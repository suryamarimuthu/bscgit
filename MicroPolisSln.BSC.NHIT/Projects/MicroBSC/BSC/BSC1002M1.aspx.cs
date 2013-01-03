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

public partial class BSC_BSC1002M1 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetMyKpiList();
        }
        else
        {

        }
    }

    #region Method
    private void SetInitForm()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        ddlGubun.Items.Add(new ListItem("나의지표", "N"));
        ddlGubun.Items.Add(new ListItem("팀원지표", "H"));
        ddlGubun.Items.Add(new ListItem("팀지표", "Y"));
        ddlGubun.Items.Add(new ListItem("전체", ""));
    }

    public void SetMyKpiList()
    {
        Biz_Bsc_Mbo_Kpi_Weight objBSC = new Biz_Bsc_Mbo_Kpi_Weight();
        DataSet rDs = objBSC.GetAllList(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), gUserInfo.Emp_Ref_ID);

        ugrdChildKpi.Clear();
        ugrdChildKpi.DataSource = rDs;
        ugrdChildKpi.DataBind();
    }

    public void SetKpiListExceptMine()
    {
        int iTxrUser   = gUserInfo.Emp_Ref_ID;
        int iComDeptId = 0;
        Biz_Bsc_Mbo_Kpi_Weight objBSC = new Biz_Bsc_Mbo_Kpi_Weight();

        // 팀원이 속한 MBO지표  : 구분 -> N     부서코드 -> 로그인사용자 부서
        // 나의지표             : 구분 -> N     부서코드 -> 0
        // 팀 지표              : 구분 -> Y     부서코드 -> 로그인사용자 부서
        // 전체                 : 구분 -> ''    부서코드 -> 0

        if (   PageUtility.GetByValueDropDownList(ddlGubun) == "Y" 
            || PageUtility.GetByValueDropDownList(ddlGubun) == "H")
        {
            iComDeptId = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
        }

        string gubun = PageUtility.GetByValueDropDownList(ddlGubun);

        if(gubun.Equals("H"))
            gubun = "N";

        DataSet rDs = objBSC.GetKpiListExceptMyKpi
                      ( PageUtility.GetIntByValueDropDownList(ddlEstTermInfo)
                      , iTxrUser
                      , ""
                      , txtKpiCode.Text
                      , txtKpiName.Text
                      , "Y"
                      , ""
                      , iComDeptId
                      , ""
                      , gubun
                      , iTxrUser);

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = rDs;
        ugrdKpiList.DataBind();
    }

    public void SetMBOKpi(string iType)
    {
        int itxr_user = gUserInfo.Emp_Ref_ID;
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        UltraWebGrid ugrdKpi = (iType == "ADD") ? ugrdKpiList : ugrdChildKpi;
        int intRtn = 0;
        int cntRow = 0;

        Biz_Bsc_Mbo_Kpi_Weight objBSC = new Biz_Bsc_Mbo_Kpi_Weight(); 

        for (int i = 0; i < ugrdKpi.Rows.Count; i++)
        {
            row = ugrdKpi.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    if (iType == "ADD")
                    {
                        intRtn += objBSC.UpdateData
                                 ( int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString())
                                 , itxr_user
                                 , int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                 , 0
                                 , "Y"
                                 , itxr_user);
                    }
                    else if (iType == "SET")
                    {
                        intRtn += objBSC.UpdateData
                                 ( int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString())
                                 , itxr_user
                                 , int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                 , decimal.Parse(row.Cells.FromKey("WEIGHT").Value.ToString())
                                 , "Y"
                                 , itxr_user);
                    }
                    else if (iType == "DEL")
                    {
                        intRtn += objBSC.DeleteData
                                 ( int.Parse(row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString())
                                 , int.Parse(row.Cells.FromKey("EMP_REF_ID").Value.ToString())
                                 , int.Parse(row.Cells.FromKey("KPI_REF_ID").Value.ToString())
                                 , itxr_user);
                    }
                }
                catch (Exception ex)
                {
                    PageUtility.AlertMessage(ex.Message);
                    return;
                }

                cntRow += 1;
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
