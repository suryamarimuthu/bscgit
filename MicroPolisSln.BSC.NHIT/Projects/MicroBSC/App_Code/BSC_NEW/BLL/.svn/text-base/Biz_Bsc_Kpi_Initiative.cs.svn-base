using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Biz.BSC.Dac;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_mgr_svr3203에 대한 요약 설명입니다.
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
    public class Biz_Bsc_Kpi_Initiative : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Initiative
    {
        public Biz_Bsc_Kpi_Initiative() { }
        public Biz_Bsc_Kpi_Initiative(int iestterm_ref_id, int ikpi_ref_id, string iymd) :
               base(iestterm_ref_id, ikpi_ref_id, iymd) {}

        public int InsertData(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_plan, string iinitiative_do, string iinitiative_desc, int itxr_user)
        { 
            return base.InsertData_Dac( iestterm_ref_id
                                      , ikpi_ref_id
                                      , iymd
                                      , iinitiative_plan
                                      , iinitiative_do
                                      , iinitiative_desc
                                      , itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_plan, string iinitiative_do, string iinitiative_desc, int itxr_user)
        { 
            return base.UpdateData_Dac(iestterm_ref_id
                                     , ikpi_ref_id
                                     , iymd
                                     , iinitiative_plan
                                     , iinitiative_do
                                     , iinitiative_desc
                                     , itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int ikpi_ref_id, string iymd, int itxr_user)
        { 
            return base.DeleteData_Dac(iestterm_ref_id
                                     , ikpi_ref_id
                                     , iymd
                                     , itxr_user);
        }

        /// <summary>
        /// 이니셔티브 실적 및 파일첨부
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iinitiative_do"></param>
        /// <param name="ido_file"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int InsertInitiativeDo(int iestterm_ref_id, int ikpi_ref_id, string iymd, string iinitiative_do, string ido_file, int itxr_user)
        { 
            return base.InsertInitiativeDo_Dac(iestterm_ref_id
                                             , ikpi_ref_id
                                             , iymd
                                             , iinitiative_do
                                             , ido_file
                                             , itxr_user);
        }
    }
}