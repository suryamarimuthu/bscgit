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
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Common;

using MicroBSC.Biz.BSC.Biz;

public partial class ctl_ctl4100 : AppPageBase
{
    // 디폴트 측정단계
    private const string CS_DEFAULT_TYPE = "4";

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
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

    private void InitControlValue()
    {
        Biz_ctl_ctl4100 biz = new Biz_ctl_ctl4100();
        DataSet dsType = biz.GetAllType();

        ddlType.Items.Clear();
        ddlType.DataSource = dsType;
        ddlType.DataTextField = "V_TYPE_NAME";
        ddlType.DataValueField = "V_TYPE";
        ddlType.DataBind();

        PageUtility.FindByValueDropDownList(ddlType, CS_DEFAULT_TYPE);
    }

    private void InitControlEvent()
    {
        string sDelScript = string.Format(
                                            "return gfConfirmWait(this, '{0}');"
                                          , "삭제를 진행하시면, 기 설정된 KPI 의 THRESHOLD 정보들이 초기화 됩니다.\\n\\n"
                                          + "삭제 후 모든 KPI 의 THRESHOLD 는 재설정하셔야 합니다.\\n\\n"
                                          + "삭제를 진행 하시겠습니까?"
                                         );
        string sAddScript = string.Format(
                                            "if (confirm('{0}')) "
                                          + "   mfOpenWindow('ADD'); "
                                          + "return false;"
                                          , "추가 등급을 적용하려면,\\n\\n"
                                          + "KPI 의 THRESHOLD 들을 재설정하셔야 합니다.\\n\\n"
                                          + "추가 하시겠습니까?"
                                         );

        iBtnDel.Attributes["onclick"] = sDelScript;
        iBtnAdd.Attributes["onclick"] = sAddScript;
    }

    private void SetPageData()
    {
        SearchDB();

    }

    private void SetPostBack()
    {

    }
    private void SetAllTimeBottom()
    {
    }
    #endregion

    #region 내부함수

    private DataSet GetSearchData()
    {
        Biz_ctl_ctl4100 biz = new Biz_ctl_ctl4100();
        string sType = PageUtility.GetByValueDropDownList(ddlType);

        DataSet lDS = biz.GetSearchData(sType);

        return lDS;
    }
    private void SearchDB()
    {
        UltraWebGrid1.DataSource = GetSearchData();
        UltraWebGrid1.DataBind();

        // 추가시에는 현재타입의 갯수만큼만 처리되도록 확인처리한다.
        ////int iRowCnt = UltraWebGrid1.Rows.Count;
        ////int iType   = Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlType));

        ////string sAddScript = "";

        ////if (iType > iRowCnt)
        ////{
        ////    sAddScript = string.Format(
        ////                                "return gfConfirmWait(this, '{0}');"
        ////                              , "추가 등급을 적용하려면,\\n\\n"
        ////                              + "KPI 의 THRESHOLD 들을 재설정하셔야 합니다.\\n\\n"
        ////                              + "추가 하시겠습니까?"
        ////                             );
        ////}
        ////else
        ////{
        ////    sAddScript = string.Format(
        ////                                "alert('{0}');return false;"
        ////                              , "현재측정단계에서는 더이상 추가하실 수 없습니다!"
        ////                             );
        ////}

        ////iBtnAdd.Attributes.Remove("onclick");
        ////iBtnAdd.Attributes["onclick"] = sAddScript;
    }

    private void DelThresHold()
    {
        Infragistics.WebUI.UltraWebGrid.UltraGridRow ugRow;
        Infragistics.WebUI.UltraWebGrid.TemplatedColumn ugCol;

        string sPKID = "";
        string[,] saPKID;

        string sScript = "";

        bool bCheck = false;

        for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
        {
            ugRow = this.UltraWebGrid1.Rows[i];
            bCheck = Convert.ToBoolean(ugRow.Cells.FromKey("selChk").Value);

            if (bCheck)
            {
                sPKID += GetValue(ugRow.Cells.FromKey("V_CODE_ID").Value) + ";";
            }
        }

        saPKID = TypeUtility.GetSplit(sPKID);
        if (saPKID.GetUpperBound(0) <= -1)
        {
            PageUtility.AlertMessage("삭제할 대상을 선택하셔야 합니다.");
            return;
        }

        Biz_ctl_ctl4100 biz = new Biz_ctl_ctl4100();
        int iRet = biz.DelThreshold(saPKID);

        sScript += string.Format(
                                "[{0}]건이 삭제되었습니다!"
                               , iRet
                                );
        PageUtility.AlertMessage(sScript);
        SearchDB();
    }
    #endregion

    #region 서버 이벤트 처리 함수

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //DataRowView dr = (DataRowView)e.Data;

        //if (dr["STATUS"].ToString().Trim() == "E")
        //{
        //    e.Row.Cells.FromKey("STATUS").Value = "<div align=center><img src='../images/icon/est_i02.gif'>";
        //}
        //else if (dr["STATUS"].ToString().Trim() == "P")
        //{
        //    e.Row.Cells.FromKey("STATUS").Value = "<div align=center><img src='../images/icon/est_i01.gif'>";
        //}
        //else
        //{
        //    e.Row.Cells.FromKey("STATUS").Value = "<div align=center><img src='../images/icon/est_i03.gif'>";
        //}

        DataRowView dr = (DataRowView)e.Data;
        string sCodeID = GetValue(dr["V_CODE_ID"]);

        e.Row.Cells.FromKey("MODIFY").Value = string.Format(
                                            "<a href=\"#\" onclick=\"mfOpenWindow('UPD', '{0}');\"><img src='../images/drafts.gif' border='0'></a>", sCodeID);

    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchDB();
    }

    protected void iBtnDel_Click(object sender, ImageClickEventArgs e)
    {
        DelThresHold();
    }
    protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
    {

    }

    // Reload
    protected void lbReload_Click(object sender, EventArgs e)
    {
        SearchDB();
    }
    #endregion



}
