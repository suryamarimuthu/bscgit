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
    public class Biz_TermInfos
    {
       #region ============================== [Fields] ==============================

		private int 	    _estterm_ref_id;
		private string 	    _estterm_name;
		private DateTime 	_est_startdate;
		private DateTime 	_est_compdate;
		private int 	    _monthly_close_day;
		private int      	_pre_close_day;
        private int         _yearly_close_yn;
        private string      _score_valuation_type;
        private string      _est_desc;
        private int         _est_status;
        private int         _close_rate_complete_yn;
		private DateTime 	_create_date;
		private int 	    _create_user;
		private DateTime 	_update_date;
		private int 	    _update_user;

        private Dac_TermInfos _dac_termInfos = new Dac_TermInfos();
		#endregion
 
		#region ============================== [Properties] ==============================
		 
		public int EstTerm_Ref_ID
		{
			get 
			{
				return _estterm_ref_id;
			}
			set
			{
                _estterm_ref_id = (value == null ? 0 : value); 
			}
		}
		 
		public string EstTerm_Name
		{
			get 
			{
                return _estterm_name;
			}
			set
			{
                _estterm_name = (value == null ? "" : value); 
			}
		}

        public DateTime Est_StartDate
		{
			get 
			{
                return _est_startdate;
			}
			set
			{
                _est_startdate = value;
			}
		}

        public DateTime Est_CompDate
        {
            get
            {
                return _est_compdate;
            }
            set
            {
                _est_compdate = value;
            }
        }

        public int Monthly_Close_Day
		{
			get 
			{
                return _monthly_close_day;
			}
			set
			{
                _monthly_close_day = (value == null ? 0 : value); 
			}
		}

        public int Pre_Close_Day
		{
			get 
			{
                return _pre_close_day;
			}
			set
			{
                _pre_close_day = (value == null ? 0 : value);
			}
		}

        public int Yearly_Close_YN
		{
			get 
			{
                return _yearly_close_yn;
			}
			set
			{
                _yearly_close_yn = value;
			}
		}

        public string Score_Valuation_Type
		{
			get 
			{
                return _score_valuation_type;
			}
			set
			{
                _score_valuation_type = value;
			}
		}

        public string Est_Desc
		{
			get 
			{
                return _est_desc;
			}
			set
			{
                _est_desc = (value == null ? "" : value);
			}
		}

        public int Est_Status
		{
			get 
			{
                return _est_status;
			}
			set
			{
                _est_status = (value == null ? 0 : value);
			}
		}

        public int Close_Rate_Complete_YN
        {
            get
            {
                return _close_rate_complete_yn;
            }
            set
            {
                _close_rate_complete_yn = (value == null ? 0 : value);
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
		 
		public int Create_User
		{
			get 
			{
				return _create_user;
			}
			set
			{
				_create_user = ( value==null ? 0 : value );
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
		 
		public int Update_User
		{
			get 
			{
				return _update_user;
			}
			set
			{
				_update_user = ( value==null ? 0 : value );
			}
		}

		#endregion
 
		public Biz_TermInfos()
		{
		}

        public Biz_TermInfos(int estterm_ref_id)
		{
            DataSet ds = _dac_termInfos.Select(estterm_ref_id);
			DataRow dr;

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				dr = ds.Tables[0].Rows[0];
                _estterm_ref_id         = Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_name           = (string)dr["ESTTERM_NAME"];
                _est_compdate           = (dr["EST_COMPDATE"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["EST_COMPDATE"];
                _est_startdate          = (dr["EST_STARTDATE"] == DBNull.Value) ? Convert.ToDateTime("2001-01-01") : (DateTime)dr["EST_STARTDATE"];
                _monthly_close_day      = (dr["MONTHLY_CLOSE_DAY"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["MONTHLY_CLOSE_DAY"]);
                _pre_close_day          = (dr["PRE_CLOSE_DAY"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PRE_CLOSE_DAY"]);
                _yearly_close_yn        = (dr["YEARLY_CLOSE_YN"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["YEARLY_CLOSE_YN"]);
                _score_valuation_type   = (dr["SCORE_VALUATION_TYPE"] == DBNull.Value) ? "" : (string)dr["SCORE_VALUATION_TYPE"];
                _est_desc               = (dr["EST_DESC"] == DBNull.Value) ? "" : (string)dr["EST_DESC"];
                _est_status             = (dr["EST_STATUS"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_STATUS"]);
                _close_rate_complete_yn = (dr["CLOSE_RATE_COMPLETE_YN"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CLOSE_RATE_COMPLETE_YN"]);
                _create_date            = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
                _create_user            = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _update_date            = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user            = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}

        /*
		public bool IsExist( int estterm_ref_id)
		{
            int affectedRow = _dac_termInfos.Count(estterm_ref_id);

            return affectedRow > 0 ? true : false;
		}

      


        public bool ModifyTermInfo(int estterm_ref_id
                                    , string estterm_name
                                    , DateTime est_startdate
                                    , DateTime est_compdate
                                    , int monthly_close_day
                                    , int pre_close_day
                                    , int yearly_close_yn
                                    , string score_valuation_type
                                    , string est_desc
                                    , int est_status
                                    , int close_rate_complete_yn
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;
            affectedRow = _dac_termInfos.Update( estterm_ref_id
                                    , estterm_name
                                    , est_startdate
                                    , est_compdate
                                    , monthly_close_day
                                    , pre_close_day
                                    , yearly_close_yn
                                    , score_valuation_type
                                    , est_desc
                                    , est_status
                                    , close_rate_complete_yn
                                    , update_date
                                    , update_user);

            if ( affectedRow > 0 )
                return true;

            return false;
        }


        public bool AddTermInfo(int estterm_ref_id
                                    , string estterm_name
                                    , DateTime est_startdate
                                    , DateTime est_compdate
                                    , int monthly_close_day
                                    , int pre_close_day
                                    , int yearly_close_yn
                                    , string score_valuation_type
                                    , string est_desc
                                    , int est_status
                                    , int close_rate_complete_yn
                                    , DateTime create_date
									, string create_user )
        {
	        int affectedRow = 0;

			if ( IsExist( estterm_ref_id) == false )
			{
                affectedRow = _dac_termInfos.Insert(estterm_ref_id
                                                    , estterm_name
                                                    , est_startdate
                                                    , est_compdate
                                                    , monthly_close_day
                                                    , pre_close_day
                                                    , yearly_close_yn
                                                    , score_valuation_type
                                                    , est_desc
                                                    , est_status
                                                    , close_rate_complete_yn
                                                    , create_date
									                , create_user);
			}

            if ( affectedRow > 0 )
                return true;

            return false;
        }

        public bool RemoveTermInfo( int estterm_ref_id)
        {
	        int affectedRow = 0;
            affectedRow = _dac_termInfos.Delete(estterm_ref_id);

            if ( affectedRow > 0 )
                return true;

            return false;
        }
         */
    }
}
