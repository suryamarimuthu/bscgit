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

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Mbo_Kpi_Weight
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Bsc_Mbo_Kpi_Weight
    /// Class Func     : BSC_MBO_KPI_WEIGHT Table Data Access
    /// CREATE DATE    : 2008-04-18 오후 1:10:39
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Bsc_Mbo_Kpi_Weight : DbAgentBase
    {
        #region ============================== [Fields] ==============================
		private int            _iestterm_ref_id;
        private Int32          _iemp_ref_id;
        private Int32          _ikpi_ref_id;
        private Decimal        _iweight;
        private String         _iuse_yn;
        private DateTime       _icreate_date;
        private Int32          _icreate_user;
        private DateTime       _iupdate_date;
        private Int32          _iupdate_user;
        private Int32          _itxr_user;
        private String         _txr_message;
        private String         _txr_result;
        #endregion
		
		#region ============================== [Properties] ==============================
		public int IEstterm_Ref_Id
        {
            get { return _iestterm_ref_id; }
            set { _iestterm_ref_id = value; }
        }
        public int IEmp_Ref_Id
        {
            get { return _iemp_ref_id; }
            set { _iemp_ref_id = value; }
        }
        public int IKpi_Ref_Id
        {
            get { return _ikpi_ref_id; }
            set { _ikpi_ref_id = value; }
        }
        public decimal IWeight
        {
            get { return _iweight; }
            set { _iweight = value; }
        }
        public string IUse_Yn
        {
            get { return _iuse_yn; }
            set { _iuse_yn = value; }
        }
        public System.DateTime ICreate_Date
        {
            get { return _icreate_date; }
            set { _icreate_date = value; }
        }
        public int ICreate_User
        {
            get { return _icreate_user; }
            set { _icreate_user = value; }
        }
        public System.DateTime IUpdate_Date
        {
            get { return _iupdate_date; }
            set { _iupdate_date = value; }
        }
        public int IUpdate_User
        {
            get { return _iupdate_user; }
            set { _iupdate_user = value; }
        }
        public int Itxr_user
        {
            get { return _itxr_user; }
            set { _itxr_user = value; }
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
		public Dac_Bsc_Mbo_Kpi_Weight() { }
        public Dac_Bsc_Mbo_Kpi_Weight(int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id)
        {
            DataSet ds = this.GetOneList( iestterm_ref_id,  iemp_ref_id,  ikpi_ref_id);
            DataRow dr; 

            if (ds.Tables[0].Rows.Count > 0)
            {
				dr = ds.Tables[0].Rows[0];
				_iestterm_ref_id             = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iemp_ref_id                 = (dr["EMP_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EMP_REF_ID"]);
                _ikpi_ref_id                 = (dr["KPI_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
                _iweight                     = (dr["WEIGHT"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["WEIGHT"]);
                _iuse_yn                     = (dr["USE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _icreate_date                = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _icreate_user                = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _iupdate_date                = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
                _iupdate_user                = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);;
			}
		}
		#endregion
		
		#region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id, decimal iweight, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
            paramArray[4].Value         = iweight;
            paramArray[5]               = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[5].Value         = iuse_yn;
            paramArray[6]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value         = itxr_user;
            paramArray[7]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[7].Direction     = ParameterDirection.Output;
            paramArray[8]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[8].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public bool UpdateMBOWeight(IDbConnection idc, IDbTransaction idt, int emp_ref_id, DataTable dt)
        {
            string strQuery = @"
SELECT  COUNT(ESTTERM_REF_ID) 
FROM    BSC_MBO_KPI_CLASSIFICATION 
WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID 
    AND EMP_REF_ID = @EMP_REF_ID 
    AND (KPI_REF_ID = @KPI_REF_ID   OR  ORG_KPI_REF_ID  = @KPI_REF_ID)
";
            string strQuery2 = @"
INSERT INTO BSC_MBO_KPI_CLASSIFICATION
    (ESTTERM_REF_ID,        EMP_REF_ID,     KPI_REF_ID,     ORG_KPI_REF_ID,     KPI_CLASS_REF_ID,       CREATE_DATE,    CREATE_USER)
VALUES
    (@ESTTERM_REF_ID,       @EMP_REF_ID,    @KPI_REF_ID,    @KPI_REF_ID,        @KPI_CLASS_REF_ID,                  GETDATE(),      @EMP_REF_ID)
";

            IDbDataParameter[] paramArray;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                paramArray = null;
                paramArray = CreateDataParameters(9);

                paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
                paramArray[0].Value = "U";
                paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1].Value = dr["ESTTERM_REF_ID"];
                paramArray[2] = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
                paramArray[2].Value = emp_ref_id;
                paramArray[3] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
                paramArray[3].Value = dr["KPI_REF_ID"];
                paramArray[4] = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
                paramArray[4].Value = dr["WEIGHT"];
                paramArray[5] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
                paramArray[5].Value = "Y";
                paramArray[6] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
                paramArray[6].Value = emp_ref_id;
                paramArray[7] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
                paramArray[7].Direction = ParameterDirection.Output;
                paramArray[8] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
                paramArray[8].Direction = ParameterDirection.Output;

                IDataParameterCollection col;

                int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

                this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
                this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

                if (affectedRow < 1 || this.Transaction_Result != "Y")
                    return false;

                // BSC_MBO_KPI_CLASSIFICATION 저장(MBO관리 신규 : 2011.09월 허성덕, 박효동 작업)
                //일상업무, 전략업무가 아닌 전략공통이면 입력

                paramArray = null;
                paramArray = CreateDataParameters(3);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[0].Value = dr["ESTTERM_REF_ID"];
                paramArray[1].Value = emp_ref_id;
                paramArray[2].Value = dr["KPI_REF_ID"];

                int cntClass = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(idc, idt, strQuery, paramArray, CommandType.Text));
                if (cntClass == 0)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(4);
                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[3] = CreateDataParameter("@KPI_CLASS_REF_ID", SqlDbType.VarChar);
                    
                    paramArray[0].Value = dr["ESTTERM_REF_ID"];
                    paramArray[1].Value = emp_ref_id;
                    paramArray[2].Value = dr["KPI_REF_ID"];
                    paramArray[3].Value = dr["KPI_CLASS_REF_ID"];

                    cntClass = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery2, paramArray, CommandType.Text);

                    if (cntClass < 1)
                        return false;
                }
            }

            return true;
        }

        public bool DeleteMBOWeight(IDbConnection idc, IDbTransaction idt, DataTable dt, int emp_ref_id)
        {
            string strQuery = @"
SELECT  COUNT(ESTTERM_REF_ID) 
FROM    BSC_MBO_KPI_CLASSIFICATION 
WHERE   ESTTERM_REF_ID      = @ESTTERM_REF_ID 
    AND EMP_REF_ID          = @EMP_REF_ID 
    AND KPI_REF_ID          = @KPI_REF_ID   
    AND ORG_KPI_REF_ID      = @KPI_REF_ID
    AND KPI_CLASS_REF_ID    IN ('SCO', 'PCO')
";
            string strQuery2 = @"
DELETE FROM BSC_MBO_KPI_CLASSIFICATION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND EMP_REF_ID      = @EMP_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID
    AND ORG_KPI_REF_ID  = @KPI_REF_ID
    AND KPI_CLASS_REF_ID    IN ('SCO', 'PCO')
";

            IDbDataParameter[] paramArray;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                paramArray = null;
                paramArray = CreateDataParameters(7);

                paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
                paramArray[0].Value = "D";
                paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1].Value = dr["ESTTERM_REF_ID"];
                paramArray[2] = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
                paramArray[2].Value = dr["EMP_REF_ID"];
                paramArray[3] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
                paramArray[3].Value = dr["KPI_REF_ID"];
                paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
                paramArray[4].Value = emp_ref_id;
                paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
                paramArray[5].Direction = ParameterDirection.Output;
                paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
                paramArray[6].Direction = ParameterDirection.Output;

                IDataParameterCollection col;

                int affectedRow = DbAgentObj.ExecuteNonQuery(idc, idt, GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

                this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
                this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

                //if (affectedRow < 1 || this.Transaction_Result != "Y")
                //    return false;

                if (affectedRow < 1 || this.Transaction_Result == "N")
                    return false;

                // BSC_MBO_KPI_CLASSIFICATION 저장(MBO관리 신규 : 2011.09월 허성덕, 박효동 작업)
                //일상업무, 전략업무가 아닌 전략공통이면 입력

                paramArray = null;
                paramArray = CreateDataParameters(3);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[0].Value = dr["ESTTERM_REF_ID"];
                paramArray[1].Value = dr["EMP_REF_ID"];
                paramArray[2].Value = dr["KPI_REF_ID"];

                int cntClass = DataTypeUtility.GetToInt32(DbAgentObj.ExecuteScalar(strQuery, paramArray, CommandType.Text));
                if (cntClass > 0)
                {
                    paramArray = null;
                    paramArray = CreateDataParameters(3);
                    paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                    paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
                    paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                    paramArray[0].Value = dr["ESTTERM_REF_ID"];
                    paramArray[1].Value = dr["EMP_REF_ID"];
                    paramArray[2].Value = dr["KPI_REF_ID"];

                    cntClass = DbAgentObj.ExecuteNonQuery(idc, idt, strQuery2, paramArray, CommandType.Text);

                    if (cntClass < 1)
                        return false;
                }
            }

            return true;
        }

        internal protected int UpdateData_Dac
                (int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id, decimal iweight, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@iWEIGHT", SqlDbType.Decimal);
            paramArray[4].Value         = iweight;
            paramArray[5]               = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[5].Value         = iuse_yn;
            paramArray[6]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value         = itxr_user;
            paramArray[7]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[7].Direction     = ParameterDirection.Output;
            paramArray[8]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[8].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        internal protected int DeleteData_Dac
                (int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;
			
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }
		
        public DataSet GetOneList(int iestterm_ref_id, int iemp_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
			paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_SELECT_ONE"), "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		
        public DataSet GetAllList(int iestterm_ref_id, int iemp_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(3);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "SA";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_SELECT_ALL"), "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMyKpiList(int iestterm_ref_id, int iemp_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, string ikpi_group_ref_id, int iest_dept_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(10);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "MK";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;
            paramArray[3]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = iresult_input_type;
            paramArray[4]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_code;
            paramArray[5]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ikpi_name;
            paramArray[6]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[6].Value         = iuse_yn;
            paramArray[7]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[7].Value         = ichampion_name;
            paramArray[8]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[8].Value         = ikpi_group_ref_id;
            paramArray[9]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.VarChar);
            paramArray[9].Value         = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_SELECT_MY_KPI"), "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiListExceptMyKpi(int iestterm_ref_id, int iemp_ref_id, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, int iest_dept_ref_id, string ikpi_group_ref_id, string iis_team_kpi, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(12);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "KT";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;
            paramArray[3]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[3].Value         = iresult_input_type;
            paramArray[4]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[4].Value         = ikpi_code;
            paramArray[5]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[5].Value         = ikpi_name;
            paramArray[6]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[6].Value         = iuse_yn;
            paramArray[7]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[7].Value         = ichampion_name;
            paramArray[8]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[8].Value         = iest_dept_ref_id;
            paramArray[9]               = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[9].Value         = ikpi_group_ref_id;
            paramArray[10]              = CreateDataParameter("@iIS_TEAM_KPI", SqlDbType.VarChar);
            paramArray[10].Value        = iis_team_kpi;
            paramArray[11]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[11].Value        = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_SELECT_KPI_TARGET"), "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMboListForWeight(int estterm_ref_id
                                        , string gubun
                                        , string kpi_code
                                        , string kpi_name
                                        , int emp_ref_id
                                        , int com_dept_ref_id)
        {
            string addQuery = string.Empty;
            if (gubun == "N") //나의지표(일상업무)
                addQuery = @"
    AND A.IS_TEAM_KPI       = 'N'
    AND A.CHAMPION_EMP_ID   = @EMP_REF_ID
";
            else if (gubun == "Y") //팀지표(전략공통) 2012.03.20 박효동 허성덕대왕 요청으로 전략공통조회시 전략업무로 MBO등록한건 제외로직 제거
                addQuery = @"
    AND ISNULL(H.ACTIVE_YN, '')     = CASE WHEN A.IS_TEAM_KPI = 'Y' THEN 'Y' ELSE '' END
    AND A.IS_TEAM_KPI       = 'Y'
--    AND A.KPI_REF_ID NOT IN (   SELECT ORG_KPI_REF_ID
--                                FROM BSC_MBO_KPI_CLASSIFICATION
--                                WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
--                                    AND EMP_REF_ID      = @EMP_REF_ID
--                                    AND KPI_CLASS_REF_ID    = 'STG')
";
            else if (gubun == "P") //일상공통(팀원MBO)
                addQuery = @"
    AND A.IS_TEAM_KPI       = 'N'
    AND A.CHAMPION_EMP_ID   <> @EMP_REF_ID
    AND A.KPI_REF_ID NOT IN (   SELECT ORG_KPI_REF_ID
                                FROM BSC_MBO_KPI_CLASSIFICATION
                                WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND EMP_REF_ID      = @EMP_REF_ID
                                    AND KPI_CLASS_REF_ID    = 'PCO')
";
            else//전체
                addQuery = @"
AND ISNULL(H.ACTIVE_YN, '')     = CASE WHEN A.IS_TEAM_KPI = 'Y' THEN 'Y' ELSE '' END
    AND A.KPI_REF_ID NOT IN (   SELECT ORG_KPI_REF_ID
                                FROM BSC_MBO_KPI_CLASSIFICATION
                                WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                    AND EMP_REF_ID      = @EMP_REF_ID
                                    AND KPI_CLASS_REF_ID    IN ('PCO')) --//2012.03.20 박효동 허성덕대왕 요청으로 전략공통조회시 전략업무로 MBO등록한건 제외로직 제거'STG', 
    --AND A.CHAMPION_EMP_ID   = CASE WHEN A.IS_TEAM_KPI = 'Y'  THEN A.CHAMPION_EMP_ID ELSE @EMP_REF_ID END
";

            string strQuery = @"
SELECT   A.ESTTERM_REF_ID
        ,A.KPI_REF_ID
        ,A.KPI_CODE
        ,ISNULL(C.KPI_NAME,'')      AS KPI_NAME
        ,ISNULL(B.EMP_NAME,'')      AS CHAMPION_EMP_NAME
        ,E.CODE_NAME                AS RESULT_INPUT_TYPE_NAME
        ,ISNULL(D.UNIT,'-')         AS UNIT_NAME
        ,G.COM_DEPT_NAME            AS OP_DEPT_NAME
        ,ISNULL(F.CODE_NAME,'')     AS KPI_GROUP_NAME
        ,A.IS_TEAM_KPI
FROM BSC_KPI_INFO A 
LEFT JOIN COM_EMP_INFO          B   ON A.CHAMPION_EMP_ID       = B.EMP_REF_ID
LEFT JOIN BSC_KPI_POOL          C   ON A.KPI_POOL_REF_ID       = C.KPI_POOL_REF_ID
LEFT JOIN COM_UNIT_TYPE_INFO    D   ON A.UNIT_TYPE_REF_ID      = D.UNIT_TYPE_REF_ID
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS001') E  ON A.RESULT_INPUT_TYPE = E.ETC_CODE
LEFT JOIN ( SELECT ETC_CODE, CODE_NAME 
            FROM COM_CODE_INFO 
            WHERE CATEGORY_CODE = 'BS009') F  ON C.KPI_GROUP_REF_ID = F.ETC_CODE
LEFT JOIN viw_EMP_COMDEPT       G   ON A.CHAMPION_EMP_ID    = G.EMP_REF_ID
LEFT JOIN COM_APPROVAL_INFO     H   ON H.APP_REF_ID         = A.APP_REF_ID
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.ISDELETE          = 'N'
    AND A.USE_YN            = 'Y'
/*    
    AND A.KPI_CODE          LIKE ( @KPI_CODE          + '%')
    AND C.KPI_NAME          LIKE ( @KPI_NAME          + '%')
*/
    AND (A.KPI_CODE          LIKE ( @KPI_CODE          + '%') OR  @KPI_CODE  ='' )
    AND (A.KPI_CODE          LIKE ( @KPI_NAME          + '%') OR  @KPI_NAME  ='' )

    AND G.COM_DEPT_REF_ID = CASE WHEN @COM_DEPT_REF_ID < 1 THEN 
            G.COM_DEPT_REF_ID 
        ELSE 
            @COM_DEPT_REF_ID 
        END
    AND A.KPI_REF_ID NOT IN (   SELECT KPI_REF_ID 
                                FROM BSC_MBO_KPI_WEIGHT 
                                WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID
                                    AND EMP_REF_ID     = @EMP_REF_ID
                                    AND USE_YN         = 'Y')
    -- 개인 kpi는 조직 kpi와 같이 결재를 하지 않는다.
    -- 단 개인 kpi(mbO)관리 화면에서 확정을 하면 결재 된것으로 간주.(BSC_KPI_INFO.APPROVAL_STATUS : N -> Y)
    --AND ISNULL(H.ACTIVE_YN, '')     = CASE WHEN A.IS_TEAM_KPI = 'Y' THEN 'Y' ELSE '' END
    --AND ISNULL(H.APP_STATUS, '')    = CASE WHEN A.IS_TEAM_KPI = 'Y' THEN 'CFT'  ELSE '' END
    AND RTRIM(LTRIM(ISNULL(A.APPROVAL_STATUS, 'N'))) = CASE WHEN A.IS_TEAM_KPI = 'Y' THEN 'N' ELSE 'Y' END
{0}
ORDER BY G.COM_DEPT_REF_ID, B.EMP_NAME, C.KPI_NAME
";

            strQuery = string.Format(strQuery, addQuery);
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_CODE", SqlDbType.VarChar);
            paramArray[2] = CreateDataParameter("@KPI_NAME", SqlDbType.VarChar);
            paramArray[3] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[4] = CreateDataParameter("@COM_DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_code;
            paramArray[2].Value = kpi_name;
            paramArray[3].Value = emp_ref_id;
            paramArray[4].Value = com_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetKpiAnalysis(int iestterm_ref_id, int iemp_ref_id, string iymd, string isum_type, string iresult_input_type, string ikpi_code, string ikpi_name, string iuse_yn, string ichampion_name, string ikpi_group_ref_id)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(11);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "KS";
	        paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iEMP_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iemp_ref_id;
            paramArray[3]               = CreateDataParameter("@iYMD", SqlDbType.VarChar);
            paramArray[3].Value         = iymd;
            paramArray[4]               = CreateDataParameter("@iSUM_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = isum_type;
            paramArray[5]               = CreateDataParameter("@iRESULT_INPUT_TYPE", SqlDbType.VarChar);
            paramArray[5].Value         = iresult_input_type;
            paramArray[6]               = CreateDataParameter("@iKPI_CODE", SqlDbType.VarChar);
            paramArray[6].Value         = ikpi_code;
            paramArray[7]               = CreateDataParameter("@iKPI_NAME", SqlDbType.VarChar);
            paramArray[7].Value         = ikpi_name;
            paramArray[8]               = CreateDataParameter("@iUSE_YN", SqlDbType.VarChar);
            paramArray[8].Value         = iuse_yn;
            paramArray[9]               = CreateDataParameter("@iCHAMPION_NAME", SqlDbType.VarChar);
            paramArray[9].Value         = ichampion_name;
            paramArray[10]              = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
            paramArray[10].Value        = ikpi_group_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MBO_KPI_WEIGHT", "PKG_BSC_MBO_KPI_WEIGHT.PROC_SELECT_MBO_KPI_ANALYSIS"), "BSC_MBO_KPI_WEIGHT", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
		#endregion



        #region ========================== 멀티 DB 작업 ============================


        public object[,] GetMboApprovalState(object estterm_ref_id
                                        , object emp_ref_id)
        {
            object[,] rtnObject = new object[1, 2];
            string strQuery = @"
--결재상태
SELECT   ISNULL(B.APP_STATUS,'NFT') AS APP_STATUS
        ,ISNULL(C.CODE_NAME,'')     AS APP_STATUS_NAME
FROM                BSC_MBO_KPI_TARGET_AGREEMENT    A
LEFT OUTER JOIN     COM_APPROVAL_INFO               B   ON  B.APP_REF_ID    = A.APP_REF_ID     
                                                        AND B.ACTIVE_YN     = 'Y'
LEFT OUTER JOIN     (   SELECT ETC_CODE, CODE_NAME
                        FROM COM_CODE_INFO 
                        WHERE CATEGORY_CODE = 'CM002') C  ON C.ETC_CODE     = B.APP_STATUS
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.EMP_REF_ID        = @EMP_REF_ID
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = emp_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_MBO_APPROVAL", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count == 0)
                rtnObject = null;
            else
            {
                rtnObject[0, 0] = ds.Tables[0].Rows[0][0];
                rtnObject[0, 1] = ds.Tables[0].Rows[0][1];
            }
            return rtnObject;
        }

        public object[,] GetMboApprovalStateByKpi(object estterm_ref_id
                                                , object kpi_ref_id)
        {
            object[,] rtnObject = new object[1, 2];
            string strQuery = @"
--결재상태
SELECT   ISNULL(C.APP_STATUS,'NFT') AS APP_STATUS
        ,ISNULL(D.CODE_NAME,'')     AS APP_STATUS_NAME

FROM                BSC_KPI_INFO                    A
INNER JOIN			BSC_MBO_KPI_WEIGHT				AA	ON	AA.ESTTERM_REF_ID	= A.ESTTERM_REF_ID
														AND	AA.EMP_REF_ID		= A.CHAMPION_EMP_ID
														AND AA.KPI_REF_ID		= A.KPI_REF_ID
														AND	AA.USE_YN='Y'
LEFT OUTER JOIN     BSC_MBO_KPI_TARGET_AGREEMENT    B   ON  B.ESTTERM_REF_ID    = AA.ESTTERM_REF_ID  
                                                        AND B.EMP_REF_ID        = AA.EMP_REF_ID
LEFT OUTER JOIN     COM_APPROVAL_INFO               C   ON  C.APP_REF_ID        = B.APP_REF_ID     
LEFT OUTER JOIN     (   SELECT ETC_CODE, CODE_NAME
                        FROM COM_CODE_INFO 
                        WHERE CATEGORY_CODE = 'CM002') D  ON D.ETC_CODE     = C.APP_STATUS
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND A.KPI_REF_ID        = @KPI_REF_ID
ORDER BY
        C.VERSION_NO   DESC
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1].Value = kpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(strQuery, "BSC_KPI_MBO_APPROVAL", null, paramArray, CommandType.Text);

            if (ds.Tables[0].Rows.Count == 0)
                rtnObject = null;
            else
            {
                rtnObject[0, 0] = ds.Tables[0].Rows[0][0];
                rtnObject[0, 1] = ds.Tables[0].Rows[0][1];
            }
            return rtnObject;
        }


        public int DeleteData_DB(IDbConnection conn
                                , IDbTransaction trx
                                , object estterm_ref_id
                                , object kpi_ref_id)
        {

            string query = @"

-- 지표구분테이블에 전략업무삭제한 이력 남김
DELETE FROM BSC_MBO_KPI_CLASSIFICATION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND KPI_REF_ID      = @KPI_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

			paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = kpi_ref_id;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);

            return affectedRow;
        }

        #endregion

    }
}