using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Interface_Kpi_Query
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Interface_Kpi_Query
    /// Class Func     : BSC_INTERFACE_KPI_QUERY Table Data Access
    /// CREATE DATE    : 2008-07-27 오후 3:47:20
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Interface_Data : DbAgentBase
    {
        public int TransactionInterfaceData(string sQuery)
        {
            return 0;
        }

        public DataTable GetBscInterfaceDataSchema(IDbConnection conn, IDbTransaction trx)
        {
            string query  = "SELECT * from BSC_INTERFACE_DATA WHERE 1=0";
            DataSet rDs   = DbAgentObj.FillDataSet(conn, trx, query, "BSC_INTERFACE_DATA",null, null, CommandType.Text);
            DataTable Tbl = new DataTable("BSC_INTERFACE_DATA");
            if (rDs.Tables.Count > 0)
            {
                Tbl = rDs.Tables[0];
            }
            return Tbl;
        }

        public DataTable GetInterfaceDataForDayResult(object dicode, object ymd, object sumtype)
        {
            string ymd1 = string.Empty;
            string ymd3 = string.Empty;
            if (ymd.ToString().Substring(4, 2) == "01")
            {
                ymd1 = (DataTypeUtility.GetToInt32(ymd.ToString().Substring(0, 4)) - 1).ToString() + "12";
                ymd3 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) + 1).ToString("00");
            }
            else if (ymd.ToString().Substring(4, 2) == "12")
            {
                ymd1 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) - 1).ToString("00");
                ymd3 = (DataTypeUtility.GetToInt32(ymd.ToString().Substring(0, 4)) + 1).ToString() + "01";
            }
            else
            {
                ymd1 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) - 1).ToString("00");
                ymd3 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) + 1).ToString("00");
            }

            string strQuery = @"
SELECT	 A.YEARMONTH, A.YMD
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '01' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY01
		,SUM(ISNULL(CASE WHEN B.RDDATE {0} '02' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY02
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '03' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY03
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '04' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY04
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '05' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY05
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '06' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY06
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '07' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY07
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '08' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY08
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '09' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY09
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '10' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY10

        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '11' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY11
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '12' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY12
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '13' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY13
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '14' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY14
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '15' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY15
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '16' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY16
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '17' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY17
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '18' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY18
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '19' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY19
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '20' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY20

        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '21' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY21
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '22' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY22
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '23' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY23
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '24' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY24
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '25' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY25
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '26' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY26
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '27' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY27
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '28' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY28
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '29' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY29
        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '30' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY30

        ,SUM(ISNULL(CASE WHEN B.RDDATE {0} '31' THEN B.DVALUES1 ELSE 0 END, 0)) AS DAY31
FROM (
    SELECT SUBSTRING(@YMD1, 1, 4) + '년 ' + SUBSTRING(@YMD1, 5, 2) + '월' AS YEARMONTH, @YMD1 AS YMD
    UNION
    SELECT SUBSTRING(@YMD2, 1, 4) + '년 ' + SUBSTRING(@YMD2, 5, 2) + '월' AS YEARMONTH, @YMD2 AS YMD
    UNION
    SELECT SUBSTRING(@YMD3, 1, 4) + '년 ' + SUBSTRING(@YMD3, 5, 2) + '월' AS YEARMONTH, @YMD3 AS YMD
)   A
LEFT OUTER JOIN BSC_INTERFACE_DATA B ON B.DICODE = @DICODE
									AND	B.RDTERM = A.YMD
GROUP BY A.YEARMONTH, A.YMD ORDER BY A.YMD
";
            strQuery = string.Format(strQuery, (sumtype.ToString() == "1" ? "=" : "<="));

            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@DICODE", SqlDbType.VarChar);
            paramArray[0].Value = dicode;
            paramArray[1] = CreateDataParameter("@YMD1", SqlDbType.VarChar);
            paramArray[1].Value = ymd1;
            paramArray[2] = CreateDataParameter("@YMD2", SqlDbType.VarChar);
            paramArray[2].Value = ymd.ToString();
            paramArray[3] = CreateDataParameter("@YMD3", SqlDbType.VarChar);
            paramArray[3].Value = ymd3;

            return DbAgentObj.FillDataSet(strQuery, "BSC_INTERFACE_DATA", null, paramArray, CommandType.Text).Tables[0];
        }

        public DataTable GetInterfaceDataForDayResultGraph(object dicode, object ymd, object sumtype)
        {
            string ymd1 = string.Empty;
            string ymd3 = string.Empty;
            if (ymd.ToString().Substring(4, 2) == "01")
            {
                ymd1 = (DataTypeUtility.GetToInt32(ymd.ToString().Substring(0, 4)) - 1).ToString() + "12";
                ymd3 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) + 1).ToString("00");
            }
            else if (ymd.ToString().Substring(4, 2) == "12")
            {
                ymd1 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) - 1).ToString("00");
                ymd3 = (DataTypeUtility.GetToInt32(ymd.ToString().Substring(0, 4)) + 1).ToString() + "01";
            }
            else
            {
                ymd1 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) - 1).ToString("00");
                ymd3 = ymd.ToString().Substring(0, 4) + (DataTypeUtility.GetToInt32(ymd.ToString().Substring(4, 2)) + 1).ToString("00");
            }

            string strQuery = @"
SELECT	 CONVERT(VARCHAR, CONVERT(INT, A.RDDATE)) + '일' AS RESULTDAY
		,SUM(ISNULL(CASE WHEN @YMD1 = B.RDTERM THEN B.DVALUES1 ELSE 0 END, 0)) AS RESULT1
		,SUM(ISNULL(CASE WHEN @YMD2 = B.RDTERM THEN B.DVALUES1 ELSE 0 END, 0)) AS RESULT2
		,SUM(ISNULL(CASE WHEN @YMD3 = B.RDTERM THEN B.DVALUES1 ELSE 0 END, 0)) AS RESULT3
FROM (
	SELECT '01' AS RDDATE UNION SELECT '02' UNION SELECT '03' UNION SELECT '04' UNION SELECT '05' UNION SELECT '06' UNION SELECT '07' UNION SELECT '08' UNION SELECT '09' UNION SELECT '10' UNION
	SELECT '11' AS RDDATE UNION SELECT '12' UNION SELECT '13' UNION SELECT '14' UNION SELECT '15' UNION SELECT '16' UNION SELECT '17' UNION SELECT '18' UNION SELECT '19' UNION SELECT '20' UNION
	SELECT '21' AS RDDATE UNION SELECT '22' UNION SELECT '23' UNION SELECT '24' UNION SELECT '25' UNION SELECT '26' UNION SELECT '27' UNION SELECT '28' UNION SELECT '29' UNION SELECT '30' UNION SELECT '31'
) A
LEFT OUTER JOIN BSC_INTERFACE_DATA B ON B.DICODE = @DICODE
									AND	B.RDTERM IN (@YMD1, @YMD2, @YMD3)
									AND B.RDDATE {0} A.RDDATE
GROUP BY A.RDDATE
ORDER BY A.RDDATE
";
            strQuery = string.Format(strQuery, (sumtype.ToString() == "1" ? "=" : "<="));

            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@DICODE", SqlDbType.VarChar);
            paramArray[0].Value = dicode;
            paramArray[1] = CreateDataParameter("@YMD1", SqlDbType.VarChar);
            paramArray[1].Value = ymd1;
            paramArray[2] = CreateDataParameter("@YMD2", SqlDbType.VarChar);
            paramArray[2].Value = ymd.ToString();
            paramArray[3] = CreateDataParameter("@YMD3", SqlDbType.VarChar);
            paramArray[3].Value = ymd3;

            return DbAgentObj.FillDataSet(strQuery, "BSC_INTERFACE_DATA", null, paramArray, CommandType.Text).Tables[0];
        }
    }
}