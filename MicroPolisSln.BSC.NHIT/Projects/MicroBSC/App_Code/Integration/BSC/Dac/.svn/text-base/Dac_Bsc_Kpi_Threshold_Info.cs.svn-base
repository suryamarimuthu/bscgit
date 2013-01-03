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
    public class Dac_Bsc_Kpi_Threshold_Info : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================


        public int Delete_DB(IDbConnection idc
                                        , IDbTransaction idt
                                        , object estterm_ref_id
                                        , object kpi_ref_id)
        {


            string query = @"
DELETE FROM BSC_KPI_THRESHOLD_INFO
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



        public int InsertData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object estterm_ref_id
                                , object kpi_ref_id
                                , object threshold_ref_id
                                , object threshold_level
                                , object set_min_value
                                , object set_txt_value
                                , object set_max_value
                                , object achieve_rate
                                , object create_date
                                , object create_user)
        {
            string query = @"
INSERT INTO     BSC_KPI_THRESHOLD_INFO
            (
                ESTTERM_REF_ID
                , KPI_REF_ID
                , THRESHOLD_REF_ID
                , THRESHOLD_LEVEL
                , SET_MIN_VALUE
                , SET_TXT_VALUE
                , SET_MAX_VALUE
                , ACHIEVE_RATE
                , CREATE_DATE
                , CREATE_USER
            )
    VALUES  (
               @ESTTERM_REF_ID
                , @KPI_REF_ID
                , @THRESHOLD_REF_ID
                , @THRESHOLD_LEVEL
                , @SET_MIN_VALUE
                , @SET_TXT_VALUE
                , @SET_MAX_VALUE
                , @ACHIEVE_RATE
                , @CREATE_DATE
                , @CREATE_USER
            )
               
";




//            string nonPRS = @"
//                , 0
//                , ''
//                , 0
//                , 0
//";


            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[2].Value = threshold_ref_id;
            paramArray[3] = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.Int);
            paramArray[3].Value = threshold_level;
            paramArray[4] = CreateDataParameter("@SET_MIN_VALUE", SqlDbType.Int);
            paramArray[4].Value = set_min_value;
            paramArray[5] = CreateDataParameter("@SET_TXT_VALUE", SqlDbType.Int);
            paramArray[5].Value = set_txt_value;
            paramArray[6] = CreateDataParameter("@SET_MAX_VALUE", SqlDbType.Int);
            paramArray[6].Value = set_max_value;
            paramArray[7] = CreateDataParameter("@ACHIEVE_RATE", SqlDbType.Int);
            paramArray[7].Value = achieve_rate;
            paramArray[8] = CreateDataParameter("@CREATE_DATE", SqlDbType.Int);
            paramArray[8].Value = create_date;
            paramArray[9] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[9].Value = create_user;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            return affectedRow;
        }


        #endregion



        public int Insert_DB_From_Bsc_Kpi_Threshold_Info(IDbConnection conn, IDbTransaction trx
                                                        , object class_type
                                                        , object estterm_ref_id
                                                        , object kpi_ref_id
                                                        , object org_kpi_ref_id
                                                        , object create_user_ref_id)
        {
            string query = @"
INSERT INTO     BSC_KPI_THRESHOLD_INFO
            (
                ESTTERM_REF_ID
                , KPI_REF_ID
                , THRESHOLD_REF_ID
                , THRESHOLD_LEVEL
                , SET_MIN_VALUE
                , SET_TXT_VALUE
                , SET_MAX_VALUE
                , ACHIEVE_RATE
                , CREATE_DATE
                , CREATE_USER
            )
    SELECT
                @ESTTERM_REF_ID
                , @KPI_REF_ID
                , THRESHOLD_REF_ID
                , THRESHOLD_LEVEL
                {0}
                , GETDATE()
                , @CREATE_USER
    FROM        BSC_KPI_THRESHOLD_INFO
    WHERE       ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND     KPI_REF_ID      = @ORG_KPI_REF_ID
";



            string PRS = @"
                , SET_MIN_VALUE
                , SET_TXT_VALUE
                , SET_MAX_VALUE
                , ACHIEVE_RATE
";

            string nonPRS = @"
                , 0
                , ''
                , 0
                , 0
";


            if (class_type.ToString().Equals("PRS"))
            {
                query = string.Format(query, PRS);
            }
            else
            {
                query = string.Format(query, nonPRS);
            }

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2]       = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = org_kpi_ref_id;
            paramArray[3]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = create_user_ref_id;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
            return affectedRow;
        }
    }
}
