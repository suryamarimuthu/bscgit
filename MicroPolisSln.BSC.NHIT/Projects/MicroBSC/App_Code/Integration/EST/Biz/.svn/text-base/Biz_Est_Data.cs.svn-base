using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.EST.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Data
    {
        #region ============================== [Fields] ==============================

        private Dac_Est_Data _data = new Dac_Est_Data();

        #endregion

        public Biz_Est_Data()
        {

        }

        public int ModifyEstData(DataTable dt)
        {
            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];

                    intTxrCnt += dacEstData.Update_DB(conn
                                                    , trx
                                                    , row["COMP_ID"]
                                                    , row["EST_ID"]
                                                    , row["ESTTERM_REF_ID"]
                                                    , row["ESTTERM_SUB_ID"]
                                                    , row["ESTTERM_STEP_ID"]
                                                    , row["POINT"]);
                }

                trx.Commit();
            }
            catch
            {
                trx.Rollback();
                return 0;
            }
            finally
            {
                conn.Close();
            }

            return intTxrCnt;
        }


        public int ModifyEstData_Point(DataTable dt, int update_user_ref_id)
        {
            int affectedRow = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();

                DataTable dt_insert = dt.Clone();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt_insert.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row[j] = dt.Rows[i][j];
                    }



                    int updateCnt = 0;
                    updateCnt = dacEstData.Update_EstData_Point(conn, trx
                                                                , row["COMP_ID"]
                                                                , row["EST_ID"]
                                                                , row["ESTTERM_REF_ID"]
                                                                , row["ESTTERM_SUB_ID"]
                                                                , row["ESTTERM_STEP_ID"]
                                                                , row["EST_DEPT_ID"]
                                                                , row["EST_EMP_ID"]
                                                                , row["TGT_DEPT_ID"]
                                                                , row["TGT_EMP_ID"]
                                                                , row["POINT_ORG"]
                                                                , row["POINT"]
                                                                , row["POINT_AVG"]
                                                                , row["POINT_STD"]
                                                                , row["POINT_CTRL_ORG"]
                                                                , row["STATUS_ID"]
                                                                , update_user_ref_id);
                    if (updateCnt == 0)
                    {
                        //인서트
                        //affectedRow += AddData(conn, trx
                        //                    , DataTypeUtility.GetToInt32(row["COMP_ID"])
                        //                    , DataTypeUtility.GetString(row["EST_ID"])
                        //                    , DataTypeUtility.GetToInt32(row["ESTTERM_REF_ID"])
                        //                    , DataTypeUtility.GetToInt32(row["ESTTERM_SUB_ID"])
                        //                    , DataTypeUtility.GetToInt32(row["ESTTERM_STEP_ID"])
                        //                    , DataTypeUtility.GetToInt32(row["EST_DEPT_ID"])
                        //                    , DataTypeUtility.GetToInt32(row["EST_EMP_ID"])
                        //                    , DataTypeUtility.GetToInt32(row["TGT_DEPT_ID"])
                        //                    , DataTypeUtility.GetToInt32(row["TGT_EMP_ID"])
                        //                    , DataTypeUtility.GetString(row["POINT_ORG"]).Equals("-1") ? 0 : DataTypeUtility.GetToFloat(row["POINT_ORG"])
                        //                    , System.DateTime.Now
                        //                    , DataTypeUtility.GetString(row["STATUS_ID"])
                        //                    , System.DateTime.Now
                        //                    , System.DateTime.Now
                        //                    , update_user_ref_id) ? 1 : 0;
                        dt_insert.Rows.Add(row);
                        

                    }
                    else
                    {
                        affectedRow += updateCnt;
                    }
                }


                if (dt_insert.Rows.Count > 0)
                {
                    affectedRow += AddData(conn, trx
                                            , new DataTable()
                                            , dt_insert
                                            , update_user_ref_id);
                }

                trx.Commit();
            }
            catch(Exception ex)
            {
                trx.Rollback();
                affectedRow = 0;
            }
            finally
            {
                conn.Close();
            }

            return affectedRow;
        }



        public int ModifyEstData_Point(IDbConnection conn, IDbTransaction trx, DataTable dt, int update_user_ref_id)
        {
            int intTxrCnt = 0;

            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                intTxrCnt += dacEstData.Update_EstData_Point(conn
                                                            , trx
                                                            , row["COMP_ID"]
                                                            , row["EST_ID"]
                                                            , row["ESTTERM_REF_ID"]
                                                            , row["ESTTERM_SUB_ID"]
                                                            , row["ESTTERM_STEP_ID"]
                                                            , row["EST_DEPT_ID"]
                                                            , row["EST_EMP_ID"]
                                                            , row["TGT_DEPT_ID"]
                                                            , row["TGT_EMP_ID"]
                                                            , row["POINT_ORG"]
                                                            , row["POINT"]
                                                            , row["POINT_AVG"]
                                                            , row["POINT_STD"]
                                                            , row["POINT_CTRL_ORG"]
                                                            , row["STATUS_ID"]
                                                            , update_user_ref_id);
            }

            return intTxrCnt;
        }



        public DataTable GetEstData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id)
        {
            return GetEstData(comp_id
                                           , est_id
                                           , estterm_ref_id
                                           , estterm_sub_id
                                           , estterm_step_id
                                           , "");
        }

        public DataTable GetEstData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string direction_type)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();
            return dacEstData.SelectData_DB(comp_id
                                           , est_id
                                           , estterm_ref_id
                                           , estterm_sub_id
                                           , estterm_step_id
                                           , direction_type);
        }

        public DataTable GetEstData(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string direction_type
                                    , int est_emp_id
                                    , int tgt_emp_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();
            return dacEstData.SelectData_DB(comp_id
                                           , est_id
                                           , estterm_ref_id
                                           , estterm_sub_id
                                           , estterm_step_id
                                           , direction_type
                                           , est_emp_id
                                           , tgt_emp_id);
        }

        public DataTable GetEstGraph_DB(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int tgt_emp_id
                                    , string estid_1
                                    , string estid_2
                                    , string yid1
                                    , string yid2
                                    , string yid3)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();
            return dacEstData.SelectGraph_DB(comp_id
                                           , est_id
                                           , estterm_ref_id
                                           , estterm_sub_id
                                           , estterm_step_id
                                           , tgt_emp_id
                                           , estid_1
                                              , estid_2
                                              , yid1
                                              , yid2
                                              , yid3);
        }

        public string RemoveEstDataWithJoin_DB()
        {

            string returnVal = string.Empty;



            return returnVal;
        }

        public int RemoveEstData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();
            return dacEstData.Delete(null
                                , null
                                , comp_id
                                , est_id
                                , estterm_ref_id
                                , estterm_sub_id);
        }

        public string RemoveEstData(DataTable dtDel
                                , int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , string direction_type)
        {
            Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();

            string returnVal = string.Empty;

            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();

                for (int i = 0; i < dtDel.Rows.Count; i++)
                {
                    DataRow row = dtDel.Rows[i];

                    intTxrCnt += dacEstData.Delete(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , row["TGT_EMP_ID"]
                                                , direction_type);
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                returnVal = ex.Message;
                trx.Rollback();
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }



        public string AddData(DataTable dtDel
                            , DataTable dtEmp
                            , int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , string direction_type
                            , string status_id
                            , DateTime status_date
                            , DateTime create_date
                            , int create_user)
        {
            Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();

            string returnVal = string.Empty;

            int intTxrCnt = 0;
            int updateCnt = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();

                for (int i = 0; i < dtDel.Rows.Count; i++)
                {
                    DataRow row = dtDel.Rows[i];

                    int delCnt = dacEstData.Delete(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id
                                                , row["TGT_EMP_ID"]
                                                , direction_type);
                }
                

                for (int i = 0; i < dtEmp.Rows.Count; i++)
                {
                    DataRow row = dtEmp.Rows[i];

                    intTxrCnt += dacEstData.Insert(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , row["EST_DEPT_ID"]
                                            , row["EST_EMP_ID"]
                                            , row["TGT_DEPT_ID"]
                                            , row["TGT_EMP_ID"]
                                            , row["TGT_POS_CLS_ID"]
                                            , row["TGT_POS_CLS_NAME"]
                                            , row["TGT_POS_DUT_ID"]
                                            , row["TGT_POS_DUT_NAME"]
                                            , row["TGT_POS_GRP_ID"]
                                            , row["TGT_POS_GRP_NAME"]
                                            , row["TGT_POS_RNK_ID"]
                                            , row["TGT_POS_RNK_NAME"]
                                            , row["TGT_POS_KND_ID"]
                                            , row["TGT_POS_KND_NAME"]
                                            , direction_type
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , status_id
                                            , status_date
                                            , create_date
                                            , create_user);
                }

                trx.Commit();
            }
            catch(Exception ex)
            {
                returnVal = ex.Message;
                trx.Rollback();
                return ex.Message ;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }



        /// <summary>
        /// 포인트 개인 집계 후 데이터 추가
        /// </summary>
        /// <param name="point_org_date">yyyy-MM-dd</param>
        /// <param name="point_date">yyyy-MM-dd</param>
        /// <param name="status_date">yyyy-MM-dd</param>
        /// <param name="create_date">yyyy-MM-dd</param>
        public bool AddData(DataTable dtDel
                            , DataTable dtEmp
                            , int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , string direction_type
                            , string status_id
                            , DateTime point_org_date
                            , DateTime point_date
                            , DateTime status_date
                            , DateTime create_date
                            , int create_user)
        {
            int delCnt = 0;
            int insertCnt = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                insertCnt = AddData(conn, trx, dtDel, dtEmp, comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, est_dept_id, est_emp_id, direction_type, status_id, point_org_date, point_date, status_date, create_date, create_user);

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                insertCnt = 0;
            }
            finally
            {
                conn.Close();
            }

            return insertCnt > 0 ? true : false;
        }


        public int AddData(IDbConnection conn, IDbTransaction trx
                            , DataTable dtDel
                            , DataTable dtEmp
                            , int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , string direction_type
                            , string status_id
                            , DateTime point_org_date
                            , DateTime point_date
                            , DateTime status_date
                            , DateTime create_date
                            , int create_user)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();
            int insertCnt = 0;
            int delCnt = 0;

            for (int i = 0; i < dtDel.Rows.Count; i++)
            {
                DataRow row = dtDel.Rows[i];

                delCnt = dacEstData.Delete(conn
                                        , trx
                                        , comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , row["TGT_EMP_ID"]
                                        , direction_type);
            }


            for (int i = 0; i < dtEmp.Rows.Count; i++)
            {
                DataRow row = dtEmp.Rows[i];

                insertCnt += dacEstData.Insert(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_dept_id
                                            , est_emp_id
                                            , row["TGT_DEPT_ID"]
                                            , row["TGT_EMP_ID"]
                                            , row["TGT_POS_CLS_ID"]
                                            , row["TGT_POS_CLS_NAME"]
                                            , row["TGT_POS_DUT_ID"]
                                            , row["TGT_POS_DUT_NAME"]
                                            , row["TGT_POS_GRP_ID"]
                                            , row["TGT_POS_GRP_NAME"]
                                            , row["TGT_POS_RNK_ID"]
                                            , row["TGT_POS_RNK_NAME"]
                                            , row["TGT_POS_KND_ID"]
                                            , row["TGT_POS_KND_NAME"]
                                            , direction_type
                                            , row["POINT_ORG"]
                                            , point_org_date
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , row["POINT"]
                                            , point_date
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , status_id
                                            , status_date
                                            , create_date
                                            , create_user);
            }

            return insertCnt;
        }



        public int AddData(IDbConnection conn, IDbTransaction trx
                            , DataTable dtDel
                            , DataTable dtEmp
                            , int create_user)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();
            int insertCnt = 0;
            int delCnt = 0;

            for (int i = 0; i < dtDel.Rows.Count; i++)
            {
                DataRow row = dtDel.Rows[i];

                delCnt = dacEstData.Delete(conn, trx
                                        , row["COMP_ID"]
                                        , row["EST_ID"]
                                        , row["ESTTERM_REF_ID"]
                                        , row["ESTTERM_SUB_ID"]
                                        , row["ESTTERM_STEP_ID"]
                                        , row["TGT_EMP_ID"]
                                        , row["DIRECTION_TYPE"]);
            }


            for (int i = 0; i < dtEmp.Rows.Count; i++)
            {
                DataRow row = dtEmp.Rows[i];

                insertCnt += dacEstData.Insert(conn, trx
                                            , row["COMP_ID"]
                                            , row["EST_ID"]
                                            , row["ESTTERM_REF_ID"]
                                            , row["ESTTERM_SUB_ID"]
                                            , row["ESTTERM_STEP_ID"]
                                            , row["EST_DEPT_ID"]
                                            , row["ESTTERM_STEP_ID"]
                                            , row["TGT_DEPT_ID"]
                                            , row["TGT_EMP_ID"]
                                            , row["TGT_POS_CLS_ID"]
                                            , row["TGT_POS_CLS_NAME"]
                                            , row["TGT_POS_DUT_ID"]
                                            , row["TGT_POS_DUT_NAME"]
                                            , row["TGT_POS_GRP_ID"]
                                            , row["TGT_POS_GRP_NAME"]
                                            , row["TGT_POS_RNK_ID"]
                                            , row["TGT_POS_RNK_NAME"]
                                            , row["TGT_POS_KND_ID"]
                                            , row["TGT_POS_KND_NAME"]
                                            , row["DIRECTION_TYPE"]
                                            , row["POINT_ORG"]
                                            , System.DateTime.Now
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , row["POINT"]
                                            , System.DateTime.Now
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , DBNull.Value
                                            , row["STATUS_ID"]
                                            , System.DateTime.Now
                                            , System.DateTime.Now
                                            , create_user);
            }

            return insertCnt;
        }






        public bool AddData(IDbConnection conn, IDbTransaction trx
                            , int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , float point_org
                            , DateTime point_org_date
                            , string status_id
                            , DateTime status_date
                            , DateTime create_date
                            , int create_user)
        {
            int affectedRow = 0;

            affectedRow = _data.Insert(conn, trx
                                    , comp_id
                                    , est_id
                                    , estterm_ref_id
                                    , estterm_sub_id
                                    , estterm_step_id
                                    , est_dept_id
                                    , est_emp_id
                                    , tgt_dept_id
                                    , tgt_emp_id
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , point_org
                                    , point_org_date
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , DBNull.Value
                                    , status_id
                                    , status_date
                                    , create_date
                                    , create_user);

            return (affectedRow > 0) ? true : false;
        }
        public bool AddData(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , int estterm_step_id
                            , int est_dept_id
                            , int est_emp_id
                            , int tgt_dept_id
                            , int tgt_emp_id
                            , float point_org
                            , DateTime point_org_date
                            , string status_id
                            , DateTime status_date
                            , DateTime create_date
                            , int create_user)
        {
            return AddData(null, null
                            , comp_id
                            , est_id
                            , estterm_ref_id
                            , estterm_sub_id
                            , estterm_step_id
                            , est_dept_id
                            , est_emp_id
                            , tgt_dept_id
                            , tgt_emp_id
                            , point_org
                            , point_org_date
                            , status_id
                            , status_date
                            , create_date
                            , create_user);
        }


        public bool AggregateEstTermStepEstData(int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id_merge_y
                                                , double total_weight_estterm_step
                                                , string year_yn
                                                , string merge_yn
                                                , OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                // 존재하는 테이터를 우선 삭제한다.
                //affectedRow += _data.Delete(conn
                //                            , trx
                //                            , comp_id
                //                            , est_id
                //                            , estterm_ref_id
                //                            , estterm_sub_id
                //                            , estterm_step_id_merge_y
                //                            , 0
                //                            , 0
                //                            , 0
                //                            , 0
                //                            , year_yn
                //                            , "Y"
                //                            , ownerType);

                affectedRow += Remove_Est_Data_Join_MappingData(conn
                                                , trx
                                                , comp_id
                                                , est_id
                                                , estterm_ref_id
                                                , estterm_sub_id
                                                , estterm_step_id_merge_y
                                                , 0
                                                , 0
                                                , 0
                                                , 0
                                                , year_yn
                                                , "Y"
                                                , ownerType);
                MicroBSC.Estimation.Biz.Biz_Datas bizDatas = new MicroBSC.Estimation.Biz.Biz_Datas();
                DataTable dtBlank = bizDatas.GetDataTableSchema();
                DataRow dataRow = null;

                MicroBSC.Estimation.Dac.Dac_Datas dacDatas = new MicroBSC.Estimation.Dac.Dac_Datas();
                DataTable dtEstData = dacDatas.SelectEstData(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , year_yn
                                                            , merge_yn
                                                            , ownerType
                                                            , "").Tables[0];


                //----------------------- 상향평가 가중치 적용 체크

                MicroBSC.Estimation.Biz.Biz_EstInfos estInfo = new MicroBSC.Estimation.Biz.Biz_EstInfos(comp_id, est_id);
                DataTable dtTgtEmp = null;
                DataTable dtTgtAllSum = null;
                double fixed_weight = 0;

                if (DataTypeUtility.GetYNToBoolean(estInfo.Fixed_Weight_Use_YN))
                {
                    fixed_weight = DataTypeUtility.GetToDouble(estInfo.Fixed_Weight);
                    DataTable dtFilterData = DataTypeUtility.FilterSortDataTable(dtEstData, "FIXED_WEIGHT_YN = 'Y'");

                    dtTgtEmp = DataTypeUtility.GetGroupByDataTable(dtFilterData
                                                                                , "WEIGHT_ESTTERM_STEP"
                                                                                , new string[] { "COMP_ID", "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "TGT_DEPT_ID", "TGT_EMP_ID" }
                                                                                , "WEIGHT_ESTTERM_STEP");

                    foreach (DataRow drTgtEmp in dtTgtEmp.Rows)
                    {
                        DataRow[] drArrEstData = dtEstData.Select(string.Format(@"COMP_ID         = {0}
                                                                                AND EST_ID          = '{1}'
                                                                                AND ESTTERM_REF_ID  = {2}
                                                                                AND ESTTERM_SUB_ID  = {3}
                                                                                AND TGT_DEPT_ID     = {4}
                                                                                AND TGT_EMP_ID      = {5}"
                                                                                , drTgtEmp["COMP_ID"]
                                                                                , drTgtEmp["EST_ID"]
                                                                                , drTgtEmp["ESTTERM_REF_ID"]
                                                                                , drTgtEmp["ESTTERM_SUB_ID"]
                                                                                , drTgtEmp["TGT_DEPT_ID"]
                                                                                , drTgtEmp["TGT_EMP_ID"]));

                        // 상향평가 가중치를 재계산 한다. 
                        foreach (DataRow drEstData in drArrEstData)
                        {
                            if (DataTypeUtility.GetValue(drEstData["FIXED_WEIGHT_YN"]).Equals("Y"))
                                drEstData["WEIGHT_ESTTERM_STEP"] = DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / DataTypeUtility.GetToDouble(drTgtEmp["SUM_WEIGHT_ESTTERM_STEP"]) * fixed_weight;
                        }
                    }
                }

                dtTgtAllSum = DataTypeUtility.GetGroupByDataTable(dtEstData
                                                                                , "WEIGHT_ESTTERM_STEP"
                                                                                , new string[] { "COMP_ID", "EST_ID", "ESTTERM_REF_ID", "ESTTERM_SUB_ID", "TGT_DEPT_ID", "TGT_EMP_ID" }
                                                                                , "WEIGHT_ESTTERM_STEP");

                //--------------------------------------------

                foreach (DataRow drEstData in dtEstData.Rows)
                {
                    // 빈 데이터 테이블에 존재하는 피평가 대상자 있는 지 확인 후
                    // 있다면 존재하는 데이터에 가중치를 계산하여 수정하지만
                    // 존재하지 않다면 새로운 데이터 Row를 생성하여 삽입한다.
                    DataRow[] drArr = dtBlank.Select(string.Format(@"COMP_ID         = {0}
                                                                AND EST_ID          = '{1}'
                                                                AND ESTTERM_REF_ID  = {2}
                                                                AND ESTTERM_SUB_ID  = {3}
                                                                AND ESTTERM_STEP_ID = {4}
                                                                AND TGT_DEPT_ID     = {5}
                                                                AND TGT_EMP_ID      = {6}"
                                                                , drEstData["COMP_ID"]
                                                                , drEstData["EST_ID"]
                                                                , drEstData["ESTTERM_REF_ID"]
                                                                , drEstData["ESTTERM_SUB_ID"]
                                                                , estterm_step_id_merge_y
                                                                , drEstData["TGT_DEPT_ID"]
                                                                , drEstData["TGT_EMP_ID"]));

                    DataRow[] drArrSum = dtTgtAllSum.Select(string.Format(@"COMP_ID         = {0}
                                                                    AND EST_ID          = '{1}'
                                                                    AND ESTTERM_REF_ID  = {2}
                                                                    AND ESTTERM_SUB_ID  = {3}
                                                                    AND TGT_DEPT_ID     = {4}
                                                                    AND TGT_EMP_ID      = {5}"
                                                                    , drEstData["COMP_ID"]
                                                                    , drEstData["EST_ID"]
                                                                    , drEstData["ESTTERM_REF_ID"]
                                                                    , drEstData["ESTTERM_SUB_ID"]
                                                                    , drEstData["TGT_DEPT_ID"]
                                                                    , drEstData["TGT_EMP_ID"]));

                    double totalWeight = DataTypeUtility.GetToDouble(drArrSum[0]["SUM_WEIGHT_ESTTERM_STEP"]);

                    if (totalWeight <= 0)
                        return false;

                    if (drArr.Length == 0)
                    {
                        dataRow = dtBlank.NewRow();
                    }
                    else
                    {
                        dataRow = drArr[0];
                    }

                    dataRow["COMP_ID"] = drEstData["COMP_ID"];
                    dataRow["EST_ID"] = drEstData["EST_ID"];
                    dataRow["ESTTERM_REF_ID"] = drEstData["ESTTERM_REF_ID"];
                    dataRow["ESTTERM_SUB_ID"] = drEstData["ESTTERM_SUB_ID"];
                    dataRow["ESTTERM_STEP_ID"] = estterm_step_id_merge_y;
                    dataRow["EST_DEPT_ID"] = drEstData["EST_DEPT_ID"];
                    dataRow["EST_EMP_ID"] = drEstData["EST_EMP_ID"];
                    dataRow["TGT_DEPT_ID"] = drEstData["TGT_DEPT_ID"];
                    dataRow["TGT_EMP_ID"] = drEstData["TGT_EMP_ID"];
                    dataRow["TGT_POS_CLS_ID"] = drEstData["TGT_POS_CLS_ID"];
                    dataRow["TGT_POS_CLS_NAME"] = drEstData["TGT_POS_CLS_NAME"];
                    dataRow["TGT_POS_DUT_ID"] = drEstData["TGT_POS_DUT_ID"];
                    dataRow["TGT_POS_DUT_NAME"] = drEstData["TGT_POS_DUT_NAME"];
                    dataRow["TGT_POS_GRP_ID"] = drEstData["TGT_POS_GRP_ID"];
                    dataRow["TGT_POS_GRP_NAME"] = drEstData["TGT_POS_GRP_NAME"];
                    dataRow["TGT_POS_RNK_ID"] = drEstData["TGT_POS_RNK_ID"];
                    dataRow["TGT_POS_RNK_NAME"] = drEstData["TGT_POS_RNK_NAME"];
                    dataRow["TGT_POS_KND_ID"] = drEstData["TGT_POS_KND_ID"];
                    dataRow["TGT_POS_KND_NAME"] = drEstData["TGT_POS_KND_NAME"];
                    dataRow["DIRECTION_TYPE"] = "SM";
                    dataRow["POINT_ORG"] = DataTypeUtility.GetToDouble(dataRow["POINT_ORG"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_ORG"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_ORG_DATE"] = DBNull.Value;
                    dataRow["POINT_AVG"] = DataTypeUtility.GetToDouble(dataRow["POINT_AVG"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_AVG"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_AVG_DATE"] = DBNull.Value;
                    dataRow["POINT_STD"] = DataTypeUtility.GetToDouble(dataRow["POINT_STD"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_STD"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_STD_DATE"] = DBNull.Value;
                    dataRow["POINT"] = DataTypeUtility.GetToDouble(dataRow["POINT"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_ESTTERM_STEP"]) / totalWeight);
                    dataRow["POINT_DATE"] = DateTime.Now;
                    dataRow["GRADE_ID"] = DBNull.Value;
                    dataRow["GRADE_DATE"] = DBNull.Value;
                    dataRow["GRADE_TO_POINT"] = DBNull.Value;
                    dataRow["GRADE_TO_POINT_DATE"] = DBNull.Value;
                    dataRow["STATUS_ID"] = "E";
                    dataRow["STATUS_DATE"] = drEstData["UPDATE_DATE"];
                    dataRow["DATE"] = drEstData["UPDATE_DATE"];
                    dataRow["USER"] = drEstData["UPDATE_USER"];

                    if (drArr.Length == 0)
                    {
                        dtBlank.Rows.Add(dataRow);
                    }
                }

                foreach (DataRow drBlank in dtBlank.Rows)
                {
                    affectedRow += Add_Est_Data_Join_MappingData(conn
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
                                                                , drBlank["DIRECTION_TYPE"]
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

        public bool AggregateChildEstData(int comp_id
                                        , string parent_est_id
                                        , int parent_estterm_ref_id
                                        , int parent_estterm_sub_id
                                        , int parent_estterm_step_id
                                        , string weightType)
        {
            int affectedRow = 0;

            MicroBSC.Estimation.Biz.Biz_EstInfos estInfo = new MicroBSC.Estimation.Biz.Biz_EstInfos();
            MicroBSC.Estimation.Biz.Biz_DeptEstDetails deptEstDetail = null;
            MicroBSC.Estimation.Biz.Biz_DeptPosDetails deptPosDetail = null;
            DataTable dtDeptDetail_temp = null;
            DataTable dtDeptDetail = null;
            DataTable dtEstData_temp = null;
            DataTable dtEstData = null;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                // 존재하는 테이터를 우선 삭제한다.
                /*
                affectedRow += _data.Delete(conn
                                            , trx
                                            , comp_id
                                            , parent_est_id
                                            , parent_estterm_ref_id
                                            , parent_estterm_sub_id
                                            , parent_estterm_step_id
                                            , 0
                                            , 0
                                            , 0
                                            , 0
                                            , ""
                                            , ""
                                            , OwnerType.All);
                 */

                affectedRow += Remove_Est_Data_Join_MappingData(conn
                                                            , trx
                                                            , comp_id
                                                            , parent_est_id
                                                            , parent_estterm_ref_id
                                                            , parent_estterm_sub_id
                                                            , parent_estterm_step_id
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , ""
                                                            , ""
                                                            , OwnerType.All);

                //2011.12.28 박효동 : 하위평가를 가져오니 문제가 있어서 수정
                // - MBO의 하위평가를 가져오도록 평가컬럼설정이 되있는데 현재는 현재평가의 하위차수를 가져오니 안나오더라
                // - 해서 평가컬럼설정에 등록되어있는 POINT_평가아이디에 해당하는 평가아이디를 가져오도록 수정 휴~~
                // 부모 평가에 속해 있는 종속 평가를 가지고 온다.
                //DataTable dtChildEst = estInfo.GetEstInfoByUpEstID(comp_id, parent_est_id).Tables[0];
                DataTable dtChildEst = estInfo.GetEstInfoByUpEstID(comp_id, parent_est_id).Tables[0];

                dtChildEst.Rows.Clear();
                MicroBSC.Estimation.Biz.Biz_ColumnInfos colInfo = new MicroBSC.Estimation.Biz.Biz_ColumnInfos();
                DataTable dtEstID = colInfo.GetColumnInfo(comp_id, parent_est_id).Tables[0];
                foreach (DataRow dr in dtEstID.Rows)
                {
                    string colnames = dr[6].ToString();
                    //if (colnames.Length > 5)
                    //{
                    //    if (colnames.Substring(0, 6) == "POINT_" && colnames.Length == 8)
                    //    {
                    //        DataRow insertDR = dtChildEst.NewRow();
                    //        insertDR["EST_ID"] = colnames.Remove(0, 6);
                    //        dtChildEst.Rows.Add(insertDR);
                    //        insertDR = null;
                    //    }
                    //}
                    //3글자 이상인 EST_ID를 인식하지 못하여 수정함
                    if (colnames.Length > 6 && colnames.IndexOf("POINT_") == 0)
                    {
                        DataRow insertDR = dtChildEst.NewRow();
                        insertDR["EST_ID"] = colnames.Remove(0, 6);
                        dtChildEst.Rows.Add(insertDR);
                        insertDR = null;
                    }
                }

                foreach (DataRow drChildEst in dtChildEst.Rows)
                {
                    string est_id = drChildEst["EST_ID"].ToString();
                    MicroBSC.Estimation.Biz.Biz_EstInfos estChildInfo = new MicroBSC.Estimation.Biz.Biz_EstInfos(comp_id, est_id);

                    weightType = estChildInfo.Weight_Type;

                    // 가중치 적용 방식에 따라
                    if (weightType.Equals("DPT"))
                    {
                        deptEstDetail = new MicroBSC.Estimation.Biz.Biz_DeptEstDetails();
                        dtDeptDetail_temp = deptEstDetail.GetDeptEstDetail(comp_id, parent_estterm_ref_id, 0, est_id).Tables[0];
                    }
                    else if (weightType.Equals("POS"))
                    {
                        deptPosDetail = new MicroBSC.Estimation.Biz.Biz_DeptPosDetails();
                        dtDeptDetail_temp = deptPosDetail.GetDeptPosDetail(comp_id, parent_estterm_ref_id, 0, est_id).Tables[0];
                    }

                    // 평가별 가중치 Data Merge
                    if (dtDeptDetail == null)
                        dtDeptDetail = dtDeptDetail_temp;
                    else
                        dtDeptDetail.Merge(dtDeptDetail_temp);

                    // 평가 데이터 Data Merge
                    MicroBSC.Estimation.Dac.Dac_Datas dacDatas = new MicroBSC.Estimation.Dac.Dac_Datas();
                    dtEstData_temp = dacDatas.SelectEstData(conn
                                                                    , trx
                                                                    , comp_id
                                                                    , est_id
                                                                    , parent_estterm_ref_id
                                                                    , parent_estterm_sub_id
                                                                    , parent_estterm_step_id
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , 0
                                                                    , ""
                                                                    , ""
                                                                    , OwnerType.All
                                                                    , "").Tables[0];

                    dtEstData_temp.Columns.Add("WEIGHT_EST", typeof(double));
                    dtEstData_temp.AcceptChanges();

                    if (weightType.Equals("DPT"))
                    {
                        foreach (DataRow drDeptDetail in dtDeptDetail_temp.Rows)
                        {
                            DataRow[] drArrEstData = dtEstData_temp.Select(string.Format("TGT_DEPT_ID = {0}", drDeptDetail["DEPT_REF_ID"]));

                            foreach (DataRow drEstData in drArrEstData)
                            {
                                drEstData["WEIGHT_EST"] = drDeptDetail["WEIGHT"];
                            }
                        }
                    }
                    else if (weightType.Equals("POS"))
                    {
                        DataTable dtPosDept = DataTypeUtility.GetGroupByDataTable(dtDeptDetail_temp
                                                                                , new string[] { "DEPT_REF_ID" });

                        //1. 부서_직급,직책 
                        //2. 부서로 그룹
                        //3. 부서그룹으로 루프
                        //4. 해당부서의 est_data로 선택
                        //5. 부서_직급,직책에서 해당당 직급,직책으로 선택
                        //6. 마지막으로 직급,직책의 값이 - 일 경우 WEIGHT_EST의 값이 null 인 컬럼을 모두 - 의 가중치로 채움

                        // 부서그룹에서
                        foreach (DataRow drPosDept in dtPosDept.Rows)
                        {
                            //해당 부서 중 직책, 직급을 선별
                            DataRow[] drArrEstPosDetail = dtDeptDetail_temp.Select(string.Format("DEPT_REF_ID = {0}", drPosDept["DEPT_REF_ID"]), "SEQ");

                            //선별된 직책, 직급의 순서에 따라
                            foreach (DataRow drChildPosDetail in drArrEstPosDetail)
                            {
                                // 기본값이면
                                if (drChildPosDetail["POS_VALUE"].ToString().Equals("-"))
                                {
                                    DataRow[] drArrEstData = dtEstData_temp.Select(string.Format("TGT_DEPT_ID = {0} AND WEIGHT_EST IS NULL", drPosDept["DEPT_REF_ID"]));

                                    for (int i = 0; i < drArrEstData.Length; i++)
                                    {
                                        drArrEstData[i]["WEIGHT_EST"] = drChildPosDetail["WEIGHT"];
                                    }
                                }
                                else // 선별된 직급
                                {
                                    DataRow[] drArrEstData = dtEstData_temp.Select(string.Format("TGT_DEPT_ID = {0} AND TGT_POS_{1}_ID = '{2}' AND WEIGHT_EST IS NULL"
                                                                                                , drPosDept["DEPT_REF_ID"]
                                                                                                , drChildPosDetail["POS_ID"]
                                                                                                , drChildPosDetail["POS_VALUE"]));

                                    for (int i = 0; i < drArrEstData.Length; i++)
                                    {
                                        drArrEstData[i]["WEIGHT_EST"] = drChildPosDetail["WEIGHT"];
                                    }
                                }
                            }
                        }
                    }

                    if (dtEstData == null)
                        dtEstData = dtEstData_temp;
                    else
                        dtEstData.Merge(dtEstData_temp);
                }

                // 자식이 아닌 자신평가에서 가중치 타입를 처리 하지 않기 위해서 자식 외 Scope 에서 우선 주석처리 함
                // 가중치 방법에 따라 총합계 계산 처리
                //if(weightType.Equals("DPT")) 
                //{
                //    dtDeptDetail = DataTypeUtility.GetGroupByDataTable(dtDeptDetail
                //                                                    , "WEIGHT"
                //                                                    , new string[] {"DEPT_REF_ID"}
                //                                                    , "WEIGHT");
                //}
                //else if(weightType.Equals("POS")) 
                //{

                //}

                MicroBSC.Estimation.Biz.Biz_Datas bizDatas = new MicroBSC.Estimation.Biz.Biz_Datas();
                DataTable dtBlank = bizDatas.GetDataTableSchema();
                DataRow dataRow = null;

                foreach (DataRow drEstData in dtEstData.Rows)
                {
                    // 빈 데이터 테이블에 존재하는 피평가 대상자 있는 지 확인 후
                    // 있다면 존재하는 데이터에 가중치를 계산하여 수정하지만
                    // 존재하지 않다면 새로운 데이터 Row를 생성하여 삽입한다.
                    DataRow[] drArr = dtBlank.Select(string.Format(@"COMP_ID         = {0}
                                                                AND EST_ID          = '{1}'
                                                                AND ESTTERM_REF_ID  = {2}
                                                                AND ESTTERM_SUB_ID  = {3}
                                                                AND ESTTERM_STEP_ID = {4}
                                                                AND TGT_DEPT_ID     = {5}
                                                                AND TGT_EMP_ID      = {6}"
                                                                , comp_id
                                                                , parent_est_id
                                                                , parent_estterm_ref_id
                                                                , parent_estterm_sub_id
                                                                , parent_estterm_step_id
                                                                , drEstData["TGT_DEPT_ID"]
                                                                , drEstData["TGT_EMP_ID"]));

                    if (drArr.Length == 0)
                    {
                        dataRow = dtBlank.NewRow();
                    }
                    else
                    {
                        dataRow = drArr[0];
                    }

                    double weight_total_weight = 100.00;

                    // 이것도 위와 같은 경우
                    //if(weightType.Equals("DPT")) 
                    //{
                    //    DataRow[] drArrWeight       = dtDeptDetail.Select(string.Format("DEPT_REF_ID = {0}", drEstData["TGT_DEPT_ID"]));

                    //    if(drArrWeight.Length > 0) 
                    //    {
                    //        weight_total_weight = DataTypeUtility.GetToDouble(drArrWeight[0]["SUM_WEIGHT"]);
                    //    }
                    //}
                    //else if(weightType.Equals("POS")) 
                    //{
                    //    weight_total_weight = 100;
                    //}

                    dataRow["COMP_ID"] = drEstData["COMP_ID"];
                    dataRow["EST_ID"] = parent_est_id;
                    dataRow["ESTTERM_REF_ID"] = parent_estterm_ref_id;
                    dataRow["ESTTERM_SUB_ID"] = parent_estterm_sub_id;
                    dataRow["ESTTERM_STEP_ID"] = parent_estterm_step_id;
                    dataRow["EST_DEPT_ID"] = drEstData["EST_DEPT_ID"];
                    dataRow["EST_EMP_ID"] = drEstData["EST_EMP_ID"];
                    dataRow["TGT_DEPT_ID"] = drEstData["TGT_DEPT_ID"];
                    dataRow["TGT_EMP_ID"] = drEstData["TGT_EMP_ID"];
                    dataRow["TGT_POS_CLS_ID"] = drEstData["TGT_POS_CLS_ID"];
                    dataRow["TGT_POS_CLS_NAME"] = drEstData["TGT_POS_CLS_NAME"];
                    dataRow["TGT_POS_DUT_ID"] = drEstData["TGT_POS_DUT_ID"];
                    dataRow["TGT_POS_DUT_NAME"] = drEstData["TGT_POS_DUT_NAME"];
                    dataRow["TGT_POS_GRP_ID"] = drEstData["TGT_POS_GRP_ID"];
                    dataRow["TGT_POS_GRP_NAME"] = drEstData["TGT_POS_GRP_NAME"];
                    dataRow["TGT_POS_RNK_ID"] = drEstData["TGT_POS_RNK_ID"];
                    dataRow["TGT_POS_RNK_NAME"] = drEstData["TGT_POS_RNK_NAME"];
                    dataRow["TGT_POS_KND_ID"] = drEstData["TGT_POS_KND_ID"];
                    dataRow["TGT_POS_KND_NAME"] = drEstData["TGT_POS_KND_NAME"];
                    dataRow["DIRECTION_TYPE"] = "SM";
                    dataRow["POINT_ORG"] = DataTypeUtility.GetToDouble(dataRow["POINT_ORG"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_ORG"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_ORG_DATE"] = DBNull.Value;
                    dataRow["POINT_AVG"] = DataTypeUtility.GetToDouble(dataRow["POINT_AVG"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_AVG"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_AVG_DATE"] = DBNull.Value;
                    dataRow["POINT_STD"] = DataTypeUtility.GetToDouble(dataRow["POINT_STD"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT_STD"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_STD_DATE"] = DBNull.Value;
                    dataRow["POINT"] = DataTypeUtility.GetToDouble(dataRow["POINT"])
                                                        + DataTypeUtility.GetToDouble(drEstData["POINT"])
                                                            * (DataTypeUtility.GetToDouble(drEstData["WEIGHT_EST"]) / weight_total_weight);
                    dataRow["POINT_DATE"] = DateTime.Now;
                    dataRow["GRADE_ID"] = DBNull.Value;
                    dataRow["GRADE_DATE"] = DBNull.Value;
                    dataRow["GRADE_TO_POINT"] = DBNull.Value;
                    dataRow["GRADE_TO_POINT_DATE"] = DBNull.Value;
                    dataRow["STATUS_ID"] = DBNull.Value;
                    dataRow["STATUS_DATE"] = DBNull.Value;
                    dataRow["DATE"] = drEstData["UPDATE_DATE"];
                    dataRow["USER"] = drEstData["UPDATE_USER"];

                    if (drArr.Length == 0)
                    {
                        dtBlank.Rows.Add(dataRow);
                    }
                }

                foreach (DataRow drBlank in dtBlank.Rows)
                {
                    affectedRow += Add_Est_Data_Join_MappingData(conn
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
                                                , drBlank["DIRECTION_TYPE"]
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
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "E"
                                                , DateTime.Now
                                                , DateTime.Now
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





        #region Dac_Data.cs의 Delete를 대체, EST060100.aspx
        //Biz_Datas.cs의 CopyTgtMapDataToEstData_PART에서 사용

        public int Remove_Est_Data_Join_MappingData(IDbConnection conn
                                                    , IDbTransaction trx
                                                    , object comp_id
                                                    , object est_id
                                                    , object estterm_ref_id
                                                    , object estterm_sub_id
                                                    , object estterm_step_id
                                                    , object est_dept_id
                                                    , object est_emp_id
                                                    , object tgt_dept_id
                                                    , object tgt_emp_id
                                                    , object year_yn
                                                    , object merge_yn
                                                    , OwnerType ownerType)
        {
            Dac_Est_Data dacEstData = new Dac_Est_Data();
            int affectedRow = 0;

            try
            {
                affectedRow = dacEstData.Delete_ED_JOIN_ESU_EST(conn, trx, comp_id, est_id, estterm_ref_id
                                                                , estterm_sub_id, estterm_step_id, est_dept_id
                                                                , est_emp_id, tgt_dept_id, tgt_emp_id
                                                                , year_yn, merge_yn, ownerType);

                //if (affectedRow > 0 && est_id.Equals("3GA"))
                if (est_id.Equals("3GA") || est_id.Equals("3A"))
                {
                    string rtnMonth = dacEstData.Select_Est_Term_YearMonth(comp_id, estterm_sub_id, estterm_ref_id);
                    int deleteCount = 0;


                    deleteCount += dacEstData.Delete_BSC_MBO_KIP_SCORE_DT(conn, trx, comp_id, est_id, estterm_ref_id
                                                                        , estterm_sub_id, estterm_step_id, rtnMonth
                                                                        , est_dept_id, est_emp_id, tgt_dept_id, tgt_emp_id);

                    deleteCount += dacEstData.Delete_BSC_MBO_KIP_SCORE_MT(conn, trx, comp_id, est_id, estterm_ref_id
                                                                        , estterm_sub_id, estterm_step_id, rtnMonth
                                                                        , est_dept_id, est_emp_id
                                                                        , tgt_dept_id, tgt_emp_id);

                    deleteCount += dacEstData.Delete_BSC_MBO_KPI_REPORT(conn, trx, comp_id, est_id, estterm_ref_id
                                                                        , estterm_sub_id, tgt_dept_id, tgt_emp_id
                                                                        , rtnMonth);
                }

                return affectedRow;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion


        #region Dac_Data.cs의 Insert를 대체, EST060100.aspx
        //Biz_Datas.cs의 CopyTgtMapDataToEstData_PART에서 사용

        public int Add_Est_Data_Join_MappingData(IDbConnection conn
                                                , IDbTransaction trx
                                                , object comp_id, object est_id, object estterm_ref_id
                                                , object estterm_sub_id, object estterm_step_id
                                                , object est_dept_id, object est_emp_id
                                                , object tgt_dept_id, object tgt_emp_id
                                                , object tgt_pos_cls_id, object tgt_pos_cls_name
                                                , object tgt_pos_dut_id, object tgt_pos_dut_name
                                                , object tgt_pos_grp_id, object tgt_pos_grp_name
                                                , object tgt_pos_rnk_id, object tgt_pos_rnk_name
                                                , object tgt_pos_knd_id, object tgt_pos_knd_name
                                                , object direction_type, object point_org
                                                , object point_org_date, object point_avg
                                                , object point_avg_date, object point_std
                                                , object point_std_date, object point_ctrl_org
                                                , object point_ctrl_org_date, object grade_ctrl_org_id
                                                , object grade_ctrl_org_date, object point
                                                , object point_date, object grade_id
                                                , object grade_date, object grade_to_point
                                                , object grade_to_point_date, object status_id
                                                , object status_date, object create_date
                                                , object create_user)
        {
            Dac_Est_Data dacEstData = new Dac_Est_Data();
            int affectedData = 0;

            try
            {
                affectedData = dacEstData.Insert(conn, trx, comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id
                                                , est_dept_id, est_emp_id, tgt_dept_id, tgt_emp_id
                                                , tgt_pos_cls_id, tgt_pos_cls_name
                                                , tgt_pos_dut_id, tgt_pos_dut_name
                                                , tgt_pos_grp_id, tgt_pos_grp_name
                                                , tgt_pos_rnk_id, tgt_pos_rnk_name
                                                , tgt_pos_knd_id, tgt_pos_knd_name
                                                , direction_type
                                                , point_org, point_org_date
                                                , point_avg, point_avg_date
                                                , point_std, point_std_date
                                                , point_ctrl_org, point_ctrl_org_date
                                                , grade_ctrl_org_id, grade_ctrl_org_date
                                                , point, point_date
                                                , grade_id, grade_date
                                                , grade_to_point, grade_to_point_date
                                                , status_id, status_date
                                                , create_date, create_user);

                // 3GA :개인KPI,  3A : 조직KPI
                if (affectedData > 0 && (est_id.Equals("3GA") || est_id.Equals("3A")) )
                {
                    string rtnMonth = dacEstData.Select_Est_Term_YearMonth(comp_id, estterm_sub_id, estterm_ref_id);
                    int insertCount = 0;

                    if(est_id.Equals("3GA"))
                        insertCount += dacEstData.Insert_BSC_MBO_KPI_SCORE_DT(conn, trx
                                                                            , comp_id, est_id
                                                                            , estterm_ref_id, estterm_sub_id, estterm_step_id
                                                                            , rtnMonth
                                                                            , est_dept_id, est_emp_id
                                                                            , tgt_dept_id, tgt_emp_id
                                                                            , create_user);

                    if (est_id.Equals("3A"))
                        insertCount += dacEstData.Insert_BSC_DEPT_KPI_SCORE_DT(conn, trx
                                                                            , comp_id, est_id
                                                                            , estterm_ref_id, estterm_sub_id, estterm_step_id
                                                                            , rtnMonth
                                                                            , est_dept_id, est_emp_id
                                                                            , tgt_dept_id, tgt_emp_id
                                                                            , create_user);

                    insertCount += dacEstData.Insert_BSC_MBO_KPI_SCORE_MT(conn, trx
                                                                        , comp_id, est_id
                                                                        , estterm_ref_id, estterm_sub_id, estterm_step_id
                                                                        , rtnMonth
                                                                        , est_dept_id, est_emp_id
                                                                        , tgt_dept_id, tgt_emp_id
                                                                        , create_user);

                    insertCount += dacEstData.Insert_BSC_MBO_KPI_REPORT(conn, trx
                                                                        , comp_id, est_id
                                                                        , estterm_ref_id, estterm_sub_id, estterm_step_id
                                                                        , rtnMonth
                                                                        , est_dept_id, est_emp_id
                                                                        , tgt_dept_id, tgt_emp_id
                                                                        , create_user);
                }

                return affectedData;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion




        // 맵핑된 평가자 <-> 피평가자의 Data를 EST_DATA 로 복사한다.(부분)
        public bool CopyTgtMapDataToEstData_PART(DataTable dataTable, OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                DataTable dtClone = dataTable.Clone();

                // 존재하지 않는 EST_DATA 테이블의 정보를 보관한다.
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (_data.Select_Est_Data_Count(conn
                                                    , trx
                                                    , dataRow["COMP_ID"]
                                                    , dataRow["EST_ID"]
                                                    , dataRow["ESTTERM_REF_ID"]
                                                    , dataRow["ESTTERM_SUB_ID"]
                                                    , dataRow["ESTTERM_STEP_ID"]
                                                    , dataRow["EST_DEPT_ID"]
                                                    , dataRow["EST_EMP_ID"]
                                                    , dataRow["TGT_DEPT_ID"]
                                                    , dataRow["TGT_EMP_ID"]
                                                    , "") == 0)
                    {
                        dtClone.ImportRow(dataRow);
                    }
                }

                DataTable dtEstData = _data.Select_Est_Data_Join_Est_Esu(
                                                    conn
                                                    , trx
                                                    , DataTypeUtility.GetToInt32(dataTable.Rows[0]["COMP_ID"])
                                                    , DataTypeUtility.GetValue(dataTable.Rows[0]["EST_ID"])
                                                    , DataTypeUtility.GetToInt32(dataTable.Rows[0]["ESTTERM_REF_ID"])
                                                    , DataTypeUtility.GetToInt32(dataTable.Rows[0]["ESTTERM_SUB_ID"])
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , 0
                                                    , "N"
                                                    , "N"
                                                    , ownerType).Tables[0];

                // 존재하지 않는 맵핑 정보가 있을 경우 평가데이터를 삭제한다.
                foreach (DataRow dataRow in dtEstData.Rows)
                {
                    if (_data.Select_Est_Emp_Est_Target_Count(conn
                                                            , trx
                                                            , dataRow["COMP_ID"]
                                                            , dataRow["EST_ID"]
                                                            , dataRow["ESTTERM_REF_ID"]
                                                            , dataRow["ESTTERM_SUB_ID"]
                                                            , dataRow["ESTTERM_STEP_ID"]
                                                            , dataRow["EST_DEPT_ID"]
                                                            , dataRow["EST_EMP_ID"]
                                                            , dataRow["TGT_DEPT_ID"]
                                                            , dataRow["TGT_EMP_ID"]) == 0)
                    {
                        affectedRow += Remove_Est_Data_Join_MappingData(
                                                    conn
                                                    , trx
                                                    , dataTable.Rows[0]["COMP_ID"]
                                                    , dataTable.Rows[0]["EST_ID"]
                                                    , dataTable.Rows[0]["ESTTERM_REF_ID"]
                                                    , dataTable.Rows[0]["ESTTERM_SUB_ID"]
                                                    , dataRow["ESTTERM_STEP_ID"]
                                                    , dataRow["EST_DEPT_ID"]
                                                    , dataRow["EST_EMP_ID"]
                                                    , dataRow["TGT_DEPT_ID"]
                                                    , dataRow["TGT_EMP_ID"]
                                                    , "N"
                                                    , "N"
                                                    , ownerType);
                    }
                }

                foreach (DataRow dataRow in dtClone.Rows)
                {
                    affectedRow += Add_Est_Data_Join_MappingData(
                                                    conn
                                                    , trx
                                                    , dataRow["COMP_ID"]
                                                    , dataRow["EST_ID"]
                                                    , dataRow["ESTTERM_REF_ID"]
                                                    , dataRow["ESTTERM_SUB_ID"]
                                                    , dataRow["ESTTERM_STEP_ID"]
                                                    , dataRow["EST_DEPT_ID"]
                                                    , dataRow["EST_EMP_ID"]
                                                    , dataRow["TGT_DEPT_ID"]
                                                    , dataRow["TGT_EMP_ID"]
                                                    , dataRow["TGT_POS_CLS_ID"]
                                                    , dataRow["TGT_POS_CLS_NAME"]
                                                    , dataRow["TGT_POS_DUT_ID"]
                                                    , dataRow["TGT_POS_DUT_NAME"]
                                                    , dataRow["TGT_POS_GRP_ID"]
                                                    , dataRow["TGT_POS_GRP_NAME"]
                                                    , dataRow["TGT_POS_RNK_ID"]
                                                    , dataRow["TGT_POS_RNK_NAME"]
                                                    , dataRow["TGT_POS_KND_ID"]
                                                    , dataRow["TGT_POS_KND_NAME"]
                                                    , dataRow["DIRECTION_TYPE"]
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , DBNull.Value
                                                    , "N"
                                                    , dataRow["DATE"]
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




        // 맵핑된 평가자 <-> 피평가자의 Data를 EST_DATA 로 복사한다.(전체)
        public bool CopyTgtMapDataToEstData_ALL(DataTable dataTable, OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    affectedRow += Remove_Est_Data_Join_MappingData(
                                                conn
                                                , trx
                                                , dataTable.Rows[0]["COMP_ID"]
                                                , dataTable.Rows[0]["EST_ID"]
                                                , dataTable.Rows[0]["ESTTERM_REF_ID"]
                                                , dataTable.Rows[0]["ESTTERM_SUB_ID"]
                                                , 0
                                                , 0
                                                , 0
                                                , 0
                                                , 0
                                                , "N"
                                                , "N"
                                                , ownerType);
                }

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += Add_Est_Data_Join_MappingData(
                                                conn
                                                , trx
                                                , dataRow["COMP_ID"]
                                                , dataRow["EST_ID"]
                                                , dataRow["ESTTERM_REF_ID"]
                                                , dataRow["ESTTERM_SUB_ID"]
                                                , dataRow["ESTTERM_STEP_ID"]
                                                , dataRow["EST_DEPT_ID"]
                                                , dataRow["EST_EMP_ID"]
                                                , dataRow["TGT_DEPT_ID"]
                                                , dataRow["TGT_EMP_ID"]
                                                , dataRow["TGT_POS_CLS_ID"]
                                                , dataRow["TGT_POS_CLS_NAME"]
                                                , dataRow["TGT_POS_DUT_ID"]
                                                , dataRow["TGT_POS_DUT_NAME"]
                                                , dataRow["TGT_POS_GRP_ID"]
                                                , dataRow["TGT_POS_GRP_NAME"]
                                                , dataRow["TGT_POS_RNK_ID"]
                                                , dataRow["TGT_POS_RNK_NAME"]
                                                , dataRow["TGT_POS_KND_ID"]
                                                , dataRow["TGT_POS_KND_NAME"]
                                                , dataRow["DIRECTION_TYPE"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "N"
                                                , dataRow["DATE"]
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




        // 선택된 항목에 따른 맵핑된 평가자 <-> 피평가자의 Data를 EST_DATA 로 복사한다.
        public bool CopyTgtMapDataToEstDataBySelectedItem(DataTable dataTable, OwnerType ownerType)
        {
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        affectedRow += Remove_Est_Data_Join_MappingData(conn
                                                    , trx
                                                    , dataRow["COMP_ID"]
                                                    , dataRow["EST_ID"]
                                                    , dataRow["ESTTERM_REF_ID"]
                                                    , dataRow["ESTTERM_SUB_ID"]
                                                    , dataRow["ESTTERM_STEP_ID"]
                                                    , dataRow["EST_DEPT_ID"]
                                                    , dataRow["EST_EMP_ID"]
                                                    , dataRow["TGT_DEPT_ID"]
                                                    , dataRow["TGT_EMP_ID"]
                                                    , "N"
                                                    , "N"
                                                    , ownerType);
                    }
                }

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += Add_Est_Data_Join_MappingData(conn
                                                , trx
                                                , dataRow["COMP_ID"]
                                                , dataRow["EST_ID"]
                                                , dataRow["ESTTERM_REF_ID"]
                                                , dataRow["ESTTERM_SUB_ID"]
                                                , dataRow["ESTTERM_STEP_ID"]
                                                , dataRow["EST_DEPT_ID"]
                                                , dataRow["EST_EMP_ID"]
                                                , dataRow["TGT_DEPT_ID"]
                                                , dataRow["TGT_EMP_ID"]
                                                , dataRow["TGT_POS_CLS_ID"]
                                                , dataRow["TGT_POS_CLS_NAME"]
                                                , dataRow["TGT_POS_DUT_ID"]
                                                , dataRow["TGT_POS_DUT_NAME"]
                                                , dataRow["TGT_POS_GRP_ID"]
                                                , dataRow["TGT_POS_GRP_NAME"]
                                                , dataRow["TGT_POS_RNK_ID"]
                                                , dataRow["TGT_POS_RNK_NAME"]
                                                , dataRow["TGT_POS_KND_ID"]
                                                , dataRow["TGT_POS_KND_NAME"]
                                                , dataRow["DIRECTION_TYPE"]
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , DBNull.Value
                                                , "N"
                                                , dataRow["DATE"]
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



        public string RemoveEstData(int comp_id
                                        , string est_id
                                        , int estterm_ref_id
                                        , int estterm_sub_id
                                        , int estterm_step_id
                                        , int est_emp_id
                                        , int tgt_emp_id
                                        , string direction_type
                                        )
        {
            string returnVal = string.Empty;

            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();


            try
            {
                MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();

                intTxrCnt = dacEstEmpEstTargetMap.Delete_DB(conn
                                                      , trx
                                                      , comp_id
                                                      , est_id
                                                      , estterm_ref_id
                                                      , estterm_sub_id
                                                      , estterm_step_id
                                                      , est_emp_id
                                                      , tgt_emp_id);
                                                      

                MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();


                intTxrCnt = dacEstData.Delete(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_emp_id
                                            , tgt_emp_id
                                            , direction_type);


                trx.Commit();
            }
            catch (Exception ex)
            {
                returnVal = ex.Message;
                trx.Rollback();
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }

        public string RemoveEstDataWithRandomEstEmp(DataTable dt
                                                    , int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int estterm_step_id
                                                    , int est_dept_id
                                                    , int est_emp_id
                                                    , int tgt_dept_id
                                                    , int tgt_emp_id
                                                    , int rnd_est_dept_id
                                                    , int rnd_est_emp_id
                                                    , string direction_type
                                                    , DateTime create_date
                                                    , int create_user
                 
                                                    )
        {
            string returnVal = string.Empty;

            int intTxrCnt = 0;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            

            try
            {

                MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();

                intTxrCnt = dacEstEmpEstTargetMap.Delete_DB(conn
                                                      , trx
                                                      , comp_id
                                                      , est_id
                                                      , estterm_ref_id
                                                      , estterm_sub_id
                                                      , estterm_step_id
                                                      , est_emp_id
                                                      , tgt_emp_id);

                dacEstEmpEstTargetMap.Insert_DB(conn
                                              , trx
                                              , comp_id
                                              , est_id
                                              , estterm_ref_id
                                              , estterm_sub_id
                                              , estterm_step_id
                                              , rnd_est_dept_id
                                              , rnd_est_emp_id
                                              , tgt_dept_id
                                              , tgt_emp_id
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_CLS_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_CLS_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_DUT_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_DUT_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_GRP_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_GRP_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_RNK_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_RNK_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_KND_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_KND_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["DIRECTION_TYPE"])
                                              , "N"
                                              , create_date
                                              , create_user);

                MicroBSC.Integration.EST.Dac.Dac_Est_Data dacEstData = new Dac_Est_Data();


                intTxrCnt = dacEstData.Delete(conn
                                            , trx
                                            , comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , estterm_step_id
                                            , est_emp_id
                                            , tgt_emp_id
                                            , direction_type);

                intTxrCnt = dacEstData.Insert(conn
                                             , trx
                                             , comp_id
                                             , est_id
                                             , estterm_ref_id
                                             , estterm_sub_id
                                             , estterm_step_id
                                             , rnd_est_dept_id
                                             , rnd_est_emp_id
                                             , tgt_dept_id
                                             , tgt_emp_id
                                             ,  DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_CLS_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_CLS_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_DUT_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_DUT_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_GRP_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_GRP_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_RNK_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_RNK_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_KND_ID"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["TGT_POS_KND_NAME"])
                                              , DataTypeUtility.GetValue(dt.Rows[0]["DIRECTION_TYPE"])
                                              , "N"
                                              , create_date
                                              , create_date
                                              , create_user);




                trx.Commit();
            }
            catch (Exception ex)
            {
                returnVal = ex.Message;
                trx.Rollback();
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return returnVal;
        }




        /// <summary>
        /// EST_DATA의 STATUS_ID 검증, 틀리면 status_id가 널
        /// </summary>
        /// <param name="current_status_id">현재 STATUS_ID</param>
        /// <param name="target_status_seq">변경될 상태의 시퀀스</param>
        /// <param name="increment_seq">현재 상태와 변경될 상태의 시퀀스 차이</param>
        public MicroBSC.Estimation.Biz.Biz_Status Get_New_Est_Status(int comp_id, string est_id, string current_status_id, int target_status_seq, int increment_seq)
        {
            string result;

            //STATUS 정보 가져오기
            int new_status_seq = target_status_seq;

            MicroBSC.Estimation.Biz.Biz_EstInfos bizEstInfo = new MicroBSC.Estimation.Biz.Biz_EstInfos(comp_id, est_id);
            string status_style_id = DataTypeUtility.GetString(bizEstInfo.Status_Style_ID);



            //목적 status 정보
            MicroBSC.Estimation.Biz.Biz_Status bizStatus = new MicroBSC.Estimation.Biz.Biz_Status();
            DataTable dt_status = bizStatus.GetStatusByEstID(est_id).Tables[0];
            string filter = string.Format("SEQ={0}", new_status_seq.ToString());
            string new_status_id = DataTypeUtility.GetString(DataTypeUtility.FilterSortDataTable(dt_status, filter).Rows[0]["STATUS_ID"]);

            MicroBSC.Estimation.Biz.Biz_Status new_status = new MicroBSC.Estimation.Biz.Biz_Status(new_status_id, status_style_id);



            //현재 status 정보
            MicroBSC.Estimation.Biz.Biz_Status status_data = new MicroBSC.Estimation.Biz.Biz_Status(current_status_id, status_style_id);


            //증가 단계가 일치하면 new_status 반환
            if (status_data.Seq + increment_seq != new_status.Seq && status_data.Seq != new_status.Seq)
            {
                new_status.Status_ID = null;
            }

            return new_status;
        }



        /// <summary>
        /// BIAS 조정용 평가자별 평균 조정비율과 펴준편차
        /// </summary>
        public DataTable Get_Bias_AVG_Ratio_STD(int comp_id
                                                , string est_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id)
        { 
            DataTable dt = _data.Select_Bias_AVG_Ratio_STD(comp_id
                                                        , est_id
                                                        , estterm_ref_id
                                                        , estterm_sub_id
                                                        , estterm_step_id);

            return dt;
        }



        /// <summary>
        /// 부서별 직급별 가중치 적용하기 위한 리스트
        /// </summary>
        public DataTable Get_Est_Data_Pos_Weight(int comp_id
            , string est_id
            , int estterm_ref_id
            , int estterm_sub_id
            , int estterm_step_id)
        {
            DataTable dt = _data.Select_Est_Data_Pos_Weight(comp_id
                , est_id
                , estterm_ref_id
                , estterm_sub_id
                , estterm_step_id);

            return dt;
        }
    }
}