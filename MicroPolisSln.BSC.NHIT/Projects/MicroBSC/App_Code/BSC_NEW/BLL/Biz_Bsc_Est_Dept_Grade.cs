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
    /// Biz_Bsc_Commnunication_List�� ���� ��� �����Դϴ�.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class ��		: Biz_Bsc_Est_Dept_Grade Biz Ŭ����
    /// Class ����		: Bsc_Est_Dept_Grade Biz Logic ó�� 
    ///                 : ���ܿ��� ���Ͽ� ó���ϴ� �κ��� �� �������� �Լ��� ȣ���Ѵ�.
    ///                 : ���������� �Լ��� Dac���� �Լ��� ���Ͽ� ���µ� Ʈ����� ó���� �����ϵ��� �����Ѵ�.
    /// �ۼ���			: �溴��
    /// �����ۼ���		: 2007.12.30
    /// ����������		:
    /// ����������		:
    /// Services		:
    /// �ֿ亯��α�	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Est_Dept_Grade : Dac_Bsc_Est_Dept_Grade
    {
        public Biz_Bsc_Est_Dept_Grade() { }
        public Biz_Bsc_Est_Dept_Grade(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id) : base(iestterm_ref_id, iest_dept_type, igrade_ref_id) { }

        public int InsertData(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id, string igrade_name
                            , double imin_value, double imax_value, string imid_grade_yn, int isort_order, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac
                        ( iestterm_ref_id
                        , iest_dept_type
                        , igrade_ref_id
                        , igrade_name
                        , imin_value
                        , imax_value
                        , imid_grade_yn
                        , isort_order
                        , iuse_yn
                        , itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id, string igrade_name
                            , double imin_value, double imax_value, string imid_grade_yn, int isort_order, string iuse_yn, int itxr_user)
        { 
            return base.UpdateData_Dac
                        ( iestterm_ref_id
                        , iest_dept_type
                        , igrade_ref_id
                        , igrade_name
                        , imin_value
                        , imax_value
                        , imid_grade_yn
                        , isort_order
                        , iuse_yn
                        , itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int iest_dept_type, int igrade_ref_id, int itxr_user)
        {
            return base.DeleteData_Dac(iestterm_ref_id, iest_dept_type, igrade_ref_id, itxr_user);
        }
    }
}