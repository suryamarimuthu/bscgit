using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_PDTAndAHPStgEstDeptDatas : DbAgentBase
    {
        public Dac_PDTAndAHPStgEstDeptDatas()
        {

        }

        public Dac_PDTAndAHPStgEstDeptDatas(int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int stg_ref_id)
        {
            DataSet ds = GetPDTAndAHPStgEstDeptData_Dac(ver_id, estterm_ref_id, est_dept_ref_id, stg_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];
                _ver_id             = (dr["VER_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["VER_ID"]);
                _estterm_ref_id     = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _est_dept_ref_id    = (dr["EST_DEPT_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
                _stg_ref_id         = (dr["STG_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["STG_REF_ID"]);
                _check_yn           = (dr["CHECK_YN"]       == DBNull.Value) ? "" : Convert.ToString(dr["CHECK_YN"]);
                _check_note         = (dr["CHECK_NOTE"]     == DBNull.Value) ? "" : Convert.ToString(dr["CHECK_NOTE"]);
                _create_date        = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _create_user        = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _update_date        = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
                _update_user        = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        #region ============================== [Fields] ==============================

        private int _ver_id;
        private int _estterm_ref_id;
        private int _est_dept_ref_id;
        private int _stg_ref_id;
        private string _check_yn;
        private string _check_note;
        private DateTime _create_date;
        private int _create_user;
        private DateTime _update_date;
        private int _update_user;
        #endregion

        #region ============================== [Properties] ==============================

        public int Ver_ID
        {
            get
            {
                return _ver_id;
            }
            set
            {
                _ver_id = value;
            }
        }

        public int Estterm_Ref_ID
        {
            get
            {
                return _estterm_ref_id;
            }
            set
            {
                _estterm_ref_id = value;
            }
        }

        public int Est_Dept_Ref_ID
        {
            get
            {
                return _est_dept_ref_id;
            }
            set
            {
                _est_dept_ref_id = value;
            }
        }

        public int Stg_Ref_ID
        {
            get
            {
                return _stg_ref_id;
            }
            set
            {
                _stg_ref_id = value;
            }
        }

        public string Check_YN
        {
            get
            {
                return _check_yn;
            }
            set
            {
                _check_yn = (value == null ? "" : value);
            }
        }

        public string Check_Note
        {
            get
            {
                return _check_note;
            }
            set
            {
                _check_note = (value == null ? "" : value);
            }
        }

        public DateTime Create_Date
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

        public int Create_User
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

        public DateTime Update_Date
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

        public int Update_User
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
        #endregion

        protected internal bool ModifyPDTAndAHPStgEstDeptData_Dac(int ver_id
                                                                , int estterm_ref_id
                                                                , int est_dept_ref_id
                                                                , int stg_ref_id
                                                                , string check_yn
                                                                , string check_note
                                                                , DateTime update_date
                                                                , int update_user)
        {
            string query = @"UPDATE	BSC_PDT_AHP_STG_EST_DEPT_DATA
                                SET	 CHECK_YN       = @CHECK_YN
	                                ,CHECK_NOTE     = @CHECK_NOTE
	                                ,UPDATE_DATE    = @UPDATE_DATE
	                                ,UPDATE_USER    = @UPDATE_USER
                                WHERE	VER_ID      = @VER_ID
                                AND	ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                AND	EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                AND	STG_REF_ID      = @STG_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;
            paramArray[4]               = CreateDataParameter("@CHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = check_yn;
            paramArray[5]               = CreateDataParameter("@CHECK_NOTE", SqlDbType.VarChar);
            paramArray[5].Value         = check_note;
            paramArray[6]               = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[6].Value         = update_date;
            paramArray[7]               = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[7].Value         = update_user;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected internal bool ModifyPDTAndAHPWeight_Dac(IDbConnection conn
                                                        , IDbTransaction trx
                                                        , int ver_id
                                                        , int estterm_ref_id
                                                        , int est_dept_ref_id
                                                        , int stg_ref_id
                                                        , float multiply
                                                        , float geomean
                                                        , float weight
                                                        , float sum_value
                                                        , float ws
                                                        , float ci
                                                        , float cr
                                                        , int update_user)
        {
            string query = @"UPDATE	BSC_PDT_AHP_STG_EST_DEPT_DATA
                                SET	 MULTIPLY       = @MULTIPLY
                                    , GEOMEAN       = @GEOMEAN
                                    , WEIGHT        = @WEIGHT
                                    , SUM_VALUE     = @SUM_VALUE
                                    , WS            = @WS
                                    , CI            = @CI
                                    , CR            = @CR
                                    , UPDATE_DATE   = GETDATE()
	                                , UPDATE_USER   = @UPDATE_USER
                                WHERE	VER_ID      = @VER_ID
                                AND	ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                AND	EST_DEPT_REF_ID = @EST_DEPT_REF_ID
                                AND	STG_REF_ID      = @STG_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;
            paramArray[4]               = CreateDataParameter("@MULTIPLY", SqlDbType.Float);
            paramArray[4].Value         = multiply;
            paramArray[5]               = CreateDataParameter("@GEOMEAN", SqlDbType.Float);
            paramArray[5].Value         = geomean;
            paramArray[6]               = CreateDataParameter("@WEIGHT", SqlDbType.Float);
            paramArray[6].Value         = weight;
            paramArray[7]               = CreateDataParameter("@SUM_VALUE", SqlDbType.Float);
            paramArray[7].Value         = sum_value;
            paramArray[8]               = CreateDataParameter("@WS", SqlDbType.Float);
            paramArray[8].Value         = ws;
            paramArray[9]               = CreateDataParameter("@CI", SqlDbType.Float);
            paramArray[9].Value         = ci;
            paramArray[10]              = CreateDataParameter("@CR", SqlDbType.Float);
            paramArray[10].Value        = cr;
            paramArray[11]              = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[11].Value        = update_user;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected internal DataSet GetPDTAndAHPStgEstDeptData_Dac(int ver_id
                                                                , int estterm_ref_id
                                                                , int est_dept_ref_id
                                                                , int stg_ref_id)
        {
            string query = @"SELECT	A.VER_ID
                                    ,A.ESTTERM_REF_ID
                                    ,A.EST_DEPT_REF_ID
                                    ,A.STG_REF_ID
                                    ,A.CHECK_YN
                                    ,A.CHECK_NOTE
                                    ,A.CREATE_DATE
                                    ,A.CREATE_USER
                                    ,A.UPDATE_DATE
                                    ,A.UPDATE_USER
                                FROM	BSC_PDT_AHP_STG_EST_DEPT_DATA                   A
		                            JOIN dbo.fn_GetEstDeptOppByLevel (@EST_DEPT_REF_ID) B ON (A.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID)
                                    WHERE	(A.VER_ID             = @VER_ID           OR @VER_ID          = 0)
                                        AND	(A.ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                        AND	(A.STG_REF_ID         = @STG_REF_ID       OR @STG_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;
            
            DataSet ds = DbAgentObj.FillDataSet(query, "PDTAHPSTGESTDEPTDATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        protected internal DataSet GetPDTAndAHPDeployList_Dac(int ver_id
                                                                , int estterm_ref_id
                                                                , int est_dept_ref_id
                                                                , int stg_ref_id
                                                                , bool isSubDept)
        {
            string query = @"SELECT	A.VER_ID
		                            , A.ESTTERM_REF_ID
		                            , A.EST_DEPT_REF_ID
                                    , dbo.fn_GetEstDeptName(A.ESTTERM_REF_ID, A.EST_DEPT_REF_ID) AS EST_DEPT_NAME
		                            , A.STG_REF_ID
		                            , A.CHECK_YN
		                            , A.CHECK_NOTE
		                            , A.MULTIPLY
		                            , A.GEOMEAN
		                            , A.WEIGHT
		                            , A.SUM_VALUE
		                            , A.WS
		                            , A.CI
		                            , A.CR
		                            , A.DEPLOY_YN
		                            , A.DEPLOY_DATE
		                            , A.CREATE_DATE
		                            , A.CREATE_USER
		                            , A.UPDATE_DATE
		                            , A.UPDATE_USER
		                            ,C.STG_NAME
                                FROM	BSC_PDT_AHP_STG_EST_DEPT_DATA                   A
                                    JOIN dbo.fn_GetEstDeptByLevel (@EST_DEPT_REF_ID) B ON (A.EST_DEPT_REF_ID = B.EST_DEPT_REF_ID)
		                            JOIN BSC_STG_INFO									C ON (A.STG_REF_ID			= C.STG_REF_ID 
																                            AND A.ESTTERM_REF_ID	= C.ESTTERM_REF_ID)
                                    WHERE	(A.VER_ID             = @VER_ID           OR @VER_ID          = 0)
                                        AND	(A.ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                        AND	(A.STG_REF_ID         = @STG_REF_ID       OR @STG_REF_ID      = 0)
                                        AND A.CHECK_YN            = 'Y'";

            if (!isSubDept)
                query += "              AND B.EST_DEPT_REF_ID = @EST_DEPT_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;
            
            DataSet ds                  = DbAgentObj.FillDataSet(query, "PDTAHPSTGESTDEPTDATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        protected internal DataSet GetPDTAndAHPEstDeptStgList_Dac(int ver_id
                                                                , int estterm_ref_id
                                                                , int est_dept_ref_id
                                                                , string check_yn)
        {
            string query = @"
                                /*
                                DECLARE @VER_ID int
                                DECLARE @ESTTERM_REF_ID int
                                DECLARE @EST_DEPT_REF_ID int
                                DECLARE @CHECK_YN char(1)

                                SET @VER_ID = 2
                                SET @ESTTERM_REF_ID = 1000
                                SET @EST_DEPT_REF_ID = 1000
                                SET @CHECK_YN = 'Y'

                                DROP TABLE #T
                                */

                                SELECT	IDENTITY(int, 1, 1) AS IDX
		                                ,A.VER_ID
		                                ,A.ESTTERM_REF_ID
		                                ,A.EST_DEPT_REF_ID
		                                ,A.STG_REF_ID
		                                ,A.CHECK_YN
		                                ,A.CHECK_NOTE
		                                ,A.CREATE_DATE
		                                ,A.CREATE_USER
		                                ,A.UPDATE_DATE
		                                ,A.UPDATE_USER
		                                ,B.STG_NAME
                                    INTO #T
	                                FROM	BSC_PDT_AHP_STG_EST_DEPT_DATA   A
		                                JOIN BSC_STG_INFO					B ON (A.STG_REF_ID			= B.STG_REF_ID 
												                                AND A.ESTTERM_REF_ID	= B.ESTTERM_REF_ID)
	                                WHERE	(A.VER_ID             = @VER_ID           OR @VER_ID          = 0)
		                                AND	(A.EST_DEPT_REF_ID    = @EST_DEPT_REF_ID OR @EST_DEPT_REF_ID  = 0)
		                                AND (A.CHECK_YN			  = @CHECK_YN		  OR @CHECK_YN		  =''    )
	                                ORDER BY B.STG_NAME

                                SELECT * FROM #T";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@CHECK_YN", SqlDbType.Char);
            paramArray[3].Value         = check_yn;
            
            DataSet ds                  = DbAgentObj.FillDataSet(query, "PDTAHPSTGESTDEPTDATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        protected internal DataSet GetAHPEstDeptStgList_Dac(int ver_id
                                                            , int estterm_ref_id
                                                            , int est_dept_ref_id)
        {
            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet("usp_BSC_AHP_LIST", "PDTAHPSTGESTDEPTDATAGET", null, paramArray, CommandType.StoredProcedure);
            return ds;
        }

        protected internal bool AddPDTAndAHPStgEstDeptData_Dac(IDbConnection conn
                                                , IDbTransaction trx
                                                , int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int stg_ref_id
                                                , string check_yn
                                                , string check_note
                                                , DateTime create_date
                                                , int create_user)
        {
            string query = @"
                            
                            /*
                            IF EXISTS (SELECT * FROM BSC_PDT_AHP_STG_EST_DEPT_DATA
                                            WHERE	VER_ID             = @VER_ID
                                                AND	ESTTERM_REF_ID     = @ESTTERM_REF_ID
                                                AND	EST_DEPT_REF_ID    = @EST_DEPT_REF_ID
                                                AND	STG_REF_ID         = @STG_REF_ID)
                            BEGIN

                                UPDATE BSC_PDT_AHP_STG_EST_DEPT_DATA
                                    SET CHECK_YN                = @CHECK_YN
                                        ,CHECK_NOTE             = @CHECK_NOTE
                                        ,UPDATE_DATE            = GETDATE()
                                        ,UPDATE_USER            = @CREATE_USER
                                    WHERE	VER_ID              = @VER_ID
                                        AND	ESTTERM_REF_ID      = @ESTTERM_REF_ID
                                        AND	EST_DEPT_REF_ID     = @EST_DEPT_REF_ID
                                        AND	STG_REF_ID          = @STG_REF_ID

                            END
                            ELSE
                            BEGIN
                            */

                                INSERT INTO BSC_PDT_AHP_STG_EST_DEPT_DATA(VER_ID
			                                                        ,ESTTERM_REF_ID
			                                                        ,EST_DEPT_REF_ID
			                                                        ,STG_REF_ID
			                                                        ,CHECK_YN
			                                                        ,CHECK_NOTE
			                                                        ,CREATE_DATE
			                                                        ,CREATE_USER
			                                                        ,UPDATE_DATE
			                                                        ,UPDATE_USER
			                                                        )
		                                                        VALUES	(@VER_ID
			                                                        ,@ESTTERM_REF_ID
			                                                        ,@EST_DEPT_REF_ID
			                                                        ,@STG_REF_ID
			                                                        ,@CHECK_YN
			                                                        ,@CHECK_NOTE
			                                                        ,@CREATE_DATE
			                                                        ,@CREATE_USER
			                                                        ,@CREATE_DATE
			                                                        ,@CREATE_USER
			                                                        )
                            /*END*/

                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;
            paramArray[4]               = CreateDataParameter("@CHECK_YN", SqlDbType.Char);
            paramArray[4].Value         = check_yn;
            paramArray[5]               = CreateDataParameter("@CHECK_NOTE", SqlDbType.VarChar);
            paramArray[5].Value         = check_note;
            paramArray[6]               = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[6].Value         = create_date;
            paramArray[7]               = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[7].Value         = create_user;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected internal bool RemovePDTAndAHPStgEstDeptData_Dac(IDbConnection conn
                                                                , IDbTransaction trx
                                                                , int ver_id
                                                                , int estterm_ref_id
                                                                , int est_dept_ref_id
                                                                , int stg_ref_id)
        {
            string query = @"DELETE	BSC_PDT_AHP_STG_EST_DEPT_DATA
                                WHERE	(VER_ID             = @VER_ID           OR @VER_ID          = 0)
                                    AND	(ESTTERM_REF_ID     = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                    AND	(EST_DEPT_REF_ID    = @EST_DEPT_REF_ID  OR @EST_DEPT_REF_ID = 0)
                                    AND	(STG_REF_ID         = @STG_REF_ID       OR @STG_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
