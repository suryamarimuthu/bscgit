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

namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Score_Goal : DbAgentBase
    {
        /// <summary>
        /// 부서의 월별 KPI 누적 실적
        /// </summary>
        public DataTable Select_Kpi_Monthly_Total_Sum(object estterm_ref_id
                                                    , object dept_ref_id)
        {
            string strQuery = @"
SELECT  KW.ESTTERM_REF_ID 
        ,KW.YMD 
        ,KW.EST_DEPT_REF_ID 
        ,ED.DEPT_NAME
        ,KW.VIEW_REF_ID
        ,KW.KPI_REF_ID
        ,(CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS) END) as SCORE_MS 
        ,(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS) END) as SCORE_TS
FROM            BSC_KPI_WEIGHT KW 
     LEFT JOIN  BSC_KPI_SCORE_GOAL TS
       ON KW.ESTTERM_REF_ID     = TS.ESTTERM_REF_ID
      AND KW.KPI_REF_ID         = TS.KPI_REF_ID
      AND KW.YMD                = TS.YMD
      AND KW.ESTTERM_REF_ID     = @ESTTERM_REF_ID
     LEFT JOIN  EST_DEPT_INFO ED
       ON KW.ESTTERM_REF_ID     = ED.ESTTERM_REF_ID
      AND KW.EST_DEPT_REF_ID    = ED.EST_DEPT_REF_ID
    LEFT JOIN   BSC_KPI_INFO KI
       ON KI.IS_TEAM_KPI        = 'Y'
      AND KI.ESTTERM_REF_ID     = ED.ESTTERM_REF_ID
      AND KI.KPI_REF_ID         = TS.KPI_REF_ID
WHERE ED.EST_DEPT_REF_ID        = @DEPT_REF_ID
   ORDER BY KW.KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = dept_ref_id;

            DataTable dt = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_RESULT_GOAL", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        /// <summary>
        /// 부서의 월별 점수
        /// </summary>
        /// <param name="sum_type">TS:누적점수, MS:월별점수</param>
        public DataTable Select_Kpi_Monthly_Score(object estterm_ref_id
                                                    , object dept_ref_id
                                                    , object sum_type)
        {
            string strQuery = @"
SELECT  TC.ESTTERM_REF_ID 
        ,TC.YMD            
        ,TC.EST_DEPT_REF_ID
        ,TC.DEPT_NAME      
        ,TC.SCORE          
    FROM (
            SELECT  TB.ESTTERM_REF_ID       as ESTTERM_REF_ID
                    ,TB.YMD                 as YMD
                    ,TB.EST_DEPT_REF_ID     as EST_DEPT_REF_ID
                    ,TB.DEPT_NAME           as DEPT_NAME
                    ,ROUND(TB.SCORE,4)      as SCORE
                FROM (
                        SELECT  TA.ESTTERM_REF_ID
                                ,TA.YMD 
                                ,TA.EST_DEPT_REF_ID
                                ,TA.DEPT_NAME
                                ,CASE WHEN  @SUM_TYPE = 'MS'
                                    THEN    ROUND(SUM(TA.SCORE_MS),4)
                                    ELSE    ROUND(SUM(TA.SCORE_TS),4)
                                    END as SCORE
                  FROM (
                        SELECT  KW.ESTTERM_REF_ID 
                                ,KW.YMD 
                                ,KW.EST_DEPT_REF_ID 
                                ,ED.DEPT_NAME
                                ,KW.VIEW_REF_ID 
                                ,ISNULL(KW.WEIGHT3,0)* (CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                                ,ISNULL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS
                            FROM            BSC_KPI_WEIGHT KW 
                                LEFT JOIN   BSC_KPI_SCORE_GOAL TS
                                    ON KW.ESTTERM_REF_ID        = TS.ESTTERM_REF_ID
                                        AND KW.KPI_REF_ID       = TS.KPI_REF_ID
                                        AND KW.YMD              = TS.YMD
                                        AND KW.ESTTERM_REF_ID   = @ESTTERM_REF_ID
                                LEFT JOIN   EST_DEPT_INFO ED
                                    ON KW.ESTTERM_REF_ID        = ED.ESTTERM_REF_ID
                                        AND KW.EST_DEPT_REF_ID  = ED.EST_DEPT_REF_ID
                            WHERE ED.EST_DEPT_REF_ID    = @DEPT_REF_ID
                        ) TA
                  GROUP BY  TA.ESTTERM_REF_ID 
                            ,TA.YMD 
                            ,TA.EST_DEPT_REF_ID
                            ,TA.DEPT_NAME
                  
                ) TB
         GROUP BY   TB.ESTTERM_REF_ID 
                    ,TB.YMD 
                    ,TB.EST_DEPT_REF_ID
                    ,TB.DEPT_NAME
                    ,TB.SCORE
       ) TC
   ORDER BY TC.ESTTERM_REF_ID
            , TC.EST_DEPT_REF_ID
            ,TC.YMD
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = dept_ref_id;
            paramArray[2] = CreateDataParameter("@SUM_TYPE", SqlDbType.NVarChar);
            paramArray[2].Value = sum_type;

            DataTable dt = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_MONTHLY_SCORE", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }
    }
}
