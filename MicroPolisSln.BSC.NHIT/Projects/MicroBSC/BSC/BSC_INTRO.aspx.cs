using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;
using MicroCharts;
using MicroBSC.Estimation.Dac;
using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Integration.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;
//using Dundas.Gauges.WebControl;
//using Dundas.Charting.WebControl;

using System.Web.UI.DataVisualization.Charting;

public partial class BSC_INTRO : AppPageBase
{

    public double dTotalPoint = 0;
    

    #region --> Property

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IEstDeptID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public int IDeptID
    {
        get
        {
            if (ViewState["COM_DEPT_REF_ID"] == null)
            {
                ViewState["COM_DEPT_REF_ID"] = GetRequestByInt("COM_DEPT_REF_ID", 0);
            }

            return (int)ViewState["COM_DEPT_REF_ID"];
        }
        set
        {
            ViewState["COM_DEPT_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string ISumType
    {
        get
        {
            if (ViewState["SUM_TYPE"] == null)
            {
                ViewState["SUM_TYPE"] = GetRequest("SUM_TYPE", "");
            }

            return (string)ViewState["SUM_TYPE"];
        }
        set
        {
            ViewState["SUM_TYPE"] = value;
        }
    }

    public string IBonID
    {
        get
        {
            if (ViewState["BONBU_ID"] == null)
            {
                ViewState["BONBU_ID"] = GetRequest("BONBU_ID", "");
            }

            return (string)ViewState["BONBU_ID"];
        }
        set
        {
            ViewState["BONBU_ID"] = value;
        }
    }

    public string IBonNAME
    {
        get
        {
            if (ViewState["BONBU_NAME"] == null)
            {
                ViewState["BONBU_NAME"] = GetRequest("BONBU_NAME", "");
            }

            return (string)ViewState["BONBU_NAME"];
        }
        set
        {
            ViewState["BONBU_NAME"] = value;
        }
    }


    public string ITeamID
    {
        get
        {
            if (ViewState["TEAM_ID"] == null)
            {
                ViewState["TEAM_ID"] = GetRequest("TEAM_ID", "");
            }

            return (string)ViewState["TEAM_ID"];
        }
        set
        {
            ViewState["TEAM_ID"] = value;
        }
    }

    public string ITeamNAME
    {
        get
        {
            if (ViewState["TEAM_NAME"] == null)
            {
                ViewState["TEAM_NAME"] = GetRequest("TEAM_NAME", "");
            }

            return (string)ViewState["TEAM_NAME"];
        }
        set
        {
            ViewState["TEAM_NAME"] = value;
        }
    }

    public string KPI_URL
    {
        get
        {
            if (ViewState["KPI_URL"] == null)
            {
                ViewState["KPI_URL"] = "";
            }

            return (string)ViewState["KPI_URL"];
        }
        set
        {
            ViewState["KPI_URL"] = value;
        }
    }

    #endregion

    #region --> Page_Load()

    protected void Page_Load(object sender, EventArgs e)
    {
        writeLog(string.Format("{0} : Page_Load START", Request.PhysicalPath));

        //좌측메뉴설정
        //base.SetMenuControl(true, true, true);

        // 웹 취약성 검사 때문에 처리
        if (IYmd.Equals("-0")
            || ISumType.Equals("-0")
            || IBonID.Equals("-0")
            || IBonNAME.Equals("-0")
            || ITeamID.Equals("-0")
            || ITeamNAME.Equals("-0")
            || KPI_URL.Equals("-0"))
        {
            FormsAuthentication.SignOut();
            string login_page_url = WebUtility.GetConfig("Login_Page_Url", "~/base/Login.aspx");
            Response.Redirect(login_page_url);
        }

        if (!IsPostBack) 
        {

            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            IEstTermRefID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);

            MicroBSC.Integration.BSC.Biz.Biz_My_Kpi bizMyKpi = new MicroBSC.Integration.BSC.Biz.Biz_My_Kpi();
            IYmd = bizMyKpi.SelectCurrentYYYYMM();


            SetSCHDGrid("조직성과평가");
            btn1.ImageUrl = "../images/Intro/mywork1_on.png";
            btn2.ImageUrl = "../images/Intro/mywork2_off.png";
            btn3.ImageUrl = "../images/Intro/mywork3_off.png";
            btn4.ImageUrl = "../images/Intro/mywork4_off.png";

            SetMyKPIGrid();
            SetNoticeGrid();
            SetFAQGrid();
            DisplayScore();

        }
        else
        {
        }



        writeLog(string.Format("{0} : Page_Load END", Request.PhysicalPath));
    }

    private void NotPostBackSetting()
    {

        //WebCommon.SetSumTypeDropDownList(ddlSumType, false);

        //DeptInfos objDept = new DeptInfos();

        //if (Request["EST_DEPT_REF_ID"] == null)
        //{
        //    objDept = new DeptInfos();
        //    this.IEstDeptID = objDept.GetRootEstDeptID(WebUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        //}
        //else
        //{
        //    this.IEstDeptID = WebUtility.GetRequestByInt("EST_DEPT_REF_ID");
        //}



        //this.Search(this.IEstDeptID);
    }

    #endregion

    #region --> Event

    
    protected void ugrdSCHD_InitializeLayout(object sender, LayoutEventArgs e)
    {

        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = null;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Reset();
        //ch.Caption = "목표";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 5;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        ////ch.RowLayoutColumnInfo.SpanY = 3;
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Reset();
        //ch.Caption = "달성율(%)";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 8;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

    }
    protected void ugrdMyKpiList_InitializeLayout(object sender, LayoutEventArgs e)
    {

        //Infragistics.WebUI.UltraWebGrid.ColumnHeader ch = null;

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Reset();
        //ch.Caption = "목표";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 5;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        ////ch.RowLayoutColumnInfo.SpanY = 3;
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

        //ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        //ch.Reset();
        //ch.Caption = "달성율(%)";
        //ch.RowLayoutColumnInfo.OriginY = 0;
        //ch.RowLayoutColumnInfo.OriginX = 8;
        //ch.RowLayoutColumnInfo.SpanX = 2;
        //ch.Style.HorizontalAlign = HorizontalAlign.Center;
        //e.Layout.Bands[0].HeaderLayout.Add(ch);

    }

    protected void ugrdSCHD_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        string schd_mid = DataTypeUtility.GetValue(e.Row.Cells.FromKey("schd_mid").Value);
        string link_dir = DataTypeUtility.GetValue(e.Row.Cells.FromKey("link_dir").Value);
        string link_page_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("link_page_name").Value);

        string url = "<a href='{0}{1}'>{2}</a>";
        string link = string.Format(url, link_dir, link_page_name, schd_mid);

        e.Row.Cells.FromKey("schd_mid").Text = link;
    }

    protected void ugrdMyKpiList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
 
        string strKPI_NAME = e.Row.Cells.FromKey("KPI_NAME").Value.ToString();
        string imageUrl = "<img border='0' src='../images/Intro/icon_k.gif'>";
        string strText = imageUrl + strKPI_NAME;

        e.Row.Cells.FromKey("KPI_NAME").Text = strText;


       string strTrend = e.Row.Cells.FromKey("TO_IMAGE").Value.ToString();

        switch (strTrend)
        {
            case "icon_A.gif":
                e.Row.Cells.FromKey("TO_IMAGE").Value = "<img border='0' src='../images/Intro/score_bar_A.gif'>";
                break;
            case "icon_B.gif":
                e.Row.Cells.FromKey("TO_IMAGE").Value = "<img border='0' src='../images/Intro/score_bar_B.gif'>";
                break;
            case "icon_C.gif":
                e.Row.Cells.FromKey("TO_IMAGE").Value = "<img border='0' src='../images/Intro/score_bar_C.gif'>";
                break;
            case "icon_D.gif":
                e.Row.Cells.FromKey("TO_IMAGE").Value = "<img border='0' src='../images/Intro/score_bar_D.gif'>";
                break;
            case "icon_S.gif":
                e.Row.Cells.FromKey("TO_IMAGE").Value = "<img border='0' src='../images/Intro/score_bar_S.gif'>";
                break;
            case "icon_U.gif":
                e.Row.Cells.FromKey("TO_IMAGE").Value = "<img border='0' src='../images/Intro/score_bar_U.gif'>";
                break;
            default:
                break;
        }

    }


    protected void iBtn1_Click(object sender, ImageClickEventArgs e)
    {
        SetSCHDGrid("조직성과평가");

        btn1.ImageUrl = "../images/Intro/mywork1_on.png";
        btn2.ImageUrl = "../images/Intro/mywork2_off.png";
        btn3.ImageUrl = "../images/Intro/mywork3_off.png";
        btn4.ImageUrl = "../images/Intro/mywork4_off.png";
       
    }

    protected void ugrdNotice_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        if (e.Row.Index > 3)
        {
            e.Row.Delete();
        }
        string title = e.Row.Cells.FromKey("TITLE").Value.ToString();
        string refid = e.Row.Cells.FromKey("NOTICE_REF_ID").Value.ToString();
        e.Row.Cells.FromKey("TITLE").Text = string.Format("<span style='cursor:pointer;' onclick='DblClickHandler_Notice({0})'>{1}</span>",
            refid, title);
    }


    protected void ugrdFAQ_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        string strFAQ_QUESTION = e.Row.Cells.FromKey("FAQ_QUESTION").Value.ToString();
        string imageUrl = "<img border='0' src='../images/Intro/icon_f.gif'>";
        string strText = imageUrl + strFAQ_QUESTION;

        e.Row.Cells.FromKey("FAQ_QUESTION").Text = string.Format("<span style='cursor:pointer;' onclick='DblClickHandler_Faq({0})'>{1}</span>",
            e.Row.Cells.FromKey("FAQ_REF_ID").Value.ToString(), strText);
    }

    #endregion

    #region --> Function
    /// <summary>
    /// my kpi
    /// </summary>
    private void SetMyKPIGrid()
    {
        writeLog(string.Format("{0} :SetMyKPIGrid() START", Request.PhysicalPath));

        ugrdMyKpiList.Clear();


        MicroBSC.Integration.BSC.Biz.Biz_My_Kpi bizMyKpi = new MicroBSC.Integration.BSC.Biz.Biz_My_Kpi();

        
        DataTable dtMyMboKpi = bizMyKpi.SelectMyMboKpi(IEstTermRefID,IYmd, gUserInfo.LoginID);

        if (dtMyMboKpi.Rows.Count > 0)
        {
           
            ugrdMyKpiList.DataSource = dtMyMboKpi;
            ugrdMyKpiList.DataBind();

            KPI_URL = "BSC1004S1.ASPX";
        }
        else{
            DataTable dtMyTeamKpi = bizMyKpi.SelectMyTeamKpi(IEstTermRefID, IYmd, gUserInfo.LoginID);

            if (dtMyTeamKpi.Rows.Count > 0)
            {
               
                ugrdMyKpiList.DataSource = dtMyTeamKpi;
                ugrdMyKpiList.DataBind();
                KPI_URL = "BSC0404S1.ASPX";
            }
            else{
                KPI_URL = "BSC0404S1.ASPX";
                ugrdMyKpiList.Visible = false;
            }


        }
        writeLog(string.Format("{0} :SetMyKPIGrid() END", Request.PhysicalPath));


    }

    /// <summary>
    /// 공지사항 조회
    /// </summary>
    private void SetNoticeGrid()
    {
        writeLog(string.Format("{0} :SetNoticeGrid() Start", Request.PhysicalPath));

        Biz_Bsc_Communication_Notice objBSC = new Biz_Bsc_Communication_Notice();

        this.ugrdNotice.Clear();
        this.ugrdNotice.DataSource = objBSC.GetAllList();
        this.ugrdNotice.DataBind();

        writeLog(string.Format("{0} :SetNoticeGrid() End", Request.PhysicalPath));

    }

    /// <summary>
    /// faq 조회
    /// </summary>
    private void SetFAQGrid()
    {
        writeLog(string.Format("{0} :SetFAQGrid() Start", Request.PhysicalPath));

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Faq objBSC = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Faq();
        DataTable dt = objBSC.SelectBscFaqAll();

            this.ugrdFAQ.Clear();
            this.ugrdFAQ.DataSource = dt;
            this.ugrdFAQ.DataBind();

        writeLog(string.Format("{0} :SetFAQGrid() End", Request.PhysicalPath));

    }

    /// <summary>
    /// bsc 스케쥴 조회
    /// </summary>
    private void SetSCHDGrid(string schd)
    {
        SetSCHDGrid(schd,4);
    }


    private void SetSCHDGrid(string schd, int row_cnt)
    {
        writeLog(string.Format("{0} : SetSCHDGrid() START", Request.PhysicalPath));

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score objBSC = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();
        DataTable dt = objBSC.GetBscSchedule(schd, row_cnt);

        this.ugrdSCHD.Clear();
        this.ugrdSCHD.DataSource = dt;
        this.ugrdSCHD.DataBind();

        writeLog(string.Format("{0} : SetSCHDGrid() END", Request.PhysicalPath));

    }

    private void DisplayScore()
    {

        writeLog(string.Format("{0} : DisplayScore() Start", Request.PhysicalPath));

        string mbo_name = "";
        int mbo_score = 0;
        int team_score = 0;
        int bonbu_score = 0;
        int jeonsa_score = 0;

        string dept_id = "";
        string dept_name = "";
        string est_dept_id = "";
        
        string bdept_id = "";
        string bdept_name = "";
        string best_dept_id = "";

        string jdept_id = "";
        string jdept_name = "";
        string jest_dept_id = "";

        string Jeonsa_id = "";
        string Jeonsa_name = "";

        Biz_Bsc_Intro_Score bizDeptInfo = new Biz_Bsc_Intro_Score();
        DataTable dtbizDeptInfo = bizDeptInfo.GetJeonsaInfo(DataTypeUtility.GetToInt32(IEstTermRefID).ToString()
                                       );

        if (dtbizDeptInfo.Rows.Count > 0)
        {
            Jeonsa_id = DataTypeUtility.GetString(dtbizDeptInfo.Rows[0][0]);
            Jeonsa_name = DataTypeUtility.GetString(dtbizDeptInfo.Rows[0][1]);
        }



        int score = 0;
        //MBO 점수 가져오기
        Biz_Bsc_Intro_Score bizScore = new Biz_Bsc_Intro_Score();
        DataTable dtbizScore = bizScore.GetMboScore(IEstTermRefID, IYmd, gUserInfo.LoginID);

        if (dtbizScore.Rows.Count > 0)
        {
            dept_id = dtbizScore.Rows[0][1].ToString();

            score = Convert.ToInt32(dtbizScore.Rows[0][3]);
            if (score < 0)
                score = 0;
            mbo_score = score;
        }
        mbo_name = gUserInfo.Emp_Name;

        //팀,본부,전사 명칭 가져오기
        dtbizScore = null;
        dtbizScore = bizScore.GetDeptInfo(Convert.ToInt32(dept_id));

        if (dtbizScore.Rows.Count > 0)
        {
            est_dept_id = dtbizScore.Rows[0][0].ToString();
            dept_name = dtbizScore.Rows[0][2].ToString();

            bdept_id = "";
            best_dept_id = dtbizScore.Rows[0][7].ToString();

            bdept_name = dtbizScore.Rows[0][15].ToString();

            if (est_dept_id == best_dept_id)
            {
                best_dept_id = Jeonsa_id;
                bdept_name = Jeonsa_name;
            }
            jest_dept_id = Jeonsa_id;
            jdept_name = Jeonsa_name;

        }

        //팀점수
        score = 0;
        dtbizScore = null;
        dtbizScore = bizScore.GetOrgScore("TS"
                                         , DataTypeUtility.GetToInt32(IEstTermRefID).ToString()
                                         , IYmd
                                         , DataTypeUtility.GetToInt32(est_dept_id).ToString());

        if (dtbizScore.Rows.Count > 0)
        {
            score = Convert.ToInt32(dtbizScore.Rows[0][6]);

            if (score < 0) 
                score = 0;
            team_score = score;

        }

        //본부점수
        score = 0;
        dtbizScore = null;
        dtbizScore = bizScore.GetOrgScore("TS"
                                         , DataTypeUtility.GetToInt32(IEstTermRefID).ToString()
                                         , IYmd
                                         , DataTypeUtility.GetToInt32(best_dept_id).ToString());

        if (dtbizScore.Rows.Count > 0)
        {
             score = Convert.ToInt32(dtbizScore.Rows[0][6]);
            if (score < 0)
                score = 0;
            bonbu_score = score;
        }


        //전사점수
        score = 0;
        dtbizScore = null;
        dtbizScore = bizScore.GetOrgScore("TS"
                                         , DataTypeUtility.GetToInt32(IEstTermRefID).ToString()
                                         , IYmd
                                         , DataTypeUtility.GetToInt32(jest_dept_id).ToString());

        if (dtbizScore.Rows.Count > 0)
        {
            score = Convert.ToInt32(dtbizScore.Rows[0][6]);
            if (score < 0)
                score = 0;
            jeonsa_score = score;
        }

        if (gUserInfo.Position_Rank_Code == "210")
        {
            //display
            lblUserName.Text = Utils.GetSubText(dept_name , 4, true);
            lblUserName.ToolTip = dept_name;
            lblMBOscore.Text = String.Format("{0:##0}", team_score);
            lblMBOscore.CssClass = searchColor(team_score);


            lblTEAMname.Text = bdept_name;
            lblTEAMname.ToolTip = bdept_name;
            lblTEAMscore.Text = String.Format("{0:##0}", bonbu_score);
            lblTEAMscore.CssClass = searchColor(bonbu_score);

            lblBONBUname.Text = jdept_name;
            lblBONBUname.ToolTip = jdept_name;
            lblBONBUscore.Text = String.Format("{0:##0}", jeonsa_score);
            lblBONBUscore.CssClass = searchColor(jeonsa_score);
        }
        else
        {
            //display
            lblUserName.Text = Utils.GetSubText(mbo_name, 4, true);
            lblUserName.ToolTip = mbo_name;
            if (KPI_URL == "BSC1004S1.ASPX")
            {
                lblMBOscore.Text = String.Format("{0:##0}", mbo_score);
                lblMBOscore.CssClass = searchColor(mbo_score);

            }
            else
            {
                lblMBOscore.Text = String.Format("{0:##0}", team_score);
                lblMBOscore.CssClass = searchColor(team_score);

            };
            //lblMBOscore.Text = String.Format("{0:##0}", mbo_score);
            //lblMBOscore.CssClass = searchColor(mbo_score);


            lblTEAMname.Text = dept_name;
            lblTEAMname.ToolTip = dept_name;
            lblTEAMscore.Text = String.Format("{0:##0}", team_score);
            lblTEAMscore.CssClass = searchColor(team_score);

            lblBONBUname.Text = bdept_name;
            lblBONBUname.ToolTip = bdept_name;
            lblBONBUscore.Text = String.Format("{0:##0}", bonbu_score);
            lblBONBUscore.CssClass = searchColor(bonbu_score);

        }



        writeLog(string.Format("{0} : DisplayScore() End", Request.PhysicalPath));

    }

    #endregion
    protected void btn2_Click(object sender, ImageClickEventArgs e)
    {
        SetSCHDGrid("개인성과평가");
        btn1.ImageUrl = "../images/Intro/mywork1_off.png";
        btn2.ImageUrl = "../images/Intro/mywork2_on.png";
        btn3.ImageUrl = "../images/Intro/mywork3_off.png";
        btn4.ImageUrl = "../images/Intro/mywork4_off.png";


    }
    protected void btn3_Click(object sender, ImageClickEventArgs e)
    {
        SetSCHDGrid("역량평가");

        btn1.ImageUrl = "../images/Intro/mywork1_off.png";
        btn2.ImageUrl = "../images/Intro/mywork2_off.png";
        btn3.ImageUrl = "../images/Intro/mywork3_on.png";
        btn4.ImageUrl = "../images/Intro/mywork4_off.png";


    }
    protected void btn4_Click(object sender, ImageClickEventArgs e)
    {
        SetSCHDGrid("성과현황");
       
        btn1.ImageUrl = "../images/Intro/mywork1_off.png";
        btn2.ImageUrl = "../images/Intro/mywork2_off.png";
        btn3.ImageUrl = "../images/Intro/mywork3_off.png";
        btn4.ImageUrl = "../images/Intro/mywork4_on.png";


    }
    private string searchColor(int score)
    {
        string rtvalue = null;

        if (score >= 100)
        {
            rtvalue = "fcols2";
        }
        else if (score >= 90 && score < 100)
        {
            rtvalue = "fcola2";

        }
        else if (score >= 80 && score < 90)
        {
            rtvalue = "fcolb2";

        }
        else if (score >= 70 && score < 80)
        {
            rtvalue = "fcolc2";

        }
        else if ( score < 70)
        {
            rtvalue = "fcold2";

        }

        return rtvalue;
    }
}