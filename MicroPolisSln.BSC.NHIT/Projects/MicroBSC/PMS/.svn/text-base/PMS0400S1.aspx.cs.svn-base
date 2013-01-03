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
using MicroBSC.Integration.PRJ.Biz;

public partial class PMS_PMS0400S1 : EstPageBase
{
    Biz_Prj_Info bizPrjInfo;
    Biz_Prj_Data bizPrjData;
    int ESTTERM_STEP_ID;
    string EST_ID;
    string DIRECTION_TYPE;
    string STATUS_ID;


    //프로젝트 선택시 피평가자 뿌려주면서 값 저장할 필드
    int PRJ_REF_ID;
    string PRJ_CODE;
    int EST_DEPT_ID;
    int EST_EMP_ID;


    //평가기간에 해당하는 직원들
    private DataTable DT_EMP_LIST
    {
        get
        {
            if (ViewState["DT_EMP_LIST"] == null)
                return null;

            return (DataTable)ViewState["DT_EMP_LIST"];
        }
        set
        {
            ViewState["DT_EMP_LIST"] = value;
        }
    }



    //최종결과
    private DataTable DT_FINAL_POINT
    {
        get
        {
            if (ViewState["DT_FINAL_POINT"] == null)
                return null;

            return (DataTable)ViewState["DT_FINAL_POINT"];
        }
        set
        {
            ViewState["DT_FINAL_POINT"] = value;
        }
    }



    //PRJ_DATA 조회결과
    private DataTable DT_PRJ_DATA
    {
        get
        {
            if (ViewState["DT_PRJ_DATA"] == null)
                return null;

            return (DataTable)ViewState["DT_PRJ_DATA"];
        }
        set
        {
            ViewState["DT_PRJ_DATA"] = value;
        }
    }


    //평가 종료된 프로젝트 목록
    private DataTable DT_ENDED_PRJ
    {
        get
        {
            if (ViewState["DT_ENDED_PRJ"] == null)
                return null;

            return (DataTable)ViewState["DT_ENDED_PRJ"];
        }
        set
        {
            ViewState["DT_ENDED_PRJ"] = value;
        }
    }


    //EST_DATA 조회결과(최종평가 점수 매칭용)
    private DataTable DT_EMP_EST_DATA
    {
        get
        {
            if (ViewState["DT_EMP_EST_DATA"] == null)
                return null;

            return (DataTable)ViewState["DT_EMP_EST_DATA"];
        }
        set
        {
            ViewState["DT_EMP_EST_DATA"] = value;
        }
    }


    //프로젝트 평가 점수
    private string PRJ_POINT
    {
        get
        {
            if (ViewState["PRJ_POINT"] == null)
                return null;

            return (string)ViewState["PRJ_POINT"];
        }
        set
        {
            ViewState["PRJ_POINT"] = value;
        }
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bizPrjInfo = new Biz_Prj_Info();
        bizPrjData = new Biz_Prj_Data();

        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);

            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID,  WebUtility.GetIntByValueDropDownList(ddlCompID), "N");
        }

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        ESTTERM_STEP_ID = 2;

        EST_ID = "3P";//프로젝트 평가
        DIRECTION_TYPE = "DN";//하향식평가
        STATUS_ID = "E";//점수 산정 완료

        ltrScript.Text = "";
    }


    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
    }
    
    
    
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        doBind_project();
    }
    protected void doBind_project()
    {
        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();

        string est_id = "3Q";

        MicroBSC.Integration.PRJ.Biz.Biz_Prj_Data bizPrjData = new Biz_Prj_Data();
        DT_ENDED_PRJ = bizPrjData.Get_Ended_Prj_Est(COMP_ID, est_id, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID);

        this.lblRowCount.Text = DT_ENDED_PRJ.Rows.Count.ToString();

        UltraWebGrid1.DataSource = DT_ENDED_PRJ;
        UltraWebGrid1.DataBind();
    }



    protected void ibnCalcEmpEstPoint_Click(object sender, EventArgs e)
    {
        if (DT_ENDED_PRJ == null)
        {
            string est_id = "3Q";

            MicroBSC.Integration.PRJ.Biz.Biz_Prj_Data bizPrjData = new Biz_Prj_Data();
            DT_ENDED_PRJ = bizPrjData.Get_Ended_Prj_Est(COMP_ID, est_id, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID);
        }

        DT_FINAL_POINT = new DataTable();
        DT_FINAL_POINT.Columns.Add("TGT_DEPT_ID");
        DT_FINAL_POINT.Columns.Add("TGT_EMP_ID");
        DT_FINAL_POINT.Columns.Add("TGT_POS_CLS_ID");
        DT_FINAL_POINT.Columns.Add("TGT_POS_CLS_NAME");
        DT_FINAL_POINT.Columns.Add("TGT_POS_DUT_ID");
        DT_FINAL_POINT.Columns.Add("TGT_POS_DUT_NAME");
        DT_FINAL_POINT.Columns.Add("TGT_POS_GRP_ID");
        DT_FINAL_POINT.Columns.Add("TGT_POS_GRP_NAME");
        DT_FINAL_POINT.Columns.Add("TGT_POS_RNK_ID");
        DT_FINAL_POINT.Columns.Add("TGT_POS_RNK_NAME");
        DT_FINAL_POINT.Columns.Add("TGT_POS_KND_ID");
        DT_FINAL_POINT.Columns.Add("TGT_POS_KND_NAME");
        DT_FINAL_POINT.Columns.Add("POINT_ORG");
        DT_FINAL_POINT.Columns.Add("POINT");
        
        
        Calculate_Emp_Prj_Point();
    }
    protected void Calculate_Emp_Prj_Point()
    {
        string est_id = "3Q";
        

        //해당 기간의 평가종료된 프로젝트 리스트
        string ended_prj_ref_id_list = "";
        for (int i = 0; i < DT_ENDED_PRJ.Rows.Count; i++)
        {
            if (ended_prj_ref_id_list.Length > 0)
                ended_prj_ref_id_list += ", ";
            ended_prj_ref_id_list += DT_ENDED_PRJ.Rows[i]["PRJ_REF_ID"].ToString();
        }
        if (ended_prj_ref_id_list.Length == 0)
            ended_prj_ref_id_list = "''";



        //평가종료된 프로젝트 참여자들의 SI, 비SI 구분
        DT_EMP_LIST = bizPrjData.Get_TgtEmp_Prj_Gubun(null, null
                                                            , COMP_ID
                                                            , est_id
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , 0
                                                            , 0
                                                            , ended_prj_ref_id_list);



        //SI프로젝트만 참여한 직원 목록
        DataTable dtEmp_SI = DataTypeUtility.FilterSortDataTable(DT_EMP_LIST, "NOT_SI_CNT=0");
        //SI프로젝트만 참여한 직원의 근무시간 대기시간 합계
        DataTable dtSum_Work_Suspend_Time_SI = bizPrjData.Get_Sum_Work_Suspend_Time(null, null
                                                                                    , COMP_ID
                                                                                    , est_id
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , ESTTERM_STEP_ID
                                                                                    , DT_ENDED_PRJ
                                                                                    , dtEmp_SI);



        //SI와 비SI프로젝트 모두 참여한 직원 목록
        DataTable dtEmp_SI_SM = DataTypeUtility.FilterSortDataTable(DT_EMP_LIST, "NOT_SI_CNT>0");
        //SI와 비SI 프로젝트에 모두 참여한 직원의 근무시간 대기시간 합계
        DataTable dtSum_Work_Suspend_Time_SI_SM = bizPrjData.Get_Sum_Work_Suspend_Time(null, null
                                                                                    , COMP_ID
                                                                                    , est_id
                                                                                    , ESTTERM_REF_ID
                                                                                    , ESTTERM_SUB_ID
                                                                                    , ESTTERM_STEP_ID
                                                                                    , DT_ENDED_PRJ
                                                                                    , dtEmp_SI_SM);



        //점수 계산 후 저장
        try
        {
            Calc_Emp_Point_SI(dtSum_Work_Suspend_Time_SI, dtEmp_SI, est_id);
            Calc_Emp_Point_SI_SM(dtSum_Work_Suspend_Time_SI_SM, dtEmp_SI_SM, est_id);
            bool result = Save_Final_Point();

            if (result)
            {
                this.ltrScript.Text = JSHelper.GetAlertScript("점수 집계를 완료하였습니다.");
            }
            else
            {
                //this.ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다.");
                this.ltrScript.Text = JSHelper.GetAlertScript("평가가 완료되지 않았습니다.");
            }
        }
        catch(Exception ex)
        {
            //this.ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다.");
            this.ltrScript.Text = JSHelper.GetAlertScript("평가가 완료되지 않았습니다.");
        }

    }
    protected void Calc_Emp_Point_SI(DataTable dtSum_Worktime, DataTable dtEmp, string est_id)
    {
        //평가 종료된 SI프로젝트 점수의 평균
        DataTable dt_ended_prj_si = DataTypeUtility.FilterSortDataTable(DT_ENDED_PRJ, "PRJ_GUBUN IN ('SI')");
        double avg_prj_point_si = bizPrjData.Get_Avg_Prj_Point(null, null
                                                            , COMP_ID
                                                            , est_id
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , dt_ended_prj_si);

        //평가종료된 SI프로젝트에 참여한 직원의 프로젝트 기여도 점수 평균
         double avg_prj_emp_point_si = bizPrjData.Get_Avg_Prj_Emp_Point(null, null
                                                                    , COMP_ID
                                                                    , est_id
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , ESTTERM_STEP_ID
                                                                    , dtEmp);
        
        for (int i = 0; i < dtEmp.Rows.Count; i++)
        {
            //직원 수 만큼 루프


            double final_point = 0.0;

            string dept_ref_id = dtEmp.Rows[i]["DEPT_REF_ID"].ToString();
            string emp_ref_id = dtEmp.Rows[i]["EMP_REF_ID"].ToString();
            
            string filter = string.Format("PRJ_EMP_ID={0}", emp_ref_id);


            DataTable dtEmpPrjData = DataTypeUtility.FilterSortDataTable(dtSum_Worktime, filter);


            object objTmp = dtEmpPrjData.Compute("SUM(WORK_TIME)", null);
            int totalWorkTime = DataTypeUtility.GetToInt32(objTmp);//총 참여시간(프로젝트+대기)

            int pm_flag = DataTypeUtility.FilterSortDataTable(dtEmpPrjData, "ISPM_YN='Y'").Rows.Count;

            for (int j = 0; j < dtEmpPrjData.Rows.Count; j++)
            { 
                //해당 직원의 프로젝트 수 만큼 루프


                int worktime = DataTypeUtility.GetToInt32(dtEmpPrjData.Rows[j]["WORK_TIME"]);
                double prj_point = DataTypeUtility.GetToDouble(dtEmpPrjData.Rows[j]["PRJ_POINT"]);
                double prj_emp_point = DataTypeUtility.GetToDouble(dtEmpPrjData.Rows[j]["PRJ_EMP_POINT"]);
                string ispm_yn = DataTypeUtility.GetString(dtEmpPrjData.Rows[j]["ISPM_YN"]);
                string gubun_code = DataTypeUtility.GetString(dtEmpPrjData.Rows[j]["GUBUN_CODE"]);
                string suspend_type = DataTypeUtility.GetString(dtEmpPrjData.Rows[j]["SUSPEND_TYPE"]);


                if (ispm_yn.Equals("Y"))
                {
                    //프로젝트에서 역할이 PM이었을 경우

                    if (gubun_code.Equals("P"))
                    {
                        final_point += ((double)worktime / (double)totalWorkTime) * prj_point;
                    }
                    else
                    { 
                        //PM으로 지정되면 P만 될 수 있으므로 여기에 올 수 없음
                        //대기시간이 될 수 없음
                    }
                }
                else
                {
                    //프로젝트에서 역할이 팀원이었을 경우

                    if (gubun_code.Equals("P"))
                    {
                        final_point += ((double)worktime / (double)totalWorkTime)
                                        * ((prj_point * 0.5) + (prj_emp_point * 0.5));
                    }
                    else
                    {
                        //대기시간 점수 계산


                        //대기시간 가중치 설정
                        double t_weight = 1.0;
                        if (suspend_type.Equals("050"))
                            t_weight = 0.9;


                        if (pm_flag > 0)
                        { 
                            //한번이라도 PM을 맡았던 경우

                            final_point += ((double)worktime / (double)totalWorkTime) * t_weight
                                            * avg_prj_point_si;
                        }
                        else
                        { 
                            //한번도 PM이 아니었던 직원의 경우

                            final_point += ((double)worktime / (double)totalWorkTime) * t_weight
                                            * ((avg_prj_point_si * 0.5) + (avg_prj_emp_point_si * 0.5));
                        }
                    }
                }
            }

            //final_point 모음
            Union_Final_Point(dtEmp.Rows[i], Math.Round(final_point, 2));
        }
    }
    protected void Calc_Emp_Point_SI_SM(DataTable dtSum_Worktime, DataTable dtEmp, string est_id)
    {
        //평가 종료된 SI와 비SI프로젝트의 평균 점수
        DataTable dt_ended_prj_si_sm = DT_ENDED_PRJ;
        double avg_prj_point_si_sm = bizPrjData.Get_Avg_Prj_Point(null, null
                                                                , COMP_ID
                                                                , est_id
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , ESTTERM_STEP_ID
                                                                , dt_ended_prj_si_sm);

        //평가종료된 SI와 비SI프로젝트에 참여한 직원의 프로젝트 기여도 점수 평균
        double avg_prj_emp_point_si_sm = bizPrjData.Get_Avg_Prj_Emp_Point(null, null
                                                                    , COMP_ID
                                                                    , est_id
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , ESTTERM_STEP_ID
                                                                    , dtEmp);

        for (int i = 0; i < dtEmp.Rows.Count; i++)
        {
            double final_point = 0.0;

            string dept_ref_id = dtEmp.Rows[i]["DEPT_REF_ID"].ToString();
            string emp_ref_id = dtEmp.Rows[i]["EMP_REF_ID"].ToString();
            
            string filter = string.Format("PRJ_EMP_ID={0}", emp_ref_id);
            object objTmp;
            int totalWorkTime;


            DataTable dtEmpPrjData = DataTypeUtility.FilterSortDataTable(dtSum_Worktime, filter);


            objTmp = dtEmpPrjData.Compute("SUM(WORK_TIME)", null);
            totalWorkTime = DataTypeUtility.GetToInt32(objTmp);

            int pm_flag = DataTypeUtility.FilterSortDataTable(dtEmpPrjData, "ISPM_YN='Y'").Rows.Count;

            for (int j = 0; j < dtEmpPrjData.Rows.Count; j++)
            {
                int worktime = DataTypeUtility.GetToInt32(dtEmpPrjData.Rows[j]["WORK_TIME"]);
                double prj_point = DataTypeUtility.GetToDouble(dtEmpPrjData.Rows[j]["PRJ_POINT"]);
                double prj_emp_point = DataTypeUtility.GetToDouble(dtEmpPrjData.Rows[j]["PRJ_EMP_POINT"]);
                string ispm_yn = DataTypeUtility.GetString(dtEmpPrjData.Rows[j]["ISPM_YN"]);
                string gubun_code = DataTypeUtility.GetString(dtEmpPrjData.Rows[j]["GUBUN_CODE"]);
                string suspend_type = DataTypeUtility.GetString(dtEmpPrjData.Rows[j]["SUSPEND_TYPE"]);


                if (ispm_yn.Equals("Y"))
                {
                    //프로젝트에서 역할이 PM이었을 경우

                    if (gubun_code.Equals("P"))
                    {
                        final_point += ((double)worktime / (double)totalWorkTime) * prj_point;
                    }
                    else
                    {
                        //PM으로 지정되면 P만 될 수 있으므로 여기에 올 수 없음
                        //대기시간이 될 수 없음
                    }
                }
                else
                {
                    //프로젝트에서 역할이 팀원이었을 경우

                    if (gubun_code.Equals("P"))
                    {
                        final_point += ((double)worktime / (double)totalWorkTime)
                                        * ((prj_point * 0.5) + (prj_emp_point * 0.5));
                    }
                    else
                    {
                        //대기시간 점수 계산


                        //대기시간 가중치 설정
                        double t_weight = 1.0;
                        if (suspend_type.Equals("050"))
                            t_weight = 0.9;


                        if (pm_flag > 0)
                        {
                            //한번이라도 PM을 맡았던 경우

                            final_point += ((double)worktime / (double)totalWorkTime) * t_weight
                                            * avg_prj_point_si_sm;
                        }
                        else
                        {
                            //한번도 PM이 아니었던 직원의 경우

                            final_point += ((double)worktime / (double)totalWorkTime) * t_weight
                                            * ((avg_prj_point_si_sm * 0.5) + (avg_prj_emp_point_si_sm * 0.5));
                        }
                    }
                }
            }

            //final_point 모음
            Union_Final_Point(dtEmp.Rows[i], Math.Round(final_point, 2));
        }
    }
    protected void Union_Final_Point(DataRow tgt_emp_info_row, double point)
    {
        DataRow row = DT_FINAL_POINT.NewRow();
        row["TGT_DEPT_ID"]      = tgt_emp_info_row["TGT_DEPT_ID"];
        row["TGT_EMP_ID"]       = tgt_emp_info_row["TGT_EMP_ID"];
        row["TGT_POS_CLS_ID"]   = tgt_emp_info_row["TGT_POS_CLS_ID"];
        row["TGT_POS_CLS_NAME"] = tgt_emp_info_row["TGT_POS_CLS_NAME"];
        row["TGT_POS_DUT_ID"]   = tgt_emp_info_row["TGT_POS_DUT_ID"];
        row["TGT_POS_DUT_NAME"] = tgt_emp_info_row["TGT_POS_DUT_NAME"];
        row["TGT_POS_GRP_ID"]   = tgt_emp_info_row["TGT_POS_GRP_ID"];
        row["TGT_POS_GRP_NAME"] = tgt_emp_info_row["TGT_POS_GRP_NAME"];
        row["TGT_POS_RNK_ID"]   = tgt_emp_info_row["TGT_POS_RNK_ID"];
        row["TGT_POS_RNK_NAME"] = tgt_emp_info_row["TGT_POS_RNK_NAME"];
        row["TGT_POS_KND_ID"]   = tgt_emp_info_row["TGT_POS_KND_ID"];
        row["TGT_POS_KND_NAME"] = tgt_emp_info_row["TGT_POS_KND_NAME"];
        row["POINT_ORG"]        = point;
        row["POINT"]            = point;

        DT_FINAL_POINT.Rows.Add(row);
    }
    protected bool Save_Final_Point()
    {
        int est_dept_id = 1;
        int est_emp_id = 1000;
        string direction_type = "DN";
        string status_id = "E";
        string now_date = System.DateTime.Now.ToString("yyyy_MM-dd");
        int create_user_ref_id = gUserInfo.Emp_Ref_ID;

        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstdata = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
        return bizEstdata.AddData(DT_EMP_LIST            
                                , DT_FINAL_POINT            
                                , COMP_ID            
                                , EST_ID            
                                , ESTTERM_REF_ID            
                                , ESTTERM_SUB_ID            
                                , ESTTERM_STEP_ID            
                                , est_dept_id            
                                , est_emp_id            
                                , direction_type            
                                , status_id            
                                , System.DateTime.Now
                                , System.DateTime.Now
                                , System.DateTime.Now
                                , System.DateTime.Now            
                                , create_user_ref_id);
    }



    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {

    }



    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        UltraGridRow row = (UltraGridRow)(e.SelectedRows[0]);
        
        PRJ_REF_ID = DataTypeUtility.GetToInt32(row.Cells.FromKey("PRJ_REF_ID").Value);
        PRJ_CODE = DataTypeUtility.GetString(row.Cells.FromKey("PRJ_CODE").Value);
        EST_DEPT_ID = DataTypeUtility.GetToInt32(row.Cells.FromKey("EST_DEPT_ID").Value);
        EST_EMP_ID = DataTypeUtility.GetToInt32(row.Cells.FromKey("EST_EMP_ID").Value);

        doBind_prjEmp();
    }
    protected void doBind_prjEmp()
    {
        UltraWebGrid2.Clear();
        
        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();
        DT_EMP_EST_DATA = bizEstData.GetEstData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID, DIRECTION_TYPE, EST_EMP_ID, 0);



        MicroBSC.Integration.PRJ.Biz.Biz_Prj_Data bizPrjData = new Biz_Prj_Data();
        string est_id = "3Q";//프로젝트 기여도 평가 EST_ID

        DT_PRJ_DATA = bizPrjData.Get_Prj_Data_List(PRJ_REF_ID
                                                    , COMP_ID
                                                    , est_id
                                                    , ESTTERM_REF_ID
                                                    , ESTTERM_SUB_ID
                                                    , ESTTERM_STEP_ID);


        DataTable dtPrj_PM_Data = DataTypeUtility.FilterSortDataTable(DT_PRJ_DATA, "TGT_DEPT_ID=-1 AND TGT_EMP_ID=-1");
        object point = dtPrj_PM_Data.Rows[0]["POINT"];
        PRJ_POINT = DataTypeUtility.GetString(point);


        UltraWebGrid2.DataSource = DT_PRJ_DATA;
        UltraWebGrid2.DataBind();
    }



    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        //프로젝트 평가점수 바인딩
        e.Row.Cells.FromKey("PRJ_POINT").Value = PRJ_POINT;
        

        //개인종합평가 평가점수 바인딩
        string tgt_dept_id = e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString();
        string tgt_emp_id = e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString();
        string filter = string.Format("TGT_DEPT_ID={0} AND TGT_EMP_ID={1}", tgt_dept_id, tgt_emp_id);

        DataTable empEstInfo = DataTypeUtility.FilterSortDataTable(DT_EMP_EST_DATA, filter);
        string point = "";
        if (empEstInfo.Rows.Count > 0)
            point = DataTypeUtility.GetString(empEstInfo.Rows[0]["POINT"]);

        if (point.Trim().Length == 0)
            point = "-";

        e.Row.Cells.FromKey("EST_POINT").Value = point;


        //PM일 경우 처리
        if (tgt_dept_id.Equals("-1") && tgt_emp_id.Equals("-1"))
        {
            e.Row.Cells.FromKey("POINT").Value = "-";
            e.Row.Cells.FromKey("TGT_DEPT_NAME").Value = DT_PRJ_DATA.Rows[0]["EST_DEPT_NAME"];
            e.Row.Cells.FromKey("TGT_EMP_NAME").Value = DT_PRJ_DATA.Rows[0]["EST_EMP_NAME"];
        }

    }



    protected void ibnConfirm_Click(object sender, EventArgs e)
    {

    }



    protected void ibnTotalView_Click_Click(object sender, EventArgs e)
    {

    }



    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        //uGridExcelExporter.DownloadName = "PMS." + DateTime.Now.ToString("yyMMddHHmmss");
        //uGridExcelExporter.WorksheetName = "PMS_DATA";

        //uGridExcelExporter.Export(UltraWebGrid2);
    }
}

