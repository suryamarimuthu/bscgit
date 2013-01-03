using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Interface_Dicode
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Interface_Dicode
    /// Class Func     : BSC_INTERFACE_DICODE Table Data Access
    /// CREATE DATE    : 2008-07-18 오후 11:30:25
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Interface_Dicode : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private string         _idicode;
        private String         _iname;
        private Int32          _isource_id;
        private String         _iinput_type;
        private String         _idefinition;
        private String         _iuse_yn;
        private String         _iquery;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        private String         _dailykpi_yn;
        #endregion
		
		#region ============================== [Properties] ==============================
		public string IDicode
        {
            get { return _idicode; }
            set { _idicode = value; }
        }
        public string IName
        {
            get { return _iname; }
            set { _iname = value; }
        }
        public int ISource_Id
        {
            get { return _isource_id; }
            set { _isource_id = value; }
        }
        public string IInput_Type
        {
            get { return _iinput_type; }
            set { _iinput_type = value; }
        }
        public string IDefinition
        {
            get { return _idefinition; }
            set { _idefinition = value; }
        }
        public string IUse_Yn
        {
            get { return _iuse_yn; }
            set { _iuse_yn = value; }
        }
        public string IQuery
        {
            get { return _iquery; }
            set { _iquery = value; }
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
        public string IDailyKpi_YN
        {
            get { return _dailykpi_yn; }
            set { _dailykpi_yn = value; }
        }
        #endregion
		
		#region ============================== [Constructor] ==============================
		public Dac_Bsc_Interface_Dicode() { }
        public Dac_Bsc_Interface_Dicode(string idicode, int itxr_user)
        {
            DataSet ds = this.GetOneList( idicode, itxr_user);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_idicode                     = (dr["DICODE"]      == DBNull.Value) ? "" : Convert.ToString(dr["DICODE"]);
                _iname                       = (dr["NAME"]        == DBNull.Value) ? "" : Convert.ToString(dr["NAME"]);
                _isource_id                  = (dr["SOURCE_ID"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["SOURCE_ID"]);
                _iinput_type                 = (dr["INPUT_TYPE"]  == DBNull.Value) ? "" : Convert.ToString(dr["INPUT_TYPE"]);
                _idefinition                 = (dr["DEFINITION"]  == DBNull.Value) ? "" : Convert.ToString(dr["DEFINITION"]);
                _iuse_yn                     = (dr["USE_YN"]      == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _iquery                      = (dr["QUERY"]       == DBNull.Value) ? "" : Convert.ToString(dr["QUERY"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
                _dailykpi_yn                 = (dr["DAILYKPI_YN"] == DBNull.Value) ? "N" : Convert.ToString(dr["DAILYKPI_YN"]);
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx, string idicode, string iname, int isource_id, string iinput_type, string idefinition, string iuse_yn, string iquery, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iNAME", SqlDbType.NVarChar);
            paramArray[2].Value         = iname;
            paramArray[3]               = CreateDataParameter("@iSOURCE_ID", SqlDbType.Int);
            paramArray[3].Value         = isource_id;
            paramArray[4]               = CreateDataParameter("@iINPUT_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = iinput_type;
            paramArray[5]               = CreateDataParameter("@iDEFINITION", SqlDbType.NVarChar);
            paramArray[5].Value         = idefinition;
            paramArray[6]               = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[6].Value         = iuse_yn;
            paramArray[7]               = CreateDataParameter("@iQUERY", SqlDbType.NText);
            paramArray[7].Value         = iquery;
            paramArray[8]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value         = itxr_user;
            paramArray[9]               = CreateDataParameter("@oRTN_MSG", SqlDbType.NVarChar,1000);
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[10].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_DICODE", "PKG_BSC_INTERFACE_DICODE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, string idicode, string iname, int isource_id, string iinput_type, string idefinition, string iuse_yn, string iquery, int itxr_user, string idailykpi_yn)
        {
            string strQuery = @"
IF EXISTS (SELECT * FROM BSC_INTERFACE_DICODE WHERE DICODE = @iDICODE)
    BEGIN
        UPDATE BSC_INTERFACE_DICODE
           SET NAME                   = @iNAME
              ,SOURCE_ID              = @iSOURCE_ID
              ,INPUT_TYPE             = @iINPUT_TYPE
              ,DEFINITION             = @iDEFINITION
              ,USE_YN                 = @iUSE_YN
              ,QUERY                  = @iQUERY
              ,UPDATE_USER            = @iTXR_USER
              ,UPDATE_DATE            = GETDATE()
              ,DAILYKPI_YN            = @iDAILYKPI_YN
         WHERE DICODE = @iDICODE
    END
ELSE
    BEGIN
        INSERT INTO BSC_INTERFACE_DICODE
        (
            DICODE
           ,NAME
           ,SOURCE_ID
           ,INPUT_TYPE
           ,DEFINITION
           ,USE_YN
           ,QUERY
           ,CREATE_USER
           ,CREATE_DATE
           ,UPDATE_USER
           ,UPDATE_DATE
           ,DAILYKPI_YN
        )
        VALUES
        (
            @iDICODE
           ,@iNAME
           ,@iSOURCE_ID
           ,@iINPUT_TYPE
           ,@iDEFINITION
           ,@iUSE_YN
           ,@iQUERY
           ,@iTXR_USER
           ,GETDATE()
           ,@iTXR_USER
           ,GETDATE()
           ,@iDAILYKPI_YN
        )
    END
";
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            //paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            //paramArray[0].Value         = "U";
			paramArray[0]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[0].Value         = idicode;
            paramArray[1] = CreateDataParameter("@iNAME", SqlDbType.NVarChar);
            paramArray[1].Value = iname;
            paramArray[2] = CreateDataParameter("@iSOURCE_ID", SqlDbType.Int);
            paramArray[2].Value = isource_id;
            paramArray[3] = CreateDataParameter("@iINPUT_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = iinput_type;
            paramArray[4] = CreateDataParameter("@iDEFINITION", SqlDbType.NVarChar);
            paramArray[4].Value = idefinition;
            paramArray[5] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[5].Value = iuse_yn;
            paramArray[6] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value = itxr_user;
            paramArray[7] = CreateDataParameter("@iQUERY", SqlDbType.NText);
            paramArray[7].Value = iquery;
            paramArray[8] = CreateDataParameter("@iDAILYKPI_YN", SqlDbType.VarChar);
            paramArray[8].Value = idailykpi_yn;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, strQuery, paramArray, CommandType.Text);
            if (affectedRow > 0)
            {
                this.Transaction_Message = "Success!";
                this.Transaction_Result = "Y";
            }
            else
            {
                this.Transaction_Message = "Fail!";
                this.Transaction_Result = "N";
            }

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, string idicode, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value         = itxr_user;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.NVarChar,1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[4].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_DICODE", "PKG_BSC_INTERFACE_DICODE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetOneList(string idicode, int itxr_user)
        {
            string strQuery = @"
SELECT DI.DICODE
   ,DI.NAME
   ,DI.SOURCE_ID
   ,DS.SOURCE_NAME
   ,DI.INPUT_TYPE
   ,DI.DEFINITION
   ,DI.USE_YN
   ,DI.QUERY
   ,DI.CREATE_USER
   ,DI.CREATE_DATE
   ,DI.UPDATE_USER
   ,DI.UPDATE_DATE 
   ,DI.DAILYKPI_YN
FROM BSC_INTERFACE_DICODE DI
    LEFT JOIN BSC_INTERFACE_DATASOURCE DS
      ON DI.SOURCE_ID = DS.SOURCE_ID
WHERE DI.DICODE = @iDICODE
";
            IDbDataParameter[] paramArray = CreateDataParameters(1);
            //paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            //paramArray[0].Value         = "SO";


			paramArray[0]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[0].Value         = idicode;
            //paramArray[1]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            //paramArray[1].Value         = itxr_user;

            //DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_DICODE", "PKG_BSC_INTERFACE_DICODE.PROC_SELECT_ONE"), "BSC_INTERFACE_DICODE", null, paramArray, CommandType.StoredProcedure);
            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_INTERFACE_DICODE", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetAllList(string idicode, string iname, int itxr_user)
        {
            return this.GetAllList(idicode, iname, "", itxr_user);
        }

        public DataSet GetAllList(string idicode, string iname, string iInput_type, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(5);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
			paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iNAME", SqlDbType.NVarChar);
            paramArray[2].Value         = iname;
            paramArray[3]               = CreateDataParameter("@iINPUT_TYPE", SqlDbType.NVarChar);
            paramArray[3].Value         = iname;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_DICODE", "PKG_BSC_INTERFACE_DICODE.PROC_SELECT_ALL"), "BSC_INTERFACE_DICODE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataTable GetDiCodeUseYNDailyKpiYN(object use_yn, object dailykpi_yn)
        {
            string strQuery = @"
SELECT   DICODE
        ,NAME
        ,SOURCE_ID
        ,INPUT_TYPE
        ,DEFINITION
        ,USE_YN
        ,QUERY
        ,DAILYKPI_YN
FROM    BSC_INTERFACE_DICODE
WHERE   (USE_YN         = @USE_YN       OR @USE_YN      =''    )
    AND (DAILYKPI_YN    = @DAILYKPI_YN  OR @DAILYKPI_YN =''    )
ORDER BY DICODE
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[0].Value = use_yn;
            paramArray[1] = CreateDataParameter("@DAILYKPI_YN", SqlDbType.VarChar);
            paramArray[1].Value = dailykpi_yn;

            return DbAgentObj.FillDataSet(strQuery, "BSC_INTERFACE_DICODE", null, paramArray, CommandType.Text).Tables[0];
        }
		#endregion
	}
}