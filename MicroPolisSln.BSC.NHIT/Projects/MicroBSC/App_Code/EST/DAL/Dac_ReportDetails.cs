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
    public class Dac_ReportDetails : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string rpt_dtl_id
                        , string rpt_dtl_name
                        , int comp_id
                        , string from_est_id
                        , string est_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string rpt_itm_id
                        , int seq
                        , string est_job_ids
                        , string est_tgt_type
                        , string estterm_use_yn
                        , string estterm_sub_yn
                        , string estterm_step_yn
                        , string year_yn
                        , string merge_yn
                        , string dept_column_no_use_yn
                        , string estterm_sub_all_use_yn
                        , string estterm_step_all_use_yn
                        , string bg_img_url
                        , string title_img_url
                        , string title_name
                        , string cus_html
                        , int grid_height
                        , string q_style_id
                        , string use_yn
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_REPORT_DETAIL
	                            SET	 RPT_DTL_NAME			= @RPT_DTL_NAME
		                            ,EST_ID					= @EST_ID
                                    ,ESTTERM_SUB_ID         = @ESTTERM_SUB_ID
                                    ,ESTTERM_STEP_ID        = @ESTTERM_STEP_ID
		                            ,RPT_ITM_ID				= @RPT_ITM_ID
		                            ,SEQ					= @SEQ
		                            ,EST_JOB_IDS			= @EST_JOB_IDS
		                            ,EST_TGT_TYPE			= @EST_TGT_TYPE
		                            ,ESTTERM_USE_YN			= @ESTTERM_USE_YN
		                            ,ESTTERM_SUB_YN			= @ESTTERM_SUB_YN
		                            ,ESTTERM_STEP_YN		= @ESTTERM_STEP_YN
		                            ,YEAR_YN				= @YEAR_YN
		                            ,MERGE_YN				= @MERGE_YN
		                            ,DEPT_COLUMN_NO_USE_YN	= @DEPT_COLUMN_NO_USE_YN
                                    ,ESTTERM_SUB_ALL_USE_YN = @ESTTERM_SUB_ALL_USE_YN
                                    ,ESTTERM_STEP_ALL_USE_YN= @ESTTERM_STEP_ALL_USE_YN
		                            ,BG_IMG_URL				= @BG_IMG_URL
		                            ,TITLE_IMG_URL			= @TITLE_IMG_URL
		                            ,TITLE_NAME				= @TITLE_NAME
                                    ,CUS_HTML               = @CUS_HTML
                                    ,GRID_HEIGHT            = @GRID_HEIGHT
		                            ,Q_STYLE_ID				= @Q_STYLE_ID
		                            ,USE_YN					= @USE_YN
		                            ,UPDATE_DATE			= @UPDATE_DATE
		                            ,UPDATE_USER			= @UPDATE_USER
	                            WHERE	RPT_DTL_ID			= @RPT_DTL_ID
                                    AND COMP_ID				= @COMP_ID
                                    AND FROM_EST_ID			= @FROM_EST_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(28);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_DTL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = rpt_dtl_id;
	        paramArray[1] 		= CreateDataParameter("@RPT_DTL_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = rpt_dtl_name;
	        paramArray[2] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[2].Value = comp_id;
            paramArray[3] 		= CreateDataParameter("@FROM_EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = from_est_id;
	        paramArray[4] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[4].Value = est_id;
            paramArray[5] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[5].Value = estterm_sub_id;
            paramArray[6] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[6].Value = estterm_step_id;
	        paramArray[7] 		= CreateDataParameter("@RPT_ITM_ID", SqlDbType.NVarChar, 20);
	        paramArray[7].Value = rpt_itm_id;
	        paramArray[8] 		= CreateDataParameter("@SEQ", SqlDbType.Int);
	        paramArray[8].Value = seq;
	        paramArray[9] 		= CreateDataParameter("@EST_JOB_IDS", SqlDbType.NVarChar, 200);
	        paramArray[9].Value = est_job_ids;
	        paramArray[10] 		= CreateDataParameter("@EST_TGT_TYPE", SqlDbType.NVarChar, 100);
	        paramArray[10].Value = est_tgt_type;
	        paramArray[11] 		= CreateDataParameter("@ESTTERM_USE_YN", SqlDbType.NChar);
	        paramArray[11].Value = estterm_use_yn;
	        paramArray[12] 		= CreateDataParameter("@ESTTERM_SUB_YN", SqlDbType.NChar);
	        paramArray[12].Value = estterm_sub_yn;
	        paramArray[13] 		= CreateDataParameter("@ESTTERM_STEP_YN", SqlDbType.NChar);
	        paramArray[13].Value= estterm_step_yn;
	        paramArray[14] 		= CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
	        paramArray[14].Value= year_yn;
	        paramArray[15] 		= CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
	        paramArray[15].Value= merge_yn;
	        paramArray[16] 		= CreateDataParameter("@DEPT_COLUMN_NO_USE_YN", SqlDbType.NChar);
	        paramArray[16].Value= dept_column_no_use_yn;
            paramArray[17] 		= CreateDataParameter("@ESTTERM_SUB_ALL_USE_YN", SqlDbType.NChar);
	        paramArray[17].Value= estterm_sub_all_use_yn;
            paramArray[18] 		= CreateDataParameter("@ESTTERM_STEP_ALL_USE_YN", SqlDbType.NChar);
	        paramArray[18].Value= estterm_step_all_use_yn;
	        paramArray[19] 		= CreateDataParameter("@BG_IMG_URL", SqlDbType.NVarChar, 200);
	        paramArray[19].Value= bg_img_url;
	        paramArray[20] 		= CreateDataParameter("@TITLE_IMG_URL", SqlDbType.NVarChar, 200);
	        paramArray[20].Value= title_img_url;
	        paramArray[21] 		= CreateDataParameter("@TITLE_NAME", SqlDbType.NVarChar, 200);
	        paramArray[21].Value= title_name;
            paramArray[22] 		= CreateDataParameter("@CUS_HTML", SqlDbType.NVarChar);
	        paramArray[22].Value= cus_html;
            paramArray[23] 		= CreateDataParameter("@GRID_HEIGHT", SqlDbType.Int);
	        paramArray[23].Value= grid_height;
	        paramArray[24] 		= CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar, 12);
	        paramArray[24].Value= q_style_id;
	        paramArray[25] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[25].Value= use_yn;
	        paramArray[26] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[26].Value= update_date;
	        paramArray[27] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[27].Value= update_user;
         
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
         
        public DataSet Select(string rpt_dtl_id
                            , int comp_id
                            , string from_est_id
                            , string use_yn)
        {
            string query = @"SELECT	 RPT_DTL_ID
		                            ,RPT_DTL_NAME
		                            ,COMP_ID
                                    ,FROM_EST_ID
		                            ,EST_ID
                                    ,ESTTERM_SUB_ID
                                    ,ESTTERM_STEP_ID
		                            ,RPT_ITM_ID
		                            ,SEQ
		                            ,EST_JOB_IDS
		                            ,EST_TGT_TYPE
		                            ,ESTTERM_USE_YN
		                            ,ESTTERM_SUB_YN
		                            ,ESTTERM_STEP_YN
		                            ,YEAR_YN
		                            ,MERGE_YN
		                            ,DEPT_COLUMN_NO_USE_YN
                                    ,ESTTERM_SUB_ALL_USE_YN
                                    ,ESTTERM_STEP_ALL_USE_YN
		                            ,BG_IMG_URL
		                            ,TITLE_IMG_URL
		                            ,TITLE_NAME
                                    ,CUS_HTML
                                    ,GRID_HEIGHT
		                            ,Q_STYLE_ID
		                            ,USE_YN
		                            ,CREATE_DATE
		                            ,CREATE_USER
		                            ,UPDATE_DATE
		                            ,UPDATE_USER
	                            FROM	EST_REPORT_DETAIL 
		                            WHERE	(RPT_DTL_ID = @RPT_DTL_ID	OR @RPT_DTL_ID	    =''    )
                                        AND (COMP_ID	= @COMP_ID      OR @COMP_ID     = 0)
                                        AND (FROM_EST_ID= @FROM_EST_ID  OR @FROM_EST_ID     =''    )
			                            AND (USE_YN		= @USE_YN		OR @USE_YN		    =''    )
                                    ORDER BY SEQ";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_DTL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = rpt_dtl_id;
            paramArray[1] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[1].Value = comp_id;
            paramArray[2] 		= CreateDataParameter("@FROM_EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = from_est_id;
	        paramArray[3] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[3].Value = use_yn;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "REPORTDETAILGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string rpt_dtl_id
                        , string rpt_dtl_name
                        , int comp_id
                        , string from_est_id
                        , string est_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , string rpt_itm_id
                        , int seq
                        , string est_job_ids
                        , string est_tgt_type
                        , string estterm_use_yn
                        , string estterm_sub_yn
                        , string estterm_step_yn
                        , string year_yn
                        , string merge_yn
                        , string dept_column_no_use_yn
                        , string estterm_sub_all_use_yn
                        , string estterm_step_all_use_yn
                        , string bg_img_url
                        , string title_img_url
                        , string title_name
                        , string cus_html
                        , int grid_height
                        , string q_style_id
                        , string use_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_REPORT_DETAIL(RPT_DTL_ID
			                                                ,RPT_DTL_NAME
			                                                ,COMP_ID
                                                            ,FROM_EST_ID
			                                                ,EST_ID
                                                            ,ESTTERM_SUB_ID
                                                            ,ESTTERM_STEP_ID
			                                                ,RPT_ITM_ID
			                                                ,SEQ
			                                                ,EST_JOB_IDS
			                                                ,EST_TGT_TYPE
			                                                ,ESTTERM_USE_YN
			                                                ,ESTTERM_SUB_YN
			                                                ,ESTTERM_STEP_YN
			                                                ,YEAR_YN
			                                                ,MERGE_YN
			                                                ,DEPT_COLUMN_NO_USE_YN
                                                            ,ESTTERM_SUB_ALL_USE_YN
                                                            ,ESTTERM_STEP_ALL_USE_YN
			                                                ,BG_IMG_URL
			                                                ,TITLE_IMG_URL
			                                                ,TITLE_NAME
                                                            ,CUS_HTML
                                                            ,GRID_HEIGHT
			                                                ,Q_STYLE_ID
			                                                ,USE_YN
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@RPT_DTL_ID
			                                                ,@RPT_DTL_NAME
			                                                ,@COMP_ID
                                                            ,@FROM_EST_ID
			                                                ,@EST_ID
                                                            ,@ESTTERM_SUB_ID
                                                            ,@ESTTERM_STEP_ID
			                                                ,@RPT_ITM_ID
			                                                ,@SEQ
			                                                ,@EST_JOB_IDS
			                                                ,@EST_TGT_TYPE
			                                                ,@ESTTERM_USE_YN
			                                                ,@ESTTERM_SUB_YN
			                                                ,@ESTTERM_STEP_YN
			                                                ,@YEAR_YN
			                                                ,@MERGE_YN
			                                                ,@DEPT_COLUMN_NO_USE_YN
                                                            ,@ESTTERM_SUB_ALL_USE_YN
                                                            ,@ESTTERM_STEP_ALL_USE_YN
			                                                ,@BG_IMG_URL
			                                                ,@TITLE_IMG_URL
			                                                ,@TITLE_NAME
                                                            ,@CUS_HTML
                                                            ,@GRID_HEIGHT
			                                                ,@Q_STYLE_ID
			                                                ,@USE_YN
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,NULL
			                                                ,NULL
			                                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(28);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_DTL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = rpt_dtl_id;
	        paramArray[1] 		= CreateDataParameter("@RPT_DTL_NAME", SqlDbType.NVarChar, 200);
	        paramArray[1].Value = rpt_dtl_name;
	        paramArray[2] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[2].Value = comp_id;
            paramArray[3] 		= CreateDataParameter("@FROM_EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[3].Value = from_est_id;
	        paramArray[4] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[4].Value = est_id;
            paramArray[5] 		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
	        paramArray[5].Value = estterm_sub_id;
            paramArray[6] 		= CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
	        paramArray[6].Value = estterm_step_id;
	        paramArray[7] 		= CreateDataParameter("@RPT_ITM_ID", SqlDbType.NVarChar, 20);
	        paramArray[7].Value = rpt_itm_id;
	        paramArray[8] 		= CreateDataParameter("@SEQ", SqlDbType.Int);
	        paramArray[8].Value = seq;
	        paramArray[9] 		= CreateDataParameter("@EST_JOB_IDS", SqlDbType.NVarChar, 200);
	        paramArray[9].Value = est_job_ids;
	        paramArray[10] 		= CreateDataParameter("@EST_TGT_TYPE", SqlDbType.NVarChar, 100);
	        paramArray[10].Value = est_tgt_type;
	        paramArray[11] 		= CreateDataParameter("@ESTTERM_USE_YN", SqlDbType.NChar);
	        paramArray[11].Value = estterm_use_yn;
	        paramArray[12] 		= CreateDataParameter("@ESTTERM_SUB_YN", SqlDbType.NChar);
	        paramArray[12].Value = estterm_sub_yn;
	        paramArray[13] 		= CreateDataParameter("@ESTTERM_STEP_YN", SqlDbType.NChar);
	        paramArray[13].Value= estterm_step_yn;
	        paramArray[14] 		= CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
	        paramArray[14].Value= year_yn;
	        paramArray[15] 		= CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
	        paramArray[15].Value= merge_yn;
	        paramArray[16] 		= CreateDataParameter("@DEPT_COLUMN_NO_USE_YN", SqlDbType.NChar);
	        paramArray[16].Value= dept_column_no_use_yn;
            paramArray[17] 		= CreateDataParameter("@ESTTERM_SUB_ALL_USE_YN", SqlDbType.NChar);
	        paramArray[17].Value= estterm_sub_all_use_yn;
            paramArray[18] 		= CreateDataParameter("@ESTTERM_STEP_ALL_USE_YN", SqlDbType.NChar);
	        paramArray[18].Value= estterm_step_all_use_yn;
	        paramArray[19] 		= CreateDataParameter("@BG_IMG_URL", SqlDbType.NVarChar, 200);
	        paramArray[19].Value= bg_img_url;
	        paramArray[20] 		= CreateDataParameter("@TITLE_IMG_URL", SqlDbType.NVarChar, 200);
	        paramArray[20].Value= title_img_url;
	        paramArray[21] 		= CreateDataParameter("@TITLE_NAME", SqlDbType.NVarChar, 200);
	        paramArray[21].Value= title_name;
            paramArray[22] 		= CreateDataParameter("@CUS_HTML", SqlDbType.NVarChar);
	        paramArray[22].Value= cus_html;
            paramArray[23] 		= CreateDataParameter("@GRID_HEIGHT", SqlDbType.Int);
	        paramArray[23].Value= grid_height;
	        paramArray[24] 		= CreateDataParameter("@Q_STYLE_ID", SqlDbType.NVarChar, 12);
	        paramArray[24].Value= q_style_id;
	        paramArray[25] 		= CreateDataParameter("@USE_YN", SqlDbType.NChar);
	        paramArray[25].Value= use_yn;
	        paramArray[26] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[26].Value= create_date;
	        paramArray[27] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[27].Value= create_user;
         
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

        public DataSet GetReportIndividal(int comp_id
                                        , int estterm_ref_id
                                        , string est_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string estid_1
                                        , string estid_2
                                        , string gongid
                                        , string mboid
                                        , int tgt_emp_id
                                        , string is_team_kpi
                                        , string yid1
                                        , string yid2
                                        , string yid3)
        {
            string strQuery = @"
--[0]
SELECT   A.POINT        AS POINT_1
        ,A.GRADE_ID     AS POINT_2
        ,B.POINT        AS POINT_3
        ,C.POINT        AS POINT_4
        ,ISNULL(D.POINT, 0)        AS YVALUE1
        ,ISNULL(E.POINT, 0)        AS YVALUE2
        ,ISNULL(F.POINT, 0)        AS YVALUE3
FROM    EST_DATA    A
LEFT OUTER JOIN EST_DATA    B   ON  B.COMP_ID         = A.COMP_ID
                                AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND B.EST_ID          = @ESTID_1
                                AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND B.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND B.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    C   ON  C.COMP_ID         = A.COMP_ID
                                AND C.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND C.EST_ID          = @ESTID_2
                                AND C.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND C.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND C.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    D   ON  D.COMP_ID         = A.COMP_ID
                                AND D.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND D.EST_ID          = @YID1
                                AND D.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND D.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND D.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    E   ON  E.COMP_ID         = A.COMP_ID
                                AND E.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND E.EST_ID          = @YID2
                                AND E.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND E.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND E.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    F   ON  F.COMP_ID         = A.COMP_ID
                                AND F.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND F.EST_ID          = @YID3
                                AND F.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND F.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND F.TGT_EMP_ID      = A.TGT_EMP_ID
WHERE   A.COMP_ID         = @COMP_ID
    AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND A.EST_ID          = @EST_ID
    AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND A.TGT_EMP_ID      = @TGT_EMP_ID

--[1]
SELECT   A.KPI_REF_ID
        ,C.KPI_NAME
        ,ISNULL(A.WEIGHT, 0) AS WEIGHT
        ,CASE WHEN ISNULL(G.TARGET_TS, 0) = 0 THEN 0 ELSE ISNULL(H.RESULT_TS / G.TARGET_TS * 100, 0) END   AS RESULT
        ,SUM(ISNULL(ISNULL(CONVERT(NUMERIC(10, 4), ISNULL(D2.SEGMENT1, 0)), 0) * ISNULL(E.WEIGHT, 0) / 100, 0))   AS POINT
FROM    BSC_MBO_KPI_WEIGHT  A
LEFT OUTER JOIN BSC_KPI_INFO    B
    ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
    AND B.KPI_REF_ID        = A.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    C
    ON  C.KPI_POOL_REF_ID   = B.KPI_POOL_REF_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT    D
    ON  D.COMP_ID           = @COMP_ID
    AND D.EST_ID            = '3GA'
    AND D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
    AND D.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND D.KPI_REF_ID        = A.KPI_REF_ID
    AND D.TGT_EMP_ID        = A.EMP_REF_ID
LEFT OUTER JOIN COM_CODE_INFO           D2
    ON  D2.CATEGORY_CODE    = 'BS015'
    AND D2.ETC_CODE         = D.SCORE_GRADE
LEFT OUTER JOIN EST_TERM_STEP_EST_MAP   E
    ON  E.COMP_ID           = D.COMP_ID
    AND E.EST_ID            = D.EST_ID
    AND E.ESTTERM_STEP_ID   = D.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                            AND F.KPI_REF_ID        = D.KPI_REF_ID
                                            AND F.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          G   ON  G.ESTTERM_REF_ID    = F.ESTTERM_REF_ID
                                            AND G.KPI_REF_ID        = F.KPI_REF_ID
                                            AND G.KPI_TARGET_VERSION_ID = F.KPI_TARGET_VERSION_ID
                                            AND G.YMD                   = D.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          H   ON  H.ESTTERM_REF_ID    = G.ESTTERM_REF_ID
                                            AND H.KPI_REF_ID        = G.KPI_REF_ID
                                            AND H.YMD               = G.YMD
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.EMP_REF_ID        = @TGT_EMP_ID
    AND A.USE_YN            = 'Y'
    AND (B.IS_TEAM_KPI  = @IS_TEAM_KPI OR @IS_TEAM_KPI      =''    )
GROUP BY A.KPI_REF_ID, C.KPI_NAME, ISNULL(A.WEIGHT, 0), CASE WHEN ISNULL(G.TARGET_TS, 0) = 0 THEN 0 ELSE ISNULL(H.RESULT_TS / G.TARGET_TS * 100, 0) END
ORDER BY A.KPI_REF_ID

--[2]역량평가, 평가항목별점수(공통역량평가)
SELECT A.Q_DFN_ID, A.Q_DFN_NAME, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.MY_POINT, 0))) AS MY_POINT, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.AVG_POINT, 0))) AS AVG_POINT
FROM (
	SELECT D.Q_DFN_ID, D.Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	LEFT OUTER JOIN EST_QUESTION_DEFINE		D
		ON		D.Q_DFN_ID	= C.Q_DFN_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID1
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY D.Q_DFN_ID, D.Q_DFN_NAME

	UNION ALL

	SELECT D.Q_DFN_ID, D.Q_DFN_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	LEFT OUTER JOIN EST_QUESTION_DEFINE		D
		ON		D.Q_DFN_ID	= C.Q_DFN_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID1
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY D.Q_DFN_ID, D.Q_DFN_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME

--[3]역량평가, 평가항목별점수(직무역량평가)
SELECT A.Q_DFN_ID, A.Q_DFN_NAME, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.MY_POINT, 0))) AS MY_POINT, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.AVG_POINT, 0))) AS AVG_POINT
FROM (
	SELECT C.Q_SBJ_ID AS Q_DFN_ID, C.Q_SBJ_NAME AS Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID2
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME

	UNION ALL

	SELECT C.Q_SBJ_ID, C.Q_SBJ_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	INNER JOIN EST_QUESTION_DATA    D
        ON      D.COMP_ID   = @COMP_ID
            AND D.EST_ID	= @YID2
		    AND	D.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		    AND	D.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		    AND	D.ESTTERM_STEP_ID	> 1
		    AND	D.TGT_EMP_ID		= @TGT_EMP_ID
            AND D.Q_SBJ_ID          = A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID2
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME

--[4]역량평가, 평가항목별점수(리더역량평가)
SELECT A.Q_DFN_ID, A.Q_DFN_NAME, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.MY_POINT, 0))) AS MY_POINT, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.AVG_POINT, 0))) AS AVG_POINT
FROM (
	SELECT C.Q_SBJ_ID AS Q_DFN_ID, C.Q_SBJ_NAME AS Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID3
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME

	UNION ALL

	SELECT C.Q_SBJ_ID, C.Q_SBJ_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	INNER JOIN EST_QUESTION_DATA    D
        ON      D.COMP_ID   = @COMP_ID
            AND D.EST_ID	= @YID3
		    AND	D.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		    AND	D.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		    AND	D.ESTTERM_STEP_ID	> 1
		    AND	D.TGT_EMP_ID		= @TGT_EMP_ID
            AND D.Q_SBJ_ID          = A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID3
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME

--[5]업적평가(공헌도평가)
SELECT A.Q_DFN_ID, A.Q_DFN_NAME, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.MY_POINT, 0))) AS MY_POINT, CONVERT(NUMERIC(10, 2), SUM(ISNULL(A.AVG_POINT, 0))) AS AVG_POINT
FROM (
	SELECT C.Q_SBJ_ID AS Q_DFN_ID, C.Q_SBJ_NAME AS Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @GONGID
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME

	UNION ALL

	SELECT C.Q_SBJ_ID, C.Q_SBJ_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	INNER JOIN EST_QUESTION_DATA    D
        ON      D.COMP_ID   = @COMP_ID
            AND D.EST_ID	= @GONGID
		    AND	D.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		    AND	D.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		    AND	D.ESTTERM_STEP_ID	> 1
		    AND	D.TGT_EMP_ID		= @TGT_EMP_ID
            AND D.Q_SBJ_ID          = A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @GONGID
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME
";
            IDbDataParameter[] paramArray = CreateDataParameters(14);
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[2].Value = est_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@GONGID", SqlDbType.VarChar);
            paramArray[5].Value = gongid;
            paramArray[6] = CreateDataParameter("@MBOID", SqlDbType.VarChar);
            paramArray[6].Value = mboid;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;
            paramArray[8] = CreateDataParameter("@IS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[8].Value = is_team_kpi;
            paramArray[9] = CreateDataParameter("@YID1", SqlDbType.VarChar);
            paramArray[9].Value = yid1;
            paramArray[10] = CreateDataParameter("@YID2", SqlDbType.VarChar);
            paramArray[10].Value = yid2;
            paramArray[11] = CreateDataParameter("@YID3", SqlDbType.VarChar);
            paramArray[11].Value = yid3;
            paramArray[12] = CreateDataParameter("@ESTID_1", SqlDbType.VarChar);
            paramArray[12].Value = estid_1;
            paramArray[13] = CreateDataParameter("@ESTID_2", SqlDbType.VarChar);
            paramArray[13].Value = estid_2;

            return DbAgentObj.FillDataSet(strQuery, "INDIVIDAL_EST_REPORT", null, paramArray, CommandType.Text);
        }
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string rpt_dtl_id
                        , int comp_id
                        , string from_est_id)
        {
            string query = @"DELETE	EST_REPORT_DETAIL
	                            WHERE	(RPT_DTL_ID = @RPT_DTL_ID   OR @RPT_DTL_ID      =''    )
                                    AND (COMP_ID	= @COMP_ID      OR @COMP_ID     = 0)
                                    AND (FROM_EST_ID= @FROM_EST_ID  OR @FROM_EST_ID     =''    )";

	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		= CreateDataParameter("@RPT_DTL_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = rpt_dtl_id;
            paramArray[1] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[1].Value = comp_id;
            paramArray[2] 		= CreateDataParameter("@FROM_EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[2].Value = from_est_id;

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
