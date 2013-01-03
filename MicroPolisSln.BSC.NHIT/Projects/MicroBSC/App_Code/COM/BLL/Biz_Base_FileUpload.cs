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
    /// Biz_Base_FileUpload에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Base_FileUpload Biz 클래스
    /// Class 내용		: FileUpload Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.19
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Base_FileUpload
    {
        public int AddFileInfo(string[,] psaFileInfo)
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
                Dac_Base_FileUpload dac = new Dac_Base_FileUpload();

                iRet = dac.AddFileInfo(psaFileInfo);

                //scope.Complete();
            //}

            return iRet;
        }

        public int RemoveFileInfo(string psAttachNo, string psFullFileName)
        {
            int iRet = 0;
            int iSerNo = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
                Dac_Base_FileUpload dac = new Dac_Base_FileUpload();

                iSerNo = dac.GetDelFileInfo(psAttachNo, psFullFileName);

                iRet = dac.DelFileInfo(psAttachNo, iSerNo);
                dac.UpdateFileSerNo(psAttachNo, iSerNo);


            //    scope.Complete();
            //}

            return iRet;
        }

        /// <summary>
        /// 업로드된 정보 추출
        /// </summary>
        /// <param name="asAttachNo"></param>
        /// <returns></returns>
        public DataSet GetFileUploaded(string asAttachNo)
        {
            DataSet lDS = new DataSet();

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
                Dac_Base_FileUpload dac = new Dac_Base_FileUpload();
                lDS = dac.GetFileUploaded(asAttachNo);

            //    scope.Complete();
            //}

            return lDS;
        }

        /// <summary>
        /// 문서 및 각 테이블의 주요키 리턴
        /// </summary>
        /// <param name="psPre"></param>
        /// <returns></returns>
        public string GetAttachNo(string psPrefix)
        {
            string sRet = "";

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
                Dac_Base_FileUpload dac = new Dac_Base_FileUpload();
                sRet = dac.GetAttachNo(psPrefix);

            //    scope.Complete();
            //}

            return sRet;
        }

    }
}
