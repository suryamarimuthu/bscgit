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
/// Dac_Bsc_Term_Detail에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Term_Detail Dac 클래스
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
    public class Dac_Bsc_Term_Detail : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================
        
        
        public DataSet Select_DB(object estterm_ref_id
                               , object kpi_ref_id)
        {
            string query = @"
SELECT @ESTTERM_REF_ID                                as ESTTERM_REF_ID
       ,@KPI_REF_ID                                    as KPI_REF_ID
       ,1                                              as KPI_TARGET_VERSION_ID
       ,TA.YMD                                         as YMD
       ,(SUBSTR(TA.YMD,1,4) || '/' || SUBSTR(TA.YMD,5,2)) as YMD_DESC
       ,0                                              as MS_PLAN
       ,0                                              as TS_PLAN
       ,0                                              as MM_PLAN
       ,0                                              as TM_PLAN
       ,'당초계획'                                     as ORI_VERSION_NAME
       ,'수정계획(등록안됨)'                           as MOD_VERSION_NAME
       ,'Y'                                            as ORI_CHECK_YN
       ,'N'                                            as MOD_CHECK_YN
       ,CLOSE_YN                                       as MONTHLY_CLOSE_YN
  FROM BSC_TERM_DETAIL TA
 WHERE TA.ESTTERM_REF_ID = @ESTTERM_REF_ID
";

            query = DbAgentHelper.GetQueryStringReplace(query);

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_ALL"), "BSC_KPI_TARGET_GOAL", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(query, "BSC_KPI_TARGET_GOAL", null, paramArray, CommandType.Text);
            return ds;
        }

        #endregion

    }
}
