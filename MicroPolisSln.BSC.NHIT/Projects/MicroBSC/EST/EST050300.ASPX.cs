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
using MicroBSC.PRJ.Biz;

public partial class EST_EST050300 : EstPageBase
{
    private DataSet DS_DATAS            = null;
    private DataSet DS_DATAS_PRJ        = null;
    private DataTable DT_EST_DATA       = null;
    private DataTable DT_EST_DATA_PRJ   = null;
    private DataTable DT_EST_DETAIL     = null;
    private DataTable DT_POS_DETAIL     = null;
    private DataTable DT_MAP_PAGE_LINK  = null;


    bool IS_EST_ADMIN = false;

	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
        this.Page.FindControl("iBtnShowMenu");
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!Page.IsPostBack)
		{
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                    , WebUtility.GetIntByValueDropDownList(ddlCompID)
                                                    , "N");
            
            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnAllEst);


            //ibnAllEst.Visible = true;

            if(ibnAllEst.Visible) 
            {
                BindDiagram(  WebUtility.GetIntByValueDropDownList(ddlCompID)
                            , WebUtility.GetIntByValueDropDownList(ddlEstTermRefID)
                            , WebUtility.GetIntByValueDropDownList(ddlEstTermSubID));

                tbGrid.Visible = false;
            }
            else 
            {
                COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
                ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
                ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

                BindMyEst(    WebUtility.GetIntByValueDropDownList(ddlCompID)
                            , WebUtility.GetIntByValueDropDownList(ddlEstTermRefID)
                            , WebUtility.GetIntByValueDropDownList(ddlEstTermSubID));

                divMapMain.Visible  = false;
                ibnMyEst.Visible    = false;
            }
		}

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);


        if (this.EMP_ROLES.Contains("1")
            || this.EMP_ROLES.Contains("8")
            || this.EMP_ROLES.Contains("9"))
        {
            IS_EST_ADMIN = true;
        }


        ltrScript.Text  = "";
	}

    private void BindMyEst(int comp_id, int estterm_ref_id, int estterm_sub_id) 
    {

        int emp_ref_id = EMP_REF_ID;

        if (IS_EST_ADMIN)
        {
            emp_ref_id = 0;
        }

        Biz_Datas biz   = new Biz_Datas();
        DataSet ds      = biz.GetEstIDByTgtEmp(comp_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , emp_ref_id);

        

        DT_EST_DATA     = biz.GetEstData(comp_id
                                      , ""
                                      , estterm_ref_id
                                      , estterm_sub_id
                                      , 0
                                      , 0
                                      , 0
                                      , 0
                                      , 0).Tables[0];


        Biz_Prj_Data prjData   = new Biz_Prj_Data();
        DT_EST_DATA_PRJ        = prjData.GetPrjData(comp_id
                                                  , ""
                                                  , estterm_ref_id
                                                  , estterm_sub_id
                                                  , 0
                                                  , 0
                                                  , 0
                                                  , 0
                                                  , ""
                                                  , "").Tables[0];

        // 부서 의견상신 담당자 처리 해주는 부분
        Biz_DeptOpinionTgtEmps deptOpinionTgt   = new Biz_DeptOpinionTgtEmps();
        DataTable dataDeptOpn                   = deptOpinionTgt.GetDeptOpinionTgtEmp(COMP_ID, "").Tables[0];

        foreach(DataRow dataRowDeptOpn in dataDeptOpn.Rows) 
        {
            DataRow[] drArrEstData = DT_EST_DATA.Select(string.Format(@"COMP_ID     = {0}
                                                                    AND EST_ID      = '{1}'
                                                                    AND TGT_DEPT_ID = {2}"
                                                                , dataRowDeptOpn["COMP_ID"]
                                                                , dataRowDeptOpn["EST_ID"]
                                                                , dataRowDeptOpn["TGT_DEPT_ID"]));

            foreach(DataRow dataRow in drArrEstData) 
            {
                dataRow["TGT_EMP_ID"] = dataRowDeptOpn["TGT_EMP_ID"];
            }
        }

        Biz_MapPageLinkInfos mapPageLinkInfo = new Biz_MapPageLinkInfos();
        DT_MAP_PAGE_LINK                    = mapPageLinkInfo.GetMapPageLinks().Tables[0];

        Biz_DeptEstDetails deptEstDetail    = new Biz_DeptEstDetails();
        DT_EST_DETAIL                       = deptEstDetail.GetDeptEstDetail(comp_id, estterm_ref_id, 0, "").Tables[0];

        Biz_DeptPosDetails deptPosDetail    = new Biz_DeptPosDetails();
        DT_POS_DETAIL                       = deptPosDetail.GetDeptPosDetail(comp_id, estterm_ref_id, 0, "").Tables[0];

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

        //DataSet dtEstEmpEstTargetMap = bizEstEmpEstTargetMap.GetTgtEmp_DB(comp_id
        //                                    , estterm_ref_id
        //                                    , estterm_sub_id
        //                                    , emp_ref_id);

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }

	/// <summary>
	/// 1. 우선 테이블을 뿌리고 
	/// 2. 선을 그린다.
	/// </summary>
	private void BindDiagram(int comp_id, int estterm_ref_id, int estterm_sub_id)
	{
        Biz_Datas biz = new Biz_Datas();
        DS_DATAS      = biz.GetEstData(comp_id
                                      , ""
                                      , estterm_ref_id
                                      , estterm_sub_id
                                      , 0
                                      , 0
                                      , 0
                                      , 0
                                      , 0);


        Biz_Prj_Data prjData = new Biz_Prj_Data();
        DS_DATAS_PRJ        = prjData.GetPrjData(comp_id
                                              , ""
                                              , estterm_ref_id
                                              , estterm_sub_id
                                              , 0
                                              , 0
                                              , 0
                                              , 0
                                              , ""
                                              , "");

        Biz_MapPageLinkInfos mapPageLinkInfo    = new Biz_MapPageLinkInfos();
        DT_MAP_PAGE_LINK                        = mapPageLinkInfo.GetMapPageLinks().Tables[0];

		divMapMain.InnerHtml	    = "";

		// 레벨별로 들어옴
        DataTable dtMap			    = BizUtility.GetEstIDTree(comp_id);

		DataSet dsMap			    = new DataSet();
		dsMap.Tables.Add(dtMap);

		// Relation 걸고
		dsMap.Relations.Add("Relation", dsMap.Tables[0].Columns["EST_ID"], dsMap.Tables[0].Columns["UP_EST_ID"], false);

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
		DataRow[] drRoot			= dtMap.Select(string.Format( "LEVEL = '{0}'", intRootLevel));

		if (drRoot.Length != 0)
		{
			strTableName			= string.Format(strTableNameFormat, intRootLevel, intRootLevel);
			strRoot					= string.Format(GetRootHtml(), drRoot[0]["PADDING"], strTableName, GetRootName(drRoot[0]["EST_NAME"].ToString()), drRoot[0]["HEADER_COLOR"]);
			divMapMain.InnerHtml	+= strRoot;

			htDraw.Add(drRoot[0]["EST_ID"].ToString(), strTableName);
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
                
                string tag             = DoMaking(est_id, weight_type);
                tag                    = (tag.Length > 0) ? tag : "<br>";

                string url             = string.Format("onclick=\"ViewJobList('{0}', '{1}', '{2}', '{3}');\""
                                                     , comp_id
                                                     , est_id
                                                     , estterm_ref_id
                                                     , estterm_sub_id);

                Biz_JobEstMaps bizJob  = new Biz_JobEstMaps();
                DataSet dsJob          = bizJob.GetJobEstMap(comp_id
                                                           , est_id
                                                           , estterm_ref_id
                                                           , estterm_sub_id
                                                           , "");
                if (dsJob.Tables[0].Rows.Count > 0 && DS_DATAS.Tables[0].Select(string.Format("EST_ID = '{0}'", est_id)).Length > 0)
                {
                    if (dsJob.Tables[0].Rows.Count == DataTypeUtility.GetToInt32(dsJob.Tables[0].Compute("COUNT(STATUS_YN)", "STATUS_YN = 'Y'")))
                        header_color = "01";
                    else
                        header_color = "03";
                }

                int padding_value = DataTypeUtility.GetToInt32(drsLevel[i]["PADDING"]);

                // 레벨안의 Item의 간격 조정을 padding-left로 되며 EST_MAP_PADDING에서 Select
                divMapMain.InnerHtml += string.Format( "<td style='padding-left:{0}px'>", DataTypeUtility.GetString( drsLevel[i]["PADDING"].ToString() ) );
                divMapMain.InnerHtml += string.Format(GetItemHtml()
                                                    , strTableName
                                                    , est_name
                                                    , tag                                                   													
                                                    , header_color
                                                    , url);

				
				divMapMain.InnerHtml += "</td>";

				htDraw.Add( drsLevel[i]["EST_ID"].ToString(), strTableName );
			}

			divMapMain.InnerHtml += "</tr></table>";

			// 간격
			divMapMain.InnerHtml += string.Format("<table><tr style='height:{0}'><td></td></tr></table>", intHeight);
		}

		// 2. 선 Draw(Javascript)
		DrawMapLine( dtMap, htDraw );
	}

	protected void ibnSearch_Click( object sender, ImageClickEventArgs e )
	{
		BindDiagram(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
	}

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDiagram(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ibnAllEst.Visible)
        {
            BindDiagram(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
        }
        else
        {
            BindMyEst(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
        }
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ibnAllEst.Visible)
        {
            BindDiagram(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
        }
        else
        {
            BindMyEst(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
        }
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
        //strJs += "window.onresize = function(){DrawMapLine();};\r\n";
        //window.onresize = function(){ExcuteFnc(0);}
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

		return "";
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
			<table>
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
		string strReturn = @"
<!-- Item -->
<div id='{0}' style='position:relative;width:89;height:100%'>
    <table border='0' cellspacing='0' cellpadding='0'>
        <tr> 
            <td width='89' height='33' background='../images/org/top_img{3}.gif' class='font01' >
            <a href='#null' {4}>{1}</a>
            </td>
        </tr>
        <tr> 
            <td background='../images/org/img_bag.gif' class='font03'>
            {2}
            </td>
        </tr>
        <tr> 
            <td><img src='../images/org/bottom_img.gif' width='89' height='8'></td>
        </tr>
    </table>
</div>";

		return strReturn;
	}

    private string DoMaking(string est_id, string weight_type)
    {
        Biz_EstInfos estInfo            = new Biz_EstInfos(COMP_ID, est_id);
        StringBuilder sbReval           = new StringBuilder();
        StringBuilder sbTag             = null;

        Biz_TermStepEstMaps bizStepMaps = new Biz_TermStepEstMaps();
        DataTable dtStepMaps            = bizStepMaps.GetTermStepEstMap(COMP_ID, est_id, "N").Tables[0];

        // 평가별 차수에 의한 데이터 처리
        foreach (DataRow dataRowStep in dtStepMaps.Rows)
        {
            DataRow[] drArrEstDataByTgt_Step    = null;
            DataRow[] drArrEstDataByEst_Step    = null;
            sbTag                               = new StringBuilder();

            string est_list_str                 = "";
            string est_emp_str                  = "";
            string opinion_str                  = "";
            string feedback_str                 = "";

            int estterm_step_id                 = DataTypeUtility.GetToInt32(dataRowStep["ESTTERM_STEP_ID"]);
            
            Biz_TermSteps bizStep               = new Biz_TermSteps(COMP_ID, estterm_step_id);
            string estterm_step_name            = bizStep.EstTerm_Step_Name;

            if(estInfo.Est_Style_ID.Equals("PRJ"))
            {
                drArrEstDataByEst_Step              = DS_DATAS_PRJ.Tables[0].Select(string.Format(@"EST_ID          = '{0}' 
                                                                                                AND EST_EMP_ID      = '{1}' 
                                                                                                AND ESTTERM_STEP_ID = '{2}'"
                                                                                                 , est_id
                                                                                                 , EMP_REF_ID
                                                                                                 , estterm_step_id));

                drArrEstDataByTgt_Step              = null;
            }
            else
            {
                drArrEstDataByEst_Step              = DS_DATAS.Tables[0].Select(string.Format(@"EST_ID          = '{0}' 
                                                                                            AND EST_EMP_ID      = '{1}' 
                                                                                            AND ESTTERM_STEP_ID = '{2}'"
                                                                                             , est_id
                                                                                             , EMP_REF_ID
                                                                                             , estterm_step_id));

                drArrEstDataByTgt_Step              = DS_DATAS.Tables[0].Select(string.Format(@"EST_ID          = '{0}' 
                                                                                            AND TGT_EMP_ID      = '{1}' 
                                                                                            AND ESTTERM_STEP_ID = '{2}'"
                                                                                             , est_id
                                                                                             , EMP_REF_ID
                                                                                             , estterm_step_id));
            }

            // 평가할 대상이 존재할 경우
            if(drArrEstDataByEst_Step.Length > 0) 
            {
                // 평가대상이 완료인 갯수
                int cntStatus_Est_Emp_E = 0;

                foreach (DataRow drEstDataByStep in drArrEstDataByEst_Step)
                {
                    if(drEstDataByStep["STATUS_ID"].ToString() == "E")
                        cntStatus_Est_Emp_E++;
                }

                est_emp_str = string.Format("<a href='{2}'><font color='{3}'>평가대상</font></a>({0}/{1})"
                                            , cntStatus_Est_Emp_E
                                            , drArrEstDataByEst_Step.Length
                                            , BizUtility.GetPageLink( DT_MAP_PAGE_LINK
                                                                    , COMP_ID
                                                                    , est_id
                                                                    , "N"
                                                                    , "N"
                                                                    , "EST")
                                            , (cntStatus_Est_Emp_E == drArrEstDataByEst_Step.Length) ? "blue" : "red" );
            }

            // 의견상신한 갯수가 존재할 경우
            if (drArrEstDataByTgt_Step != null && drArrEstDataByTgt_Step.Length > 0)
            {
                // 5단계일 경우만
                if(    estInfo.Status_Style_ID.Equals("0002")
                    || estInfo.Status_Style_ID.Equals("0003")) 
                {
                    if (estInfo.Tgt_Opinion_YN.Equals("Y"))
                    {
                        // 의견상신이 완료인 갯수
                        int cntStatus_Opinion_C = 0;

                        foreach (DataRow drEstDataByStep in drArrEstDataByTgt_Step)
                        {
                            if(    drEstDataByStep["STATUS_ID"].ToString() == "C"
                                || drEstDataByStep["STATUS_ID"].ToString() == "P"
                                || drEstDataByStep["STATUS_ID"].ToString() == "E")
                                cntStatus_Opinion_C++;
                        }

                        opinion_str = string.Format("<a href='{2}'><font color='{3}'>의견상신</font></a>({0}/{1})"
                                                    , cntStatus_Opinion_C
                                                    , drArrEstDataByTgt_Step.Length
                                                    , BizUtility.GetPageLink( DT_MAP_PAGE_LINK
                                                                            , COMP_ID
                                                                            , est_id
                                                                            , "Y"
                                                                            , "N"
                                                                            , "TGT")
                                                    , (cntStatus_Opinion_C == drArrEstDataByTgt_Step.Length) ? "blue" : "red" );
                    }
                    else if (estInfo.FeedBack_YN.Equals("Y"))
                    {
                        // 피드백이 완료인 갯수
                        int cntStatus_Feedback_E = 0;

                        foreach (DataRow drEstDataByStep in drArrEstDataByTgt_Step)
                        {
                            if(drEstDataByStep["STATUS_ID"].ToString() == "E")
                                cntStatus_Feedback_E++;
                        }

                        feedback_str = string.Format("<a href='{2}'><font color='{3}'>피드백</font></a>({0}/{1})"
                                                    , cntStatus_Feedback_E
                                                    , drArrEstDataByTgt_Step.Length
                                                    , BizUtility.GetPageLink( DT_MAP_PAGE_LINK
                                                                            , COMP_ID
                                                                            , est_id
                                                                            , "N"
                                                                            , "Y"
                                                                            , "TGT")
                                                    , (cntStatus_Feedback_E == drArrEstDataByTgt_Step.Length) ? "blue" : "red" );
                    }
                }
            }

            if(estInfo.Est_Style_ID.Equals("PRJ"))
            {
                DataRow[] drArrEstData = DS_DATAS_PRJ.Tables[0].Select(string.Format( @"EST_ID          = '{0}' 
                                                                                    AND ESTTERM_STEP_ID = '{1}'"
                                                                                 , est_id
                                                                                 , estterm_step_id));
                if(drArrEstData.Length > 0) 
                {
                    int cntStatus_OwnerType_E = 0;

                    foreach (DataRow drEstData in drArrEstData)
                    {
                        if(drEstData["STATUS_ID"].ToString() == "E")
                            cntStatus_OwnerType_E++;
                    }

                    est_list_str = string.Format("<b>프로젝트</b>({0}/<b>{1}</b>)"
                                                , cntStatus_OwnerType_E
                                                , drArrEstData.Length);
                }
            }
            else
            {
                //---------------- 피평가 주체가 사원인 경우
                if(estInfo.Owner_Type.Equals("P")) 
                {
                    // 해당 차수에 평가대상 데이터
                    DataRow[] drArrEstData = DS_DATAS.Tables[0].Select(string.Format( @"EST_ID          = '{0}' 
                                                                                    AND ESTTERM_STEP_ID = '{1}'
                                                                                    AND TGT_EMP_ID      > 0"
                                                                                 , est_id
                                                                                 , estterm_step_id));
                    if(drArrEstData.Length > 0) 
                    {
                        int cntStatus_OwnerType_E = 0;

                        foreach (DataRow drEstData in drArrEstData)
                        {
                            if(drEstData["STATUS_ID"].ToString() == "E")
                                cntStatus_OwnerType_E++;
                        }

                        est_list_str = string.Format("<b>개인</b>평가({0}/<b>{1}</b>)"
                                                    , cntStatus_OwnerType_E
                                                    , drArrEstData.Length);
                    }
                }
                else if(estInfo.Owner_Type.Equals("D")) // 피평가 주체가 부서인 경우
                {
                    // 해당 차수에 평가대상 데이터
                    DataRow[] drArrEstData = DS_DATAS.Tables[0].Select(string.Format( @"EST_ID          = '{0}' 
                                                                                    AND ESTTERM_STEP_ID = '{1}'
                                                                                    AND TGT_EMP_ID      < 0"
                                                                                     , est_id
                                                                                     , estterm_step_id));
                    if(drArrEstData.Length > 0) 
                    {
                        int cntStatus_OwnerType_E = 0;

                        foreach (DataRow drEstData in drArrEstData)
                        {
                            if(drEstData["STATUS_ID"].ToString() == "E")
                                cntStatus_OwnerType_E++;
                        }

                        est_list_str = string.Format("<b>부서</b>평가({0}/<b>{1}</b>)"
                                                    , cntStatus_OwnerType_E
                                                    , drArrEstData.Length);
                    }
                }
            }

            if (   est_list_str.Length > 0
                || est_emp_str.Length  > 0
                || opinion_str.Length  > 0
                || feedback_str.Length  > 0)
            {
                sbTag.Append((estterm_step_name.Trim().Length > 0)  ? string.Format("<b>{0}</b><br>", estterm_step_name) : "");
                sbTag.Append((est_list_str.Length > 0)              ? string.Format("&nbsp;{0}<br>", est_list_str) : "");
                sbTag.Append((est_emp_str.Length > 0)               ? string.Format("&nbsp;{0}<br>", est_emp_str) : "");
                sbTag.Append((opinion_str.Length > 0)               ? string.Format("&nbsp;{0}<br>", opinion_str) : "");
                sbTag.Append((feedback_str.Length > 0)              ? string.Format("&nbsp;{0}<br>", feedback_str) : "");
            }

            sbReval.Append(sbTag.ToString());
        }

        return sbReval.ToString();
    }

    protected void ibnMyEst_Click(object sender, ImageClickEventArgs e)
    {
        BindMyEst(COMP_ID
                , ESTTERM_REF_ID
                , ESTTERM_SUB_ID);

        divMapMain.Visible  = false;
        tbGrid.Visible      = true;
    }

    protected void ibnAllEst_Click(object sender, ImageClickEventArgs e)
    {
        BindDiagram(  COMP_ID
                    , ESTTERM_REF_ID
                    , ESTTERM_SUB_ID);

        divMapMain.Visible  = true;
        tbGrid.Visible      = false;
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw         = (DataRowView) e.Data;

        COMP_ID                 = WebUtility.GetIntByValueDropDownList(ddlCompID);
        string est_id           = DataTypeUtility.GetValue(drw["EST_ID"]);

        Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, est_id);
        string weight_type      = estInfo.Weight_Type;
        string scale_type       = estInfo.Scale_Type;
        DataRow[] drArrEst      = null;
        DataRow[] drArrTgt_OPN  = null;
        DataRow[] drArrTgt_FBK  = null;

        DataTable dtArrEst      = null;

        if (estInfo.Est_Style_ID.Equals("PRJ"))
        {
            drArrEst = DT_EST_DATA_PRJ.Select(string.Format(@"EST_ID  = '{0}' 
                                                            AND EST_EMP_ID = '{1}'
                                                            AND MERGE_YN   = 'N'
                                                            AND YEAR_YN    = 'N'"
                                                             , est_id
                                                             , EMP_REF_ID));

        }
        else
        {
            if (estInfo.Est_ID.Equals("3GA"))
            {
                Biz_Datas biz = new Biz_Datas();
                DataSet ds3G = biz.Get3GAData(COMP_ID
                                            , estInfo.Est_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , EMP_REF_ID);

                if (DataTypeUtility.GetToInt32(ds3G.Tables[0].Rows[0]["TOTAL_CNT"]) == 0 && DataTypeUtility.GetToInt32(ds3G.Tables[1].Rows[0]["TOTAL_CNT"]) == 0)
                {
                    e.Row.Delete();
                }
                else
                {
                    if (DataTypeUtility.GetToInt32(ds3G.Tables[0].Rows[0]["TOTAL_CNT"]) > 0)
                        e.Row.Cells.FromKey("EST_CNT").Value = string.Format(@"<a href='/EST/EST110104.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=1&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , ds3G.Tables[0].Rows[0]["COMPLETE_Y"].ToString()
                                                                    , ds3G.Tables[0].Rows[0]["TOTAL_CNT"].ToString()
                                                                    , (ds3G.Tables[0].Rows[0]["COMPLETE_Y"].ToString() == ds3G.Tables[0].Rows[0]["TOTAL_CNT"].ToString()) ? "blue" : "red"
                                                                    , COMP_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID);

                    if (DataTypeUtility.GetToInt32(ds3G.Tables[1].Rows[0]["TOTAL_CNT"]) > 0)
                        e.Row.Cells.FromKey("OPN_CNT").Value = string.Format(@"<a href='/EST/EST110104.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=2&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , ds3G.Tables[1].Rows[0]["COMPLETE_Y"].ToString()
                                                                    , ds3G.Tables[1].Rows[0]["TOTAL_CNT"].ToString()
                                                                    , (ds3G.Tables[1].Rows[0]["COMPLETE_Y"].ToString() == ds3G.Tables[1].Rows[0]["TOTAL_CNT"].ToString()) ? "blue" : "red"
                                                                    , COMP_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID);

                    if (DataTypeUtility.GetToInt32(ds3G.Tables[2].Rows[0]["TOTAL_CNT"]) > 0)
                        e.Row.Cells.FromKey("FBK_CNT").Value = string.Format(@"<a href='/EST/EST110104.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=2&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , ds3G.Tables[2].Rows[0]["COMPLETE_Y"].ToString()
                                                                    , ds3G.Tables[2].Rows[0]["TOTAL_CNT"].ToString()
                                                                    , (ds3G.Tables[2].Rows[0]["COMPLETE_Y"].ToString() == ds3G.Tables[2].Rows[0]["TOTAL_CNT"].ToString()) ? "blue" : "red"
                                                                    , COMP_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID);
                }
            }
            else if (estInfo.Est_ID.Equals("3A"))
            {

                MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

                DataTable dtEstEmpEstTargetMap_EST = bizEstEmpEstTargetMap.GetSumFor3A_DB(COMP_ID
                                                                                    , estInfo.Est_ID
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , EMP_REF_ID
                                                                                    , 0);

                DataTable dtEstEmpEstTargetMap_Report = bizEstEmpEstTargetMap.GetSumFor3ATgtReport_DB(COMP_ID
                                                                                    , estInfo.Est_ID
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , EMP_REF_ID);

                DataTable dtEstEmpEstTargetMap_FeedBack = bizEstEmpEstTargetMap.GetSumFor3ATgtFeedBack_DB(COMP_ID
                                                                                    , estInfo.Est_ID
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , EMP_REF_ID);

                if (DataTypeUtility.GetToInt32(dtEstEmpEstTargetMap_EST.Rows[0]["TOTAL_CNT"]) == 0 && DataTypeUtility.GetToInt32(dtEstEmpEstTargetMap_Report.Rows[0]["TOTAL_CNT"]) == 0)
                {
                    e.Row.Delete();
                }
                else
                {
                    if (DataTypeUtility.GetToInt32(dtEstEmpEstTargetMap_EST.Rows[0]["TOTAL_CNT"]) > 0)
                        e.Row.Cells.FromKey("EST_CNT").Value = string.Format(@"<a href='/EST/EST110204.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=1&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , dtEstEmpEstTargetMap_EST.Rows[0]["COMPLETE_Y"].ToString()
                                                                    , dtEstEmpEstTargetMap_EST.Rows[0]["TOTAL_CNT"].ToString()
                                                                    , (dtEstEmpEstTargetMap_EST.Rows[0]["COMPLETE_Y"].ToString() == dtEstEmpEstTargetMap_EST.Rows[0]["TOTAL_CNT"].ToString()) ? "blue" : "red"
                                                                    , COMP_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID);

                    if (DataTypeUtility.GetToInt32(dtEstEmpEstTargetMap_Report.Rows[0]["TOTAL_CNT"]) > 0)
                        e.Row.Cells.FromKey("OPN_CNT").Value = string.Format(@"<a href='/EST/EST110204.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=2&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , dtEstEmpEstTargetMap_Report.Rows[0]["COMPLETE_Y"].ToString()
                                                                    , dtEstEmpEstTargetMap_Report.Rows[0]["TOTAL_CNT"].ToString()
                                                                    , (dtEstEmpEstTargetMap_Report.Rows[0]["COMPLETE_Y"].ToString() == dtEstEmpEstTargetMap_Report.Rows[0]["TOTAL_CNT"].ToString()) ? "blue" : "red"
                                                                    , COMP_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID);

                    if (DataTypeUtility.GetToInt32(dtEstEmpEstTargetMap_FeedBack.Rows[0]["TOTAL_CNT"]) > 0)
                        e.Row.Cells.FromKey("FBK_CNT").Value = string.Format(@"<a href='/EST/EST110204.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=2&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , dtEstEmpEstTargetMap_FeedBack.Rows[0]["COMPLETE_Y"].ToString()
                                                                    , dtEstEmpEstTargetMap_FeedBack.Rows[0]["TOTAL_CNT"].ToString()
                                                                    , (dtEstEmpEstTargetMap_FeedBack.Rows[0]["COMPLETE_Y"].ToString() == dtEstEmpEstTargetMap_FeedBack.Rows[0]["TOTAL_CNT"].ToString()) ? "blue" : "red"
                                                                    , COMP_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID);
                }
            }
            else
            {
                dtArrEst = DT_EST_DATA.Clone();
                drArrEst = DT_EST_DATA.Select(string.Format(@"EST_ID  = '{0}' 
                                                        AND EST_EMP_ID = '{1}'
                                                        AND MERGE_YN   = 'N'
                                                        AND YEAR_YN    = 'N'"
                                                             , est_id
                                                             , EMP_REF_ID));

                if (est_id.Equals("3N"))
                {
                    //자기평가 의견상신
                    drArrTgt_OPN = DT_EST_DATA.Select(string.Format(@"EST_ID  = '{0}' 
                                                                    AND TGT_EMP_ID      = '{1}'
                                                                    AND MERGE_YN        = 'N'
                                                                    AND YEAR_YN         = 'N'
                                                                    AND ESTTERM_STEP_ID = 2"
                                                                     , est_id
                                                                     , EMP_REF_ID));
                }
                else
                {
                    drArrTgt_OPN = DT_EST_DATA.Select(string.Format(@"EST_ID  = '{0}' 
                                                                    AND TGT_EMP_ID = '{1}'
                                                                    AND MERGE_YN   = 'N'
                                                                    AND YEAR_YN    = 'N'"
                                                                     , est_id
                                                                     , EMP_REF_ID));
                }

                drArrTgt_FBK = DT_EST_DATA.Select(string.Format(@"EST_ID       = '{0}' 
                                                        AND TGT_EMP_ID      = '{1}'
                                                        AND MERGE_YN        = 'N'
                                                        AND YEAR_YN         = 'N'
                                                        AND DIRECTION_TYPE  = 'DN'"
                                                             , est_id
                                                             , EMP_REF_ID));
            }
        }

        if (estInfo.Est_ID != "3GA" && estInfo.Est_ID != "3A")
        {
            int est_end_cnt = 0;
            int est_all_cnt = drArrEst.Length;
            int opn_end_cnt = 0;
            int opn_all_cnt = 0;
            int fbk_end_cnt = 0;
            int fbk_all_cnt = 0;

            string tgt_send_type = BizUtility.GetTgtSendType(estInfo.Tgt_Opinion_YN, estInfo.FeedBack_YN);

            foreach (DataRow dataRowEst in drArrEst)
            {
                if (dataRowEst["STATUS_ID"].ToString() == "C") // 평가완료가 평가자 입장에서 완료
                    est_end_cnt++;
            }

            if (tgt_send_type.Equals("OPN"))
            {
                foreach (DataRow dataRowTgt in drArrTgt_OPN)
                {
                    if (est_id.Equals("3N"))
                    {
                        Biz_EstInfos bizEstInfo = new Biz_EstInfos(COMP_ID, est_id);
                        string status_style_id = bizEstInfo.Status_Style_ID;

                        string status_id = dataRowTgt["STATUS_ID"].ToString();
                        Biz_Status bizStatus = new Biz_Status(status_id, status_style_id);

                        if (DataTypeUtility.GetToInt32(bizStatus.Seq) > 2)//자기평가중 상태보다 높으면
                            opn_end_cnt++;
                    }
                    else
                    {
                        if (dataRowTgt["STATUS_ID"].ToString() == "E")
                            opn_end_cnt++;
                    }
                }

                opn_all_cnt = drArrTgt_OPN.Length;
            }
            else if (tgt_send_type.Equals("FBK"))
            {
                foreach (DataRow dataRowTgt in drArrTgt_FBK)
                {
                    if (dataRowTgt["STATUS_ID"].ToString() == "E")
                        fbk_end_cnt++;
                }

                fbk_all_cnt = drArrTgt_FBK.Length;
            }

            string pageid = string.Empty;

            if (est_end_cnt > 0 || est_all_cnt > 0)
            {
                if (est_id.Equals("3N"))
                {
                    for (int i = 0; i < drArrEst.Length; i++)
                    {
                        dtArrEst.ImportRow(drArrEst[i]);
                    }

                    dtArrEst = DataTypeUtility.FilterSortDataTable(dtArrEst, null, "ESTTERM_STEP_ID ASC");

                    pageid = string.Format("/EST/EST110500.ASPX?ESTTERM_STEP_ID={0}", DataTypeUtility.GetString(dtArrEst.Rows[0]["ESTTERM_STEP_ID"]));

                    e.Row.Cells.FromKey("EST_CNT").Value = string.Format(@"<a href='{2}'>
                                                                                <font color='{3}'>{0}</font> <font color='black'>/ {1}</font>
                                                                            </a>"
                                                                    , est_end_cnt
                                                                    , est_all_cnt
                                                                    , pageid
                                                                    , (est_end_cnt == est_all_cnt) ? "blue" : "red");
                }
                else
                //if(est_id.Equals("3A"))
                //{
                //    e.Row.Cells.FromKey("EST_CNT").Value = string.Format(@"<a href='/EST/EST110204.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=1&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                //                                                    , est_end_cnt
                //                                                    , est_all_cnt
                //                                                    , est_end_cnt == est_all_cnt ? "blue" : "red"
                //                                                    , COMP_ID
                //                                                    , ESTTERM_REF_ID
                //                                                    , ESTTERM_SUB_ID);
                //}
                //else
                {
                    pageid = BizUtility.GetPageLink(DT_MAP_PAGE_LINK
                                                                                            , COMP_ID
                                                                                            , est_id
                                                                                            , "N"
                                                                                            , "N"
                                                                                            , "EST");

                    if (est_id.Equals("3Q"))
                        pageid += "&EST_TGT_TYPE=EST";


                    e.Row.Cells.FromKey("EST_CNT").Value = string.Format(@"<a href='{2}'><font color='{3}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , est_end_cnt
                                                                    , est_all_cnt
                                                                    , pageid
                                                                    , (est_end_cnt == est_all_cnt) ? "blue" : "red");
                }
            }

            if (opn_end_cnt > 0 || opn_all_cnt > 0)
            {
                if (est_id.Equals("3N"))
                {
                    pageid = "/EST/EST110500.ASPX?ESTTERM_STEP_ID=2&EST_TGT_TYPE=TGT";

                    e.Row.Cells.FromKey("OPN_CNT").Value = string.Format(@"<a href='{2}'>
                                                                                <font color='{3}'>{0}</font> <font color='black'>/ {1}</font>
                                                                            </a>"
                                                                    , opn_end_cnt
                                                                    , opn_all_cnt
                                                                    , pageid
                                                                    , (opn_end_cnt == opn_all_cnt) ? "blue" : "red");
                }
                else
                //if(est_id.Equals("3A"))
                //{
                //    e.Row.Cells.FromKey("EST_CNT").Value = string.Format(@"<a href='/EST/EST110204.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=2&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                //                                                    , opn_end_cnt
                //                                                    , opn_all_cnt
                //                                                    , opn_end_cnt == opn_all_cnt ? "blue" : "red"
                //                                                    , COMP_ID
                //                                                    , ESTTERM_REF_ID
                //                                                    , ESTTERM_SUB_ID);
                //}
                //else
                {
                    pageid = BizUtility.GetPageLink(DT_MAP_PAGE_LINK
                                                                                            , COMP_ID
                                                                                            , est_id
                                                                                            , "Y"
                                                                                            , "N"
                                                                                            , "TGT");

                    e.Row.Cells.FromKey("OPN_CNT").Value = string.Format(@"<a href='{2}'><font color='{3}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , opn_end_cnt
                                                                    , opn_all_cnt
                                                                    , pageid
                                                                    , (opn_end_cnt == opn_all_cnt) ? "blue" : "red");
                }

                
            }

            if (fbk_end_cnt > 0 || fbk_all_cnt > 0)
            {
                //if(est_id.Equals("3A"))
                //{
                //    e.Row.Cells.FromKey("EST_CNT").Value = string.Format(@"<a href='/EST/EST110204.ASPX?COMP_ID={3}&ESTTERM_REF_ID={4}&ESTTERM_SUB_ID={5}&USERTYPE=2&'><font color='{2}'>{0}</font> <font color='black'>/ {1}</font></a>"
                //                                                    , fbk_end_cnt
                //                                                    , fbk_all_cnt
                //                                                    , fbk_end_cnt == fbk_all_cnt ? "blue" : "red"
                //                                                    , COMP_ID
                //                                                    , ESTTERM_REF_ID
                //                                                    , ESTTERM_SUB_ID);
                //}
                //else
                {
                    pageid = BizUtility.GetPageLink(DT_MAP_PAGE_LINK
                                                                                            , COMP_ID
                                                                                            , est_id
                                                                                            , "N"
                                                                                            , "Y"
                                                                                            , "TGT");

                    e.Row.Cells.FromKey("FBK_CNT").Value = string.Format(@"<a href='{2}'><font color='{3}'>{0}</font> <font color='black'>/ {1}</font></a>"
                                                                    , fbk_end_cnt
                                                                    , fbk_all_cnt
                                                                    , pageid
                                                                    , (fbk_end_cnt == fbk_all_cnt) ? "blue" : "red");
                }
            }

            if (weight_type.Equals("DPT"))
            {

            }
            else if (weight_type.Equals("POS"))
            {

            }
        }
    }
}
