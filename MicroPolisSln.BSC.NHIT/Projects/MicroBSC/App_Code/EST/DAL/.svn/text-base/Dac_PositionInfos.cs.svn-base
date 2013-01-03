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
    public class Dac_PositionInfos : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string position_type
                        , string position_type_name
                        , string position_table_name
                        , string use_yn
                        , int sort_order
                        , DateTime update_date
                        , string update_user )
        {
            string query = @"UPDATE	EST_POSITION_INFO
	                            SET	POSITION_TYPE_NAME		= @POSITION_TYPE_NAME
		                            ,POSITION_TABLE_NAME	= @POSITION_TABLE_NAME
		                            ,USE_YN					= @USE_YN
		                            ,SORT_ORDER				= @SORT_ORDER
		                            ,CREATE_DATE			= @CREATE_DATE
		                            ,CREATE_USER			= @CREATE_USER
		                            ,UPDATE_DATE			= @UPDATE_DATE
		                            ,UPDATE_USER			= @UPDATE_USER
	                            WHERE	POSITION_TYPE		= @POSITION_TYPE";

	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
	        paramArray[0] 		= CreateDataParameter("@POSITION_TYPE", SqlDbType.VarChar);
	        paramArray[0].Value = position_type;
	        paramArray[1] 		= CreateDataParameter("@POSITION_TYPE_NAME", SqlDbType.VarChar);
	        paramArray[1].Value = position_type_name;
	        paramArray[2] 		= CreateDataParameter("@POSITION_TABLE_NAME", SqlDbType.VarChar);
	        paramArray[2].Value = position_table_name;
	        paramArray[3] 		= CreateDataParameter("@USE_YN", SqlDbType.Char);
	        paramArray[3].Value = use_yn;
	        paramArray[4] 		= CreateDataParameter("@SORT_ORDER", SqlDbType.Int);
	        paramArray[4].Value = sort_order;
	        paramArray[5] 		= CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
	        paramArray[5].Value = update_date;
	        paramArray[6] 		= CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
	        paramArray[6].Value = update_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        public int UpdateByINPosId( IDbConnection conn
								, IDbTransaction trx
								, string strIdxs
								, object update_date
								, object update_user )
        {
            string query = string.Format( @"UPDATE EST_POSITION_INFO
									            SET USE_YN = 'Y'
									                WHERE POS_ID IN ( {0} )", strIdxs );

        
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, null );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }

            //IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            //paramArray[0] 		= CreateDataParameter( "@UPDATE_DATE", SqlDbType.DateTime );
            //paramArray[0].Value = update_date;
            //paramArray[1] 		= CreateDataParameter( "@UPDATE_USER", SqlDbType.Int );
            //paramArray[1].Value = update_user;
         
            //try
            //{
            //    int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray );
            //    return affectedRow;
            //}
            //catch ( Exception ex )
            //{
            //    throw ex;
            //}
        }

        public int UpdateByNotINPosId( IDbConnection conn
									, IDbTransaction trx
									, string strIdxs
									, object update_date
									, object update_user )
        {
            string query = string.Format( @"UPDATE EST_POSITION_INFO
									            SET USE_YN = 'N'
									                WHERE POS_ID Not IN ( {0} )", strIdxs );

	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, null );
		        return affectedRow;
	        }
	        catch ( Exception ex )
	        {
		        throw ex;
	        }

            //IDbDataParameter[] paramArray = CreateDataParameters(2);
         
            //paramArray[0] 		= CreateDataParameter( "@UPDATE_DATE", SqlDbType.DateTime );
            //paramArray[0].Value = update_date;
            //paramArray[1] 		= CreateDataParameter( "@UPDATE_USER", SqlDbType.VarChar );
            //paramArray[1].Value = update_user;
         
            //try
            //{
            //    int affectedRow = DbAgentObj.ExecuteNonQuery( conn, trx, query, paramArray );
            //    return affectedRow;
            //}
            //catch ( Exception ex )
            //{
            //    throw ex;
            //}
        }


        public DataSet Select(string pos_id
							, string pos_name
							, string pos_table_name
							, string pos_type_name
							, string user_yn )
        {

			string query = @"SELECT POS_ID
									, POS_NAME
	                                , POS_TABLE_NAME
									, POS_TYPE_NAME
	                                , USE_YN
	                                , CREATE_DATE
	                                , CREATE_USER
	                                , UPDATE_DATE
	                                , UPDATE_USER
                                FROM	EST_POSITION_INFO 
	                                WHERE   (POS_ID            = @POS_ID           OR @POS_ID                  =''    )
                                        AND (POS_NAME          = @POS_NAME         OR @POS_NAME                =''    )
                                        AND (POS_TABLE_NAME    = @POS_TABLE_NAME   OR @POS_TABLE_NAME          =''    )
                                        AND (POS_TYPE_NAME     = @POS_TYPE_NAME    OR @POS_TYPE_NAME           =''    )
                                        AND (USE_YN            = @USE_YN           OR @USE_YN                  =''    )
                                    ORDER BY SORT_ORDER";

	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
            paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
	        paramArray[0].Value	= pos_id;
            paramArray[1] 		= CreateDataParameter( "@POS_NAME", SqlDbType.NVarChar );
	        paramArray[1].Value	= pos_name;
            paramArray[2] 		= CreateDataParameter( "@POS_TABLE_NAME", SqlDbType.NVarChar );
	        paramArray[2].Value	= pos_table_name;
            paramArray[3] 		= CreateDataParameter( "@POS_TYPE_NAME", SqlDbType.NVarChar );
	        paramArray[3].Value = pos_type_name;
            paramArray[4] 		= CreateDataParameter( "@USE_YN", SqlDbType.NChar );
	        paramArray[4].Value = user_yn;
         
	        DataSet ds = DbAgentObj.FillDataSet( query, "POSITIONINFOGET" , null, paramArray);
	        return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx 
                        , string pos_id
                        , string pos_name
                        , string pos_table_name
                        , string pos_type_name
                        , string use_yn
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_POSITION_INFO ( POS_ID
														, POS_NAME
		                                                , POS_TABLE_NAME
														, POS_TYPE_NAME
		                                                , USE_YN
		                                                , CREATE_DATE
		                                                , CREATE_USER
		                                                )
	                                                VALUES	( @POS_ID
		                                                , @POS_NAME
		                                                , @POS_TABLE_NAME
		                                                , @POS_TYPE_NAME
		                                                , @USE_YN
		                                                , @CREATE_DATE
		                                                , @CREATE_USER
		                                                )";

	        IDbDataParameter[] paramArray = CreateDataParameters(7);
         
            paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
	        paramArray[0].Value	= pos_id;
            paramArray[1] 		= CreateDataParameter( "@POS_NAME", SqlDbType.NVarChar );
	        paramArray[1].Value	= pos_name;
            paramArray[2] 		= CreateDataParameter( "@POS_TABLE_NAME", SqlDbType.NVarChar );
	        paramArray[2].Value	= pos_table_name;
            paramArray[3] 		= CreateDataParameter( "@POS_TYPE_NAME", SqlDbType.NVarChar );
	        paramArray[3].Value = pos_type_name;
            paramArray[4] 		= CreateDataParameter( "@USE_YN", SqlDbType.NChar );
	        paramArray[4].Value = use_yn;
	        paramArray[5] 		= CreateDataParameter( "@CREATE_DATE", SqlDbType.DateTime );
	        paramArray[5].Value = create_date;
	        paramArray[6] 		= CreateDataParameter( "@CREATE_USER", SqlDbType.Int );
	        paramArray[6].Value = create_user;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }
         
        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string pos_id )
        {
            string query = @"DELETE	EST_POSITION_INFO
	                            WHERE	POS_ID = @POS_ID";

	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
            paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
	        paramArray[0].Value	= pos_id;
         
	        try
	        {
		        int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray);
		        return affectedRow;
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
        }

        public int Count( string pos_id )
        {
            string query = @"SELECT COUNT( POS_ID ) 
                                FROM EST_POSITION_INFO
	                                WHERE	POS_ID = @POS_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] 		= CreateDataParameter( "@POS_ID", SqlDbType.NVarChar );
	        paramArray[0].Value	= pos_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray).ToString());
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
