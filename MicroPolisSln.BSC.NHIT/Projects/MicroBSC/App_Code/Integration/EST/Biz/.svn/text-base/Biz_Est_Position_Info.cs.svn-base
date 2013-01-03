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
    public class Biz_Est_Position_Info
    {
        Dac_Est_Position_Info _data;

        public Biz_Est_Position_Info()
	    {
            _data = new Dac_Est_Position_Info();
	    }


        public DataTable Get_Est_Position_Info(string pos_id
                                            , string pos_name
                                            , string pos_table_name
                                            , string pos_type_name
                                            , string use_yn
                                            , int sort_order)
        {
            DataTable dt = _data.Select_DB(pos_id
                                        , pos_name
                                        , pos_table_name
                                        , pos_type_name
                                        , use_yn
                                        , sort_order);

            return dt;
        }


        public DataTable Get_Est_POsition_Table(string pos_id
                                                , string pos_table_name)
        {
            DataTable dt = _data.Select_Est_Position_Table(pos_id
                                                            , pos_table_name);

            return dt;
        }
    }
}