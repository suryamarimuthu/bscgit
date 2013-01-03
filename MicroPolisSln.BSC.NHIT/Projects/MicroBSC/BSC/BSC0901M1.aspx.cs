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
using System.Drawing;
using System.Collections.Specialized;

using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0901M1 : AppPageBase
{
    #region ==========================[변수선언]================

    public string IAPP_CCB
    {
        get
        {
            if (ViewState["APP_CCB"] == null)
            {
                ViewState["APP_CCB"] = GetRequest("APP_CCB", "");
            }

            return (string)ViewState["APP_CCB"];
        }
        set
        {
            ViewState["APP_CCB"] = value;
        }
    }

    /// <summary>
    /// 업무유형
    /// </summary>
    public string IBiz_Type
    {
        get
        {
            if (ViewState["BIZ_TYPE"] == null)
            {
                ViewState["BIZ_TYPE"] = GetRequest("BIZ_TYPE", "");
            }

            return (string)ViewState["BIZ_TYPE"];
        }
        set
        {
            ViewState["BIZ_TYPE"] = value;
        }
    }

    /// <summary>
    /// 결재상태
    /// </summary>
    public string IApp_Status
    {
        get
        {
            if (ViewState["APP_STATUS"] == null)
            {
                ViewState["APP_STATUS"] = GetRequest("APP_STATUS", "");
            }
            return (string)ViewState["APP_STATUS"];
        }
        set
        {
            ViewState["APP_STATUS"] = value;
        }
    }

    /// <summary>
    /// 기안상태
    /// </summary>
    public string IDraft_Status
    {
        get
        {
            if (ViewState["DRAFT_STATUS"] == null)
            {
                ViewState["DRAFT_STATUS"] = GetRequest("DRAFT_STATUS", "");
            }
            return (string)ViewState["DRAFT_STATUS"];
        }
        set
        {
            ViewState["DRAFT_STATUS"] = value;
        }
    }

    public decimal IApp_Ref_Id
    {
        get
        {
            if (ViewState["APP_REF_ID"] == null)
            {
                ViewState["APP_REF_ID"] = (decimal)GetRequestByInt("APP_REF_ID", 0);
            }

            return (decimal)ViewState["APP_REF_ID"];
        }
        set
        {
            ViewState["APP_REF_ID"] = value;
        }
    }

    public int IVersion_No
    {
        get
        {
            if (ViewState["VERSION_NO"] == null)
            {
                ViewState["VERSION_NO"] = GetRequestByInt("VERSION_NO", 0);
            }

            return (int)ViewState["VERSION_NO"];
        }
        set
        {
            ViewState["VERSION_NO"] = value;
        }
    }

    public int ILine_Step
    {
        get
        {
            if (ViewState["LINE_STEP"] == null)
            {
                ViewState["LINE_STEP"] = GetRequestByInt("LINE_STEP", 0);
            }

            return (int)ViewState["LINE_STEP"];
        }
        set
        {
            ViewState["LINE_STEP"] = value;
        }
    }

    public int IDraftEmpID
    {
        get
        {
            if (ViewState["DRAFT_EMP_ID"] == null)
            {
                ViewState["DRAFT_EMP_ID"] = GetRequestByInt("DRAFT_EMP_ID", 0);
            }

            return (int)ViewState["DRAFT_EMP_ID"];
        }
        set
        {
            ViewState["DRAFT_EMP_ID"] = value;
        }
    }

    protected string IHISTORY_YN
    {
        get
        {
            if (ViewState["HISTORY_YN"] == null)
                ViewState["HISTORY_YN"] = "N";
            return (string)ViewState["HISTORY_YN"];
        }
        set
        {
            ViewState["HISTORY_YN"] = value;
        }
    }

    protected string IAPP_SELF_NOTUSE_YN
    {
        get
        {
            if (ViewState["HISTORY_YN"] == null)
                ViewState["HISTORY_YN"] = "N";
            return (string)ViewState["HISTORY_YN"];
        }
        set
        {
            ViewState["HISTORY_YN"] = value;
        }
    }

    protected string IORIGINAL_LINE
    {
        get
        {
            if (ViewState["ORIGINAL_LINE"] == null)
                ViewState["ORIGINAL_LINE"] = "";
            return (string)ViewState["ORIGINAL_LINE"];
        }
        set
        {
            ViewState["ORIGINAL_LINE"] = value;
        }
    }

    public static bool blnFirst    = true;
    public static string strEmpArr = null;

    public int idxCol    = 1;
    public int iWinWidth = 650;
    public int idxLine   = 0;
    #endregion

    #region ==========================[페이지 초기화]================

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.IHISTORY_YN = WebUtility.GetConfig("DRAFT_HISTORY_YN", "N");
            this.IAPP_SELF_NOTUSE_YN = WebUtility.GetConfig("APPROVAL_SELF_NOTUSE_YN", "N");
            divReason.Style.Add("display", "none");
            this.SetInitForm();
            this.SetAppStatus();
        }
        else
        {
            
        }

        this.ShowAnyTime();
    }

    private void DoConfirmReason()
    {
        if (this.IHISTORY_YN == "Y")
        {
            string currentLine = "";
            foreach(UltraGridRow gr in ugrdAppLine.Rows)
                currentLine += gr.Cells.FromKey("EMP_REF_ID").Value.ToString() + ";";

            if (this.IORIGINAL_LINE != currentLine)
                divReason.Style.Add("display", "block");
            else
                divReason.Style.Add("display", "none");
        }
    }

    private void DoConfirmReasonBottom()
    {
        if (this.IDraft_Status == Biz_Type.app_draft_approval || this.IDraft_Status == Biz_Type.app_draft_select)
        {
            if (this.IHISTORY_YN == "Y")
            {
                string strReason = string.Empty;

                Biz_Com_Approval_Info bizAppInfo = new Biz_Com_Approval_Info();
                strReason = bizAppInfo.GetLineUpdateReason(this.IApp_Ref_Id, this.IVersion_No).Rows[0]["UPDATE_REASON"].ToString();

                if (strReason != "")
                {
                    txtUPDATE_REASON2.Text = strReason;
                }
                else
                {
                    th1.Style["width"] = th2.Style["width"] = "90px";
                    td01.Style["width"] = td02.Style["width"] = "50%";
                    th3.Visible = td03.Visible = false;
                }
            }
            else
            {
                th1.Style["width"] = th2.Style["width"] = "90px";
                td01.Style["width"] = td02.Style["width"] = "50%";
                th3.Visible = td03.Visible = false;
            }
        }
        else
        {
            th1.Style["width"] = th2.Style["width"] = "90px";
            td01.Style["width"] = td02.Style["width"] = "50%";
            th3.Visible = td03.Visible = false;
        }
    }

    public void ShowAnyTime()
    {
        if (divAreaAppLine_1.Style["display"] == "block")
        {
            divAreaAppLine_1.Style.Add("display", "block");
        }
        else
        {
            divAreaAppLine_1.Style.Add("display", "none");
        }

        ltrScript.Text = "";
    }
    #endregion

    #region ==========================[내부함수]================
    /// <summary>
    /// 페이지 초기화
    /// </summary>
    public void SetInitForm()
    {
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetApprovalLineType(ddlLineType, 0, false, 100);

        txtDocNo.Style.Add(HtmlTextWriterStyle.TextDecoration, "none");

        btnDraft.OnClientClick    = "return isConfirmDraft('D');"; // 최초기안, 재기안, 수정기안
        btnSanction.OnClientClick = "return isConfirmDraft('S');"; // 결재
        btnReturn.OnClientClick   = "return isConfirmDraft('R');"; // 반려

        // 원래기안 문서의 정보를 읽어옴
        lblAppTitle.Text = Biz_Com_Approval_Info.GetDraftTitle(this.IBiz_Type);
    }

    /// <summary>
    /// 결재작업별 상태설정
    /// </summary>
    public void SetAppStatus()
    {
        this.SetFormData();
        if (this.IDraft_Status == Biz_Type.app_draft_first)  //최초기안
        {
            this.SetDraftLine();
            this.SetFirstDraftStatus();
            this.SetDraftLineGRV();
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_redraft) // 재기안
        {
            this.SetApprovalLine();
            this.SetFirstDraftStatus();
            this.SetDraftLineGRV();
            DoBindingUpdateReason();
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_rewrite) // 재작성
        {
            this.SetApprovalLine();
            this.SetFirstDraftStatus();
            this.SetDraftLineGRV();
            DoBindingUpdateReason();
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_modify) // 수정기안
        {
            this.SetDraftLine();
            this.SetFirstDraftStatus();
            DoBindingUpdateReason();
            DoConfirmReasonBottom();
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_approval) // 승인
        {
            this.SetApprovalLine();
            this.SetDraftLineGRV();


            this.txtRtnReason.ReadOnly = false;
            this.txtRtnReason.Style.Add("background", "#ffffff");


            DoBindingUpdateReason();
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_select)   // 조회
        {
            this.SetApprovalLine();
            this.SetDraftLineGRV();
        }
        if (this.IHISTORY_YN != "Y")
            divReason.Style.Add("display", "none");
    }

    /// <summary>
    /// 버튼설정
    /// </summary>
    public void SetButton()
    {
        if ((this.IDraft_Status == Biz_Type.app_draft_first) ||
            (this.IDraft_Status == Biz_Type.app_draft_redraft) ||
            (this.IDraft_Status == Biz_Type.app_draft_rewrite) ||
            (this.IDraft_Status == Biz_Type.app_draft_modify))
        {
            btnLineSelect.Visible = true;
            btnDraft.Visible      = true;
            btnShowLine.Visible   = true;
            btnSanction.Visible   = false;
            btnReturn.Visible     = false;
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_approval)
        { 
            btnLineSelect.Visible = false;
            btnDraft.Visible      = false;
            btnShowLine.Visible   = false;
            btnSanction.Visible   = true;
            btnReturn.Visible     = true;
        }
        else 
        {
            btnLineSelect.Visible = false;
            btnDraft.Visible      = false;
            btnShowLine.Visible   = false;
            btnSanction.Visible   = false;
            btnReturn.Visible     = false;
        }
    }

    /// <summary>
    /// 최초기안상태일경우 원문문서 읽어오고 조직정보,결재선 세팅
    /// </summary>
    public void SetFirstDraftStatus()
    {
        WebCommon.FillComDeptTree(trvDept);

        string strTitle = "";
        Biz_Com_Approval_Info objApp = new Biz_Com_Approval_Info();
        bool blnRtn = objApp.GetOriDocTitle(this.IBiz_Type, Request.Params, out strTitle);
        if (blnRtn)
        {
            txtTitle.Text = strTitle;
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("결재원문을 알수 없습니다.", true);
            return;
        }

        string strHtml = Server.HtmlDecode(Biz_Com_Approval_Info.GetHtmlSource(this.GetQueryString()));
        string strPos = "{^0^}";
        int iSPos = strHtml.IndexOf(strPos) + strPos.Length;
        int iEPos = strHtml.LastIndexOf(strPos);

        divArea_M.InnerHtml = strHtml.Substring(iSPos, iEPos - iSPos);
    }

    /// <summary>
    /// Query String을 파싱하여 결재원문 호출할 URL 생성
    /// </summary>
    /// <returns></returns>
    public string GetQueryString()
    {
        int i, j;
        NameValueCollection colReq;

        colReq = Request.QueryString;

        string strFullPath = "";
        string strPath  = "";
        string strParam = "";
        String[] arrKey = colReq.AllKeys;
        for (i = 0; i < arrKey.Length; i++)
        {
            String[] arrVal = colReq.GetValues(arrKey[i]);
            strParam += "&" + arrKey[i] + "=";
            for (j = 0; j < arrVal.Length; j++)
            {
                strParam += arrVal[j];
            }

            //String[] arrVal = colReq.GetValues(arrKey[i]);
            //if (arrKey[i] == "PAGE_PATH")
            //{
            //    for (j = 0; j < arrVal.Length; j++)
            //    {
            //        strPath += arrVal[j];
            //    }
            //}
            //else
            //{
            //    strParam += "&" + arrKey[i] + "=";
            //    for (j = 0; j < arrVal.Length; j++)
            //    {
            //        strParam += arrVal[j];
            //    }
            //}
        }
               strPath  = Biz_Com_Approval_Info.GetDraftPagePath(this.IBiz_Type);
        string strVPath = Request.ApplicationPath;
        string strSHost = Request.Url.Host;
        string strSPort = Request.Url.Port.ToString();
        string strProto = Request.Url.Scheme;

        strVPath = (strVPath == "/") ? "" : strVPath;

        strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath + strPath + "?" + strParam.Substring(1, strParam.Length - 1);

        return strFullPath;
    }

    /// <summary>
    /// 최초결재선지정
    /// </summary>
    public void SetDraftLine()
    {
        //Biz_Com_Approval_Line_Base objBase = new Biz_Com_Approval_Line_Base();
        //DataSet dtBase = objBase.GetBaseAppLine(this.IBiz_Type, this.IDraftEmpID);
        Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
        DataTable dtAppLine = bizComApp.GetFullAppLine(this.IBiz_Type, this.IDraftEmpID);

        this.IORIGINAL_LINE = "";
        ugrdAppLine.Clear();

        ugrdAppLine.DataSource = dtAppLine;
        ugrdAppLine.DataBind();

        int iRow   = ugrdAppLine.Rows.Count;
        for (int i = 0; i < iRow; i++)
        {
            //ugrdAppLine.Rows[i].Cells.FromKey("DEFAULT_YN").Value = "N";
            ugrdAppLine.Rows[i].Cells.FromKey("LINE_TYPE").AllowEditing    = AllowEditing.No;
            if (ugrdAppLine.Rows[i].Cells.FromKey("DEFAULT_YN").Value.ToString() == "Y")
                ugrdAppLine.Rows[i].Cells.FromKey("LINE_TYPE").Style.BackColor = Color.WhiteSmoke;
            //{
                
                //ugrdAppLine.Rows[i].Cells.FromKey("DEFAULT_YN").Value = "Y";
            //}

            ugrdAppLine.Rows[i].Cells.FromKey("COMPLETE_YN").Value = "N";
            ugrdAppLine.Rows[i].Cells.FromKey("TXR_DATE").Value    = "/";

            this.IORIGINAL_LINE += ugrdAppLine.Rows[i].Cells.FromKey("EMP_REF_ID").Value.ToString() + ";";
        }
    }

    private void DoSetOriginalLine()
    {
        Biz_Com_Approval_Info bizComApp = new Biz_Com_Approval_Info();
        DataTable dtAppLine = bizComApp.GetFullAppLine(this.IBiz_Type, this.IDraftEmpID);

        this.IORIGINAL_LINE = "";
        foreach (DataRow dr in dtAppLine.Rows)
        {
            this.IORIGINAL_LINE += dr["EMP_REF_ID"].ToString() + ";";
        }
    }

    /// <summary>
    /// 진행중인결재선 조회
    /// </summary>
    public void SetApprovalLine()
    {
        Biz_Com_Approval_Prc objApp = new Biz_Com_Approval_Prc();
        DataSet rDs = objApp.GetAllList(this.IApp_Ref_Id, this.IVersion_No);

        ugrdAppLine.Clear();

        if (rDs.Tables.Count > 0)
        {
            rDs.Tables[0].DefaultView.Sort = "LINE_STEP ASC";
            ugrdAppLine.DataSource = rDs.Tables[0].DefaultView;
            ugrdAppLine.DataBind();

            DoSetOriginalLine();
        }
        else
        {
            this.SetDraftLine();
        }        
    }

    /// <summary>
    /// 결재선 그리기(그리드뷰)
    /// </summary>
    public void SetDraftLineGRV()
    {
        DataTable dtLine = new DataTable("LINE");

        int iRow     = ugrdAppLine.Rows.Count;
        int iCol     = ugrdAppLine.Columns.Count;
        string sHKey = "";
        string sComp = "";

        for (int i = 0; i < iRow; i++)
        {
            sHKey = "E" + ugrdAppLine.Rows[i].Cells.FromKey("EMP_REF_ID").Value.ToString();
            dtLine.Columns.Add(sHKey, typeof(string));
        }

        int     idx    = 0;
        DataRow drType = null;
        DataRow drName = null;
        DataRow drDate = null;
        for (int i = 0; i < iCol; i++)
        {
            if (ugrdAppLine.Columns[i].Key == "LINE_TYPE") // 결재유형
            {
                idx = iRow - 1;
                drType = dtLine.NewRow();
                for (int j = 0; j < iRow; j++)
                {
                    drType[j] = ugrdAppLine.Rows[idx].Cells.FromKey(ugrdAppLine.Columns[i].Key).Text.ToString();
                    idx = idx - 1;
                }
            }
            else if (ugrdAppLine.Columns[i].Key == "EMP_NAME") // 결재자
            {
                idx = iRow - 1;
                drName = dtLine.NewRow();
                for (int j = 0; j < iRow; j++)
                {
                    drName[j] = ugrdAppLine.Rows[idx].Cells.FromKey(ugrdAppLine.Columns[i].Key).Text.ToString();
                    idx = idx - 1;
                }
            }
            else if (ugrdAppLine.Columns[i].Key == "TXR_DATE")  // 처리일자
            {
                idx = iRow - 1;
                drDate = dtLine.NewRow();
                for (int j = 0; j < iRow; j++)
                {
                    sComp = ugrdAppLine.Rows[idx].Cells.FromKey("COMPLETE_YN").Text;
                    if (sComp == "Y" && (this.IDraft_Status == Biz_Type.app_draft_approval || this.IDraft_Status == Biz_Type.app_draft_select))
                    {
                        drDate[j] = (ugrdAppLine.Rows[idx].Cells.FromKey(ugrdAppLine.Columns[i].Key) != null) ?
                                     ugrdAppLine.Rows[idx].Cells.FromKey(ugrdAppLine.Columns[i].Key).Text : "/";
                    }
                    else
                    {
                        drDate[j] = "/";
                    }

                    idx = idx - 1;
                }
            }
        }
        
        dtLine.Rows.Add(drType);
        dtLine.Rows.Add(drName);
        dtLine.Rows.Add(drDate);

        grvLineTable.ShowHeader = false;
        grvLineTable.Columns.Clear();
        grvLineTable.DataSource = dtLine.DefaultView;
        grvLineTable.DataBind();

        DoConfirmReasonBottom();
    }

    /// <summary>
    /// 폼데이터 조회
    /// </summary>
    public void SetFormData()
    {
        Biz_Com_Approval_Info objApp = null;
        if (this.IDraft_Status == Biz_Type.app_draft_select && (this.IApp_Ref_Id > 0 && this.IVersion_No > 0))
        {
            objApp = new Biz_Com_Approval_Info(this.IApp_Ref_Id, this.IVersion_No);
        }
        else
        {
            objApp = new Biz_Com_Approval_Info(this.IApp_Ref_Id);
        }

        this.IApp_Ref_Id    = objApp.IApp_Ref_Id;
        this.IVersion_No    = objApp.IVersion_No;
        this.IApp_Status    = objApp.IApp_Status;
        txtDocNo.Text       = objApp.IApp_Code;
        txtTitle.Text       = objApp.ITitle;
        divArea_M.InnerHtml = Server.HtmlDecode(objApp.IOri_Doc);

        // 결재번호가 생성되지 않은경우 - 최초기안
        // 기존에 진행된결재는 있지만 활성화된 결재가 없는경우
        if ((this.IApp_Ref_Id < 1 || this.IVersion_No < 1))  
        {
            this.IDraft_Status = Biz_Type.app_draft_first;
        }

        this.SetButton();
    }

    /// <summary>
    /// 기안, 재기안, 수정기안
    /// </summary>
    public void SetDraft()
    {
        Biz_Com_Approval_Info objApp = new Biz_Com_Approval_Info();
        
        //결재완결처리 결재선이 하나인경우 완결처리
        string sAppStatus = (ugrdAppLine.Rows.Count == 1) ? Biz_Type.app_status_complete : Biz_Type.app_status_draft;

        //기안
        if (this.IDraft_Status == Biz_Type.app_draft_first)         //최초기안
        {
            bool blnRtn = objApp.TxrDraft(Server.HtmlEncode(divArea_M.InnerHtml), txtTitle.Text, this.IBiz_Type, sAppStatus, Biz_Type.app_draft_first, "", this.IDraftEmpID
                                        , this.GetAPPLine(), Request.Params);
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_redraft)  // 재기안
        {
            bool blnRtn = objApp.TxrReDraft(this.IApp_Ref_Id, Server.HtmlEncode(divArea_M.InnerHtml), txtTitle.Text, this.IBiz_Type, sAppStatus, Biz_Type.app_draft_redraft, "", this.IDraftEmpID
                                        , this.GetAPPLine(), Request.Params);
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_rewrite)  // 재작성
        {
            bool blnRtn = objApp.TxrReWrite(this.IApp_Ref_Id, this.IVersion_No, Server.HtmlEncode(divArea_M.InnerHtml), txtTitle.Text, this.IBiz_Type, sAppStatus, Biz_Type.app_draft_rewrite, "", this.IDraftEmpID
                                        , this.GetAPPLine(), Request.Params);
        }
        else if (this.IDraft_Status == Biz_Type.app_draft_modify)   // 수정기안
        {
            bool blnRtn = objApp.TxrMoDraft(this.IApp_Ref_Id, Server.HtmlEncode(divArea_M.InnerHtml), txtTitle.Text, this.IBiz_Type, sAppStatus, Biz_Type.app_draft_modify, "", this.IDraftEmpID
                                        , this.GetAPPLine(), Request.Params);
        }

        if (objApp.Transaction_Result == "Y")
        {
            this.IApp_Ref_Id = objApp.IApp_Ref_Id;
            this.IVersion_No = objApp.IVersion_No;

            if (this.IHISTORY_YN == "Y")
                DoInsertUpdateReason();
            bool bRtn = this.SendMail(false);
        }
        else
        {
            this.IApp_Ref_Id = 0;
            this.IVersion_No = 0;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objApp.Transaction_Message, this.IAPP_CCB, true);
    }

    private void DoInsertUpdateReason()
    {
        try
        {
            string currentLine = "";
            foreach (UltraGridRow gr in ugrdAppLine.Rows)
                currentLine += gr.Cells.FromKey("EMP_REF_ID").Value.ToString() + ";";
            if (currentLine != this.IORIGINAL_LINE)
            {
                Biz_Com_Approval_Info objApp = new Biz_Com_Approval_Info();
                objApp.SetLineUpdateHistory(this.IApp_Ref_Id, this.IVersion_No, txtUPDATE_REASON.Text);
            }
        }
        catch
        {
        }
    }

    private void DoBindingUpdateReason()
    {
        string currentLine = "";
        foreach (UltraGridRow gr in ugrdAppLine.Rows)
            currentLine += gr.Cells.FromKey("EMP_REF_ID").Value.ToString() + ";";
        if (currentLine != this.IORIGINAL_LINE)
        {
            Biz_Com_Approval_Info objApp = new Biz_Com_Approval_Info();
            txtUPDATE_REASON.Text = objApp.GetLineUpdateReason(this.IApp_Ref_Id, this.IVersion_No).Rows[0]["UPDATE_REASON"].ToString();
            divReason.Style.Add("display", "block");
        }
    }

    /// <summary>
    /// 승인
    /// </summary>
    public void SetApproval()
    {
        if (this.IApp_Ref_Id > 0 && this.IVersion_No > 0 && this.ILine_Step > 0)
        {
            DataTable dtAppLine = new DataTable("APP_LINE");
            dtAppLine.Columns.Add("APP_REF_ID", typeof(decimal));
            dtAppLine.Columns.Add("VERSION_NO", typeof(int));
            dtAppLine.Columns.Add("LINE_STEP", typeof(int));
            dtAppLine.Columns.Add("APP_EMP_ID", typeof(int));
            dtAppLine.Columns.Add("COMMENTS", typeof(string));

            DataRow drAppLine = dtAppLine.NewRow();
            drAppLine["APP_REF_ID"] = this.IApp_Ref_Id;
            drAppLine["VERSION_NO"] = this.IVersion_No;
            drAppLine["LINE_STEP"]  = this.ILine_Step;
            drAppLine["APP_EMP_ID"] = this.IDraftEmpID;
            drAppLine["COMMENTS"]   = txtAppOpinion.Text;

            dtAppLine.Rows.Add(drAppLine);

            Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
            int iRtn = objPrc.Approval(dtAppLine);

            if (objPrc.Transaction_Result == "Y")
            {
                bool bRtn = SendMail(false);
            }

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objPrc.Transaction_Message, this.IAPP_CCB, true);
            return;
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("결재문서정보가 올바르지 않습니다.", false);
        }
    }

    /// <summary>
    /// 반려
    /// </summary>
    public void SetReturn()
    {
        if (this.IApp_Ref_Id > 0 && this.IVersion_No > 0 && this.ILine_Step > 0)
        {
            DataTable dtAppLine = new DataTable("APP_LINE");
            dtAppLine.Columns.Add("APP_REF_ID", typeof(decimal));
            dtAppLine.Columns.Add("VERSION_NO", typeof(int));
            dtAppLine.Columns.Add("LINE_STEP", typeof(int));
            dtAppLine.Columns.Add("RETURN_REASON", typeof(string));
            dtAppLine.Columns.Add("APP_EMP_ID", typeof(int));

            DataRow drAppLine = dtAppLine.NewRow();
            drAppLine["APP_REF_ID"]    = this.IApp_Ref_Id;
            drAppLine["VERSION_NO"]    = this.IVersion_No;
            drAppLine["LINE_STEP"]     = this.ILine_Step;
            drAppLine["RETURN_REASON"] = txtRtnReason.Text;
            drAppLine["APP_EMP_ID"]    = this.IDraftEmpID;

            dtAppLine.Rows.Add(drAppLine);

            Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
            int iRtn = objPrc.Return(dtAppLine);

            if (objPrc.Transaction_Result == "Y")
            {
                bool bRtn = SendMail(true);
            }

            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objPrc.Transaction_Message, this.IAPP_CCB, true);
            return;
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("결재문서정보가 올바르지 않습니다.", false);
        }
    }

    /// <summary>
    /// 최초 기안시 결재선정보 입력
    /// </summary>
    /// <returns></returns>
    public DataTable GetAPPLine()
    {
        DataTable dtApp = new DataTable("LINE_STEP");
        dtApp.Columns.Add("APP_REF_ID",    typeof(System.Decimal));
        dtApp.Columns.Add("VERSION_NO",    typeof(System.Int32));
        dtApp.Columns.Add("LINE_STEP",     typeof(System.Int32));
        dtApp.Columns.Add("APP_EMP_ID",    typeof(System.Int32));
        dtApp.Columns.Add("COMPLETE_YN",   typeof(System.String));
        dtApp.Columns.Add("COMMENTS",      typeof(System.String));
        dtApp.Columns.Add("RETURN_REASON", typeof(System.String));
        dtApp.Columns.Add("LINE_TYPE",     typeof(System.String));
        dtApp.Columns.Add("APP_METHOD",    typeof(System.String));
        dtApp.Columns.Add("TXR_USER",      typeof(System.Int32));

        DataRow drApp = null;
        int iRow = ugrdAppLine.Rows.Count;
        int iCol = ugrdAppLine.Columns.Count;

        int iTxrUser = this.IDraftEmpID;

        for (int i = 0; i < iRow; i++)
        {
            drApp = dtApp.NewRow();
            drApp["APP_REF_ID"]    = this.IApp_Ref_Id;
            drApp["VERSION_NO"]    = this.IVersion_No;
            drApp["LINE_STEP"]     = ugrdAppLine.Rows[i].Cells.FromKey("LINE_STEP").Value.ToString();
            drApp["APP_EMP_ID"]    = ugrdAppLine.Rows[i].Cells.FromKey("EMP_REF_ID").Value.ToString();
            drApp["LINE_TYPE"]     = ugrdAppLine.Rows[i].Cells.FromKey("LINE_TYPE").Value.ToString();
            drApp["TXR_USER"]      = iTxrUser;
            drApp["APP_METHOD"]    = "NAME";
            drApp["RETURN_REASON"] = "";

            if (drApp["LINE_TYPE"].ToString() == "D") // 기안자 입력
            {
                drApp["COMPLETE_YN"]   = "Y";
                drApp["COMMENTS"]      = txtAppOpinion.Text;                
            }
            else
            {
                drApp["COMPLETE_YN"]   = "N";
                drApp["COMMENTS"]      = "";                
            }

            dtApp.Rows.Add(drApp);
        }

        return dtApp;
    }

    public bool SendMail(bool isReturn)
    {
        if (PageUtility.GetAppConfig("Mail.UseDraftMailYN") == "N")
        {
            return true;
        }

        string sC_EMP_MAIL = "";
        string sP_EMP_MAIL = "";
        string sN_EMP_MAIL = "";
        string sFile       = "Mail_Draft.htm";

        EmpInfos objEmp = new EmpInfos(this.IDraftEmpID);
        Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
        bool bRtn = objPrc.GetSendMailUser(this.IApp_Ref_Id, this.IVersion_No, this.IDraftEmpID, out sC_EMP_MAIL, out sP_EMP_MAIL, out sN_EMP_MAIL);
        if (!bRtn)
        {
            return false;
        }

        if (isReturn && (!PageUtility.CheckMailAddress(sC_EMP_MAIL) || !PageUtility.CheckMailAddress(sN_EMP_MAIL)))
        {
            return false;
        }

        if (!isReturn && (!PageUtility.CheckMailAddress(sC_EMP_MAIL) || !PageUtility.CheckMailAddress(sP_EMP_MAIL)))
        {
            return false;
        }

        DataTable dtMailParam = new DataTable("PARAM");
        dtMailParam.Columns.Add("KEY", typeof(string));
        dtMailParam.Columns.Add("VAL", typeof(string));

        Biz_Com_Approval_Info objMst = new Biz_Com_Approval_Info(this.IApp_Ref_Id, this.IVersion_No);

        string strVPath = Request.ApplicationPath;
        string strSHost = Request.Url.Host;
        string strSPort = Request.Url.Port.ToString();
        string strProto = Request.Url.Scheme;
        strVPath = (strVPath == "/") ? "" : strVPath;

        string strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath;

        DataRow dr = null;
        dr = dtMailParam.NewRow();
        dr["KEY"] = "[SITE_URL]";
        dr["VAL"] = strFullPath;
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[BIZ_TYPE]";
        dr["VAL"] = Biz_Com_Approval_Info.GetBizTypeName(this.IBiz_Type);
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[APP_CODE]";
        dr["VAL"] = objMst.IApp_Code;
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[TITLE]";
        dr["VAL"] = objMst.ITitle;
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[EMP_NAME]";
        dr["VAL"] = objEmp.Emp_Name;
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[DEPT_NAME]";
        dr["VAL"] = objEmp.Dept_Name;
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[TRX_DATE]";
        dr["VAL"] = objMst.IUpdate_Date.ToShortDateString();
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[TODAY]";
        dr["VAL"] = DateTime.Now.ToString();
        dtMailParam.Rows.Add(dr);

        dr = dtMailParam.NewRow();
        dr["KEY"] = "[DRAFT_TYPE]";
        dr["VAL"] = (isReturn) ? "반려" : "승인요청";
        dtMailParam.Rows.Add(dr);

        string sMailTitle = "[성과관리 - " + Biz_Com_Approval_Info.GetBizTypeName(this.IBiz_Type) + " 건 알림메일]";

        return PageUtility.SendMail(dtMailParam, sC_EMP_MAIL, (isReturn) ? sN_EMP_MAIL : sP_EMP_MAIL, sMailTitle, sFile);
    }
    #endregion

    #region ==========================[이벤트]================
    /// <summary>
    /// 트리변경시 사용자검색
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void trvDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        divAreaAppLine_1.Style["display"] = "block";

        TreeNode trnDept = trvDept.SelectedNode;

        if (trnDept != null)
        {
            string strDeptNm = trnDept.Text;
            string strDeptID = trnDept.Value;

            EmpInfos objEmp = new EmpInfos();
            DataSet rDs = objEmp.GetEmpInfoByDeptID(strDeptID);

            ugrdEmpList.Clear();
            ugrdEmpList.DataSource = rDs;
            ugrdEmpList.DataBind();
        }
    }

    protected void trvDept_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        strEmpArr = "";
        foreach (TreeNode tn in trvDept.CheckedNodes)
        {
            strEmpArr += tn.Value+";";
        }
    }
    
    protected void btnLineConfirm_Click(object sender, ImageClickEventArgs e)
    {
        this.SetDraftLineGRV();
        divAreaAppLine_1.Style.Add("display", "none");

        DoConfirmReason();
    }
    
    protected void ugrdAppLine_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Data;
        //e.Row.Cells.FromKey("LINE_TYPE_ORG").Value = drv["LINE_TYPE"].ToString();
        e.Row.Cells.FromKey("LINE_STEP").Value = idxCol.ToString();
        idxCol += 1;
    }
    
    protected void btnToUp_Click(object sender, ImageClickEventArgs e)
    {

    }
    
    protected void btnToDown_Click(object sender, ImageClickEventArgs e)
    {

    }
    
    protected void ugrdEmpList_DblClick(object sender, Infragistics.WebUI.UltraWebGrid.ClickEventArgs e)
    {
        ugrdAppLine.Rows.Insert(0, e.Row, true);
        int iRow = ugrdAppLine.Rows.Count;
        for (int i = 0; i < iRow; i++)
        {
            ugrdAppLine.Rows[i].Cells.FromKey("LINE_STEP").Value = Convert.ToString((i + 1));
        }
    }
    
    protected void ugrdAppLine_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Bands[0].Columns.FromKey("LINE_TYPE").Type = ColumnType.DropDownList;
        ValueList vlsLine = e.Layout.Bands[0].Columns.FromKey("LINE_TYPE").ValueList;
        for (int i = 0; i < ddlLineType.Items.Count; i++)
        {
            vlsLine.ValueListItems.Add(new ValueListItem(ddlLineType.Items[i].Text, ddlLineType.Items[i].Value));
        }
    }

    protected void grvLineTable_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (idxLine == 2)
        {
            e.Row.Height = Unit.Pixel(65);
        }
        else
        {
            e.Row.Height = Unit.Pixel(17);
        }

        if (idxLine == 1)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Style.Add(HtmlTextWriterStyle.BackgroundColor, "#D3DBDE");
            }
        }

        idxLine += 1;
    }

    protected void grvLineTable_Load(object sender, EventArgs e)
    {
        idxLine = 0;
    }

    protected void btnDraft_Click(object sender, ImageClickEventArgs e)
    {
        //if (grvLineTable.Columns.Count < 2)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("결재선을 지정해주십시오", false);
        //    return;
        //}
        this.SetDraft();
        //this.SetFormData();
    }

    protected void btnSanction_Click(object sender, ImageClickEventArgs e)
    {
        this.SetApproval();
    }

    protected void btnReturn_Click(object sender, ImageClickEventArgs e)
    {
        this.SetReturn();
    }

    #endregion
}
