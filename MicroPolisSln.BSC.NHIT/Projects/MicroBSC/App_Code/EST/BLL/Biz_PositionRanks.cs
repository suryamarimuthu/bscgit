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
    public class Biz_PositionRanks
    {
        #region ============================== [Fields] ==============================

        private string _pos_rnk_id;
        private string _pos_rnk_name;
        private DateTime _update_date;
        private int _update_user;

        private Dac_PositionRanks _positionRank = new Dac_PositionRanks();
        #endregion

        #region ============================== [Properties] ==============================

        public string Pos_Rnk_ID
        {
            get
            {
                return _pos_rnk_id;
            }
            set
            {
                _pos_rnk_id = (value == null ? "" : value);
            }
        }

        public string Pos_Rnk_Name
        {
            get
            {
                return _pos_rnk_name;
            }
            set
            {
                _pos_rnk_name = (value == null ? "" : value);
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

        public Biz_PositionRanks()
        {

        }

        public Biz_PositionRanks(string pos_rnk_id)
        {
            DataSet ds = _positionRank.Select(pos_rnk_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _pos_rnk_id     = (dr["POS_RNK_ID"]     == DBNull.Value) ? "" : (string)dr["POS_RNK_ID"];
                _pos_rnk_name   = (dr["POS_RNK_NAME"]   == DBNull.Value) ? "" : (string)dr["POS_RNK_NAME"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyPositionRank(string pos_rnk_id
                                        , string pos_rnk_name
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _positionRank.Update(null
                                            , null
                                            , pos_rnk_id
                                            , pos_rnk_name
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPositionRanks()
        {
            return _positionRank.Select(""); 
        }

        public DataSet GetPositionRank(string pos_rnk_id)
        {
            return _positionRank.Select(pos_rnk_id); 
        }

        public bool AddPositionRank(string pos_rnk_id
                                    , string pos_rnk_name
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _positionRank.Update(null
                                            , null
                                            , pos_rnk_id
                                            , pos_rnk_name
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemovePositionRank(string pos_rnk_id)
        {
            int affectedRow = 0;

            affectedRow = _positionRank.Delete(null, null, pos_rnk_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
