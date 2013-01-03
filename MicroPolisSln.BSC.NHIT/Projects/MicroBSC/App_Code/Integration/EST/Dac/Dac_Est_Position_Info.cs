using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using MicroBSC.Data;

namespace MicroBSC.Integration.EST.Dac
{
    public class Dac_Est_Position_Info : DbAgentBase
    {
        public Dac_Est_Position_Info()
        {
        }
        

        public DataTable Select_DB(object pos_id
                                , object pos_name
                                , object pos_table_name
                                , object pos_type_name
                                , object use_yn
                                , object sort_order)
        {
            string query = @"
SELECT  POS_ID
        , POS_NAME
        , POS_TABLE_NAME
        , POS_TYPE_NAME
        , USE_YN
        , SORT_ORDER
    FROM    EST_POSITION_INFO
    WHERE   (  POS_ID           = @POS_ID	        OR @POS_ID          =''  )
        AND (  POS_NAME         = @POS_NAME	        OR @POS_NAME        =''  )
        AND (  POS_TABLE_NAME   = @POS_TABLE_NAME	OR @POS_TABLE_NAME  =''  )
        AND (  POS_TYPE_NAME    = @POS_TYPE_NAME	OR @POS_TYPE_NAME   =''  )
        AND (  USE_YN           = @USE_YN	        OR @USE_YN          =''  )
        AND (  SORT_ORDER       = @SORT_ORDER	    OR @SORT_ORDER      = 0  )

";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@POS_ID", SqlDbType.NVarChar);
            paramArray[0].Value = pos_id;
            paramArray[1] = CreateDataParameter("@POS_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = pos_name;
            paramArray[2] = CreateDataParameter("@POS_TABLE_NAME", SqlDbType.NVarChar);
            paramArray[2].Value = pos_table_name;
            paramArray[3] = CreateDataParameter("@POS_TYPE_NAME", SqlDbType.NVarChar);
            paramArray[3].Value = pos_type_name;
            paramArray[4] = CreateDataParameter("@USE_YN", SqlDbType.NVarChar);
            paramArray[4].Value = use_yn;
            paramArray[5] = CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
            paramArray[5].Value = sort_order;


            DataTable dt = DbAgentObj.Fill(query, paramArray).Tables[0];

            return dt;
        }


        public DataTable Select_Est_Position_Table(object pos_id
                                                , object pos_table_name)
        {
            string query = string.Format(@"
SELECT  POS_{0}_ID
        , POS_{0}_NAME
    FROM    {1}
", pos_id, pos_table_name);

            DataTable dt = DbAgentObj.Fill(query).Tables[0];

            return dt;
        }
    }
}
