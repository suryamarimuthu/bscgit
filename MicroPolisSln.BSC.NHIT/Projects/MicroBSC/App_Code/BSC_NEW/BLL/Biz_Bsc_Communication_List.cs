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
    /// Biz_Bsc_Commnunication_List에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Bsc_Commnunication_List Biz 클래스
    /// Class 내용		: Bsc_Commnunication_List Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2007.12.16
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
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