using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;

using MicroBSC.Biz.Common.Dac;

namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_App_Code_PageUtility에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_App_Code_PageUtility Biz 클래스
    /// Class 내용		: PageUtility Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.22
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_App_Code_PageUtility
    {
        public string[,] GetSplit(string sStr)
        {
            return GetSplit(sStr, 1);
        }

        public string[,] GetSplit(string sStr, int iTerm)
        {
            return GetSplit(sStr, iTerm, ';');
        }

        public string[,] GetSplit(string sStr, int iTerm, string sSep)
        {
            string[] saSep = new string[1];
            saSep[0] = sSep;

            if (sStr == "")
                return new string[0, 0];

            if (sStr.Substring(sStr.Length - sSep.Length, sSep.Length) == sSep)
                sStr = sStr.Substring(0, sStr.Length - sSep.Length);

            string[] saTemp = sStr.Split(saSep, StringSplitOptions.None);
            string[,] saRet = new string[saTemp.Length / iTerm, iTerm];

            int iIndex = 0;

            for (int i = 0; i < saTemp.Length; i += iTerm)
            {
                if ((i + (iTerm - 1)) < saTemp.Length)
                {
                    for (int j = 0; j < iTerm; j++)
                    {
                        saRet[iIndex, j] = saTemp[i + j];
                    }

                    iIndex++;
                }
            }

            return saRet;
        }

        public string[,] GetSplit(string sStr, int iTerm, char cSep)
        {
            if (sStr == "")
                return new string[0, 0];

            if (sStr.Substring(sStr.Length - 1, 1) == cSep.ToString())
                sStr = sStr.Substring(0, sStr.Length - 1);

            string[] saTemp = sStr.Split(cSep);
            string[,] saRet = new string[saTemp.Length / iTerm, iTerm];

            int iIndex = 0;

            for (int i = 0; i < saTemp.Length; i += iTerm)
            {
                if ((i + (iTerm - 1)) < saTemp.Length)
                {
                    for (int j = 0; j < iTerm; j++)
                    {
                        saRet[iIndex, j] = saTemp[i + j];
                    }

                    iIndex++;
                }
            }

            return saRet;
        }

        public void SendMail(string[,] asaInfo, string asFromMail, string asToMail, BSC_SendMailType enType)
        {
            System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
            
            string sSubTitle    = "";
            string sContent     = "";

            sContent = GetMailContent(asaInfo, enType, out sSubTitle);

            mail.From = GetAppConfig("Mail.From");
            mail.To = asToMail;
            mail.Subject = sSubTitle;
            
            mail.Body = sContent;
            mail.BodyFormat = System.Web.Mail.MailFormat.Html;
            mail.BodyEncoding = System.Text.Encoding.Default;
            
            System.Web.Mail.SmtpMail.SmtpServer = GetAppConfig("Mail.SMTP");

            try
            {
                System.Web.Mail.SmtpMail.Send(mail);
            }
            catch{}
            
        }

        public void SendMail(DataTable dtParam, string asFromMail, string asToMail, string sTitle, string asFileName)
        {
            System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();

            string sFilePath = GetAppConfig("Mail.Template") + asFileName;
            string sContent  = "";

            sContent = GetMailContent(asFileName, dtParam);

            mail.From    = asFromMail;
            mail.To      = asToMail;
            mail.Subject = sTitle;

            mail.Body         = sContent;
            mail.BodyFormat   = System.Web.Mail.MailFormat.Html;
            mail.BodyEncoding = System.Text.Encoding.Default;

            System.Web.Mail.SmtpMail.SmtpServer = GetAppConfig("Mail.SMTP");

            try
            {
                System.Web.Mail.SmtpMail.Send(mail);
            }
            catch { }

        }

        public string GetAppConfig(string asSetting)
        {
            string lsRet = "";

            try
            {
                lsRet = ConfigurationManager.AppSettings[asSetting].ToString();
            }
            catch (Exception ex)
            {
                lsRet = "";
            }

            return lsRet;
        }

        /// <summary>
        /// 메일 내용 Parsing
        /// </summary>
        /// <param name="asFileName">메일템플릿파일</param>
        /// <param name="dtParam">치환 파라미터</param>
        /// <returns></returns>
        public string GetMailContent(string asFileName, DataTable dtParam)
        {
            string sRet = "";
            string sFilePath = GetAppConfig("Mail.Template") + asFileName;

            try
            {
                System.IO.StreamReader stream = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath(sFilePath), System.Text.Encoding.Default);
                sRet = stream.ReadToEnd();
                stream.Close();

                int iRow = dtParam.Rows.Count;
                string sKey = "";
                string sVal = "";
                for (int i = 0; i < iRow; i++)
                {
                    sKey = dtParam.Rows[i]["KEY"].ToString();
                    sVal = dtParam.Rows[i]["VAL"].ToString();

                    sRet = sRet.Replace(sKey, sVal);    
                }
            }
            catch { }

            return sRet;
        }

        /// <summary>
        /// GetMailContent
        ///     : 각 메일타입별로 템플릿파일에서 적절하게 단어바꾸어 메일내용 리턴하는 함수
        /// </summary>
        /// <param name="asContent">파일을 읽어온 내용</param>
        /// <param name="asaInfo">내용추출에 필요한 정보들</param>
        /// <param name="enType">처리할 타입</param>
        /// <returns></returns>
        public string GetMailContent(string[,] asaInfo, BSC_SendMailType enType, out string osSubTitle)
        {
            string sFileName = "";
            string sRet = "";

            osSubTitle = "";

            switch (enType)
            {
                case BSC_SendMailType.TYPE_APP_REPORT:      // 상신
                    sFileName = "mailtemp_상신.htm";
                    osSubTitle = "상신하였습니다. 결재확인 바랍니다!";

                    sRet = GetAppReportContent(sFileName, asaInfo);

                    break;
                case BSC_SendMailType.TYPE_APP_APPROVAL:    // 결재
                    sFileName = "mailtemp_결재.htm";
                    osSubTitle = "상신건에 대해 결재처리 되었습니다!";

                    sRet = GetAppApprovalContent(sFileName, asaInfo);

                    break;
                case BSC_SendMailType.TYPE_APP_CANCEL:      // 취소
                    sFileName = "mailtemp_반려.htm";
                    osSubTitle = "상신건에 대해 반려되었습니다. 내용 확인하십시요!";

                    sRet = GetAppCancelContent(sFileName, asaInfo);

                    break;
            }

            return sRet;
        }

        /// <summary>
        /// GetAppReportContent
        ///     : 상신시 적절한 메일내용 리턴
        /// </summary>
        /// <returns></returns>
        public string GetAppReportContent(string asFileName, string[,] asaInfo)
        {
            string sRet = "";
            string sFilePath = GetAppConfig("Mail.Template") + asFileName;

            // [::MAIL_DOMAIN::]
            // [::TO_DAY::]
            // [::KPI_INFO::]
            // [::EMP_NAME::]
            // [::APP_GUBUN::]
            try
            {
                System.IO.StreamReader stream = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath(sFilePath), System.Text.Encoding.Default);
                sRet = stream.ReadToEnd();
                stream.Close();

                sRet = sRet.Replace("[::MAIL_DOMAIN::]", GetAppConfig("Mail.Url"));
                sRet = sRet.Replace("[::TO_DAY::]", System.DateTime.Now.ToString());
                sRet = sRet.Replace("[::KPI_INFO::]", asaInfo[0, 0]);
                sRet = sRet.Replace("[::EMP_NAME::]", asaInfo[1, 0]);

                if (asaInfo[2, 0] == "KPIINF")
                    sRet = sRet.Replace("[::APP_GUBUN::]", "KPI정의서");
                else if (asaInfo[2, 0] == "KPIRST")
                    sRet = sRet.Replace("[::APP_GUBUN::]", "실적 확인");

            }
            catch{}

            return sRet;
        }

        /// <summary>
        /// GetAppReportContent
        ///     : 상신시 적절한 메일내용 리턴
        /// </summary>
        /// <returns></returns>
        public string GetAppApprovalContent(string asFileName, string[,] asaInfo)
        {
            string sRet = "";
            string sFilePath = GetAppConfig("Mail.Template") + asFileName;

            // [::MAIL_DOMAIN::]
            // [::TO_DAY::]
            // [::KPI_INFO::]
            // [::EMP_NAME::]
            // [::APP_GUBUN::]
            try
            {
                System.IO.StreamReader stream = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath(sFilePath), System.Text.Encoding.Default);
                sRet = stream.ReadToEnd();
                stream.Close();

                sRet = sRet.Replace("[::MAIL_DOMAIN::]", GetAppConfig("Mail.Url"));
                sRet = sRet.Replace("[::TO_DAY::]", System.DateTime.Now.ToString());
                sRet = sRet.Replace("[::KPI_INFO::]", asaInfo[0, 0]);
                sRet = sRet.Replace("[::EMP_NAME::]", asaInfo[1, 0]);

                if (asaInfo[2, 0] == "KPIINF")
                    sRet = sRet.Replace("[::APP_GUBUN::]", "KPI정의서");
                else if (asaInfo[2, 0] == "KPIRST")
                    sRet = sRet.Replace("[::APP_GUBUN::]", "실적 확인");
            }
            catch
            {
            }

            return sRet;
        }

        /// <summary>
        /// GetAppReportContent
        ///     : 상신시 적절한 메일내용 리턴
        /// </summary>
        /// <returns></returns>
        public string GetAppCancelContent(string asFileName, string[,] asaInfo)
        {
            string sRet = "";
            string sFilePath = GetAppConfig("Mail.Template") + asFileName;

            // [::MAIL_DOMAIN::]
            // [::TO_DAY::]
            // [::KPI_INFO::]
            // [::EMP_NAME::]
            // [::APP_GUBUN::]
            try
            {
                System.IO.StreamReader stream = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath(sFilePath), System.Text.Encoding.Default);
                sRet = stream.ReadToEnd();
                stream.Close();

                sRet = sRet.Replace("[::MAIL_DOMAIN::]", GetAppConfig("Mail.Url"));
                sRet = sRet.Replace("[::TO_DAY::]", System.DateTime.Now.ToString());
                sRet = sRet.Replace("[::KPI_INFO::]", asaInfo[0, 0]);
                sRet = sRet.Replace("[::EMP_NAME::]", asaInfo[1, 0]);

                if (asaInfo[2, 0] == "KPIINF")
                    sRet = sRet.Replace("[::APP_GUBUN::]", "KPI정의서");
                else if (asaInfo[2, 0] == "KPIRST")
                    sRet = sRet.Replace("[::APP_GUBUN::]", "실적 확인");
            }
            catch
            {
            }

            return sRet;
        }
    }
}
