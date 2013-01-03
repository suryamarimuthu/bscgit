using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz;

public partial class base_Main : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        writeLog(string.Format("{0} : Page_Load START", Request.PhysicalPath));

        if (!Page.IsPostBack) 
        {
            //if (PageUtility.IsContainSystemAdminUser(EMP_REF_ID))
            //{
            //    switch (ConfigurationManager.AppSettings["MainPage.Type"].ToString())
            //    {
            //        case "1":
            //            Response.Redirect("~/BSC/BSC0408S2.aspx");
            //            break;
            //        case "2":
            //            Response.Redirect("~/BSC/BSC0408S1.aspx");
            //            break;
            //        case "3":
            //            Response.Redirect("~/usr/usr1005.aspx");
            //            break;
            //        case "4":
            //            Response.Redirect("~/USR/usr10001.aspx");
            //            break;
            //        case "5":
            //            Response.Redirect("~/base/AlertPage.aspx");
            //            break;
            //        default:
            //            Response.Redirect("~/usr/usr1005.aspx");
            //            break;
            //    }
            //}
            //else 
            //{
            //    if (PageUtility.IsContainSMGUser(EMP_REF_ID))
            //    {
            //        Response.Redirect("../usr/usr1005.aspx");
            //    }
            //    else 
            //    {
            //        Response.Redirect("../usr/usr1005.aspx");
            //    }
            //}


            MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Role_Rel bizComEmpRoleRel = new MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Role_Rel();

            int isExecuteDirector = 0;
            isExecuteDirector += bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, 2) ? 1 : 0;//본부장
            isExecuteDirector += bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, 6) ? 1 : 0;//임원

            //if (isExecuteDirector > 0)
            //{
                
            //    if (gUserInfo.Position_Rank_Code == "100" )
            //    {
            //        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
            //        //본부장 경우
            //        Response.Redirect("~/bsc/bsc_intro1.aspx");


            //    }
            //    else
            //    {
            //        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
            //        //대표이사, 임원 권한인경우
            //        Response.Redirect("~/bsc/bsc_intro2.aspx");

            //    }
                    
             
            //    //writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));

                
            //    ////대표이사, 임원 권한인경우
            //    //Response.Redirect("~/bsc/bsc_intro2.aspx");
            //}

            if (isExecuteDirector > 0)
            {

                if (bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, 6))
                {
                    writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                    //임원 경우
                    Response.Redirect("~/bsc/bsc_intro2.aspx");


                }
                else if (bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, 2))
                {
                    writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                    //본부장 권한인경우
                    Response.Redirect("~/bsc/bsc_intro1.aspx");

                }
                else 
                {
                    writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                    //그외 권한인경우
                    Response.Redirect("~/bsc/bsc_intro.aspx");

                }


                //writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));


                ////대표이사, 임원 권한인경우
                //Response.Redirect("~/bsc/bsc_intro2.aspx");
            }
            else
            {
                string mainpage_type = ConfigurationManager.AppSettings["MainPage.Type"].ToString();
                switch (mainpage_type)
                {
                    case "1":
                        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                        Response.Redirect("~/BSC/BSC0408S2.aspx");
                        break;
                    case "2":
                        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                        Response.Redirect("~/BSC/BSC0408S1.aspx");
                        break;
                    case "3":
                        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                        Response.Redirect("~/usr/usr1005.aspx");
                        break;
                    case "4":
                        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                        Response.Redirect("~/USR/usr10001.aspx");
                        break;
                    case "5":
                        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                        Response.Redirect("~/base/AlertPage.aspx");
                        break;
                    case "intro":
                        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                        Response.Redirect("~/bsc/bsc_intro.aspx");
                        break;
                    default:
                        writeLog(string.Format("{0} : !Page.IsPostBack -> Page_Load END", Request.PhysicalPath));
                        Response.Redirect("~/usr/usr1005.aspx");
                        break;
                }
            }
        }


        writeLog(string.Format("{0} : PAGE LOAD END", Request.PhysicalPath));
    }
}
