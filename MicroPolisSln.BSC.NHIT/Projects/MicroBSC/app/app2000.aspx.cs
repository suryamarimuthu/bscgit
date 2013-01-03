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
using Infragistics.WebUI.UltraWebGrid;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.RolesBasedAthentication;


public partial class app_app2000 : AppPageBase
{
    private enum EN_GRIDCOL : int
    {
        V_APP_STEP              = 0,
        V_EMP_NAME              = 1,
        V_POSITION_DUTY_NAME    = 2,
        V_DEPT_NAME             = 3,
        V_APP_STATUS            = 4,
        V_APP_DATE              = 5,
        V_APP_REMARK            = 6
    }

    private int GetGridCol(EN_GRIDCOL enCol)
    {
        return (int)enCol;
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
            Biz_app_app0000 biz = new Biz_app_app0000();

            ddlAppGubun.Items.Clear();
            ddlAppGubun.DataSource      = biz.GetDDLAppGubun();
            ddlAppGubun.DataTextField   = "V_NAME";
            ddlAppGubun.DataValueField  = "V_CODE";
            ddlAppGubun.DataBind();
            ddlAppGubun.Items.Insert(0, new ListItem(":: 전체 ::", ""));

            ddlEstTerm.Items.Clear();
            //ddlEstTerm.DataSource       = biz.GetDDLEstTerm();
            //ddlEstTerm.DataTextField    = "V_NAME";
            //ddlEstTerm.DataValueField   = "V_CODE";
            //ddlEstTerm.DataBind();
            WebCommon.SetEstTermDropDownList(ddlEstTerm);

            ddlAppType.Items.Clear();
            ddlAppType.Items.Add(new ListItem(":: 전체 ::", ""));
            //ddlAppType.Items.Add(new ListItem("전체", ""));
            ddlAppType.Items.Add(new ListItem("대기", "P"));
            ddlAppType.Items.Add(new ListItem("승인", "E"));
            ddlAppType.Items.Add(new ListItem("취소", "C"));

            //ddlAppType.ClearSelection();
            //ddlAppType.Items.FindByValue("P").Selected = true;

            //Callback1.Content.Controls.Add(GridView1);
        }

        private void InitControlEvent()
        {
            iBtnAppCancel.Attributes["onclick"] = "return mfConfirmCheck();";
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
            DataSet ds = new DataSet();

            int iEmpRefID = gUserInfo.Emp_Ref_ID;
            string sAppGubun = PageUtility.GetByValueDropDownList(ddlAppGubun);
            string sEstTerm = PageUtility.GetByValueDropDownList(ddlEstTerm);
            string sAppStatus = PageUtility.GetByValueDropDownList(ddlAppType);


            Biz_app_app0000 biz = new Biz_app_app0000();
            ds = biz.GetSearchData(iEmpRefID, sAppGubun, sEstTerm, sAppStatus, true);

            return ds;
        }

        private DataSet GetSearchDetail(string asAppRefID)
        {
            DataSet ds = new DataSet();
            
            Biz_app_app0000 biz = new Biz_app_app0000();
            ds = biz.GetSearchDetail(asAppRefID);

            return ds;
        }

        private void SearchDB()
        {
            UltraWebGrid1.DataSource = GetSearchData();
            UltraWebGrid1.DataBind();

            //SearchDetail("0");
        }

        private void SearchDetail(string asAppRefID)
        {
            GridView1.DataSource = GetSearchDetail(asAppRefID);
            GridView1.DataBind();
        }

        /// <summary>
        /// SetRepCancel
        ///     : 상신취소
        /// </summary>
        private void SetRepCancel()
        {
            int iChecked = 0;
            bool bChecked = false;
            string sPrcKey = "";
            string[,] saPrcKey;

            UltraGridRow row;

            // 현재결재상태코드(V_CUR_APP_STATUS_CD), 전체결재상태코드(V_ALL_APP_STATUS_CD)
            // 문서번호(V_APP_REF_ID);문서타입(V_APP_CODE);KPI문서정보(V_EVENT_ID);KPI문서추가정보(V_EVENT_ADD_ID);평가기간코드(V_TERM_REF_ID);현재결재단계(V_APP_STEP);전체결재단계(V_MAX_APP_STEP)

            // 체크되어있는 사항 있는지 점검
            for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
            {
                row = UltraWebGrid1.Rows[i];

                if (Convert.ToBoolean(row.Cells.FromKey("SelChk").GetText()))
                {
                    iChecked++;

                    // 현재 단계가 1이면서 대기상태일 때만 체크박스 처리 가능하다.
                    if (
                        GetValue(row.Cells.FromKey("V_CUR_APP_STATUS_CD").Value) == "P" &&
                        GetValue(row.Cells.FromKey("V_APP_STEP").Value) == "1"          &&
                        GetValue(row.Cells.FromKey("V_REP_EMP_ID").Value) == GetValue(gUserInfo.Emp_Ref_ID)
                       )
                    {
                        if (bChecked == false)
                            bChecked = true;

                        sPrcKey += GetValue(row.Cells.FromKey("V_APP_REF_ID").Value) + ";";
                    }
                    else
                    {
                        // 앞에서 잘 선택되었더라도 하나라도 잘못 선택되었다면 다시해야 한다.
                        if (bChecked == true)
                            bChecked = false;

                        return;
                    }
                }
            }

            if (!bChecked)
            {
                if (iChecked > 0)
                {
                    PageUtility.AlertMessage("[상신취소]는 처리가 아직 안된건에 대해서만 가능합니다!");
                }
                else
                {
                    PageUtility.AlertMessage("[상신취소] 처리를 하시려면 먼저 선택하셔야 합니다!");
                }
                return;
            }
            else
            {
                saPrcKey = TypeUtility.GetSplit(sPrcKey);

                int iProcCnt = 0;
                Biz_app_app0000 biz = new Biz_app_app0000();

                iProcCnt = biz.SetApprovalRepCancel(saPrcKey);

                PageUtility.AlertMessage(
                                            string.Format
                                            (
                                                "[{0}]건을 상신취소처리 하였습니다!"
                                               , iProcCnt
                                            )
                                        );
            }
        }
    #endregion

    #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchDB();
        }
        protected void iBtnAppCancel_Click(object sender, ImageClickEventArgs e)
        {
            SetRepCancel();
            SearchDB();
        }
        protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
        {

        }
        protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Data;

            //int iChecked = 0;
            //bool bChecked = false;
            //string sPKs = "";
            //string[,] saPKs;
            //string sScript = "";

            //UltraGridRow row;

            // 전체 결재상태가 승인, 취소 일경우는 체크박스 없엔다.
            // 현재 단계가 1이면서 대기상태일 때만 체크박스 처리 가능하다.
            if (
                GetValue(drv["V_CUR_APP_STATUS_CD"]) != "P" ||
                GetValue(drv["V_APP_STEP"]) != "1"
               )
            {
                e.Row.Cells.FromKey("SelChk").AllowEditing = AllowEditing.No;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

            // 숨김처리.. (화면표시없이 데이터 읽기위해)
            //if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Cells[GetGridCol(EN_GRIDCOL.CODE)].CssClass = "NoneDisplay";
            //    e.Row.Cells[GetGridCol(EN_GRIDCOL.EXPLAIN)].CssClass = "NoneDisplay";
            //    e.Row.Cells[GetGridCol(EN_GRIDCOL.PARITYREASON)].CssClass = "NoneDisplay";
            //    e.Row.Cells[GetGridCol(EN_GRIDCOL.PARITYRESULT)].CssClass = "NoneDisplay";
            //}

            // Fix Header
            FixHeaderCol(e, "FixHeader");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //RadioButtonList rblYN = (RadioButtonList)e.Row.FindControl("rblChk");
                //TextBox tbReason = (TextBox)e.Row.FindControl("txtReason");

                //PageUtility.FindByValueRadioButtonList(rblYN, e.Row.Cells[GetGridCol(EN_GRIDCOL.PARITYRESULT)].Text);
                //tbReason.Text = PageUtility.GetValue(e.Row.Cells[GetGridCol(EN_GRIDCOL.PARITYREASON)].Text);

                //rblYN.Attributes["onclick"] = "mfCheckParityResult()";

                string sStatus = GetValue(e.Row.Cells[GetGridCol(EN_GRIDCOL.V_APP_STATUS)].Text);

                switch (sStatus)
                {
                    case "승인":
                        e.Row.Cells[GetGridCol(EN_GRIDCOL.V_APP_STATUS)].Text = "<img src='../images/icon/icon_bt01.gif' align='absbottom' />";
                        break;
                    case "대기":
                        e.Row.Cells[GetGridCol(EN_GRIDCOL.V_APP_STATUS)].Text = "<img src='../images/icon/icon_bt03.gif' align='absbottom' />";
                        break;
                    case "취소":
                        e.Row.Cells[GetGridCol(EN_GRIDCOL.V_APP_STATUS)].Text = "<img src='../images/icon/icon_bt04.gif' align='absbottom' />";
                        break;
                }

            }
        }

        protected void Callback1_Callback(object sender, SJ.Web.UI.CallBackEventArgs e)
        {
            string sAppRefID = e.Parameter;
            
            SearchDetail(sAppRefID);

            GridView1.RenderControl(e.Output);

        }
    #endregion


    
}
