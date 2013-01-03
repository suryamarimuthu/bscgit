using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

public partial class _common_lib_ApprovalListControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        APP_SetAppProcInfo();
        //Literal3.Text = "진행";
    }

    public void APP_SetAppProcInfo()
    {
        int empId = ((SiteIdentity)Context.User.Identity).Emp_Ref_ID;

        Com_approval_prcs appPrcInfo = new Com_approval_prcs();
        Literal3.Text = appPrcInfo.GetApprovalPrc_InfoByEmpID(empId, Com_approval_prcs.ApprovalStatus.Pending).Tables[0].Rows.Count.ToString();
    }
}
