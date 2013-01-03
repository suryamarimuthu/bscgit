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
	public class Dac_Status : DbAgentBase
	{
		public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string status_id
                        , int seq
						, string status_name
                        , string status_desc
                        , string status_img_path
                        , string status_style_id
                        , DateTime update_date
                        , int update_user)
		{
			string query = @"UPDATE	EST_STATUS
							    SET	  SEQ               = @SEQ
                                    , STATUS_NAME	    = @STATUS_NAME
                                    , STATUS_DESC       = @STATUS_DESC
                                    , STATUS_IMG_PATH   = @STATUS_IMG_PATH
                                    , STATUS_STYLE_ID   = @STATUS_STYLE_ID
							        , UPDATE_DATE	    = @UPDATE_DATE
							        , UPDATE_USER	    = @UPDATE_USER
							    WHERE STATUS_ID         = @STATUS_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(8);
		 
			paramArray[0] 			= CreateDataParameter( "@STATUS_ID", SqlDbType.NVarChar );
			paramArray[0].Value 	= status_id;
            paramArray[1] 			= CreateDataParameter( "@SEQ", SqlDbType.Int );
			paramArray[1].Value 	= seq;
			paramArray[2] 			= CreateDataParameter( "@STATUS_NAME", SqlDbType.NVarChar );
			paramArray[2].Value 	= status_name;
            paramArray[3]           = CreateDataParameter( "@STATUS_DESC", SqlDbType.NVarChar);
            paramArray[3].Value     = status_desc;
            paramArray[4]           = CreateDataParameter( "@STATUS_IMG_PATH", SqlDbType.NVarChar);
            paramArray[4].Value     = status_desc;
            paramArray[5] 			= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar );
			paramArray[5].Value 	= status_name;
			paramArray[6] 			= CreateDataParameter( "@UPDATE_DATE", SqlDbType.DateTime );
			paramArray[6].Value 	= update_date;
			paramArray[7] 			= CreateDataParameter( "@UPDATE_USER", SqlDbType.Int );
			paramArray[7].Value 	= update_user;

			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
        }

        public DataSet SelectByEstID( string status_id
                                    , string status_style_id
                                    , string est_id)
        {
            string query = @"SELECT  EI.STATUS_ID
                                    ,EI.SEQ
									,EI.STATUS_NAME
                                    ,EI.STATUS_DESC
                                    ,EI.STATUS_IMG_PATH
                                    ,EI.STATUS_STYLE_ID
                                    ,ES.STATUS_STYLE_NAME
									,EI.CREATE_DATE
									,EI.CREATE_USER
									,EI.UPDATE_DATE
									,EI.UPDATE_USER 
                                FROM        EST_STATUS          EI
                                    JOIN    EST_STATUS_STYLE    ES ON (EI.STATUS_STYLE_ID = ES.STATUS_STYLE_ID)
                                    JOIN    EST_INFO            E  ON (ES.STATUS_STYLE_ID = E.STATUS_STYLE_ID)
                                WHERE   (EI.STATUS_ID       = @STATUS_ID            OR @STATUS_ID           =''    )
                                    AND (EI.STATUS_STYLE_ID = @STATUS_STYLE_ID      OR @STATUS_STYLE_ID     =''    )
                                    AND (E.EST_ID           = @EST_ID               OR @EST_ID              =''    )
                                ORDER BY EI.SEQ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] 		= CreateDataParameter( "@STATUS_ID", SqlDbType.NVarChar);
            paramArray[0].Value = status_id;
            paramArray[1] 		= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar);
            paramArray[1].Value = status_style_id;
            paramArray[2] 		= CreateDataParameter( "@EST_ID", SqlDbType.NVarChar);
            paramArray[2].Value = est_id;

            DataSet ds = DbAgentObj.FillDataSet( query, "STATUSID" , null, paramArray, CommandType.Text );

            return ds;
        }

        public DataSet Select(string status_id
                            , string status_style_id)
		{
			string query = @"SELECT  EI.STATUS_ID
                                    ,EI.SEQ
									,EI.STATUS_NAME
                                    ,EI.STATUS_DESC
                                    ,EI.STATUS_IMG_PATH
                                    ,EI.STATUS_STYLE_ID
                                    ,ES.STATUS_STYLE_NAME
									,EI.CREATE_DATE
									,EI.CREATE_USER
									,EI.UPDATE_DATE
									,EI.UPDATE_USER 
                                FROM        EST_STATUS          EI
                                    JOIN    EST_STATUS_STYLE    ES ON (EI.STATUS_STYLE_ID = ES.STATUS_STYLE_ID)
                                WHERE   (EI.STATUS_ID       = @STATUS_ID            OR @STATUS_ID           =''    )
                                    AND (EI.STATUS_STYLE_ID = @STATUS_STYLE_ID      OR @STATUS_STYLE_ID     =''    )
                                ORDER BY EI.STATUS_STYLE_ID, EI.SEQ";

			IDbDataParameter[] paramArray = CreateDataParameters(2);

			paramArray[0] 		= CreateDataParameter( "@STATUS_ID", SqlDbType.NVarChar);
			paramArray[0].Value = status_id;
            paramArray[1] 		= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar);
			paramArray[1].Value = status_style_id;

	        DataSet ds = DbAgentObj.FillDataSet( query, "STATUSID" , null, paramArray, CommandType.Text );

	        return ds;
		}

		public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , string status_id
                        , int seq
						, string status_name
                        , string status_desc
                        , string status_img_path
                        , string status_style_id
						, DateTime create_date
						, int create_user)
		{
			string query = @"INSERT INTO EST_STATUS( STATUS_ID
                                                    ,SEQ
													,STATUS_NAME
                                                    ,STATUS_DESC
                                                    ,STATUS_IMG_PATH
                                                    ,STATUS_STYLE_ID
													,CREATE_DATE
													,CREATE_USER)
											VALUES	( @STATUS_ID
                                                    ,@SEQ
													,@STATUS_NAME
                                                    ,@STATUS_DESC
                                                    ,@STATUS_IMG_PATH
                                                    ,@STATUS_STYLE_ID
													,@CREATE_DATE
													,@CREATE_USER
													)";
            IDbDataParameter[] paramArray = CreateDataParameters(8);
		 
			paramArray[0] 			= CreateDataParameter( "@STATUS_ID", SqlDbType.NVarChar );
			paramArray[0].Value 	= status_id;
            paramArray[1] 			= CreateDataParameter( "@SEQ", SqlDbType.Int );
			paramArray[1].Value 	= seq;
			paramArray[2] 			= CreateDataParameter( "@STATUS_NAME", SqlDbType.NVarChar );
			paramArray[2].Value 	= status_name;
            paramArray[3]           = CreateDataParameter("@STATUS_DESC", SqlDbType.NVarChar);
            paramArray[3].Value     = status_desc;
			paramArray[4] 			= CreateDataParameter( "@CREATE_DATE", SqlDbType.DateTime );
			paramArray[4].Value	    = create_date;
			paramArray[5] 			= CreateDataParameter( "@CREATE_USER", SqlDbType.Int );
			paramArray[5].Value	    = create_user; 
            paramArray[6] 			= CreateDataParameter( "@STATUS_IMG_PATH", SqlDbType.NVarChar );
			paramArray[6].Value	    = status_img_path; 
            paramArray[7] 			= CreateDataParameter( "@STATUS_STYLE_ID", SqlDbType.NVarChar );
			paramArray[7].Value	    = status_style_id; 

            //IDbDataParameter[] paramArray = CreateDataParameters(6);
		 
            //paramArray[0] 			= CreateDataParameter( "@STATUS_ID", SqlDbType.NVarChar );
            //paramArray[0].Value 	= status_id;
            //paramArray[1] 			= CreateDataParameter( "@SEQ", SqlDbType.Int );
            //paramArray[1].Value 	= seq;
            //paramArray[2] 			= CreateDataParameter( "@STATUS_NAME", SqlDbType.NVarChar );
            //paramArray[2].Value 	= status_name;
            //paramArray[3]           = CreateDataParameter("@STATUS_DESC", SqlDbType.NVarChar);
            //paramArray[3].Value     = status_desc;
            //paramArray[4] 			= CreateDataParameter( "@CREATE_DATE", SqlDbType.DateTime );
            //paramArray[4].Value	    = create_date;
            //paramArray[5] 			= CreateDataParameter( "@CREATE_USER", SqlDbType.Int );
            //paramArray[5].Value	    = create_user; 
		 
			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
		}


        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string status_id )
        {
            string query = @"DELETE	EST_STATUS
							    WHERE	STATUS_ID = @STATUS_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
			paramArray[0] 			= CreateDataParameter( "@STATUS_ID", SqlDbType.NVarChar );
			paramArray[0].Value 	= status_id;
		 
			try
			{
				int affectedRow = DbAgentObj.ExecuteNonQuery( query, paramArray, CommandType.Text );
				return affectedRow;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
        }

		public int Count( string  status_id )
        {
            string query = @"SELECT COUNT(STATUS_ID) FROM EST_STATUS
                                WHERE ( STATUS_ID = @STATUS_ID OR @STATUS_ID     =''    )";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
			paramArray[0] 			= CreateDataParameter( "@STATUS_ID", SqlDbType.NVarChar );
			paramArray[0].Value 	= status_id;
		 
			try
			{
				int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text ).ToString());
				return affectedRow;
			}
			catch ( Exception ex )
			{
				throw ex;
			}
        }
	}
}