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

public partial class BSC_INTRO2 : AppPageBase
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

            SetRankGrid();
            SetIndiGrid();
            SetNoticeGrid();
            SetFAQGrid();
            DisplayScore();

            //좌측메뉴설정
            base.SetMenuControl(true, true, true);

        }
        writeLog(string.Format("{0} : Page_Load START", Request.PhysicalPath));


    }

    #endregion

    #region --> Event

    
    protected void ugrdSCHD_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }

    protected void ugrdSCHD_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        string schd_mid = DataTypeUtility.GetValue(e.Row.Cells.FromKey("schd_mid").Value);
        string link_dir = DataTypeUtility.GetValue(e.Row.Cells.FromKey("link_dir").Value);
        string link_page_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("link_page_name").Value);

        string url = "<a href='{0}{1}'>{2}</a>";
        string link = string.Format(url, link_dir, link_page_name, schd_mid);

        e.Row.Cells.FromKey("schd_mid").Text = link;


        string schd_mid_desc = DataTypeUtility.GetString(e.Row.Cells.FromKey("schd_mid_desc").Value);
        e.Row.Cells.FromKey("schd_mid_desc").Value = string.Format("<span title=\"{0}\">{0}</span>", schd_mid_desc);
    }

    protected void ugrdRank_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }

    protected void ugrdRank_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        int score = Convert.ToInt32(e.Row.Cells.FromKey("TS_SCORE").Value);
 
        string imageUrl = "<img border='0' src='" + searchRankImg(score) + "'>";

        e.Row.Cells.FromKey("TS_SCORE").Text = imageUrl;

    }

    protected void ugrdIndi_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void ugrdIndi_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
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
 


    protected void iBtn1_Click(object sender, ImageClickEventArgs e)
    {
        SetSCHDGrid("조직성과평가");

        btn1.ImageUrl = "../images/Intro/mywork1_on.png";
        btn2.ImageUrl = "../images/Intro/mywork2_off.png";
        btn3.ImageUrl = "../images/Intro/mywork3_off.png";
        btn4.ImageUrl = "../images/Intro/mywork4_off.png";
       
    }
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


    #endregion

    #region --> Function
    /// <summary>
    /// my kpi
    /// </summary>
    private void SetRankGrid()
    {
        writeLog(string.Format("{0} : SetRankGrid() START", Request.PhysicalPath));

        ugrdRank.Clear();

        //MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score bizScore = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();
        //DataTable dtbizScore =  bizScore.GetOrgRank(IEstTermRefID
        //                                 , IYmd
        //                                 , 4 );

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score bizScore = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();

        DataTable dtbizScore = bizScore.GetOrgRankBonbuDesc(IEstTermRefID, IYmd, "4", "TS", 4);

        if (dtbizScore.Rows.Count > 0)
        {

            ugrdRank.DataSource = dtbizScore;
            ugrdRank.DataBind();

        }

        writeLog(string.Format("{0} : SetRankGrid() End", Request.PhysicalPath));

       
    }

    private void SetIndiGrid()
    {

        writeLog(string.Format("{0} : SetIndiGrid() Start", Request.PhysicalPath));

        MicroBSC.Integration.COM.Biz.Biz_NHIT bizNHIT = new MicroBSC.Integration.COM.Biz.Biz_NHIT();
        DataTable dtNHIT = bizNHIT.GetJeonSa("A"
                                           , 10
                                           , ""
                                           , "","T");

        object objMaxYear = dtNHIT.Compute("MAX(CR_YEAR)", "");
        object objMaxMonth = dtNHIT.Compute("MAX(CR_MONTH)", string.Format(" CR_YEAR = '{0}' ", objMaxYear));

        DataRow[] rows = dtNHIT.Select(string.Format(" CR_YEAR = '{0}' AND CR_MONTH = '{1}' ",objMaxYear, objMaxMonth)," SORT_ORDER ");

        if (rows.Length > 0)
        {



            double rate = 0;
            double rate1p = 0;
            double rate2p = 0;
            double rate3p = 0;


            amt1.Text = String.Format("{0:##,##0}", DataTypeUtility.GetToInt32(rows[0][10]));
            rate1.Text = String.Format("{0:##,##0.00}",DataTypeUtility.GetToDouble(rows[0][11]) * 100);

            amt2.Text = String.Format("{0:##,##0}", DataTypeUtility.GetToInt32(rows[1][10]));
            rate2.Text = String.Format("{0:##,##0.00}",DataTypeUtility.GetToDouble(rows[1][11]) * 100);

            amt3.Text = String.Format("{0:##,##0}", DataTypeUtility.GetToInt32(rows[2][10]));
            rate3.Text = String.Format("{0:##,##0.00}",DataTypeUtility.GetToDouble(rows[2][11]) * 100);

            rate1p = DataTypeUtility.GetToDouble(rows[0][11]) * 100 * 0.5;
            rate2p = DataTypeUtility.GetToDouble(rows[1][11]) * 100 * 0.5;
            rate3p = DataTypeUtility.GetToDouble(rows[2][11]) * 100 * 0.5;

            //if (rate < rate1p)
            //{
            //    rate = rate1p;
            //}

            //if (rate < rate2p)
            //{
            //    rate = rate2p;
            //}

            //if (rate < rate3p)
            //{
            //    rate = rate3p;
            //}

            //if (rate > 100)
            //{
            //    rate1p = (rate1p == 0) ? rate1p : (rate1p / rate * 100);
            //    rate2p = (rate2p == 0) ? rate2p : (rate2p / rate * 100);
            //    rate3p = (rate3p == 0) ? rate3p : (rate3p / rate * 100);
            //}

            if (rate1p < 0)
            {
                rate1p = 0;
            }
            if (rate1p > 100)
            {
                rate1p = 100;
            }

            if (rate2p < 0)
            {
                rate2p = 0;
            }
             if (rate2p > 100)
            {
                rate2p = 100;
            }

            if (rate3p < 0)
            {
                rate3p = 0;
            }
             if (rate3p > 100)
            {
                rate3p = 100;
            }

            string wid1 = @"width:{0}%";
            string widthvalue1 = string.Format(wid1, rate1p);
            ratediv1.Attributes.Add("style", widthvalue1);

            string wid2 = @"width:{0}%";
            string widthvalue2 = string.Format(wid2, rate2p);
            ratediv2.Attributes.Add("style", widthvalue2);

            string wid3 = @"width:{0}%";
            string widthvalue3 = string.Format(wid3, rate3p);
            ratediv3.Attributes.Add("style", widthvalue3);
        }

        writeLog(string.Format("{0} : SetIndiGrid() End", Request.PhysicalPath));

        
    }

    /// <summary>
    /// 공지사항 조회
    /// </summary>
    private void SetNoticeGrid()
    {
        writeLog(string.Format("{0} : SetNoticeGrid() Start", Request.PhysicalPath));

        Biz_Bsc_Communication_Notice objBSC = new Biz_Bsc_Communication_Notice();

        this.ugrdNotice.Clear();
        this.ugrdNotice.DataSource = objBSC.GetAllList();
        this.ugrdNotice.DataBind();

        writeLog(string.Format("{0} : SetNoticeGrid() End", Request.PhysicalPath));

    }

    /// <summary>
    /// faq 조회
    /// </summary>
    private void SetFAQGrid()
    {
        writeLog(string.Format("{0} : SetFAQGrid() Start", Request.PhysicalPath));

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Faq objBSC = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Faq();
        DataTable dt = objBSC.SelectBscFaqAll();

        this.ugrdFAQ.Clear();
        this.ugrdFAQ.DataSource = dt;
        this.ugrdFAQ.DataBind();

        writeLog(string.Format("{0} : SetFAQGrid() End", Request.PhysicalPath));

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
        writeLog(string.Format("{0} : SetSCHDGrid() Start", Request.PhysicalPath));

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score objBSC = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Intro_Score();
        DataTable dt = objBSC.GetBscSchedule(schd, row_cnt);

        this.ugrdSCHD.Clear();
        this.ugrdSCHD.DataSource = dt;
        this.ugrdSCHD.DataBind();

        writeLog(string.Format("{0} : SetSCHDGrid() End", Request.PhysicalPath));

    }

    private void DisplayScore()
    {
        writeLog(string.Format("{0} : DisplayScore() Start", Request.PhysicalPath));

        string dept_id = "";
        string dept_name = "";
        string est_dept_id = "";

        string bdept_id = "";
        string bdept_name = "";
        string best_dept_id = "";

        Biz_Bsc_Intro_Score bizDeptInfo = new Biz_Bsc_Intro_Score();
        DataTable dtbizDeptInfo = bizDeptInfo.GetJeonsaInfo(DataTypeUtility.GetToInt32(IEstTermRefID).ToString()
                                       );

        if (dtbizDeptInfo.Rows.Count > 0)
        {
            est_dept_id = DataTypeUtility.GetString(dtbizDeptInfo.Rows[0][0]);
            dept_name = DataTypeUtility.GetString(dtbizDeptInfo.Rows[0][1]);
        }

        int score = 0;

        Biz_Bsc_Intro_Score bizScore = new Biz_Bsc_Intro_Score();
        DataTable dtbizScore = bizScore.GetOrgScore("TS"
                                         , DataTypeUtility.GetToInt32(IEstTermRefID).ToString()
                                         , IYmd
                                         , DataTypeUtility.GetToInt32(est_dept_id).ToString());

        if (dtbizScore.Rows.Count > 0)
        {
            score = Convert.ToInt32(dtbizScore.Rows[0][6]);

            if (score < 0) 
                score = 0;

        }
        lblTEAMname.Text = dept_name;
        lblTEAMname.ToolTip = dept_name;

        lblTEAMscore.Text = String.Format("{0:##0}", score);
        lblTEAMscore.CssClass = searchColor(score);

        string ESTTERM_REF_ID = DataTypeUtility.GetToInt32(IEstTermRefID).ToString();
        string YMD = IYmd;
        string SUM_TYPE = "TS";

        string url = "BSC0408S6.ASPX?ESTTERM_REF_ID={0}&YMD={1}&SUM_TYPE={2}";
        //string url = "BSC0408S4.ASPX?ESTTERM_REF_ID={0}&YMD={1}&SUM_TYPE={2}";
        KPI_URL = string.Format(url, ESTTERM_REF_ID, YMD, SUM_TYPE);

        writeLog(string.Format("{0} : DisplayScore() End", Request.PhysicalPath));

    }

    #endregion


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


    private string searchRankImg(int score)
    {
        string rtvalue = null;

        if (score >= 100)
        {
            rtvalue = "../images/NHIT/org/signal_set1/icon_s.gif";
        }
        else if (score >= 90 && score < 100)
        {
            rtvalue = "../images/NHIT/org/signal_set1/icon_a.gif";
        }
        else if (score >= 80 && score < 90)
        {
            rtvalue = "../images/NHIT/org/signal_set1/icon_b.gif";
        }
        else if (score >= 70 && score < 80)
        {
            rtvalue = "../images/NHIT/org/signal_set1/icon_c.gif";
        }
        else if (score < 70)
        {
            rtvalue = "../images/NHIT/org/signal_set1/icon_d.gif";
        }

        return rtvalue;
    }

}