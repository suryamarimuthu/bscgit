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
    public class Biz_QuestionDefines
    {
        #region ============================== [Fields] ==============================

        private string _q_dfn_id;
        private string _num;
        private string _q_dfn_name;
        private string _q_dfn_define;
        private string _q_dfn_notice;
        private string _q_dfn_desc;
        private string _est_id;
        private DateTime _update_date;
        private int _update_user;

        private Dac_QuestionDefines _questionDefine = new Dac_QuestionDefines();

        #endregion

        #region ============================== [Properties] ==============================

        public string Q_Dfn_ID
        {
            get
            {
                return _q_dfn_id;
            }
            set
            {
                _q_dfn_id = (value == null ? "" : value);
            }
        }

        public string Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = (value == null ? "" : value);
            }
        }

        public string Q_Dfn_Name
        {
            get
            {
                return _q_dfn_name;
            }
            set
            {
                _q_dfn_name = (value == null ? "" : value);
            }
        }

        public string Q_Dfn_Define
        {
            get
            {
                return _q_dfn_define;
            }
            set
            {
                _q_dfn_define = (value == null ? "" : value);
            }
        }

        public string Q_Dfn_Notice
        {
            get
            {
                return _q_dfn_notice;
            }
            set
            {
                _q_dfn_notice = (value == null ? "" : value);
            }
        }

        public string Q_Dfn_Desc
        {
            get
            {
                return _q_dfn_desc;
            }
            set
            {
                _q_dfn_desc = (value == null ? "" : value);
            }
        }

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


        public Biz_QuestionDefines()
        {

        }

        public Biz_QuestionDefines(string q_dfn_id, string est_id)
        {
            DataSet ds = _questionDefine.Select(q_dfn_id, est_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              =  ds.Tables[0].Rows[0];
                _q_dfn_id       =  DataTypeUtility.GetString(dr["Q_DFN_ID"]);
                _num            =  DataTypeUtility.GetString(dr["NUM"]);
                _q_dfn_name     =  DataTypeUtility.GetString(dr["Q_DFN_NAME"]);
                _q_dfn_define   =  DataTypeUtility.GetString(dr["Q_DFN_DEFINE"]);
                _q_dfn_notice   =  DataTypeUtility.GetString(dr["Q_DFN_NOTICE"]);
                _q_dfn_desc     =  DataTypeUtility.GetString(dr["Q_DFN_DESC"]);
                _est_id         =  DataTypeUtility.GetString(dr["EST_ID"]);
                _update_date    =  DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user    =  DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyQuestionDefine( string q_dfn_id
                                        , string num
                                        , string q_dfn_name
                                        , string q_dfn_define
                                        , string q_dfn_notice
                                        , string q_dfn_desc
                                        , string est_id
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _questionDefine.Update( null
                                                , null
                                                , q_dfn_id
                                                , num
                                                , q_dfn_name
                                                , q_dfn_define
                                                , q_dfn_notice
                                                , q_dfn_desc
                                                , est_id
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetQuestionDefines()
        {
            return _questionDefine.Select("", "");
        }

        public DataSet GetQuestionDefine(string q_dfn_id, string est_id)
        {
            return _questionDefine.Select(q_dfn_id, est_id);
        }

        public DataSet GetQuestionDefine(string est_id)
        {
            return _questionDefine.Select("", est_id);
        }

        public bool AddQuestionDefine(string num
                                    , string q_dfn_name
                                    , string q_dfn_define
                                    , string q_dfn_notice
                                    , string q_dfn_desc
                                    , string est_id
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
                string q_dfn_id     = keyGen.GetCode(conn, trx, "EST_QUESTION_DEFINE");

                affectedRow = _questionDefine.Insert( conn
                                                    , trx
                                                    , q_dfn_id
                                                    , num
                                                    , q_dfn_name
                                                    , q_dfn_define
                                                    , q_dfn_notice
                                                    , q_dfn_desc
                                                    , est_id
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

        public bool RemoveQuestionDefine(string q_dfn_id)
        {
            int affectedRow = 0;

            affectedRow = _questionDefine.Delete(null, null, q_dfn_id);

            return (affectedRow > 0) ? true : false;
        }


        public bool IsExist(string q_dfn_id)
        {
            int affectedRow = 0;

            affectedRow = _questionDefine.Count(q_dfn_id);

            if (affectedRow > 0)
                return true;

            return false;
        }
    }
}
