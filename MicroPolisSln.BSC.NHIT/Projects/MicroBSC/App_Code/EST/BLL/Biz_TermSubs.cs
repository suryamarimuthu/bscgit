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
	public class Biz_TermSubs
	{
		#region ============================== [Fields] ====================

        private int _comp_id;
		private int _estterm_sub_id;
		private string _estterm_sub_name;
        private double _weight;
        private string _year_yn;
        private int _sort_order;
        private int _start_month;
        private int _end_month;
        private string _use_yn;
		private DateTime _create_date;
		private int _create_user;
		private DateTime _update_date;
		private int _update_user;

		private Dac_TermSubs _dac_termSubs = new Dac_TermSubs();

		#endregion

		#region ============================== [Properties] =================

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

		public int EstTerm_Sub_ID
		{
			get
			{
				return _estterm_sub_id;
			}
			set
			{
				_estterm_sub_id = value;
			}
		}

		public string EstTerm_Sub_Name
		{
			get
			{
				return _estterm_sub_name;
			}
			set
			{
				_estterm_sub_name = ( value == null ? "" : value );
			}
		}
        
        public double Weight
		{
			get
			{
				return _weight;
			}
			set
			{
				_weight = value;
			}
		}

        public string Year_YN
		{
			get
			{
				return _year_yn;
			}
			set
			{
				_year_yn = value;
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

        public int Start_Month
		{
			get
			{
				return _start_month;
			}
			set
			{
				_start_month = value;
			}
		}

        public int End_Month
		{
			get
			{
				return _end_month;
			}
			set
			{
				_end_month = value;
			}
		}

        public string Use_YN
		{
			get
			{
				return _use_yn;
			}
			set
			{
				_use_yn = value;
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

        public Biz_TermSubs()
		{

		}

		public Biz_TermSubs(int comp_id, int estterm_sub_id )
		{
			DataSet ds = _dac_termSubs.Select(comp_id, estterm_sub_id, "", "");

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				DataRow dr;

				dr                  = ds.Tables[0].Rows[0];
                _comp_id            = (dr["COMP_ID"]           == DBNull.Value ) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
				_estterm_sub_id     = (dr["ESTTERM_SUB_ID"]    == DBNull.Value ) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
				_estterm_sub_name   = (dr["ESTTERM_SUB_NAME"]  == DBNull.Value ) ? "" : (string)dr["ESTTERM_SUB_NAME"];
                _weight             = (dr["WEIGHT"]            == DBNull.Value ) ? 0 : Convert.ToDouble(dr["WEIGHT"]);
                _year_yn            = (dr["YEAR_YN"]           == DBNull.Value ) ? "" : (string)dr["YEAR_YN"];
                _sort_order         = (dr["SORT_ORDER"]        == DBNull.Value ) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _start_month        = (dr["START_MONTH"]       == DBNull.Value ) ? 1 : Convert.ToInt32(dr["START_MONTH"]);
                _end_month          = (dr["END_MONTH"]         == DBNull.Value ) ? 1 : Convert.ToInt32(dr["END_MONTH"]);
                _use_yn             = (dr["USE_YN"]            == DBNull.Value ) ? "N" : dr["USE_YN"].ToString();
				_create_date        = (dr["CREATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
				_create_user        = (dr["CREATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
				_update_date        = (dr["UPDATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
				_update_user        = (dr["UPDATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}
		
		public bool ModifyTermSub(int comp_id
                                , int estterm_sub_id
								, string estterm_sub_name
                                , double weight
                                , string year_yn
                                , int sort_order
                                , int start_month
                                , int end_month
                                , string use_yn
								, DateTime update_date
								, int update_user)
		{
			int affectedRow = 0;

			affectedRow = _dac_termSubs.Update(   null
                                                , null
                                                , comp_id
                                                , estterm_sub_id
												, estterm_sub_name
                                                , weight
                                                , year_yn
                                                , sort_order
                                                , start_month
                                                , end_month
                                                , use_yn
												, update_date
												, update_user);

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public DataSet GetTermSubs(int comp_id, string use_yn)
		{
			DataSet ds = _dac_termSubs.Select(comp_id, 0, "", use_yn);
			return ds;
		}

        public DataSet GetTermSubByYearYN(int comp_id, string year_yn)
		{
			DataSet ds = _dac_termSubs.Select(comp_id, 0, year_yn, "Y");
			return ds;
		}

		public bool AddTermSub(   int comp_id
                                , int estterm_sub_id
								, string estterm_sub_name
                                , double weight
                                , string year_yn
                                , int sort_order
                                , int start_month
                                , int end_month
                                , string use_yn
								, DateTime create_date
								, int create_user )
		{
			int affectedRow = 0;

			if ( IsExist(comp_id, estterm_sub_id ) == false )
			{
				affectedRow = _dac_termSubs.Insert(   null
                                                    , null
                                                    , comp_id
                                                    , estterm_sub_id
												    , estterm_sub_name
                                                    , weight
                                                    , year_yn
                                                    , sort_order
                                                    , start_month
                                                    , end_month
                                                    , use_yn
												    , create_date
												    , create_user );
			}

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool RemoveTermSub(int comp_id, int estterm_sub_id )
		{
			int affectedRow = 0;

			affectedRow = _dac_termSubs.Delete(null, null, comp_id, estterm_sub_id );

			if ( affectedRow > 0 )
				return true;

			return false;
		}

        public bool IsExist(int comp_id, int estterm_sub_id)
        {
            int affectedRow = 0;

            affectedRow = _dac_termSubs.Count(comp_id, estterm_sub_id);

            if (affectedRow > 0)
                return true;

            return false;
        }
	}
}