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

using MicroBSC.Biz.BSC.Biz;
using MicroBSC.BSC.Biz;
using MicroBSC.Common;

public partial class ctl_ctl1114 : AppPageBase
{
    #region ============= [변수선언]====================
    private string _ikpi_group_ref_id;
    private int    _itxr_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
        }
        else
        {

        }
    }
    #endregion

    #region ============= [폼초기화]====================
    private void SetInitForm()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        this.SetKpiGroupList();
        this.SetEstLevelList();
    }

    #endregion

    #region ============= [데이터처리]====================

    private bool ValidateFormData(bool isDelete)
    {
        //if (txtVersionID.Text.Trim() == "")
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("VERSION CODE를 입력해주세요", false);
        //    return false;
        //}
        //else if (txtVersionName.Text.Trim() == "" && !isDelete)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("VERSION NAME을 입력해주세요", false);
        //    return false;
        //}
        //else if (ddlEstTermInfo.Items.Count < 1)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("평가기간이 존재하지 않습니다.", false);
        //    return false;
        //}

        //_iestterm_ref_id = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue.ToString()) : 0;
        //_ikpi_target_version_id = txtVersionID.Text.Trim();
        //_iversion_name = txtVersionName.Text.Trim();
        //_iversion_desc = txtVersionDesc.Text.Trim();
        //_iversion_number = (txtVersionNumber.Text.Trim() == "") ? 0 : int.Parse(txtVersionNumber.Text.Trim());
        //_iupdate_term = 12;
        //_iuse_yn = "Y";
        //_itxr_user = gUserInfo.Emp_Ref_ID;

        return true;
    }

    private void InsertUpdateData()
    {
        Biz_Bsc_Kpi_Qlt_Info objBSC = new Biz_Bsc_Kpi_Qlt_Info();
        UltraGridRow row;

        CheckBox chk;
        TemplatedColumn col;

        CheckBox chk1;
        TemplatedColumn col1;
        
        for (int i = 0; i < ugrdEstLevel.Rows.Count; i++)
        {
            row  = ugrdEstLevel.Rows[i];
            col  = (TemplatedColumn)row.Band.Columns.FromKey("SETTLE_MEAN_YN");
            chk  = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("chkUse");

            col1 = (TemplatedColumn)row.Band.Columns.FromKey("SETTLE_DEVIATION_YN");
            chk1 = (CheckBox)((CellItem)col1.CellItems[row.BandIndex]).FindControl("chkUse");

            if (true)
            {
                objBSC.Iestterm_ref_id      = int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                objBSC.Iest_level           = int.Parse(row.Cells.FromKey("EST_LEVEL").Value.ToString());
                objBSC.Iest_level_name      = row.Cells.FromKey("EST_LEVEL_NAME").Value.ToString();
                objBSC.Isettle_mean_yn      = (chk.Checked)  ? "Y" : "N";
                objBSC.Isettle_deviation_yn = (chk1.Checked) ? "Y" : "N";
                objBSC.Iweight              = double.Parse(row.Cells.FromKey("WEIGHT").Value.ToString());
                objBSC.Iest_order           = int.Parse(row.Cells.FromKey("EST_ORDER").Value.ToString());
                objBSC.Idescriptions        = (row.Cells.FromKey("DESCRIPTINS").Value==null) ? " " :row.Cells.FromKey("DESCRIPTINS").Value.ToString();

                objBSC.InsertData(objBSC.Iestterm_ref_id
                                , objBSC.Iest_level
                                , objBSC.Iest_level_name
                                , objBSC.Isettle_mean_yn
                                , objBSC.Isettle_deviation_yn
                                , objBSC.Iweight
                                , objBSC.Iest_order
                                , objBSC.Idescriptions
                                , gUserInfo.Emp_Ref_ID);

            }
        }
    }

    private void DeleteDataForm()
    {

    }

    private void SetKpiGroupList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Group();
        DataSet rDs = objBSC.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        ugrdKpiGroup.Clear();
        ugrdKpiGroup.DataSource = rDs;
        ugrdKpiGroup.DataBind();
    }

    private void SetEstLevelList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Qlt_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Qlt_Info();
        DataSet rDs = objBSC.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        ugrdEstLevel.Clear();
        ugrdEstLevel.DataSource = rDs;
        ugrdEstLevel.DataBind();
    }

    #endregion

    #region ============= [서버이벤트]====================

    protected void ugrdKpiGroup_ActiveRowChange(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //_ikpi_group_ref_id = (e.Row.Cells.FromKey("KPI_GROUP_REF_ID").Value == null) ? "" : e.Row.Cells.FromKey("KPI_GROUP_REF_ID").Value.ToString();
        //this.SetEstLevelList();
    }

    protected void iBtnReg_Click(object sender, ImageClickEventArgs e)
    {
        this.InsertUpdateData();
        this.SetKpiGroupList();
        this.SetEstLevelList();
    }

    protected void iBtnDel_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetKpiGroupList();
        this.SetEstLevelList();
    }

    protected void ugrdKpiGroup_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol1    = (TemplatedColumn)e.Row.Band.Columns.FromKey("NORMDIST_USE_YN");
        TemplatedColumn cCol2    = (TemplatedColumn)e.Row.Band.Columns.FromKey("MULTI_EST_USE_YN");

        CheckBox chkNormdist     = (CheckBox)((CellItem)cCol1.CellItems[e.Row.BandIndex]).FindControl("chkUse");
        CheckBox chkMultiEst     = (CheckBox)((CellItem)cCol2.CellItems[e.Row.BandIndex]).FindControl("chkUse");

        chkNormdist.Checked = (e.Row.Cells.FromKey("NORMDIST_USE_YN").Value.ToString()=="Y") ? true : false;
        chkMultiEst.Checked = (e.Row.Cells.FromKey("MULTI_EST_USE_YN").Value.ToString()=="Y") ? true : false;
    }

    protected void ugrdEstLevel_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol1 = (TemplatedColumn)e.Row.Band.Columns.FromKey("SETTLE_MEAN_YN");
        TemplatedColumn cCol2 = (TemplatedColumn)e.Row.Band.Columns.FromKey("SETTLE_DEVIATION_YN");

        CheckBox chkNormdist = (CheckBox)((CellItem)cCol1.CellItems[e.Row.BandIndex]).FindControl("chkUse");
        CheckBox chkMultiEst = (CheckBox)((CellItem)cCol2.CellItems[e.Row.BandIndex]).FindControl("chkUse");

        chkNormdist.Checked = (e.Row.Cells.FromKey("SETTLE_MEAN_YN").Value.ToString()      == "Y") ? true : false;
        chkMultiEst.Checked = (e.Row.Cells.FromKey("SETTLE_DEVIATION_YN").Value.ToString() == "Y") ? true : false;
    }
    #endregion
}
