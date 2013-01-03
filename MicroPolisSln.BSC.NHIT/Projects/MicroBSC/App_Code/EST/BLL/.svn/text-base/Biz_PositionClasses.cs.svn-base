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
    public class Biz_PositionClasses
    {
        #region ============================== [Fields] ==============================

        private string _pos_cls_id;
        private string _pos_cls_name;
        private DateTime _update_date;
        private int _update_user;

        private Dac_PositionClasses _positionClass = new Dac_PositionClasses();

        #endregion

        #region ============================== [Properties] ==============================

        public string Pos_Cls_ID
        {
            get
            {
                return _pos_cls_id;
            }
            set
            {
                _pos_cls_id = (value == null ? "" : value);
            }
        }

        public string Pos_Cls_Name
        {
            get
            {
                return _pos_cls_name;
            }
            set
            {
                _pos_cls_name = (value == null ? "" : value);
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


        public Biz_PositionClasses()
        {

        }

        public Biz_PositionClasses(string pos_cls_id)
        {
            DataSet ds = _positionClass.Select(pos_cls_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _pos_cls_id     = (dr["POS_CLS_ID"]     == DBNull.Value) ? "" : (string)dr["POS_CLS_ID"];
                _pos_cls_name   = (dr["POS_CLS_NAME"]   == DBNull.Value) ? "" : (string)dr["POS_CLS_NAME"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyPositionClass(string pos_cls_id
                                        , string pos_cls_name
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _positionClass.Update(  null
                                                , null
                                                , pos_cls_id
                                                , pos_cls_name
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPositionClasses()
        {
            return _positionClass.Select("");
        }

        public DataSet GetPositionClass(string pos_cls_id)
        {
            return _positionClass.Select(pos_cls_id);
        }

        public bool AddPositionClass(string pos_cls_id
                                    , string pos_cls_name
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _positionClass.Insert(  null
                                                , null
                                                , pos_cls_id
                                                , pos_cls_name
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemovePositionClass(string pos_cls_id)
        {
            int affectedRow = 0;

            affectedRow = _positionClass.Delete(null, null, pos_cls_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}