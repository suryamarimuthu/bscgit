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
    public class Dac_RelGroupDepts : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string rel_grp_id
                        , int dept_ref_id
                        , string est_id
                        , int estterm_ref_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_REL_GROUP_DEPT
	                            SET	 EST_ID				= @EST_ID
		                            ,ESTTERM_REF_ID		= @ESTTERM_REF_ID
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID         = @COMP_ID
                                    AND REL_GRP_ID		= @REL_GRP_ID
		                            AND	DEPT_REF_ID     = @DEPT_REF_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = dept_ref_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
	        paramArray[5] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[5].Value = update_date;
	        paramArray[6] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[6].Value = update_user;
         
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
         
        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx 
                            , int comp_id
                            , string rel_grp_id
                            , int dept_ref_id
                            , string est_id
                            , int estterm_ref_id)
        {
            string query = @"SELECT	 RG.COMP_ID
                                    ,RG.REL_GRP_ID
		                            ,RG.DEPT_REF_ID
                                    ,DI.DEPT_NAME
		                            ,RG.EST_ID
		                            ,RG.ESTTERM_REF_ID
		                            ,RG.CREATE_DATE
		                            ,RG.CREATE_USER
		                            ,RG.UPDATE_DATE
		                            ,RG.UPDATE_USER
	                            FROM	    EST_REL_GROUP_DEPT      RG  
                                    JOIN    COM_DEPT_INFO           DI  ON (RG.DEPT_REF_ID  = DI.DEPT_REF_ID)
	                            WHERE	(RG.COMP_ID	            = @COMP_ID	        OR @COMP_ID         = 0)
                                    AND (RG.REL_GRP_ID			= @REL_GRP_ID		OR @REL_GRP_ID		    =''    )
		                            AND	(RG.DEPT_REF_ID	        = @DEPT_REF_ID	    OR @DEPT_REF_ID     = 0)
		                            AND (RG.EST_ID				= @EST_ID			OR @EST_ID			    =''    )
		                            AND (RG.ESTTERM_REF_ID		= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID  = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = dept_ref_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "RELGROUPDEPTGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string rel_grp_id
                        , int dept_ref_id
                        , string est_id
                        , int estterm_ref_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_REL_GROUP_DEPT( COMP_ID
                                                            ,REL_GRP_ID
								                            ,DEPT_REF_ID
								                            ,EST_ID
								                            ,ESTTERM_REF_ID
								                            ,CREATE_DATE
								                            ,CREATE_USER
								                            ,UPDATE_DATE
								                            ,UPDATE_USER
								                            )
							                            VALUES	(@COMP_ID
                                                            ,@REL_GRP_ID
								                            ,@DEPT_REF_ID
								                            ,@EST_ID
								                            ,@ESTTERM_REF_ID
								                            ,@CREATE_DATE
								                            ,@CREATE_USER
								                            ,NULL
								                            ,NULL
								                            )";

	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = dept_ref_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
	        paramArray[5] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[5].Value = create_date;
	        paramArray[6] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[6].Value = create_user;
         
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
                        , int comp_id
                        , string rel_grp_id
                        , int dept_ref_id
                        , string est_id
                        , int estterm_ref_id)
        {
            string query = @"DELETE	EST_REL_GROUP_DEPT
	                            WHERE	(COMP_ID            = @COMP_ID          OR @COMP_ID         = 0)
                                    AND (REL_GRP_ID		    = @REL_GRP_ID       OR @REL_GRP_ID          =''    )
		                            AND	(DEPT_REF_ID        = @DEPT_REF_ID      OR @DEPT_REF_ID     = 0)
                                    AND (EST_ID             = @EST_ID           OR @EST_ID              =''    )
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = dept_ref_id;
            paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
         
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
