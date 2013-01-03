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
    public class Biz_JobEstMaps
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private string 	_est_job_id;
        private DateTime 	_update_date;
        private int 	_update_user;

        Dac_JobEstMaps _jobEstMap = new Dac_JobEstMaps();

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
         
        public string Est_Job_ID
        {
	        get 
	        {
		        return _est_job_id;
	        }
	        set
	        {
		        _est_job_id = ( value==null ? "" : value );
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
         
        public Biz_JobEstMaps()
        {
            
        }

        public Biz_JobEstMaps(int comp_id
                            , string est_id
                            , string est_job_id)
        {
            DataSet ds = _jobEstMap.Select(   comp_id
                                            , est_id
                                            , est_job_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
                _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _est_job_id     = (dr["EST_JOB_ID"]     == DBNull.Value) ? "" : (string) dr["EST_JOB_ID"];
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyJobEstMap(  int comp_id
                                    , string est_id
                                    , string est_job_id
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobEstMap.Update(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , est_job_id
                                            , update_date
                                            , update_user);

			return ( affectedRow > 0 )? true:false;
        }
         
        public DataSet GetJobEstMap(  int comp_id
                                    , string est_id
                                    , string est_job_id)
        {
	        return _jobEstMap.Select( comp_id
                                    , est_id
                                    , est_job_id);
        }
        public DataSet GetJobEstMap(int comp_id
                                  , string est_id
                                  , int estterm_ref_id
                                  , int estterm_sub_id
                                  , string est_job_id)
        {
            return _jobEstMap.Select(comp_id
                                   , est_id
                                   , estterm_ref_id
                                   , estterm_sub_id
                                   , est_job_id);
        }

        public DataSet GetJobEstMapNotIn( int comp_id
                                        , string est_id
                                        , string est_job_id)
        {
	        return _jobEstMap.SelectNotIn( comp_id
                                        , est_id
                                        , est_job_id);
        }
         
        public bool AddJobEstMap( int comp_id
                                , string est_id
                                , string est_job_id
                                , DateTime create_date
                                , int create_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobEstMap.Insert(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , est_job_id
                                            , create_date
                                            , create_user);

			return ( affectedRow > 0 )? true:false;
        }

        public bool SaveJobEstMap(DataTable dataTable, int comp_id, string est_id)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _jobEstMap.Delete( conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , "");

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _jobEstMap.Insert( conn
                                                    , trx
                                                    , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                    , DataTypeUtility.GetValue(dataRow["EST_ID"])
                                                    , DataTypeUtility.GetValue(dataRow["EST_JOB_ID"])
                                                    , DataTypeUtility.GetToDateTime(dataRow["DATE"])
                                                    , DataTypeUtility.GetToInt32(dataRow["USER"]));
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
         
        public bool RemoveJobEstMap(int comp_id, string est_id, string est_job_id)
        {
	        int affectedRow = 0;

			affectedRow = _jobEstMap.Delete(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , est_job_id);

			return ( affectedRow > 0 )? true:false;
        }

        public bool IsExist(int comp_id, string est_id, string est_job_id)
        {
	        int affectedRow = 0;

			affectedRow = _jobEstMap.Count(   comp_id
                                            , est_id
                                            , est_job_id);

			return ( affectedRow > 0 )? true:false;
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("EST_JOB_ID", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}
