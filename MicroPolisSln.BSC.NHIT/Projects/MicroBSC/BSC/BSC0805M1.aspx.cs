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
using System.Text;
using System.Drawing;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class BSC_BSC0805M1 : AppPageBase
{
    #region 변수선언 및 초기화
    int intGridRow = 0;

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

    public int IEstDeptRefID
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
                ViewState["YMD"] = GetRequest("YMD", "000000");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    #endregion

    #region 페이지 초기화
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
        }

        ltrScript.Text = "";
    }

    private void InitControlValue()
    {
        iBtnPrint.Style.Add("vertical-align", "middle");
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetComDeptDropDownList(ddlComDept, true);

        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 100);
    }

    private void InitControlEvent()
    {
        this.SetExternalScoreGrid();
    }

    private void SetPostBack()
    {

    }

    #endregion

    #region 내부함수
    /// <summary>
    /// 결재아이콘 범례생성
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SetDraftLegend(object sender, LayoutEventArgs e)
    { 
        try
        {
            e.Layout.StationaryMargins                  = StationaryMargins.HeaderAndFooter;
            e.Layout.CellClickActionDefault             = CellClickAction.Edit;
            e.Layout.ColFootersVisibleDefault           = ShowMarginInfo.Yes;
            e.Layout.FooterStyleDefault.Height          = Unit.Pixel(25);
            e.Layout.FooterStyleDefault.BackColor       = Color.WhiteSmoke;
            e.Layout.FooterStyleDefault.ForeColor       = Color.Navy;
            e.Layout.FooterStyleDefault.Margin.Right    = Unit.Pixel(10);
            e.Layout.FooterStyleDefault.HorizontalAlign = HorizontalAlign.Right;
            e.Layout.FooterStyleDefault.VerticalAlign   = VerticalAlign.Middle;

            int iCol  = e.Layout.Bands[0].Columns.Count - 1;
            int iMrg  = iCol;  // Start Colspan Length
            int iFRow = 0;     // Start Colspan Index
            for (int i = 0; i < iCol; i++)
            {
                iFRow += 1;
                if (e.Layout.Bands[0].Columns[i].Hidden)
                {
                    iMrg -= 1;
                }
                else
                {
                    e.Layout.Bands[0].Columns[i].Footer.RowLayoutColumnInfo.SpanX     = iMrg;
                    break;
                }
            }

            if (iFRow > 0)
            {
                string sLegend = Biz_Type.app_legend;

                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Caption = sLegend;
                e.Layout.Bands[0].Columns[iFRow - 1].Footer.Style.Width = Unit.Percentage(100);
            }
        }
        catch (Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript(ex.Message);
        }
    }

    public void SetExternalScoreGrid()
    {
        Biz_Bsc_Kpi_External_Score objBSC = new Biz_Bsc_Kpi_External_Score();
        DataSet rDs = objBSC.GetKpiExternalScore
                    (PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                   , PageUtility.GetByValueDropDownList(ddlEstTermMonth)
                   , txtKPICode.Text
                   , txtKPIName.Text
                   , PageUtility.GetIntByValueDropDownList(ddlComDept)
                   , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                   );

        ugrdExtScore.Clear();
        ugrdExtScore.DataSource = rDs;
        ugrdExtScore.DataBind();

        if (rDs.Tables.Count > 0)
        {
            lblCountRow.Text = "Total Rows : " + rDs.Tables[0].Rows.Count.ToString();
        }
        else
        {
            lblCountRow.Text = "Total Rows : 0" ;
        }
    }

    public DataTable GetExternalScore()
    {
        int iRow = ugrdExtScore.Rows.Count;
        DataTable dtScore = new DataTable("EXT_SCORE");

        dtScore.Columns.Add("ESTTERM_REF_ID", typeof(int));
        dtScore.Columns.Add("YMD", typeof(string));
        dtScore.Columns.Add("KPI_REF_ID", typeof(int));
        dtScore.Columns.Add("WEIGHT_INR", typeof(decimal));
        dtScore.Columns.Add("WEIGHT_EXT", typeof(decimal));
        dtScore.Columns.Add("TARGET_EXT", typeof(decimal));
        dtScore.Columns.Add("RESULT_EXT", typeof(decimal));
        dtScore.Columns.Add("POINTS_EXT", typeof(decimal));
        dtScore.Columns.Add("GRADE_EXT", typeof(string));
        dtScore.Columns.Add("OPINION_EXT", typeof(string));
        
        DataRow drScore = null;
        for (int i = 0; i < iRow; i++)
        {
            drScore = dtScore.NewRow();
            drScore["ESTTERM_REF_ID"] = int.Parse(ugrdExtScore.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            drScore["YMD"]            = ugrdExtScore.Rows[i].Cells.FromKey("YMD").Value.ToString();
            drScore["KPI_REF_ID"]     = int.Parse(ugrdExtScore.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
            drScore["WEIGHT_INR"]     = decimal.Parse(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Value.ToString());
            drScore["WEIGHT_EXT"]     = decimal.Parse(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Value.ToString());
            drScore["TARGET_EXT"]     = decimal.Parse(ugrdExtScore.Rows[i].Cells.FromKey("TARGET_EXT").Value.ToString());
            drScore["RESULT_EXT"]     = decimal.Parse(ugrdExtScore.Rows[i].Cells.FromKey("RESULT_EXT").Value.ToString());
            drScore["POINTS_EXT"]     = decimal.Parse(ugrdExtScore.Rows[i].Cells.FromKey("POINTS_EXT_ORI").Value.ToString());
            drScore["GRADE_EXT"]      = (ugrdExtScore.Rows[i].Cells.FromKey("GRADE_EXT").Value == null) ? "" : ugrdExtScore.Rows[i].Cells.FromKey("GRADE_EXT").Value.ToString().ToUpper();
            drScore["OPINION_EXT"]    = ""; //(ugrdExtScore.Rows[i].Cells.FromKey("OPINION_EXT").Value == null) ? "" : ugrdExtScore.Rows[i].Cells.FromKey("OPINION_EXT").Value.ToString();
            dtScore.Rows.Add(drScore);
        }

        return dtScore;
    }

    public void SaveExternalPoint()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_External_Score objBsc = new Biz_Bsc_Kpi_External_Score();
        int iRtn = objBsc.InsertAllData(this.GetExternalScore(), gUserInfo.Emp_Ref_ID);
        ltrScript.Text = JSHelper.GetAlertScript(objBsc.Transaction_Message, false);
    }
    #endregion

    #region 서버 이벤트 처리 함수
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, this.IEstTermRefID);
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }

    protected void iBtnSearch_Click(object sender, EventArgs e)
    {
        this.SetExternalScoreGrid();
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        this.SaveExternalPoint();
    }

    protected void iBtnCancel_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void chkApplyFirstRow_CheckedChanged(object sender, EventArgs e)
    {
        int intRow = ugrdExtScore.Rows.Count;
        double dblWeight_Inr = 0;
        double dblWeight_Ext = 0;

        for (int i = 0; i < intRow; i++)
        {
            if (chkApplyFirstRow.Checked)
            {
                if (i == 0)
                {
                    dblWeight_Inr = Convert.ToDouble(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Value.ToString());
                    dblWeight_Ext = Convert.ToDouble(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Value.ToString());
                }
                else
                {
                    ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Value = dblWeight_Inr;
                    ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Value = dblWeight_Ext;
                }

                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").AllowEditing = AllowEditing.No;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").AllowEditing = AllowEditing.No;

                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Style.BackColor = Color.WhiteSmoke;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Style.BackColor = Color.WhiteSmoke;
            }
            else
            {
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").AllowEditing = AllowEditing.Yes;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").AllowEditing = AllowEditing.Yes;

                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Style.BackColor = Color.White;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Style.BackColor = Color.White;
            }
        }
    }

    protected void ugrdExtScore_InitializeLayout(object sender, LayoutEventArgs e)
    {
        //this.SetDraftLegend(sender, e);

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;

            c.CellStyle.BackColor = Color.WhiteSmoke;
            c.AllowUpdate = AllowUpdate.No;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "지표기본정보";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 5;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "가중치";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "누계(내부)";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "누계(외부)";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "원시점수/등급";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 11;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "최종점수";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 14;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        //ch = e.Layout.Bands[0].Columns[13].Header;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 13;
        //ch.RowLayoutColumnInfo.SpanY = 2;

        //ch = e.Layout.Bands[0].Columns[12].Header;
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 14;
        //ch.RowLayoutColumnInfo.SpanY   = 2;
    }

    protected void ugrdExtScore_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        e.Row.Height = Unit.Pixel(20);
        DataRowView drw = (DataRowView)e.Data;

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        objImg.ImageUrl      = Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = Biz_Com_Approval_Info.GetAppImageText(strImg);

        e.Row.Cells.FromKey("WEIGHT_INR").Style.BackColor     = Color.White;
        e.Row.Cells.FromKey("WEIGHT_EXT").Style.BackColor     = Color.White;
        e.Row.Cells.FromKey("TARGET_EXT").Style.BackColor     = Color.White;
        e.Row.Cells.FromKey("RESULT_EXT").Style.BackColor     = Color.White;
        e.Row.Cells.FromKey("POINTS_EXT_ORI").Style.BackColor = Color.White;
        e.Row.Cells.FromKey("GRADE_EXT").Style.BackColor      = Color.White;

        e.Row.Cells.FromKey("WEIGHT_INR").AllowEditing        = AllowEditing.Yes;
        e.Row.Cells.FromKey("WEIGHT_EXT").AllowEditing        = AllowEditing.Yes;
        e.Row.Cells.FromKey("TARGET_EXT").AllowEditing        = AllowEditing.Yes;
        e.Row.Cells.FromKey("RESULT_EXT").AllowEditing        = AllowEditing.Yes;
        e.Row.Cells.FromKey("POINTS_EXT_ORI").AllowEditing    = AllowEditing.Yes;
        e.Row.Cells.FromKey("GRADE_EXT").AllowEditing         = AllowEditing.Yes;

        if (e.Row.Cells.FromKey("POINTS_INR_ORI").Value.ToString() != "-")
        {
            decimal points_inr = (e.Row.Cells.FromKey("POINTS_INR_ORI").Value == null) ? 0 : decimal.Parse(e.Row.Cells.FromKey("POINTS_INR_ORI").Value.ToString());
            e.Row.Cells.FromKey("POINTS_INR_ORI").Value = points_inr.ToString("#,##0.00");
        }

        if (e.Row.Cells.FromKey("POINTS_INR_FNL").Value.ToString() != "-")
        {
            decimal points_inr = (e.Row.Cells.FromKey("POINTS_INR_FNL").Value == null) ? 0 : decimal.Parse(e.Row.Cells.FromKey("POINTS_INR_FNL").Value.ToString());
            e.Row.Cells.FromKey("POINTS_INR_FNL").Value = points_inr.ToString("#,##0.0000");
        }

        if (e.Row.Cells.FromKey("POINTS_EXT_FNL").Value.ToString() != "-")
        {
            decimal points_inr = (e.Row.Cells.FromKey("POINTS_EXT_FNL").Value == null) ? 0 : decimal.Parse(e.Row.Cells.FromKey("POINTS_EXT_FNL").Value.ToString());
            e.Row.Cells.FromKey("POINTS_EXT_FNL").Value = points_inr.ToString("#,##0.0000");
        }
    }
    
    #endregion
}
