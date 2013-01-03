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
using MicroBSC.PRJ.Biz;

public partial class PMS_PMS_Q_PAGE_03 : PrjPageBase
{
    private string EST_ID;
    private int EST_DEPT_ID;
    private int EST_EMP_ID;
    public int PRJ_REF_ID;
    public string PRJ_TYPE;

    private string Q_OBJ_ID;
    private string Q_SBJ_ID;
    private string Q_ITM_ID;

    private string EST_TGT_TYPE;

    private double TOTALPOINT = 0;
    private double POINT_ORG  = 0;

    private string READ_ONLY_YN;
    private string SUBJECT_ITEM_YN = "0";

    protected string Q_OBJ_NAME         = "&nbsp;";
    protected string EST_NAME           = "&nbsp;";
    protected string ESTTERM_REF_NAME   = "&nbsp;";
    protected string ESTTERM_SUB_NAME   = "&nbsp;";
    protected string ESTTERM_STEP_NAME  = "&nbsp;";
    protected string EST_EMP_NAME       = "&nbsp;";
    protected string EST_DEPT_NAME      = "&nbsp;";
    protected string PRJ_NAME           = "&nbsp;";
    protected string PRJ_CODE           = "&nbsp;";


    protected int TGT_DEPT_ID;
    protected int TGT_EMP_ID;
    protected string TGT_DEPT_NAME = "&nbsp;";
    protected string TGT_EMP_NAME = "&nbsp;";   
    protected DataTable quizWeight
    {
        get
        {
            if (ViewState["quizWeight"] == null)
                return null;

            return (DataTable)ViewState["quizWeight"];
        }
        set
        {
            ViewState["quizWeight"] = value;
        }
    }


    private Biz_EstInfos    _estInfos           = null;
    private string _status_style_id             = null;
    private string _status_id                   = null;
    private string _q_item_desc_use_yn          = null;

    private string VALID_SCRIPT         = "";

    private string lblName1 = string.Empty;
    private string lblName2 = string.Empty;
    private double groupNumber = 0;
    private Label lblValue1 = new Label();
    private Label lblValue2 = new Label();
    private string txtValueText = "";
    private List<double> listPoints = new List<double>();

    private int noneSelectCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            quizWeight = new DataTable();
        }
        

        COMP_ID         = WebUtility.GetRequestByInt("COMP_ID");
        EST_ID          = WebUtility.GetRequest("EST_ID");
        ESTTERM_REF_ID  = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = WebUtility.GetRequestByInt("ESTTERM_STEP_ID");
        EST_DEPT_ID     = WebUtility.GetRequestByInt("EST_DEPT_ID");
        EST_EMP_ID      = WebUtility.GetRequestByInt("EST_EMP_ID");
        PRJ_REF_ID      = WebUtility.GetRequestByInt("PRJ_REF_ID");
        EST_TGT_TYPE    = WebUtility.GetRequest("EST_TGT_TYPE", "EST");


        TGT_DEPT_ID = WebUtility.GetRequestByInt("TGT_DEPT_ID", 0);
        TGT_EMP_ID = WebUtility.GetRequestByInt("TGT_EMP_ID", 0);


        READ_ONLY_YN    = WebUtility.GetRequest("READ_ONLY_YN", "N");

        _estInfos = new Biz_EstInfos(COMP_ID, EST_ID);
        _q_item_desc_use_yn = _estInfos.Q_Item_Desc_Use_YN;

        //PRJ_TYPE 
        Biz_Prj_Info objPrjInfo = new Biz_Prj_Info(PRJ_REF_ID);
        PRJ_TYPE = objPrjInfo.IPrj_Type;

        if (READ_ONLY_YN.Equals("N"))
        {
            Biz_TermInfos termInfos = new Biz_TermInfos(ESTTERM_REF_ID);
            Biz_TermSubs termSubs = new Biz_TermSubs(COMP_ID, ESTTERM_SUB_ID);
            Biz_TermSteps termSteps = new Biz_TermSteps(COMP_ID, ESTTERM_STEP_ID);
            Biz_EmpInfos estEmpInfos = new Biz_EmpInfos(EST_EMP_ID);
            Biz_EmpInfos tgtEmpInfos = new Biz_EmpInfos(TGT_EMP_ID);
           
            //Biz_DeptInfos estDeptInfo = new Biz_DeptInfos(EST_DEPT_ID);
            MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info bizComDeptInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info(EST_DEPT_ID);
            MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info tgtDeptInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info(TGT_DEPT_ID);
            

            //Biz_Prj_Data data = new Biz_Prj_Data(COMP_ID
            //                                    , EST_ID
            //                                    , ESTTERM_REF_ID
            //                                    , ESTTERM_SUB_ID
            //                                    , ESTTERM_STEP_ID
            //                                    , EST_DEPT_ID
            //                                    , EST_EMP_ID
            //                                    , PRJ_REF_ID);
            
            



            _status_style_id = _estInfos.Status_Style_ID;

            Biz_Prj_QuestionPrjMap objQuestionPrjMap = new Biz_Prj_QuestionPrjMap(COMP_ID
                                                                                  , ESTTERM_REF_ID
                                                                                  , ESTTERM_SUB_ID
                                                                                  , 0
                                                                                  , EST_ID
                                                                                  , ""
                                                                                  , PRJ_REF_ID);

            if (objQuestionPrjMap.Q_Obj_ID == null)
            {
                ltrScript.Text = JSHelper.GetAlertScript("프로젝트사업명에 대한 평가질의서가 매핑되지 않았습니다.", true);
                return;
            }


            // 창을 띄은 사람이 평가자 인지 체크
            if (EST_EMP_ID == EMP_REF_ID)
            {
                _status_id = "P";
                ibnSaveEst.Visible = true;
            }
            //else
            //{
            //    ibnSaveEst.Visible = false;

            //    // 롤에 따른 버튼 권한이 있는지 확인
            //    //BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnSaveEst);
            //}


            

            Q_OBJ_ID            = objQuestionPrjMap.Q_Obj_ID;
            EST_NAME            = _estInfos.Est_Name;
            ESTTERM_REF_NAME    = termInfos.EstTerm_Name;
            ESTTERM_SUB_NAME    = termSubs.EstTerm_Sub_Name;
            ESTTERM_STEP_NAME   = termSteps.EstTerm_Step_Name;
            EST_EMP_NAME        = estEmpInfos.Emp_Name;
            EST_DEPT_NAME       = bizComDeptInfo.DEPT_NAME;//estDeptInfo.Dept_Name;
            TGT_EMP_NAME = tgtEmpInfos.Emp_Name;
            TGT_DEPT_NAME = tgtDeptInfo.DEPT_NAME;//tgtDeptInfo.Dept_Name;
            PRJ_NAME = objPrjInfo.IPrj_Name;
            PRJ_CODE            = objPrjInfo.IPrj_Code;

        }
        else
        {
            Q_OBJ_ID            = WebUtility.GetRequest("Q_OBJ_ID");
            ibnSaveEst.Visible  = false;
        }

        if (!Page.IsPostBack)
        {
            SetLabelText();

            //임의수정
            Biz_Prj_Data bizPrjData = new Biz_Prj_Data();
            DataTable dt = bizPrjData.GetPrjData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID, PRJ_REF_ID, "", "").Tables[0];
            string Status_ID = "";
            if (dt != null && dt.Rows.Count > 0)
                Status_ID = dt.Rows[0]["STATUS_ID"].ToString();

            if (Status_ID.Equals("E"))
            {
                ibnSaveEst.Visible = false;
            }

            DataListBinding(dt);

            ibnSaveEst.Attributes.Add("onclick", "if(confirm('평가내용을 저장하시겠습니까?')) return ConfirmQuesiton();else return false;");
        }

        ltrScript.Text = "";
    }

    private void SetLabelText()
    {
        if (EST_ID == "3D") // 프로젝트평가
        {
            lblName1 = "평점합계";
            lblName2 = "평점합산";
        }
        else if (EST_ID == "3E") //프로젝트기여도평가
        {
            lblName1 = "";
            lblName2 = "기여도점수";
        }
        else if (EST_ID == "3F") // 종합평가
        {
            lblName1 = "";
            lblName2 = "평점합계";
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        string script = "<script>function ConfirmQuesiton() {" + VALID_SCRIPT + " return true;}</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "ConfirmQuesiton", script);
    }

    private void DataListBinding(DataTable dtPrjData) 
    {
        Biz_QuestionObjects questionObjects = new Biz_QuestionObjects(EST_ID, Q_OBJ_ID);
        Q_OBJ_NAME                          = questionObjects.Q_Obj_Name;
        TOTALPOINT                          = 0;

        Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
        DataSet ds = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, "");

        if (ds.Tables.Count == 0)
            return;

        DataTable dt = DataTypeUtility.GetGroupByDataTable(ds.Tables[0], new string[] { "Q_DFN_ID" });

        string q_dfn_ids = DataTypeUtility.GetSplitString(dt, "Q_DFN_ID", ",");

        if (!q_dfn_ids.Equals(""))
            DefineDataBinding(q_dfn_ids);

        NoDefineDataBinding(ds);

        //MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
        //DataTable dtEstData = bizEstData.GetEstData(COMP_ID
        //                                          , EST_ID
        //                                          , ESTTERM_REF_ID
        //                                          , ESTTERM_SUB_ID
        //                                          , ESTTERM_STEP_ID
        //                                          , ""
        //                                          , EST_EMP_ID
        //                                          , TGT_EMP_ID);

        //MicroBSC.Integration.PRJ.Biz.Biz_Prj_Data bizPrjData = new MicroBSC.Integration.PRJ.Biz.Biz_Prj_Data();
        //DataTable dtPrjData = bizPrjData.Get_Prj_Data_List(PRJ_REF_ID
        //                                                  , COMP_ID
        //                                                  , EST_ID
        //                                                  , ESTTERM_REF_ID
        //                                                  , ESTTERM_SUB_ID
        //                                                  , ESTTERM_STEP_ID
        //                                                  , EST_DEPT_ID
        //                                                  , EST_EMP_ID
        //                                                  , TGT_DEPT_ID
        //                                                  , TGT_EMP_ID
        //                                                  , "");


        //POINT_ORG = Math.Round(TOTALPOINT * 0.01, 2);
        //POINT_ORG = Math.Round(TOTALPOINT / 3, 1);

        POINT_ORG = DataTypeUtility.GetToDouble(dtPrjData.Rows[0]["POINT"]);

        if (POINT_ORG == 0)
            ltrTotalPoint.Text = "미평가";
        else
        {
            ltrTotalPoint.Text = POINT_ORG.ToString("###.0") + " / 100";
        }
    }

    private void NoDefineDataBinding(DataSet ds)
    {
        DataList2.DataSource = DataTypeUtility.FilterSortDataSet(ds, "Q_DFN_ID = ''", null);
        DataList2.DataBind();
    }

    private void DefineDataBinding(string q_dfn_ids)
    {
        Biz_QuestionDefines questionDefines = new Biz_QuestionDefines();
        DataSet defineDs = questionDefines.GetQuestionDefines();

        DataSet ds = DataTypeUtility.FilterSortDataSet(defineDs
                                                                , string.Format("Q_DFN_ID IN ({0})", q_dfn_ids)
                                                                , null);

        DataList1.DataSource = ds;
        DataList1.DataBind();
    }

    private void BindingItem(DataListItemEventArgs e)
    {
        DataRowView dr              = (DataRowView)e.Item.DataItem;

        string q_sbj_id             = DataTypeUtility.GetValue(dr["Q_SBJ_ID"]);
        string q_sbj_name           = DataTypeUtility.GetValue(dr["Q_SBJ_NAME"]);
        string q_sbj_define         = DataTypeUtility.GetValue(dr["Q_SBJ_DEFINE"]);
        double weight               = DataTypeUtility.GetToDouble(dr["WEIGHT"]);

        quizWeight.Columns.Add(q_sbj_id, typeof(double));
        if (quizWeight.Rows.Count == 0)
            quizWeight.Rows.Add(weight/100);
        else
            quizWeight.Rows[0][q_sbj_id] = weight/100;


        Literal ltrSbjName          = e.Item.FindControl("ltrLevelSbjName") as Literal;
        Literal ltrSbjDefine        = e.Item.FindControl("ltrLevelSbjDefine") as Literal;
        RadioButtonList rBtnList    = e.Item.FindControl("rBtnList") as RadioButtonList;
        TextBox txtValue            = e.Item.FindControl("txtLevelValue") as TextBox;
        HiddenField hdfSubItmYN     = e.Item.FindControl("tmpSubItmYN") as HiddenField;
        Literal ltrPointData        = e.Item.FindControl("ltrLevelPointData") as Literal;
        DataList dtList             = e.Item.FindControl("DataList3") as DataList;
        HtmlTableCell tdHeader      = e.Item.FindControl("tdHeader") as HtmlTableCell;
        HtmlTableCell tdContent     = null;

       

        if (dtList == null)
        {
            tdContent = e.Item.FindControl("tdContent") as HtmlTableCell;
        }
        else
        {
            tdContent = dtList.FindControl("tdContent") as HtmlTableCell;
        }

        TextBoxCommon.SetOnlyPercent(txtValue);

        ltrSbjName.Text     = q_sbj_name;
        ltrSbjDefine.Text   = q_sbj_define;

        Biz_QuestionItems questionItems = new Biz_QuestionItems();
        DataSet ds                      = questionItems.GetQuestionItem("", q_sbj_id, Q_OBJ_ID);

        SUBJECT_ITEM_YN = ds.Tables[0].Rows[0]["SUBJECT_ITEM_YN"].ToString();
        hdfSubItmYN.Value = SUBJECT_ITEM_YN;

        if (ds.Tables[0].Rows.Count == 0)
        {
            rBtnList.Visible    = false;
            txtValue.Visible    = false;
            txtValue.Width      = Unit.Percentage(100);
        }
        else if (SUBJECT_ITEM_YN == "1")
        {
            rBtnList.Visible    = false;
            txtValue.Visible    = true;
            txtValue.Width      = Unit.Percentage(100);

            Biz_Prj_QuestionData questionDatas = new Biz_Prj_QuestionData(COMP_ID
                                                                            , EST_ID
                                                                            , ESTTERM_REF_ID
                                                                            , ESTTERM_SUB_ID
                                                                            , ESTTERM_STEP_ID
                                                                            , EST_DEPT_ID
                                                                            , EST_EMP_ID
                                                                            , PRJ_REF_ID
                                                                            , q_sbj_id);

            txtValueText = questionDatas.Text_Value;
            txtValue.Text = txtValueText;
        }
        else
        {
            rBtnList.Visible    = true;
            txtValue.Visible    = false;

            // 만약 질의항목에 설명을 표시할 경우
            if (_q_item_desc_use_yn.Equals("Y"))
            {
                rBtnList.RepeatLayout   = RepeatLayout.Table;
                rBtnList.DataTextField  = "Q_ITEM_DESC";
                tdHeader.Style.Add("width", "260px");

                if (tdContent != null)
                    tdContent.Style.Add("width", "262px");
            }

            rBtnList.DataSource = ds;
            rBtnList.DataBind();

            if (READ_ONLY_YN.Equals("N"))
            {
                //Biz_Prj_QuestionData questionDatas = new Biz_Prj_QuestionData(COMP_ID
                //                                                            , EST_ID
                //                                                            , ESTTERM_REF_ID
                //                                                            , ESTTERM_SUB_ID
                //                                                            , ESTTERM_STEP_ID
                //                                                            , EST_DEPT_ID
                //                                                            , EST_EMP_ID
                //                                                            , PRJ_REF_ID
                //                                                            , q_sbj_id);
                //// 데이타 바인딩
                //WebUtility.FindByValueRadioButtonList(rBtnList, questionDatas.Q_Itm_ID);

                Biz_Prj_QuestionData questionDatas = new Biz_Prj_QuestionData(COMP_ID
                                                                            , EST_ID
                                                                            , ESTTERM_REF_ID
                                                                            , ESTTERM_SUB_ID
                                                                            , ESTTERM_STEP_ID
                                                                            , EST_DEPT_ID
                                                                            , EST_EMP_ID
                                                                            , TGT_EMP_ID
                                                                            , PRJ_REF_ID
                                                                            , q_sbj_id);
                // 데이타 바인딩
                WebUtility.FindByValueRadioButtonList(rBtnList, questionDatas.Q_Itm_ID);

                groupNumber += questionDatas.Point;

                if (questionDatas.Point.Equals(0))
                    noneSelectCount = noneSelectCount + 1;


                if (questionDatas.Point > 0)
                {
                    ltrPointData.Text = "<font color=#BF0000>" + DataTypeUtility.GetToInt32_String(questionDatas.Point, "##.#0") + "</font>점";
                    //TOTALPOINT += questionDatas.Point * weight;
                }

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

    private DataTable GetQuestionSubDataTable(DataTable dt, DataList dl)
    {
       // TOTALPOINT = 0;

        for (int i = 0; i < dl.Items.Count; i++)
        {


            RadioButtonList rBtnList    = dl.Items[i].FindControl("rBtnList") as RadioButtonList;
            TextBox txtValue            = dl.Items[i].FindControl("txtLevelValue") as TextBox;
            HiddenField hdfSubItmYN     = dl.Items[i].FindControl("tmpSubItmYN") as HiddenField;

            Q_SBJ_ID = dl.DataKeys[dl.Items[i].ItemIndex].ToString();
            Q_ITM_ID = rBtnList.SelectedValue;


            Biz_QuestionItems questionItems         = new Biz_QuestionItems(Q_ITM_ID, Q_SBJ_ID, Q_OBJ_ID);
            Biz_QuestionSubjects questionSubjects   = new Biz_QuestionSubjects(Q_SBJ_ID);


            DataRow dataRow = dt.NewRow();

            if (hdfSubItmYN.Value == "1")
            {
                txtValueText = txtValue.Text;

                dataRow["COMP_ID"] = COMP_ID;
                dataRow["EST_ID"] = EST_ID;
                dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
                dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
                dataRow["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
                dataRow["EST_DEPT_ID"] = EST_DEPT_ID;
                dataRow["EST_EMP_ID"] = EST_EMP_ID;
                dataRow["PRJ_REF_ID"] = PRJ_REF_ID;
                dataRow["Q_OBJ_ID"] = Q_OBJ_ID;
                dataRow["Q_SBJ_ID"] = Q_SBJ_ID;
                dataRow["Q_ITM_ID"] = Q_ITM_ID;
                dataRow["POINT"]    = txtValue.Text;
                dataRow["GRADE_ID"] = "";
                dataRow["TEXT_VALUE"] = txtValue.Text;
                dataRow["OPINION"] = "";
                dataRow["ATTACH_NO"] = "";
                //dataRow["USER"] = EMP_REF_ID;
                dataRow["USER"] = TGT_EMP_ID;
            }
            else
            {
                dataRow["COMP_ID"] = COMP_ID;
                dataRow["EST_ID"] = EST_ID;
                dataRow["ESTTERM_REF_ID"] = ESTTERM_REF_ID;
                dataRow["ESTTERM_SUB_ID"] = ESTTERM_SUB_ID;
                dataRow["ESTTERM_STEP_ID"] = ESTTERM_STEP_ID;
                dataRow["EST_DEPT_ID"] = EST_DEPT_ID;
                dataRow["EST_EMP_ID"] = EST_EMP_ID;
                dataRow["PRJ_REF_ID"] = PRJ_REF_ID;
                dataRow["Q_OBJ_ID"] = Q_OBJ_ID;
                dataRow["Q_SBJ_ID"] = Q_SBJ_ID;
                dataRow["Q_ITM_ID"] = Q_ITM_ID;
                dataRow["POINT"] = questionItems.Point;
                dataRow["GRADE_ID"] = "";
                dataRow["TEXT_VALUE"] = txtValue.Text;
                dataRow["OPINION"] = "";
                dataRow["ATTACH_NO"] = "";
                //dataRow["USER"] = EMP_REF_ID;
                dataRow["USER"] = TGT_EMP_ID;
            }

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

    private void SaveQuestionData()
    {
        Biz_Prj_QuestionData questionDatas  = new Biz_Prj_QuestionData();
        Biz_Prj_Data datas                  = new Biz_Prj_Data();
        DataTable dtQData                   = questionDatas.GetDataTableSchema();
        dtQData                             = GetQuestionDataTable(dtQData, DataList1);
        dtQData                             = GetQuestionSubDataTable(dtQData, DataList2);

        DataTable dtPrjData = AddNewPrjDataRow(datas.GetDataTableSchema(), dtQData);

        bool isSuccessed    = questionDatas.SaveQuestionData(dtQData, dtPrjData);

        if (!isSuccessed)
        {
            ltrScript.Text = JSHelper.GetAlertScript("데이터 저장 중 실패하였습니다.", false);
            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 저장되었습니다.", "lbnReload", true);
    }


    private void SaveQuestionData_TGT_ID()
    {
        Biz_Prj_QuestionData questionDatas = new Biz_Prj_QuestionData();
        Biz_Prj_Data datas = new Biz_Prj_Data();
        DataTable dtQData = questionDatas.GetDataTableSchema();
        dtQData = GetQuestionDataTable(dtQData, DataList1);
        dtQData = GetQuestionSubDataTable(dtQData, DataList2);

        DataTable dtPrjData = AddNewPrjDataRow(datas.GetDataTableSchema(), dtQData);

        bool isSuccessed = questionDatas.SaveQuestionData_TGT_ID(dtQData, dtPrjData);

        if (!isSuccessed)
        {
            ltrScript.Text = JSHelper.GetAlertScript("데이터 저장 중 실패하였습니다.", false);
            return;
        }

        ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 저장되었습니다.", "lbnReload", true);
    }

    private DataTable AddNewPrjDataRow(DataTable dtPrjData, DataTable quizData)
    {
        DataRow dataRow = dtPrjData.NewRow();

        dataRow["COMP_ID"]          = COMP_ID;
        dataRow["EST_ID"]           = EST_ID;
        dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
        dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
        dataRow["ESTTERM_STEP_ID"]  = ESTTERM_STEP_ID;
        dataRow["EST_DEPT_ID"]      = EST_DEPT_ID;
        dataRow["EST_EMP_ID"]       = EST_EMP_ID;
        dataRow["TGT_DEPT_ID"]      = TGT_DEPT_ID;
        dataRow["TGT_EMP_ID"]       = TGT_EMP_ID;
        dataRow["PRJ_REF_ID"]       = PRJ_REF_ID;
        dataRow["POINT"]            = CalcPoint(quizData);
        dataRow["POINT_DATE"]       = DateTime.Now;
        dataRow["STATUS_ID"]        = _status_id;
        dataRow["STATUS_DATE"]      = DateTime.Now;
        dataRow["DATE"]             = DateTime.Now;
        dataRow["USER"]             = EMP_REF_ID;

        dtPrjData.Rows.Add(dataRow);

        return dtPrjData;
    }


    protected double CalcPoint(DataTable dtQuiz)
    {
        double Result = 0.0;

        for (int i = 0; i < dtQuiz.Rows.Count; i++)
        {
            string q_sbj_id = dtQuiz.Rows[i]["Q_SBJ_ID"].ToString();
            string point = dtQuiz.Rows[i]["POINT"].ToString();

            object calcPoint = quizWeight.Compute(string.Format("SUM({0})*{1}", q_sbj_id, point), null);

            Result += DataTypeUtility.GetToDouble(calcPoint);
        }

        return Result;
    }


    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            groupNumber = 0; // 정의별합산점수초기화
            noneSelectCount = 0;

            DataRowView dr = (DataRowView)e.Item.DataItem;

            string q_dfn_id = DataTypeUtility.GetString(dr["Q_DFN_ID"]);

            Biz_QuestionDefines questionDefines = new Biz_QuestionDefines(q_dfn_id, "");

            Literal ltrDefName  = e.Item.FindControl("ltrLevelDefName") as Literal;
            Literal ltrDefine   = e.Item.FindControl("ltrLevelDefine") as Literal;
            DataList dalList    = e.Item.FindControl("DataList3") as DataList;
            Label lblText1      = e.Item.FindControl("lblAvgSumText") as Label;
            Label lblText2      = e.Item.FindControl("lblAvgText") as Label;
            lblValue1           = e.Item.FindControl("lblAvgSumValue") as Label;
            lblValue2           = e.Item.FindControl("lblAvgValue") as Label;

            ltrDefName.Text     = questionDefines.Q_Dfn_Name;
            ltrDefine.Text      = questionDefines.Q_Dfn_Define;
            lblText1.Text       = lblName1;
            lblText2.Text       = lblName2;

            Biz_QuestionSubjects questionSubjects = new Biz_QuestionSubjects();
            DataSet ds          = questionSubjects.GetQuestionSubject("", Q_OBJ_ID, q_dfn_id);
            dalList.DataSource  = ds;
            dalList.DataBind();

            double tmpSum = 0;
            double tmpSumAvg = 0;

            if (SUBJECT_ITEM_YN == "1")
            {
                lblText1.Text = "";
                lblText2.Text = "환산점수";

                lblValue2.Text = txtValueText;
            }
            else
            {
                 tmpSum = Math.Round(((groupNumber * 100) / (5 * ds.Tables[0].Rows.Count)), 1);
                 tmpSumAvg = Math.Round(((((groupNumber * 100) / (5 * ds.Tables[0].Rows.Count)) * ds.Tables[0].Rows.Count) / (ds.Tables[0].Rows.Count - noneSelectCount)), 1);
                lblValue1.Text = Convert.ToString(tmpSum);
                lblValue2.Text = Convert.ToString(tmpSumAvg);
            }

            TOTALPOINT += DataTypeUtility.GetToDouble(lblValue2.Text);

        }
    }
    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            BindingItem(e);
        }
    }
    protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            BindingItem(e);
            
        }
    }

    protected void lbnReload_Click(object sender, EventArgs e)
    {

    }

    protected void ibnSaveEst_Click(object sender, ImageClickEventArgs e)
    {
        if (TGT_DEPT_ID > 0 && TGT_EMP_ID > 0)
            SaveQuestionData_TGT_ID();
        else
            SaveQuestionData();
    }
}
