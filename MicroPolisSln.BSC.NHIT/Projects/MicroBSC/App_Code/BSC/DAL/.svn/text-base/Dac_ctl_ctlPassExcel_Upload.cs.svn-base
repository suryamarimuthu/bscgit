using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    /// <summary>
    /// Dac_ctl_ctlPassExcel_Upload에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_ctl_ctlPassExcel_Upload Dac 클래스
    /// Class 내용		: ctlPassExcel_Upload 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.07.05
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_ctl_ctlPassExcel_Upload : DbAgentBase
    {
        /// <summary>
        /// GetExcelData
        ///     : Upload할 엑셀파일을 DataSet으로 리턴
        /// </summary>
        /// <param name="asFilePath"></param>
        /// <returns></returns>
        public DataSet GetExcelData(string asFilePath)
        {
            _excelAgent.FilePath = asFilePath;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT              \n");
            sbQuery.Append("       *            \n");
            sbQuery.Append("  FROM [" + _excelAgent.GetFirstSheet() + "] \n");

            return _excelAgent.Fill(sbQuery.ToString());
        }

        /// <summary>
        /// SetExcelUpdate
        ///     : 비밀번호 업데이트
        /// </summary>
        /// <returns></returns>
        public int SetExcelUpdate(string asLoginID, string asPassWD)
        {
            IDbDataParameter[] paramArray = null;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("UPDATE COM_EMP_INFO         \n");
            sbQuery.Append("   SET PASSWD   = @PASSWD   \n");
            sbQuery.Append(" WHERE LOGINID  = @LOGINID  \n");

            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@PASSWD",     SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@LOGINID",    SqlDbType.VarChar);

            paramArray[0].Value = asPassWD;
            paramArray[1].Value = asLoginID;

            return DbAgentObj.ExecuteNonQuery(sbQuery.ToString(), paramArray);
        }
    }
}
