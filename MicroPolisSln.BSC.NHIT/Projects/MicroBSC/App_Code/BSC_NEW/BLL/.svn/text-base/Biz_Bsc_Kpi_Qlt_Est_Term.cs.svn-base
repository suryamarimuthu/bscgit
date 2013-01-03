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
    /// Biz_Bsc_Kpi_Qlt_Est_Term
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Kpi_Qlt_Est_Term
    /// Class Func     : BSC_KPI_QLT_EST_TERM Business Logic Class
    /// CREATE DATE    : 2009-03-24 오후 4:10:18
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Kpi_Qlt_Est_Term  : Dac_Bsc_Kpi_Qlt_Est_Term
    {
        public Biz_Bsc_Kpi_Qlt_Est_Term() { }
        public Biz_Bsc_Kpi_Qlt_Est_Term(int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd) : base( iestterm_ref_id,  igroup_ref_id,  iest_level,  iymd) { }

        public int InsertData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd, string iest_yn, string ibias_yn, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx,  iestterm_ref_id,  igroup_ref_id,  iest_level,  iymd, iest_yn,  ibias_yn, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd, string iest_yn, string ibias_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx,  iestterm_ref_id,  igroup_ref_id,  iest_level,  iymd, iest_yn,  ibias_yn, itxr_user);
        }
		
        public int DeleteData(IDbConnection con, IDbTransaction trx, int iestterm_ref_id, int igroup_ref_id, int iest_level, string iymd, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx,  iestterm_ref_id,  igroup_ref_id,  iest_level,  iymd, itxr_user);
        }

        public int TrxListData(DataTable iDt)
        {
            int iRow = iDt.Rows.Count;

            IDbConnection con = DbAgentHelper.CreateDbConnection();
            con.Open();
            IDbTransaction trx = con.BeginTransaction();

            int iRtn = 0;
            try
            {
                for (int i = 0; i < iRow; i++)
                {
                    iRtn += base.UpdateData_Dac
                        (con
                        , trx
                        , int.Parse(iDt.Rows[i]["ESTTERM_REF_ID"].ToString())
                        , int.Parse(iDt.Rows[i]["GROUP_REF_ID"].ToString())
                        , int.Parse(iDt.Rows[i]["EST_LEVEL"].ToString())
                        , iDt.Rows[i]["YMD"].ToString()
                        , iDt.Rows[i]["EST_YN"].ToString()
                        , iDt.Rows[i]["BIAS_YN"].ToString()
                        , int.Parse(iDt.Rows[i]["TXR_USER"].ToString())
                       );
                }
                trx.Commit();
            }
            catch (Exception e)
            {
                trx.Rollback();
                base.Transaction_Message = e.Message;
            }
            finally
            {
                con.Close();
            }

            return iRtn;
        }

        public DataTable GetSchema()
        {
            DataTable dt = new DataTable("BSC_KPI_QLT_EST_TERM");
            dt.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dt.Columns.Add("GROUP_REF_ID"  , typeof(int));
            dt.Columns.Add("EST_LEVEL"     , typeof(int));
            dt.Columns.Add("YMD"           , typeof(string));
            dt.Columns.Add("EST_YN"        , typeof(string));
            dt.Columns.Add("BIAS_YN"       , typeof(string));
            dt.Columns.Add("TXR_USER"      , typeof(int));
            return dt;
        }
	}
}