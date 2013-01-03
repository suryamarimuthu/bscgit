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
    public class Dac_EstDetails : DbAgentBase
    {
        public int Update(    IDbConnection conn
                            , IDbTransaction trx
                            , object comp_id
                            , object est_id
                            , object estterm_ref_id
                            , object estterm_sub_id
                            , object estterm_step_id
                            , object est_name
                            , object header_color
                            , object grade_confirm_yn
                            , object bias_yn
                            , object estterm_sub
                            , object estterm_step
                            , object point_ctrl_step
                            , object grade_ctrl_step
                            , object owner_type
                            , object est_style_id
                            , object weight_type
                            , object status_style_id
                            , object q_style_id
                            , object bias_type_id
                            , object use_yn
                            , DateTime update_date
                            , int update_user)
        {
            string query = @"UPDATE	EST_DETAIL
                                SET	 EST_NAME           = CASE WHEN @EST_NAME           IS NULL THEN EST_NAME           ELSE @EST_NAME          END
	                                ,HEADER_COLOR       = CASE WHEN @HEADER_COLOR       IS NULL THEN HEADER_COLOR       ELSE @HEADER_COLOR      END
	                                ,GRADE_CONFIRM_YN   = CASE WHEN @GRADE_CONFIRM_YN   IS NULL THEN GRADE_CONFIRM_YN   ELSE @GRADE_CONFIRM_YN  END
	                                ,BIAS_YN            = CASE WHEN @BIAS_YN            IS NULL THEN BIAS_YN            ELSE @BIAS_YN           END
	                                ,ESTTERM_SUB        = CASE WHEN @ESTTERM_SUB        IS NULL THEN ESTTERM_SUB        ELSE @ESTTERM_SUB       END
	                                ,ESTTERM_STEP       = CASE WHEN @ESTTERM_STEP       IS NULL THEN ESTTERM_STEP       ELSE @ESTTERM_STEP      END
	                                ,POINT_CTRL_STEP    = CASE WHEN @POINT_CTRL_STEP    IS NULL THEN POINT_CTRL_STEP    ELSE @POINT_CTRL_STEP   END
	                                ,GRADE_CTRL_STEP    = CASE WHEN @GRADE_CTRL_STEP    IS NULL THEN GRADE_CTRL_STEP    ELSE @GRADE_CTRL_STEP   END
	                                ,OWNER_TYPE         = CASE WHEN @OWNER_TYPE         IS NULL THEN OWNER_TYPE         ELSE @OWNER_TYPE        END
                                    ,EST_STYLE_ID       = CASE WHEN @EST_STYLE_ID       IS NULL THEN EST_STYLE_ID       ELSE @EST_STYLE_ID      END
                                    ,WEIGHT_TYPE        = CASE WHEN @WEIGHT_TYPE        IS NULL THEN WEIGHT_TYPE        ELSE @WEIGHT_TYPE       END
                                    ,STATUS_STYLE_ID    = CASE WHEN @STATUS_STYLE_ID    IS NULL THEN STATUS_STYLE_ID    ELSE @STATUS_STYLE_ID   END
                                    ,Q_STYLE_ID         = CASE WHEN @Q_STYLE_ID         IS NULL THEN Q_STYLE_ID         ELSE @Q_STYLE_ID        END
                                    ,BIAS_TYPE_ID       = CASE WHEN @BIAS_TYPE_ID       IS NULL THEN BIAS_TYPE_ID       ELSE @BIAS_TYPE_ID      END
	                                ,USE_YN             = CASE WHEN @USE_YN             IS NULL THEN USE_YN             ELSE @USE_YN            END
	                                ,UPDATE_DATE        = @UPDATE_DATE
	                                ,UPDATE_USER        = @UPDATE_USER
                                WHERE	COMP_ID         = @COMP_ID
                                    AND EST_ID          = @EST_ID
                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
                                    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(22);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
            paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
            paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_NAME", SqlDbType.NVarChar, 200);
	        paramArray[5].Value = est_name;
	        paramArray[6] 		= CreateDataParameter("@HEADER_COLOR", SqlDbType.NVarChar, 20);
	        paramArray[6].Value = header_color;
	        paramArray[7] 		= CreateDataParameter("@GRADE_CONFIRM_YN", SqlDbType.NChar);
	        paramArray[7].Value = grade_confirm_yn;
	        paramArray[8] 		= CreateDataParameter("@BIAS_YN", SqlDbType.NChar);
	        paramArray[8].Value = bias_yn;
	        paramArray[9] 		= CreateDataParameter("@ESTTERM_SUB", SqlDbType.Int);
	        paramArray[9].Value = estterm_sub;
	        paramArray[10] 		= CreateDataParameter("@ESTTERM_STEP", SqlDbType.Int);
	        paramArray[10].Value = estterm_step;
	        paramArray[11] 		= CreateDataParameter("@POINT_CTRL_STEP", SqlDbType.Int);
	        paramArray[11].Value = point_ctrl_step;
	        paramArray[12] 		= CreateDataParameter("@GRADE_CTRL_STEP", SqlDbType.Int);
	        paramArray[12].Value= grade_ctrl_step;
	        paramArray[13] 		= CreateDataParameter("@OWNER_TYPE", SqlDbType.NChar);
	        paramArray[13].Value= owner_type;
            paramArray[14] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[14].Value= est_style_id;
            paramArray[15] 		= CreateDataParameter("@WEIGHT_TYPE", SqlDbType.NVarChar);
	        paramArray[15].Value= weight_type;
            paramArray[16] 		= CreateDataParameter("@STATUS_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[16].Value= status_style_id;
            paramArray[17] 		= CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[17].Value= q_style_id;
            paramArray[18] 		= CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar);
	        paramArray[18].Value= bias_type_id;
	        paramArray[19] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[19].Value= use_yn;
	        paramArray[20] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[20].Value= update_date;
	        paramArray[21] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[21].Value= update_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx,  query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        public DataSet Select(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id)
        {
            string query = @"SELECT   COMP_ID
                                    , EST_ID
								    , ESTTERM_REF_ID
                                    , ESTTERM_SUB_ID
                                    , ESTTERM_STEP_ID
								    , EST_NAME
								    , HEADER_COLOR
								    , GRADE_CONFIRM_YN
								    , BIAS_YN
								    , ESTTERM_SUB
								    , ESTTERM_STEP
								    , POINT_CTRL_STEP
								    , GRADE_CTRL_STEP
								    , OWNER_TYPE
								    , EST_STYlE_ID
								    , WEIGHT_TYPE
								    , STATUS_STYLE_ID
								    , Q_STYLE_ID
								    , BIAS_TYPE_ID
								    , USE_YN
								    , CREATE_DATE
								    , CREATE_USER
								    , UPDATE_DATE
								    , UPDATE_USER
						    FROM		EST_DETAIL
						        WHERE   (COMP_ID            = @COMP_ID		    OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID		    OR @EST_ID              =''    )
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND (ESTTERM_STEP_ID    = @ESTTERM_STEP_ID  OR @ESTTERM_STEP_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
            paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
            paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "INFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public int Insert(    IDbConnection conn
                            , IDbTransaction trx
                            , object comp_id
                            , object est_id
                            , object estterm_ref_id
                            , object estterm_sub_id
                            , object estterm_step_id
                            , object est_name
                            , object header_color
                            , object grade_confirm_yn
                            , object bias_yn
                            , object estterm_sub
                            , object estterm_step
                            , object point_ctrl_step
                            , object grade_ctrl_step
                            , object owner_type
                            , object est_style_id
                            , object weight_type
                            , object status_style_id
                            , object q_style_id
                            , object bias_type_id
                            , object use_yn
                            , object create_date
                            , object create_user )
        {
            string query = @"INSERT INTO EST_DETAIL(COMP_ID
                                                    ,EST_ID
			                                        ,ESTTERM_REF_ID
                                                    ,ESTTERM_SUB_ID
                                                    ,ESTTERM_STEP_ID
			                                        ,EST_NAME
			                                        ,HEADER_COLOR
			                                        ,GRADE_CONFIRM_YN
			                                        ,BIAS_YN
			                                        ,ESTTERM_SUB
			                                        ,ESTTERM_STEP
			                                        ,POINT_CTRL_STEP
			                                        ,GRADE_CTRL_STEP
			                                        ,OWNER_TYPE
                                                    ,EST_STYLE_ID
                                                    ,Q_STYLE_ID
                                                    ,WEIGHT_TYPE
                                                    ,STATUS_STYLE_ID
                                                    ,BIAS_TYPE_ID
			                                        ,USE_YN
			                                        ,CREATE_DATE
			                                        ,CREATE_USER
			                                        )
		                                        VALUES	(@COMP_ID
                                                    ,@EST_ID
			                                        ,@ESTTERM_REF_ID
                                                    ,@ESTTERM_SUB_ID
                                                    ,@ESTTERM_STEP_ID
			                                        ,@EST_NAME
			                                        ,@HEADER_COLOR
			                                        ,@GRADE_CONFIRM_YN
			                                        ,@BIAS_YN
			                                        ,@ESTTERM_SUB
			                                        ,@ESTTERM_STEP
			                                        ,@POINT_CTRL_STEP
			                                        ,@GRADE_CTRL_STEP
			                                        ,@OWNER_TYPE
                                                    ,@EST_STYLE_ID
                                                    ,@Q_STYLE_ID
                                                    ,@WEIGHT_TYPE
                                                    ,@STATUS_STYLE_ID
                                                    ,@BIAS_TYPE_ID
			                                        ,@USE_YN
			                                        ,@CREATE_DATE
			                                        ,@CREATE_USER
			                                        )";

	        IDbDataParameter[] paramArray = CreateDataParameters(22);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
            paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
            paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
	        paramArray[5] 		= CreateDataParameter("@EST_NAME", SqlDbType.NVarChar, 200);
	        paramArray[5].Value = est_name;
	        paramArray[6] 		= CreateDataParameter("@HEADER_COLOR", SqlDbType.NVarChar, 20);
	        paramArray[6].Value = header_color;
	        paramArray[7] 		= CreateDataParameter("@GRADE_CONFIRM_YN", SqlDbType.NChar);
	        paramArray[7].Value = grade_confirm_yn;
	        paramArray[8] 		= CreateDataParameter("@BIAS_YN", SqlDbType.NChar);
	        paramArray[8].Value = bias_yn;
	        paramArray[9] 		= CreateDataParameter("@ESTTERM_SUB", SqlDbType.Int);
	        paramArray[9].Value = estterm_sub;
	        paramArray[10] 		= CreateDataParameter("@ESTTERM_STEP", SqlDbType.Int);
	        paramArray[10].Value= estterm_step;
	        paramArray[11] 		= CreateDataParameter("@POINT_CTRL_STEP", SqlDbType.Int);
	        paramArray[11].Value= point_ctrl_step;
	        paramArray[12] 		= CreateDataParameter("@GRADE_CTRL_STEP", SqlDbType.Int);
	        paramArray[12].Value= grade_ctrl_step;
	        paramArray[13] 		= CreateDataParameter("@OWNER_TYPE", SqlDbType.NChar);
	        paramArray[13].Value= owner_type;
            paramArray[14] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[14].Value= est_style_id;
            paramArray[15] 		= CreateDataParameter("@WEIGHT_TYPE", SqlDbType.NVarChar);
	        paramArray[15].Value= weight_type;
            paramArray[16] 		= CreateDataParameter("@STATUS_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[16].Value= status_style_id;
            paramArray[17] 		= CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[17].Value= q_style_id;
            paramArray[18] 		= CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar);
	        paramArray[18].Value= bias_type_id;
	        paramArray[19] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[19].Value= use_yn;
	        paramArray[20] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[20].Value= create_date;
	        paramArray[21] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[21].Value= create_user;
         
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
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id)
        {
            string query = @"DELETE	EST_DETAIL
                                WHERE   (COMP_ID            = @COMP_ID		    OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID		    OR @EST_ID              =''    )
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND (ESTTERM_STEP_ID    = @ESTTERM_STEP_ID  OR @ESTTERM_STEP_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
            paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
            paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
         
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
                        , int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_DETAIL
                                WHERE   (COMP_ID            = @COMP_ID		    OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID		    OR @EST_ID              =''    )
                                    AND (ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND (ESTTERM_SUB_ID     = @ESTTERM_SUB_ID   OR @ESTTERM_SUB_ID  = 0)
                                    AND (ESTTERM_STEP_ID    = @ESTTERM_STEP_ID  OR @ESTTERM_STEP_ID = 0)";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
            paramArray[2] 		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[2].Value = estterm_ref_id;
            paramArray[3] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[3].Value = estterm_sub_id;
            paramArray[4] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[4].Value = estterm_step_id;
         
	        try
	        {
		        return Convert.ToInt32(DbAgentObj.ExecuteScalar( conn, trx, query, paramArray, CommandType.Text).ToString());
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
