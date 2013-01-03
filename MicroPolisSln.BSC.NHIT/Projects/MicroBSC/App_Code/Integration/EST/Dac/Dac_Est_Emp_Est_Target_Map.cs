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

namespace MicroBSC.Integration.EST.Dac
{
    public class Dac_Est_Emp_Est_Target_Map : DbAgentBase
    {
        public Dac_Est_Emp_Est_Target_Map()
        {

        }

        public DataSet Select3A_List(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object est_dept_id
                                    , object est_emp_id
                                    , object tgt_dept_id)
        {
            string query = @"

SELECT   F.KPI_CODE
        ,H.DEPT_NAME                AS COM_DEPT_NAME -- TGT_DEPT_NAME
        ,G.KPI_NAME
        ,CASE G.KPI_GROUP_REF_ID WHEN 'QTT' THEN '계량' WHEN 'QLT' THEN '비계량' ELSE '' END AS KPI_GROUP_NAME
        ,ISNULL(L.CATEGORY_NAME, ' ') + '/' + ISNULL(M.CATEGORY_NAME, ' ')  + '/' + ISNULL(N.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(O.UNIT, '-')        AS UNIT_NAME
        ,D.WEIGHT
        ,ISNULL(Q.TARGET_TS, 0) AS TARGET_TS
        ,ISNULL(R.RESULT_TS, 0) AS RESULT_TS
        ,CASE WHEN ISNULL(Q.TARGET_TS, 0) = 0 THEN 0 ELSE ROUND(ISNULL(R.RESULT_TS / Q.TARGET_TS * 100, 0),4) END   AS ACHIEVEMENT_RATE
        ,U1.SET_MIN_VALUE   AS GRADE_S
        ,U1.SET_TXT_VALUE
        ,U2.SET_MIN_VALUE   AS GRADE_A
        ,U2.SET_TXT_VALUE
        ,U3.SET_MIN_VALUE   AS GRADE_B
        ,U3.SET_TXT_VALUE
        ,U4.SET_MIN_VALUE   AS GRADE_C
        ,U4.SET_TXT_VALUE
        ,U5.SET_MIN_VALUE   AS GRADE_D
        ,U5.SET_TXT_VALUE
        ,ISNULL(S.APP_STATUS, 'NFT') AS APP_STATUS
        ,C.SCORE_ORI
        ,C.SCORE_ORI_LIST
        ,ISNULL(C.SCORE_WEIGHT, 0)  AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_GRADE, ' ' ) AS GRADE
        ,C.GRADE_REASON
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,C.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
        ,C.KPI_REF_ID
        ,T.ESTTERM_STEP_NAME
        ,G.KPI_GROUP_REF_ID
        ,ISNULL(Z.SCORE_GRADE, ' ' ) AS GRADE_ORG
        ,G.KPI_POOL_REF_ID
        ,G.BASIS_USE_YN
        ,B.SCORE                    AS SCORE_MT
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
--INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
--                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID


INNER JOIN (

                SELECT TA.ESTTERM_rEF_ID, TA.EST_DEPT_rEF_ID, TA.MAX_VER
                       ,TB.KPI_REF_ID ,TB.WEIGHT
                  FROM  ( SELECT ESTTERM_rEF_ID, EST_DEPT_rEF_ID, MAX(MAP_VERSION_ID) AS MAX_VER
                            FROM BSC_MAP_KPI TA
                           GROUP BY ESTTERM_rEF_ID, EST_DEPT_rEF_ID
                         )TA , BSC_MAP_KPI TB
                 WHERE TA.ESTTERM_rEF_ID = TB.ESTTERM_rEF_ID
                   AND TA.EST_DEPT_rEF_ID = TB.EST_DEPT_rEF_ID
           )  D
                                     ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EST_DEPT_REF_ID   = C.TGT_DEPT_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                   
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = C.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   H   ON  H.DEPT_REF_ID       = C.TGT_DEPT_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  I   ON  I.ETC_CODE  = G.KPI_GROUP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                L   ON  L.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                M   ON  M.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND M.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                N   ON  N.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND N.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
                                                        AND N.CATEGORY_LOW_REF_ID   = G.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  O  ON O.UNIT_TYPE_REF_ID  = F.UNIT_TYPE_REF_ID
/*LEFT OUTER*/ JOIN BSC_KPI_TARGET_VERSION  P   ON  P.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                            AND P.KPI_REF_ID        = C.KPI_REF_ID
                                            AND P.USE_YN            = 'Y'
/*LEFT OUTER*/ JOIN BSC_KPI_TARGET          Q   ON  Q.ESTTERM_REF_ID    = P.ESTTERM_REF_ID
                                            AND Q.KPI_REF_ID        = P.KPI_REF_ID
                                            AND Q.KPI_TARGET_VERSION_ID = P.KPI_TARGET_VERSION_ID
                                            AND Q.YMD                   = C.YMD
/*LEFT OUTER*/ JOIN BSC_KPI_RESULT          R   ON  R.ESTTERM_REF_ID    = Q.ESTTERM_REF_ID
                                            AND R.KPI_REF_ID        = Q.KPI_REF_ID
                                            AND R.YMD               = Q.YMD
/*LEFT OUTER*/ JOIN COM_APPROVAL_INFO       S   ON  S.APP_REF_ID        = R.APP_REF_ID
                                            AND S.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U1  ON  U1.ESTTERM_REF_ID   = C.ESTTERM_REF_ID
                                            AND U1.KPI_REF_ID       = C.KPI_REF_ID
                                            AND U1.THRESHOLD_REF_ID = 1
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U2  ON  U2.ESTTERM_REF_ID   = C.ESTTERM_REF_ID
                                            AND U2.KPI_REF_ID       = C.KPI_REF_ID
                                            AND U2.THRESHOLD_REF_ID = 2
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U3  ON  U3.ESTTERM_REF_ID   = C.ESTTERM_REF_ID
                                            AND U3.KPI_REF_ID       = C.KPI_REF_ID
                                            AND U3.THRESHOLD_REF_ID = 3
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U4  ON  U4.ESTTERM_REF_ID   = C.ESTTERM_REF_ID
                                            AND U4.KPI_REF_ID       = C.KPI_REF_ID
                                            AND U4.THRESHOLD_REF_ID = 4
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U5  ON  U5.ESTTERM_REF_ID   = C.ESTTERM_REF_ID
                                            AND U5.KPI_REF_ID       = C.KPI_REF_ID
                                            AND U5.THRESHOLD_REF_ID = 5
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND (A.TGT_DEPT_ID           = @TGT_DEPT_ID   OR  @TGT_DEPT_ID = 0 )
    --AND A.TGT_EMP_ID           = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC

";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATATABLE0", null, paramArray, CommandType.Text);
            return ds;
        }

    

        public DataSet Select3APre_Table1(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object tgt_dept_id)
        {

            //[1]평가상태
            string query = @"
SELECT  TOP 1 A.REPORT, A.REPORT_FILE, A.STATUS, ISNULL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
";
           string queryOra = @"
SELECT  A.REPORT, A.REPORT_FILE, A.STATUS, NVL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_DEPT_ID        = A.TGT_DEPT_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND ROWNUM = 1
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE1", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select3APre_Table2(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id)
        {

            //[2] 평가마감여부
            string query = @"
SELECT	C.START_DATE, C.END_DATE, ISNULL(C.STATUS_YN, 'N') AS STATUS_YN
FROM		EST_JOB_EST_MAP	A
INNER JOIN	EST_JOB_INFO	B	ON	B.EST_JOB_ID	= A.EST_JOB_ID
							AND	B.MNG_PAGE_YN	= 'N'
							AND	B.USE_YN		= 'Y'
INNER JOIN	EST_JOB_DETAIL	C	ON	C.COMP_ID		= A.COMP_ID
								AND	C.EST_ID		= A.EST_ID
								AND	C.ESTTERM_REF_ID	= @ESTTERM_REF_ID
								AND	C.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
								AND	C.EST_JOB_ID		= A.EST_JOB_ID
WHERE	A.COMP_ID		= @COMP_ID
	AND	A.EST_ID		= @EST_ID
	AND	A.EST_JOB_ID	= 'JOB_91'
";
           
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            DataSet ds = DbAgentObj.FillDataSet(query,  "DATATABLE2", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select3APre_Table3(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object est_dept_id
                                    , object est_emp_id
                                    , object tgt_dept_id)
        {
            //[3] 모든 MBO실적 결재되었는지 확인
            string query = @"
SELECT TOP 1 A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND ISNULL(A.STATUS_ID, '') = 'E'
    AND ISNULL(F.APP_STATUS, '') != 'CFT'
";
          string  queryOra = @"
SELECT A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
    AND ISNULL(F.APP_STATUS, ' ') != 'CFT'
    AND ROWNUM = 1
";
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE3", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet Select3APre_Table4(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id
                                    , object est_dept_id
                                    , object est_emp_id
                                    , object tgt_dept_id)
        {
        
            //[4] 평가상태 및 코멘트
           string query = @"
SELECT  A.STATUS, A.COMMENT
FROM    BSC_MBO_KPI_SCORE_MT    A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID   = @ESTTERM_STEP_ID
    AND A.EST_DEPT_ID       = @EST_DEPT_ID
    AND A.EST_EMP_ID        = @EST_EMP_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
";
            
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATATABLE4", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select3APre_Table5(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object tgt_dept_id)
        {


            //[5]피평가자의견(피드백)
            string query = @"
SELECT  A.SEQ, A.COMMENT, A.CONFIRM_TYPE
FROM EST_QUESTION_COMMENT   A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.SEQ               = ( SELECT MAX(SEQ) FROM EST_QUESTION_COMMENT
                                WHERE   COMP_ID           = @COMP_ID
                                    AND EST_ID            = @EST_ID
                                    AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                    AND TGT_DEPT_ID       = @TGT_DEPT_ID)
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATATABLE5", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet Select3APre_Table6(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object tgt_dept_id)
        {

            //[6]현재평가가 아닌놈 가져와서 뿌리기 (평가자로 볼때)
            string query = @"
SELECT   A.ESTTERM_STEP_ID
        ,A.STATUS
        ,B.ESTTERM_STEP_NAME
        ,C.STATUS_NAME
FROM            BSC_MBO_KPI_SCORE_MT    A
LEFT OUTER JOIN EST_TERM_STEP           B   ON  B.COMP_ID           = A.COMP_ID
                                            AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN EST_STATUS              C   ON  C.STATUS_STYLE_ID   = '0003'
                                            AND C.STATUS_ID         = A.STATUS
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.ESTTERM_STEP_ID   > 1
ORDER BY A.ESTTERM_STEP_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATATABLE6", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet Select3APre_Table7(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id
                                    , object est_dept_id
                                    , object est_emp_id
                                    , object tgt_dept_id)
        {
            //[7]이전차수 평가정보보기
            string query = @"
SELECT   C.ESTTERM_STEP_ID
        ,T.ESTTERM_STEP_NAME
        ,C.KPI_REF_ID
        ,ISNULL(C.SCORE_WEIGHT, 0) AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_ORI, 0) AS SCORE_ORI
        ,ISNULL(C.SCORE_GRADE, '') AS GRADE
        ,ISNULL(COM.CODE_NAME, '평가중') AS GRADE_NAME
        ,G.KPI_GROUP_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
--INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
--                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID


INNER JOIN (

                SELECT TA.ESTTERM_rEF_ID, TA.EST_DEPT_rEF_ID, TA.MAX_VER
                       ,TB.KPI_REF_ID ,TB.WEIGHT
                  FROM  ( SELECT ESTTERM_rEF_ID, EST_DEPT_rEF_ID, MAX(MAP_VERSION_ID) AS MAX_VER
                            FROM BSC_MAP_KPI TA
                           GROUP BY ESTTERM_rEF_ID, EST_DEPT_rEF_ID
                         )TA , BSC_MAP_KPI TB
                 WHERE TA.ESTTERM_rEF_ID = TB.ESTTERM_rEF_ID
                   AND TA.EST_DEPT_rEF_ID = TB.EST_DEPT_rEF_ID
           )  D
                                     ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EST_DEPT_REF_ID   = C.TGT_DEPT_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                   



INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID

INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN COM_CODE_INFO   COM ON COM.CATEGORY_CODE = 'BS015' AND COM.USE_YN = 'Y' AND COM.ETC_CODE = C.SCORE_GRADE
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID < @PREESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY C.ESTTERM_STEP_ID DESC, G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC

";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@PREESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5].Value = estterm_step_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATATABLE7", null, paramArray, CommandType.Text);
            return ds;

        }

        public DataSet Select3APre_Table8(object comp_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id
                                        , object estterm_step_id
                                        , object tgt_dept_id)
        {

            //[8]현재차수까지의 평가의견
            string query = @"
SELECT A.ESTTERM_STEP_ID, ISNULL(A.COMMENT, '') AS COMMENT 
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID <= @ESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
ORDER BY A.ESTTERM_STEP_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[5].Value = estterm_step_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATATABLE8", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select3APre_Table9(object comp_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id
                                        , object tgt_dept_id)
        {


            //[9]모든차수의 평가자사번
            string query = @"
SELECT A.ESTTERM_STEP_ID, A.EST_EMP_ID
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
ORDER BY A.ESTTERM_STEP_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;

            DataSet ds = DbAgentObj.FillDataSet(query,  "DATATABLE9", null, paramArray, CommandType.Text);

            return ds;
        }

        public DataSet Get3GAKpiDataList(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id)
        {
            //[0] 평가데이터
            string query = @"
SELECT   F.KPI_CODE
        ,H.DEPT_NAME                AS COM_DEPT_NAME
        ,G.KPI_NAME
        ,E.EMP_NAME
        ,CASE G.KPI_GROUP_REF_ID WHEN 'QTT' THEN '계량' WHEN 'QLT' THEN '비계량' ELSE '' END AS KPI_GROUP_NAME--I.CODE_NAME                AS KPI_GROUP_NAME
        ,K.CODE_NAME                AS CLASS_NAME
        ,ISNULL(L.CATEGORY_NAME, ' ') + '/' + ISNULL(M.CATEGORY_NAME, ' ')  + '/' + ISNULL(N.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(O.UNIT, '-')        AS UNIT_NAME
        ,D.WEIGHT
        ,ISNULL(Q.TARGET_TS, 0) AS TARGET_TS
        ,ISNULL(R.RESULT_TS, 0) AS RESULT_TS
        ,CASE WHEN ISNULL(Q.TARGET_TS, 0) = 0 THEN 0 ELSE ISNULL(R.RESULT_TS / Q.TARGET_TS * 100, 0) END   AS ACHIEVEMENT_RATE
        ,U1.SET_MIN_VALUE   AS GRADE_S
        ,U1.SET_TXT_VALUE
        ,U2.SET_MIN_VALUE   AS GRADE_A
        ,U2.SET_TXT_VALUE
        ,U3.SET_MIN_VALUE   AS GRADE_B
        ,U3.SET_TXT_VALUE
        ,U4.SET_MIN_VALUE   AS GRADE_C
        ,U4.SET_TXT_VALUE
        ,U5.SET_MIN_VALUE   AS GRADE_D
        ,U5.SET_TXT_VALUE
        --,CASE WHEN ISNULL(S.APP_STATUS, ' ')  = 'CFT' THEN 'O' ELSE 'X' END AS APP_STATUS
        ,ISNULL(S.APP_STATUS, 'NFT') AS APP_STATUS
        ,C.SCORE_ORI
        ,C.SCORE_ORI_LIST
        ,ISNULL(C.SCORE_WEIGHT, 0)  AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_GRADE, '') AS GRADE
        ,C.GRADE_REASON
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,C.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
        ,C.KPI_REF_ID
        ,T.ESTTERM_STEP_NAME
        ,J.KPI_CLASS_REF_ID
        ,G.KPI_GROUP_REF_ID
        ,ISNULL(Z.SCORE_GRADE, ' ') AS GRADE_ORG
        ,G.KPI_POOL_REF_ID
        ,G.BASIS_USE_YN
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = D.EMP_REF_ID
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   H   ON  H.DEPT_REF_ID       = C.TGT_DEPT_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  I   ON  I.ETC_CODE  = G.KPI_GROUP_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014') K   ON  K.ETC_CODE  = J.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                L   ON  L.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                M   ON  M.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND M.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                N   ON  N.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND N.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
                                                        AND N.CATEGORY_LOW_REF_ID   = G.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  O  ON O.UNIT_TYPE_REF_ID  = F.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  P   ON  P.ESTTERM_REF_ID    = J.ESTTERM_REF_ID
                                            AND P.KPI_REF_ID        = J.KPI_REF_ID
                                            AND P.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          Q   ON  Q.ESTTERM_REF_ID    = P.ESTTERM_REF_ID
                                            AND Q.KPI_REF_ID        = P.KPI_REF_ID
                                            AND Q.KPI_TARGET_VERSION_ID = P.KPI_TARGET_VERSION_ID
                                            AND Q.YMD                   = C.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          R   ON  R.ESTTERM_REF_ID    = Q.ESTTERM_REF_ID
                                            AND R.KPI_REF_ID        = Q.KPI_REF_ID
                                            AND R.YMD               = Q.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO       S   ON  S.APP_REF_ID        = R.APP_REF_ID
                                            AND S.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U1  ON  U1.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U1.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U1.THRESHOLD_REF_ID = 1
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U2  ON  U2.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U2.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U2.THRESHOLD_REF_ID = 2
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U3  ON  U3.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U3.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U3.THRESHOLD_REF_ID = 3
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U4  ON  U4.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U4.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U4.THRESHOLD_REF_ID = 4
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U5  ON  U5.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U5.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U5.THRESHOLD_REF_ID = 5
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";
            string queryOra = @"
SELECT   F.KPI_CODE
        ,H.DEPT_NAME                AS COM_DEPT_NAME
        ,G.KPI_NAME
        ,E.EMP_NAME
        ,CASE G.KPI_GROUP_REF_ID WHEN 'QTT' THEN '계량' WHEN 'QLT' THEN '비계량' ELSE '' END AS KPI_GROUP_NAME
        ,K.CODE_NAME                AS CLASS_NAME
        ,ISNULL(L.CATEGORY_NAME, ' ') || '/' || ISNULL(M.CATEGORY_NAME, ' ')  || '/' + ISNULL(N.CATEGORY_NAME, ' ')    AS CATEGORY_NAME
        ,ISNULL(O.UNIT, '-')        AS UNIT_NAME
        ,D.WEIGHT
        ,ISNULL(Q.TARGET_TS, 0) AS TARGET_TS
        ,ISNULL(R.RESULT_TS, 0) AS RESULT_TS
        ,CASE WHEN ISNULL(Q.TARGET_TS, 0) = 0 THEN 0 ELSE ROUND(ISNULL(R.RESULT_TS / Q.TARGET_TS * 100, 0),4) END   AS ACHIEVEMENT_RATE
        ,U1.SET_MIN_VALUE   AS GRADE_S
        ,U1.SET_TXT_VALUE
        ,U2.SET_MIN_VALUE   AS GRADE_A
        ,U2.SET_TXT_VALUE
        ,U3.SET_MIN_VALUE   AS GRADE_B
        ,U3.SET_TXT_VALUE
        ,U4.SET_MIN_VALUE   AS GRADE_C
        ,U4.SET_TXT_VALUE
        ,U5.SET_MIN_VALUE   AS GRADE_D
        ,U5.SET_TXT_VALUE
        ,ISNULL(S.APP_STATUS, 'NFT') AS APP_STATUS
        ,C.SCORE_ORI
        ,C.SCORE_ORI_LIST
        ,ISNULL(C.SCORE_WEIGHT, 0)  AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_GRADE, ' ') AS GRADE
        ,C.GRADE_REASON
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,C.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
        ,C.KPI_REF_ID
        ,T.ESTTERM_STEP_NAME
        ,J.KPI_CLASS_REF_ID
        ,G.KPI_GROUP_REF_ID
        ,ISNULL(Z.SCORE_GRADE, ' ') AS GRADE_ORG
        ,G.KPI_POOL_REF_ID
        ,G.BASIS_USE_YN
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = D.EMP_REF_ID
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   H   ON  H.DEPT_REF_ID       = C.TGT_DEPT_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME 
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS009')  I   ON  I.ETC_CODE  = G.KPI_GROUP_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
LEFT OUTER JOIN (   SELECT ETC_CODE, CODE_NAME
                    FROM COM_CODE_INFO 
                    WHERE CATEGORY_CODE = 'BS0014') K   ON  K.ETC_CODE  = J.KPI_CLASS_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_TOP                L   ON  L.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_MID                M   ON  M.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND M.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
LEFT OUTER JOIN BSC_KPI_CATEGORY_LOW                N   ON  N.CATEGORY_TOP_REF_ID   = G.CATEGORY_TOP_REF_ID
                                                        AND N.CATEGORY_MID_REF_ID   = G.CATEGORY_MID_REF_ID
                                                        AND N.CATEGORY_LOW_REF_ID   = G.CATEGORY_LOW_REF_ID
LEFT OUTER JOIN COM_UNIT_TYPE_INFO  O  ON O.UNIT_TYPE_REF_ID  = F.UNIT_TYPE_REF_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  P   ON  P.ESTTERM_REF_ID    = J.ESTTERM_REF_ID
                                            AND P.KPI_REF_ID        = J.KPI_REF_ID
                                            AND P.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          Q   ON  Q.ESTTERM_REF_ID    = P.ESTTERM_REF_ID
                                            AND Q.KPI_REF_ID        = P.KPI_REF_ID
                                            AND Q.KPI_TARGET_VERSION_ID = P.KPI_TARGET_VERSION_ID
                                            AND Q.YMD                   = C.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          R   ON  R.ESTTERM_REF_ID    = Q.ESTTERM_REF_ID
                                            AND R.KPI_REF_ID        = Q.KPI_REF_ID
                                            AND R.YMD               = Q.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO       S   ON  S.APP_REF_ID        = R.APP_REF_ID
                                            AND S.ACTIVE_YN    = 'Y'
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U1  ON  U1.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U1.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U1.THRESHOLD_REF_ID = 1
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U2  ON  U2.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U2.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U2.THRESHOLD_REF_ID = 2
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U3  ON  U3.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U3.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U3.THRESHOLD_REF_ID = 3
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U4  ON  U4.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U4.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U4.THRESHOLD_REF_ID = 4
LEFT OUTER JOIN BSC_KPI_THRESHOLD_INFO  U5  ON  U5.ESTTERM_REF_ID   = J.ESTTERM_REF_ID
                                            AND U5.KPI_REF_ID       = J.KPI_REF_ID
                                            AND U5.THRESHOLD_REF_ID = 5
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";
            //평가데이터
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE0", null, paramArray, CommandType.Text);

            //[1]평가상태
            query = @"
SELECT  TOP 1 A.REPORT, A.REPORT_FILE, A.STATUS, ISNULL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            queryOra = @"
SELECT  A.REPORT, A.REPORT_FILE, A.STATUS, ISNULL(B.STATUS, 'X') AS EST_STATUS
FROM    BSC_MBO_KPI_REPORT  A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    B   ON  B.COMP_ID   = A.COMP_ID
                                            AND B.EST_ID    = A.EST_ID
                                            AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                            AND B.STATUS            <> 'N'
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND ROWNUM = 1
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE1", ds, paramArray, CommandType.Text);

            //[2] 평가마감여부
            query = @"
SELECT	C.START_DATE, C.END_DATE, ISNULL(C.STATUS_YN, 'N') AS STATUS_YN
FROM		EST_JOB_EST_MAP	A
INNER JOIN	EST_JOB_INFO	B	ON	B.EST_JOB_ID	= A.EST_JOB_ID
							AND	B.MNG_PAGE_YN	= 'N'
							AND	B.USE_YN		= 'Y'
INNER JOIN	EST_JOB_DETAIL	C	ON	C.COMP_ID		= A.COMP_ID
								AND	C.EST_ID		= A.EST_ID
								AND	C.ESTTERM_REF_ID	= @ESTTERM_REF_ID
								AND	C.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
								AND	C.EST_JOB_ID		= A.EST_JOB_ID
WHERE	A.COMP_ID		= @COMP_ID
	AND	A.EST_ID		= @EST_ID
	AND	A.EST_JOB_ID	= 'JOB_91'
";
            queryOra = @"
SELECT	C.START_DATE, C.END_DATE, ISNULL(C.STATUS_YN, 'N') AS STATUS_YN
FROM		EST_JOB_EST_MAP	A
INNER JOIN	EST_JOB_INFO	B	ON	B.EST_JOB_ID	= A.EST_JOB_ID
							AND	B.MNG_PAGE_YN	= 'N'
							AND	B.USE_YN		= 'Y'
INNER JOIN	EST_JOB_DETAIL	C	ON	C.COMP_ID		= A.COMP_ID
								AND	C.EST_ID		= A.EST_ID
								AND	C.ESTTERM_REF_ID	= @ESTTERM_REF_ID
								AND	C.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
								AND	C.EST_JOB_ID		= A.EST_JOB_ID
WHERE	A.COMP_ID		= @COMP_ID
	AND	A.EST_ID		= @EST_ID
	AND	A.EST_JOB_ID	= 'JOB_91'
";
            paramArray = null;
            paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE2", ds, paramArray, CommandType.Text);

            //[3] 모든 MBO실적 결재되었는지 확인
            query = @"
SELECT TOP 1 A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, '') = 'E'
    AND ISNULL(F.APP_STATUS, '') != 'CFT'
";
            queryOra = @"
SELECT A.ESTTERM_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
LEFT OUTER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
LEFT OUTER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_RESULT       E   ON  E.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND E.KPI_REF_ID        = C.KPI_REF_ID
                                    AND E.YMD               = C.YMD
LEFT OUTER JOIN COM_APPROVAL_INFO    F   ON  F.APP_REF_ID        = E.APP_REF_ID
                                    AND F.ACTIVE_YN         = 'Y'
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID           = @EST_DEPT_ID
    AND A.EST_EMP_ID            = @EST_EMP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
    AND ISNULL(F.APP_STATUS, ' ') != 'CFT'
    AND ROWNUM = 1
";
            paramArray = null;
            paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE3", ds, paramArray, CommandType.Text);

            //[4] 평가상태 및 코멘트
            query = @"
SELECT  A.STATUS, A.COMMENT
FROM    BSC_MBO_KPI_SCORE_MT    A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID       = @EST_DEPT_ID
    AND A.EST_EMP_ID        = @EST_EMP_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            queryOra = @"
SELECT  A.STATUS, A.COMMENT
FROM    BSC_MBO_KPI_SCORE_MT    A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.EST_DEPT_ID       = @EST_DEPT_ID
    AND A.EST_EMP_ID        = @EST_EMP_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = est_dept_id;
            paramArray[5] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_dept_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE4", ds, paramArray, CommandType.Text);

            //[5]피평가자의견(피드백)
            query = @"
SELECT  A.SEQ, A.COMMENT, A.CONFIRM_TYPE
FROM EST_QUESTION_COMMENT   A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.SEQ               = ( SELECT MAX(SEQ) FROM EST_QUESTION_COMMENT
                                WHERE   COMP_ID           = @COMP_ID
                                    AND EST_ID            = @EST_ID
                                    AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                    AND TGT_DEPT_ID       = @TGT_DEPT_ID
                                    AND TGT_EMP_ID        = @TGT_EMP_ID)
";
            queryOra = @"
SELECT  A.SEQ, A.COMMENT, A.CONFIRM_TYPE
FROM EST_QUESTION_COMMENT   A
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.SEQ               = ( SELECT MAX(SEQ) FROM EST_QUESTION_COMMENT
                                WHERE   COMP_ID           = @COMP_ID
                                    AND EST_ID            = @EST_ID
                                    AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                                    AND TGT_DEPT_ID       = @TGT_DEPT_ID
                                    AND TGT_EMP_ID        = @TGT_EMP_ID)
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, queryOra), "DATATABLE5", ds, paramArray, CommandType.Text);

            //[6]현재평가가 아닌놈 가져와서 뿌리기 (평가자로 볼때)
            query = @"
SELECT   A.ESTTERM_STEP_ID
        ,A.STATUS
        ,B.ESTTERM_STEP_NAME
        ,C.STATUS_NAME
FROM            BSC_MBO_KPI_SCORE_MT    A
LEFT OUTER JOIN EST_TERM_STEP           B   ON  B.COMP_ID           = A.COMP_ID
                                            AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN EST_STATUS              C   ON  C.STATUS_STYLE_ID   = '0003'
                                            AND C.STATUS_ID         = A.STATUS
WHERE   A.COMP_ID           = @COMP_ID
    AND A.EST_ID            = @EST_ID
    AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID       = @TGT_DEPT_ID
    AND A.TGT_EMP_ID        = @TGT_EMP_ID
    AND A.ESTTERM_STEP_ID   > 1
ORDER BY A.ESTTERM_STEP_ID
";
            paramArray = null;
            paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_dept_id;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, query), "DATATABLE6", ds, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //[7]이전차수 평가정보보기
                query = @"
SELECT   C.ESTTERM_STEP_ID
        ,T.ESTTERM_STEP_NAME
        ,C.KPI_REF_ID
        ,ISNULL(C.SCORE_WEIGHT, 0) AS SCORE_WEIGHT
        ,ISNULL(C.SCORE_ORI, 0) AS SCORE_ORI
        ,ISNULL(C.SCORE_GRADE, '') AS GRADE
        ,ISNULL(COM.CODE_NAME, '평가중') AS GRADE_NAME
        ,G.KPI_GROUP_REF_ID
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_WEIGHT   D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND D.EMP_REF_ID        = C.TGT_EMP_ID
                                    AND D.KPI_REF_ID        = C.KPI_REF_ID
                                    AND D.USE_YN            = 'Y'
INNER JOIN BSC_KPI_INFO         F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                    AND F.KPI_REF_ID        = D.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    G   ON  G.KPI_POOL_REF_ID   = F.KPI_POOL_REF_ID
INNER JOIN BSC_MBO_KPI_CLASSIFICATION   J   ON  J.ESTTERM_REF_ID        = D.ESTTERM_REF_ID
                                            AND J.KPI_REF_ID            = D.KPI_REF_ID
                                            AND J.EMP_REF_ID            = D.EMP_REF_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT Z   ON  Z.COMP_ID           = C.COMP_ID
                                    AND Z.EST_ID            = C.EST_ID
                                    AND Z.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                    AND Z.ESTTERM_SUB_ID    = C.ESTTERM_SUB_ID
                                    AND Z.ESTTERM_STEP_ID   = 2
                                    AND Z.YMD               = C.YMD
                                    AND Z.TGT_EMP_ID        = C.TGT_EMP_ID
                                    AND Z.TGT_DEPT_ID       = C.TGT_DEPT_ID
                                    AND Z.KPI_REF_ID        = C.KPI_REF_ID
LEFT OUTER JOIN EST_TERM_STEP           T   ON  T.COMP_ID           = A.COMP_ID
                                            AND T.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
LEFT OUTER JOIN COM_CODE_INFO   COM ON COM.CATEGORY_CODE = 'BS015' AND COM.USE_YN = 'Y' AND COM.ETC_CODE = C.SCORE_GRADE
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID < @PREESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
    AND ISNULL(A.STATUS_ID, ' ') = 'E'
ORDER BY C.ESTTERM_STEP_ID DESC, G.KPI_GROUP_REF_ID DESC, F.KPI_CODE ASC
";

                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;
                paramArray[6] = CreateDataParameter("@PREESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[6].Value = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["ESTTERM_STEP_ID"]);

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE7", ds, paramArray, CommandType.Text);

                //[8]현재차수까지의 평가의견
                query = @"
SELECT A.ESTTERM_STEP_ID, ISNULL(A.COMMENT, '') AS    COMMENT   
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1 AND A.ESTTERM_STEP_ID <= @ESTTERM_STEP_ID
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
ORDER BY A.ESTTERM_STEP_ID
";

                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;
                paramArray[6] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                paramArray[6].Value = DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["ESTTERM_STEP_ID"]);

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE8", ds, paramArray, CommandType.Text);

                //[9]모든차수의 평가자사번
                query = @"
SELECT A.ESTTERM_STEP_ID, A.EST_EMP_ID
FROM BSC_MBO_KPI_SCORE_MT A
WHERE A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID > 1
    AND A.TGT_DEPT_ID           = @TGT_DEPT_ID
    AND A.TGT_EMP_ID            = @TGT_EMP_ID
ORDER BY A.ESTTERM_STEP_ID
";
                paramArray = null;
                paramArray = CreateDataParameters(6);

                paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                paramArray[0].Value = comp_id;
                paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                paramArray[1].Value = est_id;
                paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[2].Value = estterm_ref_id;
                paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                paramArray[3].Value = estterm_sub_id;
                paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
                paramArray[4].Value = tgt_dept_id;
                paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
                paramArray[5].Value = tgt_emp_id;

                ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATATABLE9", ds, paramArray, CommandType.Text);

            }
            return ds;
        }



        public DataSet Select_3A(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int usertype
                                    , int emp_ref_id)
        {
            string queryAdd = string.Empty;
            if (usertype == 1) //평가자 기준
            {
                queryAdd = @"
    AND A.EST_EMP_ID    = @EMP_REF_ID";
            }
            else if (usertype == 2) //피평가자 기준
            {
                queryAdd = @"
    AND A.TGT_DEPT_ID IN (SELECT DEPT_REF_ID FROM REL_DEPT_EMP
                                             WHERE REL_STATUS    = 1
                                               AND (EMP_REF_ID    = @EMP_REF_ID   OR   @EMP_REF_ID   = 0) )";

            }
            else //관리자 및 성과평가 관리자 기준
            {
                queryAdd = @"
    AND (A.TGT_DEPT_ID = @EMP_REF_ID OR @EMP_REF_ID = 0)";
            }



            string query = @"
SELECT   D.EMP_NAME                     AS EST_EMP_NAME
        ,F.DEPT_NAME                    AS EST_DEPT_NAME
        ,H.ESTTERM_STEP_NAME            AS EST_STEP_NAME
        ,E.EMP_NAME                     AS TGT_EMP_NAME
        ,G.DEPT_NAME                    AS TGT_DEPT_NAME
        ,ISNULL(COUNT(C.KPI_REF_ID), 0) AS EST_KPI_COUNT
        ,ISNULL(SUM(CASE WHEN C.STATUS = 'N' THEN 1 ELSE 0 END), 0) AS STATUS_N
        ,ISNULL(SUM(CASE WHEN C.STATUS = 'O' THEN 1 ELSE 0 END), 0) AS STATUS_P
        ,ISNULL(SUM(CASE WHEN C.STATUS = 'C' THEN 1 ELSE 0 END), 0) AS STATUS_E
        ,CASE B.STATUS  WHEN 'P' THEN '피드백중'
                        WHEN 'E' THEN '피드백완료'
                        ELSE '미진행' END AS FEEDBACK_NAME
        ,CASE WHEN B.STATUS = 'E' THEN 'Y' ELSE 'N' END AS COMPLETE_YN
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,B.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
FROM    EST_EMP_EST_TARGET_MAP  A
INNER JOIN REL_DEPT_EMP         AA  ON  AA.EMP_REF_ID       = A.EST_EMP_ID
                                    AND AA.REL_STATUS       = 1
--INNER JOIN REL_DEPT_EMP         AAA ON  AAA.EMP_REF_ID       = A.TGT_EMP_ID
--                                    AND AAA.REL_STATUS       = 1
INNER JOIN BSC_MBO_KPI_SCORE_MT B   ON  B.COMP_ID           = A.COMP_ID
                                    AND B.EST_ID            = A.EST_ID
                                    AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                    AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                    AND B.EST_EMP_ID        = A.EST_EMP_ID
                                    AND B.EST_DEPT_ID       = A.EST_DEPT_ID
                                    AND B.TGT_EMP_ID        = A.TGT_EMP_ID
                                    AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
INNER JOIN BSC_MBO_KPI_SCORE_DT C   ON  C.COMP_ID           = B.COMP_ID
                                    AND C.EST_ID            = B.EST_ID
                                    AND C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.ESTTERM_SUB_ID    = B.ESTTERM_SUB_ID
                                    AND C.ESTTERM_STEP_ID   = B.ESTTERM_STEP_ID
                                    AND C.YMD               = B.YMD
                                    AND C.EST_EMP_ID        = B.EST_EMP_ID
                                    AND C.EST_DEPT_ID       = B.EST_DEPT_ID
                                    AND C.TGT_EMP_ID        = B.TGT_EMP_ID
                                    AND C.TGT_DEPT_ID       = B.TGT_DEPT_ID
LEFT OUTER JOIN COM_EMP_INFO    D   ON  D.EMP_REF_ID        = A.EST_EMP_ID
LEFT OUTER JOIN COM_EMP_INFO    E   ON  E.EMP_REF_ID        = A.TGT_EMP_ID
LEFT OUTER JOIN COM_DEPT_INFO   F   ON  F.DEPT_REF_ID       = A.EST_DEPT_ID
LEFT OUTER JOIN COM_DEPT_INFO   G   ON  G.DEPT_REF_ID       = A.TGT_DEPT_ID
LEFT OUTER JOIN EST_TERM_STEP   H   ON  H.COMP_ID           = A.COMP_ID
                                    AND H.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
{0}
    AND ISNULL(A.STATUS_ID, '') = 'E'
GROUP BY D.EMP_NAME                     
        ,F.DEPT_NAME                    
        ,H.ESTTERM_STEP_NAME            
        ,E.EMP_NAME                     
        ,G.DEPT_NAME                    
        ,CASE B.STATUS  WHEN 'P' THEN '피드백중'
                        WHEN 'E' THEN '피드백완료'
                        ELSE '미진행' END 
        ,CASE WHEN B.STATUS = 'E' THEN 'Y' ELSE 'N' END 
        ,A.COMP_ID
        ,A.EST_ID
        ,A.ESTTERM_REF_ID
        ,A.ESTTERM_SUB_ID
        ,A.ESTTERM_STEP_ID
        ,B.YMD
        ,A.EST_EMP_ID
        ,A.EST_DEPT_ID
        ,A.TGT_EMP_ID
        ,A.TGT_DEPT_ID
";

            query = string.Format(query, queryAdd);

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataTable SelectSumFor3A(  object comp_id
                                        , object est_id
                                        , object estterm_ref_id
                                        , object estterm_sub_id
                                        , object est_emp_id
                                        , object tgt_emp_id)
        {
            
            string    query = @"
SELECT   ISNULL(SUM(CASE WHEN ISNULL(C.STATUS, 'N') IN ('C', 'P', 'E') THEN 1 ELSE 0 END), 0) AS COMPLETE_Y
,ISNULL(SUM(CASE WHEN ISNULL(C.STATUS, 'N') IN ('C') THEN 1 ELSE 0 END), 0) AS COMPLETE_C
,ISNULL(SUM(CASE WHEN ISNULL(C.STATUS, 'N') IN ('E') THEN 1 ELSE 0 END), 0) AS COMPLETE_E
,ISNULL(SUM(CASE WHEN ISNULL(C.STATUS, 'N') IN ('P') THEN 1 ELSE 0 END), 0) AS COMPLETE_P
	    ,COUNT(ISNULL(C.STATUS, 'N')) AS TOTAL_CNT
FROM    EST_EMP_EST_TARGET_MAP          A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT    C    ON    C.COMP_ID           = A.COMP_ID
                                            AND    C.EST_ID            = A.EST_ID
                                            AND    C.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                            AND    C.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                                            AND    C.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                                            AND    C.EST_DEPT_ID       = A.EST_DEPT_ID
                                            AND    C.EST_EMP_ID        = A.EST_EMP_ID
                                            AND    C.TGT_DEPT_ID       = A.TGT_DEPT_ID
                                            AND    C.TGT_EMP_ID        = A.TGT_EMP_ID
WHERE   A.COMP_ID               = @COMP_ID
    AND A.EST_ID                = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND (A.EST_EMP_ID           = @EST_EMP_ID         OR    @EST_EMP_ID    =  0)
    AND A.TGT_DEPT_ID IN (SELECT DEPT_REF_ID FROM REL_DEPT_EMP
                                             WHERE DEPT_REF_ID   = A.TGT_DEPT_ID
                                               AND REL_STATUS    = 1
                                               AND (EMP_REF_ID    = @TGT_EMP_ID   OR   @TGT_EMP_ID   = 0)
                        )
    --AND ISNULL(A.STATUS_ID, '') = 'E'
";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = est_emp_id;
            paramArray[5]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(query, GetQueryStringReplace(query)), "DATAGET0", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }


        public DataTable SelectSumFor3ATgtReport(  object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object emp_ref_id)
        {

            string query = @"
SELECT   SUM(CASE WHEN ISNULL(A.STATUS, 'N') = 'C' THEN 1 ELSE 0 END) AS COMPLETE_Y
        ,COUNT(ISNULL(A.STATUS, 'N')) AS TOTAL_CNT
FROM        BSC_MBO_KPI_REPORT  A
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID IN ( SELECT DEPT_REF_ID FROM REL_DEPT_EMP
                                             WHERE DEPT_REF_ID   = A.TGT_DEPT_ID
                                               AND REL_STATUS    = 1
                                               AND (EMP_REF_ID    = @EMP_REF_ID   OR   @EMP_REF_ID   = 0)
                                              ) 
    
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query,  "DATAGET0", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }


        public DataTable SelectSumFor3ATgtFeedBack(  object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object emp_ref_id)
        {

            string query = @"


--내가 피드백해야할 건수
SELECT   SUM(CASE WHEN ISNULL(C.STATUS, 'N') = 'E' THEN 1 ELSE 0 END) AS COMPLETE_Y
	    ,COUNT(ISNULL(C.STATUS, 'N')) AS TOTAL_CNT
FROM    EST_EMP_EST_TARGET_MAP          A
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_MT	C	ON	C.COMP_ID	= A.COMP_ID
											AND	C.EST_ID	= A.EST_ID
											AND	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
											AND	C.ESTTERM_SUB_ID	= A.ESTTERM_SUB_ID
											AND	C.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID
											AND	C.EST_DEPT_ID		= A.EST_DEPT_ID
											AND	C.EST_EMP_ID		= A.EST_EMP_ID
											AND	C.TGT_DEPT_ID		= A.TGT_DEPT_ID
											AND	C.TGT_EMP_ID		= A.TGT_EMP_ID
WHERE   A.COMP_ID   = @COMP_ID
    AND A.EST_ID    = @EST_ID
    AND A.ESTTERM_REF_ID        = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID        = @ESTTERM_SUB_ID
    AND A.TGT_DEPT_ID IN ( SELECT DEPT_REF_ID FROM REL_DEPT_EMP
                                             WHERE DEPT_REF_ID   = A.TGT_DEPT_ID
                                               AND REL_STATUS    = 1
                                               AND (EMP_REF_ID    = @EMP_REF_ID   OR   @EMP_REF_ID   = 0)
                                              ) 
    AND ISNULL(A.STATUS_ID, '') = 'E'
    AND A.ESTTERM_STEP_ID		= (
		SELECT MAX(ESTTERM_STEP_ID) 
		FROM EST_EMP_EST_TARGET_MAP 
		WHERE	COMP_ID	                = @COMP_ID
			AND	EST_ID	                = @EST_ID
			AND	ESTTERM_REF_ID	        = @ESTTERM_REF_ID
			AND	ESTTERM_SUB_ID	        = @ESTTERM_SUB_ID
			AND A.TGT_DEPT_ID IN ( SELECT DEPT_REF_ID FROM REL_DEPT_EMP
                                             WHERE DEPT_REF_ID   = A.TGT_DEPT_ID
                                               AND REL_STATUS    = 1
                                               AND (EMP_REF_ID    = @EMP_REF_ID   OR   @EMP_REF_ID   = 0)
                                              ) 
			AND	ISNULL(A.STATUS_ID, '')	= 'E')

                                 
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET0", null, paramArray, CommandType.Text);
            return ds.Tables[0];
        }

        public DataSet SelectForDeptEst_DB(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_emp_id)
        {
            string query = @"

SELECT A.COMP_ID
    , A.EST_ID
    , A.ESTTERM_REF_ID
    , A.ESTTERM_SUB_ID
    , ESUB.ESTTERM_SUB_NAME
    , A.ESTTERM_STEP_ID
    , ESTEP.ESTTERM_STEP_NAME
    , A.EST_DEPT_ID
    , B.DEPT_NAME                     AS     EST_DEPT_NAME
    , A.EST_EMP_ID
    , C.EMP_NAME                      AS     EST_EMP_NAME
    , A.TGT_DEPT_ID
    , D.DEPT_NAME                     AS     TGT_DEPT_NAME      --   '평가조직'
    , ISNULL(BK1.KPI_TOT_CNT, 0)      AS     EST_KPI_TOTAL      -- '전체 KPI 수'
    , ISNULL(BK2.KPI_TGT_CNT,0)       AS     EST_KPI_COUNT      --'평가대상 KPI 수'
    , E1.STATUS_ID
    , E2.STATUS_NAME             -- AS                   '평가상태'
FROM EST_EMP_EST_TARGET_MAP A
   LEFT JOIN EST_TERM_SUB ESUB 
     ON A.COMP_ID = @COMP_ID AND A.ESTTERM_SUB_ID = ESUB.ESTTERM_SUB_ID
   LEFT JOIN EST_TERM_STEP ESTEP
     ON A.COMP_ID = @COMP_ID AND A.ESTTERM_STEP_ID = ESTEP.ESTTERM_STEP_ID
   INNER JOIN COM_DEPT_INFO B   ON A.EST_DEPT_ID = B.DEPT_REF_ID  AND B.DEPT_FLAG = 1
   INNER JOIN COM_EMP_INFO C    ON A.EST_EMP_ID = C.EMP_REF_ID    AND C.EMP_REF_ID IN ( SELECT EMP_REF_ID FROM REL_DEPT_EMP WHERE REL_STATUS = 1)
   LEFT JOIN EST_DEPT_INFO D    ON A.ESTTERM_REF_ID = D.ESTTERM_REF_ID   AND A.TGT_DEPT_ID = D.EST_DEPT_REF_ID
   LEFT JOIN (
                SELECT EST_DEPT_REF_ID, COUNT(KPI_REF_ID)  AS KPI_TOT_CNT 
                  FROM BSC_MAP_KPI
                 WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
                 GROUP BY EST_DEPT_REF_ID
             ) BK1 ON D.EST_DEPT_REF_ID = BK1.EST_DEPT_REF_ID 
   LEFT JOIN (
                SELECT EST_DEPT_REF_ID, COUNT(KPI_REF_ID)  AS KPI_TGT_CNT 
                  FROM BSC_MAP_KPI
                 WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
                   AND KPI_REF_ID IN ( SELECT KPI_REF_ID FROM BSC_KPI_INFO 
                                        WHERE KPI_POOL_REF_ID IN (SELECT KPI_POOL_REF_ID FROM BSC_KPI_POOL WHERE BASIS_USE_YN = 'EQL') 
                                          AND ESTTERM_REF_ID = @ESTTERM_REF_ID )
                 GROUP BY EST_DEPT_REF_ID
             ) BK2 ON D.EST_DEPT_REF_ID = BK2.EST_DEPT_REF_ID
   LEFT JOIN EST_DATA E1
     ON E1.COMP_ID = @COMP_ID
     AND E1.ESTTERM_REF_ID = @ESTTERM_REF_ID AND E1.ESTTERM_SUB_ID = @ESTTERM_SUB_ID
     AND E1.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID AND E1.EST_ID = @EST_ID
     AND A.EST_EMP_ID = E1.EST_EMP_ID AND A.TGT_DEPT_ID = E1.TGT_DEPT_ID   
   LEFT JOIN EST_STATUS E2
     ON E2.STATUS_STYLE_ID IN ( SELECT STATUS_STYLE_ID FROM EST_INFO WHERE EST_ID = @EST_ID)
     AND E1.STATUS_ID = E2.STATUS_ID                                 
WHERE A.COMP_ID         = @COMP_ID
AND A.EST_ID            = @EST_ID  
AND A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
AND A.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
AND A.ESTTERM_STEP_ID   > @ESTTERM_STEP_ID
AND (A.EST_EMP_ID        = @EST_EMP_ID            OR      @EST_EMP_ID    =   0)

                     ";


            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "EMPESTTARGETMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet Select_DB(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , OwnerType ownerType)
        {
            string query = @"SELECT	 TM.COMP_ID
                                    ,TM.EST_ID
	                                ,TM.ESTTERM_REF_ID
	                                ,TM.ESTTERM_SUB_ID
	                                ,TM.ESTTERM_STEP_ID
                                    ,ET.ESTTERM_STEP_NAME
	                                ,TM.EST_DEPT_ID
                                    ,ED1.DEPT_NAME              AS EST_DEPT_NAME
	                                ,TM.EST_EMP_ID
                                    ,CE1.EMP_NAME               AS EST_EMP_NAME
                                    ,CE1.POSITION_CLASS_CODE    AS EST_POS_CLS_ID
                                    ,PC.POS_CLS_NAME            AS EST_POS_CLS_NAME
		                            ,CE1.POSITION_DUTY_CODE     AS EST_POS_DUT_ID
                                    ,PD.POS_DUT_NAME            AS EST_POS_DUT_NAME
		                            ,CE1.POSITION_GRP_CODE      AS EST_POS_GRP_ID
                                    ,PG.POS_GRP_NAME            AS EST_POS_GRP_NAME
		                            ,CE1.POSITION_RANK_CODE     AS EST_POS_RNK_ID
		                            ,PR.POS_RNK_NAME            AS EST_POS_RNK_NAME
                                    ,CE1.POSITION_KIND_CODE     AS EST_POS_KND_ID
		                            ,PK.POS_KND_NAME            AS EST_POS_KND_NAME
	                                ,TM.TGT_DEPT_ID
                                    ,ED2.DEPT_NAME              AS TGT_DEPT_NAME
	                                ,TM.TGT_EMP_ID
                                    ,CE2.EMP_NAME               AS TGT_EMP_NAME
                                    ,TM.TGT_POS_CLS_ID
                                    ,TM.TGT_POS_CLS_NAME
		                            ,TM.TGT_POS_DUT_ID
                                    ,TM.TGT_POS_DUT_NAME
		                            ,TM.TGT_POS_GRP_ID
                                    ,TM.TGT_POS_GRP_NAME
		                            ,TM.TGT_POS_RNK_ID
		                            ,TM.TGT_POS_RNK_NAME
                                    ,TM.TGT_POS_KND_ID
		                            ,TM.TGT_POS_KND_NAME
                                    ,TM.DIRECTION_TYPE
                                    ,EM.FIXED_WEIGHT_YN
	                                ,TM.STATUS_ID
	                                ,TM.CREATE_DATE
	                                ,TM.CREATE_USER
	                                ,TM.UPDATE_DATE
	                                ,TM.UPDATE_USER
                                FROM	            EST_EMP_EST_TARGET_MAP TM
                                    LEFT OUTER JOIN COM_DEPT_INFO          ED1      ON (TM.EST_DEPT_ID          = ED1.DEPT_REF_ID)
                                    LEFT OUTER JOIN COM_DEPT_INFO          ED2      ON (TM.TGT_DEPT_ID          = ED2.DEPT_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO           CE1      ON (TM.EST_EMP_ID           = CE1.EMP_REF_ID)
                                    LEFT OUTER JOIN COM_EMP_INFO           CE2      ON (TM.TGT_EMP_ID           = CE2.EMP_REF_ID)
                                    LEFT OUTER JOIN	EST_POSITION_CLS	   PC       ON (CE1.POSITION_CLASS_CODE	= PC.POS_CLS_ID)
		                            LEFT OUTER JOIN	EST_POSITION_DUT	   PD       ON (CE1.POSITION_DUTY_CODE	= PD.POS_DUT_ID)
		                            LEFT OUTER JOIN	EST_POSITION_GRP	   PG       ON (CE1.POSITION_GRP_CODE	= PG.POS_GRP_ID)
		                            LEFT OUTER JOIN	EST_POSITION_RNK	   PR       ON (CE1.POSITION_RANK_CODE	= PR.POS_RNK_ID)
                                    LEFT OUTER JOIN	EST_POSITION_KND	   PK       ON (CE1.POSITION_KIND_CODE	= PK.POS_KND_ID)
                                    JOIN            EST_TERM_STEP          ET       ON (TM.COMP_ID              = ET.COMP_ID
                                                                                    AND TM.ESTTERM_STEP_ID      = ET.ESTTERM_STEP_ID)
                                    JOIN    EST_TERM_STEP_EST_MAP          EM       ON (TM.COMP_ID              = EM.COMP_ID
                                                                                    AND TM.EST_ID               = EM.EST_ID
                                                                                    AND TM.ESTTERM_STEP_ID      = EM.ESTTERM_STEP_ID)
                                WHERE	(TM.COMP_ID         = @COMP_ID              OR @COMP_ID                 = 0)
                                    AND (TM.EST_ID          = @EST_ID               OR @EST_ID                      =''    )
                                    AND	(TM.ESTTERM_REF_ID  = @ESTTERM_REF_ID       OR @ESTTERM_REF_ID          = 0)
                                    AND	(TM.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID       OR @ESTTERM_SUB_ID          = 0)
                                    AND	(TM.ESTTERM_STEP_ID = @ESTTERM_STEP_ID      OR @ESTTERM_STEP_ID         = 0)
                                    AND	(TM.EST_DEPT_ID     = @EST_DEPT_ID          OR @EST_DEPT_ID             = 0)
                                    AND	(TM.EST_EMP_ID      = @EST_EMP_ID           OR @EST_EMP_ID              = 0)
                                    AND	(TM.TGT_DEPT_ID     = @TGT_DEPT_ID          OR @TGT_DEPT_ID             = 0)
                                    AND	(TM.TGT_EMP_ID      = @TGT_EMP_ID           OR @TGT_EMP_ID              = 0)";

            if(ownerType == OwnerType.Dept)
            {
                query += @" AND TM.TGT_EMP_ID < 0";
            }
            else if(ownerType == OwnerType.Emp_User)
            {
                query += @" AND TM.TGT_EMP_ID > 0";
            }

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "EMPESTTARGETMAPGET", null, paramArray, CommandType.Text);
            return ds;
        }

         
        public DataTable Select_DB(object comp_id
                                , object estterm_ref_id  
                                , object estterm_sub_id   
                                , object estterm_step_id      
                                , object est_id
                                , object tgt_ref_id)
        {
            string query = @"

SELECT 
 COMP_ID   
,EST_ID    
,ESTTERM_REF_ID  
,ESTTERM_SUB_ID   
,ESTTERM_STEP_ID      
,EST_DEPT_ID   
,EST_EMP_ID     
,TGT_DEPT_ID  
,TGT_EMP_ID  
,TGT_POS_CLS_ID   
,TGT_POS_CLS_NAME   
,TGT_POS_DUT_ID    
,TGT_POS_DUT_NAME    
,TGT_POS_GRP_ID   
,TGT_POS_GRP_NAME   
,TGT_POS_RNK_ID    
,TGT_POS_RNK_NAME  
,TGT_POS_KND_ID   
,TGT_POS_KND_NAME  
,DIRECTION_TYPE  
,STATUS_ID    
FROM EST_EMP_EST_TARGET_MAP 
WHERE (COMP_ID         = @COMP_ID             OR    @COMP_ID           =   0 )
  AND (ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR    @ESTTERM_REF_ID    =   0 )
  AND (ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR    @ESTTERM_SUB_ID    =   0 )
  AND (ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR    @ESTTERM_STEP_ID   =   0 )
  AND (EST_ID          = @EST_ID              OR    @EST_ID            =''   )
  AND (TGT_EMP_ID      = @EMP_REF_ID          OR    @EMP_REF_ID        =   0 )

";

	        IDbDataParameter[] paramArray = CreateDataParameters(6);
         
	        paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_step_id;
            paramArray[4]       = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[4].Value = est_id;
            paramArray[5]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_ref_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_EMP_EST_TARGET_MAP", null, paramArray, CommandType.Text).Tables[0];
	        return dt;
        }

        public int Delete_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object tgt_emp_id)
        {
            string query = @"DELETE	EST_EMP_EST_TARGET_MAP
                                WHERE	(COMP_ID         = @COMP_ID             OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID              )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0)
                                    AND	(TGT_EMP_ID      = @TGT_EMP_ID          OR @TGT_EMP_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_emp_id
                        , object tgt_emp_id)
        {
            string query = @"DELETE	EST_EMP_EST_TARGET_MAP
                                WHERE	(COMP_ID         = @COMP_ID             OR @COMP_ID         = 0)
                                    AND (EST_ID          = @EST_ID              )
                                    AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0)
                                    AND	(EST_EMP_ID      = @EST_EMP_ID          OR @EST_EMP_ID      = 0) 
                                    AND	(TGT_EMP_ID      = @TGT_EMP_ID          OR @TGT_EMP_ID      = 0) ";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = est_emp_id;
            paramArray[6]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert_DB(IDbConnection conn
                            , IDbTransaction trx
                            , object comp_id
                            , object est_id
                            , object estterm_ref_id
                            , object estterm_sub_id
                            , object estterm_step_id
                            , object est_dept_id
                          , object est_emp_id
                          , object tgt_dept_id
                          , object tgt_emp_id
                          , object tgt_pos_cls_id
                          , object tgt_pos_cls_name
                          , object tgt_pos_dut_id
                          , object tgt_pos_dut_name
                          , object tgt_pos_grp_id
                          , object tgt_pos_grp_name
                          , object tgt_pos_rnk_id
                          , object tgt_pos_rnk_name
                          , object tgt_pos_knd_id
                          , object tgt_pos_knd_name
                          , object direction_type
                          , object status_id 
                          , object create_date
                          , object create_user)
        {
            string query = @"

INSERT INTO EST_EMP_EST_TARGET_MAP
(      COMP_ID
      ,EST_ID
      ,ESTTERM_REF_ID
      ,ESTTERM_SUB_ID
      ,ESTTERM_STEP_ID
      ,EST_DEPT_ID
      ,EST_EMP_ID
      ,TGT_DEPT_ID
      ,TGT_EMP_ID
      ,TGT_POS_CLS_ID
      ,TGT_POS_CLS_NAME
      ,TGT_POS_DUT_ID
      ,TGT_POS_DUT_NAME
      ,TGT_POS_GRP_ID
      ,TGT_POS_GRP_NAME
      ,TGT_POS_RNK_ID
      ,TGT_POS_RNK_NAME
      ,TGT_POS_KND_ID
      ,TGT_POS_KND_NAME
      ,DIRECTION_TYPE
      ,STATUS_ID 
      ,CREATE_DATE
      ,CREATE_USER
)
VALUES
(      @COMP_ID
      ,@EST_ID
      ,@ESTTERM_REF_ID
      ,@ESTTERM_SUB_ID
      ,@ESTTERM_STEP_ID
      ,@EST_DEPT_ID
      ,@EST_EMP_ID
      ,@TGT_DEPT_ID
      ,@TGT_EMP_ID
      ,@TGT_POS_CLS_ID
      ,@TGT_POS_CLS_NAME
      ,@TGT_POS_DUT_ID
      ,@TGT_POS_DUT_NAME
      ,@TGT_POS_GRP_ID
      ,@TGT_POS_GRP_NAME
      ,@TGT_POS_RNK_ID
      ,@TGT_POS_RNK_NAME
      ,@TGT_POS_KND_ID
      ,@TGT_POS_KND_NAME
      ,@DIRECTION_TYPE
      ,@STATUS_ID 
      ,@CREATE_DATE
      ,@CREATE_USER
)
";

            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@TGT_POS_CLS_ID", SqlDbType.Int);
            paramArray[9].Value = tgt_pos_cls_id;
            paramArray[10] = CreateDataParameter("@TGT_POS_CLS_NAME", SqlDbType.VarChar);
            paramArray[10].Value = tgt_pos_cls_name;
            paramArray[11] = CreateDataParameter("@TGT_POS_DUT_ID", SqlDbType.Int);
            paramArray[11].Value = tgt_pos_dut_id;
            paramArray[12] = CreateDataParameter("@TGT_POS_DUT_NAME", SqlDbType.VarChar);
            paramArray[12].Value = tgt_pos_dut_name;
            paramArray[13] = CreateDataParameter("@TGT_POS_GRP_ID", SqlDbType.Int);
            paramArray[13].Value = tgt_pos_grp_id;
            paramArray[14] = CreateDataParameter("@TGT_POS_GRP_NAME", SqlDbType.VarChar);
            paramArray[14].Value = tgt_pos_grp_name;
            paramArray[15] = CreateDataParameter("@TGT_POS_RNK_ID", SqlDbType.Int);
            paramArray[15].Value = tgt_pos_rnk_id;
            paramArray[16] = CreateDataParameter("@TGT_POS_RNK_NAME", SqlDbType.VarChar);
            paramArray[16].Value = tgt_pos_rnk_name;
            paramArray[17] = CreateDataParameter("@TGT_POS_KND_ID", SqlDbType.Int);
            paramArray[17].Value = tgt_pos_knd_id;
            paramArray[18] = CreateDataParameter("@TGT_POS_KND_NAME", SqlDbType.VarChar);
            paramArray[18].Value = tgt_pos_knd_name;
            paramArray[19] = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.VarChar);
            paramArray[19].Value = direction_type;
            paramArray[20] = CreateDataParameter("@STATUS_ID", SqlDbType.NChar);
            paramArray[20].Value = status_id;
            paramArray[21] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[21].Value = create_date;
            paramArray[22] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[22].Value = create_user;


            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 데이터 테이블의 EMP_REF_ID컬럼에 포함된 값을 모두 삭제
        /// </summary>
        public int Delete_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , DataTable DT_tgt_emp_id
                        , object status_id)
        {
            StringBuilder tgt_emp_list = new StringBuilder();

            for (int i = 0; i < DT_tgt_emp_id.Rows.Count; i++)
            {
                if (tgt_emp_list.Length > 0)
                    tgt_emp_list.Append(", ");
                tgt_emp_list.Append(DT_tgt_emp_id.Rows[i]["EMP_REF_ID"].ToString());
            }

            if (tgt_emp_list.Length == 0)
                tgt_emp_list.Append("-1");




            string query = string.Format(@"
DELETE	    EST_EMP_EST_TARGET_MAP
    WHERE	
            (COMP_ID         = @COMP_ID             OR @COMP_ID         = 0)
        AND (EST_ID          = @EST_ID              )
        AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0)
        AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0)
        AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0)
        AND	 TGT_EMP_ID     IN ({0})
        AND (STATUS_ID       = @STATUS_ID           OR @STATUS_ID       ='')
", tgt_emp_list.ToString());

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@STATUS_ID", SqlDbType.Int);
            paramArray[5].Value = status_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
