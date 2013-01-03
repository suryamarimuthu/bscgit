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
using Infragistics.WebUI.UltraWebTab;

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

using MicroBSC.Estimation.Biz;

public partial class EST_EST040100 : EstPageBase
{
    //private enum TabType
    //{
    //      SET_SCALE  = 1
    //    , SET_WEIGHT
    //    , SET_REL_GROUP
    //}

    //private enum EstWeightType
    //{
    //      DPT
    //    , POS
    //}

    private string EST_ID;
	private string WEIGHT_TYPE;
    private string SCALE_TYPE;

	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if ( !IsPostBack )
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
			TreeViewCommom.BindEst(TreeView1, WebUtility.GetIntByValueDropDownList(ddlCompID));
            DropDownListCommom.BindEstScaleInfo(ddlBScale, true, WebUtility.GetIntByValueDropDownList(ddlCompID));
			DropDownListCommom.BindEstTerm(ddlEstTermRefID);

            hdfTabKey.Value  = "1";

            ibnEst1.ImageUrl = "../images/btn/btn1Down.gif";
			ibnEst2.ImageUrl = "../images/btn/btn2Up.gif";
			ibnEst3.ImageUrl = "../images/btn/btn3Up.gif";
		}

        COMP_ID             = WebUtility.GetIntByValueDropDownList(ddlCompID);
		EST_ID				= TreeView1.SelectedValue;
		ESTTERM_REF_ID		= WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        WEIGHT_TYPE			= hdfWeightType.Value;
        SCALE_TYPE          = hdfScaleType.Value;

		ltrScript.Text      = "";
	}

	private void InitValueSetting()
	{
		ifmContent.Attributes.Add( "src", "EST040101.ASPX" + GetTabParam() );
	}

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
		hdfEstID.Value = TreeView1.SelectedValue;
		SetWeightType(COMP_ID, hdfEstID.Value);

        WEIGHT_TYPE	   = hdfWeightType.Value;
        SCALE_TYPE     = hdfScaleType.Value;
		View(hdfTabKey.Value);
    }

	private void View(string tabKey)
	{
        if(EST_ID.Equals("")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가가 선택되지 않았습니다.");
            return;
        }

        if(hdfWeightType.Value.Equals("")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가에 따른 가중치가 설정되어 있지 않습니다.");
            return;
        }

        if(hdfScaleType.Value.Equals("")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가에 따른 평가방법이 설정되어 있지 않습니다.");
            return;
        }

		if (tabKey.Equals("1"))
		{
			ibnEst1.ImageUrl = "../images/btn/btn1Down.gif";
			ibnEst2.ImageUrl = "../images/btn/btn2Up.gif";
			ibnEst3.ImageUrl = "../images/btn/btn3Up.gif";
		}
		else if (tabKey.Equals("2"))
		{
			ibnEst1.ImageUrl = "../images/btn/btn1Up.gif";
			ibnEst2.ImageUrl = "../images/btn/btn2Down.gif";
			ibnEst3.ImageUrl = "../images/btn/btn3Up.gif";
		}
		else if (tabKey.Equals("3"))
		{
			ibnEst1.ImageUrl = "../images/btn/btn1Up.gif";
			ibnEst2.ImageUrl = "../images/btn/btn2Up.gif";
			ibnEst3.ImageUrl = "../images/btn/btn3Down.gif";
		}
        else 
        {
            return;
        }

		string strTarget    = string.Format( "EST04010{0}.aspx" + GetTabParam(), tabKey);
        ltrTabPage.Text     = JSHelper.GetBlankScript(string.Format("ifmContent.location.href = '{0}';", strTarget));
	}

	protected void SetTab_Click( object sender, ImageClickEventArgs e )
	{
		ImageButton ibtnNow	= (ImageButton)sender;
		hdfTabKey.Value		= ibtnNow.CommandArgument;

		View(hdfTabKey.Value);
	}

	private void SetWeightType(int comp_id, string est_id)
	{
		Biz_EstInfos estInfos	= new Biz_EstInfos(comp_id, est_id);
		hdfWeightType.Value	    = estInfos.Weight_Type;
        hdfScaleType.Value      = estInfos.Scale_Type;
	}

    private void TreeBinding(int comp_id)
    {
        TreeViewCommom.BindEst(TreeView1, comp_id);
    }

	private string GetTabParam()
	{
		string strParam = string.Format( @"?COMP_ID={0}&ESTTERM_REF_ID={1}&EST_ID={2}&WEIGHT_TYPE={3}&SCALE_TYPE={4}"
                                        , COMP_ID
										, ESTTERM_REF_ID
										, hdfEstID.Value
										, WEIGHT_TYPE
                                        , SCALE_TYPE);
		return strParam;
	}

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
		View(hdfTabKey.Value);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeViewCommom.BindEst(TreeView1, COMP_ID);
        DropDownListCommom.BindEstScaleInfo(ddlBScale, true, COMP_ID);
    }
}
