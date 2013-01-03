using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class PageTraces : DbAgentBase
    {
        public PageTraces()
        {

        }
        public bool LogPageTrace(int emp_ref_id, string userip, string useragnet, string pagePath)
        {
            string query = @"INSERT INTO COM_PAGE_TRACE (EMP_REF_ID, USERIP, USERAGENT, ACCESSPAGE, ACCESSDATE)
	                            VALUES (@EMP_REF_ID, @USERIP, @USERAGENT, @ACCESSPAGE, GETDATE())";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;
            paramArray[1]               = CreateDataParameter("@USERIP", SqlDbType.VarChar);
            paramArray[1].Value         = userip;
            paramArray[2]               = CreateDataParameter("@USERAGENT", SqlDbType.VarChar);
            paramArray[2].Value         = useragnet;
            paramArray[3]               = CreateDataParameter("@ACCESSPAGE", SqlDbType.VarChar);
            paramArray[3].Value         = pagePath;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
