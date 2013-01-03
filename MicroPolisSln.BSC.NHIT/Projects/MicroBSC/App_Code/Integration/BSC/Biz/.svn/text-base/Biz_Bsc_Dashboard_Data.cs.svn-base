using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MicroBSC.Integration.BSC.Dac;
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Dashboard_Data
    {
        public int NHIT_DASHBOARD_EMP_Insert(string CR_YEAR,
            string CR_MONTH,
            string BONBU_NAME,
            string TEAM_NAME,
            string GRP_ONE_B_NAME,
            string GRP_ONE_C_NAME,
            string PROJECT_NAME,
            string EMP_NAME,
            float RESULT_FULL,
            float RESULT_DONG,
            float RESULT_BDONG)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_Insert(CR_YEAR, CR_MONTH, BONBU_NAME, TEAM_NAME, GRP_ONE_B_NAME, GRP_ONE_C_NAME, PROJECT_NAME, EMP_NAME, RESULT_FULL, RESULT_DONG, RESULT_BDONG);
        }

        public int NHIT_DASHBOARD_EMP_Delete(string CR_YEAR,
          string CR_MONTH,
          string BONBU_NAME,
          string TEAM_NAME,
          string GRP_ONE_B_NAME,
          string GRP_ONE_C_NAME,
          string PROJECT_NAME,
          string EMP_NAME)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_Delete(CR_YEAR, CR_MONTH, BONBU_NAME, TEAM_NAME, GRP_ONE_B_NAME, GRP_ONE_C_NAME, PROJECT_NAME, EMP_NAME);
        }

        public int NHIT_DASHBOARD_EMP_MERGE_Insert(string CR_YEAR, string CR_MONTH,
           float TARGET_FULL_RATE, float RESULT_FULL_RATE, float RESULT_DONG_RATE, float RESULT_BDONG_RATE,
           float TARGET_DONG_RATE, float RESULT_FULL_RATE_MS, float RESULT_DONG_RATE_MS, float RESULT_BDONG_RATE_MS)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_MERGE_Insert(CR_YEAR, CR_MONTH,
                TARGET_FULL_RATE, RESULT_FULL_RATE, RESULT_DONG_RATE, RESULT_BDONG_RATE,
                 TARGET_DONG_RATE, RESULT_FULL_RATE_MS, RESULT_DONG_RATE_MS, RESULT_BDONG_RATE_MS);
        }


        public int NHIT_DASHBOARD_EMP_MERGE_Delete(string CR_YEAR, string CR_MONTH)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_EMP_MERGE_Delete(CR_YEAR, CR_MONTH);
        }

        public int NHIT_DASHBOARD_MAIN_Insert(string GRP_ONE_CODE, string GRP_ONE_NAME,
            string GRP_TWO_CODE, string GRP_TWO_NAME, string GRP_THREE_CODE, string GRP_THREE_NAME,
            string CR_YEAR, string CR_MONTH, float TARGET_YEAR, float TARGET_TS,
            float RESULT_TS, float DAL_RATE, string TG_GUBUN)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_MAIN_Insert(GRP_ONE_CODE, GRP_ONE_NAME,
                GRP_TWO_CODE, GRP_TWO_NAME, GRP_THREE_CODE, GRP_THREE_NAME,
                CR_YEAR, CR_MONTH, TARGET_YEAR, TARGET_TS,
                RESULT_TS, DAL_RATE, TG_GUBUN);
        }


        public int NHIT_DASHBOARD_MAIN_Delete(string GRP_ONE_CODE, string GRP_TWO_CODE, string GRP_THREE_CODE, string CR_YEAR, string CR_MONTH, string TG_GUBUN)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_MAIN_Delete(GRP_ONE_CODE, GRP_TWO_CODE, GRP_THREE_CODE, CR_YEAR, CR_MONTH, TG_GUBUN);
        }

        public int NHIT_DASHBOARD_PMS_Insert(string CR_YEAR, string PROJECT_CODE, string PROJECT_NAME,
            string GUBUN_ONE, string GRP_ONE_C_CODE, string GRP_ONE_C_NAME,
            string GRP_ONE_B_CODE, string GRP_ONE_B_NAME, string GRP_ONE_D_CODE,
            string GRP_ONE_D_NAME, string TEAM_NAME, string PLAN_STR,
            string PLAN_END, string END_YN, string GE_COMP,
            string BUNLYU_CODE, float MECHUL, float SANPUM,
            float JAERYO, float OYJU, float JICK_EMP,
            float JICK_KYUNG, float HANGAE, float BUN_EMP,
            float BUN_KYUNG, float JUNSA_EMP, float JUNSA_KYUNG,
            float MECHUL_TOT, float PANME_EMP, float PANME_KYUNG,
            float YOUNGUP)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_PMS_Insert(CR_YEAR, PROJECT_CODE, PROJECT_NAME,
               GUBUN_ONE, GRP_ONE_C_CODE, GRP_ONE_C_NAME,
               GRP_ONE_B_CODE, GRP_ONE_B_NAME, GRP_ONE_D_CODE,
               GRP_ONE_D_NAME, TEAM_NAME, PLAN_STR,
               PLAN_END, END_YN, GE_COMP,
               BUNLYU_CODE, MECHUL, SANPUM,
               JAERYO, OYJU, JICK_EMP,
               JICK_KYUNG, HANGAE, BUN_EMP,
               BUN_KYUNG, JUNSA_EMP, JUNSA_KYUNG,
               MECHUL_TOT, PANME_EMP, PANME_KYUNG,
               YOUNGUP);
        }

        public int NHIT_DASHBOARD_PMS_Delete(string CR_YEAR, string PROJECT_CODE,
            string GUBUN_ONE, string GRP_ONE_C_CODE,
            string GRP_ONE_B_CODE, string GRP_ONE_D_CODE,
            string TEAM_NAME)
        {
            return new Dac_Bsc_Dashboard_Data().NHIT_DASHBOARD_PMS_Delete(CR_YEAR, PROJECT_CODE,
               GUBUN_ONE, GRP_ONE_C_CODE,
               GRP_ONE_B_CODE, GRP_ONE_D_CODE,
                TEAM_NAME);
        }

    }
}
