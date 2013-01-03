using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MicroBSC.Data
{
    public interface IDbAgent
    {
        string ConnectionString
        {
            get;set;
        }

        IDbDataAdapter DataAdapter
        {
            get;set;
        }

        int ExecuteNonQuery(string strQuery);

        int ExecuteNonQuery(string strQuery
                        , IDbDataParameter[] paramArray);

        int ExecuteNonQuery(IDbConnection connection
                        , IDbTransaction trx
                        , string strQuery);

        int ExecuteNonQuery(string strQuery
                        , IDbDataParameter[] paramArray
                        , CommandType cmdType);

        int ExecuteNonQuery(IDbConnection connection
                        , IDbTransaction trx
                        , string strQuery
                        , IDbDataParameter[] paramArray);

        int ExecuteNonQuery(string strQuery
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType
                            , out IDataParameterCollection col);

        int ExecuteNonQuery(IDbConnection connection
                        , IDbTransaction trx
                        , string strQuery
                        , IDbDataParameter[] paramArray
                        , CommandType cmdType);

        int ExecuteNonQuery(IDbConnection connection
                        , IDbTransaction trx
                        , string strQuery
                        , IDbDataParameter[] paramArray
                        , CommandType cmdType
                        , out IDataParameterCollection col);

        IDataReader ExecuteReader(string strQuery);

        IDataReader ExecuteReader(string strQuery
                                , IDbDataParameter[] paramArray);

        IDataReader ExecuteReader(string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType);

        IDataReader ExecuteReader(string strQuery
                                , IDbDataParameter[] paramArray
                                , CommandType cmdType
                                , out IDataParameterCollection paramCol);

        object ExecuteScalar(string strQuery);

        object ExecuteScalar(string strQuery
                            , IDbDataParameter[] paramArray);

        object ExecuteScalar(string strQuery
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType);

        object ExecuteScalar(IDbConnection connection
                            , IDbTransaction trx
                            , string strQuery
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType);

        object ExecuteScalar(IDbConnection connection
                            , IDbTransaction trx
                            , string strQuery
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType
                            , out IDataParameterCollection col);

        DataSet Fill(string strQuery);

        DataSet Fill(string strQuery
                            , IDbDataParameter[] paramArray);

        DataSet Fill(string strQuery
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType);


        DataSet FillDataSet(string strQuery, string strAlias);

        DataSet FillDataSet(  string strQuery
                            , string strAlias
                            , DataSet dsDataSet);

        DataSet FillDataSet(  string strQuery
                            , string strAlias
                            , DataSet dsDataSet
                            , IDbDataParameter[] paramArray);

        DataSet FillDataSet(  string strQuery
                            , string strAlias
                            , DataSet dsDataSet
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType);

        DataSet FillDataSet(  string strQuery
                            , string strAlias
                            , DataSet dsDataSet
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType
                            , out IDataParameterCollection paramCol);

        DataSet FillDataSet(  IDbConnection connection
                            , IDbTransaction trx
                            , string strQuery
                            , string strAlias
                            , DataSet dsDataSet
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType);

        DataSet FillDataSet(  IDbConnection connection
                            , IDbTransaction trx
                            , string strQuery
                            , string strAlias
                            , DataSet dsDataSet
                            , IDbDataParameter[] paramArray
                            , CommandType cmdType
                            , out IDataParameterCollection paramCol);
    }
}