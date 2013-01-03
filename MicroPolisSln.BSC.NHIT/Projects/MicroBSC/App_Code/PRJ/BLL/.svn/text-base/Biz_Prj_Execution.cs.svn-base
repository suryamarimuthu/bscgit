using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;

namespace MicroBSC.PRJ.Biz
{
    /// <summary>
    /// Biz_Prj_Execution
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Prj_Execution
    /// Class Func     : PRJ_EXECUTION Business Logic Class
    /// CREATE DATE    : 2008-04-10 오후 2:21:46
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Prj_Execution : Dac_Prj_Execution
    {
        public Biz_Prj_Execution() { }
        public Biz_Prj_Execution(int iexec_ref_id) : base(iexec_ref_id) { }

        public int InsertData(int iprj_ref_id, int itask_ref_id, object iexec_date, decimal iamount,string iexec_content, int itxr_user)
        {
            return base.InsertData_Dac(iprj_ref_id, itask_ref_id, iexec_date, iamount, iexec_content, itxr_user);
        }

        public int UpdateData(int iexec_ref_id, int iprj_ref_id, int itask_ref_id, object iexec_date, decimal iamount, string iexec_content, int itxr_user)
        {
            return base.UpdateData_Dac(iexec_ref_id, iprj_ref_id, itask_ref_id, iexec_date, iamount,iexec_content, itxr_user);
        }

        public int DeleteData(int iexec_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(iexec_ref_id, itxr_user);
        }
    }
}