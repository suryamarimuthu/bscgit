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
using MicroBSC.Biz.Common;

using MicroBSC.Biz.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;

using System.Collections.Generic;
using System.Text;

using MicroBSC.Data;
using MicroBSC.Common;

public partial class ctl_ctlPassExcel_Upload : AppPageBase
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
        }

        private void InitControlValue()
        {
        }

        private void InitControlEvent()
        {
            iBtnExcelUpload.Attributes.Add("onclick", "return mfCheckFile()");
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
        /// SetPassUpdate
        ///     : 비밀번호 일괄수정
        /// </summary>
        private void SetPassUpdate()
        {
            string sSaveFilePath = AppDomain.CurrentDomain.BaseDirectory + PageUtility.GetAppConfig("Excel.Temp");

            string lsAddFileInfo = "";  // 테이블에 저장될 파일정보
            string lsAddName = "";	    //중복되면 시간을 붙여 파일명으로 만든다.
            string lsFileName = System.IO.Path.GetFileName(hFile.PostedFile.FileName);

            if (Page.IsPostBack == true)
            {
                if (lsFileName == "")
                    return;

                if (lsFileName.Substring(lsFileName.LastIndexOf(".") + 1).ToUpper() != "XLS" || lsFileName.Substring(lsFileName.LastIndexOf(".") + 1).ToUpper() != "XLSX")
                {
                    PageUtility.AlertMessage("엑셀파일만 업로드할 수 있습니다!");
                    return;
                }

                string sGetUpFileName = MicroBSC.Common.Utils.UploadFile(hFile.Value, "Excel.Temp");

                if (sGetUpFileName == "")
                {
                    PageUtility.AlertMessage("업로드할 파일을 선택하십시요!");
                    return;
                }

                Biz_ctl_ctlPassExcel_Upload biz = new Biz_ctl_ctlPassExcel_Upload();
                
                int iRet = biz.UpdateEmpPass(sSaveFilePath + "/" + sGetUpFileName);
                PageUtility.ExecuteScript(
                                            string.Format
                                            (
                                            "alert('[{0}]건을 업데이트 했습니다!');"
                                          + "window.close();"
                                            ,iRet
                                            )
                                         );
            }
        }
    #endregion

    #region 서버 이벤트 처리 함수
        protected void iBtnExcelUpload_Click(object sender, ImageClickEventArgs e)
        {
            if (IsPageRefresh)
            {
                //PageUtility.AlertMessage("페이지를 리플레시 하셨습니다!");
                //return;
            }
            SetPassUpdate();
        }
    #endregion
    
}
