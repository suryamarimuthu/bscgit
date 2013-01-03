using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_AHPEstDeptStgDatas : DbAgentBase
    {
        public Dac_AHPEstDeptStgDatas()
        {

        }

        protected internal Dac_AHPEstDeptStgDatas(int ver_id
                                                , int estterm_ref_id
                                                , int est_dept_ref_id
                                                , int l_stg_ref_id
                                                , int r_stg_ref_id)
        {
            DataSet ds = GetAHPEstDeptStgData_Dac(ver_id
                                                , estterm_ref_id
                                                , est_dept_ref_id
                                                , l_stg_ref_id
                                                , r_stg_ref_id);
	        DataRow dr;
         
	        if(ds.Tables[0].Rows.Count == 1)
	        {
		        dr                  = ds.Tables[0].Rows[0];
		        _ver_id             = (dr["VER_ID"]             == DBNull.Value) ? 0 : Convert.ToInt32(dr["VER_ID"]);
		        _estterm_ref_id     = (dr["ESTTERM_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
		        _est_dept_ref_id    = (dr["EST_DEPT_REF_ID"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["EST_DEPT_REF_ID"]);
		        _l_stg_ref_id       = (dr["L_STG_REF_ID"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["L_STG_REF_ID"]);
		        _r_stg_ref_id       = (dr["R_STG_REF_ID"]       == DBNull.Value) ? 0 : Convert.ToInt32(dr["R_STG_REF_ID"]);
		        _l_point            = (dr["L_POINT"]            == DBNull.Value) ? 0 : Convert.ToSingle(dr["L_POINT"]);
		        _s_point            = (dr["S_POINT"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["S_POINT"]);
		        _r_point            = (dr["R_POINT"]            == DBNull.Value) ? 0 : Convert.ToSingle(dr["R_POINT"]);
	        }
 
        }

        #region ============================== [Fields] ==============================

        private int _ver_id;
        private int _estterm_ref_id;
        private int _est_dept_ref_id;
        private int _l_stg_ref_id;
        private int _r_stg_ref_id;
        private float _l_point;
        private int _s_point;
        private float _r_point;
        private int _user;
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

        public int L_Stg_Ref_ID
        {
            get
            {
                return _l_stg_ref_id;
            }
            set
            {
                _l_stg_ref_id = value;
            }
        }

        public int R_Stg_Ref_ID
        {
            get
            {
                return _r_stg_ref_id;
            }
            set
            {
                _r_stg_ref_id = value;
            }
        }

        public float L_Point
        {
            get
            {
                return _l_point;
            }
            set
            {
                _l_point = value;
            }
        }

        public int S_Point
        {
            get
            {
                return _s_point;
            }
            set
            {
                _s_point = value;
            }
        }

        public float R_Point
        {
            get
            {
                return _r_point;
            }
            set
            {
                _r_point = value;
            }
        }

        #endregion

        protected internal bool ModifyAHPEstDeptStgData_Dac(IDbConnection conn
                                                            , IDbTransaction trx
                                                            , int ver_id
                                                            , int estterm_ref_id
                                                            , int est_dept_ref_id
                                                            , int l_stg_ref_id
                                                            , int r_stg_ref_id
                                                            , float l_point
                                                            , int s_point
                                                            , float r_point
                                                            , int user)
        {
            string query = @"UPDATE	BSC_AHP_EST_DEPT_STG_DATA
	                            SET	L_POINT			= @L_POINT
		                            ,S_POINT		= @S_POINT
		                            ,R_POINT		= @R_POINT
		                            ,UPDATE_USER	= @USER
		                            ,UPDATE_DATE	= GETDATE()
	                            WHERE	VER_ID		= @VER_ID
	                            AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
	                            AND	EST_DEPT_REF_ID = @EST_DEPT_REF_ID
	                            AND	L_STG_REF_ID	= @L_STG_REF_ID
	                            AND	R_STG_REF_ID	= @R_STG_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]       = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value = ver_id;
            paramArray[1]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value = estterm_ref_id;
            paramArray[2]       = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value = est_dept_ref_id;
            paramArray[3]       = CreateDataParameter("@L_STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value = l_stg_ref_id;
            paramArray[4]       = CreateDataParameter("@R_STG_REF_ID", SqlDbType.Int);
            paramArray[4].Value = r_stg_ref_id;
            paramArray[5]       = CreateDataParameter("@L_POINT", SqlDbType.Float);
            paramArray[5].Value = l_point;
            paramArray[6]       = CreateDataParameter("@S_POINT", SqlDbType.Int);
            paramArray[6].Value = s_point;
            paramArray[7]       = CreateDataParameter("@R_POINT", SqlDbType.Float);
            paramArray[7].Value = r_point;
            paramArray[8]       = CreateDataParameter("@USER", SqlDbType.Int);
            paramArray[8].Value = user;

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

        protected internal DataSet GetAHPEstDeptStgData_Dac(int ver_id
                                                            , int estterm_ref_id
                                                            , int est_dept_ref_id
                                                            , int l_stg_ref_id
                                                            , int r_stg_ref_id)
        {
            string query = @"SELECT	VER_ID
	                                ,ESTTERM_REF_ID
	                                ,EST_DEPT_REF_ID
	                                ,L_STG_REF_ID
	                                ,R_STG_REF_ID
	                                ,L_POINT
	                                ,S_POINT
	                                ,R_POINT
	                                ,CREATE_USER
	                                ,CREATE_DATE
	                                ,UPDATE_USER
	                                ,UPDATE_DATE
                                FROM	BSC_AHP_EST_DEPT_STG_DATA 
	                                WHERE	(VER_ID         = @VER_ID           OR @VER_ID          = 0)
		                                AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
		                                AND	EST_DEPT_REF_ID = @EST_DEPT_REF_ID  OR @EST_DEPT_REF_ID = 0)
		                                AND	L_STG_REF_ID	= @L_STG_REF_ID     OR @L_STG_REF_ID    = 0)
		                                AND	R_STG_REF_ID	= @R_STG_REF_ID     OR @R_STG_REF_ID    = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@L_STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = l_stg_ref_id;
            paramArray[4]               = CreateDataParameter("@R_STG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = r_stg_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "AHPESTDEPTSTGDATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        protected internal DataSet GetAHPEstDeptStgPoint_Dac(int ver_id
                                                            , int estterm_ref_id
                                                            , int est_dept_ref_id
                                                            , int stg_ref_id)
        {
            string query = @"SELECT VER_ID
		                            , ESTTERM_REF_ID
		                            , EST_DEPT_REF_ID
		                            , L_STG_REF_ID
		                            , R_STG_REF_ID
		                            , L_POINT
		                            , S_POINT
		                            , R_POINT
		                            , CREATE_USER
		                            , CREATE_DATE
		                            , UPDATE_USER
		                            , UPDATE_DATE
		                            , CASE WHEN L_STG_REF_ID = @STG_REF_ID THEN L_POINT ELSE R_POINT END AS L_R_POINT 
		                            FROM BSC_AHP_EST_DEPT_STG_DATA
			                            WHERE	(VER_ID				= @VER_ID			OR @VER_ID			= 0)
				                            AND (ESTTERM_REF_ID		= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
				                            AND (EST_DEPT_REF_ID	= @EST_DEPT_REF_ID	OR @EST_DEPT_REF_ID = 0)
				                            AND (L_STG_REF_ID		= @STG_REF_ID		OR R_STG_REF_ID		= @STG_REF_ID)";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "AHPESTDEPTSTGDATAGET", null, paramArray, CommandType.Text);
            return ds;
        }

        protected internal float GetAHPEstDeptStgHorizonPoint_Dac(int ver_id
                                                                , int estterm_ref_id
                                                                , int est_dept_ref_id
                                                                , int stg_ref_id
                                                                , int target_stg_ref_id)
        {
            string query = @"SELECT L_R_POINT 
	                                FROM (SELECT VER_ID
				                                , ESTTERM_REF_ID
				                                , EST_DEPT_REF_ID
				                                , L_STG_REF_ID
				                                , R_STG_REF_ID
				                                , L_POINT
				                                , S_POINT
				                                , R_POINT
				                                , CREATE_USER
				                                , CREATE_DATE
				                                , UPDATE_USER
				                                , UPDATE_DATE
				                                , CASE WHEN L_STG_REF_ID = @STG_REF_ID THEN L_POINT ELSE R_POINT END AS L_R_POINT 
				                                FROM BSC_AHP_EST_DEPT_STG_DATA
					                                WHERE	(VER_ID				= @VER_ID			OR @VER_ID			= 0)
						                                AND (ESTTERM_REF_ID		= @ESTTERM_REF_ID	OR @ESTTERM_REF_ID	= 0)
						                                AND (EST_DEPT_REF_ID	= @EST_DEPT_REF_ID	OR @EST_DEPT_REF_ID = 0)
						                                AND (L_STG_REF_ID		= @STG_REF_ID		OR R_STG_REF_ID		= @STG_REF_ID)) T
		                                WHERE               (L_STG_REF_ID		= @T_STG_REF_ID		OR R_STG_REF_ID		= @T_STG_REF_ID)";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = stg_ref_id;
            paramArray[4]               = CreateDataParameter("@T_STG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = target_stg_ref_id;

            try
            {
                float affectedRow       = Convert.ToSingle(DbAgentObj.ExecuteScalar(query, paramArray, CommandType.Text));
                return affectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected internal bool IsAHPEstDeptStgData_Dac(int ver_id
                                                        , int estterm_ref_id
                                                        , int est_dept_ref_id
                                                        , int l_stg_ref_id
                                                        , int r_stg_ref_id)
        {
            string query = @"SELECT COUNT(*) FROM BSC_AHP_EST_DEPT_STG_DATA
				                                WHERE	VER_ID          = @VER_ID
					                                AND	ESTTERM_REF_ID	= @ESTTERM_REF_ID
					                                AND	EST_DEPT_REF_ID = @EST_DEPT_REF_ID
					                                AND	L_STG_REF_ID	= @L_STG_REF_ID
					                                AND	R_STG_REF_ID	= @R_STG_REF_ID
			                                ";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@L_STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = l_stg_ref_id;
            paramArray[4]               = CreateDataParameter("@R_STG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = r_stg_ref_id;

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


        protected internal bool AddAHPEstDeptStgData_Dac(IDbConnection conn
                                                        , IDbTransaction trx
                                                        , int ver_id
                                                        , int estterm_ref_id
                                                        , int est_dept_ref_id
                                                        , int l_stg_ref_id
                                                        , int r_stg_ref_id
                                                        , float l_point
                                                        , int s_point
                                                        , float r_point
                                                        , int user)
        {
            string query = @"INSERT INTO BSC_AHP_EST_DEPT_STG_DATA(VER_ID
			                                                        ,ESTTERM_REF_ID
			                                                        ,EST_DEPT_REF_ID
			                                                        ,L_STG_REF_ID
			                                                        ,R_STG_REF_ID
			                                                        ,L_POINT
			                                                        ,S_POINT
			                                                        ,R_POINT
			                                                        ,CREATE_USER
			                                                        ,CREATE_DATE
			                                                        ,UPDATE_USER
			                                                        ,UPDATE_DATE
			                                                        )
		                                                        VALUES	(@VER_ID
			                                                        ,@ESTTERM_REF_ID
			                                                        ,@EST_DEPT_REF_ID
			                                                        ,@L_STG_REF_ID
			                                                        ,@R_STG_REF_ID
			                                                        ,@L_POINT
			                                                        ,@S_POINT
			                                                        ,@R_POINT
			                                                        ,@USER
			                                                        ,GETDATE()
			                                                        ,@USER
			                                                        ,GETDATE()
			                                                        )
                             ";

            IDbDataParameter[] paramArray = CreateDataParameters(9);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@L_STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = l_stg_ref_id;
            paramArray[4]               = CreateDataParameter("@R_STG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = r_stg_ref_id;
            paramArray[5]               = CreateDataParameter("@L_POINT", SqlDbType.Float);
            paramArray[5].Value         = l_point;
            paramArray[6]               = CreateDataParameter("@S_POINT", SqlDbType.Float);
            paramArray[6].Value         = s_point;
            paramArray[7]               = CreateDataParameter("@R_POINT", SqlDbType.Float);
            paramArray[7].Value         = r_point;
            paramArray[8]               = CreateDataParameter("@USER", SqlDbType.Int);
            paramArray[8].Value         = user;

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

        protected internal bool RemoveAHPEstDeptStgData_Dac(IDbConnection conn
                                                            , IDbTransaction trx
                                                            , int ver_id
                                                            , int estterm_ref_id
                                                            , int est_dept_ref_id
                                                            , int l_stg_ref_id
                                                            , int r_stg_ref_id)
        {
            string query = @"DELETE	BSC_AHP_EST_DEPT_STG_DATA
	                            WHERE	(VER_ID			    = @VER_ID           OR @VER_ID          = 0)
		                            AND	(ESTTERM_REF_ID	    = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
		                            AND	(EST_DEPT_REF_ID    = @EST_DEPT_REF_ID  OR @EST_DEPT_REF_ID = 0)
		                            AND	(L_STG_REF_ID	    = @L_STG_REF_ID     OR @L_STG_REF_ID    = 0)
		                            AND	(R_STG_REF_ID	    = @R_STG_REF_ID     OR @R_STG_REF_ID    = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@EST_DEPT_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = est_dept_ref_id;
            paramArray[3]               = CreateDataParameter("@L_STG_REF_ID", SqlDbType.Int);
            paramArray[3].Value         = l_stg_ref_id;
            paramArray[4]               = CreateDataParameter("@R_STG_REF_ID", SqlDbType.Int);
            paramArray[4].Value         = r_stg_ref_id;

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
    }
}
