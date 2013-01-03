using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for Biz_Bsc_Kpi_Notice
/// </summary>
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Kpi_Notice
    {
        public Biz_Bsc_Kpi_Notice()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelectNoticeAll(string title)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Notice().SelectNoticeAll(title);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
