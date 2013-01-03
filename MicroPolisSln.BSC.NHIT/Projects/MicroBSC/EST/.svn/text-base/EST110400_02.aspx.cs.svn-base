using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using MicroBSC.Estimation.Biz;

public partial class EST110400_02 : EstPageBase
{
    private int ICOMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
                ViewState["COMP_ID"] = 0;
            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }

    private string IEST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
                ViewState["EST_ID"] = "";
            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }

    protected int ISEQ
    {
        get
        {
            if (ViewState["SEQ"] == null)
                ViewState["SEQ"] = 0;
            return (int)ViewState["SEQ"];
        }
        set
        {
            ViewState["SEQ"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ICOMP_ID = WebUtility.GetRequestByInt("COMP_ID", 0);
            this.IEST_ID = WebUtility.GetRequest("EST_ID", "");

            DoInitControl();

            DoBindingColumn();
        }
        ltrScript.Text = "";
    }

    private void DoBindingColumn()
    {
        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        DataTable dtColumns = bizBiasData.GetBiasColumns(this.ICOMP_ID, this.IEST_ID, "", "");
        if (dtColumns.Rows.Count == 0)
        {
            if (bizBiasData.InsertInitBiasColumnData(this.ICOMP_ID, this.IEST_ID, gUserInfo.Emp_Ref_ID))
                dtColumns = bizBiasData.GetBiasColumns(this.ICOMP_ID, this.IEST_ID, "", "");
            else
                return;
        }
        ugrdColumn.DataSource = dtColumns;
        ugrdColumn.DataBind();
    }

    private void DoInitControl()
    {
        rblVISIBLE_YN.Items.Add(new ListItem("보이기", "Y"));
        rblVISIBLE_YN.Items.Add(new ListItem("숨기기", "N"));

        rblUSE_YN.Items.Add(new ListItem("사용함", "Y"));
        rblUSE_YN.Items.Add(new ListItem("사용안함", "N"));

        ddlTYPE.Items.Insert(0, new ListItem("필수", "FIXEDKEY"));
        ddlTYPE.Items.Insert(1, new ListItem("사용자정의", "USERKEY"));

        ddlALIGN.Items.Insert(0, new ListItem("Left", "Left"));
        ddlALIGN.Items.Insert(1, new ListItem("Center", "Center"));
        ddlALIGN.Items.Insert(2, new ListItem("Right", "Right"));

        ddlDATATYPE.Items.Insert(0, new ListItem("::선택::", ""));
        ddlDATATYPE.Items.Insert(1, new ListItem("System.String", "System.String"));
        ddlDATATYPE.Items.Insert(2, new ListItem("System.Char", "System.Char"));
        ddlDATATYPE.Items.Insert(3, new ListItem("System.DateTime", "System.DateTime"));
        ddlDATATYPE.Items.Insert(4, new ListItem("System.Decimal", "System.Decimal"));
        ddlDATATYPE.Items.Insert(5, new ListItem("System.Double", "System.Double"));
        ddlDATATYPE.Items.Insert(6, new ListItem("System.Int32", "System.Int32"));

        ddlPROCTYPE.Items.Insert(0, new ListItem("대상", "Y"));
        ddlPROCTYPE.Items.Insert(1, new ListItem("대상아님", "N"));

        TextBoxCommon.SetOnlyInteger(txtCOL_WIDTH);
        TextBoxCommon.SetOnlyInteger(txtCOL_ORDER);        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
		
    }

    protected void ugrdColumn_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        Infragistics.WebUI.UltraWebGrid.UltraGridRow ugrd = e.SelectedRows[0];

        this.ISEQ = DataTypeUtility.GetToInt32(ugrd.Cells.FromKey("SEQ").Value);
        if (ugrd.Cells.FromKey("COL_TYPE").Value.ToString() == "FIXEDKEY")
            iBtnSave.Visible = false;
        else
            iBtnSave.Visible = true;

        WebUtility.FindByValueRadioButtonList(rblVISIBLE_YN, ugrd.Cells.FromKey("VISIBLE_YN").Value.ToString());
        WebUtility.FindByValueRadioButtonList(rblUSE_YN, ugrd.Cells.FromKey("USE_YN").Value.ToString());
        txtCOL_ORDER.Text = ugrd.Cells.FromKey("COL_ORDER").Value.ToString();
        txtCOL_KEY.Text = ugrd.Cells.FromKey("COL_KEY").Value.ToString();
        txtCOL_NAME.Text = ugrd.Cells.FromKey("COL_NAME").Value.ToString();
        txtCOL_DESC.Text = ugrd.Cells.FromKey("COL_DESC").Value.ToString();
        WebUtility.FindByValueDropDownList(ddlTYPE, ugrd.Cells.FromKey("COL_TYPE").Value.ToString());
        txtCOL_WIDTH.Text = ugrd.Cells.FromKey("COL_WIDTH").Value.ToString();
        WebUtility.FindByValueDropDownList(ddlALIGN, ugrd.Cells.FromKey("COL_ALIGN").Value.ToString());
        WebUtility.FindByValueDropDownList(ddlDATATYPE, ugrd.Cells.FromKey("DATA_TYPE").Value.ToString());
        txtPROC_NAME.Text = ugrd.Cells.FromKey("PROC_NAME").Value.ToString();
        WebUtility.FindByValueDropDownList(ddlPROCTYPE, ugrd.Cells.FromKey("PROC_TYPE").Value.ToString());

    }

    protected void ugrdColumn_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Data;
        e.Row.Cells.FromKey("VISIBLE_YN_I").Value = string.Format("<img src='../images/icon/color/{0}.gif'/>", (drv["VISIBLE_YN"].ToString().Equals("Y") ? "blue" : "red"));
        if (drv["COL_TYPE"].ToString() == "FIXEDKEY")
        {
            e.Row.Cells.FromKey("COL_TYPE_T").Value = "필수";
            e.Row.Cells.FromKey("COL_TYPE_T").Style.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            e.Row.Cells.FromKey("COL_TYPE_T").Value = "사용자정의";
            e.Row.Cells.FromKey("COL_TYPE_T").Style.ForeColor = System.Drawing.Color.Blue;
        }
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        if (bizBiasData.UpdateBiasColumn(this.ICOMP_ID
                                    , this.IEST_ID
                                    , this.ISEQ
                                    , rblVISIBLE_YN.SelectedItem.Value
                                    , DataTypeUtility.GetToInt32(txtCOL_ORDER.Text.Trim())
                                    , txtCOL_KEY.Text.Trim()
                                    , txtCOL_NAME.Text.Trim()
                                    , txtCOL_DESC.Text.Trim()
                                    , ddlTYPE.SelectedItem.Value
                                    , DataTypeUtility.GetToInt32(txtCOL_WIDTH.Text.Trim())
                                    , ddlALIGN.SelectedItem.Value
                                    , ddlDATATYPE.SelectedItem.Value
                                    , txtPROC_NAME.Text.Trim()
                                    , ddlPROCTYPE.SelectedItem.Value
                                    , rblUSE_YN.SelectedItem.Value
                                    , gUserInfo.Emp_Ref_ID))
        {
            DoBindingColumn();
            for (int i = 0; i < ugrdColumn.Rows.Count; i++)
            {
                if (ugrdColumn.Rows[i].Cells.FromKey("SEQ").Value.ToString() == this.ISEQ.ToString())
                    ugrdColumn.Rows[i].Selected = true;
            }
            ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
    }
}
