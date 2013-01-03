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
    public class Biz_QuestionEstMaps
    {
      

        #region ============================== [Fields] ==============================

        private string _est_id;
        private string _q_obj_id;
        private DateTime _update_date;
        private int _update_user;
        private Dac_QuestionEstMaps _questionestmap = new Dac_QuestionEstMaps();
        #endregion

        #region ============================== [Properties] ==============================

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

        public string Q_Obj_ID
        {
            get
            {
                return _q_obj_id;
            }
            set
            {
                _q_obj_id = (value == null ? "" : value);
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

        public Biz_QuestionEstMaps()
        {

        }

        public Biz_QuestionEstMaps(string est_id, string q_obj_id)
        {
            DataSet ds = _questionestmap.Select(est_id, q_obj_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _est_id = (dr["EST_ID"]             == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _q_obj_id = (dr["Q_OBJ_ID"]         == DBNull.Value) ? "" : (string)dr["Q_OBJ_ID"];
                _update_date = (dr["UPDATE_DATE"]   == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user = (dr["UPDATE_USER"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }


        public bool ModifyQuestionEstMap(string est_id, string q_obj_id, DateTime update_date, int update_user)
        {
            int affectedRow = 0;
            affectedRow = _questionestmap.Update( null
                                                , null
                                                , est_id
                                                , q_obj_id
                                                , update_date
                                                , update_user);

            //return affectedRow;
            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetQuestionEstMap(string est_id, string q_obj_id)
        {
            return _questionestmap.Select(est_id, q_obj_id);
        }

        public DataSet GetQuestionObJSubData(string est_id)
        {
            return _questionestmap.Select(null, null, est_id);
        }

        public bool AddQuestionEstMap(string est_id, string q_obj_id, DateTime create_date, int create_user)
        {
            int affectedRow = 0;
            affectedRow = _questionestmap.Insert(null
                                               , null
                                               , est_id
                                               , q_obj_id
                                               , create_date
                                               , create_user);

            //return affectedRow;
            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveQuestionEstMap(string est_id, string q_obj_id)
        {
            int affectedRow = 0;
            affectedRow = _questionestmap.Delete(null, null, est_id, q_obj_id);

            //return affectedRow;
            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(string est_id, string q_obj_id)
        {
            int affectedRow = 0;

            affectedRow = _questionestmap.Count(est_id,q_obj_id);

            if (affectedRow > 0)
                return true;

            return false;
        }


    }
}
