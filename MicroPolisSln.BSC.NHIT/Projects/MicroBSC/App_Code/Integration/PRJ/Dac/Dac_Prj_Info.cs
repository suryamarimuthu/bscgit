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
    public class Dac_Prj_Info : DbAgentBase
    {
        public Dac_Prj_Info()
        {
        }



        public enum EST_GUBUN { TOTAL, INCLUDED_PRJ_INFO, EXCLUDED_PRJ_INFO }

        public DataTable Select_Pms_Info_Join_Prj_Info(object start_date, object end_date, object PRJ_NAME, object est_emp_id, EST_GUBUN gubun)

        {
            string query = @"
SELECT  PRJ_ID
      , PRJ_NAME
      , DEPT_NAME
      , PM_EMP_NAME
      --, EMP_WORK_MM
      , PRJ_REF_ID
      , PRJ_EST_DATE
      , PRJ_EST_STATUS
      , EST_DEPT_ID
      , EST_EMP_ID
      , TO_CHAR(PRJ_ENDDATE,'YYYY-MM-DD') AS PRJ_ENDDATE
      , TO_CHAR(PRJ_STARTDATE,'YYYY-MM-DD') AS PRJ_STARTDATE
    FROM
        (
            SELECT
                    PMS.PRJ_ID          AS  PRJ_ID
                    , PMS.PRJ_NM        AS  PRJ_NAME

                    , CASE  WHEN    DEPT.DEPT_NAME      IS NULL     THEN    CAST(PMS.PRJ_DEPT_ID AS varchar(100))
                                                                    ELSE    DEPT.DEPT_NAME
                        END             AS  DEPT_NAME

                    , PMS.PM_EMP_NAME   AS  PM_EMP_NAME

                    , CASE  WHEN    PRJ.PRJ_REF_ID      IS NULL     THEN    '-'
                                                                    ELSE    CAST(PRJ.PRJ_REF_ID AS varchar(100))
                        END             AS  PRJ_REF_ID

                    , CASE  WHEN    PRJ.PRJ_REF_ID      IS NULL     THEN    'N'
                                                                    ELSE    'Y'
                        END             AS  PRJ_REF_ID_YN

                    , CASE  WHEN    PRJ_DATA.STATUS_ID  =   'E'     THEN    CAST(PRJ_DATA.STATUS_DATE AS varchar(100))
                                                                    ELSE    '-'
                        END             AS  PRJ_EST_DATE

                    , CASE  WHEN    PRJ_DATA.STATUS_ID  IS NULL     THEN    '-'
                                                                    ELSE    PRJ_DATA.STATUS_ID
                        END             AS  PRJ_EST_STATUS
                    , PMS.PRJ_DEPT_ID   AS  EST_DEPT_ID
                    , PMS.PM_EMP_ID     AS  EST_EMP_ID
                    , PMS.PRJ_ENDDATE   AS  PRJ_ENDDATE
                    , PMS.PRJ_STARTDATE AS  PRJ_STARTDATE
                FROM
                        (
                            SELECT 
                                        PROJECTID           AS PRJ_ID
                                        , PROJECTNAME       AS PRJ_NM
                                        , TEAM_BSC_DEPT_ID  AS PRJ_DEPT_ID
                                        , PM_BSC_EMP_ID     AS PM_EMP_ID
                                        , PMNAME            AS PM_EMP_NAME
                                        , PROJECTENDDATE    AS PRJ_ENDDATE
                                        , PROJECTSTARTDATE  AS PRJ_STARTDATE
                                FROM
                                        PMS_INFO
                                WHERE   
                                        PROJECTENDDATE    BETWEEN     @START_DATE
                                                              AND     @END_DATE
                                GROUP BY
                                        PROJECTID
                                        , PROJECTNAME
                                        , TEAM_BSC_DEPT_ID
                                        , PM_BSC_EMP_ID
                                        , PMNAME
                                        , PROJECTENDDATE
                                        , PROJECTSTARTDATE
                        )               PMS
                LEFT OUTER JOIN
                        PRJ_INFO        PRJ
                    ON  PMS.PRJ_ID                  =       PRJ.PRJ_CODE
                LEFT OUTER JOIN
                        COM_DEPT_INFO   DEPT
                    ON  PMS.PRJ_DEPT_ID             =       DEPT.DEPT_REF_ID
                LEFT OUTER JOIN
                        PRJ_DATA
                    ON  (  
                            PRJ.PRJ_REF_ID          =       PRJ_DATA.PRJ_REF_ID
                        AND PRJ_DATA.TGT_DEPT_ID    =   -1
                        AND PRJ_DATA.TGT_EMP_ID     =   -1
                        )
        )
    WHERE
                PRJ_NAME        LIKE    @PRJ_NAME
        AND (   PRJ_REF_ID_YN   =     @GUBUN        OR  @GUBUN      ='' )
        AND (   EST_EMP_ID      =     @EST_EMP_ID   OR  @EST_EMP_ID = 0 )
    GROUP BY
        PRJ_ID
      , PRJ_NAME
      , DEPT_NAME
      , PM_EMP_NAME
      --, EMP_WORK_MM
      , PRJ_REF_ID
      , PRJ_EST_DATE
      , PRJ_EST_STATUS
      , EST_DEPT_ID
      , EST_EMP_ID
      , PRJ_ENDDATE
      , PRJ_STARTDATE
    ORDER BY
        PRJ_ENDDATE DESC
";


            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@START_DATE", SqlDbType.Date);
            paramArray[0].Value = start_date;
            paramArray[1] = CreateDataParameter("@END_DATE", SqlDbType.Date);
            paramArray[1].Value = end_date;
            paramArray[2] = CreateDataParameter("@PRJ_NAME", SqlDbType.NVarChar);
            paramArray[2].Value = "%" + DataTypeUtility.GetString(PRJ_NAME) + "%";
            paramArray[3] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[3].Value = est_emp_id;


            string strGubun;
            if (gubun == EST_GUBUN.TOTAL)
                strGubun = "";
            else if (gubun == EST_GUBUN.EXCLUDED_PRJ_INFO)
                strGubun = "N";
            else
                strGubun = "Y";
            paramArray[4] = CreateDataParameter("@GUBUN", SqlDbType.NVarChar);
            paramArray[4].Value = strGubun;



            DataTable dt = DbAgentObj.FillDataSet(query, "PMS_INFO_JOIN_PRJ_INFO", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        public DataTable Select_Pms_Info_Join_Prj_Info(object est_id, object estterm_ref_id, object estterm_sub_id, object estterm_step_id, object prj_name, object est_emp_id, EST_GUBUN gubun)
        {
            string query = @"
SELECT  PRJ_ID
      , PRJ_NAME
      , DEPT_NAME
      , PM_EMP_NAME
      --, EMP_WORK_MM
      , PRJ_REF_ID
      , PRJ_EST_DATE
      , PRJ_EST_STATUS
      , EST_DEPT_ID
      , EST_EMP_ID
      , TO_CHAR(PRJ_ENDDATE,'YYYY-MM-DD') AS PRJ_ENDDATE
      , TO_CHAR(PRJ_STARTDATE,'YYYY-MM-DD') AS PRJ_STARTDATE
    FROM
        (
            SELECT
                    PMS.PRJ_ID          AS  PRJ_ID
                    , PMS.PRJ_NM        AS  PRJ_NAME

                    , CASE  WHEN    DEPT.DEPT_NAME      IS NULL     THEN    CAST(PMS.PRJ_DEPT_ID AS varchar(100))
                                                                    ELSE    DEPT.DEPT_NAME
                        END             AS  DEPT_NAME

                    , PMS.PM_EMP_NAME   AS  PM_EMP_NAME

                    , CASE  WHEN    PRJ.PRJ_REF_ID      IS NULL     THEN    '-'
                                                                    ELSE    CAST(PRJ.PRJ_REF_ID AS varchar(100))
                        END             AS  PRJ_REF_ID

                    , CASE  WHEN    PRJ.PRJ_REF_ID      IS NULL     THEN    'N'
                                                                    ELSE    'Y'
                        END             AS  PRJ_REF_ID_YN

                    , CASE  WHEN    PRJ_DATA.STATUS_ID  =   'E'     THEN    CAST(PRJ_DATA.STATUS_DATE AS varchar(100))
                                                                    ELSE    '-'
                        END             AS  PRJ_EST_DATE

                    , CASE  WHEN    PRJ_DATA.STATUS_ID  IS NULL     THEN    '-'
                                                                    ELSE    PRJ_DATA.STATUS_ID
                        END             AS  PRJ_EST_STATUS
                    , PMS.PRJ_DEPT_ID   AS  EST_DEPT_ID
                    , PMS.PM_EMP_ID     AS  EST_EMP_ID
                    , PMS.PRJ_ENDDATE   AS  PRJ_ENDDATE
                    , PMS.PRJ_STARTDATE AS  PRJ_STARTDATE
                FROM
                        (
                            SELECT 
                                        PROJECTID           AS PRJ_ID
                                        , PROJECTNAME       AS PRJ_NM
                                        , TEAM_BSC_DEPT_ID  AS PRJ_DEPT_ID
                                        , PM_BSC_EMP_ID     AS PM_EMP_ID
                                        , PMNAME            AS PM_EMP_NAME
                                        , PROJECTENDDATE    AS PRJ_ENDDATE
                                        , PROJECTSTARTDATE  AS PRJ_STARTDATE

                                FROM
                                        PMS_INFO
                                GROUP BY
                                        PROJECTID
                                        , PROJECTNAME
                                        , TEAM_BSC_DEPT_ID
                                        , PM_BSC_EMP_ID
                                        , PMNAME
                                        , PROJECTENDDATE
                                        , PROJECTSTARTDATE
                        )               PMS
                LEFT OUTER JOIN
                        PRJ_INFO        PRJ
                    ON  PMS.PRJ_ID                  =       PRJ.PRJ_CODE
                LEFT OUTER JOIN
                        COM_DEPT_INFO   DEPT
                    ON  PMS.PRJ_DEPT_ID             =       DEPT.DEPT_REF_ID
                LEFT OUTER JOIN
                        PRJ_DATA
                    ON  (  
                                PRJ.PRJ_REF_ID              =   PRJ_DATA.PRJ_REF_ID
                        AND     PRJ_DATA.TGT_DEPT_ID        =   -1
                        AND     PRJ_DATA.TGT_EMP_ID         =   -1
                        
                        )
                WHERE
                            (   PRJ_DATA.EST_ID             =   @EST_ID             OR  @EST_ID             ='' )    
                        AND (   PRJ_DATA.ESTTERM_REF_ID     =   @ESTTERM_REF_ID     OR  @ESTTERM_REF_ID     = 0 )    
                        AND (   PRJ_DATA.ESTTERM_SUB_ID     =   @ESTTERM_SUB_ID     OR  @ESTTERM_SUB_ID     = 0 )    
                        AND (   PRJ_DATA.ESTTERM_STEP_ID    =   @ESTTERM_STEP_ID    OR  @ESTTERM_STEP_ID    = 0 )
        )
    WHERE
                PRJ_NAME        LIKE    @PRJ_NAME
        AND (   PRJ_REF_ID_YN   =   @GUBUN              OR  @GUBUN      ='' )
        AND (   EST_EMP_ID      =   @EST_EMP_ID         OR  @EST_EMP_ID  = 0 )            
    GROUP BY
        PRJ_ID
      , PRJ_NAME
      , DEPT_NAME
      , PM_EMP_NAME
      --, EMP_WORK_MM
      , PRJ_REF_ID
      , PRJ_EST_DATE
      , PRJ_EST_STATUS
      , EST_DEPT_ID
      , EST_EMP_ID
      , PRJ_ENDDATE
      , PRJ_STARTDATE
    ORDER BY
        PRJ_ENDDATE DESC
";


            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[0].Value = est_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = est_emp_id;
            
            
            paramArray[5] = CreateDataParameter("@PRJ_NAME", SqlDbType.NVarChar);
            paramArray[5].Value = "%" + DataTypeUtility.GetString(prj_name) + "%";




            string tmpFlag;
            if (gubun == EST_GUBUN.TOTAL)
                tmpFlag = "";
            else if (gubun == EST_GUBUN.EXCLUDED_PRJ_INFO)
                tmpFlag = "N";
            else
                tmpFlag = "Y";
            paramArray[6] = CreateDataParameter("@GUBUN", SqlDbType.NVarChar);
            paramArray[6].Value = tmpFlag;



            DataTable dt = DbAgentObj.FillDataSet(query, "PMS_INFO_JOIN_PRJ_INFO", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        public int Delete_Prj_Info(IDbConnection conn, IDbTransaction trx, object PRJ_ID)
        {
            int affectedRow = 0;
            string query = @"
DELETE
    FROM    PRJ_INFO
    WHERE   PRJ_CODE    =   @PRJ_ID 
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@PRJ_ID", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_ID;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        public int Insert_Prj_Info(IDbConnection conn, IDbTransaction trx
                                    , object PRJ_CODE
                                    , object PRJ_NAME
                                    , object APP_REF_ID
                                    , object DEFINITION
                                    , object REF_STG
                                    , object EFFECTIVENESS
                                    , object RANGE
                                    , object OWNER_DEPT_ID
                                    , object OWNER_EMP_ID
                                    , object REQUEST_DEPT
                                    , object PRIORITY
                                    , object TOTAL_BUDGET
                                    , object PRJ_TYPE
                                    , object INTERESTED_PARTIES
                                    , object PLAN_START_DATE
                                    , object PLAN_END_DATE
                                    , object ACTUAL_START_DATE
                                    , object ACTUAL_END_DATE
                                    , object CREATE_USER_REF_ID)
        {
            int affectedRow = 0;
            string query = @"
INSERT
    INTO    PRJ_INFO
            (
                PRJ_CODE
                , PRJ_NAME
                , APP_REF_ID
                , DEFINITION
                , REF_STG
                , EFFECTIVENESS
                , RANGE
                , OWNER_DEPT_ID
                , OWNER_EMP_ID
                , REQUEST_DEPT
                , PRIORITY
                , TOTAL_BUDGET
                , PRJ_TYPE
                , INTERESTED_PARTIES
                , PLAN_START_DATE
                , PLAN_END_DATE
                , ACTUAL_START_DATE
                , ACTUAL_END_DATE
                , CREATE_USER
            )
            VALUES
            (
                @PRJ_CODE
                , @PRJ_NAME
                , @APP_REF_ID
                , @DEFINITION
                , @REF_STG
                , @EFFECTIVENESS
                , @RANGE
                , @OWNER_DEPT_ID
                , @OWNER_EMP_ID
                , @REQUEST_DEPT
                , @PRIORITY
                , @TOTAL_BUDGET
                , @PRJ_TYPE
                , @INTERESTED_PARTIES
                , @PLAN_START_DATE
                , @PLAN_END_DATE
                , @ACTUAL_START_DATE
                , @ACTUAL_END_DATE
                , @CREATE_USER
            )
";
            IDbDataParameter[] paramArray = CreateDataParameters(19);

            paramArray[0] = CreateDataParameter("@PRJ_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_CODE;
            paramArray[1] = CreateDataParameter("@PRJ_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = PRJ_NAME;
            paramArray[2] = CreateDataParameter("@APP_REF_ID", SqlDbType.Float);
            paramArray[2].Value = APP_REF_ID;
            paramArray[3] = CreateDataParameter("@DEFINITION", SqlDbType.NVarChar);
            paramArray[3].Value = DEFINITION;
            paramArray[4] = CreateDataParameter("@REF_STG", SqlDbType.NVarChar);
            paramArray[4].Value = REF_STG;
            paramArray[5] = CreateDataParameter("@EFFECTIVENESS", SqlDbType.NVarChar);
            paramArray[5].Value = EFFECTIVENESS;
            paramArray[6] = CreateDataParameter("@RANGE", SqlDbType.NVarChar);
            paramArray[6].Value = RANGE;
            paramArray[7] = CreateDataParameter("@OWNER_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = OWNER_DEPT_ID;
            paramArray[8] = CreateDataParameter("@OWNER_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = OWNER_EMP_ID;
            paramArray[9] = CreateDataParameter("@REQUEST_DEPT", SqlDbType.NVarChar);
            paramArray[9].Value = REQUEST_DEPT;
            paramArray[10] = CreateDataParameter("@PRIORITY", SqlDbType.NVarChar);
            paramArray[10].Value = PRIORITY;
            paramArray[11] = CreateDataParameter("@TOTAL_BUDGET", SqlDbType.Int);
            paramArray[11].Value = TOTAL_BUDGET;
            paramArray[12] = CreateDataParameter("@PRJ_TYPE", SqlDbType.NVarChar);
            paramArray[12].Value = PRJ_TYPE;
            paramArray[13] = CreateDataParameter("@INTERESTED_PARTIES", SqlDbType.NVarChar);
            paramArray[13].Value = INTERESTED_PARTIES;
            paramArray[14] = CreateDataParameter("@PLAN_START_DATE", SqlDbType.Date);
            paramArray[14].Value = PLAN_START_DATE;
            paramArray[15] = CreateDataParameter("@PLAN_END_DATE", SqlDbType.Date);
            paramArray[15].Value = PLAN_END_DATE;
            paramArray[16] = CreateDataParameter("@ACTUAL_START_DATE", SqlDbType.Date);
            paramArray[16].Value = ACTUAL_START_DATE;
            paramArray[17] = CreateDataParameter("@ACTUAL_END_DATE", SqlDbType.Date);
            paramArray[17].Value = ACTUAL_END_DATE;
            paramArray[18] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[18].Value = CREATE_USER_REF_ID;

            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }




        public int Select_Prj_Ref_Id(IDbConnection conn, IDbTransaction trx, object PRJ_CODE)
        {
            object Result;
            string query = @"
SELECT      PRJ_REF_ID
    FROM    PRJ_INFO
    WHERE   PRJ_CODE    =   @PRJ_CODE
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@PRJ_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = PRJ_CODE;

            Result = DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text);

            return DataTypeUtility.GetToInt32(Result);
        }



        public DataTable Select_Prj_Info_Join_Question_Map(object comp_id
                                                            , object est_id
                                                            , object estterm_ref_id
                                                            , object estterm_sub_id
                                                            , object estterm_step_id
                                                            , object prj_ref_id
                                                            , object q_obj_id)
        {
            string query = @"
SELECT      PI.PRJ_REF_ID
            ,PI.PRJ_CODE
            ,PI.PRJ_NAME
            ,PI.APP_REF_ID
            ,PI.DEFINITION
            ,PI.REF_STG
            ,PI.EFFECTIVENESS
            ,PI.RANGE
            ,PI.OWNER_DEPT_ID
            ,CD.DEPT_NAME as OWNER_DEPT_NAME
            ,PI.OWNER_EMP_ID
            ,CE.EMP_NAME  as OWNER_EMP_NAME
            ,PI.REQUEST_DEPT
            ,PI.PRIORITY
            ,PI.TOTAL_BUDGET
            ,PI.PRJ_TYPE
            ,PI.INTERESTED_PARTIES
            ,PI.PLAN_START_DATE
            ,PI.PLAN_END_DATE
            ,PI.ACTUAL_START_DATE
            ,PI.ACTUAL_END_DATE
            ,PI.ISDELETE
            ,PI.CREATE_USER
            ,PI.CREATE_DATE
            ,PI.UPDATE_USER
            ,PI.UPDATE_DATE
            ,MAP.PRJ_REF_ID             AS  MAP_PRJ_REF_ID 
    FROM                    PRJ_INFO PI
        LEFT OUTER JOIN     PRJ_DATA    PD
            ON (    PI.PRJ_REF_ID       =   PD.PRJ_REF_ID
                AND PD.TGT_DEPT_ID      =   -1 
                AND     PD.TGT_EMP_ID   =   -1  )
        LEFT OUTER JOIN     COM_EMP_INFO CE
            ON      PI.OWNER_EMP_ID     =   CE.EMP_REF_ID
        LEFT OUTER JOIN     COM_DEPT_INFO   CD
            ON      PI.OWNER_DEPT_ID    =   CD.DEPT_REF_ID
        LEFT OUTER JOIN     PRJ_QUESTION_PRJ_MAP MAP
            ON      PI.PRJ_REF_ID       =   MAP.PRJ_REF_ID
    WHERE   (   PD.COMP_ID         = @COMP_ID	        OR @COMP_ID         = 0 )
        AND (   PD.EST_ID          = @EST_ID	        OR @EST_ID          ='' )
        AND (   PD.ESTTERM_REF_ID  = @ESTTERM_REF_ID	OR @ESTTERM_REF_ID  = 0 )
        AND (   PD.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID	OR @ESTTERM_SUB_ID  = 0 )
        AND (   PD.ESTTERM_STEP_ID = @ESTTERM_STEP_ID   OR @ESTTERM_STEP_ID = 0 )
        AND (   PI.PRJ_REF_ID      = @PRJ_REF_ID	    OR @PRJ_REF_ID      = 0 )
        AND (   MAP.Q_OBJ_ID       = @Q_OBJ_ID	        OR @Q_OBJ_ID        ='' )
    ORDER BY    PI.CREATE_DATE  DESC
";
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
            paramArray[5] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[5].Value = prj_ref_id;
            paramArray[6] = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar);
            paramArray[6].Value = q_obj_id;


            DataTable dt = DbAgentObj.FillDataSet(query, "PRJ_JOIN_QUESTION_MAP", null, paramArray).Tables[0];

            return dt;
        }
    }
}
