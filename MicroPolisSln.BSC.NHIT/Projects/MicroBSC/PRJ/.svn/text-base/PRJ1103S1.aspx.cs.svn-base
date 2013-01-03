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


public partial class PRJ_PRJ1103S1 : AppPageBase
{

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

    public string IEstTermName
    {
        get
        {
            if (ViewState["ESTTERM_NAME"] == null)
            {
                ViewState["ESTTERM_NAME"] = GetRequest("ESTTERM_NAME", "");
            }

            return (string)ViewState["ESTTERM_NAME"];
        }
        set
        {
            ViewState["ESTTERM_NAME"] = value;
        }
    }

    //평가부서
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

    public string IEstDeptName
    {
        get
        {
            if (ViewState["EST_DEPT_NAME"] == null)
            {
                ViewState["EST_DEPT_NAME"] = GetRequest("EST_DEPT_NAME", "");
            }

            return (string)ViewState["EST_DEPT_NAME"];
        }
        set
        {
            ViewState["EST_DEPT_NAME"] = value;
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

    public string IMapVersionName
    {
        get
        {
            if (ViewState["MAP_VERSION_NAME"] == null)
            {
                ViewState["MAP_VERSION_NAME"] = GetRequest("MAP_VERSION_NAME", "");
            }

            return (string)ViewState["MAP_VERSION_NAME"];
        }
        set
        {
            ViewState["MAP_VERSION_NAME"] = value;
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
                ViewState["TREE_SEL_VALUE"] = GetRequest("TREE_SEL_VALUE", "0");
            }

            return (string)ViewState["TREE_SEL_VALUE"];
        }
        set
        {
            ViewState["TREE_SEL_VALUE"] = value;
        }
    }

    public int IStgRefID
    {
        get
        {
            if (ViewState["STG_REF_ID"] == null)
            {
                ViewState["STG_REF_ID"] = GetRequestByInt("STG_REF_ID", 0);
            }

            return (int)ViewState["STG_REF_ID"];
        }
        set
        {
            ViewState["STG_REF_ID"] = value;
        }
    }

    public string IStgName
    {
        get
        {
            if (ViewState["STG_NAME"] == null)
            {
                ViewState["STG_NAME"] = GetRequest("STG_NAME", "");
            }

            return (string)ViewState["STG_NAME"];

        }
        set
        {
            ViewState["STG_NAME"] = value;
        }
    }


    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public string IKpiName
    {
        get
        {
            if (ViewState["KPI_NAME"] == null)
            {
                ViewState["KPI_NAME"] = GetRequest("KPI_NAME", "");
            }

            return (string)ViewState["KPI_NAME"];

        }
        set
        {
            ViewState["KPI_NAME"] = value;
        }
    }

    public int IWorkRefID
    {
        get
        {
            if (ViewState["WORK_REF_ID"] == null)
            {
                ViewState["WORK_REF_ID"] = GetRequestByInt("WORK_REF_ID", 0);
            }

            return (int)ViewState["WORK_REF_ID"];
        }
        set
        {
            ViewState["WORK_REF_ID"] = value;
        }
    }

    public string IWorkName
    {
        get
        {
            if (ViewState["WORK_NAME"] == null)
            {
                ViewState["WORK_NAME"] = GetRequest("WORK_NAME", "");
            }

            return (string)ViewState["WORK_NAME"];
        }
        set
        {
            ViewState["WORK_NAME"] = value;
        }
    }


    public int IExecRefID
    {
        get
        {
            if (ViewState["EXEC_REF_ID"] == null)
            {
                ViewState["EXEC_REF_ID"] = GetRequestByInt("EXEC_REF_ID", 0);
            }

            return (int)ViewState["EXEC_REF_ID"];
        }
        set
        {
            ViewState["EXEC_REF_ID"] = value;
        }
    }

    public string IExecName
    {
        get
        {
            if (ViewState["EXEC_NAME"] == null)
            {
                ViewState["EXEC_NAME"] = GetRequest("EXEC_NAME", "");
            }

            return (string)ViewState["EXEC_NAME"];
        }
        set
        {
            ViewState["EXEC_NAME"] = value;
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

    private string[] mArgs = new string[3];
    private enum EN_ARGS_INFO : int
    {
        GUBUN = 0,
        STG = 1,
        KPI = 2
    }

    private int GetArgsInfo(EN_ARGS_INFO eInfo)
    {
        return (int)eInfo;
    }

    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
        ltrScript.Text = "";
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
            //평기기간(년)리스트
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        }

        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        MicroBSC.Estimation.Dac.TermInfos objTERM = new MicroBSC.Estimation.Dac.TermInfos(this.IEstTermRefID);
        this.IEstTermName = Convert.ToString(objTERM.Estterm_name);

        //평가조직 트리 구성
        WebCommon.FillEstTree(trvEstDept, this.IEstTermRefID, gUserInfo.Emp_Ref_ID);
        //WebCommon.FillEstTree(trvEstDept, this.IEstTermRefID);
        trvEstDept.ExpandAll();

        if (trvEstDept.Nodes.Count > 0)
        {
            trvEstDept.Nodes[0].Select();
            this.IEstDeptRefID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
            this.txtEstDeptName.Text = (trvEstDept.SelectedNode == null) ? "" : trvEstDept.SelectedNode.Text;
            this.IEstDeptName = (trvEstDept.SelectedNode == null) ? "" : trvEstDept.SelectedNode.Text;

            this.SetFormData();
        }
        else
        {
            this.IEstDeptRefID = 0;
            this.IMapVersionID = 0;
            this.IStgRefID = 0;
            this.IKpiRefID = 0;
            this.IWorkRefID = 0;
            this.IExecRefID = 0;
            this.IEstDeptName = "";
            this.IMapVersionName = "";
            this.IStgName = "";
            this.IKpiName = "";
            this.IWorkName = "";
            this.IExecName = "";
            this.ugrdMapSKIE.Clear();
            this.trvStgMap.Nodes.Clear();
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

    //&&여기까지
    #region 내부함수
    private void SetFormData()
    {
        this.IStgRefID = 0;
        this.IKpiRefID = 0;
        this.IWorkRefID = 0;
        this.IExecRefID = 0;
        this.IStgName = "";
        this.IKpiName = "";
        this.IWorkName = "";
        this.IExecName = "";

        this.SetMapVersion();
        this.SetMapInfo(true);
    }

    /// <summary>
    /// 전략맵 최신버젼 확인
    /// /// </summary>
    private void SetMapVersion()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Sk_Ie objVer = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Sk_Ie();
        DataSet dsVer = objVer.GetMapVersion(this.IEstTermRefID, this.IEstDeptRefID);

        if (dsVer.Tables[0].Rows.Count > 0)
        {
            IMapVersionID = Convert.ToInt32(dsVer.Tables[0].Rows[0]["MAP_VERSION_ID"].ToString());
            IMapVersionName = dsVer.Tables[0].Rows[0]["MAP_NAME"].ToString();
            txtMapVerName.Text = IMapVersionName;
        }
        else
        {
            this.IMapVersionID = 0;
            this.IMapVersionName = "";
            ltrScript.Text = JSHelper.GetAlertScript("등록된 맵버젼이 없습니다.", false);
        }

    }

    /// <summary>
    /// 맵기본정보설정
    /// </summary>
    /// <param name="IsMapTermRefresh">맵기본정보를 재설정할것인지 여부</param>
    private void SetMapInfo(bool IsMapTermRefresh)
    {
        if (IMapVersionID > 0)
        {

            this.DrawMapTree();

            if (IsMapTermRefresh)
            {

            }

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

        DrawMapTreeDetail(trvStgMap, IEstTermRefID, IEstDeptRefID, IMapVersionID, strSelVal);

    }

    private void DrawMapTreeDetail(TreeView iTrvMap, int iEstTermRefID, int iEstDeptRefID, int iMapVersionID, string iSelectedKey)
    {
        int cntRow = 0;
        int cntStg = 0;
        int cntKpi = 0;
        string strKey = "";
        string strVal = "";

        strKey = "D" + ";" + Convert.ToString(this.IEstDeptRefID) + ";0";
        strVal = this.IEstDeptName + " 전략맵";
        TreeNode topNode = new TreeNode(strVal, strKey);

        iTrvMap.Nodes.Clear();
        iTrvMap.Nodes.Add(topNode);
        topNode.ImageUrl = "../images/stg/TREE_D.gif";

        TreeNode vNode;
        MicroBSC.BSC.Biz.Biz_Bsc_View_Info objView = new MicroBSC.BSC.Biz.Biz_Bsc_View_Info();
        DataSet dsView = objView.GetAllList();

        TreeNode sNode;
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Stg objSTG = new Biz_Bsc_Map_Stg();
        DataSet dsSTG = new DataSet();

        TreeNode kNode;
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi objKPI = new Biz_Bsc_Map_Kpi();
        DataSet dsKPI = new DataSet();

        cntRow = dsView.Tables[0].Rows.Count;
        for (int i = 0; i < cntRow; i++)
        {
            string imgWork = "<img alt='' src='../images/stg/TREE_W.gif'/>";
            string imgExec = "<img alt='' src='../images/stg/TREE_E.gif'/>";

            strKey = "V" + ";" + dsView.Tables[0].Rows[i]["VIEW_REF_ID"].ToString() + ";0";
            strVal = dsView.Tables[0].Rows[i]["VIEW_NAME"].ToString();
            vNode = new TreeNode(strVal, strKey);
            vNode.ImageUrl = "../images/stg/TREE_V.gif";
            topNode.ChildNodes.Add(vNode);

            if (iSelectedKey == strKey)
            {
                vNode.Select();
                vNode.ExpandAll();
                vNode.SelectAction = TreeNodeSelectAction.Select;
            }

            int stgrefid = 0;
            int kpirefid = 0;

            dsSTG = objSTG.GetStrategyPerView(IEstTermRefID, IEstDeptRefID, IMapVersionID, int.Parse(dsView.Tables[0].Rows[i]["VIEW_REF_ID"].ToString()));
            cntStg = dsSTG.Tables[0].Rows.Count;

            for (int j = 0; j < cntStg; j++)
            {
                strKey = "S" + ";" + dsSTG.Tables[0].Rows[j]["STG_REF_ID"].ToString() + ";0";

                stgrefid = Convert.ToInt32(dsSTG.Tables[0].Rows[j]["STG_REF_ID"].ToString());
                kpirefid = 0;

                strVal = dsSTG.Tables[0].Rows[j]["STG_NAME"].ToString() 
                    + ( WorkCount(IEstTermRefID, IEstDeptRefID ,stgrefid, kpirefid) ? imgWork : "" ) 
                    + ( ExecCount(IEstTermRefID, IEstDeptRefID ,stgrefid, kpirefid) ? imgExec : "" ) ;
                sNode = new TreeNode(strVal, strKey);

                sNode.ImageUrl = "../images/stg/TREE_S.gif";
                vNode.ChildNodes.Add(sNode);

                if (iSelectedKey == strKey)
                {
                    sNode.Select();
                    sNode.ExpandAll();
                    sNode.SelectAction = TreeNodeSelectAction.Select;
                }

                dsKPI = objKPI.GetKpiListPerStg(IEstTermRefID, IEstDeptRefID, IMapVersionID, int.Parse(dsSTG.Tables[0].Rows[j]["STG_REF_ID"].ToString()));
                cntKpi = dsKPI.Tables[0].Rows.Count;

                for (int k = 0; k < cntKpi; k++)
                {
                    strKey = "K" + ";" + dsKPI.Tables[0].Rows[k]["KPI_REF_ID"].ToString() + ";" + dsSTG.Tables[0].Rows[j]["STG_REF_ID"].ToString();

                    kpirefid = Convert.ToInt32( dsKPI.Tables[0].Rows[k]["KPI_REF_ID"].ToString());

                    strVal = dsKPI.Tables[0].Rows[k]["KPI_NAME"].ToString()
                           + (WorkCount(IEstTermRefID, IEstDeptRefID, stgrefid, kpirefid) ? imgWork : "")
                           + (ExecCount(IEstTermRefID, IEstDeptRefID, stgrefid, kpirefid) ? imgExec : "");
                    
                    kNode = new TreeNode(strVal, strKey);
                    kNode.ImageUrl = "../images/stg/TREE_K.gif";
                    sNode.ChildNodes.Add(kNode);

                    if (iSelectedKey == strKey)
                    {
                        kNode.Select();
                        kNode.ExpandAll();
                        kNode.SelectAction = TreeNodeSelectAction.Select;
                    }
                }
            }
        }

        if (iTrvMap.SelectedNode == null)
        {
            topNode.Select();
        }

        iTrvMap.ExpandAll();

    }

    private bool WorkCount(int iEsttermRefId, int iEstDeptRefId, int iStgRefId, int iKpiRefId)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Sk_Ie objCnt = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Sk_Ie();
        DataSet dsCnt = objCnt.GetMapWorkCnt(iEsttermRefId, iEstDeptRefId, iStgRefId, iKpiRefId);

        if (Convert.ToInt32(dsCnt.Tables[0].Rows[0]["WORK_CNT"].ToString()) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ExecCount(int iEsttermRefId, int iEstDeptRefId, int iStgRefId, int iKpiRefId)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Sk_Ie objCnt = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Sk_Ie();
        DataSet dsCnt = objCnt.GetMapExecCnt(iEsttermRefId, iEstDeptRefId, iStgRefId, iKpiRefId);

        if (Convert.ToInt32(dsCnt.Tables[0].Rows[0]["EXEC_CNT"].ToString()) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 전략맵 트리 초기화
    /// </summary>
    /// 

    private void DrawMapTreeInit()
    {
        string strSelVal = "";


        DrawMapTreeDetail(trvStgMap, this.IEstTermRefID, this.IEstDeptRefID, -1, strSelVal);
    }



    //중점과제(WorkInfo)조회
    private void SetMapSKIEList(string NodeValue)
    {
        mArgs = NodeValue.ToString().Split(';');

        if (mArgs.Length < 3)
        {
            return;
        }

        if (mArgs.Length >= 1)
        {
            if (mArgs[GetArgsInfo(EN_ARGS_INFO.GUBUN)] == "S")
            {
                this.IStgRefID = Convert.ToInt32(mArgs[GetArgsInfo(EN_ARGS_INFO.STG)]);
                Biz_Bsc_Map_Sk_Ie objBSC = new Biz_Bsc_Map_Sk_Ie();
                DataSet rDs = objBSC.GetStgList(this.IEstTermRefID, this.IEstDeptRefID, this.IStgRefID);


                ugrdMapSKIE.Clear();
                ugrdMapSKIE.DataSource = rDs;
                ugrdMapSKIE.DataBind();

            }
            else if (mArgs[GetArgsInfo(EN_ARGS_INFO.GUBUN)] == "K")
            {
                this.IStgRefID = Convert.ToInt32(mArgs[GetArgsInfo(EN_ARGS_INFO.STG)]);
                this.IKpiRefID = Convert.ToInt32(mArgs[GetArgsInfo(EN_ARGS_INFO.KPI)]);
                Biz_Bsc_Map_Sk_Ie objBSC = new Biz_Bsc_Map_Sk_Ie();
                DataSet rDs = objBSC.GetStgKpiList(this.IEstTermRefID, this.IEstDeptRefID, this.IStgRefID, this.IKpiRefID);

                ugrdMapSKIE.Clear();
                ugrdMapSKIE.DataSource = rDs;
                ugrdMapSKIE.DataBind();

            }
        }

    }
    #endregion

    #region 서버 이벤트 처리 함수

    //부서 트리 클릭
    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.IEstDeptRefID = (trvEstDept.SelectedNode == null) ? 0 : int.Parse(trvEstDept.SelectedNode.Value);
        this.txtEstDeptName.Text = (trvEstDept.SelectedNode == null) ? "" : trvEstDept.SelectedNode.Text;
        this.IEstDeptName = (trvEstDept.SelectedNode == null) ? "" : trvEstDept.SelectedNode.Text;
        this.SetFormData();
    }

    protected void trvStgMap_SelectedNodeChanged(object sender, EventArgs e)
    {
        string strSelVal = (trvStgMap.SelectedNode == null) ? ";; " : trvStgMap.SelectedNode.Value;

        SetMapSKIEList(strSelVal);
    }



    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetPageData();
    }

    protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.SetFormData();
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetFormData();
    }


    protected void ugrdMapSKIE_InitializeRow(object sender, RowEventArgs e)
    {

        if ( Convert.ToInt32( e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString()) > 0 )
        {
            e.Row.Cells.FromKey("KPI_NAME").Style.ForeColor = System.Drawing.Color.Red;
        }
        if (Convert.ToInt32(e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString()) == 0)
        {
            e.Row.Cells.FromKey("STG_NAME").Style.ForeColor = System.Drawing.Color.Red;
        }
        if (Convert.ToInt32(e.Row.Cells.FromKey("EXEC_REF_ID").Value.ToString()) > 0)
        {
            e.Row.Cells.FromKey("EXEC_NAME").Style.ForeColor = System.Drawing.Color.Red;
        }
        if (Convert.ToInt32(e.Row.Cells.FromKey("EXEC_REF_ID").Value.ToString()) == 0)
        {
            e.Row.Cells.FromKey("WORK_NAME").Style.ForeColor = System.Drawing.Color.Red;
        }


    }
    #endregion

}
