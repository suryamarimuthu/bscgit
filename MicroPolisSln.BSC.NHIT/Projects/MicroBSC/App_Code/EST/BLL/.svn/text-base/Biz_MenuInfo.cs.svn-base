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
	public class Biz_MenuInfo
	{

		#region ============================== [Fields] =======================
		 
		private int 	_menu_ref_id;
		private int 	_up_menu_id;
		private string 	_menu_name;
		private string 	_menu_dir;
		private string 	_menu_page_name;
		private string 	_menu_param;
		private string 	_menu_full_path;
		private string 	_menu_desc;
		private int 	_menu_priority;
		private string 	_menu_auth_type;
		private string 	_menu_type;
		private string 	_menu_name_image_path;
		private string 	_menu_name_image_path_u;
		private string 	_menu_prev_icon_path;
		private DateTime 	_menu_create_date;
		private string 	_show_left_menu;
        private string  _up_menu_name;

		private Dac_MenuInfo _dac_menuinfo = new Dac_MenuInfo();

        private Dac_MenuInfo _up_menuinfo = new Dac_MenuInfo();
		#endregion
		 
		#region ============================== [Properties] =====================
		 
		public int Menu_ref_id
		{
			get 
			{
				return _menu_ref_id;
			}
			set
			{
				_menu_ref_id = value;
			}
		}
		 
		public int Up_menu_id
		{
			get 
			{
				return _up_menu_id;
			}
			set
			{
				_up_menu_id = value;
			}
		}
		 
		public string Menu_name
		{
			get 
			{
				return _menu_name;
			}
			set
			{
				_menu_name = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_dir
		{
			get 
			{
				return _menu_dir;
			}
			set
			{
				_menu_dir = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_page_name
		{
			get 
			{
				return _menu_page_name;
			}
			set
			{
				_menu_page_name = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_param
		{
			get 
			{
				return _menu_param;
			}
			set
			{
				_menu_param = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_full_path
		{
			get 
			{
				return _menu_full_path;
			}
			set
			{
				_menu_full_path = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_desc
		{
			get 
			{
				return _menu_desc;
			}
			set
			{
				_menu_desc = ( value==null ? "" : value );
			}
		}
		 
		public int Menu_priority
		{
			get 
			{
				return _menu_priority;
			}
			set
			{
				_menu_priority = value;
			}
		}
		 
		public string Menu_auth_type
		{
			get 
			{
				return _menu_auth_type;
			}
			set
			{
				_menu_auth_type = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_type
		{
			get 
			{
				return _menu_type;
			}
			set
			{
				_menu_type = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_name_image_path
		{
			get 
			{
				return _menu_name_image_path;
			}
			set
			{
				_menu_name_image_path = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_name_image_path_u
		{
			get 
			{
				return _menu_name_image_path_u;
			}
			set
			{
				_menu_name_image_path_u = ( value==null ? "" : value );
			}
		}
		 
		public string Menu_prev_icon_path
		{
			get 
			{
				return _menu_prev_icon_path;
			}
			set
			{
				_menu_prev_icon_path = ( value==null ? "" : value );
			}
		}
		 
		public DateTime Menu_create_date
		{
			get 
			{
				return _menu_create_date;
			}
			set
			{
				_menu_create_date = value;
			}
		}
		 
		public string Show_left_menu
		{
			get 
			{
				return _show_left_menu;
			}
			set
			{
				_show_left_menu = ( value==null ? "" : value );
			}
		}

        public string Up_Menu_name
        {
            get
            {
                return _up_menu_name;
            }
            set
            {
                _up_menu_name = (value == null ? "" : value);
            }
        }

		#endregion

		public Biz_MenuInfo()
		{
		}

		public Biz_MenuInfo( int menu_ref_id )
		{
			DataSet ds = _dac_menuinfo.Select( menu_ref_id
											, string.Empty 
											, string.Empty 
											, string.Empty 
											);
			DataRow dr;

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				dr = ds.Tables[0].Rows[0];

				_menu_ref_id			= DataTypeUtility.GetToInt32(dr["MENU_REF_ID"]);
				_up_menu_id				= DataTypeUtility.GetToInt32(dr["UP_MENU_ID"]);
				_menu_name				= DataTypeUtility.GetValue(dr["MENU_NAME"]);
                _menu_dir               = DataTypeUtility.GetValue(dr["MENU_DIR"]);
				_menu_page_name			= DataTypeUtility.GetValue(dr["MENU_PAGE_NAME"]);
				_menu_param				= DataTypeUtility.GetValue(dr["MENU_PARAM"]);
				_menu_full_path			= DataTypeUtility.GetValue(dr["MENU_FULL_PATH"]);
				_menu_desc				= DataTypeUtility.GetValue(dr["MENU_DESC"]);
				_menu_priority			= DataTypeUtility.GetToInt32(dr["MENU_PRIORITY"]);
				_menu_auth_type			= DataTypeUtility.GetValue(dr["MENU_AUTH_TYPE"]);
				_menu_type				= DataTypeUtility.GetValue(dr["MENU_TYPE"]);
				_menu_name_image_path	= DataTypeUtility.GetValue(dr["MENU_NAME_IMAGE_PATH"]);
				_menu_name_image_path_u = DataTypeUtility.GetValue(dr["MENU_NAME_IMAGE_PATH_U"]);
				_menu_prev_icon_path	= DataTypeUtility.GetValue(dr["MENU_PREV_ICON_PATH"]);
				_menu_create_date		= DataTypeUtility.GetToDateTime(dr["MENU_CREATE_DATE"]);
				_show_left_menu			= DataTypeUtility.GetValue(dr["SHOW_LEFT_MENU"]);


                DataSet Up_ds = _up_menuinfo.Select( _up_menu_id
											, string.Empty 
											, string.Empty 
											, string.Empty 
											);

                if(Up_ds.Tables != null && Up_ds.Tables[0].Rows.Count == 1)
                {
                   DataRow up_dr = Up_ds.Tables[0].Rows[0];

                   _up_menu_name = DataTypeUtility.GetValue(up_dr["MENU_NAME"]);     
                }
			}
		}

		public DataSet GetMenuInfoByMenuRefID( int menu_ref_id )
		{
			DataSet dtReturn = _dac_menuinfo.Select( menu_ref_id
													, string.Empty
													, string.Empty
													, string.Empty
													);

			return dtReturn;
		}

		public DataSet GetMenuInfoByMenuFullPath( string menu_full_path )
		{
			DataSet dtReturn = _dac_menuinfo.Select( DBNull.Value
													, string.Empty
													, string.Empty
													, menu_full_path
													);

			return dtReturn;
		}

        public DataSet GetMenuInfos()
        {
            DataSet dtReturn = _dac_menuinfo.Select(DBNull.Value
                                                    , string.Empty
                                                    , string.Empty
                                                    , string.Empty
                                                    );

            return dtReturn;
        }

        public int GetMenuIDByMenuFullPath(string menu_full_path)
        {
            DataSet dt = _dac_menuinfo.Select(DBNull.Value
                                                       , string.Empty
                                                       , string.Empty
                                                       , menu_full_path
                                                       );
            if (dt.Tables[0].Rows.Count > 0)
            {
                return DataTypeUtility.GetToInt32(dt.Tables[0].Rows[0]["MENU_REF_ID"]);
            }
            else
            {
                return 0;
            }
        }

		public int GetUpMenuIDByMenuFullPath( string menu_full_path )
		{
			DataSet dt = _dac_menuinfo.Select( DBNull.Value
											, string.Empty
											, string.Empty
											, menu_full_path
											);
			if ( dt.Tables[0].Rows.Count == 1 )
			{
				return DataTypeUtility.GetToInt32( dt.Tables[0].Rows[0]["UP_MENU_ID"] );
			}
			else
			{
				return 0;
			}
		}



        public bool ModifyMenuInfo( int menu_ref_id
									, int up_menu_id
									, string menu_name
									, string menu_dir
									, string menu_page_name
									, string menu_param
									, string menu_full_path
									, string menu_desc
									, int menu_priority
									, string menu_auth_type
									, string menu_type
									, string menu_name_image_path
									, string menu_name_image_path_u
									, string menu_prev_icon_path
									, DateTime menu_create_date
									, string show_left_menu )
        {
            int affectedRow = 0;

            affectedRow = _dac_menuinfo.Update( null
												, null
												, menu_ref_id
                                                , up_menu_id
												, menu_name
												, menu_dir
												, menu_page_name
												, menu_param
												, menu_full_path
												, menu_desc
												, menu_priority
												, menu_auth_type
												, menu_type
												, menu_name_image_path
												, menu_name_image_path_u
												, menu_prev_icon_path
												, menu_create_date
												, show_left_menu );

            return ( affectedRow > 0 ) ? true : false;
        }

		public bool AddMenuinfo( int menu_ref_id
								, int up_menu_id
								, string menu_name
								, string menu_dir
								, string menu_page_name
								, string menu_param
								, string menu_full_path
								, string menu_desc
								, int menu_priority
								, string menu_auth_type
								, string menu_type
								, string menu_name_image_path
								, string menu_name_image_path_u
								, string menu_prev_icon_path
								, DateTime menu_create_date
								, string show_left_menu )
		{
			int affectedRow = 0;
			affectedRow		= _dac_menuinfo.Insert( null
												, null
												, menu_ref_id
												, up_menu_id
												, menu_name
												, menu_dir
												, menu_page_name
												, menu_param
												, menu_full_path
												, menu_desc
												, menu_priority
												, menu_auth_type
												, menu_type
												, menu_name_image_path
												, menu_name_image_path_u
												, menu_prev_icon_path
												, menu_create_date
												, show_left_menu );

			return ( affectedRow > 0 ) ? true : false;
		}

		public bool RemoveMenuinfo( int menu_ref_id )
		{
			int affectedRow	= 0;
			affectedRow		= _dac_menuinfo.Delete( null
										, null
										, menu_ref_id );

			return ( affectedRow > 0 ) ? true : false;
		}

        public bool RemoveMenuinfo(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            Dac_RoleMenuRels _roleMenuRel = new Dac_RoleMenuRels();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _dac_menuinfo.Delete(conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRow["MENU_REF_ID"]));

                    affectedRow += _roleMenuRel.Delete(conn
                                                       , trx
                                                       , 0
                                                       ,DataTypeUtility.GetToInt32(dataRow["MENU_REF_ID"]));
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }

        public int GetMaxMenuRefID()
        {
            return _dac_menuinfo.GetMaxMenuRefID();
        }
       

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("MENU_REF_ID", typeof(int));
            dataTable.Columns.Add("UP_MENU_ID", typeof(int));
            dataTable.Columns.Add("MENU_NAME", typeof(string));
            dataTable.Columns.Add("MENU_DIR", typeof(string));
            dataTable.Columns.Add("MENU_PAGE_NAME", typeof(string));
            dataTable.Columns.Add("MENU_PARAM", typeof(string));
            dataTable.Columns.Add("MENU_FULL_PATH", typeof(string));
            dataTable.Columns.Add("MENU_DESC", typeof(string));
            dataTable.Columns.Add("MENU_PRIORITY", typeof(int));
            dataTable.Columns.Add("MENU_AUTH_TYPE", typeof(string));
            dataTable.Columns.Add("MENU_TYPE", typeof(string));
            dataTable.Columns.Add("MENU_NAME_IMAGE_PATH", typeof(string));
            dataTable.Columns.Add("MENU_NAME_IMAGE_PATH_U", typeof(string));
            dataTable.Columns.Add("MENU_PREV_ICON_PATH", typeof(string));
            dataTable.Columns.Add("MENU_CREATE_DATE", typeof(DateTime));
            dataTable.Columns.Add("SHOW_LEFT_MENU", typeof(string));

            return dataTable;
        }

	}
}