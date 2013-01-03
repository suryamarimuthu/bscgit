//=======================================================================
//   (주) 마이크로폴리스 RoleBases Common
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

namespace MicroBSC.Common
{
    public class RoleBases
    {
        private string _role_admin;
        private string _role_bscadmin;
        private string _role_estadmin;
        private string _role_officer;
        private string _role_champ;
        private string _role_team;
        private string _role_emp;
        private string _role_ceo;
        private string _role_est_emp;
        private string _role_eis_management;
        private string _role_eis_sales;
        private string _role_eis_customer;
        private string _role_eis_gastools;
        private string _role_eis_finance;
        private string _role_eis_safety;
        private string _role_eis_personage;

        public string ROLE_ADMIN        { get { return _role_admin; } }
        public string ROLE_BSCADMIN     { get { return _role_bscadmin; } }
        public string ROLE_ESTADMIN     { get { return _role_estadmin; } }
        public string ROLE_OFFICER      { get { return _role_officer; } }
        public string ROLE_CHAMPION     { get { return _role_champ; } }
        public string ROLE_TEAM_MANAGER { get { return _role_team; } }
        public string ROLE_EMPLOYEE     { get { return _role_emp; } }
        public string ROLE_CEO          { get { return _role_ceo; } }
        public string ROLE_EST_EMPLOYEE { get { return _role_est_emp; } }

        public string ROLE_EIS_MANAGEMENT   { get { return _role_eis_management; } }
        public string ROLE_EIS_SALES        { get { return _role_eis_sales; } }
        public string ROLE_EIS_CUSTOMER     { get { return _role_eis_customer; } }
        public string ROLE_EIS_GASTOOLS     { get { return _role_eis_gastools; } }
        public string ROLE_EIS_FINANCE      { get { return _role_eis_finance; } }
        public string ROLE_EIS_SAFETY       { get { return _role_eis_safety; } }
        public string ROLE_EIS_PERSONAGE    { get { return _role_eis_personage; } }

        /// <summary>
        /// 역할 클래스 생성자 입니다.
        /// </summary>
        public RoleBases()
        {
            _role_admin     = System.Configuration.ConfigurationManager.AppSettings["Role.Admin"];
            _role_bscadmin  = System.Configuration.ConfigurationManager.AppSettings["Role.BscAdmin"];
            _role_estadmin  = System.Configuration.ConfigurationManager.AppSettings["Role.EstAdmin"];
            _role_officer   = System.Configuration.ConfigurationManager.AppSettings["Role.Officer"];
            _role_champ     = System.Configuration.ConfigurationManager.AppSettings["Role.Champ"];
            _role_team      = System.Configuration.ConfigurationManager.AppSettings["Role.Team"];
            _role_emp       = System.Configuration.ConfigurationManager.AppSettings["Role.Emp"];
            _role_ceo       = System.Configuration.ConfigurationManager.AppSettings["Role.CEO"];
            _role_est_emp   = System.Configuration.ConfigurationManager.AppSettings["Role.Est_Emp"];

            _role_eis_management    = System.Configuration.ConfigurationManager.AppSettings["Role.EIS_Management"];
            _role_eis_sales         = System.Configuration.ConfigurationManager.AppSettings["Role.EIS_Sales"];
            _role_eis_customer      = System.Configuration.ConfigurationManager.AppSettings["Role.EIS_Customer"];
            _role_eis_gastools      = System.Configuration.ConfigurationManager.AppSettings["Role.EIS_GasTools"];
            _role_eis_finance       = System.Configuration.ConfigurationManager.AppSettings["Role.EIS_Finance"];
            _role_eis_safety        = System.Configuration.ConfigurationManager.AppSettings["Role.EIS_Safety"];
            _role_eis_personage     = System.Configuration.ConfigurationManager.AppSettings["Role.EIS_Personage"];
        }
    }
}
