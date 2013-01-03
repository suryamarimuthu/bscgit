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
	public class Biz_StatusStyles
	{
		#region ============================== [Fields] ====================

		private string _status_style_id;
		private string _status_style_name;
		private string _status_style_desc;
		private DateTime _create_date;
		private int _create_user;
		private DateTime _update_date;
		private int _update_user;

		private Dac_StatusStyles _dac_status_styles = new Dac_StatusStyles();

		#endregion

		#region ============================== [Properties] =================

		public string Status_Style_ID
		{
			get
			{
				return _status_style_id;
			}
			set
			{
				_status_style_id = ( value == null ? "" : value );
			}
		}

		public string Status_Style_Name
		{
			get
			{
				return _status_style_name;
			}
			set
			{
				_status_style_name = ( value == null ? "" : value );
			}
		}

		public string Status_Style_Desc
		{
			get
			{
				return _status_style_desc; 
			}
			set
			{
				_status_style_desc = ( value == null ? "" : value );
			}
		}

		public DateTime Create_date
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

        public int Create_user
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

		public DateTime Update_date
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

        public int Update_user
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

        public Biz_StatusStyles()
		{

		}

		public Biz_StatusStyles( string status_style_id )
		{
			DataSet ds = _dac_status_styles.Select(status_style_id);

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				DataRow dr;

				dr                  = ds.Tables[0].Rows[0];
				_status_style_id    = ( dr["STATUS_STYLE_ID"]      == DBNull.Value ) ? "" : (string)dr["STATUS_STYLE_ID"];
				_status_style_name  = ( dr["STATUS_STYLE_NAME"]    == DBNull.Value ) ? "" : (string)dr["STATUS_STYLE_NAME"];
				_status_style_desc  = ( dr["STATUS_STYLE_DESC"]    == DBNull.Value ) ? "" : (string)dr["STATUS_STYLE_DESC"];
				_create_date        = ( dr["CREATE_DATE"]   == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
				_create_user        = ( dr["CREATE_USER"]   == DBNull.Value ) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
				_update_date        = ( dr["UPDATE_DATE"]   == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
				_update_user        = ( dr["UPDATE_USER"]   == DBNull.Value ) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}

		public bool IsExist( string status_style_id )
		{
			DataSet ds = _dac_status_styles.Select( status_style_id );

			return ( ds.Tables[0].Rows.Count == 1 ) ? true : false;
		}

		public bool ModifyStatusStyle(string status_style_id
									, string status_style_name
									, string status_style_desc
									, DateTime update_date
									, int update_user)
		{
			int affectedRow = 0;

			affectedRow = _dac_status_styles.Update(  null
                                                    , null
                                                    , status_style_id
											        , status_style_name
											        , status_style_desc
											        , update_date
											        , update_user);

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public DataSet GetStatusStyles()
		{
			DataSet ds = _dac_status_styles.Select("");
			return ds;
		}

		public bool AddStatusStyle(   string status_style_id
								    , string status_style_name
								    , string status_style_desc
								    , DateTime create_date
								    , int create_user )
		{
			int affectedRow = 0;

			if ( IsExist( status_style_id ) == false )
			{

				affectedRow = _dac_status_styles.Insert(  null
                                                        , null
                                                        , status_style_id
												        , status_style_name
												        , status_style_desc
												        , create_date
												        , create_user );
			}

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool RemoveStatusStyle( string status_style_id )
		{
			int affectedRow = 0;

			affectedRow = _dac_status_styles.Delete(null, null, status_style_id );

			if ( affectedRow > 0 )
				return true;

			return false;
		}
	}
}