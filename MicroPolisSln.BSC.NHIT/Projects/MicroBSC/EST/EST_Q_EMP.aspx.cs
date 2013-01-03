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

// 제    목 : 사원 선택 페이지
// 내    용 : 평가에 해당하는 평가질의와 사원을 매핑하는 페이지
public partial class EST_EST_Q_EMP : EstPageBase
{
    private string EST_ID; 
    private string Q_OBJ_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = WebUtility.GetRequestByInt("COMP_ID");
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = WebUtility.GetRequestByInt("ESTTERM_STEP_ID");
        EST_ID          = WebUtility.GetRequest("EST_ID");
        Q_OBJ_ID        = WebUtility.GetRequest("Q_OBJ_ID");

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

        DataSet ds = questionDeptEmpMaps.GetDeptByEmpList( comp_id
                                                         , estterm_ref_id
                                                         , estterm_sub_id
                                                         , est_id
                                                         , dept_ref_id); 
        return ds;
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        DataSet ds      = GetEmpInfoList( COMP_ID
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
        DataRowView dr  = (DataRowView)e.Data;

        string empId    = e.Row.Cells.FromKey("EMP_REF_ID").Value.ToString();
        string empName  = e.Row.Cells.FromKey("EMP_NAME").Value.ToString();

        Biz_QuestionObjects questionObjects = new Biz_QuestionObjects("",DataTypeUtility.GetString(e.Row.Cells.FromKey("Q_OBJ_ID").Value));

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
        Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps();
        DataTable dataTable                         = questionDeptEmpMaps.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByAllValue(  UltraWebGrid2
                                                            , new string[] {"TGT_DEPT_ID", "TGT_EMP_ID"}
                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
            dataRow["ESTTERM_STEP_ID"]  = ESTTERM_STEP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["Q_OBJ_ID"]         = Q_OBJ_ID;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = questionDeptEmpMaps.AddQuestionDeptEmpMap(dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript("lbnEmpReload", true);
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

            if (chk.Checked && UltraGridUtility.IsColumnValueContains(UltraWebGrid2,row,"EMP_REF_ID","TGT_EMP_ID") == false)
            {
                UltraWebGrid2.Rows.Add();
                cntRow = UltraWebGrid2.Rows.Count - 1;

                UltraWebGrid2.Rows[cntRow].Cells.FromKey("TGT_DEPT_ID").Value   = row.Cells.FromKey("DEPT_REF_ID").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("TGT_EMP_ID").Value    = row.Cells.FromKey("EMP_REF_ID").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("LOGINID").Value       = row.Cells.FromKey("LOGINID").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("DEPT_NAME").Value     = row.Cells.FromKey("DEPT_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("EMP_NAME").Value      = row.Cells.FromKey("EMP_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("Q_OBJ_NAME").Value    = row.Cells.FromKey("Q_OBJ_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("POS_CLS_NAME").Value  = row.Cells.FromKey("POS_CLS_NAME").Value;
                UltraWebGrid2.Rows[cntRow].Cells.FromKey("Q_OBJ_ID").Value      = row.Cells.FromKey("Q_OBJ_ID").Value;
            }
        }

        lblSelect.Text = UltraWebGrid2.Rows.Count.ToString();
    }
}
