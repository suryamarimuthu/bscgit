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
	public class Biz_Status
	{
		#region ============================== [Fields] ====================

		private string _status_id;
        private int _seq;
		private string _status_name;
        private string _status_desc;
        private string _status_img_path;
        private string _status_style_id;
		private DateTime _create_date;
		private int _create_user;
		private DateTime _update_date;
		private int _update_user;

		private Dac_Status _dac_status = new Dac_Status();

		#endregion

		#region ============================== [Properties] =================

		public string Status_ID
		{
			get
			{
				return _status_id;
			}
			set
			{
				_status_id = ( value == null ? "" : value );
			}
		}

        public int Seq
		{
			get
			{
				return _seq;
			}
			set
			{
				_seq = value;
			}
		}

		public string Status_Name
		{
			get
			{
				return _status_name;
			}
			set
			{
				_status_name = ( value == null ? "" : value );
			}
		}

        public string Status_Desc
        {
            get
            {
                return _status_desc;
            }
            set
            {
                _status_desc = (value == null ? "" : value);
            }
        }

        public string Status_Img_Path
        {
            get
            {
                return _status_img_path;
            }
            set
            {
                _status_img_path = (value == null ? "" : value);
            }
        }

        public string Status_Style_ID
        {
            get
            {
                return _status_style_id;
            }
            set
            {
                _status_style_id = (value == null ? "" : value);
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

        public Biz_Status()
		{

		}

		public Biz_Status( string status_id, string status_style_id )
		{
			DataSet ds = _dac_status.Select(status_id, status_style_id);

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				DataRow dr;

				dr                  = ds.Tables[0].Rows[0];
				_status_id          = ( dr["STATUS_ID"]         == DBNull.Value ) ? "" : (string)dr["STATUS_ID"];
                _seq                = ( dr["SEQ"]               == DBNull.Value ) ? 0 : Convert.ToInt32(dr["SEQ"]);
				_status_name        = ( dr["STATUS_NAME"]       == DBNull.Value ) ? "" : (string)dr["STATUS_NAME"];
                _status_desc        = ( dr["STATUS_DESC"]       == DBNull.Value) ? "" : (string)dr["STATUS_DESC"];
                _status_img_path    = ( dr["STATUS_IMG_PATH"]   == DBNull.Value) ? "" : (string)dr["STATUS_IMG_PATH"];
                _status_style_id    = ( dr["STATUS_STYLE_ID"]   == DBNull.Value) ? "" : (string)dr["STATUS_STYLE_ID"];
				_create_date        = ( dr["CREATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
				_create_user        = ( dr["CREATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
				_update_date        = ( dr["UPDATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
				_update_user        = ( dr["UPDATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}


		public bool IsExist( string status_id )
		{
			int intCount = _dac_status.Count( status_id );

			return ( intCount > 0 ) ? true : false;
		}

		public bool ModifyStatus( string status_id
                                , int seq
								, string status_name
                                , string status_desc
                                , string status_img_path
                                , string status_style_id
								, DateTime update_date
								, int update_user)
		{
			int affectedRow = 0;

			affectedRow = _dac_status.Update( null
                                            , null
                                            , status_id
                                            , seq
											, status_name
                                            , status_desc
                                            , status_img_path
                                            , status_style_id
											, update_date
											, update_user);

			if ( affectedRow > 0 )
				return true;

			return false;
		}


		public DataSet GetStatuses(string status_style_id)
		{
			DataSet ds = _dac_status.Select("", status_style_id);
			return ds;
		}

        public DataSet GetStatusByEstID(string est_id)
		{
			DataSet ds = _dac_status.SelectByEstID("", "", est_id);
			return ds;
		}

		public bool AddStatus(string status_id
                            , int seq
							, string status_name
                            , string status_desc
                            , string status_img_path
                            , string status_style_id
							, DateTime create_date
							, int create_user )
		{
			int affectedRow = 0;

			if ( IsExist( status_id ) == false )
			{
				affectedRow = _dac_status.Insert( null
                                                , null
                                                , status_id
                                                , seq
												, status_name
                                                , status_desc
                                                , status_img_path
                                                , status_style_id
												, create_date
												, create_user );
			}

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool RemoveStatus( string status_id )
		{
			int affectedRow = 0;

			affectedRow = _dac_status.Delete(null, null, status_id );

			if ( affectedRow > 0 )
				return true;

			return false;
		}
	}
}