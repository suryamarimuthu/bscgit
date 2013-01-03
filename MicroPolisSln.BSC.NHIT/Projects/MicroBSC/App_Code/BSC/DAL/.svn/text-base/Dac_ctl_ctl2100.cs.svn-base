using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// ------------------------------------------------------
/// DATE    : 2007.08.30
/// AUTHOR  : juny177
/// MEMO    : [오라클/MS-SQL] 구문 공통사용을 위한 변경
/// ------------------------------------------------------

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    /// <summary>
    /// Dac_ctl_ctl2100에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_ctl_ctl2100 Dac 클래스
    /// Class 내용		: ctl2100_Role 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.05.26
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_ctl_ctl2100 : DbAgentBase
    {
        /// <summary>
        /// ChgFlagRelDeptInfo
        ///     : 사용자 삭제처리 (플래그변경으로 대체)
        /// </summary>
        /// <param name="asEmpRefID"></param>
        /// <param name="asDeptRefID"></param>
        /// <returns></returns>
        public int ChgFlagRelDeptInfo(string asEmpRefID, string asDeptRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            
            string s_query = @"
                            UPDATE REL_DEPT_EMP
                                SET REL_STATUS = 0
                            WHERE 
                                EMP_REF_ID =    CONVERT(INT,@EMP_REF_ID) 
                                AND DEPT_REF_ID=  CONVERT(INT,@DEPT_REF_ID)
            ";

            string o_query = @"
                            UPDATE REL_DEPT_EMP
                                SET REL_STATUS = 0
                            WHERE 
                                EMP_REF_ID =  TO_NUMBER(@EMP_REF_ID) 
                                AND DEPT_REF_ID=  TO_NUMBER(@DEPT_REF_ID)
            ";

            paramArray[0] = CreateDataParameter("@EMP_REF_ID",     SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID",    SqlDbType.VarChar);

            paramArray[0].Value = asEmpRefID;
            paramArray[1].Value = asDeptRefID;

            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray);
        }

        public int ChgFlagRelBackDeptInfo(string asEmpRefID, string asDeptRefID)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            string s_query = @"
                            UPDATE REL_DEPT_EMP
                                SET REL_STATUS = 1
                            WHERE 
                                EMP_REF_ID =    CONVERT(INT,@EMP_REF_ID) 
                                AND DEPT_REF_ID=  CONVERT(INT,@DEPT_REF_ID)
            ";

            string o_query = @"
                            UPDATE REL_DEPT_EMP
                                SET REL_STATUS = 1
                            WHERE 
                                EMP_REF_ID =  TO_NUMBER(@EMP_REF_ID) 
                                AND DEPT_REF_ID=  TO_NUMBER(@DEPT_REF_ID)
            ";

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.VarChar);

            paramArray[0].Value = asEmpRefID;
            paramArray[1].Value = asDeptRefID;

            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray);
        }
    }
}


