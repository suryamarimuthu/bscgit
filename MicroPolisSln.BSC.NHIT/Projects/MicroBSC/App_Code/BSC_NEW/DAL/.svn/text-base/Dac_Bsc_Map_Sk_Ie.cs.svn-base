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
/// Dac_Bsc_Map_Sk_Ie의 요약 설명입니다.
/// </summary>
/// 
namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Map_Sk_Ie : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;  //평가기간 id
        private string _iestterm_name;
        private int 	 _iest_dept_ref_id; //평가부서 id
        private string _iest_dept_name;
        private int _imap_version_id;
        private string _imap_version_name;
        private int _istg_ref_id;
        private string _istg_name;
        private int _ikpi_ref_id;
        private string _ikpi_name;
        private int _idept_ref_id;
        private string _idept_name;
        private int      _iwork_ref_id;     //중점과제 id
        private string _iwork_name;
        private int _iexec_ref_id;     //실행과제 id
        private string _iexec_name;       //실행과제 명칭
        private int _iorder_seq;
        private int _itxr_user;
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
                _iestterm_ref_id = (value == null ? 0 : value);
            }
        }

        public string Iestterm_name
        {
            get
            {
                return _iestterm_name;
            }
            set
            {
                _iestterm_name = (value == null ? "" : value);
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
                _iest_dept_ref_id = (value == null ? 0 : value);
            }
        }

        public string Iest_dept_name
        {
            get
            {
                return _iest_dept_name;
            }
            set
            {
                _iest_dept_name = (value == null ? "" : value);
            }
        }


        public int Imap_version_id
        {
            get
            {
                return _imap_version_id;
            }
            set
            {
                _imap_version_id = (value == null ? 0 : value);
            }
        }

        public string Imap_version_name
        {
            get
            {
                return _imap_version_name;
            }
            set
            {
                _imap_version_name = (value == null ? "" : value);
            }
        }

        public int Istg_ref_id
        {
            get
            {
                return _istg_ref_id;
            }
            set
            {
                _istg_ref_id = (value == null ? 0 : value);
            }
        }

        public string Istg_name
        {
            get
            {
                return _istg_name;
            }
            set
            {
                _istg_name = (value == null ? "" : value);
            }
        }

        public int Ikpi_ref_id
        {
            get
            {
                return _ikpi_ref_id;
            }
            set
            {
                _ikpi_ref_id = (value == null ? 0 : value);
            }
        }

        public string Ikpi_name
        {
            get
            {
                return _ikpi_name;
            }
            set
            {
                _ikpi_name = (value == null ? "" : value);
            }
        }

        public int Idept_ref_id
        {
            get
            {
                return _idept_ref_id;
            }
            set
            {
                _idept_ref_id = (value == null ? 0 : value);
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
                _idept_name = (value == null ? "" : value);
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
                _iwork_ref_id = (value == null ? 0 : value);
            }
        }

        public string Iwork_name
        {
            get
            {
                return _iwork_name;
            }
            set
            {
                _iwork_name = (value == null ? "" : value);
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
                _iexec_ref_id = (value == null ? 0 : value);
            }

        }

        public string Iexec_name
        {
            get
            {
                return _iexec_name;
            }
            set
            {
                _iexec_name = (value == null ? "" : value);
            }
        }

        public int Iorder_seq
        {
            get
            {
                return _iorder_seq;
            }
            set
            {
                _iorder_seq = value;
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
        public Dac_Bsc_Map_Sk_Ie() { }

        public Dac_Bsc_Map_Sk_Ie(int Iestterm_ref_id, int Iest_dept_ref_id, int Istg_ref_id, int Ikpi_ref_id, int Idept_ref_id, 
            int Iwork_ref_id, int Iexec_ref_id)
        {
            DataSet ds = this.GetOneList(Iestterm_ref_id, Iest_dept_ref_id, Istg_ref_id, Ikpi_ref_id, Idept_ref_id,Iwork_ref_id, Iexec_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];

                _iestterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _iestterm_name = (dr["ESTTERM_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["ESTTERM_NAME"]);
                
                _iest_dept_ref_id = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _iest_dept_name = (dr["EST_DEPT_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EST_DEPT_NAME"]);

                _istg_ref_id = (dr["STG_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["STG_REF_ID"]);
                _istg_name = (dr["STG_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["STG_NAME"]);

                _ikpi_ref_id = (dr["KPI_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
                _ikpi_name = (dr["KPI_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["KPI_NAME"]);

                _idept_ref_id = (dr["DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["DEPT_REF_ID"]);
                _idept_name = (dr["DEPT_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["DEPT_NAME"]);
               
                _iwork_ref_id = (dr["WORK_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["WORK_REF_ID"]);
                _iwork_name = (dr["WORK_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["WORK_NAME"]);

                _iexec_ref_id = (dr["EXEC_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_REF_ID"]);
                _iexec_name = (dr["EXEC_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_NAME"]);

                _iorder_seq = (dr["ORDER_SEQ"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ORDER_SEQ"]);

                _create_user = (dr["CREATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date = (dr["CREATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user = (dr["UPDATE_USER"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date = (dr["UPDATE_DATE"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }

        #endregion

        #region ============================== [Method] ==============================
        internal protected int InsertData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id,
                int iwork_ref_id, int iexec_ref_id, int iorder_seq, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            
            paramArray[2]               = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;

            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            paramArray[6] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iwork_ref_id;

            paramArray[7] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iexec_ref_id;

            paramArray[8] = CreateDataParameter("@iORDER_SEQ", SqlDbType.Int);
            paramArray[8].Value = iorder_seq;

            paramArray[9]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value        = itxr_user;

            paramArray[10]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[11].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id,
                int iwork_ref_id, int iexec_ref_id, int iorder_seq,
                 int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;

            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            paramArray[6] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iwork_ref_id;

            paramArray[7] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iexec_ref_id;

            paramArray[8] = CreateDataParameter("@iORDER_SEQ", SqlDbType.Int);
            paramArray[8].Value = iorder_seq;

            paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value = itxr_user;

            paramArray[10]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[11].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id,
            int iwork_ref_id, int iexec_ref_id,
            Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;

            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            paramArray[6] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iwork_ref_id;

            paramArray[7] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iexec_ref_id;

            paramArray[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value         = itxr_user;
            paramArray[9]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[9].Direction     = ParameterDirection.Output;
            paramArray[10]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[10].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, int iorder_seq, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;

            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            paramArray[6] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iwork_ref_id;

            paramArray[7] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iexec_ref_id;

            paramArray[8] = CreateDataParameter("@iORDER_SEQ", SqlDbType.Int);
            paramArray[8].Value = iorder_seq;
            
            paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value = itxr_user;

            paramArray[10] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[10].Direction = ParameterDirection.Output;
            paramArray[11] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[11].Direction = ParameterDirection.Output;
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id, int iorder_seq, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;

            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            paramArray[6] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iwork_ref_id;

            paramArray[7] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iexec_ref_id;

            paramArray[8] = CreateDataParameter("@iORDER_SEQ", SqlDbType.Int);
            paramArray[8].Value = iorder_seq;

            paramArray[9] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value = itxr_user;

            paramArray[10] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[10].Direction = ParameterDirection.Output;
            paramArray[11] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[11].Direction = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id,
            int iwork_ref_id, int iexec_ref_id, 
            Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(11);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;

            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;

            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            paramArray[6] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iwork_ref_id;

            paramArray[7] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iexec_ref_id;

            paramArray[8] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[8].Value = itxr_user;
            paramArray[9] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[9].Direction = ParameterDirection.Output;
            paramArray[10] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[10].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        //internal protected int ReUsedData_Dac(Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        //{
        //    IDbDataParameter[] paramArray = CreateDataParameters(8);

        //    paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
        //    paramArray[0].Value = "RU";
        //    paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
        //    paramArray[1].Value = iestterm_ref_id;
        //    paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
        //    paramArray[2].Value = iest_dept_ref_id;
        //    paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
        //    paramArray[3].Value = iwork_ref_id;
        //    paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
        //    paramArray[4].Value = iexec_ref_id;
        //    paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
        //    paramArray[5].Value = itxr_user;
        //    paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
        //    paramArray[6].Direction = ParameterDirection.Output;
        //    paramArray[7] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
        //    paramArray[7].Direction = ParameterDirection.Output;

        //    IDataParameterCollection col;

        //    int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

        //    this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
        //    this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

        //    return affectedRow;
        //}

        //internal protected int ReUsedData_Dac(IDbConnection conn, IDbTransaction trx, Int32 iestterm_ref_id, Int32 iest_dept_ref_id, Int32 iwork_ref_id, int iexec_ref_id, Int32 itxr_user)
        //{
        //    IDbDataParameter[] paramArray = CreateDataParameters(7);

        //    paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
        //    paramArray[0].Value = "RU";
        //    paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
        //    paramArray[1].Value = iestterm_ref_id;
        //    paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
        //    paramArray[2].Value = iest_dept_ref_id;
        //    paramArray[3] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
        //    paramArray[3].Value = iwork_ref_id;
        //    paramArray[4] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
        //    paramArray[4].Value = iexec_ref_id;
        //    paramArray[5] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
        //    paramArray[5].Value = itxr_user;
        //    paramArray[6] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
        //    paramArray[6].Direction = ParameterDirection.Output;
        //    paramArray[7] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
        //    paramArray[7].Direction = ParameterDirection.Output;

        //    IDataParameterCollection col;

        //    int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_EXEC", "PKG_BSC_WORK_EXEC.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

        //    this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
        //    this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

        //    return affectedRow;
        //}

        public DataSet GetAllList(int iestterm_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_ALL"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetStgList(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S1";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            
            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_STG"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetStgKpiList(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S2";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_STGKPI"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetStgWorkList(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S6";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;
            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_STGWORK"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetStgExecList(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S7";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;
            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_STGEXEC"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiWorkList(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S8";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;
            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_KPIWORK"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetKpiExecList(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S9";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;
            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_KPIEXEC"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id, int idept_ref_id, int iwork_ref_id, int iexec_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;
            paramArray[5] = CreateDataParameter("@iDEPT_REF_ID", SqlDbType.Int);
            paramArray[5].Value = idept_ref_id;
            paramArray[6] = CreateDataParameter("@iWORK_REF_ID", SqlDbType.Int);
            paramArray[6].Value = iwork_ref_id;
            paramArray[7] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[7].Value = iexec_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_ONE"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMapVersion(int iestterm_ref_id, int iest_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S3";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_MAP"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMapWorkCnt(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S4";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_MAP_WORKCNT"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetMapExecCnt(int iestterm_ref_id, int iest_dept_ref_id, int istg_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(5);
            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "S5";
            paramArray[1] = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iestterm_ref_id;
            paramArray[2] = CreateDataParameter("@iEST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = iest_dept_ref_id;
            paramArray[3] = CreateDataParameter("@iSTG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = istg_ref_id;
            paramArray[4] = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[4].Value = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_MAP_SK_IE", "PKG_BSC_MAP_SK_IE.PROC_SELECT_MAP_EXECCNT"), "BSC_MAP_SK_IE", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        #endregion

    }
}