using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_PDTAndAHPStgInfos : DbAgentBase
    {
        public Dac_PDTAndAHPStgInfos()
        {

        }

        public Dac_PDTAndAHPStgInfos(int ver_id, int estterm_ref_id, int stg_ref_id)
        {
            DataSet ds = GetPDTAndAHPStgInfo_Dac(ver_id, estterm_ref_id, stg_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _ver_id         = (dr["VER_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["VER_ID"]);
                _estterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _stg_ref_id     = (dr["STG_REF_ID"]     == DBNull.Value) ? 0 : Convert.ToInt32(dr["STG_REF_ID"]);
                _up_stg_id      = (dr["UP_STG_ID"]      == DBNull.Value) ? 0 : Convert.ToInt32(dr["UP_STG_ID"]);
                _stg_map_yn     = (dr["STG_MAP_YN"]     == DBNull.Value) ? "N" : Convert.ToString(dr["STG_MAP_YN"]);
                _f_yn           = (dr["F_YN"]           == DBNull.Value) ? "N" : Convert.ToString(dr["F_YN"]);
                _c_yn           = (dr["C_YN"]           == DBNull.Value) ? "N" : Convert.ToString(dr["C_YN"]);
                _p_yn           = (dr["P_YN"]           == DBNull.Value) ? "N" : Convert.ToString(dr["P_YN"]);
                _l_yn           = (dr["L_YN"]           == DBNull.Value) ? "N" : Convert.ToString(dr["L_YN"]);
                _stg_note       = (dr["STG_NOTE"]       == DBNull.Value) ? "" : Convert.ToString(dr["STG_NOTE"]);
                _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        #region ============================== [Fields] ==============================

        private int _ver_id;
        private int _estterm_ref_id;
        private int _stg_ref_id;
        private int _up_stg_id;
        private string _stg_map_yn;
        private string _f_yn;
        private string _c_yn;
        private string _p_yn;
        private string _l_yn;
        private string _stg_note;
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

        public int Up_Stg_ID
        {
            get
            {
                return _up_stg_id;
            }
            set
            {
                _up_stg_id = value;
            }
        }

        public string Stg_Map_YN
        {
            get
            {
                return _stg_map_yn;
            }
            set
            {
                if (_stg_map_yn == value)
                    return;
                _stg_map_yn = value;
            }
        }
        public string F_YN
        {
            get
            {
                return _f_yn;
            }
            set
            {
                if (_f_yn == value)
                    return;
                _f_yn = value;
            }
        }
        public string C_YN
        {
            get
            {
                return _c_yn;
            }
            set
            {
                if (_c_yn == value)
                    return;
                _c_yn = value;
            }
        }
        public string P_YN
        {
            get
            {
                return _p_yn;
            }
            set
            {
                if (_p_yn == value)
                    return;
                _p_yn = value;
            }
        }
        public string L_YN
        {
            get
            {
                return _l_yn;
            }
            set
            {
                if (_l_yn == value)
                    return;
                _l_yn = value;
            }
        }

        public string Stg_Note
        {
            get
            {
                return _stg_note;
            }
            set
            {
                _stg_note = (value == null ? "" : value);
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

        protected internal bool ModifyPDTAndAHPStgInfo_Dac(int ver_id
                                            , int estterm_ref_id
                                            , int stg_ref_id
                                            , int up_stg_id
                                            , string stg_note
                                            , DateTime update_date
                                            , int update_user)
        {
            string query = @"UPDATE	BSC_PDT_AHP_STG_INFO
                                SET	UP_STG_ID       = @UP_STG_ID
	                                ,STG_NOTE       = @STG_NOTE
	                                ,UPDATE_DATE    = @UPDATE_DATE
	                                ,UPDATE_USER    = @UPDATE_USER
                                WHERE	VER_ID      = @VER_ID
                                AND	ESTTERM_REF_ID  = @ESTTERM_REF_ID
                                AND	STG_REF_ID      = @STG_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_ref_id;
            paramArray[3]               = CreateDataParameter("@UP_STG_ID", SqlDbType.Int);
            paramArray[3].Value         = up_stg_id;
            paramArray[4]               = CreateDataParameter("@STG_NOTE", SqlDbType.VarChar);
            paramArray[4].Value         = stg_note;
            paramArray[5]               = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[5].Value         = update_date;
            paramArray[6]               = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[6].Value         = update_user;

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

        protected internal DataSet GetPDTAndAHPStgInfo_Dac(int ver_id, int estterm_ref_id, int stg_ref_id)
        {
            string query = @"SELECT	A.VER_ID
                                    ,A.ESTTERM_REF_ID
                                    ,A.STG_REF_ID
                                    ,A.UP_STG_ID
                                    ,A.STG_MAP_YN
                                    ,A.F_YN
                                    ,A.C_YN
                                    ,A.P_YN
                                    ,A.L_YN
                                    ,A.STG_NOTE
                                    ,A.CREATE_DATE
                                    ,A.CREATE_USER
                                    ,A.UPDATE_DATE
                                    ,A.UPDATE_USER
		                            ,B.STG_CODE
		                            ,B.STG_NAME
		                            ,B.STG_SET_DESC
		                            ,B.STG_ETC
                                FROM	    BSC_PDT_AHP_STG_INFO    A
		                            JOIN    BSC_STG_INFO            B ON (	A.STG_REF_ID		= B.STG_REF_ID 
								                                        AND A.ESTTERM_REF_ID	= B.ESTTERM_REF_ID)
                                    WHERE	(A.VER_ID         = @VER_ID           OR @VER_ID          = 0)
	                                    AND	(A.ESTTERM_REF_ID = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
	                                    AND	(A.STG_REF_ID     = @STG_REF_ID       OR @STG_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "PDTAHPSTGINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        protected internal bool AddPDTAndAHPStgInfo_Dac(IDbConnection conn
                                                        , IDbTransaction trx
                                                        , int ver_id
                                                        , int estterm_ref_id
                                                        , int stg_ref_id
                                                        , int up_stg_id
                                                        , string stg_map_yn
                                                        , string f_yn
                                                        , string c_yn
                                                        , string p_yn
                                                        , string l_yn
                                                        , string stg_note
                                                        , DateTime create_date
                                                        , int create_user)
        {
            string query = @"

                            IF EXISTS (SELECT * FROM BSC_PDT_AHP_STG_INFO
                                            WHERE	VER_ID         = @VER_ID
	                                            AND	ESTTERM_REF_ID = @ESTTERM_REF_ID
	                                            AND	STG_REF_ID     = @STG_REF_ID) 
                            BEGIN
                                
                                UPDATE BSC_PDT_AHP_STG_INFO
                                    SET STG_MAP_YN              = @STG_MAP_YN
                                        ,F_YN                   = @F_YN
                                        ,C_YN                   = @C_YN
                                        ,P_YN                   = @P_YN
                                        ,L_YN                   = @L_YN
                                        ,STG_NOTE               = @STG_NOTE
                                        ,UPDATE_DATE            = GETDATE()
                                        ,UPDATE_USER            = @CREATE_USER
                                    WHERE	VER_ID              = @VER_ID
	                                        AND	ESTTERM_REF_ID  = @ESTTERM_REF_ID
	                                        AND	STG_REF_ID      = @STG_REF_ID
                            END
                            ELSE
                            BEGIN

                                INSERT INTO BSC_PDT_AHP_STG_INFO(VER_ID
			                                                ,ESTTERM_REF_ID
			                                                ,STG_REF_ID
			                                                ,UP_STG_ID
                                                            ,STG_MAP_YN
                                                            ,F_YN
                                                            ,C_YN
                                                            ,P_YN
                                                            ,L_YN
			                                                ,STG_NOTE
			                                                ,CREATE_DATE
			                                                ,CREATE_USER
			                                                ,UPDATE_DATE
			                                                ,UPDATE_USER
			                                                )
		                                                VALUES	(@VER_ID
			                                                ,@ESTTERM_REF_ID
			                                                ,@STG_REF_ID
			                                                ,@UP_STG_ID
                                                            ,@STG_MAP_YN
                                                            ,@F_YN
                                                            ,@C_YN
                                                            ,@P_YN
                                                            ,@L_YN
			                                                ,@STG_NOTE
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                ,@CREATE_DATE
			                                                ,@CREATE_USER
			                                                )
                            END
                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(12);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_ref_id;
            paramArray[3]               = CreateDataParameter("@UP_STG_ID", SqlDbType.Int);
            paramArray[3].Value         = up_stg_id;
            paramArray[4]               = CreateDataParameter("@STG_MAP_YN", SqlDbType.Char);
            paramArray[4].Value         = stg_map_yn;
            paramArray[5]               = CreateDataParameter("@F_YN", SqlDbType.Char);
            paramArray[5].Value         = f_yn;
            paramArray[6]               = CreateDataParameter("@C_YN", SqlDbType.Char);
            paramArray[6].Value         = c_yn;
            paramArray[7]               = CreateDataParameter("@P_YN", SqlDbType.Char);
            paramArray[7].Value         = p_yn;
            paramArray[8]               = CreateDataParameter("@L_YN", SqlDbType.Char);
            paramArray[8].Value         = l_yn;
            paramArray[9]               = CreateDataParameter("@STG_NOTE", SqlDbType.VarChar);
            paramArray[9].Value         = stg_note;
            paramArray[10]              = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[10].Value        = create_date;
            paramArray[11]              = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[11].Value        = create_user;

            int affectedRow             = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
            return (affectedRow > 0) ? true : false;

            //try
            //{
            //    int affectedRow = DbAgentObj.ExecuteNonQuery(conn, trx, query, paramArray, CommandType.Text);
            //    return (affectedRow > 0) ? true : false;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("ERROR - AddPDTAndAHPStgInfo \n" + ex.Message);
            //}
        }

        protected internal bool RemovePDTAndAHPStgInfo_Dac(IDbConnection conn
                                                            , IDbTransaction trx
                                                            , int ver_id
                                                            , int estterm_ref_id
                                                            , int stg_ref_id)
        {
            string query = @"DELETE	BSC_PDT_AHP_STG_INFO
                                WHERE	(VER_ID         = @VER_ID           OR @VER_ID          = 0)
	                                AND	(ESTTERM_REF_ID = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
	                                AND	(STG_REF_ID     = @STG_REF_ID       OR @STG_REF_ID      = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@STG_REF_ID", SqlDbType.Int);
            paramArray[2].Value         = stg_ref_id;

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
