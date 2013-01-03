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

public partial class EST_EST010600 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!IsPostBack)
		{
			GridBinding();
			ButtonStatusInit();
		}

		ltrScript.Text = string.Empty;
	}

	private void GridBinding()
	{
		Biz_Status status   = new Biz_Status();
		DataSet ds          = status.GetStatuses("");

		UltraWebGrid1.DataSource = ds;
		UltraWebGrid1.DataBind();

		lblRowCount.Text    = ds.Tables[0].Rows.Count.ToString();
	}

	private void ViewOne( string status_id, string status_style_id)
	{
		Biz_Status status       = new Biz_Status(status_id, status_style_id);

		txtStatusID.Text		= status.Status_ID.ToString();
		txtStatusName.Text	    = status.Status_Name;
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{

	}

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		hdfStatusID.Value	    = e.SelectedRows[0].Cells.FromKey( "STATUS_ID" ).Value.ToString();
        hdfStatusStyleID.Value	= e.SelectedRows[0].Cells.FromKey( "STATUS_STYLE_ID" ).Value.ToString();

        ViewOne( hdfStatusID.Value, hdfStatusStyleID.Value);
		ButtonStatusModify();
	}

	private void ClearValueControls()
	{
		txtStatusID.Text		= "";
		txtStatusName.Text		= "";
	}

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		string strStatusID = txtStatusID.Text.Trim();

		if ( strStatusID.Length == 0 )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "상태 ID를 입력해주세요." );
			return;
		}

		Biz_Status status   = new Biz_Status();
		bool bDuplicate     = status.IsExist( strStatusID );

		if (bDuplicate)
		{
			ltrScript.Text = JSHelper.GetAlertScript( "존재하는 상태 ID가 있습니다." );
		}
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript( "사용가능한 상태 ID 입니다." );
        }
	}

	protected void ibnNew_Click( object sender, ImageClickEventArgs e )
	{
		ButtonStatusNew();
	}

	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
		string strStatusID      = txtStatusID.Text.Trim();
		string strStatusName    = txtStatusName.Text.Trim();

		Biz_Status status       = new Biz_Status();
        bool bResult            = false;

        if (PageWriteMode       == WriteMode.New)
        {
            bool bDuplicate     = status.IsExist( strStatusID );

		    if (bDuplicate)
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "존재하는 상태 ID가 있습니다." );
		    }

		    bResult             = status.AddStatus(   strStatusID
                                                    , 0
									                , strStatusName
                                                    , ""
                                                    , ""
                                                    , ""
									                , DateTime.Now
									                , EMP_REF_ID);

		    if (bResult)
		    {
    			ltrScript.Text = JSHelper.GetAlertScript( "정상적으로 저장되었습니다.");
			    GridBinding();
			    ButtonStatusInit();
		    }
		    else
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "저장 중 오류가 발생하였습니다." );
                return;
		    }
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            bResult             = status.ModifyStatus(strStatusID
                                                    , 0
													, strStatusName
                                                    , ""
                                                    , ""
                                                    , hdfStatusStyleID.Value
													, DateTime.Now
													, EMP_REF_ID);

		    if ( bResult == true )
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "정상적으로 수정되었습니다.");
			    GridBinding();
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
		string strStatusID			= hdfStatusID.Value.Trim();

		Biz_Status status           = new Biz_Status();

		bool bResult = status.RemoveStatus( strStatusID );

		if ( bResult)
		{
			ltrScript.Text          = JSHelper.GetAlertScript( "정상적으로 삭제되었습니다.", false );
			GridBinding();
			ButtonStatusInit();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript( "삭제될 대상이 선택되지 않았습니다." );
            return;
		}
	}

    private void ButtonStatusInit()
	{
		ibnSave.Enabled		    = false;
		ibnDelete.Enabled		= false;

		ibnCheckID.Visible      = false;

		ClearValueControls();

		txtStatusID.Enabled     = false;
		txtStatusName.Enabled   = false;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
		ibnSave.Enabled		    = true;
		ibnDelete.Enabled		= false;

		ibnCheckID.Visible      = true;
		txtStatusID.Width       = Unit.Percentage(60);

		ClearValueControls();

		txtStatusID.Enabled     = true;
		txtStatusName.Enabled   = true;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.New;
	}

	private void ButtonStatusModify()
	{
		ibnSave.Enabled		    = true;
		ibnDelete.Enabled		= true;

		ibnCheckID.Visible      = false;
		txtStatusID.Width       = Unit.Percentage(60);

		txtStatusID.Enabled     = true;
		txtStatusName.Enabled   = true;

        ibnSave.ImageUrl       = "../images/btn/b_002.gif";//"수정";

		PageWriteMode           = WriteMode.Modify;
	}
}

