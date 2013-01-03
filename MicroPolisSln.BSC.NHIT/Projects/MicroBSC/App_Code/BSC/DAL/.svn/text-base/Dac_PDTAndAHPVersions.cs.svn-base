using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using MicroBSC.Data;

namespace MicroBSC.Biz.BSC.Dac
{
    public class Dac_PDTAndAHPVersions : DbAgentBase
    {
        public Dac_PDTAndAHPVersions()
        {

        }

        public Dac_PDTAndAHPVersions(int ver_id, int estterm_ref_id)
        {
            DataSet ds = GetPDTAndAhpVersion_Dac(ver_id, estterm_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr              = ds.Tables[0].Rows[0];
                _ver_id         = (dr["VER_ID"]         == DBNull.Value) ? 0 : Convert.ToInt32(dr["VER_ID"]);
                _estterm_ref_id = (dr["ESTTERM_REF_ID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["ESTTERM_REF_ID"]);
                _ver_name       = (dr["VER_NAME"]       == DBNull.Value) ? "" : Convert.ToString(dr["VER_NAME"]);
                _ver_desc       = (dr["VER_DESC"]       == DBNull.Value) ? "" : Convert.ToString(dr["VER_DESC"]);
                _create_date    = (dr["CREATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["CREATE_DATE"]);
                _create_user    = (dr["CREATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["CREATE_USER"]);
                _update_date    = (dr["UPDATE_DATE"]    == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(dr["UPDATE_DATE"]);
                _update_user    = (dr["UPDATE_USER"]    == DBNull.Value) ? 0 : Convert.ToInt32(dr["UPDATE_USER"]);
            }
        }

        #region ============================== [Fields] ==============================

        private int _ver_id;
        private int _estterm_ref_id;
        private string _ver_name;
        private string _ver_desc;
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
                if (_estterm_ref_id == value)
                    return;
                _estterm_ref_id = value;
            }
        }

        public string Ver_Name
        {
            get
            {
                return _ver_name;
            }
            set
            {
                _ver_name = (value == null ? "" : value);
            }
        }

        public string Ver_Desc
        {
            get
            {
                return _ver_desc;
            }
            set
            {
                _ver_desc = (value == null ? "" : value);
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

        protected internal bool ModifyPDTAndAHPVersion_Dac(int ver_id
                                                            , int estterm_ref_id
                                                            , string ver_name
                                                            , string ver_desc
                                                            , DateTime update_date
                                                            , int update_user)
        {
            string query = @"UPDATE	BSC_PDT_AHP_VERSION
                                SET	 VER_NAME               = @VER_NAME
	                                ,VER_DESC               = @VER_DESC
	                                ,UPDATE_DATE            = @UPDATE_DATE
	                                ,UPDATE_USER            = @UPDATE_USER
                                WHERE	VER_ID              = @VER_ID
                                        AND ESTTERM_REF_ID  = @ESTTERM_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;
            paramArray[2]               = CreateDataParameter("@VER_NAME", SqlDbType.VarChar);
            paramArray[2].Value         = ver_name;
            paramArray[3]               = CreateDataParameter("@VER_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = ver_desc;
            paramArray[4]               = CreateDataParameter("@UPDATE_DATE", SqlDbType.DateTime);
            paramArray[4].Value         = update_date;
            paramArray[5]               = CreateDataParameter("@UPDATE_USER", SqlDbType.Int);
            paramArray[5].Value         = update_user;

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

        protected internal DataSet GetPDTAndAhpVersion_Dac(int ver_id, int estterm_ref_id)
        {
            string query = @"SELECT	VER_ID
                                    ,ESTTERM_REF_ID
	                                ,VER_NAME
	                                ,VER_DESC
	                                ,CREATE_DATE
	                                ,CREATE_USER
	                                ,UPDATE_DATE
	                                ,UPDATE_USER
                                FROM	BSC_PDT_AHP_VERSION 
                                    WHERE	    (VER_ID         = @VER_ID           OR @VER_ID          = 0)
                                            AND	(ESTTERM_REF_ID = @ESTTERM_REF_ID   OR @ESTTERM_REF_ID  = 0)
                                ORDER BY VER_ID DESC";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "PDTAHPVERSIONGET", null, paramArray, CommandType.Text);
            return ds;
        }

        protected internal bool AddPDTAndAHPVersion_Dac(int estterm_ref_id
                                                        , string ver_name
                                                        , string ver_desc
                                                        , DateTime create_date
                                                        , int create_user)
        {
            string query = @"
                            DECLARE @VER_ID int
                            
                            SELECT @VER_ID = MAX(VER_ID) FROM BSC_PDT_AHP_VERSION WITH (XLOCK)
	                            WHERE ESTTERM_REF_ID = @ESTTERM_REF_ID

                            IF @VER_ID IS NULL 
	                            SET @VER_ID = 1
                            ELSE
	                            SET @VER_ID = @VER_ID + 1

                            INSERT INTO BSC_PDT_AHP_VERSION(VER_ID
                                                            ,ESTTERM_REF_ID
                                                            ,VER_NAME
		                                                    ,VER_DESC
		                                                    ,CREATE_DATE
		                                                    ,CREATE_USER
		                                                    ,UPDATE_DATE
		                                                    ,UPDATE_USER
		                                                    )
	                                                    VALUES	(@VER_ID
                                                            ,@ESTTERM_REF_ID
                                                            ,@VER_NAME
		                                                    ,@VER_DESC
		                                                    ,@CREATE_DATE
		                                                    ,@CREATE_USER
		                                                    ,@CREATE_DATE
		                                                    ,@CREATE_USER
		                                                    )";

            IDbDataParameter[] paramArray = CreateDataParameters(5);

            paramArray[0]       = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[0].Value = estterm_ref_id;
            paramArray[1]       = CreateDataParameter("@VER_NAME", SqlDbType.VarChar);
            paramArray[1].Value = ver_name;
            paramArray[2]       = CreateDataParameter("@VER_DESC", SqlDbType.VarChar);
            paramArray[2].Value = ver_desc;
            paramArray[3]       = CreateDataParameter("@CREATE_DATE", SqlDbType.DateTime);
            paramArray[3].Value = create_date;
            paramArray[4]       = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[4].Value = create_user;


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

        protected internal bool RemovePDAAndAHPVersion_Dac(IDbConnection conn
                                                            , IDbTransaction trx
                                                            , int ver_id
                                                            , int estterm_ref_id)
        {
            string query = @"DELETE	BSC_PDT_AHP_VERSION
                                WHERE	VER_ID          = @VER_ID
                                    AND ESTTERM_REF_ID  = @ESTTERM_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@VER_ID", SqlDbType.Int);
            paramArray[0].Value         = ver_id;
            paramArray[1]               = CreateDataParameter("@ESTTERM_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = estterm_ref_id;

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
