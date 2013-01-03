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

using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.Common;

public partial class BSC_BSC0701M1 : AppPageBase
{
    #region =====================[ 변수선언 ]==========================
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

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"]    = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public int IListRefID
    {
        get
        {
            if (ViewState["LIST_REF_ID"] == null)
            {
                ViewState["LIST_REF_ID"] = GetRequestByInt("LIST_REF_ID", 0);
            }

            return (int)ViewState["LIST_REF_ID"];
        }
        set
        {
            ViewState["LIST_REF_ID"] = value;
        }
    }

    public string IisOwner
    {
        get
        {
            if (ViewState["IS_OWNER"] == null)
            {
                ViewState["IS_OWNER"] = GetRequest("IS_OWNER", "N");
            }

            return (string)ViewState["IS_OWNER"];
        }
        set
        {
            ViewState["IS_OWNER"] = value;
        }
    }

    public string IisFeedBack
    {
        get
        {
            if (ViewState["IS_FEEDBACK"] == null)
            {
                ViewState["IS_FEEDBACK"] = GetRequest("IS_FEEDBACK", "N");
            }

            return (string)ViewState["IS_FEEDBACK"];
        }
        set
        {
            ViewState["IS_FEEDBACK"] = value;
        }
    }
    #endregion

    #region =====================[ 초기설정 ]==========================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetButton();
            this.SetKpiInfo();
        }
        else
        { 
            
        }
    }
    #endregion

    #region =====================[ 내부함수 ]==========================
    private void SetInitForm()
    {
        iBtnDelete.Attributes.Add("onclick", "return confirm('삭제하시겠습니까?');");
    }

    public void SetButton()
    {
        if (this.IType == "A")
        {
            this.iBtnSave.Visible     = true;
            this.iBtnModify.Visible   = false;
            this.iBtnDelete.Visible   = false;
            this.iBtnFeedback.Visible = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        { 
            this.iBtnSave.Visible     = false;
            this.iBtnModify.Visible   = true;
            this.iBtnDelete.Visible   = true;
            this.iBtnFeedback.Visible = false;
        }
    }

    /// <summary>
    /// 초기 폼 데이터 설정
    /// </summary>
    private void SetKpiInfo()
    {
        if (this.IEstTermRefID > 0 && this.IKpiRefID > 0)
        {
            Biz_Bsc_Kpi_Info objKPI = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
            Biz_ComDeptInfo objDept = new Biz_ComDeptInfo();
            TermInfos       objEst  = new TermInfos(this.IEstTermRefID);
            lblKpiName.Text         = objKPI.Ikpi_name;
            lblWriterName.Text      = gUserInfo.Emp_Name;
            lblTMCode.Text          = objEst.Estterm_name +"("+this.IYMD+")";

            if (this.IType == "U" && this.IListRefID > 0)
            {
                Biz_Bsc_Communication_List objList = new Biz_Bsc_Communication_List(this.IListRefID);
                txtSubject.Text     = objList.Ititle;
                txtContent.Value    = objList.Idetails;
                ltrContent.Text     = objList.Idetails;
                txtReceiver.Text    = objList.Iarr_receiver_id;
                hdfReceiver.Value   = objList.Iarr_receiver_id;
                lblReadCount.Text   = objList.Iread_count.ToString();
                hAttachNo.Value     = objList.Iattach_no;
                lblCreateDate.Text  = objList.Create_date.ToLongDateString();
                lblWriterName.Text  = objList.Iowner_emp_name;
                chkMailSend.Checked = (objList.Iis_send_mail=="Y") ? true : false;
                chkPublicYN.Checked = (objList.Iis_open_list=="Y") ? true : false;

                int intLoginID     = gUserInfo.Emp_Ref_ID;
                int intRtnRow      = 0;

                // 작성자와 로긴한 사용자가 같을경우 즉, 자기글일경우
                if (intLoginID == objList.Iowner_emp_id)
                {
                    this.IisOwner             = "Y";
                    this.leftLayer.Visible    = false;
                    this.txtContent.Visible   = true;
                    this.iBtnFeedback.Visible = false;
                    this.iBtnDelete.Visible   = true;
                    this.iBtnDownload.Visible = false;
                    this.iBtnUpload.Visible   = true;
                }
                else
                { 
                    this.IisOwner             = "N";
                    this.leftLayer.Visible    = true;
                    this.txtContent.Visible   = false;
                    this.iBtnFeedback.Visible = true;
                    this.iBtnModify.Visible   = false;
                    this.iBtnFindEmp.Visible  = false;
                    this.iBtnDelete.Visible   = false;
                    this.iBtnDownload.Visible = (objList.Iattach_no.Trim()=="") ? false : true;
                    this.iBtnUpload.Visible   = false;
                    this.chkPublicYN.Enabled  = false;
                    this.chkMailSend.Enabled  = false;

                    intRtnRow = objList.AddClickCount(this.IListRefID, intLoginID);

                    Biz_Bsc_Communication_User objUser = new Biz_Bsc_Communication_User(this.IListRefID, intLoginID);
                    if (objUser.Iread_yn == "N")
                    {
                        intRtnRow = objUser.UpdateData(this.IListRefID, intLoginID, "Y", intLoginID);
                    }
                }
            }
            else if (this.IType == "A")
            {
                this.leftLayer.Visible    = false;
                this.txtContent.Visible   = true;
                this.iBtnDownload.Visible = false;
                this.iBtnUpload.Visible   = true;
            }
            else
            { 
                this.leftLayer.Visible  = true;
                this.txtContent.Visible = false;
            }
        }

    }

    /// <summary>
    /// 게시물 저장/삭제/수정
    /// </summary>
    /// <returns></returns>
    private int TxrCommnunication()
    {
        Biz_Bsc_Communication_List objBSC = new Biz_Bsc_Communication_List();
        Biz_Bsc_Communication_User objUsr = new Biz_Bsc_Communication_User();

        objBSC.Ilist_ref_id     = this.IListRefID;
        objBSC.Icategory_code   = "BO";
        objBSC.Iparent_list_id  = 0;
        objBSC.Iestterm_ref_id  = this.IEstTermRefID;
        objBSC.Iymd             = this.IYMD;
        objBSC.Ikpi_ref_id      = this.IKpiRefID;
        objBSC.Ititle           = txtSubject.Text;
        objBSC.Idetails         = txtContent.Value;
        objBSC.Iread_count      = (PageUtility.IsAllNumber(lblReadCount.Text)) ? Convert.ToInt32(lblReadCount.Text) : 0;
        objBSC.Iattach_no       = hAttachNo.Value;
        objBSC.Iowner_emp_id    = gUserInfo.Emp_Ref_ID;
        objBSC.Iarr_receiver_id = hdfReceiver.Value;
        objBSC.Iis_send_mail    = (chkMailSend.Checked) ? "Y" : "N";
        objBSC.Iis_open_list    = (chkPublicYN.Checked) ? "Y" : "N";

        int intRtn = 0;
        if (this.IType == "A")
        {
            intRtn = objBSC.InsertData
                     ( objBSC.Icategory_code
                     , (this.IisFeedBack == "Y" ? this.IListRefID : 0)
                     , objBSC.Iestterm_ref_id
                     , objBSC.Iymd
                     , objBSC.Ikpi_ref_id
                     , objBSC.Ititle
                     , objBSC.Idetails
                     , objBSC.Iread_count
                     , objBSC.Iattach_no
                     , objBSC.Iarr_receiver_id
                     , objBSC.Iis_send_mail
                     , objBSC.Iis_open_list
                     , objBSC.Iowner_emp_id);

            if (objBSC.Transaction_Result == "Y")
            {
                this.IListRefID = objBSC.Ilist_ref_id;
                intRtn = objUsr.InsertCommunicationAll(this.IListRefID, objBSC.Iowner_emp_id, this.getReceiverTable());
                this.IType = "U";
                this.SetButton();

                if (intRtn > 0 && chkMailSend.Checked)
                { 
                    bool blnRtn = this.SendMailToReceiver(objUsr);
                    if (!blnRtn)
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장이 되었으나 메일을 송부하지 못했습니다.",false);
                    }
                }
            }
        }
        else if (this.IType == "U")
        { 
            intRtn = objBSC.UpdateData
                     ( objBSC.Ilist_ref_id
                     , objBSC.Icategory_code
                     , objBSC.Iparent_list_id
                     , objBSC.Iestterm_ref_id
                     , objBSC.Iymd
                     , objBSC.Ikpi_ref_id
                     , objBSC.Ititle
                     , objBSC.Idetails
                     , objBSC.Iread_count
                     , objBSC.Iattach_no
                     , objBSC.Iarr_receiver_id
                     , objBSC.Iis_send_mail
                     , objBSC.Iis_open_list
                     , objBSC.Iowner_emp_id);

            if (objBSC.Transaction_Result == "Y")
            {
                intRtn = objUsr.InsertCommunicationAll(this.IListRefID, objBSC.Iowner_emp_id, this.getReceiverTable());
            }
        }
        else if (this.IType == "D")
        {
            intRtn = objBSC.DeleteData(this.IListRefID, objBSC.Iowner_emp_id);
            if (objBSC.Transaction_Result == "N")
            {
                this.IType = "U";
            }
            else
            { 
                intRtn = objUsr.DeleteDataAll(this.IListRefID, objBSC.Iowner_emp_id);
            }
        }

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        return intRtn;
    }

    /// <summary>
    /// 수신자 리스트
    /// </summary>
    /// <returns></returns>
    private DataTable getReceiverTable()
    { 
        string[] arr_receiver = hdfReceiver.Value.Split(';');

        DataTable dtRcv = new DataTable("COMMUNICATION_USER");
        dtRcv.Columns.Add("TO_EMP_ID"  , typeof(int));

        DataRow drRcv = null;
        for (int i = 0; i < arr_receiver.Length; i++)
        {
            drRcv = dtRcv.NewRow();
            drRcv["TO_EMP_ID"]   = Convert.ToInt32(arr_receiver[i].Substring(0, arr_receiver[i].IndexOf('(')));

            dtRcv.Rows.Add(drRcv);
        }

        return dtRcv;
    }

    /// <summary>
    /// 메일보내기
    /// </summary>
    /// <param name="iobjUser"></param>
    /// <returns></returns>
    private bool SendMailToReceiver(Biz_Bsc_Communication_User iobjUser)
    {
        DataSet rDs = iobjUser.GetAllList(this.IListRefID);

        int    intRow        = rDs.Tables[0].Rows.Count;
        string strMailTo     = "";
        string strTitle      = "[BSC Comment 도착 알림메일]";
        string strBody       = "새로운 Comment가 ["+ gUserInfo.Emp_Name +"]님으로부터 수신되었습니다. 확인하시기 바랍니다.";
        string strMailFrom   = gUserInfo.Emp_EMail.Trim(); //System.Configuration.ConfigurationManager.AppSettings["Mail.From"].ToString();
        string strMailServer = System.Configuration.ConfigurationManager.AppSettings["Mail.SMTP"].ToString();
        string strMailUrl    = System.Configuration.ConfigurationManager.AppSettings["Mail.Url"].ToString();


        for (int i = 0; i < intRow; i++)
        {
            strMailTo = rDs.Tables[0].Rows[i]["EMP_EMAIL"].ToString();
            try
            {
                SendMail(strMailFrom, strMailTo, strTitle, strBody, strMailUrl, strMailServer);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Form Validation Check
    /// </summary>
    /// <returns></returns>
    public bool ValidateForm()
    {
        if (this.txtSubject.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("제목을 입력해주십시오", false);
            return false;
        }
        else if (this.txtContent.Value.Trim() == "")
        { 
            ltrScript.Text = JSHelper.GetAlertScript("내용을 입력해 주십시오", false);
            return false;
        }
        else if (this.hdfReceiver.Value.Trim() == "")
        { 
            ltrScript.Text = JSHelper.GetAlertScript("수신자가 지정되지 않았습니다.", false);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Feedback Button 설정
    /// </summary>
    private void SetFeedbackForm()
    {
        Biz_Bsc_Communication_List objList = new Biz_Bsc_Communication_List(this.IListRefID);
        string strRcv = objList.Iowner_emp_id.ToString() +"("+ objList.Iowner_emp_name + ")";
        this.leftLayer.Visible    = false;
        this.txtContent.Visible   = true;
        this.txtSubject.Text      = "Re:";
        this.lblWriterName.Text   = gUserInfo.Emp_Name;
        this.iBtnFeedback.Visible = false;
        this.iBtnSave.Visible     = true;
        this.txtReceiver.Text     = strRcv;
        this.hdfReceiver.Value    = strRcv;
        this.txtContent.Value     = "";
        this.IisFeedBack          = "Y";
        this.chkMailSend.Enabled  = true;
        this.chkPublicYN.Enabled  = true;
        this.IType                = "A";

        this.hAttachNo.Value      = "";
        iBtnUpload.Visible        = true;
        iBtnDownload.Visible      = false;
    }

    #endregion
    
    #region =====================[ 이 벤 트 ]==========================
    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (ValidateForm())
        {
            int intRtn = this.TxrCommnunication();
        }
    }
    protected void iBtnModify_Click(object sender, ImageClickEventArgs e)
    {
        if (ValidateForm())
        {
            int intRtn = this.TxrCommnunication();
        }
    }
    protected void iBtnFeedback_Click(object sender, ImageClickEventArgs e)
    {
        if (this.IListRefID < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("게시물 정보를 알수 없습니다.", false);
            return;
        }
        else
        {
            this.SetFeedbackForm();
        }
    }
    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        if (this.IListRefID < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("게시물 정보를 알수 없습니다.", false);
            return;
        }
        else
        {
            this.IType = "D";
            int intRtn = this.TxrCommnunication();
        }
    }
    #endregion
}
