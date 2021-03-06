﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

/// <summary>
/// Dac_Bsc_Kpi_Target에 대한 요약 설명입니다.
/// </summary>

/// -------------------------------------------------------------
/// Class 명		@ Dac_Bsc_Kpi_Target_Version Dac 클래스
/// Class 내용		@ Kpi_Pool Dac 처리 
///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
/// 작성자			@ 방병현
/// 최초작성일		@ 2007.05.29
/// 최종수정자		@
/// 최종수정일		@
/// Services		@
/// 주요변경로그	@
/// -------------------------------------------------------------
/// 

namespace MicroBSC.BSC.Dac
{
    public class Dac_Bsc_Kpi_Target_Version : DbAgentBase
    {
        #region ============================== [Fields] ==============================
        private int 	 _iestterm_ref_id;
        private int      _ikpi_ref_id;
        private int 	 _ikpi_target_version_id;
        private string 	 _iversion_name;
        private string 	 _iversion_desc;
        private int 	 _iversion_number;
        private int 	 _iupdate_term;
        private string 	 _iuse_yn;
        private string   _ienable_reg;
        private int 	 _itxr_user;
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

        public int Ikpi_ref_id
        {
            get
            {
                return _ikpi_ref_id;
            }
            set
            {
                _ikpi_ref_id = value;
            }
        }
         
        public int Ikpi_target_version_id
        {
	        get 
	        {
		        return _ikpi_target_version_id;
	        }
	        set
	        {
		        _ikpi_target_version_id = value;
	        }
        }
         
        public string Iversion_name
        {
	        get 
	        {
		        return _iversion_name;
	        }
	        set
	        {
		        _iversion_name = ( value==null ? "" : value );
	        }
        }
         
        public string Iversion_desc
        {
	        get 
	        {
		        return _iversion_desc;
	        }
	        set
	        {
		        _iversion_desc = ( value==null ? "" : value );
	        }
        }
         
        public int Iversion_number
        {
	        get 
	        {
		        return _iversion_number;
	        }
	        set
	        {
		        _iversion_number = value;
	        }
        }
         
        public int Iupdate_term
        {
	        get 
	        {
		        return _iupdate_term;
	        }
	        set
	        {
		        _iupdate_term = value;
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
		        _iuse_yn = ( value==null ? "" : value );
	        }
        }

        public string IEnable_Reg
        {
	        get 
	        {
                return _ienable_reg;
	        }
	        set
	        {
                _ienable_reg = (value == null ? "" : value);
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

#region ===============================[ 생 성 자 ]===============================

        public Dac_Bsc_Kpi_Target_Version()
        { 
        
        }

        public Dac_Bsc_Kpi_Target_Version(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id)
        {
            DataSet ds = GetOneList(iestterm_ref_id, ikpi_ref_id, ikpi_target_version_id);
            DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr = ds.Tables[0].Rows[0];
                _iestterm_ref_id        = (dr["ESTTERM_REF_ID"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ikpi_ref_id            = (dr["KPI_REF_ID"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_REF_ID"]);
                _ikpi_target_version_id = (dr["KPI_TARGET_VERSION_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["KPI_TARGET_VERSION_ID"]);
                _iversion_name          = (dr["VERSION_NAME"]          == DBNull.Value) ? "" : Convert.ToString(dr["VERSION_NAME"]);
		        _iversion_desc          = (dr["VERSION_DESC"]          == DBNull.Value) ? "" : Convert.ToString(dr["VERSION_DESC"]);
                _iversion_number        = (dr["VERSION_NUMBER"]        == DBNull.Value) ? 0 : Convert.ToInt32(dr["VERSION_NUMBER"]);
                _iupdate_term           = (dr["UPDATE_TERM"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_TERM"]);
                _iuse_yn                = (dr["USE_YN"]                == DBNull.Value) ? "" : Convert.ToString(dr["USE_YN"]);
                _ienable_reg            = (dr["ENABLE_REG"]            == DBNull.Value) ? "" : Convert.ToString(dr["ENABLE_REG"]);
                _itxr_user              = (dr["CREATE_USER"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_user            = (dr["CREATE_USER"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date            = (dr["CREATE_DATE"]           == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user            = (dr["UPDATE_USER"]           == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date            = (dr["UPDATE_DATE"]           == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
	        }
        }
#endregion

        internal protected int InsertData_Dac(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iversion_name, string iversion_desc, int iversion_number, int iupdate_term, string iuse_yn, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(13);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value         = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
	        paramArray[3].Value         = ikpi_target_version_id;
	        paramArray[4] 		        = CreateDataParameter("@iVERSION_NAME", SqlDbType.VarChar);
	        paramArray[4].Value         = iversion_name;
	        paramArray[5] 		        = CreateDataParameter("@iVERSION_DESC", SqlDbType.VarChar);
	        paramArray[5].Value         = iversion_desc;
	        paramArray[6] 		        = CreateDataParameter("@iVERSION_NUMBER", SqlDbType.Int);
	        paramArray[6].Value         = iversion_number;
	        paramArray[7] 		        = CreateDataParameter("@iUPDATE_TERM", SqlDbType.Int);
	        paramArray[7].Value         = iupdate_term;
	        paramArray[8] 		        = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
	        paramArray[8].Value         = iuse_yn;
	        paramArray[9] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[9].Value         = itxr_user;
	        paramArray[10] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[10].Direction 	= ParameterDirection.Output ;
	        paramArray[11] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
	        paramArray[11].Direction 	= ParameterDirection.Output ;
            paramArray[12]              = CreateDataParameter("@oKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[12].Direction    = ParameterDirection.Output;
         
            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TARGET_VERSION","PKG_BSC_KPI_TARGET_VERSION.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);

            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            this.Ikpi_target_version_id = int.Parse(GetOutputParameterValueBySP(col,"@oKPI_TARGET_VERSION_ID").ToString());

            return affectedRow;
       }

        internal protected int UpdateData_Dac(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id, string iversion_name, string iversion_desc, int iversion_number, int iupdate_term, string iuse_yn, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "U";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iVERSION_NAME", SqlDbType.VarChar);
            paramArray[4].Value         = iversion_name;
            paramArray[5]               = CreateDataParameter("@iVERSION_DESC", SqlDbType.VarChar);
            paramArray[5].Value         = iversion_desc;
            paramArray[6]               = CreateDataParameter("@iVERSION_NUMBER", SqlDbType.Int);
            paramArray[6].Value         = iversion_number;
            paramArray[7]               = CreateDataParameter("@iUPDATE_TERM", SqlDbType.Int);
            paramArray[7].Value         = iupdate_term;
            paramArray[8]               = CreateDataParameter("@iUSE_YN", SqlDbType.Char);
            paramArray[8].Value         = iuse_yn;
            paramArray[9]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[9].Value         = itxr_user;
            paramArray[10]              = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[10].Direction    = ParameterDirection.Output;
            paramArray[11]              = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[11].Direction    = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow             = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TARGET_VERSION","PKG_BSC_KPI_TARGET_VERSION.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
          
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, int ikpi_ref_id,  int ikpi_target_version_id, int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;
            paramArray[4]               = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
            paramArray[4].Value         = itxr_user;
            paramArray[5]               = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
            paramArray[5].Direction     = ParameterDirection.Output;
            paramArray[6]               = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.Char,1);
            paramArray[6].Direction     = ParameterDirection.Output;

            IDataParameterCollection col;

            int affectedRow             = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_TARGET_VERSION","PKG_BSC_KPI_TARGET_VERSION.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
           
            this.Transaction_Message    = GetOutputParameterValueBySP(col,"@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col,"@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET_VERSION","PKG_BSC_KPI_TARGET_VERSION.PROC_SELECT_ALL"), "KPI_TARGET_VERSION", null, paramArray, CommandType.StoredProcedure);
            return ds;

        }

        public DataSet GetOneList(int iestterm_ref_id, int ikpi_ref_id, int ikpi_target_version_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;

            DataSet ds                  = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET_VERSION","PKG_BSC_KPI_TARGET_VERSION.PROC_SELECT_ONE"), "KPI_TARGET_VERSION", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetEnableRegTargetList(int iestterm_ref_id, int ikpi_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SL";
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_TARGET_VERSION", "PKG_BSC_KPI_TARGET_VERSION.PROC_SELECT_REG_TARGET"), "KPI_TARGET_VERSION", null, paramArray, CommandType.StoredProcedure);
            return ds;

        }



        #region ========================== 멀티 DB 작업 ============================



        public int DeleteData_DB(IDbConnection conn
                               , IDbTransaction trx
                               , object iestterm_ref_id
                               , object ikpi_ref_id)
        {

            string query = @"

DELETE FROM BSC_KPI_TARGET_VERSION
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
        AND KPI_REF_ID  = @KPI_REF_ID

";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = iestterm_ref_id;
            paramArray[1]               = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = ikpi_ref_id;

            int affectedRow             = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
           
            return affectedRow;
        }

        public DataSet SelectData_DB(object iestterm_ref_id
                                   , object ikpi_ref_id
                                   , object ikpi_target_version_id
                                   , object use_yn)
        {
            string query = @"

SELECT ESTTERM_REF_ID
,KPI_REF_ID
,KPI_TARGET_VERSION_ID
,VERSION_NAME
,VERSION_DESC
,VERSION_NUMBER
,UPDATE_TERM
,USE_YN
,CREATE_DATE	
,CREATE_USER	
,UPDATE_DATE	
,UPDATE_USER	

WHERE (ESTTERM_REF_ID  = @ESTTERM_REF_ID       OR @ESTTERM_REF_ID   =0  )
  AND (KPI_REF_ID      = @KPI_REF_ID           OR @KPI_REF_ID       =0  )
  AND (KPI_REF_ID      = @KPI_REF_ID           OR @KPI_REF_ID       =0  )
  AND (USE_YN          = @USE_YN               OR @USE_YN           ='' )

";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[0].Value         = use_yn;
            paramArray[1]               = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = iestterm_ref_id;
            paramArray[2]               = CreateDataParameter("@iKPI_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = ikpi_ref_id;
            paramArray[3]               = CreateDataParameter("@iKPI_TARGET_VERSION_ID", SqlDbType.Int);
            paramArray[3].Value         = ikpi_target_version_id;

            DataSet ds = DbAgentObj.FillDataSet(query, "KPI_TARGET_VERSION", null, paramArray, CommandType.Text);
            return ds;
        }

        #endregion
    }
}
