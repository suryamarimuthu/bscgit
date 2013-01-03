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

public partial class BSC_BSC0601S1 : AppPageBase
{
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetFormData();
            this.SetPreviewGrid();
        }
    }

    /// <summary>
    /// 조회
    /// </summary>
    public void SetFormData()
    { 
        int iTxrUser = gUserInfo.Emp_Ref_ID;
        Biz_Bsc_Interface_Dicode objBSC = new Biz_Bsc_Interface_Dicode(this.IDiCode, iTxrUser);
        lblDICODE.Text      = objBSC.IDicode;
        lblDINAME.Text      = objBSC.IName;
        lblDEFINITION.Text  = objBSC.IDefinition;
        lblUseYN.Text       = objBSC.IUse_Yn;
    }

    public void SetPreviewGrid()
    {
        Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        DataSet rDs = objCol.GetAllList(this.IDiCode, gUserInfo.Emp_Ref_ID);

        int iRow = 0;
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
                ugCol.Key            = "YMD";
                ugCol.BaseColumnName = "YMD";
                ugCol.Header.Caption = "평가월";
                ugCol.Width          = Unit.Pixel(50);
                ugCol.AllowUpdate    = AllowUpdate.No;
                ugCol.DataType       = "System.String";
                ugCol.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ugrdPreview.Columns.Add(ugCol);

                ugCol = new UltraGridColumn();
                ugCol.Key            = "DD";
                ugCol.BaseColumnName = "DD";
                ugCol.Header.Caption = "발생일자";
                ugCol.Width          = Unit.Pixel(35);
                ugCol.AllowUpdate    = AllowUpdate.Yes;
                ugCol.DataType       = "System.String";
                ugCol.Header.Style.Wrap = true;
                ugCol.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ugrdPreview.Columns.Add(ugCol);

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
                            ugrdPreview.Columns.Add(ugCol);
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
                            ugrdPreview.Columns.Add(ugCol);                            
                        }
                    }
                }
            }
        }

        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail();
        string sEstMon = objTerm.GetReleasedMonth();

        Random rndObj = new Random();
        for (int i = 0; i < 11; i++)
        {
            ugrdPreview.Rows.Add();
            for (int j = 0; j < ugrdPreview.Columns.Count; j++)
            { 
                if (ugrdPreview.Columns[j].DataType == "System.String")
                {
                    if (ugrdPreview.Columns[j].Key == "YMD")
                    {
                        ugrdPreview.Rows[i].Cells.FromKey(ugrdPreview.Columns[j].Key).Value = sEstMon;
                    }
                    else if (ugrdPreview.Columns[j].Key == "DD")
                    {
                        ugrdPreview.Rows[i].Cells.FromKey(ugrdPreview.Columns[j].Key).Value = Convert.ToString(rndObj.Next(1, 31)).PadLeft(2, '0');
                    }
                    else
                    {
                        ugrdPreview.Rows[i].Cells.FromKey(ugrdPreview.Columns[j].Key).Value = "String" + i.ToString();
                    }
                }
                else if (ugrdPreview.Columns[j].DataType == "System.Date")
                {
                    ugrdPreview.Rows[i].Cells.FromKey(ugrdPreview.Columns[j].Key).Value = DateTime.Now;
                }
                else if (ugrdPreview.Columns[j].DataType == "System.Double")
                {
                    ugrdPreview.Rows[i].Cells.FromKey(ugrdPreview.Columns[j].Key).Value = rndObj.NextDouble()*rndObj.Next(1000,1000000);
                }
            }
        }
       
        ugrdPreview.Visible = true;
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

    protected void ugrdPreview_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
}
