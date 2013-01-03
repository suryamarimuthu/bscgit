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
/// Summary description for Dac_Bsc_Intro_Score
/// </summary>
namespace MicroBSC.Integration.BSC.Dac
{


    public class Dac_Bsc_Intro_Score : DbAgentBase
    {
        public Dac_Bsc_Intro_Score()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataTable GetMboScore(object estterm_ref_id, object ymd, object loginid)
        {
            string query = @"
SELECT A.EMP_NAME, B.DEPT_REF_ID
        ,(SELECT FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, A.EMP_REF_ID, 'MS') FROM DUAL) AS MS_SCORE
        ,(SELECT FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, A.EMP_REF_ID, 'TS') FROM DUAL) AS TS_SCORE       
  FROM COM_EMP_INFO A
       LEFT JOIN REL_DEPT_EMP B    ON B.EMP_REF_ID  = A.EMP_REF_ID
       LEFT JOIN COM_DEPT_INFO C   ON B.DEPT_REF_ID = C.DEPT_REF_ID     
WHERE A.LOGINID = @LOGINID
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[2].Value = loginid;


            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_MBO_SCORE", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetOrgRank(object estterm_ref_id, object ymd, object rowcnt)
        {
            string query = @"
SELECT TC.ESTTERM_REF_ID
      ,TC.YMD
      ,TC.EST_DEPT_REF_ID
      ,TC.DEPT_NAME
      ,TC.RANK_ID
      ,TC.SCORE_TS
      ,TC.UP_EST_DEPT_ID
      ,TC.UP_DEPT_NAME
      ,ROWNUM
FROM ( 
      SELECT TB.ESTTERM_REF_ID                   as ESTTERM_REF_ID
            ,TB.YMD                              as YMD
            ,TB.EST_DEPT_REF_ID                  as EST_DEPT_REF_ID
            ,TB.DEPT_NAME                        as DEPT_NAME
            ,RANK() OVER(ORDER BY TB.SCORE_TS DESC) as RANK_ID
            --,ROUND(TB.SCORE_MS,4)                as SCORE_MS
            ,ROUND(TB.SCORE_TS,4)                as SCORE_TS
            ,TB.UP_EST_DEPT_ID
            ,TB.UP_DEPT_NAME
        FROM (
              SELECT TA.ESTTERM_REF_ID
                    ,TA.YMD 
                    ,TA.EST_DEPT_REF_ID
                    ,TA.DEPT_NAME
                    ,ROUND(SUM(TA.SCORE_MS),4) AS SCORE_MS
                    ,ROUND(SUM(TA.SCORE_TS),4) AS SCORE_TS
                    ,TA.UP_EST_DEPT_ID
                    ,TA.UP_DEPT_NAME
                FROM (
                      SELECT KW.ESTTERM_REF_ID 
                            ,KW.YMD 
                            ,KW.EST_DEPT_REF_ID 
                            ,ED.DEPT_NAME
                            ,KW.VIEW_REF_ID 
                            ,ED.DEPT_TYPE
                            ,NVL(KW.WEIGHT3,0)* (CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                            ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS
                            ,ED.UP_EST_DEPT_ID
                            ,(SELECT EDI.DEPT_NAME 
                                FROM EST_DEPT_INFO EDI 
                               WHERE EDI.ESTTERM_REF_ID = ED.ESTTERM_REF_ID 
                                 AND EDI.EST_DEPT_REF_ID = ED.UP_EST_DEPT_ID ) AS UP_DEPT_NAME
                        FROM BSC_KPI_WEIGHT KW 
                             LEFT JOIN BSC_KPI_SCORE TS
                               ON KW.ESTTERM_REF_ID  = TS.ESTTERM_REF_ID
                              AND KW.KPI_REF_ID      = TS.KPI_REF_ID
                              AND KW.YMD             = TS.YMD
                              AND KW.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                             LEFT JOIN EST_DEPT_INFO ED
                               ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                              AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                       WHERE KW.YMD                  = @YMD
                         AND ED.DEPT_TYPE IN (7)
                      ) TA
                GROUP BY TA.ESTTERM_REF_ID 
                        ,TA.YMD 
                        ,TA.EST_DEPT_REF_ID
                        ,TA.DEPT_NAME
                        ,TA.UP_EST_DEPT_ID
                        ,TA.UP_DEPT_NAME
              ) TB
       GROUP BY TB.ESTTERM_REF_ID 
               ,TB.YMD 
               ,TB.EST_DEPT_REF_ID
               ,TB.DEPT_NAME
               ,TB.UP_EST_DEPT_ID
               ,TB.UP_DEPT_NAME
               ,TB.SCORE_TS 
   ) TC
WHERE ROWNUM <= @ROWCNT OR @ROWCNT = 0
ORDER BY RANK_ID ASC, ROWNUM ASC";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@ROWCNT", SqlDbType.Int);
            paramArray[2].Value = rowcnt;



            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_RANK", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable GetOrgRankBonbuInTeam(object estterm_ref_id, object ymd, object rowcnt, object up_dept_ref_id)
        {
            string query = @"
SELECT TC.ESTTERM_REF_ID
      ,TC.YMD
      ,TC.EST_DEPT_REF_ID
      ,TC.DEPT_NAME
      ,TC.RANK_ID
      ,TC.SCORE_TS
      ,TC.UP_DEPT_NAME
FROM ( 
      SELECT TB.ESTTERM_REF_ID                   as ESTTERM_REF_ID
            ,TB.YMD                              as YMD
            ,TB.EST_DEPT_REF_ID                  as EST_DEPT_REF_ID
            ,TB.DEPT_NAME                        as DEPT_NAME
            ,RANK() OVER(ORDER BY TB.SCORE_TS DESC) as RANK_ID
            --,ROUND(TB.SCORE_MS,4)                as SCORE_MS
            ,ROUND(TB.SCORE_TS,4)                as SCORE_TS
            ,TB.UP_DEPT_NAME
        FROM (
              SELECT TA.ESTTERM_REF_ID
                    ,TA.YMD 
                    ,TA.EST_DEPT_REF_ID
                    ,TA.DEPT_NAME
                    ,ROUND(SUM(TA.SCORE_MS),4) AS SCORE_MS
                    ,ROUND(SUM(TA.SCORE_TS),4) AS SCORE_TS
                    ,TA.UP_DEPT_NAME
                FROM (
                      SELECT KW.ESTTERM_REF_ID 
                            ,KW.YMD 
                            ,KW.EST_DEPT_REF_ID 
                            ,ED.DEPT_NAME
                            ,KW.VIEW_REF_ID 
                            ,ED.DEPT_TYPE
                            ,NVL(KW.WEIGHT3,0)* (CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                            ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS
                            ,(SELECT EDI.DEPT_NAME 
                                FROM EST_DEPT_INFO EDI 
                               WHERE EDI.ESTTERM_REF_ID = ED.ESTTERM_REF_ID 
                                 AND EDI.EST_DEPT_REF_ID = ED.UP_EST_DEPT_ID ) AS UP_DEPT_NAME
                        FROM BSC_KPI_WEIGHT KW 
                             LEFT JOIN BSC_KPI_SCORE TS
                               ON KW.ESTTERM_REF_ID  = TS.ESTTERM_REF_ID
                              AND KW.KPI_REF_ID      = TS.KPI_REF_ID
                              AND KW.YMD             = TS.YMD
                              AND KW.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                             LEFT JOIN EST_DEPT_INFO ED
                               ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                              AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                       WHERE KW.YMD                  = @YMD
                         AND ED.DEPT_TYPE IN (7)
                         AND ED.UP_EST_DEPT_ID = @UP_DEPT_REF_ID
                      ) TA
                GROUP BY TA.ESTTERM_REF_ID 
                        ,TA.YMD 
                        ,TA.EST_DEPT_REF_ID
                        ,TA.DEPT_NAME
                        ,TA.UP_DEPT_NAME
              ) TB
       GROUP BY TB.ESTTERM_REF_ID 
               ,TB.YMD 
               ,TB.EST_DEPT_REF_ID
               ,TB.DEPT_NAME
               ,TB.UP_DEPT_NAME
               ,TB.SCORE_TS 
   ) TC
WHERE ROWNUM <= @ROWCNT OR @ROWCNT = 0
ORDER BY RANK_ID ASC";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@ROWCNT", SqlDbType.Int);
            paramArray[2].Value = rowcnt;
            paramArray[3] = CreateDataParameter("@UP_DEPT_REF_ID", SqlDbType.Int);
            paramArray[3].Value = up_dept_ref_id;



            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_RANK_BT", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetOrgRankDesc(object estterm_ref_id, object ymd, object rowcnt)
        {
            string query = @"
  SELECT TD.ESTTERM_REF_ID
        ,TD.YMD
        ,TD.EST_DEPT_REF_ID
        ,TD.DEPT_NAME
        ,TD.RANK_ID
        ,TD.SCORE_TS
        ,TD.UP_DEPT_NAME
        ,TD.ROWNUMBER
  FROM ( 
      SELECT TC.ESTTERM_REF_ID
            ,TC.YMD
            ,TC.EST_DEPT_REF_ID
            ,TC.DEPT_NAME
            ,TC.RANK_ID
            ,TC.SCORE_TS
            ,TC.UP_DEPT_NAME
            ,ROWNUM AS ROWNUMBER
      FROM ( 
            SELECT TB.ESTTERM_REF_ID                   as ESTTERM_REF_ID
                  ,TB.YMD                              as YMD
                  ,TB.EST_DEPT_REF_ID                  as EST_DEPT_REF_ID
                  ,TB.DEPT_NAME                        as DEPT_NAME
                  ,RANK() OVER(ORDER BY TB.SCORE_TS DESC) as RANK_ID
                  --,ROUND(TB.SCORE_MS,4)                as SCORE_MS
                  ,ROUND(TB.SCORE_TS,4)                as SCORE_TS
                  ,TB.UP_DEPT_NAME
              FROM (
                    SELECT TA.ESTTERM_REF_ID
                          ,TA.YMD 
                          ,TA.EST_DEPT_REF_ID
                          ,TA.DEPT_NAME
                          ,ROUND(SUM(TA.SCORE_MS),4) AS SCORE_MS
                          ,ROUND(SUM(TA.SCORE_TS),4) AS SCORE_TS
                          ,TA.UP_DEPT_NAME
                      FROM (
                            SELECT KW.ESTTERM_REF_ID 
                                  ,KW.YMD 
                                  ,KW.EST_DEPT_REF_ID 
                                  ,ED.DEPT_NAME
                                  ,KW.VIEW_REF_ID 
                                  ,ED.DEPT_TYPE
                                  ,NVL(KW.WEIGHT3,0)* (CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                                  ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS
                                  ,(SELECT EDI.DEPT_NAME 
                                      FROM EST_DEPT_INFO EDI 
                                     WHERE EDI.ESTTERM_REF_ID = ED.ESTTERM_REF_ID 
                                       AND EDI.EST_DEPT_REF_ID = ED.UP_EST_DEPT_ID ) AS UP_DEPT_NAME
                              FROM BSC_KPI_WEIGHT KW 
                                   LEFT JOIN BSC_KPI_SCORE TS
                                     ON KW.ESTTERM_REF_ID  = TS.ESTTERM_REF_ID
                                    AND KW.KPI_REF_ID      = TS.KPI_REF_ID
                                    AND KW.YMD             = TS.YMD
                                    AND KW.ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                   LEFT JOIN EST_DEPT_INFO ED
                                     ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                                    AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                             WHERE KW.YMD                  = @YMD
                               AND ED.DEPT_TYPE IN (7)
                            ) TA
                      GROUP BY TA.ESTTERM_REF_ID 
                              ,TA.YMD 
                              ,TA.EST_DEPT_REF_ID
                              ,TA.DEPT_NAME
                              ,TA.UP_DEPT_NAME
                    ) TB
             GROUP BY TB.ESTTERM_REF_ID 
                     ,TB.YMD 
                     ,TB.EST_DEPT_REF_ID
                     ,TB.DEPT_NAME
                     ,TB.UP_DEPT_NAME
                     ,TB.SCORE_TS 
         ) TC
      ORDER BY TC.RANK_ID DESC, ROWNUM DESC
      ) TD
WHERE ROWNUM <= @ROWCNT OR @ROWCNT = 0 ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@ROWCNT", SqlDbType.Int);
            paramArray[2].Value = rowcnt;



            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_RANK_DESC", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable GetOrgRankBonbu(object estterm_ref_id, object ymd, object dept_type, object sum_type )
        {
            string query = @"
SELECT ROWNUM AS RANK_ID
      ,TB.ESTTERM_REF_ID
      ,TB.YMD
      ,TB.EST_DEPT_REF_ID
      ,TB.MS_WEIGT         AS MS_WEIGT
      ,TB.TS_WEIGT         AS TS_WEIGT
      ,TB.MS_SCORE         AS MS_SCORE
      ,TB.TS_SCORE         AS TS_SCORE
      ,TB.DEPT_NAME
  FROM (
         SELECT TA.ESTTERM_REF_ID             AS ESTTERM_REF_ID
               ,TA.YMD                        AS YMD
               ,TA.EST_DEPT_REF_ID            AS EST_DEPT_REF_ID
               ,ROUND(SUM(TA.WEIGHT_MS),4)    as MS_WEIGT 
               ,ROUND(SUM(TA.WEIGHT_TS),4)    as TS_WEIGT 
               ,ROUND(SUM(TA.SCORE_MS),4)     as MS_SCORE 
               ,ROUND(SUM(TA.SCORE_TS),4)     as TS_SCORE 
               ,TA.DEPT_NAME
          FROM (
                 SELECT KW.ESTTERM_REF_ID 
                       ,KW.YMD 
                       ,KW.EST_DEPT_REF_ID 
                       ,NVL(KW.WEIGHT3,0)*(CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                       ,NVL(KW.WEIGHT3,0) as WEIGHT_MS 
                       ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS 
                       ,NVL(KW.SWEIGHT3,0) as WEIGHT_TS
                       ,CASE WHEN @SUM_TYPE = 'MS' THEN TS.POINTS_MS ELSE TS.POINTS_TS END as DEPT_SIGNAL
                       ,ED.DEPT_NAME
                   FROM BSC_KPI_WEIGHT KW 
                        LEFT JOIN BSC_KPI_SCORE TS
                          ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
                         AND KW.KPI_REF_ID     = TS.KPI_REF_ID
                         AND KW.YMD            = TS.YMD
                         AND KW.YMD            = @YMD
                        INNER JOIN EST_DEPT_INFO ED
                           ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                          AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                          AND ED.TEMP_FLAG = 1
                          AND ED.DEPT_TYPE = @DEPT_TYPE
                 WHERE KW.ESTTERM_REF_ID = @ESTTERM_REF_ID
                ) TA 
           WHERE TA.YMD = @YMD
           GROUP BY TA.ESTTERM_REF_ID ,TA.YMD ,TA.EST_DEPT_REF_ID,TA.DEPT_NAME
           ORDER BY ROUND(SUM(TA.SCORE_TS),4) DESC
      ) TB  ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@DEPT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = dept_type;
            paramArray[3] = CreateDataParameter("@SUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = sum_type;



            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_RANK_BONBU", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable GetOrgRankBonbuAsc(object estterm_ref_id, object ymd, object dept_type, object sum_type, object rownum)
        {
            string query = @"
SELECT ROWNUM AS RANK_ID
      ,TB.ESTTERM_REF_ID
      ,TB.YMD
      ,TB.EST_DEPT_REF_ID
      ,TB.MS_WEIGT         AS MS_WEIGT
      ,TB.TS_WEIGT         AS TS_WEIGT
      ,TB.MS_SCORE         AS MS_SCORE
      ,TB.TS_SCORE         AS TS_SCORE
      ,TB.DEPT_NAME
  FROM (
         SELECT TA.ESTTERM_REF_ID             AS ESTTERM_REF_ID
               ,TA.YMD                        AS YMD
               ,TA.EST_DEPT_REF_ID            AS EST_DEPT_REF_ID
               ,ROUND(SUM(TA.WEIGHT_MS),4)    as MS_WEIGT 
               ,ROUND(SUM(TA.WEIGHT_TS),4)    as TS_WEIGT 
               ,ROUND(SUM(TA.SCORE_MS),4)     as MS_SCORE 
               ,ROUND(SUM(TA.SCORE_TS),4)     as TS_SCORE 
               ,TA.DEPT_NAME
          FROM (
                 SELECT KW.ESTTERM_REF_ID 
                       ,KW.YMD 
                       ,KW.EST_DEPT_REF_ID 
                       ,NVL(KW.WEIGHT3,0)*(CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                       ,NVL(KW.WEIGHT3,0) as WEIGHT_MS 
                       ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS 
                       ,NVL(KW.SWEIGHT3,0) as WEIGHT_TS
                       ,CASE WHEN @SUM_TYPE = 'MS' THEN TS.POINTS_MS ELSE TS.POINTS_TS END as DEPT_SIGNAL
                       ,ED.DEPT_NAME
                   FROM BSC_KPI_WEIGHT KW 
                        LEFT JOIN BSC_KPI_SCORE TS
                          ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
                         AND KW.KPI_REF_ID     = TS.KPI_REF_ID
                         AND KW.YMD            = TS.YMD
                         AND KW.YMD            = @YMD
                        INNER JOIN EST_DEPT_INFO ED
                           ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                          AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                          AND ED.TEMP_FLAG = 1
                          AND ED.DEPT_TYPE = @DEPT_TYPE
                 WHERE KW.ESTTERM_REF_ID = @ESTTERM_REF_ID
                ) TA 
           WHERE TA.YMD = @YMD
           GROUP BY TA.ESTTERM_REF_ID ,TA.YMD ,TA.EST_DEPT_REF_ID,TA.DEPT_NAME
           ORDER BY ROUND(SUM(TA.SCORE_TS),4) ASC
      ) TB  
WHERE ROWNUM <= @ROWCNT OR @ROWCNT = 0 ";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@DEPT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = dept_type;
            paramArray[3] = CreateDataParameter("@SUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = sum_type;
            paramArray[4] = CreateDataParameter("@ROWCNT", SqlDbType.Int);
            paramArray[4].Value = rownum;
 


            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_RANK_BONBU_ASC", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable GetOrgRankBonbuDesc(object estterm_ref_id, object ymd, object dept_type, object sum_type, object rownum)
        {
            string query = @"
SELECT ROWNUM AS RANK_ID
      ,TB.ESTTERM_REF_ID
      ,TB.YMD
      ,TB.EST_DEPT_REF_ID
      ,TB.MS_WEIGT         AS MS_WEIGT
      ,TB.TS_WEIGT         AS TS_WEIGT
      ,TB.MS_SCORE         AS MS_SCORE
      ,TB.TS_SCORE         AS TS_SCORE
      ,TB.DEPT_NAME
  FROM (
         SELECT TA.ESTTERM_REF_ID             AS ESTTERM_REF_ID
               ,TA.YMD                        AS YMD
               ,TA.EST_DEPT_REF_ID            AS EST_DEPT_REF_ID
               ,ROUND(SUM(TA.WEIGHT_MS),4)    as MS_WEIGT 
               ,ROUND(SUM(TA.WEIGHT_TS),4)    as TS_WEIGT 
               ,ROUND(SUM(TA.SCORE_MS),4)     as MS_SCORE 
               ,ROUND(SUM(TA.SCORE_TS),4)     as TS_SCORE 
               ,TA.DEPT_NAME
          FROM (
                 SELECT KW.ESTTERM_REF_ID 
                       ,KW.YMD 
                       ,KW.EST_DEPT_REF_ID 
                       ,NVL(KW.WEIGHT3,0)*(CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                       ,NVL(KW.WEIGHT3,0) as WEIGHT_MS 
                       ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS 
                       ,NVL(KW.SWEIGHT3,0) as WEIGHT_TS
                       ,CASE WHEN @SUM_TYPE = 'MS' THEN TS.POINTS_MS ELSE TS.POINTS_TS END as DEPT_SIGNAL
                       ,ED.DEPT_NAME
                   FROM BSC_KPI_WEIGHT KW 
                        LEFT JOIN BSC_KPI_SCORE TS
                          ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
                         AND KW.KPI_REF_ID     = TS.KPI_REF_ID
                         AND KW.YMD            = TS.YMD
                         AND KW.YMD            = @YMD
                        INNER JOIN EST_DEPT_INFO ED
                           ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                          AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                          AND ED.TEMP_FLAG = 1
                          AND ED.DEPT_TYPE = @DEPT_TYPE
                 WHERE KW.ESTTERM_REF_ID = @ESTTERM_REF_ID
                ) TA 
           WHERE TA.YMD = @YMD
           GROUP BY TA.ESTTERM_REF_ID ,TA.YMD ,TA.EST_DEPT_REF_ID,TA.DEPT_NAME
           ORDER BY ROUND(SUM(TA.SCORE_TS),4) DESC
      ) TB  
WHERE ROWNUM <= @ROWCNT OR @ROWCNT = 0 ";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@DEPT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = dept_type;
            paramArray[3] = CreateDataParameter("@SUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = sum_type;
            paramArray[4] = CreateDataParameter("@ROWCNT", SqlDbType.Int);
            paramArray[4].Value = rownum;
 


            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_RANK_BONBU_desc", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetOrgRankPri(object estterm_ref_id, object ymd, object bonbu_id)
        {
            string query = @"
SELECT ROWNUM        AS RANK_ID
       ,BB.ESTTERM_REF_ID
       ,BB.YMD 
       ,BB.EMP_REF_ID
       ,BB.EMP_NAME
       ,CASE WHEN BB.TS_SCORE < 0 THEN 0 ELSE BB.TS_SCORE END TS_SCORE
  FROM (
        SELECT AA.ESTTERM_REF_ID     AS ESTTERM_REF_ID
              ,AA.EST_DEPT_REF_ID    AS EST_DEPT_REF_ID
              ,AA.DEPT_NAME          AS DEPT_NAME
              ,AA.YMD                AS YMD
              ,AA.EMP_REF_ID         AS EMP_REF_ID
              ,AA.EMP_NAME           AS EMP_NAME
              ,AA.MS_SCORE           AS MS_SCORE
              ,AA.TS_SCORE           AS TS_SCORE
          FROM (
                (
                SELECT A.ESTTERM_REF_ID     AS ESTTERM_REF_ID
                      ,A.EST_DEPT_REF_ID    AS EST_DEPT_REF_ID
                      ,A.DEPT_NAME         AS DEPT_NAME
                      ,TA.YMD               AS YMD
                      ,TA.EMP_REF_ID        AS EMP_REF_ID
                      ,TA.EMP_NAME          AS EMP_NAME
                      ,TA.MS_SCORE          AS MS_SCORE
                      ,TA.TS_SCORE          AS TS_SCORE
                  FROM EST_DEPT_INFO A
                       INNER JOIN ( SELECT a.emp_ref_id, a.emp_code, a.emp_name
                                           , b.dept_ref_id, c.dept_name
                                            ,@YMD   as YMD
                                            ,(select FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, a.emp_ref_id, 'MS') from dual) as ms_score
                                            ,(select FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, a.emp_ref_id, 'TS') from dual) as ts_score        
                                      from com_emp_info a
                                           inner join rel_dept_emp b    on b.rel_status = 1  and b.emp_ref_id  = a.emp_ref_id 
                                           inner join com_dept_info c   on c.dept_flag = 1   and b.dept_ref_id = c.dept_ref_id 
                                     where a.emp_ref_id not in ( select emp_ref_id from com_emp_info 
                                                                  where emp_code = 'admin' or emp_code like 'bscuser%' or emp_code like 'estuser%')
                                 ) ta
                          on ta.dept_ref_id = a.est_dept_ref_id                         
                 WHERE A.ESTTERM_REF_ID = @ESTTERM_REF_ID
                   AND A.DEPT_TYPE = 4
                   AND A.TEMP_FLAG = 1
                   AND A.EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                   )   
                UNION ALL
                (
                SELECT a.estterm_ref_id     AS ESTTERM_REF_ID
                      ,A.EST_DEPT_REF_ID    AS EST_DEPT_REF_ID
                      ,A.DEPT_NAME         AS DEPT_NAME
                      ,ta.ymd               AS YMD
                      ,ta.emp_ref_id        AS EMP_REF_ID
                      ,ta.emp_name          AS EMP_NAME
                      ,ta.ms_score          AS MS_SCORE
                      ,ta.ts_score          AS TS_SCORE
                  FROM EST_DEPT_INFO A
                       inner join ( select a.emp_ref_id, a.emp_code, a.emp_name
                                           , b.dept_ref_id, c.dept_name
                                            ,@YMD   as YMD
                                            ,(select FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, a.emp_ref_id, 'MS') from dual) as ms_score
                                            ,(select FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, a.emp_ref_id, 'TS') from dual) as ts_score        
                                      from com_emp_info a
                                           inner join rel_dept_emp b    on b.rel_status = 1  and b.emp_ref_id  = a.emp_ref_id 
                                           inner join com_dept_info c   on c.dept_flag = 1   and b.dept_ref_id = c.dept_ref_id 
                                     where a.emp_ref_id not in ( select emp_ref_id from com_emp_info 
                                                                  where emp_code = 'admin' or emp_code like 'bscuser%' or emp_code like 'estuser%')
                                 ) ta
                          on ta.dept_ref_id = a.est_dept_ref_id                         
                 WHERE A.ESTTERM_REF_ID = @ESTTERM_REF_ID
                   AND A.TEMP_FLAG = 1
                   AND A.UP_EST_DEPT_ID = @EST_DEPT_REF_ID
                   )  
               ) AA
         ORDER BY AA.TS_SCORE DESC
      ) BB   ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[2].Value = bonbu_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_PRI_RANK_ID", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable GetOrgRankBunpo(object estterm_ref_id, object ymd, object dept_type, object sum_type)
        {
            string query = @"
select BB.TS_GRADE 
       ,COUNT(BB.TS_GRADE) AS GRADE_COUNT
  from (
        select AA.EST_DEPT_REF_ID, AA.DEPT_NAME, AA.TS_SCORE
              ,case WHEN AA.TS_SCORE >= 100 THEN 'S'
                    WHEN AA.TS_SCORE >= 90  THEN 'A'
                    WHEN AA.TS_SCORE >= 80  THEN 'B'
                    WHEN AA.TS_SCORE >= 70  THEN 'C'
                    ELSE 'D' END     AS TS_GRADE
          from (
                  SELECT TA.ESTTERM_REF_ID 
                        ,TA.YMD 
                        ,TA.EST_DEPT_REF_ID 
                        ,TA.DEPT_NAME
                        ,ROUND(SUM(TA.WEIGHT_MS),4)    as MS_WEIGHT
                        ,ROUND(SUM(TA.WEIGHT_TS),4)    as TS_WEIGHT
                        ,ROUND(SUM(TA.SCORE_MS),4)     as MS_SCORE
                        ,ROUND(SUM(TA.SCORE_TS),4)     as TS_SCORE 
                    FROM (
                          SELECT KW.ESTTERM_REF_ID 
                                ,KW.YMD 
                                ,KW.EST_DEPT_REF_ID
                                ,ED.DEPT_NAME 
                                ,NVL(KW.WEIGHT3,0)*(CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                                ,NVL(KW.WEIGHT3,0) as WEIGHT_MS 
                                ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS 
                                ,NVL(KW.SWEIGHT3,0) as WEIGHT_TS
                                ,CASE WHEN @SUM_TYPE = 'MS' THEN TS.POINTS_MS ELSE TS.POINTS_TS END as DEPT_SIGNAL
                            FROM BSC_KPI_WEIGHT KW 
                                 LEFT JOIN BSC_KPI_SCORE TS
                                   ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
                                  AND KW.KPI_REF_ID     = TS.KPI_REF_ID
                                  AND KW.YMD            = TS.YMD
                                  AND KW.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                  AND KW.YMD            = @YMD
                                 INNER JOIN EST_DEPT_INFO ED
                                   ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                                  AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                                  AND ED.TEMP_FLAG = 1
                                  AND ED.DEPT_TYPE = @DEPT_TYPE   
                          ) TA 
                    WHERE TA.YMD = @YMD
                    GROUP BY TA.ESTTERM_REF_ID, TA.DEPT_NAME,TA.YMD ,TA.EST_DEPT_REF_ID
            )  AA  
     )BB      
GROUP BY BB.TS_GRADE           ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@DEPT_TYPE", SqlDbType.VarChar);
            paramArray[2].Value = dept_type;
            paramArray[3] = CreateDataParameter("@SUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = sum_type;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_PRI_RANK_ID", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable GetPriRankBunpo(object estterm_ref_id, object ymd)
        {
            string query = @"
/*
      select ta.ymd
              ,sum(case when ta.ts_score < 70 then 1 else 0 end) as d
              ,sum(case when ta.ts_score < 80 and ta.ts_score >= 70 then 1 else 0 end) as c
              ,sum(case when ta.ts_score < 90 and ta.ts_score >= 80 then 1 else 0 end) as b
              ,sum(case when ta.ts_score < 100 and ta.ts_score >= 90 then 1 else 0 end) as a
              ,sum(case when ta.ts_score >= 100 then 1 else 0 end) as s
          from (
                select a.emp_ref_id, a.emp_name, b.dept_ref_id, c.dept_name
                        ,@ymd as ymd
                        ,(select fn_bsc_mbo_score(@estterm_ref_id,@ymd, a.emp_ref_id, 'ms') from dual) as ms_score
                        ,(select fn_bsc_mbo_score(@estterm_ref_id,@ymd, a.emp_ref_id, 'ts') from dual) as ts_score       
                  from com_emp_info a
                       inner join rel_dept_emp b    on b.rel_status = 1  and b.emp_ref_id  = a.emp_ref_id 
                       inner join com_dept_info c   on c.dept_flag = 1   and b.dept_ref_id = c.dept_ref_id 
                  where a.emp_ref_id not in ( select emp_ref_id from com_emp_info 
                                                where emp_code = 'admin' or emp_code like 'bscuser%' or emp_code like 'estuser%')
               ) ta 
         group by ta.ymd

*/



SELECT TB.TS_GRADE 
       ,COUNT(TB.TS_GRADE) AS GRADE_COUNT
  FROM (
        SELECT TA.EMP_REF_ID, TA.EMP_NAME, TA.TS_SCORE
              ,CASE WHEN TA.TS_SCORE >= 100 THEN 'S'
                    WHEN TA.TS_SCORE >= 90  THEN 'A'
                    WHEN TA.TS_SCORE >= 80  THEN 'B'
                    WHEN TA.TS_SCORE >= 70  THEN 'C'
                    ELSE 'D' END AS TS_GRADE
          FROM (
                SELECT A.EMP_REF_ID, A.EMP_NAME, B.DEPT_REF_ID, C.DEPT_NAME
                        ,@YMD AS YMD
                        ,(SELECT FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, A.EMP_REF_ID, 'MS') FROM DUAL) AS MS_SCORE
                        ,(SELECT FN_BSC_MBO_SCORE(@ESTTERM_REF_ID,@YMD, A.EMP_REF_ID, 'TS') FROM DUAL) AS TS_SCORE       
                  FROM COM_EMP_INFO A
                       INNER JOIN REL_DEPT_EMP B    ON B.REL_STATUS = 1  AND B.EMP_REF_ID  = A.EMP_REF_ID 
                       INNER JOIN COM_DEPT_INFO C   ON C.DEPT_FLAG = 1   AND B.DEPT_REF_ID = C.DEPT_REF_ID 
                  WHERE A.EMP_REF_ID NOT IN ( SELECT EMP_REF_ID FROM COM_EMP_INFO 
                                                WHERE EMP_CODE = 'ADMIN' OR EMP_CODE LIKE 'BSCUSER%' OR EMP_CODE LIKE 'ESTUSER%')
               ) TA                                        
       ) TB
GROUP BY TB.TS_GRADE 
      ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
          
            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_PRI_RANK_ID", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetDeptInfo(object dept_ref_id)
        {
            string query = @"
   SELECT EST_DEPT_REF_ID
        , DEPT_REF_ID
        , DEPT_NAME
        , DEPT_TYPE
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (1) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_1
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (2) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_2
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (3) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_3
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (4) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_4
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (5) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_5  
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (6) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_6  
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (7) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_7
        , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (8) THEN EST_DEPT_REF_ID ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_8       
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (1) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_1N
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (2) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_2N
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (3) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_3N
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (4) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_4N
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (5) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_5N 
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (6) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_6N
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (7) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_7N
                    , LTRIM(RTRIM(SYS_CONNECT_BY_PATH(CASE WHEN DEPT_TYPE IN (8) THEN DEPT_NAME ELSE NULL END, ' '))) AS EST_DEPT_REF_ID_8N                   
  FROM V_COM_EST_DEPT_JOIN 
WHERE DEPT_REF_ID = @DEPT_REF_ID 
START WITH DEPT_TYPE  = 1 
CONNECT BY PRIOR EST_DEPT_REF_ID = UP_EST_DEPT_ID 

";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = dept_ref_id;

            DataTable dt = DbAgentObj.FillDataSet( query, "BSC_INTRO_MBO_SCORE", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetOrgScore(object sum_type, object estterm_ref_id, object ymd, object est_dept_ref_id)
        {
            string query = @"
 SELECT TA.ESTTERM_REF_ID 
                        ,TA.YMD 
                        ,TA.EST_DEPT_REF_ID 
                        ,ROUND(SUM(TA.WEIGHT_MS),4)    as WEIGHT_MS
                        ,ROUND(SUM(TA.WEIGHT_TS),4)    as WEIGHT_TS
                        ,ROUND(SUM(TA.SCORE_MS),4)     as SCORE_MS
                        ,ROUND(SUM(TA.SCORE_TS),4)     as SCORE_TS
                    FROM (
                          SELECT KW.ESTTERM_REF_ID 
                                ,KW.YMD 
                                ,KW.EST_DEPT_REF_ID 
                                ,NVL(KW.WEIGHT3,0)*(CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_MS)*0.01 END) as SCORE_MS 
                                ,NVL(KW.WEIGHT3,0) as WEIGHT_MS 
                                ,NVL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE TO_NUMBER(TS.POINTS_TS)*0.01 END) as SCORE_TS 
                                ,NVL(KW.SWEIGHT3,0) as WEIGHT_TS
                                ,CASE WHEN @SUM_TYPE = 'MS' THEN TS.POINTS_MS ELSE TS.POINTS_TS END as DEPT_SIGNAL
                            FROM BSC_KPI_WEIGHT KW 
                                 LEFT JOIN BSC_KPI_SCORE TS
                                   ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
                                  AND KW.KPI_REF_ID     = TS.KPI_REF_ID
                                  AND KW.YMD            = TS.YMD
                                  AND KW.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                  AND KW.YMD            = @YMD
                                 LEFT JOIN EST_DEPT_INFO ED
                                   ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
                                  AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
                          ) TA 
                    WHERE TA.EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                      AND TA.YMD = @YMD
                    GROUP BY TA.ESTTERM_REF_ID ,TA.YMD ,TA.EST_DEPT_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@SUM_TYPE", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);

            paramArray[0].Value = sum_type;
            paramArray[1].Value = estterm_ref_id;
            paramArray[2].Value = ymd;
            paramArray[3].Value = est_dept_ref_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_SCORE", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable GetJeonsaInfo(object estterm_ref_id)
        {
            string query = @"
select EST_DEPT_REF_ID, DEPT_NAME from est_dept_info
 where dept_type = ( select type_ref_id from com_dept_type_info
                      where est_comp_yn = 'Y' )
   and estterm_ref_id = @ESTTERM_REF_ID 
";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

           
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;


            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_INTRO_ORG_SCORE", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable GetBscSchedule(object schd_top, object row_cnt)
        {
            string query = @"
SELECT SCHD_TOP, SCHD_MID, SCHD_MID_DESC, SCHD_END_DATE , LINK_DIR, LINK_PAGE_NAME, LIVE_YN FROM BSC_DASHBOARD_SCHD
WHERE (SCHD_TOP = @SCHD_TOP     )
  AND (ROWNUM  <= @ROWCNT )
ORDER BY SCHD_MID_ORDER ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@SCHD_TOP", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@ROWCNT", SqlDbType.Int);

            paramArray[0].Value = schd_top;
            paramArray[1].Value = row_cnt;

          

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_SCHEDULE", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }
    }
}