using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class LowDemensionStrings : DbAgentBase
    {
        public DataSet GetLowDemensionString(string kpi_code, int dimension_position) 
        {
            string query = @"SELECT * FROM LOW_DIMENSION_STRING WHERE KPI_CODE = @KPI_CODE AND DIMENSION_POSITON = @DIMENSION_POSITON";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = kpi_code;
            paramArray[1]               = CreateDataParameter("@DIMENSION_POSITON", SqlDbType.Int);
            paramArray[1].Value         = dimension_position;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Data", null, paramArray, CommandType.Text);
            return ds;
        }
        public DataSet GetLowDemensionStringBySeq(int seq)
        {
            string query = @"SELECT * FROM LOW_DIMENSION_STRING WHERE SEQUENCE = @SEQUENCE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[0].Value         = seq;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Data", null, paramArray, CommandType.Text);
            return ds;
        }

        public bool AddLowDemensionString(string kpi_code, string dimension_position, string dimension_name, string sValueDetail1)
        {
            string query = @"  INSERT LOW_DIMENSION_STRING (KPI_CODE
                                                            , DIMENSION_POSITON
                                                            , DIMENSION_NAME
                                                            , sValueDetail1)
	                                                    VALUES (
                                                            @KPI_CODE
                                                            , @DIMENSION_POSITON
                                                            , @DIMENSION_NAME
                                                            , @sValueDetail1)";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = kpi_code;
            paramArray[1]               = CreateDataParameter("@DIMENSION_POSITON", SqlDbType.Int);
            paramArray[1].Value         = dimension_position;
            paramArray[2]               = CreateDataParameter("@DIMENSION_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = dimension_name;
            paramArray[3]               = CreateDataParameter("@sValueDetail1", SqlDbType.VarChar);
            paramArray[3].Value         = sValueDetail1;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModifyLowDemensionString(int sequence, string dimension_name, string sValueDetail1)
        {
            string query = @"UPDATE LOW_DIMENSION_STRING 
	                                        SET DIMENSION_NAME 	    = @DIMENSION_NAME
		                                        , sValueDetail1     = @sValueDetail1
                                        WHERE           SEQUENCE    = @SEQUENCE";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@SEQUENCE", SqlDbType.Decimal);
            paramArray[0].Value         = sequence;
            paramArray[1]               = CreateDataParameter("@DIMENSION_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = dimension_name;
            paramArray[2]               = CreateDataParameter("@sValueDetail1", SqlDbType.VarChar);
            paramArray[2].Value         = sValueDetail1;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveLowDemensionString(int sequence)
        {
            string query = @"DELETE LOW_DIMENSION_STRING WHERE SEQUENCE = @SEQUENCE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@SEQUENCE", SqlDbType.Decimal);
            paramArray[0].Value         = sequence;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
