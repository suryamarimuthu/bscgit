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
    public class Biz_PositionBizs
    {
	    #region ============================== [Fields] ==============================
 
        private string 	_pos_biz_id;
        private string 	_pos_biz_name;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_PositionBizs _positionBiz = new Dac_PositionBizs();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Pos_Biz_ID
        {
	        get 
	        {
		        return _pos_biz_id;
	        }
	        set
	        {
		        _pos_biz_id = ( value==null ? "" : value );
	        }
        }
         
        public string Pos_Biz_Name
        {
	        get 
	        {
		        return _pos_biz_name;
	        }
	        set
	        {
		        _pos_biz_name = ( value==null ? "" : value );
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

        public Biz_PositionBizs() 
        {

        }

        public Biz_PositionBizs(string pos_biz_id) 
        {
            DataSet ds = _positionBiz.Select(pos_biz_id);
            DataRow dr;
 
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _pos_biz_id     = (dr["POS_BIZ_ID"]     == DBNull.Value) ? "" : (string) dr["POS_BIZ_ID"];
		        _pos_biz_name   = (dr["POS_BIZ_NAME"]   == DBNull.Value) ? "" : (string) dr["POS_BIZ_NAME"];
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyPositionBiz(string pos_biz_id
                                    , string pos_biz_name
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _positionBiz.Update(null
                                            , null
                                            , pos_biz_id
                                            , pos_biz_name
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPositionBizs()
        {
            return _positionBiz.Select("");
        }
         
        public DataSet GetPositionBiz( string pos_biz_id)
        {
            return _positionBiz.Select(pos_biz_id);
        }
         
        public bool AddPositionBiz(   string pos_biz_id
                                    , string pos_biz_name
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _positionBiz.Insert(null
                                            , null
                                            , pos_biz_id
                                            , pos_biz_name
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemovePositionBiz( string pos_biz_id)
        {
	        int affectedRow = 0;

            affectedRow = _positionBiz.Delete(null
                                            , null
                                            , pos_biz_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
