using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Biz_Bsc_Map_Term의 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Biz_Bsc_Map_Stg Biz 클래스
/// Class 내용		@ Bsc_Map_Stg Biz 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.06.19
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------

namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Map_Term : MicroBSC.BSC.Dac.Dac_Bsc_Map_Term
    {
        public Biz_Bsc_Map_Term() { }
        public Biz_Bsc_Map_Term(int iestterm_ref_id, int iest_dept_ref_id, string iymd)
            : base(iestterm_ref_id, iest_dept_ref_id, iymd) { }


        public int InsertData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        { 
            return base.InsertData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, iymd, itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, iymd, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, iymd, itxr_user);
        }

        public int DeleteAllData(int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int itxr_user)
        { 
            return base.DeleteAllData_Dac(iestterm_ref_id, iest_dept_ref_id, imap_version_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        { 
            return base.InsertData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, iymd, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, iymd, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, string iymd, int itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, iymd, itxr_user);
        }

        public int DeleteAllData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int imap_version_id, int itxr_user)
        {
            return base.DeleteAllData_Dac(conn, trx, iestterm_ref_id, iest_dept_ref_id, imap_version_id, itxr_user);
        }
    }
}
