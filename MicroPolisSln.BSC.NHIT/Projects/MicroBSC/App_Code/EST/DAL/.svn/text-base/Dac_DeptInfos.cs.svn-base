using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_DeptInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int dept_ref_id
                        , int up_dept_id
                        , int dept_level
                        , string dept_name
                        , string dept_code
                        , bool dept_flag
                        , int dept_type
                        , int sort_order
                        , string dept_desc
                        , int update_user
                        , DateTime update_date)
        {
            string query = @"UPDATE	COM_DEPT_INFO
	                            SET	 UP_DEPT_ID		= @UP_DEPT_ID
		                            ,DEPT_LEVEL		= @DEPT_LEVEL
		                            ,DEPT_NAME		= @DEPT_NAME
		                            ,DEPT_CODE		= @DEPT_CODE
		                            ,DEPT_FLAG		= @DEPT_FLAG
		                            ,DEPT_TYPE		= @DEPT_TYPE
		                            ,SORT_ORDER		= @SORT_ORDER
		                            ,DEPT_DESC		= @DEPT_DESC
		                            ,UPDATE_USER	= @UPDATE_USER
		                            ,UPDATE_DATE	= @UPDATE_DATE
	                            WHERE	DEPT_REF_ID = @DEPT_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = dept_ref_id;
	        paramArray[1] 		= CreateDataParameter("@UP_DEPT_ID", SqlDbType.Int);
	        paramArray[1].Value = up_dept_id;
	        paramArray[2] 		= CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
	        paramArray[2].Value = dept_level;
	        paramArray[3] 		= CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar, 100);
	        paramArray[3].Value = dept_name;
	        paramArray[4] 		= CreateDataParameter("@DEPT_CODE", SqlDbType.VarChar, 20);
	        paramArray[4].Value = dept_code;
	        paramArray[5] 		= CreateDataParameter("@DEPT_FLAG", SqlDbType.Bit);
	        paramArray[5].Value = dept_flag;
	        paramArray[6] 		= CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
	        paramArray[6].Value = dept_type;
	        paramArray[7] 		= CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value = sort_order;
	        paramArray[8] 		= CreateDataParameter("@DEPT_DESC", SqlDbType.VarChar, 500);
	        paramArray[8].Value = dept_desc;
	        paramArray[9] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[9].Value = update_user;
	        paramArray[10] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[10].Value= update_date;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public DataSet Select( int dept_ref_id)
        {
            string query = @"SELECT	 DEPT_REF_ID
		                            ,UP_DEPT_ID
		                            ,DEPT_LEVEL
		                            ,DEPT_NAME
		                            ,DEPT_CODE
		                            ,DEPT_FLAG
		                            ,DEPT_TYPE
		                            ,SORT_ORDER
		                            ,DEPT_DESC
		                            ,CREATE_USER
		                            ,CREATE_DATE
		                            ,UPDATE_USER
		                            ,UPDATE_DATE
	                            FROM	COM_DEPT_INFO 
		                            WHERE	(DEPT_REF_ID    = @DEPT_REF_ID OR @DEPT_REF_ID = 0)
                                        AND DEPT_FLAG       = 1
                                        ORDER BY SORT_ORDER";

            string query2 =
@"SELECT  DEPT_REF_ID,
          UP_DEPT_ID,
          DEPT_LEVEL,
          DEPT_NAME,
          DEPT_CODE,
          DEPT_FLAG,
          DEPT_TYPE,
          SORT_ORDER,
          SORT_ORD  
FROM    VIW_COM_DEPT_INFO_BYTREE
WHERE   nvl(UP_DEPT_ID, 0) = 0 or  nvl(UP_DEPT_ID, 0) <> @DEPT_REF_ID 
  AND   (  DEPT_REF_ID  =   @DEPT_REF_ID    OR  @DEPT_REF_ID    =   0  )
  AND   DEPT_FLAG = 1";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, query2), "DEPTINFOGET", null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectComp()
        {
            string query = @"SELECT CDI.DEPT_REF_ID
                                  , CDI.DEPT_NAME
                                FROM     COM_DEPT_INFO		CDI
                                    JOIN COM_DEPT_TYPE_INFO DTI ON (CDI.DEPT_TYPE = DTI.TYPE_REF_ID)
                                        WHERE EST_COMP_YN = 'Y'";

            DataSet ds = DbAgentObj.FillDataSet(query, "COMP", null, null, CommandType.Text);
            return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int dept_ref_id
                        , int up_dept_id
                        , int dept_level
                        , string dept_name
                        , string dept_code
                        , bool dept_flag
                        , int dept_type
                        , int sort_order
                        , string dept_desc
                        , int create_user
                        , DateTime create_date)
        {
            string query = @"INSERT INTO COM_DEPT_INFO(DEPT_REF_ID
		                                            ,UP_DEPT_ID
		                                            ,DEPT_LEVEL
		                                            ,DEPT_NAME
		                                            ,DEPT_CODE
		                                            ,DEPT_FLAG
		                                            ,DEPT_TYPE
		                                            ,SORT_ORDER
		                                            ,DEPT_DESC
		                                            ,CREATE_USER
		                                            ,CREATE_DATE
		                                            ,UPDATE_USER
		                                            ,UPDATE_DATE
		                                            )
	                                            VALUES	(@DEPT_REF_ID
		                                            ,@UP_DEPT_ID
		                                            ,@DEPT_LEVEL
		                                            ,@DEPT_NAME
		                                            ,@DEPT_CODE
		                                            ,@DEPT_FLAG
		                                            ,@DEPT_TYPE
		                                            ,@SORT_ORDER
		                                            ,@DEPT_DESC
		                                            ,@CREATE_USER
		                                            ,@CREATE_DATE
		                                            ,@UPDATE_USER
		                                            ,@UPDATE_DATE
		                                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = dept_ref_id;
	        paramArray[1] 		= CreateDataParameter("@UP_DEPT_ID", SqlDbType.Int);
	        paramArray[1].Value = up_dept_id;
	        paramArray[2] 		= CreateDataParameter("@DEPT_LEVEL", SqlDbType.Int);
	        paramArray[2].Value = dept_level;
	        paramArray[3] 		= CreateDataParameter("@DEPT_NAME", SqlDbType.VarChar, 100);
	        paramArray[3].Value = dept_name;
	        paramArray[4] 		= CreateDataParameter("@DEPT_CODE", SqlDbType.VarChar, 20);
	        paramArray[4].Value = dept_code;
	        paramArray[5] 		= CreateDataParameter("@DEPT_FLAG", SqlDbType.Bit);
	        paramArray[5].Value = dept_flag;
	        paramArray[6] 		= CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
	        paramArray[6].Value = dept_type;
	        paramArray[7] 		= CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value = sort_order;
	        paramArray[8] 		= CreateDataParameter("@DEPT_DESC", SqlDbType.VarChar, 500);
	        paramArray[8].Value = dept_desc;
	        paramArray[9] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[9].Value = create_user;
	        paramArray[10] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[10].Value= create_date;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int dept_ref_id)
        {
            string query = @"DELETE	COM_DEPT_INFO
	                            WHERE	DEPT_REF_ID = @DEPT_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = dept_ref_id;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}