//=======================================================================
//   (주) 마이크로폴리스 RolesBasedAthentication Ver 0.8
//
//   RolesBasedAthentication.User
// 
//=======================================================================
//  Written By 이승주 (sjlee@micropolis.co.kr)
//  
//  2006. 06. 08
//=======================================================================
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using MicroBSC.Data;

using System.Collections;


namespace MicroBSC.RolesBasedAthentication
{
	/// <summary>
	/// System.Security.Principal.IIdentity 를 구현하는 클래스입니다.
	/// </summary>
	public class SiteIdentity: System.Security.Principal.IIdentity
	{
		#region 필드

        private int _emp_ref_id;
        private string _loginid;
        private string _emp_name;
        private string _emp_email;
        private int _dept_ref_id;
        private string _position_rank_code;

		
        #endregion

		#region 생성자
		
		/// <summary>
		/// UserID 에 따른 사용자 정보를 가지고 오는 생성자 입니다.
		/// </summary>
		/// <param name="userID"></param>
        public SiteIdentity(int emp_ref_id)
		{
            Users user = new Users(emp_ref_id);

            _emp_ref_id = user.Emp_Ref_ID;
            _loginid    = user.LoginID;
            _emp_name   = user.Emp_Name;
            _emp_email  = user.Emp_EMail;
            _dept_ref_id = user.Dept_Ref_ID;
            _position_rank_code = user.Position_Rank_Code;



		}

        public SiteIdentity(string loginId)
        {
            Users user = new Users(loginId);

            _emp_ref_id = user.Emp_Ref_ID;
            _loginid    = user.LoginID;
            _emp_name   = user.Emp_Name;
            _emp_email  = user.Emp_EMail;
            _dept_ref_id = user.Dept_Ref_ID;
            _position_rank_code = user.Position_Rank_Code;

           
        }

		#endregion

		#region 메소드

		/// <summary>
		/// System.Security.Principal.IIdentity.AuthenticationType 를 구현합니다.
		/// </summary>
		public string AuthenticationType
		{
			get 
			{ 
				return "Custom Authentication"; 
			}
		}

		/// <summary>
		/// System.Security.Principal.IIdentity.IsAuthenticated 를 구현합니다.
		/// SiteIdentity의 모든 객체들은 이미 인증된 것으로 전제합니다.
		/// </summary>
		public bool IsAuthenticated
		{
			get 
			{
				return true;
			}
		}

		#endregion

		#region 프로퍼티

        /// <summary>
        /// System.Security.Principal.IIdentity.Name 를 구현합니다.
        /// </summary>
        public string Name
        {
            get
            {
                return _emp_ref_id.ToString();
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

		#endregion
	}
}
