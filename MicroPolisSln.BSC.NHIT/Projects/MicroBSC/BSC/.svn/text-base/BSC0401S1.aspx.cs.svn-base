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

using System.Collections.Generic;
using System.Text;

using MicroBSC.Common;
using MicroBSC.BSC.Biz;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

public partial class BSC_BSC0401S1 : AppPageBase
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

    public int IMapVersionID
    {
        get
        {
            if (ViewState["MAP_VERSION_ID"] == null)
            {
                ViewState["MAP_VERSION_ID"] = GetRequestByInt("MAP_VERSION_ID", 0);
            }

            return (int)ViewState["MAP_VERSION_ID"];
        }
        set
        {
            ViewState["MAP_VERSION_ID"] = value;
        }
    }

    public int IEstTermRefID;
    public string strYMD;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
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
        Literal1.Text = "";
    }

    private void InitControlValue()
    {
       
    }

    private void InitControlEvent()
    {
    }

    private void SetPageData()
    {
        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        }

        this.IEstTermRefID = int.Parse(ddlEstTermInfo.SelectedValue);

        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, this.IEstTermRefID);

        MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp bizRel = new MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp();
        int estDeptID = DataTypeUtility.GetToInt32(bizRel.Get_Dept_ID_of_Emp_ID(gUserInfo.Emp_Ref_ID.ToString()));
        //WebCommon.FillEstMappingTree_NW(trvEstDept, this.IEstTermRefID, estDeptID, TreeNodeSelectAction.Select);
        WebCommon.FillEstTree(trvEstDept, this.IEstTermRefID, gUserInfo.Emp_Ref_ID);
        trvEstDept.ExpandAll();

        if (trvEstDept.Nodes.Count > 0)
        {
            trvEstDept.Nodes[0].Select();
            this.IEstDeptRefID = (trvEstDept.SelectedNode == null) ? IEstDeptRefID : int.Parse(trvEstDept.SelectedNode.Value);

            this.SetFormData(gUserInfo.Dept_Ref_ID);
        }
        else
        { 
            ltEstDeptName.Text = "";
            lblChampName.Text  = "";
            lblSTGMapName.Text = "";
            ugrdStgList.Clear();
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

    private bool HaveReadRight()
    {
        MicroBSC.Biz.BSC.Dac.Dac_EmpComDeptDetails objBSC = new MicroBSC.Biz.BSC.Dac.Dac_EmpComDeptDetails();
        return objBSC.IsAccessRightEstDept(this.IEstTermRefID, gUserInfo.Dept_Ref_ID, gUserInfo.Emp_Ref_ID);
    }

    private void SetFormData(int est_ref_id)
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.strYMD        = PageUtility.GetByValueDropDownList(ddlEstTermMonth);

        Biz_Bsc_Map_Info objMap = new Biz_Bsc_Map_Info(this.IEstTermRefID, est_ref_id, this.strYMD);
        this.IMapVersionID = objMap.Imap_version_id;
        ltEstDeptName.Text = objMap.Iest_dept_name;
        lblChampName.Text  = objMap.Ibscchampion_name;
        lblSTGMapName.Text = objMap.Idept_vision;

        Biz_Bsc_Map_Kpi objKpi = new Biz_Bsc_Map_Kpi();
        DataSet rDs = objKpi.GetWeightPerStg(this.IEstTermRefID, est_ref_id, this.strYMD);

        if (rDs.Tables.Count > 0)
        {
            if (rDs.Tables[0].Rows.Count > 0)
            {
                rDs.Tables[0].Columns.Add("PARENT_STG", typeof(string));
                Biz_Bsc_Map_Stg_Parent objPrt = new Biz_Bsc_Map_Stg_Parent();
                int iRow = rDs.Tables[0].Rows.Count;
                string sUpStg = "";
                for (int i = 0; i < iRow; i++)
                {
                    objPrt.Iestterm_ref_id  = int.Parse(rDs.Tables[0].Rows[i]["ESTTERM_REF_ID"].ToString());
                    objPrt.Iest_dept_ref_id = int.Parse(rDs.Tables[0].Rows[i]["EST_DEPT_REF_ID"].ToString());
                    objPrt.Imap_version_id  = int.Parse(rDs.Tables[0].Rows[i]["MAP_VERSION_ID"].ToString());
                    objPrt.Istg_ref_id      = int.Parse(rDs.Tables[0].Rows[i]["STG_REF_ID"].ToString());

                    DataSet pDs = objPrt.GetParentStgList
                                 ( objPrt.Iestterm_ref_id
                                 , objPrt.Iest_dept_ref_id
                                 , objPrt.Imap_version_id
                                 , objPrt.Istg_ref_id);
                    sUpStg = "";
                    if (pDs.Tables.Count > 0)
                    {
                        for (int k = 0; k < pDs.Tables[0].Rows.Count; k++)
                        {
                            sUpStg += (k == 0) ? pDs.Tables[0].Rows[k]["UP_STG_REF_ID"].ToString()
                                               : "," + pDs.Tables[0].Rows[k]["UP_STG_REF_ID"].ToString();
                        }
                    }

                    rDs.Tables[0].Rows[i]["PARENT_STG"] = sUpStg;
                }                
            }
        }

        ugrdStgList.Clear();
        ugrdStgList.DataSource = rDs;
        ugrdStgList.DataBind();
    }

    private void GetParentStg()
    { 
        
    }
    private void PrintFormGrid()
    {
        ugrdEEP.ExcelStartRow = 6;
        ugrdEEP.ExportMode    = ExportMode.InBrowser;
        ugrdEEP.DownloadName  = "ParentStrategy";
        ugrdEEP.WorksheetName = "상위전략";
        ugrdEEP.Export(ugrdStgList);
    }


    #endregion

    #region 서버 이벤트 처리 함수

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        trvEstDept.Nodes.Clear();
        WebCommon.FillEstTree(trvEstDept, Convert.ToInt32(ddlEstTermInfo.SelectedValue));
        trvEstDept.ExpandAll();
    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.IEstTermRefID = int.Parse(ddlEstTermInfo.SelectedValue);
        if (HaveReadRight())
        {
            this.IEstDeptRefID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
            this.SetFormData(IEstDeptRefID);
        }
        else
        {
            string script = @"<script type='text/javascript'>alert('조회할 권한이 없습니다.');</script>";
            Response.Write(script);
        }
    
    }

    protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.IEstDeptRefID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
        this.SetFormData(IEstDeptRefID);
    }

    protected void iBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        this.PrintFormGrid();
    }

    protected void ugrdEEP_BeginExport(object sender, BeginExportEventArgs e)
    {
        e.CurrentWorksheet.Rows[0].Cells[0].Value = "평가기간 : " + (ddlEstTermInfo.SelectedItem.Text+" / "+ddlEstTermMonth.SelectedItem.Text);
        e.CurrentWorksheet.Rows[1].Cells[0].Value = "평가조직 : " + ltEstDeptName.Text;
        e.CurrentWorksheet.Rows[2].Cells[0].Value = "조직비젼 : " + lblSTGMapName.Text;
        e.CurrentWorksheet.Rows[3].Cells[0].Value = "BSC Champion : " + lblChampName.Text;

        e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Color = System.Drawing.Color.Crimson;
        //e.CurrentWorksheet.Rows[0].Cells[0].CellFormat.Font.Height = 400;

        // Add a caption with some more information
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetPageData();
    }
    #endregion
}
