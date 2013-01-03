using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;


/// <summary>
/// Summary description for Dac_Bsc_Score_Card_Ext
/// 외부지표점수를 포함한 스코어 카드 조회
/// </summary>
/// 

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Score_Card_Ext : DbAgentBase
    {
        public Dac_Bsc_Score_Card_Ext() { }

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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_ESTDEPT_RANK"),"SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_ESTDEPT_RANK"), "SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = new DataSet();
            if (includeExtScore)
            {
                ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_ESTDEPT_RANK"), "SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
            }
            else
            { 
                ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_ESTDEPT_RANK"), "SELECT_ESTDEPT_RANK", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_SCORE_ESTDEPT"),"SELECT_SCORE_ESTDEPT", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT_GOAL.PROC_SELECT_SCORE_ESTDEPT"),"SELECT_SCORE_ESTDEPT", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_VIEW_WEIGHT"),"SELECT_VIEW_WEIGHT", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT_GOAL.PROC_SELECT_VIEW_WEIGHT"),"SELECT_VIEW_WEIGHT", null, paramArray, CommandType.StoredProcedure);
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


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_STG_WEIGHT"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
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


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT_GOAL.PROC_SELECT_STG_WEIGHT"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
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


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD_EXT", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
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


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT_GOAL.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
            return ds;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD_EXT", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
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


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);

            string sSig = "";
            string sRtn = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                sSig = ds.Tables[0].Rows[0]["DEPT_SIGNAL"].ToString();
                sRtn = (sSig == "-") ? "-" : ds.Tables[0].Rows[0]["POINT"].ToString();
            }
            else
            {
                sRtn = "-";
            }

            return sRtn;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD_EXT", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
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


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT_GOAL.PROC_SELECT_ESTDEPT_SCORE"), "SELECT_ESTDEPT_SCORE", null, paramArray, CommandType.StoredProcedure);

            string sSig = "";
            string sRtn = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                sSig = ds.Tables[0].Rows[0]["DEPT_SIGNAL"].ToString();
                sRtn = (sSig == "-") ? "-" : ds.Tables[0].Rows[0]["POINT"].ToString();
            }
            else
            {
                sRtn = "-";
            }

            return sRtn;

            //DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD_EXT", "SCORE_CARD_TOTAL", null, null, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_MAP_DEPT_SCORE"),"SELECT_MAP_DEPT_SCORE", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_DEPT_KPI_SCORE"),"SELECT_DEPT_KPI_SCORE", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_KPI_GRADE"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_EXT_GOAL.PROC_SELECT_KPI_GRADE"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT_TREND", "PKG_BSC_SCORE_CARD_TREND.PROC_SCORE_CARD_TREND"), "SCORE_CARD_TREND", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_TREND.SCORE_CARD_QUANTITY"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_EXT", "PKG_BSC_SCORE_CARD_TREND.SCORE_CARD_QUANTITY"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
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

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_SCORE_CARD_GROUP_STATUS", "PKG_BSC_SCORE_CARD_EXT.PROC_SELECT_DEPT_THRESHOLD"),"SELECT_KPI_GRADE", null, paramArray, CommandType.StoredProcedure);
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
    }
}
