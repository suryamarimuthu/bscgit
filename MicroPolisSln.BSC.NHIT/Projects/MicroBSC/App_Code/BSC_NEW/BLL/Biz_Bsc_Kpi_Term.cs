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
/// Biz_Bsc_Kpi_Term의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Kpi_Info Biz 클래스
/// Class 내용		: Bsc_Kpi_Info Biz Logic 처리 
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
    public class Biz_Bsc_Kpi_Term : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Term
    {
        public Biz_Bsc_Kpi_Term() { }
        public Biz_Bsc_Kpi_Term(int iestterm_ref_id, int ikpi_ref_id, string iymd)
               : base(iestterm_ref_id, ikpi_ref_id, iymd) {}

        public int InsertData(int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
            return base.InsertData_Dac(iestterm_ref_id, ikpi_ref_id,  iymd, icheck_yn, 
                                       ireport_yn,      iestimate_yn, itxr_user);
        }

        public int UpdateData(int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
            return base.UpdateData_Dac(iestterm_ref_id, ikpi_ref_id,  iymd, icheck_yn, 
                                       ireport_yn,      iestimate_yn, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, 
                              int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, 
                                       iestterm_ref_id, ikpi_ref_id,  iymd, icheck_yn, 
                                       ireport_yn,      iestimate_yn, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, 
                              int    iestterm_ref_id, int ikpi_ref_id,     string iymd, string icheck_yn, 
                              string ireport_yn,      string iestimate_yn, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, 
                                       iestterm_ref_id, ikpi_ref_id,  iymd, icheck_yn, 
                                       ireport_yn,      iestimate_yn, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        {
            return base.DeleteData_Dac(conn,trx, iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        public DataSet GetMBOList(int estterm_ref_id, int kpi_ref_id)
        {
            return base.GetMBOList(estterm_ref_id, kpi_ref_id);
        }

        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id)
        {
            return base.GetAllList_Dac(iestterm_ref_id, ikpi_ref_id);

            //int cntRow = rDs.Tables[0].Rows.Count;
            //int cntCol = rDs.Tables[0].Columns.Count;
            //string strCol = "";

            //DataSet tDs = new DataSet();
            //DataTable tDt = new DataTable();
            //DataRow tDr;
            //tDt.Columns.Add("ESTTERM_REF_ID", typeof(int));
            //tDt.Columns.Add("KPI_REF_ID", typeof(int));
            //tDt.Columns.Add("TERM_TYPE", typeof(string));

            //for (int i = 0; i < cntRow; i++)
            //{
            //    tDt.Columns.Add(rDs.Tables[0].Rows[i]["YMD_DESC"].ToString(), typeof(string));
            //}

            //for (int i = 0; i < cntCol; i++)
            //{
            //    strCol = rDs.Tables[0].Columns[i].ColumnName;
            //    if (strCol == "CHECK_YN" || strCol == "REPORT_YN")
            //    {
            //        tDr = tDt.NewRow();
            //        tDr["ESTTERM_REF_ID"] = rDs.Tables[0].Rows[0]["ESTTERM_REF_ID"].ToString();
            //        tDr["KPI_REF_ID"] = rDs.Tables[0].Rows[0]["KPI_REF_ID"].ToString();
            //        tDr["TERM_TYPE"] = (strCol == "CHECK_YN") ? "측정주기" : "보고주기";
            //        for (int j = 0; j < cntRow; j++)
            //        {
            //            tDr[rDs.Tables[0].Rows[j]["YMD_DESC"].ToString()] = rDs.Tables[0].Rows[j][strCol].ToString();
            //        }

            //        tDt.Rows.Add(tDr);
            //    }
            //}

            //tDs.Tables.Add(tDt);

            //return tDs;
        }
    }
}
