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
using MicroBSC.Estimation.Dac;

public class CheckBoxListCommon
{
	public static void BindEstTermStep( CheckBoxList cbllist, int comp_id, string merge_yn)
	{
		Biz_TermSteps termSteps = new Biz_TermSteps();
		DataSet ds	            = termSteps.GetTermStepByMergeYN(comp_id, merge_yn);

        cbllist.DataSource         = ds;
        cbllist.DataTextField      = "ESTTERM_STEP_NAME";
        cbllist.DataValueField     = "ESTTERM_STEP_ID";
        cbllist.DataBind();
	}

	public static void BindEstTermSub( CheckBoxList cbllist, int comp_id, string year_yn)
	{
		Biz_TermSubs termSubs       = new Biz_TermSubs();
		DataSet ds	                = termSubs.GetTermSubByYearYN(comp_id, year_yn);

        cbllist.DataSource         = ds;
        cbllist.DataTextField      = "ESTTERM_SUB_NAME";
        cbllist.DataValueField     = "ESTTERM_SUB_ID";
        cbllist.DataBind();
	}

	public static int GetCheckNum( CheckBoxList cbllist )
	{
		int intReturn = 0;

		for ( int i = 0; i < cbllist.Items.Count; i++ )
		{
			if ( cbllist.Items[i].Selected == true )
			{
				intReturn++;
			}
		}

		return intReturn;
	}

	public static void Check( CheckBoxList cbllist, bool bolCheck )
	{
		for ( int i = 0; i < cbllist.Items.Count; i++ )
		{
			cbllist.Items[i].Selected = bolCheck;
		}
	}

}
