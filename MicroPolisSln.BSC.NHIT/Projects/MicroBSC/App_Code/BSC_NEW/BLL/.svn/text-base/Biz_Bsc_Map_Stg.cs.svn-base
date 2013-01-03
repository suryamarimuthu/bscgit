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
/// Biz_Bsc_Map_Stg에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Biz_Bsc_Map_Stg Biz 클래스
/// Class 내용		@ Bsc_Map_Stg Biz 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.06.19
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------

namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Map_Stg : MicroBSC.BSC.Dac.Dac_Bsc_Map_Stg
    {
        public int InsertData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        {
            return base.InsertData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, iview_ref_id, isort_order, itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, iview_ref_id, isort_order, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, iview_ref_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, iview_ref_id, isort_order, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int isort_order, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, iview_ref_id, isort_order, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int istg_ref_id, int iview_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, istg_ref_id, iview_ref_id, itxr_user);
        }

        public bool TxrAllBscStgMap(DataTable iDT)
        {
            int intRow         = iDT.Rows.Count;
            int intTxrCnt      = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg_Parent objPrt = new Biz_Bsc_Map_Stg_Parent();
            MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKpi = new Biz_Bsc_Map_Kpi();

            try
            {
                for (int i = 0; i < intRow; i++)
                {
                    if (iDT.Rows[i]["ITYPE"].ToString() == "D")
                    {
                        this.DeleteData(conn
                                      , trx
                                      , int.Parse(iDT.Rows[i]["ESTTERM_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["MAP_VERSION_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["STG_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["VIEW_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["TXR_USER"].ToString())
                                        );
                        objPrt.DeleteAllData
                                      (conn
                                      , trx
                                      , int.Parse(iDT.Rows[i]["ESTTERM_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["MAP_VERSION_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["STG_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["TXR_USER"].ToString())
                                      );
                        objKpi.DeleteKpiPerStgData
                                     (conn
                                      , trx
                                      , int.Parse(iDT.Rows[i]["ESTTERM_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["MAP_VERSION_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["STG_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["TXR_USER"].ToString())
                                     );
                        
                    }
                    else
                    {
                        this.InsertData(conn
                                      , trx
                                      , int.Parse(iDT.Rows[i]["ESTTERM_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["MAP_VERSION_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["STG_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["VIEW_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["SORT_ORDER"].ToString())
                                      , int.Parse(iDT.Rows[i]["TXR_USER"].ToString())
                                        );
                    }

                }

                base.Transaction_Message = "정상적으로 처리되었습니다.";
                base.Transaction_Result  = "Y";
                trx.Commit();
            }
            catch (Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result  = "N";
                trx.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }
    }
}