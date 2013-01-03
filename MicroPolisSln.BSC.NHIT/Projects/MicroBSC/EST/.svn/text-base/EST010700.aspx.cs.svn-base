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

public partial class EST_EST010700 : EstPageBase
{
    private string EST_ID;
    private string SCALE_ID;

	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if ( !IsPostBack )
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
			TreeViewCommom.BindEst(TreeView1, TreeNodeSelectAction.Select, WebUtility.GetIntByValueDropDownList(ddlCompID));
            DropDownListCommom.BindEstScaleInfo(ddlScaleID, WebUtility.GetIntByValueDropDownList(ddlCompID));

			ButtonStatusInit();
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID          = hdfEstID.Value;
        SCALE_ID        = WebUtility.GetByValueDropDownList(ddlScaleID);
		ltrScript.Text  = string.Empty;
	}

	private void BindGrid(int comp_id, string est_id, string scale_id)
	{
		Biz_Scopes scopes	            = new Biz_Scopes();
		DataSet ds			            = scopes.GetScopeGradeEstID(comp_id, est_id, scale_id);

		if ( ds.Tables[0].Rows.Count == 0 )
		{
			Biz_Grades grades			= new Biz_Grades();
			DataSet dsGrade				= grades.GetEstGrades(comp_id);

			UltraWebGrid1.DataSource	= dsGrade;
			UltraWebGrid1.DataBind();
		}
		else
		{
			UltraWebGrid1.DataSource	= ds;
			UltraWebGrid1.DataBind();
		}
	}

	protected void TreeView1_SelectedNodeChanged( object sender, EventArgs e )
	{
		hdfEstID.Value	= TreeView1.SelectedValue;
		BindGrid(COMP_ID, hdfEstID.Value, SCALE_ID);

        Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, hdfEstID.Value);

        if(estInfo.Grade_Confirm_YN.Equals("N")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가등급을 확정하는 평가에서만 등급 범위 설정이 필요합니다.");
            return;
        }
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
		DataRowView drw = (DataRowView)e.Data;

		// DDL - DDLSCALE_ID
		TemplatedColumn tcol_ScaleId	    = (TemplatedColumn)e.Row.Band.Columns.FromKey( "DDLSCALE_ID" );
		DropDownList ddl_ScaleId		    = (DropDownList)((CellItem)tcol_ScaleId.CellItems[e.Row.BandIndex]).FindControl( "ddlScaleId" );
		DropDownListCommom.BindEstScaleInfo(ddl_ScaleId, COMP_ID);

        if(e.Row.Cells.FromKey("SCALE_ID").Value != null)
            WebUtility.FindByValueDropDownList(ddl_ScaleId, e.Row.Cells.FromKey("SCALE_ID").Value);

		// TXT - START_SCOPE
		TemplatedColumn tcol_StartScope     = (TemplatedColumn)e.Row.Band.Columns.FromKey( "TXTSTART_SCOPE" );
		TextBox txtStartScope			    = (TextBox)((CellItem)tcol_StartScope.CellItems[e.Row.BandIndex]).FindControl( "txtStartScope" );
		
        if(e.Row.Cells.FromKey("START_SCOPE").Value != null)
            txtStartScope.Text			    = e.Row.Cells.FromKey("START_SCOPE").Value.ToString();

        TextBoxCommon.SetOnlyInteger(txtStartScope);

		// TXT - END_SCOPE
		TemplatedColumn tcol_EndScope	    = (TemplatedColumn)e.Row.Band.Columns.FromKey( "TXTEND_SCOPE" );
		TextBox txtEndScope				    = (TextBox)((CellItem)tcol_EndScope.CellItems[e.Row.BandIndex]).FindControl( "txtEndScope" );

        if(e.Row.Cells.FromKey("END_SCOPE").Value != null)
            txtEndScope.Text			    = e.Row.Cells.FromKey("END_SCOPE").Value.ToString();

        TextBoxCommon.SetOnlyInteger(txtEndScope);

		// DDL - SCOPE_UNIT_ID
		TemplatedColumn tcol_ScopeUnitId    = (TemplatedColumn)e.Row.Band.Columns.FromKey( "DDLSCOPE_UNIT_ID" );
		DropDownList ddl_ScopeUnitId	    = (DropDownList)((CellItem)tcol_ScopeUnitId.CellItems[e.Row.BandIndex]).FindControl( "ddlScopeUnitId" );
		DropDownListCommom.BindEstScopeUnit( ddl_ScopeUnitId );

        if(e.Row.Cells.FromKey("SCOPE_UNIT_ID").Value != null)
            WebUtility.FindByValueDropDownList(ddl_ScopeUnitId, e.Row.Cells.FromKey("SCOPE_UNIT_ID").Value);

		// TXT - GRADE_TO_POINT
		TemplatedColumn tcol_GradeToPoint	= (TemplatedColumn)e.Row.Band.Columns.FromKey( "TXTGRADE_TO_POINT" );
		TextBox txtGradeToPoint				= (TextBox)((CellItem)tcol_GradeToPoint.CellItems[e.Row.BandIndex]).FindControl( "txtGradeToPoint" );
		
        if(e.Row.Cells.FromKey("GRADE_TO_POINT").Value != null)
            txtGradeToPoint.Text			= e.Row.Cells.FromKey("GRADE_TO_POINT").Value.ToString();

        TextBoxCommon.SetOnlyInteger(txtGradeToPoint);
	}

	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
		Biz_Scopes scopes	= new Biz_Scopes();
		DataTable dtInsert	= scopes.GetSchema();
		DataRow drNew		= null;

		foreach ( UltraGridRow ugRow in UltraWebGrid1.Rows )
		{
			if ( CheckRow( ugRow ) == false )
			{
				ltrScript.Text = JSHelper.GetAlertScript( "입력되지 않았습니다. 값을 입력해주세요.", false );
				break;
			}

            //TemplatedColumn tcol_ScaleId	    = (TemplatedColumn)ugRow.Band.Columns.FromKey( "DDLSCALE_ID" );
            //DropDownList ddl_ScaleId		    = (DropDownList)( (CellItem)tcol_ScaleId.CellItems[ugRow.BandIndex] ).FindControl( "ddlScaleId" );

			TemplatedColumn tcol_StartScope     = (TemplatedColumn)ugRow.Band.Columns.FromKey( "TXTSTART_SCOPE" );
			TextBox txtStartScope			    = (TextBox)( (CellItem)tcol_StartScope.CellItems[ugRow.BandIndex] ).FindControl( "txtStartScope" );

			TemplatedColumn tcol_EndScope	    = (TemplatedColumn)ugRow.Band.Columns.FromKey( "TXTEND_SCOPE" );
			TextBox txtEndScope				    = (TextBox)( (CellItem)tcol_EndScope.CellItems[ugRow.BandIndex] ).FindControl( "txtEndScope" );

            //TemplatedColumn tcol_ScopeUnitId	= (TemplatedColumn)ugRow.Band.Columns.FromKey( "DDLSCOPE_UNIT_ID" );
            //DropDownList ddl_ScopeUnitId		= (DropDownList)( (CellItem)tcol_ScopeUnitId.CellItems[ugRow.BandIndex] ).FindControl( "ddlScopeUnitId" );

			TemplatedColumn tcol_GradeToPoint	= (TemplatedColumn)ugRow.Band.Columns.FromKey( "TXTGRADE_TO_POINT" );
			TextBox txtGradeToPoint				= (TextBox)( (CellItem)tcol_GradeToPoint.CellItems[ugRow.BandIndex] ).FindControl( "txtGradeToPoint" );

			drNew                           = dtInsert.NewRow();
            drNew["COMP_ID"]				= COMP_ID;
			drNew["EST_ID"]					= EST_ID;
			drNew["GRADE_ID"]				= ugRow.Cells.FromKey("GRADE_ID").Value;
			drNew["SCALE_ID"]				= SCALE_ID;
			drNew["START_SCOPE"]			= DataTypeUtility.GetToDouble(txtStartScope.Text.Trim());
			drNew["END_SCOPE"]				= DataTypeUtility.GetToDouble(txtEndScope.Text.Trim());
			drNew["SCOPE_UNIT_ID"]			= new Biz_ScopeUnits().GetScopeUnitIDByScaleID(SCALE_ID);
			drNew["GRADE_TO_POINT"]			= DataTypeUtility.GetToDouble(txtGradeToPoint.Text.Trim());

			dtInsert.Rows.Add( drNew );
		}

		bool isOK = scopes.AddScope( dtInsert
					                , DateTime.Now
					                , EMP_REF_ID );

		if (isOK)
		{
			BindGrid(COMP_ID, EST_ID, SCALE_ID);
			//ButtonStatusInit();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript( "항목이 입력되지 않았습니다. 각 항목을 입력해주세요." );
			return;			
		}
	}

	private bool CheckRow( UltraGridRow ugRow )
	{
		TemplatedColumn tcol_StartScope		= (TemplatedColumn)ugRow.Band.Columns.FromKey( "TXTSTART_SCOPE" );
		TextBox txtStartScope				= (TextBox)( (CellItem)tcol_StartScope.CellItems[ugRow.BandIndex] ).FindControl( "txtStartScope" );

		TemplatedColumn tcol_EndScope		= (TemplatedColumn)ugRow.Band.Columns.FromKey( "TXTEND_SCOPE" );
		TextBox txtEndScope					= (TextBox)( (CellItem)tcol_EndScope.CellItems[ugRow.BandIndex] ).FindControl( "txtEndScope" );

		TemplatedColumn tcol_GradeToPoint	= (TemplatedColumn)ugRow.Band.Columns.FromKey( "TXTGRADE_TO_POINT" );
		TextBox txtGradeToPoint				= (TextBox)( (CellItem)tcol_GradeToPoint.CellItems[ugRow.BandIndex] ).FindControl( "txtGradeToPoint" );

        return true;

        //if (   txtStartScope.Text.Trim().Length     == 0
        //    || txtEndScope.Text.Trim().Length       == 0)
        //{
        //    return false;
        //}

        //return true;
	}

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeViewCommom.BindEst(TreeView1, TreeNodeSelectAction.Select, COMP_ID);
        DropDownListCommom.BindEstScaleInfo(ddlScaleID, COMP_ID);
        BindGrid(COMP_ID, EST_ID, SCALE_ID);

		ButtonStatusInit();
    }

	private void ButtonStatusInit()
	{
		hdfEstID.Value = string.Empty;
	}

    protected void ddlScaleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid(COMP_ID, EST_ID, SCALE_ID);
    }
}
