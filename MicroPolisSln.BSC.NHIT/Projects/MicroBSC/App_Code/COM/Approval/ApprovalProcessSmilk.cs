using System;
using System.Collections.Generic;
using System.Web;
using MicroBSC.Data;
using MicroBSC.Biz.Common.Biz;
using System.Collections.Specialized;
using System.Net;
using System.Data;
using MicroBSC.RolesBasedAthentication;

namespace BSC.Approval
{
    /// <summary>
    /// Summary description for ApprovalProcessSmilk
    /// </summary>
    public class ApprovalProcessSmilk : DbAgentBase, IApprovalProcess
    {
        private const String LEGACYTYPE = "SMILK_BSC";
        private const String APPFORM    = "HTMLF07";
        private const String APPSTATUS = "AUTO";
        private const String SERVERADDR = "http://210.126.128.114/iris_smilk/ERPservice.jsp";

        private String legacyKey;
        private String legacyType;
        private String appForm;
        private String userId;
        private String makeTime;
        private String appTitle;
        private String bodyInfo;
        private String appLine;
        private String esttermRefId;
        private String kpiRefId;
        private String esttermYmd;
        private String appReqDate;
        private String appSeq;
        private String userCode;
        private String appRefId;
        private String appVersion;

        private String bizType;
        private HttpContext context;

        public ApprovalProcessSmilk(HttpContext context)
        {
            this.context = context;

            this.bizType = context.Request.Params.Get("BIZ_TYPE");
            this.legacyKey = "";
            this.legacyType = LEGACYTYPE;
            this.appForm = APPFORM;
            this.userId = context.Request.Params.Get("DRAFT_EMP_ID");
            this.makeTime = System.DateTime.Today.ToString("yyyyMMddhhmmss");
            this.appTitle = Biz_Com_Approval_Info.GetDraftTitle(this.bizType); ;
            this.bodyInfo = "";
            this.appLine = "";
            this.esttermRefId = context.Request.Params.Get("ESTTERM_REF_ID");
            this.kpiRefId = context.Request.Params.Get("KPI_REF_ID");
            this.esttermYmd = context.Request.Params.Get("YMD");
            
            Users userInfo = new Users(int.Parse(this.userId));
            this.userCode = userInfo.Emp_Code;

            this.appRefId = context.Request.Params.Get("APP_REF_ID");
            if (this.appRefId == "" || this.appRefId == null)
            {
                this.appRefId = "NULL";
            }

            Biz_Com_Approval_Line_Base objBase = new Biz_Com_Approval_Line_Base();
            DataSet dtBase = objBase.GetBaseAppLine(this.bizType, int.Parse(this.userId));

            if (dtBase.Tables.Count > 0)
            {
                dtBase.Tables[0].DefaultView.Sort = "SORT_ORDER DESC";

                for (int i = 0; i < dtBase.Tables[0].Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        appLine = appLine + ",";
                    }
                    appLine = appLine + "A";
                    appLine = appLine + "|" + dtBase.Tables[0].DefaultView[i]["EMP_CODE"].ToString();
                    appLine = appLine + "|" + dtBase.Tables[0].DefaultView[i]["DEPT_CODE"].ToString();
                }
            }
        }

        #region IApprovalProcess 멤버

        /**
         * 결재상신요청 화면 호출
         */
        void IApprovalProcess.CallApprovalView()
        {
            /* 서울우유의 결재요청 프로세스
             * 1. 결재화면 스트림 생성
             * 2. I/F 테이블 생성
             * 3. 결재화면 스트림을 I/F 테이블에 저장
             * 4. 결재화면 호출
             */
            long appSeq = 0;
            bool successFlag = false;

            bodyInfo = Biz_Com_Approval_Info.GetHtmlSource(this.GetQueryString());
            int startPos = bodyInfo.IndexOf("{^0^}") + 5;
            int endPos = bodyInfo.LastIndexOf("{^0^}");
            
            bodyInfo = bodyInfo.Substring(startPos, endPos - startPos);
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();
            
            try
            {
                String queryLegacyKey = "SELECT MAX(APPSEQ) FROM t_applegacy4erp"
                                        + " WHERE APPREQDATE = '" + makeTime.Substring(0, 8) + "'";

                object maxSeq = this.DbAgentObj.ExecuteScalar(conn, trx, queryLegacyKey, null, CommandType.Text);

                if (maxSeq == System.DBNull.Value || maxSeq == null)
                {
                    appSeq = appSeq + 1;
                    this.legacyKey = this.bizType + makeTime.Substring(0, 8) + appSeq.ToString().PadLeft(6, '0');
                }
                else
                {
                    appSeq = long.Parse((((decimal)maxSeq) + 1).ToString());

                    this.legacyKey = this.bizType + makeTime.Substring(0, 8) + appSeq.ToString().PadLeft(6, '0');
                }

                String queryString = "INSERT INTO t_applegacy4erp"
                                    + " (LEGACYKEY, LEGACYTYPE, APPFORM, USERID, MAKETIME, TITLE, APPLINE, ESTTERMREFID, KPIREFID, ESTTERMYMD, APPREQDATE, APPSEQ, APPREFID, USERREFID)"
                                    + " VALUES"
                                    + " ('" + this.legacyKey + "', '" 
                                            + this.legacyType + "', '" 
                                            + this.appForm + "', '" 
                                            + this.userCode + "', '" 
                                            + this.makeTime + "', '" 
                                            + this.appTitle + "', '" 
                                            + this.appLine + "', '"
                                            + this.esttermRefId + "', '"
                                            + this.kpiRefId + "', '" 
                                            + this.esttermYmd + "', '"
                                            + this.makeTime.Substring(0, 8) + "', "
                                            + appSeq + ", "
                                            + this.appRefId + ", " 
                                            + this.userId + ")";
                int success;

                success = this.DbAgentObj.ExecuteNonQuery(conn, trx, queryString);

                String queryBody = "INSERT INTO t_applegacybody4erp(LEGACYKEY, BODYCONTENTS) VALUES ('" + this.legacyKey + "', @bodycontent)";
                
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@bodycontent", SqlDbType.Text);
                param.Value = bodyInfo;

                success = this.DbAgentObj.ExecuteNonQuery(conn, trx, queryBody, new System.Data.SqlClient.SqlParameter[] { param });

                trx.Commit();
                successFlag = true;
            }
            catch (Exception ex)
            {
                trx.Rollback();
            }


            if (successFlag == true)
            {
                context.Response.Redirect(SERVERADDR + "?id=" + this.userCode 
                                                     + "&legacykey=" + this.legacyKey 
                                                     + "&reqtime=" + this.makeTime 
                                                     + "&ifname=SMILK_BSC");
            }
            else
            {
                context.Response.Write("Error !!!!");
            }
        }

        /**
         * 결재상신 처리
         */
        void IApprovalProcess.ProcessApprovalDraft()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// Query String을 파싱하여 결재원문 호출할 URL 생성
        /// </summary>
        /// <returns></returns>
        public string GetQueryString()
        {
            int i, j;
            NameValueCollection colReq;

            colReq = context.Request.QueryString;

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
            strPath = Biz_Com_Approval_Info.GetDraftPagePath(context.Request.Params.Get("BIZ_TYPE"));
            string strVPath = context.Request.ApplicationPath;
            string strSHost = context.Request.Url.Host;
            string strSPort = context.Request.Url.Port.ToString();
            string strProto = context.Request.Url.Scheme;

            strVPath = (strVPath == "/") ? "" : strVPath;

            strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath + strPath + "?" + strParam.Substring(1, strParam.Length - 1);

            return strFullPath;
        }
    }
}
