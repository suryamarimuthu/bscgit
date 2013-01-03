using System;
using System.Web;
using System.Data;

using MicroBSC.Data;

namespace MicroBSC.Biz.Common
{
    public class RelationDeptEmps : DbAgentBase
    {
        public RelationDeptEmps()
        {

        }

        public RelationDeptEmps(int emp_ref_id, int dept_ref_id)
        {
            DataSet ds = GetRelationDeptEmp(emp_ref_id, dept_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _dept_ref_id    = Convert.ToInt32(dr["DEPT_REF_ID"]);
                _rel_status     = Convert.ToInt16(dr["REL_STATUS"]);
                //_boss_flag      = Convert.ToByte(dr["BOSS_FLAG"];
                _rel_date       = Convert.ToDateTime(dr["REL_DATE"]);
                _rel_emp_id     = Convert.ToInt32(dr["REL_EMP_ID"]);
                _emp_ref_id     = Convert.ToInt32(dr["EMP_REF_ID"]);
            }
        }

        #region ------------------------ 필드 ------------------------

        private int _dept_ref_id;
        private short _rel_status;
        private byte _boss_flag;
        private DateTime _rel_date;
        private int _rel_emp_id;
        private int _emp_ref_id;
        #endregion

        #region ------------------------ 프로퍼티 ------------------------

        public int Dept_Ref_ID
        {
            get
            {
                return _dept_ref_id;
            }
            set
            {
                _dept_ref_id = value;
            }
        }

        public short Rel_Status
        {
            get
            {
                return _rel_status;
            }
            set
            {
                _rel_status = value;
            }
        }

        public byte Boss_Flag
        {
            get
            {
                return _boss_flag;
            }
            set
            {
                _boss_flag = value;
            }
        }

        public DateTime Rel_Date
        {
            get
            {
                return _rel_date;
            }
            set
            {
                _rel_date = value;
            }
        }

        public int Rel_Emp_ID
        {
            get
            {
                return _rel_emp_id;
            }
            set
            {
                _rel_emp_id = value;
            }
        }

        public int Emp_Ref_ID
        {
            get
            {
                return _emp_ref_id;
            }
            set
            {
                _emp_ref_id = value;
            }
        }
        #endregion

        public bool ModifyRelationDeptEmp(int emp_ref_id, int dept_ref_id, short rel_status, byte boss_flag, DateTime rel_date, int rel_emp_id)
        {
            string query = @"UPDATE	REL_DEPT_EMP
                            SET	REL_STATUS      = @REL_STATUS
	                            ,BOSS_FLAG      = @BOSS_FLAG
	                            ,REL_DATE       = @REL_DATE
	                            ,REL_EMP_ID     = @REL_EMP_ID
                            WHERE	DEPT_REF_ID = @DEPT_REF_ID
                            AND	EMP_REF_ID      = @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;
            paramArray[1]               = CreateDataParameter("@REL_STATUS", SqlDbType.SmallInt);
            paramArray[1].Value         = rel_status;
            paramArray[2]               = CreateDataParameter("@BOSS_FLAG", SqlDbType.Bit);
            paramArray[2].Value         = boss_flag;
            paramArray[3]               = CreateDataParameter("@REL_DATE", SqlDbType.DateTime);
            paramArray[3].Value         = rel_date;
            paramArray[4]               = CreateDataParameter("@REL_EMP_ID", SqlDbType.Int);
            paramArray[4].Value         = rel_emp_id;
            paramArray[5]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = emp_ref_id;

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

        public DataSet GetRelationDeptEmp(int emp_ref_id, int dept_ref_id)
        {
            string query = @"SELECT	T1.DEPT_REF_ID
	                            ,T1.REL_STATUS
	                            ,T1.BOSS_FLAG
	                            ,T1.REL_DATE
	                            ,T1.REL_EMP_ID
	                            ,T1.EMP_REF_ID
                            FROM	REL_DEPT_EMP T1
                                WHERE	T1.DEPT_REF_ID  = @DEPT_REF_ID
                                    AND	T1.EMP_REF_ID   = @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;
            paramArray[1]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = emp_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "DEPTEMPGET", null, paramArray, CommandType.Text);
            return ds;
        }

        public DataSet GetRelationDeptByEmpID(int emp_ref_id)
        {
            string query = @"SELECT * FROM V_COM_DEPT_EMP_JOIN WHERE EMP_REF_ID=@EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(1);

            paramArray[0]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = emp_ref_id;

            DataSet ds                  = DbAgentObj.FillDataSet(query, "COMDEPTEMPJOINGET", null, paramArray, CommandType.Text);
            return ds;
        }


        public DataSet GetAllRelationDeptEmp()
        {
            string query = @"SELECT	T1.DEPT_REF_ID
	                            ,T1.REL_STATUS
	                            ,T1.BOSS_FLAG
	                            ,T1.REL_DATE
	                            ,T1.REL_EMP_ID
	                            ,T1.EMP_REF_ID
                            FROM	REL_DEPT_EMP T1";

            DataSet ds = DbAgentObj.FillDataSet(query, "DEPTEMPGETALL", null, null, CommandType.Text);
            return ds;
        }

        public bool AddRelationDeptEmp(int emp_ref_id, int dept_ref_id, short rel_status, byte boss_flag, DateTime rel_date, int rel_emp_id)
        {
            string query = @"INSERT INTO REL_DEPT_EMP(DEPT_REF_ID
			                                            ,REL_STATUS
			                                            ,BOSS_FLAG
			                                            ,REL_DATE
			                                            ,REL_EMP_ID
			                                            ,EMP_REF_ID
			                                            )
		                                            VALUES	(@DEPT_REF_ID
			                                            ,@REL_STATUS
			                                            ,@BOSS_FLAG
			                                            ,@REL_DATE
			                                            ,@REL_EMP_ID
			                                            ,@EMP_REF_ID
			                                            )";

            IDbDataParameter[] paramArray = CreateDataParameters(6);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;
            paramArray[1]               = CreateDataParameter("@REL_STATUS", SqlDbType.SmallInt);
            paramArray[1].Value         = rel_status;
            paramArray[2]               = CreateDataParameter("@BOSS_FLAG", SqlDbType.Bit);
            paramArray[2].Value         = boss_flag;
            paramArray[3]               = CreateDataParameter("@REL_DATE", SqlDbType.DateTime);
            paramArray[3].Value         = rel_date;
            paramArray[4]               = CreateDataParameter("@REL_EMP_ID", SqlDbType.Int);
            paramArray[4].Value         = rel_emp_id;
            paramArray[5]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[5].Value         = emp_ref_id;

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

        public bool RemoveRelationDeptEmp(int emp_ref_id, int dept_ref_id)
        {
            string query = @"DELETE	REL_DEPT_EMP
                                WHERE	DEPT_REF_ID = @DEPT_REF_ID
                                    AND	EMP_REF_ID  = @EMP_REF_ID";

            IDbDataParameter[] paramArray = CreateDataParameters(2);

            paramArray[0]               = CreateDataParameter("@DEPT_REF_ID", SqlDbType.Int);
            paramArray[0].Value         = dept_ref_id;
            paramArray[1]               = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[1].Value         = emp_ref_id;

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
