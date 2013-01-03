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
/// Dac_Bsc_Kpi_Info에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Info Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Term : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================


        public int Delete_DB(IDbConnection idc
                                        , IDbTransaction idt
                                        , object estterm_ref_id
                                        , object kpi_ref_id)
        {


            string query = @"
DELETE FROM BSC_KPI_TERM
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);

            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }
        #endregion





        public int Insert_DB(IDbConnection conn, IDbTransaction trx
                            , object estterm_ref_id
                            , object kpi_ref_id
                            , object ymd
                            , object check_yn
                            , object report_yn
                            , object estimate_yn
                            , object create_user_ref_id)
        {


            string query = @"
INSERT INTO     BSC_KPI_TERM
            (
                ESTTERM_REF_ID
                , KPI_REF_ID
                , YMD
                , CHECK_YN
                , REPORT_YN
                , ESTIMATE_YN
                , CREATE_USER
            )
    VALUES
            (
                @ESTTERM_REF_ID
                , @KPI_REF_ID
                , @YMD
                , @CHECK_YN
                , @REPORT_YN
                , @ESTIMATE_YN
                , @CREATE_USER

            )
";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.NVarChar);
            paramArray[2].Value = ymd;
            paramArray[3] = CreateDataParameter("@CHECK_YN", SqlDbType.NChar);
            paramArray[3].Value = check_yn;
            paramArray[4] = CreateDataParameter("@REPORT_YN", SqlDbType.NChar);
            paramArray[4].Value = report_yn;
            paramArray[5] = CreateDataParameter("@ESTIMATE_YN", SqlDbType.NChar);
            paramArray[5].Value = estimate_yn;
            paramArray[6] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[6].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            return affectedRow;
        }



        public int Insert_DB_From_Bsc_Kpi_Term(IDbConnection conn, IDbTransaction trx
                                            , object estterm_ref_id
                                            , object kpi_ref_id
                                            , object org_kpi_ref_id
                                            , object create_user_ref_id)
        {


            string query = @"
INSERT INTO     BSC_KPI_TERM
            (   ESTTERM_REF_ID
                , KPI_REF_ID
                , YMD
                , CHECK_YN
                , CREATE_DATE
                , CREATE_USER
            )
    SELECT
                @ESTTERM_REF_ID
                , @KPI_REF_ID
                , YMD
                , CHECK_YN
                , GETDATE()
                , @CREATE_USER
    FROM        BSC_KPI_TERM
    WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND     KPI_REF_ID      = @ORG_KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = org_kpi_ref_id;
            paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            return affectedRow;
        }
    }
}
