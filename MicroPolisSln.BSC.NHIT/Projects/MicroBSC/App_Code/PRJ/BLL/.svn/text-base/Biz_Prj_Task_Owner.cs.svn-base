using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;

namespace MicroBSC.PRJ.Biz
{
    /// <summary>
    /// Biz_Prj_Task_Owner
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Prj_Task_Owner
    /// Class Func     : PRJ_TASK_OWNER Business Logic Class
    /// CREATE DATE    : 2008-04-10 오후 2:15:36
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Prj_Task_Owner : Dac_Prj_Task_Owner
    {
        public Biz_Prj_Task_Owner() { }
        public Biz_Prj_Task_Owner(int iprj_ref_id, int iemp_ref_id, int itask_ref_id) : base(iprj_ref_id, iemp_ref_id, itask_ref_id) { }

        public int InsertData(int iprj_ref_id, int iemp_ref_id, int itask_ref_id, string itask_owner_yn, int itxr_user)
        {
            return base.InsertData_Dac(iprj_ref_id, iemp_ref_id, itask_ref_id, itask_owner_yn, itxr_user);
        }

        public int UpdateData(int iprj_ref_id, int iemp_ref_id, int itask_ref_id, string itask_owner_yn, int itxr_user)
        {
            return base.UpdateData_Dac(iprj_ref_id, iemp_ref_id, itask_ref_id, itask_owner_yn, itxr_user);
        }

        public int DeleteData(int iprj_ref_id, int iemp_ref_id, int itask_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(iprj_ref_id, iemp_ref_id, itask_ref_id, itxr_user);
        }
    }
}