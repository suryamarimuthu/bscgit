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
    public class Biz_ReportDetails
    {
        #region ============================== [Fields] ==============================
 
        private string 	_rpt_dtl_id;
        private string 	_rpt_dtl_name;
        private int 	_comp_id;
        private string 	_from_est_id;
        private string 	_est_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private string 	_rpt_itm_id;
        private int 	_seq;
        private string 	_est_job_ids;
        private string 	_est_tgt_type;
        private string 	_estterm_use_yn;
        private string 	_estterm_sub_yn;
        private string 	_estterm_step_yn;
        private string 	_year_yn;
        private string 	_merge_yn;
        private string 	_dept_column_no_use_yn;
        private string  _estterm_sub_all_use_yn;
        private string  _estterm_step_all_use_yn;
        private string 	_bg_img_url;
        private string 	_title_img_url;
        private string 	_title_name;
        private string  _cus_html;
        private int _grid_height;
        private string 	_q_style_id;
        private string 	_use_yn;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_ReportDetails _reportDeatail = new Dac_ReportDetails();

        #endregion
         
        #region ============================== [Properties] ==============================
         
        public string Rpt_Dtl_ID
        {
	        get 
	        {
		        return _rpt_dtl_id;
	        }
	        set
	        {
		        _rpt_dtl_id = ( value==null ? "" : value );
	        }
        }
         
        public string Rpt_Dtl_Name
        {
	        get 
	        {
		        return _rpt_dtl_name;
	        }
	        set
	        {
		        _rpt_dtl_name = ( value==null ? "" : value );
	        }
        }
         
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

        public string From_Est_ID
        {
	        get 
	        {
		        return _from_est_id;
	        }
	        set
	        {
		        _from_est_id = ( value==null ? "" : value );
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
         
        public string Rpt_Itm_ID
        {
	        get 
	        {
		        return _rpt_itm_id;
	        }
	        set
	        {
		        _rpt_itm_id = ( value==null ? "" : value );
	        }
        }
         
        public int Seq
        {
	        get 
	        {
		        return _seq;
	        }
	        set
	        {
		        _seq = value;
	        }
        }
         
        public string Est_Job_IDs
        {
	        get 
	        {
		        return _est_job_ids;
	        }
	        set
	        {
		        _est_job_ids = ( value==null ? "" : value );
	        }
        }
         
        public string Est_Tgt_Type
        {
	        get 
	        {
		        return _est_tgt_type;
	        }
	        set
	        {
		        _est_tgt_type = ( value==null ? "" : value );
	        }
        }
         
        public string EstTerm_Use_YN
        {
	        get 
	        {
		        return _estterm_use_yn;
	        }
	        set
	        {
		        _estterm_use_yn = ( value==null ? "" : value );
	        }
        }
         
        public string EstTerm_Sub_YN
        {
	        get 
	        {
		        return _estterm_sub_yn;
	        }
	        set
	        {
		        _estterm_sub_yn = ( value==null ? "" : value );
	        }
        }
         
        public string EstTerm_Step_YN
        {
	        get 
	        {
		        return _estterm_step_yn;
	        }
	        set
	        {
		        _estterm_step_yn = ( value==null ? "" : value );
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
         
        public string Dept_Column_No_Use_YN
        {
	        get 
	        {
		        return _dept_column_no_use_yn;
	        }
	        set
	        {
		        _dept_column_no_use_yn = ( value==null ? "" : value );
	        }
        }

        public string EstTerm_Sub_All_Use_YN
        {
	        get 
	        {
		        return _estterm_sub_all_use_yn;
	        }
	        set
	        {
		        _estterm_sub_all_use_yn = ( value==null ? "" : value );
	        }
        }

        public string EstTerm_Step_All_Use_YN
        {
	        get 
	        {
		        return _estterm_step_all_use_yn;
	        }
	        set
	        {
		        _estterm_step_all_use_yn = ( value==null ? "" : value );
	        }
        }
         
        public string Bg_Img_Url
        {
	        get 
	        {
		        return _bg_img_url;
	        }
	        set
	        {
		        _bg_img_url = ( value==null ? "" : value );
	        }
        }
         
        public string Title_Img_Url
        {
	        get 
	        {
		        return _title_img_url;
	        }
	        set
	        {
		        _title_img_url = ( value==null ? "" : value );
	        }
        }
         
        public string Title_Name
        {
	        get 
	        {
		        return _title_name;
	        }
	        set
	        {
		        _title_name = ( value==null ? "" : value );
	        }
        }

        public string Cus_Html
        {
	        get 
	        {
		        return _cus_html;
	        }
	        set
	        {
		        _cus_html = ( value==null ? "" : value );
	        }
        }

        public int Grid_Height
        {
	        get 
	        {
		        return _grid_height;
	        }
	        set
	        {
		        _grid_height = value;
	        }
        }
         
        public string Q_Style_ID
        {
	        get 
	        {
		        return _q_style_id;
	        }
	        set
	        {
		        _q_style_id = ( value==null ? "" : value );
	        }
        }
         
        public string Use_YN
        {
	        get 
	        {
		        return _use_yn;
	        }
	        set
	        {
		        _use_yn = ( value==null ? "" : value );
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
         
        public Biz_ReportDetails()
	    {
		    
	    }

        public Biz_ReportDetails(string rpt_dtl_id, int comp_id, string from_est_id)
	    {
            DataSet ds = _reportDeatail.Select(rpt_dtl_id, comp_id, from_est_id, "");
		    DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                      = ds.Tables[0].Rows[0];
		        _rpt_dtl_id             = (dr["RPT_DTL_ID"]             == DBNull.Value) ? "" : (string) dr["RPT_DTL_ID"];
		        _rpt_dtl_name           = (dr["RPT_DTL_NAME"]           == DBNull.Value) ? "" : (string) dr["RPT_DTL_NAME"];
		        _comp_id                = (dr["COMP_ID"]                == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _from_est_id            = (dr["FROM_EST_ID"]            == DBNull.Value) ? "" : (string) dr["FROM_EST_ID"];
		        _est_id                 = (dr["EST_ID"]                 == DBNull.Value) ? "" : (string) dr["EST_ID"];
                _estterm_sub_id         = (dr["ESTTERM_SUB_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id        = (dr["ESTTERM_STEP_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
		        _rpt_itm_id             = (dr["RPT_ITM_ID"]             == DBNull.Value) ? "" : (string) dr["RPT_ITM_ID"];
		        _seq                    = (dr["SEQ"]                    == DBNull.Value) ? 0 : Convert.ToInt32(dr["SEQ"]);
		        _est_job_ids            = (dr["EST_JOB_IDS"]            == DBNull.Value) ? "" : (string) dr["EST_JOB_IDS"];
		        _est_tgt_type           = (dr["EST_TGT_TYPE"]           == DBNull.Value) ? "" : (string) dr["EST_TGT_TYPE"];
		        _estterm_use_yn         = (dr["ESTTERM_USE_YN"]         == DBNull.Value) ? "" : (string) dr["ESTTERM_USE_YN"];
		        _estterm_sub_yn         = (dr["ESTTERM_SUB_YN"]         == DBNull.Value) ? "" : (string) dr["ESTTERM_SUB_YN"];
		        _estterm_step_yn        = (dr["ESTTERM_STEP_YN"]        == DBNull.Value) ? "" : (string) dr["ESTTERM_STEP_YN"];
		        _year_yn                = (dr["YEAR_YN"]                == DBNull.Value) ? "" : (string) dr["YEAR_YN"];
		        _merge_yn               = (dr["MERGE_YN"]               == DBNull.Value) ? "" : (string) dr["MERGE_YN"];
		        _dept_column_no_use_yn  = (dr["DEPT_COLUMN_NO_USE_YN"]  == DBNull.Value) ? "" : (string) dr["DEPT_COLUMN_NO_USE_YN"];
                _estterm_sub_all_use_yn = (dr["ESTTERM_SUB_ALL_USE_YN"] == DBNull.Value) ? "" : (string) dr["ESTTERM_SUB_ALL_USE_YN"];
                _estterm_step_all_use_yn= (dr["ESTTERM_STEP_ALL_USE_YN"]== DBNull.Value) ? "" : (string) dr["ESTTERM_STEP_ALL_USE_YN"];
		        _bg_img_url             = (dr["BG_IMG_URL"]             == DBNull.Value) ? "" : (string) dr["BG_IMG_URL"];
		        _title_img_url          = (dr["TITLE_IMG_URL"]          == DBNull.Value) ? "" : (string) dr["TITLE_IMG_URL"];
		        _title_name             = (dr["TITLE_NAME"]             == DBNull.Value) ? "" : (string) dr["TITLE_NAME"];
                _cus_html               = (dr["CUS_HTML"]               == DBNull.Value) ? "" : (string) dr["CUS_HTML"];
                _grid_height            = (dr["GRID_HEIGHT"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["GRID_HEIGHT"]);
		        _q_style_id             = (dr["Q_STYLE_ID"]             == DBNull.Value) ? "" : (string) dr["Q_STYLE_ID"];
		        _use_yn                 = (dr["USE_YN"]                 == DBNull.Value) ? "" : (string) dr["USE_YN"];
		        _update_date            = (dr["UPDATE_DATE"]            == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user            = (dr["UPDATE_USER"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
	    }
         
        public bool ModifyReportDetail( string rpt_dtl_id
                                    , string rpt_dtl_name
                                    , int comp_id
                                    , string from_est_id
                                    , string est_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string rpt_itm_id
                                    , int seq
                                    , string est_job_ids
                                    , string est_tgt_type
                                    , string estterm_use_yn
                                    , string estterm_sub_yn
                                    , string estterm_step_yn
                                    , string year_yn
                                    , string merge_yn
                                    , string dept_column_no_use_yn
                                    , string estterm_sub_all_use_yn
                                    , string estterm_step_all_use_yn
                                    , string bg_img_url
                                    , string title_img_url
                                    , string title_name
                                    , string cus_html
                                    , int grid_height
                                    , string q_style_id
                                    , string use_yn
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _reportDeatail.Update(  null
                                                , null
                                                , rpt_dtl_id
                                                , rpt_dtl_name
                                                , comp_id
                                                , from_est_id
                                                , est_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , rpt_itm_id
                                                , seq
                                                , est_job_ids
                                                , est_tgt_type
                                                , estterm_use_yn
                                                , estterm_sub_yn
                                                , estterm_step_yn
                                                , year_yn
                                                , merge_yn
                                                , dept_column_no_use_yn
                                                , estterm_sub_all_use_yn
                                                , estterm_step_all_use_yn
                                                , bg_img_url
                                                , title_img_url
                                                , title_name
                                                , cus_html
                                                , grid_height
                                                , q_style_id
                                                , use_yn
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetReportDetails()
        {
            return _reportDeatail.Select("", 0, "", "Y");
        }

        public DataSet GetReportIndividal(int comp_id
                                        , int estterm_ref_id
                                        , string est_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string estid_1
                                        , string estid_2
                                        , string gong_id
                                        , string mbo_id
                                        , int tgt_emp_id
                                        , string is_team_kpi
                                        , string yid1
                                        , string yid2
                                        , string yid3)
        {
            return _reportDeatail.GetReportIndividal(comp_id
                                                    , estterm_ref_id
                                                    , est_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , estid_1
                                                    , estid_2
                                                    , gong_id
                                                    , mbo_id
                                                    , tgt_emp_id
                                                    , is_team_kpi
                                                    , yid1
                                                    , yid2
                                                    , yid3);
        }

        public DataTable[] GetEstDataForReportMBO(int comp_id
                                        , int estterm_ref_id
                                        , string est_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string estid_1
                                        , string estid_2
                                        , string gong_id
                                        , string mbo_id
                                        , int tgt_emp_id
                                        , string is_team_kpi
                                        , string yid1
                                        , string yid2
                                        , string yid3)
        {
            DataTable[] dt = new DataTable[6];



            MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
            DataTable dtEstData = bizEstData.GetEstGraph_DB(comp_id
                                                          , est_id
                                                          , estterm_ref_id
                                                          , estterm_sub_id
                                                          , estterm_step_id
                                                          , tgt_emp_id
                                                          , estid_1
                                                          , estid_2
                                                          , yid1
                                                          , yid2
                                                          , yid3);




            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Mbo_Kpi_Weight dacBscMboKpiWeight = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Mbo_Kpi_Weight();

            DataTable dtBscMboKpiWeight = dacBscMboKpiWeight.SelectGraph_Data(comp_id
                                                                            , estterm_ref_id
                                                                            , estterm_sub_id
                                                                            , tgt_emp_id
                                                                            , is_team_kpi);

            

            MicroBSC.Integration.EST.Dac.Dac_Est_Question_Data dacEstQuestionData = new MicroBSC.Integration.EST.Dac.Dac_Est_Question_Data();

            DataTable dtEstQuestionData = dacEstQuestionData.SelectEstQuestionDataGraph1_DB(comp_id
                                                                                         , yid1
                                                                                         , estterm_ref_id
                                                                                         , estterm_sub_id
                                                                                         , tgt_emp_id);
            
            DataTable dtEstQuestionSubject2 = dacEstQuestionData.SelectEstQuestionSubjectGraph2_DB(comp_id
                                                                                         , yid2
                                                                                         , estterm_ref_id
                                                                                         , estterm_sub_id
                                                                                         , tgt_emp_id);

            DataTable dtEstQuestionSubject3 = dacEstQuestionData.SelectEstQuestionSubjectGraph3_DB(comp_id
                                                                                         , yid3
                                                                                         , estterm_ref_id
                                                                                         , estterm_sub_id
                                                                                         , tgt_emp_id);

            DataTable dtEstQuestionSubject = dacEstQuestionData.SelectEstQuestionSubjectGraph_DB(comp_id
                                                                                         , gong_id
                                                                                         , estterm_ref_id
                                                                                         , estterm_sub_id
                                                                                         , tgt_emp_id);


            dt[0] = dtEstData;
            dt[1] = dtBscMboKpiWeight;
            dt[2] = dtEstQuestionData;
            dt[3] = dtEstQuestionSubject2;
            dt[4] = dtEstQuestionSubject3;
            dt[5] = dtEstQuestionSubject;

            return dt;
        }
         
        public DataSet GetReportDetail(string rpt_dtl_id
                                    , int comp_id
                                    , string from_est_id
                                    , string use_yn)
        {
	        return _reportDeatail.Select(rpt_dtl_id
                                        , comp_id
                                        , from_est_id
                                        , use_yn);
        }
        
        public DataSet GetReportDetail(int comp_id, string from_est_id)
        {
	        return _reportDeatail.Select("", comp_id, from_est_id, "Y");
        }

        public bool AddReportDetail(string rpt_dtl_id
                                , string rpt_dtl_name
                                , int comp_id
                                , string from_est_id
                                , string est_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string rpt_itm_id
                                , int seq
                                , string est_job_ids
                                , string est_tgt_type
                                , string estterm_use_yn
                                , string estterm_sub_yn
                                , string estterm_step_yn
                                , string year_yn
                                , string merge_yn
                                , string dept_column_no_use_yn
                                , string estterm_sub_all_use_yn
                                , string estterm_step_all_use_yn
                                , string bg_img_url
                                , string title_img_url
                                , string title_name
                                , string cus_html
                                , int grid_height
                                , string q_style_id
                                , string use_yn
                                , DateTime create_date
                                , int create_user)
        {
	        int affectedRow = 0;

            affectedRow = _reportDeatail.Insert(null
                                            , null
                                            , rpt_dtl_id
                                            , rpt_dtl_name
                                            , comp_id
                                            , from_est_id
                                            , est_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , rpt_itm_id
                                            , seq
                                            , est_job_ids
                                            , est_tgt_type
                                            , estterm_use_yn
                                            , estterm_sub_yn
                                            , estterm_step_yn
                                            , year_yn
                                            , merge_yn
                                            , dept_column_no_use_yn
                                            , estterm_sub_all_use_yn
                                            , estterm_step_all_use_yn
                                            , bg_img_url
                                            , title_img_url
                                            , title_name
                                            , cus_html
                                            , grid_height
                                            , q_style_id
                                            , use_yn
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }
         
        public bool RemoveReportDetail(   string rpt_dtl_id
                                        , int comp_id
                                        , string from_est_id)
        {
	        int affectedRow = 0;

            affectedRow = _reportDeatail.Delete(null
                                            , null
                                            , rpt_dtl_id
                                            , comp_id
                                            , from_est_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
