using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Biz.BSC.Dac;
using MicroBSC.Data;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Biz_AHPEstDeptStgDatas
/// </summary>
namespace MicroBSC.Biz.BSC.Biz
{
    public class Biz_AHPEstDeptStgDatas : Dac.Dac_AHPEstDeptStgDatas
    {
        public Biz_AHPEstDeptStgDatas()
        {
            
        }

        public Biz_AHPEstDeptStgDatas(int ver_id
                                        , int estterm_ref_id
                                        , int est_dept_ref_id
                                        , int l_stg_ref_id
                                        , int r_stg_ref_id) : base(ver_id
                                                                    , estterm_ref_id
                                                                    , est_dept_ref_id
                                                                    , l_stg_ref_id
                                                                    , r_stg_ref_id)
        {

        }

        public bool AddAHPEstDeptStgDatas(int ver_id
                                            , int estterm_ref_id
                                            , int est_dept_ref_id
                                            , int user
                                            , DataTable dataTable) 
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach(DataRow dr in dataTable.Rows)
                {
                    if (IsAHPEstDeptStgData_Dac(ver_id
                                                    , estterm_ref_id
                                                    , est_dept_ref_id
                                                    , int.Parse(dr["L_STG_REF_ID"].ToString())
                                                    , int.Parse(dr["R_STG_REF_ID"].ToString())))
                    {
                        ModifyAHPEstDeptStgData_Dac(conn
                                                , trx
                                                , ver_id
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , int.Parse(dr["L_STG_REF_ID"].ToString())
                                                , int.Parse(dr["R_STG_REF_ID"].ToString())
                                                , float.Parse(dr["L_POINT"].ToString())
                                                , int.Parse(dr["S_POINT"].ToString())
                                                , float.Parse(dr["R_POINT"].ToString())
                                                , user);

                    }
                    else 
                    {
                        AddAHPEstDeptStgData_Dac(conn
                                                , trx
                                                , ver_id
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , int.Parse(dr["L_STG_REF_ID"].ToString())
                                                , int.Parse(dr["R_STG_REF_ID"].ToString())
                                                , float.Parse(dr["L_POINT"].ToString())
                                                , int.Parse(dr["S_POINT"].ToString())
                                                , float.Parse(dr["R_POINT"].ToString())
                                                , user);
                    }
                }

                trx.Commit();
            }
            catch (Exception e)
            {
                trx.Rollback();
                return false;
            }
            finally 
            {
                conn.Close();
            }

            return true;
        }

        /// <summary>
        /// 만약 0 일 경우 설정한 데이터가 없음
        /// </summary>
        /// <param name="ver_id"></param>
        /// <param name="estterm_ref_id"></param>
        /// <param name="est_dept_ref_id"></param>
        /// <param name="stg_ref_id"></param>
        /// <returns></returns>
        public float GetAHPEstDeptStgMultiPlyPoint(int ver_id
                                                    , int estterm_ref_id
                                                    , int est_dept_ref_id
                                                    , int stg_ref_id)
        {
            float multi_point = 1;

            DataTable dataTable = GetAHPEstDeptStgPoint_Dac( ver_id
                                                            , estterm_ref_id
                                                            , est_dept_ref_id
                                                            , stg_ref_id).Tables[0];

            if (dataTable.Rows.Count == 0)
                return 0;

            foreach (DataRow dr in dataTable.Rows) 
            {
                multi_point = multi_point * Convert.ToSingle(dr["L_R_POINT"]);
            }

            return multi_point;
        }

        public float GetAHPEstDeptStgSumPoint(int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int target_stg_ref_id)
        {
            float sum_point = 0;

            Biz_PDTAndAHPStgEstDeptDatas pdtAhpEstDept  = new Biz_PDTAndAHPStgEstDeptDatas();
            DataSet ds                                  = pdtAhpEstDept.GetPDTAndAHPEstDeptStgList(ver_id
                                                                                                    , estterm_ref_id
                                                                                                    , est_dept_ref_id
                                                                                                    , "Y");

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow drRow in ds.Tables[0].Rows)
                {
                    int stg_ref_id  = int.Parse(drRow["STG_REF_ID"].ToString());
                    float point    = 0;

                    if (stg_ref_id == target_stg_ref_id)
                    {
                        point = 1;
                    }
                    else
                    {
                        point = GetAHPEstDeptStgHorizonPoint_Dac(ver_id
                                                                , estterm_ref_id
                                                                , est_dept_ref_id
                                                                , stg_ref_id
                                                                , target_stg_ref_id);
                    }

                    sum_point += point;
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                throw ex;
            }
            finally 
            {
                conn.Close();
            }

            return sum_point;
        }

        public bool RemoveAHPEstDeptStgData(IDbConnection conn
                                                , IDbTransaction trx
                                                , int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id) 
        {
            return RemoveAHPEstDeptStgData_Dac(conn
                                                , trx
                                                , ver_id
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , 0
                                                , 0);
        }
    }
}
