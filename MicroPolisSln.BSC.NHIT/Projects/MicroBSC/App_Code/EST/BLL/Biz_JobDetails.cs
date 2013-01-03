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
    public class Biz_JobDetails
    {
        #region ============================== [Fields] ==============================
 
        private int 	_comp_id;
        private string 	_est_id;
        private int 	_estterm_ref_id;
        private int 	_estterm_sub_id;
        private int 	_estterm_step_id;
        private string 	_est_job_id;
        private string 	_est_job_name;
        private string 	_status_yn = "";
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_JobDetails _jobDetail = new Dac_JobDetails();

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
         
        public int EstTerm_Ref_ID
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
         
        public string Status_YN
        {
	        get 
	        {
		        return _status_yn;
	        }
	        set
	        {
		        _status_yn = ( value==null ? "" : value );
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
         
        public Biz_JobDetails()
        {
            
        }

        public Biz_JobDetails(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string est_job_id)
        {
            DataSet ds =  _jobDetail.Select(  comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_job_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
		        _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
		        _estterm_step_id    = (dr["ESTTERM_STEP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
		        _est_job_id         = (dr["EST_JOB_ID"]         == DBNull.Value) ? "" : (string) dr["EST_JOB_ID"];
                _est_job_name       = (dr["EST_JOB_NAME"]       == DBNull.Value) ? "" : (string) dr["EST_JOB_NAME"];
		        _status_yn          = (dr["STATUS_YN"]          == DBNull.Value) ? "N" : (string) dr["STATUS_YN"];
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
            else 
            {
                _est_job_name       = "";
                _status_yn          = "";
            }
        }
         
        public bool ModifyJobDetailByStatus(  int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string est_job_id
                                            , string status_yn
                                            , DateTime update_date
                                            , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobDetail.Update(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_job_id
                                            , DBNull.Value
                                            , DBNull.Value
                                            , status_yn
                                            , update_date
                                            , update_user);

			return ( affectedRow > 0 )? true:false;
        }

        public bool ModifyJobDetailByDate( int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string est_job_id
                                        , DateTime start_date
                                        , DateTime end_date
                                        , DateTime update_date
                                        , int update_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobDetail.Update(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_job_id
                                            , start_date
                                            , end_date
                                            , DBNull.Value
                                            , update_date
                                            , update_user);

			return ( affectedRow > 0 )? true:false;
        }

        public bool ModifyJobDetailByDate(object[] temp)
        {
            int affectedRow = 0;

            affectedRow = _jobDetail.Update(null
                                          , null
                                          , temp);

            return (affectedRow > 0) ? true : false;
        }
         
        public DataSet GetJobDetail(  int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string est_job_id)
        {
			return _jobDetail.Select( comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_job_id);
        }
         
        public bool AddJobDetail( int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string est_job_id
                                , string status_yn
                                , DateTime create_date
                                , int create_user)
        {
	        int affectedRow = 0;

			affectedRow = _jobDetail.Insert(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_job_id
                                            , status_yn
                                            , create_date
                                            , create_user);

			return ( affectedRow > 0 )? true:false;
        }

        public bool AddJobDetail(object[] temp)
        {
            int affectedRow = 0;

            affectedRow = _jobDetail.Insert(null
                                          , null
                                          , temp);

            return (affectedRow > 0) ? true : false;
        }

        public bool SaveJobDetail( int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string est_job_id
                                , string status_yn
                                , DateTime date
                                , int user)
        {
	        int affectedRow = 0;

            if(IsExist(comp_id
                    , est_id
                    , estterm_ref_id
                    , estterm_sub_id
                    , estterm_step_id
                    , est_job_id)) 
            {
                affectedRow = _jobDetail.Update(  null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_job_id
                                                , DateTime.Now
												, DateTime.Now
                                                , status_yn
                                                , date
                                                , user);
            }
            else 
            {
                affectedRow = _jobDetail.Insert(  null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_job_id
                                                , status_yn
                                                , date
                                                , user);
            }

			return ( affectedRow > 0 )? true:false;
        }
         
        public bool RemoveJobDetail(  int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string est_job_id)
        {
	        int affectedRow = 0;

			affectedRow = _jobDetail.Delete(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_job_id);

			return ( affectedRow > 0 )? true:false;
        }

        public bool IsExist(  int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string est_job_id)
        {
	        int affectedRow = 0;

			affectedRow = _jobDetail.Count(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_job_id);

			return ( affectedRow > 0 )? true:false;
        }
    }
}
