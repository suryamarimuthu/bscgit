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
    public class Dac_Bsc_Work_Item : DbAgentBase
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
        private int      _iitem_ref_id;     //세부일정 id
        private string   _iitem_ref_id_name;
        private string   _iitem_ymd;       //세부일정 명칭
        private string   _iitem_name;       //세부일정 명칭
        private string   _iitem_desc;       //세부일정 설명
        private string   _iitem_unit;
        private string   _iitem_tgt;
        private string   _iitem_rst;
        private string  _iadd_file;
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

        public string Itask_ref_id_name
        {
            get
            {
                return _itask_ref_id_name;
            }
            set
            {
                _itask_ref_id_name = value;
            }

        }

        public int Iitem_ref_id
        {
            get
            {
                return _iitem_ref_id;
            }
            set
            {
                _iitem_ref_id = value;
            }

        }

        public string Iitem_ymd
        {
            get
            {
                return _iitem_ymd;
            }
            set
            {
                _iitem_ymd = value;
            }

        }

        public string Iitem_name
        {
            get
            {
                return _iitem_name;
            }
            set
            {
                _iitem_name = value;
            }
        }

        public string Iitem_desc
        {
            get
            {
                return _iitem_desc;
            }
            set
            {
                _iitem_desc = ( value == null ? "":value);
            }
        }

        public string Iitem_unit
        {
            get
            {
                return _iitem_unit;  
            }
            set
            {
                _iitem_unit   = (value == null ? "" : value);
            }
        }

        public string Iitem_tgt
        {
            get
            {
                return _iitem_tgt ;  
            }
            set
            {
                _iitem_tgt    = (value == null ? "" : value);
            }
        }

        public string Iitem_rst 
        {
            get
            {
                return _iitem_rst ;  
            }
            set
            {
                _iitem_rst    = (value == null ? "" : value);
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
        public Dac_Bsc_Work_Item() { }
        public Dac_Bsc_Work_Item(int Iexec_ref_id, int Itask_ref_id, int Iitem_ref_id )
        {
            DataSet ds = this.GetOneList(Iexec_ref_id, Itask_ref_id, Iitem_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _iexec_ref_id = (dr["EXEC_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EXEC_REF_ID"]);
                _iexec_ref_id_name = (dr["EXEC_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["EXEC_NAME"]);
                _itask_ref_id = (dr["TASK_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["TASK_REF_ID"]);
                _itask_ref_id_name = (dr["TASK_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["TASK_NAME"]);
                _iitem_ref_id = (dr["ITEM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ITEM_REF_ID"]);
                _iitem_ymd  = (dr["ITEM_YMD"] == DBNull.Value) ? "" : Convert.ToString(dr["ITEM_YMD"]);
                _iitem_name = (dr["ITEM_NAME"] == DBNull.Value) ? "" : Convert.ToString(dr["ITEM_NAME"]);
                _iitem_desc = (dr["ITEM_DESC"] == DBNull.Value) ? "" : Convert.ToString(dr["ITEM_DESC"]);
                _iitem_unit   = (dr["ITEM_UNIT"] == DBNull.Value) ? "": Convert.ToString(dr["ITEM_UNIT"]);
                _iitem_tgt = (dr["ITEM_TGT"] == DBNull.Value) ? "" : Convert.ToString(dr["ITEM_TGT"]);
                _iitem_rst = (dr["ITEM_RST"] == DBNull.Value) ? "" : Convert.ToString(dr["ITEM_RST"]);
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
                (int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(16);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;

            paramArray[4]               = CreateDataParameter("@iITEM_YMD", SqlDbType.VarChar,8);
            paramArray[4].Value         = iitem_ymd;
            
            paramArray[5]               = CreateDataParameter("@iITEM_NAME", SqlDbType.VarChar,100);
            paramArray[5].Value         = iitem_name;
            
            paramArray[6]               = CreateDataParameter("@iITEM_DESC", SqlDbType.VarChar,1000);
            paramArray[6].Value         = iitem_desc;

            paramArray[7] = CreateDataParameter("@iITEM_UNIT", SqlDbType.VarChar, 20);
            paramArray[7].Value = iitem_unit;

            paramArray[8] = CreateDataParameter("@iITEM_TGT", SqlDbType.VarChar, 100);
            paramArray[8].Value = iitem_tgt;

            paramArray[9] = CreateDataParameter("@iITEM_RST", SqlDbType.VarChar, 100);
            paramArray[9].Value = iitem_rst;

            paramArray[10] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[10].Value = iadd_file;

            paramArray[11]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[11].Value        = iuse_yn;

            paramArray[12]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[12].Value        = itxr_user;

            paramArray[13]              = CreateDataParameter("@oRTN_ITEM_REF_ID", SqlDbType.Int);
            paramArray[13].Direction    = ParameterDirection.Output;
            paramArray[14]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[14].Direction    = ParameterDirection.Output;
            paramArray[15]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[15].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Iitem_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_ITEM_REF_ID").ToString());

            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(15);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;

            paramArray[4]               = CreateDataParameter("@iITEM_YMD", SqlDbType.VarChar,8);
            paramArray[4].Value         = iitem_ymd;
            
            paramArray[5]               = CreateDataParameter("@iITEM_NAME", SqlDbType.VarChar,100);
            paramArray[5].Value         = iitem_name;
            
            paramArray[6]               = CreateDataParameter("@iITEM_DESC", SqlDbType.VarChar,1000);
            paramArray[6].Value         = iitem_desc;

            paramArray[7] = CreateDataParameter("@iITEM_UNIT", SqlDbType.VarChar, 20);
            paramArray[7].Value = iitem_unit;

            paramArray[8] = CreateDataParameter("@iITEM_TGT", SqlDbType.VarChar, 100);
            paramArray[8].Value = iitem_tgt;

            paramArray[9] = CreateDataParameter("@iITEM_RST", SqlDbType.VarChar, 100);
            paramArray[9].Value = iitem_rst;

            paramArray[10] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[10].Value = iadd_file;

            paramArray[11]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[11].Value        = iuse_yn;

            paramArray[12]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[12].Value        = itxr_user;

            paramArray[13]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[13].Direction    = ParameterDirection.Output;
            paramArray[14]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[14].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iexec_ref_id, int itask_ref_id,int iitem_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            
            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;
            
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int InsertData_Dac
                (IDbConnection conn, IDbTransaction trx,
                 int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(18);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "A";

            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;

            paramArray[4]               = CreateDataParameter("@iITEM_YMD", SqlDbType.VarChar,8);
            paramArray[4].Value         = iitem_ymd;
            
            paramArray[5]               = CreateDataParameter("@iITEM_NAME", SqlDbType.VarChar,100);
            paramArray[5].Value         = iitem_name;
            
            paramArray[6]               = CreateDataParameter("@iITEM_DESC", SqlDbType.VarChar,1000);
            paramArray[6].Value         = iitem_desc;

            paramArray[7] = CreateDataParameter("@iITEM_UNIT", SqlDbType.VarChar, 20);
            paramArray[7].Value = iitem_unit;

            paramArray[8] = CreateDataParameter("@iITEM_TGT", SqlDbType.VarChar, 100);
            paramArray[8].Value = iitem_tgt;

            paramArray[9] = CreateDataParameter("@iITEM_RST", SqlDbType.VarChar, 100);
            paramArray[9].Value = iitem_rst;

            paramArray[10] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[10].Value = iadd_file;

            paramArray[11]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[11].Value        = iuse_yn;

            paramArray[12]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[12].Value        = itxr_user;

            paramArray[13] = CreateDataParameter("@oRTN_ITEM_REF_ID", SqlDbType.Int);
            paramArray[13].Direction = ParameterDirection.Output;

            paramArray[14] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[14].Direction = ParameterDirection.Output;
            paramArray[15] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[15].Direction = ParameterDirection.Output;
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Iitem_ref_id            = (this.Transaction_Result == "N") ? 0 : int.Parse(GetOutputParameterValueBySP(col,"@oRTN_ITEM_REF_ID").ToString());



            return affectedRow;
        }

        internal protected int UpdateData_Dac
                (IDbConnection conn, IDbTransaction trx,
                  int iexec_ref_id, int itask_ref_id, int iitem_ref_id, string iitem_ymd, string iitem_name, string iitem_desc, string iitem_unit, string iitem_tgt, string iitem_rst, string iadd_file, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(15);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";


            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;

            paramArray[4]               = CreateDataParameter("@iITEM_YMD", SqlDbType.VarChar,8);
            paramArray[4].Value         = iitem_ymd;
            
            paramArray[5]               = CreateDataParameter("@iITEM_NAME", SqlDbType.VarChar,100);
            paramArray[5].Value         = iitem_name;
            
            paramArray[6]               = CreateDataParameter("@iITEM_DESC", SqlDbType.VarChar,1000);
            paramArray[6].Value         = iitem_desc;

            paramArray[7] = CreateDataParameter("@iITEM_UNIT", SqlDbType.VarChar, 20);
            paramArray[7].Value = iitem_unit;

            paramArray[8] = CreateDataParameter("@iITEM_TGT", SqlDbType.VarChar, 100);
            paramArray[8].Value = iitem_tgt;

            paramArray[9] = CreateDataParameter("@iITEM_RST", SqlDbType.VarChar, 100);
            paramArray[9].Value = iitem_rst;

            paramArray[10] = CreateDataParameter("@iADD_FILE", SqlDbType.NVarChar, 200);
            paramArray[10].Value = iadd_file;

            paramArray[11]              = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[11].Value        = iuse_yn;

            paramArray[12]              = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[12].Value        = itxr_user;

            paramArray[13] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[13].Direction    = ParameterDirection.Output;
            paramArray[14]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[14].Direction    = ParameterDirection.Output;


            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(IDbConnection conn, IDbTransaction trx, int iexec_ref_id, int itask_ref_id, int iitem_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user; 
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(Int32 iexec_ref_id, int itask_ref_id,int iitem_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int ReUsedData_Dac(IDbConnection conn, IDbTransaction trx, Int32 iexec_ref_id, int itask_ref_id, int iitem_ref_id, Int32 itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "RU";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3] = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;
            paramArray[4] = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value = itxr_user;
            paramArray[5] = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar, 1000);
            paramArray[5].Direction = ParameterDirection.Output;
            paramArray[6] = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar, 1);
            paramArray[6].Direction = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_REUSED"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iexec_ref_id, int itask_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SA";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2] = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_SELECT_ALL"), "BSC_WORK_ITEM", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }
        
        public DataSet GetAllList(int iexec_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0] = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SE";
            paramArray[1] = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_SELECT_EXEC_ALL"), "BSC_WORK_ITEM", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iexec_ref_id, int itask_ref_id,int iitem_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0]       = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value = "SO";
            paramArray[1]       = CreateDataParameter("@iEXEC_REF_ID", SqlDbType.Int);
            paramArray[1].Value = iexec_ref_id;
            paramArray[2]       = CreateDataParameter("@iTASK_REF_ID", SqlDbType.Int);
            paramArray[2].Value = itask_ref_id;
            paramArray[3]       = CreateDataParameter("@iITEM_REF_ID", SqlDbType.Int);
            paramArray[3].Value = iitem_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_WORK_ITEM", "PKG_BSC_WORK_ITEM.PROC_SELECT_ONE"), "BSC_WORK_ITEM", null, paramArray, CommandType.StoredProcedure);
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

        #endregion

    }
}