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


public partial class ctl_ctl4903 : AppPageBase
{
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
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
        string sCodeID = TypeUtility.GetNumString(GetRequest("CODEID"));
        string sStepLevel = GetRequest("STEPLEVEL");

        if (sCodeID == "" || sStepLevel == "")
        {
            PageUtility.ExecuteScript("alert('수정하기 위한 필수값을 알 수 없습니다!\\n\\n다시 시도해 주십시요!');gfCloseWindow();");
        }
    }

    private void InitControlValue()
    {
        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();

        int sCodeID = GetRequestByInt("CODEID");
        string sStepLevel = GetRequest("STEPLEVEL");

        IDataReader sdr = biz.InfoThresholdStep(sCodeID, sStepLevel);

        if (sdr.Read())
        {
            int totCount = Convert.ToInt32(GetValue(sdr["MAXSEQ"]));
            GetSequenceBind(totCount);

            lblLevel.Text = sStepLevel;
            lblThresholdEName.Text = GetValue(sdr["THRESHOLD_ENAME"]);
            ddlSequence.SelectedValue = GetValue(sdr["SEQUENCE"]);
            txtPoint.Text = GetValue(sdr["POINT"]);
            chkBaseLineYn.Checked = (GetValue(sdr["BASE_LINE_YN"])=="Y") ? true : false;
        }
        else
        {
            PageUtility.ExecuteScript("alert('수정을 위한 정보를 알 수 없습니다!\\n\\n다시 시도해 주십시요!');gfCloseWindow();");
        }
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


    private void GetSequenceBind(int maxseq)
    {
        for (int i = maxseq; i >= 1; i--)
        {
            ListItem li = new ListItem();

            li.Text = i.ToString();
            li.Value = i.ToString();

            ddlSequence.Items.Add(li);
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
        
        return bRet;
    }

    private void UpdateThresholdStep()
    {
        string sErrMsg = "";
        if (!IsMandatory(out sErrMsg))
        {
            PageUtility.ExecuteScript(sErrMsg);
            return;
        }

        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();

        decimal sPoint          = Convert.ToDecimal(GetValue(txtPoint.Text));
        int sSequence           = Convert.ToInt32(GetValue(ddlSequence.SelectedValue));
        int Emp_Ref_ID          = gUserInfo.Emp_Ref_ID;
        int sCodeID             = GetRequestByInt("CODEID");
        string sStepLevel       = GetRequest("STEPLEVEL");
        string sBaseLineYn      = (chkBaseLineYn.Checked) ? "Y" : "N";

        int iRet = biz.UpdateThresholdStep(sCodeID, sStepLevel, sPoint, sSequence, sBaseLineYn, Emp_Ref_ID);

        string sScript = "";

        if (iRet > 0)
        {
            sScript += "alert('수정되었습니다');try{opener.__doPostBack('"+this.ICCB1+"', '');}catch(e){};gfCloseWindow();";
        }
        else
        {
            sScript += "alert('수정되지 않았습니다');";
        }

        PageUtility.ExecuteScript(sScript);
    }
    #endregion

    #region 서버 이벤트 처리 함수
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        UpdateThresholdStep();
    }
    #endregion
}
