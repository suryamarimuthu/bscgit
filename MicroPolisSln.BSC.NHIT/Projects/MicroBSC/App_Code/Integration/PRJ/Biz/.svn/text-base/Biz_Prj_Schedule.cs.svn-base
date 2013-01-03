using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.PRJ.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.PRJ.Biz
{
    public class Biz_Prj_Schedule
    {
        #region ============================== [Fields] ==============================

        private Dac_Prj_Schedule _data = new Dac_Prj_Schedule();

        #endregion

        public Biz_Prj_Schedule()
        {

        }

        public int ModifyEstData(DataTable dt)
        {
            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.PRJ.Dac.Dac_Prj_Schedule dacEstData = new Dac_Prj_Schedule();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];

                    intTxrCnt += dacEstData.Update_DB(conn
                                                    , trx
                                                    , row["COMP_ID"]
                                                    , row["EST_ID"]
                                                    , row["ESTTERM_REF_ID"]
                                                    , row["ESTTERM_SUB_ID"]
                                                    , row["ESTTERM_STEP_ID"]
                                                    , row["POINT"]);
                }

                trx.Commit();
            }
            catch
            {
                trx.Rollback();
                return 0;
            }
            finally
            {
                conn.Close();
            }

            return intTxrCnt;
        }

        public DataTable GetEstData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id)
        {
            MicroBSC.Integration.PRJ.Dac.Dac_Prj_Schedule dacEstData = new Dac_Prj_Schedule();
            return dacEstData.SelectData_DB(comp_id
                                           , est_id
                                           , estterm_ref_id
                                           , estterm_sub_id
                                           , estterm_step_id);
        }

        public string RemoveEstDataWithJoin_DB()
        {
            
            string returnVal = string.Empty;

            

            return returnVal;
        }

        public int RemoveEstData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_ste_id)
        {
            MicroBSC.Integration.PRJ.Dac.Dac_Prj_Schedule dacEstData = new Dac_Prj_Schedule();
            return dacEstData.Delete(null
                                , null
                                , comp_id
                                ,  est_id
                                ,  estterm_ref_id
                                ,  estterm_sub_id);
        }


        public int AddData(int iprj_ref_id
                        , int itask_ref_id
                        , string itask_name
                        , string itask_type
                        , int iup_task_ref_id
                        , string itask_code
                        , decimal itask_weight
                        , object iplan_start_date
                        , object iplan_end_date
                        , object iactual_start_date
                        , object iactual_end_date
                        , decimal iproceed_rate
                        , string iatt_file
                        , string icomplete_yn
                        , string iisdelete
                        , int inode_depth
                        , int iafter_task_ref_id
                        , string idesction
                        , int itxr_user)
        {
            int affectedRow = 0;

            MicroBSC.Integration.PRJ.Dac.Dac_Prj_Schedule dacEstData = new Dac_Prj_Schedule();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (itask_ref_id < 1)
                    itask_ref_id = _data.SelectMaxTaskRefID(conn, trx, iprj_ref_id);

                affectedRow = _data.Insert_DB(conn
                                        , trx
                                        , iprj_ref_id
                                        , itask_ref_id
                                        , itask_name
                                        , itask_type
                                        , iup_task_ref_id
                                        , itask_code
                                        , itask_weight
                                        , iplan_start_date
                                        , iplan_end_date
                                        , iactual_start_date
                                        , iactual_end_date
                                        , iproceed_rate
                                        , iatt_file
                                        , icomplete_yn
                                        , iisdelete
                                        , inode_depth
                                        , iafter_task_ref_id
                                        , idesction
                                        , itxr_user);
                trx.Commit();
            }
            catch
            {
                trx.Rollback();
                return 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow;
        }

    }
}