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
	public class Biz_TermSteps
	{
		#region ============================== [Fields] ====================

        private int _comp_id;
		private int _estterm_step_id;
		private string _estterm_step_name;
        private double _weight;
        private string _merge_yn;
        private int _sort_order;
        private string _use_yn;
		private DateTime _create_date;
		private int _create_user;
		private DateTime _update_date;
		private int _update_user;

		private Dac_TermSteps _dac_termSteps = new Dac_TermSteps();

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

		public int EstTerm_Step_ID
		{
			get
			{
				return _estterm_step_id;
			}
			set
			{
				_estterm_step_id = value;
			}
		}

		public string EstTerm_Step_Name
		{
			get
			{
				return _estterm_step_name;
			}
			set
			{
				_estterm_step_name = ( value == null ? "" : value );
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

        public string Merge_YN
		{
			get
			{
				return _merge_yn;
			}
			set
			{
				_merge_yn = value;
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

        public Biz_TermSteps()
		{

		}

		public Biz_TermSteps(int comp_id, int estterm_step_id)
		{
			DataSet ds = _dac_termSteps.Select(comp_id, estterm_step_id, "", "");

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				DataRow dr;

				dr                  = ds.Tables[0].Rows[0];
                _comp_id            = (dr["COMP_ID"]           == DBNull.Value ) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
				_estterm_step_id    = (dr["ESTTERM_STEP_ID"]   == DBNull.Value ) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
				_estterm_step_name  = (dr["ESTTERM_STEP_NAME"] == DBNull.Value ) ? "" : (string)dr["ESTTERM_STEP_NAME"];
                _weight             = (dr["WEIGHT"]            == DBNull.Value ) ? 0 : Convert.ToDouble(dr["WEIGHT"]);
                _merge_yn           = (dr["MERGE_YN"]          == DBNull.Value ) ? "N" : dr["MERGE_YN"].ToString();
                _sort_order         = (dr["SORT_ORDER"]        == DBNull.Value ) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _use_yn             = (dr["USE_YN"]            == DBNull.Value ) ? "N" : dr["USE_YN"].ToString();
				_create_date        = (dr["CREATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
				_create_user        = (dr["CREATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
				_update_date        = (dr["UPDATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
				_update_user        = (dr["UPDATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}

		public bool IsExist(int comp_id, int estterm_step_id )
		{
			DataSet ds = _dac_termSteps.Select(comp_id, estterm_step_id, "", "");

			return ( ds.Tables[0].Rows.Count == 1 ) ? true : false;
		}

        public bool ModifyTermStep(   int comp_id
                                    , int estterm_step_id
									, string estterm_step_name
                                    , double weight
                                    , string merge_yn
                                    , int sort_order
                                    , string use_yn
									, DateTime update_date
									, int update_user)
		{
			int affectedRow = 0;

			affectedRow = _dac_termSteps.Update(  null
                                                , null
                                                , comp_id
                                                , estterm_step_id
												, estterm_step_name
                                                , weight
                                                , merge_yn
                                                , sort_order
                                                , use_yn
												, update_date
												, update_user);

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public DataSet GetTermSteps(int comp_id, string use_yn)
		{
			DataSet ds = _dac_termSteps.Select(comp_id, 0, "", use_yn);
			return ds;
		}

        public DataSet GetTermStepByMergeYN(int comp_id, string merge_yn)
		{
			DataSet ds = _dac_termSteps.Select(comp_id, 0, merge_yn, "Y");
			return ds;
		}

		public bool AddTermStep(  int comp_id
                                , int estterm_step_id
                                , string estterm_step_name
                                , double weight
                                , string merge_yn
                                , int sort_order
                                , string use_yn
								, DateTime create_date
								, int create_user )
		{
			int affectedRow = 0;

			if ( IsExist(comp_id, estterm_step_id ) == false )
			{

				affectedRow = _dac_termSteps.Insert(  null
                                                    , null
                                                    , comp_id
                                                    , estterm_step_id
													, estterm_step_name
                                                    , weight
                                                    , merge_yn
                                                    , sort_order
                                                    , use_yn
													, create_date
													, create_user );
			}

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool RemoveTermStep(int comp_id, int estterm_step_id )
		{
			int affectedRow = 0;

			affectedRow = _dac_termSteps.Delete( null, null, comp_id, estterm_step_id );

			if ( affectedRow > 0 )
				return true;

			return false;
		}
	}
}