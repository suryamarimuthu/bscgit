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
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;

using MicroBSC.Estimation.Biz;
using MicroBSC.Integration.COM.Biz;


public partial class EST_EST_Q_PAGE_04 : EstPageBase
{
    public int COMP_ID;
    public string EST_ID;
    public int ESTTERM_REF_ID;
    public int ESTTERM_SUB_ID;
    public int ESTTERM_STEP_ID;
    
    public int     EST_DEPT_ID;
    public int     EST_EMP_ID;
    public int     TGT_DEPT_ID;
    public int     TGT_EMP_ID;

    public string STATUS_ID;

    public string EST_TGT_TYPE;

    
    public string  Q_SBJ_ID;
    public string  Q_ITM_ID;

    public double TOTALPOINT;

    private const string ConstDIRECTION_TYPE = "MU";


    public string Q_OBJ_ID
    {
        get
        {
            if (ViewState["Q_OBJ_ID"] == null)
            {
                return null;
            }

            return (string)ViewState["Q_OBJ_ID"];
        }
        set
        {
            ViewState["Q_OBJ_ID"] = value;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = WebUtility.GetRequestByInt("COMP_ID");
        EST_ID          = WebUtility.GetRequest("EST_ID");
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = WebUtility.GetRequestByInt("ESTTERM_STEP_ID");
        EST_DEPT_ID     = WebUtility.GetRequestByInt("EST_DEPT_ID");
        EST_EMP_ID      = WebUtility.GetRequestByInt("EST_EMP_ID");
        TGT_DEPT_ID     = WebUtility.GetRequestByInt("TGT_DEPT_ID");
        TGT_EMP_ID      = WebUtility.GetRequestByInt("TGT_EMP_ID");

        EST_TGT_TYPE    = WebUtility.GetRequest("EST_TGT_TYPE", "EST");
        STATUS_ID       = WebUtility.GetRequest("STATUS_ID", "N");


        Biz_EstInfos estInfo = new Biz_EstInfos(COMP_ID, EST_ID);
        Biz_TermInfos termInfo = new Biz_TermInfos(ESTTERM_REF_ID);
        Biz_TermSubs termSubInfo = new Biz_TermSubs(COMP_ID, ESTTERM_SUB_ID);



        Biz_EmpInfos est_emp_Info = new Biz_EmpInfos(EST_EMP_ID);
        Biz_EmpInfos tgt_emp_Info = new Biz_EmpInfos(TGT_EMP_ID);
        Biz_Com_Dept_Info est_dept_Info = new Biz_Com_Dept_Info(EST_DEPT_ID);
        Biz_Com_Dept_Info tgt_dept_Info = new Biz_Com_Dept_Info(TGT_DEPT_ID);



        this.lblEstTermName.Text = string.Format("{0}({1})", DataTypeUtility.GetString(termInfo.EstTerm_Name), DataTypeUtility.GetString(termSubInfo.EstTerm_Sub_Name));
        this.lblEstName.Text = DataTypeUtility.GetString(estInfo.Est_Name);
        


        this.lblEstEmp.Text = string.Format("{1}({0})", DataTypeUtility.GetString(est_dept_Info.DEPT_NAME), DataTypeUtility.GetString(est_emp_Info.Emp_Name));
        this.lblTgtEmp.Text = string.Format("{1}({0})", DataTypeUtility.GetString(tgt_dept_Info.DEPT_NAME), DataTypeUtility.GetString(tgt_emp_Info.Emp_Name));


        Biz_Datas bizData = new Biz_Datas(COMP_ID
                                        , EST_ID
                                        , ESTTERM_REF_ID
                                        , ESTTERM_SUB_ID
                                        , ESTTERM_STEP_ID
                                        , EST_DEPT_ID
                                        , EST_EMP_ID
                                        , TGT_DEPT_ID
                                        , TGT_EMP_ID);

        TOTALPOINT = DataTypeUtility.GetToDouble(bizData.Point);

        lblPoint.Text = string.Format("{0} / 100", TOTALPOINT);

        if (DT_EST_QUESTION == null)
        {
            getEstQuestion();
        }


        if (!IsPostBack)
        {
            doBindEstQuestion();
        }

        setControlState();
    }


    protected void setControlState()
    {
        if (EST_TGT_TYPE.Equals("TGT"))
        {
            //rowTGT_EMP_FEEDBACK.Visible = true;

            //iBtnFeedbackAgree.Visible = true;
            //iBtnFeedbackReject.Visible = true;
            //iBtnSaveOpinion.Visible = true;
        }
        else if (EST_TGT_TYPE.Equals("EST"))
        {
            if (!STATUS_ID.Equals("E"))
            {
                if (STATUS_ID.Equals("N"))
                {
                    if (isPossible_Reject())
                    {
                        iBtnReject.Visible = true;
                    }
                }


                iBtnSaveEst.Visible = true;
            }
        }
    }

    //평가 거부 버튼 보이기 유무, 다면평가 평가자 수 조사
    protected bool isPossible_Reject()
    {
        MicroBSC.Integration.MUL.Biz.Biz_Mul_Basic_Info bizMulBasicInfo = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Basic_Info();

        DataTable dtMulBasicInfo = bizMulBasicInfo.Get_Mul_Basic_Info(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

        int max = 0;
        int middle = 0;
        int min = 0;

        if (dtMulBasicInfo.Rows.Count > 0)
        {
            max = DataTypeUtility.GetToInt32(dtMulBasicInfo.Rows[0]["MAX_EST_EMP_CNT"]);
            middle = DataTypeUtility.GetToInt32(dtMulBasicInfo.Rows[0]["MID_EST_EMP_CNT"]);
            min = DataTypeUtility.GetToInt32(dtMulBasicInfo.Rows[0]["MIN_EST_EMP_CNT"]);
        }

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        // 현재 평가 갯수(피평가자 기준)
        DataTable dtEstData = bizEstData.GetEstData(COMP_ID
                                                  , EST_ID
                                                  , ESTTERM_REF_ID
                                                  , ESTTERM_SUB_ID
                                                  , ESTTERM_STEP_ID
                                                  , ConstDIRECTION_TYPE
                                                  , 0
                                                  , TGT_EMP_ID);


        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Target_Pool bizEstTargetPool = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Target_Pool();

        DataTable dtEstTargetPool = bizEstTargetPool.GetMulEstTargetPool_DB(COMP_ID
                                                                          , EST_ID
                                                                          , ESTTERM_REF_ID
                                                                          , ESTTERM_SUB_ID
                                                                          , TGT_EMP_ID
                                                                          , "N");

        string msg = string.Empty;

        //1.
        bool result = false;
        if (dtEstData.Rows.Count > middle)
        {
            result = true;
        }
        else //2.
        {

            //3.
            if (dtEstTargetPool.Rows.Count <= 0)
            {
                //ltrScript.Text = JSHelper.GetAlertScript("다면평가을 위한 평가자 피평가자 풀에 데이터가 없습니다.", false);
                result = false;
            }

            //4.
            if (dtEstData.Rows.Count <= min)
            {
                //ltrScript.Text = JSHelper.GetAlertScript(string.Format("평가 최소 인원이 {0}명 되지 못하여 평가거부 할 수 없습니다. 관리자에게 문의하세요 ", min), false);
                result = false;
            }
            else
            {
                result = true;
            }
        }

        return result;
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
        lblQobjName.Text = questionDeptEmpMaps.Q_Obj_Name;

        if (Q_OBJ_ID != null && Q_OBJ_ID.Trim().Length > 0)
        {
            Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
            DT_EST_QUESTION = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "").Tables[0];
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("질의평가 항목이 없습니다.");
            //this.iBtnSave.Visible = false;
            //this.iBtnSave.Enabled = false;
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
            e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginX = i - 1;
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



        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas(COMP_ID
                                                               , EST_ID
                                                               , ESTTERM_REF_ID
                                                               , ESTTERM_SUB_ID
                                                               , ESTTERM_STEP_ID
                                                               , EST_DEPT_ID
                                                               , EST_EMP_ID
                                                               , TGT_DEPT_ID
                                                               , TGT_EMP_ID
                                                               , q_sbj_id);

        WebUtility.FindByValueRadioButtonList(rdoQuestionItem, questionDatas.Q_Itm_ID);
    }


    /* 다면평가 평가 거부 프로세스
     * 1. 현재 피평가자 기준의 평가자 리스트가 평가 최소 인원(middle) 보다 큰가?
     * 2. 만약 1번을 만족하면 평가자 삭제만 한다. 
     * 3. 그렇지 않으면 풀에 데이터가 잇는지를 판단한다.
     * 4. 풀에 데이터가 있다면 평가 거부와 동시에 풀에서 데이터를 랜덤으로 가져온다.
     * 
     * */

    protected void iBtnReject_Click(object sender, ImageClickEventArgs e)
    {
        MicroBSC.Integration.MUL.Biz.Biz_Mul_Basic_Info bizMulBasicInfo = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Basic_Info();

        DataTable dtMulBasicInfo = bizMulBasicInfo.Get_Mul_Basic_Info(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

        int max = 0;
        int middle = 0;
        int min = 0;

        if (dtMulBasicInfo.Rows.Count > 0)
        {
            max = DataTypeUtility.GetToInt32(dtMulBasicInfo.Rows[0]["MAX_EST_EMP_CNT"]);
            middle = DataTypeUtility.GetToInt32(dtMulBasicInfo.Rows[0]["MID_EST_EMP_CNT"]);
            min = DataTypeUtility.GetToInt32(dtMulBasicInfo.Rows[0]["MIN_EST_EMP_CNT"]);
        }

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();

        // 현재 평가 갯수(피평가자 기준)
        DataTable dtEstData = bizEstData.GetEstData(COMP_ID
                                                  , EST_ID
                                                  , ESTTERM_REF_ID
                                                  , ESTTERM_SUB_ID
                                                  , ESTTERM_STEP_ID
                                                  , ConstDIRECTION_TYPE
                                                  , 0
                                                  , TGT_EMP_ID);


        MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Target_Pool bizEstTargetPool = new MicroBSC.Integration.MUL.Biz.Biz_Mul_Est_Target_Pool();

        DataTable dtEstTargetPool = bizEstTargetPool.GetMulEstTargetPool_DB(COMP_ID
                                                                          , EST_ID
                                                                          , ESTTERM_REF_ID
                                                                          , ESTTERM_SUB_ID
                                                                          , TGT_EMP_ID
                                                                          , "N");

        string msg = string.Empty;

        //1.
        if (dtEstData.Rows.Count > middle)
        {
            msg = bizEstData.RemoveEstData(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_EMP_ID
                                            , TGT_EMP_ID
                                            , ConstDIRECTION_TYPE);

        }
        else //2.
        {

            //3.
            if (dtEstTargetPool.Rows.Count <= 0)
            {
                ltrScript.Text = JSHelper.GetAlertScript("다면평가을 위한 평가자 피평가자 풀에 데이터가 없습니다.", false);
                return;
            }

            //4.
            if (dtEstData.Rows.Count <= min)
            {
                ltrScript.Text = JSHelper.GetAlertScript(string.Format("평가 최소 인원이 {0}명 되지 못하여 평가거부 할 수 없습니다. 관리자에게 문의하세요 ", min), false);
                return;
            }
            else
            {
                Random rnd = new Random();
                int rndCnt = rnd.Next(0, dtEstTargetPool.Rows.Count - 1);

                int rnd_est_dept_id = DataTypeUtility.GetToInt32(dtEstTargetPool.Rows[rndCnt]["DEPT_REF_ID"]); // 평가자 부서
                int rnd_est_emp_id = DataTypeUtility.GetToInt32(dtEstTargetPool.Rows[rndCnt]["EST_EMP_ID"]); // 평가자

                MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();

                DataTable dtEstEmpTargetMap = bizEstEmpTargetMap.GetEstEmpEstTargetMap_DB(COMP_ID
                                                                                         , ESTTERM_REF_ID
                                                                                         , ESTTERM_SUB_ID
                                                                                         , ESTTERM_STEP_ID
                                                                                         , EST_ID
                                                                                         , TGT_EMP_ID);

                msg = bizEstData.RemoveEstDataWithRandomEstEmp(dtEstEmpTargetMap
                                                            , COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , EST_DEPT_ID
                                                            , EST_EMP_ID
                                                            , TGT_DEPT_ID
                                                            , TGT_EMP_ID
                                                            , rnd_est_dept_id
                                                            , rnd_est_emp_id
                                                            , ConstDIRECTION_TYPE
                                                            , DateTime.Now
                                                            , this.gUserInfo.Emp_Ref_ID);


            }
        }

        if (msg.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 처리 되었습니다.", "lbnReload", true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(msg, false);
        }

    }



    #region 현재 다면평가 전용 팝업이라 사용되지 않음
    protected void iBtnFeedbackAgree_Click(object sender, ImageClickEventArgs e)
    {
        bool isSuccessed = SaveQuestionData();

        if (isSuccessed)
        {
            Biz_QuestionComments questionComment = new Biz_QuestionComments();
            questionComment.AddQuestionComment(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_DEPT_ID
                                            , EST_EMP_ID
                                            , TGT_DEPT_ID
                                            , TGT_EMP_ID
                                            , ""//txtFeedbackComment.Text
                                            , "TGT"
                                            , "AGR"
                                            , DateTime.Now
                                            , EMP_REF_ID);
        }

        if (!isSuccessed)
        {
            if (ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("질의동의가 정상적으로 처리되지 않았습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 질의평가에 동의 하셨습니다.", "lbnReload", true);
    }
    protected void iBtnFeedbackReject_Click(object sender, ImageClickEventArgs e)
    {
        //_status_id = "O";

        bool isSuccessed = SaveQuestionData();

        if (isSuccessed)
        {
            Biz_QuestionComments questionComment = new Biz_QuestionComments();
            questionComment.AddQuestionComment(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , EST_DEPT_ID
                                            , EST_EMP_ID
                                            , TGT_DEPT_ID
                                            , TGT_EMP_ID
                                            , ""//txtFeedbackComment.Text
                                            , "TGT"
                                            , "RJT"
                                            , DateTime.Now
                                            , EMP_REF_ID);
        }

        if (!isSuccessed)
        {
            if (ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("질의거절이 정상적으로 처리되지 않았습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 질의평가에 거절하셨습니다.", "lbnReload", true);
    }
    protected void iBtnSaveOpinion_Click(object sender, ImageClickEventArgs e)
    {
        bool isSuccessed = SaveQuestionData();

        if (!isSuccessed)
        {
            if (ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("의견상신이 정상적으로 처리되지 않았습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 의견상신이 되었습니다.", "lbnReload", true);
    }
    #endregion

    protected void iBtnSaveEst_Click(object sender, ImageClickEventArgs e)
    {
        bool isSuccessed = SaveQuestionData();

        if (isSuccessed)
        {
            ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("정상적으로 질의평가 되었습니다.", true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("질의평가가 정상적으로 처리되지 않았습니다.", false);
        }
    }
    private bool SaveQuestionData()
    {
        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas();
        Biz_Datas datas = new Biz_Datas();

        Biz_EstInfos bizEstInfo = new Biz_EstInfos(COMP_ID, EST_ID);

        string status_style_id = DataTypeUtility.GetString(bizEstInfo.Status_Style_ID);

        Biz_Status self_status = new Biz_Status();
        DataTable dt_status = self_status.GetStatuses(status_style_id).Tables[0];

        string status_id = DataTypeUtility.GetString(DataTypeUtility.FilterSortDataTable(dt_status, "SEQ=2").Rows[0]["STATUS_ID"]);

        DataTable dtQData = Get_SaveDT_EstQuestion();
        DataTable dtEstData = AddNewEstDataRow(datas.GetDataTableSchema(), status_id);

        //------------------------- 상태 순서 체크 시작 ----------------------------------------

        if (dtEstData.Rows.Count > 0)
        {
            if (datas.IsExist(COMP_ID
                            , EST_ID
                            , ESTTERM_REF_ID
                            , ESTTERM_SUB_ID
                            , ESTTERM_STEP_ID
                            , EST_DEPT_ID
                            , EST_EMP_ID
                            , TGT_DEPT_ID
                            , TGT_EMP_ID))
            {
                datas = new Biz_Datas(COMP_ID
                                    , EST_ID
                                    , ESTTERM_REF_ID
                                    , ESTTERM_SUB_ID
                                    , ESTTERM_STEP_ID
                                    , EST_DEPT_ID
                                    , EST_EMP_ID
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



        bool isSuccessed = questionDatas.SaveQuestionData(dtQData, dtEstData, gUserInfo.Emp_Ref_ID);

        return isSuccessed;
    }
    protected DataTable Get_SaveDT_EstQuestion()
    {
        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas();
        DataTable saveDT = questionDatas.GetDataTableSchema();

        TOTALPOINT = 0;

        for (int i = 0; i < ugrdEstQuestion.Rows.Count; i++)
        {
            DataRow dr = saveDT.NewRow();

            TemplatedColumn tc = (TemplatedColumn)ugrdEstQuestion.Rows[i].Cells.FromKey("Q_ITEM").Column;
            RadioButtonList rdoQuestionItem = (RadioButtonList)((CellItem)tc.CellItems[i]).FindControl("rdoQuestionItem");

            string q_obj_id = Q_OBJ_ID;
            string q_sbj_id = DataTypeUtility.GetString(ugrdEstQuestion.Rows[i].Cells.FromKey("Q_SBJ_ID").Value);
            string q_itm_id = DataTypeUtility.GetString(rdoQuestionItem.SelectedValue);

            Biz_QuestionItems bizQuestionItm = new Biz_QuestionItems(q_itm_id, q_sbj_id, q_obj_id);

            double weight = bizQuestionItm.Weight;
            double point = bizQuestionItm.Point * weight / 100;


            dr["COMP_ID"] = COMP_ID;
            dr["EST_ID"] = EST_ID;
            dr["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
            dr["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
            dr["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
            dr["EST_DEPT_ID"] = EST_DEPT_ID;
            dr["EST_EMP_ID"] = EST_EMP_ID;
            dr["TGT_DEPT_ID"] = TGT_DEPT_ID;
            dr["TGT_EMP_ID"] = TGT_EMP_ID;
            dr["Q_OBJ_ID"] = q_obj_id;
            dr["Q_SBJ_ID"] = q_sbj_id;
            dr["Q_ITM_ID"] = q_itm_id;
            dr["POINT"] = point;
            dr["GRADE_ID"] = "";
            dr["TEXT_VALUE"] = "";
            dr["OPINION"] = "";
            dr["ATTACH_NO"] = "";
            dr["USER"] = gUserInfo.Emp_Ref_ID;

            TOTALPOINT += point;

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
        dataRow["POINT_ORG"] = TOTALPOINT;
        dataRow["POINT_ORG_DATE"] = DateTime.Now;
        dataRow["POINT_AVG"] = DBNull.Value;
        dataRow["POINT_AVG_DATE"] = DBNull.Value;
        dataRow["POINT_STD"] = DBNull.Value;
        dataRow["POINT_STD_DATE"] = DBNull.Value;
        dataRow["POINT"] = TOTALPOINT * 20;//100점 환산 포인트
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
    protected void lbnReload_Click(object sender, EventArgs e)
    { }
}
