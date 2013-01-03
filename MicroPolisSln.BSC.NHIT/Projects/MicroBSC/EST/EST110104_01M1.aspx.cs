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
using System.IO;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;
using System.Drawing;

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

using MicroBSC.Common;

public partial class EST110104_01M1 : AppPageBase
{

    public string SCORE_ORI_LIST
    {
        get
        {
            if (ViewState["SCORE_ORI_LIST"] == null)
            {
                ViewState["SCORE_ORI_LIST"] = GetRequest("SCORE_ORI_LIST", "");
            }

            return (string)ViewState["SCORE_ORI_LIST"];
        }
        set
        {
            ViewState["SCORE_ORI_LIST"] = value;
        }
    }
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "U");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public string iPopUpType
    {
        get
        {
            if (ViewState["POPUP_TYPE"] == null)
            {
                ViewState["POPUP_TYPE"] = GetRequest("POPUP_TYPE", "R");
            }

            return (string)ViewState["POPUP_TYPE"];
        }
        set
        {
            ViewState["POPUP_TYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
                hdnEstTermID.Value = GetRequest("ESTTERM_REF_ID", "");
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
                hdnKpiId.Value = GetRequest("KPI_REF_ID", "");
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public int IGroupRefID
    {
        get
        {
            if (ViewState["GROUP_REF_ID"] == null)
            {
                ViewState["GROUP_REF_ID"] = GetRequestByInt("GROUP_REF_ID", 0);
                hdnKpiId.Value = GetRequest("GROUP_REF_ID", "");
            }

            return (int)ViewState["GROUP_REF_ID"];
        }
        set
        {
            ViewState["GROUP_REF_ID"] = value;
        }
    }

    public int IEstLevel
    {
        get
        {
            if (ViewState["EST_LEVEL"] == null)
            {
                ViewState["EST_LEVEL"] = GetRequestByInt("EST_LEVEL", 0);
                hdnKpiId.Value = GetRequest("EST_LEVEL", "");
            }

            return (int)ViewState["EST_LEVEL"];
        }
        set
        {
            ViewState["EST_LEVEL"] = value;
        }
    }

    public int IEstEmpID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
            {
                ViewState["EST_EMP_ID"] = GetRequestByInt("EST_EMP_ID", 0);
            }

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }

    public int IKpiPoolRefID
    {
        get
        {
            if (ViewState["KPI_POOL_REF_ID"] == null)
            {
                ViewState["KPI_POOL_REF_ID"] = GetRequestByInt("KPI_POOL_REF_ID", 0);
            }

            return (int)ViewState["KPI_POOL_REF_ID"];
        }
        set
        {
            ViewState["KPI_POOL_REF_ID"] = value;
        }
    }

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
                hdnYMD.Value = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string IYMD_NEXT
    {
        get
        {
            if (ViewState["YMD_NEXT"] == null)
            {
                ViewState["YMD_NEXT"] = GetRequest("YMD_NEXT", "-");
            }

            return (string)ViewState["YMD_NEXT"];
        }
        set
        {
            ViewState["YMD_NEXT"] = value;
        }
    }

    public string IChampionEmpYN
    {
        get
        {
            if (ViewState["CHAMPION_EMP_YN"] == null)
            {
                ViewState["CHAMPION_EMP_YN"] = GetRequest("CHAMPION_EMP_YN", "N");
            }

            return (string)ViewState["CHAMPION_EMP_YN"];
        }
        set
        {
            ViewState["CHAMPION_EMP_YN"] = value;
        }
    }

    public string IApprovalEmpYN
    {
        get
        {
            if (ViewState["APPROVAL_EMP_YN"] == null)
            {
                ViewState["APPROVAL_EMP_YN"] = GetRequest("APPROVAL_EMP_YN", "N");
            }

            return (string)ViewState["APPROVAL_EMP_YN"];
        }
        set
        {
            ViewState["APPROVAL_EMP_YN"] = value;
        }
    }

    public string ICheckStatus
    {
        get
        {
            if (ViewState["CHECKSTATUS"] == null)
            {
                ViewState["CHECKSTATUS"] = GetRequest("CHECKSTATUS", "N");
            }

            return (string)ViewState["CHECKSTATUS"];
        }
        set
        {
            ViewState["CHECKSTATUS"] = value;
        }
    }

    public string IConfirmStatus
    {
        get
        {
            if (ViewState["CONFIRMSTATUS"] == null)
            {
                ViewState["CONFIRMSTATUS"] = GetRequest("CONFIRMSTATUS", "N");
            }

            return (string)ViewState["CONFIRMSTATUS"];
        }
        set
        {
            ViewState["CONFIRMSTATUS"] = value;
        }
    }

    public string IYearlyClose_YN
    {
        get
        {
            if (ViewState["YEARLY_CLOSE_YN"] == null)
            {
                ViewState["YEARLY_CLOSE_YN"] = GetRequest("YEARLY_CLOSE_YN");
            }
            return (string)ViewState["YEARLY_CLOSE_YN"];
        }
        set
        {
            ViewState["YEARLY_CLOSE_YN"] = value;
        }
    }

    public string IMontylyClose_YN
    {
        get
        {
            if (ViewState["MONTHLY_CLOSE_YN"] == null)
            {
                ViewState["MONTHLY_CLOSE_YN"] = GetRequest("MONTHLY_CLOSE_YN", "Y");
            }
            return (string)ViewState["MONTHLY_CLOSE_YN"];
        }
        set
        {
            ViewState["MONTHLY_CLOSE_YN"] = value;
        }
    }

    public string IisPassCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_CLOSE_DAY"] = GetRequest("IS_PASS_CLOSE_DAY");
            }
            return (string)ViewState["IS_PASS_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_CLOSE_DAY"] = value;
        }
    }

    public string IisPassPreCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_PRE_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_PRE_CLOSE_DAY"] = GetRequest("IS_PASS_PRE_CLOSE_DAY");
            }
            return (string)ViewState["IS_PASS_PRE_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_PRE_CLOSE_DAY"] = value;
        }
    }

    public string IisPassQLTCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_QLT_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_QLT_CLOSE_DAY"] = GetRequest("IS_PASS_QLT_CLOSE_DAY", "N");
            }
            return (string)ViewState["IS_PASS_QLT_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_QLT_CLOSE_DAY"] = value;
        }
    }

    public string IFROMKEY
    {
        get
        {
            if (ViewState["FROMKEY"] == null)
            {
                ViewState["FROMKEY"] = GetRequest("FROMKEY");
            }
            return (string)ViewState["FROMKEY"];
        }
        set
        {
            ViewState["FROMKEY"] = value;
        }
    }

    public string IROW_NO
    {
        get
        {
            if (ViewState["ROW_NO"] == null)
            {
                ViewState["ROW_NO"] = GetRequest("ROW_NO");
            }

            return (string)ViewState["ROW_NO"];
        }
        set
        {
            ViewState["ROW_NO"] = value;
        }
    }

    public string IisAdmin
    {
        get
        {
            if (ViewState["IS_ADMIN"] == null)
            {
                ViewState["IS_ADMIN"] = GetRequest("IS_ADMIN", "N");
            }

            return (string)ViewState["IS_ADMIN"];
        }
        set
        {
            ViewState["IS_ADMIN"] = value;
        }
    }

    public string IResultInputType
    {
        get
        {
            if (ViewState["RESULT_INPUT_TYPE"] == null)
            {
                ViewState["RESULT_INPUT_TYPE"] = GetRequest("RESULT_INPUT_TYPE", "MAN");
            }

            return (string)ViewState["RESULT_INPUT_TYPE"];
        }
        set
        {
            ViewState["RESULT_INPUT_TYPE"] = value;
        }
    }

    public string IResultTsCalcType
    {
        get
        {
            if (ViewState["RESULT_TS_CALC_TYPE"] == null)
            {
                ViewState["RESULT_TS_CALC_TYPE"] = GetRequest("RESULT_TS_CALC_TYPE", "");
            }

            return (string)ViewState["RESULT_TS_CALC_TYPE"];
        }
        set
        {
            ViewState["RESULT_TS_CALC_TYPE"] = value;
        }
    }

    public string IEstStatus
    {
        get
        {
            if (ViewState["ESTSTATUS"] == null)
            {
                ViewState["ESTSTATUS"] = GetRequest("ESTSTATUS", "N");
            }

            return (string)ViewState["ESTSTATUS"];
        }
        set
        {
            ViewState["ESTSTATUS"] = value;
        }
    }

    public string IKpiExternalType
    {
        get
        {
            if (ViewState["KPI_EXTERNAL_TYPE"] == null)
            {
                ViewState["KPI_EXTERNAL_TYPE"] = GetRequest("KPI_EXTERNAL_TYPE", "");
            }

            return (string)ViewState["KPI_EXTERNAL_TYPE"];
        }
        set
        {
            ViewState["KPI_EXTERNAL_TYPE"] = value;
        }
    }


    /// <summary>
    /// 자식지표가 있는지 없는지 여부
    /// </summary>
    public string IHaveChildKpiYn
    {
        get
        {
            if (ViewState["HAVE_CHILD_KPI_YN"] == null)
            {
                ViewState["HAVE_CHILD_KPI_YN"] = GetRequest("HAVE_CHILD_KPI_YN", "N");
            }

            return (string)ViewState["HAVE_CHILD_KPI_YN"];
        }
        set
        {
            ViewState["HAVE_CHILD_KPI_YN"] = value;
        }
    }

    /// <summary>
    /// 관련프로젝트가 매핑되어있는지 여부
    /// </summary>
    public string IHaveInitive_YN
    {
        get
        {
            if (ViewState["HAVE_INITIATIVE_YN"] == null)
            {
                ViewState["HAVE_INITIATIVE_YN"] = GetRequest("HAVE_INITIATIVE_YN", "N");
            }
            return (string)ViewState["HAVE_INITIATIVE_YN"];
        }
        set
        {
            ViewState["HAVE_INITIATIVE_YN"] = value;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DoInitializing();

            SetEstQuestionListGrid();
        }
        else
        {

        }

        ltrScript.Text = "";
    }

    private void DoInitializing()
    {
        Biz_Bsc_Kpi_Pool objPool = new Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
        ltrEstBasis.Text = objPool.Ivaluation_basis;
        //this.IKpiGroupRefID = objPool.Ikpi_type;
        //this.IKpiExternalType = objPool.Ikpi_external_type;

        //Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        //objCode.GetKpiQualityEstimateGrade(ddlScoreGrade, 0, false, 10);
    }


    /// <summary>
    /// 정성지표 평가조회
    /// </summary>
    private void SetEstQuestionListGrid()
    {
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Question bizBscKpiPoolQuestion = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Question();
        DataSet rDs = bizBscKpiPoolQuestion.GetBscKpiPoolQuestion_DB(this.IKpiRefID
                                                                   , "Y");

        ugrdQuestionList.DataSource = rDs;
        ugrdQuestionList.DataBind();

        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info bizComCodeInfo = new Biz_Com_Code_Info();

        DataTable dtComcodeInfo = bizComCodeInfo.GetCodeListPerCategory("BS012","Y").Tables[0];

        ugrdQuestionList.Columns.FromKey("POINT").ValueList.DataSource = dtComcodeInfo;
        ugrdQuestionList.Columns.FromKey("POINT").ValueList.DisplayMember = "CODE_NAME";
        ugrdQuestionList.Columns.FromKey("POINT").ValueList.ValueMember = "SEGMENT1";
        ugrdQuestionList.Columns.FromKey("POINT").ValueList.DataBind();


    }


    protected void ugrdQuestionList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //if (this.IKpiGroupRefID == "QLT") // 비계량
        //{
        //    e.Layout.Bands[0].Columns.FromKey("TXTSCORE").Hidden = true;
        //    e.Layout.Bands[0].Columns.FromKey("DDLSCORE").Hidden = false;
        //}
        //else if (this.IKpiGroupRefID == "COM") // 공통
        //{
        //    e.Layout.Bands[0].Columns.FromKey("TXTSCORE").Hidden = false;
        //    e.Layout.Bands[0].Columns.FromKey("DDLSCORE").Hidden = true;
        //}
        //else
        //{
        //    e.Layout.Bands[0].Columns.FromKey("TXTSCORE").Hidden = true;
        //    e.Layout.Bands[0].Columns.FromKey("DDLSCORE").Hidden = true;
        //}
    }

    protected void ugrdQuestionList_InitializeRow(object sender, RowEventArgs e)
    {
        string[] temp = SCORE_ORI_LIST.Split(';');

        if (temp.Length > 1 && temp.Length >= e.Row.Index)
        {
            string[] temp2 = temp[e.Row.Index].Split('/');
            
            e.Row.Cells.FromKey("POINT").Text = temp[e.Row.Index];
            e.Row.Cells.FromKey("POINT").Value = temp2[1];
        }

        //if (this.IKpiGroupRefID == "QLT")
        //{
            //string selVal = e.Row.Cells.FromKey("DDLSCORE").Value.ToString();
            //TemplatedColumn tColDDLScore = (TemplatedColumn)e.Row.Cells.FromKey("DDLSCORE").Column;
            //DropDownList ddlScore = (DropDownList)((CellItem)tColDDLScore.CellItems[e.Row.BandIndex]).FindControl("ddlScore");

            //for (int i = 0; i < ddlScoreGrade.Items.Count; i++)
            //{
            //    ddlScore.Items.Add(new ListItem(ddlScoreGrade.Items[i].Text, ddlScoreGrade.Items[i].Value));

            //}

            //PageUtility.FindByValueDropDownList(ddlScore, selVal);
        //}
        //else
        //{
        //    TemplatedColumn tColTXTScore = (TemplatedColumn)e.Row.Cells.FromKey("TXTSCORE").Column;
        //    WebNumericEdit txtScore = (WebNumericEdit)((CellItem)tColTXTScore.CellItems[e.Row.BandIndex]).FindControl("txtScore");
        //    txtScore.Text = e.Row.Cells.FromKey("TXTSCORE").Value.ToString();
        //}
    }

    protected void iBtnConfirmOpinion_Click(object sender, ImageClickEventArgs e)
    {
        double total = 0.0;//정성평가 점수
        string point_list = string.Empty;//정성평가 질의 평가 결과

        for (int i = 0; i < ugrdQuestionList.Rows.Count; i++)
        {
            double weight = DataTypeUtility.GetToDouble(ugrdQuestionList.Rows[i].Cells.FromKey("WEIGHT").Value) * 0.01;
            double point = DataTypeUtility.GetToDouble(ugrdQuestionList.Rows[i].Cells.FromKey("POINT").Value);

            string point_text = DataTypeUtility.GetValue(ugrdQuestionList.Rows[i].Cells.FromKey("POINT").Text);

            point_list += ";" + point_text;

            double result = weight * point;

            total += result;
        }

        if (point_list.Length > 2)
        {
            point_list = point_list.Remove(0, 1);
        }


        string grid_id = IFROMKEY.Split(';')[0];
        string col_final_score = IFROMKEY.Split(';')[1];
        string col_score_ori_list = IFROMKEY.Split(';')[2];
        string col_grade_pop = IFROMKEY.Split(';')[3];


        string jscript = JSHelper.GetSclipt(string.Format("doSettingValueInCell('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}');"
                                                         , grid_id
                                                         , col_final_score
                                                         , col_score_ori_list
                                                         , col_grade_pop
                                                         , IROW_NO
                                                         , total
                                                         , point_list));

        ltrScript.Text = jscript;

    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
    }
    
}
