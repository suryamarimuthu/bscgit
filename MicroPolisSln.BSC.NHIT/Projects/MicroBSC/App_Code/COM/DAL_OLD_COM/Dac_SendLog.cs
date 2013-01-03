using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class SendLog : DbAgentBase
    {
        public bool LogMaker(int iEstterm_ref_id, int iEmp_ref_id, string sFrom, string sTo, string sSubject, string sContent, int iGidx, string sMailType)
        {
            IDbDataParameter[] paramArray = null;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("	INSERT COM_MAIL_SEND_LOG   		    \n");
            sbQuery.Append("	(                                   \n");
            sbQuery.Append("		ESTTERM_REF_ID,                 \n");
            sbQuery.Append("		EMP_REF_ID,                     \n");
            sbQuery.Append("		MAIL_FROM,                      \n");
            sbQuery.Append("		MAIL_TO,                        \n");
            sbQuery.Append("		MAIL_SUBJECT,                   \n");
            sbQuery.Append("		MAIL_CONTENT,                   \n");
            sbQuery.Append("		GIDX,                           \n");
            sbQuery.Append("		MAIL_TYPE                       \n");
            sbQuery.Append("	)                                   \n");
            sbQuery.Append("	VALUES                              \n");
            sbQuery.Append("	(                                   \n");
            sbQuery.Append("		@ESTTERM_REF_ID,        		\n");
            sbQuery.Append("		@EMP_REF_ID,            		\n");
            sbQuery.Append("		@FROM,                			\n");
            sbQuery.Append("		@TO,                  			\n");
            sbQuery.Append("		@SUBJECT,             			\n");
            sbQuery.Append("		@CONTENT,             			\n");
            sbQuery.Append("		@GIDX,                			\n");
            sbQuery.Append("		@MAILTYPE	            		\n");
            sbQuery.Append("	)                                   \n");

            paramArray          = CreateDataParameters(8);

            paramArray[0]         = CreateDataParameter("@ESTTERM_REF_ID"  , SqlDbType.Int);
            paramArray[1]         = CreateDataParameter("@EMP_REF_ID"      , SqlDbType.Int);
            paramArray[2]         = CreateDataParameter("@FROM"            , SqlDbType.VarChar);
            paramArray[3]         = CreateDataParameter("@TO"              , SqlDbType.VarChar);
            paramArray[4]         = CreateDataParameter("@SUBJECT"         , SqlDbType.VarChar);
            paramArray[5]         = CreateDataParameter("@CONTENT"         , SqlDbType.Text);
            paramArray[6]         = CreateDataParameter("@GIDX"            , SqlDbType.Int);
            paramArray[7]         = CreateDataParameter("@MAILTYPE"        , SqlDbType.Char);

            paramArray[0].Value = iEstterm_ref_id;
            paramArray[1].Value = iEmp_ref_id;
            paramArray[2].Value = sFrom;
            paramArray[3].Value = sTo;
            paramArray[4].Value = sSubject;
            paramArray[5].Value = sContent;
            paramArray[6].Value = iGidx;
            paramArray[7].Value = sMailType;

            int rowaffected = DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
            return (rowaffected > 0) ? true : false;
        }

        public bool LogMaker(string asTermRefID, string asEmpRefID, string asFromMail, string asToMail, string asSubject, string asContent, string asGIdx, string asMailType)
        {
            IDbDataParameter[] paramArray = null;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("	INSERT COM_MAIL_SEND_LOG   		    \n");
            sbQuery.Append("	(                                   \n");
            sbQuery.Append("		ESTTERM_REF_ID,                 \n");
            sbQuery.Append("		EMP_REF_ID,                     \n");
            sbQuery.Append("		MAIL_FROM,                      \n");
            sbQuery.Append("		MAIL_TO,                        \n");
            sbQuery.Append("		MAIL_SUBJECT,                   \n");
            sbQuery.Append("		MAIL_CONTENT,                   \n");
            sbQuery.Append("		GIDX,                           \n");
            sbQuery.Append("		MAIL_TYPE                       \n");
            sbQuery.Append("	)                                   \n");
            sbQuery.Append("	VALUES                              \n");
            sbQuery.Append("	(                                   \n");
            sbQuery.Append("		CONVERT(INT, @ESTTERM_REF_ID),  \n");
            sbQuery.Append("		CONVERT(INT, @EMP_REF_ID),      \n");
            sbQuery.Append("		@FROM,                			\n");
            sbQuery.Append("		@TO,                  			\n");
            sbQuery.Append("		@SUBJECT,             			\n");
            sbQuery.Append("		@CONTENT,             			\n");
            sbQuery.Append("		CONVERT(INT, @GIDX),            \n");
            sbQuery.Append("		@MAILTYPE	            		\n");
            sbQuery.Append("	)                                   \n");

            paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@FROM", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@TO", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@SUBJECT", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@CONTENT", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@GIDX", SqlDbType.VarChar);
            paramArray[7] = CreateDataParameter("@MAILTYPE", SqlDbType.Char);

            paramArray[0].Value = asTermRefID;
            paramArray[1].Value = asEmpRefID;
            paramArray[2].Value = asFromMail;
            paramArray[3].Value = asToMail;
            paramArray[4].Value = asSubject;
            paramArray[5].Value = asContent;
            paramArray[6].Value = asGIdx;
            paramArray[7].Value = asMailType;

            return (DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray)) > 0;
        }

        public bool LogMaker(string asTermRefID, string asEmpRefID, string asFromMail, string asToMail, string asSubject, string asContent, string asMailType)
        {
            return LogMaker(asTermRefID, asEmpRefID, asFromMail, asToMail, asSubject, asContent, "0", asMailType);
        }

        public bool LogMaker(string asTermRefID, string asEmpRefID, string asFromMail, string asToMail, string asSubject, string asContent)
        {
            return LogMaker(asTermRefID, asEmpRefID, asFromMail, asToMail, asSubject, asContent, "0", "K");
        }
    }
}
