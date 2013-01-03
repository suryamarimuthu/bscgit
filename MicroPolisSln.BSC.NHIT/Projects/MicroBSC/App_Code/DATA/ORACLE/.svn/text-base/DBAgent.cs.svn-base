using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace MicroBSC.Data.Oracle
{
    public class DBAgent
    {
        private OracleConnection _connection;

        public DBAgent()
        {
            _connection = new OracleConnection();
        }
        public DBAgent(string connectStr)
        {
            _connection = new OracleConnection();
            _connection.ConnectionString = connectStr;
        }
        public string ConnectionString
        {
            set
            {
                this._connection.ConnectionString = value;
            }
        }
        public DataSet FillDataSet(string strQuery, string strAlias, DataSet dsDataSet,
            OracleParameter[] paramArray, CommandType cmdType, out OracleParameterCollection paramCol)
        {
            OracleDataAdapter sqlAdapter = new OracleDataAdapter(strQuery, _connection);

            sqlAdapter.SelectCommand.CommandType = cmdType;
            sqlAdapter.SelectCommand.CommandTimeout = 120;
            if (dsDataSet == null)
                dsDataSet = new DataSet();
            if (paramArray != null)
            {
                foreach (OracleParameter param in paramArray)
                {
                    sqlAdapter.SelectCommand.Parameters.Add(param);
                }
            }
            sqlAdapter.Fill(dsDataSet, strAlias);
            paramCol = sqlAdapter.SelectCommand.Parameters;

            return dsDataSet;
        }
        public DataSet FillDataSet(string strQuery, string strAlias, DataSet dsDataSet,
            OracleParameter[] paramArray, CommandType cmdType)
        {
            OracleParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, paramArray, cmdType, out col);
        }
        public DataSet FillDataSet(string strQuery, string strAlias, DataSet dsDataSet,
            OracleParameter[] paramArray)
        {
            OracleParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, paramArray, CommandType.Text, out col);
        }

        public DataSet FillDataSet(string strQuery, string strAlias, DataSet dsDataSet)
        {
            OracleParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, null, CommandType.Text, out col);
        }

        public DataSet FillDataSet(string strQuery, string strAlias)
        {
            OracleParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, null, null, CommandType.Text, out col);
        }

        public DataSet Fill(string strQuery, OracleParameter[] paramArray, CommandType cmdType)
        {
            string strAlias = "DefaultTBL";

            return FillDataSet(strQuery, strAlias, null, paramArray, cmdType);
        }

        public DataSet Fill(string strQuery, OracleParameter[] paramArray)
        {
            return Fill(strQuery, paramArray, CommandType.Text);
        }

        public DataSet Fill(string strQuery)
        {
            return Fill(strQuery, null);
        }

        public OracleDataReader ExecuteReader(string strQuery, OracleParameter[] paramArray,
            CommandType cmdType, out OracleParameterCollection paramCol)
        {
            OracleDataReader reader = null;
            paramCol = null;

            OracleCommand cmd = new OracleCommand(strQuery, _connection);
            cmd.CommandType = cmdType;

            if (paramArray != null)
            {
                foreach (OracleParameter param in paramArray)
                {
                    cmd.Parameters.Add(param);
                }
            }
            _connection.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            paramCol = cmd.Parameters;

            return reader;
        }

        public OracleDataReader ExecuteReader(string strQuery, OracleParameter[] paramArray,
            CommandType cmdType)
        {
            OracleParameterCollection col = null;
            return ExecuteReader(strQuery, paramArray, cmdType, out col);
        }

        public OracleDataReader ExecuteReader(string strQuery, OracleParameter[] paramArray)
        {
            OracleParameterCollection col = null;
            return ExecuteReader(strQuery, paramArray, CommandType.Text, out col);
        }

        public OracleDataReader ExecuteReader(string strQuery)
        {
            OracleParameterCollection col = null;
            return ExecuteReader(strQuery, null, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery, OracleParameter[] paramArray,
            CommandType cmdType, out OracleParameterCollection col)
        {
            int nRc = 0;
            col = null;

            OracleCommand cmd = new OracleCommand(strQuery, _connection);
            cmd.CommandType = cmdType;

            if (paramArray != null)
            {
                foreach (OracleParameter param in paramArray)
                {
                    cmd.Parameters.Add(param);
                }
            }

            try
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                _connection.Open();
                nRc = cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                throw new Exception("ExecuteNonQuery가 실패했습니다.", e);
            }
            finally
            {
                col = cmd.Parameters;
               // _connection.Dispose();
                _connection.Close();
            }

            return nRc;
        }

        public int ExecuteNonQuery(string strQuery, OracleParameter[] paramArray, CommandType cmdType)
        {
            OracleParameterCollection col = null;
            return ExecuteNonQuery(strQuery, paramArray, cmdType, out col);
        }

        public int ExecuteNonQuery(string strQuery, OracleParameter[] paramArray)
        {
            OracleParameterCollection col = null;
            return ExecuteNonQuery(strQuery, paramArray, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery)
        {
            OracleParameterCollection col = null;
            return ExecuteNonQuery(strQuery, null, CommandType.Text, out col);
        }

        public object ExecuteScalar(string strQuery, OracleParameter[] paramArray,
            CommandType cmdType, out OracleParameterCollection col)
        {

            object oRc = 0;
            col = null;

            OracleCommand cmd = new OracleCommand(strQuery, _connection);
            cmd.CommandType = cmdType;

            if (paramArray != null)
            {
                foreach (OracleParameter param in paramArray)
                {
                    cmd.Parameters.Add(param);
                }
            }

            _connection.Open();
            oRc = cmd.ExecuteScalar();
            //_connection.Dispose();
            _connection.Close();
            col = cmd.Parameters;

            return oRc;
        }

        public object ExecuteScalar(string strQuery, OracleParameter[] paramArray,
            CommandType cmdType)
        {
            OracleParameterCollection col = null;
            return ExecuteScalar(strQuery, paramArray, cmdType, out col);
        }

        public object ExecuteScalar(string strQuery, OracleParameter[] paramArray)
        {
            OracleParameterCollection col = null;
            return ExecuteScalar(strQuery, paramArray, CommandType.Text, out col);
        }

        public object ExecuteScalar(string strQuery)
        {
            OracleParameterCollection col = null;
            return ExecuteScalar(strQuery, null, CommandType.Text, out col);
        }
    }
}
