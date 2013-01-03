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
    public class Dac_Bsc_Kpi_Target_Version : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================


        public int Delete_DB(IDbConnection idc
                                        , IDbTransaction idt
                                        , object estterm_ref_id
                                        , object kpi_ref_id)
        {


            string query = @"
-- KPI TARGET VERSION DELETE
DELETE FROM     BSC_KPI_TARGET_VERSION
    WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND     KPI_REF_ID      = @KPI_REF_ID
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




        public int Insert_DB(IDbConnection conn
                            , IDbTransaction trx
                            , object estterm_ref_id
                            , object kpi_ref_id
                            , object kpi_target_version_id
                            , object version_name
                            , object version_desc
                            , object version_number
                            , object update_term
                            , object use_yn
                            , object create_user_ref_id)
        {


            string query = @"
INSERT INTO     BSC_KPI_TARGET_VERSION
        (
            ESTTERM_REF_ID
            , KPI_REF_ID
            , KPI_TARGET_VERSION_ID
            , VERSION_NAME
            , VERSION_DESC         
            , VERSION_NUMBER
            , UPDATE_TERM
            , USE_YN
            , CREATE_USER
            , CREATE_DATE
        )
    VALUES 
        (
            @ESTTERM_REF_ID
            , @KPI_REF_ID
            , @KPI_TARGET_VERSION_ID
            , @VERSION_NAME
            , @VERSION_DESC
            , @VERSION_NUMBER
            , @UPDATE_TERM
            , @USE_YN
            , @CREATE_USER
            , GETDATE()
        ) 
";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value = kpi_target_version_id;
            paramArray[3] = CreateDataParameter("@VERSION_NAME", SqlDbType.NVarChar);
            paramArray[3].Value = version_name;
            paramArray[4] = CreateDataParameter("@VERSION_DESC", SqlDbType.NVarChar);
            paramArray[4].Value = version_desc;
            paramArray[5] = CreateDataParameter("@VERSION_NUMBER", SqlDbType.Int);
            paramArray[5].Value = version_number;
            paramArray[6] = CreateDataParameter("@UPDATE_TERM", SqlDbType.Int);
            paramArray[6].Value = update_term;
            paramArray[7] = CreateDataParameter("@USE_YN", SqlDbType.NChar);
            paramArray[7].Value = use_yn;
            paramArray[8] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[8].Value = create_user_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }
    }
}
