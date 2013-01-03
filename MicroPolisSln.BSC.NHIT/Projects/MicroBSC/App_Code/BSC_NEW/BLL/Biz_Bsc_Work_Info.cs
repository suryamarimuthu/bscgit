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


/// <summary>
/// Biz_Bsc_Work_Info의 요약 설명입니다.
/// </summary>
/// 

namespace MicroBSC.BSC.Biz
{

    public class Biz_Bsc_Work_Info : MicroBSC.BSC.Dac.Dac_Bsc_Work_Info
    {
        public Biz_Bsc_Work_Info() { }

        public Biz_Bsc_Work_Info(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id)
            : base(iestterm_ref_id, iest_dept_ref_id, iwork_ref_id) { }
        


        public int InsertData(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iwork_pool_ref_id, string iwork_code, string iwork_name, string iwork_desc, int iwork_emp_id, string iwork_priority, string iwork_type, string iwork_issue, string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            return base.InsertData_Dac( iestterm_ref_id,  iest_dept_ref_id,  iwork_ref_id, iwork_pool_ref_id, iwork_code,  iwork_name, iwork_desc,  iwork_emp_id,  iwork_priority,  iwork_type,  iwork_issue, iadd_file,  iapp_ref_id,  iuse_yn, icomplete_yn, itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iwork_pool_ref_id, string iwork_code, string iwork_name, string iwork_desc, int iwork_emp_id, string iwork_priority, string iwork_type, string iwork_issue, string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        { 
            return base.UpdateData_Dac( iestterm_ref_id,  iest_dept_ref_id,  iwork_ref_id, iwork_pool_ref_id, iwork_code,  iwork_name, iwork_desc,  iwork_emp_id,  iwork_priority,  iwork_type,  iwork_issue, iadd_file,  iapp_ref_id,  iuse_yn,  icomplete_yn, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(iestterm_ref_id, iest_dept_ref_id, iwork_ref_id, itxr_user);
        }

        public int ReUsedData(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(iestterm_ref_id, iest_dept_ref_id, iwork_ref_id, itxr_user);
        }

        public int ReCompleteData(int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, Int32 itxr_user)
        {
            return base.ReCompleteData_Dac(iestterm_ref_id, iest_dept_ref_id, iwork_ref_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iwork_pool_ref_id, string iwork_code, string iwork_name, string iwork_desc, int iwork_emp_id, string iwork_priority, string iwork_type, string iwork_issue, string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            return base.InsertData_Dac( conn,  trx, iestterm_ref_id,  iest_dept_ref_id,  iwork_ref_id, iwork_pool_ref_id, iwork_code,  iwork_name,  iwork_desc,  iwork_emp_id,  iwork_priority,  iwork_type,  iwork_issue, iadd_file,  iapp_ref_id,  iuse_yn,  icomplete_yn, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, int iwork_pool_ref_id, string iwork_code, string iwork_name, string iwork_desc, int iwork_emp_id, string iwork_priority, string iwork_type, string iwork_issue, string iadd_file, decimal iapp_ref_id, string iuse_yn, string icomplete_yn, int itxr_user)
        {
            return base.UpdateData_Dac( conn,  trx, iestterm_ref_id,  iest_dept_ref_id,  iwork_ref_id, iwork_pool_ref_id, iwork_code,  iwork_name, iwork_desc,  iwork_emp_id,  iwork_priority,  iwork_type,  iwork_issue, iadd_file,  iapp_ref_id,  iuse_yn, icomplete_yn, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, iwork_ref_id, itxr_user);
        }
        
        public int ReUsedData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int iwork_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, iwork_ref_id, itxr_user);
        }
      
    }
}