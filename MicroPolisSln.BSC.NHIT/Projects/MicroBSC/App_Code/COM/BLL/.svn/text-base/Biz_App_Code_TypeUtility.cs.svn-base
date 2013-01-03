using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Biz.Common.Dac;

namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_App_Code_TypeUtility에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_App_Code_TypeUtility Biz 클래스
    /// Class 내용		: TypeUtility Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.20
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_App_Code_TypeUtility
    {
        /// <summary>
        /// GetDocNo
        ///     : 문서번호 리턴
        /// </summary>
        /// <param name="asPrefix"></param>
        /// <returns></returns>
        public string GetDocNo(string asPrefix)
        {
            string sRet = "";

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_App_Code_TypeUtility dac = new Dac_App_Code_TypeUtility();

                sRet = dac.GetDocNo(asPrefix);

                scope.Complete();
            }

            return sRet;
        }
    }
}
