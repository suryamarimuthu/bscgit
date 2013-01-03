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
using MicroBSC.Integration.BSC.Dac;

namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Mbo_Kpi_Score_Mt
    {
        Dac_Bsc_Mbo_Kpi_Score_Mt _data;

        public Biz_Bsc_Mbo_Kpi_Score_Mt()
        {
            _data = new Dac_Bsc_Mbo_Kpi_Score_Mt();
        }

        public bool Modify_Score(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string ymd
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , double score
                                , int update_user_ref_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow = _data.Update_Score(conn, trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , ymd
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , score
                                                , update_user_ref_id);
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                affectedRow = 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow > 0 ? true : false;
        }
    }
}
