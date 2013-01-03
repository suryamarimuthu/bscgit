using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class UnitTypeInfos : DbAgentBase
    {
        public UnitTypeInfos()
        {
        }

        public UnitTypeInfos(int unit_type_ref_id)
        {
            DataSet ds = GetUnitTypeInfo(unit_type_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                
                _unit_type_ref_id   = (dr["UNIT_TYPE_REF_ID"] == DBNull.Value)  ? 0  : Convert.ToInt32(dr["UNIT_TYPE_REF_ID"]);
                _unit_type          = (dr["UNIT_TYPE"] == DBNull.Value)         ? "" : Convert.ToString(dr["UNIT_TYPE"]);
                _unit               = (dr["UNIT"] == DBNull.Value)              ? "" : Convert.ToString(dr["UNIT"]);
                _format_string      = (dr["FORMAT_STRING"] == DBNull.Value)     ? "" : Convert.ToString(dr["FORMAT_STRING"]);
                _decimal_point      = (dr["DECIMAL_POINT"] == DBNull.Value)     ? 0  : Convert.ToInt32(dr["DECIMAL_POINT"]);
                _rounding_type      = (dr["ROUNDING_TYPE"] == DBNull.Value)     ? "" : Convert.ToString(dr["ROUNDING_TYPE"]);
                _use_yn             = (dr["USE_YN"] == DBNull.Value)            ? "" : Convert.ToString(dr["USE_YN"]);
            }
        }

        public UnitTypeInfos(string unit_type)
        {
            DataSet ds = GetAllUnitTypeInfo(unit_type);

            if (ds.Tables[0].Rows.Count > 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
               
                _unit_type_ref_id   = (dr["UNIT_TYPE_REF_ID"] == DBNull.Value)  ? 0  : Convert.ToInt32(dr["UNIT_TYPE_REF_ID"]);
                _unit               = (dr["UNIT"] == DBNull.Value)              ? "" : Convert.ToString(dr["UNIT"]);
                _format_string      = (dr["FORMAT_STRING"] == DBNull.Value)     ? "" : Convert.ToString(dr["FORMAT_STRING"]);
                _decimal_point      = (dr["DECIMAL_POINT"] == DBNull.Value)     ? 0  : Convert.ToInt32(dr["DECIMAL_POINT"]);
                _rounding_type      = (dr["ROUNDING_TYPE"] == DBNull.Value)     ? "" : Convert.ToString(dr["ROUNDING_TYPE"]);
                _use_yn             = (dr["USE_YN"] == DBNull.Value)            ? "" : Convert.ToString(dr["USE_YN"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private int     _unit_type_ref_id;
        private string  _unit_type;
        private string  _unit;
        private string  _format_string;
        private int     _decimal_point;
        private string  _rounding_type;
        private string  _use_yn;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int Unit_Type_Ref_ID
        {
            get
            {
                return _unit_type_ref_id;
            }
            set
            {
                _unit_type_ref_id = value;
            }
        }

        public string Unit_Type
        {
            get
            {
                return _unit_type;
            }
            set
            {
                _unit_type = (value == null ? "" : value);
            }
        }

        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = (value == null ? "" : value);
            }
        }
        public string Format_String
        {
            get 
            {
                return _format_string;
            }
            set 
            {
                _format_string = (value == null ? "" : value);
            }
        }
        public int Decimal_Point
        {
            get
            {
                return _decimal_point;
            }
            set
            {
                _decimal_point = value;
            }
        }
        public string Rounding_Type
        {
            get
            {
                return _rounding_type;
            }
            set
            {
                _rounding_type = (value == null ? "" : value);
            }
        }
        public string Use_Yn
        {
            get 
            {
                return _use_yn;
            }
            set
            {
                _use_yn = (value == null ? "" : value);
            }
        }
        #endregion

        public bool ModifyUnitTypeInfo(string unit_type, string unit, string format, int dec_point, string rounding, string use, int user, int unit_type_ref_id)
        {
            string s_query = @"UPDATE COM_UNIT_TYPE_INFO
                                SET UNIT_TYPE           = @UNIT_TYPE
                                   ,UNIT                = @UNIT
                                   ,FORMAT_STRING       = CASE @FORMAT_STRING WHEN '' THEN NULL ELSE @FORMAT_STRING END
                                   ,DECIMAL_POINT       = @DECIMAL_POINT
                                   ,ROUNDING_TYPE       = CASE @ROUNDING_TYPE WHEN '' THEN NULL ELSE @ROUNDING_TYPE END
                                   ,USE_YN              = @USE_YN
                                   ,UPDATE_DATE         = GETDATE()
                                   ,UPDATE_USER         = @UPDATE_USER
                              WHERE UNIT_TYPE_REF_ID    = @UNIT_TYPE_REF_ID";

            string o_query = @"UPDATE COM_UNIT_TYPE_INFO
                                SET UNIT_TYPE           = @UNIT_TYPE
                                   ,UNIT                = @UNIT
                                   ,FORMAT_STRING       = CASE @FORMAT_STRING WHEN '' THEN NULL ELSE @FORMAT_STRING END
                                   ,DECIMAL_POINT       = @DECIMAL_POINT
                                   ,ROUNDING_TYPE       = CASE @ROUNDING_TYPE WHEN '' THEN NULL ELSE @ROUNDING_TYPE END
                                   ,USE_YN              = @USE_YN
                                   ,UPDATE_DATE         = SYSDATE
                                   ,UPDATE_USER         = @UPDATE_USER
                              WHERE UNIT_TYPE_REF_ID    = @UNIT_TYPE_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(8);

            paramArray[0]               = CreateDataParameter("@UNIT_TYPE", SqlDbType.VarChar);
            paramArray[0].Value         = unit_type;
            paramArray[1]               = CreateDataParameter("@UNIT", SqlDbType.VarChar);
            paramArray[1].Value         = unit;
            paramArray[2]               = CreateDataParameter("@FORMAT_STRING", SqlDbType.VarChar);
            paramArray[2].Value         = format;
            paramArray[3]               = CreateDataParameter("@DECIMAL_POINT", SqlDbType.Int);
            paramArray[3].Value         = dec_point;
            paramArray[4]               = CreateDataParameter("@ROUNDING_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = rounding;
            paramArray[5]               = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[5].Value         = use;
            paramArray[6]               = CreateDataParameter("@UPDATE_USER", SqlDbType.VarChar);
            paramArray[6].Value         = user;
            paramArray[7]               = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[7].Value         = unit_type_ref_id;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModifyUnitTypeGroup(string unit_type_modify, string unit_type)
        {
            string query = @"UPDATE COM_UNIT_TYPE_INFO
                                SET UNIT_TYPE = @UNIT_TYPE_MODIFY
                              WHERE UNIT_TYPE = @UNIT_TYPE";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@UNIT_TYPE_MODIFY", SqlDbType.VarChar);
            paramArray[0].Value         = unit_type_modify;
            paramArray[1]               = CreateDataParameter("@UNIT_TYPE", SqlDbType.VarChar);
            paramArray[1].Value         = unit_type;

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

        public DataSet GetUnitTypeGroup()
        {
            string query = @"SELECT UNIT_TYPE
                               FROM COM_UNIT_TYPE_INFO
                           GROUP BY UNIT_TYPE";

            DataSet ds = DbAgentObj.FillDataSet(query, "UNITTYPEINFOGET");
            return ds;
        }

        public DataSet GetUnitTypeInfo(int unit_type_ref_id)
        {
            string query = @"SELECT UNIT_TYPE_REF_ID
	                               ,UNIT_TYPE
                                   ,UNIT
                                   ,FORMAT_STRING
                                   ,DECIMAL_POINT
                                   ,ROUNDING_TYPE
                                   ,USE_YN
                               FROM COM_UNIT_TYPE_INFO
                              WHERE UNIT_TYPE_REF_ID = @UNIT_TYPE_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = unit_type_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "UNITTYPEGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetAllUnitTypeInfo(string unit_type)
        {
            string query = @"SELECT UNIT_TYPE_REF_ID
                                  ,UNIT
                                  ,FORMAT_STRING
                                  ,DECIMAL_POINT
                                  ,ROUNDING_TYPE
                                  ,USE_YN
                              FROM COM_UNIT_TYPE_INFO
                             WHERE UNIT_TYPE = @UNIT_TYPE";
            
            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@UNIT_TYPE", SqlDbType.VarChar);
            paramArray[0].Value         = unit_type;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "UNITTYPEGETALL", null, paramArray, CommandType.Text);
            return ds;
        }

        public bool RemoveUnitTypeGroup(string unit_type)
        {
            string query = @"DELETE COM_UNIT_TYPE_INFO
                              WHERE UNIT_TYPE = @UNIT_TYPE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@UNIT_TYPE", SqlDbType.VarChar);
            paramArray[0].Value         = unit_type;

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

        public int NewUnitTypeInfoRefID()
        {
            string s_query = @"SELECT ISNULL(MAX(UNIT_TYPE_REF_ID),0)+1 
                               FROM COM_UNIT_TYPE_INFO";

            string o_query = @"SELECT NVL(MAX(UNIT_TYPE_REF_ID),0)+1 
                               FROM COM_UNIT_TYPE_INFO";

            DataSet ds = DbAgentObj.FillDataSet(GetQueryStringByDb(s_query, o_query), "UNITTYPEINFOREFID");
            int result = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return result;
        }

        public bool AddNewUnitTypeInfo(string unit_type, string unit, string format, int dec_point, string rounding, string use, int user)
        {
            string s_query = @"
                                INSERT INTO COM_UNIT_TYPE_INFO 
                                    (UNIT_TYPE_REF_ID,UNIT_TYPE,UNIT,FORMAT_STRING,DECIMAL_POINT,ROUNDING_TYPE,USE_YN,CREATE_DATE,CREATE_USER)
                                VALUES
                                    ( " + NewUnitTypeInfoRefID() +
                                      @",@UNIT_TYPE,@UNIT,@FORMAT_STRING,@DECIMAL_POINT,@ROUNDING_TYPE,@USE_YN,GETDATE(),@CREATE_USER)";

            string o_query = @"
                                INSERT INTO COM_UNIT_TYPE_INFO 
                                    (UNIT_TYPE_REF_ID,UNIT_TYPE,UNIT,FORMAT_STRING,DECIMAL_POINT,ROUNDING_TYPE,USE_YN,CREATE_DATE,CREATE_USER)
                                VALUES
                                    ( " + NewUnitTypeInfoRefID() +
                                      @",@UNIT_TYPE,@UNIT,@FORMAT_STRING,@DECIMAL_POINT,@ROUNDING_TYPE,@USE_YN,SYSDATE,@CREATE_USER)";

            IDbDataParameter[] paramArray = CreateDataParameters(7);

 
            paramArray[0]               = CreateDataParameter("@UNIT_TYPE", SqlDbType.VarChar);
            paramArray[0].Value         = unit_type;
            paramArray[1]               = CreateDataParameter("@UNIT", SqlDbType.VarChar);
            paramArray[1].Value         = unit;
            paramArray[2]               = CreateDataParameter("@FORMAT_STRING", SqlDbType.VarChar);
            paramArray[2].Value         = format;
            paramArray[3]               = CreateDataParameter("@DECIMAL_POINT", SqlDbType.Int);
            paramArray[3].Value         = dec_point;
            paramArray[4]               = CreateDataParameter("@ROUNDING_TYPE", SqlDbType.VarChar);
            paramArray[4].Value         = rounding;
            paramArray[5]               = CreateDataParameter("@USE_YN", SqlDbType.VarChar);
            paramArray[5].Value         = use;
            paramArray[6]               = CreateDataParameter("@CREATE_USER", SqlDbType.Int);
            paramArray[6].Value         = user;

            try
            {
                int affectedRow         = DbAgentObj.ExecuteNonQuery(GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
                return (affectedRow > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool AddModifyUnitTypeInfo()
        //{
 
        //}

        public bool RemoveUnitTypeInfo(int unit_id, string unit)
        {
            string query = @"DELETE FROM COM_UNIT_TYPE_INFO
                                   WHERE UNIT_TYPE_REF_ID   = @UNIT_TYPE_REF_ID
                                     AND UNIT               = @UNIT";
            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@UNIT_TYPE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = unit_id;
            paramArray[1]               = CreateDataParameter("@UNIT", SqlDbType.VarChar);
            paramArray[1].Value         = unit;
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
    }
}
