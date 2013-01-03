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

using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Biz.BSC;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Common;

using Infragistics.WebUI.UltraWebNavigator;
using MicroBSC.Estimation.Biz;

public partial class _common_lib_MenuControl_Tree : AppUserControlBase
{
    public string err="err";

    protected void Page_Load(object sender, EventArgs e)
    {
        SetLeftMenu();
    }

    private void SetLeftMenu()
    {
        int iTmp = 0;
       string sUrl = HttpContext.Current.Request.Url.AbsolutePath;

        // ERRORINFO.ASPX는 쿼리스트링이 고정되지 않은 페이지 이므로 예외처리한다. (해당페이지 권한시 FULL_PATH로 처리되므로 무한루프일수 있다.)
        if (
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "ERRORINFO.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1002.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1003.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1005.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR2001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR3001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR2001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR_DEPT_ORG.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR_DEPT_ORG_EMBED.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1009.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR1001_1014.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR10001.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "USR10002.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST1100.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST3600.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST4000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST4100.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "APP2000.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0406S1.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0304S2.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0403S4.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "BSC0404S1.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110104.ASPX" &&
            sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper() != "EST110104_01.ASPX"
           )
		{
            sUrl = HttpContext.Current.Request.Url.PathAndQuery;
		}

        int iTopMenuID      = GetTopMenuRefID( sUrl );
		DataSet dsSubMenu = GetSubMenuDs( iTopMenuID.ToString() );

		LeftMenu( dsSubMenu );

		string current_page = HttpContext.Current.Request.Url.Segments[Request.Url.Segments.Length-1];

        string param        = "";

        if(HttpContext.Current.Request.Url.PathAndQuery.IndexOf('?') >= 0)
        {
            param = HttpContext.Current.Request.Url.PathAndQuery;
        }
        if (current_page.ToUpper() == "EST110104.ASPX" ||
            current_page.ToUpper() == "EST110104_01.ASPX")
            param = "";
        UltraMenuExpand( current_page
                       , param
                       , UltraWebTree1
                       , UltraWebTree1.Nodes);
	}

	private void LeftMenu( DataSet dsSubMenu )
	{
		if ( dsSubMenu.Tables[0].Rows.Count == 0 )
		{
			return;
		}

		string menu_ref_id_field        = "MENU_REF_ID";
		string up_menu_id_field         = "UP_MENU_ID";
		string menu_name_field          = "MENU_NAME";
		string menu_full_path_field     = "MENU_FULL_PATH";
		string menu_page_name_field     = "MENU_PAGE_NAME";
        string menu_dir_field           = "MENU_DIR";
        string menu_param_field         = "MENU_PARAM";
        string menu_type_field          = "MENU_TYPE";

        dsSubMenu.Relations.Add( "NodeRelation" 
			                    , dsSubMenu.Tables[0].Columns[menu_ref_id_field]
			                    , dsSubMenu.Tables[0].Columns[up_menu_id_field]
			                    , false );
		
		string strIndexParentValue = dsSubMenu.Tables[0].Rows[0][up_menu_id_field].ToString();

		UltraWebTree1.ClearAll();

		foreach ( DataRow dbRow in dsSubMenu.Tables[0].Rows )
		{
            string upMenuIDField =  dbRow[up_menu_id_field].ToString();

            if (upMenuIDField.Equals(strIndexParentValue) == true)
			{
				Node nodeRoot = CreateNode(dbRow[menu_name_field].ToString()
										, (dbRow[menu_type_field].ToString().Equals("M")) ? "../images/icon/1-1.gif" : "../images/icon/2.gif"
                                        , (dbRow[menu_type_field].ToString().Equals("M")) ? "../images/icon/1.gif" : "../images/icon/2.gif"
										, false);

				nodeRoot.Tag = string.Format( "{0};{1}"
											, dbRow[menu_full_path_field].ToString().Trim()
											, dbRow[menu_page_name_field].ToString().Trim()
                                            , dbRow[menu_dir_field].ToString()
                                            , dbRow[menu_param_field].ToString());

				UltraWebTree1.Nodes.Add( nodeRoot );

				PopulateSubTree(  dbRow
								, nodeRoot
								, menu_name_field
								, menu_type_field
								, menu_full_path_field
								, menu_page_name_field
                                , menu_dir_field
                                , menu_param_field
								, false);
			}
		}
	}

    private Node CreateNode(  string text
                            , string imageurl
                            , string selectedImageUrl
                            , bool expanded )
    {
        Node node			    = new Node();
        node.Text			    = text;
        node.ImageUrl	        = imageurl;
        node.SelectedImageUrl   = selectedImageUrl;
        node.Expanded	        = expanded;

        return node;
    }

	private void PopulateSubTree( DataRow dbRow
								, Node node
								, string menu_name_field
								, string menu_type_field
								, string menu_full_path_field
								, string menu_page_name_field
                                , string menu_dir_field
                                , string menu_param_field
								, bool expanded)
	{
		foreach( DataRow childRow in dbRow.GetChildRows("NodeRelation") )
		{
			Node childNode = CreateNode(  childRow[menu_name_field].ToString()
                                        , (childRow[menu_type_field].ToString().Equals("M")) ? "../images/icon/1-1.gif" : "../images/icon/2.gif"
                                        , (childRow[menu_type_field].ToString().Equals("M")) ? "../images/icon/1.gif" : "../images/icon/2.gif"
										, expanded );

			childNode.Tag = string.Format("{0};{1}"
										, childRow[menu_full_path_field].ToString().Trim()
										, childRow[menu_page_name_field].ToString().Trim()
                                        , childRow[menu_dir_field].ToString()
                                        , childRow[menu_param_field].ToString());

//			childNode.Tag = string.Format( "{0}"
//													, childRow[menu_full_path_field].ToString()
//													);

			node.Nodes.Add(childNode);

			PopulateSubTree(  childRow
							, childNode
							, menu_name_field
							, menu_type_field
							, menu_full_path_field
							, menu_page_name_field
                            , menu_dir_field
                            , menu_param_field
							, expanded);
		}
	}

	private void UltraMenuExpand( string current_page
                                , string pathAndQuery
							    , UltraWebTree ultraWebTree
							    , Nodes nodesParent )
	{
		for ( int i = 0; i < nodesParent.Count; i++ )
		{
			string[] strParentNodePageTag   = nodesParent[i].Tag.ToString().Split( ';' );
			string strParentNodePageValue   = strParentNodePageTag[0].ToUpper();
            string strParentNodePageName    = strParentNodePageTag[1].ToUpper();

            // QueryString 존재 여부 체크
            if(pathAndQuery.Equals(""))
            {
                if (strParentNodePageName.Equals(current_page.ToUpper()))
			    {
				    nodesParent[i].Expand( true );
				    nodesParent[i].Selected = true;
				    return;
			    }
            }
            else 
            {
                if (strParentNodePageValue.Equals(pathAndQuery.ToUpper()))
			    {
				    nodesParent[i].Expand( true );
				    nodesParent[i].Selected = true;
				    return;
			    }
            }

            //for ( int ii = 0; ii < nodesParent[i].Nodes.Count; ii++ )
            //{
            //    string[] strNodePageTag = nodesParent[i].Nodes[ii].Tag.ToString().Split( ';' );
            //    string strNodePageValue = strNodePageTag[0];
            //    string strNodePageName  = strNodePageTag[1];

            //    // QueryString 존재 여부 체크
            //    if(pathAndQuery.Equals(""))
            //    {
            //        if (strNodePageValue.Equals(current_page))
            //        {
            //            nodesParent[i].Expand( true );
            //            nodesParent[i].Nodes[ii].Selected = true;
            //            return;
            //        }        
            //    }
            //    else 
            //    {
            //        if (strNodePageValue.Equals(pathAndQuery))
            //        {
            //            nodesParent[i].Expand( true );
            //            nodesParent[i].Nodes[ii].Selected = true;
            //            return;
            //        }
            //    }
            //}

            UltraMenuExpand(  current_page
                            , pathAndQuery
						    , ultraWebTree
						    , nodesParent[i].Nodes);
            
			// 메뉴가 Root가 없으므로 Nodes(ChildNode)를 타고 가는게 아니고
			// 이웃Node(NextNode)를 타고 감
			// nodeParent.Nodes > nodeParent.NextNode 임
//			if ( i == nodeParent.Nodes.Count - 1 )
//			{
//				UltraMenuExpand( current_page, ultraWebTree, nodeParent.NextNode );
//			}

		}
	}

    /// <summary>
    /// GetTopMenuRefID
    ///     : 현재페이지를 기초로 TOP_MENU_REF_ID를 리턴한다.
    ///     : 재귀호출로 처리
    /// </summary>
    /// <param name="asUrl"></param>
    /// <returns></returns>
    private int GetTopMenuRefID( string asUrl )
    {
        Biz_lib_MenuControl biz = new Biz_lib_MenuControl();

        int iTopMenuID      = 0;
        DataSet dsAuthMenu  = biz.GetAuthMenuInclude_N( gUserInfo.Emp_Ref_ID.ToString() );

        DataRow[] draRow;

        draRow = dsAuthMenu.Tables[0].Select(
                                                "( MENU_FULL_PATH = '" + asUrl.ToUpper() + "' ) OR ( MENU_DIR + MENU_PAGE_NAME = '"+ asUrl.ToUpper() + "' AND MENU_TYPE = 'N' )"
                                            );

        if(draRow.Length==0)
            draRow = dsAuthMenu.Tables[0].Select(
                                                    "( MENU_DIR + MENU_PAGE_NAME = '" + Request.Url.AbsoluteUri.ToUpper() + "' )"
                                                );


		foreach ( DataRow dbRow in draRow )
		{
			SearchTopMenuID( dsAuthMenu, dbRow, out iTopMenuID );
		}

		// 만약 해당메뉴가 없다면 DB에서 바로 불러옴
		// usr10001.aspx 인 경우에 해당 dsAuthMenu에 없음
		if ( iTopMenuID == 0 )
		{
			Biz_MenuInfo biz_menuinfo   = new Biz_MenuInfo();
			iTopMenuID                  = biz_menuinfo.GetUpMenuIDByMenuFullPath( asUrl );
		}

        return iTopMenuID;
    }

    private void SearchTopMenuID(DataSet dsAuthMenu, DataRow dbRow, out int oiTopMenuID)
    {
        oiTopMenuID = 0;

        if (dbRow["MENU_TYPE"].ToString() != "T")
        {
            DataRow[] draRow;

            draRow = dsAuthMenu.Tables[0].Select(
                                                "MENU_REF_ID = " + dbRow["UP_MENU_ID"].ToString()
                                                );

            foreach (DataRow drRow in draRow)
            {
                SearchTopMenuID(dsAuthMenu, drRow, out oiTopMenuID);
            }
        }
        else
        {
            oiTopMenuID = Convert.ToInt32(dbRow["MENU_REF_ID"]);
        }
    }

	private void SearchSubMenu(   DataSet dsAuthMenu
							    , string asMenuID
							    , int aiLevel
                                , ref DataTable dtRet )
    {
        if ( dsAuthMenu.Tables.Count > 0 )
        {
            DataRow drNew;
            DataRow[] draAuthMenu;
            DataTable dtAuthMenu = dsAuthMenu.Tables[0];

            draAuthMenu = dtAuthMenu.Select(
                                            "UP_MENU_ID = " + asMenuID
                                           , "MENU_PRIORITY"
                                           );

            foreach (DataRow drRow in draAuthMenu)
            {
                drNew = dtRet.NewRow();

                drNew["MENU_REF_ID"]    = Convert.ToInt32(drRow["MENU_REF_ID"]);

                if (!drRow.IsNull("UP_MENU_ID"))
                {
                    drNew["UP_MENU_ID"] = Convert.ToInt32(drRow["UP_MENU_ID"]);
                }

                drNew["MENU_NAME"]              = drRow["MENU_NAME"].ToString();
                drNew["MENU_DIR"]               = drRow["MENU_DIR"].ToString();
                drNew["MENU_PAGE_NAME"]         = drRow["MENU_PAGE_NAME"].ToString();
                drNew["MENU_PARAM"]             = drRow["MENU_PARAM"].ToString();
                drNew["MENU_FULL_PATH"]         = drRow["MENU_FULL_PATH"].ToString();
                drNew["MENU_DESC"]              = drRow["MENU_DESC"].ToString();
                drNew["MENU_PRIORITY"]          = Convert.ToInt32(drRow["MENU_PRIORITY"]);
                drNew["MENU_TYPE"]              = drRow["MENU_TYPE"].ToString();

                drNew["MENU_NAME_IMAGE_PATH"]   = drRow["MENU_NAME_IMAGE_PATH"].ToString();
                drNew["MENU_PREV_ICON_PATH"]    = drRow["MENU_PREV_ICON_PATH"].ToString();
                drNew["LEVEL"]                  = aiLevel;

                dtRet.Rows.Add(drNew);

                if (drRow["MENU_TYPE"].ToString() == "M")
                {
                    SearchSubMenu(dsAuthMenu, drRow["MENU_REF_ID"].ToString(), (aiLevel + 1), ref dtRet);
                }
            }
        }
    }

	private DataSet GetSubMenuDs( string asTopMenuID )
	{
		Biz_lib_MenuControl biz = new Biz_lib_MenuControl();

		DataSet dsReturn    = new DataSet();
		DataTable dtRet     = new DataTable();

		dtRet.Columns.Add("MENU_REF_ID", typeof(int));
		dtRet.Columns.Add("UP_MENU_ID", typeof(int));
		dtRet.Columns.Add("MENU_NAME", typeof(string));
		dtRet.Columns.Add("MENU_DIR", typeof(string));
		dtRet.Columns.Add("MENU_PAGE_NAME", typeof(string));
		dtRet.Columns.Add("MENU_PARAM", typeof(string));
		dtRet.Columns.Add("MENU_FULL_PATH", typeof(string));
		dtRet.Columns.Add("MENU_DESC", typeof(string));
		dtRet.Columns.Add("MENU_PRIORITY", typeof(int));
		dtRet.Columns.Add("MENU_TYPE", typeof(string));
		dtRet.Columns.Add("MENU_NAME_IMAGE_PATH", typeof(string));
		dtRet.Columns.Add("MENU_PREV_ICON_PATH", typeof(string));
		dtRet.Columns.Add("LEVEL", typeof(int));

		DataSet dsAuthMenu = biz.GetAuthMenu( gUserInfo.Emp_Ref_ID.ToString() );

		SearchSubMenu( dsAuthMenu, asTopMenuID, 1, ref dtRet );

		dsReturn.Tables.Add( dtRet );

		return dsReturn;
	}
}
