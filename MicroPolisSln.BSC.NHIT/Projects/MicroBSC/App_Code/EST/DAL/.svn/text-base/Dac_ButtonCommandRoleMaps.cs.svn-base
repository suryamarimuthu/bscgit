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
    public class Dac_ButtonCommandRoleMaps : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int role_ref_id
                        , string command_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_BUTTON_COMMAND_ROLE_MAP
	                            SET	 UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	ROLE_REF_ID		= @ROLE_REF_ID
		                            AND	COMMAND_NAME	= @COMMAND_NAME";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = role_ref_id;
	        paramArray[1] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar);
	        paramArray[1].Value = command_name;
	        paramArray[2] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[2].Value = update_date;
	        paramArray[3] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[3].Value = update_user;
         
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
         
		/// <summary>
		/// 개인 성과평가 관리-평가시스템 관리-업무버튼 권한설정 메뉴.
		/// 권하명- 평가사용 버튼 리스트 정보
		/// </summary>
		/// <param name="role_ref_id"></param>
		/// <param name="command_name"></param>
		/// <returns></returns>
        public DataSet Select( int role_ref_id, string command_name)
        {
            string query = @"SELECT	 ROLE_REF_ID
		                            ,COMMAND_NAME
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_BUTTON_COMMAND_ROLE_MAP 
		                            WHERE	(ROLE_REF_ID	= @ROLE_REF_ID	OR @ROLE_REF_ID		= 0)
			                            AND	(COMMAND_NAME	= @COMMAND_NAME OR @COMMAND_NAME	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = role_ref_id;
	        paramArray[1] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar);
	        paramArray[1].Value = command_name;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "BUTTONCOMMANDROLEMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectByEmpID( int emp_ref_id, int role_ref_id, string command_name, string biz_type)
        {
            string query = @"SELECT   CER.EMP_REF_ID
		                            , BCR.ROLE_REF_ID
		                            , BCI.COMMAND_NAME
		                            , BCI.BIZ_TYPE
		                            , BCI.BUTTON_NAME
		                            , BCI.SORT_ORDER
	                            FROM     COM_EMP_ROLE_REL			 CER
		                            JOIN EST_BUTTON_COMMAND_ROLE_MAP BCR ON (CER.ROLE_REF_ID  = BCR.ROLE_REF_ID)
		                            JOIN EST_BUTTON_COMMAND_INFO	 BCI ON (BCR.COMMAND_NAME = BCI.COMMAND_NAME)
	                            WHERE   (CER.EMP_REF_ID     = @EMP_REF_ID   OR @EMP_REF_ID   = 0)
		                            AND (BCR.ROLE_REF_ID    = @ROLE_REF_ID  OR @ROLE_REF_ID  = 0)
		                            AND (BCI.COMMAND_NAME   = @COMMAND_NAME OR @COMMAND_NAME     =''    )
		                            AND (BCI.BIZ_TYPE       = @BIZ_TYPE     OR @BIZ_TYPE         =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
            paramArray[0] 		= CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = emp_ref_id;
	        paramArray[1] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = role_ref_id;
	        paramArray[2] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar);
	        paramArray[2].Value = command_name;
            paramArray[3] 		= CreateDataParameter("@BIZ_TYPE", SqlDbType.NVarChar);
	        paramArray[3].Value = biz_type;
         
	        DataSet ds = DbAgentObj.FillDataSet(query , "BUTTONCOMMANDROLEMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int role_ref_id
                        , string command_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_BUTTON_COMMAND_ROLE_MAP(ROLE_REF_ID
										                            ,COMMAND_NAME
										                            ,CREATE_DATE
										                            ,CREATE_USER
										                            ,UPDATE_DATE
										                            ,UPDATE_USER
										                            )
									                            VALUES	(@ROLE_REF_ID
										                            ,@COMMAND_NAME
										                            ,@CREATE_DATE
										                            ,@CREATE_USER
										                            ,NULL
										                            ,NULL
										                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = role_ref_id;
	        paramArray[1] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar);
	        paramArray[1].Value = command_name;
	        paramArray[2] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[2].Value = create_date;
	        paramArray[3] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[3].Value = create_user;
         
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
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , int role_ref_id
                        , string command_name)
        {
            string query = @"DELETE	EST_BUTTON_COMMAND_ROLE_MAP
	                            WHERE	(ROLE_REF_ID	= @ROLE_REF_ID	OR @ROLE_REF_ID		= 0)
		                            AND	(COMMAND_NAME	= @COMMAND_NAME OR @COMMAND_NAME	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);
	        paramArray[0].Value = role_ref_id;
	        paramArray[1] 		= CreateDataParameter("@COMMAND_NAME", SqlDbType.NVarChar);
	        paramArray[1].Value = command_name;
         
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
