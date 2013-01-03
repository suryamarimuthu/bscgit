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
    public class Biz_Com_Dept_Info
    {
        Dac_Com_Dept_Info _data;

        public int DEPT_REF_ID;
        public string DEPT_NAME;


        public Biz_Com_Dept_Info()
        {
            _data = new Dac_Com_Dept_Info();
        }

        public Biz_Com_Dept_Info(int dept_ref_id)
        {
            _data = new Dac_Com_Dept_Info();

            DataTable dt = _data.Select_DB(dept_ref_id);

            if (dt.Rows.Count > 0)
            {
                DEPT_NAME = DataTypeUtility.GetString(dt.Rows[0]["DEPT_NAME"]);
            }
        }


        public DataTable GetDeptRoot_DB() 
        {
            return _data.SelectRoot_DB();
        }



        /// <summary>
        /// 부서와 상위부서 목록
        /// </summary>
        public DataTable Get_Dept_UpDept_List()
        {
            DataTable dt = _data.Select_Dept_UpDept();

            return dt;
        }
    }
}