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
    public class Dac_PosDutEmps : DbAgentBase
    {
        public int Update(IDbConnection conn
                        , IDbTransaction trx
                        , int emp_ref_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string pos_dut_id
                        , DateTime start_date
                        , DateTime end_date
                        , DateTime update_date
                        , int update_user)
        {
            string query = @"UPDATE	EST_POS_DUT_EMP
                                SET	ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    ,ESTTERM_SUB_ID = @ESTTERM_SUB_ID
                                    ,END_DATE       = @END_DATE
                                    ,UPDATE_DATE    = @UPDATE_DATE
                                    ,UPDATE_USER    = @UPDATE_USER
                                WHERE	EMP_REF_ID  = @EMP_REF_ID
                                    AND	POS_DUT_ID  = @POS_DUT_ID
                                    AND	START_DATE  = @START_DATE";


            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = pos_dut_id;
            paramArray[4]       = CreateDataParameter("@START_DATE", SqlDbType.DateTime);
            paramArray[4].Value = start_date;
            paramArray[5]       = CreateDataParameter("@END_DATE", SqlDbType.DateTime);
            paramArray[5].Value = end_date;
            paramArray[6]       = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[6].Value = update_date;
            paramArray[7]       = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[7].Value = update_user;

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

        public DataSet Select(int emp_ref_id
                            , string pos_dut_id
                            , DateTime start_date)
        {
            string query = @"SELECT	EMP_REF_ID
	                                ,ESTTERM_REF_ID
	                                ,ESTTERM_SUB_ID
	                                ,POS_DUT_ID
	                                ,START_DATE
	                                ,END_DATE
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	EST_POS_DUT_EMP 
                                    WHERE	(EMP_REF_ID = @EMP_REF_ID   OR @EMP_REF_ID = 0)
                                        AND	(POS_DUT_ID = @POS_DUT_ID   OR @POS_DUT_ID     =''    )
                                        AND	START_DATE = @START_DATE";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = pos_dut_id;
            paramArray[2]       = CreateDataParameter("@START_DATE", SqlDbType.DateTime);
            paramArray[2].Value = start_date;

            DataSet ds = DbAgentObj.FillDataSet(query, "POSDUTEMPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int Insert(IDbConnection conn
                        , IDbTransaction trx
                        , int emp_ref_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , string pos_dut_id
                        , DateTime start_date
                        , DateTime end_date
                        , DateTime create_date
                        , int create_user)
        {
            string query = @"INSERT INTO EST_POS_DUT_EMP(EMP_REF_ID
			                                            ,ESTTERM_REF_ID
			                                            ,ESTTERM_SUB_ID
			                                            ,POS_DUT_ID
			                                            ,START_DATE
			                                            ,END_DATE
			                                            ,CREATE_DATE
			                                            ,CREATE_USER
			                                            ,UPDATE_DATE
			                                            ,UPDATE_USER
			                                            )
		                                            VALUES	(@EMP_REF_ID
			                                            ,@ESTTERM_REF_ID
			                                            ,@ESTTERM_SUB_ID
			                                            ,@POS_DUT_ID
			                                            ,@START_DATE
			                                            ,@END_DATE
			                                            ,@CREATE_DATE
			                                            ,@CREATE_USER
			                                            ,NULL
			                                            ,NULL
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@ESTTERM_SUB_ID", SqlDbType.Int);
            paramArray[2].Value = estterm_sub_id;
            paramArray[3]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[3].Value = pos_dut_id;
            paramArray[4]       = CreateDataParameter("@START_DATE", SqlDbType.DateTime);
            paramArray[4].Value = start_date;
            paramArray[5]       = CreateDataParameter("@END_DATE", SqlDbType.DateTime);
            paramArray[5].Value = end_date;
            paramArray[6]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[6].Value = create_date;
            paramArray[7]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[7].Value = create_user;

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
                        , int emp_ref_id
                        , string pos_dut_id
                        , DateTime start_date)
        {

            string query = @"DELETE	EST_POS_DUT_EMP
                                WHERE	EMP_REF_ID = @EMP_REF_ID
                                    AND	POS_DUT_ID = @POS_DUT_ID
                                    AND	START_DATE = @START_DATE";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = pos_dut_id;
            paramArray[2]       = CreateDataParameter("@START_DATE", SqlDbType.DateTime);
            paramArray[2].Value = start_date;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Count( int emp_ref_id
                        , string pos_dut_id
                        , DateTime start_date)
        {

            string query = @"SELECT COUNT(*) FROM EST_POS_DUT_EMP
                                WHERE	(EMP_REF_ID = @EMP_REF_ID   OR @EMP_REF_ID = 0)
                                    AND	(POS_DUT_ID = @POS_DUT_ID   OR @POS_DUT_ID     =''    )
                                    AND	START_DATE = @START_DATE";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = emp_ref_id;
            paramArray[1]       = CreateDataParameter("@POS_DUT_ID", SqlDbType.NVarChar, 12);
            paramArray[1].Value = pos_dut_id;
            paramArray[2]       = CreateDataParameter("@START_DATE", SqlDbType.DateTime);
            paramArray[2].Value = start_date;

            try
            {
                return Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
