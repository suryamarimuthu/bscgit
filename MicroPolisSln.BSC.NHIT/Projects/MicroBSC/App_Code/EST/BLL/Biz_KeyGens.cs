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
    public class Biz_KeyGens
    {
        public string GetKey(string tableName, string columnName) 
        {
            Dac_KeyGens keyGen = new Dac_KeyGens();
            return keyGen.GetCode(tableName, columnName);
        }
    }
}
