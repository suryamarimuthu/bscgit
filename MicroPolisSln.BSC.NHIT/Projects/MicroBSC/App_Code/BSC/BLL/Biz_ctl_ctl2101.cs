using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Biz.BSC.Dac;

namespace MicroBSC.Biz.BSC.Biz
{
    /// <summary>
    /// Biz_ICM_ICM112에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_ctl_ctl2101 Biz 클래스
    /// Class 내용		: ctl2101 Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.05.24
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_ctl_ctl2101
    {
        public int AddEmpInfo(
                              int aiDeptID
                            , string asLOGINID
                            , string asLOGINIP
                            , string asPASSWD
                            , string asEMP_NAME
                            , string asPOSITION_CLASS_CODE
                            , string asPOSITION_GRP_CODE
                            , string asPOSITION_RANK_CODE
                            , string asPOSITION_DUTY_CODE
                            , string asPOSITION_STAT_CODE
                            , string asPOSITION_KIND_CODE
                            , string asEMP_EMail
                            , string asDAILY_PHONE
                            , string asCELL_PHONE
                            , string asFAX_NUMBER
                            , int aiJOB_STATUS
                            , string asZIPCODE
                            , string asADDR_1
                            , string asADDR_2
                            , string asSIGN_PATH
                            , string asSTAMP_PATH
                            , int aiCREATE_TYPE
                            , int aiCREATE_EMP_ID
                            , int aiMODIFY_TYPE
                            , int aiMODIFY_EMP_ID
                             )
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2101 dac = new Dac_ctl_ctl2101();
            int iEmpRefID = dac.GetAddEmpRefID();

            iRet = dac.AddEmpInfo(
                                  iEmpRefID
                                , asLOGINID
                                , asLOGINIP
                                , asPASSWD
                                , asEMP_NAME
                                , asPOSITION_CLASS_CODE
                                , asPOSITION_GRP_CODE
                                , asPOSITION_RANK_CODE
                                , asPOSITION_DUTY_CODE
                                , asPOSITION_STAT_CODE
                                , asPOSITION_KIND_CODE
                                , asEMP_EMail
                                , asDAILY_PHONE
                                , asCELL_PHONE
                                , asFAX_NUMBER
                                , aiJOB_STATUS
                                , asZIPCODE
                                , asADDR_1
                                , asADDR_2
                                , asSIGN_PATH
                                , asSTAMP_PATH
                                , aiCREATE_TYPE
                                , aiCREATE_EMP_ID
                                , aiMODIFY_TYPE
                                , aiMODIFY_EMP_ID
                                 );

            iRet += dac.AddRelDeptInfo(iEmpRefID, aiDeptID, aiCREATE_EMP_ID);
            /* 2011-05-24 수정 : 부서변경시 부서범위 테이블도 같이 업데이트 하도록 수정 */
            iRet += dac.SaveEmployeeDeptDetail(iEmpRefID, 0, aiDeptID, aiCREATE_EMP_ID);
            /* 2011-05-24 수정 완료 *******************************************************/
            //    scope.Complete();
            //}

            return iRet;
        }

        public int EditEmpInfo(
                               int aiPrevDeptID
                             , int aiDeptID
                             , int aiEMP_REF_ID
                             , string asLOGINID
                             , string asLOINGIP
                             , string asEMP_NAME
                             , string asPOSITION_CLASS_CODE
                             , string asPOSITION_GRP_CODE
                             , string asPOSITION_RANK_CODE
                             , string asPOSITION_DUTY_CODE
                             , string asPOSITION_STAT_CODE
                             , string asPOSITION_KIND_CODE
                             , string asEMP_EMail
                             , string asDAILY_PHONE
                             , string asCELL_PHONE
                             , string asFAX_NUMBER
                             , int aiJOB_STATUS
                             , string asZIPCODE
                             , string asADDR_1
                             , string asADDR_2
                             , string asSIGN_PATH
                             , string asSTAMP_PATH
                             , int aiCREATE_TYPE
                             , int aiCREATE_EMP_ID
                             , int aiMODIFY_TYPE
                             , int aiMODIFY_EMP_ID
                              )
        {
            int iRet = 0;

            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            Dac_ctl_ctl2101 dac = new Dac_ctl_ctl2101();

            iRet += dac.EditRelDeptInfo(aiEMP_REF_ID, aiPrevDeptID, aiDeptID, aiMODIFY_EMP_ID);
           
            iRet += dac.EditEmpInfo(
                                  aiEMP_REF_ID
                                , asLOGINID
                                , asLOINGIP
                                , asEMP_NAME
                                , asPOSITION_CLASS_CODE
                                , asPOSITION_GRP_CODE
                                , asPOSITION_RANK_CODE
                                , asPOSITION_DUTY_CODE
                                , asPOSITION_STAT_CODE
                                , asPOSITION_KIND_CODE
                                , asEMP_EMail
                                , asDAILY_PHONE
                                , asCELL_PHONE
                                , asFAX_NUMBER
                                , aiJOB_STATUS
                                , asZIPCODE
                                , asADDR_1
                                , asADDR_2
                                , asSIGN_PATH
                                , asSTAMP_PATH
                                , aiCREATE_TYPE
                                , aiCREATE_EMP_ID
                                , aiMODIFY_TYPE
                                , aiMODIFY_EMP_ID
                                 );

            /* 2011-05-24 수정 : 부서변경시 부서범위 테이블도 같이 업데이트 하도록 수정 */
            iRet += dac.SaveEmployeeDeptDetail(aiEMP_REF_ID, aiPrevDeptID, aiDeptID, aiCREATE_EMP_ID);
            /* 2011-05-24 수정 완료 *******************************************************/

            //    scope.Complete();
            //}

            return iRet;
        }
    }
}
