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
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Biz_PDTAndAHPStgInfos
/// </summary>
namespace MicroBSC.Biz.BSC.Biz
{
    public class Biz_PDTAndAHPStgInfos : Dac.Dac_PDTAndAHPStgInfos
    {
        public Biz_PDTAndAHPStgInfos()
        {
            
        }

        public Biz_PDTAndAHPStgInfos(int ver_id, int estterm_ref_id, int stg_ref_id) : base(ver_id, estterm_ref_id, stg_ref_id)
        {

        }

        public DataSet GetPDTAndAHPStgInfo(int ver_id, int estterm_ref_id, int stg_ref_id)
        {
            return GetPDTAndAHPStgInfo_Dac(ver_id, estterm_ref_id, stg_ref_id);
        }

        public bool AddPDTAndAHPStgInfo(int ver_id
                                        , int estterm_ref_id
                                        , DataTable treeData
                                        , int create_update_user) 
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                //RemovePDTAndAHPStgInfo_Dac(conn, trx, ver_id, estterm_ref_id, 0);

                for(int i = 0; i < treeData.Rows.Count; i++) 
                {
                    AddPDTAndAHPStgInfo_Dac(conn
                                        , trx
                                        , ver_id
                                        , estterm_ref_id
                                        , Convert.ToInt32(treeData.Rows[i]["STG_REF_ID"])
                                        , Convert.ToInt32(treeData.Rows[i]["UP_STG_ID"])
                                        , treeData.Rows[i]["STG_MAP_YN"].ToString()
                                        , treeData.Rows[i]["F_YN"].ToString()
                                        , treeData.Rows[i]["C_YN"].ToString()
                                        , treeData.Rows[i]["P_YN"].ToString()
                                        , treeData.Rows[i]["L_YN"].ToString()
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

        public bool RemovePDTAndAHPStgInfo(IDbConnection conn
                                            , IDbTransaction trx
                                            , int ver_id
                                            , int estterm_ref_id
                                            , int stg_ref_id)
        {
            return RemovePDTAndAHPStgInfo_Dac(conn
                                            , trx
                                            , ver_id
                                            , estterm_ref_id
                                            , stg_ref_id);
        }
    }
}
