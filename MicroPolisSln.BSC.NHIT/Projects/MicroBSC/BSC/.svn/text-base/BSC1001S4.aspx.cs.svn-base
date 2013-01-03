using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class BSC_BSC1001S4 : AppPageBase
{
    protected string IAPP_STATUS
    {
        get
        {
            if (ViewState["APP_STATUS"] == null)
                ViewState["APP_STATUS"] = "";
            return (string)ViewState["APP_STATUS"];
        }
        set
        {
            ViewState["APP_STATUS"] = value;
        }
    }

    protected string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lbtReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.lbtReloadRight.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    protected int IDEPT_ID
    {
        get
        {
            if (ViewState["DEPT_ID"] == null)
                ViewState["DEPT_ID"] = 0;
            return (int)ViewState["DEPT_ID"];
        }
        set
        {
            ViewState["DEPT_ID"] = value;
        }
    }

    protected string IAPP_REF_ID
    {
        get
        {
            if (ViewState["APP_REF_ID"] == null)
                ViewState["APP_REF_ID"] = "0";
            return (string)ViewState["APP_REF_ID"];
        }
        set
        {
            ViewState["APP_REF_ID"] = value;
        }
    }

    protected DataTable DT_KPI_WEIGHT
    {
        get
        {
            if (ViewState["DT_KPI_WEIGHT"] == null)
                ViewState["DT_KPI_WEIGHT"] = null;
            return (DataTable)ViewState["DT_KPI_WEIGHT"];
        }
        set
        {
            ViewState["DT_KPI_WEIGHT"] = value;
        }
    }

    protected string IEXTERNAL_APPROVAL
    {
        get
        {
            if (ViewState["EXTERNAL_APPROVAL"] == null)
            {
                string strExt = System.Configuration.ConfigurationManager.AppSettings.Get("APPROVALGATEWAY");
                if (strExt == null || strExt.Equals(""))
                    ViewState["EXTERNAL_APPROVAL"] = "N";
                else
                    ViewState["EXTERNAL_APPROVAL"] = strExt;
            }
            return (string)ViewState["EXTERNAL_APPROVAL"];
        }
    }

    protected bool DRAFT_BTN_VISIBLE
    {
        get
        {
            if (ViewState["CONFIRM_STATE"] == null)
                return false;
            return (bool)ViewState["CONFIRM_STATE"];
        }
        set {
            ViewState["CONFIRM_STATE"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
            //2012.02.21 박효동 : 허성대대왕 요청으로 자화장영수주임 요청으로 관리자권한갖은 사원이 있어서 주석처리
            //if (User.IsInRole(ROLE_ADMIN))
            //    ibtnInsert.Enabled = ibtnDelete.Enabled = false;
        }

        this.iBtnDelete.Visible = false;

        ltrScript.Text = "";

        this.iBtnDraft.AlternateText = this.GetText("LBL_00006", "결재상신");
        this.iBtnDraft.ImageUrl = this.GetImage("IMG_00001", "../images/btn/b021.gif");

        rowKpiType.Visible = false;
    }

    protected void lbtReload_Click(object sender, EventArgs e)
    {
        DoBinding();
    }
    protected void lbtReloadRight_Click(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdMBO.Clear();
    }

    protected void ddlKpiCategoryTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }
    protected void ddlKpiCategoryMid_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }

    private void DoInitControl()
    {
        this.IDEPT_ID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
        WebCommon.SetComDeptDropDownList(ddlComDeptRight, true, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlComDeptRight, this.IDEPT_ID);

        WebCommon.SetEstTermDropDownList(ddlEstTerm);

        Biz_Com_Code_Info objCom = new Biz_Com_Code_Info();
        objCom.GetKpiType(ddlKpiGroup, "", true, 0);

        WebCommon.SetKpiCategoryTopActiveDropDownList(ddlKpiCategoryTop, true, "Y");
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");

        if (!User.IsInRole(ROLE_ADMIN))
            txtChampionNameRight.Text = gUserInfo.Emp_Name;

        this.ImageButton1.Visible = false;
        this.ImageButton2.Visible = false;
    }


    private object[] GetSelectMboList()
    {
        object[] objTemp = new object[ugrdMBO.Rows.Count];
        int objCnt = 0;
        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            UltraGridRow gr = ugrdMBO.Rows[i];
            CheckBox chkCheck;
            TemplatedColumn Col_Check = (TemplatedColumn)gr.Band.Columns.FromKey("selchk");

            chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[gr.BandIndex]).FindControl("cBox");
            if (chkCheck.Checked)
            {
                objTemp[objCnt] = DataTypeUtility.GetToInt32(gr.Cells.FromKey("KPI_REF_ID").Value);
                objCnt++;
            }
        }

        objCnt = 0;
        for (int i = 0; i < objTemp.Length; i++)
        {
            if (objTemp[i] == null)
                break;
            objCnt++;
        }
        if (objCnt == 0)
            return null;
        object[] rtnObj = new object[objCnt];

        for (int i = 0; i < rtnObj.Length; i++)
            rtnObj[i] = objTemp[i];
        return rtnObj;
    }

    protected void ibtnSearchRight_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    private void DoBinding()
    {
        if (ddlEstTerm.Items.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("등록된 평가기간이 없습니다.");
            return;
        }

        //가중치
        Biz_Bsc_Mbo_Kpi_Weight objBSC_weight = new Biz_Bsc_Mbo_Kpi_Weight();
        DT_KPI_WEIGHT = objBSC_weight.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTerm), gUserInfo.Emp_Ref_ID).Tables[0];


        //월별 실적
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet dsMonthlyTarget = objBSC.GetMBOForWeight(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                                        , txtKpiCodeRight.Text.Trim()
                                                        , txtKpiNameRight.Text.Trim()
                                                        , txtChampionNameRight.Text.Trim()
                                                        , (ddlComDeptRight.SelectedItem.Value == "" ? 0 : PageUtility.GetIntByValueDropDownList(ddlComDeptRight))
                                                        , PageUtility.GetByValueDropDownList(ddlKpiGroup)
                                                        , ""//MBO_TYPE
                                                        , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop)
                                                        , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid)
                                                        , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow)
                                                        , gUserInfo.Emp_Ref_ID
                                                        , User.IsInRole(ROLE_ADMIN));


        //KPI목록
        DataSet ds = objBSC.GetMBOForDeptKpi(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                            , txtKpiCodeRight.Text.Trim()
                                            , txtKpiNameRight.Text.Trim()
                                            , txtChampionNameRight.Text.Trim()
                                            , PageUtility.GetByValueDropDownList(ddlKpiGroup)
                                            , (ddlComDeptRight.SelectedItem.Value == "" ? 0 : PageUtility.GetIntByValueDropDownList(ddlComDeptRight))
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop)
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid)
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow)
                                            , gUserInfo.Emp_Ref_ID
                                            , (User.IsInRole(ROLE_ADMIN) == true ? 1 : 0)
                                            , this.IDEPT_ID);

        DataTable dt = addMonthlyTarget(dsMonthlyTarget.Tables[0], ds.Tables[0]);

        ugrdMBO.Clear();
        ugrdMBO.DataSource = dt;
        ugrdMBO.DataBind();




        int cntApprovalStatus = 0;
        for (int i = 0; i<ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["USE_YN"].ToString().Equals("Y"))
            {
                if (ds.Tables[0].Rows[i]["APPROVAL_STATUS"].ToString().Equals("N"))
                    cntApprovalStatus++;
            }
        }
        if (cntApprovalStatus == 0)
            DRAFT_BTN_VISIBLE = true;
        else
            DRAFT_BTN_VISIBLE = false;


        double weight = 0;
        double tmp;
        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            tmp = DataTypeUtility.GetToDouble(ugrdMBO.Rows[i].Cells.FromKey("WEIGHT").Value);

            if(DataTypeUtility.GetString(ugrdMBO.Rows[i].Cells.FromKey("USE_YN").Value).Equals("N"))
                continue;

            if (tmp == (double)0)
            {
                weight = 0;
                break;
            }

            weight += DataTypeUtility.GetToDouble(ugrdMBO.Rows[i].Cells.FromKey("WEIGHT").Value);
        }
        if (weight != (double)100)
            DRAFT_BTN_VISIBLE = false;




        if (ds.Tables[0].Rows.Count == 0)
            iBtnDraft.Visible = iBtnMoDraft.Visible = iBtnReDraft.Visible = iBtnReWrite.Visible = iBtnReqModify.Visible = false;



        this.lblRowCnt.Text = ugrdMBO.Rows.Count.ToString();

        


        DataTable dtWeightApproval = objBSC.GetMBOForWeight_Approval(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                                                    , gUserInfo.Emp_Ref_ID).Tables[0];
        if (dtWeightApproval.Rows.Count == 0)
        {
            this.IAPP_STATUS = "";
            this.IAPP_REF_ID = "0";
        }
        else
        {
            this.IAPP_STATUS = dtWeightApproval.Rows[0]["APP_STATUS"].ToString();
            this.IAPP_REF_ID = dtWeightApproval.Rows[0]["APP_REF_ID"].ToString();
        }
        string strImg = (this.IAPP_STATUS == "") ? "" : this.IAPP_STATUS;
        imgApprovalStatus.Src = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        imgApprovalStatus.Alt = Biz_Com_Approval_Info.GetAppImageText(strImg);
        if (IAPP_STATUS.Length > 0)
            this.strApprovalStatus.Text = DataTypeUtility.GetString(dtWeightApproval.Rows[0]["APP_STATUS_NAME"]);

        
        switch (this.IAPP_STATUS)
        {
            case "": // 결재상태 없음
                iBtnDraft.Visible = DRAFT_BTN_VISIBLE;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                break;


            case Biz_Type.app_status_nodraft: // 결재상태 없음
                iBtnDraft.Visible = DRAFT_BTN_VISIBLE;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                break;


            case Biz_Type.app_status_draft: // 상신
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_dft.gif";

                setVisibleForDraft(false);
                break;


            case Biz_Type.app_status_ondraft: // 결재중
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_oft.gif";

                setVisibleForDraft(false);
                break;


            case Biz_Type.app_status_return: // 반려
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = DRAFT_BTN_VISIBLE;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_rft.gif";

                setVisibleForDraft(true);
                break;


            case Biz_Type.app_status_recall: // 결재회수
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = DRAFT_BTN_VISIBLE;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_aft.gif";

                setVisibleForDraft(true);
                break;


            case Biz_Type.app_status_onmodify: // 수정결재
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = DRAFT_BTN_VISIBLE;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = false;
                imgApprovalStatus.Src = "../images/draft/sta_mft.gif";

                setVisibleForDraft(true);
                break;


            case Biz_Type.app_status_complete: // 결재완료
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReWrite.Visible = false;
                iBtnReqModify.Visible = DRAFT_BTN_VISIBLE;
                iBtnReqModify.Visible = true;
                imgApprovalStatus.Src = "../images/draft/sta_cft.gif";

                setVisibleForDraft(false);
                break;


            default:
                iBtnDraft.Visible = false;
                iBtnMoDraft.Visible = false;
                iBtnReDraft.Visible = false;
                iBtnReqModify.Visible = false;
                iBtnReWrite.Visible = false;
                break;
        }
    }

    /* 실적 입력 결재 여부 확인
    protected bool KpiResult_DraftState(string kpi_ref_id)
    {
        bool isAdmin = false;
        bool isTeamManager = false;
        if (User.IsInRole(ROLE_ADMIN))
            isAdmin = true;
        if (User.IsInRole(ROLE_TEAM_MANAGER))
            isTeamManager = true;
        
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet dsResult = objBSC.GetMboListForResultInput(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                                            , PageUtility.GetByValueDropDownList(ddlEstTermMonth)
                                                            , ""
                                                            , ""
                                                            , ""
                                                            , PageUtility.GetIntByValueDropDownList(ddlEstDeptRight)
                                                            , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop)
                                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid)
                                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow)
                                                            , gUserInfo.Emp_Ref_ID
                                                            , isAdmin
                                                            , isTeamManager
                                                            , BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));

        return false;
    }
    */

    protected DataTable addMonthlyTarget(DataTable srcTbl, DataTable tgtTbl)
    {
        for (int j = 1; j < 13; j++)
        {
            tgtTbl.Columns.Add("MONTH" + j.ToString().PadLeft(2, '0'));
        }
        for (int i = 0; i < tgtTbl.Rows.Count; i++)
        {
            DataTable dtTmp = DataTypeUtility.FilterSortDataTable(srcTbl, string.Format("KPI_REF_ID='{0}'", DataTypeUtility.GetString(tgtTbl.Rows[i]["KPI_REF_ID"])));

            if (dtTmp.Rows.Count > 0)
            {
                for (int j = 1; j < 13; j++)
                {
                    string thisMonth = "MONTH" + j.ToString().PadLeft(2, '0');
                    tgtTbl.Rows[i][thisMonth] = dtTmp.Rows[0][thisMonth];
                }
            }
        }

        return tgtTbl;
    }

    //결재상태에 따른 컨트롤 숨김
    protected void setVisibleForDraft(bool state)
    {
        this.btnArea.Visible = state;


        //this.rdoTeamKpi.Visible = state;
        //this.rdoTemplateKpi.Visible = state;
        //this.rdoKpiPool.Visible = state;
        //this.ibtnAdd.Visible = state;
        //this.iBtnDelete.Visible = state;
        //this.iBtnSetWeight.Visible = state;
    }


    protected void ugrdMBO_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //CheckBox chkCheck;
        TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");

        CheckBox chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("cBox");
        //chkCheck.Enabled = (e.Row.Cells.FromKey("KPI_CLASS_REF_ID").Value.ToString() != "STG") ? false : true;

        //if (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y")
        //    chkCheck.Enabled = false;

        //if (e.Row.Cells.FromKey("CHAMPION_EMP_ID").Value.ToString() != gUserInfo.Emp_Ref_ID.ToString())
        //    chkCheck.Enabled = false;


        //if (((DataRowView)e.Data)["CHECK_YN"].ToString() == "N")
        //    chkCheck.Enabled = false;


        //if (drv["COM_DEPT_REF_ID"].ToString() != this.IDEPT_ID.ToString())
        //    chkCheck.Enabled = false;

        //if (((DataRowView)e.Data)["APPROVAL_STATUS"].ToString() == "N")
        //    chkCheck.Enabled = true;

        string estterm_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        string kpi_code = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_CODE").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string onclick = "<a href='#null' onclick=\"doLinking_MBO('{0}','{1}','{2}')\">{3}</a>";
        string link = string.Format(onclick, estterm_ref_id, kpi_code, ICCB2, kpi_name);
        e.Row.Cells.FromKey("KPI_NAME").Value = link;



        CellsCollection cells = e.Row.Cells;
        cells.FromKey("WEIGHT").Style.BackColor = System.Drawing.Color.MintCream;


        

        DataTable dt = DataTypeUtility.FilterSortDataTable(DT_KPI_WEIGHT, string.Format("KPI_REF_ID='{0}'", cells.FromKey("KPI_REF_ID")));
        double weight;
        if (dt.Rows.Count > 0)
            weight = DataTypeUtility.GetToDouble(dt.Rows[0]["WEIGHT"]);
        else
            weight = 0;
        cells.FromKey("WEIGHT").Value = weight;




        string imgHTML = "<img src=\"{0}\" alt=\"\" />";
        cells.FromKey("IMG_USE_YN").Value = (cells.FromKey("USE_YN").Value.ToString() == "Y") ? string.Format(imgHTML, "../images/icon_o.gif") : string.Format(imgHTML, "../images/icon_x.gif");
        cells.FromKey("IMG_APPROVAL_STATUS").Value = (cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y") ? string.Format(imgHTML, "../images/icon_o.gif") : string.Format(imgHTML, "../images/icon_x.gif");




        if (cells.FromKey("USE_YN").Value.ToString().Equals("N"))
        {
            cells.FromKey("WEIGHT").Value = "0";
            cells.FromKey("WEIGHT").AllowEditing = AllowEditing.No;
        }
    }


    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        object[] objList = GetSelectMboList();

        Biz_Bsc_Kpi_Info objMBO = new Biz_Bsc_Kpi_Info();



        //bool boolOK = objMBO.DeleteMboToKpi(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
        //                        , objList
        //                        , gUserInfo.Emp_Ref_ID);

        //string returnMsg = objMBO.RemoveMboToKpi_NW(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
        //                                    , objList
        //                                    , gUserInfo.Emp_Ref_ID);



        string returnMsg = "";
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBscKpiInfo = new Biz_Bsc_Kpi_Info();
        for (int i = 0; i < objList.Length; i++)
        {
            returnMsg = "";
            objBscKpiInfo.TxrKPIMaster("D", PageUtility.GetIntByValueDropDownList(ddlEstTerm), (int)objList[i]
                , "", 0, "", "", "", "", "", "", 0, 0, 0, "", "", "", "", "", "", "", 0, "", "", "", "", "", 0, "", "", "", gUserInfo.Emp_Ref_ID, null, out returnMsg);
        }

        
        
        
        
        if (returnMsg.Equals(string.Empty))
        {
            DoBinding();
            ltrScript.Text = JSHelper.GetAlertScript("삭제를 완료하였습니다.");
        }
        else
        {
            //ltrScript.Text = JSHelper.GetAlertScript("삭제가 실패하였습니다.");
            ltrScript.Text = JSHelper.GetAlertScript(returnMsg);
            DoBinding();
        }
    }



    protected void iBtnSetWeight_Click(object sender, EventArgs e)
    {
        SetWeight();
    }
    public void SetWeight()
    {
        int itxr_user = gUserInfo.Emp_Ref_ID;

        UltraGridRow row;

        Biz_Bsc_Mbo_Kpi_Weight objBSC = new Biz_Bsc_Mbo_Kpi_Weight();

        DataTable dt = new DataTable();
        dt.Columns.Add("ESTTERM_REF_ID", typeof(int));
        dt.Columns.Add("KPI_REF_ID", typeof(int));
        dt.Columns.Add("WEIGHT", typeof(decimal));
        dt.Columns.Add("KPI_CLASS_REF_ID", typeof(string));

        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            row = ugrdMBO.Rows[i];

            DataRow dr = dt.NewRow();
            dr["ESTTERM_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("ESTTERM_REF_ID").Value);
            dr["KPI_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("KPI_REF_ID").Value);
            dr["WEIGHT"] = DataTypeUtility.GetToDouble(row.Cells.FromKey("WEIGHT").Value);

            try
            {
                dr["KPI_CLASS_REF_ID"] = (row.Cells.FromKey("IS_TEAM_KPI").Value.ToString() == "Y" ? "SCO" : "PCO");
            }
            catch { }
            dt.Rows.Add(dr);
        }

        if (objBSC.UpdateMBOWeight(gUserInfo.Emp_Ref_ID, dt))
        {
            PageUtility.AlertMessage("처리하였습니다.");
        }
        else
            PageUtility.AlertMessage("실패하였습니다.");

        DoBinding();
    }



    /// <summary>
    /// 수정결재요청
    /// </summary>
    protected void iBtnReqModify_Click(object sender, ImageClickEventArgs e)
    {
        this.RequestModifyDraft();
    }
    private void RequestModifyDraft()
    {
        Biz_Com_Approval_Prc objApp = new Biz_Com_Approval_Prc();
        bool blnRtn = objApp.RequestModifyDraft(DataTypeUtility.GetToInt32(this.IAPP_REF_ID), EMP_REF_ID);
        if (blnRtn)
        {
            DoBinding();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objApp.Transaction_Message, false);
        }
    }
}
