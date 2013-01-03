using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Result_Expect
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Kpi_Result_Expect
    /// Class Func     : BSC_KPI_RESULT_EXPECT Business Logic Class
    /// CREATE DATE    : 2008-07-12 오전 9:49:56
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Kpi_Result_Expect  : Dac_Bsc_Kpi_Result_Expect
    {
        public Biz_Bsc_Kpi_Result_Expect() { }
        public Biz_Bsc_Kpi_Result_Expect(int iestterm_ref_id, int ikpi_ref_id, string iymd) : base( iestterm_ref_id,  ikpi_ref_id,  iymd) { }
		
        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, string iymd, decimal iresult_ms, decimal iresult_ts, string iexpect_reason_ms, string iexpect_reason_ts, string iexpect_reason_file_id, string iresult_diff_cause, string iresult_diff_file_id, int itxr_user) 
        {
            return base.InsertData_Dac( iestterm_ref_id,  ikpi_ref_id,  iymd,  iresult_ms,  iresult_ts,  iexpect_reason_ms,  iexpect_reason_ts,  iexpect_reason_file_id,  iresult_diff_cause,  iresult_diff_file_id, itxr_user);
        }
		
        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, string iymd, decimal iresult_ms, decimal iresult_ts, string iexpect_reason_ms, string iexpect_reason_ts, string iexpect_reason_file_id, string iresult_diff_cause, string iresult_diff_file_id, int itxr_user) 
        {
            return base.UpdateData_Dac( iestterm_ref_id,  ikpi_ref_id,  iymd,  iresult_ms,  iresult_ts,  iexpect_reason_ms,  iexpect_reason_ts,  iexpect_reason_file_id,  iresult_diff_cause,  iresult_diff_file_id, itxr_user);
        }
		
        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user) 
        {
            return base.DeleteData_Dac( iestterm_ref_id,  ikpi_ref_id,  iymd, itxr_user);
        }
	}
}