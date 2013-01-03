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
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class BSC_BSC0307M1 : AppPageBase
{

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                //   ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    int emp_ref_id      = 0;
    int iestterm_ref_id = 0;
    int ikpi_ref_id     = 0;
    int icntKpiUse      = 0;
    int icntKpiAll      = 0;

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }


    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();

            SetKpiNormdistGroupGrid();
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
        emp_ref_id = EMP_REF_ID;
        ltrScript.Text = "";
    }

    private void InitControlValue()
    {

        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        this.IEstTermRefID = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        this.SetApplyNormdistGroupDropDownList(ddlNormdistYN, true);


        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlResultInput, "", true, 120);
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 120);
        objCode.GetKpiNormdistGroup(ddlNormdistGroup, 0, false, 300);

        objCode.GetKpiNormdistGroup(ddlsNormdistGroup, -1, true,100);


        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        PageUtility.FindByValueDropDownList(ddlNormdistGroup, 0);

        

    }

    private void InitControlEvent()
    {

    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }
    #endregion

    #region 초기 세팅 메소드

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetKpiNormdistGroupGrid();
    }

    #endregion

    #region 내부 함수


    public void SetKpiNormdistGroupGrid()
    {

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Normdist_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Normdist_Group();

        objBSC.Iestterm_ref_id = this.IEstTermRefID;
        objBSC.Iresult_input_type = ddlResultInput.SelectedValue;
        objBSC.Ikpi_code = txtKPICode.Text.Trim();
        objBSC.Ikpi_name = txtKPIName.Text.Trim();
        objBSC.Ichampion_emp_name = txtChamName.Text.Trim();
        int iest_dept_id = (ddlEstDept.SelectedValue.Trim() == "") ? -1 : int.Parse(ddlEstDept.SelectedValue);
        objBSC.Iuse_yn = "";
        objBSC.Itxr_user = int.Parse(gUserInfo.Emp_Ref_ID.ToString());
        objBSC.INormdistGroup = (ddlsNormdistGroup.SelectedValue.Trim() == "") ? "" : ddlsNormdistGroup.SelectedValue.ToString();
        objBSC.INormdist_Use_YN = (ddlNormdistYN.SelectedValue.Trim() == "") ? "": ddlNormdistYN.SelectedValue.ToString();

        DataSet ds = objBSC.GetNormdistList(
                                 objBSC.Iestterm_ref_id
                               , objBSC.Iresult_input_type
                               , objBSC.Ikpi_code
                               , objBSC.Ikpi_name
                               , objBSC.Iuse_yn
                               , objBSC.Ichampion_emp_name
                               , iest_dept_id
                               , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                               , objBSC.INormdistGroup
                               , objBSC.INormdist_Use_YN 
                               , objBSC.Itxr_user);

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = ds;
        ugrdKpiList.DataBind();

        //lblCountRow.Text = "Total Rows : " + ds.Tables[0].Rows.Count.ToString();

    }
    #endregion

    #region 서버 이벤트 처리 함수


    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }

  

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        this.IEstTermRefID = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        SetKpiNormdistGroupGrid();
    }


    #endregion



    protected void ugrdKpiList_InitializeRow(object sender, RowEventArgs e)
    {

        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("NORMDIST_USE_YN");
        Image objImg         = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        string strUseYn      = (e.Row.Cells.FromKey("NORMDIST_USE_YN") == null) ? "N" : e.Row.Cells.FromKey("NORMDIST_USE_YN").Value.ToString();

        objImg.ImageUrl      = (strUseYn == "Y") ? "../images/icon_o.gif" : "../images/icon_x.gif";

        if (strUseYn == "Y")
        {
            icntKpiUse += 1;
        }
        icntKpiAll     += 1;

        lblCountRow.Text = string.Format("Total Rows : {0} / {1}", icntKpiUse.ToString(), icntKpiAll.ToString());
    }

    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        int cntAffRow = this.UpdateKpiNormdistGroup();

        ltrScript.Text = JSHelper.GetAlertScript("누적확률그룹을 설정하였습니다.", false);
        SetKpiNormdistGroupGrid();
    }

    protected void iBtnUseYN_Click(object sender, ImageClickEventArgs e)
    {
        int cntAffRow = this.UpdateKpiNormdistUseYN();

        ltrScript.Text = JSHelper.GetAlertScript("누적확률그룹사용안함으로 설정하였습니다.", false);
        SetKpiNormdistGroupGrid();
    }

    protected int UpdateKpiNormdistGroup()
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        string isSuccessed = "0";
        int intTxrUser = gUserInfo.Emp_Ref_ID;
        int intRtn = 0;
        int intRow = ugrdKpiList.Rows.Count;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Normdist_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Normdist_Group();

        for (int i = 0; i < intRow; i++)
        {
            row = ugrdKpiList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;

               
                int iEstterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
                int iKpiCode = Convert.ToInt32(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                string iNormdistGroup = PageUtility.GetByValueDropDownList(ddlNormdistGroup);


                intRtn += objBSC.InsertData(iEstterm_ref_id
                                          , iKpiCode
                                          , iNormdistGroup
                                          , "Y"
                                          , intTxrUser);
            }
        }

        return intRtn;
    }

    protected int UpdateKpiNormdistUseYN()
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        string isSuccessed = "0";
        int intTxrUser = gUserInfo.Emp_Ref_ID;
        int intRtn = 0;
        int intRow = ugrdKpiList.Rows.Count;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Normdist_Group objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Normdist_Group();

        for (int i = 0; i < intRow; i++)
        {
            row = ugrdKpiList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;


                int iEstterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
                int iKpiCode = Convert.ToInt32(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                string iNormdistGroup = Convert.ToString(row.Cells.FromKey("NORMDIST_GROUP").Value.ToString());
                


                intRtn += objBSC.UpdateData(iEstterm_ref_id
                                          , iKpiCode
                                          , iNormdistGroup
                                          , "N"
                                          , intTxrUser);
            }
        }

        return intRtn;
    }

    private void SetApplyNormdistGroupDropDownList(DropDownList ddList, bool isDefalutText)
    {
        ddList.Items.Add(new ListItem("적  용", "Y"));
        ddList.Items.Add(new ListItem("미적용", "N"));
        if (isDefalutText)
        {
            ddList.Items.Insert(0, new ListItem(":: 전체 ::", ""));
        }
        ddList.SelectedIndex = 0;
    }
   
}
