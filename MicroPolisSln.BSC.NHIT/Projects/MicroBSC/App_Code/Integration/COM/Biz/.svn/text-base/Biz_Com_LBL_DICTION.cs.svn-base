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
    public class Biz_Com_Lbl_Diction
    {
        Dac_Com_Lbl_Diction _data;


        public Biz_Com_Lbl_Diction()
        {
            _data = new Dac_Com_Lbl_Diction();
        }

        public DataTable GetLBL(string lbl_code)
        {
            return _data.Select_DB(lbl_code);
        }


    }
}