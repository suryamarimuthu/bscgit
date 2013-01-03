using ASP;
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
using System.Collections.Generic;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Estimation.Biz;

public partial class EST_EST110300 : EstPageBase
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
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);

            DataBindReport(WebUtility.GetIntByValueDropDownList(ddlCompID), WebUtility.GetIntByValueDropDownList(ddlEstTermRefID));
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
		ltrScript.Text  = "";
	}

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    private void DataBindReport(int comp_id, int estterm_ref_id) 
    {
        Biz_ReportSumDetails reportSumDetail    = new Biz_ReportSumDetails();
        DataSet ds                              = reportSumDetail.GetReportSumDetail(comp_id, estterm_ref_id, 0);
        GridView1.DataSource                    = ds;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Row.DataItem;

        if(e.Row.RowType == DataControlRowType.DataRow) 
        {
            Control userCtrl                    = LoadControl("USER_CTRL/EST_SUM_GRID.ascx");
            EST_USER_CTRL_EST_SUM_GRID grid     = (EST_USER_CTRL_EST_SUM_GRID)userCtrl;

            grid.Comp_ID                        = COMP_ID;
            grid.Est_ID                         = DataTypeUtility.GetValue(drw["EST_ID"]);
            grid.EstTerm_Ref_ID                 = DataTypeUtility.GetToInt32(drw["ESTTERM_REF_ID"]);
            grid.EstTerm_Sub_ID                 = DataTypeUtility.GetToInt32(drw["ESTTERM_SUB_ID"]);
            grid.EstTerm_Step_ID                = DataTypeUtility.GetToInt32(drw["ESTTERM_STEP_ID"]);
            grid.Year_YN                        = DataTypeUtility.GetValue(drw["YEAR_YN"]);
            grid.Merge_YN                       = DataTypeUtility.GetValue(drw["MERGE_YN"]);
            grid.Title_Name                     = DataTypeUtility.GetValue(drw["TITLE_NAME"]);
            grid.Title_Img_Url                  = DataTypeUtility.GetValue(drw["TITLE_IMG_URL"]);
            grid.Owner_Type                     = DataTypeUtility.GetValue(drw["OWNER_TYPE"]);

            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].Controls.Add(grid);
        }
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
    }
}
