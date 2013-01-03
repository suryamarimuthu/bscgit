using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;

namespace MicroBSC.PRJ.Biz
{
    /// <summary>
    /// Biz_Prj_Share
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Prj_Share
    /// Class Func     : PRJ_SHARE Business Logic Class
    /// CREATE DATE    : 2008-04-10 오후 2:17:14
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Prj_Share : Dac_Prj_Share
    {
        public Biz_Prj_Share() { }
        public Biz_Prj_Share(int iprj_ref_id, int iemp_ref_id) : base(iprj_ref_id, iemp_ref_id) { }

        public int InsertData(int iprj_ref_id, int iemp_ref_id, int itxr_user)
        {
            return base.InsertData_Dac(iprj_ref_id, iemp_ref_id, itxr_user);
        }

        public int UpdateData(int iprj_ref_id, int iemp_ref_id, int itxr_user)
        {
            return base.UpdateData_Dac(iprj_ref_id, iemp_ref_id, itxr_user);
        }

        public int DeleteData(int iprj_ref_id, int iemp_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(iprj_ref_id, iemp_ref_id, itxr_user);
        }
    }
}