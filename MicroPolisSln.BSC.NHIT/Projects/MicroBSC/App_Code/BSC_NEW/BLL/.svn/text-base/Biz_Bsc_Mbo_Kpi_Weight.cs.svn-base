using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.BSC.Dac;
using MicroBSC.Data;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Mbo_Kpi_Weight
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Mbo_Kpi_Weight
    /// Class Func     : BSC_MBO_KPI_WEIGHT Business Logic Class
    /// CREATE DATE    : 2008-04-18 오후 1:17:48
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Mbo_Kpi_Weight  : Dac_Bsc_Mbo_Kpi_Weight
    {
        public Biz_Bsc_Mbo_Kpi_Weight() { }
        public Biz_Bsc_Mbo_Kpi_Weight(int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id) : base( iestterm_ref_id,  iemp_ref_id,  ikpi_ref_id) { }
		
        public int InsertData(int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id, decimal iweight, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac( iestterm_ref_id,  iemp_ref_id,  ikpi_ref_id,  iweight,  iuse_yn, itxr_user);
        }
		
        public int UpdateData(int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id, decimal iweight, string iuse_yn, int itxr_user) 
        {

            return base.UpdateData_Dac( iestterm_ref_id,  iemp_ref_id,  ikpi_ref_id,  iweight,  iuse_yn, itxr_user);
        }
		
        public int DeleteData(int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac( iestterm_ref_id,  iemp_ref_id,  ikpi_ref_id, itxr_user);
        }

        public bool UpdateMBOWeight(int emp_ref_id, DataTable dt)
        {
            bool rtnValue = false;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.UpdateMBOWeight(conn, trx, emp_ref_id, dt);

                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
                rtnValue = false;
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }


        /// <summary>
        /// 가중치 입력과 둥시에 확정
        /// </summary>
        public bool UpdateMBOWeight(int emp_ref_id, DataTable dt, bool is_confirm)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();


            bool rtnValue = false;
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.UpdateMBOWeight(conn, trx, emp_ref_id, dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int estterm_ref_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_REF_ID"]);
                    int kpi_ref_id = DataTypeUtility.GetToInt32(dt.Rows[i]["KPI_REF_ID"]);

                    affectedRow += objBSC.ConfirmMBO(estterm_ref_id, kpi_ref_id, is_confirm);
                }

                if (rtnValue && affectedRow == dt.Rows.Count)
                {
                    trx.Commit();
                }
                else
                {
                    trx.Rollback();
                    rtnValue = false;
                }
            }
            catch
            {
                trx.Rollback();
                rtnValue = false;
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public bool DeleteMBOWeight(DataTable dt, int emp_ref_id)
        {
            bool rtnValue = false;
            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                rtnValue = base.DeleteMBOWeight(conn, trx, dt, emp_ref_id);

                if (rtnValue)
                    trx.Commit();
                else
                    trx.Rollback();
            }
            catch
            {
                trx.Rollback();
            }
            finally
            {
                conn.Close();
            }
            return rtnValue;
        }

        public object[,] GetMboApprovalState(int estterm_ref_id
                                        , int emp_ref_id)
        {
            return base.GetMboApprovalState(estterm_ref_id
                                            , emp_ref_id);
        }

        public object[,] GetMboApprovalStateByKpi(int estterm_ref_id
                                                , int kpi_ref_id)
        {
            return base.GetMboApprovalStateByKpi(estterm_ref_id, kpi_ref_id);
        }
	}
}