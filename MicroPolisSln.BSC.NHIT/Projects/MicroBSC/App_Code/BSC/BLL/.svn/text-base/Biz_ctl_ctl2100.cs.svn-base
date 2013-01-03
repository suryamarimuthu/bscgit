using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Biz.BSC.Dac;

namespace MicroBSC.Biz.BSC.Biz
{
    /// <summary>
    /// Biz_ctl_ctl2100에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_ctl_ctl2100 Biz 클래스
    /// Class 내용		: ctl2100_Role Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.05
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_ctl_ctl2100
    {
        /// <summary>
        /// ChgFlagRelDeptInfo
        ///     : 사용자 삭제처리 (플래그변경으로 대체)
        /// </summary>
        /// <param name="asEmpRefID"></param>
        /// <param name="asDeptRefID"></param>
        /// <returns></returns>
        public int ChgFlagRelDeptInfo(string asEmpRefID, string asDeptRefID)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2100 dac = new Dac_ctl_ctl2100();

            iRet = dac.ChgFlagRelDeptInfo(asEmpRefID, asDeptRefID);

            //    scope.Complete();
            //}

            return iRet;
        }

        public int ChgFlagRelBackDeptInfo(string asEmpRefID, string asDeptRefID)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2100 dac = new Dac_ctl_ctl2100();

            iRet = dac.ChgFlagRelBackDeptInfo(asEmpRefID, asDeptRefID);

            //    scope.Complete();
            //}

            return iRet;
        }

        public int ChgFlagRelDeptInfo(string[,] saPKs)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            
            for (int i = 0; i <= saPKs.GetUpperBound(0); i++)
            {
                iRet += ChgFlagRelDeptInfo(saPKs[i, 0], saPKs[i, 1]);
            }

            //    scope.Complete();
            //}

            return iRet;
        }

        public int ChgFlagRelBackDeptInfo(string[,] saPKs)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{

            for (int i = 0; i <= saPKs.GetUpperBound(0); i++)
            {
                iRet += ChgFlagRelBackDeptInfo(saPKs[i, 0], saPKs[i, 1]);
            }

            //    scope.Complete();
            //}

            return iRet;
        }
    }
}
