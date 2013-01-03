using System;
using System.Data;
using System.Configuration;


/// <summary>
/// Biz_Bsc_Monthly_Report�� ��� �����Դϴ�.
/// </summary>

/// -------------------------------------------------------------
/// Class ��		@ Biz_Bsc_Monthly_Report Biz Ŭ����
/// Class ����		@ Bsc_Monthly_Report Biz ó�� 
///                 @ ������ ���������� �Լ��� ���� ������ �ʵ��� �Ѵ�.(Biz���� ���� ���ϵ���...)
/// �ۼ���			@ �溴��
/// �����ۼ���		@ 2007.12.12
/// ����������		@
/// ����������		@
/// Services		@
/// �ֿ亯��α�	@
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
