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

using MicroBSC.Common;
using MicroBSC.BSC.Biz;


public partial class ctl_ctl4904 : AppPageBase
{
    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", "");
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }



    #region 페이지 초기화 함수
    private void SetAllTimeTop()
    {
    }

    private void InitControlValue()
    {
        GetThresholdLevelBind();
        GetThresholdCodeBind();
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {

    }

    private void SetPostBack()
    {

    }
    private void SetAllTimeBottom()
    {
    }
    #endregion

    #region 내부함수

    private void GetThresholdLevelBind()
    {
        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();
        DataSet ds = biz.InfoThresholdLebel();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li = new ListItem();

            li.Text  = ds.Tables[0].Rows[i]["ETC_CODE"].ToString();
            li.Value = ds.Tables[0].Rows[i]["ETC_CODE"].ToString();

            ddlThresholdLevel.Items.Add(li);
        }

        ListItem li2 = new ListItem("선 택", "");
        ddlThresholdLevel.Items.Insert(0, li2);
    }


    private void GetThresholdCodeBind()
    {
        Biz_Bsc_Threshold_Code biz = new Biz_Bsc_Threshold_Code();
        DataSet ds = biz.GetThresholdCodeList("");

        for (int i = 0 ; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li = new ListItem();

            li.Text  = ds.Tables[0].Rows[i]["THRESHOLD_ENAME"].ToString();
            li.Value = ds.Tables[0].Rows[i]["THRESHOLD_REF_ID"].ToString();

            ddlThresholdCode.Items.Add(li);
        }
    }

    /// <summary>
    /// IsMandatory
    ///     : 필수값 확인
    /// </summary>
    /// <returns></returns>
    private bool IsMandatory(out string sErrMsg)
    {
        bool bRet = true;
        sErrMsg = "";

        if (GetValue(ddlThresholdLevel.SelectedValue) == "")
        {
            sErrMsg = string.Format(
                                    "alert('{0}');"
                                  + "gfSetFocus('{1}')"
                                  , "추가할 [Threshold등급]을 선택하셔야 합니다."
                                  , "ddlThresholdLevel"
                                   );
            bRet = false;
        }
        else if (!PageUtility.IsAllNumber(GetValue(txtPoint.Text)))
        {
            sErrMsg = string.Format(
                                    "alert('{0}');"
                                  + "gfSetFocus('{1}')"
                                  , "[Point]는 숫자만 입력하십시오!"
                                  , "txtPoint"
                                   );
            bRet = false;
        }

        return bRet;
    }

    private void AddThresholdCode()
    {

        string sErrMsg = "";
        if (!IsMandatory(out sErrMsg))
        {
            PageUtility.ExecuteScript(sErrMsg);
            return;
        }

        int sThreshold_Ref_ID   = Convert.ToInt32(ddlThresholdCode.SelectedValue);
        string sThreshold_Level = ddlThresholdLevel.SelectedValue;
        string sbase_line_yn    = (chkBaseLineYn.Checked) ? "Y" : "N";

        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();

        int Emp_Ref_ID = gUserInfo.Emp_Ref_ID;

        decimal sPoint = (txtPoint.Text.Equals("")) ? 0 : Convert.ToDecimal(txtPoint.Text);


        int iRet = biz.InsertThresholdStepNewLevel(sThreshold_Ref_ID, sThreshold_Level, sPoint, sbase_line_yn, EMP_REF_ID);

        string sScript = "";

        if (iRet == -1)
        {
            sScript += "alert('이미 같은이름으로 등록된 평가단계가 있습니다\\n\\n확인 후 다시 처리해주십시오')";
        }
        else
        {
            sScript += string.Format("alert('[{0}]건이 등록되었습니다!');", iRet);
            sScript += "try{opener.__doPostBack('"+this.ICCB2+"', '');}catch(e){};gfCloseWindow();";
        }

        PageUtility.ExecuteScript(sScript);
    }

    #endregion

    #region 서버 이벤트 처리 함수
    protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        AddThresholdCode();
    }
    #endregion

}
