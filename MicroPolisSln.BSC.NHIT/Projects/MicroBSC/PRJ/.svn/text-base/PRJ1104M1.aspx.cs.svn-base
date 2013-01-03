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
using System.Collections.Generic;
using System.Text;

using System.Drawing;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;

using MicroBSC.Biz.BSC;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;

public partial class PRJ_PRJ1104M1 : PrjPageBase
{
    public int IESTTERM_REF_ID
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
    public int IEST_DEPT_REF_ID
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
    public int IMAP_VERSION_ID
    {
        get
        {
            if (ViewState["MAP_VERSION_ID"] == null)
            {
                ViewState["MAP_VERSION_ID"] = GetRequestByInt("MAP_VERSION_ID", 1);
            }

            return (int)ViewState["MAP_VERSION_ID"];
        }
        set
        {
            ViewState["MAP_VERSION_ID"] = value;
        }
    }
    protected string ITERM_MONTH
    {
        get
        {
            if (ViewState["TERM_MONTH"] == null)
                ViewState["TERM_MONTH"] = "";
            return (string)ViewState["TERM_MONTH"];
        }
        set
        {
            ViewState["TERM_MONTH"] = value;
        }
    }

    public string ITREE_SELECT_TYPE
    {
        get
        {
            if (ViewState["TREE_SELECT_TYPE"] == null)
            {
                ViewState["TREE_SELECT_TYPE"] = GetRequest("TREE_SELECT_TYPE");
            }

            return (string)ViewState["TREE_SELECT_TYPE"];
        }
        set
        {
            ViewState["TREE_SELECT_TYPE"] = value;
        }
    }
    public int ITREE_SELECT_VALUE
    {
        get
        {
            if (ViewState["TREE_SELECT_VALUE"] == null)
            {
                ViewState["TREE_SELECT_VALUE"] = GetRequest("TREE_SELECT_VALUE", "0");
            }

            return (int)ViewState["TREE_SELECT_VALUE"];
        }
        set
        {
            ViewState["TREE_SELECT_VALUE"] = value;
        }
    }

    public string ITREE_SELECT_VALUE_PATH
    {
        get
        {
            if (ViewState["TREE_SELECT_VALUE_PATH"] == null)
            {
                ViewState["TREE_SELECT_VALUE_PATH"] = GetRequest("TREE_SELECT_VALUE_PATH", "");
            }

            return (string)ViewState["TREE_SELECT_VALUE_PATH"];
        }
        set
        {
            ViewState["TREE_SELECT_VALUE_PATH"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBindingMaster();
            DoBindingTree();

            Biz_Bsc_Term_Detail bizTerm = new Biz_Bsc_Term_Detail();
            DataSet dsTerm = bizTerm.GetAllList(IESTTERM_REF_ID);
            if (dsTerm.Tables[0].Rows.Count > 0)
                ITERM_MONTH = dsTerm.Tables[0].Compute("MAX(YMD)", "RELEASE_YN = 'Y'").ToString();
            if (ITERM_MONTH == "")
            {
                Biz_Bsc_Map_Info bizMap2 = new Biz_Bsc_Map_Info();
                DataSet dsMap2 = bizMap2.GetMapTermList(IESTTERM_REF_ID, IEST_DEPT_REF_ID, IMAP_VERSION_ID);
                if (dsMap2.Tables[0].Rows.Count > 0)
                    ITERM_MONTH = dsMap2.Tables[0].Compute("MAX(YMD)", "APPLY_YN = 'Y'").ToString();
            }
        }
        ltrScript.Text = "";
    }

    private void DoInitControl()
    {
        this.IESTTERM_REF_ID = GetRequestByInt("ESTTERM_REF_ID", 0);
        this.IEST_DEPT_REF_ID = GetRequestByInt("EST_DEPT_REF_ID", 0);
        
        ddlWorkType.Items.Insert(0, new ListItem("전체", ""));
        ddlWorkType.Items.Insert(1, new ListItem("중점과제", "C"));
        ddlWorkType.Items.Insert(2, new ListItem("실행과제", "E"));

        ddlCompleteYN.Items.Insert(0, new ListItem("전체", ""));
        ddlCompleteYN.Items.Insert(1, new ListItem("완료", "Y"));
        ddlCompleteYN.Items.Insert(2, new ListItem("미완료", "N"));
    }

    private void DoBindingMaster()
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        DataSet dsMaster = bizMap.GetWorkMapMaster(this.IESTTERM_REF_ID, this.IEST_DEPT_REF_ID);

        if (dsMaster.Tables[0].Rows.Count > 0)
        {
            lblEstDeptName.Text = dsMaster.Tables[0].Rows[0]["EST_DEPT_NAME"].ToString();
            txtTermDesc.Text = dsMaster.Tables[0].Rows[0]["ESTTERM_NAME"].ToString();
            txtEstDeptName.Text = dsMaster.Tables[0].Rows[0]["EST_DEPT_NAME"].ToString();
            txtBSCChampion.Text = dsMaster.Tables[0].Rows[0]["BSCCHAMPION_NAME"].ToString();
            txtDeptVision.Text = dsMaster.Tables[0].Rows[0]["DEPT_VISION"].ToString();
            txtMapVersionID.Text = dsMaster.Tables[0].Rows[0]["MAP_VERSION_ID"].ToString();
            txtMapVersionName.Text = dsMaster.Tables[0].Rows[0]["MAP_VERSION_NAME"].ToString();
            txtMapDesc.Text = dsMaster.Tables[0].Rows[0]["MAP_DESC"].ToString();
            this.IMAP_VERSION_ID = DataTypeUtility.GetToInt32(dsMaster.Tables[0].Rows[0]["MAP_VERSION_ID"]);
        }
    }

    private void DoBindingSTG()
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        DataSet ds = bizMap.GetWorkMapWorkExec(this.IESTTERM_REF_ID, this.IEST_DEPT_REF_ID, this.ITREE_SELECT_TYPE, this.ITREE_SELECT_VALUE, this.IMAP_VERSION_ID);

        ugrdWorkPreView.Clear();
        ugrdWorkPreView.DataSource = ds;
        ugrdWorkPreView.DataBind();

        if (ds.Tables[0].Rows.Count > 0)
            lblWorkListCount.Text = "중점과제: " + ds.Tables[0].Compute("COUNT(WORK_TYPE)", "WORK_TYPE='C'").ToString() + " / 실행과제: " + ds.Tables[0].Compute("COUNT(WORK_TYPE)", "WORK_TYPE='E'").ToString() + " ";
        else
            lblWorkListCount.Text = "중점과제: 0 : 실행과제: 0&nbsp;&nbsp;&nbsp;";
    }

    private void DoBindingWork()
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        DataSet ds = bizMap.GetWorkMapWorkExec(this.IESTTERM_REF_ID, this.IEST_DEPT_REF_ID, this.ITREE_SELECT_TYPE, this.ITREE_SELECT_VALUE, this.IMAP_VERSION_ID);

        ugrdWorkList.Clear();
        ugrdWorkList.DataSource = ds;
        ugrdWorkList.DataBind();
    }

    private void DoFocusCurrentWork()
    {
        foreach (UltraGridRow ugr in ugrdWorkList.Rows)
        {
            if (ugr.Cells.FromKey("WORK_REF_ID").Value.ToString() == this.ITREE_SELECT_VALUE.ToString() && ugr.Cells.FromKey("WORK_TYPE").Value.ToString() == this.ITREE_SELECT_TYPE.ToString())
            {
                ugr.Style.BackColor = System.Drawing.Color.FromName("#E2ECF4");
                return;
            }
        }
    }

    private void DoBindingTree()
    {
        trvStgMap.Nodes.Clear();

        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        DeptInfos objDept = new DeptInfos(this.IEST_DEPT_REF_ID);
        DataSet dsMap = bizMap.GetWorkMapTree(this.IESTTERM_REF_ID, this.IEST_DEPT_REF_ID, this.IMAP_VERSION_ID);

        string topNodeID = "D" + this.IEST_DEPT_REF_ID.ToString();
        TreeNode topNode = new TreeNode(objDept.Dept_Name + " 과제체계도", topNodeID, "../images/stg/TREE_D.gif");
        trvStgMap.Nodes.Add(topNode);

        if (dsMap.Tables[0].Rows.Count > 0)
        {
            TreeNode tn;
            foreach (DataRow dr in dsMap.Tables[0].Rows)
            {
                tn = new TreeNode(dr["TREE_NAME"].ToString(), dr["TREE_ID"].ToString(), dr["TREE_IMAGE"].ToString());
                trvStgMap.FindNode(topNodeID + dr["VALUE_PATH"].ToString()).ChildNodes.Add(tn);
                if (tn.Value.Substring(0, 1) == "V")
                    tn.SelectAction = TreeNodeSelectAction.None;
            }
        }

        if (trvStgMap.SelectedNode == null)
        {
            topNode.Select();
        }

        trvStgMap.ExpandAll();
    }

    protected void ibtnWorkAdd_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        CheckBox chkCheck;
        TemplatedColumn Col_Check;
        DataTable dtWork = new DataTable();
        dtWork.Columns.Add("WORK_REF_ID", typeof(int));
        dtWork.Columns.Add("EXEC_REF_ID", typeof(int));
        int work_id;
        foreach(UltraGridRow gRow in ugrdWorkAll.Rows)
        {
            Col_Check = (TemplatedColumn)gRow.Band.Columns.FromKey("selchk");
            chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[gRow.BandIndex]).FindControl("cBox");
            if (chkCheck.Checked)
            {
                work_id = DataTypeUtility.GetToInt32(gRow.Cells.FromKey("WORK_REF_ID").Value.ToString());
                DataRow iDR = dtWork.NewRow();
                iDR["WORK_REF_ID"] = (gRow.Cells.FromKey("WORK_TYPE").Value.ToString() == "C" ? work_id : 0);
                iDR["EXEC_REF_ID"] = (gRow.Cells.FromKey("WORK_TYPE").Value.ToString() == "E" ? work_id : 0);
                dtWork.Rows.Add(iDR);
            }
        }

        if (dtWork.Rows.Count == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("추가할 과제를 선택하세요!");
            return;
        }
        if (bizMap.InsertWorkMap(this.IESTTERM_REF_ID
                                , this.IEST_DEPT_REF_ID
                                , this.ITREE_SELECT_VALUE
                                , dtWork
                                , gUserInfo.Emp_Ref_ID))
        {
            ltrScript.Text = JSHelper.GetAlertScript("추가하였습니다.");
            DoBindingTree();
            DoBindingSTG();
            DoBindingAddList();

            DoFocusTree();
            return;
        }
        ltrScript.Text = JSHelper.GetAlertScript("추가 실패!");
    }
    
    protected void ibtnWorkDel_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        CheckBox chkCheck;
        TemplatedColumn Col_Check;
        DataTable dtWork = new DataTable();
        dtWork.Columns.Add("WORK_REF_ID", typeof(int));
        dtWork.Columns.Add("EXEC_REF_ID", typeof(int));
        int work_id;
        foreach (UltraGridRow gRow in ugrdWorkPreView.Rows)
        {
            Col_Check = (TemplatedColumn)gRow.Band.Columns.FromKey("selchk");
            chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[gRow.BandIndex]).FindControl("cBox");
            if (chkCheck.Checked)
            {
                work_id = DataTypeUtility.GetToInt32(gRow.Cells.FromKey("WORK_REF_ID").Value.ToString());
                DataRow iDR = dtWork.NewRow();
                iDR["WORK_REF_ID"] = (gRow.Cells.FromKey("WORK_TYPE").Value.ToString() == "C" ? work_id : 0);
                iDR["EXEC_REF_ID"] = (gRow.Cells.FromKey("WORK_TYPE").Value.ToString() == "E" ? work_id : 0);
                dtWork.Rows.Add(iDR);
            }
        }

        if (dtWork.Rows.Count == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 과제를 선택하세요!");
            return;
        }

        if (bizMap.DeleteWorkMap(this.IESTTERM_REF_ID
                                , this.IEST_DEPT_REF_ID
                                , this.ITREE_SELECT_VALUE
                                , dtWork))
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제하였습니다.");
            DoBindingTree();
            DoBindingSTG();
            DoBindingAddList();
            DoFocusTree();
            return;
        }
        ltrScript.Text = JSHelper.GetAlertScript("삭제 실패!");
    }

    private void DoFocusTree()
    {
        trvStgMap.FindNode(this.ITREE_SELECT_VALUE_PATH).Select();
    }

    protected void trvStgMap_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.ITREE_SELECT_TYPE     = trvStgMap.SelectedNode.Value.Substring(0, 1);
        this.ITREE_SELECT_VALUE    = DataTypeUtility.GetToInt32(trvStgMap.SelectedNode.Value.Substring(1, trvStgMap.SelectedNode.Value.Length-1));
        this.ITREE_SELECT_VALUE_PATH = trvStgMap.SelectedNode.ValuePath;

        switch (this.ITREE_SELECT_TYPE)
        {
            case "D" : // 부서
                pnlDept.Visible = true;
                pnlSTG.Visible = pnlWorkList.Visible = false;
                break;
            case "S":  // 전략
                DoBindingSTG();
                pnlSTG.Visible = true;
                pnlDept.Visible = pnlWorkList.Visible = false;
                break;
            case "C":   //중점과제
            case "E":   //실행과제
                DoBindingWork();
                DoFocusCurrentWork();
                pnlDept.Visible = pnlSTG.Visible = false;
                pnlWorkList.Visible = true;
                break;
            default:
                pnlDept.Visible = true;
                pnlSTG.Visible = pnlWorkList.Visible = false;
                break;
        }
    }

    protected void ugrdWorkPreView_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //DataRowView drv = (DataRowView)e.Data;
        //if (drv["WORK_TYPE"].ToString() == "C")
        //    e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openWorkForm({0}, {1}, {2})' />"
        //        , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
        //else
        //    e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openExecForm({0}, {1}, {2}, {3})' />"
        //        , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID_ORG").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
    }
    protected void ugrdWorkAll_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //DataRowView drv = (DataRowView)e.Data;
        //if (drv["WORK_TYPE"].ToString() == "C")
        //    e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openWorkForm({0}, {1}, {2})' />"
        //        , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
        //else
        //    e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openExecForm({0}, {1}, {2}, {3})' />"
        //        , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID_ORG").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
    }
    protected void ugrdWorkList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //DataRowView drv = (DataRowView)e.Data;
        //if (drv["WORK_TYPE"].ToString() == "C")
        //    e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openWorkForm({0}, {1}, {2})' />"
        //        , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
        //else
        //    e.Row.Cells.FromKey("WORK_UPDATE").Text = string.Format("<img src='../images/drafts.gif' style='cursor: pointer;' border='0' onclick='openExecForm({0}, {1}, {2}, {3})' />"
        //        , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_DEPT_REF_ID").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID_ORG").Value.ToString()
        //        , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString());
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBindingAddList();
    }

    private void DoBindingAddList()
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        DataSet dsMap = bizMap.GetWorkMapWorkExecList(this.IESTTERM_REF_ID, this.IEST_DEPT_REF_ID, PageUtility.GetByValueDropDownList(ddlWorkType), txtEstDeptNameF.Text.Trim(), txtEmpID.Text.Trim()
            , txtEmpName.Text.Trim(), txtWorkCode.Text.Trim(), txtWorkName.Text.Trim(), PageUtility.GetByValueDropDownList(ddlCompleteYN));

        ugrdWorkAll.Clear();
        ugrdWorkAll.DataSource = dsMap;
        ugrdWorkAll.DataBind();
    }
}
