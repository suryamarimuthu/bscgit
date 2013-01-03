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

public partial class EST_EST010200 : EstPageBase
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

            TextBoxCommon.SetOnlyInteger(txtEstTermStepID);
            TextBoxCommon.SetOnlyPercent(txtWeight);
            TextBoxCommon.SetOnlyInteger(txtSortOrder);

			GridBinding( WebUtility.GetIntByValueDropDownList(ddlCompID) );
			ButtonStatusInit();
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);

		ltrScript.Text  = "";
	}

	private void GridBinding(int comp_id)
	{
		Biz_TermSteps termSteps     = new Biz_TermSteps();
		DataSet ds                  = termSteps.GetTermSteps(comp_id, "");

		UltraWebGrid1.DataSource    = ds;
		UltraWebGrid1.DataBind();

		lblRowCount.Text            = ds.Tables[0].Rows.Count.ToString();
	}

	private void ViewOne(int comp_id, int estterm_step_id)
	{
        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
        string reVal = bizEstData.RemoveEstDataWithJoin_DB();


		Biz_TermSteps termStep   = new Biz_TermSteps(comp_id, estterm_step_id );

		txtEstTermStepID.Text	 = termStep.EstTerm_Step_ID.ToString();
		txtEstTermStepName.Text	 = termStep.EstTerm_Step_Name;
        txtWeight.Text           = DataTypeUtility.GetValue(termStep.Weight);
        txtSortOrder.Text        = DataTypeUtility.GetValue(termStep.Sort_Order);
        ckbMergeYN.Checked       = DataTypeUtility.GetYNToBoolean(termStep.Merge_YN);
        ckbUseYN.Checked         = DataTypeUtility.GetYNToBoolean(termStep.Use_YN);

		hdfEstTermStepID.Value	 = estterm_step_id.ToString();
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{

	}

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		hdfEstTermStepID.Value	= e.SelectedRows[0].Cells.FromKey("ESTTERM_STEP_ID").Value.ToString();
        ViewOne(COMP_ID, DataTypeUtility.GetToInt32( hdfEstTermStepID.Value ) );
		ButtonStatusModify();
	}

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		if ( txtEstTermStepID.Text.Trim().Length == 0 )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "평가주기ID를 입력해주세요." );
			return;
		}

		int intEstTermStepID      = DataTypeUtility.GetToInt32(txtEstTermStepID.Text);
		Biz_TermSteps termSteps   = new Biz_TermSteps();
		bool bDuplicate           = termSteps.IsExist(COMP_ID, intEstTermStepID );

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
		int intEstTermStepID      = DataTypeUtility.GetToInt32(txtEstTermStepID.Text);
		string strEstTermStepName = txtEstTermStepName.Text;
        double weight             = DataTypeUtility.GetToDouble(txtWeight.Text);
        string merge_yn           = DataTypeUtility.GetBooleanToYN(ckbMergeYN.Checked);
        int sort_order            = DataTypeUtility.GetToInt32(txtSortOrder.Text);
        string use_yn             = DataTypeUtility.GetBooleanToYN(ckbUseYN.Checked);

		Biz_TermSteps termSteps      = new Biz_TermSteps();

        if (PageWriteMode == WriteMode.New)
        {
		    bool bDuplicate         = termSteps.IsExist(COMP_ID, intEstTermStepID );

		    if (bDuplicate)
		    {
			    ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가주기 ID가 있습니다.");
                return;
		    }

		    bool bResult = termSteps.AddTermStep( COMP_ID
                                                , intEstTermStepID
											    , strEstTermStepName
                                                , weight
                                                , merge_yn
                                                , sort_order
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
            bool bResult = termSteps.ModifyTermStep(  COMP_ID
                                                    , intEstTermStepID
												    , strEstTermStepName
                                                    , weight
                                                    , merge_yn
                                                    , sort_order
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
		int intEstTermStepID		  = Convert.ToInt32( hdfEstTermStepID.Value.Trim() );

		Biz_TermSteps termSteps       = new Biz_TermSteps();
		bool bResult                  = termSteps.RemoveTermStep(COMP_ID, intEstTermStepID);

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
		txtEstTermStepID.Text	= "";
		txtEstTermStepName.Text	= "";
        txtWeight.Text          = "";
        txtSortOrder.Text       = "";
        ckbMergeYN.Checked      = false;
        ckbUseYN.Checked        = true;
	}

    private void ButtonStatusInit()
	{
		ibnSave.Enabled		        = false;
		ibnDelete.Enabled		    = false;

		ibnCheckID.Visible          = false;
        txtEstTermStepID.Width      = Unit.Pixel(50);

		ClearValueControls();

		txtEstTermStepID.Enabled    = false;

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = false;

		ibnCheckID.Visible          = true;
		txtEstTermStepID.Width      = Unit.Pixel(50);

		ClearValueControls();

		txtEstTermStepID.Enabled    = true;

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.New;
	}

	private void ButtonStatusModify()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = true;

		ibnCheckID.Visible          = false;
		txtEstTermStepID.Width      = Unit.Pixel(50);

		txtEstTermStepID.Enabled    = false;

        ibnSave.ImageUrl            = "../images/btn/b_002.gif";//"저장";

		PageWriteMode               = WriteMode.Modify;
	}
}
