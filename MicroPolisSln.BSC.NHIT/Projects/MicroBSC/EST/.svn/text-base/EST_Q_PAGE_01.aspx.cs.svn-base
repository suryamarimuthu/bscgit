using System;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
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
using MicroBSC.Biz.Common.Biz;

using MicroBSC.Estimation.Biz;

// 제    목 : 평가 질의서 1번 스타일
// 내    용 : 정성평가용
public partial class EST_EST_Q_PAGE_01 : EstPageBase
{
    private string  EST_ID;
    private int     EST_DEPT_ID;
    private int     EST_EMP_ID;
    private int     TGT_DEPT_ID;
    private int     TGT_EMP_ID;

    private string  Q_OBJ_ID;
    private string  Q_SBJ_ID;
    private string  Q_ITM_ID;

    private string EST_TGT_TYPE;

    private double TOTALPOINT = 0;
    private double TOTALPOINT_P = 0;
    private double POINT_ORG  = 0;
    private double POINT_ORG_P = 0;

    private string READ_ONLY_YN;

    protected string Q_OBJ_NAME         = "&nbsp;";
    protected string EST_NAME           = "&nbsp;";
    protected string ESTTERM_REF_NAME   = "&nbsp;";
    protected string ESTTERM_SUB_NAME   = "&nbsp;";
    protected string ESTTERM_STEP_NAME  = "&nbsp;";
    protected string ESTTERM_STEP_NAME_P = "&nbsp;";
    protected string EST_EMP_NAME       = "&nbsp;";
    protected string EST_EMP_NAME_P       = "&nbsp;";
    protected string EST_DEPT_NAME      = "&nbsp;";
    protected string EST_DEPT_NAME_P      = "&nbsp;";
    protected string TGT_EMP_NAME       = "&nbsp;";
    protected string TGT_DEPT_NAME      = "&nbsp;";

    private Biz_EstInfos    _estInfos   = null;
    private string _status_style_id     = null;
    private string _status_id           = null;
    private string _q_item_desc_use_yn  = null;
    private string _tgt_opinion_yn      = null;
    private string _feedback_yn         = null;
    private string _tgt_send_type       = null;

    private string VALID_SCRIPT         = "";

    private bool IPREVIOUS_STEP_VISIBLE
    {
        get
        {
            if (ViewState["PREVIOUS_STEP_VISIBLE"] == null)
                ViewState["PREVIOUS_STEP_VISIBLE"] = false;
            return (bool)ViewState["PREVIOUS_STEP_VISIBLE"];
        }
        set
        {
            ViewState["PREVIOUS_STEP_VISIBLE"] = value;
        }
    }
    private int IESTTERM_STEP_PREVIOUS_SELECT
    {
        get
        {
            if (ViewState["ESTTERM_STEP_PREVIOUS_SELECT"] == null)
                ViewState["ESTTERM_STEP_PREVIOUS_SELECT"] = 0;
            return (int)ViewState["ESTTERM_STEP_PREVIOUS_SELECT"];
        }
        set
        {
            ViewState["ESTTERM_STEP_PREVIOUS_SELECT"] = value;
        }
    }

    protected void Page_Load(object sender, System.EventArgs e)
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

        READ_ONLY_YN    = WebUtility.GetRequest("READ_ONLY_YN", "N");

        _estInfos           = new Biz_EstInfos(COMP_ID, EST_ID);
        _q_item_desc_use_yn = _estInfos.Q_Item_Desc_Use_YN;
        _tgt_opinion_yn     = _estInfos.Tgt_Opinion_YN;
        _feedback_yn        = _estInfos.FeedBack_YN;
        _tgt_send_type      = BizUtility.GetTgtSendType(_tgt_opinion_yn, _feedback_yn);

        if (!Page.IsPostBack)
        {
            //이전평가차수질의지내용보기가 설정되어있고, 현재차수가 1차수이상일때만
            divPreviousControl.Visible = false;
            Biz_EstInfos bizEstInfo = new Biz_EstInfos(COMP_ID, EST_ID);
            if (bizEstInfo.Question_Previous_Step_YN.Trim() == "Y" && ESTTERM_STEP_ID > 2)
            {
                Biz_TermStepEstMaps bizTermStepEstMap = new Biz_TermStepEstMaps();
                DataSet dsTermStepMap = bizTermStepEstMap.GetTermStepEstMap(COMP_ID, EST_ID);

                if (dsTermStepMap.Tables[0].Rows.Count > 0)
                    if (dsTermStepMap.Tables[0].Select(string.Format("ESTTERM_STEP_ID > 1 AND ESTTERM_STEP_ID < {0}", ESTTERM_STEP_ID)).Length > 0)
                    {
                        this.IPREVIOUS_STEP_VISIBLE = true;
                        DataRow[] drArr = dsTermStepMap.Tables[0].Select(string.Format("ESTTERM_STEP_ID > 1 AND ESTTERM_STEP_ID < {0}", ESTTERM_STEP_ID), "ESTTERM_STEP_ID ASC");
                        for (int i = 0; i < drArr.Length; i++)
                        {
                            ddlStep.Items.Insert(i, new ListItem(drArr[i]["ESTTERM_STEP_NAME"].ToString(), drArr[i]["ESTTERM_STEP_ID"].ToString()));
                        }
                        ddlStep.SelectedIndex = ddlStep.Items.Count - 1;
                        //this.IESTTERM_STEP_PREVIOUS_SELECT = WebUtility.GetIntByValueDropDownList(ddlStep);
                        divPreviousControl.Visible = true;
                    }
            }
        }

        if(READ_ONLY_YN.Equals("N")) 
        {
            Biz_TermInfos   termInfos   = new Biz_TermInfos(ESTTERM_REF_ID);
            Biz_TermSubs    termSubs    = new Biz_TermSubs(COMP_ID, ESTTERM_SUB_ID);
            Biz_TermSteps   termSteps   = new Biz_TermSteps(COMP_ID, ESTTERM_STEP_ID);
            Biz_EmpInfos    estEmpInfos = new Biz_EmpInfos(EST_EMP_ID);
            Biz_EmpInfos    tgtEmpInfos = new Biz_EmpInfos(TGT_EMP_ID);
            Biz_DeptInfos   estDeptInfo = new Biz_DeptInfos(EST_DEPT_ID);
            Biz_DeptInfos   tgtDeptInfo = new Biz_DeptInfos(TGT_DEPT_ID);
            Biz_Datas       data        = new Biz_Datas(  COMP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , EST_DEPT_ID
                                                        , EST_EMP_ID
                                                        , TGT_DEPT_ID
                                                        , TGT_EMP_ID);

            _status_style_id = _estInfos.Status_Style_ID;
            
            Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps(COMP_ID
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , 0
                                                                                    , EST_ID
                                                                                    , ""
                                                                                    , TGT_DEPT_ID
                                                                                    , TGT_EMP_ID
                                                                                    , _estInfos.Owner_Type);
            if(questionDeptEmpMaps.Q_Obj_ID == null) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("피평가자(부서)에 대한 평가질의서가 매핑되지 않았습니다. 성과평가 관리자에게 문의하세요.", true);
                return;
            }

            // 의견상신 : X, 피드백 : O
            if(_tgt_send_type.Equals("FBK")) 
            {
                if(EST_TGT_TYPE.Equals("EST")) 
                {
                    _status_id               = "O";
                    ibnSaveOpinion.Visible   = false;
                    ibnFeedbackAgree.Visible = false;
                    ibnFeedbackReject.Visible= false;

                    // 창을 띄은 사람이 평가자 인지 체크
                    if(EST_EMP_ID == EMP_REF_ID) 
                    {
                        ibnSaveEst.Visible  = true;
                    }
                    else 
                    {
                        ibnSaveEst.Visible  = false;

                        // 롤에 따른 버튼 권한이 있는지 확인
                        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnSaveEst);
                    }
                }
                else if(EST_TGT_TYPE.Equals("TGT")) 
                {
                    _status_id              = "P";
                    ibnSaveEst.Visible      = false;
                    ibnSaveOpinion.Visible  = false;
                    
                    // 창을 띄은 사람이 피평가자 인지 체크
                    if(TGT_EMP_ID == EMP_REF_ID) 
                    {
                        ibnFeedbackAgree.Visible  = true;
                        ibnFeedbackReject.Visible = true;
                    }
                    else 
                    {
                        ibnFeedbackAgree.Visible  = false;
                        ibnFeedbackReject.Visible = false;

                        // 롤에 따른 버튼 권한이 있는지 확인
                        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnFeedbackAgree);
                        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnFeedbackReject);
                    }

                    if(!_status_style_id.Equals("0003")) 
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("피드백 5단계 평가으로 설정되어야 합니다.", true);
                        return;
                    }
                }
            }
            else // 그외 사항에서는
            {
                if(EST_TGT_TYPE.Equals("EST")) 
                {
                    _status_id              = "P";
                    ibnSaveOpinion.Visible   = false;
                    ibnFeedbackAgree.Visible = false;
                    ibnFeedbackReject.Visible= false;

                    // 창을 띄은 사람이 평가자 인지 체크
                    if(EST_EMP_ID == EMP_REF_ID) 
                    {
                        ibnSaveEst.Visible  = true;
                    }
                    else 
                    {
                        ibnSaveEst.Visible  = false;

                        // 롤에 따른 버튼 권한이 있는지 확인
                        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnSaveEst);
                    }
                }
                else if(EST_TGT_TYPE.Equals("TGT")) 
                {
                    _status_id                = "O";
                    ibnSaveEst.Visible        = false;
                    ibnFeedbackAgree.Visible  = false;
                    ibnFeedbackReject.Visible = false;
                    
                    // 창을 띄은 사람이 피평가자 인지 체크

                    Biz_DeptOpinionTgtEmps deptOpinionTgtEmp    = new Biz_DeptOpinionTgtEmps();
                    DataTable dataTable                         = deptOpinionTgtEmp.GetDeptOpinionTgtEmp( COMP_ID
                                                                                                        , EST_ID
                                                                                                        , EMP_REF_ID).Tables[0];

                    if(dataTable.Rows.Count > 0) 
                    {
                        if(TGT_DEPT_ID == DataTypeUtility.GetToInt32(dataTable.Rows[0]["TGT_DEPT_ID"])) 
                        {
                            ibnSaveOpinion.Visible  = true;
                        }
                        else 
                        {
                            ibnSaveOpinion.Visible  = false;

                            // 롤에 따른 버튼 권한이 있는지 확인
                            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnSaveOpinion);
                        }    
                    }
                    else 
                    {
                        ibnSaveOpinion.Visible  = false;
                    }

                    if(!_status_style_id.Equals("0002")) 
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("의견상신 5단계 평가으로 설정되어야 합니다.", true);
                        return;
                    }
                }
            }

            if(data.Status_ID.Equals("E")) 
            {
                ibnSaveEst.Visible        = false;
                ibnSaveOpinion.Visible    = false;
                ibnFeedbackAgree.Visible  = false;
                ibnFeedbackReject.Visible = false;
            }

            Q_OBJ_ID            = questionDeptEmpMaps.Q_Obj_ID;
            EST_NAME            = _estInfos.Est_Name;
            ESTTERM_REF_NAME    = termInfos.EstTerm_Name;
            ESTTERM_SUB_NAME    = termSubs.EstTerm_Sub_Name;
            ESTTERM_STEP_NAME   = termSteps.EstTerm_Step_Name;
            EST_EMP_NAME        = estEmpInfos.Emp_Name;
            TGT_EMP_NAME        = tgtEmpInfos.Emp_Name;
            EST_DEPT_NAME       = estDeptInfo.Dept_Name;
            TGT_DEPT_NAME       = tgtDeptInfo.Dept_Name;
        }
        else 
        {
            Q_OBJ_ID                = WebUtility.GetRequest("Q_OBJ_ID");
            ibnSaveEst.Visible        = false;
            ibnSaveOpinion.Visible    = false;
            ibnFeedbackAgree.Visible  = false;
            ibnFeedbackReject.Visible = false;
        }

        if (!Page.IsPostBack)
        {
            DataListBinding();
            DoBindingPreviousStepQeustion();
            ibnSaveEst.Attributes.Add("onclick", "if(confirm('평가내용을 저장하시겠습니까?')) return ConfirmQuesiton();else return false;");
            ibnSaveOpinion.Attributes.Add("onclick", "return confirm('평가자에게 의견을 상신하시겠습니까?');");
            ibnFeedbackAgree.Attributes.Add("onclick", "return confirm('평가질의에 동의하십니까?');");
            ibnFeedbackReject.Attributes.Add("onclick", "return confirm('평가질의에 거절하십니까?');");
        }

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        string script = "<script>function ConfirmQuesiton() {" + VALID_SCRIPT + " return true;}</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "ConfirmQuesiton", script);
    }

    protected void ddlStep_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoBindingPreviousStepQeustion();
        ltrScript.Text = JSHelper.GetBlankScript("document.getElementById('tdPreviousStep').style.display = 'block'");
        ltrScript.Text += JSHelper.GetBlankScript("document.getElementById('ddlStep').style.display = 'block'");
    }

    private void DoBindingPreviousStepQeustion()
    {
        if (this.IPREVIOUS_STEP_VISIBLE)
        {
            this.IESTTERM_STEP_PREVIOUS_SELECT = WebUtility.GetIntByValueDropDownList(ddlStep);
            //Biz_TermSteps bizPSV = new Biz_TermSteps(COMP_ID, ESTTERM_STEP_ID - 1);
            ESTTERM_STEP_NAME_P = WebUtility.GetByTextDropDownList(ddlStep); //bizPSV.EstTerm_Step_Name;
            Biz_Datas bizPSV2 = new Biz_Datas(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, this.IESTTERM_STEP_PREVIOUS_SELECT, 0, 0, TGT_DEPT_ID, TGT_EMP_ID);
            Biz_DeptInfos bizPSV3 = new Biz_DeptInfos(bizPSV2.Est_Dept_ID);
            EST_DEPT_NAME_P = bizPSV3.Dept_Name;
            Biz_EmpInfos bizPSV4 = new Biz_EmpInfos(bizPSV2.Est_Emp_ID);
            EST_EMP_NAME_P = bizPSV4.Emp_Name;

            TOTALPOINT_P = 0;

            TOTALPOINT_P = bizPSV2.Point_Org;
            POINT_ORG_P = Math.Round(TOTALPOINT_P, 2);
            if (POINT_ORG_P == 0)
                ltrTotalPoint_P.Text = "미평가";
            else
                ltrTotalPoint_P.Text = POINT_ORG_P.ToString("##0.00") + " / 100";
            DataListBinding_P();
        }
    }

    private void DataListBinding()
    {
        Biz_QuestionObjects questionObjects = new Biz_QuestionObjects(EST_ID, Q_OBJ_ID);
        Q_OBJ_NAME                          = questionObjects.Q_Obj_Name;
        TOTALPOINT                          = 0;

        Biz_QuestionSubjects questionSubjects   = new Biz_QuestionSubjects();
        DataSet ds                              = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "");

        if (ds.Tables.Count == 0)
            return;

        DataTable dt = DataTypeUtility.GetGroupByDataTable(ds.Tables[0], new string[] { "Q_DFN_ID" });

        string q_dfn_ids = DataTypeUtility.GetSplitString(dt, "Q_DFN_ID", ",");

        if (q_dfn_ids.Length > 0)
        {
            DefineDataBinding(q_dfn_ids);
        }

        NoDefineDataBinding(ds);

        POINT_ORG = Math.Round(TOTALPOINT * 0.01, 2);

        if (POINT_ORG == 0)
            ltrTotalPoint.Text = "미평가";
        else
            ltrTotalPoint.Text = POINT_ORG.ToString("###.#0") + " / 100";
    }

    private void DataListBinding_P()
    {
        Biz_QuestionObjects questionObjects = new Biz_QuestionObjects(EST_ID, Q_OBJ_ID);
        Q_OBJ_NAME = questionObjects.Q_Obj_Name;

        Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
        DataSet ds = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "");

        if (ds.Tables.Count == 0)
            return;

        DataTable dt = DataTypeUtility.GetGroupByDataTable(ds.Tables[0], new string[] { "Q_DFN_ID" });

        string q_dfn_ids = DataTypeUtility.GetSplitString(dt, "Q_DFN_ID", ",");

        if (q_dfn_ids.Length > 0)
        {
            DefineDataBinding_P(q_dfn_ids);
        }

        NoDefineDataBinding_P(ds);
    }

    private void NoDefineDataBinding(DataSet ds)
    {
        DataList2.DataSource = DataTypeUtility.FilterSortDataSet(ds, "Q_DFN_ID = ''", null);
        DataList2.DataBind();
    }

    private void NoDefineDataBinding_P(DataSet ds)
    {
        DataList5.DataSource = DataTypeUtility.FilterSortDataSet(ds, "Q_DFN_ID = ''", null);
        DataList5.DataBind();
    }

    private void DefineDataBinding(string q_dfn_ids)
    {
        Biz_QuestionDefines questionDefines = new Biz_QuestionDefines();
        DataSet defineDs                    = questionDefines.GetQuestionDefines();

        DataList1.DataSource                = DataTypeUtility.FilterSortDataSet(  defineDs
                                                                                , string.Format("Q_DFN_ID IN ({0})", q_dfn_ids)
                                                                                , null);
        DataList1.DataBind();
    }

    private void DefineDataBinding_P(string q_dfn_ids)
    {
        Biz_QuestionDefines questionDefines = new Biz_QuestionDefines();
        DataSet defineDs = questionDefines.GetQuestionDefines();

        DataList4.DataSource = DataTypeUtility.FilterSortDataSet(defineDs
                                                                                , string.Format("Q_DFN_ID IN ({0})", q_dfn_ids)
                                                                                , null);
        DataList4.DataBind();
    }

    private void BindingItem(DataListItemEventArgs e)
    {
        DataRowView dr              = (DataRowView)e.Item.DataItem;
        string q_dfn_id             = DataTypeUtility.GetValue(dr["Q_DFN_ID"]);
        string q_sbj_id             = DataTypeUtility.GetValue(dr["Q_SBJ_ID"]);
        string q_obj_id             = DataTypeUtility.GetValue(dr["Q_OBJ_ID"]);
        string q_sbj_define         = DataTypeUtility.GetValue(dr["Q_SBJ_DEFINE"]);
        string q_sbj_desc           = DataTypeUtility.GetValue(dr["Q_SBJ_DESC"]);
        double weight               = DataTypeUtility.GetToDouble(dr["WEIGHT"]);

        Literal ltrDefine           = e.Item.FindControl("ltrLevelDefine") as Literal;
        Literal ltrDesc             = e.Item.FindControl("ltrLevelDesc") as Literal;
        RadioButtonList rBtnList    = e.Item.FindControl("rBtnList") as RadioButtonList;
        TextBox txtValue            = e.Item.FindControl("txtLevelValue") as TextBox;
        HiddenField hAttachNo       = e.Item.FindControl("hAttachNo") as HiddenField;
        DropDownList ddlFileUpload  = e.Item.FindControl("ddlFileUpload") as DropDownList;
        ImageButton ibnDownload     = e.Item.FindControl("ibnDownload") as ImageButton;
        ImageButton iBtnAttach      = e.Item.FindControl("iBtnAttach") as ImageButton;
        Literal ltrUpload           = e.Item.FindControl("ltrUpload") as Literal;
        TextBox txtTextValue        = e.Item.FindControl("txtLevelTextValue") as TextBox;
        TextBox txtOpinion          = e.Item.FindControl("txtLevelOpinion") as TextBox;
        Literal ltrPointData        = e.Item.FindControl("ltrLevelPointData") as Literal;
        Label lblCnt                = e.Item.FindControl("lblCnt") as Label;
        
        TextBoxCommon.SetOnlyInteger(txtValue);

        ltrUpload.Text = string.Format("<a href='#null' onclick=\"mfUpload('{0}');\"><img src='../images/icon/icon_gr_po05.gif' align='absmiddle' border='0'/></a>", hAttachNo.ClientID);

        ibnDownload.CausesValidation    = false;
        ibnDownload.CommandName         = ddlFileUpload.UniqueID;

        ltrDefine.Text  = q_sbj_define;
        ltrDesc.Text    = q_sbj_desc;

        DropDownListCommom.BindDefaultValue(ddlFileUpload, "--------------------", "");

        Biz_QuestionItems questionItems = new Biz_QuestionItems();
        DataSet ds                      = questionItems.GetQuestionItem("", q_sbj_id, Q_OBJ_ID);

        if (ds.Tables[0].Rows.Count == 0)
        {
            rBtnList.Visible    = false;
            txtValue.Visible    = false;
            txtValue.Width      = Unit.Percentage(100);
        }
        else if (ds.Tables[0].Rows[0]["SUBJECT_ITEM_YN"].ToString() == "1")
        {
            rBtnList.Visible    = false;
            txtValue.Visible    = true;
            txtValue.Width      = Unit.Percentage(100);
        }
        else
        {
            // 평가자인지 피평가인지 따라 
            if(EST_TGT_TYPE.Equals("EST")) 
            {
                ibnDownload.Visible         = true;
                ltrUpload.Visible           = false;
            }
            else if(EST_TGT_TYPE.Equals("TGT")) 
            {
                ibnDownload.Visible         = true;
                ltrUpload.Visible           = true;
                rBtnList.Visible            = false;
                txtOpinion.Visible          = false;
            }

            txtValue.Visible    = false;

            // 만약 질의항목에 설명을 표시할 경우
            if(_q_item_desc_use_yn.Equals("Y")) 
            {
                rBtnList.RepeatLayout       = RepeatLayout.Table;
                rBtnList.DataTextField      = "Q_ITEM_DESC";
            }

            rBtnList.DataSource = ds;
            rBtnList.DataBind();

            if(READ_ONLY_YN.Equals("N")) 
            {
                Biz_QuestionDatas questionDatas = new Biz_QuestionDatas(  COMP_ID
                                                                        , EST_ID
                                                                        , ESTTERM_REF_ID
                                                                        , ESTTERM_SUB_ID
                                                                        , ESTTERM_STEP_ID
                                                                        , EST_DEPT_ID
                                                                        , EST_EMP_ID
                                                                        , TGT_DEPT_ID
                                                                        , TGT_EMP_ID
                                                                        , q_sbj_id);
                // 데이타 바인딩

                WebUtility.FindByValueRadioButtonList(rBtnList, questionDatas.Q_Itm_ID);
                TOTALPOINT += questionDatas.Point * weight;

                txtTextValue.Text   = questionDatas.Text_Value;
                txtOpinion.Text     = questionDatas.Opinion;
                ltrPointData.Text   = DataTypeUtility.GetToInt32_String(questionDatas.Point, "##.#0");
                hAttachNo.Value     = questionDatas.Attach_NO;

                SetUploadFileInfo(hAttachNo.Value, ddlFileUpload);

                if(ddlFileUpload.Items.Count > 1)
                    lblCnt.Text = string.Format("({0}건)", ddlFileUpload.Items.Count - 1);

                //----------------- 라디오버튼 유효성 검사 시작 -------------------

                string clientIDs = "";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (i != 0)
                        clientIDs += ";";

                    clientIDs += rBtnList.ClientID + "_" + i.ToString();
                }

                VALID_SCRIPT += string.Format("if(ValidQuestion('{0}', '{1}') == false) return false;", dr["Q_SBJ_NAME"], clientIDs);

                //----------------- 라디오버튼 유효성 검사 끝 -------------------
            }
        }
    }

    private void BindingItem_P(DataListItemEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Item.DataItem;
        string q_dfn_id = DataTypeUtility.GetValue(dr["Q_DFN_ID"]);
        string q_sbj_id = DataTypeUtility.GetValue(dr["Q_SBJ_ID"]);
        string q_obj_id = DataTypeUtility.GetValue(dr["Q_OBJ_ID"]);
        string q_sbj_define = DataTypeUtility.GetValue(dr["Q_SBJ_DEFINE"]);
        string q_sbj_desc = DataTypeUtility.GetValue(dr["Q_SBJ_DESC"]);
        double weight = DataTypeUtility.GetToDouble(dr["WEIGHT"]);

        Literal ltrDefine = e.Item.FindControl("ltrLevelDefine") as Literal;
        Literal ltrDesc = e.Item.FindControl("ltrLevelDesc") as Literal;
        RadioButtonList rBtnList = e.Item.FindControl("rBtnList") as RadioButtonList;
        TextBox txtValue = e.Item.FindControl("txtLevelValue") as TextBox;
        HiddenField hAttachNo = e.Item.FindControl("hAttachNo") as HiddenField;
        DropDownList ddlFileUpload = e.Item.FindControl("ddlFileUpload") as DropDownList;
        ImageButton ibnDownload = e.Item.FindControl("ibnDownload") as ImageButton;
        ImageButton iBtnAttach = e.Item.FindControl("iBtnAttach") as ImageButton;
        Literal ltrUpload = e.Item.FindControl("ltrUpload") as Literal;
        TextBox txtTextValue = e.Item.FindControl("txtLevelTextValue") as TextBox;
        TextBox txtOpinion = e.Item.FindControl("txtLevelOpinion") as TextBox;
        Literal ltrPointData = e.Item.FindControl("ltrLevelPointData") as Literal;
        Label lblCnt = e.Item.FindControl("lblCnt") as Label;

        TextBoxCommon.SetOnlyInteger(txtValue);

        ltrUpload.Text = string.Format("<a href='#null' onclick=\"mfUpload('{0}');\"><img src='../images/icon/icon_gr_po05.gif' align='absmiddle' border='0'/></a>", hAttachNo.ClientID);

        ibnDownload.CausesValidation = false;
        ibnDownload.CommandName = ddlFileUpload.UniqueID;

        ltrDefine.Text = q_sbj_define;
        ltrDesc.Text = q_sbj_desc;

        DropDownListCommom.BindDefaultValue(ddlFileUpload, "--------------------", "");

        Biz_QuestionItems questionItems = new Biz_QuestionItems();
        DataSet ds = questionItems.GetQuestionItem("", q_sbj_id, Q_OBJ_ID);

        if (ds.Tables[0].Rows.Count == 0)
        {
            rBtnList.Visible = false;
            txtValue.Visible = false;
            txtValue.Width = Unit.Percentage(100);
        }
        else if (ds.Tables[0].Rows[0]["SUBJECT_ITEM_YN"].ToString() == "1")
        {
            rBtnList.Visible = false;
            txtValue.Visible = true;
            txtValue.Width = Unit.Percentage(100);
        }
        else
        {
            // 평가자인지 피평가인지 따라 
            if (EST_TGT_TYPE.Equals("EST"))
            {
                ibnDownload.Visible = true;
                ltrUpload.Visible = false;
            }
            else if (EST_TGT_TYPE.Equals("TGT"))
            {
                ibnDownload.Visible = true;
                ltrUpload.Visible = true;
                rBtnList.Visible = false;
                txtOpinion.Visible = false;
            }

            txtValue.Visible = false;

            // 만약 질의항목에 설명을 표시할 경우
            if (_q_item_desc_use_yn.Equals("Y"))
            {
                rBtnList.RepeatLayout = RepeatLayout.Table;
                rBtnList.DataTextField = "Q_ITEM_DESC";
            }

            rBtnList.DataSource = ds;
            rBtnList.DataBind();

            Biz_QuestionDatas questionDatas = new Biz_QuestionDatas(COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , this.IESTTERM_STEP_PREVIOUS_SELECT
                                                                    , 0
                                                                    , 0
                                                                    , TGT_DEPT_ID
                                                                    , TGT_EMP_ID
                                                                    , q_sbj_id);
            // 데이타 바인딩

            WebUtility.FindByValueRadioButtonList(rBtnList, questionDatas.Q_Itm_ID);
            TOTALPOINT += questionDatas.Point * weight;

            txtTextValue.Text = questionDatas.Text_Value;
            txtOpinion.Text = questionDatas.Opinion;
            ltrPointData.Text = DataTypeUtility.GetToInt32_String(questionDatas.Point, "##.#0");
            hAttachNo.Value = questionDatas.Attach_NO;

            SetUploadFileInfo(hAttachNo.Value, ddlFileUpload);

            if (ddlFileUpload.Items.Count > 1)
                lblCnt.Text = string.Format("({0}건)", ddlFileUpload.Items.Count - 1);

            //----------------- 라디오버튼 유효성 검사 시작 -------------------

            string clientIDs = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i != 0)
                    clientIDs += ";";

                clientIDs += rBtnList.ClientID + "_" + i.ToString();
            }

            VALID_SCRIPT += string.Format("if(ValidQuestion('{0}', '{1}') == false) return false;", dr["Q_SBJ_NAME"], clientIDs);

            //----------------- 라디오버튼 유효성 검사 끝 -------------------
        }
    }

    private DataTable GetQuestionSubDataTable(DataTable dt, DataList dl)
    {
        //TOTALPOINT = 0;

        for (int i = 0; i < dl.Items.Count; i++)
        {
            RadioButtonList rBtnList    = dl.Items[i].FindControl("rBtnList") as RadioButtonList;
            TextBox txtTextValue        = dl.Items[i].FindControl("txtLevelTextValue") as TextBox;
            TextBox txtOpinion          = dl.Items[i].FindControl("txtLevelOpinion") as TextBox;
            HiddenField hAttachNo       = dl.Items[i].FindControl("hAttachNo") as HiddenField;

            Q_SBJ_ID = dl.DataKeys[dl.Items[i].ItemIndex].ToString();
            Q_ITM_ID = rBtnList.SelectedValue;

            Biz_QuestionItems questionItems         = new Biz_QuestionItems(Q_ITM_ID, Q_SBJ_ID, Q_OBJ_ID);
            Biz_QuestionSubjects questionSubjects   = new Biz_QuestionSubjects(Q_SBJ_ID);

            TOTALPOINT      += (questionItems.Point * questionSubjects.Weight);

            string[,] saAttachInfo  = TypeUtility.GetSplit(hAttachNo.Value);
            string strAttach        = hAttachNo.Value;

            if (saAttachInfo.Length / 2 >= 1)
            {
                if (Convert.ToInt32(saAttachInfo[1, 0]) > 0)
                {
                    strAttach = saAttachInfo[0, 0];
                }
            }

            DataRow dataRow = dt.NewRow();

            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
            dataRow["ESTTERM_STEP_ID"]  = ESTTERM_STEP_ID;
            dataRow["EST_DEPT_ID"]      = EST_DEPT_ID;
            dataRow["EST_EMP_ID"]       = EST_EMP_ID;
            dataRow["TGT_DEPT_ID"]      = TGT_DEPT_ID;
            dataRow["TGT_EMP_ID"]       = TGT_EMP_ID;
            dataRow["Q_OBJ_ID"]         = Q_OBJ_ID;
            dataRow["Q_SBJ_ID"]         = Q_SBJ_ID;
            dataRow["Q_ITM_ID"]         = Q_ITM_ID;
            dataRow["POINT"]            = questionItems.Point;
            //dataRow["GRADE_ID"]         = "";
            dataRow["TEXT_VALUE"]       = txtTextValue.Text;
            dataRow["OPINION"]          = txtOpinion.Text;
            dataRow["ATTACH_NO"]        = strAttach;
            dataRow["USER"]             = EMP_REF_ID;

            dt.Rows.Add(dataRow);
        }

        return dt;
    }

    private DataTable GetQuestionDataTable(DataTable dt, DataList dl)
    {
        for (int i = 0; i < dl.Items.Count; i++)
        {
            DataList dataList = dl.Items[i].FindControl("DataList3") as DataList;
            dt = GetQuestionSubDataTable(dt, dataList);
        }
        return dt;
    }

    private bool SaveQuestionData(string commandName)
    {
        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas();
        Biz_Datas datas                 = new Biz_Datas(  COMP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , EST_DEPT_ID
                                                        , EST_EMP_ID
                                                        , TGT_DEPT_ID
                                                        , TGT_EMP_ID);

        TOTALPOINT = 0;

        DataTable dtQData               = questionDatas.GetDataTableSchema();

        if(DataList1.Items.Count > 0)
            dtQData                     = GetQuestionDataTable(dtQData, DataList1);

        if(DataList2.Items.Count > 0)
            dtQData                     = GetQuestionSubDataTable(dtQData, DataList2);

        DataTable dtEstData             = AddNewEstDataRow(datas.GetDataTableSchema());

        //------------------------- 상태 순서 체크 시작 ----------------------------------------

        if(!commandName.Equals("BIZ_Q_FEEDBACK_REJECT")) 
        {
            if(dtEstData.Rows.Count > 0) 
            {
                if(datas.IsExist(COMP_ID
                            , EST_ID
                            , ESTTERM_REF_ID
                            , ESTTERM_SUB_ID
                            , ESTTERM_STEP_ID
                            , EST_DEPT_ID
                            , EST_EMP_ID
                            , TGT_DEPT_ID
                            , TGT_EMP_ID)) 
                {
                    datas                 = new Biz_Datas(COMP_ID
                                                        , EST_ID
                                                        , ESTTERM_REF_ID
                                                        , ESTTERM_SUB_ID
                                                        , ESTTERM_STEP_ID
                                                        , EST_DEPT_ID
                                                        , EST_EMP_ID
                                                        , TGT_DEPT_ID
                                                        , TGT_EMP_ID);

                    Biz_Status status_data  = new Biz_Status(datas.Status_ID, _status_style_id);
                    Biz_Status status_new   = new Biz_Status(DataTypeUtility.GetValue(dtEstData.Rows[0]["STATUS_ID"]), _status_style_id);

                    if(     status_data.Seq + 1 != status_new.Seq
                        &&  status_data.Seq     != status_new.Seq)
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
                    Biz_Status status_new   = new Biz_Status(DataTypeUtility.GetValue(dtEstData.Rows[0]["STATUS_ID"]), _status_style_id);

                    if(status_new.Seq != 2)
                    {
                        ltrScript.Text = JSHelper.GetAlertScript(string.Format(@"[{0}] 단계은 두번째 단계가 아니여서 정상적으로 처리할 수 없습니다."
                                                                            , status_new.Status_Name)
                                                                , true);
                        return false;
                    }
                }
            }
        }
        
        //------------------------- 상태 순서 체크 끝 ----------------------------------------

        bool isSuccessed = questionDatas.SaveQuestionData(dtQData, dtEstData, gUserInfo.Emp_Ref_ID);
        return isSuccessed;
    }

    private DataTable AddNewEstDataRow(DataTable dtEstData)
    {
        DataRow dataRow = dtEstData.NewRow();

        dataRow["COMP_ID"]                  = COMP_ID;
        dataRow["EST_ID"]                   = EST_ID;
        dataRow["ESTTERM_REF_ID"]           = ESTTERM_REF_ID;
        dataRow["ESTTERM_SUB_ID"]           = ESTTERM_SUB_ID;
        dataRow["ESTTERM_STEP_ID"]          = ESTTERM_STEP_ID;
        dataRow["EST_DEPT_ID"]              = EST_DEPT_ID;
        dataRow["EST_EMP_ID"]               = EST_EMP_ID;
        dataRow["TGT_DEPT_ID"]              = TGT_DEPT_ID;
        dataRow["TGT_EMP_ID"]               = TGT_EMP_ID;
        dataRow["TGT_POS_CLS_ID"]           = DBNull.Value;
        dataRow["TGT_POS_CLS_NAME"]         = DBNull.Value;
        dataRow["TGT_POS_DUT_ID"]           = DBNull.Value;
        dataRow["TGT_POS_DUT_NAME"]         = DBNull.Value;
        dataRow["TGT_POS_GRP_ID"]           = DBNull.Value;
        dataRow["TGT_POS_GRP_NAME"]         = DBNull.Value;
        dataRow["TGT_POS_RNK_ID"]           = DBNull.Value;
        dataRow["TGT_POS_RNK_NAME"]         = DBNull.Value;
        dataRow["TGT_POS_KND_ID"]           = DBNull.Value;
        dataRow["TGT_POS_KND_NAME"]         = DBNull.Value;
        dataRow["POINT_ORG"]                = TOTALPOINT * 0.01;
        dataRow["POINT_ORG_DATE"]           = DateTime.Now;
        dataRow["POINT_AVG"]                = DBNull.Value;
        dataRow["POINT_AVG_DATE"]           = DBNull.Value;
        dataRow["POINT_STD"]                = DBNull.Value;
        dataRow["POINT_STD_DATE"]           = DBNull.Value;
        dataRow["POINT"]                    = TOTALPOINT * 0.01;
        dataRow["POINT_DATE"]               = DateTime.Now;
        dataRow["GRADE_ID"]                 = DBNull.Value;
        dataRow["GRADE_DATE"]               = DBNull.Value;
        dataRow["GRADE_TO_POINT"]           = DBNull.Value;
        dataRow["GRADE_TO_POINT_DATE"]      = DBNull.Value;
        dataRow["STATUS_ID"]                = _status_id;
        dataRow["STATUS_DATE"]              = DateTime.Now;
        dataRow["DATE"]                     = DateTime.Now;
        dataRow["USER"]                     = EMP_REF_ID;

        dtEstData.Rows.Add(dataRow);

        return dtEstData;
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView dr          = (DataRowView) e.Item.DataItem;

            string q_dfn_id         = DataTypeUtility.GetValue(dr["Q_DFN_ID"]);
            string q_dfn_name       = DataTypeUtility.GetValue(dr["Q_DFN_NAME"]);
            string q_dfn_define     = DataTypeUtility.GetValue(dr["Q_DFN_DEFINE"]);

            Literal ltrDefineName   = e.Item.FindControl("ltrLevelDefName") as Literal;
            Literal ltrDefine       = e.Item.FindControl("ltrLevelDefine") as Literal;
            DataList dalList        = e.Item.FindControl("DataList3") as DataList;

            ltrDefineName.Text      = q_dfn_name;
            ltrDefine.Text          = q_dfn_define;

            Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
            DataSet ds              = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, q_dfn_id);
            dalList.DataSource      = ds;
            dalList.DataBind();
        }
    }
    protected void DataList4_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;

            string q_dfn_id = DataTypeUtility.GetValue(dr["Q_DFN_ID"]);
            string q_dfn_name = DataTypeUtility.GetValue(dr["Q_DFN_NAME"]);
            string q_dfn_define = DataTypeUtility.GetValue(dr["Q_DFN_DEFINE"]);

            Literal ltrDefineName = e.Item.FindControl("ltrLevelDefName") as Literal;
            Literal ltrDefine = e.Item.FindControl("ltrLevelDefine") as Literal;
            DataList dalList = e.Item.FindControl("DataList6") as DataList;

            ltrDefineName.Text = q_dfn_name;
            ltrDefine.Text = q_dfn_define;

            Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
            DataSet ds = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, q_dfn_id);
            dalList.DataSource = ds;
            dalList.DataBind();
        }
    }
    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            BindingItem(e);
        }
    }
    protected void DataList5_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            BindingItem_P(e);
        }
    }
    protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            BindingItem(e);
        }
    }
    protected void DataList6_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            BindingItem_P(e);
        }
    }
    
    protected void ibnDownload_Click(object sender, ImageClickEventArgs e)
    {
        DropDownList ddlFileUpload = Page.FindControl(((ImageButton)sender).CommandName) as DropDownList;

        if (ddlFileUpload.SelectedValue.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("첨부된 파일을 선택하세요.");
            return;
        }
        
        string sText    = ddlFileUpload.SelectedItem.Text;
        string sValue   = ddlFileUpload.SelectedItem.Value;

        PageUtility.FileDownLoad(sText.Substring(0, sText.LastIndexOf(" (")), sValue);
    }

    private void SetUploadFileInfo(string asAttachNo, DropDownList ddlFileUpload)
    {
        DataSet lDS = new DataSet();

        ddlFileUpload.Items.Clear();

        Biz_Base_FileUpload bizUpload = new Biz_Base_FileUpload();
        lDS = bizUpload.GetFileUploaded(asAttachNo);

        for (int i = 0; i < lDS.Tables[0].Rows.Count; i++)
        {
            ddlFileUpload.Items.Add(new ListItem(lDS.Tables[0].Rows[i]["v_FileText"].ToString(), lDS.Tables[0].Rows[i]["v_FileValue"].ToString()));
        }

        ddlFileUpload.Items.Insert(0, new ListItem(":: 다운로드 선택 ::", ""));
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {

    }

    protected void ibnSaveEst_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn     = ((ImageButton)sender);
        string commandName  = ibn.CommandName;

        bool isSuccessed = SaveQuestionData(commandName);

        if (!isSuccessed)
        {
            if(ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("질의평가가 실패하였습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 질의평가 되었습니다.", "lbnReload", true);
    }

    protected void ibnSaveOpinion_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn     = ((ImageButton)sender);
        string commandName  = ibn.CommandName;

        bool isSuccessed = SaveQuestionData(commandName);

        if (!isSuccessed)
        {
            if(ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("의견상신이 실패하였습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 의견상신이 되었습니다.", "lbnReload", true);
    }

    protected void ibnFeedbackAgree_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn     = ((ImageButton)sender);
        string commandName  = ibn.CommandName;

        bool isSuccessed = SaveQuestionData(commandName);

        if (!isSuccessed)
        {
            if(ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("질의동의가 실패하였습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 질의평가에 동의하셨습니다.", "lbnReload", true);
    }

    protected void ibnFeedbackReject_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn     = ((ImageButton)sender);
        string commandName  = ibn.CommandName;

        _status_id = "O";

        bool isSuccessed = SaveQuestionData(commandName);

        if (!isSuccessed)
        {
            if(ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("질의거절을 실패하였습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 질의평가에 거절하셨습니다.", "lbnReload", true);
    }
}
