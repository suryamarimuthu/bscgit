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

namespace MicroBSC.Integration.PRJ.Dac
{
    public class Dac_Prj_Question_Prj_Map : DbAgentBase
    {
        public Dac_Prj_Question_Prj_Map()
        {
        }


        public int Delete_DB(IDbConnection conn, IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object prj_ref_id)
        {
            string query = @"
DELETE FROM PRJ_QUESTION_PRJ_MAP
    WHERE   COMP_ID         = @COMP_ID
        AND EST_ID          = @EST_ID
        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND ESTTERM_SUB_ID  = @ESTTERM_SUB_ID
        AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
        AND PRJ_REF_ID      = @PRJ_REF_ID
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
            paramArray[5] = CreateDataParameter("@PRJ_REF_ID", SqlDbType.Int);
            paramArray[5].Value = prj_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }

        public int Delete_DB_Bulk(IDbConnection conn, IDbTransaction trx
                        , object comp_id
                        , object est_id
                        , object estterm_ref_id
                        , object estterm_sub_id
                        , object estterm_step_id
                        , object prj_ref_id_list)
        {
            string query = string.Format(@"
DELETE FROM PRJ_QUESTION_PRJ_MAP
    WHERE   (   COMP_ID         =   @COMP_ID            OR  @COMP_ID            =   0   )
        AND (   EST_ID          =   @EST_ID             OR  @EST_ID             =''     )
        AND (   ESTTERM_REF_ID  =   @ESTTERM_REF_ID     OR  @ESTTERM_REF_ID     =   0   )
        AND (   ESTTERM_SUB_ID  =   @ESTTERM_SUB_ID     OR  @ESTTERM_SUB_ID     =   0   )
        AND (   ESTTERM_STEP_ID =   @ESTTERM_STEP_ID    OR  @ESTTERM_STEP_ID    =   0   )
        AND PRJ_REF_ID      IN  ({0})
", prj_ref_id_list.ToString());


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

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
    }
}
