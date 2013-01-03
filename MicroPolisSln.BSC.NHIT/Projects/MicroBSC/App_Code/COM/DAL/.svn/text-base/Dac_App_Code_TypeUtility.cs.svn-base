using System;
using System.Web;
using System.Data;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_App_Code_TypeUtility에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_App_Code_TypeUtility Dac 클래스
    /// Class 내용		: TypeUtility 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.20
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_App_Code_TypeUtility : DbAgentBase
    {
        /// <summary>
        /// GetDocNo
        ///     : 문서번호 리턴
        /// </summary>
        /// <param name="asPrefix"></param>
        /// <returns></returns>
        public string GetDocNo(string asPrefix)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT DBO.FN_GETDOCNO(@PREFIX) \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@PREFIX", SqlDbType.VarChar);
            
            paramArray[0].Value = asPrefix;

            return Convert.ToString(DbAgentObj.ExecuteScalar(sbQuery.ToString(), paramArray));
        }
    }
}
