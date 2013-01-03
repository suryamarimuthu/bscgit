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
    public class Dac_RelGroupPositionInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string rel_grp_pos_id
                        , string rel_grp_id
                        , string est_id
                        , int estterm_ref_id
                        , string rel_grp_pos_name
                        , string rel_grp_pos_desc
                        , string opt_value
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_REL_GROUP_POS_INFO
	                            SET	 REL_GRP_ID			= @REL_GRP_ID
		                            ,EST_ID				= @EST_ID
		                            ,ESTTERM_REF_ID		= @ESTTERM_REF_ID
		                            ,REL_GRP_POS_NAME	= @REL_GRP_POS_NAME
		                            ,REL_GRP_POS_DESC	= @REL_GRP_POS_DESC
		                            ,OPT_VALUE			= @OPT_VALUE
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	COMP_ID         = @COMP_ID
                                    AND REL_GRP_POS_ID	= @REL_GRP_POS_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_POS_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_pos_id;
	        paramArray[2] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = rel_grp_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
	        paramArray[5] 		= CreateDataParameter("@REL_GRP_POS_NAME", SqlDbType.NVarChar, 200);
	        paramArray[5].Value = rel_grp_pos_name;
	        paramArray[6] 		= CreateDataParameter("@REL_GRP_POS_DESC", SqlDbType.NVarChar, 2000);
	        paramArray[6].Value = rel_grp_pos_desc;
	        paramArray[7] 		= CreateDataParameter("@OPT_VALUE", SqlDbType.NVarChar, 20);
	        paramArray[7].Value = opt_value;
	        paramArray[8] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[8].Value = update_date;
	        paramArray[9] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[9].Value = update_user;
         
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
         
        public DataSet Select(IDbConnection conn
                            , IDbTransaction trx 
                            , int comp_id
                            , string rel_grp_pos_id
                            , string rel_grp_id
                            , string est_id
                            , int estterm_ref_id)
        {
            string query = @"SELECT	 COMP_ID
                                    ,REL_GRP_POS_ID
	                                ,REL_GRP_ID
	                                ,EST_ID
	                                ,ESTTERM_REF_ID
	                                ,REL_GRP_POS_NAME
	                                ,REL_GRP_POS_DESC
	                                ,OPT_VALUE
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_REL_GROUP_POS_INFO 
	                                WHERE	(COMP_ID        = @COMP_ID	        OR @COMP_ID	        = 0)
                                        AND (REL_GRP_POS_ID = @REL_GRP_POS_ID	OR @REL_GRP_POS_ID	    =''    )
		                                AND (REL_GRP_ID		= @REL_GRP_ID		OR @REL_GRP_ID		    =''    )
		                                AND (EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                                AND (ESTTERM_REF_ID = @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_POS_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_pos_id;
	        paramArray[2] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = rel_grp_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(conn, trx, query , "RELGROUPPOSINFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , int comp_id
                        , string rel_grp_pos_id
                        , string rel_grp_id
                        , string est_id
                        , int estterm_ref_id
                        , string rel_grp_pos_name
                        , string rel_grp_pos_desc
                        , string opt_value
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_REL_GROUP_POS_INFO( COMP_ID
                                                                ,REL_GRP_POS_ID
			                                                    ,REL_GRP_ID
			                                                    ,EST_ID
			                                                    ,ESTTERM_REF_ID
			                                                    ,REL_GRP_POS_NAME
			                                                    ,REL_GRP_POS_DESC
			                                                    ,OPT_VALUE
			                                                    ,CREATE_DATE
			                                                    ,CREATE_USER
			                                                    ,UPDATE_DATE
			                                                    ,UPDATE_USER
			                                                    )
		                                                    VALUES	(@COMP_ID
                                                                ,@REL_GRP_POS_ID
			                                                    ,@REL_GRP_ID
			                                                    ,@EST_ID
			                                                    ,@ESTTERM_REF_ID
			                                                    ,@REL_GRP_POS_NAME
			                                                    ,@REL_GRP_POS_DESC
			                                                    ,@OPT_VALUE
			                                                    ,@CREATE_DATE
			                                                    ,@CREATE_USER
			                                                    ,NULL
			                                                    ,NULL
			                                                    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_POS_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_pos_id;
	        paramArray[2] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = rel_grp_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
	        paramArray[5] 		= CreateDataParameter("@REL_GRP_POS_NAME", SqlDbType.NVarChar, 200);
	        paramArray[5].Value = rel_grp_pos_name;
	        paramArray[6] 		= CreateDataParameter("@REL_GRP_POS_DESC", SqlDbType.NVarChar, 2000);
	        paramArray[6].Value = rel_grp_pos_desc;
	        paramArray[7] 		= CreateDataParameter("@OPT_VALUE", SqlDbType.NVarChar, 20);
	        paramArray[7].Value = opt_value;
	        paramArray[8] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[8].Value = create_date;
	        paramArray[9] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[9].Value = create_user;
         
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
                        , string rel_grp_pos_id)
        {
            string query = @"DELETE	EST_REL_GROUP_POS_INFO
	                            WHERE	COMP_ID         = @COMP_ID
                                    AND REL_GRP_POS_ID  = @REL_GRP_POS_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_POS_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_pos_id;
         
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
                        , string rel_grp_pos_id
                        , string rel_grp_id)
        {
            string query = @"DELETE	EST_REL_GROUP_POS_INFO
	                            WHERE	COMP_ID         = @COMP_ID                                  
                                  AND   (REL_GRP_POS_ID  = @REL_GRP_POS_ID   OR @REL_GRP_POS_ID     =''    )
                                  AND   REL_GRP_ID      = @REL_GRP_ID  ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;            
            paramArray[1] = CreateDataParameter("@REL_GRP_POS_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = rel_grp_pos_id;
            paramArray[2] = CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
            paramArray[2].Value = rel_grp_id;

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

        public int Count( int comp_id
                        , string rel_grp_pos_id
                        , string rel_grp_id
                        , string est_id
                        , int estterm_ref_id)
        {
            string query = @"SELECT	COUNT(*)
                                FROM	EST_REL_GROUP_POS_INFO 
	                                WHERE	(COMP_ID        = @COMP_ID	        OR @COMP_ID	        = 0)
                                        AND (REL_GRP_POS_ID = @REL_GRP_POS_ID	OR @REL_GRP_POS_ID	    =''    )
		                                AND (REL_GRP_ID		= @REL_GRP_ID		OR @REL_GRP_ID		    =''    )
		                                AND (EST_ID			= @EST_ID			OR @EST_ID			    =''    )
		                                AND (ESTTERM_REF_ID = @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@REL_GRP_POS_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = rel_grp_pos_id;
	        paramArray[2] 		= CreateDataParameter("@REL_GRP_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = rel_grp_id;
	        paramArray[3] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = est_id;
	        paramArray[4] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_ref_id;
         
            try
	        {
		        return  Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray).ToString());
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
