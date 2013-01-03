using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Integration.MUL.Dac;
using MicroBSC.Integration.EST.Dac;
using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Biz
{
    public class Biz_Est_Emp_Est_Target_Map
    {
        public Biz_Est_Emp_Est_Target_Map()
	    {
		    
	    }

        public DataSet Get3A_List(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3A_List(comp_id
                                                      , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , est_dept_id
                                                            , est_emp_id
                                                            , tgt_dept_id );
        }

        public DataSet Get3APre_Table1(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table1(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3APre_Table2(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table2(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id);
        }

        public DataSet Get3APre_Table3(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table3(comp_id
                                                      , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , est_dept_id
                                                            , est_emp_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3APre_Table4(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table4(comp_id
                                                           , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , est_dept_id
                                                            , est_emp_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3APre_Table5(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table5(comp_id
                                                          , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3APre_Table6(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table6(comp_id
                                                          , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3APre_Table7(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int est_dept_id
                                    , int est_emp_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table7(comp_id
                                                          , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , est_dept_id
                                                            , est_emp_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3APre_Table8(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table8(comp_id
                                                          , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3APre_Table9(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_dept_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select3APre_Table9(comp_id
                                                          , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , tgt_dept_id);
        }

        public DataSet Get3A_DB(int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int usertype
                                    , int emp_ref_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select_3A(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , usertype
                                                            , emp_ref_id);
        }

        public DataTable GetSumFor3A_DB(int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int est_emp_id
                                                    , int tgt_emp_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.SelectSumFor3A(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , est_emp_id
                                                            , tgt_emp_id);
        }

        public DataTable GetSumFor3ATgtReport_DB(int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int emp_ref_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.SelectSumFor3ATgtReport(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , emp_ref_id);
        }

        public DataTable GetSumFor3ATgtFeedBack_DB(int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int emp_ref_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.SelectSumFor3ATgtFeedBack(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , emp_ref_id);
        }

        public DataSet GetEmpEstTargetMapForDeptEst_DB(int comp_id
                                                    , string est_id
                                                    , int estterm_ref_id
                                                    , int estterm_sub_id
                                                    , int estterm_step_id
                                                    , int est_emp_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.SelectForDeptEst_DB(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id
                                                            , est_emp_id);
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
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select_DB(comp_id
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

        public DataTable GetEstEmpEstTargetMap_DB(int comp_id
                                                , int estterm_ref_id
                                                , int estterm_sub_id
                                                , int estterm_step_id
                                                , string est_id
                                                , int tgt_ref_id)
        {
            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();
            return dacEstEmpEstTargetMap.Select_DB(comp_id
                                                , estterm_ref_id  
                                                , estterm_sub_id   
                                                , estterm_step_id      
                                                , est_id
                                                , tgt_ref_id);
        }

        public string AddEmpEstTargetMap(DataTable dtDelEmp
                                    , DataTable dtResult
                                    , int comp_id
                                    , string est_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int estterm_step_id
                                    , string direction_type
                                    , string status_id
                                    , DateTime create_date
                                    , int create_user)
        {
            int affectedRow = 0;

            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            

            try
            {
                // 존재하는 데이터가 있다면 삭제 후 추가
                foreach (DataRow dataRow in dtDelEmp.Rows)
                {
                    //저장할 부서에 해당하는 직원의 기존 데이터 모두 삭제
                    affectedRow = dacEstEmpEstTargetMap.Delete_DB(conn
                                                          , trx
                                                          , comp_id
                                                          , est_id
                                                          , estterm_ref_id
                                                          , estterm_sub_id
                                                          , estterm_step_id
                                                          , dataRow["EMP_REF_ID"]);
                }

                if (dtResult != null)
                {
                    MicroBSC.Estimation.Dac.Dac_EmpEstTargetMaps _empEstTargetMap = new MicroBSC.Estimation.Dac.Dac_EmpEstTargetMaps();

                    foreach (DataRow dataRow in dtResult.Rows)
                    {
                        int est_dept_id = DataTypeUtility.GetToInt32(dataRow["DEPT_REF_ID"]);
                        int est_emp_id = DataTypeUtility.GetToInt32(dataRow["EMP_REF_ID"]);
                        int tgt_dept_id = DataTypeUtility.GetToInt32(dataRow["TGT_DEPT_ID"]);
                        int tgt_emp_id = DataTypeUtility.GetToInt32(dataRow["TGT_EMP_ID"]);
                        string tgt_pos_cls_id = DataTypeUtility.GetValue(dataRow["TGT_CLASS_CODE"]);
                        string tgt_pos_cls_name = DataTypeUtility.GetValue(dataRow["TGT_CLS_NAME"]);
                        string tgt_pos_dut_id = DataTypeUtility.GetValue(dataRow["TGT_DUTY_CODE"]);
                        string tgt_pos_dut_name = DataTypeUtility.GetValue(dataRow["TGT_DUT_NAME"]);
                        string tgt_pos_grp_id = DataTypeUtility.GetValue(dataRow["TGT_GRP_CODE"]);
                        string tgt_pos_grp_name = DataTypeUtility.GetValue(dataRow["TGT_GRP_NAME"]);
                        string tgt_pos_rnk_id = DataTypeUtility.GetValue(dataRow["TGT_RANK_CODE"]);
                        string tgt_pos_rnk_name = DataTypeUtility.GetValue(dataRow["TGT_RANK_NAME"]);
                        string tgt_pos_knd_id = DataTypeUtility.GetValue(dataRow["TGT_KIND_CODE"]);
                        string tgt_pos_knd_name = DataTypeUtility.GetValue(dataRow["TGT_KND_NAME"]);

                        affectedRow = _empEstTargetMap.Insert(conn
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
                                                              , tgt_pos_cls_id
                                                              , tgt_pos_cls_name
                                                              , tgt_pos_dut_id
                                                              , tgt_pos_dut_name
                                                              , tgt_pos_grp_id
                                                              , tgt_pos_grp_name
                                                              , tgt_pos_rnk_id
                                                              , tgt_pos_rnk_name
                                                              , tgt_pos_knd_id
                                                              , tgt_pos_knd_name
                                                              , direction_type
                                                              , status_id
                                                              , create_date
                                                              , create_user);
                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return "";
        }

        public bool RemoveEmpEstTargetMap_DB(DataTable dataTable)
        {
            int affectedRow = 0;

            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map _empEstTargetMap = new Dac_Est_Emp_Est_Target_Map();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += _empEstTargetMap.Delete_DB(conn
                                                          , trx
                                                          , dataRow["COMP_ID"]
                                                          , dataRow["EST_ID"]
                                                          , dataRow["ESTTERM_REF_ID"]
                                                          , dataRow["ESTTERM_SUB_ID"]
                                                          , dataRow["ESTTERM_STEP_ID"]
                                                          , dataRow["TGT_EMP_ID"]);
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
        /// 풀에서 가져온 데이터를 바탕으로 메핑테이블에 저장
        /// </summary>
        public string AddEmpEstTargetMapFromPool(DataTable dtDelEmp
                                            , DataTable dtResult
                                            , int comp_id
                                            , string est_id
                                            , int estterm_ref_id
                                            , int estterm_sub_id
                                            , int estterm_step_id
                                            , string direction_type
                                            , string status_id
                                            , DateTime create_date
                                            , int create_user)
        {
            Dac_Mul_Est_Target_Pool dacMulEstTargetPool = new Dac_Mul_Est_Target_Pool();

            int affectedRow = 0;

            MicroBSC.Integration.EST.Dac.Dac_Est_Emp_Est_Target_Map dacEstEmpEstTargetMap = new Dac_Est_Emp_Est_Target_Map();

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int i;

            try
            {
                {
                    //저장할 부서에 해당하는 직원의 기존 데이터 모두 삭제
                    affectedRow = dacEstEmpEstTargetMap.Delete_DB(conn
                                                          , trx
                                                          , comp_id
                                                          , est_id
                                                          , estterm_ref_id
                                                          , estterm_sub_id
                                                          , estterm_step_id
                                                          , dtDelEmp
                                                          , "N");

                    
                    

                    //SELECT_YN원복
                    //전체 매핑정보
                    DataTable TotalMap = GetEstEmpEstTargetMap_DB(comp_id, estterm_ref_id, estterm_sub_id, estterm_step_id, est_id, 0);
                    //삭제대상 부서의 피평가자 목록 스트링
                    System.Text.StringBuilder tgt_emp_id_list = new System.Text.StringBuilder();
                    for (int j = 0; j < dtDelEmp.Rows.Count; j++)
                    {
                        if (tgt_emp_id_list.Length > 0)
                            tgt_emp_id_list.Append(", ");
                        tgt_emp_id_list.Append(dtDelEmp.Rows[j]["EMP_REF_ID"].ToString());
                    }
                    //삭제대상 부서의 피평가자에 대한 평가자 매핑 정보
                    DataTable est_tgt_emp_map = DataTypeUtility.FilterSortDataTable(TotalMap, string.Format("TGT_EMP_ID IN ({0})", tgt_emp_id_list.ToString()));

                    for (int j = 0; j < est_tgt_emp_map.Rows.Count; j++)
                    {
                        string est_emp_id = est_tgt_emp_map.Rows[j]["EST_EMP_ID"].ToString();
                        string tgt_emp_id = est_tgt_emp_map.Rows[j]["TGT_EMP_ID"].ToString();
                        dacMulEstTargetPool.Update_Pool_Select_Flag(conn, trx, comp_id, est_id, estterm_ref_id, estterm_sub_id, est_emp_id, tgt_emp_id, "N", create_user);
                    }
                }






                if (dtResult != null)
                {
                    MicroBSC.Estimation.Dac.Dac_EmpEstTargetMaps _empEstTargetMap = new MicroBSC.Estimation.Dac.Dac_EmpEstTargetMaps();

                    for (i = 0; i < dtResult.Rows.Count; i++)
                    {
                        int est_dept_id = DataTypeUtility.GetToInt32(dtResult.Rows[i]["DEPT_REF_ID"].ToString());
                        int est_emp_id = DataTypeUtility.GetToInt32(dtResult.Rows[i]["EMP_REF_ID"].ToString());
                        int tgt_dept_id = DataTypeUtility.GetToInt32(dtResult.Rows[i]["TGT_DEPT_ID"].ToString());
                        int tgt_emp_id = DataTypeUtility.GetToInt32(dtResult.Rows[i]["TGT_EMP_ID"].ToString());
                        string tgt_pos_cls_id = dtResult.Rows[i]["TGT_CLASS_CODE"].ToString();
                        string tgt_pos_cls_name = dtResult.Rows[i]["TGT_CLS_NAME"].ToString();
                        string tgt_pos_dut_id = dtResult.Rows[i]["TGT_DUTY_CODE"].ToString();
                        string tgt_pos_dut_name = dtResult.Rows[i]["TGT_DUT_NAME"].ToString();
                        string tgt_pos_grp_id = dtResult.Rows[i]["TGT_GRP_CODE"].ToString();
                        string tgt_pos_grp_name = dtResult.Rows[i]["TGT_GRP_NAME"].ToString();
                        string tgt_pos_rnk_id = dtResult.Rows[i]["TGT_RANK_CODE"].ToString();
                        string tgt_pos_rnk_name = dtResult.Rows[i]["TGT_RANK_NAME"].ToString();
                        string tgt_pos_knd_id = dtResult.Rows[i]["TGT_KIND_CODE"].ToString();
                        string tgt_pos_knd_name = dtResult.Rows[i]["TGT_KND_NAME"].ToString();


                        affectedRow = _empEstTargetMap.Insert(conn
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
                                                              , tgt_pos_cls_id
                                                              , tgt_pos_cls_name
                                                              , tgt_pos_dut_id
                                                              , tgt_pos_dut_name
                                                              , tgt_pos_grp_id
                                                              , tgt_pos_grp_name
                                                              , tgt_pos_rnk_id
                                                              , tgt_pos_rnk_name
                                                              , tgt_pos_knd_id
                                                              , tgt_pos_knd_name
                                                              , direction_type
                                                              , status_id
                                                              , create_date
                                                              , create_user);


                        affectedRow += dacMulEstTargetPool.Update_Pool_Select_Flag(conn, trx
                                                                                , comp_id
                                                                                , est_id
                                                                                , estterm_ref_id
                                                                                , estterm_sub_id
                                                                                , est_emp_id
                                                                                , tgt_emp_id
                                                                                , "Y"
                                                                                , create_user);
                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return "";
        }
    }
}