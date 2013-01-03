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

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.BSC.Biz;

public partial class ctl_ctl2100_Role : AppPageBase
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
            if (TypeUtility.GetNumString(GetRequest("emp_ref_id")) == "")
            {
                PageUtility.ExecuteScript("alert('사용자정보를 알 수 없습니다!\n\n다시 시도해 주십시요!');gfCloseWindow();");
                return;
            }
        }

        private void InitControlValue()
        {
            int iEmpRefID = WebUtility.GetRequestByInt("emp_ref_id");
            Biz_ctl_ctl2100_Role biz = new Biz_ctl_ctl2100_Role();
            
            this.lblEmpName.Text = biz.GetEmpName(iEmpRefID);
            SetDDLRoleInfo();
        }

        private void InitControlEvent()
        {

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
        private void SetDDLRoleInfo()
        {
            int iEmpRefID = Convert.ToInt32(TypeUtility.GetNumString(GetRequest("emp_ref_id")));

            Biz_ctl_ctl2100_Role biz = new Biz_ctl_ctl2100_Role();

            ddlRole.Items.Clear();
            ddlRole.DataSource = biz.GetRoleInfo(iEmpRefID);
            ddlRole.DataTextField = "ROLE_NAME";
            ddlRole.DataValueField= "ROLE_REF_ID";
            ddlRole.DataBind();

            if (ddlRole.Items.Count <= 0)
            {
                this.iBtnAdd.Visible = false;
                ddlRole.Visible = false;
            }
            else
            {
                this.iBtnAdd.Visible = true;
                ddlRole.Visible = true;
            }
        }

        private DataSet GetSearchData()
        {
            DataSet lDS = new DataSet();
            int iEmpRefID = Convert.ToInt32(TypeUtility.GetNumString(GetRequest("emp_ref_id")));
            
            Biz_ctl_ctl2100_Role biz = new Biz_ctl_ctl2100_Role();
            lDS = biz.GetSearchData(iEmpRefID);

            return lDS;
        }
         
        private void SearchDB()
        {
            UltraWebGrid1.Clear();
            UltraWebGrid1.DataSource = GetSearchData();
            UltraWebGrid1.DataBind();

            if (UltraWebGrid1.Rows.Count <= 0)
            {
                this.iBtnRoleDel.Visible = false;
            }
            else
            {
                this.iBtnRoleDel.Visible = true;
            }
        }

        private void AddRoleInfo()
        {
            if (PageUtility.GetByValueDropDownList(ddlRole) == "")
            {
                PageUtility.AlertMessage("추가할 권한이 없습니다!");
                return;
            }

            int iEmpRefID = Convert.ToInt32(TypeUtility.GetNumString(GetRequest("emp_ref_id")));
            int iRoleRefID= Convert.ToInt32(PageUtility.GetByValueDropDownList(ddlRole));

            Biz_ctl_ctl2100_Role biz = new Biz_ctl_ctl2100_Role();
            biz.AddRoleInfo(iEmpRefID, iRoleRefID);

            //if (biz.AddRoleInfo(iEmpRefID, iRoleRefID) > 0)
            //    PageUtility.AlertMessage("권한이 추가되었습니다!");
            //else
            //    PageUtility.AlertMessage("권한이 추가되지 못했습니다!");
        }

        private void DelRoleInfo()
        {
            int iChecked = 0;
            bool bChecked = false;
            string sPKs = "";
            string[,] saPKs;
            string sScript = "";

            UltraGridRow row;

            // 체크되어있는 사항 있는지 점검
            for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
            {
                row = UltraWebGrid1.Rows[i];

                if (Convert.ToBoolean(row.Cells.FromKey("SelChk").GetText()))
                {
                    if (bChecked == false)
                        bChecked = true;

                    sPKs += row.Cells.FromKey("EMP_REF_ID").Value.ToString() + ";" + row.Cells.FromKey("ROLE_REF_ID").Value.ToString() + ";";

                    iChecked++;

                }

            }

            if (!bChecked)
            {
                PageUtility.AlertMessage("[권한삭제]를 처리하시려면 먼저 삭제할 사항을 선택하셔야 합니다!");
                return;
            }
            else
            {
                saPKs = TypeUtility.GetSplit(sPKs, 2);

                int iRet = 0;
                Biz_ctl_ctl2100_Role biz = new Biz_ctl_ctl2100_Role();

                iRet = biz.DelRoleInfo(saPKs);

                //sScript = string.Format("alert('[{0}]건의 권한을 삭제처리 하였습니다!');", iRet);
                //PageUtility.ExecuteScript(sScript);
            }

        }
    #endregion

    #region 서버 이벤트 처리 함수
        protected void UltraWebGrid1_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
        {

        }

        protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
        {

        }

        protected void iBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AddRoleInfo();

            SetDDLRoleInfo();
            SearchDB();
        }

        protected void iBtnRoleDel_Click(object sender, ImageClickEventArgs e)
        {
            DelRoleInfo();

            SetDDLRoleInfo();
            SearchDB();
        }

    #endregion


    
}
