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


using MicroBSC.Common;

public partial class BSC_BSC0505M1 : AppPageBase
{
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("ITYPE", "S");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 1000);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD");
            }
            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string IisAdmin
    {
        get
        {
            if (ViewState["IS_ADMIN"] == null)
            {
                ViewState["IS_ADMIN"] = (User.IsInRole(ROLE_ADMIN)) ? "Y" : "N";
            }

            return (string)ViewState["IS_ADMIN"];
        }
        set
        {
            ViewState["IS_ADMIN"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";

        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetFormData();
        }
    }

    private void SetInitForm()
    {
        this.iBtnUpdate.Visible = false;
        this.pnlWrite.Visible   = false;

        this.pnlRead.Visible    = true;

        if (User.IsInRole(ROLE_ADMIN))
        {
            this.iBtnUpdate.Visible = true;
            this.iBtnInsert.Visible = false;
        }
        else
        { 
            this.iBtnUpdate.Visible = false;
            this.iBtnInsert.Visible = false;
        }
    }

    private void SetFormData()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Monthly_Report objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Monthly_Report(this.IEstTermRefID, this.IYmd);
        this.ltrTotalOpinion.Text  = objBSC.Ireport_detail;
        this.txtTotalOpinion.Value = objBSC.Ireport_detail;
        this.hdfReportFile.Value   = objBSC.Ireport_file_id;
    }

    private int SetSaveData()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Monthly_Report objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Monthly_Report();
        int intRtn = objBSC.InsertData
                          ( this.IEstTermRefID
                          , this.IYmd
                          , txtTotalOpinion.Value
                          , hdfReportFile.Value
                          , gUserInfo.Emp_Ref_ID);
        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        return intRtn;
    }

    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.pnlWrite.Visible   = true;
        this.pnlRead.Visible    = false;
        this.iBtnUpdate.Visible = false;
        this.iBtnInsert.Visible = true;
    }
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        int intRtn = this.SetSaveData();

        if (intRtn > 0)
        { 
            this.pnlWrite.Visible   = false;
            this.pnlRead.Visible    = true;

            if (User.IsInRole(ROLE_ADMIN))
            {
                this.iBtnUpdate.Visible = true;
                this.iBtnInsert.Visible = false;
            }
            else
            { 
                this.iBtnUpdate.Visible = false;
                this.iBtnInsert.Visible = false;
            }

            this.ltrTotalOpinion.Text = txtTotalOpinion.Value;
        }
    }
}
