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
    /// Biz_ctl_ctl4100에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_ctl_ctl4100 Biz 클래스
    /// Class 내용		: ctl2101 Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.05.24
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_ctl_ctl4100
    {
        /// <summary>
        /// GetSearchData
        ///     : 평가등급 관리 검색
        /// </summary>
        /// <param name="asType"></param>
        /// <returns></returns>
        public DataSet GetSearchData(string asType)
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

                lDS = dac.GetSearchData(asType);

                scope.Complete();
            }

            return lDS;
        }

        /// <summary>
        /// GetSearchCode
        ///     : 평가등급 수정시 검색
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public DataSet GetSearchCode(string asCodeID)
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

                lDS = dac.GetSearchCode(asCodeID);

                scope.Complete();
            }

            return lDS;
        }

        /// <summary>
        /// GetAllType
        ///     : 측정단계 드롭다운리스트 추출
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllType()
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

                lDS = dac.GetAllType();

                scope.Complete();
            }

            return lDS;
        }

        /// <summary>
        /// UpdateThresholdSeq
        ///     : 평가등급 삭제 이전에 시퀀스 조정
        ///     : 항상 정해진 순서로 들어가야 하므로 현재처럼 조정한후 삭제하도록 한다.
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public int UpdateThresholdSeq(string asCodeID)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

            iRet = dac.UpdateThresholdSeq(asCodeID);

            //    scope.Complete();
            //}

            return iRet;
        }

        /// <summary>
        /// DelThreshold
        ///     : 평가등급 관리 삭제
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public int DelThreshold(string asCodeID)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

            //iRet += dac.UpdateThresholdSeq(asCodeID);
            dac.DelThresholdInfo(asCodeID);
            dac.UpdateThresholdSeq(asCodeID);
            iRet += dac.DelThreshold(asCodeID);

            //    scope.Complete();
            //}

            return iRet;
        }

        /// <summary>
        /// DelThresholdInfo
        ///     : 기 설정된 THRESHOLD정보 삭제
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public int DelThresholdInfo(string asCodeID)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

            //iRet += dac.UpdateThresholdSeq(asCodeID);
            dac.DelThresholdInfo(asCodeID);

            //    scope.Complete();
            //}

            return iRet;
        }

        /// <summary>
        /// DelThreshold
        ///     : 일괄삭제를 위한 Biz로직
        /// </summary>
        /// <param name="asaCode"></param>
        /// <returns></returns>
        public int DelThreshold(string[,] asaCode)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{

            for (int i = 0; i <= asaCode.GetUpperBound(0); i++)
            {
                iRet += DelThreshold(asaCode[i, 0]);
            }

            //    scope.Complete();
            //}

            return iRet;
        }

        /// <summary>
        /// AddThreshold
        ///     : 평가등급관리 등록
        /// </summary>
        /// <param name="asThresholdType"></param>
        /// <param name="asThresholdName"></param>
        /// <param name="asMinValue"></param>
        /// <param name="asColor"></param>
        /// <param name="asImagePath"></param>
        /// <returns></returns>
        public int AddThreshold(string asThresholdType, string asThresholdName, string asMinValue, string asColor, string asImagePath, string asPoint)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{

            Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

            iRet += dac.AddThreshold(asThresholdType, asThresholdName, asMinValue, asColor, asImagePath, asPoint);

            //    scope.Complete();
            //}

            return iRet;
        }

        /// <summary>
        /// UpdateThreshold
        ///     : 평가등급관리 수정
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <param name="asThresholdName"></param>
        /// <param name="asMinValue"></param>
        /// <param name="asColor"></param>
        /// <param name="asImagePath"></param>
        /// <returns></returns>
        public int UpdateThreshold(string asCodeID, string asThresholdName, string asMinValue, string asColor, string asImagePath,string asPoint)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{

            Dac_ctl_ctl4100 dac = new Dac_ctl_ctl4100();

            iRet += dac.UpdateThreshold(asCodeID, asThresholdName, asMinValue, asColor, asImagePath, asPoint);

            //    scope.Complete();
            //}

            return iRet;
        }
    }
}
