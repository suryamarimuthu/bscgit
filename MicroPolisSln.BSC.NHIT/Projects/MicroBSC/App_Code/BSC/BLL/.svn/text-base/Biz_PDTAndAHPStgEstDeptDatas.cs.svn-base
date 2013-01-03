using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

/// <summary>
/// Summary description for Biz_PDTAndAHPStgEstDeptDatas
/// </summary>
namespace MicroBSC.Biz.BSC.Biz
{
    public class Biz_PDTAndAHPStgEstDeptDatas : Dac.Dac_PDTAndAHPStgEstDeptDatas
    {
        public Biz_PDTAndAHPStgEstDeptDatas()
        {
            
        }

        public Biz_PDTAndAHPStgEstDeptDatas(int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int stg_ref_id) : base(ver_id
                                                                            , estterm_ref_id
                                                                            , est_dept_ref_id
                                                                            , stg_ref_id)
        {
            
        }

        public bool AddPDTAndAHPStgEstDeptDatas(int ver_id
                                                , int estterm_ref_id
                                                , DataTable stgData
                                                , DataTable estDeptData
                                                , int est_dept_ref_id
                                                , int create_update_user) 
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < stgData.Rows.Count; i++) 
                {
                    Biz_PDTAndAHPStgInfos pdtAndAhpStgInfo = new Biz_PDTAndAHPStgInfos();
                    pdtAndAhpStgInfo.AddPDTAndAHPStgInfo_Dac(conn
                                                            , trx
                                                            , ver_id
                                                            , estterm_ref_id
                                                            , Convert.ToInt32(stgData.Rows[i]["STG_REF_ID"])
                                                            , Convert.ToInt32(stgData.Rows[i]["UP_STG_ID"])
                                                            , stgData.Rows[i]["STG_MAP_YN"].ToString()
                                                            , stgData.Rows[i]["F_YN"].ToString()
                                                            , stgData.Rows[i]["C_YN"].ToString()
                                                            , stgData.Rows[i]["P_YN"].ToString()
                                                            , stgData.Rows[i]["L_YN"].ToString()
                                                            , ""
                                                            , DateTime.Now
                                                            , create_update_user);
                }

                Biz_AHPEstDeptStgDatas ahpEstDeptStgDatas = new Biz_AHPEstDeptStgDatas();
                ahpEstDeptStgDatas.RemoveAHPEstDeptStgData(conn
                                                            , trx
                                                            , ver_id
                                                            , estterm_ref_id
                                                            , est_dept_ref_id);

                RemovePDTAndAHPStgEstDeptData(conn
                                            , trx
                                            , ver_id
                                            , estterm_ref_id
                                            , est_dept_ref_id
                                            , 0);
                

                for (int i = 0; i < estDeptData.Rows.Count; i++)
                {
                    if (est_dept_ref_id == Convert.ToInt32(estDeptData.Rows[i]["EST_DEPT_REF_ID"]))
                        AddPDTAndAHPStgEstDeptData_Dac(conn
                                                        , trx
                                                        , ver_id
                                                        , estterm_ref_id
                                                        , Convert.ToInt32(estDeptData.Rows[i]["EST_DEPT_REF_ID"])
                                                        , Convert.ToInt32(estDeptData.Rows[i]["STG_REF_ID"])
                                                        , estDeptData.Rows[i]["CHECK_YN"].ToString()
                                                        , ""
                                                        , DateTime.Now
                                                        , create_update_user);
                }

                trx.Commit();
            }
            catch(Exception e)
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

        public bool ModifyPDTAndAHPWeight(int ver_id
                                        , int estterm_ref_id
                                        , int est_dept_ref_id
                                        , int update_user
                                        , DataTable dataTable)
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    ModifyPDTAndAHPWeight_Dac(conn
                                            , trx
                                            , ver_id
                                            , estterm_ref_id
                                            , est_dept_ref_id
                                            , int.Parse(dr["STG_REF_ID"].ToString())
                                            , float.Parse(dr["MULTIPLY"].ToString())
                                            , float.Parse(dr["GEOMEAN"].ToString())
                                            , float.Parse(dr["WEIGHT"].ToString())
                                            , float.Parse(dr["SUM"].ToString())
                                            , float.Parse(dr["WS"].ToString())
                                            , float.Parse(dr["CI"].ToString())
                                            , float.Parse(dr["CR"].ToString())
                                            , update_user);
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

        public DataSet GetPDTAndAHPStgEstDeptData(int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int stg_ref_id) 
        {
            return GetPDTAndAHPStgEstDeptData_Dac(ver_id
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , stg_ref_id);

        }

        public DataSet GetAHPEstDeptStgList(int ver_id
                                            , int estterm_ref_id
                                            , int est_dept_ref_id)
        {
            return GetAHPEstDeptStgList_Dac(ver_id
                                            , estterm_ref_id
                                            , est_dept_ref_id);

        }

        public DataSet GetPDTAndAHPEstDeptStgList(int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , string check_yn)
        {
            return GetPDTAndAHPEstDeptStgList_Dac(ver_id
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , check_yn);

        }

        public DataSet GetPDTAndAHPDeployList(int ver_id
                                            , int estterm_ref_id
                                            , int est_dept_ref_id
                                            , int stg_ref_id
                                            , bool isSubDept)
        {
            return GetPDTAndAHPDeployList_Dac(ver_id
                                            , estterm_ref_id
                                            , est_dept_ref_id
                                            , stg_ref_id
                                            , isSubDept);
        }

        public bool RemovePDTAndAHPStgEstDeptData(IDbConnection conn
                                                                , IDbTransaction trx
                                                                , int ver_id
                                                                , int estterm_ref_id
                                                                , int est_dept_ref_id
                                                                , int stg_ref_id) 
        {
            return RemovePDTAndAHPStgEstDeptData_Dac(conn
                                                    , trx
                                                    , ver_id
                                                    , estterm_ref_id
                                                    , est_dept_ref_id
                                                    , stg_ref_id);
        }
    }
}
