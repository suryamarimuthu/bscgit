using System;
using System.Data;
using System.Data.Odbc;
using System.Runtime.InteropServices;

namespace MicroBSC.Data
{
    public class OdbcDbAgent : IDbAgent
    {
        private OdbcConnection _connection;
        private OdbcDataAdapter _dataAdapter;
        private OdbcCommandBuilder _sqlCom;

        public string ConnectionString
        {
            get
            {
                if (_connection.ConnectionString == null)
                {
                    return "";
                }
                return _connection.ConnectionString;
            }
            set
            {
                _connection.ConnectionString = value;
            }
        }

        public IDbDataAdapter DataAdapter
        {
            get
            {
                return _dataAdapter;
            }
            set
            {
                if (_dataAdapter != value)
                {
                    _dataAdapter = (OdbcDataAdapter)value;
                }
            }
        }

        public OdbcDbAgent()
        {
            _connection    = null;
            _dataAdapter   = null;
            _sqlCom        = null;
            _connection    = new OdbcConnection();
        }

        public OdbcDbAgent(IDbConnection connection)
        {
            _connection    = null;
            _dataAdapter   = null;
            _sqlCom        = null;
            _connection    = (OdbcConnection)connection;
        }

        public OdbcDbAgent(string connectStr)
        {
            _connection    = null;
            _dataAdapter   = null;
            _sqlCom        = null;
            _connection    = new OdbcConnection(connectStr);
        }

        public int ExecuteNonQuery(string strQuery)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteNonQuery(null, null, strQuery, null, CommandType.Text, out paramCol);
        }

        public int ExecuteNonQuery(string strQuery
                                , IDbDataParameter[] paramArray)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteNonQuery(null, null, strQuery, paramArray, CommandType.Text, out paramCol);
        }

        public int ExecuteNonQuery(IDbConnection connection
                                , IDbTransaction trx
                                , string strQuery)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteNonQuery(connection, trx, strQuery, null, CommandType.Text, out paramCol);
        }

        public int ExecuteNonQuery(string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteNonQuery(null, null, strQuery, paramArray, cmdType, out paramCol);
        }

        public int ExecuteNonQuery(IDbConnection connection
                                , IDbTransaction trx
                                , string strQuery
                                , IDbDataParameter[] paramArray)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteNonQuery(connection, trx, strQuery, paramArray, CommandType.Text, out paramCol);
        }

        public int ExecuteNonQuery(string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType
                                , out IDataParameterCollection col)
        {
            return ExecuteNonQuery(null, null, strQuery, paramArray, cmdType, out col);
        }

        public int ExecuteNonQuery(IDbConnection connection
                                , IDbTransaction trx
                                , string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteNonQuery(connection, trx, strQuery, paramArray, cmdType, out paramCol);
        }

        public int ExecuteNonQuery(IDbConnection connection
                                , IDbTransaction trx
                                , string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType
                                , out IDataParameterCollection col)
        {
            OdbcCommand command  = null;
            int num             = 0;
            col                 = null;

            if (connection == null)
            {
                command         = new OdbcCommand(strQuery, _connection);
            }
            else
            {
                command         = new OdbcCommand(strQuery, (OdbcConnection)connection);
            }

            if (trx != null)
            {
                command.Transaction = (OdbcTransaction)trx;
            }

            command.CommandTimeout  = 0;
            command.CommandType     = cmdType;
            if (paramArray != null)
            {
                foreach (IDbDataParameter parameter in paramArray)
                {
                    command.Parameters.Add((OdbcParameter)parameter);
                }
            }
            try
            {
                try
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                    if (connection == null)
                    {
                        _connection.Open();
                    }
                    num = command.ExecuteNonQuery();
                }
                catch (OdbcException exception)
                {
                    throw exception;
                }
            }
            finally
            {
                col = command.Parameters;
                if (connection == null)
                {
                    _connection.Close();
                }
            }
            return num;
        }

        public IDataReader ExecuteReader(string strQuery)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteReader(strQuery, null, CommandType.Text, out paramCol);
        }

        public IDataReader ExecuteReader(string strQuery
                                        , IDbDataParameter[] paramArray)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteReader(strQuery, paramArray, CommandType.Text, out paramCol);
        }

        public IDataReader ExecuteReader(string strQuery
                                        , IDbDataParameter[] paramArray
                                        , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteReader(strQuery, paramArray, cmdType, out paramCol);
        }

        public IDataReader ExecuteReader(string strQuery
                                        , IDbDataParameter[] paramArray
                                        , CommandType cmdType
                                        , out IDataParameterCollection paramCol)
        {
            OdbcDataReader reader = null;
            paramCol = null;
            OdbcCommand command = new OdbcCommand(strQuery, _connection);
            command.CommandType = cmdType;
            if (paramArray != null)
            {
                foreach (IDbDataParameter parameter in paramArray)
                {
                    command.Parameters.Add(parameter);
                }
            }
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Open();
            reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            paramCol = command.Parameters;
            return reader;
        }

        public object ExecuteScalar(string strQuery)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteScalar(null, null, strQuery, null, CommandType.Text, out paramCol);
        }

        public object ExecuteScalar(string strQuery
                                , IDbDataParameter[] paramArray)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteScalar(null, null, strQuery, paramArray, CommandType.Text, out paramCol);
        }

        public object ExecuteScalar(string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteScalar(null, null, strQuery, paramArray, cmdType, out paramCol);
        }

        public object ExecuteScalar(IDbConnection connection
                                , IDbTransaction trx
                                , string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return ExecuteScalar(connection, trx, strQuery, paramArray, cmdType, out paramCol);
        }

        public object ExecuteScalar(  IDbConnection connection
                                    , IDbTransaction trx
                                    , string strQuery
                                    , IDbDataParameter[] paramArray
                                    , CommandType cmdType
                                    , out IDataParameterCollection col)
        {
            OdbcCommand command      = null;
            //int num                 = 0;
            col                     = null;
            object obj2             = null;

            if (connection == null)
            {
                command             = new OdbcCommand(strQuery, _connection);
            }
            else
            {
                command             = new OdbcCommand(strQuery, (OdbcConnection)connection);
            }

            if (trx != null)
            {
                command.Transaction = (OdbcTransaction)trx;
            }

            command.CommandTimeout  = 0;
            command.CommandType     = cmdType;

            if (paramArray != null)
            {
                foreach (IDbDataParameter parameter in paramArray)
                {
                    command.Parameters.Add((OdbcParameter)parameter);
                }
            }

            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }

            _connection.Open();
            obj2 = command.ExecuteScalar();
            _connection.Close();
            col = command.Parameters;
            return obj2;
        }

        public DataSet Fill(string strQuery)
        {
            return Fill(strQuery, null);
        }

        public DataSet Fill(  string strQuery
                            , IDbDataParameter[] paramArray)
        {
            return Fill(strQuery, paramArray, CommandType.Text);
        }

        public DataSet Fill(  string strQuery
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType)
        {
            string strAlias = "DefaultTBL";
            return FillDataSet(null, null, strQuery, strAlias, null, paramArray, cmdType);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(null, null, strQuery, strAlias, null, null, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(null, null, strQuery, strAlias, dsDataSet, null, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , IDbDataParameter[] paramArray)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(null, null, strQuery, strAlias, dsDataSet, paramArray, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , IDbDataParameter[] paramArray
                                    , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(null, null, strQuery, strAlias, dsDataSet, paramArray, cmdType, out paramCol);
        }

        public DataSet FillDataSet(   string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , IDbDataParameter[] paramArray
                                    , CommandType cmdType
                                    , out IDataParameterCollection paramCol)
        {
            return FillDataSet(null, null, strQuery, strAlias, dsDataSet, paramArray, cmdType, out paramCol);
        }

        public DataSet FillDataSet(   IDbConnection connection
                                    , IDbTransaction trx
                                    , string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , IDbDataParameter[] paramArray
                                    , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(connection, trx, strQuery, strAlias, dsDataSet, paramArray, cmdType, out paramCol);
        }

        public DataSet FillDataSet(   IDbConnection connection
                                    , IDbTransaction trx
                                    , string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , IDbDataParameter[] paramArray
                                    , CommandType cmdType
                                    , out IDataParameterCollection paramCol)
        {
            if (connection == null)
            {
                _dataAdapter = new OdbcDataAdapter(strQuery, _connection);
            }
            else
            {
                _dataAdapter = new OdbcDataAdapter(strQuery, (OdbcConnection)connection);
            }

            if (trx != null)
            {
                _dataAdapter.SelectCommand.Transaction = (OdbcTransaction)trx;
            }
            
            _sqlCom                                    = new OdbcCommandBuilder(_dataAdapter);

            _dataAdapter.SelectCommand.CommandType     = cmdType;
            _dataAdapter.SelectCommand.CommandTimeout  = 0;

            if (dsDataSet == null)
            {
                dsDataSet = new DataSet();
            }
            if (paramArray != null)
            {
                foreach (IDbDataParameter parameter in paramArray)
                {
                    _dataAdapter.SelectCommand.Parameters.Add( (OdbcParameter)parameter );
                }
            }
            _dataAdapter.Fill(dsDataSet, strAlias);
            paramCol = _dataAdapter.SelectCommand.Parameters;
            return dsDataSet;
        }

        public int Update(DataSet dsDataSet, string strAlias)
        {
            return _dataAdapter.Update(dsDataSet, strAlias);
        }
    }
}

