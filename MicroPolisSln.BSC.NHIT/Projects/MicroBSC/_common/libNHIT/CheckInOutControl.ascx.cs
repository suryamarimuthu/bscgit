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

using MicroBSC.Biz.Common;

public partial class _common_libNHIT_CheckInOutControl : AppUserControlBase
{
    private Control[] _control  = null;
    private string FILENAME     = "";
    private string IS_CHECK_IN_OUT_USE = ConfigurationManager.AppSettings["COM.CHECK.IN.OUT.USE"].ToString().ToUpper();
    
    public bool IsEnabled
    {
        get
        {
            if (ViewState["IS_ENABLED"] == null)
            {
                ViewState["IS_ENABLED"] = false;
            }

            return (bool)ViewState["IS_ENABLED"];
        }
        set
        {
            ViewState["IS_ENABLED"] = value;
        }
    }

    public Control[] ButtonArr
    {
        get
        {
            return _control;
        }
        set
        {
            if (_control == value)
                return;
            _control = value;
        }
    }

    public bool CheckInButtonVisible 
    {
        get 
        {
            if (ViewState["CHECK_IN_VISIBLE"] == null)
            {
                ViewState["CHECK_IN_VISIBLE"]   = true;
            }

            return (bool)ViewState["CHECK_IN_VISIBLE"];
        }
        set
        {
        	ViewState["CHECK_IN_VISIBLE"]       = value;
        }
    }

    public bool IsCheckingOut
    {
        get
        {
            if (ViewState["IS_CHECKING_OUT"] == null)
            {
                ViewState["IS_CHECKING_OUT"] = false;
            }

            return (bool)ViewState["IS_CHECKING_OUT"];
        }
        set
        {
            ViewState["IS_CHECKING_OUT"] = value;
        }
    }

    private void ContolVisibleStatus(bool isContorlVisible) 
    {
        if (_control == null)
            return;

        for (int i = 0; i < _control.Length; i++) 
        {
            _control[i].Visible = isContorlVisible;
        }
    }
    private void CheckInButtonVisibleTrue(bool isTrue) 
    {
        if (isTrue == true)
        {
            iBtnCheckIn.Visible     = true;
            iBtnCheckOut.Visible    = false;
            imgCheckIn.Visible      = true;
            imgCheckOut.Visible     = false;
        }
        else
        {
            iBtnCheckIn.Visible     = false;
            iBtnCheckOut.Visible    = true;
            imgCheckIn.Visible      = false;
            imgCheckOut.Visible     = true;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        FILENAME = HttpContext.Current.Request.Url.AbsolutePath.Substring(
                                            HttpContext.Current.Request.Url.AbsolutePath.LastIndexOf("/") + 1).ToLower();

        if (IsEnabled && IS_CHECK_IN_OUT_USE.Equals("TRUE"))
        {
            iBtnCheckIn.ImageUrl    = Request.ApplicationPath + "/images/btn/b_s_001.gif";
            iBtnCheckOut.ImageUrl   = Request.ApplicationPath + "/images/btn/b_s_002.gif";
            imgCheckIn.ImageUrl     = Request.ApplicationPath + "/images/icon/i_check_out.gif";
            imgCheckOut.ImageUrl    = Request.ApplicationPath + "/images/icon/i_check_in.gif";

            iBtnCheckIn.Attributes.Add("onclick", "return confirm('체크인 하시겠습니까?');");
            iBtnCheckOut.Attributes.Add("onclick", "return confirm('체크아웃 하시겠습니까?');");

            if (!Page.IsPostBack)
            {
                //Response.Write(FILENAME);
                StatusImageButton();
            }
        }
        else 
        {
            iBtnCheckIn.Visible     = false;
            iBtnCheckOut.Visible    = false;
            imgCheckIn.Visible      = false;
            imgCheckOut.Visible     = false;
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        CheckInButtonVisibleTrue(CheckInButtonVisible);

        // 버튼 클릭 순서에 따라 종속된 버튼 Visible true, false 가 변하기 때문에
        // 체크아웃 상태에서만 모든 버튼를 숨긴다.
        if (!CheckInButtonVisible)
            ContolVisibleStatus(CheckInButtonVisible);

        if (!IsEnabled || IsCheckingOut)
        {
            iBtnCheckIn.Visible     = false;
            iBtnCheckOut.Visible    = false;
            imgCheckIn.Visible      = false;
            imgCheckOut.Visible     = false;
        }
    }
    protected void iBtnCheckIn_Click(object sender, ImageClickEventArgs e)
    {
        CheckInButtonVisible = false;
        SetCheckIn();
        StatusImageButton();
        ContolVisibleStatus(CheckInButtonVisible);
    }
    protected void iBtnCheckOut_Click(object sender, ImageClickEventArgs e)
    {
        CheckInButtonVisible = true;
        SetCheckOut();
        StatusImageButton();

        // 체크아웃을 누르게 되면 모든 버튼을 보여주는 것이 아니라 자신의 페이지를 다시 호출한다.
        //Response.Redirect(FILENAME);
        ContolVisibleStatus(CheckInButtonVisible);
    }
    private void SetCheckIn() 
    {
        CheckInOutInfos checkInOut = new CheckInOutInfos();
        checkInOut.AddCheckinoutinfo(FILENAME, HttpContext.Current.Request.Url.ToString(), gUserInfo.Emp_Ref_ID, 0);
    }
    private void SetCheckOut()
    {
        CheckInOutInfos checkInOut = new CheckInOutInfos();
        checkInOut.AddCheckinoutinfo(FILENAME, HttpContext.Current.Request.Url.ToString(), gUserInfo.Emp_Ref_ID, 1);
    }
    private void StatusImageButton() 
    {
        CheckInOutInfos checkInOut  = new CheckInOutInfos();
        DataTable dt                = checkInOut.GetCheckinoutinfo(0, FILENAME, 0).Tables[0];

        if (dt.Rows.Count > 0)
        {
            // 이전에 체크아웃을 한 경우가 있다면
            if (dt.Rows[0]["ACCESS_EMP_ID"].ToString().Equals(gUserInfo.Emp_Ref_ID.ToString()))
            {
                // 체크인 상태이면
                if (int.Parse(dt.Rows[0]["IS_CHECK_OUT"].ToString()) == 0)
                {
                    // 컨트롤을 숨긴다.
                    CheckInButtonVisible    = false;

                    if (dt.Rows[0]["RECENT_CHECK_OUT_DATE"] != DBNull.Value)
                        lblMsg.Text = "Recent Check-Out Date : " + ((DateTime)dt.Rows[0]["RECENT_CHECK_OUT_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                    
                }
                else // 체크아웃이면
                {
                    // 컨트롤을 보여준다.
                    CheckInButtonVisible    = true;

                    if (dt.Rows[0]["RECENT_CHECK_IN_DATE"] != DBNull.Value)
                        lblMsg.Text = "Recent Check-In Date : " + ((DateTime)dt.Rows[0]["RECENT_CHECK_IN_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            else 
            {
                // 이전에 체크아웃을 한적이 없다면
                // 체크인 상태이면
                if (int.Parse(dt.Rows[0]["IS_CHECK_OUT"].ToString()) == 0)
                {
                    // 컨트롤을 숨긴다.
                    CheckInButtonVisible    = false;

                    if (dt.Rows[0]["RECENT_CHECK_OUT_DATE"] != DBNull.Value)
                        lblMsg.Text = "Recent Check-Out Date : " + ((DateTime)dt.Rows[0]["RECENT_CHECK_OUT_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    CheckInButtonVisible    = false;
                    iBtnCheckIn.Visible     = false;
                    iBtnCheckOut.Visible    = false;
                    imgCheckIn.Visible      = false;
                    imgCheckOut.Visible     = false;
                    IsCheckingOut           = true;
                    ContolVisibleStatus(false);
                    // 컨트롤을 보여준다.
                    lblMsg.Text = dt.Rows[0]["ACCESS_EMP_ID"].ToString() + " 사용자가 체크아웃 중입니다.";
                }
            }
        }
        else 
        {
            // 우선을 숨긴다.
            CheckInButtonVisible = false;
            ContolVisibleStatus(false);
        }
    }
}
