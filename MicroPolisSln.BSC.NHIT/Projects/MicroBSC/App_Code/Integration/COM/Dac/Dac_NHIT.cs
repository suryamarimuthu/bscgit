using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_NHIT : DbAgentBase
    {
        public Dac_NHIT()
        {

        }

        #region ====================   농협 Dashboard 메인 =====================


        public DataTable SelectYear_DB()
        {
            DataSet DS = new DataSet();
            string query = @"


SELECT CR_YEAR 
     , CR_YEAR + '년' AS CR_YEAR_NAME
FROM NHIT_DASHBOARD_MAIN 
GROUP BY CR_YEAR
ORDER BY CR_YEAR

";

            DS = DbAgentObj.Fill(query, null);

            return DS.Tables[0];
        }

        public DataTable SelectMonth_DB()
        {
            DataSet DS = new DataSet();
            string query = @"

SELECT CR_MONTH
     , CR_MONTH + '월' AS CR_MONTH_NAME
FROM NHIT_DASHBOARD_MAIN 
GROUP BY CR_MONTH
ORDER BY CR_MONTH

";

            DS = DbAgentObj.Fill(query, null);

            return DS.Tables[0];
        }

        // 전사 매출/손익
        public DataTable SelectJeonSa(object grp_one_code
                                     , object grp_two_code
                                     , object grp_three_code
                                     , object cr_year
                                     , object cr_month
                                     , object tg_gubun)
        {
            string query = @"

SELECT GRP_ONE_CODE
      ,GRP_ONE_NAME
      ,GRP_TWO_CODE
      ,GRP_TWO_NAME
      ,GRP_THREE_CODE
      ,GRP_THREE_NAME
    ,CR_YEAR
    ,CR_MONTH
    ,CR_MONTH   +   '월'       AS   CR_MONTH_NAME
    ,TARGET_YEAR
    ,TARGET_TS
    ,RESULT_TS
    ,DAL_RATE 
FROM NHIT_DASHBOARD_MAIN 
WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
  AND GRP_TWO_CODE   = @GRP_TWO_CODE
  AND GRP_THREE_CODE = @GRP_THREE_CODE
  AND (CR_YEAR  = @CR_YEAR   )
  AND (CR_MONTH = @CR_MONTH  OR  @CR_MONTH =''   )
  AND TG_GUBUN = @TG_GUBUN
ORDER BY GRP_TWO_CODE, CR_MONTH

";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@GRP_ONE_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = grp_one_code;
            paramArray[1] = CreateDataParameter("@GRP_TWO_CODE", SqlDbType.NVarChar);
            paramArray[1].Value = grp_two_code;
            paramArray[2] = CreateDataParameter("@GRP_THREE_CODE", SqlDbType.NVarChar);
            paramArray[2].Value = grp_three_code;
            paramArray[3] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[3].Value = cr_year;
            paramArray[4] = CreateDataParameter("@CR_MONTH", SqlDbType.NVarChar);
            paramArray[4].Value = cr_month;
            paramArray[5] = CreateDataParameter("@TG_GUBUN", SqlDbType.NVarChar);
            paramArray[5].Value = tg_gubun;

            return DbAgentObj.Fill(query, paramArray).Tables[0];

        }

        // 전사 매출/손익
        public DataTable SelectJeonSa(object grp_one_code
                                 , object grp_two_code
                                 , object cr_year
                                 , object cr_month
                                 , object tg_gubun)
        {
            string query = @"


SELECT GRP_ONE_CODE
      ,GRP_ONE_NAME
      ,GRP_TWO_CODE
      ,GRP_TWO_NAME
      ,GRP_THREE_CODE
      ,GRP_THREE_NAME
    ,CR_YEAR
    ,CR_MONTH
    ,TARGET_YEAR
    ,TARGET_TS
    ,NVL(RESULT_TS,0) AS RESULT_TS
    ,NVL(DAL_RATE,0) AS DAL_RATE  
    ,(NVL(DAL_RATE,0) * 100 ) AS DAL_RATE_100  
    ,SORT_ORDER 
     FROM (

                    SELECT GRP_ONE_CODE
                          ,GRP_ONE_NAME
                          ,GRP_TWO_CODE
                          ,GRP_TWO_NAME
                          ,GRP_THREE_CODE
                          ,GRP_THREE_NAME
                        ,CR_YEAR
                        ,CR_MONTH
                        ,TARGET_YEAR
                        ,TARGET_TS
                        ,RESULT_TS
                        ,DAL_RATE 
                        ,10          AS SORT_ORDER
                    FROM NHIT_DASHBOARD_MAIN 
                    WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
                      AND GRP_TWO_CODE   = @GRP_TWO_CODE
                      AND GRP_THREE_CODE = 'ME'
                      AND (CR_YEAR  = @CR_YEAR   OR  @CR_YEAR  =''   )
                      AND (CR_MONTH = @CR_MONTH  OR  @CR_MONTH =''   )
                      AND TG_GUBUN = @TG_GUBUN
                      
                    UNION
                     

                    SELECT GRP_ONE_CODE
                          ,GRP_ONE_NAME
                          ,GRP_TWO_CODE
                          ,GRP_TWO_NAME
                          ,GRP_THREE_CODE
                          ,GRP_THREE_NAME
                        ,CR_YEAR
                        ,CR_MONTH
                        ,TARGET_YEAR
                        ,TARGET_TS
                        ,RESULT_TS
                        ,DAL_RATE 
                        ,20          AS SORT_ORDER
                    FROM NHIT_DASHBOARD_MAIN 
                    WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
                      AND GRP_TWO_CODE   = @GRP_TWO_CODE
                      AND GRP_THREE_CODE = 'YG'
                      AND (CR_YEAR  = @CR_YEAR   OR  @CR_YEAR  =''   )
                      AND (CR_MONTH = @CR_MONTH  OR  @CR_MONTH =''   )
                      AND TG_GUBUN = @TG_GUBUN
                      
                    UNION


                    SELECT GRP_ONE_CODE
                          ,GRP_ONE_NAME
                          ,GRP_TWO_CODE
                          ,GRP_TWO_NAME
                          ,GRP_THREE_CODE
                          ,GRP_THREE_NAME
                        ,CR_YEAR
                        ,CR_MONTH
                        ,TARGET_YEAR
                        ,TARGET_TS
                        ,RESULT_TS
                        ,DAL_RATE 
                        ,30          AS SORT_ORDER
                    FROM NHIT_DASHBOARD_MAIN 
                    WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
                      AND GRP_TWO_CODE   = @GRP_TWO_CODE
                      AND GRP_THREE_CODE = 'DN'
                      AND (CR_YEAR  = @CR_YEAR   OR  @CR_YEAR  =''   )
                      AND (CR_MONTH = @CR_MONTH  OR  @CR_MONTH =''   )
                      AND TG_GUBUN = @TG_GUBUN

             )  TBL 
ORDER BY SORT_ORDER

";



            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@GRP_ONE_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = grp_one_code;
            paramArray[1] = CreateDataParameter("@GRP_TWO_CODE", SqlDbType.NVarChar);
            paramArray[1].Value = grp_two_code;
            paramArray[2] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[2].Value = cr_year;
            paramArray[3] = CreateDataParameter("@CR_MONTH", SqlDbType.NVarChar);
            paramArray[3].Value = cr_month;
            paramArray[4] = CreateDataParameter("@TG_GUBUN", SqlDbType.NVarChar);
            paramArray[4].Value = tg_gubun;

            return DbAgentObj.Fill(query, paramArray).Tables[0];

        }

        // 전사 매출/손익
        public DataTable SelectJeonSaPOPUP(object grp_one_code
                                 , object grp_two_code
                                 , object cr_year
                                 , object tg_gubun
                                 )
        {
            string query = @"


SELECT GRP_ONE_CODE
      ,GRP_ONE_NAME
      ,GRP_TWO_CODE
      ,GRP_TWO_NAME
      ,GRP_THREE_CODE
      ,GRP_THREE_NAME
    ,CR_YEAR
    ,CR_MONTH
    ,TARGET_YEAR
    ,TARGET_TS
    ,NVL(RESULT_TS,0) AS RESULT_TS
    ,NVL(DAL_RATE,0) AS DAL_RATE  
    ,(NVL(DAL_RATE,0) * 100 ) AS DAL_RATE_100  
    ,SORT_ORDER 
     FROM (

                    SELECT GRP_ONE_CODE
                          ,GRP_ONE_NAME
                          ,GRP_TWO_CODE
                          ,GRP_TWO_NAME
                          ,GRP_THREE_CODE
                          ,GRP_THREE_NAME
                        ,CR_YEAR
                        ,CR_MONTH
                        ,TARGET_YEAR
                        ,TARGET_TS
                        ,RESULT_TS
                        ,DAL_RATE 
                        ,10          AS SORT_ORDER
                    FROM NHIT_DASHBOARD_MAIN 
                    WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
                      AND GRP_TWO_CODE   = @GRP_TWO_CODE
                      AND GRP_THREE_CODE = 'ME'
                      AND (CR_YEAR  = @CR_YEAR   OR  @CR_YEAR  =''   )
                      AND TG_GUBUN = @TG_GUBUN
                      
                    UNION
                     

                    SELECT GRP_ONE_CODE
                          ,GRP_ONE_NAME
                          ,GRP_TWO_CODE
                          ,GRP_TWO_NAME
                          ,GRP_THREE_CODE
                          ,GRP_THREE_NAME
                        ,CR_YEAR
                        ,CR_MONTH
                        ,TARGET_YEAR
                        ,TARGET_TS
                        ,RESULT_TS
                        ,DAL_RATE 
                        ,20          AS SORT_ORDER
                    FROM NHIT_DASHBOARD_MAIN 
                    WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
                      AND GRP_TWO_CODE   = @GRP_TWO_CODE
                      AND GRP_THREE_CODE = 'YG'
                      AND (CR_YEAR  = @CR_YEAR   OR  @CR_YEAR  =''   )
                      AND TG_GUBUN = @TG_GUBUN
                      
                    UNION


                    SELECT GRP_ONE_CODE
                          ,GRP_ONE_NAME
                          ,GRP_TWO_CODE
                          ,GRP_TWO_NAME
                          ,GRP_THREE_CODE
                          ,GRP_THREE_NAME
                        ,CR_YEAR
                        ,CR_MONTH
                        ,TARGET_YEAR
                        ,TARGET_TS
                        ,RESULT_TS
                        ,DAL_RATE 
                        ,30          AS SORT_ORDER
                    FROM NHIT_DASHBOARD_MAIN 
                    WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
                      AND GRP_TWO_CODE   = @GRP_TWO_CODE
                      AND GRP_THREE_CODE = 'DN'
                      AND (CR_YEAR  = @CR_YEAR   OR  @CR_YEAR  =''   )
                      AND TG_GUBUN = @TG_GUBUN

             )  TBL 
ORDER BY SORT_ORDER 

";



            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@GRP_ONE_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = grp_one_code;
            paramArray[1] = CreateDataParameter("@GRP_TWO_CODE", SqlDbType.NVarChar);
            paramArray[1].Value = grp_two_code;
            paramArray[2] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[2].Value = cr_year;
            paramArray[3] = CreateDataParameter("@TG_GUBUN", SqlDbType.NVarChar);
            paramArray[3].Value = tg_gubun;
           
            return DbAgentObj.Fill(query, paramArray).Tables[0];

        }

        public DataTable SelectInPower(string cr_year)
        {
            string query = @"

SELECT CR_YEAR 
    ,CR_MONTH      
    ,CR_MONTH  ||  '월'        AS CR_MONTH_NAME
    ,TARGET_FULL_RATE 
    ,RESULT_FULL_RATE 
    ,RESULT_DONG_RATE 
    ,RESULT_BDONG_RATE 
    ,TARGET_FULL_RATE / 100   AS TARGET_FULL_RATE_001
    ,RESULT_FULL_RATE / 100   AS RESULT_FULL_RATE_001
    ,RESULT_DONG_RATE / 100   AS RESULT_DONG_RATE_001
    ,RESULT_BDONG_RATE / 100   AS RESULT_BDONG_RATE_001
    ,TARGET_FULL_RATE * 100    AS TARGET_FULL_RATE_100
    ,RESULT_FULL_RATE * 100    AS RESULT_FULL_RATE_100
    ,RESULT_DONG_RATE * 100    AS RESULT_DONG_RATE_100
    ,RESULT_BDONG_RATE * 100   AS RESULT_BDONG_RATE_100
 FROM NHIT_DASHBOARD_EMP_MERGE
WHERE CR_YEAR = @CR_YEAR
ORDER BY CR_MONTH

";



            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[0].Value = cr_year;


            return DbAgentObj.Fill(query, paramArray).Tables[0];

        }


        public DataTable SelectEtc(object grp_one_code
                                         , object cr_year
                                         , object cr_month
                                         , object tg_gubun)
        {
            string query = @"

SELECT GRP_ONE_CODE
      ,GRP_ONE_NAME
      ,GRP_TWO_CODE
      ,GRP_TWO_NAME
      ,CR_YEAR
      ,CR_MONTH
      ,SUM(ME_TARGET_YEAR)   AS ME_TARGET_YEAR
      ,SUM(ME_TARGET_TS)     AS ME_TARGET_TS
      ,SUM(ME_RESULT_TS)     AS ME_RESULT_TS
      ,SUM(ME_DAL_RATE)      AS ME_DAL_RATE
      ,SUM(ME_DAL_RATE) * 100      AS ME_DAL_RATE_100
      ,SUM(YG_TARGET_YEAR)   AS YG_TARGET_YEAR
      ,SUM(YG_TARGET_TS)     AS YG_TARGET_TS
      ,SUM(YG_RESULT_TS)     AS YG_RESULT_TS
      ,SUM(YG_DAL_RATE)      AS YG_DAL_RATE
      ,SUM(YG_DAL_RATE) * 100     AS YG_DAL_RATE_100
      ,SUM(DN_TARGET_YEAR)   AS DN_TARGET_YEAR
      ,SUM(DN_TARGET_TS)     AS DN_TARGET_TS
      ,SUM(DN_RESULT_TS)     AS DN_RESULT_TS
      ,SUM(DN_DAL_RATE)      AS DN_DAL_RATE
      ,SUM(DN_DAL_RATE) * 100      AS DN_DAL_RATE_100
 FROM(

            SELECT GRP_ONE_CODE
                  ,GRP_ONE_NAME
                  ,GRP_TWO_CODE
                  ,GRP_TWO_NAME
                  ,GRP_THREE_CODE
                  ,GRP_THREE_NAME
                ,CR_YEAR
                ,CR_MONTH
                ,TARGET_YEAR          AS ME_TARGET_YEAR
                ,TARGET_TS            AS ME_TARGET_TS
                ,RESULT_TS            AS ME_RESULT_TS
                ,DAL_RATE             AS ME_DAL_RATE
                ,0                    AS YG_TARGET_YEAR
                ,0                    AS YG_TARGET_TS
                ,0                    AS YG_RESULT_TS
                ,0                    AS YG_DAL_RATE
                ,0                    AS DN_TARGET_YEAR
                ,0                    AS DN_TARGET_TS
                ,0                    AS DN_RESULT_TS
                ,0                    AS DN_DAL_RATE
            FROM NHIT_DASHBOARD_MAIN 
            WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
              AND GRP_THREE_CODE = 'ME'
              AND CR_YEAR        = @CR_YEAR
              AND (CR_MONTH      = @CR_MONTH        OR     @CR_MONTH    =''       )
              AND TG_GUBUN = @TG_GUBUN
                                          
            UNION

            SELECT GRP_ONE_CODE
                  ,GRP_ONE_NAME
                  ,GRP_TWO_CODE
                  ,GRP_TWO_NAME
                  ,GRP_THREE_CODE
                  ,GRP_THREE_NAME
                ,CR_YEAR
                ,CR_MONTH
                ,0                    AS ME_TARGET_YEAR
                ,0                    AS ME_TARGET_TS
                ,0                    AS ME_RESULT_TS
                ,0                    AS ME_DAL_RATE
                ,TARGET_YEAR          AS YG_TARGET_YEAR
                ,TARGET_TS            AS YG_TARGET_TS
                ,RESULT_TS            AS YG_RESULT_TS
                ,DAL_RATE             AS YG_DAL_RATE
                ,0                    AS DN_TARGET_YEAR
                ,0                    AS DN_TARGET_TS
                ,0                    AS DN_RESULT_TS
                ,0                    AS DN_DAL_RATE
            FROM NHIT_DASHBOARD_MAIN 
            WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
              AND GRP_THREE_CODE = 'YG'
              AND CR_YEAR        = @CR_YEAR
              AND (CR_MONTH      = @CR_MONTH        OR     @CR_MONTH    =''       )
              AND TG_GUBUN = @TG_GUBUN

            UNION

            SELECT GRP_ONE_CODE
                  ,GRP_ONE_NAME
                  ,GRP_TWO_CODE
                  ,GRP_TWO_NAME
                  ,GRP_THREE_CODE
                  ,GRP_THREE_NAME
                ,CR_YEAR
                ,CR_MONTH
                ,0                    AS ME_TARGET_YEAR
                ,0                    AS ME_TARGET_TS
                ,0                    AS ME_RESULT_TS
                ,0                    AS ME_DAL_RATE
                ,0                    AS YG_TARGET_YEAR
                ,0                    AS YG_TARGET_TS
                ,0                    AS YG_RESULT_TS
                ,0                    AS YG_DAL_RATE
                ,TARGET_YEAR          AS DN_TARGET_YEAR
                ,TARGET_TS            AS DN_TARGET_TS
                ,RESULT_TS            AS DN_RESULT_TS
                ,DAL_RATE             AS DN_DAL_RATE
            FROM NHIT_DASHBOARD_MAIN 
            WHERE GRP_ONE_CODE   = @GRP_ONE_CODE
              AND GRP_THREE_CODE = 'DN'
              AND CR_YEAR        = @CR_YEAR
              AND (CR_MONTH      = @CR_MONTH        OR     @CR_MONTH    =''       )
              AND TG_GUBUN = @TG_GUBUN

           ) TBL
GROUP BY GRP_ONE_CODE
        ,GRP_ONE_NAME
        ,GRP_TWO_CODE
        ,GRP_TWO_NAME
        ,CR_YEAR
        ,CR_MONTH
ORDER BY GRP_TWO_CODE

";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@GRP_ONE_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = grp_one_code;
            paramArray[1] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[1].Value = cr_year;
            paramArray[2] = CreateDataParameter("@CR_MONTH", SqlDbType.NVarChar);
            paramArray[2].Value = cr_month;
            paramArray[3] = CreateDataParameter("@TG_GUBUN", SqlDbType.NVarChar);
            paramArray[3].Value = tg_gubun;

            return DbAgentObj.Fill(query, paramArray).Tables[0];
        }


        #endregion

        #region ====================   농협 Dashboard 인력정산 세부 =====================





        public DataTable SelectEmpProject(object cr_year
                                      , object cr_month)
        {
            string query = @"


SELECT CR_YEAR
        ,CR_MONTH
        ,BONBU_NAME
        ,TEAM_NAME
        ,GRP_ONE_B_NAME
        ,GRP_ONE_C_NAME
        ,PROJECT_NAME
        ,COUNT(EMP_NAME) AS EMP_COUNT
 FROM NHIT_DASHBOARD_EMP 
WHERE CR_YEAR  = @CR_YEAR
  AND CR_MONTH = @CR_MONTH
GROUP BY CR_YEAR
        ,CR_MONTH
        ,BONBU_NAME
        ,TEAM_NAME
        ,GRP_ONE_B_NAME
        ,GRP_ONE_C_NAME
        ,PROJECT_NAME
ORDER BY CR_YEAR
        ,CR_MONTH
        ,BONBU_NAME
        ,TEAM_NAME
        ,GRP_ONE_B_NAME
        ,GRP_ONE_C_NAME
        ,PROJECT_NAME

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[0].Value = cr_year;
            paramArray[1] = CreateDataParameter("@CR_MONTH", SqlDbType.NVarChar);
            paramArray[1].Value = cr_month;

            return DbAgentObj.Fill(query, paramArray).Tables[0];
        }


        public DataTable SelectEmpProjectDetail(object cr_year
                                              , object cr_month
                                              , object project_name)
        {
            string query = @"


SELECT CR_YEAR
        ,CR_MONTH
        ,BONBU_NAME
        ,TEAM_NAME
        ,GRP_ONE_B_NAME
        ,GRP_ONE_C_NAME 
        ,EMP_NAME
        ,RESULT_FULL
        ,RESULT_DONG
        ,RESULT_BDONG
 FROM NHIT_DASHBOARD_EMP 
WHERE CR_YEAR  = @CR_YEAR
  AND CR_MONTH = @CR_MONTH
  AND PROJECT_NAME = @PROJECT_NAME
ORDER BY CR_YEAR
        ,CR_MONTH
        ,BONBU_NAME
        ,TEAM_NAME
        ,GRP_ONE_B_NAME
        ,GRP_ONE_C_NAME 
        ,EMP_NAME
        ,RESULT_FULL
        ,RESULT_DONG
        ,RESULT_BDONG
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[0].Value = cr_year;
            paramArray[1] = CreateDataParameter("@CR_MONTH", SqlDbType.NVarChar);
            paramArray[1].Value = cr_month;
            paramArray[2] = CreateDataParameter("@PROJECT_NAME", SqlDbType.NVarChar);
            paramArray[2].Value = project_name;

            return DbAgentObj.Fill(query, paramArray).Tables[0];
        }



        #endregion



        #region ====================   농협 Dashboard 프로젝트 세부 =====================



        public DataTable SelectProjectDetail(object cr_year
                                          , object grp_one_b_code
                                          , object grp_one_c_code
                                          , object grp_one_d_code)
        {
            string query = @"


SELECT CR_YEAR    ,
  PROJECT_CODE    ,
  PROJECT_NAME    ,
  GUBUN_ONE       ,
  GRP_ONE_C_CODE  ,
  GRP_ONE_C_NAME  ,
  GRP_ONE_B_CODE  ,
  GRP_ONE_B_NAME  ,
  GRP_ONE_D_CODE  ,
  GRP_ONE_D_NAME  ,
  TEAM_NAME       ,
  PLAN_STR        ,
  PLAN_END        ,
  END_YN          ,
  GE_COMP         ,
  BUNLYU_CODE     ,
  MECHUL          ,
  SANPUM          ,
  JAERYO          ,
  OYJU            ,
  JICK_EMP        ,
  JICK_KYUNG      ,
  HANGAE          ,
  BUN_EMP         ,
  BUN_KYUNG       ,
  JUNSA_EMP       ,
  JUNSA_KYUNG     ,
  MECHUL_TOT      ,
  PANME_EMP       ,
  PANME_KYUNG     ,
  YOUNGUP         
 FROM NHIT_DASHBOARD_PMS 
WHERE CR_YEAR         = @CR_YEAR
  AND (GRP_ONE_B_CODE = @GRP_ONE_B_CODE        OR   @GRP_ONE_B_CODE  =''   )
  AND (GRP_ONE_C_CODE = @GRP_ONE_C_CODE        OR   @GRP_ONE_C_CODE  =''   )
  AND (GRP_ONE_D_CODE = @GRP_ONE_D_CODE        OR   @GRP_ONE_D_CODE  =''   )
ORDER BY PROJECT_NAME    ,
         GRP_ONE_C_CODE  ,          
         GRP_ONE_B_CODE  ,          
         GRP_ONE_D_CODE  ,
         TEAM_NAME       ,
         GE_COMP         

";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.NVarChar);
            paramArray[0].Value = cr_year;
            paramArray[1] = CreateDataParameter("@GRP_ONE_B_CODE", SqlDbType.NVarChar);
            paramArray[1].Value = grp_one_b_code;
            paramArray[2] = CreateDataParameter("@GRP_ONE_C_CODE", SqlDbType.NVarChar);
            paramArray[2].Value = grp_one_c_code;
            paramArray[3] = CreateDataParameter("@GRP_ONE_D_CODE", SqlDbType.NVarChar);
            paramArray[3].Value = grp_one_d_code;

            return DbAgentObj.Fill(query, paramArray).Tables[0];
        }



        #endregion

    }
}
