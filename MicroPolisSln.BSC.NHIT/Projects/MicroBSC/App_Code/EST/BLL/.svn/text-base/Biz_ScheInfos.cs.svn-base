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
	public class Biz_ScheInfos
	{
		#region ============================== [Fields] ==============================

        private int _comp_id;
		private string _est_sche_id;
		private string _up_est_sche_id;
		private string _est_sche_name;
		private string _est_sche_desc;
		private int _sort_order;
		private string _est_id;
		private DateTime _create_date;
		private int _create_user;
		private DateTime _update_date;
		private int _update_user;

		private string _up_est_sche_name;

		private Dac_ScheInfos _dac_scheInfos = new Dac_ScheInfos();
		#endregion

		#region ============================== [Properties] ==============================

        public int Comp_ID
		{
			get
			{
				return _comp_id;
			}
			set
			{
				_comp_id = value;
			}
		}

		public string Est_Sche_ID
		{
			get
			{
				return _est_sche_id;
			}
			set
			{
				_est_sche_id = ( value == null ? "" : value );
			}
		}

		public string Up_Est_Sche_ID
		{
			get
			{
				return _up_est_sche_id;
			}
			set
			{
				_up_est_sche_id = ( value == null ? "" : value );
			}
		}

		public string Est_Sche_Name
		{
			get
			{
				return _est_sche_name;
			}
			set
			{
				_est_sche_name = ( value == null ? "" : value );
			}
		}

		public string Est_Sche_Desc
		{
			get
			{
				return _est_sche_desc;
			}
			set
			{
				_est_sche_desc = ( value == null ? "" : value );
			}
		}

		public int Sort_Order
		{
			get
			{
				return _sort_order;
			}
			set
			{
				_sort_order = value;
			}
		}

		public string Est_ID
		{
			get
			{
				return _est_id;
			}
			set
			{
				_est_id = ( value == null ? "" : value );
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

		public string Up_Est_Sche_Name
		{
			get
			{
				return _up_est_sche_name;
			}
			set
			{
				_up_est_sche_name = ( value == null ? "" : value );
			}
		}
		#endregion

		public Biz_ScheInfos()
		{

		}

		public Biz_ScheInfos(int comp_id, string est_sche_id )
		{
			DataSet ds = _dac_scheInfos.Select(comp_id, est_sche_id );
			DataRow dr;

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]            == DBNull.Value ) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
				_est_sche_id        = (dr["EST_SCHE_ID"]        == DBNull.Value ) ? "" : (string)dr["EST_SCHE_ID"];
				_up_est_sche_id     = (dr["UP_EST_SCHE_ID"]     == DBNull.Value ) ? "" : (string)dr["UP_EST_SCHE_ID"];
                _up_est_sche_name   = (dr["UP_EST_SCHE_NAME"]   == DBNull.Value ) ? "" : (string)dr["UP_EST_SCHE_NAME"];
				_est_sche_name      = (dr["EST_SCHE_NAME"]      == DBNull.Value ) ? "" : (string)dr["EST_SCHE_NAME"];
				_est_sche_desc      = (dr["EST_SCHE_DESC"]      == DBNull.Value ) ? "" : (string)dr["EST_SCHE_DESC"];
				_sort_order         = (dr["SORT_ORDER"]         == DBNull.Value ) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
				_est_id             = (dr["EST_ID"]             == DBNull.Value ) ? "" : (string)dr["EST_ID"];
				_create_date        = (dr["CREATE_DATE"]        == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
				_create_user        = (dr["CREATE_USER"]        == DBNull.Value ) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
				_update_date        = (dr["UPDATE_DATE"]        == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
				_update_user        = (dr["UPDATE_USER"]        == DBNull.Value ) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}

		public DataSet GetScheInfo(int comp_id)
		{
			DataSet ds	= _dac_scheInfos.Select(comp_id, "");
			return ds;
		}

		public DataSet GetScheInfo(int comp_id, string est_sche_id)
		{
			DataSet ds	= _dac_scheInfos.Select(comp_id, est_sche_id);
			return ds;
		}

		public bool IsExist(int comp_id, string est_sche_id)
		{
			int intCount	= _dac_scheInfos.Count(comp_id, est_sche_id);
			return ( intCount == 1 ) ? true : false;
		}

		public bool ModifyScheInfo(   int comp_id
                                    , string est_sche_id
									, string up_est_sche_id
									, string est_sche_name
									, string est_sche_desc
									, int sort_order
									, string est_id
									, DateTime update_date
									, int update_user )
		{
			int affectedRow = 0;

			affectedRow = _dac_scheInfos.Update(  null
											    , null
                                                , comp_id
											    , est_sche_id
											    , up_est_sche_id
											    , est_sche_name
											    , est_sche_desc
											    , sort_order
											    , est_id
											    , update_date
											    , update_user );

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool AddScheInfo(  int comp_id
                                , string est_sche_id
								, string up_est_sche_id
								, string est_sche_name
								, string est_sche_desc
								, int sort_order
								, string est_id
								, DateTime create_date
								, int cerate_user )
		{
			int affectedRow = 0;

			affectedRow = _dac_scheInfos.Insert(  null
											    , null
                                                , comp_id
											    , est_sche_id
											    , up_est_sche_id
											    , est_sche_name
											    , est_sche_desc
											    , sort_order
											    , est_id
											    , create_date
											    , cerate_user );

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool RemoveScheInfo(int comp_id, string est_sche_id)
		{
			int affectedRow = 0;

			affectedRow		= _dac_scheInfos.Delete(  null
													, null
                                                    , comp_id
													, est_sche_id );

			if ( affectedRow > 0 )
				return true;

			return false;
		}
	}
}