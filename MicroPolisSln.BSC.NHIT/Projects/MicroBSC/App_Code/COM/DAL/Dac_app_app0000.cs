using System;
using System.Web;
using System.Data;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_app_app0000에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_app_app0000 Dac 클래스
    /// Class 내용		: app0000 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.20
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_app_app0000 : DbAgentBase
    {
        /// <summary>
        /// GetDDLAppGubun
        ///     : 업무 구분 드롭다운리스트 추출
        /// </summary>
        /// <returns></returns>
        public DataSet GetDDLAppGubun()
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT BIZ_TYPE_CODE    V_CODE, \n");
            sbQuery.Append("       BIZ_TYPE_NAME    V_NAME  \n");
            sbQuery.Append("  FROM COM_BIZ_INFO             \n");
            sbQuery.Append("  ORDER BY BIZ_TYPE_CODE DESC   \n");

            return DbAgentObj.Fill(sbQuery.ToString());
        }

        /// <summary>
        /// GetDDLEstTerm
        ///     : 평가 기간 드롭다운리스트 추출
        /// </summary>
        /// <returns></returns>
        public DataSet GetDDLEstTerm()
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT ESTTERM_REF_ID V_CODE,   \n");
            sbQuery.Append("       ESTTERM_NAME   V_NAME    \n");
            sbQuery.Append("  FROM EST_TERM_INFO            \n");
            sbQuery.Append(" ORDER BY                       \n");
            sbQuery.Append("       EST_STARTDATE DESC       \n");

            return DbAgentObj.Fill(sbQuery.ToString());
        }

        /// <summary>
        /// GetSearchData
        ///     : 결재승인 정보 추출
        /// </summary>
        /// <param name="asEmpID"></param>
        /// <param name="bIsRep">상신검색(true) / 결재검색(false)</param>
        /// <returns></returns>
        public DataSet GetSearchData(string asEmpID, string asAppGubun, string asEstTerm, string asAppStatus, bool bIsRep)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT                                                                      \n");
            sbQuery.Append("       A.APP_CODE           V_APP_CODE          , -- 문서타입      HIDDEN   \n");
            sbQuery.Append("       E.BIZ_TYPE_NAME      V_APP_TYPE_NAME     , -- 문서타입명             \n");
            sbQuery.Append("       A.APP_REF_ID         V_APP_REF_ID        , -- 문서번호               \n");
            sbQuery.Append("       G.KPI_REF_ID         V_KPI_REF_ID        , -- KPI_REF_ID             \n");
            sbQuery.Append("       G.KPI_CODE           V_KPI_CODE          , -- KPI 코드 (기간동안 UNIQUE한 KEY)   \n");
            sbQuery.Append("       G.KPI_NAME           V_KPI_NAME          , -- KPI NAME                           \n");
            sbQuery.Append("       CASE A.APP_CODE WHEN 'KPIRST' THEN                                               \n");
            sbQuery.Append("                                (                                                       \n");
            sbQuery.Append("                                SELECT ISNULL(MAX(RESULT), 0)                           \n");
            sbQuery.Append("                                  FROM KPI_RESULT                                       \n");
            sbQuery.Append("                                 WHERE KPI_REF_ID = A.EVENT_ID                          \n");
            sbQuery.Append("                                   AND TMCODE     = A.EVENT_ADD_ID                      \n");
            sbQuery.Append("                                )                                                       \n");
            sbQuery.Append("                       ELSE NULL                                                        \n");
            sbQuery.Append("       END V_KPI_RESULT                         , -- KPI 실적                           \n");
            sbQuery.Append("       A.EVENT_ID           V_EVENT_ID          , -- KPI_REF_ID    HIDDEN   \n");
            sbQuery.Append("       A.EVENT_ADD_ID       V_EVENT_ADD_ID      , -- KPI 관련 정보 HIDDEN   \n");
            sbQuery.Append("       B.APP_STEP           V_APP_STEP          , -- 현재결재단계  HIDDEN   \n");
            sbQuery.Append("       F.MAX_APP_STEP       V_MAX_APP_STEP      , -- 전체결재단계  HIDDEN   \n");
            sbQuery.Append("       A.REP_TITLE          V_REP_TITLE         , -- 상신 제목              \n");
            sbQuery.Append("       A.REP_EMP_ID         V_REP_EMP_ID        , -- 상신자 아이디 HIDDEN   \n");
            sbQuery.Append("       C.EMP_NAME           V_REP_EMP_NAME      , -- 상신자 명              \n");
            sbQuery.Append("       B.APP_EMP_ID         V_APP_EMP_ID        , -- 결재자 아이디 HIDDEN   \n");
            sbQuery.Append("       D.EMP_NAME           V_APP_EMP_NAME      , -- 결재자 명              \n");
            sbQuery.Append("       B.APP_REMARK         V_REMARK            , -- 취소사유               \n");
            sbQuery.Append("       CASE B.APP_STATUS WHEN 'P' THEN '대기'                               \n");
            sbQuery.Append("                         WHEN 'E' THEN '승인'                               \n");
            sbQuery.Append("                         WHEN 'C' THEN '취소'                               \n");
            sbQuery.Append("       END        V_CUR_APP_STATUS    , -- 현재결재상태                     \n");
            sbQuery.Append("       CASE A.APP_STATUS WHEN 'P' THEN '대기'                               \n");
            sbQuery.Append("                         WHEN 'E' THEN '승인'                               \n");
            sbQuery.Append("                         WHEN 'C' THEN '취소'                               \n");
            sbQuery.Append("       END        V_ALL_APP_STATUS    , -- 전체결재상태                     \n");
            sbQuery.Append("       A.APPTERM_REF_ID     V_TERM_REF_ID       , -- 평가기간      HIDDEN   \n");
            sbQuery.Append("       B.APP_STATUS         V_CUR_APP_STATUS_CD , -- 현재결재상태 코드 HIDDEN   \n");
            sbQuery.Append("       A.APP_STATUS         V_ALL_APP_STATUS_CD , -- 전체결재상태 코드 HIDDEN   \n");
            sbQuery.Append("       A.REP_DATE           V_REP_DATE          , -- 상신일                 \n");
            sbQuery.Append("       A.APP_COMPDATE       V_APP_COMPDATE        -- 결재일                 \n");
            sbQuery.Append("  FROM COM_APPROVAL_INFO A, -- 결재정보                                     \n");
            sbQuery.Append("       COM_APPROVAL_PRC  B, -- 결재 HISTORY 정보                            \n");
            sbQuery.Append("       COM_EMP_INFO      C, -- 상신자 정보                                  \n");
            sbQuery.Append("       COM_EMP_INFO      D, -- 결재자 정보                                  \n");
            sbQuery.Append("       COM_BIZ_INFO      E, -- 결재타입 정보                                \n");
            sbQuery.Append("       (                                                                    \n");
            sbQuery.Append("       SELECT BIZ_TYPE_CODE,                                                \n");
            sbQuery.Append("              MAX(APP_STEP) MAX_APP_STEP                                    \n");
            sbQuery.Append("         FROM COM_APPROVAL_LINE                                             \n");
            sbQuery.Append("        GROUP BY                                                            \n");
            sbQuery.Append("              BIZ_TYPE_CODE                                                 \n");
            sbQuery.Append("       ) F, -- 결재선 정보                                                  \n");
            sbQuery.Append("       KPI_INFO          G  -- KPI 정의                                     \n");
            sbQuery.Append(" WHERE 1=1                                                                  \n");
            sbQuery.Append("   AND A.APP_REF_ID    = B.APP_REF_ID                                       \n");
            sbQuery.Append("   AND A.CUR_APP_STEP  = B.APP_STEP                                         \n");
            sbQuery.Append("   AND A.REP_EMP_ID    = C.EMP_REF_ID                                       \n");
            sbQuery.Append("   AND B.APP_EMP_ID    = D.EMP_REF_ID                                       \n");
            sbQuery.Append("   AND A.APP_CODE      = E.BIZ_TYPE_CODE                                    \n");
            sbQuery.Append("   AND E.BIZ_TYPE_CODE = F.BIZ_TYPE_CODE                                    \n");
            sbQuery.Append("   AND A.EVENT_ID      = G.KPI_REF_ID                                       \n");
            
            if (bIsRep)
                sbQuery.Append("   AND a.REP_EMP_ID     = @APP_EMP_ID                                       \n");
            else
                sbQuery.Append("   AND B.APP_EMP_ID     = @APP_EMP_ID                                       \n");

            if (asAppGubun != "")
                sbQuery.Append("   AND E.BIZ_TYPE_CODE  = @BIZ_TYPE_CODE                                    \n");
            
            if (asEstTerm != "")
                sbQuery.Append("   AND A.APPTERM_REF_ID = CONVERT(INT, @APPTERM_REF_ID)                     \n");
            
            if (asAppStatus != "")
                sbQuery.Append("   AND A.APP_STATUS     = @APP_STATUS                                       \n");

            paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@APP_EMP_ID",     SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@BIZ_TYPE_CODE",  SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@APPTERM_REF_ID", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@APP_STATUS",     SqlDbType.VarChar);

            paramArray[0].Value = asEmpID;
            paramArray[1].Value = asAppGubun;
            paramArray[2].Value = asEstTerm;
            paramArray[3].Value = asAppStatus;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetSearchDetail
        ///     : 세부사항 추출쿼리 (app2000에서 사용)
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <returns></returns>
        public DataSet GetSearchDetail(string asAppRefID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT A.APP_STEP           V_APP_STEP          , -- 순번               \n");
            sbQuery.Append("       B.EMP_NAME           V_EMP_NAME          , -- 성명               \n");
            sbQuery.Append("       B.POSITION_DUTY_NAME V_POSITION_DUTY_NAME, -- 직책               \n");
            sbQuery.Append("       B.DEPT_NAME          V_DEPT_NAME         , -- 부서명             \n");
            sbQuery.Append("                                                                        \n");
            sbQuery.Append("       CASE A.APP_STATUS WHEN 'P' THEN '대기'                           \n");
            sbQuery.Append("                         WHEN 'E' THEN '승인'                           \n");
            sbQuery.Append("                         WHEN 'C' THEN '취소'                           \n");
            sbQuery.Append("       END        V_APP_STATUS    , -- 결재상태                         \n");
            sbQuery.Append("       A.APP_STATUS         V_APP_STATUS_CD     , -- 결재상태 코드      \n");
            sbQuery.Append("       A.APP_DATE           V_APP_DATE          , -- 결재일시           \n");
            sbQuery.Append("       A.APP_REMARK         V_APP_REMARK          -- 취소사유           \n");
            sbQuery.Append("  FROM COM_APPROVAL_PRC A,                                              \n");
            sbQuery.Append("       (                                                                \n");
            sbQuery.Append("        SELECT                                                          \n");
            sbQuery.Append("               A.EMP_REF_ID,                                            \n");
            sbQuery.Append("               A.EMP_NAME,                                              \n");
            sbQuery.Append("               D.POSITION_DUTY_NAME,                                    \n");
            sbQuery.Append("               B.DEPT_NAME                                              \n");
            sbQuery.Append("          FROM COM_EMP_INFO    A,    -- 사용자 테이블                   \n");
            sbQuery.Append("               COM_DEPT_INFO   B,    -- 부서 테이블                     \n");
            sbQuery.Append("               REL_DEPT_EMP    C,    -- 사용자, 부서코드 연결 테이블    \n");
            sbQuery.Append("               COM_POSITION_DUTY D   -- 직책테이블                      \n");
            sbQuery.Append("         WHERE A.EMP_REF_ID = C.EMP_REF_ID                              \n");
            sbQuery.Append("           AND C.DEPT_REF_ID= B.DEPT_REF_ID                             \n");
            sbQuery.Append("           AND D.POSITION_DUTY_CODE = A.POSITION_DUTY_CODE              \n");
            sbQuery.Append("       ) B                                                              \n");
            sbQuery.Append(" WHERE A.APP_EMP_ID = B.EMP_REF_ID                                      \n");
            sbQuery.Append("   AND A.APP_REF_ID = @APP_REF_ID                                       \n");
            sbQuery.Append(" ORDER BY                                                               \n");
            sbQuery.Append("       APP_STEP                                                         \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// SetKPIInfoApproval
        ///     : KPI_INFO테이블 승인처리
        /// </summary>
        /// <param name="asKpiRefID"></param>
        /// <returns></returns>
        public int SetKPIInfoApproval(string asKpiRefID, int aiStatus)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE KPI_INFO                                 \n");
            sbQuery.Append("   SET CONFIRMSTATUS = @CONFIRMSTATUS           \n");
            sbQuery.Append(" WHERE KPI_REF_ID = CONVERT(INT, @KPI_REF_ID)   \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@CONFIRMSTATUS",  SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID",     SqlDbType.VarChar);

            paramArray[0].Value = aiStatus;
            paramArray[1].Value = asKpiRefID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// SetKPIResultApproval
        ///     : KPI_RESULT테이블 승인처리
        /// </summary>
        /// <param name="asKpiRefID"></param>
        /// <param name="asTmCode"></param>
        /// <returns></returns>
        public int SetKPIResultApproval(string asKpiRefID, string asTmCode, int aiStatus)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE KPI_RESULT                               \n");
            sbQuery.Append("   SET CONFIRMSTATUS = @CONFIRMSTATUS           \n");
            sbQuery.Append(" WHERE KPI_REF_ID = CONVERT(INT, @KPI_REF_ID)   \n");
            sbQuery.Append("   AND TMCODE     = CONVERT(INT, @TMCODE)       \n");

            paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@CONFIRMSTATUS",  SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID",     SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@TMCODE",         SqlDbType.VarChar);

            paramArray[0].Value = aiStatus;
            paramArray[1].Value = asKpiRefID;
            paramArray[2].Value = asTmCode;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// ConfirmRemainStep
        ///     : 현재 처리하려는 문서 이후로 몇건의 결재문서가 남아 있는가?
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asTermRefID"></param>
        /// <returns></returns>
        public int ConfirmRemainStep(string asAppRefID, string asTermRefID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT (C.MAX_APP_STEP - B.APP_STEP) V_REMAIN_STEP  \n");
            sbQuery.Append("  FROM COM_APPROVAL_INFO    A,                      \n");
            sbQuery.Append("       COM_APPROVAL_PRC     B,                      \n");
            sbQuery.Append("       (                                            \n");
            sbQuery.Append("       SELECT BIZ_TYPE_CODE,                        \n");
            sbQuery.Append("              MAX(APP_STEP) MAX_APP_STEP            \n");
            sbQuery.Append("         FROM COM_APPROVAL_LINE                     \n");
            sbQuery.Append("        GROUP BY                                    \n");
            sbQuery.Append("              BIZ_TYPE_CODE                         \n");
            sbQuery.Append("       ) C                                          \n");
            sbQuery.Append(" WHERE 1=1                                          \n");
            sbQuery.Append("   AND A.APP_REF_ID     = B.APP_REF_ID              \n");
            sbQuery.Append("   AND A.CUR_APP_STEP   = B.APP_STEP                \n");
            sbQuery.Append("   AND A.APP_CODE       = C.BIZ_TYPE_CODE           \n");
            sbQuery.Append("   AND A.APP_REF_ID     = @APP_REF_ID               \n");
            sbQuery.Append("   AND A.APPTERM_REF_ID = CONVERT(INT, @TERM_REF_ID)    \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@APP_REF_ID",     SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@TERM_REF_ID",    SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asTermRefID;

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(sbQuery.ToString(), paramArray));
        }

        /// <summary>
        /// SetInfoApproval
        ///     : 결재정보 테이블 승인완료 처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asTermRefID"></param>
        /// <param name="aiRemain"></param>
        /// <returns></returns>
        public int SetInfoApproval(string asAppRefID, string asTermRefID, int aiRemain)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_APPROVAL_INFO                \n");
            sbQuery.Append("   SET                                  \n");

            if (aiRemain > 0)
                sbQuery.Append("       CUR_APP_STEP = CUR_APP_STEP + 1  \n");
            else
            {
                sbQuery.Append("       APP_STATUS   = 'E'               \n");
                sbQuery.Append("      ,APP_COMPDATE = GETDATE()         \n");
            }

            sbQuery.Append(" WHERE 1=1                              \n");
            sbQuery.Append("   AND APP_REF_ID     = @APP_REF_ID     \n");
            sbQuery.Append("   AND APPTERM_REF_ID = CONVERT(INT, @TERM_REF_ID)    \n");  

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@TERM_REF_ID",SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asTermRefID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);

        }

        /// <summary>
        /// SetInfoCancel
        ///     : 결재정보 테이블 승인취소 처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asTermRefID"></param>
        /// <param name="aiRemain"></param>
        /// <returns></returns>
        public int SetInfoCancel(string asAppRefID, string asTermRefID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_APPROVAL_INFO                \n");
            sbQuery.Append("   SET                                  \n");
            sbQuery.Append("       APP_STATUS = 'C'                 \n");
            sbQuery.Append(" WHERE 1=1                              \n");
            sbQuery.Append("   AND APP_REF_ID     = @APP_REF_ID     \n");
            sbQuery.Append("   AND APPTERM_REF_ID = CONVERT(INT, @TERM_REF_ID)    \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@TERM_REF_ID", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asTermRefID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// SetInfoRepCancel
        ///     : 결재정보 테이블 상신취소 처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <returns></returns>
        public int SetInfoRepCancel(string asAppRefID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("DELETE                          \n");
            sbQuery.Append("  FROM COM_APPROVAL_INFO        \n");
            sbQuery.Append(" WHERE APP_REF_ID = @APP_REF_ID \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// SetInfoRep
        ///     : 결재정보 테이블 상신 처리
        /// </summary>
        /// <param name="asKpiRefID"></param>
        /// <param name="asAppRefID"></param>
        /// <param name="asEventAddID"></param>
        /// <param name="asAppCode"></param>
        /// <param name="asRepEmpID"></param>
        /// <param name="asTermRefID"></param>
        /// <returns></returns>
        public int SetInfoRep(
                                string asKpiRefID 
                               ,string asAppRefID
                               ,string asEventAddID
                               ,string asAppCode
                               ,string asRepEmpID
                               ,string asTermRefID
                             )
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            string sRepTitle = "";
            string sEventAddID = "";

            if (asAppCode == "KPIINF")
            {
                sRepTitle = "KPI 정의서 결재를 바랍니다.";
                sEventAddID = "";
            }
            else if (asAppCode == "KPIRST")
            {
                sRepTitle = asEventAddID + "월 KPI 실적 결재를 바랍니다.";
                sEventAddID = asEventAddID;
            }
            else
            {
                return 0;
            }

            sbQuery.Append("INSERT INTO COM_APPROVAL_INFO                                                           \n");
            sbQuery.Append("    (                                                                                   \n");
            sbQuery.Append("    APP_REF_ID      , EVENT_ID      , EVENT_ADD_ID  ,                                   \n");
            sbQuery.Append("    APP_CODE        , REP_EMP_ID    , APP_STATUS    ,                                   \n");
            sbQuery.Append("    CUR_APP_STEP    , REP_TITLE     , REP_DESC      ,                                   \n");
            sbQuery.Append("    REP_DATE        , APPTERM_REF_ID                                                    \n");
            sbQuery.Append("    )                                                                                   \n");
            sbQuery.Append("SELECT @APP_REF_ID  , KPI_REF_ID        , @EVENT_ADD_ID                 ,   \n");
            sbQuery.Append("       @APP_CODE    , CONVERT(INT, @REP_EMP_ID)       , 'P'                           ,   \n");
            sbQuery.Append("       1            , @REP_TITLE        , KPI_CODE + ' : ' + KPI_NAME   ,   \n");
            sbQuery.Append("       GETDATE(), CONVERT(INT, @APPTERM_REF_ID)                                                       \n");
            sbQuery.Append("  FROM KPI_INFO                                                                         \n");
            sbQuery.Append(" WHERE KPI_REF_ID = @KPI_REF_ID                                                         \n");

            paramArray = CreateDataParameters(7);
            paramArray[0] = CreateDataParameter("@APP_REF_ID",     SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@EVENT_ADD_ID",   SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@APP_CODE",       SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@REP_EMP_ID",     SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@REP_TITLE",      SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@APPTERM_REF_ID", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@KPI_REF_ID",     SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = sEventAddID;
            paramArray[2].Value = asAppCode;
            paramArray[3].Value = asRepEmpID;
            paramArray[4].Value = sRepTitle;
            paramArray[5].Value = asTermRefID;
            paramArray[6].Value = asKpiRefID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// SetPrcApproval
        ///     : 결재정보 히스토리테이블 승인처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asAppStep"></param>
        /// <returns></returns>
        public int SetPrcApproval(string asAppRefID, string asAppStep)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_APPROVAL_PRC                     \n");
            sbQuery.Append("   SET APP_STATUS = 'E'                     \n");
            sbQuery.Append("      ,APP_DATE   = GETDATE()               \n");
            sbQuery.Append(" WHERE 1=1                                  \n");
            sbQuery.Append("   AND APP_REF_ID = @APP_REF_ID             \n");
            sbQuery.Append("   AND APP_STEP   = CONVERT(INT, @APP_STEP) \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@APP_STEP", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asAppStep;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);

        }

        /// <summary>
        /// SetPrcCancel
        ///     : 결재정보 히스토리테이블 승인취소처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asAppStep"></param>
        /// <returns></returns>
        public int SetPrcCancel(string asRemark, string asAppRefID, string asAppStep)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_APPROVAL_PRC                     \n");
            sbQuery.Append("   SET APP_STATUS = 'C'                     \n");
            sbQuery.Append("      ,APP_DATE   = GETDATE()               \n");
            sbQuery.Append("      ,APP_REMARK = @APP_REMARK             \n");
            sbQuery.Append(" WHERE 1=1                                  \n");
            sbQuery.Append("   AND APP_REF_ID = @APP_REF_ID             \n");
            sbQuery.Append("   AND APP_STEP   = CONVERT(INT, @APP_STEP) \n");

            paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@APP_STEP",   SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@APP_REMARK", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asAppStep;
            paramArray[2].Value = asRemark;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// SetPrcRepCancel
        ///     : 결재정보 히스토리테이블 상신취소처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <returns></returns>
        public int SetPrcRepCancel(string asAppRefID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("DELETE                          \n");
            sbQuery.Append("  FROM COM_APPROVAL_PRC         \n");
            sbQuery.Append(" WHERE APP_REF_ID = @APP_REF_ID \n");  

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// SetPrcRep
        ///     : 결재정보 히스토리테이블 상신처리
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asAppStep"></param>
        /// <param name="asAppEmpID"></param>
        /// <returns></returns>
        public int SetPrcRep(string asAppRefID, string asAppStep, string asAppEmpID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("INSERT INTO COM_APPROVAL_PRC            \n");
            sbQuery.Append("    (                                   \n");
            sbQuery.Append("    APP_REF_ID, APP_STEP, APP_STATUS,   \n");
            sbQuery.Append("    APP_EMP_ID                          \n");
            sbQuery.Append("    )                                   \n");
            sbQuery.Append("VALUES                                  \n");
            sbQuery.Append("    (                                   \n");
            sbQuery.Append("    @APP_REF_ID, CONVERT(INT, @APP_STEP), 'P',        \n");
            sbQuery.Append("    CONVERT(INT, @APP_EMP_ID)                         \n");
            sbQuery.Append("    )                                   \n");

            paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@APP_STEP",   SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@APP_EMP_ID", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asAppStep;
            paramArray[2].Value = asAppEmpID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetApprovalLine
        ///     : 결재선 리턴
        /// </summary>
        /// <param name="asBizType"></param>
        /// <param name="asRepEmpID"></param>
        /// <returns></returns>
        public DataSet GetApprovalLine(string asAppCode, string asRepEmpID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT APP_STEP ,                       \n");
            sbQuery.Append("       APP_EMP_ID                       \n");
            sbQuery.Append("  FROM COM_APPROVAL_LINE                \n");
            sbQuery.Append(" WHERE 1=1                              \n");
            sbQuery.Append("   AND BIZ_TYPE_CODE = @BIZ_TYPE_CODE   \n");
            sbQuery.Append("   AND REP_EMP_ID    = @REP_EMP_ID      \n");
            sbQuery.Append(" ORDER BY                               \n");
            sbQuery.Append("       APP_STEP                         \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@BIZ_TYPE_CODE",  SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@REP_EMP_ID",     SqlDbType.VarChar);

            paramArray[0].Value = asAppCode;
            paramArray[1].Value = asRepEmpID;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetKPIApprovalInfo
        ///     : KPI_REF_ID가 포함된 결재관련 정보 리턴
        /// </summary>
        /// <param name="asKpiRefID"></param>
        /// <returns></returns>
        public DataSet GetKPIApprovalInfo(string asKpiRefID, string asAppCode, string asMonthInfo)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT                                                      \n");
            sbQuery.Append("       DBO.FN_GETAPPSTATUS(CONVERT(INT, @KPI_REF_ID), @APP_CODE, @MONTH_INFO)   V_APP_STATUS   -- 전체결재상태   \n");
            sbQuery.Append("      ,(SELECT MAX(CHAMPION_EMP_ID) FROM KPI_INFO WHERE KPI_REF_ID = CONVERT(INT, @KPI_REF_ID)) V_CHAM_EMP_ID  -- 챔피언       \n");
            sbQuery.Append("      ,COUNT(A.APP_STATUS) V_CNT                            \n");
            sbQuery.Append("  FROM COM_APPROVAL_INFO A, -- 결재정보                     \n");
            sbQuery.Append("       COM_APPROVAL_PRC  B, -- 결재 HISTORY 정보            \n");
            sbQuery.Append("       COM_EMP_INFO      C, -- 상신자 정보                  \n");
            sbQuery.Append("       COM_EMP_INFO      D, -- 결재자 정보                  \n");
            sbQuery.Append("       COM_BIZ_INFO      E, -- 결재타입 정보                \n");
            sbQuery.Append("       (                                                    \n");
            sbQuery.Append("       SELECT BIZ_TYPE_CODE,                                \n");
            sbQuery.Append("              MAX(APP_STEP) MAX_APP_STEP                    \n");
            sbQuery.Append("         FROM COM_APPROVAL_LINE                             \n");
            sbQuery.Append("        GROUP BY                                            \n");
            sbQuery.Append("              BIZ_TYPE_CODE                                 \n");
            sbQuery.Append("       ) F  -- 결재선 정보                                  \n");
            sbQuery.Append(" WHERE 1=1                                                  \n");
            sbQuery.Append("   AND A.APP_REF_ID    = B.APP_REF_ID                       \n");
            sbQuery.Append("   AND A.CUR_APP_STEP  = B.APP_STEP                         \n");
            sbQuery.Append("   AND A.REP_EMP_ID    = C.EMP_REF_ID                       \n");
            sbQuery.Append("   AND B.APP_EMP_ID    = D.EMP_REF_ID                       \n");
            sbQuery.Append("   AND A.APP_CODE      = E.BIZ_TYPE_CODE                    \n");
            sbQuery.Append("   AND E.BIZ_TYPE_CODE = F.BIZ_TYPE_CODE                    \n");
            sbQuery.Append("   AND A.EVENT_ID      = CONVERT(INT, @KPI_REF_ID)          \n");
            sbQuery.Append("   AND A.APP_CODE      = @APP_CODE                          \n");

            paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@KPI_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@APP_CODE",   SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@MONTH_INFO", SqlDbType.VarChar);
            
            paramArray[0].Value = asKpiRefID;
            paramArray[1].Value = asAppCode;
            paramArray[2].Value = asMonthInfo;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetKPIStatus
        ///     : KPI_REF_ID와 월정보를 가지고 KPI실적테이블에서 각 STATUS를 추출한다.
        /// </summary>
        /// <param name="asKpiRefID"></param>
        /// <param name="asMonthInfo"></param>
        /// <returns></returns>
        public DataSet GetKPIStatus(string asKpiRefID, string asMonthInfo)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT ISNULL(CHECKSTATUS, 0) CHECKSTATUS,                      \n");
            sbQuery.Append("       ISNULL(CONFIRMSTATUS, 0) CONFIRMSTATUS,                  \n");
            sbQuery.Append("       V_CNT                                                    \n");
            sbQuery.Append("  FROM (                                                        \n");
            sbQuery.Append("       SELECT MAX(CONVERT (INT, CHECKSTATUS)) CHECKSTATUS,      \n");
            sbQuery.Append("              MAX(CONVERT (INT, CONFIRMSTATUS)) CONFIRMSTATUS,  \n");
            sbQuery.Append("              COUNT(*) V_CNT                                    \n");
            sbQuery.Append("         FROM KPI_RESULT                                        \n");
            sbQuery.Append("        WHERE KPI_REF_ID= CONVERT(INT, @KPI_REF_ID)             \n");
            sbQuery.Append("          AND TMCODE    = CONVERT(INT, @TMCODE)                 \n");
            sbQuery.Append("       ) A                                                      \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@KPI_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@TMCODE",     SqlDbType.VarChar);

            paramArray[0].Value = asKpiRefID;
            paramArray[1].Value = asMonthInfo;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetDSReportMailInfo
        ///     : 상신시에 메일링 처리할 내용을 리턴한다.
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <returns></returns>
        public DataSet GetDSReportMailInfo(string asAppRefID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT D.KPI_CODE + ' (' + D.KPI_NAME + ')'  V_KPIINFO,  \n");
            sbQuery.Append("       E.EMP_NAME   V_REP_EMP_NAME,                      \n");
            sbQuery.Append("       E.EMP_EMAIL  V_REP_EMP_EMAIL,                     \n");
            sbQuery.Append("       F.EMP_EMAIL  V_APP_EMP_EMAIL                      \n");
            sbQuery.Append("  FROM COM_APPROVAL_INFO A,                              \n");
            sbQuery.Append("       COM_APPROVAL_PRC  B,                              \n");
            sbQuery.Append("       KPI_INFO          D,                              \n");
            sbQuery.Append("       COM_EMP_INFO      E,                              \n");
            sbQuery.Append("       COM_EMP_INFO      F                               \n");
            sbQuery.Append(" WHERE A.APP_REF_ID = B.APP_REF_ID                       \n");
            sbQuery.Append("   AND B.APP_STEP   = 1                                  \n");
            sbQuery.Append("   AND D.KPI_REF_ID = A.EVENT_ID                         \n");
            sbQuery.Append("   AND E.EMP_REF_ID = A.REP_EMP_ID                       \n");
            sbQuery.Append("   AND F.EMP_REF_ID = B.APP_EMP_ID                       \n");
            sbQuery.Append("   AND A.APP_REF_ID = @APP_REF_ID                        \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[0].Value = asAppRefID;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetDSApprovalMailInfo
        ///     : 결재시에 메일링 처리할 내용을 리턴한다.
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asAppStep"></param>
        /// <returns></returns>
        public DataSet GetDSApprovalMailInfo(string asAppRefID, string asAppStep)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT D.KPI_CODE + ' (' + D.KPI_NAME + ')'  V_KPIINFO,  \n");
            sbQuery.Append("       F.EMP_NAME   V_APP_EMP_NAME,                                        \n");
            sbQuery.Append("       F.EMP_EMAIL  V_APP_EMP_EMAIL,                                       \n");
            sbQuery.Append("       E.EMP_EMAIL  V_REP_EMP_EMAIL                                       \n");
            sbQuery.Append("  FROM COM_APPROVAL_INFO A,                              \n");
            sbQuery.Append("       COM_APPROVAL_PRC  B,                              \n");
            sbQuery.Append("       KPI_INFO          D,                              \n");
            sbQuery.Append("       COM_EMP_INFO      E,                              \n");
            sbQuery.Append("       COM_EMP_INFO      F                               \n");
            sbQuery.Append(" WHERE A.APP_REF_ID = B.APP_REF_ID                       \n");
            sbQuery.Append("   AND B.APP_STEP   = CONVERT(INT,@APP_STEP)             \n");
            sbQuery.Append("   AND D.KPI_REF_ID = A.EVENT_ID                         \n");
            sbQuery.Append("   AND E.EMP_REF_ID = A.REP_EMP_ID                       \n");
            sbQuery.Append("   AND F.EMP_REF_ID = B.APP_EMP_ID                       \n");
            sbQuery.Append("   AND A.APP_REF_ID = @APP_REF_ID                        \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@APP_STEP",   SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asAppStep;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetDSCancelMailInfo
        ///     : 취소시에 메일링 처리할 내용을 리턴한다.
        /// </summary>
        /// <param name="asAppRefID"></param>
        /// <param name="asAppStep"></param>
        /// <returns></returns>
        public DataSet GetDSCancelMailInfo(string asAppRefID, string asAppStep)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT D.KPI_CODE + ' (' + D.KPI_NAME + ')'  V_KPIINFO,  \n");
            sbQuery.Append("       F.EMP_NAME     V_APP_EMP_NAME,                    \n");
            sbQuery.Append("       F.EMP_EMAIL    V_APP_EMP_EMAIL,                   \n");
            sbQuery.Append("       E.EMP_EMAIL    V_REP_EMP_EMAIL                    \n");
            sbQuery.Append("  FROM COM_APPROVAL_INFO A,                              \n");
            sbQuery.Append("       COM_APPROVAL_PRC  B,                              \n");
            sbQuery.Append("       KPI_INFO          D,                              \n");
            sbQuery.Append("       COM_EMP_INFO      E,                              \n");
            sbQuery.Append("       COM_EMP_INFO      F                               \n");
            sbQuery.Append(" WHERE A.APP_REF_ID = B.APP_REF_ID                       \n");
            sbQuery.Append("   AND B.APP_STEP   = CONVERT(INT,@APP_STEP)             \n");
            sbQuery.Append("   AND D.KPI_REF_ID = A.EVENT_ID                         \n");
            sbQuery.Append("   AND E.EMP_REF_ID = A.REP_EMP_ID                       \n");
            sbQuery.Append("   AND F.EMP_REF_ID = B.APP_EMP_ID                       \n");
            sbQuery.Append("   AND A.APP_REF_ID = @APP_REF_ID                        \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@APP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@APP_STEP", SqlDbType.VarChar);

            paramArray[0].Value = asAppRefID;
            paramArray[1].Value = asAppStep;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }
    }
}
