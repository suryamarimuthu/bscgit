using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

/// <summary>
/// Dac_Bsc_Kpi_Result의 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Result Dac 클래스
/// Class 내용		@ Bsc_Kpi_Result Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Result : DbAgentBase
    {
    
        #region ========================== 멀티 DB 작업 ============================

        public DataSet SelectKpiList(int iestterm_ref_id, int iest_dept_ref_id, string iymd, int itxr_user)
        {
            string strQuery = @"

SELECT T0.ESTTERM_REF_ID, T0.YMD, T0.EST_DEPT_REF_ID, M1.DEPT_NAME
				, T0.MAP_VERSION_ID, T1.MAP_VERSION_NAME, T1.DEPT_VISION
				, T2.STG_REF_ID, T2.KPI_REF_ID, T2.SORT_ORDER, T2.WEIGHT
				, T3.KPI_CODE, T3.KPI_POOL_REF_ID, M10.KPI_NAME, T3.RESULT_ACHIEVEMENT_TYPE
				, T3.RESULT_INPUT_TYPE, M5.CODE_NAME INPUT_TYPE_NAME
				, T3.RESULT_TERM_TYPE, M6.CODE_NAME RESULT_TERM_NAME
				, T3.RESULT_TS_CALC_TYPE, M7.CODE_NAME RESULT_TS_NAME
				, T3.UNIT_TYPE_REF_ID, M8.UNIT UNIT_NAME
				, T3.ROLLUP_SCORE_YN, T3.ROLLUP_TARGET_YN
				, T3.CHAMPION_EMP_ID, M2.EMP_NAME CHAMP_EMP_NAME, M4.DEPT_NAME ORG_DEPT_NAME
				, T4.TARGET_MS, T4.TARGET_TS, T5.CAL_RESULT_MS, T5.CAL_RESULT_TS
				, T5.RESULT_MS, T5.RESULT_TS, M9.CLOSE_YN, M9.RELEASE_YN, T5.APP_REF_ID
			FROM BSC_MAP_TERM T0 INNER JOIN BSC_MAP_INFO T1 
				ON T0.ESTTERM_REF_ID = T1.ESTTERM_REF_ID AND T0.EST_DEPT_REF_ID = T1.EST_DEPT_REF_ID AND T0.MAP_VERSION_ID = T1.MAP_VERSION_ID
				INNER JOIN BSC_MAP_KPI T2
				ON T1.ESTTERM_REF_ID = T2.ESTTERM_REF_ID AND T1.EST_DEPT_REF_ID = T2.EST_DEPT_REF_ID AND T1.MAP_VERSION_ID = T2.MAP_VERSION_ID
				INNER JOIN BSC_KPI_TERM KT
				ON T2.ESTTERM_REF_ID = KT.ESTTERM_REF_ID AND T0.YMD = KT.YMD AND T2.KPI_REF_ID = KT.KPI_REF_ID
				LEFT OUTER JOIN BSC_KPI_INFO T3
				ON T2.ESTTERM_REF_ID = T3.ESTTERM_REF_ID AND T2.KPI_REF_ID = T3.KPI_REF_ID
				LEFT OUTER JOIN 
                
                                (SELECT TARGET_MS
                                      , TARGET_TS
                                      , ESTTERM_REF_ID
                                      , KPI_REF_ID
                                      , YMD
                                      , KPI_TARGET_VERSION_ID
                                  FROM BSC_KPI_TARGET A
                                 WHERE KPI_TARGET_VERSION_ID IN (SELECT MAX(KPI_TARGET_VERSION_ID) FROM BSC_KPI_TARGET_VERSION B
                                                                 WHERE A.ESTTERM_REF_ID = B.ESTTERM_REF_ID
                                                                   AND A.KPI_REF_ID     = B.KPI_REF_ID)
                                 ) T4
                                 
                ON T3.ESTTERM_REF_ID = T4.ESTTERM_REF_ID AND T3.KPI_REF_ID = T4.KPI_REF_ID AND T4.YMD = T0.YMD
--                AND T4.KPI_TARGET_VERSION_ID IN (SELECT MAX(S.KPI_TARGET_VERSION_ID) FROM BSC_KPI_TARGET_VERSION S
--                                                     WHERE S.ESTTERM_REF_ID = T4.ESTTERM_REF_ID
--                                                       AND S.KPI_REF_ID = T4.KPI_REF_ID)
				LEFT OUTER JOIN BSC_KPI_RESULT T5
				ON T3.ESTTERM_REF_ID = T5.ESTTERM_REF_ID AND T3.KPI_REF_ID = T5.KPI_REF_ID AND T5.YMD = T0.YMD
				LEFT OUTER JOIN EST_DEPT_INFO M1
				ON T0.EST_DEPT_REF_ID = M1.EST_DEPT_REF_ID
				LEFT OUTER JOIN COM_EMP_INFO M2
				ON T3.CHAMPION_EMP_ID = M2.EMP_REF_ID
				LEFT OUTER JOIN REL_DEPT_EMP M3
				ON M2.EMP_REF_ID = M3.EMP_REF_ID
				LEFT OUTER JOIN COM_DEPT_INFO M4
				ON M3.DEPT_REF_ID = M4.DEPT_REF_ID
				LEFT OUTER JOIN COM_CODE_INFO M5
				ON T3.RESULT_INPUT_TYPE = M5.ETC_CODE AND M5.CATEGORY_CODE = 'BS001'
				LEFT OUTER JOIN COM_CODE_INFO M6
				ON T3.RESULT_TERM_TYPE = M6.ETC_CODE AND M6.CATEGORY_CODE = 'BS005'
				LEFT OUTER JOIN COM_CODE_INFO M7
				ON RESULT_TS_CALC_TYPE = M7.ETC_CODE AND M7.CATEGORY_CODE = 'BS002'
				LEFT OUTER JOIN COM_UNIT_TYPE_INFO M8
				ON T3.UNIT_TYPE_REF_ID = M8.UNIT_TYPE_REF_ID
				LEFT OUTER JOIN BSC_TERM_DETAIL M9
				ON T0.ESTTERM_REF_ID = M9.ESTTERM_REF_ID
					AND M9.YMD = T0.YMD
				LEFT OUTER JOIN BSC_KPI_POOL M10
				ON T3.KPI_POOL_REF_ID = M10.KPI_POOL_REF_ID
			WHERE T0.ESTTERM_REF_ID = @iESTTERM_REF_ID  
				AND T0.EST_DEPT_REF_ID = @iEST_DEPT_REF_ID
				AND T0.YMD = @iYMD
				AND (T3.CHAMPION_EMP_ID = @iTXR_USER OR @iTXR_USER = 0)
				AND T1.USE_YN = 'Y'
				AND KT.CHECK_YN = 'Y'
			ORDER BY T3.KPI_CODE

";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iest_dept_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_RESULT", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectKpiResult_DB(object estterm_ref_id
                                        , object kpi_ref_id
                                        , object ymd)
        {
            string strQuery = @"
SELECT ESTTERM_REF_ID  
    ,KPI_REF_ID      
    ,YMD             
    ,RESULT_MS       
    ,RESULT_TS       
    ,SEQUENCE        
    ,CHECKSTATUS     
    ,CHECK_DATE      
    ,CAL_RESULT_MS   
    ,CAL_RESULT_TS   
    ,CAL_APPLY_YN    
    ,CAL_APPLY_REASON
    ,CAUSE_TEXT_MS  
    ,CAUSE_TEXT_TS  
    ,CAUSE_FILE_ID  
    ,MEASURE_TEXT_MS
    ,MEASURE_TEXT_TS
    ,MEASURE_FILE_ID
    ,REMARK        
    ,CREATE_DATE
    ,CREATE_USER
    ,UPDATE_DATE
    ,UPDATE_USER
FROM BSC_KPI_RESULT 
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
  AND KPI_REF_ID     = @KPI_REF_ID 
  AND YMD            = @YMD

";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2].Value = ymd;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_RESULT", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectKpiTargetList(int iestterm_ref_id
                                         , int iest_dept_ref_id
                                         , string iymd
                                         , int itxr_user)
        {

            string strQuery = @"
SELECT T0.ESTTERM_REF_ID, T0.YMD, SUBSTRING(T0.YMD, 1, 4) PER_YEAR, SUBSTRING(T0.YMD, 5, 2) PER_MONTH
			, T0.EST_DEPT_REF_ID, M1.DEPT_NAME
			, T0.MAP_VERSION_ID, T1.MAP_VERSION_NAME, T1.DEPT_VISION
			, T2.STG_REF_ID, T2.KPI_REF_ID, T2.SORT_ORDER, T2.WEIGHT
			, T3.KPI_CODE, T3.KPI_POOL_REF_ID, M10.KPI_NAME, T3.RESULT_ACHIEVEMENT_TYPE
			, T3.RESULT_INPUT_TYPE, M5.CODE_NAME INPUT_TYPE_NAME
			, T3.RESULT_TERM_TYPE, M6.CODE_NAME RESULT_TERM_NAME
			, T3.RESULT_TS_CALC_TYPE, M7.CODE_NAME RESULT_TS_NAME
			, T3.UNIT_TYPE_REF_ID, M8.UNIT UNIT_NAME
			, T3.ROLLUP_SCORE_YN, T3.ROLLUP_TARGET_YN
			, T3.CHAMPION_EMP_ID, M2.EMP_NAME CHAMP_EMP_NAME, M4.DEPT_NAME ORG_DEPT_NAME
			, T4.KPI_TARGET_VERSION_ID
			, T4.M01_TARGET_MM, T4.M01_CHECK, T4.M01_MS, T4.M01_TS
			, T4.M02_TARGET_MM, T4.M02_CHECK, T4.M02_MS, T4.M02_TS
			, T4.M03_TARGET_MM, T4.M03_CHECK, T4.M03_MS, T4.M03_TS
			, T4.M04_TARGET_MM, T4.M04_CHECK, T4.M04_MS, T4.M04_TS
			, T4.M05_TARGET_MM, T4.M05_CHECK, T4.M05_MS, T4.M05_TS
			, T4.M06_TARGET_MM, T4.M06_CHECK, T4.M06_MS, T4.M06_TS
			, T4.M07_TARGET_MM, T4.M07_CHECK, T4.M07_MS, T4.M07_TS
			, T4.M08_TARGET_MM, T4.M08_CHECK, T4.M08_MS, T4.M08_TS
			, T4.M09_TARGET_MM, T4.M09_CHECK, T4.M09_MS, T4.M09_TS
			, T4.M10_TARGET_MM, T4.M10_CHECK, T4.M10_MS, T4.M10_TS
			, T4.M11_TARGET_MM, T4.M11_CHECK, T4.M11_MS, T4.M11_TS
			, T4.M12_TARGET_MM, T4.M12_CHECK, T4.M12_MS, T4.M12_TS
			, M9.CLOSE_YN, M9.RELEASE_YN
		FROM BSC_MAP_TERM T0 INNER JOIN BSC_MAP_INFO T1 ON (    T0.ESTTERM_REF_ID  = T1.ESTTERM_REF_ID 
                                                            AND T0.EST_DEPT_REF_ID = T1.EST_DEPT_REF_ID 
                                                            AND T0.MAP_VERSION_ID  = T1.MAP_VERSION_ID )
			                 INNER JOIN BSC_MAP_KPI T2  ON (    T1.ESTTERM_REF_ID  = T2.ESTTERM_REF_ID 
                                                            AND T1.EST_DEPT_REF_ID = T2.EST_DEPT_REF_ID 
                                                            AND T1.MAP_VERSION_ID  = T2.MAP_VERSION_ID )
			           LEFT OUTER JOIN BSC_KPI_INFO T3  ON (    T2.ESTTERM_REF_ID  = T3.ESTTERM_REF_ID 
                                                            AND T2.KPI_REF_ID      = T3.KPI_REF_ID )
			           LEFT OUTER JOIN (SELECT T1.ESTTERM_REF_ID, T1.KPI_REF_ID, MAX(T1.KPI_TARGET_VERSION_ID) KPI_TARGET_VERSION_ID
					, '01' M01_TARGET_MM, MAX(CASE WHEN T2.MM = '01' THEN T3.CHECK_YN ELSE 'N' END) M01_CHECK, MAX(CASE WHEN T2.MM = '01' THEN T1.TARGET_MS ELSE NULL END) M01_MS, MAX(CASE WHEN T2.MM = '01' THEN T1.TARGET_TS ELSE NULL END) M01_TS
					, '02' M02_TARGET_MM, MAX(CASE WHEN T2.MM = '02' THEN T3.CHECK_YN ELSE 'N' END) M02_CHECK, MAX(CASE WHEN T2.MM = '02' THEN T1.TARGET_MS ELSE NULL END) M02_MS, MAX(CASE WHEN T2.MM = '02' THEN T1.TARGET_TS ELSE NULL END) M02_TS
					, '03' M03_TARGET_MM, MAX(CASE WHEN T2.MM = '03' THEN T3.CHECK_YN ELSE 'N' END) M03_CHECK, MAX(CASE WHEN T2.MM = '03' THEN T1.TARGET_MS ELSE NULL END) M03_MS, MAX(CASE WHEN T2.MM = '03' THEN T1.TARGET_TS ELSE NULL END) M03_TS
					, '04' M04_TARGET_MM, MAX(CASE WHEN T2.MM = '04' THEN T3.CHECK_YN ELSE 'N' END) M04_CHECK, MAX(CASE WHEN T2.MM = '04' THEN T1.TARGET_MS ELSE NULL END) M04_MS, MAX(CASE WHEN T2.MM = '04' THEN T1.TARGET_TS ELSE NULL END) M04_TS
					, '05' M05_TARGET_MM, MAX(CASE WHEN T2.MM = '05' THEN T3.CHECK_YN ELSE 'N' END) M05_CHECK, MAX(CASE WHEN T2.MM = '05' THEN T1.TARGET_MS ELSE NULL END) M05_MS, MAX(CASE WHEN T2.MM = '05' THEN T1.TARGET_TS ELSE NULL END) M05_TS
					, '06' M06_TARGET_MM, MAX(CASE WHEN T2.MM = '06' THEN T3.CHECK_YN ELSE 'N' END) M06_CHECK, MAX(CASE WHEN T2.MM = '06' THEN T1.TARGET_MS ELSE NULL END) M06_MS, MAX(CASE WHEN T2.MM = '06' THEN T1.TARGET_TS ELSE NULL END) M06_TS
					, '07' M07_TARGET_MM, MAX(CASE WHEN T2.MM = '07' THEN T3.CHECK_YN ELSE 'N' END) M07_CHECK, MAX(CASE WHEN T2.MM = '07' THEN T1.TARGET_MS ELSE NULL END) M07_MS, MAX(CASE WHEN T2.MM = '07' THEN T1.TARGET_TS ELSE NULL END) M07_TS
					, '08' M08_TARGET_MM, MAX(CASE WHEN T2.MM = '08' THEN T3.CHECK_YN ELSE 'N' END) M08_CHECK, MAX(CASE WHEN T2.MM = '08' THEN T1.TARGET_MS ELSE NULL END) M08_MS, MAX(CASE WHEN T2.MM = '08' THEN T1.TARGET_TS ELSE NULL END) M08_TS
					, '09' M09_TARGET_MM, MAX(CASE WHEN T2.MM = '09' THEN T3.CHECK_YN ELSE 'N' END) M09_CHECK, MAX(CASE WHEN T2.MM = '09' THEN T1.TARGET_MS ELSE NULL END) M09_MS, MAX(CASE WHEN T2.MM = '09' THEN T1.TARGET_TS ELSE NULL END) M09_TS
					, '10' M10_TARGET_MM, MAX(CASE WHEN T2.MM = '10' THEN T3.CHECK_YN ELSE 'N' END) M10_CHECK, MAX(CASE WHEN T2.MM = '10' THEN T1.TARGET_MS ELSE NULL END) M10_MS, MAX(CASE WHEN T2.MM = '10' THEN T1.TARGET_TS ELSE NULL END) M10_TS
					, '11' M11_TARGET_MM, MAX(CASE WHEN T2.MM = '11' THEN T3.CHECK_YN ELSE 'N' END) M11_CHECK, MAX(CASE WHEN T2.MM = '11' THEN T1.TARGET_MS ELSE NULL END) M11_MS, MAX(CASE WHEN T2.MM = '11' THEN T1.TARGET_TS ELSE NULL END) M11_TS
					, '12' M12_TARGET_MM, MAX(CASE WHEN T2.MM = '12' THEN T3.CHECK_YN ELSE 'N' END) M12_CHECK, MAX(CASE WHEN T2.MM = '12' THEN T1.TARGET_MS ELSE NULL END) M12_MS, MAX(CASE WHEN T2.MM = '12' THEN T1.TARGET_TS ELSE NULL END) M12_TS
				FROM BSC_KPI_TARGET T1 INNER JOIN BSC_TERM_DETAIL T2
					ON T1.ESTTERM_REF_ID = T2.ESTTERM_REF_ID AND T1.YMD = T2.YMD
					INNER JOIN BSC_KPI_TERM T3
					ON T1.KPI_REF_ID = T3.KPI_REF_ID AND T1.ESTTERM_REF_ID = T3.ESTTERM_REF_ID
					AND T1.YMD = T3.YMD
				WHERE T1.ESTTERM_REF_ID = @iESTTERM_REF_ID
					AND T1.KPI_TARGET_VERSION_ID = (SELECT MAX(kpi_target_version_id) FROM BSC_KPI_TARGET_VERSION
												WHERE ESTTERM_REF_ID = T1.ESTTERM_REF_ID 
													AND KPI_REF_ID = T1.KPI_REF_ID
												GROUP BY ESTTERM_REF_ID, KPI_REF_ID)
				GROUP BY T1.ESTTERM_REF_ID, T1.KPI_REF_ID) T4
			ON T3.ESTTERM_REF_ID = T4.ESTTERM_REF_ID AND T3.KPI_REF_ID = T4.KPI_REF_ID
			LEFT OUTER JOIN EST_DEPT_INFO M1
			ON T0.EST_DEPT_REF_ID = M1.EST_DEPT_REF_ID
			LEFT OUTER JOIN COM_EMP_INFO M2
			ON T3.CHAMPION_EMP_ID = M2.EMP_REF_ID
			LEFT OUTER JOIN REL_DEPT_EMP M3
			ON M2.EMP_REF_ID = M3.EMP_REF_ID
			LEFT OUTER JOIN COM_DEPT_INFO M4
			ON M3.DEPT_REF_ID = M4.DEPT_REF_ID
			LEFT OUTER JOIN COM_CODE_INFO M5
			ON T3.RESULT_INPUT_TYPE = M5.ETC_CODE AND M5.CATEGORY_CODE = 'BS001'
			LEFT OUTER JOIN COM_CODE_INFO M6
			ON T3.RESULT_TERM_TYPE = M6.ETC_CODE AND M6.CATEGORY_CODE = 'BS005'
			LEFT OUTER JOIN COM_CODE_INFO M7
			ON RESULT_TS_CALC_TYPE = M7.ETC_CODE AND M7.CATEGORY_CODE = 'BS002'
			LEFT OUTER JOIN COM_UNIT_TYPE_INFO M8
			ON T3.UNIT_TYPE_REF_ID = M8.UNIT_TYPE_REF_ID
			LEFT OUTER JOIN BSC_TERM_DETAIL M9
			ON T0.ESTTERM_REF_ID = M9.ESTTERM_REF_ID
				AND M9.YMD = T0.YMD
			LEFT OUTER JOIN BSC_KPI_POOL M10
			ON T3.KPI_POOL_REF_ID = M10.KPI_POOL_REF_ID
		WHERE T0.ESTTERM_REF_ID = @iESTTERM_REF_ID
			AND T0.EST_DEPT_REF_ID = @iEST_DEPT_REF_ID
			AND T0.YMD = @iYMD
			AND (T3.CHAMPION_EMP_ID = @iTXR_USER OR @iTXR_USER = 0)
			AND T1.USE_YN = 'Y'
		ORDER BY T3.KPI_CODE

";
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            //paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            //paramArray[0].Value = "ST";
            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iest_dept_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;


            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_RESULT", null, paramArray, CommandType.Text);

            return ds;
        }

        public DataSet SelectKpiResultYear(object estterm_ref_id, object est_dept_ref_id, int itxr_user)
        {
            string strQuery = @"
SELECT	D.KPI_CODE, E.KPI_NAME, F.CODE_NAME INPUT_TYPE_NAME, G.CODE_NAME RESULT_TS_NAME, H.UNIT UNIT_NAME, I.EMP_NAME CHAMP_EMP_NAME, C.WEIGHT
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '01' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M01_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '01' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M01_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '01' THEN J.RESULT_MS ELSE 0 END, 0)) AS M01_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '01' THEN J.RESULT_TS ELSE 0 END, 0)) AS M01_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '01' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M01_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '01' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M01_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '02' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M02_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '02' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M02_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '02' THEN J.RESULT_MS ELSE 0 END, 0)) AS M02_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '02' THEN J.RESULT_TS ELSE 0 END, 0)) AS M02_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '02' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M02_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '02' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M02_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '03' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M03_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '03' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M03_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '03' THEN J.RESULT_MS ELSE 0 END, 0)) AS M03_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '03' THEN J.RESULT_TS ELSE 0 END, 0)) AS M03_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '03' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M03_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '03' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M03_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '04' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M04_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '04' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M04_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '04' THEN J.RESULT_MS ELSE 0 END, 0)) AS M04_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '04' THEN J.RESULT_TS ELSE 0 END, 0)) AS M04_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '04' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M04_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '04' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M04_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '05' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M05_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '05' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M05_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '05' THEN J.RESULT_MS ELSE 0 END, 0)) AS M05_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '05' THEN J.RESULT_TS ELSE 0 END, 0)) AS M05_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '05' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M05_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '05' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M05_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '06' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M06_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '06' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M06_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '06' THEN J.RESULT_MS ELSE 0 END, 0)) AS M06_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '06' THEN J.RESULT_TS ELSE 0 END, 0)) AS M06_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '06' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M06_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '06' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M06_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '07' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M07_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '07' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M07_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '07' THEN J.RESULT_MS ELSE 0 END, 0)) AS M07_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '07' THEN J.RESULT_TS ELSE 0 END, 0)) AS M07_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '07' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M07_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '07' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M07_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '08' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M08_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '08' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M08_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '08' THEN J.RESULT_MS ELSE 0 END, 0)) AS M08_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '08' THEN J.RESULT_TS ELSE 0 END, 0)) AS M08_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '08' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M08_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '08' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M08_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '09' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M09_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '09' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M09_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '09' THEN J.RESULT_MS ELSE 0 END, 0)) AS M09_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '09' THEN J.RESULT_TS ELSE 0 END, 0)) AS M09_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '09' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M09_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '09' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M09_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '10' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M10_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '10' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M10_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '10' THEN J.RESULT_MS ELSE 0 END, 0)) AS M10_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '10' THEN J.RESULT_TS ELSE 0 END, 0)) AS M10_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '10' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M10_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '10' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M10_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '11' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M11_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '11' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M11_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '11' THEN J.RESULT_MS ELSE 0 END, 0)) AS M11_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '11' THEN J.RESULT_TS ELSE 0 END, 0)) AS M11_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '11' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M11_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '11' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M11_SIGNAL_TS
	    ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '12' THEN D2.CHECK_YN ELSE 'N' END, 'N')) AS M12_CHECK_YN
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '12' THEN J.CHECKSTATUS ELSE 'N' END, 'N')) AS M12_CHECKSTATUS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '12' THEN J.RESULT_MS ELSE 0 END, 0)) AS M12_MS
	    ,SUM(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '12' THEN J.RESULT_TS ELSE 0 END, 0)) AS M12_TS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '12' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'MS') ELSE 0 END, '')) AS M12_SIGNAL_MS
        ,MAX(ISNULL(CASE WHEN SUBSTRING(D2.YMD, 5, 2) = '12' THEN dbo.fn_BSC_KPI_INDICATOR_ID(J.ESTTERM_REF_ID, J.KPI_REF_ID, J.YMD, 'TS') ELSE 0 END, '')) AS M12_SIGNAL_TS
FROM	BSC_MAP_TERM	A
INNER JOIN BSC_MAP_INFO B ON B.ESTTERM_REF_ID = A.ESTTERM_REF_ID AND B.EST_DEPT_REF_ID = A.EST_DEPT_REF_ID AND B.MAP_VERSION_ID = A.MAP_VERSION_ID AND B.USE_YN = 'Y'
INNER JOIN BSC_MAP_KPI	C ON C.ESTTERM_REF_ID = B.ESTTERM_REF_ID AND C.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID AND C.MAP_VERSION_ID = B.MAP_VERSION_ID
INNER JOIN BSC_KPI_INFO D ON D.ESTTERM_REF_ID = C.ESTTERM_REF_ID AND D.KPI_REF_ID = C.KPI_REF_ID
INNER JOIN BSC_KPI_TERM D2 ON D2.ESTTERM_REF_ID = A.ESTTERM_REF_ID AND D2.KPI_REF_ID = D.KPI_REF_ID AND D2.YMD = A.YMD
LEFT OUTER JOIN BSC_KPI_POOL E ON E.KPI_POOL_REF_ID = D.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_CODE_INFO F ON F.ETC_CODE = D.RESULT_INPUT_TYPE AND F.CATEGORY_CODE = 'BS001'
LEFT OUTER JOIN COM_CODE_INFO G ON G.ETC_CODE = D.RESULT_TS_CALC_TYPE AND G.CATEGORY_CODE = 'BS002'
LEFT OUTER JOIN COM_UNIT_TYPE_INFO H ON H.UNIT_TYPE_REF_ID = D.UNIT_TYPE_REF_ID
LEFT OUTER JOIN COM_EMP_INFO I ON I.EMP_REF_ID = D.CHAMPION_EMP_ID
LEFT OUTER JOIN BSC_KPI_RESULT J ON J.ESTTERM_REF_ID = D2.ESTTERM_REF_ID AND J.KPI_REF_ID = D2.KPI_REF_ID AND J.YMD = D2.YMD

WHERE A.ESTTERM_REF_ID = @iESTTERM_REF_ID AND A.EST_DEPT_REF_ID = @iEST_DEPT_REF_ID
GROUP BY D.KPI_CODE, E.KPI_NAME, F.CODE_NAME, G.CODE_NAME, H.UNIT, I.EMP_NAME, C.WEIGHT
ORDER BY D.KPI_CODE

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_KPI_RESULT", null, paramArray, CommandType.Text);
        }


        public DataSet SelectKpiResultYear_BscThresholdCode()
        {
            string strQuery = @"
SELECT  THRESHOLD_REF_ID, IMAGE_FILE_NAME, THRESHOLD_ENAME
FROM    BSC_THRESHOLD_CODE
";

            return DbAgentObj.FillDataSet(strQuery, "BSC_THRESHOLD_CODE", null, null, CommandType.Text);
        }


        public int UpdateKpiResultDataByAdmin(IDbConnection conn
                                            , IDbTransaction trx
                                            , object estterm_ref_id
                                            , object kpi_ref_id
                                            , object ymd
                                            , object result_ms
                                            , object result_ts
                                            , object cause_text_ms
                                            , object cause_text_ts
                                            , object measure_text_ms
                                            , object measure_text_ts
                                            , object checkstatus
                                            , object update_date
                                            , object update_user)
        {
            string query = "";
            query = @"UPDATE BSC_KPI_RESULT
	                            SET   RESULT_MS                 =   @RESULT_MS
		                            , RESULT_TS                 =   @RESULT_TS
                                    , CAUSE_TEXT_MS             =   @CAUSE_TEXT_MS
                                    , CAUSE_TEXT_TS             =   @CAUSE_TEXT_TS
                                    , MEASURE_TEXT_MS           =   @MEASURE_TEXT_MS    
                                    , MEASURE_TEXT_TS           =   @MEASURE_TEXT_TS    
                                    , CHECKSTATUS               =   CASE WHEN @CHECKSTATUS = 'Y' THEN 'Y' ELSE CHECKSTATUS END
                                    , UPDATE_DATE               =   @UPDATE_DATE
                                    , UPDATE_USER               =   @UPDATE_USER
	                            WHERE		ESTTERM_REF_ID      =   @ESTTERM_REF_ID
			                            AND KPI_REF_ID	        =   @KPI_REF_ID
			                            AND YMD	                =   @YMD";

            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@RESULT_MS", SqlDbType.Decimal);
            paramArray[3].Value = result_ms;
            paramArray[4] = CreateDataParameter("@RESULT_TS", SqlDbType.Decimal);
            paramArray[4].Value = result_ts;
            paramArray[5] = CreateDataParameter("@CAUSE_TEXT_MS", SqlDbType.Text);
            paramArray[5].Value = cause_text_ms;
            paramArray[6] = CreateDataParameter("@CAUSE_TEXT_TS", SqlDbType.Text);
            paramArray[6].Value = cause_text_ts;
            paramArray[7] = CreateDataParameter("@MEASURE_TEXT_MS", SqlDbType.Text);
            paramArray[7].Value = measure_text_ms;
            paramArray[8] = CreateDataParameter("@MEASURE_TEXT_TS", SqlDbType.Text);
            paramArray[8].Value = measure_text_ts;
            paramArray[9] = CreateDataParameter("@CHECKSTATUS", SqlDbType.VarChar);
            paramArray[9].Value = checkstatus;
            paramArray[10] = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[10].Value = update_date;
            paramArray[11] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[11].Value = update_user;

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

        public int DeleteData_DB(IDbConnection conn
                                            , IDbTransaction trx
                                            , object estterm_ref_id
                                            , object kpi_ref_id)
        {

            string query = @"

DELETE FROM BSC_KPI_RESULT
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @KPI_REF_ID

";
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        
        public int UpdataData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object ymd
                                , object result_ms
                                , object result_ts
                                , object app_ref_id
                                , object checkstatus 
                                , object update_user
                                , object update_date)
        {

            string query = @"

UPDATE BSC_KPI_RESULT
	SET   RESULT_MS        = @RESULT_MS       
    	, RESULT_TS        = @RESULT_TS
    	, CHECKSTATUS      = @CHECKSTATUS
    	, CHECK_DATE       = @CHECK_DATE
    	, APP_REF_ID       = @APP_REF_ID
        , UPDATE_USER      = @UPDATE_USER
    	, UPDATE_DATE      = @UPDATE_DATE
        
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
  AND KPI_REF_ID     = @KPI_REF_ID 
  AND YMD            = @YMD

";
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;
            paramArray[2]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2].Value         = ymd;
            paramArray[3]               = CreateDataParameter("@RESULT_MS", SqlDbType.Decimal);
            paramArray[3].Value         = result_ms;
            paramArray[4]               = CreateDataParameter("@RESULT_TS", SqlDbType.Decimal);
            paramArray[4].Value         = result_ts;
            paramArray[5]               = CreateDataParameter("@CHECKSTATUS", SqlDbType.VarChar);
            paramArray[5].Value         = checkstatus;
            paramArray[6]               = CreateDataParameter("@CHECK_DATE", SqlDbType.DateTime);
            paramArray[6].Value         = update_date;
            paramArray[7]               = CreateDataParameter("@APP_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = app_ref_id;
            paramArray[8]               = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[8].Value         = update_user;
            paramArray[9]               = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[9].Value         = update_date;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public int UpdataData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object ymd
                                , object result_ms
                                , object result_ts
                                , object sequence
                                , object checkstatus 
                                , object cal_result_ms
                                , object cal_result_ts
                                , object cal_apply_yn
                                , object cal_apply_reason
                                , object cause_text_ms
                                , object cause_text_ts
                                , object cause_file_id
                                , object measure_text_ms
                                , object measure_text_ts
                                , object measure_file_id
                                , object remark
                                , object update_user
                                , object update_date)
        {

            string query = @"

UPDATE BSC_KPI_RESULT
    SET RESULT_MS        = @RESULT_MS       
       ,RESULT_TS        = @RESULT_TS       
       ,SEQUENCE         = @SEQUENCE        
       ,CHECKSTATUS      = @CHECKSTATUS  
       ,CHECK_DATE       = @CHECK_DATE
       ,CAL_RESULT_MS    = @CAL_RESULT_MS   
       ,CAL_RESULT_TS    = @CAL_RESULT_TS   
       ,CAL_APPLY_YN     = @CAL_APPLY_YN    
       ,CAL_APPLY_REASON = @CAL_APPLY_REASON
       ,CAUSE_TEXT_MS    = @CAUSE_TEXT_MS  
       ,CAUSE_TEXT_TS    = @CAUSE_TEXT_TS  
       ,CAUSE_FILE_ID    = @CAUSE_FILE_ID  
       ,MEASURE_TEXT_MS  = @MEASURE_TEXT_MS
       ,MEASURE_TEXT_TS  = @MEASURE_TEXT_TS
       ,MEASURE_FILE_ID  = @MEASURE_FILE_ID
       ,REMARK           = @REMARK          
       ,UPDATE_DATE      = @UPDATE_DATE
       ,UPDATE_USER      = @UPDATE_USER
  WHERE ESTTERM_REF_ID   = @ESTTERM_REF_ID
    AND KPI_REF_ID       = @KPI_REF_ID
    AND YMD              = @YMD

";

            IDbDataParameter[] paramArray = CreateDataParameters(21);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;
            paramArray[2]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2].Value         = ymd;
            paramArray[3]               = CreateDataParameter("@RESULT_MS", SqlDbType.Decimal);
            paramArray[3].Value         = result_ms;
            paramArray[4]               = CreateDataParameter("@RESULT_TS", SqlDbType.Decimal);
            paramArray[4].Value         = result_ts;
            paramArray[5]               = CreateDataParameter("@CHECKSTATUS", SqlDbType.VarChar);
            paramArray[5].Value         = checkstatus;
            paramArray[6]               = CreateDataParameter("@CHECK_DATE", SqlDbType.DateTime);
            paramArray[6].Value         = update_date;
            paramArray[7]               = CreateDataParameter("@CAL_RESULT_MS", SqlDbType.Decimal);
            paramArray[7].Value         = cal_result_ms;
            paramArray[8]               = CreateDataParameter("@CAL_RESULT_TS", SqlDbType.Decimal);
            paramArray[8].Value         = cal_result_ts;
            paramArray[9]               = CreateDataParameter("@CAL_APPLY_YN", SqlDbType.Char);
            paramArray[9].Value         = cal_apply_yn;
            paramArray[10]              = CreateDataParameter("@CAL_APPLY_REASON", SqlDbType.VarChar);
            paramArray[10].Value        = cal_apply_reason;
            paramArray[11]              = CreateDataParameter("@CAUSE_TEXT_MS", SqlDbType.VarChar);
            paramArray[11].Value        = cause_text_ms;
            paramArray[12]               = CreateDataParameter("@CAUSE_TEXT_TS", SqlDbType.VarChar);
            paramArray[12].Value         = cause_text_ts;
            paramArray[13]               = CreateDataParameter("@CAUSE_FILE_ID", SqlDbType.VarChar);
            paramArray[13].Value         = cause_file_id;
            paramArray[14]              = CreateDataParameter("@MEASURE_TEXT_MS", SqlDbType.VarChar);
            paramArray[14].Value        = measure_text_ms;
            paramArray[15]              = CreateDataParameter("@MEASURE_TEXT_TS", SqlDbType.VarChar);
            paramArray[15].Value        = measure_text_ts;
            paramArray[16]              = CreateDataParameter("@MEASURE_FILE_ID", SqlDbType.VarChar);
            paramArray[16].Value        = measure_file_id;
            paramArray[17]              = CreateDataParameter("@REMARK", SqlDbType.VarChar);
            paramArray[17].Value        = remark;
            paramArray[18]              = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[18].Value        = update_user;
            paramArray[19]              = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[19].Value        = update_date;
            paramArray[20]              = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[20].Value        = sequence;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        /// <summary>
        /// 프로젝트 평가 점수와 KPI실적 연계
        /// </summary>
        public int UpdateData_DB(IDbConnection conn, IDbTransaction trx
            , object estterm_ref_id
            , object kpi_ref_id
            , object ymd
            , object cal_result_ms
            , object cal_result_ts
            , object app_ref_id
            , object update_user_ref_id)
        {
            string query = @"

UPDATE      BSC_KPI_RESULT
	SET     CAL_RESULT_MS   = @CAL_RESULT_MS
    	  , CAL_RESULT_TS   = @CAL_RESULT_TS
    	  , APP_REF_ID      = @APP_REF_ID
    	  , UPDATE_USER     = @UPDATE_USER
          , UPDATE_DATE     = GETDATE()
    WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID      = @KPI_REF_ID 
        AND YMD             = @YMD

";
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@CAL_RESULT_MS", SqlDbType.Decimal);
            paramArray[3].Value = cal_result_ms;
            paramArray[4] = CreateDataParameter("@CAL_RESULT_TS", SqlDbType.Decimal);
            paramArray[4].Value = cal_result_ts;
            paramArray[5] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[5].Value = app_ref_id;
            paramArray[6] = CreateDataParameter("@UPDATE_USER", SqlDbType.DateTime);
            paramArray[6].Value = update_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        public int InsertData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object iymd
                                , object iresult_ms
                                , object iresult_ts
                                , object isequence
                                , object ical_result_ms
                                , object ical_result_ts
                                , object ical_apply_yn
                                , object ical_apply_reason
                                , object icause_text_ms
                                , object icause_text_ts
                                , object icause_file_id
                                , object imeasure_text_ms
                                , object imeasure_text_ts
                                , object imeasure_file_id
                                , object iremark
                                , object create_date
                                , object create_user)
        {

            string query = @"
INSERT INTO BSC_KPI_RESULT
  ( 
     ESTTERM_REF_ID  
    ,KPI_REF_ID      
    ,YMD             
    ,RESULT_MS       
    ,RESULT_TS       
    ,SEQUENCE        
    ,CHECKSTATUS     
    ,CHECK_DATE      
    ,CAL_RESULT_MS   
    ,CAL_RESULT_TS   
    ,CAL_APPLY_YN    
    ,CAL_APPLY_REASON
    ,CAUSE_TEXT_MS  
    ,CAUSE_TEXT_TS  
    ,CAUSE_FILE_ID  
    ,MEASURE_TEXT_MS
    ,MEASURE_TEXT_TS
    ,MEASURE_FILE_ID
    ,REMARK        
    ,CREATE_DATE
    ,CREATE_USER
    ,UPDATE_DATE
    ,UPDATE_USER
  )
VALUES
  ( 
     @ESTTERM_REF_ID  
    ,@KPI_REF_ID      
    ,@YMD             
    ,@RESULT_MS       
    ,@RESULT_TS       
    ,@SEQUENCE        
    ,@CHECKSTATUS   --,'Y'
    ,@CREATE_DATE
    ,@CAL_RESULT_MS   
    ,@CAL_RESULT_TS   
    ,@CAL_APPLY_YN    
    ,@CAL_APPLY_REASON
    ,@CAUSE_TEXT_MS  
    ,@CAUSE_TEXT_TS  
    ,@CAUSE_FILE_ID  
    ,@MEASURE_TEXT_MS
    ,@MEASURE_TEXT_TS
    ,@MEASURE_FILE_ID
    ,@REMARK          
    ,@CREATE_DATE
    ,@CREATE_USER
    ,@CREATE_DATE
    ,@CREATE_USER  
  )
";
            IDbDataParameter[] paramArray = CreateDataParameters(20);

            paramArray[0]               = CreateDataParameter("@CHECKSTATUS", SqlDbType.VarChar);
            paramArray[0].Value         = "Y";
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@RESULT_MS", SqlDbType.Decimal);
            paramArray[4].Value         = iresult_ms;
            paramArray[5]               = CreateDataParameter("@RESULT_TS", SqlDbType.Decimal);
            paramArray[5].Value         = iresult_ts;
            paramArray[6]               = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[6].Value         = isequence;
            paramArray[7]               = CreateDataParameter("@CAL_RESULT_MS", SqlDbType.Decimal);
            paramArray[7].Value         = ical_result_ms;
            paramArray[8]               = CreateDataParameter("@CAL_RESULT_TS", SqlDbType.Decimal);
            paramArray[8].Value         = ical_result_ts;
            paramArray[9]               = CreateDataParameter("@CAL_APPLY_YN", SqlDbType.Char);
            paramArray[9].Value         = ical_apply_yn;
            paramArray[10]              = CreateDataParameter("@CAL_APPLY_REASON", SqlDbType.VarChar);
            paramArray[10].Value        = ical_apply_reason;
            paramArray[11]              = CreateDataParameter("@CAUSE_TEXT_MS", SqlDbType.NText);
            paramArray[11].Value        = icause_text_ms;
            paramArray[12]              = CreateDataParameter("@CAUSE_TEXT_TS", SqlDbType.NText);
            paramArray[12].Value        = icause_text_ts;
            paramArray[13]              = CreateDataParameter("@CAUSE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[13].Value        = icause_file_id;
            paramArray[14]              = CreateDataParameter("@MEASURE_TEXT_MS", SqlDbType.Text);
            paramArray[14].Value        = imeasure_text_ms;
            paramArray[15]              = CreateDataParameter("@MEASURE_TEXT_TS", SqlDbType.Text);
            paramArray[15].Value        = imeasure_text_ts;
            paramArray[16]              = CreateDataParameter("@MEASURE_FILE_ID", SqlDbType.VarChar, 25);
            paramArray[16].Value        = imeasure_file_id;
            paramArray[17]              = CreateDataParameter("@REMARK", SqlDbType.VarChar);
            paramArray[17].Value        = iremark;
            paramArray[18]              = CreateDataParameter("@CREATE_DATE", SqlDbType.Date);
            paramArray[18].Value        = create_date;
            paramArray[19]              = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[19].Value        = create_user;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }




        public int Insert_DB_From_Estterm_Detail(IDbConnection conn, IDbTransaction trx
                            , object estterm_ref_id
                            , object kpi_ref_id
                            , object create_user_ref_id)
        {
            string query = @"
INSERT INTO     BSC_KPI_RESULT
    ( 
        ESTTERM_REF_ID
        , KPI_REF_ID
        , YMD
        , RESULT_MS
        , RESULT_TS
        , SEQUENCE
        , CHECKSTATUS
        , CONFIRMSTATUS
        , CAL_RESULT_MS
        , CAL_RESULT_TS
        , CAL_APPLY_YN
        , CAL_APPLY_REASON
        , REMARK
        , APP_REF_ID
        , CREATE_USER
        , CREATE_DATE
    )
    SELECT      ESTTERM_REF_ID
                , @KPI_REF_ID
                , YMD
                , 0.00
                , 0.00
                , CAST(YMD AS int)
                , 'N'
                , 'N'
                , 0.00
                , 0.00
                , 'N'
                , ''
                , ''
                , 0
                , @CREATE_USER
                , GETDATE()
        FROM    BSC_TERM_DETAIL
        WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[2].Value = create_user_ref_id;



            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            return affectedRow;
        }


        

        public DataSet Select_DB(object estterm_ref_id
                                , object kpi_ref_id
                                , string ymd)
        {
            string strQuery = @"

SELECT ESTTERM_REF_ID
      ,KPI_REF_ID
      ,YMD 
      ,RESULT_MS
      ,RESULT_TS
 FROM BSC_KPI_RESULT
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
  AND KPI_REF_ID     = @KPI_REF_ID
  AND YMD            = @YMD
ORDER BY KPI_REF_ID DESC

";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar, 20);
            paramArray[2].Value = ymd;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);
            return ds;
        }


        #endregion
    }
}
