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
    public class Biz_ButtonCommandInfos
    {
        #region ============================== [Fields] ==============================
 
        private string 	_command_name;
        private string 	_biz_type;
        private string 	_command_desc;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_ButtonCommandInfos _buttonCommandInfo = new Dac_ButtonCommandInfos();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Command_Name
        {
	        get 
	        {
		        return _command_name;
	        }
	        set
	        {
		        _command_name = ( value==null ? "" : value );
	        }
        }
         
        public string Biz_Type
        {
	        get 
	        {
		        return _biz_type;
	        }
	        set
	        {
		        _biz_type = ( value==null ? "" : value );
	        }
        }
         
        public string Command_Desc
        {
	        get 
	        {
		        return _command_desc;
	        }
	        set
	        {
		        _command_desc = ( value==null ? "" : value );
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
         
        public Biz_ButtonCommandInfos()
	    {
		    
	    }

        public Biz_ButtonCommandInfos(string command_name)
	    {
            DataSet ds = _buttonCommandInfo.Select( command_name, "");
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
		        _command_name   = (dr["COMMAND_NAME"]   == DBNull.Value) ? "" : (string) dr["COMMAND_NAME"];
		        _biz_type       = (dr["BIZ_TYPE"]       == DBNull.Value) ? "" : (string) dr["BIZ_TYPE"];
		        _command_desc   = (dr["COMMAND_DESC"]   == DBNull.Value) ? "" : (string) dr["COMMAND_DESC"];
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyButtonCommandInfo(  string command_name
                                            , string biz_type
                                            , string command_desc
                                            , DateTime update_date
                                            , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _buttonCommandInfo.Update(  null
                                                    , null
                                                    , command_name
                                                    , biz_type
                                                    , command_desc
                                                    , update_date
                                                    , update_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetButtonCommandInfo(  string command_name
                                            , string biz_type)
        {
            return _buttonCommandInfo.Select( command_name, biz_type);
        }

        public DataSet GetButtonCommandInfos()
        {
            return _buttonCommandInfo.Select("", "");
        }
         
        public bool AddButtonCommandInfo( string command_name
                                        , string biz_type
                                        , string command_desc
                                        , DateTime create_date
                                        , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _buttonCommandInfo.Insert(  null
                                                    , null
                                                    , command_name
                                                    , biz_type
                                                    , command_desc
                                                    , create_date
                                                    , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveButtonCommandInfo( string command_name)
        {
	        int affectedRow = 0;

            affectedRow = _buttonCommandInfo.Delete(  null
                                                    , null
                                                    , command_name);

            return (affectedRow > 0) ? true : false;
        }
    }
}
