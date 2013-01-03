using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_EstDept_LoadMap의 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Kpi_Pool Biz 클래스
    /// Class 내용		: Kpi_Pool Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2006.11.01
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------

    public class Biz_Bsc_EstDept_LoadMap : MicroBSC.BSC.Dac.Dac_Bsc_EstDept_LoadMap
    {
        public Biz_Bsc_EstDept_LoadMap() { }
        public Biz_Bsc_EstDept_LoadMap(int estterm_ref_id, int est_dept_ref_id, string ymd) : base(estterm_ref_id, est_dept_ref_id, ymd) { }

        public int InsertData(int estterm_ref_id, int est_dept_ref_id, string ymd, string monthly_plan, string details, string etc_contents, int itxr_user)
        {
            return base.InsertData_Dac(estterm_ref_id
                                     , est_dept_ref_id
                                     , ymd
                                     , monthly_plan
                                     , details
                                     , etc_contents
                                     , itxr_user);
        }

        public int UpdateData(int estterm_ref_id, int est_dept_ref_id, string ymd, string monthly_plan, string details, string etc_contents, int itxr_user)
        {
            return base.UpdateData_Dac(estterm_ref_id
                                     , est_dept_ref_id
                                     , ymd
                                     , monthly_plan
                                     , details
                                     , etc_contents
                                     , itxr_user);
        }

        public int DeleteData(int estterm_ref_id, int est_dept_ref_id, string ymd, string monthly_plan, string details, string etc_contents, int itxr_user)
        {
            return base.DeleteData_Dac(estterm_ref_id
                                     , est_dept_ref_id
                                     , ymd
                                     , itxr_user);
        }
    }
}