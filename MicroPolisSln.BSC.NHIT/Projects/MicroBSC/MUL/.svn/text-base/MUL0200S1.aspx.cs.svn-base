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

public partial class MUL_MUL0200S1 : EstPageBase
{
    Biz_Mul_Est_Target_Pool bizMulEstTargetPool;

    private string EST_ID = "0";

    const int ConESTTERM_STEP_ID = 2;
    const string ConDIRECTION_TYPE = "MU";

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


    protected int EMP_REF_ID
    {
        get
        {
            if (ViewState["EMP_REF_ID"] == null)
                return -1;

            return (int)ViewState["EMP_REF_ID"];
        }
        set
        {
            ViewState["EMP_REF_ID"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bizMulEstTargetPool = new Biz_Mul_Est_Target_Pool();

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
        EST_ID = WebUtility.GetByValueDropDownList(ddlEstList);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);


        ltrScript.Text = "";
    }


    protected void toggleBtn(ImageButton btn, bool mode)
    {
        btn.Enabled = mode;
        btn.Visible = mode;
    }
        
    

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        string EST_EMP_CNT = e.Row.Cells.FromKey("EST_EMP_CNT").Value.ToString();
        string POOL_EST_CNT = e.Row.Cells.FromKey("POOL_EST_CNT").Value.ToString();
        e.Row.Cells.FromKey("EST_CNT").Value = POOL_EST_CNT + "/" + EST_EMP_CNT;

        if (!POOL_EST_CNT.Equals("0"))
        {
            e.Row.Cells.FromKey("EST_CNT").Style.ForeColor = Color.Red;
            e.Row.Cells.FromKey("EST_CNT").Style.Font.Bold = true;
        }



        string TGT_EMP_CNT = e.Row.Cells.FromKey("TGT_EMP_CNT").Value.ToString();
        string POOL_TGT_CNT = e.Row.Cells.FromKey("POOL_TGT_CNT").Value.ToString();
        e.Row.Cells.FromKey("TGT_CNT").Value = POOL_TGT_CNT + "/" + TGT_EMP_CNT;

        if (!POOL_TGT_CNT.Equals("0"))
        {
            e.Row.Cells.FromKey("TGT_CNT").Style.ForeColor = Color.Red;
            e.Row.Cells.FromKey("TGT_CNT").Style.Font.Bold = true;
        }
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows[0] != null)
        {
            DEPT_REF_ID = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("DEPT_ID").Value.ToString());

            DoBinding_TgtEmp();
        }
    }


    protected void UltraWebGrid2_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows[0] != null)
        {
            EMP_REF_ID = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("EMP_ID").Value.ToString());

            DoBinding_EstEmp();
        }
    }
    


    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBinding(COMP_ID);
    }


    private void GridBinding(int comp_id)
    {
        Biz_TermSubs termSubs = new Biz_TermSubs();
        DataSet ds = termSubs.GetTermSubs(comp_id, "");

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        //lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }


    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();
        UltraWebGrid3.Clear();

        DoBinding_Dept();
    }


    private void DoBinding_Dept()
    {
        DataTable DT = bizMulEstTargetPool.Get_MulEmpCnt_Join_MulPoolEmpCnt(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

        if (DT.Rows.Count > 0)
        {
            toggleBtn(this.ibnSavePool, true);
            toggleBtn(this.ibnDelPool, true);
        }
        else
        {
            toggleBtn(this.ibnSavePool, false);
            toggleBtn(this.ibnDelPool, false);
        }

        setButtonVisible();

        UltraWebGrid1.DataSource = DT;
        UltraWebGrid1.DataBind();
    }



    private void setButtonVisible()
    {
        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEmpEstTargetMaps = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();
        //MicroBSC.Estimation.Biz.Biz_EmpEstTargetMaps bizEmpEstTargetMaps = new Biz_EmpEstTargetMaps();

        DataTable dt_esttargetmap = bizEmpEstTargetMaps.GetEmpEstTargetMap(COMP_ID
                                                                        , EST_ID
                                                                        , ESTTERM_REF_ID
                                                                        , ESTTERM_SUB_ID
                                                                        , ConESTTERM_STEP_ID
                                                                        , 0
                                                                        , 0
                                                                        , 0
                                                                        , 0).Tables[0];

        DataRow[] rows = dt_esttargetmap.Select(string.Format(" DIRECTION_TYPE = '{0}' ", ConDIRECTION_TYPE));

        if (rows.Length > 0)
        {
            this.ibnSavePool.Visible = false;
            this.ibnDelPool.Visible = false;
        }
        else
        {
            this.ibnSavePool.Visible = true;
            this.ibnDelPool.Visible = true;
        }
    }
    
    
    
    private void DoBinding_TgtEmp()
    {
        DataTable DT = bizMulEstTargetPool.Get_MulTgtEmp_List(COMP_ID, DEPT_REF_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

        UltraWebGrid2.DataSource = DT;
        UltraWebGrid2.DataBind();
    }


    private void DoBinding_EstEmp()
    {
        DataTable DT = bizMulEstTargetPool.Get_MulEstEmp_List(COMP_ID, EMP_REF_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

        UltraWebGrid3.DataSource = DT;
        UltraWebGrid3.DataBind();
    }
    
    
    protected void ibnSavePool_Click(object sender, ImageClickEventArgs e)
    {
        if (doSave_Est_Target_Pool())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장하였습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("실패했습니다.");
        }

        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();
        UltraWebGrid3.Clear();

        DoBinding_Dept();
    }
    
    
    protected void ibnDelPool_Click(object sender, ImageClickEventArgs e)
    {
        UltraWebGrid2.Clear();
        UltraWebGrid3.Clear();

        if (doDelete_Est_Target_Pool())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("삭제하였습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("실패했습니다.");
        }

        DoBinding_Dept();
    }


    protected bool doSave_Est_Target_Pool()
    { 
        DataTable DT = UltraGridUtility.GetDataSetByCheckedBox(UltraWebGrid1
                                                                , new string[] { "DEPT_ID" }
                                                                , "selchk"
                                                                , "cBox").Tables[0];

        int affectedRow = bizMulEstTargetPool.Add_Tgt_Emp_Pool(DT, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, gUserInfo.Emp_Ref_ID);

        return affectedRow > 0 ? true : false;
    }


    protected bool doDelete_Est_Target_Pool()
    {
        DataTable DT = UltraGridUtility.GetDataSetByCheckedBox(UltraWebGrid1
                                                                , new string[] { "DEPT_ID" }
                                                                , "selchk"
                                                                , "cBox").Tables[0];

        int affectedRow = bizMulEstTargetPool.Remove_Tgt_Emp_Pool(DT, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

        return affectedRow > 0 ? true : false;
    }
}

