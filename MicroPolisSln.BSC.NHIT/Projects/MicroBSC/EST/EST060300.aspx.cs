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

using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

using MicroBSC.Estimation.Biz;

public partial class EST_EST060300 : EstPageBase
{
    private DataSet DS_DETAIL;

	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if ( IsPostBack == false )
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm( ddlEstTermInfo );
            TreeViewCommom.BindDept(TreeView1
                                     , false
                                     , TreeNodeSelectAction.Select
                                     , null);

			//BindMap();
		}

        COMP_ID        = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        ltrScript.Text = "";
	}

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        Biz_DeptEstDetails biz = new Biz_DeptEstDetails();
        DS_DETAIL              = biz.GetDeptEstDetail(COMP_ID
                                                    , ESTTERM_REF_ID
                                                    , DataTypeUtility.GetToInt32(TreeView1.SelectedNode.Value)
                                                    , "");


        BindMap();
    }

	/// <summary>
	/// 1. 우선 테이블을 뿌리고 
	/// 2. 선을 그린다.
	/// </summary>
	private void BindMap()
	{
		divMapMain.InnerHtml	= string.Empty;

		// 레벨별로 들어옴
		DataTable dtMap			= BizUtility.GetEstIDTree(COMP_ID);
		DataSet dsMap			= new DataSet();
		dsMap.Tables.Add( dtMap );

		// Relation 걸고
		dsMap.Relations.Add( "Relation", dsMap.Tables[0].Columns["EST_ID"], dsMap.Tables[0].Columns["UP_EST_ID"], false );

		// 선그리기용 HashTable --- EST_ID + TableName
		// 테이블의명을 알아야 선을 그릴 수 있으므로 테이블명을 저장하는 HashTable이 필요함.
		Hashtable htDraw			= new Hashtable();

		string strRootTableName		= string.Empty;
		string strTableName			= string.Empty;
		string strTableNameFormat	= "div_{0}_{1}";

		string strRoot				= string.Empty;
		strRootTableName			= strTableName;

		int intRootLevel			= 0;

		// 레벨별 간격
		int intHeight				= 15;

		// Root
		// Root 레벨도 일반 레벨과 크게 다른점 없이 Loop로 돌리면 되지만 Root에서
		// 차후에 유지/보수할 내용이 있을 것 같아서 따로 처리했음
		// GetRootHtml() 
		DataRow[] drRoot			= dtMap.Select( string.Format( "LEVEL = '{0}'", intRootLevel.ToString() ) );

		if ( drRoot.Length != 0 )
		{
			strTableName			= string.Format( strTableNameFormat, intRootLevel.ToString(), intRootLevel.ToString() );
			strRoot					= string.Format( GetRootHtml(), drRoot[0]["PADDING"].ToString(), strTableName, GetRootName( drRoot[0]["EST_NAME"].ToString() ), drRoot[0]["HEADER_COLOR"].ToString() );
			divMapMain.InnerHtml	+= strRoot;

			htDraw.Add( drRoot[0]["EST_ID"].ToString(), strTableName );
		}

		// 간격
		divMapMain.InnerHtml		+= string.Format( "<table><tr style='height:{0}'><td></td></tr></table>", intHeight.ToString() );

		// Root를 제외한 레벨DataTable
		DataTable dtLevel			= DataTypeUtility.GetGroupByDataTable( dtMap, new string[] { "LEVEL" } );
		DataView dvLevel1Over		= dtLevel.DefaultView;
		dvLevel1Over.RowFilter		= string.Format( "LEVEL >= {0}", ( intRootLevel + 1 ).ToString() );
		dvLevel1Over.Sort			= "LEVEL";

		// 레벨별로 처리했음
		// 각 레벨별로 <tr><td><table>로 생성됨
		for ( int j = 0; j < dvLevel1Over.Count; j++ )
		{
			int intCurrentLevel		= DataTypeUtility.GetToInt32( dvLevel1Over[j]["LEVEL"] );
			DataRow[] drsLevel		= dtMap.Select( string.Format( "LEVEL = '{0}'", intCurrentLevel.ToString() ) );

			divMapMain.InnerHtml	+= "<table border='0'><tr>";
			for ( int i = 0; i < drsLevel.Length; i++ )
			{
				strTableName           = string.Format( strTableNameFormat, intCurrentLevel, i.ToString() );
                string est_name        = GetRootName( drsLevel[i]["EST_NAME"].ToString());
                string est_id          = drsLevel[i]["EST_ID"].ToString();
				string status_style_id = GetItemName( drsLevel[i]["STATUS_STYLE_ID"].ToString());
	            string est_sche_name   = GetItemName( drsLevel[i]["EST_SCHE_NAME"].ToString() );													
				string header_color    = "05";
                string weight_type     = drsLevel[i]["WEIGHT_TYPE"].ToString();

                string weight          = string.Empty;
                string weight_name     = string.Empty;
                string scale_name      = GetScaleName(est_id);

                //if (!scale_name.Equals("-"))
                //{
                    weight_name = GetWeightName(est_id, weight_type, ref weight);

                    if (!weight.Equals("") && !scale_name.Equals(""))
                    {
                        header_color = "01";
                    }
                    else if (!weight.Equals("") || !scale_name.Equals(""))
                    {                        
                        header_color = "03";
                    }
                //}
                //else
                //    scale_name = scale_name.Equals("-") ? "<center>" + scale_name + "</center>" : scale_name;
                

				// 레벨안의 Item의 간격 조정을 padding-left로 되며 EST_MAP_PADDING에서 Select
				divMapMain.InnerHtml += string.Format( "<td style='padding-left:{0}px'>", DataTypeUtility.GetString( drsLevel[i]["PADDING"].ToString() ) );
				divMapMain.InnerHtml += string.Format(GetItemHtml()
													, strTableName
													, est_name
                                                    , (scale_name.Replace("&nbsp","").Trim().Equals("")) ? "" : scale_name + "<br>"
                                                    , weight_name
													, header_color);
				divMapMain.InnerHtml += "</td>";

				htDraw.Add( est_id, strTableName );
			}
			divMapMain.InnerHtml += "</tr></table>";

			// 간격
			divMapMain.InnerHtml += string.Format( "<table><tr style='height:{0}'><td></td></tr></table>", intHeight.ToString() );
		}

		// 2. 선 Draw(Javascript)
		DrawMapLine( dtMap, htDraw );
	}

	protected void ibnSearch_Click( object sender, ImageClickEventArgs e )
	{
		BindMap();
	}

    private string GetScaleName(string est_id)
    {
        //if(est_id.Equals("3B")) 
        //    System.Diagnostics.Debugger.Break();

        Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, est_id);

        string scale_id         = string.Empty;
        string scale_name       = "";

        if(estInfo.Scale_Type.Equals("DPT")) 
        {
            DataRow[] rows     = DS_DETAIL.Tables[0].Select(string.Format(" EST_ID = '{0}' ", est_id));

            if (rows.Length > 0)
            {
                scale_id = rows[0]["SCALE_ID"].ToString();

                if (scale_id.Equals("ABS"))
                {
                    scale_name = "<b>절대평가</b>";
                }
                else if (scale_id.Equals("REL"))
                {
                    string temp           = string.Empty;
                    Biz_RelGroupInfos biz = new Biz_RelGroupInfos();
                    DataSet ds            = biz.GetRelGroupInfo(COMP_ID, "", est_id, ESTTERM_REF_ID);

                    StringBuilder sbTemp  = new StringBuilder();
                    int cnt               = 0;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cnt++;
                        temp = string.Format("<a href='#' onclick=ViewEmpList('{0}','{1}','{2}','{3}')>{4}</a>"
                                             ,COMP_ID
                                             ,est_id
                                             ,ESTTERM_REF_ID
                                             ,row["REL_GRP_ID"].ToString()
                                             ,row["REL_GRP_NAME"].ToString());

                        sbTemp.Append("<br>&nbsp;" + cnt.ToString() + ". " + temp);
                    }

                    temp = (temp.Length > 0) ? temp.Remove(temp.Length - 1, 1) : string.Empty;

                    scale_name = "<b>상대평가</b>" + sbTemp.ToString();
                }
            }
        }
        else if(estInfo.Scale_Type.Equals("POS")) 
        {
            Biz_DeptPosScales deptPosScale  = new Biz_DeptPosScales();
            DataSet ds                      = deptPosScale.GetDeptPosScale(   COMP_ID
                                                                             ,ESTTERM_REF_ID
                                                                             ,DataTypeUtility.GetToInt32(TreeView1.SelectedNode.Value)
                                                                             ,est_id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                scale_name      = "";
                bool isFirst    = true;

                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    string no       = "&nbsp;" + row["SEQ"].ToString() + "." ;

                    string pos_id   = GetPosName(row["POS_ID"].ToString(), row["POS_VALUE"].ToString());
                    string temp     = "<b>" + row["SCALE_NAME"].ToString().Replace("평가", "") + "</b>";

                    if(isFirst) 
                    {
                        scale_name     += no + pos_id + temp;
                        isFirst        = false;
                    }
                    else 
                    {
                        scale_name     += "<br>" + no + pos_id + temp;
                    }
                }
            }
            else
            {
                scale_name = "&nbsp;-";
            }
        }

        return scale_name;
    }

    private string GetWeightName(string est_id, string weight_type, ref string weight)
    {
        string reVal       = "<b>가중치</b><br>";
        string weight_name = string.Empty;

        if (weight_type.Equals("DPT"))
        {
            DataRow[] rows = DS_DETAIL.Tables[0].Select(string.Format(" EST_ID = '{0}' ", est_id));

            if (rows.Length > 0)
            {
                weight = (rows[0]["WEIGHT"].ToString().Equals("")) ? "" : rows[0]["WEIGHT"].ToString();
            }
            else
            {
                weight = "";
            }

            if(weight.Equals(""))
                weight_name = "";
            else
                weight_name = "&nbsp;부서:" + weight + "%";
        }
        else if (weight_type.Equals("POS"))
        {
            Biz_DeptPosDetails biz = new Biz_DeptPosDetails();
            DataSet ds             = biz.GetDeptPosDetail(COMP_ID
                                                         ,ESTTERM_REF_ID
                                                         ,DataTypeUtility.GetToInt32(TreeView1.SelectedNode.Value)
                                                         ,est_id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    string no       = "&nbsp;" + row["SEQ"].ToString() + "." ;
                    string pos_id   = GetPosName(row["POS_ID"].ToString(), row["POS_VALUE"].ToString());
                    weight = (row["WEIGHT"].ToString().Equals("")) ? "" : row["WEIGHT"].ToString() + "%" + "<br>";

                    weight_name  += no + pos_id + weight;
                }
            }
            else
            {
                weight_name = "";
            }
        }

        reVal += weight_name;

        if(reVal.Equals("<b>가중치</b><br>"))
            return "";

        return reVal;
    }

    private string GetPosName(string pos_id, string pos_value)
    {
        string reVal = string.Empty;

        if (pos_id.Equals("CLS"))
        {
            Biz_PositionClasses biz = new Biz_PositionClasses(pos_value);
            reVal = biz.Pos_Cls_Name + ":";
        }
        else if (pos_id.Equals("DUT"))
        {
            Biz_PositionDutys biz = new Biz_PositionDutys(pos_value);
            reVal = biz.Pos_Dut_Name + ":";
        }
        else if (pos_id.Equals("GRP"))
        {
            Biz_PositionGroups biz = new Biz_PositionGroups(pos_value);
            reVal = biz.Pos_Grp_Name + ":";
        }
        else if (pos_id.Equals("RNK"))
        {
            Biz_PositionRanks biz = new Biz_PositionRanks(pos_value);
            reVal = biz.Pos_Rnk_Name + ":";
        }

        return reVal;
    }
    
	/// <summary>
	/// 계층선 그리기는 Tree Loop를 돌려서 상위노드, 처음노드, 마지막노드로 DrawLevelLine( 상위노드, 처음노드, 마지막노드 ) 으로 그린 후
	/// 그 외에 노드(처음노드와 마지막노드 사이에 있는 노드들)는 윗선만 그리면 되므로 배열에 넣어서 따로 그린다.
	/// </summary>
	private void DrawMapLine( DataTable dtMap, Hashtable htDraw )
	{
		List<string[]> listUpperLine	= new List<string[]>();

		string strParentNode			= string.Empty;
		string strFirstNode				= string.Empty;
		string strLastNode				= string.Empty;

		string strJsFunction	= string.Empty;
		string strJs			= "<script>\r\n";
		strJs 					+= "var jg = new jsGraphics( 'divMapMain' );\r\n";
		strJs 					+= "jg.setColor( '#006A92' );\r\n";
		strJs 					+= "jg.setStroke( 1 );\r\n\r\n";

		foreach ( DataRow drItem in dtMap.Rows )
		{
			strParentNode	= string.Empty;
			strFirstNode	= string.Empty;
			strLastNode		= string.Empty;

			if ( drItem.GetChildRows( "Relation" ).Length == 0 )
				continue;

			strParentNode	= htDraw[drItem["EST_ID"].ToString()].ToString();

			DataRow[] drItemm = drItem.GetChildRows( "Relation" );
			for( int i = 0; i < drItemm.Length; i++ )
			{
				// 처음노드
				if ( i == 0 )
				{
					strFirstNode	= htDraw[drItemm[i]["EST_ID"].ToString()].ToString();
				}
				// 마지막노드
				else if ( i == drItemm.Length - 1 )
				{
					strLastNode		= htDraw[drItemm[i]["EST_ID"].ToString()].ToString();
				}
				// 중간에 있는 노드들
				else
				{
					listUpperLine.Add( new string[] { strParentNode, htDraw[drItemm[i]["EST_ID"].ToString()].ToString() } );
				}
			}

			if ( strParentNode.Length != 0 && strFirstNode.Length != 0 && strLastNode.Length != 0 )
			{
				strJsFunction	+= string.Format( "DrawLevelLine( '{0}', '{1}', '{2}', jg );\r\n"
													, strParentNode
													, strFirstNode
													, strLastNode );
			}
			// 부모 - 자식 수직선
			// 부모노드 - 자식노드(2개이상의 노드 - 처음노드, 마지막노드) 들도 구성되지 않고
			// 단순히 부모-자식 노드 1개씩으로만 구성되어 있을때에는 수직선만 그리면 되므로 DrawVerticalLine() 사용
			else if ( strParentNode.Length != 0 && strFirstNode.Length != 0 && strLastNode.Length == 0 )
			{
				strJsFunction	+= string.Format( "DrawVerticalLine( '{0}', '{1}', jg );\r\n"
													, strParentNode
													, strFirstNode );
			}
		}

		for ( int i = 0; i < listUpperLine.Count; i++ )
		{
			strJsFunction		+= string.Format( "DrawUpperLine( '{0}', '{1}', jg );\r\n"
												, listUpperLine[i][0]
												, listUpperLine[i][1] );
		}

		// SetTimeout용 함수 - js:DrawMapLine()
		// 클라이언트에서 그리는 것이므로 테이블이 뿌려진 후에 그려야 하므로 1초 뒤에 그리는 것으로 설정(setTimeout())
		strJs += "function DrawMapLine()\r\n";
		strJs += "{\r\n";
		strJs += strJsFunction;
		strJs += "}\r\n";
		strJs += "window.setTimeout( 'DrawMapLine()', 1000 );\r\n";
		strJs += "</script>";

		ClientScript.RegisterStartupScript( typeof( string ), "DrawMapLine", strJs );
	}

	/// <summary>
	/// Root명 설정
	/// 줄바꿈 : 9자 이상이면 4번째글자에서 <BR>매김
	/// </summary>
	private string GetRootName( string strOrg )
	{
		int intLimit = 9;

		if ( strOrg.Length >= intLimit )
		{
			strOrg = strOrg.Substring( 0, 4 ) + "<br>" + strOrg.Substring( 4 );
		}

		return strOrg;
	}

	/// <summary>
	/// 날짜설정
	/// 줄바꿈 : 데이타 있으면 앞에 <br> 설정
	/// </summary>
	private string GetDateTime( string strDateTime )
	{
		if ( strDateTime.Length > 0 )
		{
			return "<br>" + DataTypeUtility.GetToDateTime( strDateTime ).ToString( "yyyy-MM-dd" );
		}

		return strDateTime;
	}

	/// <summary>
	/// Loop 도는 Item명 설정
	/// 줄바꿈 : 데이타 있으면 앞에 <br> 설정
	/// </summary>
	private string GetItemName( string strItemName )
	{
		if ( strItemName.Length > 0 )
		{
			return "<br>" + strItemName;
		}

		return string.Empty;
	}

	/// <summary>
	/// 디자인 보기 편하게 하기 위해서 string.format() 으로 처리하였음.
	/// {0}padding {1}테이블명 {2}Root명 {3}HeaderColor
	/// div안에 테이블이 있는 형식
	/// <div id="테이블명">
	///		<table></table>
	/// </div>
	/// </summary>
	private string GetRootHtml()
	{
		string strRoot = 
		@"<!-- ROOT -->
			<table width='100%'>
				<tr>
					<td style='padding-left:{0}px'>
						<div id='{1}' style='position:relative;width:93px;height:100%'>

							<table width='93' height='38' border='0' cellspacing='0' cellpadding='0'>
								<tr> 
									<td background='../images/org/img{3}.gif' class='font01'>{2}</td>
								</tr>
							</table>

						</div>
					</td>
				</tr>
			</table>";

		return strRoot;
	}

	/// <summary>
	/// 디자인 보기 편하게 하기 위해서 string.format() 으로 처리하였음.
	/// div안에 테이블이 있는 형식
	/// <div id="테이블명">
	///		<table></table>
	/// </div>
	/// {0}테이블명 {1}Root명 {2}EST_ID {3}STYLE {4}EST_SCHE_NAME {5}START_DATE {6}END_DATE {7}HeaderColor
	/// </summary>
	private string GetItemHtml()
	{
		string strReturn =
            @"<!-- Item -->
				<div id='{0}' style='position:relative;width:89;height:100%'>

					<table border='0' cellspacing='0' cellpadding='0'>
						<tr> 
							<td width='89' height='33' background='../images/org/top_img{4}.gif' class='font01'>{1}</td>
						</tr>
						<tr> 
							<td background='../images/org/img_bag.gif' class='font03'>
                            {2}
                            {3}&nbsp;
                            </td>
						</tr>
						<tr> 
							<td><img src='../images/org/bottom_img.gif' width='89' height='8'></td>
						</tr>
					</table>

				</div>";

		return strReturn;
	}

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeViewCommom.BindDept(TreeView1
                                 , false
                                 , TreeNodeSelectAction.Select
                                 , null);
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeViewCommom.BindDept(TreeView1
                                 , false
                                 , TreeNodeSelectAction.Select
                                 , null);
    }
}
