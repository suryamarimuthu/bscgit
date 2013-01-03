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
    public class Dac_Bsc_Kpi_Pool_Ver_MAP : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================
        
        public int InsertData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object kpi_pool_ver_id
                                , object kpi_pool_ref_id
                                , object create_date
                                , object create_user)
        {

            string query = @"
INSERT INTO BSC_KPI_POOL_VER_MAP
  ( 
     KPI_POOL_VER_ID  
    ,KPI_POOL_REF_ID
    ,CREATE_DATE
    ,CREATE_USER
    ,UPDATE_DATE
    ,UPDATE_USER
  )
VALUES
  ( 
     @KPI_POOL_VER_ID  
    ,@KPI_POOL_REF_ID      
    ,@CREATE_DATE
    ,@CREATE_USER
    ,@CREATE_DATE
    ,@CREATE_USER  
  )
";
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_pool_ver_id;
            paramArray[1]               = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_pool_ref_id;
            paramArray[2]              = CreateDataParameter("@CREATE_DATE", SqlDbType.Date);
            paramArray[2].Value        = create_date;
            paramArray[3]              = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value        = create_user;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public int DeleteData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object kpi_pool_ver_id)
        {

            string query = @"
DELETE FROM BSC_KPI_POOL_VER_MAP
WHERE KPI_POOL_VER_ID    = @KPI_POOL_VER_ID 
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_pool_ver_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        public DataTable SelectData_DB(object kpi_pool_ver_id)
        {

            string query = @"
SELECT KPI_POOL_VER_ID  
     , KPI_POOL_REF_ID  
FROM BSC_KPI_POOL_VER_MAP
WHERE (KPI_POOL_VER_ID    = @KPI_POOL_VER_ID   OR  @KPI_POOL_VER_ID   =   0)
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[0].Value         = kpi_pool_ver_id;


            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_POOL_VER_MAP", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        #endregion

    }
}
