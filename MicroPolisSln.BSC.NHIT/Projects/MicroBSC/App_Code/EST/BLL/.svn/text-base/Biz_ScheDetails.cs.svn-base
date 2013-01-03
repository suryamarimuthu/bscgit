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
	public class Biz_ScheDetails 
	{
		#region ============================== [Fields] =========================

        private int _comp_id;
		private int _estterm_ref_id;
		private int _estterm_sub_id;
		private string _est_sche_id;
		private DateTime _start_date;
		private DateTime _end_date;
		private string _status_id;
		private DateTime _create_date;
		private int _create_user;
		private DateTime _update_date;
		private int _update_user;

		private Dac_ScheDetails _dac_scheDetails = new Dac_ScheDetails();

		#endregion

		#region ============================== [Properties] =====================

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

		public int Estterm_Ref_ID
		{
			get
			{
				return _estterm_ref_id;
			}
			set
			{
				_estterm_ref_id = value;
			}
		}

		public int Estterm_Sub_ID
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

		public DateTime Start_Date
		{
			get
			{
				return _start_date;
			}
			set
			{
				_start_date = value;
			}
		}

		public DateTime End_Date
		{
			get
			{
				return _end_date;
			}
			set
			{
				_end_date = value;
			}
		}

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

		public Biz_ScheDetails()
		{

		}

		public Biz_ScheDetails(   int comp_id
                                , int estterm_ref_id
								, int estterm_sub_id
								, string est_sche_id )
		{
			DataSet ds = _dac_scheDetails.Select( comp_id
                                                , estterm_ref_id
												, estterm_sub_id
												, est_sche_id );

			DataRow dr;

			if ( ds.Tables[0].Rows.Count == 1 )
			{
				dr              = ds.Tables[0].Rows[0];

                _comp_id        = (dr["COMP_ID"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
				_estterm_ref_id = (dr["ESTTERM_REF_ID"]    == DBNull.Value ) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
				_estterm_sub_id = (dr["ESTTERM_SUB_ID"]    == DBNull.Value ) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
				_est_sche_id    = (dr["EST_SCHE_ID"]       == DBNull.Value ) ? "" : (string)dr["EST_SCHE_ID"];
				_start_date     = (dr["START_DATE"]        == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["START_DATE"];
				_end_date       = (dr["END_DATE"]          == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["END_DATE"];
				_status_id      = (dr["STATUS_ID"]         == DBNull.Value ) ? "" : (string)dr["STATUS_ID"];
				_create_date    = (dr["CREATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
				_create_user    = (dr["CREATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
				_update_date    = (dr["UPDATE_DATE"]       == DBNull.Value ) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
				_update_user    = (dr["UPDATE_USER"]       == DBNull.Value ) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
			}
		}

		public bool IsExist(  int comp_id
                            , int estterm_ref_id
						    , int estterm_sub_id
						    , string est_sche_id )
		{
			DataSet ds = _dac_scheDetails.Select( comp_id
                                                , estterm_ref_id
												, estterm_sub_id
												, est_sche_id );

			return ( ds.Tables[0].Rows.Count == 1 ) ? true : false;
		}

		public bool ModifyScheDetail( int comp_id
                                    , int estterm_ref_id
									, int estterm_sub_id
									, string est_sche_id
									, DateTime start_date
									, DateTime end_date
									, string status_id
									, DateTime update_date
									, int update_user )
		{
			int affectedRow = 0;

			affectedRow = _dac_scheDetails.Update(null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
												, estterm_sub_id
												, est_sche_id
												, start_date
												, end_date
												, status_id
												, update_date
												, update_user );

			if ( affectedRow > 0 )
				return true;

			return false;
		}

		public bool AddScheDetail(int comp_id
                                , int estterm_ref_id
								, int estterm_sub_id
								, string est_sche_id
								, DateTime start_date
								, DateTime end_date
								, string status_id
								, DateTime create_date
								, int create_user )
		{
			int affectedRow = 0;

			if ( IsExist(comp_id, estterm_ref_id, estterm_sub_id, est_sche_id ) == false )
			{

				affectedRow = _dac_scheDetails.Insert(null
                                                    , null
                                                    , comp_id
                                                    , estterm_ref_id
													, estterm_sub_id
													, est_sche_id
													, start_date
													, end_date
													, status_id
													, create_date
													, create_user );
			}

			if ( affectedRow > 0 )
				return true;

			return false;
		}

        public DataTable GetScheData( int comp_id
                                    , int intEstTermRefID
                                    , int intEstTermSub )
        {
            DataTable dtTemp    = null;
            string id_column    = "EST_SCHE_ID";
            string up_id_column = "UP_EST_SCHE_ID";
            string level_column = "LEVEL";
            DataSet ds          = _dac_scheDetails.SelectINFO(comp_id
                                                            , intEstTermRefID
                                                            , intEstTermSub );

            ds.Tables[0].Columns.Add( level_column, typeof(string) );

            dtTemp = ds.Tables[0].Clone();

            ds.Relations.Add( "Relation", ds.Tables[0].Columns[id_column], ds.Tables[0].Columns[up_id_column], false );

            foreach ( DataRow dbRow in ds.Tables[0].Rows )
            {
                if ( dbRow[up_id_column].ToString().Length == 0 || dbRow[up_id_column] == DBNull.Value )
                {
                    int level           = 0;
                    dbRow[level_column] = level;
                    dtTemp.ImportRow( dbRow );
                    
                    PopulateDataRow( dtTemp, dbRow, id_column, up_id_column, level_column, level + 1 );
                }
            }

            return dtTemp;
        }

        private void PopulateDataRow( DataTable dtData
                                    , DataRow dbRow
                                    , string id_column
                                    , string up_id_column
                                    , string level_column
                                    , int level )
        {
            foreach ( DataRow childRow in dbRow.GetChildRows("Relation") )
            {
                childRow[level_column] = level;
                dtData.ImportRow(childRow);
                PopulateDataRow(dtData, childRow, id_column, up_id_column, level_column, level + 1);
            }
        }

		public bool NewAddScheDetail( int comp_id
                                    , int estterm_ref_id
								    , int estterm_sub_id
                                    , DateTime start_date
                                    , DateTime end_date
								    , DateTime create_date
								    , int create_user )
		{
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			int affectedRow = 0;

			try
			{
				affectedRow = _dac_scheDetails.Delete(conn
													, trx
                                                    , comp_id
													, estterm_ref_id
													, estterm_sub_id
													, string.Empty );

				affectedRow += _dac_scheDetails.InsertSelect( conn
														    , trx
                                                            , comp_id
														    , estterm_ref_id
														    , estterm_sub_id
                                                            , start_date
                                                            , end_date
														    , create_date
														    , create_user );
                trx.Commit();
            }
            catch( Exception e )
            {
                trx.Rollback();
                return false;
            }
            finally 
            {
                conn.Close();
            }

			if ( affectedRow > 0 )
				return true;

			return false;
		}		


		public bool RemoveScheDetail( int comp_id
                                    , int estterm_ref_id
									, int estterm_sub_id
									, string est_sche_id )
		{
			int affectedRow = 0;

			affectedRow = _dac_scheDetails.Delete(null
                                                , null
                                                , comp_id
                                                , estterm_ref_id
												, estterm_sub_id
												, est_sche_id );

			if ( affectedRow > 0 )
				return true;

			return false;
		}
	}
}