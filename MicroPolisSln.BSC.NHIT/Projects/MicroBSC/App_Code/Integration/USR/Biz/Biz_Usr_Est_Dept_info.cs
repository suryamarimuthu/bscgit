using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using MicroBSC.Integration.USR.Dac;

namespace MicroBSC.Integration.USR.Biz
{
    public class Biz_Usr_Est_Dept_info
    {
        public DataTable GetDeptInfo_Depth()
        {
            return new Dac_Usr_Est_Dept_info().GetDeptInfo_Depth();
        }

        public DataTable GetDeptInfo_DepthRow()
        {
            return new Dac_Usr_Est_Dept_info().GetDeptInfo_DepthRow();
        }

        public DataTable GetDeptInfo_DepthRow(int upId)
        {
            return new Dac_Usr_Est_Dept_info().GetDeptInfo_DepthRow(upId);
        }
    }
}
