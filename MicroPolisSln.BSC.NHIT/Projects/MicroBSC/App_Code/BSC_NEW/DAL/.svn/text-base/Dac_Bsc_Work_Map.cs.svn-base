using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Work_Map
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Work_Map
    /// Class Func     : BSC_MBO_Work_Map Table Data Access
    /// CREATE DATE    : 2011-11-01
    /// CREATE USER    : H.D.Park
    /// -------------------------------------------------------------
    public class Dac_Bsc_Work_Map : DbAgentBase
    {
        public Dac_Bsc_Work_Map() { }

        public bool InsertWorkMap(IDbConnection idc, IDbTransaction idt, int estterm_ref_id, int est_dept_ref_id, int stg_ref_id, DataTable dtAdd, int emp_ref_id)
        {
            //seq 넣어야함
            string strQuery = @"
SELECT  ISNULL(MAX(ORDER_SEQ), 0)
FROM    BSC_MAP_SK_IE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID 
    AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
    AND STG_REF_ID      = @STG_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value = stg_ref_id;

            int order_seq = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(idc, idt, strQuery, paramArray, CommandType.Text));

            strQuery = @"
INSERT INTO BSC_MAP_SK_IE
    (ESTTERM_REF_ID,    EST_DEPT_REF_ID,    STG_REF_ID,     KPI_REF_ID, DEPT_REF_ID,    WORK_REF_ID,    EXEC_REF_ID
    ,ORDER_SEQ,         CREATE_DATE,        CREATE_USER)
VALUES
    (@ESTTERM_REF_ID,   @EST_DEPT_REF_ID,   @STG_REF_ID,    0,          0,              @WORK_REF_ID,   @EXEC_REF_ID
    ,@ORDER_SEQ,        GETDATE(),          @EMP_REF_ID)
";
            foreach (DataRow dr in dtAdd.Rows)
            {
                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
                paramArray[1].Value = est_dept_ref_id;
                paramArray[2] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
                paramArray[2].Value = stg_ref_id;
                paramArray[3] = CreateDataParameter("@WORK_REF_ID", SqlDbType.Int);
                paramArray[3].Value = dr["WORK_REF_ID"];
                paramArray[4] = CreateDataParameter("@EXEC_REF_ID", SqlDbType.Int);
                paramArray[4].Value = dr["EXEC_REF_ID"];
                paramArray[5] = CreateDataParameter("@ORDER_SEQ", SqlDbType.Int);
                paramArray[5].Value = order_seq++;
                paramArray[6] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[6].Value = emp_ref_id;

                int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery, paramArray, CommandType.Text);

                if (affectedRow == 0)
                    return false;
            }
            return true;
        }

        public bool DeleteWorkMap(IDbConnection idc, IDbTransaction idt, int estterm_ref_id, int est_dept_ref_id, int stg_ref_id, DataTable dtDel)
        {
            int order_seq = 0;

            string strQuery = @"
SELECT  ORDER_SEQ
FROM    BSC_MAP_SK_IE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
    AND STG_REF_ID      = @STG_REF_ID
    AND WORK_REF_ID     = @WORK_REF_ID
    AND EXEC_REF_ID     = @EXEC_REF_ID
";

            string strQuery2 = @"
DELETE FROM BSC_MAP_SK_IE
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
    AND STG_REF_ID      = @STG_REF_ID
    AND WORK_REF_ID     = @WORK_REF_ID
    AND EXEC_REF_ID     = @EXEC_REF_ID
";

            // 순번정리
            string strQuery3 = @"
UPDATE BSC_MAP_SK_IE
    SET ORDER_SEQ = ORDER_SEQ - 1
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID
    AND STG_REF_ID      = @STG_REF_ID
    AND ORDER_SEQ       > @ORDER_SEQ
";

            IDbDataParameter[] paramArray;
            foreach (DataRow dr in dtDel.Rows)
            {
                paramArray = null;
                paramArray = CreateDataParameters(5);

                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
                paramArray[1].Value = est_dept_ref_id;
                paramArray[2] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
                paramArray[2].Value = stg_ref_id;
                paramArray[3] = CreateDataParameter("@WORK_REF_ID", SqlDbType.Int);
                paramArray[3].Value = dr["WORK_REF_ID"];
                paramArray[4] = CreateDataParameter("@EXEC_REF_ID", SqlDbType.Int);
                paramArray[4].Value = dr["EXEC_REF_ID"];

                order_seq = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(idc, idt, strQuery, paramArray, CommandType.Text));



                paramArray = null;
                paramArray = CreateDataParameters(5);

                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
                paramArray[1].Value = est_dept_ref_id;
                paramArray[2] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
                paramArray[2].Value = stg_ref_id;
                paramArray[3] = CreateDataParameter("@WORK_REF_ID", SqlDbType.Int);
                paramArray[3].Value = dr["WORK_REF_ID"];
                paramArray[4] = CreateDataParameter("@EXEC_REF_ID", SqlDbType.Int);
                paramArray[4].Value = dr["EXEC_REF_ID"];

                int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery2, paramArray, CommandType.Text);

                if (affectedRow > 0)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(4);

                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[0].Value = estterm_ref_id;
                    paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
                    paramArray[1].Value = est_dept_ref_id;
                    paramArray[2] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
                    paramArray[2].Value = stg_ref_id;
                    paramArray[3] = CreateDataParameter("@ORDER_SEQ", SqlDbType.Int);
                    paramArray[3].Value = order_seq;

                    affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery3, paramArray, CommandType.Text);
                }
                else
                    return false;
            }
            return true;
        }

        public DataSet GetWorkMapTotalList(object estterm_ref_id
                                        , object est_dept_ref_id)
        {
            string strQuery = @"
--평가헤더정보
SELECT   A.ESTTERM_REF_ID
        ,D.ESTTERM_NAME 
        ,A.EST_DEPT_REF_ID
        ,B.DEPT_NAME       as EST_DEPT_NAME
        ,A.DEPT_VISION    
        ,A.BSCCHAMPION_EMP_ID
        ,C.EMP_NAME        as BSCCHAMPION_NAME
        ,A.MAP_VERSION_ID
FROM                BSC_MAP_INFO    A
LEFT OUTER JOIN     EST_DEPT_INFO   B   ON  A.ESTTERM_REF_ID  = B.ESTTERM_REF_ID
                                        AND A.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID
LEFT OUTER JOIN     COM_EMP_INFO    C   ON A.BSCCHAMPION_EMP_ID = C.EMP_REF_ID
LEFT OUTER JOIN     EST_TERM_INFO   D   ON A.ESTTERM_REF_ID = D.ESTTERM_REF_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
    AND A.MAP_VERSION_ID    = ( SELECT MAX(MAP_VERSION_ID)
                                FROM BSC_MAP_TERM
                                WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID)
    AND A.USE_YN            = 'Y'
ORDER BY B.DEPT_NAME

--리스트
SELECT  D2.VIEW_NAME, D3.STG_CODE, D3.STG_NAME
    , ISNULL(SUM(CASE WHEN ISNULL(F.COMPLETE_YN, 'N') = 'Y' THEN 1 ELSE 0 END), 0) AS WORK_COMPLETE_COUNT, ISNULL(SUM(CASE WHEN ISNULL(F.ESTTERM_REF_ID, 0) > 0 THEN 1 ELSE 0 END), 0) AS WORK_COUNT
    , ISNULL(SUM(CASE WHEN ISNULL(G.COMPLETE_YN, 'N') = 'Y' THEN 1 ELSE 0 END), 0) AS EXEC_COMPLETE_COUNT, ISNULL(SUM(CASE WHEN ISNULL(G.ESTTERM_REF_ID, 0) > 0 THEN 1 ELSE 0 END), 0) AS EXEC_COUNT
    , B.ESTTERM_REF_ID, B.EST_DEPT_REF_ID, D2.VIEW_REF_ID, D3.STG_REF_ID
FROM        (SELECT @EST_DEPT_REF_ID AS EST_DEPT_REF_ID)   A
INNER JOIN          EST_DEPT_INFO   B   ON  B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                        AND B.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
INNER JOIN          (   SELECT ESTTERM_REF_ID, EST_DEPT_REF_ID, MAX(MAP_VERSION_ID) AS MAP_VERSION_ID
                        FROM        BSC_MAP_TERM
                        WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
                        GROUP BY    ESTTERM_REF_ID, EST_DEPT_REF_ID )   C   ON  C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                                                            AND C.EST_DEPT_REF_ID   = B.EST_DEPT_REF_ID
INNER JOIN          BSC_MAP_STG     D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                        AND D.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
                                        AND D.MAP_VERSION_ID    = C.MAP_VERSION_ID
LEFT OUTER JOIN     BSC_VIEW_INFO   D2  ON  D2.VIEW_REF_ID      = D.VIEW_REF_ID
LEFT OUTER JOIN     BSC_STG_INFO    D3  ON  D3.ESTTERM_REF_ID   = D.ESTTERM_REF_ID
                                        AND D3.STG_REF_ID       = D.STG_REF_ID
LEFT OUTER JOIN     BSC_MAP_SK_IE   E   ON  E.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                        AND E.EST_DEPT_REF_ID   = D.EST_DEPT_REF_ID
                                        AND E.STG_REF_ID        = D.STG_REF_ID
LEFT OUTER JOIN     BSC_WORK_INFO   F   ON  F.ESTTERM_REF_ID    = E.ESTTERM_REF_ID
                                        AND F.WORK_REF_ID       = E.WORK_REF_ID
                                        AND F.USE_YN            = 'Y'
LEFT OUTER JOIN     BSC_WORK_EXEC   G   ON  G.ESTTERM_REF_ID    = E.ESTTERM_REF_ID
                                        AND G.EXEC_REF_ID       = E.EXEC_REF_ID
                                        AND G.USE_YN            = 'Y'
GROUP BY D2.VIEW_NAME, D3.STG_CODE, D3.STG_NAME, B.ESTTERM_REF_ID, B.EST_DEPT_REF_ID, D2.VIEW_REF_ID, D3.STG_REF_ID

--하위부서포함 전체 가져오기
--SELECT  D2.VIEW_NAME, D3.STG_CODE, D3.STG_NAME
--    , ISNULL(SUM(CASE WHEN ISNULL(F.COMPLETE_YN, 'N') = 'Y' THEN 1 ELSE 0 END), 0) AS WORK_COMPLETE_COUNT, ISNULL(SUM(CASE WHEN ISNULL(F.ESTTERM_REF_ID, 0) > 0 THEN 1 ELSE 0 END), 0) AS WORK_COUNT
--    , ISNULL(SUM(CASE WHEN ISNULL(G.COMPLETE_YN, 'N') = 'Y' THEN 1 ELSE 0 END), 0) AS EXEC_COMPLETE_COUNT, ISNULL(SUM(CASE WHEN ISNULL(G.ESTTERM_REF_ID, 0) > 0 THEN 1 ELSE 0 END), 0) AS EXEC_COUNT
--    , B.ESTTERM_REF_ID, B.EST_DEPT_REF_ID, D2.VIEW_REF_ID, D3.STG_REF_ID
--FROM        dbo.fn_EST_DEPT_INFO_BYTREE(@ESTTERM_REF_ID,@EST_DEPT_REF_ID)   A
--INNER JOIN          EST_DEPT_INFO   B   ON  B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
--                                        AND B.EST_DEPT_REF_ID   = A.DEPT_ID
--INNER JOIN          (   SELECT ESTTERM_REF_ID, EST_DEPT_REF_ID, MAX(MAP_VERSION_ID) AS MAP_VERSION_ID
--                        FROM        BSC_MAP_TERM
--                        WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
--                        GROUP BY    ESTTERM_REF_ID, EST_DEPT_REF_ID )   C   ON  C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
--                                                                            AND C.EST_DEPT_REF_ID   = B.EST_DEPT_REF_ID
--INNER JOIN          BSC_MAP_STG     D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
--                                        AND D.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
--                                        AND D.MAP_VERSION_ID    = C.MAP_VERSION_ID
--LEFT OUTER JOIN     BSC_VIEW_INFO   D2  ON  D2.VIEW_REF_ID      = D.VIEW_REF_ID
--LEFT OUTER JOIN     BSC_STG_INFO    D3  ON  D3.ESTTERM_REF_ID   = D.ESTTERM_REF_ID
--                                        AND D3.STG_REF_ID       = D.STG_REF_ID
--INNER JOIN          BSC_MAP_SK_IE   E   ON  E.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
--                                        AND E.EST_DEPT_REF_ID   = D.EST_DEPT_REF_ID
--                                        AND E.STG_REF_ID        = D.STG_REF_ID
--LEFT OUTER JOIN     BSC_WORK_INFO   F   ON  F.ESTTERM_REF_ID    = E.ESTTERM_REF_ID
--                                        AND F.EST_DEPT_REF_ID   = E.EST_DEPT_REF_ID
--                                        AND F.WORK_REF_ID       = E.WORK_REF_ID
--                                        AND F.USE_YN            = 'Y'
--LEFT OUTER JOIN     BSC_WORK_EXEC   G   ON  G.ESTTERM_REF_ID    = E.ESTTERM_REF_ID
--                                        AND G.EST_DEPT_REF_ID   = E.EST_DEPT_REF_ID
--                                        AND G.EXEC_REF_ID       = E.EXEC_REF_ID
--                                        AND G.USE_YN            = 'Y'
--GROUP BY D2.VIEW_NAME, D3.STG_CODE, D3.STG_NAME, B.ESTTERM_REF_ID, B.EST_DEPT_REF_ID, D2.VIEW_REF_ID, D3.STG_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = est_dept_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_TOTAL_LIST", null, paramArray, CommandType.Text);
        }


        public DataSet GetWorkMapTotalListHeader_DB(object estterm_ref_id
                                                  , object est_dept_ref_id)
        {
            string strQuery = @"
--평가헤더정보
SELECT   A.ESTTERM_REF_ID
        ,D.ESTTERM_NAME 
        ,A.EST_DEPT_REF_ID
        ,B.DEPT_NAME       as EST_DEPT_NAME
        ,A.DEPT_VISION    
        ,A.BSCCHAMPION_EMP_ID
        ,C.EMP_NAME        as BSCCHAMPION_NAME
        ,A.MAP_VERSION_ID
FROM                BSC_MAP_INFO    A
LEFT OUTER JOIN     EST_DEPT_INFO   B   ON  A.ESTTERM_REF_ID  = B.ESTTERM_REF_ID
                                        AND A.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID
LEFT OUTER JOIN     COM_EMP_INFO    C   ON A.BSCCHAMPION_EMP_ID = C.EMP_REF_ID
LEFT OUTER JOIN     EST_TERM_INFO   D   ON A.ESTTERM_REF_ID = D.ESTTERM_REF_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
    AND A.MAP_VERSION_ID    = ( SELECT MAX(MAP_VERSION_ID)
                                FROM BSC_MAP_TERM
                                WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID)
    AND A.USE_YN            = 'Y'
ORDER BY B.DEPT_NAME

";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = est_dept_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_TOTAL_LIST_HEADER", null, paramArray, CommandType.Text);
        }

        public DataSet GetWorkMapTotalList_DB()
        {
            string strQuery = @"
--리스트
SELECT  D2.VIEW_NAME, D3.STG_CODE, D3.STG_NAME
    , ISNULL(SUM(CASE WHEN ISNULL(F.COMPLETE_YN, 'N') = 'Y' THEN 1 ELSE 0 END), 0) AS WORK_COMPLETE_COUNT, ISNULL(SUM(CASE WHEN ISNULL(F.ESTTERM_REF_ID, 0) > 0 THEN 1 ELSE 0 END), 0) AS WORK_COUNT
    , ISNULL(SUM(CASE WHEN ISNULL(G.COMPLETE_YN, 'N') = 'Y' THEN 1 ELSE 0 END), 0) AS EXEC_COMPLETE_COUNT, ISNULL(SUM(CASE WHEN ISNULL(G.ESTTERM_REF_ID, 0) > 0 THEN 1 ELSE 0 END), 0) AS EXEC_COUNT
    , B.ESTTERM_REF_ID, B.EST_DEPT_REF_ID, D2.VIEW_REF_ID, D3.STG_REF_ID
FROM        (SELECT @EST_DEPT_REF_ID AS EST_DEPT_REF_ID)   A
INNER JOIN          EST_DEPT_INFO   B   ON  B.ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                        AND B.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
INNER JOIN          (   SELECT ESTTERM_REF_ID, EST_DEPT_REF_ID, MAX(MAP_VERSION_ID) AS MAP_VERSION_ID
                        FROM        BSC_MAP_TERM
                        WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
                        GROUP BY    ESTTERM_REF_ID, EST_DEPT_REF_ID )   C   ON  C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                                                            AND C.EST_DEPT_REF_ID   = B.EST_DEPT_REF_ID
INNER JOIN          BSC_MAP_STG     D   ON  D.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                                        AND D.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
                                        AND D.MAP_VERSION_ID    = C.MAP_VERSION_ID
LEFT OUTER JOIN     BSC_VIEW_INFO   D2  ON  D2.VIEW_REF_ID      = D.VIEW_REF_ID
LEFT OUTER JOIN     BSC_STG_INFO    D3  ON  D3.ESTTERM_REF_ID   = D.ESTTERM_REF_ID
                                        AND D3.STG_REF_ID       = D.STG_REF_ID
LEFT OUTER JOIN     BSC_MAP_SK_IE   E   ON  E.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                        AND E.EST_DEPT_REF_ID   = D.EST_DEPT_REF_ID
                                        AND E.STG_REF_ID        = D.STG_REF_ID
LEFT OUTER JOIN     BSC_WORK_INFO   F   ON  F.ESTTERM_REF_ID    = E.ESTTERM_REF_ID
                                        AND F.WORK_REF_ID       = E.WORK_REF_ID
                                        AND F.USE_YN            = 'Y'
LEFT OUTER JOIN     BSC_WORK_EXEC   G   ON  G.ESTTERM_REF_ID    = E.ESTTERM_REF_ID
                                        AND G.EXEC_REF_ID       = E.EXEC_REF_ID
                                        AND G.USE_YN            = 'Y'
GROUP BY D2.VIEW_NAME, D3.STG_CODE, D3.STG_NAME, B.ESTTERM_REF_ID, B.EST_DEPT_REF_ID, D2.VIEW_REF_ID, D3.STG_REF_ID

";
           

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_TOTAL_LIST", null, null, CommandType.Text);
        }

        public DataSet GetWorkMapMaster(object estterm_ref_id
                                        , object est_dept_ref_id)
        {
            string strQuery = @"
--평가기본정보들
SELECT   A.ESTTERM_NAME
        ,C.DEPT_NAME        AS EST_DEPT_NAME
        ,D.EMP_NAME         AS BSCCHAMPION_NAME
        ,B.DEPT_VISION
        ,B.MAP_VERSION_ID
        ,B.MAP_VERSION_NAME
        ,B.MAP_DESC
FROM            EST_TERM_INFO   A
INNER JOIN      BSC_MAP_INFO    B   ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
                                    AND B.MAP_VERSION_ID    = ( SELECT MAX(MAP_VERSION_ID)
                                                                FROM BSC_MAP_TERM
                                                                WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                                                    AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID)
                                    AND B.USE_YN            = 'Y'
INNER JOIN      EST_DEPT_INFO   C   ON  C.ESTTERM_REF_ID    = B.ESTTERM_REF_ID
                                    AND C.EST_DEPT_REF_ID   = B.EST_DEPT_REF_ID
LEFT OUTER JOIN COM_EMP_INFO    D   ON  D.EMP_REF_ID        = B.BSCCHAMPION_EMP_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = est_dept_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_MASTER", null, paramArray, CommandType.Text);
        }

        public DataSet GetWorkMapTree(object estterm_ref_id, object est_dept_ref_id, object map_version_id)
        {
            string strQuery = @"
--관점
SELECT	DISTINCT 1									    AS SEQ_1
		,A.VIEW_SEQ									    AS SEQ_2
		,''	                                            AS VALUE_PATH
		,'V' + CONVERT(VARCHAR, A.VIEW_REF_ID)          AS TREE_ID
		,A.VIEW_NAME								    AS TREE_NAME
		,'../images/stg/TREE_V.gif'					    AS TREE_IMAGE
FROM	BSC_VIEW_INFO	A
INNER JOIN BSC_MAP_STG	B	ON	B.ESTTERM_REF_ID	= @ESTTERM_REF_ID
							AND	B.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
							AND	B.MAP_VERSION_ID	= @MAP_VERSION_ID
							AND	B.VIEW_REF_ID		= A.VIEW_REF_ID
INNER JOIN BSC_STG_INFO	C	ON	C.ESTTERM_REF_ID	= B.ESTTERM_REF_ID
							AND	C.STG_REF_ID		= B.STG_REF_ID
							AND	C.USE_YN			= 'Y'
WHERE	A.USE_YN	= 'Y'

UNION ALL

--전략
SELECT	 2											    AS SEQ_1
		,A.SORT_ORDER								    AS SEQ_2
		,';V' + CONVERT(VARCHAR, A.VIEW_REF_ID)	        AS VALUE_PATH
		,'S' + CONVERT(VARCHAR, A.STG_REF_ID)	        AS TREE_ID
		,B.STG_NAME									    AS TREE_NAME
		,'../images/stg/TREE_S.gif'					    AS TREE_IMAGE
FROM	BSC_MAP_STG		A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_VIEW_INFO C  ON  C.VIEW_REF_ID       = A.VIEW_REF_ID
                            AND C.USE_YN            = 'Y'
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
	AND	A.MAP_VERSION_ID	= @MAP_VERSION_ID

UNION ALL

--중점과제
SELECT	 3											                                    AS SEQ_1
		,A.ORDER_SEQ								                                    AS SEQ_2
		,';V' + CONVERT(VARCHAR, D.VIEW_REF_ID) + ';S' + CONVERT(VARCHAR, A.STG_REF_ID)  AS VALUE_PATH
		,'C' + CONVERT(VARCHAR, A.WORK_REF_ID)                                          AS TREE_ID
		,C.WORK_NAME								                                    AS TREE_NAME
		,'../images/stg/TREE_W.gif'					                                    AS TREE_IMAGE
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_INFO C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	C.WORK_REF_ID		= A.WORK_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
	
UNION ALL

--실행과제
SELECT	 4											                                    AS SEQ_1
		,A.ORDER_SEQ								                                    AS SEQ_2
		,';V' + CONVERT(VARCHAR, D.VIEW_REF_ID) + ';S' + CONVERT(VARCHAR, A.STG_REF_ID)  AS VALUE_PATH
		,'E' + CONVERT(VARCHAR, A.EXEC_REF_ID)	                                        AS TREE_ID
		,C.EXEC_NAME								                                    AS TREE_NAME
		,'../images/stg/TREE_E.gif'					                                    AS TREE_IMAGE
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_EXEC C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	C.EXEC_REF_ID		= A.EXEC_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
ORDER BY SEQ_1, SEQ_2
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2].Value = map_version_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_TREE", null, paramArray, CommandType.Text);
        }

        public DataSet GetWorkMapWorkExec(object estterm_ref_id, object est_dept_ref_id, object select_type, object select_value, object map_version_id)
        {
            string strQuery = string.Empty;
            if (select_type.ToString() == "S") //전략
                strQuery = @"
SELECT	 '중점과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.WORK_CODE
        ,C.WORK_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.WORK_REF_ID
        ,A.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'C'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_INFO C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	C.WORK_REF_ID		= A.WORK_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID    = C.WORK_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
    AND A.STG_REF_ID        = @STG_REF_ID
    AND A.WORK_REF_ID       <> 0

UNION ALL

SELECT	 '실행과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.EXEC_CODE
        ,C.EXEC_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.EXEC_REF_ID                                                              AS WORK_REF_ID
        ,C.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'E'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_EXEC C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	C.EXEC_REF_ID		= A.EXEC_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID    = C.EXEC_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
    AND A.STG_REF_ID        = @STG_REF_ID
    AND A.EXEC_REF_ID       <> 0
ORDER BY WORK_TYPE, ORDER_SEQ
";
            else if (select_type.ToString() == "C") //중점과제
                strQuery = @"
SELECT	 '중점과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.WORK_CODE
        ,C.WORK_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.WORK_REF_ID
        ,A.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'C'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_INFO C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	C.WORK_REF_ID		= A.WORK_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID        = C.WORK_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
    AND A.WORK_REF_ID       = @STG_REF_ID

UNION ALL

SELECT	 '실행과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.EXEC_CODE
        ,C.EXEC_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,C.EXEC_REF_ID                                                              AS WORK_REF_ID
        ,C.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'E'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_EXEC C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
                            AND C.WORK_REF_ID       = A.WORK_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
INNER JOIN BSC_WORK_INFO A2 ON  A2.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                            AND A2.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
                            AND A2.WORK_REF_ID       = C.WORK_REF_ID
                            AND A2.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID    = C.EXEC_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
    AND A.WORK_REF_ID       = @STG_REF_ID
ORDER BY WORK_TYPE, ORDER_SEQ
";
            else if (select_type.ToString() == "E") //실행과제
                strQuery = @"
SELECT	 '중점과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.WORK_CODE
        ,C.WORK_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,C.WORK_REF_ID
        ,C.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'C'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_EXEC A2 ON  A2.ESTTERM_REF_ID   = A.ESTTERM_REF_ID
                            AND A2.EXEC_REF_ID      = A.EXEC_REF_ID
                            AND A2.USE_YN           = 'Y'
INNER JOIN BSC_WORK_INFO C	ON	C.ESTTERM_REF_ID	= A2.ESTTERM_REF_ID
							AND	C.WORK_REF_ID		= A2.WORK_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID        = C.WORK_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
    AND A.EXEC_REF_ID       = @STG_REF_ID

UNION ALL

SELECT	 '실행과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.EXEC_CODE
        ,C.EXEC_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.EXEC_REF_ID                                                              AS WORK_REF_ID
        ,C.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'E'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_EXEC C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
                            AND C.EXEC_REF_ID       = A.EXEC_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = @MAP_VERSION_ID
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
INNER JOIN BSC_WORK_INFO A2 ON  A2.ESTTERM_REF_ID    = C.ESTTERM_REF_ID
                            AND A2.WORK_REF_ID       = C.WORK_REF_ID
                            AND A2.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID    = C.EXEC_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
	AND	A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID
    AND A.EXEC_REF_ID       = @STG_REF_ID
ORDER BY WORK_TYPE, ORDER_SEQ
";


            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2]       = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3]       = CreateDataParameter("@MAP_VERSION_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2].Value = select_value;
            paramArray[3].Value  = map_version_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_WORK_EXEC", null, paramArray, CommandType.Text);
        }

        public DataSet GetWorkMapWorkExecList(object estterm_ref_id
                                            , object est_dept_ref_id
                                            , object work_type
                                            , object est_dept_name
                                            , object est_emp_id
                                            , object est_emp_name
                                            , object work_code
                                            , object work_name
                                            , object complete_yn)
        {
            string strQuery = @"
SELECT	 '중점과제'                                                                 AS WORK_TYPE_NAME
        ,C.DEPT_NAME                                                                AS DEPT_NAME
        ,A.WORK_CODE
        ,A.WORK_NAME
        ,B.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(A.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.WORK_REF_ID
        ,A.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,A.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'C'                                                                        AS WORK_TYPE
FROM	BSC_WORK_INFO A
LEFT OUTER JOIN COM_EMP_INFO    B   ON  B.EMP_REF_ID        = A.WORK_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   C   ON  C.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
LEFT OUTER JOIN BSC_MAP_SK_IE   D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND D.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
                                    AND D.WORK_REF_ID       = A.WORK_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
    AND A.USE_YN            = 'Y'
    AND (@WORK_TYPE         = 'C'               OR @WORK_TYPE           =''    )
    AND (C.DEPT_NAME        = @EST_DEPT_NAME    OR @EST_DEPT_NAME       =''    )
    AND (A.WORK_EMP_ID      = @EST_EMP_ID       OR @EST_EMP_ID          =''    )
    AND (B.EMP_NAME         = @EST_EMP_NAME     OR @EST_EMP_NAME        =''    )
    AND (A.WORK_CODE        = @WORK_CODE        OR @WORK_CODE           =''    )
    AND (A.WORK_NAME        = @WORK_NAME        OR @WORK_NAME           =''    )
    AND (ISNULL(A.COMPLETE_YN, 'N') = @COMPLETE_YN OR @COMPLETE_YN      =''    )
    AND D.WORK_REF_ID       IS NULL

UNION ALL

SELECT	 '실행과제'                                                                 AS WORK_TYPE_NAME
        ,C.DEPT_NAME                                                                AS DEPT_NAME
        ,A.EXEC_CODE                                                                AS WORK_CODE
        ,A.EXEC_NAME                                                                AS WORK_NAME
        ,B.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(A.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.EXEC_REF_ID                                                              AS WORK_REF_ID
        ,A.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,A.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'E'                                                                        AS WORK_TYPE
FROM	BSC_WORK_EXEC A
LEFT OUTER JOIN COM_EMP_INFO    B   ON  B.EMP_REF_ID        = A.EXEC_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   C   ON  C.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
LEFT OUTER JOIN BSC_MAP_SK_IE   D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND D.EST_DEPT_REF_ID   = @EST_DEPT_REF_ID
                                    AND D.EXEC_REF_ID       = A.EXEC_REF_ID
WHERE	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
    AND A.USE_YN            = 'Y'
    AND (@WORK_TYPE         = 'E'               OR @WORK_TYPE           =''    )
    AND (C.DEPT_NAME        = @EST_DEPT_NAME    OR @EST_DEPT_NAME       =''    )
    AND (A.EXEC_EMP_ID      = @EST_EMP_ID       OR @EST_EMP_ID      = 0)
    AND (B.EMP_NAME         = @EST_EMP_NAME     OR @EST_EMP_NAME        =''    )
    AND (A.EXEC_CODE        = @WORK_CODE        OR @WORK_CODE           =''    )
    AND (A.EXEC_NAME        = @WORK_NAME        OR @WORK_NAME           =''    )
    AND (ISNULL(A.COMPLETE_YN, 'N') = @COMPLETE_YN OR @COMPLETE_YN      =''    )
    AND D.EXEC_REF_ID       IS NULL
ORDER BY WORK_TYPE, WORK_DEPT_REF_ID, A.WORK_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(9);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@WORK_TYPE", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@EST_DEPT_NAME", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[5] = CreateDataParameter("@EST_EMP_NAME", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@WORK_CODE", SqlDbType.VarChar);
            paramArray[7] = CreateDataParameter("@WORK_NAME", SqlDbType.VarChar);
            paramArray[8] = CreateDataParameter("@COMPLETE_YN", SqlDbType.VarChar);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2].Value = work_type;
            paramArray[3].Value = est_dept_name;
            paramArray[4].Value = (est_emp_id == "" ? 0 : DataTypeUtility.GetToInt32(est_emp_id));
            paramArray[5].Value = est_emp_name;
            paramArray[6].Value = work_code;
            paramArray[7].Value = work_name;
            paramArray[8].Value = complete_yn;

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_WORK_EXEC", null, paramArray, CommandType.Text);
        }

        public DataSet GetWorkMapList(object estterm_ref_id
                                    , object work_code
                                    , object work_name
                                    , object emp_name
                                    , object est_dept_ref_id
                                    , object work_type
                                    , object complete_yn
                                    , object work_emp_id)
        {
            string strQuery = @"
SELECT	 '중점과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.WORK_CODE
        ,C.WORK_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.WORK_REF_ID
        ,A.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'C'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_INFO C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	C.WORK_REF_ID		= A.WORK_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = (SELECT MAX(MAP_VERSION_ID) FROM BSC_MAP_TERM WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID)
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID    = C.WORK_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	(A.ESTTERM_REF_ID	= @ESTTERM_REF_ID       OR @ESTTERM_REF_ID  = 0)
	AND	(A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID      OR @EST_DEPT_REF_ID = 0)
    AND (C.WORK_CODE        = @WORK_CODE            OR @WORK_CODE           =''    )
    AND (C.WORK_NAME        = @WORK_NAME            OR @WORK_NAME           =''    )
    AND (F.EMP_NAME         = @EMP_NAME             OR @EMP_NAME            =''    )
    AND (@WORK_TYPE         = 'C'                   OR @WORK_TYPE           =''    )
    AND (C.COMPLETE_YN      = @COMPLETE_YN          OR @COMPLETE_YN         =''    )
    AND (C.WORK_EMP_ID      = @WORK_EMP_ID          OR @WORK_EMP_ID     = 0)

UNION ALL

SELECT	 '실행과제'                                                                 AS WORK_TYPE_NAME
        ,G.DEPT_NAME                                                                AS DEPT_NAME
        ,C.EXEC_CODE
        ,C.EXEC_NAME
        ,F.EMP_NAME                                                                 AS WORK_EMP_NAME
        ,CASE WHEN ISNULL(C.COMPLETE_YN, 'N') = 'Y' THEN '완료' ELSE '진행중' END   AS COMPLETE_YN
        ,A.ESTTERM_REF_ID
        ,A.EXEC_REF_ID                                                              AS WORK_REF_ID
        ,C.WORK_REF_ID                                                              AS WORK_REF_ID_ORG
        ,C.EST_DEPT_REF_ID                                                          AS WORK_DEPT_REF_ID
        ,'E'                                                                        AS WORK_TYPE
        ,A.ORDER_SEQ
FROM	BSC_MAP_SK_IE	A
INNER JOIN BSC_STG_INFO	B	ON	B.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	B.STG_REF_ID		= A.STG_REF_ID
							AND	B.USE_YN			= 'Y'
INNER JOIN BSC_WORK_EXEC C	ON	C.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
							AND	C.EXEC_REF_ID		= A.EXEC_REF_ID
							AND	C.USE_YN			= 'Y'
INNER JOIN BSC_MAP_STG  D   ON  D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                            AND D.EST_DEPT_REF_ID   = A.EST_DEPT_REF_ID
                            AND D.MAP_VERSION_ID    = (SELECT MAX(MAP_VERSION_ID) FROM BSC_MAP_TERM WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND EST_DEPT_REF_ID = @EST_DEPT_REF_ID)
                            AND D.STG_REF_ID        = A.STG_REF_ID
INNER JOIN BSC_VIEW_INFO E  ON  E.VIEW_REF_ID       = D.VIEW_REF_ID
                            AND E.USE_YN            = 'Y'
LEFT OUTER JOIN COM_EMP_INFO    F   ON  F.EMP_REF_ID    = C.EXEC_EMP_ID
LEFT OUTER JOIN EST_DEPT_INFO   G   ON  G.EST_DEPT_REF_ID   = C.EST_DEPT_REF_ID
WHERE	(A.ESTTERM_REF_ID	= @ESTTERM_REF_ID       OR @ESTTERM_REF_ID  = 0)
	AND	(A.EST_DEPT_REF_ID	= @EST_DEPT_REF_ID      OR @EST_DEPT_REF_ID = 0)
    AND (C.EXEC_CODE        = @WORK_CODE            OR @WORK_CODE           =''    )
    AND (C.EXEC_NAME        = @WORK_NAME            OR @WORK_NAME           =''    )
    AND (F.EMP_NAME         = @EMP_NAME             OR @EMP_NAME            =''    )
    AND (@WORK_TYPE         = 'E'                   OR @WORK_TYPE           =''    )
    AND (C.COMPLETE_YN      = @COMPLETE_YN          OR @COMPLETE_YN         =''    )
    AND (C.EXEC_EMP_ID      = @WORK_EMP_ID          OR @WORK_EMP_ID     = 0)
ORDER BY WORK_TYPE, ORDER_SEQ
";


            IDbDataParameter[] paramArray = CreateDataParameters(8);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = est_dept_ref_id;
            paramArray[2] = CreateDataParameter("@WORK_CODE", SqlDbType.VarChar);
            paramArray[2].Value = work_code;
            paramArray[3] = CreateDataParameter("@WORK_NAME", SqlDbType.VarChar);
            paramArray[3].Value = work_name;
            paramArray[4] = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value = emp_name;
            paramArray[5] = CreateDataParameter("@WORK_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = work_type;

            paramArray[6] = CreateDataParameter("@COMPLETE_YN", SqlDbType.VarChar);
            paramArray[6].Value = complete_yn;
            paramArray[7] = CreateDataParameter("@WORK_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = work_emp_id;

            return DbAgentObj.FillDataSet(strQuery, "BSC_WORK_MAP_LIST", null, paramArray, CommandType.Text);
        }
    }
}