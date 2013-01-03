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
    public class Dac_RoleInfos : DbAgentBase
    {
	    public int Update(    IDbConnection conn
                            , IDbTransaction trx
                            , int role_ref_id
                            , string role_name
                            , string role_desc
                            , string sys_type
                            , int    sort_order
                            , string delete_enabled_yn)
        {
            string query = @"UPDATE	COM_ROLE_INFO
	                            SET	 ROLE_NAME		= @ROLE_NAME
		                            ,ROLE_DESC		= @ROLE_DESC
                                    ,SYS_TYPE       = @SYS_TYPE
                                    ,SORT_ORDER     = @SORT_ORDER
	                            WHERE	ROLE_REF_ID = @ROLE_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = role_ref_id;
	        paramArray[1] 		= CreateDataParameter("@ROLE_NAME", SqlDbType.VarChar, 50);
	        paramArray[1].Value = role_name;
	        paramArray[2] 		= CreateDataParameter("@ROLE_DESC", SqlDbType.VarChar, 300);
	        paramArray[2].Value = role_desc;
            paramArray[3]       = CreateDataParameter("@SYS_TYPE", SqlDbType.VarChar, 30);
            paramArray[3].Value = sys_type;
            paramArray[4]       = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[4].Value = sort_order;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query , paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
        
		/// <summary>
		/// 개인성과평가-평가 사스템관리-업무버튼권산 설정
		/// 권한명 데이터 리스트
		/// </summary>
		/// <param name="role_ref_id"></param>
		/// <returns></returns>
        public DataSet Select( int role_ref_id)
        {
            string query = @"SELECT	 ROLE_REF_ID
                                    , ROLE_NAME
                                    , ROLE_DESC
                                    , SYS_TYPE
                                    , SORT_ORDER
                                    , DELETE_ENABLED_YN
                                    , CREATE_DATE
                                    , CREATE_USER
                                    , UPDATE_DATE
                                    , UPDATE_USER
	                            FROM	COM_ROLE_INFO 
		                            WHERE	(ROLE_REF_ID = @ROLE_REF_ID OR @ROLE_REF_ID = 0)
                                ORDER BY SORT_ORDER";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = role_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "ROLEINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string role_name
                        , string role_desc
                        , string sys_type
                        , int    sort_order
                        , string delete_enabled_yn)
        {
            string query = @"INSERT INTO COM_ROLE_INFO(  ROLE_NAME
			                                            ,ROLE_DESC
                                                        ,SYS_TYPE
                                                        ,SORT_ORDER
                                                        ,DELETE_ENABLED_YN
			                                            )
		                                            VALUES	(@ROLE_NAME
			                                                ,@ROLE_DESC
                                                            ,@SYS_TYPE
                                                            ,@SORT_ORDER
                                                            ,@DELETE_ENABLED_YN
			                                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@ROLE_NAME", SqlDbType.VarChar, 50);
            paramArray[0].Value = role_name;
            paramArray[1]       = CreateDataParameter("@ROLE_DESC", SqlDbType.VarChar, 300);
            paramArray[1].Value = role_desc;
            paramArray[2]       = CreateDataParameter("@SYS_TYPE", SqlDbType.VarChar, 30);
            paramArray[2].Value = sys_type;
            paramArray[3]       = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[3].Value = sort_order;
            paramArray[4]       = CreateDataParameter("@DELETE_ENABLED_YN", SqlDbType.VarChar, 1);
            paramArray[4].Value = delete_enabled_yn;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query , paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public int Delete(    IDbConnection conn
                            , IDbTransaction trx
                            , int role_ref_id)
        {
            string query = @"DELETE	COM_ROLE_INFO
	                            WHERE ROLE_REF_ID = @ROLE_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = role_ref_id;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query , paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
