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
    public class Dac_Est_Refusal : DbAgentBase
    {
        public Dac_Est_Refusal()
        {
        }
        

        public int Insert_Est_Refusal(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object tgt_dept_id
                        , object tgt_emp_id
                        , object refusal_comment
                        , object grade_id
                        , object create_user_ref_id)
        {
            string query = @"
INSERT INTO     EST_REFUSAL
    (
        COMP_ID
        , EST_ID
        , ESTTERM_REF_ID
        , ESTTERM_SUB_ID
        , ESTTERM_STEP_ID
        , TGT_DEPT_ID
        , TGT_EMP_ID
        , REFUSAL_COMMENT
        , REFUSAL_DATE
        , GRADE_ID
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
        , @TGT_DEPT_ID
        , @TGT_EMP_ID
        , @REFUSAL_COMMENT
        , GETDATE()
        , @GRADE_ID
        , @CREATE_USER
        , GETDATE()
    )
";


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
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;
            paramArray[7] = CreateDataParameter("@REFUSAL_COMMENT", SqlDbType.NVarChar);
            paramArray[7].Value = refusal_comment;
            paramArray[8] = CreateDataParameter("@GRADE_ID", SqlDbType.NVarChar);
            paramArray[8].Value = grade_id;
            paramArray[9] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public int Update_Est_Refusal_Comment(IDbConnection conn
                                            , IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object tgt_dept_id
                                            , object tgt_emp_id
                                            , object refusal_comment
                                            , object update_user_ref_id)
        {
            string query = @"
UPDATE      EST_REFUSAL
    SET     REFUSAL_COMMENT = @REFUSAL_COMMENT
            , UPDATE_USER   = @UPDATE_USER
            , UPDATE_DATE   = GETDATE()
    WHERE
            COMP_ID         = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND TGT_DEPT_ID     = @TGT_DEPT_ID
        AND TGT_EMP_ID      = @TGT_EMP_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(9);

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
            paramArray[7] = CreateDataParameter("@REFUSAL_COMMENT", SqlDbType.NVarChar);
            paramArray[7].Value = refusal_comment;
            paramArray[8] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[8].Value = update_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Update_Est_Refusal_Reply(IDbConnection conn
                                            , IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object tgt_dept_id
                                            , object tgt_emp_id
                                            , object reply_emp_id
                                            , object reply_comment
                                            , object update_user_ref_id)
        {
            string query = @"
UPDATE      EST_REFUSAL
    SET     REPLY_EMP_ID    = @REPLY_EMP_ID
            , REPLY_COMMENT = @REPLY_COMMENT
            , REPLY_DATE    = GETDATE()
            , UPDATE_USER   = @UPDATE_USER
            , UPDATE_DATE   = GETDATE()

    WHERE
            COMP_ID         = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND TGT_DEPT_ID     = @TGT_DEPT_ID
        AND TGT_EMP_ID      = @TGT_EMP_ID
";


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
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;
            paramArray[7] = CreateDataParameter("@REPLY_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = reply_emp_id;
            paramArray[8] = CreateDataParameter("@REPLY_COMMENT", SqlDbType.NVarChar);
            paramArray[8].Value = reply_comment;
            paramArray[9] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[9].Value = update_user_ref_id;




            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Delete_Est_Refusal(IDbConnection conn
                        , IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object tgt_dept_id
                        , object tgt_emp_id)
        {
            string query = @"
DELETE FROM     EST_REFUSAL
  WHERE
                COMP_ID         = @COMP_ID
        AND     EST_ID          = @EST_ID
        AND     ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND     ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND     ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND     TGT_DEPT_ID     = @TGT_DEPT_ID
        AND     TGT_EMP_ID      = @TGT_EMP_ID
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
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;



            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public DataTable Select_Est_Refusal(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object tgt_dept_id
                                            , object tgt_emp_id)
        {
            string query = @"
SELECT
            COMP_ID
            , EST_ID
            , ESTTERM_REF_ID
            , ESTTERM_SUB_ID
            , ESTTERM_STEP_ID
            , TGT_DEPT_ID
            , TGT_EMP_ID
            , REFUSAL_COMMENT
            , REPLY_EMP_ID
            , REPLY_COMMENT
            , GRADE_ID
    FROM    
            EST_REFUSAL
    WHERE
                COMP_ID         = @COMP_ID
        AND     EST_ID          = @EST_ID
        AND     ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND     ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND     ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND     TGT_DEPT_ID     = @TGT_DEPT_ID
        AND     TGT_EMP_ID      = @TGT_EMP_ID
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
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;


            DataTable dt = DbAgentObj.FillDataSet(query, "EST_REFUSAL_DATA", null, paramArray).Tables[0];

            return dt;
        }
    }
}
