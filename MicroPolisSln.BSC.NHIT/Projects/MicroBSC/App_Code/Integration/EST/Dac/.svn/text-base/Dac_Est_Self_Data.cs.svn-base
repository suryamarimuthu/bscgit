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
    public class Dac_Est_Self_Data : DbAgentBase
    {
        public Dac_Est_Self_Data()
        {
        }

        public DataTable Select_Self_Est_Question(object comp_id
                                                , object est_id
                                                , object estterm_ref_id
                                                , object estterm_sub_id
                                                , object estterm_step_id
                                                , object tgt_dept_id
                                                , object tgt_emp_id)
        {
            string query = @"
SELECT      EST_Q.SELF_TOP_ID
            , EST_Q.SELF_TOP_NM
            , EST_Q.SELF_MID_ID
            , EST_Q.SELF_MID_NM
            , CASE WHEN
                            EST_Q.SELF_TOP_ID=EST.SELF_TOP_ID
                    AND     EST_Q.SELF_MID_ID=EST.SELF_MID_ID
                    THEN    1
                    ELSE    0
                    END AS SELECTED
            , EST.SELF_COMMENT
    FROM                    EST_SELF_QUESTION   EST_Q
        LEFT OUTER JOIN (   SELECT     SELF_TOP_ID, SELF_MID_ID, SELF_COMMENT
                                FROM    EST_SELF_DATA
                                WHERE   COMP_ID             =   @COMP_ID
                                    AND EST_ID              =   @EST_ID
                                    AND ESTTERM_REF_ID      =   @ESTTERM_REF_ID
                                    AND ESTTERM_SUB_ID      =   @ESTTERM_SUB_ID
                                    AND ESTTERM_STEP_ID     =   @ESTTERM_STEP_ID
                                    AND TGT_DEPT_ID         =   @TGT_DEPT_ID
                                    AND TGT_EMP_ID          =   @TGT_EMP_ID
                        )                       EST
            ON  (    
                    EST.SELF_TOP_ID=EST_Q.SELF_TOP_ID
                AND EST.SELF_MID_ID=EST_Q.SELF_MID_ID
                )
    ORDER BY
        EST_Q.SELF_TOP_ID   ASC
        , EST_Q.SELF_MID_ID ASC
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


            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }




        public int Insert_Self_Est_Question(IDbConnection conn, IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object tgt_dept_id
                                            , object tgt_emp_id
                                            , object self_top_id
                                            , object self_mid_id
                                            , object self_comment
                                            , object create_user_ref_id)
        {
            string query = @"
INSERT INTO EST_SELF_DATA
    (
        COMP_ID
        , EST_ID
        , ESTTERM_REF_ID
        , ESTTERM_SUB_ID
        , ESTTERM_STEP_ID
        , TGT_DEPT_ID
        , TGT_EMP_ID
        , SELF_TOP_ID
        , SELF_MID_ID
        , SELF_COMMENT
        , CREATE_DATE
        , CREATE_USER
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
        , @SELF_TOP_ID
        , @SELF_MID_ID
        , @SELF_COMMENT
        , GETDATE()
        , @CREATE_USER
    )
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
            paramArray[5] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_dept_id;
            paramArray[6] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = tgt_emp_id;
            paramArray[7] = CreateDataParameter("@SELF_TOP_ID", SqlDbType.Int);
            paramArray[7].Value = self_top_id;
            paramArray[8] = CreateDataParameter("@SELF_MID_ID", SqlDbType.Int);
            paramArray[8].Value = self_mid_id;
            paramArray[9] = CreateDataParameter("@SELF_COMMENT", SqlDbType.NVarChar);
            paramArray[9].Value = self_comment;
            paramArray[10] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[10].Value = create_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int Delete_Self_Est_Question(IDbConnection conn, IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object estterm_step_id
                                            , object tgt_emp_id)
        {
            string query = @"
DELETE FROM EST_SELF_DATA
    WHERE   COMP_ID         = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND TGT_EMP_ID      = @TGT_EMP_ID
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
            paramArray[5] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = tgt_emp_id;
            
            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
    }
}
