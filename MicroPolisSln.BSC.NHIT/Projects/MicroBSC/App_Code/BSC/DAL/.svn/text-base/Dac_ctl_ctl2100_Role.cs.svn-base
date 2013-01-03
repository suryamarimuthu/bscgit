using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    /// <summary>
    /// Dac_ICM_ICM112에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		: Dac_ctl_ctl2100_Role Dac 클래스
    /// Class 내용		: ctl2100_Role 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.05.26
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_ctl_ctl2100_Role : DbAgentBase
    {
        /// <summary>
        /// GetSearchData
        ///     : 
        /// </summary>
        /// <returns></returns>
        public DataSet GetSearchData(int aiEmpRefID)
        {
            string query = @"
                            SELECT                                 
                                 C.EMP_NAME,                     
                                 C.EMP_REF_ID,                   
                                 B.ROLE_NAME,                    
                                 B.ROLE_REF_ID                   
                            FROM COM_EMP_ROLE_REL A,             
                                 COM_ROLE_INFO    B,             
                                 COM_EMP_INFO     C              
                            WHERE A.ROLE_REF_ID = B.ROLE_REF_ID   
                             AND A.EMP_REF_ID   = C.EMP_REF_ID    
                             AND A.EMP_REF_ID   = @EMP_REF_ID
                            ORDER BY B.SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID",     SqlDbType.Int);

            paramArray[0].Value = aiEmpRefID;

            return DbAgentObj.Fill(query, paramArray);
        }

        public DataSet GetRoleInfo(int aiEmpRefID)
        {
            string query = @"SELECT ROLE_REF_ID
                                 , ROLE_NAME
                                FROM COM_ROLE_INFO                                   
                                    WHERE ROLE_REF_ID NOT IN (SELECT  ROLE_REF_ID                 
                                                                FROM COM_EMP_ROLE_REL
                                                                    WHERE EMP_REF_ID = @EMP_REF_ID)
                                ORDER BY SORT_ORDER";

            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = aiEmpRefID;

            return DbAgentObj.Fill(query, paramArray);
        }

        public string GetEmpName(int aiEmpRefID)
        {
            string query = @"
                            SELECT EMP_NAME                
                            FROM COM_EMP_INFO            
                            WHERE EMP_REF_ID = @EMP_REF_ID
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);

            paramArray[0].Value = aiEmpRefID;

            return DbAgentObj.ExecuteScalar(query, paramArray).ToString();
        }

        public int AddRoleInfo(int aiEmpRefID, int aiRoleRefID)
        {
            string query = @"
                        INSERT INTO COM_EMP_ROLE_REL  
                        (                         
                            EMP_REF_ID,               
                            ROLE_REF_ID               
                        )                         
                        VALUES                        
                        (                         
                            @EMP_REF_ID,              
                            @ROLE_REF_ID              
                        )                         
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID",     SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID",    SqlDbType.Int);

            paramArray[0].Value = aiEmpRefID;
            paramArray[1].Value = aiRoleRefID;

            return DbAgentObj.ExecuteNonQuery(query, paramArray);
        }

        public int DelRoleInfo(int aiEmpRefID, int aiRoleRefID)
        {
            string query = @"
                            DELETE 
                                COM_EMP_ROLE_REL         
                            WHERE 
                                EMP_REF_ID = @EMP_REF_ID 
                            AND 
                                ROLE_REF_ID= @ROLE_REF_ID
            ";


            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);

            paramArray[0].Value = aiEmpRefID;
            paramArray[1].Value = aiRoleRefID;

            return DbAgentObj.ExecuteNonQuery(query, paramArray);
        }


        public int AddRoleInfo(IDbConnection idc
                              , IDbTransaction idt
                              , int aiEmpRefID
                             , int aiRoleRefID)
        {
            string query = @"
                        INSERT INTO COM_EMP_ROLE_REL  
                        (                         
                            EMP_REF_ID,               
                            ROLE_REF_ID               
                        )                         
                        VALUES                        
                        (                         
                            @EMP_REF_ID,              
                            @ROLE_REF_ID              
                        )                         
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);

            paramArray[0].Value = aiEmpRefID;
            paramArray[1].Value = aiRoleRefID;

            return DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray);
        }

        public int DelRoleInfo(IDbConnection idc
                              , IDbTransaction idt
                              , int aiEmpRefID
                              , int aiRoleRefID)
        {
            string query = @"
                            DELETE 
                                COM_EMP_ROLE_REL         
                            WHERE 
                                EMP_REF_ID = @EMP_REF_ID 
                            AND 
                                ROLE_REF_ID= @ROLE_REF_ID
            ";


            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ROLE_REF_ID", SqlDbType.Int);

            paramArray[0].Value = aiEmpRefID;
            paramArray[1].Value = aiRoleRefID;

            return DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray);
        }
    }
}
