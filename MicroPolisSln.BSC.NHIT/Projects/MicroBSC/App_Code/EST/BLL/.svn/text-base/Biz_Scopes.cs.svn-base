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
    public class Biz_Scopes
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private string _est_id;
        private string _grade_id;
        private string _scale_id;
        private float _start_scope;
        private float _end_scope;
        private string _scope_unit_id;
        private float _grade_to_point;
        private DateTime _update_date;
        private int _update_user;

        private Dac_Scopes _scope = new Dac_Scopes();

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

        public string Est_ID
        {
            get
            {
                return _est_id;
            }
            set
            {
                _est_id = (value == null ? "" : value);
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
                _grade_id = (value == null ? "" : value);
            }
        }

        public string Scale_ID
        {
            get
            {
                return _scale_id;
            }
            set
            {
                _scale_id = (value == null ? "" : value);
            }
        }

        public float Start_Scope
        {
            get
            {
                return _start_scope;
            }
            set
            {
                _start_scope = value;
            }
        }

        public float End_Scope
        {
            get
            {
                return _end_scope;
            }
            set
            {
                _end_scope = value;
            }
        }

        public string Scope_Unit_ID
        {
            get
            {
                return _scope_unit_id;
            }
            set
            {
                _scope_unit_id = (value == null ? "" : value);
            }
        }

        public float Grade_TO_Point
        {
            get
            {
                return _grade_to_point;
            }
            set
            {
                _grade_to_point = value;
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

        public Biz_Scopes()
        {

        }

        public Biz_Scopes(int comp_id
                        , string est_id
                        , string grade_id
                        , string scale_id)
        {
            DataSet ds = _scope.Select(comp_id
                                    , est_id
                                    , grade_id
                                    , scale_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];

                _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _grade_id       = (dr["GRADE_ID"]       == DBNull.Value) ? "" : (string)dr["GRADE_ID"];
                _scale_id       = (dr["SCALE_ID"]       == DBNull.Value) ? "" : (string)dr["SCALE_ID"];
                _start_scope    = (dr["START_SCOPE"]    == DBNull.Value) ? 0 : (float)dr["START_SCOPE"];
                _end_scope      = (dr["END_SCOPE"]      == DBNull.Value) ? 0 : (float)dr["END_SCOPE"];
                _scope_unit_id  = (dr["SCOPE_UNIT_ID"]  == DBNull.Value) ? "" : (string)dr["SCOPE_UNIT_ID"];
                _grade_to_point = (dr["GRADE_TO_POINT"] == DBNull.Value) ? 0 : (float)dr["GRADE_TO_POINT"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyScope(  int comp_id
                                , string est_id
                                , string grade_id
                                , string scale_id
                                , float start_scope
                                , float end_scope
                                , string scope_unit_id
                                , float grade_to_point
                                , DateTime update_date
                                , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _scope.Update(  null
										, null
                                        , comp_id
										, est_id
										, grade_id
										, scale_id
										, start_scope
										, end_scope
										, scope_unit_id
										, grade_to_point
										, update_date
										, update_user );

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetScopeEstID(int comp_id, string est_id)
        {
            return _scope.Select(comp_id, est_id, string.Empty, string.Empty);
        }

        public DataSet GetScope(int comp_id, string est_id)
        {
            return _scope.Select( comp_id
                                , est_id
                                , ""
                                , "");
        }

        public DataSet GetScope(  int comp_id
                                , string est_id
                                , string grade_id
                                , string scale_id)
        {
            return _scope.Select( comp_id
                                , est_id
                                , grade_id
                                , scale_id);
        }

		public DataSet GetScopeGradeEstID(int comp_id, string est_id)
		{
            return _scope.SelectJoinGrade(comp_id
                                        , est_id
										, string.Empty
										, string.Empty );
		}

        public DataSet GetScopeGradeEstID(int comp_id, string est_id, string scale_id)
		{
            return _scope.SelectJoinGrade(comp_id
                                        , est_id
										, string.Empty
										, scale_id );
		}

		public DataSet GetScopeGrade( int comp_id
                                    , string est_id
									, string grade_id
									, string scale_id )
		{
            return _scope.SelectJoinGrade(comp_id
                                        , est_id
										, grade_id
										, scale_id );
		}

        public bool AddScope( int comp_id
                            , string est_id
                            , string grade_id
                            , string scale_id
                            , float start_scope
                            , float end_scope
                            , string scope_unit_id
                            , float grade_to_point
                            , DateTime create_date
                            , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _scope.Insert(  null
										, null
                                        , comp_id
										, est_id
										, grade_id
										, scale_id
										, start_scope
										, end_scope
										, scope_unit_id
										, grade_to_point
										, create_date
										, create_user );

            return ( affectedRow > 0 ) ? true : false;
        }

		public bool AddScope( DataTable dtInsert
							, DateTime create_date
							, int create_user )
		{
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow	= 0;
			try
			{
				for ( int i = 0; i < dtInsert.Rows.Count; i++ )
				{
					// 최초 한번만 삭제
					if ( i == 0 )
					{
						affectedRow = _scope.Delete(  conn
												    , trx
                                                    , DataTypeUtility.GetToInt32(dtInsert.Rows[i]["COMP_ID"])
												    , dtInsert.Rows[i]["EST_ID"].ToString()
												    , string.Empty
												    , dtInsert.Rows[i]["SCALE_ID"].ToString() );
					}

					affectedRow = _scope.Insert(  conn
												, trx
                                                , DataTypeUtility.GetToInt32( dtInsert.Rows[i]["COMP_ID"] )
												, dtInsert.Rows[i]["EST_ID"].ToString()
												, dtInsert.Rows[i]["GRADE_ID"].ToString()
												, dtInsert.Rows[i]["SCALE_ID"].ToString()
												, DataTypeUtility.GetToFloat( dtInsert.Rows[i]["START_SCOPE"] )
												, DataTypeUtility.GetToFloat( dtInsert.Rows[i]["END_SCOPE"] )
												, dtInsert.Rows[i]["SCOPE_UNIT_ID"].ToString()
												, DataTypeUtility.GetToFloat( dtInsert.Rows[i]["GRADE_TO_POINT"] )
												, create_date
												, create_user );
				}

				trx.Commit();
			}
			catch ( Exception ex )
			{
				trx.Rollback();
				return false;
			}
			finally
			{
				conn.Close();
			}

			if ( affectedRow > 0 )
			{
				return true;
			}

            return false;
		}

        public bool RemoveScope(  int comp_id
                                , string est_id
                                , string grade_id
                                , string scale_id)
        {
            int affectedRow = 0;

            affectedRow = _scope.Delete(  null
									    , null
                                        , comp_id
									    , est_id
                                        , grade_id
                                        , scale_id);

            return (affectedRow > 0) ? true : false;
        }

		public DataTable GetSchema()
		{
			DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID",		typeof(int));
			dataTable.Columns.Add("EST_ID",		    typeof(string));
			dataTable.Columns.Add("GRADE_ID",		typeof(string));
			dataTable.Columns.Add("SCALE_ID",		typeof(string));
			dataTable.Columns.Add("START_SCOPE",	typeof(float));
			dataTable.Columns.Add("END_SCOPE",		typeof(float));
			dataTable.Columns.Add("SCOPE_UNIT_ID",	typeof(string));
			dataTable.Columns.Add("GRADE_TO_POINT", typeof(float));

			return dataTable;
		}
    }
}
