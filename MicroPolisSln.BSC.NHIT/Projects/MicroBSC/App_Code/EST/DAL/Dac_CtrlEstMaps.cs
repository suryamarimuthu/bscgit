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
    public class Dac_CtrlEstMaps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string ctrl_id
                        , string est_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_CTRL_EST_MAP
	                            SET	 UPDATE_DATE	= @UPDATE_DATE
		                            ,UPDATE_USER	= @UPDATE_USER
	                            WHERE	CTRL_ID		= @CTRL_ID
		                            AND	EST_ID		= @EST_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
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
         
        public DataSet Select( string ctrl_id, string est_id)
        {
            string query = @"SELECT	 CEM.CTRL_ID
                                    ,CEM.COMP_ID
		                            ,CEM.EST_ID
                                    ,EI.EST_NAME
		                            ,CEM.CREATE_DATE
		                            ,CEM.CREATE_USER
		                            ,CEM.UPDATE_DATE
		                            ,CEM.UPDATE_USER
	                            FROM	 EST_CTRL_EST_MAP  CEM
                                    JOIN EST_INFO          EI ON (CEM.EST_ID = EI.EST_ID)
	                            WHERE	(CEM.CTRL_ID	= @CTRL_ID	OR @CTRL_ID     =''    )
		                            AND	(CEM.EST_ID		= @EST_ID	OR @EST_ID	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "CTRLESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectCtrlInfoByEstID(int comp_id, string est_id)
        {
            string query = @"SELECT   CTRL_ID
		                            , COMP_ID
		                            , ESTTERM_REF_ID
		                            , ESTTERM_SUB_ID
		                            , CTRL_EMP_ID
		                            , SCOPE
		                            , POINT_GRADE_TYPE
		                            , SCOPE_UNIT_ID
		                            , ALL_EST_YN
		                            , ALL_EST_DEPT_YN
		                            , CTRL_ORDER
		                            , CREATE_DATE
		                            , CREATE_USER
		                            , UPDATE_DATE
		                            , UPDATE_USER
                            FROM EST_CTRL_INFO
	                            WHERE   COMP_ID = @COMP_ID
		                            AND CTRL_ID IN (SELECT CTRL_ID FROM EST_CTRL_INFO
							                            WHERE ALL_EST_YN = 'Y'
						                            UNION
						                            SELECT CTRL_ID FROM EST_CTRL_EST_MAP
							                            WHERE   COMP_ID = @COMP_ID
                                                            AND EST_ID  = @EST_ID)";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "CTRLESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectCtrlEstDeptByEstID(int comp_id, string est_id)
        {
            string query = @"SELECT   CTRL_ID
		                            , COMP_ID
		                            , DEPT_REF_ID
		                            , CREATE_DATE
		                            , CREATE_USER
		                            , UPDATE_DATE
		                            , UPDATE_USER  
                            FROM EST_CTRL_DEPT_MAP
	                            WHERE   COMP_ID = @COMP_ID
		                            AND CTRL_ID IN (SELECT CTRL_ID FROM EST_CTRL_INFO
							                            WHERE ALL_EST_YN = 'Y'
						                            UNION
						                            SELECT CTRL_ID FROM EST_CTRL_EST_MAP
							                            WHERE   COMP_ID = @COMP_ID
                                                            AND EST_ID  = @EST_ID)";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "CTRLESTMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string ctrl_id
                        , int comp_id
                        , string est_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_CTRL_EST_MAP(CTRL_ID
                                                        ,COMP_ID
						                                ,EST_ID
						                                ,CREATE_DATE
						                                ,CREATE_USER
						                                ,UPDATE_DATE
						                                ,UPDATE_USER
						                                )
					                                VALUES	(@CTRL_ID
                                                        ,@COMP_ID
						                                ,@EST_ID
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
	        paramArray[2] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = est_id;
	        paramArray[3] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[3].Value = create_date;
	        paramArray[4] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[4].Value = create_user;
         
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
                        , string ctrl_id
                        , string est_id)
        {
            string query = @"DELETE	EST_CTRL_EST_MAP
	                            WHERE	(CTRL_ID	= @CTRL_ID	OR @CTRL_ID     =''    )
		                            AND	(EST_ID		= @EST_ID	OR @EST_ID	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@CTRL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = ctrl_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
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
