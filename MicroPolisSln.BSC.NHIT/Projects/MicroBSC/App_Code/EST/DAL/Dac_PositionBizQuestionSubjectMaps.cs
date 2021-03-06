﻿using System;
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
    public class Dac_PositionBizQuestionSubjectMaps : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , string pos_biz_id
                        , string q_sbj_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_POS_BIZ_Q_SBJ_MAP
	                            SET	 UPDATE_DATE	= @UPDATE_DATE
		                            ,UPDATE_USER	= @UPDATE_USER
	                            WHERE	COMP_ID     = @COMP_ID
                                    AND EST_ID      = @EST_ID
                                    AND POS_BIZ_ID	= @POS_BIZ_ID
		                            AND	Q_SBJ_ID	= @Q_SBJ_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.NVarChar, 100);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 100);
	        paramArray[2].Value = pos_biz_id;
	        paramArray[3] 		= CreateDataParameter("@Q_SBJ_ID", SqlDbType.NChar);
	        paramArray[3].Value = q_sbj_id;
	        paramArray[4] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[4].Value = update_date;
	        paramArray[5] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[5].Value = update_user;
         
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
                            , string est_id 
                            , string pos_biz_id
                            , string q_sbj_id)
        {
            string query = @"SELECT	 COMP_ID
                                    ,EST_ID
                                    ,POS_BIZ_ID
		                            ,Q_SBJ_ID
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_POS_BIZ_Q_SBJ_MAP 
		                            WHERE	(COMP_ID    = @COMP_ID      OR @COMP_ID     = 0)
                                        AND (EST_ID     = @EST_ID       OR @EST_ID          =''    )
                                        AND (POS_BIZ_ID	= @POS_BIZ_ID	OR @POS_BIZ_ID	    =''    )
			                            AND	(Q_SBJ_ID	= @Q_SBJ_ID		OR @Q_SBJ_ID	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.NVarChar, 100);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 100);
	        paramArray[2].Value = pos_biz_id;
	        paramArray[3] 		= CreateDataParameter("@Q_SBJ_ID", SqlDbType.NChar);
	        paramArray[3].Value = q_sbj_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "QUESTIONSBJPOSBIZMAPGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int comp_id
                        , string est_id
                        , string pos_biz_id
                        , string q_sbj_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_POS_BIZ_Q_SBJ_MAP(COMP_ID
                                                                    ,EST_ID
                                                                    ,POS_BIZ_ID
									                                ,Q_SBJ_ID
									                                ,CREATE_DATE
									                                ,CREATE_USER
									                                ,UPDATE_DATE
									                                ,UPDATE_USER
									                                )
								                                VALUES	(@COMP_ID
                                                                    ,@EST_ID
                                                                    ,@POS_BIZ_ID
									                                ,@Q_SBJ_ID
									                                ,@CREATE_DATE
									                                ,@CREATE_USER
									                                ,NULL
									                                ,NULL
									                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.NVarChar, 100);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 100);
	        paramArray[2].Value = pos_biz_id;
	        paramArray[3] 		= CreateDataParameter("@Q_SBJ_ID", SqlDbType.NChar);
	        paramArray[3].Value = q_sbj_id;
	        paramArray[4] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[4].Value = create_date;
	        paramArray[5] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[5].Value = create_user;
         
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
                        , int comp_id
                        , string est_id
                        , string pos_biz_id
                        , string q_sbj_id)
        {
            string query = @"DELETE	EST_POS_BIZ_Q_SBJ_MAP
	                            WHERE	(COMP_ID    = @COMP_ID      OR @COMP_ID     = 0)
                                    AND (EST_ID     = @EST_ID       OR @EST_ID          =''    )
                                    AND (POS_BIZ_ID	= @POS_BIZ_ID	OR @POS_BIZ_ID	    =''    )
		                            AND	(Q_SBJ_ID	= @Q_SBJ_ID		OR @Q_SBJ_ID	    =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.NVarChar, 100);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
	        paramArray[1].Value = est_id;
	        paramArray[2] 		= CreateDataParameter("@POS_BIZ_ID", SqlDbType.NVarChar, 100);
	        paramArray[2].Value = pos_biz_id;
	        paramArray[3] 		= CreateDataParameter("@Q_SBJ_ID", SqlDbType.NChar);
	        paramArray[3].Value = q_sbj_id;
         
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
