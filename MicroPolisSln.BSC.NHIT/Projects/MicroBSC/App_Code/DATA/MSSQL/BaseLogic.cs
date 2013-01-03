namespace MicroBSC.Data
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class BaseLogic
    {
        protected DBAgent _dbAgent = new DBAgent(GetConnection());
        protected ExcelAgent _excelAgent = new ExcelAgent();

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ApplicationException("ConnectionString's not found.");
            }
            return connectionString;
        }
    }
}

