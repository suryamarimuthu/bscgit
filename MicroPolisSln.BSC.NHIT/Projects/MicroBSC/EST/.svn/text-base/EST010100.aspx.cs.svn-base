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

public partial class EST_EST010100 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!IsPostBack)
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);

            TextBoxCommon.SetOnlyInteger(txtEstTermSubID);
            TextBoxCommon.SetOnlyInteger(txtSortOrder);
            TextBoxCommon.SetOnlyInteger(txtStartMonth);
            TextBoxCommon.SetOnlyInteger(txtEndMonth);
            TextBoxCommon.SetOnlyPercent(txtWeight);

			GridBinding(WebUtility.GetIntByValueDropDownList(ddlCompID));
			ButtonStatusInit();
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);

		ltrScript.Text  = "";
	}

	private void GridBinding(int comp_id)
	{
		Biz_TermSubs termSubs   = new Biz_TermSubs();
		DataSet ds              = termSubs.GetTermSubs(comp_id, "");

		UltraWebGrid1.DataSource = ds;
		UltraWebGrid1.DataBind();

		lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
	}

	private void ViewOne(int comp_id, int estterm_sub_id )
	{
		Biz_TermSubs termSub   = new Biz_TermSubs(comp_id, estterm_sub_id );

		txtEstTermSubID.Text   = termSub.EstTerm_Sub_ID.ToString();
		txtEstTermSubName.Text = termSub.EstTerm_Sub_Name;
        txtWeight.Text         = DataTypeUtility.GetValue(termSub.Weight);
        ckbYearYN.Checked      = DataTypeUtility.GetYNToBoolean(termSub.Year_YN);
        txtSortOrder.Text      = DataTypeUtility.GetValue(termSub.Sort_Order);
        ckbUseYN.Checked       = DataTypeUtility.GetYNToBoolean(termSub.Use_YN);
        txtStartMonth.Text     = DataTypeUtility.GetValue(termSub.Start_Month);
        txtEndMonth.Text       = DataTypeUtility.GetValue(termSub.End_Month);

		hdfEstTermSubID.Value  = estterm_sub_id.ToString();
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
	}

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		hdfEstTermSubID.Value	= e.SelectedRows[0].Cells.FromKey( "ESTTERM_SUB_ID" ).Value.ToString();

        ViewOne(COMP_ID, DataTypeUtility.GetToInt32( hdfEstTermSubID.Value ) );
		ButtonStatusModify();
	}

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		if ( txtEstTermSubID.Text.Trim().Length == 0 )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "평가주기ID를 입력해주세요." );
			return;
		}

		int intEstTermSubID     = DataTypeUtility.GetToInt32(txtEstTermSubID.Text);
		Biz_TermSubs termSubs   = new Biz_TermSubs();
		bool bDuplicate         = termSubs.IsExist(COMP_ID, intEstTermSubID );

		if (bDuplicate)
		{
			ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가주기 ID가 있습니다.");
		}
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("사용가능한 평가주기 ID 입니다.");
        }
	}

	protected void ibnNew_Click( object sender, ImageClickEventArgs e )
	{
		ButtonStatusNew();
	}

	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
		int intEstTermSubID         = DataTypeUtility.GetToInt32(txtEstTermSubID.Text);
		string strEstTermSubName    = txtEstTermSubName.Text;
        double weight               = DataTypeUtility.GetToDouble(txtWeight.Text);
        string year_yn              = DataTypeUtility.GetBooleanToYN(ckbYearYN.Checked);
        int sort_order              = DataTypeUtility.GetToInt32(txtSortOrder.Text);
        string use_yn               = DataTypeUtility.GetBooleanToYN(ckbUseYN.Checked);
        int startMonth              = DataTypeUtility.GetToInt32(txtStartMonth.Text);
        int endMonth                = DataTypeUtility.GetToInt32(txtEndMonth.Text);

		Biz_TermSubs termSubs = new Biz_TermSubs();

        if (PageWriteMode == WriteMode.New)
        {
		    bool bDuplicate         = termSubs.IsExist(COMP_ID, intEstTermSubID );

		    if (bDuplicate)
		    {
			    ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가주기 ID가 있습니다.");
                return;
		    }

		    bool bResult = termSubs.AddTermSub(   COMP_ID
                                                , intEstTermSubID
											    , strEstTermSubName
                                                , weight
                                                , year_yn
                                                , sort_order
                                                , startMonth
                                                , endMonth
                                                , use_yn
											    , DateTime.Now
											    , EMP_REF_ID);

		    if (bResult)
		    {
			    GridBinding(COMP_ID);
			    ButtonStatusInit();
		    }
		    else
		    {
			    ltrScript.Text = JSHelper.GetAlertScript("저장 중 오류가 발생되었습니다.");
                return;
		    }
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            bool bResult = termSubs.ModifyTermSub(COMP_ID
                                                , intEstTermSubID
												, strEstTermSubName
                                                , weight
                                                , year_yn
                                                , sort_order
                                                , startMonth
                                                , endMonth
                                                , use_yn
												, DateTime.Now
												, EMP_REF_ID);

		    if (bResult)
		    {
			    GridBinding(COMP_ID);
			    ButtonStatusInit();
		    }
		    else
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "수정 중 오류가 발생하였습니다." );
                return;
		    }
        }
	}

	protected void ibnDelete_Click( object sender, ImageClickEventArgs e )
	{
		int intEstTermSubID			= Convert.ToInt32( hdfEstTermSubID.Value.Trim() );

		Biz_TermSubs termSubs       = new Biz_TermSubs();
		bool bResult                = termSubs.RemoveTermSub(COMP_ID, intEstTermSubID );

		if (bResult)
		{
			ltrScript.Text = JSHelper.GetAlertScript("삭제되었습니다.", false);

			GridBinding(COMP_ID);
			ButtonStatusInit();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("삭제되지 않았습니다.");
		}
	}

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBinding(COMP_ID);
        ClearValueControls();
    }

    private void ClearValueControls()
	{
		txtEstTermSubID.Text	= "";
		txtEstTermSubName.Text	= "";
        txtWeight.Text          = "";
        txtSortOrder.Text       = "";
        txtStartMonth.Text      = "";
        txtEndMonth.Text        = "";
        ckbYearYN.Checked       = false;
        ckbUseYN.Checked        = true;
	}

    private void ButtonStatusInit()
	{
		ibnSave.Enabled		        = false;
		ibnDelete.Enabled		    = false;

		ibnCheckID.Visible          = false;
        txtEstTermSubID.Width       = Unit.Pixel(50);

		ClearValueControls();

		txtEstTermSubID.Enabled     = false;

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = false;

		ibnCheckID.Visible          = true;
		txtEstTermSubID.Width       = Unit.Pixel(50);

		ClearValueControls();

		txtEstTermSubID.Enabled     = true;

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.New;
	}

	private void ButtonStatusModify()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = true;

		ibnCheckID.Visible          = false;
		txtEstTermSubID.Width       = Unit.Pixel(50);

		txtEstTermSubID.Enabled     = false;

        ibnSave.ImageUrl            = "../images/btn/b_002.gif";//"저장";

		PageWriteMode               = WriteMode.Modify;
	}
}
