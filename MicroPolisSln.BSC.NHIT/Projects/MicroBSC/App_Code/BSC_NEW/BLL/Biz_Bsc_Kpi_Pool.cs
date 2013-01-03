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
    /// Biz_mgr_svr3203에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Kpi_Pool Biz 클래스
    /// Class 내용		: Kpi_Pool Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2006.11.01
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Kpi_Pool : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Pool
    {
        public Biz_Bsc_Kpi_Pool() { }
        public Biz_Bsc_Kpi_Pool(int ikpi_pool_ref_id) : base(ikpi_pool_ref_id) { }

        public int InsertData(string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis, int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac(ikpi_name, 
                                       ikpi_desc, 
                                       ikpi_type, 
                                       ikpi_external_type,
                                       ibasis_use_yn,
                                       ivaluation_basis,
                                       icategory_top_ref_id, 
                                       icategory_mid_ref_id, 
                                       icategory_low_ref_id,
                                       iuse_yn, 
                                       itxr_user);
        }
        public int InsertData(string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis, int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user, int stg_ref_id)
        {
            return base.InsertData_Dac(ikpi_name,
                                       ikpi_desc,
                                       ikpi_type,
                                       ikpi_external_type,
                                       ibasis_use_yn,
                                       ivaluation_basis,
                                       icategory_top_ref_id,
                                       icategory_mid_ref_id,
                                       icategory_low_ref_id,
                                       iuse_yn,
                                       itxr_user,
                                       stg_ref_id);
        }
        public int UpdateData(int ikpi_pool_ref_id, string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis, int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(ikpi_pool_ref_id,
                                       ikpi_name,
                                       ikpi_desc,
                                       ikpi_type,
                                       ikpi_external_type,
                                       ibasis_use_yn,
                                       ivaluation_basis,
                                       icategory_top_ref_id,
                                       icategory_mid_ref_id,
                                       icategory_low_ref_id,
                                       iuse_yn,
                                       itxr_user);

        }

        public int UpdateData(int ikpi_pool_ref_id, string ikpi_name, string ikpi_desc, string ikpi_type, string ikpi_external_type, string ibasis_use_yn, string ivaluation_basis, int icategory_top_ref_id, int icategory_mid_ref_id, int icategory_low_ref_id, string iuse_yn, int itxr_user, int stg_ref_id)
        {
            return base.UpdateData_Dac(ikpi_pool_ref_id,
                                       ikpi_name,
                                       ikpi_desc,
                                       ikpi_type,
                                       ikpi_external_type,
                                       ibasis_use_yn,
                                       ivaluation_basis,
                                       icategory_top_ref_id,
                                       icategory_mid_ref_id,
                                       icategory_low_ref_id,
                                       iuse_yn,
                                       itxr_user
                                       , stg_ref_id);

        }
        public int DeleteData(int ikpi_pool_ref_id, Int32 itxr_user) 
        {
            return base.DeleteData_Dac(ikpi_pool_ref_id, itxr_user);
        }

        public int ReUsedData(int ikpi_pool_ref_id, Int32 itxr_user)
        {
            return base.ReUsedData_Dac(ikpi_pool_ref_id, itxr_user);
        }
    }
}
