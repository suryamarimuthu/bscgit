using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.BSC.Dac;

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
    public class Biz_Bsc_Validation_Group_Kpi : Dac_Bsc_Validation_Group_Kpi
    {
        public Biz_Bsc_Validation_Group_Kpi() { }
        public Biz_Bsc_Validation_Group_Kpi(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id) 
             : base(iestterm_ref_id, igroup_ref_id, iest_level, iemp_ref_id, ikpi_ref_id) { }

        public int InsertData(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user) 
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , iest_level
                                     , iemp_ref_id
                                     , ikpi_ref_id
                                     , iopinion
                                     , itxr_user);
        }
        public int UpdateData(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user) 
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , iest_level
                                     , iemp_ref_id
                                     , ikpi_ref_id
                                     , iopinion
                                     , itxr_user);
        }
        public int DeleteData(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , iest_level
                                     , iemp_ref_id
                                     , ikpi_ref_id
                                     , itxr_user);
        }

        public int ConfirmOpnion(int iestterm_ref_id, int  igroup_ref_id, int iest_level, int iemp_ref_id, int ikpi_ref_id, string iopinion, int itxr_user) 
        {
            return base.ConfirmOpnion_Dac(iestterm_ref_id
                                        , igroup_ref_id
                                        , iest_level
                                        , iemp_ref_id
                                        , ikpi_ref_id
                                        , iopinion
                                        , itxr_user);
        }

        public int CopyValuationKpiList(int iestterm_ref_id, int igroup_ref_id, int iest_level, int ifrom_emp_ref_id, int itxr_user)
        { 
            return base.CopyValuationKpiList_Dac(iestterm_ref_id, igroup_ref_id, iest_level, ifrom_emp_ref_id, itxr_user);
        }
    }
}