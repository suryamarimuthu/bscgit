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
    /// Biz_ctl_ctlPassExcel_Upload에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_ctl_ctlPassExcel_Upload Biz 클래스
    /// Class 내용		: ctlPassExcel_Upload Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.07.05
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_ctl_ctlPassExcel_Upload
    {
        /// <summary>
        /// GetExcelData
        ///     : Upload할 엑셀파일을 DataSet으로 리턴
        /// </summary>
        /// <param name="asFilePath"></param>
        /// <returns></returns>
        public DataSet GetExcelData(string asFilePath)
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctlPassExcel_Upload dac = new Dac_ctl_ctlPassExcel_Upload();

                lDS = dac.GetExcelData(asFilePath);

                scope.Complete();
            }

            return lDS;
        }

        /// <summary>
        /// UpdateEmpPass
        ///     : 사용자 비밀번호 일괄 업데이트
        /// </summary>
        /// <param name="asFilePath"></param>
        /// <returns></returns>
        public int UpdateEmpPass(string asFilePath)
        {
            int iRet = 0;
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_ctl_ctlPassExcel_Upload dac = new Dac_ctl_ctlPassExcel_Upload();
                lDS = GetExcelData(asFilePath);

                foreach(DataRow dr in lDS.Tables[0].Rows)
                {
                    iRet += dac.SetExcelUpdate(dr[0].ToString(), dr[2].ToString());
                }

                scope.Complete();
            }

            return iRet;
        }
    }
}
