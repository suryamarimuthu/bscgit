using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.Documents.Excel;

using Syncfusion.XlsIO;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Biz;

public partial class EST_EST0901M1 : EstPageBase
{
    #region 변수선언
    private int _iestterm_ref_id        = 0;
    private string _iymd                = "";
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.InitControlValue();
            this.SetResultListGrid();
        }
        ltrScript.Text = "";
    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        this.SetResultListGrid();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetResultListGrid();
    }

    #region 내부함수
    public void SetResultListGrid()
    {
        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");

        DataTable _estData1 = new DataTable();
        DataTable _estData2 = new DataTable();
        Biz_Datas est_data = new Biz_Datas();
        
        _estData1 = est_data.GetPersonEavluation(COMP_ID, _iestterm_ref_id, _iymd).Tables[0];
        _estData1.TableName = "BSC_PERSON_EVALUATION";
        _estData2 = est_data.GetPersonEavluationPoint(COMP_ID, _iestterm_ref_id, _iymd).Tables[0];
        _estData2.TableName = "BSC_DEPT_EST_POINT";

        if (_estData1.Rows.Count > 0 && _estData2.Rows.Count > 1)
        {
            DataRow[] _setRow;
            foreach (DataRow _pointRow in _estData1.Rows)
            {
                _setRow = _estData2.Select("EST_DEPT_REF_ID = " + _pointRow["EST_DEPT_REF_ID"]);
                if (_setRow.Length == 1)
                    _pointRow["ORGANIZATION_POINT"] = _setRow[0]["ORGANIZATION_POINT"];
                else
                    _pointRow["ORGANIZATION_POINT"] = 0;
            }
            _estData1.AcceptChanges();
        }

        ugrdResultTotal.DataSource = _estData1;
        ugrdResultTotal.DataBind();
    }
    #endregion

    #region 서버이벤트

    protected void ugrdResultTotal_InitializeRow(object sender, RowEventArgs e)
    {
        
    }

    protected void ugrdResultTotal_InitializeLayout(object sender, LayoutEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
        }

        // 단일 헤더 합침
        ch = e.Layout.Bands[0].Columns.FromKey("EMP_REF_ID").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("EST_DEPT_REF_ID").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("POS_CLS_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("DEPT_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("POS_GRP_ID").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("POS_GRP_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("EMP_CODE").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("EMP_NAME").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = e.Layout.Bands[0].Columns.FromKey("WEIGHT_SUM").Header;
        ch.RowLayoutColumnInfo.SpanY = 2;
        ch.RowLayoutColumnInfo.OriginY = 0;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "조직";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "개인";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 7;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "목표1";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 9;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "목표2";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 11;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "목표3";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 13;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
    }
    #endregion

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");

        Biz_Datas est_data = new Biz_Datas();
        DataSet _dataSet = est_data.GetEvaluationDataScheme();
        DataTable _dataTable = _dataSet.Tables[0];
        DataTable _dataTable2 = _dataSet.Tables[1];
        DataTable _dataTable3 = est_data.GetEvaluationScoreInfo(_iestterm_ref_id);

        _dataTable = UltraGridUtility.GetDataTableByAllValue(ugrdResultTotal
                                                        , new string[] { "EMP_REF_ID", "EMP_CODE"
                                                            , "ORGANIZATION_POINT", "ORGANIZATION_WEIGHT"
                                                            , "APPRAISAL_POINT", "APPRAISAL_WEIGHT"
                                                            , "OTHERS1_POINT", "OTHERS1_WEIGHT"
                                                            , "OTHERS2_POINT", "OTHERS2_WEIGHT"
                                                            , "OTHERS3_POINT", "OTHERS3_WEIGHT"
                                                            , "WEIGHT_SUM", "POINT_SUM"
                                                            , "POS_GRP_ID"}
                                                        , _dataTable);
        _dataTable = DataTypeUtility.FilterSortDataTable(_dataTable, "EMP_REF_ID IS NOT NULL", "POS_GRP_ID ASC");

        string _pos_grp_id = "";
        double _sum = 0.0;
        double _sum2 = 0.0;
        int _n = 0;
        double _sumPoint = 0.0;
        double _mean = 0.0;
        double _stdv = 0.0;

        for (int i = 0; i < _dataTable.Rows.Count; i++)
        {
            if (_dataTable.Rows[i]["ORGANIZATION_POINT"] == DBNull.Value) _dataTable.Rows[i]["ORGANIZATION_POINT"] = 0;
            if (_dataTable.Rows[i]["ORGANIZATION_WEIGHT"] == DBNull.Value) _dataTable.Rows[i]["ORGANIZATION_WEIGHT"] = 0;
            if (_dataTable.Rows[i]["APPRAISAL_POINT"] == DBNull.Value) _dataTable.Rows[i]["APPRAISAL_POINT"] = 0;
            if (_dataTable.Rows[i]["APPRAISAL_WEIGHT"] == DBNull.Value) _dataTable.Rows[i]["APPRAISAL_WEIGHT"] = 0;
            if (_dataTable.Rows[i]["OTHERS1_POINT"] == DBNull.Value) _dataTable.Rows[i]["OTHERS1_POINT"] = 0;
            if (_dataTable.Rows[i]["OTHERS1_WEIGHT"] == DBNull.Value) _dataTable.Rows[i]["OTHERS1_WEIGHT"] = 0;
            if (_dataTable.Rows[i]["OTHERS2_POINT"] == DBNull.Value) _dataTable.Rows[i]["OTHERS2_POINT"] = 0;
            if (_dataTable.Rows[i]["OTHERS2_WEIGHT"] == DBNull.Value) _dataTable.Rows[i]["OTHERS2_WEIGHT"] = 0;
            if (_dataTable.Rows[i]["OTHERS3_POINT"] == DBNull.Value) _dataTable.Rows[i]["OTHERS3_POINT"] = 0;
            if (_dataTable.Rows[i]["OTHERS3_WEIGHT"] == DBNull.Value) _dataTable.Rows[i]["OTHERS3_WEIGHT"] = 0;
            
            _dataTable.Rows[i]["ESTTERM_REF_ID"] = _iestterm_ref_id;
            _dataTable.Rows[i]["YY"] = _iymd.Substring(0, 4);
            _dataTable.Rows[i]["DD"] = _iymd.Substring(4, 2);
            _sumPoint = Convert.ToDouble(_dataTable.Rows[i]["ORGANIZATION_POINT"]) * Convert.ToDouble(_dataTable.Rows[i]["ORGANIZATION_WEIGHT"]) / 100;
            _sumPoint += Convert.ToDouble(_dataTable.Rows[i]["APPRAISAL_POINT"]) * Convert.ToDouble(_dataTable.Rows[i]["APPRAISAL_WEIGHT"]) / 100;
            _sumPoint += Convert.ToDouble(_dataTable.Rows[i]["OTHERS1_POINT"]) * Convert.ToDouble(_dataTable.Rows[i]["OTHERS1_WEIGHT"]) / 100;
            _sumPoint += Convert.ToDouble(_dataTable.Rows[i]["OTHERS2_POINT"]) * Convert.ToDouble(_dataTable.Rows[i]["OTHERS2_WEIGHT"]) / 100;
            _sumPoint += Convert.ToDouble(_dataTable.Rows[i]["OTHERS3_POINT"]) * Convert.ToDouble(_dataTable.Rows[i]["OTHERS3_WEIGHT"]) / 100;
            _dataTable.Rows[i]["POINT_SUM"] = _sumPoint;
            _dataTable.Rows[i]["CREATE_DATE"] = DateTime.Now;
            _dataTable.Rows[i]["CREATE_USER"] = EMP_REF_ID;
            _dataTable.Rows[i]["UPDATE_DATE"] = DateTime.Now;
            _dataTable.Rows[i]["UPDATE_USER"] = EMP_REF_ID;
            
            if (i == 0)
            {
                _pos_grp_id = _dataTable.Rows[i]["POS_GRP_ID"].ToString();
                _sum = DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]);
                _sum2 = DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]) * DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]);
                _n = 1;
            }
            else if (_pos_grp_id == _dataTable.Rows[i]["POS_GRP_ID"].ToString())
            {
                _sum += DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]);
                _sum2 += DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]) * DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]);
                _n += 1;
            }
            else if (_pos_grp_id != _dataTable.Rows[i]["POS_GRP_ID"].ToString())
            {
                _stdv = Math.Sqrt(((double)_n * _sum2 - _sum * _sum) / ((double)_n * (double)(_n)));
                _mean = _sum / (double)_n;

                DataRow _newRow = _dataTable2.NewRow();
                _newRow["ESTTERM_REF_ID"] = _iestterm_ref_id;
                _newRow["YY"] = _iymd.Substring(0, 4);
                _newRow["DD"] = _iymd.Substring(4, 2);
                _newRow["POS_GRP_ID"] = _pos_grp_id;
                _newRow["GROUP_MEAN"] = _mean;
                _newRow["STANDARD_DEVIATION"] = _stdv;
                _newRow["CREATE_DATE"] = DateTime.Now;
                _newRow["CREATE_USER"] = EMP_REF_ID;
                _newRow["UPDATE_DATE"] = DateTime.Now;
                _newRow["UPDATE_USER"] = EMP_REF_ID;
                _dataTable2.Rows.Add(_newRow);

                _pos_grp_id = _dataTable.Rows[i]["POS_GRP_ID"].ToString();
                _sum = DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]);
                _sum2 = DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]) * DataTypeUtility.GetToDouble(_dataTable.Rows[i]["POINT_SUM"]);
                _n = 1;
            }
            if (i + 1 == _dataTable.Rows.Count)
            {
                _stdv = Math.Sqrt(((double)_n * _sum2 - _sum * _sum) / ((double)_n * (double)(_n)));
                _mean = _sum / (double)_n;

                DataRow _newRow = _dataTable2.NewRow();
                _newRow["ESTTERM_REF_ID"] = _iestterm_ref_id;
                _newRow["YY"] = _iymd.Substring(0, 4);
                _newRow["DD"] = _iymd.Substring(4, 2);
                _newRow["POS_GRP_ID"] = _pos_grp_id;
                _newRow["GROUP_MEAN"] = _mean;
                _newRow["STANDARD_DEVIATION"] = _stdv;
                _newRow["CREATE_DATE"] = DateTime.Now;
                _newRow["CREATE_USER"] = EMP_REF_ID;
                _newRow["UPDATE_DATE"] = DateTime.Now;
                _newRow["UPDATE_USER"] = EMP_REF_ID;
                _dataTable2.Rows.Add(_newRow);
            }
        }

        foreach (DataRow _drv in _dataTable2.Rows)
        {
            DataRow[] _dr = _dataTable.Select("POS_GRP_ID = '" + _drv["POS_GRP_ID"].ToString() + "'");
            if (_dr.Length > 0)
            {
                for (int i = 0; i < _dr.Length; i++)
                {
                    if (DataTypeUtility.GetToDouble(_drv["STANDARD_DEVIATION"]) == 0)
                        _dr[i]["STANDARD_SCORE"] = 0;
                    else
                        _dr[i]["STANDARD_SCORE"] = (DataTypeUtility.GetToDouble(_dr[i]["POINT_SUM"])
                            - DataTypeUtility.GetToDouble(_drv["GROUP_MEAN"]))
                            / DataTypeUtility.GetToDouble(_drv["STANDARD_DEVIATION"]);
                    DataRow[] _stdRat = 
                        _dataTable3.Select(DataTypeUtility.GetToDouble(_dr[i]["STANDARD_SCORE"]) + " > MIN_VALUE AND " 
                        + DataTypeUtility.GetToDouble(_dr[i]["STANDARD_SCORE"]) + " <= MAX_VALUE");
                    if (_stdRat.Length > 0)
                        _dr[i]["STANDARD_RATING"] = _stdRat[0]["SCORE_CODE"].ToString();
                    else
                        _dr[i]["STANDARD_RATING"] = "U";
                }
            }
        }

        bool isOK = est_data.SaveDataPersonEvaluation(_dataTable, true);

        if (isOK)
        {
            isOK = est_data.SaveDataGroupEvaluation(_dataTable2, true);
            if (isOK)
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장하였습니다.");
                this.SetResultListGrid();
            }
            else
                ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }

    protected void iBtnExcelImport_Click(object sender, ImageClickEventArgs e)
    {
        if (fldExcelFile.PostedFile.FileName.Equals(""))
        {
            // 업로드하실 엑셀파일을 선택해주세요.
            ltrScript.Text = JSHelper.GetAlertScript("업로드하실 엑셀파일을 선택해주세요.", false);
            return;
        }

        System.IO.Stream fileStream = null;

        try
        {
            fileStream = fldExcelFile.PostedFile.InputStream;
        }
        catch (Exception ex)
        {
            // 업로드 중 오류가 발생하였습니다.
            ltrScript.Text = JSHelper.GetAlertScript("업로드 중 오류가 발생하였습니다.", false);
            return;
        }

        ExcelEngine excelEngine = new ExcelEngine();
        IApplication application = excelEngine.Excel;
        //application.UseNativeStorage = false; //user sync version 8...
        
        IWorkbook workbook = null;

        workbook = excelEngine.Excel.Workbooks.Open(fldExcelFile.PostedFile.InputStream);

        /*
        try
        {
            workbook = excelEngine.Excel.Workbooks.Open(fldExcelFile.PostedFile.InputStream);
        }
        catch (Exception ex)
        {
            // 엑셀형식의 파일이 아닙니다.
            Response.Write(ex.Message);
            ltrScript.Text = JSHelper.GetAlertScript("엑셀형식의 파일이 아닙니다.", false);
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
            return;
        }
        */
        IWorksheet sheet = workbook.Worksheets[0];

        if (sheet.Rows.Length < 3)
        {
            // 빈 엑셀 파일입니다.
            ltrScript.Text = JSHelper.GetAlertScript("빈 엑셀 파일입니다.", false);
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
            return;
        }

        try
        {

            for (int i = 0; i < sheet.Columns.Length; i++)
            {
                string columnKey = string.Format("{0}2", DataTypeUtility.GetInt32ToAlphabet(i + 1));
                sheet.Range[columnKey].Text = sheet.Range[columnKey].AddComment().Text;
            }

            DataTable ExcelUnitUploadData = new DataTable();
            ExcelUnitUploadData.Columns.Add("EMP_REF_ID", typeof(int));
            ExcelUnitUploadData.Columns.Add("EST_DEPT_REF_ID", typeof(string));
            ExcelUnitUploadData.Columns.Add("DEPT_NAME", typeof(string));
            ExcelUnitUploadData.Columns.Add("POS_CLS_ID", typeof(string));
            ExcelUnitUploadData.Columns.Add("POS_CLS_NAME", typeof(string));
            ExcelUnitUploadData.Columns.Add("POS_GRP_ID", typeof(string));
            ExcelUnitUploadData.Columns.Add("POS_GRP_NAME", typeof(string));
            ExcelUnitUploadData.Columns.Add("EMP_CODE", typeof(string));
            ExcelUnitUploadData.Columns.Add("EMP_NAME", typeof(string));
            ExcelUnitUploadData.Columns.Add("ORGANIZATION_POINT", typeof(double));
            ExcelUnitUploadData.Columns.Add("ORGANIZATION_WEIGHT", typeof(int));
            ExcelUnitUploadData.Columns.Add("APPRAISAL_POINT", typeof(double));
            ExcelUnitUploadData.Columns.Add("APPRAISAL_WEIGHT", typeof(int));
            ExcelUnitUploadData.Columns.Add("OTHERS1_POINT", typeof(double));
            ExcelUnitUploadData.Columns.Add("OTHERS1_WEIGHT", typeof(int));
            ExcelUnitUploadData.Columns.Add("OTHERS2_POINT", typeof(double));
            ExcelUnitUploadData.Columns.Add("OTHERS2_WEIGHT", typeof(int));
            ExcelUnitUploadData.Columns.Add("OTHERS3_POINT", typeof(double));
            ExcelUnitUploadData.Columns.Add("OTHERS3_WEIGHT", typeof(int));
            ExcelUnitUploadData.Columns.Add("WEIGHT_SUM", typeof(int));
            ExcelUnitUploadData.Columns.Add("POINT_SUM", typeof(double));

            DataTable _tmpTable = sheet.ExportDataTable(2, 1, sheet.Rows.Length, 19, ExcelExportDataTableOptions.ColumnNames | ExcelExportDataTableOptions.ComputedFormulaValues);

            _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");

            DataTable _estData1 = new DataTable();
            DataTable _estData2 = new DataTable();
            Biz_Datas est_data = new Biz_Datas();

            _estData1 = est_data.GetPersonEavluation(COMP_ID, _iestterm_ref_id, _iymd).Tables[0];
            _estData2 = est_data.GetPersonEavluationPoint(COMP_ID, _iestterm_ref_id, _iymd).Tables[0];

            if (_tmpTable.Rows.Count > 1 && _estData2.Rows.Count > 1)
            {
                DataRow[] _setRow;
                DataRow[] _setRow2;
                foreach (DataRow _pointRow in _tmpTable.Rows)
                {
                    if (_pointRow["EST_DEPT_REF_ID"] != null && !_pointRow["EST_DEPT_REF_ID"].ToString().Equals(""))
                    {
                        _setRow = _estData2.Select("EST_DEPT_REF_ID = " + _pointRow["EST_DEPT_REF_ID"]);
                        if (_setRow.Length == 1)
                            _pointRow["ORGANIZATION_POINT"] = _setRow[0]["ORGANIZATION_POINT"];
                        else
                            _pointRow["ORGANIZATION_POINT"] = 0;

                        _setRow2 = _estData1.Select("EMP_REF_ID = " + _pointRow["EMP_REF_ID"]);
                        if (_setRow2.Length == 1)
                            _pointRow["POS_GRP_ID"] = _setRow2[0]["POS_GRP_ID"].ToString();
                    }
                }
                _tmpTable.AcceptChanges();
            }

            foreach (DataRow _dr in _tmpTable.Rows)
            {
                if (_dr["EST_DEPT_REF_ID"] != null && !_dr["EST_DEPT_REF_ID"].ToString().Equals(""))
                {
                    DataRow _drMain = ExcelUnitUploadData.NewRow();
                    _drMain["EMP_REF_ID"] = _dr["EMP_REF_ID"].ToString();
                    _drMain["EST_DEPT_REF_ID"] = _dr["EST_DEPT_REF_ID"].ToString();
                    _drMain["DEPT_NAME"] = _dr["DEPT_NAME"].ToString();
                    _drMain["POS_CLS_ID"] = _dr["POS_CLS_ID"].ToString();
                    _drMain["POS_CLS_NAME"] = _dr["POS_CLS_NAME"].ToString();
                    _drMain["POS_GRP_ID"] = _dr["POS_GRP_ID"].ToString();
                    _drMain["POS_GRP_NAME"] = _dr["POS_GRP_NAME"].ToString();
                    _drMain["EMP_CODE"] = _dr["EMP_CODE"].ToString();
                    _drMain["EMP_NAME"] = _dr["EMP_NAME"].ToString();
                    _drMain["ORGANIZATION_POINT"] = _dr["ORGANIZATION_POINT"].ToString();
                    _drMain["ORGANIZATION_WEIGHT"] = Convert.ToInt32(Convert.ToDouble(_dr["ORGANIZATION_WEIGHT"]));
                    _drMain["APPRAISAL_POINT"] = DataTypeUtility.GetToDouble(_dr["APPRAISAL_POINT"]);
                    _drMain["APPRAISAL_WEIGHT"] = Convert.ToInt32(Convert.ToDouble(_dr["APPRAISAL_WEIGHT"]));
                    _drMain["OTHERS1_POINT"] = DataTypeUtility.GetToDouble(_dr["OTHERS1_POINT"]);
                    _drMain["OTHERS1_WEIGHT"] = Convert.ToInt32(Convert.ToDouble(_dr["OTHERS1_WEIGHT"]));
                    _drMain["OTHERS2_POINT"] = DataTypeUtility.GetToDouble(_dr["OTHERS2_POINT"]);
                    _drMain["OTHERS2_WEIGHT"] = Convert.ToInt32(Convert.ToDouble(_dr["OTHERS2_WEIGHT"]));
                    _drMain["OTHERS3_POINT"] = DataTypeUtility.GetToDouble(_dr["OTHERS3_POINT"]);
                    _drMain["OTHERS3_WEIGHT"] = Convert.ToInt32(Convert.ToDouble(_dr["OTHERS3_WEIGHT"]));
                    _drMain["WEIGHT_SUM"] = Convert.ToInt32(Convert.ToDouble(_dr["ORGANIZATION_WEIGHT"]))
                        + Convert.ToInt32(Convert.ToDouble(_dr["APPRAISAL_WEIGHT"]))
                        + Convert.ToInt32(Convert.ToDouble(_dr["OTHERS1_WEIGHT"]))
                        + Convert.ToInt32(Convert.ToDouble(_dr["OTHERS2_WEIGHT"]))
                        + Convert.ToInt32(Convert.ToDouble(_dr["OTHERS3_WEIGHT"]));
                    _drMain["POINT_SUM"] = DataTypeUtility.GetToDouble(_dr["ORGANIZATION_POINT"])
                        + DataTypeUtility.GetToDouble(_dr["APPRAISAL_POINT"])
                        + DataTypeUtility.GetToDouble(_dr["OTHERS1_POINT"])
                        + DataTypeUtility.GetToDouble(_dr["OTHERS2_POINT"])
                        + DataTypeUtility.GetToDouble(_dr["OTHERS3_POINT"]);
                    ExcelUnitUploadData.Rows.Add(_drMain);
                }
            }
            
            ugrdResultTotal.Clear();
            ugrdResultTotal.DataSource = ExcelUnitUploadData;
            ugrdResultTotal.DataBind();

            foreach (UltraGridRow _ugr in ugrdResultTotal.Rows)
            {
                if (Convert.ToDouble(_ugr.Cells.FromKey("WEIGHT_SUM").Value) != 100)
                    _ugr.Cells.FromKey("WEIGHT_SUM").Style.ForeColor = Color.Red;
            }

            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            ltrScript.Text = JSHelper.GetAlertScript("업로드 중 오류가 발생하였습니다.", false);
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
        }
    }

    private IWorksheet SetGridtoExcelFormat(IWorksheet sheet)
    {
        string format = "_(* #,##0.00_);[red]_(* (#,##0.00);_(* \" 0.00\"_)";
        string formatKRW = "_(* #,##0_);[red]_(* (#,##0);_(* \" 0\"_)";

        int cnt = 15;
        int rowCnt = sheet.Rows.Length;

        for (int rowIDX = 2; rowIDX < rowCnt; rowIDX++)
        {
            for (int i = 5; i < cnt; i++)
            {
                if (i == 5 || i == 7 || i == 9 || i == 11 || i == 13)
                {
                    try
                    {
                        if (sheet.Rows[rowIDX].Cells[i].Value != null)
                        {
                            sheet.Rows[rowIDX].Cells[i].NumberFormat = format;
                        }
                        else
                        {
                            sheet.Rows[rowIDX].Cells[i].Value = "0.00";
                            sheet.Rows[rowIDX].Cells[i].NumberFormat = format;
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                    }
                }
                else
                {
                    try
                    {
                        if (sheet.Rows[rowIDX].Cells[i].Value != null)
                        {
                            sheet.Rows[rowIDX].Cells[i].NumberFormat = formatKRW;
                        }
                        else
                        {
                            sheet.Rows[rowIDX].Cells[i].Value = "0";
                            sheet.Rows[rowIDX].Cells[i].NumberFormat = formatKRW;
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                    }
                }
            }
        }
        return sheet;
    }

    protected void iBtnExcelExport_Click(object sender, ImageClickEventArgs e)
    {
        ExcelEngine excelEngine = new ExcelEngine();
        IApplication application = excelEngine.Excel;
        IWorkbook workbook = application.Workbooks.Create(1);
        IWorksheet sheet = workbook.Worksheets[0];

        try
        {
            for (int i = 1; i < 6; i++)
            {
                sheet.Range[1, i, 2, i].Merge();
                sheet.Range[1, i, 2, i].Text = ugrdResultTotal.Columns[i - 1].Header.Caption;
                sheet.Range[2, i, 2, i].AddComment().Text = ugrdResultTotal.Columns[i - 1].Key;
                sheet.Range[1, i, 2, i].AutofitColumns();
                sheet.Range[1, i, 2, i].CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                sheet.Range[1, i, 2, i].CellStyle.Font.Color = ExcelKnownColors.White;
                sheet.Range[1, i, 2, i].CellStyle.Font.Bold = true;
                sheet.Range[1, i, 2, i].ColumnWidth = 8;
                sheet.Range[1, 1, 2, i].VerticalAlignment = ExcelVAlign.VAlignCenter;
                sheet.Range[1, 1, 2, i].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            }
            for (int i = 16; i < 20; i++)
            {
                sheet.Range[1, i, 2, i].Merge();
                sheet.Range[1, i, 2, i].Text = ugrdResultTotal.Columns[i + 3].Header.Caption;
                sheet.Range[2, i, 2, i].AddComment().Text = ugrdResultTotal.Columns[i + 3].Key;
                sheet.Range[1, i, 2, i].AutofitColumns();
                sheet.Range[1, i, 2, i].CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                sheet.Range[1, i, 2, i].CellStyle.Font.Color = ExcelKnownColors.White;
                sheet.Range[1, i, 2, i].CellStyle.Font.Bold = true;
                sheet.Range[1, i, 2, i].ColumnWidth = 0;
                sheet.Range[1, 1, 2, i].VerticalAlignment = ExcelVAlign.VAlignCenter;
                sheet.Range[1, 1, 2, i].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            }

            for (int i = 6; i < 16; i++)
            {
                if (i == 6 || i == 8 || i == 10 || i == 12 || i == 14)
                {
                    sheet.Range[1, i, 1, i + 1].Merge();
                    if (i == 6)
                        sheet.Range[1, i, 1, i + 1].Text = "조직";
                    else if (i == 8)
                        sheet.Range[1, i, 1, i + 1].Text = "개인";
                    else if (i == 10)
                        sheet.Range[1, i, 1, i + 1].Text = "목표1";
                    else if (i == 12)
                        sheet.Range[1, i, 1, i + 1].Text = "목표2";
                    else if (i == 14)
                        sheet.Range[1, i, 1, i + 1].Text = "목표3";
                    sheet.Range[1, i, 1, i + 1].AutofitColumns();
                    sheet.Range[1, i, 1, i + 1].CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                    sheet.Range[1, i, 1, i + 1].CellStyle.Font.Color = ExcelKnownColors.White;
                    sheet.Range[1, i, 1, i + 1].CellStyle.Font.Bold = true;
                    sheet.Range[1, i, 1, i + 1].VerticalAlignment = ExcelVAlign.VAlignCenter;
                    sheet.Range[1, i, 1, i + 1].HorizontalAlignment = ExcelHAlign.HAlignCenter;
                }
                sheet.Range[2, i, 2, i].Text = ugrdResultTotal.Columns[i - 1].Header.Caption;
                sheet.Range[2, i, 2, i].AddComment().Text = ugrdResultTotal.Columns[i - 1].Key;
                sheet.Range[2, i, 2, i].AutofitColumns();
                sheet.Range[2, i, 2, i].CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                sheet.Range[2, i, 2, i].CellStyle.Font.Color = ExcelKnownColors.White;
                sheet.Range[2, i, 2, i].CellStyle.Font.Bold = true;
                sheet.Range[2, i, 2, i].VerticalAlignment = ExcelVAlign.VAlignCenter;
                sheet.Range[2, i, 2, i].HorizontalAlignment = ExcelHAlign.HAlignCenter;
                sheet.Range[2, i, 2, i].ColumnWidth = 9;
            }

            DataTable dataTable = new DataTable();
            DataRow dataRow = null;

            
            dataTable.Columns.Add("DEPT_NAME", typeof(string));
            dataTable.Columns.Add("POS_CLS_NAME", typeof(string));
            dataTable.Columns.Add("POS_GRP_NAME", typeof(string));
            dataTable.Columns.Add("EMP_CODE", typeof(string));
            dataTable.Columns.Add("EMP_NAME", typeof(string));
            dataTable.Columns.Add("ORGANIZATION_POINT", typeof(double));
            dataTable.Columns.Add("ORGANIZATION_WEIGHT", typeof(int));
            dataTable.Columns.Add("APPRAISAL_POINT", typeof(double));
            dataTable.Columns.Add("APPRAISAL_WEIGHT", typeof(int));
            dataTable.Columns.Add("OTHERS1_POINT", typeof(double));
            dataTable.Columns.Add("OTHERS1_WEIGHT", typeof(int));
            dataTable.Columns.Add("OTHERS2_POINT", typeof(double));
            dataTable.Columns.Add("OTHERS2_WEIGHT", typeof(int));
            dataTable.Columns.Add("OTHERS3_POINT", typeof(double));
            dataTable.Columns.Add("OTHERS3_WEIGHT", typeof(int));
            dataTable.Columns.Add("EMP_REF_ID", typeof(int));
            dataTable.Columns.Add("EST_DEPT_REF_ID", typeof(string));
            dataTable.Columns.Add("POS_CLS_ID", typeof(string));
            dataTable.Columns.Add("POS_GRP_ID", typeof(string));

            UltraGridRow row;
            for (int i = 0; i < ugrdResultTotal.Rows.Count; i++)
            {
                row = ugrdResultTotal.Rows[i];

                dataRow = dataTable.NewRow();
                dataRow["EMP_REF_ID"] = row.Cells.FromKey("EMP_REF_ID").Text;
                dataRow["EST_DEPT_REF_ID"] = row.Cells.FromKey("EST_DEPT_REF_ID").Text;
                dataRow["DEPT_NAME"] = row.Cells.FromKey("DEPT_NAME").Text;
                dataRow["POS_CLS_ID"] = row.Cells.FromKey("POS_CLS_ID").Text;
                dataRow["POS_CLS_NAME"] = row.Cells.FromKey("POS_CLS_NAME").Text;
                dataRow["POS_GRP_ID"] = row.Cells.FromKey("POS_GRP_ID").Text;
                dataRow["POS_GRP_NAME"] = row.Cells.FromKey("POS_GRP_NAME").Text;
                dataRow["EMP_CODE"] = row.Cells.FromKey("EMP_CODE").Text;
                dataRow["EMP_NAME"] = row.Cells.FromKey("EMP_NAME").Text;
                dataRow["ORGANIZATION_POINT"] = row.Cells.FromKey("ORGANIZATION_POINT").Value;
                dataRow["ORGANIZATION_WEIGHT"] = row.Cells.FromKey("ORGANIZATION_WEIGHT").Value;
                dataRow["APPRAISAL_POINT"] = row.Cells.FromKey("APPRAISAL_POINT").Value;
                dataRow["APPRAISAL_WEIGHT"] = row.Cells.FromKey("APPRAISAL_WEIGHT").Value;
                dataRow["OTHERS1_POINT"] = row.Cells.FromKey("OTHERS1_POINT").Value;
                dataRow["OTHERS1_WEIGHT"] = row.Cells.FromKey("OTHERS1_WEIGHT").Value;
                dataRow["OTHERS2_POINT"] = row.Cells.FromKey("OTHERS2_POINT").Value;
                dataRow["OTHERS2_WEIGHT"] = row.Cells.FromKey("OTHERS2_WEIGHT").Value;
                dataRow["OTHERS3_POINT"] = row.Cells.FromKey("OTHERS3_POINT").Value;
                dataRow["OTHERS3_WEIGHT"] = row.Cells.FromKey("OTHERS3_WEIGHT").Value;
                dataTable.Rows.Add(dataRow);
            }

            sheet.ImportDataTable(dataTable, false, 3, 1);
            sheet = SetGridtoExcelFormat(sheet);

            string _filename = "BSC_Person_Evaluation_" + ddlEstTermInfo.SelectedItem.Value + "_" + ddlEstTermMonth.SelectedItem.Value + ".xls";
            workbook.SaveAs(_filename, ExcelSaveType.SaveAsXLS, Response, ExcelDownloadType.PromptDialog);
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
        }
        catch (Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript("다운로드 중 오류가 발생하였습니다.", false);
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
        }
    }
}