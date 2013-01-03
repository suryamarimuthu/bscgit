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

using MicroBSC.EIS.Dac;

using MicroBSC.Estimation.Biz;

public partial class EIS_JW_EST010100 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		//SetPageLayout( phdLayout );
	}

	protected void Page_Load( object sender, EventArgs e )
	{
        //scriptManager.RegisterAsyncPostBackControl(ddlEstRefID);
        //scriptManager.RegisterAsyncPostBackControl(ddlYMD);
        //scriptManager.RegisterAsyncPostBackControl(ddlMain);
        //scriptManager.RegisterAsyncPostBackControl(ddlSub);


        (((_common_lib_MicroBSC)this.Master).FindControl("ScriptManager1") as ScriptManager).RegisterAsyncPostBackControl(ddlEstRefID);
        (((_common_lib_MicroBSC)this.Master).FindControl("ScriptManager1") as ScriptManager).RegisterAsyncPostBackControl(ddlYMD);
        (((_common_lib_MicroBSC)this.Master).FindControl("ScriptManager1") as ScriptManager).RegisterAsyncPostBackControl(ddlMain);
        (((_common_lib_MicroBSC)this.Master).FindControl("ScriptManager1") as ScriptManager).RegisterAsyncPostBackControl(ddlSub);

        ibnSearch.Click += new ImageClickEventHandler(ibnSearch_Click);

		if (!IsPostBack)
		{
            base.SetMenuControl(true, false, true);
            WebCommon.SetEstTermDropDownList(ddlEstRefID);
            WebCommon.SetTermMonthDropDownList(ddlYMD, WebUtility.GetIntByValueDropDownList(ddlEstRefID));
            BindMain();
            BindSub(WebUtility.GetIntByValueDropDownList(ddlMain));

            ibnSearch_Click(null, null);
		}

		//ltrScript.Text  = "";
	}

    protected void Page_PreRender(object sender, EventArgs e) 
    {
        string title_name = ((_common_lib_MicroBSC)this.Master).GetTitle();

        if(title_name.Trim().Equals(""))
        {
            ((_common_lib_MicroBSC)this.Master).SetTitle("전사 Global 경영실적");
        }
    }

    private void BindMain() 
    {
        Dac_EISDatas obj        = new Dac_EISDatas();
        DataTable dt            = obj.GetEISMain();
        ddlMain.DataValueField  = "M_ID";
        ddlMain.DataTextField   = "M_NAME";
        ddlMain.DataSource      = dt;
        ddlMain.DataBind();
    }

    private void BindSub(int m_id) 
    {
        Dac_EISDatas obj        = new Dac_EISDatas();
        DataTable dt            = obj.GetEISSub(m_id, 0);
        dt = DataTypeUtility.FilterSortDataTable(dt, "", "SORT_ORDER");
        ddlSub.DataValueField  = "S_ID";
        ddlSub.DataTextField   = "S_NAME";
        ddlSub.DataSource      = dt;
        ddlSub.DataBind();
    }

    private string GetPageName(int m_id, int s_id) 
    {
        Dac_EISDatas obj        = new Dac_EISDatas();
        DataTable dt            = obj.GetEISSub(m_id, s_id);
        
        if(dt.Rows.Count > 0) 
        {
            return DataTypeUtility.GetValue(dt.Rows[0]["PAGE_NAME"]);
        }

        return "";
    }

    protected void ddlEstRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlYMD, WebUtility.GetIntByValueDropDownList(ddlEstRefID));
    }

    protected void ddlMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSub(WebUtility.GetIntByValueDropDownList(ddlMain));
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string page_name    = "";
        string title_name   = "";

        Dac_EISDatas obj        = new Dac_EISDatas();
        DataTable dt            = obj.GetEISSub(WebUtility.GetIntByValueDropDownList(ddlMain), WebUtility.GetIntByValueDropDownList(ddlSub));
        
        if(dt.Rows.Count > 0) 
        {
            page_name   = DataTypeUtility.GetValue(dt.Rows[0]["PAGE_NAME"]);
            title_name  = DataTypeUtility.GetValue(dt.Rows[0]["TITLE_NAME"]);
        }

        ((_common_lib_MicroBSC)this.Master).SetTitle(title_name);

        if(page_name.IndexOf("?") >= 0) 
        {
            ifmContent.Attributes.Add("src", string.Format("{0}&ESTTERM_REF_ID={1}&YMD={2}&M_ID={3}&S_ID={4}"
                                            , page_name
                                            , WebUtility.GetIntByValueDropDownList(ddlEstRefID)
                                            , WebUtility.GetIntByValueDropDownList(ddlYMD)
                                            , WebUtility.GetIntByValueDropDownList(ddlMain)
                                            , WebUtility.GetIntByValueDropDownList(ddlSub)));
        }
        else 
        {
            ifmContent.Attributes.Add("src", string.Format("{0}?ESTTERM_REF_ID={1}&YMD={2}&M_ID={3}&S_ID={4}"
                                            , page_name
                                            , WebUtility.GetIntByValueDropDownList(ddlEstRefID)
                                            , WebUtility.GetIntByValueDropDownList(ddlYMD)
                                            , WebUtility.GetIntByValueDropDownList(ddlMain)
                                            , WebUtility.GetIntByValueDropDownList(ddlSub)));    
        }
    }
}
