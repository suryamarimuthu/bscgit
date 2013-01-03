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
	public class Dac_MenuInfo : DbAgentBase
	{
		public int Update( IDbConnection conn
							, IDbTransaction trx 
							, int menu_ref_id
							, int up_menu_id
							, string menu_name
							, string menu_dir
							, string menu_page_name
							, string menu_param
							, string menu_full_path
							, string menu_desc
							, int menu_priority
							, string menu_auth_type
							, string menu_type
							, string menu_name_image_path
							, string menu_name_image_path_u
							, string menu_prev_icon_path
							, DateTime menu_create_date
							, string show_left_menu )
		{
			string query = @"UPDATE	COM_MENU_INFO
								SET	UP_MENU_ID = @UP_MENU_ID
									,MENU_NAME = @MENU_NAME
									,MENU_DIR = @MENU_DIR
									,MENU_PAGE_NAME = @MENU_PAGE_NAME
									,MENU_PARAM = @MENU_PARAM
									,MENU_FULL_PATH = @MENU_FULL_PATH
									,MENU_DESC = @MENU_DESC
									,MENU_PRIORITY = @MENU_PRIORITY
									,MENU_AUTH_TYPE = @MENU_AUTH_TYPE
									,MENU_TYPE = @MENU_TYPE
									,MENU_NAME_IMAGE_PATH = @MENU_NAME_IMAGE_PATH
									,MENU_NAME_IMAGE_PATH_U = @MENU_NAME_IMAGE_PATH_U
									,MENU_PREV_ICON_PATH = @MENU_PREV_ICON_PATH
									,MENU_CREATE_DATE = @MENU_CREATE_DATE
									,SHOW_LEFT_MENU = @SHOW_LEFT_MENU
								WHERE	MENU_REF_ID = @MENU_REF_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(16);
		 
			paramArray[0] 			= CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
			paramArray[0].Value 	= menu_ref_id;
			paramArray[1] 			= CreateDataParameter("@UP_MENU_ID", SqlDbType.Int);
			paramArray[1].Value 	= up_menu_id;
			paramArray[2] 			= CreateDataParameter("@MENU_NAME", SqlDbType.VarChar, 100);
			paramArray[2].Value 	= menu_name;
			paramArray[3] 			= CreateDataParameter("@MENU_DIR", SqlDbType.VarChar, 500);
			paramArray[3].Value 	= menu_dir;
			paramArray[4] 			= CreateDataParameter("@MENU_PAGE_NAME", SqlDbType.VarChar, 100);
			paramArray[4].Value 	= menu_page_name;
			paramArray[5] 			= CreateDataParameter("@MENU_PARAM", SqlDbType.VarChar, 500);
			paramArray[5].Value 	= menu_param;
			paramArray[6] 			= CreateDataParameter("@MENU_FULL_PATH", SqlDbType.VarChar, 1000);
			paramArray[6].Value 	= menu_full_path;
			paramArray[7] 			= CreateDataParameter("@MENU_DESC", SqlDbType.VarChar, 500);
			paramArray[7].Value 	= menu_desc;
			paramArray[8] 			= CreateDataParameter("@MENU_PRIORITY", SqlDbType.Int);
			paramArray[8].Value 	= menu_priority;
			paramArray[9] 			= CreateDataParameter("@MENU_AUTH_TYPE", SqlDbType.Char, 1);
			paramArray[9].Value 	= menu_auth_type;
			paramArray[10] 			= CreateDataParameter("@MENU_TYPE", SqlDbType.Char, 1);
			paramArray[10].Value 	= menu_type;
			paramArray[11] 			= CreateDataParameter("@MENU_NAME_IMAGE_PATH", SqlDbType.VarChar, 1000);
			paramArray[11].Value 	= menu_name_image_path;
			paramArray[12] 			= CreateDataParameter("@MENU_NAME_IMAGE_PATH_U", SqlDbType.VarChar, 1000);
			paramArray[12].Value 	= menu_name_image_path_u;
			paramArray[13] 			= CreateDataParameter("@MENU_PREV_ICON_PATH", SqlDbType.VarChar, 1000);
			paramArray[13].Value 	= menu_prev_icon_path;
			paramArray[14] 			= CreateDataParameter("@MENU_CREATE_DATE", SqlDbType.DateTime);
			paramArray[14].Value 	= menu_create_date;
			paramArray[15] 			= CreateDataParameter("@SHOW_LEFT_MENU", SqlDbType.VarChar, 20);
			paramArray[15].Value 	= show_left_menu;
		 
			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
		}


		public DataSet Select( object menu_ref_id
								, string menu_name
								, string menu_page_name
								, string menu_full_path )

		{
			string s_query = @"SELECT	MENU_REF_ID
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
									,MENU_NAME_IMAGE_PATH
									,MENU_NAME_IMAGE_PATH_U
									,MENU_PREV_ICON_PATH
									,MENU_CREATE_DATE
									,SHOW_LEFT_MENU

							FROM	COM_MENU_INFO 
							WHERE	( MENU_REF_ID	= @MENU_REF_ID OR @MENU_REF_ID     = 0    )
								AND	( MENU_NAME		= @MENU_NAME OR @MENU_NAME     =''    )
								AND	( MENU_PAGE_NAME		= @MENU_PAGE_NAME OR @MENU_PAGE_NAME     =''    )
								AND	( MENU_FULL_PATH		= @MENU_FULL_PATH OR @MENU_FULL_PATH     =''    )
                                ORDER BY MENU_PRIORITY ";


            string o_query = @"SELECT	MENU_REF_ID
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
									,MENU_NAME_IMAGE_PATH
									,MENU_NAME_IMAGE_PATH_U
									,MENU_PREV_ICON_PATH
									,MENU_CREATE_DATE
									,SHOW_LEFT_MENU

							FROM	COM_MENU_INFO 
							WHERE	( MENU_REF_ID	LIKE  @MENU_REF_ID || '%' )
								AND	( MENU_NAME		LIKE  @MENU_NAME || '%' )
								AND	( MENU_PAGE_NAME		LIKE @MENU_PAGE_NAME || '%' )
								AND	( MENU_FULL_PATH		LIKE @MENU_FULL_PATH || '%' )
                                ORDER BY MENU_PRIORITY ";

			IDbDataParameter[] paramArray = CreateDataParameters(4);
		 
			paramArray[0] 		= CreateDataParameter("@MENU_REF_ID", SqlDbType.Int );
			paramArray[0].Value = ( menu_ref_id.Equals( DBNull.Value ) == true ) ? 0 : menu_ref_id;
			paramArray[1] 		= CreateDataParameter("@MENU_NAME", SqlDbType.VarChar);
			paramArray[1].Value = menu_name;
			paramArray[2] 		= CreateDataParameter("@MENU_PAGE_NAME", SqlDbType.VarChar);
			paramArray[2].Value = menu_page_name;
			paramArray[3] 		= CreateDataParameter("@MENU_FULL_PATH", SqlDbType.VarChar);
			paramArray[3].Value = menu_full_path;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "MENUINFOGET", null, paramArray, CommandType.Text);
            DataSet ds = DbAgentObj.FillDataSet(s_query, "MENUINFOGET", null, paramArray, CommandType.Text);


			return ds;
		}

		 
		public int Insert( IDbConnection conn
							, IDbTransaction trx
							, int menu_ref_id
							, int up_menu_id
							, string menu_name
							, string menu_dir
							, string menu_page_name
							, string menu_param
							, string menu_full_path
							, string menu_desc
							, int menu_priority
							, string menu_auth_type
							, string menu_type
							, string menu_name_image_path
							, string menu_name_image_path_u
							, string menu_prev_icon_path
							, DateTime menu_create_date
							, string show_left_menu )
		{
			string query = @"INSERT INTO COM_MENU_INFO( MENU_REF_ID
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
														,MENU_NAME_IMAGE_PATH
														,MENU_NAME_IMAGE_PATH_U
														,MENU_PREV_ICON_PATH
														,MENU_CREATE_DATE
														,SHOW_LEFT_MENU
														)
													VALUES	( @MENU_REF_ID
														,@UP_MENU_ID
														,@MENU_NAME
														,@MENU_DIR
														,@MENU_PAGE_NAME
														,@MENU_PARAM
														,@MENU_FULL_PATH
														,@MENU_DESC
														,@MENU_PRIORITY
														,@MENU_AUTH_TYPE
														,@MENU_TYPE
														,@MENU_NAME_IMAGE_PATH
														,@MENU_NAME_IMAGE_PATH_U
														,@MENU_PREV_ICON_PATH
														,@MENU_CREATE_DATE
														,@SHOW_LEFT_MENU
														)";

			IDbDataParameter[] paramArray = CreateDataParameters(16);
		 
			paramArray[0] 			= CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
			paramArray[0].Value 	= menu_ref_id;
			paramArray[1] 			= CreateDataParameter("@UP_MENU_ID", SqlDbType.Int);
			paramArray[1].Value 	= up_menu_id;
			paramArray[2] 			= CreateDataParameter("@MENU_NAME", SqlDbType.VarChar, 100);
			paramArray[2].Value 	= menu_name;
			paramArray[3] 			= CreateDataParameter("@MENU_DIR", SqlDbType.VarChar, 500);
			paramArray[3].Value 	= menu_dir;
			paramArray[4] 			= CreateDataParameter("@MENU_PAGE_NAME", SqlDbType.VarChar, 100);
			paramArray[4].Value 	= menu_page_name;
			paramArray[5] 			= CreateDataParameter("@MENU_PARAM", SqlDbType.VarChar, 500);
			paramArray[5].Value 	= menu_param;
			paramArray[6] 			= CreateDataParameter("@MENU_FULL_PATH", SqlDbType.VarChar, 1000);
			paramArray[6].Value 	= menu_full_path;
			paramArray[7] 			= CreateDataParameter("@MENU_DESC", SqlDbType.VarChar, 500);
			paramArray[7].Value 	= menu_desc;
			paramArray[8] 			= CreateDataParameter("@MENU_PRIORITY", SqlDbType.Int);
			paramArray[8].Value 	= menu_priority;
			paramArray[9] 			= CreateDataParameter("@MENU_AUTH_TYPE", SqlDbType.Char, 1);
			paramArray[9].Value 	= menu_auth_type;
			paramArray[10] 			= CreateDataParameter("@MENU_TYPE", SqlDbType.Char, 1);
			paramArray[10].Value	= menu_type;
			paramArray[11] 			= CreateDataParameter("@MENU_NAME_IMAGE_PATH", SqlDbType.VarChar, 1000);
			paramArray[11].Value	= menu_name_image_path;
			paramArray[12] 			= CreateDataParameter("@MENU_NAME_IMAGE_PATH_U", SqlDbType.VarChar, 1000);
			paramArray[12].Value	= menu_name_image_path_u;
			paramArray[13] 			= CreateDataParameter("@MENU_PREV_ICON_PATH", SqlDbType.VarChar, 1000);
			paramArray[13].Value	= menu_prev_icon_path;
			paramArray[14] 			= CreateDataParameter("@MENU_CREATE_DATE", SqlDbType.DateTime);
			paramArray[14].Value	= menu_create_date;
			paramArray[15] 			= CreateDataParameter("@SHOW_LEFT_MENU", SqlDbType.VarChar, 20);
			paramArray[15].Value	= show_left_menu;
		 
			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
		}
		 
		public int Delete( IDbConnection conn
							, IDbTransaction trx
							, int menu_ref_id )
		{
			string query = @"DELETE	COM_MENU_INFO
							WHERE	MENU_REF_ID = @MENU_REF_ID";

			IDbDataParameter[] paramArray = CreateDataParameters(1);
		 
			paramArray[0] 		= CreateDataParameter("@MENU_REF_ID", SqlDbType.Int);
			paramArray[0].Value = menu_ref_id;
		 
			try
			{
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray, CommandType.Text );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }
		}


        public int GetMaxMenuRefID()
        {
            string s_query = @"SELECT MAX(MENU_REF_ID) +1 NEXT_MENU_REF_ID
                               FROM COM_MENU_INFO";

            string o_query = @"SELECT MAX(MENU_REF_ID) +1 NEXT_MENU_REF_ID
                               FROM COM_MENU_INFO";

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(GetQueryStringByDb(s_query, o_query)));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}