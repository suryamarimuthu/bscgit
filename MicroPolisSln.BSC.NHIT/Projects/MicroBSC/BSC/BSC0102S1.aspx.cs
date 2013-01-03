using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0102S1 : AppPageBase
{
    #region 전역변수
    protected bool IPOSSIBLE_COPY
    {
        get
        {
            if (ViewState["POSSIBLE_COPY"] == null)
                ViewState["POSSIBLE_COPY"] = false;
            return (bool)ViewState["POSSIBLE_COPY"];
        }
        set
        {
            ViewState["POSSIBLE_COPY"] = value;
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
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    } 
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        TreeMapCreate();
        TabExpand("V");
        UgrdView_Bind();
        if (!Page.IsPostBack)
        {
           
        }
        
    }
    private void TabExpand(string types)
    {
        trvEstDept.Nodes[0].Expanded = true;
        if (types == "V")
        {
            for (int i = 0; i < trvEstDept.Nodes[0].ChildNodes.Count; i++)
            {
                int stcount = trvEstDept.Nodes[0].ChildNodes[i].ChildNodes.Count;
                trvEstDept.Nodes[0].ChildNodes[i].Expanded = false;
            }
        }
        if (types == "S")
        {
            for (int i = 0; i < trvEstDept.Nodes[0].ChildNodes.Count; i++)
            {
                int stcount = trvEstDept.Nodes[0].ChildNodes[i].ChildNodes.Count;
                trvEstDept.Nodes[0].ChildNodes[i].Expanded = true;
                for (int j = 0; j < stcount; j++)
                {
                    trvEstDept.Nodes[0].ChildNodes[i].ChildNodes[j].Expanded = false;
                }
            }
        }
        if (types == "K")
        {
            for (int i = 0; i < trvEstDept.Nodes[0].ChildNodes.Count; i++)
            {
                int stcount = trvEstDept.Nodes[0].ChildNodes[i].ChildNodes.Count;
                trvEstDept.Nodes[0].ChildNodes[i].Expanded = true;
                for (int j = 0; j < stcount; j++)
                {
                    int kpicount = trvEstDept.Nodes[0].ChildNodes[i].ChildNodes[j].ChildNodes.Count;
                    trvEstDept.Nodes[0].ChildNodes[i].ChildNodes[j].Expanded = true;
                    for (int k = 0; k < kpicount; k++)
                    {
                        trvEstDept.Nodes[0].ChildNodes[i].ChildNodes[j].ChildNodes[k].Expanded = false;
                    }
                    
                }
            }
        }
    }
    #region Tab 이벤트
    protected void ugrdKpiStatusTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        if (e.Tab.Key == "1")
        {
            UgrdView_Bind();
            TabExpand("V");
        }
        if (e.Tab.Key == "2")
        {
            ViewInfo_ddlBind();
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetUseYnDropDownList(ddlUseYn, true);
            //WebCommon.SetEstTermDropDownList(ddlEstTermInfo2);
            this.IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            //DoSetPossibleCopay();

            SetStgGrid();

            SetAllTimeBottom();
            TabExpand("S");
        }
        if (e.Tab.Key == "3")
        {
            WebCommon.SetUseYnDropDownList(ddlUseYn3, true);
            KpiPoolUpSkillBind();
            MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
            objCode.GetKpiType(ddlKpiType, "", true, 0);
            objCode.GetKpiExternalType(ddlKpi, "", true, 0);

            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver bizBscKpiPoolVer = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver();

            DataTable dtBscKpiPoolVer = bizBscKpiPoolVer.GetBscKpiPoolVer_DB();

            ddlKpiVersion.DataValueField = "KPI_POOL_VER_ID";
            ddlKpiVersion.DataTextField = "KPI_POOL_VER_NAME";
            ddlKpiVersion.DataSource = dtBscKpiPoolVer;
            ddlKpiVersion.DataBind();

            ddlKpiVersion.Items.Insert(0, new ListItem(":: 전체 ::", "0"));

            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete bizBscKpiPoolTemplete = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete();

            DataTable dtBscKpiPoolTemplete = bizBscKpiPoolTemplete.GetBscKpiPoolTemplete_DB();

            ddlKpiTemplete.DataValueField = "KPI_POOL_TEMPLETE_ID";
            ddlKpiTemplete.DataTextField = "KPI_POOL_TEMPLETE_NAME";
            ddlKpiTemplete.DataSource = dtBscKpiPoolTemplete;
            ddlKpiTemplete.DataBind();

            ddlKpiTemplete.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
            SetKpiPoolGrid();
            TabExpand("K");
        }
    } 
    #endregion

    #region 관점관리 그리드 바인딩
    private void UgrdView_Bind()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        DataSet rDs = objBSC.GetAllList();

        ugrdView.Clear();
        if (rDs.Tables.Count > 0)
        {
            ugrdView.DataSource = rDs;
            ugrdView.DataBind();
        }
    } 
    #endregion

    #region 관점관리 그리드 이벤트
    protected void ugrdView_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                                    "../images/icon_o.gif" : "../images/icon_x.gif";


        string use_yn = (DataTypeUtility.GetValue(e.Row.Cells.FromKey("USE_YN")) == "Y") ? "U" : "D";

        string view_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("VIEW_REF_ID").Value);
        string view_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("VIEW_NAME").Value);

        string url = "<a href='#' onclick='doPoppingUp_View(\"{0}\",\"{1}\",\"{2}\")'>{3}</a>";
        string link = string.Format(url, use_yn, view_ref_id, ICCB1, view_name);

        e.Row.Cells.FromKey("VIEW_NAME").Value = link;
    } 
    #endregion

    #region 전략관리 관점 드롭다운 바인딩
    private void ViewInfo_ddlBind()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        DataSet rDs = objBSC.GetAllList();
        ddlStgViewInfo.Items.Add(new ListItem(":: 전체 ::", "0"));
        if (rDs.Tables.Count > 0)
        {
            for(int i=0; i < rDs.Tables[0].Rows.Count; i++)
            {
                ddlStgViewInfo.Items.Add(new ListItem(rDs.Tables[0].Rows[i]["VIEW_NAME"].ToString(), rDs.Tables[0].Rows[i]["VIEW_REF_ID"].ToString()));
            }
        }
    } 
    #endregion

    #region 전략관리 드롭다운 이벤트
    //protected void ddlEstTermInfo2_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DoSetPossibleCopay();
    //} 
    #endregion

    #region 전략관리 내보내기 버튼
    //protected void ibtnCopy_Click(object sender, ImageClickEventArgs e)
    //{
    //    MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();
    //    if (objBSC.CopyStg(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo), WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), gUserInfo.Emp_Ref_ID))
    //        PageUtility.AlertMessage("복사하였습니다.");
    //    else
    //        PageUtility.AlertMessage("복사 실패!");
    //    DoSetPossibleCopay();
    //} 
    #endregion

    #region 전략관리 조회 버튼
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetStgGrid();
    } 
    #endregion

    #region 전략관리 Reload 버튼
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        SetStgGrid();
    } 
    #endregion

    #region 전략관리 그리드 이벤트
    protected void ugrdStgList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        TemplatedColumn cCol1 = (TemplatedColumn)e.Row.Band.Columns.FromKey("MAPYN");
        Image objImg1 = (Image)((CellItem)cCol1.CellItems[e.Row.BandIndex]).FindControl("imgUseMapYn");
        objImg1.ImageUrl = (e.Row.Cells.FromKey("MAPYN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";


        string use_yn = (DataTypeUtility.GetValue(e.Row.Cells.FromKey("USE_YN").Value) == "Y") ? "U" : "D";
        string stg_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("STG_REF_ID").Value);
        string stg_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("STG_NAME").Value);

        string url = "<a href='#' onclick='doPoppingUp_StgList(\"{0}\",\"{1}\",\"{2}\",\"{3}\")'>{4}</a>";
        string link = string.Format(url, use_yn, IESTTERM_REF_ID, stg_ref_id, ICCB1, stg_name);

        e.Row.Cells.FromKey("STG_NAME").Value = link;
    } 
    #endregion

    #region 전략관리 그리드 바인드
    protected void SetStgGrid()
    {
        //if (TypeUtility.GetNumString(PageUtility.GetByValueDropDownList(ddlEstTermInfo)) == "")
        //{
        //    PageUtility.AlertMessage("평가기간을 알 수 없습니다!");
        //    return;
        //}

        MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();
        objBSC.Iestterm_ref_id = Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlEstTermInfo));
        objBSC.Istg_code = txtKPICode.Text;
        objBSC.Istg_name = txtKPIName.Text;
        objBSC.Iuse_yn = PageUtility.GetByValueDropDownList(ddlUseYn);

        //DataSet rDs = objBSC.GetAllList(objBSC.Iestterm_ref_id, objBSC.Istg_code, objBSC.Istg_name, objBSC.Iuse_yn);
        DataSet rDs = objBSC.GetAllList(objBSC.Istg_code, objBSC.Istg_name, objBSC.Iuse_yn, PageUtility.GetByValueDropDownList(ddlStgViewInfo));
        ugrdStgList.Clear();

        if (rDs.Tables.Count > 0)
        {
            ugrdStgList.DataSource = rDs;
            ugrdStgList.DataBind();
        }
    } 
    #endregion

    protected void btnMapEdit_Click(object sender, EventArgs e)
    {
        int rows = ugrdStgList.Rows.Count;
        if (rows > 0)
        {
            for (int i = 0; i < rows; i++)
            {
                UltraGridRow row = ugrdStgList.Rows[i];
                TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");
                if (cBox.Checked)
                {
                    int stg_ref_id = DataTypeUtility.GetToInt32(row.Cells.FromKey("STG_REF_ID").Value);
                    int view_ref_id = DataTypeUtility.GetToInt32(row.Cells.FromKey("VIEW_REF_ID").Value);
                    new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().KpiPoolMapEdit(stg_ref_id, view_ref_id);
                }
            }
            ltrScript.Text = JSHelper.GetSclipt("변경 되었습니다.");
            SetStgGrid();
        }
        //new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().KpiPoolMapEdit(1, 1);
    }

    private void TreeMapCreate()
    {
        trvEstDept.Nodes.Clear();

        TreeNode Root = new TreeNode("풀맵");
        Root.ImageUrl = "../images/icon/02_2.gif";
        Root.SelectAction = TreeNodeSelectAction.Expand;
        DataTable ParentDt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().KpiPoolMapFirstSelect();
        DataTable SecondDt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().KpiPoolMapSecondSelect();
        DataTable ThirddDt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().KpiPoolMapThirdSelect();

        for (int i = 0; i < ParentDt.Rows.Count; i++)
        {
            TreeNode node = new TreeNode();
            node.Text = ParentDt.Rows[i]["VIEW_NAME"].ToString();
            node.Value = ParentDt.Rows[i]["VIEW_REF_ID"].ToString();
            node.ImageUrl = "../images/stg/TREE_V.gif";
            node.SelectAction = TreeNodeSelectAction.Expand;
            Root.ChildNodes.Add(node);
        }

        for (int i = 0; i < SecondDt.Rows.Count; i++)
        {
            foreach (TreeNode node in Root.ChildNodes)
            {
                if (node.Value == SecondDt.Rows[i]["VIEW_REF_ID"].ToString())
                {
                    TreeNode cnode = new TreeNode();
                    cnode.Text = SecondDt.Rows[i]["STG_NAME"].ToString();
                    cnode.Value = SecondDt.Rows[i]["STG_REF_ID"].ToString();
                    cnode.ImageUrl = "../images/stg/TREE_S.gif";
                    cnode.SelectAction = TreeNodeSelectAction.Expand;
                    node.ChildNodes.Add(cnode);
                }
            }
        }

        for (int i = 0; i < ThirddDt.Rows.Count; i++)
        {
            foreach (TreeNode node in Root.ChildNodes)
            {
                foreach(TreeNode snode in node.ChildNodes)
                {
                    if (snode.Value == ThirddDt.Rows[i]["STG_REF_ID"].ToString())
                    {
                        TreeNode cnode = new TreeNode();
                        cnode.Text = ThirddDt.Rows[i]["KPI_NAME"].ToString();
                        cnode.Value = ThirddDt.Rows[i]["KPI_POOL_REF_ID"].ToString();
                        cnode.ImageUrl = "../images/stg/TREE_K.gif";
                        cnode.SelectAction = TreeNodeSelectAction.Expand;
                        snode.ChildNodes.Add(cnode);
                    }
                }
            }
        }

        trvEstDept.Nodes.Add(Root);
    }

    private TreeNode SearchNode(TreeNodeCollection objNodes, string strKey)
    {
        foreach(TreeNode node in objNodes)
        {
            if(node.Value == strKey)
            {
                return node;
            }
            TreeNode findNode = SearchNode(node.ChildNodes, strKey);
            if (findNode != null)
            {
                return findNode;
            }
        }
        return null;
    }

    #region 전략관리
    //private void DoSetPossibleCopay()
    //{
    //    MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Stg_Info();
    //    DataTable dt = objBSC.GetAllList(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo2), "", "", "").Tables[0];
    //    this.IPOSSIBLE_COPY = (dt.Rows.Count > 0 ? false : true);
    //}

    private void SetAllTimeBottom()
    {
        if (ddlEstTermInfo.Items.Count == 0)
        {
            divAdd.Visible = false;
        }
    } 
	#endregion

    #region kpi풀 그리드 바인드
    public void SetKpiPoolGrid()
    {
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool bizBscKpiPool = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool();

        DataTable dtBscKpiPool = bizBscKpiPool.GetKpiPool_DB(txtKpiNames.Text.Trim(),
                                                           PageUtility.GetByValueDropDownList(ddlUseYn3),
                                                           PageUtility.GetByValueDropDownList(ddlKpiType),
                                                           DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlKpiVersion)),
                                                           DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlKpiTemplete)),
                                                           DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlUpPoint)),
                                                           DataTypeUtility.GetString(PageUtility.GetByValueDropDownList(ddlKpi)));

        ugrdKPIPool.Clear();
        ugrdKPIPool.DataSource = dtBscKpiPool;
        ugrdKPIPool.DataBind();

        lblRowCount.Text = dtBscKpiPool.Rows.Count.ToString();
    } 
    #endregion

    #region KPI풀 상위전략 바인드
    private void KpiPoolUpSkillBind()
    {
        ddlUpPoint.Items.Add(new ListItem(":: 전체 ::", "0"));
        DataTable dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver().Select_UpSkill_DB();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlUpPoint.Items.Add(new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
            }
        }
    } 
    #endregion

    protected void lBtnReloadKpi(object sender, EventArgs e)
    {
        this.SetKpiPoolGrid();
    }

    protected void iBtnSearch_Click3(object sender, ImageClickEventArgs e)
    {
        this.SetKpiPoolGrid();
    }

    #region kpi풀 그리드 생성 이벤트
    protected void ugrdKPIPool_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";



        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);
        string kpi_pool_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value);
        string iType = DataTypeUtility.GetValue(e.Row.Cells.FromKey("USE_YN").Value).Equals("Y") ? "U" : "D";

        string link = "<a href='#null' onclick=\"doInsertingKpi('{0}','{1}','{2}')\">{3}</a>";
        string url = string.Format(link, iType, kpi_pool_ref_id, ICCB1, kpi_name);

        e.Row.Cells.FromKey("KPI_NAME").Value = url;
    } 
    #endregion

    #region kpi풀 관리 버젼관리 클릭
    protected void iBtnVersion_Click(object sender, ImageClickEventArgs e)
    {
        int cnt = ugrdKPIPool.Rows.Count;

        string kpi_pool_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = ugrdKPIPool.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                kpi_pool_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("KPI_POOL_REF_ID").Value);
            }
        }

        if (kpi_pool_id_list.Length > 0)
        {
            BizUtility.KPI_POOL_LIST = kpi_pool_id_list.Remove(0, 1);
        }

        string url = "BSC0301M3.aspx";
        string str = string.Format("gfOpenWindow('{0}', 800, 400, false, false, '_bk');", url);
        ltrScript.Text = JSHelper.GetSclipt(str);
    } 
    #endregion

    #region #region kpi풀 관리 템플릿관리 클릭
    protected void iBtnTemplete_Click(object sender, ImageClickEventArgs e)
    {
        int cnt = ugrdKPIPool.Rows.Count;

        string kpi_pool_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = ugrdKPIPool.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                kpi_pool_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("KPI_POOL_REF_ID").Value);
            }
        }

        if (kpi_pool_id_list.Length > 0)
        {
            BizUtility.KPI_POOL_LIST = kpi_pool_id_list.Remove(0, 1);
        }

        string url = "BSC0301M4.aspx";
        string str = string.Format("gfOpenWindow('{0}', 800, 400, false, false, '_bk');", url);
        ltrScript.Text = JSHelper.GetSclipt(str);
    } 
    #endregion
}
