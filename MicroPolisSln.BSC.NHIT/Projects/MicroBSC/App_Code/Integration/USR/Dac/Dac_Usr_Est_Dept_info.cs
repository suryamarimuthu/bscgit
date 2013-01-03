using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using MicroBSC.Data;

namespace MicroBSC.Integration.USR.Dac
{
    public class Dac_Usr_Est_Dept_info : DbAgentBase
    {
        public DataTable GetDeptInfo_Depth()
        {
            DataTable dt = new DataTable();
            string qry = "SELECT DISTINCT DEPT_LEVEL FROM EST_DEPT_INFO ORDER BY DEPT_LEVEL";
            return DbAgentObj.FillDataSet(qry, "depth", null, null, CommandType.Text).Tables[0];
        }

        public DataTable GetDeptInfo_DepthRow()
        {
            DataTable dt = new DataTable();
            string qry = "SELECT * FROM EST_DEPT_INFO";
            return DbAgentObj.FillDataSet(qry, "depth", null, null, CommandType.Text).Tables[0];
        }

        public DataTable GetDeptInfo_DepthRow(int upId)
        {
            DataTable dt = new DataTable();
            string qry = "SELECT * FROM EST_DEPT_INFO WHERE UP_EST_DEPT_ID = @UP_EST_DEPT_ID";
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            paramArray[0] = CreateDataParameter("@UP_EST_DEPT_ID", SqlDbType.Int);
            paramArray[0].Value = upId;
            return DbAgentObj.FillDataSet(qry, "depth", null, paramArray, CommandType.Text).Tables[0];
        }
    }
}
