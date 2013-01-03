using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Qlt_Score_Had�� ���� ��� �����Դϴ�.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class ��		: Biz_Bsc_Kpi_Qlt_Score_Had Biz Ŭ����
    /// Class ����		: Biz_Bsc_Kpi_Qlt_Score_Had Biz Logic ó�� 
    ///                 : ���ܿ��� ���Ͽ� ó���ϴ� �κ��� �� �������� �Լ��� ȣ���Ѵ�.
    ///                 : ���������� �Լ��� Dac���� �Լ��� ���Ͽ� ���µ� Ʈ����� ó���� �����ϵ��� �����Ѵ�.
    /// �ۼ���			: �溴��
    /// �����ۼ���		: 2006.11.01
    /// ����������		:
    /// ����������		:
    /// Services		:
    /// �ֿ亯��α�	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Kpi_Qlt_Score_Had : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Qlt_Score_Had
    {
        public Biz_Bsc_Kpi_Qlt_Score_Had() { }
        public Biz_Bsc_Kpi_Qlt_Score_Had(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id) : base(iestterm_ref_id, iymd, igroup_ref_id, ikpi_ref_id, iest_level, iest_emp_id) { }

        public int InsertData(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, double iscore,
                              string istatus,  string iopinion, string ireview_file_id, int itxr_user) 
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , iymd
                                     , igroup_ref_id
                                     , ikpi_ref_id
                                     , iest_level
                                     , iest_emp_id
                                     , iscore
                                     , istatus
                                     , iopinion
                                     , ireview_file_id
                                     , itxr_user);
        }
        public int UpdateData(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, double iscore,
                              string istatus,  string iopinion, string ireview_file_id, int itxr_user) 
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , iymd
                                     , igroup_ref_id
                                     , ikpi_ref_id
                                     , iest_level
                                     , iest_emp_id
                                     , iscore
                                     , istatus
                                     , iopinion
                                     , ireview_file_id
                                     , itxr_user);
        }
        public int DeleteData(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int itxr_user) 
        {
            return base.DeleteData_Dac(iestterm_ref_id, iymd, igroup_ref_id, ikpi_ref_id, iest_level, itxr_user);
        }

        public int ConfirmOpinion(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, int itxr_user)
        { 
            return base.ConfirmOpinion_Dac(iestterm_ref_id, iymd, igroup_ref_id, ikpi_ref_id, iest_level, iest_emp_id, itxr_user);
        }

        public int CancelOpinion(int iestterm_ref_id, string iymd, int igroup_ref_id, int ikpi_ref_id, int iest_level, int iest_emp_id, int itxr_user)
        { 
            return base.CancelOpinion_Dac(iestterm_ref_id, iymd, igroup_ref_id, ikpi_ref_id, iest_level, iest_emp_id, itxr_user);
        }
    }
}