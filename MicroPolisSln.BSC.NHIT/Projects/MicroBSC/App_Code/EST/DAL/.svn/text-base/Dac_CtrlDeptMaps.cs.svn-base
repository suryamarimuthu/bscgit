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
    public class Dac_CtrlDeptMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string ctrl_id
                        , int dept_ref_id
                        , DateTime update_date
                        , int update_user)
        {
            string quey = @"UPDATE	EST_CTRL_DEPT_MAP
	                            SET	 UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	CTRL_ID			= @CTRL_ID
		                            AND	DEPT_REF_ID     = @DEPT_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = dept_ref_id;
	        paramArray[2] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[2].Value = update_date;
	        paramArray[3] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[3].Value = update_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, quey, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public DataSet Select( string ctrl_id, int dept_ref_id)
        {
            string query = @"SELECT	 EDM.CTRL_ID
		                            ,EDM.DEPT_REF_ID
                                    ,EDI.DEPT_NAME
		                            ,EDM.CREATE_DATE
		                            ,EDM.CREATE_USER
		                            ,EDM.UPDATE_DATE
		                            ,EDM.UPDATE_USER
	                            FROM	 EST_CTRL_DEPT_MAP      EDM
                                    JOIN COM_DEPT_INFO          EDI ON (EDM.DEPT_REF_ID = EDI.DEPT_REF_ID)
	                            WHERE	(EDM.CTRL_ID			= @CTRL_ID          OR @CTRL_ID             =''    )
		                            AND	(EDM.DEPT_REF_ID        = @DEPT_REF_ID      OR @DEPT_REF_ID     = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = dept_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "CTRLESTDEPTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string ctrl_id
                        , int comp_id
                        , int dept_ref_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO	EST_CTRL_DEPT_MAP(CTRL_ID
                                                            ,COMP_ID
							                                ,DEPT_REF_ID
							                                ,CREATE_DATE
							                                ,CREATE_USER
							                                ,UPDATE_DATE
							                                ,UPDATE_USER
							                                )
						                                VALUES	(@CTRL_ID
                                                            ,@COMP_ID
							                                ,@DEPT_REF_ID
							                                ,@CREATE_DATE
							                                ,@CREATE_USER
							                                ,NULL
							                                ,NULL
							                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
            paramArray[1] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[1].Value = comp_id;
	        paramArray[2] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = dept_ref_id;
	        paramArray[3] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[3].Value = create_date;
	        paramArray[4] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[4].Value = create_user;
         
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
                        , string ctrl_id
                        , int dept_ref_id)
        {
            string query = @"DELETE	EST_CTRL_DEPT_MAP
	                            WHERE	(CTRL_ID		= @CTRL_ID          OR @CTRL_ID             =''    )
		                            AND	(DEPT_REF_ID    = @DEPT_REF_ID      OR @DEPT_REF_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[1].Value = dept_ref_id;
         
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
