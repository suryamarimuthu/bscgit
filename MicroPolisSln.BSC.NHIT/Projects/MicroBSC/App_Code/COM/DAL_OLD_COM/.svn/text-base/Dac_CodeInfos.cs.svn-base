using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class CodeInfos : DbAgentBase
    {
        public CodeInfos()
        {

        }

        public CodeInfos(int code_ref_id)
        {
            DataSet ds= GetCodeInfo(code_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _code_ref_id = Convert.ToInt32(dr["CODE_REF_ID"]);
                _code_name = Convert.ToString(dr["CODE_NAME"]);
                _code_value = Convert.ToString(dr["CODE_VALUE"]);
                _code_desc = Convert.ToString(dr["CODE_DESC"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private int _code_ref_id;
        private string _code_name;
        private string _code_value;
        private string _code_desc;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int Code_Ref_ID
        {
            get
            {
                return _code_ref_id;
            }
            set
            {
                _code_ref_id = value;
            }
        }

        public string Code_Name
        {
            get
            {
                return _code_name;
            }
            set
            {
                _code_name = (value == null ? "" : value);
            }
        }

        public string Code_Value
        {
            get
            {
                return _code_value;
            }
            set
            {
                _code_value = (value == null ? "" : value);
            }
        }

        public string Code_Desc
        {
            get
            {
                return _code_desc;
            }
            set
            {
                _code_desc = (value == null ? "" : value);
            }
        }
        #endregion

        public bool ModifyCodeInfo(int code_ref_id, string code_name, string code_value, string code_desc)
        {
            string query = @"UPDATE	COM_CODE_INFO
                                SET	CODE_NAME       = @CODE_NAME
	                                ,CODE_VALUE     = @CODE_VALUE
	                                ,CODE_DESC      = @CODE_DESC
                                WHERE	CODE_REF_ID = @CODE_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@CODE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = code_ref_id;
            paramArray[1]               = CreateDataParameter("@CODE_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = code_name;
            paramArray[2]               = CreateDataParameter("@CODE_VALUE", SqlDbType.VarChar);
            paramArray[2].Value         = code_value;
            paramArray[3]               = CreateDataParameter("@CODE_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = code_desc;

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

        public DataSet GetCodeInfo(int code_ref_id)
        {
            string query = @"SELECT	CODE_REF_ID
	                                ,CODE_NAME
	                                ,CODE_VALUE
	                                ,CODE_DESC
                                FROM	COM_CODE_INFO 
                                WHERE	CODE_REF_ID = @CODE_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@CODE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = code_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "CODEINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetAllCodeInfo()
        {
            string query = @"SELECT	CODE_REF_ID
	                                ,CODE_NAME
	                                ,CODE_VALUE
	                                ,CODE_DESC
                                FROM	COM_CODE_INFO ";

            DataSet ds = DbAgentObj.FillDataSet(query, "CODEINFOGETALL", null, null, CommandType.Text);
            return ds;
        }

        public bool AddCodeInfo(int code_ref_id, string code_name, string code_value, string code_desc)
        {
            string query = @"INSERT INTO COM_CODE_INFO(CODE_REF_ID
			                                            ,CODE_NAME
			                                            ,CODE_VALUE
			                                            ,CODE_DESC
			                                            )
		                                            VALUES	(@CODE_REF_ID
			                                            ,@CODE_NAME
			                                            ,@CODE_VALUE
			                                            ,@CODE_DESC
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@CODE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = code_ref_id;
            paramArray[1]               = CreateDataParameter("@CODE_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = code_name;
            paramArray[2]               = CreateDataParameter("@CODE_VALUE", SqlDbType.VarChar);
            paramArray[2].Value         = code_value;
            paramArray[3]               = CreateDataParameter("@CODE_DESC", SqlDbType.VarChar);
            paramArray[3].Value         = code_desc;

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

        public bool RemoveCodeInfo(int code_ref_id)
        {
            string query = @"DELETE	COM_CODE_INFO
                                WHERE	CODE_REF_ID = @CODE_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@CODE_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = code_ref_id;

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

        public DataTable GetGeneralSetup()
        {
            string strQuery = @"
SELECT GENERALKEY, GENERALDESC, VALUE
FROM    COM_GENERAL_SETUP
ORDER BY SEQ
";
            return DbAgentObj.FillDataSet(strQuery, "COM_GENERAL_SETUP").Tables[0];
        }

        public bool SaveGeneralSetup(object[,] objItem)
        {
            bool rtnValue = false;
            return rtnValue;
        }
    }
}
