using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Integration.ETC.Dac
{
    public class Dac_Nhis_Hist_Sd : DbAgentBase
    {
        public Dac_Nhis_Hist_Sd()
        {
        }


        public int Insert_Nhis_Hist_Sd(IDbConnection conn, IDbTransaction trx
                                    , object msg_key
                                    , object callee_no
                                    , object callback_no
                                    , object sms_msg
                                    , object save_time)
        {
            string query = @"
INSERT INTO nhitpms.NHIS_SD
		(
          MSG_KEY
	      , CALLEE_NO
          , CALLBACK_NO
          , SMS_MSG
          , USER_TEXT_01
		)
		VALUES
		(
          nhitpms.NHISSD_SEQ.nextval
	      , @CALLEE_NO
          , @CALLBACK_NO
          , @SMS_MSG
          , 'BSC'
		)
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);


            paramArray[0] = CreateDataParameter("@CALLEE_NO", SqlDbType.NVarChar);
            paramArray[0].Value = callee_no;
            paramArray[1] = CreateDataParameter("@CALLBACK_NO", SqlDbType.NVarChar);
            paramArray[1].Value = callback_no;
            paramArray[2] = CreateDataParameter("@SMS_MSG", SqlDbType.NVarChar);
            paramArray[2].Value = sms_msg;
            

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Select_Max_Msg_Key(IDbConnection conn, IDbTransaction trx)
        {
            string query = @"
SELECT      MAX(MSG_KEY)+1
    FROM    nhitpms.NHIS_SD
";

            object Result = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);

            return DataTypeUtility.GetToInt32(Result);
        }
    }
}
