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

using MicroBSC.Data;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;

public partial class BSC_BSC0406S3 : AppPageBase
{
    private int    _iestterm_ref_id;
    private string _iresult_input_method;
    //private string _ikpi_code;
    //private string _ikpi_name;
    //private string _iemp_name;
    private int _iest_dept_ref_id;
    private int    _ilogin_id;
    private string _iymd;
    private int    _ithreshold_ref_id;
    private int _istg_ref_id;
    private AppPageUtility objNum;

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

    public int IEstDeptID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public string IYmd
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public int IStgRefID
    {
        get
        {
            if (ViewState["STG_REF_ID"] == null)
            {
                ViewState["STG_REF_ID"] = GetRequestByInt("STG_REF_ID", 0);
            }

            return (int)ViewState["STG_REF_ID"];
        }
        set
        {
            ViewState["STG_REF_ID"] = value;
        }
    }



    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();

        if (!Page.IsPostBack)
        {
            InitControlValue();
            InitControlEvent();

            SetResultGrid();
        }
    }


    #region 페이지 초기화 함수

    private void SetAllTimeTop()
    {
        objNum = new AppPageUtility(this.Page);
    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;

        //Biz_EtcCodeInfos objCode = new Biz_EtcCodeInfos();
        //objCode.getResultMethod(ddlResultInput, "", true, 80);

        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        WebCommon.SetSumTypeDropDownList(ddlSumType, false);
        //WebCommon.SetSortTypeDropDownList(ddlOrderType, true);

        //this.SetSignalDropDownList(ddlSignal, true);

        Biz_Bsc_Stg_Info objStg = new Biz_Bsc_Stg_Info(this.IEstTermRefID, this.IStgRefID);
        lblStg_Name.Text = objStg.Istg_name;

        Biz_Bsc_Map_Info objDept = new Biz_Bsc_Map_Info(this.IEstTermRefID, this.IEstDeptID, this.IYmd);
        lblEst_Dept_Name.Text = objDept.Iest_dept_name;

        ugrdResultStatus.Columns.FromKey("CHAMPION_EMP_NAME").Header.Caption = this.GetText("LBL_00001", "KPI담당자");

    }

    private void InitControlEvent()
    {
        //txtCntKpi.Style.Add("ime-mode", "disabled");
        //txtCntKpi.Style.Add("text-align", "right");
        //txtCntKpi.Attributes.Add("onkeydown", "return gfChkInputNum(-1, 0)");
    }

    private void SetPageData()
    {
        _iestterm_ref_id = this.IEstTermRefID;
        _iest_dept_ref_id = this.IEstDeptID;
        _iymd = this.IYmd;
        _istg_ref_id = this.IStgRefID;
        _ilogin_id            = gUserInfo.Emp_Ref_ID;
        _ithreshold_ref_id = 0;
        
    }

    #endregion

    #region 내부함수

    private void SetSignalDropDownList(System.Web.UI.WebControls.DropDownList ddList, bool isDefalutText)
    {
        WebCommon.SetSignalDropDownList(ddList, true);
    }

    private void SetResultGrid()
    {
        this.SetPageData();
        Biz_Bsc_Map_Kpi objBSC = new Biz_Bsc_Map_Kpi();

        DataSet ds              = objBSC.GetKpiStgResultAnalysis(_iestterm_ref_id
                                                                       , _iest_dept_ref_id
                                                                       , _iymd
                                                                       , PageUtility.GetByValueDropDownList(ddlSumType)
                                                                       , _istg_ref_id );

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ugrdResultStatus.Clear();
            ugrdResultStatus.DataSource = ds.Tables[0];
            ugrdResultStatus.DataBind();
        }
    }

    

    #endregion

    #region 서버이벤트
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetResultGrid();
    }

    protected void ugrdResultStatus_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

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

        e.Row.Cells.FromKey("SIGNAL_IMAGE").Value   = "<div align=center><img src='../images/" + e.Row.Cells.FromKey("SIGNAL_IMAGE").Value.ToString() + "'></div>";

     
            e.Row.Cells.FromKey("RANK").Style.BackColor = System.Drawing.Color.FromName("#CEE2F4");
      
        

        
        string kpi_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_REF_ID").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string url = "<a href='#' onclick='doPoppingUp_Grid(\"{0}\",\"{1}\",\"{2}\")'>{3}</a>";
        string link = string.Format(url, IEstTermRefID, kpi_ref_id, IYmd, kpi_name);

        e.Row.Cells.FromKey("KPI_NAME").Value = link;

        
    }

    protected void ugrdResultStatus_InitializeLayout(object sender, LayoutEventArgs e)
    {
      
            e.Layout.Bands[0].Columns.FromKey("RANK").Hidden    = true;
            e.Layout.Bands[0].Columns.FromKey("KPI_NAME").Width = 200;

    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        this.SetResultGrid();
    }
    #endregion
}
