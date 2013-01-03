using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;

using MicroBSC.Estimation.Biz;
using MicroBSC.PRJ.Biz;

using Infragistics.WebUI.UltraWebGrid;

public partial class PRJ_PRJ0301M1 : EstPageBase
{
    #region ================ 필드 =======================

    public string EST_ID;
    public string EST_TGT_TYPE;
    public string YEAR_YN;
    public string MERGE_YN;
    public string DEPT_COLUMN_NO_USE_YN;
    public string ESTTERM_SUB_ALL_USE_YN;
    public string ESTTERM_STEP_ALL_USE_YN;

    #endregion

    #region ====================== Page_Load =====================

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout);
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
      
        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");
            DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");

            if(COMP_ID == 0) 
                COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

            if(ESTTERM_REF_ID == 0)
                ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

            if(ESTTERM_SUB_ID == 0)
                ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

            if(ESTTERM_STEP_ID == 0)
                ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

            ibnSearch.Attributes.Add("onclick", "return Search();");
            ibnConfirmEstQ.Attributes.Add("onclick", "return confirm('질의평가를 확정하시겠습니까?');");
            ibnAggEstTermStep.Attributes.Add("onclick", "return confirm('평가차수 간에 가중치를 반영하여 점수를 집계하시겠습니까?');");
            ibnGetPrjPoint.Attributes.Add("onclick", "return confirm('프로젝트 점수를 반영하시겠습니까?');");
            ibnProjectToEmpData.Attributes.Add("onclick", "return confirm('사원별 점수로 반영하시겠습니까?');");

            if(!WebUtility.GetRequest("EST_ID").Equals(""))
            {
                txtSearchEstName.Visible    = false;
                imgEstButton.Visible        = false;
                ibnSearch.Visible           = false;

                hdfSearchEstID.Value        = WebUtility.GetRequest("EST_ID");
                EST_ID                      = hdfSearchEstID.Value;

                GridBidingData(COMP_ID
                                , EST_ID
                                , ESTTERM_REF_ID
                                , ESTTERM_SUB_ID
                                , ESTTERM_STEP_ID
                                , EMP_REF_ID
                                , SEARCH_ALL);

                BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, tdImgBox.Controls);

                BizUtility.SetButtonVisibleByEstJobID(EST_JOB_IDS
                                                    , tdImgBox.Controls
                                                    , COMP_ID
                                                    , hdfSearchEstID.Value
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID);

                SetConfirmStatusHtml(EST_JOB_IDS);
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

        ltrScript.Text = "";

        // 상태 html
        HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, EST_ID);
    }

    #endregion

    #region ==================== Page_PreRender =============================

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if(YEAR_YN.Equals("Y"))
            ddlEstTermSubID.Visible = false;

        if(MERGE_YN.Equals("Y"))
            ddlEstTermStepID.Visible = false;
    }

    #endregion 

    #region ======================== 울트라 그리드 이벤트 ================

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
       
    }

    protected internal void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;
        BizUtility.SetStatusImage(drw, e.Row.Cells);
    }

    #endregion 

    #region ==================== 드롭다운 리스트 ================

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , EMP_REF_ID
                     , SEARCH_ALL);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , EMP_REF_ID
                     , SEARCH_ALL);
    }

    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , EMP_REF_ID
                     , SEARCH_ALL);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , EMP_REF_ID
                     , SEARCH_ALL);
    }

    #endregion 

    #region ================ 버튼 클릭 이벤트 =========================

    /// <summary>
    /// 팝업창에서 부모창을 Refresh 되었을 때
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbnReload_Click(object sender, EventArgs e)
    {
        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , EMP_REF_ID
                     , SEARCH_ALL);
    }

    /// <summary>
    /// 조회 클릭
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , EMP_REF_ID
                     , SEARCH_ALL);

        SetConfirmStatusHtml(EST_JOB_IDS);
    }

    /// <summary>
    /// 전체 리스트 가지고 오기
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibnSearchAll_Click(object sender, ImageClickEventArgs e)
    {
        SEARCH_ALL  = true;

        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , EMP_REF_ID
                     , SEARCH_ALL);
    }

    /// <summary>
    /// 질의평가 확정 (JOB_25)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibnConfirmEstQ_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Prj_Data objPrjData = new Biz_Prj_Data();
        DataTable dataTable     = objPrjData.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue( UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "EST_DEPT_ID", "EST_EMP_ID", "PRJ_REF_ID", "STATUS_ID" }
                                                            , dataTable);

        dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'P'");

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("상태가 평가 중이 아니거나 선택된 항목이 없습니다.");
            return;
        }

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
            dataRow["ESTTERM_STEP_ID"]  = ESTTERM_STEP_ID;
            dataRow["STATUS_ID"]        = "E";
        }

        bool isOK = objPrjData.SaveStatus(dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가를 확정하였습니다.");

            GridBidingData(COMP_ID
                         , EST_ID
                         , ESTTERM_REF_ID
                         , ESTTERM_SUB_ID
                         , ESTTERM_STEP_ID
                         , EMP_REF_ID
                         , SEARCH_ALL);

            SetConfirmStatusHtml(EST_JOB_IDS);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정되지 않았습니다.");
        }
    }
    protected void ibnCancelEstQ_Click(object sender, ImageClickEventArgs e)
    {

        Biz_Prj_Data objPrjData = new Biz_Prj_Data();
        DataTable dataTable = objPrjData.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "EST_DEPT_ID", "EST_EMP_ID", "PRJ_REF_ID", "STATUS_ID" }
                                                            , dataTable);

        if (dataTable.Rows.Count == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("상태가 평가완료가 아니거나 선택된 항목이 없습니다.");
            return;
        }
        else
        {
            dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "STATUS_ID = 'E'");
        }


        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"] = COMP_ID;
            dataRow["EST_ID"] = EST_ID;
            dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
            dataRow["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
            dataRow["STATUS_ID"] = "P";
        }

        bool isOK = objPrjData.SaveStatus(dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 질의평가를 취소하였습니다.");

            GridBidingData(COMP_ID
                       , EST_ID
                       , ESTTERM_REF_ID
                       , ESTTERM_SUB_ID
                       , ESTTERM_STEP_ID
                       , EMP_REF_ID
                       , SEARCH_ALL);

            SetConfirmStatusHtml(EST_JOB_IDS);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 취소되지 않았습니다.");
        }
    }

   
    /// <summary>
    /// 다운로드
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName     = "PRJ" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName    = "PRJ_DATA";

        uGridExcelExporter.Export(UltraWebGrid1);
    }

    protected void ibnAggEstTermStep_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn = ((ImageButton)sender);
        string est_job_id = ibn.CommandArgument;

        bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , est_job_id
                                                            , ibnAggEstTermStep
                                                            , null
                                                            , "Y"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        if (!isJobOK)
            return;

        Biz_Prj_Data objPrjData = new Biz_Prj_Data();

        DataTable dtStatusCheck = objPrjData.GetDataByMergeYN(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , MERGE_YN).Tables[0];

        if (dtStatusCheck.Rows.Count != dtStatusCheck.Select("STATUS_ID = 'E'").Length)
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정되지 않은 평가정보가 있습니다. 모두 확정된 상태에서 차수별 합산이 가능합니다.");
            return;
        }

        //, BizUtility.GetTotalWeightEstTermStep(COMP_ID, EST_ID)
        // MERGE_YN 이 N 인 이유는 N인 것만 데이터를 수집해서 집계하기 때문
        bool isOK = objPrjData.AggregateEstTermStepEstData(COMP_ID
                                                                , EST_ID
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , ESTTERM_STEP_ID
                                                                , BizUtility.GetTotalWeightEstTermStep(COMP_ID, EST_ID)
                                                                , YEAR_YN
                                                                , "N");

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가차수에 따른 가중치 집계를 처리하였습니다.");

            GridBidingData(COMP_ID
                        , EST_ID
                        , ESTTERM_REF_ID
                        , ESTTERM_SUB_ID
                        , ESTTERM_STEP_ID
                        , EMP_REF_ID
                        , SEARCH_ALL);

            SetConfirmStatusHtml(EST_JOB_IDS);
        }
        else
        {
            //EstJobUtility.SetConfirmButtonVisible(COMP_ID
            //                                    , EST_ID
            //                                    , ESTTERM_REF_ID
            //                                    , ESTTERM_SUB_ID
            //                                    , ESTTERM_STEP_ID
            //                                    , est_job_id
            //                                    , ibn
            //                                    , null
            //                                    , "N"
            //                                    , DateTime.Now
            //                                    , EMP_REF_ID
            //                                    , ltrScript);

            ltrScript.Text = JSHelper.GetAlertScript("가중치 집계 처리 중 오류가 발생하였습니다.");
        }
    }

    protected void ibnProjectToEmpData_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn = ((ImageButton)sender);
        string est_job_id = ibn.CommandArgument;

        //bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
        //                                                            , EST_ID
        //                                                            , ESTTERM_REF_ID
        //                                                            , ESTTERM_SUB_ID
        //                                                            , ESTTERM_STEP_ID
        //                                                            , est_job_id
        //                                      ibnDownExcel                      , ibn
        //                                                            , null
        //                                                            , "Y"
        //                                                            , DateTime.Now
        //                                                            , EMP_REF_ID
        //                                                            , ltrScript);

        //if (!isJobOK)
        //    return;

        Biz_Prj_Data data = new Biz_Prj_Data();

        bool isOK = data.CopyProjectToEmpData(COMP_ID
                                                , EST_ID
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , YEAR_YN
                                                , MERGE_YN
                                                , DateTime.Now
                                                , EMP_REF_ID);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 프로젝트 평가 정보를 사원 평가 정보로 변환하였습니다.");

            GridBidingData(COMP_ID
                       , EST_ID
                       , ESTTERM_REF_ID
                       , ESTTERM_SUB_ID
                       , ESTTERM_STEP_ID
                       , EMP_REF_ID
                       , SEARCH_ALL);

            SetConfirmStatusHtml(EST_JOB_IDS);
        }
        else
        {
            //EstJobUtility.SetConfirmButtonVisible(COMP_ID
            //                                    , EST_ID
            //                                    , ESTTERM_REF_ID
            //                                    , ESTTERM_SUB_ID
            //                                    , ESTTERM_STEP_ID
            //                                    , est_job_id
            //                                    , ibn
            //                                    , null
            //                                    , "N"
            //                                    , DateTime.Now
            //                                    , EMP_REF_ID
            //                                    , ltrScript);

            ltrScript.Text = JSHelper.GetAlertScript("프로젝트 평가 정보를 사원 평가 정보로 변환 중 오류가 발생하였습니다.");
        }
    }

    protected void ibnGetPrjPoint_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn = ((ImageButton)sender);
        string est_job_id = ibn.CommandArgument;

        if (HasGroupByColumns()) return;

        bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , est_job_id
                                                            , ibn
                                                            , null
                                                            , "Y"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        if (!isJobOK)
            return;

        Biz_OuterDataProcInfos biz_data = new Biz_OuterDataProcInfos();
        string msg = null;
        bool isOK = biz_data.GetOuterData(COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , ESTTERM_STEP_ID
                                                                    , out msg);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 프로젝트평가 데이터를 반영하였습니다.");


            GridBidingData(COMP_ID
                         , EST_ID
                         , ESTTERM_REF_ID
                         , ESTTERM_SUB_ID
                         , ESTTERM_STEP_ID
                         , EMP_REF_ID
                         , SEARCH_ALL);

            SetConfirmStatusHtml(EST_JOB_IDS);
        }
        else
        {
            EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                                , EST_ID
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , est_job_id
                                                , ibn
                                                , null
                                                , "N"
                                                , DateTime.Now
                                                , EMP_REF_ID
                                                , ltrScript);

            ltrScript.Text = JSHelper.GetAlertScript(msg);
        }
    }
    
    #endregion

    #region =================== 일반 메소드 ==========================

    /// <summary>
    /// 그리드 바인딩 메소드
    /// </summary>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <param name="estterm_ref_id"></param>
    /// <param name="estterm_sub_id"></param>
    /// <param name="estterm_step_id"></param>
    private void GridBidingData(  int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_emp_id
                                , bool isAll) 
    {
        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        if (!estInfo.IsExists(comp_id, est_id))
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

        // 상태 html
        HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, est_id);

        Biz_Prj_Data objPrjData = new Biz_Prj_Data();

        if (isAll)
        {
            est_emp_id  = 0;
        }

        DataTable dt    = objPrjData.GetPrjData(  comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , 0
                                                , est_emp_id
                                                , 0
                                                , YEAR_YN
                                                , MERGE_YN).Tables[0];

        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = dt;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = dt.Rows.Count.ToString();
    }

    /// <summary>
    /// EST_JOB_ID의 확정 상태
    /// </summary>
    /// <param name="est_job_ids"></param>
    private void SetConfirmStatusHtml(string est_job_ids) 
    {
        ltrConfirmStatus.Text = EstJobUtility.GetStatusHtml(  COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , est_job_ids.Split(','));
    }

    private bool HasGroupByColumns()
    {
        bool isColumns = false;
        string temp = "";

        for (int i = 0; i < UltraWebGrid1.Columns.Count; i++)
        {
            if (UltraWebGrid1.Columns[i].IsGroupByColumn)
            {
                temp += string.Format("[{0}] ", UltraWebGrid1.Columns[i].Header.Caption);

                if (!isColumns)
                    isColumns = true;
            }
        }

        if (isColumns)
            ltrScript.Text = JSHelper.GetAlertScript(string.Format("현재의 작업을 진행하시기 전에 GroupByBox에서 존재하는 {0}컬럼을 모두 제거하세요.", temp));

        return isColumns;
    }

    #endregion

  
}
