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

public partial class app_app0000 : AppPageBase
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    String query = "select b.emp_name, rep_date, app_ref_id, case app_code when 'KPI' then 'KPI' when 'STG' then '전략' when 'STM' then '전략체계도' when 'QUA' then '업적평가' when 'QUL' then '역량평가' when 'ABL' then '성과평가'end as app_code,rep_title, app_doc_no, (app_step_count+1) as app_step_count from com_approval_info a, com_emp_info b  where a.app_emp_id = b.emp_ref_id and b.emp_ref_id=" + ((SiteIdentity)Context.User.Identity).Emp_Ref_ID;
    //    IDbConnection _connection = new IDbConnection();
    //    _connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
    //    SqlDataAdapter ad = new SqlDataAdapter(query, _connection);
    //    DataSet ds = new DataSet();
    //    ad.Fill(ds);

    //    UltraWebGrid1.DataSource = ds;
    //    UltraWebGrid1.DataBind();
    //}

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
            //ddlAppType.Items.Add(new ListItem(":: 전체 ::", ""));
            ddlAppType.Items.Add(new ListItem("전체", ""));
            ddlAppType.Items.Add(new ListItem("대기", "P"));
            ddlAppType.Items.Add(new ListItem("승인", "E"));
            ddlAppType.Items.Add(new ListItem("취소", "C"));

            //ddlAppType.ClearSelection();
            //ddlAppType.Items.FindByValue("P").Selected = true;

        }

        private void InitControlEvent()
        {
            txtCancelRemark.Attributes["onkeydown"]= "if (event.keyCode == ENTER_KEY){window.event.returnValue = false; return false;}";
            iBtnAppEnd.Attributes["onclick"]    = "return mfConfirmCheck('결재완료');";
            iBtnAppCancel.Attributes["onclick"] = "return mfConfirmCheck('승인취소');";
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
            string sAppGubun    = PageUtility.GetByValueDropDownList(ddlAppGubun);
            string sEstTerm     = PageUtility.GetByValueDropDownList(ddlEstTerm);
            string sAppStatus   = PageUtility.GetByValueDropDownList(ddlAppType);


            Biz_app_app0000 biz = new Biz_app_app0000();
            ds = biz.GetSearchData(iEmpRefID, sAppGubun, sEstTerm, sAppStatus, false);

            return ds;
        }

        private void SearchDB()
        {
            UltraWebGrid1.DataSource = GetSearchData();
            UltraWebGrid1.DataBind();
        }

        /// <summary>
        /// SetAppEnd
        ///     : 결재완료 처리
        /// </summary>
        private void SetAppEnd()
        {
            int iChecked    = 0;
            bool bChecked   = false;
            string sPrcKey  = "";
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

                    // 현재결재상태코드가 승인취소(C)가 아니면서 현재결재상태코드가 승인(E)가 아닐경우 
                    if (
                        GetValue(row.Cells.FromKey("V_CUR_APP_STATUS_CD").Value) != "C" &&
                        GetValue(row.Cells.FromKey("V_CUR_APP_STATUS_CD").Value) != "E" &&
                        GetValue(row.Cells.FromKey("V_APP_EMP_ID").Value) == GetValue(gUserInfo.Emp_Ref_ID)
                       )
                    {
                        if (bChecked == false)
                            bChecked = true;

                        sPrcKey += GetValue(row.Cells.FromKey("V_APP_REF_ID").Value)    + ";"
                                 + GetValue(row.Cells.FromKey("V_APP_CODE").Value)      + ";"
                                 + GetValue(row.Cells.FromKey("V_EVENT_ID").Value)      + ";"
                                 + GetValue(row.Cells.FromKey("V_EVENT_ADD_ID").Value)  + ";"
                                 + GetValue(row.Cells.FromKey("V_TERM_REF_ID").Value)   + ";"
                                 + GetValue(row.Cells.FromKey("V_APP_STEP").Value)      + ";"
                                 + GetValue(row.Cells.FromKey("V_MAX_APP_STEP").Value)  + ";"
                        ;
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
                    PageUtility.AlertMessage("결재가 완료되었거나 승인취소된 건을 선택하시면 안됩니다!");
                }
                else
                {
                    PageUtility.AlertMessage("[결재완료] 처리를 하시려면 먼저 선택하셔야 합니다!");
                }
                return;
            }
            else
            {
                saPrcKey = TypeUtility.GetSplit(sPrcKey, 7);

                int iProcCnt = 0;
                Biz_app_app0000 biz = new Biz_app_app0000();

                iProcCnt = biz.SetApprovalEnd(saPrcKey);

                PageUtility.AlertMessage(
                                            string.Format
                                            (
                                                "[{0}]건을 승인처리 하였습니다!"
                                               ,iProcCnt
                                            )
                                        );

                MenuControl1.CallApprovalInfo();
            }

            
        }

        /// <summary>
        ///  SetAppCancel
        ///     : 결재취소 처리
        /// </summary>
        private void SetAppCancel()
        {
            int iChecked = 0;
            bool bChecked = false;
            string sPrcKey = "";
            string[,] saPrcKey;

            // 취소사유 확인
            string sRemark = GetValue(txtCancelRemark.Text);
            if (sRemark == "")
            {
                PageUtility.AlertMsgFocus("[취소사유]를 입력하셔야 합니다!", "txtCancelRemark");
                return;
            }

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

                    // 현재결재상태코드가 승인취소(C)가 아니면서 현재결재상태코드가 승인(E)가 아닐경우 
                    if (
                        GetValue(row.Cells.FromKey("V_CUR_APP_STATUS_CD").Value) != "C" &&
                        GetValue(row.Cells.FromKey("V_CUR_APP_STATUS_CD").Value) != "E" &&
                        GetValue(row.Cells.FromKey("V_APP_EMP_ID").Value) == GetValue(gUserInfo.Emp_Ref_ID)
                       )
                    {
                        if (bChecked == false)
                            bChecked = true;

                        sPrcKey += GetValue(row.Cells.FromKey("V_APP_REF_ID").Value) + ";"
                                 + GetValue(row.Cells.FromKey("V_APP_CODE").Value) + ";"
                                 + GetValue(row.Cells.FromKey("V_EVENT_ID").Value) + ";"
                                 + GetValue(row.Cells.FromKey("V_EVENT_ADD_ID").Value) + ";"
                                 + GetValue(row.Cells.FromKey("V_TERM_REF_ID").Value) + ";"
                                 + GetValue(row.Cells.FromKey("V_APP_STEP").Value) + ";"
                                 + GetValue(row.Cells.FromKey("V_MAX_APP_STEP").Value) + ";"
                        ;
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
                    PageUtility.AlertMessage("결재가 완료되었거나 승인취소된 건을 선택하시면 안됩니다!");
                }
                else
                {
                    PageUtility.AlertMessage("[승인취소] 처리를 하시려면 먼저 선택하셔야 합니다!");
                }
                return;
            }
            else
            {
                saPrcKey = TypeUtility.GetSplit(sPrcKey, 7);

                int iProcCnt = 0;
                Biz_app_app0000 biz = new Biz_app_app0000();

                iProcCnt = biz.SetApprovalCancel(sRemark, saPrcKey);

                PageUtility.AlertMessage(
                                            string.Format
                                            (
                                                "[{0}]건을 승인취소처리 하였습니다!"
                                               , iProcCnt
                                            )
                                        );

                txtCancelRemark.Text = "";
                MenuControl1.CallApprovalInfo();
            }
        }
    #endregion

    #region 서버 이벤트 처리 함수
        protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchDB();
        }

        protected void iBtnAppEnd_Click(object sender, ImageClickEventArgs e)
        {
            // 리로드로 인해 중복처리 되는 현상 제거
            if (IsPageRefresh)
                return;

            SetAppEnd();
            SearchDB();
        }

        protected void iBtnAppCancel_Click(object sender, ImageClickEventArgs e)
        {
            // 리로드로 인해 중복처리 되는 현상 제거
            if (IsPageRefresh)
                return;

            SetAppCancel();
            SearchDB();
        }

        protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
        {

        }
        protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Data;

            int iChecked = 0;
            bool bChecked = false;
            string sPKs = "";
            string[,] saPKs;
            string sScript = "";

            UltraGridRow row;

            // KPI 코드열 색상변경
            e.Row.Cells.FromKey("V_KPI_NAME").Style.ForeColor = System.Drawing.Color.Blue;

            // 전체 결재상태가 승인, 취소 일경우는 체크박스 없엔다.
            //for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
            //{

                if (
                    GetValue(drv["V_ALL_APP_STATUS_CD"]) == "E" ||
                    GetValue(drv["V_ALL_APP_STATUS_CD"]) == "C"
                   )
                {
                    e.Row.Cells.FromKey("SelChk").AllowEditing = AllowEditing.No;
                }

                switch (GetValue(drv["V_CUR_APP_STATUS"]))
                {
                    case "승인":
                        e.Row.Cells.FromKey("V_CUR_APP_STATUS").Value = "<img src='../images/icon/icon_bt01.gif' align='absbottom' />";
                        break;
                    case "대기":
                        e.Row.Cells.FromKey("V_CUR_APP_STATUS").Value = "<img src='../images/icon/icon_bt03.gif' align='absbottom' />";
                        break;
                    case "취소":
                        e.Row.Cells.FromKey("V_CUR_APP_STATUS").Value = "<img src='../images/icon/icon_bt04.gif' align='absbottom' />";
                        break;
                }

                switch (GetValue(drv["V_ALL_APP_STATUS"]))
                {
                    case "승인":
                        e.Row.Cells.FromKey("V_ALL_APP_STATUS").Value = "<img src='../images/icon/icon_bt01.gif' align='absbottom' />";
                        break;
                    case "대기":
                        e.Row.Cells.FromKey("V_ALL_APP_STATUS").Value = "<img src='../images/icon/icon_bt03.gif' align='absbottom' />";
                        break;
                    case "취소":
                        e.Row.Cells.FromKey("V_ALL_APP_STATUS").Value = "<img src='../images/icon/icon_bt04.gif' align='absbottom' />";
                        break;
                }
            //}
        }
    #endregion

    
}
