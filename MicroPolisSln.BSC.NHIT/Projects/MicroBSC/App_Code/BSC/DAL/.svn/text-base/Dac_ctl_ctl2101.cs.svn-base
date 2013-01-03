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
    /// Class 명		: Dac_ctl_ctl2101 Dac 클래스
    /// Class 내용		: ctl2101 실제 Dac 처리 
    ///                 : 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			: 강신규
    /// 최초작성일		: 2006.05.24
    /// 최종수정자		:
    /// 최종수정일		:
    /// Services		:
    /// 주요변경로그	:
    /// -------------------------------------------------------------
    public class Dac_ctl_ctl2101 : DbAgentBase
    {
        /// <summary>
        /// GetAddEmpRefID
        ///     : 추가될 Emp_Ref_ID를 추출한다.
        /// </summary>
        /// <returns></returns>
        public int GetAddEmpRefID()
        {
            string s_query = @"  
                            SELECT ISNULL(MAX(EMP_REF_ID),0)+1 FROM COM_EMP_INFO 
            ";

            string o_query = @"  
                            SELECT NVL(MAX(EMP_REF_ID),0)+1 FROM COM_EMP_INFO 
            ";

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query)));
        }

        public int AddEmpInfo(
                             int aiEMP_REF_ID
                            ,string asLOGINID
                            ,string asLOGINIP
                            ,string asPASSWD
                            ,string asEMP_NAME
                            ,string asPOSITION_CLASS_CODE
                            ,string asPOSITION_GRP_CODE
                            ,string asPOSITION_RANK_CODE
                            ,string asPOSITION_DUTY_CODE
                            ,string asPOSITION_STAT_CODE
                            ,string asPOSITION_KIND_CODE
                            ,string asEMP_EMail
                            ,string asDAILY_PHONE
                            ,string asCELL_PHONE
                            ,string asFAX_NUMBER
                            ,int aiJOB_STATUS
                            ,string asZIPCODE
                            ,string asADDR_1
                            ,string asADDR_2
                            ,string asSIGN_PATH
                            ,string asSTAMP_PATH
                            ,int aiCREATE_TYPE
                            ,int aiCREATE_EMP_ID
                            ,int aiMODIFY_TYPE
                            ,int aiMODIFY_EMP_ID
                             )
        {
            string s_query = @"

                            INSERT INTO COM_EMP_INFO                                                   
                               (                                                                      
                               EMP_REF_ID          , EMP_CODE              , LOGINID               ,  
                               PASSWD              , EMP_NAME              , EMP_EMail             ,  
                               POSITION_CLASS_CODE , POSITION_GRP_CODE     , POSITION_RANK_CODE    ,  
                               POSITION_DUTY_CODE  , POSITION_STAT_CODE    , POSITION_KIND_CODE    , DAILY_PHONE           ,  
                               CELL_PHONE          , FAX_NUMBER            , JOB_STATUS            ,  
                               ZIPCODE             , ADDR_1                , ADDR_2                ,  
                               SIGN_PATH           , STAMP_PATH            , CREATE_TYPE           ,  
                               CREATE_DATE         , CREATE_EMP_ID         , MODIFY_TYPE           ,  
                               MODIFY_DATE         , MODIFY_EMP_ID         , LOGINIP                  
                               )                                                                      
                           SELECT                                                                     
                               @EMP_REF_ID         , @LOGINID              , @LOGINID              ,  
                               @PASSWD             , @EMP_NAME             , @EMP_EMail            ,  
                               @POSITION_CLASS_CODE, @POSITION_GRP_CODE    , @POSITION_RANK_CODE   ,  
                               @POSITION_DUTY_CODE , @POSITION_STAT_CODE   , @POSITION_KIND_CODE   , @DAILY_PHONE          ,  
                               @CELL_PHONE         , @FAX_NUMBER           , @JOB_STATUS           ,  
                               @ZIPCODE            , @ADDR_1               , @ADDR_2               ,  
                               @SIGN_PATH          , @STAMP_PATH           , @CREATE_TYPE          ,  
                               GETDATE()           , @CREATE_EMP_ID        , @MODIFY_TYPE          ,  
                               GETDATE()           , @MODIFY_EMP_ID        , @LOGINIP                 
            ";


            string o_query = @"

                            INSERT INTO COM_EMP_INFO                                                   
                               (                                                                      
                               EMP_REF_ID          , EMP_CODE              , LOGINID               ,  
                               PASSWD              , EMP_NAME              , EMP_EMail             ,  
                               POSITION_CLASS_CODE , POSITION_GRP_CODE     , POSITION_RANK_CODE    ,  
                               POSITION_DUTY_CODE  , POSITION_STAT_CODE    , POSITION_KIND_CODE    , DAILY_PHONE           ,  
                               CELL_PHONE          , FAX_NUMBER            , JOB_STATUS            ,  
                               ZIPCODE             , ADDR_1                , ADDR_2                ,  
                               SIGN_PATH           , STAMP_PATH            , CREATE_TYPE           ,  
                               CREATE_DATE         , CREATE_EMP_ID         , MODIFY_TYPE           ,  
                               MODIFY_DATE         , MODIFY_EMP_ID         , LOGINIP                  
                               )                                                                      
                           SELECT                                                                     
                               @EMP_REF_ID         , @LOGINID              , @LOGINID              ,  
                               @PASSWD             , @EMP_NAME             , @EMP_EMail            ,  
                               @POSITION_CLASS_CODE, @POSITION_GRP_CODE    , @POSITION_RANK_CODE   ,  
                               @POSITION_DUTY_CODE , @POSITION_STAT_CODE   , @POSITION_KIND_CODE   , @DAILY_PHONE          ,  
                               @CELL_PHONE         , @FAX_NUMBER           , @JOB_STATUS           ,  
                               @ZIPCODE            , @ADDR_1               , @ADDR_2               ,  
                               @SIGN_PATH          , @STAMP_PATH           , @CREATE_TYPE          ,  
                               SYSDATE             , @CREATE_EMP_ID        , @MODIFY_TYPE          ,  
                               SYSDATE             , @MODIFY_EMP_ID        , @LOGINIP                
                           FROM DUAL 
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(25);
            paramArray[0] = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@PASSWD", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@POSITION_CLASS_CODE", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@POSITION_RANK_CODE", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@POSITION_DUTY_CODE", SqlDbType.VarChar);
            paramArray[7] = CreateDataParameter("@POSITION_STAT_CODE", SqlDbType.VarChar);
            paramArray[8] = CreateDataParameter("@POSITION_KIND_CODE", SqlDbType.VarChar);
            paramArray[9] = CreateDataParameter("@EMP_EMail", SqlDbType.VarChar);
            paramArray[10] = CreateDataParameter("@DAILY_PHONE", SqlDbType.VarChar);
            paramArray[11] = CreateDataParameter("@CELL_PHONE", SqlDbType.VarChar);
            paramArray[12] = CreateDataParameter("@FAX_NUMBER", SqlDbType.VarChar);
            paramArray[13] = CreateDataParameter("@JOB_STATUS", SqlDbType.Int);
            paramArray[14] = CreateDataParameter("@ZIPCODE", SqlDbType.VarChar);
            paramArray[15] = CreateDataParameter("@ADDR_1", SqlDbType.VarChar);
            paramArray[16] = CreateDataParameter("@ADDR_2", SqlDbType.VarChar);
            paramArray[17] = CreateDataParameter("@SIGN_PATH", SqlDbType.VarChar);
            paramArray[18] = CreateDataParameter("@STAMP_PATH", SqlDbType.VarChar);
            paramArray[19] = CreateDataParameter("@CREATE_TYPE", SqlDbType.Int);
            paramArray[20] = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
            paramArray[21] = CreateDataParameter("@MODIFY_TYPE", SqlDbType.Int);
            paramArray[22] = CreateDataParameter("@MODIFY_EMP_ID", SqlDbType.Int); 
            paramArray[23] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[24] = CreateDataParameter("@LOGINIP",   SqlDbType.VarChar);

            paramArray[0].Value = asLOGINID;
            paramArray[1].Value = asPASSWD;
            paramArray[2].Value = asEMP_NAME;
            paramArray[3].Value = asPOSITION_CLASS_CODE;
            paramArray[4].Value = asPOSITION_GRP_CODE;
            paramArray[5].Value = asPOSITION_RANK_CODE;
            paramArray[6].Value = asPOSITION_DUTY_CODE;
            paramArray[7].Value = asPOSITION_STAT_CODE;
            paramArray[8].Value = asPOSITION_KIND_CODE;
            paramArray[9].Value = asEMP_EMail;
            paramArray[10].Value = asDAILY_PHONE;
            paramArray[11].Value = asCELL_PHONE;
            paramArray[12].Value = asFAX_NUMBER;
            paramArray[13].Value = aiJOB_STATUS;
            paramArray[14].Value = asZIPCODE;
            paramArray[15].Value = asADDR_1;
            paramArray[16].Value = asADDR_2;
            paramArray[17].Value = asSIGN_PATH;
            paramArray[18].Value = asSTAMP_PATH;
            paramArray[19].Value = aiCREATE_TYPE;
            paramArray[20].Value = aiCREATE_EMP_ID;
            paramArray[21].Value = aiMODIFY_TYPE;
            paramArray[22].Value = aiMODIFY_EMP_ID;
            paramArray[23].Value = aiEMP_REF_ID;
            paramArray[24].Value = asLOGINIP;

            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray);
        }

        public int AddRelDeptInfo(
                                 int aiEMP_REF_ID
                               , int aiDEPT_REF_ID
                               , int aiREL_EMP_ID
                                 )
        {

            string s_query = @" 
                                
            INSERT INTO REL_DEPT_EMP                           
                (                                              
                EMP_REF_ID  , DEPT_REF_ID   , REL_STATUS    ,  
                BOSS_FLAG   , REL_DATE      , REL_EMP_ID       
                )                                              
            VALUES                                             
                (                                              
                @EMP_REF_ID  , @DEPT_REF_ID   , 1           ,
                0            , GETDATE()      , @REL_EMP_ID    
                )                                              
            ";


            string o_query = @" 
                                
            INSERT INTO REL_DEPT_EMP                           
                (                                              
                EMP_REF_ID  , DEPT_REF_ID   , REL_STATUS    ,  
                BOSS_FLAG   , REL_DATE      , REL_EMP_ID       
                )                                              
            VALUES                                             
                (                                              
                @EMP_REF_ID  , @DEPT_REF_ID   , 1           ,
                0            , SYSDATE      , @REL_EMP_ID    
                )                                              
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID",     SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID",    SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@REL_EMP_ID",     SqlDbType.Int);

            paramArray[0].Value = aiEMP_REF_ID;
            paramArray[1].Value = aiDEPT_REF_ID;
            paramArray[2].Value = aiREL_EMP_ID;

            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray);
        }

        public int EditEmpInfo(
                              int aiEMP_REF_ID
                             ,string asLOGINID
                             ,string asLOGINIP
                             ,string asEMP_NAME
                             ,string asPOSITION_CLASS_CODE
                             ,string asPOSITION_GRP_CODE
                             ,string asPOSITION_RANK_CODE
                             ,string asPOSITION_DUTY_CODE
                             ,string asPOSITION_STAT_CODE
                             ,string asPOSITION_KIND_CODE
                             ,string asEMP_EMail
                             ,string asDAILY_PHONE
                             ,string asCELL_PHONE
                             ,string asFAX_NUMBER
                             ,int aiJOB_STATUS
                             ,string asZIPCODE
                             ,string asADDR_1
                             ,string asADDR_2
                             ,string asSIGN_PATH
                             ,string asSTAMP_PATH
                             ,int aiCREATE_TYPE
                             ,int aiCREATE_EMP_ID
                             ,int aiMODIFY_TYPE
                             ,int aiMODIFY_EMP_ID
                              )
        {
            string s_query = @"
                    
                               UPDATE COM_EMP_INFO                                     
                                  SET                                                  
                                      EMP_CODE             = @LOGINID              ,   
                                      LOGINID              = @LOGINID              ,   
                                      EMP_NAME             = @EMP_NAME             ,   
                                      EMP_EMail            = @EMP_EMail            ,   
                                      POSITION_CLASS_CODE  = @POSITION_CLASS_CODE  ,   
                                      POSITION_GRP_CODE    = @POSITION_GRP_CODE    ,   
                                      POSITION_RANK_CODE   = @POSITION_RANK_CODE   ,   
                                      POSITION_DUTY_CODE   = @POSITION_DUTY_CODE   ,   
                                      POSITION_STAT_CODE   = @POSITION_STAT_CODE   ,   
                                      POSITION_KIND_CODE   = @POSITION_KIND_CODE   ,   
                                      DAILY_PHONE          = @DAILY_PHONE          ,   
                                      CELL_PHONE           = @CELL_PHONE           ,   
                                      FAX_NUMBER           = @FAX_NUMBER           ,   
                                      JOB_STATUS           = @JOB_STATUS           ,   
                                      ZIPCODE              = @ZIPCODE              ,   
                                      ADDR_1               = @ADDR_1               ,   
                                      ADDR_2               = @ADDR_2               ,   
                                      SIGN_PATH            = @SIGN_PATH            ,   
                                      STAMP_PATH           = @STAMP_PATH           ,   
                                      CREATE_TYPE          = @CREATE_TYPE          ,   
                                      CREATE_EMP_ID        = @CREATE_EMP_ID        ,   
                                      MODIFY_TYPE          = @MODIFY_TYPE          ,   
                                      MODIFY_DATE          = GETDATE()             ,   
                                      MODIFY_EMP_ID        = @MODIFY_EMP_ID        ,   
                                      LOGINIP              = @LOGINIP                  
                                WHERE EMP_REF_ID           = @EMP_REF_ID               

            ";

            string o_query = @"
                    
                               UPDATE COM_EMP_INFO                                     
                                  SET                                                  
                                      EMP_CODE             = @LOGINID              ,   
                                      LOGINID              = @LOGINID              ,   
                                      EMP_NAME             = @EMP_NAME             ,   
                                      EMP_EMail            = @EMP_EMail            ,   
                                      POSITION_CLASS_CODE  = @POSITION_CLASS_CODE  ,   
                                      POSITION_GRP_CODE    = @POSITION_GRP_CODE    ,   
                                      POSITION_RANK_CODE   = @POSITION_RANK_CODE   ,   
                                      POSITION_DUTY_CODE   = @POSITION_DUTY_CODE   ,   
                                      POSITION_STAT_CODE   = @POSITION_STAT_CODE   ,   
                                      POSITION_KIND_CODE   = @POSITION_KIND_CODE   ,   
                                      DAILY_PHONE          = @DAILY_PHONE          ,   
                                      CELL_PHONE           = @CELL_PHONE           ,   
                                      FAX_NUMBER           = @FAX_NUMBER           ,   
                                      JOB_STATUS           = @JOB_STATUS           ,   
                                      ZIPCODE              = @ZIPCODE              ,   
                                      ADDR_1               = @ADDR_1               ,   
                                      ADDR_2               = @ADDR_2               ,   
                                      SIGN_PATH            = @SIGN_PATH            ,   
                                      STAMP_PATH           = @STAMP_PATH           ,   
                                      CREATE_TYPE          = @CREATE_TYPE          ,   
                                      CREATE_EMP_ID        = @CREATE_EMP_ID        ,   
                                      MODIFY_TYPE          = @MODIFY_TYPE          ,   
                                      MODIFY_DATE          = SYSDATE             ,   
                                      MODIFY_EMP_ID        = @MODIFY_EMP_ID        ,   
                                      LOGINIP              = @LOGINIP                  
                                WHERE EMP_REF_ID           = @EMP_REF_ID   
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(24);

            paramArray[0] = CreateDataParameter("@LOGINID", SqlDbType.VarChar);
            paramArray[1] = CreateDataParameter("@EMP_NAME", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@POSITION_CLASS_CODE", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@POSITION_GRP_CODE", SqlDbType.VarChar);
            paramArray[4] = CreateDataParameter("@POSITION_RANK_CODE", SqlDbType.VarChar);
            paramArray[5] = CreateDataParameter("@POSITION_DUTY_CODE", SqlDbType.VarChar);
            paramArray[6] = CreateDataParameter("@POSITION_STAT_CODE", SqlDbType.VarChar);
            paramArray[7] = CreateDataParameter("@POSITION_KIND_CODE", SqlDbType.VarChar);
            paramArray[8] = CreateDataParameter("@EMP_EMail", SqlDbType.VarChar);
            paramArray[9] = CreateDataParameter("@DAILY_PHONE", SqlDbType.VarChar);
            paramArray[10] = CreateDataParameter("@CELL_PHONE", SqlDbType.VarChar);
            paramArray[11] = CreateDataParameter("@FAX_NUMBER", SqlDbType.VarChar);
            paramArray[12] = CreateDataParameter("@JOB_STATUS", SqlDbType.Int);
            paramArray[13] = CreateDataParameter("@ZIPCODE", SqlDbType.VarChar);
            paramArray[14] = CreateDataParameter("@ADDR_1", SqlDbType.VarChar);
            paramArray[15] = CreateDataParameter("@ADDR_2", SqlDbType.VarChar);
            paramArray[16] = CreateDataParameter("@SIGN_PATH", SqlDbType.VarChar);
            paramArray[17] = CreateDataParameter("@STAMP_PATH", SqlDbType.VarChar);
            paramArray[18] = CreateDataParameter("@CREATE_TYPE", SqlDbType.Int);
            paramArray[19] = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.Int);
            paramArray[20] = CreateDataParameter("@MODIFY_TYPE", SqlDbType.Int);
            paramArray[21] = CreateDataParameter("@MODIFY_EMP_ID", SqlDbType.Int);
            paramArray[22] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[23] = CreateDataParameter("@LOGINIP", SqlDbType.VarChar);

            paramArray[0].Value = asLOGINID;
            paramArray[1].Value = asEMP_NAME;
            paramArray[2].Value = asPOSITION_CLASS_CODE;
            paramArray[3].Value = asPOSITION_GRP_CODE;
            paramArray[4].Value = asPOSITION_RANK_CODE;
            paramArray[5].Value = asPOSITION_DUTY_CODE;
            paramArray[6].Value = asPOSITION_STAT_CODE;
            paramArray[7].Value = asPOSITION_KIND_CODE;
            paramArray[8].Value = asEMP_EMail;
            paramArray[9].Value = asDAILY_PHONE;
            paramArray[10].Value = asCELL_PHONE;
            paramArray[11].Value = asFAX_NUMBER;
            paramArray[12].Value = aiJOB_STATUS;
            paramArray[13].Value = asZIPCODE;
            paramArray[14].Value = asADDR_1;
            paramArray[15].Value = asADDR_2;
            paramArray[16].Value = asSIGN_PATH;
            paramArray[17].Value = asSTAMP_PATH;
            paramArray[18].Value = aiCREATE_TYPE;
            paramArray[19].Value = aiCREATE_EMP_ID;
            paramArray[20].Value = aiMODIFY_TYPE;
            paramArray[21].Value = aiMODIFY_EMP_ID;
            paramArray[22].Value = aiEMP_REF_ID;
            paramArray[23].Value = asLOGINIP;

            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray);
        }

        public int EditRelDeptInfo(
                                  int aiEMP_REF_ID
                                , int aiPrevDeptID
                                , int aiDEPT_REF_ID
                                , int aiREL_EMP_ID
                                  )
        {

            string s_query = @"                    
                                    UPDATE REL_DEPT_EMP                    
                                       SET DEPT_REF_ID  = @DEPT_REF_ID  ,  
                                           REL_DATE     = GETDATE()     ,  
                                           REL_EMP_ID   = @REL_EMP_ID      
                                    WHERE EMP_REF_ID   = @EMP_REF_ID      
                                       AND DEPT_REF_ID  = @PREV_DEPT_REF_ID
            ";

            string o_query = @"
                                    UPDATE REL_DEPT_EMP                    
                                       SET DEPT_REF_ID  = @DEPT_REF_ID  ,  
                                           REL_DATE     = SYSDATE     ,  
                                           REL_EMP_ID   = @REL_EMP_ID      
                                     WHERE EMP_REF_ID   = @EMP_REF_ID      
                                       AND DEPT_REF_ID  = @PREV_DEPT_REF_ID
            ";
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@REL_EMP_ID", SqlDbType.Int);
            paramArray[3] = CreateDataParameter("@PREV_DEPT_REF_ID", SqlDbType.Int);

            paramArray[0].Value = aiEMP_REF_ID;
            paramArray[1].Value = aiDEPT_REF_ID;
            paramArray[2].Value = aiREL_EMP_ID;
            paramArray[3].Value = aiPrevDeptID;

            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray);
        }

        public int SaveEmployeeDeptDetail(int aiEMP_REF_ID
                                , int aiPrevDeptID
                                , int aiDEPT_REF_ID
                                , int aiCREATE_EMP_ID)
        {
            object retValue;
            string queryString;
            IDbDataParameter[] paramArray;

            queryString = @"SELECT EMP_REF_ID, DEPT_REF_ID
                                FROM BSC_EMP_COM_DEPT_DETAIL
                                WHERE EMP_REF_ID = @EMP_REF_ID AND DEPT_REF_ID = @PREV_DEPT_REF_ID";
            
            paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@PREV_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = aiEMP_REF_ID;
            paramArray[1].Value = aiPrevDeptID;

            //retValue = DbAgentObj.ExecuteNonQuery(queryString, paramArray);
            retValue = DbAgentObj.ExecuteScalar(queryString, paramArray);

            if (retValue == null)
            {
                queryString = @"INSERT INTO BSC_EMP_COM_DEPT_DETAIL
                                (EMP_REF_ID, DEPT_REF_ID, CREATE_USER, CREATE_DATE, UPDATE_USER, UPDATE_DATE)
                                VALUES
                                (@EMP_REF_ID, @DEPT_REF_ID, @CREATE_EMP_ID, GETDATE(), @CREATE_EMP_ID, GETDATE())";

                paramArray = CreateDataParameters(3);
                paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.VarChar);
                paramArray[1] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@CREATE_EMP_ID", SqlDbType.VarChar);

                paramArray[0].Value = aiEMP_REF_ID;
                paramArray[1].Value = aiDEPT_REF_ID;
                paramArray[2].Value = aiCREATE_EMP_ID;

                return DbAgentObj.ExecuteNonQuery(queryString, paramArray);
            }
            else
            {
                queryString = @"UPDATE BSC_EMP_COM_DEPT_DETAIL
	                                SET DEPT_REF_ID = @DEPT_REF_ID
                                WHERE EMP_REF_ID = @EMP_REF_ID AND DEPT_REF_ID = @PREV_DEPT_REF_ID";

                paramArray = CreateDataParameters(3);
                paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.VarChar);
                paramArray[1] = CreateDataParameter("@PREV_DEPT_REF_ID", SqlDbType.VarChar);
                paramArray[2] = CreateDataParameter("@DEPT_REF_ID", SqlDbType.VarChar);
                paramArray[0].Value = aiEMP_REF_ID;
                paramArray[1].Value = aiPrevDeptID;
                paramArray[2].Value = aiDEPT_REF_ID;

                return DbAgentObj.ExecuteNonQuery(queryString, paramArray);
            }
        }
    }
}
