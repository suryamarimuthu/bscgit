using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_Boards : DbAgentBase
    {
	    public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string board_id
                        , string board_category_id
                        , string subject_text
                        , string content_text
                        , int read_count
                        , string attach_no
                        , string p_board_id
                        , string group_id
                        , int level_id
                        , int seq_id
                        , object start_date
                        , object end_date
                        , int menu_ref_id
                        , string pop_up_yn
                        , int write_emp_id
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_BOARD
	                            SET	BOARD_CATEGORY_ID	= @BOARD_CATEGORY_ID
		                            ,SUBJECT_TEXT		= @SUBJECT_TEXT
		                            ,CONTENT_TEXT		= @CONTENT_TEXT
		                            ,READ_COUNT			= @READ_COUNT
		                            ,ATTACH_NO			= @ATTACH_NO
		                            ,P_BOARD_ID			= @P_BOARD_ID
		                            ,GROUP_ID			= @GROUP_ID
		                            ,LEVEL_ID			= @LEVEL_ID
		                            ,SEQ_ID				= @SEQ_ID
		                            ,START_DATE			= @START_DATE
		                            ,END_DATE			= @END_DATE
                                    ,MENU_REF_ID        = @MENU_REF_ID
		                            ,POP_UP_YN			= @POP_UP_YN
		                            ,WRITE_EMP_ID		= @WRITE_EMP_ID
		                            ,UPDATE_DATE		= @UPDATE_DATE
		                            ,UPDATE_USER		= @UPDATE_USER
	                            WHERE	BOARD_ID		= @BOARD_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(17);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = board_id;
	        paramArray[1] 		= CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value = board_category_id;
	        paramArray[2] 		= CreateDataParameter("@SUBJECT_TEXT", SqlDbType.NVarChar, 200);
	        paramArray[2].Value = subject_text;
	        paramArray[3] 		= CreateDataParameter("@CONTENT_TEXT", SqlDbType.NVarChar, 4000);
	        paramArray[3].Value = content_text;
	        paramArray[4] 		= CreateDataParameter("@READ_COUNT", SqlDbType.Int);
	        paramArray[4].Value = read_count;
	        paramArray[5] 		= CreateDataParameter("@ATTACH_NO", SqlDbType.NVarChar, 200);
	        paramArray[5].Value = attach_no;
	        paramArray[6] 		= CreateDataParameter("@P_BOARD_ID", SqlDbType.NVarChar, 100);
	        paramArray[6].Value = p_board_id;
	        paramArray[7] 		= CreateDataParameter("@GROUP_ID", SqlDbType.NVarChar, 100);
	        paramArray[7].Value = group_id;
	        paramArray[8] 		= CreateDataParameter("@LEVEL_ID", SqlDbType.Int);
	        paramArray[8].Value = level_id;
	        paramArray[9] 		= CreateDataParameter("@SEQ_ID", SqlDbType.Int);
	        paramArray[9].Value= seq_id;
	        paramArray[10] 		= CreateDataParameter("@START_DATE", SqlDbType.DateTime);
	        paramArray[10].Value= start_date;
	        paramArray[11] 		= CreateDataParameter("@END_DATE", SqlDbType.DateTime);
	        paramArray[11].Value= end_date;
            paramArray[12]      = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[12].Value= menu_ref_id;
	        paramArray[13] 		= CreateDataParameter("@POP_UP_YN", SqlDbType.NChar);
	        paramArray[13].Value= pop_up_yn;
	        paramArray[14] 		= CreateDataParameter("@WRITE_EMP_ID", SqlDbType.Int);
	        paramArray[14].Value= write_emp_id;
	        paramArray[15] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[15].Value= update_date;
	        paramArray[16] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[16].Value= update_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        public DataSet Select(string board_id, string board_category_id, int menu_ref_id, string popup_yn)
        {
            string query = @"SELECT	 BRD.BOARD_ID
                                    ,BRD.BOARD_CATEGORY_ID
                                    ,BRD.SUBJECT_TEXT
                                    ,BRD.CONTENT_TEXT
                                    ,BRD.READ_COUNT
                                    ,BRD.ATTACH_NO
                                    ,BRD.P_BOARD_ID
                                    ,BRD.GROUP_ID
                                    ,BRD.LEVEL_ID
                                    ,BRD.SEQ_ID
                                    ,BRD.START_DATE
                                    ,BRD.END_DATE
                                    ,BRD.MENU_REF_ID
                                    ,BRD.POP_UP_YN
                                    ,BRD.WRITE_EMP_ID
                                    ,EMP.EMP_NAME AS WRITE_EMP_NAME
                                    ,BRD.CREATE_DATE
                                    ,BRD.CREATE_USER
                                    ,BRD.UPDATE_DATE
                                    ,BRD.UPDATE_USER
                                    FROM	EST_BOARD BRD
                                    LEFT JOIN COM_EMP_INFO EMP
                                    ON EMP.EMP_REF_ID = BRD.WRITE_EMP_ID
	                                WHERE	(BRD.BOARD_ID           = @BOARD_ID             OR @BOARD_ID              =''    )
                                        AND (BRD.BOARD_CATEGORY_ID  = @BOARD_CATEGORY_ID    OR @BOARD_CATEGORY_ID     =''    )
                                        AND (BRD.MENU_REF_ID        = @MENU_REF_ID          OR @MENU_REF_ID       = 0)
                                        AND (BRD.POP_UP_YN          = @POP_UP_YN            OR @POP_UP_YN             =''    )
                                    ORDER BY BOARD_ID DESC";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = board_id;
            paramArray[1]       = CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = board_category_id;
            paramArray[2]       = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[2].Value = menu_ref_id;
            paramArray[3]       = CreateDataParameter("@POP_UP_YN", SqlDbType.NVarChar,1);
            paramArray[3].Value = popup_yn;
         
	        DataSet ds = DbAgentObj.FillDataSet(query, "BOARDGET" , null, paramArray, CommandType.Text);
	        return ds;
        }
         
        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string board_id
                        , string board_category_id
                        , string subject_text
                        , string content_text
                        , int read_count
                        , string attach_no
                        , string p_board_id
                        , string group_id
                        , int level_id
                        , int seq_id
                        , object start_date
                        , object end_date
                        , int menu_ref_id
                        , string pop_up_yn
                        , int write_emp_id
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_BOARD(BOARD_ID
			                                        ,BOARD_CATEGORY_ID
			                                        ,SUBJECT_TEXT
			                                        ,CONTENT_TEXT
			                                        ,READ_COUNT
			                                        ,ATTACH_NO
			                                        ,P_BOARD_ID
			                                        ,GROUP_ID
			                                        ,LEVEL_ID
			                                        ,SEQ_ID
			                                        ,START_DATE
			                                        ,END_DATE
                                                    ,MENU_REF_ID
			                                        ,POP_UP_YN
			                                        ,WRITE_EMP_ID
			                                        ,CREATE_DATE
			                                        ,CREATE_USER
			                                        ,UPDATE_DATE
			                                        ,UPDATE_USER
			                                        )
		                                        VALUES	(@BOARD_ID
			                                        ,@BOARD_CATEGORY_ID
			                                        ,@SUBJECT_TEXT
			                                        ,@CONTENT_TEXT
			                                        ,@READ_COUNT
			                                        ,@ATTACH_NO
			                                        ,@P_BOARD_ID
			                                        ,@GROUP_ID
			                                        ,@LEVEL_ID
			                                        ,@SEQ_ID
			                                        ,@START_DATE
			                                        ,@END_DATE
                                                    ,@MENU_REF_ID
			                                        ,@POP_UP_YN
			                                        ,@WRITE_EMP_ID
			                                        ,@CREATE_DATE
			                                        ,@CREATE_USER
			                                        ,NULL
			                                        ,NULL)";

	        IDbDataParameter[] paramArray = CreateDataParameters(17);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_ID", SqlDbType.NVarChar, 10);
	        paramArray[0].Value = board_id;
	        paramArray[1] 		= CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 10);
	        paramArray[1].Value = board_category_id;
	        paramArray[2] 		= CreateDataParameter("@SUBJECT_TEXT", SqlDbType.NVarChar, 100);
	        paramArray[2].Value = subject_text;
	        paramArray[3] 		= CreateDataParameter("@CONTENT_TEXT", SqlDbType.NVarChar, 4000);
	        paramArray[3].Value = content_text;
	        paramArray[4] 		= CreateDataParameter("@READ_COUNT", SqlDbType.Int);
	        paramArray[4].Value = read_count;
	        paramArray[5] 		= CreateDataParameter("@ATTACH_NO", SqlDbType.NVarChar, 100);
	        paramArray[5].Value = attach_no;
	        paramArray[6] 		= CreateDataParameter("@P_BOARD_ID", SqlDbType.NVarChar, 50);
	        paramArray[6].Value = p_board_id;
	        paramArray[7] 		= CreateDataParameter("@GROUP_ID", SqlDbType.NVarChar, 50);
	        paramArray[7].Value = group_id;
	        paramArray[8] 		= CreateDataParameter("@LEVEL_ID", SqlDbType.Int);
	        paramArray[8].Value = level_id;
	        paramArray[9] 		= CreateDataParameter("@SEQ_ID", SqlDbType.Int);
	        paramArray[9].Value= seq_id;
	        paramArray[10] 		= CreateDataParameter("@START_DATE", SqlDbType.DateTime);
	        paramArray[10].Value= start_date;
	        paramArray[11] 		= CreateDataParameter("@END_DATE", SqlDbType.DateTime);
	        paramArray[11].Value= end_date;
            paramArray[12]      = CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
            paramArray[12].Value= menu_ref_id;
	        paramArray[13] 		= CreateDataParameter("@POP_UP_YN", SqlDbType.NChar);
	        paramArray[13].Value= pop_up_yn;
	        paramArray[14] 		= CreateDataParameter("@WRITE_EMP_ID", SqlDbType.Int);
	        paramArray[14].Value= write_emp_id;
	        paramArray[15] 		= CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
	        paramArray[15].Value= create_date;
	        paramArray[16] 		= CreateDataParameter("@CREATE_USER", SqlDbType.Int);
	        paramArray[16].Value= create_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string board_id
                        , string board_category_id)
        {
            string query = @"DELETE	EST_BOARD
	                            WHERE	BOARD_ID            = @BOARD_ID
                                   AND  BOARD_CATEGORY_ID   = @BOARD_CATEGORY_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(2);
         
	        paramArray[0] 		= CreateDataParameter("@BOARD_ID", SqlDbType.NVarChar, 20);
	        paramArray[0].Value = board_id;
            paramArray[1]       = CreateDataParameter("@BOARD_CATEGORY_ID", SqlDbType.NVarChar, 20);
            paramArray[1].Value = board_category_id;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
    }
}
