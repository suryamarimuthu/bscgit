using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MicroBSC.Data;

namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Dashboard_Data : DbAgentBase
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
            string qry = @"INSERT INTO NHIT_DASHBOARD_EMP VALUES(
                @CR_YEAR,
                @CR_MONTH,
                @BONBU_NAME,
                @TEAM_NAME,
                @GRP_ONE_B_NAME,
                @GRP_ONE_C_NAME,
                @PROJECT_NAME,
                @EMP_NAME,
                @RESULT_FULL,
                @RESULT_DONG,
                @RESULT_BDONG) ";
            IDbDataParameter[] paramArray = CreateDataParameters(11);
            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[0].Value = CR_YEAR;
            paramArray[1] = CreateDataParameter("@CR_MONTH", SqlDbType.VarChar);
            paramArray[1].Value = CR_MONTH;
            paramArray[2] = CreateDataParameter("@BONBU_NAME", SqlDbType.VarChar);
            paramArray[2].Value = BONBU_NAME;
            paramArray[3] = CreateDataParameter("@TEAM_NAME", SqlDbType.VarChar);
            paramArray[3].Value = TEAM_NAME;
            paramArray[4] = CreateDataParameter("@GRP_ONE_B_NAME", SqlDbType.VarChar);
            paramArray[4].Value = GRP_ONE_B_NAME;
            paramArray[5] = CreateDataParameter("@GRP_ONE_C_NAME", SqlDbType.VarChar);
            paramArray[5].Value = GRP_ONE_C_NAME;
            paramArray[6] = CreateDataParameter("@PROJECT_NAME", SqlDbType.VarChar);
            paramArray[6].Value = PROJECT_NAME;
            paramArray[7] = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[7].Value = EMP_NAME;
            paramArray[8] = CreateDataParameter("@RESULT_FULL", SqlDbType.Float);
            paramArray[8].Value = RESULT_FULL;
            paramArray[9] = CreateDataParameter("@RESULT_DONG", SqlDbType.Float);
            paramArray[9].Value = RESULT_DONG;
            paramArray[10] = CreateDataParameter("@RESULT_BDONG", SqlDbType.Float);
            paramArray[10].Value = RESULT_BDONG;
            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
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
            string qry = @"
DELETE FROM NHIT_DASHBOARD_EMP
WHERE CR_YEAR  = @CR_YEAR 
  AND CR_MONTH = @CR_MONTH 
  AND BONBU_NAME = @BONBU_NAME 
  AND TEAM_NAME = @TEAM_NAME 
  AND GRP_ONE_B_NAME = @GRP_ONE_B_NAME 
  AND GRP_ONE_C_NAME = @GRP_ONE_C_NAME 
  AND PROJECT_NAME = @PROJECT_NAME 
  AND EMP_NAME = @EMP_NAME ";
            IDbDataParameter[] paramArray = CreateDataParameters(8);
            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[0].Value = CR_YEAR;
            paramArray[1] = CreateDataParameter("@CR_MONTH", SqlDbType.VarChar);
            paramArray[1].Value = CR_MONTH;
            paramArray[2] = CreateDataParameter("@BONBU_NAME", SqlDbType.VarChar);
            paramArray[2].Value = BONBU_NAME;
            paramArray[3] = CreateDataParameter("@TEAM_NAME", SqlDbType.VarChar);
            paramArray[3].Value = TEAM_NAME;
            paramArray[4] = CreateDataParameter("@GRP_ONE_B_NAME", SqlDbType.VarChar);
            paramArray[4].Value = GRP_ONE_B_NAME;
            paramArray[5] = CreateDataParameter("@GRP_ONE_C_NAME", SqlDbType.VarChar);
            paramArray[5].Value = GRP_ONE_C_NAME;
            paramArray[6] = CreateDataParameter("@PROJECT_NAME", SqlDbType.VarChar);
            paramArray[6].Value = PROJECT_NAME;
            paramArray[7] = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[7].Value = EMP_NAME;
            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
        }

        public int NHIT_DASHBOARD_EMP_MERGE_Insert(string CR_YEAR, string CR_MONTH,
            float TARGET_FULL_RATE, float RESULT_FULL_RATE, float RESULT_DONG_RATE, float RESULT_BDONG_RATE,
            float TARGET_DONG_RATE, float RESULT_FULL_RATE_MS, float RESULT_DONG_RATE_MS, float RESULT_BDONG_RATE_MS)
        {
            string qry = @"INSERT INTO NHIT_DASHBOARD_EMP_MERGE VALUES(
                @CR_YEAR,
                @CR_MONTH,
                @TARGET_FULL_RATE,
                @RESULT_FULL_RATE,
                @RESULT_DONG_RATE,
                @RESULT_BDONG_RATE,
                @TARGET_DONG_RATE,
                @RESULT_FULL_RATE_MS,
                @RESULT_DONG_RATE_MS,
                @RESULT_BDONG_RATE_MS) ";
            IDbDataParameter[] paramArray = CreateDataParameters(10);
            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[0].Value = CR_YEAR;
            paramArray[1] = CreateDataParameter("@CR_MONTH", SqlDbType.VarChar);
            paramArray[1].Value = CR_MONTH;
            paramArray[2] = CreateDataParameter("@TARGET_FULL_RATE", SqlDbType.VarChar);
            paramArray[2].Value = TARGET_FULL_RATE;
            paramArray[3] = CreateDataParameter("@RESULT_FULL_RATE", SqlDbType.VarChar);
            paramArray[3].Value = RESULT_FULL_RATE;
            paramArray[4] = CreateDataParameter("@RESULT_DONG_RATE", SqlDbType.VarChar);
            paramArray[4].Value = RESULT_DONG_RATE;
            paramArray[5] = CreateDataParameter("@RESULT_BDONG_RATE", SqlDbType.VarChar);
            paramArray[5].Value = RESULT_BDONG_RATE;
            paramArray[6] = CreateDataParameter("@TARGET_DONG_RATE", SqlDbType.VarChar);
            paramArray[6].Value = TARGET_DONG_RATE;
            paramArray[7] = CreateDataParameter("@RESULT_FULL_RATE_MS", SqlDbType.VarChar);
            paramArray[7].Value = RESULT_FULL_RATE_MS;
            paramArray[8] = CreateDataParameter("@RESULT_DONG_RATE_MS", SqlDbType.VarChar);
            paramArray[8].Value = RESULT_DONG_RATE_MS;
            paramArray[9] = CreateDataParameter("@RESULT_BDONG_RATE_MS", SqlDbType.VarChar);
            paramArray[9].Value = RESULT_BDONG_RATE_MS;

            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
        }


        public int NHIT_DASHBOARD_EMP_MERGE_Delete(string CR_YEAR, string CR_MONTH)
        {
            string qry = @"DELETE FROM NHIT_DASHBOARD_EMP_MERGE
                WHERE CR_YEAR = @CR_YEAR AND CR_MONTH = @CR_MONTH";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[0].Value = CR_YEAR;
            paramArray[1] = CreateDataParameter("@CR_MONTH", SqlDbType.VarChar);
            paramArray[1].Value = CR_MONTH;


            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
        }

        public int NHIT_DASHBOARD_MAIN_Insert(string GRP_ONE_CODE, string GRP_ONE_NAME,
             string GRP_TWO_CODE, string GRP_TWO_NAME, string GRP_THREE_CODE, string GRP_THREE_NAME,
             string CR_YEAR, string CR_MONTH, float TARGET_YEAR, float TARGET_TS,
             float RESULT_TS, float DAL_RATE, string TG_GUBUN)
        {
            string qry = @"INSERT INTO NHIT_DASHBOARD_MAIN VALUES(
                @GRP_ONE_CODE,
                @GRP_ONE_NAME,
                @GRP_TWO_CODE,
                @GRP_TWO_NAME,
                @GRP_THREE_CODE,
                @GRP_THREE_NAME,
                @CR_YEAR,
                @CR_MONTH,
                @TARGET_YEAR,
                @TARGET_TS,
                @RESULT_TS,
                @DAL_RATE,
                @TG_GUBUN) ";
            IDbDataParameter[] paramArray = CreateDataParameters(13);
            paramArray[0] = CreateDataParameter("@GRP_ONE_CODE", SqlDbType.VarChar);
            paramArray[0].Value = GRP_ONE_CODE;
            paramArray[1] = CreateDataParameter("@GRP_ONE_NAME", SqlDbType.VarChar);
            paramArray[1].Value = GRP_ONE_NAME;
            paramArray[2] = CreateDataParameter("@GRP_TWO_CODE", SqlDbType.VarChar);
            paramArray[2].Value = GRP_TWO_CODE;
            paramArray[3] = CreateDataParameter("@GRP_TWO_NAME", SqlDbType.VarChar);
            paramArray[3].Value = GRP_TWO_NAME;
            paramArray[4] = CreateDataParameter("@GRP_THREE_CODE", SqlDbType.VarChar);
            paramArray[4].Value = GRP_THREE_CODE;
            paramArray[5] = CreateDataParameter("@GRP_THREE_NAME", SqlDbType.VarChar);
            paramArray[5].Value = GRP_THREE_NAME;
            paramArray[6] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[6].Value = CR_YEAR;
            paramArray[7] = CreateDataParameter("@CR_MONTH", SqlDbType.VarChar);
            paramArray[7].Value = CR_MONTH;
            paramArray[8] = CreateDataParameter("@TARGET_YEAR", SqlDbType.Float);
            paramArray[8].Value = TARGET_YEAR;
            paramArray[9] = CreateDataParameter("@TARGET_TS", SqlDbType.Float);
            paramArray[9].Value = TARGET_TS;
            paramArray[10] = CreateDataParameter("@RESULT_TS", SqlDbType.Float);
            paramArray[10].Value = RESULT_TS;
            paramArray[11] = CreateDataParameter("@DAL_RATE", SqlDbType.Float);
            paramArray[11].Value = DAL_RATE;
            paramArray[12] = CreateDataParameter("@TG_GUBUN", SqlDbType.VarChar);
            paramArray[12].Value = TG_GUBUN;

            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
        }

        public int NHIT_DASHBOARD_MAIN_Delete(string GRP_ONE_CODE, string GRP_TWO_CODE, string GRP_THREE_CODE, string CR_YEAR, string CR_MONTH, string TG_GUBUN)
        {
            string qry = @"
                DELETE 
                FROM    NHIT_DASHBOARD_MAIN 
                WHERE 
                        GRP_ONE_CODE = @GRP_ONE_CODE
                  AND   GRP_TWO_CODE = @GRP_TWO_CODE
                  AND   GRP_THREE_CODE = @GRP_THREE_CODE
                  AND   CR_YEAR        = @CR_YEAR
                  AND   CR_MONTH       = @CR_MONTH
                  AND   TG_GUBUN       = @TG_GUBUN ";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@GRP_ONE_CODE", SqlDbType.VarChar);
            paramArray[0].Value = GRP_ONE_CODE;
            paramArray[1] = CreateDataParameter("@GRP_TWO_CODE", SqlDbType.VarChar);
            paramArray[1].Value = GRP_TWO_CODE;
            paramArray[2] = CreateDataParameter("@GRP_THREE_CODE", SqlDbType.VarChar);
            paramArray[2].Value = GRP_THREE_CODE;
            paramArray[3] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[3].Value = CR_YEAR;
            paramArray[4] = CreateDataParameter("@CR_MONTH", SqlDbType.VarChar);
            paramArray[4].Value = CR_MONTH;
            paramArray[5] = CreateDataParameter("@TG_GUBUN", SqlDbType.VarChar);
            paramArray[5].Value = TG_GUBUN;

            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
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
            string qry = @"INSERT INTO NHIT_DASHBOARD_PMS VALUES(
                @CR_YEAR, @PROJECT_CODE, @PROJECT_NAME, 
                @GUBUN_ONE, @GRP_ONE_C_CODE, @GRP_ONE_C_NAME, 
                @GRP_ONE_B_CODE, @GRP_ONE_B_NAME, @GRP_ONE_D_CODE, 
                @GRP_ONE_D_NAME, @TEAM_NAME, @PLAN_STR, 
                @PLAN_END, @END_YN, @GE_COMP, @BUNLYU_CODE, 
                @MECHUL, @SANPUM, @JAERYO, 
                @OYJU, @JICK_EMP, @JICK_KYUNG, 
                @HANGAE, @BUN_EMP, @BUN_KYUNG, 
                @JUNSA_EMP, @JUNSA_KYUNG, @MECHUL_TOT, 
                @PANME_EMP, @PANME_KYUNG, @YOUNGUP    
                ) ";
            IDbDataParameter[] paramArray = CreateDataParameters(31);
            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[0].Value = CR_YEAR;
            paramArray[1] = CreateDataParameter("@PROJECT_CODE", SqlDbType.VarChar);
            paramArray[1].Value = PROJECT_CODE;
            paramArray[2] = CreateDataParameter("@PROJECT_NAME", SqlDbType.VarChar);
            paramArray[2].Value = PROJECT_NAME;
            paramArray[3] = CreateDataParameter("@GUBUN_ONE", SqlDbType.VarChar);
            paramArray[3].Value = GUBUN_ONE;
            paramArray[4] = CreateDataParameter("@GRP_ONE_C_CODE", SqlDbType.VarChar);
            paramArray[4].Value = GRP_ONE_C_CODE;
            paramArray[5] = CreateDataParameter("@GRP_ONE_C_NAME", SqlDbType.VarChar);
            paramArray[5].Value = GRP_ONE_C_NAME;
            paramArray[6] = CreateDataParameter("@GRP_ONE_B_CODE", SqlDbType.VarChar);
            paramArray[6].Value = GRP_ONE_B_CODE;
            paramArray[7] = CreateDataParameter("@GRP_ONE_B_NAME", SqlDbType.VarChar);
            paramArray[7].Value = GRP_ONE_B_NAME;
            paramArray[8] = CreateDataParameter("@GRP_ONE_D_CODE", SqlDbType.VarChar);
            paramArray[8].Value = GRP_ONE_D_CODE;
            paramArray[9] = CreateDataParameter("@GRP_ONE_D_NAME", SqlDbType.VarChar);
            paramArray[9].Value = GRP_ONE_D_NAME;
            paramArray[10] = CreateDataParameter("@TEAM_NAME", SqlDbType.VarChar);
            paramArray[10].Value = TEAM_NAME;
            paramArray[11] = CreateDataParameter("@PLAN_STR", SqlDbType.VarChar);
            paramArray[11].Value = PLAN_STR;
            paramArray[12] = CreateDataParameter("@PLAN_END", SqlDbType.VarChar);
            paramArray[12].Value = PLAN_END;
            paramArray[13] = CreateDataParameter("@END_YN", SqlDbType.VarChar);
            paramArray[13].Value = END_YN;
            paramArray[14] = CreateDataParameter("@GE_COMP", SqlDbType.VarChar);
            paramArray[14].Value = GE_COMP;
            paramArray[15] = CreateDataParameter("@BUNLYU_CODE", SqlDbType.VarChar);
            paramArray[15].Value = BUNLYU_CODE;
            paramArray[16] = CreateDataParameter("@MECHUL", SqlDbType.Float);
            paramArray[16].Value = MECHUL;
            paramArray[17] = CreateDataParameter("@SANPUM", SqlDbType.Float);
            paramArray[17].Value = SANPUM;
            paramArray[18] = CreateDataParameter("@JAERYO", SqlDbType.Float);
            paramArray[18].Value = JAERYO;
            paramArray[19] = CreateDataParameter("@OYJU", SqlDbType.Float);
            paramArray[19].Value = OYJU;
            paramArray[20] = CreateDataParameter("@JICK_EMP", SqlDbType.Float);
            paramArray[20].Value = JICK_EMP;
            paramArray[21] = CreateDataParameter("@JICK_KYUNG", SqlDbType.Float);
            paramArray[21].Value = JICK_KYUNG;
            paramArray[22] = CreateDataParameter("@HANGAE", SqlDbType.Float);
            paramArray[22].Value = HANGAE;
            paramArray[23] = CreateDataParameter("@BUN_EMP", SqlDbType.Float);
            paramArray[23].Value = BUN_EMP;
            paramArray[24] = CreateDataParameter("@BUN_KYUNG", SqlDbType.Float);
            paramArray[24].Value = BUN_KYUNG;
            paramArray[25] = CreateDataParameter("@JUNSA_EMP", SqlDbType.Float);
            paramArray[25].Value = JUNSA_EMP;
            paramArray[26] = CreateDataParameter("@JUNSA_KYUNG", SqlDbType.Float);
            paramArray[26].Value = JUNSA_KYUNG;
            paramArray[27] = CreateDataParameter("@MECHUL_TOT", SqlDbType.Float);
            paramArray[27].Value = MECHUL_TOT;
            paramArray[28] = CreateDataParameter("@PANME_EMP", SqlDbType.Float);
            paramArray[28].Value = PANME_EMP;
            paramArray[29] = CreateDataParameter("@PANME_KYUNG", SqlDbType.Float);
            paramArray[29].Value = PANME_KYUNG;
            paramArray[30] = CreateDataParameter("@YOUNGUP", SqlDbType.Float);
            paramArray[30].Value = YOUNGUP;


            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
        }

        public int NHIT_DASHBOARD_PMS_Delete(string CR_YEAR,
            string PROJECT_CODE,
            string GUBUN_ONE,
            string GRP_ONE_C_CODE,
            string GRP_ONE_B_CODE,
            string GRP_ONE_D_CODE,
            string TEAM_NAME)
        {
            string qry = @"
 DELETE FROM NHIT_DASHBOARD_PMS 
  WHERE CR_YEAR = @CR_YEAR
    AND PROJECT_CODE = @PROJECT_CODE
    AND GUBUN_ONE = @GUBUN_ONE
    AND GRP_ONE_C_CODE = @GRP_ONE_C_CODE  
    AND GRP_ONE_B_CODE = @GRP_ONE_B_CODE
    AND GRP_ONE_D_CODE = @GRP_ONE_D_CODE
    AND TEAM_NAME = @TEAM_NAME
                 ";
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0] = CreateDataParameter("@CR_YEAR", SqlDbType.VarChar);
            paramArray[0].Value = CR_YEAR;
            paramArray[1] = CreateDataParameter("@PROJECT_CODE", SqlDbType.VarChar);
            paramArray[1].Value = PROJECT_CODE;

            paramArray[2] = CreateDataParameter("@GUBUN_ONE", SqlDbType.VarChar);
            paramArray[2].Value = GUBUN_ONE;
            paramArray[3] = CreateDataParameter("@GRP_ONE_C_CODE", SqlDbType.VarChar);
            paramArray[3].Value = GRP_ONE_C_CODE;

            paramArray[4] = CreateDataParameter("@GRP_ONE_B_CODE", SqlDbType.VarChar);
            paramArray[4].Value = GRP_ONE_B_CODE;

            paramArray[5] = CreateDataParameter("@GRP_ONE_D_CODE", SqlDbType.VarChar);
            paramArray[5].Value = GRP_ONE_D_CODE;

            paramArray[6] = CreateDataParameter("@TEAM_NAME", SqlDbType.VarChar);
            paramArray[6].Value = TEAM_NAME;



            return DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
        }
    }
}
