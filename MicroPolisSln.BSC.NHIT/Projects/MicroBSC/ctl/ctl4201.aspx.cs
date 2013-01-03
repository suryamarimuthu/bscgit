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

public partial class ctl_ctl4201 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDimensionName.Focus();

            if (Request["MODE"].Equals("NUMBER")) 
            {
                IMG1.Src = "../images/title/ma_t10.gif";

                if (Request["TYPE"].Equals("NEW")) 
                {
                    iBtnUpdate.ImageUrl = "../images/btn/b_156.gif";
                    iBtnDelete.Visible = false;
                }
                else if (Request["TYPE"].Equals("MODIFY"))
                {
                    iBtnUpdate.ImageUrl = "../images/btn/b_002.gif";
                    iBtnDelete.Visible = true;

                    LowDemensionNumbers number = new LowDemensionNumbers();
                    DataSet ds = number.GetLowDemensionNumberBySeq(int.Parse(Request["SEQ"]));
                    txtDimensionName.Text = ds.Tables[0].Rows[0]["DIMENSION_NAME"].ToString();

                }
            }
            else if (Request["MODE"].Equals("NAME"))
            {
                IMG1.Src = "../images/title/ma_t11.gif";

                if (Request["TYPE"].Equals("NEW"))
                {
                    iBtnUpdate.ImageUrl = "../images/btn/b_156.gif";
                    iBtnDelete.Visible = false;
                }
                else if (Request["TYPE"].Equals("MODIFY"))
                {
                    iBtnUpdate.ImageUrl = "../images/btn/b_002.gif";
                    iBtnDelete.Visible = true;

                    LowDemensionNames number = new LowDemensionNames();
                    DataSet ds = number.GetLowDemensionNameBySeq(int.Parse(Request["SEQ"]));
                    txtDimensionName.Text = ds.Tables[0].Rows[0]["DIMENSION_NAME"].ToString();
                }
            }
        }
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["MODE"].Equals("NUMBER"))
        {
            if (Request["TYPE"].Equals("NEW"))
            {
                LowDemensionNumbers number = new LowDemensionNumbers();
                number.AddLowDemensionNumber(Request["KPI_CODE"], txtDimensionName.Text);
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnNumber", true);
            }
            else if (Request["TYPE"].Equals("MODIFY"))
            {
                LowDemensionNumbers number = new LowDemensionNumbers();
                number.ModifyLowDemensionNumber(int.Parse(Request["SEQ"]), txtDimensionName.Text);
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnNumber", true);
            }
        }
        else if (Request["MODE"].Equals("NAME"))
        {
            if (Request["TYPE"].Equals("NEW"))
            {
                LowDemensionNames number = new LowDemensionNames();
                number.AddLowDemensionName(Request["KPI_CODE"], txtDimensionName.Text);
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnName", true);
            }
            else if (Request["TYPE"].Equals("MODIFY"))
            {
                LowDemensionNames number = new LowDemensionNames();
                number.ModifyLowDemensionName(int.Parse(Request["SEQ"]), txtDimensionName.Text);
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnName", true);
            }
        }
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["MODE"].Equals("NUMBER"))
        {
            if (Request["TYPE"].Equals("MODIFY"))
            {
                LowDemensionNumbers number = new LowDemensionNumbers();
                number.RemoveLowDemensionNumber(int.Parse(Request["SEQ"]));
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnNumber", true);
            }
        }
        else if (Request["MODE"].Equals("NAME"))
        {
            if (Request["TYPE"].Equals("MODIFY"))
            {
                LowDemensionNames number = new LowDemensionNames();
                number.RemoveLowDemensionName(int.Parse(Request["SEQ"]));
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적 처리되었습니다.", "lBtnName", true);
            }
        }
    }
}
