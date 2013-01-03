using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;

namespace MicroBSC.PRJ.Biz
{
    /// <summary>
    /// Biz_Prj_Schedule
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Prj_Schedule
    /// Class Func     : PRJ_SCHEDULE Business Logic Class
    /// CREATE DATE    : 2008-04-10 오후 2:18:40
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Prj_Schedule : Dac_Prj_Schedule
    {
        public Biz_Prj_Schedule() { }
        public Biz_Prj_Schedule(int iprj_ref_id, int itask_ref_id) : base(iprj_ref_id, itask_ref_id) { }

        public int InsertData(int iprj_ref_id, int itask_ref_id, string itask_name, string itask_type, decimal itask_weight, int iup_task_ref_id, string itask_code, object iplan_start_date, object iplan_end_date, object iactual_start_date, object iactual_end_date, decimal iproceed_rate, string iatt_file, string icomplete_yn, string iisdelete, int inode_depth, int iafter_task_ref_id, string idesction, int itxr_user)
        {
            return base.InsertData_Dac(iprj_ref_id, itask_ref_id, itask_name, itask_type, itask_weight, iup_task_ref_id, itask_code, iplan_start_date, iplan_end_date, iactual_start_date, iactual_end_date, iproceed_rate, iatt_file, icomplete_yn, iisdelete, inode_depth,iafter_task_ref_id, idesction, itxr_user);
        }

        public int UpdateData(int iprj_ref_id, int itask_ref_id, string itask_name, string itask_type, decimal itask_weight, int iup_task_ref_id, string itask_code, object iplan_start_date, object iplan_end_date, object iactual_start_date, object iactual_end_date, decimal iproceed_rate, string iatt_file, string icomplete_yn, string iisdelete, int inode_depth, int iafter_task_ref_id, string idesction, int itxr_user)
        {
            return base.UpdateData_Dac(iprj_ref_id, itask_ref_id, itask_name, itask_type, itask_weight, iup_task_ref_id, itask_code, iplan_start_date, iplan_end_date, iactual_start_date, iactual_end_date, iproceed_rate, iatt_file, icomplete_yn, iisdelete, inode_depth, iafter_task_ref_id, idesction, itxr_user);
        }

        public int DeleteData(int iprj_ref_id, int itask_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(iprj_ref_id, itask_ref_id, itxr_user);
        }

        public bool IsExist(int iprj_ref_id, int itask_ref_id)
        {
            int affectedRow = 0;

            affectedRow = base.Count(iprj_ref_id, itask_ref_id);

            if (affectedRow > 0)
                return true;

            return false;
        } 

    }
}