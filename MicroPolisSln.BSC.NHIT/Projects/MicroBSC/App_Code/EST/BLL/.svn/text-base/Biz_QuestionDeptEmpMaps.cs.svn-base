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
    public class Biz_QuestionDeptEmpMaps
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private string _est_id;
        private string _q_obj_id;
        private string _q_obj_name;
        private int _tgt_dept_id;
        private int _tgt_emp_id;
        private DateTime _update_date;
        private int _update_user;

        private Dac_QuestionDeptEmpMaps _questionDeptEmpMap = new Dac_QuestionDeptEmpMaps();

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

        public string Q_Obj_Name
        {
            get
            {
                return _q_obj_name;
            }
            set
            {
                _q_obj_name = (value == null ? "" : value);
            }
        }

        public int Tgt_Dept_ID
        {
            get
            {
                return _tgt_dept_id;
            }
            set
            {
                _tgt_dept_id = value;
            }
        }

        public int Tgt_Emp_ID
        {
            get
            {
                return _tgt_emp_id;
            }
            set
            {
                _tgt_emp_id = value;
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

        public Biz_QuestionDeptEmpMaps()
        {

        }

        public Biz_QuestionDeptEmpMaps(   int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string est_id
                                        , string q_obj_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , string owner_type)
        {
            DataSet ds = null;

            if (owner_type.Equals("P"))
            {
                 ds = _questionDeptEmpMap.SelectEmp(comp_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_id
                                                , q_obj_id
                                                , tgt_emp_id
                                                , OwnerType.Emp_User);
            }
            else if (owner_type.Equals("D"))
            {
                ds = _questionDeptEmpMap.SelectDept(comp_id
                                                  , estterm_ref_id
                                                  , estterm_sub_id
                                                  , estterm_step_id
                                                  , est_id
                                                  , q_obj_id
                                                  , tgt_dept_id);
            }

            DataRow dr;

            if (ds != null && ds.Tables[0].Rows.Count == 1)
            {
                dr                      = ds.Tables[0].Rows[0];

                _comp_id                = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _estterm_ref_id         = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id         = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id        = (dr["ESTTERM_STEP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
                _est_id                 = (dr["EST_ID"]             == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _q_obj_id               = (dr["Q_OBJ_ID"]           == DBNull.Value) ? "" : (string)dr["Q_OBJ_ID"];
                _q_obj_name             = (dr["Q_OBJ_NAME"]         == DBNull.Value) ? "" : (string)dr["Q_OBJ_NAME"];
                _tgt_dept_id            = (dr["TGT_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
                _tgt_emp_id             = (dr["TGT_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
                _update_date            = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user            = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyQuestionDeptEmpMap( int comp_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string est_id
                                            , string q_obj_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id
                                            , DateTime update_date
                                            , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _questionDeptEmpMap.Update( null
                                                    , null
                                                    , comp_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , est_id
                                                    , q_obj_id
                                                    , tgt_dept_id
                                                    , tgt_emp_id
                                                    , update_date
                                                    , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetQuestionEmpMapping( int comp_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string est_id
                                            , string q_obj_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id
                                            , OwnerType ownerType)
        {
            return _questionDeptEmpMap.SelectEmp( comp_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_id
                                                , q_obj_id
                                                , tgt_emp_id
                                                , ownerType);
        }

        public DataSet GetQuestionDeptEmpMapping( int comp_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id
                                                , string est_id
                                                , string q_obj_id
                                                , int tgt_dept_id
                                                , int tgt_emp_id
                                                , OwnerType ownerType)
        {
            return _questionDeptEmpMap.SelectEmp( comp_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_id
                                                , q_obj_id
                                                , tgt_emp_id
                                                , ownerType);
        }

        public DataSet GetQuestionDeptMapping(int comp_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string est_id
                                            , string q_obj_id
                                            , int tgt_dept_id)
        {
            return _questionDeptEmpMap.SelectDept(comp_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_id
                                                , q_obj_id
                                                , tgt_dept_id);
        }

        public bool AddQuestionDeptEmpMap(int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string est_id
                                        , string q_obj_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , DateTime create_date
                                        , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _questionDeptEmpMap.Insert( null
                                                    , null
                                                    , comp_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , est_id
                                                    , q_obj_id
                                                    , tgt_dept_id
                                                    , tgt_emp_id
                                                    , create_date
                                                    , create_user);

            return (affectedRow > 0) ? true : false;
        }

        /// <summary>
        /// 전기간 참조
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="estterm_ref_id_from"></param>
        /// <param name="estterm_sub_id_from"></param>
        /// <param name="estterm_ref_id_to"></param>
        /// <param name="estterm_sub_id_to"></param>
        /// <param name="create_date"></param>
        /// <param name="create_user"></param>
        /// <returns></returns>
        public bool CopyEstDataFromTo(int comp_id
                                    , int estterm_ref_id_from
                                    , int estterm_sub_id_from
                                    , int estterm_ref_id_to
                                    , int estterm_sub_id_to
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow += _questionDeptEmpMap.Delete(    conn
                                                            , trx
                                                            , comp_id
                                                            , estterm_ref_id_to
                                                            , estterm_sub_id_to
                                                            , ""
                                                            , ""
                                                            , 0
                                                            , 0);

                affectedRow += _questionDeptEmpMap.InsertDataFromTo(  conn
                                                                    , trx
                                                                    , comp_id
                                                                    , estterm_ref_id_from
                                                                    , estterm_sub_id_from
                                                                    , estterm_ref_id_to
                                                                    , estterm_sub_id_to
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

        public bool AddQuestionDeptEmpMap(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _questionDeptEmpMap.Insert(conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , dataRow["Q_OBJ_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                                            , DateTime.Now
                                                            , DataTypeUtility.GetToInt32(dataRow["USER"]));
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

        public bool RemoveQuestionDeptEmpMap( int comp_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , string est_id
                                            , string q_obj_id
                                            , int tgt_dept_id
                                            , int tgt_emp_id)
        {
            int affectedRow = 0;

            affectedRow = _questionDeptEmpMap.Delete( null
                                                    , null
                                                    , comp_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , est_id
                                                    , q_obj_id
                                                    , tgt_dept_id
                                                    , tgt_emp_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveQuestionDeptEmpMap(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _questionDeptEmpMap.Delete(conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , dataRow["Q_OBJ_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"]));
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

        public bool UpdateQuestionDeptMap(DataTable dataTable
                                        , int comp_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , string est_id
                                        , string q_obj_id)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                affectedRow = _questionDeptEmpMap.Delete( conn
                                                        , trx
                                                        , comp_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , est_id
                                                        , q_obj_id
                                                        , 0
                                                        , 0);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _questionDeptEmpMap.Insert(conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , dataRow["Q_OBJ_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"])
                                                            , DataTypeUtility.GetToDateTime(dataRow["DATE"])
                                                            , DataTypeUtility.GetToInt32(dataRow["USER"]));
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

        public bool IsExist(  int comp_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , string est_id
                            , string q_obj_id
                            , int tgt_dept_id
                            , int tgt_emp_id)
        {
            int affectedRow = 0;

            affectedRow = _questionDeptEmpMap.Count(  comp_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , est_id
                                                    , q_obj_id
                                                    , tgt_dept_id
                                                    , tgt_emp_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public DataSet GetDeptByEmpList(int comp_id
                                     , int estterm_ref_id
                                     , int estterm_sub_id
                                     , string est_id
                                     , int dept_ref_id)
        {
            return _questionDeptEmpMap.SelectDeptByEmpList(comp_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , est_id
                                                        , dept_ref_id);
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
            dataTable.Columns.Add("TGT_DEPT_ID", typeof(string));
            dataTable.Columns.Add("TGT_EMP_ID", typeof(string));
            dataTable.Columns.Add("DATE", typeof(string));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}