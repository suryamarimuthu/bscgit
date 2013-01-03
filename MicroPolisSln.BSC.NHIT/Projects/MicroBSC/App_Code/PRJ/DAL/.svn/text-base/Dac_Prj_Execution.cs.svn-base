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
    /// Dac_Prj_Execution
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Prj_Execution
    /// Class Func     : PRJ_EXECUTION Table Data Access
    /// CREATE DATE    : 2008-04-10 오후 2:58:19
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Prj_Execution : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int _iexec_ref_id;
        private Int32 _iprj_ref_id;
        private Int32 _itask_ref_id;
        private object _iexec_date;
        private Decimal _iamount;
        private string _iexec_content;
        private Int32 _icreate_user;
        private DateTime _icreate_date;
        private Int32 _iupdate_user;
        private DateTime _iupdate_date;
        private String _txr_message;
        private String _txr_result;
        #endregion

        #region ============================== [Properties] ==============================
        public int IExec_Ref_Id
        {
            get { return _iexec_ref_id; }
            set { _iexec_ref_id = value; }
        }
        public int IPrj_Ref_Id
        {
            get { return _iprj_ref_id; }
            set { _iprj_ref_id = value; }
        }
        public int ITask_Ref_Id
        {
            get { return _itask_ref_id; }
            set { _itask_ref_id = value; }
        }
        public object IExec_Date
        {
            get { return _iexec_date; }
            set { _iexec_date = value; }
        }
        public decimal IAmount
        {
            get { return _iamount; }
            set { _iamount = value; }
        }

        public string IExec_Content
        {
            get { return _iexec_content; }
            set { _iexec_content = value; }
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
        public Dac_Prj_Execution() { }
        public Dac_Prj_Execution(int iexec_ref_id)
        {
            DataSet ds = this.GetOneList(iexec_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                _iexec_ref_id   = DataTypeUtility.GetToInt32(dr["EXEC_REF_ID"]);
                _iprj_ref_id    = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _itask_ref_id   = DataTypeUtility.GetToInt32(dr["TASK_REF_ID"]);
                _iexec_date     = DataTypeUtility.GetToDateTime(dr["EXEC_DATE"]);
                _iamount        = DataTypeUtility.GetToDecimal(dr["AMOUNT"]);
                _iexec_content  = DataTypeUtility.GetValue(dr["EXEC_CONTENT"]);
                _icreate_user   = DataTypeUtility.GetToInt32(dr["CREATE_USER"]);
                _icreate_date   = DataTypeUtility.GetToDateTime(dr["CREATE_DATE"]);
                _iupdate_user   = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
                _iupdate_date   = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iprj_ref_id, int itask_ref_id, object iexec_date, decimal iamount, string iexec_content, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2]       = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3]       = CreateDataParameter("@iEXEC_DATE", SqlDbType.DateTime);
            paramArray[3].Value = (iexec_date == null) ? DBNull.Value : iexec_date;
            paramArray[4]       = CreateDataParameter("@iAMOUNT", SqlDbType.Decimal);
            paramArray[4].Value = iamount;
            paramArray[5]       = CreateDataParameter("@iEXEC_CONTENT", SqlDbType.VarChar,200);
            paramArray[5].Value = iexec_content;
            paramArray[6]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[6].Value = itxr_user;
            paramArray[7]           = CreateDataParameter("@oRTN_EXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Direction = ParameterDirection.Output;
            paramArray[8]       = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[8].Direction = ParameterDirection.Output;
            paramArray[9]       = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[9].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_EXECUTION", "PKG_PRJ_EXECUTION.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.IExec_Ref_Id = DataTypeUtility.GetToInt32(GetOutputParameterValueBySP(col, "@oRTN_EXEC_REF_ID"));
            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iexec_ref_id, int iprj_ref_id, int itask_ref_id, object iexec_date, decimal iamount, string iexec_content,  int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(10);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "U";
            paramArray[1]       = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iprj_ref_id;
            paramArray[3]       = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[3].Value = itask_ref_id;
            paramArray[4]       = CreateDataParameter("@iEXEC_DATE", SqlDbType.DateTime);
            paramArray[4].Value = (iexec_date == null) ? DBNull.Value : iexec_date;
            paramArray[5]       = CreateDataParameter("@iAMOUNT", SqlDbType.Decimal);
            paramArray[5].Value = iamount;
            paramArray[6]       = CreateDataParameter("@iEXEC_CONTENT", SqlDbType.VarChar, 200);
            paramArray[6].Value = iexec_content;
            paramArray[7]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[7].Value = itxr_user;
            paramArray[8]       = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[8].Direction = ParameterDirection.Output;
            paramArray[9]       = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[9].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_EXECUTION", "PKG_PRJ_EXECUTION.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac
                (int iexec_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[2].Direction = ParameterDirection.Output;
            paramArray[3] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[3].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_EXECUTION", "PKG_PRJ_EXECUTION.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetOneList(int iexec_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
          

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_EXECUTION", "PKG_PRJ_EXECUTION.PROC_SELECT_ONE"), "PRJ_EXECUTION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_EXECUTION", "PKG_PRJ_EXECUTION.PROC_SELECT_ALL"), "PRJ_EXECUTION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetTotalSum(int iprj_ref_id, string budget_ym, decimal monthly_amount)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SU";
            paramArray[1]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2]       = CreateDataParameter("@iBUDGET_YM", SqlDbType.VarChar, 8);
            paramArray[2].Value = budget_ym;
            paramArray[3]       = CreateDataParameter("@iMONTHLY_AMOUNT", SqlDbType.Decimal);
            paramArray[3].Value = monthly_amount;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_EXECUTION", "PKG_PRJ_EXECUTION.PROC_SUM"), "PRJ_EXECUTION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion
    }
}