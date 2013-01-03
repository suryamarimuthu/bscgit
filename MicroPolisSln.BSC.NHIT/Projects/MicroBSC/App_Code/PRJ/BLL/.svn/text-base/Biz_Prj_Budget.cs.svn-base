using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;

namespace MicroBSC.PRJ.Biz
{
    /// <summary>
    /// Biz_Prj_Budget
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Prj_Budget
    /// Class Func     : PRJ_BUDGET Business Logic Class
    /// CREATE DATE    : 2008-04-10 오후 2:23:57
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Prj_Budget : Dac_Prj_Budget
    {
        public Biz_Prj_Budget() { }
        public Biz_Prj_Budget(int iprj_ref_id, string ibudget_ym) : base(iprj_ref_id, ibudget_ym) { }

        public int InsertData(int iprj_ref_id, string ibudget_ym, decimal imonthly_amount, int itxr_user)
        {
            return base.InsertData_Dac(iprj_ref_id, ibudget_ym, imonthly_amount, itxr_user);
        }

        public int UpdateData(int iprj_ref_id, string ibudget_ym, decimal imonthly_amount, int itxr_user)
        {
            return base.UpdateData_Dac(iprj_ref_id, ibudget_ym, imonthly_amount, itxr_user);
        }

        public int DeleteData(int iprj_ref_id, string ibudget_ym, int itxr_user)
        {
            return base.DeleteData_Dac(iprj_ref_id, ibudget_ym, itxr_user);
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ITYPE", typeof(string));
            dataTable.Columns.Add("PRJ_REF_ID", typeof(int));
            dataTable.Columns.Add("BUDGET_YM", typeof(string));
            dataTable.Columns.Add("BUDGET_YM_NAME", typeof(string));
            dataTable.Columns.Add("MONTHLY_AMOUNT", typeof(decimal));
            dataTable.Columns.Add("AMOUNT", typeof(decimal));
            dataTable.Columns.Add("RATE", typeof(decimal));

            return dataTable;
        }
        
    }
}