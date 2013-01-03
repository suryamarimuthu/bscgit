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

public partial class EST_EST060200 : EstPageBase
{
    private string EST_ID;
    private string Q_OBJ_ID;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            EST_JOB_ID = "JOB_18";

            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");
            DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");

            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("DEPT_NAME").Hidden     = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("EMP_NAME").Hidden      = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_CLS_NAME").Hidden  = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_RNK_NAME").Hidden  = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_DUT_NAME").Hidden  = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_GRP_NAME").Hidden  = true;

            ibnSearch.Attributes.Add("onclick", "return Search();");
            iBtnDeptRemove.Attributes.Add("onclick", "return confirm('선택된 부서를 삭제하시겠습니까?');");
            iBtnEmpRemove.Attributes.Add("onclick", "return confirm('선택된 사원을 삭제하시겠습니까?');");
            ibnConfirm.Attributes.Add("onclick", "return confirm('피평가자 질의매핑을 확정하시겠습니까?')");
            ibnConfirmCancel.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID          = hdfSearchEstID.Value;
        ESTTERM_REF_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        if(ddlEstTermStepID.Visible)
            ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
        else
            ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);

        Q_OBJ_ID        = hdfQObjID.Value;

        ltrScript.Text  = "";
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Binding(COMP_ID, EST_ID);
    }

    private void Binding(int comp_id, string est_id) 
    {
        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        if(!estInfo.IsExists(comp_id, est_id)) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
            ClearValueControls();
            return;
        }

        if (estInfo.Owner_Type.Equals("D"))
        {
            OwnerTypeMode = OwnerType.Dept;

            lblTitle1.Text = "질의 응답 부서 리스트";
            // 질의 응답 부서 리스트
            //imgTitle.ImageUrl                                                            = "../images/title/ta_t16.gif";
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("DEPT_NAME").Width      = Unit.Pixel(300);
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("DEPT_NAME").Hidden     = false;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("EMP_NAME").Hidden      = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_CLS_NAME").Hidden  = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_RNK_NAME").Hidden  = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_DUT_NAME").Hidden  = true;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_GRP_NAME").Hidden  = true;
        }
        else
        {
            OwnerTypeMode = OwnerType.Emp_User;

            lblTitle1.Text = "질의 응답 사원 리스트";
            // 질의 응답 사원 리스트
            //imgTitle.ImageUrl                                                            = "../images/title/ta_t17.gif";
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("DEPT_NAME").Width      = Unit.Pixel(200);
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("DEPT_NAME").Hidden     = false;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("EMP_NAME").Hidden      = false;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_CLS_NAME").Hidden  = false;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_RNK_NAME").Hidden  = false;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_DUT_NAME").Hidden  = false;
            UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("POS_GRP_NAME").Hidden  = false;
        }

        UltraGridUtility.VisiblePosColumn(UltraWebGrid2.DisplayLayout.Bands[0].Columns);
        DropDownListCommom.BindEstTermSub(ddlEstTermSubID, comp_id, est_id, "");
        DropDownListCommom.BindEstTermStep(ddlEstTermStepID, comp_id, est_id);

        BindQuestionGrid();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);

        //imgQDeptEmpMap.Visible = true;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        Biz_QuestionObjects questionObjects        = new Biz_QuestionObjects(hdfSearchEstID.Value, dr["Q_OBJ_ID"].ToString());
        e.Row.Cells.FromKey("Q_OBJ_NAME").Value    = questionObjects.Q_Obj_Name;
        e.Row.Cells.FromKey("Q_OBJ_TITLE").Value   = questionObjects.Q_Obj_Title;
    }
   
    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows[0] != null)
        {
            hdfQObjID.Value     = e.SelectedRows[0].Cells.FromKey("Q_OBJ_ID").Value.ToString();
            Q_OBJ_ID            = hdfQObjID.Value;
            BindQuestionDeptEmpMapGrid();
            ibnDownExcel.Visible = true;
        }
    }

    protected void iBtnDeptRemove_Click(object sender, ImageClickEventArgs e)
    {
        DeleteQuestionDeptEmpMapGrid();
    }

    protected void iBtnEmpRemove_Click(object sender, ImageClickEventArgs e)
    {
        DeleteQuestionDeptEmpMapGrid();
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {
        
    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Q_OBJ_ID != "")
            BindQuestionDeptEmpMapGrid();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Q_OBJ_ID != "")
            BindQuestionDeptEmpMapGrid();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }

    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Q_OBJ_ID != "")
            BindQuestionDeptEmpMapGrid();

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        Binding(COMP_ID, EST_ID);
    }

    private void BindQuestionGrid()
    {
        Biz_QuestionEstMaps questionEstMaps = new Biz_QuestionEstMaps();

        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();

        UltraWebGrid1.DataSource = questionEstMaps.GetQuestionEstMap(EST_ID, "");
        UltraWebGrid1.DataBind();
    }

    private void AddDeptData() 
    {
        Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps();
        DataTable dataTable                         = questionDeptEmpMaps.GetDataTableSchema();

        string[] est_dept_values = hdfEstDept.Value.Split(',');

        for (int i = 0; i < est_dept_values.Length; i++)
        {
            DataRow dataRow = null;

            dataRow = dataTable.NewRow();

            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
            dataRow["ESTTERM_STEP_ID"]  = ESTTERM_STEP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["Q_OBJ_ID"]         = Q_OBJ_ID;
            dataRow["TGT_DEPT_ID"]      = est_dept_values[i];
            dataRow["TGT_EMP_ID"]       = -1;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;

            dataTable.Rows.Add(dataRow);
        }

        bool isOK = questionDeptEmpMaps.UpdateQuestionDeptMap(dataTable
                                                            , COMP_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , EST_ID
                                                            , Q_OBJ_ID);

        if (isOK)
        {
            BindQuestionDeptEmpMapGrid();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서 추가에 실패하였습니다.", false);
        }
    }

    private void BindQuestionDeptEmpMapGrid()
    {
        Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps();

        UltraWebGrid2.Clear();
        DataSet ds = null;

        if (OwnerTypeMode == OwnerType.Emp_User)
        {
            pnlDept.Visible = false;
            pnlEmp.Visible  = true;

            ds = questionDeptEmpMaps.GetQuestionEmpMapping(   COMP_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_ID
                                                            , Q_OBJ_ID
                                                            , 0
                                                            , 0
                                                            , OwnerType.Emp_User);
        }
        else if (OwnerTypeMode == OwnerType.Dept)
        {
            pnlDept.Visible = true;
            pnlEmp.Visible  = false;

            ds = questionDeptEmpMaps.GetQuestionDeptMapping(  COMP_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_ID
                                                            , Q_OBJ_ID
                                                            , 0);

            hdfEstDept.Value = WebUtility.GetValueForSplit(ds.Tables[0]
                                                        , "TGT_DEPT_ID"
                                                        , ",");
        }

        UltraWebGrid2.DataSource = ds;
        UltraWebGrid2.DataBind();
    }

    private void DeleteQuestionDeptEmpMapGrid()
    {
        Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps();
        DataTable dataTable                         = questionDeptEmpMaps.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid2
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "TGT_DEPT_ID", "TGT_EMP_ID" }
                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
            dataRow["EST_ID"]         = EST_ID;
            dataRow["Q_OBJ_ID"]       = hdfQObjID.Value;
        }

        bool isOK = questionDeptEmpMaps.RemoveQuestionDeptEmpMap(dataTable);

        if (!isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        }
        else
        {
            BindQuestionDeptEmpMapGrid();
        }
    }

    protected void lbnDeptReload_Click(object sender, EventArgs e)
    {
        AddDeptData();
    }

    protected void lbnEmpReload_Click(object sender, EventArgs e)
    {
        BindQuestionDeptEmpMapGrid();
    }

    private void ClearValueControls()
    {
        hdfEstDept.Value        = "";
        hdfSearchEstID.Value    = "";
        txtSearchEstName.Text   = "";
    }

    protected void ibnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        bool isJobOK = EstJobUtility.SetConfirmButtonVisible( COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_JOB_ID
                                                            , ibnConfirm
                                                            , ibnConfirmCancel
                                                            , "Y"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        if(isJobOK)
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 피평가자 질의매핑을 확정하였습니다.");
    }

    protected void ibnConfirmCancel_Click(object sender, ImageClickEventArgs e)
    {
        bool isJobOK = EstJobUtility.SetConfirmButtonVisible( COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_JOB_ID
                                                            , ibnConfirm
                                                            , ibnConfirmCancel
                                                            , "N"
                                                            , DateTime.Now
                                                            , EMP_REF_ID
                                                            , ltrScript);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정을 취소하였습니다.");
    }

    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName     = "EST_TGT_" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName    = "EST_TGT_DATA";

        UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("Q_OBJ_NAME").Hidden       = false;
        
        uGridExcelExporter.Export(UltraWebGrid2);

        UltraWebGrid2.DisplayLayout.Bands[0].Columns.FromKey("Q_OBJ_NAME").Hidden       = false;
    }
}