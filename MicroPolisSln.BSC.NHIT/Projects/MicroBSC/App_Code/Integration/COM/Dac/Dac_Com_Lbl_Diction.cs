using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Com_Lbl_Diction : DbAgentBase
    {
        public Dac_Com_Lbl_Diction()
        {

        }



        public DataTable Select_DB(string lbl_code)
        {
            DataSet DS = new DataSet();
            string query = @"
SELECT   LBL_CODE
        ,LBL_KOR_TEXT
        ,LBL_NOTE
 FROM    COM_LBL_DICTION
    WHERE       (LBL_CODE   =   @LBL_CODE  OR    @LBL_CODE =''     )
    ORDER BY    LBL_CODE ";



            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@LBL_CODE", SqlDbType.NVarChar);
            paramArray[0].Value = lbl_code;


            DS = DbAgentObj.Fill(query, paramArray);

            return DS.Tables[0];
        }

    }
}
