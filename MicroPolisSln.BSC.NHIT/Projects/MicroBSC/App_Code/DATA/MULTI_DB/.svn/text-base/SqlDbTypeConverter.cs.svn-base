using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.Odbc;


/// <summary>
/// Summary description for SqlDbTypeConverter
/// </summary>
namespace MicroBSC.Data
{
    public class SqlDbTypeConverter
    {
        public static OracleType GetOracleType(SqlDbType sqlDbType)
        {
            if (sqlDbType == SqlDbType.Int)
                return OracleType.Int32;
            else if (sqlDbType == SqlDbType.VarChar)
                return OracleType.VarChar;
            else if (sqlDbType == SqlDbType.NVarChar)
                return OracleType.NVarChar;
            else if (sqlDbType == SqlDbType.Char)
                return OracleType.Char;
            else if (sqlDbType == SqlDbType.NChar)
                return OracleType.NChar;
            else if (sqlDbType == SqlDbType.DateTime)
                return OracleType.DateTime;
            else if (sqlDbType == SqlDbType.Text)
                return OracleType.Clob;


            return OracleType.VarChar;
        }

        public static OdbcType GetOdbcType(SqlDbType sqlDbType)
        {
            if (sqlDbType == SqlDbType.Int)
                return OdbcType.Int;
            else if (sqlDbType == SqlDbType.VarChar)
                return OdbcType.VarChar;
            else if (sqlDbType == SqlDbType.NVarChar)
                return OdbcType.NVarChar;
            else if (sqlDbType == SqlDbType.Char)
                return OdbcType.Char;
            else if (sqlDbType == SqlDbType.NChar)
                return OdbcType.NChar;
            else if (sqlDbType == SqlDbType.DateTime)
                return OdbcType.DateTime;
            else if (sqlDbType == SqlDbType.Text)
                return OdbcType.Text;


            return OdbcType.VarChar;
        }
    }
}
