
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

public partial class EST_EST020200 : EstPageBase
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
        Biz_ColumnStyles columnStyles = new Biz_ColumnStyles();
        DataSet ds                    = columnStyles.GetColumnStyles();

		UltraWebGrid1.DataSource = ds;
		UltraWebGrid1.DataBind();

		lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
	}

	private void ViewOne( string col_style_id )
	{
        Biz_ColumnStyles columnStyles = new Biz_ColumnStyles(col_style_id);

        txtColStyleID.Text          = columnStyles.Col_Style_ID;
        txtColStyleName.Text        = columnStyles.Col_Style_Name;

        hdfColStyleID.Value      = columnStyles.Col_Style_ID;
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
	}

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		hdfColStyleID.Value	= e.SelectedRows[0].Cells.FromKey( "COL_STYLE_ID" ).Value.ToString();
        ViewOne(hdfColStyleID.Value);
		ButtonStatusModify();
	}

	private void ClearValueControls()
	{
		txtColStyleID.Text	= "";
		txtColStyleName.Text	= "";
	}

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		if ( txtColStyleID.Text.Trim().Length == 0 )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "컬럼스타일ID를 입력해주세요." );
			return;
		}

        string col_style_id           = txtColStyleID.Text.Trim();
        Biz_ColumnStyles columnStyles = new Biz_ColumnStyles();
        bool bDuplicate               = columnStyles.IsExist(col_style_id);

		if (bDuplicate)
		{
			ltrScript.Text = JSHelper.GetAlertScript("존재하는 컬럼스타일ID가 있습니다.");
		}
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("사용가능한 컬럼스타일ID 입니다.");
        }
	}

	protected void ibnNew_Click( object sender, ImageClickEventArgs e )
	{
		ButtonStatusNew();
	}

	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
		string col_style_id         = txtColStyleID.Text.Trim();
		string col_style_name       = txtColStyleName.Text.Trim();

        Biz_ColumnStyles columnStyles = new Biz_ColumnStyles();

        if (PageWriteMode == WriteMode.New)
        {
            bool bDuplicate     = columnStyles.IsExist(col_style_id);

		    if (bDuplicate)
		    {
			    ltrScript.Text  = JSHelper.GetAlertScript("존재하는 컬럼스타일ID가 있습니다.");
                return;
		    }

            bool bResult = columnStyles.AddColumnStyle(col_style_id
                                                        ,col_style_name
											            , DateTime.Now
											            , EMP_REF_ID);

		    if (bResult)
		    {
			    ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.");
			    GridBinding();
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
            bool bResult = columnStyles.ModifyColumnStyle(col_style_id
                                                        , col_style_name
                                                        , DateTime.Now
                                                        , EMP_REF_ID);

		    if (bResult)
		    {
    			ltrScript.Text = JSHelper.GetAlertScript( "정상적으로 수정되었습니다.", false );
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
        string col_style_id             = hdfColStyleID.Value;

        Biz_ColumnStyles columnStyles   = new Biz_ColumnStyles();
        bool bResult                    = columnStyles.RemoveColumnStyle(col_style_id);

		if (bResult)
		{
			ltrScript.Text = JSHelper.GetAlertScript("삭제되었습니다.", false);

			GridBinding();
			ButtonStatusInit();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript("삭제되지 않았습니다.");
		}
	}

    private void ButtonStatusInit()
	{
		ibnSave.Enabled		        = false;
		ibnDelete.Enabled		    = false;

		ibnCheckID.Visible          = false;
        txtColStyleID.Width       = Unit.Pixel(50);

		ClearValueControls();

		txtColStyleID.Enabled     = false;

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = false;

		ibnCheckID.Visible          = true;
		txtColStyleID.Width       = Unit.Pixel(50);

		ClearValueControls();

		txtColStyleID.Enabled     = true;

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.New;
	}

	private void ButtonStatusModify()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = true;

		ibnCheckID.Visible          = false;
		txtColStyleID.Width       = Unit.Pixel(50);

		txtColStyleID.Enabled     = false;

        ibnSave.ImageUrl            = "../images/btn/b_002.gif";//"저장";

		PageWriteMode               = WriteMode.Modify;
	}
}
