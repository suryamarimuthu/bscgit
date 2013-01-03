using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC0501M5 : AppPageBase
{
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.lBtnReload2.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    protected string IIS_TEAM_KPI
    {
        get
        {
            if (ViewState["IS_TEAM_KPI"] == null)
            {
                ViewState["IS_TEAM_KPI"] = GetRequest("IS_TEAM_KPI");
            }

            return (string)ViewState["IS_TEAM_KPI"];
        }
        set
        {
            ViewState["IS_TEAM_KPI"] = value;
        }
    }

    public int IDraftEmpID
    {
        get
        {
            return (int)ViewState["DRAFT_EMP_ID"];
        }
        set
        {
            ViewState["DRAFT_EMP_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.IIS_TEAM_KPI = GetRequest("IS_TEAM_KPI");
        this.IDraftEmpID = gUserInfo.Emp_Ref_ID;
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }
        ltrScript.Text = "";
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void lBtnReload2_Click(object sender, EventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    protected void ibtnDraft_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtAppLine = new DataTable("APP_LINE");
        dtAppLine.Columns.Add("APP_REF_ID", typeof(decimal));
        dtAppLine.Columns.Add("VERSION_NO", typeof(int));
        dtAppLine.Columns.Add("LINE_STEP", typeof(int));
        dtAppLine.Columns.Add("APP_EMP_ID", typeof(int));
        dtAppLine.Columns.Add("COMMENTS", typeof(string));

        for (int i = 0; i < ugrdDraft.Rows.Count; i++)
        {
            if (DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("APP_REF_ID").Value) < 1
                || DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("VERSION_NO").Value) < 1 
                || DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("LINE_STEP").Value) < 1)
            {
                this.ltrScript.Text = JSHelper.GetAlertScript("결재문서정보가 올바르지 않습니다.", false);
                return;
            }

            DataRow drAppLine = dtAppLine.NewRow();
            drAppLine["APP_REF_ID"] = DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("APP_REF_ID").Value);
            drAppLine["VERSION_NO"] = DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("VERSION_NO").Value);
            drAppLine["LINE_STEP"] = DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("LINE_STEP").Value);
            drAppLine["APP_EMP_ID"] = this.IDraftEmpID;
            drAppLine["COMMENTS"] = txtAppOpinion.Text.Trim();

            dtAppLine.Rows.Add(drAppLine);
        }
        
        Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();
        int iRtn = objPrc.Approval(dtAppLine);

        if (iRtn > 0)
        {
            SendMailBatch(false);
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objPrc.Transaction_Message, this.ICCB1, true);
        return;
    }

    public void SendMailBatch(bool isReturn)
    {
        if (PageUtility.GetAppConfig("Mail.UseDraftMailYN") == "N")
        {
            return;
        }

        string sC_EMP_MAIL = "";
        string sP_EMP_MAIL = "";
        string sN_EMP_MAIL = "";
        string sFile = "Mail_Draft.htm";

        EmpInfos objEmp = new EmpInfos(gUserInfo.Emp_Ref_ID);
        Biz_Com_Approval_Prc objPrc = new Biz_Com_Approval_Prc();

        for (int i = 0; i < ugrdDraft.Rows.Count; i++)
        {
            int appid, verno;
            string biztype = string.Empty;
            if (ugrdDraft.Rows[i].Cells.FromKey("BIZ_TYPE").Value.ToString() == Biz_Type.biz_type_kpi_docbatch)
                biztype = Biz_Type.biz_type_kpi_doc;
            else if (ugrdDraft.Rows[i].Cells.FromKey("BIZ_TYPE").Value.ToString() == Biz_Type.biz_type_kpi_rstbatch)
                biztype = Biz_Type.biz_type_kpi_rst;
            else if (ugrdDraft.Rows[i].Cells.FromKey("BIZ_TYPE").Value.ToString() == Biz_Type.biz_type_target_resultbatch)
                biztype = Biz_Type.biz_type_target_result;
            appid = DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("APP_REF_ID").Value);
            verno = DataTypeUtility.GetToInt32(ugrdDraft.Rows[i].Cells.FromKey("VERSION_NO").Value);
            bool bRtn = objPrc.GetSendMailUser(appid, verno, gUserInfo.Emp_Ref_ID, out sC_EMP_MAIL, out sP_EMP_MAIL, out sN_EMP_MAIL);
            if (!bRtn)
            {
                return;
            }

            if (isReturn && (!PageUtility.CheckMailAddress(sC_EMP_MAIL) || !PageUtility.CheckMailAddress(sN_EMP_MAIL)))
            {
                return;
            }

            if (!isReturn && (!PageUtility.CheckMailAddress(sC_EMP_MAIL) || !PageUtility.CheckMailAddress(sP_EMP_MAIL)))
            {
                return;
            }

            bool rtnValue = false;
            DataTable dtMailParam = new DataTable("PARAM");
            dtMailParam.Columns.Add("KEY", typeof(string));
            dtMailParam.Columns.Add("VAL", typeof(string));

            Biz_Com_Approval_Info objMst = new Biz_Com_Approval_Info(appid, verno);

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
            dr["VAL"] = Biz_Com_Approval_Info.GetBizTypeName(biztype);
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

            string sMailTitle = "[성과관리 - " + Biz_Com_Approval_Info.GetBizTypeName(biztype) + " 건 알림메일]";

            bool ismail = PageUtility.SendMail(dtMailParam, sC_EMP_MAIL, (isReturn) ? sN_EMP_MAIL : sP_EMP_MAIL, sMailTitle, sFile);
        }
    }

    private void DoBinding()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();

        string app_ref_id = string.Empty;
        foreach (string app1 in GetRequest("AVL").Split(','))
        {
            app_ref_id += app1.Split(';').GetValue(0).ToString() + ",";
        }
        if (!app_ref_id.Equals(""))
            app_ref_id = app_ref_id.Substring(0, app_ref_id.Length - 1);
        DataSet ds = objBSC.GetKpiListForBatchApproval(app_ref_id, gUserInfo.Emp_Ref_ID);

        ugrdDraft.Clear();
        ugrdDraft.DataSource = ds;
        ugrdDraft.DataBind();

    }

    private void DoInitControl()
    {
        
    }

    protected void ugrdDraft_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //this.SetDraftLegend(sender, e);
        e.Layout.Bands[0].Columns.FromKey("SIGNAL_MS").Header.RowLayoutColumnInfo.SpanX = 2;
    }

    protected void ugrdDraft_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        
        DataRowView drw = (DataRowView)e.Data;

        //if (drw["CHECK_YN"].ToString() == "N")
        //{
        //    e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        //}
        //else
        //{
        //    e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        //}

        //if (drw["CHECKSTATUS"].ToString() == "N")
        //{
        //    e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        //}
        //else
        //{
        //    e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        //}

        //TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        //System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        //string strImg = DataTypeUtility.GetValue(e.Row.Cells.FromKey("APP_STATUS").Value);
        //objImg.ImageUrl = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        //objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);
        if (drw["BIZ_TYPE"].ToString() == Biz_Type.biz_type_kpi_doc)
        {
            e.Row.Cells.FromKey("RESULT_MS").Text = "해당없음";
            e.Row.Cells.FromKey("RESULT_TS").Text = "해당없음";
            e.Row.Cells.FromKey("SIGNAL_MS").Text = "해당없음";
            e.Row.Cells.FromKey("SIGNAL_TS").Text = "해당없음";

            e.Row.Cells.FromKey("RESULT_MS").ColSpan = 4;
            e.Row.Cells.FromKey("RESULT_MS").Style.HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells.FromKey("RESULT_MS").Style.BackColor = Color.LightGray;

        }
        else
        {
            e.Row.Cells.FromKey("SIGNAL_MS").Text = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_MS").Value.ToString() + "' />";
            e.Row.Cells.FromKey("SIGNAL_TS").Text = "<img src='../images/" + e.Row.Cells.FromKey("SIGNAL_TS").Value.ToString() + "' />";
        }
    }
}
