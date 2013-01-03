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
    public class Biz_QuestionItems
    {
        #region ============================== [Fields] ==============================

        private string _q_itm_id;
        private string _q_sbj_id;
        private int _num;
        private string _q_item_name;
        private double _point;
        private double _weight;
        private string _comment;
        private string _subject_item_yn;
        private DateTime _update_date;
        private int _update_user;

        private Dac_QuestionItems _questionItem = new Dac_QuestionItems();

        #endregion

        #region ============================== [Properties] ==============================

        public string Q_Itm_ID
        {
            get
            {
                return _q_itm_id;
            }
            set
            {
                _q_itm_id = (value == null ? "" : value);
            }
        }

        public string Q_Sbj_ID
        {
            get
            {
                return _q_sbj_id;
            }
            set
            {
                _q_sbj_id = (value == null ? "" : value);
            }
        }

        public int Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = (value == null ? 0 : value);
            }
        }

        public string Q_Item_Name
        {
            get
            {
                return _q_item_name;
            }
            set
            {
                _q_item_name = (value == null ? "" : value);
            }
        }

        public double Point
        {
            get
            {
                return _point;
            }
            set
            {
                _point = value;
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = (value == null ? "" : value);
            }
        }

        public string Subject_Item_YN
        {
            get
            {
                return _subject_item_yn;
            }
            set
            {
                _subject_item_yn = (value == null ? "" : value);
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

        public Biz_QuestionItems()
        {

        }

        public Biz_QuestionItems(string q_itm_id, string q_sbj_id, string q_obj_id)
        {
            DataSet ds = _questionItem.Select(q_itm_id, q_sbj_id, q_obj_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];
                _q_itm_id           = (dr["Q_ITM_ID"]        == DBNull.Value) ? "" : dr["Q_ITM_ID"].ToString();
                _q_sbj_id           = (dr["Q_SBJ_ID"]        == DBNull.Value) ? "" : dr["Q_SBJ_ID"].ToString();
                _num                = (dr["NUM"]             == DBNull.Value) ? 0 :  DataTypeUtility.GetToInt32(dr["NUM"]);
                _q_item_name        = (dr["Q_ITEM_NAME"]     == DBNull.Value) ? "" : dr["Q_ITEM_NAME"].ToString();
                _point              = (dr["POINT"]           == DBNull.Value) ? 0 :  DataTypeUtility.GetToDouble(dr["POINT"]);
                _weight             = (dr["WEIGHT"]          == DBNull.Value) ? 0 :  DataTypeUtility.GetToDouble(dr["WEIGHT"]);
                _comment            = (dr["COMMENT"]         == DBNull.Value) ? "" : dr["COMMENT"].ToString();
                _subject_item_yn    = (dr["SUBJECT_ITEM_YN"] == DBNull.Value) ? "" : dr["SUBJECT_ITEM_YN"].ToString();
                _update_date        = (dr["UPDATE_DATE"]     == DBNull.Value) ? DateTime.MinValue : DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user        = (dr["UPDATE_USER"]     == DBNull.Value) ? 0 : DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyQuestionItem(string q_itm_id
                                        , string q_sbj_id
                                        , int num
                                        , string q_item_name
                                        , double point
                                        , string comment
                                        , string subject_item_yn
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _questionItem.Update( null
                                            , null
                                            , q_itm_id
                                            , q_sbj_id
                                            , num
                                            , q_item_name
                                            , point
                                            , comment
                                            , subject_item_yn
                                            , update_date
                                            , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetQuestionItems()
        {
            return GetQuestionItem("", "", "");
        }

        public DataSet GetQuestionItem(string q_itm_id, string q_sbj_id, string q_obj_id)
        {
            return _questionItem.Select(q_itm_id, q_sbj_id, q_obj_id);
        }

        public bool AddQuestionItem(  string q_sbj_id
                                    , int num
                                    , string q_item_name
                                    , double point
                                    , string comment
                                    , string subject_item_yn
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Dac_KeyGens keyGen  = new Dac_KeyGens();
                string q_itm_id     = keyGen.GetCode(conn, trx, "EST_QUESTION_ITEM");

                affectedRow = _questionItem.Insert(   conn
                                                    , trx
                                                    , q_itm_id
                                                    , q_sbj_id
                                                    , num
                                                    , q_item_name
                                                    , point
                                                    , comment
                                                    , subject_item_yn
                                                    , create_date
                                                    , create_user);

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveQuestionItem(string q_itm_id)
        {
            int affectedRow = 0;

            affectedRow = _questionItem.Delete(null, null, q_itm_id, "");
                                                
            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(string q_itm_id)
        {
            int affectedRow = 0;

            affectedRow = _questionItem.Count(q_itm_id);

            if (affectedRow > 0)
                return true;

            return false;
        }
    }
}
