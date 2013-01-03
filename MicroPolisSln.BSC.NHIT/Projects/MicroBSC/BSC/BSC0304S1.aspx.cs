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

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

public partial class BSC_BSC0304S1 : AppPageBase
{
    private int    _iestterm_ref_id;
    private string _iresult_input_method;
    private string _ikpi_code;
    private string _ikpi_name;
    private string _iemp_name;
    private int    _iest_dept_id;
    private int    _ilogin_id;
    private string _iymd;
    private int    _ithreshold_ref_id;
    private AppPageUtility objNum;
    private int    _iTRow = 0;

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdResultStatus.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

        SetAllTimeTop();

        if (!Page.IsPostBack)
        {
            InitControlValue();
            InitControlEvent();

            SetResultGrid();
        }
    }


    #region 페이지 초기화 함수

    private void SetAllTimeTop()
    {
        objNum = new AppPageUtility(this.Page);
    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group bizBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        DataTable dtGroup = bizBSC.GetIssueGroup(intEstTermId, 0);
        ddlGroup.DataValueField = "GROUP_CODE";
        ddlGroup.DataTextField = "GROUP_NAME";
        ddlGroup.DataSource = dtGroup;
        ddlGroup.DataBind();
        ddlGroup.Items.Insert(0, new ListItem("::선택::", "0"));

        ddlEstYN.Items.Insert(0, new ListItem("::선택::", ""));
        ddlEstYN.Items.Insert(1, new ListItem("대상", "Y"));
        ddlEstYN.Items.Insert(2, new ListItem("비대상", "N"));

        //Biz_EtcCodeInfos objCode = new Biz_EtcCodeInfos();
        //objCode.getResultMethod(ddlResultInput, "", true, 80);
        //objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlResultInput, "", true, 80);
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);
        ddlKpiGroupRefID.Width = Unit.Percentage(99);
        objCode.GetKpiExternalType(ddlExternalType, 0, true, 90);

        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        WebCommon.SetSumTypeDropDownList(ddlSumType, false);
        WebCommon.SetSortTypeDropDownList(ddlOrderType, true);

        this.SetSignalDropDownList(ddlSignal, true);
    }

    private void InitControlEvent()
    {
        txtCntKpi.Style.Add("ime-mode", "disabled");
        txtCntKpi.Style.Add("text-align", "right");
        txtCntKpi.Attributes.Add("onkeydown", "return gfChkInputNum(-1, 0)");
    }

    private void SetPageData()
    {
        _iestterm_ref_id      = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        _iresult_input_method = (ddlResultInput.Items.Count > 0) ? ddlResultInput.SelectedValue : "";
        _ikpi_code            = txtKPICode.Text.Trim();
        _ikpi_name            = txtKPIName.Text.Trim();
        _iemp_name            = txtChamName.Text.Trim();
        _iymd                 = (ddlMonthInfo.Items.Count > 0) ? ddlMonthInfo.SelectedValue :"";
        _ilogin_id            = gUserInfo.Emp_Ref_ID;

        if (ddlSignal.Items.Count > 0)
        {
            _ithreshold_ref_id = (ddlSignal.SelectedValue=="") ? 0 : PageUtility.GetIntByValueDropDownList(ddlSignal);
        }
    }

    #endregion

    #region 내부함수

    private void SetSignalDropDownList(System.Web.UI.WebControls.DropDownList ddList, bool isDefalutText)
    {
        WebCommon.SetSignalDropDownList(ddList, true);
    }

    private void SetResultGrid()
    {

        // 골타겟 관련 입력 버튼 (농협에서 추가)
        string goaltongYN = "N";

        if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
        {
            rdoGoalTong.Visible = true;

            if(rdoGoalTong.SelectedIndex.Equals(1))
                goaltongYN = "Y";
        }

        this.SetPageData();
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds              = objBSC.GetKpiListForResultAnalysisNew(_iestterm_ref_id
                                                                   , _iymd
                                                                   , _iresult_input_method
                                                                   , _ikpi_code
                                                                   , _ikpi_name
                                                                   , _iemp_name
                                                                   , _iest_dept_id
                                                                   , _ithreshold_ref_id
                                                                   ,  PageUtility.GetByValueDropDownList(ddlSumType)
                                                                   , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                                                                   , PageUtility.GetByValueDropDownList(ddlExternalType)
                                                                   , PageUtility.GetIntByValueDropDownList(ddlGroup)
                                                                   , PageUtility.GetByValueDropDownList(ddlEstYN)
                                                                   , goaltongYN);


        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Columns.Add("RANK", typeof(int));
            ds.Tables[0].Columns.Add("SORT_TYPE", typeof(string));

            DataTable dataTable = null;

            // 순위정렬 성격에 따라 처리 내용
            if (ddlOrderType.SelectedValue == "H")
            {
                dataTable = PageUtility.FilterSortData(ds.Tables[0], "", "ACHIEVE_RATE_DIFF DESC");
                SetRowNum(dataTable, "H");
            }
            else if (ddlOrderType.SelectedValue == "L")
            {
                dataTable = PageUtility.FilterSortData(ds.Tables[0], "", "ACHIEVE_RATE_DIFF ASC");
                SetRowNum(dataTable, "L");
            }
            else if (ddlOrderType.SelectedValue == "HL")
            {
                DataTable dataTable1 = PageUtility.FilterSortData(ds.Tables[0], "", "ACHIEVE_RATE_DIFF DESC");
                SetRowNum(dataTable1, "H");

                if (!txtCntKpi.Text.Equals(string.Empty))
                {
                    DeleteExtraRowsByRowNum(dataTable1, int.Parse(txtCntKpi.Text));
                }

                DataTable dataTable2 = PageUtility.FilterSortData(ds.Tables[0], "", "ACHIEVE_RATE_DIFF ASC");
                SetRowNum(dataTable2, "L");

                if (!txtCntKpi.Text.Equals(string.Empty))
                {
                    DeleteExtraRowsByRowNum(dataTable2, int.Parse(txtCntKpi.Text));
                }

                dataTable1.Merge(dataTable2);
                dataTable = dataTable1;
            }
            else if (ddlOrderType.SelectedValue == "")
            {
                dataTable = ds.Tables[0];
            }

            // DataRow 삭제
            if (!txtCntKpi.Text.Equals(string.Empty) && ddlOrderType.SelectedValue != "HL")
            {
                DeleteExtraRowsByRowNum(dataTable, int.Parse(txtCntKpi.Text));
            }

            ugrdResultStatus.Clear();
            ugrdResultStatus.DataSource = dataTable;
            ugrdResultStatus.DataBind();
        }
        else
        {
            ugrdResultStatus.Clear();
            ugrdResultStatus.DataSource = ds.Tables[0];
            ugrdResultStatus.DataBind();

        }
    }

    private void DeleteExtraRowsByRowNum(DataTable dataTable, int deleteRowNum) 
    {
        if (dataTable.Rows.Count < deleteRowNum)
            return;

        for (int i = 0; i < dataTable.Rows.Count; i++) 
        {
            if (i >= deleteRowNum)
                dataTable.Rows[i].Delete();
        }

        dataTable.AcceptChanges();
    }

    private void SetRowNum(DataTable dataTable, string sort_type) 
    {
        for (int i = 0; i < dataTable.Rows.Count; i++) 
        {
            dataTable.Rows[i]["RANK"]       = i + 1;
            dataTable.Rows[i]["SORT_TYPE"]  = sort_type;
        }

        dataTable.AcceptChanges();
    }

    /// <summary>
    /// 엑셀출력
    /// </summary>
    private void PrintFormGrid()
    {
        //this.IPrintType = "XLS";
        //this.SetDeptScoreCard();
        string strCurDate = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString().PadRight(2, '0') + DateTime.Now.Minute.ToString().PadRight(2, '0') + DateTime.Now.Second.ToString().PadRight(2, '0');

        ugrdEEP.ExcelStartRow = 7;
        ugrdEEP.ExportMode = ExportMode.Download;
        ugrdEEP.DownloadName = "KPI LIST_" + strCurDate + ".xls";
        ugrdEEP.WorksheetName = "유형별KPI분석";
        ugrdEEP.Export(ugrdResultStatus);
        //this.IPrintType = "MONITOR";
        //ugrdScoreCardForPrint.Clear();
    }
    #endregion

    #region 서버이벤트
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetResultGrid();
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintFormGrid();
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermInfo.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가년월 : " + ddlMonthInfo.SelectedItem.Text;
        //e.CurrentWorksheet.Rows[2].Cells[0].Value = "평가조직 : " + lblDeptName.Text;
        //e.CurrentWorksheet.Rows[3].Cells[0].Value = "평가점수 : " + lblTotalScore.Text;
        //e.CurrentWorksheet.Rows[4].Cells[0].Value = "조직비젼 : " + lblDeptVision.Text;
        //e.CurrentWorksheet.Rows[5].Cells[0].Value = "BSC Champion : " + lblBSCChampion.Text;

        for (int i = 0; i < 6; i++)
        {
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Navy;
            e.CurrentWorksheet.Rows[i].Cells[0].CellFormat.Font.Height = 250;
            e.CurrentWorksheet.Rows[i].Height = 400;
        }
    }

    protected void ugrdEEP_CellExporting(object sender, CellExportingEventArgs e)
    {
        if (e.GridRow != null && e.GridColumn.Key == "CHECK_YN")
        {
            e.Value = e.GridRow.Cells.FromKey("CHECK_YN_CODE").Value; 
        }

        if (e.GridRow != null && e.GridColumn.Key == "SIGNAL_IMAGE")
        {
            e.Value = "";
        }

        if (e.GridRow != null && e.GridColumn.Key == "TREND")
        {
            e.Value = e.GridRow.Cells.FromKey("TREND_CODE").Value;
        }
    }

    protected void ugrdResultStatus_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        if (drw["CHECK_YN"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        string strTrend = e.Row.Cells.FromKey("TREND").Value.ToString();

        switch (strTrend)
        {
            case "UP":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_e_up.gif'>"; ;
                break;
            case "DOWN":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_b_down.gif'>"; ;
                break;
            case "FLAT":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_m.gif'>"; ;
                break;
            default:
                break;
        }

        e.Row.Cells.FromKey("SIGNAL_IMAGE").Value   = "<div align=center><img src='../images/" + e.Row.Cells.FromKey("SIGNAL_IMAGE").Value.ToString() + "'></div>";

        if (drw["SORT_TYPE"].ToString() == "H")
        {
            e.Row.Cells.FromKey("RANK").Style.BackColor = System.Drawing.Color.FromName("#CEE2F4");
        }
        else if (drw["SORT_TYPE"].ToString() == "L")
        {
            e.Row.Cells.FromKey("RANK").Style.BackColor = System.Drawing.Color.FromName("#FFE0E0");
        }

        // 골타겟 관련 입력 버튼 (농협에서 추가)
        string goaltongYN = "N";

        if (PageUtility.GetAppConfig("GOALTONG_YN").Equals("Y"))
        {
            if (rdoGoalTong.SelectedIndex.Equals(1))
                goaltongYN = "Y";
        }

        string strURL = "<a href=\"javascript:gfOpenWindow('../BSC/BSC0304S2.aspx?iType=POP&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}&GOALTONG_YN={4}',840,600,'no','no');\" style=\"color:Navy;\">{3}</a>";
        e.Row.Cells.FromKey("KPI_NAME").Text = string.Format(strURL
                                                            , _iestterm_ref_id.ToString()
                                                            , drw["KPI_REF_ID"].ToString()
                                                            , _iymd
                                                            , drw["KPI_NAME"].ToString()
                                                            , goaltongYN);

        _iTRow += 1;

        lblRowCount.Text = _iTRow.ToString();

        double ACHIEVE_RATE = DataTypeUtility.GetToDouble(DataTypeUtility.GetValue(e.Row.Cells.FromKey("ACHIEVE_RATE")));
        e.Row.Cells.FromKey("ACHIEVE_RATE").Value = ACHIEVE_RATE;

    }

    protected void ugrdResultStatus_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (!ddlOrderType.SelectedValue.Equals(""))
        {
            e.Layout.Bands[0].Columns.FromKey("RANK").Hidden    = false;
            e.Layout.Bands[0].Columns.FromKey("KPI_NAME").Width = 140;
        }
        else 
        {
            e.Layout.Bands[0].Columns.FromKey("RANK").Hidden    = true;
            e.Layout.Bands[0].Columns.FromKey("KPI_NAME").Width = 170;
        }
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        this.SetResultGrid();
    }
    #endregion
}
