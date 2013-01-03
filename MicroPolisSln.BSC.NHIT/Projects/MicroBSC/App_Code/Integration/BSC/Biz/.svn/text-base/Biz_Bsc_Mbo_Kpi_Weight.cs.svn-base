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
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Mbo_Kpi_Weight : MicroBSC.Integration.BSC.Dac.Dac_Bsc_Mbo_Kpi_Weight
    {
        public Biz_Bsc_Mbo_Kpi_Weight() { }

        public DataTable GetWeightGraph_DB(int comp_id
                                    , int estterm_ref_id
                                    , int estterm_sub_id
                                    , int tgt_emp_id
                                    , string is_team_kpi)
        {
            return SelectGraph_Data(comp_id
                                   , estterm_ref_id
                                   , estterm_sub_id
                                   , tgt_emp_id
                                   , is_team_kpi);
        }


        public DataTable GetWeight_DB(int estterm_ref_id
                                    , int emp_ref_id
                                    , string use_yn)
        {
            return SelectData_DB(estterm_ref_id
                                   , emp_ref_id
                                   , use_yn);
        }

    }
}
