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

using MicroBSC.Estimation.Biz;

public partial class EST_EST050100 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if ( !IsPostBack )
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindDefaultValue(ddlEstJobID, "----------", ""); 
            TextBoxCommon.SetOnlyInteger(txtSortOrder);
			BindGrid(WebUtility.GetIntByValueDropDownList(ddlCompID));

			ButtonStatusByInit();
			ClearValueControls();
		}

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

		ltrScript.Text = string.Empty;
	}

    protected void Page_PreRender( object sender, EventArgs e )
	{
        
	}

	private void BindGrid(int comp_id)
	{
		TreeViewCommom.BindJobs(TreeView1, TreeNodeSelectAction.Select, comp_id);
	}

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
		hdfEstScheId.Value	= TreeView1.SelectedValue;
        ViewOne(COMP_ID, hdfEstScheId.Value);
		ButtonStatusByModify();
    }

    private void ViewOne(int comp_id,  string est_sche_id)
    {
		Biz_ScheInfos scheInfos	    = new Biz_ScheInfos(comp_id, est_sche_id);
        Biz_ScheInfos scheInfos_up	= null;

        if(!scheInfos.Up_Est_Sche_ID.Equals(""))
        {
            scheInfos_up	        = new Biz_ScheInfos(comp_id, scheInfos.Up_Est_Sche_ID);
            txtUpEstScheID.Text	    = scheInfos_up.Est_Sche_Name;
        }

		txtEstScheID.Text		= scheInfos.Est_Sche_ID;
		txtEstScheName.Text	    = scheInfos.Est_Sche_Name;
		hdfUpEstScheID.Value	= scheInfos.Up_Est_Sche_ID;
		hdfEstID.Value			= scheInfos.Est_ID;
		txtEstScheDesc.Text	    = scheInfos.Est_Sche_Desc;
		txtSortOrder.Text		= scheInfos.Sort_Order.ToString();

		Biz_EstInfos estInfos   = new Biz_EstInfos(comp_id, scheInfos.Est_ID);
		txtEstID.Text			= estInfos.Est_Name;

        DropDownListCommom.BindEstJobMapNotIn(ddlEstJobID, COMP_ID, hdfEstID.Value, true);
    }

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		if ( txtEstScheID.Text.Trim().Length == 0 )
		{
			ltrScript.Text      = JSHelper.GetAlertScript("일정 ID를 입력해주세요.");
			return;
		}

		string strEstScheID     = txtEstScheID.Text.Trim();
		Biz_ScheInfos scheInfos = new Biz_ScheInfos();
		bool bDuplicate         = scheInfos.IsExist(COMP_ID, strEstScheID);

		if ( bDuplicate )
		{
			ltrScript.Text = JSHelper.GetAlertScript("존재하는 일정 ID가 있습니다.");
		}
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("사용가능한 일정 ID 입니다.");
        }
	}

	protected void ibnNew_Click( object sender, ImageClickEventArgs e )
	{
		ButtonStatusByNew();
	}

	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
		string est_sche_id		= txtEstScheID.Text.Trim();

		if ( est_sche_id.Length == 0 )
		{
			est_sche_id			= hdfEstScheId.Value.Trim();
		}

		string up_est_sche_id	= hdfUpEstScheID.Value.Trim();
		string est_sche_name	= txtEstScheName.Text.Trim();
		string est_sche_desc	= txtEstScheDesc.Text.Trim();
		int sort_order			= DataTypeUtility.GetToInt32( txtSortOrder.Text );
		string est_id		    = hdfEstID.Value.Trim();

		Biz_ScheInfos scheInfos	= new Biz_ScheInfos();

		if ( PageWriteMode == WriteMode.New )
		{
			bool bDuplicate			= scheInfos.IsExist(COMP_ID, est_sche_id);

			if ( bDuplicate == true )
			{
				ltrScript.Text = JSHelper.GetAlertScript( "존재하는 일정 ID가 있습니다.", false );
				return;
			}

			bool bResult = scheInfos.AddScheInfo( COMP_ID
                                                , est_sche_id
												, up_est_sche_id
												, est_sche_name
												, est_sche_desc
												, sort_order
												, est_id
												, DateTime.Now
												, gUserInfo.Emp_Ref_ID
												);

			if ( bResult == true )
			{
				ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.");
				BindGrid(COMP_ID);
				ButtonStatusByInit();
			}
			else
			{
				ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
				return;
			}
		}
		else if ( PageWriteMode == WriteMode.Modify )
		{
			bool bIsExist			= scheInfos.IsExist(COMP_ID, est_sche_id);

			if ( bIsExist == false )
			{
				ltrScript.Text = JSHelper.GetAlertScript("해당 자료가 없습니다.");
				return;
			}

			bool bResult = scheInfos.ModifyScheInfo(  COMP_ID
                                                    , est_sche_id
													, up_est_sche_id
													, est_sche_name
													, est_sche_desc
													, sort_order
													, est_id
													, DateTime.Now
													, gUserInfo.Emp_Ref_ID
													);

			if ( bResult == true )
			{
				ltrScript.Text = JSHelper.GetAlertScript( "정상적으로 수정되었습니다." );
				BindGrid(COMP_ID);
				ButtonStatusByInit();
			}
			else
			{
				ltrScript.Text = JSHelper.GetAlertBackScript( "수정되지 않았습니다." );
				return;
			}
		}
	}

	protected void ibnDelete_Click( object sender, ImageClickEventArgs e )
	{
		string est_sche_id		= hdfEstScheId.Value.Trim();

		if ( est_sche_id.Length == 0 )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "선택된 일정 ID가 없습니다." );
			return;
		}

		Biz_ScheInfos scheInfos = new Biz_ScheInfos();
		bool bResult            = scheInfos.RemoveScheInfo(COMP_ID, est_sche_id);

		if ( bResult == true )
		{
			BindGrid(COMP_ID);
			ButtonStatusByInit();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertBackScript( "삭제되지 않았습니다." );
            return;
		}
	}

    protected void lbnEstJobMap_Click(object sender, EventArgs e)
    {
        DropDownListCommom.BindEstJobMapNotIn(ddlEstJobID, COMP_ID, hdfEstID.Value, true);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
 
	private void ClearValueControls()
	{
		txtEstScheID.Text			= string.Empty;
		txtEstScheName.Text		    = string.Empty;
		hdfUpEstScheID.Value		= string.Empty;
		txtUpEstScheID.Text		    = string.Empty;
		hdfEstID.Value		        = string.Empty;
		txtEstID.Text		        = string.Empty;
		txtEstScheDesc.Text		    = string.Empty;

		hdfUpEstScheID.Value		= string.Empty;

		txtSortOrder.Text			= "0";
	}

    private void ButtonStatusByInit()
    {
		txtEstScheID.ReadOnly	= false;

        ibnNew.Enabled          = true;
        ibnSave.Enabled         = false;
        ibnDelete.Enabled       = false;

        ibnCheckID.Visible      = false;
        txtEstScheID.Width      = Unit.Percentage(100);
        txtEstScheID.Enabled    = false;

        ClearValueControls();

		txtEstScheID.Enabled	= false;
		txtEstScheName.Enabled	= false;
		txtUpEstScheID.Enabled	= false;
		imgUpEstScheID.Visible	= true;
		txtEstScheDesc.Enabled	= false;
		txtEstID.Enabled		= false;
		imgEstID.Disabled		= true;
		txtSortOrder.Enabled	= false;
        ddlEstJobID.Enabled     = false;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode = WriteMode.None;
    }

	private void ButtonStatusByNew()
	{
		txtEstScheID.ReadOnly	= false;

        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;
        ibnDelete.Enabled       = false;

        ibnCheckID.Visible      = true;
        txtEstScheID.Width      = Unit.Percentage(60);
        txtEstScheID.Enabled    = true;

        ClearValueControls();

		txtEstScheID.Enabled	= true;
		txtEstScheName.Enabled	= true;
		txtUpEstScheID.Enabled	= true;
		imgUpEstScheID.Visible	= true;
		txtEstScheDesc.Enabled	= true;
		txtEstID.Enabled		= true;
		imgEstID.Disabled		= false;
		txtSortOrder.Enabled	= true;
        ddlEstJobID.Enabled     = true;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.New;
	}

    private void ButtonStatusByModify()
    {
		txtEstScheID.ReadOnly	= true;

        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;
        ibnDelete.Enabled       = true;

        ibnCheckID.Visible      = false;
        txtEstScheID.Width      = Unit.Percentage(100);

		txtEstScheID.Enabled	= true;
		txtEstScheName.Enabled	= true;
		txtUpEstScheID.Enabled	= true;
		txtEstScheDesc.Enabled	= true;
		imgUpEstScheID.Visible	= false;
		txtEstID.Enabled		= true;
		imgEstID.Disabled		= false;
		txtSortOrder.Enabled	= true;
        ddlEstJobID.Enabled     = true;

        ibnSave.ImageUrl        = "../images/btn/b_002.gif";//"수정";

        PageWriteMode           = WriteMode.Modify;
    }
}
