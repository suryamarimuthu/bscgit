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
/// Dac_Bsc_Est_Dept_Grade에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Est_Dept_Grade Dac 클래스
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
    public class Dac_Bsc_Est_Dept_Grade : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================


        public DataSet SelectForMap_DB(object estterm_ref_id
                                     , object dept_type)
        {
            string query = @"


SELECT   DG.ESTTERM_REF_ID
        ,DG.EST_DEPT_TYPE
        ,ISNULL(DT.TYPE_NAME,'') as TYPE_NAME
        ,DG.GRADE_REF_ID 
        ,DG.GRADE_NAME    
        ,DG.MIN_VALUE     
        ,DG.MAX_VALUE     
        ,DG.MID_GRADE_YN
        ,DG.SORT_ORDER    
        ,DG.USE_YN        
        ,DG.CREATE_USER   
        ,DG.CREATE_DATE   
        ,DG.UPDATE_USER   
        ,DG.UPDATE_DATE   
FROM BSC_EST_DEPT_GRADE DG
LEFT JOIN COM_DEPT_TYPE_INFO DT
     ON DG.EST_DEPT_TYPE = DT.TYPE_REF_ID
WHERE DG.ESTTERM_REF_ID = @ESTTERM_REF_ID
AND DG.EST_DEPT_TYPE  = CASE WHEN ISNULL(@DEPT_TYPE,0) < 1 THEN DG.EST_DEPT_TYPE ELSE @DEPT_TYPE END
ORDER BY DG.EST_DEPT_TYPE, DG.SORT_ORDER


";

            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
            paramArray[1].Value = dept_type;

            return DbAgentObj.FillDataSet(query, "BSC_KPI_WEIGHT", null, paramArray, CommandType.Text);
        }


        public int InsertData_DB(IDbConnection conn
                            , IDbTransaction trx
                            , object iestterm_ref_id
                            , object ikpi_ref_id
                            , object ikpi_target_version_id
                            , object iymd
                            , object itarget_ms
                            , object itarget_ts
                            , object itxr_user)
        {

            string query = @"

INSERT INTO BSC_KPI_TARGET_GOAL
( ESTTERM_REF_ID
, KPI_REF_ID
, KPI_TARGET_VERSION_ID
, YMD
, TARGET_MS
, TARGET_TS
, CREATE_DATE
, CREATE_USER)
VALUES
( @ESTTERM_REF_ID
, @KPI_REF_ID
, @KPI_TARGET_VERSION_ID
, @YMD
, @TARGET_MS
, @TARGET_TS
, GETDATE()
, @TXR_USER)

";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@TXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@TARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@TARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);


            return affectedRow;
        }

        public int UpdateData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object ikpi_target_version_id
                                , object iymd
                                , object itarget_ms
                                , object itarget_ts
                                , object itxr_user)
        {

            string query = @"

UPDATE BSC_KPI_TARGET_GOAL
SET TARGET_MS             = @TARGET_MS
   ,TARGET_TS             = @TARGET_TS
   ,UPDATE_DATE           = GETDATE()
   ,UPDATE_USER           = @TXR_USER 
WHERE ESTTERM_REF_ID        = @ESTTERM_REF_ID
AND KPI_REF_ID            = @KPI_REF_ID    
AND KPI_TARGET_VERSION_ID = @KPI_TARGET_VERSION_ID
AND YMD                   = @YMD

";
            
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@TXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@TARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@TARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        
        public int DeleteData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object ikpi_target_version_id)
        {

            string query = @"

DELETE BSC_KPI_TARGET_GOAL
WHERE ESTTERM_REF_ID          = @ESTTERM_REF_ID
    AND KPI_REF_ID            = @KPI_REF_ID    
    AND KPI_TARGET_VERSION_ID = @KPI_TARGET_VERSION_ID

";
            
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_target_version_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        #endregion

    }
}
