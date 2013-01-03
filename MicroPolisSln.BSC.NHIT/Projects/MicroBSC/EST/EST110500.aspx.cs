using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;

using MicroBSC.Estimation.Biz;
using MicroBSC.Integration.EST.Biz;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.Documents.Excel;

public partial class EST_EST110500 : EstPageBase
{
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

    public string EST_TGT_TYPE
    {
        get
        {
            if (ViewState["EST_TGT_TYPE"] == null)
            {
                ViewState["EST_TGT_TYPE"] = WebUtility.GetRequest("EST_TGT_TYPE", "EST");
            }

            return (string)ViewState["EST_TGT_TYPE"];
        }
        set
        {
            ViewState["EST_TGT_TYPE"] = value;
        }
    }

    public DataTable DT_EST_DATA
    {
        get
        {
            if (ViewState["DT_EST_DATA"] == null)
            {
                return null;
            }

            return (DataTable)ViewState["DT_EST_DATA"];
        }
        set
        {
            ViewState["DT_EST_DATA"] = value;
        }
    }

    public DataTable DT_EST_DATA_1ST
    {
        get
        {
            if (ViewState["DT_EST_DATA_1ST"] == null)
            {
                return null;
            }

            return (DataTable)ViewState["DT_EST_DATA_1ST"];
        }
        set
        {
            ViewState["DT_EST_DATA_1ST"] = value;
        }
    }

    public DataTable DT_QUESTION_SBJ_POINT
    {
        get
        {
            if (ViewState["DT_QUESTION_SBJ_POINT"] == null)
            {
                return null;
            }

            return (DataTable)ViewState["DT_QUESTION_SBJ_POINT"];
        }
        set
        {
            ViewState["DT_QUESTION_SBJ_POINT"] = value;
        }
    }

    public bool IS_ADMIN;
    public int MAX_POINT;

	protected void Page_Init(object sender, EventArgs e)
	{
		SetPageLayout(phdLayout, phdBottom);
	}

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";

        // 웹 취약성 검사 때문에 처리
        if (EST_JOB_IDS.Equals("-0")
            || EST_TGT_TYPE.Equals("-0"))
        {
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }


        EST_ID = "3N";



        IS_ADMIN = false;
        checkAdmin();



        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID, COMP_ID, "N");
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

            ESTTERM_STEP_ID = WebUtility.GetRequestByInt("ESTTERM_STEP_ID", -1);

            GridBidingData(COMP_ID
                    , EST_ID
                    , ESTTERM_REF_ID
                    , ESTTERM_SUB_ID
                    , ESTTERM_STEP_ID
                    , IS_ADMIN);
            if ( Convert.ToInt32(lblRowCount.Text) > 0){
                UltraWebGrid1.Rows[0].Cells[0].Activated = true;}
        }
        else
        {
            COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
            ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        }
        //평가 상태 범례
        HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, EST_ID);

        
        setControlState();
    }

    protected void checkAdmin()
    {
        MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Role_Rel bizComEmpRoleRel = new MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Role_Rel();
        int isAdmin = 0;
        isAdmin += bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, 1) ? 1 : 0;//시스템관리자

        IS_ADMIN = isAdmin > 0 ? true : false;
    }

    protected void setControlState()
    {
        if (IS_ADMIN)
        {
            iBtnSearchAll.Visible = true;


            
        }



        if (EST_TGT_TYPE.Equals("TGT"))
        {
            iBtnConfirm_SelfEst.Visible = true;
            iBtnCancel_SelfEst.Visible = true;
        }
        else if (EST_TGT_TYPE.Equals("EST"))
        {
            if (IS_ADMIN)
            {
                ddlBIAS_TYPE.Visible = true;
                iBtnBias.Visible = true;
            }


            iBtnConfirm_EstQ.Visible = true;
            iBtnCancel_EstQ.Visible = true;


            if (ESTTERM_STEP_ID == 3)
            {
                iBtnSave_EstQ.Visible = true;


                lblNotice.Visible = true;
                //원래 10%
                //int balance_plus_cnt = DT_EST_DATA.Rows.Count / 10;
                //int balance_minus_cnt = DT_EST_DATA.Rows.Count / 10;
                //lblNotice.Text = string.Format("범위(명) : 가점 ({0}), 감점({1}) 명 [산식 :피평가자 인원 * 10 %]<br />범위(점수) : 가점(0 ~ 1.0), 감점(-1 ~ 0)", balance_plus_cnt, balance_minus_cnt);
                
                //인원 제한 없음 2012.12.17 서대원
                int balance_plus_cnt = DT_EST_DATA.Rows.Count / 1;
                int balance_minus_cnt = DT_EST_DATA.Rows.Count / 1;
                lblNotice.Text = string.Format("범위(점수) : 가점(0 ~ 1.0), 감점(-1 ~ 0)");
                
                lblNotice.Style.Add("font-weight", "bold");
                lblNotice.Style.Add("color", "red");
            }
        }


        
        //평가 상태 범례
        if (tblViewStatus.Rows[0].Cells.Count == 7)
        {
            if (ESTTERM_STEP_ID == 2)
            {
                tblViewStatus.Rows[0].Cells[5].Visible = false;
                tblViewStatus.Rows[0].Cells[6].Visible = false;
            }
            else if (ESTTERM_STEP_ID == 3)
            {
                tblViewStatus.Rows[0].Cells[1].Visible = false;
                tblViewStatus.Rows[0].Cells[2].Visible = false;
                tblViewStatus.Rows[0].Cells[3].Visible = false;
                tblViewStatus.Rows[0].Cells[4].Visible = false;
            }
            else
            {
                tblViewStatus.Visible = false;
            }
        }
        else
        {
            tblViewStatus.Visible = false;
        }
    }

	protected void lbnReload_Click(object sender, EventArgs e)
	{
		
	}



    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
	{
		GridBidingData(COMP_ID
					 , EST_ID
					 , ESTTERM_REF_ID
					 , ESTTERM_SUB_ID
					 , ESTTERM_STEP_ID
					 , false);
	}
    protected void iBtnSearchAll_Click(object sender, ImageClickEventArgs e)
    {
        GridBidingData(COMP_ID
                     , EST_ID
                     , ESTTERM_REF_ID
                     , ESTTERM_SUB_ID
                     , ESTTERM_STEP_ID
                     , true);
    }
    private void GridBidingData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id
                                , bool isAll)
    {
        // 평가정보를 가져온다.
        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        // 해당평가가 존재하는지 여부 체크
        if (!estInfo.IsExists(comp_id, est_id))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
            return;
        }





        int est_emp_id = 0;
        int tgt_dept_id = 0;
        int tgt_emp_id = 0;

        if (EST_TGT_TYPE.Equals("EST"))
        {
            est_emp_id = EMP_REF_ID;
            tgt_dept_id = 0;// 모든 피평가자가 속한 부서를 가져온다.
            tgt_emp_id = 0;
        }
        else if (EST_TGT_TYPE.Equals("TGT"))
        {
            est_emp_id = 0;
            tgt_dept_id = 0;// 모든 피평가자가 속한 부서를 가져온다.
            tgt_emp_id = EMP_REF_ID;
        }

        if (isAll)
        {
            est_emp_id = 0;
            tgt_dept_id = 0;
            tgt_emp_id = 0;
        }

        Biz_Datas est_data = new Biz_Datas();
        DT_EST_DATA = est_data.GetEstData(comp_id
                                        , est_id
                                        , estterm_ref_id
                                        , estterm_sub_id
                                        , estterm_step_id
                                        , 0
                                        , est_emp_id
                                        , tgt_dept_id
                                        , tgt_emp_id).Tables[0];


        if (estterm_step_id == 2 && EST_TGT_TYPE.Equals("EST"))
        {
            //자기평가 완료 이상 1차 평가 데이터
            DT_EST_DATA = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "STATUS_ID = 'C' OR STATUS_ID = 'P' OR STATUS_ID = 'F' OR STATUS_ID = 'N' OR STATUS_ID = 'O'");


            DT_EST_DATA.Columns.Add("STATUS_ID_2ND");

            DataTable dt_est_data_2nd = est_data.GetEstData(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , 3
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , 0).Tables[0];//2차 평가 데이터


            //2차 평가 데이터 상태 추출
            for (int i = 0; i < DT_EST_DATA.Rows.Count; i++)
            {
                DataRow dr = DT_EST_DATA.Rows[i];

                string filter = string.Format(@"
COMP_ID={0} 
AND EST_ID='{1}' 
AND ESTTERM_REF_ID={2} 
AND ESTTERM_SUB_ID={3} 
AND ESTTERM_STEP_ID={4} 
AND TGT_DEPT_ID={5}
AND TGT_EMP_ID={6}
", DataTypeUtility.GetString(dr["COMP_ID"])
 , DataTypeUtility.GetString(dr["EST_ID"])
 , DataTypeUtility.GetString(dr["ESTTERM_REF_ID"])
 , DataTypeUtility.GetString(dr["ESTTERM_SUB_ID"])
 , 3
 , DataTypeUtility.GetString(dr["TGT_DEPT_ID"])
 , DataTypeUtility.GetString(dr["TGT_EMP_ID"]));

                DataTable dt_filtered_est_data_2nd = DataTypeUtility.FilterSortDataTable(dt_est_data_2nd, filter);

                if (dt_filtered_est_data_2nd.Rows.Count > 0)
                {
                    dr["STATUS_ID_2ND"] = DataTypeUtility.GetString(dt_filtered_est_data_2nd.Rows[0]["STATUS_ID"]);
                }
            }
        }
        else if (estterm_step_id == 3 && EST_TGT_TYPE.Equals("EST"))
        {
            //1차 평가 데이터
            DT_EST_DATA.Columns.Add("STATUS_ID_1ST");

            DT_EST_DATA_1ST = est_data.GetEstData(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , 2
                                            , 0
                                            , 0
                                            , 0
                                            , 0).Tables[0];//1차 평가 데이터

            //1차 평가 데이터 상태 추출
            for (int i = 0; i < DT_EST_DATA.Rows.Count; i++)
            {
                DataRow dr = DT_EST_DATA.Rows[i];

                string filter = string.Format(@"
COMP_ID={0} 
AND EST_ID='{1}' 
AND ESTTERM_REF_ID={2} 
AND ESTTERM_SUB_ID={3} 
AND ESTTERM_STEP_ID={4} 
AND TGT_DEPT_ID={5}
AND TGT_EMP_ID={6}
", DataTypeUtility.GetString(dr["COMP_ID"])
 , DataTypeUtility.GetString(dr["EST_ID"])
 , DataTypeUtility.GetString(dr["ESTTERM_REF_ID"])
 , DataTypeUtility.GetString(dr["ESTTERM_SUB_ID"])
 , 2
 , DataTypeUtility.GetString(dr["TGT_DEPT_ID"])
 , DataTypeUtility.GetString(dr["TGT_EMP_ID"]));

                DataTable dt_filtered_est_data_1st = DataTypeUtility.FilterSortDataTable(DT_EST_DATA_1ST, filter);

                if (dt_filtered_est_data_1st.Rows.Count > 0)
                {
                    dr["STATUS_ID_1ST"] = DataTypeUtility.GetString(dt_filtered_est_data_1st.Rows[0]["STATUS_ID"]);
                }
            }




            int total_est_data_cnt = DT_EST_DATA.Rows.Count;

            DT_EST_DATA = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "STATUS_ID_1ST = 'F'");

            int filtered_est_data_cnt = DT_EST_DATA.Rows.Count;

            if (total_est_data_cnt != filtered_est_data_cnt)
            {
                this.ltrScript.Text = JSHelper.GetAlertScript("1차평가가 진행중입니다.");
                return;
            }
        }



        //평가자에게만 보이는 질의평가 결과
        if (EST_TGT_TYPE.Equals("EST"))
        {
            if (estterm_step_id == 2)
            {
                Biz_Est_Question_Data bizEstQuestionData = new Biz_Est_Question_Data();
                DT_QUESTION_SBJ_POINT = bizEstQuestionData.Get_Est_QuestionSbj_Point(comp_id
                                                                                    , est_id
                                                                                    , estterm_ref_id
                                                                                    , estterm_sub_id
                                                                                    , estterm_step_id
                                                                                    , 0
                                                                                    , est_emp_id
                                                                                    , tgt_dept_id
                                                                                    , tgt_emp_id);
            }
            else if (estterm_step_id == 3)
            { 

            }
        }



       // ClearGroupByBoxColumn();

        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = DT_EST_DATA;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = DT_EST_DATA.Rows.Count.ToString("#,##0");
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
	{
        if (EST_TGT_TYPE.Equals("EST"))
        {
            if (ESTTERM_STEP_ID == 2)
            {
                //질의 별 평균 컬럼 활성
                DataTable dt_q_dfn = DataTypeUtility.GetGroupByDataTable(DT_QUESTION_SBJ_POINT, new string[] { "Q_DFN_ID", "Q_DFN_NAME" });

                int insert_pos = e.Layout.Bands[0].Columns.FromKey("Q_SBJ_POINT_AVG").Index;
                for (int i = 0; i < dt_q_dfn.Rows.Count; i++)
                {
                    string q_dfn_name = DataTypeUtility.GetString(dt_q_dfn.Rows[i]["Q_DFN_NAME"]) + "평균";
                    string q_dfn_id = DataTypeUtility.GetString(dt_q_dfn.Rows[i]["Q_DFN_ID"]);
                    string key = q_dfn_id;

                    if (!UltraWebGrid1.Columns.Exists(key))
                    {
                        UltraGridColumn col_q_dfn = new UltraGridColumn();
                        col_q_dfn.BaseColumnName = key;
                        col_q_dfn.Width = Unit.Pixel(100);
                        col_q_dfn.Key = key;
                        col_q_dfn.Header.Caption = q_dfn_name;
                        col_q_dfn.Header.Style.HorizontalAlign = HorizontalAlign.Center;
                        col_q_dfn.CellStyle.HorizontalAlign = HorizontalAlign.Right;

                        UltraWebGrid1.Columns.Insert(insert_pos + i, col_q_dfn);
                    }
                }


                e.Layout.Bands[0].Columns.FromKey("Q_SBJ_POINT_AVG").Hidden = false;
                e.Layout.Bands[0].Columns.FromKey("POINT_ORG").Hidden = false;



                //관리자의 경우 점수 조정 컬럼 활성
                if (IS_ADMIN)
                {
                    e.Layout.Bands[0].Columns.FromKey("POINT_AVG").Hidden = false;
                    e.Layout.Bands[0].Columns.FromKey("POINT_STD").Hidden = false;
                    e.Layout.Bands[0].Columns.FromKey("POINT_CTRL_ORG").Hidden = false;
                }
            }
            else if (ESTTERM_STEP_ID == 3)
            {
                e.Layout.Bands[0].Columns.FromKey("POINT_CTRL_ORG").Header.Caption = "합계점수";
                e.Layout.Bands[0].Columns.FromKey("POINT_ORG_1ST").Hidden = false;
                e.Layout.Bands[0].Columns.FromKey("POINT_CTRL_ORG_1ST").Hidden = false;
                e.Layout.Bands[0].Columns.FromKey("POINT_BALANCE").Hidden = false;
                e.Layout.Bands[0].Columns.FromKey("POINT_CTRL_ORG").Hidden = false;
                e.Layout.Bands[0].Columns.FromKey("POINT").Hidden = false;
            }
        }
	}
	protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
	{
        string status_id = DataTypeUtility.GetString(e.Row.Cells.FromKey("STATUS_ID").Value);
        string status_img_path = DataTypeUtility.GetString(e.Row.Cells.FromKey("STATUS_IMG_PATH").Value);
        string imgTag = string.Format("<img src=\"{0}\" alt={1}>", status_img_path, status_id);

        e.Row.Cells.FromKey("STATUS_IMG").Value = imgTag;


        string popup_path = "";
        if (EST_TGT_TYPE.Equals("TGT"))
        {
            popup_path = "EST110500M1.ASPX";
        }
        else if (EST_TGT_TYPE.Equals("EST"))
        {
            popup_path = "EST110500M2.ASPX";
        }
        e.Row.Cells.FromKey("POPUP_PATH").Value = popup_path;




        if (EST_TGT_TYPE.Equals("EST"))
        {
            if (ESTTERM_STEP_ID == 2)
            {
                string est_emp_id = DataTypeUtility.GetString(e.Row.Cells.FromKey("EST_EMP_ID").Value);
                string tgt_emp_id = DataTypeUtility.GetString(e.Row.Cells.FromKey("TGT_EMP_ID").Value);
                string filter = string.Format("EST_EMP_ID={0} AND TGT_EMP_ID={1}", est_emp_id, tgt_emp_id);
                DataTable dt_q_sbj_point = DataTypeUtility.FilterSortDataTable(DT_QUESTION_SBJ_POINT, filter);

                if (dt_q_sbj_point.Rows.Count > 0)
                {
                    DataTable dt_groupBy_q_dfn = DataTypeUtility.GetGroupByDataTable(dt_q_sbj_point, "POINT", new string[] { "Q_DFN_ID" }, "POINT");

                    if (dt_groupBy_q_dfn.Rows.Count > 0)
                    {
                        double total_sum = 0;
                        for (int i = 0; i < dt_groupBy_q_dfn.Rows.Count; i++)
                        {
                            string q_dfn_id = DataTypeUtility.GetString(dt_groupBy_q_dfn.Rows[i]["Q_DFN_ID"]);
                            double avg_point = DataTypeUtility.GetToDouble(dt_groupBy_q_dfn.Rows[i]["AVG_POINT"]);

                            e.Row.Cells.FromKey(q_dfn_id).Value = Math.Round(avg_point, 1);

                            total_sum += avg_point;
                        }

                        double total_avg = total_sum / dt_groupBy_q_dfn.Rows.Count;

                        e.Row.Cells.FromKey("Q_SBJ_POINT_AVG").Value = Math.Round(total_avg, 1);
                    }
                }
            }
            else if (ESTTERM_STEP_ID == 3)
            {
                if (DT_EST_DATA_1ST == null)
                {
                    int est_emp_id;
                    if (IS_ADMIN)
                        est_emp_id = 0;
                    else
                        est_emp_id = gUserInfo.Emp_Ref_ID;

                    Biz_Datas est_data = new Biz_Datas();
                    DT_EST_DATA_1ST = est_data.GetEstData(COMP_ID
                                                    , EST_ID
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , 2
                                                    , 0
                                                    , est_emp_id
                                                    , 0
                                                    , 0).Tables[0];//1차 평가 데이터
                }

                string tgt_emp_id = DataTypeUtility.GetString(e.Row.Cells.FromKey("TGT_EMP_ID").Value);
                string filter = string.Format("TGT_EMP_ID={0}", tgt_emp_id);
                DataTable dt_filtered_est_data_1st = DataTypeUtility.FilterSortDataTable(DT_EST_DATA_1ST, filter);

                if (dt_filtered_est_data_1st.Rows.Count > 0)
                {
                    string est_dept_id_1st = DataTypeUtility.GetString(dt_filtered_est_data_1st.Rows[0]["EST_DEPT_ID"]);
                    string est_emp_id_1st = DataTypeUtility.GetString(dt_filtered_est_data_1st.Rows[0]["EST_EMP_ID"]);
                    double point_org_1st = DataTypeUtility.GetToDouble(dt_filtered_est_data_1st.Rows[0]["POINT_ORG"]);
                    double point_ctrl_org_1st = DataTypeUtility.GetToDouble(dt_filtered_est_data_1st.Rows[0]["POINT_CTRL_ORG"]);
                    


                    double point_org = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("POINT_ORG").Value);
                    double point_ctrl_org = DataTypeUtility.GetToDouble(e.Row.Cells.FromKey("POINT_CTRL_ORG").Value);
                    double point_balance;

                    if (point_ctrl_org == 0)
                    {
                        point_org = point_ctrl_org_1st;
                        e.Row.Cells.FromKey("POINT_ORG").Value = point_org;

                        point_balance = 0;
                    }
                    else
                        point_balance = point_ctrl_org - point_org;



                    TemplatedColumn tc = (TemplatedColumn)UltraWebGrid1.Columns.FromKey("POINT_BALANCE");
                    Infragistics.WebUI.WebDataInput.WebNumericEdit ne = (Infragistics.WebUI.WebDataInput.WebNumericEdit)((CellItem)tc.CellItems[e.Row.Index]).FindControl("POINT_BALANCE");
                    ne.Value = point_balance;

                    e.Row.Cells.FromKey("EST_DEPT_ID_1ST").Value = est_dept_id_1st;
                    e.Row.Cells.FromKey("EST_EMP_ID_1ST").Value = est_emp_id_1st;
                    e.Row.Cells.FromKey("POINT_ORG_1ST").Value = point_org_1st;
                    e.Row.Cells.FromKey("POINT_CTRL_ORG_1ST").Value = point_ctrl_org_1st;
                }
            }
        }
	}






    protected void iBtnConfirm_SelfEst_Click(object sender, ImageClickEventArgs e)
    {
        if (Confirm_SelfEst())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("처리되었습니다.");
        }
        else
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("실패하였습니다.");
        }

        GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, IS_ADMIN);
    }
    protected bool Confirm_SelfEst()
    {
        int new_status_seq = 3;//자기평가 완료
        int increment_seq = 1;


        
        //데이터 수집
        DataTable dt = new DataTable();

        string[] cols = new string[this.UltraWebGrid1.Columns.Count-1];

        for (int i = 1; i < this.UltraWebGrid1.Columns.Count; i++)
        {
            cols[i-1] = this.UltraWebGrid1.Columns[i].Key;
            dt.Columns.Add(cols[i - 1]);
        }

        dt = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1, "cBox", "selchk", cols, dt);




        //데이터 가공 및 검증
        for (int i = 0; i < dt.Rows.Count; i++)
        { 
            
            string status_id = DataTypeUtility.GetString(dt.Rows[i]["STATUS_ID"]);

            Biz_Est_Data bizEstData = new Biz_Est_Data();
            Biz_Status new_status = bizEstData.Get_New_Est_Status(COMP_ID, EST_ID, status_id, new_status_seq, increment_seq);

            if (new_status.Status_ID != null && new_status.Status_ID.Trim().Length > 0)
            {
                dt.Rows[i]["STATUS_ID"] = new_status.Status_ID;
            }
            else
            {
                this.ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 단계로 진행할 수 없는 데이터가 있습니다.", new_status.Status_Name));
                return false;
            }
        }


        dt = Add_Date_User(dt);

        

        //데이터 저장
        Biz_Datas datas = new Biz_Datas();
        return datas.SaveStatus(dt);
    }





    protected void iBtnCancel_SelfEst_Click(object sender, ImageClickEventArgs e)
    {
        if(Cancel_SelfEst())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("처리되었습니다.");
        }
        else
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("실패하였습니다.");
        }

        GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, IS_ADMIN);
    }
    
    protected bool Cancel_SelfEst()
    {
        //STATUS 정보 가져오기
        int new_status_seq = 2;//자기 평가중
        int increment_seq = -1;



        //데이터 수집
        DataTable dt = Collect_CheckedData();



        //데이터 가공 및 검증
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string status_id = DataTypeUtility.GetString(dt.Rows[i]["STATUS_ID"]);
            
            Biz_Est_Data bizEstData = new Biz_Est_Data();
            Biz_Status new_status = bizEstData.Get_New_Est_Status(COMP_ID, EST_ID, status_id, new_status_seq, increment_seq);

            if (new_status.Status_ID != null && new_status.Status_ID.Trim().Length > 0)
            {
                dt.Rows[i]["STATUS_ID"] = new_status.Status_ID;
            }
            else
            {
                this.ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 단계로 진행할 수 없는 데이터가 있습니다.", new_status.Status_Name));
                return false;
            }
        }


        dt = Add_Date_User(dt);


        //데이터 저장
        Biz_Datas datas = new Biz_Datas();
        return datas.SaveStatus(dt);
    }
    
    
    
    
    
    protected void iBtnConfirm_EstQ_Click(object sender, ImageClickEventArgs e)
    {
        if(Confirm_EstQ())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("처리되었습니다.");
        }
        else
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("실패하였습니다.");
        }

        GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, IS_ADMIN);
    }
    protected bool Confirm_EstQ()
    {
        //STATUS 정보 가져오기
        int new_status_seq = 0;
        if (ESTTERM_STEP_ID == 2)
        {
            //1차 평가 완료
            new_status_seq = 5;
        }
        else if (ESTTERM_STEP_ID == 3)
        {
            //2차 평가 완료
            new_status_seq = 7;
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("잘못된 평가 차수 데이터입니다.");
        }
        int increment_seq = 1;



        //데이터 수집
        DataTable dt = Collect_CheckedData();




        //데이터 가공 및 검증
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string status_id = DataTypeUtility.GetString(dt.Rows[i]["STATUS_ID"]);
            
            Biz_Est_Data bizEstData = new Biz_Est_Data();
            Biz_Status new_status = bizEstData.Get_New_Est_Status(COMP_ID, EST_ID, status_id, new_status_seq, increment_seq);

            if (new_status.Status_ID != null && new_status.Status_ID.Trim().Length > 0)
            {
                dt.Rows[i]["STATUS_ID"] = new_status.Status_ID;
            }
            else
            {
                this.ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 단계로 진행할 수 없는 데이터가 있습니다.", new_status.Status_Name));
                return false;
            }
        }


        dt = Add_Date_User(dt);


        //데이터 저장
        Biz_Datas datas = new Biz_Datas();
        return datas.SaveStatus(dt);
    }
    
    
    
    
    protected void iBtnCancel_EstQ_Click(object sender, ImageClickEventArgs e)
    {
        if(Cancel_EstQ())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("처리되었습니다.");
        }
        else
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("확정 취소할 수 없습니다.");
        }

        GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, IS_ADMIN);
    }
    protected bool Cancel_EstQ()
    {
        
        //STATUS 정보 가져오기
        int new_status_seq = 0;
        if (ESTTERM_STEP_ID == 2)
        {
            //1차 평가 중
            new_status_seq = 4;
        }
        else if (ESTTERM_STEP_ID == 3)
        {
            //2차 평가 중
            new_status_seq = 6;
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("잘못된 평가 차수 데이터입니다.");
        }
        int increment_seq = -1;




        //데이터 수집
        DataTable dt = Collect_CheckedData();




        //데이터 가공 및 검증
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string status_id = DataTypeUtility.GetString(dt.Rows[i]["STATUS_ID"]);

            if (ESTTERM_STEP_ID == 2)//1차 평가 확정 취소이면
            {
                string status_id_2nd = DataTypeUtility.GetString(dt.Rows[i]["STATUS_ID_2ND"]);

                Biz_EstInfos bizEstInfo = new Biz_EstInfos(COMP_ID, EST_ID);
                Biz_Status bizStatus = new Biz_Status(status_id_2nd, DataTypeUtility.GetString(bizEstInfo.Status_Style_ID));

                if (bizStatus.Seq > 1)
                {
                    this.ltrScript.Text = JSHelper.GetAlertScript("2차 평가가 진행중이므로 확정 취소할 수 없습니다.");
                    return false;
                }
            }


            Biz_Est_Data bizEstData = new Biz_Est_Data();
            Biz_Status new_status = bizEstData.Get_New_Est_Status(COMP_ID, EST_ID, status_id, new_status_seq, increment_seq);

            if (new_status.Status_ID != null && new_status.Status_ID.Trim().Length > 0)
            {
                dt.Rows[i]["STATUS_ID"] = new_status.Status_ID;
            }
            else
            {
                this.ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 단계로 진행할 수 없는 데이터가 있습니다.", new_status.Status_Name));
                return false;
            }
        }



        dt = Add_Date_User(dt);



        //데이터 저장
        Biz_Datas datas = new Biz_Datas();
        return datas.SaveStatus(dt);
    }
    protected DataTable Collect_CheckedData()
    {
        DataTable dt = new DataTable();

        string[] cols = new string[this.UltraWebGrid1.Columns.Count - 1];

        for (int i = 1; i < this.UltraWebGrid1.Columns.Count; i++)
        {
            cols[i - 1] = this.UltraWebGrid1.Columns[i].Key;
            dt.Columns.Add(cols[i - 1]);
        }

        dt = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1, "cBox", "selchk", cols, dt);

        return dt;
    }








    protected void iBtnBias_Click(object sender, ImageClickEventArgs e)
    {
        if (setBias())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("적용되었습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("실패하였습니다.");
        }

        GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, IS_ADMIN);
    }
    protected bool setBias()
    {
        string bias_type = PageUtility.GetByValueDropDownList(ddlBIAS_TYPE);
        bool result = false;

        if (bias_type.Equals("ORG"))
        {
            result = setOriginal_Point();
        }
        else if (bias_type.Equals("AVG"))
        {
            result = setAverage_Point();
        }
        else if (bias_type.Equals("STD"))
        {
            result = setSTD_Point();
        }

        return result;
            
    }
    protected bool setOriginal_Point()
    { 
        //데이터 수집
        DataTable dt = getConfirmed_EstData();
        int result = 0;

        if (dt.Rows.Count > 0)
        {
            //데이터 가공
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double point_org = DataTypeUtility.GetToDouble(dt.Rows[i]["POINT_ORG"]);//원점수

                double point_ctrl_org = point_org;//환산점수 계산용 점수
                double point = point_ctrl_org * 100 / 5;//환산점수


                dt.Rows[i]["POINT"] = Math.Round(point, 1);
                dt.Rows[i]["POINT_AVG"] = -1;
                dt.Rows[i]["POINT_STD"] = -1;
                dt.Rows[i]["POINT_CTRL_ORG"] = Math.Round(point_org, 1);

                dt.Rows[i]["STATUS_ID"] = "E";//확정
            }


            dt = Add_Date_User(dt);


            Biz_Est_Data bizEstData = new Biz_Est_Data();
            result = bizEstData.ModifyEstData_Point(dt, gUserInfo.Emp_Ref_ID);
        }

        return result > 0 ? true : false;
    }
    protected bool setAverage_Point()
    {
        //데이터 수집
        DataTable dt = getConfirmed_EstData();
        int result = 0;

        if (dt.Rows.Count > 0)
        {
            Biz_Est_Data bizEstData = new Biz_Est_Data();
            DataTable dt_Bias_ratio = bizEstData.Get_Bias_AVG_Ratio_STD(COMP_ID
                                                                        , EST_ID
                                                                        , ESTTERM_REF_ID
                                                                        , ESTTERM_SUB_ID
                                                                        , ESTTERM_STEP_ID);

            //데이터 가공
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string est_emp_id = DataTypeUtility.GetString(dt.Rows[i]["EST_EMP_ID"]);
                string filter = string.Format("EST_EMP_ID={0}", est_emp_id);
                DataTable dt_filtered_ratio = DataTypeUtility.FilterSortDataTable(dt_Bias_ratio, filter);
                
                if (dt_filtered_ratio.Rows.Count > 0)
                {
                    double avg_ratio = DataTypeUtility.GetToDouble(dt_filtered_ratio.Rows[0]["AVG_RATIO"]);
                    double point_org = DataTypeUtility.GetToDouble(dt.Rows[i]["POINT_ORG"]);
                    double point_avg = point_org * avg_ratio;

                    double point_ctrl_org = point_avg;//환산점수 계산용 점수
                    double point = point_ctrl_org * 100 / 5;//환산점수


                    dt.Rows[i]["POINT"] = Math.Round(point, 1);
                    dt.Rows[i]["POINT_AVG"] = Math.Round(point_avg, 1);
                    dt.Rows[i]["POINT_STD"] = -1;
                    dt.Rows[i]["POINT_CTRL_ORG"] = Math.Round(point_avg, 1);

                    dt.Rows[i]["STATUS_ID"] = "E";//확정
                }
            }


            dt = Add_Date_User(dt);

            result = bizEstData.ModifyEstData_Point(dt, gUserInfo.Emp_Ref_ID);
        }
        
        return result > 0 ? true : false;
    }
    protected bool setSTD_Point()
    {
        //데이터 수집
        DataTable dt = getConfirmed_EstData();
        int result = 0;

        if (dt.Rows.Count > 0)
        {
            Biz_Est_Data bizEstData = new Biz_Est_Data();
            DataTable dt_Bias_ratio = bizEstData.Get_Bias_AVG_Ratio_STD(COMP_ID
                                                                        , EST_ID
                                                                        , ESTTERM_REF_ID
                                                                        , ESTTERM_SUB_ID
                                                                        , ESTTERM_STEP_ID);

            //데이터 가공
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string est_emp_id = DataTypeUtility.GetString(dt.Rows[i]["EST_EMP_ID"]);
                string filter = string.Format("EST_EMP_ID={0}", est_emp_id);
                DataTable dt_filtered_ratio = DataTypeUtility.FilterSortDataTable(dt_Bias_ratio, filter);

                if (dt_filtered_ratio.Rows.Count > 0)
                {
                    double est_emp_avg = DataTypeUtility.GetToDouble(dt_filtered_ratio.Rows[0]["EST_EMP_AVG"]);
                    double est_emp_std = DataTypeUtility.GetToDouble(dt_filtered_ratio.Rows[0]["EST_EMP_STD"]);
                    double total_avg = DataTypeUtility.GetToDouble(dt_filtered_ratio.Rows[0]["TOTAL_AVG"]);
                    double total_std = DataTypeUtility.GetToDouble(dt_filtered_ratio.Rows[0]["TOTAL_STD"]);
                    double point_org = DataTypeUtility.GetToDouble(dt.Rows[i]["POINT_ORG"]);

                    double point_std;
                    if (total_std == 0 || est_emp_std == 0)
                        point_std = total_avg;
                    else
                        point_std = (point_org - est_emp_avg) * total_std / est_emp_std + total_avg;


                    double point_ctrl_org = point_std;//환산점수 계산용 점수
                    double point = point_ctrl_org * 100 / 5;//환산점수

                    dt.Rows[i]["POINT"] = Math.Round(point_std, 1);
                    dt.Rows[i]["POINT_AVG"] = -1;
                    dt.Rows[i]["POINT_STD"] = Math.Round(point_std, 1);
                    dt.Rows[i]["POINT_CTRL_ORG"] = Math.Round(point_ctrl_org, 1);

                    dt.Rows[i]["STATUS_ID"] = "E";//확정
                }
            }


            dt = Add_Date_User(dt);

            result = bizEstData.ModifyEstData_Point(dt, gUserInfo.Emp_Ref_ID);
        }
        
        return result > 0 ? true : false;
    }
    protected DataTable getConfirmed_EstData()
    {
        return DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "STATUS_ID='E'");
    }






    //2차평가 점수 조정
    protected void iBtnSave_EstQ_Click(object sender, ImageClickEventArgs e)
    {
        if (saveEstQ())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("적용되었습니다.");
            GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, IS_ADMIN);
        }
        else
        {
            this.ltrScript.Text += JSHelper.GetAlertScript("실패하였습니다.");
        }
    }
    protected bool saveEstQ()
    {
        Biz_Est_Data bizEstData = new Biz_Est_Data();
        DataTable dt = DT_EST_DATA.Clone();

        int balance_plus_cnt = 0;
        int balance_minus_cnt = 0;

        for (int i = 0; i < UltraWebGrid1.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            DataRow dr_final = dt.NewRow(); 
            

            string comp_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("COMP_ID").Value);
            string est_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("EST_ID").Value);
            string estterm_ref_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value);
            string estterm_sub_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("ESTTERM_SUB_ID").Value);
            string estterm_step_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("ESTTERM_STEP_ID").Value);
            string est_dept_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("EST_DEPT_ID").Value);
            string est_emp_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("EST_EMP_ID").Value);
            string tgt_dept_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("TGT_DEPT_ID").Value);
            string tgt_emp_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("TGT_EMP_ID").Value);
            string status_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("STATUS_ID").Value);
            double point_org = DataTypeUtility.GetToDouble(UltraWebGrid1.Rows[i].Cells.FromKey("POINT_ORG").Value);




            string filter = "COMP_ID='{0}' AND EST_ID='{1}' AND ESTTERM_REF_ID='{2}' AND ESTTERM_SUB_ID='{3}' AND ESTTERM_STEP_ID='{4}' AND EST_DEPT_ID='{5}' AND EST_EMP_ID='{6}' AND TGT_DEPT_ID='{7}' AND TGT_EMP_ID='{8}'";
            filter = string.Format(filter, comp_id, est_id, estterm_ref_id, estterm_sub_id, estterm_step_id, est_dept_id, est_emp_id, tgt_dept_id, tgt_emp_id);
            DataTable dt_tmp = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, filter);
            if (dt_tmp.Rows.Count == 1)
            {
                for (int j = 0; j < dt_tmp.Columns.Count; j++)
                {
                    dr_final[j] = dt_tmp.Rows[0][j];
                }
            }
            else
            {
                this.ltrScript.Text = JSHelper.GetAlertScript("평가데이터에 오류가 있습니다.");
                return false;
            }



            Biz_Status new_status = bizEstData.Get_New_Est_Status(DataTypeUtility.GetToInt32(comp_id), est_id, status_id, 6, 5);
            if (new_status.Status_ID == null && new_status.Status_ID.Trim().Length > 0)
            {
                this.ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0} 단계로 진행할 수 없는 데이터가 있습니다.", new_status.Status_Name));
                return false;
            }


            TemplatedColumn tc = (TemplatedColumn)UltraWebGrid1.Columns.FromKey("POINT_BALANCE");
            Infragistics.WebUI.WebDataInput.WebNumericEdit ne = (Infragistics.WebUI.WebDataInput.WebNumericEdit)((CellItem)tc.CellItems[i]).FindControl("POINT_BALANCE");
            double point_balance = DataTypeUtility.GetToDouble(ne.Value);
            
            if (point_balance > 0)
            {
                balance_plus_cnt++;
            }
            else if (point_balance < 0)
            {
                balance_minus_cnt++;
            }

            double point_ctrl_org = point_org + point_balance;
            double point = point_ctrl_org * 100 / 5;//환산점수


            
            



            dr["COMP_ID"] = comp_id;
            dr["EST_ID"] = est_id;
            dr["ESTTERM_REF_ID"] = estterm_ref_id;
            dr["ESTTERM_SUB_ID"] =estterm_sub_id;
            dr["ESTTERM_STEP_ID"] = estterm_step_id;
            dr["EST_DEPT_ID"] = est_dept_id;
            dr["EST_EMP_ID"] = est_emp_id;
            dr["TGT_DEPT_ID"] = tgt_dept_id;
            dr["TGT_EMP_ID"] = tgt_emp_id;
            dr["POINT"] = point;
            dr["POINT_ORG"] = point_org;
            dr["POINT_AVG"] = -1;
            dr["POINT_STD"] = -1;
            dr["POINT_CTRL_ORG"] = point_ctrl_org;
            dr["STATUS_ID"] = new_status.Status_ID;




            dr_final["COMP_ID"] = comp_id;
            dr_final["EST_ID"] = est_id;
            dr_final["ESTTERM_REF_ID"] = estterm_ref_id;
            dr_final["ESTTERM_SUB_ID"] = estterm_sub_id;
            dr_final["ESTTERM_STEP_ID"] = "1";
            dr_final["EST_DEPT_ID"] = est_dept_id;
            dr_final["EST_EMP_ID"] = est_emp_id;
            dr_final["TGT_DEPT_ID"] = tgt_dept_id;
            dr_final["TGT_EMP_ID"] = tgt_emp_id;
            dr_final["POINT"] = point;
            dr_final["POINT_ORG"] = point_org;
            dr_final["POINT_AVG"] = -1;
            dr_final["POINT_STD"] = -1;
            dr_final["POINT_CTRL_ORG"] = point_ctrl_org;
            dr_final["STATUS_ID"] = new_status.Status_ID;


            dt.Rows.Add(dr);
            dt.Rows.Add(dr_final);
        }

        int balance_limit = DT_EST_DATA.Rows.Count / 10;

        if (balance_plus_cnt > balance_limit || balance_minus_cnt > balance_limit)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("점수조정 가능인원을 초과하였습니다.");
            return false;
        }

        int result = bizEstData.ModifyEstData_Point(dt, gUserInfo.Emp_Ref_ID);

        return result > 0 ? true : false;
    }












    
    protected DataTable Add_Date_User(DataTable dt)
    {
        dt.Columns.Add("DATE");
        dt.Columns.Add("USER");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["DATE"] = System.DateTime.Now;
            dt.Rows[i]["USER"] = gUserInfo.Emp_Ref_ID;
        }

        return dt;
    }
	private void ClearGroupByBoxColumn()
	{
		UltraWebGrid1.DisplayLayout.ViewType = ViewType.Flat;
		UltraWebGrid1.Clear();
		UltraWebGrid1.DisplayLayout.ViewType = ViewType.OutlookGroupBy;
	}
}
