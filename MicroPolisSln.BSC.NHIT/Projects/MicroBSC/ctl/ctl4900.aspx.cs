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
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class ctl_ctl4900 : AppPageBase
{
    // 디폴트 측정단계

    // Control for Call Back
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.lBtnReload.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    private const string CS_DEFAULT_TYPE = "LV4";
    protected int COD_ESEQ_COUNT = 0;
    
    #region 페이지 초기화 함수

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

    private void SetAllTimeTop()
    {
        
    }


    private void InitControlValue()
    {
        BindThresholdStepSearch();
        SearchBind();
    }

    private void InitControlEvent()
    {
        string sDel_CScript = string.Format("return gfConfirmWait(this, '{0}');","삭제를 진행 하시겠습니까?");

        string sAdd_CScript = string.Format("   mfOpenWindow('ADD_C'); ");

        string sAdd_SScript = string.Format("   mfOpenWindow('ADD_S'); ");

        iBtnCodeDel.Attributes["onclick"] = sDel_CScript;
        iBtnCodeAdd.Attributes["onclick"] = sAdd_CScript;
        iBtnStepAdd.Attributes["onclick"] = sAdd_SScript;
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


    // 등급코드를 가져온다
    private void BindThresholdCodeList()
    {
        Biz_Bsc_Threshold_Code biz  = new Biz_Bsc_Threshold_Code();
        COD_ESEQ_COUNT              = biz.RtnThresholdCodeMaxSeq();

        string strLevel             = GetValue(ddlLevel.SelectedValue);
        DataSet ds                  = biz.GetThresholdCodeList(strLevel);        

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }


    // 평가단계별 등급코드를 가져온다
    private void BindThresholdStepList()
    {
        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();

        string strLevel = GetValue(ddlLevel.SelectedValue);
        DataSet ds = biz.GetThresholdLevelList(strLevel);        

        UltraWebGrid2.DataSource = ds;
        UltraWebGrid2.DataBind();
    }


    // 검색박스에 평가단계를 가져돈다
    private void BindThresholdStepSearch()
    {
        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();
        DataSet ds = biz.GetThresholdLevelSearch();

        ddlLevel.Items.Clear();

        ddlLevel.DataSource = ds;
        ddlLevel.DataTextField  = "THRESHOLD_LEVEL";
        ddlLevel.DataValueField = "THRESHOLD_LEVEL";
        ddlLevel.DataBind();

        ListItem li = new ListItem("선 택", "");
        ddlLevel.Items.Insert(0,li);

        PageUtility.FindByValueDropDownList(ddlLevel, CS_DEFAULT_TYPE);
    }

    // 평가단계별 등록되어있는 등급코드을 가져온다
    private void GetThresholdStepList()
    {
        BindThresholdCodeList();
    }

    private string[,] GetSelectedThresholdCode_ID(Infragistics.WebUI.UltraWebGrid.UltraWebGrid uGrid)
    {
        Infragistics.WebUI.UltraWebGrid.UltraGridRow ugRow;

        string sPKID = "";
        string[,] saPKID;

        bool bCheck = false;

        for (int i = 0; i < uGrid.Rows.Count; i++)
        {
            ugRow = uGrid.Rows[i];
            bCheck = Convert.ToBoolean(ugRow.Cells.FromKey("selChk").Value);

            if (bCheck)
            {
                sPKID += GetValue(ugRow.Cells.FromKey("THRESHOLD_REF_ID").Value) + ";";
            }
        }

        saPKID = TypeUtility.GetSplit(sPKID);
        return saPKID;
    }

    // 평가코드 삭제
    private void DelThresHoldCode()
    {     
        string sScript = "";

        string[,] saPKID;

        saPKID = GetSelectedThresholdCode_ID(this.UltraWebGrid1);

        if (saPKID.GetUpperBound(0) <= -1)
        {
            PageUtility.AlertMessage("삭제할 대상을 선택하셔야 합니다.");
            return;
        }

        Biz_Bsc_Threshold_Code biz = new Biz_Bsc_Threshold_Code();
        int iRet = biz.DelThresholdCode(saPKID);

        if (iRet == -1)
        {
            sScript += "평가단계에서 사용중인 코드이므로 삭제 할수없습니다\\n\\n평가단계에서 먼저 삭제해야 합니다";
        }
        else
        {
            sScript += string.Format(
                                    "[{0}]건이 삭제되었습니다!"
                                   , iRet
                                    );
        }
        PageUtility.AlertMessage(sScript);
        SearchBind();
    }

    private void AddThresholdStep(Infragistics.WebUI.UltraWebGrid.UltraWebGrid uGrid)
    {
        string[,] saPKID;

        saPKID = GetSelectedThresholdCode_ID(uGrid);

        if (saPKID.GetUpperBound(0) <= -1)
        {
            PageUtility.AlertMessage("추가할 대상을 선택하셔야 합니다.");
            return;
        }

        if (ddlLevel.SelectedValue.Equals(""))
        {
            PageUtility.AlertMessage("추가할 평가단계를 선택하셔야 합니다.");
            return;
        }

        string thresholdlevel = ddlLevel.SelectedValue;
        decimal point = 0;
        int emp_ref_id = gUserInfo.Emp_Ref_ID;

        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();
        int iRet = biz.InsertThresholdStep(saPKID, thresholdlevel, point, "N", emp_ref_id);

        //string sScript = "";

        //sScript += string.Format(
        //                        "[{0}]건이 추가되었습니다!"
        //                       , iRet
        //                        );

        //PageUtility.AlertMessage(sScript);

        SearchBind();
    }    

    private void DelThresholdStep(Infragistics.WebUI.UltraWebGrid.UltraWebGrid uGrid)
    {           
        string[,] saPKID;

        saPKID = GetSelectedThresholdCode_ID(uGrid);

        if (saPKID.GetUpperBound(0) <= -1)
        {
            PageUtility.AlertMessage("제거할 대상을 선택하셔야 합니다.");
            return;
        }

        if (ddlLevel.SelectedValue.Equals(""))
        {
            PageUtility.AlertMessage("제거할 평가단계를 선택하셔야 합니다.");
            return;
        }

        Biz_Bsc_Threshold_Step biz = new Biz_Bsc_Threshold_Step();        
        string thresholdlevel = ddlLevel.SelectedValue;
        int emp_ref_id = gUserInfo.Emp_Ref_ID;

        if (biz.IsDelStepValidate(saPKID, thresholdlevel))
        {
            PageUtility.AlertMessage("이미사용되고 있는 평가단계코드이므로 삭제할수 없습니다.");
            return;
        }

        //return;
        int iRet = biz.DelThresholdStep(saPKID, thresholdlevel);

        //string sScript = "";

        //sScript += string.Format(
        //                        "[{0}]건이 제거되었습니다!"
        //                       , iRet
        //                        );

        //PageUtility.AlertMessage(sScript);

        BindThresholdStepSearch();

        bool chkSelect = false;

        for(int i = 0; i < ddlLevel.Items.Count; i++)
        {
            if (ddlLevel.Items[i].Value == thresholdlevel)
            {
                ddlLevel.SelectedValue = thresholdlevel;
                chkSelect = true;
                SearchBind();
                return;
            }
        }

        if (!chkSelect)
            PageUtility.FindByValueDropDownList(ddlLevel, CS_DEFAULT_TYPE);

        SearchBind();
    }

    private void SearchBind()
    {
        BindThresholdStepList();
        BindThresholdCodeList();
    }
    #endregion


    #region 서버 이벤트 처리 함수

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {       
        DataRowView dr = (DataRowView)e.Data;
        string sCodeID = GetValue(dr["THRESHOLD_REF_ID"]);

        e.Row.Cells.FromKey("MODIFY").Value = string.Format(
                                            "<a href=\"#\" onclick=\"mfOpenWindow('UPD_C', '{0}');\"><img src='../images/drafts.gif' border='0'></a>", sCodeID);   
    }

    protected void UltraWebGrid2_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        string sCodeID = GetValue(dr["THRESHOLD_REF_ID"]);
        string sStopLevel = GetValue(dr["THRESHOLD_LEVEL"]);

        string _Code = sCodeID + ":" + sStopLevel;

        e.Row.Cells.FromKey("MODIFY").Value = string.Format(
                                            "<a href=\"#\" onclick=\"mfOpenWindow('UPD_S', '{0}', '{1}');\"><img src='../images/drafts.gif' border='0'></a>", sCodeID, sStopLevel);
    }

    protected void iBtnCodeDel_Click(object sender, ImageClickEventArgs e)
    {
        DelThresHoldCode();
    }

    protected void iBtnCodeAdd_Click(object sender, ImageClickEventArgs e)
    {
    }


    protected void iBtnStepSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchBind();
    }

    protected void iBtnCodeSearch_Click(object sender, ImageClickEventArgs e)
    {
        ddlLevel.SelectedValue = "";
        SearchBind();
    }


    protected void iBtnStepAdd_Click(object sender, ImageClickEventArgs e)
    {

    }

    // Reload
    protected void lBtnReload_Click(object sender, EventArgs e)
    {

        SearchBind();
    }

    protected void lbLevelReload_Click(object sender, EventArgs e)
    {
        BindThresholdStepSearch();
        SearchBind();
    }

    protected void iBtnCodeToStep_Click(object sender, EventArgs e)
    {
        AddThresholdStep(UltraWebGrid1);
    }

    protected void iBtnStepToCode_Click(object sender, ImageClickEventArgs e)
    {
        DelThresholdStep(UltraWebGrid2);
    }

    #endregion
  
}
