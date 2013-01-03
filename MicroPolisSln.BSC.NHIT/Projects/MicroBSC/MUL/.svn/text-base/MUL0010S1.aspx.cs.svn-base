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

public partial class MUL_MUL0010S1 : EstPageBase
{
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

    protected DataTable DT_ESTTARGETMAP
    {
        get
        {
            if (ViewState["DT_ESTTARGETMAP"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTTARGETMAP"];
        }
        set
        {
            ViewState["DT_ESTTARGETMAP"] = value;
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

            rdoEstTypeList.Items.Add(new ListItem("평가자", "EST"));
            rdoEstTypeList.Items.Add(new ListItem("피평가자", "TGT"));
            rdoEstTypeList.SelectedIndex = 0;


            //TextBoxCommon.SetOnlyInteger(txtEstTermSubID);
            //TextBoxCommon.SetOnlyInteger(txtSortOrder);
            //TextBoxCommon.SetOnlyInteger(txtStartMonth);
            //TextBoxCommon.SetOnlyInteger(txtEndMonth);
            //TextBoxCommon.SetOnlyPercent(txtWeight);

            //DoBindingDept();
			//GridBinding(WebUtility.GetIntByValueDropDownList(ddlCompID));


            ibnDeptAdd.Enabled = false;
            ibnDeptDel.Enabled = false;
            ibnEmp.Enabled = false;
		}


        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID  = WebUtility.GetByValueDropDownList(ddlEstList);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

            

		ltrScript.Text  = "";
	}

    private void DoBindingDept()
    {
        MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo bizComDeptInfo = new MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo();

        DataTable dtComDeptInfo = bizComDeptInfo.GetAllList().Tables[0];

        UltraWebGrid1.DataSource = dtComDeptInfo;
        UltraWebGrid1.DataBind();
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //ViewOne(COMP_ID, hdfEstID.Value);
    }

	private void GridBinding(int comp_id)
	{
		Biz_TermSubs termSubs   = new Biz_TermSubs();
		DataSet ds              = termSubs.GetTermSubs(comp_id, "");

		UltraWebGrid1.DataSource = ds;
		UltraWebGrid1.DataBind();

        //lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
	}

	private void ViewOne(int comp_id, int estterm_sub_id )
	{
		Biz_TermSubs termSub   = new Biz_TermSubs(comp_id, estterm_sub_id );

        //txtEstTermSubID.Text   = termSub.EstTerm_Sub_ID.ToString();
        //txtEstTermSubName.Text = termSub.EstTerm_Sub_Name;
        //txtWeight.Text         = DataTypeUtility.GetValue(termSub.Weight);
        //ckbYearYN.Checked      = DataTypeUtility.GetYNToBoolean(termSub.Year_YN);
        //txtSortOrder.Text      = DataTypeUtility.GetValue(termSub.Sort_Order);
        //ckbUseYN.Checked       = DataTypeUtility.GetYNToBoolean(termSub.Use_YN);
        //txtStartMonth.Text     = DataTypeUtility.GetValue(termSub.Start_Month);
        //txtEndMonth.Text       = DataTypeUtility.GetValue(termSub.End_Month);

		hdfEstTermSubID.Value  = estterm_sub_id.ToString();
	}

	protected void UltraWebGrid1_InitializeRow( object sender, RowEventArgs e )
	{
        //int est_cnt = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("EST_CNT").Value);
        //int tgt_cnt = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("TGT_CNT").Value);

        //if (est_cnt > 0)
        //{
        //    e.Row.Cells.FromKey("EST_CNT").Style.ForeColor = System.Drawing.Color.Red;
        //    e.Row.Cells.FromKey("EST_CNT").Style.Font.Bold = true;
        //}

        //if (tgt_cnt > 0)
        //{
        //    e.Row.Cells.FromKey("TGT_CNT").Style.ForeColor = System.Drawing.Color.Red;
        //    e.Row.Cells.FromKey("TGT_CNT").Style.Font.Bold = true;
        //}

        //TemplatedColumn selchk = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        //CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[e.Row.BandIndex]).FindControl("cBox");

        //int total_cnt = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("TOTAL_CNT").Value);

        //if (total_cnt == est_cnt + tgt_cnt)
        //{
        //    cBox.Checked = true;
        //}
	}

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        TemplatedColumn selchk = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[e.Row.BandIndex]).FindControl("cBox");

            //cBox.Checked = true;
            //cBox.Attributes.Add("onclick", string.Format("enableCheckBox('{0}', '', '{1}')", ckbUseYN.ClientID, txtWeight.ClientID));

        int emp_ref_id = DataTypeUtility.GetToInt32(drw["EMP_REF_ID"]);

        DataRow[] rowsEST = DT_ESTEMP.Select(string.Format(" EST_EMP_ID = {0} AND EST_TYPE = '{1}' ", emp_ref_id, rdoEstTypeList.SelectedValue));

        if (rowsEST.Length > 0)
        {
            cBox.Checked = true;
        }
    }

	protected void UltraWebGrid1_SelectedRowsChange( object sender, SelectedRowsEventArgs e )
	{
        lblTitleEMP.Text = rdoEstTypeList.Items[rdoEstTypeList.SelectedIndex].Text;

        if (e.SelectedRows.Count > 0)
        {
            DEPT_REF_ID = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("DEPT_REF_ID").Value);
            DoBinding_Emp(DEPT_REF_ID);
        }
	}

	protected void ibnCheckID_Click( object sender, ImageClickEventArgs e )
	{
        //if ( txtEstTermSubID.Text.Trim().Length == 0 )
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript( "평가주기ID를 입력해주세요." );
        //    return;
        //}

        //int intEstTermSubID     = DataTypeUtility.GetToInt32(txtEstTermSubID.Text);
        //Biz_TermSubs termSubs   = new Biz_TermSubs();
        //bool bDuplicate         = termSubs.IsExist(COMP_ID, intEstTermSubID );

        //if (bDuplicate)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가주기 ID가 있습니다.");
        //}
        //else
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("사용가능한 평가주기 ID 입니다.");
        //}
	}

    protected void ibnDeptAdd_Click(object sender, ImageClickEventArgs e)
	{
        int cnt = UltraWebGrid1.Rows.Count;

        string dept_ref_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = UltraWebGrid1.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                dept_ref_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("DEPT_REF_ID").Value);
            }
        }

        if (dept_ref_id_list.Length > 0)
        {
            dept_ref_id_list = dept_ref_id_list.Remove(0, 1);
        }

        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" DEPT_REF_ID  IN ({0})  ", dept_ref_id_list));

        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp BizMulEstEmp = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp();

        string okMsg = BizMulEstEmp.AddEstEmp(dtEmp
                                         , COMP_ID
                                         , EST_ID
                                         , ESTTERM_REF_ID
                                         , ESTTERM_SUB_ID
                                         , rdoEstTypeList.SelectedValue
                                         , DateTime.Now
                                         , this.gUserInfo.Emp_Ref_ID);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(okMsg);
        }
	}

    protected void ibnDeptDel_Click(object sender, ImageClickEventArgs e)
	{
        int cnt = UltraWebGrid1.Rows.Count;

        string dept_ref_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = UltraWebGrid1.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                dept_ref_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("DEPT_REF_ID").Value);
            }
        }

        if (dept_ref_id_list.Length > 0)
        {
            dept_ref_id_list = dept_ref_id_list.Remove(0, 1);
        }
        else
        {
            dept_ref_id_list = "-1";
        }

        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" DEPT_REF_ID  IN ({0})  ", dept_ref_id_list));

        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp BizMulEstEmp = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp();

        string okMsg = BizMulEstEmp.RemoveEstEmp(dtEmp
                                            , COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , rdoEstTypeList.SelectedValue);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(okMsg);
        }
	}

    protected void ibnEmp_Click(object sender, ImageClickEventArgs e)
    {
        int cnt = UltraWebGrid2.Rows.Count;

        string emp_ref_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = UltraWebGrid2.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                emp_ref_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("EMP_REF_ID").Value);
            }
        }

        DataTable dtEmp = new DataTable();

        if (emp_ref_id_list.Length > 0)
        {
            emp_ref_id_list = emp_ref_id_list.Remove(0, 1);
            dtEmp = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" EMP_REF_ID  IN ({0})  ", emp_ref_id_list));
        }

        DataTable dtDelEmp = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" DEPT_REF_ID  IN ({0})  ", DEPT_REF_ID));
        

        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp BizMulEstEmp = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp();

        string okMsg = BizMulEstEmp.AddEstEmp(dtDelEmp
                                             , dtEmp
                                             , COMP_ID
                                             , EST_ID
                                             , ESTTERM_REF_ID
                                             , ESTTERM_SUB_ID
                                             , rdoEstTypeList.SelectedValue
                                             , DateTime.Now
                                             , this.gUserInfo.Emp_Ref_ID);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
            DEPT_REF_ID = -1;
            UltraWebGrid2.Clear();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(okMsg);
        }
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBinding(COMP_ID);
    }

    protected void rdoEstTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblTitleEMP.Text = rdoEstTypeList.Items[rdoEstTypeList.SelectedIndex].Text;

        if (UltraWebGrid1.Rows.Count > 0)
        {
            if (DEPT_REF_ID > 0)
            {
                DoBinding_Emp(DEPT_REF_ID);
            }
        }
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //BindingData(COMP_ID, EST_ID, ESTTERM_REF_ID);
        DoBinding_Dept();
    }

    private void DoBinding_Dept()
    {
        DEPT_REF_ID = -1;
        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEmpEstTargetMaps = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();
        //MicroBSC.Estimation.Biz.Biz_EmpEstTargetMaps bizEmpEstTargetMaps = new Biz_EmpEstTargetMaps();

        DT_ESTTARGETMAP = bizEmpEstTargetMaps.GetEmpEstTargetMap(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ConESTTERM_STEP_ID
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , 0).Tables[0];

        DataRow[] rows = DT_ESTTARGETMAP.Select(string.Format(" DIRECTION_TYPE = '{0}' ", ConDIRECTION_TYPE));

        if (rows.Length > 0)
        {
            ibnDeptAdd.Visible = false;
            ibnDeptDel.Visible = false;
            ibnEmp.Visible = false;
        }
        else
        {
            ibnDeptAdd.Visible = true;
            ibnDeptDel.Visible = true;
            ibnEmp.Visible = true;
        }

        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp bizMulEstEmp = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp();

        DataTable dtMulEstEmp = bizMulEstEmp.GetDeptMapping_DB(COMP_ID
                                                             , EST_ID
                                                             , ESTTERM_REF_ID
                                                             , ESTTERM_SUB_ID);

        UltraWebGrid1.DataSource = dtMulEstEmp;
        UltraWebGrid1.DataBind();

        if (dtMulEstEmp.Rows.Count > 0)
        {
            ibnDeptAdd.Enabled = true;
            ibnDeptDel.Enabled = true;
        }
        else
        {
            ibnDeptAdd.Enabled = false;
            ibnDeptDel.Enabled = false;
        }

        // 평가자 목록 (EST_TYPE : EST)
        DT_ESTEMP = bizMulEstEmp.GetEstEmp_DB(COMP_ID
                                             , EST_ID
                                             , ESTTERM_REF_ID
                                             , ESTTERM_SUB_ID
                                             , 0
                                             , "");

        //// 피평가자 목록 (EST_TYPE : TGT)
        //DT_TGTEMP = bizMulEstEmp.GetEstEmp_DB(COMP_ID
        //                                     , EST_ID
        //                                     , ESTTERM_REF_ID
        //                                     , ESTTERM_SUB_ID
        //                                     , 0
        //                                     , "TGT");

        MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp bizRelDeptEmp = new MicroBSC.Integration.COM.Biz.Biz_Rel_Dept_Emp();

        DT_DEPTEMP = bizRelDeptEmp.GetRelDeptEmp_DB(0
                                                  , COMP_ID
                                                  , EST_ID
                                                  , ESTTERM_REF_ID
                                                  , ESTTERM_SUB_ID);
    }

    private void DoBinding_Emp(int dept_ref_id)
    {

        DataTable dtDeptEmp = DataTypeUtility.FilterSortDataTable(DT_DEPTEMP, string.Format(" DEPT_REF_ID = {0} ", dept_ref_id), " EMP_NAME ");
        UltraWebGrid2.DataSource = dtDeptEmp;
        UltraWebGrid2.DataBind();

        //if (rdoEstTypeList.SelectedIndex.Equals(0))
        //{

        //    MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp bizMulEstEmp = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp();
            
        //}
        //else
        //{

        //}

        if (dtDeptEmp.Rows.Count > 0)
        {
            ibnEmp.Enabled = true;
        }
        else
        {
            ibnEmp.Enabled = false;
        }
    }
}

