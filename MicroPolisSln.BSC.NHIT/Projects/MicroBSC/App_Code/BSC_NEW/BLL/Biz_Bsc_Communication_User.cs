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
    /// 최초작성일		: 2007.12.18
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
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
