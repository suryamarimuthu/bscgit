using System;
using System.Web;
using System.Data;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    /// <summary>
    /// Dac_Base_FileUpload에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_Base_FileUpload Dac 클래스
    /// Class 내용		: FileUpload 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.06.19
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_Base_FileUpload : DbAgentBase
    {
        /// <summary>
        /// COM_FILE_ATTACH테이블에 파일정보 추가
        /// </summary>
        /// <param name="psaFileInfo"></param>
        /// <returns></returns>
        public int AddFileInfo(string[,] psaFileInfo)
        {
            int iRet = 0;

            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("INSERT INTO COM_FILE_ATTACH                     \n");
            sbQuery.Append("    (                                           \n");
            sbQuery.Append("    ATTACH_NO   , SER_NO    , V_FILENAME    ,   \n");
            sbQuery.Append("    V_FILESIZE  , P_FILESIZE, P_FULLPATH        \n");
            sbQuery.Append("    )                                           \n");

            sbQuery.Append("SELECT                                          \n");
            sbQuery.Append("    @ATTACH_NO , ISNULL(MAX(SER_NO), 0)+1   , @V_FILENAME   ,   \n");
            sbQuery.Append("    @V_FILESIZE ,@P_FILESIZE, @P_FULLPATH       \n");
            sbQuery.Append("  FROM COM_FILE_ATTACH                          \n");
            sbQuery.Append(" WHERE ATTACH_NO  = @ATTACH_NO                  \n");

            paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@ATTACH_NO", SqlDbType.VarChar);
            paramArray[0].Value = psaFileInfo[0, 0];

            paramArray[1] = CreateDataParameter("@V_FILENAME", SqlDbType.VarChar);
            paramArray[1].Value = psaFileInfo[1, 0];

            paramArray[2] = CreateDataParameter("@V_FILESIZE", SqlDbType.VarChar);
            paramArray[2].Value = psaFileInfo[2, 0];

            paramArray[3] = CreateDataParameter("@P_FILESIZE", SqlDbType.VarChar);
            paramArray[3].Value = psaFileInfo[3, 0];

            paramArray[4] = CreateDataParameter("@P_FULLPATH", SqlDbType.VarChar);
            paramArray[4].Value = psaFileInfo[4, 0];

            iRet = DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray, CommandType.Text);

            return iRet;
        }

        /// <summary>
        /// SER_NO추출
        ///     : 지워진 파일정보 이후로 순번을 재조정해야 하고 
        ///     : 현재 ser_no가 pk이기 때문에 삭제후 재조정을 위해 추출한다.
        /// </summary>
        /// <param name="psAttachNo"></param>
        /// <param name="psFullFileName"></param>
        /// <returns></returns>
        public int GetDelFileInfo(string psAttachNo, string psFullFileName)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT SER_NO                   \n");
            sbQuery.Append("  FROM COM_FILE_ATTACH          \n");
            sbQuery.Append(" WHERE ATTACH_NO = @ATTACHNO    \n");
            sbQuery.Append("   AND P_FULLPATH= @FULLPATH    \n");

            paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ATTACHNO", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@FULLPATH", SqlDbType.VarChar);

            paramArray[0].Value = psAttachNo;
            paramArray[1].Value = psFullFileName;

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(sbQuery.ToString(), paramArray, CommandType.Text));
        }

        /// <summary>
        /// ICM_FILE에서 파일정보 삭제
        /// </summary>
        /// <param name="psAttachNo"></param>
        /// <param name="piSerNo"></param>
        /// <returns></returns>
        public int DelFileInfo(string psAttachNo, int piSerNo)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("DELETE COM_FILE_ATTACH          \n");
            sbQuery.Append(" WHERE ATTACH_NO = @ATTACHNO    \n");
            sbQuery.Append("   AND SER_NO    = @SER_NO      \n");

            paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ATTACHNO", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@SER_NO", SqlDbType.Int);

            paramArray[0].Value = psAttachNo;
            paramArray[1].Value = piSerNo;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray, CommandType.Text);

        }

        /// <summary>
        /// ICM_FILE에서 그룹핑된 파일들중 삭제되는 파일 이후 순위 조정
        /// </summary>
        /// <param name="psAttachNo"></param>
        /// <param name="piSerNo"></param>
        /// <returns></returns>
        public int UpdateFileSerNo(string psAttachNo, int piSerNo)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_FILE_ATTACH          \n");
            sbQuery.Append("   SET SER_NO = SER_NO-1        \n");
            sbQuery.Append(" WHERE ATTACH_NO = @ATTACHNO    \n");
            sbQuery.Append("   AND SER_NO    > @SER_NO      \n");

            paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@ATTACHNO", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@SER_NO", SqlDbType.Int);

            paramArray[0].Value = psAttachNo;
            paramArray[1].Value = piSerNo;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray, CommandType.Text);
        }

        /// <summary>
        /// 업로드된 정보 추출
        /// </summary>
        /// <param name="asAttachNo"></param>
        /// <returns></returns>
        public DataSet GetFileUploaded(string asAttachNo)
        {
            IDbDataParameter[] paramArray = null;

            string strSQL = @"SELECT SER_NO, V_FILENAME + ' (' + V_FILESIZE + ')' V_FILETEXT, P_FULLPATH V_FILEVALUE, P_FILESIZE
                                FROM COM_FILE_ATTACH
                               WHERE ATTACH_NO = @ATTACH_NO
                               ORDER BY SER_NO
                            ";
            string strORA = @"SELECT SER_NO, V_FILENAME || ' (' || V_FILESIZE || ')' V_FILETEXT, P_FULLPATH V_FILEVALUE, P_FILESIZE
                                FROM COM_FILE_ATTACH
                               WHERE ATTACH_NO = @ATTACH_NO
                               ORDER BY SER_NO
                            ";

            paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@ATTACH_NO", SqlDbType.VarChar, 25);
            paramArray[0].Value = (asAttachNo == null ? "" : asAttachNo);

            return DbAgentObj.FillDataSet(GetQueryStringByDb(strSQL, strORA), "COM_FILE_ATTACH", null, paramArray, CommandType.Text);
        }

        /// <summary>
        /// 문서 및 각 테이블의 주요키 리턴
        /// </summary>
        /// <param name="psPre"></param>
        /// <returns></returns>
        public string GetAttachNo(string psPrefix)
        {
            IDbDataParameter[] paramArray = null;

            string strSQL = "SELECT dbo.fn_GetAttachNo(@sPREFIX, GETDATE())";
            string strORA = "SELECT fn_GetAttachNo(@sPREFIX) FROM DUAL";
            
            paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@sPREFIX", SqlDbType.VarChar);
            paramArray[0].Value = psPrefix;

            return (string)DbAgentObj.ExecuteScalar(GetQueryStringByDb(strSQL, strORA), paramArray, CommandType.Text);
        }

        
    }
}
