using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;


namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Mbo_Kpi_Score_Mt : DbAgentBase
    {

        public Dac_Bsc_Mbo_Kpi_Score_Mt()
        { }
        
        public int Update_Score(IDbConnection conn, IDbTransaction trx
                                , object comp_id
                                , object est_id
                                , object estterm_ref_id
                                , object estterm_sub_id
                                , object estterm_step_id
                                , object ymd
                                , object est_dept_id
                                , object est_emp_id
                                , object tgt_dept_id
                                , object tgt_emp_id
                                , object score
                                , object update_user_ref_id)
        {
            string query = @"
UPDATE      BSC_MBO_KPI_SCORE_MT
    SET     SCORE           = @SCORE
          , UPDATE_USER     = @UPDATE_USER
          , UPDATE_DATE     = GETDATE()
    WHERE   COMP_ID         = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND YMD             = @YMD
        AND EST_DEPT_ID     = @EST_DEPT_ID
        AND EST_EMP_ID      = @EST_EMP_ID
        AND TGT_DEPT_ID     = @TGT_DEPT_ID
        AND TGT_EMP_ID      = @TGT_EMP_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]       = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1]       = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4]       = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5]       = CreateDataParameter("@YMD", SqlDbType.NVarChar);
            paramArray[5].Value = ymd;
            paramArray[6]       = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[6].Value = est_dept_id;
            paramArray[7]       = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[7].Value = est_emp_id;
            paramArray[8]       = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_dept_id;
            paramArray[9]       = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[9].Value = tgt_emp_id;
            paramArray[10]       = CreateDataParameter("@SCORE", SqlDbType.Float);
            paramArray[10].Value = score;
            paramArray[11]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Float);
            paramArray[11].Value = update_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }
    }
}
