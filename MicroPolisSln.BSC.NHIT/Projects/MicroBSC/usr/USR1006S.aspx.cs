using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MicroBSC.Integration.USR.Biz;
using System.Data;
using System.Text;

public partial class usr_USR1006S : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dept_id = Request["upId"];
        string depth = Request["level"];

        if (dept_id != null && depth != null && dept_id != "" && depth != "")
        {
            DataTable dt1 = new Biz_Usr_Est_Dept_info().GetDeptInfo_DepthRow(int.Parse(dept_id));
            if (dt1.Rows.Count > 0)
            {
                rpList.DataSource = dt1;
                rpList.DataBind();
                divMessage.Visible = false;
                rpList.Visible = true;
            }
            else
            {
                divMessage.Visible = true;
                rpList.Visible = false;
            }
        }
    }
}
