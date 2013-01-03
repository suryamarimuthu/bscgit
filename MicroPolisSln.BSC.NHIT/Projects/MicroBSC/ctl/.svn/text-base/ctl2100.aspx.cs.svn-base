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
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Biz;
using MicroBSC.Common;

public partial class usr_usr2100 : AppPageBase
{
    #region 변수선언
    
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnRefreshEmp.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    private int _idept_ref_id;
    private int _iup_dept_id;
    private string _idept_name;
    private string _iup_dept_name;
    private int _idept_type;
    private int _isort_order;
    private string _idept_desc;
    private string _idept_code;

    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebCommon.FillComDeptTree(TreeView1);
            WebCommon.SetDeptTypeDropDownList(ddlDeptType, false);

            hImgNew.Visible      = false;
            ibtnDelete.Visible   = false;

            ibtnDelete.Attributes.Add("onclick", "return confirm('정말 사원을 삭제하시겠습니까?');");
            ibtnRollback.Attributes.Add("onclick", "return confirm('선택한 사원을 다시 사용하시겠습니까?');");
            ibnUpdatePos.Attributes.Add("onclick", "return confirm('평가데이터에 현재 인사데이터의 직급,직책으로 업데이트 하시겠습니까?');");
            ibnUpdateDpt.Attributes.Add("onclick", "return confirm('평가데이터에 현재 인사데이터의 부서로로 업데이트 하시겠습니까?');");
        }

        txtSearch.Attributes["onkeypress"] = "if (event.keyCode==13) {" + Page.GetPostBackEventReference(ibtnSearch) + ";return false;}";

        Literal1.Text   = "";
        ltrScript.Text  = "";
    }

    #region 내부함수

    private DataSet GetEmpInfoList(string dept_ref_id)
    {
        EmpInfos emp = new EmpInfos();
        return emp.GetEmpInfoByDeptID(dept_ref_id);
    }

    private void SetFormData(int iDeptId)
    {
        Biz_ComDeptInfo objDept     = new Biz_ComDeptInfo(iDeptId);
        hdfDeptRefId.Value          = objDept.Idept_ref_id.ToString();
        txtDeptName.Text            = objDept.Idept_name;
        hdfUpDeptRefId.Value        = objDept.Iup_dept_id.ToString();
        txtUpDeptName.Text          = objDept.Iup_dept_name;
        ddlDeptType.SelectedValue   = objDept.Idept_type.ToString();
        txtSortOrder.Text           = objDept.Isort_order.ToString();
        chkUseYn.Checked            = objDept.Idept_flag;
        txtCreateDate.Text          = objDept.Create_date.ToString();
        hdfDeptLevel.Value          = objDept.Idept_level.ToString();

        /* 2011-02-22 수정 : 부서코드를 표시하도록 수정 */
        txtDeptCode.Text = objDept.Idept_code;
        /* 2011-02-22 완료 ******************************/
    }

    private void SetParameter()
    {
        _idept_ref_id               = int.Parse(hdfDeptRefId.Value.ToString());
        _idept_name                 = txtDeptName.Text.Trim();
        _iup_dept_id                = int.Parse(hdfUpDeptRefId.Value.ToString());
        _iup_dept_name              = txtUpDeptName.Text.Trim();
        _idept_type                 = (ddlDeptType.Items.Count > 0) ? int.Parse(ddlDeptType.SelectedValue) : 1;
        _isort_order                = int.Parse(txtSortOrder.Text);
        _idept_desc                 = txtDeptDesc.Text;

        /* 2011-02-22 수정 : 부서코드를 표시하도록 수정 */
        _idept_code = txtDeptCode.Text;
        /* 2011-02-22 완료 ******************************/
    }

    private void SetSelectTree()
    {
        if (TreeView1.SelectedNode == null)
            return;
        string deptId               = TreeView1.SelectedNode.Value;
        SetFormData(int.Parse(deptId));
        UltraWebGrid1.Clear();

        DataSet ds = GetEmpInfoList(deptId);

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();

        if (!hImgNew.Visible)
            hImgNew.Visible = true;

        if (!ibtnDelete.Visible)
            ibtnDelete.Visible = true;
    }

    private void AddDeptNode(string strGubun)
    {
        if (hdfDeptRefId.Value.Trim() == "" || txtDeptName.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서를 선택해주십시오.", false);
            return;
        }

        if (strGubun == "BROTHER" && (hdfUpDeptRefId.Value.Trim() == "" || txtUpDeptName.Text.Trim() == ""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("최상위 레벨이므로 동위레벨등록을 할수 없습니다.", false);
            return;
        }

        this.SetParameter();
        if (strGubun == "CHILD")
        {
            _iup_dept_id = _idept_ref_id;
        }

        _idept_ref_id = -1;
        Biz_ComDeptInfo objDept = new Biz_ComDeptInfo();
        int intRtn              = objDept.InsertData(_iup_dept_id, 0, _idept_name, "", 1, _idept_type, _isort_order, _idept_desc, gUserInfo.Emp_Ref_ID);

        if (objDept.Transaction_Result == "Y")
        {
            hdfDeptRefId.Value = objDept.Idept_ref_id.ToString();
        }

        TreeNode cTrn = new TreeNode(_idept_name);
        if (strGubun == "CHILD")
        {
            TreeView1.SelectedNode.ChildNodes.Add(cTrn);
        }
        else
        {
            TreeView1.SelectedNode.Parent.ChildNodes.Add(cTrn);
        }

        cTrn.Select();
    }

    private void InsertUpdateDeptInfo()
    {
        if (hdfDeptRefId.Value.Trim() == "" || txtDeptName.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서를 선택해주십시오.", false);
            return;
        }

        this.SetParameter();

        Biz_ComDeptInfo objDept = new Biz_ComDeptInfo();
        int intRtn  = objDept.UpdateData( _idept_ref_id
                                        , _iup_dept_id
                                        , 0
                                        , _idept_name
                                        , _idept_code       //_idept_ref_id.ToString(),
                                        , 1
                                        , _idept_type
                                        , _isort_order
                                        , _idept_desc
                                        , gUserInfo.Emp_Ref_ID);

        WebCommon.FillComDeptTree(TreeView1);
        TreeView1.ExpandAll();
        SetButtons();
    }

    #endregion

    #region 서버 이벤트 처리 함수

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.txtSearch.Text = "";
        radType.SelectedIndex = 0;
        SetSelectTree();
        SetButtons();
    }
    protected void ibtnSelect_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnRollback_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        int iChecked = 0;
        string sPKs = "";
        string[,] saPKs;


        for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
        {
            row = UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                sPKs += row.Cells.FromKey("EMP_REF_ID") + ";" + row.Cells.FromKey("DEPT_REF_ID") + ";";
                iChecked++;
            }
        }

        if (iChecked <= 0)
        {
            PageUtility.AlertMessage("먼저 사용할 유저를 선택하셔야 합니다!");
            return;
        }
        else
        {
            saPKs = TypeUtility.GetSplit(sPKs, 2);

            int iRet = 0;
            Biz_ctl_ctl2100 biz = new Biz_ctl_ctl2100();

            iRet = biz.ChgFlagRelBackDeptInfo(saPKs);

            //SetSelectTree();
            SearchEmpInfo();
        }
    }
    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        int iChecked = 0;
        string sPKs = "";
        string[,] saPKs;


        for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
        {
            row = UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                sPKs += row.Cells.FromKey("EMP_REF_ID") + ";" + row.Cells.FromKey("DEPT_REF_ID") + ";";
                iChecked++;
            }
        }

        if (iChecked <= 0)
        {
            PageUtility.AlertMessage("먼저 삭제할 유저를 선택하셔야 합니다!");
            return;
        }
        else
        {
            saPKs = TypeUtility.GetSplit(sPKs, 2);

            int iRet = 0;
            Biz_ctl_ctl2100 biz = new Biz_ctl_ctl2100();

            iRet = biz.ChgFlagRelDeptInfo(saPKs);

            SetSelectTree();
        }
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        EmpInfos empInfo = new EmpInfos();

        int empId = int.Parse(dr["EMP_REF_ID"].ToString());

        e.Row.Cells.FromKey("MODIFY").Value = string.Format(
                    "<a href=\"#null\" onclick=\"openwindow('Modify', '{0}');\"><img src='../images/drafts.gif' border='0'></a>", empId.ToString());
    
        e.Row.Cells.FromKey("ROLE").Value = string.Format(
                    "<a href=\"#null\" onclick=\"gfOpenWindow('ctl2100_Role.aspx?emp_ref_id={0}&CCB1={1}', 600, 460, true, true, 'editForm')\"><img src='../images/drafts.gif' border='0'></a>", empId.ToString(), this.ICCB1);

        e.Row.Cells.FromKey("EMP_NAMES").Value = empInfo.GetRoleNamesArray(empId);
    }
    protected void lBtnGridReload_Click(object sender, EventArgs e)
    {
        string deptId = TreeView1.SelectedNode.Value;

        UltraWebGrid1.Clear();
        DataSet ds = GetEmpInfoList(deptId);
        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        if (this.txtSearch.Text.Trim() == "")
            SetSelectTree();
        else
            SearchEmpInfo();
    }

    protected void lBtnRefreshEmp_Click(object sender, EventArgs e)
    {
        SetSelectTree();
    }

    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        InsertUpdateDeptInfo();
    }

    // 동위레벨 추가
    protected void iBtnAddBrother_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDeptNode("BROTHER");

        WebCommon.FillComDeptTree(TreeView1);
        TreeView1.ExpandAll();
        SetButtons();
    }
    protected void iBtnAddChild_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = "";
        this.AddDeptNode("CHILD");

        WebCommon.FillComDeptTree(TreeView1);
        TreeView1.ExpandAll();
        SetButtons();
    }
    protected void itnDelete_Click(object sender, ImageClickEventArgs e)
    {
        DeptInfos dept = new DeptInfos();

        if (TreeView1.SelectedValue.Equals(""))
            return;

        bool isOK = dept.RemoveDeptinfo(int.Parse(TreeView1.SelectedValue));

        if (!isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("소속되어 있는 부서나 사원이 있습니다. 확인 후 삭제 해주세요.", false);
            return;
        }
        else
        {
            WebCommon.FillComDeptTree(TreeView1);
            TreeView1.ExpandAll();
            SetButtons();

            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제되었습니다.", false);
            return;
        }
    }
    private void SetButtons()
    {
        if(TreeView1.SelectedNode == null)
        {
            Panel1.Visible          = false;

            hdfDeptRefId.Value      = "";
            txtDeptName.Text        = "";
            hdfUpDeptRefId.Value    = "";
            txtUpDeptName.Text      = "";
            txtSortOrder.Text       = "";
            txtCreateDate.Text      = "";
            hdfDeptLevel.Value      = "";
            txtDeptCode.Text = string.Empty;
        }
        else
        {
            Panel1.Visible = true;
        }
    }

    private void SearchEmpInfo()
    {
        EmpInfos emp = new EmpInfos();

        string searchType = WebUtility.GetByValueDropDownList(ddlSchType);
        string searchText = this.txtSearch.Text.Trim();
        int useYN = WebUtility.GetIntByValueRadioButtonList(radType);
        if (useYN == 0)
            ibtnRollback.Visible = true;
        else
            ibtnRollback.Visible = false;

        UltraWebGrid1.Clear();
        DataSet ds = emp.GetEmpInfoSearch(searchType, searchText, useYN);
        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchEmpInfo();
    }

    protected void ibnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EmpInfos empInfo  = new Biz_EmpInfos();
        DataTable dataTable   = empInfo.GetDataTableSchema();

        dataTable   = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "EMP_REF_ID" }
                                                            , dataTable);

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가데이터에 직급,직책을 반영하려는 사원이 선택되지 않았습니다.");
            return;
        }

        string emp_ref_ids  = "";
        bool isFirst        = true;

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            if(isFirst) 
            {
                isFirst = false;
                emp_ref_ids += DataTypeUtility.GetValue(dataRow["EMP_REF_ID"]);
            }
            else 
            {
                emp_ref_ids += "," + DataTypeUtility.GetValue(dataRow["EMP_REF_ID"]);
            }
        }

        string ctrlID = (sender as ImageButton).ID;
        string type = "";

        if(ctrlID.Equals("ibnUpdatePos"))
            type = "POS";
        else if(ctrlID.Equals("ibnUpdateDpt"))
            type = "DPT";

        WebUtility.PopupPage(ltrScript
                            , "../EST/EST060602.aspx?EMP_REF_IDS=" + emp_ref_ids + "&TYPE=" + type
                            , 400
                            , 120
                            , "popup_pos");
    }

    #endregion
    
}
