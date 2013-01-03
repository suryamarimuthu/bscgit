using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Data;

public partial class ctl2400 : AppPageBase
{
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.FillEstOrgStatusTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), TreeNodeSelectAction.Select);
            WebCommon.SetDeptTypeDropDownList(ddlDeptType, false);
            BindingOrgType(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        }

        //MenuControl2.IsCheckInOutVisible = true;
        //MenuControl2.SetCheckInOutBuuton(iBtnSave_1, iBtnSave_2);

        ltrScript.Text = "";
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            iBtnSave_0.Attributes.Add("onclick", "return confirm('조직 개체별 보이기를 저장하시겠습니까?');");
            iBtnSave_1.Attributes.Add("onclick", "return confirm('조직 개체 상세정보를 저장하시겠습니까?');");
            iBtnSave_2.Attributes.Add("onclick", "return confirm('조직 타입 보이기를 저장하시겠습니까?');");
            itnClearEstDeptOrg.Attributes.Add("onclick", "return confirm('조직 타입 정보를 모두 초기화 하시겠습니까?');");
            itnClearDeptDrill.Attributes.Add("onclick", "return confirm('선택된 드릴다운정보를 삭제하시겠습니까?');");

            txtSort_Org.Style.Add("ime-mode", "disabled");
            txtSort_Org.Style.Add("text-align", "right");
            txtSort_Org.Attributes.Add("onkeydown", "return gfChkInputNum_Std()");
        }
    }
    private void BindingOrgType(int estterm_ref_id) 
    {
        Biz_DeptTypeInfo deptTypeInfo           = new Biz_DeptTypeInfo();
        UltraWebGrid1.DataSource                = deptTypeInfo.GetDeptTypeList();
        UltraWebGrid1.DataBind();

        CheckDrillDownYN(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }

    private void CheckDrillDownYN(int estterm_ref_id) 
    {
        Biz_EstDeptOrgDetails estDeptOrgDetail  = new Biz_EstDeptOrgDetails();
        bool isDrilldown                        = estDeptOrgDetail.IsDrillDown(estterm_ref_id);

        rtlDrildownYN.ClearSelection();

        if (isDrilldown)
        {
            rtlDrildownYN.SelectedIndex = 0;
        }
        else 
        {
            rtlDrildownYN.SelectedIndex = 1;
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        Biz_EstDeptOrgMaps estDeptOrgMap = new Biz_EstDeptOrgMaps(Convert.ToInt32(TreeView1.SelectedNode.Value));
        txtDeptName_Org.Text    = estDeptOrgMap.Dept_Name_Org;
        txtSort_Org.Text        = estDeptOrgMap.Sort_Org.ToString();
        
        PageUtility.FindByValueDropDownList(ddlHearderType, estDeptOrgMap.Header_Img_Org.ToString());
        PageUtility.FindByValueDropDownList(ddlDeptType, estDeptOrgMap.Dept_Type.ToString());

        SetVisibleButton();
        GridBinding();
        CheckDrillDownYN(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        Biz_EstDeptOrgDetails estDeptOrgDetail = new Biz_EstDeptOrgDetails();
        cBoxEstDeptTopYN.Checked = estDeptOrgDetail.IsEstDeptTopYN(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), Convert.ToInt32(TreeView1.SelectedNode.Value));

        if (iBtnSave_1.Visible == false)
        {
            iBtnSave_1.Visible = true;
            //iBtnSave_2.Visible = true;
            //itnClearEstDeptOrg.Visible = true;
        }
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        TreeView1.Nodes.Clear();
        WebCommon.FillEstOrgStatusTree(TreeView1, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), TreeNodeSelectAction.Select);
        TreeView1.ExpandAll();

        SetVisibleButton();
        GridBinding();
        CheckDrillDownYN(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }
    protected void iBtnSave_0_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EstDeptOrgMaps estDeptOrgMap = new Biz_EstDeptOrgMaps();
        estDeptOrgMap.ModifyViewYNOrg(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), TreeView1.CheckedNodes);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 조직상황판 보이기 여부가 저장되었습니다.", false);
    }
    protected void iBtnSave_1_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EstDeptOrgMaps estDeptOrgMap = new Biz_EstDeptOrgMaps();
        estDeptOrgMap.ModifyEstDeptOrg(Convert.ToInt32(TreeView1.SelectedNode.Value)
                                        , PageUtility.GetIntByValueDropDownList(ddlHearderType)
                                        , (txtSort_Org.Text.Equals("0"))? 10 : int.Parse(txtSort_Org.Text)
                                        , PageUtility.GetIntByValueDropDownList(ddlDeptType)
                                        , txtDeptName_Org.Text);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.", false);
    }
    protected void iBtnSave_2_Click(object sender, ImageClickEventArgs e)
    {
        UltraGridRow row;
        CheckBox cBoxHome_YN_Org;
        CheckBox cBoxHeader_YN_Org;
        CheckBox cBoxContent_YN_Org;
        DropDownList ddlPosition_Org;
        TemplatedColumn home_yn_col;
        TemplatedColumn header_yn_col;
        TemplatedColumn content_yn_col;
        TemplatedColumn position_col;
        int est_dept_ref_id = 0;
        string ynStr        = "N";

        Biz_DeptTypeInfo deptTypeInfo           = new Biz_DeptTypeInfo();
        Biz_EstDeptOrgDetails estDeptOrgDetail  = new Biz_EstDeptOrgDetails();

        IDbConnection conn                      = DbAgentHelper.CreateDbConnection();
        conn.Open();
        IDbTransaction trx                      = conn.BeginTransaction();

        try
        {
            // 드릴다운 사용 안할 때
            if (rtlDrildownYN.SelectedValue.Equals("0"))
            {
                if (TreeView1.Nodes.Count > 0)
                {
                    est_dept_ref_id = int.Parse(TreeView1.Nodes[0].Value);
                }
                else
                {
                    ltrScript.Text = JSHelper.GetAlertScript("조직정보가 없습니다.", false);
                    return;
                }

                ynStr = "Y";
                estDeptOrgDetail.RemoveEstDeptOrgDetail(conn, trx, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), 0, 0);
            }
            else // 드릴다운 사용
            {
                if (TreeView1.SelectedNode != null)
                {
                    est_dept_ref_id = int.Parse(TreeView1.SelectedValue);
                    estDeptOrgDetail.ModifyEstDeptOrgDetail(conn, trx, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), "N");
                    estDeptOrgDetail.RemoveEstDeptOrgDetail(conn, trx, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), est_dept_ref_id, 0);
                }
                else
                {
                    ltrScript.Text = JSHelper.GetAlertScript("드릴다운 방식으로 하실 때에는 조직 부서를 선택하셔야 합니다.", false);
                    return;
                }

                ynStr = TypeUtility.GetBooleanToYN(cBoxEstDeptTopYN.Checked);
            }

            for (int i = 0; i < UltraWebGrid1.Rows.Count; i++)
            {
                row = UltraWebGrid1.Rows[i];

                home_yn_col         = (TemplatedColumn)row.Band.Columns.FromKey("HOME_YN_ORG");
                header_yn_col       = (TemplatedColumn)row.Band.Columns.FromKey("HEADER_YN_ORG");
                content_yn_col      = (TemplatedColumn)row.Band.Columns.FromKey("CONTENT_YN_ORG");
                position_col        = (TemplatedColumn)row.Band.Columns.FromKey("POSITION_ORG");

                cBoxHome_YN_Org     = (CheckBox)((CellItem)home_yn_col.CellItems[row.BandIndex]).FindControl("cBoxHome_YN_Org");
                cBoxHeader_YN_Org   = (CheckBox)((CellItem)header_yn_col.CellItems[row.BandIndex]).FindControl("cBoxHeader_YN_Org");
                cBoxContent_YN_Org  = (CheckBox)((CellItem)content_yn_col.CellItems[row.BandIndex]).FindControl("cBoxContent_YN_Org");
                ddlPosition_Org     = (DropDownList)((CellItem)position_col.CellItems[row.BandIndex]).FindControl("ddlPosition_Org");

                estDeptOrgDetail.AddEstDeptOrgDetail(conn
                                                    , trx
                                                    , PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                                    , est_dept_ref_id
                                                    , int.Parse(row.Cells.FromKey("TYPE_REF_ID").Value.ToString())
                                                    , TypeUtility.GetBooleanToYN(cBoxHome_YN_Org.Checked)
                                                    , TypeUtility.GetBooleanToYN(cBoxHeader_YN_Org.Checked)
                                                    , TypeUtility.GetBooleanToYN(cBoxContent_YN_Org.Checked)
                                                    , ynStr
                                                    , int.Parse(ddlPosition_Org.SelectedValue)
                                                    , gUserInfo.Emp_Ref_ID);

                if (cBoxHome_YN_Org.Checked
                    || cBoxHeader_YN_Org.Checked)
                {
                    ddlPosition_Org.Enabled = true;
                }
                else
                {
                    ddlPosition_Org.Enabled = false;
                }
            }

            trx.Commit();

            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.", false);
        }
        catch (Exception ex)
        {
            trx.Rollback();
            conn.Close();
        }
        finally 
        {
            conn.Close();
        }        
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        CheckBox cBoxHome_YN_Org;
        CheckBox cBoxHeader_YN_Org;
        CheckBox cBoxContent_YN_Org;
        DropDownList ddlPosition_Org;
        TemplatedColumn home_yn_col;
        TemplatedColumn header_yn_col;
        TemplatedColumn content_yn_col;
        TemplatedColumn position_col;

        home_yn_col         = (TemplatedColumn) e.Row.Band.Columns.FromKey("HOME_YN_ORG");
        header_yn_col       = (TemplatedColumn) e.Row.Band.Columns.FromKey("HEADER_YN_ORG");
        content_yn_col      = (TemplatedColumn) e.Row.Band.Columns.FromKey("CONTENT_YN_ORG");
        position_col        = (TemplatedColumn) e.Row.Band.Columns.FromKey("POSITION_ORG");

        cBoxHome_YN_Org     = (CheckBox)((CellItem)home_yn_col.CellItems[e.Row.BandIndex]).FindControl("cBoxHome_YN_Org");
        cBoxHeader_YN_Org   = (CheckBox)((CellItem)header_yn_col.CellItems[e.Row.BandIndex]).FindControl("cBoxHeader_YN_Org");
        cBoxContent_YN_Org  = (CheckBox)((CellItem)content_yn_col.CellItems[e.Row.BandIndex]).FindControl("cBoxContent_YN_Org");
        ddlPosition_Org     = (DropDownList)((CellItem)position_col.CellItems[e.Row.BandIndex]).FindControl("ddlPosition_Org");

        if(drw["HOME_YN_ORG"].ToString() == "Y")
            cBoxHome_YN_Org.Checked = true;
        else
            cBoxHome_YN_Org.Checked = false;

        if(drw["HEADER_YN_ORG"].ToString() == "Y")
            cBoxHeader_YN_Org.Checked = true;
        else
            cBoxHeader_YN_Org.Checked = false;

        if(drw["CONTENT_YN_ORG"].ToString() == "Y")
            cBoxContent_YN_Org.Checked = true;
        else
            cBoxContent_YN_Org.Checked = false;

        PageUtility.FindByValueDropDownList(ddlPosition_Org, drw["POSITION_ORG"].ToString());

        cBoxHome_YN_Org.Attributes.Add      ("onclick", string.Format("CheckCtrl('{0}', '{1}', '{2}', '{3}', '{4}')", cBoxHome_YN_Org.ClientID, cBoxHome_YN_Org.ClientID, cBoxHeader_YN_Org.ClientID, cBoxContent_YN_Org.ClientID, ddlPosition_Org.ClientID));
        cBoxHeader_YN_Org.Attributes.Add    ("onclick", string.Format("CheckCtrl('{0}', '{1}', '{2}', '{3}', '{4}')", cBoxHeader_YN_Org.ClientID, cBoxHome_YN_Org.ClientID, cBoxHeader_YN_Org.ClientID, cBoxContent_YN_Org.ClientID, ddlPosition_Org.ClientID));
        cBoxContent_YN_Org.Attributes.Add   ("onclick", string.Format("CheckCtrl('{0}', '{1}', '{2}', '{3}', '{4}')", cBoxContent_YN_Org.ClientID, cBoxHome_YN_Org.ClientID, cBoxHeader_YN_Org.ClientID, cBoxContent_YN_Org.ClientID, ddlPosition_Org.ClientID));

        if (cBoxHome_YN_Org.Checked
                    || cBoxHeader_YN_Org.Checked)
        {
            ddlPosition_Org.Enabled = true;
        }
        else
        {
            ddlPosition_Org.Enabled = false;
        }
    }
    protected void itnClearEstDeptOrg_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EstDeptOrgDetails estDeptOrgDetail = new Biz_EstDeptOrgDetails();
        estDeptOrgDetail.RemoveEstDeptOrgDetail(null, null, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), 0, 0);

        iBtnSearch_Click(null, null);
        BindingOrgType(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        iBtnSave_1.Visible = false;
        //iBtnSave_2.Visible = false;
        //itnClearEstDeptOrg.Visible = false;
    }
    protected void itnClearDeptDrill_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EstDeptOrgDetails estDeptOrgDetail = new Biz_EstDeptOrgDetails();
        estDeptOrgDetail.RemoveEstDeptOrgDetail(null, null, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), int.Parse(TreeView1.SelectedValue), 0);

        iBtnSearch_Click(null, null);
        BindingOrgType(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        iBtnSave_1.Visible = false;
    }
    private void SetVisibleButton()
    {
        if (rtlDrildownYN.SelectedIndex == 1)
        {
            cBoxEstDeptTopYN.Visible = false;

            if (TreeView1.Nodes.Count > 0)
            {
                iBtnSave_2.Visible          = true;
                itnClearEstDeptOrg.Visible  = true;
                itnClearDeptDrill.Visible   = true;
            }
            else
            {
                iBtnSave_2.Visible              = false;
                itnClearEstDeptOrg.Visible      = false;
                itnClearDeptDrill.Visible       = false;
            }
        }
        else
        {
            cBoxEstDeptTopYN.Visible        = true;

            if (TreeView1.Nodes.Count > 0)
            {
                if (TreeView1.SelectedNode != null)
                {
                    iBtnSave_2.Visible          = true;
                    itnClearEstDeptOrg.Visible  = true;
                    itnClearDeptDrill.Visible   = true;
                }
                else
                {
                    iBtnSave_2.Visible          = false;
                    itnClearEstDeptOrg.Visible  = false;
                    itnClearDeptDrill.Visible   = false;
                }
            }
            else 
            {
                iBtnSave_2.Visible              = false;
                itnClearEstDeptOrg.Visible      = false;
                itnClearDeptDrill.Visible       = false;
            }
        }
    }
    private void GridBinding() 
    {
        Biz_EstDeptOrgDetails estDeptOrgDetail  = new Biz_EstDeptOrgDetails();
        Biz_DeptTypeInfo deptTypeInfo           = new Biz_DeptTypeInfo();

        if (rtlDrildownYN.SelectedIndex == 1)
        {
            if (TreeView1.Nodes.Count > 0)
            {
                UltraWebGrid1.Clear();
                UltraWebGrid1.DataSource = estDeptOrgDetail.GetEstDeptOrgDetail(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), Convert.ToInt32(TreeView1.Nodes[0].Value));
                UltraWebGrid1.DataBind();
            }
            else
            {
                UltraWebGrid1.DataSource = deptTypeInfo.GetDeptTypeList();
                UltraWebGrid1.DataBind();
            }
        }
        else 
        {
            if (TreeView1.Nodes.Count > 0)
            {
                if (TreeView1.SelectedNode != null)
                {
                    UltraWebGrid1.Clear();
                    DataSet ds = estDeptOrgDetail.GetEstDeptOrgDetail(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), Convert.ToInt32(TreeView1.SelectedNode.Value));
                    UltraWebGrid1.DataSource = ds;
                    UltraWebGrid1.DataBind();
                }
                else
                {
                    UltraWebGrid1.DataSource = deptTypeInfo.GetDeptTypeList();
                    UltraWebGrid1.DataBind();
                }
            }
            else
            {
                UltraWebGrid1.DataSource = deptTypeInfo.GetDeptTypeList();
                UltraWebGrid1.DataBind();
            }
        }
    }
    protected void rtlDrildownYN_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetVisibleButton();
        GridBinding();
        //CheckDrillDownYN(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
    }
    
}
