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
    public class Biz_QuestionObjects
    {
        #region ============================== [Fields] ==============================

        private string  _est_id;
        private string 	_q_obj_id;
        private string 	_q_obj_name;
        private string 	_q_obj_title;
        private string 	_q_obj_preface;
        private DateTime 	_update_date;
        private int 	_update_user;

        private Dac_QuestionObjects _questionObject = new Dac_QuestionObjects();

        #endregion
 
        #region ============================== [Properties] ==============================

        public string Est_ID
        {
            get { return _est_id; }
            set { _est_id = (value == null ? "" : value); }
        }

        public string Q_Obj_ID
        {
            get 
            {
	            return _q_obj_id;
            }
            set
            {
	            _q_obj_id = ( value==null ? "" : value );
            }
        }
         
        public string Q_Obj_Name
        {
            get 
            {
	            return _q_obj_name;
            }
            set
            {
	            _q_obj_name = ( value==null ? "" : value );
            }
        }
         
        public string Q_Obj_Title
        {
            get 
            {
	            return _q_obj_title;
            }
            set
            {
	            _q_obj_title = ( value==null ? "" : value );
            }
        }
         
        public string Q_Obj_Preface
        {
            get 
            {
	            return _q_obj_preface;
            }
            set
            {
	            _q_obj_preface = ( value==null ? "" : value );
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

        public Biz_QuestionObjects()
        {

        }

        public Biz_QuestionObjects(string est_id,string q_obj_id)
        {
            DataSet ds = _questionObject.Select(est_id, q_obj_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _est_id         = (dr["EST_ID"]        == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _q_obj_id       = (dr["Q_OBJ_ID"]      == DBNull.Value) ? "" : (string)dr["Q_OBJ_ID"];
                _q_obj_name     = (dr["Q_OBJ_NAME"]    == DBNull.Value) ? "" : (string)dr["Q_OBJ_NAME"];
                _q_obj_title    = (dr["Q_OBJ_TITLE"]   == DBNull.Value) ? "" : (string)dr["Q_OBJ_TITLE"];
                _q_obj_preface  = (dr["Q_OBJ_PREFACE"] == DBNull.Value) ? "" : (string)dr["Q_OBJ_PREFACE"];
                _update_date    = (dr["UPDATE_DATE"]   == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }
 
        public bool ModifyQuestionObject( string q_obj_id
                                        , string q_obj_name
                                        , string q_obj_title
                                        , string q_obj_preface
                                        , string[] est_id_arr
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            Dac_QuestionEstMaps questionEstMap = new Dac_QuestionEstMaps();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow += _questionObject.Update(conn
                                                    , trx
                                                    , q_obj_id
                                                    , q_obj_name
                                                    , q_obj_title
                                                    , q_obj_preface
                                                    , update_date
                                                    , update_user);

                affectedRow += questionEstMap.Delete(conn, trx, "", q_obj_id);

                foreach (string est_id in est_id_arr)
                {
                    affectedRow += questionEstMap.Insert( conn
                                                        , trx
                                                        , est_id
                                                        , q_obj_id
                                                        , update_date
                                                        , update_user);
                }


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
 
        public DataSet GetQuestionObject(string est_id, string q_obj_id)
        {
            return _questionObject.Select(est_id, q_obj_id);
        }

        public DataSet GetQuestionObjects(string est_id)
        {
            return _questionObject.Select(est_id,"");
        }

        public bool AddQuestionObject(string q_obj_name
                                    , string q_obj_title
                                    , string q_obj_preface
                                    , string[] est_id_arr
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            Dac_QuestionEstMaps questionEstMap  = new Dac_QuestionEstMaps();
            Dac_KeyGens keyGen                  = new Dac_KeyGens();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                string q_obj_id = keyGen.GetCode(conn, trx, "EST_QUESTION_OBJECT");

                affectedRow += _questionObject.Insert(conn
                                                    , trx
                                                    , q_obj_id
                                                    , q_obj_name
                                                    , q_obj_title
                                                    , q_obj_preface
                                                    , create_date
                                                    , create_user);

                foreach (string est_id in est_id_arr)
                {
                    affectedRow += questionEstMap.Insert( conn
                                                        , trx
                                                        , est_id
                                                        , q_obj_id
                                                        , create_date
                                                        , create_user);
                }

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

        public bool RemoveQuestionObject(string q_obj_id)
        {
            int affectedRow = 0;

            Dac_QuestionEstMaps questionEstMap      = new Dac_QuestionEstMaps();
            Dac_QuestionSubjects questionSubject    = new Dac_QuestionSubjects();
            Dac_QuestionItems questionItem          = new Dac_QuestionItems();
            Dac_QuestionDatas questionData          = new Dac_QuestionDatas();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                affectedRow += questionItem.DeleteByQObjID(conn, trx, q_obj_id);
                affectedRow += questionSubject.Delete(conn, trx, "", q_obj_id);
                affectedRow += questionEstMap.Delete(conn, trx, "", q_obj_id);
                affectedRow += _questionObject.Delete(conn, trx, q_obj_id);

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

        public bool CopyQuestionObject(DataTable dataTable)
        {
            int affectedRow = 0;

            Dac_QuestionEstMaps questionEstMap      = new Dac_QuestionEstMaps();
            Dac_QuestionSubjects questionSubject    = new Dac_QuestionSubjects();
            Dac_QuestionItems questionItem          = new Dac_QuestionItems();
            Dac_QuestionDatas questionData          = new Dac_QuestionDatas();
            Dac_KeyGens keyGen                      = new Dac_KeyGens();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                //EST_QUESTION_OBJECT - 복사
                foreach(DataRow dataRowDT in dataTable.Rows) 
                {
                    DataTable dtObj     = _questionObject.Select( conn
                                                                , trx
                                                                , DataTypeUtility.GetValue(dataRowDT["EST_ID"])
                                                                , DataTypeUtility.GetValue(dataRowDT["Q_OBJ_ID"])).Tables[0];

                    DataTable dtEstMap  = questionEstMap.Select(  conn
                                                                , trx
                                                                , ""
                                                                , DataTypeUtility.GetValue(dataRowDT["Q_OBJ_ID"])).Tables[0];

                    foreach(DataRow dataRowObj in dtObj.Rows) 
                    {
                        string q_obj_id = keyGen.GetCode( conn
                                                        , trx
                                                        , "EST_QUESTION_OBJECT");

                        // 질의 그룹 등록
                        affectedRow += _questionObject.Insert(conn
                                                            , trx
                                                            , q_obj_id
                                                            , "Copy of "+ DataTypeUtility.GetValue(dataRowObj["Q_OBJ_NAME"])
                                                            , DataTypeUtility.GetValue(dataRowObj["Q_OBJ_TITLE"])
                                                            , DataTypeUtility.GetValue(dataRowObj["Q_OBJ_PREFACE"])
                                                            , DataTypeUtility.GetToDateTime(dataRowDT["DATE"])
                                                            , DataTypeUtility.GetToInt32(dataRowDT["USER"]));

                        // 질의 매핑 등록
                        foreach (DataRow dataRowEstMap in dtEstMap.Rows)
                        {
                            affectedRow += questionEstMap.Insert( conn
                                                                , trx
                                                                , DataTypeUtility.GetValue(dataRowEstMap["EST_ID"])
                                                                , q_obj_id
                                                                , DataTypeUtility.GetToDateTime(dataRowDT["DATE"])
                                                                , DataTypeUtility.GetToInt32(dataRowDT["USER"]));
                        }

                        DataTable dtSub  = questionSubject.Select(conn
                                                                , trx
                                                                , ""
                                                                , DataTypeUtility.GetValue(dataRowObj["Q_OBJ_ID"])
                                                                , "").Tables[0];

                        // 질의 제목 등록
                        foreach(DataRow dataRowSub in dtSub.Rows) 
                        {
                            string q_sbj_id     = keyGen.GetCode( conn
                                                                , trx
                                                                , "EST_QUESTION_SUBJECT");

                            affectedRow         += questionSubject.Insert(conn
                                                                        , trx
                                                                        , q_sbj_id
                                                                        , q_obj_id
                                                                        , DataTypeUtility.GetValue(dataRowSub["Q_DFN_ID"])
                                                                        , DataTypeUtility.GetToInt32(dataRowSub["NUM"])
                                                                        , DataTypeUtility.GetValue(dataRowSub["Q_SBJ_NAME"])
                                                                        , DataTypeUtility.GetToDouble(dataRowSub["WEIGHT"])
                                                                        , DataTypeUtility.GetValue(dataRowSub["Q_SBJ_DEFINE"])
                                                                        , DataTypeUtility.GetValue(dataRowSub["Q_SBJ_DESC"])
                                                                        , DataTypeUtility.GetToDateTime(dataRowDT["DATE"])
                                                                        , DataTypeUtility.GetToInt32(dataRowDT["USER"]));

                            DataTable dtItem  = questionItem.Select(  conn
                                                                    , trx
                                                                    , ""
                                                                    , DataTypeUtility.GetValue(dataRowSub["Q_SBJ_ID"])
                                                                    , DataTypeUtility.GetValue(dataRowObj["Q_OBJ_ID"])).Tables[0];

                            // 질의 항목 등록
                            foreach(DataRow dataRowItem in dtItem.Rows) 
                            {
                                string q_itm_id     = keyGen.GetCode( conn
                                                                    , trx
                                                                    , "EST_QUESTION_ITEM");

                                affectedRow         += questionItem.Insert(   conn
                                                                            , trx
                                                                            , q_itm_id
                                                                            , q_sbj_id
                                                                            , DataTypeUtility.GetToInt32(dataRowItem["NUM"])
                                                                            , DataTypeUtility.GetValue(dataRowItem["Q_ITEM_NAME"])
                                                                            , DataTypeUtility.GetToDouble(dataRowItem["POINT"])
                                                                            , DataTypeUtility.GetValue(dataRowItem["COMMENT"])
                                                                            , DataTypeUtility.GetValue(dataRowItem["SUBJECT_ITEM_YN"])
                                                                            , DataTypeUtility.GetToDateTime(dataRowDT["DATE"])
                                                                            , DataTypeUtility.GetToInt32(dataRowDT["USER"]));
                            }
                        }
                    }
                }

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

        public bool IsExist(string q_obj_id)
        {
            int affectedRow = 0;

            affectedRow = _questionObject.Count(q_obj_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("Q_OBJ_ID", typeof(string));
            dataTable.Columns.Add("Q_OBJ_NAME", typeof(string));
            dataTable.Columns.Add("Q_OBJ_TITLE", typeof(string));
            dataTable.Columns.Add("Q_OBJ_PREFACE", typeof(string));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));
            
            return dataTable;
        }
    }
}
