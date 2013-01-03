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
using MicroBSC.Biz.BSC;

/// <summary>
/// Summary description for Biz_PDTAndAHPVersions
/// </summary>
namespace MicroBSC.Biz.BSC.Biz
{
    public class Biz_PDTAndAHPVersions : Dac.Dac_PDTAndAHPVersions
    {
        public Biz_PDTAndAHPVersions()
        {
            
        }

        public Biz_PDTAndAHPVersions(int ver_id, int estterm_ref_id) : base(ver_id, estterm_ref_id)
        {

        }

        public DataSet GetPdtAhpVersions(int estterm_ref_id) 
        {
            return GetPDTAndAhpVersion_Dac(0, estterm_ref_id);
        }

        public DataSet GetPdtAhpVersion(int ver_id, int estterm_ref_id)
        {
            return GetPDTAndAhpVersion_Dac(ver_id, estterm_ref_id);
        }

        public bool AddPdtAhpVersion (int estterm_ref_id
                                    , string ver_name
                                    , string ver_desc
                                    , int create_user)
        {
            return AddPDTAndAHPVersion_Dac(estterm_ref_id, ver_name, ver_desc, DateTime.Now, create_user);
        }

        public bool RemovePdtAhpVersion(int ver_id, int estterm_ref_id) 
        {
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                Biz_AHPEstDeptStgDatas ahpEstDeptStg = new Biz_AHPEstDeptStgDatas();
                ahpEstDeptStg.RemoveAHPEstDeptStgData(conn
                                                        , trx
                                                        , ver_id
                                                        , estterm_ref_id
                                                        , 0);

                Biz_AHPEstDeptStgDatas ahpEstDeptStgDatas = new Biz_AHPEstDeptStgDatas();
                ahpEstDeptStgDatas.RemoveAHPEstDeptStgData_Dac(conn
                                                                , trx
                                                                , ver_id
                                                                , estterm_ref_id
                                                                , 0
                                                                , 0
                                                                , 0);

                Biz_PDTAndAHPStgEstDeptDatas pdtAndAHPStgEstDeptDatas = new Biz_PDTAndAHPStgEstDeptDatas();
                pdtAndAHPStgEstDeptDatas.RemovePDTAndAHPStgEstDeptData(conn
                                                                        , trx
                                                                        , ver_id
                                                                        , estterm_ref_id
                                                                        , 0
                                                                        , 0);

                RemovePDAAndAHPVersion_Dac(conn, trx, ver_id, estterm_ref_id);

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

            return true;
        }

        public bool ModifyPdtAhpVersion(int ver_id
                                    , int estterm_ref_id
                                    , string ver_name
                                    , string ver_desc
                                    , int update_user)
        {
            return ModifyPDTAndAHPVersion_Dac(ver_id
                                            , estterm_ref_id
                                            , ver_name
                                            , ver_desc
                                            , DateTime.Now
                                            , update_user);
        }
    }
}
