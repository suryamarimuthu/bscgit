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
    /// Class ��		: Biz_Bsc_Commnunication_List Biz Ŭ����
    /// Class ����		: Bsc_Commnunication_List Biz Logic ó�� 
    ///                 : ���ܿ��� ���Ͽ� ó���ϴ� �κ��� �� �������� �Լ��� ȣ���Ѵ�.
    ///                 : ���������� �Լ��� Dac���� �Լ��� ���Ͽ� ���µ� Ʈ����� ó���� �����ϵ��� �����Ѵ�.
    /// �ۼ���			: �溴��
    /// �����ۼ���		: 2007.12.18
    /// ����������		:
    /// ����������		:
    /// Services		:
    /// �ֿ亯��α�	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Communication_User : Dac_Bsc_Communication_User
    {
        public Biz_Bsc_Communication_User() { }
        public Biz_Bsc_Communication_User(int ilist_ref_id, int ito_emp_id) : base(ilist_ref_id, ito_emp_id) { }

        public int InsertData(int ilist_ref_id, int ito_emp_id, int itxr_user)
        { 
            return base.InsertData_Dac(ilist_ref_id, ito_emp_id, itxr_user);
        }

        public int UpdateData(int ilist_ref_id, int ito_emp_id, string iread_yn, int itxr_user)
        { 
            return base.UpdateData_Dac(ilist_ref_id, ito_emp_id, iread_yn, itxr_user);
        }

        public int DeleteData(int ilist_ref_id, int ito_emp_id, int itxr_user)
        { 
            return base.DeleteData_Dac(ilist_ref_id, ito_emp_id, itxr_user);
        }

        public int DeleteDataAll(int ilist_ref_id, int itxr_user)
        {
            return base.DeleteDataAll_Dac(ilist_ref_id, itxr_user);
        }

        public int InsertCommunicationAll(int ilist_ref_id, int itxr_user, DataTable dtUser)
        {
            int intRtn = 0;
            intRtn = base.DeleteDataAll_Dac(ilist_ref_id, itxr_user);

            int intRow = dtUser.Rows.Count;
            for (int i = 0; i < intRow; i++)
            { 
               intRtn +=  base.InsertData_Dac
                               ( 
                                  ilist_ref_id
                                , Convert.ToInt32(dtUser.Rows[i]["TO_EMP_ID"].ToString())
                                , itxr_user
                               );
            }

            return intRtn;
        }
    }
}
