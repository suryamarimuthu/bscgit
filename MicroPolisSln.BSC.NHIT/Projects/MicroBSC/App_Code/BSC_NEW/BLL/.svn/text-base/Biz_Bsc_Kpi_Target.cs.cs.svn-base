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

using MicroBSC.Data;

/// <summary>
/// Biz_Bsc_Kpi_Term의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Kpi_Info Biz 클래스
/// Class 내용		: Bsc_Kpi_Info Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 방병현
/// 최초작성일		: 2007.04.26
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
/// 
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Kpi_Target : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Target
    {
        public Biz_Bsc_Kpi_Target() { }

        public Biz_Bsc_Kpi_Target(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd) : 
               base(iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, iymd) {}

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd,
                              double itarget_ms, double itarget_ts, int itxr_user)
        { 
            return base.InsertData_Dac( iestterm_ref_id,  ikpi_ref_id,  ikpi_target_version_id,  iymd,
                                        itarget_ms,       itarget_ts,  itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd,
                                              double itarget_ms, double itarget_ts, int itxr_user)
        {
            return base.UpdateData_Dac(iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, iymd,
                                       itarget_ms,      itarget_ts,  itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, iymd, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd,
                              double itarget_ms, double itarget_ts, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, iymd,
                                        itarget_ms,       itarget_ts,  itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd,
                              double itarget_ms, double itarget_ts, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, iymd,
                                       itarget_ms,      itarget_ts,  itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id, iymd, itxr_user);
        }
    }
}
