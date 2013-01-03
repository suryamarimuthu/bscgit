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
    public class Biz_Bsc_Kpi_Qlt_Score_Det : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Qlt_Score_Det
    {
        public Biz_Bsc_Kpi_Qlt_Score_Det() { }
        public Biz_Bsc_Kpi_Qlt_Score_Det(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id) 
             : base(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, iquestion_ref_id) { }

        public int InsertData(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                              double iscore, int itxr_user) 
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , ikpi_ref_id
                                     , iest_emp_id
                                     , iymd
                                     , iest_level
                                     , iquestion_ref_id
                                     , iscore
                                     , itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                              double iscore, int itxr_user) 
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , ikpi_ref_id
                                     , iest_emp_id
                                     , iymd
                                     , iest_level
                                     , iquestion_ref_id
                                     , iscore
                                     , itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, iquestion_ref_id, itxr_user);
        }

        /// <summary>
        /// ���׸� ������
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="iquestion_ref_id"></param>
        /// <param name="iscore"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstQuestionItem(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd
                                 , int iest_level, int iquestion_ref_id, double iscore, int itxr_user)
        { 
            return base.EstQuestionItem_Dac(iestterm_ref_id
                                          , igroup_ref_id
                                          , ikpi_ref_id
                                          , iest_emp_id
                                          , iymd
                                          , iest_level
                                          , iquestion_ref_id
                                          , iscore
                                          , itxr_user);
        }

        /// <summary>
        /// ���׸� �����
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="iquestion_ref_id"></param>
        /// <param name="iscore_grade"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstQuestionItemGrade(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id,
                                            string iscore_grade, int itxr_user)
        { 
            return base.EstQuestionItemGrade_Dac(
                          iestterm_ref_id
                        , igroup_ref_id
                        , ikpi_ref_id
                        , iest_emp_id
                        , iymd
                        , iest_level
                        , iquestion_ref_id  
                        , iscore_grade
                        , itxr_user);
        }

        /// <summary>
        /// ������ Ȯ��
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstConfirm(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int itxr_user)
        { 
            return base.EstConfirm_Dac(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, itxr_user);
        }

        /// <summary>
        /// ������ Ȯ�� ���
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstCancel(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int itxr_user)
        { 
            return base.EstCancel_Dac(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, itxr_user);
        }
    }
}
