using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.PRJ.Dac
{
    public class Dac_Prj_Data : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object prj_ref_id
                        , object point
                        , object point_date
                        , object status_id
                        , object status_date
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	PRJ_DATA
                                SET	 POINT                  = CASE WHEN @POINT                  IS NULL THEN POINT                  ELSE @POINT                 END
	                                ,POINT_DATE             = CASE WHEN @POINT_DATE             IS NULL THEN POINT_DATE             ELSE @POINT_DATE            END
                                    ,STATUS_ID              = CASE WHEN @STATUS_ID              IS NULL THEN STATUS_ID              ELSE @STATUS_ID             END
	                                ,STATUS_DATE            = CASE WHEN @STATUS_DATE            IS NULL THEN STATUS_DATE            ELSE @STATUS_DATE           END
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	(COMP_ID             = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID              = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID      = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID      = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID     = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID         = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID          = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(PRJ_REF_ID          = @PRJ_REF_ID      OR @PRJ_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value     = prj_ref_id;
            paramArray[8]           = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[8].Value     = point;
            paramArray[9]           = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[9].Value     = point_date;
            paramArray[10]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[10].Value    = status_id;
            paramArray[11]          = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[11].Value    = status_date;
            paramArray[12]          = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[12].Value    = update_date;
            paramArray[13]          = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[13].Value    = update_user;

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


        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object prj_ref_id
                        , object point
                        , object point_date
                        , object status_id
                        , object status_date
                        , object update_date
                        , object update_user)
        {
            string query = @"UPDATE	PRJ_DATA
                                SET	 POINT                  = CASE WHEN @POINT                  IS NULL THEN POINT                  ELSE @POINT                 END
	                                ,POINT_DATE             = CASE WHEN @POINT_DATE             IS NULL THEN POINT_DATE             ELSE @POINT_DATE            END
                                    ,STATUS_ID              = CASE WHEN @STATUS_ID              IS NULL THEN STATUS_ID              ELSE @STATUS_ID             END
	                                ,STATUS_DATE            = CASE WHEN @STATUS_DATE            IS NULL THEN STATUS_DATE            ELSE @STATUS_DATE           END
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	(COMP_ID             = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID              = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID      = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID      = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID     = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID         = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID          = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(TGT_DEPT_ID         = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(TGT_EMP_ID          = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                    AND	(PRJ_REF_ID          = @PRJ_REF_ID      OR @PRJ_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[9].Value = prj_ref_id;
            paramArray[10] = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[10].Value = point;
            paramArray[11] = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[11].Value = point_date;
            paramArray[12] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[12].Value = status_id;
            paramArray[13] = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[13].Value = status_date;
            paramArray[14] = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[14].Value = update_date;
            paramArray[15] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[15].Value = update_user;

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


        public int UpdateConfirmBias( IDbConnection conn
                                    , IDbTransaction trx
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string bias_type_id
                                    , DateTime update_date
                                    , int update_user)
        {
            string query = string.Format(@"UPDATE	PRJ_DATA
                                                SET	 POINT              = POINT_{0}
	                                                ,POINT_DATE         = @UPDATE_DATE
	                                                ,UPDATE_DATE        = @UPDATE_DATE
	                                                ,UPDATE_USER        = @UPDATE_USER
                                                WHERE	(COMP_ID        =  @COMP_ID         OR @COMP_ID         = 0)
                                                    AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)", bias_type_id);

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[5].Value     = update_date;
            paramArray[6]           = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[6].Value     = update_user;

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
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int prj_ref_id
                            , string year_yn
                            , string merge_yn)
        {
            string query = @"SELECT	 PD.COMP_ID
                                    ,PD.EST_ID
	                                ,PD.ESTTERM_REF_ID
	                                ,PD.ESTTERM_SUB_ID
	                                ,PD.ESTTERM_STEP_ID
	                                ,PD.EST_DEPT_ID
	                                ,PD.EST_EMP_ID
	                                ,PD.PRJ_REF_ID
                                    ,PD.POINT
	                                ,PD.POINT_DATE
                                    ,PD.STATUS_ID
	                                ,PD.STATUS_DATE
	                                ,PD.CREATE_DATE
	                                ,PD.CREATE_USER
	                                ,PD.UPDATE_DATE
	                                ,PD.UPDATE_USER

                                FROM	PRJ_DATA PD
                                    JOIN    EST_TERM_SUB          ESU    ON	(PD.COMP_ID         = ESU.COMP_ID
                                                                         AND PD.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
                                    JOIN    EST_TERM_STEP         EST    ON	(PD.COMP_ID         = EST.COMP_ID
                                                                         AND PD.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
                                    WHERE   (PD.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                        AND (PD.EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                        AND	(PD.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                        AND	(PD.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                        AND	(PD.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                        AND	(PD.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                        AND	(PD.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                        AND	(PD.PRJ_REF_ID      = @PRJ_REF_ID      OR @PRJ_REF_ID      = 0)
                                        AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN             =''    )
                                        AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN            =''    )
                                    ORDER BY PD.ESTTERM_SUB_ID , PD.ESTTERM_STEP_ID";



            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value = prj_ref_id;
            paramArray[8] = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[8].Value = year_yn;
            paramArray[9] = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[9].Value = merge_yn;
            

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        // Bias 조정에서 쓰이는 쿼리
        public string SelectBiasDataScript(string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string bias_type)
        {
            string query = string.Format(@"SELECT ED.EST_EMP_ID
	                                            , CE.EMP_NAME                   AS EST_EMP_NAME
	                                            , ROUND(MAX(ED.POINT_{0}), 2)	AS PNT_MAX
	                                            , ROUND(MIN(ED.POINT_{0}), 2)	AS PNT_MIN
	                                            , ROUND(AVG(ED.POINT_{0}), 2)	AS PNT_AVG
	                                            , COUNT(ED.TGT_DEPT_ID)			AS PNT_CNT
                                            FROM		PRJ_DATA		ED 
	                                            JOIN	COM_EMP_INFO	CE ON (ED.EST_EMP_ID = CE.EMP_REF_ID)
                                            WHERE	(EST_ID          = '{1}' OR '{1}'     =''    )
                                                AND	(ESTTERM_REF_ID  = {2}   OR {2}   = 0)
                                                AND	(ESTTERM_SUB_ID  = {3}   OR {3}   = 0)
                                                AND	(ESTTERM_STEP_ID = {4}   OR {4}   = 0)
                                            GROUP BY  ED.EST_EMP_ID
		                                            , CE.EMP_NAME", bias_type, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id);

            return query;
        }

        public DataSet SelectPrjData( int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , int prj_ref_id
                                    , string year_yn
                                    , string merge_yn)
        {
            string query = @"
SELECT  PD.COMP_ID
        ,PD.EST_ID
        ,PD.ESTTERM_REF_ID
        ,PD.ESTTERM_SUB_ID
        ,PD.ESTTERM_STEP_ID
        ,PD.EST_DEPT_ID
        ,PD.EST_EMP_ID
        ,PD.PRJ_REF_ID
        ,PD.POINT
        ,PD.POINT_DATE
        ,PD.STATUS_ID
        ,PD.STATUS_DATE
        ,PD.CREATE_DATE
        ,PD.CREATE_USER
        ,PD.UPDATE_DATE
        ,PD.UPDATE_USER
        ,ESU.ESTTERM_SUB_NAME
        ,EST.ESTTERM_STEP_NAME
        ,EDE.DEPT_NAME                      AS EST_DEPT_NAME
        ,EIE.EMP_NAME                       AS EST_EMP_NAME
        ,PIF.PRJ_NAME
        ,PIF.PRJ_CODE
        ,ESA.STATUS_IMG_PATH
        ,QPS.Q_STYLE_PAGE_NAME
        ,SSM.WEIGHT                         AS WEIGHT_ESTTERM_SUB
        ,STM.WEIGHT                         AS WEIGHT_ESTTERM_STEP
        ,ESU.YEAR_YN
        ,EST.MERGE_YN
        ,DE.DEPT_CODE                       AS TGT_DEPT_ID
        ,RE.OWNER_EMP_ID                    AS TGT_EMP_ID
        ,PC.POS_CLS_ID		                AS TGT_POS_CLS_ID
        ,PC.POS_CLS_NAME	                AS TGT_POS_CLS_NAME
        ,PU.POS_DUT_ID		                AS TGT_POS_DUT_ID
        ,PU.POS_DUT_NAME	                AS TGT_POS_DUT_NAME
        ,PG.POS_GRP_ID		                AS TGT_POS_GRP_ID
        ,PG.POS_GRP_NAME	                AS TGT_POS_GRP_NAME
        ,PR.POS_RNK_ID		                AS TGT_POS_RNK_ID
        ,PR.POS_RNK_NAME	                AS TGT_POS_RNK_NAME
        ,PK.POS_KND_ID		                AS TGT_POS_KND_ID
        ,PK.POS_KND_NAME	                AS TGT_POS_KND_NAME
    FROM	            PRJ_DATA	        PD
        LEFT OUTER JOIN PRJ_INFO            RE ON RE.PRJ_REF_ID             = PD.PRJ_REF_ID
        JOIN COM_EMP_INFO		            CE ON (RE.OWNER_EMP_ID			= CE.EMP_REF_ID)
        JOIN COM_DEPT_INFO		            DE ON (PD.EST_DEPT_ID			= DE.DEPT_REF_ID)    --DE.DEPT_CODE)
        LEFT OUTER JOIN EST_POSITION_CLS	PC ON (CE.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
        LEFT OUTER JOIN EST_POSITION_DUT	PU ON (CE.POSITION_DUTY_CODE	= PU.POS_DUT_ID)
        LEFT OUTER JOIN EST_POSITION_GRP	PG ON (CE.POSITION_GRP_CODE		= PG.POS_GRP_ID)
        LEFT OUTER JOIN EST_POSITION_RNK	PR ON (CE.POSITION_RANK_CODE	= PR.POS_RNK_ID)
        LEFT OUTER JOIN EST_POSITION_KND	PK ON (CE.POSITION_KIND_CODE	= PK.POS_KND_ID)
        LEFT OUTER JOIN EST_TERM_SUB  ESU    ON	(PD.ESTTERM_SUB_ID          = ESU.ESTTERM_SUB_ID)
        LEFT OUTER JOIN EST_TERM_STEP EST    ON	(PD.ESTTERM_STEP_ID         = EST.ESTTERM_STEP_ID)
        JOIN COM_DEPT_INFO            EDE    ON (PD.EST_DEPT_ID             = EDE.DEPT_REF_ID)
        JOIN COM_EMP_INFO             EIE    ON (PD.EST_EMP_ID              = EIE.EMP_REF_ID)
        JOIN EST_INFO                 EI     ON (PD.EST_ID                  = EI.EST_ID)
        JOIN EST_STATUS_STYLE         ESS    ON (EI.STATUS_STYLE_ID         = ESS.STATUS_STYLE_ID)
        LEFT OUTER JOIN EST_STATUS    ESA    ON (ESA.STATUS_STYLE_ID        = ESS.STATUS_STYLE_ID
                                            AND  ESA.STATUS_ID              = PD.STATUS_ID)
        JOIN EST_QUESTION_PAGE_STYLE  QPS    ON (EI.Q_STYLE_ID              = QPS.Q_STYLE_ID)
        LEFT OUTER JOIN EST_TERM_SUB_EST_MAP  SSM    ON (PD.COMP_ID             = SSM.COMP_ID
                                                         AND PD.EST_ID          = SSM.EST_ID
                                                         AND PD.ESTTERM_SUB_ID  = SSM.ESTTERM_SUB_ID)
        LEFT OUTER JOIN EST_TERM_STEP_EST_MAP STM    ON (PD.COMP_ID             = STM.COMP_ID
                                                         AND PD.EST_ID          = STM.EST_ID
                                                         AND PD.ESTTERM_STEP_ID = STM.ESTTERM_STEP_ID)
        JOIN PRJ_INFO				          PIF	 ON (PD.PRJ_REF_ID		    = PIF.PRJ_REF_ID)
            WHERE (PD.COMP_ID           = @COMP_ID         OR @COMP_ID         = 0)	
                AND (PD.EST_ID          = @EST_ID          OR @EST_ID		   ='')
                AND	(PD.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                AND	(PD.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                AND	(PD.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                AND	(PD.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                AND	(PD.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                AND	(PD.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                AND	(PD.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                AND	(PD.PRJ_REF_ID      = @PRJ_REF_ID      OR @PRJ_REF_ID      = 0)
                AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN         ='')
                AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN        ='')
                AND (PD.TGT_EMP_ID          <> -1 )
        ORDER BY PD.ESTTERM_SUB_ID, PD.ESTTERM_STEP_ID, EDE.DEPT_NAME, EIE.EMP_NAME";

            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9]       = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[9].Value = prj_ref_id;
            paramArray[10]      = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[10].Value= year_yn;
            paramArray[11]      = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[11].Value= merge_yn;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object prj_ref_id
                        , object point
                        , object point_date
                        , object status_id
                        , object status_date
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO PRJ_DATA  (COMP_ID
                                                   ,EST_ID
                                                   ,ESTTERM_REF_ID
                                                   ,ESTTERM_SUB_ID
                                                   ,ESTTERM_STEP_ID
                                                   ,EST_DEPT_ID
                                                   ,EST_EMP_ID
                                                   ,PRJ_REF_ID
                                                   ,POINT
                                                   ,POINT_DATE
                                                   ,STATUS_ID
                                                   ,STATUS_DATE
                                                   ,CREATE_DATE
                                                   ,CREATE_USER)
                                             VALUES
                                                   (@COMP_ID
                                                   ,@EST_ID
                                                   ,@ESTTERM_REF_ID
                                                   ,@ESTTERM_SUB_ID
                                                   ,@ESTTERM_STEP_ID
                                                   ,@EST_DEPT_ID
                                                   ,@EST_EMP_ID
                                                   ,@PRJ_REF_ID
                                                   ,@POINT
                                                   ,@POINT_DATE
                                                   ,@STATUS_ID
                                                   ,@STATUS_DATE
                                                   ,@CREATE_DATE
                                                   ,@CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value     = prj_ref_id;
            paramArray[8]           = CreateDataParameter("@POINT", SqlDbType.Decimal);
            paramArray[8].Value     = point;
            paramArray[9]           = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[9].Value     = point_date;
            paramArray[10]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 6);
            paramArray[10].Value    = status_id;
            paramArray[11]          = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[11].Value    = status_date;
            paramArray[12]          = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[12].Value    = create_date;
            paramArray[13]          = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[13].Value    = create_user;

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




        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object prj_ref_id
                        , object point
                        , object point_date
                        , object status_id
                        , object status_date
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO PRJ_DATA  (COMP_ID
                                                   ,EST_ID
                                                   ,ESTTERM_REF_ID
                                                   ,ESTTERM_SUB_ID
                                                   ,ESTTERM_STEP_ID
                                                   ,EST_DEPT_ID
                                                   ,EST_EMP_ID
                                                   ,TGT_DEPT_ID
                                                   ,TGT_EMP_ID
                                                   ,PRJ_REF_ID
                                                   ,POINT
                                                   ,POINT_DATE
                                                   ,STATUS_ID
                                                   ,STATUS_DATE
                                                   ,CREATE_DATE
                                                   ,CREATE_USER)
                                             VALUES
                                                   (@COMP_ID
                                                   ,@EST_ID
                                                   ,@ESTTERM_REF_ID
                                                   ,@ESTTERM_SUB_ID
                                                   ,@ESTTERM_STEP_ID
                                                   ,@EST_DEPT_ID
                                                   ,@EST_EMP_ID
                                                   ,@TGT_DEPT_ID
                                                   ,@TGT_EMP_ID
                                                   ,@PRJ_REF_ID
                                                   ,@POINT
                                                   ,@POINT_DATE
                                                   ,@STATUS_ID
                                                   ,@STATUS_DATE
                                                   ,@CREATE_DATE
                                                   ,@CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[9].Value = prj_ref_id;
            paramArray[10] = CreateDataParameter("@POINT", SqlDbType.Decimal);
            paramArray[10].Value = point;
            paramArray[11] = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[11].Value = point_date;
            paramArray[12] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 6);
            paramArray[12].Value = status_id;
            paramArray[13] = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[13].Value = status_date;
            paramArray[14] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[14].Value = create_date;
            paramArray[15] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[15].Value = create_user;

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
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_dept_id
                        , object est_emp_id
                        , object prj_ref_id
                        , object year_yn
                        , object merge_yn)
        {
            /*
            string query = @"DELETE	PRJ_DATA
	                            FROM        PRJ_DATA         PD
                                    JOIN    EST_TERM_SUB     ESU    ON	(PD.COMP_ID         = ESU.COMP_ID
									                                 AND PD.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
		                            JOIN    EST_TERM_STEP    EST    ON	(PD.COMP_ID         = EST.COMP_ID
									                                 AND PD.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)

                                WHERE   (PD.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (PD.EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    AND	(PD.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(PD.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(PD.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(PD.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(PD.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(PD.PRJ_REF_ID      = @PRJ_REF_ID      OR @PRJ_REF_ID      = 0)
                                    AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN             =''    )
                                    AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN            =''    )";
            */

            string query = @"DELETE	FROM PRJ_DATA
                                WHERE   (COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID          OR @EST_ID          =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(PRJ_REF_ID      = @PRJ_REF_ID      OR @PRJ_REF_ID      = 0)
                                    AND ESTTERM_SUB_ID      IN  (   SELECT      ESTTERM_SUB_ID
                                                                        FROM    EST_TERM_SUB
                                                                        WHERE   COMP_ID     =   @COMP_ID    OR  @COMP_ID    =   0
                                                                            AND YEAR_YN     =   @YEAR_YN    OR  @YEAR_YN    =''     )
                                    AND ESTTERM_STEP_ID     IN  (   SELECT      ESTTERM_STEP_ID
                                                                        FROM    EST_TERM_STEP
                                                                        WHERE   COMP_ID     =   @COMP_ID    OR  @COMP_ID    =   0
                                                                            AND MERGE_YN    =   @MERGE_YN   OR  @MERGE_YN   =''     )
";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value = prj_ref_id;
            paramArray[8] = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[8].Value = year_yn;
            paramArray[9] = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[9].Value = merge_yn;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Count(int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int prj_ref_id)
        {
            string query = @"SELECT COUNT(*) FROM PRJ_DATA
                                WHERE   (COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)	
                                    AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(PRJ_REF_ID      = @PRJ_REF_ID      OR @PRJ_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[7].Value = prj_ref_id;

            try
            {
               int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
