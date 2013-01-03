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
using Infragistics.WebUI.UltraWebToolbar;
using System.Xml;
using MicroBSC.Common;

using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;


public partial class PRJ_PRJ0102S2 : PrjPageBase
{
    private PrjScheuldeWeekDataProvider _prjScheuldeWeekDataProvider = null;
    private int _iPrjRefID = 0;
    private int _iTaskRefID = 0;
    private string _readOnlyYN = "N";


    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public int IPrjRefID
    {
        get { return _iPrjRefID; }
        set { _iPrjRefID = value; }
    }

    public string READ_ONLY_YN
    {
        get { return _readOnlyYN; }
        set { _readOnlyYN = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        txtYear.ValueChange += new Infragistics.WebUI.WebDataInput.ValueChangeHandler(txtYear_ValueChange);
        if (!IsPostBack)
        {
            this.SetFormInit();
        }
        else
        {
            //BindSchedule();

        }

       
        ltrScript.Text = "";

       
    }


    #region 내부 함수
    public void SetFormInit()
    {
        Biz_Com_Code_Info codeinfo = new Biz_Com_Code_Info();
        codeinfo.GetProjectType(ddlPrjType, -1, true, 120);

        ListItem itemA = new ListItem(":: 전체 ::", "0");
        ddlPrjName.Items.Insert(0, itemA);

        this.WebWeekView1.StyleSheetFileName = "./styles/Office2007Blue/ig_webweekview.css";
        txtYear.Value = DateTime.Now.Year;
    }

    private void BindSchedule()
    {
        _iPrjRefID = WebUtility.GetIntByValueDropDownList(ddlPrjName);

        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        objSchedule.IPrj_Ref_Id = IPrjRefID;
        DataSet ds = objSchedule.GetUserAllList(objSchedule.IPrj_Ref_Id, 0, gUserInfo.Emp_Ref_ID);

        if (ds.Tables.Count == 0 && ds.Tables[0].Rows.Count == 0)
            return;

        DataSet tmpDs = ds.Clone();

        ds.Relations.Add("NodeRelation"
                        , ds.Tables[0].Columns["TASK_REF_ID"]
                        , ds.Tables[0].Columns["UP_TASK_REF_ID"]
                        , false);

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (DataTypeUtility.GetToInt32(dbRow["UP_TASK_REF_ID"]) == 0)
            {
                tmpDs.Tables[0].ImportRow(dbRow);
                PopulateScheduleTree(dbRow, tmpDs);
            }
        }

        _prjScheuldeWeekDataProvider = new PrjScheuldeWeekDataProvider(tmpDs.Tables[0]);
        _prjScheuldeWeekDataProvider.WebScheduleInfo = this.WebScheduleInfo1;

        this.WebScheduleInfo1.AppointmentFormPath = "./PRJ0102M1.aspx?PRJ_REF_ID=" + _iPrjRefID + "&TASK_REF_ID=";
        this.WebScheduleInfo1.ReminderFormPath = "./PRJ0102M1.aspx?PRJ_REF_ID=" + _iPrjRefID + "&TASK_REF_ID=" + _iTaskRefID;

        this.WebWeekView1.AppointmentFormatString = "<SUBJECT>";
        this.WebWeekView1.AppointmentTooltipFormatString = "<DESCRIPTION><NEW_LINE><SUBJECT>";

        // 프로젝트 책임자 또는 사업구성원이 아닐경우
        Biz_Prj_Info objPrj = new Biz_Prj_Info();
        Biz_Prj_Resource objRes = new Biz_Prj_Resource(this._iPrjRefID, gUserInfo.Emp_Ref_ID);

        if (!objPrj.IsOwnerEmpIDYN(gUserInfo.Emp_Ref_ID, this.IPrjRefID)
            || (objRes == null))
        {
            _readOnlyYN = "Y";
        }
        else
        {
            _readOnlyYN = "N";
        }
    }

    private void PopulateScheduleTree(DataRow dbRow, DataSet ds)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            ds.Tables[0].ImportRow(childRow);

            PopulateScheduleTree(childRow, ds);
        }
    }

    #endregion


    
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindSchedule();
    }
    protected void ddlPrjType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iYear = 0;
        bool isInt = int.TryParse(txtYear.Value.ToString(), out iYear);

        WebCommon.SetProjectListDropDownList(ddlPrjName, true, EMP_REF_ID, PageUtility.GetByValueDropDownList(ddlPrjType), iYear);
    }
    void txtYear_ValueChange(object sender, Infragistics.WebUI.WebDataInput.ValueChangeEventArgs e)
    {
        int iYear = 0;
        bool isInt = int.TryParse(txtYear.Value.ToString(), out iYear);

        WebCommon.SetProjectListDropDownList(ddlPrjName, true, EMP_REF_ID, PageUtility.GetByValueDropDownList(ddlPrjType), iYear);
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        BindSchedule();
    }

    protected void WebWeekView1_Load(object sender, EventArgs e)
    {
        if (PageUtility.GetByValueDropDownList(ddlPrjType) == "" ||
            PageUtility.GetByValueDropDownList(ddlPrjName) == "")
        {
            WebWeekView1.Reset();
            return;
        }

        BindSchedule();
    }
}
