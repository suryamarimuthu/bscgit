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
/// Dac_Bsc_Faq에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Faq Dac 클래스
/// Class 내용		@ Bsc_Faq Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 서대원    
/// 최초작성일		@ 2012.09.14
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 
namespace MicroBSC.Integration.BSC.Dac
{

    public class Dac_Bsc_Faq : DbAgentBase
    {
      
        public Dac_Bsc_Faq()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        
        public DataTable SelectBscFaqAll()
        {
//            string query = @"
//SELECT FAQ_REF_ID,
//       FAQ_CATEGORY_ID,
//       FAQ_QUESTION,
//       FAQ_ANSWER,
//       READ_COUNT,
//       FAQ_USER,
//       ISDELETE,
//       CREATE_USER,
//       CREATE_DATE,
//       UPDATE_USER,
//       UPDATE_DATE
//  FROM BSC_COMMUNICATION_FAQ 
// WHERE ISDELETE = 'N'
// ORDER BY FAQ_CATEGORY_ID, FAQ_REF_ID ASC
//";
            string query = @"
SELECT 
       FAQ_QUESTION, FAQ_REF_ID
       
  FROM BSC_COMMUNICATION_FAQ 
WHERE ROWNUM <= 4
 ";

            //IDbDataParameter[] paramArray = CreateDataParameters(1);

            //paramArray[0] = CreateDataParameter("@ISDELETE", SqlDbType.VarChar );

            //paramArray[0].Value = "N";


            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_FAQ_ALL", null, null, CommandType.Text).Tables[0];
            return dt;


        }

        public DataTable SelectBscFaqAll(string question)
        {
            string query = @"
            SELECT FAQ_REF_ID,
                   FAQ_QUESTION,
                   FAQ_ANSWER,
                   READ_COUNT,
                   FAQ_USER,
                   ISDELETE,
                   CREATE_USER,
                   CREATE_DATE,
                   UPDATE_USER,
                   UPDATE_DATE
             FROM BSC_COMMUNICATION_FAQ 
             WHERE ISDELETE = 'N'
             AND (FAQ_QUESTION LIKE '%' + @FAQ_QUESTION + '%' OR  @FAQ_QUESTION ='') 
             ORDER BY FAQ_CATEGORY_ID ASC, FAQ_REF_ID ASC";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@FAQ_QUESTION", SqlDbType.VarChar);
            paramArray[0].Value = question;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_FAQ_ALL", null, paramArray, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable SelectBscFaqCateAll(object faq_category)
        {
            string query = @"
SELECT FAQ_REF_ID,
       FAQ_CATEGORY_ID,
       FAQ_QUESTION,
       FAQ_ANSWER,
       READ_COUNT,
       FAQ_USER,
       ISDELETE,
       CREATE_USER,
       CREATE_DATE,
       UPDATE_USER,
       UPDATE_DATE
  FROM BSC_COMMUNICATION_FAQ 
 WHERE ISDELETE = 'N'
   AND FAQ_CATEGORY_ID = @FAQ_CATEGORY
  AND ROWNUM <= 4
 ORDER BY FAQ_CATEGORY_ID, FAQ_REF_ID ASC
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@FAQ_CATEGORY", SqlDbType.Int);

            paramArray[0].Value = faq_category;


            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_FAQ_CATE_ALL",null,paramArray, CommandType.Text).Tables[0];

            return dt;
        }


        public DataTable SelectBscFaqIdxAll(object faq_category, object IDX)
        {
            string query = @"
SELECT A.FAQ_REF_ID,
       A.FAQ_CATEGORY_ID,
       A.FAQ_QUESTION,
       A.FAQ_ANSWER,
       A.READ_COUNT,
       A.FAQ_USER,
       A.ISDELETE,
       A.CREATE_USER,
       A.CREATE_DATE,
       A.UPDATE_USER,
       A.UPDATE_DATE
  FROM BSC_COMMUNICATION_FAQ A
 WHERE A.ISDELETE = 'N'
   AND A.FAQ_CATEGORY_ID = @FAQ_CATEGORY_ID
   AND A.FAQ_REF_ID = @FAQ_REF_ID
  AND ROWNUM <= 4
 ORDER BY A.FAQ_CATEGORY_ID, A.FAQ_REF_ID ASC
";
            
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@FAQ_CATEGORY_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@FAQ_REF_ID", SqlDbType.Int);

            paramArray[0].Value = faq_category;
            paramArray[1].Value = IDX;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_FAQ_IDX_ALL",null,paramArray, CommandType.Text).Tables[0];

            return dt;
        }

        public DataTable SelectBscFaqIdxAll(object IDX)
        {
            string query = @"
SELECT A.FAQ_REF_ID,
       A.FAQ_CATEGORY_ID,
       A.FAQ_QUESTION,
       A.FAQ_ANSWER,
       A.READ_COUNT,
       A.FAQ_USER,
       A.ISDELETE,
       A.CREATE_USER,
       A.CREATE_DATE,
       A.UPDATE_USER,
       A.UPDATE_DATE
  FROM BSC_COMMUNICATION_FAQ A
 WHERE A.ISDELETE = 'N'
   AND A.FAQ_REF_ID = @FAQ_REF_ID
  AND ROWNUM <= 4
 ORDER BY A.FAQ_CATEGORY_ID, A.FAQ_REF_ID ASC
";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@FAQ_REF_ID", SqlDbType.Int);
            paramArray[0].Value = IDX;

            DataTable dt = DbAgentObj.FillDataSet(query, "BSC_FAQ_IDX_ALL", null, paramArray, CommandType.Text).Tables[0];

            return dt;
        }


        public int Delete_DB(IDbConnection idc
                                , IDbTransaction idt
                                , object IDX, object UPDATE_USER)
        {



            string query = @"
-- BSC FAQ DELETE
UPDATE     BSC_COMMUNICATION_FAQ  
   SET   
        ISDELETE = 'Y',
        UPDATE_DATE = @UPDATEDATE,
        UPDATE_USER = @UPDATE_USER
WHERE   FAQ_REF_ID  = @IDX
";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@UPDATEDATE", SqlDbType.Date);
            paramArray[2] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);

            paramArray[0].Value = IDX;
            paramArray[1].Value = DateTime.Now;
            paramArray[2].Value = UPDATE_USER;

            int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, query, paramArray, CommandType.Text);

            return affectedRow;
        }


        public int InsertData_DB(IDbConnection conn
                               , IDbTransaction trx
                               , object FAQ_CATEGORY
                               , object FAQ_QUESTION
                               , object FAQ_ANSWER
                               , object CREATE_USER)
        {
            string query = @"
INSERT INTO     BSC_COMMUNICATION_FAQ    
            (
                FAQ_REF_ID,
                FAQ_CATEGORY_ID,
                FAQ_QUESTION,
                FAQ_ANSWER,
                FAQ_USER,
                CREATE_USER
            )
    VALUES  (
                SEQ_BSC_COMMUNICATION_FAQ.nextval
                , @FAQ_CATEGORY
                , @FAQ_QUESTION
                , @FAQ_ANSWER
                , @FAQ_USER
                , @CREATE_USER
           )
";

            IDbDataParameter[] paramArray = CreateDataParameters(5);


            paramArray[0] = CreateDataParameter("@FAQ_CATEGORY", SqlDbType.Int);
            paramArray[0].Value = FAQ_CATEGORY;
            paramArray[1] = CreateDataParameter("@FAQ_QUESTION", SqlDbType.NVarChar);
            paramArray[1].Value = FAQ_QUESTION;
            paramArray[2] = CreateDataParameter("@FAQ_ANSWER", SqlDbType.NVarChar);
            paramArray[2].Value = FAQ_ANSWER;
            paramArray[3] = CreateDataParameter("@FAQ_USER", SqlDbType.Int);
            paramArray[3].Value = CREATE_USER;
            paramArray[4] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[4].Value = CREATE_USER;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }


        public int UpdateData_DB(IDbConnection conn
                               , IDbTransaction trx
                               , object IDX
                               , object FAQ_CATEGORY
                               , object FAQ_QUESTION
                               , object FAQ_ANSWER
                               , object UPDATE_USER)
        {
            string query = @"
UPDATE BSC_COMMUNICATION_FAQ  
   SET   
        FAQ_CATEGORY_ID = @FAQ_CATEGORY, 
        FAQ_QUESTION =  @FAQ_QUESTION, 
        FAQ_ANSWER = @FAQ_ANSWER,
        UPDATE_DATE = GETDATE(),
        UPDATE_USER = @UPDATE_USER
WHERE FAQ_REF_ID = @IDX
";

            IDbDataParameter[] paramArray = CreateDataParameters(6);


            paramArray[0] = CreateDataParameter("@FAQ_CATEGORY", SqlDbType.Int);
            paramArray[0].Value = FAQ_CATEGORY;
            paramArray[1] = CreateDataParameter("@FAQ_QUESTION", SqlDbType.NVarChar);
            paramArray[1].Value = FAQ_QUESTION;
            paramArray[2] = CreateDataParameter("@FAQ_ANSWER", SqlDbType.NVarChar);
            paramArray[2].Value = FAQ_ANSWER;
            paramArray[4] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[4].Value = UPDATE_USER;
            paramArray[5] = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[5].Value = IDX;


            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);

            return affectedRow;
        }



    }
}
