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
using System.Transactions;

using MicroBSC.Data;


namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Normdist_Group에 대한 요약 설명입니다.
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
    public class Biz_Bsc_Kpi_Normdist_Group : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Normdist_Group
    {
        public Biz_Bsc_Kpi_Normdist_Group() { }


        public int InsertData
              (int iestterm_ref_id, int ikpi_ref_code, string inormdist_group, string inormdist_use_yn, int itxr_user)
        {
            return base.InsertData_Dac
              (iestterm_ref_id, ikpi_ref_code, inormdist_group, inormdist_use_yn, itxr_user);
        }

        public int UpdateData
           (int iestterm_ref_id, int ikpi_ref_code, string inormdist_group, string inormdist_use_yn, int itxr_user)
        {
            return base.UpdateData_Dac
              (iestterm_ref_id, ikpi_ref_code, inormdist_group, inormdist_use_yn, itxr_user);
        }

        public DataSet GetNormdistList(int iestterm_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, string ikpi_group_ref_id, string iNormadist_group, string iNormdist_use_yn, int itxr_user)
        {
            return base.GetNormdistList_Dac(iestterm_ref_id, iresult_input_type, ikpi_code, ikpi_name, iuse_yn, ichampion_name, iest_dept_ref_id, ikpi_group_ref_id,iNormadist_group, iNormdist_use_yn, itxr_user);
        }
    }
}
