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
/// Biz_Bsc_Map_Sk_Ie의 요약 설명입니다.
/// </summary>
/// 
/// 
/// 
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Map_Sk_Ie : MicroBSC.BSC.Dac.Dac_Bsc_Map_Sk_Ie
    {
        public Biz_Bsc_Map_Sk_Ie()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }
        public Biz_Bsc_Map_Sk_Ie(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id)
            : base(iestterm_ref_id, iest_dept_ref_id, istg_ref_id, ikpi_ref_id, idept_ref_id, iwork_ref_id, iexec_ref_id) { }

        public int InsertData(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, int iorder_seq, int itxr_user)
        {
            return base.InsertData_Dac(iestterm_ref_id, iest_dept_ref_id, istg_ref_id, ikpi_ref_id, idept_ref_id, iwork_ref_id, iexec_ref_id, iorder_seq, itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, int iorder_seq, int itxr_user)
        {
            return base.UpdateData_Dac(iestterm_ref_id, iest_dept_ref_id, istg_ref_id, ikpi_ref_id, idept_ref_id, iwork_ref_id, iexec_ref_id, iorder_seq, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(iestterm_ref_id, iest_dept_ref_id, istg_ref_id, ikpi_ref_id, idept_ref_id, iwork_ref_id, iexec_ref_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, int iorder_seq, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, istg_ref_id, ikpi_ref_id, idept_ref_id, iwork_ref_id, iexec_ref_id, iorder_seq, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, int iorder_seq, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, istg_ref_id, ikpi_ref_id, idept_ref_id, iwork_ref_id, iexec_ref_id, iorder_seq, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, istg_ref_id, ikpi_ref_id, idept_ref_id, iwork_ref_id, iexec_ref_id, itxr_user);
        }

        public bool TxrAllBscSKIE(DataTable iDT)
        {
            int intRow = iDT.Rows.Count;
            int intTxrCnt = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

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
                                      , int.Parse(iDT.Rows[i]["STG_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["KPI_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["DEPT_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["WORK_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["EXEC_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["TXR_USER"].ToString())
                                        );

                    }
                    else
                    {
                        this.InsertData(conn
                                      , trx
                                      , int.Parse(iDT.Rows[i]["ESTTERM_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["EST_DEPT_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["STG_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["KPI_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["DEPT_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["WORK_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["EXEC_REF_ID"].ToString())
                                      , int.Parse(iDT.Rows[i]["ORDER_SEQ"].ToString())
                                      , int.Parse(iDT.Rows[i]["TXR_USER"].ToString())
                                        );
                    }

                }

                base.Transaction_Message = "정상적으로 처리되었습니다.";
                base.Transaction_Result = "Y";
                trx.Commit();
            }
            catch (Exception e)
            {
                base.Transaction_Message = e.Message;
                base.Transaction_Result = "N";
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
