using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.RolesBasedAthentication;

public partial class BSC_BSC0581M1 : AppPageBase
{
    private int _iestterm_ref_id = 0;
    private string _iresult_input_method = "";
    private string _ikpi_code = "";
    private string _ikpi_name = "";
    private string _iemp_name = "";
    private int _iest_dept_id = 0;
    private int _ilogin_id = 0;
    private string _iymd = "";

    public int EstTermRefId
    {
        get { return _iestterm_ref_id; }
        set { _iestterm_ref_id = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.NotPostBackSetting();
            this.iBtnApply.OnClientClick = "ApplyIFResult('" + this.ugridKpiTargetList.ClientID + "'); return false";
            this.iBtnUpdate.OnClientClick = "return UpdateResults('" + this.ugridKpiTargetList.ClientID + "')";
        }
        else
        {
            this.PostBackSetting();
        }


        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");

        if (txtDeptCode.Value == string.Empty)
        {
            _iest_dept_id = 0;
        }
        else
        {
            _iest_dept_id = int.Parse(txtDeptCode.Value);
        }

        ltrScript.Text = "";
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        //this.SetResultListGrid();

        DoBinding();
    }

    protected void iBtnSearch_Click(object sender, EventArgs e)
    {
        //this.SetResultListGrid();
        DoBinding();
    }

    protected void iBtnUpdate_Click(object sender, EventArgs e)
    {
        //setUpdate();


        DataTable dtResult = new DataTable();

        dtResult.Columns.Add("ESTTERM_REF_ID");
        dtResult.Columns.Add("KPI_REF_ID");
        dtResult.Columns.Add("YMD");
        dtResult.Columns.Add("RESULT_MS");
        dtResult.Columns.Add("RESULT_TS");
        dtResult.Columns.Add("APP_REF_ID");
        dtResult.Columns.Add("CHECK_APPING_YN");


        int iesttermRefId;
        int ikpiRefId;
        string iymd;
        int itxrUser;
        double iresultMs;
        double iresultTs;
        TemplatedColumn template;
        CellItem cellItemObject;
        Infragistics.WebUI.WebDataInput.WebNumericEdit inputTxt;


        TemplatedColumn col_cBox;
        CheckBox cBox;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in this.ugridKpiTargetList.Rows) 
        {
            
            iesttermRefId = DataTypeUtility.GetToInt32(row.Cells.FromKey("estTermRefId").Value);
            ikpiRefId     = DataTypeUtility.GetToInt32(row.Cells.FromKey("kpiRefId").Value);
            iymd          = DataTypeUtility.GetValue(row.Cells.FromKey("estYmd").Value);
            itxrUser      = DataTypeUtility.GetToInt32(this.USERID);
            
            template       = (TemplatedColumn)row.Cells.FromKey("resultMs").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            inputTxt       = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtResultMs");
            iresultMs      = inputTxt.ValueDouble;

            template = (TemplatedColumn)row.Cells.FromKey("resultTs").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            inputTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtResultTs");
            iresultTs = inputTxt.ValueDouble;

            col_cBox = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            cBox = (CheckBox)((CellItem)col_cBox.CellItems[row.BandIndex]).FindControl("cBox");

            string check_apping_yn = DataTypeUtility.GetBooleanToYN(cBox.Checked);

            DataRow rowResult = dtResult.NewRow();

            rowResult["ESTTERM_REF_ID"] = iesttermRefId;
            rowResult["KPI_REF_ID"]     = ikpiRefId;
            rowResult["YMD"]            = iymd;
            rowResult["RESULT_MS"]      = iresultMs;
            rowResult["RESULT_TS"]      = iresultTs;
            rowResult["APP_REF_ID"]     = iesttermRefId;
            rowResult["CHECK_APPING_YN"] = check_apping_yn;
            

            dtResult.Rows.Add(rowResult);
        }

        string pagePath = this.Page.Request.Url.AbsolutePath;

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result bizBscKpiResult = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result();

        string returnVal = bizBscKpiResult.ModifyKpiResultDataBulker_DB(dtResult
                                                                        , ""
                                                                        , this.gUserInfo.Emp_Ref_ID
                                                                        , DateTime.Now.ToString("yyyy-MM-dd"));

        string msg = returnVal;

        if (returnVal.Equals(string.Empty))
        {
            msg = "저장 되었습니다.";
        }

        ltrScript.Text = JSHelper.GetAlertScript(msg);
    }

    protected void ugridKpiTargetList_InitializeRow(object sender, RowEventArgs e)
    {
        UltraWebGrid grid = (UltraWebGrid)sender;
        DataRowView view = (DataRowView)e.Data;

        TemplatedColumn template;
        CellItem cellItemObject;
        int userRefId = ((MicroBSC.RolesBasedAthentication.SiteIdentity)this.User.Identity).Emp_Ref_ID;

        // RESULT_MS의 값을 세팅
        template = (TemplatedColumn)e.Row.Cells.FromKey("resultMs").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];

        Infragistics.WebUI.WebDataInput.WebNumericEdit txtMs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtResultMs");
        txtMs.Value = view["RESULT_MS"].ToString();

        // RESULT_TS의 값을 세팅
        template = (TemplatedColumn)e.Row.Cells.FromKey("resultTs").Column;
        cellItemObject = (CellItem)template.CellItems[e.Row.Index];

        Infragistics.WebUI.WebDataInput.WebNumericEdit txtTs = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtResultTs");
        txtTs.Value = view["RESULT_TS"].ToString();

        if (userRefId.ToString().Equals(view["CHAMPION_EMP_ID"].ToString()) == false)
        {
            //txtMs.Enabled = false;
            //txtTs.Enabled = false;
        }

        TemplatedColumn col_cBox = (TemplatedColumn)(e.Row.Cells.FromKey("selchk").Column);
        CheckBox cBox = (CheckBox)((CellItem)col_cBox.CellItems[e.Row.BandIndex]).FindControl("cBox");


        int app_ref_id = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("APP_REF_ID").Value);
        if (!app_ref_id.Equals(0))
        {
            cBox.Enabled = false;
        }


    }

    private void NotPostBackSetting()
    {
        this.InitControlValue();
        //this.SetResultListGrid();

        DoBinding();
    }

    private void PostBackSetting()
    {

    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
    }

    public void SetResultListGrid()
    {
        DataSet ds;
        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");

        if (txtDeptCode.Value == string.Empty)
        {
            _iest_dept_id = 0;
        }
        else
        {
            _iest_dept_id = int.Parse(txtDeptCode.Value);
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();

        if (((SitePrincipal)this.User).Roles.Contains("1") == true || ((SitePrincipal)this.User).Roles.Contains("8") == true)
        {
            ds = objBSC.SelectKpiList(_iestterm_ref_id, _iest_dept_id, _iymd, 0);
        }
        else
        {
            ds = objBSC.SelectKpiList(_iestterm_ref_id, _iest_dept_id, _iymd, this.gUserInfo.Emp_Ref_ID);
        }

        this.ugridKpiTargetList.DataSource = ds;
        this.ugridKpiTargetList.DataBind();

        lblRowCount.Text = ugridKpiTargetList.Rows.Count.ToString();
    }


    private void setUpdate()
    {
        int iesttermRefId;
        int ikpiRefId;
        string iymd;
        int itxrUser;
        double iresultMs;
        double iresultTs;
        TemplatedColumn template;
        CellItem cellItemObject;
        Infragistics.WebUI.WebDataInput.WebNumericEdit inputTxt;


        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in this.ugridKpiTargetList.Rows) 
        {
            
            iesttermRefId = DataTypeUtility.GetToInt32(row.Cells.FromKey("estTermRefId").Value);
            ikpiRefId     = DataTypeUtility.GetToInt32(row.Cells.FromKey("kpiRefId").Value);
            iymd          = DataTypeUtility.GetValue(row.Cells.FromKey("estYmd").Value);
            itxrUser      = DataTypeUtility.GetToInt32(this.USERID);
            
            template       = (TemplatedColumn)row.Cells.FromKey("resultMs").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            inputTxt       = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtResultMs");
            iresultMs      = inputTxt.ValueDouble;

            template = (TemplatedColumn)row.Cells.FromKey("resultTs").Column;
            cellItemObject = (CellItem)template.CellItems[row.Index];
            inputTxt = (Infragistics.WebUI.WebDataInput.WebNumericEdit)cellItemObject.FindControl("txtResultTs");
            iresultTs = inputTxt.ValueDouble;

            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Result();
            int result = objBSC.UpdateKpiResult(null, null, iesttermRefId, ikpiRefId, iymd, itxrUser, iresultMs, iresultTs);
        }


        ltrScript.Text = JSHelper.GetAlertScript("저장이 완료되었습니다.");
    }

    private void DoBinding()
    {
        DataSet ds;

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result bizBscKpiResult = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Result();
        int emp_id = this.gUserInfo.Emp_Ref_ID;

        if (this.EMP_ROLES.Contains("1") || this.EMP_ROLES.Contains("8"))
        {
            emp_id = 0;
        }

        ds = bizBscKpiResult.SelectKpiList(_iestterm_ref_id, _iest_dept_id, _iymd, emp_id);

        this.ugridKpiTargetList.DataSource = ds;
        this.ugridKpiTargetList.DataBind();

        lblRowCount.Text = ugridKpiTargetList.Rows.Count.ToString();

        DataRow[] rows = ds.Tables[0].Select(" CLOSE_YN = 'Y' ");

        if (rows.Length > 0)
        {
            lblMsg.Text = "마감된 평가 기간 입니다.";
            iBtnApply.Visible = false;
            iBtnUpdate.Visible = false;
        }
        else
        {
            lblMsg.Text = string.Empty;
            iBtnApply.Visible = true;
            iBtnUpdate.Visible = true;
        }

    }
}

