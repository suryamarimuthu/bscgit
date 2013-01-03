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
    public class Biz_Bsc_Communication_Notice : Dac_Bsc_Communication_Notice
    {
        public Biz_Bsc_Communication_Notice() { }
        public Biz_Bsc_Communication_Notice(int inotice_ref_id) : base(inotice_ref_id) { }

        public int InsertData(int iestterm_ref_id, string iymd
                            , string ititle, string idetails, int iread_count, string iattach_no
                            , DateTime inotice_from, DateTime inotice_to, string ishow_pop_up, int itxr_user)
        {
            return base.InsertData_Dac
                        (
                          iestterm_ref_id
                        , iymd
                        , ititle
                        , idetails
                        , iread_count
                        , iattach_no
                        , inotice_from
                        , inotice_to
                        , ishow_pop_up
                        , itxr_user);
        }

        public int UpdateData(int inotice_ref_id, int iestterm_ref_id, string iymd
                            , string ititle, string idetails, int iread_count, string iattach_no
                            , DateTime inotice_from, DateTime inotice_to, string ishow_pop_up, int itxr_user)
        {
            return base.UpdateData_Dac
                        (
                          inotice_ref_id
                        , iestterm_ref_id
                        , iymd
                        , ititle
                        , idetails
                        , iread_count
                        , iattach_no
                        , inotice_from
                        , inotice_to
                        , ishow_pop_up
                        , itxr_user);
        }

        public int DeleteData(int inotice_ref_id, int itxr_user)
        { 
            return base.DeleteData_Dac(inotice_ref_id, itxr_user);
        }

        public int AddClickCount(int inotice_ref_id, int itxr_user)
        { 
            return base.AddClickCount_Dac(inotice_ref_id, itxr_user);
        }


    }
}