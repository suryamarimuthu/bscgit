using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common.Dac
{
    public class Dac_ComDeptInfo : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	_idept_ref_id;
        private int 	_iup_dept_id;
        private int 	_idept_level;
        private string 	_idept_name;
        private string _iup_dept_name;
        private string 	_idept_code;
        private bool 	_idept_flag;
        private int 	_idept_type;
        private int 	_isort_order;
        private string 	 _idept_desc;
        private int 	 _create_user;
        private DateTime _create_date;
        private int 	 _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result; // 처리결과여부(Y,N)
        #endregion
         
        #region ============================== [Properties] ==============================
         
        public int Idept_ref_id
        {
	        get 
	        {
		        return _idept_ref_id;
	        }
	        set
	        {
		        _idept_ref_id = value;
	        }
        }
         
        public int Iup_dept_id
        {
	        get 
	        {
		        return _iup_dept_id;
	        }
	        set
	        {
		        _iup_dept_id = value;
	        }
        }
         
        public int Idept_level
        {
	        get 
	        {
		        return _idept_level;
	        }
	        set
	        {
		        _idept_level = value;
	        }
        }
         
        public string Idept_name
        {
	        get 
	        {
		        return _idept_name;
	        }
	        set
	        {
		        _idept_name = ( value==null ? "" : value );
	        }
        }

        public string Iup_dept_name
        {
            get
            {
                return _iup_dept_name;
            }
            set
            {
                _iup_dept_name = (value == null ? "" : value);
            }
        }
         
        public string Idept_code
        {
	        get 
	        {
		        return _idept_code;
	        }
	        set
	        {
		        _idept_code = ( value==null ? "" : value );
	        }
        }
         
        public bool Idept_flag
        {
	        get 
	        {
		        return _idept_flag;
	        }
	        set
	        {
		        _idept_flag = value;
	        }
        }
         
        public int Idept_type
        {
	        get 
	        {
		        return _idept_type;
	        }
	        set
	        {
		        _idept_type = value;
	        }
        }
         
        public int Isort_order
        {
	        get 
	        {
		        return _isort_order;
	        }
	        set
	        {
		        _isort_order = value;
	        }
        }
         
        public string Idept_desc
        {
	        get 
	        {
		        return _idept_desc;
	        }
	        set
	        {
		        _idept_desc = ( value==null ? "" : value );
	        }
        }
        
        public int Create_user
        {
	        get 
	        {
		        return _create_user;
	        }
	        set
	        {
		        _create_user = value;
	        }
        }
         
        public DateTime Create_date
        {
	        get 
	        {
		        return _create_date;
	        }
	        set
	        {
		        _create_date = value;
	        }
        }
         
        public int Update_user
        {
	        get 
	        {
		        return _update_user;
	        }
	        set
	        {
		        _update_user = value;
	        }
        }
         
        public DateTime Update_date
        {
	        get 
	        {
		        return _update_date;
	        }
	        set
	        {
		        _update_date = value;
	        }
        }

        public String Transaction_Message
        {
            get
            {
                return _txr_message;
            }
            set
            {
                _txr_message = value;
            }
        }

        public String Transaction_Result
        {
            get
            {
                return _txr_result;
            }
            set
            {
                _txr_result = value;
            }
        }

        #endregion
         
        #region ============================== [Constructor] ==============================
        public Dac_ComDeptInfo() { }
        public Dac_ComDeptInfo(int idept_ref_id)
        {
            DataSet ds = this.GetOneList_Dac(idept_ref_id);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr = ds.Tables[0].Rows[0];
		        _idept_ref_id = (dr["DEPT_REF_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
		        _iup_dept_id  = (dr["UP_DEPT_ID"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["UP_DEPT_ID"]);
		        _idept_level  = (dr["DEPT_LEVEL"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_LEVEL"]);
		        _idept_name   = (dr["DEPT_NAME"]    == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_NAME"]);
                _iup_dept_name= (dr["UP_DEPT_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["UP_DEPT_NAME"]);
		        _idept_code   = (dr["DEPT_CODE"]    == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_CODE"]);
		        _idept_flag   = (dr["DEPT_FLAG"]    == DBNull.Value) ? false : Convert.ToBoolean(dr["DEPT_FLAG"]);
		        _idept_type   = (dr["DEPT_TYPE"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_TYPE"]);
		        _isort_order  = (dr["SORT_ORDER"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["SORT_ORDER"]);
		        _idept_desc   = (dr["DEPT_DESC"]    == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_DESC"]);
		        _create_user  = (dr["CREATE_USER"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
		        _create_date  = (dr["CREATE_DATE"]  == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
		        _update_user  = (dr["UPDATE_USER"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
		        _update_date  = (dr["UPDATE_DATE"]  == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
	        }
        }
        #endregion

        #region ============================== [Method] ==============================

        internal protected int InsertData_Dac( int iup_dept_id, int idept_level, string idept_name, string idept_code, int idept_flag, int idept_type, int isort_order, string idept_desc, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	= "A";
	        paramArray[1] 		= CreateDataParameter("@iUP_DEPT_ID", SqlDbType.Int);
	        paramArray[1].Value 	= iup_dept_id;
	        paramArray[2] 		= CreateDataParameter("@iDEPT_LEVEL", SqlDbType.Int);
	        paramArray[2].Value 	= idept_level;
	        paramArray[3] 		= CreateDataParameter("@iDEPT_NAME", SqlDbType.VarChar);
	        paramArray[3].Value 	= idept_name;
	        paramArray[4] 		= CreateDataParameter("@iDEPT_CODE", SqlDbType.VarChar);
	        paramArray[4].Value 	= idept_code;
	        paramArray[5] 		= CreateDataParameter("@iDEPT_FLAG", SqlDbType.Int);
	        paramArray[5].Value 	= idept_flag;
	        paramArray[6] 		= CreateDataParameter("@iDEPT_TYPE", SqlDbType.Int);
	        paramArray[6].Value 	= idept_type;
	        paramArray[7] 		= CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[7].Value 	= isort_order;
	        paramArray[8] 		= CreateDataParameter("@iDEPT_DESC", SqlDbType.VarChar);
	        paramArray[8].Value 	= idept_desc;
	        paramArray[9] 		= CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value 	= itxr_user;
	        paramArray[10] 		= CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		= CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
            paramArray[12] = CreateDataParameter("@oDEPT_REF_ID", SqlDbType.Int);
            paramArray[12].Direction = ParameterDirection.Output;
         
	        IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.Idept_ref_id = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col, "@oDEPT_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac( int idept_ref_id, int iup_dept_id, int idept_level, string idept_name, string idept_code, int idept_flag, int idept_type, int isort_order, string idept_desc, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		= CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	= "U";
	        paramArray[1] 		= CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	= idept_ref_id;
	        paramArray[2] 		= CreateDataParameter("@iUP_DEPT_ID", SqlDbType.Int);
	        paramArray[2].Value 	= iup_dept_id;
	        paramArray[3] 		= CreateDataParameter("@iDEPT_LEVEL", SqlDbType.Int);
	        paramArray[3].Value 	= idept_level;
	        paramArray[4] 		= CreateDataParameter("@iDEPT_NAME", SqlDbType.VarChar);
	        paramArray[4].Value 	= idept_name;
	        paramArray[5] 		= CreateDataParameter("@iDEPT_CODE", SqlDbType.VarChar);
	        paramArray[5].Value 	= idept_code;
	        paramArray[6] 		= CreateDataParameter("@iDEPT_FLAG", SqlDbType.Int);
	        paramArray[6].Value 	= idept_flag;
	        paramArray[7] 		= CreateDataParameter("@iDEPT_TYPE", SqlDbType.VarChar);
	        paramArray[7].Value 	= idept_type;
	        paramArray[8] 		= CreateDataParameter("@iSORT_ORDER", SqlDbType.Int);
	        paramArray[8].Value 	= isort_order;
	        paramArray[9] 		= CreateDataParameter("@iDEPT_DESC", SqlDbType.VarChar);
	        paramArray[9].Value 	= idept_desc;
	        paramArray[10] 		= CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[10].Value 	= itxr_user;
	        paramArray[11] 		= CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
	        paramArray[12] 		= CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char, 1);
	        paramArray[12].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int idept_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = idept_ref_id;
            paramArray[2] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value = itxr_user;
            paramArray[3] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeptShift_Dac(int idept_ref_id, int iup_dept_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "DT";
            paramArray[1] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = idept_ref_id;
            paramArray[2] = CreateDataParameter("@iUP_DEPT_ID", SqlDbType.Int);
            paramArray[2].Value = iup_dept_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@iRTN_MSG", SqlDbType.VarChar);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@iRTN_COMPLETE_YN", SqlDbType.Char);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;
            int affectedRow          = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_DEPT_TRANSFER"), paramArray, CommandType.StoredProcedure, out col);
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result  = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected DataSet GetAllList_Dac()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_SELECT_ALL"), "COM_DEPT_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetOneList_Dac(int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1]       = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[1].Value = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_SELECT_ONE"), "COM_DEPT_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetComDeptByTree_Dac()
        {
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "ST";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_SELECT_TREE"), "COM_DEPT_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetDeptMappingByTree_Dac(int iest_term_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SM";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iest_term_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_SELECT_MAPPING_TREE"), "COM_DEPT_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetDeptOrgStatusByTree_Dac(int iest_term_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SS";
            paramArray[1]       = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iest_term_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_SELECT_ORGSTATUS"), "COM_DEPT_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        internal protected DataSet GetComDeptOrgAuthorityByTree_Dac(int iLoginUser)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SH";
            paramArray[1]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[1].Value = iLoginUser;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_COM_DEPT_INFO", "PKG_COM_DEPT_INFO.PROC_SELECT_ORGAUTH"), "COM_DEPT_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        #endregion
    }
}
