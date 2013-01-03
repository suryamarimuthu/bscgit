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

public partial class ctl_ctl4302 : AppPageBase
{

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

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            SetPageData();
            SetGridBind();
        }
        else
        { 
        
        }
    }


    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
    }

    private void SetPageData()
    {
        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetDeptTypeDropDownList(ddlDeptType,true);
        }
           this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
               
    }

    private void SetGridBind()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Est_Dept_Grade objGrade = new MicroBSC.BSC.Biz.Biz_Bsc_Est_Dept_Grade();
        DataSet rDs = objGrade.GetAllList(this.IEstTermRefID,PageUtility.GetIntByValueDropDownList(ddlDeptType));
        ugrdGradeList.Clear();
        ugrdGradeList.DataSource = rDs;
        ugrdGradeList.DataBind();

        if (PageUtility.GetIntByValueDropDownList(ddlDeptType) < 1)
        {
            iBtnUpdate.Visible   = false;
            ImgBtnAddRow.Visible = false;
        }
        else
        {
            iBtnUpdate.Visible   = true;
            ImgBtnAddRow.Visible = true;
        }
    }


    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGridBind();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetGridBind();
    }
    
    
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        int cntAffRow = this.UpdateGrade();
        SetGridBind();
    }
  
    protected void ImgBtnAddRow_Click(object sender, ImageClickEventArgs e)
    {
        int cntRow = 0;
        ugrdGradeList.Rows.Add();
        cntRow = ugrdGradeList.Rows.Count - 1;



        DropDownList ddlTempYN;
        TemplatedColumn yn_col = (TemplatedColumn)ugrdGradeList.Columns.FromKey("USE_YN");

        ddlTempYN = (DropDownList)((CellItem)yn_col.CellItems[ugrdGradeList.Rows[cntRow].BandIndex]).FindControl("ddlUse_YN");


        ddlTempYN.Items.Add(new ListItem("사용", "Y"));
        ddlTempYN.Items.Add(new ListItem("미사용", "N"));



        DropDownList ddlTempGradeYN;
        TemplatedColumn grade_col = (TemplatedColumn)ugrdGradeList.Columns.FromKey("MID_GRADE_YN");

        ddlTempGradeYN = (DropDownList)((CellItem)grade_col.CellItems[ugrdGradeList.Rows[cntRow].BandIndex]).FindControl("ddlMidGrade_YN");


        //ddlTempGradeYN.Items.Add(new ListItem("사용", "Y"));
        //ddlTempGradeYN.Items.Add(new ListItem("미사용", "N"));

        //ddlTempGradeYN.SelectedIndex = 1;

        UltraGridRow row;

        row = ugrdGradeList.Rows[cntRow];

        ugrdGradeList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
        ugrdGradeList.Rows[cntRow].Cells.FromKey("EST_DEPT_TYPE").Value = PageUtility.GetByValueDropDownList(ddlDeptType);
        ugrdGradeList.Rows[cntRow].Cells.FromKey("TYPE_NAME").Value     = PageUtility.GetByTextDropDownList(ddlDeptType);
    }

    protected void ugrdGradeList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (PageUtility.GetIntByValueDropDownList(ddlDeptType) > 0 && ddlDeptType.Items.Count > 0)
        {
            e.Layout.CellClickActionDefault = CellClickAction.RowSelect;
            e.Layout.Bands[0].Columns.FromKey("GRADE_NAME").AllowUpdate = AllowUpdate.Yes;
            e.Layout.Bands[0].Columns.FromKey("MIN_VALUE").AllowUpdate  = AllowUpdate.Yes;
            e.Layout.Bands[0].Columns.FromKey("MAX_VALUE").AllowUpdate  = AllowUpdate.Yes;
            e.Layout.Bands[0].Columns.FromKey("SORT_ORDER").AllowUpdate = AllowUpdate.Yes;
        }
        else
        {
            e.Layout.Bands[0].Columns.FromKey("GRADE_NAME").AllowUpdate = AllowUpdate.NotSet;
            e.Layout.Bands[0].Columns.FromKey("MIN_VALUE").AllowUpdate  = AllowUpdate.NotSet;
            e.Layout.Bands[0].Columns.FromKey("MAX_VALUE").AllowUpdate  = AllowUpdate.NotSet;
            e.Layout.Bands[0].Columns.FromKey("SORT_ORDER").AllowUpdate = AllowUpdate.NotSet;
        }
    }

    protected void ugrdGradeList_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;


        e.Row.Cells.FromKey("ITYPE").Value = "U";

        DropDownList ddlTempYN;
        TemplatedColumn yn_col = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");

        ddlTempYN = (DropDownList)((CellItem)yn_col.CellItems[e.Row.BandIndex]).FindControl("ddlUse_YN");


        ddlTempYN.Items.Add(new ListItem("사용", "Y"));
        ddlTempYN.Items.Add(new ListItem("미사용", "N"));

        PageUtility.FindByValueDropDownList(ddlTempYN, e.Row.Cells.FromKey("USE_YN").Value.ToString());

        CheckBox chkMidGradeTemp ;
        TemplatedColumn home_yn_col;


        home_yn_col = (TemplatedColumn)e.Row.Band.Columns.FromKey("MID_GRADE_YN");

        chkMidGradeTemp = (CheckBox)((CellItem)home_yn_col.CellItems[e.Row.BandIndex]).FindControl("chkMidGrade_YN");

        

        if (drw["MID_GRADE_YN"].ToString() == "Y")
            chkMidGradeTemp.Checked = true;
        else
            chkMidGradeTemp.Checked = false;

        chkMidGradeTemp.Attributes.Add("onclick", "return selectChkBox(this, '" + ((UltraWebGrid)sender).ClientID + "');");
    }


    private int UpdateGrade()
    {
        UltraGridRow row;
        int intTxrUser = gUserInfo.Emp_Ref_ID;
        int intRtn = 0;
        int intRow = ugrdGradeList.Rows.Count;

        MicroBSC.BSC.Biz.Biz_Bsc_Est_Dept_Grade objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Est_Dept_Grade();

        CheckBox chkTempGradeYN;
        TemplatedColumn grade_col = (TemplatedColumn)ugrdGradeList.Columns.FromKey("MID_GRADE_YN");

        DropDownList ddlTempYN;
        TemplatedColumn yn_col = (TemplatedColumn)ugrdGradeList.Columns.FromKey("USE_YN");


        for (int i = 0; i < intRow; i++)
        {
            row = ugrdGradeList.Rows[i];

            string iType        = Convert.ToString(row.Cells.FromKey("ITYPE").Value.ToString());
            int iEstterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            int iEstDeptType    = (row.Cells.FromKey("EST_DEPT_TYPE").Value == null) ? 0 : Convert.ToInt32(row.Cells.FromKey("EST_DEPT_TYPE").Value.ToString());
            int iGradeRefId     = (row.Cells.FromKey("GRADE_REF_ID").Value == null) ? 0 : Convert.ToInt32(row.Cells.FromKey("GRADE_REF_ID").Value.ToString());
            string iGradeName   = row.Cells.FromKey("GRADE_NAME").ToString();
            double iMinValue    = Convert.ToDouble(row.Cells.FromKey("MIN_VALUE").Value);
            double iMaxValue    = Convert.ToDouble(row.Cells.FromKey("MAX_VALUE").Value);

            chkTempGradeYN      = (CheckBox)((CellItem)grade_col.CellItems[ugrdGradeList.Rows[i].BandIndex]).FindControl("chkMidGrade_YN");
            int iSort_order     = Convert.ToInt32(row.Cells.FromKey("SORT_ORDER").Value.ToString());
            ddlTempYN           = (DropDownList)((CellItem)yn_col.CellItems[ugrdGradeList.Rows[i].BandIndex]).FindControl("ddlUse_YN");
            int iuser           = intTxrUser;


            if (iType == "U")
            {
                intRtn += objBSC.UpdateData(iEstterm_ref_id
                                          , iEstDeptType
                                          , iGradeRefId
                                          , iGradeName
                                          , iMinValue
                                          , iMaxValue
                                          , (chkTempGradeYN.Checked == true)? "Y": "N"
                                          , iSort_order
                                          , ddlTempYN.SelectedValue.ToString()
                                          , iuser);
            }
            else if (iType == "A")
            {
                intRtn += objBSC.InsertData(iEstterm_ref_id
                                          , iEstDeptType
                                          , iGradeRefId
                                          , iGradeName
                                          , iMinValue
                                          , iMaxValue
                                          , (chkTempGradeYN.Checked == true) ? "Y" : "N"
                                          , iSort_order
                                          , ddlTempYN.SelectedValue.ToString()
                                          , iuser);
            }
        }

        return intRtn;
    }


    protected void ddlDeptType_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGridBind();
    }
}
