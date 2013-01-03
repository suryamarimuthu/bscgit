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

public partial class EST_EST010300 : EstPageBase
{
    private DataTable _dtEstJobMap          = null;
    private DataTable DT_ESTTERM_SUB_MAP    = null;
    private DataTable DT_ESTTERM_STEP_MAP   = null;

    //private bool IVISIBLE_PAST_POINT_YN
    //{
    //    get
    //    {
    //        if (ViewState["VISIBLE_PAST_POINT_YN"] == null)
    //            ViewState["VISIBLE_PAST_POINT_YN"] = false;
    //        return (bool)ViewState["VISIBLE_PAST_POINT_YN"];
    //    }
    //    set
    //    {
    //        ViewState["VISIBLE_PAST_POINT_YN"] = value;
    //    }
    //}
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load( object sender, EventArgs e )
	{
        if (!IsPostBack)
        {
            //2011.10.28 허성덕과장요청(자화전자 요청)으로 박효동작업(개인평가의 과거년도 개인점수 컬럼들 보이기여부 컬럼 자동추가.
            //Biz_Datas biz = new Biz_Datas();
            //biz.ConfirmNewColumn("EST_INFO", "VISIBLE_PAST_POINT_YN", "ALTER TABLE EST_INFO ADD VISIBLE_PAST_POINT_YN CHAR(1) NULL DEFAULT('Y')");

            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            TreeViewCommom.BindEst(TreeView1, WebUtility.GetIntByValueDropDownList(ddlCompID));

            RadioButtonListCommom.BindYN(rblGradeConfirmYN);
            DropDownListCommom.BindBiasType(ddlBiasTypeID);
            RadioButtonListCommom.BindYN(rblBiasYN);
            RadioButtonListCommom.BindYN(rblBiasDeptUseID);
            RadioButtonListCommom.BindYN(rblFixedWeightUseYN);
            RadioButtonListCommom.BindTgtSendType(rblTgtSendType);
            DropDownListCommom.BindSetCtrlStep(ddlPointCtrlStep);
            DropDownListCommom.BindSetCtrlStep(ddlGradeCtrlStep);
            RadioButtonListCommom.BindEstimate(rblOwnerType);
            RadioButtonListCommom.BindEstStyle(rblEstStyle);
            RadioButtonListCommom.BindWeightType(rblWeightType);
            RadioButtonListCommom.BindScaleType(rblScaleType);
            DropDownListCommom.BindStatusStyle(ddlStatusStyleID);
            DropDownListCommom.BindQuestionPageStyle(ddlQuestionStyleID);
            RadioButtonListCommom.BindYN(rblQItemDescUseYN);
            RadioButtonListCommom.BindYN(rblQTgtPosBizUseYN);
            RadioButtonListCommom.BindYN(rblAllStepVisibleYN);
            RadioButtonListCommom.BindYN(rblEmpComDeptYN);
            RadioButtonListCommom.BindUseYN(rblUseYN);
            RadioButtonListCommom.BindVisiblePastPointYN(rblVisiblePastPointYN);
            RadioButtonListCommom.BindEstQTTMBOYN(rblEstQTTMBOYN);
            RadioButtonListCommom.BindMboScoreEstimateYN(rblMboScoreEstimateYN);
            RadioButtonListCommom.BindDashBoardTYPE(rblDashBoardTYPE);
            DropDownListCommom.BindDashBoardType(ddlDashBoardTYPE);
            DropDownListCommom.BindQuestionPreviousStepYN(ddlPreviousStempYN);

            //CheckBoxListCommon.BindEstTermSub(cblEstTermSub, WebUtility.GetIntByValueDropDownList(ddlCompID), "N");
            //CheckBoxListCommon.BindEstTermStep(cblEstTermStep, WebUtility.GetIntByValueDropDownList(ddlCompID), "N");

            BindEstJob(0, "");

            ButtonStatusInit();
        }
        else
        {
            rblDashBoardTYPE.Items[0].Attributes.Add("OnClick", "displayDashboarDDL('Y')");
            rblDashBoardTYPE.Items[1].Attributes.Add("OnClick", "displayDashboarDDL('N')");

            //평가질의지 이전차수 보이기여부
            //for (int i = 0; i < ddlQuestionStyleID.Items.Count; i++)
            //{
            //    if (ddlQuestionStyleID.Items[i].Value == "BLK")
            //        ddlQuestionStyleID.Items[i].Attributes.Add("onchange", "displayPreviousStepDDL('N')");
            //    else
            //        ddlQuestionStyleID.Items[i].Attributes.Add("onchange", "displayPreviousStepDDL('Y')");

            //}
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);

		ltrScript.Text  = "";
	}

	protected void Page_PreRender( object sender, EventArgs e )
	{

	}

	private void GridBinding(int comp_id)
	{
		TreeViewCommom.BindEst(TreeView1, comp_id);
	}

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        txtQueryString.Text = string.Empty;
		hdfEstID.Value	= TreeView1.SelectedValue;

		CheckBoxListCommon.Check( cblEstTermSub, false );
		CheckBoxListCommon.Check( cblEstTermStep, false );

        ViewOne(COMP_ID, hdfEstID.Value);
		ButtonStatusModify();
    }

	private void ViewOne(int comp_id, string est_id )
	{
		Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

		txtEstID.Text   = estInfo.Est_ID;
		txtEstName.Text = estInfo.Est_Name;

		if ( estInfo.Up_Est_ID != DBNull.Value )
		{
			Biz_EstInfos upEstInfo  = new Biz_EstInfos(comp_id, estInfo.Up_Est_ID.ToString());
			txtUpEstID.Text         = upEstInfo.Est_Name;
			hdfUpEstID.Value        = estInfo.Up_Est_ID.ToString();
		}

		txtHeaderColor.Text         = estInfo.Header_Color;

        WebUtility.FindByValueRadioButtonList( rblFixedWeightUseYN, estInfo.Fixed_Weight_Use_YN );
        txtFixedWeight.Text         = estInfo.Fixed_Weight.ToString();
        TextBoxCommon.SetOnlyPercent(txtFixedWeight);

        rblFixedWeightUseYN_SelectedIndexChanged(rblFixedWeightUseYN, null);

		WebUtility.FindByValueRadioButtonList( rblGradeConfirmYN, estInfo.Grade_Confirm_YN );
		WebUtility.FindByValueRadioButtonList( rblBiasYN, estInfo.Bias_YN );
        WebUtility.FindByValueRadioButtonList( rblBiasDeptUseID, estInfo.Bias_Dept_Use_YN );

        if(estInfo.Tgt_Opinion_YN.Equals("Y") && estInfo.FeedBack_YN.Equals("N")) 
        {
            WebUtility.FindByValueRadioButtonList( rblTgtSendType, "OPN");
        }
        else if(estInfo.Tgt_Opinion_YN.Equals("N") && estInfo.FeedBack_YN.Equals("Y")) 
        {
            WebUtility.FindByValueRadioButtonList( rblTgtSendType, "FBK");
        }
        else 
        {
            WebUtility.FindByValueRadioButtonList( rblTgtSendType, "N");
        }
        
		WebUtility.FindByValueDropDownList( ddlPointCtrlStep, estInfo.Point_Ctrl_Step );
		WebUtility.FindByValueDropDownList( ddlGradeCtrlStep, estInfo.Grade_Ctrl_Step );
		WebUtility.FindByValueRadioButtonList( rblOwnerType, estInfo.Owner_Type );
		WebUtility.FindByValueRadioButtonList( rblEstStyle, estInfo.Est_Style_ID );

        if ( estInfo.Link_Est_ID != "" )
		{
			Biz_EstInfos lnkEstInfo = new Biz_EstInfos(comp_id, estInfo.Link_Est_ID);
			txtLinkEstID.Text       = lnkEstInfo.Est_Name;
			hdfLinkEstID.Value      = estInfo.Link_Est_ID;
		}

		WebUtility.FindByValueRadioButtonList( rblWeightType, estInfo.Weight_Type );
        WebUtility.FindByValueRadioButtonList( rblScaleType, estInfo.Scale_Type );
        WebUtility.FindByValueDropDownList( ddlStatusStyleID, estInfo.Status_Style_ID );
        WebUtility.FindByValueDropDownList( ddlQuestionStyleID, estInfo.Q_Style_ID );
        WebUtility.FindByValueDropDownList( ddlBiasTypeID, estInfo.Bias_Type_ID );
        WebUtility.FindByValueRadioButtonList( rblQItemDescUseYN, estInfo.Q_Item_Desc_Use_YN );
        WebUtility.FindByValueRadioButtonList( rblQTgtPosBizUseYN, estInfo.Q_Tgt_Pos_Biz_Use_YN );
        WebUtility.FindByValueRadioButtonList( rblAllStepVisibleYN, estInfo.All_Step_Visible_YN );
        WebUtility.FindByValueRadioButtonList( rblEmpComDeptYN, estInfo.Emp_Com_Dept_YN );
		WebUtility.FindByValueRadioButtonList( rblUseYN, estInfo.Use_YN );
        WebUtility.FindByValueRadioButtonList( rblVisiblePastPointYN, estInfo.Visible_Past_Point_YN.Trim() );
        WebUtility.FindByValueRadioButtonList(rblEstQTTMBOYN, estInfo.Est_Qtt_Mbo_YN.Trim());
        WebUtility.FindByValueRadioButtonList(rblMboScoreEstimateYN, estInfo.Mbo_Score_Estimate_YN.Trim());
        WebUtility.FindByValueRadioButtonList(rblDashBoardTYPE, estInfo.DashBoard_TYPE.Trim());
        if (estInfo.DashBoard_TYPE.Trim() == "" || estInfo.DashBoard_TYPE.Trim() == "N")
        {
            rblDashBoardTYPE.Items.FindByValue("N").Selected = true;
            ddlDashBoardTYPE.Style.Add("display", "none");
        }
        else
        {
            rblDashBoardTYPE.Items.FindByValue("Y").Selected = true;
            ddlDashBoardTYPE.Style.Add("display", "block");
            WebUtility.FindByValueDropDownList(ddlDashBoardTYPE, estInfo.DashBoard_TYPE.Trim());
        }

        //이전차수의 질의평가지 보이기 여부
        WebUtility.FindByValueDropDownList(ddlPreviousStempYN, estInfo.Question_Previous_Step_YN.Trim());
        if (estInfo.Q_Style_ID.Trim() == "" || estInfo.Q_Style_ID.Trim() == "BLK")
            divQPSYN.Style.Add("display", "none");
        else
            divQPSYN.Style.Add("display", "true");

            // 평가주기 바인딩
            BindCblEstTermSub(comp_id, est_id);

		// 평가차수 바인딩
		BindCblEstTermStep(comp_id, est_id);

        BindEstJob(comp_id, est_id);

        rblEstStyle_SelectedIndexChanged(null, null);
        rblBiasYN_SelectedIndexChanged(null, null);

        MicroBSC.Integration.EST.Biz.Biz_Est_Outer_Data_Proc_Info bizOuterDataProcInfo = new MicroBSC.Integration.EST.Biz.Biz_Est_Outer_Data_Proc_Info();
        DataTable dtOuterDataProcInfo = bizOuterDataProcInfo.GetOuterDataProcInfo(comp_id
                                                                         , est_id).Tables[0];

        if (dtOuterDataProcInfo.Rows.Count > 0)
        {
            txtQueryString.Text = DataTypeUtility.GetValue(dtOuterDataProcInfo.Rows[0]["QUERY_STRING"]);
        }
	}

    private void BindEstJob(int comp_id, string est_id) 
    {
        if(!est_id.Equals("")) 
        {
            Biz_JobEstMaps jobEstMap    = new Biz_JobEstMaps();
            _dtEstJobMap                = jobEstMap.GetJobEstMap(comp_id, est_id, "").Tables[0];
        }

        Biz_JobInfos jobInfo        = new Biz_JobInfos();
        UltraWebGrid2.DataSource    = jobInfo.GetJobInfos("N");
        UltraWebGrid2.DataBind();
    }

	private void BindCblEstTermSub(int comp_id, string est_id)
	{
		Biz_TermSubEstMaps termSubEstMaps   = new Biz_TermSubEstMaps();
		DT_ESTTERM_SUB_MAP                  = termSubEstMaps.GetTermSubEstMap(comp_id, est_id, "").Tables[0];

        Biz_TermSubs termSub    = new Biz_TermSubs();
        DataSet ds              = termSub.GetTermSubByYearYN(COMP_ID, "N");

        uGridSub.DataSource    = ds;
        uGridSub.DataBind();
	}

	private void BindCblEstTermStep(int comp_id, string est_id)
	{
		Biz_TermStepEstMaps termStepEstMaps = new Biz_TermStepEstMaps();
		DT_ESTTERM_STEP_MAP                 = termStepEstMaps.GetTermStepEstMap(comp_id, est_id).Tables[0];

        Biz_TermSteps termStep  = new Biz_TermSteps();
        DataSet ds              = termStep.GetTermStepByMergeYN(COMP_ID, "N");

        uGridStep.DataSource    = ds;
        uGridStep.DataBind();
	}

	protected void ibtnCheckID_Click( object sender, ImageClickEventArgs e )
	{
		string est_id = txtEstID.Text.Trim();

		if ( est_id.Length == 0 )
		{
			ltrScript.Text = JSHelper.GetAlertScript( "평가 ID를 입력해주세요." );
			return;
		}

		Biz_EstInfos estInfo   = new Biz_EstInfos();
		bool bDuplicate        = estInfo.IsExists(COMP_ID, est_id);

		if ( bDuplicate )
		{
			ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가 ID 입니다.");
		}
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("사용 가능한 평가 ID 입니다.");
        }
	}

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView) e.Data;

        if(!TreeView1.SelectedValue.Equals("")) 
        {
            string est_job_id = drw["EST_JOB_ID"].ToString();

            if(_dtEstJobMap.Select(string.Format("EST_JOB_ID = '{0}'", est_job_id)).Length > 0)
            {
                TemplatedColumn ckbEstJobEstMap	= (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
		        CheckBox cBox		            = (CheckBox)((CellItem)ckbEstJobEstMap.CellItems[e.Row.BandIndex]).FindControl("cBox");
                cBox.Checked                    = true;
            }
        }
    }

    private bool SaveEstJobEstMap() 
    {
        Biz_JobEstMaps jobEstMap = new Biz_JobEstMaps();
        DataTable dataTable      = jobEstMap.GetDataTableSchema();

        dataTable                = UltraGridUtility.GetDataTableByCheckValue( UltraWebGrid2
                                                                            , "cBox"
                                                                            , "selchk"
                                                                            , new string[] { "EST_JOB_ID" }
                                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"]  = COMP_ID;
            dataRow["EST_ID"]   = TreeView1.SelectedValue;
            dataRow["DATE"]     = DateTime.Now;
            dataRow["USER"]     = EMP_REF_ID;
        }

        return jobEstMap.SaveJobEstMap(dataTable, COMP_ID, TreeView1.SelectedValue);
    }

    private bool DoSavIng_OuterDataProcInfo() 
    {
        MicroBSC.Integration.EST.Biz.Biz_Est_Outer_Data_Proc_Info bizOuterDataProcInfo = new MicroBSC.Integration.EST.Biz.Biz_Est_Outer_Data_Proc_Info();

        bool isOK = false;

        if (PageWriteMode == WriteMode.New)
        {
            isOK = bizOuterDataProcInfo.AddOuterDataProcInfo(COMP_ID
                                                                 , hdfEstID.Value
                                                                 , ""
                                                                 , txtQueryString.Text
                                                                 , DateTime.Now
                                                                 , this.gUserInfo.Emp_Ref_ID
                                                                );
        }
        else
        {
            isOK = bizOuterDataProcInfo.ModifyOuterDataProcInfo(COMP_ID
                                                                 , hdfEstID.Value
                                                                 , ""
                                                                 , txtQueryString.Text
                                                                 , DateTime.Now
                                                                 , this.gUserInfo.Emp_Ref_ID
                                                                );
        }
        return isOK;
    }

    private bool SaveEstTermSubMap() 
    {
        Biz_TermSubEstMaps termSubEstMap    = new Biz_TermSubEstMaps();
        DataTable dataTable                 = termSubEstMap.GetDataTableSchema();
        DataRow dataRow                     = null;

        TemplatedColumn ckb_use_yn          = null;
        CheckBox ckbUseYN                   = null;

        TemplatedColumn weight_col          = null;
        TextBox txtWeight                   = null;

        for(int i = 0; i < uGridSub.Rows.Count; i++) 
        {
            UltraGridRow row    = uGridSub.Rows[i];

            ckb_use_yn          = (TemplatedColumn)row.Band.Columns.FromKey("USE_YN");
            ckbUseYN            = (CheckBox)((CellItem)ckb_use_yn.CellItems[row.BandIndex]).FindControl("cBox");

            weight_col          = (TemplatedColumn)row.Band.Columns.FromKey("WEIGHT");
            txtWeight           = (TextBox)((CellItem)weight_col.CellItems[row.BandIndex]).FindControl("txtWeight");

            if(ckbUseYN.Checked)
            {
                dataRow                     = dataTable.NewRow();

                dataRow["COMP_ID"]          = COMP_ID;
                dataRow["EST_ID"]           = TreeView1.SelectedValue;
                dataRow["ESTTERM_SUB_ID"]   = uGridSub.Rows[i].Cells.FromKey("ESTTERM_SUB_ID").Value;
                dataRow["WEIGHT"]           = txtWeight.Text;
                dataRow["DATE"]             = DateTime.Now;
                dataRow["USER"]             = EMP_REF_ID;

                dataTable.Rows.Add(dataRow);
            }
        }

        return termSubEstMap.SaveTermSubEstMap(dataTable, COMP_ID, TreeView1.SelectedValue);
    }

    private bool SaveEstTermStepMap() 
    {
        Biz_TermStepEstMaps termStepEstMap  = new Biz_TermStepEstMaps();
        DataTable dataTable                 = termStepEstMap.GetDataTableSchema();
        DataRow dataRow                     = null;

        TemplatedColumn ckb_use_yn          = null;
        CheckBox ckbUseYN                   = null;

        TemplatedColumn weight_col          = null;
        TextBox txtWeight                   = null;

        TemplatedColumn ckb_fixed_yn        = null;
        CheckBox ckbFixedWeightYN           = null;

        for(int i = 0; i < uGridStep.Rows.Count; i++) 
        {
            UltraGridRow row    = uGridStep.Rows[i];

            ckb_use_yn          = (TemplatedColumn)row.Band.Columns.FromKey("USE_YN");
            ckbUseYN            = (CheckBox)((CellItem)ckb_use_yn.CellItems[row.BandIndex]).FindControl("cBox");

            weight_col          = (TemplatedColumn)row.Band.Columns.FromKey("WEIGHT");
            txtWeight           = (TextBox)((CellItem)weight_col.CellItems[row.BandIndex]).FindControl("txtWeight");

            ckb_fixed_yn        = (TemplatedColumn)row.Band.Columns.FromKey("FIXED_WEIGHT_YN");
            ckbFixedWeightYN    = (CheckBox)((CellItem)ckb_fixed_yn.CellItems[row.BandIndex]).FindControl("ckbFixedWeightYN");
            
            if(ckbUseYN.Checked)
            {
                dataRow                     = dataTable.NewRow();

                dataRow["COMP_ID"]          = COMP_ID;
                dataRow["EST_ID"]           = TreeView1.SelectedValue;
                dataRow["ESTTERM_STEP_ID"]  = uGridStep.Rows[i].Cells.FromKey("ESTTERM_STEP_ID").Value;
                dataRow["FIXED_WEIGHT_YN"]  = DataTypeUtility.GetBooleanToYN(ckbFixedWeightYN.Checked);
                dataRow["WEIGHT"]           = txtWeight.Text;
                dataRow["DATE"]             = DateTime.Now;
                dataRow["USER"]             = EMP_REF_ID;

                dataTable.Rows.Add(dataRow);
            }
        }

        return termStepEstMap.SaveTermStepEstMap(dataTable, COMP_ID, TreeView1.SelectedValue);
    }

    protected void ibnNew_Click(object sender, ImageClickEventArgs e)
    {
        GridBinding(COMP_ID);
        BindEstJob(COMP_ID, TreeView1.SelectedValue);
		ButtonStatusNew();
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
		string est_id               = txtEstID.Text;
		string up_est_id            = hdfUpEstID.Value;
		string est_name             = txtEstName.Text;
		string header_color         = txtHeaderColor.Text;
		string grade_confirm_yn     = WebUtility.GetByValueRadioButtonList(rblGradeConfirmYN);
		string bias_yn              = WebUtility.GetByValueRadioButtonList(rblBiasYN);
        string bias_dept_use_id     = WebUtility.GetByValueRadioButtonList(rblBiasDeptUseID);
        string tgt_send_type        = WebUtility.GetByValueRadioButtonList(rblTgtSendType);
        string tgt_opinion_yn       = null;
        string feedback_yn          = null;

        if(bias_yn.Equals("N"))
            bias_dept_use_id = "N";

        if(tgt_send_type.Equals("OPN")) 
        {
            tgt_opinion_yn      = "Y";
            feedback_yn         = "N";
        }
        else if(tgt_send_type.Equals("FBK"))
        {
            tgt_opinion_yn      = "N";
            feedback_yn         = "Y";
        }
        else 
        {
            tgt_opinion_yn      = "N";
            feedback_yn         = "N";
        }

		int estterm_sub             = CheckBoxListCommon.GetCheckNum( cblEstTermSub );
		int estterm_step            = CheckBoxListCommon.GetCheckNum( cblEstTermStep );
        string fixed_weight_use_yn  = WebUtility.GetByValueRadioButtonList(rblFixedWeightUseYN);
        double fixed_weight         = DataTypeUtility.GetToDouble(txtFixedWeight.Text);
		int point_ctrl_step         = WebUtility.GetIntByValueDropDownList(ddlPointCtrlStep);
		int grade_ctrl_step         = WebUtility.GetIntByValueDropDownList(ddlGradeCtrlStep);
		string owner_type           = WebUtility.GetByValueRadioButtonList(rblOwnerType);
        string est_style            = WebUtility.GetByValueRadioButtonList(rblEstStyle);
        string link_est_id          = hdfLinkEstID.Value;
        string weight_type          = WebUtility.GetByValueRadioButtonList(rblWeightType);
        string scale_type           = WebUtility.GetByValueRadioButtonList(rblScaleType);
        string status_style_id      = WebUtility.GetByValueDropDownList(ddlStatusStyleID);
        string q_style_id           = WebUtility.GetByValueDropDownList(ddlQuestionStyleID);
        string bias_type_id         = WebUtility.GetByValueDropDownList(ddlBiasTypeID);
        string q_item_desc_use_yn   = WebUtility.GetByValueRadioButtonList(rblQItemDescUseYN);
        string q_tgt_pos_biz_use_yn = WebUtility.GetByValueRadioButtonList(rblQTgtPosBizUseYN);
        string all_step_visible_yn  = WebUtility.GetByValueRadioButtonList(rblAllStepVisibleYN);
        string emp_com_dept_yn      = WebUtility.GetByValueRadioButtonList(rblEmpComDeptYN);
		string use_yn               = WebUtility.GetByValueRadioButtonList(rblUseYN);
        string visible_past_point_yn = WebUtility.GetByValueRadioButtonList(rblVisiblePastPointYN);
        string est_qtt_mbo_yn       = WebUtility.GetByValueRadioButtonList(rblEstQTTMBOYN);
        string mbo_score_estimate_yn = WebUtility.GetByValueRadioButtonList(rblMboScoreEstimateYN);
        string dashboard_type       = (rblDashBoardTYPE.SelectedItem.Value != "N" ? ddlDashBoardTYPE.SelectedItem.Value : "N");
        string previousstep_yn      = (ddlQuestionStyleID.SelectedItem.Value == "BLK" ? "N" : ddlPreviousStempYN.SelectedItem.Value.ToString());

        if (visible_past_point_yn.Equals(""))
            visible_past_point_yn = "Y";
        if (est_qtt_mbo_yn.Equals(""))
            est_qtt_mbo_yn = "N";
        if (mbo_score_estimate_yn.Equals(""))
            mbo_score_estimate_yn = "N";

		Biz_EstInfos estInfo        = new Biz_EstInfos();
        Biz_JobEstMaps jobEstMap    = new Biz_JobEstMaps();

        if ( PageWriteMode == WriteMode.New )
        {
            bool bDuplicate        = estInfo.IsExists(COMP_ID, est_id);

		    if ( bDuplicate )
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "존재하는 평가 ID 입니다." );
		    }

		    bool bResult = estInfo.AddEstInfoAddMaps( COMP_ID
                                                    , est_id
										            , up_est_id
										            , est_name
										            , header_color
										            , grade_confirm_yn
										            , bias_yn
                                                    , bias_dept_use_id
                                                    , tgt_opinion_yn
                                                    , feedback_yn
										            , estterm_sub
										            , estterm_step
                                                    , fixed_weight_use_yn
                                                    , fixed_weight
										            , point_ctrl_step
										            , grade_ctrl_step
										            , owner_type
                                                    , est_style
                                                    , link_est_id
                                                    , weight_type
                                                    , scale_type
                                                    , status_style_id
                                                    , q_style_id
                                                    , q_item_desc_use_yn
                                                    , q_tgt_pos_biz_use_yn
                                                    , all_step_visible_yn
                                                    , emp_com_dept_yn
                                                    , bias_type_id
                                                    , visible_past_point_yn
                                                    , est_qtt_mbo_yn
                                                    , mbo_score_estimate_yn
                                                    , dashboard_type
                                                    , previousstep_yn
										            , use_yn
										            , DateTime.Now
										            , EMP_REF_ID);

            bool isOK1 = SaveEstTermSubMap();
            bool isOK2 = SaveEstTermStepMap();
            bool isOK3 = SaveEstJobEstMap();

            DoSavIng_OuterDataProcInfo();

		    if ( bResult )
		    {
                ltrScript.Text = JSHelper.GetAlertScript( "정상적으로 저장되었습니다." );
			    GridBinding(COMP_ID);
			    ButtonStatusInit();
		    }
		    else
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "처리 중 오류가 발생하였습니다." );
                return;
		    }
        }
        else if ( PageWriteMode == WriteMode.Modify )
        {
		    bool bResult = estInfo.ModifyEstInfoModifyMaps(   COMP_ID
                                                            , est_id
											                , up_est_id
											                , est_name
											                , header_color
											                , grade_confirm_yn
											                , bias_yn
                                                            , bias_dept_use_id
                                                            , tgt_opinion_yn
                                                            , feedback_yn
											                , estterm_sub
											                , estterm_step
                                                            , fixed_weight_use_yn
                                                            , fixed_weight
											                , point_ctrl_step
											                , grade_ctrl_step
											                , owner_type
                                                            , est_style
                                                            , link_est_id
                                                            , weight_type
                                                            , scale_type
                                                            , status_style_id
                                                            , q_style_id
                                                            , q_item_desc_use_yn
                                                            , q_tgt_pos_biz_use_yn
                                                            , all_step_visible_yn
                                                            , emp_com_dept_yn
                                                            , bias_type_id
                                                            , visible_past_point_yn
                                                            , est_qtt_mbo_yn
                                                            , mbo_score_estimate_yn
                                                            , dashboard_type
                                                            , previousstep_yn
											                , use_yn
											                , DateTime.Now
											                , EMP_REF_ID);

            bool isOK1 = SaveEstTermSubMap();
            bool isOK2 = SaveEstTermStepMap();
            bool isOK3 = SaveEstJobEstMap();

            DoSavIng_OuterDataProcInfo();

		    if ( bResult )
		    {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되었습니다.");
			    //GridBinding();
			    ButtonStatusModify();
				ViewOne(COMP_ID, hdfEstID.Value);
		    }
		    else
		    {
			    ltrScript.Text = JSHelper.GetAlertScript( "수정되지 않았습니다." );
                return;
		    }
        }
    }

    protected void itnDelete_Click(object sender, ImageClickEventArgs e)
    {
		string strEstID			= hdfEstID.Value.Trim();

		Biz_EstInfos estInfo    = new Biz_EstInfos();
		bool bResult            = estInfo.RemoveEstInfoRemoveMaps(COMP_ID, strEstID);

		if ( bResult)
		{
			ltrScript.Text          = JSHelper.GetAlertScript( "정상적으로 삭제되었습니다.", false );
			GridBinding(COMP_ID);
			ButtonStatusInit();
			ClearValueControls();
		}
		else
		{
			ltrScript.Text = JSHelper.GetAlertScript( "삭제될 대상이 선택되지 않았습니다." );
            return;
		}
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBinding(COMP_ID);
        ClearValueControls();
    }

    protected void rblBiasYN_SelectedIndexChanged(object sender, EventArgs e)
    {
        string bias_yn = WebUtility.GetByValueRadioButtonList(rblBiasYN);

        if(bias_yn.Equals("Y"))
            rblBiasDeptUseID.Enabled = true;
        else
            rblBiasDeptUseID.Enabled = false;
    }

    protected void rblEstStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
        string est_style_id = WebUtility.GetByValueRadioButtonList(rblEstStyle);

        //if(est_style_id.Equals("EST")) 
        //{
        //    cblEstTermSub.Enabled       = true;
        //    cblEstTermStep.Enabled      = true;

        //    txtEstTermSubWeight.Enabled = true;
        //    txtEstTermStepWeight.Enabled= true;
        //}
        //else
        //{
        //    cblEstTermSub.Enabled       = false;
        //    cblEstTermStep.Enabled      = false;

        //    txtEstTermSubWeight.Enabled = false;
        //    txtEstTermStepWeight.Enabled= false;
        //}

        if(est_style_id.Equals("LNK")) 
        {
            txtLinkEstID.Enabled = true;
            imgLinkEstID.Visible = true;
        }
        else 
        {
            txtLinkEstID.Enabled = false;
            imgLinkEstID.Visible = false;
            hdfLinkEstID.Value   = "";
            txtLinkEstID.Text    = "";
        }
    }

	private void ClearValueControls()
	{
		txtEstID.Text			= "";
		txtEstName.Text			= "";
		hdfUpEstID.Value		= "";
		txtUpEstID.Text			= "";
		txtHeaderColor.Text		= "";

        WebUtility.FindByValueRadioButtonList( rblGradeConfirmYN, "N" );
        WebUtility.FindByValueRadioButtonList( rblBiasYN, "N" );
        WebUtility.FindByValueRadioButtonList( rblTgtSendType, "N" );
        CheckBoxListCommon.Check( cblEstTermSub, false );
        CheckBoxListCommon.Check( cblEstTermStep, false );
        WebUtility.FindByValueDropDownList( ddlPointCtrlStep, "1" );
        WebUtility.FindByValueDropDownList( ddlGradeCtrlStep, "1" );
        WebUtility.FindByValueRadioButtonList( rblOwnerType, "P" );
        WebUtility.FindByValueRadioButtonList( rblEstStyle, "BLK" );

        txtLinkEstID.Text    = "";
        hdfLinkEstID.Value   = "";

        WebUtility.FindByValueRadioButtonList( rblWeightType, "DPT" );
        WebUtility.FindByValueRadioButtonList( rblScaleType, "DPT" );
        WebUtility.FindByValueDropDownList( ddlBiasTypeID, "1" );
        WebUtility.FindByValueRadioButtonList( rblQItemDescUseYN, "N" );
        WebUtility.FindByValueRadioButtonList( rblUseYN, "Y" );
        WebUtility.FindByValueRadioButtonList( rblVisiblePastPointYN, "Y");
        WebUtility.FindByValueRadioButtonList(rblEstQTTMBOYN, "N");
        WebUtility.FindByValueRadioButtonList(rblMboScoreEstimateYN, "N");
        WebUtility.FindByValueRadioButtonList(rblDashBoardTYPE, "N");

        ddlQuestionStyleID.SelectedIndex = 0;
        ddlDashBoardTYPE.SelectedIndex = 0;
        ddlDashBoardTYPE.Style.Add("display", "none");
        ddlPreviousStempYN.SelectedIndex = 0;
        //ddlPreviousStempYN.Style.Add("display", "none");
        divQPSYN.Style.Add("display", "none");
        WebUtility.FindByValueRadioButtonList( rblAllStepVisibleYN, "N" );
        WebUtility.FindByValueRadioButtonList( rblEmpComDeptYN, "N" );

        rblEstStyle_SelectedIndexChanged(null, null);
	}

	private void ButtonStatusInit()
	{
		txtEstID.Enabled        = false;
		txtEstID.ReadOnly		= false;

		ibnSave.Enabled		    = false;
		ibnDelete.Enabled		= false;

		ibnCheckID.Visible      = false;
        //txtEstID.Width          = Unit.Pixel(200);
        txtEstID.Enabled        = false;

        imgUpEstID.Visible      = false;

		ClearValueControls();

		txtEstID.Enabled        = false;
		txtUpEstID.Enabled      = false;
		txtEstName.Enabled      = false;
		txtHeaderColor.Enabled  = false;

        txtLinkEstID.Enabled    = false;
        imgLinkEstID.Visible    = false;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.None;
	}

	private void ButtonStatusNew()
	{
		txtEstID.Enabled        = false;
		txtEstID.ReadOnly		= false;

		ibnSave.Enabled         = true;
		ibnDelete.Enabled       = false;

        ibnCheckID.Visible      = true;
        //txtEstID.Width          = Unit.Pixel(200);
        txtEstID.Enabled        = true;

        imgUpEstID.Visible      = true;

		ClearValueControls();

		txtEstID.Enabled        = true;
		txtUpEstID.Enabled      = true;
		txtEstName.Enabled      = true;
		txtHeaderColor.Enabled  = true;

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

		PageWriteMode           = WriteMode.New;
	}

	private void ButtonStatusModify()
	{
		txtEstID.Enabled		= true;
		txtEstID.ReadOnly		= true;

		ibnSave.Enabled		    = true;
		ibnDelete.Enabled		= true;

		ibnCheckID.Visible      = false;
		//txtEstID.Width          = Unit.Pixel(200);

        imgUpEstID.Visible      = false;
		txtUpEstID.Attributes.Remove( "onclick" );

		txtEstID.Enabled        = true;
		txtUpEstID.Enabled      = true;
		txtEstName.Enabled      = true;
		txtHeaderColor.Enabled  = true;
        

        ibnSave.ImageUrl        = "../images/btn/b_002.gif";//"수정";

		PageWriteMode           = WriteMode.Modify;
	}

    protected void uGridSub_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView) e.Data;

        TemplatedColumn ckb_use_yn  = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        CheckBox ckbUseYN           = (CheckBox)((CellItem)ckb_use_yn.CellItems[e.Row.BandIndex]).FindControl("cBox");

        TemplatedColumn weight_col  = (TemplatedColumn)e.Row.Band.Columns.FromKey("WEIGHT");
        TextBox txtWeight           = (TextBox)((CellItem)weight_col.CellItems[e.Row.BandIndex]).FindControl("txtWeight");

		TextBoxCommon.SetOnlyPercent(txtWeight);

        DataRow[] drArr = DT_ESTTERM_SUB_MAP.Select( string.Format(  @"COMP_ID         = {0}                                        
                                                                    AND EST_ID          = '{1}'
                                                                    AND ESTTERM_SUB_ID  = {2}"
                                                                , COMP_ID
                                                                , TreeView1.SelectedValue
                                                                , drw["ESTTERM_SUB_ID"] ));

		if ( drArr.Length > 0 )
		{
            ckbUseYN.Checked = true;
            ckbUseYN.Attributes.Add("onclick", string.Format("enableCheckBox('{0}', '', '{1}')", ckbUseYN.ClientID, txtWeight.ClientID));

			txtWeight.Text = drArr[0]["WEIGHT"].ToString();

            //e.Row.Style.BackColor       = Color.FromName("#FFFFFF");
		}
		else
		{
			ckbUseYN.Checked            = false;
            txtWeight.Text              = "";
            //e.Row.Style.BackColor       = Color.FromName("#EBEBEB");
		}
    }

    protected void uGridStep_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView) e.Data;

        TemplatedColumn ckb_use_yn  = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        CheckBox ckbUseYN           = (CheckBox)((CellItem)ckb_use_yn.CellItems[e.Row.BandIndex]).FindControl("cBox");

        TemplatedColumn weight_col  = (TemplatedColumn)e.Row.Band.Columns.FromKey("WEIGHT");
        TextBox txtWeight           = (TextBox)((CellItem)weight_col.CellItems[e.Row.BandIndex]).FindControl("txtWeight");

        TemplatedColumn ckb_fixed_yn = (TemplatedColumn)e.Row.Band.Columns.FromKey("FIXED_WEIGHT_YN");
        CheckBox ckbFixedWeightYN    = (CheckBox)((CellItem)ckb_fixed_yn.CellItems[e.Row.BandIndex]).FindControl("ckbFixedWeightYN");

		TextBoxCommon.SetOnlyPercent(txtWeight);

        DataRow[] drArr = DT_ESTTERM_STEP_MAP.Select( string.Format(  @"COMP_ID         = {0}                                        
                                                                    AND EST_ID          = '{1}'
                                                                    AND ESTTERM_STEP_ID = {2}"
                                                                , COMP_ID
                                                                , TreeView1.SelectedValue
                                                                , drw["ESTTERM_STEP_ID"] ));

		if ( drArr.Length > 0 )
		{
            ckbUseYN.Checked = true;
            ckbUseYN.Attributes.Add("onclick", string.Format("enableCheckBox('{0}', '{1}', '{2}')", ckbUseYN.ClientID, ckbFixedWeightYN.ClientID, txtWeight.ClientID));

            if(DataTypeUtility.GetValue(drArr[0]["FIXED_WEIGHT_YN"]).Equals("Y"))
                ckbFixedWeightYN.Checked = true;
            else
                ckbFixedWeightYN.Checked = false;

			txtWeight.Text              = drArr[0]["WEIGHT"].ToString();
            //e.Row.Style.BackColor       = Color.FromName("#FFFFFF");
		}
		else
		{
			ckbUseYN.Checked            = false;
            ckbFixedWeightYN.Checked    = false;
            txtWeight.Text              = "";
            //e.Row.Style.BackColor       = Color.FromName("#EBEBEB");
		}
    }

    protected void rblFixedWeightUseYN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rblFixedWeightUseYN.Items[0].Selected) 
        {
            tdFixedWeight.Visible = true;
            txtFixedWeight.Focus();

            uGridStep.Bands[0].Columns.FromKey("FIXED_WEIGHT_YN").Hidden = false;
        }
        else
        {
            tdFixedWeight.Visible = false;

            uGridStep.Bands[0].Columns.FromKey("FIXED_WEIGHT_YN").Hidden = true;
        }
    }
}
