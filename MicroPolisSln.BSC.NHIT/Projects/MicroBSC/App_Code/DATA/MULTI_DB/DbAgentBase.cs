using System;
using System.Data;

namespace MicroBSC.Data
{
    public class DbAgentBase
    {
        private static IDbAgent _dbAgentCache   = null;
        protected IDbAgent _dbAgent             = null;
        protected ExcelAgent _excelAgent        = null;

        protected static IDbAgent DbAgentCache
        {
            get
            {
                return _dbAgentCache;
            }
            set
            {
                if (_dbAgentCache == value)
                    return;
                _dbAgentCache = value;
            }
        }

        protected IDbAgent DbAgentObj
        {
            get
            {
                return _dbAgent;
            }
            set
            {
                if (_dbAgent == value)
                    return;
                _dbAgent = value;
            }
        }

        static DbAgentBase() 
        {
            _dbAgentCache   = DbAgentHelper.CreateDbAgent();
        }

        public DbAgentBase()
        {
            _dbAgent        = DbAgentHelper.CreateDbAgent();
            _excelAgent     = new ExcelAgent();
        }

        public static IDbDataParameter[] CreateDataParameters(int parameterArrayCount)
        {
            return DbAgentHelper.CreateDataParameters(parameterArrayCount);
        }

        public static IDbDataParameter CreateDataParameter(string parameter, SqlDbType sqlDbType)
        {
            return DbAgentHelper.CreateDataParameter(parameter, sqlDbType);
        }

        public static IDbDataParameter CreateDataParameter(string parameter, SqlDbType sqlDbType, int size)
        {
            return DbAgentHelper.CreateDataParameter(parameter, sqlDbType, size);
        }

        public static string GetQueryStringByDb(string sqlQueryString, string oracleQueryString)
        {
            return DbAgentHelper.GetQueryStringByDb(sqlQueryString, oracleQueryString);
        }

        public static object GetOutputParameterValue(IDataParameterCollection col, string parameterName, CommandType cmdType)
        {
            return DbAgentHelper.GetOutputParameterValue(col, parameterName, cmdType);
        }

        public static string GetProviderType()
        {
            return DbAgentHelper.GetProviderType();
        }

        public static string GetQueryStringReplace(string query)
        {
            return DbAgentHelper.GetQueryStringReplace(query);
        }

        public static object GetOutputParameterValue(IDataParameterCollection col, string parameterName)
        {
            return GetOutputParameterValue(col, parameterName, CommandType.Text);
        }

        public static object GetOutputParameterValueBySP(IDataParameterCollection col, string parameterName)
        {
            return DbAgentHelper.GetOutputParameterValue(col, parameterName, CommandType.StoredProcedure);
        }
    }
}

