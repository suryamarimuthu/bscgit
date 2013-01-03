using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Term_Info
    {
        Dac_Est_Term_Info _data;

        public Biz_Est_Term_Info()
	    {
            _data = new Dac_Est_Term_Info();
	    }


        public DataTable Get_Start_End_YearMonth(int comp_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id)
        {
            DataTable dt = _data.Select_Start_End_YearMonth(comp_id
                                                        , estterm_sub_id
                                                        , estterm_ref_id);

            return dt;
        }
    }
}