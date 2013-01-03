using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MicroBSC.Integration.USR.Biz;
using System.Data;
using System.Text;

public partial class usr_USR1006 : AppPageBase
{
    public string Html = string.Empty;
    public int rowCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new Biz_Usr_Est_Dept_info().GetDeptInfo_Depth();
        DataTable dt1 = new Biz_Usr_Est_Dept_info().GetDeptInfo_DepthRow();
        rowCount = dt.Rows.Count;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt1.Rows[i]["DEPT_LEVEL"].ToString() == "1")
            {
                Html = string.Format("<div class='dept' onclick=\"fnClick('{0}', '{1}', this);\">{2}</div>"
                    , dt1.Rows[i]["DEPT_LEVEL"]
                    , dt1.Rows[i]["DEPT_REF_ID"]
                    , dt1.Rows[i]["DEPT_NAME"]);
            }
        }
    }
}
