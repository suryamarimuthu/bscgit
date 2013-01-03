using System;
using System.Data;
using System.Configuration;


/// <summary>
/// Biz_Bsc_Monthly_Report의 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Biz_Bsc_Monthly_Report Biz 클래스
/// Class 내용		@ Bsc_Monthly_Report Biz 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.12.12
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------

namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Monthly_Report : MicroBSC.BSC.Dac.Dac_Bsc_Monthly_Report
    {
        public Biz_Bsc_Monthly_Report() { }
        public Biz_Bsc_Monthly_Report(int iestterm_ref_id, string iymd)
            : base(iestterm_ref_id, iymd) { }

        public int InsertData(int iestterm_ref_id, string iymd, string ireport_detail, string ireport_file_id, int itxr_user)
        {
            return InsertData_Dac(iestterm_ref_id, iymd, ireport_detail, ireport_file_id, itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, string iymd, string ireport_detail, string ireport_file_id, int itxr_user)
        { 
            return UpdateData_Dac(iestterm_ref_id, iymd, ireport_detail, ireport_file_id, itxr_user);
        }
    }
}
