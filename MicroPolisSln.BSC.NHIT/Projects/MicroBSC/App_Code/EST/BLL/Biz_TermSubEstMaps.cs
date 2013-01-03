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
    public class Biz_TermSubEstMaps
    {
        #region ============================== [Fields] ==============================
 
        private int     _comp_id;
        private string 	_est_id;
        private int 	_estterm_sub_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_TermSubEstMaps _dac_termSubEstMaps = new Dac_TermSubEstMaps();

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
		        _est_id = ( value==null ? "" : value );
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

        public Biz_TermSubEstMaps()
        {
            
        }

        public Biz_TermSubEstMaps(int comp_id, string est_id, int estterm_sub_id)
        {
            DataSet ds = GetTermSubEstMap(comp_id, est_id, estterm_sub_id);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
                _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyTermSubEstMap(  int comp_id
                                        , string est_id
                                        , int estterm_sub_id
                                        , double weight
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _dac_termSubEstMaps.Update( null
                                                    , null
                                                    , comp_id
                                                    , est_id
												    , estterm_sub_id
                                                    , weight
												    , update_date
												    , update_user);

			return ( affectedRow > 0 ) ? true : false;
        }

		public DataSet GetTermSubEstMap(int comp_id, string est_id, string year_yn)
		{
			return _dac_termSubEstMaps.Select(comp_id, est_id, 0, year_yn);
		}
 
        public DataSet GetTermSubEstMap(int comp_id, string est_id, int estterm_sub_id)
        {
			return _dac_termSubEstMaps.Select(comp_id, est_id, estterm_sub_id, "");
        }
        
        public bool AddTermSubEstMap( int comp_id
                                    , string est_id
                                    , int estterm_sub_id
                                    , double weight
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

			affectedRow = _dac_termSubEstMaps.Insert( null
                                                    , null
                                                    , comp_id
                                                    , est_id
												    , estterm_sub_id
                                                    , weight
												    , create_date
												    , create_user);

			return ( affectedRow > 0 ) ? true : false;
        }

        public bool SaveTermSubEstMap(DataTable dataTable
                                    , int comp_id
                                    , string est_id)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 0;

			try
			{
				affectedRow += _dac_termSubEstMaps.Delete(conn
                                                        , trx
                                                        , comp_id
                                                        , est_id
                                                        , 0);

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _dac_termSubEstMaps.Insert(conn
                                                            , trx
                                                            , dataRow["COMP_ID"]
                                                            , dataRow["EST_ID"]
												            , dataRow["ESTTERM_SUB_ID"]
                                                            , dataRow["WEIGHT"]
												            , dataRow["DATE"]
												            , dataRow["USER"]);
                }

                trx.Commit();
            }
            catch ( Exception e )
            {
                trx.Rollback();
                return false;
            }
            finally 
            {
                conn.Close();
            }

            return ( affectedRow > 0 ) ? true : false;
        }

		public bool RemoveTermSubEstMap(int comp_id, string est_id )
		{
			return RemoveTermSubEstMap(comp_id, est_id, 0 );
		}

        public bool RemoveTermSubEstMap(  int comp_id
                                        , string est_id
                                        , int estterm_sub_id)
        {
	        int affectedRow = 0;

			affectedRow = _dac_termSubEstMaps.Delete( null
                                                    , null
                                                    , comp_id
                                                    , est_id
												    , estterm_sub_id);

			return ( affectedRow > 0 ) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_SUB_ID", typeof(int));
            dataTable.Columns.Add("WEIGHT", typeof(double));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
