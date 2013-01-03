using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.PRJ.Dac;
using MicroBSC.Data;
using MicroBSC.Estimation.Dac;
using MicroBSC.Estimation.Biz;

namespace MicroBSC.PRJ.Biz
{
    public class Biz_Prj_Data
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
        private float _point;
        private DateTime _point_date;
        private string _status_id;
        private DateTime _status_date;
        private DateTime _update_date;
        private int _update_user;

        private Dac_Prj_Data _data = new Dac_Prj_Data();

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

        public float Point
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

        public DateTime Point_Date
        {
            get
            {
                return _point_date;
            }
            set
            {
                _point_date = value;
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

        public DateTime Status_Date
        {
            get
            {
                return _status_date;
            }
            set
            {
                _status_date = value;
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

        public Biz_Prj_Data()
        {

        }

        public Biz_Prj_Data(int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int estterm_step_id
                        , int est_dept_id
                        , int est_emp_id
                        , int prj_ref_id)
        {
            DataSet ds = GetPrjData(comp_id 
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , prj_ref_id
                                    , ""
                                    , "");

            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];
                _comp_id            = DataTypeUtility.GetToInt32(dr["COMP_ID"]);
                _est_id             = DataTypeUtility.GetValue(dr["EST_ID"]);
                _estterm_ref_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_REF_ID"]);
                _estterm_sub_id     = DataTypeUtility.GetToInt32(dr["ESTTERM_SUB_ID"]);
                _estterm_step_id    = DataTypeUtility.GetToInt32(dr["ESTTERM_STEP_ID"]);
                _est_dept_id        = DataTypeUtility.GetToInt32(dr["EST_DEPT_ID"]);
                _est_emp_id         = DataTypeUtility.GetToInt32(dr["EST_EMP_ID"]);
                _prj_ref_id         = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _point              = DataTypeUtility.GetToFloat(dr["POINT"]);
                _point_date         = DataTypeUtility.GetToDateTime(dr["POINT_DATE"]);
                _status_id          = DataTypeUtility.GetValue(dr["STATUS_ID"]);
                _status_date        = DataTypeUtility.GetToDateTime(dr["STATUS_DATE"]);
                _update_date        = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
                _update_user        = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
            }
        }

        public bool ModifyData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int prj_ref_id
                                , float point
                                , DateTime point_date
                                , string status_id
                                , DateTime status_date
                                , DateTime update_date
                                , int update_user)
        {
            int affectedRow = 0;

            affectedRow = _data.Update(null
                                        , null
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , est_dept_id
                                        , est_emp_id
                                        , prj_ref_id
                                        , point
                                        , point_date
                                        , status_id
                                        , status_date
                                        , update_date
                                        , update_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool ConfirmGrade(DataTable dataTable)
        {
            int affectedRow = 0;

            //IDbConnection conn = DbAgentHelper.CreateDbConnection();
            //conn.Open();
            //IDbTransaction trx = conn.BeginTransaction();

            //try
            //{
            //    foreach(DataRow dataRow in dataTable.Rows) 
            //    {
            //        affectedRow += _data.Update(  conn
            //                                    , trx
            //                                    , dataRow["EST_ID"]
            //                                    , dataRow["ESTTERM_REF_ID"]
            //                                    , dataRow["ESTTERM_SUB_ID"]
            //                                    , dataRow["ESTTERM_STEP_ID"]
            //                                    , dataRow["EST_DEPT_ID"]
            //                                    , dataRow["EST_EMP_ID"]
            //                                    , dataRow["TGT_DEPT_ID"]
            //                                    , dataRow["TGT_EMP_ID"]
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , dataRow["GRADE_ID"]
            //                                    , dataRow["GRADE_DATE"]
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , dataRow["DATE"]
            //                                    , dataRow["USER"]);
            //    }

            //    trx.Commit();
            //}
            //catch ( Exception ex )
            //{
            //    trx.Rollback();
            //    return false;
            //}
            //finally
            //{
            //    conn.Close();
            //}

            return (affectedRow > 0) ? true : false;
        }

        public bool GradeToPoint(DataTable dataTable)
        {
            int affectedRow = 0;

            //IDbConnection conn = DbAgentHelper.CreateDbConnection();
            //conn.Open();
            //IDbTransaction trx = conn.BeginTransaction();

            //try
            //{
            //    foreach(DataRow dataRow in dataTable.Rows) 
            //    {
            //        affectedRow += _data.Update(  conn
            //                                    , trx
            //                                    , dataRow["EST_ID"]
            //                                    , dataRow["ESTTERM_REF_ID"]
            //                                    , dataRow["ESTTERM_SUB_ID"]
            //                                    , dataRow["ESTTERM_STEP_ID"]
            //                                    , dataRow["EST_DEPT_ID"]
            //                                    , dataRow["EST_EMP_ID"]
            //                                    , dataRow["TGT_DEPT_ID"]
            //                                    , dataRow["TGT_EMP_ID"]
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , dataRow["GRADE_TO_POINT"]
            //                                    , dataRow["GRADE_TO_POINT_DATE"]
            //                                    , DBNull.Value
            //                                    , DBNull.Value
            //                                    , dataRow["DATE"]
            //                                    , dataRow["USER"]);
            //    }

            //    trx.Commit();
            //}
            //catch ( Exception ex )
            //{
            //    trx.Rollback();
            //    return false;
            //}
            //finally
            //{
            //    conn.Close();
            //}

            return (affectedRow > 0) ? true : false;
        }

        public DataSet GetData( int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int prj_ref_id)
        {
            return _data.Select(comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id
                                , estterm_step_id
                                , est_dept_id
                                , est_emp_id
                                , prj_ref_id
                                , ""
                                , "");
        }

        public string GetBiasQueryScript( string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , string bias_type)
        {
            return _data.SelectBiasDataScript(est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , 0
                                            , bias_type);
        }

        public DataSet GetPrjData(int comp_id
                                        ,string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_dept_id
                                        , int est_emp_id
                                        , int prj_ref_id
                                        , string year_yn
                                        , string merge_yn)
        {
            return GetPrjData(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , 0
                                    , 0
                                    , est_emp_id
                                    , prj_ref_id
                                    , ""
                                    , "");
        }


        public DataSet GetPrjData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int est_dept_id
                                , int est_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , int prj_ref_id
                                , string year_yn
                                , string merge_yn)
        {
            return _data.SelectPrjData(comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , tgt_dept_id
                                    , tgt_emp_id
                                    , prj_ref_id
                                    , year_yn
                                    , merge_yn);
        }

        public bool AddData(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int prj_ref_id
                            , float point
                            , DateTime point_date
                            , string status_id
                            , DateTime status_date
                            , DateTime create_date
                            , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _data.Insert(null
                                    , null
                                    , comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , prj_ref_id
                                    , point
                                    , point_date
                                    , status_id
                                    , status_date
                                    , create_date
                                    , create_user);

            return (affectedRow > 0) ? true : false;
        }

        public bool CopyTgtMapDataToEstData(DataTable dataTable)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

			try
			{
                if(dataTable.Rows.Count > 0) 
                {
                    affectedRow += _data.Delete(  conn
                                                , trx
                                                , dataTable.Rows[0]["COMP_ID"]
                                                , dataTable.Rows[0]["EST_ID"]
                                                , dataTable.Rows[0]["ESTTERM_REF_ID"]
                                                , dataTable.Rows[0]["ESTTERM_SUB_ID"]
                                                , dataTable.Rows[0]["ESTTERM_STEP_ID"]
                                                , 0
                                                , 0
                                                , 0
                                                , "N"
                                                , "N");
                }

                foreach(DataRow dataRow in dataTable.Rows) 
                {
                    affectedRow += _data.Insert(  conn
                                                , trx
                                                , dataRow["COMP_ID"]
                                                , dataRow["EST_ID"]
                                                , dataRow["ESTTERM_REF_ID"]
                                                , dataRow["ESTTERM_SUB_ID"]
                                                , dataRow["ESTTERM_STEP_ID"]
                                                , dataRow["EST_DEPT_ID"]
                                                , dataRow["EST_EMP_ID"]
                                                , dataRow["PRJ_REF_ID"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "N"
                                                , dataRow["DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
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

        public bool RemoveData(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int prj_ref_id
                            , string year_yn
                            , string merge_yn)
        {
            int affectedRow = 0;

            affectedRow = _data.Delete(null
                                    , null
                                    , comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , prj_ref_id
                                    , year_yn
                                    , merge_yn);

            return (affectedRow > 0) ? true : false;
        }

        public bool IsExist(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int prj_ref_id)
        {
            int affectedRow = 0;

            affectedRow = _data.Count(comp_id
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

        /// <summary>
        /// 평가의 상태를 바꿈
        /// </summary>
        /// <param name="dtEstQ"></param>
        /// <returns></returns>
        public bool SaveStatus(DataTable dtEstQ)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dtEstQ.Rows)
                {
                    affectedRow += _data.Update(conn
                                                , trx
                                                , dataRow["COMP_ID"]
                                                , dataRow["EST_ID"]
                                                , dataRow["ESTTERM_REF_ID"]
                                                , dataRow["ESTTERM_SUB_ID"]
                                                , dataRow["ESTTERM_STEP_ID"]
                                                , dataRow["EST_DEPT_ID"]
                                                , dataRow["EST_EMP_ID"]
                                                , dataRow["PRJ_REF_ID"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , dataRow["STATUS_ID"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]
                                                , dataRow["DATE"]);
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


        public DataSet GetDataByMergeYN(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , string merge_yn)
        {
            return _data.Select(comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id
                                , estterm_step_id
                                , 0
                                , 0
                                , 0
                                , ""
                                , merge_yn);
        }

        /// <summary>
        /// 평가차수에 따른 점수를 가중치로 계산하여 집계하는 메소드
        /// </summary>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="estterm_sub_id"></param>
        /// <returns></returns>
        public bool AggregateEstTermStepEstData(int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id_merge_y
                                                , double total_weight_estterm_step
                                                , string year_yn
                                                , string merge_yn)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                // 존재하는 테이터를 우선 삭제한다.
                affectedRow += _data.Delete(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , BizUtility.GetEstTermStepIDByMergeYN(comp_id)
                                            , 0
                                            , 0
                                            , 0
                                            , year_yn
                                            , "Y");

                DataTable dtBlank = GetDataTableSchema();
                DataRow dataRow = null;

                DataTable dtPrjData = _data.SelectPrjData(comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , year_yn
                                                        , merge_yn).Tables[0];

                foreach (DataRow drPrjData in dtPrjData.Rows)
                {
                    // 빈 데이터 테이블에 존재하는 피평가 대상자 있는 지 확인 후
                    // 있다면 존재하는 데이터에 가중치를 계산하여 수정하지만
                    // 존재하지 않다면 새로운 데이터 Row를 생성하여 삽입한다.
                    DataRow[] drArr = dtBlank.Select(string.Format(@"COMP_ID         = {0}
                                                                AND EST_ID          = '{1}'
                                                                AND ESTTERM_REF_ID  = {2}
                                                                AND ESTTERM_SUB_ID  = {3}
                                                                AND ESTTERM_STEP_ID = {4}
                                                                AND PRJ_REF_ID      = {5}"
                                                                , drPrjData["COMP_ID"]
                                                                , drPrjData["EST_ID"]
                                                                , drPrjData["ESTTERM_REF_ID"]
                                                                , drPrjData["ESTTERM_SUB_ID"]
                                                                , estterm_step_id_merge_y
                                                                , drPrjData["PRJ_REF_ID"]));

                    if (drArr.Length == 0)
                    {
                        dataRow = dtBlank.NewRow();
                    }
                    else
                    {
                        dataRow = drArr[0];
                    }

                    dataRow["COMP_ID"] = drPrjData["COMP_ID"];
                    dataRow["EST_ID"] = drPrjData["EST_ID"];
                    dataRow["ESTTERM_REF_ID"] = drPrjData["ESTTERM_REF_ID"];
                    dataRow["ESTTERM_SUB_ID"] = drPrjData["ESTTERM_SUB_ID"];
                    dataRow["ESTTERM_STEP_ID"] = BizUtility.GetEstTermStepIDByMergeYN(comp_id);
                    dataRow["EST_DEPT_ID"] = drPrjData["EST_DEPT_ID"];
                    dataRow["EST_EMP_ID"] = drPrjData["EST_EMP_ID"];
                    dataRow["PRJ_REF_ID"] = drPrjData["PRJ_REF_ID"];
                    dataRow["POINT"] = DataTypeUtility.GetToDouble(dataRow["POINT"])
                                                        + DataTypeUtility.GetToDouble(drPrjData["POINT"])
                                                            * (DataTypeUtility.GetToDouble(drPrjData["WEIGHT_ESTTERM_STEP"]) / total_weight_estterm_step);
                    dataRow["POINT_DATE"] = DateTime.Now;
                    dataRow["STATUS_ID"] = "E";
                    dataRow["STATUS_DATE"] = DateTime.Now;
                    dataRow["DATE"] = DateTime.Now; 
                    dataRow["USER"] = drPrjData["UPDATE_USER"];

                    if (drArr.Length == 0)
                    {
                        dtBlank.Rows.Add(dataRow);
                    }
                }

                foreach (DataRow drBlank in dtBlank.Rows)
                {
                    affectedRow += _data.Insert(conn
                                                , trx
                                                , drBlank["COMP_ID"]
                                                , drBlank["EST_ID"]
                                                , drBlank["ESTTERM_REF_ID"]
                                                , drBlank["ESTTERM_SUB_ID"]
                                                , drBlank["ESTTERM_STEP_ID"]
                                                , drBlank["EST_DEPT_ID"]
                                                , drBlank["EST_EMP_ID"]
                                                , drBlank["PRJ_REF_ID"]
                                                , drBlank["POINT"]
                                                , drBlank["POINT_DATE"]
                                                , drBlank["STATUS_ID"]
                                                , drBlank["STATUS_DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
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

        /// <summary>
        /// 프로젝트 점수를 개인 점수로 재분재하는 메소드
        /// </summary>
        /// <param name="comp_id"></param>
        /// <param name="est_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="estterm_sub_id"></param>
        /// <param name="estterm_step_id"></param>
        /// <param name="create_date"></param>
        /// <param name="create_user"></param>
        /// <returns></returns>
        public bool CopyProjectToEmpData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string year_yn
                                    , string merge_yn
                                    , DateTime create_date
                                    , int create_user)
        {

            Dac_EstInfos estInfo        = new Dac_EstInfos();
            Dac_EstDetails estDetail    = new Dac_EstDetails();
            Dac_Datas  estData          = new Dac_Datas();
            Biz_Datas bizEstData        = new Biz_Datas();

            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                // 기존에 존재하는 사원평가 데이터를 삭제한다.
                affectedRow         += estData.Delete(conn
                                                    , trx
                                                    , comp_id
                                                    , est_id
                                                    , estterm_ref_id
                                                    , estterm_sub_id
                                                    , estterm_step_id
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , year_yn
                                                    , merge_yn
                                                    , OwnerType.Emp_User);


                DataTable dtBlank = bizEstData.GetDataTableSchema();
                DataRow dataRow = null;

                
                DataTable dtPrjData = _data.SelectPrjData(comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , 0
                                                        , year_yn
                                                        , merge_yn).Tables[0];

                foreach (DataRow drPrjData in dtPrjData.Rows)
                {
                    ////구성원사원정보
                    //Biz_Prj_Resource objResource = new Biz_Prj_Resource();

                    //DataTable dtRes = objResource.GetAllList(DataTypeUtility.GetToInt32(drPrjData["PRJ_REF_ID"]), 0).Tables[0];

                    //foreach(DataRow drRes in dtRes.Rows)
                    //{
                        dataRow = dtBlank.NewRow();

                        dataRow["COMP_ID"]              = drPrjData["COMP_ID"];
                        dataRow["EST_ID"]               = drPrjData["EST_ID"];
                        dataRow["ESTTERM_REF_ID"]       = drPrjData["ESTTERM_REF_ID"];
                        dataRow["ESTTERM_SUB_ID"]       = drPrjData["ESTTERM_SUB_ID"];
                        dataRow["ESTTERM_STEP_ID"]      = drPrjData["ESTTERM_STEP_ID"];
                        dataRow["EST_DEPT_ID"]          = drPrjData["EST_DEPT_ID"];
                        dataRow["EST_EMP_ID"]           = drPrjData["EST_EMP_ID"];

                        //dataRow["TGT_DEPT_ID"]          = drRes["TGT_DEPT_ID"];
                        //dataRow["TGT_EMP_ID"]           = drRes["TGT_EMP_ID"];
                        //dataRow["TGT_POS_CLS_ID"]       = drRes["TGT_POS_CLS_ID"];
                        //dataRow["TGT_POS_CLS_NAME"]     = drRes["TGT_POS_CLS_NAME"];
                        //dataRow["TGT_POS_DUT_ID"]       = drRes["TGT_POS_DUT_ID"];
                        //dataRow["TGT_POS_DUT_NAME"]     = drRes["TGT_POS_DUT_NAME"];
                        //dataRow["TGT_POS_GRP_ID"]       = drRes["TGT_POS_GRP_ID"];
                        //dataRow["TGT_POS_GRP_NAME"]     = drRes["TGT_POS_GRP_NAME"];
                        //dataRow["TGT_POS_RNK_ID"]       = drRes["TGT_POS_RNK_ID"];
                        //dataRow["TGT_POS_RNK_NAME"]     = drRes["TGT_POS_RNK_NAME"];

                        dataRow["TGT_DEPT_ID"]          = drPrjData["TGT_DEPT_ID"];
                        dataRow["TGT_EMP_ID"]           = drPrjData["TGT_EMP_ID"];
                        dataRow["TGT_POS_CLS_ID"]       = drPrjData["TGT_POS_CLS_ID"];
                        dataRow["TGT_POS_CLS_NAME"]     = drPrjData["TGT_POS_CLS_NAME"];
                        dataRow["TGT_POS_DUT_ID"]       = drPrjData["TGT_POS_DUT_ID"];
                        dataRow["TGT_POS_DUT_NAME"]     = drPrjData["TGT_POS_DUT_NAME"];
                        dataRow["TGT_POS_GRP_ID"]       = drPrjData["TGT_POS_GRP_ID"];
                        dataRow["TGT_POS_GRP_NAME"]     = drPrjData["TGT_POS_GRP_NAME"];
                        dataRow["TGT_POS_RNK_ID"]       = drPrjData["TGT_POS_RNK_ID"];
                        dataRow["TGT_POS_RNK_NAME"]     = drPrjData["TGT_POS_RNK_NAME"];
                        dataRow["TGT_POS_KND_ID"]       = drPrjData["TGT_POS_KND_ID"];
                        dataRow["TGT_POS_KND_NAME"]     = drPrjData["TGT_POS_KND_NAME"];

                        dataRow["POINT_ORG"]            = DBNull.Value;
                        dataRow["POINT_ORG_DATE"]       = DBNull.Value;
                        dataRow["POINT_AVG"]            = DBNull.Value;
                        dataRow["POINT_AVG_DATE"]       = DBNull.Value;
                        dataRow["POINT_STD"]            = DBNull.Value;
                        dataRow["POINT_STD_DATE"]       = DBNull.Value;
                        dataRow["POINT"]                = drPrjData["POINT"];
                        dataRow["POINT_DATE"]           = drPrjData["POINT_DATE"];
                        dataRow["GRADE_ID"]             = DBNull.Value;
                        dataRow["GRADE_DATE"]           = DBNull.Value;
                        dataRow["GRADE_TO_POINT"]       = DBNull.Value;
                        dataRow["GRADE_TO_POINT_DATE"]  = DBNull.Value;
                        dataRow["STATUS_ID"]            = "E";
                        dataRow["STATUS_DATE"]          = create_date;
                        dataRow["DATE"]                 = create_date;
                        dataRow["USER"]                 = create_user;


                        dtBlank.Rows.Add(dataRow);
                    //}
                }

                foreach (DataRow drBlank in dtBlank.Rows)
                {
                    affectedRow += estData.Insert(conn
                                                , trx
                                                , drBlank["COMP_ID"]
                                                , drBlank["EST_ID"]
                                                , drBlank["ESTTERM_REF_ID"]
                                                , drBlank["ESTTERM_SUB_ID"]
                                                , drBlank["ESTTERM_STEP_ID"]
                                                , drBlank["EST_DEPT_ID"]
                                                , drBlank["EST_EMP_ID"]
                                                , drBlank["TGT_DEPT_ID"]
                                                , drBlank["TGT_EMP_ID"]
                                                , drBlank["TGT_POS_CLS_ID"]
                                                , drBlank["TGT_POS_CLS_NAME"]
                                                , drBlank["TGT_POS_DUT_ID"]
                                                , drBlank["TGT_POS_DUT_NAME"]
                                                , drBlank["TGT_POS_GRP_ID"]
                                                , drBlank["TGT_POS_GRP_NAME"]
                                                , drBlank["TGT_POS_RNK_ID"]
                                                , drBlank["TGT_POS_RNK_NAME"]
                                                , drBlank["TGT_POS_KND_ID"]
                                                , drBlank["TGT_POS_KND_NAME"]
                                                , DBNull.Value
                                                , drBlank["POINT_ORG"]
                                                , drBlank["POINT_ORG_DATE"]
                                                , drBlank["POINT_AVG"]
                                                , drBlank["POINT_AVG_DATE"]
                                                , drBlank["POINT_STD"]
                                                , drBlank["POINT_STD_DATE"]
                                                , drBlank["POINT_CTRL_ORG"]
                                                , drBlank["POINT_CTRL_ORG_DATE"]
                                                , drBlank["GRADE_CTRL_ORG_ID"]
                                                , drBlank["GRADE_CTRL_ORG_DATE"]
                                                , drBlank["POINT"]
                                                , drBlank["POINT_DATE"]
                                                , drBlank["GRADE_ID"]
                                                , drBlank["GRADE_DATE"]
                                                , drBlank["GRADE_TO_POINT"]
                                                , drBlank["GRADE_TO_POINT_DATE"]
                                                , drBlank["STATUS_ID"]
                                                , drBlank["STATUS_DATE"]
                                                , dataRow["DATE"]
                                                , dataRow["USER"]);
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
            dataTable.Columns.Add("PRJ_REF_ID", typeof(int));
            dataTable.Columns.Add("POINT", typeof(decimal));
            dataTable.Columns.Add("POINT_DATE", typeof(DateTime));
            dataTable.Columns.Add("STATUS_ID", typeof(string));
            dataTable.Columns.Add("STATUS_DATE", typeof(DateTime));
            dataTable.Columns.Add("DATE", typeof(DateTime));
            dataTable.Columns.Add("USER", typeof(int));

            return dataTable;
        }
    }
}