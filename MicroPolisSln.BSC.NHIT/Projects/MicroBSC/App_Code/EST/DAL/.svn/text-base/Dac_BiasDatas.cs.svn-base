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

namespace MicroBSC.Estimation.Dac
{
    public class Dac_BiasDatas : DbAgentBase
    {
        public string rtnMSG = string.Empty;
        public Dac_BiasDatas()
        {
        }

        public DataSet GetBiasGroupEmp(object comp_id, object est_id, object estterm_ref_id, object bias_grp_id)
        {
            string strQuery = @"
DECLARE @ROOT_DEPT INT

SELECT  @ROOT_DEPT = DEPT_REF_ID  
FROM    COM_DEPT_INFO
WHERE   ISNULL(UP_DEPT_ID, 0) = 0
    AND DEPT_FLAG = 1

SELECT  @ROOT_DEPT = DEPT_REF_ID  
FROM    COM_DEPT_INFO
WHERE   ISNULL(UP_DEPT_ID, 0) = 0
	AND DEPT_FLAG = 1

SELECT   A.DEPT_ID      AS SFID
        ,B.UP_DEPT_ID   AS PTID
        ,B.DEPT_NAME    AS NAME
        ,B.DEPT_TYPE    AS LVL
        ,ISNULL(D.EMP_REF_ID, 0) AS EMP_REF_ID
        ,ISNULL(D.EMP_NAME, '') AS EMP_NAME
        ,CASE WHEN ISNULL(E.BIAS_GRP_ID, 0) = @BIAS_GRP_ID THEN 'Y' ELSE 'N' END AS ISCHECK
        ,CASE WHEN F.YEARLY_CLOSE_YN = 1 THEN 'F' ELSE CASE WHEN ISNULL(E.BIAS_GRP_ID, 0) = @BIAS_GRP_ID THEN 'Y' ELSE CASE WHEN ISNULL(E.BIAS_GRP_ID, 0) = 0 THEN 'Y' ELSE 'N' END END END AS ISENABLED
FROM        fn_COM_DEPT_INFO_BYTREE(@ROOT_DEPT) A 
LEFT OUTER JOIN COM_DEPT_INFO   B
                            ON  B.DEPT_REF_ID   = A.DEPT_ID
LEFT OUTER JOIN REL_DEPT_EMP	C
							ON	C.DEPT_REF_ID	= B.DEPT_REF_ID
LEFT OUTER JOIN COM_EMP_INFO    D
                            ON  D.EMP_REF_ID    = C.EMP_REF_ID
LEFT OUTER JOIN EST_BIAS_GRP_USER   E
                                ON  E.COMP_ID           = @COMP_ID
                                AND E.EST_ID            = @EST_ID
                                AND E.ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                AND E.EMP_REF_ID        = D.EMP_REF_ID
LEFT OUTER JOIN EST_TERM_INFO	F
							ON	F.ESTTERM_REF_ID	= @ESTTERM_REF_ID
WHERE	C.REL_STATUS > CASE WHEN F.YEARLY_CLOSE_YN = 0 THEN  0 ELSE -1 END
ORDER BY A.SORT_ORDER, A.DEPT_ID, D.EMP_NAME
";
            IDbDataParameter[] dtParam = CreateDataParameters(4);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[3].Value = bias_grp_id;

            return DbAgentObj.FillDataSet(strQuery, "BIAS_GROUP_EMP", null, dtParam, CommandType.Text);
        }

        public DataTable CalcBiasData(object comp_id, object est_id, object estterm_ref_id, object estterm_sub_id, object estterm_step_id, object bias_grp_id, object selectQuery, object joinQuery)
        {
            string strQuery = @"
SELECT   A.COMP_ID, A.EST_ID, A.ESTTERM_REF_ID, A.BIAS_GRP_ID, AA.BIAS_GRP_NM, B.ESTTERM_SUB_ID, B.ESTTERM_STEP_ID, A.DEPT_REF_ID AS TGT_DEPT_ID, A.EMP_REF_ID AS TGT_EMP_ID, C.DEPT_NAME AS TGT_DEPT_NAME, D.EMP_NAME AS TGT_EMP_NAME
        , B.TGT_POS_CLS_ID, B.TGT_POS_DUT_ID, B.TGT_POS_GRP_ID, B.TGT_POS_RNK_ID
        , B.TGT_POS_CLS_NAME, B.TGT_POS_DUT_NAME, B.TGT_POS_GRP_NAME, B.TGT_POS_RNK_NAME
{0}
FROM    EST_BIAS_GRP_USER   A
INNER JOIN EST_BIAS_GROUP   AA
                        ON  AA.COMP_ID      = A.COMP_ID
                        AND AA.EST_ID       = A.EST_ID
                        AND AA.BIAS_GRP_ID  = A.BIAS_GRP_ID
INNER JOIN EST_DATA B
                ON  B.COMP_ID   = A.COMP_ID
                AND B.EST_ID    = A.EST_ID
                AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                AND B.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
                AND B.ESTTERM_STEP_ID   = @ESTTERM_STEP_ID
                AND B.TGT_DEPT_ID       = A.DEPT_REF_ID
                AND B.TGT_EMP_ID        = A.EMP_REF_ID
LEFT OUTER JOIN COM_DEPT_INFO   C
                            ON  C.DEPT_REF_ID   = A.DEPT_REF_ID
LEFT OUTER JOIN COM_EMP_INFO    D
                            ON  D.EMP_REF_ID    = A.EMP_REF_ID
{1}
WHERE   A.COMP_ID          = @COMP_ID
    AND A.EST_ID           = @EST_ID
    AND A.ESTTERM_REF_ID   = @ESTTERM_REF_ID
    AND A.BIAS_GRP_ID      = @BIAS_GRP_ID
ORDER BY A.COMP_ID, A.EST_ID, A.ESTTERM_REF_ID, A.BIAS_GRP_ID, B.ESTTERM_SUB_ID, B.ESTTERM_STEP_ID, C.SORT_ORDER, D.EMP_NAME
";
            strQuery = string.Format(strQuery, selectQuery.ToString(), joinQuery.ToString());

            IDbDataParameter[] dtParam = CreateDataParameters(6);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[3].Value = bias_grp_id;
            dtParam[4] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            dtParam[4].Value = estterm_sub_id;
            dtParam[5] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            dtParam[5].Value = estterm_step_id;

            return DbAgentObj.FillDataSet(strQuery, "EST_BIAS_DATACALC", null, dtParam, CommandType.Text).Tables[0];
        }

        public DataTable GetBiasColumns(object comp_id, object est_id, object visible_yn, object use_yn)
        {
            string strQuery = @"
SELECT   COMP_ID
        ,EST_ID
        ,SEQ
        ,VISIBLE_YN
        ,COL_ORDER
        ,COL_KEY
        ,COL_NAME
        ,COL_DESC
        ,COL_TYPE
        ,COL_WIDTH
        ,COL_ALIGN
        ,DATA_TYPE
        ,PROC_NAME
        ,PROC_TYPE
        ,USE_YN
FROM    EST_BIAS_COL
WHERE   (COMP_ID    = @COMP_ID      OR @COMP_ID     = 0)
    AND (EST_ID     = @EST_ID       OR @EST_ID          =''    )
    AND (VISIBLE_YN = @VISIBLE_YN   OR @VISIBLE_YN      =''    )
    AND (USE_YN     = @USE_YN       OR @USE_YN          =''    )
ORDER BY COMP_ID, EST_ID, SEQ
";
            IDbDataParameter[] dtParam = CreateDataParameters(4);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@VISIBLE_YN", SqlDbType.VarChar);
            dtParam[2].Value = visible_yn;
            dtParam[3] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            dtParam[3].Value = use_yn;

            return DbAgentObj.FillDataSet(strQuery, "EST_BIAS_COL", null, dtParam, CommandType.Text).Tables[0];
        }

        public DataTable GetBiasGroupEmpCount(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object use_yn)
        {
            string strQuery = @"
SELECT   A.COMP_ID
        ,A.EST_ID
        ,A.BIAS_GRP_ID
        ,A.BIAS_GRP_CD
        ,A.BIAS_GRP_NM
        ,A.BIAS_GRP_DESC
        ,B.ESTTERM_REF_ID
        ,COUNT(DISTINCT B.DEPT_REF_ID)   AS DEPT_COUNT
        ,COUNT(B.COMP_ID)       AS EMP_COUNT
FROM EST_BIAS_GROUP A
LEFT OUTER JOIN EST_BIAS_GRP_USER   B
                                ON  B.COMP_ID           = A.COMP_ID
                                AND B.EST_ID            = A.EST_ID
                                AND B.BIAS_GRP_ID       = A.BIAS_GRP_ID
                                AND (B.ESTTERM_REF_ID   = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
WHERE   (A.COMP_ID     = @COMP_ID   OR @COMP_ID = 0)
    AND (A.EST_ID      = @EST_ID    OR @EST_ID      =''    )
    AND (A.USE_YN      = @USE_YN    OR @USE_YN      =''    )
GROUP BY A.COMP_ID, A.EST_ID, B.ESTTERM_REF_ID, A.BIAS_GRP_ID, A.BIAS_GRP_CD, A.BIAS_GRP_NM, A.BIAS_GRP_DESC
ORDER BY A.COMP_ID, A.EST_ID, A.BIAS_GRP_ID
";
            IDbDataParameter[] dtParam = CreateDataParameters(4);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            dtParam[3].Value = use_yn;

            return DbAgentObj.FillDataSet(strQuery, "BIAS_GROUP_EMP", null, dtParam, CommandType.Text).Tables[0];
        }

        public DataTable GetBiasGroupEmpList(object comp_id, object est_id, object estterm_ref_id)
        {
            string strQuery = @"
SELECT  A.BIAS_GRP_ID
       ,B.BIAS_GRP_CD
       ,B.BIAS_GRP_NM
       ,A.DEPT_REF_ID
       ,C.DEPT_NAME
       ,A.EMP_REF_ID
       ,D.EMP_NAME
FROM EST_BIAS_GRP_USER  A
LEFT OUTER JOIN EST_BIAS_GROUP  B
                            ON  B.COMP_ID   = A.COMP_ID
                            AND B.EST_ID    = A.EST_ID
                            AND B.BIAS_GRP_ID   = A.BIAS_GRP_ID
LEFT OUTER JOIN COM_DEPT_INFO   C
                            ON  C.DEPT_REF_ID   = A.DEPT_REF_ID
LEFT OUTER JOIN COM_EMP_INFO    D
                            ON  D.EMP_REF_ID    = A.EMP_REF_ID
WHERE   (A.COMP_ID     = @COMP_ID OR @COMP_ID = 0)
    AND (A.EST_ID      = @EST_ID  OR @EST_ID      =''    )
    AND (A.ESTTERM_REF_ID   = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID = 0)
ORDER BY A.COMP_ID, A.EST_ID, A.ESTTERM_REF_ID, A.BIAS_GRP_ID, A.DEPT_REF_ID, A.EMP_REF_ID
";
            IDbDataParameter[] dtParam = CreateDataParameters(3);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;

            return DbAgentObj.FillDataSet(strQuery, "BIAS_GROUP", null, dtParam, CommandType.Text).Tables[0];
        }

        public DataTable GetBiasData(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id, int estterm_step_id, int bias_grp_id)
        {
            string strQuery = @"
SELECT   A.COMP_ID, A.EST_ID, A.ESTTERM_REF_ID, A.ESTTERM_SUB_ID, A.ESTTERM_STEP_ID, A.BIAS_GRP_ID, H.BIAS_GRP_NM
        ,A.TGT_DEPT_ID, A.TGT_EMP_ID, A.TGT_POS_CLS_ID, A.TGT_POS_DUT_ID, A.TGT_POS_GRP_ID, A.TGT_POS_RNK_ID
        ,B.DEPT_NAME AS TGT_DEPT_NAME, C.EMP_NAME AS TGT_EMP_NAME, D.POS_CLS_NAME AS TGT_POS_CLS_NAME, E.POS_DUT_NAME AS TGT_POS_DUT_NAME, F.POS_GRP_NAME AS TGT_POS_GRP_NAME, G.POS_RNK_NAME AS TGT_POS_RNK_NAME
        ,A.COL1,A.COL2,A.COL3,A.COL4,A.COL5,A.COL6,A.COL7,A.COL8,A.COL9,A.COL10
        ,A.POINT
FROM EST_BIAS_DATA  A
LEFT OUTER JOIN COM_DEPT_INFO   B
                            ON  B.DEPT_REF_ID   = A.TGT_DEPT_ID
LEFT OUTER JOIN COM_EMP_INFO    C
                            ON  C.EMP_REF_ID    = A.TGT_EMP_ID
LEFT OUTER JOIN EST_POSITION_CLS    D
                                ON  D.POS_CLS_ID    = A.TGT_POS_CLS_ID
LEFT OUTER JOIN EST_POSITION_DUT    E
                                ON  E.POS_DUT_ID    = A.TGT_POS_DUT_ID
LEFT OUTER JOIN EST_POSITION_GRP    F
                                ON  F.POS_GRP_ID    = A.TGT_POS_GRP_ID
LEFT OUTER JOIN EST_POSITION_RNK    G
                                ON  G.POS_RNK_ID    = A.TGT_POS_RNK_ID
LEFT OUTER JOIN EST_BIAS_GROUP      H
                                ON  H.COMP_ID       = A.COMP_ID
                                AND H.EST_ID        = A.EST_ID
                                AND H.BIAS_GRP_ID   = A.BIAS_GRP_ID
WHERE   (A.COMP_ID     = @COMP_ID OR @COMP_ID = 0)
    AND (A.EST_ID      = @EST_ID  OR @EST_ID      =''    )
    AND (A.ESTTERM_REF_ID      = @ESTTERM_REF_ID    OR @ESTTERM_REF_ID  = 0)
    AND (A.ESTTERM_SUB_ID      = @ESTTERM_SUB_ID    OR @ESTTERM_SUB_ID  = 0)
    AND (A.ESTTERM_STEP_ID     = @ESTTERM_STEP_ID   OR @ESTTERM_STEP_ID = 0)
    AND (A.BIAS_GRP_ID         = @BIAS_GRP_ID       OR @BIAS_GRP_ID     = 0)
ORDER BY A.COMP_ID, A.EST_ID, A.ESTTERM_REF_ID, A.ESTTERM_SUB_ID, A.ESTTERM_STEP_ID, A.BIAS_GRP_ID, A.TGT_DEPT_ID, C.EMP_NAME
";
            IDbDataParameter[] dtParam = CreateDataParameters(6);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            dtParam[3].Value = estterm_sub_id;
            dtParam[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            dtParam[4].Value = estterm_step_id;
            dtParam[5] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[5].Value = bias_grp_id;

            return DbAgentObj.FillDataSet(strQuery, "BIAS_DATA", null, dtParam, CommandType.Text).Tables[0];
        }

        public DataTable GetBiasGroup(object comp_id
                                    , object est_id
                                    , object use_yn)
        {
            string strQuery = @"
SELECT  COMP_ID
       ,EST_ID
       ,BIAS_GRP_ID
       ,BIAS_GRP_CD
       ,BIAS_GRP_NM
       ,BIAS_GRP_DESC
       ,USE_YN
FROM EST_BIAS_GROUP
WHERE   (COMP_ID     = @COMP_ID OR @COMP_ID = 0)
    AND (EST_ID      = @EST_ID  OR @EST_ID      =''    )
    AND (USE_YN      = @USE_YN  OR @USE_YN      =''    )
ORDER BY COMP_ID, EST_ID, BIAS_GRP_ID
";
            IDbDataParameter[] dtParam = CreateDataParameters(3);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            dtParam[2].Value = use_yn;

            return DbAgentObj.FillDataSet(strQuery, "BIAS_GROUP", null, dtParam, CommandType.Text).Tables[0];
        }

        public bool InsertInitBiasColumnData(IDbConnection conn, IDbTransaction trx, object comp_id, object est_id, object reg_user)
        {
            string strQuery = @"
INSERT INTO EST_BIAS_COL 
    (COMP_ID,       EST_ID,     SEQ,        VISIBLE_YN,     COL_ORDER
    ,COL_KEY,       COL_NAME,   COL_DESC,   COL_WIDTH,      COL_TYPE
    ,COL_ALIGN,     DATA_TYPE,  PROC_NAME,  PROC_TYPE,      USE_YN
    ,CREATE_DATE,   CREATE_USER)
VALUES
    (@COMP_ID,      @EST_ID,    @SEQ,       @VISIBLE_YN,    @COL_ORDER
    ,@COL_KEY,      @COL_NAME,  @COL_DESC,  @COL_WIDTH,     @COL_TYPE
    ,@COL_ALIGN,    @DATA_TYPE, @PROC_NAME, @PROC_TYPE,     @USE_YN
    ,GETDATE(),     @CREATE_USER)
";

            IDbDataParameter[] dtParam;
            int i = 1;
            int rtnCnt = 0;
            foreach (DataRow dr in FNBiasColumnInitData().Rows)
            {
                dtParam = CreateDataParameters(16);
                dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                dtParam[0].Value = comp_id;
                dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                dtParam[1].Value = est_id;
                dtParam[2] = CreateDataParameter("@SEQ", SqlDbType.Int);
                dtParam[2].Value = i;
                dtParam[3] = CreateDataParameter("@VISIBLE_YN", SqlDbType.VarChar);
                dtParam[3].Value = dr["VISIBLE_YN"];
                dtParam[4] = CreateDataParameter("@COL_ORDER", SqlDbType.Int);
                dtParam[4].Value = dr["COL_ORDER"];

                dtParam[5] = CreateDataParameter("@COL_KEY", SqlDbType.VarChar);
                dtParam[5].Value = dr["COL_KEY"];
                dtParam[6] = CreateDataParameter("@COL_NAME", SqlDbType.VarChar);
                dtParam[6].Value = dr["COL_NAME"];
                dtParam[7] = CreateDataParameter("@COL_DESC", SqlDbType.VarChar);
                dtParam[7].Value = dr["COL_DESC"];
                dtParam[8] = CreateDataParameter("@COL_WIDTH", SqlDbType.Int);
                dtParam[8].Value = dr["COL_WIDTH"];
                dtParam[9] = CreateDataParameter("@COL_TYPE", SqlDbType.VarChar);
                dtParam[9].Value = dr["COL_TYPE"];

                dtParam[10] = CreateDataParameter("@COL_ALIGN", SqlDbType.VarChar);
                dtParam[10].Value = dr["COL_ALIGN"];
                dtParam[11] = CreateDataParameter("@DATA_TYPE", SqlDbType.VarChar);
                dtParam[11].Value = dr["DATA_TYPE"];
                dtParam[12] = CreateDataParameter("@PROC_NAME", SqlDbType.VarChar);
                dtParam[12].Value = dr["PROC_NAME"];
                dtParam[13] = CreateDataParameter("@PROC_TYPE", SqlDbType.VarChar);
                dtParam[13].Value = dr["PROC_TYPE"];
                dtParam[14] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
                dtParam[14].Value = dr["USE_YN"];

                dtParam[15] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
                dtParam[15].Value = reg_user;

                rtnCnt += DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, dtParam, CommandType.Text);
                i++;
            }

            if (rtnCnt == 24)
                return true;
            return false;
        }

        private DataTable FNBiasColumnInitData()
        {
            DataTable dtColumns = new DataTable();
            dtColumns.Columns.Add("VISIBLE_YN", typeof(string));
            dtColumns.Columns.Add("COL_ORDER", typeof(int));
            dtColumns.Columns.Add("COL_KEY", typeof(string));
            dtColumns.Columns.Add("COL_NAME", typeof(string));
            dtColumns.Columns.Add("COL_DESC", typeof(string));

            dtColumns.Columns.Add("COL_WIDTH", typeof(int));
            dtColumns.Columns.Add("COL_ALIGN", typeof(string));
            dtColumns.Columns.Add("COL_TYPE", typeof(string));
            dtColumns.Columns.Add("DATA_TYPE", typeof(string));
            dtColumns.Columns.Add("PROC_NAME", typeof(string));

            dtColumns.Columns.Add("PROC_TYPE", typeof(string));
            dtColumns.Columns.Add("USE_YN", typeof(string));

            object[] objList;
            objList = new object[]{"N", 1, "BIAS_GRP_ID", "Bias Group ID", "Bias 그룹 아이디", 0, "LEFT", "FIXEDKEY", "System.Int32", "", "N", "Y"};
            dtColumns.Rows.Add(objList);
            objList = new object[] { "Y", 2, "BIAS_GRP_NM", "Bias Group", "Bias 그룹 명칭", 100, "LEFT", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 3, "TGT_DEPT_ID", "피평가자 부서코드", "피평가자 부서코드", 0, "CENTER", "FIXEDKEY", "System.Int32", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "Y", 4, "TGT_DEPT_NAME", "피평가자 부서명", "피평가자 부서명", 100, "LEFT", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 5, "TGT_EMP_ID", "피평가자 사번", "피평가자 사번", 0, "CENTER", "FIXEDKEY", "System.Int32", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "Y", 6, "TGT_EMP_NAME", "피평가자명", "피평가자명", 60, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);

            objList = new object[] { "N", 7, "TGT_POS_CLS_ID", "직급ID", "직급ID", 0, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "Y", 8, "TGT_POS_CLS_NAME", "직급", "직급", 60, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 9, "TGT_POS_DUT_ID", "직책ID", "직책ID", 0, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "Y", 10, "TGT_POS_DUT_NAME", "직책", "직책", 60, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 11, "TGT_POS_GRP_ID", "직군ID", "직군ID", 0, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "Y", 12, "TGT_POS_GRP_NAME", "직군", "직군", 60, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 13, "TGT_POS_RNK_ID", "직위ID", "직위ID", 0, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "Y", 14, "TGT_POS_RNK_NAME", "직위", "직위", 60, "CENTER", "FIXEDKEY", "System.String", "", "N", "Y" };
            dtColumns.Rows.Add(objList);

            objList = new object[] { "N", 15, "COL1", "사용자정의1", "사용자정의1", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 16, "COL2", "사용자정의2", "사용자정의2", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 17, "COL3", "사용자정의3", "사용자정의3", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 18, "COL4", "사용자정의4", "사용자정의4", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 19, "COL5", "사용자정의5", "사용자정의5", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 20, "COL6", "사용자정의6", "사용자정의6", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 21, "COL7", "사용자정의7", "사용자정의7", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 22, "COL8", "사용자정의8", "사용자정의8", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 23, "COL9", "사용자정의9", "사용자정의9", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);
            objList = new object[] { "N", 24, "COL10", "사용자정의10", "사용자정의10", 0, "LEFT", "USERKEY", "", "", "N", "N" };
            dtColumns.Rows.Add(objList);

            return dtColumns;            
        }

        public bool DeleteBiasGroup(IDbConnection conn
                                    , IDbTransaction trx
                                    , object comp_id
                                    , object est_id
                                    , object bias_grp_id)
        {
            string strQuery = "SELECT TOP 1 COMP_ID FROM EST_BIAS_GRP_USER WHERE COMP_ID = @COMP_ID AND EST_ID = @EST_ID AND BIAS_GRP_ID = @BIAS_GRP_ID";
            IDbDataParameter[] dtParam = CreateDataParameters(3);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[2].Value = bias_grp_id;

            if (DbAgentObj.ExecuteScalar(conn, trx, strQuery, dtParam, CommandType.Text) != null)
            {
                rtnMSG = "그룹에 매핑된 사원이 존재합니다. 삭제할 수 없습니다.";
                return false;
            }

            strQuery = @"
DELETE FROM EST_BIAS_GROUP
WHERE   COMP_ID     = @COMP_ID
    AND EST_ID      = @EST_ID
    AND BIAS_GRP_ID = @BIAS_GRP_ID

SELECT @@ROWCOUNT
";
            dtParam = null;
            dtParam = CreateDataParameters(3);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[2].Value = bias_grp_id;

            if (DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(conn, trx, strQuery, dtParam, CommandType.Text).ToString()) > 0)
                return true;
            else
                return false;
        }

        public bool InsertBiasData(IDbConnection conn, IDbTransaction trx, object comp_id, object est_id, object estterm_ref_id, object estterm_sub_id, object estterm_step_id, object bias_grp_id, DataTable insertDT, int reg_user)
        {
            string strQuery = @"
INSERT INTO EST_BIAS_DATA
        (COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, BIAS_GRP_ID";
            foreach(DataColumn dc in insertDT.Columns)
            {
                strQuery += ", " + dc.ColumnName;
            }
            strQuery += @", CREATE_DATE, CREATE_USER)
SELECT  @COMP_ID, @EST_ID, @ESTTERM_REF_ID, @ESTTERM_SUB_ID, @ESTTERM_STEP_ID, @BIAS_GRP_ID";
            foreach (DataColumn dc in insertDT.Columns)
            {
                strQuery += ", @" + dc.ColumnName;
            }
            strQuery += ", GETDATE(), @REG_USER";
            IDbDataParameter[] dtParam;
            int rtnCnt = 0;
            foreach (DataRow dr in insertDT.Rows)
            {
                dtParam = null;
                dtParam = CreateDataParameters(7 + insertDT.Columns.Count);
                dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                dtParam[0].Value = comp_id;
                dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                dtParam[1].Value = est_id;
                dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                dtParam[2].Value = estterm_ref_id;
                dtParam[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
                dtParam[3].Value = estterm_sub_id;
                dtParam[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
                dtParam[4].Value = estterm_step_id;
                dtParam[5] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
                dtParam[5].Value = bias_grp_id;
                dtParam[6] = CreateDataParameter("@REG_USER", SqlDbType.Int);
                dtParam[6].Value = reg_user;
                int i = 0;
                foreach (DataColumn dc in insertDT.Columns)
                {
                    dtParam[7 + i] = CreateDataParameter("@" + dc.ColumnName, (dc.ColumnName == "POINT" ? SqlDbType.Decimal : (dc.ColumnName.Substring(0, 3) == "COL" || dc.ColumnName.Substring(0, 8) == "TGT_POS_" ? SqlDbType.NVarChar : SqlDbType.Int)));
                    dtParam[7 + i].Value = dr[dc.ColumnName];
                    i++;
                }


                string SQL_query = strQuery;
                string Oracle_query = strQuery + " FROM DUAL";


                rtnCnt += DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(SQL_query, Oracle_query), dtParam, CommandType.Text);
            }

            return true;
        }

        public bool InsertBiasGroupEmp(IDbConnection conn, IDbTransaction trx, object comp_id, object est_id, object estterm_ref_id, object bias_grp_id, DataTable insertDT, int reg_user)
        {
            string strQuery = @"
INSERT INTO EST_BIAS_GRP_USER
        (COMP_ID, EST_ID, ESTTERM_REF_ID, BIAS_GRP_ID, DEPT_REF_ID, EMP_REF_ID, CREATE_DATE, CREATE_USER)
SELECT  @COMP_ID, @EST_ID, @ESTTERM_REF_ID, @BIAS_GRP_ID, DEPT_REF_ID, @EMP_REF_ID, GETDATE(), @REG_USER
FROM REL_DEPT_EMP
WHERE   EMP_REF_ID  = @EMP_REF_ID
";
            IDbDataParameter[] dtParam;
            int rtnCnt = 0;
            foreach(DataRow dr in insertDT.Rows)
            {
                dtParam = null;
                dtParam = CreateDataParameters(6);
                dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                dtParam[0].Value = comp_id;
                dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                dtParam[1].Value = est_id;
                dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                dtParam[2].Value = estterm_ref_id;
                dtParam[3] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
                dtParam[3].Value = bias_grp_id;
                dtParam[4] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                dtParam[4].Value = dr["EMP_REF_ID"];
                dtParam[5] = CreateDataParameter("@REG_USER", SqlDbType.Int);
                dtParam[5].Value = reg_user;

                rtnCnt += DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, dtParam, CommandType.Text);
            }

            return true;
        }

        public int DeleteBiasData(IDbConnection conn, IDbTransaction trx, object comp_id, object est_id, object estterm_ref_id, object estterm_sub_id, object estterm_step_id, object bias_grp_id)
        {
            string strQuery = @"
DELETE FROM EST_BIAS_DATA
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND BIAS_GRP_ID     = @BIAS_GRP_ID
";
            IDbDataParameter[] dtParam = CreateDataParameters(6);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            dtParam[3].Value = estterm_sub_id;
            dtParam[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            dtParam[4].Value = estterm_step_id;
            dtParam[5] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[5].Value = bias_grp_id;

            return DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, dtParam, CommandType.Text);
        }

        public int DeleteBiasGroupEmp(IDbConnection conn, IDbTransaction trx, object comp_id, object est_id, object estterm_ref_id, object bias_grp_id)
        {
            string strQuery = @"
DELETE FROM EST_BIAS_GRP_USER
WHERE   COMP_ID         = @COMP_ID
    AND EST_ID          = @EST_ID
    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND BIAS_GRP_ID     = @BIAS_GRP_ID
";
            IDbDataParameter[] dtParam = CreateDataParameters(4);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[3].Value = bias_grp_id;

            return DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, dtParam, CommandType.Text);
        }

        public bool ConfirmBiasPoint(IDbConnection conn
                                    , IDbTransaction trx
                                    , object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id
                                    , object bias_grp_id
                                    , object reg_user)
        {
            string strQuery = @"
UPDATE  EST_DATA
    SET
         POINT          = ISNULL(B.POINT, 0)
        ,POINT_DATE     = GETDATE()
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @UPDATE_USER
FROM    EST_DATA    A
INNER JOIN EST_BIAS_DATA    B
                        ON  B.COMP_ID           = A.COMP_ID
                        AND B.EST_ID            = A.EST_ID
                        AND B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                        AND B.ESTTERM_SUB_ID    = A.ESTTERM_SUB_ID
                        AND B.ESTTERM_STEP_ID   = A.ESTTERM_STEP_ID
                        AND B.BIAS_GRP_ID       = @BIAS_GRP_ID
                        AND B.TGT_DEPT_ID       = A.TGT_DEPT_ID
                        AND B.TGT_EMP_ID        = A.TGT_EMP_ID
WHERE   A.COMP_ID         = @COMP_ID
    AND A.EST_ID          = @EST_ID
    AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
";
            IDbDataParameter[] dtParam = CreateDataParameters(7);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            dtParam[3].Value = estterm_sub_id;
            dtParam[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            dtParam[4].Value = estterm_step_id;
            dtParam[5] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[5].Value = bias_grp_id;
            dtParam[6] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            dtParam[6].Value = reg_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, dtParam, CommandType.Text) > 0)
                return true;
            return false;
        }

        public bool UpdateBiasPoint(IDbConnection conn
                                    , IDbTransaction trx
                                    , object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id
                                    , object bias_grp_id
                                    , object bias_apply_column
                                    , object reg_user)
        {
            string strQuery = @"
    UPDATE  EST_BIAS_DATA
        SET
             POINT     = CONVERT(NUMERIC(17, 4), ISNULL(" + bias_apply_column.ToString() + ", 0))";
                strQuery += @" 
            ,UPDATE_DATE    = GETDATE()
            ,UPDATE_USER    = @UPDATE_USER
    WHERE   COMP_ID         = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND BIAS_GRP_ID     = @BIAS_GRP_ID
    ";
            IDbDataParameter[] dtParam = CreateDataParameters(7);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            dtParam[2].Value = estterm_ref_id;
            dtParam[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            dtParam[3].Value = estterm_sub_id;
            dtParam[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            dtParam[4].Value = estterm_step_id;
            dtParam[5] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            dtParam[5].Value = bias_grp_id;
            dtParam[6] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            dtParam[6].Value = reg_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, dtParam, CommandType.Text) > 0)
                return true;
            return false;
        }

        public bool UpdateBiasColumn(IDbConnection conn
                                    ,IDbTransaction trx
                                    ,object comp_id
                                    , object est_id
                                    , object seq
                                    , object visible_yn
                                    , object col_order
                                    , object col_key
                                    , object col_name
                                    , object col_desc
                                    , object col_type
                                    , object col_width
                                    , object col_align
                                    , object data_type
                                    , object proc_name
                                    , object proc_type
                                    , object use_yn
                                    , object reg_user)
        {
            string strQuery = @"
UPDATE  EST_BIAS_COL
    SET
         VISIBLE_YN     = @VISIBLE_YN
        ,COL_ORDER      = @COL_ORDER
        ,COL_KEY        = @COL_KEY
        ,COL_NAME       = @COL_NAME   
        ,COL_DESC       = @COL_DESC   
        ,COL_TYPE       = @COL_TYPE   
        ,COL_WIDTH      = @COL_WIDTH  
        ,COL_ALIGN      = @COL_ALIGN  
        ,DATA_TYPE      = @DATA_TYPE  
        ,PROC_NAME      = @PROC_NAME  
        ,PROC_TYPE      = @PROC_TYPE  
        ,USE_YN         = @USE_YN     
        ,UPDATE_DATE    = GETDATE()
        ,UPDATE_USER    = @UPDATE_USER
WHERE   COMP_ID     = @COMP_ID
    AND EST_ID      = @EST_ID
    AND SEQ         = @SEQ
";
            IDbDataParameter[] dtParam = CreateDataParameters(16);
            dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            dtParam[0].Value = comp_id;
            dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            dtParam[1].Value = est_id;
            dtParam[2] = CreateDataParameter("@SEQ", SqlDbType.Int);
            dtParam[2].Value = seq;
            dtParam[3] = CreateDataParameter("@VISIBLE_YN", SqlDbType.VarChar);
            dtParam[3].Value = visible_yn;
            dtParam[4] = CreateDataParameter("@COL_ORDER", SqlDbType.Int);
            dtParam[4].Value = col_order;

            dtParam[5] = CreateDataParameter("@COL_KEY", SqlDbType.VarChar);
            dtParam[5].Value = col_key;
            dtParam[6] = CreateDataParameter("@COL_NAME", SqlDbType.VarChar);
            dtParam[6].Value = col_name;
            dtParam[7] = CreateDataParameter("@COL_DESC", SqlDbType.VarChar);
            dtParam[7].Value = col_desc;
            dtParam[8] = CreateDataParameter("@COL_TYPE", SqlDbType.VarChar);
            dtParam[8].Value = col_type;
            dtParam[9] = CreateDataParameter("@COL_WIDTH", SqlDbType.Int);
            dtParam[9].Value = col_width;

            dtParam[10] = CreateDataParameter("@COL_ALIGN", SqlDbType.VarChar);
            dtParam[10].Value = col_align;
            dtParam[11] = CreateDataParameter("@DATA_TYPE", SqlDbType.VarChar);
            dtParam[11].Value = data_type;
            dtParam[12] = CreateDataParameter("@PROC_NAME", SqlDbType.VarChar);
            dtParam[12].Value = proc_name;
            dtParam[13] = CreateDataParameter("@PROC_TYPE", SqlDbType.VarChar);
            dtParam[13].Value = proc_type;
            dtParam[14] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            dtParam[14].Value = use_yn;

            dtParam[15] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            dtParam[15].Value = reg_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, dtParam, CommandType.Text) > 0)
                return true;
            return false;
        }

        public int SaveBiasGroup(IDbConnection conn
                                    , IDbTransaction trx
                                    , object comp_id
                                    , object est_id
                                    , object bias_grp_id
                                    , object bias_grp_cd
                                    , object bias_grp_nm
                                    , object bias_grp_desc
                                    , object use_yn
                                    , object reg_emp_id)
        {
            //그룹코드 중복확인
            string strQuery = string.Empty;
            IDbDataParameter[] dtParam = null;

            if (DataTypeUtility.GetToInt32(bias_grp_id) == 0) //신규
            {
                strQuery = @"
SELECT  COMP_ID
FROM    EST_BIAS_GROUP
WHERE   COMP_ID = @COMP_ID
    AND EST_ID  = @EST_ID
    AND BIAS_GRP_CD = @BIAS_GRP_CD

SELECT @@ROWCOUNT
";

                dtParam = CreateDataParameters(3);
                dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                dtParam[0].Value = comp_id;
                dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                dtParam[1].Value = est_id;
                dtParam[2] = CreateDataParameter("@BIAS_GRP_CD", SqlDbType.VarChar);
                dtParam[2].Value = bias_grp_cd;

                if (DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(conn, trx, strQuery, dtParam, CommandType.Text)) > 0)
                    return -1;

                strQuery = @"
INSERT INTO EST_BIAS_GROUP
        (COMP_ID, EST_ID, BIAS_GRP_CD, BIAS_GRP_NM, BIAS_GRP_DESC, USE_YN, CREATE_DATE, CREATE_USER)
    VALUES
        (@COMP_ID, @EST_ID, @BIAS_GRP_CD, @BIAS_GRP_NM, @BIAS_GRP_DESC, @USE_YN, GETDATE(), @CREATE_USER)

SELECT  BIAS_GRP_ID
FROM    EST_BIAS_GROUP
WHERE   COMP_ID     = @COMP_ID
    AND EST_ID      = @EST_ID
    AND BIAS_GRP_CD = @BIAS_GRP_CD
";
                dtParam = null;
                dtParam = CreateDataParameters(8);
                dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                dtParam[0].Value = comp_id;
                dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                dtParam[1].Value = est_id;
                dtParam[2] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
                dtParam[2].Value = bias_grp_id;
                dtParam[3] = CreateDataParameter("@BIAS_GRP_CD", SqlDbType.VarChar);
                dtParam[3].Value = bias_grp_cd;
                dtParam[4] = CreateDataParameter("@BIAS_GRP_NM", SqlDbType.VarChar);
                dtParam[4].Value = bias_grp_nm;
                dtParam[5] = CreateDataParameter("@BIAS_GRP_DESC", SqlDbType.VarChar);
                dtParam[5].Value = bias_grp_desc;
                dtParam[6] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
                dtParam[6].Value = use_yn;
                dtParam[7] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
                dtParam[7].Value = reg_emp_id;

                return DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(conn, trx, strQuery, dtParam, CommandType.Text).ToString());
            }
            else//수정
            {
                strQuery = @"
UPDATE EST_BIAS_GROUP
    SET
        BIAS_GRP_CD     = @BIAS_GRP_CD
    , BIAS_GRP_NM     = @BIAS_GRP_NM
    , BIAS_GRP_DESC   = @BIAS_GRP_DESC
    , USE_YN          = @USE_YN
    , UPDATE_DATE     = GETDATE()
    , UPDATE_USER     = @UPDATE_USER
WHERE
        COMP_ID     = @COMP_ID
    AND EST_ID      = @EST_ID
    AND BIAS_GRP_ID = @BIAS_GRP_ID

SELECT @@ROWCOUNT
";
                dtParam = null;
                dtParam = CreateDataParameters(8);
                dtParam[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
                dtParam[0].Value = comp_id;
                dtParam[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
                dtParam[1].Value = est_id;
                dtParam[2] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
                dtParam[2].Value = bias_grp_id;
                dtParam[3] = CreateDataParameter("@BIAS_GRP_CD", SqlDbType.VarChar);
                dtParam[3].Value = bias_grp_cd;
                dtParam[4] = CreateDataParameter("@BIAS_GRP_NM", SqlDbType.VarChar);
                dtParam[4].Value = bias_grp_nm;
                dtParam[5] = CreateDataParameter("@BIAS_GRP_DESC", SqlDbType.VarChar);
                dtParam[5].Value = bias_grp_desc;
                dtParam[6] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
                dtParam[6].Value = use_yn;
                dtParam[7] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
                dtParam[7].Value = reg_emp_id;

                if (DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(conn, trx, strQuery, dtParam, CommandType.Text).ToString()) > 0)
                    return DataTypeUtility.GetToInt32(bias_grp_id);
                else
                    return 0;
            }
        }
                                        
    }
}
