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
    /// �����ۼ���		: 2007.12.16
    /// ����������		:
    /// ����������		:
    /// Services		:
    /// �ֿ亯��α�	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Communication_List : Dac_Bsc_Communication_List
    {
        public Biz_Bsc_Communication_List() { }
        public Biz_Bsc_Communication_List(int ilist_ref_id) : base(ilist_ref_id) { }

        public int InsertData(string icategory_code, int iparent_list_id, int iestterm_ref_id, string iymd
                             , int ikpi_ref_id, string ititle, string idetails, int iread_count, string iattach_no
                             , string iarr_receiver_id, string iis_send_mail, string iis_open_list, int itxr_user) 
        {
            return base.InsertData_Dac
                        ( icategory_code
                        , iparent_list_id
                        , iestterm_ref_id
                        , iymd
                        , ikpi_ref_id
                        , ititle
                        , idetails
                        , iread_count
                        , iattach_no
                        , iarr_receiver_id
                        , iis_send_mail
                        , iis_open_list
                        , itxr_user);
        }

        public int UpdateData(int ilist_ref_id, string icategory_code, int iparent_list_id, int iestterm_ref_id, string iymd
                             , int ikpi_ref_id, string ititle, string idetails, int iread_count, string iattach_no
                             , string iarr_receiver_id, string iis_send_mail, string iis_open_list, int itxr_user) 
        {
            return base.UpdateData_Dac
                        ( ilist_ref_id
                        , icategory_code
                        , iparent_list_id
                        , iestterm_ref_id
                        , iymd
                        , ikpi_ref_id
                        , ititle
                        , idetails
                        , iread_count
                        , iattach_no
                        , iarr_receiver_id
                        , iis_send_mail
                        , iis_open_list
                        , itxr_user);
        }

        public int DeleteData(int ilist_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(ilist_ref_id, itxr_user);
        }

        public int AddClickCount(int ilist_ref_id, int itxr_user)
        { 
            return base.AddClickCount_Dac(ilist_ref_id, itxr_user);
        }
    }
}