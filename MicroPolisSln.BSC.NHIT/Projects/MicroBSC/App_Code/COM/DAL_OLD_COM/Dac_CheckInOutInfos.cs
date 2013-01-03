using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class CheckInOutInfos : DbAgentBase
    {
        public CheckInOutInfos()
        {

        }

        public CheckInOutInfos(int idx, string page_name, int access_emp_id)
        {
            DataSet ds = GetCheckinoutinfo(idx, page_name, access_emp_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                  = ds.Tables[0].Rows[0];
                _idx                = (dr["IDX"]            == DBNull.Value) ? 0 : Convert.ToInt32(dr["IDX"]);
                _page_name          = (dr["PAGE_NAME"]      == DBNull.Value) ? "" : Convert.ToString(dr["PAGE_NAME"]);
                _access_emp_id      = (dr["ACCESS_EMP_ID"]  == DBNull.Value) ? 0 : Convert.ToInt32(dr["ACCESS_EMP_ID"]);
                _is_check_out       = (dr["IS_CHECK_OUT"]   == DBNull.Value) ? 0 : Convert.ToInt32(dr["IS_CHECK_OUT"]);
            }
        }

        #region ============================== [Fields] ==============================

        private int _idx;
        private string _page_name;
        private int _access_emp_id;
        private int _is_check_out;
        #endregion

        #region ============================== [Properties] ==============================

        public int Idx
        {
            get
            {
                return _idx;
            }
            set
            {
                _idx = value;
            }
        }

        public string Page_Name
        {
            get
            {
                return _page_name;
            }
            set
            {
                _page_name = (value == null ? "" : value);
            }
        }

        public int Access_Emp_ID
        {
            get
            {
                return _access_emp_id;
            }
            set
            {
                _access_emp_id = value;
            }
        }

        public int Is_Check_Out
        {
            get
            {
                return _is_check_out;
            }
            set
            {
                _is_check_out = value;
            }
        }
        #endregion

        public bool ModifyCheckInOutInfo(int idx, string page_name, int access_emp_id, int is_check_out)
        {
            string query = @"
                                UPDATE	COM_CHECK_IN_OUT_INFO
	                                SET	ACCESS_EMP_ID			= @ACCESS_EMP_ID
		                                ,IS_CHECK_OUT			= @IS_CHECK_OUT
		                                ,RECENT_CHECK_IN_DATE	= CASE WHEN @IS_CHECK_OUT = 0 THEN GETDATE() ELSE RECENT_CHECK_OUT_DATE END
		                                ,RECENT_CHECK_OUT_DATE	= CASE WHEN @IS_CHECK_OUT = 1 THEN GETDATE() ELSE RECENT_CHECK_OUT_DATE END
	                                WHERE	(IDX				= @IDX				OR @IDX				= 0)
		                                AND PAGE_NAME			= @PAGE_NAME

                            ";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[0].Value         = idx;
            paramArray[1]               = CreateDataParameter("@PAGE_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = page_name;
            paramArray[2]               = CreateDataParameter("@ACCESS_EMP_ID", SqlDbType.Int);
            paramArray[2].Value         = access_emp_id;
            paramArray[3]               = CreateDataParameter("@IS_CHECK_OUT", SqlDbType.Int);
            paramArray[3].Value         = is_check_out;

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

        public DataSet GetCheckinoutinfo(int idx, string page_name, int access_emp_id)
        {
            string query = @"
                                SELECT	IDX
		                                ,PAGE_NAME
		                                ,FULL_PATH
		                                ,ACCESS_EMP_ID
		                                ,IS_CHECK_OUT
		                                ,RECENT_CHECK_IN_DATE
		                                ,RECENT_CHECK_OUT_DATE
		                                ,CREATE_DATE
                                FROM	COM_CHECK_IN_OUT_INFO 
                                WHERE	(IDX                = @IDX               OR @IDX             = 0)
		                                AND PAGE_NAME      = @PAGE_NAME
		                                AND (ACCESS_EMP_ID  = @ACCESS_EMP_ID     OR @ACCESS_EMP_ID   = 0)";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[0].Value         = idx;
            paramArray[1]               = CreateDataParameter("@PAGE_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = page_name;
            paramArray[2]               = CreateDataParameter("@ACCESS_EMP_ID", SqlDbType.Int);
            paramArray[2].Value         = access_emp_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "CHECKINOUTINFOGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public bool AddCheckinoutinfo(string page_name, string full_path, int access_emp_id, int is_check_out)
        {
            string query = @"
                                IF EXISTS (SELECT * FROM COM_CHECK_IN_OUT_INFO
				                                WHERE PAGE_NAME		= @PAGE_NAME
		                                )
                                BEGIN

	                                UPDATE	COM_CHECK_IN_OUT_INFO
	                                SET	ACCESS_EMP_ID			= @ACCESS_EMP_ID
		                                ,IS_CHECK_OUT			= @IS_CHECK_OUT
		                                ,RECENT_CHECK_IN_DATE	= CASE WHEN @IS_CHECK_OUT = 0 THEN GETDATE() ELSE RECENT_CHECK_OUT_DATE END
		                                ,RECENT_CHECK_OUT_DATE	= CASE WHEN @IS_CHECK_OUT = 1 THEN GETDATE() ELSE RECENT_CHECK_OUT_DATE END
	                                WHERE PAGE_NAME			    = @PAGE_NAME

                                END
                                ELSE
                                BEGIN
                                INSERT INTO	COM_CHECK_IN_OUT_INFO(
			                                PAGE_NAME
			                                ,FULL_PATH
			                                ,ACCESS_EMP_ID
			                                ,IS_CHECK_OUT
			                                ,RECENT_CHECK_IN_DATE
			                                ,RECENT_CHECK_OUT_DATE
			                                ,CREATE_DATE
			                                )
		                                VALUES	(
			                                @PAGE_NAME
			                                ,@FULL_PATH
			                                ,@ACCESS_EMP_ID
			                                ,@IS_CHECK_OUT
			                                ,NULL
			                                ,NULL
			                                ,GETDATE()
			                                )

                                END";

            IDbDataParameter[] paramArray = CreateDataParameters(4);

            paramArray[0]               = CreateDataParameter("@PAGE_NAME", SqlDbType.VarChar);
            paramArray[0].Value         = page_name;
            paramArray[1]               = CreateDataParameter("@FULL_PATH", SqlDbType.VarChar);
            paramArray[1].Value         = full_path;
            paramArray[2]               = CreateDataParameter("@ACCESS_EMP_ID", SqlDbType.Int);
            paramArray[2].Value         = access_emp_id;
            paramArray[3]               = CreateDataParameter("@IS_CHECK_OUT", SqlDbType.Int);
            paramArray[3].Value         = is_check_out;

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

        public bool RemoveCheckInOutInfo(int idx, string page_name)
        {
            string query = @"
                                DELETE	COM_CHECK_IN_OUT_INFO
	                                WHERE	(IDX				= @IDX				OR @IDX				= 0)
		                                AND PAGE_NAME			= @PAGE_NAME
                                ";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@IDX", SqlDbType.Int);
            paramArray[0].Value         = idx;
            paramArray[1]               = CreateDataParameter("@PAGE_NAME", SqlDbType.VarChar);
            paramArray[1].Value         = page_name;

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
    }
}
