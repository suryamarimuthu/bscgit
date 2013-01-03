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
    public class Biz_EmpEstTargetMaps
    {
        #region ============================== [Fields] ==============================

        private int _comp_id;
        private string _est_id;
        private int _estterm_ref_id;
        private int _estterm_sub_id;
        private int _estterm_step_id;
        private int _est_dept_id;
        private int _est_emp_id;
        private int _tgt_dept_id;
        private int _tgt_emp_id;
        private string _tgt_pos_cls_id;
        private string _tgt_pos_cls_name;
        private string _tgt_pos_dut_id;
        private string _tgt_pos_dut_name;
        private string _tgt_pos_grp_id;
        private string _tgt_pos_grp_name;
        private string _tgt_pos_rnk_id;
        private string _tgt_pos_rnk_name;
        private string _tgt_pos_knd_id;
        private string _tgt_pos_knd_name;
        private string _direction_type;
        private string _status_id;
        private DateTime _update_date;
        private int _update_user;

        private Dac_EmpEstTargetMaps _empEstTargetMap = new Dac_EmpEstTargetMaps();

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

        public Biz_EmpEstTargetMaps()
        {

        }
        public Biz_EmpEstTargetMaps(  int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id)
        {
            DataSet ds = _empEstTargetMap.Select( comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , OwnerType.All);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];

                _comp_id        = (dr["COMP_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["COMP_ID"]);
                _est_id         = (dr["EST_ID"]             == DBNull.Value) ? "" : (string)dr["EST_ID"];
                _estterm_ref_id = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id = (dr["ESTTERM_SUB_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id= (dr["ESTTERM_STEP_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id    = (dr["EST_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id     = (dr["EST_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_EMP_ID"]);
                _tgt_dept_id    = (dr["TGT_DEPT_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_DEPT_ID"]);
                _tgt_emp_id     = (dr["TGT_EMP_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_EMP_ID"]);
                _direction_type = (dr["DIRECTION_TYPE"]     == DBNull.Value) ? "D" : (string)dr["DIRECTION_TYPE"];
                _status_id      = (dr["STATUS_ID"]          == DBNull.Value) ? "" : (string)dr["STATUS_ID"];
                _update_date    = (dr["UPDATE_DATE"]        == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["UPDATE_DATE"];
                _update_user    = (dr["UPDATE_USER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyEmpEstTargetMap(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , string status_id
                                        , DateTime update_date
                                        , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _empEstTargetMap.Update(null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id
                                                , status_id
                                                , update_date
                                                , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetEmpEstTargetMap(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id)
        {
            return _empEstTargetMap.Select(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_dept_id
                                        , est_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id
                                        , OwnerType.All);
        }

        public DataSet GetEmpEstTargetMap(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id
                                        , OwnerType ownerType)
        {
            return _empEstTargetMap.Select(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_dept_id
                                        , est_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id
                                        , ownerType);
        }

        public bool AddEmpEstTargetMap(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id
                                    , int tgt_emp_id
                                    , string tgt_pos_cls_id
                                    , string tgt_pos_cls_name
                                    , string tgt_pos_dut_id
                                    , string tgt_pos_dut_name
                                    , string tgt_pos_grp_id
                                    , string tgt_pos_grp_name
                                    , string tgt_pos_rnk_id
                                    , string tgt_pos_rnk_name
                                    , string tgt_pos_knd_id
                                    , string tgt_pos_knd_name
                                    , string direction_type
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
                            , tgt_dept_id
                            , tgt_emp_id))
                {
                    affectedRow += _empEstTargetMap.Delete( conn
                                                          , trx
                                                          , comp_id
                                                          , est_id
                                                          , estterm_ref_id
                                                          , estterm_sub_id
                                                          , estterm_step_id
                                                          , 0
                                                          , 0
                                                          , tgt_dept_id
                                                          , tgt_emp_id);
                }

                affectedRow += _empEstTargetMap.Insert( conn
                                                      , trx
                                                      , comp_id
                                                      , est_id
                                                      , estterm_ref_id
                                                      , estterm_sub_id
                                                      , estterm_step_id
                                                      , est_dept_id
                                                      , est_emp_id
                                                      , tgt_dept_id
                                                      , tgt_emp_id
                                                      , tgt_pos_cls_id.Replace("&nbsp;", "")
                                                      , tgt_pos_cls_name.Replace("&nbsp;", "")
                                                      , tgt_pos_dut_id.Replace("&nbsp;", "")
                                                      , tgt_pos_dut_name.Replace("&nbsp;", "")
                                                      , tgt_pos_grp_id.Replace("&nbsp;", "")
                                                      , tgt_pos_grp_name.Replace("&nbsp;", "")
                                                      , tgt_pos_rnk_id.Replace("&nbsp;", "")
                                                      , tgt_pos_rnk_name.Replace("&nbsp;", "")
                                                      , tgt_pos_knd_id.Replace("&nbsp;", "")
                                                      , tgt_pos_knd_name.Replace("&nbsp;", "")
                                                      , direction_type
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

        public bool CopyDataFromTo(int comp_id
                                , string est_id
                                , int estterm_ref_id_from
                                , int estterm_sub_id_from
                                , int estterm_step_id_from
                                , int estterm_ref_id_to
                                , int estterm_sub_id_to
                                , int estterm_step_id_to
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
                affectedRow += _empEstTargetMap.Delete( conn
                                                      , trx
                                                      , comp_id
                                                      , ""
                                                      , estterm_ref_id_to
                                                      , estterm_sub_id_to
                                                      , estterm_step_id_to
                                                      , 0
                                                      , 0
                                                      , 0
                                                      , 0);

                affectedRow += _empEstTargetMap.InsertDataFromTo(   conn
                                                                  , trx
                                                                  , comp_id
                                                                  , estterm_ref_id_from
                                                                  , estterm_sub_id_from
                                                                  , estterm_step_id_from
                                                                  , estterm_ref_id_to
                                                                  , estterm_sub_id_to
                                                                  , estterm_step_id_to
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

        public bool RemoveEmpEstTargetMap(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int tgt_dept_id
                                        , int tgt_emp_id)
        {
            int affectedRow = 0;

            affectedRow = _empEstTargetMap.Delete(null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id);

            return (affectedRow > 0) ? true : false;
        }

        public bool RemoveEmpEstTargetMap(DataTable dataTable)
        {
            int affectedRow = 0;

            Dac_QuestionEstMaps questionEstMap = new Dac_QuestionEstMaps();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _empEstTargetMap.Delete( conn
                                                          , trx
                                                          , dataRow["COMP_ID"]
                                                          , dataRow["EST_ID"]
                                                          , dataRow["ESTTERM_REF_ID"]
                                                          , dataRow["ESTTERM_SUB_ID"]
                                                          , dataRow["ESTTERM_STEP_ID"]
                                                          , dataRow["EST_DEPT_ID"]
                                                          , dataRow["EST_EMP_ID"]
                                                          , dataRow["TGT_DEPT_ID"]
                                                          , dataRow["TGT_EMP_ID"]);
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

        public bool IsExist(  int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id)
        {
            int affectedRow = 0;

            affectedRow = _empEstTargetMap.Count( null
                                                , null
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , est_dept_id
                                                , est_emp_id
                                                , tgt_dept_id
                                                , tgt_emp_id);

            if (affectedRow > 0)
                return true;

            return false;
        }

        public DataTable GetDataTableSchema()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("COMP_ID", typeof(int));
            dataTable.Columns.Add("EST_ID", typeof(string));
            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_SUB_ID", typeof(int));
            dataTable.Columns.Add("ESTTERM_STEP_ID", typeof(int));
            dataTable.Columns.Add("EST_DEPT_ID", typeof(int));
            dataTable.Columns.Add("EST_EMP_ID", typeof(int));
            dataTable.Columns.Add("TGT_DEPT_ID", typeof(int));
            dataTable.Columns.Add("TGT_EMP_ID", typeof(int));
            dataTable.Columns.Add("TGT_POS_CLS_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_CLS_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_DUT_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_DUT_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_GRP_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_GRP_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_RNK_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_RNK_NAME", typeof(string));
            dataTable.Columns.Add("TGT_POS_KND_ID", typeof(string));
            dataTable.Columns.Add("TGT_POS_KND_NAME", typeof(string));
            dataTable.Columns.Add("DIRECTION_TYPE", typeof(string));
            dataTable.Columns.Add("STATUS_ID", typeof(string));
            dataTable.Columns.Add("STATUS_DATE", typeof(DateTime));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}
