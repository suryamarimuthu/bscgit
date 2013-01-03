using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using MicroBSC.Biz.BSC;
using Infragistics.WebUI.UltraWebGrid;

public partial class base_com1000 : AppPageBase
{
    private double cntKpi       = 0;
    private double cntEstKpi    = 0;
    private double cntCfmKpi    = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);

//        StrategyMapInfos stgMapInfo = new StrategyMapInfos();
        if (!Page.IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            //WebCommon.SetMonthDropDownList(ddlMonthInfo);
            //int TMCODE = stgMapInfo.GetTMCODE();
            //ddlMonthInfo.Items.FindByValue(TMCODE.ToString()).Selected = true;

            int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, intEstTermId);
            DataBinding();
        }
    }
    private void DataBinding()
    {
        int    _iestterm_ref_id         = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        string _iresult_input_method    = "";
        string _ikpi_code               = "";
        string _ikpi_name               = "";
        string _iemp_name               = "";
        int    _iest_dept_id            = 0;
        int    _ilogin_id               = gUserInfo.Emp_Ref_ID;
        string _itmcode                 = (ddlMonthInfo.Items.Count > 0) ? ddlMonthInfo.SelectedValue : "";

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet ds                      = objBSC.GetKpiListForResultInput(_iestterm_ref_id
                                                                        , _iresult_input_method
                                                                        , _ikpi_code
                                                                        , _ikpi_name
                                                                        , _iemp_name
                                                                        , _iest_dept_id
                                                                        , _itmcode
                                                                        , ""
                                                                        , ""
                                                                        , _ilogin_id);

        cntKpi          = 0;
        cntEstKpi       = 0;
        cntCfmKpi       = 0;

        ugrdKpiResultList.DataSource = ds;
        ugrdKpiResultList.DataBind();
    }

    protected void ugrdKpiResultList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;
        UltraGridCell cell;

        //cntKpi          += 1;
        //cntEstKpi       += (e.Row.Cells.FromKey("CHECK_YN").Value.ToString()      =="Y") ? 1 : 0;
        //cntCfmKpi       += (e.Row.Cells.FromKey("CONFIRMSTATUS").Value.ToString() =="Y") ? 1 : 0;

        //lblTotKpi.Text  = cntKpi.ToString();
        //lblEstKpi.Text  = cntEstKpi.ToString();
        //lblCfmKpi.Text  = cntCfmKpi.ToString();
        //lblEstRate.Text = (cntEstKpi == 0) ? "0%" : Convert.ToString(Math.Round((cntEstKpi / cntKpi)*100,0))+"%";
        //lblCfmRate.Text = (cntCfmKpi == 0) ? "0%" : Convert.ToString(Math.Round((cntCfmKpi / cntEstKpi) * 100, 0)) + "%";

        //lblCfmRate.ForeColor = (int.Parse(lblCfmRate.Text.Replace("%", "")) < 100) ? Color.Red : Color.Blue;

        DataRowView drw = (DataRowView)e.Data;

        cntKpi          += 1;
        cntEstKpi       += (drw["CHECK_YN"].ToString()      =="Y") ? 1 : 0;
        cntCfmKpi       += (drw["CONFIRMSTATUS"].ToString() =="Y") ? 1 : 0;

        lblTotKpi.Text  = cntKpi.ToString();
        lblEstKpi.Text  = cntEstKpi.ToString();
        lblCfmKpi.Text  = cntCfmKpi.ToString();
        lblEstRate.Text = (cntEstKpi == 0) ? "0%" : Convert.ToString(Math.Round((cntEstKpi / cntKpi)*100,0))+"%";
        lblCfmRate.Text = (cntCfmKpi == 0) ? "0%" : Convert.ToString(Math.Round((cntCfmKpi / cntEstKpi) * 100, 0)) + "%";

        lblCfmRate.ForeColor = (int.Parse(lblCfmRate.Text.Replace("%", "")) < 100) ? Color.Red : Color.Blue;

        if (drw["CHECK_YN"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        if (drw["CHECKSTATUS"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECKSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        if (drw["CONFIRMSTATUS"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CONFIRMSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CONFIRMSTATUS").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }
    }
    protected void ugrdKpiResultList_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {

    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        return;
    }
    protected void ddlMonthInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ltlMsg.Text = "";
        DataBinding();
    }
}
