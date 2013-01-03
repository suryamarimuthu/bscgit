using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_IF : DbAgentBase
    {
        public Dac_Com_IF()
        {

        }



        
        public DataSet Select_Diff_DeptInfo_IF()
        {
            DataSet DS = new DataSet();
            string query = @"
 SELECT  SRC.DEPT_CODE          AS  SRC_DEPT_CODE
        , SRC.DEPT_NAME         AS  SRC_DEPT_NAME
        , SRC.UP_DEPT_CODE      AS  SRC_UP_DEPT_CODE
        , SRC.UP_DEPT_NAME      AS  SRC_UP_DEPT_NAME   
        , SRC.DEPT_LEVEL        AS  SRC_DEPT_LEVEL
        , SRC.SORT_ORDER        AS  SRC_SORT_ORDER

        , TARGET.DEPT_CODE      AS  TARGET_DEPT_CODE
        , TARGET.DEPT_NAME      AS  TARGET_DEPT_NAME
        , TARGET.UP_DEPT_CODE   AS  TARGET_UP_DEPT_CODE
        , TARGET.UP_DEPT_NAME   AS  TARGET_UP_DEPT_NAME

        , CASE WHEN     SRC.DEPT_CODE   IS NULL     OR  TARGET.DEPT_CODE    IS NULL     THEN 'N'
                                                                                        ELSE 'Y'
                                                            END     AS  GUBUN

     FROM 
                             (
                                 SELECT A.INSERT_DATE
                                        , A.DEPT_CODE
                                        , A.DEPT_NAME
                                        , CASE WHEN     A.UP_DEPT_CODE  IS NULL
                                                    OR  A.UP_DEPT_CODE  =   '-'
                                                    OR  A.UP_DEPT_CODE  =   ''      THEN    '0'
                                                                                    ELSE    A.UP_DEPT_CODE
                                                        END    AS  UP_DEPT_CODE
                                        , CASE WHEN     B.DEPT_NAME     IS NULL     THEN    ''
                                                                                    ELSE    B.DEPT_NAME
                                                        END    AS  UP_DEPT_NAME
                                        , A.DEPT_LEVEL
                                        , A.DEPT_USEYN
                                        , A.SORT_ORDER
                                        , A.DEPT_STRDATE
                                        , A.DEPT_ENDDATE 
                                     FROM                   COM_DEPT_INFO_IF    A
                                        LEFT OUTER JOIN     COM_DEPT_INFO_IF    B
                                            ON (    A.UP_DEPT_CODE  =   B.DEPT_CODE )
                                     WHERE
                                            A.DEPT_USEYN='Y'
                                        AND A.INSERT_DATE   IN  (
                                                                    SELECT      MAX(INSERT_DATE)
                                                                        FROM    COM_DEPT_INFO_IF
                                                                )
                             ) SRC
         FULL OUTER JOIN 
                             (
                                 SELECT A.DEPT_REF_ID
                                        , A.UP_DEPT_ID
                                        , A.DEPT_LEVEL
                                        , A.DEPT_NAME
                                        , A.DEPT_CODE
                                        , CASE WHEN     B.DEPT_CODE     IS NULL THEN        '0'
                                                                                ELSE        B.DEPT_CODE
                                                        END     AS      UP_DEPT_CODE
                                        , CASE WHEN     B.DEPT_NAME     IS NULL THEN        ''
                                                                                ELSE        B.DEPT_NAME
                                                        END     AS      UP_DEPT_NAME
                                        , A.DEPT_FLAG
                                        , A.DEPT_TYPE
                                        , A.SORT_ORDER
                                        , A.DEPT_DESC
                                        , A.CREATE_USER
                                        , A.CREATE_DATE
                                        , A.UPDATE_USER
                                        , A.UPDATE_DATE
                                    FROM                    COM_DEPT_INFO A
                                        LEFT OUTER JOIN     COM_DEPT_INFO B
                                            ON  A.UP_DEPT_ID    =   B.DEPT_REF_ID
                             ) TARGET
             ON (   
                    SRC.DEPT_CODE       =   TARGET.DEPT_CODE
                AND SRC.UP_DEPT_CODE    =   TARGET.UP_DEPT_CODE
                )
    ORDER BY
                SRC.DEPT_LEVEL          ASC
                , SRC.SORT_ORDER        ASC
                , TARGET.DEPT_LEVEL     ASC
                , TARGET.SORT_ORDER     ASC
";

            DS = DbAgentObj.Fill(query.ToString());

            return DS;
        }





        /// <summary>
        /// GUBUN : "Y" or "N"
        /// </summary>
        public DataSet Select_Diff_EmpInfo_IF(string GUBUN, int firstRowNum, int lastRowNum)
        {
            DataSet DS = new DataSet();
            string query = @"
SELECT      SRC_DEPT_CODE
            , SRC_DEPT_NAME
            , SRC_DEPT_USEYN
            , SRC_EMP_CODE
            , SRC_EMP_NAME
            , SRC_POSITION_CLASS_CODE
            , SRC_POSITION_GRP_CODE
            , SRC_POSITION_RANK_CODE
            , SRC_POSITION_DUTY_CODE
            , SRC_POS_KIND_CD
            , TARGET_DEPT_CODE
            , TARGET_DEPT_NAME
            , TARGET_EMP_CODE
            , TARGET_EMP_NAME
            , GUBUN
            , RN
    FROM
    (
        SELECT  SRC.DEPT_CODE               AS  SRC_DEPT_CODE
                , SRC.DEPT_NAME             AS  SRC_DEPT_NAME
                , SRC.DEPT_USEYN            AS  SRC_DEPT_USEYN
                , SRC.EMP_CODE              AS  SRC_EMP_CODE
                , SRC.EMP_NAME              AS  SRC_EMP_NAME
                , SRC.POSITION_CLASS_CODE   AS  SRC_POSITION_CLASS_CODE
                , SRC.POSITION_GRP_CODE     AS  SRC_POSITION_GRP_CODE
                , SRC.POSITION_RANK_CODE    AS  SRC_POSITION_RANK_CODE
                , SRC.POSITION_DUTY_CODE    AS  SRC_POSITION_DUTY_CODE
                , SRC.POS_KIND_CD           AS  SRC_POS_KIND_CD
                
                , TARGET.DEPT_CODE          AS  TARGET_DEPT_CODE
                , TARGET.DEPT_NAME          AS  TARGET_DEPT_NAME
                , TARGET.EMP_CODE           AS  TARGET_EMP_CODE
                , TARGET.EMP_NAME           AS  TARGET_EMP_NAME

                , CASE WHEN     SRC.EMP_CODE    !=  TARGET.EMP_CODE
                            OR  SRC.DEPT_CODE   !=  TARGET.DEPT_CODE    THEN 'N' ELSE 'Y' END AS GUBUN

                , ROW_NUMBER() OVER ( ORDER BY SRC.EMP_NAME ASC, TARGET.EMP_NAME ASC) AS RN
            FROM 
                (
                    SELECT  DEPT.DEPT_CODE
                            , DEPT.DEPT_NAME
                            , EMP.EMP_CODE
                            , EMP.EMP_NAME
                        FROM            REL_DEPT_EMP        REL
                            INNER JOIN  COM_DEPT_INFO       DEPT
                                ON  REL.DEPT_REF_ID =   DEPT.DEPT_REF_ID
                            INNER JOIN  COM_EMP_INFO        EMP
                                ON  REL.EMP_REF_ID  =   EMP.EMP_REF_ID
                ) TARGET
                FULL OUTER JOIN
                (
                    SELECT  EMP.EMP_CODE
                            , EMP.EMP_NAME
                            , EMP.DEPT_CODE
                            , DEPT.DEPT_NAME
                            , DEPT.DEPT_USEYN
                            , POSITION_CLASS_CODE
                            , POSITION_CLASS_NAME
                            , POSITION_GRP_CODE
                            , POSITION_GRP_NAME
                            , POSITION_RANK_CODE
                            , POSITION_RANK_NAME
                            , POSITION_DUTY_CODE
                            , POSITION_DUTY_NAME
                            , POS_KIND_CD
                            , POS_KIND_NM
                            , EMP_STRDATE
                            , EMP_ENDDATE
                        FROM
                                        COM_EMP_INFO_IF     EMP
                            INNER JOIN  COM_DEPT_INFO_IF    DEPT
                                ON  EMP.DEPT_CODE   =   DEPT.DEPT_CODE
                        WHERE
                                EMP.INSERT_DATE     IN  (
                                                            SELECT      MAX(INSERT_DATE)
                                                                FROM    COM_EMP_INFO_IF
                                                        )
                            AND DEPT.INSERT_DATE    IN  (
                                                            SELECT      MAX(INSERT_DATE)
                                                                FROM    COM_DEPT_INFO_IF
                                                        )
                ) SRC
                    ON (TARGET.EMP_CODE=SRC.EMP_CODE)
            WHERE   (
                        CASE WHEN     SRC.EMP_CODE    !=  TARGET.EMP_CODE
                            OR  SRC.DEPT_CODE   !=  TARGET.DEPT_CODE    THEN 'N' ELSE 'Y' END   =   @GUBUN   OR  @GUBUN  =''
                    )
                AND SRC.DEPT_USEYN  =   'Y'
    )
    WHERE   (  RN BETWEEN @firstRowNum AND @lastRowNum  )
        
";


            IDbDataParameter[] paramArray;

            paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@firstRowNum", SqlDbType.Int);
            paramArray[0].Value = firstRowNum;
            paramArray[1] = CreateDataParameter("@lastRowNum", SqlDbType.Int);
            paramArray[1].Value = lastRowNum;
            paramArray[2] = CreateDataParameter("@GUBUN", SqlDbType.NVarChar);
            paramArray[2].Value = GUBUN;


            DS = DbAgentObj.Fill(query, paramArray);

            return DS;
        }





        public int Select_Diff_EmpInfo_IF_Count(string GUBUN)
        {
            /*
            string query = @"
SELECT  COUNT(*)
    FROM 
        (
            SELECT DEPT.DEPT_CODE, DEPT.DEPT_NAME, EMP.EMP_CODE, EMP.EMP_NAME
                FROM            REL_DEPT_EMP    REL
                    INNER JOIN  COM_DEPT_INFO   DEPT
                        ON  REL.DEPT_REF_ID =   DEPT.DEPT_REF_ID
                    INNER JOIN  COM_EMP_INFO    EMP
                        ON  REL.EMP_REF_ID  =   EMP.EMP_REF_ID
        ) TARGET
        FULL OUTER JOIN
            COM_EMP_INFO_IF SRC
            ON (TARGET.EMP_CODE=SRC.EMP_CODE)
";
            */

            string query = @"
SELECT      COUNT(*)
    FROM
    (
        SELECT  SRC.DEPT_CODE               AS  SRC_DEPT_CODE
                , SRC.DEPT_NAME             AS  SRC_DEPT_NAME
                , SRC.DEPT_USEYN            AS  SRC_DEPT_USEYN
                , SRC.EMP_CODE              AS  SRC_EMP_CODE
                , SRC.EMP_NAME              AS  SRC_EMP_NAME
                , SRC.POSITION_CLASS_CODE   AS  SRC_POSITION_CLASS_CODE
                , SRC.POSITION_GRP_CODE     AS  SRC_POSITION_GRP_CODE
                , SRC.POSITION_RANK_CODE    AS  SRC_POSITION_RANK_CODE
                , SRC.POSITION_DUTY_CODE    AS  SRC_POSITION_DUTY_CODE
                , SRC.POS_KIND_CD           AS  SRC_POS_KIND_CD
                
                , TARGET.DEPT_CODE          AS  TARGET_DEPT_CODE
                , TARGET.DEPT_NAME          AS  TARGET_DEPT_NAME
                , TARGET.EMP_CODE           AS  TARGET_EMP_CODE
                , TARGET.EMP_NAME           AS  TARGET_EMP_NAME

                , CASE WHEN     SRC.EMP_CODE    !=  TARGET.EMP_CODE
                            OR  SRC.DEPT_CODE   !=  TARGET.DEPT_CODE    THEN 'N' ELSE 'Y' END AS GUBUN

                --, ROW_NUMBER() OVER ( ORDER BY SRC.EMP_NAME ASC, TARGET.EMP_NAME ASC) AS RN
            FROM 
                (
                    SELECT  DEPT.DEPT_CODE
                            , DEPT.DEPT_NAME
                            , EMP.EMP_CODE
                            , EMP.EMP_NAME
                        FROM            REL_DEPT_EMP        REL
                            INNER JOIN  COM_DEPT_INFO       DEPT
                                ON  REL.DEPT_REF_ID =   DEPT.DEPT_REF_ID
                            INNER JOIN  COM_EMP_INFO        EMP
                                ON  REL.EMP_REF_ID  =   EMP.EMP_REF_ID
                ) TARGET
                FULL OUTER JOIN
                (
                    SELECT  EMP.EMP_CODE
                            , EMP.EMP_NAME
                            , EMP.DEPT_CODE
                            , DEPT.DEPT_NAME
                            , DEPT.DEPT_USEYN
                            , POSITION_CLASS_CODE
                            , POSITION_CLASS_NAME
                            , POSITION_GRP_CODE
                            , POSITION_GRP_NAME
                            , POSITION_RANK_CODE
                            , POSITION_RANK_NAME
                            , POSITION_DUTY_CODE
                            , POSITION_DUTY_NAME
                            , POS_KIND_CD
                            , POS_KIND_NM
                            , EMP_STRDATE
                            , EMP_ENDDATE
                        FROM
                                        COM_EMP_INFO_IF     EMP
                            INNER JOIN  COM_DEPT_INFO_IF    DEPT
                                ON  EMP.DEPT_CODE   =   DEPT.DEPT_CODE
                        WHERE
                                EMP.INSERT_DATE     IN  (
                                                            SELECT      MAX(INSERT_DATE)
                                                                FROM    COM_EMP_INFO_IF
                                                        )
                            AND DEPT.INSERT_DATE    IN  (
                                                            SELECT      MAX(INSERT_DATE)
                                                                FROM    COM_DEPT_INFO_IF
                                                        )
                ) SRC
                    ON (TARGET.EMP_CODE=SRC.EMP_CODE)
            WHERE   (
                        CASE WHEN     SRC.EMP_CODE    !=  TARGET.EMP_CODE
                            OR  SRC.DEPT_CODE   !=  TARGET.DEPT_CODE    THEN 'N' ELSE 'Y' END   =   @GUBUN   OR  @GUBUN  =''
                    )
                AND SRC.DEPT_USEYN  =   'Y'
    )
";
            IDbDataParameter[] paramArray;

            paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@GUBUN", SqlDbType.NVarChar);
            paramArray[0].Value = GUBUN;


            object Result = DbAgentObj.ExecuteScalar(query, paramArray);

            return DataTypeUtility.GetToInt32(Result);
        }





        public int Insert_Rel_Dept_Emp(IDbConnection conn
                                        , IDbTransaction trx
                                        , object EMP_REF_ID
                                        , object DEPT_REF_ID
                                        , object REL_STATUS
                                        , object BOSS_FLAG
                                        , object REL_DATE
                                        , object REL_EMP_ID)
        {
            string query = @"
INSERT INTO REL_DEPT_EMP
    (
        EMP_REF_ID
        , DEPT_REF_ID
        , REL_STATUS
        , BOSS_FLAG
        , REL_DATE
        , REL_EMP_ID
    )
    VALUES
    (
        @EMP_REF_ID
        , @DEPT_REF_ID
        , @REL_STATUS
        , @BOSS_FLAG
        , @REL_DATE
        , @REL_EMP_ID
    )";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = EMP_REF_ID;
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = DEPT_REF_ID;
            paramArray[2] = CreateDataParameter("@REL_STATUS", SqlDbType.Int);
            paramArray[2].Value = REL_STATUS;
            paramArray[3] = CreateDataParameter("@BOSS_FLAG", SqlDbType.Int);
            paramArray[3].Value = BOSS_FLAG;
            paramArray[4] = CreateDataParameter("@REL_DATE", SqlDbType.Date);
            paramArray[4].Value = REL_DATE;
            paramArray[5] = CreateDataParameter("@REL_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = REL_EMP_ID;
            

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
    }
}
