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
/// Biz_Bsc_Kpi_Term의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		: Biz_Bsc_Kpi_Info Biz 클래스
/// Class 내용		: Bsc_Kpi_Info Biz Logic 처리 
///                 : 웹단에서 콜하여 처리하는 부분은 본 페이지의 함수를 호출한다.
///                 : 본페이지의 함수는 Dac단의 함수를 콜하여 쓰는데 트랜잭션 처리를 수행하도록 구성한다.
/// 작성자			: 방병현
/// 최초작성일		: 2007.04.26
/// 최종수정자		:
/// 최종수정일		:
/// Services		:
/// 주요변경로그	:
/// ----------------------------------------------------------
/// </summary>
/// 
namespace MicroBSC.Integration.BSC.Biz
{
    public class Biz_Bsc_Kpi_Pool
    {
        public Biz_Bsc_Kpi_Pool() { }


        #region 리스트
        public DataTable GetKpiPool_DB(string kpi_name
                                    , string use_yn
                                    , string kpi_group_ref_id
                                    , int kpi_pool_ver_id
                                    , int kpi_pool_templete_id
                                    , int STG_REF_ID, string KPI_EXTERNAL_TYPE)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool dacBscKpiPool = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool();
            return dacBscKpiPool.SelectData_DB(kpi_name
                                                , use_yn
                                                , kpi_group_ref_id
                                                , kpi_pool_ver_id
                                                , kpi_pool_templete_id
                                                , STG_REF_ID, KPI_EXTERNAL_TYPE);
        }

        public DataTable GetKpiPool_DB(string kpi_name
                                    , string use_yn
                                    , string kpi_group_ref_id
                                    , int kpi_pool_ver_id
                                    , int kpi_pool_templete_id)
        {
            MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool dacBscKpiPool = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool();
            return dacBscKpiPool.SelectData_DB(kpi_name
                                                , use_yn
                                                , kpi_group_ref_id
                                                , kpi_pool_ver_id
                                                , kpi_pool_templete_id
                                                );
        }
        #endregion

        public void SetKpiTempleteInsert()
        {
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SetKpiTempleteInsert();
        }

        public DataTable GETBscKpiPoolInfo(int KPI_POOL_REF_ID)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().GETBscKpiPoolInfo(KPI_POOL_REF_ID);
        }

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
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SetBscKpiPoolInfo(KPI_POOL_REF_ID
           , WORD_DEFINITION
           , CALC_FORM_MS
           , CALC_FORM_TS
           , RESULT_TERM_TYPE
           , RESULT_ACHIEVEMENT_TYPE
           , RESULT_TS_CALC_TYPE
           , RESULT_MEASUREMENT_STEP
           , MEASUREMENT_GRADE_TYPE
           , UNIT_TYPE_REF_ID
           , USE_YN
           , CREATE_USER);
        }

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
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SetBscKpiPoolInfo_UPDATE(KPI_POOL_REF_ID
                              , WORD_DEFINITION
                              , CALC_FORM_MS
                              , CALC_FORM_TS
                              , RESULT_TERM_TYPE
                              , RESULT_ACHIEVEMENT_TYPE
                              , RESULT_TS_CALC_TYPE
                              , RESULT_MEASUREMENT_STEP
                              , MEASUREMENT_GRADE_TYPE
                              , UNIT_TYPE_REF_ID
                              , USE_YN
                              , UPDATE_USER);
        }

        public void SetKpiPoolTerm(int KPI_POOL_REF_ID, string YMD_MM, string CHECK_YN, int CREATE_USER)
        {
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, YMD_MM, CHECK_YN, CREATE_USER);
        }

        public void SetKpiPoolTerm_Update(int KPI_POOL_REF_ID, string YMD_MM, string CHECK_YN, int UPDATE_USER)
        {
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, YMD_MM, CHECK_YN, UPDATE_USER);
        }

        public DataTable GetKpiPoolTerm(int KPI_POOL_REF_ID)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().GetKpiPoolTerm(KPI_POOL_REF_ID);
        }

        public DataSet GetSignalListPerKpiWithBiz(int KPI_POOL_REF_ID, string ithreshold_level)
        {
            DataSet dsReturn = null;
            DataTable dtTreshold = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SelectkpiThresholdInfo(KPI_POOL_REF_ID, ithreshold_level).Tables[0];
            if (dtTreshold == null || dtTreshold.Rows.Count == 0)
            {
                dsReturn = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SelectSignalListPerKpiWithStep(KPI_POOL_REF_ID, ithreshold_level);
            }
            else
            {
                dsReturn = new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().SelectkpiThresholdInfo(KPI_POOL_REF_ID);
            }

            return dsReturn;
        }

        public void GetThreadHoldInsert(int KPI_POOL_REF_ID, int THRESHOLD_REF_ID,
            string THRESHOLD_LEVEL, double SET_MIN_VALUE, double ACHIEVE_RATE, int CREATE_USER)
        {
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().GetThreadHoldInsert(KPI_POOL_REF_ID, THRESHOLD_REF_ID,
            THRESHOLD_LEVEL, SET_MIN_VALUE, ACHIEVE_RATE, CREATE_USER);
        }

        public void GetThreadHoldDelete(int KPI_POOL_REF_ID)
        {
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().GetThreadHoldDelete(KPI_POOL_REF_ID);
        }

        public void KpiPoolMapEdit(int STG_REF_ID, int VIEW_REF_ID)
        {
            new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().KpiPoolMapEdit(STG_REF_ID, VIEW_REF_ID);
        }

        public DataTable KpiPoolMapFirstSelect()
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().KpiPoolMapFirstSelect();
        }

        public DataTable KpiPoolMapSecondSelect()
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().KpiPoolMapSecondSelect();
        }

        public DataTable KpiPoolMapThirdSelect()
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().KpiPoolMapThirdSelect();
        }

        public DataTable CoporationKpiTempleteList()
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().CoporationKpiTempleteList();
        }

        public DataTable CoporationKpiList()
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().CoporationKpiList();
        }

        public DataTable AllInsertKpiList(string ESTTERM_REF_ID, string KPI_NAME)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().AllInsertKpiList(ESTTERM_REF_ID, KPI_NAME);
        }

        public int AllTargetInsert(int emp_no, int pool_ref_id)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().AllTargetInsert(emp_no, pool_ref_id);
        }

        public int AllResultInsert(int emp_no, int pool_ref_id)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().AllResultInsert(emp_no, pool_ref_id);
        }

        public DataTable KpiCreateDeptList(int kpi_pool_ref_id)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().KpiCreateDeptList(kpi_pool_ref_id);
        }

        public int KpiCreateDeptRemove(int kpi_ref_id)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().KpiCreateDeptRemove(kpi_ref_id);
        }

        #region 공통코드 가져오기
        public DataTable GetCommonCode(string code)
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().GetCommonCode(code);
        }
        public DataTable GetCommonCode()
        {
            return new MicroBSC.Integration.BSC.Dac.Dac_Bsc_Kpi_Pool().GetCommonCode();
        }
        #endregion
    }
}
