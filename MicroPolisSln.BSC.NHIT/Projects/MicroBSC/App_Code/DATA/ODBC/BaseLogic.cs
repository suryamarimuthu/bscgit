using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBSC.Data.Odbc
{
    public class BaseLogic
    {
        protected DBAgent _dbAgent;

        /// <summary>
        /// »ý¼ºÀÚ
        /// </summary>
        public BaseLogic()
        {
            _dbAgent                    = new DBAgent();
            _dbAgent.ConnectionString   = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        }
    }
}
