using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Biz.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Work_Pool에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Bsc_Work_Pool Biz 클래스
    /// Class 내용		: Work_Pool Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 서대원
    /// 최초작성일		: 2011.09.27
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Work_Pool : MicroBSC.BSC.Dac.Dac_Bsc_Work_Pool
    {
        public Biz_Bsc_Work_Pool() { }
        public Biz_Bsc_Work_Pool(int iwork_pool_ref_id) : base(iwork_pool_ref_id) { }

        public int InsertData(string iwork_name, string iwork_desc, string iwork_priority, string iwork_type, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac(iwork_name, 
                                       iwork_desc, 
                                       iwork_priority,
                                       iwork_type,
                                       iuse_yn, 
                                       itxr_user);
        }
        public int UpdateData(int iwork_pool_ref_id, string iwork_name, string iwork_desc, string iwork_priority, string iwork_type, string iuse_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(iwork_pool_ref_id,
                                       iwork_name, 
                                       iwork_desc, 
                                       iwork_priority,
                                       iwork_type,
                                       iuse_yn, 
                                       itxr_user);
        }
        public int DeleteData(int iwork_pool_ref_id, Int32 itxr_user) 
        {
            return base.DeleteData_Dac(iwork_pool_ref_id, itxr_user);
        }

        public int ReUsedData(int iwork_pool_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(iwork_pool_ref_id, itxr_user);
        }
    }
}