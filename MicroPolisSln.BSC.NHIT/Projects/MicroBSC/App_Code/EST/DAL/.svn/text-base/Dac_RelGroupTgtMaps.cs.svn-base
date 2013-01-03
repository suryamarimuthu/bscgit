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
    public class Dac_RelGroupTgtMaps : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , object comp_id
                        , object rel_grp_id
                        , object est_id
                        , object estterm_ref_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	EST_REL_GROUP_TGT_MAP
	                            SET	 UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID			= @COMP_ID
		                            AND	REL_GRP_ID		= @REL_GRP_ID
		                            AND	EST_ID			= @EST_ID
		                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
		                            AND	TGT_DEPT_ID		= @TGT_DEPT_ID
                                    AND TGT_EMP_ID      = @TGT_EMP_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[2].Value = est_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_ref_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[4].Value = tgt_dept_id;
            paramArray[5] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = tgt_emp_id;
	        paramArray[6] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[6].Value = update_date;
	        paramArray[7] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[7].Value = update_user;
         
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
         
        public DataSet Select(int comp_id
                            , string rel_grp_id
                            , string est_id
                            , int estterm_ref_id
                            , int tgt_dept_id
                            , int tgt_emp_id)
        {
            string query = @"SELECT	 COMP_ID
		                            ,REL_GRP_ID
		                            ,EST_ID
		                            ,ESTTERM_REF_ID
		                            ,TGT_DEPT_ID
                                    ,TGT_EMP_ID
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_REL_GROUP_TGT_MAP 
		                            WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
			                            AND	(REL_GRP_ID		= @REL_GRP_ID		OR @REL_GRP_ID		    =''    )
			                            AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
			                            AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
			                            AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
                                        AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[2].Value = est_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_ref_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[4].Value = tgt_dept_id;
            paramArray[5] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = tgt_emp_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "RELGROUPEMPMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , object comp_id
                        , object rel_grp_id
                        , object est_id
                        , object estterm_ref_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO EST_REL_GROUP_TGT_MAP(COMP_ID
		                                                    ,REL_GRP_ID
		                                                    ,EST_ID
		                                                    ,ESTTERM_REF_ID
		                                                    ,TGT_DEPT_ID
                                                            ,TGT_EMP_ID
		                                                    ,CREATE_DATE
		                                                    ,CREATE_USER
		                                                    ,UPDATE_DATE
		                                                    ,UPDATE_USER
		                                                    )
	                                                    VALUES	(@COMP_ID
		                                                    ,@REL_GRP_ID
		                                                    ,@EST_ID
		                                                    ,@ESTTERM_REF_ID
		                                                    ,@TGT_DEPT_ID
                                                            ,@TGT_EMP_ID
		                                                    ,@CREATE_DATE
		                                                    ,@CREATE_USER
		                                                    ,NULL
		                                                    ,NULL
		                                                    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[2].Value = est_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_ref_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[4].Value = tgt_dept_id;
            paramArray[5] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = tgt_emp_id;
	        paramArray[6] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[6].Value = create_date;
	        paramArray[7] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[7].Value = create_user;
         
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
                        , object comp_id
                        , object rel_grp_id
                        , object est_id
                        , object estterm_ref_id
                        , object tgt_dept_id
                        , object tgt_emp_id)
        {
            string query = @"DELETE	EST_REL_GROUP_TGT_MAP
		                        WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
			                        AND	(REL_GRP_ID		= @REL_GRP_ID		OR @REL_GRP_ID		    =''    )
			                        AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
			                        AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
			                        AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
                                    AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[2].Value = est_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_ref_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[4].Value = tgt_dept_id;
            paramArray[5] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = tgt_emp_id;
         
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

        public int Count( IDbConnection conn
                        , IDbTransaction trx 
                        , object comp_id
                        , object rel_grp_id
                        , object est_id
                        , object estterm_ref_id
                        , object tgt_dept_id
                        , object tgt_emp_id)
        {
            string query = @"SELECT COUNT(*)
                                FROM	EST_REL_GROUP_TGT_MAP
	                        WHERE	(COMP_ID		= @COMP_ID			OR @COMP_ID			= 0)
		                        AND	(REL_GRP_ID		= @REL_GRP_ID		OR @REL_GRP_ID		    =''    )
		                        AND	(EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                        AND	(ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
		                        AND	(TGT_DEPT_ID	= @TGT_DEPT_ID		OR @TGT_DEPT_ID		= 0)
                                AND	(TGT_EMP_ID		= @TGT_EMP_ID		OR @TGT_EMP_ID		= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_id;
	        paramArray[2] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
	        paramArray[2].Value = est_id;
	        paramArray[3] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_ref_id;
	        paramArray[4] 		= CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
	        paramArray[4].Value = tgt_dept_id;
            paramArray[5] 		= CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
	        paramArray[5].Value = tgt_emp_id;
         
	        try
	        {
		        return Convert.ToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text).ToString());
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
