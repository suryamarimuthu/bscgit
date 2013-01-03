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
/// Class 명		: Biz_Bsc_Kpi_Dashboard Biz 클래스
/// Class 내용		: Biz_Bsc_Kpi_Dashboard Biz Logic 처리 
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
    public class Biz_Bsc_Kpi_Dashboard : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Dashboard
    {
        //Biz_Bsc_Kpi_Dashboard() { }
    }
}