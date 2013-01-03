using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase : System.Web.UI.Page
{
    protected const int POP_HEIGHT = 30;
    private int     _emp_ref_id;
    private string _role_admin;
    private string _role_bscadmin;
    private string _role_estadmin;
    private string _role_officer;
    private string _role_champ;
    private string _role_team;
    private string _role_emp;
    private string _role_ceo;
    private string _role_est_emp;
    private ArrayList _emp_roles;

    protected int EMP_REF_ID            { get { return _emp_ref_id; } set{_emp_ref_id = value;}}
    protected string ROLE_ADMIN         { get { return _role_admin; } }
    protected string ROLE_BSCADMIN      { get { return _role_bscadmin; } }
    protected string ROLE_ESTADMIN      { get { return _role_estadmin; } }
    protected string ROLE_OFFICER       { get { return _role_officer; } }
    protected string ROLE_CHAMPION      { get { return _role_champ; } }
    protected string ROLE_TEAM_MANAGER  { get { return _role_team; } }
    protected string ROLE_EMPLOYEE      { get { return _role_emp; } }
    protected string ROLE_CEO           { get { return _role_ceo; } }
    protected string ROLE_EST_EMPLOYEE  { get { return _role_est_emp; } }

    /// <summary>
    /// Role.Admin(시스템관리자)      : 1  ,                   
    /// Role.Officer(임원)            : 2  ,
    /// Role.Champ(챔피언)            : 3  ,
    /// Role.Team(팀장)               : 4  ,
    /// Role.Emp(일반사원)            : 5  ,
    /// Role.CEO(대표이사)            : 6  ,
    ///	Role.Est_Emp(평가자)          : 7  ,
    /// Role.BscAdmin(BSC관리자)      : 8  ,
    /// Role.EstAdmin(성과평가관리자) : 9  ,
    /// (부서평가 의견상신 권한)      :	10 ,
    /// (역량평가 직무 설정 권한)     :	11 ,
    /// (질의풀 관리 권한)            : 12 ,
    /// (EIS 관리자)                  : 15 ,
    /// </summary>
    protected ArrayList EMP_ROLES       { get { return _emp_roles; } }

    override protected void OnPreInit(EventArgs e)
    {
        // this.Master == null 이면 팝업이다.
        string master_site = WebUtility.GetConfig("SITE", "");

        if (this.Master != null)
        {
            this.Page.MasterPageFile = string.Format("~/_common/lib{0}/MicroBSC.master", master_site);
        }
    }


    protected void writeLog(string msg)
    {
        //페이지 열릴대마다 로그 기록
        if (WebUtility.GetConfig("USE_PAGE_OPEN_LOG", "N").Equals("Y"))
        {
            string base_dir = System.Web.HttpContext.Current.Server.MapPath("~");

            string fileName = WebUtility.GetConfig("PAGE_OPEN_LOG_FILE", "~\\log.txt");
            string name = fileName.Substring(0, fileName.LastIndexOf("."));
            if (name.IndexOf("~") > -1)
                name = name.Replace("~\\", base_dir);
            string ext = fileName.Substring(fileName.LastIndexOf("."));
            string logFile = name + System.DateTime.Now.ToString("_yyyy-MM-dd") + ext;

            string proxyAddr = DataTypeUtility.GetString(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            string remoteAddr = DataTypeUtility.GetString(Request.ServerVariables["REMOTE_ADDR"]);

            string userAddr = string.Format("PROXY:{0}, USER:{1}", proxyAddr, remoteAddr);

            System.Text.StringBuilder logMsg = new System.Text.StringBuilder();
            logMsg.Append(msg);

            try
            {
                MicroBSC.Common.ErrorLogs.WriteFileError(logMsg.ToString(), userAddr, logFile);
            }
            catch (Exception ex)
            { }
        }
    }


    override protected void OnInit(EventArgs e)
    {
        //페이지 열릴대마다 로그 기록
        writeLog(Request.PhysicalPath);

        //this.Page.RegisterRequiresViewStateEncryption();
        //this.Page.RegisterRequiresControlState(this);
        base.OnInit(e);

        string path = this.Page.Request.Path.ToLower();
        //string pathInfo = this.Page.Request.PathInfo.ToLower();
        //string masterid = this.Master.ID;
        

        
        if (Context.User.Identity.IsAuthenticated)
        {
            //Page.ViewStateUserKey = Session.SessionID;
            Page.ViewStateUserKey = Context.User.Identity.Name;
            RoleBases role = new RoleBases();

            _emp_ref_id     = ((SiteIdentity)Context.User.Identity).Emp_Ref_ID;
            _role_admin     = role.ROLE_ADMIN;
            _role_officer   = role.ROLE_OFFICER;
            _role_champ     = role.ROLE_CHAMPION;
            _role_team      = role.ROLE_TEAM_MANAGER;
            _role_emp       = role.ROLE_EMPLOYEE;
            _role_ceo       = role.ROLE_CEO;
            _role_est_emp   = role.ROLE_EST_EMPLOYEE;
            _role_bscadmin  = role.ROLE_BSCADMIN;
            _role_estadmin  = role.ROLE_ESTADMIN;

            _emp_roles = ((SitePrincipal)this.User).Roles;

            if (path.IndexOf("login.aspx") > 0 || path.IndexOf("logout.aspx") > 0 )
            {
                FormsAuthentication.SignOut();
            }
            else
            {
                if (path.IndexOf("dashboard/nhit_") > 0 
                    || path.IndexOf("usr_dept_org.aspx") > 0
                    || path.IndexOf("usr/usr10001.aspx") > 0
                    || path.IndexOf("bsc_intro") > 0
                    || path.IndexOf("bsc0406s3.aspx") > 0
                    )
                    return;

                string filter = "0";
                if (_emp_roles.Count > 0)
                {
                    for (int i = 0; i < _emp_roles.Count; i++)
                    {
                        filter += "," + _emp_roles[i].ToString();
                    }
                }

                // this.Master == null 이면 팝업이다.
                if (this.Master != null)
                {
                    MicroBSC.Integration.COM.Biz.Biz_Role_Menu_Rel bizRoleMenuRel = new MicroBSC.Integration.COM.Biz.Biz_Role_Menu_Rel();
                    DataTable dtRoleMenuRel = bizRoleMenuRel.GetRoleMenuRel_DB(filter);
                    if (dtRoleMenuRel.Rows.Count > 0)
                    {
                        DataRow[] rows = dtRoleMenuRel.Select(string.Format(" MENU_FULL_PATH LIKE '%{0}%' ", path));
                        if (rows.Length == 0)
                        {
                            //관리자는 메뉴 등록 여부 검사 패스
                            if (filter.IndexOf(role.ROLE_ADMIN) > -1)
                                return;

                            FormsAuthentication.SignOut();
                            this.Page.Response.Redirect(path);
                                
                        }
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                        this.Page.Response.Redirect(path);
                    }
                }
            }
        }
        else
        {
            int defaultValue = -1;
            //_emp_ref_id = 0;
            _emp_ref_id = defaultValue;

            _emp_roles = new ArrayList();
            _emp_roles.Add(defaultValue);

            //FormsAuthentication.SignOut();
        }

        Response.AddHeader("P3P", "CP='CAO PSA CONi OTR OUR DEM ONL'");
    }   
}