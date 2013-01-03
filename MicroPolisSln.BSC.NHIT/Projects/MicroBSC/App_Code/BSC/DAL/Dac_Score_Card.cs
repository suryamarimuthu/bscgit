using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_Score_Card : DbAgentBase
    {
        public Dac_Score_Card() { }

        public DataSet GetEstDeptRankList(int iestterm_ref_id, string iymd, int idept_type, string isum_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "S1";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value = idept_type;
            paramArray[4] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[4].Value = isum_type;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_RANK", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptKpiScoreList(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "S2";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[3].Value = isum_type;
            paramArray[4] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_KPI", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptKpiViewTypeList(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "S3";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[3].Value = isum_type;
            paramArray[4] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_VIEW", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptTotalScore(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "S4";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[3].Value = isum_type;
            paramArray[4] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_TOTAL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEstDeptTotalScoreForMap(int iestterm_ref_id, string iymd, string isum_type, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "S6";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[3].Value = isum_type;
            paramArray[4] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[4].Value = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_TOTAL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetYearlyTotalScoreTrend(int iestterm_ref_id, int idept_type, int isumtype)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = iestterm_ref_id;
            paramArray[1] = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[1].Value = idept_type;
            paramArray[2] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[2].Value = isumtype;

            DataSet ds = DbAgentObj.FillDataSet("usp_SCORE_CARD_TREND", "SCORE_CARD_TREND", null, paramArray, CommandType.StoredProcedure);
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
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "S5";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = iestterm_sub_id;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_QUANTITY", null, paramArray, CommandType.StoredProcedure);
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
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "A1";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = iestterm_sub_id;

            DataSet ds = DbAgentObj.FillDataSet("usp_BSC_SCORE_CARD", "SCORE_CARD_QUANTITY", null, paramArray, CommandType.StoredProcedure);
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

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "SG";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[3].Value = isumType;

            DataSet ds = DbAgentObj.FillDataSet("usp_SCORE_CARD_GROUP_STATUS", "SCORE_CARD_GROUP_STATUS", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetScoreCardAchieveRatePerViewType(int iestterm_ref_id, string iymd, int isumType)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "SV";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar,2);
            paramArray[3].Value = isumType;

            DataSet ds = DbAgentObj.FillDataSet("usp_SCORE_CARD_GROUP_STATUS", "SCORE_CARD_GROUP_STATUS", null, paramArray, CommandType.StoredProcedure);
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

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "CS";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;

            DataSet ds = DbAgentObj.FillDataSet("usp_SCORE_CARD_GROUP_STATUS", "usp_SCORE_CARD_GROUP_STATUS", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetGroupResultInputList(int iestterm_ref_id, string iymd, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar, 2);
            paramArray[0].Value = "GC";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar, 8);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iest_dept_ref_id;



            DataSet ds = DbAgentObj.FillDataSet("usp_SCORE_CARD_GROUP_STATUS", "usp_SCORE_CARD_GROUP_STATUS", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }     
    }
}
