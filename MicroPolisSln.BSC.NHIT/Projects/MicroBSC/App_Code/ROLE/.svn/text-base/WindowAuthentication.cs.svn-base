using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;

namespace MicroBSC.RolesBasedAthentication
{
    public class WindowAuthentication
	{
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool LogonUser(String lpszUserName, String lpszDomain, String lpszPassword,int dwLogonType,int dwLogonProvider, out int phToken);

        [DllImport("advapi32.dll")]
        public static extern int RevertToSelf();

        [DllImport("advapi32.dll")]
        public static extern int ImpersonateLoggedOnUser(IntPtr phToken);

        public static bool ValidateLogin(string uid, string pwd, string domain, HttpContext context)
		{
			try
			{
				int token1; 
				bool loggedOn = LogonUser(uid,domain,pwd,2,0,out token1); 
				IntPtr token2 = new IntPtr(token1); 

				WindowsIdentity wi = new WindowsIdentity(token2); 
				WindowsPrincipal wp = new WindowsPrincipal(wi); 
				HttpContext.Current.User = wp; 
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}
	} 
}