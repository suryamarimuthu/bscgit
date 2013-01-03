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

public partial class EST_EST060500 : EstPageBase
{
    private string EST_ID;
    private string CTRL_ID;
    private string POINT_GRADE_TYPE;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        EST_ID          = "";
        ESTTERM_SUB_ID  = 0;

        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstScopeUnit(ddlScopeUnitID);
            RadioButtonListCommom.BindPointGradeType(rblPointGradeType);
            TextBoxCommon.SetOnlyPercent(txtScope);

            BindCtrlInfo( WebUtility.GetIntByValueDropDownList(ddlCompID)
						, WebUtility.GetIntByValueDropDownList(ddlEstTermRefID)
                        , WebUtility.GetIntByValueDropDownList(ddlEstTermSubID)
						, WebUtility.GetByValueRadioButtonList(rblPointGradeType));

            ibnSave.Attributes.Add("onclick", "return ValidCheck();");

            SetEstJobID();

            ButtonStatusInit();
        }

        COMP_ID             = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID      = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        CTRL_ID             = hdfCtlID.Value;
        POINT_GRADE_TYPE    = WebUtility.GetByValueRadioButtonList(rblPointGradeType);

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    private void SelectCtrlInfo(string ctrl_id)
    {
        Biz_CtrlInfos ctrlInfo = new Biz_CtrlInfos(ctrl_id);
        Biz_EmpInfos empInfo   = new Biz_EmpInfos(ctrlInfo.Ctrl_Emp_ID);
        
        hdfEmpRefID.Value       = DataTypeUtility.GetValue(ctrlInfo.Ctrl_Emp_ID);
        txtEmpName.Text         = empInfo.Emp_Name;
        txtScope.Text           = DataTypeUtility.GetValue(ctrlInfo.Scope);
        WebUtility.FindByValueDropDownList(ddlScopeUnitID, ctrlInfo.Scope);
        ckbAllEstYN.Checked     = DataTypeUtility.GetYNToBoolean(ctrlInfo.All_Est_YN);
        ckbAllEstDeptYN.Checked = DataTypeUtility.GetYNToBoolean(ctrlInfo.All_Est_Dept_YN);
        ckbConfirmEmpYN.Checked = DataTypeUtility.GetYNToBoolean(ctrlInfo.Confirm_Emp_YN);
    }

    private void BindCtrlInfo(int comp_id, int estterm_ref_id, int estterm_sub_id, string point_grade_type)
	{
		uwgCtrlInfo.Clear();

		Biz_CtrlInfos ctrlInfo  = new Biz_CtrlInfos();
		DataSet ds              = ctrlInfo.GetCtrlInfo("", comp_id, estterm_ref_id, estterm_sub_id, point_grade_type);
		uwgCtrlInfo.DataSource  = ds;
		uwgCtrlInfo.DataBind();
	}

    private void BindCtrlEstInfo(string ctrl_id)
    {
        uwgCtrlEstMap.Clear();

        Biz_CtrlEstMaps ctrlEstMap  = new Biz_CtrlEstMaps();
        DataSet ds                  = ctrlEstMap.GetCtrlEstMap(ctrl_id);
        uwgCtrlEstMap.DataSource    = ds;
        uwgCtrlEstMap.DataBind();
    }

    private void BindCtrlEstDeptInfo(string ctrl_id)
    {
        uwgCtrlEstDeptMap.Clear();

        Biz_CtrlDeptMaps ctrlEstDeptMap     = new Biz_CtrlDeptMaps();
        DataSet ds                          = ctrlEstDeptMap.GetCtrlEstDeptMap(ctrl_id);
        uwgCtrlEstDeptMap.DataSource        = ds;
        uwgCtrlEstDeptMap.DataBind();
    }

    protected void uwgCtrlInfo_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;
    }

    protected void uwgCtrlEstMap_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;
    }

    protected void uwgCtrlEstDeptMap_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;
    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCtrlInfo(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, POINT_GRADE_TYPE);

        SetEstJobID();

        ClearValueControls();
        ButtonStatusInit();
    }

    protected void rblPointGradeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCtrlInfo(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, POINT_GRADE_TYPE);

        SetEstJobID();

        ClearValueControls();
        ButtonStatusInit();
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCtrlInfo(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, POINT_GRADE_TYPE);

        SetEstJobID();

        ClearValueControls();
        ButtonStatusInit();
    }

    protected void uwgCtrlInfo_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0) 
        {
            string ctrl_id = e.SelectedRows[0].Cells.FromKey("CTRL_ID").Value.ToString();
            hdfCtlID.Value = ctrl_id;

            SelectCtrlInfo(ctrl_id);
            BindCtrlEstInfo(ctrl_id);
            BindCtrlEstDeptInfo(ctrl_id);

            ButtonStatusModify();
        }
    }

    protected void ibnNew_Click(object sender, ImageClickEventArgs e)
    {
        ButtonStatusNew();
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_CtrlInfos ctrlInfo = new Biz_CtrlInfos();

        if (PageWriteMode == WriteMode.New)
        {
            bool isOK = ctrlInfo.AddCtrlInfo( COMP_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , DataTypeUtility.GetToInt32(hdfEmpRefID.Value)
                                            , DataTypeUtility.GetToFloat(txtScope.Text)
                                            , POINT_GRADE_TYPE
                                            , WebUtility.GetByValueDropDownList(ddlScopeUnitID)
                                            , DataTypeUtility.GetBooleanToYN(ckbAllEstYN.Checked)
                                            , DataTypeUtility.GetBooleanToYN(ckbAllEstDeptYN.Checked)
                                            , DataTypeUtility.GetBooleanToYN(ckbConfirmEmpYN.Checked)
                                            , 0
                                            , DateTime.Now
                                            , EMP_REF_ID);

            if (isOK)
            {
                BindCtrlInfo(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, POINT_GRADE_TYPE);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되지 않았습니다.");
                return;
            }    
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            bool isOK = ctrlInfo.ModifyCtrlInfo(  CTRL_ID
                                                , COMP_ID
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , DataTypeUtility.GetToInt32(hdfEmpRefID.Value)
                                                , DataTypeUtility.GetToFloat(txtScope.Text)
                                                , POINT_GRADE_TYPE
                                                , WebUtility.GetByValueDropDownList(ddlScopeUnitID)
                                                , DataTypeUtility.GetBooleanToYN(ckbAllEstYN.Checked)
                                                , DataTypeUtility.GetBooleanToYN(ckbAllEstDeptYN.Checked)
                                                , DataTypeUtility.GetBooleanToYN(ckbConfirmEmpYN.Checked)
                                                , 0
                                                , DateTime.Now
                                                , EMP_REF_ID);

            if (isOK)
            {
                BindCtrlInfo(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, POINT_GRADE_TYPE);
                ClearValueControls();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되지 않았습니다.");
                return;
            }
        }

        ButtonStatusInit();
    }

    protected void ibnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Biz_CtrlInfos ctrlInfo = new Biz_CtrlInfos();

        bool isOK           = ctrlInfo.RemoveCtrlInfo(CTRL_ID);

        if (isOK)
        {
            BindCtrlInfo(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, POINT_GRADE_TYPE);
            ButtonStatusInit();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제가 처리되지 않았습니다.");
            return;
        }
    }

    protected void ibnDeleteCtrlEstMap_Click(object sender, ImageClickEventArgs e)
    {
        Biz_CtrlEstMaps ctrlEstMap = new Biz_CtrlEstMaps();
        DataTable dataTable        = ctrlEstMap.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(uwgCtrlEstMap
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "CTRL_ID", "EST_ID" }
                                                            , dataTable);

        bool isOK = ctrlEstMap.RemoveCtrlEstMap(dataTable);

        if (isOK)
        {
            BindCtrlEstInfo(CTRL_ID);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        }
    }

    protected void ibnDeleteCtrlEstDeptMap_Click(object sender, ImageClickEventArgs e)
    {
        Biz_CtrlDeptMaps ctrlEstDeptMap  = new Biz_CtrlDeptMaps();
        DataTable dataTable                 = ctrlEstDeptMap.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(uwgCtrlEstDeptMap
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "CTRL_ID", "DEPT_REF_ID" }
                                                            , dataTable);

        bool isOK = ctrlEstDeptMap.RemoveCtrlEstDeptMap(dataTable);

        if (isOK)
        {
            BindCtrlEstDeptInfo(CTRL_ID);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        }
    }

    private void AddCtrlEstData() 
    {
        Biz_CtrlEstMaps ctrlEstMap = new Biz_CtrlEstMaps();
        DataTable dataTable        = ctrlEstMap.GetDataTableSchema();

        string[] est_id_values     = hdfEstIDArr.Value.Split(',');

        foreach (string est_id in est_id_values)
        {
            DataRow dataRow = null;

            dataRow = dataTable.NewRow();

            dataRow["CTRL_ID"]  = CTRL_ID;
            dataRow["COMP_ID"]  = COMP_ID;
            dataRow["EST_ID"]   = est_id;
            dataRow["DATE"]     = DateTime.Now;
            dataRow["USER"]     = EMP_REF_ID;

            dataTable.Rows.Add(dataRow);
        }

        bool isOK = ctrlEstMap.AddCtrlEstMap(dataTable);

        if (isOK)
        {
            BindCtrlEstInfo(CTRL_ID);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가 추가에 실패하였습니다.", false);
        }
    }

    private void AddCtrlEstDeptData() 
    {
        Biz_CtrlDeptMaps ctrlEstDeptMap  = new Biz_CtrlDeptMaps();
        DataTable dataTable              = ctrlEstDeptMap.GetDataTableSchema();

        string[] dept_ref_id_values      = hdfDeptRefIDArr.Value.Split(',');

        foreach (string dept_ref_id in dept_ref_id_values)
        {
            DataRow dataRow = null;

            dataRow = dataTable.NewRow();

            dataRow["CTRL_ID"]          = CTRL_ID;
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["DEPT_REF_ID"]      = dept_ref_id;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;

            dataTable.Rows.Add(dataRow);
        }

        bool isOK = ctrlEstDeptMap.AddCtrlEstDeptMap(dataTable);

        if (isOK)
        {
            BindCtrlEstDeptInfo(CTRL_ID);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서 추가에 실패하였습니다.", false);
        }
    }

    private void SetEstJobID() 
    {
        if(WebUtility.GetByValueRadioButtonList(rblPointGradeType).Equals("PNT")) 
        {
            EST_JOB_ID = "JOB_19";

            ibnConfirm.Attributes.Add("onclick", "return confirm('점수 조정자 설정을 확정하시겠습니까?');");
            ibnConfirmCancel.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
        }
        else if(WebUtility.GetByValueRadioButtonList(rblPointGradeType).Equals("GRD")) 
        {
            EST_JOB_ID = "JOB_20";

            ibnConfirm.Attributes.Add("onclick", "return confirm('등급 조정자 설정을 확정하시겠습니까?');");
            ibnConfirmCancel.Attributes.Add("onclick", "return confirm('확정을 취소하시겠습니까?')");
        }

        EstJobUtility.SetConfirmButtonVisible(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_JOB_ID
                                            , ibnConfirm
                                            , ibnConfirmCancel);
    }

    protected void lbnReload_Est_Click(object sender, EventArgs e)
    {
        AddCtrlEstData();
    }

    protected void lbnReload_EstDept_Click(object sender, EventArgs e)
    {
        AddCtrlEstDeptData();
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
        {
            if(POINT_GRADE_TYPE.Equals("PNT")) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 점수 조정자를 확정하였습니다.");
            }
            else if(POINT_GRADE_TYPE.Equals("GRD")) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등급 조정자를 확정하였습니다.");
            }
        }
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

    private void ClearValueControls()
	{
        hdfEmpRefID.Value       = "";
        txtEmpName.Text         = "";
        txtScope.Text           = "";
        ckbAllEstYN.Checked     = false;
        ckbAllEstDeptYN.Checked = false;
        ckbConfirmEmpYN.Checked = false;
        uwgCtrlEstMap.Clear();
        uwgCtrlEstDeptMap.Clear();
	}

    private void ButtonStatusInit()
	{
		ibnSave.Enabled		        = false;
		ibnDelete.Enabled		    = false;

        tblEst.Visible              = false;
        tblEstDept.Visible          = false;

		ClearValueControls();

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = false;

        tblEst.Visible              = false;
        tblEstDept.Visible          = false;

		ClearValueControls();

        ibnSave.ImageUrl            = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode               = WriteMode.New;
	}

	private void ButtonStatusModify()
	{
		ibnSave.Enabled		        = true;
		ibnDelete.Enabled		    = true;

        tblEst.Visible              = true;
        tblEstDept.Visible          = true;

        ibnSave.ImageUrl            = "../images/btn/b_002.gif";//"저장";

		PageWriteMode               = WriteMode.Modify;
	}
}
