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
    public class Biz_EstDetails
    {
        #region ============================== [Fields] ==============================
 
        private int     _comp_id;
        private string 	_est_id;
        private int     _estterm_ref_id;
        private int     _estterm_sub_id;
        private int     _estterm_step_id;
        private string 	_est_name;
        private string 	_header_color;
        private string 	_grade_confirm_yn;
        private string 	_bias_yn;
        private int 	_estterm_sub;
        private int 	_estterm_step;
        private int 	_point_ctrl_step;
        private int 	_grade_ctrl_step;
        private string 	_owner_type;
        private string  _est_style_id;
        private string  _weight_type;
        private string  _status_style_id;
        private string  _q_style_id;
        private string  _bias_type_id;
        private string 	_use_yn;
        private DateTime 	_create_date;
        private int 	_create_user;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_EstDetails _estDetail = new Dac_EstDetails();

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

        public Biz_EstDetails()
        {
        }
         
        public Biz_EstDetails(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id)
        {
            DataSet ds = GetEstDetail(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];

                _comp_id            = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
		        _est_id             = (dr["EST_ID"]             == DBNull.Value) ? "" : (string) dr["EST_ID"];
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = (dr["ESTTERM_STEP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
		        _est_name           = (dr["EST_NAME"]           == DBNull.Value) ? "" : (string) dr["EST_NAME"];
		        _header_color       = (dr["HEADER_COLOR"]       == DBNull.Value) ? "" : (string) dr["HEADER_COLOR"];
		        _grade_confirm_yn   = (dr["GRADE_CONFIRM_YN"]   == DBNull.Value) ? "" : (string) dr["GRADE_CONFIRM_YN"];
		        _bias_yn            = (dr["BIAS_YN"]            == DBNull.Value) ? "" : (string) dr["BIAS_YN"];
		        _estterm_sub        = (dr["ESTTERM_SUB"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB"]);
		        _estterm_step       = (dr["ESTTERM_STEP"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP"]);
		        _point_ctrl_step    = (dr["POINT_CTRL_STEP"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["POINT_CTRL_STEP"]);
		        _grade_ctrl_step    = (dr["GRADE_CTRL_STEP"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["GRADE_CTRL_STEP"]);
		        _owner_type         = (dr["OWNER_TYPE"]         == DBNull.Value) ? "" : (string) dr["OWNER_TYPE"];
                _est_style_id       = (dr["EST_STYLE_ID"]       == DBNull.Value) ? "" : (string) dr["EST_STYLE_ID"];
                _weight_type        = (dr["WEIGHT_TYPE"]        == DBNull.Value) ? "" : (string) dr["WEIGHT_TYPE"];
                _status_style_id    = (dr["STATUS_STYLE_ID"]    == DBNull.Value) ? "" : (string) dr["STATUS_STYLE_ID"];
                _q_style_id         = (dr["Q_STYLE_ID"]         == DBNull.Value) ? "" : (string) dr["Q_STYLE_ID"];
                _bias_type_id       = (dr["BIAS_TYPE_ID"]       == DBNull.Value) ? "" : (string) dr["BIAS_TYPE_ID"];
		        _use_yn             = (dr["USE_YN"]             == DBNull.Value) ? "" : (string) dr["USE_YN"];
		        _create_date        = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["CREATE_DATE"];
		        _create_user        = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
		        _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime) dr["UPDATE_DATE"];
		        _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
	        }
            else 
            {
                _comp_id            = 0;
		        _est_id             = "";
                _estterm_ref_id     = 0;
                _estterm_sub_id     = 0;
                _estterm_step_id    = 0;
		        _est_name           = "";
		        _header_color       = "";
		        _grade_confirm_yn   = "";
		        _bias_yn            = "";
		        _estterm_sub        = 0;
		        _estterm_step       = 0;
		        _point_ctrl_step    = 0;
		        _grade_ctrl_step    = 0;
		        _owner_type         = "";
                _est_style_id       = "";
                _weight_type        = "";
                _status_style_id    = "";
                _q_style_id         = "";
                _bias_type_id       = "";
		        _use_yn             = "";
		        _create_date        = DateTime.MinValue;
		        _create_user        = 0;
		        _update_date        = DateTime.MinValue;
		        _update_user        = 0;
            }
        }
         
        public bool ModifyEstDetail(  int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string est_name
                                    , string header_color
                                    , string grade_confirm_yn
                                    , string bias_yn
                                    , int estterm_sub
                                    , int estterm_step
                                    , int point_ctrl_step
                                    , int grade_ctrl_step
                                    , string owner_type
                                    , string est_style_id
                                    , string weight_type
                                    , string status_style_id
                                    , string q_style_id
                                    , string bias_type_id
                                    , string use_yn
                                    , DateTime update_date
                                    , int update_user)
        {
	        int affectedRow = 0;

            affectedRow = _estDetail.Update(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_name
                                            , header_color
                                            , grade_confirm_yn
                                            , bias_yn
                                            , estterm_sub
                                            , estterm_step
                                            , point_ctrl_step
                                            , grade_ctrl_step
                                            , owner_type
                                            , est_style_id
                                            , weight_type
                                            , status_style_id
                                            , q_style_id
                                            , bias_type_id
                                            , use_yn
                                            , update_date
                                            , update_user );

            return ( affectedRow > 0 ) ? true : false;
        }

        public DataSet GetEstDetails(int comp_id)
        {
	        return _estDetail.Select(comp_id, "", 0, 0, 0);
        }        
 
        public DataSet GetEstDetail(int comp_id, string est_id )
        {
	        return _estDetail.Select(comp_id, est_id, 0, 0, 0);
        }

        public DataSet GetEstDetail(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id)
        {
	        return _estDetail.Select( comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id);
        }

        public bool AddEstDetail( int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string est_name
                                , string header_color
                                , string grade_confirm_yn
                                , string bias_yn
                                , int estterm_sub
                                , int estterm_step
                                , int point_ctrl_step
                                , int grade_ctrl_step
                                , string owner_type
                                , string est_style_id
                                , string weight_type
                                , string status_style_id
                                , string q_style_id
                                , string bias_type_id
                                , string use_yn
                                , DateTime create_date
                                , int create_user )
        {
	        int affectedRow = 0;

            affectedRow = _estDetail.Insert(  null
                                            , null
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_name
                                            , header_color
                                            , grade_confirm_yn
                                            , bias_yn
                                            , estterm_sub
                                            , estterm_step
                                            , point_ctrl_step
                                            , grade_ctrl_step
                                            , owner_type
                                            , est_style_id
                                            , weight_type
                                            , status_style_id
                                            , q_style_id
                                            , bias_type_id
                                            , use_yn
                                            , create_date
                                            , create_user );

            return ( affectedRow > 0 ) ? true : false;
        }

        // 평가, 평가기간별 OwnerType를 저장하는 메소드
        public bool SaveOwnerType(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string owner_type
                                , DateTime date
                                , int user )
        {
	        int affectedRow = 0;

            if(IsExists(comp_id
                    , est_id
                    , estterm_ref_id
                    , estterm_sub_id
                    , estterm_step_id)) 
            {
                affectedRow = _estDetail.Update(  null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , owner_type
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , date
                                                , user );
            }
            else 
            {
                affectedRow = _estDetail.Insert(  null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , owner_type
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , date
                                                , user );
            }

            return ( affectedRow > 0 ) ? true : false;
        }

        public bool RemoveEstDetail(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id)
        {
	        int affectedRow = 0;

            affectedRow = _estDetail.Delete(null
                                        , null
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id);

            return ( affectedRow > 0 ) ? true : false;
        }

		public bool IsExists(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id)
		{
			int affectedRow = 0;

			affectedRow = _estDetail.Count(null
                                        , null
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id);

			return ( affectedRow > 0 ) ? true : false;
		}
    }
}
