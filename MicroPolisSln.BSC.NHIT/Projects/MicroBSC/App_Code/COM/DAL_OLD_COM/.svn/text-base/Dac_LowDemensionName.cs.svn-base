using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class LowDemensionNames : DbAgentBase
    {
        public DataSet GetLowDemensionName(string kpi_code) 
        {
            string query = @"SELECT * FROM LOW_DIMENSION_NAME WHERE KPI_CODE = @KPI_CODE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = kpi_code;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "EMPINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }
        public DataSet GetLowDemensionNameBySeq(int seq)
        {
            string query = @"SELECT * FROM LOW_DIMENSION_NAME WHERE SEQUENCE = @SEQUENCE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@SEQUENCE", SqlDbType.Int);
            paramArray[0].Value         = seq;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "Data", null, paramArray, CommandType.Text);
            return ds;
        }
        public bool AddLowDemensionName(string kpi_code, string dimension_name)
        {
            string query = @"DECLARE @DIMENSION_POSITON int

                             SELECT @DIMENSION_POSITON = ISNULL(MAX(DIMENSION_POSITON), 0) +1 FROM LOW_DIMENSION_NAME WHERE KPI_CODE = @KPI_CODE

                             INSERT LOW_DIMENSION_NAME (KPI_CODE
                                                        , DIMENSION_POSITON
                                                        , DIMENSION_NAME
                                                        , CREATE_DATE)
	                                                    VALUES 
                                                        (@KPI_CODE
                                                        , @DIMENSION_POSITON
                                                        , @DIMENSION_NAME
                                                        , GETDATE())";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = kpi_code;
            paramArray[1]               = CreateDataParameter("@DIMENSION_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = dimension_name;

            //try
            //{
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("ERROR - AddLowDemensionString() \n" + ex.Message);
            //}
        }

        public bool ModifyLowDemensionName(int sequence, string dimension_name)
        {
            string query = @"UPDATE LOW_DIMENSION_NAME 
                                SET DIMENSION_NAME = @DIMENSION_NAME 
                                    WHERE SEQUENCE = @SEQUENCE";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@SEQUENCE", SqlDbType.Decimal);
            paramArray[0].Value         = sequence;
            paramArray[1]               = CreateDataParameter("@DIMENSION_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = dimension_name;

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

        public bool RemoveLowDemensionName(int sequence)
        {
            string query = @"DELETE LOW_DIMENSION_NAME WHERE SEQUENCE = @SEQUENCE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@SEQUENCE", SqlDbType.Decimal);
            paramArray[0].Value         = sequence;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
