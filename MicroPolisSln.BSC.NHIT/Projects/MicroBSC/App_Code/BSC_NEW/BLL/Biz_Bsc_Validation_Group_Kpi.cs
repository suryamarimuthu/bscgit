using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_mgr_svr3203�� ���� ��� �����Դϴ�.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class ��		: Biz_Kpi_Pool Biz Ŭ����
    /// Class ����		: Kpi_Pool Biz Logic ó�� 
    ///                 : ���ܿ��� ���Ͽ� ó���ϴ� �κ��� �� �������� �Լ��� ȣ���Ѵ�.
    ///                 : ���������� �Լ��� Dac���� �Լ��� ���Ͽ� ���µ� Ʈ����� ó���� �����ϵ��� �����Ѵ�.
    /// �ۼ���			: �溴��
    /// �����ۼ���		: 2006.11.01
    /// ����������		:
    /// ����������		:
    /// Services		:
    /// �ֿ亯��α�	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Validation_Group_Kpi : Dac_Bsc_Validation_Group_Kpi
    {
        public Biz_Bsc_Validation_Group_Kpi() { }
        public Biz_Bsc_Validation_Group_Kpi(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id) 
             : base(iestterm_ref_id, igroup_ref_id, iest_level, iemp_ref_id, ikpi_ref_id) { }

        public int InsertData(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user) 
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , iest_level
                                     , iemp_ref_id
                                     , ikpi_ref_id
                                     , iopinion
                                     , itxr_user);
        }
        public int UpdateData(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user) 
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , iest_level
                                     , iemp_ref_id
                                     , ikpi_ref_id
                                     , iopinion
                                     , itxr_user);
        }
        public int DeleteData(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , iest_level
                                     , iemp_ref_id
                                     , ikpi_ref_id
                                     , itxr_user);
        }

        public int ConfirmOpnion(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user) 
        {
            return base.ConfirmOpnion_Dac(iestterm_ref_id
                                        , igroup_ref_id
                                        , iest_level
                                        , iemp_ref_id
                                        , ikpi_ref_id
                                        , iopinion
                                        , itxr_user);
        }

        public int CopyValuationKpiList(int iestterm_ref_id, int igroup_ref_id, int iest_level, int ifrom_emp_ref_id, int itxr_user)
        { 
            return base.CopyValuationKpiList_Dac(iestterm_ref_id, igroup_ref_id, iest_level, ifrom_emp_ref_id, itxr_user);
        }
    }
}