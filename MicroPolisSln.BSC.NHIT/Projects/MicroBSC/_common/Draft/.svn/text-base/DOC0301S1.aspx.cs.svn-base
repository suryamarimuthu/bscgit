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
using System.Drawing.Drawing2D;
using System.IO;

using Infragistics.WebUI.UltraWebGrid;
using MicroCharts;
using Dundas.Charting.WebControl;

using MicroBSC.BSC.Biz;
using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;

public partial class _common_Draft_DOC0301S1 : PrjPageBase
{
    #region 변수선언

    private decimal TOTAL_MONTHLY_AMOUNT = 0;
    private decimal TOTAL_AMOUNT = 0;
    private decimal TOTAL_RATE = 0;
    private int TOTAL_CNT = 0;

    public int IPrjRefID
    {
        get
        {
            if (ViewState["PRJ_REF_ID"] == null)
            {
                ViewState["PRJ_REF_ID"] = GetRequestByInt("PRJ_REF_ID", 0);
            }

            return (int)ViewState["PRJ_REF_ID"];
        }
        set
        {
            ViewState["PRJ_REF_ID"] = value;
        }
    }
   

    public int IEstLevel
    {
        get
        {
            if (ViewState["EST_LEVEL"] == null)
            {
                ViewState["EST_LEVEL"] = GetRequestByInt("EST_LEVEL", 0);
            }

            return (int)ViewState["EST_LEVEL"];
        }
        set
        {
            ViewState["EST_LEVEL"] = value;
        }
    }

    public int IEstEmpID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
            {
                ViewState["EST_EMP_ID"] = GetRequestByInt("EST_EMP_ID", 0);
            }

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }

    public int IKpiPoolRefID
    {
        get
        {
            if (ViewState["KPI_POOL_REF_ID"] == null)
            {
                ViewState["KPI_POOL_REF_ID"] = GetRequestByInt("KPI_POOL_REF_ID", 0);
            }

            return (int)ViewState["KPI_POOL_REF_ID"];
        }
        set
        {
            ViewState["KPI_POOL_REF_ID"] = value;
        }
    }

    public string IChampionEmpYN
    {
        get
        {
            if (ViewState["CHAMPION_EMP_YN"] == null)
            {
                ViewState["CHAMPION_EMP_YN"] = GetRequest("CHAMPION_EMP_YN", "N");
            }

            return (string)ViewState["CHAMPION_EMP_YN"];
        }
        set
        {
            ViewState["CHAMPION_EMP_YN"] = value;
        }
    }

    public string IApprovalEmpYN
    {
        get
        {
            if (ViewState["APPROVAL_EMP_YN"] == null)
            {
                ViewState["APPROVAL_EMP_YN"] = GetRequest("APPROVAL_EMP_YN", "N");
            }

            return (string)ViewState["APPROVAL_EMP_YN"];
        }
        set
        {
            ViewState["APPROVAL_EMP_YN"] = value;
        }
    }

    public string ICheckStatus
    {
        get
        {
            if (ViewState["CHECKSTATUS"] == null)
            {
                ViewState["CHECKSTATUS"] = GetRequest("CHECKSTATUS", "N");
            }

            return (string)ViewState["CHECKSTATUS"];
        }
        set
        {
            ViewState["CHECKSTATUS"] = value;
        }
    }

    public string IConfirmStatus
    {
        get
        {
            if (ViewState["CONFIRMSTATUS"] == null)
            {
                ViewState["CONFIRMSTATUS"] = GetRequest("CONFIRMSTATUS", "N");
            }

            return (string)ViewState["CONFIRMSTATUS"];
        }
        set
        {
            ViewState["CONFIRMSTATUS"] = value;
        }
    }

    public string IYearlyClose_YN
    {
        get
        {
            if (ViewState["YEARLY_CLOSE_YN"] == null)
            {
                ViewState["YEARLY_CLOSE_YN"] = GetRequest("YEARLY_CLOSE_YN");
            }
            return (string)ViewState["YEARLY_CLOSE_YN"];
        }
        set
        {
            ViewState["YEARLY_CLOSE_YN"] = value;
        }
    }

    public string IMontylyClose_YN
    {
        get
        {
            if (ViewState["MONTHLY_CLOSE_YN"] == null)
            {
                ViewState["MONTHLY_CLOSE_YN"] = GetRequest("MONTHLY_CLOSE_YN", "Y");
            }
            return (string)ViewState["MONTHLY_CLOSE_YN"];
        }
        set
        {
            ViewState["MONTHLY_CLOSE_YN"] = value;
        }
    }

    public string IisPassCloseDay
    {
        get
        {
            if (ViewState["IS_PASS_CLOSE_DAY"] == null)
            {
                ViewState["IS_PASS_CLOSE_DAY"] = GetRequest("IS_PASS_CLOSE_DAY");
            }
            return (string)ViewState["IS_PASS_CLOSE_DAY"];
        }
        set
        {
            ViewState["IS_PASS_CLOSE_DAY"] = value;
        }
    }
    
    public string IisAdmin
    {
        get
        {
            if (ViewState["IS_ADMIN"] == null)
            {
                ViewState["IS_ADMIN"] = GetRequest("IS_ADMIN", "N");
            }

            return (string)ViewState["IS_ADMIN"];
        }
        set
        {
            ViewState["IS_ADMIN"] = value;
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetPrjInfoData();
            this.SetShareGrid();
            this.SetResourceGrid();
            this.SetPrjTaskGrid();
            this.SetTaskOwnerGrid();
            this.SetTaskShareGrid();
            this.SetBudgetGrid();
            this.SetKpiPrjGrid();
        }
    }

    #region 내부함수
    //===================================: PRJ기본정보 조회
    private void SetInitForm()
    {

    }

    private void SetPrjInfoData()
    {
        Biz_Prj_Info objPrjInfo = new Biz_Prj_Info(IPrjRefID);
        Biz_Com_Code_Info objPrjPriority = new Biz_Com_Code_Info("PM001",objPrjInfo.IPriority);
        Biz_Com_Code_Info objPrjType = new Biz_Com_Code_Info("PM002", objPrjInfo.IPrj_Type);

        lblPRJCode.Text         = objPrjInfo.IPrj_Code;
        lblPRJName.Text         = objPrjInfo.IPrj_Name;
        lblPRJDefinition.Text   = objPrjInfo.IDefinition;
        lblPlanStartDate.Text   = DataTypeUtility.GetToDateTimeText(objPrjInfo.IPlan_Start_Date);
        lblPlanEndDate.Text     = DataTypeUtility.GetToDateTimeText(objPrjInfo.IPlan_End_Date);
        lblActualStartDate.Text = DataTypeUtility.GetToDateTimeText(objPrjInfo.IActual_Start_Date);
        lblActualEndDate.Text   = DataTypeUtility.GetToDateTimeText(objPrjInfo.IActual_End_Date);
        hdfPrjType.Value        = objPrjInfo.IPrj_Type;
        lblPRJTypeName.Text     = objPrjType.Icode_name;
        hdfOwnerDeptID.Value    = objPrjInfo.IOwner_Dept_Id.ToString();
        lblOwnerDeptName.Text   = objPrjInfo.IOwner_Dept_Name;
        hdfOwnerEmpID.Value     = objPrjInfo.IOwner_Emp_Id.ToString();
        lblOwnerEmpName.Text    = objPrjInfo.IOwner_Emp_Name;
        lblRequestDept.Text     = objPrjInfo.IRequest_Dept;
        lblPriorityName.Text    = objPrjPriority.Icode_name;
        hdfPriority.Value       = objPrjInfo.IPriority;
        lblTotalBudget.Text     = objPrjInfo.ITotal_Budget.ToString("###,##0") + " 원";
        lblInterested.Text      = objPrjInfo.IInterested_Parties;
        lblRefStg.Text          = objPrjInfo.IRef_Stg;
        lblEffectiveness.Text   = objPrjInfo.IEffectiveness;
        lblRange.Text           = objPrjInfo.IRange;
    }

    //===================================: 사업공유정보 조회
    private void SetShareGrid()
    {
        Biz_Prj_Share objPrjShare = new Biz_Prj_Share();
        grdProjectShareList.DataSource = objPrjShare.GetAllList(this.IPrjRefID, 0).Tables[0].DefaultView;
        grdProjectShareList.DataBind();
    }

    //===================================: 사업수행구성원 조회
    private void SetResourceGrid()
    {
        Biz_Prj_Resource prjResource = new Biz_Prj_Resource();
        ugrdResourceList.DataSource = prjResource.GetAllList(this.IPrjRefID, 0).Tables[0].DefaultView;
        ugrdResourceList.DataBind();
    }

    //===================================: 사업일정 조회
    private void SetPrjTaskGrid()
    {
       BindSchedule("TASK_REF_ID", "UP_TASK_REF_ID");
    }


    //===================================: 작업수행담당자 조회
    private void SetTaskOwnerGrid()
    {
        Biz_Prj_Task_Owner objTaskOwner = new Biz_Prj_Task_Owner();
        grdTaskOwnerList.DataSource = objTaskOwner.GetAllList(this.IPrjRefID, 0, 0).Tables[0].DefaultView;
        grdTaskOwnerList.DataBind();
    }

    //===================================: 일정공유자 조회
    private void SetTaskShareGrid()
    {
        Biz_Prj_Task_Share objTaskShare = new Biz_Prj_Task_Share();

        grdTaskShareList.DataSource = objTaskShare.GetAllList(this.IPrjRefID, 0, 0).Tables[0].DefaultView;
        grdTaskShareList.DataBind();
    }

    //===================================: 비용관리 조회
    private void SetBudgetGrid()
    {
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IPrjRefID);
        Biz_Prj_Resource prjResource = new Biz_Prj_Resource();
        Biz_Prj_Budget objBud = new Biz_Prj_Budget();

        if (this.IPrjRefID == 0)
            return;

        DataSet ds = objBud.SelectMonthRateList(this.IPrjRefID);
        DataTable dt = objBud.GetDataTableSchema();
        DateTime dtStart = DataTypeUtility.GetToDateTime(objPrj.IPlan_Start_Date);
        DateTime dtEnd = DataTypeUtility.GetToDateTime(objPrj.IPlan_End_Date);

        for (DateTime date = dtStart; date <= dtEnd; )
        {
            TOTAL_CNT++;

            DataRow dataRow = null;

            dataRow = GetBudGetYM(ds.Tables[0], date.ToString("yyyyMM"));

            if (dataRow == null)
            {
                dataRow = dt.NewRow();

                dataRow["ITYPE"] = "A";
                dataRow["PRJ_REF_ID"] = this.IPrjRefID;
                dataRow["BUDGET_YM"] = date.ToString("yyyyMM");
                dataRow["BUDGET_YM_NAME"] = date.ToString("yyyy년 MM월");
                dataRow["MONTHLY_AMOUNT"] = 0;
                dataRow["AMOUNT"] = 0;
                dataRow["RATE"] = 0;

                dt.Rows.Add(dataRow);
            }
            else
            {
                dt.ImportRow(dataRow);
            }

            date = date.AddMonths(1);
        }

        grdBudgetList.DataSource = dt.DefaultView;
        grdBudgetList.DataBind();

        lblTOTAL_MONTHLY_AMOUNT.Text = TOTAL_MONTHLY_AMOUNT.ToString("###,##0");
        lblTOTAL_AMOUNT.Text = TOTAL_AMOUNT.ToString("###,##0");

        decimal tmpVar = (TOTAL_RATE / TOTAL_CNT);
        lblTOTAL_RATE.Text = tmpVar.ToString("##0.#0");
    }

    //===================================: KPI연계 조회
    private void SetKpiPrjGrid()
    {
        Biz_Bsc_Kpi_Prj objKpiPrj = new Biz_Bsc_Kpi_Prj();

        objKpiPrj.IEstterm_Ref_Id = base.ESTTERM_REF_ID;
        objKpiPrj.IKpi_Ref_Id = 0;
        objKpiPrj.IPrj_Ref_Id = this.IPrjRefID;

        DataSet ds = objKpiPrj.GetAllList(objKpiPrj.IEstterm_Ref_Id, objKpiPrj.IKpi_Ref_Id, objKpiPrj.IPrj_Ref_Id);
      
        grdKpiPrjList.DataSource = ds.Tables[0].DefaultView;
        grdKpiPrjList.DataBind();
    }

    private DataRow GetBudGetYM(DataTable dt, string budgetYM)
    {
        DataRow dataRow = null;

        foreach (DataRow row in dt.Rows)
        {
            if (row["BUDGET_YM"].ToString() == budgetYM)
            {
                dataRow = row;
                break;
            }
        }

        return dataRow;
    }

    private DataTable GetDataTableSchema()
    {
        DataTable dataTable = new DataTable();


        dataTable.Columns.Add("PRJ_REF_ID", typeof(int));
        dataTable.Columns.Add("TASK_REF_ID", typeof(int));
        dataTable.Columns.Add("TASK_NAME", typeof(string));
        dataTable.Columns.Add("TASK_TYPE", typeof(string));
        dataTable.Columns.Add("TASK_TYPE_NAME", typeof(string));
        dataTable.Columns.Add("UP_TASK_REF_ID", typeof(int));
        dataTable.Columns.Add("TASK_CODE", typeof(string));
        dataTable.Columns.Add("PLAN_START_DATE", typeof(DateTime));
        dataTable.Columns.Add("PLAN_END_DATE", typeof(DateTime));
        dataTable.Columns.Add("ACTUAL_START_DATE", typeof(DateTime));
        dataTable.Columns.Add("ACTUAL_END_DATE", typeof(DateTime));
        dataTable.Columns.Add("PROCEED_RATE", typeof(decimal));
        dataTable.Columns.Add("TASK_WEIGHT", typeof(decimal));
        dataTable.Columns.Add("ATT_FILE", typeof(string));

        return dataTable;
    }
    public void BindSchedule(string valueStr, string up_valueStr)
    {
        DataTable dataTable = GetDataTableSchema();

        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        DataSet ds = objSchedule.GetAllList(this.IPrjRefID, 0);

        object oRate = objSchedule.GetTotalRate(this.IPrjRefID, 0);

        if (ds.Tables.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["UP_TASK_REF_ID"] == DBNull.Value | ds.Tables[0].Rows[i]["UP_TASK_REF_ID"].ToString() == "0")
                {
                    ds.Tables[0].Rows[i]["PROCEED_RATE"] = DataTypeUtility.GetString(oRate);
                    break;
                }
            }
        }

        ds.Relations.Add("NodeRelation"
                        , ds.Tables[0].Columns[valueStr]
                        , ds.Tables[0].Columns[up_valueStr]
                        , false);

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            DataTable dt = ds.Tables[0];

            if (DataTypeUtility.GetToInt32(dbRow[up_valueStr]) == 0)
            {
                dataTable.Rows.Add(MakeDataRow(dataTable, dbRow));

                PopulateSchedule(dbRow, dataTable);
            }
        }

        grdTaskList.DataSource =  dataTable.DefaultView;
        grdTaskList.DataBind();
    }

    private DataRow MakeDataRow(DataTable blankTable, DataRow dr)
    {
        DataRow dataRow = blankTable.NewRow();
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info("PM003", DataTypeUtility.GetValue(dr["TASK_TYPE"]));

        string space = this.GetnSpace(DataTypeUtility.GetToInt32(dr["NODE_DEPTH"]));

        dataRow["PRJ_REF_ID"]               = dr["PRJ_REF_ID"];
        dataRow["TASK_REF_ID"]              = dr["TASK_REF_ID"];
        dataRow["TASK_NAME"]                = space + dr["TASK_NAME"];
        dataRow["TASK_TYPE"]                = dr["TASK_TYPE"];
        dataRow["TASK_TYPE_NAME"]           = objCode.Icode_name;
        dataRow["UP_TASK_REF_ID"]           = dr["UP_TASK_REF_ID"];
        dataRow["TASK_CODE"]                = dr["TASK_CODE"];
        dataRow["PLAN_START_DATE"]          = dr["PLAN_START_DATE"];
        dataRow["PLAN_END_DATE"]            = dr["PLAN_END_DATE"];
        dataRow["ACTUAL_START_DATE"]        = dr["ACTUAL_START_DATE"];
        dataRow["ACTUAL_END_DATE"]          = dr["ACTUAL_END_DATE"];
        dataRow["PROCEED_RATE"]             = dr["PROCEED_RATE"];
        dataRow["TASK_WEIGHT"]              = dr["TASK_WEIGHT"];
        dataRow["ATT_FILE"]                 = dr["ATT_FILE"];

        return dataRow;
    }

    private string GetnSpace(int depth)
    {
        string strSpace = "";
        string strUnit = "&nbsp;&nbsp;";

        for (int i = 0; i <= depth; i++)
        {
            strSpace += strUnit;
        }
        return strSpace;
    }

    private void PopulateSchedule(DataRow dbRow
                                , DataTable callbackDataTable
                                 )
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            callbackDataTable.Rows.Add(MakeDataRow(callbackDataTable, childRow));

            PopulateSchedule(childRow, callbackDataTable);
        }
    }
    #endregion
  
    protected void grdBudgetList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text != "&nbsp;")
                TOTAL_MONTHLY_AMOUNT += DataTypeUtility.GetToDecimal(e.Row.Cells[1].Text);

            if(e.Row.Cells[2].Text != "&nbsp;")
                TOTAL_AMOUNT         += DataTypeUtility.GetToDecimal(e.Row.Cells[2].Text);

            if (e.Row.Cells[3].Text != "&nbsp;")
                TOTAL_RATE += DataTypeUtility.GetToDecimal(e.Row.Cells[3].Text);

            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {

        }
    }
    protected void ugrdResourceList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            //e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            //e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[4].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            //e.Row.Cells[5].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            //e.Row.Cells[6].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            //e.Row.Cells[7].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            //e.Row.Cells[8].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            //e.Row.Cells[9].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            //e.Row.Cells[10].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {

        }
    }
    protected void grdKpiPrjList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {

        }
    }
    protected void grdTaskList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.TextAlign, "left");
            e.Row.Cells[9].Style.Add(HtmlTextWriterStyle.TextAlign, "right");
            e.Row.Cells[10].Style.Add(HtmlTextWriterStyle.TextAlign, "right");

            string sFile = DataBinder.Eval(e.Row.DataItem, "ATT_FILE").ToString();
            System.Web.UI.WebControls.ImageButton imgFile = (System.Web.UI.WebControls.ImageButton)e.Row.FindControl("imgFile");

            if (sFile == "")
            {
                imgFile.Visible = false;
            }
            else
            {
                System.Web.UI.WebControls.HiddenField hdfFile = (System.Web.UI.WebControls.HiddenField)e.Row.FindControl("hdfFile");
                hdfFile.Value = sFile;

                imgFile.OnClientClick = "return mfUpload('"+ hdfFile.ClientID +"'); return false;";
            }
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {

        }
    }

    protected void grdProjectShareList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.TextAlign  , "left");
            e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.PaddingLeft, "2px");
        }
    }
}
