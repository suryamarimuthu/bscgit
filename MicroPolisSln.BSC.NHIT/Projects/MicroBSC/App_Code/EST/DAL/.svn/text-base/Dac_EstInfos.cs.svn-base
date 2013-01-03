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
    public class Dac_EstInfos : DbAgentBase
    {
        public Dac_EstInfos()
        {
        }

        public int Update(    IDbConnection conn
                            , IDbTransaction trx
                            , object comp_id
                            , object est_id
                            , object up_est_id
                            , object est_name
                            , object header_color
                            , object grade_confirm_yn
                            , object bias_yn
                            , object bias_dept_use_yn
                            , object tgt_opinion_yn
                            , object feedback_yn
                            , object estterm_sub
                            , object estterm_step
                            , object fixed_weight_use_yn
                            , object fixed_weight
                            , object point_ctrl_step
                            , object grade_ctrl_step
                            , object owner_type
                            , object est_style_id
                            , object link_est_id
                            , object weight_type
                            , object scale_type
                            , object status_style_id
                            , object q_style_id
                            , object q_item_desc_use_yn
                            , object q_tgt_pos_biz_use_yn
                            , object all_step_visible_yn
                            , object emp_com_dept_yn
                            , object bias_type_id
                            , object visible_past_point_yn
                            , object est_qtt_mbo_yn
                            , object mbo_score_estimate_yn
                            , object dashboard_type
                            , object question_previous_step_yn
                            , object use_yn
                            , DateTime update_date
                            , int update_user)
        {
            string query = @"UPDATE	EST_INFO
                                SET	 EST_NAME               = CASE WHEN @EST_NAME               IS NULL THEN EST_NAME               ELSE @EST_NAME              END
	                                ,HEADER_COLOR           = CASE WHEN @HEADER_COLOR           IS NULL THEN HEADER_COLOR           ELSE @HEADER_COLOR          END
	                                ,GRADE_CONFIRM_YN       = CASE WHEN @GRADE_CONFIRM_YN       IS NULL THEN GRADE_CONFIRM_YN       ELSE @GRADE_CONFIRM_YN      END
	                                ,BIAS_YN                = CASE WHEN @BIAS_YN                IS NULL THEN BIAS_YN                ELSE @BIAS_YN               END
                                    ,BIAS_DEPT_USE_YN       = CASE WHEN @BIAS_DEPT_USE_YN       IS NULL THEN BIAS_DEPT_USE_YN       ELSE @BIAS_DEPT_USE_YN      END
                                    ,TGT_OPINION_YN         = CASE WHEN @TGT_OPINION_YN         IS NULL THEN TGT_OPINION_YN         ELSE @TGT_OPINION_YN        END
                                    ,FEEDBACK_YN            = CASE WHEN @FEEDBACK_YN            IS NULL THEN FEEDBACK_YN            ELSE @FEEDBACK_YN           END
	                                ,ESTTERM_SUB            = CASE WHEN @ESTTERM_SUB            IS NULL THEN ESTTERM_SUB            ELSE @ESTTERM_SUB           END
	                                ,ESTTERM_STEP           = CASE WHEN @ESTTERM_STEP           IS NULL THEN ESTTERM_STEP           ELSE @ESTTERM_STEP          END
                                    ,FIXED_WEIGHT_USE_YN    = CASE WHEN @FIXED_WEIGHT_USE_YN    IS NULL THEN FIXED_WEIGHT_USE_YN    ELSE @FIXED_WEIGHT_USE_YN   END
                                    ,FIXED_WEIGHT           = CASE WHEN @FIXED_WEIGHT           IS NULL THEN FIXED_WEIGHT           ELSE @FIXED_WEIGHT          END
	                                ,POINT_CTRL_STEP        = CASE WHEN @POINT_CTRL_STEP        IS NULL THEN POINT_CTRL_STEP        ELSE @POINT_CTRL_STEP       END
	                                ,GRADE_CTRL_STEP        = CASE WHEN @GRADE_CTRL_STEP        IS NULL THEN GRADE_CTRL_STEP        ELSE @GRADE_CTRL_STEP       END
	                                ,OWNER_TYPE             = CASE WHEN @OWNER_TYPE             IS NULL THEN OWNER_TYPE             ELSE @OWNER_TYPE            END
                                    ,EST_STYLE_ID           = CASE WHEN @EST_STYLE_ID           IS NULL THEN EST_STYLE_ID           ELSE @EST_STYLE_ID          END
                                    ,LINK_EST_ID            = CASE WHEN @LINK_EST_ID            IS NULL THEN LINK_EST_ID            ELSE @LINK_EST_ID           END
                                    ,WEIGHT_TYPE            = CASE WHEN @WEIGHT_TYPE            IS NULL THEN WEIGHT_TYPE            ELSE @WEIGHT_TYPE           END
                                    ,SCALE_TYPE             = CASE WHEN @SCALE_TYPE             IS NULL THEN SCALE_TYPE             ELSE @SCALE_TYPE            END
                                    ,STATUS_STYLE_ID        = CASE WHEN @STATUS_STYLE_ID        IS NULL THEN STATUS_STYLE_ID        ELSE @STATUS_STYLE_ID       END
                                    ,Q_STYLE_ID             = CASE WHEN @Q_STYLE_ID             IS NULL THEN Q_STYLE_ID             ELSE @Q_STYLE_ID            END
                                    ,Q_ITEM_DESC_USE_YN     = CASE WHEN @Q_ITEM_DESC_USE_YN     IS NULL THEN Q_ITEM_DESC_USE_YN     ELSE @Q_ITEM_DESC_USE_YN    END
                                    ,Q_TGT_POS_BIZ_USE_YN   = CASE WHEN @Q_TGT_POS_BIZ_USE_YN   IS NULL THEN Q_TGT_POS_BIZ_USE_YN   ELSE @Q_TGT_POS_BIZ_USE_YN  END
                                    ,ALL_STEP_VISIBLE_YN    = CASE WHEN @ALL_STEP_VISIBLE_YN    IS NULL THEN ALL_STEP_VISIBLE_YN    ELSE @ALL_STEP_VISIBLE_YN   END
                                    ,EMP_COM_DEPT_YN        = CASE WHEN @EMP_COM_DEPT_YN        IS NULL THEN EMP_COM_DEPT_YN        ELSE @EMP_COM_DEPT_YN       END
                                    ,BIAS_TYPE_ID           = CASE WHEN @BIAS_TYPE_ID           IS NULL THEN BIAS_TYPE_ID           ELSE @BIAS_TYPE_ID          END
                                    ,VISIBLE_PAST_POINT_YN  = CASE WHEN @VISIBLE_PAST_POINT_YN  IS NULL THEN VISIBLE_PAST_POINT_YN  ELSE @VISIBLE_PAST_POINT_YN END
                                    ,EST_QTT_MBO_YN         = CASE WHEN @EST_QTT_MBO_YN         IS NULL THEN EST_QTT_MBO_YN         ELSE @EST_QTT_MBO_YN        END
                                    ,MBO_SCORE_ESTIMATE_YN  = CASE WHEN @MBO_SCORE_ESTIMATE_YN  IS NULL THEN MBO_SCORE_ESTIMATE_YN  ELSE @MBO_SCORE_ESTIMATE_YN END
                                    ,DASHBOARD_TYPE         = CASE WHEN @DASHBOARD_TYPE         IS NULL THEN DASHBOARD_TYPE         ELSE @DASHBOARD_TYPE        END
                                    ,Q_PREVIOUS_STEP_VISIBLE_YN         = CASE WHEN @Q_PREVIOUS_STEP_VISIBLE_YN         IS NULL THEN Q_PREVIOUS_STEP_VISIBLE_YN         ELSE @Q_PREVIOUS_STEP_VISIBLE_YN        END
	                                ,USE_YN                 = CASE WHEN @USE_YN                 IS NULL THEN USE_YN                 ELSE @USE_YN                END
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	COMP_ID             = @COMP_ID
                                    AND EST_ID              = @EST_ID 
                                    AND @TEMP          = 0
                                    --AND @UP_EST_ID         != '00' -- 2011.12.29 박효동 : 허성덕과장과 협의하여 왜그런지 몰르지만 최상위수정못하게 막아놓은거 빼버림
                                    
                                   

 ";
            string query2 = @"UPDATE	EST_INFO
                                SET	 EST_NAME               = nvl(@EST_NAME,EST_NAME)
	                                ,HEADER_COLOR           = nvl(@HEADER_COLOR,HEADER_COLOR)
	                                ,GRADE_CONFIRM_YN       = nvl(@GRADE_CONFIRM_YN,GRADE_CONFIRM_YN )
	                                ,BIAS_YN                = nvl(@BIAS_YN,BIAS_YN)
                                    ,BIAS_DEPT_USE_YN       = nvl(@BIAS_DEPT_USE_YN,BIAS_DEPT_USE_YN)
                                    ,TGT_OPINION_YN         = nvl(@TGT_OPINION_YN,TGT_OPINION_YN)
                                    ,FEEDBACK_YN            = nvl(@FEEDBACK_YN,FEEDBACK_YN)
	                                ,ESTTERM_SUB            = nvl(@ESTTERM_SUB, ESTTERM_SUB)
	                                ,ESTTERM_STEP           = nvl(@ESTTERM_STEP,ESTTERM_STEP)
                                    ,FIXED_WEIGHT_USE_YN    = nvl(@FIXED_WEIGHT_USE_YN,FIXED_WEIGHT_USE_YN )
                                    ,FIXED_WEIGHT           = nvl(@FIXED_WEIGHT,FIXED_WEIGHT)
	                                ,POINT_CTRL_STEP        = nvl( @POINT_CTRL_STEP,POINT_CTRL_STEP      )
	                                ,GRADE_CTRL_STEP        = nvl(@GRADE_CTRL_STEP,GRADE_CTRL_STEP     )
	                                ,OWNER_TYPE             = nvl(@OWNER_TYPE, OWNER_TYPE           )
                                    ,EST_STYLE_ID           = nvl( @EST_STYLE_ID , EST_STYLE_ID         )
                                    ,LINK_EST_ID            = nvl(@LINK_EST_ID ,LINK_EST_ID         )
                                    ,WEIGHT_TYPE            = nvl(@WEIGHT_TYPE, WEIGHT_TYPE        )
                                    ,SCALE_TYPE             = nvl(@SCALE_TYPE,SCALE_TYPE        )
                                    ,STATUS_STYLE_ID        = nvl(@STATUS_STYLE_ID , STATUS_STYLE_ID    )
                                    ,Q_STYLE_ID             = nvl(@Q_STYLE_ID , Q_STYLE_ID         )
                                    ,Q_ITEM_DESC_USE_YN     = nvl(@Q_ITEM_DESC_USE_YN ,Q_ITEM_DESC_USE_YN   )
                                    ,Q_TGT_POS_BIZ_USE_YN   = nvl(@Q_TGT_POS_BIZ_USE_YN , Q_TGT_POS_BIZ_USE_YN )
                                    ,ALL_STEP_VISIBLE_YN    = nvl( @ALL_STEP_VISIBLE_YN ,ALL_STEP_VISIBLE_YN  )
                                    ,EMP_COM_DEPT_YN        = nvl(@EMP_COM_DEPT_YN  ,EMP_COM_DEPT_YN      )
                                    ,BIAS_TYPE_ID           = nvl(@BIAS_TYPE_ID, BIAS_TYPE_ID           )
                                    ,VISIBLE_PAST_POINT_YN  = nvl(@VISIBLE_PAST_POINT_YN,VISIBLE_PAST_POINT_YN )
                                    ,EST_QTT_MBO_YN         = nvl(@EST_QTT_MBO_YN  , EST_QTT_MBO_YN      )
                                    ,MBO_SCORE_ESTIMATE_YN  = nvl(@MBO_SCORE_ESTIMATE_YN ,MBO_SCORE_ESTIMATE_YN  )
                                    ,DASHBOARD_TYPE         = nvl(@DASHBOARD_TYPE        ,DASHBOARD_TYPE        )
                                    ,Q_PREVIOUS_STEP_VISIBLE_YN         = nvl(@Q_PREVIOUS_STEP_VISIBLE_YN , Q_PREVIOUS_STEP_VISIBLE_YN   )
	                                ,USE_YN                 = nvl(@USE_YN, USE_YN  )
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	COMP_ID             = @COMP_ID
                                    AND EST_ID              = @EST_ID 
                                    AND @TEMP          = 0
                                    --AND @UP_EST_ID         != '00' -- 2011.12.29 박효동 : 허성덕과장과 협의하여 왜그런지 몰르지만 최상위수정못하게 막아놓은거 빼버림
                                    
                                   

 ";

            IDbDataParameter[] paramArray = CreateDataParameters(36);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            //paramArray[2] 		= CreateDataParameter("@UP_EST_ID", SqlDbType.NVarChar, 20);
            //paramArray[2].Value = up_est_id;
            paramArray[2] = CreateDataParameter("@TEMP", SqlDbType.Int);
            paramArray[2].Value = 0;
            paramArray[3] = CreateDataParameter("@EST_NAME", SqlDbType.NVarChar);
            paramArray[3].Value = est_name;
            paramArray[4] = CreateDataParameter("@HEADER_COLOR", SqlDbType.NVarChar);
            paramArray[4].Value = header_color;
            paramArray[5] = CreateDataParameter("@GRADE_CONFIRM_YN", SqlDbType.NChar);
            paramArray[5].Value = grade_confirm_yn;
            paramArray[6] = CreateDataParameter("@BIAS_YN", SqlDbType.NChar);
            paramArray[6].Value = bias_yn;
            paramArray[7] = CreateDataParameter("@BIAS_DEPT_USE_YN", SqlDbType.NChar);
            paramArray[7].Value = bias_dept_use_yn;
            paramArray[8] = CreateDataParameter("@TGT_OPINION_YN", SqlDbType.NChar);
            paramArray[8].Value = tgt_opinion_yn;
            paramArray[9] = CreateDataParameter("@FEEDBACK_YN", SqlDbType.NChar);
            paramArray[9].Value = feedback_yn;
            paramArray[10] = CreateDataParameter("@ESTTERM_SUB", SqlDbType.Int);
            paramArray[10].Value = estterm_sub;
            paramArray[11] = CreateDataParameter("@ESTTERM_STEP", SqlDbType.Int);
            paramArray[11].Value = estterm_step;
            paramArray[12] = CreateDataParameter("@FIXED_WEIGHT_USE_YN", SqlDbType.NChar);
            paramArray[12].Value = fixed_weight_use_yn;
            paramArray[13] = CreateDataParameter("@FIXED_WEIGHT", SqlDbType.Decimal);
            paramArray[13].Value = fixed_weight;
            paramArray[14] = CreateDataParameter("@POINT_CTRL_STEP", SqlDbType.Int);
            paramArray[14].Value = point_ctrl_step;
            paramArray[15] = CreateDataParameter("@GRADE_CTRL_STEP", SqlDbType.Int);
            paramArray[15].Value = grade_ctrl_step;
            paramArray[16] = CreateDataParameter("@OWNER_TYPE", SqlDbType.NChar);
            paramArray[16].Value = owner_type;
            paramArray[17] = CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar);
            paramArray[17].Value = est_style_id;
            paramArray[18] = CreateDataParameter("@LINK_EST_ID", SqlDbType.NVarChar);
            paramArray[18].Value = link_est_id;
            paramArray[19] = CreateDataParameter("@WEIGHT_TYPE", SqlDbType.NVarChar);
            paramArray[19].Value = weight_type;
            paramArray[20] = CreateDataParameter("@SCALE_TYPE", SqlDbType.NVarChar);
            paramArray[20].Value = scale_type;
            paramArray[21] = CreateDataParameter("@STATUS_STYLE_ID", SqlDbType.NVarChar);
            paramArray[21].Value = status_style_id;
            paramArray[22] = CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
            paramArray[22].Value = q_style_id;
            paramArray[23] = CreateDataParameter("@Q_ITEM_DESC_USE_YN", SqlDbType.NChar);
            paramArray[23].Value = q_item_desc_use_yn;
            paramArray[24] = CreateDataParameter("@Q_TGT_POS_BIZ_USE_YN", SqlDbType.NChar);
            paramArray[24].Value = q_tgt_pos_biz_use_yn;
            paramArray[25] = CreateDataParameter("@ALL_STEP_VISIBLE_YN", SqlDbType.NChar);
            paramArray[25].Value = all_step_visible_yn;
            paramArray[26] = CreateDataParameter("@EMP_COM_DEPT_YN", SqlDbType.NChar);
            paramArray[26].Value = emp_com_dept_yn;
            paramArray[27] = CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar);
            paramArray[27].Value = bias_type_id;
            paramArray[28] = CreateDataParameter("@VISIBLE_PAST_POINT_YN", SqlDbType.NChar);
            paramArray[28].Value = visible_past_point_yn;
            paramArray[29] = CreateDataParameter("@EST_QTT_MBO_YN", SqlDbType.NChar);
            paramArray[29].Value = est_qtt_mbo_yn;
            paramArray[30] = CreateDataParameter("@MBO_SCORE_ESTIMATE_YN", SqlDbType.NChar);
            paramArray[30].Value = mbo_score_estimate_yn;
            paramArray[31] = CreateDataParameter("@DASHBOARD_TYPE", SqlDbType.NVarChar);
            paramArray[31].Value = dashboard_type;
            paramArray[32] = CreateDataParameter("@Q_PREVIOUS_STEP_VISIBLE_YN", SqlDbType.NChar);
            paramArray[32].Value = question_previous_step_yn;
            paramArray[33] = CreateDataParameter("@USE_YN", SqlDbType.NChar);
            paramArray[33].Value = use_yn;
            paramArray[34] = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[34].Value = update_date;
            paramArray[35] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[35].Value = update_user;


            //IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            //paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
            //paramArray[0].Value = comp_id;
            //paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            //paramArray[1].Value = est_id;
            ////paramArray[2] = CreateDataParameter("@TEMP", SqlDbType.Int);
            ////paramArray[2].Value = 0;
            //paramArray[2] = CreateDataParameter("@EST_NAME", SqlDbType.NVarChar);
            //paramArray[2].Value = est_name;
            //paramArray[3] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            //paramArray[3].Value= update_date;
            //paramArray[4] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            //paramArray[4].Value= update_user;
         
	        try
	        {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(query,query2), paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        public DataSet SelectDashBoardEst(int comp_id)
        {
            string query = @"SELECT   COMP_ID
                                    , EST_ID
								    , UP_EST_ID
								    , EST_NAME
								    , HEADER_COLOR
								    , GRADE_CONFIRM_YN
								    , BIAS_YN
                                    , BIAS_DEPT_USE_YN
                                    , TGT_OPINION_YN
                                    , FEEDBACK_YN
								    , ESTTERM_SUB
								    , ESTTERM_STEP
                                    , FIXED_WEIGHT_USE_YN
                                    , FIXED_WEIGHT
								    , POINT_CTRL_STEP
								    , GRADE_CTRL_STEP
								    , OWNER_TYPE
								    , EST_STYlE_ID
                                    , LINK_EST_ID
								    , WEIGHT_TYPE
                                    , SCALE_TYPE
								    , STATUS_STYLE_ID
								    , Q_STYLE_ID
                                    , Q_ITEM_DESC_USE_YN
                                    , Q_TGT_POS_BIZ_USE_YN
                                    , ALL_STEP_VISIBLE_YN
                                    , EMP_COM_DEPT_YN
								    , BIAS_TYPE_ID
								    , USE_YN
								    , CREATE_DATE
								    , CREATE_USER
								    , UPDATE_DATE
								    , UPDATE_USER
                                    , ISNULL(VISIBLE_PAST_POINT_YN, 'Y') AS VISIBLE_PAST_POINT_YN
                                    , ISNULL(EST_QTT_MBO_YN, 'N') AS EST_QTT_MBO_YN
                                    , ISNULL(DASHBOARD_TYPE, 'N') AS DASHBOARD_TYPE
						    FROM		EST_INFO
						    WHERE   (COMP_ID = @COMP_ID		OR	@COMP_ID = 0)
                                    AND RTRIM(DASHBOARD_TYPE) NOT IN ('', 'N')
                            ORDER BY DASHBOARD_TYPE
";
                            

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "INFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet Select(int comp_id, string est_id )
        {
            string query = @"SELECT   COMP_ID
                                    , EST_ID
								    , UP_EST_ID
								    , EST_NAME
								    , HEADER_COLOR
								    , GRADE_CONFIRM_YN
								    , BIAS_YN
                                    , BIAS_DEPT_USE_YN
                                    , TGT_OPINION_YN
                                    , FEEDBACK_YN
								    , ESTTERM_SUB
								    , ESTTERM_STEP
                                    , FIXED_WEIGHT_USE_YN
                                    , FIXED_WEIGHT
								    , POINT_CTRL_STEP
								    , GRADE_CTRL_STEP
								    , OWNER_TYPE
								    , EST_STYlE_ID
                                    , LINK_EST_ID
								    , WEIGHT_TYPE
                                    , SCALE_TYPE
								    , STATUS_STYLE_ID
								    , Q_STYLE_ID
                                    , Q_ITEM_DESC_USE_YN
                                    , Q_TGT_POS_BIZ_USE_YN
                                    , ALL_STEP_VISIBLE_YN
                                    , EMP_COM_DEPT_YN
								    , BIAS_TYPE_ID
								    , USE_YN
								    , CREATE_DATE
								    , CREATE_USER
								    , UPDATE_DATE
								    , UPDATE_USER
                                    , ISNULL(VISIBLE_PAST_POINT_YN, 'Y') AS VISIBLE_PAST_POINT_YN
                                    , ISNULL(EST_QTT_MBO_YN, 'N') AS EST_QTT_MBO_YN
                                    , ISNULL(DASHBOARD_TYPE, 'N') AS DASHBOARD_TYPE
                                    , ISNULL(Q_PREVIOUS_STEP_VISIBLE_YN, 'N') AS Q_PREVIOUS_STEP_VISIBLE_YN
                                    , ISNULL(MBO_SCORE_ESTIMATE_YN, 'N') AS MBO_SCORE_ESTIMATE_YN
						    FROM		EST_INFO
						        WHERE   (COMP_ID = @COMP_ID		OR	@COMP_ID    = 0    )
                                    AND (EST_ID  = @EST_ID		OR	@EST_ID     =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
	        DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "INFOGET" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet SelectByUpEstID(int comp_id, object up_est_id )
        {
            string query = @"SELECT   COMP_ID
                                    , EST_ID
								    , UP_EST_ID
								    , EST_NAME
								    , HEADER_COLOR
								    , GRADE_CONFIRM_YN
								    , BIAS_YN
                                    , BIAS_DEPT_USE_YN
                                    , TGT_OPINION_YN
                                    , FEEDBACK_YN
								    , ESTTERM_SUB
								    , ESTTERM_STEP
                                    , FIXED_WEIGHT_USE_YN
                                    , FIXED_WEIGHT
								    , POINT_CTRL_STEP
								    , GRADE_CTRL_STEP
								    , OWNER_TYPE
								    , EST_STYlE_ID
                                    , LINK_EST_ID
								    , WEIGHT_TYPE
                                    , SCALE_TYPE
								    , STATUS_STYLE_ID
								    , Q_STYLE_ID
                                    , Q_ITEM_DESC_USE_YN
                                    , Q_TGT_POS_BIZ_USE_YN
                                    , ALL_STEP_VISIBLE_YN
                                    , EMP_COM_DEPT_YN
								    , BIAS_TYPE_ID
								    , USE_YN
								    , CREATE_DATE
								    , CREATE_USER
								    , UPDATE_DATE
								    , UPDATE_USER
						    FROM		EST_INFO
						        WHERE   (COMP_ID   = @COMP_ID		OR	@COMP_ID   = 0)
                                    AND (UP_EST_ID = @UP_EST_ID		OR	@UP_EST_ID     =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@UP_EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = up_est_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "EST_INFO" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public int Insert(    IDbConnection conn
                            , IDbTransaction trx
                            , int comp_id
                            , string est_id
                            , object up_est_id
                            , string est_name
                            , string header_color
                            , string grade_confirm_yn
                            , string bias_yn
                            , object bias_dept_use_yn
                            , string tgt_opinion_yn
                            , string feedback_yn
                            , int estterm_sub
                            , int estterm_step
                            , string fixed_weight_use_yn
                            , double fixed_weight
                            , int point_ctrl_step
                            , int grade_ctrl_step
                            , string owner_type
                            , string est_style_id
                            , string link_est_id
                            , string weight_type
                            , string scale_type
                            , string status_style_id
                            , string q_style_id
                            , string q_item_desc_use_yn
                            , object q_tgt_pos_biz_use_yn
                            , object all_step_visible_yn
                            , object emp_com_dept_yn
                            , string bias_type_id
                            , string visible_past_point_yn
                            , string est_qtt_mbo_yn
                            , string mbo_score_estimate_yn
                            , string dashboard_type
                            , string question_previous_step_yn
                            , string use_yn
                            , DateTime create_date
                            , int create_user )
        {
            string query = @"INSERT INTO EST_INFO(COMP_ID
                                                ,EST_ID
			                                    ,UP_EST_ID
			                                    ,EST_NAME
			                                    ,HEADER_COLOR
			                                    ,GRADE_CONFIRM_YN
			                                    ,BIAS_YN
                                                ,BIAS_DEPT_USE_YN
                                                ,TGT_OPINION_YN
                                                ,FEEDBACK_YN
			                                    ,ESTTERM_SUB
			                                    ,ESTTERM_STEP
                                                ,FIXED_WEIGHT_USE_YN
                                                ,FIXED_WEIGHT
			                                    ,POINT_CTRL_STEP
			                                    ,GRADE_CTRL_STEP
			                                    ,OWNER_TYPE
                                                ,EST_STYLE_ID
                                                ,LINK_EST_ID
                                                ,Q_STYLE_ID
                                                ,WEIGHT_TYPE
                                                ,SCALE_TYPE
                                                ,STATUS_STYLE_ID
                                                ,Q_ITEM_DESC_USE_YN
                                                ,Q_TGT_POS_BIZ_USE_YN
                                                ,ALL_STEP_VISIBLE_YN
                                                ,EMP_COM_DEPT_YN
                                                ,BIAS_TYPE_ID
                                                ,VISIBLE_PAST_POINT_YN
                                                ,EST_QTT_MBO_YN
                                                ,MBO_SCORE_ESTIMATE_YN
                                                ,DASHBOARD_TYPE
                                                ,Q_PREVIOUS_STEP_VISIBLE_YN
			                                    ,USE_YN
			                                    ,CREATE_DATE
			                                    ,CREATE_USER
			                                    )
		                                    VALUES	(@COMP_ID
                                                ,@EST_ID
			                                    ,@UP_EST_ID
			                                    ,@EST_NAME
			                                    ,@HEADER_COLOR
			                                    ,@GRADE_CONFIRM_YN
			                                    ,@BIAS_YN
                                                ,@BIAS_DEPT_USE_YN
                                                ,@TGT_OPINION_YN
                                                ,@FEEDBACK_YN
			                                    ,@ESTTERM_SUB
			                                    ,@ESTTERM_STEP
                                                ,@FIXED_WEIGHT_USE_YN
                                                ,@FIXED_WEIGHT
			                                    ,@POINT_CTRL_STEP
			                                    ,@GRADE_CTRL_STEP
			                                    ,@OWNER_TYPE
                                                ,@EST_STYLE_ID
                                                ,@LINK_EST_ID
                                                ,@Q_STYLE_ID
                                                ,@WEIGHT_TYPE
                                                ,@SCALE_TYPE
                                                ,@STATUS_STYLE_ID
                                                ,@Q_ITEM_DESC_USE_YN
                                                ,@Q_TGT_POS_BIZ_USE_YN
                                                ,@ALL_STEP_VISIBLE_YN
                                                ,@EMP_COM_DEPT_YN
                                                ,@BIAS_TYPE_ID
                                                ,@VISIBLE_PAST_POINT_YN
                                                ,@EST_QTT_MBO_YN
                                                ,@MBO_SCORE_ESTIMATE_YN
                                                ,@DASHBOARD_TYPE
                                                ,@Q_PREVIOUS_STEP_VISIBLE_YN
			                                    ,@USE_YN
			                                    ,@CREATE_DATE
			                                    ,@CREATE_USER
			                                    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(36);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
            paramArray[2] 		= CreateDataParameter("@UP_EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = up_est_id;
	        paramArray[3] 		= CreateDataParameter("@EST_NAME", SqlDbType.NVarChar, 200);
	        paramArray[3].Value = est_name;
	        paramArray[4] 		= CreateDataParameter("@HEADER_COLOR", SqlDbType.NVarChar, 20);
	        paramArray[4].Value = header_color;
	        paramArray[5] 		= CreateDataParameter("@GRADE_CONFIRM_YN", SqlDbType.NChar);
	        paramArray[5].Value = grade_confirm_yn;
	        paramArray[6] 		= CreateDataParameter("@BIAS_YN", SqlDbType.NChar);
	        paramArray[6].Value = bias_yn;
            paramArray[7] 		= CreateDataParameter("@BIAS_DEPT_USE_YN", SqlDbType.NChar);
	        paramArray[7].Value = bias_dept_use_yn;
            paramArray[8] 		= CreateDataParameter("@TGT_OPINION_YN", SqlDbType.NChar);
	        paramArray[8].Value = tgt_opinion_yn;
            paramArray[9] 		= CreateDataParameter("@FEEDBACK_YN", SqlDbType.NChar);
	        paramArray[9].Value = feedback_yn;
	        paramArray[10] 		= CreateDataParameter("@ESTTERM_SUB", SqlDbType.Int);
	        paramArray[10].Value = estterm_sub;
	        paramArray[11] 		= CreateDataParameter("@ESTTERM_STEP", SqlDbType.Int);
	        paramArray[11].Value = estterm_step;
            paramArray[12] 		= CreateDataParameter("@FIXED_WEIGHT_USE_YN", SqlDbType.NChar);
	        paramArray[12].Value= fixed_weight_use_yn;
            paramArray[13] 		= CreateDataParameter("@FIXED_WEIGHT", SqlDbType.Decimal);
	        paramArray[13].Value= fixed_weight;
	        paramArray[14] 		= CreateDataParameter("@POINT_CTRL_STEP", SqlDbType.Int);
	        paramArray[14].Value = point_ctrl_step;
	        paramArray[15] 		= CreateDataParameter("@GRADE_CTRL_STEP", SqlDbType.Int);
	        paramArray[15].Value= grade_ctrl_step;
	        paramArray[16] 		= CreateDataParameter("@OWNER_TYPE", SqlDbType.NChar);
	        paramArray[16].Value= owner_type;
            paramArray[17] 		= CreateDataParameter("@EST_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[17].Value= est_style_id;
            paramArray[18] 		= CreateDataParameter("@LINK_EST_ID", SqlDbType.NVarChar);
	        paramArray[18].Value= link_est_id;
            paramArray[19] 		= CreateDataParameter("@WEIGHT_TYPE", SqlDbType.NVarChar);
	        paramArray[19].Value= weight_type;
            paramArray[20] 		= CreateDataParameter("@SCALE_TYPE", SqlDbType.NVarChar);
	        paramArray[20].Value= scale_type;
            paramArray[21] 		= CreateDataParameter("@STATUS_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[21].Value= status_style_id;
            paramArray[22] 		= CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar);
	        paramArray[22].Value= q_style_id;
            paramArray[23] 		= CreateDataParameter("@Q_ITEM_DESC_USE_YN", SqlDbType.NChar);
	        paramArray[23].Value= q_item_desc_use_yn;
            paramArray[24] 		= CreateDataParameter("@Q_TGT_POS_BIZ_USE_YN", SqlDbType.NChar);
	        paramArray[24].Value= q_tgt_pos_biz_use_yn;
            paramArray[25] 		= CreateDataParameter("@ALL_STEP_VISIBLE_YN", SqlDbType.NChar);
			paramArray[25].Value= all_step_visible_yn;
            paramArray[26] 		= CreateDataParameter("@EMP_COM_DEPT_YN", SqlDbType.NChar);
			paramArray[26].Value= emp_com_dept_yn;
            paramArray[27] 		= CreateDataParameter("@BIAS_TYPE_ID", SqlDbType.NVarChar);
	        paramArray[27].Value= bias_type_id;
	        paramArray[28] 		= CreateDataParameter("@VISIBLE_PAST_POINT_YN", SqlDbType.NChar);
	        paramArray[28].Value= visible_past_point_yn;
            paramArray[29]      = CreateDataParameter("@EST_QTT_MBO_YN", SqlDbType.NChar);
            paramArray[29].Value= est_qtt_mbo_yn;
            paramArray[30] = CreateDataParameter("@MBO_SCORE_ESTIMATE_YN", SqlDbType.NChar);
            paramArray[30].Value = mbo_score_estimate_yn;
            paramArray[31] = CreateDataParameter("@DASHBOARD_TYPE", SqlDbType.NChar);
            paramArray[31].Value = dashboard_type;
            paramArray[32] = CreateDataParameter("@Q_PREVIOUS_STEP_VISIBLE_YN", SqlDbType.NChar);
            paramArray[32].Value = question_previous_step_yn;
            paramArray[33]      = CreateDataParameter("@USE_YN", SqlDbType.NChar);
            paramArray[33].Value= use_yn;
	        paramArray[34] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[34].Value= create_date;
	        paramArray[35] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[35].Value= create_user;
         
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
                        , string est_id)
        {
            string query = @"DELETE	EST_INFO
                                WHERE	COMP_ID = @COMP_ID
                                    AND EST_ID  = @EST_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
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

        public int Count(int comp_id, string est_id)
        {
            string query = @"SELECT COUNT(*) FROM EST_INFO
                                WHERE	(COMP_ID    = @COMP_ID  OR @COMP_ID = 0)
                                    AND (EST_ID     = @EST_ID   OR @EST_ID      =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = est_id;
         
	        try
	        {
				object result = DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text);
				if (string.IsNullOrEmpty(result.ToString()))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(result.ToString());
				}
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
