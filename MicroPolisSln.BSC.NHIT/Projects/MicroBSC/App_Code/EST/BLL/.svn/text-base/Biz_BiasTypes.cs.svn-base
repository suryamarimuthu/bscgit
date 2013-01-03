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
    public class Biz_BiasTypes
    {
        #region ============================== [Fields] ==============================

        private string _bias_type_id;
        private string _bias_type_name;
        private DateTime _update_date;
        private int _update_user;

        private Dac_BiasTypes _biasType = new Dac_BiasTypes();

        #endregion

        #region ============================== [Properties] ==============================

        public string Bias_Type_ID
        {
            get
            {
                return _bias_type_id;
            }
            set
            {
                _bias_type_id = (value == null ? "" : value);
            }
        }

        public string Bias_Type_Name
        {
            get
            {
                return _bias_type_name;
            }
            set
            {
                _bias_type_name = (value == null ? "" : value);
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

        public Biz_BiasTypes()
        {

        }

        public Biz_BiasTypes(string bias_type_id)
        {
            DataSet ds = _biasType.Select(bias_type_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _bias_type_id   = (dr["BIAS_TYPE_ID"]   == DBNull.Value) ? "" : (string)dr["BIAS_TYPE_ID"];
                _bias_type_name = (dr["BIAS_TYPE_NAME"] == DBNull.Value) ? "" : (string)dr["BIAS_TYPE_NAME"];
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }
     
        public bool ModifyBiasType(string bias_type_id
                                    , string bias_type_name
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _biasType.Update(null
                                            , null
                                            , bias_type_id
                                            , bias_type_name
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetBiasTypes()
        {
            return _biasType.Select("");
        }

        public DataSet GetBiasType(string bias_type_id)
        {
            return _biasType.Select(bias_type_id);
        }

        public bool AddBiasType(string bias_type_id
                                , string bias_type_name
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _biasType.Insert(null
                                            , null
                                            , bias_type_id
                                            , bias_type_name
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveBiasType(string bias_type_id)
        {
            int affectedRow = 0;

            affectedRow = _biasType.Delete(null, null, bias_type_id);

            return (affectedRow > 0) ? true : false;
        }


        public bool IsExist(string bias_type_id)
        {
            int affectedRow = 0;

            affectedRow = _biasType.Count(bias_type_id);

            if (affectedRow > 0)
                return true;

            return false;
        }
    }
}
