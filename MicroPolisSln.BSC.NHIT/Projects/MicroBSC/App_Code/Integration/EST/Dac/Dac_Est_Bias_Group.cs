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
    public class Dac_Est_Bias_Group : DbAgentBase
    {
        public Dac_Est_Bias_Group()
        {
        }
        

        public int Insert_DB(IDbConnection conn
                            , IDbTransaction trx
                            , object comp_id
                            , object est_id
                            , object bias_grp_id
                            , object bias_grp_cd
                            , object bias_grp_nm
                            , object bias_grp_desc
                            , object use_yn
                            , object create_user_ref_id)
        {
            string query = @"
INSERT INTO EST_BIAS_GROUP
        (COMP_ID, EST_ID, BIAS_GRP_ID, BIAS_GRP_CD, BIAS_GRP_NM, BIAS_GRP_DESC, USE_YN, CREATE_DATE, CREATE_USER)
    VALUES
        (@COMP_ID, @EST_ID, @BIAS_GRP_ID, @BIAS_GRP_CD, @BIAS_GRP_NM, @BIAS_GRP_DESC, @USE_YN, GETDATE(), @CREATE_USER)

";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@BIAS_GRP_CD", SqlDbType.NVarChar);
            paramArray[2].Value = bias_grp_cd;
            paramArray[3] = CreateDataParameter("@BIAS_GRP_NM", SqlDbType.NVarChar);
            paramArray[3].Value = bias_grp_nm;
            paramArray[4] = CreateDataParameter("@BIAS_GRP_DESC", SqlDbType.NVarChar);
            paramArray[4].Value = bias_grp_desc;
            paramArray[5] = CreateDataParameter("@USE_YN", SqlDbType.NChar);
            paramArray[5].Value = use_yn;
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[6].Value = create_user_ref_id;
            paramArray[7] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            paramArray[7].Value = bias_grp_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }

        public int Update_DB(IDbConnection conn
                                            , IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object bias_grp_id
                                            , object bias_grp_cd
                                            , object bias_grp_nm
                                            , object bias_grp_desc
                                            , object use_yn
                                            , object update_user_ref_id)
        {
            string query = @"
UPDATE EST_BIAS_GROUP
 SET  COMP_ID     = @COMP_ID
    , EST_ID      = @EST_ID
    , BIAS_GRP_CD     = @BIAS_GRP_CD
    , BIAS_GRP_NM     = @BIAS_GRP_NM
    , BIAS_GRP_DESC   = @BIAS_GRP_DESC
    , USE_YN          = @USE_YN
    , UPDATE_DATE     = GETDATE()
    , UPDATE_USER     = @UPDATE_USER
WHERE BIAS_GRP_ID = @BIAS_GRP_ID

";
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            paramArray[2].Value = bias_grp_id;
            paramArray[3] = CreateDataParameter("@BIAS_GRP_CD", SqlDbType.Int);
            paramArray[3].Value = bias_grp_cd;
            paramArray[4] = CreateDataParameter("@BIAS_GRP_NM", SqlDbType.Int);
            paramArray[4].Value = bias_grp_nm;
            paramArray[5] = CreateDataParameter("@BIAS_GRP_DESC", SqlDbType.Int);
            paramArray[5].Value = bias_grp_desc;
            paramArray[6] = CreateDataParameter("@USE_YN", SqlDbType.Int);
            paramArray[6].Value = use_yn;
            paramArray[7] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[7].Value = update_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Delete_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object bias_grp_id)
        {
            string query = @"
DELETE FROM     EST_BIAS_GROUP
  WHERE  BIAS_GRP_ID         = @BIAS_GRP_ID
  
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@BIAS_GRP_ID", SqlDbType.Int);
            paramArray[0].Value = bias_grp_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public DataTable Select_DB(object comp_id
                                            , object est_id
                                            , object bias_grp_cd)
        {
            string query = @"
SELECT  COMP_ID
, EST_ID
, BIAS_GRP_ID
, BIAS_GRP_CD
, BIAS_GRP_NM
, BIAS_GRP_DESC
, USE_YN
, CREATE_DATE
, CREATE_USER
FROM    EST_BIAS_GROUP
WHERE   COMP_ID     = @COMP_ID
    AND EST_ID      = @EST_ID
    AND BIAS_GRP_CD = @BIAS_GRP_CD
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@BIAS_GRP_CD", SqlDbType.Int);
            paramArray[2].Value = bias_grp_cd;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_BIAS_GROUP", null, paramArray).Tables[0];

            return dt;
        }


        public int SelectMax_DB(IDbConnection conn
                                            , IDbTransaction trx)
        {
            string query = @"
SELECT  ISNULL(MAX(BIAS_GRP_ID), 0) AS BIAS_GRP_ID
FROM    EST_BIAS_GROUP

";
            object objMax = DbAgentObj.ExecuteScalar(conn, trx, query, null, CommandType.Text);
            return DataTypeUtility.GetToInt32(objMax) + 1;
        }


        public DataSet SelectBiasGroupEmp_DB(object comp_id
                                           , object est_id
                                           , object estterm_ref_id
                                           , object bias_grp_id)
        {
//            string strQuery = @"
//
//SELECT   B.DEPT_REF_ID      AS SFID
//        ,B.UP_DEPT_ID   AS PTID
//        ,B.DEPT_NAME    AS NAME
//       -- ,B.DEPT_TYPE    AS LVL
//        ,B.DEPT_LEVEL  +1    AS LVL
//        ,ISNULL(D.EMP_REF_ID, 0) AS EMP_REF_ID
//        ,ISNULL(D.EMP_NAME, '') AS EMP_NAME
//        ,CASE WHEN ISNULL(E.BIAS_GRP_ID, 0) = @BIAS_GRP_ID THEN 'Y' ELSE 'N' END AS ISCHECK
//        ,CASE WHEN F.YEARLY_CLOSE_YN = 1 THEN 'F' ELSE CASE WHEN ISNULL(E.BIAS_GRP_ID, 0) = @BIAS_GRP_ID THEN 'Y' ELSE CASE WHEN ISNULL(E.BIAS_GRP_ID, 0) = 0 THEN 'Y' ELSE 'N' END END END AS ISENABLED
//FROM COM_DEPT_INFO   B
//                            
//LEFT OUTER JOIN REL_DEPT_EMP	C
//							ON	C.DEPT_REF_ID	= B.DEPT_REF_ID
//LEFT OUTER JOIN COM_EMP_INFO    D
//                            ON  D.EMP_REF_ID    = C.EMP_REF_ID
//LEFT OUTER JOIN EST_BIAS_GRP_USER   E
//                                ON  E.COMP_ID           = @COMP_ID
//                                AND E.EST_ID            = @EST_ID
//                                AND E.ESTTERM_REF_ID    = @ESTTERM_REF_ID
//                                AND E.EMP_REF_ID        = D.EMP_REF_ID
//LEFT OUTER JOIN EST_TERM_INFO	F
//							ON	F.ESTTERM_REF_ID	= @ESTTERM_REF_ID
//WHERE	C.REL_STATUS > CASE WHEN F.YEARLY_CLOSE_YN = 0 THEN  0 ELSE -1 END
//ORDER BY B.SORT_ORDER, B.DEPT_REF_ID, D.EMP_NAME
//";

            string strQuery = @"
SELECT   B.COM_DEPT_REF_ID      AS SFID
        ,B.COM_UP_DEPT_ID   AS PTID
        ,B.COM_DEPT_NAME    AS NAME
       -- ,B.DEPT_TYPE    AS LVL
        ,D.DEPT_LEVEL  +1    AS LVL
        ,NVL(B.EMP_REF_ID, 0) AS EMP_REF_ID
        ,NVL(B.EMP_NAME, '') AS EMP_NAME
        ,CASE WHEN NVL(E.BIAS_GRP_ID, 0) = @BIAS_GRP_ID THEN 'Y' ELSE 'N' END AS ISCHECK
        ,CASE WHEN F.YEARLY_CLOSE_YN = 1 THEN 'F' ELSE CASE WHEN NVL(E.BIAS_GRP_ID, 0) = @BIAS_GRP_ID THEN 'Y' ELSE CASE WHEN NVL(E.BIAS_GRP_ID, 0) = 0 THEN 'Y' ELSE 'N' END END END AS ISENABLED
FROM VIW_EMP_COMDEPT   B
LEFT OUTER JOIN REL_DEPT_EMP	C
							ON	C.DEPT_REF_ID	= B.COM_DEPT_REF_ID AND C.EMP_REF_ID = B.EMP_REF_ID
LEFT OUTER JOIN VIW_COM_DEPT_INFO_BYTREE D
                            ON  D.DEPT_REF_ID = B.COM_DEPT_REF_ID
LEFT OUTER JOIN EST_BIAS_GRP_USER   E
                                ON  E.COMP_ID           = @COMP_ID
                                AND E.EST_ID            = @EST_ID
                                AND E.ESTTERM_REF_ID    = @ESTTERM_REF_ID
                                AND E.EMP_REF_ID        = B.EMP_REF_ID
LEFT OUTER JOIN EST_TERM_INFO	F
							ON	F.ESTTERM_REF_ID	= @ESTTERM_REF_ID
WHERE	C.REL_STATUS > CASE WHEN F.YEARLY_CLOSE_YN = 0 THEN  0 ELSE -1 END
ORDER BY D.SORT_ORD, B.EMP_NAME ";

            //strQuery = string.Format(strQuery, root_dept_ref_id);

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
    }
}
