using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_EstDeptOrgScoreInfos : DbAgentBase
    {
        public Dac_EstDeptOrgScoreInfos()
        {

        }

        public Dac_EstDeptOrgScoreInfos(int estterm_ref_id, string score_code)
        {
            DataSet ds = GetEstDeptOrgScoreInfo_Dac(estterm_ref_id, score_code);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr;
                dr = ds.Tables[0].Rows[0];
                _estterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _score_code     = (dr["SCORE_CODE"]     == DBNull.Value) ? "" : Convert.ToString(dr["SCORE_CODE"]);
                _score_name     = (dr["SCORE_NAME"]     == DBNull.Value) ? "" : Convert.ToString(dr["SCORE_NAME"]);
                _min_value      = (dr["MIN_VALUE"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["MIN_VALUE"]);
                _max_value      = (dr["MAX_VALUE"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["MAX_VALUE"]);
                _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
            }
            else
            {
                _estterm_ref_id = 1000;
                _score_code     = "";
                _score_name     = "";
                _min_value      = 0;
                _max_value      = 0;
                _create_user    = 0;
                _create_date    = DateTime.Now;
                _update_user    = 0;
                _update_date    = DateTime.Now;
            }
        }

        #region ============================== [Fields] ==============================

        private int _estterm_ref_id;
        private string _score_code;
        private string _score_name;
        private int _min_value;
        private int _max_value;
        private int _create_user;
        private DateTime _create_date;
        private int _update_user;
        private DateTime _update_date;
        #endregion

        #region ============================== [Properties] ==============================

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

        public string Score_Code
        {
            get
            {
                return _score_code;
            }
            set
            {
                _score_code = (value == null ? "" : value);
            }
        }

        public string Score_Name
        {
            get
            {
                return _score_name;
            }
            set
            {
                _score_name = (value == null ? "" : value);
            }
        }

        public int Min_Value
        {
            get
            {
                return _min_value;
            }
            set
            {
                _min_value = value;
            }
        }

        public int Max_Value
        {
            get
            {
                return _max_value;
            }
            set
            {
                _max_value = value;
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
        #endregion

        internal protected bool ModifyEstDeptOrgScoreInfo_Dac(int estterm_ref_id
                                                            , string score_code
                                                            , string score_name
                                                            , int min_value
                                                            , int max_value
                                                            , int update_user
                                                            , DateTime update_date)
        {
            string query = @"UPDATE	BSC_EST_DEPT_ORG_SCORE_INFO
                                SET	SCORE_NAME          = @SCORE_NAME
	                                ,MIN_VALUE          = @MIN_VALUE
	                                ,MAX_VALUE          = @MAX_VALUE
	                                ,UPDATE_USER        = @UPDATE_USER
	                                ,UPDATE_DATE        = @UPDATE_DATE
                                WHERE	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID = 0)
                                    AND	 SCORE_CODE      = @SCORE_CODE";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@SCORE_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = score_code;
            paramArray[2]               = CreateDataParameter("@SCORE_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = score_name;
            paramArray[3]               = CreateDataParameter("@MIN_VALUE", SqlDbType.Int);
            paramArray[3].Value         = min_value;
            paramArray[4]               = CreateDataParameter("@MAX_VALUE", SqlDbType.Int);
            paramArray[4].Value         = max_value;
            paramArray[5]               = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[5].Value         = update_user;
            paramArray[6]               = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[6].Value         = update_date;

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

        internal protected DataSet GetEstDeptOrgScoreInfo_Dac(int estterm_ref_id, string score_code)
        {
            string query = @"SELECT	ESTTERM_REF_ID
	                                ,SCORE_CODE
	                                ,SCORE_NAME
	                                ,MIN_VALUE
	                                ,MAX_VALUE
	                                ,CREATE_USER
	                                ,CREATE_DATE
	                                ,UPDATE_USER
	                                ,UPDATE_DATE
                                FROM BSC_EST_DEPT_ORG_SCORE_INFO 
                               WHERE (ESTTERM_REF_ID = CASE WHEN ISNULL(@ESTTERM_REF_ID,0)<1 THEN ESTTERM_REF_ID ELSE @ESTTERM_REF_ID END)
	                             AND (SCORE_CODE  LIKE (@SCORE_CODE " + DbAgentHelper.GetConcatinationChar() + @" '%' ) OR  @SCORE_CODE  =''  )
                               ORDER BY MIN_VALUE DESC";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@SCORE_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = score_code;

            DataSet ds                  = DbAgentObj.FillDataSet(DbAgentHelper.GetQueryStringReplace(query), "ESTDEPTORGSCOREINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }


        internal protected bool IsEstDeptOrgScoreInfo_Dac(int estterm_ref_id
                                                            , string score_code)
        {
            string query = @"SELECT COUNT(*) FROM BSC_EST_DEPT_ORG_SCORE_INFO
		                                        WHERE	    (ESTTERM_REF_ID = @ESTTERM_REF_ID OR @ESTTERM_REF_ID = 0)
                                                        AND	 SCORE_CODE = @SCORE_CODE";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@SCORE_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = score_code;

            try
            {
                int affectedRow = Convert.ToInt32(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text).ToString());
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal protected bool AddEstDeptOrgScoreInfo_Dac(int estterm_ref_id
                                                            , string score_code
                                                            , string score_name
                                                            , int min_value
                                                            , int max_value
                                                            , int create_user
                                                            , DateTime create_date)
        {
            string query = @"
                                    INSERT INTO	BSC_EST_DEPT_ORG_SCORE_INFO(ESTTERM_REF_ID
			                                    ,SCORE_CODE
			                                    ,SCORE_NAME
			                                    ,MIN_VALUE
			                                    ,MAX_VALUE
			                                    ,CREATE_USER
			                                    ,CREATE_DATE
			                                    ,UPDATE_USER
			                                    ,UPDATE_DATE
			                                    )
		                                    VALUES	(@ESTTERM_REF_ID
			                                    ,@SCORE_CODE
			                                    ,@SCORE_NAME
			                                    ,@MIN_VALUE
			                                    ,@MAX_VALUE
			                                    ,@CREATE_USER
			                                    ,@CREATE_DATE
			                                    ,@UPDATE_USER
			                                    ,@UPDATE_DATE
			                                    )
                             ";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@SCORE_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = score_code;
            paramArray[2]               = CreateDataParameter("@SCORE_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = score_name;
            paramArray[3]               = CreateDataParameter("@MIN_VALUE", SqlDbType.Int);
            paramArray[3].Value         = min_value;
            paramArray[4]               = CreateDataParameter("@MAX_VALUE", SqlDbType.Int);
            paramArray[4].Value         = max_value;
            paramArray[5]               = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[5].Value         = create_user;
            paramArray[6]               = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[6].Value         = create_date;
            paramArray[7]               = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[7].Value         = create_user;
            paramArray[8]               = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[8].Value         = create_date;

            try
            {
                int affectedRow = DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal protected bool RemoveEstDeptOrgScoreInfo_Dac(int estterm_ref_id, string score_code)
        {
            string query = @"DELETE BSC_EST_DEPT_ORG_SCORE_INFO
                                WHERE	(ESTTERM_REF_ID  = @ESTTERM_REF_ID  OR @ESTTERM_REF_ID =''    )
	                                AND	(SCORE_CODE     = @SCORE_CODE       OR @SCORE_CODE =''    )";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = estterm_ref_id;
            paramArray[1]               = CreateDataParameter("@SCORE_CODE", SqlDbType.VarChar);
            paramArray[1].Value         = score_code;

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

        internal protected bool DeleteEDOS(object estterm_ref_id, DataTable dtDel)
        {
            string strQuery = @"
DELETE FROM BSC_EST_DEPT_ORG_SCORE_INFO
WHERE   ESTTERM_REF_ID  = @ESTTERM_REF_ID
    AND SCORE_CODE      = @SCORE_CODE
";
            IDbDataParameter[] paramArray;

            foreach (DataRow dr in dtDel.Rows)
            {
                paramArray = null;
                paramArray = CreateDataParameters(2);
                paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
                paramArray[0].Value = estterm_ref_id;
                paramArray[1] = CreateDataParameter("@SCORE_CODE", SqlDbType.VarChar);
                paramArray[1].Value = dr["SCORE_CODE"].ToString();

                if (DbAgentObj.ExecuteNonQuery(strQuery, paramArray, CommandType.Text) == 0)
                    return false;
            }
            return true;
        }

        internal protected bool InsertEDOS(object estterm_ref_id, object score_code, object score_name, object min_value, object max_value, object reg_user)
        {
            string strQuery = @"
IF NOT EXISTS (SELECT ESTTERM_REF_ID FROM BSC_EST_DEPT_ORG_SCORE_INFO WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID AND SCORE_CODE = @SCORE_CODE)
BEGIN
    INSERT INTO BSC_EST_DEPT_ORG_SCORE_INFO
        (ESTTERM_REF_ID, SCORE_CODE, SCORE_NAME, MIN_VALUE, MAX_VALUE, CREATE_USER, CREATE_DATE)
    VALUES
        (@ESTTERM_REF_ID, @SCORE_CODE, @SCORE_NAME, @MIN_VALUE, @MAX_VALUE, @CREATE_USER, GETDATE())
END
";
            IDbDataParameter[] paramArray = CreateDataParameters(6);
            paramArray[0] = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1] = CreateDataParameter("@SCORE_CODE", SqlDbType.VarChar);
            paramArray[1].Value = score_code;
            paramArray[2] = CreateDataParameter("@SCORE_NAME", SqlDbType.VarChar);
            paramArray[2].Value = score_name;
            paramArray[3] = CreateDataParameter("@MIN_VALUE", SqlDbType.Decimal);
            paramArray[3].Value = min_value;
            paramArray[4] = CreateDataParameter("@MAX_VALUE", SqlDbType.Decimal);
            paramArray[4].Value = max_value;
            paramArray[5] = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[5].Value = reg_user;

            if (DbAgentObj.ExecuteNonQuery(strQuery, paramArray, CommandType.Text) > 0)
                return true;
            return false;
        }

        public bool CopyEDOS(IDbConnection conn, IDbTransaction trx, object org_estterm_ref_id, object new_estterm_ref_id, object reg_user)
        {
            // 평가부서는 여러사람이 쓰는 것이 아니므로 동적으로 임시테이블을 만들지 않았음
            string strQuery = @"
IF NOT EXISTS (SELECT * FROM BSC_EST_DEPT_ORG_SCORE_INFO WHERE ESTTERM_REF_ID = @NEW_ESTTERM_REF_ID)
BEGIN
    INSERT INTO BSC_EST_DEPT_ORG_SCORE_INFO
        (ESTTERM_REF_ID, SCORE_CODE, SCORE_NAME, MIN_VALUE, MAX_VALUE, CREATE_USER, CREATE_DATE)
    SELECT
         @NEW_ESTTERM_REF_ID,   SCORE_CODE, SCORE_NAME, MIN_VALUE,  MAX_VALUE,  CREATE_USER,    GETDATE()
    FROM    BSC_EST_DEPT_ORG_SCORE_INFO
    WHERE   ESTTERM_REF_ID  = @ORG_ESTTERM_REF_ID
END
";
            IDbDataParameter[] paramArray = CreateDataParameters(3);
            paramArray[0] = CreateDataParameter("@ORG_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = org_estterm_ref_id;
            paramArray[1] = CreateDataParameter("@NEW_ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = new_estterm_ref_id;
            paramArray[2] = CreateDataParameter("@REG_USER", SqlDbType.Int);
            paramArray[2].Value = reg_user;

            if (DbAgentObj.ExecuteNonQuery(conn, trx, strQuery, paramArray, CommandType.Text) > 0)
                return true;
            return false;
        }
    }
}
