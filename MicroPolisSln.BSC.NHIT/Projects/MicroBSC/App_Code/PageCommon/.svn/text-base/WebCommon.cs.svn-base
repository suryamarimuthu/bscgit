using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.Biz.BSC.Biz;

using MicroBSC.BSC.Biz;
using MicroBSC.PRJ.Biz;
using MicroBSC.Estimation.Biz;

/// <summary>
/// Summary description for WebCommon
/// </summary>
public class WebCommon
{
    public static void FindByValueDropDownList(DropDownList ddlReceive, object sValue)
    {
        ddlReceive.ClearSelection();
        ListItem item = ddlReceive.Items.FindByValue(sValue.ToString());
        if (item != null)
            item.Selected = true;
    }

    public static void SetMonthDropDownList(DropDownList ddList)
    {
        for (int i = 12; i >= 1; i--)
        {
            ddList.Items.Insert(0, new ListItem(String.Format("{0}월", i), i.ToString()));
        }
    }

    public static void SetTermMonthDropDownList(DropDownList ddList, int pEstTermRefID)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail objTerm = new MicroBSC.BSC.Biz.Biz_Bsc_Term_Detail();
        DataSet dsRtn           = objTerm.GetAllList(pEstTermRefID);

        ddList.DataSource       = dsRtn;
        ddList.DataTextField    = "YM";
        ddList.DataValueField   = "YMD";
        ddList.DataBind();

        ListItem item = ddList.Items.FindByValue(objTerm.GetReleasedMonth());
        if (item != null)
        {
            item.Selected = true;
        }
    }
    public static void SetKpiTermTypeDropDownList(DropDownList ddList)
    {
        ddList.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
        ddList.Items.Insert(1, new ListItem("월별", "1"));
        ddList.Items.Insert(2, new ListItem("분기별", "2"));
        ddList.Items.Insert(3, new ListItem("반기별", "3"));
        ddList.Items.Insert(4, new ListItem("년단위", "4"));
    
    }
    public static void SetRoleDropDownList(DropDownList ddList, int menu_ref_id)
    {
        RoleInfos role          = new RoleInfos();
        DataSet ds              = role.GetNotMenuRoles(menu_ref_id);
        ddList.DataSource       = ds;
        ddList.DataTextField    = "ROLE_NAME";
        ddList.DataValueField   = "ROLE_REF_ID";
        ddList.DataBind();
    }
    
    public static void SetEstDeptByStgMapDropDownList(DropDownList ddList, int esterm_ref_id) 
    {
        MicroBSC.Estimation.Dac.DeptInfos estDeptInfo = new MicroBSC.Estimation.Dac.DeptInfos();
        DataSet ds              = estDeptInfo.GetEstDeptByStgMap(esterm_ref_id);
        ddList.DataTextField    = "DEPT_NAME";
        ddList.DataValueField   = "EST_DEPT_REF_ID";
        ddList.DataSource       = ds;
        ddList.DataBind();
    }

    public static void SetEstTermDropDownList(DropDownList ddList)
    {
        TermInfos term          = new TermInfos();
        DataSet ds              = term.GetAllList();

        ds = DataTypeUtility.FilterSortDataSet(ds, "", "ESTTERM_NAME DESC");

        ddList.DataSource       = ds;
        ddList.DataTextField    = "ESTTERM_NAME";
        ddList.DataValueField   = "ESTTERM_REF_ID";
        ddList.DataBind();

        // 배포되어있는 평가월의 평가기간을 가져온다
        Biz_Bsc_Term_Detail objTD = new Biz_Bsc_Term_Detail();
        ddList.ClearSelection();

        if(ddList.Items.FindByValue(objTD.GetOpenEstTermID().ToString()) != null)
            ddList.Items.FindByValue(objTD.GetOpenEstTermID().ToString()).Selected = true;
    }

    public static void SetBizInfoDropDownList(DropDownList ddList)
    {
        BizInfos position       = new BizInfos();
        DataSet ds              = position.GetAllBizInfo();
        ddList.DataSource       = ds;
        ddList.DataTextField    = "BIZ_TYPE_NAME";
        ddList.DataValueField   = "BIZ_TYPE_CODE";
        ddList.DataBind();

        ddList.Items.Insert(0, new ListItem(":: 선택 ::", "*"));
    }

    public static void SetEstDeptGroupDropDownList(DropDownList ddList, string defaultText, string defaultValue, bool isDefalutText)
    {
        Biz_DeptGroupInfos deptGroupInfo = new Biz_DeptGroupInfos();
        DataSet ds              = deptGroupInfo.GetDeptGroupInfo(0);
        ddList.DataSource       = ds;
        ddList.DataTextField    = "EST_DEPT_GROUP_NAME";
        ddList.DataValueField   = "EST_DEPT_GROUP_ID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(defaultText , defaultValue));
    }

    public static void SetBizInfoDropDownList(DropDownList ddList, bool isDefalutText)
    {
        BizInfos position       = new BizInfos();
        DataSet ds              = position.GetAllBizInfo();
        ddList.DataSource       = ds;
        ddList.DataTextField    = "BIZ_TYPE_NAME";
        ddList.DataValueField   = "BIZ_TYPE_CODE";
        ddList.DataBind();

        if(isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", "*"));
    }

    public static void SetEstDeptDropDownList(DropDownList ddList, int estterm_ref_id, bool isDefalutText)
    {
        SetEstDeptDropDownList(ddList, estterm_ref_id, isDefalutText, 0);
    }

    public static void SetEstDeptDropDownList(DropDownList ddList, int estterm_ref_id, bool isDefalutText, int emp_ref_id)
    {
        MicroBSC.Estimation.Dac.DeptInfos dept = new MicroBSC.Estimation.Dac.DeptInfos();
        DataSet ds              = dept.getEstDeptList(estterm_ref_id, emp_ref_id);
        DataView dw             = ds.Tables[0].DefaultView;
        dw.RowFilter            = "TREE_NODE_TYPE = 1";

        ddList.DataSource       = dw;
        ddList.DataTextField    = "DEPT_NAME";
        ddList.DataValueField   = "EST_DEPT_REF_ID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", "0"));
    }

    public static void SetComDeptDropDownList(DropDownList ddList, bool isDefalutText, int emp_ref_id)
    {
        MicroBSC.Estimation.Dac.DeptInfos dept = new MicroBSC.Estimation.Dac.DeptInfos();
        DataSet ds = dept.getComDeptListByPermit(emp_ref_id);
        DataView dw = ds.Tables[0].DefaultView;
        dw.RowFilter = "TREE_NODE_TYPE = 1";

        ddList.DataSource = dw;
        ddList.DataTextField = "DEPT_NAME";
        ddList.DataValueField = "DEPT_REF_ID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", "0"));
    }

    public static void SetComDeptDropDownList(DropDownList ddList, bool isDefalutText)
    { 
        Biz_ComDeptInfo dept    = new Biz_ComDeptInfo();
        DataSet dsTree          = dept.GetComDeptByTree();

        ddList.DataSource       = dsTree;
        ddList.DataTextField    = "NAME";
        ddList.DataValueField   = "SFID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", "0"));
    }

    public static void SetKpiPoolDropDownList(DropDownList ddList, bool isDefalutText)
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool kpiPool = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        DataSet ds              = kpiPool.GetAllList("","","");

        ddList.DataSource       = ds;
        ddList.DataTextField    = "KPI_NAME";
        ddList.DataValueField   = "KPI_POOL_REF_ID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", ""));
    }

    public static void SetUnitTypeDropDownList(DropDownList ddList, bool isDefalutText)
    {
        Biz_Com_Unit_Type_Info objUnit = new Biz_Com_Unit_Type_Info();
        DataSet ds              = objUnit.GetAllList();

        ddList.DataSource       = ds;
        ddList.DataTextField    = "UNIT";
        ddList.DataValueField   = "UNIT_TYPE_REF_ID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "-1"));
    }

    public static void SetBSCTermDetaolDropDownList(DropDownList ddList, int estterm_ref_id, bool isDefalutText)
    {
        Biz_Bsc_Term_Detail bscTermDetail   = new Biz_Bsc_Term_Detail();
        DataSet ds                          = bscTermDetail.GetTermDetail(estterm_ref_id);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
        {
            ddList.Items.Add(new ListItem(ds.Tables[0].Rows[i]["YY"].ToString() + "년 " + ds.Tables[0].Rows[i]["MM"].ToString() + "월"
                                        , ds.Tables[0].Rows[i]["YMD"].ToString()));
        }

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "-1"));
    }
    
    public static void SetEstYNDropDownList(DropDownList ddList, bool isDefalutText)
    {
        ddList.Items.Add(new ListItem("평가", "Y"));
        ddList.Items.Add(new ListItem("미평가", "N"));
        if (isDefalutText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }
        ddList.SelectedIndex = 0;
    }
    public static void SetUseYnDropDownList(DropDownList ddList, bool isDefalutText)
    {
        ddList.Items.Add(new ListItem("사  용", "Y"));
        ddList.Items.Add(new ListItem("미사용", "N"));
        if (isDefalutText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }
        ddList.SelectedIndex = 0;
    }

    public static void SetSettingYnDropDownList(DropDownList ddList, bool isDefalutText)
    {
        ddList.Items.Add(new ListItem("설  정", "Y"));
        ddList.Items.Add(new ListItem("미설정", "N"));
        if (isDefalutText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }
        ddList.SelectedIndex = 0;
    }

    public static void SetMonthlyCloseRateTypeDropDownList(DropDownList ddList, bool isDefalutText)
    {
        ddList.Items.Add(new ListItem("100%", "1"));
        ddList.Items.Add(new ListItem("100% 미만", "0"));
        if (isDefalutText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }

        ddList.SelectedIndex = 0;
    }
    public static void SetExternalEstTypeDropDownList(DropDownList ddList, bool isDefalutText)
    {
        ddList.Items.Add(new ListItem("지표별", "K"));
        ddList.Items.Add(new ListItem("평가부서별", "D"));
        if (isDefalutText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }

        ddList.SelectedIndex = 0;
    }
    public static void SetSignalDropDownList(DropDownList ddList, bool isDefaultText)
    {
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Threshold_Code objBSC = new Biz_Bsc_Threshold_Code();
        IDataReader rDr        = objBSC.InfoThresholdCode(0);

        ddList.DataSource     = rDr;
        ddList.DataTextField  = "THRESHOLD_KNAME";
        ddList.DataValueField = "THRESHOLD_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }

        ddList.SelectedIndex = 0;
    }
    public static void SetSumTypeDropDownList(DropDownList ddList, bool isDefaultText)
    {
        ddList.Items.Add(new ListItem("누적", "TS"));
        ddList.Items.Add(new ListItem("당월", "MS"));
        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }
        ddList.SelectedIndex = 0;

        //else
        //{
        //    WebUtility.FindByValueDropDownList(ddList, "TS");
        //}
    }
    public static void SetScoreCardLevelDropDownList(DropDownList ddList, bool isDefaultText)
    {
        ddList.Items.Add(new ListItem("관점별", "VP"));
        ddList.Items.Add(new ListItem("전략별", "SP"));
        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }

        ddList.SelectedIndex = 0;
    }

    public static void SetSortTypeDropDownList(DropDownList ddList, bool isDefaultText)
    {
        ddList.Items.Add(new ListItem("HIGH", "H"));
        ddList.Items.Add(new ListItem("LOW", "L"));
        ddList.Items.Add(new ListItem("H&L", "HL"));

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem("---", ""));
        }

        ddList.SelectedIndex = 0;
    }

    public static void SetKpiCategoryTopDropDownList(DropDownList ddList, bool isDefaultText)
    { 
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top objBSC = new Biz_Bsc_Kpi_Category_Top();
        DataSet rDs        = objBSC.GetAllList();

        ddList.DataSource     = rDs;
        ddList.DataTextField  = "CATEGORY_TOP_NAME";
        ddList.DataValueField = "CATEGORY_TOP_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
            ddList.SelectedIndex = 0;
        }        
    }

    public static void SetKpiCategoryTopActiveDropDownList(DropDownList ddList, bool isDefaultText, string useyn)
    {
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Top objBSC = new Biz_Bsc_Kpi_Category_Top();
        DataSet rDs = objBSC.GetAllActiveList(useyn);

        ddList.DataSource = rDs;
        ddList.DataTextField = "CATEGORY_TOP_NAME";
        ddList.DataValueField = "CATEGORY_TOP_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", "0"));
            ddList.SelectedIndex = 0;
        }
    }

    public static void SetKpiCategoryMidDropDownList(DropDownList ddList, bool isDefaultText, int icategory_top_ref_id)
    { 
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid objBSC = new Biz_Bsc_Kpi_Category_Mid();
        DataSet rDs        = objBSC.GetAllList(icategory_top_ref_id);

        ddList.DataSource     = rDs;
        ddList.DataTextField  = "CATEGORY_MID_NAME";
        ddList.DataValueField = "CATEGORY_MID_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
            ddList.SelectedIndex = 0;
        }        
    }

    public static void SetKpiCategoryMidActiveDropDownList(DropDownList ddList, bool isDefaultText, int icategory_top_ref_id, string useyn)
    {
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Mid objBSC = new Biz_Bsc_Kpi_Category_Mid();
        DataSet rDs = objBSC.GetAllActiveList(icategory_top_ref_id, useyn);

        ddList.DataSource = rDs;
        ddList.DataTextField = "CATEGORY_MID_NAME";
        ddList.DataValueField = "CATEGORY_MID_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", "0"));
            ddList.SelectedIndex = 0;
        }
    }

    public static void SetKpiCategoryLowDropDownList(DropDownList ddList, bool isDefaultText, int icategory_top_ref_id, int icategory_mid_ref_id)
    { 
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objBSC = new Biz_Bsc_Kpi_Category_Low();
        DataSet rDs        = objBSC.GetAllList(icategory_top_ref_id, icategory_mid_ref_id);

        ddList.DataSource     = rDs;
        ddList.DataTextField  = "CATEGORY_LOW_NAME";
        ddList.DataValueField = "CATEGORY_LOW_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
            ddList.SelectedIndex = 0;
        }        
    }

    public static void SetKpiCategoryLowActiveDropDownList(DropDownList ddList, bool isDefaultText, int icategory_top_ref_id, int icategory_mid_ref_id, string useyn)
    {
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Category_Low objBSC = new Biz_Bsc_Kpi_Category_Low();
        DataSet rDs = objBSC.GetAllActiveList(icategory_top_ref_id, icategory_mid_ref_id, useyn);

        ddList.DataSource = rDs;
        ddList.DataTextField = "CATEGORY_LOW_NAME";
        ddList.DataValueField = "CATEGORY_LOW_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 선택 ::", "0"));
            ddList.SelectedIndex = 0;
        }
    }

    public static void SetValuationGroupDropDownList(DropDownList ddList, bool isDefaultText)
    { 
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Validation_Group objBSC = new Biz_Bsc_Validation_Group();
        DataSet rDs        = objBSC.GetAllList();

        ddList.DataSource     = rDs;
        ddList.DataTextField  = "GROUP_NAME";
        ddList.DataValueField = "GROUP_REF_ID";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
            ddList.SelectedIndex = 0;
        }        
    }

    /// <summary>
    /// 외부평가 지표 사용여부에 따른 체크박스 활성화
    /// </summary>
    /// <param name="chkExt"></param>
    /// <param name="iEsttermRefId"></param>
    public static void SetExternalScoreCheckBox(CheckBox chkExt, int iEsttermRefId)
    {
        MicroBSC.Estimation.Dac.TermInfos objTerm = new MicroBSC.Estimation.Dac.TermInfos(iEsttermRefId);
        chkExt.Visible = (objTerm.External_score_use_yn == "Y") ? true : false;
    }

    /// <summary>
    /// 비계량지표 평가차수
    /// </summary>
    /// <param name="ddList"></param>
    /// <param name="isDefaultText"></param>
    public static void SetKpiQltEstLevelDropDownList(DropDownList ddList, int iestterm_ref_id, bool isDefaultText)
    { 
        ddList.Items.Clear();
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Qlt_Info objBSC = new Biz_Bsc_Kpi_Qlt_Info();
        DataSet rDs        = objBSC.GetAllList(iestterm_ref_id);

        ddList.DataSource     = rDs;
        ddList.DataTextField  = "EST_LEVEL_NAME";
        ddList.DataValueField = "EST_LEVEL";
        ddList.DataBind();

        if (isDefaultText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
            ddList.SelectedIndex = 0;
        }        
    }

    public static void SetDeptTypeDropDownList(DropDownList ddList, bool isDefalutText)
    {
        Biz_DeptTypeInfo objType    = new Biz_DeptTypeInfo();
        DataSet ds                  = objType.GetAllList();
        ddList.DataSource           = ds;

        ddList.DataTextField        = "TYPE_NAME";
        ddList.DataValueField       = "TYPE_REF_ID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "-1"));
    }


    public static void SetProjectListDropDownList(DropDownList ddList, bool isDefalutText, int TrxUser, string PrjType, int iPrjYear)
    {
        Biz_Prj_Info objInfo  = new Biz_Prj_Info();
        ddList.DataSource     = objInfo.GetList("", "", 0, "", TrxUser, PrjType, iPrjYear);
        ddList.DataTextField  = "PRJ_NAME";
        ddList.DataValueField = "PRJ_REF_ID";
        ddList.DataBind();

        if (isDefalutText)
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
    }

    public static void FillEstTree(TreeView iTreeView, int iEstTermId, TreeNodeSelectAction treeNodeSelectAction) 
    {
        FillEstTree(iTreeView, iEstTermId, treeNodeSelectAction, 0, 0);
    }

    public static void FillEstTree(TreeView iTreeView, int iEstTermId, int emp_ref_id)
    {
        FillEstTree(iTreeView, iEstTermId, TreeNodeSelectAction.Select, emp_ref_id, 0);
    }

    public static void FillEstTree(TreeView iTreeView, int iEstTermId)
    {
        FillEstTree(iTreeView, iEstTermId, TreeNodeSelectAction.Select, 0, 0);
    }

    public static void FillEstTree(TreeView iTreeView, int iEstTermId, int emp_ref_id, int iest_dept_ref_id)
    {
        FillEstTree(iTreeView, iEstTermId, TreeNodeSelectAction.Select, emp_ref_id, iest_dept_ref_id);
    }

    /// <summary>
    /// 기본조직 트리구성
    /// </summary>
    /// <param name="iTreeView"></param>
    public static void FillComDeptTree(TreeView iTreeView)
    {
        iTreeView.ShowLines = false;

        Biz_ComDeptInfo dept    = new Biz_ComDeptInfo();
        DataSet dsTree          = dept.GetComDeptByTree();

        string strSfId          = "";      // 부서 ID
        string strPtId          = "";      // 부모 부서 ID
        string strDept          = "";      // 부서명
        string strLevel         = "";     // 부서레벨
        int intIdx              = 0;
        int intRow              = dsTree.Tables[0].Rows.Count;

        TreeNode[] arrNodeList  = new TreeNode[intRow];
        string[] arrSelfNdID    = new string[intRow];
        bool blnSW = false;

        iTreeView.Nodes.Clear();
        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId             = dr["SFID"].ToString();
            strPtId             = dr["PTID"].ToString();
            strDept             = dr["NAME"].ToString();
            strLevel            = dr["LVL"].ToString();

            TreeNode trnDept;
            trnDept = new TreeNode(strDept, strSfId);

            arrNodeList[intIdx] = trnDept;
            arrSelfNdID[intIdx] = strSfId;

            int k = 0;
            for (k = 0; k < arrSelfNdID.Length; k++)
            {
                if (strPtId == arrSelfNdID[k])
                {
                    arrNodeList[k].ChildNodes.Add(trnDept);
                    blnSW       = true;
                    break;
                }
            }

            if (!blnSW)
            {
                iTreeView.Nodes.Add(trnDept);
                blnSW           = false;
            }

            trnDept.ImageUrl = "~/images/icon/0" + strLevel + "_2.gif";
            intIdx += 1;
        }
    }

    public static void FillEstTree(TreeView iTreeView, int iEstTermId, TreeNodeSelectAction treeNodeSelectAction, int emp_ref_id, int iest_dept_ref_id)
    {
        iTreeView.ShowLines = false;

        MicroBSC.Estimation.Dac.DeptInfos dept = new MicroBSC.Estimation.Dac.DeptInfos();
        DataSet dsTree              = dept.getEstDeptTree(iEstTermId, 1000);

        string strSfId              = "";      // 부서 ID
        string strPtId              = "";      // 부모 부서 ID
        string strDept              = "";      // 부서명
        string strLevel             = "";     // 부서레벨
        int intIdx                  = 0;
        int intRow                  = dsTree.Tables[0].Rows.Count;

        TreeNode[] arrNodeList      = new TreeNode[intRow];
        string[] arrSelfNdID        = new string[intRow];
        bool blnSW = false;

        iTreeView.Nodes.Clear();
        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId                 = dr["SFID"].ToString();
            strPtId                 = dr["PTID"].ToString();
            strDept                 = dr["NAME"].ToString();
            strLevel                = dr["LVL"].ToString();

            TreeNode trnDept = null;
            trnDept                 = new TreeNode();
            trnDept.Value           = strSfId;
            arrNodeList[intIdx]     = trnDept;
            arrSelfNdID[intIdx]     = strSfId;

            /* 2011-06-10 수정 시작 : 현재 노드의 SortOrder를 저장 */
            trnDept.ToolTip = dr["SORT_ORDER"].ToString();
            /* 2011-06-10 수정 완료 *********************************/

            if (iest_dept_ref_id > 0 && strSfId == iest_dept_ref_id.ToString())
            {
                trnDept.Select();
                trnDept.SelectAction = TreeNodeSelectAction.Select;
            }

            if (dr["TREE_NODE_TYPE"].ToString() == "0")
            {
                trnDept.SelectAction = TreeNodeSelectAction.None;
                trnDept.Text         = "<font color='#18609C'>" + strDept + "</font>";
            }
            else
            {
                trnDept.SelectAction = treeNodeSelectAction;
                trnDept.Text         = strDept;
            }

            //부모부서 검색하여 추가
            int k = 0;
            for (k = 0; k < arrSelfNdID.Length; k++)
            {
                if (strPtId == arrSelfNdID[k])
                {
                    arrNodeList[k].ChildNodes.Add(trnDept);
                    blnSW = true;
                    break;
                }
            }

            if (!blnSW)
            {
                iTreeView.Nodes.Add(trnDept);
                blnSW = false;
            }

            trnDept.ImageUrl = "~/images/icon/0" + strLevel + "_2.gif";
            intIdx += 1;
        }
    }


    public static void FillEstMappingTree(TreeView iTreeView, int iEstTermId, TreeNodeSelectAction treeNodeSelectAction)
    {
        iTreeView.ShowLines = false;
        Biz_ComDeptInfo dept    = new Biz_ComDeptInfo();
        DataSet dsTree          = dept.GetDeptMappingByTree(iEstTermId);

        string strSfId          = "";      // 부서 ID
        string strPtId          = "";      // 부모 부서 ID
        string strDept          = "";      // 부서명
        string strLevel         = "";     // 부서레벨
        int intIdx              = 0;
        int intRow              = dsTree.Tables[0].Rows.Count;

        TreeNode[] arrNodeList  = new TreeNode[intRow];
        string[] arrSelfNdID    = new string[intRow];
        bool blnSW              = false;

        iTreeView.Nodes.Clear();
        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId             = dr["SFID"].ToString();
            strPtId             = dr["PTID"].ToString();
            strDept             = dr["NAME"].ToString();
            strLevel            = dr["LVL"].ToString();

            TreeNode trnDept;
            trnDept             = new TreeNode(strDept, strSfId);
            arrNodeList[intIdx] = trnDept;
            arrSelfNdID[intIdx] = strSfId;
            trnDept.SelectAction = treeNodeSelectAction;

            int k = 0;
            for (k = 0; k < arrSelfNdID.Length; k++)
            {
                if (strPtId == arrSelfNdID[k])
                {
                    arrNodeList[k].ChildNodes.Add(trnDept);
                    blnSW = true;
                    break;
                }
            }

            if (!blnSW)
            {
                iTreeView.Nodes.Add(trnDept);
                blnSW = false;
            }

            trnDept.ImageUrl = "~/images/icon/0" + strLevel + "_2.gif";
            intIdx += 1;
        }
    }


    public static void FillEstMappingTree_NW(TreeView iTreeView, int iEstTermId, int iest_dept_ref_id, TreeNodeSelectAction treeNodeSelectAction)
    {
        iTreeView.ShowLines = false;
        Biz_ComDeptInfo dept = new Biz_ComDeptInfo();
        DataSet dsTree = dept.GetDeptMappingByTree(iEstTermId);

        string strSfId = "";      // 부서 ID
        string strPtId = "";      // 부모 부서 ID
        string strDept = "";      // 부서명
        string strLevel = "";     // 부서레벨
        int intIdx = 0;
        int intRow = dsTree.Tables[0].Rows.Count;

        TreeNode[] arrNodeList = new TreeNode[intRow];
        string[] arrSelfNdID = new string[intRow];
        bool blnSW = false;

        iTreeView.Nodes.Clear();
        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId = dr["SFID"].ToString();
            strPtId = dr["PTID"].ToString();
            strDept = dr["NAME"].ToString();
            strLevel = dr["LVL"].ToString();

            if (strDept.IndexOf("<") > 0)
            {
                strDept = strDept.Substring(0, strDept.IndexOf("<"));
            }


            TreeNode trnDept;
            trnDept = new TreeNode(strDept, strSfId);
            arrNodeList[intIdx] = trnDept;
            arrSelfNdID[intIdx] = strSfId;
            trnDept.SelectAction = treeNodeSelectAction;


            if (iest_dept_ref_id > 0 && strSfId == iest_dept_ref_id.ToString())
            {
                trnDept.Select();
                trnDept.SelectAction = TreeNodeSelectAction.Select;
            }


            int k = 0;
            for (k = 0; k < arrSelfNdID.Length; k++)
            {
                if (strPtId == arrSelfNdID[k])
                {
                    arrNodeList[k].ChildNodes.Add(trnDept);
                    blnSW = true;
                    break;
                }
            }

            if (!blnSW)
            {
                iTreeView.Nodes.Add(trnDept);
                blnSW = false;
            }

            trnDept.ImageUrl = "~/images/icon/0" + strLevel + "_2.gif";
            intIdx += 1;
        }
    }



    public static void FillEstOrgStatusTree(TreeView iTreeView, int iEstTermId, TreeNodeSelectAction treeNodeSelectAction)
    {
        iTreeView.ShowLines = false;
        Biz_ComDeptInfo dept        = new Biz_ComDeptInfo();
        DataSet dsTree              = dept.GetDeptOrgStatusByTree(iEstTermId);

        iTreeView.ShowCheckBoxes    = TreeNodeTypes.All;

        string strSfId              = "";       // 부서 ID
        string strPtId              = "";       // 부모 부서 ID
        string strDept              = "";       // 부서명
        string strLevel             = "";       // 부서레벨
        string strViewYn            = "";       // 조직View여부
        int intIdx                  = 0;
        int intRow                  = dsTree.Tables[0].Rows.Count;

        TreeNode[] arrNodeList      = new TreeNode[intRow];
        string[] arrSelfNdID        = new string[intRow];
        bool blnSW                  = false;

        iTreeView.Nodes.Clear();
        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId                 = dr["SFID"].ToString();
            strPtId                 = dr["PTID"].ToString();
            strDept                 = dr["NAME"].ToString();
            strLevel                = dr["LVL"].ToString();
            strViewYn               = dr["VIEW_YN"].ToString();

            TreeNode trnDept;
            trnDept                 = new TreeNode(strDept, strSfId);
            arrNodeList[intIdx]     = trnDept;
            arrSelfNdID[intIdx]     = strSfId;
            trnDept.SelectAction    = treeNodeSelectAction;

            int k = 0;
            for (k = 0; k < arrSelfNdID.Length; k++)
            {
                if (strPtId == arrSelfNdID[k])
                {
                    arrNodeList[k].ChildNodes.Add(trnDept);
                    trnDept.Checked = (strViewYn=="Y") ? true : false;
                    blnSW           = true;
                    break;
                }
            }

            if (!blnSW)
            {
                iTreeView.Nodes.Add(trnDept);
                trnDept.Checked     = (strViewYn == "Y") ? true : false;
                blnSW               = false;
            }

            trnDept.ImageUrl        = "~/images/icon/0" + strLevel + "_2.gif";
            intIdx                  += 1;
        }
    }

    public static void FillEstOrgStatusTree(SJ.Web.UI.TreeView iTreeView, int iEstTermId)
    {
        iTreeView.ShowLines = false;
        Biz_ComDeptInfo dept        = new Biz_ComDeptInfo();
        DataSet dsTree              = dept.GetDeptOrgStatusByTree(iEstTermId);

        iTreeView.ImagesBaseUrl     = "~/images/icon/";
        string strSfId              = "";       // 부서 ID
        string strPtId              = "";       // 부모 부서 ID
        string strDept              = "";       // 부서명
        string strLevel             = "";       // 부서레벨
        string strViewYn            = "";       // 조직View여부
        int intIdx                  = 0;
        int intRow                  = dsTree.Tables[0].Rows.Count;

        SJ.Web.UI.TreeViewNode[] arrNodeList = new SJ.Web.UI.TreeViewNode[intRow];
        string[] arrSelfNdID        = new string[intRow];
        bool blnSW                  = false;

        iTreeView.Nodes.Clear();
        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId                 = dr["SFID"].ToString();
            strPtId                 = dr["PTID"].ToString();
            strDept                 = dr["NAME"].ToString();
            strLevel                = dr["LVL"].ToString();
            strViewYn               = dr["VIEW_YN"].ToString();

            SJ.Web.UI.TreeViewNode trnDept;
            trnDept                 = new SJ.Web.UI.TreeViewNode();
            
            //strDept, strSfId
            trnDept.Value           = strSfId;
            trnDept.Text            = strDept;
            arrNodeList[intIdx]     = trnDept;
            arrSelfNdID[intIdx]     = strSfId;

            int k;
            for (k = 0; k < arrSelfNdID.Length; k++)
            {
                if (strPtId == arrSelfNdID[k])
                {
                    arrNodeList[k].Nodes.Add(trnDept);
                    trnDept.Checked = (strViewYn=="Y") ? true : false;
                    blnSW           = true;
                    break;
                }
            }

            if (!blnSW)
            {
                iTreeView.Nodes.Add(trnDept);
                trnDept.Checked     = (strViewYn == "Y") ? true : false;
                blnSW               = false;
            }

            trnDept.ImageUrl        = "0" + strLevel + "_2.gif";
            intIdx                  += 1;
        }
    }

    private static string DoMakeLevel(DataTable dt, string sfid, ref string lvlPath, int lvl)
    {
        lvl++;

        DataRow[] rows = dt.Select(string.Format(" PTID = {0} ", sfid));
        if (rows.Length > 0)
        {
            lvlPath += lvl.ToString() + "/";
            string ptid = DataTypeUtility.GetValue(rows[0]["PTID"]);

            string a = DoMakeLevel(dt, ptid, ref lvlPath, lvl);

        }

        return lvlPath;
    }

    /// <summary>
    /// Bias 그룹에 적용할 사용자 조회
    /// </summary>
    /// <param name="iTreeView"></param>
    /// <param name="comp_id"></param>
    /// <param name="est_id"></param>
    /// <param name="estterm_ref_id"></param>
    public static void FillBiasEmpOrg(TreeView iTreeView, int comp_id, string est_id, int estterm_ref_id, int bias_grp_id)
    {
        iTreeView.ShowLines = false;
        //Biz_BiasDatas bizBiasData = new Biz_BiasDatas();
        //DataSet dsTree = bizBiasData.GetBiasGroupEmp(comp_id, est_id, estterm_ref_id, bias_grp_id);

        MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info bizComDeptInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info();
        DataTable dtTemp = bizComDeptInfo.GetDeptRoot_DB();
        int root_dept_ref_id = -1;

        if (dtTemp.Rows.Count > 0)
        {
            root_dept_ref_id = DataTypeUtility.GetToInt32(dtTemp.Rows[0][0]);
        }

        MicroBSC.Integration.EST.Biz.Biz_Est_Bias_Group bizEstBiasGroup = new MicroBSC.Integration.EST.Biz.Biz_Est_Bias_Group();
        DataSet dsTree = bizEstBiasGroup.GetBiasGroupEmp_DB(comp_id, est_id, estterm_ref_id, bias_grp_id);



        string strSfId = "";         // 부서 ID
        string strPtId = "";         // 부모 부서 ID
        string strDept = "";         // 부서명
        string strLevel = "";         // 부서레벨
        string strViewYn = "";         // 사원Check여부
        string strEnableYn = "";        // 활성화여부
        string strValuePath = "";          // 부서트리 : 뎁쓰 + 부서코드
        int intRow = dsTree.Tables[0].Rows.Count;

        TreeNode[] arrNodeList = new TreeNode[intRow];
        string[] arrSelfNdID = new string[intRow];

        iTreeView.Nodes.Clear();

        if (dsTree.Tables[0].Rows.Count == 0)
            return;

        dsTree.Tables[0].Columns.Add("VALUEPATH", typeof(string));

        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            //int lvl = 0;
            //string lvlPath = string.Empty;
            //string a = DoMakeLevel(dsTree.Tables[0], DataTypeUtility.GetValue(dr["SFID"]), ref lvlPath, lvl);
            //dr["VALUEPATH"] = lvlPath;
            dr["VALUEPATH"] = GetValuePath(DataTypeUtility.GetToInt32(dr["SFID"]), DataTypeUtility.GetToInt32(dr["PTID"]), dsTree.Tables[0], (DataTypeUtility.GetToInt32(dr["EMP_REF_ID"]) == 0 ? "" : "/" + DataTypeUtility.GetToInt32(dr["EMP_REF_ID"]).ToString()));
            
        }   

        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId = dr["SFID"].ToString();
            strPtId = dr["PTID"].ToString();
            strDept = dr["NAME"].ToString();
            strLevel = dr["LVL"].ToString();
            strViewYn = dr["ISCHECK"].ToString();
            strEnableYn = dr["ISENABLED"].ToString();
            strValuePath = dr["VALUEPATH"].ToString();

            if (DataTypeUtility.GetToInt32(dr["EMP_REF_ID"]) == 0)
            {
                if (iTreeView.FindNode(strValuePath) == null)
                {
                    TreeNode trnDept = new TreeNode();
                    trnDept.Expanded = true;
                    trnDept.SelectAction = TreeNodeSelectAction.Expand;
                    trnDept.Value = strSfId;
                    trnDept.Text = strDept;

                    //if (iTreeView.FindNode(strValuePath.Substring(0, strValuePath.Length - strSfId.Length - 1)) == null)
                    //    iTreeView.Nodes.Add(trnDept);
                    //else
                    //    iTreeView.FindNode(strValuePath.Substring(0, strValuePath.Length - strSfId.Length - 1)).ChildNodes.Add(trnDept);


                    if (iTreeView.FindNode(strValuePath) == null)
                    {
                        if (strValuePath.Split('/').Length == 1)
                            iTreeView.Nodes.Add(trnDept);
                        else
                        {
                            if (iTreeView.FindNode(strValuePath.Substring(0, strValuePath.Length - strSfId.Length - 1)) != null)
                                iTreeView.FindNode(strValuePath.Substring(0, strValuePath.Length - strSfId.Length - 1)).ChildNodes.Add(trnDept);
                        }
                    }
                    trnDept.ShowCheckBox = true;
                    trnDept.ImageUrl = "~/images/icon/0" + strLevel + "_2.gif";
                    trnDept.ToolTip = "DEPT";
                }
            }
            else
            {
                if (iTreeView.FindNode(strValuePath.Substring(0, strValuePath.Length - dr["EMP_REF_ID"].ToString().Length - 1)) == null)
                {
                    string fullPath = strValuePath.Substring(0, strValuePath.Length - dr["EMP_REF_ID"].ToString().Length - 1);
                    TreeNode trnDept = new TreeNode();
                    trnDept.Expanded = true;
                    trnDept.SelectAction = TreeNodeSelectAction.Expand;
                    trnDept.Value = strSfId;
                    trnDept.Text = strDept;
                    if (iTreeView.FindNode(fullPath) == null)
                    {
                        if (fullPath.Split('/').Length == 1)
                            iTreeView.Nodes.Add(trnDept);
                        else
                        {
                            if (iTreeView.FindNode(fullPath.Substring(0, fullPath.Length - strSfId.Length - 1)) != null)
                                iTreeView.FindNode(fullPath.Substring(0, fullPath.Length - strSfId.Length - 1)).ChildNodes.Add(trnDept);
                        }
                    }
                    trnDept.ShowCheckBox = true;
                    trnDept.ImageUrl = "~/images/icon/0" + strLevel + "_2.gif";
                    trnDept.ToolTip = "DEPT";
                }
            }

            if (DataTypeUtility.GetToInt32(dr["EMP_REF_ID"]) > 0)
            {
                TreeNode trnEmp = new TreeNode();
                trnEmp.Expanded = false;
                trnEmp.SelectAction = TreeNodeSelectAction.None;
                trnEmp.Value = dr["EMP_REF_ID"].ToString();
                trnEmp.Text = dr["EMP_NAME"].ToString();
                trnEmp.Checked = (strViewYn == "Y" ? true : false);
                trnEmp.ShowCheckBox = (strViewYn == "N" && strEnableYn == "N" ? false : true);

                if (iTreeView.FindNode(strValuePath.Substring(0, strValuePath.Length - dr["EMP_REF_ID"].ToString().Length - 1)) != null)
                    iTreeView.FindNode(strValuePath.Substring(0, strValuePath.Length - dr["EMP_REF_ID"].ToString().Length - 1)).ChildNodes.Add(trnEmp);

                trnEmp.ImageUrl = "~/images/icon/08_2.gif";
                trnEmp.ToolTip = "EMP";
            }
        }
    }

    private static string GetValuePath(int uid, int pid, DataTable udt, string emp_id)
    {
        string valuePath = uid.ToString() + emp_id;

        while (pid != 0)
        {
            DataRow[] dr = udt.Select(string.Format("SFID = {0}", pid));
            if (dr.Length > 0)
            {
                valuePath = dr[0]["SFID"].ToString() + "/" + valuePath;
                pid = DataTypeUtility.GetToInt32(dr[0]["PTID"]);
            }
        }
        return valuePath;
    }

    /// <summary>
    /// 조직별 권한설정 트리조회
    /// </summary>
    /// <param name="iTreeView">트리컨트롤</param>
    /// <param name="iLoginID">사용자ID</param>
    public static void FillEstOrgAuthorityTree(TreeView iTreeView, int iLoginID)
    {
        iTreeView.ShowLines = false;
        Biz_ComDeptInfo dept    = new Biz_ComDeptInfo();
        DataSet dsTree          = dept.GetComDeptOrgAuthorityByTree(iLoginID);

        //iTreeView.Im = "~/images/icon/";
        string strSfId          = "";         // 부서 ID
        string strPtId          = "";         // 부모 부서 ID
        string strDept          = "";         // 부서명
        string strLevel         = "";         // 부서레벨
        string strViewYn        = "";         // 조직Check여부
        int intIdx              = 0;
        int intRow              = dsTree.Tables[0].Rows.Count;

        TreeNode[] arrNodeList  = new TreeNode[intRow];
        string[] arrSelfNdID    = new string[intRow];
        bool blnSW              = false;

        iTreeView.Nodes.Clear();
        foreach (DataRow dr in dsTree.Tables[0].Rows)
        {
            strSfId             = dr["SFID"].ToString();
            strPtId             = dr["PTID"].ToString();
            strDept             = dr["NAME"].ToString();
            strLevel            = dr["LVL"].ToString();
            strViewYn           = dr["VIEW_YN"].ToString();

            TreeNode trnDept;
            trnDept             = new TreeNode();
            trnDept.Expanded    = true;
            trnDept.SelectAction = TreeNodeSelectAction.Expand;
            //strDept, strSfId
            trnDept.Value       = strSfId;
            trnDept.Text        = strDept;
            arrNodeList[intIdx] = trnDept;
            arrSelfNdID[intIdx] = strSfId;

            int k;
            for (k = 0; k < arrSelfNdID.Length; k++)
            {
                if (strPtId == arrSelfNdID[k])
                {
                    arrNodeList[k].ChildNodes.Add(trnDept);
                    trnDept.Checked = (strViewYn == "Y") ? true : false;
                    blnSW = true;
                    break;
                }
            }

            if (!blnSW)
            {
                iTreeView.Nodes.Add(trnDept);
                trnDept.Checked = (strViewYn == "Y") ? true : false;
                blnSW = false;
            }

            trnDept.ImageUrl = "~/images/icon/0" + strLevel + "_2.gif";
            intIdx += 1;
        }
    }

    public static void FillEstMappingTree(TreeView iTreeView, int iEstTermId)
    {
        FillEstMappingTree(iTreeView, iEstTermId, TreeNodeSelectAction.Select);
    }

    public static string GetParentTreeText(TreeView iTreeView)
    {
        string strRtn;
        TreeNode trnCur = iTreeView.SelectedNode;

        strRtn = "";
        while (trnCur != null)
        {
            strRtn = trnCur.Text + "/" + strRtn;
            trnCur = trnCur.Parent;
        }

        return strRtn;
    }


    // 평가부서 선택시 부서부분만 잘라내서 경로를 보이게 함
    public static string GetEstParentTreeText(TreeView iTreeView)
    {
        string strRtn;
        TreeNode trnCur = iTreeView.SelectedNode;
        int edIndex = 0;

        strRtn = "";
        while (trnCur != null)
        {

            edIndex = (trnCur.Text.IndexOf("<=>")) < 0 ? trnCur.Text.Length : trnCur.Text.IndexOf("<=>");
            strRtn  = trnCur.Text.Substring(0,edIndex) + "/" + strRtn;
            trnCur  = trnCur.Parent;
        }

        return strRtn;
    }

    public static string GetDeptTreePathText(TreeView iTreeView)
    {
        string strRtn;
        TreeNode trnCur = iTreeView.SelectedNode;

        strRtn = "";

        while (trnCur != null)
        {
            if (trnCur.Parent == null)
                strRtn =  trnCur.Text + strRtn;
            else
                strRtn = ">>" + trnCur.Text + strRtn;

            trnCur = trnCur.Parent;
        }

        return strRtn;
    }

    /// <summary>
    /// Commmunication 에서 받는사람의 수신글이 있을 경우 이미지가 깜빡거림
    /// </summary>
    /// <param name="ltrCommunication">Literal 컨트롤</param>
    /// <param name="activeImageName">깜빡거리는 이미지 경로</param>
    /// <param name="noactiveImageName">깜빡러리지 않는 이미지 경로</param>
    /// <param name="movePath">클릭했을 경우 이동 경로</param>
    /// <param name="emp_ref_id">수신자 ID</param>
    /// <returns></returns>
    //public static void SetCommunicationImageStatus(Literal ltrCommunication
    //                                                , string activeImageName
    //                                                , string noactiveImageName
    //                                                , string movePath
    //                                                , int emp_ref_id) 
    //{
    //    Biz_KpiBoardReceivers kpiBoardRec   = new Biz_KpiBoardReceivers();
    //    bool isCheck                        = kpiBoardRec.CheckCommunication(emp_ref_id);

    //    if(isCheck)
    //        ltrCommunication.Text = string.Format("<a href='#null' onclick=\"location.href='{0}'\"><img src='{1}' boarder='0'></a>", movePath, activeImageName) ;
    //    else
    //        ltrCommunication.Text = string.Format("<a href='#null' onclick=\"location.href='{0}'\"><img src='{1}' boarder='0'></a>", movePath, noactiveImageName) ;
    //}

    //public static void SetCommunicationImageStatus(HtmlImage htmlImage
    //                                                , string activeImageName
    //                                                , string noactiveImageName
    //                                                , int emp_ref_id) 
    //{
    //    Biz_KpiBoardReceivers kpiBoardRec   = new Biz_KpiBoardReceivers();
    //    bool isCheck                        = kpiBoardRec.CheckCommunication(emp_ref_id);

    //    htmlImage.Src       = activeImageName;
    //    htmlImage.Visible   = true;

    //    if(isCheck)
    //        htmlImage.Src   = activeImageName;
    //    else
    //        htmlImage.Src   = noactiveImageName;

    //    //if(isCheck)
    //    //    ltrCommunication.Text = string.Format("<a href='#null' onclick=\"location.href='{0}'\"><img src='{1}' boarder='0'></a>", movePath, activeImageName) ;
    //    //else
    //    //    ltrCommunication.Text = string.Format("<a href='#null' onclick=\"location.href='{0}'\"><img src='{1}' boarder='0'></a>", movePath, noactiveImageName) ;


    //    //ImageButton1.Src = "~/images/btn/top_bu_k01_b.gif";
    //    //ImageButton1.Visible = true;
    //    //if (isResult())
    //    //    ImageButton1.Src = "~/images/btn/top_bu_k01_b.gif";
    //    //else
    //    //    ImageButton1.Src = "~/images/btn/top_bu_k01.gif";
    //}

    /// <summary>
    /// 엑셀 컬럼명 가져오기 
    /// </summary>
    /// <param name="ColumnOrder">컬럼순서 배열은 0 번부터</param>
    /// <returns></returns>
    public static string GetExcelColumnName(int ColumnOrder)
    {
        string[] arrColumn = new string[]{"A" , "B" , "C" , "D" ,"E" ,"F" ,"G" ,"H" ,"I" ,"J" ,"K" ,"L" ,"M" ,"N" ,"O" ,"P" ,"Q" ,"R" ,"S" ,"T" ,"U" ,"V" ,"W" ,"X" ,"Y" ,"Z" ,
                                        "AA", "AB", "AC", "AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ",
                                        "BA", "BB", "BC", "BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR","BS","BT","BU","BV","BW","BX","BY","BZ",
                                        "CA", "CB", "CC", "CD","CE","CF","CG","CH","CI","CJ","CK","CL","CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV","CW","CX","CY","CZ",
                                        "DA", "DB", "DC", "DD","DE","DF","DG","DH","DI","DJ","DK","DL","DM","DN","DO","DP","DQ","DR","DS","DT","DU","DV","DW","DX","DY","DZ",
                                        "EA", "EB", "EC", "ED","EE","EF","EG","EH","EI","EJ","EK","EL","EM","EN","EO","EP","EQ","ER","ES","ET","EU","EV","EW","EX","EY","EZ",
                                        "FA", "FB", "FC", "FD","FE","FF","FG","FH","FI","FJ","FK","FL","FM","FN","FO","FP","FQ","FR","FS","FT","FU","FV","FW","FX","FY","FZ",
                                        "GA", "GB", "GC", "GD","GE","GF","GG","GH","GI","GJ","GK","GL","GM","GN","GO","GP","GQ","GR","GS","GT","GU","GV","GW","GX","GY","GZ",
                                        "HA", "HB", "HC", "HD","HE","HF","HG","HH","HI","HJ","HK","HL","HM","HN","HO","HP","HQ","HR","HS","HT","HU","HV","HW","HX","HY","HZ",
                                        "IA", "IB", "IC", "ID","IE","IF","IG","IH","II","IJ","IK","IL","IM","IN","IO","IP","IQ","IR","IS","IT","IU","IV"
                                        };

        if (ColumnOrder < 1)
        {
            return arrColumn[0];
        }
        else if (ColumnOrder > arrColumn.Length)
        {
            return arrColumn[arrColumn.Length - 1];
        }
        else
        {
            return arrColumn[ColumnOrder];
        }
    }

    /// <summary>
    /// Excel 컬럼수 구하기
    /// </summary>
    /// <returns></returns>
    public static int GetExcelColumnCount()
    {
        string[] arrColumn = new string[]{"A" , "B" , "C" , "D" ,"E" ,"F" ,"G" ,"H" ,"I" ,"J" ,"K" ,"L" ,"M" ,"N" ,"O" ,"P" ,"Q" ,"R" ,"S" ,"T" ,"U" ,"V" ,"W" ,"X" ,"Y" ,"Z" ,
                                        "AA", "AB", "AC", "AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ",
                                        "BA", "BB", "BC", "BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN","BO","BP","BQ","BR","BS","BT","BU","BV","BW","BX","BY","BZ",
                                        "CA", "CB", "CC", "CD","CE","CF","CG","CH","CI","CJ","CK","CL","CM","CN","CO","CP","CQ","CR","CS","CT","CU","CV","CW","CX","CY","CZ",
                                        "DA", "DB", "DC", "DD","DE","DF","DG","DH","DI","DJ","DK","DL","DM","DN","DO","DP","DQ","DR","DS","DT","DU","DV","DW","DX","DY","DZ",
                                        "EA", "EB", "EC", "ED","EE","EF","EG","EH","EI","EJ","EK","EL","EM","EN","EO","EP","EQ","ER","ES","ET","EU","EV","EW","EX","EY","EZ",
                                        "FA", "FB", "FC", "FD","FE","FF","FG","FH","FI","FJ","FK","FL","FM","FN","FO","FP","FQ","FR","FS","FT","FU","FV","FW","FX","FY","FZ",
                                        "GA", "GB", "GC", "GD","GE","GF","GG","GH","GI","GJ","GK","GL","GM","GN","GO","GP","GQ","GR","GS","GT","GU","GV","GW","GX","GY","GZ",
                                        "HA", "HB", "HC", "HD","HE","HF","HG","HH","HI","HJ","HK","HL","HM","HN","HO","HP","HQ","HR","HS","HT","HU","HV","HW","HX","HY","HZ",
                                        "IA", "IB", "IC", "ID","IE","IF","IG","IH","II","IJ","IK","IL","IM","IN","IO","IP","IQ","IR","IS","IT","IU","IV"
                                        };

        return arrColumn.Length;
    }

    /// <summary>
    /// Dundas 차트 타입
    /// </summary>
    /// <returns></returns>
    public static Dundas.Charting.WebControl.SeriesChartType GetDundasChartType(string strChartType)
    {
        switch (strChartType.ToUpper())
        {
            case "AREA" :
                return Dundas.Charting.WebControl.SeriesChartType.Area;
            case "BAR" :
                return Dundas.Charting.WebControl.SeriesChartType.Bar;
            case "BOXPLOT" :
                return Dundas.Charting.WebControl.SeriesChartType.BoxPlot;
            case "BUBBLE" :
                return Dundas.Charting.WebControl.SeriesChartType.Bubble;
            case "CANDLESTICK" :
                return Dundas.Charting.WebControl.SeriesChartType.CandleStick;
            case "COLUMN" :
                return Dundas.Charting.WebControl.SeriesChartType.Column;
            case "DOUGHNUT" :
                return Dundas.Charting.WebControl.SeriesChartType.Doughnut;
            case "ERRORBAR" :
                return Dundas.Charting.WebControl.SeriesChartType.ErrorBar;
            case "FASTLINE" :
                return Dundas.Charting.WebControl.SeriesChartType.FastLine;
            case "FUNNEL" :
                return Dundas.Charting.WebControl.SeriesChartType.Funnel;
            case "GANTT" :
                return Dundas.Charting.WebControl.SeriesChartType.Gantt;
            case "KAGI" :
                return Dundas.Charting.WebControl.SeriesChartType.Kagi;
            case "LINE" :
                return Dundas.Charting.WebControl.SeriesChartType.Line;
            case "PIE" :
                return Dundas.Charting.WebControl.SeriesChartType.Pie;
            case "POINT" :
                return Dundas.Charting.WebControl.SeriesChartType.Point;
            case "POINTANDFIGURE" :
                return Dundas.Charting.WebControl.SeriesChartType.PointAndFigure;
            case "POLAR" :
                return Dundas.Charting.WebControl.SeriesChartType.Polar;
            case "PYRAMID" :
                return Dundas.Charting.WebControl.SeriesChartType.Pyramid;
            case "RADAR" :
                return Dundas.Charting.WebControl.SeriesChartType.Radar;
            case "RANGE" :
                return Dundas.Charting.WebControl.SeriesChartType.Range;
            case "RANGECOLUMN" :
                return Dundas.Charting.WebControl.SeriesChartType.RangeColumn;
            case "RENKO" :
                return Dundas.Charting.WebControl.SeriesChartType.Renko;
            case "SPLINE" :
                return Dundas.Charting.WebControl.SeriesChartType.Spline;
            case "SPLINEAREA" :
                return Dundas.Charting.WebControl.SeriesChartType.SplineArea;
            case "SPLINERANGE" :
                return Dundas.Charting.WebControl.SeriesChartType.SplineRange;
            case "STACKEDAREA" :
                return Dundas.Charting.WebControl.SeriesChartType.StackedArea;
            case "STACKEDAREA100" :
                return Dundas.Charting.WebControl.SeriesChartType.StackedArea100;
            case "STACKEDBAR" :
                return Dundas.Charting.WebControl.SeriesChartType.StackedBar;
            case "STACKEDBAR100" :
                return Dundas.Charting.WebControl.SeriesChartType.StackedBar100;
            case "STACKEDCOLUMN" :
                return Dundas.Charting.WebControl.SeriesChartType.StackedColumn;
            case "STACKEDCOLUMN100" :
                return Dundas.Charting.WebControl.SeriesChartType.StackedColumn100;
            case "STEPLINE" :
                return Dundas.Charting.WebControl.SeriesChartType.StepLine;
            case "STOCK" :
                return Dundas.Charting.WebControl.SeriesChartType.Stock;
            case "THREELINEBREAK" :
                return Dundas.Charting.WebControl.SeriesChartType.ThreeLineBreak;
            default:
                return Dundas.Charting.WebControl.SeriesChartType.Area;
        }
    }

    /// <summary>
    /// Dundas 차트 타입
    /// </summary>
    /// <returns></returns>
    public static System.Web.UI.DataVisualization.Charting.SeriesChartType GetMSChartType(string strChartType)
    {
        switch (strChartType.ToUpper())
        {
            case "AREA":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Area;
            case "BAR":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
            case "BOXPLOT":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.BoxPlot;
            case "BUBBLE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Bubble;
            case "CANDLESTICK":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Candlestick;
            case "COLUMN":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
            case "DOUGHNUT":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
            case "ERRORBAR":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.ErrorBar;
            case "FASTLINE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.FastLine;
            case "FUNNEL":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel;
            //case "GANTT":
            //    return System.Web.UI.DataVisualization.Charting.SeriesChartType.Gantt;
            case "KAGI":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Kagi;
            case "LINE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            case "PIE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            case "POINT":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
            case "POINTANDFIGURE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.PointAndFigure;
            case "POLAR":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Polar;
            case "PYRAMID":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Pyramid;
            case "RADAR":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Radar;
            case "RANGE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Range;
            case "RANGECOLUMN":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.RangeColumn;
            case "RENKO":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Renko;
            case "SPLINE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
            case "SPLINEAREA":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.SplineArea;
            case "SPLINERANGE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.SplineRange;
            case "STACKEDAREA":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedArea;
            case "STACKEDAREA100":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedArea100;
            case "STACKEDBAR":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar;
            case "STACKEDBAR100":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar100;
            case "STACKEDCOLUMN":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;
            case "STACKEDCOLUMN100":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            case "STEPLINE":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.StepLine;
            case "STOCK":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Stock;
            case "THREELINEBREAK":
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.ThreeLineBreak;
            default:
                return System.Web.UI.DataVisualization.Charting.SeriesChartType.Area;
        }
    }

    public static void SetDundasChartType(DropDownList ddlChartType)
    {
        ddlChartType.Items.Add(new ListItem("Area", "Area"));
        //ddlChartType.Items.Add(new ListItem("Bar", "Bar"));
        ddlChartType.Items.Add(new ListItem("BoxPlot", "BoxPlot"));
        ddlChartType.Items.Add(new ListItem("Bubble", "Bubble"));
        ddlChartType.Items.Add(new ListItem("CandleStick", "CandleStick"));
        ddlChartType.Items.Add(new ListItem("Column", "Column"));
        //ddlChartType.Items.Add(new ListItem("Doughnut", "Doughnut"));
        //ddlChartType.Items.Add(new ListItem("ErrorBar", "ErrorBar"));
        ddlChartType.Items.Add(new ListItem("FastLine", "FastLine"));
        //ddlChartType.Items.Add(new ListItem("Funnel", "Funnel"));
        //ddlChartType.Items.Add(new ListItem("Gantt", "Gantt"));
        ddlChartType.Items.Add(new ListItem("Kagi", "Kagi"));
        ddlChartType.Items.Add(new ListItem("Line", "Line"));
        //ddlChartType.Items.Add(new ListItem("Pie", "Pie"));
        ddlChartType.Items.Add(new ListItem("Point", "Point"));
        //ddlChartType.Items.Add(new ListItem("PointAndFigure", "PointAndFigure"));
        //ddlChartType.Items.Add(new ListItem("Polar", "Polar"));
        //ddlChartType.Items.Add(new ListItem("Pyramid", "Pyramid"));
        //ddlChartType.Items.Add(new ListItem("Radar", "Radar"));
        ddlChartType.Items.Add(new ListItem("Range", "Range"));
        ddlChartType.Items.Add(new ListItem("RangeColumn", "RangeColumn"));
        ddlChartType.Items.Add(new ListItem("Renko", "Renko"));
        ddlChartType.Items.Add(new ListItem("Spline", "Spline"));
        ddlChartType.Items.Add(new ListItem("SplineArea", "SplineArea"));
        ddlChartType.Items.Add(new ListItem("SplineRange", "SplineRange"));
        ddlChartType.Items.Add(new ListItem("StackedArea", "StackedArea"));
        //ddlChartType.Items.Add(new ListItem("StackedArea100", "StackedArea100"));
        //ddlChartType.Items.Add(new ListItem("StackedBar", "StackedBar"));
        //ddlChartType.Items.Add(new ListItem("StackedBar100", "StackedBar100"));
        ddlChartType.Items.Add(new ListItem("StackedColumn", "StackedColumn"));
        //ddlChartType.Items.Add(new ListItem("StackedColumn100", "StackedColumn100"));
        ddlChartType.Items.Add(new ListItem("StepLine", "StepLine"));
        ddlChartType.Items.Add(new ListItem("Stock", "Stock"));
        ddlChartType.Items.Add(new ListItem("ThreeLineBreak", "ThreeLineBreak"));

        ddlChartType.SelectedIndex = 0;
    }
}
