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
using Infragistics.WebUI.WebDataInput;
using Infragistics.WebUI.UltraWebTab;
using MicroBSC.QueryEngine.QueryBuilder;

using Syncfusion.XlsIO;

public partial class BSC_BSC0601M1 : AppPageBase
{
    #region ==========================[변수선언]================
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

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "P");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
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

    TextBox TtxtQUERY;
    ListBox TlstField;

    #endregion

    #region 폼초기화
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        TtxtQUERY      = this.ugrdDiCodeTab.FindControl("txtQUERY") as TextBox;
        TlstField      = this.ugrdDiCodeTab.FindControl("lstField") as ListBox;


        if (!IsPostBack)
        {
            this.NotPostBackSetting();
        }
        else
        {
            this.PostBackSetting();
        }

        this.iBtnPreView.Visible = false;
    }

    private void NotPostBackSetting()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);

        WebCommon.SetUnitTypeDropDownList(ddlUnit_Hdf, false);
        this.SetSourceDDL();
        this.SetInputTypeDDL();
        this.SetConditionList();
        //this.SetPreviewGrid();

        if (this.IType == "A")
        {
            this.InitForm();
        }
        else if (this.IType == "U" && this.IDiCode != "")
        {
            this.SetFormData();
        }
    }

    private void PostBackSetting()
    {
        /* 2011-06-03 수정 : 저장을 하거나 PostBack이후에 단위가 사라지는 현상을 방지 */
        WebCommon.SetUnitTypeDropDownList(ddlUnit_Hdf, false);
        /* 2011-06-03 수정 완료 *********************************************************/
    }

    #endregion

    #region ================================= [ 내부함수 ]================================
    /// <summary>
    /// 폼 값 초기화
    /// </summary>
    public void InitForm()
    {
        txtDICODE.Text      = "";
        txtDINAME.Text      = "";
        txtDEFINITION.Text  = "";
        lblUseYN.Text       = "";
        txtDICODE.BackColor = Color.White;
        txtDICODE.ReadOnly  = false;

        Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        ugrdDIColumn.Clear();
        ugrdDIColumn.DataSource = objCol.GetDefaultColumn(this.IDiCode).DefaultView;
        ugrdDIColumn.DataBind();
        this.SetButton();
    }

    private void SetButton()
    {

        fldExcelFile.Visible = iBtnUpload.Visible = iBtnDownload.Visible = iBtnSave.Visible = false;
        //tdtitle1.Visible = ddlEstTermInfo.Visible = ddlEstTermMonth.Visible = false;
        iBtnUpdate.Visible = iBtnDelete.Visible = true;

        if (this.IType == "A")
        {
            iBtnClear.Visible   = false;
            iBtnInsert.Visible  = true;
            iBtnUpdate.Visible  = false;
            iBtnDelete.Visible  = false;
            iBtnReUse.Visible   = false;
            iBtnPreView.Visible = false;
        }
        else if (this.IType == "U")
        { 
            iBtnClear.Visible   = false;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = true;
            iBtnDelete.Visible  = true;
            iBtnReUse.Visible   = false;
            iBtnPreView.Visible = true;
        }
        else if (this.IType == "D")
        { 
            iBtnClear.Visible   = false;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = true;
            iBtnDelete.Visible  = true;
            iBtnReUse.Visible   = false;
            iBtnPreView.Visible = true;
        }
        else if (this.IType == "R")
        { 
            iBtnClear.Visible   = false;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = false;
            iBtnDelete.Visible  = false;
            iBtnReUse.Visible   = true;
            iBtnPreView.Visible = true;
        }
        else
        {
            iBtnClear.Visible   = false;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = false;
            iBtnDelete.Visible  = false;
            iBtnReUse.Visible   = false;
            iBtnPreView.Visible = true;
        }

        if (ugrdDiCodeTab.SelectedTab == 2)
        {
            fldExcelFile.Visible = iBtnUpload.Visible = iBtnDownload.Visible = iBtnSave.Visible = true;
            //tdtitle1.Visible = ddlEstTermInfo.Visible = ddlEstTermMonth.Visible = true;
            iBtnUpdate.Visible = iBtnDelete.Visible = false;
        }
    }

    /// <summary>
    /// Data Source 조회
    /// </summary>
    public void SetSourceDDL()
    {
        Biz_Bsc_Interface_Datasource objBSC = new Biz_Bsc_Interface_Datasource();
        DataSet rDs = objBSC.GetAllList();

        ddlSOURCE_ID.Items.Clear();
        ddlSOURCE_ID.DataSource     = rDs.Tables[0].DefaultView;
        ddlSOURCE_ID.DataTextField  = "SOURCE_NAME";
        ddlSOURCE_ID.DataValueField = "SOURCE_ID";
        ddlSOURCE_ID.DataBind();
    }

    public void SetInputTypeDDL()
    {
        ddlINPUT_TYPE.Items.Clear();
        ddlINPUT_TYPE.Items.Add(new ListItem("PUSH", "PUSH"));
        ddlINPUT_TYPE.Items.Add(new ListItem("PULL", "PULL"));
    }

    /// <summary>
    /// 폼데이터 조회
    /// </summary>
    public void SetFormData()
    { 
        int iTxrUser = gUserInfo.Emp_Ref_ID;
        Biz_Bsc_Interface_Dicode objBSC = new Biz_Bsc_Interface_Dicode(this.IDiCode, iTxrUser);
        txtDICODE.Text      = objBSC.IDicode;
        txtDINAME.Text      = objBSC.IName;
        txtDEFINITION.Text  = objBSC.IDefinition;
        lblUseYN.Text       = objBSC.IUse_Yn;
        TtxtQUERY.Text      = objBSC.IQuery;
        chkDailyResultKpi.Checked = (objBSC.IDailyKpi_YN == "Y" ? true : false);
        PageUtility.FindByValueDropDownList(ddlSOURCE_ID, objBSC.ISource_Id.ToString());
        PageUtility.FindByValueDropDownList(ddlINPUT_TYPE, objBSC.IInput_Type);

        txtDICODE.BackColor = Color.WhiteSmoke;
        txtDICODE.ReadOnly  = true;
        this.IType          = (objBSC.IUse_Yn=="Y") ? "U" : "R";

        Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        DataTable dtRtn = objCol.GetColumnInfoPerDicode(this.IDiCode, iTxrUser);

        ugrdDIColumn.Clear();
        ugrdDIColumn.DataSource = dtRtn.DefaultView;
        ugrdDIColumn.DataBind();

        // 데이터를 미리 본다
        try
        {
            //Biz_Bsc_Interface_Datasource objIDS = new Biz_Bsc_Interface_Datasource();
            Biz_Bsc_Interface_Dicode objIDS = new Biz_Bsc_Interface_Dicode();
            Biz_Bsc_Term_Detail objTD = new Biz_Bsc_Term_Detail();
            //DataSet ds = objIDS.GetInterfacePreviewData(TtxtQUERY.Text.Trim(), objTD.GetReleasedMonth());
            DataTable ds = objIDS.GetOrginalInterfaceData(txtDICODE.Text.Trim(), "", gUserInfo.Emp_Ref_ID, objTD.GetReleasedMonth());
            UltraWebGrid1.Clear();
            UltraWebGrid1.DataSource = ds;
            UltraWebGrid1.DataBind();

            UltraWebGrid1.Columns.FromKey("DICODE").Header.Caption = "코드";
            UltraWebGrid1.Columns.FromKey("DICODE").Header.Style.HorizontalAlign = HorizontalAlign.Center;
            UltraWebGrid1.Columns.FromKey("DICODE").CellStyle.HorizontalAlign = HorizontalAlign.Center;
            UltraWebGrid1.Columns.FromKey("RDTERM").Header.Caption = "발생월";
            UltraWebGrid1.Columns.FromKey("RDTERM").Header.Style.HorizontalAlign = HorizontalAlign.Center;
            UltraWebGrid1.Columns.FromKey("RDTERM").CellStyle.HorizontalAlign = HorizontalAlign.Center;
            UltraWebGrid1.Columns.FromKey("RDDATE").Header.Caption = "발생일";
            UltraWebGrid1.Columns.FromKey("RDDATE").Header.Style.HorizontalAlign = HorizontalAlign.Center;
            UltraWebGrid1.Columns.FromKey("RDDATE").CellStyle.HorizontalAlign = HorizontalAlign.Center;

            Biz_Bsc_Interface_Column objIDC = new Biz_Bsc_Interface_Column();
            DataTable dtCol = objIDC.GetColumnInfoPerDicode(txtDICODE.Text.Trim(), gUserInfo.Emp_Ref_ID);
            for (int i = 0; i < dtCol.Rows.Count; i++)
            {
                DataRow dr = dtCol.Rows[i];
                if (dr["D_USE_YN"].ToString() == "Y")
                {
                    UltraWebGrid1.Columns.FromKey(dr["D_COLUMN_ID"].ToString()).Header.Caption = dr["D_COL_NAME"].ToString();
                    UltraWebGrid1.Columns.FromKey(dr["D_COLUMN_ID"].ToString()).CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    UltraWebGrid1.Columns.FromKey(dr["D_COLUMN_ID"].ToString()).Format = "###,##0" + GetFormatFromColumnInfo(DataTypeUtility.GetToInt32(dr["D_DECIMAL_POINTS"]));
                }
                if (dr["S_USE_YN"].ToString() == "Y")
                {
                    UltraWebGrid1.Columns.FromKey(dr["S_COLUMN_ID"].ToString()).Header.Caption = dr["S_COL_NAME"].ToString();
                }
            }
        }
        catch(Exception ex) { }

        this.SetButton();
    }

    private string GetFormatFromColumnInfo(int colCount)
    {
        string strReturn = string.Empty;
        if (colCount < 1)
            return strReturn;

        strReturn = ".";
        for (int i = 0; i < colCount; i++)
        {
            strReturn += "0";
        }
        return strReturn;
    }

    public bool ValidataFormData()
    {
        if (txtDICODE.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("DICODE를 입력해 주십시오.", false);
            return false;
        }
        else if (txtDINAME.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("코드명을 입력해 주십시오.", false);
            return false;
        }

        return true;
    }

    /// <summary>
    /// 폼데이터 입력/수정/삭제
    /// </summary>
    /// <returns></returns>
    public bool TrxFormData()
    {
        if (!this.ValidataFormData())
        {
            return false;
        }

        Biz_Bsc_Interface_Dicode objBSC = new Biz_Bsc_Interface_Dicode();
        objBSC.IDicode     = txtDICODE.Text;
        objBSC.IName       = txtDINAME.Text;
        objBSC.ISource_Id  = PageUtility.GetIntByValueDropDownList(ddlSOURCE_ID);
        objBSC.IInput_Type = PageUtility.GetByValueDropDownList(ddlINPUT_TYPE);
        objBSC.IDefinition = txtDEFINITION.Text;
        objBSC.IUse_Yn     = "Y";
        objBSC.IQuery      = TtxtQUERY.Text;
        objBSC.IDailyKpi_YN = (chkDailyResultKpi.Checked == true ? "Y" : "N");

        for (int i = 0; i < TlstField.Items.Count; i++)
        {
            string sParam = QueryOperator.LBracket + TlstField.Items[i].Text + QueryOperator.RBracket;
            objBSC.IQuery = objBSC.IQuery.Replace(sParam, TlstField.Items[i].Value);
        }

        Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        DataTable dtCol = objCol.GetInsertSchema();
        DataRow drRow   = null;

        bool bSCheck    = false; //문자열 체크여부
        bool bDCheck    = false; //숫자열 체크여부
        bool bSInsert   = false; //문자열 입력여부
        bool bDInsert   = false; //숫자열 입력여부

        CheckBox chkSCheck         = null;
        TextBox txtSColNm          = null;
        WebNumericEdit txtSSorder  = null;
        WebNumericEdit txtSWidth   = null;

        CheckBox chkDCheck         = null;
        TextBox txtDColNm          = null;
        WebNumericEdit txtDWidth   = null;
        WebNumericEdit txtDSorder  = null;
        WebNumericEdit txtDDigit   = null;
        DropDownList ddlDUnit      = null;

        TemplatedColumn colSCheck  = null;
        TemplatedColumn colSColNm  = null;
        TemplatedColumn colSSorder = null;
        TemplatedColumn colSWidth  = null;
        
        TemplatedColumn colDCheck  = null;
        TemplatedColumn colDColNm  = null;
        TemplatedColumn colDSorder = null;
        TemplatedColumn colDWidth  = null;
        TemplatedColumn colDDigit  = null;
        TemplatedColumn colDUnit   = null;

        int iRow = ugrdDIColumn.Rows.Count;
        for (int i = 0; i < iRow; i++)
        {
            colSCheck = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("S_USE_YN");
            colDCheck = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("D_USE_YN");

            chkSCheck = (CheckBox)((CellItem)colSCheck.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("chkUseYn");
            chkDCheck = (CheckBox)((CellItem)colDCheck.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("chkUseYn");
            
            bSInsert  = (chkSCheck.Checked) ? true : false;
            bDInsert  = (chkDCheck.Checked) ? true : false;
            bSCheck   = (ugrdDIColumn.Rows[i].Cells.FromKey("S_INSERTED_YN").Value.ToString() == "Y") ? true : false;
            bDCheck   = (ugrdDIColumn.Rows[i].Cells.FromKey("D_INSERTED_YN").Value.ToString() == "Y") ? true : false;

            if (bSInsert || bSInsert)
            {
                colSColNm  = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("S_COL_NAME");
                colSSorder = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("S_SORT_ORDER");
                colSWidth  = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("S_GRID_WIDTH");

                txtSColNm  = (TextBox)((CellItem)colSColNm.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("txtColumnName");
                txtSSorder = (WebNumericEdit)((CellItem)colSSorder.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("txtSortOrder");
                txtSWidth  = (WebNumericEdit)((CellItem)colSWidth.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("txtGridWidth");

                drRow = dtCol.NewRow();
                drRow[dtCol.Columns[0].ColumnName] = objBSC.IDicode;
                drRow[dtCol.Columns[1].ColumnName] = ugrdDIColumn.Rows[i].Cells.FromKey("S_COLUMN_ID").Value.ToString();
                drRow[dtCol.Columns[2].ColumnName] = txtSColNm.Text;
                drRow[dtCol.Columns[3].ColumnName] = "N";
                drRow[dtCol.Columns[4].ColumnName] = Convert.ToInt32(txtSSorder.Text);
                drRow[dtCol.Columns[5].ColumnName] = 0;
                drRow[dtCol.Columns[6].ColumnName] = 0;
                drRow[dtCol.Columns[7].ColumnName] = Convert.ToInt32(txtSWidth.Text);
                drRow[dtCol.Columns[8].ColumnName] = (chkSCheck.Checked) ? "Y" : "N";
                dtCol.Rows.Add(drRow);
            }

            if (bDInsert || bDInsert)
            {
                colDColNm  = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("D_COL_NAME");
                colDSorder = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("D_SORT_ORDER");
                colDWidth  = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("D_GRID_WIDTH");
                colDDigit  = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("D_DECIMAL_POINTS");
                colDUnit   = (TemplatedColumn)ugrdDIColumn.Columns.FromKey("D_UNIT_REF_ID");

                txtDColNm  = (TextBox)((CellItem)colDColNm.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("txtColumnName");
                txtDSorder = (WebNumericEdit)((CellItem)colDSorder.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("txtSortOrder");
                txtDWidth  = (WebNumericEdit)((CellItem)colDWidth.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("txtGridWidth");
                txtDDigit  = (WebNumericEdit)((CellItem)colDDigit.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("txtDecimalPoints");
                ddlDUnit   = (DropDownList)((CellItem)colDUnit.CellItems[ugrdDIColumn.Rows[i].BandIndex]).FindControl("ddlUnit");

                drRow = dtCol.NewRow();
                drRow[dtCol.Columns[0].ColumnName] = objBSC.IDicode;
                drRow[dtCol.Columns[1].ColumnName] = ugrdDIColumn.Rows[i].Cells.FromKey("D_COLUMN_ID").Value.ToString();
                drRow[dtCol.Columns[2].ColumnName] = txtDColNm.Text;
                drRow[dtCol.Columns[3].ColumnName] = "N";
                drRow[dtCol.Columns[4].ColumnName] = Convert.ToInt32(txtDSorder.Text);
                drRow[dtCol.Columns[5].ColumnName] = PageUtility.GetIntByValueDropDownList(ddlDUnit);
                drRow[dtCol.Columns[6].ColumnName] = Convert.ToInt32(txtDDigit.Text);
                drRow[dtCol.Columns[7].ColumnName] = Convert.ToInt32(txtDWidth.Text);
                drRow[dtCol.Columns[8].ColumnName] = (chkDCheck.Checked) ? "Y" : "N";
                dtCol.Rows.Add(drRow);
            }
        }

        if (this.IType == "A" || this.IType == "U")
        {
            bool bRtn      = objBSC.InsertDiCodeColumn(null, null, objBSC.IDicode, objBSC.IName,objBSC.ISource_Id,objBSC.IInput_Type, objBSC.IDefinition, objBSC.IUse_Yn, objBSC.IQuery, gUserInfo.Emp_Ref_ID, dtCol, objBSC.IDailyKpi_YN);
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message);
            return bRtn;
        }
        else if (this.IType == "D")
        { 
            int iRtn = objBSC.DeleteData(null, null, objBSC.IDicode, gUserInfo.Emp_Ref_ID);
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message);
            if (objBSC.Transaction_Result == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (this.IType == "R")
        {
            int iRtn = objBSC.UpdateData(null, null, objBSC.IDicode, objBSC.IName, objBSC.ISource_Id,objBSC.IInput_Type, objBSC.IDefinition, "Y", objBSC.IQuery, gUserInfo.Emp_Ref_ID, objBSC.IDailyKpi_YN);
        }

        return false;
    }

    public void SetConditionList()
    {
        TlstField.Visible = true;
        TlstField.Items.Clear();

        TlstField.Items.Add(new ListItem("@DICODE", this.IDiCode));
        TlstField.Items.Add(new ListItem("@직전평가월", QueryOperator.ParamPrevYmd));
        TlstField.Items.Add(new ListItem("@현재평가월", QueryOperator.ParamCurrYmd)); 
    }

    public void SetPreviewGrid()
    {
        ugrdPreview.Clear();
        Biz_Bsc_Interface_Column objCol = new Biz_Bsc_Interface_Column();
        DataSet rDs = objCol.GetAllList(this.IDiCode, gUserInfo.Emp_Ref_ID);

        int iRow        = 0;
        string sUseYn   = "N";
        string sColKey  = "";
        string sColName = "";
        int iDPoints    = 0;
        int iGridWith   = 0;

        for (int i = ugrdPreview.Columns.Count; i > 0; i--)
        {
            ugrdPreview.Bands[0].Columns.RemoveAt(i - 1);
            ugrdPreview.Bands[0].HeaderLayout.RemoveAt(i - 1);
        }

        UltraGridColumn ugCol;

        if (rDs.Tables.Count > 0)
        {
            iRow = rDs.Tables[0].Rows.Count;
            if (iRow > 0)
            {
                ugCol = new UltraGridColumn();
                ugCol.Key            = "RDTERM";
                ugCol.BaseColumnName = "RDTERM";
                ugCol.Header.Caption = "발생월";
                ugCol.Width          = Unit.Pixel(50);
                ugCol.AllowUpdate    = AllowUpdate.No;
                ugCol.DataType       = "System.String";
                ugCol.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                ugrdPreview.Columns.Add(ugCol);

                ugCol = new UltraGridColumn();
                ugCol.Key            = "RDDATE";
                ugCol.BaseColumnName = "RDDATE";
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
        string sEstMon   = objTerm.GetReleasedMonth();
        string sPreMon   = objTerm.GetOpenEstTermID().ToString() + "01";

        Biz_Bsc_Interface_Dicode objDiCode = new Biz_Bsc_Interface_Dicode();
        DataTable rDt = objDiCode.GetDataResult(this.IDiCode, sPreMon, sEstMon, gUserInfo.Emp_Ref_ID);

        if (rDt != null)
        {
            ugrdPreview.Clear();
            ugrdPreview.DataSource = rDt.DefaultView;
            ugrdPreview.DataBind();
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
            sFormat = sFormat + "0";
        }

        return sFormat;
    }

    protected void OperatorButton_Click(object sender, EventArgs e)
    {
        string sID = ((Control)sender).ID;

        string sCurQry = "";
        sCurQry = TtxtQUERY.Text;

        switch (sID)
        {
            case "btnD0":
                sCurQry += QueryOperator.Digit0;
                break;
            case "btnD1":
                sCurQry += QueryOperator.Digit1;
                break;
            case "btnD2":
                sCurQry += QueryOperator.Digit2;
                break;
            case "btnD3":
                sCurQry += QueryOperator.Digit3;
                break;
            case "btnD4":
                sCurQry += QueryOperator.Digit4;
                break;
            case "btnD5":
                sCurQry += QueryOperator.Digit5;
                break;
            case "btnD6":
                sCurQry += QueryOperator.Digit6;
                break;
            case "btnD7":
                sCurQry += QueryOperator.Digit7;
                break;
            case "btnD8":
                sCurQry += QueryOperator.Digit8;
                break;
            case "btnD9":
                sCurQry += QueryOperator.Digit9;
                break;
            case "bntPoint":
                sCurQry += QueryOperator.DigitPoint;
                break;
            case "btnPlus":
                sCurQry += QueryOperator.ArithOperPlus;
                break;
            case "btnMinus":
                sCurQry += QueryOperator.ArithOperMinus;
                break;
            case "btnMultiply":
                sCurQry += QueryOperator.ArithOperMultiply;
                break;
            case "btnDivision":
                sCurQry += QueryOperator.ArithOperDivide;
                break;
            case "btnLeftBR":
                sCurQry += QueryOperator.LParenthesis;
                break;
            case "btnRightBR":
                sCurQry += QueryOperator.RParenthesis;
                break;
            case "btnSum":
                sCurQry += QueryOperator.AggFuncSum;
                break;
            case "btnAbs":
                sCurQry += QueryOperator.AggFuncABS;
                break;
            case "btnAvg":
                sCurQry += QueryOperator.AggFuncAVG;
                break;
            case "btnMax":
                sCurQry += QueryOperator.AggFuncMAX;
                break;
            case "btnMin":
                sCurQry += QueryOperator.AggFuncMIN;
                break;
            case "btnCount":
                sCurQry += QueryOperator.AggFuncCOUNT;
                break;
            case "btnAnd":
                sCurQry += QueryOperator.LogicOperAnd;
                break;
            case "btnOR":
                sCurQry += QueryOperator.LogicOperOr;
                break;
            case "btnEqual":
                sCurQry += QueryOperator.CompOperEqual;
                break;
            case "btnNotEqual":
                sCurQry += QueryOperator.CompOperNotEqual;
                break;
            case "btnGT":
                sCurQry += QueryOperator.CompOperGrater;
                break;
            case "btnLT":
                sCurQry += QueryOperator.CompOperLower;
                break;
            case "btnMoreThen":
                sCurQry += QueryOperator.CompOperMoreThen;
                break;
            case "btnLessThen":
                sCurQry += QueryOperator.CompOperLessThen;
                break;
            case "lstField":
                sCurQry += QueryOperator.LBracket + TlstField.SelectedItem.Text + QueryOperator.RBracket;
                break;
            default:
                break;
        }

        TtxtQUERY.Text = sCurQry;
    }

    #endregion

    #region ================================= [ 서버이벤트 ]================================
    protected void ugrdDIColumn_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "CODE";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "문자열";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "숫자열";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 10;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;
    }
    
    protected void ugrdDIColumn_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        CheckBox chkSCheck         = null;
        TextBox txtSColNm          = null;
        WebNumericEdit txtSSorder  = null;
        WebNumericEdit txtSWidth   = null;

        CheckBox chkDCheck         = null;
        TextBox txtDColNm          = null;
        WebNumericEdit txtDWidth   = null;
        WebNumericEdit txtDSorder  = null;
        WebNumericEdit txtDDigit   = null;
        DropDownList ddlDUnit      = null;

        TemplatedColumn colSCheck  = null;
        TemplatedColumn colSColNm  = null;
        TemplatedColumn colSSorder = null;
        TemplatedColumn colSWidth  = null;
        
        TemplatedColumn colDCheck  = null;
        TemplatedColumn colDColNm  = null;
        TemplatedColumn colDSorder = null;
        TemplatedColumn colDWidth  = null;
        TemplatedColumn colDDigit  = null;
        TemplatedColumn colDUnit   = null;

        colSCheck  = (TemplatedColumn)e.Row.Band.Columns.FromKey("S_USE_YN");
        colSColNm  = (TemplatedColumn)e.Row.Band.Columns.FromKey("S_COL_NAME");
        colSSorder = (TemplatedColumn)e.Row.Band.Columns.FromKey("S_SORT_ORDER");
        colSWidth  = (TemplatedColumn)e.Row.Band.Columns.FromKey("S_GRID_WIDTH");

        colDCheck  = (TemplatedColumn)e.Row.Band.Columns.FromKey("D_USE_YN");
        colDColNm  = (TemplatedColumn)e.Row.Band.Columns.FromKey("D_COL_NAME");
        colDSorder = (TemplatedColumn)e.Row.Band.Columns.FromKey("D_SORT_ORDER");
        colDWidth  = (TemplatedColumn)e.Row.Band.Columns.FromKey("D_GRID_WIDTH");
        colDDigit  = (TemplatedColumn)e.Row.Band.Columns.FromKey("D_DECIMAL_POINTS");
        colDUnit   = (TemplatedColumn)e.Row.Band.Columns.FromKey("D_UNIT_REF_ID");

        chkSCheck  = (CheckBox)((CellItem)colSCheck.CellItems[e.Row.BandIndex]).FindControl("chkUseYn");
        txtSColNm  = (TextBox)((CellItem)colSColNm.CellItems[e.Row.BandIndex]).FindControl("txtColumnName");
        txtSSorder = (WebNumericEdit)((CellItem)colSSorder.CellItems[e.Row.BandIndex]).FindControl("txtSortOrder");
        txtSWidth  = (WebNumericEdit)((CellItem)colSWidth.CellItems[e.Row.BandIndex]).FindControl("txtGridWidth");
        
        chkDCheck  = (CheckBox)((CellItem)colDCheck.CellItems[e.Row.BandIndex]).FindControl("chkUseYn");
        txtDColNm  = (TextBox)((CellItem)colDColNm.CellItems[e.Row.BandIndex]).FindControl("txtColumnName");
        txtDSorder = (WebNumericEdit)((CellItem)colDSorder.CellItems[e.Row.BandIndex]).FindControl("txtSortOrder");
        txtDWidth  = (WebNumericEdit)((CellItem)colDWidth.CellItems[e.Row.BandIndex]).FindControl("txtGridWidth");
        txtDDigit  = (WebNumericEdit)((CellItem)colDDigit.CellItems[e.Row.BandIndex]).FindControl("txtDecimalPoints");
        ddlDUnit   = (DropDownList)((CellItem)colDUnit.CellItems[e.Row.BandIndex]).FindControl("ddlUnit");

        ddlDUnit.DataSource     = ddlUnit_Hdf.DataSource;
        ddlDUnit.DataTextField  = ddlUnit_Hdf.DataTextField;
        ddlDUnit.DataValueField = ddlUnit_Hdf.DataValueField;
        ddlDUnit.DataBind();

        chkSCheck.Checked = (e.Row.Cells.FromKey("S_USE_YN").Value.ToString() == "Y") ? true : false;
        txtSColNm.Text    = e.Row.Cells.FromKey("S_COL_NAME").Value.ToString();
        txtSSorder.Text   = e.Row.Cells.FromKey("S_SORT_ORDER").Value.ToString();
        txtSWidth.Text    = e.Row.Cells.FromKey("S_GRID_WIDTH").Value.ToString();

        chkDCheck.Checked = (e.Row.Cells.FromKey("D_USE_YN").Value.ToString() == "Y") ? true : false;
        txtDColNm.Text    = e.Row.Cells.FromKey("D_COL_NAME").Value.ToString();
        txtDSorder.Text   = e.Row.Cells.FromKey("D_SORT_ORDER").Value.ToString();
        txtDWidth.Text    = e.Row.Cells.FromKey("D_GRID_WIDTH").Value.ToString();
        txtDDigit.Text    = e.Row.Cells.FromKey("D_DECIMAL_POINTS").Value.ToString();
        PageUtility.FindByValueDropDownList(ddlDUnit, e.Row.Cells.FromKey("D_UNIT_REF_ID").Value.ToString());
    }

    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        bool bRtn = this.TrxFormData();
        if (bRtn)
        {
            this.IDiCode = txtDICODE.Text;
            this.IType   = "U";
            this.SetFormData();
        }
    }

    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        bool bRtn = this.TrxFormData();
        if (bRtn)
        {
            this.SetFormData();
        }
    }

    protected void iBtnUpload_Click(object sender, ImageClickEventArgs e)
    {
        ugrdPreview.Clear();
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
        IWorkbook workbook = null;

        workbook = excelEngine.Excel.Workbooks.Open(fldExcelFile.PostedFile.InputStream);

        IWorksheet sheet = workbook.Worksheets[0];

        if (sheet.Rows.Length < 4)
        {
            // 빈 엑셀 파일입니다.
            ltrScript.Text = JSHelper.GetAlertScript("빈 엑셀 파일입니다.", false);
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
            return;
        }

        // 컬럼 일치하는지 검증
        string colName;
        bool isExist;
        int maxCols = sheet.Columns.Length;
        for (int i = 0; i < sheet.Columns.Length; i++)
        {
            if (sheet.Range[3, i + 1].AddComment().Text.Trim().Equals(""))
            {
                maxCols = i;
                break;
            }
        }

        for (int i = 0; i < maxCols; i++)
        {
            isExist = true;
            colName = sheet.Range[3, i + 1].AddComment().Text;

            if (!colName.Equals(""))
            {
                for (int j = 2; j < ugrdPreview.Columns.Count; j++)
                {
                    if (colName == ugrdPreview.Columns[j].Key)
                    {
                        isExist = false;
                        break;
                    }
                }
                if (isExist)
                {
                    // 엑셀형식이 일치하지 않습니다.
                    ltrScript.Text = JSHelper.GetAlertScript("엑셀형식이 일치하지 않습니다.", false);
                    excelEngine.ThrowNotSavedOnDestroy = false;
                    excelEngine.Dispose();
                    return;
                }
            }
        }

        try
        {
            //바인딩할 테이블 스키마 생성
            DataTable ExcelUnitUploadData = new DataTable();
            for (int i = 2; i < ugrdPreview.Columns.Count; i++)
            {
                if (ugrdPreview.Columns[i].DataType == "System.String")
                    ExcelUnitUploadData.Columns.Add(ugrdPreview.Columns[i].Key, typeof(string));
                else
                    ExcelUnitUploadData.Columns.Add(ugrdPreview.Columns[i].Key, typeof(double));
            }

            //발생월, 발생일 추가
            ExcelUnitUploadData.Columns.Add("RDTERM", typeof(string));
            ExcelUnitUploadData.Columns.Add("RDDATE", typeof(string));

            //엑셀컬럼명 변경(그리드컬럼키로 변경)
            for (int i = 0; i < maxCols; i++)
            {
                string columnKey = string.Format("{0}3", DataTypeUtility.GetInt32ToAlphabet(i + 1));
                sheet.Range[columnKey].Text = sheet.Range[columnKey].AddComment().Text;
            }

            //엑셀 -> 데이터테이블
            DataTable _tmpTable = sheet.ExportDataTable(3, 1, sheet.Rows.Length, maxCols, ExcelExportDataTableOptions.ColumnNames | ExcelExportDataTableOptions.ComputedFormulaValues);

            //빈값 Row  제거
            string queryCondition = string.Empty;
            for (int i = 0; i < _tmpTable.Columns.Count; i++)
            {
                queryCondition += _tmpTable.Columns[i].ColumnName + "<>'' OR ";
            }
            queryCondition = queryCondition.Substring(0, queryCondition.Length - 3);

            DataRow[] dr = _tmpTable.Select(queryCondition);
            if (dr.Length == 0)
            {
                // 빈 엑셀 파일입니다.
                ltrScript.Text = JSHelper.GetAlertScript("빈 엑셀 파일입니다.", false);
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();
                return;
            }

            double _tvalue;
            //바인딩할 테이블로 인서트
            for (int i = 0; i < dr.Length; i++)
            {
                DataRow _insertRow = ExcelUnitUploadData.NewRow();
                for (int j = 0; j < _tmpTable.Columns.Count; j++)
                {
                    if (ExcelUnitUploadData.Columns[_tmpTable.Columns[j].ColumnName].DataType == typeof(double))
                    {
                        try
                        {
                            _tvalue = DataTypeUtility.GetToDouble(dr[i][_tmpTable.Columns[j].ColumnName]);
                        }
                        catch
                        {
                            _tvalue = 0;
                            //엑셀자료 중 숫자열의 데이터가 잘못 입력되었습니다.
                            ltrScript.Text = JSHelper.GetAlertScript("숫자열의 데이터가 잘못 입력되었습니다."
                                + string.Format("엑셀자료[{0}:{1}]", DataTypeUtility.GetInt32ToAlphabet(j + 1), i + 4), false);
                            excelEngine.ThrowNotSavedOnDestroy = false;
                            excelEngine.Dispose();
                            return;
                        }
                        _insertRow[_tmpTable.Columns[j].ColumnName] = _tvalue;
                    }
                    else
                    {
                        _insertRow[_tmpTable.Columns[j].ColumnName] = dr[i][_tmpTable.Columns[j].ColumnName];
                    }
                }
                _insertRow["RDTERM"] = ddlEstTermMonth.SelectedValue;
                _insertRow["RDDATE"] = "00";
                ExcelUnitUploadData.Rows.Add(_insertRow);
            }
            ExcelUnitUploadData.AcceptChanges();

            //바인딩
            ugrdPreview.Clear();
            ugrdPreview.DataSource = ExcelUnitUploadData;
            ugrdPreview.DataBind();

            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();

            // 업로드하였습니다.
            ltrScript.Text = JSHelper.GetAlertScript("업로드하였습니다.", false);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            ltrScript.Text = JSHelper.GetAlertScript("업로드 중 오류가 발생하였습니다.", false);
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
        }
    }

    protected void iBtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        ExcelEngine excelEngine = new ExcelEngine();
        IApplication application = excelEngine.Excel;
        IWorkbook workbook = application.Workbooks.Create(1);
        IWorksheet sheet = workbook.Worksheets[0];

        try
        {
            //타이틀 정의(DICODE(DICODE), 실적년월(RDTERM))
            sheet.Range[1, 1, 1, 4].Merge();
            sheet.Range[1, 1, 1, 4].Text = "DICODE : " + txtDICODE.Text.Trim() + "  /  실적년월 : " + ddlEstTermMonth.SelectedValue;
            sheet.Range[1, 1, 1, 4].CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
            sheet.Range[1, 1, 1, 4].CellStyle.Font.Color = ExcelKnownColors.White;
            sheet.Range[1, 1, 1, 4].CellStyle.Font.Bold = true;
            sheet.Range[1, 1, 1, 4].VerticalAlignment = ExcelVAlign.VAlignCenter;
            sheet.Range[1, 1, 1, 4].HorizontalAlignment = ExcelHAlign.HAlignCenter;

            for (int i = 2; i < ugrdPreview.Columns.Count; i++)
            {
                if (ugrdPreview.Columns[i].DataType == "System.String")
                {
                    sheet.Range[2, i - 1, 2, i - 1].Text = ugrdPreview.Columns[i].Key.Replace("SVALUES", "문자컬럼");
                    sheet.Range[string.Format("{0}4:{0}10000", DataTypeUtility.GetInt32ToAlphabet(i - 1))].NumberFormat = "@";
                }
                else
                {
                    string dFormat = ugrdPreview.Columns[i].Format;
                    if (dFormat.IndexOf(".") > 0)
                    {
                        dFormat = dFormat.Substring(0, dFormat.IndexOf(".") + 1) 
                            + dFormat.Substring(dFormat.IndexOf(".") + 1, dFormat.Length - (dFormat.IndexOf(".") + 1)).Replace("#", "0");
                    }
                    sheet.Range[2, i - 1, 2, i - 1].Text = ugrdPreview.Columns[i].Key.Replace("DVALUES", "숫자컬럼");
                    sheet.Range[string.Format("{0}4:{0}10000", DataTypeUtility.GetInt32ToAlphabet(i - 1))].NumberFormat = dFormat;
                }
                sheet.Range[2, i - 1, 2, i - 1].CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                sheet.Range[2, i - 1, 2, i - 1].CellStyle.Font.Color = ExcelKnownColors.White;
                sheet.Range[2, i - 1, 2, i - 1].CellStyle.Font.Bold = true;
                sheet.Range[2, i - 1, 2, i - 1].VerticalAlignment = ExcelVAlign.VAlignCenter;
                sheet.Range[2, i - 1, 2, i - 1].HorizontalAlignment = ExcelHAlign.HAlignCenter;

                sheet.Range[3, i - 1, 3, i - 1].Text = ugrdPreview.Columns[i].Header.Caption;
                sheet.Range[3, i - 1, 3, i - 1].AddComment().Text = ugrdPreview.Columns[i].Key;
                sheet.Range[3, i - 1, 3, i - 1].CellStyle.ColorIndex = ExcelKnownColors.Blue_grey;
                sheet.Range[3, i - 1, 3, i - 1].CellStyle.Font.Color = ExcelKnownColors.White;
                sheet.Range[3, i - 1, 3, i - 1].CellStyle.Font.Bold = true;
                sheet.Range[3, i - 1, 3, i - 1].ColumnWidth = ugrdPreview.Columns[i].Width.Value / 7;
                sheet.Range[3, i - 1, 3, i - 1].VerticalAlignment = ExcelVAlign.VAlignCenter;
                sheet.Range[3, i - 1, 3, i - 1].HorizontalAlignment = ExcelHAlign.HAlignCenter;
            }

            string _filename = "BSC_INTERFACE_DATA_" 
                + txtDICODE.Text.Trim() 
                + "_" + txtDINAME.Text.Trim() 
                + "_" + ddlEstTermMonth.SelectedItem.Value 
                + ".xls";
            sheet.Name = _filename;
            _filename = HttpUtility.UrlEncode(_filename, System.Text.Encoding.UTF8);
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

    protected void ddlEstTermMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdPreview.Clear();
        this.SetPreviewGrid();
        DoBinding();
    }
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        ugrdPreview.Clear();
        this.SetPreviewGrid();
        DoBinding();
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        DoSaving();
    }

    private void DoSaving()
    {
        if (ugrdPreview.Rows.Count == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("저장할 정보가 없습니다.");
            return;
        }

        Biz_Bsc_Interface_Datasource _bizInterData = new Biz_Bsc_Interface_Datasource();
        DataTable _insertTable = _bizInterData.GetInsertSchema();

        // 컬럼 데이터타입 확인
        object[] typeObject = new object[ugrdPreview.Columns.Count];
        for (int i = 0; i < ugrdPreview.Columns.Count; i++)
        {
            typeObject[i] = ugrdPreview.Columns[i].DataType;
        }

        object insertData;
        for (int i = 0; i < ugrdPreview.Rows.Count; i++)
        {
            DataRow dr = _insertTable.NewRow();
            dr["DICODE"] = txtDICODE.Text.Trim();
            dr["SEQUENCE"] = i + 1;
            dr["INPUT_TYPE"] = ddlINPUT_TYPE.SelectedIndex + 1;// ddlINPUT_TYPE.SelectedValue;
            dr["RESULT_DATE"] = DateTime.Now.ToString("yyyy/MM/dd");
            dr["RD_STATUS"] = 1; 
            dr["CREATE_DATE"] = DateTime.Now.ToString();
            dr["CREATE_USER"] = EMP_REF_ID;

            for (int j = 0; j < ugrdPreview.Columns.Count; j++)
            {
                insertData = ugrdPreview.Rows[i].Cells.FromKey(ugrdPreview.Columns[j].Key).Value;
                if (insertData == null || insertData == DBNull.Value)
                {
                    if (typeObject[j].ToString() == "System.String")
                    {
                        dr[ugrdPreview.Columns[j].Key] = "";
                    }
                    else
                    {
                        dr[ugrdPreview.Columns[j].Key] = 0;
                    }
                }
                else
                {
                    dr[ugrdPreview.Columns[j].Key] = insertData;
                }
            }
            _insertTable.Rows.Add(dr);
        }
        _insertTable.AcceptChanges();

        bool isOK = _bizInterData.InsertInterfaceData(_insertTable, false);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장하였습니다.");
            DoBinding();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }

    private void DoBinding()
    {
        Biz_Bsc_Interface_Datasource _bizInterData = new Biz_Bsc_Interface_Datasource();
        DataSet _interfaceData = _bizInterData.GetInterfaceData(txtDICODE.Text.Trim(), ddlEstTermMonth.SelectedValue, ddlINPUT_TYPE.SelectedIndex + 1, "00");
        ugrdPreview.Clear();
        ugrdPreview.DataSource = _interfaceData;
        ugrdPreview.DataBind();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "D";
        bool bRtn  = this.TrxFormData();

        if (bRtn)
        {
            this.IType = "D";
            this.SetFormData();
        }
        else
        {
            this.IType = "U";
        }
    }

    protected void iBtnClear_Click(object sender, ImageClickEventArgs e)
    {
        this.IType   = "A";
        this.IDiCode = "";
        this.InitForm();
    }

    protected void iBtnReUse_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "R";
        bool bRtn = this.TrxFormData();

        if (bRtn)
        {
            this.IType = "U";
            this.SetFormData();
        }
        else
        {
            this.IType = "R";
        }
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //DataRowView dr = (DataRowView)e.Data;

        //EmpInfos empInfo = new EmpInfos();

        //int empId = int.Parse(dr["EMP_REF_ID"].ToString());

        //e.Row.Cells.FromKey("MODIFY").Value = string.Format(
        //            "<a href=\"#null\" onclick=\"openwindow('Modify', '{0}');\"><img src='../images/drafts.gif' border='0'></a>", empId.ToString());

        //e.Row.Cells.FromKey("ROLE").Value = string.Format(
        //            "<a href=\"#null\" onclick=\"gfOpenWindow('ctl2100_Role.aspx?emp_ref_id={0}&CCB1={1}', 600, 460, true, true, 'editForm')\"><img src='../images/drafts.gif' border='0'></a>", empId.ToString(), this.ICCB1);

        //e.Row.Cells.FromKey("EMP_NAMES").Value = empInfo.GetRoleNamesArray(empId);
    }
    protected void ugrdPreview_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (ugrdPreview.Columns.Count > 1)
        {
            ugrdPreview.Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            ugrdPreview.Columns[0].AllowUpdate = AllowUpdate.No;
            ugrdPreview.Columns[1].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            ugrdPreview.Columns[1].AllowUpdate = AllowUpdate.No;
        }
        for (int i = 0; i < ugrdPreview.Columns.Count; i++)
        {
            if (ugrdPreview.Columns[i].DataType == "System.Double")
                ugrdPreview.Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
        }
    }

    protected void ugrdDiCodeTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        if (e.Tab.Key == "3")
        {
            if (txtDICODE.ReadOnly == false)
            {
                ltrScript.Text = JSHelper.GetAlertScript("먼저 기본정보를 저장하세요.", false);
                ugrdDiCodeTab.SelectedTab = 0;
                return;
            }
            this.SetPreviewGrid();
            ddlINPUT_TYPE.Enabled = ddlSOURCE_ID.Enabled = false;
            txtDINAME.ReadOnly = txtDEFINITION.ReadOnly = true;
            DoBinding();
        }
        else
        {
            ddlINPUT_TYPE.Enabled = ddlSOURCE_ID.Enabled = true;
            txtDINAME.ReadOnly = txtDEFINITION.ReadOnly = false;
        }
        SetButton();
    }

    protected void lstListField_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.OperatorButton_Click(sender, e);
    }
    #endregion
}
