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
    /// Biz_ICM_ICM112에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_ctl_ctl2100_Role Biz 클래스
    /// Class 내용		: ctl2100_Role Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.05.26
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_ctl_ctl2100_Role
    {
        /// <summary>
        /// GetSearchData
        ///     : 
        /// </summary>
        /// <returns></returns>
        public DataSet GetSearchData(int aiEmpRefID)
        {
            DataSet lDS = new DataSet();

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
                Dac_ctl_ctl2100_Role dac = new Dac_ctl_ctl2100_Role();

                lDS = dac.GetSearchData(aiEmpRefID);

            //    scope.Complete();
            //}

            return lDS;
        }

        public DataSet GetRoleInfo(int aiEmpRefID)
        {
            DataSet lDS = new DataSet();

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
                Dac_ctl_ctl2100_Role dac = new Dac_ctl_ctl2100_Role();

                lDS = dac.GetRoleInfo(aiEmpRefID);

            //    scope.Complete();
            //}

            return lDS;
        }

        public string GetEmpName(int aiEmpRefID)
        {
            string sEmpName = "";

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2100_Role dac = new Dac_ctl_ctl2100_Role();

                sEmpName = dac.GetEmpName(aiEmpRefID);

            //    scope.Complete();
            //}

            return sEmpName;
        }

        public int AddRoleInfo(int aiEmpRefID, int aiRoleRefID)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2100_Role dac = new Dac_ctl_ctl2100_Role();

            iRet = dac.AddRoleInfo(aiEmpRefID, aiRoleRefID);

            //    scope.Complete();
            //}

            return iRet;
        }

        public int DelRoleInfo(string[,] saPKs)
        {
            int iRet = 0;
            
            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2100_Role dac = new Dac_ctl_ctl2100_Role();

            for (int i = 0; i <= saPKs.GetUpperBound(0) ; i++)
            {
                iRet += DelRoleInfo(Convert.ToInt32(saPKs[i, 0]), Convert.ToInt32(saPKs[i, 1]));
            }

            //    scope.Complete();
            //}

            return iRet;
        }

        public int DelRoleInfo(int aiEmpRefID, int aiRoleRefID)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2100_Role dac = new Dac_ctl_ctl2100_Role();

            iRet = dac.DelRoleInfo(aiEmpRefID, aiRoleRefID);

            //    scope.Complete();
            //}

            return iRet;
        }
    }
}
