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
    public class Biz_ScopeUnits
    {
        #region ============================== [Fields] ==============================

        private string _scope_unit_id;
        private string _scale_id;
        private string _scope_unit_name;
        private string _scope_unit_desc;
        private DateTime _update_date;
        private int _update_user;

        private Dac_ScopeUnits _scopeUnit = new Dac_ScopeUnits();

        #endregion

        #region ============================== [Properties] ==============================

        public string Scope_Unit_ID
        {
            get
            {
                return _scope_unit_id;
            }
            set
            {
                _scope_unit_id = (value == null ? "" : value);
            }
        }

        public string Scale_ID
        {
            get
            {
                return _scale_id;
            }
            set
            {
                _scale_id = (value == null ? "" : value);
            }
        }

        public string Scope_Unit_Name
        {
            get
            {
                return _scope_unit_name;
            }
            set
            {
                _scope_unit_name = (value == null ? "" : value);
            }
        }

        public string Scope_Unit_Desc
        {
            get
            {
                return _scope_unit_desc;
            }
            set
            {
                _scope_unit_desc = (value == null ? "" : value);
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

        public Biz_ScopeUnits()
        {

        }

        public Biz_ScopeUnits(string scope_unit_id)
        {
            DataSet ds = _scopeUnit.Select(scope_unit_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];
                _scope_unit_id      = (dr["SCOPE_UNIT_ID"]   == DBNull.Value) ? "" : (string)dr["SCOPE_UNIT_ID"];
                _scale_id           = (dr["SCALE_ID"]        == DBNull.Value) ? "" : (string)dr["SCALE_ID"];
                _scope_unit_name    = (dr["SCOPE_UNIT_NAME"] == DBNull.Value) ? "" : (string)dr["SCOPE_UNIT_NAME"];
                _scope_unit_desc    = (dr["SCOPE_UNIT_DESC"] == DBNull.Value) ? "" : (string)dr["SCOPE_UNIT_DESC"];
                _update_date        = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user        = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyScopeUnit(string scope_unit_id
                                    , string scale_id
                                    , string scope_unit_name
                                    , string scope_unit_desc
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _scopeUnit.Update(  null
                                            , null
                                            , scope_unit_id
                                            , scale_id
                                            , scope_unit_name
                                            , scope_unit_desc
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetScopeUnit()
        {
           return _scopeUnit.Select( string.Empty );
        }

        public DataSet GetScopeUnit(string scope_unit_id)
        {
           return _scopeUnit.Select(scope_unit_id);
        }

        public string GetScopeUnitIDByScaleID(string scale_id)
        {
           DataSet ds = _scopeUnit.SelectByScaleID(scale_id);

            if(ds.Tables[0].Rows.Count > 0) 
            {
                return ds.Tables[0].Rows[0]["SCOPE_UNIT_ID"].ToString();
            }

            return "";
        }

        public bool AddScopeUnit(string scope_unit_id
                                , string scale_id
                                , string scope_unit_name
                                , string scope_unit_desc
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _scopeUnit.Insert( null
                                         , null
                                         , scope_unit_id
                                         , scale_id
                                         , scope_unit_name
                                         , scope_unit_desc
                                         , create_date
                                         , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveScopeUnit(string scope_unit_id)
        {
            int affectedRow = 0;

            affectedRow = _scopeUnit.Delete(null, null, scope_unit_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
