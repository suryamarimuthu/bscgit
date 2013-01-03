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
    public class Biz_PositionGroups
    {
        #region ============================== [Fields] ==============================

        private string _pos_grp_id;
        private string _pos_grp_name;
        private DateTime _update_date;
        private int _update_user;

        private Dac_PositionGroups _positionGroup = new Dac_PositionGroups();

        #endregion

        #region ============================== [Properties] ==============================

        public string Pos_Grp_ID
        {
            get
            {
                return _pos_grp_id;
            }
            set
            {
                _pos_grp_id = (value == null ? "" : value);
            }
        }

        public string Pos_Grp_Name
        {
            get
            {
                return _pos_grp_name;
            }
            set
            {
                _pos_grp_name = (value == null ? "" : value);
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

        public Biz_PositionGroups()
        {

        }
        public Biz_PositionGroups(string pos_grp_id)
        {
            DataSet ds = _positionGroup.Select(pos_grp_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _pos_grp_id     = (dr["POS_GRP_ID"]     == DBNull.Value) ? "" : (string)dr["POS_GRP_ID"];
                _pos_grp_name   = (dr["POS_GRP_NAME"]   == DBNull.Value) ? "" : (string)dr["POS_GRP_NAME"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyPositionGroup(string pos_grp_id
                                        , string pos_grp_name
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _positionGroup.Update( null
                                               , null
                                               , pos_grp_id
                                               , pos_grp_name
                                               , update_date
                                               , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPositionGroups()
        {
            return _positionGroup.Select("");
        }

        public DataSet GetPositionGroup(string pos_grp_id)
        {
            return _positionGroup.Select(pos_grp_id);
        }

        public bool AddPositionGroup(string pos_grp_id
                                    , string pos_grp_name
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _positionGroup.Insert( null
                                               , null
                                               , pos_grp_id
                                               , pos_grp_name
                                               , create_date
                                               , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemovePositionGroup(string pos_grp_id)
        {
            int affectedRow = 0;

            affectedRow = _positionGroup.Delete(null, null, pos_grp_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
