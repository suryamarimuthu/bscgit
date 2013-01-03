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

using MicroBSC.BSC.Biz;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common.Biz;

public partial class BSC_BSC1002M2 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetMyKpiList();
        }
    }

    #region Method
    private void SetInitForm()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        ddlGubun.Items.Add(new ListItem("개별지표", "N"));
        ddlGubun.Items.Add(new ListItem("연계(공통)지표", "Y"));
        //ddlGubun.Items.Add(new ListItem("일상공통(팀원MBO)", "P"));
        ddlGubun.Items.Add(new ListItem("전체", ""));

        //ddlGubun.Items.Add(new ListItem("일상업무(나의지표)", "N"));
        //ddlGubun.Items.Add(new ListItem("전략공통(팀지표)", "Y"));
        //ddlGubun.Items.Add(new ListItem("일상공통(팀원MBO)", "P"));
        //ddlGubun.Items.Add(new ListItem("전체", ""));
    }

    public void SetMyKpiList()
    {
        Biz_Bsc_Mbo_Kpi_Weight objBSC = new Biz_Bsc_Mbo_Kpi_Weight();
        DataSet rDs = objBSC.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), gUserInfo.Emp_Ref_ID);

        ugrdChildKpi.Clear();
        ugrdChildKpi.DataSource = rDs;
        ugrdChildKpi.DataBind();

        object[,] objRtn = objBSC.GetMboApprovalState(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), gUserInfo.Emp_Ref_ID);
        if (objRtn != null)
        {
            switch (objRtn[0, 0].ToString())
            {
                case "": // 결재상태 없음
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = true;
                    break;
                case Biz_Type.app_status_nodraft: // 결재상태 없음
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = true;
                    break;
                case Biz_Type.app_status_draft: // 상신
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = false;
                    break;
                case Biz_Type.app_status_ondraft: // 결재중
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = false;
                    break;
                case Biz_Type.app_status_return: // 반려
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = true;
                    break;
                case Biz_Type.app_status_recall: // 결재회수
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = true;
                    break;
                case Biz_Type.app_status_onmodify: // 수정결재
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = true;
                    break;
                case Biz_Type.app_status_complete: // 결재완료
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = false;
                    break;
                default:
                    addKpi.Visible = remKpi.Visible = udtKpi.Visible = false;
                    break;
            }
        }
        lblRowCount.Text = "&nbsp;" + ugrdChildKpi.Rows.Count.ToString() + "&nbsp;";
    }

    public void SetKpiListExceptMine()
    {
        int iTxrUser   = gUserInfo.Emp_Ref_ID;
        int iComDeptId = 0;
        Biz_Bsc_Mbo_Kpi_Weight objBSC = new Biz_Bsc_Mbo_Kpi_Weight();

        // 나의지표             : 구분 -> N     부서코드 -> 0
        // 팀 지표              : 구분 -> Y     부서코드 -> 로그인사용자 부서
        // 전체                 : 구분 -> ''    부서코드 -> 0

        if (PageUtility.GetByValueDropDownList(ddlGubun) == "Y" || PageUtility.GetByValueDropDownList(ddlGubun) == "" || PageUtility.GetByValueDropDownList(ddlGubun) == "P")
        {
            iComDeptId = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
        }

        DataSet rDS = objBSC.GetMboListForWeight(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                                                , PageUtility.GetByValueDropDownList(ddlGubun)
                                                , txtKpiCode.Text.Trim()
                                                , txtKpiName.Text.Trim()
                                                , gUserInfo.Emp_Ref_ID
                                                , iComDeptId);

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = rDS;
        ugrdKpiList.DataBind();
    }

    public void SetMBOKpi(string iType)
    {
        int itxr_user = gUserInfo.Emp_Ref_ID;
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        UltraWebGrid ugrdKpi = (iType == "ADD") ? ugrdKpiList : ugrdChildKpi;
        int cntRow = 0;

        Biz_Bsc_Mbo_Kpi_Weight objBSC = new Biz_Bsc_Mbo_Kpi_Weight();

        if (iType == "DEL")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dt.Columns.Add("EMP_REF_ID", typeof(int));
            dt.Columns.Add("KPI_REF_ID", typeof(int));

            for (int i = 0; i < ugrdKpi.Rows.Count; i++)
            {
                row = ugrdKpi.Rows[i];
                col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

                if (chk.Checked)
                {
                    DataRow dr = dt.NewRow();
                    dr["ESTTERM_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("ESTTERM_REF_ID").Value);
                    dr["EMP_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);
                    dr["KPI_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("KPI_REF_ID").Value);
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                if (objBSC.DeleteMBOWeight(dt, gUserInfo.Emp_Ref_ID))
                {
                    this.SetMyKpiList();
                    this.SetKpiListExceptMine();
                    PageUtility.AlertMessage("삭제하였습니다.");
                }
                else
                    PageUtility.AlertMessage("실패하였습니다.");
                return;
            }
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ESTTERM_REF_ID", typeof(int));
            dt.Columns.Add("KPI_REF_ID", typeof(int));
            dt.Columns.Add("WEIGHT", typeof(decimal));
            dt.Columns.Add("KPI_CLASS_REF_ID", typeof(string));

            for (int i = 0; i < ugrdKpi.Rows.Count; i++)
            {
                row = ugrdKpi.Rows[i];
                col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

                if (chk.Checked)
                {
                    DataRow dr = dt.NewRow();
                    dr["ESTTERM_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("ESTTERM_REF_ID").Value);
                    dr["KPI_REF_ID"] = DataTypeUtility.GetToInt32(row.Cells.FromKey("KPI_REF_ID").Value);
                    if (iType == "ADD")
                        dr["WEIGHT"] = 0;
                    else if (iType == "SET")
                        dr["WEIGHT"] = DataTypeUtility.GetToDecimal(row.Cells.FromKey("WEIGHT").Value);
                    try
                    {
                        dr["KPI_CLASS_REF_ID"] = (row.Cells.FromKey("IS_TEAM_KPI").Value.ToString() == "Y" ? "SCO" : "PCO");
                    }
                    catch { }
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                if (objBSC.UpdateMBOWeight(gUserInfo.Emp_Ref_ID
                                        , dt))
                {
                    this.SetMyKpiList();
                    this.SetKpiListExceptMine();
                    PageUtility.AlertMessage("처리하였습니다.");
                }
                else
                    PageUtility.AlertMessage("실패하였습니다.");
                return;                    
            }
        }

        if (cntRow < 1)
        {
            PageUtility.AlertMessage("항목을 선택하세요.");
        }
        else
        {
            this.SetMyKpiList();
            this.SetKpiListExceptMine();
            PageUtility.AlertMessage("삭제하였습니다.");
        }
    }
    #endregion

    #region Event
    protected void ugrdKpiList_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        //System.Web.UI.WebControls.Image objImg = (System.Web.UI.WebControls.Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        //objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
        //                  "../images/icon_o.gif" : "../images/icon_x.gif";
    }
    protected void addKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.SetMBOKpi("ADD");
    }
    protected void remKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.SetMBOKpi("DEL");
    }
    protected void udtKpi_Click(object sender, ImageClickEventArgs e)
    {
        this.SetMBOKpi("SET");
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetMyKpiList();
        this.SetKpiListExceptMine();
        
    }
    #endregion
}
