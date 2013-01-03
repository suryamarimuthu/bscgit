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
using MicroBSC.Biz.BSC.Dac;

/// <summary>
/// Summary description for Biz_EmpComDeptDetails
/// </summary>
public class Biz_EmpComDeptDetails
{
    public DataSet GetComDeptDetail(int emp_ref_id, int dept_ref_id) 
    {
        Dac_EmpComDeptDetails empComDeptDetail = new Dac_EmpComDeptDetails();

        return empComDeptDetail.GetEmpComdeptdetail(emp_ref_id, dept_ref_id);
    }

    public bool AddEmpComDeptDetail(IDbConnection conn, IDbTransaction trx, int emp_ref_id, int dept_ref_id, int create_user)
    {
        Dac_EmpComDeptDetails empComDeptDetail = new Dac_EmpComDeptDetails();

        if (empComDeptDetail.IsEmpComDeptDetail(emp_ref_id, dept_ref_id)) 
        {
            empComDeptDetail.RemoveEmpComDeptDetail(conn, trx, emp_ref_id);
        }

        return empComDeptDetail.AddEmpComDeptDetail(conn, trx, emp_ref_id, dept_ref_id, create_user);
    }

    public bool AddEmpComDeptDetail(int emp_ref_id, int dept_ref_id, int create_user)
    {
        Dac_EmpComDeptDetails empComDeptDetail = new Dac_EmpComDeptDetails();

        if (empComDeptDetail.IsEmpComDeptDetail(emp_ref_id, dept_ref_id)) 
        {
            empComDeptDetail.RemoveEmpComDeptDetail(emp_ref_id);
        }

        return empComDeptDetail.AddEmpComDeptDetail(emp_ref_id, dept_ref_id, create_user);
    }

    public bool RemoveEmpComDeptDetail(IDbConnection conn, IDbTransaction trx, int emp_ref_id)
    {
        Dac_EmpComDeptDetails empComDeptDetail = new Dac_EmpComDeptDetails();
        return empComDeptDetail.RemoveEmpComDeptDetail(conn, trx, emp_ref_id);
    }

    public bool RemoveEmpComDeptDetail(int emp_ref_id)
    {
        Dac_EmpComDeptDetails empComDeptDetail = new Dac_EmpComDeptDetails();
        return empComDeptDetail.RemoveEmpComDeptDetail(emp_ref_id);
    }
}
