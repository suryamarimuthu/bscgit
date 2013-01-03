using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Kpi_Qlt_Score_Had에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_Bsc_Kpi_Qlt_Score_Had Biz 클래스
    /// Class 내용		: Biz_Bsc_Kpi_Qlt_Score_Had Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 방병현
    /// 최초작성일		: 2006.11.01
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_Bsc_Kpi_Qlt_Score_Det : MicroBSC.BSC.Dac.Dac_Bsc_Kpi_Qlt_Score_Det
    {
        public Biz_Bsc_Kpi_Qlt_Score_Det() { }
        public Biz_Bsc_Kpi_Qlt_Score_Det(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id) 
             : base(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, iquestion_ref_id) { }

        public int InsertData(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                              double iscore, int itxr_user) 
        {
            return base.InsertData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , ikpi_ref_id
                                     , iest_emp_id
                                     , iymd
                                     , iest_level
                                     , iquestion_ref_id
                                     , iscore
                                     , itxr_user);
        }

        public int UpdateData(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, 
                              double iscore, int itxr_user) 
        {
            return base.UpdateData_Dac(iestterm_ref_id
                                     , igroup_ref_id
                                     , ikpi_ref_id
                                     , iest_emp_id
                                     , iymd
                                     , iest_level
                                     , iquestion_ref_id
                                     , iscore
                                     , itxr_user);
        }

        public int DeleteData(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id, int itxr_user) 
        {
            return base.DeleteData_Dac(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, iquestion_ref_id, itxr_user);
        }

        /// <summary>
        /// 평가항목 점수평가
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="iquestion_ref_id"></param>
        /// <param name="iscore"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstQuestionItem(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd
                                 , int iest_level, int iquestion_ref_id, double iscore, int itxr_user)
        { 
            return base.EstQuestionItem_Dac(iestterm_ref_id
                                          , igroup_ref_id
                                          , ikpi_ref_id
                                          , iest_emp_id
                                          , iymd
                                          , iest_level
                                          , iquestion_ref_id
                                          , iscore
                                          , itxr_user);
        }

        /// <summary>
        /// 평가항목 등급평가
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="iquestion_ref_id"></param>
        /// <param name="iscore_grade"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstQuestionItemGrade(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int iquestion_ref_id,
                                            string iscore_grade, int itxr_user)
        { 
            return base.EstQuestionItemGrade_Dac(
                          iestterm_ref_id
                        , igroup_ref_id
                        , ikpi_ref_id
                        , iest_emp_id
                        , iymd
                        , iest_level
                        , iquestion_ref_id  
                        , iscore_grade
                        , itxr_user);
        }

        /// <summary>
        /// 평가점수 확정
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstConfirm(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int itxr_user)
        { 
            return base.EstConfirm_Dac(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, itxr_user);
        }

        /// <summary>
        /// 평가점수 확정 취소
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="igroup_ref_id"></param>
        /// <param name="ikpi_ref_id"></param>
        /// <param name="iest_emp_id"></param>
        /// <param name="iymd"></param>
        /// <param name="iest_level"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public int EstCancel(int iestterm_ref_id, int igroup_ref_id, int ikpi_ref_id, int iest_emp_id, string iymd, int iest_level, int itxr_user)
        { 
            return base.EstCancel_Dac(iestterm_ref_id, igroup_ref_id, ikpi_ref_id, iest_emp_id, iymd, iest_level, itxr_user);
        }
    }
}
