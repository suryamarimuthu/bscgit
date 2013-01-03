using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MicroBSC.Data.Oracle;
using MicroBSC.Biz.EIS;
using System.Drawing;
using MicroBSC.RolesBasedAthentication;
using Dundas.Charting.WebControl;

using MicroBSC.Common;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class EISPageBase : System.Web.UI.Page
{
    private int _emp_ref_id;
    private string _role_admin;
    private string _role_officer;
    private string _role_champ;
    private string _role_team;
    private string _role_emp;
    private string _role_ceo;
    private string _role_est_emp;

    protected int EMP_REF_ID { get { return _emp_ref_id; } set { _emp_ref_id = value; } }
    protected string ROLE_ADMIN { get { return _role_admin; } }
    protected string ROLE_OFFICER { get { return _role_officer; } }
    protected string ROLE_CHAMPION { get { return _role_champ; } }
    protected string ROLE_TEAM_MANAGER { get { return _role_team; } }
    protected string ROLE_EMPLOYEE { get { return _role_emp; } }
    protected string ROLE_CEO { get { return _role_ceo; } }
    protected string ROLE_EST_EMPLOYEE { get { return _role_est_emp; } }

    public SiteIdentity gUserInfo
    {
        get
        {
            if (Context.User.Identity.IsAuthenticated)
                return (SiteIdentity)Context.User.Identity;

            return null;
        }
    }

    private string _userId;
    protected DBAgent gDbAgent = null;
    
    //랜덤필드
    private Random _clsRandom;

    protected enum gEN_GRID_COLOR : int
    {
        GROUP1  = 0,
        GROUP2  = 1,
        SUBTOTAL_NAME1 = 2,
        SUBTOTAL_NAME2 = 3,
        SUBTOTAL_DATA1 = 4,
        SUBTOTAL_DATA2 = 5
    }

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
                                        {0x5a, 0x7d, 0xde},
                                        {0xff, 0x8a, 0x00},
                                        {0x00, 0xC4, 0xCB},
                                        {0x38, 0xd9, 0x38},
                                        {0x00, 0x33, 0xc2},
                                        {0x00, 0xc4, 0xcb},
                                        {0x35, 0xa5, 0x72},
                                        {0xd7, 0xa8, 0x71},
                                        {0xc6, 0xc5, 0xe5},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };
   
    protected int[,] LINE_COLOR = new int[,]
                                   {
                                        {0x7A, 0x9D, 0xFE},
                                        {0xFF, 0xAA, 0x20},
                                        {0x20, 0xE4, 0xEB},
                                        {0x38, 0xd9, 0x38},
                                        {0xe4, 0xe4, 0xe4},
                                        {0x00, 0xc4, 0xcb},
                                        {0x35, 0xa5, 0x72},
                                        {0xd7, 0xa8, 0x71},
                                        {0xc6, 0xc5, 0xe5},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };

    protected int[,] MARKER_COLOR = new int[,]
                                   {
                                        {0x7A, 0x9D, 0xFE},
                                        {0xFF, 0xAA, 0x20},
                                        {0x20, 0xE4, 0xEB},
                                        {0x38, 0xd9, 0x38},
                                        {0xe4, 0xe4, 0xe4},
                                        {0x00, 0xc4, 0xcb},
                                        {0x35, 0xa5, 0x72},
                                        {0xd7, 0xa8, 0x71},
                                        {0xc6, 0xc5, 0xe5},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };

    protected int[,] MARKER_BORDER_COLOR = new int[,]
                                   {
                                        {0x4A, 0x58, 0x7E},
                                        {0xD7, 0x41, 0x01},
                                        {0x00, 0xC4, 0xCB},
                                        {0x38, 0xd9, 0x38},
                                        {0xe4, 0xe4, 0xe4},
                                        {0x00, 0xc4, 0xcb},
                                        {0x35, 0xa5, 0x72},
                                        {0xd7, 0xa8, 0x71},
                                        {0xc6, 0xc5, 0xe5},
                                        {0xe9, 0x01, 0x6e},
                                        {0x8e, 0xa5, 0x11},
                                        {0x87, 0x69, 0x8f},
                                        {0x6b, 0x91, 0x8a},
                                        {0xff, 0x66, 0x66},
                                        {0x00, 0x33, 0xc2},
                                        {0xff, 0xc4, 0xec}
                                   };

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
    protected MarkerStyle GetMarkerStyle(int i)
    {
        int iCheck = i % 9;

        switch (iCheck)
        {
            case 0: return MarkerStyle.Circle;
            case 1: return MarkerStyle.Diamond;
            case 2: return MarkerStyle.Triangle;
            case 3: return MarkerStyle.Square;
            case 4: return MarkerStyle.Star10;
            case 5: return MarkerStyle.Star4;
            case 6: return MarkerStyle.Star5;
            case 7: return MarkerStyle.Star6;
            case 8: return MarkerStyle.Cross;
            default: return MarkerStyle.None;
        }
    }

    // 챠트 마커컬러 리턴
    protected Color GetMarkerColor(int i)
    {
        int iCheck = i % 16;

        return Color.FromArgb(MARKER_COLOR[iCheck, 0], CHART_COLOR[iCheck, 1], CHART_COLOR[iCheck, 2]);
    }

    // 챠트 마커보더컬러 리턴
    protected Color GetMarkerBorderColor(int i)
    {
        int iCheck = i % 16;

        return Color.FromArgb(MARKER_BORDER_COLOR[iCheck, 0], MARKER_BORDER_COLOR[iCheck, 1], MARKER_BORDER_COLOR[iCheck, 2]);
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
        gDbAgent= new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        
        _clsRandom = new Random(unchecked((int)DateTime.Now.Ticks));

        if (Context.User.Identity.IsAuthenticated)
        {
            _userId = User.Identity.Name;
        }
        else
        {
            _userId = "Anonymous";
        }

        if (Context.User.Identity.IsAuthenticated)
        {

            RoleBases role = new RoleBases();

            _emp_ref_id     = ((SiteIdentity)Context.User.Identity).Emp_Ref_ID;
            _role_admin     = role.ROLE_ADMIN;
            _role_officer   = role.ROLE_OFFICER;
            _role_champ     = role.ROLE_CHAMPION;
            _role_team      = role.ROLE_TEAM_MANAGER;
            _role_emp       = role.ROLE_EMPLOYEE;
            _role_ceo       = role.ROLE_CEO;
            _role_est_emp   = role.ROLE_EST_EMPLOYEE;
        }
        else
        {
            _emp_ref_id = 0;
        }

        Response.AddHeader("P3P", "CP='CAO PSA CONi OTR OUR DEM ONL'");
    }
    protected void SetAreaDropDownList(System.Web.UI.WebControls.DropDownList ddList)
    {
        UserDatas userData = new UserDatas();
        DataTable dt = userData.GetArea();
        ddList.DataSource = dt;
        ddList.DataTextField = "VALUE";
        ddList.DataValueField = "KEY";
        ddList.DataBind();

        ddList.Items.Insert(0, new ListItem("전체", "--"));
    }
    protected void SetDateDropDownList(System.Web.UI.WebControls.DropDownList ddlYear, System.Web.UI.WebControls.DropDownList ddlMonth)
    {
        UserDatas userData = new UserDatas();
        DataTable dt = userData.GetYear();
        DataView dv = dt.DefaultView;
        dv.Sort = "KEY DESC";
        ddlYear.DataSource = dv;
        ddlYear.DataTextField = "VALUE";
        ddlYear.DataValueField = "KEY";
        ddlYear.DataBind();

        dt = userData.GetMonth();
        ddlMonth.DataSource = dt;
        ddlMonth.DataTextField = "VALUE";
        ddlMonth.DataValueField = "KEY";
        ddlMonth.DataBind();
    }
    protected DataSet GetDataSet(string query) 
    {
        DBAgent dbAgent = new DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB_Oracle"].ConnectionString);
        DataSet ds = dbAgent.FillDataSet(query, "Data");
        return ds;
    }

    /// <summary>
    /// GetDateDiff
    ///     : 두 날짜사이의 일자를 문자배열로 반환
    /// 작성자 : 강신규    
    /// </summary>
    /// <param name="asDateS">시작일 / 시작월</param>
    /// <param name="asDateE">종료일 / 종료월</param>
    /// <returns></returns>
    protected string[] GetDateDiff(string asDateS, string asDateE)
    {
        return GetDateDiff(asDateS, asDateE, false);
    }

    protected string[] GetDateDiff(string asDateS, string asDateE, bool IsMonth)
    {
        string[] lsaRet;
        DateTime ldtTmp, ldtS, ldtE;

        if (IsMonth)
        {
            ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                Convert.ToInt32(asDateS.Substring(4, 2)),
                                1);
            ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                Convert.ToInt32(asDateE.Substring(4, 2)),
                                1);

            ldtE = ldtE.AddMonths(1);
        }
        else
        {
            ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                Convert.ToInt32(asDateS.Substring(4, 2)),
                                Convert.ToInt32(asDateS.Substring(6, 2)));
            ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                Convert.ToInt32(asDateE.Substring(4, 2)),
                                Convert.ToInt32(asDateE.Substring(6, 2)));
        }

        ldtTmp = ldtS;
        lsaRet = new string[(ldtE.Subtract(ldtS).Days) + 1];

        for (int i = 0; i < ((ldtE.Subtract(ldtS).Days) + 1); i++)
        {
            lsaRet[i] = ldtTmp.ToString("yyyyMMdd");

            ldtTmp = ldtS.AddDays(i + 1);
        }

        return lsaRet;
    }

    protected string[] GetMonthDiff(string asDateS, string asDateE, string asDateType)
    {
        string[] lsaRet;
        int      liCheck = 0;
        DateTime ldtTmp, ldtS = new DateTime(), ldtE = new DateTime();
        
        switch (asDateType.ToUpper())
        {
            case "D" :
                ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                    Convert.ToInt32(asDateS.Substring(4, 2)),
                                    Convert.ToInt32(asDateS.Substring(6, 2)));
                ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                    Convert.ToInt32(asDateE.Substring(4, 2)),
                                    Convert.ToInt32(asDateE.Substring(6, 2)));

                break;
            case "M" :
                ldtS = new DateTime(Convert.ToInt32(asDateS.Substring(0, 4)),
                                    Convert.ToInt32(asDateS.Substring(4, 2)),
                                    1);
                ldtE = new DateTime(Convert.ToInt32(asDateE.Substring(0, 4)),
                                    Convert.ToInt32(asDateE.Substring(4, 2)),
                                    1);

                ldtE = ldtE.AddMonths(1);
                break;
            case "Y" :
                ldtS = new DateTime(Convert.ToInt32(asDateS),
                                    1,
                                    1);
                ldtE = new DateTime(Convert.ToInt32(asDateE),
                                    12,
                                    1);
                break;
        }

        liCheck = ((ldtE.Year-ldtS.Year) * 12) + (ldtE.Month-ldtS.Month);

        if (liCheck < 0)
        {
            return new string[0];
        }

        ldtTmp = ldtS;
        lsaRet = new string[liCheck];
        for (int i = 0; i < (liCheck); i++)
        {
            lsaRet[i] = ldtTmp.ToString("yyyyMM");

            ldtTmp = ldtS.AddMonths(i + 1);
        }

        return lsaRet;
    }

    /// <summary>
    /// 서비스명	: FindByValueDropDownList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Value 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="sValue">Value 값입니다.</param>
    protected void FindByValueDropDownList(DropDownList ddlReceive, string sValue)
    {
        ddlReceive.SelectedIndex =
            ddlReceive.Items.IndexOf(ddlReceive.Items.FindByValue(sValue));

        //객체를 해제합니다
        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명    : GetByValueDropDownList 메서드.
    /// 서비스내용  : DropDownList의 선택된 Value를 리턴합니다.
    protected string GetByValueDropDownList(DropDownList ddlSearch)
    {
        if (ddlSearch.SelectedIndex < 0)
            return "";

        return ddlSearch.SelectedItem.Value.ToString().Trim();
    }

    protected string GetByTextDropDownList(DropDownList ddlSearch)
    {
        if (ddlSearch.SelectedIndex < 0)
            return "";

        return ddlSearch.SelectedItem.Text.ToString().Trim();
    }

    /// <summary>
    /// 서비스명	: FindByValueDropDownList 오버로딩 메서드.
    /// 서비스내용	: DataRow 타입의 Value 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="drReceive">DataRow 객체입니다.</param>
    protected void FindByValueDropDownList(DropDownList ddlReceive, DataRow drReceive)
    {
        ddlReceive.SelectedIndex =
            ddlReceive.Items.IndexOf(ddlReceive.Items.FindByValue(drReceive[0].ToString()));

        //객체를 해제합니다
        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명	: FindByTextDropDownList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Text 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="sText">Text 값입니다.</param>
    protected void FindByTextDropDownList(DropDownList ddlReceive, string sText)
    {
        ddlReceive.SelectedIndex =
            ddlReceive.Items.IndexOf(ddlReceive.Items.FindByText(sText));

        //객체를 해제합니다
        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명	: FindByTextDropDownList 오버로딩 메서드.
    /// 서비스내용	: DataRow 타입의 Text 값을 디롭다운리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="ddlReceive">출력할 DropDownList 객체입니다.</param>
    /// <param name="drReceive">DataRow 객체입니다.</param>
    protected void FindByTextDropDownList(DropDownList ddlReceive, DataRow drReceive)
    {
        ddlReceive.SelectedIndex =
            ddlReceive.Items.IndexOf(ddlReceive.Items.FindByText(drReceive[0].ToString()));

        //객체를 해제합니다
        if (ddlReceive != null)
        {
            ddlReceive.Dispose();
            ddlReceive = null;
        }
    }

    /// <summary>
    /// 서비스명	: FindByValueRadioButtonList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Value 값을 라디오버튼리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="rbtnlReceive">출력할 RadioButtonList 객체입니다.</param>
    /// <param name="sValue">Value 값입니다.</param>
    protected void FindByValueRadioButtonList(RadioButtonList rbtnlReceive, string sValue)
    {
        rbtnlReceive.SelectedIndex =
            rbtnlReceive.Items.IndexOf(rbtnlReceive.Items.FindByValue(sValue));

        //객체를 해제합니다
        if (rbtnlReceive != null)
        {
            rbtnlReceive.Dispose();
            rbtnlReceive = null;
        }
    }

    protected void SetHalfYearDropDownList(System.Web.UI.WebControls.DropDownList ddlYear, System.Web.UI.WebControls.DropDownList ddlHalf)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("KEY", typeof(string));
        dt.Columns.Add("VALUE", typeof(string));

        for (int i = 2001; i <= 2008; i++)
        {
            dr = dt.NewRow();
            dr["KEY"] = i.ToString();
            dr["VALUE"] = i.ToString();
            dt.Rows.Add(dr);
        }

        DataView dv = dt.DefaultView;
        dv.Sort = "KEY DESC";
        ddlYear.DataSource = dv;
        ddlYear.DataTextField = "VALUE";
        ddlYear.DataValueField = "KEY";
        ddlYear.DataBind();

        DataTable dtTable = new DataTable();
        DataRow dr2;
        dtTable.Columns.Add("KEY", typeof(string));
        dtTable.Columns.Add("VALUE", typeof(string));
        dr2 = dtTable.NewRow();
        dr2["KEY"] = ".상반기";
        dr2["VALUE"] = "상반기";
        dtTable.Rows.Add(dr2);
        dr2 = dtTable.NewRow();
        dr2["KEY"] = ".하반기";
        dr2["VALUE"] = "하반기";
        dtTable.Rows.Add(dr2);

        DataView dv2 = dtTable.DefaultView;
        dv2.Sort = "KEY ASC";
        ddlHalf.DataSource = dv2;
        ddlHalf.DataTextField = "VALUE";
        ddlHalf.DataValueField = "KEY";
        ddlHalf.DataBind();
        
    }
    


    /// <summary>
    /// 서비스명    : GetByValueRadioButtonList 메서드.
    /// 서비스내용  : 라디오버튼리스트의 선택된 Value를 리턴합니다.
    /// </summary>
    /// <param name="rbtnlSearch"></param>
    /// <returns></returns>
    protected string GetByValueRadioButtonList(RadioButtonList rbtnlSearch)
    {
        if (rbtnlSearch.SelectedIndex < 0)
            return "";

        return rbtnlSearch.SelectedItem.Value.ToString().Trim();
    }

    /// <summary>
    /// 서비스명	: FindByTextRadioButtonList 오버로딩 메서드.
    /// 서비스내용	: string 타입의 Text 값을 라디오버튼리스트의 디폴트아이템으로 출력합니다.
    /// </summary>
    /// <param name="rbtnlReceive">출력할 RadioButtonList 객체입니다.</param>
    /// <param name="sText">Text 값입니다.</param>
    protected void FindByTextRadioButtonList(RadioButtonList rbtnlReceive, string sText)
    {
        rbtnlReceive.SelectedIndex =
            rbtnlReceive.Items.IndexOf(rbtnlReceive.Items.FindByText(sText));

        //객체를 해제합니다
        if (rbtnlReceive != null)
        {
            rbtnlReceive.Dispose();
            rbtnlReceive = null;
        }
    }

    #region 자바스크립트 실행 메서드

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩1)
    /// 서비스내용	: 페이지 로딩 후 자바스크립트 Alert 메세지를 출력합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    protected void AlertMessage(string sMessage)
    {
        AlertMessage(sMessage, false, false, "");
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩1)
    /// 서비스내용	: 자바스크립트 Alert 메세지를 출력합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    protected void AlertMessage(string sMessage, bool bIsBlank)
    {
        AlertMessage(sMessage, bIsBlank, false, "");
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩2)
    /// 서비스내용	: 자바스크립트 Alert 메세지출력, 창닫기유무, Alert 창 백그라운드에 공백출력유무등의 기능을
    ///				  제공합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="bIsClose">메시지 출력후 창닫기 여부를 결정합니다.</param>
    protected void AlertMessage(string sMessage, bool bIsBlank, bool bIsClose)
    {
        AlertMessage(sMessage, bIsBlank, bIsClose, "");
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩3)
    /// 서비스내용	: 자바스크립트 Alert 메세지를 출력후 페이지 이동을 수행합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="sRedirectUrl">메시지 출력후 페이지 이동할 Url 입니다.</param>
    protected void AlertMessage(string sMessage, bool bIsBlank, string sRedirectUrl)
    {
        string sScriptCommand = "document.location.href = '" + sRedirectUrl + "';";
        AlertMessage(sMessage, bIsBlank, false, sScriptCommand);
    }

    /// <summary>
    /// 서비스명	: AlertMessage 메서드(오버로딩4)
    /// 서비스내용	: 자바스크립트 Alert 메세지출력, 창닫기유무, Alert 창 백그라운드에 공백출력유무,
    ///				  기타 자바스크립트 소스추가 유뮤를 자유롭게 선택할 수 있습니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="bIsClose">메시지 출력후 창닫기 여부를 결정합니다.</param>
    /// <param name="sScriptCommand">메시지 출력후 추가 실행할 자바스크립트 소스입니다.</param>
    protected void AlertMessage(string sMessage, bool bIsBlank, bool bIsClose, string sScriptCommand)
    {
        string msMSG = "";
        msMSG += "alert('" + sMessage.Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r") + "');";
        msMSG += sScriptCommand;
        msMSG += bIsClose ? "opener = self; window.close();" : "";

        //자바스크립트 실행
        ExecuteScript(msMSG, bIsBlank);
    }

    /// <summary>
    /// 서비스명	: AlertMsgFocus 메서드
    /// 서비스내용	: 페이지 로딩 후 자바스크립트 Alert 메세지를 출력합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="sConFocus">Focus 이동할 컨트롤지정</param>
    protected void AlertMsgFocus(string sMessage, string sConFocus)
    {
        AlertMsgFocus(sMessage, false, false, sConFocus);
    }

    /// <summary>
    /// 서비스명	: AlertMsgFocus
    /// 서비스내용	: 자바스크립트 Alert 메세지출력, 창닫기유무, Alert 창 백그라운드에 공백출력유무,
    ///				  이동할 포커스를 지정합니다.
    /// </summary>
    /// <param name="sMessage">Alert에 출력할 메시지입니다.</param>
    /// <param name="bIsBlank">Alert 창 백그라운드에 공백을 출력할지를 결정합니다.</param>
    /// <param name="bIsClose">메시지 출력후 창닫기 여부를 결정합니다.</param>
    /// <param name="sConFocus">메시지 출력후 이동할  포커스 지정합니다.</param>
    protected void AlertMsgFocus(string sMessage, bool bIsBlank, bool bIsClose, string sConFocus)
    {
        string msMSG = "";
        msMSG += "alert('" + sMessage.Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "\\r") + "');";
        msMSG += "try {eval(document.forms[0]." + sConFocus + ".select());} catch(e){}";
        msMSG += "try {eval(document.forms[0]." + sConFocus + ".focus());} catch(e){}";
        msMSG += bIsClose ? "self.close();" : "";

        //자바스크립트 실행
        ExecuteScript(msMSG, bIsBlank);
    }

    /// <summary>
    /// 서비스명	: ExecuteScript 메서드.
    /// 서비스내용	: 페이지 로딩 후 자바스크립트 명령문을 처리합니다.
    /// </summary>
    /// <param name="sScript">실행할 클라이언트 스크립트 문자열입니다.</param>
    protected void ExecuteScript(string sScript)
    {
        Type csType = this.GetType();

        sScript = "<script type=text/javascript>" + sScript + "</script>";
        //현재시각과 랜덤값 더한 것을 sriptID 의 key 로 설정합니다.
        string sScriptID = DateTime.Now.ToString("yyyyMMddhhmmssfff") + _clsRandom.Next().ToString();

        //if (!_clsPage.IsClientScriptBlockRegistered(sScriptID))
        //    _clsPage.RegisterStartupScript(sScriptID, sScript);

        if (!this.ClientScript.IsClientScriptBlockRegistered(csType, sScriptID))
            this.ClientScript.RegisterStartupScript(csType, sScriptID, sScript);

    }

    /// <summary>
    /// 서비스명	: ExecuteScript 메서드.
    /// 서비스내용	: 자바스크립트 명령문을 처리합니다.
    /// </summary>
    /// <param name="sScript">실행할 클라이언트 스크립트 문자열입니다.</param>
    /// <param name="bIsRunBeforePageLoad">페이지로드전에 실행하려면 true 로 설정합니다.</param>
    protected void ExecuteScript(string sScript, bool bIsRunBeforePageLoad)
    {
        Type csType = this.GetType();

        sScript = "<script type=text/javascript>" + sScript + "</script>";
        //페이지로딩 전에 수행합니다.
        if (bIsRunBeforePageLoad)
        {
            HttpContext.Current.Response.Write(sScript);
        }
        //페이지로딩후에 수행합니다.
        else
        {
            //현재시각과 랜덤값 더한 것을 sriptID 의 key 로 설정합니다.
            string sScriptID = DateTime.Now.ToString("yyyyMMddhhmmssfff") + _clsRandom.Next().ToString();
            //if (!_clsPage.IsClientScriptBlockRegistered(sScriptID))
            //    _clsPage.RegisterStartupScript(sScriptID, sScript);


            if (!this.ClientScript.IsClientScriptBlockRegistered(csType, sScriptID))
                this.ClientScript.RegisterStartupScript(csType, sScriptID, sScript);
        }
    }
    #endregion

    /// <summary>
    /// 서비스명    : GetSplit
    /// 서비스내용  : 구분자로 분리된 2차원배열 리턴
    /// 작성자      : 강신규 
    /// </summary>
    /// <param name="sStr"></param>
    /// <param name="iTerm"></param>
    /// <param name="cSep"></param>
    /// <returns></returns>

    public string[,] GetSplit(string sStr)
    {
        return GetSplit(sStr, 1);
    }

    public string[,] GetSplit(string sStr, int iTerm)
    {
        return GetSplit(sStr, iTerm, ';');
    }

    public string[,] GetSplit(string sStr, int iTerm, char cSep)
    {
        if (sStr == "")
            return new string[0, 0];

        if (sStr.Substring(sStr.Length - 1, 1) == cSep.ToString())
            sStr = sStr.Substring(0, sStr.Length - 1);

        string[] saTemp = sStr.Split(cSep);
        string[,] saRet = new string[saTemp.Length / iTerm, iTerm];

        int iIndex = 0;

        for (int i = 0; i < saTemp.Length; i += iTerm)
        {
            if ((i + (iTerm - 1)) < saTemp.Length)
            {
                for (int j = 0; j < iTerm; j++)
                {
                    saRet[iIndex, j] = saTemp[i + j];
                }

                iIndex++;
            }
        }

        return saRet;
    }

    protected void SetPageLayout(PlaceHolder phdLayout)
    {
        SetPageLayout(phdLayout, "");
    }

    protected void SetPageLayout(PlaceHolder phdLayout, string userControlFileName)
    {

        if (!userControlFileName.Equals(""))
        {
            phdLayout.Controls.Add(LoadControl("~/_common/lib/" + userControlFileName));
            return;
        }

        string page_layout = System.Configuration.ConfigurationManager.AppSettings["Page.Layout"].ToString();

        Control myControl = null;

		if (page_layout.Equals("DEFAULT"))
            myControl = LoadControl("~/_common/lib/MenuControl.ascx");
        else if (page_layout.Equals("TOP"))
            myControl = LoadControl("~/_common/lib/MenuControl.ascx");
        else if (page_layout.Equals("GROUP"))
            myControl = LoadControl("~/_common/lib/MenuControl_Blank.ascx");

        phdLayout.Controls.Add(myControl);
    }

}