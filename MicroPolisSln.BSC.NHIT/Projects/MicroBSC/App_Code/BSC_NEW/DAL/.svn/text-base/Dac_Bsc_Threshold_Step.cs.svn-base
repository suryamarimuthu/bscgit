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
/// Dac_Bsc_Threshold_Step의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Threshold_Step Dac 클래스
/// Class 내용		@ Bsc_Threshold_Step Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 박혜준
/// 최초작성일		@ 2007.06.13
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// </summary>

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Threshold_Step : DbAgentBase
    {
        #region ============================== [Fields] ==============================

        private Int32 _create_user;
        private DateTime _create_date;
        private Int32 _update_user;
        private DateTime _update_date;

        #endregion

        #region ============================== [Properties] ==============================


        public Int32 Create_user
        {
            get
            {
                return _create_user;
            }
            set
            {
                _create_user = value;
            }
        }

        public DateTime Create_date
        {
            get
            {
                return _create_date;
            }
            set
            {
                _create_date = value;
            }
        }

        public Int32 Update_user
        {
            get
            {
                return _update_user;
            }
            set
            {
                _update_user = value;
            }
        }

        public DateTime Update_date
        {
            get
            {
                return _update_date;
            }
            set
            {
                _update_date = value;
            }
        }
        #endregion

        public Dac_Bsc_Threshold_Step() { }

        // THRESHOLD_CODE [THRESHOLD_REF_ID] 를 THRESHOLD_STEP 에서 사용하는지 여부 체크 리턴 : true - 사용중, false - 비사용중
        protected bool UseThresholdCodeInStep_Dac(int threshold_ref_id)
        {
            string query = @" SELECT COUNT(*)
                                FROM BSC_THRESHOLD_STEP
                               WHERE THRESHOLD_REF_ID = @THRESHOLD_REF_ID";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;


            int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
            return (affectedRow > 0) ? true : false;
        }

        // THRESHOLD_STEP MAX[SEQUENCE]
        protected int RtnMaxSeqInStep_Dac(string threshold_level)
        {
            string s_query = @"SELECT MAX(ISNULL(SEQUENCE,0)) AS MAXSEQ
                                 FROM BSC_THRESHOLD_STEP 
                                WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL";

            string o_query = @"SELECT MAX(NVL(SEQUENCE,0)) AS MAXSEQ
                                 FROM BSC_THRESHOLD_STEP 
                                WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[0].Value         = threshold_level;

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text));
        }

        //THRESHOLD_STEP OLD[SEQUENCE]
        protected int RtnThresholdSetpOldSeq_Dac(string threshold_level, int threshold_ref_id)
        {
            string query = @"SELECT SEQUENCE 
                               FROM BSC_THRESHOLD_STEP
                              WHERE THRESHOLD_LEVEL  = @THRESHOLD_LEVEL
                                AND THRESHOLD_REF_ID = @THRESHOLD_REF_ID
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[0].Value         = threshold_level;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = threshold_ref_id;

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
        }


        // 순서 변경 쿼리 
        protected int GetThresholdStepDelSeqUpdate(string threshold_level, int oldseq)
        {
            string query = @"UPDATE BSC_THRESHOLD_STEP
                                SET SEQUENCE = SEQUENCE - 1
                              WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL
                                AND SEQUENCE > @OLDSEQ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[0].Value = threshold_level;
            paramArray[1] = CreateDataParameter("@OLDSEQ", SqlDbType.Int);
            paramArray[1].Value = oldseq;

            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);

            return affectedRow;
        }


        // 순서변경 쿼리
        protected int GetThersholdStepSeqUpdatd(int sequence, int oldseq, string threshold_level, string state)
        {
            string query = "";

            if (state == "P")
            {
                query = @"UPDATE BSC_THRESHOLD_STEP
                             SET SEQUENCE = SEQUENCE +1
                           WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL                                 
                             AND (SEQUENCE < @OLDSEQ AND SEQUENCE >= @SEQUENCE)";
            }
            else if (state == "M")
            {
                query = @"UPDATE BSC_THRESHOLD_STEP
                             SET SEQUENCE = SEQUENCE - 1
                           WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL                                 
                             AND (SEQUENCE > @OLDSEQ AND SEQUENCE <= @SEQUENCE)";
            }


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[0].Value = sequence;
            paramArray[1] = CreateDataParameter("@OLDSEQ", SqlDbType.Int);
            paramArray[1].Value = oldseq;
            paramArray[2] = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[2].Value = threshold_level;

            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);

            return affectedRow;
        }
        protected DataSet GetThresholdLevelSearch_Dac()
        {
            string query = @"SELECT THRESHOLD_LEVEL 
                               FROM BSC_THRESHOLD_STEP 
                              GROUP BY THRESHOLD_LEVEL";

            DataSet ds  = new DataSet();
            ds          = DbAgentObj.FillDataSet(query, "BSC_THRESHOLD_STEP_SEARCH");

            return ds;
        }


        protected DataSet GetThresholdLevelList_Dac(string threshold_level)
        {
            string query = @"SELECT TS.THRESHOLD_REF_ID 
                                   ,TC.THRESHOLD_ENAME 
	                               ,TS.THRESHOLD_LEVEL 
                                   ,TS.POINT 
                                   ,TS.SEQUENCE
                                   ,TS.BASE_LINE_YN
                               FROM BSC_THRESHOLD_STEP TS
                                    LEFT OUTER JOIN BSC_THRESHOLD_CODE TC 
                                      ON TS.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
                              WHERE TS.THRESHOLD_LEVEL = @THRESHOLD_LEVEL
                              ORDER BY TS.SEQUENCE,TS.POINT DESC";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[0].Value         = threshold_level;

            return DbAgentObj.FillDataSet(query, "BSC_THRESHOLD_STEP", null, paramArray, CommandType.Text);
        }


        // 2007.08.30 [juny177] SQL 쿼리 변경, 공통 쿼리 
        protected int InsertThresholdStep_Dac(string threshold_ref_id, string threshold_level, string base_line_yn, decimal point, int emp_ref_id)
        {
            string s_query = @"INSERT INTO BSC_THRESHOLD_STEP(THRESHOLD_REF_ID, THRESHOLD_LEVEL, POINT, SEQUENCE, BASE_LINE_YN, CREATE_USER, UPDATE_USER)
                               SELECT @THRESHOLD_REF_ID, @THRESHOLD_LEVEL, @POINT, @MAXSEQ +1, @BASE_LINE_YN, @EMP_REF_ID, @EMP_REF_ID
                                WHERE EXISTS (SELECT THRESHOLD_REF_ID 
                                                FROM BSC_THRESHOLD_STEP 
                                               WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL)";

            string o_query = @"INSERT INTO BSC_THRESHOLD_STEP(THRESHOLD_REF_ID, THRESHOLD_LEVEL, POINT, SEQUENCE, BASE_LINE_YN, CREATE_USER, UPDATE_USER)
                               SELECT @THRESHOLD_REF_ID, @THRESHOLD_LEVEL, @POINT, @MAXSEQ +1, @BASE_LINE_YN, @EMP_REF_ID, @EMP_REF_ID
                                 FROM DUAL
                                WHERE EXISTS (SELECT THRESHOLD_REF_ID 
                                                FROM BSC_THRESHOLD_STEP 
                                               WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL)";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.VarChar);
            paramArray[0].Value         = threshold_ref_id;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[1].Value         = threshold_level;
            paramArray[2]               = CreateDataParameter("@POINT", SqlDbType.Decimal);
            paramArray[2].Value         = point;
            paramArray[3]               = CreateDataParameter("@BASE_LINE_YN", SqlDbType.Char);
            paramArray[3].Value         = base_line_yn;
            paramArray[4]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = emp_ref_id;
            
            paramArray[5]               = CreateDataParameter("@MAXSEQ",SqlDbType.Int);
            paramArray[5].Value         = RtnMaxSeqInStep_Dac(threshold_level);


            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
        }


        // 2007.08.30 [juny177] SQL 쿼리 변경, 공통 쿼리 
        protected int DelThresholdStep_Dac(int threshold_ref_id, string threshold_level)
        {
            string query = @"DELETE BSC_THRESHOLD_STEP
                              WHERE THRESHOLD_REF_ID = @THRESHOLD_REF_ID
                                AND THRESHOLD_LEVEL  = @THRESHOLD_LEVEL";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[1].Value         = threshold_level;

            return DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
        }

        protected IDataReader InfoThresholdStep_Dac(int threshold_ref_id, string threshold_level)
        {
            string query = @"SELECT TS.THRESHOLD_REF_ID
                                   ,TC.THRESHOLD_ENAME 
                                   ,TS.THRESHOLD_LEVEL 
                                   ,TS.POINT 
                                   ,TS.SEQUENCE
                                   ,TS.BASE_LINE_YN
                                   ,(SELECT MAX(SEQUENCE) FROM BSC_THRESHOLD_STEP WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL) AS MAXSEQ            
                               FROM BSC_THRESHOLD_STEP TS
	                                LEFT OUTER JOIN BSC_THRESHOLD_CODE TC 
                                      ON TS.THRESHOLD_REF_ID = TC.THRESHOLD_REF_ID
                              WHERE TS.THRESHOLD_REF_ID = @THRESHOLD_REF_ID
	                            AND TS.THRESHOLD_LEVEL = @THRESHOLD_LEVEL";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID",   SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_LEVEL",    SqlDbType.VarChar);
            paramArray[1].Value         = threshold_level;

            IDataReader sdr           = DbAgentObj.ExecuteReader(query, paramArray, CommandType.Text);

            return sdr;
        }

        // 2007.08.30 [juny177] SQL 쿼리 변경, 공통 쿼리(GETDATE --> 후처리)
        protected int UpdateThresholdStep_Dac(int threshold_ref_id, string threshold_level, decimal point, int sequence, string base_line_yn, int emp_ref_id)
        {
            string s_query = @"UPDATE BSC_THRESHOLD_STEP
                                  SET POINT        = @POINT 
                                     ,SEQUENCE     = @SEQUENCE 
                                     ,BASE_LINE_YN = @BASE_LINE_YN
                                     ,UPDATE_USER  = @EMP_REF_ID 
                                     ,UPDATE_DATE  = GETDATE()
                                WHERE THRESHOLD_REF_ID = @THRESHOLD_REF_ID
                                  AND THRESHOLD_LEVEL  = @THRESHOLD_LEVEL";


            string o_query = @"UPDATE BSC_THRESHOLD_STEP
                                  SET POINT        = @POINT 
                                     ,SEQUENCE     = @SEQUENCE 
                                     ,BASE_LINE_YN = @BASE_LINE_YN
                                     ,UPDATE_USER  = @EMP_REF_ID 
                                     ,UPDATE_DATE  = SYSDATE
                                WHERE THRESHOLD_REF_ID = @THRESHOLD_REF_ID
                                  AND THRESHOLD_LEVEL  = @THRESHOLD_LEVEL";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID",   SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_LEVEL",    SqlDbType.VarChar);
            paramArray[1].Value         = threshold_level;
            paramArray[2]               = CreateDataParameter("@POINT",              SqlDbType.Decimal);
            paramArray[2].Value         = point;
            paramArray[3]               = CreateDataParameter("@SEQUENCE",           SqlDbType.Int);
            paramArray[3].Value         = sequence;
            paramArray[4]               = CreateDataParameter("@BASE_LINE_YN",       SqlDbType.Char);
            paramArray[4].Value         = base_line_yn;
            paramArray[5]               = CreateDataParameter("@EMP_REF_ID",         SqlDbType.Int);
            paramArray[5].Value         = emp_ref_id;

            return DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
        }

        // 2007.08.30 [juny177] SQL 쿼리 변경, 공통 쿼리 
        protected bool InsertThresholdStepNewLevel_Dac(int threshold_ref_id, string threshold_level, decimal point, string base_line_yn, int emp_ref_id)
        {
            string s_query = @"INSERT INTO BSC_THRESHOLD_STEP (THRESHOLD_REF_ID, THRESHOLD_LEVEL, POINT, SEQUENCE, BASE_LINE_YN, CREATE_USER, UPDATE_USER)
                               SELECT @THRESHOLD_REF_ID, @THRESHOLD_LEVEL, @POINT, 1, @BASE_LINE_YN, @EMP_REF_ID, @EMP_REF_ID
                                WHERE NOT EXISTS (SELECT THRESHOLD_REF_ID 
                                                    FROM BSC_THRESHOLD_STEP 
                                                   WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL)";

            string o_query = @"INSERT INTO BSC_THRESHOLD_STEP(THRESHOLD_REF_ID, THRESHOLD_LEVEL, POINT, SEQUENCE, BASE_LINE_YN, CREATE_USER, UPDATE_USER)
                               SELECT @THRESHOLD_REF_ID, @THRESHOLD_LEVEL, @POINT, 1, @BASE_LINE_YN, @EMP_REF_ID, @EMP_REF_ID
                                 FROM DUAL
                                WHERE NOT EXISTS(SELECT THRESHOLD_REF_ID 
                                                   FROM BSC_THRESHOLD_STEP 
                                                  WHERE THRESHOLD_LEVEL = @THRESHOLD_LEVEL)";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID",   SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_LEVEL",    SqlDbType.VarChar);
            paramArray[1].Value         = threshold_level;
            paramArray[2]               = CreateDataParameter("@POINT",              SqlDbType.Decimal);
            paramArray[2].Value         = point;
            paramArray[3]               = CreateDataParameter("@BASE_LINE_YN",       SqlDbType.Char);
            paramArray[3].Value         = base_line_yn;
            paramArray[4]               = CreateDataParameter("@EMP_REF_ID",         SqlDbType.Int);
            paramArray[4].Value         = emp_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);

            return (affectedRow > 0) ? true : false;
        }

        protected int IsDelStepValidate_Dac(int threshold_ref_id, string threshold_level)
        {
            string query = @"SELECT COUNT(THRESHOLD_REF_ID)
                               FROM BSC_KPI_THRESHOLD_INFO
                              WHERE THRESHOLD_LEVEL  = @THRESHOLD_LEVEL
                                AND THRESHOLD_REF_ID = @THRESHOLD_REF_ID ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[1].Value         = threshold_level;

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(query,paramArray, CommandType.Text));
        }


        // 기초 코드 관리에서 등록되어 있는 THRESHOLD_LEVEL 만 사용할수 있다.
        protected DataSet infoThresholdLevel_Dac()
        {
            string query = @"SELECT ETC_CODE
                               FROM COM_CODE_INFO
                              WHERE CATEGORY_CODE = 'BS004'
                                AND ETC_CODE NOT IN (SELECT THRESHOLD_LEVEL FROM BSC_THRESHOLD_STEP GROUP BY THRESHOLD_LEVEL)";

            DataSet ds = DbAgentObj.FillDataSet(query, "THRESHOLDLEVEL", null, null, CommandType.Text);

            return ds;
        }
    }
}
