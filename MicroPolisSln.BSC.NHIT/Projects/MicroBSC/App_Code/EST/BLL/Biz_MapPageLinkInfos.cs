using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Dac;
using MicroBSC.Data;

namespace MicroBSC.Estimation.Biz
{
    public class Biz_MapPageLinkInfos
    {
        private Dac_MapPageLinkInfos _mapPageLinkInfo = new Dac_MapPageLinkInfos();

	    public Biz_MapPageLinkInfos()
	    {
		    
	    }

        public DataSet GetMapPageLinks()
        {
	        return _mapPageLinkInfo.Select();
        }
    }
}
