using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MicroBSC.Biz.Common.Biz;
using System.Collections.Specialized;
using BSC.Approval;

namespace BSC
{
    public partial class ApprovalGateway : AppPageBase
    {
        #region ==========================[변수선언]================

        public string IAPP_CCB
        {
            get
            {
                if (ViewState["APP_CCB"] == null)
                {
                    ViewState["APP_CCB"] = GetRequest("APP_CCB", "");
                }

                return (string)ViewState["APP_CCB"];
            }
            set
            {
                ViewState["APP_CCB"] = value;
            }
        }

        /// <summary>
        /// 업무유형
        /// </summary>
        public string IBiz_Type
        {
            get
            {
                if (ViewState["BIZ_TYPE"] == null)
                {
                    ViewState["BIZ_TYPE"] = GetRequest("BIZ_TYPE", "");
                }

                return (string)ViewState["BIZ_TYPE"];
            }
            set
            {
                ViewState["BIZ_TYPE"] = value;
            }
        }

        /// <summary>
        /// 결재상태
        /// </summary>
        public string IApp_Status
        {
            get
            {
                if (ViewState["APP_STATUS"] == null)
                {
                    ViewState["APP_STATUS"] = GetRequest("APP_STATUS", "");
                }
                return (string)ViewState["APP_STATUS"];
            }
            set
            {
                ViewState["APP_STATUS"] = value;
            }
        }

        /// <summary>
        /// 기안상태
        /// </summary>
        public string IDraft_Status
        {
            get
            {
                if (ViewState["DRAFT_STATUS"] == null)
                {
                    ViewState["DRAFT_STATUS"] = GetRequest("DRAFT_STATUS", "");
                }
                return (string)ViewState["DRAFT_STATUS"];
            }
            set
            {
                ViewState["DRAFT_STATUS"] = value;
            }
        }

        public decimal IApp_Ref_Id
        {
            get
            {
                if (ViewState["APP_REF_ID"] == null)
                {
                    ViewState["APP_REF_ID"] = (decimal)GetRequestByInt("APP_REF_ID", 0);
                }

                return (decimal)ViewState["APP_REF_ID"];
            }
            set
            {
                ViewState["APP_REF_ID"] = value;
            }
        }

        public int IVersion_No
        {
            get
            {
                if (ViewState["VERSION_NO"] == null)
                {
                    ViewState["VERSION_NO"] = GetRequestByInt("VERSION_NO", 0);
                }

                return (int)ViewState["VERSION_NO"];
            }
            set
            {
                ViewState["VERSION_NO"] = value;
            }
        }

        public int ILine_Step
        {
            get
            {
                if (ViewState["LINE_STEP"] == null)
                {
                    ViewState["LINE_STEP"] = GetRequestByInt("LINE_STEP", 0);
                }

                return (int)ViewState["LINE_STEP"];
            }
            set
            {
                ViewState["LINE_STEP"] = value;
            }
        }

        public int IDraftEmpID
        {
            get
            {
                if (ViewState["DRAFT_EMP_ID"] == null)
                {
                    ViewState["DRAFT_EMP_ID"] = GetRequestByInt("DRAFT_EMP_ID", 0);
                }

                return (int)ViewState["DRAFT_EMP_ID"];
            }
            set
            {
                ViewState["DRAFT_EMP_ID"] = value;
            }
        }
        #endregion

        #region Define Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            //string strHtml = Server.HtmlDecode(Biz_Com_Approval_Info.GetHtmlSource(this.GetQueryString()));
            //Response.Write(strHtml);

            IApprovalProcess approvalProcess = new ApprovalProcessSmilk(this.Context);
            approvalProcess.CallApprovalView();
        }

        #endregion

        #region Define Custom Method
        /// <summary>
        /// Query String을 파싱하여 결재원문 호출할 URL 생성
        /// </summary>
        /// <returns></returns>
        public string GetQueryString()
        {
            int i, j;
            NameValueCollection colReq;

            colReq = Request.QueryString;

            string strFullPath = "";
            string strPath = "";
            string strParam = "";
            String[] arrKey = colReq.AllKeys;
            for (i = 0; i < arrKey.Length; i++)
            {
                String[] arrVal = colReq.GetValues(arrKey[i]);
                strParam += "&" + arrKey[i] + "=";
                for (j = 0; j < arrVal.Length; j++)
                {
                    strParam += arrVal[j];
                }
            }
            strPath = Biz_Com_Approval_Info.GetDraftPagePath(this.IBiz_Type);
            string strVPath = Request.ApplicationPath;
            string strSHost = Request.Url.Host;
            string strSPort = Request.Url.Port.ToString();
            string strProto = Request.Url.Scheme;

            strVPath = (strVPath == "/") ? "" : strVPath;

            strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath + strPath + "?" + strParam.Substring(1, strParam.Length - 1);

            return strFullPath;
        }
        #endregion
    }
}