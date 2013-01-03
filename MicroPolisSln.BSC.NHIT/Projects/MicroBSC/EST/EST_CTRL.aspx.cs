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

// 제    목 : 조정 팝업 페이지
// 내    용 : 성과평가 점수 및 등급을 조정하기 위한 페이지
public partial class EST_EST_CTRL : EstPageBase
{
    private string CTRL_ID;
    private string EST_ID;
    private string POINT_GRADE_TYPE;
    private int EST_DEPT_ID;
    private int EST_EMP_ID;
    private int CTRL_EMP_ID;
    private int TGT_DEPT_ID;
    private int TGT_EMP_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        CTRL_ID             = WebUtility.GetRequest("CTRL_ID");
        COMP_ID             = WebUtility.GetRequestByInt("COMP_ID");
        EST_ID              = WebUtility.GetRequest("EST_ID");
        ESTTERM_REF_ID      = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID      = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
        POINT_GRADE_TYPE    = WebUtility.GetRequest("POINT_GRADE_TYPE");
        EST_DEPT_ID         = WebUtility.GetRequestByInt("EST_DEPT_ID");
        EST_EMP_ID          = WebUtility.GetRequestByInt("EST_EMP_ID");
        CTRL_EMP_ID         = WebUtility.GetRequestByInt("CTRL_EMP_ID");
        TGT_DEPT_ID         = WebUtility.GetRequestByInt("TGT_DEPT_ID");
        TGT_EMP_ID          = WebUtility.GetRequestByInt("TGT_EMP_ID");

        if(!Page.IsPostBack) 
        {
            if(CTRL_EMP_ID != EMP_REF_ID) 
            {
                Response.Write(JSHelper.GetAlertScript("조정자와 접근한 조정 페이지의 권한자와 같지 않습니다.", true));
            }

            // 현재 평가의 주체가 부서/ 사원인지 구분
            if(TGT_EMP_ID >= -1) 
            {
                trTgtDeptName.Visible = true;
                trTgtEmpName.Visible  = false;

                Biz_DeptInfos deptInfo  = new Biz_DeptInfos(TGT_DEPT_ID);
                lblTgtDeptName.Text     = deptInfo.Dept_Name;
            }
            else 
            {
                trTgtDeptName.Visible = false;
                trTgtEmpName.Visible  = true;

                Biz_DeptInfos deptInfo  = new Biz_DeptInfos(TGT_DEPT_ID);
                Biz_EmpInfos empInfo    = new Biz_EmpInfos(TGT_EMP_ID);
                lblTgtEmpName.Text      = string.Format("{0} / {1}", deptInfo.Dept_Name, empInfo.Emp_Name);
            }

            Biz_Datas data          = new Biz_Datas(  COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID
                                                    , EST_DEPT_ID
                                                    , EST_EMP_ID
                                                    , TGT_DEPT_ID
                                                    , TGT_EMP_ID);

            Biz_EstInfos estInfo   = new Biz_EstInfos(COMP_ID, EST_ID);
            Biz_CtrlInfos ctrlInfo = new Biz_CtrlInfos(CTRL_ID);

            if(ctrlInfo.Ctrl_Emp_ID == CTRL_EMP_ID)
            {
                ibnSave.Visible = true;
            }
            else 
            {
                BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnSave);
                
                ibnSave.Visible = false;
            }

            if(    ctrlInfo.Ctrl_Emp_ID     == CTRL_EMP_ID 
                && ctrlInfo.Confirm_Emp_YN  == "Y")
            {
                ibnCtrlConfirm.Visible = true;
            }
            else 
            {
                BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnCtrlConfirm);
                
                ibnCtrlConfirm.Visible = false;
            }

            if(POINT_GRADE_TYPE.Equals("PNT")) 
            {
                TextBoxCommon.SetOnlyPercent(txtCtrlPoint);

                imgTitle.Src        = "../images/title/popup_t73.gif";
                trCurPoint.Visible  = true;
                trCurGrade.Visible  = false;
                trCtrlPoint.Visible = true;
                trCtrlGrade.Visible = false;
                UltraWebGrid1.Bands[0].Columns.FromKey("CTRL_GRADE_NAME").Hidden = true;

                lblPoint.Text       = data.Point.ToString("#,##0.00");
                lblCtrlMsg.Text     = string.Format("- {0}는 {1}차까지 점수조정 가능합니다.", estInfo.Est_Name, estInfo.Point_Ctrl_Step);
                hdfCtrlStep.Value   = estInfo.Point_Ctrl_Step.ToString();
            }
            else if(POINT_GRADE_TYPE.Equals("GRD")) 
            {
                DropDownListCommom.BindGrade(ddlCtrlGradeID, COMP_ID);
                WebUtility.FindByValueDropDownList(ddlCtrlGradeID, data.Grade_ID);

                imgTitle.Src        = "../images/title/popup_t72.gif";
                trCurPoint.Visible  = false;
                trCurGrade.Visible  = true;
                trCtrlPoint.Visible = false;
                trCtrlGrade.Visible = true;
                UltraWebGrid1.Bands[0].Columns.FromKey("CTRL_POINT").Hidden = true;

                lblGrade.Text       = new Biz_Grades(COMP_ID, data.Grade_ID).Grade_Name;
                lblCtrlMsg.Text     = string.Format("- {0}는 {1}차까지 등급조정 가능합니다.", estInfo.Est_Name, estInfo.Grade_Ctrl_Step);
                hdfCtrlStep.Value   = estInfo.Grade_Ctrl_Step.ToString();
            }
            else 
            {
                ltrScript.Text = JSHelper.GetAlertScript("조정 타입이 없습니다.", true);
            }

            GridBinding();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        
    }

    private void GridBinding() 
    {
        DataSet ds = null;

        if(POINT_GRADE_TYPE.Equals("PNT")) 
        {
            Biz_CtrlPointDatas ctrlPointData    = new Biz_CtrlPointDatas();
            ds                                  = ctrlPointData.GetCtrlPointData( COMP_ID
                                                                                , EST_ID
                                                                                , ESTTERM_REF_ID
                                                                                , ESTTERM_SUB_ID
                                                                                , ESTTERM_STEP_ID
                                                                                , CTRL_EMP_ID
                                                                                , TGT_DEPT_ID
                                                                                , TGT_EMP_ID
                                                                                , 0);
        }
        else if(POINT_GRADE_TYPE.Equals("GRD")) 
        {
            Biz_CtrlGradeDatas ctrlGradeData    = new Biz_CtrlGradeDatas();
            ds                                  = ctrlGradeData.GetCtrlGradeData( COMP_ID
                                                                                , EST_ID
                                                                                , ESTTERM_REF_ID
                                                                                , ESTTERM_SUB_ID
                                                                                , ESTTERM_STEP_ID
                                                                                , CTRL_EMP_ID
                                                                                , TGT_DEPT_ID
                                                                                , TGT_EMP_ID
                                                                                , 0);
        }

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        // 자신이 조정한 정보가 존재한다면 신규버튼을 숨김
        if(ds.Tables[0].Select(string.Format("CTRL_EMP_ID = {0}", CTRL_EMP_ID)).Length > 0)
        {
           ibnNew.Visible = false;
        }
        else 
        {
            // 평가별 평가 차수와 현재 등록된 차수가 같거나 클 경우 신규버튼을 숨김
            if(ds.Tables[0].Rows.Count >= DataTypeUtility.GetToInt32(hdfCtrlStep.Value)) 
            {
                ibnNew.Visible = false;
            }
        }
    }

    protected void ibnNew_Click(object sender, ImageClickEventArgs e)
    {
        ButtonStatusByNew();
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_CtrlPointDatas ctrlPointData = new Biz_CtrlPointDatas();
        Biz_CtrlGradeDatas ctrlGradeData = new Biz_CtrlGradeDatas();

        bool isOK = false;

        if (PageWriteMode == WriteMode.New)
        {
            if(POINT_GRADE_TYPE.Equals("PNT")) 
            {
                if (txtCtrlPoint.Text.Equals("")) 
                {
                    ltrScript.Text = JSHelper.GetAlertScript("조정점수를 입력하세요.");
                    return;
                }

                isOK = ctrlPointData.AddCtrlPointData(COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID
                                                    , CTRL_EMP_ID
                                                    , TGT_DEPT_ID
                                                    , TGT_EMP_ID
                                                    , DataTypeUtility.GetToFloat(txtCtrlPoint.Text)
                                                    , txtCtrlOpinion.Text
                                                    , DateTime.Now
                                                    , EMP_REF_ID);
            }
            else if(POINT_GRADE_TYPE.Equals("GRD")) 
            {
                isOK = ctrlGradeData.AddCtrlGradeData(COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID
                                                    , CTRL_EMP_ID
                                                    , TGT_DEPT_ID
                                                    , TGT_EMP_ID
                                                    , WebUtility.GetByValueDropDownList(ddlCtrlGradeID)
                                                    , txtCtrlOpinion.Text
                                                    , DateTime.Now
                                                    , EMP_REF_ID);
            }

            if (isOK)
            {
                GridBinding();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되지 않았습니다.");
                return;
            }    
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            if(POINT_GRADE_TYPE.Equals("PNT")) 
            {
                if (txtCtrlPoint.Text.Equals("")) 
                {
                    ltrScript.Text = JSHelper.GetAlertScript("조정점수를 입력하세요.");
                    return;
                }

                isOK = ctrlPointData.ModifyCtrlPointData( DataTypeUtility.GetToInt32(hdfCompID.Value)
                                                        , hdfEstID.Value
                                                        , DataTypeUtility.GetToInt32(hdfEstTermRefID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfEstTermSubID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfEstTermStepID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfCtrlEmpID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfTgtDeptID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfTgtEmpID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfCtrlSeq.Value)
                                                        , DataTypeUtility.GetToFloat(txtCtrlPoint.Text)
                                                        , txtCtrlOpinion.Text
                                                        , DateTime.Now
                                                        , EMP_REF_ID);
            }
            else if(POINT_GRADE_TYPE.Equals("GRD")) 
            {
                isOK = ctrlGradeData.ModifyCtrlGradeData( DataTypeUtility.GetToInt32(hdfCompID.Value)
                                                        , hdfEstID.Value
                                                        , DataTypeUtility.GetToInt32(hdfEstTermRefID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfEstTermSubID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfEstTermStepID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfCtrlEmpID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfTgtDeptID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfTgtEmpID.Value)
                                                        , DataTypeUtility.GetToInt32(hdfCtrlSeq.Value)
                                                        , WebUtility.GetByValueDropDownList(ddlCtrlGradeID)
                                                        , txtCtrlOpinion.Text
                                                        , DateTime.Now
                                                        , EMP_REF_ID);
            }

            if (isOK)
            {
                GridBinding();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되지 않았습니다.");
                return;
            }
        }

        ButtonStatusByInit();
    }

    protected void ibnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Data;
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0) 
        {
            int comp_id         = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("COMP_ID").Value);
            string est_id       = e.SelectedRows[0].Cells.FromKey("EST_ID").Value.ToString();
            int estterm_ref_id  = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("ESTTERM_REF_ID").Value);
            int estterm_sub_id  = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("ESTTERM_SUB_ID").Value);
            int estterm_step_id = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("ESTTERM_STEP_ID").Value);
            int ctrl_emp_id     = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("CTRL_EMP_ID").Value);
            int tgt_dept_id     = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("TGT_DEPT_ID").Value);
            int tgt_emp_id      = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("TGT_EMP_ID").Value);
            int ctrl_seq        = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("CTRL_SEQ").Value);

            hdfCompID.Value         = e.SelectedRows[0].Cells.FromKey("COMP_ID").Value.ToString();
            hdfEstID.Value          = e.SelectedRows[0].Cells.FromKey("EST_ID").Value.ToString();
            hdfEstTermRefID.Value   = e.SelectedRows[0].Cells.FromKey("ESTTERM_REF_ID").Value.ToString();
            hdfEstTermSubID.Value   = e.SelectedRows[0].Cells.FromKey("ESTTERM_SUB_ID").Value.ToString();
            hdfEstTermStepID.Value  = e.SelectedRows[0].Cells.FromKey("ESTTERM_STEP_ID").Value.ToString();
            hdfCtrlEmpID.Value      = e.SelectedRows[0].Cells.FromKey("CTRL_EMP_ID").Value.ToString();
            hdfTgtDeptID.Value      = e.SelectedRows[0].Cells.FromKey("TGT_DEPT_ID").Value.ToString();
            hdfTgtEmpID.Value       = e.SelectedRows[0].Cells.FromKey("TGT_EMP_ID").Value.ToString();
            hdfCtrlSeq.Value        = e.SelectedRows[0].Cells.FromKey("CTRL_SEQ").Value.ToString();

            SelectCtrlData(comp_id
                        , est_id
                        , estterm_ref_id
                        , estterm_sub_id
                        , estterm_step_id
                        , ctrl_emp_id
                        , tgt_dept_id
                        , tgt_emp_id
                        , ctrl_seq);

            ButtonStatusByModify();
        }
    }

    private void SelectCtrlData( int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , int ctrl_emp_id
                                , int tgt_dept_id
                                , int tgt_emp_id
                                , int ctrl_seq)
    {
        if(POINT_GRADE_TYPE.Equals("PNT")) 
        {
            Biz_CtrlPointDatas ctrlPointData = new Biz_CtrlPointDatas(comp_id
                                                                    , est_id
                                                                    , estterm_ref_id
                                                                    , estterm_sub_id
                                                                    , estterm_step_id
                                                                    , ctrl_emp_id
                                                                    , tgt_dept_id
                                                                    , tgt_emp_id
                                                                    , ctrl_seq);

            txtCtrlPoint.Text   = ctrlPointData.Ctrl_Point.ToString();
            txtCtrlOpinion.Text = ctrlPointData.Ctrl_Opinion;
        }
        else if(POINT_GRADE_TYPE.Equals("GRD")) 
        {
            Biz_CtrlGradeDatas ctrlGradeData = new Biz_CtrlGradeDatas(comp_id
                                                                    , est_id
                                                                    , estterm_ref_id
                                                                    , estterm_sub_id
                                                                    , estterm_step_id
                                                                    , ctrl_emp_id
                                                                    , tgt_dept_id
                                                                    , tgt_emp_id
                                                                    , ctrl_seq);

            WebUtility.FindByValueDropDownList(ddlCtrlGradeID, ctrlGradeData.Ctrl_Grade_ID);
            txtCtrlOpinion.Text = ctrlGradeData.Ctrl_Opinion;
        }
    }

    protected void ibnCtrlConfirm_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dataTable = null;
        bool isOK           = false;

        Biz_Datas data          = new Biz_Datas(  COMP_ID
                                                , EST_ID
                                                , ESTTERM_REF_ID
                                                , ESTTERM_SUB_ID
                                                , ESTTERM_STEP_ID
                                                , EST_DEPT_ID
                                                , EST_EMP_ID
                                                , TGT_DEPT_ID
                                                , TGT_EMP_ID);

        if(POINT_GRADE_TYPE.Equals("PNT")) 
        {
            Biz_CtrlPointDatas ctrlPointData = new Biz_CtrlPointDatas();
            dataTable = ctrlPointData.GetDataTableSchema();

            dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                                , "ckbCtrlConfirm"
                                                                , "CTRL_CONFIRM"
                                                                , new string[] { "CTRL_SEQ", "CTRL_POINT" }
                                                                , dataTable);

            if(dataTable.Rows.Count == 0) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("점수 조정확정 체크박스에 선택된 항목이 없습니다.");
                return;
            }
            else if(dataTable.Rows.Count > 1) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("두개 이상 항목이 체크될 수 없습니다.");
                return;
            }

            isOK = data.CtrlPoint(COMP_ID
                                , EST_ID
                                , ESTTERM_REF_ID
                                , ESTTERM_SUB_ID
                                , ESTTERM_STEP_ID
                                , EST_DEPT_ID
                                , EST_EMP_ID
                                , TGT_DEPT_ID
                                , TGT_EMP_ID
                                , CTRL_EMP_ID
                                , DataTypeUtility.GetToInt32(dataTable.Rows[0]["CTRL_SEQ"])
                                , data.Point
                                , DataTypeUtility.GetToFloat(dataTable.Rows[0]["CTRL_POINT"])
                                , DateTime.Now
                                , DateTime.Now
                                , EMP_REF_ID);
            
            if(isOK)
            {
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 점수조정이 확정되었습니다.", "lbnReload", true);
            }
            else 
            {
                ltrScript.Text = JSHelper.GetAlertScript("점수조정 확정 중 오류가 발생하였습니다.");
            }
        }
        else if(POINT_GRADE_TYPE.Equals("GRD")) 
        {
            Biz_CtrlGradeDatas ctrlGradeData = new Biz_CtrlGradeDatas();
            dataTable = ctrlGradeData.GetDataTableSchema();

            dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                                , "ckbCtrlConfirm"
                                                                , "CTRL_CONFIRM"
                                                                , new string[] { "CTRL_SEQ", "CTRL_GRADE_ID" }
                                                                , dataTable);

            if(dataTable.Rows.Count == 0) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("등급 조정확정 체크박스에 선택된 항목이 없습니다.");
                return;
            }
            else if(dataTable.Rows.Count > 1) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("두개 이상 항목이 체크될 수 없습니다.");
                return;
            }

            isOK = data.CtrlGrade(COMP_ID
                                , EST_ID
                                , ESTTERM_REF_ID
                                , ESTTERM_SUB_ID
                                , ESTTERM_STEP_ID
                                , EST_DEPT_ID
                                , EST_EMP_ID
                                , TGT_DEPT_ID
                                , TGT_EMP_ID
                                , CTRL_EMP_ID
                                , DataTypeUtility.GetToInt32(dataTable.Rows[0]["CTRL_SEQ"])
                                , data.Grade_ID
                                , DataTypeUtility.GetValue(dataTable.Rows[0]["CTRL_GRADE_ID"])
                                , DateTime.Now
                                , DateTime.Now
                                , EMP_REF_ID);
            
            if(isOK)
            {
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 등급조정이 확정되었습니다.", "lbnReload", true);
            }
            else 
            {
                ltrScript.Text = JSHelper.GetAlertScript("등급조정 확정 중 오류가 발생하였습니다.");
            }
        }
    }

    private void ClearValueControls() 
    {
        txtCtrlPoint.Text   = "";
        txtCtrlOpinion.Text = "";
    }

    private void ButtonStatusByInit() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = false;
        ibnDelete.Enabled       = false;

        ClearValueControls();

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.None;
    }

    private void ButtonStatusByNew() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;
        ibnDelete.Enabled       = false;

        ClearValueControls();

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.New;
    }

    private void ButtonStatusByModify() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;

        if(hdfCtrlEmpID.Value == CTRL_EMP_ID.ToString())
            ibnDelete.Enabled       = true;

        ibnSave.ImageUrl        = "../images/btn/b_002.gif";//"수정";

        PageWriteMode           = WriteMode.Modify;
    }
}
