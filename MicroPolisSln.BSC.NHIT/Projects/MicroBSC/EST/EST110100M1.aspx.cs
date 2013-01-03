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
using MicroBSC.Integration.EST.Biz;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.Documents.Excel;

public partial class EST_EST110100M1 : EstPageBase
{
    Biz_Est_Data bizEstData;
    Biz_Est_Refusal bizEstRefusal;

    public int COMP_ID;
	public string EST_ID;
    
    public int ESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                return 0;

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }
    
    public int ESTTERM_SUB_ID
    {
        get
        {
            if (ViewState["ESTTERM_SUB_ID"] == null)
                return 0;

            return (int)ViewState["ESTTERM_SUB_ID"];
        }
        set
        {
            ViewState["ESTTERM_SUB_ID"] = value;
        }
    }

    public int ESTTERM_STEP_ID;
    public int TGT_DEPT_ID;
    public int TGT_EMP_ID;

	public string EST_TGT_TYPE;
	

	protected void Page_Init(object sender, EventArgs e)
	{
	}

	protected void Page_Load(object sender, EventArgs e)
	{

        bizEstData = new Biz_Est_Data();
        bizEstRefusal = new Biz_Est_Refusal();


        COMP_ID = WebUtility.GetRequestByInt("COMP_ID", 1);
        EST_ID = WebUtility.GetConfig("EST_GRADE_ID");

        //ESTTERM_REF_ID = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        //ESTTERM_SUB_ID = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = WebUtility.GetRequestByInt("ESTTERM_STEP_ID", 1);

        //TGT_DEPT_ID = WebUtility.GetRequestByInt("TGT_DEPT_ID");
        TGT_EMP_ID = WebUtility.GetRequestByInt("TGT_EMP_ID", gUserInfo.Emp_Ref_ID);
        TGT_DEPT_ID = 0;

        EST_TGT_TYPE = WebUtility.GetRequest("EST_TGT_TYPE", "TGT");

        // 웹 취약성 검사 때문에 처리
        if (EST_TGT_TYPE.Equals("-0"))
        {
            ltrScript.Text = JSHelper.GetAlertScript("악성 요청을 거부합니다.", false);
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                    , WebUtility.GetIntByValueDropDownList(ddlCompID)
                                                    , "N");
        }


        ESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermSubID);


        PageUtility.FindByValueDropDownList(ddlEstTermRefID, ESTTERM_REF_ID.ToString());
        PageUtility.FindByValueDropDownList(ddlEstTermSubID, ESTTERM_SUB_ID.ToString());


		ltrScript.Text = "";

        if (!Page.IsPostBack)
        {
            Get_Refusal_Data();
        }
	}


    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Get_Refusal_Data();
    }
    private void clearField()
    {
        this.lblGrade_id.Text = "";
        this.hdf_grade_id.Value = "";
        this.txt_RefusalComment.Text = "";
        this.txt_RefusalReply.Text = "";
    }
    private void Get_Refusal_Data()
    {
        if (EST_TGT_TYPE.Equals("TGT"))
        {
            ibnSaveComment.Visible = true;
            ibnSaveReply.Visible = false;
        }
        else
        {
            ibnSaveComment.Visible = false;
            ibnSaveReply.Visible = true;
        }

        clearField();

        DataTable dtEst_Data = bizEstData.GetEstData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, "", TGT_DEPT_ID, TGT_EMP_ID);
        /*
        dtEst_Data = new DataTable();
        dtEst_Data.Columns.Add("GRADE_ID");
        dtEst_Data.Rows.Add("S");
        */

        DataTable dtEst_Refusal = bizEstRefusal.Get_Est_Refusal_Data(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, TGT_DEPT_ID, TGT_EMP_ID);

        if (dtEst_Data.Rows.Count > 0)
        {
            doBind_grade_id(dtEst_Data.Rows[0]["GRADE_ID"].ToString());


            if (dtEst_Refusal.Rows.Count > 0)
            {
                this.txt_RefusalComment.Text = dtEst_Refusal.Rows[0]["REFUSAL_COMMENT"].ToString();
                this.txt_RefusalReply.Text = dtEst_Refusal.Rows[0]["REPLY_COMMENT"].ToString();
            }
            ibnSaveComment.Visible = true;
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("평가 데이터가 없습니다");
            lblGrade_id.Text = "등급 미확정";
            ibnSaveComment.Visible = false;
        }

        
    }
    private void doBind_grade_id(string grade_id)
    {
        this.lblGrade_id.Text = grade_id;
        this.hdf_grade_id.Value = grade_id;
    }

    protected void ibnSaveReply_Click(object sender, ImageClickEventArgs e)
    {
        DoSavingReply();
    }

    private void DoSavingReply()
    {
        DataTable dtEst_Refusal = bizEstRefusal.Get_Est_Refusal_Data(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, TGT_DEPT_ID, TGT_EMP_ID);
        bool Result;


        Result = bizEstRefusal.Modify_Est_Refusal_Reply(COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID
                                                    , TGT_DEPT_ID
                                                    , TGT_EMP_ID
                                                    , this.gUserInfo.Emp_Ref_ID
                                                    , this.txt_RefusalReply.Text
                                                    , gUserInfo.Emp_Ref_ID);

        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패했습니다.");
        }
    }

    protected void ibnSaveComment_Click(object sender, ImageClickEventArgs e)
    {
        Savecomment();
    }
    private void Savecomment()
    {
        DataTable dtEst_Refusal = bizEstRefusal.Get_Est_Refusal_Data(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, TGT_DEPT_ID, TGT_EMP_ID);
        bool Result;

        if (dtEst_Refusal.Rows.Count == 0)
        {
            Result = bizEstRefusal.Add_Est_Refusal(COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID
                                                    , TGT_DEPT_ID
                                                    , TGT_EMP_ID
                                                    , this.txt_RefusalComment.Text
                                                    , this.lblGrade_id.Text
                                                    , gUserInfo.Emp_Ref_ID);
        }
        else
        {
            Result = bizEstRefusal.Modify_Est_Refusal_Comment(COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID
                                                    , TGT_DEPT_ID
                                                    , TGT_EMP_ID
                                                    , this.txt_RefusalComment.Text
                                                    , gUserInfo.Emp_Ref_ID);
        }


        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패했습니다.");
        }
    }
}
