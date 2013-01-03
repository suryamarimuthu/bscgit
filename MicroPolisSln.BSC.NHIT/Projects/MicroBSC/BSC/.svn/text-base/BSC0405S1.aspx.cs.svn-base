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

using Dundas.Charting.WebControl;
using MicroCharts;
using System.Drawing;
using Infragistics.WebUI.UltraWebGrid;
public partial class BSC_BSC0405S1 : AppPageBase
{    
    #region 변수 선언부

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


    #endregion

    #region 페이지 초기화

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


    private void SetAllTimeTop()
    {

    }

    private void InitControlValue()
    {
        BindBadKpiInfo();
    }


    private void InitControlEvent()
    {

    }


    private void SetPageData()
    {

    }


    private void SetPostBack()
    {

    }


    private void SetAllTimeBottom()
    {

    }

    #endregion



    #region 내부함수


    private void BindBadKpiInfo()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi biz = new MicroBSC.BSC.Biz.Biz_Bsc_Map_Kpi();
        DataSet ds = biz.GetBadKpiListPreviousMonth(this.IEstTermRefID, this.IEstDeptID, this.IYmd, "MS");

        this.ugrdBadKPIInfo.DataSource = ds;
        this.ugrdBadKPIInfo.DataBind();
    }

    #endregion

    
    // [인터페이스 실적 확인] 
    protected void ugrdBadKPIInfo_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
        UltraGridCell cell;

        float RESULT = 0;
        float TARGET = 0;
        string imgSignal = "";


        // 신호 이미지
        cell = e.Row.Cells.FromKey("IMAGE_FILE_NAME");
        string img = "../images/stg/" + cell.Value.ToString();

        imgSignal = String.Format("<img alt='' src='{0}'/>", img);

        e.Row.Cells.FromKey("SIGNAL").Text = imgSignal;
    }
}
