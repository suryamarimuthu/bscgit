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
    public class Biz_Styles
    {
        #region ============================== [Fields] ==============================
 
        private string 	_est_style_id;
        private string 	_est_style_name;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_Styles _dac_style = new Dac_Styles();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Est_Style_ID
        {
	        get 
	        {
		        return _est_style_id;
	        }
	        set
	        {
		        _est_style_id = ( value==null ? "" : value );
	        }
        }
         
        public string Est_Style_Name
        {
	        get 
	        {
		        return _est_style_name;
	        }
	        set
	        {
		        _est_style_name = ( value==null ? "" : value );
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
         
        public Biz_Styles()
        {
            
        }

        public Biz_Styles(string est_style_id)
        {
            DataSet ds = GetStyle(est_style_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _est_style_id   = (dr["EST_STYLE_ID"]       == DBNull.Value) ? "" : (string) dr["EST_STYLE_ID"];
		        _est_style_name = (dr["EST_STYLE_NAME"]     == DBNull.Value) ? "" : (string) dr["EST_STYLE_NAME"];
		        _update_date    = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyStyle(  string est_style_id
                                , string est_style_name
                                , DateTime update_date
                                , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _dac_style.Update(  null
                                            , null
                                            , est_style_id
											, est_style_name
											, update_date
											, update_user);

			if ( affectedRow > 0 )
				return true;

			return false;
        }

        public DataSet GetStyles()
        {
            return GetStyle("");
        }
         
        public DataSet GetStyle( string est_style_id)
        {
	        DataSet ds = _dac_style.Select(est_style_id);
			return ds;
        }
         
        public bool AddStyle( string est_style_id
                            , string est_style_name
                            , DateTime create_date
                            , int create_user)
        {
	        int affectedRow = 0;

			if (IsExist(est_style_id))
			{
				affectedRow = _dac_style.Insert(  null
                                                , null
                                                , est_style_id
											    , est_style_name
											    , create_date
											    , create_user );
			}

			if ( affectedRow > 0 )
				return true;

			return false;
        }
         
        public bool RemoveStyle( string est_style_id)
        {
	        int affectedRow = 0;

			affectedRow = _dac_style.Delete( null, null, est_style_id );

			if ( affectedRow > 0 )
				return true;

			return false;
        }

        public bool IsExist( string est_style_id )
		{
			int intCount = _dac_style.Count( est_style_id );

			return ( intCount > 0 ) ? true : false;
		}
    }
}
