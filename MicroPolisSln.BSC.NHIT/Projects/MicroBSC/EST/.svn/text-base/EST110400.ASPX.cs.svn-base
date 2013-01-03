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
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

using MicroBSC.Estimation.Biz;
using MicroCharts;

public partial class EST_EST110400 : EstPageBase
{
    #region ================ 필드 =======================
    //public string EST_ID;
    public string YEAR_YN;
    public string MERGE_YN;
    public string ESTTERM_SUB_ALL_USE_YN;
    public string ESTTERM_STEP_ALL_USE_YN;

    #endregion

    #region ================ 프로퍼티 =======================
    protected string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lbnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected int IIS_TERM_CLOSE
    {
        get
        {
            if (ViewState["IS_TERM_CLOSE"] == null)
                ViewState["IS_TERM_CLOSE"] = 1;
            return (int)ViewState["IS_TERM_CLOSE"];
        }
        set
        {
            ViewState["IS_TERM_CLOSE"] = value;
        }
    }

    protected int ICOMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
                ViewState["COMP_ID"] = 1;
            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }

    protected int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    protected string IEST_ID
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

    protected string IEST_JOB_IDS
    {
        get
        {
            if (ViewState["EST_JOB_IDS"] == null)
                ViewState["EST_JOB_IDS"] = "";
            return (string)ViewState["EST_JOB_IDS"];
        }
        set
        {
            ViewState["EST_JOB_IDS"] = value;
        }
    }

    protected int IBIAS_GRP_ID
    {
        get
        {
            if (ViewState["BIAS_GRP_ID"] == null)
                ViewState["BIAS_GRP_ID"] = 0;
            return (int)ViewState["BIAS_GRP_ID"];
        }
        set
        {
            ViewState["BIAS_GRP_ID"] = value;
        }
    }

    #endregion

    #region ================ Page 이벤트 =======================

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.IEST_ID = WebUtility.GetRequest("EST_ID", "");
        this.IEST_JOB_IDS = WebUtility.GetRequest("EST_JOB_IDS");
        YEAR_YN = WebUtility.GetRequest("YEAR_YN", "N");
        MERGE_YN = WebUtility.GetRequest("MERGE_YN", "N");

        //BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnApplyBiasPoint);
        //BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnCalcBiasPoint);

        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            //DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");
            //DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");

            if (this.ICOMP_ID == 0)
                this.ICOMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

            if (this.IESTTERM_REF_ID == 0)
                this.IESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

            //if (ESTTERM_SUB_ID == 0)
            //    ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

            //if (ESTTERM_STEP_ID == 0)
            //    ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

            if (!this.IEST_ID.Equals(""))
            {
                DoBindingGroup();
            }
            else
                imgGroup.Visible = imgColumn.Visible = ibtnSave.Visible = false;
        }

        //if (YEAR_YN.Equals("Y"))
        //    ESTTERM_SUB_ID = BizUtility.GetEstTermSubIDByYearYN(this.ICOMP_ID);
        //else
        //    ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        //if (MERGE_YN.Equals("Y"))
        //    ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(this.ICOMP_ID);
        //else
        //    ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //if (YEAR_YN.Equals("Y"))
        //    ddlEstTermSubID.Visible = false;

        //if (MERGE_YN.Equals("Y"))
        //    ddlEstTermStepID.Visible = false;
    }

    #endregion

    #region ================ 메소드 =======================

    private void DoBindingGroup()
    {
        //DropDownListCommom.BindEstTermSub(ddlEstTermSubID, this.ICOMP_ID, this.IEST_ID, "");
        //DropDownListCommom.BindEstTermStep(ddlEstTermStepID, this.ICOMP_ID, this.IEST_ID);

        //평가마감되었는지 확인
        Biz_TermInfos bizTermInfos = new Biz_TermInfos(this.IESTTERM_REF_ID);
        this.IIS_TERM_CLOSE = bizTermInfos.Yearly_Close_YN;

        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        DataTable dt = bizBiasData.GetBiasGroupEmpCount(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, "Y");
        ugrdGroup.DataSource = dt;
        ugrdGroup.DataBind();

    }

    private void DoBindingEmpTree(int bias_grp_id)
    {
        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        WebCommon.FillBiasEmpOrg(treeEmp, this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, bias_grp_id);
    }

    #endregion

    #region ======================= 드롭다운 컨트롤 ===========================

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBindingGroup();
    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

        DoBindingGroup();
    }

    //protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

    //    DoBindingGroup();
    //}

    //protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);

    //    DoBindingGroup();
    //}

    #endregion

    #region ================== 버튼 컨틀롤 ========================

    protected void ugrdGroup_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        this.IBIAS_GRP_ID = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("BIAS_GRP_ID").Value);
        DoBindingEmpTree(this.IBIAS_GRP_ID);
        lblGroup.Text = "[ " + e.SelectedRows[0].Cells.FromKey("BIAS_GRP_NM").Value.ToString() + " ]";
        lblGroup.Font.Bold = true;
        lblGroup.ForeColor = Color.LightBlue;
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {
        DoBindingGroup();
        if (this.IBIAS_GRP_ID > 0)
        {
            DoBindingGroupSelect();
        }
    }

    private void DoBindingGroupSelect()
    {
        for (int i = 0; i < ugrdGroup.Rows.Count; i++)
        {
            if (ugrdGroup.Rows[i].Cells.FromKey("BIAS_GRP_ID").Value.ToString() == this.IBIAS_GRP_ID.ToString())
            {
                ugrdGroup.Rows[i].Selected = true;
                break;
            }
        }
        if (ugrdGroup.DisplayLayout.SelectedRows.Count == 0)
        {
            this.IBIAS_GRP_ID = 0;
            lblGroup.Text = "";
        }
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        TreeNodeCollection treeNodeCol = treeEmp.CheckedNodes;

        DataTable insertDT = new DataTable();
        insertDT.Columns.Add("EMP_REF_ID", typeof(int));

        foreach (TreeNode node in treeNodeCol)
        {
            if (node.ToolTip == "EMP")
            {
                DataRow insertDR = insertDT.NewRow();
                insertDR["EMP_REF_ID"] = DataTypeUtility.GetToInt32(node.Value);
                insertDT.Rows.Add(insertDR);
            }
        }

        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        if (bizBiasData.InsertBiasGroupEmp(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID, this.IBIAS_GRP_ID, insertDT, gUserInfo.Emp_Ref_ID))
        {
            DoBindingEmpTree(this.IBIAS_GRP_ID);
            DoBindingGroup();
            if (this.IBIAS_GRP_ID > 0)
            {
                DoBindingGroupSelect();
            }
            ltrScript.Text = JSHelper.GetAlertScript("설정하였습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        Biz_EstInfos bizEstInfo = new Biz_EstInfos(this.ICOMP_ID, this.IEST_ID);
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + ddlEstTermRefID.SelectedItem.Text;
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가명 : " + bizEstInfo.Est_Name;
        //e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
    }

    protected void ibtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        ugrdGroupEmpList.DataSource = bizBiasData.GetBiasGroupEmpList(this.ICOMP_ID, this.IEST_ID, this.IESTTERM_REF_ID);
        ugrdGroupEmpList.DataBind();

        ugrdEEP.ExcelStartRow = 4;
        ugrdEEP.ExportMode = ExportMode.InBrowser;
        ugrdEEP.DownloadName = "Bias Group List";
        ugrdEEP.WorksheetName = "Bias 그룹대상현황";
        ugrdEEP.Export(ugrdGroupEmpList);
    }

    #endregion
}
