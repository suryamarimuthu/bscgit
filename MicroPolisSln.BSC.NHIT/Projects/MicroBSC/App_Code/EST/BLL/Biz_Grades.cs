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
	public class Biz_Grades
	{
		#region ============================== [Fields] ====================

        private int _comp_id;
		private string _grade_id   = "";
		private string _grade_name = "";
		private string _grade_desc;
        private int    _sort_order;
		private DateTime _create_date;
		private int _create_user;
		private DateTime _update_date;
		private int _update_user;

		private Dac_Grades _dac_grades = new Dac_Grades();
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

		public string Grade_ID
		{
			get
			{
				return _grade_id;
			}
			set
			{
				_grade_id = ( value == null ? "" : value );
			}
		}

		public string Grade_Name
		{
			get
			{
				return _grade_name;
			}
			set
			{
				_grade_name = ( value == null ? "" : value );
			}
		}

		public string Grade_Desc
		{
			get
			{
				return _grade_desc; 
			}
			set
			{
				_grade_desc = ( value == null ? "" : value );
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

        public Biz_Grades()
		{

		}

		public Biz_Grades(int comp_id, string grade_id)
		{
			DataSet ds = _dac_grades.Select(comp_id, grade_id);

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				DataRow dr;

				dr              = ds.Tables[0].Rows[0];
                _comp_id        = ( dr["COMP_ID"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
				_grade_id       = ( dr["GRADE_ID"]      == DBNull.Value ) ? "" : (string)dr["GRADE_ID"];
				_grade_name     = ( dr["GRADE_NAME"]    == DBNull.Value ) ? "" : (string)dr["GRADE_NAME"];
				_grade_desc     = ( dr["GRADE_DESC"]    == DBNull.Value ) ? "" : (string)dr["GRADE_DESC"];
                _sort_order     = ( dr["SORT_ORDER"]    == DBNull.Value ) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
				_create_date    = ( dr["CREATE_DATE"]   == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
				_create_user    = ( dr["CREATE_USER"]   == DBNull.Value ) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
				_update_date    = ( dr["UPDATE_DATE"]   == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
				_update_user    = ( dr["UPDATE_USER"]   == DBNull.Value ) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}

		public bool IsExist(int comp_id, string grade_id)
		{
			DataSet ds = _dac_grades.Select(comp_id, grade_id);

			return ( ds.Tables[0].Rows.Count == 1 ) ? true : false;
		}

		public bool ModifyEstGrade(   int comp_id
                                    , string grade_id
									, string grade_name
									, string grade_desc
									, DateTime update_date
									, int update_user)
		{
			int affectedRow = 0;

			affectedRow = _dac_grades.Update( null
                                            , null
                                            , comp_id
                                            , grade_id
											, grade_name
											, grade_desc
											, update_date
											, update_user);

			return ( affectedRow > 0 )? true:false;
		}

		public DataSet GetEstGrades(int comp_id)
		{
			DataSet ds = _dac_grades.Select(comp_id, "");
			return ds;
		}

		public bool AddEstGrade(  int comp_id
                                , string grade_id
								, string grade_name
								, string grade_desc
								, DateTime create_date
								, int create_user )
		{
			int affectedRow = 0;

			if (!IsExist(comp_id, grade_id))
			{

				affectedRow = _dac_grades.Insert( null
                                                , null
                                                , comp_id
                                                , grade_id
												, grade_name
												, grade_desc
												, create_date
												, create_user );
			}

			return ( affectedRow > 0 )? true:false;
        }

		public bool RemoveEstGrade(int comp_id, string grade_id)
		{
			int affectedRow = 0;

			affectedRow     = _dac_grades.Delete(null, null, comp_id, grade_id);

			return ( affectedRow > 0 )? true:false;
		}
	}
}