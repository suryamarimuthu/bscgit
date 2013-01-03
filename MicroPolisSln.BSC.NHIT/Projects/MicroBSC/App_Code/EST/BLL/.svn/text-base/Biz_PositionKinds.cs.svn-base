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
    public class Biz_PositionKinds
    {
        #region ============================== [Fields] ==============================
 
        private string 	_pos_knd_id;
        private string 	_pos_knd_name;
        private DateTime 	_create_date;
        private int 	_create_user;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_PositionKinds _postionKind = new Dac_PositionKinds();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Pos_Knd_ID
        {
	        get 
	        {
		        return _pos_knd_id;
	        }
	        set
	        {
		        _pos_knd_id = ( value==null ? "" : value );
	        }
        }
         
        public string Pos_Knd_Name
        {
	        get 
	        {
		        return _pos_knd_name;
	        }
	        set
	        {
		        _pos_knd_name = ( value==null ? "" : value );
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
         
        public Biz_PositionKinds()
	    {
		    
	    }

        public Biz_PositionKinds(string pos_knd_id)
	    {
            DataSet ds = _postionKind.Select(pos_knd_id);
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _pos_knd_id     = (dr["POS_KND_ID"]   == DBNull.Value) ? "" : (string) dr["POS_KND_ID"];
		        _pos_knd_name   = (dr["POS_KND_NAME"] == DBNull.Value) ? "" : (string) dr["POS_KND_NAME"];
		        _create_date    = (dr["CREATE_DATE"]  == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _create_user    = (dr["CREATE_USER"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
		        _update_date    = (dr["UPDATE_DATE"]  == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyPositionKnd( string pos_knd_id
                                    , string pos_knd_name
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _postionKind.Update(null
                                            , null
                                            , pos_knd_id
                                            , pos_knd_name
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPositionKinds()
        {
            return _postionKind.Select("");
        }
         
        public DataSet GetPositionKnd( string pos_knd_id)
        {
            return _postionKind.Select(pos_knd_id);
        }
         
        public bool AddPositionKnd( string pos_knd_id
                                , string pos_knd_name
                                , DateTime create_date
                                , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _postionKind.Insert(null
                                            , null
                                            , pos_knd_id
                                            , pos_knd_name
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemovePositionKnd( string pos_knd_id)
        {
	        int affectedRow = 0;

            affectedRow = _postionKind.Delete(null
                                            , null
                                            , pos_knd_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
