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
using MicroBSC.Biz.Common;
using MicroBSC.Common;

public partial class _common_ErrorPages_ErrorInfo : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPageLayout(null, phdBottom);

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
            MenuControl1.err = "err";
        }

        private void InitControlValue()
        {
            string sErrTitle    = GetRequest("ERRTITLE");
            string sErrMsg      = GetRequest("ERRMSG").Replace("\r\n", "<br/>").Replace("\n", "<br />");

            if (sErrTitle != "")
                lblErrTitle.Text = sErrTitle;

            if (sErrMsg != "")
                lblErrMsg.Text = sErrMsg;
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
    

    #endregion


    #region 서버 이벤트 처리 함수
    

    #endregion
}
