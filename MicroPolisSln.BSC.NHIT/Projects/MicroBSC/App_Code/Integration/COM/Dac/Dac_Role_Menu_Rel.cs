using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Integration.COM.Dac
{
    public class Dac_Role_Menu_Rel : DbAgentBase
    {


        public Dac_Role_Menu_Rel()
        {

        }

        public DataSet Select_DB(string filter)
        {
            string query = @"

SELECT 
MENU_REF_ID
,UP_MENU_ID
,MENU_NAME
,MENU_DIR 
,MENU_PAGE_NAME
,MENU_PARAM   
,MENU_FULL_PATH 
,MENU_DESC
,MENU_PRIORITY
,MENU_AUTH_TYPE
,MENU_TYPE
,SHOW_LEFT_MENU
FROM COM_MENU_INFO
WHERE MENU_REF_ID IN ( SELECT MENU_REF_ID FROM COM_ROLE_MENU_REL
                                         WHERE ROLE_REF_ID IN ( {0} )
                     )
                            
";

            query = string.Format(query, filter);


            DataSet ds = DbAgentObj.FillDataSet(query, "COM_ROLE_MENU_REL", null, null, CommandType.Text);
            return ds;
        }


    }
}
