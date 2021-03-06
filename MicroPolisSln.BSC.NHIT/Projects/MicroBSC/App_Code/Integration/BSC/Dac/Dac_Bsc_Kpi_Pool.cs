﻿using System;
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
/// Dac_Bsc_Kpi_Info에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Info Dac 클래스
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
    public class Dac_Bsc_Kpi_Pool : DbAgentBase
    {

        #region 리스트
        public DataTable SelectData_DB(object kpi_name
                                   , object use_yn
                                   , object kpi_group_ref_id
                                   , object kpi_pool_ver_id
                                   , object kpi_pool_templete_id)
        {

            //            string query = @"
            //SELECT KP.KPI_POOL_REF_ID
            //        ,KP.KPI_NAME
            //        ,KP.KPI_DESC
            //        ,KP.KPI_GROUP_REF_ID
            //        ,ISNULL(CI.CODE_NAME,'') as KPI_GROUP_NAME
            //        ,KP.KPI_EXTERNAL_TYPE
            //        ,ISNULL(C2.CODE_NAME,'') as KPI_EXTERNAL_TYPE_NAME
            //        ,KP.BASIS_USE_YN
            //        ,KP.VALUATION_BASIS
            //        ,KP.CATEGORY_TOP_REF_ID
            //        ,KP.CATEGORY_MID_REF_ID
            //        ,KP.CATEGORY_LOW_REF_ID
            //        ,CT.CATEGORY_NAME       as TOP_CATEGORY_NAME
            //        ,CM.CATEGORY_NAME       as MID_CATEGORY_NAME
            //        ,CL.CATEGORY_NAME       as LOW_CATEGORY_NAME
            //        ,KP.USE_YN
            //        ,KP.CREATE_USER
            //        ,KP.CREATE_DATE
            //        ,KP.UPDATE_USER
            //        ,KP.UPDATE_DATE
            //    FROM BSC_KPI_POOL KP
            //         LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='BS009') CI
            //           ON KP.KPI_GROUP_REF_ID = CI.ETC_CODE
            //         LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='BS010')  C2
            //           ON KP.KPI_EXTERNAL_TYPE = C2.ETC_CODE
            //         LEFT JOIN BSC_KPI_CATEGORY_TOP CT
            //           ON KP.CATEGORY_TOP_REF_ID = CT.CATEGORY_TOP_REF_ID
            //         LEFT JOIN BSC_KPI_CATEGORY_MID CM
            //           ON KP.CATEGORY_TOP_REF_ID = CM.CATEGORY_TOP_REF_ID
            //          AND KP.CATEGORY_MID_REF_ID = CM.CATEGORY_MID_REF_ID
            //         LEFT JOIN BSC_KPI_CATEGORY_LOW CL
            //           ON KP.CATEGORY_TOP_REF_ID = CL.CATEGORY_TOP_REF_ID
            //          AND KP.CATEGORY_MID_REF_ID = CL.CATEGORY_MID_REF_ID
            //          AND KP.CATEGORY_LOW_REF_ID = CL.CATEGORY_LOW_REF_ID
            //   WHERE (KP.KPI_NAME          LIKE ( @KPI_NAME          + '%') OR     @KPI_NAME  ='' )
            //     AND (KP.USE_YN                  =  @USE_YN                 OR  @USE_YN               =''  )
            //     AND (KP.KPI_GROUP_REF_ID        =  @KPI_GROUP_REF_ID       OR  @KPI_GROUP_REF_ID     =''  )
            ///*
            //     AND (VM.KPI_POOL_VER_ID         =  @KPI_POOL_VER_ID        OR  @KPI_POOL_VER_ID      = 0   )
            //     AND (TM.KPI_POOL_TEMPLETE_ID    =  @KPI_POOL_TEMPLETE_ID   OR  @KPI_POOL_TEMPLETE_ID = 0   )
            //*/
            //     {0} KP.KPI_POOL_REF_ID IN ( SELECT KPI_POOL_REF_ID FROM BSC_KPI_POOL_VER_MAP
            //                                  WHERE (KPI_POOL_VER_ID         =  @KPI_POOL_VER_ID        OR  @KPI_POOL_VER_ID           = 0   )
            //                               )
            //     {1} KP.KPI_POOL_REF_ID IN ( SELECT KPI_POOL_REF_ID FROM BSC_KPI_POOL_TEMPLETE_MAP
            //                                  WHERE (KPI_POOL_TEMPLETE_ID    =  @KPI_POOL_TEMPLETE_ID   OR  @KPI_POOL_TEMPLETE_ID      = 0   )
            //                               )
            //   ORDER BY KP.KPI_NAME
            //
            //";
            //            string boolean1 = "OR";
            //            string boolean2 = "OR";

            //            if (!kpi_pool_ver_id.Equals(0))
            //            {
            //                boolean1 = "AND";
            //            }

            //            if (!kpi_pool_templete_id.Equals(0))
            //            {
            //                boolean2 = "AND";
            //            }
            //            query = string.Format(query, boolean1, boolean2);


            string query = @"
SELECT KP.KPI_POOL_REF_ID
        ,KP.KPI_NAME
        ,KP.KPI_DESC
        ,KP.KPI_GROUP_REF_ID
        ,ISNULL(CI.CODE_NAME,'') as KPI_GROUP_NAME
        ,KP.KPI_EXTERNAL_TYPE
        ,ISNULL(C2.CODE_NAME,'') as KPI_EXTERNAL_TYPE_NAME
        ,KP.BASIS_USE_YN
        --,KP.VALUATION_BASIS
        ,KP.CATEGORY_TOP_REF_ID
        ,KP.CATEGORY_MID_REF_ID
        ,KP.CATEGORY_LOW_REF_ID
        ,CT.CATEGORY_NAME       as TOP_CATEGORY_NAME
        ,CM.CATEGORY_NAME       as MID_CATEGORY_NAME
        ,CL.CATEGORY_NAME       as LOW_CATEGORY_NAME
        ,KP.USE_YN
        ,KP.CREATE_USER
        ,KP.CREATE_DATE
        ,KP.UPDATE_USER
        ,KP.UPDATE_DATE
        ,SG.STG_NAME
        ,SG.VIEW_NAME
    FROM BSC_KPI_POOL KP
         LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='BS009') CI
           ON KP.KPI_GROUP_REF_ID = CI.ETC_CODE
         LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='BS010')  C2
           ON KP.KPI_EXTERNAL_TYPE = C2.ETC_CODE
         LEFT JOIN BSC_KPI_CATEGORY_TOP CT
           ON KP.CATEGORY_TOP_REF_ID = CT.CATEGORY_TOP_REF_ID
         LEFT JOIN BSC_KPI_CATEGORY_MID CM
           ON KP.CATEGORY_TOP_REF_ID = CM.CATEGORY_TOP_REF_ID
          AND KP.CATEGORY_MID_REF_ID = CM.CATEGORY_MID_REF_ID
         LEFT JOIN BSC_KPI_CATEGORY_LOW CL
           ON KP.CATEGORY_TOP_REF_ID = CL.CATEGORY_TOP_REF_ID
          AND KP.CATEGORY_MID_REF_ID = CL.CATEGORY_MID_REF_ID
          AND KP.CATEGORY_LOW_REF_ID = CL.CATEGORY_LOW_REF_ID
         LEFT OUTER  JOIN BSC_KPI_POOL_VER_MAP      VM ON(KP.KPI_POOL_REF_ID = VM.KPI_POOL_REF_ID)
         LEFT OUTER  JOIN BSC_KPI_POOL_TEMPLETE_MAP TM ON(KP.KPI_POOL_REF_ID = TM.KPI_POOL_REF_ID)
         LEFT JOIN 
                 (
                    SELECT DISTINCT BSI.STG_CODE, BSI.STG_NAME, BSI.VIEW_REF_ID, BVI.VIEW_NAME, BSI.STG_REF_ID 
                        FROM BSC_STG_INFO BSI JOIN 
                             BSC_VIEW_INFO BVI 
                                ON BSI.VIEW_REF_ID = BVI.VIEW_REF_ID
                    WHERE BSI.ESTTERM_REF_ID = (SELECT MAX(ESTTERM_REF_ID) FROM EST_TERM_INFO WHERE EST_STATUS = '1')
                 ) SG ON KP.STG_REF_ID = SG.STG_REF_ID
   WHERE (KP.KPI_NAME          LIKE ( @KPI_NAME          + '%') OR     @KPI_NAME  ='' )
     AND (KP.USE_YN                  =  @USE_YN                 OR  @USE_YN               =''  )
     AND (KP.KPI_GROUP_REF_ID        =  @KPI_GROUP_REF_ID       OR  @KPI_GROUP_REF_ID     =''  )
     AND (VM.KPI_POOL_VER_ID         =  @KPI_POOL_VER_ID        OR  @KPI_POOL_VER_ID      = 0   )
     AND (TM.KPI_POOL_TEMPLETE_ID    =  @KPI_POOL_TEMPLETE_ID   OR  @KPI_POOL_TEMPLETE_ID = 0   )

   GROUP BY KP.KPI_POOL_REF_ID
        ,KP.KPI_NAME
        ,KP.KPI_DESC
        ,KP.KPI_GROUP_REF_ID
        ,ISNULL(CI.CODE_NAME,'')
        ,KP.KPI_EXTERNAL_TYPE
        ,ISNULL(C2.CODE_NAME,'')
        ,KP.BASIS_USE_YN
        --,KP.VALUATION_BASIS
        ,KP.CATEGORY_TOP_REF_ID
        ,KP.CATEGORY_MID_REF_ID
        ,KP.CATEGORY_LOW_REF_ID
        ,CT.CATEGORY_NAME       
        ,CM.CATEGORY_NAME       
        ,CL.CATEGORY_NAME       
        ,KP.USE_YN
        ,KP.CREATE_USER
        ,KP.CREATE_DATE
        ,KP.UPDATE_USER
        ,KP.UPDATE_DATE
        ,SG.STG_NAME
        ,SG.VIEW_NAME
   ORDER BY KP.KPI_NAME
";
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[0].Value = kpi_name;
            paramArray[1] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[1].Value = use_yn;
            paramArray[2] = CreateDataParameter("@KPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[2].Value = kpi_group_ref_id;
            paramArray[3] = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[3].Value = kpi_pool_ver_id;
            paramArray[4] = CreateDataParameter("@KPI_POOL_TEMPLETE_ID", SqlDbType.Int);
            paramArray[4].Value = kpi_pool_templete_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_POOL", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }
        #endregion

        #region 리스트
        public DataTable SelectData_DB(object kpi_name
                                   , object use_yn
                                   , object kpi_group_ref_id
                                   , object kpi_pool_ver_id
                                   , object kpi_pool_templete_id
                                   , object STG_REF_ID
                                    , object KPI_EXTERNAL_TYPE)
        {

            string query = @"
SELECT KP.KPI_POOL_REF_ID
        ,KP.KPI_NAME
        ,KP.KPI_DESC
        ,KP.KPI_GROUP_REF_ID
        ,ISNULL(CI.CODE_NAME,'') as KPI_GROUP_NAME
        ,KP.KPI_EXTERNAL_TYPE
        ,ISNULL(C2.CODE_NAME,'') as KPI_EXTERNAL_TYPE_NAME
        ,KP.BASIS_USE_YN
        --,KP.VALUATION_BASIS
        ,KP.CATEGORY_TOP_REF_ID
        ,KP.CATEGORY_MID_REF_ID
        ,KP.CATEGORY_LOW_REF_ID
        ,CT.CATEGORY_NAME       as TOP_CATEGORY_NAME
        ,CM.CATEGORY_NAME       as MID_CATEGORY_NAME
        ,CL.CATEGORY_NAME       as LOW_CATEGORY_NAME
        ,KP.USE_YN
        ,KP.CREATE_USER
        ,KP.CREATE_DATE
        ,KP.UPDATE_USER
        ,KP.UPDATE_DATE
        ,SG.STG_NAME
        ,SG.VIEW_NAME
    FROM BSC_KPI_POOL KP
         LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='BS009') CI
           ON KP.KPI_GROUP_REF_ID = CI.ETC_CODE
         LEFT JOIN (SELECT * FROM COM_CODE_INFO WHERE CATEGORY_CODE='BS010')  C2
           ON KP.KPI_EXTERNAL_TYPE = C2.ETC_CODE
         LEFT JOIN BSC_KPI_CATEGORY_TOP CT
           ON KP.CATEGORY_TOP_REF_ID = CT.CATEGORY_TOP_REF_ID
         LEFT JOIN BSC_KPI_CATEGORY_MID CM
           ON KP.CATEGORY_TOP_REF_ID = CM.CATEGORY_TOP_REF_ID
          AND KP.CATEGORY_MID_REF_ID = CM.CATEGORY_MID_REF_ID
         LEFT JOIN BSC_KPI_CATEGORY_LOW CL
           ON KP.CATEGORY_TOP_REF_ID = CL.CATEGORY_TOP_REF_ID
          AND KP.CATEGORY_MID_REF_ID = CL.CATEGORY_MID_REF_ID
          AND KP.CATEGORY_LOW_REF_ID = CL.CATEGORY_LOW_REF_ID
         LEFT OUTER  JOIN BSC_KPI_POOL_VER_MAP      VM ON(KP.KPI_POOL_REF_ID = VM.KPI_POOL_REF_ID)
         LEFT OUTER  JOIN BSC_KPI_POOL_TEMPLETE_MAP TM ON(KP.KPI_POOL_REF_ID = TM.KPI_POOL_REF_ID)
         LEFT JOIN 
                 (
                    SELECT DISTINCT BSI.STG_REF_ID, BSI.STG_NAME, BSI.VIEW_REF_ID, BVI.VIEW_NAME 
                        FROM BSC_STG_INFO BSI JOIN 
                             BSC_VIEW_INFO BVI 
                                ON BSI.VIEW_REF_ID = BVI.VIEW_REF_ID
                 ) SG ON KP.STG_REF_ID = SG.STG_REF_ID
   WHERE (KP.KPI_NAME          LIKE ( '%' + @KPI_NAME          + '%') OR     @KPI_NAME  ='' )
     AND (KP.USE_YN                  =  @USE_YN                 OR  @USE_YN               =''  )
     AND (KP.KPI_GROUP_REF_ID        =  @KPI_GROUP_REF_ID       OR  @KPI_GROUP_REF_ID     =''  )
     AND (VM.KPI_POOL_VER_ID         =  @KPI_POOL_VER_ID        OR  @KPI_POOL_VER_ID      = 0   )
     AND (TM.KPI_POOL_TEMPLETE_ID    =  @KPI_POOL_TEMPLETE_ID   OR  @KPI_POOL_TEMPLETE_ID = 0   )
     AND (ISNULL(KP.STG_REF_ID,0)    =  @STG_REF_ID             OR  @STG_REF_ID               = 0  )
     AND (KP.KPI_EXTERNAL_TYPE       =  @KPI_EXTERNAL_TYPE      OR  @KPI_EXTERNAL_TYPE ='')
   GROUP BY KP.KPI_POOL_REF_ID
        ,KP.KPI_NAME
        ,KP.KPI_DESC
        ,KP.KPI_GROUP_REF_ID
        ,ISNULL(CI.CODE_NAME,'')
        ,KP.KPI_EXTERNAL_TYPE
        ,ISNULL(C2.CODE_NAME,'')
        ,KP.BASIS_USE_YN
        --,KP.VALUATION_BASIS
        ,KP.CATEGORY_TOP_REF_ID
        ,KP.CATEGORY_MID_REF_ID
        ,KP.CATEGORY_LOW_REF_ID
        ,CT.CATEGORY_NAME       
        ,CM.CATEGORY_NAME       
        ,CL.CATEGORY_NAME       
        ,KP.USE_YN
        ,KP.CREATE_USER
        ,KP.CREATE_DATE
        ,KP.UPDATE_USER
        ,KP.UPDATE_DATE
        ,SG.STG_NAME
        ,SG.VIEW_NAME
   ORDER BY KP.KPI_NAME
";
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[0].Value = kpi_name;
            paramArray[1] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[1].Value = use_yn;
            paramArray[2] = CreateDataParameter("@KPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[2].Value = kpi_group_ref_id;
            paramArray[3] = CreateDataParameter("@KPI_POOL_VER_ID", SqlDbType.Int);
            paramArray[3].Value = kpi_pool_ver_id;
            paramArray[4] = CreateDataParameter("@KPI_POOL_TEMPLETE_ID", SqlDbType.Int);
            paramArray[4].Value = kpi_pool_templete_id;
            paramArray[5] = CreateDataParameter("@STG_REF_ID", SqlDbType.VarChar);
            paramArray[5].Value = STG_REF_ID;
            paramArray[6] = CreateDataParameter("@KPI_EXTERNAL_TYPE", SqlDbType.VarChar);
            paramArray[6].Value = KPI_EXTERNAL_TYPE;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_KPI_POOL", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }
        #endregion

        public void SetKpiTempleteInsert()
        {
            string qry = @"INSERT INTO BSC_KPI_POOL_TEMPLETE
            SELECT MAX(VIEW_REF_ID), STG_REF_ID, 'Y', 1000, SYSDATE, NULL, NULL 
              FROM BSC_MAP_STG  
             WHERE ESTTERM_REF_ID IN ( SELECT ESTTERM_REF_ID FROM  EST_TERM_INFO   
                                       WHERE EST_STATUS = 1)     
             GROUP BY STG_REF_ID;";
            DbAgentObj.ExecuteNonQuery(qry);
        }

        #region BSC_KPI_POOL_INFO SELECT
        public DataTable GETBscKpiPoolInfo(int KPI_POOL_REF_ID)
        {
            string qry = @"SELECT * FROM BSC_KPI_POOL_INFO WHERE KPI_POOL_REF_ID = @KPI_POOL_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            return DbAgentObj.FillDataSet(qry, "Pool", null, paramArray, CommandType.Text).Tables[0];
        }
        #endregion

        #region BSC_KPI_POOL_INFO INSERT
        public void SetBscKpiPoolInfo(int KPI_POOL_REF_ID
            , string WORD_DEFINITION
            , string CALC_FORM_MS
            , string CALC_FORM_TS
            , string RESULT_TERM_TYPE
            , string RESULT_ACHIEVEMENT_TYPE
            , string RESULT_TS_CALC_TYPE
            , string RESULT_MEASUREMENT_STEP
            , string MEASUREMENT_GRADE_TYPE
            , string UNIT_TYPE_REF_ID
            , string USE_YN
            , int CREATE_USER)
        {
            string qry = @"INSERT INTO BSC_KPI_POOL_INFO
                            (
                                 KPI_POOL_REF_ID          
                                ,WORD_DEFINITION              
                                ,CALC_FORM_MS            
                                ,CALC_FORM_TS            
                                ,RESULT_TERM_TYPE        
                                ,RESULT_ACHIEVEMENT_TYPE 
                                ,RESULT_TS_CALC_TYPE     
                                ,RESULT_MEASUREMENT_STEP 
                                ,MEASUREMENT_GRADE_TYPE  
                                ,UNIT_TYPE_REF_ID        
                                ,USE_YN                  
                                ,CREATE_DATE             
                                ,CREATE_USER             
                            )
                            values(
                                 @KPI_POOL_REF_ID
                                ,@WORD_DEFINITION              
                                ,@CALC_FORM_MS            
                                ,@CALC_FORM_TS            
                                ,@RESULT_TERM_TYPE        
                                ,@RESULT_ACHIEVEMENT_TYPE 
                                ,@RESULT_TS_CALC_TYPE     
                                ,@RESULT_MEASUREMENT_STEP 
                                ,@MEASUREMENT_GRADE_TYPE  
                                ,@UNIT_TYPE_REF_ID        
                                ,@USE_YN                  
                                ,sysdate             
                                ,@CREATE_USER            
                        )";
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;

            paramArray[1] = CreateDataParameter("@WORD_DEFINITION", SqlDbType.Text);
            paramArray[1].Value = WORD_DEFINITION;

            paramArray[2] = CreateDataParameter("@CALC_FORM_MS", SqlDbType.VarChar);
            paramArray[2].Value = CALC_FORM_MS;

            paramArray[3] = CreateDataParameter("@CALC_FORM_TS", SqlDbType.VarChar);
            paramArray[3].Value = CALC_FORM_TS;

            paramArray[4] = CreateDataParameter("@RESULT_TERM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = RESULT_TERM_TYPE;

            paramArray[5] = CreateDataParameter("@RESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = RESULT_ACHIEVEMENT_TYPE;

            paramArray[6] = CreateDataParameter("@RESULT_TS_CALC_TYPE", SqlDbType.VarChar);
            paramArray[6].Value = RESULT_TS_CALC_TYPE;

            paramArray[7] = CreateDataParameter("@RESULT_MEASUREMENT_STEP", SqlDbType.VarChar);
            paramArray[7].Value = RESULT_MEASUREMENT_STEP;

            paramArray[8] = CreateDataParameter("@MEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[8].Value = MEASUREMENT_GRADE_TYPE;

            paramArray[9] = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[9].Value = UNIT_TYPE_REF_ID;

            paramArray[10] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[10].Value = USE_YN;

            paramArray[11] = CreateDataParameter("@CREATE_USER", SqlDbType.VarChar);
            paramArray[11].Value = CREATE_USER;

            DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }
        #endregion

        #region BSC_KPI_POOL_INFO UPDATE
        public void SetBscKpiPoolInfo_UPDATE(int KPI_POOL_REF_ID
          , string WORD_DEFINITION
          , string CALC_FORM_MS
          , string CALC_FORM_TS
          , string RESULT_TERM_TYPE
          , string RESULT_ACHIEVEMENT_TYPE
          , string RESULT_TS_CALC_TYPE
          , string RESULT_MEASUREMENT_STEP
          , string MEASUREMENT_GRADE_TYPE
          , string UNIT_TYPE_REF_ID
          , string USE_YN
          , int UPDATE_USER)
        {
            string qry = @"UPDATE BSC_KPI_POOL_INFO SET
                             WORD_DEFINITION = @WORD_DEFINITION                
                            ,CALC_FORM_MS = @CALC_FORM_MS            
                            ,CALC_FORM_TS = @CALC_FORM_TS       
                            ,RESULT_TERM_TYPE = @RESULT_TERM_TYPE        
                            ,RESULT_ACHIEVEMENT_TYPE = @RESULT_ACHIEVEMENT_TYPE 
                            ,RESULT_TS_CALC_TYPE = @RESULT_TS_CALC_TYPE
                            ,RESULT_MEASUREMENT_STEP = @RESULT_MEASUREMENT_STEP 
                            ,MEASUREMENT_GRADE_TYPE = @MEASUREMENT_GRADE_TYPE  
                            ,UNIT_TYPE_REF_ID = @UNIT_TYPE_REF_ID        
                            ,USE_YN = @USE_YN
                            ,UPDATE_DATE = SYSDATE
                            ,UPDATE_USER = @UPDATE_USER 
                        WHERE KPI_POOL_REF_ID = @KPI_POOL_REF_ID            
                        ";
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;

            paramArray[1] = CreateDataParameter("@WORD_DEFINITION", SqlDbType.Text);
            paramArray[1].Value = WORD_DEFINITION;

            paramArray[2] = CreateDataParameter("@CALC_FORM_MS", SqlDbType.VarChar);
            paramArray[2].Value = CALC_FORM_MS;

            paramArray[3] = CreateDataParameter("@CALC_FORM_TS", SqlDbType.VarChar);
            paramArray[3].Value = CALC_FORM_TS;

            paramArray[4] = CreateDataParameter("@RESULT_TERM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = RESULT_TERM_TYPE;

            paramArray[5] = CreateDataParameter("@RESULT_ACHIEVEMENT_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = RESULT_ACHIEVEMENT_TYPE;

            paramArray[6] = CreateDataParameter("@RESULT_TS_CALC_TYPE", SqlDbType.VarChar);
            paramArray[6].Value = RESULT_TS_CALC_TYPE;

            paramArray[7] = CreateDataParameter("@RESULT_MEASUREMENT_STEP", SqlDbType.VarChar);
            paramArray[7].Value = RESULT_MEASUREMENT_STEP;

            paramArray[8] = CreateDataParameter("@MEASUREMENT_GRADE_TYPE", SqlDbType.VarChar);
            paramArray[8].Value = MEASUREMENT_GRADE_TYPE;

            paramArray[9] = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[9].Value = UNIT_TYPE_REF_ID;

            paramArray[10] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[10].Value = USE_YN;

            paramArray[11] = CreateDataParameter("@UPDATE_USER", SqlDbType.VarChar);
            paramArray[11].Value = UPDATE_USER;

            DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }
        #endregion

        public void SetKpiPoolTerm(int KPI_POOL_REF_ID, string YMD_MM, string CHECK_YN, int CREATE_USER)
        {
            string qry = @"INSERT INTO BSC_KPI_POOL_TERM(KPI_POOL_REF_ID, YMD_MM, CHECK_YN, CREATE_DATE, CREATE_USER)
                           VALUES(@KPI_POOL_REF_ID, @YMD_MM, @CHECK_YN, SYSDATE, @CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            paramArray[1] = CreateDataParameter("@YMD_MM", SqlDbType.Text);
            paramArray[1].Value = YMD_MM;
            paramArray[2] = CreateDataParameter("@CHECK_YN", SqlDbType.Text);
            paramArray[2].Value = CHECK_YN;
            paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.Text);
            paramArray[3].Value = CREATE_USER;

            DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public void SetKpiPoolTerm_Update(int KPI_POOL_REF_ID, string YMD_MM, string CHECK_YN, int CREATE_USER)
        {
            string qry = @"UPDATE BSC_KPI_POOL_TERM SET 
                            CHECK_YN = @CHECK_YN,
                            UPDATE_DATE = SYSDATE,
                            UPDATE_USER = @UPDATE_USER
                            WHERE KPI_POOL_REF_ID = @KPI_POOL_REF_ID AND YMD_MM = @YMD_MM";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            paramArray[1] = CreateDataParameter("@YMD_MM", SqlDbType.Text);
            paramArray[1].Value = YMD_MM;
            paramArray[2] = CreateDataParameter("@CHECK_YN", SqlDbType.Text);
            paramArray[2].Value = CHECK_YN;
            paramArray[3] = CreateDataParameter("@UPDATE_USER", SqlDbType.Text);
            paramArray[3].Value = CREATE_USER;

            DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public DataTable GetKpiPoolTerm(int KPI_POOL_REF_ID)
        {

            string query = @"SELECT * FROM BSC_KPI_POOL_TERM WHERE KPI_POOL_REF_ID = @KPI_POOL_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;

            DataTable dt = DbAgentObj.FillDataSet(query, "POOL_TERM", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        #region 공통코드 가져오기
        public DataTable GetCommonCode(string code)
        {
            DataTable dt = new DataTable();
            if (code != null && code != "")
            {
                string qry = "SELECT ETC_CODE, CODE_NAME FROM COM_CODE_INFO WHERE CATEGORY_CODE = @code AND USE_YN = 'Y'";
                IDbDataParameter[] paramArray = CreateDataParameters(1);
                paramArray[0] = CreateDataParameter("@code", SqlDbType.VarChar);
                paramArray[0].Value = code;
                dt = DbAgentObj.FillDataSet(qry, "CommonCode", null, paramArray, CommandType.Text).Tables[0];
            }
            return dt;

        }
        public DataTable GetCommonCode()
        {
            DataTable dt = new DataTable();
            string qry = "SELECT UNIT_TYPE_REF_ID, UNIT_TYPE FROM COM_UNIT_TYPE_INFO";
            dt = DbAgentObj.FillDataSet(qry, "CommonCode", null, null, CommandType.Text).Tables[0];
            return dt;

        }
        #endregion

        public DataTable GetThreadHold()
        {
            DataTable dt = new DataTable();
            string qry = "SELECT UNIT_TYPE_REF_ID, UNIT_TYPE FROM COM_UNIT_TYPE_INFO";
            dt = DbAgentObj.FillDataSet(qry, "CommonCode", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        public DataSet SelectkpiThresholdInfo(int KPI_POOL_REF_ID, string Level)
        {

            string strQuery = @"
                SELECT  
                 C.THRESHOLD_ENAME AS SIGNAL
                ,C.IMAGE_FILE_NAME AS IMAG_PATH
                ,C.THRESHOLD_KNAME AS THRS_DESC
                ,A.SET_MIN_VALUE
                ,A.ACHIEVE_RATE
                ,B.POINT
                ,B.BASE_LINE_YN     
                ,A.KPI_POOL_REF_ID 
                ,A.THRESHOLD_REF_ID
                ,A.THRESHOLD_LEVEL
                  FROM BSC_KPI_POOL_THRESHOLD A
                       LEFT JOIN BSC_THRESHOLD_STEP B
                         ON A.THRESHOLD_LEVEL = B.THRESHOLD_LEVEL
                        AND A.THRESHOLD_REF_ID = B.THRESHOLD_REF_ID
                       INNER JOIN BSC_THRESHOLD_CODE C
                         ON B.THRESHOLD_REF_ID = C.THRESHOLD_REF_ID
                         AND USE_YN = 'Y'
                 WHERE A.KPI_POOL_REF_ID = @KPI_POOL_REF_ID  AND A.THRESHOLD_LEVEL = @THRESHOLD_LEVEL
                ";
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            paramArray[1] = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[1].Value = Level;
            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectkpiThresholdInfo(int KPI_POOL_REF_ID)
        {

            string strQuery = @"
                SELECT  
                 C.THRESHOLD_ENAME AS SIGNAL
                ,C.IMAGE_FILE_NAME AS IMAG_PATH
                ,C.THRESHOLD_KNAME AS THRS_DESC
                ,A.SET_MIN_VALUE
                ,A.ACHIEVE_RATE
                ,B.POINT
                ,B.BASE_LINE_YN     
                ,A.KPI_POOL_REF_ID 
                ,A.THRESHOLD_REF_ID
                ,A.THRESHOLD_LEVEL
                  FROM BSC_KPI_POOL_THRESHOLD A
                       LEFT JOIN BSC_THRESHOLD_STEP B
                         ON A.THRESHOLD_LEVEL = B.THRESHOLD_LEVEL
                        AND A.THRESHOLD_REF_ID = B.THRESHOLD_REF_ID
                       INNER JOIN BSC_THRESHOLD_CODE C
                         ON B.THRESHOLD_REF_ID = C.THRESHOLD_REF_ID
                         AND USE_YN = 'Y'
                 WHERE A.KPI_POOL_REF_ID = @KPI_POOL_REF_ID 
                 ORDER BY C.THRESHOLD_REF_ID
                ";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet SelectSignalListPerKpiWithStep(int KPI_POOL_REF_ID, string ithreshold_level)
        {
            string strQuery = @"

   
         SELECT TC.THRESHOLD_ENAME   as SIGNAL
               ,TC.IMAGE_FILE_NAME   as IMAG_PATH
               ,TC.THRESHOLD_KNAME   as THRS_DESC
               ,0                    as SET_MIN_VALUE
               ,0.00                 as ACHIEVE_RATE 
               ,TS.POINT             as POINT
               ,TS.BASE_LINE_YN      as BASE_LINE_YN
               ,@KPI_POOL_REF_ID         as KPI_REF_ID
               ,TC.THRESHOLD_REF_ID  as THRESHOLD_REF_ID
               ,TS.THRESHOLD_LEVEL   as THRESHOLD_LEVEL
           FROM BSC_THRESHOLD_CODE TC
                LEFT JOIN BSC_THRESHOLD_STEP TS
                  ON TC.THRESHOLD_REF_ID = TS.THRESHOLD_REF_ID
          WHERE TS.THRESHOLD_LEVEL       = @iTHRESHOLD_LEVEL  
          ORDER BY TS.SEQUENCE
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            paramArray[1] = CreateDataParameter("@iTHRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[1].Value = ithreshold_level;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_THRESHOLD_INFO", null, paramArray, CommandType.Text);
            return ds;
        }

        public void GetThreadHoldInsert(int KPI_POOL_REF_ID, int THRESHOLD_REF_ID,
            string THRESHOLD_LEVEL, double SET_MIN_VALUE, double ACHIEVE_RATE, int CREATE_USER)
        {
            string qry = @"
                INSERT INTO BSC_KPI_POOL_THRESHOLD(KPI_POOL_REF_ID, THRESHOLD_REF_ID, THRESHOLD_LEVEL, SET_MIN_VALUE,ACHIEVE_RATE, CREATE_DATE, CREATE_USER)
                VALUES(@KPI_POOL_REF_ID, @THRESHOLD_REF_ID, @THRESHOLD_LEVEL, @SET_MIN_VALUE, @ACHIEVE_RATE, SYSDATE, @CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            paramArray[1] = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[1].Value = THRESHOLD_REF_ID;
            paramArray[2] = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[2].Value = THRESHOLD_LEVEL;
            paramArray[3] = CreateDataParameter("@SET_MIN_VALUE", SqlDbType.Decimal);
            paramArray[3].Value = SET_MIN_VALUE;
            paramArray[4] = CreateDataParameter("@ACHIEVE_RATE", SqlDbType.Decimal);
            paramArray[4].Value = ACHIEVE_RATE;
            paramArray[5] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[5].Value = CREATE_USER;
            DbAgentObj.ExecuteNonQuery(qry, paramArray);

        }


        public void GetThreadHoldDelete(int KPI_POOL_REF_ID)
        {
            string qry = "DELETE FROM BSC_KPI_POOL_THRESHOLD WHERE KPI_POOL_REF_ID = @KPI_POOL_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = KPI_POOL_REF_ID;
            DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public void KpiPoolMapEdit(int STG_REF_ID, int VIEW_REF_ID)
        {
            string qry = "UPDATE BSC_KPI_POOL_MAP SET USE_YN = (CASE USE_YN WHEN 'Y' THEN 'N' ELSE 'Y' END) WHERE STG_REF_ID = @STG_REF_ID AND VIEW_REF_ID = @VIEW_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[0].Value = STG_REF_ID;
            paramArray[1] = CreateDataParameter("@VIEW_REF_ID", SqlDbType.Int);
            paramArray[1].Value = VIEW_REF_ID;
            DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public DataTable KpiPoolMapFirstSelect()
        {
            string qry = @"SELECT DISTINCT MAP.VIEW_REF_ID, VI.VIEW_NAME FROM BSC_KPI_POOL_MAP MAP 
                                JOIN BSC_VIEW_INFO VI ON MAP.VIEW_REF_ID = VI.VIEW_REF_ID
                           -- WHERE MAP.USE_YN = 'Y'
                            ORDER BY MAP.VIEW_REF_ID ";

            DataTable dt = DbAgentObj.FillDataSet(qry, "map", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable KpiPoolMapSecondSelect()
        {
            string qry = @"SELECT MAP.VIEW_REF_ID, MAP.STG_REF_ID, VI.VIEW_NAME,STG.STG_NAME 
                            FROM BSC_KPI_POOL_MAP MAP 
                                JOIN BSC_STG_INFO STG ON MAP.STG_REF_ID = STG.STG_REF_ID
                                JOIN BSC_VIEW_INFO VI ON MAP.VIEW_REF_ID = VI.VIEW_REF_ID
                           -- WHERE MAP.USE_YN = 'Y' 
                            ORDER BY VIEW_REF_ID, STG_REF_ID";

            DataTable dt = DbAgentObj.FillDataSet(qry, "map", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable KpiPoolMapThirdSelect()
        {
            //            string qry = @"SELECT STG_REF_ID, KPI_NAME, KPI_POOL_REF_ID FROM BSC_KPI_POOL WHERE STG_REF_ID IN 
            //                            ( 
            //                                SELECT STG_REF_ID FROM BSC_STG_INFO WHERE ESTTERM_REF_ID = (SELECT MAX(ESTTERM_REF_ID) FROM EST_TERM_INFO WHERE EST_STATUS = '1')
            //                            ) ";
            string qry = @"SELECT STG_REF_ID, KPI_NAME, KPI_POOL_REF_ID FROM BSC_KPI_POOL";
            IDbDataParameter[] paramArray = CreateDataParameters(0);

            DataTable dt = DbAgentObj.FillDataSet(qry, "map", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable CoporationKpiTempleteList()
        {
            string qry = @"SELECT 
                             KPI.KPI_POOL_REF_ID ,
                             KPI.KPI_NAME,
                             STG.STG_REF_ID,
                             STG.STG_NAME,
                             VI.VIEW_REF_ID,
                             VI.VIEW_NAME,
                             STG.ESTTERM_REF_ID
                            FROM 
                            BSC_KPI_POOL KPI
                            LEFT JOIN BSC_STG_INFO STG ON KPI.STG_REF_ID = STG.STG_REF_ID
                            LEFT JOIN BSC_VIEW_INFO VI ON VI.VIEW_REF_ID = STG.VIEW_REF_ID
                            WHERE KPI.STG_REF_ID IN (SELECT STG_REF_ID FROM BSC_KPI_POOL_MAP MAP WHERE USE_YN = 'Y') AND STG.ESTTERM_REF_ID = (SELECT MAX(ESTTERM_REF_ID) FROM EST_TERM_INFO WHERE EST_STATUS = '1') ORDER BY VI.VIEW_SEQ, STG.STG_NAME, KPI.KPI_NAME";

            DataTable dt = DbAgentObj.FillDataSet(qry, "map", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable CoporationKpiList()
        {
            string qry = @"SELECT 
                             KPI.KPI_POOL_REF_ID ,
                             KPI.KPI_NAME,
                             STG.STG_REF_ID,
                             STG.STG_NAME,
                             VI.VIEW_REF_ID,
                             VI.VIEW_NAME, STG.ESTTERM_REF_ID,
                             KPI_EXTERNAL_TYPE
                            FROM 
                            BSC_KPI_POOL KPI
                            LEFT JOIN BSC_STG_INFO STG ON KPI.STG_REF_ID = STG.STG_REF_ID
                            LEFT JOIN BSC_VIEW_INFO VI ON VI.VIEW_REF_ID = STG.VIEW_REF_ID
                            WHERE STG.ESTTERM_REF_ID = (SELECT MAX(ESTTERM_REF_ID) FROM EST_TERM_INFO WHERE EST_STATUS = '1') ORDER BY VI.VIEW_SEQ, STG.STG_NAME, KPI.KPI_NAME";

            DataTable dt = DbAgentObj.FillDataSet(qry, "map", null, null, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable AllInsertKpiList(string ESTTERM_REF_ID, string KPI_NAME)
        {
            string qry = @"SELECT A.KPI_POOL_REF_ID, A.KPI_NAME, ISNULL(TA.KPI_CNT, 0) AS KPI_CNT
                                        ,B.TARGET_SUB_EMP, B.RESULT_SUB_EMP , a.stg_ref_id, aa.view_ref_id
                                        , (SELECT EMP_NAME FROM COM_EMP_INFO WHERE EMP_REF_ID = B.TARGET_SUB_EMP) AS TARGET_SUB_EMP_NAME
                                        , (SELECT EMP_NAME FROM COM_EMP_INFO WHERE EMP_REF_ID = B.RESULT_SUB_EMP) AS RESULT_SUB_EMP_NAME
                                  FROM BSC_KPI_POOL A
                                       LEFT JOIN ( SELECT KPI_POOL_REF_ID    AS KPI_POOL_REF_ID
                                                          ,COUNT(KPI_REF_ID) AS KPI_CNT
                                                     FROM BSC_KPI_INFO
                                                    WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID -- 평가기간
                                                      AND IS_TEAM_KPI = 'Y'                -- 조직KPI
                                                      AND USE_YN = 'Y'
                                                      AND ISDELETE = 'N'
                                                    GROUP BY KPI_POOL_REF_ID
                                                  ) TA
                                              ON A.KPI_POOL_REF_ID = TA.KPI_POOL_REF_ID
                                       LEFT JOIN BSC_KPI_POOL_SUBEMP B
                                         ON A.KPI_POOL_REF_ID = B.KPI_POOL_REF_ID
                                        LEFT JOIN BSC_STG_INFO AA
                                         ON A.STG_REF_ID = AA.STG_REF_ID
                                        AND AA.ESTTERM_REF_ID = @ESTTERM_REF_ID
                                 WHERE A.USE_YN = 'Y' AND A.KPI_NAME LIKE '%' + @KPI_NAME + '%'";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = ESTTERM_REF_ID;
            paramArray[1] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[1].Value = KPI_NAME;
            DataTable dt = DbAgentObj.FillDataSet(qry, "map", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public int AllTargetInsert(int emp_no, int pool_ref_id)
        {
            string qry = @"UPDATE BSC_KPI_POOL_SUBEMP SET TARGET_SUB_EMP = @TARGET_SUB_EMP WHERE KPI_POOL_REF_ID = @KPI_POOL_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@TARGET_SUB_EMP", SqlDbType.Int);
            paramArray[0].Value = emp_no;
            paramArray[1] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = pool_ref_id;
            return DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public int AllResultInsert(int emp_no, int pool_ref_id)
        {
            string qry = @"UPDATE BSC_KPI_POOL_SUBEMP SET RESULT_SUB_EMP = @RESULT_SUB_EMP WHERE KPI_POOL_REF_ID = @KPI_POOL_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@RESULT_SUB_EMP", SqlDbType.Int);
            paramArray[0].Value = emp_no;
            paramArray[1] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.VarChar);
            paramArray[1].Value = pool_ref_id;
            return DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

        public DataTable KpiCreateDeptList(int kpi_pool_ref_id)
        {
            string qry = @"SELECT A.KPI_POOL_REF_ID, A.KPI_NAME, B.KPI_REF_ID
                                        ,B.CHAMPION_EMP_ID, D.DEPT_NAME  ,E.EMP_NAME  
                                  FROM BSC_KPI_POOL A 
                                       LEFT JOIN BSC_KPI_INFO B
                                         ON A.KPI_POOL_REF_ID = B.KPI_POOL_REF_ID
                                        AND B.USE_YN = 'Y'
                                        AND B.ISDELETE = 'N'
                                        AND B.IS_TEAM_KPI = 'Y'   -- 조직KPI
                                       LEFT JOIN REL_DEPT_EMP C
                                         ON B.CHAMPION_EMP_ID = C.EMP_REF_ID
                                       LEFT JOIN COM_DEPT_INFO D
                                         ON C.DEPT_REF_ID = D.DEPT_REF_ID
                                       LEFT JOIN COM_EMP_INFO E
                                         ON C.EMP_REF_ID = E.EMP_REF_ID
                                 WHERE A.KPI_POOL_REF_ID = @KPI_POOL_REF_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@KPI_POOL_REF_ID", SqlDbType.Int);
            paramArray[0].Value = kpi_pool_ref_id;
            return DbAgentObj.FillDataSet(qry, "pool", null, paramArray, CommandType.Text).Tables[0];
        }

        public int KpiCreateDeptRemove(int kpi_ref_id)
        {
            string qry = "UPDATE BSC_KPI_INFO SET USE_YN = 'N' WHERE KPI_REF_ID = @KPI_REF_ID ";
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = kpi_ref_id;
            return DbAgentObj.ExecuteNonQuery(qry, paramArray);
        }

    }
}
