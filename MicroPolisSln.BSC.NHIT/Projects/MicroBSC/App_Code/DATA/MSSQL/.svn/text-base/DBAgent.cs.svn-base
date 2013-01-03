using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace MicroBSC.Data
{
    public class DBAgent
    {
        private SqlConnection _connection;
        private SqlDataAdapter _dataAdapter;
        private SqlCommandBuilder _sqlCom;

        public string ConnectionString
        {
            get
            {
                if (this._connection.ConnectionString == null)
                {
                    return "";
                }
                return this._connection.ConnectionString;
            }
            set
            {
                this._connection.ConnectionString = value;
            }
        }

        public SqlDataAdapter DataAdapter
        {
            get
            {
                return this._dataAdapter;
            }
            set
            {
                if (this._dataAdapter != value)
                {
                    this._dataAdapter = value;
                }
            }
        }

        public DBAgent()
        {
            this._connection    = null;
            this._dataAdapter   = null;
            this._sqlCom        = null;
            this._connection    = new SqlConnection();
        }

        public DBAgent(SqlConnection connection)
        {
            this._connection    = null;
            this._dataAdapter   = null;
            this._sqlCom        = null;
            this._connection    = connection;
        }

        public DBAgent(string connectStr)
        {
            this._connection    = null;
            this._dataAdapter   = null;
            this._sqlCom        = null;
            this._connection    = new SqlConnection(connectStr);
        }

        public int ExecuteNonQuery(string strQuery)
        {
            SqlParameterCollection col = null;
            return this.ExecuteNonQuery(null, null, strQuery, null, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery
                                , SqlParameter[] paramArray)
        {
            SqlParameterCollection col = null;
            return this.ExecuteNonQuery(null, null, strQuery, paramArray, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(SqlConnection connection
                                , SqlTransaction trx
                                , string strQuery)
        {
            SqlParameterCollection col = null;
            return this.ExecuteNonQuery(connection, trx, strQuery, null, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery
                                , SqlParameter[] paramArray
                                , CommandType cmdType)
        {
            SqlParameterCollection col = null;
            return this.ExecuteNonQuery(null, null, strQuery, paramArray, cmdType, out col);
        }

        public int ExecuteNonQuery(SqlConnection connection
                                , SqlTransaction trx
                                , string strQuery
                                , SqlParameter[] paramArray)
        {
            SqlParameterCollection col = null;
            return this.ExecuteNonQuery(connection, trx, strQuery, paramArray, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery
                                , SqlParameter[] paramArray
                                , CommandType cmdType
                                , out SqlParameterCollection col)
        {
            return this.ExecuteNonQuery(null, null, strQuery, paramArray, cmdType, out col);
        }

        public int ExecuteNonQuery(SqlConnection connection
                                , SqlTransaction trx
                                , string strQuery
                                , SqlParameter[] paramArray
                                , CommandType cmdType)
        {
            SqlParameterCollection col = null;
            return this.ExecuteNonQuery(connection, trx, strQuery, paramArray, cmdType, out col);
        }

        public int ExecuteNonQuery(SqlConnection connection
                                , SqlTransaction trx
                                , string strQuery
                                , SqlParameter[] paramArray
                                , CommandType cmdType
                                , out SqlParameterCollection col)
        {
            SqlCommand command  = null;
            int num             = 0;
            col                 = null;

            if (connection == null)
            {
                command         = new SqlCommand(strQuery, this._connection);
            }
            else
            {
                command         = new SqlCommand(strQuery, connection);
            }

            if (trx != null)
            {
                command.Transaction = trx;
            }

            command.CommandTimeout  = 0;
            command.CommandType     = cmdType;
            if (paramArray != null)
            {
                foreach (SqlParameter parameter in paramArray)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                try
                {
                    if (this._connection.State == ConnectionState.Open)
                    {
                        this._connection.Close();
                    }
                    if (connection == null)
                    {
                        this._connection.Open();
                    }
                    num = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw exception;
                }
            }
            finally
            {
                col = command.Parameters;
                if (connection == null)
                {
                    this._connection.Close();
                }
            }
            return num;
        }

        public SqlDataReader ExecuteReader(string strQuery)
        {
            SqlParameterCollection paramCol = null;
            return this.ExecuteReader(strQuery, null, CommandType.Text, out paramCol);
        }

        public SqlDataReader ExecuteReader(string strQuery
                                        , SqlParameter[] paramArray)
        {
            SqlParameterCollection paramCol = null;
            return this.ExecuteReader(strQuery, paramArray, CommandType.Text, out paramCol);
        }

        public SqlDataReader ExecuteReader(string strQuery
                                        , SqlParameter[] paramArray
                                        , CommandType cmdType)
        {
            SqlParameterCollection paramCol = null;
            return this.ExecuteReader(strQuery, paramArray, cmdType, out paramCol);
        }

        public SqlDataReader ExecuteReader(string strQuery
                                        , SqlParameter[] paramArray
                                        , CommandType cmdType
                                        , out SqlParameterCollection paramCol)
        {
            SqlDataReader reader = null;
            paramCol = null;
            SqlCommand command = new SqlCommand(strQuery, this._connection);
            command.CommandType = cmdType;
            if (paramArray != null)
            {
                foreach (SqlParameter parameter in paramArray)
                {
                    command.Parameters.Add(parameter);
                }
            }
            if (this._connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }
            this._connection.Open();
            reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            paramCol = command.Parameters;
            return reader;
        }

        public object ExecuteScalar(string strQuery)
        {
            SqlParameterCollection col = null;
            return this.ExecuteScalar(null, null, strQuery, null, CommandType.Text, out col);
        }

        public object ExecuteScalar(string strQuery
                                , SqlParameter[] paramArray)
        {
            SqlParameterCollection col = null;
            return this.ExecuteScalar(null, null, strQuery, paramArray, CommandType.Text, out col);
        }

        public object ExecuteScalar(string strQuery
                                , SqlParameter[] paramArray
                                , CommandType cmdType)
        {
            SqlParameterCollection col = null;
            return this.ExecuteScalar(null, null, strQuery, paramArray, cmdType, out col);
        }

        public object ExecuteScalar(SqlConnection connection
                                , SqlTransaction trx
                                , string strQuery
                                , SqlParameter[] paramArray
                                , CommandType cmdType)
        {
            SqlParameterCollection col = null;
            return this.ExecuteScalar(connection, trx, strQuery, paramArray, cmdType, out col);
        }

        public object ExecuteScalar(SqlConnection connection
                                        , SqlTransaction trx
                                        , string strQuery
                                        , SqlParameter[] paramArray
                                        , CommandType cmdType
                                        , out SqlParameterCollection col)
        {
            SqlCommand command      = null;
            int num                 = 0;
            col                     = null;
            object obj2             = null;

            if (connection == null)
            {
                command             = new SqlCommand(strQuery, this._connection);
            }
            else
            {
                command             = new SqlCommand(strQuery, connection);
            }

            if (trx != null)
            {
                command.Transaction = trx;
            }

            command.CommandTimeout  = 0;
            command.CommandType     = cmdType;

            if (paramArray != null)
            {
                foreach (SqlParameter parameter in paramArray)
                {
                    command.Parameters.Add(parameter);
                }
            }

            if (this._connection.State == ConnectionState.Open)
            {
                this._connection.Close();
            }

            this._connection.Open();
            obj2 = command.ExecuteScalar();
            this._connection.Close();
            col = command.Parameters;
            return obj2;
        }

        public DataSet Fill(string strQuery)
        {
            return this.Fill(strQuery, null);
        }

        public DataSet Fill(string strQuery
                            , SqlParameter[] paramArray)
        {
            return this.Fill(strQuery, paramArray, CommandType.Text);
        }

        public DataSet Fill(string strQuery
                            , SqlParameter[] paramArray
                            , CommandType cmdType)
        {
            string strAlias = "DefaultTBL";
            return this.FillDataSet(strQuery, strAlias, null, paramArray, cmdType);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias)
        {
            SqlParameterCollection paramCol = null;
            return this.FillDataSet(strQuery, strAlias, null, null, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet)
        {
            SqlParameterCollection paramCol = null;
            return this.FillDataSet(strQuery, strAlias, dsDataSet, null, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , SqlParameter[] paramArray)
        {
            SqlParameterCollection paramCol = null;
            return this.FillDataSet(strQuery, strAlias, dsDataSet, paramArray, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , SqlParameter[] paramArray
                                    , CommandType cmdType)
        {
            SqlParameterCollection paramCol = null;
            return this.FillDataSet(strQuery, strAlias, dsDataSet, paramArray, cmdType, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , SqlParameter[] paramArray
                                    , CommandType cmdType
                                    , out SqlParameterCollection paramCol)
        {
            this._dataAdapter                               = new SqlDataAdapter(strQuery, this._connection);
            this._sqlCom                                    = new SqlCommandBuilder(this._dataAdapter);
            this._dataAdapter.SelectCommand.CommandType     = cmdType;
            this._dataAdapter.SelectCommand.CommandTimeout  = 0;

            if (dsDataSet == null)
            {
                dsDataSet = new DataSet();
            }
            if (paramArray != null)
            {
                foreach (SqlParameter parameter in paramArray)
                {
                    this._dataAdapter.SelectCommand.Parameters.Add(parameter);
                }
            }
            this._dataAdapter.Fill(dsDataSet, strAlias);
            paramCol = this._dataAdapter.SelectCommand.Parameters;
            return dsDataSet;
        }

        public int Update(DataSet dsDataSet, string strAlias)
        {
            return this._dataAdapter.Update(dsDataSet, strAlias);
        }
    }
}

