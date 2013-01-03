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
    /// Biz_Bsc_Kpi_Category_Mid 에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Bsc_Kpi_Category_Mid Biz 클래스
    /// Class 내용		: Bsc_Kpi_Category_Mid Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2006.11.01
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Kpi_Category_Mid : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Category_Mid
    {
        public Biz_Bsc_Kpi_Category_Mid() { }
        public Biz_Bsc_Kpi_Category_Mid(int icategory_top_ref_id, int icategory_mid_ref_id) : base(icategory_top_ref_id, icategory_mid_ref_id) { }

        public int InsertData(int icategory_top_ref_id, string icategory_name, string icategory_desc , string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac(icategory_top_ref_id
                                     , icategory_name
                                     , icategory_desc
                                     , iuse_yn
                                     , itxr_user);
        }
        public int UpdateData(int icategory_top_ref_id, int icategory_mid_ref_id, string icategory_name, string icategory_desc , string iuse_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(icategory_top_ref_id
                                     , icategory_mid_ref_id
                                     , icategory_name
                                     , icategory_desc
                                     , iuse_yn
                                     , itxr_user);
        }
        public int DeleteData(int icategory_top_ref_id, int icategory_mid_ref_id, Int32 itxr_user) 
        {
            return base.DeleteData_Dac(icategory_top_ref_id, icategory_mid_ref_id, itxr_user);
        }
    }
}
