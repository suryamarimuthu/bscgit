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
    public class Biz_JobColumnMaps
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private string 	_est_job_id;
        private string  _col_key;
        private DateTime 	_update_date;
        private int 	_update_user;

        Dac_JobColumnMaps _jobColumnMap = new Dac_JobColumnMaps();

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

        public string Col_Key
        {
	        get 
	        {
		        return _col_key;
	        }
	        set
	        {
		        _col_key = ( value==null ? "" : value );
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
         
        public Biz_JobColumnMaps()
        {
            
        }

        public Biz_JobColumnMaps(int comp_id
                                , string est_id
                                , string est_job_id
                                , string col_key)
        {
            DataSet ds = _jobColumnMap.Select(comp_id
                                            , est_id
                                            , est_job_id
                                            , col_key);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr              = ds.Tables[0].Rows[0];
                _comp_id        = (dr["COMP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id         = (dr["EST_ID"]         == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _est_job_id     = (dr["EST_JOB_ID"]     == DBNull.Value) ? "" : (string) dr["EST_JOB_ID"];
                _col_key        = (dr["COL_KEY"]        == DBNull.Value) ? "" : (string) dr["COL_KEY"];
		        _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyJobColumnMap(   int comp_id
                                        , string est_id
                                        , string est_job_id
                                        , string col_key
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobColumnMap.Update(   null
                                                , null
                                                , comp_id
                                                , est_id
                                                , est_job_id
                                                , col_key
                                                , update_date
                                                , update_user);

			return ( affectedRow > 0 )? true:false;
        }
         
        public DataSet GetJobColumnMap(   int comp_id
                                        , string est_id
                                        , string est_job_id
                                        , string col_key)
        {
	        return _jobColumnMap.Select(  comp_id
                                        , est_id
                                        , est_job_id
                                        , col_key);
        }

        public DataSet GetJobColumnMap(   int comp_id
                                        , string est_id
                                        , string est_job_id)
        {
	        return _jobColumnMap.Select(  comp_id
                                        , est_id
                                        , est_job_id
                                        , "");
        }

        public DataSet GetJobColumnMapNotIn(  int comp_id
                                            , string est_id
                                            , string est_job_id
                                            , string col_key)
        {
	        return _jobColumnMap.SelectNotIn( comp_id
                                            , est_id
                                            , est_job_id
                                            , col_key);
        }
         
        public bool AddJobColumnMap(  int comp_id
                                    , string est_id
                                    , string est_job_id
                                    , string col_key
                                    , DateTime create_date
                                    , int create_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobColumnMap.Insert(   null
                                                , null
                                                , comp_id
                                                , est_id
                                                , est_job_id
                                                , col_key
                                                , create_date
                                                , create_user);

			return ( affectedRow > 0 )? true:false;
        }

        public bool SaveJobColumnMap(DataTable dataTable, int comp_id, string est_id, string col_key)
        {
	        int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _jobColumnMap.Delete(  conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , ""
                                                    , col_key);

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _jobColumnMap.Insert(  conn
                                                        , trx
                                                        , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                        , DataTypeUtility.GetValue(dataRow["EST_ID"])
                                                        , DataTypeUtility.GetValue(dataRow["EST_JOB_ID"])
                                                        , DataTypeUtility.GetValue(dataRow["COL_KEY"])
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
         
        public bool RemoveJobColumnMap(int comp_id
                                    , string est_id
                                    , string est_job_id
                                    , string col_key)
        {
	        int affectedRow = 0;

			affectedRow = _jobColumnMap.Delete(   null
                                                , null
                                                , comp_id
                                                , est_id
                                                , est_job_id
                                                , col_key);

			return ( affectedRow > 0 )? true:false;
        }

        public bool IsExist(  int comp_id
                            , string est_id
                            , string est_job_id
                            , string col_key)
        {
	        int affectedRow = 0;

			affectedRow = _jobColumnMap.Count(comp_id
                                            , est_id
                                            , est_job_id
                                            , col_key);

			return ( affectedRow > 0 )? true:false;
        }

        public DataTable GetDataTableSchema() 
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("EST_JOB_ID", typeof(string));
            dataTable.Columns.Add("COL_KEY", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}
