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

public partial class BSC_BSC1001M1 : AppPageBase
{
    #region ==========================[변수선언]================
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "N");
            }

            return (string)ViewState["CCB1"];
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

    protected DataTable DT_MBO
    {
        get
        {
            if (ViewState["DT_MBO"] == null)
                ViewState["DT_MBO"] = null;
            return (DataTable)ViewState["DT_MBO"];
        }
        set
        {
            ViewState["DT_MBO"] = value;
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
            ibtnSearchLeft_Click(null, null);
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
        object[] objList = GetSelectKpiList();

        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail();
        DataSet dsYear = objTerm.GetTermDetail(ESTTERM_REF_ID);
        if (dsYear.Tables[0].Rows.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가년도를 확인하세요.");
            return;
        }
        Biz_Bsc_Kpi_Info objMBO = new Biz_Bsc_Kpi_Info();


        //if (objMBO.CopyKpiToMbo(ESTTERM_REF_ID
        //                        , objList
        //                        , gUserInfo.Emp_Ref_ID
        //                        , dsYear.Tables[0].Rows[0]["YMD"].ToString().Substring(0, 4)
        //                        , "STG"))
        //{
        //    DoBindingDept();
        //    DoBinding();
        //    ltrScript.Text = JSHelper.GetAlertScript("복사를 완료하였습니다.");
        //}
        //else
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("복사가 실패하였습니다.");
        //}
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
            string returnStr = objMBO.CopyKpiToMbo_NW(ESTTERM_REF_ID
                                                    , objList
                                                    , gUserInfo.Emp_Ref_ID
                                                    , dsYear.Tables[0].Rows[0]["YMD"].ToString().Substring(0, 4)
                                                    , "STG");

            if (returnStr.Equals(string.Empty))
            {
                DoBindingDept();
                ltrScript.Text = JSHelper.GetAlertOpenerReflashScript("복사를 완료하였습니다.", true);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript(returnStr);
            }
        }
    }

    protected void ugrdDeptKpi_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }

    protected void ugrdDeptKpi_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {

        // 이미 추가 되어 있으면 화면에서 지운다.
        //string kpi_pool_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_POOL_REF_ID").Value);

        //DataRow[] rows = DT_MBO.Select(string.Format(" KPI_POOL_REF_ID = {0} ", kpi_pool_ref_id));
        //if (rows.Length > 0)
        //{
        //    e.Row.Delete();
        //}
        //else
        //{

            CheckBox chkCheck;
            TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");

            chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("cBox");

            e.Row.Cells.FromKey("APP_STATUS_NAME").Value = "Y";

            if (e.Row.Cells.FromKey("APP_STATUS").Value != null)
            {
                if (e.Row.Cells.FromKey("APP_STATUS").Value.ToString() != Biz_Type.app_status_complete)
                {
                    chkCheck.Enabled = false;
                    e.Row.Cells.FromKey("APP_STATUS_NAME").Value = "N";
                }
            }

            DataRowView drv = (DataRowView)e.Data;
            if (drv["COM_DEPT_REF_ID"].ToString() != this.IDEPT_ID.ToString())
                chkCheck.Enabled = false;

            string estterm_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
            string kpi_code = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_CODE").Value);
            string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

            string onclick = "<a href='#null' onclick=\"doLinking_Dept('{0}','{1}','{2}')\">{3}</a>";
            string link = string.Format(onclick, estterm_ref_id, kpi_code, ICCB1, kpi_name);
            e.Row.Cells.FromKey("KPI_NAME").Value = link;
        //}
    }

    protected void ibtnSearchLeft_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DT_MBO = objBSC.GetMBOForDeptKpi(ESTTERM_REF_ID
                                            , ""
                                            , ""
                                            , ""
                                            , ""
                                            , 0
                                            , 0
                                            , 0
                                            , 0
                                            , gUserInfo.Emp_Ref_ID
                                            , (User.IsInRole(ROLE_ADMIN) == true ? 1 : 0)
                                            , this.IDEPT_ID).Tables[0];

        DoBindingDept();
    }

    #endregion

    private void DoInitializing()
    {
        this.IDEPT_ID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);

        WebCommon.SetComDeptDropDownList(ddlComDeptLeft, true, gUserInfo.Emp_Ref_ID);

        ddlComDeptLeft.SelectedValue = IDEPT_ID.ToString();
        ddlComDeptLeft.Enabled = false;

    }

    


    private object[] GetSelectKpiList()
    {
        object[] objTemp = new object[ugrdDeptKpi.Rows.Count];
        int objCnt = 0;
        for (int i = 0; i < ugrdDeptKpi.Rows.Count; i++)
        {
            UltraGridRow gr = ugrdDeptKpi.Rows[i];
            CheckBox chkCheck;
            TemplatedColumn Col_Check = (TemplatedColumn)gr.Band.Columns.FromKey("selchk");

            chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[gr.BandIndex]).FindControl("cBox");
            if (chkCheck.Checked)
            {
                objTemp[objCnt] = DataTypeUtility.GetToInt32(gr.Cells.FromKey("KPI_REF_ID").Value);
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

    private void DoBindingDept()
    {
        
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetDeptKpiForMBO(ESTTERM_REF_ID
                                                , (ddlComDeptLeft.SelectedItem.Value == "" ? 0 : PageUtility.GetIntByValueDropDownList(ddlComDeptLeft))
                                                , txtKpiCodeLeft.Text.Trim()
                                                , txtKpiNameLeft.Text.Trim()
                                                , txtChampionNameLeft.Text.Trim()
                                                , gUserInfo.Emp_Ref_ID
                                                , (User.IsInRole(ROLE_ADMIN) == true ? 1 : 0));

        ugrdDeptKpi.Clear();



        ugrdDeptKpi.DataSource = ds;
        ugrdDeptKpi.DataBind();

        
    }

}
