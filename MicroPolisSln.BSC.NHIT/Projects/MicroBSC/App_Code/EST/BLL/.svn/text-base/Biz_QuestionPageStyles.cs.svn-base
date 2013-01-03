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
    public class Biz_QuestionPageStyles
    {
        #region ============================== [Fields] ====================

        private string _q_style_id;
        private string _q_style_name;
        private string _q_style_desc;
        private string _q_style_page_name;
        private int _sort_order;
        private DateTime _create_date;
        private int _create_user;
        private DateTime _update_date;
        private int _update_user;

        private Dac_QuestionPageStyles _dac_q_styles = new Dac_QuestionPageStyles();

        #endregion

        #region ============================== [Properties] =================

        public string Question_Style_ID
        {
            get
            {
                return _q_style_id;
            }
            set
            {
                _q_style_id = (value == null ? "" : value);
            }
        }

        public string Question_Style_Name
        {
            get
            {
                return _q_style_name;
            }
            set
            {
                _q_style_name = (value == null ? "" : value);
            }
        }

        public string Question_Style_Desc
        {
            get
            {
                return _q_style_desc;
            }
            set
            {
                _q_style_desc = (value == null ? "" : value);
            }
        }

        public string Question_Style_Page_Name
        {
            get
            {
                return _q_style_page_name;
            }
            set
            {
                _q_style_page_name = (value == null ? "" : value);
            }
        }

        public int Sort_Order
        {
            get
            {
                return _sort_order;
            }
            set
            {
                _sort_order = value;
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

        public Biz_QuestionPageStyles()
        {

        }

        public Biz_QuestionPageStyles(string q_style_id)
        {
            DataSet ds = _dac_q_styles.Select(q_style_id);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr;

                dr                  = ds.Tables[0].Rows[0];
                _q_style_id         = (dr["Q_STYLE_ID"]         == DBNull.Value) ? "" : (string)dr["Q_STYLE_ID"];
                _q_style_name       = (dr["Q_STYLE_NAME"]       == DBNull.Value) ? "" : (string)dr["Q_STYLE_NAME"];
                _q_style_desc       = (dr["Q_STYLE_DESC"]       == DBNull.Value) ? "" : (string)dr["Q_STYLE_DESC"];
                _q_style_page_name  = (dr["Q_STYLE_PAGE_NAME"]  == DBNull.Value) ? "" : (string)dr["Q_STYLE_PAGE_NAME"];
                _sort_order         = (dr["SORT_ORDER"]         == DBNull.Value) ? 1 : Convert.ToInt32(dr["SORT_ORDER"]);
                _create_date        = (dr["CREATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["CREATE_DATE"];
                _create_user        = (dr["CREATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _update_date        = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user        = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }


        public bool IsExist(string q_style_id)
        {
            int intCount = _dac_q_styles.Count(q_style_id);

            return (intCount > 0) ? true : false;
        }

        public bool ModifyQuestionPageStyle(  string q_style_id
                                            , string q_style_name
                                            , string q_style_desc
                                            , string q_style_page_name
                                            , DateTime update_date
                                            , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _dac_q_styles.Update(null
                                            , null
                                            , q_style_id
                                            , q_style_name
                                            , q_style_desc
                                            , q_style_page_name
                                            , update_date
                                            , update_user);

            if (affectedRow > 0)
                return true;

            return false;
        }


        public DataSet GetQuestionPageStyles()
        {
            DataSet ds = _dac_q_styles.Select("");
            return ds;
        }

        public bool AddQuestionPageStyle( string q_style_id
                                        , string q_style_name
                                        , string q_style_desc
                                        , string q_style_page_name
                                        , DateTime create_date
                                        , int create_user)
        {
            int affectedRow = 0;

            if (IsExist(q_style_id) == false)
            {
                affectedRow = _dac_q_styles.Insert(null
                                                , null
                                                , q_style_id
                                                , q_style_name
                                                , q_style_desc
                                                , q_style_page_name
                                                , create_date
                                                , create_user);
            }

            if (affectedRow > 0)
                return true;

            return false;
        }

        public bool RemoveQuestionPageStyle(string q_style_id)
        {
            int affectedRow = 0;

            affectedRow = _dac_q_styles.Delete(null, null, q_style_id);

            if (affectedRow > 0)
                return true;

            return false;
        }
    }
}