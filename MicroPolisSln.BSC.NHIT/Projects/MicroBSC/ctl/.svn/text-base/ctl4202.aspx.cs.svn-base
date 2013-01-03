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
using System.Drawing;

using MicroBSC.Common;
using MicroBSC.Biz.Common;

public partial class ctl_ctl4202 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCode.Focus();

            if (Request["MODE"].Equals("STRING")) 
            {
                if (Request["TYPE"].Equals("NEW")) 
                {
                    iBtnUpdate.ImageUrl = "../images/btn/b_156.gif";
                }
                else if (Request["TYPE"].Equals("MODIFY"))
                {
                    iBtnUpdate.ImageUrl = "../images/btn/b_002.gif";

                    LowDemensionStrings number = new LowDemensionStrings();
                    DataSet ds = number.GetLowDemensionStringBySeq(int.Parse(Request["SEQ"]));
                    txtCode.Text        = ds.Tables[0].Rows[0]["DIMENSION_NAME"].ToString();
                    txtCodeName.Text    = ds.Tables[0].Rows[0]["sValueDetail1"].ToString();
                }
            }
        }
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["MODE"].Equals("STRING"))
        {
            if (Request["TYPE"].Equals("NEW"))
            {
                iBtnUpdate.ImageUrl = "../images/btn/b_156.gif";
                LowDemensionStrings number = new LowDemensionStrings();
                number.AddLowDemensionString(Request["KPI_CODE"], Request["DEMENSION_POSITION"], txtCode.Text, txtCodeName.Text);
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnString", true);
            }
            else if (Request["TYPE"].Equals("MODIFY"))
            {
                iBtnUpdate.ImageUrl = "../images/btn/b_002.gif";

                LowDemensionStrings number = new LowDemensionStrings();
                number.ModifyLowDemensionString(int.Parse(Request["SEQ"]), txtCode.Text, txtCodeName.Text);
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnString", true);
            }
        }
    }
}
