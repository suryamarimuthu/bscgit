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
    public class Biz_Bsc_Kpi_Score_Detail : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Score_Detail
    {
        public Biz_Bsc_Kpi_Score_Detail() { }

        public Biz_Bsc_Kpi_Score_Detail(int iestterm_ref_id, int ikpi_ref_id, string iymd) : 
               base(iestterm_ref_id, ikpi_ref_id, iymd) {}

        public int InsertData
                  (int iestterm_ref_id, int ikpi_ref_id, string iymd, 
                   string inrmdst_use_ms, string ipoints_ori_ms, string ipoints_avg_ms, string ipoints_std_ms, string ipoints_ada_ms, string ipoints_ads_ms, string ipoints_nor_ms, string ipoints_fnl_ms,
                   string inrmdst_use_ts, string ipoints_ori_ts, string ipoints_avg_ts, string ipoints_std_ts, string ipoints_ada_ts, string ipoints_ads_ts, string ipoints_nor_ts, string ipoints_fnl_ts,
                   int itxr_user)
        { 
            return base.InsertData_Dac
                          (iestterm_ref_id, ikpi_ref_id, iymd, 
                           inrmdst_use_ms, ipoints_ori_ms, ipoints_avg_ms, ipoints_std_ms, ipoints_ada_ms, ipoints_ads_ms, ipoints_nor_ms, ipoints_fnl_ms, 
                           inrmdst_use_ts, ipoints_ori_ts, ipoints_avg_ts, ipoints_std_ts, ipoints_ada_ts, ipoints_ads_ts, ipoints_nor_ts, ipoints_fnl_ts, 
                           itxr_user);
        }

        public int UpdateData
                  (int iestterm_ref_id, int ikpi_ref_id, string iymd, 
                   string inrmdst_use_ms, string ipoints_ori_ms, string ipoints_avg_ms, string ipoints_std_ms, string ipoints_ada_ms, string ipoints_ads_ms, string ipoints_nor_ms, string ipoints_fnl_ms,
                   string inrmdst_use_ts, string ipoints_ori_ts, string ipoints_avg_ts, string ipoints_std_ts, string ipoints_ada_ts, string ipoints_ads_ts, string ipoints_nor_ts, string ipoints_fnl_ts,
                   int itxr_user)
        { 
            return base.UpdateData_Dac
                          (iestterm_ref_id, ikpi_ref_id, iymd, 
                           inrmdst_use_ms, ipoints_ori_ms, ipoints_avg_ms, ipoints_std_ms, ipoints_ada_ms, ipoints_ads_ms, ipoints_nor_ms, ipoints_fnl_ms, 
                           inrmdst_use_ts, ipoints_ori_ts, ipoints_avg_ts, ipoints_std_ts, ipoints_ada_ts, ipoints_ads_ts, ipoints_nor_ts, ipoints_fnl_ts, 
                           itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id, ikpi_ref_id, iymd, itxr_user);
        }

        public int DeleteDataAll(int iestterm_ref_id, string iymd, int itxr_user)
        { 
            return base.DeleteDataAll_Dac(iestterm_ref_id, iymd, itxr_user);
        }

        public int UpdateExternalScore
                  (int iestterm_ref_id, int ikpi_ref_id, string iymd,
                   string inrmdst_use_ts, string ipoints_ori_ts, string ipoints_avg_ts, string ipoints_std_ts, string ipoints_ada_ts, string ipoints_ads_ts, string ipoints_nor_ts, string ipoints_fnl_ts,
                   int itxr_user)
        {
            return base.UpdateExternalScore_Dac
                          (iestterm_ref_id, ikpi_ref_id, iymd,
                           inrmdst_use_ts, ipoints_ori_ts, ipoints_avg_ts, ipoints_std_ts, ipoints_ada_ts, ipoints_ads_ts, ipoints_nor_ts, ipoints_fnl_ts,
                           itxr_user);
        }
    }

}