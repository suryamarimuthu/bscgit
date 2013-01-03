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
    public class Dac_Est_Data : DbAgentBase
    {
        public Dac_Est_Data()
        {
        }

        public DataTable SelectData_DB(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id
                                    , object direction_type)
        {
            string query = @"
SELECT  COMP_ID
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
       ,POINT_ORG
       ,POINT_ORG_DATE
       ,POINT_AVG
       ,POINT_AVG_DATE
       ,POINT_STD
       ,POINT_STD_DATE
       ,POINT_CTRL_ORG
       ,POINT_CTRL_ORG_DATE
       ,GRADE_CTRL_ORG_ID
       ,GRADE_CTRL_ORG_DATE
       ,POINT
       ,POINT_DATE
       ,GRADE_ID
       ,GRADE_DATE
       ,GRADE_TO_POINT
       ,GRADE_TO_POINT_DATE
       ,STATUS_ID
       ,STATUS_DATE
       ,CREATE_DATE
       ,CREATE_USER
FROM EST_DATA
WHERE COMP_ID           = @COMP_ID
  AND EST_ID            = @EST_ID
  AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
  AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
  AND ESTTERM_STEP_ID   = @ESTTERM_STEP_ID
  AND (DIRECTION_TYPE   = @DIRECTION_TYPE       OR   @DIRECTION_TYPE     =''    )
";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

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
            paramArray[5] = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[5].Value = direction_type;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectData_DB(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id
                                    , object direction_type
                                    ,object est_emp_id
                                    ,object tgt_emp_id)
        {
            string query = @"
SELECT  COMP_ID
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
       ,POINT_ORG
       ,POINT_ORG_DATE
       ,POINT_AVG
       ,POINT_AVG_DATE
       ,POINT_STD
       ,POINT_STD_DATE
       ,POINT_CTRL_ORG
       ,POINT_CTRL_ORG_DATE
       ,GRADE_CTRL_ORG_ID
       ,GRADE_CTRL_ORG_DATE
       ,POINT
       ,POINT_DATE
       ,GRADE_ID
       ,GRADE_DATE
       ,GRADE_TO_POINT
       ,GRADE_TO_POINT_DATE
       ,STATUS_ID
       ,STATUS_DATE
       ,CREATE_DATE
       ,CREATE_USER
FROM EST_DATA
WHERE COMP_ID           = @COMP_ID
  AND EST_ID            = @EST_ID
  AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
  AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
  AND (ESTTERM_STEP_ID  = @ESTTERM_STEP_ID      OR   @ESTTERM_STEP_ID    = 0    )
  AND (DIRECTION_TYPE   = @DIRECTION_TYPE       OR   @DIRECTION_TYPE     =''    )
  AND (EST_EMP_ID       = @EST_EMP_ID           OR   @EST_EMP_ID         = 0    )
  AND (TGT_EMP_ID       = @TGT_EMP_ID           OR   @TGT_EMP_ID         = 0    )
";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

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
            paramArray[5] = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[5].Value = direction_type;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.NVarChar);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.NVarChar);
            paramArray[7].Value = tgt_emp_id;


            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectGraph_DB(object comp_id
                                    , object est_id
                                    , object estterm_ref_id
                                    , object estterm_sub_id
                                    , object estterm_step_id
                                    , object tgt_emp_id
                                    , object estid_1
                                    , object estid_2
                                    , object yid1
                                    , object yid2
                                    , object yid3)
        {
            string query = @"
SELECT   A.POINT        AS POINT_1
        ,A.GRADE_ID     AS POINT_2
        ,B.POINT        AS POINT_3
        ,C.POINT        AS POINT_4
        ,ISNULL(D.POINT, 0)        AS YVALUE1
        ,ISNULL(E.POINT, 0)        AS YVALUE2
        ,ISNULL(F.POINT, 0)        AS YVALUE3
FROM    EST_DATA    A
LEFT OUTER JOIN EST_DATA    B   ON  B.COMP_ID         = A.COMP_ID
                                AND B.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND B.EST_ID          = @ESTID_1
                                AND B.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND B.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND B.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    C   ON  C.COMP_ID         = A.COMP_ID
                                AND C.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND C.EST_ID          = @ESTID_2
                                AND C.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND C.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND C.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    D   ON  D.COMP_ID         = A.COMP_ID
                                AND D.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND D.EST_ID          = @YID1
                                AND D.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND D.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND D.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    E   ON  E.COMP_ID         = A.COMP_ID
                                AND E.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND E.EST_ID          = @YID2
                                AND E.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND E.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND E.TGT_EMP_ID      = A.TGT_EMP_ID
LEFT OUTER JOIN EST_DATA    F   ON  F.COMP_ID         = A.COMP_ID
                                AND F.ESTTERM_REF_ID  = A.ESTTERM_REF_ID
                                AND F.EST_ID          = @YID3
                                AND F.ESTTERM_SUB_ID  = A.ESTTERM_SUB_ID
                                AND F.ESTTERM_STEP_ID = A.ESTTERM_STEP_ID
                                AND F.TGT_EMP_ID      = A.TGT_EMP_ID
WHERE   A.COMP_ID         = @COMP_ID
    AND A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND A.EST_ID          = @EST_ID
    AND A.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
    AND A.ESTTERM_STEP_ID = @ESTTERM_STEP_ID
    AND A.TGT_EMP_ID      = @TGT_EMP_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

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
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;
            paramArray[6] = CreateDataParameter("@ESTID_1", SqlDbType.Int);
            paramArray[6].Value = estid_1;
            paramArray[7] = CreateDataParameter("@ESTID_2", SqlDbType.Int);
            paramArray[7].Value = estid_2;
            paramArray[8] = CreateDataParameter("@YID1", SqlDbType.Int);
            paramArray[8].Value = yid1;
            paramArray[9] = CreateDataParameter("@YID2", SqlDbType.Int);
            paramArray[9].Value = yid2;
            paramArray[10] = CreateDataParameter("@YID3", SqlDbType.Int);
            paramArray[10].Value = yid3;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public int DeleteWithJoin_DB(IDbConnection conn
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
                        , object year_yn
                        , object merge_yn
                        , OwnerType ownerType)
        {

            string query = @"DELETE	EST_DATA
	                            FROM        EST_DATA         ED
		                            JOIN    EST_TERM_SUB     ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
									                                 AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
		                            JOIN    EST_TERM_STEP    EST    ON	(ED.COMP_ID         = EST.COMP_ID
									                                 AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
	                            WHERE	(ED.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (ED.EST_ID          = @EST_ID          OR @EST_ID          =''  )
                                    AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
                                    AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
                                    AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
                                    AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
                                    AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
                                    AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN         ='')
                                    AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN        ='')";

            if(ownerType == OwnerType.Dept)
            {
                query += @" AND TGT_EMP_ID < 0";
            }
            else if(ownerType == OwnerType.Emp_User)
            {
                query += @" AND TGT_EMP_ID > 0";
            }

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
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
            paramArray[9]       = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[9].Value = year_yn;
            paramArray[10]      = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[10].Value= merge_yn;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id)
        {
            return Delete(conn, trx, comp_id, est_id, estterm_ref_id, estterm_sub_id, 0, 0, 0, "");
        }

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object tgt_emp_id
                        , object direction_type)
        {
            return Delete(conn, trx, comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, 0, 0, "");
        }


        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object est_emp_id
                        , object tgt_emp_id
                        , object direction_type)
        {
            string query = @"
DELETE FROM EST_DATA
  WHERE COMP_ID         = @COMP_ID
  AND EST_ID            = @EST_ID
  AND ESTTERM_REF_ID    = @ESTTERM_REF_ID
  AND ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
  AND (ESTTERM_STEP_ID  = @ESTTERM_STEP_ID  OR  @ESTTERM_STEP_ID    =   0)
  AND (EST_EMP_ID       = @EST_EMP_ID       OR  @EST_EMP_ID         =   0)
  AND (TGT_EMP_ID       = @TGT_EMP_ID       OR  @TGT_EMP_ID         =   0)
  AND (DIRECTION_TYPE   = @DIRECTION_TYPE   OR  @DIRECTION_TYPE     ='')
";


            IDbDataParameter[] paramArray = CreateDataParameters(8);

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
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;
            paramArray[6] = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.VarChar);
            paramArray[6].Value = direction_type;
            paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = est_emp_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;

        }



        public int Insert(IDbConnection conn
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
                        , object status_date
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO EST_DATA  (COMP_ID
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
                                                   ,STATUS_DATE
                                                   ,CREATE_DATE
                                                   ,CREATE_USER)
                                             VALUES
                                                   (@COMP_ID
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
                                                   ,@STATUS_DATE
                                                   ,@CREATE_DATE
                                                   ,@CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(24);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]           = CreateDataParameter("@TGT_POS_CLS_ID", SqlDbType.NVarChar);
            paramArray[9].Value     = tgt_pos_cls_id;
            paramArray[10]          = CreateDataParameter("@TGT_POS_CLS_NAME", SqlDbType.NVarChar);
            paramArray[10].Value    = tgt_pos_cls_name;
            paramArray[11]          = CreateDataParameter("@TGT_POS_DUT_ID", SqlDbType.NVarChar);
            paramArray[11].Value    = tgt_pos_dut_id;
            paramArray[12]          = CreateDataParameter("@TGT_POS_DUT_NAME", SqlDbType.NVarChar);
            paramArray[12].Value    = tgt_pos_dut_name;
            paramArray[13]          = CreateDataParameter("@TGT_POS_GRP_ID", SqlDbType.NVarChar);
            paramArray[13].Value    = tgt_pos_grp_id;
            paramArray[14]          = CreateDataParameter("@TGT_POS_GRP_NAME", SqlDbType.NVarChar);
            paramArray[14].Value    = tgt_pos_grp_name;
            paramArray[15]          = CreateDataParameter("@TGT_POS_RNK_ID", SqlDbType.NVarChar);
            paramArray[15].Value    = tgt_pos_rnk_id;
            paramArray[16]          = CreateDataParameter("@TGT_POS_RNK_NAME", SqlDbType.NVarChar);
            paramArray[16].Value    = tgt_pos_rnk_name;
            paramArray[17]          = CreateDataParameter("@TGT_POS_KND_ID", SqlDbType.NVarChar);
            paramArray[17].Value    = tgt_pos_knd_id;
            paramArray[18]          = CreateDataParameter("@TGT_POS_KND_NAME", SqlDbType.NVarChar);
            paramArray[18].Value    = tgt_pos_knd_name;
            paramArray[19]          = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[19].Value    = direction_type;
            paramArray[20]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 6);
            paramArray[20].Value    = status_id;
            paramArray[21]          = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[21].Value    = status_date;
            paramArray[22]          = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[22].Value    = create_date;
            paramArray[23]          = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[23].Value    = create_user;

            
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
          
        }

        
        public int Insert(IDbConnection conn
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
                        , object point_org
                        , object point_org_date
                        , object point_avg
                        , object point_avg_date
                        , object point_std
                        , object point_std_date
                        , object point_ctrl_org
                        , object point_ctrl_org_date
                        , object grade_ctrl_org_id
                        , object grade_ctrl_org_date
                        , object point
                        , object point_date
                        , object grade_id
                        , object grade_date
                        , object grade_to_point
                        , object grade_to_point_date
                        , object status_id
                        , object status_date
                        , object create_date
                        , object create_user)
        {
            string query = @"INSERT INTO EST_DATA  (COMP_ID
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
                                                   ,POINT_ORG
                                                   ,POINT_ORG_DATE
                                                   ,POINT_AVG
                                                   ,POINT_AVG_DATE
                                                   ,POINT_STD
                                                   ,POINT_STD_DATE
                                                   ,POINT_CTRL_ORG
                                                   ,POINT_CTRL_ORG_DATE
                                                   ,GRADE_CTRL_ORG_ID
                                                   ,GRADE_CTRL_ORG_DATE
                                                   ,POINT
                                                   ,POINT_DATE
                                                   ,GRADE_ID
                                                   ,GRADE_DATE
                                                   ,GRADE_TO_POINT
                                                   ,GRADE_TO_POINT_DATE
                                                   ,STATUS_ID
                                                   ,STATUS_DATE
                                                   ,CREATE_DATE
                                                   ,CREATE_USER)
                                             VALUES
                                                   (@COMP_ID
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
                                                   ,@POINT_ORG
                                                   ,@POINT_ORG_DATE
                                                   ,@POINT_AVG
                                                   ,@POINT_AVG_DATE
                                                   ,@POINT_STD
                                                   ,@POINT_STD_DATE
                                                   ,@POINT_CTRL_ORG
                                                   ,@POINT_CTRL_ORG_DATE
                                                   ,@GRADE_CTRL_ORG_ID
                                                   ,@GRADE_CTRL_ORG_DATE
                                                   ,@POINT
                                                   ,@POINT_DATE
                                                   ,@GRADE_ID
                                                   ,@GRADE_DATE
                                                   ,@GRADE_TO_POINT
                                                   ,@GRADE_TO_POINT_DATE
                                                   ,@STATUS_ID
                                                   ,@STATUS_DATE
                                                   ,@CREATE_DATE
                                                   ,@CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(40);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value     = est_dept_id;
            paramArray[6]           = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value     = est_emp_id;
            paramArray[7]           = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value     = tgt_dept_id;
            paramArray[8]           = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value     = tgt_emp_id;
            paramArray[9]           = CreateDataParameter("@TGT_POS_CLS_ID", SqlDbType.NVarChar);
            paramArray[9].Value     = tgt_pos_cls_id;
            paramArray[10]          = CreateDataParameter("@TGT_POS_CLS_NAME", SqlDbType.NVarChar);
            paramArray[10].Value    = tgt_pos_cls_name;
            paramArray[11]          = CreateDataParameter("@TGT_POS_DUT_ID", SqlDbType.NVarChar);
            paramArray[11].Value    = tgt_pos_dut_id;
            paramArray[12]          = CreateDataParameter("@TGT_POS_DUT_NAME", SqlDbType.NVarChar);
            paramArray[12].Value    = tgt_pos_dut_name;
            paramArray[13]          = CreateDataParameter("@TGT_POS_GRP_ID", SqlDbType.NVarChar);
            paramArray[13].Value    = tgt_pos_grp_id;
            paramArray[14]          = CreateDataParameter("@TGT_POS_GRP_NAME", SqlDbType.NVarChar);
            paramArray[14].Value    = tgt_pos_grp_name;
            paramArray[15]          = CreateDataParameter("@TGT_POS_RNK_ID", SqlDbType.NVarChar);
            paramArray[15].Value    = tgt_pos_rnk_id;
            paramArray[16]          = CreateDataParameter("@TGT_POS_RNK_NAME", SqlDbType.NVarChar);
            paramArray[16].Value    = tgt_pos_rnk_name;
            paramArray[17]          = CreateDataParameter("@TGT_POS_KND_ID", SqlDbType.NVarChar);
            paramArray[17].Value    = tgt_pos_knd_id;
            paramArray[18]          = CreateDataParameter("@TGT_POS_KND_NAME", SqlDbType.NVarChar);
            paramArray[18].Value    = tgt_pos_knd_name;
            paramArray[19]          = CreateDataParameter("@DIRECTION_TYPE", SqlDbType.NVarChar);
            paramArray[19].Value    = direction_type;
            paramArray[20]          = CreateDataParameter("@POINT_ORG", SqlDbType.Decimal);
            paramArray[20].Value    = point_org;
            paramArray[21]          = CreateDataParameter("@POINT_ORG_DATE", SqlDbType.DateTime);
            paramArray[21].Value    = point_org_date;
            paramArray[22]          = CreateDataParameter("@POINT_AVG", SqlDbType.Decimal);
            paramArray[22].Value    = point_avg;
            paramArray[23]          = CreateDataParameter("@POINT_AVG_DATE", SqlDbType.DateTime);
            paramArray[23].Value    = point_avg_date;
            paramArray[24]          = CreateDataParameter("@POINT_STD", SqlDbType.Decimal);
            paramArray[24].Value    = point_std;
            paramArray[25]          = CreateDataParameter("@POINT_STD_DATE", SqlDbType.DateTime);
            paramArray[25].Value    = point_std_date;
            paramArray[26]          = CreateDataParameter("@POINT_CTRL_ORG", SqlDbType.Decimal);
            paramArray[26].Value    = point_ctrl_org;
            paramArray[27]          = CreateDataParameter("@POINT_CTRL_ORG_DATE", SqlDbType.DateTime);
            paramArray[27].Value    = point_ctrl_org_date;
            paramArray[28]          = CreateDataParameter("@GRADE_CTRL_ORG_ID", SqlDbType.NVarChar);
            paramArray[28].Value    = grade_ctrl_org_id;
            paramArray[29]          = CreateDataParameter("@GRADE_CTRL_ORG_DATE", SqlDbType.DateTime);
            paramArray[29].Value    = grade_ctrl_org_date;
            paramArray[30]          = CreateDataParameter("@POINT", SqlDbType.Decimal);
            paramArray[30].Value    = point;
            paramArray[31]          = CreateDataParameter("@POINT_DATE", SqlDbType.DateTime);
            paramArray[31].Value    = point_date;
            paramArray[32]          = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar, 6);
            paramArray[32].Value    = grade_id;
            paramArray[33]          = CreateDataParameter("@GRADE_DATE", SqlDbType.DateTime);
            paramArray[33].Value    = grade_date;
            paramArray[34]          = CreateDataParameter("@GRADE_TO_POINT", SqlDbType.NVarChar, 6);
            paramArray[34].Value    = grade_to_point;
            paramArray[35]          = CreateDataParameter("@GRADE_TO_POINT_DATE", SqlDbType.DateTime);
            paramArray[35].Value    = grade_to_point_date;
            paramArray[36]          = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar, 6);
            paramArray[36].Value    = status_id;
            paramArray[37]          = CreateDataParameter("@STATUS_DATE", SqlDbType.DateTime);
            paramArray[37].Value    = status_date;
            paramArray[38]          = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[38].Value    = create_date;
            paramArray[39]          = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[39].Value    = create_user;

            
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
          
        }

        public int Update_DB(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object point)
        {
            string query = @"UPDATE	EST_DATA
                                SET	 POINT                  = CASE WHEN @POINT                  IS NULL THEN POINT                  ELSE @POINT                 END
                                WHERE	(COMP_ID            = @COMP_ID         OR @COMP_ID         = 0)
                                    AND (EST_ID             = @EST_ID          OR @EST_ID              =''    )
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
                                    AND	(ESTTERM_SUB_ID     = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
                                    AND	(ESTTERM_STEP_ID    = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0) ";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]           = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value     = comp_id;
            paramArray[1]           = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value     = est_id;
            paramArray[2]           = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = estterm_ref_id;
            paramArray[3]           = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value     = estterm_sub_id;
            paramArray[4]           = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value     = estterm_step_id;
            paramArray[5]           = CreateDataParameter("@POINT", SqlDbType.NVarChar);
            paramArray[5].Value     = point;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
            return affectedRow;
        }




        /// <summary>
        /// 입력될 점수가 없을 경우 -1을 던질것
        /// </summary>
        public int Update_EstData_Point(IDbConnection conn
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
                        , object point_org
                        , object point
                        , object point_avg
                        , object point_std
                        , object point_ctrl_org
                        , object status_id
                        , object update_user_ref_id)
        {
            string query = @"
UPDATE      EST_DATA
    SET	    POINT                 = CASE WHEN @POINT                = -1        THEN    POINT                   ELSE    @POINT              END
            , POINT_DATE            = CASE WHEN @POINT              = -1        THEN    POINT_DATE              ELSE    GETDATE()           END
            , POINT_ORG             = CASE WHEN @POINT_ORG          = -1        THEN    POINT_ORG               ELSE    @POINT_ORG          END
            , POINT_ORG_DATE        = CASE WHEN @POINT_ORG          = -1        THEN    POINT_ORG_DATE          ELSE    GETDATE()           END
            , POINT_AVG             = CASE WHEN @POINT_AVG          = -1        THEN    POINT_AVG               ELSE    @POINT_AVG          END
            , POINT_AVG_DATE        = CASE WHEN @POINT_AVG          = -1        THEN    POINT_AVG_DATE          ELSE    GETDATE()           END
            , POINT_STD             = CASE WHEN @POINT_STD          = -1        THEN    POINT_STD               ELSE    @POINT_STD          END
            , POINT_STD_DATE        = CASE WHEN @POINT_STD          = -1        THEN    POINT_STD_DATE          ELSE    GETDATE()           END
            , POINT_CTRL_ORG        = CASE WHEN @POINT_CTRL_ORG     = -1        THEN    POINT_CTRL_ORG          ELSE    @POINT_CTRL_ORG     END
            , POINT_CTRL_ORG_DATE   = CASE WHEN @POINT_CTRL_ORG     = -1        THEN    POINT_CTRL_ORG_DATE     ELSE    GETDATE()           END
            , STATUS_ID             = CASE WHEN @STATUS_ID          IS NULL     THEN    STATUS_ID               ELSE    @STATUS_ID          END
            , STATUS_DATE           = CASE WHEN @STATUS_ID          IS NULL     THEN    STATUS_DATE             ELSE    GETDATE()           END
            , UPDATE_USER           = @UPDATE_USER
    WHERE	COMP_ID             = @COMP_ID
        AND EST_ID              = @EST_ID
        AND	ESTTERM_REF_ID      = @ESTTERM_REF_ID
        AND	ESTTERM_SUB_ID      = @ESTTERM_SUB_ID
        AND	ESTTERM_STEP_ID     = @ESTTERM_STEP_ID
        AND	EST_DEPT_ID         = @EST_DEPT_ID
        AND	EST_EMP_ID          = @EST_EMP_ID
        AND	TGT_DEPT_ID         = @TGT_DEPT_ID
        AND	TGT_EMP_ID          = @TGT_EMP_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(16);

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
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@POINT", SqlDbType.Float);
            paramArray[9].Value = point == DBNull.Value ? -1 : point;
            paramArray[10] = CreateDataParameter("@POINT_AVG", SqlDbType.Float);
            paramArray[10].Value = point_avg == DBNull.Value ? -1 : point_avg;
            paramArray[11] = CreateDataParameter("@POINT_STD", SqlDbType.Float);
            paramArray[11].Value = point_std == DBNull.Value ? -1 : point_std;
            paramArray[12] = CreateDataParameter("@POINT_CTRL_ORG", SqlDbType.Float);
            paramArray[12].Value = point_ctrl_org == DBNull.Value ? -1 : point_ctrl_org;
            paramArray[13] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[13].Value = status_id;
            paramArray[14] = CreateDataParameter("@POINT_ORG", SqlDbType.Float);
            paramArray[14].Value = point_org == DBNull.Value ? -1 : point_org;
            paramArray[15] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[15].Value = update_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
            return affectedRow;
        }



        



        public DataTable Select_Bias_AVG_Ratio_STD(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id)
        {
            string query = @"
SELECT  EST_EMP.EST_EMP_ID
        , TOTAL.TOTAL_AVG
        , EST_EMP.EST_EMP_AVG
        , TOTAL.TOTAL_AVG / EST_EMP.EST_EMP_AVG     AS AVG_RATIO
        , EST_EMP.EST_EMP_STD                       AS EST_EMP_STD
        , TOTAL.TOTAL_STD                           AS TOTAL_STD
    FROM
        (
            SELECT      EST_EMP_ID
                        , SUM(POINT_ORG)            AS EST_EMP_SUM
                        , COUNT(*)                  AS EST_EMP_CNT
                        , SUM(POINT_ORG)/COUNT(*)   AS EST_EMP_AVG
                        , STDDEV(POINT_ORG)         AS EST_EMP_STD
                        , '1'                       AS BR
                FROM    EST_DATA
                WHERE   COMP_ID         =   @COMP_ID
                    AND EST_ID          =   @EST_ID
                    AND ESTTERM_REF_ID  =   @ESTTERM_REF_ID
                    AND ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
                    AND ESTTERM_STEP_ID =   @ESTTERM_STEP_ID
                    AND STATUS_ID       =   @STATUS_ID
                GROUP BY EST_EMP_ID
        )   EST_EMP
    LEFT OUTER JOIN 
        (
            SELECT      SUM(POINT_ORG)              AS TOTAL_SUM
                        , COUNT(*)                  AS TGT_EMP_CNT
                        , SUM(POINT_ORG)/COUNT(*)   AS TOTAL_AVG
                        , STDDEV(POINT_ORG)         AS TOTAL_STD
                        , '1'                       AS BR
                FROM    EST_DATA
                WHERE   COMP_ID         =   @COMP_ID
                    AND EST_ID          =   @EST_ID
                    AND ESTTERM_REF_ID  =   @ESTTERM_REF_ID
                    AND ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
                    AND ESTTERM_STEP_ID =   @ESTTERM_STEP_ID
                    AND STATUS_ID       =   @STATUS_ID
        )   TOTAL
        ON  EST_EMP.BR  =   TOTAL.BR
";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

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
            paramArray[5] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[5].Value = "E";


            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }



        public DataTable Select_Est_Data_Pos_Weight(object comp_id
                                                    , object est_id
                                                    , object estterm_ref_id
                                                    , object estterm_sub_id
                                                    , object estterm_step_id)
        {
            string query = @"
SELECT  @COMP_ID                        AS  COMP_ID
        , @EST_ID                       AS  EST_ID
        , TERM.ESTTERM_REF_ID
        , TERM.ESTTERM_NAME
        , SUB.ESTTERM_SUB_ID
        , SUB.ESTTERM_SUB_NAME
        , STEP.ESTTERM_STEP_ID
        , STEP.ESTTERM_STEP_NAME
        , ED.EST_DEPT_ID
        , ED.EST_EMP_ID
        , UDI.DEPT_REF_ID               AS UP_DEPT_ID
        , UDI.DEPT_NAME                 AS UP_DEPT_NAME
        , UDI.DEPT_TYPE                 AS UP_DEPT_TYPE
        --, UEPW.WEIGHT                 AS UP_DEPT_WEIGHT
        , UED.POINT                     AS UP_DEPT_POINT
        , DI.DEPT_REF_ID                AS TGT_DEPT_ID
        , DI.DEPT_NAME                  AS TGT_DEPT_NAME
        , DI.DEPT_TYPE                  AS DEPT_TYPE
        --, EPW.WEIGHT                  AS DEPT_WEIGHT
        , ED.POINT                      AS DEPT_POINT
        , EMP.EMP_REF_ID                AS TGT_EMP_ID
        , EMP.EMP_NAME                  AS TGT_EMP_NAME
        , DI.SORT_ORDER
        , EMP.POSITION_CLASS_CODE       AS TGT_POS_CLS_ID
        , CLS.POS_CLS_NAME              AS TGT_POS_CLS_NAME
        , EMP.POSITION_GRP_CODE         AS TGT_POS_GRP_ID
        , GRP.POS_GRP_NAME              AS TGT_POS_GRP_NAME
        , EMP.POSITION_RANK_CODE        AS TGT_POS_RNK_ID
        , RNK.POS_RNK_NAME              AS TGT_POS_RNK_NAME
        , EMP.POSITION_DUTY_CODE        AS TGT_POS_DUT_ID
        , DUT.POS_DUT_NAME              AS TGT_POS_DUT_NAME
        , EMP.POSITION_KIND_CODE        AS TGT_POS_KND_ID
        , KND.POS_KND_NAME              AS TGT_POS_KND_NAME
        , ED_EMP.POINT_ORG              AS POINT_ORG
        , ED_EMP.POINT                  AS POINT
        , ED_EMP.STATUS_ID              AS STATUS_ID
    FROM                    COM_DEPT_INFO       DI
        LEFT OUTER JOIN     EST_DATA            ED
            ON      ED.EST_ID               = @EST_ID
                AND ED.ESTTERM_REF_ID       = @ESTTERM_REF_ID
                AND ED.ESTTERM_SUB_ID       = @ESTTERM_SUB_ID
                AND ED.ESTTERM_STEP_ID      = @ESTTERM_STEP_ID
                AND ED.TGT_EMP_ID           < 0
                AND DI.DEPT_REF_ID          = ED.TGT_DEPT_ID
        LEFT OUTER JOIN     COM_DEPT_INFO       UDI
            ON      DI.UP_DEPT_ID           = UDI.DEPT_REF_ID
        LEFT OUTER JOIN     EST_DATA            UED
            ON      ED.EST_ID               = @EST_ID
                AND ED.ESTTERM_REF_ID       = @ESTTERM_REF_ID
                AND ED.ESTTERM_SUB_ID       = @ESTTERM_SUB_ID
                AND ED.ESTTERM_STEP_ID      = @ESTTERM_STEP_ID
                AND UED.TGT_EMP_ID          < 0
                AND UDI.DEPT_REF_ID         = UED.TGT_DEPT_ID
        LEFT OUTER JOIN     EST_TERM_INFO       TERM
            ON      TERM.ESTTERM_REF_ID     = @ESTTERM_REF_ID
        LEFT OUTER JOIN     EST_TERM_SUB        SUB
            ON      SUB.ESTTERM_SUB_ID      = @ESTTERM_SUB_ID
        LEFT OUTER JOIN     EST_TERM_STEP       STEP
            ON      STEP.ESTTERM_STEP_ID    = @ESTTERM_STEP_ID
        --LEFT OUTER JOIN     EST_POS_WEIGHT      UEPW
        --    ON      UDI.DEPT_TYPE           = UEPW.DEPT_TYPE_REF_ID
        --LEFT OUTER JOIN     EST_POS_WEIGHT      EPW
        --    ON      DI.DEPT_TYPE            = EPW.DEPT_TYPE_REF_ID
        INNER JOIN          REL_DEPT_EMP        REL
            ON      DI.DEPT_REF_ID          = REL.DEPT_REF_ID
        INNER JOIN          COM_EMP_INFO        EMP
            ON      REL.EMP_REF_ID          = EMP.EMP_REF_ID
        LEFT OUTER JOIN     EST_DATA            ED_EMP
            ON      ED_EMP.EST_ID           = @EST_ID
                AND ED_EMP.ESTTERM_REF_ID   = @ESTTERM_REF_ID
                AND ED_EMP.ESTTERM_SUB_ID   = @ESTTERM_SUB_ID
                AND ED_EMP.ESTTERM_STEP_ID  = @ESTTERM_STEP_ID
                AND REL.DEPT_REF_ID         = ED_EMP.TGT_DEPT_ID
                AND EMP.EMP_REF_ID          = ED_EMP.TGT_EMP_ID
        INNER JOIN          EST_POSITION_CLS    CLS
            ON      EMP.POSITION_CLASS_CODE = CLS.POS_CLS_ID
        INNER JOIN          EST_POSITION_GRP    GRP
            ON      EMP.POSITION_GRP_CODE   = GRP.POS_GRP_ID
        INNER JOIN          EST_POSITION_RNK    RNK
            ON      EMP.POSITION_RANK_CODE  = RNK.POS_RNK_ID
        INNER JOIN          EST_POSITION_DUT    DUT
            ON      EMP.POSITION_DUTY_CODE  = DUT.POS_DUT_ID
        INNER JOIN          EST_POSITION_KND    KND
            ON      EMP.POSITION_KIND_CODE  = KND.POS_KND_ID
    WHERE
            DI.DEPT_TYPE    = 4     OR  DI.DEPT_TYPE    = 7
    ORDER BY
            DI.SORT_ORDER
";

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

            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }









        #region EST060100 매핑 확정시 존재하지 않는 맵핑 정보가 있을 경우 평가데이터 삭제
        // Biz_Data의 CopyTgtMapDataToEstData_PART에서 수행
        //
        // 아래 순서대로 수행
        // 1. Delete_ED_JOIN_ESU_EST
        // 2. Select_YearMonth
        // 3. Delete_BSC_MBO_KIP_SCORE_DT
        // 4. Delete_BSC_MBO_KIP_SCORE_MT
        // 5. Delete_BSC_MBO_KPI_REPORT


        public int Delete_ED_JOIN_ESU_EST(IDbConnection conn
                                        , IDbTransaction trx
                                        , object COMP_ID
                                        , object EST_ID
                                        , object ESTTERM_REF_ID
                                        , object ESTTERM_SUB_ID
                                        , object ESTTERM_STEP_ID
                                        , object EST_DEPT_ID
                                        , object EST_EMP_ID
                                        , object TGT_DEPT_ID
                                        , object TGT_EMP_ID
                                        , object YEAR_YN
                                        , object MERGE_YN
                                        , OwnerType ownerType)
        {
            string Oracle_Query = @"
DELETE FROM EST_DATA ED
    WHERE   EXISTS
                ( SELECT 1
                    FROM EST_TERM_SUB ESU
                    WHERE   ED.COMP_ID          =   ESU.COMP_ID
                        AND ED.ESTTERM_SUB_ID   =   ESU.ESTTERM_SUB_ID
                        AND (       ESU.YEAR_YN         =   @YEAR_YN
                                OR  @YEAR_YN            =''
                            )
                )
        AND EXISTS
                ( SELECT 1
                    FROM EST_TERM_STEP EST
                    WHERE   ED.COMP_ID          =   EST.COMP_ID
                        AND ED.ESTTERM_STEP_ID  =   EST.ESTTERM_STEP_ID
                        AND (   
                                    EST.MERGE_YN        =   @MERGE_YN
                                OR  @MERGE_YN           =''
                            )
                )
        AND (   ED.COMP_ID          = @COMP_ID          OR  @COMP_ID            = 0     )
        AND (   ED.EST_ID           = @EST_ID           OR @EST_ID              =''    )
        AND (   ED.ESTTERM_REF_ID   = @ESTTERM_REF_ID   OR  @ESTTERM_REF_ID     = 0     )
        AND (   ED.ESTTERM_SUB_ID   = @ESTTERM_SUB_ID   OR  @ESTTERM_SUB_ID     = 0     )
        AND (   ED.ESTTERM_STEP_ID  = @ESTTERM_STEP_ID  OR  @ESTTERM_STEP_ID    = 0     )
        AND (   ED.EST_DEPT_ID      = @EST_DEPT_ID      OR  @EST_DEPT_ID        = 0     )
        AND (   ED.EST_EMP_ID       = @EST_EMP_ID       OR  @EST_EMP_ID         = 0     )
        AND (   ED.TGT_DEPT_ID      = @TGT_DEPT_ID      OR  @TGT_DEPT_ID        = 0     )
        AND (   ED.TGT_EMP_ID       = @TGT_EMP_ID       OR  @TGT_EMP_ID         = 0     )";



            string SQL_Query = @"
DELETE	EST_DATA
    FROM        EST_DATA         ED
        JOIN    EST_TERM_SUB     ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
		                                 AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
        JOIN    EST_TERM_STEP    EST    ON	(ED.COMP_ID         = EST.COMP_ID
		                                 AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
    WHERE	(ED.COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
        AND (ED.EST_ID          = @EST_ID          OR @EST_ID              =''    )
        AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
        AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
        AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
        AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
        AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
        AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
        AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
        AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN             =''    )
        AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN            =''    )";



            string query = @"
DELETE
    FROM    EST_DATA
        
    WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0)
        AND (EST_ID          = @EST_ID          OR @EST_ID              =''    )
        AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0)
        AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0)
        AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0)
        AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0)
        AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0)
        AND	(TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0)
        AND	(TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0)
        AND ESTTERM_SUB_ID IN ( SELECT ESTTERM_SUB_ID FROM EST_TERM_SUB
                                                         WHERE (COMP_ID = @COMP_ID   OR @COMP_ID         = 0)
                                                           AND (YEAR_YN = @YEAR_YN   OR @YEAR_YN             =''    ))
        AND ESTTERM_STEP_ID IN ( SELECT ESTTERM_STEP_ID FROM EST_TERM_STEP
                                                         WHERE (COMP_ID = @COMP_ID   OR @COMP_ID         = 0)
                                                           AND (MERGE_YN = @MERGE_YN OR @MERGE_YN            =''    ))


";
            if (ownerType == OwnerType.Dept)
            {
                Oracle_Query += @" AND TGT_EMP_ID < 0";
                SQL_Query += @" AND TGT_EMP_ID < 0";
                query += @" AND TGT_EMP_ID < 0";
            }
            else if (ownerType == OwnerType.Emp_User)
            {
                Oracle_Query += @" AND TGT_EMP_ID > 0";
                SQL_Query += @" AND TGT_EMP_ID > 0";
                query += @" AND TGT_EMP_ID > 0";
            }

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
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
            paramArray[9] = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[9].Value = YEAR_YN;
            paramArray[10] = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[10].Value = MERGE_YN;


            try
            {
                //int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(SQL_Query, Oracle_Query), paramArray, CommandType.Text);
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// EST_ID가 3GA이고 DELETE_ED_JOIN EST_ESU가 성공하면 수행 #1
        /// </summary>
        public string Select_Est_Term_YearMonth(object COMP_ID
                                    , object ESTTERM_SUB_ID
                                    , object ESTTERM_REF_ID)
        {
            string Oracle_query = @"
SELECT  TO_CHAR(A.EST_STARTDATE, 'yyyy') + LPAD(B.END_MONTH, 2, '0')
    FROM                    EST_TERM_INFO   A
        LEFT OUTER JOIN     EST_TERM_SUB    B 
            ON      B.COMP_ID           =   @COMP_ID 
                AND B.ESTTERM_SUB_ID    =   @ESTTERM_SUB_ID
    WHERE
        A.ESTTERM_REF_ID    =   @ESTTERM_REF_ID";

            string SQL_query = @"
SELECT CONVERT(VARCHAR, YEAR(A.EST_STARTDATE))
        +   CASE
                WHEN    DATALENGTH(CONVERT(VARCHAR, B.END_MONTH)) = 2
                THEN    CONVERT(VARCHAR, B.END_MONTH)
                ELSE    '0'+CONVERT(VARCHAR, B.END_MONTH)
            END
    FROM                    EST_TERM_INFO   A
        LEFT OUTER JOIN     EST_TERM_SUB    B 
            ON      B.COMP_ID           =   @COMP_ID 
                AND B.ESTTERM_SUB_ID    =   @ESTTERM_SUB_ID
    WHERE
        A.ESTTERM_REF_ID    =   @ESTTERM_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1].Value = ESTTERM_SUB_ID;
            paramArray[2].Value = ESTTERM_REF_ID;

            string rtnMonth = DbAgentObj.ExecuteScalar(GetQueryStringByDb(SQL_query, Oracle_query), paramArray, CommandType.Text).ToString();

            return rtnMonth;
        }



        /// <summary>
        /// EST_ID가 3GA이고 DELETE_ED_JOIN EST_ESU가 성공하면 수행 #2
        /// </summary>
        public int Delete_BSC_MBO_KIP_SCORE_DT(IDbConnection conn
                                            , IDbTransaction trx
                                            , object COMP_ID
                                            , object EST_ID
                                            , object ESTTERM_REF_ID
                                            , object ESTTERM_SUB_ID
                                            , object ESTTERM_STEP_ID
                                            , object YMD
                                            , object EST_DEPT_ID
                                            , object EST_EMP_ID
                                            , object TGT_DEPT_ID
                                            , object TGT_EMP_ID)
        {
            string query = @"
DELETE FROM     BSC_MBO_KPI_SCORE_DT
    WHERE       COMP_ID         =   @COMP_ID
        AND     EST_ID          =   @EST_ID
        AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID
        AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
        AND     YMD             =   @YMD
        AND     (   ESTTERM_STEP_ID =   @ESTTERM_STEP_ID    OR  @ESTTERM_STEP_ID    =   0   )
        AND     (   EST_DEPT_ID     =   @EST_DEPT_ID        OR  @EST_DEPT_ID        =   0   )
        AND     (   EST_EMP_ID      =   @EST_EMP_ID         OR  @EST_EMP_ID         =   0   )
        AND     (   TGT_DEPT_ID     =   @TGT_DEPT_ID        OR  @TGT_DEPT_ID        =   0   )
        AND     (   TGT_EMP_ID      =   @TGT_EMP_ID         OR  @TGT_EMP_ID         =   0   )
";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;
            paramArray[5] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[5].Value = YMD;
            paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = EST_DEPT_ID;
            paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = EST_EMP_ID;
            paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_DEPT_ID;
            paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9].Value = TGT_EMP_ID;


            int deletedCount = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return deletedCount;
        }




        /// <summary>
        /// EST_ID가 3GA이고 DELETE_ED_JOIN EST_ESU가 성공하면 수행 #3
        /// </summary>
        public int Delete_BSC_MBO_KIP_SCORE_MT(IDbConnection conn
                                            , IDbTransaction trx
                                            , object COMP_ID
                                            , object EST_ID
                                            , object ESTTERM_REF_ID
                                            , object ESTTERM_SUB_ID
                                            , object ESTTERM_STEP_ID
                                            , object YMD
                                            , object EST_DEPT_ID
                                            , object EST_EMP_ID
                                            , object TGT_DEPT_ID
                                            , object TGT_EMP_ID)
        {
            string query = @"
DELETE FROM     BSC_MBO_KPI_SCORE_MT
    WHERE       COMP_ID         =   @COMP_ID        
        AND     EST_ID          =   @EST_ID         
        AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID 
        AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID 
        AND     YMD             =   @YMD            
        AND     (   ESTTERM_STEP_ID =   @ESTTERM_STEP_ID    OR  @ESTTERM_STEP_ID    =   0   )
        AND     (   EST_DEPT_ID     =   @EST_DEPT_ID        OR  @EST_DEPT_ID        =   0   )
        AND     (   EST_EMP_ID      =   @EST_EMP_ID         OR  @EST_EMP_ID         =   0   )
        AND     (   TGT_DEPT_ID     =   @TGT_DEPT_ID        OR  @TGT_DEPT_ID        =   0   )
        AND     (   TGT_EMP_ID      =   @TGT_EMP_ID         OR  @TGT_EMP_ID         =   0   )
";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;
            paramArray[5] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[5].Value = YMD;
            paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = EST_DEPT_ID;
            paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = EST_EMP_ID;
            paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_DEPT_ID;
            paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9].Value = TGT_EMP_ID;

            int deletedCount = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return deletedCount;
        }



        /// <summary>
        /// EST_ID가 3GA이고 DELETE_ED_JOIN EST_ESU가 성공하면 수행 #4
        /// </summary>
        public int Delete_BSC_MBO_KPI_REPORT(IDbConnection conn
                                            , IDbTransaction trx
                                            , object COMP_ID
                                            , object EST_ID
                                            , object ESTTERM_REF_ID
                                            , object ESTTERM_SUB_ID
                                            , object TGT_DEPT_ID
                                            , object TGT_EMP_ID
                                            , object YMD)
        {
            string Oracle_query = @"
DELETE FROM     BSC_MBO_KPI_REPORT 
    WHERE       COMP_ID         =   @COMP_ID
        AND     EST_ID          =   @EST_ID
        AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID 
        AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID 
        AND     (   TGT_DEPT_ID     =   @TGT_DEPT_ID        OR  @TGT_DEPT_ID        =   0   )
        AND     (   TGT_EMP_ID      =   @TGT_EMP_ID         OR  @TGT_EMP_ID         =   0   )
        AND     NOT EXISTS
                            (
            SELECT * 
                FROM        BSC_MBO_KPI_SCORE_MT 
                WHERE       COMP_ID         =   @COMP_ID
                    AND     EST_ID          =   @EST_ID
                    AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID 
                    AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID 
                    AND     (   TGT_DEPT_ID     =   @TGT_DEPT_ID        OR  @TGT_DEPT_ID        =   0   )
                    AND     (   TGT_EMP_ID      =   @TGT_EMP_ID         OR  @TGT_EMP_ID         =   0   )
                    AND     YMD             =   @YMD
                            )
";

            string SQL_query = @"
IF NOT EXISTS
    (
    SELECT * 
        FROM        BSC_MBO_KPI_SCORE_MT 
        WHERE       COMP_ID         =   @COMP_ID
            AND     EST_ID          =   @EST_ID
            AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID 
            AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID 
            AND     (   TGT_DEPT_ID     =   @TGT_DEPT_ID        OR  @TGT_DEPT_ID        =   0   )
            AND     (   TGT_EMP_ID      =   @TGT_EMP_ID         OR  @TGT_EMP_ID         =   0   )
            AND     YMD             =   @YMD
    )
    DELETE FROM     BSC_MBO_KPI_REPORT 
        WHERE       COMP_ID         =   @COMP_ID
            AND     EST_ID          =   @EST_ID
            AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID 
            AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID 
            AND     (   TGT_DEPT_ID     =   @TGT_DEPT_ID        OR  @TGT_DEPT_ID        =   0   )
            AND     (   TGT_EMP_ID      =   @TGT_EMP_ID         OR  @TGT_EMP_ID         =   0   )
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[4].Value = YMD;
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = TGT_DEPT_ID;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = TGT_EMP_ID;

            int deletedCount = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(SQL_query, Oracle_query), paramArray, CommandType.Text);

            return deletedCount;
        }



        #endregion



        #region EST060100 매핑 확정시 데이터 인서트
        //Dac_Data.cs의 Insert 대체

        //인서트 수행 후 인서트 성공 & est_id가 3GA이면 3가지 인서트 수행
        // 1. Select_Est_Term_YearMonth 
        // 2. SCORE_DT
        // 3. SCORE_MT
        // 4. SCORE_REPORT



        /// <summary>
        /// EST_ID가 3GA이고 Insert가 성공하면 수행 #2
        /// </summary>
        public int Insert_BSC_MBO_KPI_SCORE_DT(IDbConnection conn
                        , IDbTransaction trx
                        , object COMP_ID
                        , object EST_ID
                        , object ESTTERM_REF_ID
                        , object ESTTERM_SUB_ID
                        , object ESTTERM_STEP_ID
                        , object YMD
                        , object EST_DEPT_ID
                        , object EST_EMP_ID
                        , object TGT_DEPT_ID
                        , object TGT_EMP_ID
                        , object create_user)
        {
            string query = @"
INSERT INTO BSC_MBO_KPI_SCORE_DT
    (COMP_ID,       EST_ID,         ESTTERM_REF_ID,     ESTTERM_SUB_ID,     ESTTERM_STEP_ID
    ,YMD,           EST_DEPT_ID,    EST_EMP_ID,         TGT_DEPT_ID,        TGT_EMP_ID
    ,KPI_REF_ID,    SCORE_GRADE,    SCORE_ORI,          SCORE_WEIGHT,       GRADE_REASON
    ,STATUS,        CREATE_USER,    CREATE_DATE)
SELECT
    @COMP_ID,       @EST_ID,        @ESTTERM_REF_ID,    @ESTTERM_SUB_ID,    @ESTTERM_STEP_ID
    ,@YMD,          @EST_DEPT_ID,   @EST_EMP_ID,        @TGT_DEPT_ID,       @TGT_EMP_ID
    ,A.KPI_REF_ID,  NULL,           NULL,               NULL,               NULL
    ,'N',           @CREATE_USER,   GETDATE()
FROM    BSC_MBO_KPI_WEIGHT  A
WHERE
        A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.EMP_REF_ID        = @TGT_EMP_ID
    AND A.USE_YN            = 'Y'";

            IDbDataParameter[] paramArray = CreateDataParameters(11);
            
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;

            paramArray[5] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[5].Value = YMD;
            paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = EST_DEPT_ID;
            paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = EST_EMP_ID;
            paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_DEPT_ID;
            paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9].Value = TGT_EMP_ID;

            paramArray[10] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[10].Value = create_user;


            int insertCount = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return insertCount;
        }

        
        /// <summary>
        /// EST_ID가 3A이고 Insert가 성공하면 수행 #2
        /// </summary>
        public int Insert_BSC_DEPT_KPI_SCORE_DT(IDbConnection conn
                                                , IDbTransaction trx
                                                , object COMP_ID
                                                , object EST_ID
                                                , object ESTTERM_REF_ID
                                                , object ESTTERM_SUB_ID
                                                , object ESTTERM_STEP_ID
                                                , object YMD
                                                , object EST_DEPT_ID
                                                , object EST_EMP_ID
                                                , object TGT_DEPT_ID
                                                , object TGT_EMP_ID
                                                , object create_user)
        {
            string query = @"
INSERT INTO BSC_MBO_KPI_SCORE_DT
    (COMP_ID,       EST_ID,         ESTTERM_REF_ID,     ESTTERM_SUB_ID,     ESTTERM_STEP_ID
    ,YMD,           EST_DEPT_ID,    EST_EMP_ID,         TGT_DEPT_ID,        TGT_EMP_ID
    ,KPI_REF_ID,    SCORE_GRADE,    SCORE_ORI,          SCORE_WEIGHT,       GRADE_REASON
    ,STATUS,        CREATE_USER,    CREATE_DATE)
SELECT @COMP_ID,      @EST_ID,        @ESTTERM_REF_ID,    @ESTTERM_SUB_ID,    @ESTTERM_STEP_ID
      ,@YMD,          @EST_DEPT_ID,   @EST_EMP_ID,        @TGT_DEPT_ID,       @TGT_EMP_ID
      ,A.KPI_REF_ID,  NULL,           NULL,               NULL,               NULL
      ,'N',           @CREATE_USER,   GETDATE()
 FROM BSC_MAP_KPI A 
WHERE A.MAP_VERSION_ID = (SELECT MAX(MAP_VERSION_ID) FROM BSC_MAP_KPI B
                                               WHERE A.ESTTERM_REF_ID  = B.ESTTERM_REF_ID
                                                 AND A.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID 
                                                 AND A.KPI_REF_ID      = B.KPI_REF_ID )
AND A.EST_DEPT_REF_ID = @TGT_DEPT_ID --'1'

";

            IDbDataParameter[] paramArray = CreateDataParameters(11);
            
            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;

            paramArray[5] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[5].Value = YMD;
            paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = EST_DEPT_ID;
            paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = EST_EMP_ID;
            paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_DEPT_ID;
            paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9].Value = TGT_EMP_ID;

            paramArray[10] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[10].Value = create_user;


            int insertCount = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return insertCount;
        }




        /// <summary>
        /// EST_ID가 3GA이고 DELETE_ED_JOIN EST_ESU가 성공하면 수행 #3
        /// </summary>
        public int Insert_BSC_MBO_KPI_SCORE_MT(IDbConnection conn
                                            , IDbTransaction trx
                                            , object COMP_ID
                                            , object EST_ID
                                            , object ESTTERM_REF_ID
                                            , object ESTTERM_SUB_ID
                                            , object ESTTERM_STEP_ID
                                            , object YMD
                                            , object EST_DEPT_ID
                                            , object EST_EMP_ID
                                            , object TGT_DEPT_ID
                                            , object TGT_EMP_ID
                                            , object create_user)
        {
            string query = @"
INSERT INTO BSC_MBO_KPI_SCORE_MT
    (COMP_ID       ,EST_ID         ,ESTTERM_REF_ID     ,ESTTERM_SUB_ID     ,ESTTERM_STEP_ID
    ,YMD           ,EST_DEPT_ID    ,EST_EMP_ID         ,TGT_DEPT_ID        ,TGT_EMP_ID
    ,SCORE         ,COMMENT        ,STATUS             ,CREATE_USER        ,CREATE_DATE)
VALUES
    (@COMP_ID      ,@EST_ID        ,@ESTTERM_REF_ID    ,@ESTTERM_SUB_ID    ,@ESTTERM_STEP_ID
    ,@YMD          ,@EST_DEPT_ID   ,@EST_EMP_ID        ,@TGT_DEPT_ID       ,@TGT_EMP_ID
    ,NULL          ,NULL           ,'N'                ,@CREATE_USER       ,GETDATE())";

            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;

            paramArray[5] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[5].Value = YMD;
            paramArray[6] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = EST_DEPT_ID;
            paramArray[7] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = EST_EMP_ID;
            paramArray[8] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_DEPT_ID;
            paramArray[9] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9].Value = TGT_EMP_ID;

            paramArray[10] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[10].Value = create_user;

            int insertCOunt = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return insertCOunt;
        }



        /// <summary>
        /// EST_ID가 3GA이고 DELETE_ED_JOIN EST_ESU가 성공하면 수행 #4
        /// </summary>
        public int Insert_BSC_MBO_KPI_REPORT(IDbConnection conn
                                            , IDbTransaction trx
                                            , object COMP_ID
                                            , object EST_ID
                                            , object ESTTERM_REF_ID
                                            , object ESTTERM_SUB_ID
                                            , object ESTTERM_STEP_ID
                                            , object YMD
                                            , object EST_DEPT_ID
                                            , object EST_EMP_ID
                                            , object TGT_DEPT_ID
                                            , object TGT_EMP_ID
                                            , object create_user)
        {
            string Oracle_query = @"
INSERT INTO BSC_MBO_KPI_REPORT
    (COMP_ID       ,EST_ID     ,ESTTERM_REF_ID     ,ESTTERM_SUB_ID     ,TGT_DEPT_ID
    ,TGT_EMP_ID    ,REPORT     ,REPORT_FILE        ,STATUS             ,CREATE_USER    ,CREATE_DATE)
    SELECT
            @COMP_ID      ,@EST_ID    ,@ESTTERM_REF_ID    ,@ESTTERM_SUB_ID    ,@TGT_DEPT_ID
            ,@TGT_EMP_ID   ,NULL       ,NULL               ,'N'                ,@CREATE_USER   ,GETDATE()
    FROM    DUAL
    WHERE   NOT EXISTS    (
                            SELECT *
                                FROM        BSC_MBO_KPI_REPORT 
                                WHERE
                                            COMP_ID         =   @COMP_ID
                                    AND     EST_ID          =   @EST_ID
                                    AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID 
                                    AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID 
                                    AND     TGT_DEPT_ID     =   @TGT_DEPT_ID    
                                    AND     TGT_EMP_ID      =   @TGT_EMP_ID
                            )

";

            string SQL_query = @"
IF NOT EXISTS
    (
    SELECT *
        FROM        BSC_MBO_KPI_REPORT 
        WHERE
                    COMP_ID         =   @COMP_ID
            AND     EST_ID          =   @EST_ID
            AND     ESTTERM_REF_ID  =   @ESTTERM_REF_ID 
            AND     ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID 
            AND     TGT_DEPT_ID     =   @TGT_DEPT_ID    
            AND     TGT_EMP_ID      =   @TGT_EMP_ID
    )
    INSERT INTO BSC_MBO_KPI_REPORT
        (COMP_ID       ,EST_ID     ,ESTTERM_REF_ID     ,ESTTERM_SUB_ID     ,TGT_DEPT_ID
        ,TGT_EMP_ID    ,REPORT     ,REPORT_FILE        ,STATUS             ,CREATE_USER    ,CREATE_DATE)
    VALUES
        (@COMP_ID      ,@EST_ID    ,@ESTTERM_REF_ID    ,@ESTTERM_SUB_ID    ,@TGT_DEPT_ID
        ,@TGT_EMP_ID   ,NULL       ,NULL               ,'N'                ,@CREATE_USER   ,GETDATE())";


            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;

            paramArray[4] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[4].Value = TGT_DEPT_ID;
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = TGT_EMP_ID;

            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[6].Value = create_user;

            int deletedCount = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(SQL_query, Oracle_query), paramArray, CommandType.Text);

            return deletedCount;
        }





        public int Select_Est_Data_Count(IDbConnection conn
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
                                        , object status_id)
        {
            string query = @"
SELECT COUNT(*)
    FROM     EST_DATA
    WHERE	(COMP_ID         = @COMP_ID         OR @COMP_ID         = 0 )
        AND (EST_ID          = @EST_ID          OR @EST_ID          =''     )
        AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID  = 0 )
        AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID  = 0 )
        AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID = 0 )
        AND	(EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID     = 0 )
        AND	(EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID      = 0 )
        AND	(TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID     = 0 )
        AND	(TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID      = 0 )
        AND (STATUS_ID       = @STATUS_ID       OR @STATUS_ID       =''     )";

            IDbDataParameter[] paramArray = CreateDataParameters(10);

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
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@STATUS_ID", SqlDbType.NVarChar);
            paramArray[9].Value = status_id;

            try
            {
                int Result = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public int Select_Est_Emp_Est_Target_Count(IDbConnection conn
                                                , IDbTransaction trx
                                                , object comp_id
                                                , object est_id
                                                , object estterm_ref_id
                                                , object estterm_sub_id
                                                , object estterm_step_id
                                                , object est_dept_id
                                                , object est_emp_id
                                                , object tgt_dept_id
                                                , object tgt_emp_id)
        {
            string query = @"
SELECT COUNT(*)
    FROM    EST_EMP_EST_TARGET_MAP
    WHERE	(COMP_ID         = @COMP_ID             OR @COMP_ID         = 0 )
        AND (EST_ID          = @EST_ID              OR @EST_ID          ='' )
        AND	(ESTTERM_REF_ID  = @ESTTERM_REF_ID      OR @ESTTERM_REF_ID  = 0 )
        AND	(ESTTERM_SUB_ID  = @ESTTERM_SUB_ID      OR @ESTTERM_SUB_ID  = 0 )
        AND	(ESTTERM_STEP_ID = @ESTTERM_STEP_ID     OR @ESTTERM_STEP_ID = 0 )
        AND	(EST_DEPT_ID     = @EST_DEPT_ID         OR @EST_DEPT_ID     = 0 )
        AND	(EST_EMP_ID      = @EST_EMP_ID          OR @EST_EMP_ID      = 0 )
        AND	(TGT_DEPT_ID     = @TGT_DEPT_ID         OR @TGT_DEPT_ID     = 0 )
        AND	(TGT_EMP_ID      = @TGT_EMP_ID          OR @TGT_EMP_ID      = 0 )";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

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
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;

            try
            {
                int Result = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(conn, trx, query, paramArray, CommandType.Text));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public DataSet Select_Est_Data_Join_Est_Esu(IDbConnection conn
                                                    , IDbTransaction trx
                                                    , int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int estterm_step_id
                                                    , int est_dept_id
                                                    , int est_emp_id
                                                    , int tgt_dept_id
                                                    , int tgt_emp_id
                                                    , string year_yn
                                                    , string merge_yn
                                                    , OwnerType ownerType)
        {
            string query = @"
SELECT	 ED.COMP_ID
        ,ED.EST_ID
        ,ED.ESTTERM_REF_ID
        ,ED.ESTTERM_SUB_ID
        ,ED.ESTTERM_STEP_ID
        ,ED.EST_DEPT_ID
        ,ED.EST_EMP_ID
        ,ED.TGT_DEPT_ID
        ,ED.TGT_EMP_ID
        ,ED.TGT_POS_CLS_ID
        ,ED.TGT_POS_CLS_NAME
        ,ED.TGT_POS_DUT_ID
        ,ED.TGT_POS_DUT_NAME
        ,ED.TGT_POS_GRP_ID
        ,ED.TGT_POS_GRP_NAME
        ,ED.TGT_POS_RNK_ID
        ,ED.TGT_POS_RNK_NAME
        ,ED.TGT_POS_KND_ID
        ,ED.TGT_POS_KND_NAME
        ,DIRECTION_TYPE
        ,ED.POINT_ORG
        ,ED.POINT_ORG_DATE
        ,ED.POINT_AVG
        ,ED.POINT_AVG_DATE
        ,ED.POINT_STD
        ,ED.POINT_STD_DATE
        ,ED.POINT_CTRL_ORG
        ,ED.POINT_CTRL_ORG_DATE
        ,ED.GRADE_CTRL_ORG_ID
        ,ED.GRADE_CTRL_ORG_DATE
        ,ED.POINT
        ,ED.POINT_DATE
        ,ED.GRADE_ID
        ,ED.GRADE_DATE
        ,ED.GRADE_TO_POINT
        ,ED.GRADE_TO_POINT_DATE
        ,ED.STATUS_ID
        ,ED.STATUS_DATE
        ,ED.CREATE_DATE
        ,ED.CREATE_USER
        ,ED.UPDATE_DATE
        ,ED.UPDATE_USER
    FROM	    EST_DATA              ED
        JOIN    EST_TERM_SUB          ESU    ON	(ED.COMP_ID         = ESU.COMP_ID
                                             AND ED.ESTTERM_SUB_ID  = ESU.ESTTERM_SUB_ID)
        JOIN    EST_TERM_STEP         EST    ON	(ED.COMP_ID         = EST.COMP_ID
                                             AND ED.ESTTERM_STEP_ID = EST.ESTTERM_STEP_ID)
        WHERE	(ED.COMP_ID         = @COMP_ID         OR @COMP_ID          = 0 )
            AND (ED.EST_ID          = @EST_ID          OR @EST_ID           ='')
            AND	(ED.ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID   = 0 )
            AND	(ED.ESTTERM_SUB_ID  = @ESTTERM_SUB_ID  OR @ESTTERM_SUB_ID   = 0 )
            AND	(ED.ESTTERM_STEP_ID = @ESTTERM_STEP_ID OR @ESTTERM_STEP_ID  = 0 )
            AND	(ED.EST_DEPT_ID     = @EST_DEPT_ID     OR @EST_DEPT_ID      = 0 )
            AND	(ED.EST_EMP_ID      = @EST_EMP_ID      OR @EST_EMP_ID       = 0 )
            AND	(ED.TGT_DEPT_ID     = @TGT_DEPT_ID     OR @TGT_DEPT_ID      = 0 )
            AND	(ED.TGT_EMP_ID      = @TGT_EMP_ID      OR @TGT_EMP_ID       = 0 )
            AND	(ESU.YEAR_YN        = @YEAR_YN         OR @YEAR_YN          ='')
            AND	(EST.MERGE_YN       = @MERGE_YN        OR @MERGE_YN         ='')";

            if (ownerType == OwnerType.Dept)
            {
                query += @" AND TGT_EMP_ID < 0";
            }
            else if (ownerType == OwnerType.Emp_User)
            {
                query += @" AND TGT_EMP_ID > 0";
            }

            IDbDataParameter[] paramArray = CreateDataParameters(11);

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
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;
            paramArray[9] = CreateDataParameter("@YEAR_YN", SqlDbType.NChar);
            paramArray[9].Value = year_yn;
            paramArray[10] = CreateDataParameter("@MERGE_YN", SqlDbType.NChar);
            paramArray[10].Value = merge_yn;

            DataSet ds = DbAgentObj.FillDataSet(conn, trx, query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }


        #endregion
    }
}