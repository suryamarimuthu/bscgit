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
	public class Dac_EstMap : DbAgentBase
	{
		public DataSet Select(int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id)
        {
            string query = @"SELECT   IMS.EST_ID
									, IMS.UP_EST_ID
									, IMS.EST_NAME
									, IMS.HEADER_COLOR
									, IMS.STATUS_STYLE_ID
									, IMS.PADDING
									, IMS.EST_SCHE_ID
									, IMS.EST_SCHE_NAME
									, SDET.START_DATE
									, SDET.END_DATE
								FROM (SELECT  INF.COMP_ID
                                            , INF.EST_ID
											, INF.UP_EST_ID
											, INF.EST_NAME
											, INF.HEADER_COLOR
											, INF.STATUS_STYLE_ID
											, MAPP.PADDING
											, SINF.EST_SCHE_ID
											, SINF.EST_SCHE_NAME
									FROM		        EST_INFO            INF
										LEFT OUTER JOIN	EST_MAP_PADDING	    MAPP		ON	(INF.EST_ID  = MAPP.EST_ID)
										LEFT OUTER JOIN	EST_SCHE_INFO		SINF		ON	(INF.COMP_ID = SINF.COMP_ID 
                                                                                         AND INF.EST_ID  = SINF.EST_ID)
									WHERE   (INF.COMP_ID = @COMP_ID	OR @COMP_ID = 0) 
                                        AND (INF.EST_ID  = @EST_ID	OR @EST_ID      =''    ) 
                                ) IMS
								    LEFT OUTER JOIN (SELECT   COMP_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , EST_SCHE_ID
                                                            , START_DATE
                                                            , END_DATE
                                                            , STATUS_ID 
                                                        FROM EST_SCHE_DETAIL
										                    WHERE   (COMP_ID	    = @COMP_ID	        OR 	@COMP_ID        = 0 )
                                                                AND (ESTTERM_REF_ID	= @ESTTERM_REF_ID	OR 	@ESTTERM_REF_ID = 0 )
											                    AND (ESTTERM_SUB_ID	= @ESTTERM_SUB_ID	OR 	@ESTTERM_SUB_ID = 0 )
								    ) SDET	   ON (IMS.COMP_ID     = SDET.COMP_ID
                                               AND IMS.EST_SCHE_ID = SDET.EST_SCHE_ID)";

	        IDbDataParameter[] paramArray = CreateDataParameters(4);
         
            paramArray[0] 		= CreateDataParameter("@COMP_ID", SqlDbType.Int);
	        paramArray[0].Value	= comp_id;
	        paramArray[1] 		= CreateDataParameter("@EST_ID", SqlDbType.NVarChar, 20);
	        paramArray[1].Value	= est_id;
            paramArray[2]		= CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[2].Value	= estterm_ref_id;
            paramArray[3]		= CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[3].Value	= estterm_sub_id;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "ESTMAP" , null, paramArray, CommandType.Text);
	        return ds;
        }

        public DataSet Select4Valid(int comp_id)
        {
            string query = @"SELECT   IMS.EST_ID
									, IMS.UP_EST_ID
									, IMS.EST_NAME
									, IMS.HEADER_COLOR
									, IMS.STATUS_STYLE_ID
                                    , IMS.WEIGHT_TYPE
									, IMS.PADDING
									, IMS.EST_SCHE_ID
									, IMS.EST_SCHE_NAME									
								FROM (SELECT  INF.COMP_ID
                                            , INF.EST_ID
											, INF.UP_EST_ID
											, INF.EST_NAME
											, INF.HEADER_COLOR
											, INF.STATUS_STYLE_ID
                                            , INF.WEIGHT_TYPE
											, MAPP.PADDING
											, SINF.EST_SCHE_ID
											, SINF.EST_SCHE_NAME
									FROM		        EST_INFO            INF
										LEFT OUTER JOIN	EST_MAP_PADDING	    MAPP		ON	(INF.EST_ID  = MAPP.EST_ID)
										LEFT OUTER JOIN	EST_SCHE_INFO		SINF		ON	(INF.COMP_ID = SINF.COMP_ID 
                                                                                         AND INF.EST_ID  = SINF.EST_ID)
									WHERE   (INF.COMP_ID = @COMP_ID	OR @COMP_ID = 0) 
                                        --AND (INF.EST_ID  = @EST_ID	OR @EST_ID      =''    ) 
                                ) IMS
								    ";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@COMP_ID", SqlDbType.Int);
            paramArray[0].Value = comp_id;
           
            

            DataSet ds = DbAgentObj.FillDataSet(query, "ESTMAP", null, paramArray, CommandType.Text);
            return ds;
        }
	}
}