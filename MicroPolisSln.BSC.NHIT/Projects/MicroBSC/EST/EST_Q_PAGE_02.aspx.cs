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

// 제    목 : 평가 질의서 2번 스타일
// 내    용 : 역량평가용
public partial class EST_EST_Q_PAGE_02 : EstPageBase
{
    private string STATUS_ID;

    private string  EST_ID;
    private int     EST_DEPT_ID;
    private int     EST_EMP_ID;
    private int     TGT_DEPT_ID;
    private int     TGT_EMP_ID;

    private string  Q_OBJ_ID;
    private string  Q_SBJ_ID;
    private string  Q_ITM_ID;

    private string EST_TGT_TYPE;
    private string Q_STYLE_ID;

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
    protected string EST_EMP_NAME_P     = "&nbsp;";
    protected string EST_DEPT_NAME      = "&nbsp;";
    protected string EST_DEPT_NAME_P    = "&nbsp;";
    protected string TGT_EMP_NAME       = "&nbsp;";
    protected string TGT_DEPT_NAME      = "&nbsp;";

    private Biz_EstInfos    _estInfos   = null;
    private string _status_style_id     = null;
    private string _status_id           = null;
    private string _q_item_desc_use_yn  = null;
    private string _tgt_opinion_yn      = null;
    private string _feedback_yn         = null;
    private string _tgt_send_type       = null;
    private string _tgt_pos_biz_use_yn  = null;

    private string VALID_SCRIPT         = "";

    private int TOTAL_CNT               = 0;

    private const string ConstDIRECTION_TYPE = "MU";

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
        Q_STYLE_ID      = WebUtility.GetRequest("Q_STYLE_ID", "BLK");

        READ_ONLY_YN    = WebUtility.GetRequest("READ_ONLY_YN", "N");

        _estInfos           = new Biz_EstInfos(COMP_ID, EST_ID);
        _q_item_desc_use_yn = _estInfos.Q_Item_Desc_Use_YN;
        _tgt_opinion_yn     = _estInfos.Tgt_Opinion_YN;
        _feedback_yn        = _estInfos.FeedBack_YN;
        _tgt_send_type      = BizUtility.GetTgtSendType(_tgt_opinion_yn, _feedback_yn);
        _tgt_pos_biz_use_yn = _estInfos.Q_Tgt_Pos_Biz_Use_YN;

        Biz_EstInfos bizEstInfos = new Biz_EstInfos();
        DataTable dtEstInfos = bizEstInfos.GetEstInfo(COMP_ID, EST_ID).Tables[0];
        DataRow[] rows = dtEstInfos.Select(string.Format(" EST_STYLE_ID = '{0}' ", "MUL"), " EST_NAME ");
        if (rows.Length > 0)
        {
            if (STATUS_ID.Equals("N"))
            {
                iBtnReject.Visible = true;
            }
            else
            {
                iBtnReject.Visible = false;
            }

            if (STATUS_ID.Equals("E"))
            {
                ibnSaveEst.Visible = false;
            }
        }
        else
        {
            iBtnReject.Visible = false;
        }


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
                        for(int i = 0; i < drArr.Length; i++)
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

            _status_style_id    = _estInfos.Status_Style_ID;
            
            Biz_QuestionDeptEmpMaps questionDeptEmpMaps = new Biz_QuestionDeptEmpMaps(COMP_ID
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , 0
                                                                                    , EST_ID
                                                                                    , ""
                                                                                    , TGT_DEPT_ID
                                                                                    , TGT_EMP_ID
                                                                                    , _estInfos.Owner_Type);

            if(_tgt_pos_biz_use_yn.Equals("N")) 
            {
                if(questionDeptEmpMaps.Q_Obj_ID == null) 
                {
                    ltrScript.Text = JSHelper.GetAlertScript("피평가자(부서)에 대한 평가질의서가 매핑되지 않았습니다. 성과평가 관리자에게 문의하세요.", true);
                    return;
                }
            }
            else 
            {
                
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
                    tblComment.Visible      = true;
                    
                    // 창을 띄은 사람이 피평가자 인지 체크
                    if(TGT_EMP_ID == EMP_REF_ID) 
                    {
                        ibnFeedbackAgree.Visible  = true;
                        ibnFeedbackReject.Visible = false;

                        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnFeedbackAgree);
                        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnFeedbackReject);

                        if(data.Direction_Type.Equals("UP"))
                        {
                            ltrScript.Text = JSHelper.GetAlertScript("상향평가는 피드백을 할 수 없습니다.", true);
                            return;
                        }
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
                    _status_id               = "P";
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
                    if(TGT_EMP_ID == EMP_REF_ID) 
                    {
                        ibnSaveOpinion.Visible  = true;
                    }
                    else 
                    {
                        ibnSaveOpinion.Visible  = false;

                        // 롤에 따른 버튼 권한이 있는지 확인
                        BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnSaveOpinion);
                    }

                    if(!_status_style_id.Equals("0002")) 
                    {
                        ltrScript.Text = JSHelper.GetAlertScript("의견상신 5단계 평가으로 설정되어야 합니다.", true);
                        return;
                    }
                }
            }

            if(_tgt_send_type.Equals("FBK")) 
            {
                if(data.Status_ID.Equals("E")) 
                {
                    ibnSaveEst.Visible        = false;
                    ibnSaveOpinion.Visible    = false;
                    ibnFeedbackAgree.Visible = false;
                    ibnFeedbackReject.Visible = false;
                }
                else if (data.Status_ID.Equals("C")) 
                {
                    if (EST_TGT_TYPE.Equals("TGT"))
                    {
                        ibnFeedbackAgree.Visible = true;
                        ibnFeedbackReject.Visible = true;
                    }
                }
                else
                {
                    ibnFeedbackAgree.Visible = false;
                    ibnFeedbackReject.Visible = false;
                }

                if(data.Status_ID.Equals("C")) 
                {
                    ibnSaveEst.Visible        = false;
                }
            }
            else 
            {
                if (data.Status_ID.Equals("E"))
                {
                    ibnSaveEst.Visible = false;
                    ibnSaveOpinion.Visible = false;
                    ibnFeedbackAgree.Visible = true;
                    ibnFeedbackReject.Visible = true;
                }
                else
                {
                    ibnFeedbackAgree.Visible = false;
                    ibnFeedbackReject.Visible = false;
                }

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
            Q_OBJ_ID                  = WebUtility.GetRequest("Q_OBJ_ID");
            ibnSaveEst.Visible        = false;
            ibnSaveOpinion.Visible    = false;
            ibnFeedbackAgree.Visible  = false;
            ibnFeedbackReject.Visible = false;
        }

        if (!Page.IsPostBack)
        {
            DataListBinding();
            DoBindingPreviousStepQeustion();
            
                BindFeedBackComment();

            ibnSaveEst.Attributes.Add("onclick", "if(confirm('평가내용을 저장하시겠습니까?')) return ConfirmQuesiton();else return false;");
            ibnSaveOpinion.Attributes.Add("onclick", "return confirm('평가자에게 의견을 상신하시겠습니까?');");
            ibnFeedbackAgree.Attributes.Add("onclick", "return CheckAgree();");
            ibnFeedbackReject.Attributes.Add("onclick", "return CheckReject();");

            if(!ltrScript.Text.Equals(""))
                return;
        }

        ltrScript.Text = "";

        txtFeedbackComment.Visible = true;

        if (READ_ONLY_YN.Equals("N"))
        {
            lblFeedbackComment.Visible = true;
        }
        else
        {
            lblFeedbackComment.Visible = false;
        }
        

        //lblFeedbackComment.Text = "1111";

        //ibnFeedbackAgree.Visible = true;
        //ibnFeedbackReject.Visible = true;
        //ibnSaveOpinion.Visible = true;

        if (this.STATUS_ID.Equals("E"))
            ibnSaveEst.Visible = false;
    }

    protected void Page_PreRender(object sender, EventArgs e)
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

    private void BindFeedBackComment() 
    {
        Biz_QuestionComments questionComment    = new Biz_QuestionComments();
        DataTable dataTable                     = questionComment.GetQuestionComment(COMP_ID
                                                                                    , EST_ID
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , ESTTERM_STEP_ID
                                                                                    , EST_DEPT_ID
                                                                                    , EST_EMP_ID
                                                                                    , TGT_DEPT_ID
                                                                                    , TGT_EMP_ID).Tables[0];

        lblFeedbackComment.Text += "<br>";

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            if (DataTypeUtility.GetValue(dataRow["CONFIRM_TYPE"]).Equals("AGR"))
            {
                lblFeedbackComment.Text += string.Format("<b>[작성일:{2}] </b><br>{0}<br>"
                                                            , DataTypeUtility.GetValue(dataRow["COMMENT"]).Replace("\r\n", "<br>")
                                                            , dataRow["SEQ"]
                                                            , DataTypeUtility.GetToDateTime(dataRow["CREATE_DATE"]).ToString("yyyy-MM-dd HH:mm:ss"));


                txtFeedbackComment.Text += string.Format("[작성일:{2}] \r\n{0}\r\n"
                                                            , DataTypeUtility.GetValue(dataRow["COMMENT"]).Replace("\r\n", "<br>")
                                                            , dataRow["SEQ"]
                                                            , DataTypeUtility.GetToDateTime(dataRow["CREATE_DATE"]).ToString("yyyy-MM-dd HH:mm:ss"));

            }
            else if (DataTypeUtility.GetValue(dataRow["CONFIRM_TYPE"]).Equals("RJT"))
            {
                lblFeedbackComment.Text += string.Format("<font color='red'><b>[작성일:{2}] </b><br>{0}</font><br>"
                                                            , DataTypeUtility.GetValue(dataRow["COMMENT"]).Replace("\r\n", "<br>")
                                                            , dataRow["SEQ"]
                                                            , DataTypeUtility.GetToDateTime(dataRow["CREATE_DATE"]).ToString("yyyy-MM-dd HH:mm:ss"));

                txtFeedbackComment.Text += string.Format("[작성일:{2}] \r\n{0}\r\n"
                                                            , DataTypeUtility.GetValue(dataRow["COMMENT"]).Replace("\r\n", "<br>")
                                                            , dataRow["SEQ"]
                                                            , DataTypeUtility.GetToDateTime(dataRow["CREATE_DATE"]).ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }


        if(dataTable.Rows.Count == 0) 
            trViewComment.Visible = false;
    }
   
    private void DataListBinding() 
    {
        if(_tgt_pos_biz_use_yn.Equals("N"))
        {
            Biz_QuestionObjects questionObjects     = new Biz_QuestionObjects(EST_ID, Q_OBJ_ID);
            Q_OBJ_NAME                              = questionObjects.Q_Obj_Name;
        }
        else 
        {
            Q_OBJ_NAME                              = "직무평가";
        }
        
        TOTALPOINT = 0;

        Biz_QuestionSubjects questionSubjects   = new Biz_QuestionSubjects();
        DataTable dtSubject                     = null;
        
        if(    _tgt_pos_biz_use_yn.Equals("N") 
            || READ_ONLY_YN.Equals("Y"))
        {
            dtSubject           = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "").Tables[0];

            double weight_total = DataTypeUtility.GetToDouble(dtSubject.Compute("SUM(WEIGHT)", "1 = 1"));

            for(int i = 1; i <= dtSubject.Rows.Count; i++) 
            {
                dtSubject.Rows[i - 1]["WEIGHT"] = DataTypeUtility.GetToDouble(dtSubject.Rows[i - 1]["WEIGHT"]) / weight_total * 100;
            }
        }
        else 
        {
            dtSubject           = questionSubjects.GetQuestionSubject(COMP_ID, EST_ID, TGT_EMP_ID, "").Tables[0];

            double weight_total = DataTypeUtility.GetToDouble(dtSubject.Compute("SUM(WEIGHT)", "1 = 1"));

            for(int i = 1; i <= dtSubject.Rows.Count; i++) 
            {
                dtSubject.Rows[i - 1]["NUM"]    = i;
                dtSubject.Rows[i - 1]["WEIGHT"] = DataTypeUtility.GetToDouble(dtSubject.Rows[i - 1]["WEIGHT"]) / weight_total * 100;
            }
        }

        DataTable dt = DataTypeUtility.GetGroupByDataTable(dtSubject, new string[] { "Q_DFN_ID" });

        string q_dfn_ids = DataTypeUtility.GetSplitString(dt, "Q_DFN_ID", ",");
        if (q_dfn_ids.Length > 0)
            DefineDataBinding(q_dfn_ids);

        NoDefineDataBinding(dtSubject);

        POINT_ORG = Math.Round(TOTALPOINT * 0.01, 2);
        if (POINT_ORG == 0)
            ltrTotalPoint.Text = "미평가";
        else
            ltrTotalPoint.Text = POINT_ORG.ToString("##0.00") + " / 100";

        if (TOTAL_CNT == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("질의항목이 없습니다. 직무평가일 경우는 직무설정이 되었는지 확인해주세요.", true);
        }
    }

    private void DataListBinding_P()
    {
        if (_tgt_pos_biz_use_yn.Equals("N"))
        {
            Biz_QuestionObjects questionObjects = new Biz_QuestionObjects(EST_ID, Q_OBJ_ID);
            Q_OBJ_NAME = questionObjects.Q_Obj_Name;
        }
        else
        {
            Q_OBJ_NAME = "직무평가";
        }

        Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
        DataTable dtSubject = null;

        if (_tgt_pos_biz_use_yn.Equals("N")
            || READ_ONLY_YN.Equals("Y"))
        {
            dtSubject = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "").Tables[0];

            double weight_total = DataTypeUtility.GetToDouble(dtSubject.Compute("SUM(WEIGHT)", "1 = 1"));

            for (int i = 1; i <= dtSubject.Rows.Count; i++)
            {
                dtSubject.Rows[i - 1]["WEIGHT"] = DataTypeUtility.GetToDouble(dtSubject.Rows[i - 1]["WEIGHT"]) / weight_total * 100;
            }
        }
        else
        {
            dtSubject = questionSubjects.GetQuestionSubject(COMP_ID, EST_ID, TGT_EMP_ID, "").Tables[0];

            double weight_total = DataTypeUtility.GetToDouble(dtSubject.Compute("SUM(WEIGHT)", "1 = 1"));

            for (int i = 1; i <= dtSubject.Rows.Count; i++)
            {
                dtSubject.Rows[i - 1]["NUM"] = i;
                dtSubject.Rows[i - 1]["WEIGHT"] = DataTypeUtility.GetToDouble(dtSubject.Rows[i - 1]["WEIGHT"]) / weight_total * 100;
            }
        }
        
        DataTable dt = DataTypeUtility.GetGroupByDataTable(dtSubject, new string[] { "Q_DFN_ID" });

        string q_dfn_ids = DataTypeUtility.GetSplitString(dt, "Q_DFN_ID", ",");
        if (q_dfn_ids.Length > 0)
            DefineDataBinding_P(q_dfn_ids);
        NoDefineDataBinding_P(dtSubject);
    }

    private void NoDefineDataBinding(DataTable dataTable)
    {
        dataTable               = DataTypeUtility.FilterSortDataTable(dataTable, "Q_DFN_ID = ''", null);
        DataList2.DataSource    = dataTable;
        DataList2.DataBind();

        TOTAL_CNT += dataTable.Rows.Count;
    }

    private void NoDefineDataBinding_P(DataTable dataTable)
    {
        dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "Q_DFN_ID = ''", null);
        DataList5.DataSource = dataTable;
        DataList5.DataBind();
    }

    private void DefineDataBinding(string q_dfn_ids)
    {
        Biz_QuestionDefines questionDefines = new Biz_QuestionDefines();
        DataSet defineDs                    = questionDefines.GetQuestionDefines();

        defineDs             = DataTypeUtility.FilterSortDataSet(defineDs
                                                                , string.Format("Q_DFN_ID IN ({0})", q_dfn_ids)
                                                                , null);
        DataList1.DataSource = defineDs;
        DataList1.DataBind();

        TOTAL_CNT += defineDs.Tables[0].Rows.Count;
    }

    private void DefineDataBinding_P(string q_dfn_ids)
    {
        Biz_QuestionDefines questionDefines = new Biz_QuestionDefines();
        DataSet defineDs = questionDefines.GetQuestionDefines();

        defineDs = DataTypeUtility.FilterSortDataSet(defineDs
                                                                , string.Format("Q_DFN_ID IN ({0})", q_dfn_ids)
                                                                , null);
        DataList4.DataSource = defineDs;
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
        Label lblEstText            = e.Item.FindControl("lblEstText") as Label;
        Literal ltrPoint            = e.Item.FindControl("ltrPoint") as Literal;
        TextBox txtValue            = e.Item.FindControl("txtLevelValue") as TextBox;
        Literal ltrPointData        = e.Item.FindControl("ltrLevelPointData") as Literal;
        HtmlTableCell tdLeft        = e.Item.FindControl("tdLeft") as HtmlTableCell;
        HtmlTableCell tdCenter      = e.Item.FindControl("tdCenter") as HtmlTableCell;
        HtmlTableCell tdRight       = e.Item.FindControl("tdRight") as HtmlTableCell;
        HtmlTableRow trTextValue    = e.Item.FindControl("trTextValue") as HtmlTableRow;

        //TextBoxCommon.SetOnlyInteger(txtValue);

        ltrPoint.Text   = " (가중치 : " + weight.ToString("#,##0.00") + " %)";
        ltrDefine.Text  = q_sbj_define;
        ltrDesc.Text    = q_sbj_desc;

        Biz_QuestionItems questionItems = new Biz_QuestionItems();
        DataSet ds                      = questionItems.GetQuestionItem("", q_sbj_id, q_obj_id);

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
            rBtnList.Visible    = true;

            // 만약 질의항목에 설명을 표시할 경우
            if(_q_item_desc_use_yn.Equals("Y")) 
            {
                rBtnList.RepeatDirection    = RepeatDirection.Vertical;
                rBtnList.RepeatLayout       = RepeatLayout.Table;
                rBtnList.DataTextField      = "Q_ITEM_DESC";
                tdLeft.Visible              = false;
                tdRight.Visible             = false;
                tdCenter.Attributes.Remove("background");
            }

            // 만약 피드백을 적용할 경우
            if(_feedback_yn.Equals("Y")) 
            {
                if(EST_TGT_TYPE.Equals("TGT")) 
                {
                    txtValue.ReadOnly = true;
                    rBtnList.Enabled  = false;
                }
                
                if(is_last_row_2)
                    trTextValue.Visible  = true;
            }

            rBtnList.DataSource = ds;
            rBtnList.DataBind();
            
            if(READ_ONLY_YN.Equals("N")) 
            {
                Biz_QuestionDatas questionDatas = new Biz_QuestionDatas( COMP_ID
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

                if (DataTypeUtility.GetToDouble(dr["WEIGHT"]) == 0.0)
                {
                    lblEstText.Text         = "가중치가 0% 인 경우에는 평가를 할 수 없습니다.";
                    lblEstText.Font.Bold    = false;
                    lblEstText.ForeColor    = System.Drawing.Color.Red;
                    rBtnList.Visible        = false;
                }
                if (questionDatas.Point > 0)
                {
                    ltrPointData.Text = " (점수 : <font color=red>" + DataTypeUtility.GetToInt32_String(questionDatas.Point, "##.#0") + "</font> 점)";
                    TOTALPOINT += questionDatas.Point * weight;
                }

                txtValue.Text   = questionDatas.Text_Value;

                //----------------- 라디오버튼 유효성 검사 시작 -------------------

                string clientIDs = "";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (i != 0)
                        clientIDs += ";";

                    clientIDs += rBtnList.ClientID + "_" + i.ToString();
                }

                VALID_SCRIPT += string.Format("if(ValidQuestion('{0}', '{1}', '{2}') == false) return false;", dr["Q_SBJ_NAME"], clientIDs, txtValue.ClientID);

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
        Label lblEstText = e.Item.FindControl("lblEstText") as Label;
        Literal ltrPoint = e.Item.FindControl("ltrPoint") as Literal;
        TextBox txtValue = e.Item.FindControl("txtLevelValue") as TextBox;
        Literal ltrPointData = e.Item.FindControl("ltrLevelPointData") as Literal;
        HtmlTableCell tdLeft = e.Item.FindControl("tdLeft") as HtmlTableCell;
        HtmlTableCell tdCenter = e.Item.FindControl("tdCenter") as HtmlTableCell;
        HtmlTableCell tdRight = e.Item.FindControl("tdRight") as HtmlTableCell;
        HtmlTableRow trTextValue = e.Item.FindControl("trTextValue") as HtmlTableRow;

        ltrPoint.Text = " (가중치 : " + weight.ToString("#,##0.00") + " %)";
        ltrDefine.Text = q_sbj_define;
        ltrDesc.Text = q_sbj_desc;

        Biz_QuestionItems questionItems = new Biz_QuestionItems();
        DataSet ds = questionItems.GetQuestionItem("", q_sbj_id, q_obj_id);

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
            rBtnList.Visible = true;

            // 만약 질의항목에 설명을 표시할 경우
            if (_q_item_desc_use_yn.Equals("Y"))
            {
                rBtnList.RepeatDirection = RepeatDirection.Vertical;
                rBtnList.RepeatLayout = RepeatLayout.Table;
                rBtnList.DataTextField = "Q_ITEM_DESC";
                tdLeft.Visible = false;
                tdRight.Visible = false;
                tdCenter.Attributes.Remove("background");
            }

            // 만약 피드백을 적용할 경우
            if (_feedback_yn.Equals("Y"))
            {
                if (EST_TGT_TYPE.Equals("TGT"))
                {
                    txtValue.ReadOnly = true;
                    rBtnList.Enabled = false;
                }

                if (is_last_row_2)
                    trTextValue.Visible = true;
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

            if (DataTypeUtility.GetToDouble(dr["WEIGHT"]) == 0.0)
            {
                lblEstText.Text = "가중치가 0% 인 경우에는 평가를 할 수 없습니다.";
                lblEstText.Font.Bold = false;
                lblEstText.ForeColor = System.Drawing.Color.Red;
                rBtnList.Visible = false;
            }
            if (questionDatas.Point > 0)
                ltrPointData.Text = " (점수 : <font color=red>" + DataTypeUtility.GetToInt32_String(questionDatas.Point, "##.#0") + "</font> 점)";

            txtValue.Text = questionDatas.Text_Value;

            //----------------- 라디오버튼 유효성 검사 시작 -------------------

            string clientIDs = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i != 0)
                    clientIDs += ";";

                clientIDs += rBtnList.ClientID + "_" + i.ToString();
            }

            VALID_SCRIPT += string.Format("if(ValidQuestion('{0}', '{1}', '{2}') == false) return false;", dr["Q_SBJ_NAME"], clientIDs, txtValue.ClientID);

            //----------------- 라디오버튼 유효성 검사 끝 -------------------
        }
    }

    private DataTable GetQuestionSubDataTable(DataTable dt, DataList dl)
    {
        Biz_QuestionSubjects questionSubjects   = new Biz_QuestionSubjects();
        DataTable dtSubject                     = null;

        //TOTALPOINT = 0;

        // 가중치를 가지고 오기 위해서 
        if(_tgt_pos_biz_use_yn.Equals("N"))
        {
            dtSubject           = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "").Tables[0];

            double weight_total = DataTypeUtility.GetToDouble(dtSubject.Compute("SUM(WEIGHT)", "1 = 1"));

            for(int i = 1; i <= dtSubject.Rows.Count; i++) 
            {
                dtSubject.Rows[i - 1]["WEIGHT"] = DataTypeUtility.GetToDouble(dtSubject.Rows[i - 1]["WEIGHT"]) / weight_total * 100;
            }
        }
        
        else 
        {
            dtSubject           = questionSubjects.GetQuestionSubject(COMP_ID, EST_ID, TGT_EMP_ID, "").Tables[0];

            double weight_total = DataTypeUtility.GetToDouble(dtSubject.Compute("SUM(WEIGHT)", "1 = 1"));

            for(int i = 1; i <= dtSubject.Rows.Count; i++) 
            {
                dtSubject.Rows[i - 1]["WEIGHT"] = DataTypeUtility.GetToDouble(dtSubject.Rows[i - 1]["WEIGHT"]) / weight_total * 100;
            }

            Q_OBJ_ID = "";
        }

        for (int i = 0; i < dl.Items.Count; i++)
        {
            RadioButtonList rBtnList                = dl.Items[i].FindControl("rBtnList") as RadioButtonList;
            TextBox txtValue                        = dl.Items[i].FindControl("txtLevelValue") as TextBox;
            Q_SBJ_ID                                = dl.DataKeys[dl.Items[i].ItemIndex].ToString();
            Q_ITM_ID                                = rBtnList.SelectedValue;

            Biz_QuestionItems questionItems         = new Biz_QuestionItems(Q_ITM_ID, Q_SBJ_ID, Q_OBJ_ID);
            double weight                           = DataTypeUtility.GetToDouble(dtSubject.Select(string.Format("Q_SBJ_ID = '{0}'", Q_SBJ_ID))[0]["WEIGHT"]);
            
            TOTALPOINT += (questionItems.Point * weight);

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
            dataRow["GRADE_ID"]         = "";
            dataRow["TEXT_VALUE"]       = txtValue.Text;
            dataRow["OPINION"]          = "";
            dataRow["ATTACH_NO"]        = "";
            dataRow["USER"]             = EMP_REF_ID;

            dt.Rows.Add(dataRow);
        }
            return dt;
    }

    private DataTable GetQuestionDataTable(DataTable dt, DataList dl)
    {
        for (int i = 0; i < dl.Items.Count; i++)
        {
            DataList dataList   = dl.Items[i].FindControl("DataList3") as DataList;
            dt                  = GetQuestionSubDataTable(dt, dataList);
        }
        return dt;
    }

    private bool SaveQuestionData(string commandName)
    {
        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas();
        Biz_Datas datas                 = new Biz_Datas();

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
            DataRowView dr          = (DataRowView)e.Item.DataItem;

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

            Literal ltrDefineName_P = e.Item.FindControl("ltrLevelDefName_P") as Literal;
            Literal ltrDefine_P = e.Item.FindControl("ltrLevelDefine_P") as Literal;
            DataList dalList = e.Item.FindControl("DataList6") as DataList;

            ltrDefineName_P.Text = q_dfn_name;
            ltrDefine_P.Text = q_dfn_define;

            Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
            DataSet ds = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, q_dfn_id);
            dalList.DataSource = ds;
            dalList.DataBind();
        }
    }

    int i_2 = 0;
    private bool is_last_row_2;

    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            // 의견을 마지막 문항만 넣기 위해서
            //-------------------------------------------
            i_2++;
            DataRowView drw = (DataRowView)e.Item.DataItem;

            if(drw.DataView.Table.Rows.Count == i_2)
            {
                is_last_row_2 = true;
                i_2 = 0;
            }
            else
            {
                is_last_row_2 = false;
            }
            //---------------------------------------------
            BindingItem(e);
        }
    }

    protected void DataList5_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            // 의견을 마지막 문항만 넣기 위해서
            //-------------------------------------------
            i_2++;
            DataRowView drw = (DataRowView)e.Item.DataItem;

            if (drw.DataView.Table.Rows.Count == i_2)
            {
                is_last_row_2 = true;
                i_2 = 0;
            }
            else
            {
                is_last_row_2 = false;
            }
            //---------------------------------------------
            BindingItem_P(e);
        }
    }

    protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            i_2++;
            DataRowView drw = (DataRowView)e.Item.DataItem;

            if(drw.DataView.Table.Rows.Count == i_2)
            {
                is_last_row_2 = true;
                i_2 = 0;
            }
            else
            {
                is_last_row_2 = false;
            }

            BindingItem(e);
        }
    }

    protected void DataList6_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            i_2++;
            DataRowView drw = (DataRowView)e.Item.DataItem;

            if (drw.DataView.Table.Rows.Count == i_2)
            {
                is_last_row_2 = true;
                i_2 = 0;
            }
            else
            {
                is_last_row_2 = false;
            }

            BindingItem_P(e);
        }
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
                ltrScript.Text = JSHelper.GetAlertScript("질의평가가 정상적으로 처리되지 않았습니다.", false);

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
                ltrScript.Text = JSHelper.GetAlertScript("의견상신이 정상적으로 처리되지 않았습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 의견상신이 되었습니다.", "lbnReload", true);
    }

    protected void ibnFeedbackAgree_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn     = ((ImageButton)sender);
        string commandName  = ibn.CommandName;

        bool isSuccessed = SaveQuestionData(commandName);

        if(isSuccessed) 
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
                                            , txtFeedbackComment.Text
                                            , "TGT"
                                            , "AGR"
                                            , DateTime.Now
                                            , EMP_REF_ID);
        }

        if (!isSuccessed)
        {
            if(ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("질의동의가 정상적으로 처리되지 않았습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 질의평가에 동의 하셨습니다.", "lbnReload", true);
    }

    protected void ibnFeedbackReject_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn     = ((ImageButton)sender);
        string commandName  = ibn.CommandName;

        _status_id = "O";

        bool isSuccessed = SaveQuestionData(commandName);

        if(isSuccessed) 
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
                                            , txtFeedbackComment.Text
                                            , "TGT"
                                            , "RJT"
                                            , DateTime.Now
                                            , EMP_REF_ID);
        }

        if (!isSuccessed)
        {
            if(ltrScript.Text.Equals(""))
                ltrScript.Text = JSHelper.GetAlertScript("질의거절이 정상적으로 처리되지 않았습니다.", false);

            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 질의평가에 거절하셨습니다.", "lbnReload", true);
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

        if(dtMulBasicInfo.Rows.Count > 0)
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
    
}
