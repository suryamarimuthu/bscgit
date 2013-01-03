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
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.BSC.Biz;
using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Integration.COM.Biz;

public partial class BSC_BSC0406S1 : AppPageBase
{
    private int _ilogin_id;
    private int _ithreshold_ref_id;
    private int _iTRow = 0;

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.hdfDeptID.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }


    public int Estterm_Ref_ID
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

    public int Est_Dept_Ref_ID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"]    = GetRequestByInt("EST_DEPT_REF_ID", -1);
                hdfDeptID.Value                 = ViewState["EST_DEPT_REF_ID"].ToString();
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"]    = value;
            hdfDeptID.Value                 = value.ToString();
        }
    }

    public string Sum_Type
    {
        get
        {
            if (ViewState["SUM_TYPE"] == null)
            {
                ViewState["SUM_TYPE"] = GetRequest("SUM_TYPE", "MS");
            }

            return ViewState["SUM_TYPE"].ToString();
        }
        set
        {
            ViewState["SUM_TYPE"] = value;
        }
    }


    public string Ymd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }
            return ViewState["YMD"].ToString();
        }
        set
        {
            ViewState["YMD"] = value;
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
    
    public int VIEWROLE;//임원, 팀장, 사원 구분

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ugrdResultStatus.DisplayLayout.Bands[0].Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

        ltrScript.Text = "?";
        if (!Page.IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
            WebCommon.SetSumTypeDropDownList(ddlSumType, false);
            WebCommon.SetSignalDropDownList(ddlSignal, true);

            SetPageData();

            if (Request["ESTTERM_REF_ID"] != null) 
            {
                Estterm_Ref_ID  = GetRequestByInt("ESTTERM_REF_ID");
                Est_Dept_Ref_ID = GetRequestByInt("EST_DEPT_REF_ID");
                hdfDeptID.Value = Est_Dept_Ref_ID.ToString();
                Ymd             = GetRequest("YMD");

                PageUtility.FindByValueDropDownList(ddlEstTermInfo, Est_Dept_Ref_ID);
                PageUtility.FindByValueDropDownList(ddlMonthInfo, Ymd);

            
                //처음로그인시 사용자 부서로 초기 세팅
                Est_Dept_Ref_ID = int.Parse(DataTypeUtility.GetValue(gUserInfo.Dept_Ref_ID));
                hdfDeptID.Value = Est_Dept_Ref_ID.ToString();
            }
            else
            {
                Estterm_Ref_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
            }

            this.IisAdmin = (User.IsInRole(ROLE_ADMIN) ? "Y" : "N");

            if (this.IisAdmin == "Y")
            {

                //WebCommon.SetComDeptDropDownList(ddlDeptList, true, gUserInfo.Emp_Ref_ID);
                //PageUtility.FindByValueDropDownList(ddlDeptList, this.IDEPT_ID);
                Est_Dept_Ref_ID = int.Parse(DataTypeUtility.GetValue(gUserInfo.Dept_Ref_ID));
                WebCommon.SetComDeptDropDownList(ddlDeptList, false, gUserInfo.Emp_Ref_ID);
                PageUtility.FindByValueDropDownList(ddlDeptList, Est_Dept_Ref_ID);
            }
            else
            {
                BindDeptList();

            }
            Est_Dept_Ref_ID = int.Parse(DataTypeUtility.GetValue(gUserInfo.Dept_Ref_ID));
            SetPageData();
            SetResultGrid();
            //WebCommon.FillEstTree(trvEstDept, Estterm_Ref_ID, gUserInfo.Emp_Ref_ID);

            //SetResultGrid();
        }
    }

    protected void BindDeptList()
    {
        Biz_Com_Dept_Info bizComDeptInfo = new Biz_Com_Dept_Info();
        DataTable dt = bizComDeptInfo.Get_Dept_UpDept_List();


        VIEWROLE = 0;
        for (int i = 0; i < EMP_ROLES.Count; i++)
        {
            int emp_role = DataTypeUtility.GetToInt32(EMP_ROLES[i]);

            if (emp_role == 2)
            {
                //임원권한
                VIEWROLE = 2;
                dt = DataTypeUtility.FilterSortDataTable(dt, string.Format("UP_DEPT_ID='{0}'", gUserInfo.Dept_Ref_ID));
                break;
            }
            else if (emp_role == 4)
            {
                //팀장권한
                VIEWROLE = 4;
                dt = DataTypeUtility.FilterSortDataTable(dt, string.Format("DEPT_ID='{0}'", gUserInfo.Dept_Ref_ID));
                break;
            }
            else if (emp_role == 5)
            {
                //사원권한
                VIEWROLE = 5;
                dt = DataTypeUtility.FilterSortDataTable(dt, string.Format("DEPT_ID='{0}'", gUserInfo.Dept_Ref_ID));
                break;
            }
        }


        DataTable dt_result = new DataTable();
        dt_result.Columns.Add("DEPT_REF_ID");
        dt_result.Columns.Add("DEPT_NAME");


        if (dt.Rows.Count > 0)
        {
            if (VIEWROLE == 2 || VIEWROLE == 4)
            {
                DataRow dr = dt_result.NewRow();

                dr["DEPT_REF_ID"] = DataTypeUtility.GetString(dt.Rows[0]["UP_DEPT_ID"]);
                dr["DEPT_NAME"] = DataTypeUtility.GetString(dt.Rows[0]["UP_DEPT_NAME"]);

                dt_result.Rows.Add(dr);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt_result.NewRow();

                dr["DEPT_REF_ID"] = DataTypeUtility.GetString(dt.Rows[0]["DEPT_ID"]);
                dr["DEPT_NAME"] = DataTypeUtility.GetString(dt.Rows[0]["DEPT_NAME"]);

                dt_result.Rows.Add(dr);
            }
        }

        ddlDeptList.DataTextField = "DEPT_NAME";
        ddlDeptList.DataValueField = "DEPT_REF_ID";
        ddlDeptList.DataSource = dt_result;
        ddlDeptList.DataBind();
    }


    private void SetPageData()
    {
        Estterm_Ref_ID    = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        Est_Dept_Ref_ID   = int.Parse(hdfDeptID.Value);
        Ymd               = (ddlMonthInfo.Items.Count > 0) ? ddlMonthInfo.SelectedValue : "";
        Sum_Type          = ddlSumType.SelectedValue;
        _ilogin_id        = gUserInfo.Emp_Ref_ID;
        
        if (ddlSignal.Items.Count > 0)
        {
            _ithreshold_ref_id = (ddlSignal.SelectedValue == "") ? 0 : PageUtility.GetIntByValueDropDownList(ddlSignal);
        }        
    }

    #region 내부함수

    private void SetResultGrid()
    {
        if (Est_Dept_Ref_ID.ToString() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가부서를 선택하십시오.", false);
            return;
        }

        Biz_Bsc_Map_Kpi biz = new Biz_Bsc_Map_Kpi();
        DataSet ds          = biz.GetKpiAnalysisPerEstDept(Estterm_Ref_ID
            , Est_Dept_Ref_ID
                                                            , Ymd
                                                            , _ithreshold_ref_id
                                                            , Sum_Type);
        ugrdResultStatus.Clear();
        ugrdResultStatus.DataSource = ds;
        ugrdResultStatus.DataBind();
    }

    #endregion

    #region 서버이벤트
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SetPageData();
        SetResultGrid();
    }

    protected void ugrdResultStatus_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        UltraGridCell cell;

        cell                                        = e.Row.Cells.FromKey("THRESHOLD_IMG");
        string img                                  = "../images/stg/" + cell.Value.ToString();
        e.Row.Cells.FromKey("THRESHOLD_IMG").Text   = string.Format("<img alt='' src='{0}'/>", img);

        if (dr["CHECK_YN"].ToString() == "N")
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("CHECK_YN").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        string strTrend = e.Row.Cells.FromKey("TREND").Value.ToString();

        switch (strTrend)
        {
            case "UP":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_e_up.gif'>"; ;
                break;
            case "DOWN":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_b_down.gif'>"; ;
                break;
            case "FLAT":
                e.Row.Cells.FromKey("TREND").Value = "<img class='KPI' border='0' src='../images/arrow/arrow_m.gif'>"; ;
                break;
            default:
                break;
        }

        _iTRow += 1;

        lblRowCount.Text = _iTRow.ToString();




        string kpi_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_REF_ID").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string url = "<a href=\"javascript:gfOpenWindow('../BSC/BSC0304P1.aspx?iType=POP&ESTTERM_REF_ID={0}&KPI_REF_ID={1}&YMD={2}',800,600,'no','no');\" style=\"color:Navy;\">{3}</a>";


        e.Row.Cells.FromKey("KPI_NAME").Text = string.Format(url
                                                           , Estterm_Ref_ID
                                                           , kpi_ref_id
                                                           , Ymd
                                                           , kpi_name);

    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        //PopupControlExtender1.Commit(trvEstDept.SelectedNode.Text);
        //PopupControlExtender2.Commit(trvEstDept.SelectedNode.Value);
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Estterm_Ref_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        hdfDeptID.Value  = "";
        ugrdResultStatus.Clear();
    }
    #endregion
}
