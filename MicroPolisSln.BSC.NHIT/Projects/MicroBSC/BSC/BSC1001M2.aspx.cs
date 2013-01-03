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
using Infragistics.WebUI.WebDataInput;
using Infragistics.WebUI.UltraWebTab;
using MicroBSC.QueryEngine.QueryBuilder;

using Syncfusion.XlsIO;

public partial class BSC_BSC1001M2 : AppPageBase
{
    #region ==========================[변수선언]================
    public string ICCB1
    {
        get
        {
            if (ViewState["IS_TEAM_KPI"] == null)
            {
                ViewState["IS_TEAM_KPI"] = GetRequest("IS_TEAM_KPI", "N");
            }

            return (string)ViewState["IS_TEAM_KPI"];
        }
        set
        {
            ViewState["IS_TEAM_KPI"] = value;
        }
    }

    public int ESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", -1);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    protected int IDEPT_ID
    {
        get
        {
            if (ViewState["DEPT_ID"] == null)
                ViewState["DEPT_ID"] = 0;
            return (int)ViewState["DEPT_ID"];
        }
        set
        {
            ViewState["DEPT_ID"] = value;
        }
    }

    public string TEMPLETE_ID
    {
        get
        {
            if (ViewState["TEMPLETE_ID"] == null)
            {
                ViewState["TEMPLETE_ID"] = GetRequest("TEMPLETE_ID", "-1");
            }

            return (string)ViewState["TEMPLETE_ID"];
        }
        set
        {
            ViewState["TEMPLETE_ID"] = value;
        }
    }

    public string TEMPLETE_NAME
    {
        get
        {
            if (ViewState["TEMPLETE_NAME"] == null)
            {
                ViewState["TEMPLETE_NAME"] = GetRequest("TEMPLETE_NAME", "");
            }

            return (string)ViewState["TEMPLETE_NAME"];
        }
        set
        {
            ViewState["TEMPLETE_NAME"] = value;
        }
    }

    #endregion

    #region 폼초기화
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            DoInitializing();
            this.NotPostBackSetting();
            DoBindingTemplete();
        }
        else
        {
            this.PostBackSetting();
        }

        ltrScript.Text = "";

    }

    private void NotPostBackSetting()
    {
        WebCommon.SetUnitTypeDropDownList(ddlUnit_Hdf, false);
    }

    private void PostBackSetting()
    {
        /* 2011-06-03 수정 : 저장을 하거나 PostBack이후에 단위가 사라지는 현상을 방지 */
        WebCommon.SetUnitTypeDropDownList(ddlUnit_Hdf, false);
        /* 2011-06-03 수정 완료 *********************************************************/
    }

    #endregion

    

    #region ================================= [ 서버이벤트 ]================================
    

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }
    

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        object[] objList = GetSelectKpiList(UltraWebGrid2);

        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail();
        DataSet dsYear = objTerm.GetTermDetail(ESTTERM_REF_ID);
        if (dsYear.Tables[0].Rows.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가년도를 확인하세요.");
            return;
        }

        string result_measurement_step = "LV5";
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info bizComCodeInfo = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        DataTable dtComCodeInfo = bizComCodeInfo.getCheckStep(0).Tables[0];

        DataRow[] rows = dtComCodeInfo.Select(" USE_YN = 'Y' ", "SORT_ORDER DESC");
        if (rows.Length > 0)
        {
            result_measurement_step = DataTypeUtility.GetValue(rows[0]["ETC_CODE"]);
        }

        int unit_type_ref_id = 1;
        MicroBSC.Biz.Common.Biz.Biz_Com_Unit_Type_Info bizComUnitTypeInfo = new MicroBSC.Biz.Common.Biz.Biz_Com_Unit_Type_Info();
        DataTable dtComUnitTypeInfo = bizComUnitTypeInfo.GetAllList().Tables[0];
        if (dtComUnitTypeInfo.Rows.Count > 0)
        {
            unit_type_ref_id = DataTypeUtility.GetToInt32(dtComUnitTypeInfo.Rows[0]["UNIT_TYPE_REF_ID"]);
        }

        Biz_Bsc_Threshold_Step bizBscThresholdStep = new Biz_Bsc_Threshold_Step();
        DataTable dtBscThresholdStep = bizBscThresholdStep.GetThresholdLevelList(result_measurement_step).Tables[0];

        int checkCount = 0;
        for (int i = 0; i < objList.Length; i++)
        {
            checkCount += new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info().KpiInfoExsistCheckPerson(int.Parse(objList[i].ToString()), gUserInfo.Emp_Ref_ID, ESTTERM_REF_ID);
        }

        if (checkCount > 0)
        {
            Response.Write("<script>alert('중복되는 KPI 풀입니다.');</script>");
        }
        else
        {
            MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info bizBscKpiInfo = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info();
            string returnStr = bizBscKpiInfo.CopyKpiToMboUsingTemplete(ESTTERM_REF_ID
                                                                      , objList
                                                                      , TEMPLETE_ID
                                                                      , TEMPLETE_NAME
                                                                      , gUserInfo.Emp_Ref_ID
                                                                      , DateTime.Now.ToString("yyyy-MM-dd")
                                                                      , result_measurement_step
                                                                      , unit_type_ref_id
                                                                      , "PRS"
                                                                      , dtBscThresholdStep);

            if (returnStr.Equals(string.Empty))
            {
                DoBindingTemplete();
                ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("복사를 완료하였습니다.", true);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript(returnStr);
            }
        }
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {

        if (e.SelectedRows.Count > 0)
        {
            int kpi_pool_templete_id = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("KPI_POOL_TEMPLETE_ID").Value);
            DoBindingTempleteMap(kpi_pool_templete_id);
        }
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TEMPLETE_ID   = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_POOL_TEMPLETE_ID").Value);
        TEMPLETE_NAME = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_POOL_TEMPLETE_NAME").Value);

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete_Map bizBscKpiPoolTempleteMap = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete_Map();

        DataTable dtBscKpiPoolTempleteMap = bizBscKpiPoolTempleteMap.GetBscKpiPoolTempleteMap_DB(TEMPLETE_ID);

        e.Row.Cells.FromKey("KPI_CNT").Value = dtBscKpiPoolTempleteMap.Rows.Count;
    }

    protected void ugrdDeptKpi_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void ugrdDeptKpi_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        CheckBox chkCheck;
        TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");

        chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("cBox");

        //e.Row.Cells.FromKey("APP_STATUS_NAME").Value = "Y";

        //if (e.Row.Cells.FromKey("APP_STATUS").Value != null)
        //{
        //    if (e.Row.Cells.FromKey("APP_STATUS").Value.ToString() != Biz_Type.app_status_complete)
        //    {
        //        chkCheck.Enabled = false;
        //        e.Row.Cells.FromKey("APP_STATUS_NAME").Value = "N";
        //    }
        //}

        //DataRowView drv = (DataRowView)e.Data;
        //if (drv["COM_DEPT_REF_ID"].ToString() != this.IDEPT_ID.ToString())
        //    chkCheck.Enabled = false;


        
        string kpi_code = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value);
        string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        string onclick = "<a href='#null' onclick=\"doLinking_Pool('{0}')\">{1}</a>";
        string link = string.Format(onclick, kpi_code, kpi_name);
        e.Row.Cells.FromKey("KPI_NAME").Value = link;
    }

    protected void ibtnSearchLeft_Click(object sender, ImageClickEventArgs e)
    {
        DoBindingTemplete();
    }

    #endregion

    private void DoInitializing()
    {
        this.IDEPT_ID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);

        //WebCommon.SetComDeptDropDownList(ddlComDeptLeft, true, gUserInfo.Emp_Ref_ID);

        //ddlComDeptLeft.SelectedValue = IDEPT_ID.ToString();
        //ddlComDeptLeft.Enabled = false;
    }

    


    private object[] GetSelectKpiList(UltraWebGrid grid)
    {
        object[] objTemp = new object[grid.Rows.Count];
        int objCnt = 0;
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            UltraGridRow gr = grid.Rows[i];
            CheckBox chkCheck;
            TemplatedColumn Col_Check = (TemplatedColumn)gr.Band.Columns.FromKey("selchk");

            chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[gr.BandIndex]).FindControl("cBox");
            if (chkCheck.Checked)
            {
                objTemp[objCnt] = DataTypeUtility.GetToInt32(gr.Cells.FromKey("KPI_POOL_REF_ID").Value);
                objCnt++;
            }
        }

        objCnt = 0;
        for (int i = 0; i < objTemp.Length; i++)
        {
            if (objTemp[i] == null)
                break;
            objCnt++;
        }
        if (objCnt == 0)
            return null;
        object[] rtnObj = new object[objCnt];

        for (int i = 0; i < rtnObj.Length; i++)
            rtnObj[i] = objTemp[i];
        return rtnObj;
    }

    private void DoBindingTemplete()
    {
        UltraWebGrid1.Clear();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete bizBscKpiPoolTemplete = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Templete();

        DataTable dtBscKpiPoolTemplete = bizBscKpiPoolTemplete.GetBscKpiPoolTemplete_DB();


        if (dtBscKpiPoolTemplete.Rows.Count > 0)
        {
            UltraWebGrid1.DataSource = dtBscKpiPoolTemplete;
            UltraWebGrid1.DataBind();
            UltraWebGrid1.Rows[0].Activate();
            UltraWebGrid1.Rows[0].Selected = true;

            int templete_code = DataTypeUtility.GetToInt32(dtBscKpiPoolTemplete.Rows[0]["KPI_POOL_TEMPLETE_ID"]);

            DoBindingTempleteMap(templete_code);
        }
    }

    public void DoBindingTempleteMap(int templete_code)
    {
        UltraWebGrid2.Clear();

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool bizBscKpiPool = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool();

        DataTable dtBscKpiPool = bizBscKpiPool.GetKpiPool_DB(""
                                                           , ""
                                                           , ""
                                                           , 0
                                                           , templete_code);

        UltraWebGrid2.DataSource = dtBscKpiPool;
        UltraWebGrid2.DataBind();

        //lblRowCount.Text = dtBscKpiPool.Rows.Count.ToString();
    }
}
