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
    /// Class ��		: Biz_Bsc_Validation_Group Biz Ŭ����
    /// Class ����		: Bsc_Validation_Group Biz Logic ó�� 
    ///                 : ���ܿ��� ���Ͽ� ó���ϴ� �κ��� �� �������� �Լ��� ȣ���Ѵ�.
    ///                 : ���������� �Լ��� Dac���� �Լ��� ���Ͽ� ���µ� Ʈ����� ó���� �����ϵ��� �����Ѵ�.
    /// �ۼ���			: �溴��
    /// �����ۼ���		: 2006.11.01
    /// ����������		:
    /// ����������		:
    /// Services		:
    /// �ֿ亯��α�	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Validation_Group : Dac_Bsc_Validation_Group
    {
        public Biz_Bsc_Validation_Group() { }
        public Biz_Bsc_Validation_Group(int igroup_ref_id) 
             : base(igroup_ref_id) { }

        public int InsertData(string igroup_name, string idescriptions, string iuse_yn, int itxr_user) 
        {
            return base.InsertData_Dac(igroup_name
                                     , idescriptions
                                     , iuse_yn
                                     , itxr_user);
        }
        public int UpdateData(int igroup_ref_id, string igroup_name, string idescriptions, string iuse_yn, int itxr_user) 
        {
            return base.UpdateData_Dac(igroup_ref_id
                                     , igroup_name
                                     , idescriptions
                                     , iuse_yn
                                     , itxr_user);
        }
        public int DeleteData(int igroup_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(igroup_ref_id
                                     , itxr_user);
        }
    }
}