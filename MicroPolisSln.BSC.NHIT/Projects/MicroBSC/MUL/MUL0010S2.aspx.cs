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

public partial class MUL_MUL0010S2 : EstPageBase
{
    private string EST_ID = "0";

    private int EST_MAX_COUNT = 10;
    private string EST_RANGE = "A"; // A:전체. D:부서만
    private string EST_METHOD = "R"; // R:RANDON   S:우선순위

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

    protected DataTable DT_ESTTARGETMAP_GROUPBYEST
    {
        get
        {
            if (ViewState["DT_ESTTARGETMAP_GROUPBYEST"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTTARGETMAP_GROUPBYEST"];
        }
        set
        {
            ViewState["DT_ESTTARGETMAP_GROUPBYEST"] = value;
        }
    }

    protected DataTable DT_ESTTARGETMAP_GROUPBYTGT
    {
        get
        {
            if (ViewState["DT_ESTTARGETMAP_GROUPBYTGT"] == null)
                return null;

            return (DataTable)ViewState["DT_ESTTARGETMAP_GROUPBYTGT"];
        }
        set
        {
            ViewState["DT_ESTTARGETMAP_GROUPBYTGT"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
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


            ibnRandom.Enabled = false;
            ibnDelRandom.Enabled = false;
            //ibnAddEstData.Enabled = false;
            //ibnDelEstData.Enabled = false;
        }


        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID = WebUtility.GetByValueDropDownList(ddlEstList);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);


        EST_MAX_COUNT = DataTypeUtility.GetToInt32(txtMax.Text);
        EST_RANGE = rdoRange.SelectedValue;
        EST_METHOD = rdoMethod.SelectedValue;


        ltrScript.Text = "";
    }

    private void DoBindingDept()
    {
        MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo bizComDeptInfo = new MicroBSC.Biz.Common.Biz.Biz_ComDeptInfo();

        DataTable dtComDeptInfo = bizComDeptInfo.GetAllList().Tables[0];

        UltraWebGrid1.DataSource = dtComDeptInfo;
        UltraWebGrid1.DataBind();
    }


    private void GridBinding(int comp_id)
    {
        Biz_TermSubs termSubs = new Biz_TermSubs();
        DataSet ds = termSubs.GetTermSubs(comp_id, "");

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        //lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }

    private void ViewOne(int comp_id, int estterm_sub_id)
    {
        Biz_TermSubs termSub = new Biz_TermSubs(comp_id, estterm_sub_id);

        //txtEstTermSubID.Text   = termSub.EstTerm_Sub_ID.ToString();
        //txtEstTermSubName.Text = termSub.EstTerm_Sub_Name;
        //txtWeight.Text         = DataTypeUtility.GetValue(termSub.Weight);
        //ckbYearYN.Checked      = DataTypeUtility.GetYNToBoolean(termSub.Year_YN);
        //txtSortOrder.Text      = DataTypeUtility.GetValue(termSub.Sort_Order);
        //ckbUseYN.Checked       = DataTypeUtility.GetYNToBoolean(termSub.Use_YN);
        //txtStartMonth.Text     = DataTypeUtility.GetValue(termSub.Start_Month);
        //txtEndMonth.Text       = DataTypeUtility.GetValue(termSub.End_Month);

        hdfEstTermSubID.Value = estterm_sub_id.ToString();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        int dept_ref_id = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("DEPT_REF_ID").Value);

        int est_cnt = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("EST_CNT").Value);
        int tgt_cnt = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("TGT_CNT").Value);

        DataRow[] rows = DT_ESTTARGETMAP_GROUPBYTGT.Select(string.Format(" EST_DEPT_ID = {0} AND DIRECTION_TYPE = '{1}' ", dept_ref_id, ConDIRECTION_TYPE));

        e.Row.Cells.FromKey("EST_CNT").Value = string.Format("{0}/{1}", rows.Length, est_cnt);
        if (rows.Length > 0)
        {
            e.Row.Cells.FromKey("EST_CNT").Style.ForeColor = System.Drawing.Color.Red;
            e.Row.Cells.FromKey("EST_CNT").Style.Font.Bold = true;
        }

        rows = DT_ESTTARGETMAP_GROUPBYEST.Select(string.Format(" TGT_DEPT_ID = {0} AND DIRECTION_TYPE= '{1}' ", dept_ref_id, ConDIRECTION_TYPE));

        e.Row.Cells.FromKey("TGT_CNT").Value = string.Format("{0}/{1}", rows.Length, tgt_cnt);
        if (rows.Length > 0)
        {
            e.Row.Cells.FromKey("TGT_CNT").Style.ForeColor = System.Drawing.Color.Red;
            e.Row.Cells.FromKey("TGT_CNT").Style.Font.Bold = true;
        }

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

    protected void UltraWebGrid2_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0)
        {
            int est_emp_id = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("EST_EMP_ID").Value);
            DoBinding_EST(est_emp_id);
        }
    }

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        //DataRowView drw = (DataRowView)e.Data;

        //TemplatedColumn selchk = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        //CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[e.Row.BandIndex]).FindControl("cBox");

        //cBox.Checked = true;
        //cBox.Attributes.Add("onclick", string.Format("enableCheckBox('{0}', '', '{1}')", ckbUseYN.ClientID, txtWeight.ClientID));

        //int emp_ref_id = DataTypeUtility.GetToInt32(drw["EMP_REF_ID"]);

        //DataRow[] rowsEST = DT_ESTTARGETMAP.Select(string.Format(" EST_EMP_ID = {0} AND EST_TYPE = '{1}' ", emp_ref_id, rdoEstTypeList.SelectedValue));

        //if (rowsEST.Length > 0)
        //{
        //    cBox.Checked = true;
        //}
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0)
        {
            string dept_name = DataTypeUtility.GetValue(e.SelectedRows[0].Cells.FromKey("DEPT_NAME").Value);

            lblTitleDept.Text = string.Format("({0})", dept_name);

            DEPT_REF_ID = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("DEPT_REF_ID").Value);
            DoBinding_Emp(DEPT_REF_ID);
        }
    }

    protected void ibnCheckID_Click(object sender, ImageClickEventArgs e)
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

    protected void ibnRandom_Click(object sender, ImageClickEventArgs e)
    {
        int cnt = UltraWebGrid1.Rows.Count;

        string dept_ref_id_list = string.Empty;
        string dept_ref_id = string.Empty;

        DataTable dtResult = DT_DEPTEMP.Clone();

        for (int i = 0; i < cnt; i++)
        {

            UltraGridRow row = UltraWebGrid1.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                dept_ref_id = DataTypeUtility.GetValue(row.Cells.FromKey("DEPT_REF_ID").Value);

                dept_ref_id_list += "," + dept_ref_id;

                string est_tgt_list = string.Empty;


                DataRow[] rowsTGT = DT_DEPTEMP.Select(string.Format(" EST_TYPE_TGT = 'TGT' AND DEPT_REF_ID = {0} ", dept_ref_id));

                string filterDept = " EST_TYPE_EST = 'EST' ";
                string sort = string.Empty;

                if (EST_RANGE.Equals("D"))
                {
                    filterDept += string.Format(" AND  DEPT_REF_ID = {0} ", dept_ref_id);
                }

                if (EST_METHOD.Equals("R"))
                {
                    foreach (DataRow rowTgt in rowsTGT)
                    {
                        DataTable dtRandom = DT_DEPTEMP.Copy();

                        string estList = string.Empty;

                        string tgt_emp_id = DataTypeUtility.GetValue(rowTgt["EMP_REF_ID"]);
                        string tgt_emp_name = DataTypeUtility.GetValue(rowTgt["EMP_NAME"]);
                        string position_class_code = DataTypeUtility.GetValue(rowTgt["POSITION_CLASS_CODE"]);
                        string pos_cls_name = DataTypeUtility.GetValue(rowTgt["POS_CLS_NAME"]);
                        string position_grp_code = DataTypeUtility.GetValue(rowTgt["POSITION_GRP_CODE"]);
                        string pos_grp_name = DataTypeUtility.GetValue(rowTgt["POS_GRP_NAME"]);
                        string position_rank_code = DataTypeUtility.GetValue(rowTgt["POSITION_RANK_CODE"]);
                        string pos_rank_name = DataTypeUtility.GetValue(rowTgt["POS_RNK_NAME"]);
                        string position_duty_code = DataTypeUtility.GetValue(rowTgt["POSITION_DUTY_CODE"]);
                        string pos_dut_name = DataTypeUtility.GetValue(rowTgt["POS_DUT_NAME"]);
                        string position_kind_code = DataTypeUtility.GetValue(rowTgt["POSITION_KIND_CODE"]);
                        string pos_knd_name = DataTypeUtility.GetValue(rowTgt["POS_KND_NAME"]);

                        string filter = filterDept + string.Format(" AND EMP_REF_ID <> {0} ", tgt_emp_id);

                        dtRandom = DataTypeUtility.FilterSortDataTable(dtRandom, filter);

                        int cntRandom = dtRandom.Rows.Count;
                        if (cntRandom > 0)
                        {
                            for (int k = 0; k < EST_MAX_COUNT; k++)
                            {
                                cntRandom = dtRandom.Rows.Count;
                                if (cntRandom <= 0)
                                    break;

                                Random rnd = new Random();
                                int rndCnt = rnd.Next(0, cntRandom - 1);

                                rndCnt = rnd.Next(0, rndCnt);

                                //int rndCnt = rnd.Next(1, 1);

                                estList += "," + DataTypeUtility.GetValue(dtRandom.Rows[rndCnt]["EMP_REF_ID"]);

                                DataRow rowRandom = dtRandom.Rows[rndCnt];

                                rowRandom["TGT_DEPT_ID"] = dept_ref_id;
                                rowRandom["TGT_EMP_ID"] = tgt_emp_id;
                                rowRandom["TGT_EMP_NAME"] = tgt_emp_name;
                                rowRandom["TGT_CLASS_CODE"] = position_class_code;
                                rowRandom["TGT_CLS_NAME"] = pos_cls_name;
                                rowRandom["TGT_GRP_CODE"] = position_grp_code;
                                rowRandom["TGT_GRP_NAME"] = pos_grp_name;
                                rowRandom["TGT_RANK_CODE"] = position_rank_code;
                                rowRandom["TGT_RANK_NAME"] = pos_rank_name;
                                rowRandom["TGT_DUTY_CODE"] = position_duty_code;
                                rowRandom["TGT_DUT_NAME"] = pos_dut_name;
                                rowRandom["TGT_KIND_CODE"] = position_kind_code;
                                rowRandom["TGT_KND_NAME"] = pos_knd_name;

                                dtResult.ImportRow(rowRandom);

                                rowRandom.Delete();
                                dtRandom.AcceptChanges();
                            }
                        }

                        if (estList.Length > 0)
                            estList = estList.Remove(0, 1);

                        est_tgt_list += ";" + string.Format("{0}={1}", tgt_emp_id, estList);
                    }
                }
                else
                {
                    //dtRandom = DataTypeUtility.FilterSortDataTable(dtRandom, filter, sort);
                }

                if (est_tgt_list.Length > 0)
                    est_tgt_list = est_tgt_list.Remove(0, 1);

                row.Cells.FromKey("RND_EST_LIST").Value += est_tgt_list;
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

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

        string okMsg = bizEstEmpEstTargetMap.AddEmpEstTargetMap(dtEmp
                                                             , dtResult
                                                             , COMP_ID
                                                             , EST_ID
                                                             , ESTTERM_REF_ID
                                                             , ESTTERM_SUB_ID
                                                             , ConESTTERM_STEP_ID
                                                             , ConDIRECTION_TYPE
                                                             , "N"
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

    protected void ibnDelRandom_Click(object sender, ImageClickEventArgs e)
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

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

        string okMsg = bizEstEmpEstTargetMap.AddEmpEstTargetMap(dtEmp
                                                             , null
                                                             , COMP_ID
                                                             , EST_ID
                                                             , ESTTERM_REF_ID
                                                             , ESTTERM_SUB_ID
                                                             , ConESTTERM_STEP_ID
                                                             , ConDIRECTION_TYPE
                                                             , "N"
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

    protected void ibnAddEstData_Click(object sender, ImageClickEventArgs e)
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

        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" TGT_DEPT_ID  IN ({0}) AND DIRECTION_TYPE = '{1}' ", dept_ref_id_list, ConDIRECTION_TYPE));

        DataTable dtDel = DataTypeUtility.GetGroupByDataTable(dtEmp.Copy(), new string[] { "TGT_EMP_ID" });

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        string okMsg = bizEstData.AddData(dtDel
                                        , dtEmp
                                                             , COMP_ID
                                                             , EST_ID
                                                             , ESTTERM_REF_ID
                                                             , ESTTERM_SUB_ID
                                                             , ConESTTERM_STEP_ID
                                                             , ConDIRECTION_TYPE
                                                             , "N"
                                                             , DateTime.Now
                                                             , DateTime.Now
                                                             , this.gUserInfo.Emp_Ref_ID);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
            DEPT_REF_ID = -1;

        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(okMsg);
        }
    }

    protected void ibnDelEstData_Click(object sender, ImageClickEventArgs e)
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

        DataTable dtEmp = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" TGT_DEPT_ID  IN ({0}) AND DIRECTION_TYPE = '{1}' ", dept_ref_id_list, ConDIRECTION_TYPE));

        DataTable dtDel = DataTypeUtility.GetGroupByDataTable(dtEmp.Copy(), new string[] { "TGT_EMP_ID" });

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        string okMsg = bizEstData.RemoveEstData(dtDel
                                                 , COMP_ID
                                                 , EST_ID
                                                 , ESTTERM_REF_ID
                                                 , ESTTERM_SUB_ID
                                                 , ConESTTERM_STEP_ID
                                                 , ConDIRECTION_TYPE);

        if (okMsg.Length == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상 처리 되었습니다.", false);

            DoBinding_Dept();
            DEPT_REF_ID = -1;

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
        UltraWebGrid3.Clear();

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

        string[] groupBy = { "TGT_DEPT_ID"
                            ,"TGT_DEPT_NAME"
                            ,"TGT_EMP_ID"
                            ,"TGT_EMP_NAME"
                            ,"TGT_POS_CLS_ID"
                            ,"TGT_POS_CLS_NAME"
                            ,"TGT_POS_DUT_ID"
                            ,"TGT_POS_DUT_NAME"
                            ,"TGT_POS_GRP_ID"
                            ,"TGT_POS_GRP_NAME"
                            ,"TGT_POS_RNK_ID"
                            ,"TGT_POS_RNK_NAME"
                            ,"TGT_POS_KND_ID"
                            ,"TGT_POS_KND_NAME"
                            ,"DIRECTION_TYPE" };

        DataTable dtEst = DT_ESTTARGETMAP.Copy();
        DataTable dtTgt = DT_ESTTARGETMAP.Copy();

        DT_ESTTARGETMAP_GROUPBYEST = DataTypeUtility.GetGroupByDataTable(dtEst, groupBy);

        DT_ESTTARGETMAP_GROUPBYTGT = DataTypeUtility.GetGroupByDataTable(dtTgt, new string[] { "EST_DEPT_ID", "EST_EMP_ID", "DIRECTION_TYPE" });

        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp bizMulEstEmp = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Emp();

        DataTable dtMulEstEmp = bizMulEstEmp.GetDeptMapping_DB(COMP_ID
                                                             , EST_ID
                                                             , ESTTERM_REF_ID
                                                             , ESTTERM_SUB_ID);

        UltraWebGrid1.DataSource = dtMulEstEmp;
        UltraWebGrid1.DataBind();

        if (dtMulEstEmp.Rows.Count > 0)
        {
            ibnRandom.Enabled = true;
            ibnDelRandom.Enabled = true;
        }
        else
        {
            ibnRandom.Enabled = false;
            ibnDelRandom.Enabled = false;
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

        DT_DEPTEMP.Columns.Add("TGT_DEPT_ID");
        DT_DEPTEMP.Columns.Add("TGT_EMP_ID");
        DT_DEPTEMP.Columns.Add("TGT_EMP_NAME");
        DT_DEPTEMP.Columns.Add("TGT_CLASS_CODE");
        DT_DEPTEMP.Columns.Add("TGT_CLS_NAME");
        DT_DEPTEMP.Columns.Add("TGT_GRP_CODE");
        DT_DEPTEMP.Columns.Add("TGT_GRP_NAME");
        DT_DEPTEMP.Columns.Add("TGT_RANK_CODE");
        DT_DEPTEMP.Columns.Add("TGT_RANK_NAME");
        DT_DEPTEMP.Columns.Add("TGT_DUTY_CODE");
        DT_DEPTEMP.Columns.Add("TGT_DUT_NAME");
        DT_DEPTEMP.Columns.Add("TGT_KIND_CODE");
        DT_DEPTEMP.Columns.Add("TGT_KND_NAME");


        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        DataTable dtEstData =  bizEstData.GetEstData(COMP_ID
                                                  , EST_ID
                                                  , ESTTERM_REF_ID
                                                  , ESTTERM_SUB_ID
                                                  , ConESTTERM_STEP_ID
                                                  , ConDIRECTION_TYPE);

        if (dtEstData.Rows.Count > 0)
        {
            ibnAddEstData.Visible = false;
            //ibnDelEstData.Visible = false;
        }
        else
        {
            ibnAddEstData.Visible = true;
            //ibnDelEstData.Visible = true;
        }
    }

    private void DoBinding_Emp(int dept_ref_id)
    {
        string filter = string.Format(" TGT_DEPT_ID = {0} ", dept_ref_id);
        string sort = "TGT_EMP_NAME";
        string[] groupBy = { "TGT_DEPT_ID"
                            ,"TGT_DEPT_NAME"
                            ,"TGT_EMP_ID"
                            ,"TGT_EMP_NAME"
                            ,"TGT_POS_CLS_ID"
                            ,"TGT_POS_CLS_NAME"
                            ,"TGT_POS_DUT_ID"
                            ,"TGT_POS_DUT_NAME"
                            ,"TGT_POS_GRP_ID"
                            ,"TGT_POS_GRP_NAME"
                            ,"TGT_POS_RNK_ID"
                            ,"TGT_POS_RNK_NAME"
                            ,"TGT_POS_KND_ID"
                            ,"TGT_POS_KND_NAME"
                            ,"DIRECTION_TYPE"};

        UltraWebGrid2.Columns[1].BaseColumnName = "TGT_EMP_NAME";
        UltraWebGrid2.Columns[2].BaseColumnName = "TGT_POS_KND_NAME";
        UltraWebGrid2.Columns[3].BaseColumnName = "TGT_POS_CLS_NAME";
        UltraWebGrid2.Columns[4].BaseColumnName = "TGT_POS_DUT_NAME";
        UltraWebGrid2.Columns[5].BaseColumnName = "TGT_EMP_ID";


        //if (rdoEstTypeList.SelectedIndex.Equals(0))
        //{
        //    filter = string.Format(" EST_DEPT_ID = {0} ", dept_ref_id);
        //    sort = "EST_EMP_NAME";
        //    groupBy = new string[] { "EST_DEPT_ID"
        //                            ,"EST_DEPT_NAME"
        //                            ,"EST_EMP_ID"
        //                            ,"EST_EMP_NAME"
        //                            ,"EST_POS_CLS_ID"
        //                            ,"EST_POS_CLS_NAME"
        //                            ,"EST_POS_DUT_ID"
        //                            ,"EST_POS_DUT_NAME"
        //                            ,"EST_POS_GRP_ID"
        //                            ,"EST_POS_GRP_NAME"
        //                            ,"EST_POS_RNK_ID"
        //                            ,"EST_POS_RNK_NAME"
        //                            ,"EST_POS_KND_ID"
        //                            ,"EST_POS_KND_NAME" };

        //    UltraWebGrid2.Columns[1].BaseColumnName = "EST_EMP_NAME";
        //    UltraWebGrid2.Columns[2].BaseColumnName = "EST_POS_KND_NAME";
        //    UltraWebGrid2.Columns[3].BaseColumnName = "EST_POS_CLS_NAME";
        //    UltraWebGrid2.Columns[4].BaseColumnName = "EST_POS_DUT_NAME";
        //}



        DataTable dtDeptEmp = DataTypeUtility.FilterSortDataTable(DataTypeUtility.GetGroupByDataTable(DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, filter)
                                                                                                    , groupBy)
                                                                , ""
                                                                , sort);
        UltraWebGrid2.DataSource = dtDeptEmp;
        UltraWebGrid2.DataBind();



        //if (dtDeptEmp.Rows.Count > 0)
        //{
        //    ibnEmp.Enabled = true;
        //}
        //else
        //{
        //    ibnEmp.Enabled = false;
        //}
    }

    private void DoBinding_EST(int est_emp_id)
    {
        DataTable dtEST = DataTypeUtility.FilterSortDataTable(DT_ESTTARGETMAP, string.Format(" TGT_EMP_ID = {0} ", est_emp_id), " EST_DEPT_NAME, EST_EMP_NAME ");
        UltraWebGrid3.DataSource = dtEST;
        UltraWebGrid3.DataBind();
    }
}

