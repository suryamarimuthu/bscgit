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
    public class Biz_ReportItems
    {
        #region ============================== [Fields] ==============================
 
        private string 	_rpt_itm_id;
        private string 	_prt_itm_name;
        private DateTime 	_create_date;
        private int 	_create_user;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_ReportItems _reportItem = new Dac_ReportItems();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Rpt_Itm_ID
        {
	        get 
	        {
		        return _rpt_itm_id;
	        }
	        set
	        {
		        _rpt_itm_id = ( value==null ? "" : value );
	        }
        }
         
        public string Prt_Itm_Name
        {
	        get 
	        {
		        return _prt_itm_name;
	        }
	        set
	        {
		        _prt_itm_name = ( value==null ? "" : value );
	        }
        }
         
        public DateTime Create_Date
        {
	        get 
	        {
		        return _create_date;
	        }
	        set
	        {
		        _create_date = value;
	        }
        }
         
        public int Create_User
        {
	        get 
	        {
		        return _create_user;
	        }
	        set
	        {
		        _create_user = value;
	        }
        }
         
        public DateTime Update_Date
        {
	        get 
	        {
		        return _update_date;
	        }
	        set
	        {
		        _update_date = value;
	        }
        }
         
        public int Update_User
        {
	        get 
	        {
		        return _update_user;
	        }
	        set
	        {
		        _update_user = value;
	        }
        }
        #endregion
         
        public Biz_ReportItems()
	    {
		    
	    }

        public Biz_ReportItems(string rpt_itm_id)
	    {
            DataSet ds = _reportItem.Select(rpt_itm_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _rpt_itm_id     = (dr["RPT_ITM_ID"]     == DBNull.Value) ? "" : (string) dr["RPT_ITM_ID"];
		        _prt_itm_name   = (dr["PRT_ITM_NAME"]   == DBNull.Value) ? "" : (string) dr["PRT_ITM_NAME"];
		        _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyReportItem( string rpt_itm_id
                                    , string prt_itm_name
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _reportItem.Update(null
                                        , null
                                        , rpt_itm_id
                                        , prt_itm_name
                                        , update_date
                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetReportItem( string rpt_itm_id)
        {
            return _reportItem.Select(rpt_itm_id);
        }
         
        public bool AddReportItem(string rpt_itm_id
                                , string prt_itm_name
                                , DateTime create_date
                                , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _reportItem.Insert(null
                                        , null
                                        , rpt_itm_id
                                        , prt_itm_name
                                        , create_date
                                        , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveReportItem( string rpt_itm_id)
        {
	        int affectedRow = 0;

            affectedRow = _reportItem.Delete(null
                                        , null
                                        , rpt_itm_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
