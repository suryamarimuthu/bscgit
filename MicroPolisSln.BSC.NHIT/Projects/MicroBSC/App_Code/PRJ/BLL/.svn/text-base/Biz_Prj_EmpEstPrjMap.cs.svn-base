using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;
using MicroBSC.Data;
using MicroBSC.Estimation.Dac;

namespace MicroBSC.PRJ.Biz
{
    public class Biz_Prj_EmpEstPrjMap
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private string _est_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private int _est_dept_id;
        private int _est_emp_id;
        private int _prj_ref_id;
        private string _status_id;
        private DateTime _update_date;
        private int _update_user;

        private Dac_Prj_EmpEstPrjMap _prjEstPrjMap = new Dac_Prj_EmpEstPrjMap();

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

        public int Est_Dept_ID
        {
            get
            {
                return _est_dept_id;
            }
            set
            {
                _est_dept_id = value;
            }
        }

        public int Est_Emp_ID
        {
            get
            {
                return _est_emp_id;
            }
            set
            {
                _est_emp_id = value;
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

        public string Status_ID
        {
            get
            {
                return _status_id;
            }
            set
            {
                _status_id = (value == null ? "" : value);
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

        public Biz_Prj_EmpEstPrjMap()
        {

        }
        public Biz_Prj_EmpEstPrjMap(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int prj_ref_id)
        {
            DataSet ds = _prjEstPrjMap.Select( comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , prj_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];

                _comp_id            = DataTypeUtility.GetToInt32(dr["COMP_ID"]);
                _est_id             = DataTypeUtility.GetValue(dr["EST_ID"]);
                _estterm_ref_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id        = DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id         = DataTypeUtility.GetToInt32(dr["EST_EMP_ID"]);
                _prj_ref_id         = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _status_id          = DataTypeUtility.GetValue(dr["STATUS_ID"]);
                _update_date        = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user        = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyPrjEmpEstPrjMap(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int prj_ref_id
                                        , string status_id
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _prjEstPrjMap.Update(null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , prj_ref_id
                                                , status_id
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetPrjEmpEstPrjMap(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int prj_ref_id)
        {
            return _prjEstPrjMap.Select(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_dept_id
                                        , est_emp_id
                                        , prj_ref_id);
        }

       

        public bool AddPrjEmpEstPrjMap(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int prj_ref_id
                                    , string status_id
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            Dac_QuestionEstMaps questionEstMap = new Dac_QuestionEstMaps();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                // 존재하는 데이터가 있다면 삭제 후 추가
                if(IsExist(   comp_id
                            , est_id
                            , estterm_ref_id
                            , estterm_sub_id
                            , estterm_step_id
                            , 0
                            , 0
                            , prj_ref_id))
                {
                    affectedRow += _prjEstPrjMap.Delete( conn
                                                          , trx
                                                          , comp_id
                                                          , est_id
                                                          , estterm_ref_id
                                                          , estterm_sub_id
                                                          , estterm_step_id
                                                          , 0
                                                          , 0
                                                          , prj_ref_id);
                }

                affectedRow += _prjEstPrjMap.Insert( conn
                                                      , trx
                                                      , comp_id
                                                      , est_id
                                                      , estterm_ref_id
                                                      , estterm_sub_id
                                                      , estterm_step_id
                                                      , est_dept_id
                                                      , est_emp_id
                                                      , prj_ref_id
                                                      , status_id
                                                      , create_date
                                                      , create_user);

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

        public bool AddPrjEmpEstPrjMap(DataTable dataTable)
        {
            int affectedRow = 0;


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _prjEstPrjMap.Insert(conn
                                                          , trx
                                                          , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                          , dataRow["EST_ID"].ToString()
                                                          , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                          , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                          , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                          , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                          , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
                                                          , DataTypeUtility.GetToInt32(dataRow["PRJ_REF_ID"])
                                                          , dataRow["STATUS_ID"].ToString()
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

        public bool RemovePrjEmpEstPrjMap(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _prjEstPrjMap.Delete(conn
                                                            , trx
                                                            , DataTypeUtility.GetToInt32(dataRow["COMP_ID"])
                                                            , dataRow["EST_ID"].ToString()
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_REF_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_SUB_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["ESTTERM_STEP_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_DEPT_ID"])
                                                            , DataTypeUtility.GetToInt32(dataRow["EST_EMP_ID"])
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

        public bool RemovePrjEmpEstPrjMap(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int prj_ref_id)
        {
            int affectedRow = 0;

            affectedRow = _prjEstPrjMap.Delete(null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , prj_ref_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(  int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int prj_ref_id)
        {
            int affectedRow = 0;

            affectedRow = _prjEstPrjMap.Count( comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
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
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_SUB_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_STEP_ID", typeof(int));
            dataTable.Columns.Add("EST_DEPT_ID", typeof(int));
            dataTable.Columns.Add("EST_EMP_ID", typeof(int));
            dataTable.Columns.Add("PRJ_REF_ID", typeof(int));
            dataTable.Columns.Add("STATUS_ID", typeof(string));
            dataTable.Columns.Add("DATE", typeof(string));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
