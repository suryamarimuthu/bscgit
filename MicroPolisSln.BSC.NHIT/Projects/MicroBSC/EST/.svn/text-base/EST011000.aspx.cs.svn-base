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

public partial class EST_EST011000 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!Page.IsPostBack)
		{
			KndGridBinding();
		}

        KndBizMapGridBinding();

		ltrScript.Text = "";
	}

    private void KndGridBinding()
	{
        Biz_PositionKinds positionKinds = new Biz_PositionKinds();

        DataSet ds = positionKinds.GetPositionKinds();

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
	}

	private void SelectBizGridBinding(string pos_knd_id)
	{
        Biz_PositionBizs positionBizs = new Biz_PositionBizs();
        DataSet ds = positionBizs.GetPositionBizs();

		UltraWebGrid3.DataSource = ds;
		UltraWebGrid3.DataBind();

	}

    private void KndBizMapGridBinding()
    {
        Biz_PositionKindBizMaps maps = new Biz_PositionKindBizMaps();

        DataSet ds = maps.GetPosKndBizMaps();

        UltraWebGrid2.DataSource = ds;
        UltraWebGrid2.DataBind();
    }

   

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
        //DataRowView drw = (DataRowView)e.Data;
        //TemplatedColumn col_cBox = (TemplatedColumn)e.Row.Band.Columns.FromKey( "CHK_BOX" );
        //CheckBox cBoxUseYn = (CheckBox)( (CellItem)col_cBox.CellItems[e.Row.BandIndex] ).FindControl( "cBox" );

        //if ( TypeUtility.GetYNToBoolean( drw["USE_YN"].ToString() ) == true )
        //{
        //    cBoxUseYn.Checked = true;
        //}
	}
	protected void ibnSave_Click( object sender, ImageClickEventArgs e )
	{
        string strIdxs = UltraGridUtility.GetCheckBoxValues(UltraWebGrid3
                                                        , "CHK_BOX"
                                                        , "cBox"
                                                        , "POS_BIZ_ID");

        string[] pos_biz_ids = strIdxs.Substring(0, strIdxs.Length - 1).Split(';');
       

        Biz_PositionKindBizMaps positionKindBizMap = new Biz_PositionKindBizMaps();

        DataTable dataTable = positionKindBizMap.GetDataTableSchema();
        DataRow row = null;


        for (int i = 0; i < pos_biz_ids.Length; i ++ )
        {
            DataRow dataRow = dataTable.NewRow();

            dataRow["POS_KND_ID"]   = this.hdfPoskndID.Value;
            dataRow["POS_BIZ_ID"]   = pos_biz_ids[i].ToString();
            dataRow["DATE"]         = DateTime.Now;
            dataRow["USER"]         = gUserInfo.Emp_Ref_ID;

            dataTable.Rows.Add(dataRow);
        }


       bool bResult  =  positionKindBizMap.ModifyPosKndBizMap(this.hdfPoskndID.Value, dataTable);

       if (bResult)
       {
           SelectBizGridBinding(hdfPoskndID.Value);
           KndBizMapGridBinding();
       }
       else
       {
           ltrScript.Text = JSHelper.GetAlertBackScript("수정되지 않았습니다.");
           return;
       }
	}
    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
	{
        if (e.SelectedRows.Count == 0)
            return;

        hdfPoskndID.Value = e.SelectedRows[0].Cells.FromKey("POS_KND_ID").Value.ToString();
        SelectBizGridBinding(hdfPoskndID.Value);
	}
	protected void UltraWebGrid2_InitializeRow( object sender, RowEventArgs e )
	{

	}
	protected void UltraWebGrid2_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		
       
	}
    protected void UltraWebGrid3_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        Biz_PositionKindBizMaps kndBizMap = new Biz_PositionKindBizMaps();

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("CHK_BOX");
        CheckBox objchk = (CheckBox)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("cBox");
        
        objchk.Checked = kndBizMap.IsExist(this.hdfPoskndID.Value, drw["POS_BIZ_ID"].ToString());
    }
    protected void UltraWebGrid3_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
    protected void UltraWebGrid2_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
}