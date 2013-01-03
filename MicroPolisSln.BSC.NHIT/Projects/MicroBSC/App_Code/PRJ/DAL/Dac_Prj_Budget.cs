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
    /// Dac_Prj_Budget
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Prj_Budget
    /// Class Func     : PRJ_BUDGET Table Data Access
    /// CREATE DATE    : 2008-04-10 오후 3:04:58
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Prj_Budget : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int _iprj_ref_id;
        private String _ibudget_ym;
        private Decimal _imonthly_amount;
        private Int32 _icreate_user;
        private DateTime _icreate_date;
        private Int32 _iupdate_user;
        private DateTime _iupdate_date;
        private String _txr_message;
        private String _txr_result;
        #endregion

        #region ============================== [Properties] ==============================
        public int IPrj_Ref_Id
        {
            get { return _iprj_ref_id; }
            set { _iprj_ref_id = value; }
        }
        public string IBudget_Ym
        {
            get { return _ibudget_ym; }
            set { _ibudget_ym = value; }
        }
        public decimal IMonthly_Amount
        {
            get { return _imonthly_amount; }
            set { _imonthly_amount = value; }
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
        public Dac_Prj_Budget() { }
        public Dac_Prj_Budget(int iprj_ref_id, string ibudget_ym)
        {
            DataSet ds = this.GetOneList(iprj_ref_id, ibudget_ym);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                _iprj_ref_id = (dr["PRJ_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["PRJ_REF_ID"]);
                _ibudget_ym = (dr["BUDGET_YM"] == DBNull.Value) ? "" : Convert.ToString(dr["BUDGET_YM"]);
                _imonthly_amount = (dr["MONTHLY_AMOUNT"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["MONTHLY_AMOUNT"]);
                _icreate_user = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _icreate_date = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _iupdate_user = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _iupdate_date = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]); ;
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iprj_ref_id, string ibudget_ym, decimal imonthly_amount, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iBUDGET_YM", SqlDbType.VarChar);
            paramArray[2].Value = ibudget_ym;
            paramArray[3] = CreateDataParameter("@iMONTHLY_AMOUNT", SqlDbType.Decimal);
            paramArray[3].Value = imonthly_amount;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_BUDGET", "PKG_PRJ_BUDGET.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iprj_ref_id, string ibudget_ym, decimal imonthly_amount, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "U";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iBUDGET_YM", SqlDbType.VarChar);
            paramArray[2].Value = ibudget_ym;
            paramArray[3] = CreateDataParameter("@iMONTHLY_AMOUNT", SqlDbType.Decimal);
            paramArray[3].Value = imonthly_amount;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_BUDGET", "PKG_PRJ_BUDGET.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac
                (int iprj_ref_id, string ibudget_ym, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iBUDGET_YM", SqlDbType.VarChar);
            paramArray[2].Value = ibudget_ym;
            paramArray[3] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_BUDGET", "PKG_PRJ_BUDGET.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetOneList(int iprj_ref_id, string ibudget_ym)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iBUDGET_YM", SqlDbType.VarChar);
            paramArray[2].Value = ibudget_ym;
  

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_BUDGET", "PKG_PRJ_BUDGET.PROC_SELECT_ONE"), "PRJ_BUDGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(int iprj_ref_id, string ibudget_ym)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iBUDGET_YM", SqlDbType.VarChar);
            paramArray[2].Value = ibudget_ym;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_BUDGET", "PKG_PRJ_BUDGET.PROC_SELECT_ALL"), "PRJ_BUDGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet SelectMonthRateList(int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RT";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
 

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_BUDGET", "PKG_PRJ_BUDGET.PROC_SELECT_RATE"), "PRJ_BUDGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public object GetBudGetSum(int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SU";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;

            return DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_PRJ_BUDGET", "PKG_PRJ_BUDGET.PROC_BUDGET_SUM"),paramArray, CommandType.StoredProcedure);
        }
        #endregion
    }
}