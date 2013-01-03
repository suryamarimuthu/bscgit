using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;

using MicroBSC.BSC.Dac;
using MicroBSC.QueryEngine.QueryBuilder;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Interface_Kpi_Query
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Interface_Kpi_Query
    /// Class Func     : BSC_INTERFACE_KPI_QUERY Business Logic Class
    /// CREATE DATE    : 2008-07-27 오후 3:59:52
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Interface_Kpi_Query  : Dac_Bsc_Interface_Kpi_Query
    {
        public Biz_Bsc_Interface_Kpi_Query() { }
        public Biz_Bsc_Interface_Kpi_Query(int ikpi_ref_id, string idicode) : base( ikpi_ref_id,  idicode) { }

        public int InsertData(IDbConnection con, IDbTransaction trx, int ikpi_ref_id, string idicode, int iversion_no, string iactive_yn, string iresult_field_al, string iresult_where_al, string iresult_field_ms, string iresult_where_ms, string iresult_field_ts, string iresult_where_ts, string iquery_al, string iquery_ms, string iquery_ts, string iisvalid_query, string imodify_reason, int itxr_user) 
        {
            return base.InsertData_Dac(con, trx, ikpi_ref_id,  idicode,  iversion_no,  iactive_yn,  iresult_field_al,  iresult_where_al,  iresult_field_ms,  iresult_where_ms,  iresult_field_ts,  iresult_where_ts,  iquery_al,  iquery_ms,  iquery_ts,  iisvalid_query,  imodify_reason, itxr_user);
        }

        public int InsertData(int ikpi_ref_id, string idicode, int iversion_no, string iactive_yn, string iresult_field_al, string iresult_where_al, string iresult_field_ms, string iresult_where_ms, string iresult_field_ts, string iresult_where_ts, string iquery_al, string iquery_ms, string iquery_ts, string iisvalid_query, string imodify_reason, int itxr_user)
        {
            return base.InsertData_Dac(null, null, ikpi_ref_id, idicode, iversion_no, iactive_yn, iresult_field_al, iresult_where_al, iresult_field_ms, iresult_where_ms, iresult_field_ts, iresult_where_ts, iquery_al, iquery_ms, iquery_ts, iisvalid_query, imodify_reason, itxr_user);
        }

        public int UpdateData(IDbConnection con, IDbTransaction trx, int ikpi_ref_id, string idicode, int iversion_no, string iactive_yn, string iresult_field_al, string iresult_where_al, string iresult_field_ms, string iresult_where_ms, string iresult_field_ts, string iresult_where_ts, string iquery_al, string iquery_ms, string iquery_ts, string iisvalid_query, string imodify_reason, int itxr_user) 
        {
            return base.UpdateData_Dac(con, trx, ikpi_ref_id, idicode, iversion_no, iactive_yn, iresult_field_al, iresult_where_al, iresult_field_ms, iresult_where_ms, iresult_field_ts, iresult_where_ts, iquery_al, iquery_ms, iquery_ts, iisvalid_query, imodify_reason, itxr_user);
        }

        public int UpdateData(int ikpi_ref_id, string idicode, int iversion_no, string iactive_yn, string iresult_field_al, string iresult_where_al, string iresult_field_ms, string iresult_where_ms, string iresult_field_ts, string iresult_where_ts, string iquery_al, string iquery_ms, string iquery_ts, string iisvalid_query, string imodify_reason, int itxr_user)
        {
            return base.UpdateData_Dac(null, null, ikpi_ref_id, idicode, iversion_no, iactive_yn, iresult_field_al, iresult_where_al, iresult_field_ms, iresult_where_ms, iresult_field_ts, iresult_where_ts, iquery_al, iquery_ms, iquery_ts, iisvalid_query, imodify_reason, itxr_user);
        }

        public int DeleteData(IDbConnection con, IDbTransaction trx, int ikpi_ref_id, string idicode, int iversion_no, int itxr_user) 
        {
            return base.DeleteData_Dac(con, trx, ikpi_ref_id, idicode, iversion_no, itxr_user);
        }

        public int DeleteData(int ikpi_ref_id, string idicode, int iversion_no, int itxr_user)
        {
            return base.DeleteData_Dac(null, null, ikpi_ref_id, idicode, iversion_no, itxr_user);
        }

        /// <summary>
        /// 실적상세데이터 조회
        /// </summary>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="sCurYMD"></param>
        /// <returns></returns>
        public DataSet GetInterfaceData(int ikpi_ref_id, string sCurYMD, out string sMsg, out bool bIsSuccess)
        {
            Dac_Bsc_Interface_Kpi_Query objQry = new Dac_Bsc_Interface_Kpi_Query(ikpi_ref_id, "");

            DataSet rDs   = new DataSet();
            sMsg          = "";
            string sQuery = "";
            bIsSuccess    = false;

            try
            {
                sQuery = objQry.IQuery_Al;
                sQuery = sQuery.Replace(QueryOperator.ParamCurrYmd, "'" + sCurYMD + "'");
                sQuery = sQuery.Replace(QueryOperator.ParamFirstYmd, "'" + sCurYMD + "'");

                rDs = DbAgentObj.FillDataSet(sQuery, "INTERFACE_DATA");
                sMsg = "Success";
                bIsSuccess = true;
            }
            catch (Exception e)
            {
                sMsg = e.Message;
                bIsSuccess = false;
            }

            return rDs;
        }
        /// <summary>
        /// 실적상세데이터 조회 (검증용)
        /// </summary>
        /// <param name="sQuery"></param>
        /// <param name="sMsg"></param>
        /// <param name="bIsSuccess"></param>
        /// <returns></returns>
        public DataSet GetInterfaceData(string sQuery, string sCurYMD, out string sMsg, out bool bIsSuccess)
        {
            DataSet rDs = new DataSet();
            sMsg        = "";
            bIsSuccess  = false;

            try
            {
                sQuery = sQuery.Replace(QueryOperator.ParamCurrYmd, "'"  + sCurYMD + "'");
                sQuery = sQuery.Replace(QueryOperator.ParamFirstYmd, "'" + sCurYMD + "'");
                rDs = DbAgentObj.FillDataSet(sQuery, "INTERFACE_DATA");
                sMsg = "Success";
                bIsSuccess = true;
            }
            catch (Exception e)
            {
                sMsg = e.Message;
                bIsSuccess = false;
            }

            return rDs;
        }

        /// <summary>
        /// 당월 인터페이스 실적
        /// </summary>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="sCurYMD"></param>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public decimal GetInterfaceResultMs(int ikpi_ref_id, string sCurYMD, out string sMsg, out bool bIsSuccess)
        {
            Dac_Bsc_Interface_Kpi_Query objQry = new Dac_Bsc_Interface_Kpi_Query(ikpi_ref_id, "");
            DataSet rDs  = new DataSet();
            decimal rVal = 0;
            string sQry  = "";
            sMsg         = "";
            bIsSuccess   = false;

            try
            {
                sQry = objQry.IQuery_Ms;
                sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + sCurYMD + "'");
                sQry = sQry.Replace(QueryOperator.ParamFirstYmd, "'" + sCurYMD + "'");

                rDs  = DbAgentObj.FillDataSet(sQry, "INTERFACE_DATA");

                if (rDs.Tables.Count > 0)
                {
                    if (rDs.Tables[0].Rows.Count > 0)
                    {
                        rVal = (rDs.Tables[0].Rows[0][0] == DBNull.Value) ? 0 : decimal.Parse(rDs.Tables[0].Rows[0][0].ToString());
                        rVal = Math.Round(rVal, 4);
                    }
                    else
                    {
                        rVal = 0;
                    }
                }
                else
                {
                    rVal = 0;
                }
                sMsg = "Success";
                bIsSuccess = true;
            }
            catch (Exception e)
            {
                sMsg = e.Message;
                rVal = 0;
                bIsSuccess = false;
            }

            return rVal;
        }

        /// <summary>
        /// 당월 인터페이스 실적 (검증용)
        /// </summary>
        /// <param name="sQuery"></param>
        /// <param name="sCurYMD"></param>
        /// <param name="sMsg"></param>
        /// <param name="bIsSuccess"></param>
        /// <returns></returns>
        public decimal GetInterfaceResultMs(string sQuery, string sCurYMD, out string sMsg, out bool bIsSuccess)
        {
            DataSet rDs  = new DataSet();
            decimal rVal = 0;
            string sQry  = "";
            sMsg         = "";
            bIsSuccess   = false;

            try
            {
                sQry = sQuery;
                sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + sCurYMD + "'");
                sQry = sQry.Replace(QueryOperator.ParamFirstYmd, "'" + sCurYMD + "'");

                rDs  = DbAgentObj.FillDataSet(sQry, "INTERFACE_DATA");

                if (rDs.Tables.Count > 0)
                {
                    if (rDs.Tables[0].Rows.Count > 0)
                    {
                        rVal = (rDs.Tables[0].Rows[0][0] == DBNull.Value) ? 0 : decimal.Parse(rDs.Tables[0].Rows[0][0].ToString());
                        rVal = Math.Round(rVal, 4);
                    }
                    else
                    {
                        rVal = 0;
                    }
                }
                else
                {
                    rVal = 0;
                }
                sMsg = "Success";
                bIsSuccess = true;
            }
            catch (Exception e)
            {
                sMsg = e.Message;
                rVal = 0;
                bIsSuccess = false;
            }

            return rVal;
        }

        /// <summary>
        /// 누적 인터페이스 실적
        /// </summary>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="sIniYMD"></param>
        /// <param name="sCurYMD"></param>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public decimal GetInterfaceResultTs(int ikpi_ref_id, string sIniYMD, string sCurYMD, out string sMsg, out bool bIsSuccess)
        {
            Dac_Bsc_Interface_Kpi_Query objQry = new Dac_Bsc_Interface_Kpi_Query(ikpi_ref_id, "");
            DataSet rDs  = new DataSet();
            decimal rVal = 0;
            string sQry  = "";
            sMsg         = "";
            bIsSuccess   = false;

            try
            {
                sQry = objQry.IQuery_Ts;
                sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + sCurYMD + "'");
                sQry = sQry.Replace(QueryOperator.ParamFirstYmd, "'" + sIniYMD + "'");

                rDs  = DbAgentObj.FillDataSet(sQry, "INTERFACE_DATA");
                if (rDs.Tables.Count > 0)
                {
                    if (rDs.Tables[0].Rows.Count > 0)
                    {
                        rVal = (rDs.Tables[0].Rows[0][0] == DBNull.Value) ? 0 : decimal.Parse(rDs.Tables[0].Rows[0][0].ToString());
                        rVal = Math.Round(rVal, 4);
                    }
                    else
                    {
                        rVal = 0;
                    }
                }
                else
                {
                    rVal = 0;
                }
                sMsg = "Success";
                bIsSuccess = true;
            }
            catch (Exception e)
            {
                sMsg = e.Message;
                rVal = 0;
                bIsSuccess = false;
            }

            return rVal;
        }

        /// <summary>
        /// 누적 인터페이스 실적 (검증용)
        /// </summary>
        /// <param name="sQuery"></param>
        /// <param name="sIniYMD"></param>
        /// <param name="sCurYMD"></param>
        /// <param name="sMsg"></param>
        /// <param name="bIsSuccess"></param>
        /// <returns></returns>
        public decimal GetInterfaceResultTs(string sQuery, string sIniYMD, string sCurYMD, out string sMsg, out bool bIsSuccess)
        {
            DataSet rDs = new DataSet();
            decimal rVal = 0;
            string sQry = "";
            sMsg = "";
            bIsSuccess = false;

            try
            {
                sQry = sQuery;
                sQry = sQry.Replace(QueryOperator.ParamCurrYmd, "'" + sCurYMD + "'");
                sQry = sQry.Replace(QueryOperator.ParamFirstYmd, "'" + sIniYMD + "'");

                rDs = DbAgentObj.FillDataSet(sQry, "INTERFACE_DATA");
                if (rDs.Tables.Count > 0)
                {
                    if (rDs.Tables[0].Rows.Count > 0)
                    {
                        rVal = (rDs.Tables[0].Rows[0][0] == DBNull.Value) ? 0 : decimal.Parse(rDs.Tables[0].Rows[0][0].ToString());
                        rVal = Math.Round(rVal, 4);
                    }
                    else
                    {
                        rVal = 0;
                    }
                }
                else
                {
                    rVal = 0;
                }
                sMsg = "Success";
                bIsSuccess = true;
            }
            catch (Exception e)
            {
                sMsg = e.Message;
                rVal = 0;
                bIsSuccess = false;
            }

            return rVal;
        }

	}
}