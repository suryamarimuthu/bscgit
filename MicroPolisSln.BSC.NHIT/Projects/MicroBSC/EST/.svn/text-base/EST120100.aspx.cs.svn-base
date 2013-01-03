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

public partial class EST_EST120100 : EstPageBase
{
    public bool IS_ADMIN;

    public int[] DEPT_TYPE_REF_ID;


    public string EST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
            {
                return null;
            }

            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }


    public string POS_ID
    {
        get
        {
            if (ViewState["POS_ID"] == null)
            {
                return null;
            }

            return (string)ViewState["POS_ID"];
        }
        set
        {
            ViewState["POS_ID"] = value;
        }
    }

    public string DEPT_TYPE_REF_ID_LIST
    {
        get
        {
            if (ViewState["DEPT_TYPE_REF_ID_LIST"] == null)
            {
                return null;
            }

            return (string)ViewState["DEPT_TYPE_REF_ID_LIST"];
        }
        set
        {
            ViewState["DEPT_TYPE_REF_ID_LIST"] = value;
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


    public DataTable DT_EST_POS_WEIGHT
    {
        get
        {
            if (ViewState["DT_EST_POS_WEIGHT"] == null)
            {
                return null;
            }

            return (DataTable)ViewState["DT_EST_POS_WEIGHT"];
        }
        set
        {
            ViewState["DT_EST_POS_WEIGHT"] = value;
        }
    }


    public int PAGE_CNT
    {
        get
        {
            if (ViewState["PAGE_CNT"] == null)
            {
                return 0;
            }

            return (int)ViewState["PAGE_CNT"];
        }
        set
        {
            ViewState["PAGE_CNT"] = value;
        }
    }


    public int CURRENT_PAGE
    {
        get
        {
            if (ViewState["CURRENT_PAGE"] == null)
            {
                return 1;
            }

            return (int)ViewState["CURRENT_PAGE"];
        }
        set
        {
            ViewState["CURRENT_PAGE"] = value;
        }
    }

	protected void Page_Init(object sender, EventArgs e)
	{
		SetPageLayout(phdLayout, phdBottom);
	}

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";

        /*
         * 
         * 부서 타입 설정 갯수에 따라 유동적으로 동작하도록 하려 하였으나....일단 팀과 본부로 고정
         * 
         */


        EST_ID = "3A";//조직KPI 평가


        //쿼리스트링으로 받은 부서타입을 배열로 변환
        DEPT_TYPE_REF_ID_LIST = "4, 7";
        DEPT_TYPE_REF_ID_LIST = DEPT_TYPE_REF_ID_LIST.Replace(" ", "");
        string[] tmp = DEPT_TYPE_REF_ID_LIST.Split(',');
        DEPT_TYPE_REF_ID = new int[tmp.Length];
        for (int i = 0; i < tmp.Length; i++)
        {
            if (tmp[i].Trim().Length > 0)
            {
                DEPT_TYPE_REF_ID[i] = DataTypeUtility.GetToInt32(tmp[i]);
            }
            else
            { 
                //비정상 데이터
                this.ltrScript.Text = JSHelper.GetAlertScript("비정상 부서타입이 존재합니다.");
                return;
            }
        }




        IS_ADMIN = false;
        checkAdmin();



        UltraWebGrid1.DisplayLayout.Pager.CurrentPageIndex = CURRENT_PAGE;
        UltraWebGrid1.DisplayLayout.Pager.PageCount = PAGE_CNT;




        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID, COMP_ID, "N");
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

            ESTTERM_STEP_ID = 1;

            GridBidingData(COMP_ID
                            , EST_ID
                            , ESTTERM_REF_ID
                            , ESTTERM_SUB_ID
                            , ESTTERM_STEP_ID);
        }
        else
        {
            COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
            ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
            ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
        }

        HtmlScriptCommon.CreateStatusHtmlTable(tblViewStatus, EST_ID);// 상태 html

    }

    protected void checkAdmin()
    {
        MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Role_Rel bizComEmpRoleRel = new MicroBSC.Integration.COM.Biz.Biz_Com_Emp_Role_Rel();
        int isAdmin = 0;
        isAdmin += bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, 1) ? 1 : 0;//시스템 관리자
        isAdmin += bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, 9) ? 1 : 0;//성과평가 관리자

        IS_ADMIN = isAdmin > 0 ? true : false;
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
					 , ESTTERM_STEP_ID);
	}
    private void GridBidingData(int comp_id
                                , string est_id
                                , int estterm_ref_id
                                , int estterm_sub_id
                                , int estterm_step_id)
    {
        // 평가정보를 가져온다.
        Biz_EstInfos estInfo = new Biz_EstInfos(comp_id, est_id);

        // 해당평가가 존재하는지 여부 체크
        if (!estInfo.IsExists(comp_id, est_id))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 회사의 평가정보가 없습니다.");
            return;
        }





        Biz_Est_Data bizEstData = new Biz_Est_Data();
        if (DT_EST_DATA == null)
        {
            DT_EST_DATA = bizEstData.Get_Est_Data_Pos_Weight(comp_id
                                                            , est_id
                                                            , estterm_ref_id
                                                            , estterm_sub_id
                                                            , estterm_step_id);
        }



        DT_EST_DATA = DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "TGT_DEPT_ID=10");//경영혁신팀만 조회
        if (DataTypeUtility.FilterSortDataTable(DT_EST_DATA, "DEPT_POINT IS NULL").Rows.Count > 0)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("점수가 입력되지 않은 부서가 존재합니다.");
            iBtnApplyWeight.Visible = false;
        }






        Biz_Est_Pos_Weight bizEstPosWeight = new Biz_Est_Pos_Weight();
        DataTable dt = bizEstPosWeight.Get_Est_Pos_Weight(comp_id
                                                            , estterm_ref_id
                                                            , est_id
                                                            , 0
                                                            , ""
                                                            , ""
                                                            , 0);

        if (dt.Rows.Count > 0)
        {
            dt = DataTypeUtility.GetGroupByDataTable(dt, new string[] { "POS_ID" });
            POS_ID = DataTypeUtility.GetString(dt.Rows[0]["POS_ID"]);

            Biz_PositionInfos bizPosInfo = new Biz_PositionInfos(POS_ID);
            if (bizPosInfo.Position_Table_Name != null && bizPosInfo.Position_Table_Name.Trim().Length > 0)
            {
                DT_EST_POS_WEIGHT = bizEstPosWeight.Get_Est_Pos_Weight(POS_ID
                                                                        , bizPosInfo.Position_Table_Name
                                                                        , DEPT_TYPE_REF_ID_LIST
                                                                        , comp_id
                                                                        , estterm_ref_id
                                                                        , est_id);



                int current_page = UltraWebGrid1.DisplayLayout.Pager.CurrentPageIndex;
                int page_size = UltraWebGrid1.DisplayLayout.Pager.PageSize;
                double page_cnt = Math.Ceiling((double)DT_EST_DATA.Rows.Count / page_size);


                CURRENT_PAGE = current_page;
                PAGE_CNT = DataTypeUtility.GetToInt32(page_cnt);


                DataTable dt_est_data = DT_EST_DATA.Copy();
                for (int i = 0; i < (current_page - 1) * page_size; i++)
                {
                    dt_est_data.Rows.RemoveAt(0);
                }


                UltraWebGrid1.Clear();
                UltraWebGrid1.DataSource = dt_est_data;
                UltraWebGrid1.DataBind();


                lblRowCount.Text = DT_EST_DATA.Rows.Count.ToString("#,##0");
            }
        }
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
	{
        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginY = 1;
        }


        ColumnHeader ch;

        //헤더 스팬X
        ch = new ColumnHeader();
        ch.Caption = "피 평가부서 점수";
        ch.RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns.FromKey("UP_DEPT_NAME").Index;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.SpanX = 4;

        e.Layout.Bands[0].HeaderLayout.Add(ch);



        //헤더 스팬X
        ch = new ColumnHeader();
        ch.Caption = "가중치(%)";
        ch.RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns.FromKey("UP_DEPT_WEIGHT").Index - 1;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;

        e.Layout.Bands[0].HeaderLayout.Add(ch);



        //헤더 스팬Y
        int up_dept_name_col_pos = e.Layout.Bands[0].Columns.FromKey("UP_DEPT_NAME").Index;
        for (int i = 0; i < up_dept_name_col_pos; i++)
        {
            e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.OriginY = 0;
            e.Layout.Bands[0].Columns[i].Header.RowLayoutColumnInfo.SpanY = 2;
        }
        
        e.Layout.Bands[0].Columns.FromKey("POINT").Header.RowLayoutColumnInfo.OriginY = 0;
        e.Layout.Bands[0].Columns.FromKey("POINT").Header.RowLayoutColumnInfo.SpanY = 2;
	}
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
	{
        Biz_PositionInfos bizPosInfo = new Biz_PositionInfos(POS_ID);


        string up_dept_point = DataTypeUtility.GetString(e.Row.Cells.FromKey("UP_DEPT_POINT").Value);
        if (up_dept_point.Trim().Length == 0)
            up_dept_point = "-";
        string dept_point = DataTypeUtility.GetString(e.Row.Cells.FromKey("DEPT_POINT").Value);
        if (dept_point.Trim().Length == 0)
            dept_point = "-";
        string point = DataTypeUtility.GetString(e.Row.Cells.FromKey("POINT").Value);
        if (point.Trim().Length == 0)
            point = "-";


        e.Row.Cells.FromKey("UP_DEPT_POINT").Value = up_dept_point;
        e.Row.Cells.FromKey("DEPT_POINT").Value = dept_point;
        e.Row.Cells.FromKey("POINT").Value = point;



        if (e.Row.Cells.Exists(string.Format("TGT_POS_{0}_ID", POS_ID)))
        {
            string pos_value = DataTypeUtility.GetString(e.Row.Cells.FromKey(string.Format("TGT_POS_{0}_ID", POS_ID)).Value);
            
            int up_dept_type = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("UP_DEPT_TYPE").Value);
            int dept_type = DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("DEPT_TYPE").Value);


            double up_dept_weight = 0;
            double dept_weight = 0;


            DataTable dt = null;
            string filter_src = "POS_ID='{0}' AND POS_VALUE='{1}' AND DEPT_TYPE_REF_ID='{2}'";


            string dept_name = DataTypeUtility.GetString(e.Row.Cells.FromKey("TGT_DEPT_NAME").Value);


            if (dept_type == 7)
            {
                if (up_dept_type == 4)
                {
                    dt = DataTypeUtility.FilterSortDataTable(DT_EST_POS_WEIGHT, string.Format(filter_src, POS_ID, pos_value, up_dept_type));
                    if (dt.Rows.Count > 0)
                    {
                        up_dept_weight = DataTypeUtility.GetToDouble(dt.Rows[0]["WEIGHT"]);
                    }


                    dt = DataTypeUtility.FilterSortDataTable(DT_EST_POS_WEIGHT, string.Format(filter_src, POS_ID, pos_value, dept_type));
                    if (dt.Rows.Count > 0)
                    {
                        dept_weight = DataTypeUtility.GetToDouble(dt.Rows[0]["WEIGHT"]);
                    }
                }
                else
                {
                    dept_weight = 100;

                    //e.Row.Cells.FromKey("UP_DEPT_NAME").Value = "";
                    //e.Row.Cells.FromKey("UP_DEPT_POINT").Value = "";
                }
            }
            else if (dept_type == 4)
            {
                dept_weight = 100;

                //e.Row.Cells.FromKey("UP_DEPT_NAME").Value = dept_name;
                //e.Row.Cells.FromKey("UP_DEPT_POINT").Value = point;

                //e.Row.Cells.FromKey("TGT_DEPT_NAME").Style.ForeColor = Color.Transparent;
                //e.Row.Cells.FromKey("POINT").Style.ForeColor = Color.Transparent;
            }


            e.Row.Cells.FromKey("UP_DEPT_WEIGHT").Value = up_dept_weight;
            e.Row.Cells.FromKey("DEPT_WEIGHT").Value = dept_weight;
        }
	}






    

    protected void iBtnApplyWeight_Click(object sender, ImageClickEventArgs e)
    {
        if (ApplyWeight())
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("적용되었습니다.");
            GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID);
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("실패하였습니다.");
        }
    }
    protected bool ApplyWeight()
    {
        Biz_Datas bizData = new Biz_Datas();
        DataTable dt = bizData.GetDataTableSchema();
        DataTable dt_pos_weight = null;

        for (int i = 0; i < DT_EST_DATA.Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();

            //컬럼 값 초기화
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dr[j] = DBNull.Value;
            }



            for (int j = 0; j < DT_EST_DATA.Columns.Count; j++)
            {
                string key = DT_EST_DATA.Columns[j].ColumnName;

                if (dt.Columns.Contains(DT_EST_DATA.Columns[j].ColumnName))
                {
                    dr[key] = DT_EST_DATA.Rows[i][key];
                }
            }

            //string comp_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("COMP_ID").Value);
            //string est_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("EST_ID").Value);
            //string estterm_ref_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value);
            //string estterm_sub_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("ESTTERM_SUB_ID").Value);
            //string estterm_step_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("ESTTERM_STEP_ID").Value);
            //string est_dept_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("EST_DEPT_ID").Value);
            //string est_emp_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("EST_EMP_ID").Value);
            //string tgt_dept_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("TGT_DEPT_ID").Value);
            //string tgt_emp_id = DataTypeUtility.GetString(UltraWebGrid1.Rows[i].Cells.FromKey("TGT_EMP_ID").Value);

            //double point_org = DataTypeUtility.GetToDouble(UltraWebGrid1.Rows[i].Cells.FromKey("POINT_CTRL_ORG_1ST").Value);

            int up_dept_type = DataTypeUtility.GetToInt32(DT_EST_DATA.Rows[i]["UP_DEPT_TYPE"]);
            int dept_type = DataTypeUtility.GetToInt32(DT_EST_DATA.Rows[i]["DEPT_TYPE"]);


            string filter_src = "POS_ID='{0}' AND POS_VALUE='{1}' AND DEPT_TYPE_REF_ID='{2}'";
            string pos_value = DataTypeUtility.GetString(DT_EST_DATA.Rows[i][string.Format("TGT_POS_{0}_ID", POS_ID)]);
            

            //상위부서 가중치
            dt_pos_weight = DataTypeUtility.FilterSortDataTable(DT_EST_POS_WEIGHT, string.Format(filter_src, POS_ID, pos_value, dept_type));
            double up_dept_weight = 0;
            if (dt_pos_weight.Rows.Count > 0)
            {
                up_dept_weight = DataTypeUtility.GetToDouble(dt_pos_weight.Rows[0]["WEIGHT"]);
            }



            //부서 가중치
            dt_pos_weight = DataTypeUtility.FilterSortDataTable(DT_EST_POS_WEIGHT, string.Format(filter_src, POS_ID, pos_value, dept_type));
            double dept_weight = 0;
            if (dt_pos_weight.Rows.Count > 0)
            {
                up_dept_weight = DataTypeUtility.GetToDouble(dt_pos_weight.Rows[0]["WEIGHT"]);
            }




            double up_dept_point = DataTypeUtility.GetToDouble(DT_EST_DATA.Rows[i]["UP_DEPT_POINT"]);
            double dept_point = DataTypeUtility.GetToDouble(DT_EST_DATA.Rows[i]["DEPT_POINT"]);

            double point_org = 0;

            if(dept_type==7 && up_dept_type==4)
            {
                point_org = (up_dept_point * up_dept_weight / 100) + (dept_point * dept_weight / 100);
            }
            else if(dept_type==4)
            {
                point_org = dept_point;
            }


            double point_ctrl_org = point_org;
            double point = point_ctrl_org;

            string status_id = "E";

            dr["POINT_ORG"] = point_org;
            dr["POINT_ORG_DATE"] = System.DateTime.Now;
            dr["POINT_CTRL_ORG"] = point_ctrl_org;
            dr["POINT_CTRL_ORG_DATE"] = System.DateTime.Now;
            dr["POINT"] = point;
            dr["POINT_DATE"] = System.DateTime.Now;
            dr["STATUS_ID"] = status_id;
            dr["STATUS_DATE"] = System.DateTime.Now;
            dr["DATE"] = System.DateTime.Now;
            dr["USER"] = EMP_REF_ID;

            dt.Rows.Add(dr);
        }

        return bizData.SaveData(dt);
    }







    protected void UltraWebGrid1_PageIndexChanged(object sender, PageEventArgs e)
    {
        CURRENT_PAGE = e.NewPageIndex;
        GridBidingData(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, ESTTERM_STEP_ID);
    }




    protected void iBtnSetWeight_Click(object sender, ImageClickEventArgs e)
    { 

    }




    protected DataTable Collect_Data()
    {
        //데이터 수집
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
}
