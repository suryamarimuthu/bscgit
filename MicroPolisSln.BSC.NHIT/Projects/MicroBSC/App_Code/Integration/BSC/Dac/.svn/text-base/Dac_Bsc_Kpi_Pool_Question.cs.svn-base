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
/// Dac_Bsc_Kpi_Pool_Question의 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Pool_Question Dac 클래스
/// Class 내용		@ Bsc_Kpi_Result Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Pool_Question : DbAgentBase
    {
    
        #region ========================== 멀티 DB 작업 ============================


        public DataSet Select_DB(object kpi_ref_id
                                        , object use_yn)
        {
            string strQuery = @"
SELECT KPI_POOL_REF_ID
      ,QUESTION_REF_ID
      ,ITEM_NAME
      ,WEIGHT
      ,QUESTION_ORDER
      ,USE_YN
 FROM BSC_KPI_POOL_QUESTION 
WHERE USE_YN = @USE_YN 
  AND KPI_POOL_REF_ID IN ( SELECT KPI_POOL_REF_ID FROM BSC_KPI_INFO 
                                                 WHERE KPI_REF_ID   = @KPI_REF_ID )
ORDER BY QUESTION_ORDER 
";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = kpi_ref_id;
            paramArray[1] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[1].Value = use_yn;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_POOL_QUESTION", null, paramArray, CommandType.Text);
            return ds;
        }


        #endregion
    }
}
