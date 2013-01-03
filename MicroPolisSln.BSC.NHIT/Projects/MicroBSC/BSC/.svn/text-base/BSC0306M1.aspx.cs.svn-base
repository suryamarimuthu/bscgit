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

public partial class BSC_BSC0306M1 : AppPageBase
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

    int emp_ref_id = 0;
    int iestterm_ref_id = 0;
    int ikpi_ref_id = 0;

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
        ugrdKpiList.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

        SetAllTimeTop();

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();

            SetDashBoardKpiGrid();
            //SetKpiPoolGrid();
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

        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.getResultMethod(ddlResultInput, "", true, 0);
        objCode.GetKpiType(ddlKpiGroupRefID, "", true, 0);
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
        SetDashBoardKpiGrid();
        SetKpiPoolGrid();
    }

    #endregion

    #region 내부 함수


    public void SetDashBoardKpiGrid()
    {

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();
        DataSet rDs = objBSC.GetDashBoardKpiList(this.IEstTermRefID);


        ugrdKPIPool.Clear();
        ugrdKPIPool.DataSource = rDs.Tables[0].DefaultView;
        ugrdKPIPool.DataBind();

        //lblCountRow.Text = "Total Rows : " + ds.Tables[0].Rows.Count.ToString();
    }

    public void SetKpiPoolGrid()
    {

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Info();

        objBSC.Iestterm_ref_id = this.IEstTermRefID;
        objBSC.Iresult_input_type = ddlResultInput.SelectedValue;
        objBSC.Ikpi_code = txtKPICode.Text.Trim();
        objBSC.Ikpi_name = txtKPIName.Text.Trim();
        objBSC.Ichampion_emp_name = txtChamName.Text.Trim();
        int iest_dept_id = (ddlEstDept.SelectedValue.Trim() == "") ? -1 : int.Parse(ddlEstDept.SelectedValue);
        objBSC.Iuse_yn = "";
        objBSC.Itxr_user = int.Parse(gUserInfo.Emp_Ref_ID.ToString());

        DataSet ds = objBSC.GetDashBoardKpiList(
                                 objBSC.Iestterm_ref_id
                               , objBSC.Iresult_input_type
                               , objBSC.Ikpi_code
                               , objBSC.Ikpi_name
                               , objBSC.Iuse_yn
                               , objBSC.Ichampion_emp_name
                               , iest_dept_id
                               , PageUtility.GetByValueDropDownList(ddlKpiGroupRefID)
                               , objBSC.Itxr_user);

        ugrdKpiList.Clear();
        ugrdKpiList.DataSource = ds;
        ugrdKpiList.DataBind();

    }
    #endregion

    #region 서버 이벤트 처리 함수


    protected void lBtnReload_Click(object sender, EventArgs e)
    {

    }

    protected void ugrdKPIPool_InitializeRow(object sender, RowEventArgs e)
    {
        //e.Row.Cells.FromKey("ITYPE").Value = "U";

        DropDownList ddlTempSelectType;
        TemplatedColumn unit_col = (TemplatedColumn)e.Row.Band.Columns.FromKey("SELECT_TYPE");

        ddlTempSelectType = (DropDownList)((CellItem)unit_col.CellItems[e.Row.BandIndex]).FindControl("ddlSelectType");

     
        ddlTempSelectType.Items.Add(new ListItem("달성율", "ACRATE"));
        ddlTempSelectType.Items.Add(new ListItem("실 적", "RESULT"));
        ddlTempSelectType.Items.Add(new ListItem("계 획", "TARGET"));
        
       
        PageUtility.FindByValueDropDownList(ddlTempSelectType, e.Row.Cells.FromKey("SELECT_TYPE").Value.ToString());



        DropDownList ddlTempGraphType;
        TemplatedColumn graph_col = (TemplatedColumn)e.Row.Band.Columns.FromKey("GRAPH_TYPE");

        ddlTempGraphType = (DropDownList)((CellItem)graph_col.CellItems[e.Row.BandIndex]).FindControl("ddlGraphType");

        //ArrayList alGraphType = new ArrayList();
        //alGraphType.Add("LINE");
        //alGraphType.Add("FASTLINE");
        //alGraphType.Add("BAR");
        //alGraphType.Add("COLUMN");
        //alGraphType.Add("SPLINE");
        //alGraphType.Add("STEPLINE");

        //foreach (string str in alGraphType.ToArray(typeof(string)))
        //{
        //    ddlTempGraphType.Items.Add(new ListItem(str.ToString(), str.ToString()));
        //}

        WebCommon.SetDundasChartType(ddlTempGraphType);

        PageUtility.FindByValueDropDownList(ddlTempGraphType, e.Row.Cells.FromKey("GRAPH_TYPE").Value.ToString());


        DropDownList ddlTempSortOrder;
        TemplatedColumn sort_col = (TemplatedColumn)e.Row.Band.Columns.FromKey("SORT_ORDER");

        ddlTempSortOrder = (DropDownList)((CellItem)sort_col.CellItems[e.Row.BandIndex]).FindControl("ddlSortOrder");

        for (int i = 1; i < 9; i++)
        {
            ddlTempSortOrder.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        PageUtility.FindByValueDropDownList(ddlTempSortOrder, e.Row.Cells.FromKey("SORT_ORDER").Value.ToString());


    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetComDeptDropDownList(ddlEstDept, true);
        this.IEstTermRefID = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        SetDashBoardKpiGrid();
        SetKpiPoolGrid();
    }


    #endregion



    protected void ugrdKpiList_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg         = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("APPROVAL_STATUS");
        objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";
    }

   
    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        int cntAffRow = this.SaveDashBoardKpi();
        SetDashBoardKpiGrid();
    }
    protected void iBtnAddKpi_Click(object sender, ImageClickEventArgs e)
    {
        if (this.CheckCount())
        {
            int cntAffRow = this.AddKpiDashBoard();
            SetDashBoardKpiGrid();
            SetKpiPoolGrid();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("지표를 8개까지만 등록 가능합니다.", false);
        }
    }
    protected void iBtnRemoveKpi_Click(object sender, ImageClickEventArgs e)
    {
        int cntAffRow = this.RemoveKpiDashBoard();
        SetDashBoardKpiGrid();
        SetKpiPoolGrid();
    }

    protected int AddKpiDashBoard()
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK          = false;
        string isSuccessed = "0";
        int intTxrUser     = gUserInfo.Emp_Ref_ID;
        int intRtn         = 0;
        int intRow         = ugrdKpiList.Rows.Count;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();

        for (int i = 0; i < intRow; i++)
        {
            row = ugrdKpiList.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

             if (chk.Checked)
            {
                chk.Checked = false;

                int iKpiCode = Convert.ToInt32(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                int iEstterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
                int iuser = intTxrUser;


                intRtn += objBSC.InsertData(iEstterm_ref_id
                                          , iKpiCode
                                          , "TARGET"
                                          , "LINE"
                                          , 1
                                          , gUserInfo.Emp_Ref_ID);
            }
        }

        return intRtn;
    }

    protected int RemoveKpiDashBoard()
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        string isSuccessed = "0";
        int intTxrUser = gUserInfo.Emp_Ref_ID;
        int intRtn = 0;
        int intRow = ugrdKPIPool.Rows.Count;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();

        for (int i = 0; i < intRow; i++)
        {
            row = ugrdKPIPool.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;


                //ltrScript.Text = JSHelper.GetAlertScript("그룹을 선택해주십시오.", false);


                int iKpiCode = Convert.ToInt32(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                int iEstterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
                int iuser = intTxrUser;


                intRtn += objBSC.DeleteData(iEstterm_ref_id
                                          , iKpiCode
                                          , gUserInfo.Emp_Ref_ID);
            }
        }

        return intRtn;
    }

    protected int SaveDashBoardKpi()
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        string isSuccessed = "0";
        int intTxrUser = gUserInfo.Emp_Ref_ID;
        int intRtn = 0;
        int intRow = ugrdKPIPool.Rows.Count;

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Dashboard();

        DropDownList ddlTempSelectType;
        TemplatedColumn selecttype_col = (TemplatedColumn)ugrdKPIPool.Columns.FromKey("SELECT_TYPE");

        DropDownList ddlTempGraphType;
        TemplatedColumn graphtype_col = (TemplatedColumn)ugrdKPIPool.Columns.FromKey("GRAPH_TYPE");

        DropDownList ddlTempSortOrder;
        TemplatedColumn sortorder_col = (TemplatedColumn)ugrdKPIPool.Columns.FromKey("SORT_ORDER");



        for (int i = 0; i < intRow; i++)
        {
            row = ugrdKPIPool.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (true)
            {
                chk.Checked = false;



                int iKpiCode = Convert.ToInt32(row.Cells.FromKey("KPI_REF_ID").Value.ToString());
                int iEstterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
                ddlTempSelectType = (DropDownList)((CellItem)selecttype_col.CellItems[ugrdKPIPool.Rows[i].BandIndex]).FindControl("ddlSelectType");
                //string iSelect_type = row.Cells.FromKey("SELECT_TYPE").ToString();
                ddlTempGraphType = (DropDownList)((CellItem)graphtype_col.CellItems[ugrdKPIPool.Rows[i].BandIndex]).FindControl("ddlGraphType");

                //string iGraph_type = Convert.ToString(row.Cells.FromKey("GRAPH_TYPE").Value);

                ddlTempSortOrder = (DropDownList)((CellItem)sortorder_col.CellItems[ugrdKPIPool.Rows[i].BandIndex]).FindControl("ddlSortOrder");


               // int iSort_order = Convert.ToInt32(row.Cells.FromKey("SORT_ORDER").Value.ToString());
                int iuser = intTxrUser;


                intRtn += objBSC.UpdateData(iEstterm_ref_id
                                          , iKpiCode
                                          , ddlTempSelectType.SelectedValue
                                          , ddlTempGraphType.SelectedValue
                                          , Convert.ToInt32(ddlTempSortOrder.SelectedValue)
                                          , gUserInfo.Emp_Ref_ID);
            }
        }

        return intRtn;
    }

    private bool CheckCount()
    {
        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        int ugrdKPIPoolrow = ugrdKPIPool.Rows.Count;
        int ugrdKpiListrow = ugrdKpiList.Rows.Count;
        int checkCnt = 0;
        bool res = false;

        if (ugrdKPIPoolrow == 8)
        {
            res = false;
        }
        else
        {
            checkCnt = ugrdKPIPoolrow;

            for (int i = 0; i < ugrdKpiList.Rows.Count; i++)
            {
                row = ugrdKpiList.Rows[i];
                col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");
                if (chk.Checked)
                {
                    checkCnt++; 
                }
            }

            if (checkCnt > 8)
            {
                res = false;
            }
            else
            {
                res = true;
            }
        }

        return res;
    }


    
}
