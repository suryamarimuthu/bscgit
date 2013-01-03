using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

using MicroBSC.Biz.Common.Dac;

namespace MicroBSC.Biz.Common.Biz
{
    /// <summary>
    /// Biz_app_app0000에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Biz_app_app0000 Biz 클래스
    /// Class 내용		: app0000 Biz Logic 처리 
    ///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
    ///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.20
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// ----------------------------------------------------------
    public class Biz_app_app0000
    {
        /// <summary>
        /// GetDDLAppGubun
        ///     : 업무 구분 드롭다운리스트 추출
        /// </summary>
        /// <returns></returns>
        public DataSet GetDDLAppGubun()
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                lDS = dac.GetDDLAppGubun();

                scope.Complete();
            }

            return lDS;
        }

        /// <summary>
        /// GetDDLEstTerm
        ///     : 평가 기간 드롭다운리스트 추출
        /// </summary>
        /// <returns></returns>
        public DataSet GetDDLEstTerm()
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                lDS = dac.GetDDLEstTerm();

                scope.Complete();
            }

            return lDS;
        }

        /// <summary>
        /// GetSearchData
        ///     : 결재승인 정보 추출
        /// </summary>
        /// <param name="asEmpID"></param>
        /// <returns></returns>
        public DataSet GetSearchData(string asEmpID, string asAppGubun, string asEstTerm, string asAppStatus, bool bIsRep)
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                lDS = dac.GetSearchData(asEmpID, asAppGubun, asEstTerm, asAppStatus, bIsRep);

                scope.Complete();
            }

            return lDS;
        }

        /// <summary>
        /// GetSearchData
        ///     : 결재승인 정보 추출
        /// </summary>
        /// <param name="asEmpID"></param>
        /// <returns></returns>
        public DataSet GetSearchData(int aiEmpID, string asAppGubun, string asEstTerm, string asAppStatus, bool bIsRep)
        {
            return GetSearchData(aiEmpID.ToString(), asAppGubun, asEstTerm, asAppStatus, bIsRep);
        }

        /// <summary>
        /// GetSearchDetail
        ///     : 세부사항 추출쿼리 (app2000에서 사용)
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <returns></returns>
        public DataSet GetSearchDetail(string asAppRefID)
        {
            DataSet lDS = new DataSet();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                lDS = dac.GetSearchDetail(asAppRefID);

                scope.Complete();
            }

            return lDS;
        }

        public int SetApprovalCancel(string asRemark, string[,] asaPrcKey)
        {
            int iTmp = 0;
            int iRet = 0;

            string sSaveAppInfo = "";   // APP_REF_ID;APP_STEP;APP_CODE;
            string[,] saSaveAppInfo;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                // 문서번호(V_APP_REF_ID);문서타입(V_APP_CODE);KPI문서정보(V_EVENT_ID);KPI문서추가정보(V_EVENT_ADD_ID);평가기간코드(V_TERM_REF_ID);현재결재단계(V_APP_STEP);전체결재단계(V_MAX_APP_STEP)
                for (int i = 0; i <= asaPrcKey.GetUpperBound(0); i++)
                {
                    sSaveAppInfo += asaPrcKey[i, 0] + ";" + asaPrcKey[i, 5] + ";" + asaPrcKey[i, 1] + ";";

                    // V_APP_CODE : KPIINF => KPI_INFO.CONFIRMSTATUS = 0
                    //            : KPIRST => KPI_RESULT.CONFIRMSTATUS = 0
                    iTmp = SetKPIConfirmStatus(asaPrcKey[i, 1], asaPrcKey[i, 2], asaPrcKey[i, 3], 0);

                    // 해당 처리를 하지 못했으면 결재처리 롤백.
                    if (iTmp <= 0)
                        return 0;

                    iTmp = SetAppTableCancel(asRemark, asaPrcKey[i, 0], asaPrcKey[i, 5], asaPrcKey[i, 4]);

                    // 해당 처리를 하지 못했으면 결재처리 롤백.
                    if (iTmp <= 0)
                        return 0;

                    iRet += iTmp;
                }

                scope.Complete();
            }

            #region 반려시 메일링처리
                Biz_App_Code_PageUtility biz = new Biz_App_Code_PageUtility();
                saSaveAppInfo = biz.GetSplit(sSaveAppInfo, 3);

                for (int i = 0; i <= saSaveAppInfo.GetUpperBound(0); i++)
                {
                    SendAlertMail(saSaveAppInfo[i, 0], saSaveAppInfo[i, 1], saSaveAppInfo[i, 2], BSC_SendMailType.TYPE_APP_CANCEL);
                }
            #endregion

            return iRet;
        }

        /// <summary>
        /// SetApprovalEnd
        ///     : 선택한 정보들에 대한 결재처리 로직
        /// </summary>
        /// <param name="asaPrcKey"></param>
        /// <returns></returns>
        public int SetApprovalEnd(string[,] asaPrcKey)
        {
            int iTmp = 0;
            int iRet = 0;

            string sSaveAppInfo = "";   // APP_REF_ID;APP_STEP;APP_CODE;
            string[,] saSaveAppInfo;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                // 문서번호(V_APP_REF_ID);문서타입(V_APP_CODE);KPI문서정보(V_EVENT_ID);KPI문서추가정보(V_EVENT_ADD_ID);평가기간코드(V_TERM_REF_ID);현재결재단계(V_APP_STEP);전체결재단계(V_MAX_APP_STEP)
                for (int i = 0; i <= asaPrcKey.GetUpperBound(0); i++)
                {
                    sSaveAppInfo += asaPrcKey[i, 0] + ";" + asaPrcKey[i, 5] + ";" + asaPrcKey[i, 1] + ";";

                    // V_APP_CODE : KPIINF => KPI_INFO.CONFIRMSTATUS = 1
                    //            : KPIRST => KPI_RESULT.CONFIRMSTATUS = 1
                    iTmp = SetKPIConfirmStatus(asaPrcKey[i, 1], asaPrcKey[i, 2], asaPrcKey[i, 3], 1);

                    // 해당 처리를 하지 못했으면 결재처리 롤백.
                    if (iTmp <= 0)
                        return 0;

                    iTmp = SetAppTableApproval(asaPrcKey[i, 0], asaPrcKey[i, 5], asaPrcKey[i, 4]);

                    // 해당 처리를 하지 못했으면 결재처리 롤백.
                    if (iTmp <= 0)
                        return 0;

                    iRet += iTmp;
                }

                scope.Complete();
            }

            #region 결재시 메일링처리
                Biz_App_Code_PageUtility biz = new Biz_App_Code_PageUtility();
                saSaveAppInfo = biz.GetSplit(sSaveAppInfo, 3);

                for (int i = 0; i <= saSaveAppInfo.GetUpperBound(0); i++)
                {
                    SendAlertMail(saSaveAppInfo[i, 0], saSaveAppInfo[i, 1], saSaveAppInfo[i, 2], BSC_SendMailType.TYPE_APP_APPROVAL);
                }
            #endregion

            return iRet;
        }

        /// <summary>
        /// SetApprovalRepCancel
        ///     : 선택한 정보들에 대한 상신취소 로직
        /// </summary>
        /// <param name="asaPrcKey"></param>
        /// <returns></returns>
        public int SetApprovalRepCancel(string[,] asaPrcKey)
        {
            int iTmp = 0;
            int iRet = 0;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                // 문서번호(V_APP_REF_ID);
                for (int i = 0; i <= asaPrcKey.GetUpperBound(0); i++)
                {
                    iTmp = SetAppTableRepCancel(asaPrcKey[i, 0]);

                    // 해당 처리를 하지 못했으면 결재처리 롤백.
                    if (iTmp <= 0)
                        return 0;

                    iRet += iTmp;
                }

                scope.Complete();
            }

            return iRet;
        }

        /// <summary>
        /// SetApprovalRep
        ///     : 상신 처리 (2006.06.21)
        /// </summary>
        /// <param name="asaPrcKey"></param>
        /// <returns></returns>
        public int SetApprovalRep(string asRepEmpID, string[,] asaPrcKey)
        {
            int iTmp = 0;
            int iRet = 0;

            string sSaveAppRefID = "";  // APP_REF_ID;APP_CODE;
            string[,] saSaveAppRefID;

            string sAppRefID = "";
            string sPrevAppRefID = "";

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_App_Code_TypeUtility dacType = new Dac_App_Code_TypeUtility();

                // KPI 臾몄꽌踰덊샇(KPI_REF_ID);?ㅼ쟻??EVENT_ADD_ID);寃곗옱???APP_CODE);?됯?湲곌컙肄붾뱶(TERM_REF_ID);
                for (int i = 0; i <= asaPrcKey.GetUpperBound(0); i++)
                {
                    //sAppRefID = dacType.GetDocNo("APP");

                    while (sPrevAppRefID == sAppRefID)
                    {
                        sAppRefID = dacType.GetDocNo("APP");
                    }

                    sPrevAppRefID = sAppRefID;

                    sSaveAppRefID += sAppRefID + ";" + asaPrcKey[i, 2] + ";";

                    iTmp = SetAppTableRep(sAppRefID, asaPrcKey[i, 0], asaPrcKey[i, 1], asaPrcKey[i, 2], asRepEmpID, asaPrcKey[i, 3]);

                    // 해당 처리를 하지 못했으면 상신처리 롤백.
                    if (iTmp <= 0)
                        return 0;

                    iRet += iTmp;
                }

                scope.Complete();
            }

            #region 상신시 메일링처리
                Biz_App_Code_PageUtility biz = new Biz_App_Code_PageUtility();
                saSaveAppRefID = biz.GetSplit(sSaveAppRefID, 2);

                for (int i = 0; i <= saSaveAppRefID.GetUpperBound(0); i++)
                {
                    SendAlertMail(saSaveAppRefID[i, 0], "1", saSaveAppRefID[i, 1], BSC_SendMailType.TYPE_APP_REPORT);
                }
            #endregion

            return iRet;
        }

        public int SetApprovalRep(int aiRepEmpID, string[,] asaPrcKey)
        {
            return SetApprovalRep(aiRepEmpID.ToString(), asaPrcKey);
        }

        /// <summary>
        /// SetKPIConfirmStatus
        ///     : 문서타입에 관련된 KPI 테이블의 CONFIRMSTATUS를 설정한다.
        /// </summary>
        /// <param name="asAppCode"></param>
        /// <param name="asTmCode"></param>
        /// <returns></returns>
        public int SetKPIConfirmStatus(string asAppCode, string asKpiRefID, string asTmCode, int aiStatus)
        {
            int iRet = 0;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                if (asAppCode == "KPIINF")
                    iRet = dac.SetKPIInfoApproval(asKpiRefID, aiStatus);
                else if (asAppCode == "KPIRST")
                    iRet = dac.SetKPIResultApproval(asKpiRefID, asTmCode, aiStatus);

                scope.Complete();
            }

            return iRet;
        }

        /// <summary>
        /// SetAppTableApproval
        ///     : 결재처리를 위한 테이블 수정처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asCurStep"></param>
        /// <param name="asTermRefID"></param>
        /// <returns></returns>
        public int SetAppTableApproval(string asAppRefID, string asCurStep, string asTermRefID)
        {
            int iRet = 0;
            int iTmp = 0;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                iRet = dac.SetPrcApproval(asAppRefID, asCurStep);

                if (iRet <= 0)
                    return 0;

                iTmp = dac.ConfirmRemainStep(asAppRefID, asTermRefID);

                if (iTmp > 0)
                {
                    // 더 처리할 결재가 있다.
                    // PRC APP_STATUS = 'E' INFO.CUR_APP_STEP += 1
                    dac.SetInfoApproval(asAppRefID, asTermRefID, iTmp);
                }
                else
                {
                    // 현재문서 처리가 결재의 마지막이다.
                    // INFO, PRC APP_STATUS = 'E', INFO.APP_COMPDATE=GETDATE()
                    iRet = dac.SetInfoApproval(asAppRefID, asTermRefID, iTmp);

                    if (iRet <= 0)
                        return 0;
                }

                

                scope.Complete();
            }

            return iRet;
        }

        /// <summary>
        /// SetAppTableCancel
        ///     : 승인취소 처리를 위한 테이블 수정처리
        /// </summary>
        /// <param name="asRemark"></param>
        /// <param name="asAppRefID"></param>
        /// <param name="asCurStep"></param>
        /// <param name="asTermRefID"></param>
        /// <returns></returns>
        public int SetAppTableCancel(string asRemark, string asAppRefID, string asCurStep, string asTermRefID)
        {
            int iRet = 0;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                iRet = dac.SetPrcCancel(asRemark, asAppRefID, asCurStep);

                if (iRet <= 0)
                    return 0;

                iRet = dac.SetInfoCancel(asAppRefID, asTermRefID);

                if (iRet <= 0)
                    return 0;

                

                scope.Complete();
            }

            return iRet;
        }

        /// <summary>
        /// SetAppTableRepCancel
        ///     : 상신취소 처리를 위한 테이블 수정처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <returns></returns>
        public int SetAppTableRepCancel(string asAppRefID)
        {
            int iRet = 0;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                iRet = dac.SetPrcRepCancel(asAppRefID);

                if (iRet <= 0)
                    return 0;

                iRet = dac.SetInfoRepCancel(asAppRefID);

                if (iRet <= 0)
                    return 0;

                scope.Complete();
            }

            return iRet;
        }

        /// <summary>
        /// SetAppTableRep
        ///     : 상신처리를 위한 테이블 수정처리
        /// </summary>
        /// <param name="asKpiRefID"></param>
        /// <returns></returns>
        public int SetAppTableRep(
                                    string asAppRefID   // 문서번호
                                   ,string asKpiRefID   // KPI_REF_ID
                                   ,string asEventAddID // 실적처리시 월
                                   ,string asAppCode    // KPIINF, KPIRST
                                   ,string asRepEmpID   // 상신자 아이디
                                   ,string asTermRefID  // 평가기간
                                 )
        {
            int iRet = 0;
            string sAppRefID = "";

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();

                sAppRefID = asAppRefID;

                #region 결재 히스토리테이블 추가
                    DataSet lDS = dac.GetApprovalLine(asAppCode, asRepEmpID);

                    foreach (DataRow dr in lDS.Tables[0].Rows)
                    {
                        iRet += dac.SetPrcRep(sAppRefID, dr["APP_STEP"].ToString(), dr["APP_EMP_ID"].ToString());
                    }

                    if (iRet <= 0 || (iRet < lDS.Tables[0].Rows.Count))
                        return 0;
                #endregion
                
                #region 결재 테이블 추가
                    iRet = dac.SetInfoRep(asKpiRefID, sAppRefID, asEventAddID, asAppCode, asRepEmpID, asTermRefID);
                    
                    if (iRet <= 0)
                        return 0;                
                #endregion

                
                scope.Complete();
            }

            return iRet;
        }

        public bool IsKPIApprovalInfo(string asEmpID, string asKpiRefID, string asAppCode, string asMonth, out string sErrMsg)
        {
            bool bRet = false;
            sErrMsg = "";

            int iCnt = -1;
            string sChampEmpID = "";
            string sAppStatus = "";
            DataSet lDS = null;

            Dac_app_app0000 dac = new Dac_app_app0000();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                lDS = dac.GetKPIApprovalInfo(asKpiRefID, asAppCode, asMonth);

                iCnt = Convert.ToInt32(lDS.Tables[0].Rows[0]["V_CNT"]);
                sChampEmpID = lDS.Tables[0].Rows[0]["V_CHAM_EMP_ID"].ToString();
                sAppStatus = lDS.Tables[0].Rows[0]["V_APP_STATUS"].ToString();

                scope.Complete();
            }

            // iCnt가 0 이거나
            // iCnt == 1 이면서 sAppStatus == "C", "E"인 상태만 상신할 수 있다.
            // 자기 KPI만 처리 가능하다.

            if (iCnt == 0 && (asEmpID == sChampEmpID))
            {
                bRet = true;
            }
            else if (sAppStatus != "P" && (asEmpID == sChampEmpID))
            {
                bRet = true;
            }
            else
            {
                bRet = false;

                if (iCnt < 0)
                    sErrMsg = "테이블 검색 오류입니다!";
                else
                {
                    switch (sAppStatus)
                    {
                        case "P":
                            sErrMsg = "해당 KPI정보로 이미 상신되어 결재대기중에 있습니다!";
                            break;
                        default:
                            sErrMsg = "해당 KPI정보로 알 수 없는 타입의 결재정보가 있습니다!\\n\\n[" + asKpiRefID + "] 의 코드로 관리자에게 문의하십시요";
                            break;
                    }
                }
            }

            
            if (bRet)
            {
                // 실적KPI관련 상신인가?
                // 실적KPI상신이면 CHECKSTATUS = 1 && CONFIRMSTATUS = 0 인 경우만 확정가능
                if (asMonth != "")
                {
                    lDS = dac.GetKPIStatus(asKpiRefID, asMonth);
 
                    if (
                            Convert.ToBoolean(lDS.Tables[0].Rows[0]["CHECKSTATUS"]) == true 
                         && Convert.ToBoolean(lDS.Tables[0].Rows[0]["CONFIRMSTATUS"]) == false
                       )
                    {
                        bRet = true;
                    }
                    else
                    {
                        bRet = false;

                        sErrMsg = "실적관련 결재대상건이 아닙니다!";
                    }
                }
            }

            return bRet;
        }

        /// <summary>
        /// IsKPIApprovalInfo
        ///     : KPI_REF_ID로 현재 상신할 수 있는 상태인지 검사
        /// </summary>
        /// <param name="asEmpID">현재 사용자</param>
        /// <param name="asKpiRefID"></param>
        /// <param name="sErrMsg"></param>
        /// <returns></returns>
        public bool IsKPIApprovalInfo(string asEmpID, string asKpiRefID, string asAppCode, out string sErrMsg)
        {
            return IsKPIApprovalInfo(asEmpID, asKpiRefID, asAppCode, "", out sErrMsg);
        }

        public string GetSplitReportMailInfo(string asAppRefID)
        {
            string sRet = "";

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();
                DataSet lDS = dac.GetDSReportMailInfo(asAppRefID);

                foreach (DataRow dr in lDS.Tables[0].Rows)
                {
                    sRet += dr["V_KPIINFO"].ToString()          + ";"
                          + dr["V_REP_EMP_NAME"].ToString()     + ";"
                          + dr["V_REP_EMP_EMAIL"].ToString()    + ";"
                          + dr["V_APP_EMP_EMAIL"].ToString()    + ";";
                }
            }

            return sRet;
        }

        public string GetSplitApprovalMailInfo(string asAppRefID, string asAppStep)
        {
            string sRet = "";

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();
                DataSet lDS = dac.GetDSApprovalMailInfo(asAppRefID, asAppStep);

                foreach (DataRow dr in lDS.Tables[0].Rows)
                {
                    sRet += dr["V_KPIINFO"].ToString() + ";"
                          + dr["V_APP_EMP_NAME"].ToString() + ";"
                          + dr["V_APP_EMP_EMAIL"].ToString() + ";"
                          + dr["V_REP_EMP_EMAIL"].ToString() + ";";
                }
            }

            return sRet;
        }

        public string GetSplitCancelMailInfo(string asAppRefID, string asAppStep)
        {
            string sRet = "";

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                Dac_app_app0000 dac = new Dac_app_app0000();
                DataSet lDS = dac.GetDSCancelMailInfo(asAppRefID, asAppStep);

                foreach (DataRow dr in lDS.Tables[0].Rows)
                {
                    sRet += dr["V_KPIINFO"].ToString() + ";"
                          + dr["V_APP_EMP_NAME"].ToString() + ";"
                          + dr["V_APP_EMP_EMAIL"].ToString() + ";"
                          + dr["V_REP_EMP_EMAIL"].ToString() + ";";
                }
            }

            return sRet;
        }

        /// <summary>
        /// SendAlertMail
        ///     : 결재시 Alert메일 발송
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="enType"></param>
        /// <returns></returns>
        public void SendAlertMail(string asAppRefID, string asAppStep, string asAppCode, BSC_SendMailType enType)
        {
            string sInfo = "";
            string[,] sArray;

            DataSet lDS = new DataSet();
            Biz_App_Code_PageUtility biz = new Biz_App_Code_PageUtility();
            

            switch(enType)
            {
                case BSC_SendMailType.TYPE_APP_REPORT:
                    // 상신했을때 첫번째 결재자에게 메일발송
                    sArray = biz.GetSplit(GetSplitReportMailInfo(asAppRefID));
                    sInfo = sArray[0, 0] + ";" + sArray[1, 0] + ";" + asAppCode;
                    
                    biz.SendMail(biz.GetSplit(sInfo), sArray[2, 0], sArray[3, 0], enType);

                    break;
                case BSC_SendMailType.TYPE_APP_APPROVAL:
                    // 결재했을때 상신자에게 메일발송
                    sArray = biz.GetSplit(GetSplitApprovalMailInfo(asAppRefID, asAppStep));
                    sInfo = sArray[0, 0] + ";" + sArray[1, 0] + ";" + asAppCode;

                    biz.SendMail(biz.GetSplit(sInfo), sArray[2, 0], sArray[3, 0], enType);

                    break;
                case BSC_SendMailType.TYPE_APP_CANCEL:
                    // 반려했을때 상신자에게 메일발송
                    sArray = biz.GetSplit(GetSplitCancelMailInfo(asAppRefID, asAppStep));
                    sInfo = sArray[0, 0] + ";" + sArray[1, 0] + ";" + asAppCode;

                    biz.SendMail(biz.GetSplit(sInfo), sArray[2, 0], sArray[3, 0], enType);

                    break;
            }

        }
    }
}
