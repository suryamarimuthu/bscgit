using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using MicroCharts;
using MicroBSC.Estimation.Dac;
using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Integration.BSC.Biz;


using Infragistics.WebUI.UltraWebGrid;
//using Dundas.Gauges.WebControl;
//using Dundas.Charting.WebControl;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_BSC3000S1 : AppPageBase
{

    public double dTotalPoint = 0;

    #region --> Property

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IEstDeptID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public int IDeptID
    {
        get
        {
            if (ViewState["COM_DEPT_REF_ID"] == null)
            {
                ViewState["COM_DEPT_REF_ID"] = GetRequestByInt("COM_DEPT_REF_ID", 0);
            }

            return (int)ViewState["COM_DEPT_REF_ID"];
        }
        set
        {
            ViewState["COM_DEPT_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string ISumType
    {
        get
        {
            if (ViewState["SUM_TYPE"] == null)
            {
                ViewState["SUM_TYPE"] = GetRequest("SUM_TYPE", "");
            }

            return (string)ViewState["SUM_TYPE"];
        }
        set
        {
            ViewState["SUM_TYPE"] = value;
        }
    }

    #endregion

    #region --> Page_Load()

    protected void Page_Load(object sender, EventArgs e)
    {
        //좌측메뉴설정
        base.SetMenuControl(true, true, true);

        if (!IsPostBack) 
        {

            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            IEstTermRefID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);


            SetMyKPIGrid();
            SetNoticeGrid();
            SetFAQGrid();

        }
        else
        {
        }

    }

    private void NotPostBackSetting()
    {

        //WebCommon.SetSumTypeDropDownList(ddlSumType, false);

        //DeptInfos objDept = new DeptInfos();

        //if (Request["EST_DEPT_REF_ID"] == null)
        //{
        //    objDept = new DeptInfos();
        //    this.IEstDeptID = objDept.GetRootEstDeptID(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        //}
        //else
        //{
        //    this.IEstDeptID = WebUtility.GetRequestByInt("EST_DEPT_REF_ID");
        //}



        //this.Search(this.IEstDeptID);
    }

    #endregion

    #region --> Event

    
    protected void ugrdMyKpiList_InitializeLayout(object sender, LayoutEventArgs e)
    {

        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = null;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Reset();
        //ch.Caption = "목표";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 5;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        ////ch.RowLayoutColumnInfo.SpanY = 3;
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Reset();
        //ch.Caption = "달성율(%)";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 8;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

    }

    protected void ugrdMyKpiList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }


    protected void ugrdNotice_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }


    protected void ugrdFAQ_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

    }

    #endregion

    #region --> Function
    /// <summary>
    /// my kpi
    /// </summary>
    private void SetMyKPIGrid()
    {
        ugrdMyKpiList.Clear();


        MicroBSC.Integration.BSC.Biz.Biz_My_Kpi bizMyKpi = new MicroBSC.Integration.BSC.Biz.Biz_My_Kpi();

        
        DataTable dtMyMboKpi = bizMyKpi.SelectMyMboKpi(IEstTermRefID,bizMyKpi.SelectCurrentYYYYMM(), gUserInfo.LoginID);

        if (dtMyMboKpi.Rows.Count > 0)
        {
            Label1.Text = "mbo";
            ugrdMyKpiList.DataSource = dtMyMboKpi;
            ugrdMyKpiList.DataBind();
        }
        else{
            DataTable dtMyTeamKpi = bizMyKpi.SelectMyTeamKpi(IEstTermRefID, bizMyKpi.SelectCurrentYYYYMM(), gUserInfo.LoginID);

            if (dtMyTeamKpi.Rows.Count > 0)
            {
                Label1.Text = "team";
                ugrdMyKpiList.DataSource = dtMyTeamKpi;
                ugrdMyKpiList.DataBind();
            }
            else{
                ugrdMyKpiList.Visible = false;
            }

        }

    }

    /// <summary>
    /// 공지사항 조회
    /// </summary>
    private void SetNoticeGrid()
    {
        Biz_Bsc_Communication_Notice objBSC = new Biz_Bsc_Communication_Notice();
        this.ugrdNotice.Clear();
        this.ugrdNotice.DataSource = objBSC.GetAllList();
        this.ugrdNotice.DataBind();
    }
    /// <summary>
    /// 공지사항 조회
    /// </summary>
    private void SetFAQGrid()
    {
        Biz_Bsc_Faq objBSC = new Biz_Bsc_Faq();
        this.ugrdFAQ.Clear();
        this.ugrdFAQ.DataSource = objBSC.SelectBscFaqAll();
        this.ugrdFAQ.DataBind();
    }


    #endregion
}