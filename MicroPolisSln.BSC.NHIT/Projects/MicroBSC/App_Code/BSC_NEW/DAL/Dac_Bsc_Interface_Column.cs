using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Interface_Column
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Interface_Column
    /// Class Func     : BSC_INTERFACE_COLUMN Table Data Access
    /// CREATE DATE    : 2008-07-18 오후 11:52:19
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Interface_Column : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private string         _idicode;
        private String         _icolumn_id;
        private String         _icolumn_alias;
        private String         _ilov_yn;
        private Int32          _isort_order;
        private Int32          _iunit_ref_id;
        private Int32          _idecimal_points;
        private Int32          _igrid_width;
        private String         _iuse_yn;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public string IDicode
        {
            get { return _idicode; }
            set { _idicode = value; }
        }
        public string IColumn_Id
        {
            get { return _icolumn_id; }
            set { _icolumn_id = value; }
        }
        public string IColumn_Alias
        {
            get { return _icolumn_alias; }
            set { _icolumn_alias = value; }
        }
        public string ILov_Yn
        {
            get { return _ilov_yn; }
            set { _ilov_yn = value; }
        }
        public int ISort_Order
        {
            get { return _isort_order; }
            set { _isort_order = value; }
        }
        public int IUnit_Ref_Id
        {
            get { return _iunit_ref_id; }
            set { _iunit_ref_id = value; }
        }
        public int IDecimal_Points
        {
            get { return _idecimal_points; }
            set { _idecimal_points = value; }
        }
        public int IGrid_Width
        {
            get { return _igrid_width; }
            set { _igrid_width = value; }
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
		public Dac_Bsc_Interface_Column() { }
        public Dac_Bsc_Interface_Column(string idicode, string icolumn_id, int itxr_user)
        {
            DataSet ds = this.GetOneList(idicode, icolumn_id, itxr_user);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_idicode                     = (dr["DICODE"]       == DBNull.Value) ? "" : Convert.ToString(dr["DICODE"]);
                _icolumn_id                  = (dr["COLUMN_ID"]    == DBNull.Value) ? "" : Convert.ToString(dr["COLUMN_ID"]);
                _icolumn_alias               = (dr["COLUMN_ALIAS"] == DBNull.Value) ? "" : Convert.ToString(dr["COLUMN_ALIAS"]);
                _ilov_yn                     = (dr["LOV_YN"]       == DBNull.Value) ? "" : Convert.ToString(dr["LOV_YN"]);
                _isort_order                 = (dr["SORT_ORDER"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
                _iunit_ref_id                = (dr["UNIT_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["UNIT_REF_ID"]);
                _idecimal_points             = (dr["DECIMAL_POINTS"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["DECIMAL_POINTS"]);
                _igrid_width                 = (dr["GRID_WIDTH"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["GRID_WIDTH"]);
                _iuse_yn                     = (dr["USE_YN"]       == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _icreate_user                = (dr["CREATE_USER"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date                = (dr["CREATE_DATE"]  == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"]  == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);;
			}
            else
            {
                _idicode         = "";
                _icolumn_id      = "";
                _icolumn_alias   = "";
                _ilov_yn         = "N";
                _isort_order     = 0;
                _iunit_ref_id    = 
                _idecimal_points = 0;
                _igrid_width     = 0;
                _iuse_yn         = "N";
                _icreate_user    = 0;
                _icreate_date    = DateTime.MinValue;
                _iupdate_user    = 0;
                _iupdate_date    = DateTime.MinValue;
            }
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (IDbConnection con, IDbTransaction trx, string idicode, string icolumn_id, string icolumn_alias, string ilov_yn, int isort_order, int iunit_ref_id, int idecimal_points, int igrid_width, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iCOLUMN_ID", SqlDbType.NVarChar);
            paramArray[2].Value         = icolumn_id;
            paramArray[3]               = CreateDataParameter("@iCOLUMN_ALIAS", SqlDbType.NVarChar);
            paramArray[3].Value         = icolumn_alias;
            paramArray[4]               = CreateDataParameter("@iLOV_YN", SqlDbType.Char);
            paramArray[4].Value         = ilov_yn;
            paramArray[5]               = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[5].Value         = isort_order;
            paramArray[6]               = CreateDataParameter("@iUNIT_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = iunit_ref_id;
            paramArray[7]               = CreateDataParameter("@iDECIMAL_POINTS", SqlDbType.Int);
            paramArray[7].Value         = idecimal_points;
            paramArray[8]               = CreateDataParameter("@iGRID_WIDTH", SqlDbType.Int);
            paramArray[8].Value         = igrid_width;
            paramArray[9]               = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[9].Value         = iuse_yn;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = itxr_user;
            paramArray[11]              = CreateDataParameter("@oRTN_MSG", SqlDbType.NVarChar,1000);
            paramArray[11].Direction    = ParameterDirection.Output;
            paramArray[12]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[12].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_COLUMN", "PKG_BSC_INTERFACE_COLUMN.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (IDbConnection con, IDbTransaction trx, string idicode, string icolumn_id, string icolumn_alias, string ilov_yn, int isort_order, int iunit_ref_id, int idecimal_points, int igrid_width, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(13);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iCOLUMN_ID", SqlDbType.NVarChar);
            paramArray[2].Value         = icolumn_id;
            paramArray[3]               = CreateDataParameter("@iCOLUMN_ALIAS", SqlDbType.NVarChar);
            paramArray[3].Value         = icolumn_alias;
            paramArray[4]               = CreateDataParameter("@iLOV_YN", SqlDbType.Char);
            paramArray[4].Value         = ilov_yn;
            paramArray[5]               = CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
            paramArray[5].Value         = isort_order;
            paramArray[6]               = CreateDataParameter("@iUNIT_REF_ID", SqlDbType.Int);
            paramArray[6].Value         = iunit_ref_id;
            paramArray[7]               = CreateDataParameter("@iDECIMAL_POINTS", SqlDbType.Int);
            paramArray[7].Value         = idecimal_points;
            paramArray[8]               = CreateDataParameter("@iGRID_WIDTH", SqlDbType.Int);
            paramArray[8].Value         = igrid_width;
            paramArray[9]               = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[9].Value         = iuse_yn;
            paramArray[10]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[10].Value        = itxr_user;
            paramArray[11]              = CreateDataParameter("@oRTN_MSG", SqlDbType.NVarChar,1000);
            paramArray[11].Direction    = ParameterDirection.Output;
            paramArray[12]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[12].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_COLUMN", "PKG_BSC_INTERFACE_COLUMN.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (IDbConnection con, IDbTransaction trx, string idicode, string icolumn_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iCOLUMN_ID", SqlDbType.NVarChar);
            paramArray[2].Value         = icolumn_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.NVarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(con, trx, GetQueryStringByDb("usp_BSC_INTERFACE_COLUMN", "PKG_BSC_INTERFACE_COLUMN.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetOneList(string idicode, string icolumn_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iCOLUMN_ID", SqlDbType.NVarChar);
            paramArray[2].Value         = icolumn_id;
            paramArray[3]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_COLUMN", "PKG_BSC_INTERFACE_COLUMN.PROC_SELECT_ONE"), "BSC_INTERFACE_COLUMN", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(string idicode, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1]               = CreateDataParameter("@iDICODE", SqlDbType.VarChar);
            paramArray[1].Value         = idicode;
            paramArray[2]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_INTERFACE_COLUMN", "PKG_BSC_INTERFACE_COLUMN.PROC_SELECT_ALL"), "BSC_INTERFACE_COLUMN", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion
	}
}