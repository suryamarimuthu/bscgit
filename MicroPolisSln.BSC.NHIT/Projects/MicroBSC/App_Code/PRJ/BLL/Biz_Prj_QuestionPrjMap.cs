using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;
using MicroBSC.Data;

namespace MicroBSC.PRJ.Biz
{
    public class Biz_Prj_QuestionPrjMap
    {
        #region ============================== [Fields] ==============================
       
        private int _comp_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private string _est_id;
        private string _q_obj_id;
        private int _prj_ref_id;
        private DateTime _update_date;
        private int _update_user;

        private Dac_Prj_QuestionPrjMap _questionPrjMap = new Dac_Prj_QuestionPrjMap();

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

        public int Estterm_Ref_ID
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                _estterm_ref_id = value;
            }
        }

        public int Estterm_Sub_ID
        {
            get
            {
                return _estterm_sub_id;
            }
            set
            {
                _estterm_sub_id = value;
            }
        }

        public int Estterm_Step_ID
        {
            get
            {
                return _estterm_step_id;
            }
            set
            {
                _estterm_step_id = value;
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

        public int Prj_Ref_ID
        {
            get
            {
                return _prj_ref_id;
            }
            set
            {
                _prj_ref_id = value;
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

        public Biz_Prj_QuestionPrjMap()
        {

        }

        public Biz_Prj_QuestionPrjMap(int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string est_id
                                        , string q_obj_id
                                        , int prj_ref_id)
        {
            DataSet ds = null;


            ds = _questionPrjMap.Select(comp_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_id
                                        , q_obj_id
                                        , prj_ref_id);

            DataRow dr;

            if (ds != null && ds.Tables[0].Rows.Count == 1)
            {
                dr                      = ds.Tables[0].Rows[0];
                _estterm_ref_id         = DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id         = DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id        = DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"]);
                _est_id                 = DataTypeUtility.GetValue(dr["EST_ID"]);
                _q_obj_id               = DataTypeUtility.GetValue(dr["Q_OBJ_ID"]);
                _prj_ref_id             = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _update_date            = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user            = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        

        public DataSet GetQuestionProjectMapping(int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string est_id
                                        , string q_obj_id
                                        , int prj_ref_id)
        {
            return _questionPrjMap.Select(comp_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_id
                                        , q_obj_id
                                        , prj_ref_id);
        }

        public bool AddQuestionProjectMap(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    {
                        affectedRow += _questionPrjMap.Insert(conn
                                                                , trx
                                                                , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                                , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                                , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                                , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                                , dataRow["EST_ID"].ToString()
                                                                , dataRow["Q_OBJ_ID"].ToString()
                                                                , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                                                                , DateTime.Now
                                                                , DataTypeUtility.GetToInt32(dataRow["USER"]));
                    }
                }

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

        public bool RemoveQuestionDeptEmpMap(int comp_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , string est_id
                                            , string q_obj_id
                                            , int prj_ref_id)
        {
            int affectedRow = 0;

            affectedRow = _questionPrjMap.Delete(null
                                                    , null
                                                    , comp_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , est_id
                                                    , q_obj_id
                                                    , prj_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveQuestionProjectMap(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _questionPrjMap.Delete(conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , dataRow["Q_OBJ_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"]));
                }

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

        

        public bool IsExist(int comp_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , string est_id
                            , string q_obj_id
                            , int prj_ref_id)
        {
            int affectedRow = 0;

            affectedRow = _questionPrjMap.Count(      comp_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , est_id
                                                    , q_obj_id
                                                    , prj_ref_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ITYPE", typeof(string));
            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_SUB_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_STEP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("Q_OBJ_ID", typeof(string));
            dataTable.Columns.Add("PRJ_REF_ID", typeof(int));
            dataTable.Columns.Add("DATE", typeof(string));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    
    }
}