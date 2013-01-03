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
/// Dac_Bsc_Kpi_Target에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Target Dac 클래스
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
    public class Dac_Bsc_Kpi_Target : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================


        // 장동건 추가(for 성덕여왕)
        /// <summary>
        /// 버전별 수정계획 내역보기 (BSC0303M1.ASPX)
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="ikpi_target_version_id"></param>
        /// <returns></returns>
        /// 
        public DataSet GetAllList_Detail(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id)
        {
            string query = @"

SELECT  YMD
      , TARGET_MS     --AS '당월계획'
      , TARGET_TS    --AS '누적계획' 
  FROM BSC_KPI_TARGET 
 WHERE ESTTERM_REF_ID         = @iESTTERM_REF_ID
   AND KPI_REF_ID             = @iKPI_REF_ID
   AND (KPI_TARGET_VERSION_ID = @iKPI_TARGET_VERSION_ID   OR      @iKPI_TARGET_VERSION_ID    =  0)   
   
";

            query = DbAgentHelper.GetQueryStringReplace(query);

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_target_version_id;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_ALL"), "BSC_KPI_TARGET", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(query, "BSC_KPI_TARGET", null, paramArray, CommandType.Text);
            return ds;
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

INSERT INTO BSC_KPI_TARGET
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



        public int InsertData_DB_From_BSC_KPI_TARGET(IDbConnection conn
                                                    , IDbTransaction trx
                                                    , object estterm_ref_id
                                                    , object org_kpi_ref_id
                                                    , object kpi_ref_id
                                                    , object create_user_ref_id)
        {

            string query = @"

INSERT INTO     BSC_KPI_TARGET
            (   ESTTERM_REF_ID
                , KPI_REF_ID
                , KPI_TARGET_VERSION_ID
                , YMD
                , TARGET_MS
                , TARGET_TS
                , CREATE_DATE
                , CREATE_USER
            )
    SELECT
                ESTTERM_REF_ID
                , @KPI_REF_ID
                , KPI_TARGET_VERSION_ID
                , YMD
                , TARGET_MS
                , TARGET_TS
                , GETDATE()
                , @CREATE_USER
        FROM    BSC_KPI_TARGET
        WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
            AND KPI_REF_ID      = @ORG_KPI_REF_ID
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ORG_KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value = org_kpi_ref_id;
            paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value = kpi_ref_id;
            paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = create_user_ref_id;
            


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

UPDATE BSC_KPI_TARGET
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

        public DataSet Select_DB(object estterm_ref_id
                                , object kpi_ref_id
                                , string ymd)
        {
            string strQuery = @"

SELECT ESTTERM_REF_ID
      ,KPI_REF_ID
      ,KPI_TARGET_VERSION_ID
      ,YMD 
      ,TARGET_MS
      ,TARGET_TS
      ,dbo.fn_BSC_KPI_ACHEVE_RATE(ESTTERM_REF_ID, KPI_REF_ID,YMD,'MS') AS TARGET_DAL_MS
      ,dbo.fn_BSC_KPI_ACHEVE_RATE(ESTTERM_REF_ID, KPI_REF_ID,YMD,'TS') AS TARGET_DAL_TS
 FROM BSC_KPI_TARGET
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
  AND KPI_REF_ID     = @KPI_REF_ID
  AND YMD            = @YMD
ORDER BY KPI_TARGET_VERSION_ID DESC

";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar, 20);
            paramArray[2].Value = ymd;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet SelectMM_DB(object estterm_ref_id
                                , object kpi_ref_id
                                , string ymd)
        {
            string strQuery = @"
SELECT 
 A.KPI_REF_ID
,A.YMD
,SUBSTRING(A.YMD, 5 , 2) AS MM
,A.TARGET_MS 
,A.TARGET_TS
,B.RESULT_MS
,B.RESULT_TS
,C.TARGET_MS   AS GOAL_MS
,C.TARGET_TS   AS GOAL_TS
,dbo.fn_BSC_KPI_ACHEVE_RATE_GOAL(C.ESTTERM_REF_ID, C.KPI_REF_ID, C.YMD,'MS') AS GOAL_DAL_MS
,dbo.fn_BSC_KPI_ACHEVE_RATE_GOAL(C.ESTTERM_REF_ID, C.KPI_REF_ID, C.YMD,'TS') AS GOAL_DAL_TS
,dbo.fn_BSC_KPI_ACHEVE_RATE(A.ESTTERM_REF_ID, A.KPI_REF_ID, A.YMD,'MS') AS TARGET_DAL_MS
,dbo.fn_BSC_KPI_ACHEVE_RATE(A.ESTTERM_REF_ID, A.KPI_REF_ID, A.YMD,'TS') AS TARGET_DAL_TS
,A.KPI_TARGET_VERSION_ID
FROM BSC_KPI_TARGET A JOIN BSC_KPI_RESULT      B ON(    A.ESTTERM_REF_ID = B.ESTTERM_REF_ID
                                                    AND A.KPI_REF_ID     = B.KPI_REF_ID
                                                    AND A.YMD            = B.YMD)
           LEFT OUTER JOIN BSC_KPI_TARGET_GOAL C ON(    A.ESTTERM_REF_ID        = C.ESTTERM_REF_ID
                                                    AND A.KPI_REF_ID            = C.KPI_REF_ID
                                                    AND A.YMD                   = C.YMD
                                                    AND A.KPI_TARGET_VERSION_ID = C.KPI_TARGET_VERSION_ID
                                                   )
WHERE A.ESTTERM_REF_ID = @ESTTERM_REF_ID
  AND A.KPI_REF_ID     = @KPI_REF_ID
  AND (A.YMD           = @YMD            OR    @YMD        =''      )
  AND A.KPI_TARGET_VERSION_ID = ( SELECT MAX(KPI_TARGET_VERSION_ID) FROM BSC_KPI_TARGET
                                   WHERE ESTTERM_rEF_ID = A.ESTTERM_rEF_ID
                                     AND KPI_REF_ID     = A.KPI_REF_ID ) 
ORDER BY YMD 


";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar, 20);
            paramArray[2].Value = ymd;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);
            return ds;
        }



        public int Delete_DB(IDbConnection idc
                                        , IDbTransaction idt
                                        , object estterm_ref_id
                                        , object kpi_ref_id)
        {


            string query = @"
DELETE FROM BSC_KPI_TARGET
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


        public bool Proc_Update(IDbConnection conn, IDbTransaction trx
                                , object itype
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object ikpi_target_version_id
                                , object iymd
                                , object itarget_ms
                                , object itarget_ts
                                , object emp_ref_id)
        {
            bool Result = true;
            int affectedRow;


            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]           = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value     = itype;
            paramArray[1]           = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value     = iestterm_ref_id;
            paramArray[2]           = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value     = ikpi_ref_id;
            paramArray[3]           = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value     = ikpi_target_version_id;
            paramArray[4]           = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[4].Value     = iymd;
            paramArray[5]           = CreateDataParameter("@iTARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value     = itarget_ms;
            paramArray[6]           = CreateDataParameter("@iTARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value     = itarget_ts;
            paramArray[7]           = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value     = emp_ref_id;
            paramArray[8]           = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[8].Direction = ParameterDirection.Output;
            paramArray[9]           = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[9].Direction = ParameterDirection.Output;


            IDataParameterCollection col;
            affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            string rtnMSG = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            if (rtnMSG == "N")
                Result = false;

            return Result;
        }
    }
}
