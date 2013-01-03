using System;
using System.Drawing;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Xml;

using Dundas.Charting.WebControl;
//using MicroBSC.Data;
using MicroBSC.RolesBasedAthentication;

// ///////////////////////////////////////////////////////////////////////////////////
// Class   명	    : AppPageBase 클래스(UI단)
// Class 내용		: 웹페이지 클래스의 기본클래스입니다.
// 작  성  자		: 강신규
// 최초작성일		: 2006.05.15
// 최종수정자		: 
// 최종수정일		: 
// Services		    :	
// ////////////////////////////////////////////////////////////////////////////////////

public class AppPageBase : PageBase
{
    // 그리드에서 사용될 색
    protected Color CLR_GRP_FORECOLOR = Color.FromArgb(75, 90, 118);
    protected Color CLR_GRP_BACKCOLOR_1 = Color.FromArgb(232, 241, 251);
    protected Color CLR_GRP_BACKCOLOR_2 = Color.FromArgb(244, 248, 252);
    protected Color CLR_SUM_BACKCOLOR_1 = Color.FromArgb(249, 249, 249);
    protected Color CLR_SUM_BACKCOLOR_2 = Color.FromArgb(238, 238, 238);

    protected string QUERY_STRINGS = "?BOARD_CATEGORY={0}&ESTTERM_REF_ID={1}&TMCODE={2}&KPI_REF_ID={3}&EST_DEPT_REF_ID={4}&EMP_REF_ID={5}&RECEIVER_ID={6}&SEARCH_KEY={7}&SEARCH_VALUE={8}&PAGE={9}&MODE={10}&GROUP_ID={11}&LEVEL_ID={12}&SEQ_ID={13}&IDX={14}&READ_ONLY={15}&KPI_VIEW={16}&SEARCH_1_VIEW={17}&SEARCH_2_VIEW={18}&SEARCH_2_DEPT_VIEW={19}";

    private AppPageUtility _libPageUtil;
    private AppTypeUtility _libTypeUtil;

    protected SiteIdentity gUserInfo
    {
        get
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
                return (SiteIdentity) User.Identity;

            return null;
        }
    }

    /// <summary>
    /// 서비스명	: PageUtility 프로퍼티.
    /// 서비스내용	: PageUtility 객체를 가져옵니다.
    /// </summary>
    protected AppPageUtility PageUtility
    {
        get
        {
            return _libPageUtil;
        }
    }

    /// <summary>
    /// 서비스명	: TypeUtility 프로퍼티.
    /// 서비스내용	: TypeUtility 객체를 가져옵니다.
    /// </summary>
    protected AppTypeUtility TypeUtility
    {
        get
        {
            return _libTypeUtil;
        }
    }

    private string _userId;
    //protected DBAgent gDbAgent = null;
    //protected DBAgent gDbAgentEIS = null;

    #region 현페이지가 리프레시 (F5)인지 검사
    private bool _refreshState;
    private bool _isRefresh;

    public bool IsPageRefresh
    {
        get
        {
            return _isRefresh;
        }
    }

    protected override void LoadViewState(object savedState)
    {
        object[] allStates = (object[])savedState;
        base.LoadViewState(allStates[0]);

        _refreshState = (bool)allStates[1];

        if (Session["__ISREFRESH"] != null)
            _isRefresh = _refreshState == (bool)Session["__ISREFRESH"];
        else
            _isRefresh = false;
    }

    protected override object SaveViewState()
    {
        Session["__ISREFRESH"] = _refreshState;
        object[] allStates = new object[2];

        allStates[0] = base.SaveViewState();
        allStates[1] = !_refreshState;

        return allStates;
    }
    #endregion

    private int[,] GRID_COLOR = new int[,]
                                  {
                                      {0x98, 0xc7, 0xd0},   // Group 1
                                      {0xb9, 0xdc, 0xe3},   // Group 2
                                      {0xb9, 0xc8, 0x92},   // SubTotal Name 1
                                      {0xc5, 0xb1, 0xcf},   // SubTotal Name 2
                                      {0xe5, 0xf1, 0xc6},   // SubTotal Data 1
                                      {0xe9, 0xd6, 0xf3}    // SubTotal Data 2
                                  };

    protected int[,] CHART_COLOR = new int[,]
                                   {
                                        //{0x7C, 0xA8, 0xFE},
                                        //{0xFE, 0xD3, 0x25},
                                        //{0xFE, 0x7C, 0x25},
                                        //{0xA7, 0xD2, 0x7B},
                                        //{0xC3, 0x95, 0xDE},
                                        //{0xA8, 0xD2, 0xFD},
                                        //{0xFB, 0xEE, 0xA6},
                                        //{0xFC, 0xD1, 0xA6},
                                        //{0xD1, 0xFC, 0xD1},
                                        //{0xe9, 0x01, 0x6e},
                                        //{0x8e, 0xa5, 0x11},
                                        //{0x87, 0x69, 0x8f},
                                        //{0x6b, 0x91, 0x8a},
                                        //{0xff, 0x66, 0x66},
                                        //{0x00, 0x33, 0xc2},
                                        //{0xff, 0xc4, 0xec}
                                        //{0x5a, 0x7d, 0xde},
                                        //{0xff, 0x8a, 0x00},
                                        //{0x00, 0xC4, 0xCB},
                                        //{0x38, 0xd9, 0x38},
                                        //{0x00, 0x33, 0xc2},
                                        //{0x00, 0xc4, 0xcb},
                                        //{0x35, 0xa5, 0x72},
                                        //{0xd7, 0xa8, 0x71},
                                        //{0xc6, 0xc5, 0xe5},
                                        //{0xe9, 0x01, 0x6e},
                                        //{0x8e, 0xa5, 0x11},
                                        //{0x87, 0x69, 0x8f},
                                        //{0x6b, 0x91, 0x8a},
                                        //{0xff, 0x66, 0x66},
                                        //{0x00, 0x33, 0xc2},
                                        //{0xff, 0xc4, 0xec}

                                        {0x0c, 0x4c, 0xd4},
                                        {0xff, 0xa1, 0x0d},
                                        {0xad, 0x00, 0x00},
                                        {0xff, 0x72, 0x00},
                                        {0x75, 0xd8, 0x00},
                                        {0xA8, 0xD2, 0xFD},
                                        {0xFB, 0xEE, 0xA6},
                                        {0xFC, 0xD1, 0xA6},
                                        {0xD1, 0xFC, 0xD1},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };

    protected int[,] SIGNAL_COLOR = new int[,]
                                   {
                                        {0x00, 0x64, 0xff}, // Excellent
                                        {0x22, 0x8b, 0x22}, // Good 
                                        {0xff, 0x14, 0x93}, // Watching
                                        {0xcd, 0x00, 0x00}, // Alert
                                        {0x82, 0x82, 0x82}, // Unmeasured
                                        {0x82, 0x82, 0x82}, 
                                        {0xFB, 0xEE, 0xA6},
                                        {0xFC, 0xD1, 0xA6},
                                        {0xD1, 0xFC, 0xD1},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };

    protected int[,] CHART_COLOR_INT = new int[,]
                                   {
                                        {49, 108, 206},
                                        {255, 115, 1},
                                        {107, 148, 49},
                                        {99, 49, 206},
                                        {254, 17, 148},
                                        {68, 149, 149},
                                        {246, 175, 10},
                                        {89, 107, 141},
                                        {179, 123, 120},
                                        {241, 238, 149}
                                   };

    // 시그널컬러 리턴
    protected Color GetSignalColor(int i)
    {
        int iCheck = i % 16;

        return Color.FromArgb(SIGNAL_COLOR[iCheck, 0], SIGNAL_COLOR[iCheck, 1], SIGNAL_COLOR[iCheck, 2]);
    }

    protected Color GetGridColor(gEN_GRID_COLOR enCol)
    {
        int ICheck = (int)enCol % 6;

        return Color.FromArgb(GRID_COLOR[ICheck, 0], GRID_COLOR[ICheck, 1], GRID_COLOR[ICheck, 2]);
    }

    // 챠트칼라 리턴
    protected Color GetChartColor(int i)
    {
        int iCheck = i % 16;

        return Color.FromArgb(CHART_COLOR[iCheck, 0], CHART_COLOR[iCheck, 1], CHART_COLOR[iCheck, 2]);
    }

    // 챠트 마커스타일 리턴
    protected static MarkerStyle GetMarkerStyle(int i)
    {
        int iCheck = i % 9;

        switch (iCheck)
        {
            case 0:
                return MarkerStyle.Circle;
            case 1:
                return MarkerStyle.Cross;
            case 2:
                return MarkerStyle.Diamond;
            case 3:
                return MarkerStyle.Square;
            case 4:
                return MarkerStyle.Star10;
            case 5:
                return MarkerStyle.Star4;
            case 6:
                return MarkerStyle.Star5;
            case 7:
                return MarkerStyle.Star6;
            case 8:
                return MarkerStyle.Triangle;
            default:
                return MarkerStyle.None;
        }
    }

    protected string USERID
    {
        get
        {
            return _userId;
        }
    }

    override protected void OnInit(EventArgs e)
    {
        base.OnInit(e);

        _libPageUtil = new AppPageUtility(this);
        _libTypeUtil = new AppTypeUtility();

        //gDbAgent    = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        //gDbAgentEIS = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["EISDB"].ConnectionString);

        if (Context.User.Identity.IsAuthenticated)
        {
            _userId = User.Identity.Name;
        }
        else
        {
            _userId = "Anonymous";
        }

        Response.AddHeader("P3P", "CP='CAO PSA CONi OTR OUR DEM ONL'");

        //Response.Write("<META http-equiv=\"Page-Enter\" content=\"blendTrans(Duration=0.3)\">");
        //Response.Write("<META http-equiv=\"Page-Exit\" content=\"blendTrans(Duration=0.3)\">");

        //string sScript = "window.attachEvent('onbeforeunload', gfAttachBeforeUnload_DT);\n"
        //               + "document.body.attachEvent('onfocusout', gfAttachFocusOut_DT);\n"
        //               + "window.attachEvent('onload', gfAttachLoad_DT);\n"
        //               + "document.writeln(\"<iframe id='ifrWAIT' frameborder='0' scrolling='no' class='WaitingBar'></iframe>\");\n"
        //               + "document.writeln(\"<div id='flpWAIT' class='WaitingBarDiv'></div>\");\n";

        //_libPageUtil.ExecuteScript(sScript);

        
    }

    protected static DataSet GetDataSet(string query)
    {
        MicroBSC.Data.DBAgent dbAgent = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        return ds;
    }

    protected static void SetHalfYearDropDownList(DropDownList ddlYear)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("KEY", typeof(string));
        dt.Columns.Add("VALUE", typeof(string));

        for (int i = 2001; i <= 2008; i++)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["KEY"] = i.ToString() + ".상반기";
            dr["VALUE"] = i.ToString() + "_1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["KEY"] = i.ToString() + ".하반기";
            dr["VALUE"] = i.ToString() + "_2";
            dt.Rows.Add(dr);
        }

        //DataTable dt = userData.GetYear();

        DataView dv = dt.DefaultView;
        dv.Sort = "KEY DESC";
        ddlYear.DataSource = dv;
        ddlYear.DataTextField = "VALUE";
        ddlYear.DataValueField = "KEY";
        ddlYear.DataBind();
    }

    protected static void DatabaseBindingXY(Series series, string xColunmName, string yColunmName, DataTable dataTable)
    {
        int rowCount    = dataTable.Rows.Count;
        string[] xval   = new string[rowCount];
        double[] yval   = new double[rowCount];

        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            xval[i]     = dataTable.Rows[i][xColunmName].ToString();
            yval[i]     = Convert.ToDouble(dataTable.Rows[i][yColunmName].ToString());

        }

        series.Points.DataBindXY(xval, yval);
    }
    //protected void SetVisibleZeroPoint(Chart chart, int year) 
    //{
    //    for (int i = 0; i < chart.Series.Count; i++)
    //    {
    //        for (int j = 0; j < chart.Series[i].Points.Count; j++)
    //        {
    //            //series2.Points[i].ShowLabelAsValue = true;

    //            if (chart.Series[i].Points[j].GetValueY(0) == 0
    //                //&& System.DateTime.Now.Year.ToString() == year.ToString()
    //                //&& ( j + 1 ) >= System.DateTime.Now.Month 
    //                )
    //            {
    //                chart.Series[i].Points[j].Color = Color.Transparent;
    //                chart.Series[i].Points[j].BorderColor = Color.Transparent;
    //                chart.Series[i].Points[j].MarkerStyle = MarkerStyle.None;
    //                //chart.Series[i].Points[j].BorderWidth = 1;
    //            }
    //        }
    //    }
    //}
    protected static void SetVisibleZeroPoint(Chart chart)
    {

        for (int i = 0; i < chart.Series.Count; i++)
        {
            for (int j = 0; j < chart.Series[i].Points.Count; j++)
            {
                //series2.Points[i].ShowLabelAsValue = true;

                if (chart.Series[i].Points[j].GetValueY(0) == 0)
                {
                    chart.Series[i].Points[j].Color = Color.Transparent;
                    chart.Series[i].Points[j].BorderColor = Color.Transparent;
                    chart.Series[i].Points[j].MarkerStyle = MarkerStyle.None;
                    //chart.Series[i].Points[j].BorderWidth = 1;
                }
            }
        }
    }

    protected static void SetVisibleZeroPoint(Chart chart, int iYear)
    {
        SetVisibleZeroPoint(chart, iYear, DateTime.Now.Month);
        //for (int i = 0; i < chart.Series.Count; i++)
        //{
        //    for (int j = iMonth; j < chart.Series[i].Points.Count; j++)
        //    {
        //        //series2.Points[i].ShowLabelAsValue = true;

        //        if (chart.Series[i].Points[j].GetValueY(0) == 0)
        //        {
        //            chart.Series[i].Points[j].Color = Color.Transparent;
        //            chart.Series[i].Points[j].BorderColor = Color.Transparent;
        //            chart.Series[i].Points[j].MarkerStyle = MarkerStyle.None;
        //            //chart.Series[i].Points[j].BorderWidth = 1;
        //        }
        //    }
        //}
    }

    protected static void SetVisibleZeroPoint(Chart chart, int iYear, int iMonth)
    {
        DateTime date = DateTime.Now;

        for (int i = 0; i < chart.Series.Count; i++)
        {
            if (iYear <= date.Year)
            {
                for (int j = (iMonth - 1); j < chart.Series[i].Points.Count; j++)
                {
                    //series2.Points[i].ShowLabelAsValue = true;

                    if (
                            chart.Series[i].Points[j].GetValueY(0) == 0
                         && date.Year == iYear
                       )
                    {
                        chart.Series[i].Points[j].Color = Color.Transparent;
                        chart.Series[i].Points[j].BorderColor = Color.Transparent;
                        chart.Series[i].Points[j].MarkerStyle = MarkerStyle.None;
                        //chart.Series[i].Points[j].BorderWidth = 1;
                    }
                }
            }
            else
            {
                SetVisibleZeroPoint(chart);
            }
        }
    }

    protected static void BindingToolTip(Chart chart)
    {
        for (int i = 0; i < chart.Series.Count; i++)
        {
            for (int j = 0; j < chart.Series[i].Points.Count; j++)
            {
                chart.Series[i].Points[i].ToolTip = j.ToString();
            }
        }
    }
    protected static void SetVisibleZeroLabelText(Chart chart)
    {
        for (int i = 0; i < chart.Series.Count; i++)
        {
            for (int j = 0; j < chart.Series[i].Points.Count; j++)
            {
                if (chart.Series[i].Points[j].GetValueY(0) == 0)
                {
                    chart.Series[i].Points[j].ShowLabelAsValue = false;
                }
            }
        }
    }

    /// <summary>
    /// Request인자값을 받아내는 함수
    /// </summary>
    /// <param name="asKey"></param>
    /// <returns></returns>
    protected string GetRequest(string asKey)
    {
        return (Request[asKey] == null ? "" : Request[asKey]);
    }

    /// <summary>
    /// Request인자값을 받아내는 함수
    /// </summary>
    /// <param name="asKey"></param>
    /// <returns></returns>
    /// <param name="nullValue"></param>
    protected int GetRequestByInt(string asKey, int nullValue)
    {
        if (Request[asKey] == null || Request[asKey].Trim() == "")
            return nullValue;

        return Convert.ToInt32(Request[asKey]);
    }

    /// <summary>
    /// Request인자값을 받아내는 함수
    /// </summary>
    /// <param name="asKey"></param>
    /// <returns></returns>
    protected int GetRequestByInt(string asKey)
    {
        return GetRequestByInt(asKey, 0);
    }

    /// <summary>
    /// Request인자값을 받아내는 함수
    /// </summary>
    /// <param name="asKey"></param>
    /// <returns></returns>
    /// <param name="nullValue"></param>
    protected string GetRequest(string asKey, string nullValue)
    {
        string reVal = nullValue;
        if (Request[asKey] != null)
        {
            string temp = Request[asKey];

            if (temp.ToUpper().IndexOf("SELECT") > 0
                || temp.ToUpper().IndexOf("FROM") > 0
                || temp.ToUpper().IndexOf("HTML") > 0
                || temp.ToUpper().IndexOf("HTM") > 0
                || temp.ToUpper().IndexOf("SCRIPT") > 0
                || temp.ToUpper().IndexOf("TRIM") > 0
                || temp.ToUpper().IndexOf("AND") > 0
                || temp.ToUpper().IndexOf("|") > 0
                || temp.ToUpper().IndexOf("&") > 0
                || temp.ToUpper().IndexOf(";") > 0
                //|| temp.ToUpper().IndexOf("$") > 0
                || temp.ToUpper().IndexOf("%") > 0
                || temp.ToUpper().IndexOf("@") > 0
                || temp.ToUpper().IndexOf("'") > 0
                || temp.ToUpper().IndexOf("\"") > 0
                || temp.ToUpper().IndexOf("\\") > 0
                || temp.ToUpper().IndexOf("\\\"") > 0
                || temp.ToUpper().IndexOf("<") > 0
                || temp.ToUpper().IndexOf("<") > 0
                || temp.ToUpper().IndexOf("(") > 0
                || temp.ToUpper().IndexOf(")") > 0
                || temp.ToUpper().IndexOf("+") > 0
                || temp.ToUpper().IndexOf("\\r") > 0
                || temp.ToUpper().IndexOf("\\n") > 0
                || temp.ToUpper().IndexOf(",") > 0
                || temp.ToUpper().IndexOf(".INI") > 0
                )
            {
                reVal = "-0";
            }
            else
            {
                reVal = temp;
            }
        }

        return reVal;

        //return (Request[asKey] == null ? nullValue : Request[asKey]);
    }

    protected static string GetValue(object aObj)
    {
        if (aObj == null)
            return "";

        return aObj.ToString().Replace("&nbsp;", "");
    }

    protected static string GetFieldValue(object fieldName)
    {
        return GetFieldValue(fieldName, "");
    }

    protected static string GetFieldValue(object fieldName, string returnStr)
    {
        if (fieldName == DBNull.Value)
            return returnStr;

        return fieldName.ToString();
    }

    protected static string GetFormatString(FormatType formatType)
    {
        if (formatType == FormatType.CNT)
            return "0";
        if (formatType == FormatType.CUR)
            return "#,##0.000";
        if (formatType == FormatType.PCT)
            return "#,##0.00";
        if (formatType == FormatType.PNT)
            return "0";

        return "#,##0.00";
    }

    /// <summary>
    /// 스트링 문자열을 포멧마스크를 적용하여 반환
    /// 기본문자열은 '-' 임
    /// </summary>
    /// <param name="sDigit">문자열</param>
    /// <param name="sFormat">포멧스트링</param>
    /// <returns></returns>
    protected static string GetStringDigit(string sDigit, string sFormat)
    {
        decimal dRtn = 0;
        if (decimal.TryParse(sDigit, out dRtn))
        {
            return dRtn.ToString(sFormat);
        }
        else
        {
            return sDigit;
        }
    }

    protected static string GetStatusImageName(string status)
    {
        if (status.Trim() == "E")
        {
            return "<img src='../images/icon/est_i02.gif'>";
        }
        else if (status.Trim() == "P")
        {
            return "<img src='../images/icon/est_i01.gif'>";
        }
        else if (status.Trim() == "S")
        {
            return "<img src='../images/icon/est_i07.gif'>";
        }
        else if (status.Trim() == "W")
        {
            return "<img src='../images/icon/est_i06.gif'>";
        }
        else if (status.Trim() == "C")
        {
            return "<img src='../images/icon/est_i03.gif'>";
        }

        return "<img src='../images/icon/est_i03.gif'>";
    }

    protected static string GetStatusFromColor(string status)
    {
        if (status.Trim() == "E")
        {
            return "#C0E0FF";
        }
        else if (status.Trim() == "P")
        {
            return "#008000";
        }
        else if (status.Trim() == "S")
        {
            return "#FF80FF";
        }
        else if (status.Trim() == "W")
        {
            return "#800080";
        }
        else if (status.Trim() == "C")
        {
            return "#FF8000";
        }

        return "#FF8000";
    }

    /// <summary>
    /// 여러 평가중에서 다차평가 value, text 바인딩
    /// </summary>
    /// <param name="estterm_sub_id"></param>
    /// <param name="est_type"></param>
    /// <returns></returns>
    protected static string GetEstTermSubString(int estterm_sub_id, int est_type)
    {
        string[] values = System.Configuration.ConfigurationManager.AppSettings["EST.TERM.ABL.SUB.VALUES"].ToString().Split(',');
        string[] texts  = System.Configuration.ConfigurationManager.AppSettings["EST.TERM.ABL.SUB.TEXTS"].ToString().Split(',');
        string[] isUsed = System.Configuration.ConfigurationManager.AppSettings["EST.TERM.SUB.USE"].ToString().Split(',');

        if (values.Length != texts.Length)
            return null;

        for (int i = 0; i < isUsed.Length; i++)
        {
            if (est_type == int.Parse(isUsed[i]))
            {
                for (int j = 0; j < values.Length; j++)
                {
                    if (estterm_sub_id == int.Parse(values[j]))
                        return texts[j];
                }
            }
        }

        return "-";
    }

    protected int GetEstTermSubValue(DropDownList ddlEstTermSub)
    {
        return GetEstTermSubValue(ddlEstTermSub, 1);
    }

    /// <summary>
    /// 평가 주기에서 역량평가일 때 주기 설정 컨트로롤 값 Return
    /// </summary>
    /// <param name="ddlEstTermSub"></param>
    /// <returns></returns>
    /// <param name="returnVaue"></param>
    protected int GetEstTermSubValue(DropDownList ddlEstTermSub, int returnVaue)
    {
        if (!ddlEstTermSub.Visible)
            return returnVaue;

        return _libPageUtil.GetIntByValueDropDownList(ddlEstTermSub);
    }

    protected static void SendNewMail(string from
                                        , string to
                                        , string subject
                                        , string body
                                        , string url
                                        , string server)
    {
        MailMessage message         = new MailMessage(from, to);
        message.Subject             = subject;
        message.Body                = body;
        message.SubjectEncoding     = System.Text.Encoding.Default;
        message.BodyEncoding        = System.Text.Encoding.Default;
        message.IsBodyHtml          = true;

        SmtpClient client           = new SmtpClient(server);
        client.UseDefaultCredentials = true;
        client.Send(message);
    }

    #region DataGrid Header Column Fix

    // 헤더고정
    protected static void FixHeaderCol(GridViewRowEventArgs e, string sParent)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].CssClass.ToLower() != "nonedisplay")
                {
                    e.Row.Cells[i].Style.Add("border-left", "1px solid #D4D0C8");
                    e.Row.Cells[i].Style.Add("border-bottom", "1px solid #D4D0C8");
                    e.Row.Cells[i].Style.Add("border-top-style", "none");
                    e.Row.Cells[i].Style.Add("border-right-style", "none");

                    e.Row.Cells[i].Style.Add("border-collapse", "collapse");
                    e.Row.Cells[i].Style.Add("cursor", "default");
                    e.Row.Cells[i].Style.Add("position", "relative");
                    e.Row.Cells[i].CssClass = "locked";

                    e.Row.Cells[i].Style.Add("top", "expression(eval(document.getElementById('" + sParent + "').scrollTop))");
                }
            }
        }
    }

    // 컬럼고정
    protected void FixHeaderCol(GridViewRowEventArgs e, string sParent, int iCol)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < iCol; i++)
            {
                if (e.Row.Cells[i].CssClass.ToLower() != "nonedisplay")
                {
                    e.Row.Cells[i].Style.Add("border-left-style", "none");
                    e.Row.Cells[i].Style.Add("border-right", "1px solid #D4D0C8");

                    e.Row.Cells[i].CssClass = "lockedh";
                    e.Row.Cells[i].Style.Add("left", "expression(eval(document.getElementById('" + sParent + "').scrollLeft))");
                }
            }
        }
        else
        {
            for (int i = 0; i < iCol; i++)
            {
                if (e.Row.Cells[i].CssClass.ToLower() != "nonedisplay")
                {
                    e.Row.Cells[i].ForeColor = CLR_GRP_FORECOLOR;
                    e.Row.Cells[i].BackColor = CLR_GRP_BACKCOLOR_1;
                    e.Row.Cells[i].Style.Add("border-left-style", "none");
                    e.Row.Cells[i].Style.Add("border-right", "1px solid #D4D0C8");

                    e.Row.Cells[i].CssClass = "lockedd";
                    e.Row.Cells[i].Style.Add("left", "expression(eval(document.getElementById('" + sParent + "').scrollLeft))");
                }
            }
        }

    }

    #endregion


    protected static void SendMail(string from
                                 , string to
                                 , string subject
                                 , string body
                                 , string url
                                 , string server)
    {
        MailMessage message             = new MailMessage(from, to);
        message.Subject                 = subject;
        message.Body                    = body;
        message.SubjectEncoding         = System.Text.Encoding.Default;
        message.BodyEncoding            = System.Text.Encoding.Default;
        message.IsBodyHtml              = true;
        SmtpClient client               = new SmtpClient(server);
        client.UseDefaultCredentials    = true;
        client.Send(message);
    }

    protected static string HttpContent(string url)
    {
        WebRequest objRequest   = HttpWebRequest.Create(url);
        StreamReader sr         = new StreamReader(objRequest.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
        string result           = sr.ReadToEnd();
        sr.Close();
        return result;
    }
    protected string GetFileText(string filePath)
    {
        StreamReader sr         = new StreamReader(Server.MapPath(filePath), System.Text.Encoding.Default);
        string result           = sr.ReadToEnd();
        sr.Close();
        return result;
    }
    public string GetRootPagePath(string filePath)
    {
        return Convert.ToString(System.Web.HttpContext.Current.Request.ApplicationPath + filePath).Replace("//", "");
    }

    public string GetCurrentFileName()
    {
        string sUrl = HttpContext.Current.Request.Url.AbsolutePath;
        sUrl = sUrl.Substring(sUrl.LastIndexOf("/") + 1).ToUpper();

        return sUrl;
    }

    #region 마스터페이지 메뉴 Show/Hidden

    protected void SetMenuControl(bool isShowTopMenu, bool isShowLeftMenu, bool isShowBottomMenu)
    {
        if (!isShowTopMenu)
        {
            HtmlTableRow trTop = this.Master.FindControl("trMenuTop") as HtmlTableRow;
            trTop.Style.Add(HtmlTextWriterStyle.Display, "none");

            ImageButton iBtnShowMenu = this.Master.FindControl("iBtnShowMenu") as ImageButton;    
        
            if(iBtnShowMenu != null)
            iBtnShowMenu.Visible = false;
        }
        else
        {
            HtmlTableRow trTop = this.Master.FindControl("trMenuTop") as HtmlTableRow;
            trTop.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

        if (!isShowLeftMenu)
        { 
            HtmlTableCell tdLeft     = this.Master.FindControl("tdMenuLeft")     as HtmlTableCell;
            HtmlTableCell tdContents = this.Master.FindControl("tdMenuContents") as HtmlTableCell;

            tdLeft.Style.Add(HtmlTextWriterStyle.Display, "none");
            tdContents.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            HtmlTableCell tdLeft     = this.Master.FindControl("tdMenuLeft")     as HtmlTableCell;
            HtmlTableCell tdContents = this.Master.FindControl("tdMenuContents") as HtmlTableCell;

            tdLeft.Style.Add(HtmlTextWriterStyle.Display, "block");
            tdContents.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

        if (!isShowBottomMenu)
        {
            HtmlTableRow trBtm = this.Master.FindControl("trMenuBottom") as HtmlTableRow;
            trBtm.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        { 
            HtmlTableRow trBtm = this.Master.FindControl("trMenuBottom") as HtmlTableRow;
            trBtm.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

        HiddenField hdfMenuStatus = this.Master.FindControl("hdfMenuStatus") as HiddenField;
        hdfMenuStatus.Value = (isShowLeftMenu) ? "O" : "C";
    }

    #endregion

    //#region ComboBox TreeView

    //private string xml_txt = "<Nodes>\r\n";

    //public void CreatePopupEstDeptTreeView(int estterm_ref_id, string fileName)
    //{
    //    CreatePopupEstDeptTreeView(estterm_ref_id, fileName, 0);
    //}

    //public void CreatePopupEstDeptTreeView(int estterm_ref_id, string fileName, int emp_ref_id)
    //{
    //    MicroBSC.Estimation.Dac.DeptInfos dept = new MicroBSC.Estimation.Dac.DeptInfos();
    //    DataSet ds = dept.GetMenuDeptInfo(estterm_ref_id, emp_ref_id);

    //    ds.Relations.Add("Menu", ds.Tables[0].Columns["EST_DEPT_REF_ID"], ds.Tables[0].Columns["UP_EST_DEPT_ID"], false);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        int i = 0;

    //        string temp = "\t";

    //        if (!ds.Tables[0].Rows[0].IsNull("UP_EST_DEPT_ID"))
    //        {
    //            CreateNode(ds.Tables[0].Rows[i], temp);
    //            PopulateSubTree(ds.Tables[0].Rows[i], temp);
    //            xml_txt += temp + "</TreeViewNode>\r\n";
    //        }
    //    }

    //    string text = xml_txt + "</Nodes>";

    //    //if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(fileName)))
    //    //    File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileName));

    //    using (StreamWriter streamWriter = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(fileName), false))
    //    {
    //        streamWriter.WriteLine(text);
    //    }

    //    //xml_txt = "";
    //}

    //private void PopulateSubTree(DataRow dbRow, string temp)
    //{
    //    for (int i = 0; i < dbRow.GetChildRows("Menu").Length; i++)
    //    {
    //        CreateNode(dbRow.GetChildRows("Menu")[i], temp + temp);
    //        PopulateSubTree(dbRow.GetChildRows("Menu")[i], temp + temp);

    //        xml_txt += temp + temp + "</TreeViewNode>\r\n";
    //    }
    //}

    //private void CreateNode(DataRow dr, string temp)
    //{
    //    xml_txt += string.Format(temp + "<TreeViewNode Value=\"{0}\" Text=\"{1}\" ImageUrl=\"{2}\" Expanded=\"true\">\r\n"
    //                                , dr["EST_DEPT_REF_ID"]
    //                                , dr["DEPT_NAME"]
    //                                , "../images/icon/0" + dr["DEPT_TYPE"] + ".gif");
    //}



    //////////////////////////////////////////////////////////////////////////////////////////////////

    //public void CreatePopupComDeptTreeView(string fileName)
    //{
    //    MicroBSC.Biz.Common.DeptInfos dept = new MicroBSC.Biz.Common.DeptInfos();
    //    DataSet ds = dept.GetMenuDeptInfo();

    //    ds.Relations.Add("Menu", ds.Tables[0].Columns["DEPT_REF_ID"], ds.Tables[0].Columns["UP_DEPT_ID"], false);

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        int i = 0;

    //        string temp = "\t";

    //        if (!ds.Tables[0].Rows[0].IsNull("UP_DEPT_ID"))
    //        {
    //            CreateComNode(ds.Tables[0].Rows[i], temp);
    //            PopulateSubComTree(ds.Tables[0].Rows[i], temp);
    //            xml_txt += temp + "</TreeViewNode>\r\n";
    //        }
    //    }

    //    string text = xml_txt + "</Nodes>";

    //    //if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(fileName)))
    //    //    File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileName));

    //    using (StreamWriter streamWriter = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(fileName), false))
    //    {
    //        streamWriter.WriteLine(text);
    //    }

    //    //xml_txt = "";
    //}

    //private void PopulateSubComTree(DataRow dbRow, string temp)
    //{
    //    for (int i = 0; i < dbRow.GetChildRows("Menu").Length; i++)
    //    {
    //        CreateComNode(dbRow.GetChildRows("Menu")[i], temp + temp);
    //        PopulateSubComTree(dbRow.GetChildRows("Menu")[i], temp + temp);

    //        xml_txt += temp + temp + "</TreeViewNode>\r\n";
    //    }
    //}

    //private void CreateComNode(DataRow dr, string temp)
    //{
    //    xml_txt += string.Format(temp + "<TreeViewNode Value=\"{0}\" Text=\"{1}\" ImageUrl=\"{2}\" Expanded=\"true\">\r\n"
    //                                , dr["DEPT_REF_ID"]
    //                                , dr["DEPT_NAME"]
    //                                , "../images/icon/0" + dr["DEPT_TYPE"] + ".gif");
    //}

    protected void SetPageLayout(PlaceHolder phdLayout)  
    {
        SetPageLayout(phdLayout, "");
    }

    protected void SetPageLayout(PlaceHolder phdLayout, string userControlFileName)
    {
        string page_layout = WebUtility.GetConfig("Page.Layout", "DEFAULT");
        string master_site = WebUtility.GetConfig("SITE", "");

        if (!userControlFileName.Equals("")) 
        {
            phdLayout.Controls.Add(LoadControl(string.Format("~/_common/lib{0}/" + userControlFileName, master_site)));
            return;
        }

        //string page_layout = System.Configuration.ConfigurationManager.AppSettings["Page.Layout"].ToString();

        Control myControl = null;

        string control_location = "";

        if (page_layout.Equals("DEFAULT"))
            control_location = string.Format("~/_common/lib{0}/MenuControl.ascx", master_site);
        else if (page_layout.Equals("TOP"))
            control_location = string.Format("~/_common/lib{0}/MenuControl.ascx", master_site);
        else if (page_layout.Equals("GROUP"))
            control_location = string.Format("~/_common/lib{0}/MenuControl_Blank.ascx", master_site);

        myControl = LoadControl(control_location);

        phdLayout.Controls.Add(myControl);
    }


    protected void SetPageLayout(PlaceHolder phdLayout,PlaceHolder phdBottom)
    {
        SetPageLayout(phdLayout, phdBottom, "");
    }


    protected void SetPageLayout(PlaceHolder phdLayout, PlaceHolder phdBottom, string userControlFileName)
    {
        string page_layout = WebUtility.GetConfig("Page.Layout", "DEFAULT");
        string master_site = WebUtility.GetConfig("SITE", "");

        Control myControl = null;
        string control_location = "";


        if (phdLayout != null)
        {
            if (!userControlFileName.Equals(""))
            {
                phdLayout.Controls.Add(LoadControl(string.Format("~/_common/lib{0}/" + userControlFileName, master_site)));
                return;
            }

            //string page_layout = System.Configuration.ConfigurationManager.AppSettings["Page.Layout"].ToString();


            if (page_layout.Equals("DEFAULT"))
                control_location = string.Format("~/_common/lib{0}/MenuControl.ascx", master_site);
            else if (page_layout.Equals("TOP"))
                control_location = string.Format("~/_common/lib{0}/MenuControl.ascx", master_site);
            else if (page_layout.Equals("GROUP"))
                control_location = string.Format("~/_common/lib{0}/MenuControl_Blank.ascx", master_site);

            myControl = LoadControl(control_location);
            phdLayout.Controls.Add(myControl);
        }

        if (phdBottom != null)
        {
            control_location = string.Format("~/_common/lib{0}/MenuControl_Bottom.ascx", master_site);
            myControl = LoadControl(control_location);
            phdBottom.Controls.Add(myControl);
        }
    }

    //#endregion

    #region ================= [ 날짜관련 함수 ]==============
    public enum DateType
    {
         StartDate
       , EndDate
       , CurrDate
    }

    public DateTime GetStartDayofCurrent()
    {
        DateTime dtFrDate = DateTime.Now.AddMonths(DateTime.Now.Month * -1 + 1);
        return dtFrDate.AddDays(DateTime.Now.Day * -1 + 1);
    }

    public DateTime GetEndDayofCurrent()
    {
        DateTime dtFrDate = DateTime.Now.AddMonths(DateTime.Now.Month * -1 + 1);
        DateTime dtToDate = dtFrDate.AddDays(DateTime.Now.Day * -1);

        return (dtToDate.AddYears(1));
    }

    protected string GetYMDFromDateTime(DateTime iDate, string iDelimiter)
    {
        string sYmd = iDate.Year.ToString() + iDelimiter + iDate.Month.ToString().PadLeft(2, '0') + iDelimiter + iDate.Day.ToString().PadLeft(2, '0');
        return sYmd;
    }

    protected string GetYMDFromDateTime(string iDate, string iDelimiter)
    {
        string sYmd = iDate.Substring(0, 4) + iDelimiter + iDate.Substring(4, 2) + iDelimiter + iDate.Substring(6, 2);
        return sYmd;
    }

    protected DateTime GetDefaultYMD(DateType dateType)
    {
        DateTime sDate = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
        if (dateType == DateType.StartDate)
        {
            return sDate;
        }

        if (dateType == DateType.EndDate)
        {
            return sDate.AddMonths(1).AddDays(-1);
        }

        if (dateType == DateType.CurrDate)
        {
            return DateTime.Now;
        }

        return DateTime.Now;
    }
    #endregion

    #region ==================================================== [ XML리소스 ]==============================================================
    protected string GetResources(string sKey, string sDefaultText)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            string sXml = string.Empty;
            sXml = System.Web.HttpContext.Current.Server.MapPath("~/Resources") + "\\TermsList.xml";
            doc.Load(sXml);
            XmlNode xNode = null;
            xNode = doc.SelectSingleNode(@"/root/data[@name='" + sKey + "']");
            return xNode.SelectSingleNode("value").InnerXml;
        }
        catch (Exception)
        {

            return sDefaultText;
        }

    }

    protected string GetText(string sKey, string sDefaultText)
    {
        return GetText(sKey, sDefaultText, "kor");
    }
    protected string GetText(string sKey, string sDefaultText, string nation_code)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            string sXml = string.Empty;
            sXml = System.Web.HttpContext.Current.Server.MapPath("~/Resources") + "\\LabelList.xml";
            doc.Load(sXml);
            XmlNode xNode = null;
            xNode = doc.SelectSingleNode(@"/root/data[@name='" + sKey.ToUpper() + "']");
            return xNode.SelectSingleNode(nation_code.ToUpper()).InnerXml;
        }
        catch (Exception ex)
        {
            string aa = ex.Message;
            return sDefaultText;
        }

    }

    protected string GetImage(string sKey, string sDefaultText)
    {
        return GetImage(sKey, sDefaultText, "kor");
    }
    protected string GetImage(string sKey, string sDefaultText, string nation_code)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            string sXml = string.Empty;
            sXml = System.Web.HttpContext.Current.Server.MapPath("~/Resources") + "\\ImageList.xml";
            doc.Load(sXml);
            XmlNode xNode = null;
            xNode = doc.SelectSingleNode(@"/root/data[@name='" + sKey.ToUpper() + "']");
            return xNode.SelectSingleNode(nation_code.ToUpper()).InnerXml;
        }
        catch (Exception ex)
        {
            string aa = ex.Message;
            return sDefaultText;
        }

    }
    #endregion

    #region 업데이트판넬 사용시 메시지 전달
    protected void MsgOnUP(UpdatePanel up, string strMSG)
    {
        strMSG = strMSG.Replace("'", "");
        string strScript = "alert('" + strMSG + "');";
        string guidKey = Guid.NewGuid().ToString();
        ScriptManager.RegisterStartupScript(up, up.GetType(), guidKey, strScript, true);
    }
    #endregion


    //#region ================= [ 암호화 관련 ]==============
    //protected string DoConverting(string iStr)
    //{
    //    byte[] plainText = new byte[16];
    //    byte[] cipherText = new byte[16];

    //    plainText = System.Text.Encoding.Unicode.GetBytes(iStr.PadRight(8, ' '));
    //    Encryption objEcy = new Encryption(Encryption.KeySize.Bits128, new byte[16]);
    //    objEcy.Cipher(plainText, cipherText);
    //    return (System.Text.Encoding.Unicode.GetString(cipherText));
    //}

    //#endregion


    

}
