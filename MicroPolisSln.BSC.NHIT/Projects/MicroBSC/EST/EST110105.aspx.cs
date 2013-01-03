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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

public partial class EST_EST110105 : EstPageBase
{
    protected int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    protected int ICOMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
                ViewState["COMP_ID"] = 0;
            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }

    protected string IEST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
                ViewState["EST_ID"] = "3GA";
            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }

    protected int IESTTERM_SUB_ID
    {
        get
        {
            if (ViewState["ESTTERM_SUB_ID"] == null)
                ViewState["ESTTERM_SUB_ID"] = 0;
            return (int)ViewState["ESTTERM_SUB_ID"];
        }
        set
        {
            ViewState["ESTTERM_SUB_ID"] = value;
        }
    }

    protected int IESTTERM_STEP_ID
    {
        get
        {
            if (ViewState["ESTTERM_STEP_ID"] == null)
                ViewState["ESTTERM_STEP_ID"] = 0;
            return (int)ViewState["ESTTERM_STEP_ID"];
        }
        set
        {
            ViewState["ESTTERM_STEP_ID"] = value;
        }
    }

    protected string IEST_STATUS
    {
        get
        {
            if (ViewState["EST_STATUS"] == null)
                ViewState["EST_STATUS"] = "N";
            return (string)ViewState["EST_STATUS"];
        }
        set
        {
            ViewState["EST_STATUS"] = value;
        }
    }

    protected string IEST_COMPLETE
    {
        get
        {
            if (ViewState["EST_COMPLETE"] == null)
                ViewState["EST_COMPLETE"] = "N";
            return (string)ViewState["EST_COMPLETE"];
        }
        set
        {
            ViewState["EST_COMPLETE"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }

        ltrScript.Text = "";
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ICOMP_ID = PageUtility.GetIntByValueDropDownList(ddlCompID);
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdMBO.Clear();
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdMBO.Clear();
        IESTTERM_SUB_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermSubID);
    }

    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdMBO.Clear();
        IESTTERM_STEP_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermStepID);
    }

    protected void ddlComDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdMBO.Clear();
    }

    private void DoInitControl()
    {
        tblViewStatus.CellPadding = 0;
        tblViewStatus.CellSpacing = 0;
        tblViewStatus.BorderWidth = 0;

        TableRow tblRow     = new TableRow();
        TableCell tblCell   = null;
        tblViewStatus.Rows.Add(tblRow);

        Biz_Status bizStatus = new Biz_Status();
        DataSet dsStatus = bizStatus.GetStatuses("0003");
        foreach (DataRow dataRow in dsStatus.Tables[0].Rows) 
        {
            tblCell         = new TableCell();
            tblCell.Style.Add("padding-right", "5px");
            tblCell.Text    = string.Format("<img src='{0}' alt='{1}' /> {2} ", dataRow["STATUS_IMG_PATH"], dataRow["STATUS_DESC"], dataRow["STATUS_NAME"]);
            tblRow.Cells.Add(tblCell);
        }

        DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
        ICOMP_ID = GetRequestByInt("COMP_ID", PageUtility.GetIntByValueDropDownList(ddlCompID));
        PageUtility.FindByValueDropDownList(ddlCompID, ICOMP_ID);

        DropDownListCommom.BindEstTerm(ddlEstTerm);
        IESTTERM_REF_ID = GetRequestByInt("ESTTERM_REF_ID", PageUtility.GetIntByValueDropDownList(ddlEstTerm));
        PageUtility.FindByValueDropDownList(ddlEstTerm, IESTTERM_REF_ID);

        DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                    , ICOMP_ID
                                                    , "N");
        IESTTERM_SUB_ID = GetRequestByInt("ESTTERM_SUB_ID", PageUtility.GetIntByValueDropDownList(ddlEstTermSubID));
        PageUtility.FindByValueDropDownList(ddlEstTermSubID, IESTTERM_SUB_ID);

        DropDownListCommom.BindEstTermStep(ddlEstTermStepID, ICOMP_ID, IEST_ID, "N");
        if (ddlEstTermStepID.Items.Count > 0)
        {
            ddlEstTermStepID.Items.Insert(0, new ListItem("::전체::", "0"));
            ddlEstTermStepID.SelectedIndex = 0;
            ESTTERM_STEP_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermStepID);
        }

        WebCommon.SetComDeptDropDownList(ddlComDept, true);
        //PageUtility.FindByValueDropDownList(ddlComDept, BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }
    
    protected void ibtnSearchAll_Click(object sender, ImageClickEventArgs e)
    {
        ddlComDept.SelectedIndex = 0;
        ddlEstTermStepID.SelectedIndex = 0;
        DoBinding();
    }

    protected void ibtnConfirmAll_Click(object sender, ImageClickEventArgs e)
    {
        DoConfirmEst(true);
    }

    protected void ibtnConfirmMbo_Click(object sender, ImageClickEventArgs e)
    {
        DoConfirmEst(false);
    }

    private void DoConfirmEst(bool completeYN)
    {
        Biz_Datas bizDatas = new Biz_Datas();
        if (bizDatas.ConfirmMBOEstimate(this.ICOMP_ID
                                        , this.IEST_ID
                                        , this.IESTTERM_REF_ID
                                        , this.IESTTERM_SUB_ID
                                        , "JOB_91"
                                        , this.EMP_REF_ID
                                        , completeYN))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정하였습니다.");
            DoBinding();
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정 실패!");
    }

    protected void ibtnCancelConfirm_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas bizDatas = new Biz_Datas();
        if (bizDatas.ConfirmCancelMBOEstimate(this.ICOMP_ID
                                            , this.IEST_ID
                                            , this.IESTTERM_REF_ID
                                            , this.IESTTERM_SUB_ID
                                            , "JOB_91"
                                            , this.EMP_REF_ID))
        {
            ltrScript.Text = JSHelper.GetAlertScript("확정취소하였습니다.");
            DoBinding();
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("확정취소 실패!");
    }

    protected void ibtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        ugrdEEP.ExcelStartRow = 5;
        ugrdEEP.ExportMode = ExportMode.InBrowser;
        ugrdEEP.DownloadName = "MBO LIST";
        ugrdEEP.WorksheetName = "MBO 평가현황";
        ugrdEEP.Export(ugrdMBO);
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTerm.SelectedItem.Text + " / " + ddlEstTermSubID.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "피평가부서 : " + ddlComDept.SelectedItem.Text;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "평가차수 : " + ddlEstTermStepID.SelectedItem.Text;
        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
    }

    protected void ugrdEEP_EndExport(object sender, EndExportEventArgs e)
    {
        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            e.CurrentWorksheet.Rows[i + 5].Cells[0].Value = ugrdMBO.Rows[i].Cells.FromKey("STATUS_NAME").Value.ToString();
        }
    }

    private void DoBinding()
    {
        Biz_Datas biz   = new Biz_Datas();
        int dept_ref_id = DataTypeUtility.GetToInt32(ddlComDept.SelectedValue);
        int estterm_step_id = this.IESTTERM_STEP_ID;
        DataSet ds = biz.Get3GADataEstData(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, this.IESTTERM_SUB_ID, estterm_step_id, dept_ref_id);
        ugrdMBO.Clear();
        ugrdMBO.DataSource = ds.Tables[0];
        ugrdMBO.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();

        if (ds.Tables[1].Rows.Count > 0)
            this.IEST_STATUS = ds.Tables[1].Rows[0]["STATUS_YN"].ToString();

        if (ds.Tables[2].Rows.Count > 0)
            this.IEST_COMPLETE = "N";
        else
            this.IEST_COMPLETE = "Y";
    }

    protected void ugrdMBO_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;
        e.Row.Cells.FromKey("EST_STATUS").Value = string.Format("<img src='{0}' alt='{1}' />", drw["STATUS_IMG_PATH"].ToString(), drw["STATUS_NAME"].ToString());

        //if (IUSERTYPE == 1)
        //{
        //    e.Row.Cells.FromKey("SELECT").Text = string.Format(@"<a href='EST110104_01.aspx?USERTYPE={0}&COMP_ID={1}&ESTTERM_REF_ID={2}&ESTTERM_SUB_ID={3}&ESTTERM_STEP_ID={4}&EST_EMP_ID={5}&EST_DEPT_ID={6}&TGT_EMP_ID={7}&TGT_DEPT_ID={8}'><div class='stext' style='cursor: pointer;'><img src='../images/btn/b_143.gif'></div></a>"
        //                                                        , IUSERTYPE
        //                                                        , ICOMP_ID
        //                                                        , IESTTERM_REF_ID
        //                                                        , IESTTERM_SUB_ID
        //                                                        , e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString());
        //}
        //else
        //{
        //    e.Row.Cells.FromKey("SELECT").Text = string.Format(@"<a href='EST110104_01.aspx?USERTYPE={0}&COMP_ID={1}&ESTTERM_REF_ID={2}&ESTTERM_SUB_ID={3}&ESTTERM_STEP_ID={4}&EST_EMP_ID={5}&EST_DEPT_ID={6}&TGT_EMP_ID={7}&TGT_DEPT_ID={8}'><div class='stext' style='cursor: pointer;'><img src='../images/btn/b_143.gif'></div></a>"
        //                                                        , IUSERTYPE
        //                                                        , ICOMP_ID
        //                                                        , IESTTERM_REF_ID
        //                                                        , IESTTERM_SUB_ID
        //                                                        , e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString()
        //                                                        , e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString());
        //}
    }
}
