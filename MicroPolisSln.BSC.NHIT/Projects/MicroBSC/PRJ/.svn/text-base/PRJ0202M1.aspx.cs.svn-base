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

public partial class PRJ_PRJ0202M1 : PrjPageBase
{
    private string EST_ID;
    private string Q_OBJ_ID;

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
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindDefaultValue(ddlEstTermSubID, "----------", "");
            DropDownListCommom.BindDefaultValue(ddlEstTermStepID, "----------", "");

            ibnSearch.Attributes.Add("onclick", "return Search();");
            iBtnPrjRemove.Attributes.Add("onclick", "return confirm('선택된 프로젝트를 질의지와의 매핑을 삭제하시겠습니까?');");
            ibnConfirm.Attributes.Add("onclick", "return confirm('프로젝트 질의매핑을 확정하시겠습니까?')");
            ibnConfirmCancel.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");

            DropDownListCommom.BindEstStyle(ddlEstList, WebUtility.GetIntByValueDropDownList(ddlCompID), "PRJ");
            int marker = 0;
            for (int i = 0; i < ddlEstList.Items.Count; i++)
            {
                if (ddlEstList.Items[marker].Text.Equals("프로젝트기여도평가"))
                {
                    marker++;
                    continue;
                }
                else
                {
                    ddlEstList.Items.RemoveAt(marker);
                }
            }
            
        }

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        
        EST_ID = WebUtility.GetByValueDropDownList(ddlEstList);
        hdfSearchEstID.Value = EST_ID;
        
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);


        if (ddlEstTermStepID.Visible)
            ESTTERM_STEP_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermStepID);
        else
            ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);

        Q_OBJ_ID = hdfQObjID.Value;

        ltrScript.Text = "";
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (Check_EST())
        {
            Binding(COMP_ID, EST_ID);
        }
        else
        {
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

    private void Binding(int comp_id, string est_id)
    {
        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        if (!estInfo.IsExists(comp_id, est_id))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
            ClearValueControls();
            return;
        }

        DropDownListCommom.BindEstTermSub(ddlEstTermSubID, comp_id, est_id, "");
        DropDownListCommom.BindEstTermStep(ddlEstTermStepID, comp_id, est_id);

        BindQuestionGrid();

        this.pnlPrj.Visible = true;

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        Biz_QuestionObjects questionObjects = new Biz_QuestionObjects(hdfSearchEstID.Value, dr["Q_OBJ_ID"].ToString());
        e.Row.Cells.FromKey("Q_OBJ_NAME").Value = questionObjects.Q_Obj_Name;
        e.Row.Cells.FromKey("Q_OBJ_TITLE").Value = questionObjects.Q_Obj_Title;
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows[0] != null)
        {
            hdfQObjID.Value = e.SelectedRows[0].Cells.FromKey("Q_OBJ_ID").Value.ToString();
            Q_OBJ_ID = hdfQObjID.Value;

            BindQuestionProjectMapGrid();
        }
    }

   


    protected void lbnReload_Click(object sender, EventArgs e)
    {

    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Q_OBJ_ID != "")
            BindQuestionProjectMapGrid();

        //EstJobUtility.SetConfirmButtonVisible(COMP_ID
        //                                    , EST_ID
        //                                    , ESTTERM_REF_ID
        //                                    , ESTTERM_SUB_ID
        //                                    , ESTTERM_STEP_ID
        //                                    , EST_JOB_ID
        //                                    , ibnConfirm
        //                                    , ibnConfirmCancel);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Q_OBJ_ID != "")
            BindQuestionProjectMapGrid();

        //EstJobUtility.SetConfirmButtonVisible(COMP_ID
        //                                    , EST_ID
        //                                    , ESTTERM_REF_ID
        //                                    , ESTTERM_SUB_ID
        //                                    , ESTTERM_STEP_ID
        //                                    , EST_JOB_ID
        //                                    , ibnConfirm
        //                                    , ibnConfirmCancel);
    }

    protected void ddlEstTermStepID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Q_OBJ_ID != "")
            BindQuestionProjectMapGrid();

        //EstJobUtility.SetConfirmButtonVisible(COMP_ID
        //                                    , EST_ID
        //                                    , ESTTERM_REF_ID
        //                                    , ESTTERM_SUB_ID
        //                                    , ESTTERM_STEP_ID
        //                                    , EST_JOB_ID
        //                                    , ibnConfirm
        //                                    , ibnConfirmCancel);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        Binding(COMP_ID, EST_ID);
    }

    private void BindQuestionGrid()
    {
        Biz_QuestionEstMaps questionEstMaps = new Biz_QuestionEstMaps();

        UltraWebGrid1.Clear();
        ugrdPrjList.Clear();

        UltraWebGrid1.DataSource = questionEstMaps.GetQuestionEstMap(EST_ID, "");
        UltraWebGrid1.DataBind();
    }

    private void AddPrjectData()
    {
        Biz_Prj_QuestionPrjMap objQuestionPrjMap = new Biz_Prj_QuestionPrjMap();
        DataTable dataTable = objQuestionPrjMap.GetDataTableSchema();

        string[] prj_values = hdfPrjRefID.Value.Split(',');

        for (int i = 0; i < prj_values.Length; i++)
        {

            if (!objQuestionPrjMap.IsExist(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, EST_ID, Q_OBJ_ID,DataTypeUtility.GetToInt32(prj_values[i])))
            {
                DataRow dataRow = null;

                dataRow = dataTable.NewRow();

                dataRow["COMP_ID"] = COMP_ID;
                dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
                dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
                dataRow["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
                dataRow["EST_ID"] = EST_ID;
                dataRow["Q_OBJ_ID"] = Q_OBJ_ID;
                dataRow["PRJ_REF_ID"] = prj_values[i];
                dataRow["DATE"] = DateTime.Now;
                dataRow["USER"] = EMP_REF_ID;

                dataTable.Rows.Add(dataRow);
            }
        }

        bool isOK = objQuestionPrjMap.AddQuestionProjectMap(dataTable);

        if (isOK)
        {
            BindQuestionProjectMapGrid();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("프로젝트 추가에 실패하였습니다.", false);
        }
    }

    private void BindQuestionProjectMapGrid()
    {
        Biz_Prj_QuestionPrjMap objQuestionPrjMap = new Biz_Prj_QuestionPrjMap();

        ugrdPrjList.Clear();
        DataSet ds = null;

        ds = objQuestionPrjMap.GetQuestionProjectMapping(COMP_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , EST_ID
                                                        , Q_OBJ_ID
                                                        , 0 );

        //    hdfEstDept.Value = WebUtility.GetValueForSplit(ds.Tables[0]
        //                                                , "TGT_DEPT_ID"
        //                                                , ",");


        ugrdPrjList.DataSource = ds;
        ugrdPrjList.DataBind();
    }

    private void DeleteQuestionProjectMapGrid()
    {
        Biz_Prj_QuestionPrjMap objQuestionPrjMap = new Biz_Prj_QuestionPrjMap();

        DataTable dataTable = objQuestionPrjMap.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(ugrdPrjList
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "PRJ_REF_ID" }
                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"] = COMP_ID;
            dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
            dataRow["EST_ID"] = EST_ID;
            dataRow["Q_OBJ_ID"] = hdfQObjID.Value;
        }

        bool isOK = objQuestionPrjMap.RemoveQuestionProjectMap(dataTable);

        if (!isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        }
        else
        {
            BindQuestionProjectMapGrid();
        }
    }

  

    protected void lbnEmpReload_Click(object sender, EventArgs e)
    {
        BindQuestionProjectMapGrid();
    }

    private void ClearValueControls()
    {
        hdfPrjRefID.Value = "";
        hdfSearchEstID.Value = "";
        //txtSearchEstName.Text = "";
    }

    protected void ibnConfirm_Click(object sender, ImageClickEventArgs e)
    {
        //bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
        //                                                    , EST_ID
        //                                                    , ESTTERM_REF_ID
        //                                                    , ESTTERM_SUB_ID
        //                                                    , ESTTERM_STEP_ID
        //                                                    , EST_JOB_ID
        //                                                    , ibnConfirm
        //                                                    , ibnConfirmCancel
        //                                                    , "Y"
        //                                                    , DateTime.Now
        //                                                    , EMP_REF_ID
        //                                                    , ltrScript);

        //if (isJobOK)
        //    ltrScript.Text = JSHelper.GetAlertScript("정상적으로 피평가자 질의매핑을 확정하였습니다.");
    }

    protected void ibnConfirmCancel_Click(object sender, ImageClickEventArgs e)
    {
        //bool isJobOK = EstJobUtility.SetConfirmButtonVisible(COMP_ID
        //                                                    , EST_ID
        //                                                    , ESTTERM_REF_ID
        //                                                    , ESTTERM_SUB_ID
        //                                                    , ESTTERM_STEP_ID
        //                                                    , EST_JOB_ID
        //                                                    , ibnConfirm
        //                                                    , ibnConfirmCancel
        //                                                    , "N"
        //                                                    , DateTime.Now
        //                                                    , EMP_REF_ID
        //                                                    , ltrScript);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 확정을 취소하였습니다.");
    }
    protected void ugrdPrjList_InitializeRow(object sender, RowEventArgs e)
    {

    }
    protected void iBtnPrjRemove_Click(object sender, ImageClickEventArgs e)
    {
        DeleteQuestionProjectMapGrid();
    }
    protected void lbnPrjReload_Click(object sender, EventArgs e)
    {
        AddPrjectData();
    }
}
