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
using MicroBSC.Common;

public partial class ctl_ctl4301 : AppPageBase
{
    public int IcategoryTopRefID
    {
        get
        {
            if (ViewState["CATEGORY_TOP_REF_ID"] == null)
            {
                ViewState["CATEGORY_TOP_REF_ID"] = GetRequestByInt("CATEGORY_TOP_REF_ID", 0);
            }

            return (int)ViewState["CATEGORY_TOP_REF_ID"];
        }
        set
        {
            ViewState["CATEGORY_TOP_REF_ID"] = value;
        }
    }

    public int IcategoryMidRefID
    {
        get
        {
            if (ViewState["CATEGORY_MID_REF_ID"] == null)
            {
                ViewState["CATEGORY_MID_REF_ID"] = GetRequestByInt("CATEGORY_MID_REF_ID", 0);
            }

            return (int)ViewState["CATEGORY_MID_REF_ID"];
        }
        set
        {
            ViewState["CATEGORY_MID_REF_ID"] = value;
        }
    }

    public int IcategoryLowRefID
    {
        get
        {
            if (ViewState["CATEGORY_LOW_REF_ID"] == null)
            {
                ViewState["CATEGORY_LOW_REF_ID"] = GetRequestByInt("CATEGORY_LOW_REF_ID", 0);
            }

            return (int)ViewState["CATEGORY_LOW_REF_ID"];
        }
        set
        {
            ViewState["CATEGORY_LOW_REF_ID"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.FormInit();
        }
        else
        { 
        
        }

        ltrScript.Text = "";
    }

    public void FormInit()
    {
        this.SetCategoryTopGrid();

        if (ugrdCategoryTop.Rows.Count > 0)
        {
            ugrdCategoryTop.Rows[0].Selected = true;
            this.IcategoryTopRefID = Convert.ToInt32(ugrdCategoryTop.Rows[0].Cells.FromKey("CATEGORY_TOP_REF_ID").ToString());
            this.SetTopCategoryInfo();
            this.SetCategoryMidGrid();

            if (ugrdCategoryMid.Rows.Count > 0)
            {
                ugrdCategoryMid.Rows[0].Selected = true;
                this.IcategoryMidRefID = Convert.ToInt32(ugrdCategoryMid.Rows[0].Cells.FromKey("CATEGORY_MID_REF_ID").ToString());
                SetMidCategoryInfo();
                this.SetCategoryLowGrid();

                if (ugrdCategoryLow.Rows.Count > 0)
                {
                    ugrdCategoryLow.Rows[0].Selected = true;
                    this.IcategoryLowRefID = Convert.ToInt32(ugrdCategoryLow.Rows[0].Cells.FromKey("CATEGORY_LOW_REF_ID").ToString());

                    this.SetLowCategoryInfo();
                }
                else
                {
                    this.ClearCategoryLow();
                }
            }
            else
            {
                ugrdCategoryLow.Clear();
            }
        }
        else
        {
            ugrdCategoryMid.Clear();
            ugrdCategoryLow.Clear();
        }
    }

    
    public void ChangeTopGrid()
    {
       
        this.ClearCategoryMid();
        this.ClearCategoryLow();
        ugrdCategoryLow.Clear();
             

        this.SetCategoryMidGrid();

        if (ugrdCategoryMid.Rows.Count > 0)
        {
            ugrdCategoryMid.Rows[this.IcategoryMidRefID].Selected = true;
            this.IcategoryMidRefID = Convert.ToInt32(ugrdCategoryMid.Rows[this.IcategoryMidRefID].Cells.FromKey("CATEGORY_MID_REF_ID").ToString());

            this.SetMidCategoryInfo();

            this.SetCategoryLowGrid();
        }
        else
        {
            ugrdCategoryMid.Clear();
            ugrdCategoryLow.Clear();
        }
    }

    public void ChangeMidGrid()
    {
        ugrdCategoryLow.Clear();

        if (ugrdCategoryMid.Rows.Count > 0)
        {
            //this.IcategoryMidRefID = Convert.ToInt32(ugrdCategoryMid.Rows[0].Cells.FromKey("CATEGORY_MID_REF_ID").ToString());
            this.SetCategoryLowGrid();
        }
        else
        {
            ugrdCategoryMid.Clear();
        }
    }

    public void SetCategoryTopGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top();
        DataSet rDs = objBSC.GetAllList();

        ugrdCategoryTop.Clear();
        ugrdCategoryTop.DataSource = rDs;
        ugrdCategoryTop.DataBind();

        if (ugrdCategoryTop.Rows.Count < 1)
        {
            iBtnAddTop.Visible = true;
            iBtnUdtTop.Visible = true;
        }
        else
        { 
            iBtnAddTop.Visible = true;
            iBtnUdtTop.Visible = true;
        }
    }

    public void SetCategoryMidGrid()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid();
        DataSet rDs = objBSC.GetAllList(this.IcategoryTopRefID);

        ugrdCategoryMid.Clear();
        ugrdCategoryMid.DataSource = rDs;
        ugrdCategoryMid.DataBind();

        this.IcategoryMidRefID = 0;

        if (ugrdCategoryMid.Rows.Count < 1)
        {
            iBtnAddMid.Visible = true;
            iBtnUdtMid.Visible = true;
        }
        else
        {
           

            iBtnAddMid.Visible = true;
            iBtnUdtMid.Visible = true;
        }
    }

    public void SetCategoryLowGrid()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low();
        DataSet rDs = objBSC.GetAllList(this.IcategoryTopRefID, this.IcategoryMidRefID);

        ugrdCategoryLow.Clear();
        ugrdCategoryLow.DataSource = rDs;
        ugrdCategoryLow.DataBind();

        this.IcategoryLowRefID = 0;

        if (ugrdCategoryLow.Rows.Count < 1)
        {
            iBtnAddLow.Visible = true;
            iBtnUdtLow.Visible = true;
        }
        else
        {
            ugrdCategoryLow.Rows[this.IcategoryLowRefID].Selected = true;
            this.IcategoryLowRefID = Convert.ToInt32(ugrdCategoryLow.Rows[this.IcategoryLowRefID].Cells.FromKey("CATEGORY_LOW_REF_ID").ToString());
          
            this.SetLowCategoryInfo();

            iBtnAddLow.Visible = true;
            iBtnUdtLow.Visible = true;
        }
    }

    public void SetTopCategoryInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top(this.IcategoryTopRefID);
        txtTopCatName.Text = objBSC.Icategory_top_name;
        txtTopCatDesc.Text = objBSC.Icategory_desc;
        chkTopUseYn.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
    }

    public void SetMidCategoryInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid(this.IcategoryTopRefID, this.IcategoryMidRefID);
        txtMidCatName.Text = objBSC.Icategory_mid_name;
        txtMidCatDesc.Text = objBSC.Icategory_desc;
        chkMidUseYn.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
    }

    public void SetLowCategoryInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low(this.IcategoryTopRefID, this.IcategoryMidRefID, this.IcategoryLowRefID);
        txtLowCatName.Text = objBSC.Icategory_low_name;
        txtLowCatDesc.Text = objBSC.Icategory_desc;
        chkLowUseYn.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
    }

    private void ClearCategoryTop()
    {
        txtTopCatName.Text = "";
        txtTopCatDesc.Text = "";
        chkTopUseYn.Checked = false;
    }

    private void ClearCategoryMid()
    {
        txtMidCatName.Text = "";
        txtMidCatDesc.Text = "";
        chkMidUseYn.Checked = false;
    }

    private void ClearCategoryLow()
    {
        txtLowCatName.Text = "";
        txtLowCatDesc.Text = "";
        chkLowUseYn.Checked = false;
    }


    #region 등록/ 수정
    public void SaveTopCategoyInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top objTop = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top();
        int intRtn = objTop.InsertData
                     ( txtTopCatName.Text
                     , txtTopCatDesc.Text
                     , (chkTopUseYn.Checked) ? "Y" : "N"
                     , gUserInfo.Emp_Ref_ID
                     );

        if (objTop.Transaction_Result == "Y")
        {
            this.IcategoryTopRefID = objTop.Icategory_top_ref_id;
            this.SetCategoryTopGrid();
        }
    }

    public void SaveMidCategoyInfo()
    {
        if (this.IcategoryTopRefID < 1)
        {
            ltrScript.Text = JSHelper.GetBlankScript("상위분류를 선택해주십시오");
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid objMid = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid();
        int intRtn = objMid.InsertData
                     ( this.IcategoryTopRefID 
                     , txtMidCatName.Text
                     , txtMidCatDesc.Text
                     , (chkTopUseYn.Checked) ? "Y" : "N"
                     , gUserInfo.Emp_Ref_ID
                     );

        if (objMid.Transaction_Result == "Y")
        {
            this.IcategoryMidRefID = objMid.Icategory_mid_ref_id;
            this.SetCategoryMidGrid();
        }
    }

    public void SaveLowCategoyInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objLow = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low();
        int intRtn = objLow.InsertData
                     ( this.IcategoryTopRefID 
                     , this.IcategoryMidRefID
                     , txtLowCatName.Text
                     , txtLowCatDesc.Text
                     , (chkLowUseYn.Checked) ? "Y" : "N"
                     , gUserInfo.Emp_Ref_ID
                     );
        if (objLow.Transaction_Result == "Y")
        {
            this.IcategoryLowRefID = objLow.Icategory_low_ref_id;
            this.SetCategoryLowGrid();
        }
    }

    public void UpdateTopCategoyInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top objTop = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top();
        int intRtn = objTop.UpdateData
                     ( this.IcategoryTopRefID
                     , txtTopCatName.Text
                     , txtTopCatDesc.Text
                     , (chkTopUseYn.Checked) ? "Y" : "N"
                     , gUserInfo.Emp_Ref_ID
                     );

        if (objTop.Transaction_Result == "Y")
        {
            this.SetCategoryTopGrid();
        }

        ltrScript.Text = JSHelper.GetAlertScript(objTop.Transaction_Message, false);
    }

    public void UpdateMidCategoyInfo()
    {
        if (this.IcategoryTopRefID < 1)
        {
            ltrScript.Text = JSHelper.GetBlankScript("상위분류를 선택해주십시오");
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid objMid = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid();
        int intRtn = objMid.UpdateData
                     ( this.IcategoryTopRefID 
                     , this.IcategoryMidRefID
                     , txtMidCatName.Text
                     , txtMidCatDesc.Text
                     , (chkMidUseYn.Checked) ? "Y" : "N"
                     , gUserInfo.Emp_Ref_ID
                     );

        if (objMid.Transaction_Result == "Y")
        {
            this.SetCategoryMidGrid();
        }
    }

    public void UpdateLowCategoyInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objLow = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low();
        int intRtn = objLow.UpdateData
                     ( this.IcategoryTopRefID 
                     , this.IcategoryMidRefID
                     , this.IcategoryLowRefID
                     , txtLowCatName.Text
                     , txtLowCatDesc.Text
                     , (chkLowUseYn.Checked) ? "Y" : "N"
                     , gUserInfo.Emp_Ref_ID
                     );
        if (objLow.Transaction_Result == "Y")
        {
            this.SetCategoryLowGrid();
        }
    }
    #endregion

    

    protected void iBtnAddTop_Click(object sender, ImageClickEventArgs e)
    {
        this.SaveTopCategoyInfo();
    }

    protected void iBtnUdtTop_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateTopCategoyInfo();
    }

    protected void iBtnDelTop_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnAddMid_Click(object sender, ImageClickEventArgs e)
    {
        this.SaveMidCategoyInfo();
    }

    protected void iBtnUdtMid_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateMidCategoyInfo();
    }

    protected void iBtnDelMid_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void iBtnAddLow_Click(object sender, ImageClickEventArgs e)
    {
        this.SaveLowCategoyInfo();
    }

    protected void iBtnUdtLow_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateLowCategoyInfo();
    }

    protected void iBtnDelLow_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ugrdCategoryTop_InitializeRow(object sender, RowEventArgs e)
    {

    }
    protected void ugrdCategoryMid_InitializeRow(object sender, RowEventArgs e)
    {

    }
    protected void ugrdCategoryLow_InitializeRow(object sender, RowEventArgs e)
    {

    }
    protected void ugrdCategoryTop_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.ClearCategoryTop();

        this.IcategoryTopRefID = Convert.ToInt32(e.Row.Cells.FromKey("CATEGORY_TOP_REF_ID").ToString());
        this.SetTopCategoryInfo();
        this.ChangeTopGrid();        
    }
    protected void ugrdCategoryMid_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.ClearCategoryMid();
        this.ClearCategoryLow();

        this.IcategoryMidRefID = Convert.ToInt32(e.Row.Cells.FromKey("CATEGORY_MID_REF_ID").ToString());
        ugrdCategoryMid.Rows[e.Row.Index].Selected = true;

        this.SetMidCategoryInfo();
        this.ChangeMidGrid();        
    }
    protected void ugrdCategoryLow_ActiveRowChange(object sender, RowEventArgs e)
    {
        this.ClearCategoryLow();

        this.IcategoryLowRefID = Convert.ToInt32(e.Row.Cells.FromKey("CATEGORY_LOW_REF_ID").ToString());
         ugrdCategoryLow.Rows[e.Row.Index].Selected = true;
        this.SetLowCategoryInfo();

    }
}
