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
    public class Biz_Com_Emp_Role_Rel
    {
        Dac_Com_Emp_Role_Rel _data;

        public Biz_Com_Emp_Role_Rel()
        {
            _data = new Dac_Com_Emp_Role_Rel();
        }


        /// <summary>
        /// 직원과 권한비교
        /// </summary>
        public bool IsMatch_EmpRole(int emp_ref_id, int role_ref_id)
        {
            int result;

            result = _data.Select_Cnt_EmpRole(emp_ref_id, role_ref_id);

            return result > 0 ? true : false;
        }


        public DataTable Get_EmpRoleRel(int emp_ref_id, int role_ref_id)
        {
            return _data.Select_EmpRoleRel(emp_ref_id, role_ref_id);
        }

    }
}