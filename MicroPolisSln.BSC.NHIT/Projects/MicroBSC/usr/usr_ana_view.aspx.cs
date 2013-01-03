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
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

using MicroBSC.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Data;
using ASP;

public partial class usr_ana_view : AppPageBase
{
    private int ESTTERM_REF_ID  = 0;
    private int EST_DEPT_REF_ID = 0;
    private int TMCODE          = 0;
    private string VIEW_PAGE    = "";
    DropDownList ddlEstTermInfo = null;
    DropDownList ddlMonthInfo   = null;
    Label lblDeptPath           = null;

    public string SelectedTabKey 
    {
        get 
        {
            if (ViewState["SELECTED_TAB_KEY"] == null) 
            {
                if (Request["ESTTERM_REF_ID"] != null)
                {
                    ViewState["SELECTED_TAB_KEY"] = "STG_MAP";
                    UltraWebTab1.SelectedTabIndex = 1;
                }
                else
                {
                    ViewState["SELECTED_TAB_KEY"] = "DEPT_ORG";
                    UltraWebTab1.SelectedTabIndex = 0;
                }
            }

            return ViewState["SELECTED_TAB_KEY"].ToString();
        }
        set 
        {
            ViewState["SELECTED_TAB_KEY"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //SetPageLayout(phdLayout, "MenuControl_NotLeftMenu.ascx");

        ddlEstTermInfo  = MenuControl1.DdlEstTermInfo;
        ddlMonthInfo    = MenuControl1.DdlEstMonth;
        lblDeptPath     = MenuControl1.LblDeptPath;

        ddlEstTermInfo.SelectedIndexChanged += new EventHandler(ddlEstTermInfo_SelectedIndexChanged);
        ddlMonthInfo.SelectedIndexChanged   += new EventHandler(ddlMonthInfo_SelectedIndexChanged);

        if (!Page.IsPostBack) 
        {
            //if (!PageUtility.IsContainSystemAdminUser(EMP_REF_ID))
            //{
                UltraWebTab1.Tabs.FromKeyTab("GROUP_VIEW").Visible = false;
            //}

            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            //WebCommon.SetMonthDropDownList(ddlMonthInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            WebCommon.FillEstTree(trvEstDept, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), EMP_REF_ID);

            //StrategyMapInfos stgMapInfo = new StrategyMapInfos();

            if (Request["ESTTERM_REF_ID"] != null)
            {
                PageUtility.FindByValueDropDownList(ddlEstTermInfo, GetRequest("ESTTERM_REF_ID"));
                //UltraWebTab1.SelectedTabIndex = 2;
            }

            if (Request["TMCODE"] != null)
            {
                PageUtility.FindByValueDropDownList(ddlMonthInfo, GetRequest("TMCODE"));
            }
            else
            {
                MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
                PageUtility.FindByValueDropDownList(ddlMonthInfo, objTerm.GetReleasedMonth());
            }

            if (Request["EST_DEPT_REF_ID"] != null)
            {
                PageUtility.SelectTreeNode(trvEstDept, GetRequest("EST_DEPT_REF_ID"));
            }
            else 
            {
                //if (trvEstDept.Nodes.Count > 0)
                //    trvEstDept.Nodes[0].Select();

                int return_est_dept_ref_id = PageUtility.SetTopEstDeptRefID(trvEstDept);
                PageUtility.SelectTreeNode(trvEstDept, return_est_dept_ref_id.ToString());
            }

            ChageTabPage();

            ddlEstTermInfo.AutoPostBack         = true;
            ddlMonthInfo.AutoPostBack           = true;
        }

        lblDeptPath.Text    = WebCommon.GetDeptTreePathText(trvEstDept);
        ltrScript.Text      = "";

        this.UltraWebTab1.Tabs.FromKeyTab("CEO_COM").Text = this.GetText("LBL_00004", "Communication");
        this.UltraWebTab1.Tabs.FromKeyTab("CEO_COM").Tooltip = this.GetText("LBL_00004", "Communication");
    }

    void ddlMonthInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChageTabPage();
    }

    void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChageTabPage();
    }

    protected void UltraWebTab1_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        SelectedTabKey = e.Tab.Key;
        ChageTabPage();
    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        ChageTabPage();
    }

    private void ChageTabPage() 
    {
        if (trvEstDept.SelectedNode != null)
        {
            EST_DEPT_REF_ID = int.Parse(trvEstDept.SelectedValue);
        }
        else 
        {
            EST_DEPT_REF_ID = 0;
        }

        ESTTERM_REF_ID  = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        TMCODE          = int.Parse(ddlMonthInfo.SelectedValue);
        VIEW_PAGE       = SelectedTabKey;

        if (VIEW_PAGE.Equals("STG_MAP"))
        {
            string url = "../usr/usr10001_embed.aspx?ESTTERM_REF_ID="   + ESTTERM_REF_ID.ToString()
                                        + "&EST_DEPT_REF_ID="           + EST_DEPT_REF_ID.ToString()
                                        + "&TMCODE="                    + TMCODE.ToString()
                                        + "&LINE_TYPE="                 + ""
                                        + "&SHOW_KPI_LIST="             + "";

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_01.Attributes.Add("src", url);
        }
        //else if (VIEW_PAGE.Equals("SCORE_CARD"))
        //{
        //    string url = "../usr/usr5002_embed.aspx?EDEPTID="           + EST_DEPT_REF_ID.ToString()
        //                                    + "&TMCODE="                + TMCODE.ToString()
        //                                    + "&SUMTYPE=0"
        //                                    + "&ESTTERMREFID="          + ESTTERM_REF_ID.ToString();

        //    ifm_05.Attributes.Add("src", url);
        //}
        //else if (VIEW_PAGE.Equals("GROUP_VIEW"))
        //{
        //    string url = "../usr/usr2007_embed.aspx?ESTTERM_REF_ID="    + ESTTERM_REF_ID.ToString()
        //                                + "&EST_DEPT_REF_ID="           + EST_DEPT_REF_ID.ToString()
        //                                + "&TMCODE="                    + TMCODE.ToString();

        //    ifm_02.Attributes.Add("src", url);
        //}
        else if (VIEW_PAGE.Equals("STG_LIST"))
        {
            string url = "../usr/usr1000_embed.aspx?ESTTERM_REF_ID="   + ESTTERM_REF_ID.ToString()
                                                + "&EST_DEPT_REF_ID="  + EST_DEPT_REF_ID.ToString()
                                                + "&TMCODE="           + TMCODE.ToString()
                                                + "&SUMTYPE=0";

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_03.Attributes.Add("src", url);
        }
        else if (VIEW_PAGE.Equals("KPI_LIST"))
        {
            string url = "../usr/usr2000_embed.aspx?ESTTERM_REF_ID="   + ESTTERM_REF_ID.ToString()
                                                + "&EST_DEPT_REF_ID="  + EST_DEPT_REF_ID.ToString()
                                                + "&TMCODE="           + TMCODE.ToString()
                                                + "&SUMTYPE=0";

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_04.Attributes.Add("src", url);
        }
        else if (VIEW_PAGE.Equals("PAREPORT"))
        {
            string url = "../usr/svr5000_embed.aspx?ESTTERM_REF_ID="    + ESTTERM_REF_ID.ToString()
                                                + "&EST_DEPT_REF_ID="   + EST_DEPT_REF_ID.ToString()
                                                + "&TMCODE="            + TMCODE.ToString();

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_06.Attributes.Add("src", url);
        }
        else if (VIEW_PAGE.Equals("CEO_COM"))
        {
            //string url = "../usr/usr3010_embed.aspx?ESTTERM_REF_ID="    + ESTTERM_REF_ID.ToString()
            //                                    + "&EST_DEPT_REF_ID="   + EST_DEPT_REF_ID.ToString()
            //                                    + "&TMCODE="            + TMCODE.ToString();

            string url = "../usr/usr3010_embed.aspx";

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_07.Attributes.Add("src", url);
        }
        //else if (VIEW_PAGE.Equals("EXCEL_OLAP"))
        //{
        //    string url = "../usr/usr_excel_pivot.aspx?ESTTERM_REF_ID="  + ESTTERM_REF_ID.ToString()
        //                                        + "&EST_DEPT_REF_ID="   + EST_DEPT_REF_ID.ToString()
        //                                        + "&TMCODE="            + TMCODE.ToString();

        //    ifm_08.Attributes.Add("src", url);
        //}
        //else if (VIEW_PAGE.Equals("DUNDAS_OLAP"))
        //{
        //    string url = "../usr/usr_dundas_olap.aspx?ESTTERM_REF_ID="  + ESTTERM_REF_ID.ToString()
        //                                        + "&EST_DEPT_REF_ID="   + EST_DEPT_REF_ID.ToString()
        //                                        + "&TMCODE="            + TMCODE.ToString();

        //    ifm_09.Attributes.Add("src", url);
        //}
        else if (VIEW_PAGE.Equals("DEPT_ORG"))
        {
            string url = "../usr/usr_dept_org_embed.aspx?ESTTERM_REF_ID="   + ESTTERM_REF_ID.ToString()
                                                + "&EST_DEPT_REF_ID="       + EST_DEPT_REF_ID.ToString()
                                                + "&TMCODE="                + TMCODE.ToString();

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_10.Attributes.Add("src", url);
        }
        else if (VIEW_PAGE.Equals("DEPT_SCORE_CARD"))
        {
            string url = "../usr/usr5001_embed.aspx?ESTTERM_REF_ID="        + ESTTERM_REF_ID.ToString()
                                                + "&EST_DEPT_REF_ID="       + EST_DEPT_REF_ID.ToString()
                                                + "&TMCODE="                + TMCODE.ToString();

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_11.Attributes.Add("src", url);
        }
        else if (VIEW_PAGE.Equals("DATE_SCORE_CARD"))
        {
            string url = "../usr/usr5100_embed.aspx?ESTTERM_REF_ID="        + ESTTERM_REF_ID.ToString()
                                                + "&EST_DEPT_REF_ID="       + EST_DEPT_REF_ID.ToString()
                                                + "&TMCODE="                + TMCODE.ToString();

            UltraWebTab1.Tabs.FromKeyTab(VIEW_PAGE).ContentPane.TargetUrl = url;
            //ifm_12.Attributes.Add("src", url);
        }
    }
}
