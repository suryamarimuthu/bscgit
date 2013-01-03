using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.COM.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Biz
{
    public class Biz_Rel_Dept_Emp
    {
        Dac_Rel_Dept_Emp _data;


        public Biz_Rel_Dept_Emp()
        {
            _data = new Dac_Rel_Dept_Emp();
        }

        public DataTable GetRelDeptEmp_DB(int emp_ref_id
                                        , int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id) 
        {
            MicroBSC.Integration.COM.Dac.Dac_Rel_Dept_Emp dacRelDeptEmp = new Dac_Rel_Dept_Emp();
            return dacRelDeptEmp.SelectRelDeptEmp_DB(emp_ref_id
                                                   , comp_id
                                                   , est_id
                                                   , estterm_ref_id
                                                   , estterm_sub_id).Tables[0];
        }



        public string Get_Dept_ID_of_Emp_ID(IDbConnection conn, IDbTransaction trx
                                            , string EMP_REF_ID)
        { 
            return _data.Select_Dept_ID_of_Emp_ID(conn, trx, EMP_REF_ID);
        }

        public string Get_Dept_ID_of_Emp_ID(string EMP_REF_ID)
        {
            return Get_Dept_ID_of_Emp_ID(null, null, EMP_REF_ID);
        }
    }
}