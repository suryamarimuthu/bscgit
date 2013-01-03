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
using MicroBSC.Biz.BSC;
using MicroBSC.RolesBasedAthentication;
using System.IO;

using MicroBSC.Common;

public partial class BSC_BSC0101M1 : AppPageBase
{
    #region ======================= [ Variable, Property ] ===============
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

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

    public int IViewRefID
    {
        get
        {
            if (ViewState["VIEW_REF_ID"] == null)
            {
                ViewState["VIEW_REF_ID"] = GetRequestByInt("VIEW_REF_ID", 0);
            }

            return (int)ViewState["VIEW_REF_ID"];
        }
        set
        {
            ViewState["VIEW_REF_ID"] = value;
        }
    }
    #endregion
    #region ======================= [ Page Load ] ========================
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ExecuteAtTop();
        if (!IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        {

        }
    }

    #endregion
    #region ======================== [ Method ] =========================
    private void ExecuteAtTop()
    {
        ltrScript.Text = "";

    }

    private void NotPostBackSetting()
    {
        this.SetButton();
        this.SetFormData();
    }

    private void PostBackSetting()
    {

    }

    private void ExecuteAtBottom()
    {

    }

    private void InitForm()
    {

    }

    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnReUsed.Visible = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnDelete.Visible = (this.IType == "D") ? false : true;
            iBtnReUsed.Visible = (this.IType == "D") ? true : false;
        }
        else
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnReUsed.Visible = false;
        }
    }

    private void SetFormData()
    {
        if (this.IType != "A")
        {
            MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info(this.IViewRefID);
            this.IViewRefID = objBSC.Iview_ref_id;
            txtVIEW_NAME.Text = objBSC.Iview_name;
            txtVIEW_SEQ.Text = objBSC.Iview_seq.ToString();
            txtVIEW_DESC.Text = objBSC.Iview_desc;
            txtVIEW_ETC.Text = objBSC.Iview_etc;
            hdfImagePath.Value = objBSC.Iview_image_name;

            string virtualPath = "../images/stg/";
            string absolutePath = Server.MapPath(virtualPath);

            if (!Directory.Exists(absolutePath))
            {
                DirectoryInfo objFold = Directory.CreateDirectory(absolutePath);
                absolutePath = objFold.FullName;
            }

            imgPreview.ImageUrl = virtualPath + objBSC.Iview_image_name;
        }
    }

    private bool CheckFormData()
    {
        if (this.IType == "A")
        {
            if (txtVIEW_NAME.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("관점명을 입력해 주십시오", false);
                return false;
            }
            else if (txtVIEW_SEQ.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("정렬순서를 입력해 주십시오", false);
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "U")
        {
            if (txtVIEW_NAME.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("관점명을 입력해 주십시오", false);
                return false;
            }
            else if (txtVIEW_SEQ.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("정렬순서를 입력해 주십시오", false);
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (this.IViewRefID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("관점을 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InsertViewData()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        objBSC.Iview_seq = int.Parse(txtVIEW_SEQ.Text.ToString());
        objBSC.Iview_name = txtVIEW_NAME.Text.Trim();
        objBSC.Iview_desc = txtVIEW_DESC.Text;
        objBSC.Iview_etc = txtVIEW_ETC.Text;
        objBSC.Iview_image_name = (fudViewImage.HasFile) ? fudViewImage.FileName : "";
        objBSC.Create_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.InsertData(objBSC.Iview_seq,
                                       objBSC.Iview_name,
                                       objBSC.Iview_desc,
                                       objBSC.Iview_etc,
                                       objBSC.Iview_image_name,
                                       gUserInfo.Emp_Ref_ID);
        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            this.IViewRefID = objBSC.Iview_ref_id;

            if (fudViewImage.HasFile && fudViewImage.FileName.Trim() != "")
            {
                this.FileUpload(fudViewImage);
            }

            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
        else
        {
            this.IViewRefID = 0;
        }
    }

    private void UpdateViewData()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info(this.IViewRefID);
        objBSC.Iview_ref_id = this.IViewRefID;
        objBSC.Iview_seq = int.Parse(txtVIEW_SEQ.Text.ToString());
        objBSC.Iview_name = txtVIEW_NAME.Text.Trim();
        objBSC.Iview_desc = txtVIEW_DESC.Text;
        objBSC.Iview_etc = txtVIEW_ETC.Text;
        objBSC.Iview_image_name = (fudViewImage.HasFile) ? fudViewImage.FileName : objBSC.Iview_image_name;
        objBSC.Create_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.UpdateData(objBSC.Iview_ref_id,
                                       objBSC.Iview_seq,
                                       objBSC.Iview_name,
                                       objBSC.Iview_desc,
                                       objBSC.Iview_etc,
                                       objBSC.Iview_image_name,
                                       gUserInfo.Emp_Ref_ID);
        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y"
            && fudViewImage.HasFile
            && fudViewImage.FileName.Trim() != "")
        {
            this.FileUpload(fudViewImage);
        }
    }

    private void DeleteViewData()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        objBSC.Iview_ref_id = this.IViewRefID;

        int intRtn = objBSC.DeleteData(objBSC.Iview_ref_id,
                                       "N",
                                       gUserInfo.Emp_Ref_ID);

        if (objBSC.Transaction_Result == "Y")
        {
            this.FileUpload(fudViewImage);
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
        }
        else
        {
            this.IType = "U";
        }
    }

    private void ReUsedViewData()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        objBSC.Iview_ref_id = this.IViewRefID;

        int intRtn = objBSC.ReUsedData(objBSC.Iview_ref_id,
                                       "Y",
                                       gUserInfo.Emp_Ref_ID);

        if (objBSC.Transaction_Result == "Y")
        {
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
        }
        else
        {
            this.IType = "U";
        }
    }

    private void FileUpload(System.Web.UI.WebControls.FileUpload iFile)
    {
        string virtualPath = "../images/stg/";
        string absolutePath = Server.MapPath(virtualPath);
        string fullFilePath = "";

        if (!Directory.Exists(absolutePath))
        {
            DirectoryInfo objFold = Directory.CreateDirectory(absolutePath);
            absolutePath = objFold.FullName;
        }

        if (this.IType == "D")
        {
            fullFilePath = absolutePath + hdfImagePath.Value;
            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }
        }
        else
        {

            fullFilePath = absolutePath + iFile.FileName;
            if (File.Exists(fullFilePath))
            {
                File.SetAttributes(fullFilePath, FileAttributes.Normal);
                File.Delete(fullFilePath);
            }
            iFile.SaveAs(fullFilePath);
        }
    }

    private bool ImageExtensionCheck()
    {
        bool extensionCheck = false;
        string extension = string.Empty;
        string file = fudViewImage.PostedFile.FileName;
        string[] arrFile = file.Split('.');
        if (arrFile.Length > 0)
        {
            extension = arrFile[arrFile.Length - 1].ToString().ToLower();

            if (extension == "jpg") { extensionCheck = true; }
            else if (extension == "gif") { extensionCheck = true; }
            else if (extension == "png") { extensionCheck = true; }
            else if (extension == "bmp") { extensionCheck = true; }
            else if (extension == "tif") { extensionCheck = true; }

        }
        return extensionCheck;
    }

    private bool fileSizeCheck()
    {
        if (fudViewImage.PostedFile.ContentLength > 1048576)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion
    #region =========================[ Server Event ] ===================
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        if (!fileSizeCheck())
        {
            ltrScript.Text = JSHelper.GetAlertScript("파일용량 최대크기는 1MB입니다.");
        }
        else if (!ImageExtensionCheck())
        {
            ltrScript.Text = JSHelper.GetAlertScript("이미지 파일만 가능합니다.");
        }
        else
        {
            this.InsertViewData();
            this.SetFormData();
        }
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (!ImageExtensionCheck())
        {
            ltrScript.Text = JSHelper.GetAlertScript("이미지 파일만 수정 가능합니다.");
        }
        else
        {
            this.UpdateViewData();
            this.SetFormData();
        }
    }
    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteViewData();
        this.SetFormData();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedViewData();
    }
    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }
    #endregion

}
