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

public partial class EST_EST050400 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!IsPostBack)
		{
			
		}

		ltrScript.Text = "";
	}

	private void GridBinding()
	{
        //Biz_ColumnStyles columnStyles = new Biz_ColumnStyles();
        //DataSet ds                    = columnStyles.GetColumnStyles();

        //UltraWebGrid1.DataSource = ds;
        //UltraWebGrid1.DataBind();

        //lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
        DataRowView drw = (DataRowView) e.Data;
	}

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
		
	}

	
}
