using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

using MicroBSC.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Integration.COM.Biz;
using MicroBSC.Integration.EST.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class EST_EST110500M2 : AppPageBase
{
    #region Properties
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

    #endregion


    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Q_OBJ_ID = DataTypeUtility.GetString(new Biz_QuestionDeptEmpMaps(COMP_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
                                                                           , EST_ID, "", TGT_DEPT_ID, TGT_EMP_ID, "P").Q_Obj_ID);
            TopLabel_Bind();
            Grid_Bind();

        }

        setBtnState();
    } 
    #endregion

    #region Label Bind
    private void TopLabel_Bind()
    {

        this.lblEstTerm.Text = string.Format("{0}({1})",
                DataTypeUtility.GetString(new Biz_TermInfos(ESTTERM_REF_ID).EstTerm_Name),
                DataTypeUtility.GetString(new Biz_TermSubs(COMP_ID, ESTTERM_SUB_ID).EstTerm_Sub_Name));

        this.lblEstName.Text = DataTypeUtility.GetString(new Biz_EstInfos(COMP_ID, EST_ID).Est_Name);

        this.lblEstEmp.Text = string.Format("{1}({0})",
            DataTypeUtility.GetString(new Biz_Com_Dept_Info(EST_DEPT_ID).DEPT_NAME),
            DataTypeUtility.GetString(new Biz_EmpInfos(EST_EMP_ID).Emp_Name));

        this.lblEstOtherEmp.Text = string.Format("{1}({0})",
            DataTypeUtility.GetString(new Biz_Com_Dept_Info(TGT_DEPT_ID).DEPT_NAME),
            DataTypeUtility.GetString(new Biz_EmpInfos(TGT_EMP_ID).Emp_Name));

        this.lblEstGroup.Text = DataTypeUtility.GetString(new Biz_QuestionObjects(EST_ID, Q_OBJ_ID).Q_Obj_Name);

        DateTime update_date = new Biz_QuestionDatas(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID,
            EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID).Update_Date;
        if (update_date == DateTime.MinValue)
        {
            this.lblUpdateDate.Text = "";
        }
        else
        {
            this.lblUpdateDate.Text = update_date.ToString();
        }


        Biz_Datas bizDatas = new Biz_Datas(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID);
        this.lblPoint.Text = string.Format("{0} / {1}",  DataTypeUtility.GetString(bizDatas.Point_Org), 5);
        ugrdEstQuestion.Columns.FromKey("Q_FIRST").Footer.Caption = DataTypeUtility.GetString(bizDatas.Point_Org);
        ugrdEstQuestion.Columns.FromKey("Q_FIRST").Footer.Style.HorizontalAlign = HorizontalAlign.Right;
    } 
    #endregion


    protected void setBtnState()
    {
        if (STATUS_ID.Equals("E"))
        {
            iBtnInsert.Visible = false;
            iBtnInsert.Enabled = false;
        }
    }

    private void Grid_Bind()
    {
        DT_EST_QUESTION = new Biz_QuestionSubjects().GetQuestionSubject("", Q_OBJ_ID, "").Tables[0];
        ugrdEstQuestion.Clear();
        ugrdEstQuestion.DataSource = DT_EST_QUESTION;
        ugrdEstQuestion.DataBind();
        if(DT_EST_QUESTION.Rows.Count > 0)
        {
            ugrdEstQuestion.Rows[0].Cells[0].Activated = true;
        }
    }

    protected void ugrdEstQuestion_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridColumn col_est_1st = e.Layout.Bands[0].Columns.FromKey("Q_FIRST");

        UltraGridColumn col = new UltraGridColumn();
        col.Header.Caption = "자기평가결과";
        col.Width = Unit.Pixel(100);
        col.Key = "Q_ITEM_NAME_SELF";
        e.Layout.Bands[0].Columns.Insert(col_est_1st.Index, col);


        //다면평가 평가자 수
        DataTable pointDt = new MicroBSC.Integration.EST.Biz.Biz_Est_Question_Data().SelectEstQuestionDataSelfPointResultCount(
            ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, Q_OBJ_ID, TGT_EMP_ID, "3O");


        System.Collections.ArrayList est_emp_list = new ArrayList();
        for (int i = 0; i < pointDt.Rows.Count; i++)
        {
            UltraGridColumn cols = new UltraGridColumn();
            cols.Header.Caption = "평가" + (i+1).ToString();
            cols.Width = Unit.Pixel(50);
            cols.Key = pointDt.Rows[i]["EST_EMP_ID"].ToString();
            cols.CellStyle.HorizontalAlign = HorizontalAlign.Right;
            cols.Footer.Total = SummaryInfo.Avg;
            cols.Footer.Formula = "##,##0.00";

            e.Layout.Bands[0].Columns.Insert(col_est_1st.Index, cols);
            est_emp_list.Add(cols.Key);
        }

        UltraGridColumn colEverage = new UltraGridColumn();
        colEverage.Header.Caption = est_emp_list.Count > 0 ? "평균" : "다면평가 평균";
        colEverage.Width = est_emp_list.Count > 0 ? Unit.Pixel(50) : Unit.Pixel(100);
        colEverage.Key = "Q_AVERAGE";
        colEverage.CellStyle.HorizontalAlign = HorizontalAlign.Right;
        colEverage.Format = "##,##0.00";
        e.Layout.Bands[0].Columns.Insert(col_est_1st.Index, colEverage);


        //TemplatedColumn colFirst = new TemplatedColumn();
        //colFirst.Header.Caption = "1차평가";
        //colFirst.Key = "Q_FIRST";
        //colFirst.AllowUpdate = AllowUpdate.Yes;
        //colFirst.DefaultValue = 0;
        //colFirst.Width = 10;
        //colFirst.CellStyle.BackColor = System.Drawing.Color.MintCream;
        //colFirst.DataType = "System.Int32";
        //e.Layout.Bands[0].Columns.Add(colFirst);

        UltraGridColumn hidenItem = new UltraGridColumn();
        hidenItem.Key = "Q_ITM_ID";
        hidenItem.Hidden = true;
        e.Layout.Bands[0].Columns.Insert(col_est_1st.Index, hidenItem);

        UltraGridColumn hidenobjId= new UltraGridColumn();
        hidenobjId.Key = "Q_OBJ_ID";
        hidenobjId.Hidden = true;
        e.Layout.Bands[0].Columns.Insert(col_est_1st.Index, hidenobjId);


        if (est_emp_list.Count > 0)
        {
            //모든 헤더 1씩 내림
            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginY = 1;
                e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginX = i;
            }


            //스팬헤더 추가
            int insert_pos = e.Layout.Bands[0].Columns.FromKey((string)est_emp_list[0]).Index;

            ColumnHeader ch = new ColumnHeader();
            ch.Caption = "다면평가 결과";
            ch.RowLayoutColumnInfo.OriginX = insert_pos - 1;
            ch.RowLayoutColumnInfo.OriginY = 0;
            ch.RowLayoutColumnInfo.SpanX = est_emp_list.Count + 1;//평가자 수 컬럼 + 평균 컬럼

            e.Layout.Bands[0].HeaderLayout.Add(ch);

            //spanY
            for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
            {
                int flag = 0;

                for (int j = 0; j < est_emp_list.Count; j++)
                {
                    string key = e.Layout.Bands[0].Columns[i].Key;

                    if (key.Equals((string)est_emp_list[j]) || key.Equals("Q_AVERAGE"))
                    {
                        flag++;
                        break;
                    }
                }

                if (flag == 0)
                {
                    e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginY = 0;
                    e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.SpanY = 2;
                }
            }
        }




        e.Layout.Bands[0].Columns.FromKey("Q_DFN_NAME").Header.RowLayoutColumnInfo.SpanX = 2;
        e.Layout.Bands[0].Columns.FromKey("Q_DFN_NAME").Header.Caption = "항목";
        int shift_pos = e.Layout.Bands[0].Columns.FromKey("Q_DFN_NAME").Index;
        for (int i = shift_pos + 1; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginX -= 1;
        }



        ////머지된 셀의 색상 조정
        //for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        //{
        //    if (e.Layout.Bands[0].Columns[i].MergeCells)
        //    {
        //        e.Layout.Bands[0].Columns[i].CellStyle.CssClass = "grid_merged_cell";
        //    }
        //}
    }

    protected void ugrdEstQuestion_InitializeRow(object sender, RowEventArgs e)
    {
        string q_sbj_id = DataTypeUtility.GetString(e.Row.Cells.FromKey("Q_SBJ_ID").Value);


        //자기평가 결과
        //DataTable ItemDt = new MicroBSC.Integration.EST.Biz.Biz_Est_Question_Data().SelectEstQuestionDataSelfPoint(Q_OBJ_ID, q_sbj_id);


        Biz_QuestionDatas questionDatas = new Biz_QuestionDatas(COMP_ID
                                                               , EST_ID
                                                               , ESTTERM_REF_ID
                                                               , ESTTERM_SUB_ID
                                                               , ESTTERM_STEP_ID
                                                               , TGT_DEPT_ID
                                                               , TGT_EMP_ID
                                                               , TGT_DEPT_ID
                                                               , TGT_EMP_ID
                                                               , q_sbj_id);


        Biz_QuestionItems questionItems = new Biz_QuestionItems();
        DataTable ItemDt = questionItems.GetQuestionItem(questionDatas.Q_Itm_ID, q_sbj_id, Q_OBJ_ID).Tables[0];


        UltraGridCell uc = e.Row.Cells.FromKey("Q_ITEM_NAME_SELF");
        uc.Value = ItemDt.Rows[0]["Q_ITEM_NAME"].ToString();

        UltraGridCell ugItemNo = e.Row.Cells.FromKey("Q_ITM_ID");
        ugItemNo.Value = ItemDt.Rows[0]["Q_ITM_ID"].ToString();

        UltraGridCell ugobjId = e.Row.Cells.FromKey("Q_OBJ_ID");
        ugobjId.Value = ItemDt.Rows[0]["Q_OBJ_ID"].ToString();


        //다면평가 결과
        DataTable dtPoint = new MicroBSC.Integration.EST.Biz.Biz_Est_Question_Data().SelectEstQuestionDataSelfPointResultPoint(
            ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, Q_OBJ_ID, TGT_EMP_ID, "3O");


        int count = 0;
        double sum = 0;
        for (int i = 0; i < dtPoint.Rows.Count; i++)
        {
            if (dtPoint.Rows[i]["Q_SBJ_ID"].ToString().Equals(q_sbj_id))
            {
                UltraGridCell ugc = e.Row.Cells.FromKey((dtPoint.Rows[i]["EST_EMP_ID"].ToString()));
                ugc.Value = dtPoint.Rows[i]["POINT"].ToString();
                sum += double.Parse(dtPoint.Rows[i]["POINT"].ToString());
                count++;
            }
        }

        //다면평가 평균
        UltraGridCell ugAv = e.Row.Cells.FromKey("Q_AVERAGE");
        if (count == 0)
            ugAv.Value = "-";
        else
            ugAv.Value = Math.Round(sum / count, 2);


        //1차 평가 결과
        questionDatas = new Biz_QuestionDatas(COMP_ID
                                               , EST_ID
                                               , ESTTERM_REF_ID
                                               , ESTTERM_SUB_ID
                                               , ESTTERM_STEP_ID
                                               , EST_DEPT_ID
                                               , EST_EMP_ID
                                               , TGT_DEPT_ID
                                               , TGT_EMP_ID
                                               , q_sbj_id);

        TemplatedColumn tc = (TemplatedColumn)e.Row.Band.Columns.FromKey("Q_FIRST");
        Infragistics.WebUI.WebDataInput.WebNumericEdit ne = (Infragistics.WebUI.WebDataInput.WebNumericEdit)((CellItem)tc.CellItems[e.Row.Index]).FindControl("Q_FIRST");
        ne.Value = DataTypeUtility.GetToDouble(questionDatas.Point);

        if (STATUS_ID.Equals("E"))
        {
            ne.ReadOnly = true;
        }
    }


    protected void iBtnInsert_Click(object sender, EventArgs e)
    {
        if(doSave())
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
        bool result = false;
        double total_point = 0;
        int count = 0;

        DataTable dtSaveQuestiondata = new DataTable();
        dtSaveQuestiondata.Columns.Add("COMP_ID");
        dtSaveQuestiondata.Columns.Add("EST_ID");
        dtSaveQuestiondata.Columns.Add("ESTTERM_REF_ID");
        dtSaveQuestiondata.Columns.Add("ESTTERM_SUB_ID");
        dtSaveQuestiondata.Columns.Add("ESTTERM_STEP_ID");
        dtSaveQuestiondata.Columns.Add("EST_DEPT_ID");
        dtSaveQuestiondata.Columns.Add("EST_EMP_ID");
        dtSaveQuestiondata.Columns.Add("TGT_DEPT_ID");
        dtSaveQuestiondata.Columns.Add("TGT_EMP_ID");
        dtSaveQuestiondata.Columns.Add("Q_OBJ_ID");
        dtSaveQuestiondata.Columns.Add("Q_SBJ_ID");
        dtSaveQuestiondata.Columns.Add("Q_ITM_ID");
        dtSaveQuestiondata.Columns.Add("Q_DFN_ID");
        dtSaveQuestiondata.Columns.Add("POINT");
        dtSaveQuestiondata.Columns.Add("GRADE_ID");
        dtSaveQuestiondata.Columns.Add("TEXT_VALUE");
        dtSaveQuestiondata.Columns.Add("OPINION");
        dtSaveQuestiondata.Columns.Add("ATTACH_NO");
        dtSaveQuestiondata.Columns.Add("USER");

        for (int i = 0; i < ugrdEstQuestion.Rows.Count; i++)
        {
            TemplatedColumn tc = (TemplatedColumn)ugrdEstQuestion.Rows.Band.Columns.FromKey("Q_FIRST");
            Infragistics.WebUI.WebDataInput.WebNumericEdit ne = (Infragistics.WebUI.WebDataInput.WebNumericEdit)((CellItem)tc.CellItems[i]).FindControl("Q_FIRST");
            double point = DataTypeUtility.GetToDouble(ne.Value);

            if (point > 0)
            {
                DataRow dr = dtSaveQuestiondata.NewRow();

                string q_obj_id = Q_OBJ_ID;
                string q_sbj_id = DataTypeUtility.GetString(ugrdEstQuestion.Rows[i].Cells.FromKey("Q_SBJ_ID").Value);
                string q_dfn_id = DataTypeUtility.GetString(ugrdEstQuestion.Rows[i].Cells.FromKey("Q_DFN_ID").Value);


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
                dr["Q_DFN_ID"] = q_dfn_id;
                dr["USER"] = EMP_REF_ID;



                //Biz_QuestionItems questionItems = new Biz_QuestionItems();
                //DataTable dt_item = questionItems.GetQuestionItem("", q_sbj_id, Q_OBJ_ID).Tables[0];
                //string filter = string.Format("POINT={0}", point);
                //DataTable dt_item_filtered = DataTypeUtility.FilterSortDataTable(dt_item, filter);
                //dr["Q_ITM_ID"] = DataTypeUtility.GetString(dt_item_filtered.Rows[0]["Q_ITM_ID"]);
                dr["Q_ITM_ID"] = DBNull.Value;





                dr["POINT"] = Math.Round(point, 1);



                //가중치
                DataTable dt_est_question_filtered = DataTypeUtility.FilterSortDataTable(DT_EST_QUESTION, string.Format("Q_SBJ_ID='{0}'", q_sbj_id));
                int weight = DataTypeUtility.GetToInt32(dt_est_question_filtered.Rows[0]["WEIGHT"]);

                total_point += point * weight / 100;


                //count += new MicroBSC.Integration.EST.Biz.Biz_Est_Question_Data().Insert("1", "3N", ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID
                //        , EST_DEPT_ID, EST_EMP_ID, TGT_DEPT_ID, TGT_EMP_ID
                //        , DataTypeUtility.GetString(ugrdEstQuestion.Rows[i].Cells.FromKey("Q_OBJ_ID").Value)
                //        , DataTypeUtility.GetString(ugrdEstQuestion.Rows[i].Cells.FromKey("Q_SBJ_ID").Value)
                //        , DataTypeUtility.GetString(ugrdEstQuestion.Rows[i].Cells.FromKey("Q_ITM_ID").Value)
                //        , point, EMP_REF_ID);

                dtSaveQuestiondata.Rows.Add(dr);
                count++;
            }
            else
            {
                count = 0;
                break;
            }
        }

        if (count > 0)
        {
            MicroBSC.Estimation.Biz.Biz_QuestionDatas questionDatas = new MicroBSC.Estimation.Biz.Biz_QuestionDatas();
            Biz_Est_Data bizEstData = new Biz_Est_Data();


            Biz_Status bizStatus = bizEstData.Get_New_Est_Status(COMP_ID, EST_ID, STATUS_ID, 4, 1);

            if (bizStatus.Status_ID != null && bizStatus.Status_ID.Trim().Length > 0)
            {
                DataTable dtSaveEstData = AddNewEstDataRow();

                double point_org = Math.Round(total_point, 1);
                dtSaveEstData.Rows[0]["POINT_ORG"] = point_org;
                dtSaveEstData.Rows[0]["POINT_CTRL_ORG"] = point_org;
                dtSaveEstData.Rows[0]["POINT"] = point_org *100 / 5;//환산점수
                dtSaveEstData.Rows[0]["STATUS_ID"] = bizStatus.Status_ID;

                result = questionDatas.SaveQuestionData(dtSaveQuestiondata, dtSaveEstData, gUserInfo.Emp_Ref_ID);
            }
            else
            {
                this.ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 단계로 진행할 수 없습니다.", bizStatus.Status_Name));
            }
        }

        return result;
    }
    private DataTable AddNewEstDataRow()
    {
        Biz_Datas bizDatas = new Biz_Datas();
        DataTable dt = bizDatas.GetDataTableSchema();
        DataRow dataRow = dt.NewRow();

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
        dataRow["POINT_CTRL_ORG"] = -1;
        dataRow["POINT_CTRL_ORG_DATE"] = DateTime.Now;
        dataRow["POINT_ORG"] = -1;
        dataRow["POINT_ORG_DATE"] = DateTime.Now;
        dataRow["POINT_AVG"] = -1;
        dataRow["POINT_AVG_DATE"] = DateTime.Now;
        dataRow["POINT_STD"] = -1;
        dataRow["POINT_STD_DATE"] = DateTime.Now;
        dataRow["POINT"] = -1;
        dataRow["POINT_DATE"] = DateTime.Now;
        dataRow["GRADE_ID"] = DBNull.Value;
        dataRow["GRADE_DATE"] = DBNull.Value;
        dataRow["GRADE_TO_POINT"] = DBNull.Value;
        dataRow["GRADE_TO_POINT_DATE"] = DBNull.Value;
        dataRow["STATUS_ID"] = DBNull.Value;
        dataRow["STATUS_DATE"] = DateTime.Now;
        dataRow["DATE"] = DateTime.Now;
        dataRow["USER"] = gUserInfo.Emp_Ref_ID;

        dt.Rows.Add(dataRow);

        return dt;
    }
}
