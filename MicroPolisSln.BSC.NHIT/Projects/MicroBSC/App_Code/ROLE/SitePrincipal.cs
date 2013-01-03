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
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using MicroBSC.Data;

namespace MicroBSC.RolesBasedAthentication
{
	/// <summary>
	/// System.Security.Principal.IPrincipal 를 구현하는 클래스입니다.
	/// </summary>
	public class SitePrincipal: System.Security.Principal.IPrincipal
	{
		protected System.Security.Principal.IIdentity	_identity;
		protected ArrayList								_roleList;

		/// <summary>
		/// SitePrincipal 생성자 입니다.
		/// </summary>
		/// <param name="userID">로그인아이디</param>
        public SitePrincipal(int emp_ref_id)
		{
            _identity   = new SiteIdentity(emp_ref_id);

            Users user  = new Users();
			_roleList   = user.GetUserRoles( ((SiteIdentity)_identity).Emp_Ref_ID );
		}

        public SitePrincipal(string loginId)
        {
            _identity   = new SiteIdentity(loginId);

            Users user = new Users();
            _roleList = user.GetUserRoles(((SiteIdentity)_identity).Emp_Ref_ID);
        }

		/// <summary>
		/// 로그인아이디와 패스워드로 인증를 확인한다.
		/// </summary>
		/// <param name="userID">로그인 아이디</param>
		/// <param name="userPWD">로그인 패스워드</param>
		/// <returns>인증되면 SitePrincipal를 반환하고 인증되지 않으면 반환하지 않습니다.</returns>
		public static SitePrincipal ValidateLogin(string loginId, string passwd)
		{
            Biz.Common.EmpInfos emp = new Biz.Common.EmpInfos();
            int emp_ref_id          =  emp.ValidateLogin(loginId, passwd);
            return (emp_ref_id == 0 ? null : new SitePrincipal(emp_ref_id));
		}


        /// <summary>
        /// 로그인아이디와 패스워드로 인증를 확인한다. 로그인 시도 허용횟수 지정
        /// </summary>
        /// <param name="userID">로그인 아이디</param>
        /// <param name="userPWD">로그인 패스워드</param>
        /// <param name="failcnt">로그인 시도 허용횟수</param>
        /// <returns>1:정상 인증, -1:허용횟수 초과, 0:잘못된 로그인 정보</returns>
        public static int ValidateLogin(string loginId, string passwd, int failcnt, out SitePrincipal newuser)
        {
            MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Info bizEmpInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Info();

            Biz.Common.EmpInfos emp = new Biz.Common.EmpInfos();


            IDbConnection conn = DbAgentHelper.CreateDbConnection();
            conn.Open();
            IDbTransaction trx = conn.BeginTransaction();

            int result = 0;

            newuser = null;

            try
            {
                DataTable dt_user_info = bizEmpInfo.Get_Emp_Login_Info(conn, trx, loginId);


                if (dt_user_info == null || dt_user_info.Rows.Count == 0)
                {
                    //잘못된 사용자 ID


                    result = 0;
                }
                else
                {
                    //사용자 ID 존재


                    int user_ref_id = DataTypeUtility.GetToInt32(dt_user_info.Rows[0]["emp_ref_id"]);
                    string user_passwd = DataTypeUtility.GetString(dt_user_info.Rows[0]["PASSWD"]);
                    int user_failcnt = DataTypeUtility.GetToInt32(dt_user_info.Rows[0]["FAILCNT"]);

                    if (user_failcnt < failcnt)
                    {
                        //로그인 시도 허용횟수 이내


                        if (user_passwd.Equals(passwd))
                        {
                            //비밀번호 일치


                            result = 1;
                            bizEmpInfo.Modify_Login_FailCnt(conn, trx, user_ref_id, 0, user_ref_id);//로그인 시도횟수 리셋
                            newuser = new SitePrincipal(user_ref_id);
                        }
                        else
                        {
                            //비밀번호 불일치


                            result = 0;
                        }
                    }
                    else
                    {
                        //로그인 시도 허용횟수 초과


                        result = -1;
                    }
                }

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                result = 0;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }



        /// <summary>
        /// SSO 처리의 경우 사용자 아이디를 확인하여 인증함
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static SitePrincipal ValidateLogin(string loginId)
        {
            Biz.Common.EmpInfos emp = new Biz.Common.EmpInfos();
            DataSet rDs             = emp.GetEmpInfo(loginId);

            if (rDs.Tables[0].Rows.Count < 1)
            {
                return null;
            }
            else
            { 
                int emp_ref_id = Convert.ToInt32(rDs.Tables[0].Rows[0]["EMP_REF_ID"].ToString());
                return new SitePrincipal(emp_ref_id);
            }
        }

        /// <summary>
        /// 로그인아이디, 패스워드, 로그인 IP 로 인증를 확인한다.
        /// </summary>
        /// <param name="userID">로그인 아이디</param>
        /// <param name="userPWD">로그인 패스워드</param>
        /// <param name="loginIp">로그인 IP</param>
        /// <returns>인증되면 SitePrincipal를 반환하고 인증되지 않으면 반환하지 않습니다.</returns>
        public static SitePrincipal ValidateLogin(string loginId, string passwd, string loginIp)
        {
            Biz.Common.EmpInfos emp = new Biz.Common.EmpInfos();
            int emp_ref_id          = emp.ValidateLogin(loginId, passwd, loginIp);
            return (emp_ref_id == 0 ? null : new SitePrincipal(emp_ref_id));
        }

		/// <summary>
		/// System.Security.Principal.IPrincipal.IsInRole를 구현합니다.
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public bool IsInRole(string role)
		{
			return _roleList.Contains( role );
		}

		/// <summary>
		/// System.Security.Principal.IPrincipal.Identity를 구현합니다.
		/// </summary>
		public System.Security.Principal.IIdentity Identity
		{
			get 
			{ 
				return _identity; 
			}
			set 
			{ 
				_identity = value; 
			}
		}

		/// <summary>
		/// Role를 ArrayList 로 반환합니다.
		/// </summary>
		public ArrayList Roles
		{
			get 
			{ 
				return _roleList; 
			}
		}

        public static string GetEncriptString(string iStr)
        {
            byte[] plainText  = new byte[16];
            byte[] cipherText = new byte[16];

            plainText         = Encoding.Unicode.GetBytes(iStr.PadRight(8, ' '));
            Encryption objEcy = new Encryption(Encryption.KeySize.Bits128, new byte[16]);
            objEcy.Cipher(plainText, cipherText);
            return (Encoding.Unicode.GetString(cipherText));
        }
	}
}
