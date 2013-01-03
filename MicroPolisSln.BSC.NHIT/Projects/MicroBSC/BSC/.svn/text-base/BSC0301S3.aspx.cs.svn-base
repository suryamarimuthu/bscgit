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

using System.Data;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

public partial class BSC_BSC0301S3 : AppPageBase
{
    #region 변수선언
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_','$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }
    #endregion

    #region 페이지 초기화 함수
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
        BizUtility.KPI_POOL_LIST =

        ltrScript.Text = "";
    }


    private void SetAllTimeTop()
    {
        
    }

    private void InitControlValue()
    {
        WebCommon.SetUseYnDropDownList(ddlUseYn, true);
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiType,"", true, 0);

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver bizBscKpiPoolVer = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver();

        DataTable dtBscKpiPoolVer = bizBscKpiPoolVer.GetBscKpiPoolVer_DB();

        ddlKpiVersion.DataValueField = "KPI_POOL_VER_ID";
        ddlKpiVersion.DataTextField = "KPI_POOL_VER_NAME";
        ddlKpiVersion.DataSource = dtBscKpiPoolVer;
        ddlKpiVersion.DataBind();

        ddlKpiVersion.Items.Insert(0, new ListItem(":: 전체 ::", "0"));

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete bizBscKpiPoolTemplete = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete();

        DataTable dtBscKpiPoolTemplete = bizBscKpiPoolTemplete.GetBscKpiPoolTemplete_DB();

        ddlKpiTemplete.DataValueField = "KPI_POOL_TEMPLETE_ID";
        ddlKpiTemplete.DataTextField = "KPI_POOL_TEMPLETE_NAME";
        ddlKpiTemplete.DataSource = dtBscKpiPoolTemplete;
        ddlKpiTemplete.DataBind();

        ddlKpiTemplete.Items.Insert(0, new ListItem(":: 전체 ::", "0"));
    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        this.SetKpiPoolGrid();
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }
    
    #endregion

    #region 내부 함수

    public void SetKpiPoolGrid()
    {
        //MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        //DataSet ds = objBSC.GetAllList(txtKPIName.Text.Trim(), 
        //                               PageUtility.GetByValueDropDownList(ddlKpiType),
        //                               PageUtility.GetByValueDropDownList(ddlUseYn));

        //ugrdKPIPool.Clear();
        //ugrdKPIPool.DataSource = ds.Tables[0].DefaultView;
        //ugrdKPIPool.DataBind();

        //lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();


        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool bizBscKpiPool = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool();

        DataTable dtBscKpiPool = bizBscKpiPool.GetKpiPool_DB(txtKPIName.Text.Trim(),
                                                           PageUtility.GetByValueDropDownList(ddlKpiType),
                                                           PageUtility.GetByValueDropDownList(ddlUseYn),
                                                           DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlKpiVersion)),
                                                           DataTypeUtility.GetToInt32(PageUtility.GetByValueDropDownList(ddlKpiTemplete)));

        ugrdKPIPool.Clear();
        ugrdKPIPool.DataSource = dtBscKpiPool;
        ugrdKPIPool.DataBind();

        lblRowCount.Text = dtBscKpiPool.Rows.Count.ToString();
    }
        
    #endregion

    #region 서버 이벤트 처리 함수

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        this.SetKpiPoolGrid();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetKpiPoolGrid();
    }

    protected void ugrdKPIPool_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        

        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);
        string kpi_pool_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value);
        string iType = DataTypeUtility.GetValue(e.Row.Cells.FromKey("USE_YN").Value).Equals("Y") ? "U":"D";

        string link = "<a href='#null' onclick=\"doInsertingKpi('{0}','{1}','{2}')\">{3}</a>";
        string url = string.Format(link, iType, kpi_pool_ref_id, ICCB1, kpi_name);

        e.Row.Cells.FromKey("KPI_NAME").Value = url;
    }



    protected void iBtnVersion_Click(object sender, ImageClickEventArgs e)
    {
        int cnt = ugrdKPIPool.Rows.Count;

        string kpi_pool_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = ugrdKPIPool.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                kpi_pool_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("KPI_POOL_REF_ID").Value);
            }
        }

        if (kpi_pool_id_list.Length > 0)
        {
            BizUtility.KPI_POOL_LIST = kpi_pool_id_list.Remove(0, 1);
        }

        string url = "BSC0301M3.aspx";
        string str = string.Format("gfOpenWindow('{0}', 800, 400, false, false, '_bk');", url);
        ltrScript.Text = JSHelper.GetSclipt(str);
    }

    protected void iBtnTemplete_Click(object sender, ImageClickEventArgs e)
    {
        int cnt = ugrdKPIPool.Rows.Count;

        string kpi_pool_id_list = string.Empty;

        for (int i = 0; i < cnt; i++)
        {
            UltraGridRow row = ugrdKPIPool.Rows[i];

            TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

            if (cBox.Checked)
            {
                kpi_pool_id_list += "," + DataTypeUtility.GetValue(row.Cells.FromKey("KPI_POOL_REF_ID").Value);
            }
        }

        if (kpi_pool_id_list.Length > 0)
        {
            BizUtility.KPI_POOL_LIST = kpi_pool_id_list.Remove(0, 1);
        }

        string url = "BSC0301M4.aspx";
        string str = string.Format("gfOpenWindow('{0}', 800, 400, false, false, '_bk');", url);
        ltrScript.Text = JSHelper.GetSclipt(str);
    }

    

    #endregion
}
