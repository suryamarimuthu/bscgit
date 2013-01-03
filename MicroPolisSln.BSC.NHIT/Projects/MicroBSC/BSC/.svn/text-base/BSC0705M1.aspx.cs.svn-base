using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MicroBSC.Integration.BSC.Biz;
using MicroBSC.Biz.Common;

public partial class BSC_BSC0705M1 : AppPageBase
{
    protected int CategoryId = 1;
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

    public string FAQ_REF_ID
    {
        get
        {
            if (ViewState["FAQ_REF_ID"] == null)
            {
                ViewState["FAQ_REF_ID"] = GetRequest("FAQ_REF_ID", "S");
            }

            return (string)ViewState["FAQ_REF_ID"];
        }
        set
        {
            ViewState["FAQ_REF_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
        }
    }

    private void SetInitForm()
    {
        if (this.IType == "A")
        {
            txtContent.Visible = true;
            leftLayer.Visible = false;
            this.iBtnSave.Visible = true;
            this.iBtnModify.Visible = false;
            this.iBtnDelete.Visible = false;
            lblWriterName.Text = gUserInfo.Emp_Name;
            lblCreateDate.Text = DateTime.Now.ToShortDateString();
        }
        else if (this.IType == "U")
        {
            this.SetNFaqInfo();
        }
        else
        {
            txtContent.Visible = false;
            leftLayer.Visible = true;
            this.iBtnSave.Visible = false;
            this.iBtnModify.Visible = false;
            this.iBtnDelete.Visible = false;
        }
    }

    public void SetNFaqInfo()
    {
        Biz_Bsc_Faq objBSC = new Biz_Bsc_Faq();
        DataTable dt = objBSC.SelectBscFaqIdxAll(int.Parse(FAQ_REF_ID));
        int emp = 0;
        if (dt.Rows.Count > 0)
        {
            lblCreateDate.Text = string.Format("{0:yyyy-MM-dd}", dt.Rows[0]["CREATE_DATE"]);
            txtSubject.Text = dt.Rows[0]["FAQ_QUESTION"].ToString();
            txtContent.Value = dt.Rows[0]["FAQ_ANSWER"].ToString();
            ltrContent.Text = dt.Rows[0]["FAQ_ANSWER"].ToString();

            emp = int.Parse(dt.Rows[0]["CREATE_USER"].ToString());
            EmpInfos objEMP = new EmpInfos(emp);
            lblWriterName.Text = objEMP.Emp_Name;
        }

        if (gUserInfo.Emp_Ref_ID == emp)
        {
            txtContent.Visible = true;
            leftLayer.Visible = false;
            this.iBtnSave.Visible = false;
            this.iBtnModify.Visible = true;
            this.iBtnDelete.Visible = true;
        }
        else
        {
            txtContent.Visible = false;
            leftLayer.Visible = true;
            this.iBtnSave.Visible = false;
            this.iBtnModify.Visible = false;
            this.iBtnDelete.Visible = false;

           // int intRtn = objBSC.AddClickCount(this.INoticeRefID, gUserInfo.Emp_Ref_ID);
        }
        
    }

    public bool ValidateFormData()
    {
        if (txtSubject.Text == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("질문을 입력해주십시오", false);
            return false;
        }
        if (txtContent.Value == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("답변을 입력해주십시오", false);
            return false;
        }

        return true;
    }

    public bool TxrNotice()
    {
        if (this.IType == "A" || this.IType == "U")
        {
            if (!this.ValidateFormData())
            {
                return false;
            }
        }

        Biz_Bsc_Faq objBSC = new Biz_Bsc_Faq();
       
        int intRtn = 0;
        if (this.IType == "A")
        {
            if (objBSC.Insert_DB(CategoryId, txtSubject.Text, txtContent.Value, gUserInfo.Emp_Ref_ID) == "")
            {
                intRtn = 1;
            }
        }
        if (this.IType == "U")
        {

            if (objBSC.Update_DB(int.Parse(FAQ_REF_ID), CategoryId, txtSubject.Text, txtContent.Value, gUserInfo.Emp_Ref_ID) == "")
            {
                intRtn = 1;
            }
        }
        if (this.IType == "D")
        {
            if (objBSC.Delete_DB(int.Parse(FAQ_REF_ID), gUserInfo.Emp_Ref_ID) == "")
            {
                intRtn = 1;
            }
        }
        
        return ((intRtn > 0) ? true : false);
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        string strReturnMessage = string.Empty;
        if (this.TxrNotice())
        {
            strReturnMessage = "저장되었습니다.";
            ltrScript.Text = JSHelper.GetAlertOpenerReflashScript(strReturnMessage, true);
        }
        else
        {
            strReturnMessage = "저장 실패되었습니다.";
            ltrScript.Text = JSHelper.GetAlertScript(strReturnMessage, false);
        }
    }

    protected void iBtnModify_Click(object sender, ImageClickEventArgs e)
    {
        string strReturnMessage = string.Empty;
        if (this.TxrNotice())
        {
            strReturnMessage = "수정되었습니다.";
            ltrScript.Text = JSHelper.GetAlertOpenerReflashScript(strReturnMessage, true);
        }
        else
        {
            strReturnMessage = "수정 실패되었습니다.";
            ltrScript.Text = JSHelper.GetAlertScript(strReturnMessage, false);
        }
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "D";
        string strReturnMessage = string.Empty;
        if (this.TxrNotice())
        {
            strReturnMessage = "삭제되었습니다.";
            ltrScript.Text = JSHelper.GetAlertOpenerReflashScript(strReturnMessage, true);
        }
        else
        {
            strReturnMessage = "삭제 실패되었습니다.";
            ltrScript.Text = JSHelper.GetAlertScript(strReturnMessage, false);
        }
    }
}
