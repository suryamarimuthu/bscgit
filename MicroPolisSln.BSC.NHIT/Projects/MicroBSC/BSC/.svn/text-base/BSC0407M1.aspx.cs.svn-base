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

using MicroBSC.Common;
using Infragistics.WebUI.UltraWebGrid;
using System.Drawing;

public partial class BSC_BSC0407M1 : AppPageBase
{

    public int IEstDeptRefID
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

    public string IYmd
    { 
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "000000");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string IsOpenTerm
    { 
        get
        {
            if (ViewState["CLOSE_TERM"] == null)
            {
                MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();

                if (objTerm.GetIsOpenTerm(this.IEstTermRefID))
                {
                    ViewState["CLOSE_TERM"] = "Y";
                }
                else
                {
                    ViewState["CLOSE_TERM"] = "N";
                }
            }

            return (string)ViewState["CLOSE_TERM"];
        }
        set
        {
            ViewState["CLOSE_TERM"] = value;
        }
    }

    public string IsAdmin
    {
        get
        {
            if (ViewState["ISADMIN"] == null)
            {
                ViewState["ISADMIN"] = GetRequest("ISADMIN", "Y");
            }

            return (string)ViewState["ISADMIN"];
        }
        set
        {
            ViewState["ISADMIN"] = value;
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
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
    }

    private void SetPageData()
    {
        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            if (User.IsInRole(ROLE_ADMIN))
            {
                this.IsAdmin = "Y";
            }
            else
            {
                this.IsAdmin = "N";
            }
        }

        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, this.IEstTermRefID);
        WebCommon.FillEstTree(trvEstDept, this.IEstTermRefID, gUserInfo.Emp_Ref_ID);
        trvEstDept.ExpandAll();

        if (trvEstDept.Nodes.Count > 0)
        {
            trvEstDept.Nodes[0].Select();
            this.IEstDeptRefID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
            this.SetFormData();
        }
        else
        {
            ltEstDeptName.Text = "";
            lblChampName.Text  = "";
            lblSTGMapName.Text = "";
            ugrdLoadMapList.Clear();
            this.IEstDeptRefID = 0;
        }
    }

    private void SetPostBack()
    {
        if (trvEstDept.SelectedNode == null)
        {
            
        }
        else
        {
            TreeNode trvSel = trvEstDept.FindNode(trvEstDept.SelectedNode.ValuePath);
            trvSel.Select();
            trvSel.Expand();
        }
    }

    private void SetAllTimeBottom()
    {

    }
    #endregion


    #region 내부함수
    private void SetFormData()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IYmd          = PageUtility.GetByValueDropDownList(ddlEstTermMonth);

        if (this.IEstDeptRefID < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서를 선택해 주십시오", false);
            ugrdLoadMapList.Clear();
            return;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objMap = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info(this.IEstTermRefID, this.IEstDeptRefID, this.IYmd);
        ltEstDeptName.Text = objMap.Iest_dept_name;
        lblChampName.Text  = objMap.Ibscchampion_name;
        lblSTGMapName.Text = objMap.Idept_vision;

        MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap objLoadMap = new MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap();
        DataSet rDs = objLoadMap.GetLoadMapPerEstDept(this.IEstTermRefID, this.IEstDeptRefID);
        ugrdLoadMapList.Clear();
        ugrdLoadMapList.DataSource = rDs;
        ugrdLoadMapList.DataBind();
    }


    private void SaveEstDeptLoadMap()
    {
        int intTxrUser = gUserInfo.Emp_Ref_ID;
        int intRow     = ugrdLoadMapList.Rows.Count;
        int intRnt     = 0;
        MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap objLoadMap = new MicroBSC.BSC.Biz.Biz_Bsc_EstDept_LoadMap();

        TemplatedColumn tmcPL = null;
        TemplatedColumn tmcDO = null;
        TemplatedColumn tmcDE = null;

        TextBox txtPL = null;
        TextBox txtDO = null;
        TextBox txtDE = null;

        for (int i = 0; i < intRow; i++)
        {
            tmcPL = (TemplatedColumn)ugrdLoadMapList.Rows[i].Band.Columns.FromKey("MONTHLY_PLAN");
            tmcDO = (TemplatedColumn)ugrdLoadMapList.Rows[i].Band.Columns.FromKey("DETAILS");
            tmcDE = (TemplatedColumn)ugrdLoadMapList.Rows[i].Band.Columns.FromKey("ETC_CONTENTS");

            txtPL = (TextBox)((CellItem)tmcPL.CellItems[ugrdLoadMapList.Rows[i].BandIndex]).FindControl("txtMONTHLY_PLAN");
            txtDO = (TextBox)((CellItem)tmcDO.CellItems[ugrdLoadMapList.Rows[i].BandIndex]).FindControl("txtDETAILS");
            txtDE = (TextBox)((CellItem)tmcDE.CellItems[ugrdLoadMapList.Rows[i].BandIndex]).FindControl("txtETC_CONTENTS");

            objLoadMap.Iestterm_ref_id  = (ugrdLoadMapList.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value ==null) ? 0  : Convert.ToInt32(ugrdLoadMapList.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            objLoadMap.Iest_dept_ref_id = (ugrdLoadMapList.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value==null) ? 0  : Convert.ToInt32(ugrdLoadMapList.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
            objLoadMap.Iymd             = (ugrdLoadMapList.Rows[i].Cells.FromKey("YMD").Value == null)           ? "" : Convert.ToString(ugrdLoadMapList.Rows[i].Cells.FromKey("YMD").Value.ToString());
            objLoadMap.Imonthly_plan    = txtPL.Text; 
            objLoadMap.Idetails         = txtDO.Text; //(ugrdLoadMapList.Rows[i].Cells.FromKey("DETAILS").Value== null)        ? "" : Convert.ToString(ugrdLoadMapList.Rows[i].Cells.FromKey("DETAILS").Value.ToString());
            objLoadMap.Ietc_contents    = txtDE.Text; //(ugrdLoadMapList.Rows[i].Cells.FromKey("ETC_CONTENTS").Value==null)    ? "" : Convert.ToString(ugrdLoadMapList.Rows[i].Cells.FromKey("ETC_CONTENTS").Value.ToString());

            if ((objLoadMap.Iestterm_ref_id == 0) || (objLoadMap.Iest_dept_ref_id == 0))
            {
                ltrScript.Text = JSHelper.GetAlertScript("평가기간이나 부서정보를 알수 없습니다.",false);
                break;
                //return;
            }

            intRnt = objLoadMap.InsertData(
                                  objLoadMap.Iestterm_ref_id
                                , objLoadMap.Iest_dept_ref_id
                                , objLoadMap.Iymd
                                , objLoadMap.Imonthly_plan
                                , objLoadMap.Idetails
                                , objLoadMap.Ietc_contents
                                , intTxrUser
                                  );
        }
    }

    #endregion
    #region =================== [ server event ] ===================
    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.IEstDeptRefID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
        this.SetFormData();
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        this.SaveEstDeptLoadMap();
    }

    protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.SetFormData();
    }

    protected void ugrdLoadMapList_InitializeRow(object sender, RowEventArgs e)
    {

        TemplatedColumn tmcPL = (TemplatedColumn)e.Row.Band.Columns.FromKey("MONTHLY_PLAN");
        TemplatedColumn tmcDO = (TemplatedColumn)e.Row.Band.Columns.FromKey("DETAILS");
        TemplatedColumn tmcDE = (TemplatedColumn)e.Row.Band.Columns.FromKey("ETC_CONTENTS");

        TextBox txtPL = (TextBox)((CellItem)tmcPL.CellItems[e.Row.BandIndex]).FindControl("txtMONTHLY_PLAN");
        TextBox txtDO = (TextBox)((CellItem)tmcDO.CellItems[e.Row.BandIndex]).FindControl("txtDETAILS");
        TextBox txtDE = (TextBox)((CellItem)tmcDE.CellItems[e.Row.BandIndex]).FindControl("txtETC_CONTENTS");

        txtPL.Text = (e.Row.Cells.FromKey("MONTHLY_PLAN").Value == null)  ? "" : Convert.ToString(e.Row.Cells.FromKey("MONTHLY_PLAN").Value.ToString());
        txtDO.Text = (e.Row.Cells.FromKey("DETAILS").Value == null)       ? "" : Convert.ToString(e.Row.Cells.FromKey("DETAILS").Value.ToString());
        txtDE.Text = (e.Row.Cells.FromKey("ETC_CONTENTS").Value == null)  ? "" : Convert.ToString(e.Row.Cells.FromKey("ETC_CONTENTS").Value.ToString());

        txtPL.Style.Add("overflow", "auto");
        txtDO.Style.Add("overflow", "auto");
        txtDE.Style.Add("overflow", "auto");

        if (this.IsAdmin == "N")
        {
            string strCheck = e.Row.Cells.FromKey("CLOSE_YN").Value.ToString();
            if (strCheck == "Y")
            {
                txtPL.ReadOnly = true;
                txtDO.ReadOnly = true;
                txtDE.ReadOnly = true;

                txtPL.BackColor = Color.WhiteSmoke;
                txtDO.BackColor = Color.WhiteSmoke;
                txtDE.BackColor = Color.WhiteSmoke;
            }
            else
            {
                txtPL.ReadOnly = (this.IsOpenTerm == "Y") ? false : true;
                txtDO.ReadOnly = false;
                txtDE.ReadOnly = false;

                txtPL.BackColor = (this.IsOpenTerm == "Y") ? Color.White : Color.WhiteSmoke;
                txtDO.BackColor = Color.White;
                txtDE.BackColor = Color.White;
            }
        }
    }

    protected void ugrdLoadMapList_InitializeLayout(object sender, LayoutEventArgs e)
    {
        if (this.IsAdmin == "N")
        {
            if (this.IsOpenTerm == "Y")
            {
                e.Layout.Bands[0].Columns.FromKey("MONTHLY_PLAN").AllowUpdate = AllowUpdate.Yes;
                e.Layout.Bands[0].Columns.FromKey("MONTHLY_PLAN").CellStyle.BackColor = Color.White;
            }
            else
            {
                e.Layout.Bands[0].Columns.FromKey("MONTHLY_PLAN").AllowUpdate = AllowUpdate.No;
                e.Layout.Bands[0].Columns.FromKey("MONTHLY_PLAN").CellStyle.BackColor = Color.WhiteSmoke;
            }
        }
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetPageData();
    }
    #endregion
}
    