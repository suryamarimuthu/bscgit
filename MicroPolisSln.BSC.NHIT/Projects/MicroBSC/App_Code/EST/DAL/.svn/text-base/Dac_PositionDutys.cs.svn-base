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
    public class Dac_PositionDutys: DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , string pos_dut_id
                        , string pos_dut_name
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_POSITION_DUT
                                    SET	POS_DUT_NAME = @POS_DUT_NAME
	                                    ,UPDATE_DATE = @UPDATE_DATE
	                                    ,UPDATE_USER = @UPDATE_USER
                                    WHERE	POS_DUT_ID = @POS_DUT_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = pos_dut_id;
            paramArray[1]       = CreateDataParameter("@POS_DUT_NAME", SqlDbType.NVarChar, 200);
            paramArray[1].Value = pos_dut_name;
            paramArray[2]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = update_date;
            paramArray[3]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[3].Value = update_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select(string pos_dut_id)
        {
            string s_query = @"SELECT	POS_DUT_ID
	                                ,POS_DUT_NAME
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_POSITION_DUT 
                                WHERE	(POS_DUT_ID = @POS_DUT_ID OR @POS_DUT_ID     =''    )";

            string o_query = @"SELECT	POS_DUT_ID
	                                ,POS_DUT_NAME
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_POSITION_DUT 
                                WHERE	(POS_DUT_ID = @POS_DUT_ID OR POS_DUT_ID LIKE @POS_DUT_ID || '%')";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = pos_dut_id;


            DataSet ds = DbAgentObj.FillDataSet(s_query, "POSITIONDUTYGET", null, paramArray, CommandType.Text);
            return ds;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "POSITIONDUTYGET", null, paramArray, CommandType.Text);
            //return ds;

        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , string pos_dut_id
                        , string pos_dut_name
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_POSITION_DUT(POS_DUT_ID
			                                            ,POS_DUT_NAME
			                                            ,CREATE_DATE
			                                            ,CREATE_USER
			                                            ,UPDATE_DATE
			                                            ,UPDATE_USER
			                                            )
		                                            VALUES	(@POS_DUT_ID
			                                            ,@POS_DUT_NAME
			                                            ,@CREATE_DATE
			                                            ,@CREATE_USER
			                                            ,NULL
			                                            ,NULL
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = pos_dut_id;
            paramArray[1]       = CreateDataParameter("@POS_DUT_NAME", SqlDbType.NVarChar, 200);
            paramArray[1].Value = pos_dut_name;
            paramArray[2]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = create_date;
            paramArray[3]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = create_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(IDbConnection conn
                        , IDbTransaction trx
                        , string pos_dut_id)
        {
            string query = @"DELETE	EST_POSITION_DUT
                                WHERE	POS_DUT_ID = @POS_DUT_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = pos_dut_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count(string pos_dut_id)
        {
            string query = @"SELECT COUNT(POS_DUT_ID) FROM EST_POSITION_DUT
                                    WHERE	POS_DUT_ID = @POS_DUT_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[0].Value = pos_dut_id;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
