using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Data;

namespace MicroBSC.Estimation.Dac
{
    public class Dac_MapPageLinkInfos : DbAgentBase
    {
	    public DataSet Select()
		{
			string query = @"SELECT   COMP_ID
                                    , EST_ID
                                    , TGT_SEND_TYPE
                                    , TGT_OPINION_YN
                                    , FEEDBACK_YN
		                            , EST_JOB_IDS
		                            , EST_TGT_TYPE
		                            , YEAR_YN
		                            , MERGE_YN
		                            , DEPT_COLUMN_NO_USE_YN
		                            , ESTTERM_SUB_ALL_USE_YN
		                            , ESTTERM_STEP_ALL_USE_YN
                                    , LINK_DIR
                                    , LINK_PAGE_NAME
		                            , CREATE_DATE
		                            , CREATE_USER
		                            , UPDATE_DATE
		                            , UPDATE_USER
	                            FROM EST_MAP_PAGE_LINK_INFO";

            DataSet ds          = DbAgentObj.FillDataSet(query, "PAGEINFOGET", null, null, CommandType.Text);
            return ds;
		}
    }
}
