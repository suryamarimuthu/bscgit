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

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Biz.Common;

public partial class BSC_BSC0704M1 : AppPageBase
{
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
            if (ViewState["iTYPE"] == null)
            {
                ViewState["iTYPE"] = GetRequest("iTYPE", "S");
            }

            return (string)ViewState["iTYPE"];
        }
        set
        {
            ViewState["iTYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public int INoticeRefID
    {
        get
        {
            if (ViewState["NOTICE_REF_ID"] == null)
            {
                ViewState["NOTICE_REF_ID"] = GetRequestByInt("NOTICE_REF_ID", 0);
            }

            return (int)ViewState["NOTICE_REF_ID"];
        }
        set
        {
            ViewState["NOTICE_REF_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
        }
        else
        { 
            
        }
    }

    private void SetInitForm()
    {
        if (this.IType == "A")
        {
            txtContent.Visible      = true;
            leftLayer.Visible       = false;
            this.iBtnSave.Visible   = true;
            this.iBtnModify.Visible = false;
            this.iBtnDelete.Visible = false;
            lblWriterName.Text      = gUserInfo.Emp_Name;
        }
        else if (this.IType == "U")
        {
            this.SetNoticeInfo();
        }
        else
        { 
            txtContent.Visible      = false;
            leftLayer.Visible       = true;
            this.iBtnSave.Visible   = false;
            this.iBtnModify.Visible = false;
            this.iBtnDelete.Visible = false;
        }
    }

    public void SetNoticeInfo()
    { 
        Biz_Bsc_Communication_Notice objBSC = new Biz_Bsc_Communication_Notice(this.INoticeRefID);
        lblReadCount.Text  = objBSC.Iread_count.ToString();
        lblCreateDate.Text = objBSC.Create_date.ToLongDateString();
        wdcFrom.Value      = objBSC.Inotice_from.ToLongDateString();
        wdcTo.Value        = objBSC.Inotice_to.ToLongDateString();  
        txtSubject.Text    = objBSC.Ititle;
        txtContent.Value   = objBSC.Idetails;
        ltrContent.Text    = objBSC.Idetails;
        chkPopUpYn.Checked = (objBSC.Ishow_pop_up == "Y") ? true : false;

        EmpInfos objEMP = new EmpInfos(objBSC.Create_user);
        lblWriterName.Text = objEMP.Emp_Name;

        if (gUserInfo.Emp_Ref_ID == objBSC.Create_user)
        {
            txtContent.Visible      = true;
            leftLayer.Visible       = false;
            this.iBtnSave.Visible   = false;
            this.iBtnModify.Visible = true;
            this.iBtnDelete.Visible = true;
            this.wdcFrom.Enabled    = true;
            this.wdcTo.Enabled      = true;
            this.chkPopUpYn.Enabled = true;
        }
        else
        { 
            txtContent.Visible      = false;
            leftLayer.Visible       = true;
            this.iBtnSave.Visible   = false;
            this.iBtnModify.Visible = false;
            this.iBtnDelete.Visible = false;
            this.wdcFrom.Enabled    = false;
            this.wdcTo.Enabled      = false;
            this.chkPopUpYn.Enabled = false;

            int intRtn = objBSC.AddClickCount(this.INoticeRefID, gUserInfo.Emp_Ref_ID);
        }
    }

    /// <summary>
    /// 처리시 데이터 validation check
    /// </summary>
    /// <returns></returns>
    public bool ValidateFormData()
    {
        if (txtSubject.Text == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("제목을 입력해주십시오", false);
            return false;
        }
        else if (txtContent.Value == "")
        { 
            ltrScript.Text = JSHelper.GetAlertScript("내용을 입력해주십시오", false);
            return false;
        }
        else if (wdcFrom.Text == "")
        { 
            ltrScript.Text = JSHelper.GetAlertScript("공지시작일자를 입력해주십시오", false);
            return false;
        }
        else if (wdcTo.Text == "")
        { 
            ltrScript.Text = JSHelper.GetAlertScript("공지종료일자를 입력해주십시오", false);
            return false;
        }

        return true;
    }

    /// <summary>
    /// 공지사항 입력/수정/삭제
    /// </summary>
    /// <returns></returns>
    public bool TxrNotice()
    {
        if (this.IType == "A" || this.IType == "U")
        {
            if (!this.ValidateFormData())
            {
                return false;
            }
        }

        Biz_Bsc_Communication_Notice objBSC = new Biz_Bsc_Communication_Notice();
        objBSC.Inotice_ref_id  = this.INoticeRefID;
        objBSC.Iestterm_ref_id = this.IEstTermRefID;
        objBSC.Iymd            = this.IYMD;
        objBSC.Ititle          = this.txtSubject.Text;
        objBSC.Idetails        = this.txtContent.Value;
        objBSC.Iread_count     = 0;
        objBSC.Ishow_pop_up    = (chkPopUpYn.Checked ? "Y" : "N");
        objBSC.Inotice_from    = Convert.ToDateTime(wdcFrom.Value);
        objBSC.Inotice_to      = Convert.ToDateTime(wdcTo.Value);
        objBSC.Iattach_no      = "";
        objBSC.Itxr_user       = gUserInfo.Emp_Ref_ID;

        int intRtn = 0;
        if (this.IType == "A")
        {
            intRtn = objBSC.InsertData
                     (
                         objBSC.Iestterm_ref_id
                        ,objBSC.Iymd
                        ,objBSC.Ititle
                        ,objBSC.Idetails
                        ,objBSC.Iread_count
                        ,objBSC.Iattach_no
                        ,objBSC.Inotice_from
                        ,objBSC.Inotice_to
                        ,objBSC.Ishow_pop_up
                        ,objBSC.Itxr_user
                     );
            if (objBSC.Transaction_Result == "Y")
            {
                this.INoticeRefID = objBSC.Inotice_ref_id;
            }
        }
        else if (this.IType == "U")
        { 
            intRtn = objBSC.UpdateData
                     (
                         objBSC.Inotice_ref_id
                        ,objBSC.Iestterm_ref_id
                        ,objBSC.Iymd
                        ,objBSC.Ititle
                        ,objBSC.Idetails
                        ,objBSC.Iread_count
                        ,objBSC.Iattach_no
                        ,objBSC.Inotice_from
                        ,objBSC.Inotice_to
                        ,objBSC.Ishow_pop_up
                        ,objBSC.Itxr_user
                     );
        }
        else if (this.IType == "D")
        {
            intRtn = objBSC.DeleteData
                     (
                        objBSC.Inotice_ref_id
                      , objBSC.Itxr_user
                     );
        }
        else
        { 
            intRtn = objBSC.AddClickCount
                     (
                        objBSC.Inotice_ref_id
                      , objBSC.Itxr_user
                     );
        }

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        return ((intRtn>0) ? true : false);
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (this.TxrNotice())
        {
            this.IType = "U";
            this.SetNoticeInfo();
        }
    }
    
    protected void iBtnModify_Click(object sender, ImageClickEventArgs e)
    {
        bool blnRtn = this.TxrNotice();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "D";
        if (!this.TxrNotice())
        {
            this.IType = "U";
        }
    }
}
