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

using Dundas.Charting.WebControl;
using MicroCharts;
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;

public partial class BSC_BSC0403P4 : AppPageBase
{
    #region 변수선언
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("ITYPE", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

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

    public string IGubun
    {
        get
        {
            if (ViewState["GUBUN"] == null)
            {
                ViewState["GUBUN"] = GetRequest("GUBUN", "L");
            }

            return (string)ViewState["GUBUN"];
        }
        set
        {
            ViewState["GUBUN"] = value;
        }
    }

    public bool IExtKpiYN
    {
        get
        {
            if (ViewState["EXT_KPI_YN"] == null)
            {
                ViewState["EXT_KPI_YN"] = (GetRequest("EXT_KPI_YN", "Y") == "Y") ? true : false;
            }

            return (bool)ViewState["EXT_KPI_YN"];
        }
        set
        {
            ViewState["EXT_KPI_YN"] = value;
        }
    }

    private int iViewLp = 0;
    #endregion

    #region 페이지초기화

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        {

        }
    }

    #endregion

    #region 내부함수
    private void NotPostBackSetting()
    {
        this.SetInitForm();
        this.SetDeptScoreCard();

        this.SetEstDeptLoadMap();
        this.SetKpiStatusGrid();
        this.SetDeptScoreCard();
        //this.SetFormObject(true);
    }

    private void SetInitForm()
    { 
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        ddlEstTermInfo.SelectedValue = this.IEstTermRefID.ToString();

        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        PageUtility.FindByValueDropDownList(ddlMonthInfo, this.IYmd);

        WebCommon.SetSumTypeDropDownList(ddlSumType, false);
        PageUtility.FindByValueDropDownList(ddlSumType, this.ISumType);

        if (this.IEstTermRefID > 0)
        {
            PageUtility.FindByValueDropDownList(ddlEstTermInfo, this.IEstTermRefID.ToString());
        }

        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);

        WebCommon.SetEstDeptDropDownList(ddlEstDept, this.IEstTermRefID, false, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlEstDept, this.IEstDeptID);

        WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, this.IEstTermRefID);
        chkApplyExtScore.Checked = this.IExtKpiYN;

        chkApplyExtScore.Visible = false;

        lblEstTermInfo.Text = PageUtility.GetByTextDropDownList(ddlEstTermInfo);
        lblMonthInfo.Text   = PageUtility.GetByTextDropDownList(ddlMonthInfo);
        lblSumType.Text     = PageUtility.GetByTextDropDownList(ddlSumType);

        lblEstTermInfo.Style.Add(HtmlTextWriterStyle.TextAlign, "left");
    }

    private void SetParam()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IEstDeptID    = PageUtility.GetIntByValueDropDownList(ddlEstDept);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlMonthInfo);
        this.IExtKpiYN     = this.chkApplyExtScore.Checked;
        this.ISumType      = PageUtility.GetByValueDropDownList(ddlSumType);
    }

    private void SetMapinfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objMapinfo = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info(this.IEstTermRefID, this.IEstDeptID, this.IYmd);
        lblDeptVision.Text  = objMapinfo.Idept_vision;
        lblChampName.Text   = objMapinfo.Ibscchampion_name;
        lblEstDeptName.Text = objMapinfo.Iest_dept_name;
    }
    private void SetKpiStatusGrid()
    {
        this.SetMapinfo();

        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();

        DataSet dsScore = objBSC.GetEstDeptTotalScore
                                 (
                                  this.IEstTermRefID
                                , this.IYmd
                                , this.ISumType
                                , this.IEstDeptID
                                , chkApplyExtScore.Checked
                                 );

        if (dsScore.Tables[0].Rows.Count > 0)
        {
            string strs = dsScore.Tables[0].Rows[0]["POINT"].ToString();
        }


        DataSet dsKpi = objBSC.GetEstDeptKpiScoreList
                                                 ( this.IEstTermRefID
                                                 , this.IYmd
                                                 , this.ISumType
                                                 , this.IEstDeptID
                                                 , chkApplyExtScore.Checked);
        //ugrdKpiStatus.Clear();
        ugrdKpiStatus.DataSource = dsKpi.Tables[0].DefaultView;
        ugrdKpiStatus.DataBind();
    }

    private void SetEstDeptLoadMap()
    {
        this.SetMapinfo();

        MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap objMap = new MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap();
        DataSet rDs = objMap.GetLoadMapPerEstDept(this.IEstTermRefID, this.IEstDeptID);

//        ugrdLoadMapList.Clear();
        ugrdLoadMapList.DataSource = rDs.Tables[0].DefaultView;
        ugrdLoadMapList.DataBind();
    }

    private void SetDeptScoreCard()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet rDs = objBSC.GetEstDeptTotalScoreForMap
                                        (this.IEstTermRefID
                                        , this.IYmd
                                        , this.ISumType
                                        , this.IEstDeptID
                                        , this.IExtKpiYN
                                        );
        ultraLegend.DataSource = rDs.Tables[0].DefaultView;
        ultraLegend.DataBind();
    }

    #endregion

    #region 이벤트
    protected void ugrdKpiStatus_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView oGridView = (GridView)sender;
        //    GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //    TableHeaderCell oTableCell = new TableHeaderCell();

        //    oTableCell.ColumnSpan = 1;
        //    oTableCell.RowSpan    = 2;
        //    oTableCell.Text = "목표&lt;BR /&gt;시기";
        //    oGridViewRow.Cells.Add(oTableCell);

        //    oTableCell = new TableHeaderCell();
        //    oTableCell.Text = "당초목표";
        //    oTableCell.ColumnSpan = 2;  
        //    oGridViewRow.Cells.Add(oTableCell);

        //    oTableCell = new TableHeaderCell();
        //    oTableCell.Text = "수정목표";
        //    oTableCell.ColumnSpan = 2;
        //    oGridViewRow.Cells.Add(oTableCell);

        //    oTableCell = new TableHeaderCell();
        //    oTableCell.ColumnSpan = 1;
        //    oTableCell.RowSpan    = 2;
        //    oTableCell.Text = "마감&lt;BR /&gt;여부";
        //    oGridViewRow.Cells.Add(oTableCell);

        //    oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);

        //    e.Row.Cells[0].Visible = false;
        //    e.Row.Cells[5].Visible = false;
        //    e.Row.Cells[5].Width   = Unit.Pixel(80);
        //}
    }

    protected void ugrdKpiStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[5].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[6].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[7].Style.Add(HtmlTextWriterStyle.TextAlign, "right");

            //if (e.Row.Cells[6].Text == "N")
            //{
            //    e.Row.Cells[1].BackColor = Color.WhiteSmoke;
            //    e.Row.Cells[2].BackColor = Color.WhiteSmoke;
            //}
            //else
            //{
            //    e.Row.Cells[1].BackColor = Color.White;
            //    e.Row.Cells[2].BackColor = Color.White;
            //}

            //if (e.Row.Cells[7].Text == "N")
            //{
            //    e.Row.Cells[3].BackColor = Color.WhiteSmoke;
            //    e.Row.Cells[4].BackColor = Color.WhiteSmoke;
            //}
            //else
            //{
            //    e.Row.Cells[3].BackColor = Color.White;
            //    e.Row.Cells[4].BackColor = Color.White;
            //}

            string sSignal = DataBinder.Eval(e.Row.DataItem, "SIGNAL").ToString();

            System.Web.UI.WebControls.Image imgSignal = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgSignal");

            imgSignal.ImageUrl = "~/images/" + sSignal;
        }
    }

    protected void ugrdLoadMapList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.TextAlign, "center");
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            e.Row.Cells[1].Text = PageUtility.GetHtmlEncodeChar(e.Row.Cells[1].Text);
            e.Row.Cells[2].Text = PageUtility.GetHtmlEncodeChar(e.Row.Cells[2].Text);
        }
    }

    protected void ultraLegend_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (iViewLp == 0)
            {
                e.Row.Height = Unit.Pixel(25);
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.TextDecoration, "bold");
            }
            e.Row.Cells[0].Width = Unit.Pixel(100);
            e.Row.Cells[1].Width = Unit.Pixel(70);
            e.Row.Cells[2].Width = Unit.Pixel(15);
            e.Row.Cells[3].Width = Unit.Pixel(70);

            e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "center");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "left");

            e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.BackgroundColor, "whitesmoke");
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.BackgroundColor, "whitesmoke");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.BackgroundColor, "whitesmoke");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.BackgroundColor, "whitesmoke");

            iViewLp += 1;
        }
    }

    #endregion
}
