using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using MicroBSC.Data;

namespace MicroBSC.RolesBasedAthentication
{
	/// <summary>
	/// 사용자 정보 클래스
	/// </summary>
	public class Users : DbAgentBase
	{
        #region ------------------------ 필드 ------------------------

        private int _emp_ref_id;
        private int _dept_ref_id;
        private string _position_rank_code;
        private string _loginid;
        private string _emp_name;
        private string _emp_email;
        private string _emp_code;

        #endregion

        #region ------------------------ 프로퍼티 ------------------------

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

        public string LoginID
        {
            get
            {
                return _loginid;
            }
            set
            {
                _loginid = (value == null ? "" : value);
            }
        }

        public string Emp_Name
        {
            get
            {
                return _emp_name;
            }
            set
            {
                _emp_name = (value == null ? "" : value);
            }
        }

        public string Position_Rank_Code
        {
            get
            {
                return _position_rank_code;
            }
            set
            {
                _position_rank_code = (value == null ? "" : value);
            }
        }

        public string Emp_EMail
        {
            get
            {
                return _emp_email;
            }
            set
            {
                _emp_email = (value == null ? "" : value);
            }
        }

        public string Emp_Code
        {
            get
            {
                return _emp_code;
            }

            set
            {
                _emp_code = (value == null ? string.Empty : value);
            }
        }
        #endregion

		#region 생성자
		
		public Users()
		{
		
		}

        public Users(int emp_ref_id)
        {
            Biz.Common.EmpInfos emp = new Biz.Common.EmpInfos();
            DataSet ds              = emp.GetEmpInfo(emp_ref_id);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr = ds.Tables[0].Rows[0];
                _emp_ref_id = Convert.ToInt32(dr["EMP_REF_ID"]);
                _dept_ref_id = Convert.ToInt32(dr["DEPT_REF_ID"]);
                _loginid = Convert.ToString(dr["LOGINID"]);
                _emp_name               = Convert.ToString(dr["EMP_NAME"]);
                _emp_email              = DataTypeUtility.GetValue(dr["EMP_EMAIL"]);
                _emp_code = Convert.ToString(dr["EMP_CODE"]);
                _position_rank_code = Convert.ToString(dr["POSITION_RANK_CODE"]);
            }
        }

        public Users(string loginId)
        {
            Biz.Common.EmpInfos emp = new Biz.Common.EmpInfos();

            DataSet ds = emp.GetEmpInfo(loginId);
            DataRow dr;

            if (ds.Tables[0].Rows.Count == 1)
            {
                dr                      = ds.Tables[0].Rows[0];
                _emp_ref_id             = Convert.ToInt32(dr["EMP_REF_ID"]);
                _dept_ref_id = Convert.ToInt32(dr["DEPT_REF_ID"]);

                _loginid                = Convert.ToString(dr["LOGINID"]);
                _emp_name               = Convert.ToString(dr["EMP_NAME"]);
                _emp_email              = DataTypeUtility.GetValue(dr["EMP_EMAIL"]);
                _emp_code = Convert.ToString(dr["EMP_CODE"]);
                _position_rank_code = Convert.ToString(dr["POSITION_RANK_CODE"]);

            }
        }

		#endregion

		#region 메소드

        public ArrayList GetUserRoles(int emp_ref_id)
        {
            string query = @"SELECT A.ROLE_REF_ID
                                    , A.ROLE_NAME 
		                            FROM  COM_ROLE_INFO     A
                                        , COM_EMP_ROLE_REL  B
	                            WHERE   A.ROLE_REF_ID       = B.ROLE_REF_ID
                                    AND B.EMP_REF_ID        = @EMP_REF_ID";

            ArrayList roles = new ArrayList();

            IDbDataParameter[] paramArray     = CreateDataParameters(1);

            paramArray[0]                   = CreateDataParameter("@EMP_REF_ID", SqlDbType.Int);
            paramArray[0].Value             = emp_ref_id;

            DataTable dataTable             = DbAgentObj.FillDataSet(query, "roles", null, paramArray, CommandType.Text).Tables[0];

            for (int i = 0; i < dataTable.Rows.Count; i++) 
            {
                roles.Add(dataTable.Rows[i]["ROLE_REF_ID"].ToString());
            }

            return roles;
        }

		#endregion
	}
}
