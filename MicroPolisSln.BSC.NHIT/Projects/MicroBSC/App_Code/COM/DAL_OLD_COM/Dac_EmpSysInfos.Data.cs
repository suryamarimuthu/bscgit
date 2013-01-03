using System;
using System.Web;
using System.Data;


/// ------------------------------------------------------
/// DATE    : 2007.08.30
/// AUTHOR  : juny177
/// MEMO    : [오라클/MS-SQL] 구문 공통사용을 위한 변경
/// ------------------------------------------------------


using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class EmpSysInfos_Data : DbAgentBase
    {
        private int _emp_ref_id = 0;
        //private int _sys_key = 0;
        //private string _sys_value = "";

        public int Emp_Ref_ID
        {
            get
            {
                return _emp_ref_id;
            }
        }

        public EmpSysInfos_Data(int emp_ref_id) 
        {
            _emp_ref_id = emp_ref_id;
        }

        // 유저 Systemp 카데고리 정보 리턴
        public DataSet GetEmpSysCategory()
        {
            string query = @"SELECT * FROM COM_EMP_SYS_CATEGORY ORDER BY SYS_CATEGORY_SORT";

            DataSet ds = DbAgentObj.FillDataSet(query, "Sys_Data", null, null, CommandType.Text);
            return ds;
        }

        // 유저 Systemp 기초 정보 리턴
        protected DataSet GetEmpSysInfo(int sys_key)
        {
            string query = @"SELECT * FROM COM_EMP_SYS_KEY_INFO WHERE SYS_KEY = @SYS_KEY ORDER BY SYS_SORT";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0] = CreateDataParameter("@SYS_KEY", SqlDbType.Int);
            paramArray[0].Value = sys_key;

            DataSet ds = DbAgentObj.FillDataSet(query, "Sys_Data", null, paramArray, CommandType.Text);
            return ds;
        }

        // 유저 Systemp 기초 정보 리턴
        public DataSet GetEmpSysInfoByCategory(int sys_category)
        {
            string query = @"SELECT * FROM COM_EMP_SYS_KEY_INFO WHERE SYS_CATEGORY = @SYS_CATEGORY";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]       = CreateDataParameter("@SYS_CATEGORY", SqlDbType.Int);
            paramArray[0].Value = sys_category;

            DataSet ds = DbAgentObj.FillDataSet(query, "Sys_Data", null, paramArray, CommandType.Text);
            return ds;
        }

        // 유저 Systemp 정보 리턴
        protected DataSet GetEmpSysDetail(int sys_key) 
        {
            string query = @"SELECT * FROM COM_EMP_SYS_KEY_DETAIL WHERE EMP_REF_ID = @EMP_REF_ID AND SYS_KEY = @SYS_KEY";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]       = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = _emp_ref_id;
            paramArray[1]       = CreateDataParameter("@SYS_KEY", SqlDbType.Int);
            paramArray[1].Value = sys_key;

            DataSet ds = DbAgentObj.FillDataSet(query, "Sys_Data", null, paramArray, CommandType.Text);
            return ds;
        }

        public int SetEmpSysDetailUpdate(int sys_key, string sys_value)
        {
            string query = @"
                                    UPDATE COM_EMP_SYS_KEY_DETAIL 
		                                SET SYS_VALUE	= @SYS_VALUE 
	                                WHERE EMP_REF_ID	= @EMP_REF_ID 
			                                AND SYS_KEY = @SYS_KEY
                                            AND  EXISTS (SELECT * FROM COM_EMP_SYS_KEY_DETAIL WHERE EMP_REF_ID = @EMP_REF_ID AND SYS_KEY = @SYS_KEY)
            ";

            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0] = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value = _emp_ref_id;
            paramArray[1] = CreateDataParameter("@SYS_KEY", SqlDbType.Int);
            paramArray[1].Value = sys_key;
            paramArray[2] = CreateDataParameter("@SYS_VALUE", SqlDbType.VarChar);
            paramArray[2].Value = sys_value;

            return DbAgentObj.ExecuteNonQuery(query, paramArray, CommandType.Text);
        }

        // 유저별 시스템 설정 데이터 추가 및 변경
        public bool SetEmpSysDetail(IDbConnection conn, IDbTransaction trx, int sys_key, string sys_value)
        {
            string s_query = @" 
                                            IF NOT EXISTS(
                                            SELECT * 
                                            FROM COM_EMP_SYS_KEY_DETAIL 
                                            WHERE EMP_REF_ID = @EMP_REF_ID AND SYS_KEY = @SYS_KEY
                                            )

                                            INSERT COM_EMP_SYS_KEY_DETAIL (EMP_REF_ID
                                            , SYS_KEY
                                            , SYS_VALUE
                                            , CREATE_DATE) 
                                            VALUES (@EMP_REF_ID
				                              , @SYS_KEY
				                              , @SYS_VALUE
                                            , GETDATE())
            ";

            string o_query = @" 
                                        INSERT INTO COM_EMP_SYS_KEY_DETAIL
                                             ( EMP_REF_ID
			                                 , SYS_KEY
			                                 , SYS_VALUE
			                                 , CREATE_DATE) 
                                        SELECT @EMP_REF_ID
				                             , @SYS_KEY
				                             , @SYS_VALUE
                                             , SYSDATE
                                          FROM COM_EMP_SYS_KEY_DETAIL 
                                         WHERE NOT EXISTS (SELECT * FROM COM_EMP_SYS_KEY_DETAIL WHERE EMP_REF_ID = @EMP_REF_ID AND SYS_KEY = @SYS_KEY)

            ";


            IDbDataParameter[] paramArray = CreateDataParameters(3);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = _emp_ref_id;
            paramArray[1]               = CreateDataParameter("@SYS_KEY", SqlDbType.Int);
            paramArray[1].Value         = sys_key;
            paramArray[2]               = CreateDataParameter("@SYS_VALUE", SqlDbType.VarChar);
            paramArray[2].Value         = sys_value;

            int affectedRow             = DbAgentObj.ExecuteNonQuery(conn, trx, GetQueryStringByDb(s_query, o_query), paramArray, CommandType.Text);
            return (affectedRow > 0) ? true : false;
        }

    }
}
