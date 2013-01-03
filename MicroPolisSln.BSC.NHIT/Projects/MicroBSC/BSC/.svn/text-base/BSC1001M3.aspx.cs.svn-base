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

using MicroBSC.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;
using Infragistics.WebUI.UltraWebTab;
using MicroBSC.QueryEngine.QueryBuilder;

using Syncfusion.XlsIO;

public partial class BSC_BSC1001M3 : AppPageBase
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
            doBindKpiPool();
        }

        ltrScript.Text = "";

    }

    #endregion

    

    #region ================================= [ 서버이벤트 ]================================
    

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }
    

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        object[] objList = GetSelectKpiList(UltraWebGrid1);

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
                                                                      , ""
                                                                      , ""
                                                                      , gUserInfo.Emp_Ref_ID
                                                                      , DateTime.Now.ToString("yyyy-MM-dd")
                                                                      , result_measurement_step
                                                                      , unit_type_ref_id
                                                                      , "PRS"
                                                                      , dtBscThresholdStep);

            if (returnStr.Equals(string.Empty))
            {
                ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("처리되었습니다.", true);
                doBindKpiPool();
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript(returnStr);
            }
        }
    }



    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        doBindKpiPool();
    }
    protected void doBindKpiPool()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        DataSet ds = objBSC.GetDetailAllList(txtKpiName.Text.Trim()
                                               , ""
                                               , ""
                                               , 0
                                               , 0
                                               , 0
                                               , "");

        DataTable dt_filtered = DataTypeUtility.FilterSortDataTable(ds.Tables[0], "KPI_EXTERNAL_TYPE='EXT'");

        UltraWebGrid1.Clear();
        UltraWebGrid1.DataSource = dt_filtered;
        UltraWebGrid1.DataBind();
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        
    }
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ? "../images/icon_o.gif" : "../images/icon_x.gif";
    }


    #endregion


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
}