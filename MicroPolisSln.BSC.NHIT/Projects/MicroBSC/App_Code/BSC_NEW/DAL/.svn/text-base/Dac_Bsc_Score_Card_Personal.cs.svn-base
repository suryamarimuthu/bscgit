using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

/// <summary>
/// Summary description for Dac_Bsc_Score_Card_Personal
/// </summary>
/// 
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Score_Card_Personal : DbAgentBase
    {

        public DataSet GetPersonalScoreCard(int iestterm_ref_id, string iymd, int idept_type, string isum_type, int iemp_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SP";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value         = idept_type;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;
            paramArray[5]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = iemp_ref_id;
            paramArray[6]               = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_PERSONAL", "PKG_BSC_SCORE_CARD_PERSONAL.PROC_SELECT_PERSONAL_SCORE"), "BSC_SCORE_CARD_PERSONAL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetPersonalScoreCard_Goal(int iestterm_ref_id, string iymd, int idept_type, string isum_type, int iemp_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SP";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value         = idept_type;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;
            paramArray[5]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = iemp_ref_id;
            paramArray[6]               = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_PERSONAL", "PKG_BSC_SCORE_CARD_PERSONAL_G.PROC_SELECT_PERSONAL_SCORE"), "BSC_SCORE_CARD_PERSONAL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetPersonalScoreRank(int iestterm_ref_id, string iymd, int idept_type, string isum_type, int iemp_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "RK";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value         = iymd;
            paramArray[3]               = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value         = idept_type;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;
            paramArray[5]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = iemp_ref_id;
            paramArray[6]               = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_PERSONAL", "PKG_BSC_SCORE_CARD_PERSONAL.PROC_SELECT_PERSONAL_RANK"), "BSC_SCORE_CARD_PERSONAL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetPersonalScoreRankAll(int iestterm_ref_id, string iymd, int idept_type, string isum_type, int iemp_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RK";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value = idept_type;
            paramArray[4] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = isum_type;
            paramArray[5] = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value = iemp_ref_id;
            paramArray[6] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value = idept_ref_id;
            paramArray[7] = CreateDataParameter("@iHAVE_CHILD_DEPT", SqlDbType.VarChar);
            paramArray[7].Value = "Y";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_PERSONAL", "PKG_BSC_SCORE_CARD_PERSONAL.PROC_SELECT_PERSONAL_RANK"), "BSC_SCORE_CARD_PERSONAL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetPersonalScoreRankAll_Goal(int iestterm_ref_id, string iymd, int idept_type, string isum_type, int iemp_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RK";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[2].Value = iymd;
            paramArray[3] = CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
            paramArray[3].Value = idept_type;
            paramArray[4] = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = isum_type;
            paramArray[5] = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value = iemp_ref_id;
            paramArray[6] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[6].Value = idept_ref_id;
            paramArray[7] = CreateDataParameter("@iHAVE_CHILD_DEPT", SqlDbType.VarChar);
            paramArray[7].Value = "Y";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_SCORE_CARD_PERSONAL", "PKG_BSC_SCORE_CARD_PERSONAL_G.PROC_SELECT_PERSONAL_RANK"), "BSC_SCORE_CARD_PERSONAL", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
    }
}
