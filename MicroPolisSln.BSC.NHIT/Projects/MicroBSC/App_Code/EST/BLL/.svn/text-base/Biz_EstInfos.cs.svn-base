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
    public class Biz_EstInfos
    {
        #region ============================== [Fields] ==============================
 
        private int     _comp_id;
        private string 	_est_id;
        private object 	_up_est_id;
        private string 	_est_name;
        private string 	_header_color;
        private string 	_grade_confirm_yn;
        private string 	_bias_yn;
        private string 	_bias_dept_use_yn;
        private string 	_tgt_opinion_yn;
        private string  _feedback_yn;
        private int 	_estterm_sub;
        private int 	_estterm_step;
        private string  _fixed_weight_use_yn;
        private double  _fixed_weight;
        private int 	_point_ctrl_step;
        private int 	_grade_ctrl_step;
        private string 	_owner_type;
        private string  _est_style_id;
        private string  _link_est_id;
        private string  _weight_type;
        private string  _scale_type;
        private string  _status_style_id;
        private string  _q_style_id;
        private string  _q_item_desc_use_yn;
        private string  _q_tgt_pos_biz_use_yn;
        private string  _all_step_visible_yn;
        private string  _emp_com_dept_yn;
        private string  _bias_type_id;
        private string 	_use_yn;
        private string _visible_past_point_yn;
        private string _est_qtt_mbo_yn;
        private string _dashboard_type;
        private string _question_previous_step_yn;
        private DateTime 	_create_date;
        private int 	_create_user;
        private DateTime 	_update_date;
        private int 	_update_user;
        private string _mbo_score_estimate_yn;

        private Dac_EstInfos _estInfo = new Dac_EstInfos();

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

        public object Up_Est_ID
        {
	        get 
	        {
		        return _up_est_id;
	        }
	        set
	        {
		        _up_est_id = value;
	        }
        }        
		
        public string Est_Name
        {
	        get 
	        {
		        return _est_name;
	        }
	        set
	        {
		        _est_name = ( value==null ? "" : value );
	        }
        }
         
        public string Header_Color
        {
	        get 
	        {
		        return _header_color;
	        }
	        set
	        {
		        _header_color = ( value==null ? "" : value );
	        }
        }
         
        public string Grade_Confirm_YN
        {
	        get 
	        {
		        return _grade_confirm_yn;
	        }
	        set
	        {
		        _grade_confirm_yn = ( value==null ? "" : value );
	        }
        }
         
        public string Bias_YN
        {
	        get 
	        {
		        return _bias_yn;
	        }
	        set
	        {
		        _bias_yn = ( value==null ? "" : value );
	        }
        }

        public string Bias_Dept_Use_YN
        {
	        get 
	        {
		        return _bias_dept_use_yn;
	        }
	        set
	        {
		        _bias_dept_use_yn = ( value==null ? "" : value );
	        }
        }

        public string Tgt_Opinion_YN
        {
	        get 
	        {
		        return _tgt_opinion_yn;
	        }
	        set
	        {
		        _tgt_opinion_yn = ( value==null ? "" : value );
	        }
        }

        public string FeedBack_YN
        {
	        get 
	        {
		        return _feedback_yn;
	        }
	        set
	        {
		        _tgt_opinion_yn = ( value==null ? "" : value );
	        }
        }

        public int EstTerm_Sub
        {
	        get 
	        {
		        return _estterm_sub;
	        }
	        set
	        {
		        _estterm_sub = value;
	        }
        }        
 
        public int EstTerm_Step
        {
	        get 
	        {
		        return _estterm_step;
	        }
	        set
	        {
		        _estterm_step = value;
	        }
        }

        public string Fixed_Weight_Use_YN
        {
	        get 
	        {
		        return _fixed_weight_use_yn;
	        }
	        set
	        {
		        _fixed_weight_use_yn = value;
	        }
        }

        public double Fixed_Weight
        {
	        get 
	        {
		        return _fixed_weight;
	        }
	        set
	        {
		        _fixed_weight = value;
	        }
        }
         
        public int Point_Ctrl_Step
        {
	        get 
	        {
		        return _point_ctrl_step;
	        }
	        set
	        {
		        _point_ctrl_step = value;
	        }
        }
         
        public int Grade_Ctrl_Step
        {
	        get 
	        {
		        return _grade_ctrl_step;
	        }
	        set
	        {
		        _grade_ctrl_step = value;
	        }
        }
         
        public string Owner_Type
        {
	        get 
	        {
		        return _owner_type;
	        }
	        set
	        {
		        _owner_type = ( value==null ? "" : value );
	        }
        }

        public string Est_Style_ID
        {
	        get 
	        {
		        return _est_style_id;
	        }
	        set
	        {
		        _est_style_id = ( value==null ? "" : value );
	        }
        }

        public string Link_Est_ID
        {
	        get 
	        {
		        return _link_est_id;
	        }
	        set
	        {
		        _link_est_id = ( value==null ? "" : value );
	        }
        }

        public string Weight_Type
        {
	        get 
	        {
		        return _weight_type;
	        }
	        set
	        {
		        _weight_type = ( value==null ? "" : value );
	        }
        }

        public string Scale_Type
        {
	        get 
	        {
		        return _scale_type;
	        }
	        set
	        {
		        _scale_type = ( value==null ? "" : value );
	        }
        }

        public string Status_Style_ID
        {
	        get 
	        {
		        return _status_style_id;
	        }
	        set
	        {
		        _status_style_id = ( value==null ? "" : value );
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

        public string Q_Item_Desc_Use_YN
        {
	        get 
	        {
		        return _q_item_desc_use_yn;
	        }
	        set
	        {
		        _q_item_desc_use_yn = ( value==null ? "" : value );
	        }
        }

        public string Q_Tgt_Pos_Biz_Use_YN
        {
	        get 
	        {
		        return _q_tgt_pos_biz_use_yn;
	        }
	        set
	        {
		        _q_tgt_pos_biz_use_yn = ( value==null ? "" : value );
	        }
        }

        public string All_Step_Visible_YN
		{
			get
			{
				return _all_step_visible_yn;
			}
			set
			{
				_all_step_visible_yn = ( value==null ? "" : value );
			}
		}

        public string Emp_Com_Dept_YN
		{
			get
			{
				return _emp_com_dept_yn;
			}
			set
			{
				_emp_com_dept_yn = ( value==null ? "" : value );
			}
		}

        public string Bias_Type_ID
        {
	        get 
	        {
		        return _bias_type_id;
	        }
	        set
	        {
		        _bias_type_id = ( value==null ? "" : value );
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

        public string Visible_Past_Point_YN
        {
            get
            {
                return _visible_past_point_yn;
            }
            set
            {
                _visible_past_point_yn = ( value == null ? "" : value );
            }
        }

        public string Est_Qtt_Mbo_YN
        {
            get
            {
                return _est_qtt_mbo_yn;
            }
            set
            {
                _est_qtt_mbo_yn = (value == null ? "" : value);
            }
        }

        public string Mbo_Score_Estimate_YN
        {
            get
            {
                return _mbo_score_estimate_yn;
            }
            set
            {
                _mbo_score_estimate_yn = (value == null ? "" : value);
            }
        }

        public string DashBoard_TYPE
        {
            get
            {
                return _dashboard_type;
            }
            set
            {
                _dashboard_type = (value == null ? "N" : value);
            }
        }

        public string Question_Previous_Step_YN
        {
            get
            {
                return _question_previous_step_yn;
            }
            set
            {
                _question_previous_step_yn = (value == null ? "N" : value);
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
        
        public Biz_EstInfos()
        {
        }
         
        public Biz_EstInfos(int comp_id, string est_id)
        {
            DataSet ds = GetEstInfo(comp_id, est_id);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32( dr["COMP_ID"]);
		        _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
		        _up_est_id          = dr["UP_EST_ID"];
		        _est_name           = (dr["EST_NAME"]           == DBNull.Value) ? "" : (string) dr["EST_NAME"];
		        _header_color       = (dr["HEADER_COLOR"]       == DBNull.Value) ? "" : (string) dr["HEADER_COLOR"];
		        _grade_confirm_yn   = (dr["GRADE_CONFIRM_YN"]   == DBNull.Value) ? "" : (string) dr["GRADE_CONFIRM_YN"];
		        _bias_yn            = (dr["BIAS_YN"]            == DBNull.Value) ? "" : (string) dr["BIAS_YN"];
                _bias_dept_use_yn   = (dr["BIAS_DEPT_USE_YN"]   == DBNull.Value) ? "" : (string) dr["BIAS_DEPT_USE_YN"];
                _tgt_opinion_yn     = (dr["TGT_OPINION_YN"]     == DBNull.Value) ? "" : (string) dr["TGT_OPINION_YN"];
                _feedback_yn        = (dr["FEEDBACK_YN"]        == DBNull.Value) ? "" : (string) dr["FEEDBACK_YN"];
		        _estterm_sub        = (dr["ESTTERM_SUB"]        == DBNull.Value) ? 0 : Convert.ToInt32( dr["ESTTERM_SUB"]);
		        _estterm_step       = (dr["ESTTERM_STEP"]       == DBNull.Value) ? 0 : Convert.ToInt32( dr["ESTTERM_STEP"]);
                _fixed_weight_use_yn= (dr["FIXED_WEIGHT_USE_YN"]== DBNull.Value) ? "N" : (string) dr["FIXED_WEIGHT_USE_YN"];
                _fixed_weight       = (dr["FIXED_WEIGHT"]       == DBNull.Value) ? 0 : DataTypeUtility.GetToDouble(dr["FIXED_WEIGHT"]);
		        _point_ctrl_step    = (dr["POINT_CTRL_STEP"]    == DBNull.Value) ? 0 : Convert.ToInt32( dr["POINT_CTRL_STEP"]);
		        _grade_ctrl_step    = (dr["GRADE_CTRL_STEP"]    == DBNull.Value) ? 0 : Convert.ToInt32( dr["GRADE_CTRL_STEP"]);
		        _owner_type         = (dr["OWNER_TYPE"]         == DBNull.Value) ? "" : (string) dr["OWNER_TYPE"];
                _est_style_id       = (dr["EST_STYLE_ID"]       == DBNull.Value) ? "" : (string) dr["EST_STYLE_ID"];
                _link_est_id        = (dr["LINK_EST_ID"]        == DBNull.Value) ? "" : (string) dr["LINK_EST_ID"];
                _weight_type        = (dr["WEIGHT_TYPE"]        == DBNull.Value) ? "" : (string) dr["WEIGHT_TYPE"];
                _scale_type         = (dr["SCALE_TYPE"]         == DBNull.Value) ? "" : (string) dr["SCALE_TYPE"];
                _status_style_id    = (dr["STATUS_STYLE_ID"]    == DBNull.Value) ? "" : (string) dr["STATUS_STYLE_ID"];
                _q_style_id         = (dr["Q_STYLE_ID"]         == DBNull.Value) ? "" : (string) dr["Q_STYLE_ID"];
                _q_item_desc_use_yn = (dr["Q_ITEM_DESC_USE_YN"] == DBNull.Value) ? "N" : (string) dr["Q_ITEM_DESC_USE_YN"];
                _q_tgt_pos_biz_use_yn = (dr["Q_TGT_POS_BIZ_USE_YN"] == DBNull.Value) ? "N" : (string) dr["Q_TGT_POS_BIZ_USE_YN"];
                _all_step_visible_yn = (dr["ALL_STEP_VISIBLE_YN"] == DBNull.Value) ? "N" : (string) dr["ALL_STEP_VISIBLE_YN"];
                _emp_com_dept_yn    = (dr["EMP_COM_DEPT_YN"]    == DBNull.Value) ? "N" : (string) dr["EMP_COM_DEPT_YN"];
                _bias_type_id       = (dr["BIAS_TYPE_ID"]       == DBNull.Value) ? "" : (string) dr["BIAS_TYPE_ID"];
		        _use_yn             = (dr["USE_YN"]             == DBNull.Value) ? "" : (string) dr["USE_YN"];
                _visible_past_point_yn = (dr["VISIBLE_PAST_POINT_YN"] == DBNull.Value) ? "Y" : (string)dr["VISIBLE_PAST_POINT_YN"];
                _est_qtt_mbo_yn     = (dr["EST_QTT_MBO_YN"] == DBNull.Value) ? "N" : (string)dr["EST_QTT_MBO_YN"];
                _dashboard_type       = (dr["DASHBOARD_TYPE"] == DBNull.Value) ? "N" : (string)dr["DASHBOARD_TYPE"];
                _question_previous_step_yn = (dr["Q_PREVIOUS_STEP_VISIBLE_YN"] == DBNull.Value) ? "N" : (string)dr["Q_PREVIOUS_STEP_VISIBLE_YN"];
		        _create_date        = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _create_user        = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32( dr["CREATE_USER"]);
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32( dr["UPDATE_USER"]);
                _mbo_score_estimate_yn = (dr["MBO_SCORE_ESTIMATE_YN"] == DBNull.Value) ? "N" : (string)dr["MBO_SCORE_ESTIMATE_YN"];
	        }
        }
         
        public bool ModifyEstInfo(    int comp_id
                                    , string est_id
                                    , object up_est_id
                                    , string est_name
                                    , string header_color
                                    , string grade_confirm_yn
                                    , string bias_yn
                                    , string bias_dept_use_yn
                                    , string tgt_opinion_yn
                                    , string feedback_yn
                                    , int estterm_sub
                                    , int estterm_step
                                    , string fixed_weight_use_yn
                                    , double fixed_weight
                                    , int point_ctrl_step
                                    , int grade_ctrl_step
                                    , string owner_type
                                    , string est_style_id
                                    , string link_est_id
                                    , string weight_type
                                    , string scale_type
                                    , string status_style_id
                                    , string q_style_id
                                    , string q_item_desc_use_yn
                                    , string q_tgt_pos_biz_use_yn
                                    , string all_step_visible_yn
                                    , string emp_com_dept_yn
                                    , string bias_type_id
                                    , string use_yn
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _estInfo.Update(null
                                        , null
                                        , comp_id
                                        , est_id
                                        , (up_est_id.Equals("")) ? DBNull.Value : up_est_id
                                        , est_name
                                        , header_color
                                        , grade_confirm_yn
                                        , bias_yn
                                        , bias_dept_use_yn
                                        , tgt_opinion_yn
                                        , feedback_yn
                                        , estterm_sub
                                        , estterm_step
                                        , fixed_weight_use_yn
                                        , fixed_weight
                                        , point_ctrl_step
                                        , grade_ctrl_step
                                        , owner_type
                                        , est_style_id
                                        , link_est_id
                                        , weight_type
                                        , scale_type
                                        , status_style_id
                                        , q_style_id
                                        , q_item_desc_use_yn
                                        , q_tgt_pos_biz_use_yn
                                        , all_step_visible_yn
                                        , emp_com_dept_yn
                                        , bias_type_id
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value
                                        , DBNull.Value
                                        , use_yn
                                        , update_date
                                        , update_user );

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool ModifyEstInfoModifyMaps(  int comp_id
                                            , string est_id
                                            , object up_est_id
                                            , string est_name
                                            , string header_color
                                            , string grade_confirm_yn
                                            , string bias_yn
                                            , string bias_dept_use_yn
                                            , string tgt_opinion_yn
                                            , string feedback_yn
                                            , int estterm_sub
                                            , int estterm_step
                                            , string fixed_weight_use_yn
                                            , double fixed_weight
                                            , int point_ctrl_step
                                            , int grade_ctrl_step
                                            , string owner_type
                                            , string est_style_id
                                            , string link_est_id
                                            , string weight_type
                                            , string scale_type
                                            , string status_style_id
                                            , string q_style_id
                                            , string q_item_desc_use_yn
                                            , string q_tgt_pos_biz_use_yn
                                            , string all_step_visible_yn
                                            , string emp_com_dept_yn
                                            , string bias_type_id
                                            , string visible_past_point_yn
                                            , string est_qtt_mbo_yn
                                            , string mbo_score_estimate_yn
                                            , string dashboard_type
                                            , string question_previous_step_yn
                                            , string use_yn
                                            , DateTime update_date
                                            , int update_user)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			Biz_TermSubEstMaps termSubEstMaps   = new Biz_TermSubEstMaps();
			Biz_TermStepEstMaps termStepEstMaps = new Biz_TermStepEstMaps();

			int affectedRow = 0;

			try
			{
				affectedRow = _estInfo.Update( conn
											, trx
                                            , comp_id
											, est_id
											, ( up_est_id.Equals( "" ) ) ? DBNull.Value : up_est_id
											, est_name
											, header_color
											, grade_confirm_yn
											, bias_yn
                                            , bias_dept_use_yn
                                            , tgt_opinion_yn
                                            , feedback_yn
											, estterm_sub
											, estterm_step
                                            , fixed_weight_use_yn
                                            , fixed_weight
											, point_ctrl_step
											, grade_ctrl_step
											, owner_type
											, est_style_id
                                            , link_est_id
											, weight_type
                                            , scale_type
                                            , status_style_id
                                            , q_style_id
                                            , q_item_desc_use_yn
                                            , q_tgt_pos_biz_use_yn
                                            , all_step_visible_yn
                                            , emp_com_dept_yn
                                            , bias_type_id
                                            , visible_past_point_yn
                                            , est_qtt_mbo_yn
                                            , mbo_score_estimate_yn
                                            , dashboard_type
                                            , question_previous_step_yn
											, use_yn
											, update_date
											, update_user );

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

        public DataSet GetEstInfos(int comp_id)
        {
	        return _estInfo.Select(comp_id, "");
        }        
 
        public DataSet GetEstInfo(int comp_id, string est_id )
        {
	        return _estInfo.Select(comp_id, est_id);
        }

        public DataSet GetDashBoardEst(int comp_id)
        {
            return _estInfo.SelectDashBoardEst(comp_id);
        }

        public DataSet GetEstInfoByUpEstID(int comp_id, string up_est_id )
        {
	        return _estInfo.SelectByUpEstID(comp_id, up_est_id);
        }
         
        public bool AddEstInfo(   int comp_id
                                , string est_id
                                , object up_est_id
                                , string est_name
                                , string header_color
                                , string grade_confirm_yn
                                , string bias_yn
                                , string bias_dept_use_yn
                                , string tgt_opinion_yn
                                , string feedback_yn
                                , int estterm_sub
                                , int estterm_step
                                , string fixed_weight_use_yn
                                , double fixed_weight
                                , int point_ctrl_step
                                , int grade_ctrl_step
                                , string owner_type
                                , string est_style_id
                                , string link_est_id
                                , string weight_type
                                , string scale_type
                                , string status_style_id
                                , string q_style_id
                                , string q_item_desc_use_yn
                                , string q_tgt_pos_biz_use_yn
                                , string all_step_visible_yn
                                , string emp_com_dept_yn
                                , string bias_type_id
                                , string use_yn
                                , DateTime create_date
                                , int create_user )
        {
	        int affectedRow = 0;

            affectedRow = _estInfo.Insert(null
                                        , null
                                        , comp_id
                                        , est_id
                                        , (up_est_id.Equals("")) ? DBNull.Value : up_est_id
                                        , est_name
                                        , header_color
                                        , grade_confirm_yn
                                        , bias_yn
                                        , bias_dept_use_yn
                                        , tgt_opinion_yn
                                        , feedback_yn
                                        , estterm_sub
                                        , estterm_step
                                        , fixed_weight_use_yn
                                        , fixed_weight
                                        , point_ctrl_step
                                        , grade_ctrl_step
                                        , owner_type
                                        , est_style_id
                                        , link_est_id
                                        , weight_type
                                        , scale_type
                                        , status_style_id
                                        , q_style_id
                                        , q_item_desc_use_yn
                                        , q_tgt_pos_biz_use_yn
                                        , all_step_visible_yn
                                        , emp_com_dept_yn
                                        , bias_type_id
                                        , "Y"
                                        , "N"
                                        , "N"
                                        , "N"
                                        , "N"
                                        , use_yn
                                        , create_date
                                        , create_user );

            return ( affectedRow > 0 ) ? true : false;
        }

		public bool AddEstInfoAddMaps(int comp_id
                                    , string est_id
								    , object up_est_id
								    , string est_name
								    , string header_color
								    , string grade_confirm_yn
								    , string bias_yn
                                    , string bias_dept_use_yn
                                    , string tgt_opinion_yn
                                    , string feedback_yn
								    , int estterm_sub
								    , int estterm_step
                                    , string fixed_weight_use_yn
                                    , double fixed_weight
								    , int point_ctrl_step
								    , int grade_ctrl_step
								    , string owner_type
								    , string est_style_id
                                    , string link_est_id
                                    , string weight_type
                                    , string scale_type
                                    , string status_style_id
                                    , string q_style_id
                                    , string q_item_desc_use_yn
                                    , string q_tgt_pos_biz_use_yn
                                    , string all_step_visible_yn
                                    , string emp_com_dept_yn
                                    , string bias_type_id
                                    , string visible_past_point_yn
                                    , string est_qtt_mbo_yn
                                    , string mbo_score_estimate_yn
                                    , string dashboard_type
                                    , string question_previous_step_yn
								    , string use_yn
								    , DateTime create_date
								    , int create_user)
		{
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			Biz_TermSubEstMaps termSubEstMaps   = new Biz_TermSubEstMaps();
			Biz_TermStepEstMaps termStepEstMaps = new Biz_TermStepEstMaps();

			int affectedRow = 0;

			try
			{
				affectedRow = _estInfo.Insert(conn
											, trx
                                            , comp_id
											, est_id
											, (up_est_id.Equals("")) ? DBNull.Value : up_est_id
											, est_name
											, header_color
											, grade_confirm_yn
											, bias_yn
                                            , bias_dept_use_yn
                                            , tgt_opinion_yn
                                            , feedback_yn
											, estterm_sub
											, estterm_step
                                            , fixed_weight_use_yn
                                            , fixed_weight
											, point_ctrl_step
											, grade_ctrl_step
											, owner_type
											, est_style_id
                                            , link_est_id
                                            , weight_type
                                            , scale_type
                                            , status_style_id
                                            , q_style_id
                                            , q_item_desc_use_yn
                                            , q_tgt_pos_biz_use_yn
                                            , all_step_visible_yn
                                            , emp_com_dept_yn
                                            , bias_type_id
                                            , visible_past_point_yn
                                            , est_qtt_mbo_yn
                                            , mbo_score_estimate_yn
                                            , dashboard_type
                                            , question_previous_step_yn
											, use_yn
											, create_date
											, create_user
											);

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

        public bool RemoveEstInfo(int comp_id, string est_id )
        {
	        int affectedRow = 0;

            affectedRow = _estInfo.Delete(null, null, comp_id, est_id);

            return ( affectedRow > 0 ) ? true : false;
        }

		public bool RemoveEstInfoRemoveMaps(int comp_id, string est_id)
		{
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			Dac_TermSubEstMaps termSubEstMaps   = new Dac_TermSubEstMaps();
			Dac_TermStepEstMaps termStepEstMaps = new Dac_TermStepEstMaps();

	        int affectedRow = 0;

			try
			{
				affectedRow = _estInfo.Delete(conn, trx, comp_id, est_id);

				int affectedRowSub = termSubEstMaps.Delete(conn, trx, comp_id, est_id, 0);

				if ( affectedRowSub > 0 )
					affectedRow += 1;

				int affectedRowStep = termStepEstMaps.Delete(conn, trx, comp_id, est_id, 0);

				if ( affectedRowStep > 0 )
					affectedRow += 1;

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

		public bool IsExists(int comp_id, string est_id )
		{
			int affectedRow = 0;

			affectedRow = _estInfo.Count(comp_id, est_id);

			return ( affectedRow > 0 ) ? true : false;
		}
    }
}
