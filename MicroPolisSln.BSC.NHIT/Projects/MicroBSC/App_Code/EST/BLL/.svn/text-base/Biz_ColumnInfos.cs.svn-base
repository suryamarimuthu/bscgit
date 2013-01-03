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
    public class Biz_ColumnInfos
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private string _est_id;
        private int _seq;
        private string _col_name;
        private string _col_style_id;
        private string _col_key;
        private string _caption;
        private int _width;
        private string _data_type;
        private string _halign;
        private string _back_color;
        private string _format;
        private string _formula;
        private string _default_value;
        private string _col_desc;
        private string _back_color_yn;
        private string _format_yn;
        private string _formula_yn;
        private string _default_value_yn;
        private string _visible_yn;
        private string _col_emp_visible_yn;
        private DateTime _update_date;
        private int _update_user;

        private Dac_ColumnInfos _columnInfo = new Dac_ColumnInfos();

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
                _est_id = (value == null ? "" : value);
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

        public string Col_Name
        {
            get
            {
                return _col_name;
            }
            set
            {
                _col_name = (value == null ? "" : value);
            }
        }

        public string Col_Style_ID
        {
            get
            {
                return _col_style_id;
            }
            set
            {
                _col_style_id = (value == null ? "" : value);
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
                _col_key = (value == null ? "" : value);
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = (value == null ? "" : value);
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public string Data_Type
        {
            get
            {
                return _data_type;
            }
            set
            {
                _data_type = (value == null ? "" : value);
            }
        }

        public string Halign
        {
            get
            {
                return _halign;
            }
            set
            {
                _halign = (value == null ? "" : value);
            }
        }

        public string Back_Color
        {
            get
            {
                return _back_color;
            }
            set
            {
                _back_color = (value == null ? "" : value);
            }
        }

        public string Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = (value == null ? "" : value);
            }
        }

        public string Formula
        {
            get
            {
                return _formula;
            }
            set
            {
                _formula = (value == null ? "" : value);
            }
        }

        public string Default_Value
        {
            get
            {
                return _default_value;
            }
            set
            {
                _default_value = (value == null ? "" : value);
            }
        }

        public string Col_Desc
        {
            get
            {
                return _col_desc;
            }
            set
            {
                _col_desc = (value == null ? "" : value);
            }
        }

        public string Back_color_YN
        {
            get
            {
                return _back_color_yn;
            }
            set
            {
                _back_color_yn = (value == null ? "" : value);
            }
        }

        public string Format_YN
        {
            get
            {
                return _format_yn;
            }
            set
            {
                _format_yn = (value == null ? "" : value);
            }
        }

        public string Formula_YN
        {
            get
            {
                return _formula_yn;
            }
            set
            {
                _formula_yn = (value == null ? "" : value);
            }
        }

        public string Default_Value_YN
        {
            get
            {
                return _default_value_yn;
            }
            set
            {
                _default_value_yn = (value == null ? "" : value);
            }
        }

        public string Visible_YN
        {
            get
            {
                return _visible_yn;
            }
            set
            {
                _visible_yn = (value == null ? "" : value);
            }
        }

        public string Col_Emp_Visible_YN
        {
            get
            {
                return _col_emp_visible_yn;
            }
            set
            {
                _col_emp_visible_yn = (value == null ? "" : value);
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

         public Biz_ColumnInfos()
        {

        }

        public Biz_ColumnInfos(int comp_id, string est_id, string col_key)
        {
            DataSet ds = _columnInfo.Select(comp_id, est_id, col_key, "");
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                          = ds.Tables[0].Rows[0];
                _comp_id                    = (dr["COMP_ID"]                    == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _est_id                     = (dr["EST_ID"]                     == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _seq                        = (dr["SEQ"]                        == DBNull.Value) ? 0 : Convert.ToInt32(dr["SEQ"]);
                _col_name                   = (dr["COL_NAME"]                   == DBNull.Value) ? "" : (string)dr["COL_NAME"];
                _col_style_id               = (dr["COL_STYLE_ID"]               == DBNull.Value) ? "" : (string)dr["COL_STYLE_ID"];
                _col_key                    = (dr["COL_KEY"]                    == DBNull.Value) ? "" : (string)dr["COL_KEY"];
                _caption                    = (dr["CAPTION"]                    == DBNull.Value) ? "" : (string)dr["CAPTION"];
                _width                      = (dr["WIDTH"]                      == DBNull.Value) ? 0 : Convert.ToInt32(dr["WIDTH"]);
                _data_type                  = (dr["DATA_TYPE"]                  == DBNull.Value) ? "" : (string)dr["DATA_TYPE"];
                _halign                     = (dr["HALIGN"]                     == DBNull.Value) ? "" : (string)dr["HALIGN"];
                _back_color                 = (dr["BACK_COLOR"]                 == DBNull.Value) ? "" : (string)dr["BACK_COLOR"];
                _format                     = (dr["FORMAT"]                     == DBNull.Value) ? "" : (string)dr["FORMAT"];
                _formula                    = (dr["FORMULA"]                    == DBNull.Value) ? "" : (string)dr["FORMULA"];
                _default_value              = (dr["DEFAULT_VALUE"]              == DBNull.Value) ? "" : (string)dr["DEFAULT_VALUE"];
                _col_desc                   = (dr["COL_DESC"]                   == DBNull.Value) ? "" : (string)dr["COL_DESC"];
                _back_color_yn              = (dr["BACK_COLOR_YN"]              == DBNull.Value) ? "N" : (string)dr["BACK_COLOR_YN"];
                _format_yn                  = (dr["FORMAT_YN"]                  == DBNull.Value) ? "N" : (string)dr["FORMAT_YN"];
                _formula_yn                 = (dr["FORMULA_YN"]                 == DBNull.Value) ? "N" : (string)dr["FORMULA_YN"];
                _default_value_yn           = (dr["DEFAULT_VALUE_YN"]           == DBNull.Value) ? "N" : (string)dr["DEFAULT_VALUE_YN"];
                _visible_yn                 = (dr["VISIBLE_YN"]                 == DBNull.Value) ? "N" : (string)dr["VISIBLE_YN"];
                _col_emp_visible_yn         = (dr["COL_EMP_VISIBLE_YN"]         == DBNull.Value) ? "N" : (string)dr["COL_EMP_VISIBLE_YN"];
                _update_date                = (dr["UPDATE_DATE"]                == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user                = (dr["UPDATE_USER"]                == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyColumnInfo( int comp_id
                                    , string est_id
                                    , int seq
                                    , string col_name
                                    , string col_style_id
                                    , string col_key
                                    , string caption
                                    , int width
                                    , string data_type
                                    , string halign
                                    , string back_color
                                    , string format
                                    , string formula
                                    , string default_value
                                    , string col_desc
                                    , string back_color_yn
                                    , string format_yn
                                    , string formula_yn
                                    , string default_value_yn
                                    , string visible_yn
                                    , string col_emp_visible_yn
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _columnInfo.Update( null
                                            , null
                                            , comp_id
                                            , est_id
                                            , seq
                                            , col_name
                                            , col_style_id
                                            , col_key
                                            , caption
                                            , width
                                            , data_type
                                            , halign
                                            , back_color
                                            , format
                                            , formula
                                            , default_value
                                            , col_desc
                                            , back_color_yn
                                            , format_yn
                                            , formula_yn
                                            , default_value_yn
                                            , visible_yn
                                            , col_emp_visible_yn
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetColumnInfo(int comp_id, string est_id)
        {
            return _columnInfo.Select(comp_id, est_id, "", "");
        }

        public DataSet GetColumnInfo(int comp_id, string est_id, string col_key)
        {
            return _columnInfo.Select(comp_id, est_id, col_key, "");
        }

        public DataSet GetColumnInfo(int comp_id, string est_id, string col_key, string visible_yn)
        {
            return _columnInfo.Select(comp_id, est_id, col_key, visible_yn);
        }

        public bool AddColumnInfo(int comp_id
                                , string est_id
                                , int seq
                                , string col_name
                                , string col_style_id
                                , string col_key
                                , string caption
                                , int width
                                , string data_type
                                , string halign
                                , string back_color
                                , string format
                                , string formula
                                , string default_value
                                , string col_desc
                                , string back_color_yn
                                , string format_yn
                                , string formula_yn
                                , string default_value_yn
                                , string visible_yn
                                , string col_emp_visible_yn
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;
            affectedRow = _columnInfo.Insert( null
                                            , null
                                            , comp_id
                                            , est_id
                                            , seq
                                            , col_name
                                            , col_style_id
                                            , col_key
                                            , caption
                                            , width
                                            , data_type
                                            , halign
                                            , back_color
                                            , format
                                            , formula
                                            , default_value
                                            , col_desc
                                            , back_color_yn
                                            , format_yn
                                            , formula_yn
                                            , default_value_yn
                                            , visible_yn
                                            , col_emp_visible_yn
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveColumnInfo(int comp_id, string est_id, string col_key)
        {
            int affectedRow = 0;

            affectedRow = _columnInfo.Delete(null, null, comp_id, est_id, col_key);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(int comp_id, string est_id, string col_key)
        {
            int affectedRow = 0;

            affectedRow = _columnInfo.Count(comp_id, est_id, col_key);

            if (affectedRow > 0)
                return true;

            return false;
        }
    }
}