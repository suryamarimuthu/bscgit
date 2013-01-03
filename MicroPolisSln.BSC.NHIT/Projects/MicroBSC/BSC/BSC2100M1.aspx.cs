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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;
public partial class BSC_BSC2100M1 : EstPageBase
{
    private string EST_ID;
    private string Q_OBJ_ID;
    private int poo_ref_id;
    private int stg_ref_id;
    private int view_ref_id;
    private string POSTBACK_CTRL_NAME;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID = WebUtility.GetRequestByInt("COMP_ID");
        ESTTERM_REF_ID = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = WebUtility.GetRequestByInt("ESTTERM_STEP_ID");
        EST_ID = WebUtility.GetRequest("EST_ID");
        Q_OBJ_ID = WebUtility.GetRequest("Q_OBJ_ID");
        POSTBACK_CTRL_NAME = WebUtility.GetRequest("POSTBACK_CTRL_NAME");
        poo_ref_id = WebUtility.GetRequestByInt("POOL");
        stg_ref_id = WebUtility.GetRequestByInt("STG");
        view_ref_id = WebUtility.GetRequestByInt("VIEW");
        if (poo_ref_id == 0 || stg_ref_id == 0 || view_ref_id == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("KPI풀을 선택하세요.");
            return;
        }
        if (!Page.IsPostBack)
        {
            TreeViewCommom.BindDept(TreeView1);
        }

        ltrScript.Text = "";
    }

    private DataSet GetEmpInfoList(int comp_id
                                 , int estterm_ref_id
                                 , int estterm_sub_id
                                 , string est_id
                                 , int dept_ref_id)
    {
        Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps();

        DataSet ds = questionDeptEmpMaps.GetDeptByEmpList(comp_id
                                                         , estterm_ref_id
                                                         , estterm_sub_id
                                                         , est_id
                                                         , dept_ref_id);
        return ds;
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DataSet ds = GetEmpInfoList(COMP_ID
                                        , ESTTERM_REF_ID
                                        , ESTTERM_SUB_ID
                                        , EST_ID
                                        , DataTypeUtility.GetToInt32(TreeView1.SelectedNode.Value));
        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        string empId = e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString();
        string empName = e.Row.Cells.FromKey("EMP_NAME").Value.ToString();

        Biz_QuestionObjects questionObjects = new Biz_QuestionObjects("", DataTypeUtility.GetString(e.Row.Cells.FromKey("Q_OBJ_ID").Value));

        e.Row.Cells.FromKey("Q_OBJ_NAME").Value = questionObjects.Q_Obj_Name;

        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        row = e.Row;
        col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
        chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

        if (dr["ENABLED"].ToString().Equals("0"))
            chk.Enabled = false;
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        int effrctRow = 0;
        Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps();
        DataTable dataTable = questionDeptEmpMaps.GetDataTableSchema();
        dataTable = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid2
                                                            , new string[] { "TGT_DEPT_ID", "TGT_EMP_ID" }
                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            effrctRow += new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info().KpiAutoInsert(ESTTERM_REF_ID, view_ref_id, stg_ref_id, poo_ref_id,
                int.Parse(dataRow["TGT_DEPT_ID"].ToString()), int.Parse(dataRow["TGT_EMP_ID"].ToString()));
        }

        if (effrctRow > 0)
        {
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(POSTBACK_CTRL_NAME, true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("추가하실 사원을 선택하세요.");
        }
    }

    protected void ibtnDelEmp_Click(object sender, ImageClickEventArgs e)
    {
        UltraGridUtility.SetRemoveRow(UltraWebGrid2
                                    , "cBox"
                                    , "selchk");

        lblSelect.Text = UltraWebGrid2.Rows.Count.ToString();
    }
    protected void ibtnAddEmp_Click(object sender, ImageClickEventArgs e)
    {
        int cntRow = 0;
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;

        for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
        {
            row = UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked && UltraGridUtility.IsColumnValueContains(UltraWebGrid2, row, "EMP_REF_ID", "TGT_EMP_ID") == false)
            {
                UltraWebGrid2.Rows.Add();
                cntRow = UltraWebGrid2.Rows.Count - 1;

                UltraWebGrid2.Rows[cntRow].Cells.FromKey("TGT_DEPT_ID").Value = row.Cells.FromKey("DEPT_REF_ID").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("TGT_EMP_ID").Value = row.Cells.FromKey("EMP_REF_ID").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("LOGINID").Value = row.Cells.FromKey("LOGINID").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("DEPT_NAME").Value = row.Cells.FromKey("DEPT_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("EMP_NAME").Value = row.Cells.FromKey("EMP_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("Q_OBJ_NAME").Value = row.Cells.FromKey("Q_OBJ_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("POS_CLS_NAME").Value = row.Cells.FromKey("POS_CLS_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("Q_OBJ_ID").Value = row.Cells.FromKey("Q_OBJ_ID").Value;
            }
        }

        lblSelect.Text = UltraWebGrid2.Rows.Count.ToString();
    }
}
