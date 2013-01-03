using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.PRJ.Dac
{
    /// <summary>
    /// Dac_Prj_Info
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Prj_Info
    /// Class Func     : PRJ_INFO Table Data Access
    /// CREATE DATE    : 2008-04-03 오전 11:06:54
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Prj_Info : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _iprj_ref_id;
        private String         _iprj_code;
        private String         _iprj_name;
        private decimal            _iapp_ref_id;
        private String         _idefinition;
        private String         _iref_stg;
        private String         _ieffectiveness;
        private String         _irange;
        private Int32          _iowner_dept_id;
        private Int32          _iowner_emp_id;
        private String         _iowner_dept_name;
        private String         _iowner_emp_name;
        private String         _irequest_dept;
        private String         _ipriority;
        private Decimal        _itotal_budget;
        private String         _iprj_type;
        private String         _iinterested_parties;
        private object          _iplan_start_date;
        private object          _iplan_end_date;
        private object          _iactual_start_date;
        private object          _iactual_end_date;
        private String          _isdelete;
        private String          _complete_yn;
        private Int32          _icreate_user;
        private DateTime       _icreate_date;
        private Int32          _iupdate_user;
        private DateTime       _iupdate_date;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public int IPrj_Ref_Id
        {
            get { return _iprj_ref_id; }
            set { _iprj_ref_id = value; }
        }
        public string IPrj_Code
        {
            get { return _iprj_code; }
            set { _iprj_code = value; }
        }
        public string IPrj_Name
        {
            get { return _iprj_name; }
            set { _iprj_name = value; }
        }
        public decimal IApp_Ref_Id
        {
            get { return _iapp_ref_id; }
            set { _iapp_ref_id = value; }
        }
        public string IDefinition
        {
            get { return _idefinition; }
            set { _idefinition = value; }
        }
        public string IRef_Stg
        {
            get { return _iref_stg; }
            set { _iref_stg = value; }
        }
        public string IEffectiveness
        {
            get { return _ieffectiveness; }
            set { _ieffectiveness = value; }
        }
        public string IRange
        {
            get { return _irange; }
            set { _irange = value; }
        }
        public int IOwner_Dept_Id
        {
            get { return _iowner_dept_id; }
            set { _iowner_dept_id = value; }
        }
        public int IOwner_Emp_Id
        {
            get { return _iowner_emp_id; }
            set { _iowner_emp_id = value; }
        }
        public string IOwner_Dept_Name
        {
            get { return _iowner_dept_name; }
            set { _iowner_dept_name = value; }
        }
        public string IOwner_Emp_Name
        {
            get { return _iowner_emp_name; }
            set { _iowner_emp_name = value; }
        }
        public string IRequest_Dept
        {
            get { return _irequest_dept; }
            set { _irequest_dept = value; }
        }
        public string IPriority
        {
            get { return _ipriority; }
            set { _ipriority = value; }
        }
        public decimal ITotal_Budget
        {
            get { return _itotal_budget; }
            set { _itotal_budget = value; }
        }
        public string IPrj_Type
        {
            get { return _iprj_type; }
            set { _iprj_type = value; }
        }
        public string IInterested_Parties
        {
            get { return _iinterested_parties; }
            set { _iinterested_parties = value; }
        }
        public object IPlan_Start_Date
        {
            get { return _iplan_start_date; }
            set { _iplan_start_date = value; }
        }
        public object IPlan_End_Date
        {
            get { return _iplan_end_date; }
            set { _iplan_end_date = value; }
        }
        public object IActual_Start_Date
        {
            get { return _iactual_start_date; }
            set { _iactual_start_date = value; }
        }
        public object IActual_End_Date
        {
            get { return _iactual_end_date; }
            set { _iactual_end_date = value; }
        }
        public string IIsDelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }
        public string IComplete_YN
        {
            get { return _complete_yn; }
            set { _complete_yn = value; }
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
		public Dac_Prj_Info() { }
        public Dac_Prj_Info(int iprj_ref_id)
        {
            DataSet ds = this.GetOneList( iprj_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iprj_ref_id                 = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _iprj_code                   = DataTypeUtility.GetValue(dr["PRJ_CODE"]);
                _iprj_name                   = DataTypeUtility.GetValue(dr["PRJ_NAME"]);
                _iapp_ref_id                 = DataTypeUtility.GetToDecimal(dr["APP_REF_ID"]);
                _idefinition                 = DataTypeUtility.GetValue(dr["DEFINITION"]);
                _iref_stg                    = DataTypeUtility.GetValue(dr["REF_STG"]);
                _ieffectiveness              = DataTypeUtility.GetValue(dr["EFFECTIVENESS"]);
                _irange                      = DataTypeUtility.GetValue(dr["RANGE"]);
                _iowner_dept_id              = DataTypeUtility.GetToInt32(dr["OWNER_DEPT_ID"]);
                _iowner_emp_id               = DataTypeUtility.GetToInt32(dr["OWNER_EMP_ID"]);
                _iowner_dept_name            = DataTypeUtility.GetValue(dr["OWNER_DEPT_NAME"]);
                _iowner_emp_name             = DataTypeUtility.GetValue(dr["OWNER_EMP_NAME"]);
                _irequest_dept               = DataTypeUtility.GetValue(dr["REQUEST_DEPT"]);
                _ipriority                   = DataTypeUtility.GetValue(dr["PRIORITY"]);
                _itotal_budget               = DataTypeUtility.GetToDecimal(dr["TOTAL_BUDGET"]);
                _iprj_type                   = DataTypeUtility.GetValue(dr["PRJ_TYPE"]);
                _iinterested_parties         = DataTypeUtility.GetValue(dr["INTERESTED_PARTIES"]);
                _iplan_start_date            = dr["PLAN_START_DATE"];
                _iplan_end_date              = dr["PLAN_END_DATE"];
                _iactual_start_date          = dr["ACTUAL_START_DATE"];
                _iactual_end_date            = dr["ACTUAL_END_DATE"];
                _isdelete                    = DataTypeUtility.GetValue(dr["ISDELETE"]);
                _complete_yn                 = DataTypeUtility.GetValue(dr["COMPLETE_YN"]);
                _icreate_user                = DataTypeUtility.GetToInt32(dr["CREATE_USER"]);
                _icreate_date                = DataTypeUtility.GetToDateTime(dr["CREATE_DATE"]);
                _iupdate_user                = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
                _iupdate_date                = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (string iprj_code
                , string iprj_name
                , decimal iapp_ref_id
                , string idefinition
                , string iref_stg
                , string ieffectiveness
                , string irange
                , int iowner_dept_id
                , int iowner_emp_id
                , string irequest_dept
                , string ipriority
                , decimal itotal_budget
                , string iprj_type
                , string iinterested_parties
                , object iplan_start_date
                , object iplan_end_date
                , object iactual_start_date
                , object iactual_end_date
                , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = iprj_code;
            paramArray[2]               = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = iprj_name;
            paramArray[3]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Decimal);
            paramArray[3].Value         = iapp_ref_id;
            paramArray[4]               = CreateDataParameter("@iDEFINITION", SqlDbType.VarChar);
            paramArray[4].Value         = idefinition;
            paramArray[5]               = CreateDataParameter("@iREF_STG", SqlDbType.VarChar);
            paramArray[5].Value         = iref_stg;
            paramArray[6]               = CreateDataParameter("@iEFFECTIVENESS", SqlDbType.VarChar);
            paramArray[6].Value         = ieffectiveness;
            paramArray[7]               = CreateDataParameter("@iRANGE", SqlDbType.VarChar);
            paramArray[7].Value         = irange;
            paramArray[8]               = CreateDataParameter("@iOWNER_DEPT_ID", SqlDbType.Int);
            paramArray[8].Value         = iowner_dept_id;
            paramArray[9]               = CreateDataParameter("@iOWNER_EMP_ID", SqlDbType.Int);
            paramArray[9].Value         = iowner_emp_id;
            paramArray[10]              = CreateDataParameter("@iREQUEST_DEPT", SqlDbType.VarChar);
            paramArray[10].Value        = irequest_dept;
            paramArray[11]              = CreateDataParameter("@iPRIORITY", SqlDbType.VarChar);
            paramArray[11].Value        = ipriority;
            paramArray[12]              = CreateDataParameter("@iTOTAL_BUDGET", SqlDbType.Decimal);
            paramArray[12].Value        = itotal_budget;
            paramArray[13]              = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[13].Value        = iprj_type;
            paramArray[14]              = CreateDataParameter("@iINTERESTED_PARTIES", SqlDbType.VarChar);
            paramArray[14].Value        = iinterested_parties;
            paramArray[15]              = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[15].Value        = iplan_start_date;
            paramArray[16]              = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[16].Value        = iplan_end_date;
            paramArray[17]              = CreateDataParameter("@iACTUAL_START_DATE", SqlDbType.DateTime);
            paramArray[17].Value        = (iactual_start_date == null) ? DBNull.Value : iactual_start_date;
            paramArray[18]              = CreateDataParameter("@iACTUAL_END_DATE", SqlDbType.DateTime);
            paramArray[18].Value        = (iactual_end_date == null) ? DBNull.Value : iactual_end_date;
            paramArray[19]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[19].Value        = itxr_user;
            paramArray[20]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[20].Direction    = ParameterDirection.Output;
            paramArray[21]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[21].Direction    = ParameterDirection.Output;
			paramArray[22]              = CreateDataParameter("@oRTN_PRJ_REF_ID", SqlDbType.Int);
            paramArray[22].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.IPrj_Ref_Id = Convert.ToInt32(GetOutputParameterValueBySP(col, "@oRTN_PRJ_REF_ID"));
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();
            
            return affectedRow;
        }
		
        internal protected int UpdateData_Dac
                (int iprj_ref_id, string iprj_code, string iprj_name, decimal iapp_ref_id, string idefinition, string iref_stg, string ieffectiveness, string irange, int iowner_dept_id, int iowner_emp_id, string irequest_dept, string ipriority, decimal itotal_budget, string iprj_type, string iinterested_parties, object iplan_start_date, object iplan_end_date, object iactual_start_date, object iactual_end_date, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(23);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value         = iprj_ref_id;
            paramArray[2]               = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[2].Value         = iprj_code;
            paramArray[3]               = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[3].Value         = iprj_name;
            paramArray[4]               = CreateDataParameter("@iAPP_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = iapp_ref_id;
            paramArray[5]               = CreateDataParameter("@iDEFINITION", SqlDbType.VarChar);
            paramArray[5].Value         = idefinition;
            paramArray[6]               = CreateDataParameter("@iREF_STG", SqlDbType.VarChar);
            paramArray[6].Value         = iref_stg;
            paramArray[7]               = CreateDataParameter("@iEFFECTIVENESS", SqlDbType.VarChar);
            paramArray[7].Value         = ieffectiveness;
            paramArray[8]               = CreateDataParameter("@iRANGE", SqlDbType.VarChar);
            paramArray[8].Value         = irange;
            paramArray[9]               = CreateDataParameter("@iOWNER_DEPT_ID", SqlDbType.Int);
            paramArray[9].Value         = iowner_dept_id;
            paramArray[10]              = CreateDataParameter("@iOWNER_EMP_ID", SqlDbType.Int);
            paramArray[10].Value        = iowner_emp_id;
            paramArray[11]              = CreateDataParameter("@iREQUEST_DEPT", SqlDbType.VarChar);
            paramArray[11].Value        = irequest_dept;
            paramArray[12]              = CreateDataParameter("@iPRIORITY", SqlDbType.VarChar);
            paramArray[12].Value        = ipriority;
            paramArray[13]              = CreateDataParameter("@iTOTAL_BUDGET", SqlDbType.Decimal);
            paramArray[13].Value        = itotal_budget;
            paramArray[14]              = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[14].Value        = iprj_type;
            paramArray[15]              = CreateDataParameter("@iINTERESTED_PARTIES", SqlDbType.VarChar);
            paramArray[15].Value        = iinterested_parties;
            paramArray[16]              = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[16].Value        = iplan_start_date;
            paramArray[17]              = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[17].Value        = iplan_end_date;
            paramArray[18]              = CreateDataParameter("@iACTUAL_START_DATE", SqlDbType.DateTime);
            paramArray[18].Value        = (iactual_start_date == null) ? DBNull.Value : iactual_start_date;
            paramArray[19]              = CreateDataParameter("@iACTUAL_END_DATE", SqlDbType.DateTime);
            paramArray[19].Value        = (iactual_end_date == null) ? DBNull.Value : iactual_end_date;
            paramArray[20]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[20].Value        = itxr_user;
            paramArray[21]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[21].Direction    = ParameterDirection.Output;
            paramArray[22]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[22].Direction    = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (int iprj_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iprj_ref_id;
            paramArray[2]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value         = itxr_user;
            paramArray[3]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[3].Direction     = ParameterDirection.Output;
            paramArray[4]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[4].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac
               (int iprj_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[2].Value = itxr_user;
            paramArray[3] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iprj_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_SELECT_ONE"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(  string iprj_code
                                    , string iprj_name
                                    , int iowner_dept_id
                                    , string iowner_emp_name
                                    , string iprj_type
                                    , object iplan_start_date
                                    , object iplan_end_date)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(8);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
            paramArray[1]               = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = iprj_code;
            paramArray[2]               = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = iprj_name;
            paramArray[3]               = CreateDataParameter("@iOWNER_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value         = iowner_dept_id;
            paramArray[4]               = CreateDataParameter("@iOWNER_EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = iowner_emp_name;
            paramArray[5]               = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[5].Value         = iprj_type;
            paramArray[6]               = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[6].Value         = iplan_start_date;
            paramArray[7]               = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value         = iplan_end_date;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_SELECT_ALL"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetList(string iprj_code
                                    , string iprj_name
                                    , int iowner_dept_id
                                    , string iowner_emp_name
                                    , int iowner_emp_id
                                    , string iprj_type
                                    , int iprj_year
                                   )
        {
            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SL";
            paramArray[1]       = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[1].Value = iprj_code;
            paramArray[2]       = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[2].Value = iprj_name;
            paramArray[3]       = CreateDataParameter("@iOWNER_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value = iowner_dept_id;
            paramArray[4]       = CreateDataParameter("@iOWNER_EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value = iowner_emp_name;
            paramArray[5]       = CreateDataParameter("@iOWNER_EMP_ID", SqlDbType.Int);
            paramArray[5].Value = iowner_emp_id;
            paramArray[6]       = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[6].Value = iprj_type;
            paramArray[7]       = CreateDataParameter("@iPRJ_YEAR", SqlDbType.VarChar);
            paramArray[7].Value = iprj_year;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_SELECT_LIST"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetList(string iprj_code
                                    , string iprj_name
                                    , int iowner_dept_id
                                    , string iowner_emp_name
                                    , int iowner_emp_id
                                    , string iprj_type
                                   )
        {
            return GetList(iprj_code, iprj_name, iowner_dept_id, iowner_emp_name, iowner_emp_id, iprj_type, DateTime.Now.Year);
        }

        public DataSet GetTotalStateList(string iprj_code
                                    , string iprj_name
                                    , int iowner_dept_id
                                    , string iowner_emp_name
                                    , string iprj_type
                                    , object iplan_start_date
                                    , object iplan_end_date
                                    , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "ST";
            paramArray[1] = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[1].Value = iprj_code;
            paramArray[2] = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[2].Value = iprj_name;
            paramArray[3] = CreateDataParameter("@iOWNER_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value = iowner_dept_id;
            paramArray[4] = CreateDataParameter("@iOWNER_EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value = iowner_emp_name;
            paramArray[5] = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = iprj_type;
            paramArray[6] = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[6].Value = iplan_start_date;
            paramArray[7] = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value = iplan_end_date;
            paramArray[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_SELECT_TOTAL"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetExcelDownList(string iprj_code
                                  , string iprj_name
                                  , int iowner_dept_id
                                  , string iowner_emp_name
                                  , string iprj_type
                                  , object iplan_start_date
                                  , object iplan_end_date
                                  , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "ED";
            paramArray[1] = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[1].Value = iprj_code;
            paramArray[2] = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[2].Value = iprj_name;
            paramArray[3] = CreateDataParameter("@iOWNER_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value = iowner_dept_id;
            paramArray[4] = CreateDataParameter("@iOWNER_EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value = iowner_emp_name;
            paramArray[5] = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = iprj_type;
            paramArray[6] = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[6].Value = iplan_start_date;
            paramArray[7] = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value = iplan_end_date;
            paramArray[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_EXECEL_DOWN"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetTotalFootInfo(string iprj_code
                                        , string iprj_name
                                        , string iprj_type)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "TF";
            paramArray[1] = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[1].Value = iprj_code;
            paramArray[2] = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[2].Value = iprj_name;
            paramArray[3] = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[3].Value = iprj_type;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_TOTAL_FOOT"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public bool Count(string iprj_code, string iprj_name)
        {
           
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.NVarChar,2);
            paramArray[0].Value = "CK";
            paramArray[1]       = CreateDataParameter("@iPRJ_CODE", SqlDbType.NVarChar,30);
            paramArray[1].Value = iprj_code;
            paramArray[2]       = CreateDataParameter("@iPRJ_NAME", SqlDbType.NVarChar,100);
            paramArray[2].Value = iprj_name;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_CHECK"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int intRtn = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                return (intRtn > 0) ? true : false;
            }
            else
            {
                return false;
            }

            //return Convert.ToInt32(DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_CHECK"), paramArray, CommandType.StoredProcedure));
        }

        protected bool IsOwnerEmpIDYN(int iemp_ref_id, int ipr_ref_id)
        {
            DataSet ds = null;
            bool isBool = false;
                
            ds = GetOneList(ipr_ref_id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (iemp_ref_id == DataTypeUtility.GetToInt32(ds.Tables[0].Rows[0]["OWNER_EMP_ID"]))
                    isBool = true;
            }
            return isBool;
        }

        internal protected int UpdateComplete_Dac
              (int iprj_ref_id, string icomplete_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "UC";
            paramArray[1]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Decimal);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2]       = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.VarChar);
            paramArray[2].Value = icomplete_yn;
            paramArray[3]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_UPDATE_COMPLETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetUserAllList(string iprj_code
                                  , string iprj_name
                                  , int iowner_dept_id
                                  , string iowner_emp_name
                                  , string iprj_type
                                  , object iplan_start_date
                                  , object iplan_end_date
                                  , int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "UA";
            paramArray[1] = CreateDataParameter("@iPRJ_CODE", SqlDbType.VarChar);
            paramArray[1].Value = iprj_code;
            paramArray[2] = CreateDataParameter("@iPRJ_NAME", SqlDbType.VarChar);
            paramArray[2].Value = iprj_name;
            paramArray[3] = CreateDataParameter("@iOWNER_DEPT_ID", SqlDbType.Int);
            paramArray[3].Value = iowner_dept_id;
            paramArray[4] = CreateDataParameter("@iOWNER_EMP_NAME", SqlDbType.VarChar);
            paramArray[4].Value = iowner_emp_name;
            paramArray[5] = CreateDataParameter("@iPRJ_TYPE", SqlDbType.VarChar);
            paramArray[5].Value = iprj_type;
            paramArray[6] = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[6].Value = iplan_start_date;
            paramArray[7] = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value = iplan_end_date;
            paramArray[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value = itxr_user;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_INFO", "PKG_PRJ_INFO.PROC_SELECT_USER_ALL"), "PRJ_INFO", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

		
		#endregion
	}
}