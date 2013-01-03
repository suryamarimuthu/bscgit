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
/// Dac_Bsc_Threshold_Code의 요약 설명입니다.
/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Threshold_Code Dac 클래스
/// Class 내용		@ Bsc_Threshold_Code Dac 처리 
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
    public class Dac_Bsc_Threshold_Code : DbAgentBase
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

        public Dac_Bsc_Threshold_Code() { }

        protected int RtnThresholdCodeMaxSeq_Dac()
        {
            string s_query = @"
                                SELECT 
                                    ISNULL(MAX(SEQUENCE) ,0) AS MAXSEQ
                                FROM
                                    BSC_THRESHOLD_CODE
            ";

            string o_query = @"
                                SELECT 
                                    NVL(MAX(SEQUENCE) ,0) AS MAXSEQ
                                FROM
                                    BSC_THRESHOLD_CODE
            ";


            return Convert.ToInt32(DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query)));
        }

        protected DataSet GetThresholdCodeList_Dac(string threshold_level)
        {
            string query = @"
            
	                            SELECT 
		                            THRESHOLD_REF_ID,    
		                            THRESHOLD_KNAME,
		                            THRESHOLD_ENAME,
		                            IMAGE_FILE_NAME,
		                            SEQUENCE,
		                            USE_YN,
                                    DEFAULT_IMG_YN,
                                    ALERT_IMG_YN,
                                    THRESHOLD_COLOR
	                            FROM
		                            BSC_THRESHOLD_CODE
	                            WHERE
		                            THRESHOLD_REF_ID NOT IN 
		                            (
			                            SELECT
				                            THRESHOLD_REF_ID
			                            FROM
				                            BSC_THRESHOLD_STEP	
			                            WHERE
				                            (THRESHOLD_LEVEL = @THRESHOLD_LEVEL OR THRESHOLD_LEVEL     =''    )
		                            )
                                  AND USE_YN = 'Y'
	                            ORDER BY
		                            SEQUENCE

            ";

            DataSet ds = new DataSet();

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_LEVEL", SqlDbType.VarChar);
            paramArray[0].Value         = threshold_level;

            ds = DbAgentObj.FillDataSet(query, "BSC_THRESHOLD_CODE", null, paramArray, CommandType.Text);

            return ds;
        }

        // 같은영문명이나 한글명을 가지고 있는 코드가 등록되어 있는 지 여부 리턴- true:중복값있음, false:중복값없음
        protected bool UseThresholdName_Dac(string threshold_ename, string threshold_kname)
        {
            string query = @"
                                SELECT 
                                    THRESHOLD_REF_ID 
                                FROM 
                                    BSC_THRESHOLD_CODE 
		                        WHERE 
                                    (THRESHOLD_ENAME = @THRESHOLD_ENAME) OR ( THRESHOLD_KNAME = @THRESHOLD_KNAME)
            ";
            
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_ENAME",    SqlDbType.VarChar);
            paramArray[0].Value         = threshold_ename;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_KNAME",    SqlDbType.VarChar);
            paramArray[1].Value         = threshold_kname;


            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
            return (affectedRow > 0) ? true : false;

        }

        // 순서 변경 쿼리 
        protected int GetThresholdCodeAddSeqUpdate(int sequence)
        {
            string query = @"	
                                UPDATE
	                                BSC_THRESHOLD_CODE
                                SET
	                                SEQUENCE = SEQUENCE + 1
                                WHERE
	                                SEQUENCE >= @SEQUENCE
                                    AND EXISTS (SELECT THRESHOLD_REF_ID FROM BSC_THRESHOLD_CODE WHERE SEQUENCE = @SEQUENCE)
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[0].Value = sequence;

            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);

            return affectedRow;
        }

            // 순서 변경 쿼리 
        protected int GetThresholdCodeDelSeqUpdate(int oldseq)
        {
            string query = @"	
                                UPDATE 
                                    BSC_THRESHOLD_CODE
                                SET 
                                    SEQUENCE = SEQUENCE - 1
                                WHERE
                                    SEQUENCE > @OLDSEQ
                                   
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@OLDSEQ", SqlDbType.Int);
            paramArray[0].Value = oldseq;

            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);

            return affectedRow;
        }

        // 순서변경 쿼리
        protected int GetThersholdcodeSeqUpdatd(int sequence, int oldseq, string state)
        {
            string query = "";

            if (state == "P")
            {
                query = @"    
                                UPDATE 
                                    BSC_THRESHOLD_CODE
                                SET 
                                    SEQUENCE = SEQUENCE + 1
                                WHERE                                              
                                    SEQUENCE < @OLDSEQ
                                    AND SEQUENCE >= @SEQUENCE        
            ";
            }
            else if (state == "M")
            {
                query = @"      
                                UPDATE 
                                    BSC_THRESHOLD_CODE
                                SET 
                                    SEQUENCE = SEQUENCE - 1
                                WHERE                                                                                     
                                    SEQUENCE > @OLDSEQ
                                    AND SEQUENCE <= @SEQUENCE        
                           
            ";
            }


            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[0].Value = sequence;
            paramArray[1] = CreateDataParameter("@OLDSEQ", SqlDbType.Int);
            paramArray[1].Value = oldseq;

            int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);

            return affectedRow;
        }
		
        protected int InsertThresholdCode_Dac(string threshold_ename, string threshold_kname, string image_file_name, int sequence, string use_yn, int emp_ref_id)
        {            
           
            string s_query = @"
                                INSERT INTO BSC_THRESHOLD_CODE
	                                (
		                                THRESHOLD_ENAME, 
		                                THRESHOLD_KNAME, 
		                                IMAGE_FILE_NAME, 
		                                SEQUENCE, 
		                                USE_YN,
		                                CREATE_USER,
		                                UPDATE_USER
	                                )
                                VALUES
	                                (
		                                @THRESHOLD_ENAME, 
		                                @THRESHOLD_KNAME, 
		                                @IMAGE_FILE_NAME, 
		                                @SEQUENCE, 
		                                @USE_YN, 
		                                @EMP_REF_ID,                                         
		                                @EMP_REF_ID
	                                )
            ";

            string o_query = @"
                                
                                INSERT INTO BSC_THRESHOLD_CODE
	                                (
                                        THRESHOLD_REF_ID,
		                                THRESHOLD_ENAME, 
		                                THRESHOLD_KNAME, 
		                                IMAGE_FILE_NAME, 
		                                SEQUENCE, 
		                                USE_YN,
		                                CREATE_USER,
		                                UPDATE_USER
	                                )
                                VALUES
	                                (
                                        SEQ_BSC_THRESHOLD_CODE.NEXTVAL,
		                                @THRESHOLD_ENAME, 
		                                @THRESHOLD_KNAME, 
		                                @IMAGE_FILE_NAME, 
		                                @SEQUENCE, 
		                                @USE_YN, 
		                                @EMP_REF_ID,                                         
		                                @EMP_REF_ID
	                                )
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_ENAME",    SqlDbType.VarChar);
            paramArray[0].Value         = threshold_ename;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_KNAME",    SqlDbType.VarChar);
            paramArray[1].Value         = threshold_kname;
            paramArray[2]               = CreateDataParameter("@IMAGE_FILE_NAME",    SqlDbType.VarChar);
            paramArray[2].Value         = image_file_name;
            paramArray[3]               = CreateDataParameter("@SEQUENCE",           SqlDbType.Int);
            paramArray[3].Value         = sequence;
            paramArray[4]               = CreateDataParameter("@USE_YN",             SqlDbType.Char);
            paramArray[4].Value         = use_yn;
            paramArray[5]               = CreateDataParameter("@EMP_REF_ID",         SqlDbType.Int);
            paramArray[5].Value         = emp_ref_id;

            int affectedRow             = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);

            return affectedRow;
        }

        protected IDataReader InfoThresholdCode_Doc(int threshold_ref_id)
        {
            string query = @"
	                            SELECT 
                                    (SELECT COUNT(THRESHOLD_REF_ID) FROM BSC_THRESHOLD_CODE) AS TOTCOUNT,
		                            THRESHOLD_REF_ID,
		                            THRESHOLD_KNAME,
		                            THRESHOLD_ENAME,
		                            IMAGE_FILE_NAME,
		                            SEQUENCE,
		                            USE_YN		
	                            FROM
		                            BSC_THRESHOLD_CODE
	                            WHERE
		                            THRESHOLD_REF_ID = CASE WHEN @THRESHOLD_REF_ID=0 THEN THRESHOLD_REF_ID
                                                            ELSE @THRESHOLD_REF_ID
                                                       END
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;

            return DbAgentObj.ExecuteReader(query, paramArray, CommandType.Text);
        }

        protected int RtnThresholdCodeOldSeq_Dac(int threshold_ref_id)
        {
            string query = @"
                                SELECT 
                                    SEQUENCE AS OLDSEQ 
                                FROM 
                                    BSC_THRESHOLD_CODE 
                                WHERE 
                                    THRESHOLD_REF_ID = @THRESHOLD_REF_ID
            ";


            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@THRESHOLD_REF_ID", SqlDbType.Int);
            paramArray[0].Value = threshold_ref_id;

            return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
        }

        // 2007.09.03 [juny177] SQL 쿼리 변경 >> 공용쿼리 사용
        protected int UpdateThresholdCode_Dac(int threshold_ref_id, string threshold_ename, string thrreshold_kname, string image_file_name, int sequence, string use_yn, int emp_ref_id)
        {
            string s_query = @"

                                UPDATE 
	                                BSC_THRESHOLD_CODE
                                SET	
                                    THRESHOLD_KNAME		        = @THRESHOLD_KNAME,
                                    THRESHOLD_ENAME	        	= @THRESHOLD_ENAME, 
                                    IMAGE_FILE_NAME	        	= @IMAGE_FILE_NAME, 
                                    SEQUENCE					= @SEQUENCE,
                                    USE_YN						= @USE_YN,
	                                UPDATE_DATE			        = GETDATE(),
	                                UPDATE_USER				    = @EMP_REF_ID
                                WHERE 
	                                THRESHOLD_REF_ID = @THRESHOLD_REF_ID
                               
            ";

            string o_query = @"

                                UPDATE 
	                                BSC_THRESHOLD_CODE
                                SET	
                                    THRESHOLD_KNAME		        = @THRESHOLD_KNAME,
                                    THRESHOLD_ENAME	        	= @THRESHOLD_ENAME, 
                                    IMAGE_FILE_NAME	        	= @IMAGE_FILE_NAME, 
                                    SEQUENCE					= @SEQUENCE,
                                    USE_YN						= @USE_YN,
	                                UPDATE_DATE			        = SYSDATE,
	                                UPDATE_USER				    = @EMP_REF_ID
                                WHERE 
	                                THRESHOLD_REF_ID = @THRESHOLD_REF_ID
                               
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(7);


            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID",  SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;
            paramArray[1]               = CreateDataParameter("@THRESHOLD_ENAME",   SqlDbType.VarChar);
            paramArray[1].Value         = threshold_ename;
            paramArray[2]               = CreateDataParameter("@THRESHOLD_KNAME",   SqlDbType.VarChar);
            paramArray[2].Value         = thrreshold_kname;
            paramArray[3]               = CreateDataParameter("@IMAGE_FILE_NAME",   SqlDbType.VarChar);
            paramArray[3].Value         = image_file_name;
            paramArray[4]               = CreateDataParameter("@SEQUENCE",          SqlDbType.Int);
            paramArray[4].Value         = sequence;

            paramArray[5]               = CreateDataParameter("@USE_YN",            SqlDbType.Char);
            paramArray[5].Value         = use_yn;
            paramArray[6]               = CreateDataParameter("@EMP_REF_ID",        SqlDbType.Int);
            paramArray[6].Value         = emp_ref_id;            

            int affectedRow             = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);

            return affectedRow;

        }


        // 2007.09.03 [juny177] SQL 쿼리 변경 >> 공용쿼리 사용
        protected int DelThresholdCode_Dac(int threshold_ref_id)
        {
            string query = @"  
                                        DELETE 
                                            BSC_THRESHOLD_CODE
                                        WHERE
                                            THRESHOLD_REF_ID = @THRESHOLD_REF_ID
                                                   
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@THRESHOLD_REF_ID",  SqlDbType.Int);
            paramArray[0].Value         = threshold_ref_id;

            int affectedRow             = DbAgentObj.ExecuteNonQuery(query,paramArray,CommandType.Text);
            return affectedRow;
        }

    }
}