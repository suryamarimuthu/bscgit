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
    public class Biz_TermStepEstMaps
    {
        #region ============================== [Fields] ==============================
 
        private int _comp_id;
        private string 	_est_id;
        private int 	_estterm_step_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_TermStepEstMaps _dac_termStepEstMaps = new Dac_TermStepEstMaps();

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

        public Biz_TermStepEstMaps()
        {
            
        }

        public Biz_TermStepEstMaps(int comp_id, string est_id, int estterm_step_id)
        {
            DataSet ds = _dac_termStepEstMaps.Select(comp_id, est_id, estterm_step_id, "");
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_step_id    = (dr["ESTTERM_STEP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyTermStepEstMap( int comp_id
                                        , string est_id
                                        , int estterm_step_id
                                        , DateTime update_date
                                        , double weight
                                        , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _dac_termStepEstMaps.Update(null
                                                    , null
                                                    , comp_id
                                                    , est_id
												    , estterm_step_id
                                                    , weight
												    , update_date
												    , update_user);

			return ( affectedRow > 0 ) ? true : false;
        }
         
        public DataSet GetTermStepEstMap( int comp_id
                                        , string est_id
                                        , int estterm_step_id
                                        , string fixed_weight_yn)
        {
			return _dac_termStepEstMaps.Select(comp_id, est_id, estterm_step_id, fixed_weight_yn);
        }

        public DataSet GetTermStepEstMap( int comp_id
                                        , string est_id
                                        , int estterm_step_id)
        {
			return _dac_termStepEstMaps.Select(comp_id, est_id, estterm_step_id, "");
        }

        public DataSet GetTermStepEstMap( int comp_id
                                        , string est_id
                                        , string fixed_weight_yn)
        {
			return _dac_termStepEstMaps.Select(comp_id, est_id, 0, fixed_weight_yn);
        }

        public DataSet GetTermStepEstMap( int comp_id
                                        , string est_id)
        {
			return _dac_termStepEstMaps.Select(comp_id, est_id, 0, "");
        }
         
        public bool AddTermStepEstMap(int comp_id
                                    , string est_id
                                    , int estterm_step_id
                                    , Double weight
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

			affectedRow = _dac_termStepEstMaps.Insert(null
                                                    , null
                                                    , comp_id
                                                    , est_id
												    , estterm_step_id
                                                    , ""
                                                    , weight
												    , create_date
												    , create_user);

			return ( affectedRow > 0 ) ? true : false;
        }

        public bool SaveTermStepEstMap(DataTable dataTable
                                    , int comp_id
                                    , string est_id)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int affectedRow = 0;

			try
			{
				affectedRow += _dac_termStepEstMaps.Delete(conn
                                                        , trx
                                                        , comp_id
                                                        , est_id
                                                        , 0);

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _dac_termStepEstMaps.Insert(conn
                                                            , trx
                                                            , dataRow["COMP_ID"]
                                                            , dataRow["EST_ID"]
												            , dataRow["ESTTERM_STEP_ID"]
                                                            , dataRow["FIXED_WEIGHT_YN"]
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
         
		public bool RemoveTermStepEstMap(int comp_id, string est_id)
		{
			return RemoveTermStepEstMap(comp_id, est_id, 0);
		}

        public bool RemoveTermStepEstMap( int comp_id
                                        , string est_id
                                        , int estterm_step_id)
        {
	        int affectedRow = 0;

			affectedRow = _dac_termStepEstMaps.Delete(null
                                                    , null
                                                    , comp_id
                                                    , est_id
												    , estterm_step_id);

			return ( affectedRow > 0 ) ? true : false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_STEP_ID", typeof(int));
            dataTable.Columns.Add("FIXED_WEIGHT_YN", typeof(string));
            dataTable.Columns.Add("WEIGHT", typeof(double));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
