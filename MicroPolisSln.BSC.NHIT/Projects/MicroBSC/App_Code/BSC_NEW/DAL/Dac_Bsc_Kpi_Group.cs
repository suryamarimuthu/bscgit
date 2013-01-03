using System;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.BSC.Dac
{
    /// <summary>
    /// Dac_Bsc_Kpi_Group에 대한 요약 설명입니다.
    /// </summary>

    /// -------------------------------------------------------------
    /// Class 명		@ Dac_Bsc_Kpi_Group Dac 클래스
    /// Class 내용		@ Bsc_Kpi_Group Dac 처리 
    ///                 @ 웹에서 본페이지의 함수를 직접 콜하지 않도록 한다.(Biz단을 거쳐 콜하도록...)
    /// 작성자			@ 방병현
    /// 최초작성일		@ 2006.11.1
    /// 최종수정자		@
    /// 최종수정일		@
    /// Services		@
    /// 주요변경로그	@
    /// -------------------------------------------------------------
    public class Dac_Bsc_Kpi_Group : DbAgentBase
    {
        #region ------------------------ [ Field ] ------------------------
        private int      _iestterm_ref_id  ;
        private string   _ikpi_group_ref_id;
        private string   _ikpi_group_name;
        private string   _inormdist_use_yn ;
        private string   _imulti_est_use_yn;
        private string   _idescriptions    ;
        private Int32    _itxr_user;
        private Int32    _create_user;
        private DateTime _create_date;
        private Int32    _update_user;
        private DateTime _update_date;
        private String   _txr_message; // 처리결과메시지
        private String   _txr_result;  // 처리결과여부(Y,N)
        #endregion

        #region ------------------------ [ Property ] ------------------------

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

        public String Ikpi_group_ref_id
        {
            get
            {
                return _ikpi_group_ref_id;
            }
            set
            {
                _ikpi_group_ref_id = value;
            }
        }

        public String Ikpi_group_name
        {
            get
            {
                return _ikpi_group_name;
            }
            set
            {
                _ikpi_group_name = value;
            }
        }

        public String Inormdist_use_yn
        {
            get
            {
                return _inormdist_use_yn;
            }
            set
            {
                _inormdist_use_yn = value;
            }
        }

        public String Imulti_est_use_yn
        {
            get
            {
                return _imulti_est_use_yn;
            }
            set
            {
                _imulti_est_use_yn = value;
            }
        }

        public String Idescriptions
        {
            get
            {
                return _idescriptions;
            }
            set
            {
                _idescriptions = value;
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
         
        #region ------------------------ [ Constructor ] ------------------------
        public Dac_Bsc_Kpi_Group() { }
        public Dac_Bsc_Kpi_Group(int iestterm_ref_id, string ikpi_group_ref_id) 
        {
            DataSet ds = this.GetOneList(iestterm_ref_id, ikpi_group_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];

		        _iestterm_ref_id         = (dr["ESTTERM_REF_ID"]       == DBNull.Value) ? 0  : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _ikpi_group_ref_id       = (dr["KPI_GROUP_REF_ID"]     == DBNull.Value) ? "" : Convert.ToString(dr["KPI_GROUP_REF_ID"]);
                _ikpi_group_name         = (dr["KPI_GROUP_NAME"]       == DBNull.Value) ? "" : Convert.ToString(dr["KPI_GROUP_NAME"]);
		        _inormdist_use_yn        = (dr["NORMDIST_USE_YN"]      == DBNull.Value) ? "" : Convert.ToString(dr["NORMDIST_USE_YN"]);
		        _imulti_est_use_yn       = (dr["MULTI_EST_USE_YN"]     == DBNull.Value) ? "" : Convert.ToString(dr["MULTI_EST_USE_YN"]);
                _idescriptions           = (dr["DESCRIPTIONS"]         == DBNull.Value) ? "" : Convert.ToString(dr["DESCRIPTIONS"]);
                _create_user             = (dr["CREATE_USER"]          == DBNull.Value) ? 0  : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date             = (dr["CREATE_DATE"]          == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user             = (dr["UPDATE_USER"]          == DBNull.Value) ? 0  : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date             = (dr["UPDATE_DATE"]          == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
        }
        #endregion

        #region ------------------------ [ Method ] ------------------------
        internal protected int InsertData_Dac(int iestterm_ref_id, string ikpi_group_ref_id, string inormdist_use_yn, string imulti_est_use_yn, string idescriptions, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "A";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ikpi_group_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iNORMDIST_USE_YN", SqlDbType.VarChar);
	        paramArray[3].Value 	    = inormdist_use_yn;
	        paramArray[4] 		        = CreateDataParameter("@iMULTI_EST_USE_YN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = imulti_est_use_yn;
	        paramArray[5] 		        = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.VarChar);
	        paramArray[5].Value 	    = idescriptions;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_GROUP", "PKG_BSC_KPI_GROUP.PROC_INSERT"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int UpdateData_Dac(int iestterm_ref_id, string ikpi_group_ref_id, string inormdist_use_yn, string imulti_est_use_yn, string idescriptions, int itxr_user)
        {
	        IDbDataParameter[] paramArray = CreateDataParameters(9);
         
	        paramArray[0] 		        = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
	        paramArray[0].Value 	    = "U";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ikpi_group_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iNORMDIST_USE_YN", SqlDbType.VarChar);
	        paramArray[3].Value 	    = inormdist_use_yn;
	        paramArray[4] 		        = CreateDataParameter("@iMULTI_EST_USE_YN", SqlDbType.VarChar);
	        paramArray[4].Value 	    = imulti_est_use_yn;
	        paramArray[5] 		        = CreateDataParameter("@iDESCRIPTIONS", SqlDbType.VarChar);
	        paramArray[5].Value 	    = idescriptions;
	        paramArray[6] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[6].Value 	    = itxr_user;
	        paramArray[7] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[7].Direction 	= ParameterDirection.Output ;
	        paramArray[8] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[8].Direction 	= ParameterDirection.Output ;
         
	        IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_GROUP", "PKG_BSC_KPI_GROUP.PROC_UPDATE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        internal protected int DeleteData_Dac(int iestterm_ref_id, string ikpi_group_ref_id,  int itxr_user)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "D";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ikpi_group_ref_id;
	        paramArray[3] 		        = CreateDataParameter("@iTXR_USER", SqlDbType.Int);
	        paramArray[3].Value 	    = itxr_user;
	        paramArray[4] 		        = CreateDataParameter("@oRTN_MSG", SqlDbType.VarChar,1000);
	        paramArray[4].Direction 	= ParameterDirection.Output ;
	        paramArray[5] 		        = CreateDataParameter("@oRTN_COMPLETE_YN", SqlDbType.VarChar,1);
	        paramArray[5].Direction 	= ParameterDirection.Output ;

            IDataParameterCollection col;

            int affectedRow = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb("usp_BSC_KPI_GROUP", "PKG_BSC_KPI_GROUP.PROC_DELETE"), paramArray, CommandType.StoredProcedure, out col);
            
            this.Transaction_Message    = GetOutputParameterValueBySP(col, "@oRTN_MSG").ToString();
            this.Transaction_Result     = GetOutputParameterValueBySP(col, "@oRTN_COMPLETE_YN").ToString();

            return affectedRow;
        }

        public DataSet GetAllList(int iestterm_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SA";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_GROUP", "PKG_BSC_KPI_GROUP.PROC_SELECT_ALL"), "BSC_KPI_GROUP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataSet GetOneList(int iestterm_ref_id, string ikpi_group_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0]               = CreateDataParameter("@iTYPE", SqlDbType.VarChar);
            paramArray[0].Value         = "SO";
	        paramArray[1] 		        = CreateDataParameter("@iESTTERM_REF_ID", SqlDbType.Int);
	        paramArray[1].Value 	    = iestterm_ref_id;
	        paramArray[2] 		        = CreateDataParameter("@iKPI_GROUP_REF_ID", SqlDbType.VarChar);
	        paramArray[2].Value 	    = ikpi_group_ref_id;

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb("usp_BSC_KPI_GROUP", "PKG_BSC_KPI_GROUP.PROC_SELECT_ONE"), "BSC_KPI_GROUP", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        public DataTable GetIssueGroup(object estterm_ref_id, object group_code)
        {
            string strQuery = @"
SELECT   ESTTERM_REF_ID
        ,GROUP_CODE
        ,GROUP_NAME
FROM    BSC_KPI_ISSUE_GROUP
WHERE   (ESTTERM_REF_ID = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
    AND (GROUP_CODE     = @GROUP_CODE       OR @GROUP_CODE      = 0)
ORDER BY ESTTERM_REF_ID, GROUP_CODE
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
            paramArray[1].Value = group_code;

            return DbAgentObj.FillDataSet(strQuery, "BSC_KPI_ISSUE_GROUP", null, paramArray, CommandType.Text).Tables[0];
        }

        public bool CopyGroup(IDbConnection conn, IDbTransaction trx, object org_estterm_ref_id, object new_estterm_ref_id, object itxr_user)
        {
            this.Transaction_Message = "";

            string strQuery = @"
IF NOT EXISTS (SELECT * FROM BSC_KPI_ISSUE_GROUP WHERE ESTTERM_REF_ID = @NEW_ESTTERM_REF_ID)
BEGIN
    INSERT INTO BSC_KPI_ISSUE_GROUP
        (ESTTERM_REF_ID,        GROUP_CODE,     GROUP_NAME,     CREATE_USER,    CREATE_DATE)
    SELECT
        @NEW_ESTTERM_REF_ID,    GROUP_CODE,     GROUP_NAME,     @CREATE_USER,   GETDATE()
    FROM    BSC_KPI_ISSUE_GROUP
    WHERE   ESTTERM_REF_ID  = @ORG_ESTTERM_REF_ID
END
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ORG_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = org_estterm_ref_id;
            paramArray[1] = CreateDataParameter("@NEW_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = new_estterm_ref_id;
            paramArray[2] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[2].Value = itxr_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) > 0)
                return true;
            return false;
        }

        public bool SaveIssueGroup(IDbConnection conn, IDbTransaction trx, object estterm_ref_id, object group_code, object group_name, object itxr_user)
        {
            this.Transaction_Message = "";

            string strQuery = @"
IF (@GROUP_CODE = 0)
BEGIN
    INSERT INTO BSC_KPI_ISSUE_GROUP
        (ESTTERM_REF_ID,        GROUP_CODE,     GROUP_NAME,     CREATE_USER,    CREATE_DATE)
    SELECT
        @ESTTERM_REF_ID,        ISNULL(MAX(GROUP_CODE), 0) + 1,     @GROUP_NAME,     @CREATE_USER,   GETDATE()
    FROM    BSC_KPI_ISSUE_GROUP
    WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
END
ELSE
BEGIN
    UPDATE BSC_KPI_ISSUE_GROUP
        SET  GROUP_NAME = @GROUP_NAME
            ,CREATE_USER = @CREATE_USER
            ,CREATE_DATE = GETDATE()
    WHERE   ESTTERM_REF_ID = @ESTTERM_REF_ID
        AND GROUP_CODE  = @GROUP_CODE
END
";
            IDbDataParameter[] paramArray = CreateDataParameters(4);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
            paramArray[1].Value = group_code;
            paramArray[2] = CreateDataParameter("@GROUP_NAME", SqlDbType.VarChar);
            paramArray[2].Value = group_name;
            paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[3].Value = itxr_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) > 0)
                return true;
            return false;
        }
        public bool DeleteIssueGroup(IDbConnection conn, IDbTransaction trx, object estterm_ref_id, object group_code)
        {
            this.Transaction_Message = "";

            string strQuery = @"
DELETE FROM BSC_KPI_ISSUE_GROUP
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND GROUP_CODE      = @GROUP_CODE
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
            paramArray[1].Value = group_code;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) > 0)
            {
                strQuery = @"
DELETE FROM BSC_KPI_GROUP_MAP
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND GROUP_CODE      = @GROUP_CODE
";
                paramArray = null;
                paramArray = CreateDataParameters(2);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
                paramArray[1].Value = group_code;

                int delCount = DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text);
                return true;
            }
            return false;
        }
        public bool InsertIssueGroupMap(IDbConnection conn, IDbTransaction trx, object estterm_ref_id, object group_code, DataTable dtInsert, object reg_user)
        {
            this.Transaction_Message = "";

            string strQuery = @"
IF NOT EXISTS (SELECT TOP 1 * FROM BSC_KPI_GROUP_MAP WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND GROUP_CODE = @GROUP_CODE AND KPI_REF_ID IN ({0}))
BEGIN
    SELECT 1
END
ELSE
BEGIN
    SELECT 2
END
";
            string strExists = string.Empty;
            foreach (DataRow dr in dtInsert.Rows)
            {
                strExists += dr["KPI_REF_ID"].ToString() + ", ";
            }
            strExists = strExists.Substring(0, strExists.Length - 2);
            strQuery = string.Format(strQuery, strExists);

            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
            paramArray[1].Value = group_code;

            if (DbAgentObj.ExecuteScalar(conn, trx, strQuery, paramArray, CommandType.Text).ToString() == "2")
                return false;
            
            strQuery = @"
INSERT INTO BSC_KPI_GROUP_MAP (ESTTERM_REF_ID, GROUP_CODE, KPI_REF_ID, CREATE_USER, CREATE_DATE)
    VALUES (@ESTTERM_REF_ID, @GROUP_CODE, @KPI_REF_ID, @CREATE_USER, GETDATE())
";

            foreach (DataRow dr in dtInsert.Rows)
            {
                paramArray = null;
                paramArray = CreateDataParameters(4);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
                paramArray[1].Value = group_code;
                paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[2].Value = dr["KPI_REF_ID"];
                paramArray[3] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
                paramArray[3].Value = reg_user;

                if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
                    return false;
            }
            return true;
        }
        public bool DeleteIssueGroupMap(IDbConnection conn, IDbTransaction trx, object estterm_ref_id, object group_code, DataTable dtInsert)
        {
            this.Transaction_Message = "";

            string strQuery = @"
DELETE FROM BSC_KPI_GROUP_MAP
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND GROUP_CODE      = @GROUP_CODE
    AND KPI_REF_ID      = @KPI_REF_ID
";
            IDbDataParameter[] paramArray;
            foreach (DataRow dr in dtInsert.Rows)
            {
                paramArray = null;
                paramArray = CreateDataParameters(3);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
                paramArray[1].Value = group_code;
                paramArray[2] = CreateDataParameter("@KPI_REF_ID", SqlDbType.Int);
                paramArray[2].Value = dr["KPI_REF_ID"];

                if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) == 0)
                    return false;
            }
            return true;
        }
        public DataTable GetGroupMapList(object estterm_ref_id, object group_code)
        {
            string strQuery = @"
SELECT   A.ESTTERM_REF_ID
        ,A.GROUP_CODE
        ,A.KPI_REF_ID
        ,B.GROUP_NAME
        ,C.KPI_CODE
        ,D.KPI_NAME
        ,E.COM_DEPT_NAME as DEPT_NAME
        ,F.EMP_NAME AS CHAMPION_NAME
        ,ISNULL(G.CODE_NAME,'') as KPI_GROUP_NAME
        ,C.USE_YN
        ,ISNULL(H.APP_STATUS,'NFT') as APP_STATUS
FROM    BSC_KPI_GROUP_MAP   A
LEFT OUTER JOIN BSC_KPI_ISSUE_GROUP   B   ON  B.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND B.GROUP_CODE        = A.GROUP_CODE
LEFT OUTER JOIN BSC_KPI_INFO    C   ON  C.ESTTERM_REF_ID    = A.ESTTERM_REF_ID
                                    AND C.KPI_REF_ID        = A.KPI_REF_ID
LEFT OUTER JOIN BSC_KPI_POOL    D   ON  D.KPI_POOL_REF_ID   = C.KPI_POOL_REF_ID
LEFT OUTER JOIN viw_EMP_COMDEPT E   ON  E.EMP_REF_ID        = C.CHAMPION_EMP_ID
LEFT OUTER JOIN COM_EMP_INFO     F   ON  F.EMP_REF_ID        = C.CHAMPION_EMP_ID
LEFT OUTER JOIN COM_CODE_INFO   G   ON  G.CATEGORY_CODE     = 'BS009'
                                    AND G.ETC_CODE          = D.KPI_GROUP_REF_ID
LEFT OUTER JOIN COM_APPROVAL_INFO H ON  H.APP_REF_ID        = C.APP_REF_ID
                                    AND H.ACTIVE_YN         = 'Y'
WHERE   A.ESTTERM_REF_ID    = @ESTTERM_REF_ID
    AND (A.GROUP_CODE        = @GROUP_CODE OR @GROUP_CODE = 0)
";
            IDbDataParameter[] paramArray = CreateDataParameters(2);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@GROUP_CODE", SqlDbType.Int);
            paramArray[1].Value = group_code;

            return DbAgentObj.FillDataSet(strQuery, "BSC_KPI_GROUP_MAP", null, paramArray, CommandType.Text).Tables[0];
        }

        #endregion
    }
}
