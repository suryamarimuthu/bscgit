using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBSC.Data.Oracle
{
    public class BaseLogic
    {
        protected DBAgent _dbAgent;

        /// <summary>
        /// ������
        /// </summary>
        public BaseLogic()
        {
            _dbAgent                    = new DBAgent();
            _dbAgent.ConnectionString   = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString;
        }
    }
}
