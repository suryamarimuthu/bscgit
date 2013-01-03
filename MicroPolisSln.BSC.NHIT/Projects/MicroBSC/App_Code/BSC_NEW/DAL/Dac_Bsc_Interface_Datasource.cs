using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Interface_Datasource
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Interface_Datasource
    /// Class Func     : BSC_INTERFACE_DATASOURCE Table Data Access
    /// CREATE DATE    : 2008-08-28 오후 3:35:22
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Interface_Datasource : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _isource_id;
        private String         _isource_name;
        private String         _isource_type;
        private String         _ics_initial_catalog;
        private String         _ics_data_source;
        private String         _ics_provider;
        private String         _ics_user_id;
        private String         _ics_password;
        private String         _ics_connect_timeout;
        private String         _ics_extended_properties;
        private String         _idescriptions;
        private String         _iuse_yn;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public int ISource_Id
        {
            get { return _isource_id; }
            set { _isource_id = value; }
        }
        public string ISource_Name
        {
            get { return _isource_name; }
            set { _isource_name = value; }
        }
        public string ISource_Type
        {
            get { return _isource_type; }
            set { _isource_type = value; }
        }
        public string ICs_Initial_Catalog
        {
            get { return _ics_initial_catalog; }
            set { _ics_initial_catalog = value; }
        }
        public string ICs_Data_Source
        {
            get { return _ics_data_source; }
            set { _ics_data_source = value; }
        }
        public string ICs_Provider
        {
            get { return _ics_provider; }
            set { _ics_provider = value; }
        }
        public string ICs_User_Id
        {
            get { return _ics_user_id; }
            set { _ics_user_id = value; }
        }
        public string ICs_Password
        {
            get { return _ics_password; }
            set { _ics_password = value; }
        }
        public string ICs_Connect_Timeout
        {
            get { return _ics_connect_timeout; }
            set { _ics_connect_timeout = value; }
        }
        public string ICs_Extended_Properties
        {
            get { return _ics_extended_properties; }
            set { _ics_extended_properties = value; }
        }
        public string IDescriptions
        {
            get { return _idescriptions; }
            set { _idescriptions = value; }
        }
        public string IUse_Yn
        {
            get { return _iuse_yn; }
            set { _iuse_yn = value; }
        }
        public int ICreate_User
        {
            get { return _icreate_user; }
            set { _icreate_user = value; }
        }
        public System.DateTime ICreate_Date
        {
            get { return _icreate_date; }
            set { _icreate_date = value; }
        }
        public int IUpdate_User
        {
            get { return _iupdate_user; }
            set { _iupdate_user = value; }
        }
        public System.DateTime IUpdate_Date
        {
            get { return _iupdate_date; }
            set { _iupdate_date = value; }
        }
        public String Transaction_Message
        {
            get { return _txr_message; }
            set { _txr_message = value; }
        }
        public String Transaction_Result
        {
            get { return _txr_result; }
            set { _txr_result = value; }
        }
        #endregion
		
		#region ============================== [Constructor] ==============================
		public Dac_Bsc_Interface_Datasource() { }
        public Dac_Bsc_Interface_Datasource(int isource_id)
        {
            DataSet ds = this.GetOneList( isource_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_isource_id                  = (dr["SOURCE_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["SOURCE_ID"]);
                _isource_name                = (dr["SOURCE_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["SOURCE_NAME"]);
                _isource_type                = (dr["SOURCE_TYPE"] == DBNull.Value) ? "" : Convert.ToString(dr["SOURCE_TYPE"]);
                _ics_initial_catalog         = (dr["CS_INITIAL_CATALOG"] == DBNull.Value) ? "" : Convert.ToString(dr["CS_INITIAL_CATALOG"]);
                _ics_data_source             = (dr["CS_DATA_SOURCE"] == DBNull.Value) ? "" : Convert.ToString(dr["CS_DATA_SOURCE"]);
                _ics_provider                = (dr["CS_PROVIDER"] == DBNull.Value) ? "" : Convert.ToString(dr["CS_PROVIDER"]);
                _ics_user_id                 = (dr["CS_USER_ID"] == DBNull.Value) ? "" : Convert.ToString(dr["CS_USER_ID"]);
                _ics_password                = (dr["CS_PASSWORD"] == DBNull.Value) ? "" : Convert.ToString(dr["CS_PASSWORD"]);
                _ics_connect_timeout         = (dr["CS_CONNECT_TIMEOUT"] == DBNull.Value) ? "" : Convert.ToString(dr["CS_CONNECT_TIMEOUT"]);
                _ics_extended_properties     = (dr["CS_EXTENDED_PROPERTIES"] == DBNull.Value) ? "" : Convert.ToString(dr["CS_EXTENDED_PROPERTIES"]);
                _idescriptions               = (dr["DESCRIPTIONS"] == DBNull.Value) ? "" : Convert.ToString(dr["DESCRIPTIONS"]);
                _iuse_yn                     = (dr["USE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx, string isource_name, string isource_type, string ics_initial_catalog, string ics_data_source
               , string ics_provider, string ics_user_id, string ics_password, string ics_connect_timeout, string ics_extended_properties, string idescriptions
               , string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iSOURCE_NAME", SqlDbType.NVarChar);
            paramArray[1].Value         = isource_name;
            paramArray[2]               = CreateDataParameter("@iSOURCE_TYPE", SqlDbType.NVarChar);
            paramArray[2].Value         = isource_type;
            paramArray[3]               = CreateDataParameter("@iCS_INITIAL_CATALOG", SqlDbType.NVarChar);
            paramArray[3].Value         = ics_initial_catalog;
            paramArray[4]               = CreateDataParameter("@iCS_DATA_SOURCE", SqlDbType.NVarChar);
            paramArray[4].Value         = ics_data_source;
            paramArray[5]               = CreateDataParameter("@iCS_PROVIDER", SqlDbType.NVarChar);
            paramArray[5].Value         = ics_provider;
            paramArray[6]               = CreateDataParameter("@iCS_USER_ID", SqlDbType.NVarChar);
            paramArray[6].Value         = ics_user_id;
            paramArray[7]               = CreateDataParameter("@iCS_PASSWORD", SqlDbType.NVarChar);
            paramArray[7].Value         = ics_password;
            paramArray[8]               = CreateDataParameter("@iCS_CONNECT_TIMEOUT", SqlDbType.NVarChar);
            paramArray[8].Value         = ics_connect_timeout;
            paramArray[9]               = CreateDataParameter("@iCS_EXTENDED_PROPERTIES", SqlDbType.NVarChar);
            paramArray[9].Value         = ics_extended_properties;
            paramArray[10]              = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.NVarChar);
            paramArray[10].Value        = idescriptions;
            paramArray[11]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[11].Value        = iuse_yn;
            paramArray[12]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[12].Value        = itxr_user;
            paramArray[13]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[13].Direction    = ParameterDirection.Output;
            paramArray[14]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[14].Direction    = ParameterDirection.Output;
            paramArray[15]              = CreateDataParameter("@oRTN_SOURCE_ID", SqlDbType.Int,4);
            paramArray[15].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_DATASOURCE", "pkg_BSC_INTERFACE_DATASOURCE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.ISource_Id             = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_SOURCE_ID").ToString());

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, int isource_id, string isource_name, string isource_type, string ics_initial_catalog, string ics_data_source, string ics_provider, string ics_user_id, string ics_password, string ics_connect_timeout, string ics_extended_properties, string idescriptions, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(17);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iSOURCE_ID", SqlDbType.Int);
            paramArray[1].Value         = isource_id;
			paramArray[2]               = CreateDataParameter("@iSOURCE_NAME", SqlDbType.NVarChar);
            paramArray[2].Value         = isource_name;
            paramArray[3]               = CreateDataParameter("@iSOURCE_TYPE", SqlDbType.NVarChar);
            paramArray[3].Value         = isource_type;
            paramArray[4]               = CreateDataParameter("@iCS_INITIAL_CATALOG", SqlDbType.NVarChar);
            paramArray[4].Value         = ics_initial_catalog;
            paramArray[5]               = CreateDataParameter("@iCS_DATA_SOURCE", SqlDbType.NVarChar);
            paramArray[5].Value         = ics_data_source;
            paramArray[6]               = CreateDataParameter("@iCS_PROVIDER", SqlDbType.NVarChar);
            paramArray[6].Value         = ics_provider;
            paramArray[7]               = CreateDataParameter("@iCS_USER_ID", SqlDbType.NVarChar);
            paramArray[7].Value         = ics_user_id;
            paramArray[8]               = CreateDataParameter("@iCS_PASSWORD", SqlDbType.NVarChar);
            paramArray[8].Value         = ics_password;
            paramArray[9]               = CreateDataParameter("@iCS_CONNECT_TIMEOUT", SqlDbType.NVarChar);
            paramArray[9].Value         = ics_connect_timeout;
            paramArray[10]              = CreateDataParameter("@iCS_EXTENDED_PROPERTIES", SqlDbType.NVarChar);
            paramArray[10].Value        = ics_extended_properties;
            paramArray[11]              = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.NVarChar);
            paramArray[11].Value        = idescriptions;
            paramArray[12]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[12].Value        = iuse_yn;
            paramArray[13]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[13].Value        = itxr_user;
            paramArray[14]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[14].Direction    = ParameterDirection.Output;
            paramArray[15]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[15].Direction    = ParameterDirection.Output;
            paramArray[16]              = CreateDataParameter("@oRTN_SOURCE_ID", SqlDbType.Int, 4);
            paramArray[16].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_DATASOURCE", "PKG_BSC_INTERFACE_DATASOURCE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.ISource_Id = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oRTN_SOURCE_ID").ToString());

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, int isource_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "D";
			paramArray[1]              = CreateDataParameter("@iSOURCE_ID", SqlDbType.Int);
            paramArray[1].Value        = isource_id;
            paramArray[2]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value        = itxr_user;
            paramArray[3]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction    = ParameterDirection.Output;
            paramArray[4]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[4].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_DATASOURCE", "PKG_BSC_INTERFACE_DATASOURCE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUseData_Dac
                (IDbConnection con, IDbTransaction trx, int isource_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "RD";
			paramArray[1]              = CreateDataParameter("@iSOURCE_ID", SqlDbType.Int);
            paramArray[1].Value        = isource_id;
            paramArray[2]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[2].Direction    = ParameterDirection.Output;
            paramArray[3]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[3].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_DATASOURCE", "PKG_BSC_INTERFACE_DATASOURCE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int isource_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]              = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value        = "SO";
			paramArray[1]              = CreateDataParameter("@iSOURCE_ID", SqlDbType.Int);
            paramArray[1].Value        = isource_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_DATASOURCE", "PKG_BSC_INTERFACE_DATASOURCE.PROC_SELECT_ONE"), "BSC_INTERFACE_DATASOURCE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList()
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(1);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_DATASOURCE", "PKG_BSC_INTERFACE_DATASOURCE.PROC_SELECT_ALL"), "BSC_INTERFACE_DATASOURCE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public int DeleteInterfaceData(IDbConnection conn
                                        , IDbTransaction trx
                                        , object dicode
                                        , object rdterm
                                        , object rddate
                                        , object input_type)
        {
            int affectedRow = 0;
            string queryValue = string.Empty;
            string query = @"DELETE FROM BSC_INTERFACE_DATA
WHERE   DICODE      = @DICODE
    AND RDTERM      = @RDTERM
    AND RDDATE      = @RDDATE
    AND INPUT_TYPE  = @INPUT_TYPE
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@DICODE", SqlDbType.VarChar);
            paramArray[0].Value = dicode;
            paramArray[1] = CreateDataParameter("@RDTERM", SqlDbType.VarChar);
            paramArray[1].Value = rdterm;
            paramArray[2] = CreateDataParameter("@RDDATE", SqlDbType.VarChar);
            paramArray[2].Value = rddate;
            paramArray[3] = CreateDataParameter("@INPUT_TYPE", SqlDbType.Int);
            paramArray[3].Value = input_type;

            
            try
            {
                affectedRow += DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetInterfacePreviewData(object strQuery
                                            , object ymd)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@C_YMD", SqlDbType.VarChar);
            paramArray[0].Value = ymd;

            DataSet ds = DbAgentObj.FillDataSet(strQuery.ToString(), "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetInterfaceData(object dicode
                                    , object rdterm
                                    , object input_type
                                    , object rddate)
        {
            string query = @"SELECT   *
                                FROM    BSC_INTERFACE_DATA      BID
                                WHERE   BID.DICODE      = @DICODE
                                    AND BID.RDTERM      = @RDTERM
                                    AND BID.INPUT_TYPE  = @INPUT_TYPE
                                    AND BID.RD_STATUS   = 1
                                    AND BID.RDDATE      = @RDDATE
                                ORDER BY BID.SEQUENCE
";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@DICODE", SqlDbType.VarChar);
            paramArray[0].Value = dicode;
            paramArray[1] = CreateDataParameter("@RDTERM", SqlDbType.VarChar);
            paramArray[1].Value = rdterm;
            paramArray[2] = CreateDataParameter("@INPUT_TYPE", SqlDbType.Int);
            paramArray[2].Value = input_type;
            paramArray[3] = CreateDataParameter("@RDDATE", SqlDbType.VarChar);
            paramArray[3].Value = rddate;

            DataSet ds = DbAgentObj.FillDataSet(query, "DATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public int InsertInterfaceData(IDbConnection conn
                                        , IDbTransaction trx
                                        , DataTable _dt)
        {
            int affectedRow = 0;
            string queryValue = string.Empty;
            string query = @"INSERT INTO BSC_INTERFACE_DATA (";
            for (int i = 0; i < _dt.Columns.Count; i++)
            {
                query += _dt.Columns[i].ColumnName + ",";
                queryValue += @"@" + _dt.Columns[i].ColumnName + ",";
            }

            query = query.Substring(0, query.Length - 1);
            query += ")";
            queryValue = queryValue.Substring(0, queryValue.Length - 1);

            query += string.Format(@" VALUES({0})", queryValue);

            IDbDataParameter[] paramArray;

            SqlDbType _type;

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                paramArray = CreateDataParameters(_dt.Columns.Count);
                for (int k = 0; k < _dt.Columns.Count; k++)
                {
                    if (_dt.Columns[k].DataType == typeof(string))
                        _type = SqlDbType.VarChar;
                    else if (_dt.Columns[k].DataType == typeof(int))
                        _type = SqlDbType.Int;
                    else if (_dt.Columns[k].DataType == typeof(double))
                        _type = SqlDbType.Decimal;
                    else if (_dt.Columns[k].DataType == typeof(DateTime))
                        _type = SqlDbType.DateTime;
                    else
                        _type = SqlDbType.Udt;
                    paramArray[k] = CreateDataParameter("@" + _dt.Columns[k].ColumnName, _type);
                }

                for (int j = 0; j < _dt.Columns.Count; j++)
                {
                    paramArray[j].Value = _dt.Rows[i][j];
                }

                try
                {
                    affectedRow += DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                    paramArray = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return affectedRow;
        }

		#endregion
	}
}