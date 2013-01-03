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
using Infragistics.WebUI.UltraWebGrid;

using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

using MicroCharts;
using Dundas.Charting.WebControl;

using MicroBSC.EIS.Dac;

using MicroBSC.Estimation.Biz;

public partial class EIS_EIS_COMMENT_HTML : EstPageBase
{
    private int ESTTERM_REF_ID;
    private string YMD;
    private int M_ID;
    private int S_ID;
    private int AREA_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        YMD             = WebUtility.GetRequest("YMD");
        M_ID            = WebUtility.GetRequestByInt("M_ID");
        S_ID            = WebUtility.GetRequestByInt("S_ID");
        AREA_ID         = WebUtility.GetRequestByInt("AREA_ID");

        //ESTTERM_REF_ID  = 1000;
        //YMD             = "201001";
        //M_ID            = 1;
        //S_ID            = 1;

        if (!Page.IsPostBack)
        {
            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnEdit);

            //ibnSave.Visible = true;

            if(!ibnSave.Visible && !ibnCancel.Visible) 
            {
                txtContent.Toolbar.Enabled = false;
                txtContent.ReadOnly = true;
                txtContent.TabStripDisplay = false;
            }

            if(ibnEdit.Visible) 
            {
                tr01.Height = "35px";
            }
            else 
            {
                tr01.Height = "10px";
            }

            SetData();
        }

        ltrScript.Text = "";
    }

    private void SetData() 
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        DataTable dt = objEIS.GetEISComment(ESTTERM_REF_ID, YMD, M_ID, S_ID, AREA_ID);

        if(dt.Rows.Count > 0) 
        {
            txtContent.Text = dt.Rows[0]["TEXT_DATA"].ToString();
        }
        else
        {
            txtContent.Text = "";
        }
    }

    protected void ibnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ButtonStatusModify();
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        Dac_EISDatas objEIS = new Dac_EISDatas();
        int affectedRow = objEIS.SaveEISComment(ESTTERM_REF_ID
                                            , YMD
                                            , M_ID
                                            , S_ID
                                            , AREA_ID
                                            , txtContent.Text
                                            , DateTime.Now
                                            , EMP_REF_ID);

        SetData();

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.");

        ButtonStatusInit();
    }

    protected void ibnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ButtonStatusInit();
    }


    //private void ClearValueControls()
    //{
    //    txtEstTermSubID.Text	= "";
    //    txtEstTermSubName.Text	= "";
    //    txtWeight.Text          = "";
    //    txtSortOrder.Text       = "";
    //    txtStartMonth.Text      = "";
    //    txtEndMonth.Text        = "";
    //    ckbYearYN.Checked       = false;
    //    ckbUseYN.Checked        = true;
    //}

    private void ButtonStatusInit()
    {
        ibnEdit.Visible             = true;
        ibnSave.Visible		        = false;
        ibnCancel.Visible		    = false;

        PageWriteMode               = WriteMode.None;

        txtContent.Toolbar.Enabled = false;
        txtContent.ReadOnly = true;
        txtContent.TabStripDisplay = false;
    }

    private void ButtonStatusModify()
    {
        ibnEdit.Visible             = false;
        ibnSave.Visible		        = true;
        ibnCancel.Visible		    = true;

        PageWriteMode               = WriteMode.Modify;

        txtContent.Toolbar.Enabled = true;
        txtContent.ReadOnly = false;
        txtContent.TabStripDisplay = true;
    }
}
