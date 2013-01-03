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
    public class Biz_Bsc_Kpi_Initiative : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative
    {
        public Biz_Bsc_Kpi_Initiative() { }
        public Biz_Bsc_Kpi_Initiative(int iestterm_ref_id, int ikpi_ref_id, string iymd) :
               base(iestterm_ref_id, ikpi_ref_id, iymd) {}

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_plan, string iinitiative_do, string iinitiative_desc, int itxr_user)
        { 
            return base.InsertData_Dac( iestterm_ref_id
                                      , ikpi_ref_id
                                      , iymd
                                      , iinitiative_plan
                                      , iinitiative_do
                                      , iinitiative_desc
                                      , itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_plan, string iinitiative_do, string iinitiative_desc, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id
                                     , ikpi_ref_id
                                     , iymd
                                     , iinitiative_plan
                                     , iinitiative_do
                                     , iinitiative_desc
                                     , itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id
                                     , ikpi_ref_id
                                     , iymd
                                     , itxr_user);
        }

        /// <summary>
        /// �̴ϼ�Ƽ�� ���� �� ����÷��
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iinitiative_do"></param>
        /// <param name="ido_file"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int InsertInitiativeDo(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_do, string ido_file, int itxr_user)
        { 
            return base.InsertInitiativeDo_Dac(iestterm_ref_id
                                             , ikpi_ref_id
                                             , iymd
                                             , iinitiative_do
                                             , ido_file
                                             , itxr_user);
        }
    }
}