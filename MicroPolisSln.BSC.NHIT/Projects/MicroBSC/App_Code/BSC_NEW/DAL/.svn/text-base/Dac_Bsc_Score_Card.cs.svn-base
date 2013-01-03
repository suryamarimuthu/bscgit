using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

/// <summary>
/// Dac_Bsc_Score_Card의 요약 설명입니다.
/// </summary>
/// 

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Score_Card : DbAgentBase
    {
        public Dac_Bsc_Score_Card() { }

        /// <summary>
        /// 내부평가점수 조직유형별 부서순위조회 
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="idept_type"></param>
        /// <param name="isum_type"></param>
        /// <returns></returns>
        public DataSet GetEstDeptRankList(int iestterm_ref_id, string iymd, int idept_type, string isum_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "ER";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value         = idept_type;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_ESTDEPT_RANK"),"SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 내부평가점수 부서순위조회 (하위조직 포함 순위하기)
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="idept_type"></param>
        /// <param name="isum_type"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <param name="iselecttype"></param>
        /// <param name="itxr_user"></param>
        /// <returns></returns>
        public DataSet GetEstDeptRankList(int iestterm_ref_id, string iymd, int idept_type, string isum_type
                                        , int iest_dept_ref_id, string iselecttype, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "ER";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value         = idept_type;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;
            paramArray[5]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = iest_dept_ref_id;
            paramArray[6]               = CreateDataParameter("@iSELECT_TYPE", SqlDbType.VarChar);
            paramArray[6].Value         = iselecttype;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_ESTDEPT_RANK"), "SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 외부평가를 포함한 조직 순위구하기
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간</param>
        /// <param name="iymd">평가년월</param>
        /// <param name="idept_type">조직유형</param>
        /// <param name="isum_type">누계유형</param>
        /// <param name="iest_dept_ref_id">조직ID</param>
        /// <param name="iselecttype">하위조직포함여부</param>
        /// <param name="includeExtScore">외부평가점수 반영여부</param>
        /// <param name="itxr_user">조회자</param>
        /// <returns></returns>
        public DataSet GetEstDeptRankList(int iestterm_ref_id, string iymd, int idept_type, string isum_type
                                        , int iest_dept_ref_id, string iselecttype, bool includeExtScore, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "KE";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value         = idept_type;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;
            paramArray[5]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = iest_dept_ref_id;
            paramArray[6]               = CreateDataParameter("@iSELECT_TYPE", SqlDbType.VarChar);
            paramArray[6].Value         = iselecttype;
	        paramArray[7] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[7].Value 	    = itxr_user;

            DataSet ds = new DataSet();
            if (includeExtScore)
            {
                ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_ESTDEPT_RANK_EXT"), "SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
            }
            else
            { 
                ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_ESTDEPT_RANK"), "SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
            }

            return ds;
        }

        public DataSet GetEstDeptKpiScoreList(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S2";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_SCORE_ESTDEPT"),"SELECT_SCORE_ESTDEPT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptKpiScoreList_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S2";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_GOAL.PROC_SELECT_SCORE_ESTDEPT"),"SELECT_SCORE_ESTDEPT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptKpiViewTypeList(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S3";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_VIEW_WEIGHT"),"SELECT_VIEW_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptKpiViewTypeList_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S3";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_GOAL.PROC_SELECT_VIEW_WEIGHT"),"SELECT_VIEW_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetScorePerStrategy(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S7";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_STG_WEIGHT"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetScorePerStrategy_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S7";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_GOAL.PROC_SELECT_STG_WEIGHT"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 부서점수 리턴
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <returns></returns>
        public DataSet GetEstDeptTotalScore(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S4";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = isum_type;
            paramArray[4] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
            //return ds;
        }

        public DataSet GetEstDeptTotalScore_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S4";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = isum_type;
            paramArray[4] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_GOAL.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
            //return ds;
        }

        /// <summary>
        /// 부서점수 리턴 (점수)
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <returns></returns>
        public string GetEstDeptTotalScoreOnly(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S4";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3]       = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = isum_type;
            paramArray[4]       = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);

            string sSig = "";
            string sRtn = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                sSig = ds.Tables[0].Rows[0]["DEPT_SIGNAL"].ToString();
                sRtn = (sSig=="-") ? "-" : ds.Tables[0].Rows[0]["POINT"].ToString();
            }
            else
            {
                sRtn = "-";
            }

            return sRtn;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
            //return ds;
        }

        /// <summary>
        /// 부서점수 리턴 (점수)
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <returns></returns>
        public string GetEstDeptTotalScoreOnly_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S4";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2]       = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3]       = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = isum_type;
            paramArray[4]       = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_GOAL.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);

            string sSig = "";
            string sRtn = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                sSig = ds.Tables[0].Rows[0]["DEPT_SIGNAL"].ToString();
                sRtn = (sSig=="-") ? "-" : ds.Tables[0].Rows[0]["POINT"].ToString();
            }
            else
            {
                sRtn = "-";
            }

            return sRtn;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
            //return ds;
        }

        public DataSet GetEstDeptTotalScoreForMap(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S6";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_MAP_DEPT_SCORE"),"SELECT_MAP_DEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiDetailStatusForMap(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {            
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S8";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_DEPT_KPI_SCORE"),"SELECT_DEPT_KPI_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiGradeStatusForMap(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {            
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S9";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD.PROC_SELECT_KPI_GRADE"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiGradeStatusForMap_Goal(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {            
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S9";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isum_type;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_GOAL.PROC_SELECT_KPI_GRADE"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetYearlyTotalScoreTrend(int iestterm_ref_id, int idept_type, string isumtype, int iest_dept_ref_id, string iselecttype, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            
            paramArray[0]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iest_dept_ref_id;
            paramArray[2]               = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[2].Value         = idept_type;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isumtype;
            paramArray[4]               = CreateDataParameter("@iSELECT_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = iselecttype;
            paramArray[5]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[5].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_TREND", "PKG_BSC_SCORE_CARD_TREND.PROC_SCORE_CARD_TREND"), "SCORE_CARD_TREND", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 전체지표 등급현황
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isum_type"></param>
        /// <param name="iest_dept_ref_id"></param>
        /// <returns></returns>
        public DataSet GetKpiEntGradeStatus(string isymd, string ieymd, string isum_type, int iest_dept_ref_id)
        {
            string sSQL =
              @"SELECT TD.YMD, TD.THRESHOLD_REF_ID, TD.THRESHOLD_KNAME, TD.THRESHOLD_ENAME, TD.IMAGE_FILE_NAME, TD.SEQUENCE, TD.THRESHOLD_COLOR
                     , TD.CNT_KPI, TD.CNT_ALL
                     , CASE WHEN TD.CNT_ALL=0 THEN 0 ELSE ROUND((TD.CNT_KPI/(TD.CNT_ALL)),4)*100 END as COMP_RATE
                  FROM (
						SELECT TB.YMD, TB.THRESHOLD_REF_ID, TC.THRESHOLD_KNAME, TC.THRESHOLD_ENAME, TC.IMAGE_FILE_NAME, TC.SEQUENCE, TC.THRESHOLD_COLOR
						     , (TB.CNT_KPI*0.1)*10 as CNT_KPI
							 , SUM(TB.CNT_KPI) OVER(PARTITION BY TB.YMD) as CNT_ALL
						  FROM (
								SELECT TA.YMD, TA.THRESHOLD_REF_ID, COUNT(TA.THRESHOLD_REF_ID) as CNT_KPI
								  FROM (
										SELECT KS.YMD
											 , CASE WHEN @iSUM_TYPE='MS' THEN KS.THRESHOLD_REF_ID_MS ELSE KS.THRESHOLD_REF_ID_TS END as THRESHOLD_REF_ID
										  FROM BSC_KPI_SCORE KS
											   INNER JOIN BSC_KPI_INFO KI
												  ON KS.ESTTERM_REF_ID = KI.ESTTERM_REF_ID
												 AND KS.KPI_REF_ID     = KI.KPI_REF_ID
												 AND KI.USE_YN         = 'Y'
												 AND KI.ISDELETE       = 'N'
												 AND KI.IS_TEAM_KPI    = 'Y'
										 WHERE KS.YMD      BETWEEN @iSYMD AND @iEYMD
										) TA
								   GROUP BY TA.YMD, TA.THRESHOLD_REF_ID
								) TB 
								INNER JOIN BSC_THRESHOLD_CODE TC
								   ON TB.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
								  AND TC.DEFAULT_IMG_YN = 'N'
                       ) TD
                 ORDER BY TD.YMD, TD.SEQUENCE";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iSYMD", SqlDbType.VarChar);
            paramArray[0].Value         = isymd;
            paramArray[1]               = CreateDataParameter("@iEYMD", SqlDbType.VarChar);
            paramArray[1].Value         = ieymd;
            paramArray[2]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = isum_type;

            //DataSet ds = DbAgentObj.FillDataSet(query, "DEPT_TYPE_SORT_LIST", null, paramArray, CommandType.Text);
            DataSet ds = DbAgentObj.FillDataSet(DbAgentHelper.GetQueryStringReplace(sSQL),"KPI_GRADE", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiEntGradeAlert(int iestterm_ref_id, string iymd, string isum_type, int ithreshold_ref_id)
        { 
            string sSQL =
              @" SELECT TH.VIEW_REF_ID, TH.VIEW_NAME, TH.CNT_KPI, TH.CNT_ALL
                       ,CASE WHEN TH.CNT_ALL = 0 THEN 0 ELSE ROUND((TH.CNT_KPI/TH.CNT_ALL),4)*100 END as COMP_RATE
                   FROM (
                         SELECT TG.VIEW_REF_ID, TG.VIEW_NAME, TG.VIEW_SEQ, (TG.CNT_KPI*0.1)*10 as CNT_KPI, SUM(TG.CNT_KPI) OVER() as CNT_ALL 
                           FROM (
                                 SELECT TE.VIEW_REF_ID, TE.VIEW_NAME, ISNULL(TF.CNT_KPI,0) as CNT_KPI, TE.VIEW_SEQ
                                   FROM BSC_VIEW_INFO TE
                                        INNER JOIN 
                                        (
                                         SELECT TB.YMD, TB.VIEW_REF_ID, COUNT(TB.KPI_REF_ID) as CNT_KPI
                                           FROM (
                                                 SELECT KS.YMD, KS.KPI_REF_ID, TA.VIEW_REF_ID
                                                       ,CASE WHEN @iSUM_TYPE='MS' THEN KS.THRESHOLD_REF_ID_MS ELSE KS.THRESHOLD_REF_ID_TS END as THRESHOLD_REF_ID
                                                   FROM BSC_KPI_SCORE KS
                                                        INNER JOIN 
                                                        (
                                                         SELECT MK.ESTTERM_REF_ID, MV.YMD, MK.KPI_REF_ID, MS.VIEW_REF_ID
                                                           FROM BSC_MAP_KPI MK
                                                                 INNER JOIN BSC_MAP_TERM MV
                                                                    ON MK.ESTTERM_REF_ID  = MV.ESTTERM_REF_ID
                                                                   AND MK.EST_DEPT_REF_ID = MV.EST_DEPT_REF_ID
                                                                   AND MK.MAP_VERSION_ID  = MV.MAP_VERSION_ID
                                                                   AND MV.YMD             = @iYMD
                                                                 INNER JOIN BSC_MAP_STG MS
                                                                    ON MK.ESTTERM_REF_ID  = MS.ESTTERM_REF_ID
                                                                   AND MK.EST_DEPT_REF_ID = MS.EST_DEPT_REF_ID
                                                                   AND MK.MAP_VERSION_ID  = MS.MAP_VERSION_ID
                                                                   AND MK.STG_REF_ID      = MS.STG_REF_ID
                                                           WHERE MK.ESTTERM_REF_ID       = @iESTTERM_REF_ID
                                                           GROUP BY MK.ESTTERM_REF_ID, MV.YMD, MK.KPI_REF_ID, MS.VIEW_REF_ID
                                                        ) TA
                                                           ON KS.ESTTERM_REF_ID = TA.ESTTERM_REF_ID
                                                          AND KS.YMD            = TA.YMD
                                                          AND KS.KPI_REF_ID     = TA.KPI_REF_ID
                                                ) TB
                                                INNER JOIN BSC_THRESHOLD_CODE TC
                                                   ON TB.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
                                                  AND TB.THRESHOLD_REF_ID = @iTHRESHOLD_REF_ID
                                          GROUP BY TB.YMD, TB.THRESHOLD_REF_ID, TB.VIEW_REF_ID
                                        ) TF
                                        ON TE.VIEW_REF_ID = TF.VIEW_REF_ID
                                ) TG
                        ) TH
                  ORDER BY TH.VIEW_SEQ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[1].Value         = iymd;
            paramArray[2]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[2].Value         = isum_type;
            paramArray[3]               = CreateDataParameter("@iTHRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ithreshold_ref_id;

            //DataSet ds = DbAgentObj.FillDataSet(query, "DEPT_TYPE_SORT_LIST", null, paramArray, CommandType.Text);
            DataSet ds = DbAgentObj.FillDataSet(DbAgentHelper.GetQueryStringReplace(sSQL),"KPI_GRADE", null, paramArray, CommandType.Text);
            return ds;
        }

        /// <summary>
        /// 상하반기 정량평가점수조회
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간코드</param>
        /// <param name="iestterm_sub_id">상하반기구분코드</param>
        /// <returns></returns>
        public DataSet GetQuantityScoreForEstDetp(int iestterm_ref_id, int iestterm_sub_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "S5";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value         = iestterm_sub_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_TREND.SCORE_CARD_QUANTITY"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 상하반기 정량평가점수 가져오기
        /// </summary>
        /// <param name="iestterm_ref_id">평가기간코드</param>
        /// <param name="iestterm_sub_id">상하반기구분코드</param>
        /// <returns></returns>
        public DataSet GetInterfaceQuantityScore(int iestterm_ref_id, int iestterm_sub_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A1";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value         = iestterm_sub_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD", "PKG_BSC_SCORE_CARD_TREND.SCORE_CARD_QUANTITY"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 그룹사 KPI현황
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <returns></returns>
        public DataSet GetScoreCardGroupStatus(int iestterm_ref_id, string iymd, int isumType)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SG";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isumType;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_SCORE_CARD_GROUP_STATUS", "PKG_BSC_SCORE_CARD_TREND.SCORE_CARD_GROUP_STATUS"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetScoreCardAchieveRatePerViewType(int iestterm_ref_id, string iymd, int isumType)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SV";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isumType;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_SCORE_CARD_GROUP_STATUS", "PKG_BSC_SCORE_CARD_TREND.SCORE_CARD_GROUP_STATUS"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 평가부서별/ 등급구간별 지표분포현황
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <param name="isumType"></param>
        /// <returns></returns>
        public DataSet GetEstDeptThresholdGrade(int iestterm_ref_id, string iymd, string isumType, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A2";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = isumType;
            paramArray[4]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_SCORE_CARD_GROUP_STATUS", "PKG_BSC_SCORE_CARD.PROC_SELECT_DEPT_THRESHOLD"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        /// <summary>
        /// 그룹사별 실적 입력 현황
        /// </summary>
        /// <param name="iestterm_ref_id"></param>
        /// <param name="iymd"></param>
        /// <returns></returns>
        public DataSet GetScoreCardGroupConfirmRateStatus(int iestterm_ref_id, string iymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "CS";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_SCORE_CARD_GROUP_STATUS", "usp_SCORE_CARD_GROUP_STATUS"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetGroupResultInputList(int iestterm_ref_id, string iymd, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "GC";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_SCORE_CARD_GROUP_STATUS", "usp_SCORE_CARD_GROUP_STATUS"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptRankPOP(object estterm_ref_id, object ymd, object dept_type)
        {
            string strQuery = @"
SELECT   KW.ESTTERM_REF_ID
        ,KW.YMD
        ,KW.EST_DEPT_REF_ID
        ,ED.DEPT_NAME
        ,SUM(ISNULL(KW.WEIGHT3,0)* (CASE WHEN TS.POINTS_MS='-' OR TS.POINTS_MS IS NULL THEN 0 ELSE CONVERT(NUMERIC(20,4),TS.POINTS_MS)*0.01 END)) as SCORE_MS
        ,SUM(ISNULL(KW.SWEIGHT3,0)*(CASE WHEN TS.POINTS_TS='-' OR TS.POINTS_TS IS NULL THEN 0 ELSE CONVERT(NUMERIC(20,4),TS.POINTS_TS)*0.01 END)) as SCORE_TS
FROM BSC_KPI_WEIGHT KW 
LEFT JOIN BSC_KPI_SCORE TS
      ON KW.ESTTERM_REF_ID = TS.ESTTERM_REF_ID
     AND KW.KPI_REF_ID     = TS.KPI_REF_ID
     AND KW.YMD            = TS.YMD
     AND KW.ESTTERM_REF_ID = @ESTTERM_REF_ID
LEFT JOIN EST_DEPT_INFO ED
      ON KW.ESTTERM_REF_ID  = ED.ESTTERM_REF_ID
     AND KW.EST_DEPT_REF_ID = ED.EST_DEPT_REF_ID
WHERE ED.DEPT_TYPE            = @DEPT_TYPE
AND KW.YMD                  = @YMD
AND ED.DEPT_REF_ID IS NOT NULL
GROUP BY KW.ESTTERM_REF_ID,
    KW.YMD,
    KW.EST_DEPT_REF_ID,
    ED.DEPT_NAME    


SELECT   DG.ESTTERM_REF_ID
        ,DG.EST_DEPT_TYPE
        ,ISNULL(DT.TYPE_NAME,'') as TYPE_NAME
        ,DG.GRADE_REF_ID 
        ,DG.GRADE_NAME    
        ,DG.MIN_VALUE     
        ,DG.MAX_VALUE     
        ,DG.MID_GRADE_YN
        ,DG.SORT_ORDER    
        ,DG.USE_YN        
        ,DG.CREATE_USER   
        ,DG.CREATE_DATE   
        ,DG.UPDATE_USER   
        ,DG.UPDATE_DATE   
FROM BSC_EST_DEPT_GRADE DG
LEFT JOIN COM_DEPT_TYPE_INFO DT
     ON DG.EST_DEPT_TYPE = DT.TYPE_REF_ID
WHERE DG.ESTTERM_REF_ID = @ESTTERM_REF_ID
AND DG.EST_DEPT_TYPE  = CASE WHEN ISNULL(@DEPT_TYPE,0) < 1 THEN DG.EST_DEPT_TYPE ELSE @DEPT_TYPE END
ORDER BY DG.EST_DEPT_TYPE, DG.SORT_ORDER
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@YMD", SqlDbType.VarChar);
            paramArray[1].Value = ymd;
            paramArray[2] = CreateDataParameter("@DEPT_TYPE", SqlDbType.Int);
            paramArray[2].Value = dept_type;

            return DbAgentObj.FillDataSet(strQuery, "BSC_KPI_WEIGHT", null, paramArray, CommandType.Text);
        }
    }
}