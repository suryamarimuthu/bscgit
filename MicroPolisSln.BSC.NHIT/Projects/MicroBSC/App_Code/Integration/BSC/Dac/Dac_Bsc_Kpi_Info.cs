﻿using System;
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
/// Dac_Bsc_Kpi_Info에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Info Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Info : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================


        public DataTable Select_GoalTongDashboard(object estterm_ref_id
                                            , object est_dept_ref_id)
        {
            string query = @"

SELECT 
    A.KPI_REF_ID
   ,D.KPI_NAME
   ,B.EST_DEPT_REF_ID
   ,C.DEPT_NAME
   ,A.CHAMPION_EMP_ID
   ,E.EMP_NAME           AS   CHAMPION_NAME
FROM BSC_KPI_INFO A JOIN ( SELECT ESTTERM_REF_ID
                                 ,EST_DEPT_REF_ID
                                 ,MAP_VERSION_ID
                                 ,KPI_REF_ID
                                 ,WEIGHT
                             FROM BSC_MAP_KPI 
                            WHERE ESTTERM_REF_ID  = @ESTTERM_REF_ID
                              AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID   ) B   ON (     A.ESTTERM_REF_ID = B.ESTTERM_REF_ID
                                                                                  AND A.KPI_REF_ID     = B.KPI_REF_ID )
                    JOIN EST_DEPT_INFO     C  ON (    B.ESTTERM_REF_ID   = C.ESTTERM_REF_ID
                                                  AND B.EST_DEPT_REF_ID  = C.EST_DEPT_REF_ID )
                    JOIN BSC_KPI_POOL      D  ON (    A.KPI_POOL_REF_ID = D.KPI_POOL_REF_ID )
                    JOIN COM_EMP_INFO      E  ON (    A.CHAMPION_EMP_ID = E.EMP_REF_ID )                    
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
  AND A.USE_YN = 'Y'
ORDER BY KPI_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = est_dept_ref_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_INFO", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public int Delete_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object estterm_ref_id
                                , object kpi_ref_id)
        {



            string query = @"
-- KPI INFO DELETE
DELETE FROM BSC_KPI_INFO    
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int InsertData_DB(IDbConnection conn
                               , IDbTransaction trx
                               , object estterm_ref_id
                                ,object  kpi_ref_id
                                ,object  kpi_code
                                ,object  kpi_pool_ref_id
                                ,object  word_definition
                                ,object  calc_form_ms
                                ,object  champion_emp_id
                                ,object  result_input_type
                                ,object  result_achievement_type
                                ,object  result_ts_calc_type
                                ,object  result_measurement_step
                                ,object  measurement_grade_type
                                ,object  unit_type_ref_id
                                ,object  kpi_target_version_id
                                ,object  kpi_target_setting_reason
                                ,object  kpi_target_reason_file
                                ,object  approval_status
                                ,object  excel_dnuse
                                ,object  is_team_kpi
                                ,object  use_yn
                                ,object  create_date
                                ,object  create_user)
        {
            string query = @"
INSERT INTO     BSC_KPI_INFO    
            (
                ESTTERM_REF_ID
                , KPI_REF_ID
                , KPI_CODE
                , KPI_POOL_REF_ID
                , WORD_DEFINITION
                , CALC_FORM_MS
                , CHAMPION_EMP_ID
                , RESULT_INPUT_TYPE
                , RESULT_ACHIEVEMENT_TYPE
                , RESULT_TS_CALC_TYPE
                , RESULT_MEASUREMENT_STEP
                , MEASUREMENT_GRADE_TYPE
                , UNIT_TYPE_REF_ID
                , KPI_TARGET_VERSION_ID
                , KPI_TARGET_SETTING_REASON
                , KPI_TARGET_REASON_FILE
                , APPROVAL_STATUS
                , EXCEL_DNUSE
                , IS_TEAM_KPI
                , USE_YN
                , CREATE_DATE
                , CREATE_USER
            )
    VALUES  (
                 @ESTTERM_REF_ID
                , @KPI_REF_ID
                , @KPI_CODE
                , @KPI_POOL_REF_ID
                , @WORD_DEFINITION
                , @CALC_FORM_MS
                , @CHAMPION_EMP_ID
                , @RESULT_INPUT_TYPE
                , @RESULT_ACHIEVEMENT_TYPE
                , @RESULT_TS_CALC_TYPE
                , @RESULT_MEASUREMENT_STEP
                , @MEASUREMENT_GRADE_TYPE
                , @UNIT_TYPE_REF_ID
                , @KPI_TARGET_VERSION_ID
                , @KPI_TARGET_SETTING_REASON
                , @KPI_TARGET_REASON_FILE
                , @APPROVAL_STATUS
                , @EXCEL_DNUSE
                , @IS_TEAM_KPI
                , @USE_YN
                , @CREATE_DATE
                , @CREATE_USER
           )
";

            IDbDataParameter[] paramArray = CreateDataParameters(22);


            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.NVarChar);
            paramArray[2].Value = kpi_code;
            paramArray[3] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[3].Value = kpi_pool_ref_id;
            paramArray[4] = CreateDataParameter("@WORD_DEFINITION", SqlDbType.Int);
            paramArray[4].Value = word_definition;
            paramArray[5] = CreateDataParameter("@CALC_FORM_MS", SqlDbType.NVarChar);
            paramArray[5].Value = calc_form_ms;
            paramArray[6] = CreateDataParameter("@CHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = champion_emp_id;
            paramArray[7] = CreateDataParameter("@RESULT_INPUT_TYPE", SqlDbType.NVarChar);
            paramArray[7].Value = result_input_type;
            paramArray[8] = CreateDataParameter("@RESULT_ACHIEVEMENT_TYPE", SqlDbType.NVarChar);
            paramArray[8].Value = result_achievement_type;
            paramArray[9] = CreateDataParameter("@RESULT_TS_CALC_TYPE", SqlDbType.NVarChar);
            paramArray[9].Value = result_ts_calc_type;
            paramArray[10] = CreateDataParameter("@RESULT_MEASUREMENT_STEP", SqlDbType.NVarChar);
            paramArray[10].Value = result_measurement_step;
            paramArray[11] = CreateDataParameter("@MEASUREMENT_GRADE_TYPE", SqlDbType.NVarChar);
            paramArray[11].Value = measurement_grade_type;
            paramArray[12] = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[12].Value = unit_type_ref_id;
            paramArray[13] = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[13].Value = kpi_target_version_id;
            paramArray[14] = CreateDataParameter("@KPI_TARGET_SETTING_REASON", SqlDbType.NVarChar);
            paramArray[14].Value = kpi_target_setting_reason;
            paramArray[15] = CreateDataParameter("@KPI_TARGET_REASON_FILE", SqlDbType.NVarChar);
            paramArray[15].Value = kpi_target_reason_file;
            paramArray[16] = CreateDataParameter("@APPROVAL_STATUS", SqlDbType.NVarChar);
            paramArray[16].Value = approval_status;
            paramArray[17] = CreateDataParameter("@EXCEL_DNUSE", SqlDbType.NVarChar);
            paramArray[17].Value = excel_dnuse;
            paramArray[18] = CreateDataParameter("@IS_TEAM_KPI", SqlDbType.NVarChar);
            paramArray[18].Value = is_team_kpi;
            paramArray[19] = CreateDataParameter("@USE_YN", SqlDbType.NVarChar);
            paramArray[19].Value = use_yn;
            paramArray[20] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[20].Value = create_date;
            paramArray[21] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[21].Value = create_user;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        #endregion







        public int Insert_DB_From_Bsc_Kpi_Info(IDbConnection conn, IDbTransaction trx
                                                , object estterm_ref_id
                                                , object kpi_ref_id
                                                , object kpi_code
                                                , object emp_ref_id
                                                , object org_kpi_ref_id)
        {
            string query = @"
INSERT INTO     BSC_KPI_INFO    
            (
                ESTTERM_REF_ID
                , KPI_REF_ID
                , KPI_CODE
                , KPI_POOL_REF_ID
                , WORD_DEFINITION
                , CALC_FORM_MS
                , CHAMPION_EMP_ID
                , RESULT_INPUT_TYPE
                , RESULT_ACHIEVEMENT_TYPE
                , RESULT_TS_CALC_TYPE
                , RESULT_MEASUREMENT_STEP
                , MEASUREMENT_GRADE_TYPE
                , UNIT_TYPE_REF_ID
                , KPI_TARGET_VERSION_ID
                , KPI_TARGET_SETTING_REASON
                , KPI_TARGET_REASON_FILE
                , APPROVAL_STATUS
                , EXCEL_DNUSE
                , IS_TEAM_KPI
                , USE_YN
                , CREATE_DATE
                , CREATE_USER
            )
    SELECT
                @ESTTERM_REF_ID
                , @KPI_REF_ID
                , @KPI_CODE
                , KPI_POOL_REF_ID
                , WORD_DEFINITION
                , CALC_FORM_MS
                , @EMP_REF_ID
                , RESULT_INPUT_TYPE
                , RESULT_ACHIEVEMENT_TYPE
                , RESULT_TS_CALC_TYPE
                , RESULT_MEASUREMENT_STEP
                , MEASUREMENT_GRADE_TYPE
                , UNIT_TYPE_REF_ID
                , '1'
                , KPI_TARGET_SETTING_REASON
                , ''
                , 'N'
                , EXCEL_DNUSE
                , 'N'
                , 'Y'
                , GETDATE()
                , @EMP_REF_ID
    FROM        BSC_KPI_INFO
    WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND     KPI_REF_ID      = @ORG_KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);


            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_CODE", SqlDbType.NVarChar);
            paramArray[2].Value = kpi_code;
            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[3].Value = emp_ref_id;
            paramArray[4] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = org_kpi_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }



        public int Select_Max_Kpi_Ref_Id(IDbConnection conn, IDbTransaction trx)
        {
            object Result;
            string query = @"
SELECT      ISNULL(MAX(KPI_REF_ID),1000)+1
    FROM    BSC_KPI_INFO
";

            Result = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);

            return DataTypeUtility.GetToInt32(Result);
        }



        public int Update_Bsc_Kpi_Info(IDbConnection conn, IDbTransaction trx
                                    , object kpi_ref_id
                                    , object estterm_ref_id
                                    , object rtn_kpi_ref_id)
        {
            string query = @"
UPDATE      BSC_KPI_INFO
    SET
            KPI_REF_ID      = @RTN_KPI_REF_ID
            , KPI_CODE      = CAST(@RTN_KPI_REF_ID  AS  VARCHAR(20))
    WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID      = @KPI_REF_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(3);


            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@RTN_KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = rtn_kpi_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public int KpiWeightUpdate(int WEIGHT, int ESTTERM_REF_ID, int EST_DEPT_REF_ID, int MAP_VERSION_ID,
            int STG_REF_ID, int KPI_REF_ID)
        {
            string qry = @"
            UPDATE BSC_MAP_KPI SET WEIGHT = @WEIGHT
                WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                AND MAP_VERSION_ID = @MAP_VERSION_ID
                AND STG_REF_ID = @STG_REF_ID
                AND KPI_REF_ID = @KPI_REF_ID
                ";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@WEIGHT", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = WEIGHT;
            paramArray[1].Value = ESTTERM_REF_ID;
            paramArray[2].Value = EST_DEPT_REF_ID;
            paramArray[3].Value = MAP_VERSION_ID;
            paramArray[4].Value = STG_REF_ID;
            paramArray[5].Value = KPI_REF_ID;

            return DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public int KpiWeightUpdate(double WEIGHT, int ESTTERM_REF_ID, int EST_DEPT_REF_ID, int MAP_VERSION_ID,
            int STG_REF_ID, int KPI_REF_ID)
        {
            string qry = @"
            UPDATE BSC_MAP_KPI SET WEIGHT = @WEIGHT
                WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
                AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                AND MAP_VERSION_ID = @MAP_VERSION_ID
                AND STG_REF_ID = @STG_REF_ID
                AND KPI_REF_ID = @KPI_REF_ID
                ";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = WEIGHT;
            paramArray[1].Value = ESTTERM_REF_ID;
            paramArray[2].Value = EST_DEPT_REF_ID;
            paramArray[3].Value = MAP_VERSION_ID;
            paramArray[4].Value = STG_REF_ID;
            paramArray[5].Value = KPI_REF_ID;

            return DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }


        public int KpiAutoInsert(int ESTTERM_REF_ID, int VIEW_REF_ID, int STG_REF_ID, int KPI_POOL_REF_ID, int EST_DEPT_REF_ID, int TXR_USER)
        {
            int result = 0;
            IDbDataParameter[] paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "I";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = ESTTERM_REF_ID;
            paramArray[2] = CreateDataParameter("@iVIEW_REF_ID", SqlDbType.Int);
            paramArray[2].Value = VIEW_REF_ID;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = STG_REF_ID;
            paramArray[4] = CreateDataParameter("@iKPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[4].Value = KPI_POOL_REF_ID;
            paramArray[5] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = EST_DEPT_REF_ID;
            paramArray[6] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value = TXR_USER;
            paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 500);
            paramArray[7].Direction = ParameterDirection.Output;
            paramArray[7].Value = "";
            paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 500);
            paramArray[8].Direction = ParameterDirection.Output;
            paramArray[8].Value = "";
            IDataParameterCollection col;
            result = DbAgentObj.ExecuteNonQuery("PKG_BSC_KPI_INFO_AUTO.PROC_AUTO_INSERT", paramArray, CommandType.StoredProcedure, out col);

            string message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            string resultYn = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return result;
        }

        public int KpiInfoExsistCheck(int KPI_POOL_REF_ID, int CHAMPION_EMP_ID, int ESTTERM_REF_ID)
        {
            string qry = @"SELECT count(*) FROM BSC_KPI_INFO KP
                                    INNER JOIN REL_DEPT_EMP DE ON DE.EMP_REF_ID = KP.CHAMPION_EMP_ID
                            WHERE KP.KPI_POOL_REF_ID = @KPI_POOL_REF_ID
                            AND KP.CHAMPION_EMP_ID = @CHAMPION_EMP_ID
                            AND KP.ESTTERM_REF_ID = @ESTTERM_REF_ID
                            AND IS_TEAM_KPI = 'Y'";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            paramArray[1] = CreateDataParameter("@CHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[1].Value = CHAMPION_EMP_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;

            object result = DbAgentObj.ExecuteScalar(qry, paramArray, CommandType.Text);
            return int.Parse(result.ToString());
        }

        public int KpiInfoExsistCheckPerson(int KPI_POOL_REF_ID, int CHAMPION_EMP_ID, int ESTTERM_REF_ID)
        {
            string qry = @"SELECT count(*) FROM BSC_KPI_INFO KP
                            WHERE KP.KPI_POOL_REF_ID = @KPI_POOL_REF_ID
                            AND KP.CHAMPION_EMP_ID = @CHAMPION_EMP_ID
                            AND KP.ESTTERM_REF_ID = @ESTTERM_REF_ID
                            AND IS_TEAM_KPI = 'N'";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            paramArray[1] = CreateDataParameter("@CHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[1].Value = CHAMPION_EMP_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;

            object result = DbAgentObj.ExecuteScalar(qry, paramArray, CommandType.Text);
            return int.Parse(result.ToString());
        }

        public int KpiInfoChampionChange(int kpi_ref_id, int champion_emp_id, int estterm_ref_id)
        {
            string qry = @"UPDATE BSC_KPI_INFO SET CHAMPION_EMP_ID = @CHAMPION_EMP_ID WHERE KPI_REF_ID = @KPI_REF_ID AND ESTTERM_REF_ID =@ESTTERM_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = kpi_ref_id;
            paramArray[1] = CreateDataParameter("@CHAMPION_EMP_ID", SqlDbType.Int);
            paramArray[1].Value = champion_emp_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;

            int result = DbAgentObj.ExecuteNonQuery(qry, paramArray, CommandType.Text);
            return result;
        }
    }
}
