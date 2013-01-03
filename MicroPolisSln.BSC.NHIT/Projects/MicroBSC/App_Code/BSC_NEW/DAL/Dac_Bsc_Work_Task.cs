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


/// <summary>
/// Dac_Bsc_Work_Task의 요약 설명입니다.
/// </summary>

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Work_Task : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;  //평가기간 id
        private string   _iestterm_ref_id_name;
        private int 	 _iest_dept_ref_id; //평가부서 id
        private string   _iest_dept_ref_id_name;
        private int      _iwork_ref_id;     //중점과제 id
        private string   _iwork_ref_id_name;
        private int      _iexec_ref_id;     //실행과제 id
        private string   _iexec_ref_id_name;
        private int      _itask_ref_id;     //세부일정 id
        private string   _itask_ref_id_name;
        private string   _itask_name;       //세부일정 명칭
        private string   _itask_desc;       //세부일정 설명
        private decimal    _itask_weight;      //세부일정 가중치
        private DateTime   _itgt_str_date;  //세부일정 목표 시작일자
        private DateTime _itgt_end_date;  //세부일정 목표 종료일자
        private int      _itgt_cost;      //예산금액
        private DateTime _irst_str_date;  //세부일정 실적 시작일자
        private DateTime _irst_end_date;  //세부일정 실적 종료일자
        private int      _irst_cost;           //집행예산
        private decimal  _ido_rate;
        private string   _iadd_file;
        private string   _iuse_yn;
        private int      _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
 
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)
        #endregion

        #region ============================== [Properties] ==============================

        public int Iestterm_ref_id
        {
            get
            {
                return _iestterm_ref_id;
            }
            set
            {
                _iestterm_ref_id = value;
            }
        }

        public string Iestterm_ref_id_name
        {
            get
            {
                return _iestterm_ref_id_name;
            }
            set
            {
                _iestterm_ref_id_name = value;
            }
        }

        public int Iest_dept_ref_id
        {
            get
            {
                return _iest_dept_ref_id;
            }
            set
            {
                _iest_dept_ref_id = value;
            }
        }

        public string Iest_dept_ref_id_name
        {
            get
            {
                return _iest_dept_ref_id_name;
            }
            set
            {
                _iest_dept_ref_id_name = value;
            }
        }

        public int Iwork_ref_id
        {
            get
            {
                return _iwork_ref_id;
            }
            set
            {
                _iwork_ref_id = value;
            }
        }

        public string Iwork_ref_id_name
        {
            get
            {
                return _iwork_ref_id_name;
            }
            set
            {
                _iwork_ref_id_name = value;
            }

        }

        public int Iexec_ref_id
        {
            get
            {
                return _iexec_ref_id;
            }
            set
            {
                _iexec_ref_id = value;
            }

        }

        public string Iexec_ref_id_name
        {
            get
            {
                return _iexec_ref_id_name;
            }
            set
            {
                _iexec_ref_id_name = value;
            }

        }

        public int Itask_ref_id
        {
            get
            {
                return _itask_ref_id;
            }
            set
            {
                _itask_ref_id = value;
            }

        }

        public string Itask_name
        {
            get
            {
                return _itask_name;
            }
            set
            {
                _itask_name = value;
            }
        }

        public string Itask_desc
        {
            get
            {
                return _itask_desc;
            }
            set
            {
                _itask_desc = ( value == null ? "":value);
            }
        }

        public decimal  Itask_weight
        {
            get
            {
                return _itask_weight;
            }
            set
            {
                _itask_weight = (value == null ? 0 : value);
            }
        }

        public DateTime Itgt_str_date
        {
            get
            {
                return _itgt_str_date;
            }
            set
            {
                _itgt_str_date = value;
            }
        }

        public DateTime Itgt_end_date
        {
            get
            {
                return _itgt_end_date;
            }
            set
            {
                _itgt_end_date = value;
            }
        }

        public int Itgt_cost
        {
            get
            {
                return _itgt_cost;
            }
            set
            {
                _itgt_cost = value;
            }
        }

        public DateTime Irst_str_date
        {
            get
            {
                return _irst_str_date;
            }
            set
            {
                _irst_str_date = value;
            }
        }

        public DateTime Irst_end_date
        {
            get
            {
                return _irst_end_date;
            }
            set
            {
                _irst_end_date = value;
            }
        }

        public int Irst_cost
        {
            get
            {
                return _irst_cost;
            }
            set
            {
                _irst_cost = value;
            }
        }

        public decimal Ido_rate
        {
            get
            {
                return _ido_rate;
            }
            set
            {
                _ido_rate = value;
            }
        }

        public string Iadd_file
        {
            get
            {
                return _iadd_file;
            }
            set
            {
                _iadd_file = value;
            }
        }

        public string Iuse_yn
        {
            get
            {
                return _iuse_yn;
            }
            set
            {
                _iuse_yn = value;
            }
        }

        public int Itxr_user
        {
            get
            {
                return _itxr_user;
            }
            set
            {
                _itxr_user = value;
            }
        }

        public Int32 Create_user
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

        public Int32 Update_user
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
        public Dac_Bsc_Work_Task() { }
        public Dac_Bsc_Work_Task(int Iexec_ref_id, int Itask_ref_id )
        {
            DataSet ds = this.GetOneList(Iexec_ref_id, Itask_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iexec_ref_id = (dr["EXEC_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_REF_ID"]);
                _iexec_ref_id_name = (dr["EXEC_NAME"] == DBNull.Value) ? "" : Convert.ToString (dr["EXEC_NAME"]);
                _itask_ref_id = (dr["TASK_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TASK_REF_ID"]);
                _itask_name = (dr["TASK_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["TASK_NAME"]);
                _itask_desc = (dr["TASK_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["TASK_DESC"]);
                _itask_weight = (dr["TASK_WEIGHT"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["TASK_WEIGHT"]);
                _itgt_str_date = (dr["TGT_STR_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TGT_STR_DATE"]);
                _itgt_end_date = (dr["TGT_END_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["TGT_END_DATE"]);
                _itgt_cost = (dr["TGT_COST"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TGT_COST"]);
                _irst_str_date = (dr["RST_STR_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["RST_STR_DATE"]);
                _irst_end_date = (dr["RST_END_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["RST_END_DATE"]);
                _irst_cost = (dr["RST_COST"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["RST_COST"]);
                _ido_rate = (dr["DO_RATE"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["DO_RATE"]);
                _iadd_file = (dr["ADD_FILE"] == DBNull.Value) ? "" : Convert.ToString(dr["ADD_FILE"]);
                _iuse_yn = (dr["USE_YN"] == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _create_user = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac
                (int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(19);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3]               = CreateDataParameter("@iTASK_NAME", SqlDbType.VarChar,100);
            paramArray[3].Value         = itask_name;
            
            paramArray[4]               = CreateDataParameter("@iTASK_DESC", SqlDbType.VarChar,1000);
            paramArray[4].Value         = itask_desc;

            paramArray[5] = CreateDataParameter("@iTASK_WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = itask_weight;

            paramArray[6] = CreateDataParameter("@iTGT_STR_DATE", SqlDbType.DateTime );
            paramArray[6].Value = itgt_str_date;

            paramArray[7] = CreateDataParameter("@iTGT_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value = itgt_end_date;

            paramArray[8] = CreateDataParameter("@iTGT_COST", SqlDbType.Decimal);
            paramArray[8].Value = itgt_cost;

            paramArray[9] = CreateDataParameter("@iRST_STR_DATE", SqlDbType.DateTime);
            paramArray[9].Value = irst_str_date;

            paramArray[10] = CreateDataParameter("@iRST_END_DATE", SqlDbType.DateTime);
            paramArray[10].Value = irst_end_date;

            paramArray[11] = CreateDataParameter("@iRST_COST", SqlDbType.Decimal);
            paramArray[11].Value = irst_cost;

            paramArray[12] = CreateDataParameter("@iDO_RATE", SqlDbType.Decimal);
            paramArray[12].Value = ido_rate;

            paramArray[13] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[13].Value = iadd_file;

            paramArray[14]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value        = iuse_yn;

            paramArray[15]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[15].Value        = itxr_user;

            paramArray[16]              = CreateDataParameter("@oRTN_TASK_REF_ID", SqlDbType.Int);
            paramArray[16].Direction    = ParameterDirection.Output;
            paramArray[17]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[17].Direction    = ParameterDirection.Output;
            paramArray[18]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[18].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Itask_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_TASK_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3] = CreateDataParameter("@iTASK_NAME", SqlDbType.VarChar, 100);
            paramArray[3].Value = itask_name;

            paramArray[4] = CreateDataParameter("@iTASK_DESC", SqlDbType.VarChar, 1000);
            paramArray[4].Value = itask_desc;

            paramArray[5] = CreateDataParameter("@iTASK_WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = itask_weight;

            paramArray[6] = CreateDataParameter("@iTGT_STR_DATE", SqlDbType.DateTime);
            paramArray[6].Value = itgt_str_date;

            paramArray[7] = CreateDataParameter("@iTGT_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value = itgt_end_date;

            paramArray[8] = CreateDataParameter("@iTGT_COST", SqlDbType.Decimal);
            paramArray[8].Value = itgt_cost;

            paramArray[9] = CreateDataParameter("@iRST_STR_DATE", SqlDbType.DateTime);
            paramArray[9].Value = irst_str_date;

            paramArray[10] = CreateDataParameter("@iRST_END_DATE", SqlDbType.DateTime);
            paramArray[10].Value = irst_end_date;

            paramArray[11] = CreateDataParameter("@iRST_COST", SqlDbType.Decimal);
            paramArray[11].Value = irst_cost;

            paramArray[12] = CreateDataParameter("@iDO_RATE", SqlDbType.Decimal);
            paramArray[12].Value = ido_rate;

            paramArray[13] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[13].Value = iadd_file;

            paramArray[14] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value = iuse_yn;

            paramArray[15] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[15].Value = itxr_user;

            paramArray[16]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[16].Direction    = ParameterDirection.Output;
            paramArray[17]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[17].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;
            
            paramArray[4]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(19);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3] = CreateDataParameter("@iTASK_NAME", SqlDbType.VarChar, 100);
            paramArray[3].Value = itask_name;

            paramArray[4] = CreateDataParameter("@iTASK_DESC", SqlDbType.VarChar, 1000);
            paramArray[4].Value = itask_desc;

            paramArray[5] = CreateDataParameter("@iTASK_WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = itask_weight;

            paramArray[6] = CreateDataParameter("@iTGT_STR_DATE", SqlDbType.DateTime);
            paramArray[6].Value = itgt_str_date;

            paramArray[7] = CreateDataParameter("@iTGT_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value = itgt_end_date;

            paramArray[8] = CreateDataParameter("@iTGT_COST", SqlDbType.Decimal);
            paramArray[8].Value = itgt_cost;

            paramArray[9] = CreateDataParameter("@iRST_STR_DATE", SqlDbType.DateTime);
            paramArray[9].Value = irst_str_date;

            paramArray[10] = CreateDataParameter("@iRST_END_DATE", SqlDbType.DateTime);
            paramArray[10].Value = irst_end_date;

            paramArray[11] = CreateDataParameter("@iRST_COST", SqlDbType.Decimal);
            paramArray[11].Value = irst_cost;

            paramArray[12] = CreateDataParameter("@iDO_RATE", SqlDbType.Decimal);
            paramArray[12].Value = ido_rate;

            paramArray[13] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[13].Value = iadd_file;

            paramArray[14] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value = iuse_yn;

            paramArray[15] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[15].Value = itxr_user;

            paramArray[16] = CreateDataParameter("@oRTN_TASK_REF_ID", SqlDbType.Int);
            paramArray[16].Direction = ParameterDirection.Output;

            paramArray[17] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[17].Direction = ParameterDirection.Output;
            paramArray[18] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[18].Direction = ParameterDirection.Output;
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Itask_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_TASK_REF_ID").ToString());



            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (IDbConnection conn, IDbTransaction trx,
                  int iexec_ref_id, int itask_ref_id, string itask_name, string itask_desc, decimal itask_weight, DateTime itgt_str_date, DateTime itgt_end_date, decimal itgt_cost, DateTime irst_str_date, DateTime irst_end_date, decimal irst_cost, decimal ido_rate, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3] = CreateDataParameter("@iTASK_NAME", SqlDbType.VarChar, 100);
            paramArray[3].Value = itask_name;

            paramArray[4] = CreateDataParameter("@iTASK_DESC", SqlDbType.VarChar, 1000);
            paramArray[4].Value = itask_desc;

            paramArray[5] = CreateDataParameter("@iTASK_WEIGHT", SqlDbType.Decimal);
            paramArray[5].Value = itask_weight;

            paramArray[6] = CreateDataParameter("@iTGT_STR_DATE", SqlDbType.DateTime);
            paramArray[6].Value = itgt_str_date;

            paramArray[7] = CreateDataParameter("@iTGT_END_DATE", SqlDbType.DateTime);
            paramArray[7].Value = itgt_end_date;

            paramArray[8] = CreateDataParameter("@iTGT_COST", SqlDbType.Decimal);
            paramArray[8].Value = itgt_cost;

            paramArray[9] = CreateDataParameter("@iRST_STR_DATE", SqlDbType.DateTime);
            paramArray[9].Value = irst_str_date;

            paramArray[10] = CreateDataParameter("@iRST_END_DATE", SqlDbType.DateTime);
            paramArray[10].Value = irst_end_date;

            paramArray[11] = CreateDataParameter("@iRST_COST", SqlDbType.Decimal);
            paramArray[11].Value = irst_cost;

            paramArray[12] = CreateDataParameter("@iDO_RATE", SqlDbType.Decimal);
            paramArray[12].Value = irst_cost;

            paramArray[13] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[13].Value = iadd_file;

            paramArray[14] = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[14].Value = iuse_yn;

            paramArray[15] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[15].Value = itxr_user;
            paramArray[16] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[16].Direction    = ParameterDirection.Output;
            paramArray[17]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[17].Direction    = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user; 
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction     = ParameterDirection.Output;
            paramArray[5]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(Int32 iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(IDbConnection conn, IDbTransaction trx, Int32 iexec_ref_id, int itask_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;
            paramArray[4] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[4].Direction = ParameterDirection.Output;
            paramArray[5] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[5].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iexec_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
 
            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_SELECT_ALL"), "BSC_WORK_TASK", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iexec_ref_id, int itask_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1]       = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2]       = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_SELECT_ONE"), "BSC_WORK_TASK", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetTaskStatus(int iexec_ref_id, int itask_ref_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SS";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[3].Value         = itxr_user;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_SELECT_WORK_STATUS"), "BSC_WORK_TASK", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }


        public DataSet GetTaskList(int iexec_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SL";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_TASK", "PKG_BSC_WORK_TASK.PROC_SELECT_TASK_LIST"), "BSC_WORK_TASK", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        #endregion

    }
}