using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

using Dundas.Charting.WebControl;

using MicroBSC.Estimation.Biz;
using MicroCharts;
using MicroBSC.Integration.PageCommon.Biz;

public partial class EST_EST110200 : EstPageBase
{
    #region ================ 필드 =======================

    public string EST_ID;
    public string EST_TGT_TYPE;
    public string YEAR_YN;
    public string MERGE_YN;
    public string DEPT_COLUMN_NO_USE_YN;
    public string ESTTERM_SUB_ALL_USE_YN;
    public string ESTTERM_STEP_ALL_USE_YN;
    private string DEPT_VALUES;

    #endregion

    #region ================ 프로퍼티 =======================

    private string GraphType
    {
        get
        {
            return (ViewState["GraphType"] == null) ? "LowHigh" : (string)ViewState["GraphType"]; 
        }
        set 
        {
            ViewState["GraphType"] = value;
        }
    }

    private BiasType DataType
    {
        get
        {
            return (ViewState["DataType"] == null) ? BiasType.ORG : (BiasType)ViewState["DataType"];
        }
        set
        {
            ViewState["DataType"] = value;
        }
    }

    #endregion

    #region ================ Page 이벤트 =======================

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        EST_JOB_IDS             = WebUtility.GetRequest("EST_JOB_IDS");
        EST_TGT_TYPE            = WebUtility.GetRequest("EST_TGT_TYPE", "EST");
        YEAR_YN                 = WebUtility.GetRequest("YEAR_YN", "N");
        MERGE_YN                = WebUtility.GetRequest("MERGE_YN", "N");
        DEPT_COLUMN_NO_USE_YN   = WebUtility.GetRequest("DEPT_COLUMN_NO_USE_YN", "N");
        ESTTERM_SUB_ALL_USE_YN  = WebUtility.GetRequest("ESTTERM_SUB_ALL_USE_YN", "N");
        ESTTERM_STEP_ALL_USE_YN = WebUtility.GetRequest("ESTTERM_STEP_ALL_USE_YN", "N");
        EST_JOB_ID              = "JOB_04";
        EST_JOB_IDS             = "JOB_04";

        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnApplyBiasPoint);
        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnCalcBiasPoint);

        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");
            DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");
            DropDownListCommom.BindBiasType(ddlBiasTypeID);

            if(COMP_ID == 0) 
                COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

            if(ESTTERM_REF_ID == 0)
                ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

            if(ESTTERM_SUB_ID == 0)
                ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

            if(ESTTERM_STEP_ID == 0)
                ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

            ibnSearch.Attributes.Add("onclick", "return Search();");
            ibnApplyBiasPoint.Attributes.Add("onclick", "return confirm('정말 선택된 조정방식으로 점수를 Bias 조정 하시겠습니까?');");
            ibnCalcBiasPoint.Attributes.Add("onclick", "return confirm('Bias 조정점수를 계산 실행하시겠습니까?');");

            if(!WebUtility.GetRequest("EST_ID").Equals(""))
            {
                txtSearchEstName.Visible    = false;
                imgEstButton.Visible        = false;
                ibnSearch.Visible           = false;

                hdfSearchEstID.Value        = WebUtility.GetRequest("EST_ID");
                EST_ID                      = hdfSearchEstID.Value;

                BindingData(  COMP_ID
                            , EST_ID
                            , ESTTERM_REF_ID
                            , ESTTERM_SUB_ID
                            , ESTTERM_STEP_ID
                            , GraphType
                            , DataType);

                //2011.12.27 박효동 : 아래는 없던건데 만들어놓았다..일단은 없이 가자고 함(허성덕과장)
                //Biz_EstInfos bizEstInfo = new Biz_EstInfos(COMP_ID, EST_ID);
                //if (bizEstInfo.Bias_Type_ID != "" && bizEstInfo.Bias_YN != "")
                //{
                //    PageUtility.FindByValueDropDownList(ddlBiasTypeID, bizEstInfo.Bias_Type_ID);
                //    ddlBiasTypeID.Enabled = false;
                //}
            }
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID          = hdfSearchEstID.Value;
        ESTTERM_REF_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

        if(YEAR_YN.Equals("Y")) 
        {
            ESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(COMP_ID);
        }
        else
        {
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        }

        if(MERGE_YN.Equals("Y")) 
        {
            ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
        }
        else
        {
            if(ESTTERM_STEP_ALL_USE_YN.Equals("Y")) 
            {
                ESTTERM_STEP_ID = 0;
            }
            else
            {
                ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
            }
        }

        DEPT_VALUES = hdfEstDept.Value;

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if(YEAR_YN.Equals("Y"))
            ddlEstTermSubID.Visible = false;

        if(MERGE_YN.Equals("Y"))
            ddlEstTermStepID.Visible = false;
    }

    #endregion

    #region ================ 메소드 =======================

    private void BindChart(int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string graphType
                        , BiasType biasType
                        , string dept_values) 
    {
        if(tdBiasDept.Visible && hdfEstDept.Value.Trim().Equals("")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("Bias 조정을 위한 부서 범위를 선택하세요.");
            return;
        }

        Biz_Datas data  = new Biz_Datas();
        string query    = data.GetBiasQueryScript(comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , biasType.ToString()
                                                , dept_values);

        if(graphType.Equals("Radar")) 
        {
            //try 
            //{
                BindRadarChart(   Chart1
                                , query
                                , biasType
                                , ChartImageType.Flash);
            //}
            //catch(Exception ex) 
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("Bias할 수 있는 데이터가 아닙니다." + );
            //    return;
            //}
        }
        else if(graphType.Equals("LowHigh")) 
        {
            //try 
            //{
                BindRangeColumnChart( Chart1
                                    , query
                                    , biasType
                                    , ChartImageType.Flash);
            //}
            //catch(Exception ex) 
            //{
            //    ltrScript.Text = JSHelper.GetAlertScript("Bias할 수 있는 데이터가 아닙니다.");
            //    return;
            //}
        }

        BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
                                            , ibnApplyBiasPoint
                                            , COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID);

        BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
                                            , ibnCalcBiasPoint
                                            , COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID);

        ddlBiasTypeID.Visible = ibnApplyBiasPoint.Visible;
    }

    private void BindingData( int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string graphType
                            , BiasType dataType) 
    {
        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        if(!estInfo.IsExists(comp_id, est_id)) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
            return;
        }

        DropDownListCommom.BindEstTermSub(ddlEstTermSubID, comp_id, est_id, "");
        DropDownListCommom.BindEstTermStep(ddlEstTermStepID, comp_id, est_id);

        // 처음 실행될때
        if(estterm_sub_id.Equals(0))
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        // 만약 주기가 년간일 경우
        if(YEAR_YN.Equals("Y")) 
        {
            ESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(COMP_ID);
        }

        // 만약 차수가 합산일 경우
        if(MERGE_YN.Equals("Y")) 
        {
            ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);
        }
        else 
        {
            // 만약 모든 차수를 보여 줘야하는 경우
            if(ESTTERM_STEP_ALL_USE_YN.Equals("Y")) 
            {
                ESTTERM_STEP_ID             = 0;
                ddlEstTermStepID.Visible    = false;
            }
        }

        WebUtility.FindByValueDropDownList(ddlEstTermRefID, estterm_ref_id);
        
        if(ddlEstTermSubID.Visible) 
            WebUtility.FindByValueDropDownList(ddlEstTermSubID, estterm_sub_id);

        if(ddlEstTermStepID.Visible) 
            WebUtility.FindByValueDropDownList(ddlEstTermStepID, estterm_step_id);

        if(estInfo.Owner_Type.Equals("D")) 
                OwnerTypeMode   = OwnerType.Dept;
            else 
                OwnerTypeMode   = OwnerType.Emp_User;

        ScaleTypeMode   = estInfo.Scale_Type;
        WeightTypeMode  = estInfo.Weight_Type;

        if(estInfo.Bias_YN.Equals("Y"))
            BiasYN          = YesNo.Yes;
        else
            BiasYN          = YesNo.No;

        if(estInfo.Grade_Confirm_YN.Equals("Y"))
            GradeConfirmYN = YesNo.Yes;
        else
            GradeConfirmYN = YesNo.No;

        Biz_Datas est_data   = new Biz_Datas();

        int est_emp_id      = 0;;
        int tgt_dept_id     = 0;
        int tgt_emp_id      = 0;

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            if(EST_TGT_TYPE.Equals("EST"))
            {
                est_emp_id  = EMP_REF_ID;
                tgt_dept_id = 0;
                tgt_emp_id  = 0;
            }
            else if(EST_TGT_TYPE.Equals("TGT"))
            {
                est_emp_id  = 0;
                tgt_dept_id = BizUtility.GetDeptID(EMP_REF_ID);
                tgt_emp_id  = -1;
            }
        }
        else if(OwnerTypeMode == OwnerType.Emp_User) 
        {
            if(EST_TGT_TYPE.Equals("EST"))
            {
                est_emp_id  = EMP_REF_ID;
                tgt_dept_id = 0;
                tgt_emp_id  = 0;
            }
            else if(EST_TGT_TYPE.Equals("TGT"))
            {
                est_emp_id  = 0;
                tgt_dept_id = 0;
                tgt_emp_id  = EMP_REF_ID;
            }
        }

        if(OwnerTypeMode == OwnerType.Dept && COL_DEPT_TO_EMP_DATA.Equals("Y")) 
        {
            OwnerTypeMode = OwnerType.Emp_User;
        }
        else if(OwnerTypeMode == OwnerType.Emp_User && COL_DEPT_TO_EMP_DATA.Equals("Y")) 
        {
            OwnerTypeMode = OwnerType.Dept;
        }

        if(estInfo.Bias_Dept_Use_YN.Equals("Y")) 
        {
            tdBiasDept.Visible = true;
        }
        else 
        {
            tdBiasDept.Visible  = false;
            hdfEstDept.Value    = "";
        }

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    private void BindRadarChart(  Chart chart
                                , string query
                                , BiasType biasType
                                , ChartImageType chartImageType)
    {
        //DundasCharts.DundasChartBase(chart
        //                            , chartImageType
        //                            , 800
        //                            , 400
        //                            , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
        //                            , Color.FromArgb(0xFF, 0xFF, 0xFE)
        //                            , Color.FromArgb(0xFF, 0xFF, 0xFE)
        //                            , Color.FromArgb(0x20, 0x80, 0xD0)
        //                            , ChartDashStyle.Solid
        //                            , -1
        //                            , ChartHatchStyle.None
        //                            , GradientType.TopBottom
        //                            , AntiAliasing.None);
        Biz_DundasCharts.DundasChartBase(chart
                                    , chartImageType
                                    , 800
                                    , 400
                                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , ChartDashStyle.Solid
                                    , -1
                                    , ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);




        //Series series1 = DundasCharts.CreateSeries(chart
        //                                        , "Series1"
        //                                        , "Default"
        //                                        , "최대값"
        //                                        , null
        //                                        , SeriesChartType.Radar
        //                                        , 1
        //                                        , Color.FromArgb(0x5A, 0x7D, 0xDE)
        //                                        , Color.FromArgb(0x4A, 0x58, 0x7E)
        //                                        , Color.FromArgb(64, 0, 0, 0)
        //                                        , 1
        //                                        , 9
        //                                        , Color.FromArgb(64, 64, 64));
        Series series1 = Biz_DundasCharts.CreateSeries(chart
                                                , "Series1"
                                                , "Default"
                                                , "최대값"
                                                , null
                                                , SeriesChartType.Radar
                                                , 1
                                                , Color.FromArgb(0x5A, 0x7D, 0xDE)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));




        //Series series2 = DundasCharts.CreateSeries(chart
        //                                        , "Series2"
        //                                        , "Default"
        //                                        , "최소값"
        //                                        , null
        //                                        , SeriesChartType.Radar
        //                                        , 1
        //                                        , Color.FromArgb(0xFF, 0x8A, 0x00)
        //                                        , Color.FromArgb(0xD7, 0x41, 0x01)
        //                                        , Color.FromArgb(64, 0, 0, 0)
        //                                        , 1
        //                                        , 9
        //                                        , Color.FromArgb(64, 64, 64));
        Series series2 = Biz_DundasCharts.CreateSeries(chart
                                                , "Series2"
                                                , "Default"
                                                , "최소값"
                                                , null
                                                , SeriesChartType.Radar
                                                , 1
                                                , Color.FromArgb(0xFF, 0x8A, 0x00)
                                                , Color.FromArgb(0xD7, 0x41, 0x01)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));




        series1.ToolTip             = "#VALY{#,##0}";
        series2.ToolTip             = "#VALY{#,##0}";

        series1.MarkerStyle         = MarkerStyle.Circle;
        series2.MarkerStyle         = MarkerStyle.Diamond;
        series1.MarkerColor         = Color.FromArgb(0x7A, 0x9D, 0xFE);
        series2.MarkerColor         = Color.FromArgb(0xFF, 0xAA, 0x20);
        series1.MarkerBorderColor   = Color.FromArgb(0x4A, 0x58, 0x7E);
        series2.MarkerBorderColor   = Color.FromArgb(0xD7, 0x41, 0x01);

        ArrayList yValues1;
        ArrayList yValues2;
        ArrayList xValues;

        //DundasCharts.SetDataFieldsX1(query
        //                            , "EST_EMP_NAME"
        //                            , out xValues
        //                            , "PNT_MAX"
        //                            , out yValues1
        //                            , "PNT_MIN"
        //                            , out yValues2);
        Biz_DundasCharts.SetDataFieldsX1(query
                                    , "EST_EMP_NAME"
                                    , out xValues
                                    , "PNT_MAX"
                                    , out yValues1
                                    , "PNT_MIN"
                                    , out yValues2);




        series1.Points.DataBindXY(xValues, yValues1);
        series2.Points.DataBindXY(xValues, yValues2);

        if (chartImageType == ChartImageType.Flash) 
        {
            DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 1);
            DundasAnimations.GrowingAnimation(chart, series1, 0.0, 3.0, false);
            DundasAnimations.GrowingAnimation(chart, series2, 3.0, 6.0, true);
        }

        // Set radar chart style Line, Area, Marker
        series1["RadarDrawingStyle"] = "Line";
        series2["RadarDrawingStyle"] = "Line";

        // Set circular area drawing style //Circle, Polygon
        series1["AreaDrawingStyle"] = "Polygon";
        series2["AreaDrawingStyle"] = "Polygon";

        // Set labels style //Horizontal, Circular, Radial
        series1["CircularLabelsStyle"] = "Horizontal";
        series2["CircularLabelsStyle"] = "Horizontal";

        string titleStr = "";

        if (biasType == BiasType.ORG)
            titleStr = "원시 점수";
        else if (biasType == BiasType.AVG)
            titleStr = "평균조정 점수";
        else if (biasType == BiasType.STD)
            titleStr = "평균편차조정 점수";

        Font font   = new Font("Gulim", 13, FontStyle.Regular);
        Font font1  = new Font("Gulim", 9, FontStyle.Regular);

        //Dundas.Charting.WebControl.Title title = DundasCharts.CreateTitle(chart
        //                                                                , "Title1"
        //                                                                , titleStr, font
        //                                                                , Color.FromArgb(26, 59, 105)
        //                                                                , Color.Empty
        //                                                                , Color.Empty
        //                                                                , ContentAlignment.TopCenter
        //                                                                , null
        //                                                                , Color.FromArgb(32, 0, 0, 0)
        //                                                                , 3
        //                                                                , false
        //                                                                , 5
        //                                                                , 5
        //                                                                , 91
        //                                                                , 6);
        Dundas.Charting.WebControl.Title title = Biz_DundasCharts.CreateTitle(chart
                                                                        , "Title1"
                                                                        , titleStr, font
                                                                        , Color.FromArgb(26, 59, 105)
                                                                        , Color.Empty
                                                                        , Color.Empty
                                                                        , ContentAlignment.TopCenter
                                                                        , null
                                                                        , Color.FromArgb(32, 0, 0, 0)
                                                                        , 3
                                                                        , false
                                                                        , 5
                                                                        , 5
                                                                        , 91
                                                                        , 6);




        //Legend legend = DundasCharts.CreateLegend(chart
        //                                        , "Default"
        //                                        , Color.Transparent
        //                                        , Color.Empty
        //                                        , Color.Empty
        //                                        , font1
        //                                        , false
        //                                        , 75
        //                                        , 75
        //                                        , 20
        //                                        , 15);
        Legend legend = Biz_DundasCharts.CreateLegend(chart
                                                , "Default"
                                                , Color.Transparent
                                                , Color.Empty
                                                , Color.Empty
                                                , font1
                                                , false
                                                , 75
                                                , 75
                                                , 20
                                                , 15);




        //DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
        Biz_DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }

    private void BindRangeColumnChart(Chart chart
                                    , string query
                                    , BiasType biasType
                                    , ChartImageType chartImageType)
    {
        //DundasCharts.DundasChartBase(chart
        //                            , chartImageType
        //                            , 800
        //                            , 400
        //                            , BorderSkinStyle.Emboss
        //                            , Color.FromArgb(181, 64, 1)
        //                            , 2
        //                            , Color.FromArgb(0xFF, 0xFF, 0xFE)
        //                            , Color.FromArgb(0xFF, 0xFF, 0xFE)
        //                            , Color.FromArgb(0x20, 0x80, 0xD0)
        //                            , ChartDashStyle.Solid
        //                            , -1
        //                            , ChartHatchStyle.None
        //                            , GradientType.TopBottom
        //                            , AntiAliasing.None);
        Biz_DundasCharts.DundasChartBase(chart
                                    , chartImageType
                                    , 800
                                    , 400
                                    , BorderSkinStyle.Emboss
                                    , Color.FromArgb(181, 64, 1)
                                    , 2
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , ChartDashStyle.Solid
                                    , -1
                                    , ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);




        //Series series1 = DundasCharts.CreateSeries(chart
        //                                        , "Series1"
        //                                        , "Default"
        //                                        , "최대.최소값"
        //                                        , null
        //                                        , SeriesChartType.RangeColumn
        //                                        , 1
        //                                        , Color.FromArgb(0x5A, 0x7D, 0xDE)
        //                                        , Color.FromArgb(0x4A, 0x58, 0x7E)
        //                                        , Color.FromArgb(64, 0, 0, 0)
        //                                        , 1
        //                                        , 9
        //                                        , Color.FromArgb(64, 64, 64));
        Series series1 = Biz_DundasCharts.CreateSeries(chart
                                                , "Series1"
                                                , "Default"
                                                , "최대.최소값"
                                                , null
                                                , SeriesChartType.RangeColumn
                                                , 1
                                                , Color.FromArgb(0x5A, 0x7D, 0xDE)
                                                , Color.FromArgb(0x4A, 0x58, 0x7E)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));




        //Series series2 = DundasCharts.CreateSeries(chart
        //                                        , "Series2"
        //                                        , "Default"
        //                                        , "평균값"
        //                                        , null
        //                                        , SeriesChartType.Line
        //                                        , 3
        //                                        , Color.FromArgb(0xFF, 0x8A, 0x00)
        //                                        , Color.FromArgb(0xD7, 0x41, 0x01)
        //                                        , Color.FromArgb(64, 0, 0, 0)
        //                                        , 1
        //                                        , 9
        //                                        , Color.FromArgb(64, 64, 64));
        Series series2 = Biz_DundasCharts.CreateSeries(chart
                                                , "Series2"
                                                , "Default"
                                                , "평균값"
                                                , null
                                                , SeriesChartType.Line
                                                , 3
                                                , Color.FromArgb(0xFF, 0x8A, 0x00)
                                                , Color.FromArgb(0xD7, 0x41, 0x01)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));




        //series1.ToolTip = "#VALY{#,##0,00}";
        series2.ToolTip = "#VALY{#,##0}";

        ArrayList yValues1;
        ArrayList yValues2;
        ArrayList yValues3;
        ArrayList xValues;

        Biz_DundasCharts.SetDataFieldsX1( query
                                    , "EST_EMP_NAME"
                                    , out xValues
                                    , "PNT_MAX"
                                    , out yValues1
                                    , "PNT_MIN"
                                    , out yValues2
                                    , "PNT_AVG"
                                    , out yValues3);

        series1.Points.DataBindY(yValues2, yValues1);
        series2.Points.DataBindY(yValues3, "PNT_AVG");

        for (int i = 0; i < xValues.Count; i++)
        {
            series1.Points[i].AxisLabel = xValues[i].ToString();
        }

        if (chartImageType == ChartImageType.Flash)
        {
            DundasAnimations.DundasChartBase(chart, AnimationTheme.None, -1, -1, false, 5);
            DundasAnimations.GrowingAnimation(chart, series1, 0.0, 3.0, false);
            DundasAnimations.GrowingAnimation(chart, series2, 3.0, 6.0, true);
        }

        series2.MarkerStyle         = MarkerStyle.Circle;
        series2.MarkerColor         = Color.FromArgb(0xFF, 0xAA, 0x20);
        series2.MarkerBorderColor   = Color.FromArgb(0xD7, 0x41, 0x01);

        string titleStr = "";

        if (biasType == BiasType.ORG)
            titleStr = "원시 점수";
        else if (biasType == BiasType.AVG)
            titleStr = "평균조정 점수";
        else if (biasType == BiasType.STD)
            titleStr = "평균편차조정 점수";

        Font font   = new Font("Gulim", 13, FontStyle.Regular);
        Font font1  = new Font("Gulim", 9, FontStyle.Regular);

        Dundas.Charting.WebControl.Title title = Biz_DundasCharts.CreateTitle(chart
                                                                        , "Title1"
                                                                        , titleStr
                                                                        , font
                                                                        , Color.FromArgb(26, 59, 105)
                                                                        , Color.Empty
                                                                        , Color.Empty
                                                                        , ContentAlignment.TopCenter
                                                                        , null
                                                                        , Color.FromArgb(32, 0, 0, 0)
                                                                        , 3
                                                                        , false
                                                                        , 5
                                                                        , 5
                                                                        , 91
                                                                        , 6);

        Legend legend = Biz_DundasCharts.CreateLegend(chart
                                                , "Default"
                                                , Color.Transparent
                                                , Color.Empty
                                                , Color.Empty);

        Biz_DundasCharts.SetChartArea(chart.ChartAreas["Default"], false);
    }

    #endregion

    #region ======================= 드롭다운 컨트롤 ===========================

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingData(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType);
    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    #endregion

    #region ================== 버튼 컨틀롤 ========================

    protected void ibnRadar_Click(object sender, ImageClickEventArgs e)
    {
        GraphType = "Radar";

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    protected void ibnLowHigh_Click(object sender, ImageClickEventArgs e)
    {
        GraphType = "LowHigh";

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    protected void ibnCalcBiasPoint_Click(object sender, ImageClickEventArgs e)
    {
        if(BiasYN == YesNo.Yes) 
        {
            if(tdBiasDept.Visible && hdfEstDept.Value.Trim().Equals("")) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("Bias 조정을 위한 부서 범위를 선택하세요.");
                return;
            }

            Biz_BiasDatas biasData  = new Biz_BiasDatas();
            bool isOK               = false;

            isOK                    = biasData.SetBiasAvg(COMP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , YEAR_YN
                                                        , MERGE_YN
                                                        , OwnerTypeMode
                                                        , DEPT_VALUES
                                                        , DateTime.Now
                                                        , EMP_REF_ID);

            isOK                    = biasData.SetBiasSTDev(  COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , YEAR_YN
                                                            , MERGE_YN
                                                            , OwnerTypeMode
                                                            , DEPT_VALUES
                                                            , DateTime.Now
                                                            , EMP_REF_ID);

            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 Bias 조정점수를 계산하여 적용하였습니다.");

            BindChart(COMP_ID
                    , EST_ID
                    , ESTTERM_REF_ID
                    , ESTTERM_SUB_ID
                    , ESTTERM_STEP_ID
                    , GraphType
                    , DataType
                    , DEPT_VALUES);
        }
    }

	/// <summary>
	/// 원시자료 버튼 클릭
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    protected void ibnOrg_Click(object sender, ImageClickEventArgs e)
    {
        DataType = BiasType.ORG;

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

	/// <summary>
	/// 평균조정 버튼 클릭
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    protected void ibnAvg_Click(object sender, ImageClickEventArgs e)
    {
        DataType = BiasType.AVG;

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

	/// <summary>
	/// 평균,편차 조정 버튼 클릭
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    protected void ibnStd_Click(object sender, ImageClickEventArgs e)
    {
        DataType = BiasType.STD;

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {
        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindingData(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType);

        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);
        BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
                                            , tdImgBox.Controls
                                            , COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID);
    }

	/// <summary>
	/// Bias 점수 적용
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    protected void ibnConfirmBias_Click(object sender, ImageClickEventArgs e)
    {
        if(tdBiasDept.Visible && hdfEstDept.Value.Trim().Equals("")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("Bias 조정을 위한 부서 범위를 선택하세요.");
            return;
        }
        
        Biz_BiasDatas biasData  = new Biz_BiasDatas();
        bool isOK               = false;

        isOK                    = biasData.SetBiasType(COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , 0
                                                    , WebUtility.GetByValueDropDownList(ddlBiasTypeID)
                                                    , DEPT_VALUES
                                                    , DateTime.Now
                                                    , EMP_REF_ID);

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0}로 점수를 조정 확정 하였습니다.", WebUtility.GetByTextDropDownList(ddlBiasTypeID)));
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0}로 점수를 조정 처리 중 오류가 발생하였습니다.", WebUtility.GetByTextDropDownList(ddlBiasTypeID)));
        }

        BindChart(COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , GraphType
                , DataType
                , DEPT_VALUES);
    }

    protected void ibnConfirmCancel_Click(object sender, ImageClickEventArgs e)
    {
        bool isJobOK = EstJobUtility.SetConfirmButtonVisible( COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_JOB_ID
                                                            , ibnApplyBiasPoint
                                                            , ibnConfirmCancel
                                                            , "N"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정을 취소하였습니다.");
    }

    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas data  = new Biz_Datas();
        string query    = data.GetBiasQueryScript(COMP_ID
                                                , EST_ID
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , DataType.ToString()
                                                , DEPT_VALUES);

        if(GraphType.Equals("Radar")) 
        {
            BindRadarChart(   Chart1
                            , query
                            , DataType
                            , ChartImageType.Flash);

            BindRadarChart(   Chart2
                            , query
                            , DataType
                            , ChartImageType.Jpeg);
        }
        else if(GraphType.Equals("LowHigh")) 
        {
            BindRangeColumnChart( Chart1
                                , query
                                , DataType
                                , ChartImageType.Flash);

            BindRangeColumnChart( Chart2
                                , query
                                , DataType
                                , ChartImageType.Jpeg);
        }

        string filePath = Server.MapPath("../_common/Temp/bias_graph.jpg");

        FileStream file = null;

        try 
        {
            file = new FileStream( filePath
                                , FileMode.Create
                                , System.Security.AccessControl.FileSystemRights.CreateFiles
                                , FileShare.ReadWrite
                                , 8
                                , FileOptions.None
                                , null);
        
            if(File.Exists(filePath))
                File.Delete(filePath);

            Chart2.Save(file);
            file.Close();

            string fileName = "역량평가Bias조정.jpg";
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName).Replace("+", "%20"));
            Response.ContentType = "application/unknown";
            Response.WriteFile(filePath);
        }
        catch(Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
            return;
        }
    }

    #endregion
}
