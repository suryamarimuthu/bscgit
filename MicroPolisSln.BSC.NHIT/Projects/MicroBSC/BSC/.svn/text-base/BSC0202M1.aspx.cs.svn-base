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

public partial class BSC_BSC0202M1 : AppPageBase
{
    #region 변수선언
    // Control for Call Back
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public string ITypeTree
    {
        get
        {
            ViewState["ITYPE_TREE"] = hdfITypeTree.Value;
            return (string)ViewState["ITYPE_TREE"];
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

    public int IVersionRefID
    {
        get
        {
            if (ViewState["VERSION_REF_ID"] == null)
            {
                ViewState["VERSION_REF_ID"] = GetRequestByInt("VERSION_REF_ID", 0);
            }

            return (int)ViewState["VERSION_REF_ID"];
        }
        set
        {
            ViewState["VERSION_REF_ID"] = value;
        }
    }

    public decimal IIdx
    {
        get
        {
            if (ViewState["IDX"] == null)
            {
                ViewState["IDX"] = decimal.Parse(GetRequest("IDX", "0"));
            }

            return (decimal)ViewState["IDX"];
        }
        set
        {
            ViewState["IDX"] = value;
        }
    }

    public decimal IIdxParent
    {
        get
        {
            if (ViewState["IDX_PARENT"] == null)
            {
                ViewState["IDX_PARENT"] = decimal.Parse(GetRequest("IDX_PARENT", "0"));
            }

            return (decimal)ViewState["IDX_PARENT"];
        }
        set
        {
            ViewState["IDX_PARENT"] = value;
        }
    }
    #endregion

    #region 페이지 초기화 함수
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
    
    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        this.SetStgVersion();
        this.SetParam();
        this.SetStgTree(trvStg);
        this.SetButton();
    }

    private void InitControlEvent()
    {
        //iBtnFindParent.Attributes.Add("onclick", "return ShowPopUp();");
    }

    private void SetPageData()
    {
        this.SetStgGrid();
        this.SetStgTerm();
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {
        
    }
    #endregion

    #region 내부함수
    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnVerClear.Visible       = false;
            iBtnVerInsert.Visible      = true;
            iBtnVerUpdate.Visible      = false;
            iBtnVerDelete.Visible      = false;

            iBtnNodeAddBrother.Visible = false;
            iBtnNodeAddChild.Visible   = false;
            iBtnNodeDelete.Visible     = false;
            iBtnNodeUpdate.Visible     = false;
            iBtnFindParent.Visible     = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnVerClear.Visible       = true;
            iBtnVerInsert.Visible      = false;
            iBtnVerUpdate.Visible      = true;
            iBtnVerDelete.Visible      = true;

            iBtnNodeAddBrother.Visible = true;
            iBtnNodeAddChild.Visible   = true;
            iBtnNodeDelete.Visible     = true;
            iBtnNodeUpdate.Visible     = true;
            iBtnFindParent.Visible     = true;
        }
        else
        {
            iBtnVerClear.Visible       = false;
            iBtnVerInsert.Visible      = false;
            iBtnVerUpdate.Visible      = false;
            iBtnVerDelete.Visible      = false;

            iBtnNodeAddBrother.Visible = false;
            iBtnNodeAddChild.Visible   = false;
            iBtnNodeDelete.Visible     = false;
            iBtnNodeUpdate.Visible     = false;
            iBtnFindParent.Visible     = false;
        }
    }

    public void SetParam()
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IVersionRefID = PageUtility.GetIntByValueDropDownList(ddlStgTreeVersion);
    }

    /// <summary>
    /// 전략버젼 세팅
    /// </summary>
    public void SetStgVersion()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Version objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Version();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID);

        ddlStgTreeVersion.Items.Clear();
        if (rDs.Tables.Count > 0)
        {
            ddlStgTreeVersion.DataSource     = rDs.Tables[0].DefaultView;
            ddlStgTreeVersion.DataTextField  = "VERSION_NAME";
            ddlStgTreeVersion.DataValueField = "VERSION_REF_ID";
            ddlStgTreeVersion.DataBind();

            if (ddlStgTreeVersion.Items.Count > 0)
            {
                this.IType = "U";
            }
        }
    }

    /// <summary>
    /// 전략버젼 적용기간 선택
    /// </summary>
    public void SetStgTerm()
    {
        if (ddlStgTreeVersion.SelectedValue != null)
        {
            txtVERSION_NAME.Text = PageUtility.GetByTextDropDownList(ddlStgTreeVersion);
            this.IType = "U";
            this.SetButton();
        }
        else
        {
            txtVERSION_NAME.Text = "";
            ugrdTerm.Clear();
            return;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Term objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Term();
        DataSet rDs = objBSC.GetAllList( this.IEstTermRefID
                                       , this.IVersionRefID);

        ugrdTerm.Clear();
        if (rDs.Tables.Count > 0)
        {
            ugrdTerm.DataSource = rDs.Tables[0].DefaultView;
            ugrdTerm.DataBind();
        }
    }

    /// <summary>
    /// 전략풀 그리드 조회
    /// </summary>
    protected void SetStgGrid()
    {
        if (TypeUtility.GetNumString(PageUtility.GetByValueDropDownList(ddlEstTermInfo)) == "")
        {
            PageUtility.AlertMessage("평가기간을 알 수 없습니다!");
            return;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree();
        objBSC.IEstterm_Ref_Id = this.IEstTermRefID;
        objBSC.IVersion_Ref_Id = this.IVersionRefID;

        //DataSet rDs = objBSC.GetAllList(objBSC.Iestterm_ref_id, objBSC.Istg_code, objBSC.Istg_name, objBSC.Iuse_yn);
        DataSet rDs = objBSC.GetUsedStgCount(objBSC.IEstterm_Ref_Id, objBSC.IVersion_Ref_Id);

        ugrdStgList.Clear();

        if (rDs.Tables.Count > 0)
        {
            ugrdStgList.DataSource = rDs;
            ugrdStgList.DataBind();
        }
    }

    /// <summary>
    /// 전략 버젼, 적용기간 저장.수정.삭제
    /// </summary>
    /// <returns></returns>
    public bool TrxStgVersion()
    {
        int iRtn = 0;
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Version objVer = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Version();
        objVer.IEstterm_Ref_Id = this.IEstTermRefID;
        objVer.IVersion_Ref_Id = this.IVersionRefID;
        objVer.IVersion_Name   = txtVERSION_NAME.Text;

        if (this.IType == "A")
        {
            iRtn = objVer.TrxVersionAndTerm
                         (  this.IType
                          , objVer.IEstterm_Ref_Id
                          , 0
                          , objVer.IVersion_Name
                          , gUserInfo.Emp_Ref_ID
                          , this.GetStgVersionData());
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iRtn = objVer.TrxVersionAndTerm
                         (  this.IType
                          , objVer.IEstterm_Ref_Id
                          , objVer.IVersion_Ref_Id
                          , objVer.IVersion_Name
                          , gUserInfo.Emp_Ref_ID
                          , this.GetStgVersionData());
        }

        this.IVersionRefID = objVer.IVersion_Ref_Id;

        return (iRtn>0) ? true : false;
    }

    /// <summary>
    /// 전략관계 데이터 체크
    /// </summary>
    /// <param name="isAdd">입력/수정 여부</param>
    /// <param name="isChild">입력이라면 형제인지 자식인지</param>
    /// <returns></returns>
    public bool ValidateStgData()
    {
        if (txtSelStg.Text == "A")
        {
            ltrScript.Text = JSHelper.GetAlertScript("전략을 선택해 주십시오.", false);
            return false;
        }

        if (this.ITypeTree == "A")
        {
            if (hdfStgPoolId.Value == "" || !PageUtility.IsAllNumber(hdfStgPoolId.Value))
            {
                ltrScript.Text = JSHelper.GetAlertScript("추가할 전략을 선택해 주십시오.");
                return false;
            }
        }

        if (this.ITypeTree == "D")
        {
            if (trvStg.SelectedNode.ChildNodes.Count > 0)
            {
                ltrScript.Text = JSHelper.GetAlertScript("하위전략이 존재합니다. 삭제할 수 없습니다.", false);
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 전략트리 데이터 입출력
    /// </summary>
    public bool TrxStgTreeData(bool isChild)
    {
        if (!ValidateStgData())
        {
            return false;
        }

        this.SetParam();
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree objStg = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree();
        objStg.IEstterm_Ref_Id = this.IEstTermRefID;
        objStg.IVersion_Ref_Id = this.IVersionRefID;
        objStg.IIdx            = this.IIdx;
        objStg.IParent_Idx     = (isChild) ? this.IIdx : this.IIdxParent;
        objStg.IStg_Ref_Id     = (this.ITypeTree == "U" || this.ITypeTree == "D") ? 0 : int.Parse(hdfStgPoolId.Value);
        objStg.ISort_Order     = int.Parse(txtSORT_ORDER.Text);
        objStg.ICreate_User    = gUserInfo.Emp_Ref_ID;

        if (this.ITypeTree == "A")
        {
            int iRtn = objStg.InsertData(null
                                       , null
                                       , this.IEstTermRefID
                                       , this.IVersionRefID
                                       , objStg.IStg_Ref_Id
                                       , objStg.IParent_Idx
                                       , objStg.ISort_Order
                                       , objStg.ICreate_User);

            ltrScript.Text = JSHelper.GetAlertScript(objStg.Transaction_Message, false);
            if (objStg.Transaction_Result == "Y")
            {
                this.IIdx = objStg.IIdx;
                return true;
            }

        }
        else if (this.ITypeTree == "U")
        {
            int iRtn = objStg.UpdateData(null
                                       , null
                                       , this.IIdx
                                       , this.IEstTermRefID
                                       , this.IVersionRefID
                                       , objStg.IStg_Ref_Id
                                       , objStg.IParent_Idx
                                       , objStg.ISort_Order
                                       , objStg.ICreate_User);
            ltrScript.Text = JSHelper.GetAlertScript(objStg.Transaction_Message, false);
            if (objStg.Transaction_Result == "Y")
            {
                return true;
            }
        }
        else if (this.ITypeTree == "D")
        {
            decimal[] arrIdx = new decimal[1];
            TreeNode tn = trvStg.SelectedNode;
            int iLoop = 1;

            //자신
            if (tn != null)
            {
                arrIdx[0] = decimal.Parse(tn.Value);
            }
            //자식
            //foreach (TreeNode trn in tn.ChildNodes)
            //{
            //    decimal dTmp = decimal.Parse(trn.Value);
            //    if (dTmp > 0)
            //    {
            //        iLoop++;
            //        Array.Resize(ref arrIdx, iLoop);
            //        arrIdx[iLoop - 1] = dTmp;
            //    }
            //}
            
            //상위부모 다 삭제
            //while (tn != null)
            //{
            //    decimal dTmp = decimal.Parse(tn.Value);
            //    if (dTmp > 0)
            //    {
            //        Array.Resize(ref arrIdx, iLoop);
            //        arrIdx[iLoop - 1] = dTmp;
            //        iLoop++;
            //    }                
            //    tn = tn.Parent;
            //}

            int iRtn = objStg.DeleteMultiNode(arrIdx, objStg.ICreate_User);
            ltrScript.Text = JSHelper.GetAlertScript(objStg.Transaction_Message, false);
            if (objStg.Transaction_Result == "Y")
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 전략버젼 적용기간 데이터 추출
    /// </summary>
    /// <returns></returns>
    public DataTable GetStgVersionData()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Term objTrm = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree_Term();
        DataTable dtTerm = objTrm.GetSchemaStgTreeTerm();
        DataRow   drTerm = null;

        CheckBox chkAPPLY;
        TemplatedColumn colAPPLY = (TemplatedColumn)ugrdTerm.Columns.FromKey("APPLY_YN");
        int iRow = ugrdTerm.Rows.Count;
        for(int i = 0; i < iRow; i++)
        {
            chkAPPLY = (CheckBox)((CellItem)colAPPLY.CellItems[ugrdTerm.Rows[i].BandIndex]).FindControl("chkCheckTerm");
            
            if (chkAPPLY.Checked)
            {
                drTerm = dtTerm.NewRow();
                drTerm["ESTTERM_REF_ID"] = ugrdTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value;
                drTerm["VERSION_REF_ID"] = ugrdTerm.Rows[i].Cells.FromKey("VERSION_REF_ID").Value;
                drTerm["YMD"]            = ugrdTerm.Rows[i].Cells.FromKey("YMD").Value;
                dtTerm.Rows.Add(drTerm);
            }
        }

        return dtTerm;
    }

    /// <summary>
    /// 전략트리 설정
    /// </summary>
    public void SetStgTree(TreeView iTreeView)
    {
        iTreeView.Nodes.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree objTree = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree();
        DataTable rDt = objTree.GetStgTree(this.IEstTermRefID, this.IVersionRefID);

        TreeNode tnRoot = new TreeNode(PageUtility.GetByTextDropDownList(ddlStgTreeVersion), "0");
        iTreeView.Nodes.Add(tnRoot);
        tnRoot.Checked = true;
        //tnRoot.SelectAction = TreeNodeSelectAction.Expand;

        for (int i = 0; i < rDt.Rows.Count; i++)
        {
            string sID = rDt.Rows[i]["IDX"].ToString();
            string sNM = rDt.Rows[i]["STG_NAME"].ToString();
            string sPT = rDt.Rows[i]["PARENT_IDX"].ToString();

            foreach (TreeNode tnC in iTreeView.CheckedNodes)
            {
                if (tnC.Value == sPT)
                {
                    TreeNode tnNode = new TreeNode(sNM, sID);
                    tnC.ChildNodes.Add(tnNode);
                    tnNode.Checked = true;
                    if (this.IIdx.ToString() == sID)
                    {
                        tnNode.Select();
                    }
                    break;
                }
            }
        }

        if (trvStg.SelectedNode != null && trvStg.SelectedNode.Parent != null)
        {
            this.IIdx            = decimal.Parse(trvStg.SelectedNode.Value);
            this.IIdxParent      = decimal.Parse(trvStg.SelectedNode.Value);
            txtSelStg.Text       = trvStg.SelectedNode.Text;
            txtSelStgParent.Text = trvStg.SelectedNode.Parent.Text;
            trvStg.ExpandAll();
        }
        else
        {
            this.SetInitStgForm();
        }
    }

    /// <summary>
    /// 전략트리 선택
    /// </summary>
    public void SetTreeNodeSelection()
    {
        TreeNode tnSelect = null;
        foreach (TreeNode tnC in trvStg.CheckedNodes)
        {
            if (tnC.Value == this.IIdx.ToString())
            {
                tnC.Select();
                tnC.Collapse();
                tnSelect = tnC;
                break;
            }
        }

        if (tnSelect != null)
        {
            txtSelStg.Text = tnSelect.Text;

            this.IIdxParent      = decimal.Parse(tnSelect.Parent.Value);
            txtSelStgParent.Text = tnSelect.Parent.Text;

            hdfITypeTree.Value = "U";
        }

        while (tnSelect != null)
        {
            tnSelect.Expand();
            tnSelect = tnSelect.Parent;
        }
    }

    public void SetStgTreeInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree objTree = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Tree(this.IIdx);
        txtSORT_ORDER.Text = objTree.ISort_Order.ToString();
    }

    public void SetInitStgForm()
    {
        hdfITypeTree.Value   = "";
        hdfStgPoolId.Value   = "";
        txtSelStg.Text       = "";
        txtSelStgParent.Text = "";
        txtSORT_ORDER.Text   = "0";
        this.IIdx            = 0;
        this.IIdxParent      = 0;
    }

    public void SetStgPopUpTree()
    {
        trvStgParent.Nodes.Clear();
        this.SetStgTree(trvStgParent);
        trvStgParent.ExpandAll();
        divAreaPopUp.Style.Add(HtmlTextWriterStyle.Display, "block");
    }
    #endregion

    #region 이벤트
    protected void trvStg_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.IIdx      = decimal.Parse(trvStg.SelectedNode.Value);
        txtSelStg.Text = trvStg.SelectedNode.Text;

        if (trvStg.SelectedNode.Parent != null)
        {
            this.IIdxParent      = decimal.Parse(trvStg.SelectedNode.Parent.Value);

            txtSelStgParent.Text = trvStg.SelectedNode.Parent.Text;
            hdfITypeTree.Value   = "U";
        }
        else
        {
            this.IIdxParent      = 0;
            txtSelStgParent.Text = "";
            hdfITypeTree.Value   = "";
        }
        
        if (this.IIdx > 0)
        {
            this.SetStgTreeInfo();
        }
    }

    protected void trvStgParent_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (this.IIdx.ToString() == trvStgParent.SelectedNode.Value)
        {
            ltrScript.Text = JSHelper.GetAlertScript("부모의 전략과 동일한 전략입니다.", false);
            return;
        }
        else
        {
            this.IIdxParent = decimal.Parse(trvStgParent.SelectedNode.Value);
            txtSelStgParent.Text = trvStgParent.SelectedNode.Text;
            divAreaPopUp.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }
    
    protected void iBtnNodeAddBrother_Click(object sender, ImageClickEventArgs e)
    {
        if (this.TrxStgTreeData(false))
        {
            this.SetStgTree(trvStg);
            this.SetTreeNodeSelection();
            this.SetStgGrid();
        }
    }
    protected void iBtnNodeAddChild_Click(object sender, ImageClickEventArgs e)
    {
        if (this.TrxStgTreeData(true))
        {
            this.SetStgTree(trvStg);
            this.SetTreeNodeSelection();
            this.SetStgGrid();
        }
    }
    protected void iBtnNodeDelete_Click(object sender, ImageClickEventArgs e)
    {
        TreeNode tnPrn = trvStg.SelectedNode;
        hdfITypeTree.Value = "D";
        bool bRtn = this.TrxStgTreeData(false);
        if (bRtn)
        {
            this.IIdx = decimal.Parse(trvStg.SelectedNode.Parent.Value);
            this.SetStgTree(trvStg);
        }
    }
    protected void iBtnNodeUpdate_Click(object sender, ImageClickEventArgs e)
    {
        bool bRtn = this.TrxStgTreeData(false);
    }

    protected void iBtnVerInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "A";
        bool blnRtn = this.TrxStgVersion();

        if (blnRtn)
        {
            this.SetStgVersion();
            PageUtility.FindByValueDropDownList(ddlStgTreeVersion, this.IVersionRefID);
            this.SetStgTerm();
        }
    }
    protected void iBtnVerUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (txtVERSION_NAME.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("전략명을 입력해 주십시오.", false);
        }

        this.IType  = "U";
        bool blnRtn = this.TrxStgVersion();

        if (blnRtn)
        {
            this.SetStgVersion();
            PageUtility.FindByValueDropDownList(ddlStgTreeVersion, this.IVersionRefID);
            this.SetStgTerm();
        }
    }
    protected void iBtnVerDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "D";
        bool blnRtn = this.TrxStgVersion();

        if (blnRtn)
        {
            this.SetStgVersion();
            this.SetParam();
            this.SetStgTree(trvStg);
            this.SetButton();
            ltrScript.Text = JSHelper.GetAlertScript("해당 버전이 삭제되었습니다.");
        }
        else
        {
            this.IType = "U";
            ltrScript.Text = JSHelper.GetAlertScript("버전삭제시 오류가 발생되었습니다.");
        }
    }
    protected void iBtnVerClear_Click(object sender, ImageClickEventArgs e)
    {
        this.IType           = "A";
        txtVERSION_NAME.Text = "";
        ddlStgTreeVersion.SelectedValue = null;
        this.SetButton();
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetParam();
        this.SetStgTerm();
        this.SetStgTree(trvStg);
        this.SetStgGrid();
        trvStg.ExpandAll();
    }
    
    protected void ugrdTerm_InitializeRow(object sender, RowEventArgs e)
    {
        int iVersion = (e.Row.Cells.FromKey("VERSION_REF_ID").Value != null) ? int.Parse(e.Row.Cells.FromKey("VERSION_REF_ID").Value.ToString()) : 0;
        if (iVersion == this.IVersionRefID)
        {
            CheckBox chkAPPLY;
            TemplatedColumn colAPPLY = (TemplatedColumn)ugrdTerm.Columns.FromKey("APPLY_YN");
            chkAPPLY = (CheckBox)((CellItem)colAPPLY.CellItems[e.Row.BandIndex]).FindControl("chkCheckTerm");

            chkAPPLY.Checked = true;
        }
    }

    protected void iBtnFindParent_Click(object sender, ImageClickEventArgs e)
    {
        this.SetStgPopUpTree();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.SetStgVersion();
        this.SetStgTree(trvStg);
        this.SetButton();
    }
    #endregion
}
