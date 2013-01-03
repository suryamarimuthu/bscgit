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

namespace MicroBSC.Integration.MUL.Dac
{
    public class Dac_Mul_Basic_Info : DbAgentBase
    {
        public Dac_Mul_Basic_Info()
        {
        }


        public int Insert_Mul_Est_Basic_Info(IDbConnection conn
                                            , IDbTransaction trx
                                            , object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id
                                            , object max_est_emp_cnt
                                            , object mid_est_emp_cnt
                                            , object min_est_emp_cnt
                                            , object create_user_ref_id)
        {
            string query = @"
INSERT INTO MUL_BASIC_INFO
		( 
            COMP_ID
            , EST_ID
            , ESTTERM_REF_ID
            , ESTTERM_SUB_ID
            , MAX_EST_EMP_CNT
            , MID_EST_EMP_CNT
            , MIN_EST_EMP_CNT
            , CREATE_USER
		)
		VALUES
		(
			@COMP_ID
            , @EST_ID
            , @ESTTERM_REF_ID
            , @ESTTERM_SUB_ID
            , @MAX_EST_EMP_CNT
            , @MID_EST_EMP_CNT
            , @MIN_EST_EMP_CNT
            , @CREATE_USER
		)
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
            paramArray[4] = CreateDataParameter("@MAX_EST_EMP_CNT", SqlDbType.Int);
            paramArray[4].Value = max_est_emp_cnt;
            paramArray[5] = CreateDataParameter("@MID_EST_EMP_CNT", SqlDbType.Int);
            paramArray[5].Value = mid_est_emp_cnt;
            paramArray[6] = CreateDataParameter("@MIN_EST_EMP_CNT", SqlDbType.Int);
            paramArray[6].Value = min_est_emp_cnt;
            paramArray[7] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[7].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public int Delete_Mul_Est_Basic_Info(IDbConnection conn
                                , IDbTransaction trx
                                , object comp_id
                                , object est_id
                                , object estterm_ref_id
                                , object estterm_sub_id)
        {
            string query = @"
DELETE FROM MUL_BASIC_INFO
  WHERE COMP_ID            = @COMP_ID
    AND EST_ID             = @EST_ID
    AND ESTTERM_REF_ID     = @ESTTERM_REF_ID
    AND ESTTERM_SUB_ID     = @ESTTERM_SUB_ID
";


            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }



        public DataTable Select_Mul_Basic_Info(object comp_id
                                            , object est_id
                                            , object estterm_ref_id
                                            , object estterm_sub_id)
        {
            string query = @"
SELECT          MAX_EST_EMP_CNT, MID_EST_EMP_CNT, MIN_EST_EMP_CNT
    FROM    MUL_BASIC_INFO
    WHERE   COMP_ID         =   @COMP_ID
        AND EST_ID          =   @EST_ID
        AND ESTTERM_REF_ID  =   @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;

            DataTable DT = DbAgentObj.FillDataSet(query, "MUL_BASIC_INFO", null, paramArray).Tables[0];

            return DT;
        }
    }
}
