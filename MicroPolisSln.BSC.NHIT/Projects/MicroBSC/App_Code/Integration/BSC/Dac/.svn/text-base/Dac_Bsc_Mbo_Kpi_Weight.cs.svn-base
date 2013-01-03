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
/// Dac_Bsc_Mbo_Kpi_Weight에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Mbo_Kpi_Weight Dac 클래스
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
    public class Dac_Bsc_Mbo_Kpi_Weight : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================
        
        /// <summary>
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="tgt_emp_id"></param>
        /// <returns></returns>
        /// 
        public DataTable SelectGraph_Data(object comp_id
                                        , object iestterm_ref_id
                                        , object iestterm_sub_id
                                        , object tgt_emp_id
                                        , object is_team_kpi)
        {
            string query = @"


SELECT   A.KPI_REF_ID
        ,C.KPI_NAME
        ,ISNULL(A.WEIGHT, 0) AS WEIGHT
        ,CASE WHEN ISNULL(G.TARGET_TS, 0) = 0 THEN 0 ELSE ISNULL(H.RESULT_TS / G.TARGET_TS * 100, 0) END   AS RESULT
        ,SUM(ISNULL(ISNULL(CAST(ISNULL(D2.SEGMENT1, 0) AS FLOAT), 0) * ISNULL(E.WEIGHT, 0) / 100, 0))   AS POINT
FROM    BSC_MBO_KPI_WEIGHT  A
LEFT OUTER JOIN BSC_KPI_INFO    B
    ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
    AND B.KPI_REF_ID        = A.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    C
    ON  C.KPI_POOL_REF_ID   = B.KPI_POOL_REF_ID
LEFT OUTER JOIN BSC_MBO_KPI_SCORE_DT    D
    ON  D.COMP_ID           = @COMP_ID
    AND D.EST_ID            = '3GA'
    AND D.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
    AND D.ESTTERM_SUB_ID    = @ESTTERM_SUB_ID
    AND D.KPI_REF_ID        = A.KPI_REF_ID
    AND D.TGT_EMP_ID        = A.EMP_REF_ID
LEFT OUTER JOIN COM_CODE_INFO           D2
    ON  D2.CATEGORY_CODE    = 'BS015'
    AND D2.ETC_CODE         = D.SCORE_GRADE
LEFT OUTER JOIN EST_TERM_STEP_EST_MAP   E
    ON  E.COMP_ID           = D.COMP_ID
    AND E.EST_ID            = D.EST_ID
    AND E.ESTTERM_STEP_ID   = D.ESTTERM_STEP_ID
LEFT OUTER JOIN BSC_KPI_TARGET_VERSION  F   ON  F.ESTTERM_REF_ID    = D.ESTTERM_REF_ID
                                            AND F.KPI_REF_ID        = D.KPI_REF_ID
                                            AND F.USE_YN            = 'Y'
LEFT OUTER JOIN BSC_KPI_TARGET          G   ON  G.ESTTERM_REF_ID    = F.ESTTERM_REF_ID
                                            AND G.KPI_REF_ID        = F.KPI_REF_ID
                                            AND G.KPI_TARGET_VERSION_ID = F.KPI_TARGET_VERSION_ID
                                            AND G.YMD                   = D.YMD
LEFT OUTER JOIN BSC_KPI_RESULT          H   ON  H.ESTTERM_REF_ID    = G.ESTTERM_REF_ID
                                            AND H.KPI_REF_ID        = G.KPI_REF_ID
                                            AND H.YMD               = G.YMD
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.EMP_REF_ID        = @TGT_EMP_ID
    AND A.USE_YN            = 'Y'
    AND (B.IS_TEAM_KPI  = @IS_TEAM_KPI OR @IS_TEAM_KPI      =''    )
GROUP BY A.KPI_REF_ID, C.KPI_NAME, ISNULL(A.WEIGHT, 0), CASE WHEN ISNULL(G.TARGET_TS, 0) = 0 THEN 0 ELSE ISNULL(H.RESULT_TS / G.TARGET_TS * 100, 0) END
ORDER BY A.KPI_REF_ID
   
";

            query = DbAgentHelper.GetQueryStringReplace(query);

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[1].Value         = tgt_emp_id;
            paramArray[2]               = CreateDataParameter("@IS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[2].Value         = is_team_kpi;
            paramArray[3]               = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value         = iestterm_ref_id;
            paramArray[4]               = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[4].Value         = comp_id;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_ALL"), "BSC_KPI_TARGET", null, paramArray, CommandType.StoredProcedure);
            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectData_DB(object iestterm_ref_id
                                        , object emp_ref_id
                                        , object use_yn)
        {
            string query = @"

SELECT ESTTERM_REF_ID
      ,EMP_REF_ID 
      ,KPI_REF_ID
      ,WEIGHT
      ,USE_YN
FROM BSC_MBO_KPI_WEIGHT 
WHERE (ESTTERM_REF_ID = @ESTTERM_REF_ID    OR  @ESTTERM_REF_ID  =   0  )
  AND (EMP_REF_ID     = @EMP_REF_ID        OR  @EMP_REF_ID      =   0  )
  AND (USE_YN         = @USE_YN            OR  @USE_YN          =''    ) -- 'Y'
   
";

            query = DbAgentHelper.GetQueryStringReplace(query);

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = emp_ref_id;
            paramArray[2]               = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[2].Value         = use_yn;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_ALL"), "BSC_KPI_TARGET", null, paramArray, CommandType.StoredProcedure);
            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        

        #endregion

    }
}
