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
using MicroBSC.BSC.Biz;

public partial class ctl_ctl4901 : AppPageBase
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

    private const string CS_FILE_SAVE_INFO = "Ctl.UploadImages.SIGNAL";
    private int MaxSeq = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }



    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        MaxSeq = GetRequestByInt("COUNT") + 1;
    }

    private void InitControlValue()
    {
        GetSequenceBind(MaxSeq);
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {

    }

    private void SetPostBack()
    {

    }
    private void SetAllTimeBottom()
    {
    }
    #endregion

    #region 내부함수

    private void GetSequenceBind(int MaxSeq)
    {
        for (int i = MaxSeq; i >= 1; i--)
        {
            ListItem li = new ListItem();

            li.Text = i.ToString();
            li.Value = i.ToString();

            ddlSequence.Items.Add(li);
        }
    }

    /// <summary>
    /// IsMandatory
    ///     : 필수값 확인
    /// </summary>
    /// <returns></returns>
    private bool IsMandatory(out string sErrMsg)
    {
        bool bRet = true;
        sErrMsg = "";

        // THRESHOLD 영문명
        if (GetValue(txtThresholdEName.Text) == "")
        {
            sErrMsg = string.Format(
                                    "alert('{0}');"
                                  + "gfSetFocus('{1}')"
                                  , "[영문명]을 입력하십시요!"
                                  , "txtThresholdEName"
                                   );
            bRet = false;
        }
        // THRESHOLD 한글명
        else if (GetValue(txtThresholdKName.Text) == "")
        {
            sErrMsg = string.Format(
                                    "alert('{0}');"
                                  + "gfSetFocus('{1}')"
                                  , "[한글명]을 입력하십시요!"
                                  , "txtThresholdKName"
                                   );
            bRet = false;
        }
        // 이미지파일
        else if (GetValue(fileUpload.Value) != "")
        {
            if (
                GetValue(fileUpload.Value).Substring(GetValue(fileUpload.Value).LastIndexOf(".") + 1).ToUpper() != "GIF" &&
                GetValue(fileUpload.Value).Substring(GetValue(fileUpload.Value).LastIndexOf(".") + 1).ToUpper() != "JPG"
               )
            {
                sErrMsg = string.Format(
                                        "alert('{0}');"
                                      + "gfSetFocus('{1}')"
                                      , "[GIF, JPG] 형태의 파일만 업로드 가능합니다!"
                                      , "fileUpload"
                                       );

                bRet = false;
            }
        }


        return bRet;
    }

    private void AddThresholdCode()
    {

        string sErrMsg = "";
        if (!IsMandatory(out sErrMsg))
        {
            PageUtility.ExecuteScript(sErrMsg);
            return;
        }

        string sFileName = "";
        if (GetValue(fileUpload.Value) != "")
        {
            sFileName = Utils.FileExtensionValidator(fileUpload.PostedFile) == true ? sFileName = MicroBSC.Common.Utils.UploadFile(fileUpload.Value, CS_FILE_SAVE_INFO) : sFileName = "";
            //sFileName = MicroBSC.Common.Utils.UploadFile(fileUpload.Value, CS_FILE_SAVE_INFO);

            if (sFileName == "")
            {
                PageUtility.AlertMessage("이미지를 저장하는데 실패하였습니다!\\n\\n관리자에게 문의하십시오");
                return;
            }
        }

        Biz_Bsc_Threshold_Code biz = new Biz_Bsc_Threshold_Code();

        string sThresholdEName  = GetValue(txtThresholdEName.Text);
        string sThresholdKName  = GetValue(txtThresholdKName.Text);
        string sUseYN           = GetValue(rBtnList.SelectedValue);        
        int sSequence           = Convert.ToInt32(GetValue(ddlSequence.SelectedValue));
        int Emp_Ref_ID          = gUserInfo.Emp_Ref_ID;

        //Response.Write(string.Format("{0}||{1}||{2}||{3}||{4}",sThresholdEName, sThresholdKName, sUseYN, sSequence, Emp_Ref_ID));
        int iRet = biz.InsertThresholdCode(sThresholdEName, sThresholdKName, sFileName, sSequence, sUseYN, Emp_Ref_ID);

        string sScript = "";
        if (iRet == 3)
        {
            sScript += "alert('이미 등록된 THRESHOLD 명이 있습니다');";
        }
        else
        {
            if (iRet > 0)
            {
                sScript += "try{alert('등록되었습니다');opener.__doPostBack('"+this.ICCB1+"', '');}catch(e){};gfCloseWindow();";
            }
            else
            {
                sScript += "alert('등록되지 않았습니다');";
            }
        }

        PageUtility.ExecuteScript(sScript);
    }

    #endregion

    #region 서버 이벤트 처리 함수
    protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        AddThresholdCode();
    }
    #endregion

}
