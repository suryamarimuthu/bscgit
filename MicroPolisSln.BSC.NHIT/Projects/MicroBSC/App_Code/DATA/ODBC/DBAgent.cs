using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace MicroBSC.Data.Odbc
{
    public class DBAgent
    {
        private OdbcConnection _connection;

        public DBAgent()
        {
            _connection = new OdbcConnection();
        }
        public DBAgent(string connectStr)
        {
            _connection = new OdbcConnection();
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
            OdbcParameter[] paramArray, CommandType cmdType, out OdbcParameterCollection paramCol)
        {
            OdbcDataAdapter sqlAdapter = new OdbcDataAdapter(strQuery, _connection);

            sqlAdapter.SelectCommand.CommandType = cmdType;
            sqlAdapter.SelectCommand.CommandTimeout = 120;
            if (dsDataSet == null)
                dsDataSet = new DataSet();
            if (paramArray != null)
            {
                foreach (OdbcParameter param in paramArray)
                {
                    sqlAdapter.SelectCommand.Parameters.Add(param);
                }
            }
            sqlAdapter.Fill(dsDataSet, strAlias);
            paramCol = sqlAdapter.SelectCommand.Parameters;

            return dsDataSet;
        }
        public DataSet FillDataSet(string strQuery, string strAlias, DataSet dsDataSet,
            OdbcParameter[] paramArray, CommandType cmdType)
        {
            OdbcParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, paramArray, cmdType, out col);
        }
        public DataSet FillDataSet(string strQuery, string strAlias, DataSet dsDataSet,
            OdbcParameter[] paramArray)
        {
            OdbcParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, paramArray, CommandType.Text, out col);
        }

        public DataSet FillDataSet(string strQuery, string strAlias, DataSet dsDataSet)
        {
            OdbcParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, null, CommandType.Text, out col);
        }

        public DataSet FillDataSet(string strQuery, string strAlias)
        {
            OdbcParameterCollection col = null;
            return FillDataSet(strQuery, strAlias, null, null, CommandType.Text, out col);
        }

        public DataSet Fill(string strQuery, OdbcParameter[] paramArray, CommandType cmdType)
        {
            string strAlias = "DefaultTBL";

            return FillDataSet(strQuery, strAlias, null, paramArray, cmdType);
        }

        public DataSet Fill(string strQuery, OdbcParameter[] paramArray)
        {
            return Fill(strQuery, paramArray, CommandType.Text);
        }

        public DataSet Fill(string strQuery)
        {
            return Fill(strQuery, null);
        }

        public OdbcDataReader ExecuteReader(string strQuery, OdbcParameter[] paramArray,
            CommandType cmdType, out OdbcParameterCollection paramCol)
        {
            OdbcDataReader reader = null;
            paramCol = null;

            OdbcCommand cmd = new OdbcCommand(strQuery, _connection);
            cmd.CommandType = cmdType;

            if (paramArray != null)
            {
                foreach (OdbcParameter param in paramArray)
                {
                    cmd.Parameters.Add(param);
                }
            }
            _connection.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            paramCol = cmd.Parameters;

            return reader;
        }

        public OdbcDataReader ExecuteReader(string strQuery, OdbcParameter[] paramArray,
            CommandType cmdType)
        {
            OdbcParameterCollection col = null;
            return ExecuteReader(strQuery, paramArray, cmdType, out col);
        }

        public OdbcDataReader ExecuteReader(string strQuery, OdbcParameter[] paramArray)
        {
            OdbcParameterCollection col = null;
            return ExecuteReader(strQuery, paramArray, CommandType.Text, out col);
        }

        public OdbcDataReader ExecuteReader(string strQuery)
        {
            OdbcParameterCollection col = null;
            return ExecuteReader(strQuery, null, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery, OdbcParameter[] paramArray,
            CommandType cmdType, out OdbcParameterCollection col)
        {
            int nRc = 0;
            col = null;

            OdbcCommand cmd = new OdbcCommand(strQuery, _connection);
            cmd.CommandType = cmdType;

            if (paramArray != null)
            {
                foreach (OdbcParameter param in paramArray)
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
            catch (OdbcException e)
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

        public int ExecuteNonQuery(string strQuery, OdbcParameter[] paramArray, CommandType cmdType)
        {
            OdbcParameterCollection col = null;
            return ExecuteNonQuery(strQuery, paramArray, cmdType, out col);
        }

        public int ExecuteNonQuery(string strQuery, OdbcParameter[] paramArray)
        {
            OdbcParameterCollection col = null;
            return ExecuteNonQuery(strQuery, paramArray, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery)
        {
            OdbcParameterCollection col = null;
            return ExecuteNonQuery(strQuery, null, CommandType.Text, out col);
        }

        public object ExecuteScalar(string strQuery, OdbcParameter[] paramArray,
            CommandType cmdType, out OdbcParameterCollection col)
        {

            object oRc = 0;
            col = null;

            OdbcCommand cmd = new OdbcCommand(strQuery, _connection);
            cmd.CommandType = cmdType;

            if (paramArray != null)
            {
                foreach (OdbcParameter param in paramArray)
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

        public object ExecuteScalar(string strQuery, OdbcParameter[] paramArray,
            CommandType cmdType)
        {
            OdbcParameterCollection col = null;
            return ExecuteScalar(strQuery, paramArray, cmdType, out col);
        }

        public object ExecuteScalar(string strQuery, OdbcParameter[] paramArray)
        {
            OdbcParameterCollection col = null;
            return ExecuteScalar(strQuery, paramArray, CommandType.Text, out col);
        }

        public object ExecuteScalar(string strQuery)
        {
            OdbcParameterCollection col = null;
            return ExecuteScalar(strQuery, null, CommandType.Text, out col);
        }
    }
}
