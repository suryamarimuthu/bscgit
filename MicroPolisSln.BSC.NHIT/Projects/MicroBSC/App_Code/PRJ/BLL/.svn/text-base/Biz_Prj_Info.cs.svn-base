using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;
using System.Web.UI.WebControls;

using MicroBSC.PRJ.Dac;

namespace MicroBSC.PRJ.Biz
{
    /// <summary>
    /// Biz_Prj_Info
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Prj_Info
    /// Class Func     : PRJ_INFO Business Logic Class
    /// CREATE DATE    : 2008-04-03 오전 11:33:27
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Prj_Info : Dac_Prj_Info
    {
        public Biz_Prj_Info() { }
        public Biz_Prj_Info(int iprj_ref_id) : base(iprj_ref_id) { }

        public int InsertData(string iprj_code, string iprj_name, decimal iapp_ref_id, string idefinition, string iref_stg, string ieffectiveness, string irange, int iowner_dept_id, int iowner_emp_id, string irequest_dept, string ipriority, decimal itotal_budget, string iprj_type, string iinterested_parties, object iplan_start_date, object iplan_end_date, object iactual_start_date, object iactual_end_date, int itxr_user)
        {
            return base.InsertData_Dac(iprj_code, iprj_name, iapp_ref_id, idefinition, iref_stg, ieffectiveness, irange, iowner_dept_id, iowner_emp_id, irequest_dept, ipriority, itotal_budget, iprj_type, iinterested_parties, iplan_start_date, iplan_end_date, iactual_start_date, iactual_end_date, itxr_user);
        }

        public int UpdateData(int iprj_ref_id, string iprj_code, string iprj_name, decimal iapp_ref_id, string idefinition, string iref_stg, string ieffectiveness, string irange, int iowner_dept_id, int iowner_emp_id, string irequest_dept, string ipriority, decimal itotal_budget, string iprj_type, string iinterested_parties, object iplan_start_date, object iplan_end_date, object iactual_start_date, object iactual_end_date, int itxr_user)
        {
            return base.UpdateData_Dac(iprj_ref_id, iprj_code, iprj_name, iapp_ref_id, idefinition, iref_stg, ieffectiveness, irange, iowner_dept_id, iowner_emp_id, irequest_dept, ipriority, itotal_budget, iprj_type, iinterested_parties, iplan_start_date, iplan_end_date, iactual_start_date, iactual_end_date, itxr_user);
        }

        public int DeleteData(int iprj_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(iprj_ref_id, itxr_user);
        }

        public int ReUsedData(int iprj_ref_id, int itxr_user)
        {
            return base.ReUsedData_Dac(iprj_ref_id, itxr_user);
        }


        public bool IsExist(string iprj_code, string iprj_name)
        {
            return base.Count(iprj_code, iprj_name);
        }

        public bool IsOwnerEmpIDYN(int iemp_ref_id, int iprj_ref_id)
        {
            return base.IsOwnerEmpIDYN(iemp_ref_id, iprj_ref_id);
        }


        public int UpdateComplete(int iprj_ref_id, string icomplete_yn, int itxr_user)
        {
            return base.UpdateComplete_Dac(iprj_ref_id, icomplete_yn, itxr_user);
        }
       
    }
}