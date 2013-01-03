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
using System.Drawing;

using MicroBSC.BSC.Biz;
using Infragistics.WebUI.UltraWebGrid;

using Dundas.Charting.WebControl;
using MicroCharts;

using MicroBSC.Biz.Common;

public partial class BSC_BSC0604S1 : AppPageBase
{
    #region 변수선언
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
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

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public string IYMD
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

    public string IDiCode
    {
        get
        {
            if (ViewState["DICODE"] == null)
            {
                ViewState["DICODE"] = GetRequest("DICODE", "");
            }

            return (string)ViewState["DICODE"];
        }
        set
        {
            ViewState["DICODE"] = value;
        }
    }

    public string IGoalTong_YN
    {
        get
        {
            if (ViewState["GOALTONG_YN"] == null)
            {
                ViewState["GOALTONG_YN"] = GetRequest("GOALTONG_YN", "N");
            }
            return (string)ViewState["GOALTONG_YN"];
        }
        set
        {
            ViewState["GOALTONG_YN"] = value;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdInterface.InitializeRow += new InitializeRowEventHandler(ugrdInterface_InitializeRow);
        ltrScript.Text = "";
        if (!IsPostBack)
        {
            this.SetMonthlyResultGraph();
        }
    }

    public void SetMonthlyResultGraph()
    {
        Biz_Bsc_Kpi_Info objKpi = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        lblKpiCode.Text = objKpi.Ikpi_code;
        lblKpiName.Text = objKpi.Ikpi_name;
        lblResultInputType.Text = objKpi.Iresult_input_type_name;
        lblUnitName.Text = objKpi.Iunit_name;

        Biz_Bsc_Kpi_Result objBSC = new Biz_Bsc_Kpi_Result(this.IEstTermRefID, this.IKpiRefID, this.IYMD);
        DataSet rDs = objBSC.GetResultAnalysisList(this.IEstTermRefID, this.IKpiRefID, this.IYMD, this.IGoalTong_YN);

        DataTable dtMs = new DataTable("TBL_MS");
        DataTable dtTs = new DataTable("TBL_TS");

        dtMs.Columns.Add("MM", typeof(string));
        dtMs.Columns.Add("TARGET", typeof(double));
        dtMs.Columns.Add("RESULT", typeof(double));

        dtTs.Columns.Add("MM", typeof(string));
        dtTs.Columns.Add("TARGET", typeof(double));
        dtTs.Columns.Add("RESULT", typeof(double));

        double dTargetMs = 0;
        double dTargetTs = 0;
        double dResultMs = 0;
        double dResultTs = 0;
        DataRow[] arrDr  = null;
        DataRow rDr      = null;
        if (rDs.Tables.Count > 0)
        {
            if (rDs.Tables[0].Rows.Count > 0)
            {
                string sFilter  = "KPI_REF_ID="+this.IKpiRefID.ToString() + " AND YMD='" + this.IYMD + "'";
                arrDr = rDs.Tables[0].Select(sFilter);

                if (arrDr.GetLength(0) > 0)
                { 
                    dTargetMs = double.Parse(arrDr[0]["TARGET_MS"].ToString());
                    dTargetTs = double.Parse(arrDr[0]["TARGET_TS"].ToString());
                    dResultMs = double.Parse(arrDr[0]["RESULT_MS"].ToString());
                    dResultTs = double.Parse(arrDr[0]["RESULT_TS"].ToString());

                }
            }
        }

        rDr = dtMs.NewRow();
        rDr["MM"]     = this.IYMD;
        rDr["TARGET"] = dTargetMs;
        rDr["RESULT"] = dResultMs;
        dtMs.Rows.Add(rDr);

        rDr = dtTs.NewRow();
        rDr["MM"]     = this.IYMD;
        rDr["TARGET"] = dTargetTs;
        rDr["RESULT"] = dResultTs;
        dtTs.Rows.Add(rDr);

        DundasCharts.DundasChartBase(chartMs, ChartImageType.Flash, 360, 200
        , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
        , Color.FromArgb(0xFF, 0xFF, 0xFE)
        , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
        , -1
        , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series serTargetMs = DundasCharts.CreateSeries(chartMs, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series serResultMs = DundasCharts.CreateSeries(chartMs, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        serTargetMs.ToolTip = "#VALY{N0}";
        serResultMs.ToolTip = "#VALY{N0}";

        chartMs.ChartAreas[chartMs.Series[serTargetMs.Name].ChartArea].AxisY.LabelStyle.Format = "N0";
        chartMs.ChartAreas[chartMs.Series[serTargetMs.Name].ChartArea].Area3DStyle.Enable3D = true;
        chartMs.ToolTip = "#VALY{N0}";


        chartMs.DataSource = dtMs.DefaultView;
        serTargetMs.ValueMemberX  = "MM";
        serTargetMs.ValueMembersY = "TARGET";
        serResultMs.ValueMembersY = "RESULT";
        
        chartMs.DataBind();

        DundasCharts.DundasChartBase(chartTs, ChartImageType.Flash, 360, 200
        , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
        , Color.FromArgb(0xFF, 0xFF, 0xFE)
        , Color.FromArgb(0xFF, 0xFF, 0xFE), Color.FromArgb(0x20, 0x80, 0xD0), ChartDashStyle.Solid
        , -1
        , ChartHatchStyle.None, GradientType.TopBottom, AntiAliasing.None);

        Series serTargetTs = DundasCharts.CreateSeries(chartTs, "Series1", "Default", "계획", null, SeriesChartType.Column, 1, GetChartColor(0), GetChartColor(0), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));
        Series serResultTs = DundasCharts.CreateSeries(chartTs, "Series2", "Default", "실적", null, SeriesChartType.Column, 1, GetChartColor(1), GetChartColor(1), Color.FromArgb(64, 0, 0, 0), 1, 9, Color.FromArgb(64, 64, 64));

        serTargetTs.ToolTip = "#VALY{N0}";
        serResultTs.ToolTip = "#VALY{N0}";

        chartTs.ChartAreas[chartTs.Series[serTargetTs.Name].ChartArea].AxisY.LabelStyle.Format = "N0";
        chartTs.ChartAreas[chartTs.Series[serTargetTs.Name].ChartArea].Area3DStyle.Enable3D = true;
        chartTs.ToolTip = "#VALY{N0}";

        chartTs.DataSource = dtTs.DefaultView;
        serTargetTs.ValueMemberX  = "MM";
        serTargetTs.ValueMembersY = "TARGET";
        serResultTs.ValueMembersY = "RESULT";

        chartTs.DataBind();

        if (objKpi.Iresult_input_type == "KPI")
        {
            this.SetChildKpiGrid();
        }
        else
        {
            this.SetInterfaceGrid();
        }
    }

    public void SetInterfaceGrid()
    {
        Biz_Bsc_Interface_Kpi_Query objQry = new Biz_Bsc_Interface_Kpi_Query(this.IKpiRefID, "");
        this.IDiCode = objQry.IDicode;

        if (this.IDiCode == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("정의된 Interface가 없습니다.", false);
            return;
        }

        Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        DataSet rDs = objCol.GetAllList(this.IDiCode, gUserInfo.Emp_Ref_ID);

        int iRow        = 0;
        string sUseYn   = "N";
        string sColKey  = "";
        string sColName = "";
        int iDPoints    = 0;
        int iGridWith   = 0;

        UltraGridColumn ugCol;

        if (rDs.Tables.Count > 0)
        {
            iRow = rDs.Tables[0].Rows.Count;
            if (iRow > 0)
            {
                ugCol = new UltraGridColumn();
                ugCol.Key = "TRX_DATE";
                ugCol.BaseColumnName = "TRX_DATE";
                ugCol.Header.Caption = "발생일자";
                ugCol.Width = Unit.Pixel(100);
                ugCol.AllowUpdate = AllowUpdate.Yes;
                ugCol.DataType = "System.String";
                ugCol.CellStyle.HorizontalAlign = HorizontalAlign.Left;
                ugrdInterface.Columns.Add(ugCol);

                for (int i = 0; i < iRow; i++)
                {
                    sUseYn    = rDs.Tables[0].Rows[i]["USE_YN"].ToString();
                    sColKey   = rDs.Tables[0].Rows[i]["COLUMN_ID"].ToString();
                    sColName  = rDs.Tables[0].Rows[i]["COLUMN_ALIAS"].ToString();
                    iDPoints  = Convert.ToInt32(rDs.Tables[0].Rows[i]["DECIMAL_POINTS"].ToString());
                    iGridWith = Convert.ToInt32(rDs.Tables[0].Rows[i]["GRID_WIDTH"].ToString());
                    if (sUseYn == "Y")
                    {
                        if (sColKey.Substring(0, 7) == "SVALUES")
                        {
                            ugCol = new UltraGridColumn();
                            ugCol.Key            = sColKey;
                            ugCol.BaseColumnName = sColKey;
                            ugCol.Header.Caption = sColName;
                            ugCol.Width          = Unit.Pixel(iGridWith);
                            ugCol.DataType       = "System.String";
                            ugCol.AllowUpdate    = AllowUpdate.Yes;
                            ugCol.CellStyle.HorizontalAlign = HorizontalAlign.Left;
                            ugrdInterface.Columns.Add(ugCol);
                        }
                        else
                        {
                            ugCol = new UltraGridColumn();
                            ugCol.Key            = sColKey;
                            ugCol.BaseColumnName = sColKey;
                            ugCol.Header.Caption = sColName;
                            ugCol.Width          = Unit.Pixel(iGridWith);
                            ugCol.AllowUpdate    = AllowUpdate.Yes;
                            ugCol.DataType       = "System.Double";
                            ugCol.Format         = "#,###,###,###,###,###,###,##0"+this.GetFormatPoints(iDPoints);
                            ugCol.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                            ugrdInterface.Columns.Add(ugCol);                            
                        }
                    }
                }
            }
        }

        string sRtnMsg  = "";
        bool bIsSuccess = false;
        decimal dRtnVal = 0;
        DataSet rDsQry  = objQry.GetInterfaceData(this.IKpiRefID, this.IYMD, out sRtnMsg, out bIsSuccess);

        ugrdInterface.Clear();
        ugrdInterface.DataSource = rDsQry;
        ugrdInterface.DataBind();

        //dRtnVal = objQry.GetInterfaceResultMs(this.IKpiRefID, this.IYMD, out sRtnMsg, out bIsSuccess);
        //txtResult_Ms.Text = (bIsSuccess) ? dRtnVal.ToString() : "0";

        //dRtnVal = objQry.GetInterfaceResultTs(this.IKpiRefID, this.IYMD.Substring(0,4)+"01", this.IYMD, out sRtnMsg, out bIsSuccess);
        //txtResult_Ts.Text = (bIsSuccess) ? dRtnVal.ToString() : "0";
    }

    public void SetChildKpiGrid()
    {
        Biz_Bsc_Kpi_Result objRst = new Biz_Bsc_Kpi_Result();
        DataSet dsChild = objRst.GetChildKpiStatustList(this.IEstTermRefID, this.IKpiRefID, this.IYMD);

        ugrdInterface.Clear();
        if (dsChild.Tables.Count > 0)
        {
            ugrdInterface.DisplayLayout.AutoGenerateColumns = true;
            ugrdInterface.DataSource = dsChild.Tables[0].DefaultView;
            ugrdInterface.DataBind();

            if (ugrdInterface.Columns.Exists("YMD"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("YMD");
                ugc.MergeCells = true;
                ugc.Width      = Unit.Pixel(50);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ugc.Header.Caption = "년월";
            }

            if (ugrdInterface.Columns.Exists("KPI_CODE"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("KPI_CODE");
                ugc.Width      = Unit.Pixel(50);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ugc.Header.Caption = "코드";
            }

            if (ugrdInterface.Columns.Exists("KPI_NAME"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("KPI_NAME");
                ugc.Width = Unit.Pixel(120);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Left;
                ugc.Header.Caption = "지표명";
            }

            if (ugrdInterface.Columns.Exists("KPI_LEVEL"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("KPI_LEVEL");
                ugc.Width = Unit.Pixel(20);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ugc.Header.Caption = "L";
            }

            if (ugrdInterface.Columns.Exists("DEPT_NAME"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("DEPT_NAME");
                ugc.Width = Unit.Pixel(100);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Left;
                ugc.Header.Caption = "부서명";
            }

            if (ugrdInterface.Columns.Exists("CHAMPION_EMP_NAME"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("CHAMPION_EMP_NAME");
                ugc.Width = Unit.Pixel(80);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Left;
                ugc.Header.Caption = "챔피언";
            }

            if (ugrdInterface.Columns.Exists("TARGET_MS"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("TARGET_MS");
                ugc.Width = Unit.Pixel(80);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                ugc.Format = "#,###,###,###,###,###,###,###,##0.####";
                ugc.Header.Caption = "당월목표";
            }

            if (ugrdInterface.Columns.Exists("RESULT_MS"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("RESULT_MS");
                ugc.Width = Unit.Pixel(80);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                ugc.Format = "#,###,###,###,###,###,###,###,##0.####";
                ugc.Header.Caption = "당월실적";
            }

            if (ugrdInterface.Columns.Exists("ARATE_MS"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("ARATE_MS");
                ugc.Width = Unit.Pixel(60);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                ugc.Format = "#,###,###,###,###,###,###,###,##0.##";
                ugc.Header.Caption = "달성율";
            }

            if (ugrdInterface.Columns.Exists("TARGET_TS"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("TARGET_TS");
                ugc.Width = Unit.Pixel(80);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                ugc.Format = "#,###,###,###,###,###,###,###,##0.####";
                ugc.Header.Caption = "누계목표";
            }

            if (ugrdInterface.Columns.Exists("RESULT_TS"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("RESULT_TS");
                ugc.Width = Unit.Pixel(80);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                ugc.Format = "#,###,###,###,###,###,###,###,##0.####";
                ugc.Header.Caption = "누계실적";
            }

            if (ugrdInterface.Columns.Exists("ARATE_TS"))
            {
                UltraGridColumn ugc = ugrdInterface.Columns.FromKey("ARATE_TS");
                ugc.Width = Unit.Pixel(60);
                ugc.CellStyle.HorizontalAlign = HorizontalAlign.Right;
                ugc.Format = "#,###,###,###,###,###,###,###,##0.##";
                ugc.Header.Caption = "달성율";
            }
        }
    }

    public string GetFormatPoints(int iDigit)
    {
        if (iDigit == 0)
        {
            return "";
        }

        string sFormat = ".";
        for (int i = 0; i < iDigit; i++)
        {
            sFormat = sFormat + "#";
        }

        return sFormat;
    }

    protected void ugrdInterface_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    public void ugrdInterface_InitializeRow(object sender, RowEventArgs e)
    {
        if (e.Row.Band.Columns.Exists("ARATE_MS"))
        {
            decimal dRtn = 0;
            if (decimal.TryParse(e.Row.Cells.FromKey("ARATE_MS").Value.ToString(), out dRtn))
            {
                e.Row.Cells.FromKey("ARATE_MS").Value = dRtn;
            }
        }

        if (e.Row.Band.Columns.Exists("ARATE_TS"))
        {
            decimal dRtn = 0;
            if (decimal.TryParse(e.Row.Cells.FromKey("ARATE_TS").Value.ToString(), out dRtn))
            {
                e.Row.Cells.FromKey("ARATE_TS").Value = dRtn;
            }
        }
    }
}
