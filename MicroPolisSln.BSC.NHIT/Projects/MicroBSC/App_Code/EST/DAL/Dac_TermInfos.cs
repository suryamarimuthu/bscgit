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
    public class Dac_TermInfos : DbAgentBase
    {
        public DataSet Select(int estterm_ref_id)
        {
            string query = @"SELECT   ESTTERM_REF_ID
                                    , ESTTERM_NAME
                                    , EST_STARTDATE
                                    , EST_COMPDATE
                                    , MONTHLY_CLOSE_DAY
                                    , PRE_CLOSE_DAY
                                    , KPI_QLT_CLOSE_DAY
                                    , YEARLY_CLOSE_YN
                                    , SCORE_VALUATION_TYPE
                                    , EST_DESC
                                    , EST_STATUS
                                    , CLOSE_RATE_COMPLETE_YN
                                    , CREATE_DATE
                                    , CREATE_USER
                                    , UPDATE_DATE
                                    , UPDATE_USER
								FROM EST_TERM_INFO
                                    WHERE (ESTTERM_REF_ID = @ESTTERM_REF_ID OR @ESTTERM_REF_ID = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "ESTTERMINFOGET", null, paramArray, CommandType.Text);

            return ds;
        }
        /*
        public int Update(IDbConnection conn
                         , IDbTransaction trx
                         ,int estterm_ref_id
                         , string estterm_name
                         , DateTime est_startdate
                         , DateTime est_compdate
                         , int monthly_close_day
                         , int pre_close_day
                         , int yearly_close_yn
                         , string score_valuation_type
                         , string est_desc
                         , int est_status
                         , int close_rate_complete_yn
                         , DateTime update_date
                         , int update_user)
        {
            string query = @"UPDATE	EST_TERM_INFO
							    SET	  ESTTERM_REF_NAME	        = @ESTTERM_REF_NAME
                                       , EST_STARTDATE          = @EST_STARTDATE
                                       , EST_COMPDATE           = @EST_COMPDATE
                                       , MONTHLY_CLOSE_DAY      = @MONTHLY_CLOSE_DAY
                                       , PRE_CLOSE_DAY          = @PRE_CLOSE_DAY
                                       , YEARLY_CLOSE_YN        = @YEARLY_CLOSE_YN
                                       , SCORE_VALUATION_TYPE   = @SCORE_VALUATION_TYPE
                                       , EST_DESC               = @EST_DESC
                                       , CLOSE_RATE_COMPLETE_YN = @CLOSE_RATE_COMPLETE_YN
                                       , UPDATE_DATE		    = @UPDATE_DATE
								       , UPDATE_USER		    = @UPDATE_USER
							    WHERE ESTTERM_REF_ID   = @ESTTERM_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = estterm_name;
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = estterm_name;
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = estterm_name;
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = estterm_name;
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = estterm_name;
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_REF_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = estterm_name;




            paramArray[2] = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = update_date;
            paramArray[3] = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
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


       

        public int Insert(IDbConnection conn
                            , IDbTransaction trx
                            , int estterm_ref_id
                            , string estterm_name
                            , DateTime est_startdate
                            , DateTime est_compdate
                            , int monthly_close_day
                            , int pre_close_day
                            , int yearly_close_yn
                            , string score_valuation_type
                            , string est_desc
                            , int est_status
                            , int close_rate_complete_yn
                            , DateTime create_date
                            , int create_user)
        {
            string query = @"INSERT INTO EST_TERM_INFO( ESTTERM_STEP_ID
													,ESTTERM_STEP_NAME
													,CREATE_DATE
													,CREATE_USER
													)
											VALUES	(@ESTTERM_STEP_ID
													,@ESTTERM_STEP_NAME
													,@CREATE_DATE
													,@CREATE_USER
													)";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@ESTTERM_STEP_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_step_id;
            paramArray[1] = CreateDataParameter("@ESTTERM_STEP_NAME", SqlDbType.NVarChar);
            paramArray[1].Value = estterm_step_name;
            paramArray[2] = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[2].Value = create_date;
            paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
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
                        , int estterm_ref_id)
        {
            string query = @"DELETE	EST_TERM_INFO
							    WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_step_id;

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

        public int Count(int estterm_step_id)
        {
            string query = @"SELECT   COUNT(*)
								FROM EST_TERM_INFO
                                    WHERE (ESTTERM_REF_ID = @ESTTERM_REF_ID OR @ESTTERM_REF_ID = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_step_id;

            return (int)DbAgentObj.ExecuteNonQuery(query, paramArray);
        }
         */
    }
}