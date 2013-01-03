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
/// Biz_Bsc_Kpi_Datasource에 대한 요약 설명입니다.
/// </summary>

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
namespace MicroBSC.BSC.Biz
{
    public class Biz_Bsc_Kpi_Datasource : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Datasource
    {
        public Biz_Bsc_Kpi_Datasource() { }
        public Biz_Bsc_Kpi_Datasource(int iestterm_ref_id, int ikpi_ref_id, int idatasource_id) 
               : base(iestterm_ref_id, ikpi_ref_id, idatasource_id) { }

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, string ilevel1, string ilevel2, 
                              string ilevel3, string iresult_source, string itarget_source, string iresult_create_time, 
                              int iunit_type_ref_id, int itxr_user)
        {
            return base.InsertData_Dac(iestterm_ref_id,  ikpi_ref_id,    ilevel1,        ilevel2, 
                                       ilevel3,          iresult_source, itarget_source, iresult_create_time, 
                                       iunit_type_ref_id,itxr_user);
        }

        public int UpdateData (int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, string ilevel1, string ilevel2,
                               string ilevel3, string iresult_source, string itarget_source, string iresult_create_time,
                               int iunit_type_ref_id, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id, ikpi_ref_id,    idatasource_id, ilevel1, ilevel2,
                                       ilevel3,         iresult_source, itarget_source, iresult_create_time,
                                       iunit_type_ref_id, itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, idatasource_id, itxr_user);
        }

        public int InsertData(IDbConnection conn, IDbTransaction trx,
                              int iestterm_ref_id, int ikpi_ref_id, string ilevel1, string ilevel2,
                              string ilevel3, string iresult_source, string itarget_source, string iresult_create_time,
                              int iunit_type_ref_id, int itxr_user)
        {
            return base.InsertData_Dac(conn, trx,
                                       iestterm_ref_id, ikpi_ref_id, ilevel1, ilevel2,
                                       ilevel3, iresult_source, itarget_source, iresult_create_time,
                                       iunit_type_ref_id, itxr_user);
        }

        public int UpdateData(IDbConnection conn, IDbTransaction trx,
                              int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, string ilevel1, string ilevel2,
                              string ilevel3, string iresult_source, string itarget_source, string iresult_create_time,
                              int iunit_type_ref_id, int itxr_user)
        {
            return base.UpdateData_Dac(conn, trx,
                                       iestterm_ref_id, ikpi_ref_id, idatasource_id, ilevel1, ilevel2,
                                       ilevel3, iresult_source, itarget_source, iresult_create_time,
                                       iunit_type_ref_id, itxr_user);
        }

        public int DeleteData(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int ikpi_ref_id, int idatasource_id, int itxr_user)
        {
            return base.DeleteData_Dac(conn, trx, iestterm_ref_id, ikpi_ref_id, idatasource_id, itxr_user);
        }
       
    }
}
