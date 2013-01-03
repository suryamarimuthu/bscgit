using System;
using System.Web;
using System.Data;
using System.Text;
using System.Transactions;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;

using MicroBSC.BSC.Dac;
using MicroBSC.Data;

namespace MicroBSC.BSC.Biz
{
    /// <summary>
    /// Biz_Bsc_Interface_Data
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Biz_Bsc_Interface_Data
    /// Class Func     : BSC_INTERFACE_DATA Business Logic Class
    /// CREATE DATE    : 2012-04-19 오후 3:52:10
    /// CREATE USER    : H.D.Park
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Biz_Bsc_Interface_Data : Dac_Bsc_Interface_Data
    {
        public Biz_Bsc_Interface_Data() { }

        public DataTable GetInterfaceDataForDayResult(string dicode, string ymd, string sumtype)
        {
            return base.GetInterfaceDataForDayResult(dicode, ymd, sumtype);
        }
        public DataTable GetInterfaceDataForDayResultGraph(string dicode, string ymd, string sumtype)
        {
            return base.GetInterfaceDataForDayResultGraph(dicode, ymd, sumtype);
        }

	}
}