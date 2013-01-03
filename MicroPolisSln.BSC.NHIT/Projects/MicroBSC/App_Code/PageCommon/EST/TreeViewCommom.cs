using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.Estimation.Biz;

public class TreeViewCommom
{
    #region ========= TreeView 생성

    private static TreeNode CreateNode(string value
                                    , string text
                                    , string imageurl
                                    , bool expanded
                                    , TreeNodeSelectAction treeNodeSel
                                    , bool showChk)
    {
        TreeNode node       = new TreeNode();
        node.Value          = value;
        node.Text           = text;
        node.ImageUrl       = imageurl;
        node.SelectAction   = treeNodeSel;
        node.Expanded       = expanded;
        node.ShowCheckBox   = showChk;
        return node;
    }

    private static TreeNode CreateNode(string value, string text, string imageurl, bool expanded)
    {
        return CreateNode(value, text, imageurl, expanded, TreeNodeSelectAction.Select, false);
    }

    private static TreeNode CreateNode( string value, string text, bool expanded )
    {
        return CreateNode( value, text, string.Empty, expanded, TreeNodeSelectAction.Select, false );
    }

    private static string GetFirtChar(string str, string defaultStr) 
    {
        if(str != null || str.Equals("")) 
        {
            return str[0].ToString();
        }

        return defaultStr;
    }

    #endregion

    #region ========= 일정관리 작업 TreeView 바인딩

	public static void BindJobs( TreeView treeView, TreeNodeSelectAction treeNodeSelectAction, int comp_id)
	{
        BindJobs( treeView, false, treeNodeSelectAction, null, comp_id);
	}

    public static void BindJobs( TreeView treeView
								, bool isCheckBox
								, TreeNodeSelectAction treeNodeSelectAction
								, string checkedValues
                                , int comp_id)
    {
        string valueStr			= "EST_SCHE_ID";
        string up_valueStr		= "UP_EST_SCHE_ID";
        string textStr			= "EST_SCHE_NAME";
        string iconStr          = "EST_SCHE_ID";
        string imageUrlDir		= "../images/dept_icon/";
        bool isExtended			= true;
		DataTable dataTable     = null;

        // 부모 페이지에서 값이 수정되었을 경우를 위해서 체크박스에 대한 값을 처리하기 
        // 위해서 추가 되는 부분
        if(isCheckBox && (checkedValues != null || checkedValues == "")) 
        {
            dataTable           = new DataTable();
            DataRow dr          = null;
            dataTable.Columns.Add("VALUE", typeof(string));
            dataTable.Columns.Add("OK_YN", typeof(string));
            
            string[] values = checkedValues.Split(',');

            foreach(string val in values) 
            {
                dr          = dataTable.NewRow();
                dr["VALUE"] = val;
                dr["OK_YN"] = "N";
                dataTable.Rows.Add(dr);
            }
        }

        Biz_ScheInfos scheInfos	= new Biz_ScheInfos();
		DataSet ds				= scheInfos.GetScheInfo(comp_id);

        ds.Relations.Add( "NodeRelation" 
		                , ds.Tables[0].Columns[valueStr]
		                , ds.Tables[0].Columns[up_valueStr]
		                , false );

        treeView.Nodes.Clear();

        foreach ( DataRow dbRow in ds.Tables[0].Rows )
        {
            if ( dbRow[up_valueStr] == DBNull.Value)
            {
                TreeNode rootNode = CreateNode(dbRow[valueStr].ToString()
											, dbRow[textStr].ToString()
                                            , imageUrlDir + ( (dbRow["EST_ID"].ToString().Length != 0) ? "blue/E.gif" : "blue/S.gif" )
											, isExtended
                                            , treeNodeSelectAction
                                            , isCheckBox);

                if ( isCheckBox && ( checkedValues != null || checkedValues == "" ) ) 
                {
                    TreeNodeCheck( rootNode, dataTable );
                }

                treeView.Nodes.Add( rootNode );
                PopulateEstTreeJob( dbRow, rootNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, isExtended, isCheckBox, dataTable);
            }
        }
    }

    private static void PopulateSubTree(  DataRow dbRow
                                        , TreeNode node
                                        , string valueStr
                                        , string textStr
                                        , string imageUrlDir
                                        , bool expanded )
    {
        foreach ( DataRow childRow in dbRow.GetChildRows( "NodeRelation" ) )
        {
            TreeNode childNode = CreateNode( childRow[valueStr].ToString()
											, childRow[textStr].ToString()
											, imageUrlDir + string.Format( "blue/{0}.gif", GetFirtChar( dbRow[valueStr].ToString(), "p" ) )
											, expanded);
            node.ChildNodes.Add( childNode );
            PopulateSubTree( childRow, childNode, valueStr, textStr, imageUrlDir, expanded );
        }
    }

    private static void PopulateSubTree(  DataRow dbRow
                                        , TreeNode node
                                        , string valueStr
                                        , string textStr
                                        , string imageUrlDir
                                        , TreeNodeSelectAction treeNodeSelectAction
                                        , bool expanded
                                        , bool isCheckBox)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            TreeNode childNode = CreateNode(  childRow[valueStr].ToString()
											, childRow[textStr].ToString()
                                            , imageUrlDir + "blue/E.gif"
											, expanded
                                            , treeNodeSelectAction
                                            , isCheckBox);

            node.ChildNodes.Add( childNode );
            PopulateSubTree(childRow, childNode, valueStr, textStr, imageUrlDir, treeNodeSelectAction, expanded, isCheckBox);
        }
    }

    #endregion

    #region ========= 평가

    public static void BindEst( TreeView treeView, int comp_id)
    {
        BindEst(treeView, false, TreeNodeSelectAction.Select, null, comp_id);
    }

    public static void BindEst( TreeView treeView, bool isCheckBox, int comp_id)
    {
        TreeNodeSelectAction treeNodeSelectAction = TreeNodeSelectAction.None;

        if(!isCheckBox)
            treeNodeSelectAction = TreeNodeSelectAction.Select;

        BindEst(treeView, isCheckBox, treeNodeSelectAction, null, comp_id);
    }

    public static void BindEst( TreeView treeView, TreeNodeSelectAction treeNodeSelectAction, int comp_id)
    {
        BindEst(treeView, false, treeNodeSelectAction, null, comp_id);
    }

    public static void BindEst( TreeView treeView
                                , bool isCheckBox
                                , TreeNodeSelectAction treeNodeSelectAction
                                , string checkedValues
                                , int comp_id)
    {
        string valueStr			= "EST_ID";
        string up_valueStr		= "UP_EST_ID";
        string textStr			= "EST_NAME";
        string iconStr          = "EST_STYLE_ID";
        string imageUrlDir		= "../images/dept_icon/";
        bool isExtended			= true;
        DataTable dataTable     = null;

        // 부모 페이지에서 값이 수정되었을 경우를 위해서 체크박스에 대한 값을 처리하기 
        // 위해서 추가 되는 부분
        if(isCheckBox && (checkedValues != null || checkedValues == "")) 
        {
            dataTable           = new DataTable();
            DataRow dr          = null;
            dataTable.Columns.Add("VALUE", typeof(string));
            dataTable.Columns.Add("OK_YN", typeof(string));
            
            string[] values = checkedValues.Split(',');

            foreach(string val in values) 
            {
                dr          = dataTable.NewRow();
                dr["VALUE"] = val;
                dr["OK_YN"] = "N";
                dataTable.Rows.Add(dr);
            }
        }

        Biz_EstInfos estInfos	= new Biz_EstInfos();
		DataSet ds				= estInfos.GetEstInfos(comp_id);

        ds.Relations.Add( "NodeRelation" 
			            , ds.Tables[0].Columns[valueStr]
			            , ds.Tables[0].Columns[up_valueStr]
			            , false );

        treeView.Nodes.Clear();

        foreach ( DataRow dbRow in ds.Tables[0].Rows )
        {
            if ( dbRow[up_valueStr] == DBNull.Value)
            {
                TreeNode rootNode = CreateNode( dbRow[valueStr].ToString()
											, dbRow[textStr].ToString()
                                            , imageUrlDir + string.Format("blue/{0}.gif", GetFirtChar(dbRow[iconStr].ToString(), "E"))
											, isExtended
                                            , treeNodeSelectAction
                                            , isCheckBox);

                if(isCheckBox && (checkedValues != null || checkedValues == "")) 
                {
                    TreeNodeCheck(rootNode, dataTable);
                }

                treeView.Nodes.Add( rootNode );
                PopulateEstTree( dbRow, rootNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, isExtended, isCheckBox, dataTable);
            }
        }
    }

    private static void PopulateEstTree(  DataRow dbRow
                                        , TreeNode node
                                        , string valueStr
                                        , string textStr
                                        , string imageUrlDir
                                        , string iconStr
                                        , TreeNodeSelectAction treeNodeSelectAction
                                        , bool expanded
                                        , bool isCheckBox
                                        , DataTable callbackDataTable)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            TreeNode childNode = CreateNode(  childRow[valueStr].ToString()
											, childRow[textStr].ToString()
                                            , imageUrlDir + string.Format("blue/{0}.gif", GetFirtChar(childRow[iconStr].ToString(), "E"))
											, expanded
                                            , treeNodeSelectAction
                                            , isCheckBox);

            if(isCheckBox && callbackDataTable != null) 
            {
                TreeNodeCheck(childNode, callbackDataTable);
            }

            node.ChildNodes.Add( childNode );
            PopulateEstTree(childRow, childNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, expanded, isCheckBox, callbackDataTable);
        }
    }

    private static void PopulateEstTreeJob(  DataRow dbRow
                                        , TreeNode node
                                        , string valueStr
                                        , string textStr
                                        , string imageUrlDir
                                        , string iconStr
                                        , TreeNodeSelectAction treeNodeSelectAction
                                        , bool expanded
                                        , bool isCheckBox
                                        , DataTable callbackDataTable)
    {
        foreach ( DataRow childRow in dbRow.GetChildRows("NodeRelation") )
        {
            TreeNode childNode = CreateNode(  childRow[valueStr].ToString()
											, childRow[textStr].ToString()
                                            , imageUrlDir + ( (childRow["EST_ID"].ToString().Length != 0) ? "blue/E.gif" : "blue/S.gif" )
											, expanded
                                            , treeNodeSelectAction
                                            , isCheckBox);

            if ( isCheckBox && callbackDataTable != null )
            {
                TreeNodeCheck( childNode, callbackDataTable );
            }

            node.ChildNodes.Add( childNode );
            PopulateEstTree( childRow, childNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, expanded, isCheckBox, callbackDataTable );
        }
    }

    private static void TreeNodeCheck( TreeNode treeNode, DataTable dataTable )
    {
        DataRow[] drCol = dataTable.Select("OK_YN = 'N'");

        foreach(DataRow dr in drCol) 
        {
            if(treeNode.Value.Equals(dr["VALUE"].ToString())) 
            {
                treeNode.Checked    = true;
                dr["OK_YN"]         = "Y";
            }
        }
    }

    #endregion

    #region ========= 부서

    public static void BindDept(TreeView treeView)
    {
        BindDept(treeView, false, TreeNodeSelectAction.Select, null);
    }

    public static void BindDept( TreeView treeView, bool isCheckBox)
    {
        TreeNodeSelectAction treeNodeSelectAction = TreeNodeSelectAction.None;

        if(!isCheckBox)
            treeNodeSelectAction = TreeNodeSelectAction.Select;

        BindDept(treeView, isCheckBox, treeNodeSelectAction, null);
    }

    public static void BindDept( TreeView treeView, TreeNodeSelectAction treeNodeSelectAction)
    {
        BindDept(treeView, false, treeNodeSelectAction, null);
    }

    public static void BindDept(  TreeView treeView
                                , bool isCheckBox
                                , TreeNodeSelectAction treeNodeSelectAction
                                , string checkedValues)
    {
        string valueStr			= "DEPT_REF_ID";
        string up_valueStr		= "UP_DEPT_ID";
        string textStr			= "DEPT_NAME";
        string iconStr          = "DEPT_TYPE";
        string imageUrlDir		= "../images/icon/";
        bool isExtended			= true;
        DataTable dataTable     = null;

        // 부모 페이지에서 값이 수정되었을 경우를 위해서 체크박스에 대한 값을 처리하기 
        // 위해서 추가 되는 부분
        if(isCheckBox && (checkedValues != null || checkedValues == "")) 
        {
            dataTable           = new DataTable();
            DataRow dr          = null;
            dataTable.Columns.Add("VALUE", typeof(string));
            dataTable.Columns.Add("OK_YN", typeof(string));
            
            string[] values = checkedValues.Split(',');

            foreach(string val in values) 
            {
                dr          = dataTable.NewRow();
                dr["VALUE"] = val;
                dr["OK_YN"] = "N";
                dataTable.Rows.Add(dr);
            }
        }

        Biz_DeptInfos estDeptInfo   = new Biz_DeptInfos();
		DataSet ds				     = estDeptInfo.GetDeptInfos();

        ds.Relations.Add( "NodeRelation" 
			            , ds.Tables[0].Columns[valueStr]
			            , ds.Tables[0].Columns[up_valueStr]
			            , false );

        treeView.Nodes.Clear();

        foreach ( DataRow dbRow in ds.Tables[0].Rows )
        {
            if ( DataTypeUtility.GetToInt32(dbRow[up_valueStr]) == 0)
            {
                TreeNode rootNode = CreateNode( dbRow[valueStr].ToString()
											, dbRow[textStr].ToString()
                                            , imageUrlDir + string.Format("{0}_2.gif", dbRow[iconStr].ToString().PadLeft(2, '0'), "07")
											, isExtended
                                            , treeNodeSelectAction
                                            , isCheckBox);

                if(isCheckBox && (checkedValues != null || checkedValues == "")) 
                {
                    TreeNodeCheck(rootNode, dataTable);
                }

                treeView.Nodes.Add( rootNode );
                PopulateEstDeptTree( dbRow, rootNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, isExtended, isCheckBox, dataTable);
            }
        }
    }

    private static void PopulateEstDeptTree(  DataRow dbRow
                                            , TreeNode node
                                            , string valueStr
                                            , string textStr
                                            , string imageUrlDir
                                            , string iconStr
                                            , TreeNodeSelectAction treeNodeSelectAction
                                            , bool expanded
                                            , bool isCheckBox
                                            , DataTable callbackDataTable)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            TreeNode childNode = CreateNode(  childRow[valueStr].ToString()
											, childRow[textStr].ToString()
                                            , imageUrlDir + string.Format("{0}_2.gif", childRow[iconStr].ToString().PadLeft(2, '0'), "07")
											, expanded
                                            , treeNodeSelectAction
                                            , isCheckBox);

            if(isCheckBox && callbackDataTable != null) 
            {
                TreeNodeCheck(childNode, callbackDataTable);
            }

            node.ChildNodes.Add( childNode );
            PopulateEstDeptTree(childRow, childNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, expanded, isCheckBox, callbackDataTable);
        }
    }

    #endregion

    #region ========= 직종 - 직무

    public static void BindKndBiz(TreeView treeView)
    {
        string valueStr_knd		= "POS_KND_ID";
        string textStr_knd		= "POS_KND_NAME";
        string valueStr_biz		= "POS_BIZ_ID";
        string textStr_biz		= "POS_BIZ_NAME";

        string imageUrlDir		= "../images/dept_icon/";

        Biz_PositionKinds posKind   = new Biz_PositionKinds();
        DataTable dtKnd             = posKind.GetPositionKinds().Tables[0];

        Biz_PositionKindBizMaps posKndBiz   = new Biz_PositionKindBizMaps();
        DataTable dtKndBiz                  = posKndBiz.GetPosKndBizMaps().Tables[0];

        TreeNode rootNode = CreateNode("", "Root", imageUrlDir + "purple/R.gif", true, TreeNodeSelectAction.None, false);
        treeView.Nodes.Add(rootNode);

        foreach (DataRow dbRowKnd in dtKnd.Rows)
        {
            TreeNode newNode = CreateNode(dbRowKnd[valueStr_knd].ToString()
                                        , dbRowKnd[textStr_knd].ToString()
                                        , imageUrlDir + "blue/k.gif"
                                        , false
                                        , TreeNodeSelectAction.Expand
                                        , false);

            rootNode.ChildNodes.Add(newNode);

            DataRow[] drArrBiz = dtKndBiz.Select(string.Format(@"POS_KND_ID = '{0}'", dbRowKnd["POS_KND_ID"]));

            foreach(DataRow drBiz in drArrBiz) 
            {
                TreeNode newChildNode = CreateNode(drBiz[valueStr_biz].ToString()
                                                , drBiz[textStr_biz].ToString()
                                                , imageUrlDir + "red/b.gif"
                                                , false
                                                , TreeNodeSelectAction.Select
                                                , false);

                newNode.ChildNodes.Add(newChildNode);
            }
        }
    }

    #endregion

    #region ========= TreeView 검색 관련 메소드

    public static void SelectTreeNode(TreeView treeView, object value)
    {
        foreach (TreeNode treeNode in treeView.Nodes)
        {
            if (treeNode.Value == value.ToString())
            {
                treeNode.Select();
                return;
            }

            SelfFind(treeNode.ChildNodes, value.ToString());
        }
    }

    private static void SelfFind(TreeNodeCollection nodeCol, string value)
    {
        foreach (TreeNode treeNode in nodeCol)
        {
            if (treeNode.Value == value)
            {
                treeNode.Select();
                return;
            }

            SelfFind(treeNode.ChildNodes, value);
        }
    }

    /// <summary>
    /// 선택된 TreeNode의 부모 TreeNode.Value 반환
    /// </summary>
    /// <param name="treeView"></param>
    /// <returns></returns>
    public static string GetParentValueBySelectedNode(TreeView treeView)
    {
        TreeNode treeNode = treeView.SelectedNode;

        if (   treeNode         == null 
            || treeNode.Parent  == null)
            return "";

        return treeNode.Parent.Value;
    }

    /// <summary>
    /// 선택된 TreeNode의 부모 TreeNode.Text 반환
    /// </summary>
    /// <param name="treeView"></param>
    /// <returns></returns>
    public static string GetParentTextBySelectedNode(TreeView treeView)
    {
        TreeNode treeNode = treeView.SelectedNode;

        if (    treeNode        == null
            || treeNode.Parent  == null)
            return "";

        return treeNode.Parent.Text;
    }

    /// <summary>
    /// TreeView 의 최상위 Value 반환
    /// </summary>
    /// <param name="treeView"></param>
    /// <returns></returns>
    public static string GetTreeViewTopValue(TreeView treeView)
    {
        TreeNode treeNode = treeView.SelectedNode;

        while (treeNode != null)
        {
            if (treeNode.Parent == null)
                return treeNode.Value;

            treeNode = treeNode.Parent;
        }

        return null;
    }

    /// <summary>
    /// TreeView 의 최상위 Text 반환
    /// </summary>
    /// <param name="treeView"></param>
    /// <returns></returns>
    public static string GetTreeViewTopText(TreeView treeView)
    {
        TreeNode treeNode = treeView.SelectedNode;

        while (treeNode != null)
        {
            if (treeNode.Parent == null)
                return treeNode.Text;

            treeNode = treeNode.Parent;
        }

        return null;
    }

    #endregion

    #region  =============== 일반 메소드 

    

    #endregion

    #region ========= 메뉴
    public static void BindMenu(TreeView treeView
                               , bool isCheckBox
                               , TreeNodeSelectAction treeNodeSelectAction
                               , string checkedValues)
    {
        string valueStr = "MENU_REF_ID";
        string up_valueStr = "UP_MENU_ID";
        string textStr = "MENU_NAME";
        string iconStr = "EST_STYLE_ID";
        string imageUrlDir = "../images/treeview/";
        bool isExtended = true;
        DataTable dataTable = null;

        // 부모 페이지에서 값이 수정되었을 경우를 위해서 체크박스에 대한 값을 처리하기 
        // 위해서 추가 되는 부분
        if (isCheckBox && (checkedValues != null || checkedValues == ""))
        {
            dataTable = new DataTable();
            DataRow dr = null;
            dataTable.Columns.Add("VALUE", typeof(string));
            dataTable.Columns.Add("OK_YN", typeof(string));

            string[] values = checkedValues.Split(',');

            foreach (string val in values)
            {
                dr = dataTable.NewRow();
                dr["VALUE"] = val;
                dr["OK_YN"] = "N";
                dataTable.Rows.Add(dr);
            }
        }

        Biz_MenuInfo objMenuInfo = new Biz_MenuInfo();

        DataSet ds = objMenuInfo.GetMenuInfos();

        ds.Relations.Add("NodeRelation"
                        , ds.Tables[0].Columns[valueStr]
                        , ds.Tables[0].Columns[up_valueStr]
                        , false);

        treeView.Nodes.Clear();

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (dbRow[up_valueStr] == DBNull.Value || DataTypeUtility.GetToInt32(dbRow[up_valueStr]) == 0)
            {
                TreeNode rootNode = CreateNode(dbRow[valueStr].ToString()
                                            , dbRow[textStr].ToString()
                                            , imageUrlDir + "folder.gif"
                                            , isExtended
                                            , treeNodeSelectAction
                                            , isCheckBox);

                if (isCheckBox && (checkedValues != null || checkedValues == ""))
                {
                    TreeNodeCheck(rootNode, dataTable);
                }

                treeView.Nodes.Add(rootNode);
                PopulateMenuTree(dbRow, rootNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, isExtended, isCheckBox, dataTable);
            }
        }
    }

    private static void PopulateMenuTree(DataRow dbRow
                                        , TreeNode node
                                        , string valueStr
                                        , string textStr
                                        , string imageUrlDir
                                        , string iconStr
                                        , TreeNodeSelectAction treeNodeSelectAction
                                        , bool expanded
                                        , bool isCheckBox
                                        , DataTable callbackDataTable)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            TreeNode childNode = CreateNode(childRow[valueStr].ToString()
                                            , childRow[textStr].ToString()
                                            , imageUrlDir + "notes.gif"
                                            , expanded
                                            , treeNodeSelectAction
                                            , isCheckBox);

            if (isCheckBox && callbackDataTable != null)
            {
                TreeNodeCheck(childNode, callbackDataTable);
            }

            node.ChildNodes.Add(childNode);
            PopulateMenuTree(childRow, childNode, valueStr, textStr, imageUrlDir, iconStr, treeNodeSelectAction, expanded, isCheckBox, callbackDataTable);
        }
    }
    #endregion
}














/*
	public static void BindPosition(TreeView treeView, string position_type) 
    {
        string valueStr     = "POSITION_TYPE";
        string textStr      = "POSITION_TYPE_NAME";
        string tableNameStr = "POSITION_TABLE_NAME";
        string imageUrlDir  = "../images/dept_icon/";
        bool isExtended     = true;

        Biz_PositionInfos positionInfo  = new Biz_PositionInfos();
        DataSet ds                      = positionInfo.GetPositionInfo(position_type);

        treeView.Nodes.Clear();

        TreeNode rootNode   = null;
        TreeNode newNode    = null;

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            rootNode = CreateNode(dbRow[valueStr].ToString()
                                , dbRow[textStr].ToString()
                                , imageUrlDir + string.Format("blue/{0}.gif", GetFirtChar(dbRow[valueStr].ToString(), "p")) 
                                , false
                                , TreeNodeSelectAction.None
                                , false);

            treeView.Nodes.Add(rootNode);

            DataSet dsSub = positionInfo.GetPositionByTableName(dbRow[tableNameStr].ToString());

            foreach (DataRow dbSubRow in dsSub.Tables[0].Rows) 
            {
                newNode       = CreateNode(   dbRow[valueStr].ToString() + ";" + dbSubRow[string.Format("POSITION_{0}_CODE", dbRow[tableNameStr].ToString())].ToString()
                                            , dbSubRow[string.Format("POSITION_{0}_NAME", dbRow[tableNameStr].ToString())].ToString()
                                            , imageUrlDir + "purple/P.gif"
                                            , isExtended
                                            , TreeNodeSelectAction.Select
                                            , false);

                rootNode.ChildNodes.Add(newNode);
            }
        }
    }
*/