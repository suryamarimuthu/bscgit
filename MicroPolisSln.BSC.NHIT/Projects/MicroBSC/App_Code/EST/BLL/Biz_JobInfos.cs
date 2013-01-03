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
    public class Biz_JobInfos
    {
        #region ============================== [Fields] ==============================
 
        private string 	_est_job_id;
        private string 	_est_job_name;
        private string 	_est_job_depen_ids;
        private string  _var_map_key;
        private string 	_mng_page_yn;
        private string 	_year_yn;
        private string 	_merge_yn;
        private string 	_sort_column = "";
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_JobInfos _jobInfo = new Dac_JobInfos();

        #endregion
         
        #region ============================== [Properties] ==============================
         
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
         
        public string Est_Job_Name
        {
	        get 
	        {
		        return _est_job_name;
	        }
	        set
	        {
		        _est_job_name = ( value==null ? "" : value );
	        }
        }
         
        public string Est_Job_Depen_IDs
        {
	        get 
	        {
		        return _est_job_depen_ids;
	        }
	        set
	        {
		        _est_job_depen_ids = ( value==null ? "" : value );
	        }
        }

        public string Var_Map_Key
        {
	        get 
	        {
		        return _var_map_key;
	        }
	        set
	        {
		        _var_map_key = ( value==null ? "" : value );
	        }
        }

        public string Mng_Page_YN
        {
	        get 
	        {
		        return _mng_page_yn;
	        }
	        set
	        {
		        _mng_page_yn = ( value==null ? "" : value );
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
		        _year_yn = ( value==null ? "" : value );
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
		        _merge_yn = ( value==null ? "" : value );
	        }
        }

        public string Sort_Column
        {
	        get 
	        {
		        return _sort_column;
	        }
	        set
	        {
		        _sort_column = ( value==null ? "" : value );
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

        public Biz_JobInfos()
        {
            
        }

        public Biz_JobInfos(string est_job_id)
        {
            DataSet ds = _jobInfo.Select(est_job_id, "");
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                                  = ds.Tables[0].Rows[0];
		        _est_job_id                         = (dr["EST_JOB_ID"]                     == DBNull.Value) ? "" : (string) dr["EST_JOB_ID"];
		        _est_job_name                       = (dr["EST_JOB_NAME"]                   == DBNull.Value) ? "" : (string) dr["EST_JOB_NAME"];
		        _est_job_depen_ids                  = (dr["EST_JOB_DEPEN_IDS"]              == DBNull.Value) ? "" : (string) dr["EST_JOB_DEPEN_IDS"];
                _var_map_key                        = (dr["VAR_MAP_KEY"]                    == DBNull.Value) ? "" : (string) dr["VAR_MAP_KEY"];
                _mng_page_yn                        = (dr["MNG_PAGE_YN"]                    == DBNull.Value) ? "N" : (string) dr["MNG_PAGE_YN"];
		        _year_yn                            = (dr["YEAR_YN"]                        == DBNull.Value) ? "N" : (string) dr["YEAR_YN"];
		        _merge_yn                           = (dr["MERGE_YN"]                       == DBNull.Value) ? "N" : (string) dr["MERGE_YN"];
                _sort_column                        = (dr["SORT_COLUMN"]                    == DBNull.Value) ? "" : (string) dr["SORT_COLUMN"];
		        _update_date                        = (dr["UPDATE_DATE"]                    == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user                        = (dr["UPDATE_USER"]                    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
        }
         
        public bool ModifyJobInfo( string est_job_id
                                , string est_job_name
                                , string est_job_depen_ids
                                , string var_map_key
                                , string mng_page_yn
                                , string year_yn
                                , string merge_yn
                                , DateTime update_date
                                , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobInfo.Update(null
                                        , null
                                        , est_job_id
                                        , est_job_name
                                        , est_job_depen_ids
                                        , var_map_key
                                        , mng_page_yn
                                        , year_yn
                                        , merge_yn
                                        , update_date
                                        , update_user);

			return ( affectedRow > 0 )? true:false;
        }
         
        public DataSet GetJobInfo(string est_job_id)
        {
	        return _jobInfo.Select(est_job_id, "");
        }

        public DataSet GetJobInfos(string mng_page_yn)
        {
	        return _jobInfo.Select("", mng_page_yn);
        }

        public DataSet GetJobInfoInEstJobMaps(int comp_id, string est_id, string mng_page_yn)
        {
	        return _jobInfo.SelectInEstJobMap("", mng_page_yn, comp_id, est_id);
        }

        public bool AddJobInfo( string est_job_id
                            , string est_job_name
                            , string est_job_depen_ids
                            , string var_map_key
                            , string mng_page_yn
                            , string year_yn
                            , string merge_yn
                            , DateTime create_date
                            , int create_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobInfo.Insert(null
                                        , null
                                        , est_job_id
                                        , est_job_name
                                        , est_job_depen_ids
                                        , var_map_key
                                        , mng_page_yn
                                        , year_yn
                                        , merge_yn
                                        , create_date
                                        , create_user);

			return ( affectedRow > 0 )? true:false;
        }
         
        public bool RemoveJobInfo( string est_job_id)
        {
	        int affectedRow = 0;

			affectedRow = _jobInfo.Delete(null
                                        , null
                                        , est_job_id);

			return ( affectedRow > 0 )? true:false;
        }
    }
}
