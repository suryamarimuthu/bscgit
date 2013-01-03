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
    public class Biz_ScaleInfos
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private string _scale_id;
        private string _scale_name;
        private string _use_yn;
        private DateTime _update_date;
        private int _update_user;
        private Dac_ScaleInfos _scaleInfo = new Dac_ScaleInfos();

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

        public string Scale_Name
        {
            get
            {
                return _scale_name;
            }
            set
            {
                _scale_name = (value == null ? "" : value);
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
                _use_yn = (value == null ? "" : value);
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

        public Biz_ScaleInfos()
        {

        }

        public Biz_ScaleInfos(int comp_id, string scale_id)
        {
            DataSet ds = _scaleInfo.Select(comp_id, scale_id, "");
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr          = ds.Tables[0].Rows[0];

                _comp_id     = (dr["COMP_ID"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _scale_id    = (dr["SCALE_ID"]      == DBNull.Value) ? "" : (string)dr["SCALE_ID"];
                _scale_name  = (dr["SCALE_NAME"]    == DBNull.Value) ? "" : (string)dr["SCALE_NAME"];
                _use_yn      = (dr["USE_YN"]        == DBNull.Value) ? "" : (string)dr["USE_YN"];
                _update_date = (dr["UPDATE_DATE"]   == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user = (dr["UPDATE_USER"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyScaleInfo(  int comp_id
                                    , string scale_id
                                    , string scale_name
                                    , string use_yn
                                    , DateTime update_date
                                    , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _scaleInfo.Update(  null
                                            , null
                                            , comp_id
                                            , scale_id
                                            , scale_name
                                            , use_yn
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetScaleInfos(int comp_id)
        {
            return _scaleInfo.Select(comp_id, "", "Y");
        }

        public DataSet GetScaleInfo(int comp_id, string scale_id, string use_yn)
        {
            return _scaleInfo.Select(comp_id, scale_id, use_yn);
        }

        public bool AddScaleInfo( int comp_id
                                , string scale_id
                                , string scale_name
                                , string use_yn
                                , DateTime create_date
                                , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _scaleInfo.Insert(  null
                                            , null
                                            , comp_id
                                            , scale_id
                                            , scale_name
                                            , use_yn
                                            , create_date
                                            , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveScaleInfo(int comp_id, string scale_id)
        {
            int affectedRow = 0;

            affectedRow = _scaleInfo.Delete(null, null, comp_id, scale_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(int comp_id, string scale_id)
        {
            int affectedRow = 0;

            affectedRow = _scaleInfo.Count(comp_id, scale_id);

            return (affectedRow > 0) ? true : false;
        }
    }
}
