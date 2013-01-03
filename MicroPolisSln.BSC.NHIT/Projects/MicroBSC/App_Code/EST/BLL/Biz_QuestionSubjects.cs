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
    public class Biz_QuestionSubjects
    {
        #region ============================== [Fields] ==============================

        private string _q_sbj_id;
        private string _q_obj_id;
        private string _q_dfn_id;
        private int _num;
        private string _q_sbj_name;
        private double _weight;
        private string _q_sbj_define;
        private string _q_sbj_desc;
        private DateTime _update_date;
        private int _update_user;

        private Dac_QuestionSubjects _questionsubject = new Dac_QuestionSubjects();

        #endregion

        #region ============================== [Properties] ==============================

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

        public string Q_Sbj_Name
        {
            get
            {
                return _q_sbj_name;
            }
            set
            {
                _q_sbj_name = (value == null ? "" : value);
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

        public string Q_Sbj_Define
        {
            get { return _q_sbj_define; }
            set { _q_sbj_define = (value == null ? "" : value); }
        }

        public string Q_Sbj_Desc
        {
            get { return _q_sbj_desc; }
            set { _q_sbj_desc = (value == null ? "" : value); }
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

        public Biz_QuestionSubjects()
        {

        }

        public Biz_QuestionSubjects(string q_sbj_id)
        {
            DataSet ds = _questionsubject.Select(q_sbj_id,"","");
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _q_sbj_id       = dr["Q_SBJ_ID"].ToString();
                _q_obj_id       = dr["Q_OBJ_ID"].ToString();
                _q_dfn_id       = dr["Q_DFN_ID"].ToString();
                _num            = DataTypeUtility.GetToInt32(dr["NUM"]);
                _q_sbj_name     = dr["Q_SBJ_NAME"].ToString();
                _q_sbj_define   = dr["Q_SBJ_DEFINE"].ToString();
                _q_sbj_desc     = dr["Q_SBJ_DESC"].ToString();
                _weight         = DataTypeUtility.GetToDouble(dr["WEIGHT"]);
                _update_date    = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user    = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyQuestionSubject(string q_sbj_id
                                        , string q_obj_id
                                        , string q_dfn_id
                                        , int num
                                        , string q_sbj_name
                                        , double weight
                                        , string q_sbj_define
                                        , string q_sbj_desc
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _questionsubject.Update(null
                                                , null
                                                , q_sbj_id
                                                , q_obj_id
                                                , q_dfn_id
                                                , num
                                                , q_sbj_name
                                                , weight
                                                , q_sbj_define
                                                , q_sbj_desc
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetQuestionSubjects()
        {
            return GetQuestionSubject("","","");
        }

        public DataSet GetQuestionSubject(string q_sbj_id, string q_obj_id,string q_dfn_id)
        {
            return _questionsubject.Select(q_sbj_id, q_obj_id,q_dfn_id);
        }

        public DataSet GetQuestionSubject(int comp_id, string est_id, int tgt_emp_id, string q_dfn_id)
        {
            return _questionsubject.SelectByTgt(null, null, comp_id, est_id, tgt_emp_id, q_dfn_id);
        }

        public bool AddQuestionSubject(string q_obj_id
                                    , string q_dfn_id
                                    , int num
                                    , string q_sbj_name
                                    , double weight
                                    , string q_sbj_define
                                    , string q_sbj_desc
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
                string q_sbj_id     = keyGen.GetCode(conn, trx, "EST_QUESTION_SUBJECT");

                affectedRow         = _questionsubject.Insert(conn
                                                            , trx
                                                            , q_sbj_id
                                                            , q_obj_id
                                                            , q_dfn_id
                                                            , num
                                                            , q_sbj_name
                                                            , weight
                                                            , q_sbj_define
                                                            , q_sbj_desc
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

        public bool RemoveQuestionSubject(string q_sbj_id)
        {
            int affectedRow = 0;

            Dac_QuestionItems questionItem = new Dac_QuestionItems();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow += questionItem.Delete(null, null, "", q_sbj_id);
                affectedRow += _questionsubject.Delete(null, null, q_sbj_id, "");

				trx.Commit();
			}
			catch ( Exception ex )
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

        public bool IsExist(string q_sbj_id)
        {
            int affectedRow = 0;

            affectedRow = _questionsubject.Count(q_sbj_id);

            if (affectedRow > 0)
                return true;

            return false;
        }
    }
}
