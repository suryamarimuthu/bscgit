using System;
using System.Data;
using System.Web.UI;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Estimation.Dac;
using DeptInfos=MicroBSC.Estimation.Dac.DeptInfos;
using MicroBSC.Biz.BSC.Dac;
using MicroBSC.Common;

public partial class usr_usr10002 : AppPageBase
{
    private int ESTTERM_REF_ID                          = 0;
    private int EST_DEPT_REF_ID                         = 0;
    private int TMCODE                                  = 0;

    DeptInfos                           _estDeptInfo    = new DeptInfos();
    Biz_Bsc_Map_Info                    _stgMapInfo     = new Biz_Bsc_Map_Info();
    Biz_Bsc_Score_Card                  _score_card     = new Biz_Bsc_Score_Card();

    private int IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
                ViewState["YMD"] = DataTypeUtility.GetToInt32(DateTime.Now.ToString("yyyyMM"));
            return (int)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    private int IMAP_VERSION_ID
    {
        get
        {
            if (ViewState["MAP_VERSION_ID"] == null)
                ViewState["MAP_VERSION_ID"] = 1;
            return (int)ViewState["MAP_VERSION_ID"];
        }
        set
        {
            ViewState["MAP_VERSION_ID"] = value;
        }
    }

    public bool ViewKPI
    {
        get
        {
            if (Session["VIEW_KPI"] == null)
                Session["VIEW_KPI"] = true;

            return (bool)Session["VIEW_KPI"];
        }
        set
        {
            Session["VIEW_KPI"] = value;
        }
    }

    public bool IExtKpiYN
    {
        get
        {
            if (ViewState["EXT_KPI_YN"] == null)
            {
                ViewState["EXT_KPI_YN"] = (GetRequest("EXT_KPI_YN", "Y") == "Y") ? true : false;
            }

            return (bool)ViewState["EXT_KPI_YN"];
        }
        set
        {
            ViewState["EXT_KPI_YN"] = value;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        SetQueryStringData();

        if (EST_DEPT_REF_ID == 0)
        {
            Biz_EstDeptOrgDetails estDeptOrgDetail  = new Biz_EstDeptOrgDetails();
            EST_DEPT_REF_ID                         = estDeptOrgDetail.GetEstDeptRefID(ESTTERM_REF_ID, EMP_REF_ID);
            if (EST_DEPT_REF_ID < 1)
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "noAccess", JSHelper.GetAlertBackScript("권한이 없습니다."));
            }
        }

        if (!IsPostBack)
        {
            WebCommon.FillEstTree(trvEstDept, ESTTERM_REF_ID, EMP_REF_ID);
            txtDeptID.Text = EST_DEPT_REF_ID.ToString();

            WebCommon.SetExternalScoreCheckBox(chkApplyExtScore, ESTTERM_REF_ID);
            chkApplyExtScore.Checked = this.IExtKpiYN;

            ViewKPI = true;

            SetCtrlSetting(ESTTERM_REF_ID
                        , int.Parse(txtDeptID.Text));
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (txtDropDown.Text.Equals(""))
        {
            DeptInfos deptInfo = new DeptInfos(EST_DEPT_REF_ID);
            txtDropDown.Text = deptInfo.Dept_Name;
        }
    }

    private void SetCtrlSetting(int estterm_ref_id, int est_dept_ref_id) 
    {
        Biz_Bsc_Work_Map bizMap = new Biz_Bsc_Work_Map();
        //DataSet dsMap = bizMap.GetWorkMapTotalList(estterm_ref_id, est_dept_ref_id);
        DataSet dsMap = bizMap.GetWorkMapTotalListHeader_DB(estterm_ref_id, est_dept_ref_id);
        if (dsMap.Tables[0].Rows.Count > 0)
        {
            ltrStgMapVision.Text = dsMap.Tables[0].Rows[0]["DEPT_VISION"].ToString();
            ltrStgMapChamp.Text = dsMap.Tables[0].Rows[0]["BSCCHAMPION_NAME"].ToString();
            this.IMAP_VERSION_ID = DataTypeUtility.GetToInt32(dsMap.Tables[0].Rows[0]["MAP_VERSION_ID"]);
        }

        Biz_Bsc_Term_Detail bizTerm = new Biz_Bsc_Term_Detail();
        string strYMD = bizTerm.GetReleasedMonth();
        this.IYMD = (strYMD == "000000" ? DataTypeUtility.GetToInt32(DateTime.Now.ToString("yyyyMM")) : DataTypeUtility.GetToInt32(strYMD));
        SetViewScoreGrid(estterm_ref_id, est_dept_ref_id, this.IYMD);

        string view_kpi_str = (ViewKPI) ? "1" : "0";

        string url = "../usr/usr_stg_map.aspx?ESTTERM_REF_ID=" + estterm_ref_id.ToString()
                                    + "&EST_DEPT_REF_ID="   + est_dept_ref_id.ToString()
                                    + "&MAP_VERSION_ID=" + this.IMAP_VERSION_ID
                                    + "&TMCODE=" + this.IYMD
                                    + "&LINE_TYPE=0"
                                    + "&SHOW_KPI_LIST="     + view_kpi_str
                                    + "&WORKINGMAPYN=T";

        ifm.Attributes.Add("src", Server.UrlDecode(url));
    }

    private void SetQueryStringData() 
    {
        if (GetRequest("ESTTERM_REF_ID").Equals(""))
        {
            TermInfos term  = new TermInfos();
            DataView dw     = term.GetAllTermInfo().Tables[0].DefaultView;

            for (int i = 0; i < dw.Table.Rows.Count; i++)
            {
                if (Convert.ToInt32(dw.Table.Rows[i]["EST_STATUS"]) == 1)
                {
                    ESTTERM_REF_ID = int.Parse(dw.Table.Rows[i]["ESTTERM_REF_ID"].ToString());
                    return;
                }
            }
        }
        else
        {
            ESTTERM_REF_ID = GetRequestByInt("ESTTERM_REF_ID");
        }

        if (GetRequest("EST_DEPT_REF_ID").Equals(""))
        {
            EST_DEPT_REF_ID = _estDeptInfo.GetRootEstDeptID(ESTTERM_REF_ID);
        }
        else
        {
            EST_DEPT_REF_ID = GetRequestByInt("EST_DEPT_REF_ID");
        }
    }
    
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (txtDeptID.Text == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("부서를 선택해 주십시오", false);
            return;
        }

        Dac_EmpComDeptDetails objBSC = new Dac_EmpComDeptDetails();
        bool blnRtn = objBSC.IsAccessRightEstDept
                             (ESTTERM_REF_ID
                            , int.Parse(txtDeptID.Text)
                            , gUserInfo.Emp_Ref_ID);

        if (!blnRtn)
        { 
            ltrScript.Text = JSHelper.GetAlertScript("조회할 권한이 없습니다.", false);
            return;
        }

        this.IExtKpiYN = chkApplyExtScore.Checked;

        SetCtrlSetting(ESTTERM_REF_ID
                        //, PageUtility.GetIntByValueDropDownList(ddlEstDept)
                        , int.Parse(txtDeptID.Text));
    }

    private void SetViewScoreGrid(int estterm_ref_id, int est_dept_ref_id, int tmcode)
    {
        ultraLegend.Clear();
        ultraLegend.DataSource = _score_card.GetEstDeptTotalScoreForMap(estterm_ref_id, tmcode.ToString(), "MS", est_dept_ref_id, this.IExtKpiYN);
        ultraLegend.DataBind();
    }

    protected void ultraLegend_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        if (e.Row.Cells.FromKey("VIEW_REF_ID").Value.ToString() == "0")
        {
            e.Row.Style.Font.Bold                           = true;
            e.Row.Cells.FromKey("SCORE").Style.ForeColor    = System.Drawing.Color.Red;
            e.Row.Cells.FromKey("WEIGHT").Style.ForeColor   = System.Drawing.Color.Red;
        }
        else
        {
            e.Row.Cells.FromKey("VIEW_NAME").Value          = "&nbsp;&nbsp;" + e.Row.Cells.FromKey("VIEW_NAME").Value;
        }

        e.Row.Cells.FromKey("DASH").Value                   = "/";
    }

    protected string GetKpiMapUrl()
    {
        string view_kpi_str = (ViewKPI) ? "1" : "0";
        string url = "../usr/usr_stg_map.aspx?EST_DEPT_REF_ID=" + EST_DEPT_REF_ID + "&ESTTERM_REF_ID=" + ESTTERM_REF_ID + "&MAP_VERSION_ID=" 
            + this.IMAP_VERSION_ID + "&TMCODE=" + this.IYMD + "&LINE_TYPE=0&SHOW_KPI_LIST=" + view_kpi_str + "&WORKINGMAPYN=Y&DRAWING_YN=N";
        return url;
    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        PopupControlExtender1.Commit(trvEstDept.SelectedNode.Text);
        PopupControlExtender2.Commit(trvEstDept.SelectedNode.Value);
    }
    protected void iBtnVisibleKPI_Click(object sender, ImageClickEventArgs e)
    {
        SetCtrlSetting(ESTTERM_REF_ID
                        , int.Parse(txtDeptID.Text));
    }
}
