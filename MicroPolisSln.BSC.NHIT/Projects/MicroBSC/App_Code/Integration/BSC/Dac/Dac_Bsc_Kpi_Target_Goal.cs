using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

/// <summary>
/// Dac_Bsc_Kpi_Target_Goal에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Target_Goal Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.Integration.BSC.Dac
{
    public class Dac_Bsc_Kpi_Target_Goal : DbAgentBase
    {

        #region ========================== 멀티 DB 작업 ============================
        
        
        public DataSet Select_DB(object estterm_ref_id
                               , object kpi_ref_id
                               , object kpi_target_version_id)
        {
            string query = @"
SELECT TA.ESTTERM_REF_ID       
       ,TA.KPI_REF_ID           
       ,TA.KPI_TARGET_VERSION_ID
       ,TA.YMD
       ,(SUBSTRING(TA.YMD,1,4) + '/' + SUBSTRING(TA.YMD,5,2)) as YMD_DESC
       ,TA.TARGET_MS                                   as MS_PLAN
       ,TA.TARGET_TS                                   as TS_PLAN
       ,ISNULL(TB.TARGET_MS,0)                            as MM_PLAN
       ,ISNULL(TB.TARGET_TS,0)                            as TM_PLAN
       ,TA.VERSION_NAME                                as ORI_VERSION_NAME
       ,ISNULL(TB.VERSION_NAME,'수정계획(등록안됨)')      as MOD_VERSION_NAME
       ,TA.CHECK_YN                                    as ORI_CHECK_YN
       ,ISNULL(TB.CHECK_YN,'N')                           as MOD_CHECK_YN
       ,TC.CLOSE_YN                                    as MONTHLY_CLOSE_YN
   FROM (SELECT KT.ESTTERM_REF_ID       
               ,KT.KPI_REF_ID           
               ,KT.KPI_TARGET_VERSION_ID
               ,KT.YMD                  
               ,KT.TARGET_MS            
               ,KT.TARGET_TS            
               ,KT.CREATE_DATE          
               ,KT.CREATE_USER
               ,KT.UPDATE_DATE
               ,KT.UPDATE_USER
               ,KV.VERSION_NAME
               ,KM.CHECK_YN
           FROM BSC_KPI_TARGET_GOAL KT 
                INNER JOIN BSC_KPI_TARGET_VERSION KV
                   ON KT.ESTTERM_REF_ID        = KV.ESTTERM_REF_ID
                  AND KT.KPI_REF_ID            = KV.KPI_REF_ID
                  AND KT.KPI_TARGET_VERSION_ID = KV.KPI_TARGET_VERSION_ID
                INNER JOIN BSC_KPI_TERM KM
                   ON KT.ESTTERM_REF_ID        = KM.ESTTERM_REF_ID
                  AND KT.KPI_REF_ID            = KM.KPI_REF_ID
                  AND KT.YMD                   = KM.YMD
          WHERE KT.ESTTERM_REF_ID        = @ESTTERM_REF_ID       
            AND KT.KPI_REF_ID            = @KPI_REF_ID           
            AND KT.KPI_TARGET_VERSION_ID = @KPI_TARGET_VERSION_ID) TA
         LEFT JOIN 
         (SELECT KT.ESTTERM_REF_ID       
                ,KT.KPI_REF_ID           
                ,KT.KPI_TARGET_VERSION_ID
                ,KT.YMD                  
                ,KT.TARGET_MS
                ,KT.TARGET_TS
                ,KT.CREATE_DATE
                ,KT.CREATE_USER
                ,KT.UPDATE_DATE
                ,KT.UPDATE_USER
                ,KV.VERSION_NAME
                ,KM.CHECK_YN
            FROM BSC_KPI_TARGET_GOAL KT 
                 INNER JOIN BSC_KPI_TARGET_VERSION KV
                    ON KT.ESTTERM_REF_ID        = KV.ESTTERM_REF_ID
                   AND KT.KPI_REF_ID            = KV.KPI_REF_ID
                   AND KT.KPI_TARGET_VERSION_ID = KV.KPI_TARGET_VERSION_ID
                 INNER JOIN BSC_KPI_TERM KM
                    ON KT.ESTTERM_REF_ID        = KM.ESTTERM_REF_ID
                   AND KT.KPI_REF_ID            = KM.KPI_REF_ID
                   AND KT.YMD                   = KM.YMD
           WHERE KT.ESTTERM_REF_ID              = @ESTTERM_REF_ID
             AND KT.KPI_REF_ID                  = @KPI_REF_ID    
             AND KV.KPI_TARGET_VERSION_ID       > @KPI_TARGET_VERSION_ID
             AND KV.USE_YN = 'Y' ) TB
          ON TA.ESTTERM_REF_ID = TB.ESTTERM_REF_ID
         AND TA.KPI_REF_ID     = TB.KPI_REF_ID
         AND TA.YMD            = TB.YMD
        LEFT JOIN BSC_TERM_DETAIL TC
          ON TA.ESTTERM_REF_ID = TC.ESTTERM_REF_ID
         AND TA.YMD            = TC.YMD
       ORDER BY TA.YMD
";

            query = DbAgentHelper.GetQueryStringReplace(query);

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value         = kpi_target_version_id;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET", "PKG_BSC_KPI_TARGET.PROC_SELECT_ALL"), "BSC_KPI_TARGET_GOAL", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(query, "BSC_KPI_TARGET_GOAL", null, paramArray, CommandType.Text);
            return ds;
        }


        public int InsertData_DB(IDbConnection conn
                            , IDbTransaction trx
                            , object iestterm_ref_id
                            , object ikpi_ref_id
                            , object ikpi_target_version_id
                            , object iymd
                            , object itarget_ms
                            , object itarget_ts
                            , object itxr_user)
        {

            string query = @"

INSERT INTO BSC_KPI_TARGET_GOAL
( ESTTERM_REF_ID
, KPI_REF_ID
, KPI_TARGET_VERSION_ID
, YMD
, TARGET_MS
, TARGET_TS
, CREATE_DATE
, CREATE_USER)
VALUES
( @ESTTERM_REF_ID
, @KPI_REF_ID
, @KPI_TARGET_VERSION_ID
, @YMD
, @TARGET_MS
, @TARGET_TS
, GETDATE()
, @TXR_USER)

";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@TXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@TARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@TARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);


            return affectedRow;
        }

        public int UpdateData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object ikpi_target_version_id
                                , object iymd
                                , object itarget_ms
                                , object itarget_ts
                                , object itxr_user)
        {

            string query = @"

UPDATE BSC_KPI_TARGET_GOAL
SET TARGET_MS             = @TARGET_MS
   ,TARGET_TS             = @TARGET_TS
   ,UPDATE_DATE           = GETDATE()
   ,UPDATE_USER           = @TXR_USER 
WHERE ESTTERM_REF_ID        = @ESTTERM_REF_ID
AND KPI_REF_ID            = @KPI_REF_ID    
AND KPI_TARGET_VERSION_ID = @KPI_TARGET_VERSION_ID
AND YMD                   = @YMD

";
            
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@TXR_USER", SqlDbType.VarChar);
            paramArray[0].Value         = itxr_user;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[4].Value         = iymd;
            paramArray[5]               = CreateDataParameter("@TARGET_MS", SqlDbType.Decimal);
            paramArray[5].Value         = itarget_ms;
            paramArray[6]               = CreateDataParameter("@TARGET_TS", SqlDbType.Decimal);
            paramArray[6].Value         = itarget_ts;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        
        public int DeleteData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object iestterm_ref_id
                                , object ikpi_ref_id
                                , object ikpi_target_version_id)
        {

            string query = @"

DELETE BSC_KPI_TARGET_GOAL
WHERE ESTTERM_REF_ID          = @ESTTERM_REF_ID
    AND KPI_REF_ID            = @KPI_REF_ID    
    AND KPI_TARGET_VERSION_ID = @KPI_TARGET_VERSION_ID

";
            
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;
            paramArray[2]               = CreateDataParameter("@KPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_target_version_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }

        public DataSet SelectKpiListForResultAnalysisNew_DB(int iestterm_ref_id, string iymd, string iresult_input_type, string ikpi_code, string ikpi_name,
                                                   string ichampion_name, int iest_dept_ref_id, int ithreshold_ref_id, string isum_type
                                                 , string ikpi_group_ref_id, string ikpi_external_type, int group_code, string estYN)
        {
            string strQuery = @"
SELECT  TA.ESTTERM_REF_ID
        ,TA.KPI_REF_ID                       
        ,TA.YMD                              
        ,TA.KPI_CODE                         
        ,TA.KPI_POOL_REF_ID                  
        ,TA.KPI_NAME                         
        ,TA.WORD_DEFINITION                  
        ,TA.MEASUREMENT_PURPOSE              
        ,TA.CALC_FORM_MS                     
        ,TA.CALC_FORM_TS                     
        ,TA.RELATED_ISSUE                    
        ,TA.ADD_FILE                         
        ,TA.CHAMPION_EMP_ID                  
        ,TA.CHAMPION_EMP_NAME                
        ,TA.MEASUREMENT_EMP_ID               
        ,TA.MEASUREMENT_EMP_NAME             
        ,TA.APPROVAL_EMP_ID                  
        ,TA.APPROVAL_EMP_NAME                
        ,TA.DATA_GETHERING_METHOD            
        ,TA.RESULT_TERM_TYPE                 
        ,TA.RESULT_TERM_TYPE_NAME            
        ,TA.RESULT_INPUT_TYPE                
        ,TA.RESULT_INPUT_TYPE_NAME           
        ,TA.RESULT_ACHIEVEMENT_TYPE          
        ,TA.RESULT_ACHIEVEMENT_TYPE_NAME     
        ,TA.RESULT_TS_CALC_TYPE              
        ,TA.RESULT_TS_CALC_TYPE_NAME         
        ,TA.RESULT_MEASUREMENT_STEP          
        ,TA.RESULT_MEASUREMENT_STEP_NAME     
        ,TA.MEASUREMENT_GRADE_TYPE           
        ,TA.MEASUREMENT_GRADE_TYPE_NAME      
        ,TA.UNIT_TYPE_REF_ID                 
        ,TA.UNIT_NAME                        
        ,TA.KPI_TARGET_VERSION_ID            
        ,TA.APPROVAL_STATUS                  
        ,TA.GRAPH_TYPE                       
        ,TA.APP_REF_ID                       
        ,TA.EXCEL_DNUSE
        ,TA.USE_YN
        ,TA.ISDELETE
        ,TA.OP_DEPT_NAME
        ,TA.CHECK_YN
        ,TA.CHECKSTATUS
        ,TA.CONFIRMSTATUS
        ,TA.RESULT
        ,TA.TARGET
        ,TA.THRESHOLD_REF_ID
        ,TC.IMAGE_FILE_NAME as SIGNAL_IMAGE
        ,TA.TREND
        ,TA.ACHIEVE_RATE
       ,CASE WHEN (TA.RESULT_ACHIEVEMENT_TYPE='ATY' AND CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')) >=100) THEN CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')) 
             WHEN (TA.RESULT_ACHIEVEMENT_TYPE='ATY' AND CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')) < 100) THEN CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0'))-100
             ELSE (100-CONVERT(NUMERIC(20,4), REPLACE(TA.ACHIEVE_RATE,'-','0')))
        END as ACHIEVE_RATE_DIFF
        ,TA.KPI_GROUP_REF_ID
        ,TA.KPI_GROUP_NAME
        ,TA.CREATE_DATE
        ,TA.CREATE_USER
        ,TA.UPDATE_DATE
        ,TA.UPDATE_USER
FROM ( 
      SELECT KI.ESTTERM_REF_ID          
            ,KI.KPI_REF_ID
            ,KR.YMD
            ,KI.KPI_CODE                
            ,KI.KPI_POOL_REF_ID         
            ,ISNULL(KP.KPI_NAME,'') as KPI_NAME
            ,KI.WORD_DEFINITION         
            ,KI.MEASUREMENT_PURPOSE     
            ,KI.CALC_FORM_MS            
            ,KI.CALC_FORM_TS            
            ,KI.RELATED_ISSUE           
            ,KI.ADD_FILE                
            ,KI.CHAMPION_EMP_ID
            ,ISNULL(CE1.EMP_NAME,'') as CHAMPION_EMP_NAME
            ,KI.MEASUREMENT_EMP_ID
            ,ISNULL(CE2.EMP_NAME,'') as MEASUREMENT_EMP_NAME
            ,KI.APPROVAL_EMP_ID
            ,ISNULL(CE3.EMP_NAME,'') as APPROVAL_EMP_NAME
            ,KI.DATA_GETHERING_METHOD	 
            ,KI.RESULT_TERM_TYPE
            ,CA5.CODE_NAME as RESULT_TERM_TYPE_NAME
            ,KI.RESULT_INPUT_TYPE
            ,CA1.CODE_NAME as RESULT_INPUT_TYPE_NAME
            ,KI.RESULT_ACHIEVEMENT_TYPE 
            ,CA3.CODE_NAME as RESULT_ACHIEVEMENT_TYPE_NAME
            ,KI.RESULT_TS_CALC_TYPE
            ,CA2.CODE_NAME as RESULT_TS_CALC_TYPE_NAME
            ,KI.RESULT_MEASUREMENT_STEP
            ,CA4.CODE_NAME as RESULT_MEASUREMENT_STEP_NAME
            ,KI.MEASUREMENT_GRADE_TYPE
            ,CA6.CODE_NAME as MEASUREMENT_GRADE_TYPE_NAME
            ,KI.UNIT_TYPE_REF_ID
            ,ISNULL(CU.UNIT,'-') as UNIT_NAME
            ,KI.KPI_TARGET_VERSION_ID   
            ,KI.APPROVAL_STATUS         
            ,KI.GRAPH_TYPE              
            ,KI.APP_REF_ID
            ,KI.EXCEL_DNUSE             
            ,KI.USE_YN                  
            ,KI.ISDELETE
            ,VEE.COM_DEPT_NAME as OP_DEPT_NAME
            ,KT.CHECK_YN
            ,KR.CHECKSTATUS
            ,KR.CONFIRMSTATUS
            ,CASE WHEN @iSUM_TYPE='MS' THEN KR.RESULT_MS ELSE dbo.fn_BSC_KPI_RESULT_TS(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD) END as RESULT
            ,CASE WHEN @iSUM_TYPE='MS' THEN BT.TARGET_MS ELSE dbo.fn_BSC_KPI_TARGET_TS(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD) END as TARGET
            ,dbo.fn_BSC_KPI_INDICATOR_ID(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, @iSUM_TYPE) as THRESHOLD_REF_ID
            ,dbo.fn_BSC_KPI_TREND(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, @iSUM_TYPE) as TREND
            ,dbo.fn_BSC_KPI_ACHEVE_RATE(KI.ESTTERM_REF_ID, KI.KPI_REF_ID, KR.YMD, @iSUM_TYPE) as ACHIEVE_RATE
            ,KP.KPI_GROUP_REF_ID
            ,ISNULL(CA9.CODE_NAME,'') as KPI_GROUP_NAME
            ,KI.CREATE_DATE             
            ,KI.CREATE_USER             
            ,KI.UPDATE_DATE             
            ,KI.UPDATE_USER   
        FROM BSC_KPI_INFO KI 
             LEFT JOIN COM_EMP_INFO CE1 ON KI.CHAMPION_EMP_ID    = CE1.EMP_REF_ID
             LEFT JOIN COM_EMP_INFO CE2 ON KI.MEASUREMENT_EMP_ID = CE2.EMP_REF_ID
             LEFT JOIN COM_EMP_INFO CE3 ON KI.APPROVAL_EMP_ID    = CE3.EMP_REF_ID
             LEFT JOIN BSC_KPI_POOL KP ON KI.KPI_POOL_REF_ID     = KP.KPI_POOL_REF_ID
             LEFT JOIN BSC_KPI_TERM KT
               ON KI.ESTTERM_REF_ID = KT.ESTTERM_REF_ID
              AND KI.KPI_REF_ID     = KT.KPI_REF_ID
              AND KT.YMD            = @iYMD
             LEFT JOIN BSC_KPI_RESULT KR 
               ON KI.ESTTERM_REF_ID = KR.ESTTERM_REF_ID
              AND KI.KPI_REF_ID     = KR.KPI_REF_ID
              AND KR.YMD            = @iYMD
             LEFT JOIN BSC_KPI_TARGET BT
               ON KR.ESTTERM_REF_ID        = BT.ESTTERM_REF_ID
              AND KR.KPI_REF_ID            = BT.KPI_REF_ID
              AND KR.YMD                   = BT.YMD
            INNER JOIN BSC_KPI_TARGET_VERSION KV
               ON BT.ESTTERM_REF_ID        = KV.ESTTERM_REF_ID
              AND BT.KPI_REF_ID            = KV.KPI_REF_ID
              AND BT.KPI_TARGET_VERSION_ID = KV.KPI_TARGET_VERSION_ID
             LEFT JOIN COM_UNIT_TYPE_INFO CU ON KI.UNIT_TYPE_REF_ID = CU.UNIT_TYPE_REF_ID
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS001') CA1 
                    ON KI.RESULT_INPUT_TYPE = CA1.ETC_CODE       -- RESULT_INPUT_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS002') CA2
                    ON KI.RESULT_TS_CALC_TYPE = CA2.ETC_CODE     -- RESULT_TS_CALC_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS003') CA3
                    ON KI.RESULT_ACHIEVEMENT_TYPE = CA3.ETC_CODE -- RESULT_ACHIEVEMENT_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS004') CA4
                    ON KI.RESULT_MEASUREMENT_STEP = CA4.ETC_CODE -- RESULT_MEASUREMENT_STEP
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS005') CA5
                    ON KI.RESULT_TERM_TYPE = CA5.ETC_CODE        -- RESULT_TERM_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS006') CA6
                    ON KI.MEASUREMENT_GRADE_TYPE = CA6.ETC_CODE  -- MEASUREMENT_GRADE_TYPE
             LEFT JOIN (SELECT ETC_CODE, CODE_NAME 
                          FROM COM_CODE_INFO 
                         WHERE CATEGORY_CODE = 'BS009') CA9
                    ON KP.KPI_GROUP_REF_ID = CA9.ETC_CODE        -- KPI GROUP
             LEFT JOIN viw_EMP_COMDEPT VEE
                    ON KI.CHAMPION_EMP_ID = VEE.EMP_REF_ID 
             LEFT JOIN COM_APPROVAL_INFO AI
                    ON KI.APP_REF_ID = AI.APP_REF_ID
                   AND AI.ACTIVE_YN = 'Y'
             LEFT OUTER JOIN BSC_KPI_GROUP_MAP KM
                    ON KM.ESTTERM_REF_ID = KI.ESTTERM_REF_ID
                   AND KM.KPI_REF_ID     = KI.KPI_REF_ID
             LEFT OUTER JOIN BSC_KPI_ISSUE_GROUP KG
                    ON KG.ESTTERM_REF_ID = KM.ESTTERM_REF_ID
                   AND KG.GROUP_CODE     = KM.GROUP_CODE
       WHERE KI.ESTTERM_REF_ID = @iESTTERM_REF_ID
         AND KV.USE_YN         = 'Y'
         AND KI.ISDELETE       = 'N'
         AND KI.IS_TEAM_KPI    = 'Y'

/*
         AND KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%')
         AND KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%')
         AND KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%')
         AND KP.KPI_EXTERNAL_TYPE LIKE ( @iKPI_EXTERNAL_TYPE + '%')
         AND KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%')
         AND CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%')
         AND (ISNULL(KT.CHECK_YN, 'N') LIKE ( @EST_YN     + '%') )
*/

         AND (KI.KPI_CODE          LIKE ( @iKPI_CODE          + '%') OR  @iKPI_CODE  ='' )
         AND (KP.KPI_NAME          LIKE ( @iKPI_NAME          + '%') OR  @iKPI_NAME  ='' )
         AND (KP.KPI_GROUP_REF_ID  LIKE ( @iKPI_GROUP_REF_ID  + '%') OR  @iKPI_GROUP_REF_ID  ='' )
         AND (KP.KPI_EXTERNAL_TYPE LIKE ( @iKPI_EXTERNAL_TYPE + '%') OR  @iKPI_EXTERNAL_TYPE  ='' )
         AND (KI.RESULT_INPUT_TYPE LIKE ( @iRESULT_INPUT_TYPE + '%') OR  @iRESULT_INPUT_TYPE  ='' )
         AND (CE1.EMP_NAME         LIKE ( @iCHAMPION_NAME     + '%') OR  @iCHAMPION_NAME  ='' )
         AND ((ISNULL(KT.CHECK_YN, 'N') LIKE ( @EST_YN     + '%') ) OR  @EST_YN  ='' )


         AND VEE.COM_DEPT_REF_ID = CASE WHEN @iEST_DEPT_REF_ID < 1 THEN 
                                             VEE.COM_DEPT_REF_ID 
                                        ELSE @iEST_DEPT_REF_ID 
                                   END
         
         AND (ISNULL(KG.GROUP_CODE, 0) = @GROUP_CODE OR @GROUP_CODE = 0)
      ) TA 
      LEFT JOIN BSC_THRESHOLD_CODE TC
        ON TA.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
WHERE TC.THRESHOLD_REF_ID = CASE WHEN (@iTHRESHOLD_REF_ID < 1 OR @iTHRESHOLD_REF_ID IS NULL) THEN TC.THRESHOLD_REF_ID
                                ELSE @iTHRESHOLD_REF_ID
                           END
ORDER BY TA.KPI_NAME
";
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[1].Value = iymd;
            paramArray[2] = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar, 20);
            paramArray[2].Value = iresult_input_type;
            paramArray[3] = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[3].Value = ikpi_code;
            paramArray[4] = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[4].Value = ikpi_name;
            paramArray[5] = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[5].Value = ichampion_name;
            paramArray[6] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iest_dept_ref_id;
            paramArray[7] = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[7].Value = ithreshold_ref_id;
            paramArray[8] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[8].Value = isum_type;
            paramArray[9] = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[9].Value = ikpi_group_ref_id;
            paramArray[10] = CreateDataParameter("@iKPI_EXTERNAL_TYPE", SqlDbType.VarChar);
            paramArray[10].Value = ikpi_external_type;
            paramArray[11] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
            paramArray[11].Value = group_code;
            paramArray[12] = CreateDataParameter("@EST_YN", SqlDbType.VarChar);
            paramArray[12].Value = estYN;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);
            return ds;
        }



        public DataSet Select_DB(object estterm_ref_id
                                , object kpi_ref_id
                                , string ymd)
        {
            string strQuery = @"

SELECT ESTTERM_REF_ID
      ,KPI_REF_ID
      ,KPI_TARGET_VERSION_ID
      ,YMD 
      ,TARGET_MS                AS GOAL_MS
      ,TARGET_TS                AS GOAL_TS
      ,dbo.fn_BSC_KPI_ACHEVE_RATE_GOAL(ESTTERM_REF_ID, KPI_REF_ID,YMD,'MS') AS GOAL_DAL_MS
      ,dbo.fn_BSC_KPI_ACHEVE_RATE_GOAL(ESTTERM_REF_ID, KPI_REF_ID,YMD,'TS') AS GOAL_DAL_TS
 FROM BSC_KPI_TARGET_GOAL
WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID
  AND KPI_REF_ID     = @KPI_REF_ID
  AND YMD            = @YMD
ORDER BY KPI_TARGET_VERSION_ID DESC

";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = kpi_ref_id;
            paramArray[2] = CreateDataParameter("@YMD", SqlDbType.VarChar, 20);
            paramArray[2].Value = ymd;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_INFO", null, paramArray, CommandType.Text);
            return ds;
        }




        #endregion

    }
}
