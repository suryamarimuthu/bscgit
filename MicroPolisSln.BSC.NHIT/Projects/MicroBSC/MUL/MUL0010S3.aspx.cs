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
using MicroBSC.Integration.MUL.Biz;

public partial class MUL_MUL0010S3 : EstPageBase
{
    private string DETAIL_VIEW = "Y";

    private string EST_ID = "0";

    protected int DEPT_REF_ID
    {
        get
        {
            if (ViewState["DEPT_REF_ID"] == null)
                return -1;

            return (int)ViewState["DEPT_REF_ID"];
        }
        set
        {
            ViewState["DEPT_REF_ID"] = value;
        }
    }

    protected DataTable DT_DEPTEMP
    {
        get
        {
            if (ViewState["DT_DEPTEMP"] == null)
                return null;

            return (DataTable)ViewState["DT_DEPTEMP"];
        }
        set
        {
            ViewState["DT_DEPTEMP"] = value;
        }
    }

    protected DataTable DT_ESTEMP
    {
        get
        {
            if (ViewState["DT_ESTEMP"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTEMP"];
        }
        set
        {
            ViewState["DT_ESTEMP"] = value;
        }
    }

    protected DataTable DT_TGTEMP
    {
        get
        {
            if (ViewState["DT_TGTEMP"] == null)
                return null;

            return (DataTable)ViewState["DT_TGTEMP"];
        }
        set
        {
            ViewState["DT_TGTEMP"] = value;
        }
    }

	protected void Page_Init( object sender, EventArgs e )
	{
        SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
		if (!IsPostBack)
		{

            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                    , WebUtility.GetIntByValueDropDownList(ddlCompID)
                                                    , "N");


            DropDownListCommom.BindEstStyle(ddlEstList, WebUtility.GetIntByValueDropDownList(ddlCompID), "MUL");
		}


        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        
        
        EST_ID = WebUtility.GetByValueDropDownList(ddlEstList);
        hdfEstID.Value = EST_ID;


		ltrScript.Text  = "";


        if (DETAIL_VIEW.Equals("Y"))
        {
            UltraWebGrid2.Columns.FromKey("DETAIL").Hidden = false;
        }
	}



	private void GridBinding(int comp_id)
	{
		Biz_TermSubs termSubs   = new Biz_TermSubs();
		DataSet ds              = termSubs.GetTermSubs(comp_id, "");

		UltraWebGrid1.DataSource = ds;
		UltraWebGrid1.DataBind();
	}



    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        
    }



	protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
	{
        if (!e.Row.Cells.FromKey("STATUS_N_CNT").Value.ToString().Equals("0"))
        {
            e.Row.Cells.FromKey("STATUS_N_CNT").Style.ForeColor = Color.Red;
            e.Row.Cells.FromKey("STATUS_N_CNT").Style.Font.Bold = true;
        }

        if (!e.Row.Cells.FromKey("STATUS_P_CNT").Value.ToString().Equals("0"))
        {
            e.Row.Cells.FromKey("STATUS_P_CNT").Style.ForeColor = Color.Orange;
            e.Row.Cells.FromKey("STATUS_P_CNT").Style.Font.Bold = true;
        }

        if (!e.Row.Cells.FromKey("STATUS_E_CNT").Value.ToString().Equals("0"))
        {
            e.Row.Cells.FromKey("STATUS_E_CNT").Style.ForeColor = Color.Green;
            e.Row.Cells.FromKey("STATUS_E_CNT").Style.Font.Bold = true;
        }



        //진행률 처리
        int TOTAL_EST_CNT = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("TOTAL_EST_CNT").Value);
        int STATUS_E_CNT = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("STATUS_E_CNT").Value);
        string EST_PROGRESS;
        if (TOTAL_EST_CNT == 0)
        {
            EST_PROGRESS = "-";
        }
        else
        {
            EST_PROGRESS = Math.Round(((double)STATUS_E_CNT / TOTAL_EST_CNT) * 100, 1).ToString() + "%";
        }

        e.Row.Cells.FromKey("EST_PROGRESS").Value = EST_PROGRESS;
        e.Row.Cells.FromKey("EST_PROGRESS").Style.HorizontalAlign = HorizontalAlign.Right;

        if (EST_PROGRESS.Equals("100%"))
        {
            e.Row.Cells.FromKey("TGT_DEPT_NAME").Style.Font.Bold = true;
            e.Row.Cells.FromKey("EST_PROGRESS").Style.Font.Bold = true;
        }
	}


    protected void UltraWebGrid2_InitializeLayout(object sender, LayoutEventArgs e)
    {
        
    }


    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        if (!e.Row.Cells.FromKey("STATUS_N_CNT").Value.ToString().Equals("0"))
        {
            e.Row.Cells.FromKey("STATUS_N_CNT").Style.ForeColor = Color.Red;
            e.Row.Cells.FromKey("STATUS_N_CNT").Style.Font.Bold = true;
        }

        if (!e.Row.Cells.FromKey("STATUS_P_CNT").Value.ToString().Equals("0"))
        {
            e.Row.Cells.FromKey("STATUS_P_CNT").Style.ForeColor = Color.Orange;
            e.Row.Cells.FromKey("STATUS_P_CNT").Style.Font.Bold = true;
        }

        if (!e.Row.Cells.FromKey("STATUS_E_CNT").Value.ToString().Equals("0"))
        {
            e.Row.Cells.FromKey("STATUS_E_CNT").Style.ForeColor = Color.Green;
            e.Row.Cells.FromKey("STATUS_E_CNT").Style.Font.Bold = true;
        }




        //진행률 처리
        int TOTAL_EST_CNT = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("TOTAL_EST_CNT").Value);
        int STATUS_E_CNT = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("STATUS_E_CNT").Value);
        string EST_PROGRESS;
        if (TOTAL_EST_CNT == 0)
        {
            EST_PROGRESS = "-";
        }
        else
        {
            EST_PROGRESS = Math.Round(((double)STATUS_E_CNT / TOTAL_EST_CNT) * 100, 1).ToString() + "%";
        }

        e.Row.Cells.FromKey("EST_PROGRESS").Value = EST_PROGRESS;
        e.Row.Cells.FromKey("EST_PROGRESS").Style.HorizontalAlign = HorizontalAlign.Right;

        if (EST_PROGRESS.Equals("100%"))
        {
            e.Row.Cells.FromKey("TGT_EMP_NAME").Style.Font.Bold = true;
            e.Row.Cells.FromKey("EST_PROGRESS").Style.Font.Bold = true;
        }




        if (DETAIL_VIEW.Equals("Y"))
        {
            string imgUrl = "../images/tree/search.gif";
            string popupScript;

            string TGT_DEPT_ID;
            string TGT_EMP_ID;



            TGT_DEPT_ID = e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString();
            TGT_EMP_ID = e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString();

            popupScript = string.Format("javascript:Show_Est_Stat_Detail_By_Emp('{0}', '{1}');"
                                                    , TGT_DEPT_ID, TGT_EMP_ID);

            e.Row.Cells.FromKey("DETAIL").Value = string.Format("<a href=\"{0}\"><img src=\"{1}\" /></a>"
                                                    , popupScript, imgUrl);
            e.Row.Cells.FromKey("DETAIL").Style.HorizontalAlign = HorizontalAlign.Center;
        }
    }



    protected string Calc_Progress(int cnt, int totalCnt)
    {
        string progressVal;

        if (totalCnt == 0)
            progressVal = "-";
        else
            progressVal = Math.Round(((double)cnt / totalCnt) * 100, 1).ToString() + "%";

        return progressVal;
    }



	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
        UltraWebGrid2.Clear();

        string TGT_DEPT_ID = e.SelectedRows[0].Cells.FromKey("TGT_DEPT_ID").Value.ToString();

        DoBinding_Emp(TGT_DEPT_ID);
	}




    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBinding(COMP_ID);
    }



    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding_Dept();
    }



    private void DoBinding_Dept()
    {
        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();

        Biz_Mul_Est_Data bizMulEstData = new Biz_Mul_Est_Data();
        
        DataTable DT = bizMulEstData.Get_Est_Status_By_Dept(hdfEstID.Value, ESTTERM_REF_ID.ToString(), ESTTERM_SUB_ID.ToString());

        
        UltraWebGrid1.DataSource = DT;
        UltraWebGrid1.DataBind();
    }



    private void DoBinding_Emp(string TGT_DEPT_ID)
    {
        UltraWebGrid2.Clear();

        Biz_Mul_Est_Data bizMulEstData = new Biz_Mul_Est_Data();

        DataTable DT = bizMulEstData.Get_Est_Status_By_Emp(hdfEstID.Value, ESTTERM_REF_ID.ToString(), ESTTERM_SUB_ID.ToString(), TGT_DEPT_ID);

        UltraWebGrid2.DataSource = DT;
        UltraWebGrid2.DataBind();
    }
}

