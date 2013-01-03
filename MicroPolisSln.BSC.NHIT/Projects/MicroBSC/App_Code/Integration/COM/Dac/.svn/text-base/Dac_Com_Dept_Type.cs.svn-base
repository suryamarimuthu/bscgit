using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_Dept_Type : DbAgentBase
    {
        public Dac_Com_Dept_Type()
        {

        }



        public DataTable Select_Com_Dept_Type()
        {
            DataSet DS = new DataSet();

            string query = @"
SELECT  TYPE_REF_ID
    FROM    COM_DEPT_TYPE_INFO";


            DS = DbAgentObj.Fill(query);

            return DS.Tables[0];
        }

    }
}
