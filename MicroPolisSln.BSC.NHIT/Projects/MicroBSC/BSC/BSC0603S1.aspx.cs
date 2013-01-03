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
using Syncfusion.XlsIO;


public partial class BSC_BSC0603S1 : AppPageBase
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

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "U");
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

    public int IEstEmpID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
            {
                ViewState["EST_EMP_ID"] = GetRequestByInt("EST_EMP_ID", 0);
            }

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
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

    string sRtnMsg  = "";
    bool bIsSuccess = false;
    decimal dRtnVal = 0;

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        if (!IsPostBack)
        {
            this.InitForm();
        }
    }

    public void InitForm()
    {
        this.SetInterfaceGrid();
    }

    public void SetInterfaceGrid()
    {
        Biz_Bsc_Kpi_Info objKpi = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        lblKpiCode.Text = objKpi.Ikpi_code;
        lblKpiName.Text = objKpi.Ikpi_name;
        txtCalcFormMs.Text = objKpi.Icalc_form_ms;
        txtCalcFormTs.Text = objKpi.Icalc_form_ts;

        Biz_Bsc_Interface_Kpi_Query objQry = new Biz_Bsc_Interface_Kpi_Query(this.IKpiRefID, "");
        this.IDiCode = objQry.IDicode;
        txtFieldMs.Text = "계산식 : " + objQry.IResult_Field_Ms + "\n" + "조건식 : " + objQry.IResult_Where_Ms;
        txtFieldTs.Text = "계산식 : " + objQry.IResult_Field_Ts + "\n" + "조건식 : " + objQry.IResult_Where_Ts;

        if (this.IDiCode == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("정의된 Interface가 없습니다.", true);
            return;
        }

        Biz_Bsc_Interface_Dicode objCode = new Biz_Bsc_Interface_Dicode(this.IDiCode, gUserInfo.Emp_Ref_ID);
        txtDiCode.Text = objCode.IDicode;
        txtDiName.Text = objCode.IName;

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
                ugCol.Key = "RDTERM";
                ugCol.BaseColumnName = "RDTERM";
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

        sRtnMsg    = "";
        bIsSuccess = false;
        dRtnVal    = 0;
        DataSet rDsQry  = objQry.GetInterfaceData(this.IKpiRefID, this.IYMD, out sRtnMsg, out bIsSuccess);

        ugrdInterface.Clear();
        ugrdInterface.DataSource = rDsQry;
        ugrdInterface.DataBind();

        dRtnVal = objQry.GetInterfaceResultMs(this.IKpiRefID, this.IYMD, out sRtnMsg, out bIsSuccess);
        txtResult_Ms.Text = (bIsSuccess) ? dRtnVal.ToString() : "0";

        dRtnVal = objQry.GetInterfaceResultTs(this.IKpiRefID, this.IYMD.Substring(0,4)+"01", this.IYMD, out sRtnMsg, out bIsSuccess);
        txtResult_Ts.Text = (bIsSuccess) ? dRtnVal.ToString() : "0";
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

    public void ExportExcelFormat()
    {
        
        Biz_Bsc_Interface_Kpi_Query objQry = new Biz_Bsc_Interface_Kpi_Query(this.IKpiRefID, "");
        DataSet rDsQry  = objQry.GetInterfaceData(this.IKpiRefID, this.IYMD, out sRtnMsg, out bIsSuccess);

        int iCntCol = 0;
        if (rDsQry.Tables.Count > 0)
        {
            if (rDsQry.Tables[0].Rows.Count > 0)
            {
                iCntCol = rDsQry.Tables[0].Columns.Count;
            }
            else
            {
                iCntCol = 0;
            }
        }

        ExcelEngine xlsEngine = new ExcelEngine();
        IApplication xlsApp   = xlsEngine.Excel;

        IWorkbook xlsBook     = xlsEngine.Excel.Workbooks.Create(1);
        IWorksheet xlsSheet   = xlsBook.Worksheets[0];

        try
        {
            int iCol = WebCommon.GetExcelColumnCount();

            for (int i = iCol; i > iCntCol; i--)
            {
                xlsSheet.ShowColumn(i, false);
            }

            Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
            string sColNm   = "";
            for (int i = 0; i < iCntCol; i++)
            {
                sColNm   = rDsQry.Tables[0].Columns[i].ColumnName;
                objCol   = new Biz_Bsc_Interface_Column(this.IDiCode, sColNm, gUserInfo.Emp_Ref_ID);

                if (i == 0)
                {
                    xlsSheet.Range[1, i + 1].Text        = sColNm;
                    xlsSheet.Range[2, i + 1].Text        = "발생일자";
                    xlsSheet.Range[2, i + 1].ColumnWidth = 10;
                }
                else
                { 
                    xlsSheet.Range[1, i + 1].Text        = objCol.IColumn_Id;
                    xlsSheet.Range[2, i + 1].Text        = objCol.IColumn_Alias;
                    xlsSheet.Range[2, i + 1].ColumnWidth = (objCol.IGrid_Width/9);
                    xlsSheet.Columns[i].AutofitColumns();
                    xlsSheet.Columns[i].AutofitRows();
                }

                //switch (rDsQry.Tables[0].Columns[i].DataType.Name.ToLower())
                //{
                //    case "decimal":
                //        string sChar  = WebCommon.GetExcelColumnName(i);
                //        string sRange = sChar + "3:" + sChar + "10000";
                //        IDataValidation dvColumn    = xlsSheet.Range[sRange].DataValidation;
                //        xlsSheet.Range[sRange].Text = "";
                //        xlsSheet.Range[sRange].NumberFormat = "#,###,###,###,###,###,###,###,###,###,##0.0######";
                //        xlsSheet.Range[sRange].AutofitColumns();

                //        dvColumn.AllowType          = ExcelDataType.Decimal;
                //        dvColumn.CompareOperator    = ExcelDataValidationComparisonOperator.Between;
                //        dvColumn.FirstFormula       = System.Decimal.MinValue.ToString();
                //        dvColumn.SecondFormula      = System.Decimal.MaxValue.ToString();
                //        dvColumn.ShowErrorBox       = true;
                //        dvColumn.ErrorBoxText       = "Enter Value between " + System.Decimal.MinValue.ToString() + " to " + System.Decimal.MaxValue.ToString();
                //        dvColumn.ErrorBoxTitle      = "ERROR";
                //        dvColumn.PromptBoxText      = "Data Validation using Condition for Numbers";
                //        dvColumn.ShowPromptBox      = true;
                //        break;
                //    default:
                //        break;
                //}
            }

            string sFileName = "InterfaceData" +"_" + this.IKpiRefID + "_" + this.IYMD+".xls";

            xlsSheet.ShowRow(1, false);

            //Saving the workbook to disk.
            xlsBook.SaveAs(sFileName, ExcelSaveType.SaveAsXLS, Response, ExcelDownloadType.PromptDialog);
        }
        catch(Exception e)
        {
            ltrScript.Text = JSHelper.GetAlertScript(e.Message);
        }
        finally
        {
            xlsEngine.ThrowNotSavedOnDestroy = false;
            xlsEngine.Dispose();        
        }



        //Entering text inside the Cells
        

        //sheet.Range["A1:D1"].Text = "This is the Long Text";
        //sheet.Range["E1"].Text = "This is the Long Text";
        //sheet.Range["A2:A5"].Text = "This is the Long Text using Autofit Columns and Rows";

        ////AutoFit Applied to a Range 
        //sheet.Range["A1:D1"].AutofitColumns();
        //sheet.Range["A2:A5"].AutofitRows();

        ////AutoFit applied to a Single Column
        //sheet.AutofitColumn(5);
        ////AutoFit applied to a Single Row
        //sheet.AutofitRow(1);

        ////Saving the workbook to disk.
        //workbook.SaveAs("Sample.xls", ExcelSaveType.SaveAsXLS, Response, ExcelDownloadType.PromptDialog);
        ////No exception will be thrown if there are unsaved workbooks.
        //excelEngine.ThrowNotSavedOnDestroy = false;
        //excelEngine.Dispose(); 
    }

    protected void ugrdInterface_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void iBtnExcelExport_Click(object sender, ImageClickEventArgs e)
    {
        this.ExportExcelFormat();
    }
}
