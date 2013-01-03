using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Integration.PRJ.Dac
{
    public class Dac_Prj_Data : DbAgentBase
    {
        public Dac_Prj_Data()
        {
        }


        public int Delete_Prj_Data(IDbConnection conn, IDbTransaction trx, object PRJ_REF_ID)
        {
            int affectedRow = 0;
            string query = @"
DELETE
    FROM    PRJ_DATA
    WHERE   PRJ_REF_ID  =   @PRJ_REF_ID 
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_REF_ID;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }



        public int Insert_Prj_Data(IDbConnection conn, IDbTransaction trx
                                , object COMP_ID
                                , object EST_ID
                                , object ESTTERM_REF_ID
                                , object ESTTERM_SUB_ID
                                , object ESTTERM_STEP_ID
                                , object EST_DEPT_ID
                                , object EST_EMP_ID
                                , object TGT_DEPT_ID
                                , object TGT_EMP_ID
                                , object PRJ_REF_ID
                                , object POINT
                                , object POINT_DATE
                                , object STATUS_ID
                                , object CREATE_USER_REF_ID)
        {
            int affectedRow = 0;
            string query = @"
INSERT
    INTO    PRJ_DATA
            (
                COMP_ID
                , EST_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID
                , ESTTERM_STEP_ID
                , EST_DEPT_ID
                , EST_EMP_ID
                , TGT_DEPT_ID
                , TGT_EMP_ID
                , PRJ_REF_ID
                , POINT
                , POINT_DATE
                , STATUS_ID
                , CREATE_USER
                , CREATE_DATE
            )
            VALUES
            (
                @COMP_ID
                , @EST_ID
                , @ESTTERM_REF_ID
                , @ESTTERM_SUB_ID
                , @ESTTERM_STEP_ID
                , @EST_DEPT_ID
                , @EST_EMP_ID
                , @TGT_DEPT_ID
                , @TGT_EMP_ID
                , @PRJ_REF_ID
                , @POINT
                , @POINT_DATE
                , @STATUS_ID
                , @CREATE_USER
                , GETDATE()
            )
";
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = EST_DEPT_ID;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = EST_EMP_ID;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = TGT_DEPT_ID;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_EMP_ID;
            paramArray[9] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[9].Value = PRJ_REF_ID;
            paramArray[10] = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[10].Value = POINT;
            paramArray[11] = CreateDataParameter("@POINT_DATE", SqlDbType.Date);
            paramArray[11].Value = POINT_DATE;
            paramArray[12] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[12].Value = STATUS_ID;
            paramArray[13] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[13].Value = CREATE_USER_REF_ID;


            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public DataTable SelectPrjInfo_DB(object estterm_ref_id
                                        , object estterm_sub_id
                                        , object est_emp_id
                                        , object tgt_emp_id
                                        , object status_id)
        {
            string query = @"

SELECT A.COMP_ID
      ,A.EST_ID
      ,A.ESTTERM_REF_ID
      ,A.ESTTERM_SUB_ID
      ,A.ESTTERM_STEP_ID
      ,A.EST_DEPT_ID
      ,A.EST_EMP_ID
      ,A.PRJ_REF_ID
      ,A.POINT
      ,A.POINT_DATE
      ,A.STATUS_ID
      ,A.STATUS_DATE
      ,A.TGT_DEPT_ID
      ,DEPT_TGT.DEPT_NAME   AS   TGT_DEPT_NAME
      ,A.TGT_EMP_ID
      ,C.EMPLOYEENAME       AS   TGT_EMP_NAME
      ,B.PRJ_NAME
      ,B.PRJ_CODE
      ,C.TEAM_BSC_DEPT_ID   AS   PRJ_DEPT_CD
      ,CASE WHEN    C.TEAMNAME IS NULL  THEN    DEPT.DEPT_NAME  ELSE    C.TEAMNAME  END
                          AS   DEPT_NAME
      ,C.PROJECTID        AS   PRJ_ID
      ,C.PMNAME           AS   PM_EMP_NAME
 FROM PRJ_DATA A JOIN PRJ_INFO B ON(A.PRJ_REF_ID = B.PRJ_REF_ID)
                 JOIN PMS_INFO C ON(B.PRJ_CODE   = C.PROJECTID    )
    LEFT OUTER JOIN     COM_DEPT_INFO   DEPT        ON  C.TEAM_BSC_DEPT_ID  = DEPT.DEPT_REF_ID
    LEFT OUTER JOIN     COM_DEPT_INFO   DEPT_TGT    ON  A.TGT_DEPT_ID       = DEPT_TGT.DEPT_REF_ID
WHERE (A.ESTTERM_REF_ID = @ESTTERM_REF_ID      OR   @ESTTERM_REF_ID    = 0  )
  AND (A.ESTTERM_SUB_ID = @ESTTERM_SUB_ID      OR   @ESTTERM_SUB_ID    = 0  )
  AND (A.EST_EMP_ID     = @EST_EMP_ID          OR   @EST_EMP_ID        = 0  )
  AND (A.TGT_EMP_ID     = @TGT_EMP_ID          OR   @TGT_EMP_ID        = 0  )
  AND (A.STATUS_ID      = @STATUS_ID           OR   @STATUS_ID         =''  )
 
";


            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_sub_id;
            paramArray[2] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[2].Value = est_emp_id;
            paramArray[3] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[3].Value = tgt_emp_id;
            paramArray[4] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[4].Value = status_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "PRJ_INFO", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }


        public DataTable Select_Prj_Data(object PRJ_REF_ID
                                        , object COMP_ID
                                        , object EST_ID
                                        , object ESTTERM_REF_ID
                                        , object ESTTERM_SUB_ID
                                        , object ESTTERM_STEP_ID
                                        , object EST_DEPT_ID
                                        , object EST_EMP_ID
                                        , object TGT_DEPT_ID
                                        , object TGT_EMP_ID
                                        , object STATUS_ID)
        {
            string query = @"
SELECT
        PRJ_DATA.PRJ_REF_ID
        , PRJ_DATA.COMP_ID
        , PRJ_DATA.EST_ID
        , PRJ_DATA.ESTTERM_REF_ID
        , PRJ_DATA.ESTTERM_SUB_ID
        , PRJ_DATA.ESTTERM_STEP_ID
        , PRJ_DATA.EST_DEPT_ID
        , CASE  WHEN    EST_DEPT.DEPT_NAME  IS NULL THEN    CAST(PRJ_DATA.EST_DEPT_ID   AS varchar(100))
                                                    ELSE    EST_DEPT.DEPT_NAME  END     AS  EST_DEPT_NAME
        , PRJ_DATA.EST_EMP_ID
        , CASE  WHEN    EST_EMP.EMP_NAME    IS NULL THEN    CAST(PRJ_DATA.EST_EMP_ID    AS varchar(100))
                                                    ELSE    EST_EMP.EMP_NAME    END     AS  EST_EMP_NAME
        , PRJ_DATA.TGT_DEPT_ID
        , CASE  WHEN    TGT_DEPT.DEPT_NAME  IS NULL THEN    CAST(PRJ_DATA.TGT_DEPT_ID   AS varchar(100))
                                                    ELSE    TGT_DEPT.DEPT_NAME  END     AS  TGT_DEPT_NAME
        , PRJ_DATA.TGT_EMP_ID
        , CASE  WHEN    TGT_EMP.EMP_NAME    IS NULL THEN    CAST(PRJ_DATA.TGT_EMP_ID    AS varchar(100))
                                                    ELSE    TGT_EMP.EMP_NAME    END     AS  TGT_EMP_NAME
        , PRJ_DATA.POINT
        , PRJ_DATA.POINT_DATE
        , PRJ_DATA.STATUS_ID        AS  EST_STATUS
        , PRJ_DATA.STATUS_DATE
        , PMS_INFO.EMPLOYEEROLEID   AS  TGT_EMP_ROLE_CODE
        , PMS_INFO.EMPLOYEEROLENAME AS  TGT_EMP_ROLE_NAME
        , PMS_INFO.CGRADECODE       AS  TGT_EMP_GRADE_CODE
        , PMS_INFO.EMPGRADENAME     AS  TGT_EMP_GRADE_NAME
        --, PMS_INFO.EMP_WORK_MM
        , PRJ_INFO.PRJ_CODE
        , PMS_INFO.VALUATIONJUMSU   AS  EMP_EST_SCORE
        , {0}                       AS  EMP_WORK_PERIOD
    FROM                    PRJ_DATA
        LEFT OUTER JOIN     COM_DEPT_INFO   EST_DEPT
                        ON  PRJ_DATA.EST_DEPT_ID    =   EST_DEPT.DEPT_REF_ID
        LEFT OUTER JOIN     COM_DEPT_INFO   TGT_DEPT
                        ON  PRJ_DATA.TGT_DEPT_ID    =   TGT_DEPT.DEPT_REF_ID
        LEFT OUTER JOIN     COM_EMP_INFO    EST_EMP
                        ON  PRJ_DATA.EST_EMP_ID     =   EST_EMP.EMP_REF_ID
        LEFT OUTER JOIN     COM_EMP_INFO    TGT_EMP
                        ON  PRJ_DATA.TGT_EMP_ID     =   TGT_EMP.EMP_REF_ID
        LEFT OUTER JOIN     PRJ_INFO
                        ON  PRJ_DATA.PRJ_REF_ID     =   PRJ_INFO.PRJ_REF_ID
        LEFT OUTER JOIN     PMS_INFO
                        ON  
                    (       PRJ_INFO.PRJ_CODE       =   PMS_INFO.PROJECTID
                        AND PRJ_DATA.TGT_EMP_ID     =   PMS_INFO.EMPLOYEE_BSC_EMP_ID
                    )
    WHERE       
            (   PRJ_DATA.PRJ_REF_ID      =   @PRJ_REF_ID         OR  @PRJ_REF_ID         = 0 )       
        AND (   PRJ_DATA.COMP_ID         =   @COMP_ID            OR  @COMP_ID            = 0 )
        AND (   PRJ_DATA.EST_ID          =   @EST_ID             OR  @EST_ID             ='' )
        AND (   PRJ_DATA.ESTTERM_REF_ID  =   @ESTTERM_REF_ID     OR  @ESTTERM_REF_ID     = 0 )
        AND (   PRJ_DATA.ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID     OR  @ESTTERM_SUB_ID     = 0 )
        AND (   PRJ_DATA.ESTTERM_STEP_ID =   @ESTTERM_STEP_ID    OR  @ESTTERM_STEP_ID    = 0 )
        AND (   PRJ_DATA.EST_DEPT_ID     =   @EST_DEPT_ID        OR  @EST_DEPT_ID        = 0 )
        AND (   PRJ_DATA.EST_EMP_ID      =   @EST_EMP_ID         OR  @EST_EMP_ID         = 0 )
        AND (   PRJ_DATA.TGT_DEPT_ID     =   @TGT_DEPT_ID        OR  @TGT_DEPT_ID        = 0 )
        AND (   PRJ_DATA.TGT_EMP_ID      =   @TGT_EMP_ID         OR  @TGT_EMP_ID         = 0 )
        AND (   PRJ_DATA.STATUS_ID       =   @STATUS_ID          OR  @STATUS_ID          ='' )
";


            string Oracle_Date_Format = "TO_CHAR(PMS_INFO.DTINVOLVESTARTDATE, 'YYYY-MM-DD') || ' ~ ' || TO_CHAR(PMS_INFO.DTINVOLVEENDDATE, 'YYYY-MM-DD')";
            string MSSQL_Date_Format = "CONVERT(varchar(10), PMS_INFO.DTINVOLVESTARTDATE, 20) + ' ~ ' + CONVERT(varchar(10), PMS_INFO.DTINVOLVEENDDATE, 20)";


            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[0].Value = PRJ_REF_ID;
            paramArray[1] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1].Value = COMP_ID;
            paramArray[2] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = EST_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_REF_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_SUB_ID;
            paramArray[5] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5].Value = ESTTERM_STEP_ID;
            paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = EST_DEPT_ID;
            paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = EST_EMP_ID;
            paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_DEPT_ID;
            paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9].Value = TGT_EMP_ID;
            paramArray[10] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[10].Value = STATUS_ID;


            DataTable DT = DbAgentObj.FillDataSet(GetQueryStringByDb(string.Format(query, MSSQL_Date_Format)
                                                                    , string.Format(query, Oracle_Date_Format)
                                                                    )
                                                , "PRJ_DATA_LIST"
                                                , null, paramArray).Tables[0];

            return DT;
        }




        public int Update_Prj_Data_Point(IDbConnection conn, IDbTransaction trx
                                    , object PRJ_REF_ID
                                    , object TGT_DEPT_ID
                                    , object TGT_EMP_ID
                                    , object POINT
                                    , object USER_REF_ID)
        {
            int affectedRow = 0;
            string query = @"
UPDATE      PRJ_DATA
    SET     POINT           =   @POINT
          , POINT_DATE      =   GETDATE()
          , UPDATE_USER     =   @USER_REF_ID
          , UPDATE_DATE     =   GETDATE()
    WHERE   PRJ_REF_ID      =   @PRJ_REF_ID
        AND TGT_DEPT_ID     =   @TGT_DEPT_ID
        AND TGT_EMP_ID      =   @TGT_EMP_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[0].Value = PRJ_REF_ID;
            paramArray[1] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[1].Value = TGT_DEPT_ID;
            paramArray[2] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[2].Value = TGT_EMP_ID;
            paramArray[3] = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[3].Value = POINT;
            paramArray[4] = CreateDataParameter("@USER_REF_ID", SqlDbType.Int);
            paramArray[4].Value = USER_REF_ID;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }




        public int Update_Prj_Data_StatusID(IDbConnection conn, IDbTransaction trx
                                            , object PRJ_REF_ID
                                            , object TGT_DEPT_ID
                                            , object TGT_EMP_ID
                                            , object STATUS_ID
                                            , object USER_REF_ID)
        {
            int affectedRow = 0;
            string query = @"
UPDATE      PRJ_DATA
    SET     STATUS_ID       =   @STATUS_ID
          , STATUS_DATE     =   GETDATE()
          , UPDATE_USER     =   @USER_REF_ID
          , UPDATE_DATE     =   GETDATE()
    WHERE       PRJ_REF_ID      =   @PRJ_REF_ID
        AND (   TGT_DEPT_ID     =   @TGT_DEPT_ID    OR  @TGT_DEPT_ID    =   0   )
        AND (   TGT_EMP_ID      =   @TGT_EMP_ID     OR  @TGT_EMP_ID     =   0   )
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[0].Value = PRJ_REF_ID;
            paramArray[1] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[1].Value = TGT_DEPT_ID;
            paramArray[2] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[2].Value = TGT_EMP_ID;
            paramArray[3] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[3].Value = STATUS_ID;
            paramArray[4] = CreateDataParameter("@USER_REF_ID", SqlDbType.Int);
            paramArray[4].Value = USER_REF_ID;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }



        /// <summary>
        /// 프로젝트 리스트에 대한 프로젝트 점수 평균
        /// </summary>
        public double Select_Avg_Prj_Point(IDbConnection conn, IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object prj_ref_id_list)
        {
            string query = string.Format(@"
SELECT          AVG(  CASE WHEN POINT IS NULL THEN 0 ELSE POINT END  ) AS AVG_POINT
    FROM                PRJ_DATA PD
        LEFT OUTER JOIN PRJ_INFO PI
            ON  PD.PRJ_REF_ID   =   PI.PRJ_REF_ID
        LEFT OUTER JOIN PMS_INFO PMS
            ON  PI.PRJ_CODE     =   PMS.PROJECTID
    WHERE       COMP_ID             =   @COMP_ID
        AND     EST_ID              =   @EST_ID
        AND     ESTTERM_REF_ID      =   @ESTTERM_REF_ID
        AND     ESTTERM_SUB_ID      =   @ESTTERM_SUB_ID
        AND     ESTTERM_STEP_ID     =   @ESTTERM_STEP_ID
        AND     TGT_DEPT_ID         =   -1
        AND     TGT_EMP_ID          =   -1
        AND     PD.PRJ_REF_ID   IN  (  {0}  )
", prj_ref_id_list.ToString());

            IDbDataParameter[] paramArray = CreateDataParameters(5);

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

            object result = DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text);

            return DataTypeUtility.GetToDouble(result);
        }




        /// <summary>
        /// 사용자 리스트에 대한 프로젝트 기여도 점수 평균
        /// </summary>
        public double Select_Avg_Prj_Emp_Point(IDbConnection conn, IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object emp_ref_id_list)
        {
            string query = string.Format(@"
SELECT          ROUND(  AVG(  CASE WHEN POINT IS NULL THEN 0 ELSE POINT END  ), 2  ) AS AVG_POINT
    FROM                PRJ_DATA PD
        LEFT OUTER JOIN PRJ_INFO PI
            ON  PD.PRJ_REF_ID   =   PI.PRJ_REF_ID
        LEFT OUTER JOIN PMS_INFO PMS
            ON  PI.PRJ_CODE     =   PMS.PROJECTID
    WHERE       COMP_ID             =   @COMP_ID
        AND     EST_ID              =   @EST_ID
        AND     ESTTERM_REF_ID      =   @ESTTERM_REF_ID
        AND     ESTTERM_SUB_ID      =   @ESTTERM_SUB_ID
        AND     ESTTERM_STEP_ID     =   @ESTTERM_STEP_ID
        AND     PD.TGT_EMP_ID       IN  (  {0}  )
", emp_ref_id_list.ToString());

            IDbDataParameter[] paramArray = CreateDataParameters(5);

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

            object result = DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text);

            return DataTypeUtility.GetToDouble(result);
        }




        /// <summary>
        /// 해당 프로젝트들의 사용자에 대한 참여시간 계산, SI와 비SI를 따로 매개변수로 던짐
        /// </summary>
        public DataTable Select_Sum_Work_Time(IDbConnection conn, IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object prj_ref_id_list
                                            , object emp_ref_id_list)
        {
            string query = string.Format(@"
SELECT  
        PRJ_ID
        , PRJ_NAME
        , PM_DEPT_ID                        --PM부서 ID
        , PM_EMP_ID                         --PM직원 ID
        , PRJ_EMP_DEPT_ID                   --피평가자 부서ID(PM인 경우 null)
        , PRJ_EMP_ID                        --직원ID(BSC) 평가자 or 피평가자
        , PRJ_EMP_NAME                      --직원이름 평가자 or 피평가자
        , GUBUN_CODE                        --작업(P), 대기(T)구분
        , SUSPEND_TYPE                      --대기시간 종류
        , SUM(WORK_TIME)    AS  WORK_TIME   --프로젝트에대한 사용자의 참여시간 합계
        , PRJ_POINT                         --프로젝트 평가 점수
        , PRJ_EMP_POINT                     --프로젝트 기여도 평가 점수
        , ISPM_YN                           --PM여부
    FROM
    (
        SELECT  PMS.PROJECTID           AS  PRJ_ID
                , PMS.PROJECTNAME       AS  PRJ_NAME
                , PD.EST_DEPT_ID        AS  PM_DEPT_ID
                , PD.EST_EMP_ID         AS  PM_EMP_ID
                , PD.TGT_DEPT_ID        AS  PRJ_EMP_DEPT_ID --피평가자 부서ID
                , EMP.EMP_REF_ID        AS  PRJ_EMP_ID      --직원ID(BSC) 평가자 or 피평가자
                , EMP.EMP_NAME          AS  PRJ_EMP_NAME    --직원이름 평가자 or 피평가자
                , VW.INTIME_TASK_GU_CD  AS  GUBUN_CODE      --작업(P), 대기(T)구분
                , CASE WHEN
                    VW.INTIME_TASK_GU_CD='P'                    THEN ''
                                                                ELSE VW.INTIME_GU_CD END
                                        AS  SUSPEND_TYPE    --대기시간 종류
                , PRJ_POINT.POINT       AS  PRJ_POINT       --프로젝트 평가 점수
                , CASE WHEN
                    PD.POINT IS NULL                            THEN 0
                                                                ELSE PD.POINT END
                                        AS  PRJ_EMP_POINT   --프로젝트 기여도 평가 점수
                , CASE WHEN
                    VW.EMP_TIME IS NULL                         THEN 0
                                                                ELSE VW.EMP_TIME END
                                        AS  WORK_TIME       --참여시간
                , CASE WHEN
                    PMS.PM_BSC_EMP_ID=PMS.EMPLOYEE_BSC_EMP_ID   THEN 'Y'
                                                                ELSE 'N' END
                                        AS  ISPM_YN         --PM여부
        FROM            nhitpms.VW_BSC_PMS_EMP  VW
            LEFT OUTER JOIN     COM_EMP_INFO    EMP
                ON  VW.VCEMPSABUN   =   EMP.EMP_CODE        
            LEFT OUTER JOIN     PMS_INFO        PMS
                ON  VW.PRJ_ID       =   PMS.PROJECTID AND EMP.EMP_REF_ID=PMS.EMPLOYEE_BSC_EMP_ID
            LEFT OUTER JOIN     PRJ_INFO        PI
                ON  PI.PRJ_CODE     =   PMS.PROJECTID
            LEFT OUTER JOIN     PRJ_DATA        PD
                ON  PD.PRJ_REF_ID   =   PI.PRJ_REF_ID AND PD.TGT_EMP_ID=EMP.EMP_REF_ID
            LEFT OUTER JOIN (
                                SELECT      PRJ_REF_ID 
                                            , CASE WHEN POINT IS NULL THEN 0 ELSE POINT END AS POINT
                                    FROM    PRJ_DATA
                                    WHERE   COMP_ID         =   @COMP_ID
                                        AND EST_ID          =   @EST_ID
                                        AND ESTTERM_REF_ID  =   @ESTTERM_REF_ID
                                        AND ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
                                        AND ESTTERM_STEP_ID =   @ESTTERM_STEP_ID
                                        AND TGT_DEPT_ID     =   -1
                                        AND TGT_EMP_ID      =   -1
                            )                       PRJ_POINT   --프로젝트별 평가점수
                ON  PRJ_POINT.PRJ_REF_ID=PI.PRJ_REF_ID
        WHERE   1=1
            --AND PD.COMP_ID          =   @COMP_ID
            --AND PD.EST_ID           =   @EST_ID
            --AND PD.ESTTERM_REF_ID   =   @ESTTERM_REF_ID
            --AND PD.ESTTERM_SUB_ID   =   @ESTTERM_SUB_ID
            --AND PD.ESTTERM_STEP_ID  =   @ESTTERM_STEP_ID
            AND PRJ_POINT.POINT     IS NOT NULL                 --PRJ_DATA에 조건 거는 대신 추가한 조건
            AND PI.PRJ_REF_ID       IN  (  {0}  )               --평가할 프로젝트 리스트(평가완료된)
            AND EMP.EMP_REF_ID      IN  (  {1}  )               --평가할 직원ID 리스트
    )
    GROUP BY PRJ_ID
            , PRJ_NAME
            , PM_DEPT_ID
            , PM_EMP_ID
            , PRJ_EMP_DEPT_ID
            , PRJ_EMP_ID
            , PRJ_EMP_NAME
            , GUBUN_CODE
            , SUSPEND_TYPE
            , PRJ_POINT
            , PRJ_EMP_POINT
            , ISPM_YN
", prj_ref_id_list.ToString(), emp_ref_id_list.ToString());


            IDbDataParameter[] paramArray = CreateDataParameters(5);

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

            DataTable dt = DbAgentObj.FillDataSet(conn, trx, query, "SUM_WORK_TIME", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }




        /// <summary>
        /// 해당기간의 해당사용자에 대한 대기시간 계산
        /// </summary>
        /// <param name="start_date">yyyyMM</param>
        /// <param name="end_date">yyyyMM</param>
        public DataTable Select_Sum_Suspend_Time(IDbConnection conn, IDbTransaction trx
                                            , object start_date
                                            , object end_date
                                            , object emp_ref_id_list)
        {
            string query = string.Format(@"
SELECT  
        PRJ_ID
        , PRJ_NAME
        , PM_DEPT_ID
        , PM_EMP_ID
        , PRJ_EMP_DEPT_ID
        , PRJ_EMP_ID
        , PRJ_EMP_NAME
        , GUBUN_CODE
        , SUSPEND_TYPE
        , SUM(WORK_TIME)    AS  WORK_TIME    --프로젝트에대한 사용자의 참여시간 합계
        , PRJ_POINT
        , PRJ_EMP_POINT
        , ISPM_YN
    FROM
    (
        SELECT  ''                      AS  PRJ_ID
                , ''                    AS  PRJ_NAME
                , ''                    AS  PM_DEPT_ID
                , ''                    AS  PM_EMP_ID
                , DEPT.DEPT_REF_ID      AS  PRJ_EMP_DEPT_ID
                , EMP.EMP_REF_ID        AS  PRJ_EMP_ID      --직원ID(BSC) 평가자 or 피평가자
                , EMP.EMP_NAME          AS  PRJ_EMP_NAME    --직원이름 평가자 or 피평가자
                , VW.INTIME_TASK_GU_CD  AS  GUBUN_CODE      --작업(P), 대기(T)구분
                , VW.INTIME_GU_CD       AS  SUSPEND_TYPE    --대기시간 종류
                , 0                     AS  PRJ_POINT       --프로젝트 평가 점수
                , 0                     AS  PRJ_EMP_POINT   --프로젝트 기여도 평가 점수
                , CASE WHEN
                    VW.EMP_TIME IS NULL                         THEN 0
                                                                ELSE VW.EMP_TIME END
                                        AS  WORK_TIME       --참여시간
                , ''                    AS  ISPM_YN         --PM여부
        FROM            nhitpms.VW_BSC_PMS_EMP  VW
            LEFT OUTER JOIN     COM_EMP_INFO    EMP
                ON  VW.VCEMPSABUN       =   EMP.EMP_CODE
            LEFT ouTER JOIN     REL_DEPT_EMP    REL
                ON  REL.EMP_REF_ID      =   EMP.EMP_REF_ID
            LEFT OUTER JOIN     COM_DEPT_Info   DEPT
                ON  REL.DEPT_REF_ID     =   DEPT.DEPT_REF_ID
        WHERE
                VW.INTIME_TASK_GU_CD    =   'T'
            AND EMP.EMP_REF_ID          IN      (  {0}  )   --평가할 직원ID 리스트
            AND VW.PMS_YMD              BETWEEN @START_DATE
                                            AND @END_DATE
    )
    GROUP BY PRJ_ID
            , PRJ_NAME
            , PM_DEPT_ID
            , PM_EMP_ID
            , PRJ_EMP_DEPT_ID
            , PRJ_EMP_ID
            , PRJ_EMP_NAME
            , GUBUN_CODE
            , SUSPEND_TYPE
            , PRJ_POINT
            , PRJ_EMP_POINT
            , ISPM_YN
", emp_ref_id_list.ToString());


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@START_DATE", SqlDbType.NVarChar);
            paramArray[0].Value = start_date;
            paramArray[1] = CreateDataParameter("@END_DATE", SqlDbType.NVarChar);
            paramArray[1].Value = end_date;

            DataTable dt = DbAgentObj.FillDataSet(conn, trx, query, "SUM_SUSPEND_TIME", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }





        /// <summary>
        /// 평가기간에 해당하는 프로젝트의 종료상태에 따른 프로젝트구분
        /// </summary>
        public DataTable Select_Prj_Gubun(IDbConnection conn, IDbTransaction trx
                                        , object comp_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id
                                        , object estterm_step_id
                                        , object prj_status_id)
        {
            string query = @"
SELECT          PD.PRJ_REF_ID
                , PMS.PROJECTID         AS  PRJ_CODE
                , PMS.PROJECTNAME       AS  PRJ_NAME
                , PMS.PROJECTGUBUN      AS  PRJ_GUBUN
                , PMS.PROJECTSTARTDATE  AS  PRJ_STARTDATE
                , PMS.PROJECTENDDATE    AS  PRJ_ENDDATE
                , PMS.TEAM_BSC_DEPT_ID  AS  EST_DEPT_ID
                , PMS.TEAMNAME          AS  EST_DEPT_NAME
                , PMS.PM_BSC_EMP_ID     AS  EST_EMP_ID
                , PD.STATUS_ID
    FROM                    PMS_INFO PMS
        LEFT OUTER JOIN     PRJ_INFO PI
            ON      PMS.PROJECTID   =   PI.PRJ_CODE
        LEFT OUTER JOIN     PRJ_DATA PD
            ON (
                    PI.PRJ_REF_ID   =   PD.PRJ_REF_ID
                AND PD.TGT_DEPT_ID  =   -1
                AND PD.TGT_EMP_ID   =   -1
                )
    WHERE
                PMS.PROJECTGUBUN        IS NOT NULL
        AND     PMS.PROJECTSTARTDATE    IS NOT NULL
        AND     PMS.PROJECTENDDATE      IS NOT NULL
        AND (   PD.STATUS_ID        =   @STATUS_ID  OR  @STATUS_ID  ='' )
    GROUP BY 
            PD.PRJ_REF_ID
            , PMS.PROJECTID
            , PMS.PROJECTNAME
            , PMS.PROJECTGUBUN
            , PMS.PROJECTSTARTDATE
            , PMS.PROJECTENDDATE
            , PMS.TEAMNAME
            , PMS.PM_BSC_EMP_ID
            , PMS.TEAM_BSC_DEPT_ID
            , PD.STATUS_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[0].Value = prj_status_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "PRJ_GUBUN", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        /// <summary>
        /// 해당 평가기간의 평가 종료된 프로젝트 참여자의 SI, 비SI구분
        /// </summary>
        public DataTable Select_TgtEmp_Prj_Gubun(IDbConnection conn, IDbTransaction trx
            , object comp_id
            , object est_id
            , object estterm_ref_id
            , object estterm_sub_id
            , object estterm_step_id
            , object tgt_dept_id
            , object tgt_emp_id
            , object prj_ref_id_list)
        { 
            string query = string.Format(@"
SELECT  PRJ.DEPT_REF_ID
        , PRJ.EMP_REF_ID
        , PRJ.DEPT_REF_ID       AS  TGT_DEPT_ID
        , PRJ.EMP_REF_ID        AS  TGT_EMP_ID
        , SUM(CASE WHEN     PROJECTGUBUN='SI'   THEN    1   ELSE    0   END)    AS  SI_CNT
        , SUM(CASE WHEN     PROJECTGUBUN!='SI'  THEN    1   ELSE    0   END)    AS  NOT_SI_CNT
        , CLS.POS_CLS_ID        AS  TGT_POS_CLS_ID
        , CLS.POS_CLS_NAME      AS  TGT_POS_CLS_NAME
        , DUT.POS_DUT_ID        AS  TGT_POS_DUT_ID
        , DUT.POS_DUT_NAME      AS  TGT_POS_DUT_NAME
        , GRP.POS_GRP_ID        AS  TGT_POS_GRP_ID
        , GRP.POS_GRP_NAME      AS  TGT_POS_GRP_NAME
        , RNK.POS_RNK_ID        AS  TGT_POS_RNK_ID
        , RNK.POS_RNK_NAME      AS  TGT_POS_RNK_NAME
        , KND.POS_KND_ID        AS  TGT_POS_KND_ID
        , KND.POS_KND_NAME      AS  TGT_POS_KND_NAME
    FROM
        (
        SELECT      CASE WHEN PD.TGT_EMP_ID   =   -1            THEN    PMS_PM.PROJECTID
                                                                ELSE    PMS.PROJECTID  END      AS  PROJECTID
                    , CASE WHEN PD.TGT_EMP_ID   =   -1          THEN    PD.EST_DEPT_ID
                                                                ELSE    PD.TGT_DEPT_ID     END  AS  DEPT_REF_ID                    
                    , CASE WHEN PD.TGT_EMP_ID   =   -1          THEN    PD.EST_EMP_ID
                                                                ELSE    PD.TGT_EMP_ID     END   AS  EMP_REF_ID
                    , CASE WHEN PD.TGT_EMP_ID   =   -1          THEN    PMS_PM.PROJECTGUBUN
                                                                ELSE    PMS.PROJECTGUBUN  END   AS  PROJECTGUBUN
            FROM                    PRJ_DATA    PD 
                LEFT OUTER JOIN     PRJ_INFO    PI 
                    ON PD.PRJ_REF_ID        =   PI.PRJ_REF_ID
                LEFT OUTER JOIN     PMS_INFO    PMS
                    ON (    PI.PRJ_CODE     =   PMS.PROJECTID
                        AND PD.TGT_EMP_ID   =   PMS.EMPLOYEE_BSC_EMP_ID  )
                LEFT OUTER JOIN     PMS_INFO    PMS_PM
                    ON (    PI.PRJ_CODE     =   PMS_PM.PROJECTID
                        AND PD.EST_EMP_ID   =   PMS_PM.EMPLOYEE_BSC_EMP_ID  )
            WHERE   PD.COMP_ID          =   @COMP_ID
                AND PD.EST_ID           =   @EST_ID
                AND PD.ESTTERM_REF_ID   =   @ESTTERM_REF_ID
                AND PD.ESTTERM_SUB_ID   =   @ESTTERM_SUB_ID
                AND PD.ESTTERM_STEP_ID  =   @ESTTERM_STEP_ID
                AND PI.PRJ_REF_ID       IS NOT NULL
                AND (   PD.TGT_DEPT_ID  =   @TGT_DEPT_ID    OR  @TGT_DEPT_ID    =   0   )
                AND (   PD.TGT_EMP_ID   =   @TGT_EMP_ID     OR  @TGT_EMP_ID     =   0   )
                AND (   PD.PRJ_REF_ID   IN  ({0})           OR  ({0})           =   0   )   --종료된 프로젝트
        )                                       PRJ
        LEFT OUTER JOIN     COM_EMP_INFO        EMP
            ON  PRJ.EMP_REF_ID  =   EMP.EMP_REF_ID
        LEFt OUTER JOIN     EST_POSITION_CLS    CLS
            ON CLS.POS_CLS_ID   =   EMP.POSITION_CLASS_CODE
        LEFT OUTER JOIN     EST_POSITION_DUT    DUT
            ON DUT.POS_DUT_ID   =   EMP.POSITION_DUTY_CODE
        LEFT OUTER JOIN     EST_POSITION_GRP    GRP
            ON GRP.POS_GRP_ID   =   EMP.POSITION_GRP_CODE
        LEFT OUTER JOIN     EST_POSITION_RNK    RNK
            ON RNK.POS_RNK_ID   =   EMP.POSITION_RANK_CODE
        LEFT OUTER JOIN     EST_POSITION_KND    KND
            ON KND.POS_KND_ID   =   EMP.POSITION_KIND_CODE
    GROUP BY    PRJ.DEPT_REF_ID
                , PRJ.EMP_REF_ID
                , CLS.POS_CLS_ID
                , CLS.POS_CLS_NAME
                , DUT.POS_DUT_ID
                , DUT.POS_DUT_NAME
                , GRP.POS_GRP_ID
                , GRP.POS_GRP_NAME
                , RNK.POS_RNK_ID
                , RNK.POS_RNK_NAME
                , KND.POS_KND_ID
                , KND.POS_KND_NAME
", prj_ref_id_list.ToString());



            IDbDataParameter[] paramArray = CreateDataParameters(7);

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
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "PRJ_GUBUN", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }
    }
}
