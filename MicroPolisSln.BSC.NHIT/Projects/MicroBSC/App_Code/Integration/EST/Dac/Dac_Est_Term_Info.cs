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
    public class Dac_Est_Term_Info : DbAgentBase
    {
        public Dac_Est_Term_Info()
        {
        }

        public DataTable Select_DB(object comp_id
                                , object est_id
                                , object estterm_sub_id
                                , object estterm_ref_id)
        {
            string sqlQuery = @"
SELECT CAST(YEAR(A.EST_STARTDATE) AS VARCHAR)   +   
       CASE WHEN DATALENGTH(CAST(B.END_MONTH AS VARCHAR)) = 2 
            THEN CAST(B.END_MONTH AS VARCHAR) 
            ELSE  '0' + CONVERT(VARCHAR, B.END_MONTH)
       END AS TEMP
FROM EST_TERM_INFO A LEFT OUTER JOIN EST_TERM_SUB    B ON(   B.COMP_ID        = @COMP_ID 
                                                         AND B.ESTTERM_SUB_ID = @ESTTERM_SUB_ID)
WHERE A.ESTTERM_REF_ID  = @ESTTERM_REF_ID

";

            string orclQuery = @"

SELECT CAST(YEAR(A.EST_STARTDATE) AS VARCHAR)   +   
       CASE WHEN DATALENGTH(CAST(B.END_MONTH AS VARCHAR)) = 2 
            THEN CAST(B.END_MONTH AS VARCHAR) 
            ELSE  '0' + CONVERT(VARCHAR, B.END_MONTH)
       END AS TEMP
FROM EST_TERM_INFO A LEFT OUTER JOIN EST_TERM_SUB    B ON(   B.COMP_ID        = @COMP_ID 
                                                         AND B.ESTTERM_SUB_ID = @ESTTERM_SUB_ID)
WHERE A.ESTTERM_REF_ID  = @ESTTERM_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = estterm_sub_id;
            paramArray[2].Value = estterm_ref_id;

            DataTable dt = DbAgentObj.FillDataSet(GetQueryStringByDb(sqlQuery, orclQuery), null, null, paramArray).Tables[0];

            return dt;
        }


        public DataTable Select_Start_End_YearMonth(object comp_id
                                                , object estterm_sub_id
                                                , object estterm_ref_id)
        {
            string sqlQuery = @"
SELECT      CONVERT(A.EST_STARTDATE, varchar(4), 20)
                + CASE WHEN     LEN(B.START_MONTH)  =   2   THEN    B.START_MONTH
                                                            ELSE    '0' +   B.START_MONTH   AS  START_YEARMONTH
            , CONVERT(A.EST_COMPDATE, varchar(4), 20)
                + CASE WHEN     LEN(B.END_MONTH)    =   2   THEN    B.END_MONTH
                                                            ELSE    '0' +   B.END_MONTH     AS  END_YEARMONTH
    FROM                EST_TERM_INFO   A
            LEFT OUTER JOIN EST_TERM_SUB    B
                ON  (
                        B.COMP_ID           =   @COMP_ID
                    AND B.ESTTERM_SUB_ID    =   @ESTTERM_SUB_ID
                    )
    WHERE       A.ESTTERM_REF_ID        =   @ESTTERM_REF_ID
";

            string orclQuery = @"
SELECT      TO_CHAR(A.EST_STARTDATE, 'yyyy') || TO_CHAR(TO_DATE(B.START_MONTH, 'MM'), 'MM') AS START_YEARMONTH
            , TO_CHAR(A.EST_COMPDATE, 'yyyy') || TO_CHAR(TO_DATE(B.END_MONTH, 'MM'), 'MM')  AS END_YEARMONTH
    FROM                EST_TERM_INFO   A
        LEFT OUTER JOIN EST_TERM_SUB    B
            ON  (
                    B.COMP_ID           =   @COMP_ID
                AND B.ESTTERM_SUB_ID    =   @ESTTERM_SUB_ID
                )
    WHERE       A.ESTTERM_REF_ID        =   @ESTTERM_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2] = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);

            paramArray[0].Value = comp_id;
            paramArray[1].Value = estterm_ref_id;
            paramArray[2].Value = estterm_sub_id;

            DataTable dt = DbAgentObj.FillDataSet(GetQueryStringByDb(sqlQuery, orclQuery), "START_END_YEARMONTH", null, paramArray).Tables[0];

            return dt;
        }
    }
}
