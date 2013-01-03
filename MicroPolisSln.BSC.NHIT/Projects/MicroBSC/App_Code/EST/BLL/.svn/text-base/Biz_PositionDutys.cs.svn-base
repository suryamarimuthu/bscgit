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
    public class Biz_PositionDutys
    {
        #region ============================== [Fields] ==============================

        private string _pos_dut_id;
        private string _pos_dut_name;
        private DateTime _update_date;
        private int _update_user;

        private Dac_PositionDutys _positionDuty = new Dac_PositionDutys();

        #endregion

        #region ============================== [Properties] ==============================

        public string Pos_Dut_ID
        {
            get
            {
                return _pos_dut_id;
            }
            set
            {
                _pos_dut_id = (value == null ? "" : value);
            }
        }

        public string Pos_Dut_Name
        {
            get
            {
                return _pos_dut_name;
            }
            set
            {
                _pos_dut_name = (value == null ? "" : value);
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

        public Biz_PositionDutys()
        {

        }

        public Biz_PositionDutys(string pos_dut_id)
        {
            DataSet ds = _positionDuty.Select(pos_dut_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _pos_dut_id     = (dr["POS_DUT_ID"]     == DBNull.Value) ? "" : (string)dr["POS_DUT_ID"];
                _pos_dut_name   = (dr["POS_DUT_NAME"]   == DBNull.Value) ? "" : (string)dr["POS_DUT_NAME"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyPositionDuty(string pos_dut_id
                                    , string pos_dut_name
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _positionDuty.Update(  null
                                               , null
                                               , pos_dut_id
                                               , pos_dut_name
                                               , update_date
                                               , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPositionDuty(string pos_dut_id)
        {
            return _positionDuty.Select(pos_dut_id);
        }

        public DataSet GetPositionDuties()
        {
            return _positionDuty.Select("");
        }

        public bool AddPositionDuty(string pos_dut_id
                                    , string pos_dut_name
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _positionDuty.Insert(   null
                                                , null
                                                , pos_dut_id
                                                , pos_dut_name
                                                , create_date
                                                , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemovePositionDuty(string pos_dut_id)
        {
            int affectedRow = 0;

            affectedRow = _positionDuty.Delete(null, null, pos_dut_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}