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
    /// Biz_ctl_ctl3100에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_ctl_ctl3100 Biz 클래스
    /// Class 내용		: PositionGrp Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.02
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_ctl_ctl3100
    {
        public DataSet GetMenuInfo(int aiUpRefID)
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctl3100 dac = new Dac_ctl_ctl3100();

                lDS = dac.GetMenuInfo(aiUpRefID);

                scope.Complete();
            }

            return lDS;
        }

        public DataSet GetMenuInfo(string asUpRefID)
        {
            return GetMenuInfo(Convert.ToInt32(asUpRefID));
        }

        public DataSet GetMenuInfo()
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctl3100 dac = new Dac_ctl_ctl3100();

                lDS = dac.GetMenuInfo();

                scope.Complete();
            }

            return lDS;
        }

        public DataSet GetTopMenuInfo()
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctl3100 dac = new Dac_ctl_ctl3100();

                lDS = dac.GetTopMenuInfo();

                scope.Complete();
            }

            return lDS;
        }
    }
}
