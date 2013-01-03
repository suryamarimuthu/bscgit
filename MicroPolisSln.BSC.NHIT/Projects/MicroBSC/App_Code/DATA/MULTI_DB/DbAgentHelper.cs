using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.Odbc;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

namespace MicroBSC.Data
{
    public class DbAgentHelper
    {
        private static DbProviderType dbProviderType;

        private static string SQL_CONNECTION_STRING         = null;
        private static string ORACLE_CONNECTION_STRING      = null;
        private static string ODBC_CONNECTION_STRING = null;

        static DbAgentHelper()
        {
            SQL_CONNECTION_STRING       = ConfigurationManager.ConnectionStrings["SqlDbString"].ConnectionString;
            ORACLE_CONNECTION_STRING    = ConfigurationManager.ConnectionStrings["OracleDbString"].ConnectionString;
            ODBC_CONNECTION_STRING      = ConfigurationManager.ConnectionStrings["OdbcDbString"].ConnectionString;

            string dbProviderTypeStr    = ConfigurationManager.AppSettings["DbProviderType"];

            if (dbProviderTypeStr.Equals("MSSQL"))
                dbProviderType = DbProviderType.SqlProvider;
            else if (dbProviderTypeStr.Equals("ORACLE"))
                dbProviderType = DbProviderType.OracleProvider;
            else if (dbProviderTypeStr.Equals("ODBC"))
                dbProviderType = DbProviderType.OdbcProvider;

            //dbProviderType = DbProviderType.SqlProvider;
        }

        public static IDbConnection CreateDbConnection(string connectionString)
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return new SqlConnection(connectionString);
            else if (dbProviderType == DbProviderType.OracleProvider)
                return new OracleConnection(connectionString);
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return new OdbcConnection(connectionString);

            return new SqlConnection();
        }

        public static IDbConnection CreateDbConnection()
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return new SqlConnection(GetConnectionString());
            else if (dbProviderType == DbProviderType.OracleProvider)
                return new OracleConnection(GetConnectionString());
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return new OdbcConnection(GetConnectionString());

            return new SqlConnection(GetConnectionString());
        }

        public static string GetConnectionString()
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return SQL_CONNECTION_STRING;
            else if (dbProviderType == DbProviderType.OracleProvider)
                return ORACLE_CONNECTION_STRING;
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return ODBC_CONNECTION_STRING;

            return ConfigurationManager.ConnectionStrings["SqlDbString"].ConnectionString;
        }

        public static IDbAgent CreateDbAgent()
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return new SqlDbAgent(GetConnectionString());
            else if (dbProviderType == DbProviderType.OracleProvider)
                return new OracleDbAgent(GetConnectionString());
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return new OdbcDbAgent(GetConnectionString());

            return new SqlDbAgent(GetConnectionString());
        }

        public static IDbDataParameter[] CreateDataParameters(int parameterArrayCount)
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return new SqlParameter[parameterArrayCount];
            else if (dbProviderType == DbProviderType.OracleProvider)
                return new OracleParameter[parameterArrayCount];
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return new OdbcParameter[parameterArrayCount];

            return new SqlParameter[parameterArrayCount];
        }

        public static IDbDataParameter CreateDataParameter(string parameter, SqlDbType sqlDbType)
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return new SqlParameter(parameter, sqlDbType);
            else if (dbProviderType == DbProviderType.OracleProvider)
                return new OracleParameter(parameter, sqlDbType);
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return new OdbcParameter(parameter, sqlDbType);

            return new SqlParameter(parameter, sqlDbType);
        }

        public static IDbDataParameter CreateDataParameter(string parameter, SqlDbType sqlDbType, int size)
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return new SqlParameter(parameter, sqlDbType, size);
            else if (dbProviderType == DbProviderType.OracleProvider)
                return new OracleParameter(parameter, SqlDbTypeConverter.GetOracleType(sqlDbType), size);
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return new OdbcParameter(parameter, SqlDbTypeConverter.GetOdbcType(sqlDbType), size);

            return new SqlParameter(parameter, sqlDbType, size);
        }

        public static string GetQueryStringByDb(string sqlQueryString, string oracleQueryString)
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return sqlQueryString;
            else if (dbProviderType == DbProviderType.OracleProvider)
                return oracleQueryString;
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return sqlQueryString;

            return sqlQueryString;
        }

        public static object GetOutputParameterValue(IDataParameterCollection col, string parameterName, CommandType cmdType)
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return ((SqlParameterCollection)col)[parameterName].Value;
            else if (dbProviderType == DbProviderType.OracleProvider) 
            {
                return ((OracleParameterCollection)col)[GetParameterNameReplace(parameterName, cmdType)].Value;
            }
            else if (dbProviderType == DbProviderType.OdbcProvider)
            {
                return ((OdbcParameterCollection)col)[GetParameterNameReplace(parameterName, cmdType)].Value;
            }

            return ((SqlParameterCollection)col)[parameterName].Value; ;
        }

        public static object GetOutputParameterValue(IDataParameterCollection col, string parameterName)
        {
           return GetOutputParameterValue(col, parameterName, CommandType.Text);
        }


        public static OracleParameter GetParameterNameReplace(OracleParameter parameter, CommandType cmdType)
        {
            if (cmdType == CommandType.StoredProcedure)
            {
                parameter.ParameterName = parameter.ParameterName.Replace("@", "");
            }
            else
            {
                parameter.ParameterName = parameter.ParameterName.Replace("@", ":");
            }

            return parameter;
        }

        public static string GetProviderType()
        {
            if (dbProviderType == DbProviderType.SqlProvider)
                return "MS-SQL";
            else if (dbProviderType == DbProviderType.OracleProvider)
                return "ORACLE";
            else if (dbProviderType == DbProviderType.OdbcProvider)
                return "ODBC";

            return "MS-SQL";
        }


		/// <summary>
		/// 오라클 프로바이더용 파라메터 컨버터
		/// 공백 처리 추가됨 [Null to WhiteSpace]
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
        public static string GetQueryStringReplace(string query)
        {
            string iquery = query.ToUpper();

            if (dbProviderType == DbProviderType.OracleProvider)
            {
				// ''
				iquery = (iquery.Contains(" =''")) ? iquery.Replace(" =''", " =' '") : iquery;
                // N''
                iquery = (iquery.Contains("N''")) ? iquery.Replace("N''", "' '") : iquery;

                // @
                iquery = (iquery.Contains("@"))             ? iquery.Replace("@", ":") : iquery;
                // ISNULL
                iquery = (iquery.Contains("ISNULL("))       ? iquery.Replace("ISNULL(", "NVL(") : iquery;
                // SUBSTRING
                iquery = (iquery.Contains("SUBSTRING("))    ? iquery.Replace("SUBSTRING(", "SUBSTR(") : iquery;
                // LEN
                iquery = (iquery.Contains("LEN"))           ? iquery.Replace("LEN(", "LENGTH(") : iquery;
                // GETDATE()
                iquery = (iquery.Contains("GETDATE()"))     ? iquery = iquery.Replace("GETDATE()", "SYSDATE") : iquery;
                // CONVERT(NUMERIC(20,4)
                iquery = (iquery.Contains("CONVERT(NUMERIC(20,4),")) ? iquery = iquery.Replace("CONVERT(NUMERIC(20,4),", "TO_NUMBER(") : iquery;
                // dbo.
                iquery = (iquery.Contains("dbo.")) ? iquery.Replace("dbo.", "") : iquery;
                // DBO.
                iquery = (iquery.Contains("DBO.")) ? iquery.Replace("DBO.", "") : iquery;
                // + '%')
                iquery = (iquery.Contains("+ '%')")) ? iquery.Replace("+ '%')", "|| '%')") : iquery;
                // + 
                iquery = (iquery.Contains(" + ")) ? iquery.Replace(" + ", " || ") : iquery;
                // COMMENTS
                iquery = (iquery.Contains(".COMMENTS")) ? iquery.Replace(".COMMENTS", ".\"COMMENTS\"") : iquery;
                // COMMENT
                iquery = (iquery.Contains(".COMMENT")) ? iquery.Replace(".COMMENT", ".\"COMMENT\"") : iquery;
                // comment
                iquery = (iquery.Contains(".comment")) ? iquery.Replace(".comment", ".\"comment\"") : iquery;
                // COMMENT
                iquery = (iquery.Contains(".Comment")) ? iquery.Replace(".Comment", ".\"Comment\"") : iquery;
                // COMMENT
                iquery = (iquery.Contains(",COMMENT")) ? iquery.Replace(",COMMENT", ",\"COMMENT\"") : iquery;
                // comment
                iquery = (iquery.Contains(",comment")) ? iquery.Replace(",comment", ",\"comment\"") : iquery;
                // COMMENT
                iquery = (iquery.Contains(",Comment")) ? iquery.Replace(",Comment", ",\"Comment\"") : iquery;
                // COMMENTS
                iquery = (iquery.Contains(" COMMENT ")) ? iquery.Replace(" COMMENT ", " \"COMMENT\" ") : iquery;

               
            }

            return iquery;
        }

        public static string GetConcatinationChar()
        {
            string sCon = "+";
            if (dbProviderType == DbProviderType.OracleProvider)
            {
                sCon = "||";
            }
            return sCon;
        }

        public static string GetParameterNameReplace(string parameterName, CommandType cmdType)
        {
            if (dbProviderType == DbProviderType.SqlProvider) 
            {
                return parameterName;
            }
            else if (dbProviderType == DbProviderType.OracleProvider) 
            {
                if (cmdType == CommandType.StoredProcedure)
                {
                    return parameterName.Replace("@", "");
                }
                else 
                {
                    return parameterName.Replace("@", ":");
                }
            }

            return parameterName;
        }
    }
}