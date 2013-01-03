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

using MicroBSC.Biz.BSC.Biz;

public partial class ctl_ctl4101 : AppPageBase
{
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
            string sType = TypeUtility.GetNumString(GetRequest("TYPE"));

            if (sType != "")
            {
                lblType.Text = sType + " 단계";
            }
            else
            {
                PageUtility.ExecuteScript("alert('등록하기 위한 필수값을 알 수 없습니다!\n\n다시 시도해 주십시요!');gfCloseWindow();");
            }
        }

        private void InitControlValue()
        {
            
        }

        private void InitControlEvent()
        {
            txtMinValue.Attributes["onkeydown"] = "return gfChkInputNum(-1, 2)";
            txtMinValue.Style["text-align"] = "right";
            txtPoint.Attributes["onkeydown"] = "return gfChkInputNum(-1, 2)";
            txtPoint.Style["text-align"] = "right";
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
        /// <summary>
        /// IsMandatory
        ///     : 필수값 확인
        /// </summary>
        /// <returns></returns>
        private bool IsMandatory(out string sErrMsg)
        {
            bool bRet = true;
            sErrMsg = "";

            // 저장을 위한 타입
            if (TypeUtility.GetNumString(GetRequest("TYPE")) == "")
            {
                sErrMsg = string.Format(
                                        "alert('{0}');"
                                      , "등록하기 위한 필수값을 알 수 없습니다!"
                                       );
                bRet = false;
            }
            // THRESHOLD명
            else if (GetValue(txtThresholdName.Text) == "")
            {
                sErrMsg = string.Format(
                                        "alert('{0}');"
                                      + "gfSetFocus('{1}')"
                                      , "[THRESHOLD 명]을 입력하십시요!"
                                      , "txtThresholdName"
                                       );
                bRet = false;
            }
            // 최저 수치
            else if (TypeUtility.GetNumString(txtMinValue.Text) == "")
            {
                sErrMsg = string.Format(
                                        "alert('{0}');"
                                      + "gfSetFocus('{1}')"
                                      , "[최저 수치]를 입력하십시요!"
                                      , "txtMinValue"
                                       );
                bRet = false;
            }
            // 표시 색상
            else if (GetValue(txtColor.Text).Length != 7)
            {
                sErrMsg = string.Format(
                                        "alert('{0}');"
                                      + "gfSetFocus('{1}')"
                                      , "[표시 색상]을 입력하십시요!"
                                      , "txtColor"
                                       );
                bRet = false;
            }
            // 평가 점수
            else if (TypeUtility.GetNumString(txtPoint.Text) == "")
            {
                sErrMsg = string.Format(
                                        "alert('{0}');"
                                      + "gfSetFocus('{1}')"
                                      , "[평가 점수]를 입력하십시요!"
                                      , "txtPoint"
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

        private void AddThreshold()
        {
            string sScript = string.Empty;
            if (Utils.FileExtensionValidator(fileUpload.PostedFile))
            {
                string sErrMsg = "";
                if (!IsMandatory(out sErrMsg))
                {
                    PageUtility.ExecuteScript(sErrMsg);
                    return;
                }

                string sFileName = "";
                sFileName = MicroBSC.Common.Utils.UploadFile(fileUpload.Value, "Ctl.UploadImages.CTL4100");

                if (sFileName == "")
                {
                    PageUtility.AlertMessage("이미지를 저장하는데 실패하였습니다!\n\n관리자에게 문의하십시오!");
                    return;
                }

                Biz_ctl_ctl4100 biz = new Biz_ctl_ctl4100();

                string sType = TypeUtility.GetNumString(GetRequest("TYPE"));
                string sThresholdName = GetValue(txtThresholdName.Text);
                string sMinValue = GetValue(txtMinValue.Text);
                string sColor = GetValue(txtColor.Text);
                string sPoint = GetValue(txtPoint.Text);

                int iRet = biz.AddThreshold(sType, sThresholdName, sMinValue, sColor, sFileName, sPoint);
                sScript = string.Format("alert('[{0}]건이 등록되었습니다!');", iRet);

                if (iRet > 0)
                {
                    sScript += "try{opener.__doPostBack('lbReload', '');}catch(e){};gfCloseWindow();";
                }
            }
            else
            {
                sScript = "alert('유효하지 않은 파일입니다.');";
            }
            PageUtility.ExecuteScript(sScript);
        }
        
    #endregion

    #region 서버 이벤트 처리 함수
        protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AddThreshold();
        }
    #endregion
    
}
