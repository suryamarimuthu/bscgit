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

using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0401M1 : AppPageBase
{
    #region 변수선언
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("ITYPE", "S");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 1000);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IEstDeptRefID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 1000);
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
                ViewState["MAP_VERSION_ID"] = GetRequestByInt("MAP_VERSION_ID", 1);
            }

            return (int)ViewState["MAP_VERSION_ID"];
        }
        set
        {
            ViewState["MAP_VERSION_ID"] = value;
        }
    }

    public string ITreeSelType
    {
        get
        {
            if (ViewState["TREE_SEL_TYPE"] == null)
            {
                ViewState["TREE_SEL_TYPE"] = GetRequest("TREE_SEL_TYPE");
            }

            return (string)ViewState["TREE_SEL_TYPE"];
        }
        set
        {
            ViewState["TREE_SEL_TYPE"] = value;
        }
    }

    public string ITreeSelTypeName
    {
        get
        {
            if (ViewState["TREE_SEL_TYPE_NAME"] == null)
            {
                ViewState["TREE_SEL_TYPE_NAME"] = GetRequest("TREE_SEL_TYPE_NAME");
            }

            return (string)ViewState["TREE_SEL_TYPE_NAME"];
        }
        set
        {
            ViewState["TREE_SEL_TYPE_NAME"] = value;
        }
    }

    public string ITreeSelText
    {
        get
        {
            if (ViewState["TREE_SEL_TEXT"] == null)
            {
                ViewState["TREE_SEL_TEXT"] = GetRequest("TREE_SEL_TEXT");
            }

            return (string)ViewState["TREE_SEL_TEXT"];
        }
        set
        {
            ViewState["TREE_SEL_TEXT"] = value;
        }
    }

    public string ITreeSelValue
    {
        get
        {
            if (ViewState["TREE_SEL_VALUE"] == null)
            {
                ViewState["TREE_SEL_VALUE"] = GetRequest("TREE_SEL_VALUE","0");
            }

            return (string)ViewState["TREE_SEL_VALUE"];
        }
        set
        {
            ViewState["TREE_SEL_VALUE"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD");
            }
            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    UltraWebGrid TugrdUpStgList;
    UltraWebGrid TugrdStgPerDept;

    ImageButton  TiBtnAddUpStg;
    ImageButton  TiBtnDelUpStg;

    UltraWebGrid TugrdKPIPerStg;
    UltraWebGrid TugrdKPIAll;

    ImageButton  TiBtnAddKpi;
    ImageButton  TiBtnDelKpi;
    ImageButton  TiBtnFindKpi;

    TextBox      TtxtFindKpiID;
    TextBox      TtxtFindKpiNM;
    Label        TlblWeightTotal;

    //public string ESTTERM_REF_ID    = "";
    //public string EST_DEPT_REF_ID   = "";
    //public string YMD               = "";

    #endregion

    #region 페이지 초기화 함수
    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            ugwtKpiTab.SelectedTabIndex = 0;
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();

        this.ugrdKPIPerStg.Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "챔피언");
        this.ugrdKPIAll.Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "챔피언");
    }

    private void SetAllTimeTop()
    {
        ltrScript.Text = "";

        TugrdUpStgList  = this.ugwtKpiTab.FindControl("ugrdUpStgList")  as UltraWebGrid;
        TugrdStgPerDept = this.ugwtKpiTab.FindControl("ugrdStgPerDept") as UltraWebGrid;

        TiBtnAddUpStg   = this.ugwtKpiTab.FindControl("iBtnAddUpStg")  as ImageButton;
        TiBtnDelUpStg   = this.ugwtKpiTab.FindControl("iBtnDelUpStg")  as ImageButton;

        TugrdKPIPerStg  = this.ugwtKpiTab.FindControl("ugrdKPIPerStg") as UltraWebGrid;
        TugrdKPIAll     = this.ugwtKpiTab.FindControl("ugrdKPIAll")    as UltraWebGrid;

        TiBtnAddKpi     = this.ugwtKpiTab.FindControl("iBtnAddKpi")    as ImageButton;
        TiBtnDelKpi     = this.ugwtKpiTab.FindControl("iBtnDelKpi")    as ImageButton;
        TiBtnFindKpi    = this.ugwtKpiTab.FindControl("iBtnFindKpi")   as ImageButton;

        TtxtFindKpiID   = this.ugwtKpiTab.FindControl("txtFindKpiID")  as TextBox;
        TtxtFindKpiNM   = this.ugwtKpiTab.FindControl("txtFindKpiNM")  as TextBox;

        TlblWeightTotal = this.ugwtKpiTab.FindControl("lblWeightTotal") as Label;

        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        ddlMAP_KPI_TYPE_H.DataSource = objCode.GetCodeListPerCategory("BS0017", "Y").Tables[0];
        ddlMAP_KPI_TYPE_H.DataTextField = "CODE_NAME";
        ddlMAP_KPI_TYPE_H.DataValueField = "ETC_CODE";
        ddlMAP_KPI_TYPE_H.DataBind();
        ddlMAP_KPI_TYPE_H.Items.Insert(0, new ListItem("::선택::", ""));
    }

    private void InitControlValue()
    {
        this.SetMapVersionDDL();
        this.SetMapInfo(true);


        ugrdKPIAll.Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = GetText("LBL_00001", "챔피언");
        ugrdKPIPerStg.Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = GetText("LBL_00001", "챔피언");
    }

    private void SetPostBack()
    {
    }

    private void SetAllTimeBottom()
    {
        
    }
    #endregion

    #region 내부함수

    /// <summary>
    /// Map Info Master Setting
    /// </summary>
    private void SetFormType()
    {
        this.ITreeSelType     = trvStgMap.SelectedNode.Value.Substring(0, 1);
        this.ITreeSelValue    = trvStgMap.SelectedNode.Value.Substring(1, trvStgMap.SelectedNode.Value.Length-1);
        this.ITreeSelText     = trvStgMap.SelectedNode.Text;
        this.ITreeSelTypeName = "";

        switch (this.ITreeSelType)
        {
            case "D" : // 부서
                this.ITreeSelTypeName = "부서";
                pnlDept.Visible = true;
                pnlSTG.Visible = false;
                pnlKPI.Visible = false;
                pnlKPIDetail.Visible = false;
                break;
            case "V" : // 관점
                this.ITreeSelTypeName = "관점";
                pnlDept.Visible = false;
                pnlSTG.Visible = true;
                pnlKPI.Visible = false;
                pnlKPIDetail.Visible = false;
                this.SetStrategy(false);
                break;
            case "S":  // 전략
                this.ITreeSelTypeName = "전략";
                pnlDept.Visible = false;
                pnlSTG.Visible = false;
                pnlKPI.Visible = true;
                pnlKPIDetail.Visible = false;
                this.SetKpi(false);
                this.SetParentStg();
                break;
            case "K":  // KPI
                this.ITreeSelTypeName = "KPI";
                pnlDept.Visible = false;
                pnlSTG.Visible = false;
                pnlKPI.Visible = false;
                pnlKPIDetail.Visible = true;
                this.SetKpiChildGrid();
                break;
            default:
                pnlDept.Visible = false;
                pnlSTG.Visible = false;
                pnlKPI.Visible = false;
                pnlKPIDetail.Visible = false;
                break;
        }

        lblSelType.Text   = this.ITreeSelTypeName;
        lblSelTypeNM.Text = this.ITreeSelText;
    }

    /// <summary>
    /// Set Button By Role and Authority
    /// </summary>
    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnInsertMapInfo.Visible = true;
            iBtnUpdateMapInfo.Visible = false;
            iBtnDeleteMapInfo.Visible = false;
            iBtnInitMapInfo.Visible   = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsertMapInfo.Visible = false;
            iBtnUpdateMapInfo.Visible = true;
            iBtnDeleteMapInfo.Visible = false;
            iBtnInitMapInfo.Visible   = true;
        }
        else
        {
            iBtnInsertMapInfo.Visible = false;
            iBtnUpdateMapInfo.Visible = false;
            iBtnDeleteMapInfo.Visible = false;
            iBtnInitMapInfo.Visible   = false;
        }
    }

    /// <summary>
    /// 전략맵 버젼 Dropdownlist설정
    /// </summary>
    private void SetMapVersionDDL()
    { 
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objVer = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info();
        DataSet dsVer = objVer.GetMapVersionList(this.IEstTermRefID, this.IEstDeptRefID);
        ddlMapVersion.DataSource     = dsVer;
        ddlMapVersion.DataTextField  = "MAP_VERSION_NAME";
        ddlMapVersion.DataValueField = "MAP_VERSION_ID";
        ddlMapVersion.DataBind();

        if (ddlMapVersion.Items.Count > 0)
        {
            ddlMapVersion.SelectedIndex = 0;
            this.IMapVersionID          = int.Parse(ddlMapVersion.SelectedValue);
            this.IType                  = "U";
        }
        else
        {
            this.IMapVersionID          = 0;
            this.IType                  = "A";
        }

        this.SetButton();
    }

    /// <summary>
    /// 폼초기값 설정
    /// </summary>
    private void SetInitForm()
    {
        txtMapVersionID.Text   = "";
        txtMapVersionName.Text = "";
        txtMapDesc.Text        = "";
    }

    /// <summary>
    /// 맵기본정보설정
    /// </summary>
    /// <param name="IsMapTermRefresh">맵기본정보를 재설정할것인지 여부</param>
    private void SetMapInfo(bool IsMapTermRefresh)
    {
        this.IMapVersionID = PageUtility.GetIntByValueDropDownList(ddlMapVersion);

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objMap = null;
        if (this.IMapVersionID < 1 && (!IsPostBack))
        {
            objMap = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info(this.IEstTermRefID, this.IEstDeptRefID, this.IYmd);
            ddlMapVersion.SelectedValue = objMap.Imap_version_id.ToString();
            this.IMapVersionID          = objMap.Imap_version_id;
        }
        else
        {
            objMap = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info(this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID);
        }

        this.DrawMapTree();

        txtTermDesc.Text       = objMap.Iest_term_name;
        txtEstDeptName.Text    = objMap.Iest_dept_name;
        hdfBSCChampionID.Value = objMap.Ibscchampion_emp_id.ToString();
        txtBSCChampion.Text    = objMap.Ibscchampion_name;
        txtDeptVision.Text     = objMap.Idept_vision;
        txtMapVersionID.Text   = objMap.Imap_version_id.ToString();
        txtMapVersionName.Text = objMap.Imap_version_name;
        txtMapDesc.Text        = objMap.Imap_desc;

        if (IsMapTermRefresh)
        {
            DataSet dsTerm = objMap.GetMapTermList(this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID);
            ugrdTerm.Clear();
            ugrdTerm.DataSource = dsTerm;
            ugrdTerm.DataBind();
        }

        if (trvStgMap.SelectedNode != null)
        {
            this.SetFormType();
        }
    }

    /// <summary>
    /// 전략맵 트리설정
    /// </summary>
    private void DrawMapTree()
    {
        string strSelVal = "";

        if (trvStgMap.SelectedNode != null)
        {
            strSelVal = trvStgMap.SelectedNode.Value;
        }

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objTrv = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info();
        objTrv.DrawMapTree(trvStgMap, this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID, strSelVal);
    }

    /// <summary>
    /// 전략맵 트리 초기화
    /// </summary>
    private void DrawMapTreeInit()
    {
        string strSelVal = "";

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objTrv = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info();
        objTrv.DrawMapTree(trvStgMap, this.IEstTermRefID, this.IEstDeptRefID, -1, strSelVal);
    }
    
    /// <summary>
    /// 선택된 전략 리스트
    /// </summary>
    /// <param name="isSelectAll"></param>
    private void SetStrategy(bool isSelectAll)
    {
        int    intFindStgID = (txtFindStgID.Text == "") ? 0 : int.Parse(txtFindStgID.Text);
        string strFindStgNM = txtFindStgNM.Text;

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg objSTG = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg();
        DataSet dsSTG = objSTG.GetStrategyPerView(this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID, int.Parse(this.ITreeSelValue));
        
        ugrdStgPerView.Clear();
        ugrdStgPerView.DataSource = dsSTG;
        ugrdStgPerView.DataBind();

        ugrdStgAll.Clear();
        if (isSelectAll)
        {
            DataSet dsSTGAll = objSTG.GetAllStrategyExceptDept(this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID, intFindStgID, strFindStgNM);
            ugrdStgAll.DataSource = dsSTGAll;
            ugrdStgAll.DataBind();
        }
    }

    /// <summary>
    /// 상위전략 리스트
    /// </summary>
    private void SetParentStg()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg_Parent objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg_Parent();
        DataSet dsStg = objBSC.GetParentStgList(this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID, int.Parse(this.ITreeSelValue));

        TugrdUpStgList.Clear();
        TugrdUpStgList.DataSource = dsStg;
        TugrdUpStgList.DataBind();

        DataSet dsAllStg = objBSC.GetDeptStgListExceptParentStg(this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID, int.Parse(this.ITreeSelValue));
        TugrdStgPerDept.Clear();
        TugrdStgPerDept.DataSource = dsAllStg;
        TugrdStgPerDept.DataBind();

    }

    /// <summary>
    /// 전략별 KPI 리스트 조회/ KPI 총가중치 조회
    /// </summary>
    /// <param name="isSelectAll"></param>
    private void SetKpi(bool isSelectAll)
    {
        int    intFindKpiID = (TtxtFindKpiID.Text == "") ? 0 : int.Parse(TtxtFindKpiID.Text);
        string strFindKpiNM = TtxtFindKpiNM.Text;

        MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKPI = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi();
        DataSet dsKPI    = objKPI.GetKpiListPerStg(this.IEstTermRefID, this.IEstDeptRefID, this.IMapVersionID, int.Parse(this.ITreeSelValue));
        TugrdKPIPerStg.Clear();
        TugrdKPIPerStg.DataSource = dsKPI;
        TugrdKPIPerStg.DataBind();

        TugrdKPIAll.Clear();
        if (isSelectAll)
        {
            DataSet dsKPIAll = objKPI.GetAllKpiExceptDept(this.IEstTermRefID
                                                        , this.IEstDeptRefID
                                                        , this.IMapVersionID
                                                        , intFindKpiID
                                                        , strFindKpiNM
                                                        , txtChampion.Text
                                                        , txtMgmDept.Text);
            TugrdKPIAll.DataSource = dsKPIAll;
            TugrdKPIAll.DataBind();
        }

        DataSet dsWeight = objKPI.GetWeightPerDept(this.IEstTermRefID, this.IEstDeptRefID, this.IYmd);
        if (dsWeight.Tables[0].Rows.Count > 0)
        {
            double dblWeight          = double.Parse(dsWeight.Tables[0].Rows[0]["WEIGHT"].ToString());
            TlblWeightTotal.ForeColor = (dblWeight != 100) ? Color.Red : Color.Blue;
            TlblWeightTotal.Text      = Convert.ToString(Math.Round(dblWeight, 2, MidpointRounding.ToEven));
        }
    }

    /// <summary>
    /// 하위 KPI 리스트
    /// </summary>
    private void SetKpiChildGrid()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
        DataSet rDs = objBSC.GetKpiChildList(this.IEstTermRefID, int.Parse(this.ITreeSelValue));

        ugrdChildKpiList.Clear();
        ugrdChildKpiList.DataSource = rDs;
        ugrdChildKpiList.DataBind();
    }

    /// <summary>
    /// 하위 KPI 대상 리스트 
    /// </summary>
    //private void SetKpiChildTargetGrid()
    //{
    //    MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();
    //    DataSet rDs = objBSC.GetKpiChildTargetList(this.IEstTermRefID, int.Parse(this.ITreeSelValue),"","", "","");

    //    ugrdKpiTargetList.Clear();
    //    ugrdKpiTargetList.DataSource = rDs;
    //    ugrdKpiTargetList.DataBind();
    //}

    /// <summary>
    /// 관점별 전략 추가/삭제
    /// </summary>
    /// <param name="iType"></param>
    private void AddDelStrategy(string iType)
    { 
        DataTable rDT1 = new DataTable("BSC_MAP_STG");
        rDT1.Columns.Add("ITYPE",              typeof(string));
        rDT1.Columns.Add("ESTTERM_REF_ID",     typeof(int));
        rDT1.Columns.Add("EST_DEPT_REF_ID",    typeof(int));
        rDT1.Columns.Add("MAP_VERSION_ID",     typeof(int));
        rDT1.Columns.Add("VIEW_REF_ID",        typeof(int));
        rDT1.Columns.Add("STG_REF_ID",         typeof(int));
        rDT1.Columns.Add("SORT_ORDER",         typeof(int));
        rDT1.Columns.Add("STG_NAME",           typeof(string));
        rDT1.Columns.Add("TXR_USER",           typeof(int));

        int intLogInUser = gUserInfo.Emp_Ref_ID;
        DataRow rDR1;
        DataRow rDR2;
        CheckBox chkCheck;

        int intRow = (iType == "A") ? ugrdStgAll.Rows.Count : ugrdStgPerView.Rows.Count;
        
        for (int i = 0; i < intRow; i++)
        {
            if (iType=="A")
            {
                TemplatedColumn unit_col = (TemplatedColumn)ugrdStgAll.Columns.FromKey("selchk");
                chkCheck = (CheckBox)((CellItem)unit_col.CellItems[ugrdStgAll.Rows[i].BandIndex]).FindControl("cBox");
                if (chkCheck.Checked)
                {
                    rDR1 = rDT1.NewRow();

                    rDR1["ITYPE"]           = iType;
                    rDR1["ESTTERM_REF_ID"]  = this.IEstTermRefID;
                    rDR1["EST_DEPT_REF_ID"] = this.IEstDeptRefID;
                    rDR1["MAP_VERSION_ID"]  = this.IMapVersionID;
                    rDR1["VIEW_REF_ID"]     = (this.ITreeSelValue == "") ? 0 : int.Parse(this.ITreeSelValue);
                    rDR1["STG_REF_ID"]      = (ugrdStgAll.Rows[i].Cells.FromKey("STG_REF_ID").Value == null) ? 0 : int.Parse(ugrdStgAll.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString());
                    rDR1["SORT_ORDER"]      = 0;
                    rDR1["STG_NAME"]        = (ugrdStgAll.Rows[i].Cells.FromKey("STG_NAME").Value == null)   ? "" : ugrdStgAll.Rows[i].Cells.FromKey("STG_NAME").Value.ToString();
                    rDR1["TXR_USER"]        = intLogInUser;
                    rDT1.Rows.Add(rDR1);
                }
            }
            else if (iType=="D")
            {
                TemplatedColumn unit_col = (TemplatedColumn)ugrdStgPerView.Columns.FromKey("selchk");
                chkCheck = (CheckBox)((CellItem)unit_col.CellItems[ugrdStgPerView.Rows[i].BandIndex]).FindControl("cBox");
                if (chkCheck.Checked)
                {
                    rDR1 = rDT1.NewRow();

                    rDR1["ITYPE"]           = iType;
                    rDR1["ESTTERM_REF_ID"]  = (ugrdStgPerView.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? this.IEstTermRefID : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    rDR1["EST_DEPT_REF_ID"] = (ugrdStgPerView.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? this.IEstDeptRefID : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                    rDR1["MAP_VERSION_ID"]  = (ugrdStgPerView.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value == null)  ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value.ToString()); 
                    rDR1["VIEW_REF_ID"]     = (ugrdStgPerView.Rows[i].Cells.FromKey("VIEW_REF_ID").Value == null)     ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("VIEW_REF_ID").Value.ToString()); 
                    rDR1["STG_REF_ID"]      = (ugrdStgPerView.Rows[i].Cells.FromKey("STG_REF_ID").Value == null)      ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString()); 
                    rDR1["SORT_ORDER"]      = (ugrdStgPerView.Rows[i].Cells.FromKey("SORT_ORDER").Value == null)      ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("SORT_ORDER").Value.ToString());
                    rDR1["STG_NAME"]        = (ugrdStgPerView.Rows[i].Cells.FromKey("STG_NAME").Value == null)        ? ""                 : ugrdStgPerView.Rows[i].Cells.FromKey("STG_NAME").Value.ToString();
                    rDR1["TXR_USER"]        = intLogInUser;

                    rDT1.Rows.Add(rDR1);
                }
            }
            else if (iType=="U")
            {
                rDR1 = rDT1.NewRow();

                rDR1["ITYPE"]              = iType;
                rDR1["ESTTERM_REF_ID"]     = (ugrdStgPerView.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? this.IEstTermRefID : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                rDR1["EST_DEPT_REF_ID"]    = (ugrdStgPerView.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? this.IEstDeptRefID : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                rDR1["MAP_VERSION_ID"]     = (ugrdStgPerView.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value == null)  ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value.ToString()); 
                rDR1["VIEW_REF_ID"]        = (ugrdStgPerView.Rows[i].Cells.FromKey("VIEW_REF_ID").Value == null)     ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("VIEW_REF_ID").Value.ToString()); 
                rDR1["STG_REF_ID"]         = (ugrdStgPerView.Rows[i].Cells.FromKey("STG_REF_ID").Value == null)      ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString()); 
                rDR1["SORT_ORDER"]         = (ugrdStgPerView.Rows[i].Cells.FromKey("SORT_ORDER").Value == null)      ? 0                  : int.Parse(ugrdStgPerView.Rows[i].Cells.FromKey("SORT_ORDER").Value.ToString());
                rDR1["STG_NAME"]           = (ugrdStgPerView.Rows[i].Cells.FromKey("STG_NAME").Value == null)        ? ""                 : ugrdStgPerView.Rows[i].Cells.FromKey("STG_NAME").Value.ToString();
                rDR1["TXR_USER"]           = intLogInUser;

                rDT1.Rows.Add(rDR1);
            }
        }

        if (rDT1.Rows.Count > 0)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg objSTG = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg();
            objSTG.TxrAllBscStgMap(rDT1);

            ltrScript.Text = JSHelper.GetAlertScript(objSTG.Transaction_Message, false);

            this.SetStrategy(true);
            this.DrawMapTree();
        }
    }

    /// <summary>
    /// 전략별 KPI 추가/삭제
    /// </summary>
    /// <param name="iType"></param>
    private void AddDelKpi(string iType)
    { 
        DataTable rDT1 = new DataTable("BSC_MAP_STG");
        rDT1.Columns.Add("ITYPE",              typeof(string));
        rDT1.Columns.Add("ESTTERM_REF_ID",     typeof(int));
        rDT1.Columns.Add("EST_DEPT_REF_ID",    typeof(int));
        rDT1.Columns.Add("MAP_VERSION_ID",     typeof(int));
        rDT1.Columns.Add("STG_REF_ID",         typeof(int));
        rDT1.Columns.Add("KPI_REF_ID",         typeof(int));
        rDT1.Columns.Add("WEIGHT",             typeof(double));
        rDT1.Columns.Add("SORT_ORDER",         typeof(int));
        rDT1.Columns.Add("MAP_KPI_TYPE",       typeof(string));
        rDT1.Columns.Add("TXR_USER",           typeof(int));

        int intLogInUser = gUserInfo.Emp_Ref_ID;
        DataRow rDR1;
        CheckBox chkCheck;

        int intRow = (iType == "A") ? TugrdKPIAll.Rows.Count : TugrdKPIPerStg.Rows.Count;
        int cntKpi = TugrdKPIPerStg.Rows.Count+1;

        TemplatedColumn colMKT;
        DropDownList ddlMKT;

        for (int i = 0; i < intRow; i++)
        {
            if (iType=="A")
            {
                TemplatedColumn unit_col = (TemplatedColumn)TugrdKPIAll.Columns.FromKey("selchk");
                chkCheck = (CheckBox)((CellItem)unit_col.CellItems[TugrdKPIAll.Rows[i].BandIndex]).FindControl("cBox");
                if (chkCheck.Checked)
                {
                    rDR1 = rDT1.NewRow();

                    rDR1["ITYPE"] = iType;
                    rDR1["ESTTERM_REF_ID"]  = this.IEstTermRefID;
                    rDR1["EST_DEPT_REF_ID"] = this.IEstDeptRefID;
                    rDR1["MAP_VERSION_ID"]  = this.IMapVersionID;
                    rDR1["STG_REF_ID"]      = (this.ITreeSelValue == "") ? 0 : int.Parse(this.ITreeSelValue);
                    rDR1["KPI_REF_ID"]      = (TugrdKPIAll.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null) ? 0 : int.Parse(TugrdKPIAll.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString());
                    rDR1["WEIGHT"]          = 0;
                    rDR1["SORT_ORDER"]      = cntKpi + i;
                    rDR1["TXR_USER"]        = intLogInUser;
                    rDT1.Rows.Add(rDR1);
                }
            }
            else if (iType=="D")
            {
                TemplatedColumn unit_col = (TemplatedColumn)TugrdKPIPerStg.Columns.FromKey("selchk");
                chkCheck = (CheckBox)((CellItem)unit_col.CellItems[TugrdKPIPerStg.Rows[i].BandIndex]).FindControl("cBox");
                if (chkCheck.Checked)
                {
                    rDR1 = rDT1.NewRow();

                    rDR1["ITYPE"]              = iType;
                    rDR1["ESTTERM_REF_ID"]     = (TugrdKPIPerStg.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? this.IEstTermRefID : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    rDR1["EST_DEPT_REF_ID"]    = (TugrdKPIPerStg.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? this.IEstDeptRefID : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                    rDR1["MAP_VERSION_ID"]     = (TugrdKPIPerStg.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value == null)  ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value.ToString()); 
                    rDR1["STG_REF_ID"]         = (TugrdKPIPerStg.Rows[i].Cells.FromKey("STG_REF_ID").Value == null)      ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString()); 
                    rDR1["KPI_REF_ID"]         = (TugrdKPIPerStg.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)      ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString()); 
                    rDR1["SORT_ORDER"]         = (TugrdKPIPerStg.Rows[i].Cells.FromKey("SORT_ORDER").Value == null)      ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("SORT_ORDER").Value.ToString());
                    rDR1["WEIGHT"]             = (TugrdKPIPerStg.Rows[i].Cells.FromKey("WEIGHT").Value == null)          ? 0                  : double.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("WEIGHT").Value.ToString());
                    rDR1["TXR_USER"]           = intLogInUser;

                    rDT1.Rows.Add(rDR1);
                }
            }
            else if (iType=="U")
            {
                rDR1 = rDT1.NewRow();

                    rDR1["ITYPE"]              = iType;
                    rDR1["ESTTERM_REF_ID"]     = (TugrdKPIPerStg.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? this.IEstTermRefID : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    rDR1["EST_DEPT_REF_ID"]    = (TugrdKPIPerStg.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? this.IEstDeptRefID : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                    rDR1["MAP_VERSION_ID"]     = (TugrdKPIPerStg.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value == null)  ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value.ToString()); 
                    rDR1["STG_REF_ID"]         = (TugrdKPIPerStg.Rows[i].Cells.FromKey("STG_REF_ID").Value == null)      ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString()); 
                    rDR1["KPI_REF_ID"]         = (TugrdKPIPerStg.Rows[i].Cells.FromKey("KPI_REF_ID").Value == null)      ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("KPI_REF_ID").Value.ToString()); 
                    rDR1["SORT_ORDER"]         = (TugrdKPIPerStg.Rows[i].Cells.FromKey("SORT_ORDER").Value == null)      ? 0                  : int.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("SORT_ORDER").Value.ToString());

                    colMKT = (TemplatedColumn)TugrdKPIPerStg.Rows[i].Band.Columns.FromKey("MAP_KPI_TYPE");
                    ddlMKT = (DropDownList)((CellItem)colMKT.CellItems[TugrdKPIPerStg.Rows[i].BandIndex]).FindControl("ddlMAP_KPI_TYPE");

                    rDR1["MAP_KPI_TYPE"]       = PageUtility.GetByValueDropDownList(ddlMKT);
                    rDR1["WEIGHT"]             = (TugrdKPIPerStg.Rows[i].Cells.FromKey("WEIGHT").Value == null)          ? 0                  : double.Parse(TugrdKPIPerStg.Rows[i].Cells.FromKey("WEIGHT").Value.ToString());
                    rDR1["TXR_USER"]           = intLogInUser;

                rDT1.Rows.Add(rDR1);
            }
        }

        if (rDT1.Rows.Count > 0)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKPI = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi();
            objKPI.TxrAllBscMapKpi(rDT1);

            ltrScript.Text = JSHelper.GetAlertScript(objKPI.Transaction_Message, false);

            this.SetKpi(true);
            this.DrawMapTree();
        }
    }

    /// <summary>
    /// 전략맵 & 전략맵기간 추가/삭제
    /// </summary>
    private void AddDelMapInfo()
    {
        if (!CheckMapInfoForm())
        {
            return;
        }

        int LoginUser = gUserInfo.Emp_Ref_ID;
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Info objMap = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Info();
        objMap.TxrMapInfo(this.IType
                        , this.IEstTermRefID
                        , this.IEstDeptRefID
                        , (this.IType=="A") ? 0 : this.IMapVersionID
                        , txtMapVersionName.Text
                        , txtDeptVision.Text
                        , txtMapDesc.Text
                        , (hdfBSCChampionID.Value == "") ? 0 : int.Parse(hdfBSCChampionID.Value)
                        , "Y"
                        , LoginUser
                        , this.GetMapTermList(LoginUser)
                          );

        ltrScript.Text = JSHelper.GetAlertScript(objMap.Transaction_Message, false);

        if (objMap.Transaction_Result == "Y" && this.IType == "A")
        {
            this.SetMapVersionDDL();
            this.ddlMapVersion.SelectedItem.Value = objMap.Imap_version_id.ToString();
        }
        else if (objMap.Transaction_Result == "Y" && this.IType == "U")
        {
            this.SetMapInfo(true);
        }
    }

    /// <summary>
    /// 상위전략 추가/삭제
    /// </summary>
    /// <param name="iType"></param>
    private void AddDelParentStrategy(string iType)
    { 
        DataTable rDT1 = new DataTable("BSC_MAP_STG");
        rDT1.Columns.Add("ITYPE",              typeof(string));
        rDT1.Columns.Add("ESTTERM_REF_ID",     typeof(int));
        rDT1.Columns.Add("EST_DEPT_REF_ID",    typeof(int));
        rDT1.Columns.Add("MAP_VERSION_ID",     typeof(int));
        rDT1.Columns.Add("STG_REF_ID",         typeof(int));
        rDT1.Columns.Add("UP_STG_REF_ID",      typeof(int));
        rDT1.Columns.Add("TXR_USER",           typeof(int));

        int intRow = (iType == "A") ? TugrdStgPerDept.Rows.Count : TugrdUpStgList.Rows.Count;

        CheckBox chkCheck;
        DataRow  rDR1;
        int intLogInUser = gUserInfo.Emp_Ref_ID;
        for (int i = 0; i < intRow; i++)
        {
            if (iType=="A")
            {
                TemplatedColumn unit_col = (TemplatedColumn)TugrdStgPerDept.Columns.FromKey("selchk");
                chkCheck = (CheckBox)((CellItem)unit_col.CellItems[TugrdStgPerDept.Rows[i].BandIndex]).FindControl("cBox");
                if (chkCheck.Checked)
                {
                    rDR1 = rDT1.NewRow();

                    rDR1["ITYPE"] = iType;
                    rDR1["ESTTERM_REF_ID"]  = (TugrdStgPerDept.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? this.IEstTermRefID : int.Parse(TugrdStgPerDept.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    rDR1["EST_DEPT_REF_ID"] = (TugrdStgPerDept.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? this.IEstDeptRefID : int.Parse(TugrdStgPerDept.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                    rDR1["MAP_VERSION_ID"]  = (TugrdStgPerDept.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value == null)  ? this.IMapVersionID : int.Parse(TugrdStgPerDept.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value.ToString());
                    rDR1["STG_REF_ID"]      = (TugrdStgPerDept.Rows[i].Cells.FromKey("STG_REF_ID").Value == null)      ? 0                  : int.Parse(TugrdStgPerDept.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString());
                    rDR1["UP_STG_REF_ID"]   = (TugrdStgPerDept.Rows[i].Cells.FromKey("UP_STG_REF_ID").Value == null)   ? 0                  : int.Parse(TugrdStgPerDept.Rows[i].Cells.FromKey("UP_STG_REF_ID").Value.ToString());
                    rDR1["TXR_USER"]        = intLogInUser;
                    rDT1.Rows.Add(rDR1);
                }
            }
            else if (iType=="D")
            {
                TemplatedColumn unit_col = (TemplatedColumn)TugrdUpStgList.Columns.FromKey("selchk");
                chkCheck = (CheckBox)((CellItem)unit_col.CellItems[TugrdUpStgList.Rows[i].BandIndex]).FindControl("cBox");
                if (chkCheck.Checked)
                {
                    rDR1 = rDT1.NewRow();

                    rDR1["ITYPE"] = iType;
                    rDR1["ESTTERM_REF_ID"]  = (TugrdUpStgList.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null)  ? this.IEstTermRefID : int.Parse(TugrdUpStgList.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                    rDR1["EST_DEPT_REF_ID"] = (TugrdUpStgList.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value == null) ? this.IEstDeptRefID : int.Parse(TugrdUpStgList.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
                    rDR1["MAP_VERSION_ID"]  = (TugrdUpStgList.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value == null)  ? this.IMapVersionID : int.Parse(TugrdUpStgList.Rows[i].Cells.FromKey("MAP_VERSION_ID").Value.ToString());
                    rDR1["STG_REF_ID"]      = (TugrdUpStgList.Rows[i].Cells.FromKey("STG_REF_ID").Value == null)      ? 0                  : int.Parse(TugrdUpStgList.Rows[i].Cells.FromKey("STG_REF_ID").Value.ToString());
                    rDR1["UP_STG_REF_ID"]   = (TugrdUpStgList.Rows[i].Cells.FromKey("UP_STG_REF_ID").Value == null)   ? 0                  : int.Parse(TugrdUpStgList.Rows[i].Cells.FromKey("UP_STG_REF_ID").Value.ToString());
                    rDR1["TXR_USER"]        = intLogInUser;
                    rDT1.Rows.Add(rDR1);
                }
            }
        }

        if (rDT1.Rows.Count > 0)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg_Parent objSTG = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg_Parent();
            bool blnRtn = objSTG.TxrAllBscStgParent(rDT1);

            this.SetParentStg();
            //ltrScript.Text = JSHelper.GetAlertBackScript(objSTG.Transaction_Message);
        }
    }

    /// <summary>
    /// 전략 적용기간 추출
    /// </summary>
    /// <param name="iLoginUser"></param>
    /// <returns></returns>
    private DataTable GetMapTermList(int iLoginUser)
    { 
        ////////////////////////////////////////////////////
        // MAP TERM 
        ////////////////////////////////////////////////////
        int intRow = ugrdTerm.Rows.Count;
        DataTable rDT = new DataTable("BSC_MAP_TERM");

        rDT.Columns.Add("ESTTERM_REF_ID",  typeof(int));
        rDT.Columns.Add("MAP_VERSION_ID",  typeof(int));
        rDT.Columns.Add("EST_DEPT_REF_ID", typeof(int));
        rDT.Columns.Add("YMD",             typeof(string));
        rDT.Columns.Add("APPLY_YN",        typeof(string));
        rDT.Columns.Add("TXR_USER",        typeof(int));


        DataRow rDR;
        CheckBox chkAPPLY;

        TemplatedColumn colAPPLY  = (TemplatedColumn)ugrdTerm.Columns.FromKey("APPLY_YN");
        for (int i = 0; i < intRow; i++)
        { 
            rDR = rDT.NewRow();

            chkAPPLY = (CheckBox)((CellItem)colAPPLY.CellItems[ugrdTerm.Rows[i].BandIndex]).FindControl("chkCheckTerm");

            if (chkAPPLY.Enabled && chkAPPLY.Checked)
            {
                rDR["ESTTERM_REF_ID"]  = (ugrdTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value == null) ? this.IEstTermRefID : int.Parse(ugrdTerm.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
                rDR["EST_DEPT_REF_ID"] = this.IEstDeptRefID;
                rDR["MAP_VERSION_ID"]  = this.IMapVersionID;
                rDR["YMD"]             = (ugrdTerm.Rows[i].Cells.FromKey("YMD").Value == null) ? "" : ugrdTerm.Rows[i].Cells.FromKey("YMD").Value;
                rDR["APPLY_YN"]        = "Y";
                rDR["TXR_USER"]        = iLoginUser;
                
                rDT.Rows.Add(rDR);
            }
        }

        return rDT;
    }

    /// <summary>
    /// Validation Check
    /// </summary>
    /// <returns></returns>
    public bool CheckMapInfoForm()
    {
        if (this.IEstTermRefID < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가기간이 올바르지 않습니다.", false);
            return false;
        }
        else if (this.IEstDeptRefID < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가부서가 올바르지 않습니다.", false);
            return false;
        }
        else if (hdfBSCChampionID.Value == "" || hdfBSCChampionID.Value == "0")
        {
            ltrScript.Text = JSHelper.GetAlertScript("BSC챔피언을 지정해주십시오", false);
            return false;
        }
        else if (txtMapVersionName.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("Map 버젼명을 입력해주십시오", false);
            return false;
        }

        return true;
    }

    #endregion

    #region 서버 이벤트 처리 함수

    /// <summary>
    /// 전략맵트리 변경시 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void trvStgMap_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (this.IType == "A")
        {
            ltrScript.Text = JSHelper.GetAlertBackScript("전략맵 정보가 저장되지 않았습니다. 먼저 전략맵정보를 저장해 주십시오");
            return;
        }
        this.SetFormType();
    }

    /// <summary>
    /// 전략추가버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnStgAdd_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelStrategy("A");
    }

    /// <summary>
    /// 전략삭제 버튼설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnStgDel_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelStrategy("D");
    }

    /// <summary>
    /// 관점별 전략리스트 수정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnUpdateStg_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelStrategy("U");
    }

    /// <summary>
    /// 전략별 KPI 추가버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnAddKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelKpi("A");
    }

    /// <summary>
    /// 전략별 KPI 삭제버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnDelKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelKpi("D");
    }

    /// <summary>
    /// 전략별 KPI 가중치, 순서 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnUpdateKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelKpi("U");
    }


    protected void ugrdTerm_InitializeRow(object sender, RowEventArgs e)
    {
        CheckBox chkApply;

        TemplatedColumn Col_Apply  = (TemplatedColumn)e.Row.Band.Columns.FromKey("APPLY_YN");
        chkApply = (CheckBox)((CellItem)Col_Apply.CellItems[e.Row.BandIndex]).FindControl("chkCheckTerm");
        chkApply.Checked = (e.Row.Cells.FromKey("APPLY_YN").Value.ToString() == "Y") ? true : false;
        chkApply.Enabled = (e.Row.Cells.FromKey("CLOSE_YN").Value.ToString() == "N") ? true : false;
    }

    protected void ugrdKPIPerStg_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Data;
        DropDownList ddlTempSelectType;
        TemplatedColumn unit_col = (TemplatedColumn)e.Row.Band.Columns.FromKey("MAP_KPI_TYPE");

        ddlTempSelectType = (DropDownList)((CellItem)unit_col.CellItems[e.Row.BandIndex]).FindControl("ddlMAP_KPI_TYPE");


        ddlTempSelectType.DataSource = ddlMAP_KPI_TYPE_H.DataSource;
        ddlTempSelectType.DataTextField = ddlMAP_KPI_TYPE_H.DataTextField;
        ddlTempSelectType.DataValueField = ddlMAP_KPI_TYPE_H.DataValueField;
        ddlTempSelectType.DataBind();

        ddlTempSelectType.Items.Insert(0, new ListItem("::선택::", ""));

        PageUtility.FindByValueDropDownList(ddlTempSelectType, drv["MAP_KPI_TYPE"].ToString());
    }

    /// <summary>
    /// 전략맵 정보 저장버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnInsertMapInfo_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "A";
        this.AddDelMapInfo();
    }

    /// <summary>
    /// 전략맵 초기화 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnInitMapInfo_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "A";
        this.SetInitForm();
        this.SetButton();

        trvStgMap.Nodes.Clear();
        this.DrawMapTreeInit();
    }
    

    /// <summary>
    /// 전략맵수정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnUpdateMapInfo_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelMapInfo();
    }

    /// <summary>
    /// 전략맵 삭제
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnDeleteMapInfo_Click(object sender, ImageClickEventArgs e)
    {

    }

    /// <summary>
    /// 전략맵 버젼 변경시 전략맵 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMapVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetMapInfo(true);
    }

    /// <summary>
    /// 전략검색버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnFindStg_Click(object sender, ImageClickEventArgs e)
    {
        this.SetStrategy(true);
    }

    /// <summary>
    /// KPI검색버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnFindKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.SetKpi(true);
    }

    /// <summary>
    /// 상위전략 추가버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnAddUpStg_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelParentStrategy("A");
    }

    /// <summary>
    /// 상위전략 삭제버튼 설정
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnDelUpStg_Click(object sender, ImageClickEventArgs e)
    {
        this.AddDelParentStrategy("D");
    }

    protected void ugwtKpiTab_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
    {
        if (e.Tab.Key == "2")
        {
            this.SetParentStg();
        }
    }

    #endregion
}
