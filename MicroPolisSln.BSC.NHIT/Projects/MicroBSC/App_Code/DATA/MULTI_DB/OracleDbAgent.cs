using System;
using System.Data;
using System.Data.OracleClient;
using System.Runtime.InteropServices;

namespace MicroBSC.Data
{
    public class OracleDbAgent : IDbAgent
    {
        private OracleConnection     _connection;
        private OracleDataAdapter    _dataAdapter;
        private OracleCommandBuilder _oracleCom;

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
                    _dataAdapter = (OracleDataAdapter)value;
                }
            }
        }

        public OracleDbAgent()
        {
            _connection    = null;
            _dataAdapter   = null;
            _oracleCom     = null;
            _connection    = new OracleConnection();
        }

        public OracleDbAgent(IDbConnection connection)
        {
            _connection    = null;
            _dataAdapter   = null;
            _oracleCom     = null;
            _connection    = (OracleConnection)connection;
        }

        public OracleDbAgent(string connectStr)
        {
            _connection    = null;
            _dataAdapter   = null;
            _oracleCom     = null;
            _connection    = new OracleConnection(connectStr);
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
            OracleCommand command   = null;
            int num                 = 0;
            col                     = null;

            if (connection == null)
            {
                command             = new OracleCommand(DbAgentHelper.GetQueryStringReplace(strQuery), _connection);
            }
            else
            {
                command             = new OracleCommand(DbAgentHelper.GetQueryStringReplace(strQuery), (OracleConnection)connection);
            }

            if (trx != null)
            {
                command.Transaction = (OracleTransaction)trx;
            }

            command.CommandTimeout  = 0;
            command.CommandType     = cmdType;
            
            

            if (paramArray != null)
            {
                foreach (IDbDataParameter parameter in paramArray)
                {
					//try
					//{
					//    //�Ķ���� ������ Date �����̸鼭 ���� ������� �⺻ ��¥ ���� ���˿� �°� �Է����ش�.
					//    if (((OracleParameter)parameter).OracleType == OracleType.DateTime)
					//    {
					//        //���� ���ٸ�.
					//        if (parameter.Value == DBNull.Value)
					//        {
					//            parameter.Value = "NULL";
					//        }
					//        else
					//        {
					//            //DateTime paramDate = Convert.ToDateTime(parameter.Value);
					//            //parameter.Value = string.Format("TO_DATE('{0}-{1}-{2} {3}:{4}:{5}','YYYY-MM-DD hh24:mi:ss')",
					//            //    paramDate.Year.ToString("D4"),
					//            //    paramDate.Month.ToString("D2"),
					//            //    paramDate.Day.ToString("D2"),
					//            //    paramDate.Hour.ToString("D2"),
					//            //    paramDate.Minute.ToString("D2"),
					//            //    paramDate.Second.ToString("D2"));
					//        }
					//    }
					//}
					//catch (Exception ex)
					//{
					//    throw ex;
					//}
					try
					{
						//�Ķ���� ������ ������ ���ڿ��� _DATE �� �����°�� ���� ���Ѵ�.
						//if (parameter.ParameterName.Substring(parameter.ParameterName.Length-5, 5).ToUpper() == "_DATE" && parameter.Value == DBNull.Value)
						//{
						//    //parameter.Value = "TO_DATE('1900-01-01 00:00:00','YYYY-MM-DD hh24:mi:ss')";
						//    //parameter.Value = new DateTime(1900, 1, 1, 0, 0, 0);
						//    //parameter.Value = "NULL";
						//    parameter.Value = DateTime.Now;
						//    ((OracleParameter)parameter).DbType = DbType.DateTime;
						//    ((OracleParameter)parameter).OracleType = OracleType.DateTime;
						//}


                        // �߰��۾� : ����Ŭ ��ȯ�� ���� ''  �� ó�� (�嵿�� 10-08-20)
                        // �� ���ν��� �κп��� ��� ����

                        if (cmdType != CommandType.StoredProcedure)
                        {
                            //if (parameter.DbType == System.Data.DbType.AnsiString)
                            //{
                            //    parameter.Value = DBNull.Value;
                            //}
                            
                            if (string.IsNullOrEmpty(DataTypeUtility.GetValue(parameter.Value)))
                            {
                                if (parameter.Value == null)
                                    parameter.Value = " ";
                                else if (!parameter.Value.Equals(DBNull.Value))
                                    parameter.Value = " ";
                            }
                        }

                        command.Parameters.Add(DbAgentHelper.GetParameterNameReplace((OracleParameter)parameter, cmdType));

					}
					catch(Exception ex)
					{
                        //throw ex;
						//���� ���� �ش���� �ƴѰɷ� ������.
					}


                    //command.Parameters.Add(DbAgentHelper.GetParameterNameReplace((OracleParameter)parameter, cmdType));
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
                catch (OracleException exception)
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
            OracleDataReader reader     = null;
            paramCol                    = null;
            OracleCommand command       = new OracleCommand(DbAgentHelper.GetQueryStringReplace(strQuery), _connection);
            command.CommandType         = cmdType;

            if (paramArray != null)
            {
                foreach (IDbDataParameter parameter in paramArray)
                {
                    command.Parameters.Add(DbAgentHelper.GetParameterNameReplace((OracleParameter)parameter, cmdType));
                }
            }
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }

            _connection.Open();
            reader      = command.ExecuteReader(CommandBehavior.CloseConnection);
            paramCol    = command.Parameters;
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

        public object ExecuteScalar(IDbConnection connection
                                    , IDbTransaction trx
                                    , string strQuery
                                    , IDbDataParameter[] paramArray
                                    , CommandType cmdType
                                    , out IDataParameterCollection col)
        {
            OracleCommand command   = null;
            //int num                 = 0;
            col                     = null;
            object obj2             = null;

            if (connection == null)
            {
                command             = new OracleCommand(DbAgentHelper.GetQueryStringReplace(strQuery), _connection);
            }
            else
            {
                command             = new OracleCommand(DbAgentHelper.GetQueryStringReplace(strQuery), (OracleConnection)connection);
            }

            if (trx != null)
            {
                command.Transaction = (OracleTransaction)trx;
            }

            command.CommandTimeout  = 0;
            command.CommandType     = cmdType;

            if (paramArray != null)
            {
                foreach (IDbDataParameter parameter in paramArray)
                {
                    // �߰��۾� : ����Ŭ ��ȯ�� ���� ''  �� ó�� (������ 10-08-15)
                    // �� ���ν��� �κп��� ��� ����

                    if (cmdType != CommandType.StoredProcedure)
                    {
                        if (string.IsNullOrEmpty(DataTypeUtility.GetValue(parameter.Value)))
                        {
                            if (parameter.Value == null)
                                parameter.Value = " ";
                            else if (!parameter.Value.Equals(DBNull.Value))
                                parameter.Value = " ";
                        }
                    }

                    command.Parameters.Add(DbAgentHelper.GetParameterNameReplace((OracleParameter)parameter, cmdType));
                }

                //foreach (IDbDataParameter parameter in paramArray)
                //{
                //    command.Parameters.Add(DbAgentHelper.GetParameterNameReplace((OracleParameter)parameter, cmdType));
                //}
            }

            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }

            _connection.Open();
            obj2 = command.ExecuteScalar();
            //obj2 = command.ExecuteOracleScalar();
            _connection.Close();
            col = command.Parameters;
            return obj2;
        }

        public DataSet Fill(string strQuery)
        {
            return Fill(strQuery, null);
        }

        public DataSet Fill(string strQuery
                            , IDbDataParameter[] paramArray)
        {
            return Fill(strQuery, paramArray, CommandType.Text);
        }

        public DataSet Fill(string strQuery
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType)
        {
            string strAlias = "DefaultTBL";
            return FillDataSet(strQuery, strAlias, null, paramArray, cmdType);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(strQuery, strAlias, null, null, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, null, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , IDbDataParameter[] paramArray)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, paramArray, CommandType.Text, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                , string strAlias
                                , DataSet dsDataSet
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType)
        {
            IDataParameterCollection paramCol = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, paramArray, cmdType, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                , string strAlias
                                , DataSet dsDataSet
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType
                                , out IDataParameterCollection paramCol)
        {
            return FillDataSet(null, null, strQuery, strAlias, dsDataSet, paramArray, cmdType, out paramCol);
        }

        public DataSet FillDataSet(IDbConnection connection
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

        public DataSet FillDataSet(IDbConnection connection
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
                _dataAdapter = new OracleDataAdapter(DbAgentHelper.GetQueryStringReplace(strQuery), _connection);
            }
            else
            {
                _dataAdapter = new OracleDataAdapter(DbAgentHelper.GetQueryStringReplace(strQuery), (OracleConnection)connection);
            }

            if (trx != null)
            {
                _dataAdapter.SelectCommand.Transaction = (OracleTransaction)trx;
            }
            
            _oracleCom                                 = new OracleCommandBuilder(_dataAdapter);
            _dataAdapter.SelectCommand.CommandType     = cmdType;
            _dataAdapter.SelectCommand.CommandTimeout  = 0;

            if (dsDataSet == null)
            {
                dsDataSet = new DataSet();
            }
            if (paramArray != null)
            {

                foreach (System.Data.OracleClient.OracleParameter parameter in paramArray)
                {

                    // �߰��۾� : ����Ŭ ��ȯ�� ���� ''  �� ó�� (������ 10-08-15)
                    // �� ���ν��� �κп��� ��� ����

                    if (cmdType != CommandType.StoredProcedure)
                    {
                        if (string.IsNullOrEmpty(DataTypeUtility.GetValue(parameter.Value)))
                        {
                            if (parameter.Value == null)
                                parameter.Value = " ";
                            else if (!parameter.Value.Equals(DBNull.Value))
                            {

                                parameter.Value = " ";

                                //if (parameter.OracleType.Equals(System.Data.DbType.Int32))
                                //{
                                //    parameter.Value = "";
                                //}
                                //else
                                //{
                                //    parameter.Value = " ";
                                //}
                            }
                        }
                    }

                    _dataAdapter.SelectCommand.Parameters.Add(DbAgentHelper.GetParameterNameReplace((OracleParameter)parameter, cmdType));
                }

                if (cmdType == CommandType.StoredProcedure) 
                {
                    OracleParameter oracleParameter = new OracleParameter("O_CUSR_RTN", OracleType.Cursor);
                    oracleParameter.Direction       = ParameterDirection.Output;

                    _dataAdapter.SelectCommand.Parameters.Add(oracleParameter);
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

