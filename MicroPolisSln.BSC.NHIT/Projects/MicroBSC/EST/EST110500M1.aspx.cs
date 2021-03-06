﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;
using System.Drawing;

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

using MicroBSC.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Integration.COM.Biz;
using MicroBSC.Integration.EST.Biz;

public partial class EST110500M1 : AppPageBase
{
    public int COMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
            {
                ViewState["COMP_ID"] = WebUtility.GetRequestByInt("COMP_ID");
            }

            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }

    public int ESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int ESTTERM_SUB_ID
    {
        get
        {
            if (ViewState["ESTTERM_SUB_ID"] == null)
            {
                ViewState["ESTTERM_SUB_ID"] = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
            }

            return (int)ViewState["ESTTERM_SUB_ID"];
        }
        set
        {
            ViewState["ESTTERM_SUB_ID"] = value;
        }
    }

    public int ESTTERM_STEP_ID
    {
        get
        {
            if (ViewState["ESTTERM_STEP_ID"] == null)
            {
                ViewState["ESTTERM_STEP_ID"] = WebUtility.GetRequestByInt("ESTTERM_STEP_ID");
            }

            return (int)ViewState["ESTTERM_STEP_ID"];
        }
        set
        {
            ViewState["ESTTERM_STEP_ID"] = value;
        }
    }

    public string EST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
            {
                ViewState["EST_ID"] = WebUtility.GetRequest("EST_ID");
            }

            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }

    public int TGT_EMP_ID
    {
        get
        {
            if (ViewState["TGT_EMP_ID"] == null)
            {
                ViewState["TGT_EMP_ID"] = WebUtility.GetRequestByInt("TGT_EMP_ID");
            }

            return (int)ViewState["TGT_EMP_ID"];
        }
        set
        {
            ViewState["TGT_EMP_ID"] = value;
        }
    }

    public int TGT_DEPT_ID
    {
        get
        {
            if (ViewState["TGT_DEPT_ID"] == null)
            {
                ViewState["TGT_DEPT_ID"] = WebUtility.GetRequestByInt("TGT_DEPT_ID");
            }

            return (int)ViewState["TGT_DEPT_ID"];
        }
        set
        {
            ViewState["TGT_DEPT_ID"] = value;
        }
    }

    public int EST_EMP_ID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
            {
                ViewState["EST_EMP_ID"] = WebUtility.GetRequestByInt("EST_EMP_ID");
            }

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }

    public int EST_DEPT_ID
    {
        get
        {
            if (ViewState["EST_DEPT_ID"] == null)
            {
                ViewState["EST_DEPT_ID"] = WebUtility.GetRequestByInt("EST_DEPT_ID");
            }

            return (int)ViewState["EST_DEPT_ID"];
        }
        set
        {
            ViewState["EST_DEPT_ID"] = value;
        }
    }

    public string EST_TGT_TYPE
    {
        get
        {
            if (ViewState["EST_TGT_TYPE"] == null)
            {
                ViewState["EST_TGT_TYPE"] = WebUtility.GetRequest("EST_TGT_TYPE");
            }

            return (string)ViewState["EST_TGT_TYPE"];
        }
        set
        {
            ViewState["EST_TGT_TYPE"] = value;
        }
    }

    public DataTable DT_EST_SELF_DATA
    {
        get
        {
            if (ViewState["DT_EST_SELF_DATA"] == null)
            {
                return null;
            }

            return (DataTable)ViewState["DT_EST_SELF_DATA"];
        }
        set
        {
            ViewState["DT_EST_SELF_DATA"] = value;
        }
    }

    public DataTable DT_EST_QUESTION
    {
        get
        {
            if (ViewState["DT_EST_QUESTION"] == null)
            {
                return null;
            }

            return (DataTable)ViewState["DT_EST_QUESTION"];
        }
        set
        {
            ViewState["DT_EST_QUESTION"] = value;
        }
    }

    public string STATUS_ID
    {
        get
        {
            if (ViewState["STATUS_ID"] == null)
            {
                ViewState["STATUS_ID"] = WebUtility.GetRequest("STATUS_ID");
            }

            return (string)ViewState["STATUS_ID"];
        }
        set
        {
            ViewState["STATUS_ID"] = value;
        }
    }

    public string Q_OBJ_ID
    {
        get
        {
            if (ViewState["Q_OBJ_ID"] == null)
            {
                ViewState["Q_OBJ_ID"] = WebUtility.GetRequest("Q_OBJ_ID");
            }

            return (string)ViewState["Q_OBJ_ID"];
        }
        set
        {
            ViewState["Q_OBJ_ID"] = value;
        }
    }
    

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";

        if (!IsPostBack)
        {
            Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);
            Biz_TermInfos termInfo = new Biz_TermInfos(ESTTERM_REF_ID);
            Biz_TermSubs termSubInfo = new Biz_TermSubs(COMP_ID, ESTTERM_SUB_ID);
            
            ESTTERM_STEP_ID = 2;


            Biz_EmpInfos empInfo = new Biz_EmpInfos(TGT_EMP_ID);
            Biz_Com_Dept_Info deptInfo = new Biz_Com_Dept_Info(TGT_DEPT_ID);
            Biz_PositionClasses clsInfo = new Biz_PositionClasses(empInfo.Position_Class_Code);



            this.lblEstTerm.Text = string.Format("{0}({1})", DataTypeUtility.GetString(termInfo.EstTerm_Name), DataTypeUtility.GetString(termSubInfo.EstTerm_Sub_Name));
            this.lblEstName.Text = DataTypeUtility.GetString(estInfo.Est_Name);
            this.lblEstEmp.Text = string.Format("{1}({0})", DataTypeUtility.GetString(deptInfo.DEPT_NAME), DataTypeUtility.GetString(empInfo.Emp_Name));
            this.lblEstEmpClass.Text = DataTypeUtility.GetString(clsInfo.Pos_Cls_Name);

            txtConsult.ToolbarStartExpanded = false;

            bindData();
        }

        setSaveBtn();
    }

    protected void setSaveBtn()
    { 
        bool state = true;

        if (COMP_ID == 0)
            state = false;
        else if (EST_ID.Trim().Length == 0)
            state = false;
        else if (ESTTERM_REF_ID == 0)
            state = false;
        else if (ESTTERM_SUB_ID == 0)
            state = false;
        else if (ESTTERM_STEP_ID == 0)
            state = false;
        else if (TGT_DEPT_ID == 0)
            state = false;
        else if (TGT_EMP_ID == 0)
            state = false;
        else if (EST_TGT_TYPE.Trim().Length == 0)
            state = false;
        else if (!STATUS_ID.Trim().Equals("N") && !STATUS_ID.Trim().Equals("O"))
            state = false;

        this.iBtnSave.Enabled = state;
        this.iBtnSave.Visible = state;
    }


    protected void bindData()
    {
        getEstSelfData();
        getEstQuestion();


        doBindEstComment();
        doBindConsult();
        doBindEstQuestion();
        doBindEstEmpList();
    }


    protected void getEstSelfData()
    {
        Biz_Est_Self_Data bizEstSelfData = new Biz_Est_Self_Data();
        DT_EST_SELF_DATA = bizEstSelfData.Get_Self_Est_Question(COMP_ID
                                                                , EST_ID
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , ESTTERM_STEP_ID
                                                                , TGT_DEPT_ID
                                                                , TGT_EMP_ID);
    }


    protected void getEstQuestion()
    {
        Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps(COMP_ID
                                                                                , ESTTERM_REF_ID
                                                                                , ESTTERM_SUB_ID
                                                                                , ESTTERM_STEP_ID
                                                                                , EST_ID
                                                                                , ""
                                                                                , TGT_DEPT_ID
                                                                                , TGT_EMP_ID
                                                                                , "P");

        Q_OBJ_ID = questionDeptEmpMaps.Q_Obj_ID;

        if (Q_OBJ_ID != null && Q_OBJ_ID.Trim().Length > 0)
        {
            Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
            DT_EST_QUESTION = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "").Tables[0];
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("질의평가 항목이 없습니다.");
            this.iBtnSave.Visible = false;
            this.iBtnSave.Enabled = false;
        }
    }


    protected void doBindEstComment()
    {
        if (DT_EST_SELF_DATA == null)
        {
            getEstSelfData();
        }
        
        ugrdEstComment.Clear();
        ugrdEstComment.DataSource = DataTypeUtility.GetGroupByDataTable(DT_EST_SELF_DATA, new string[] { "SELF_TOP_ID", "SELF_TOP_NM" });
        ugrdEstComment.DataBind();
    }
    protected void ugrdEstComment_InitializeLayout(object sender, LayoutEventArgs e)
    { 
        
    }
    protected void ugrdEstComment_InitializeRow(object sender, RowEventArgs e)
    {
        string self_top_id = DataTypeUtility.GetString(e.Row.Cells.FromKey("SELF_TOP_ID"));

        DataTable dt_question = DataTypeUtility.FilterSortDataTable(DT_EST_SELF_DATA, string.Format("SELF_TOP_ID={0}", self_top_id));


        TemplatedColumn tc = (TemplatedColumn)e.Row.Band.Columns.FromKey("EST_COMMENT");
        RadioButtonList rdoEstComment = (RadioButtonList)((CellItem)tc.CellItems[e.Row.Index]).FindControl("rdoEstComment");
        rdoEstComment.RepeatDirection = RepeatDirection.Horizontal;
        rdoEstComment.RepeatLayout = RepeatLayout.Table;
        rdoEstComment.Width = Unit.Percentage(99);
        rdoEstComment.DataSource = dt_question;
        rdoEstComment.DataBind();

        DataTable dt_q_selected = DataTypeUtility.FilterSortDataTable(dt_question, string.Format("SELECTED > 0"));
        if (dt_q_selected.Rows.Count > 0)
            WebUtility.FindByValueRadioButtonList(rdoEstComment, DataTypeUtility.GetString(dt_q_selected.Rows[0]["SELF_MID_ID"]));
    }





    protected void doBindConsult()
    {
        DataTable dt = DataTypeUtility.FilterSortDataTable(DT_EST_SELF_DATA, "SELF_COMMENT IS NOT NULL");

        if (dt.Rows.Count > 0)
        {
//            txtConsult.Text = DataTypeUtility.GetString(dt.Rows[0]["SELF_COMMENT"]);
            txtConsult.Value  = DataTypeUtility.GetString(dt.Rows[0]["SELF_COMMENT"]);
        }
    }





    protected void doBindEstQuestion()
    {
        ugrdEstQuestion.Clear();
        ugrdEstQuestion.DataSource = DT_EST_QUESTION;
        ugrdEstQuestion.DataBind();
    }
    protected void ugrdEstQuestion_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Bands[0].Columns.FromKey("Q_DFN_NAME").Header.Caption = "항목";
        e.Layout.Bands[0].Columns.FromKey("Q_DFN_NAME").Header.RowLayoutColumnInfo.SpanX = 2;

        for (int i = 2; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginX = i-1;
        }
    }
    protected void ugrdEstQuestion_InitializeRow(object sender, RowEventArgs e)
    {
        string q_sbj_id = DataTypeUtility.GetString(e.Row.Cells.FromKey("Q_SBJ_ID"));

        Biz_QuestionItems questionItems = new Biz_QuestionItems();
        DataTable dt_q_item = questionItems.GetQuestionItem("", q_sbj_id, Q_OBJ_ID).Tables[0];


        TemplatedColumn tc = (TemplatedColumn)e.Row.Band.Columns.FromKey("Q_ITEM");
        RadioButtonList rdoQuestionItem = (RadioButtonList)((CellItem)tc.CellItems[e.Row.Index]).FindControl("rdoQuestionItem");

        rdoQuestionItem.RepeatDirection = RepeatDirection.Horizontal;
        rdoQuestionItem.RepeatLayout = RepeatLayout.Table;
        rdoQuestionItem.DataSource = dt_q_item;
        rdoQuestionItem.DataBind();



        int est_dept_id = TGT_DEPT_ID;
        int est_emp_id = TGT_EMP_ID;
        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas(COMP_ID
                                                               , EST_ID
                                                               , ESTTERM_REF_ID
                                                               , ESTTERM_SUB_ID
                                                               , ESTTERM_STEP_ID
                                                               , est_dept_id
                                                               , est_emp_id
                                                               , TGT_DEPT_ID
                                                               , TGT_EMP_ID
                                                               , q_sbj_id);

        WebUtility.FindByValueRadioButtonList(rdoQuestionItem, questionDatas.Q_Itm_ID);


        DateTime update_date = (DateTime)questionDatas.Update_Date;
        if (update_date != DateTime.MinValue)
        {
            this.lblUpdateDate.Text = DataTypeUtility.GetString(questionDatas.Update_Date);
        }
    }





    protected void doBindEstEmpList()
    {
        Biz_Est_Data bizEstData = new Biz_Est_Data();
        DataTable dt = bizEstData.GetEstData(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , 0
                                            , ""
                                            , 0
                                            , TGT_EMP_ID);


        dt.Columns.Add("EST_DEPT_NAME");
        dt.Columns.Add("EST_EMP_NAME");
        dt.Columns.Add("EST_POS_CLS");
        dt.Columns.Add("EST_POS_RNK");
        dt.Columns.Add("ESTTERM_STEP_NAME");


        dt = DataTypeUtility.FilterSortDataTable(dt, "ESTTERM_STEP_ID=2 OR ESTTERM_STEP_ID=3", "ESTTERM_STEP_ID ASC");
         

        for(int i=0; i<dt.Rows.Count; i++)
        {
            int est_dept_id = DataTypeUtility.GetToInt32(dt.Rows[i]["EST_DEPT_ID"]);
            int est_emp_id = DataTypeUtility.GetToInt32(dt.Rows[i]["EST_EMP_ID"]);

            Biz_EmpInfos bizEmpInfo = new Biz_EmpInfos(est_emp_id);
            Biz_Com_Dept_Info bizDeptInfo = new Biz_Com_Dept_Info(est_dept_id);

            string est_dept_name = DataTypeUtility.GetString(bizDeptInfo.DEPT_NAME);
            string est_emp_name = DataTypeUtility.GetString(bizEmpInfo.Emp_Name);

            Biz_PositionClasses bizPosCls = new Biz_PositionClasses(bizEmpInfo.Position_Class_Code);
            Biz_PositionRanks bizPosRnk = new Biz_PositionRanks(bizEmpInfo.Position_Rank_Code);

            string est_pos_cls = DataTypeUtility.GetString(bizPosCls.Pos_Cls_Name);
            string est_pos_rnk = DataTypeUtility.GetString(bizPosRnk.Pos_Rnk_Name);

            dt.Rows[i]["EST_DEPT_NAME"] = est_dept_name;
            dt.Rows[i]["EST_EMP_NAME"] = est_emp_name;
            dt.Rows[i]["EST_POS_CLS"] = est_pos_cls;
            dt.Rows[i]["EST_POS_RNK"] = est_pos_rnk;


            int estterm_step_id = DataTypeUtility.GetToInt32(dt.Rows[i]["ESTTERM_STEP_ID"]);
            string estterm_step_name = "";
            if (estterm_step_id == 2)
                estterm_step_name = "1차 평가자";
            else if (estterm_step_id == 3)
                estterm_step_name = "2차 평가자";

            dt.Rows[i]["ESTTERM_STEP_NAME"] = estterm_step_name;
        }

        ugrdEstEmpList.Clear();
        ugrdEstEmpList.DataSource = dt;
        ugrdEstEmpList.DataBind();
    }

    


    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (doSave())
        {
            this.ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("적용되었습니다.", true);
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("실패하였습니다.", true);
        }
    }
    protected bool doSave()
    {
        Biz_Est_Self_Data bizEstSelfData = new Biz_Est_Self_Data();

        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas();
        Biz_Datas datas = new Biz_Datas();

        Biz_EstInfos bizEstInfo = new Biz_EstInfos(COMP_ID, EST_ID);

        int est_dept_id = TGT_DEPT_ID;
        int est_emp_id = TGT_EMP_ID;

        string status_style_id = DataTypeUtility.GetString(bizEstInfo.Status_Style_ID);
        
        Biz_Status self_status = new Biz_Status();
        DataTable dt_status = self_status.GetStatuses(status_style_id).Tables[0];

        string status_id = DataTypeUtility.GetString(DataTypeUtility.FilterSortDataTable(dt_status, "SEQ=2").Rows[0]["STATUS_ID"]);

        DataTable dtQData = Get_SaveDT_EstQuestion();
        DataTable dtEstData = AddNewEstDataRow(datas.GetDataTableSchema(), status_id);
        DataTable dtEstSelfData = Get_SaveDT_EstComment();

        //------------------------- 상태 순서 체크 시작 ----------------------------------------

        if (dtEstData.Rows.Count > 0)
        {
            if (datas.IsExist(COMP_ID
                            , EST_ID
                            , ESTTERM_REF_ID
                            , ESTTERM_SUB_ID
                            , ESTTERM_STEP_ID
                            , est_dept_id
                            , est_emp_id
                            , TGT_DEPT_ID
                            , TGT_EMP_ID))
            {
                datas = new Biz_Datas(COMP_ID
                                    , EST_ID
                                    , ESTTERM_REF_ID
                                    , ESTTERM_SUB_ID
                                    , ESTTERM_STEP_ID
                                    , est_dept_id
                                    , est_emp_id
                                    , TGT_DEPT_ID
                                    , TGT_EMP_ID);

                Biz_Status status_data = new Biz_Status(datas.Status_ID, status_style_id);
                Biz_Status status_new = new Biz_Status(DataTypeUtility.GetValue(dtEstData.Rows[0]["STATUS_ID"]), status_style_id);

                if (status_data.Seq + 1 != status_new.Seq
                    && status_data.Seq != status_new.Seq)
                {
                    ltrScript.Text = JSHelper.GetAlertScript(string.Format(@"[{0}] 단계에서 [{1}] 단계로 진행될 수 없어 정상적으로 처리할 수 없습니다."
                                                                        , status_data.Status_Name
                                                                        , status_new.Status_Name)
                                                            , true);
                    return false;
                }
            }
            else
            {
                Biz_Status status_new = new Biz_Status(DataTypeUtility.GetValue(dtEstData.Rows[0]["STATUS_ID"]), status_style_id);

                if (status_new.Seq != 2)
                {
                    ltrScript.Text = JSHelper.GetAlertScript(string.Format(@"[{0}] 단계은 두번째 단계가 아니여서 정상적으로 처리할 수 없습니다."
                                                                        , status_new.Status_Name)
                                                            , true);
                    return false;
                }
            }
        }

        //------------------------- 상태 순서 체크 끝 ----------------------------------------



        bool isSuccessed = bizEstSelfData.Save_Self_Est(dtEstData, dtQData, dtEstSelfData, gUserInfo.Emp_Ref_ID);

        return isSuccessed;
    }
    protected DataTable Get_SaveDT_EstComment()
    {
        DataTable saveDT = CreateEstSelfDataColumns();

//        string self_comment = PageUtility.GetHtmlEncodeChar(this.txtConsult.Text);
        string self_comment = PageUtility.GetHtmlEncodeChar(this.txtConsult.Value );

        for (int i = 0; i < ugrdEstComment.Rows.Count; i++)
        {
            DataRow dr = saveDT.NewRow();

            TemplatedColumn tc = (TemplatedColumn)ugrdEstComment.Rows[i].Cells.FromKey("EST_COMMENT").Column;
            RadioButtonList rdoEstComment = (RadioButtonList)((CellItem)tc.CellItems[i]).FindControl("rdoEstComment");

            string self_top_id = DataTypeUtility.GetString(ugrdEstComment.Rows[i].Cells.FromKey("SELF_TOP_ID").Value);
            string self_mid_id = DataTypeUtility.GetString(rdoEstComment.SelectedValue);


            dr["COMP_ID"] = COMP_ID;
            dr["EST_ID"] = EST_ID;
            dr["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
            dr["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
            dr["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
            dr["TGT_DEPT_ID"] = TGT_DEPT_ID;
            dr["TGT_EMP_ID"] = TGT_EMP_ID;
            dr["SELF_TOP_ID"] = self_top_id;
            dr["SELF_MID_ID"] = self_mid_id;
            dr["SELF_COMMENT"] = self_comment;

            saveDT.Rows.Add(dr);
        }

        return saveDT;
    }
    protected DataTable CreateEstSelfDataColumns()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("COMP_ID");
        dt.Columns.Add("EST_ID");
        dt.Columns.Add("ESTTERM_REF_ID");
        dt.Columns.Add("ESTTERM_SUB_ID");
        dt.Columns.Add("ESTTERM_STEP_ID");
        dt.Columns.Add("TGT_DEPT_ID");
        dt.Columns.Add("TGT_EMP_ID");
        dt.Columns.Add("SELF_TOP_ID");
        dt.Columns.Add("SELF_MID_ID");
        dt.Columns.Add("SELF_COMMENT");

        return dt;
    }
    protected DataTable Get_SaveDT_EstQuestion()
    {
        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas();
        DataTable saveDT = questionDatas.GetDataTableSchema();
        
        for (int i = 0; i < ugrdEstQuestion.Rows.Count; i++)
        {
            DataRow dr = saveDT.NewRow();

            TemplatedColumn tc = (TemplatedColumn)ugrdEstQuestion.Rows[i].Cells.FromKey("Q_ITEM").Column;
            RadioButtonList rdoQuestionItem = (RadioButtonList)((CellItem)tc.CellItems[i]).FindControl("rdoQuestionItem");

            string q_obj_id = Q_OBJ_ID;
            string q_sbj_id = DataTypeUtility.GetString(ugrdEstQuestion.Rows[i].Cells.FromKey("Q_SBJ_ID").Value);
            string q_itm_id = DataTypeUtility.GetString(rdoQuestionItem.SelectedValue);

            dr["COMP_ID"] = COMP_ID;
            dr["EST_ID"] = EST_ID;
            dr["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
            dr["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
            dr["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
            dr["EST_DEPT_ID"] = TGT_DEPT_ID;
            dr["EST_EMP_ID"] = TGT_EMP_ID;
            dr["TGT_DEPT_ID"] = TGT_DEPT_ID;
            dr["TGT_EMP_ID"] = TGT_EMP_ID;
            dr["Q_OBJ_ID"] = q_obj_id;
            dr["Q_SBJ_ID"] = q_sbj_id;
            dr["Q_ITM_ID"] = q_itm_id;
            dr["POINT"] = 0;
            dr["GRADE_ID"] = "";
            dr["TEXT_VALUE"] = "";
            dr["OPINION"] = "";
            dr["ATTACH_NO"] = "";
            dr["USER"] = gUserInfo.Emp_Ref_ID;

            saveDT.Rows.Add(dr);
        }

        return saveDT;
    }
    private DataTable AddNewEstDataRow(DataTable dtEstData, string status_id)
    {
        DataRow dataRow = dtEstData.NewRow();

        dataRow["COMP_ID"] = COMP_ID;
        dataRow["EST_ID"] = EST_ID;
        dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
        dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
        dataRow["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
        dataRow["EST_DEPT_ID"] = EST_DEPT_ID;
        dataRow["EST_EMP_ID"] = EST_EMP_ID;
        dataRow["TGT_DEPT_ID"] = TGT_DEPT_ID;
        dataRow["TGT_EMP_ID"] = TGT_EMP_ID;
        dataRow["TGT_POS_CLS_ID"] = DBNull.Value;
        dataRow["TGT_POS_CLS_NAME"] = DBNull.Value;
        dataRow["TGT_POS_DUT_ID"] = DBNull.Value;
        dataRow["TGT_POS_DUT_NAME"] = DBNull.Value;
        dataRow["TGT_POS_GRP_ID"] = DBNull.Value;
        dataRow["TGT_POS_GRP_NAME"] = DBNull.Value;
        dataRow["TGT_POS_RNK_ID"] = DBNull.Value;
        dataRow["TGT_POS_RNK_NAME"] = DBNull.Value;
        dataRow["TGT_POS_KND_ID"] = DBNull.Value;
        dataRow["TGT_POS_KND_NAME"] = DBNull.Value;
        dataRow["POINT_ORG"] = DBNull.Value;
        dataRow["POINT_ORG_DATE"] = DateTime.Now;
        dataRow["POINT_AVG"] = DBNull.Value;
        dataRow["POINT_AVG_DATE"] = DBNull.Value;
        dataRow["POINT_STD"] = DBNull.Value;
        dataRow["POINT_STD_DATE"] = DBNull.Value;
        dataRow["POINT"] = DBNull.Value;
        dataRow["POINT_DATE"] = DateTime.Now;
        dataRow["GRADE_ID"] = DBNull.Value;
        dataRow["GRADE_DATE"] = DBNull.Value;
        dataRow["GRADE_TO_POINT"] = DBNull.Value;
        dataRow["GRADE_TO_POINT_DATE"] = DBNull.Value;
        dataRow["STATUS_ID"] = status_id;
        dataRow["STATUS_DATE"] = DateTime.Now;
        dataRow["DATE"] = DateTime.Now;
        dataRow["USER"] = gUserInfo.Emp_Ref_ID;

        dtEstData.Rows.Add(dataRow);

        return dtEstData;
    }
}
