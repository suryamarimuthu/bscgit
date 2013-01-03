using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace MicroBSC.Data
{
    public class ExcelAgent
    {
        private bool _bHdr                      = true;
        //private string _sConn                   = "Provider=Microsoft.Jet.OLEDB.4.0;Password=\"\";User ID=Admin;Data Source=:G_EXCEL_FILE;Mode=Read;Extended Properties=Excel 8.0;HDR=:G_HDR;Jet OLEDB:System database=\"\";Jet OLEDB:Registry Path=\"\";Jet OLEDB:Database Password=\"\";Jet OLEDB:Engine Type=35";
        private string _sConn                   = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=:G_EXCEL_FILE;Extended Properties=""Excel 8.0;HDR=:G_HDR;""";
        private string _sFilePath               = "";
        private const string CS_REPLACE_EXCEL   = ":G_EXCEL_FILE";
        private const string CS_REPLACE_HDR     = ":G_HDR";
        private OleDbDataAdapter mObjAdapter    = null;

        public int ExecuteNonQuery(string strQuery)
        {
            OleDbParameterCollection col = null;
            return ExecuteNonQuery(strQuery, null, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery, OleDbParameter[] paramArray)
        {
            OleDbParameterCollection col = null;
            return ExecuteNonQuery(strQuery, paramArray, CommandType.Text, out col);
        }

        public int ExecuteNonQuery(string strQuery, OleDbParameter[] paramArray, CommandType cmdType)
        {
            OleDbParameterCollection col = null;
            return ExecuteNonQuery(strQuery, paramArray, cmdType, out col);
        }

        public int ExecuteNonQuery(string strQuery
                                    , OleDbParameter[] paramArray
                                    , CommandType cmdType
                                    , out OleDbParameterCollection col)
        {
            int num                     = 0;
            col                         = null;
            OleDbConnection connection  = new OleDbConnection(GetConnStr());
            OleDbCommand command        = new OleDbCommand(strQuery, connection);
            command.CommandType         = cmdType;

            if (paramArray != null)
            {
                foreach (OleDbParameter parameter in paramArray)
                {
                    command.Parameters.Add(parameter);
                }
            }
            try
            {
                try
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (OleDbException exception)
                {
                    throw exception;
                }
            }
            finally
            {
                col = command.Parameters;
                connection.Close();
            }
            return num;
        }

        public DataSet Fill(string strQuery)
        {
            return Fill(strQuery, null);
        }

        public DataSet Fill(string strQuery, OleDbParameter[] paramArray)
        {
            return Fill(strQuery, paramArray, CommandType.Text);
        }

        public DataSet Fill(string strQuery, OleDbParameter[] paramArray, CommandType cmdType)
        {
            string strAlias = "DefaultTBL";
            return FillDataSet(strQuery, strAlias, null, paramArray, cmdType);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , OleDbParameter[] paramArray
                                    , CommandType cmdType)
        {
            OleDbParameterCollection paramCol = null;
            return FillDataSet(strQuery, strAlias, dsDataSet, paramArray, cmdType, out paramCol);
        }

        public DataSet FillDataSet(string strQuery
                                    , string strAlias
                                    , DataSet dsDataSet
                                    , OleDbParameter[] paramArray
                                    , CommandType cmdType
                                    , out OleDbParameterCollection paramCol)
        {
            paramCol = null;
            if (dsDataSet == null)
            {
                dsDataSet = new DataSet();
            }
            if (this._sFilePath != "")
            {
                mObjAdapter = new OleDbDataAdapter(strQuery, this.GetConnStr());

                if (paramArray != null)
                {
                    foreach (OleDbParameter parameter in paramArray)
                    {
                        this.mObjAdapter.SelectCommand.Parameters.Add(parameter);
                    }
                }

                mObjAdapter.Fill(dsDataSet, strAlias);
                paramCol = mObjAdapter.SelectCommand.Parameters;
            }
            return dsDataSet;
        }

        private string GetConnStr()
        {
            return _sConn.Replace(":G_EXCEL_FILE", _sFilePath).Replace(":G_HDR", _bHdr ? "YES" : "NO");
        }

        public string GetFirstSheet()
        {
            string text;

            if (this._sFilePath == "")
            {
                return "";
            }
            OleDbConnection connection  = null;
            DataTable oleDbSchemaTable  = null;
            try
            {
                connection              = new OleDbConnection(this.GetConnStr());
                connection.Open();
                oleDbSchemaTable        = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (oleDbSchemaTable == null)
                {
                    return "";
                }
                if (oleDbSchemaTable.Rows.Count < 1)
                {
                    return "";
                }
                text = oleDbSchemaTable.Rows[0]["TABLE_NAME"].ToString();
            }
            catch (Exception)
            {
                text = "";
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                if (oleDbSchemaTable != null)
                {
                    oleDbSchemaTable.Dispose();
                }
            }
            return text;
        }

        public string FilePath
        {
            get
            {
                return _sFilePath;
            }
            set
            {
                _sFilePath = value;
            }
        }

        public bool HDR
        {
            get
            {
                return _bHdr;
            }
            set
            {
                _bHdr = value;
            }
        }
    }
}

