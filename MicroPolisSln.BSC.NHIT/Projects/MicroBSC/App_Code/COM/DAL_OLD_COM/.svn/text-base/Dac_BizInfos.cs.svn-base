using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class BizInfos : DbAgentBase
    {
        public BizInfos()
        {

        }

        public BizInfos(string biz_type_code)
        {
            DataSet ds= GetBizInfo(biz_type_code);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _biz_type_code = Convert.ToString(dr["BIZ_TYPE_CODE"]);
                _biz_type_name = Convert.ToString(dr["BIZ_TYPE_NAME"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private string _biz_type_code;
        private string _biz_type_name;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public string Biz_Type_Code
        {
            get
            {
                return _biz_type_code;
            }
            set
            {
                _biz_type_code = (value == null ? "" : value);
            }
        }

        public string Biz_Type_Name
        {
            get
            {
                return _biz_type_name;
            }
            set
            {
                _biz_type_name = (value == null ? "" : value);
            }
        }
        #endregion

        public bool ModifyBizInfo(string biz_type_code, string biz_type_name)
        {
            string query = @"UPDATE	COM_APPROVAL_PRC
                                SET	APP_STEP_STATUS = @APP_STEP_STATUS
	                                ,APP_STATUS     = @APP_STATUS
	                                ,APP_DATE       = @APP_DATE
	                                ,APP_FLAG       = @APP_FLAG
	                                ,APP_REMARK     = @APP_REMARK
	                                ,APP_EMP_ID     = @APP_EMP_ID
                                WHERE	APP_REF_ID  = @APP_REF_ID
                                AND	APP_STEP        = @APP_STEP";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = biz_type_code;
            paramArray[1]               = CreateDataParameter("@BIZ_TYPE_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = biz_type_name;

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

        public DataSet GetBizInfo(string biz_type_code)
        {
            string query = @"SELECT	BIZ_TYPE_CODE
	                                ,BIZ_TYPE_NAME
                                FROM	COM_BIZ_INFO 
                                WHERE	BIZ_TYPE_CODE = @BIZ_TYPE_CODE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = biz_type_code;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "BIZINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetAllBizInfo()
        {
            string query = @"SELECT	BIZ_TYPE_CODE
	                                ,BIZ_TYPE_NAME
                                FROM	COM_BIZ_INFO ";

            DataSet ds = DbAgentObj.FillDataSet(query, "BIZINFOGETALL", null, null, CommandType.Text);
            return ds;
        }

        public bool AddBizInfo(string biz_type_code, string biz_type_name)
        {
            string query = @"INSERT INTO	COM_BIZ_INFO(BIZ_TYPE_CODE
			                                            ,BIZ_TYPE_NAME
			                                            )
		                                            VALUES	(@BIZ_TYPE_CODE
			                                            ,@BIZ_TYPE_NAME
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = biz_type_code;
            paramArray[1]               = CreateDataParameter("@BIZ_TYPE_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = biz_type_name;

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

        public bool RemoveBizInfo(string biz_type_code)
        {
            string query = @"DELETE	COM_BIZ_INFO
                                WHERE	BIZ_TYPE_CODE = @BIZ_TYPE_CODE";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@BIZ_TYPE_CODE", SqlDbType.VarChar);
            paramArray[0].Value         = biz_type_code;

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
