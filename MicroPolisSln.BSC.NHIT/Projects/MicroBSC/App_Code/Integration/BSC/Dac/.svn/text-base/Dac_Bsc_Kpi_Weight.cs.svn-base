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
/// Dac_Bsc_Kpi_Weight에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Weight Dac 클래스
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
    public class Dac_Bsc_Kpi_Weight : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================


        public DataSet SelectForMap_DB(object estterm_ref_id
                                     , object ymd
                                     , object dept_type)
        {
            string query = @"


SELECT   KW.ESTTERM_REF_ID
        ,KW.YMD
        ,KW.EST_DEPT_REF_ID
        ,ED.DEPT_NAME
        ,SUM(ISNULL(KW.WEIGHT3,0)* (CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE CAST(TS.POINTS_TS AS FLOAT)*0.01 END)) as SCORE_MS
        ,SUM(ISNULL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE CAST(TS.POINTS_TS AS FLOAT)*0.01 END)) as SCORE_TS
FROM BSC_KPI_WEIGHT KW 
LEFT JOIN BSC_KPI_SCORE TS
      ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
     AND KW.KPI_REF_ID     = TS.KPI_REF_ID
     AND KW.YMD            = TS.YMD
     AND KW.ESTTERM_REF_ID = @ESTTERM_REF_ID
LEFT JOIN EST_DEPT_INFO ED
      ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
     AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
WHERE ED.DEPT_TYPE            = @DEPT_TYPE
AND KW.YMD                  = @YMD
AND ED.DEPT_REF_ID IS NOT NULL
GROUP BY KW.ESTTERM_REF_ID,
    KW.YMD,
    KW.EST_DEPT_REF_ID,
    ED.DEPT_NAME   


";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
            paramArray[2].Value = dept_type;

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
