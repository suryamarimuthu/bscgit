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
    public class Biz_Role_Menu_Rel
    {
        Dac_Role_Menu_Rel _data;


        public Biz_Role_Menu_Rel()
        {
            _data = new Dac_Role_Menu_Rel();
        }

        public DataTable GetRoleMenuRel_DB(string filter)
        {
            return _data.Select_DB(filter).Tables[0];
        }


    }
}