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

using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;

public partial class PRJ_PRJ0101S3 : PrjPageBase
{
    private int _prjNameCount = 0;

    private int _iestTermInfo;
    private int _iestDeptRefID;
    private string _iprjType;
    private string _iprjCode;
    private string _iprjName;

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetFormInit();
        }
      
        ltrScript.Text = "";
    }

    #region 내부 함수
    public void SetFormInit()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);

        Biz_Com_Code_Info codeinfo = new Biz_Com_Code_Info();
        codeinfo.GetProjectType(ddlPrjType, "", false, 120);
    }

    //AddColumn(ugrdPrjList,"부서명","DEPT_NAME","DEPT_NAME",false,true);
    private void AddColumn(  UltraWebGrid grid
                           , string caption
                           , string key
                           , string columnName
                           , string horizontalAlign
                           , int width
                           , bool isHidden
                           , bool isMergeCells)
    {

        UltraGridColumn column = new UltraGridColumn();

        column.Header.Caption = caption;
        column.Header.Column.Key = key;
        column.Header.Column.BaseColumnName = columnName;
        column.Header.Column.Width = width;
        column.Header.Style.HorizontalAlign = HorizontalAlign.Center;
        column.CellStyle.HorizontalAlign = UltraGridUtility.GetHorizontalAlign(horizontalAlign);
        column.CellStyle.VerticalAlign = VerticalAlign.Top;
        column.DataType = "System.String";
        column.Hidden = isHidden;
        column.MergeCells = isMergeCells;
        grid.Columns.Add(column);
        grid.Bands[0].Columns.Add(column);
    }

    private void CheckBind(UltraWebGrid grid)
    {
        int EsttermRefID;
        int kpiRefID;
        int prjRefID;

        foreach (UltraGridRow row in grid.Rows)
        {
            EsttermRefID = DataTypeUtility.GetToInt32(row.Cells.FromKey("ESTTERM_REF_ID").Value);
            kpiRefID     = DataTypeUtility.GetToInt32(row.Cells.FromKey("KPI_REF_ID").Value);
            Biz_Bsc_Kpi_Prj objKpiPrj = new Biz_Bsc_Kpi_Prj();

            foreach (UltraGridColumn col in grid.Columns)
            {
                try
                {
                    prjRefID = DataTypeUtility.GetToInt32(col.Header.Column.Key);
                }
                catch
                {
                    prjRefID = 0;
                }

                if (prjRefID != 0)
                {
                    DataTable dt = objKpiPrj.GetOneList(EsttermRefID
                                       , kpiRefID
                                       , prjRefID).Tables[0];

                    if (dt.Rows.Count == 0 || dt.Rows.Count > 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (DataTypeUtility.GetToInt32(dt.Rows[0]["KPI_REF_ID"]) == kpiRefID
                            && DataTypeUtility.GetToInt32(dt.Rows[0]["PRJ_REF_ID"]) == prjRefID)
                        {
                            row.Cells.FromKey(col.Header.Column.Key).Value = "<img src='../images/checkbox.gif' border='0' width='15px' height='15px' valign='middle'>";
                           // row.Cells.FromKey(col.Header.Column.Key).Value = "V";
                        }
                    }
                }
            }
        }
    }

    public void SetPrjList()
    {
        //그리드 컬럼생성
        InitializeGrid(ugrdPrjList);

        ugrdPrjList.DisplayLayout.AllowColSizingDefault = AllowSizing.Free;

        //컬럼고정
        ugrdPrjList.DisplayLayout.UseFixedHeaders = true;

        ugrdPrjList.Columns.FromKey("DEPT_NAME").Header.Fixed = true;
        ugrdPrjList.Columns.FromKey("KPI_NAME").Header.Fixed = true;

        Biz_Bsc_Kpi_Prj objKpiPrj = new Biz_Bsc_Kpi_Prj();

        _iestTermInfo = WebUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iestDeptRefID = WebUtility.GetIntByValueDropDownList(ddlEstDept);
        _iprjType = WebUtility.GetByValueDropDownList(ddlPrjType);
        _iprjCode = txtPrjCode.Text.Trim();
        _iprjName = txtPrjName.Text.Trim();

        DataTable rDt = objKpiPrj.GetTotalKpiPrjList(_iestTermInfo
                                    , 0
                                    , 0
                                    , _iestDeptRefID
                                    , _iprjType
                                    , _iprjCode
                                    , _iprjName
                                    , gUserInfo.Emp_Ref_ID);

        ugrdPrjList.Clear();
        ugrdPrjList.DataSource = rDt;
        ugrdPrjList.DataBind();

        lblRowCount.Text =  rDt.Rows.Count.ToString();

        if (rDt.Rows.Count > 0)
        {
            //지표와프로젝트연결
            CheckBind(ugrdPrjList);

            GridDoLayout(ugrdPrjList);
        }
    }

    private void GridDoLayout(UltraWebGrid grid)
    {
        Biz_Prj_Info objPrjInfo = new Biz_Prj_Info();

        _iprjType = WebUtility.GetByValueDropDownList(ddlPrjType);
        _iprjCode = txtPrjCode.Text.Trim();
        _iprjName = txtPrjName.Text.Trim();

        DataTable dt = objPrjInfo.GetTotalFootInfo(_iprjCode
                                                    ,_iprjName
                                                    ,_iprjType).Tables[0];

        UltraGridRow row = new UltraGridRow();
        grid.Rows.Add(row);
        UltraGridRow row2 = new UltraGridRow();
        grid.Rows.Add(row2);
        UltraGridRow row3 = new UltraGridRow();
        grid.Rows.Add(row3);
        
        row.Cells.FromKey("KPI_NAME").Value  = "<B>소요예산 : </B>";
        row2.Cells.FromKey("KPI_NAME").Value = "<B>집행현황 : </B>";
        row3.Cells.FromKey("KPI_NAME").Value = "<B>진행율(%): </B>";

        foreach (UltraGridColumn col in grid.Columns)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (col.Header.Column.Key == dr["PRJ_REF_ID"].ToString())
                {
                    double dTotalBudget = DataTypeUtility.GetToDouble(dr["TOTAL_BUDGET"]);
                    row.Cells.FromKey(col.Header.Column.Key).Value = dTotalBudget.ToString("###,##0.#0");

                    double dExecAmount = DataTypeUtility.GetToDouble(dr["EXEC_AMOUNT"]);
                    row2.Cells.FromKey(col.Header.Column.Key).Value = dExecAmount.ToString("###,##0.#0");

                    double dTotalRate = DataTypeUtility.GetToDouble(dr["RATE"]);
                    row3.Cells.FromKey(col.Header.Column.Key).Value = dTotalRate.ToString("##0.#0");
                }
            }
        }
    }

    private void InitializeGrid(UltraWebGrid grid)
    {
        Biz_Prj_Info objPrjInfo = new Biz_Prj_Info();
        objPrjInfo.IPrj_Code = this.txtPrjCode.Text.Trim();
        objPrjInfo.IPrj_Name = this.txtPrjName.Text.Trim();
        objPrjInfo.IPrj_Type = WebUtility.GetByValueDropDownList(ddlPrjType);

        DataTable dt = objPrjInfo.GetList(objPrjInfo.IPrj_Code
                          , objPrjInfo.IPrj_Name
                          , 0
                          , ""
                          , EMP_REF_ID
                          , objPrjInfo.IPrj_Type).Tables[0];

        _prjNameCount = dt.Rows.Count;

        grid.Columns.Clear();

        AddColumn(ugrdPrjList
            , "ESTTERM_REF_ID"
            , "ESTTERM_REF_ID"
            , "ESTTERM_REF_ID"
            , "Left"
            , 100
            , true
            , false);

        AddColumn(ugrdPrjList
            , "DEPT_REF_ID"
            , "DEPT_REF_ID"
            , "DEPT_REF_ID"
            , "Left"
            , 100
            , true
            , false);

        AddColumn(ugrdPrjList
            , "KPI_REF_ID"
            , "KPI_REF_ID"
            , "KPI_REF_ID"
            , "Left"
            , 100
            , true
            , false);

        AddColumn(ugrdPrjList
            , "부서명"
            , "DEPT_NAME"
            , "DEPT_NAME"
            , "Left"
            , 120
            , false
            , true);

        AddColumn(ugrdPrjList
            , "지표명"
            , "KPI_NAME"
            , "KPI_NAME"
            , "Left"
            , 120
            , false
            , true);

        // 사업명 컬럼 추가
        foreach (DataRow row in dt.Rows)
        {
            AddColumn(ugrdPrjList
                , row["PRJ_NAME"].ToString()
                , row["PRJ_REF_ID"].ToString()
                , row["PRJ_REF_ID"].ToString()
                , "Center"
                , 150
                , false, false);
        }
    }


    #endregion

    #region Event

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        SetPrjList();
    }
    
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetPrjList();
    }

    protected void ugrdPrjList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        e.Row.Cells.FromKey("KPI_NAME").Value = string.Format("<a href=\"#null\" onclick=\"openKpiInfo('{0}','{1}');\">{2}</a>"
                                                                                        , this.ddlEstTermInfo.SelectedValue.ToString()
                                                                                        , dr["KPI_REF_ID"]
                                                                                        , dr["KPI_NAME"]);
    
    }
    protected void ugrdPrjList_InitializeLayout(object sender, LayoutEventArgs e)
    {
       

      


    }

    #endregion

    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName = "PRJ" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName = "PRJ_KPI";

        uGridExcelExporter.Export(ugrdPrjList);
    }
}
