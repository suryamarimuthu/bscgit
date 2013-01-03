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

using MicroBSC.Integration.COM.Dac;
using MicroBSC.Integration.BSC.Dac;
using MicroBSC.Data;

/// <summary>
/// Biz_My_Kpi 의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_My_Kpi Biz 클래스
/// Class 내용		: Biz_My_Kpi Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
///                 : 사용자 intro 화면에서 자신의 mbo kpi의 등급을 조회한다.
///                 : mbo kpi가 없는 사용자는 자신의 팀 kpi의 등급을 보여준다.
/// 작성자			: 서대원
/// 최초작성일		: 2012.09.14
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
/// 
namespace MicroBSC.Integration.BSC.Biz
{

    public class Biz_My_Kpi
    {
        Dac_My_Kpi _data;

	    public Biz_My_Kpi()
	    {
            _data = new Dac_My_Kpi();

		    //
		    // TODO: Add constructor logic here
		    //
	    }

        public DataTable SelectMyMboKpi(int estterm_ref_id, string ymd, string loginid)
        {
            MicroBSC.Integration.BSC.Dac.Dac_My_Kpi dacMyKpi = new MicroBSC.Integration.BSC.Dac.Dac_My_Kpi();
            return dacMyKpi.SelectMyMboKpi(estterm_ref_id, ymd, loginid);
        }

        public DataTable SelectMyTeamKpi(int estterm_ref_id, string ymd, string loginid)
        {
            MicroBSC.Integration.BSC.Dac.Dac_My_Kpi dacMyKpi = new MicroBSC.Integration.BSC.Dac.Dac_My_Kpi();
            return dacMyKpi.SelectMyTeamKpi(estterm_ref_id, ymd, loginid);
        }

        public string  SelectCurrentYYYYMM()
        {
            MicroBSC.Integration.BSC.Dac.Dac_My_Kpi dacMyKpi = new MicroBSC.Integration.BSC.Dac.Dac_My_Kpi();
            DataTable dt =  dacMyKpi.SelectCurrentYYYYMM();

            string YYYYMM = "";

            if (dt.Rows.Count > 0)
            {
                YYYYMM = dt.Rows[0][0].ToString();
            }

            return YYYYMM;
        }
    }
}
