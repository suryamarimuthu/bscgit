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
using System.Globalization;

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using Infragistics.WebUI.UltraWebGrid.ExcelExport;

public partial class BSC_BSC0403S2 : AppPageBase
{
    private int    est_term_id = 0;
    private int    emp_ref_id  = 0;
    private string sum_type    = "";
    private const string CSS_NAME = "cssMScore";

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.hdfDeptID.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.txtDeptName.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    // Control for Call Back
    public string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", this.lBtnReload.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB3"];
        }
        set
        {
            ViewState["CCB3"] = value;
        }
    }

    public int IcntCol
    {
        get
        {
            if (ViewState["COL"] == null)
            {
                ViewState["COL"] = GetRequestByInt("COL", 0);
            }

            return (int)ViewState["COL"];
        }
        set
        {
            ViewState["COL"] = value;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        emp_ref_id = gUserInfo.Emp_Ref_ID;

        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetDeptTypeDropDownList(ddlComTypeInfo, false);
            WebCommon.SetSumTypeDropDownList(ddlSumType, false);

            this.TopEstDeptInfo();
            this.SetScoreGrid();

            WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        }
    }

    
    public void SetParameter()
    {
      
            this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            this.ISumType = PageUtility.GetByValueDropDownList(ddlSumType);
    }

    private void SetScoreGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        DataSet rDs = objTerm.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        DataSet dsTScore = new DataSet();
        dsTScore.Tables.Add("TSCORE");
        dsTScore.Tables.Add("TSCORE2");

        string strMM = "";
        this.IcntCol = rDs.Tables[0].Rows.Count;

        for (int i = 0; i < this.IcntCol; i++)
        {
            strMM = rDs.Tables[0].Rows[i]["YMD"].ToString();
            dsTScore.Tables[1].Columns.Add("TC_" + strMM + "_01", typeof(string));  // YMD
            dsTScore.Tables[1].Columns.Add("TC_" + strMM + "_02", typeof(string));  // EST_DEPT_REF_ID
            dsTScore.Tables[1].Columns.Add("TC_" + strMM + "_06", typeof(string));  // EST_YN

            dsTScore.Tables[0].Columns.Add("TC_" + strMM + "_03", typeof(string));  // RANK_ID
            dsTScore.Tables[0].Columns.Add("TC_" + strMM + "_04", typeof(string));  // DEPT_NAME
            dsTScore.Tables[0].Columns.Add("TC_" + strMM + "_05", typeof(string));  // SCORE
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Score_Card objSC = new MicroBSC.BSC.Biz.Biz_Bsc_Score_Card();
        DataSet dsRtn = objSC.GetYearlyTotalScoreTrend( PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                                      , PageUtility.GetIntByValueDropDownList(ddlComTypeInfo)
                                                      , PageUtility.GetByValueDropDownList(ddlSumType)
                                                      , (hdfDeptID.Value=="") ? 0 : int.Parse(hdfDeptID.Value)
                                                      , (chkApplyExtScore.Checked) ? "Y" : "N"
                                                      , gUserInfo.Emp_Ref_ID);

        int cntRow        = dsRtn.Tables[0].Rows.Count;       // 조회행수
        int cntCol        = dsRtn.Tables[0].Columns.Count;    // 컬럼수
        int intRowIdx     = 0;                                // DataSet Row Index
        int intColIdx     = 0;                                // DataSet Col Index
        int intRowNum     = 0;                                // Row Num
        string strPTmcode = "";                               // 이전행 월코드
        string strCTmcode = "";                               // 현재행 월코드
        string strNTmcode = "";                               // 다음행 월코드
        int iGrpRow       = 0;
        int iTotRow       = 0;

        try
        {
            DataRow drRow = dsTScore.Tables[0].NewRow();
            DataRow drRow2 = dsTScore.Tables[1].NewRow();
            for (int i = 0; i < cntRow; i++)
            {
                strPTmcode = (i > 0) ? dsRtn.Tables[0].Rows[i - 1]["YMD"].ToString() : dsRtn.Tables[0].Rows[i]["YMD"].ToString();
                strCTmcode = dsRtn.Tables[0].Rows[i]["YMD"].ToString();
                strNTmcode = (i >= cntRow - 1) ? dsRtn.Tables[0].Rows[i]["YMD"].ToString() : dsRtn.Tables[0].Rows[i + 1]["YMD"].ToString();

                if (strPTmcode != strCTmcode)
                {
                    iGrpRow = 1;
                }
                else
                {
                    iGrpRow += 1;
                }

                for (int j = 0; j < cntCol; j++)
                {
                    //if (intRowIdx == 0)
                    if (iGrpRow > iTotRow)
                    {
                        if (j == 0 || j == 1 || j == 5)
                            drRow2[intColIdx + (j == 5 ? 2 : j)] = dsRtn.Tables[0].Rows[i][j];
                        else
                            drRow[intColIdx + j - 2] = dsRtn.Tables[0].Rows[i][j];
                    }
                    else
                    {
                        if (j == 0 || j == 1 || j == 5)
                            dsTScore.Tables[1].Rows[intRowNum][intColIdx + (j == 5 ? 2 : j)] = dsRtn.Tables[0].Rows[i][j];
                        else
                            dsTScore.Tables[0].Rows[intRowNum][intColIdx + j - 2] = dsRtn.Tables[0].Rows[i][j];
                    }
                }

                //if (intRowIdx == 0)
                if (iGrpRow > iTotRow)
                {
                    dsTScore.Tables[0].Rows.Add(drRow);
                    dsTScore.Tables[1].Rows.Add(drRow2);
                    drRow = dsTScore.Tables[0].NewRow();
                    drRow2 = dsTScore.Tables[1].NewRow();
                    iTotRow += 1;
                }

                if (strCTmcode != strNTmcode)
                {
                    intRowIdx += 1;
                    intColIdx += 3;
                    intRowNum = 0;
                }
                else
                {
                    intRowNum += 1;
                }
            }
        }
        catch (Exception e)
        {
            ltrScript.Text = JSHelper.GetAlertScript(e.Message, false);
        }

        ugrdMScore2.DataSource = dsTScore.Tables[1];
        ugrdMScore2.DataBind();

        ugrdMScore.DataSource = dsTScore.Tables[0];
        ugrdMScore.DataBind();

        //if (ugrdMScore.Rows.Count > 0)
        //{
        //    ugrdMScore.Visible = true;
        //    imgNoData.Visible  = false;
        //}
        //else
        //{
        //    ugrdMScore.Visible = false;
        //    imgNoData.Visible  = true;
        //}
    }
    protected void iBtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        ugrdEEP.ExcelStartRow = 7;
        ugrdEEP.ExportMode = ExportMode.InBrowser;
        ugrdEEP.DownloadName = "Dept Score Rank";
        ugrdEEP.WorksheetName = "조직별 Score 순위";
        ugrdEEP.Export(ugrdMScore);
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (this.hdfDeptID.Value == "" || this.txtDeptName.Text == "")
        {
            ltrScript.Text = JSHelper.GetAlertBackScript("조직을 선택해주십시오");
            return;
        }
        
        this.SetScoreGrid();
    }
    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermInfo.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가조직 : " + txtDeptName.Text;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "조회구분 : " + ddlSumType.SelectedItem.Text;
        e.CurrentWorksheet.Rows[3].Cells[0].Value = "조직유형 : " + ddlComTypeInfo.SelectedItem.Text;

        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
    }

    protected void ugrdEEP_CellExported(object sender, CellExportedEventArgs e)
    {
        int iRdex = e.CurrentRowIndex;
        int iCdex = e.CurrentColumnIndex;

        if (iRdex >  6)
        {
            if (iCdex % 3 == 2 && e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value != null)
            {
                if (e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value.ToString() != "-")
                {
                    string str = e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value.ToString();
                    char[] sep = { '<', '>' };
                    Array a = str.Split(sep);
                    e.CurrentWorksheet.Rows[iRdex].Cells[iCdex].Value = a.GetValue(2);
                }
            }
        }
    }

    protected void ugrdEEP_EndExport(object sender, EndExportEventArgs e)
    {
        int j = ugrdMScore.Columns.Count;

        for (int i = 0; i < ugrdMScore.Columns.Count; i = i + 3)
        {
            e.CurrentWorksheet.Rows[5].Cells[i].Value = ugrdMScore.Bands[0].HeaderLayout[j].Caption;
            e.CurrentWorksheet.MergedCellsRegions.Add(5, i, 5, i + 2);
            e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center;
            e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.FillPattern = Infragistics.Documents.Excel.FillPatternStyle.Solid;
            e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.FillPatternForegroundColor = System.Drawing.ColorTranslator.FromHtml("#94BAC9");
            e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.Font.Color = System.Drawing.Color.White;
            e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.BottomBorderColor = e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.TopBorderColor
                = e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.RightBorderColor = e.CurrentWorksheet.Rows[5].Cells[i].CellFormat.LeftBorderColor = System.Drawing.ColorTranslator.FromHtml("#C7C7C7");
            j++;
            e.CurrentWorksheet.Columns[i + 2].Width = 2000;
        }
    }

    protected void ugrdMScore_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Bands[0].HeaderLayout.Reset();

        for (int i = 0; i < this.IcntCol; i++)
        {
            //e.Layout.Bands[0].Columns[i * 6].Hidden = true;
            //e.Layout.Bands[0].Columns[i * 6 + 1].Hidden = true;
            //e.Layout.Bands[0].Columns[i * 6 + 5].Hidden = true;

            e.Layout.Bands[0].Columns[i * 3].Header.Caption = "순위";
            e.Layout.Bands[0].Columns[i * 3 + 1].Header.Caption = "부서명";
            e.Layout.Bands[0].Columns[i * 3 + 2].Header.Caption = "점수";
            /*
            e.Layout.Bands[0].Columns[i * 6 + 2].Header.RowLayoutColumnInfo.OriginX = (i * 3) + 0;
            e.Layout.Bands[0].Columns[i * 6 + 3].Header.RowLayoutColumnInfo.OriginX = (i * 3) + 1;
            e.Layout.Bands[0].Columns[i * 6 + 4].Header.RowLayoutColumnInfo.OriginX = (i * 3) + 2;
            */
            e.Layout.Bands[0].Columns[i * 3].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            e.Layout.Bands[0].Columns[i * 3 + 1].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            e.Layout.Bands[0].Columns[i * 3 + 2].CellStyle.HorizontalAlign = HorizontalAlign.Right;

            e.Layout.Bands[0].Columns[i * 3].Width = Unit.Pixel(30);
            e.Layout.Bands[0].Columns[i * 3 + 1].Width = Unit.Pixel(70);
            e.Layout.Bands[0].Columns[i * 3 + 2].Width = Unit.Pixel(50);

            //e.Layout.Bands[0].Columns[i * 6 + 2].MergeCells = true;
        }

        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }

        for (int i = 0; i < this.IcntCol; i++)
        {
            ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
            ch.Caption = String.Format("{0}월", i + 1);
            ch.Style.HorizontalAlign = HorizontalAlign.Center;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.OriginX = i * 3;
            ch.RowLayoutColumnInfo.SpanX = 3;
            e.Layout.Bands[0].HeaderLayout.Add(ch);
        }

    }

    protected void ugrdMScore_InitializeRow(object sender, RowEventArgs e)
    {
        try
        {
            for (int i = 0; i < this.IcntCol; i++)
            {

                string deptName = DataTypeUtility.GetValue(e.Row.Cells[i * 3 + 1].Value);

                if (double.Parse(e.Row.Cells[i * 3 + 2].Value.ToString()) < 0)
                {
                    e.Row.Cells[i * 3].Value = "-";
                    //e.Row.Cells[i * 6 + 3].Value = "-";
                    e.Row.Cells[i * 3 + 2].Value = "-";
                }
                else
                {
                    e.Row.Cells[i * 3 + 1].Style.CssClass = CSS_NAME + "_" + deptName;
                    e.Row.Cells[i * 3 + 1].Value = string.Format("<span>{0}</span>", deptName);

                    //e.Row.Cells[i * 3 + 2].Value = double.Parse(e.Row.Cells[i * 3 + 2].Value.ToString()).ToString("#,##0.00");
                    //e.Row.Cells[i * 3 + 2].Value = string.Format("<a href='#null' onclick=\"ShowScoreTrace('{0}', '{1}', '{2}', '{3}', '{5}')\">{4}</a>"
                    //                                                    , PageUtility.GetByValueDropDownList(ddlEstTermInfo)
                    //                                                    , ugrdMScore2.Rows[e.Row.Index].Cells[i * 3].Value.ToString()//e.Row.Cells[i * 6 + 0].Value.ToString()
                    //                                                    , PageUtility.GetByValueDropDownList(ddlSumType)
                    //                                                    , ugrdMScore2.Rows[e.Row.Index].Cells[i * 3 + 1].Value.ToString()//e.Row.Cells[i * 6 + 1].Value.ToString()
                    //                                                    , e.Row.Cells[i * 3 + 2].Value.ToString()
                    //                                                    , ddlComTypeInfo.SelectedValue);
                    
                }
            }
        }
        catch (Exception ex)
        {
            //ltrScript.Text = JSHelper.GetAlertScript(ex.Message, false);
            return;
        }
    }

    private void BindComTypeInfo()
    {
        int sDEPT_REF_ID = int.Parse(hdfDeptID.Value);
        est_term_id = int.Parse(this.ddlEstTermInfo.SelectedValue);

        MicroBSC.Biz.Common.Biz.Biz_DeptTypeInfo biz = new MicroBSC.Biz.Common.Biz.Biz_DeptTypeInfo();
        DataSet ds = biz.GetDeptTypeSortList(est_term_id, sDEPT_REF_ID);

        ddlComTypeInfo.Items.Clear();

        ddlComTypeInfo.DataSource = ds;

        //임원,부분 제거
        ds.Tables[0].Rows.Remove(ds.Tables[0].Rows[0]);
        ds.Tables[0].Rows.Remove(ds.Tables[0].Rows[0]);
   
        this.hdfDept_Type_Flag.Value = ds.Tables[0].Rows.Count.ToString();

        ddlComTypeInfo.DataTextField = "TYPE_NAME";
        ddlComTypeInfo.DataValueField = "TYPE_REF_ID";

        ddlComTypeInfo.DataBind();

    }

    private void TopEstDeptInfo()
    {
        this.SetParameter();

        //장성민 Dac을 직접호출 추후 수정필수
        MicroBSC.Estimation.Dac.DeptInfos objEst = new MicroBSC.Estimation.Dac.DeptInfos();
        this.IEstDeptID = objEst.GetRootEstDeptID(this.IEstTermRefID);
        hdfDeptID.Value = this.IEstDeptID.ToString();
        MicroBSC.Estimation.Dac.DeptInfos objEst2 = new MicroBSC.Estimation.Dac.DeptInfos(this.IEstDeptID);
        this.txtDeptName.Text = objEst2.Dept_Name;

        BindComTypeInfo();

    }


    protected void lBtnReload_Click(object sender, EventArgs e)
    {       
        BindComTypeInfo();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.txtDeptName.Text = "";
        this.hdfDeptID.Value  = "";
        ugrdMScore.Clear();
        ugrdMScore2.Clear();

        this.TopEstDeptInfo();
    }
}
