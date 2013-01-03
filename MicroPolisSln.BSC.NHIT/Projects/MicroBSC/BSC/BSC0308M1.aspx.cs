using System;
using System.Data;
using System.Web.UI;

public partial class BSC_BSC0308M1 : AppPageBase
{

    protected int IESTTERM_REF_ID
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
    private int tRow = 0;
    private int tCol = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }
        ltrScript.Text = "";

        this.ugrdGroupList.Columns.FromKey("CHAMPION_NAME").Header.Caption = this.GetText("LBL_00001", "챔피언");
        this.ugrdKpiList.Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "챔피언");
    }

    private void DoInitControl()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group bizBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        DataTable dtGroup = bizBSC.GetIssueGroup(this.IESTTERM_REF_ID, 0);
        ddlGroup.DataValueField = "GROUP_CODE";
        ddlGroup.DataTextField = "GROUP_NAME";
        ddlGroup.DataSource = dtGroup;
        ddlGroup.DataBind();

        WebCommon.SetComDeptDropDownList(ddlComDept, true);
        PageUtility.FindByValueDropDownList(ddlComDept, BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID));
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);

        ugrdGroupList.Columns.FromKey("CHAMPION_NAME").Header.Caption = GetText("LBL_00001", "챔피언");
        ugrdKpiList.Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = GetText("LBL_00001", "챔피언");
    }
    private void DoBinding()
    {
        if (this.IESTTERM_REF_ID == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가기간을 선택하세요!");
            return;
        }
        if (ddlGroup.Items.Count == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("지표그룹을 선택하세요!");
            return;
        }
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group bizBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        DataTable dtList = bizBSC.GetGroupMapList(this.IESTTERM_REF_ID, PageUtility.GetIntByValueDropDownList(ddlGroup));
        ugrdGroupList.Clear();
        ugrdGroupList.DataSource = dtList;
        ugrdGroupList.DataBind();
    }

    private void DoBindingList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetKpiListPerUser(this.IESTTERM_REF_ID
                               , ""
                               , txtKPICode.Text.Trim()
                               , txtKPIName.Text.Trim()
                               , ""
                               , txtChamName.Text.Trim()
                               , (ddlComDept.SelectedValue.Trim() == "") ? -1 : int.Parse(ddlComDept.SelectedValue)
                               , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                               , "Y"
                               , int.Parse(gUserInfo.Emp_Ref_ID.ToString()));

        if (ds.Tables[0].Rows.Count > 0)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group objGroup = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
            DataTable dtExists = objGroup.GetGroupMapList(this.IESTTERM_REF_ID, 0);

            if (dtExists.Rows.Count > 0)
            {
                foreach (DataRow dr in dtExists.Rows)
                {
                    DataRow[] drExists = ds.Tables[0].Select("KPI_REF_ID = " + DataTypeUtility.GetToInt32(dr["KPI_REF_ID"]));
                    if (drExists.Length > 0)
                        drExists[0].Delete();
                }
            }
        }
        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = ds;
        ugrdKpiList.DataBind();

    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        ugrdGroupList.Clear();
        ugrdKpiList.Clear();
        DoBinding();
        DoBindingList();
    }

    protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBindingList();
    }
    protected void ibtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtInsert = new DataTable();
        dtInsert.Columns.Add("KPI_REF_ID", typeof(string));
        dtInsert = UltraGridUtility.GetDataTableByCheckValue(ugrdKpiList, "cBox", "selchk", new string[] { "KPI_REF_ID" }, dtInsert);

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group bizBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        if (bizBSC.InsertIssueGroupMap(this.IESTTERM_REF_ID, PageUtility.GetIntByValueDropDownList(ddlGroup), dtInsert, gUserInfo.Emp_Ref_ID))
        {
            DoBinding();
            DoBindingList();
            ltrScript.Text = JSHelper.GetAlertScript("등록하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("등록 실패!");
    }
    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtDelete = new DataTable();
        dtDelete.Columns.Add("KPI_REF_ID", typeof(string));
        dtDelete = UltraGridUtility.GetDataTableByCheckValue(ugrdGroupList, "cBox", "selchk", new string[] { "KPI_REF_ID" }, dtDelete);

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group bizBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        if (bizBSC.DeleteIssueGroupMap(this.IESTTERM_REF_ID, PageUtility.GetIntByValueDropDownList(ddlGroup), dtDelete))
        {
            DoBinding();
            DoBindingList();
            ltrScript.Text = JSHelper.GetAlertScript("삭제하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("삭제 실패!");
    }
    protected void ugrdGroupList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.TemplatedColumn cCol = (Infragistics.WebUI.UltraWebGrid.TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((Infragistics.WebUI.UltraWebGrid.CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");



        object tmp = e.Row.Cells.FromKey("USE_YN").Value;
        if (DataTypeUtility.GetString(tmp).Equals("Y"))
            objImg.ImageUrl = "../images/icon_o.gif";
        else
            objImg.ImageUrl = "../images/icon_x.gif";
        
        //objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
        //                  "../images/icon_o.gif" : "../images/icon_x.gif";




        //cCol   = (TemplatedColumn)e.Row.Band.Columns.FromKey("APPROVAL_STATUS");
        //objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        //objImg.ImageUrl = (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y") ?
        //                  "../images/icon_o.gif" : "../images/icon_x.gif";

        cCol = (Infragistics.WebUI.UltraWebGrid.TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        objImg = (System.Web.UI.WebControls.Image)((Infragistics.WebUI.UltraWebGrid.CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = (e.Row.Cells.FromKey("APP_STATUS").Value == null) ? "" : e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        MicroBSC.Biz.Common.Biz.Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = MicroBSC.Biz.Common.Biz.Biz_Com_Approval_Info.GetAppImageText(strImg);

        tRow += 1;
        if (strImg == Biz_Type.app_status_complete)
        {
            tCol += 1;
        }

        //lblRowCount.Text = tCol.ToString() + " / " + tRow.ToString();
    }

    protected void ugrdKpiList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.TemplatedColumn cCol = (Infragistics.WebUI.UltraWebGrid.TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((Infragistics.WebUI.UltraWebGrid.CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        //cCol   = (TemplatedColumn)e.Row.Band.Columns.FromKey("APPROVAL_STATUS");
        //objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        //objImg.ImageUrl = (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y") ?
        //                  "../images/icon_o.gif" : "../images/icon_x.gif";

        cCol = (Infragistics.WebUI.UltraWebGrid.TemplatedColumn)e.Row.Band.Columns.FromKey("APP_STATUS");
        objImg = (System.Web.UI.WebControls.Image)((Infragistics.WebUI.UltraWebGrid.CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgApp");
        string strImg = (e.Row.Cells.FromKey("APP_STATUS").Value == null) ? "" : e.Row.Cells.FromKey("APP_STATUS").Value.ToString();
        MicroBSC.Biz.Common.Biz.Biz_Com_Approval_Info.GetAppImageUrl(strImg);
        objImg.AlternateText = MicroBSC.Biz.Common.Biz.Biz_Com_Approval_Info.GetAppImageText(strImg);

        tRow += 1;
        if (strImg == Biz_Type.app_status_complete)
        {
            tCol += 1;
        }

        //lblRowCount.Text = tCol.ToString() + " / " + tRow.ToString();
    }
}
