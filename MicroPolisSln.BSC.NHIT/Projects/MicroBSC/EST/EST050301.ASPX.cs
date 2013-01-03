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

public partial class EST_EST050301 : EstPageBase
{
    #region ========================================  이벤트 =========================================
    protected void Page_Load( object sender, EventArgs e )
	{
		if (!Page.IsPostBack)
		{
            COMP_ID            = GetRequestByInt("COMP_ID");
            string est_id      = GetRequest("EST_ID");
            int estterm_ref_id = GetRequestByInt("ESTTERM_REF_ID");
            int estterm_sub_id = GetRequestByInt("ESTTERM_SUB_ID");

            DoLoading(COMP_ID
                    , est_id
                    , estterm_ref_id
                    , estterm_sub_id);
		}
	}

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {  

        object status_yn  = e.Row.Cells.FromKey("STATUS_YN").Value;

        if (status_yn == null)
        {
            e.Row.Cells.FromKey("STATUS_IMG").Value = "<img src='../Images/status/N.gif'>";
        }
        else
        {
            if (status_yn.Equals("Y"))
                e.Row.Cells.FromKey("STATUS_IMG").Value = "<img src='../Images/status/E.gif'>";
            else 
                e.Row.Cells.FromKey("STATUS_IMG").Value = "<img src='../Images/status/N.gif'>";
        }

        int step_id       = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value);
        Biz_TermSteps biz = new Biz_TermSteps(COMP_ID, step_id);

        e.Row.Cells.FromKey("ESTTERM_STEP_NAME").Value = biz.EstTerm_Step_Name;
    }
    #endregion

    #region ========================================  이벤트 =========================================
    private void DoLoading(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id)
    {
        UltraWebGrid1.Clear();

        Biz_JobEstMaps biz = new Biz_JobEstMaps();
        DataSet ds         = biz.GetJobEstMap(comp_id
                                            , est_id
                                            , estterm_ref_id
                                            , estterm_sub_id
                                            , "");

        UltraWebGrid1.DataSource = ds.Tables[0];
        UltraWebGrid1.DataBind();
    }

    #endregion

}
