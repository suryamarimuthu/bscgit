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
    /// Dac_Prj_Schedule
    /// </summary>

    /// -------------------------------------------------------------
    /// Class Name     : Dac_Prj_Schedule
    /// Class Func     : PRJ_SCHEDULE Table Data Access
    /// CREATE DATE    : 2008-04-10 오후 2:46:12
    /// CREATE USER    : B.H.Bang
    /// CREATE DESC    :
    /// UPDATE DATE    :
    /// UPDATE USER    : 
    /// UPDATE DESC    : 
    /// -------------------------------------------------------------
    public class Dac_Prj_Schedule : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int _iprj_ref_id;
        private Int32 _itask_ref_id;
        private string _itask_name;
        private string _itask_type;
        private decimal _itask_weight;
        private Int32 _iup_task_ref_id;
        private String _itask_code;
        private object _iplan_start_date;
        private object _iplan_end_date;
        private object _iactual_start_date;
        private object _iactual_end_date;
        private Decimal _iproceed_rate;
        private String _iatt_file;
        private String _icomplete_yn;
        private String _iisdelete;
        private Int32 _inode_depth;
        private Int32 _iafter_task_ref_id;
        private String _idesction;
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
        public int ITask_Ref_Id
        {
            get { return _itask_ref_id; }
            set { _itask_ref_id = value; }
        }
        public string ITask_Name
        {
            get { return _itask_name; }
            set { _itask_name = value; }
        }
        public string ITask_Type
        {
            get { return _itask_type; }
            set { _itask_type = value; }
        }
        public decimal ITask_Weight
        {
            get { return _itask_weight; }
            set { _itask_weight = value; }
        }
        public int IUp_Task_Ref_Id
        {
            get { return _iup_task_ref_id; }
            set { _iup_task_ref_id = value; }
        }
        public string ITask_Code
        {
            get { return _itask_code; }
            set { _itask_code = value; }
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
        public decimal IProceed_Rate
        {
            get { return _iproceed_rate; }
            set { _iproceed_rate = value; }
        }
        public string IAtt_File
        {
            get { return _iatt_file; }
            set { _iatt_file = value; }
        }
        public string IComplete_Yn
        {
            get { return _icomplete_yn; }
            set { _icomplete_yn = value; }
        }
        public string IIsdelete
        {
            get { return _iisdelete; }
            set { _iisdelete = value; }
        }
        public int INode_Depth
        {
            get { return _inode_depth; }
            set { _inode_depth = value; }
        }

        public int IAfter_Task_Ref_Id
        {
            get { return _iafter_task_ref_id; }
            set { _iafter_task_ref_id = value; }
        }

        public string IDesction
        {
            get { return _idesction; }
            set { _idesction = value; }
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
        public Dac_Prj_Schedule() { }
        public Dac_Prj_Schedule(int iprj_ref_id, int itask_ref_id)
        {
            DataSet ds = this.GetOneList(iprj_ref_id, itask_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
                _iprj_ref_id        = DataTypeUtility.GetToInt32(dr["PRJ_REF_ID"]);
                _itask_ref_id       = DataTypeUtility.GetToInt32(dr["TASK_REF_ID"]);
                _itask_name         = DataTypeUtility.GetValue(dr["TASK_NAME"]);
                _itask_type         = DataTypeUtility.GetValue(dr["TASK_TYPE"]);
                _itask_weight       = DataTypeUtility.GetToDecimal(dr["TASK_WEIGHT"]);
                _iup_task_ref_id    = DataTypeUtility.GetToInt32(dr["UP_TASK_REF_ID"]);
                _itask_code         = DataTypeUtility.GetValue(dr["TASK_CODE"]);
                _iplan_start_date   = dr["PLAN_START_DATE"];
                _iplan_end_date     = dr["PLAN_END_DATE"];
                _iactual_start_date = dr["ACTUAL_START_DATE"];
                _iactual_end_date   = dr["ACTUAL_END_DATE"];
                _iproceed_rate      = DataTypeUtility.GetToDecimal(dr["PROCEED_RATE"]);
                _iatt_file          = DataTypeUtility.GetValue(dr["ATT_FILE"]);
                _icomplete_yn       = DataTypeUtility.GetValue(dr["COMPLETE_YN"]);
                _iisdelete          = DataTypeUtility.GetValue(dr["ISDELETE"]);
                _inode_depth        = DataTypeUtility.GetToInt32(dr["NODE_DEPTH"]);
                _iafter_task_ref_id = DataTypeUtility.GetToInt32(dr["AFTER_TASK_REF_ID"]);
                _idesction          = DataTypeUtility.GetString(dr["DESCTION"]);
                _icreate_user       = DataTypeUtility.GetToInt32(dr["CREATE_USER"]);
                _icreate_date       = DataTypeUtility.GetToDateTime(dr["CREATE_DATE"]);
                _iupdate_user       = DataTypeUtility.GetToInt32(dr["UPDATE_USER"]);
                _iupdate_date       = DataTypeUtility.GetToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iprj_ref_id, int itask_ref_id, string itask_name, string itask_type, decimal itask_weight, int iup_task_ref_id, string itask_code, object iplan_start_date, object iplan_end_date, object iactual_start_date, object iactual_end_date, decimal iproceed_rate, string iatt_file, string icomplete_yn, string iisdelete, int inode_depth, int iafter_task_ref_id, string idesction, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(23);

         
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "A";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iTASK_NAME", SqlDbType.VarChar);
            paramArray[3].Value = itask_name;
            paramArray[4] = CreateDataParameter("@iTASK_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = itask_type;
            paramArray[5] = CreateDataParameter("@iTASK_WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = itask_weight;
            paramArray[6] = CreateDataParameter("@iUP_TASK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iup_task_ref_id;
            paramArray[7] = CreateDataParameter("@iTASK_CODE", SqlDbType.VarChar);
            paramArray[7].Value = itask_code;
            paramArray[8] = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[8].Value = (iplan_start_date == null) ? DBNull.Value : iplan_start_date;
            paramArray[9] = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[9].Value = (iplan_end_date == null) ? DBNull.Value : iplan_end_date;

            paramArray[10] = CreateDataParameter("@iACTUAL_START_DATE", SqlDbType.DateTime);
            paramArray[10].Value = (iactual_start_date == null) ? DBNull.Value : iactual_start_date;
            paramArray[11] = CreateDataParameter("@iACTUAL_END_DATE", SqlDbType.DateTime);
            paramArray[11].Value = (iactual_end_date == null) ? DBNull.Value : iactual_end_date;
           
            paramArray[12] = CreateDataParameter("@iPROCEED_RATE", SqlDbType.Decimal);
            paramArray[12].Value = iproceed_rate;
            paramArray[13] = CreateDataParameter("@iATT_FILE", SqlDbType.VarChar);
            paramArray[13].Value = iatt_file;
            paramArray[14] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[14].Value = icomplete_yn;
            paramArray[15] = CreateDataParameter("@iISDELETE", SqlDbType.Char);
            paramArray[15].Value = iisdelete;
            paramArray[16] = CreateDataParameter("@iNODE_DEPTH", SqlDbType.Int);
            paramArray[16].Value = inode_depth;
            paramArray[17] = CreateDataParameter("@iAFTER_TASK_REF_ID", SqlDbType.Int);
            paramArray[17].Value = iafter_task_ref_id;
            paramArray[18] = CreateDataParameter("@iDESCTION", SqlDbType.VarChar, 2000);
            paramArray[18].Value = idesction;
            paramArray[19] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[19].Value = itxr_user;
            paramArray[20] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[20].Direction = ParameterDirection.Output;
            paramArray[21] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[21].Direction = ParameterDirection.Output;
            paramArray[22] = CreateDataParameter("@oRTN_TASK_REF_ID", SqlDbType.Int);
            paramArray[22].Direction = ParameterDirection.Output;


  
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();
            this.ITask_Ref_Id = Convert.ToInt32(GetOutputParameterValueBySP(col, "@oRTN_TASK_REF_ID"));

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iprj_ref_id, int itask_ref_id, string itask_name, string itask_type, decimal itask_weight, int iup_task_ref_id, string itask_code, object iplan_start_date, object iplan_end_date, object iactual_start_date, object iactual_end_date, decimal iproceed_rate, string iatt_file, string icomplete_yn, string iisdelete, int inode_depth, int iafter_task_ref_id, string idesction, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(22);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "U";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iTASK_NAME", SqlDbType.VarChar);
            paramArray[3].Value = itask_name;
            paramArray[4] = CreateDataParameter("@iTASK_TYPE", SqlDbType.VarChar);
            paramArray[4].Value = itask_type;
            paramArray[5] = CreateDataParameter("@iTASK_WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = itask_weight;
            paramArray[6] = CreateDataParameter("@iUP_TASK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iup_task_ref_id;
            paramArray[7] = CreateDataParameter("@iTASK_CODE", SqlDbType.VarChar);
            paramArray[7].Value = itask_code;
            paramArray[8] = CreateDataParameter("@iPLAN_START_DATE", SqlDbType.DateTime);
            paramArray[8].Value = (iplan_start_date == null) ? DBNull.Value : iplan_start_date;
            paramArray[9] = CreateDataParameter("@iPLAN_END_DATE", SqlDbType.DateTime);
            paramArray[9].Value = (iplan_end_date == null) ? DBNull.Value : iplan_end_date;
            paramArray[10] = CreateDataParameter("@iACTUAL_START_DATE", SqlDbType.DateTime);
            paramArray[10].Value = (iactual_start_date == null) ? DBNull.Value : iactual_start_date;
            paramArray[11]      = CreateDataParameter("@iACTUAL_END_DATE", SqlDbType.DateTime);
            paramArray[11].Value = (iactual_end_date == null) ? DBNull.Value : iactual_end_date;
            paramArray[12] = CreateDataParameter("@iPROCEED_RATE", SqlDbType.Decimal);
            paramArray[12].Value = iproceed_rate;
            paramArray[13] = CreateDataParameter("@iATT_FILE", SqlDbType.VarChar);
            paramArray[13].Value = iatt_file;
            paramArray[14] = CreateDataParameter("@iCOMPLETE_YN", SqlDbType.Char);
            paramArray[14].Value = icomplete_yn;
            paramArray[15] = CreateDataParameter("@iISDELETE", SqlDbType.Char);
            paramArray[15].Value = iisdelete;
            paramArray[16] = CreateDataParameter("@iNODE_DEPTH", SqlDbType.Int);
            paramArray[16].Value = inode_depth;
            paramArray[17] = CreateDataParameter("@iAFTER_TASK_REF_ID", SqlDbType.Int);
            paramArray[17].Value = iafter_task_ref_id;
            paramArray[18] = CreateDataParameter("@iDESCTION", SqlDbType.VarChar, 2000);
            paramArray[18].Value = idesction;
            paramArray[19] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[19].Value = itxr_user;
            paramArray[20] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[20].Direction = ParameterDirection.Output;
            paramArray[21] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[21].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac
                (int iprj_ref_id, int itask_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "D";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[3].Direction = ParameterDirection.Output;
            paramArray[4] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[4].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetOneList(int iprj_ref_id, int itask_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;


            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_SELECT_ONE"), "PRJ_SCHEDULE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetAllList(int iprj_ref_id, int itask_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
          
            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_SELECT_ALL"), "PRJ_SCHEDULE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetChildList(int iprj_ref_id, int iup_task_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "CO";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iUP_TASK_REF_ID", SqlDbType.Int, 8);
            paramArray[2].Value = iup_task_ref_id;
      
            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_SELECT_CHILD"), "PRJ_SCHEDULE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public int Count(int iprj_ref_id, int itask_ref_id)
        {

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "CK";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_CHECK"), "PRJ_SCHEDULE", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int intRtn = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                return intRtn;
            }
            else
            {
                return 0;
            }


            //return (int)DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_CHECK"), paramArray, CommandType.StoredProcedure);
        }

        public object GetTotalRate(int iprj_ref_id, int itask_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "TR";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_TOTAL_RATE"), "PRJ_SCHEDULE", null, paramArray, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0];
            }
            else
            {
                return 0;
            }

            //return DbAgentObj.ExecuteScalar(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_TOTAL_RATE"), paramArray, CommandType.StoredProcedure);
        }

        public DataSet GetUserAllList(int iprj_ref_id, int itask_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "UA";
            paramArray[1]       = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;
            paramArray[2]       = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3]       = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_SELECT_USER_ALL"), "PRJ_SCHEDULE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetActualDate(int iprj_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "AD";
            paramArray[1] = CreateDataParameter("@iPRJ_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iprj_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_PRJ_SCHEDULE", "PKG_PRJ_SCHEDULE.PROC_SELECT_ACTUAL_DATE"), "PRJ_SCHEDULE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        #endregion
    }
}