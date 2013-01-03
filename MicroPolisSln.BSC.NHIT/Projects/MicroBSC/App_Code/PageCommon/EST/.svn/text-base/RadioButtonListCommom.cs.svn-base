
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using MicroBSC.BSC.Biz;
using MicroBSC.Estimation.Biz;

public class RadioButtonListCommom
{
    
	public static void BindEstTermStep( RadioButtonList rbtnlist, int comp_id )
	{
		Biz_TermSteps termSteps = new Biz_TermSteps();
		DataSet ds	            = termSteps.GetTermSteps(comp_id, "Y");

        rbtnlist.DataSource         = ds;
        rbtnlist.DataTextField      = "ESTTERM_STEP_NAME";
        rbtnlist.DataValueField     = "ESTTERM_STEP_ID";
        rbtnlist.DataBind();

		if ( ds.Tables[0].Rows.Count > 0 )
		{
			rbtnlist.Items[0].Selected = true;
		}
	}

	public static void BindEstTermSub( RadioButtonList rbtnlist, int comp_id )
	{
		Biz_TermSubs termSubs       = new Biz_TermSubs();
		DataSet ds	                = termSubs.GetTermSubs(comp_id, "Y");

        rbtnlist.DataSource         = ds;
        rbtnlist.DataTextField      = "ESTTERM_SUB_NAME";
        rbtnlist.DataValueField     = "ESTTERM_SUB_ID";
        rbtnlist.DataBind();

		if ( ds.Tables[0].Rows.Count > 0 )
		{
			rbtnlist.Items[0].Selected = true;
		}
	}

    public static void BindEstStyle( RadioButtonList rbtnlist )
	{
		Biz_Styles style            = new Biz_Styles();
		DataSet ds	                = style.GetStyles();

        rbtnlist.DataSource         = ds;
        rbtnlist.DataTextField      = "EST_STYLE_NAME";
        rbtnlist.DataValueField     = "EST_STYLE_ID";
        rbtnlist.DataBind();

        if ( ds.Tables[0].Rows.Count > 0 )
		{
			rbtnlist.Items[0].Selected = true;
		}
	}

	/// <summary>
	/// 예 / 아니오
	/// </summary>
    public static void BindYN( RadioButtonList rbtnlist )
    {
		rbtnlist.Items.Insert( 0, new ListItem( "예", "Y" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "아니오", "N" ) );

		rbtnlist.Items[0].Selected = true;
    }

	/// <summary>
	/// 개인 / 부서
	/// </summary>
	public static void BindEstimate( RadioButtonList rbtnlist )
	{
		rbtnlist.Items.Insert( 0, new ListItem( "개인", "P" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "부서", "D" ) );

		rbtnlist.Items[0].Selected = true;
	}

    /// <summary>
	/// 가중치 적용 방식
	/// </summary>
	public static void BindWeightType( RadioButtonList rbtnlist )
	{
		rbtnlist.Items.Insert( 0, new ListItem( "부서별 가중치 적용", "DPT" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "직급별 가중치 적용", "POS" ) );

		rbtnlist.Items[0].Selected = true;
	}

    /// <summary>
	/// 평가방법 적용
	/// </summary>
	public static void BindScaleType( RadioButtonList rbtnlist )
	{
		rbtnlist.Items.Insert( 0, new ListItem( "부서별 평가방법", "DPT" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "직급별 평가방법", "POS" ) );

		rbtnlist.Items[0].Selected = true;
	}

	/// <summary>
	/// 사용 / 미사용
	/// </summary>
	public static void BindUseYN( RadioButtonList rbtnlist )
	{
		rbtnlist.Items.Insert( 0, new ListItem( "사용", "Y" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "미사용", "N" ) );

		rbtnlist.Items[0].Selected = true;
	}

    /// <summary>
    /// 과거데이터 개인평가 점수 보이기여부
    /// </summary>
    public static void BindVisiblePastPointYN(RadioButtonList rbtnlist)
    {
        rbtnlist.Items.Insert(0, new ListItem("예", "Y"));
        rbtnlist.Items.Insert(1, new ListItem("아니오", "N"));

        rbtnlist.Items[0].Selected = true;
    }

    public static void BindEstQTTMBOYN(RadioButtonList rbtnlist)
    {
        rbtnlist.Items.Insert(0, new ListItem("예", "Y"));
        rbtnlist.Items.Insert(1, new ListItem("아니오", "N"));

        rbtnlist.Items[1].Selected = true;
    }

    public static void BindMboScoreEstimateYN(RadioButtonList rbtnlist)
    {
        rbtnlist.Items.Insert(0, new ListItem("예", "Y"));
        rbtnlist.Items.Insert(1, new ListItem("아니오", "N"));

        rbtnlist.Items[1].Selected = true;
    }

    public static void BindDashBoardTYPE(RadioButtonList rbtnlist)
    {
        rbtnlist.Items.Insert(0, new ListItem("예", "Y"));
        rbtnlist.Items.Insert(1, new ListItem("아니오", "N"));

        rbtnlist.Items[1].Selected = true;

        rbtnlist.Items[0].Attributes.Add("OnClick", "displayDashboarDDL('Y')");
        rbtnlist.Items[1].Attributes.Add("OnClick", "displayDashboarDDL('N')");
    }

    /// <summary>
	/// Point, Grade 방식
	/// </summary>
	public static void BindPointGradeType( RadioButtonList rbtnlist )
	{
		rbtnlist.Items.Insert( 0, new ListItem( "점수", "PNT" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "등급", "GRD" ) );

		rbtnlist.Items[0].Selected = true;
	}

	/// <summary>
	/// 피평가자 의견상신 및 평가자 피드백
	/// </summary>
	public static void BindTgtSendType( RadioButtonList rbtnlist )
	{
        rbtnlist.Items.Insert( 0, new ListItem( "미사용", "N" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "피평가자 의견상신", "OPN" ) );
        rbtnlist.Items.Insert( 2, new ListItem( "피평가자 피드백", "FBK" ) );

		rbtnlist.Items[0].Selected = true;
	}

    /// <summary>
	/// 상향/하향 평가
	/// </summary>
	public static void BindDirectionType( RadioButtonList rbtnlist )
	{
        rbtnlist.Items.Insert( 0, new ListItem( "하향평가", "DN" ) );
		rbtnlist.Items.Insert( 1, new ListItem( "상향평가", "UP" ) );

		rbtnlist.Items[0].Selected = true;
	}

    /// <summary>
	/// 전체/부분확정
	/// </summary>
	public static void BindConfirmAllAndPart( RadioButtonList rbtnlist )
	{
		rbtnlist.Items.Insert( 0, new ListItem( "부분", "PRT" ) );
        rbtnlist.Items.Insert( 1, new ListItem( "전체", "ALL" ) );

		rbtnlist.Items[0].Selected = true;
	}
}
