using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Qlt_Score_Had에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Bsc_Kpi_Qlt_Score_Det Biz 클래스
    /// Class 내용		: Biz_Bsc_Kpi_Qlt_Score_Det Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2006.11.01
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Kpi_Qlt_Term_Weight : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Qlt_Term_Weight
    {
        public Biz_Bsc_Kpi_Qlt_Term_Weight() { }
        public Biz_Bsc_Kpi_Qlt_Term_Weight(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level) 
             : base(iestterm_ref_id, ikpi_ref_id, iymd, iest_level) { }

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level, 
                              double iweight, int itxr_user) 
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , ikpi_ref_id
                                     , iymd
                                     , iest_level
                                     , iweight
                                     , itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level, 
                              double iweight, int itxr_user) 
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , ikpi_ref_id
                                     , iymd
                                     , iest_level
                                     , iweight
                                     , itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int iest_level, int itxr_user) 
        {
            return base.DeleteData_Dac(iestterm_ref_id
                                     , ikpi_ref_id
                                     , iymd
                                     , iest_level
                                     , itxr_user);
        }
    }
}