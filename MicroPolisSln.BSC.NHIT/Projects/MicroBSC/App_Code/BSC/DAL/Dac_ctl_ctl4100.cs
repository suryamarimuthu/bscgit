using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    /// <summary>
    /// Dac_ctl_ctl4100에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_ctl_ctl4100 Dac 클래스
    /// Class 내용		: ctl4100 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.08
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_ctl_ctl4100 : DbAgentBase
    {
        /// <summary>
        /// GetSearchData
        ///     : 평가등급 관리 검색
        /// </summary>
        /// <param name="asType"></param>
        /// <returns></returns>
        public DataSet GetSearchData(string asType)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT KPI_THRESHOLD_CODE_ID    V_CODE_ID   ,       \n");
            sbQuery.Append("       KPI_THRESHOLD_TYPE       V_TYPE      ,       \n");
            sbQuery.Append("       KPI_THRESHOLD_STEPNAME   V_STEPNAME  ,       \n");
            sbQuery.Append("       BASE_MIN_VALUE           V_MIN_VALUE ,       \n");
            sbQuery.Append("       MARK_COLOR               V_COLOR     ,       \n");
            sbQuery.Append("       MARK_IMAGE_PATH          V_IMG_PATH  ,       \n");
            sbQuery.Append("       POINT                    V_POINT     ,       \n");
            sbQuery.Append("       SEQUENCE                                     \n");
            sbQuery.Append("  FROM COM_KPI_THRESHOLD_CODE                       \n");
            sbQuery.Append(" WHERE 1=1                                          \n");
            sbQuery.Append("   AND KPI_THRESHOLD_TYPE = @KPI_THRESHOLD_TYPE     \n");
            sbQuery.Append(" ORDER BY                                           \n");
            sbQuery.Append("       SEQUENCE                                     \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@KPI_THRESHOLD_TYPE", SqlDbType.VarChar);

            paramArray[0].Value = asType;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetSearchCode
        ///     : 평가등급 수정시 검색
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public DataSet GetSearchCode(string asCodeID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT KPI_THRESHOLD_CODE_ID    V_CODE_ID   ,       \n");
            sbQuery.Append("       KPI_THRESHOLD_TYPE       V_TYPE      ,       \n");
            sbQuery.Append("       KPI_THRESHOLD_STEPNAME   V_STEPNAME  ,       \n");
            sbQuery.Append("       BASE_MIN_VALUE           V_MIN_VALUE ,       \n");
            sbQuery.Append("       MARK_COLOR               V_COLOR     ,       \n");
            sbQuery.Append("       MARK_IMAGE_PATH          V_IMG_PATH  ,       \n");
            sbQuery.Append("       POINT                    V_POINT     ,       \n");
            sbQuery.Append("       SEQUENCE                                     \n");
            sbQuery.Append("  FROM COM_KPI_THRESHOLD_CODE                       \n");
            sbQuery.Append(" WHERE 1=1                                          \n");
            sbQuery.Append("   AND KPI_THRESHOLD_CODE_ID = CONVERT(int, @KPI_THRESHOLD_CODE_ID)     \n");
            sbQuery.Append(" ORDER BY                                           \n");
            sbQuery.Append("       SEQUENCE                                     \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@KPI_THRESHOLD_CODE_ID", SqlDbType.VarChar);

            paramArray[0].Value = asCodeID;

            return DbAgentObj.Fill(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// GetAllType
        ///     : 측정단계 드롭다운리스트 추출
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllType()
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT DISTINCT                                                     \n");
            sbQuery.Append("       CONVERT(VARCHAR,KPI_THRESHOLD_TYPE) + ' 단계' V_TYPE_NAME,   \n");
            sbQuery.Append("       KPI_THRESHOLD_TYPE V_TYPE                                    \n");
            sbQuery.Append("  FROM COM_KPI_THRESHOLD_CODE                                       \n");
            sbQuery.Append(" ORDER BY                                                           \n");
            sbQuery.Append("       KPI_THRESHOLD_TYPE                                           \n");

            return DbAgentObj.Fill(sbQuery.ToString());
        }

        /// <summary>
        /// DelThreshold
        ///     : 평가등급 관리 삭제
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public int DelThreshold(string asCodeID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("DELETE COM_KPI_THRESHOLD_CODE                                       \n");
            sbQuery.Append(" WHERE KPI_THRESHOLD_CODE_ID = CONVERT(INT, @KPI_THRESHOLD_CODE_ID) \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@KPI_THRESHOLD_CODE_ID",  SqlDbType.VarChar);

            paramArray[0].Value = asCodeID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// DelThresholdInfo
        ///     : 기 설정된 THRESHOLD정보 삭제
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public int DelThresholdInfo(string asCodeID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("DELETE KPI_THRESHOLD_INFO                                           \n");
            sbQuery.Append(" WHERE KPI_THRESHOLD_CODE_ID = CONVERT(INT, @KPI_THRESHOLD_CODE_ID) \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@KPI_THRESHOLD_CODE_ID",  SqlDbType.VarChar);

            paramArray[0].Value = asCodeID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// UpdateThresholdSeq
        ///     : 평가등급 삭제 이전에 시퀀스 조정
        ///     : 항상 정해진 순서로 들어가야 하므로 현재처럼 조정한후 삭제하도록 한다.
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <returns></returns>
        public int UpdateThresholdSeq(string asCodeID)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_KPI_THRESHOLD_CODE                                                                   \n");
            sbQuery.Append("   SET SEQUENCE = SEQUENCE - 1                                                                  \n");
            sbQuery.Append(" WHERE KPI_THRESHOLD_CODE_ID IN                                                                 \n");
            sbQuery.Append("                    (                                                                           \n");
            sbQuery.Append("                    SELECT A.KPI_THRESHOLD_CODE_ID                                              \n");
            sbQuery.Append("                      FROM COM_KPI_THRESHOLD_CODE A,                                            \n");
            sbQuery.Append("                           (                                                                    \n");
            sbQuery.Append("                            SELECT KPI_THRESHOLD_TYPE,                                          \n");
            sbQuery.Append("                                   SEQUENCE                                                     \n");
            sbQuery.Append("                              FROM COM_KPI_THRESHOLD_CODE                                       \n");
            sbQuery.Append("                             WHERE KPI_THRESHOLD_CODE_ID = CONVERT(INT, @KPI_THRESHOLD_CODE_ID) \n");
            sbQuery.Append("                           ) B                                                                  \n");
            sbQuery.Append("                     WHERE A.KPI_THRESHOLD_TYPE = B.KPI_THRESHOLD_TYPE                          \n");
            sbQuery.Append("                       AND A.SEQUENCE >= B.SEQUENCE                                             \n");
            sbQuery.Append("                    )                                                                           \n");

            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@KPI_THRESHOLD_CODE_ID",  SqlDbType.VarChar);

            paramArray[0].Value = asCodeID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// AddThreshold
        ///     : 평가등급관리 등록
        /// </summary>
        /// <param name="asThresholdType"></param>
        /// <param name="asThresholdName"></param>
        /// <param name="asMinValue"></param>
        /// <param name="asColor"></param>
        /// <param name="asImagePath"></param>
        /// <returns></returns>
        public int AddThreshold(string asThresholdType, string asThresholdName, string asMinValue, string asColor, string asImagePath, string asPoint)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("INSERT INTO COM_KPI_THRESHOLD_CODE                                                              \n");
            sbQuery.Append("    (                                                                                           \n");
            sbQuery.Append("    KPI_THRESHOLD_CODE_ID   , KPI_THRESHOLD_TYPE    , KPI_THRESHOLD_STEPNAME    ,               \n");
            sbQuery.Append("    BASE_MIN_VALUE          , MARK_COLOR            , MARK_IMAGE_PATH           ,               \n");
            sbQuery.Append("    POINT                                                                      ,               \n");
            sbQuery.Append("    SEQUENCE                                                                                    \n");
            sbQuery.Append("    )                                                                                           \n");
            sbQuery.Append("SELECT                                                                                          \n");
            sbQuery.Append("    ISNULL(MAX(KPI_THRESHOLD_CODE_ID),0)+1, @KPI_THRESHOLD_TYPE   , @KPI_THRESHOLD_STEPNAME  , \n");
            sbQuery.Append("    CONVERT(NUMERIC(18, 2), @BASE_MIN_VALUE)          , @MARK_COLOR            , @MARK_IMAGE_PATH           , \n");
            sbQuery.Append("    @POINT                                                                      ,               \n");
            sbQuery.Append("    (                                                                                           \n");
            sbQuery.Append("    SELECT ISNULL(MAX(SEQUENCE), 0)+1  SEQUENCE                                                 \n");
            sbQuery.Append("      FROM COM_KPI_THRESHOLD_CODE                                                               \n");
            sbQuery.Append("     WHERE KPI_THRESHOLD_TYPE = @KPI_THRESHOLD_TYPE                               \n");
            sbQuery.Append("    )                                                                                           \n");
            sbQuery.Append("  FROM COM_KPI_THRESHOLD_CODE                                                                   \n");

            paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@KPI_THRESHOLD_TYPE",     SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@KPI_THRESHOLD_STEPNAME", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@BASE_MIN_VALUE",         SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@MARK_COLOR",             SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@MARK_IMAGE_PATH",        SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@POINT",                  SqlDbType.VarChar);

            paramArray[0].Value = asThresholdType;
            paramArray[1].Value = asThresholdName;
            paramArray[2].Value = asMinValue;
            paramArray[3].Value = asColor;
            paramArray[4].Value = asImagePath;
            paramArray[5].Value = asPoint;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }

        /// <summary>
        /// UpdateThreshold
        ///     : 평가등급관리 수정
        /// </summary>
        /// <param name="asCodeID"></param>
        /// <param name="asThresholdName"></param>
        /// <param name="asMinValue"></param>
        /// <param name="asColor"></param>
        /// <param name="asImagePath"></param>
        /// <returns></returns>
        public int UpdateThreshold(string asCodeID, string asThresholdName, string asMinValue, string asColor, string asImagePath, string asPoint)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_KPI_THRESHOLD_CODE                                               \n");
            sbQuery.Append("   SET KPI_THRESHOLD_STEPNAME   = @KPI_THRESHOLD_STEPNAME                   \n");
            sbQuery.Append("      ,BASE_MIN_VALUE           = CONVERT(NUMERIC(18, 2), @BASE_MIN_VALUE)  \n");
            sbQuery.Append("      ,MARK_COLOR               = @MARK_COLOR                               \n");
            
            if (asImagePath != "")
                sbQuery.Append("      ,MARK_IMAGE_PATH          = @MARK_IMAGE_PATH                          \n");

            sbQuery.Append("      ,POINT               = @POINT                               \n");
            sbQuery.Append(" WHERE KPI_THRESHOLD_CODE_ID = CONVERT(INT, @KPI_THRESHOLD_CODE_ID)         \n");

            paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@KPI_THRESHOLD_CODE_ID",  SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@KPI_THRESHOLD_STEPNAME", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@BASE_MIN_VALUE",         SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@MARK_COLOR",             SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@MARK_IMAGE_PATH",        SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@POINT",                  SqlDbType.VarChar);

            paramArray[0].Value = asCodeID;
            paramArray[1].Value = asThresholdName;
            paramArray[2].Value = asMinValue;
            paramArray[3].Value = asColor;
            paramArray[4].Value = asImagePath;
            paramArray[5].Value = asPoint;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }
    }
}
