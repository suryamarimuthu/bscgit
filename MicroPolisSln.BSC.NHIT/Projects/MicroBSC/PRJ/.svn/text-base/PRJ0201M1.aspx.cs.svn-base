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
using System.Transactions;

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.PRJ.Biz;

using Infragistics.WebUI.UltraWebGrid;
using System.Drawing;

public partial class PRJ_PRJ0201M1 : PrjPageBase
{
    private string EST_ID = "";

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lbnPrjReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //hdfSearchEstID.Value = WebUtility.GetRequest("EST_ID");
        txtSearchEstName.ReadOnly = true;
        if (!Page.IsPostBack)
        {
            imgEstTgtMap.Visible            = false;
            imgAdd.Visible                  = false;
            iBtnPrjRemove.Visible           = false;
            ibnConfirm.Visible              = false;

            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");
            DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");

            ibnSearch.Attributes.Add("onclick", "return Search();");
            iBtnPrjRemove.Attributes.Add("onclick", "return confirm('선택된 프로젝트를 평가자와의 매핑을 삭제하시겠습니까?');");
            ibnConfirm.Attributes.Add("onclick", "return confirm('매핑하신 평가자 <-> 프로젝트의 정보를 평가리스트로 확정하시겠습니까?')");
            //ibnConfirmCancel.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
        }

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID = hdfSearchEstID.Value;
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);


        if(!Page.IsPostBack)
            BindingData(COMP_ID, EST_ID, ESTTERM_REF_ID);


        ltrScript.Text = "";
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (Check_EST())
        {
            BindingData(COMP_ID, EST_ID, ESTTERM_REF_ID);
            imgEstTgtMap.Visible = true;
        }
        else
        {
            imgEstTgtMap.Visible = false;
            ltrScript.Text = JSHelper.GetAlertScript("평가 성격이 프로젝트평가가 아닙니다.", false);
            return;
        }
    }

    private bool Check_EST()
    {
        Biz_EstInfos objEstInfo = new Biz_EstInfos(COMP_ID, EST_ID);

        if (objEstInfo.Est_Style_ID == "PRJ")
            return true;
        else
            return false;
    }

    private void AddPrjectData()
    {
        Biz_Prj_EmpEstPrjMap objPrjEmpEstPrjMap = new Biz_Prj_EmpEstPrjMap();
        DataTable dataTable = objPrjEmpEstPrjMap.GetDataTableSchema();

        string[] prj_values = hdfPrjRefID.Value.Split(',');

        for (int i = 0; i < prj_values.Length; i++)
        {

            if (!objPrjEmpEstPrjMap.IsExist(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , DataTypeUtility.GetToInt32(this.hdfEstDeptID.Value)
                                            , DataTypeUtility.GetToInt32(this.hdfEstEmpID.Value)
                                            , DataTypeUtility.GetToInt32(prj_values[i])))
            {
                DataRow dataRow = null;

                dataRow = dataTable.NewRow();

                dataRow["COMP_ID"]          = COMP_ID;
                dataRow["EST_ID"]           = EST_ID;
                dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
                dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
                dataRow["ESTTERM_STEP_ID"]  = ESTTERM_STEP_ID;
                dataRow["EST_DEPT_ID"]      = DataTypeUtility.GetToInt32(this.hdfEstDeptID.Value);
                dataRow["EST_EMP_ID"]       = DataTypeUtility.GetToInt32(this.hdfEstEmpID.Value);
                dataRow["PRJ_REF_ID"]       = prj_values[i];
                dataRow["DATE"]             = DateTime.Now;
                dataRow["USER"]             = EMP_REF_ID;

                dataTable.Rows.Add(dataRow);
            }
        }

        bool isOK = objPrjEmpEstPrjMap.AddPrjEmpEstPrjMap(dataTable);

        if (isOK)
        {
            BindingProjectMap();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("프로젝트 추가에 실패하였습니다.", false);
        }
    }

    // 성과 DropDownList의 선택이 바뀌었을 경우
    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeView1.Nodes.Clear();
        TreeViewCommom.BindDept(TreeView1);
        TreeView1.ExpandAll();
       
    }
    protected void ddlEstTermSub_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeView1.Nodes.Clear();
        TreeViewCommom.BindDept(TreeView1);
        TreeView1.ExpandAll();
      
    }
    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeView1.Nodes.Clear();
        TreeViewCommom.BindDept(TreeView1);
        TreeView1.ExpandAll();
        
    }
    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingData(COMP_ID, EST_ID, ESTTERM_REF_ID);
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeView treeView = (TreeView)sender;
        int dept_ref_id = DataTypeUtility.GetToInt32(treeView.SelectedValue);

        Biz_EmpInfos empInfo = new Biz_EmpInfos();

        UltraWebGrid1.DataSource = empInfo.GetEmpByEstDeptIDWithPrefix(dept_ref_id, "EST_");
        UltraWebGrid1.DataBind();

        if (UltraWebGrid1.Rows.Count > 0)
        {
            
            imgAdd.Visible = true;
            iBtnPrjRemove.Visible = true;
            ibnConfirm.Visible = true;
        }
        else
        {
            imgAdd.Visible = false;
            iBtnPrjRemove.Visible = false;
            ibnConfirm.Visible = false;
        }
    }

    private void BindingData(int comp_id, string est_id, int estterm_ref_id)
    {
        if (est_id.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가를 선택하세요.");
            return;
        }

        DropDownListCommom.BindEstTermSub(ddlEstTermSubID, comp_id, est_id, "");
        DropDownListCommom.BindEstTermStep(ddlEstTermStepID, comp_id, est_id);

        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        if (!estInfo.IsExists(comp_id, est_id))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
            return;
        }

        

        if (ddlEstTermRefID.Items.Count > 0)
        {
            TreeViewCommom.BindDept(TreeView1);
        }

    }

    private void BindingProjectMap()
    {
        this.ugrdPrjList.Clear();

        Biz_Prj_EmpEstPrjMap objPrjEmpEstPrjMap = new Biz_Prj_EmpEstPrjMap();

        DataSet ds = objPrjEmpEstPrjMap.GetPrjEmpEstPrjMap(COMP_ID
                                                           , EST_ID
                                                           , ESTTERM_REF_ID
                                                           , ESTTERM_SUB_ID
                                                           , ESTTERM_STEP_ID
                                                           , DataTypeUtility.GetToInt32(this.hdfEstDeptID.Value)
                                                           , DataTypeUtility.GetToInt32(this.hdfEstEmpID.Value)
                                                           , 0);

        ugrdPrjList.DataSource = ds;
        ugrdPrjList.DataBind();
    }

    private void DeleteEmpEstProjectMapGrid()
    {
        Biz_Prj_EmpEstPrjMap objPrjEmpEstPrjMap = new Biz_Prj_EmpEstPrjMap();

        DataTable dataTable = objPrjEmpEstPrjMap.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(ugrdPrjList
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "PRJ_REF_ID", "EST_DEPT_ID", "EST_EMP_ID" }
                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"] = COMP_ID;
            dataRow["EST_ID"] = EST_ID;
            dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
            dataRow["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
        }

        bool isOK = objPrjEmpEstPrjMap.RemovePrjEmpEstPrjMap(dataTable);

        if (!isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        }
        else
        {
            BindingProjectMap();
        }
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {

        if (e.SelectedRows[0] != null)
        {

            imgAdd.Visible = true;
            iBtnPrjRemove.Visible = true;
            ibnConfirm.Visible = true;

            this.ugrdPrjList.Clear();

            this.hdfEstEmpID.Value = e.SelectedRows[0].Cells.FromKey("EST_EMP_ID").Value.ToString();
            this.hdfEstDeptID.Value = e.SelectedRows[0].Cells.FromKey("EST_DEPT_ID").Value.ToString();

            Biz_Prj_EmpEstPrjMap objPrjEmpEstPrjMap = new Biz_Prj_EmpEstPrjMap();

            DataSet ds = objPrjEmpEstPrjMap.GetPrjEmpEstPrjMap(COMP_ID
                                                               , EST_ID
                                                               , ESTTERM_REF_ID
                                                               , ESTTERM_SUB_ID
                                                               , ESTTERM_STEP_ID
                                                               , DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("EST_DEPT_ID").Value)
                                                               , DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("EST_EMP_ID").Value)
                                                               , 0);

            ugrdPrjList.DataSource = ds;
            ugrdPrjList.DataBind();
        }
    }
    protected void iBtnPrjRemove_Click(object sender, ImageClickEventArgs e)
    {
        DeleteEmpEstProjectMapGrid();
    }
    protected void lbnPrjReload_Click(object sender, EventArgs e)
    {
        AddPrjectData();
    }
    protected void ibnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        //bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
        //                                                   , EST_ID
        //                                                   , ESTTERM_REF_ID
        //                                                   , ESTTERM_SUB_ID
        //                                                   , ESTTERM_STEP_ID
        //                                                   , EST_JOB_ID
        //                                                   , ibnConfirm
        //                                                   , ibnConfirmCancel
        //                                                   , "Y"
        //                                                   , DateTime.Now
        //                                                   , EMP_REF_ID
        //                                                   , ltrScript);

        //// 만약 이전에 처리하지 않은 작업이 있다면 아래의 내용을 처리하지 못함
        //if (!isJobOK)
        //    return;

        Biz_Prj_EmpEstPrjMap objPrjEmpEstPrjMap = new Biz_Prj_EmpEstPrjMap();

        DataTable dataTable = objPrjEmpEstPrjMap.GetPrjEmpEstPrjMap(COMP_ID
                                                                , EST_ID
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , ESTTERM_STEP_ID
                                                                , 0
                                                                , 0
                                                                , 0).Tables[0];

        dataTable.Columns.Add("DATE", typeof(DateTime));
        dataTable.Columns.Add("USER", typeof(int));

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["DATE"] = DateTime.Now;
            dataRow["USER"] = EMP_REF_ID;
        }

        Biz_Prj_Data objPrjData = new Biz_Prj_Data();

        bool isOK = objPrjData.CopyTgtMapDataToEstData(dataTable);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가자/사업관리 매핑정보를 평가리스트로 설정 및 확정하였습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("설정 중 오류가 발생하였습니다.");
        }
    }
}
