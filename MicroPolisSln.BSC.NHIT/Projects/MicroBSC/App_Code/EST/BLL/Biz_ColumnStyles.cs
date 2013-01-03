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
    public class Biz_ColumnStyles
    {
        #region ============================== [Fields] ==============================

        private string _col_style_id;
        private string _col_style_name;
        private DateTime _update_date;
        private int _update_user;

        private Dac_ColumnStyles _columnStyle = new Dac_ColumnStyles();

        #endregion

        #region ============================== [Properties] ==============================

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

        public string Col_Style_Name
        {
            get
            {
                return _col_style_name;
            }
            set
            {
                _col_style_name = (value == null ? "" : value);
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

        public Biz_ColumnStyles()
        {

        }

        public Biz_ColumnStyles(string col_style_id)
        {
            DataSet ds = _columnStyle.Select(col_style_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _col_style_id   = (dr["COL_STYLE_ID"]   == DBNull.Value) ? "" : (string)dr["COL_STYLE_ID"];
                _col_style_name = (dr["COL_STYLE_NAME"] == DBNull.Value) ? "" : (string)dr["COL_STYLE_NAME"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }
     
        public bool ModifyColumnStyle(string col_style_id
                                    , string col_style_name
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _columnStyle.Update(null
                                            , null
                                            , col_style_id
                                            , col_style_name
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetColumnStyles()
        {
            return _columnStyle.Select("");
        }



        public DataSet GetColumnStyle(string col_style_id)
        {
            return _columnStyle.Select(col_style_id);                                    }

        public bool AddColumnStyle(string col_style_id
                                , string col_style_name
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _columnStyle.Insert(null
                                            , null
                                            , col_style_id
                                            , col_style_name
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveColumnStyle(string col_style_id)
        {
            int affectedRow = 0;

            affectedRow = _columnStyle.Delete(null, null, col_style_id);

            return (affectedRow > 0) ? true : false;
        }


        public bool IsExist(string col_style_id)
        {
            int affectedRow = 0;

            affectedRow = _columnStyle.Count(col_style_id);

            if (affectedRow > 0)
                return true;

            return false;
        }
    }
}
