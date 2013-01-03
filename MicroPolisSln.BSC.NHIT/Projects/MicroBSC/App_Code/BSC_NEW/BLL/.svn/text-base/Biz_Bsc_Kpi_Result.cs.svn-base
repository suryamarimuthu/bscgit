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
/// Biz_Bsc_Kpi_Result의 요약 설명입니다.
/// </summary>

/// <summary>
/// Biz_Bsc_Kpi_Result의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Kpi_Result Biz 클래스
/// Class 내용		: Bsc_Kpi_Result Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 방병현
/// 최초작성일		: 2007.04.26
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Kpi_Result : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Result
    {
        public Biz_Bsc_Kpi_Result() { }
        public Biz_Bsc_Kpi_Result(int iestterm_ref_id, int ikpi_ref_id, string iymd)
               : base(iestterm_ref_id, ikpi_ref_id, iymd) 
        {
            
        }

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                              int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                              string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id,
                              string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        {
            return base.InsertData_Dac(iestterm_ref_id, ikpi_ref_id, iymd, iresult_ms, iresult_ts,
                                       isequence, ical_result_ms, ical_result_ts, ical_apply_yn,
                                       ical_apply_reason, icause_text_ms, icause_text_ts, icause_file_id, 
                                       imeasure_text_ms, imeasure_text_ts, imeasure_file_id, iremark, itxr_user);
        }

        public DataSet GetKpiResultDataScheme()
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dataTable.Columns.Add("KPI_REF_ID", typeof(int));
            dataTable.Columns.Add("YMD", typeof(string));

            dataTable.Columns.Add("RESULT_MS", typeof(double));
            dataTable.Columns.Add("RESULT_TS", typeof(double));

            dataTable.Columns.Add("CAUSE_TEXT_MS", typeof(string));
            dataTable.Columns.Add("CAUSE_TEXT_TS", typeof(string));
            dataTable.Columns.Add("MEASURE_TEXT_MS", typeof(string));
            dataTable.Columns.Add("MEASURE_TEXT_TS", typeof(string));

            dataTable.Columns.Add("CHECKSTATUS", typeof(string));

            dataTable.Columns.Add("UPDATE_DATE", typeof(DateTime));
            dataTable.Columns.Add("UPDATE_USER", typeof(int));

            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        public DataSet GetResultTotalData(int estterm_ref_id
                                    , int kpi_ref_id)
        {
            return base.GetResultTotalData(estterm_ref_id
                                        , kpi_ref_id);
        }

        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                              int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                              string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id,
                              string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id, ikpi_ref_id, iymd, iresult_ms, iresult_ts,
                                       isequence, ical_result_ms, ical_result_ts, ical_apply_yn,
                                       ical_apply_reason, icause_text_ms, icause_text_ts, icause_file_id,
                                       imeasure_text_ms, imeasure_text_ts, imeasure_file_id, iremark, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        public int DeleteAllData(int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        { 
            return base.DeleteAllData_Dac(iestterm_ref_id, ikpi_ref_id, itxr_user);
        }

        public int Result_Confirm(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        { 
            return base.Result_Confirm_Dac(iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        public int Result_Cancel(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        { 
            return base.Result_Cancel_Dac(iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        //transaction

        public int InsertData(IDbConnection conn, IDbTransaction trx,
                              int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                              int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                              string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id,
                              string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx,
                                       iestterm_ref_id, ikpi_ref_id, iymd, iresult_ms, iresult_ts,
                                       isequence, ical_result_ms, ical_result_ts, ical_apply_yn,
                                       ical_apply_reason, icause_text_ms, icause_text_ts, icause_file_id,
                                       imeasure_text_ms, imeasure_text_ts, imeasure_file_id, iremark, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx,
                              int iestterm_ref_id, int ikpi_ref_id, string iymd, double iresult_ms, double iresult_ts,
                              int isequence, double ical_result_ms, double ical_result_ts, string ical_apply_yn,
                              string ical_apply_reason, string icause_text_ms, string icause_text_ts, string icause_file_id,
                              string imeasure_text_ms, string imeasure_text_ts, string imeasure_file_id, string iremark, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx,
                                       iestterm_ref_id, ikpi_ref_id, iymd, iresult_ms, iresult_ts,
                                       isequence, ical_result_ms, ical_result_ts, ical_apply_yn,
                                       ical_apply_reason, icause_text_ms, icause_text_ts, icause_file_id,
                                       imeasure_text_ms, imeasure_text_ts, imeasure_file_id, iremark, itxr_user);
        }

        public bool UpdateKpiResultDataByAdmin(DataTable dataTable)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result dac = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Result();
            int affectedRow = 0;

            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    affectedRow += dac.UpdateKpiResultDataByAdmin(conn
                                                                , trx
                                                                , dataRow["ESTTERM_REF_ID"]
                                                                , dataRow["KPI_REF_ID"]
                                                                , dataRow["YMD"]
                                                                , dataRow["RESULT_MS"]
                                                                , dataRow["RESULT_TS"]
                                                                , dataRow["CAUSE_TEXT_MS"]
                                                                , dataRow["CAUSE_TEXT_TS"]
                                                                , dataRow["MEASURE_TEXT_MS"]
                                                                , dataRow["MEASURE_TEXT_TS"]
                                                                , dataRow["CHECKSTATUS"]
                                                                , dataRow["UPDATE_DATE"]
                                                                , dataRow["UPDATE_USER"]);
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

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        public int DeleteAllData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int itxr_user)
        {
            return base.DeleteAllData_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, itxr_user);
        }

        public int Result_Confirm(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return base.Result_Confirm_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        public int Result_Cancel(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return base.Result_Cancel_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

    }
}
