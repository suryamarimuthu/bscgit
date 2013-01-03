using System;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.BSC.Biz;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

public class DropDownListCommom
{
    /// <summary>
    /// 바인딩이 되기 전에 기본값 세팅
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="defaultText"></param>
    /// <param name="defaultValue"></param>
    public static void BindDefaultValue(DropDownList ddl, string defaultText, string defaultValue) 
    {
        ListItem item = new ListItem(defaultText, defaultValue);
        ddl.Items.Insert(0, item);
    }

    /// <summary>
    /// 회사 코드 바인딩
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="lbl"></param>
    public static void BindComp(DropDownList ddl, Label lbl)
    {
        Biz_DeptInfos deptInfo  = new Biz_DeptInfos();
        DataSet ds              = deptInfo.GetCompID();
        ddl.DataSource          = ds;
        ddl.DataTextField       = "DEPT_NAME";
        ddl.DataValueField      = "DEPT_REF_ID";
        ddl.DataBind();

        if(ds.Tables[0].Rows.Count == 0) 
        {
            lbl.Text        = "등록되어 있는 회사 코드가 없습니다.";
            lbl.ForeColor   = Color.FromKnownColor(KnownColor.Red);
            ddl.Visible     = false;
        }
        else if(ds.Tables[0].Rows.Count == 1) 
        {
            lbl.Visible = false;
            ddl.Visible = false;
        }
        else
        {
            lbl.Text        = "회사명 : ";
        }
    }

    /// <summary>
    /// 평가유형 
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="style_id"></param>
    public static void BindEstStyle(DropDownList ddl, int comp_id, string est_style_id)
    {
        Biz_EstInfos bizEstInfos = new Biz_EstInfos();

        DataTable dtEstInfos = bizEstInfos.GetEstInfo(comp_id, "").Tables[0];

        DataRow[] rows = dtEstInfos.Select(string.Format(" EST_STYLE_ID = '{0}' ", est_style_id), " EST_NAME ");

        if (rows.Length > 0)
        {
            foreach (DataRow row in rows)
            {
                ddl.Items.Add(new ListItem(DataTypeUtility.GetValue(row["EST_NAME"]), DataTypeUtility.GetValue(row["EST_ID"])));
            }
        }
        else
        {
            ddl.Items.Insert(0, new ListItem("-", "-"));
        }
    }

    /// <summary>
    /// 평가기간 
    /// </summary>
    /// <param name="ddl"></param>
    public static void BindEstTerm(DropDownList ddl)
    {
        TermInfos term          = new TermInfos();
        DataSet ds              = term.GetAllList();
        ddl.DataSource          = ds;
        ddl.DataTextField       = "ESTTERM_NAME";
        ddl.DataValueField      = "ESTTERM_REF_ID";
        ddl.DataBind();

        // 배포되어있는 평가월의 평가기간을 가져온다
        Biz_Bsc_Term_Detail objTD = new Biz_Bsc_Term_Detail();
        ddl.ClearSelection();

        if(ddl.Items.FindByValue(objTD.GetOpenEstTermID().ToString()) != null)
            ddl.Items.FindByValue(objTD.GetOpenEstTermID().ToString()).Selected = true;
    }

    /// <summary>
    /// 평가 주기
    /// </summary>
    /// <param name="ddl"></param>
    public static void BindEstTermSub( DropDownList ddl, int comp_id)
	{
		Biz_TermSubs termSubs               = new Biz_TermSubs();
		DataSet ds	                        = termSubs.GetTermSubs(comp_id, "Y");
        ddl.DataTextField                   = "ESTTERM_SUB_NAME";
        ddl.DataValueField                  = "ESTTERM_SUB_ID";
        ddl.DataSource                      = ds;
        ddl.DataBind();
	}

    /// <summary>
    /// 평가 주기
    /// </summary>
    /// <param name="ddl"></param>
    public static void BindEstTermSubByYearYN( DropDownList ddl, int comp_id, string year_yn)
	{
		Biz_TermSubs termSubs               = new Biz_TermSubs();
		DataSet ds	                        = termSubs.GetTermSubByYearYN(comp_id, year_yn);
        ddl.DataTextField                   = "ESTTERM_SUB_NAME";
        ddl.DataValueField                  = "ESTTERM_SUB_ID";
        ddl.DataSource                      = ds;
        ddl.DataBind();
	}

    /// <summary>
    /// 평가별 주기
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="est_id"></param>
    public static void BindEstTermSub( DropDownList ddl, int comp_id, string est_id, string year_yn)
	{
		Biz_TermSubEstMaps termSubEstMap    = new Biz_TermSubEstMaps();
		DataSet ds	                        = termSubEstMap.GetTermSubEstMap(comp_id, est_id, year_yn);
        ddl.DataTextField                   = "ESTTERM_SUB_NAME";
        ddl.DataValueField                  = "ESTTERM_SUB_ID";
        ddl.DataSource                      = ds;
        ddl.DataBind();

        if(ds.Tables[0].Rows.Count == 0)
		{
		    ddl.Style.Add("display", "none");
		}
		else
		{
		    ddl.Style.Remove("display");
		}

        //if(ds.Tables[0].Rows.Count == 1) 
        //{
        //    ddl.Visible = false;
        //}
        //else 
        //{
        //    ddl.Visible = false;
        //}
	}

    /// <summary>
    /// 평가 차수
    /// </summary>
    /// <param name="ddl"></param>
	public static void BindEstTermStep( DropDownList ddl, int comp_id)
	{
		Biz_TermSteps termStep              = new Biz_TermSteps();
		DataSet ds	                        = termStep.GetTermSteps(comp_id, "Y");
        ddl.DataTextField                   = "ESTTERM_STEP_NAME";
        ddl.DataValueField                  = "ESTTERM_STEP_ID";
        ddl.DataSource                      = ds;
        ddl.DataBind();

        //if(ds.Tables[0].Rows.Count == 1) 
        //{
        //    ddl.Visible = false;
        //}
        //else 
        //{
        //    ddl.Visible = false;
        //}
	}

    /// <summary>
    /// 평가별 차수
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="est_id"></param>
    public static void BindEstTermStep(DropDownList ddl
                                    , int comp_id
                                    , string est_id
                                    , string fixed_weight_yn)
	{
		Biz_TermStepEstMaps termStepEstMap  = new Biz_TermStepEstMaps();
		DataSet ds	                        = termStepEstMap.GetTermStepEstMap(comp_id, est_id, fixed_weight_yn);
        ddl.DataTextField                   = "ESTTERM_STEP_NAME";
        ddl.DataValueField                  = "ESTTERM_STEP_ID";
        ddl.DataSource                      = ds;
        ddl.DataBind();

        //if(ds.Tables[0].Rows.Count == 1) 
        //{
        //    ddl.Visible = false;
        //}
        //else 
        //{
        //    ddl.Visible = false;
        //}
	}

    /// <summary>
    /// 평가별 차수
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="est_id"></param>
    public static void BindEstTermStep(DropDownList ddl
                                    , int comp_id
                                    , string est_id)
	{
		Biz_TermStepEstMaps termStepEstMap  = new Biz_TermStepEstMaps();
		DataSet ds	                        = termStepEstMap.GetTermStepEstMap(comp_id, est_id);
        ddl.DataTextField                   = "ESTTERM_STEP_NAME";
        ddl.DataValueField                  = "ESTTERM_STEP_ID";
        ddl.DataSource                      = ds;
        ddl.DataBind();

        //if(ds.Tables[0].Rows.Count == 1) 
        //{
        //    ddl.Visible = false;
        //}
        //else 
        //{
        //    ddl.Visible = false;
        //}
	}

	/// <summary>
	/// 예 / 아니오
	/// </summary>
    public static void BindYN( DropDownList ddl )
    {
		ddl.Items.Insert( 0, new ListItem( "예", "Y" ) );
		ddl.Items.Insert( 1, new ListItem( "아니오", "N" ) );
    }

	/// <summary>
	/// 개인 / 부서
	/// </summary>
	public static void BindEstimate( DropDownList ddl )
	{
		ddl.Items.Insert( 0, new ListItem( "개인", "P" ) );
		ddl.Items.Insert( 1, new ListItem( "부서", "D" ) );
	}

    ///// <summary>
    ///// 개인 / 부서
    ///// </summary>
    //public static void BindEstimate( DropDownList ddl )
    //{
    //    ddl.Items.Insert( 0, new ListItem( "개인", "P" ) );
    //    ddl.Items.Insert( 1, new ListItem( "부서", "D" ) );
    //}

	/// <summary>
	/// 사용 / 미사용
	/// </summary>
	public static void BindUseYN( DropDownList ddl )
	{
		ddl.Items.Insert( 0, new ListItem( "사용", "Y" ) );
		ddl.Items.Insert( 1, new ListItem( "미사용", "N" ) );
	}

    public static void BindDashBoardType(DropDownList ddl)
    {
        ddl.Items.Insert(0, new ListItem("개인업적평가", "01"));
        ddl.Items.Insert(1, new ListItem("개인역량평가", "02"));
        ddl.Items.Insert(2, new ListItem("공헌도 평가", "03"));
        ddl.Items.Insert(3, new ListItem("MBO 평가", "04"));
        ddl.Items.Insert(4, new ListItem("공통역량평가", "11"));
        ddl.Items.Insert(5, new ListItem("직무역량평가", "12"));
        ddl.Items.Insert(6, new ListItem("리더역량평가", "13"));
    }

    public static void BindQuestionPreviousStepYN(DropDownList ddl)
    {
        ddl.Items.Insert(0, new ListItem("숨기기", "N"));
        ddl.Items.Insert(1, new ListItem("보이기", "Y"));
    }

	private static void BindNumber(DropDownList ddl
								, int intStartNum
								, int intEndNum )
	{
		ListItem liNew;
		for ( int i = intStartNum; i <= intEndNum; i++ )
		{
			liNew			= new ListItem();
			liNew.Text		= i.ToString();
			liNew.Value		= i.ToString();
			ddl.Items.Add( liNew );
		}
	}

	public static void BindSortNumber( DropDownList ddl )
	{
		BindNumber( ddl, 1, 20 );
	}

	public static void BindSetCtrlStep( DropDownList ddl )
	{
		BindNumber( ddl, 0, 3 );
	}

	public static void BindEstScopeUnit( DropDownList ddl )
	{
		Biz_ScopeUnits scopeUnit    = new Biz_ScopeUnits();
		DataSet ds		            = scopeUnit.GetScopeUnit();
        ddl.DataTextField           = "SCOPE_UNIT_NAME";
        ddl.DataValueField          = "SCOPE_UNIT_ID";
        ddl.DataSource              = ds;
        ddl.DataBind();
	}

	public static void BindEstScaleInfo( DropDownList ddl, int comp_id)
	{
        BindEstScaleInfo(ddl, false, comp_id);
	}

    public static void BindEstScaleInfo(DropDownList ddl, bool isBlank, int comp_id)
    {
        Biz_ScaleInfos scaleInfo    = new Biz_ScaleInfos();
        DataSet ds                  = scaleInfo.GetScaleInfos(comp_id);
        ddl.DataTextField           = "SCALE_NAME";
        ddl.DataValueField          = "SCALE_ID";
        ddl.DataSource              = ds;
        ddl.DataBind();

        if (isBlank)
        {
            ListItem itemA = new ListItem("미적용", "");
            ddl.Items.Insert(0, itemA);
        }
    }

    public static void BindQuestionObject(DropDownList ddl, string strEstID)
    {
        BindQuestionObject(ddl, strEstID, false);
    }

    public static void BindQuestionObject(DropDownList ddl, string strEstID, bool isBlank )
    {
        Biz_QuestionObjects questionObject  = new Biz_QuestionObjects();
        ddl.DataSource                      = questionObject.GetQuestionObjects(strEstID);
        ddl.DataTextField                   = "Q_OBJ_NAME";
        ddl.DataValueField                  = "Q_OBJ_ID";
        ddl.DataBind();

        if (isBlank)
        {
            ListItem itemA = new ListItem("----------", "");
            ddl.Items.Insert(0, itemA);
        }
    }

    public static void BindQuestionDefine(DropDownList ddl, string est_id, bool isBlank)
    {
        Biz_QuestionDefines questionDefine  = new Biz_QuestionDefines();
        ddl.DataSource                      = questionDefine.GetQuestionDefine(est_id);
        ddl.DataTextField                   = "Q_DFN_NAME";
        ddl.DataValueField                  = "Q_DFN_ID";
        ddl.DataBind();

        if (isBlank)
        {
            ListItem itemA = new ListItem("선택없음", "");
            ddl.Items.Insert(0, itemA);
        }
    }

    public static void BindColumnStyle(DropDownList ddl, bool isBlank)
    {
        Biz_ColumnStyles columnStyles       = new Biz_ColumnStyles();

        ddl.DataSource                      = columnStyles.GetColumnStyles();
        ddl.DataTextField                   = "COL_STYLE_NAME";
        ddl.DataValueField                  = "COL_STYLE_ID";
        ddl.DataBind();

        if (isBlank)
        {
            ListItem itemA = new ListItem("선택없음", "");
            ddl.Items.Insert(0, itemA);
        }
    }

	public static void BindPositionInfo( DropDownList ddl )
	{
		Biz_PositionInfos positionInfo  = new Biz_PositionInfos();
		DataSet ds                      = positionInfo.GetPositionInfoByUseYN("Y");

		ddl.DataValueField  = "POS_ID";
		ddl.DataTextField   = "POS_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();
	}

    public static void BindPositionClass( DropDownList ddl )
	{
		BindPositionClass(ddl, false);
	}

    public static void BindPositionClass( DropDownList ddl, bool isDefault)
	{
		Biz_PositionClasses position = new Biz_PositionClasses();
		DataSet ds          = position.GetPositionClasses();

		ddl.DataValueField  = "POS_CLS_ID";
		ddl.DataTextField   = "POS_CLS_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();

        if (isDefault)
        {
            ListItem itemA = new ListItem("----------", "-");
            ddl.Items.Insert(0, itemA);
        }
	}

    public static void BindPositionDuty( DropDownList ddl )
	{
		BindPositionDuty(ddl, false);
	}

    public static void BindPositionDuty( DropDownList ddl, bool isDefault)
	{
		Biz_PositionDutys position = new Biz_PositionDutys();
		DataSet ds          = position.GetPositionDuties();

		ddl.DataValueField  = "POS_DUT_ID";
		ddl.DataTextField   = "POS_DUT_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();

        if (isDefault)
        {
            ListItem itemA = new ListItem("----------", "-");
            ddl.Items.Insert(0, itemA);
        }
	}

    public static void BindPositionGroup( DropDownList ddl )
	{
		BindPositionGroup(ddl, false);
	}

    public static void BindPositionGroup( DropDownList ddl, bool isDefault)
	{
		Biz_PositionGroups position = new Biz_PositionGroups();
		DataSet ds          = position.GetPositionGroups();

		ddl.DataValueField  = "POS_GRP_ID";
		ddl.DataTextField   = "POS_GRP_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();

        if (isDefault)
        {
            ListItem itemA = new ListItem("----------", "-");
            ddl.Items.Insert(0, itemA);
        }
	}

    public static void BindPositionRank( DropDownList ddl )
	{
		BindPositionRank(ddl, false);
	}

    public static void BindPositionRank( DropDownList ddl, bool isDefault)
	{
		Biz_PositionRanks position = new Biz_PositionRanks();
		DataSet ds          = position.GetPositionRanks();

		ddl.DataValueField  = "POS_RNK_ID";
		ddl.DataTextField   = "POS_RNK_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();

        if (isDefault)
        {
            ListItem itemA = new ListItem("----------", "-");
            ddl.Items.Insert(0, itemA);
        }
	}

    public static void BindPositionKind( DropDownList ddl)
	{
		BindPositionKind( ddl, false);
	}

    public static void BindPositionKind( DropDownList ddl, bool isDefault)
	{
		Biz_PositionKinds position = new Biz_PositionKinds();
		DataSet ds          = position.GetPositionKinds();

		ddl.DataValueField  = "POS_KND_ID";
		ddl.DataTextField   = "POS_KND_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();

        if (isDefault)
        {
            ListItem itemA = new ListItem("----------", "-");
            ddl.Items.Insert(0, itemA);
        }
	}

    public static void BindPositionBiz( DropDownList ddl)
	{
        BindPositionBiz(ddl, false);
    }

    public static void BindPositionBiz( DropDownList ddl, bool isDefault)
	{
		Biz_PositionBizs position = new Biz_PositionBizs();
		DataSet ds          = position.GetPositionBizs();

		ddl.DataValueField  = "POS_BIZ_ID";
		ddl.DataTextField   = "POS_BIZ_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();

        if (isDefault)
        {
            ListItem itemA = new ListItem("----------", "-");
            ddl.Items.Insert(0, itemA);
        }
	}



	public static void BindPositionValue( DropDownList ddl, string strPos )
	{
		string strPosTableName  = "EST_POSITION_" + strPos;

		Biz_Positions positions = new Biz_Positions( strPosTableName, strPos );
		DataSet ds              = positions.GetPositions();

		ddl.DataSource          = ds;
		ddl.DataTextField = "POS_NAME";
		ddl.DataValueField = "POS_ID";
		ddl.DataBind();
	}

    public static void BindQuestionPageStyle(DropDownList ddl)
    {
        Biz_QuestionPageStyles q_page_style = new Biz_QuestionPageStyles();
        ddl.DataSource                      = q_page_style.GetQuestionPageStyles();
        ddl.DataTextField                   = "Q_STYLE_NAME";
        ddl.DataValueField                  = "Q_STYLE_ID";
        ddl.DataBind();

        //for (int i = 0; i < ddl.Items.Count; i++)
        //{
        //    if (ddl.Items[i].Value == "BLK")
        //        ddl.Items[i].Attributes.Add("onchange", "displayPreviousStepDDL('N')");
        //    else
        //        ddl.Items[i].Attributes.Add("onchange", "displayPreviousStepDDL('Y')");

        //}
    }

    public static void BindStatusStyle(DropDownList ddl)
    {
        Biz_StatusStyles statusStyle    = new Biz_StatusStyles();
        ddl.DataSource                  = statusStyle.GetStatusStyles();
        ddl.DataTextField               = "STATUS_STYLE_NAME";
        ddl.DataValueField              = "STATUS_STYLE_ID";
        ddl.DataBind();
    }

    public static void BindStatus( DropDownList ddl, string strStatusStyleID )
    {
        Biz_Status status	= new Biz_Status();
        ddl.DataSource		= status.GetStatuses( strStatusStyleID );
        ddl.DataTextField	= "STATUS_NAME";
        ddl.DataValueField	= "STATUS_ID";
        ddl.DataBind();
    }

    public static void BindBiasType( DropDownList ddl)
    {
        Biz_BiasTypes biasType	= new Biz_BiasTypes();
        ddl.DataSource		    = biasType.GetBiasTypes();
        ddl.DataTextField	    = "BIAS_TYPE_NAME";
        ddl.DataValueField	    = "BIAS_TYPE_ID";
        ddl.DataBind();
    }

    public static void BindScale( DropDownList ddl, int comp_id)
    {
        Biz_ScaleInfos scaleInfo= new Biz_ScaleInfos();
        ddl.DataSource		    = scaleInfo.GetScaleInfo(comp_id, "", "Y");
        ddl.DataTextField	    = "SCALE_NAME";
        ddl.DataValueField	    = "SCALE_ID";
        ddl.DataBind();
    }

    public static void BindGrade( DropDownList ddl, int comp_id)
	{
		Biz_Grades grade    = new Biz_Grades();
		DataSet ds          = grade.GetEstGrades(comp_id);

		ddl.DataValueField  = "GRADE_ID";
		ddl.DataTextField   = "GRADE_NAME";
		ddl.DataSource      = ds;
		ddl.DataBind();
	}

    public static void BindEstJobMapNotIn( DropDownList ddl, int comp_id, string est_id, bool isBlank)
	{
		Biz_JobEstMaps jobEstMap    = new Biz_JobEstMaps();
		DataSet ds                  = jobEstMap.GetJobEstMap(comp_id, est_id, "");

		ddl.DataValueField          = "EST_JOB_ID";
		ddl.DataTextField           = "EST_JOB_NAME";
		ddl.DataSource              = ds;
		ddl.DataBind();

        if (isBlank)
        {
            ListItem itemA = new ListItem("----------", "");
            ddl.Items.Insert(0, itemA);
        }
	}

    public static void BindEstBoardPopupPage(DropDownList ddl, int menu_ref_id, bool isBlank)
    {
        Biz_BoardPopupPages boardPopupPage  = new Biz_BoardPopupPages();
        DataSet ds                          = boardPopupPage.GetBoardPoupPage(menu_ref_id);
        ddl.DataValueField                  = "MENU_REF_ID";
        ddl.DataTextField                   = "MENU_NAME";
        ddl.DataSource                      = ds;
        ddl.DataBind();

        if (isBlank)
        {
            ListItem itemA = new ListItem("----------", "");
            ddl.Items.Insert(0, itemA);
        }
    }
}
