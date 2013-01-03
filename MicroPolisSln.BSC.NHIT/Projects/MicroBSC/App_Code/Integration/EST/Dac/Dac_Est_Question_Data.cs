using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Dac
{
    public class Dac_Est_Question_Data : DbAgentBase
    {
        public Dac_Est_Question_Data()
        {
        }

        public DataTable SelectEstQuestionDataGraph1_DB(object comp_id
                                                    , object yid1
                                                    , object estterm_ref_id
                                                    , object estterm_sub_id
                                                    , object tgt_emp_id)
        {
            string query = @"

--[2]역량평가, 평가항목별점수(공통역량평가)
SELECT A.Q_DFN_ID
     , A.Q_DFN_NAME
     , CAST(SUM(ISNULL(A.MY_POINT, 0)) AS FLOAT) AS MY_POINT
     , CAST(SUM(ISNULL(A.AVG_POINT, 0)) AS FLOAT) AS AVG_POINT
FROM (
	SELECT D.Q_DFN_ID, D.Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	LEFT OUTER JOIN EST_QUESTION_DEFINE		D
		ON		D.Q_DFN_ID	= C.Q_DFN_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID1
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY D.Q_DFN_ID, D.Q_DFN_NAME

	UNION ALL

	SELECT D.Q_DFN_ID, D.Q_DFN_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	LEFT OUTER JOIN EST_QUESTION_DEFINE		D
		ON		D.Q_DFN_ID	= C.Q_DFN_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID1
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY D.Q_DFN_ID, D.Q_DFN_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME

";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@YID1", SqlDbType.NVarChar);
            paramArray[1].Value = yid1;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_emp_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectEstQuestionSubjectGraph2_DB(object comp_id
                                                        , object yid2
                                                        , object estterm_ref_id
                                                        , object estterm_sub_id
                                                        , object tgt_emp_id)
        {
            string query = @"

--[3]역량평가, 평가항목별점수(직무역량평가)
SELECT A.Q_DFN_ID
     , A.Q_DFN_NAME
     , CAST(SUM(ISNULL(A.MY_POINT, 0)) AS FLOAT) AS MY_POINT
     , CAST(SUM(ISNULL(A.AVG_POINT, 0)) AS FLOAT) AS AVG_POINT
FROM (
	SELECT C.Q_SBJ_ID AS Q_DFN_ID, C.Q_SBJ_NAME AS Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID2
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME

	UNION ALL

	SELECT C.Q_SBJ_ID, C.Q_SBJ_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	INNER JOIN EST_QUESTION_DATA    D
        ON      D.COMP_ID   = @COMP_ID
            AND D.EST_ID	= @YID2
		    AND	D.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		    AND	D.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		    AND	D.ESTTERM_STEP_ID	> 1
		    AND	D.TGT_EMP_ID		= @TGT_EMP_ID
            AND D.Q_SBJ_ID          = A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID2
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME

";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@YID2", SqlDbType.NVarChar);
            paramArray[1].Value = yid2;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_emp_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        public DataTable SelectEstQuestionSubjectGraph3_DB(object comp_id
                                                        , object yid3
                                                        , object estterm_ref_id
                                                        , object estterm_sub_id
                                                        , object tgt_emp_id)
        {
            string query = @"


--[4]역량평가, 평가항목별점수(리더역량평가)
SELECT A.Q_DFN_ID
     , A.Q_DFN_NAME
     , CAST(SUM(ISNULL(A.MY_POINT, 0)) AS FLOAT) AS MY_POINT
     , CAST(SUM(ISNULL(A.AVG_POINT, 0)) AS FLOAT) AS AVG_POINT
FROM (
	SELECT C.Q_SBJ_ID AS Q_DFN_ID, C.Q_SBJ_NAME AS Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID3
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME

	UNION ALL

	SELECT C.Q_SBJ_ID, C.Q_SBJ_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	INNER JOIN EST_QUESTION_DATA    D
        ON      D.COMP_ID   = @COMP_ID
            AND D.EST_ID	= @YID3
		    AND	D.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		    AND	D.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		    AND	D.ESTTERM_STEP_ID	> 1
		    AND	D.TGT_EMP_ID		= @TGT_EMP_ID
            AND D.Q_SBJ_ID          = A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @YID3
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME

";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@YID3", SqlDbType.NVarChar);
            paramArray[1].Value = yid3;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_emp_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }



        public DataTable SelectEstQuestionSubjectGraph_DB(object comp_id
                                                        , object gong_id
                                                        , object estterm_ref_id
                                                        , object estterm_sub_id
                                                        , object tgt_emp_id)
        {
            string query = @"


--[5]업적평가(공헌도평가)
SELECT A.Q_DFN_ID
     , A.Q_DFN_NAME
     , CAST(SUM(ISNULL(A.MY_POINT, 0)) AS FLOAT) AS MY_POINT
     , CAST(SUM(ISNULL(A.AVG_POINT, 0)) AS FLOAT) AS AVG_POINT
FROM (
	SELECT C.Q_SBJ_ID AS Q_DFN_ID, C.Q_SBJ_NAME AS Q_DFN_NAME, SUM(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS MY_POINT, 0 AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @GONGID
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
		AND	A.TGT_EMP_ID		= @TGT_EMP_ID
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME

	UNION ALL

	SELECT C.Q_SBJ_ID, C.Q_SBJ_NAME, 0 AS MY_POINT, AVG(ISNULL(A.POINT, 0) * ISNULL(B.WEIGHT, 0) / 100)	AS AVG_POINT
	FROM EST_QUESTION_DATA	A
	LEFT OUTER JOIN EST_TERM_STEP_EST_MAP	B
		ON		B.COMP_ID	= A.COMP_ID
			AND	B.EST_ID	= A.EST_ID
			AND	B.ESTTERM_STEP_ID	= A.ESTTERM_STEP_ID	
	LEFT OUTER JOIN EST_QUESTION_SUBJECT	C
		ON		C.Q_SBJ_ID	= A.Q_SBJ_ID
	INNER JOIN EST_QUESTION_DATA    D
        ON      D.COMP_ID   = @COMP_ID
            AND D.EST_ID	= @GONGID
		    AND	D.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		    AND	D.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		    AND	D.ESTTERM_STEP_ID	> 1
		    AND	D.TGT_EMP_ID		= @TGT_EMP_ID
            AND D.Q_SBJ_ID          = A.Q_SBJ_ID
	WHERE	A.COMP_ID	= @COMP_ID
		AND	A.EST_ID	= @GONGID
		AND	A.ESTTERM_REF_ID	= @ESTTERM_REF_ID
		AND	A.ESTTERM_SUB_ID	= @ESTTERM_SUB_ID
		AND	A.ESTTERM_STEP_ID	> 1
	GROUP BY C.Q_SBJ_ID, C.Q_SBJ_NAME
) A
GROUP BY A.Q_DFN_ID, A.Q_DFN_NAME

";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@GONGID", SqlDbType.NVarChar);
            paramArray[1].Value = gong_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_ref_id;
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[4].Value = tgt_emp_id;

            DataTable dt = DbAgentObj.FillDataSet(query, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectEstQuestionDataSelfPoint(string q_obj_id, string q_sbj_id)
        {
            string qry = @"SELECT QI.Q_SBJ_ID, QI.Q_ITEM_NAME, QI.POINT, QI.Q_ITM_ID, QD.Q_OBJ_ID FROM EST_QUESTION_DATA QD INNER JOIN EST_QUESTION_ITEM QI ON QD.Q_ITM_ID =QI.Q_ITM_ID
                            WHERE QD.Q_OBJ_ID = @Q_OBJ_ID AND QD.Q_SBJ_ID = @Q_SBJ_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@Q_OBJ_ID", SqlDbType.VarChar);
            paramArray[0].Value = q_obj_id;
            paramArray[1] = CreateDataParameter("@Q_SBJ_ID", SqlDbType.VarChar);
            paramArray[1].Value = q_sbj_id;

            DataTable dt = DbAgentObj.FillDataSet(qry, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectEstQuestionDataSelfPointResultCount(int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
            string Q_OBJ_ID, int TGT_EMP_ID, string EST_ID)
        {
            string qry = @"SELECT EST_EMP_ID FROM EST_QUESTION_DATA 
                            WHERE EST_ID = @EST_ID 
                            AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
                            AND Q_OBJ_ID = @Q_OBJ_ID AND TGT_EMP_ID = @TGT_EMP_ID
                            GROUP BY EST_EMP_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = ESTTERM_REF_ID;
            paramArray[1] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[1].Value = ESTTERM_SUB_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_STEP_ID;
            paramArray[3] = CreateDataParameter("@Q_OBJ_ID", SqlDbType.VarChar);
            paramArray[3].Value = Q_OBJ_ID;
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.VarChar);
            paramArray[4].Value = TGT_EMP_ID;
            paramArray[5] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[5].Value = EST_ID;
            DataTable dt = DbAgentObj.FillDataSet(qry, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectEstQuestionDataSelfPointResultPoint(int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
           string Q_OBJ_ID, int TGT_EMP_ID, string EST_ID)
        {
            string qry = @"SELECT Q_SBJ_ID, POINT, EST_EMP_ID FROM EST_QUESTION_DATA 
                            WHERE EST_ID = @EST_ID 
                            AND ESTTERM_REF_ID = @ESTTERM_REF_ID AND ESTTERM_SUB_ID = @ESTTERM_SUB_ID AND ESTTERM_STEP_ID = @ESTTERM_STEP_ID
                            AND Q_OBJ_ID = @Q_OBJ_ID AND TGT_EMP_ID = @TGT_EMP_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = ESTTERM_REF_ID;
            paramArray[1] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[1].Value = ESTTERM_SUB_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_STEP_ID;
            paramArray[3] = CreateDataParameter("@Q_OBJ_ID", SqlDbType.VarChar);
            paramArray[3].Value = Q_OBJ_ID;
            paramArray[4] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.VarChar);
            paramArray[4].Value = TGT_EMP_ID;
            paramArray[5] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[5].Value = EST_ID;

            DataTable dt = DbAgentObj.FillDataSet(qry, "EST_DATA", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public int Insert(IDbConnection conn, IDbTransaction trx
            , string COMP_ID, string EST_ID, int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID
            , int EST_DEPT_ID, int EST_EMP_ID, int TGT_DEPT_ID, int TGT_EMP_ID, string Q_OBJ_ID, string Q_DFN_ID, string Q_SBJ_ID, string Q_ITM_ID, int POINT, int EMP_NO)
        {
            string qry = @"INSERT INTO EST_QUESTION_DATA
                            (
                              COMP_ID,          
                              EST_ID,           
                              ESTTERM_REF_ID,   
                              ESTTERM_SUB_ID,   
                              ESTTERM_STEP_ID,  
                              EST_DEPT_ID,      
                              EST_EMP_ID,       
                              TGT_DEPT_ID,      
                              TGT_EMP_ID,       
                              Q_OBJ_ID,
                              Q_DFN_ID,         
                              Q_SBJ_ID,         
                              Q_ITM_ID,         
                              POINT,            
                              CREATE_DATE,      
                              CREATE_USER      
                            )
                            VALUES
                            (
                              @COMP_ID,          
                              @EST_ID,           
                              @ESTTERM_REF_ID,   
                              @ESTTERM_SUB_ID,   
                              @ESTTERM_STEP_ID,  
                              @EST_DEPT_ID,      
                              @EST_EMP_ID,       
                              @TGT_DEPT_ID,      
                              @TGT_EMP_ID,       
                              @Q_OBJ_ID,
                              @Q_DFN_ID,         
                              @Q_SBJ_ID,         
                              @Q_ITM_ID,         
                              @POINT,            
                              SYSDATE,      
                              @CREATE_USER      
                            )";
            IDbDataParameter[] paramArray = CreateDataParameters(14);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.VarChar);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.VarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = EST_DEPT_ID;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = EST_EMP_ID;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = TGT_DEPT_ID;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_EMP_ID;
            paramArray[9] = CreateDataParameter("@Q_OBJ_ID", SqlDbType.VarChar);
            paramArray[9].Value = Q_OBJ_ID;
            paramArray[10] = CreateDataParameter("@Q_DFN_ID", SqlDbType.VarChar);
            paramArray[10].Value = Q_DFN_ID;
            paramArray[11] = CreateDataParameter("@Q_SBJ_ID", SqlDbType.VarChar);
            paramArray[11].Value = Q_SBJ_ID;
            paramArray[12] = CreateDataParameter("@Q_ITM_ID", SqlDbType.VarChar);
            paramArray[12].Value = Q_ITM_ID;
            paramArray[13] = CreateDataParameter("@POINT", SqlDbType.VarChar);
            paramArray[13].Value = POINT;
            paramArray[14] = CreateDataParameter("@CREATE_USER", SqlDbType.VarChar);
            paramArray[14].Value = EMP_NO;

            return DbAgentObj.ExecuteNonQuery(conn, trx, qry, paramArray);
        }
        public int Insert(string COMP_ID, string EST_ID, int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
            int EST_DEPT_ID, int EST_EMP_ID, int TGT_DEPT_ID, int TGT_EMP_ID, string Q_OBJ_ID, string Q_SBJ_ID, string Q_ITM_ID, int POINT, int EMP_NO)
        {
            return Insert(null, null, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, Q_OBJ_ID, "", Q_SBJ_ID, Q_ITM_ID, POINT, EMP_NO);
        }


        public int Insert(string COMP_ID, string EST_ID, int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
            int EST_DEPT_ID, int EST_EMP_ID, int TGT_DEPT_ID, int TGT_EMP_ID, string Q_OBJ_ID, string Q_DFN_ID, string Q_SBJ_ID, string Q_ITM_ID, int POINT, int EMP_NO)
        {
            return Insert(null, null, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, Q_OBJ_ID, Q_DFN_ID, Q_SBJ_ID, Q_ITM_ID, POINT, EMP_NO);
        }


        public int Delete(IDbConnection conn, IDbTransaction trx
            , string COMP_ID, string EST_ID, int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID
            , int EST_DEPT_ID, int EST_EMP_ID, int TGT_DEPT_ID, int TGT_EMP_ID, string Q_OBJ_ID, string Q_SBJ_ID, string Q_ITM_ID)
        {
            string qry = @"
DELETE FROM EST_QUESTION_DATA
    WHERE   (  COMP_ID          = @COMP_ID  )
        AND (  EST_ID           = @EST_ID   )
        AND (  ESTTERM_REF_ID   = @ESTTERM_REF_ID   )
        AND (  ESTTERM_SUB_ID   = @ESTTERM_SUB_ID   )
        AND (  ESTTERM_STEP_ID  = @ESTTERM_STEP_ID  )
        AND (  EST_DEPT_ID      = @EST_DEPT_ID	    OR @EST_DEPT_ID         = 0  )
        AND (  EST_EMP_ID       = @EST_EMP_ID	    OR @EST_EMP_ID          = 0  )
        AND (  TGT_DEPT_ID      = @TGT_DEPT_ID	    OR @TGT_DEPT_ID         = 0  )
        AND (  TGT_EMP_ID       = @TGT_EMP_ID	    OR @TGT_EMP_ID          = 0  )
        AND (  Q_OBJ_ID         = @Q_OBJ_ID	        OR @Q_OBJ_ID            =''  )
        AND (  Q_SBJ_ID         = @Q_SBJ_ID	        OR @Q_SBJ_ID            =''  )
        AND (  Q_ITM_ID         = @Q_ITM_ID	        OR @Q_ITM_ID            =''  )
";

            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = COMP_ID;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = EST_ID;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = ESTTERM_REF_ID;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = ESTTERM_SUB_ID;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = ESTTERM_STEP_ID;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = EST_DEPT_ID;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = EST_EMP_ID;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = TGT_DEPT_ID;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = TGT_EMP_ID;
            paramArray[9] = CreateDataParameter("@Q_OBJ_ID", SqlDbType.NVarChar);
            paramArray[9].Value = Q_OBJ_ID;
            paramArray[10] = CreateDataParameter("@Q_SBJ_ID", SqlDbType.NVarChar);
            paramArray[10].Value = Q_SBJ_ID;
            paramArray[11] = CreateDataParameter("@Q_ITM_ID", SqlDbType.NVarChar);
            paramArray[11].Value = Q_ITM_ID;

            return DbAgentObj.ExecuteNonQuery(conn, trx,qry, paramArray);
        }
        public int Delete(string COMP_ID, string EST_ID, int ESTTERM_REF_ID, int ESTTERM_SUB_ID, int ESTTERM_STEP_ID,
            int EST_DEPT_ID, int EST_EMP_ID, int TGT_DEPT_ID, int TGT_EMP_ID, string Q_OBJ_ID, string Q_SBJ_ID, string Q_ITM_ID)
        {
            int affectedRow = 0;
            affectedRow = Delete(null, null, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, Q_OBJ_ID, Q_SBJ_ID, Q_ITM_ID);
            return affectedRow;
        }


        public DataTable Select_Est_QuestionSbj_Point(object comp_id
                                                    , object est_id
                                                    , object estterm_ref_id
                                                    , object estterm_sub_id
                                                    , object estterm_step_id
                                                    , object est_dept_id
                                                    , object est_emp_id
                                                    , object tgt_dept_id
                                                    , object tgt_emp_id)
        {
            string query = @"
SELECT  QDATA.COMP_ID
        , QDATA.ESTTERM_REF_ID
        , QDATA.ESTTERM_SUB_ID
        , QDATA.ESTTERM_STEP_ID
        , QDATA.EST_DEPT_ID
        , QDATA.EST_EMP_ID
        , QDATA.TGT_DEPT_ID
        , QDATA.TGT_EMP_ID
        , QDATA.Q_OBJ_ID
        , QD.Q_DFN_ID
        , QDATA.Q_SBJ_ID
        , QDATA.Q_ITM_ID
        , QD.Q_DFN_NAME
        , QS.Q_SBJ_NAME
        , QS.Q_SBJ_DESC
        , CASE WHEN     QDATA.POINT     IS NULL     THEN    QI.POINT    ELSE    QDATA.POINT     END     AS  POINT
        , QS.WEIGHT 
    FROM                    EST_QUESTION_DATA QDATA
        LEFT OUTER JOIN     EST_QUESTION_SUBJECT QS
            ON QS.Q_SBJ_ID      =   QDATA.Q_SBJ_ID
        LEFT OUTER JOIN     EST_QUESTION_DEFINE QD
            ON QD.Q_DFN_ID      =   QS.Q_DFN_ID
        LEFT OUTER JOIN     EST_QUESTION_ITEM QI
            ON QDATA.Q_ITM_ID   =   QI.Q_ITM_ID
    WHERE   (  QDATA.COMP_ID          = @COMP_ID	        OR @COMP_ID         = 0  )
        AND (  QDATA.EST_ID           = @EST_ID	            OR @EST_ID          =''  )
        AND (  QDATA.ESTTERM_REF_ID   = @ESTTERM_REF_ID	    OR @ESTTERM_REF_ID  = 0  )
        AND (  QDATA.ESTTERM_SUB_ID   = @ESTTERM_SUB_ID	    OR @ESTTERM_SUB_ID  = 0  )
        AND (  QDATA.ESTTERM_STEP_ID  = @ESTTERM_STEP_ID    OR @ESTTERM_STEP_ID = 0  )
        AND (  QDATA.EST_DEPT_ID      = @EST_DEPT_ID	    OR @EST_DEPT_ID     = 0  )
        AND (  QDATA.EST_EMP_ID       = @EST_EMP_ID	        OR @EST_EMP_ID      = 0  )
        AND (  QDATA.TGT_DEPT_ID      = @TGT_DEPT_ID	    OR @TGT_DEPT_ID     = 0  )
        AND (  QDATA.TGT_EMP_ID       = @TGT_EMP_ID	        OR @TGT_EMP_ID      = 0  )
";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
            paramArray[1] = CreateDataParameter("@EST_ID", SqlDbType.NVarChar);
            paramArray[1].Value = est_id;
            paramArray[2] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_ref_id;
            paramArray[3] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value = estterm_sub_id;
            paramArray[4] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[4].Value = estterm_step_id;
            paramArray[5] = CreateDataParameter("@EST_DEPT_ID", SqlDbType.Int);
            paramArray[5].Value = est_dept_id;
            paramArray[6] = CreateDataParameter("@EST_EMP_ID", SqlDbType.Int);
            paramArray[6].Value = est_emp_id;
            paramArray[7] = CreateDataParameter("@TGT_DEPT_ID", SqlDbType.Int);
            paramArray[7].Value = tgt_dept_id;
            paramArray[8] = CreateDataParameter("@TGT_EMP_ID", SqlDbType.Int);
            paramArray[8].Value = tgt_emp_id;

            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }
    }
}
