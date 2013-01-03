using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_Emp_Info : DbAgentBase
    {
        public Dac_Com_Emp_Info()
        {

        }


        /// <summary>
        /// 정보가 없으면 "" 리턴
        /// </summary>
        public DataSet SelectAll_DB()
        {
            DataSet DS = new DataSet();
            string result;
            string query = @"
SELECT  EMP_REF_ID
        , EMP_CODE
        , LOGINID
        , LOGINIP
        , PASSWD
        , EMP_NAME
        , EMP_EMAIL
        , POSITION_CLASS_CODE
        , POSITION_GRP_CODE
        , POSITION_RANK_CODE
        , POSITION_DUTY_CODE
        , POSITION_STAT_CODE
        , POSITION_KIND_CODE
        , DAILY_PHONE
        , CELL_PHONE
        , FAX_NUMBER
        , JOB_STATUS
        , ZIPCODE
        , ADDR_1
        , ADDR_2
        , SIGN_PATH
        , STAMP_PATH
        , CREATE_TYPE
        , CREATE_EMP_ID
        , MODIFY_TYPE
        , MODIFY_EMP_ID
    FROM    COM_EMP_INFO";



            DS = DbAgentObj.Fill(query, null);

            return DS;
        }



        /// <summary>
        /// 정보가 없으면 "" 리턴
        /// </summary>
        public string Select_EMP_REF_ID(string LOGIN_ID)
        {
            DataSet DS = new DataSet();
            string result;
            string query = @"
SELECT  EMP_REF_ID
    FROM    COM_EMP_INFO
    WHERE   LOGINID = @LOGIN_ID
    ORDER BY    MODIFY_DATE DESC";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@LOGIN_ID", SqlDbType.NVarChar);
            paramArray[0].Value = LOGIN_ID;


            DS = DbAgentObj.Fill(query, paramArray);

            if (DS.Tables[0].Rows.Count == 0)
                result = "";
            else
                result = DS.Tables[0].Rows[0][0].ToString();

            return result;
        }





        public string Select_EMP_REF_ID(IDbConnection conn, IDbTransaction trx, string LOGIN_ID)
        {
            DataSet DS = new DataSet();
            string query = @"
SELECT  EMP_REF_ID
    FROM    COM_EMP_INFO
    WHERE   LOGINID = @LOGIN_ID
    ORDER BY    MODIFY_DATE DESC";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@LOGIN_ID", SqlDbType.NVarChar);
            paramArray[0].Value = LOGIN_ID;


            DS = DbAgentObj.FillDataSet(conn, trx, query, "EMP_REF_ID", DS, paramArray, CommandType.Text);

            return DS.Tables[0].Rows[0][0].ToString();
        }



        public int Insert_EmpInfo(IDbConnection conn
                                            , IDbTransaction trx
                                            , object EMP_REF_ID
                                            , object EMP_CODE
                                            , object LOGINID
                                            , object LOGINIP
                                            , object PASSWD
                                            , object EMP_NAME
                                            , object EMP_EMAIL
                                            , object POSITION_CLASS_CODE
                                            , object POSITION_GRP_CODE
                                            , object POSITION_RANK_CODE
                                            , object POSITION_DUTY_CODE
                                            , object POSITION_STAT_CODE
                                            , object POSITION_KIND_CODE
                                            , object DAILY_PHONE
                                            , object CELL_PHONE
                                            , object FAX_NUMBER
                                            , object JOB_STATUS
                                            , object ZIPCODE
                                            , object ADDR_1
                                            , object ADDR_2
                                            , object SIGN_PATH
                                            , object STAMP_PATH
                                            , object CREATE_TYPE
                                            , object CREATE_EMP_ID
                                            , object MODIFY_TYPE
                                            , object MODIFY_EMP_ID)
        {
            string query = @"
INSERT INTO COM_EMP_INFO
    (
        EMP_REF_ID
        , EMP_CODE
        , LOGINID
        , LOGINIP
        , PASSWD
        , EMP_NAME
        , EMP_EMAIL
        , POSITION_CLASS_CODE
        , POSITION_GRP_CODE
        , POSITION_RANK_CODE
        , POSITION_DUTY_CODE
        , POSITION_STAT_CODE
        , POSITION_KIND_CODE
        , DAILY_PHONE
        , CELL_PHONE
        , FAX_NUMBER
        , JOB_STATUS
        , ZIPCODE
        , ADDR_1
        , ADDR_2
        , SIGN_PATH
        , STAMP_PATH
        , CREATE_TYPE
        , CREATE_EMP_ID
        , MODIFY_TYPE
        , MODIFY_EMP_ID
    )
    VALUES
    (
        @EMP_REF_ID
        , @EMP_CODE
        , @LOGINID
        , @LOGINIP
        , @PASSWD
        , @EMP_NAME
        , @EMP_EMAIL
        , @POSITION_CLASS_CODE
        , @POSITION_GRP_CODE
        , @POSITION_RANK_CODE
        , @POSITION_DUTY_CODE
        , @POSITION_STAT_CODE
        , @POSITION_KIND_CODE
        , @DAILY_PHONE
        , @CELL_PHONE
        , @FAX_NUMBER
        , @JOB_STATUS
        , @ZIPCODE
        , @ADDR_1
        , @ADDR_2
        , @SIGN_PATH
        , @STAMP_PATH
        , @CREATE_TYPE
        , @CREATE_EMP_ID
        , @MODIFY_TYPE
        , @MODIFY_EMP_ID
    )
";

            IDbDataParameter[] paramArray = CreateDataParameters(26);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.NVarChar, 50);
            paramArray[0].Value = EMP_REF_ID;
            paramArray[1] = CreateDataParameter("@EMP_CODE", SqlDbType.NVarChar, 50);
            paramArray[1].Value = EMP_CODE;
            paramArray[2] = CreateDataParameter("@LOGINID", SqlDbType.NVarChar, 50);
            paramArray[2].Value = LOGINID;
            paramArray[3] = CreateDataParameter("@LOGINIP", SqlDbType.NVarChar, 50);
            paramArray[3].Value = LOGINIP;
            paramArray[4] = CreateDataParameter("@PASSWD", SqlDbType.NVarChar, 50);
            paramArray[4].Value = PASSWD;
            paramArray[5] = CreateDataParameter("@EMP_NAME", SqlDbType.NVarChar, 100);
            paramArray[5].Value = EMP_NAME;
            paramArray[6] = CreateDataParameter("@EMP_EMAIL", SqlDbType.NVarChar, 200);
            paramArray[6].Value = EMP_EMAIL;
            paramArray[7] = CreateDataParameter("@POSITION_CLASS_CODE", SqlDbType.NVarChar, 20);
            paramArray[7].Value = POSITION_CLASS_CODE;
            paramArray[8] = CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.NVarChar, 20);
            paramArray[8].Value = POSITION_GRP_CODE;
            paramArray[9] = CreateDataParameter("@POSITION_RANK_CODE", SqlDbType.NVarChar, 20);
            paramArray[9].Value = POSITION_RANK_CODE;
            paramArray[10] = CreateDataParameter("@POSITION_DUTY_CODE", SqlDbType.NVarChar, 20);
            paramArray[10].Value = POSITION_DUTY_CODE;
            paramArray[11] = CreateDataParameter("@POSITION_STAT_CODE", SqlDbType.NVarChar, 20);
            paramArray[11].Value = POSITION_STAT_CODE;
            paramArray[12] = CreateDataParameter("@POSITION_KIND_CODE", SqlDbType.NVarChar, 20);
            paramArray[12].Value = POSITION_KIND_CODE;
            paramArray[13] = CreateDataParameter("@DAILY_PHONE", SqlDbType.NVarChar, 30);
            paramArray[13].Value = DAILY_PHONE;
            paramArray[14] = CreateDataParameter("@CELL_PHONE", SqlDbType.NVarChar, 30);
            paramArray[14].Value = CELL_PHONE;
            paramArray[15] = CreateDataParameter("@FAX_NUMBER", SqlDbType.NVarChar, 30);
            paramArray[15].Value = FAX_NUMBER;
            paramArray[16] = CreateDataParameter("@JOB_STATUS", SqlDbType.Int);
            paramArray[16].Value = JOB_STATUS;
            paramArray[17] = CreateDataParameter("@ZIPCODE", SqlDbType.NVarChar, 6);
            paramArray[17].Value = ZIPCODE;
            paramArray[18] = CreateDataParameter("@ADDR_1", SqlDbType.NVarChar, 200);
            paramArray[18].Value = ADDR_1;
            paramArray[19] = CreateDataParameter("@ADDR_2", SqlDbType.NVarChar, 200);
            paramArray[19].Value = ADDR_2;
            paramArray[20] = CreateDataParameter("@SIGN_PATH", SqlDbType.NVarChar, 200);
            paramArray[20].Value = SIGN_PATH;
            paramArray[21] = CreateDataParameter("@STAMP_PATH", SqlDbType.NVarChar, 200);
            paramArray[21].Value = STAMP_PATH;
            paramArray[22] = CreateDataParameter("@CREATE_TYPE", SqlDbType.Int);
            paramArray[22].Value = CREATE_TYPE;
            paramArray[23] = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
            paramArray[23].Value = CREATE_EMP_ID;
            paramArray[24] = CreateDataParameter("@MODIFY_TYPE", SqlDbType.Int);
            paramArray[24].Value = MODIFY_TYPE;
            paramArray[25] = CreateDataParameter("@MODIFY_EMP_ID", SqlDbType.Int);
            paramArray[25].Value = MODIFY_EMP_ID;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }




        public string SelectNextEmpRefID(IDbConnection conn, IDbTransaction trx)
        {
            object Result;
            string query = @"
SELECT  MAX(EMP_REF_ID)+1
    FROM COM_EMP_INFO";

            Result = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);

            return DataTypeUtility.GetString(Result);
        }



        public DataTable Select_Emp_Info(object emp_ref_id)
        {
            string query = @"
    SELECT  EMP_REF_ID
          , EMP_CODE
          , LOGINID
          , LOGINIP
          , PASSWD
          , EMP_NAME
          , EMP_EMAIL
          , POSITION_CLASS_CODE
          , POSITION_GRP_CODE
          , POSITION_RANK_CODE
          , POSITION_DUTY_CODE
          , POSITION_STAT_CODE
          , POSITION_KIND_CODE
          , DAILY_PHONE
          , CELL_PHONE
          , FAX_NUMBER
          , JOB_STATUS
          , ZIPCODE
          , ADDR_1
          , ADDR_2
          , SIGN_PATH
          , STAMP_PATH
          , CREATE_TYPE
          , CREATE_DATE
          , CREATE_EMP_ID
          , MODIFY_TYPE
          , MODIFY_DATE
          , MODIFY_EMP_ID
    FROM    COM_EMP_INFO
    WHERE   EMP_REF_ID  =   @EMP_REF_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.NVarChar);
            paramArray[0].Value = emp_ref_id;


            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }



        public int Update_Emp_Info(IDbConnection conn, IDbTransaction trx
                                    , object emp_ref_id
                                    , object emp_email
                                    , object cell_phone
                                    , object update_user_ref_id)
        {
            string query = @"
UPDATE  COM_EMP_INFO
    SET
        EMP_EMAIL       =   @EMP_EMAIL
        , CELL_PHONE    =   @CELL_PHONE
        , MODIFY_EMP_ID =   @UPDATE_USER
        , MODIFY_DATE   =   GETDATE()
    WHERE
        EMP_REF_ID      =   @EMP_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@EMP_EMAIL", SqlDbType.NVarChar);
            paramArray[1].Value = emp_email;
            paramArray[2] = CreateDataParameter("@CELL_PHONE", SqlDbType.NVarChar);
            paramArray[2].Value = cell_phone;
            paramArray[3] = CreateDataParameter("@UPDATE_USER", SqlDbType.NVarChar);
            paramArray[3].Value = update_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        /// <summary>
        /// 로그인 시도 실패횟수 증가
        /// </summary>
        public int Update_Emp_Fail_Count(IDbConnection conn, IDbTransaction trx
                                        , object emp_ref_id
                                        , object update_user_ref_id)
        {
            string query = @"
UPDATE  COM_EMP_INFO
    SET
        FAILCNT         =   FAILCNT+1
        , MODIFY_EMP_ID =   @UPDATE_USER
        , MODIFY_DATE   =   GETDATE()
    WHERE
        EMP_REF_ID      =   @EMP_REF_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@UPDATE_USER", SqlDbType.NVarChar);
            paramArray[1].Value = update_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        /// <summary>
        /// 로그인 시도 실패횟수 변경
        /// </summary>
        public int Update_Emp_Fail_Count(IDbConnection conn, IDbTransaction trx
                                        , object emp_ref_id
                                        , object failcnt
                                        , object update_user_ref_id)
        {
            string query = @"
UPDATE  COM_EMP_INFO
    SET
        FAILCNT         =   @FAILCNT
        , MODIFY_EMP_ID =   @UPDATE_USER
        , MODIFY_DATE   =   GETDATE()
    WHERE
        EMP_REF_ID      =   @EMP_REF_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1] = CreateDataParameter("@FAILCNT", SqlDbType.Int);
            paramArray[1].Value = failcnt;
            paramArray[2] = CreateDataParameter("@UPDATE_USER", SqlDbType.NVarChar);
            paramArray[2].Value = update_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        /// <summary>
        /// EMP_REF_ID, PASSWD, FAILCNT 정보를 가진 datatable
        /// </summary>
        public DataTable Select_Emp_Login_Info(IDbConnection conn, IDbTransaction trx
                                                , object loginId)
        {
            string query = @"
SELECT      EMP_REF_ID
            , PASSWD
            , FAILCNT
    FROM    COM_EMP_INFO 
    WHERE   LOGINID     = @LOGINID 
";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[0].Value = loginId;

            DataTable dt = DbAgentObj.FillDataSet(conn, trx, query, "USER_LOGIN_INFO", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }

        public DataTable Select_Goal(int estrterm_id, string yymm, int goalemp, int kpiemp, string kpiname)
        {
            string qry = string.Empty;
            if (kpiemp != 0)
            {
                qry = @"
                            SELECT B.KPI_POOL_REF_ID, C.KPI_NAME   
                                    ,G.DEPT_NAME    
                                    ,E.EMP_NAME     AS KPIEMP
                                    ,A.EMP_NAME     AS ALLEMP
                                    ,TA.UNIT      
                                    ,TC.CODE_NAME  
                                    ,TD.TARGET_MS   
                                    , TD.TARGET_TS 
                                    ,TB.APP_STATUS,D.KPI_REF_ID
                              FROM COM_EMP_INFO A
                                   LEFT JOIN BSC_KPI_POOL_SUBEMP B
                                     ON A.EMP_REF_ID = B.TARGET_SUB_EMP
                                   INNER JOIN BSC_KPI_POOL C
                                     ON B.KPI_POOL_REF_ID = C.KPI_POOL_REF_ID
                                   INNER JOIN BSC_KPI_INFO D
                                     ON C.KPI_POOL_REF_ID = D.KPI_POOL_REF_ID
                                    AND D.USE_YN = 'Y'
                                    AND D.ISDELETE = 'N'
                                    AND D.IS_TEAM_KPI = 'Y'   -- 조직KPI
                                   INNER JOIN COM_EMP_INFO E  ON D.CHAMPION_EMP_ID = E.EMP_REF_ID
                                   LEFT JOIN REL_DEPT_EMP  F  ON E.EMP_REF_ID      = F.EMP_REF_ID
                                   LEFT JOIN COM_DEPT_INFO G  ON F.DEPT_REF_ID     = G.DEPT_REF_ID 
                                   LEFT JOIN COM_UNIT_TYPE_INFO TA
                                     ON D.UNIT_TYPE_REF_ID  =  TA.UNIT_TYPE_REF_ID
                                   LEFT JOIN COM_APPROVAL_INFO  TB
                                     ON D.APP_REF_ID = TB.APP_REF_ID
                                   LEFT JOIN COM_CODE_INFO TC
                                     ON TC.CATEGORY_CODE = 'CM002'
                                    AND TB.APP_STATUS = TC.ETC_CODE
                                   INNER JOIN BSC_KPI_TARGET TD
                                     ON D.ESTTERM_REF_ID = TD.ESTTERM_REF_ID
                                    AND D.KPI_REF_ID     = TD.KPI_REF_ID
                                    INNER JOIN BSC_KPI_TERM TE ON TE.ESTTERM_REF_ID = D.ESTTERM_REF_ID 
                                    AND D.KPI_REF_ID = TE.KPI_REF_ID AND TE.YMD = @YMD AND CHECK_YN = 'Y'
                             WHERE A.EMP_REF_ID = @EMP_REF_ID  
                                AND E.EMP_REF_ID = @KPI_EMP_ID
                                AND C.KPI_NAME   LIKE '%' +  @KPI_NAME + '%'     
                                AND D.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                AND TD.YMD = @YMD
                            ";
                IDbDataParameter[] paramArray = CreateDataParameters(5);
                paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[0].Value = goalemp;
                paramArray[1] = CreateDataParameter("@KPI_EMP_ID", SqlDbType.Int);
                paramArray[1].Value = kpiemp;
                paramArray[2] = CreateDataParameter("@KPI_NAME", SqlDbType.NVarChar);
                paramArray[2].Value = kpiname;
                paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3].Value = estrterm_id;
                paramArray[4] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                paramArray[4].Value = yymm;
                return DbAgentObj.Fill(qry, paramArray).Tables[0];
            }
            else
            {
                qry = @"
                            SELECT B.KPI_POOL_REF_ID, C.KPI_NAME   
                                    ,G.DEPT_NAME    
                                    ,E.EMP_NAME     AS KPIEMP
                                    ,A.EMP_NAME     AS ALLEMP
                                    ,TA.UNIT      
                                    ,TC.CODE_NAME  
                                    ,TD.TARGET_MS   
                                    , TD.TARGET_TS 
                                    ,TB.APP_STATUS,D.KPI_REF_ID
                              FROM COM_EMP_INFO A
                                   LEFT JOIN BSC_KPI_POOL_SUBEMP B
                                     ON A.EMP_REF_ID = B.TARGET_SUB_EMP
                                   INNER JOIN BSC_KPI_POOL C
                                     ON B.KPI_POOL_REF_ID = C.KPI_POOL_REF_ID
                                   INNER JOIN BSC_KPI_INFO D
                                     ON C.KPI_POOL_REF_ID = D.KPI_POOL_REF_ID
                                    AND D.USE_YN = 'Y'
                                    AND D.ISDELETE = 'N'
                                    AND D.IS_TEAM_KPI = 'Y'   -- 조직KPI
                                   INNER JOIN COM_EMP_INFO E  ON D.CHAMPION_EMP_ID = E.EMP_REF_ID
                                   LEFT JOIN REL_DEPT_EMP  F  ON E.EMP_REF_ID      = F.EMP_REF_ID
                                   LEFT JOIN COM_DEPT_INFO G  ON F.DEPT_REF_ID     = G.DEPT_REF_ID 
                                   LEFT JOIN COM_UNIT_TYPE_INFO TA
                                     ON D.UNIT_TYPE_REF_ID  =  TA.UNIT_TYPE_REF_ID
                                   LEFT JOIN COM_APPROVAL_INFO  TB
                                     ON D.APP_REF_ID = TB.APP_REF_ID
                                   LEFT JOIN COM_CODE_INFO TC
                                     ON TC.CATEGORY_CODE = 'CM002'
                                    AND TB.APP_STATUS = TC.ETC_CODE
                                   INNER JOIN BSC_KPI_TARGET TD
                                     ON D.ESTTERM_REF_ID = TD.ESTTERM_REF_ID
                                    AND D.KPI_REF_ID     = TD.KPI_REF_ID
                                   INNER JOIN BSC_KPI_TERM TE ON TE.ESTTERM_REF_ID = D.ESTTERM_REF_ID 
                                    AND D.KPI_REF_ID = TE.KPI_REF_ID AND TE.YMD = @YMD AND CHECK_YN = 'Y'
                             WHERE A.EMP_REF_ID = @EMP_REF_ID  
                                AND C.KPI_NAME   LIKE '%' +  @KPI_NAME + '%'     
                                AND D.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                AND TD.YMD = @YMD
                            ";
                IDbDataParameter[] paramArray = CreateDataParameters(4);
                paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[0].Value = goalemp;
                paramArray[1] = CreateDataParameter("@KPI_NAME", SqlDbType.NVarChar);
                paramArray[1].Value = kpiname;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estrterm_id;
                paramArray[3] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                paramArray[3].Value = yymm;
                return DbAgentObj.Fill(qry, paramArray).Tables[0];
            }
        }

        public int Update_Goal(int estrterm_id, int kpi_ref_id, string ymd, double target_ms, double target_ts)
        {
            string qry = @"UPDATE BSC_KPI_TARGET SET 
                                    TARGET_MS = @TARGET_MS, TARGET_TS = @TARGET_TS
                                WHERE
                                    ESTTERM_REF_ID = @ESTTERM_REF_ID
                                    AND KPI_REF_ID = @KPI_REF_ID
                                    AND YMD = @YMD ";
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@TARGET_MS", SqlDbType.Float);
            paramArray[0].Value = target_ms;
            paramArray[1] = CreateDataParameter("@TARGET_TS", SqlDbType.Float);
            paramArray[1].Value = target_ts;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estrterm_id;
            paramArray[3] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value = kpi_ref_id;
            paramArray[4] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[4].Value = ymd;
            return DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public DataTable Select_Result(int estrterm_id, string yymm, int goalemp, int kpiemp, string kpiname)
        {
            string qry = string.Empty;
            if (kpiemp != 0)
            {
                qry = @"
                            SELECT B.KPI_POOL_REF_ID, C.KPI_NAME   
                                    ,G.DEPT_NAME    
                                    ,E.EMP_NAME     AS KPIEMP
                                    ,A.EMP_NAME     AS ALLEMP
                                    ,TA.UNIT      
                                    ,TC.CODE_NAME  
                                    ,TD.CAL_RESULT_MS   
                                    , TD.CAL_RESULT_TS 
                                    ,TD.RESULT_MS   
                                    , TD.RESULT_TS 
                                    ,TB.APP_STATUS,D.KPI_REF_ID
                              FROM COM_EMP_INFO A
                                   LEFT JOIN BSC_KPI_POOL_SUBEMP B
                                     ON A.EMP_REF_ID = B.TARGET_SUB_EMP
                                   INNER JOIN BSC_KPI_POOL C
                                     ON B.KPI_POOL_REF_ID = C.KPI_POOL_REF_ID
                                   INNER JOIN BSC_KPI_INFO D
                                     ON C.KPI_POOL_REF_ID = D.KPI_POOL_REF_ID
                                    AND D.USE_YN = 'Y'
                                    AND D.ISDELETE = 'N'
                                    AND D.IS_TEAM_KPI = 'Y'   -- 조직KPI
                                   INNER JOIN COM_EMP_INFO E  ON D.CHAMPION_EMP_ID = E.EMP_REF_ID
                                   LEFT JOIN REL_DEPT_EMP  F  ON E.EMP_REF_ID      = F.EMP_REF_ID
                                   LEFT JOIN COM_DEPT_INFO G  ON F.DEPT_REF_ID     = G.DEPT_REF_ID 
                                   LEFT JOIN COM_UNIT_TYPE_INFO TA
                                     ON D.UNIT_TYPE_REF_ID  =  TA.UNIT_TYPE_REF_ID
                                   LEFT JOIN COM_APPROVAL_INFO  TB
                                     ON D.APP_REF_ID = TB.APP_REF_ID
                                   LEFT JOIN COM_CODE_INFO TC
                                     ON TC.CATEGORY_CODE = 'CM002'
                                    AND TB.APP_STATUS = TC.ETC_CODE
                                   INNER JOIN BSC_KPI_RESULT TD
                                     ON D.ESTTERM_REF_ID = TD.ESTTERM_REF_ID
                                    AND D.KPI_REF_ID     = TD.KPI_REF_ID
                                    INNER JOIN BSC_KPI_TERM TE ON TE.ESTTERM_REF_ID = D.ESTTERM_REF_ID 
                                    AND D.KPI_REF_ID = TE.KPI_REF_ID AND TE.YMD = @YMD AND CHECK_YN = 'Y'
                             WHERE A.EMP_REF_ID = @EMP_REF_ID  
                                AND E.EMP_REF_ID = @KPI_EMP_ID
                                AND C.KPI_NAME   LIKE '%' +  @KPI_NAME + '%'     
                                AND D.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                AND TD.YMD = @YMD
                            ";
                IDbDataParameter[] paramArray = CreateDataParameters(5);
                paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[0].Value = goalemp;
                paramArray[1] = CreateDataParameter("@KPI_EMP_ID", SqlDbType.Int);
                paramArray[1].Value = kpiemp;
                paramArray[2] = CreateDataParameter("@KPI_NAME", SqlDbType.NVarChar);
                paramArray[2].Value = kpiname;
                paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[3].Value = estrterm_id;
                paramArray[4] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                paramArray[4].Value = yymm;
                return DbAgentObj.Fill(qry, paramArray).Tables[0];
            }
            else
            {
                qry = @"
                            SELECT B.KPI_POOL_REF_ID, C.KPI_NAME   
                                    ,G.DEPT_NAME    
                                    ,E.EMP_NAME     AS KPIEMP
                                    ,A.EMP_NAME     AS ALLEMP
                                    ,TA.UNIT      
                                    ,TC.CODE_NAME  
                                    ,TD.CAL_RESULT_MS   
                                    ,TD.CAL_RESULT_TS 
                                    ,TD.RESULT_MS   
                                    ,TD.RESULT_TS 
                                    ,TB.APP_STATUS,D.KPI_REF_ID
                              FROM COM_EMP_INFO A
                                   LEFT JOIN BSC_KPI_POOL_SUBEMP B
                                     ON A.EMP_REF_ID = B.TARGET_SUB_EMP
                                   INNER JOIN BSC_KPI_POOL C
                                     ON B.KPI_POOL_REF_ID = C.KPI_POOL_REF_ID
                                   INNER JOIN BSC_KPI_INFO D
                                     ON C.KPI_POOL_REF_ID = D.KPI_POOL_REF_ID
                                    AND D.USE_YN = 'Y'
                                    AND D.ISDELETE = 'N'
                                    AND D.IS_TEAM_KPI = 'Y'   -- 조직KPI
                                   INNER JOIN COM_EMP_INFO E  ON D.CHAMPION_EMP_ID = E.EMP_REF_ID
                                   LEFT JOIN REL_DEPT_EMP  F  ON E.EMP_REF_ID      = F.EMP_REF_ID
                                   LEFT JOIN COM_DEPT_INFO G  ON F.DEPT_REF_ID     = G.DEPT_REF_ID 
                                   LEFT JOIN COM_UNIT_TYPE_INFO TA
                                     ON D.UNIT_TYPE_REF_ID  =  TA.UNIT_TYPE_REF_ID
                                   LEFT JOIN COM_APPROVAL_INFO  TB
                                     ON D.APP_REF_ID = TB.APP_REF_ID
                                   LEFT JOIN COM_CODE_INFO TC
                                     ON TC.CATEGORY_CODE = 'CM002'
                                    AND TB.APP_STATUS = TC.ETC_CODE
                                   INNER JOIN BSC_KPI_RESULT TD
                                     ON D.ESTTERM_REF_ID = TD.ESTTERM_REF_ID
                                    AND D.KPI_REF_ID     = TD.KPI_REF_ID
                                   INNER JOIN BSC_KPI_TERM TE ON TE.ESTTERM_REF_ID = D.ESTTERM_REF_ID 
                                    AND D.KPI_REF_ID = TE.KPI_REF_ID AND TE.YMD = @YMD AND CHECK_YN = 'Y'
                             WHERE A.EMP_REF_ID = @EMP_REF_ID  
                                AND C.KPI_NAME   LIKE '%' +  @KPI_NAME + '%'     
                                AND D.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                AND TD.YMD = @YMD
                            ";
                IDbDataParameter[] paramArray = CreateDataParameters(4);
                paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[0].Value = goalemp;
                paramArray[1] = CreateDataParameter("@KPI_NAME", SqlDbType.NVarChar);
                paramArray[1].Value = kpiname;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estrterm_id;
                paramArray[3] = CreateDataParameter("@YMD", SqlDbType.VarChar);
                paramArray[3].Value = yymm;
                return DbAgentObj.Fill(qry, paramArray).Tables[0];
            }
        }

        public int Update_Result(int estrterm_id, int kpi_ref_id, string ymd, double target_ms, double target_ts)
        {
            string qry = @"UPDATE BSC_KPI_RESULT SET 
                                    RESULT_MS = @RESULT_MS, RESULT_TS = @RESULT_TS
                                WHERE
                                    ESTTERM_REF_ID = @ESTTERM_REF_ID
                                    AND KPI_REF_ID = @KPI_REF_ID
                                    AND YMD = @YMD ";
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@RESULT_MS", SqlDbType.Float);
            paramArray[0].Value = target_ms;
            paramArray[1] = CreateDataParameter("@RESULT_TS", SqlDbType.Float);
            paramArray[1].Value = target_ts;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estrterm_id;
            paramArray[3] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value = kpi_ref_id;
            paramArray[4] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[4].Value = ymd;
            return DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }
    }
}
