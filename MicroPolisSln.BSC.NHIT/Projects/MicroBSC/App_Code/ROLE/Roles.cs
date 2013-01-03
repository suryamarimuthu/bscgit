using System;
using System.Data;
using System.Data.SqlClient;
using MicroBSC.Data;

namespace MicroBSC.RolesBasedAthentication
{
	/// <summary>
	/// 역할 클래스 입니다.
	/// </summary>
	public class Roles
	{
		#region 필드

		private int		_roleID;
		private string	_roleName;
		private DBAgent _dbAgent;

		#endregion

		#region 생성자

		/// <summary>
		/// 역할 클래스 생성자 입니다.
		/// </summary>
		public Roles()
		{
            _dbAgent                    = new DBAgent();
            _dbAgent.ConnectionString   = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
		}

		#endregion

		#region 프로퍼티

		/// <summary>
		/// RoleID 를 설정 및 반환합니다.
		/// </summary>
		public int RoleID
		{
			get 
			{ 
				return _roleID; 
			}
			set 
			{ 
				_roleID = value; 
			}
		}

		/// <summary>
		/// RoleName 를 설정 및 반환합니다.
		/// </summary>
		public string RoleName
		{
			get 
			{ 
				return _roleName; 
			}
			set 
			{ 
				_roleName = value; 
			}
		}

		#endregion
	}
}
