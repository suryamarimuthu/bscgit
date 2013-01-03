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

public partial class EST_EST010900 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!Page.IsPostBack)
		{
			InfoGridBinding();

			ButtonStatusInit();
		}

		ltrScript.Text = "";
	}

	private void InfoGridBinding()
	{
		Biz_PositionInfos positionInfo  = new Biz_PositionInfos();
		DataSet ds                      = positionInfo.GetPositionInfoByUseYN("");

		UltraWebGrid1.DataSource = ds;
		UltraWebGrid1.DataBind();
	}

	private void DetailGridBinding(string pos_id)
	{
		Biz_Positions positions = new Biz_Positions( "EST_POSITION_" + pos_id, pos_id);
		DataSet ds              = positions.GetPositions();

		UltraWebGrid2.DataSource = ds;
		UltraWebGrid2.DataBind();

		InitForm();
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
		DataRowView drw = (DataRowView)e.Data;
		TemplatedColumn col_cBox = (TemplatedColumn)e.Row.Band.Columns.FromKey( "CHK_BOX" );
		CheckBox cBoxUseYn = (CheckBox)( (CellItem)col_cBox.CellItems[e.Row.BandIndex] ).FindControl( "cBox" );

		if ( TypeUtility.GetYNToBoolean( drw["USE_YN"].ToString() ) == true )
		{
			cBoxUseYn.Checked = true;
		}
	}

	protected void ibtnDataMove_Click( object sender, ImageClickEventArgs e )
	{
		string strIdxs = UltraGridUtility.GetCheckBoxValues(UltraWebGrid1
														, "CHK_BOX"
														, "cBox"
														, "POS_ID" );
		string strNotInIdxs = GetNotInIdxs( strIdxs );
		
		Biz_PositionInfos positionInfo  = new Biz_PositionInfos();
		bool bResult                    = positionInfo.ModifyPositionID( strNotInIdxs
																		, DateTime.Now
																		, EMP_REF_ID);

		if (bResult)
		{
			DetailGridBinding(hdfPosInfoID.Value);
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertBackScript( "등록되지 않았습니다." );
            return;
		}
	}

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		string pos_id = txtPosID.Text.Trim();

		if ( pos_id.Length == 0 )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "POS_ID를 입력해주세요." );
			return;
		}

		Biz_Positions positions = new Biz_Positions( "EST_POSITION_" + hdfPosInfoID.Value, hdfPosInfoID.Value );
		bool bDuplicate         = positions.IsExist( pos_id );

		if (bDuplicate)
		{
			ltrScript.Text = JSHelper.GetAlertScript( "존재하는 POS_ID가 있습니다." );
		}
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript( "사용가능한 POS_ID 입니다." );
        }
	}

	protected void ibnNew_Click( object sender, ImageClickEventArgs e )
	{
		ButtonStatusNew();
	}

	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
		string pos_id   = txtPosID.Text.Trim();
		string pos_name = txtPosName.Text.Trim();

		Biz_Positions positions = new Biz_Positions( "EST_POSITION_" + hdfPosInfoID.Value, hdfPosInfoID.Value );

		if ( PageWriteMode == WriteMode.New )
		{
			bool bDuplicate = positions.IsExist( pos_id );

			if ( bDuplicate == true )
			{
				ltrScript.Text = JSHelper.GetAlertScript( "중복되었습니다.", false );
				return;
			}

			bool bResult = positions.AddPositions(pos_id
												, pos_name
												, DateTime.Now
												, EMP_REF_ID);

			if ( bResult == true )
			{
				DetailGridBinding(hdfPosInfoID.Value);
				InitForm();
			}
			else
			{
				ltrScript.Text = JSHelper.GetAlertBackScript( "등록되지 않았습니다." );
				return;
			}
		}
		else if ( PageWriteMode == WriteMode.Modify )
		{
			bool bIsExist = positions.IsExist( pos_id );

			if ( bIsExist == false )
			{
				ltrScript.Text = JSHelper.GetAlertScript( "해당 자료가 없습니다.", false );
				return;
			}

			bool bResult = positions.ModifyPositions( pos_id
												    , pos_name
												    , DateTime.Now
												    , EMP_REF_ID);

			if ( bResult == true )
			{
				DetailGridBinding(hdfPosInfoID.Value);
				InitForm();
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
		string strPos_id		= hdfPosID.Value.Trim();

		Biz_Positions positions = new Biz_Positions( "EST_POSITION_" + hdfPosInfoID.Value, hdfPosInfoID.Value);
		bool bIsExist			= positions.IsExist( strPos_id );

		if ( bIsExist == false )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "해당 자료가 없습니다.", false );
			return;
		}

		bool bResult = positions.RemovePositions( strPos_id );

		if (bResult)
		{
			DetailGridBinding(hdfPosInfoID.Value);
			InitForm();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertBackScript( "삭제되지 않았습니다." );
            return;
		}
	}

	private string GetNotInIdxs( string strIdxs )
	{
		string[] strarr         = strIdxs.Split( ';' );
		string strReturn        = string.Empty;
		StringBuilder sbReturn  = new StringBuilder();

		for ( int i = 0; i < strarr.Length; i++ )
		{
			sbReturn.Append( string.Format( "'{0}',", strarr[i] ) );
		}

		strReturn = sbReturn.ToString().Substring( 0, sbReturn.ToString().Length -1 );
		return strReturn;
	}

	private void ViewOne( string strPos_id )
	{
		string strPos           = hdfPosInfoID.Value;

		Biz_Positions positions = new Biz_Positions(  "EST_POSITION_" + strPos
													, strPos
													, strPos_id);

		txtPosID.Text			= positions.PosID;
		txtPosName.Text		    = positions.PosName;
	}

	private void InitForm()
	{
		txtPosID.Text		    = "";
		txtPosName.Text		    = "";

		ButtonStatusInit();
	}

	private void ClearValueControls()
	{
		txtPosID.Text		    = "";
		txtPosName.Text	        = "";
	}

	private void ButtonStatusInit()
	{
		ibnSave.Enabled			= false;
		ibnDelete.Enabled		= false;

		ibnCheckID.Visible      = false;

		txtPosID.Enabled		= false;
		txtPosName.Enabled		= false;

		ClearValueControls();
	}

	private void ButtonStatusNew()
	{
		ibnSave.Enabled		    = true;
		ibnDelete.Enabled		= false;

		ibnCheckID.Visible      = true;

		txtPosID.Enabled		= true;
		txtPosName.Enabled		= true;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.New;

		ClearValueControls();
	}

	private void ButtonStatusModify()
	{
		ibnSave.Enabled			= true;
		ibnDelete.Enabled		= true;

		txtPosID.Enabled		= false;
		txtPosName.Enabled		= true;

        ibnSave.ImageUrl		= "../images/btn/b_002.gif";//"수정";

		PageWriteMode			= WriteMode.Modify;
	}

	protected void ddlPosition_SelectedIndexChanged( object sender, EventArgs e )
	{
		
	}

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{

	}

	protected void UltraWebGrid2_InitializeRow( object sender, RowEventArgs e )
	{

	}

    protected void UltraWebGrid1_SelectedRowsChange1(object sender, SelectedRowsEventArgs e)
    {
        if ( e.SelectedRows.Count == 0 )
			return;

        hdfPosInfoID.Value = e.SelectedRows[0].Cells.FromKey("POS_ID").Value.ToString();
        DetailGridBinding(hdfPosInfoID.Value);
    }

	protected void UltraWebGrid2_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		if ( e.SelectedRows.Count == 0 )
			return;

		hdfPosID.Value = e.SelectedRows[0].Cells.FromKey("POS_ID").Value.ToString();

        ViewOne( hdfPosID.Value );
		ButtonStatusModify();
	}
}