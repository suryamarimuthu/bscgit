using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

public partial class BSC_BSC1001S2 : AppPageBase
{
    protected string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lbtReloadLeft.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    protected string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.lbtReloadRight.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    protected string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", this.lbtReloadLeft2.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB3"];
        }
        set
        {
            ViewState["CCB3"] = value;
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

    private int IDTPAGINGID
    {
        get
        {
            if (ViewState["DTPAGINGID"] == null)
                ViewState["DTPAGINGID"] = 1;
            return (int)ViewState["DTPAGINGID"];
        }
        set
        {
            ViewState["DTPAGINGID"] = value;
        }
    }

    private DataTable IDT_PAGING
    {
        get
        {
            if (ViewState["DT_PAGING"] == null)
                ViewState["DT_PAGING"] = 0;
            return (DataTable)ViewState["DT_PAGING"];
        }
        set
        {
            ViewState["DT_PAGING"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBindingDeptMBO();
            DoBindingDept();
            DoBinding();
            //2012.02.21 박효동 : 허성대대왕 요청으로 자화장영수주임 요청으로 관리자권한갖은 사원이 있어서 주석처리
            //if (User.IsInRole(ROLE_ADMIN))
            //    ibtnInsert.Enabled = ibtnDelete.Enabled = false;
        }

        ltrScript.Text = "";
    }

    protected void lbtReloadRight_Click(object sender, EventArgs e)
    {
        DoBinding();
    }

    protected void lbtReloadLeft_Click(object sender, EventArgs e)
    {
        DoBindingDept();
    }

    protected void lbtReloadLeft2_Click(object sender, EventArgs e)
    {
        DoBindingDeptMBO();
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdDeptKpi.Clear();
        ugrdMBO.Clear();
        ugrdTeamMbo.Clear();
    }

    protected void ddlKpiCategoryTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }
    protected void ddlKpiCategoryMid_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }

    private void DoInitControl()
    {
        this.IDEPT_ID = BizUtility.GetDeptID(gUserInfo.Emp_Ref_ID);
        WebCommon.SetComDeptDropDownList(ddlComDeptLeft, true, gUserInfo.Emp_Ref_ID);
        WebCommon.SetComDeptDropDownList(ddlComDeptLeft2, true, gUserInfo.Emp_Ref_ID);
        WebCommon.SetComDeptDropDownList(ddlComDeptRight, true, gUserInfo.Emp_Ref_ID);
        PageUtility.FindByValueDropDownList(ddlComDeptLeft, this.IDEPT_ID);
        PageUtility.FindByValueDropDownList(ddlComDeptLeft2, this.IDEPT_ID);
        PageUtility.FindByValueDropDownList(ddlComDeptRight, this.IDEPT_ID);

        WebCommon.SetEstTermDropDownList(ddlEstTerm);

        Biz_Com_Code_Info objCom = new Biz_Com_Code_Info();
        objCom.GetKpiType(ddlKpiGroup, "", true, 120);

        WebCommon.SetKpiCategoryTopActiveDropDownList(ddlKpiCategoryTop, true, "Y");
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, true, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");

        if (!User.IsInRole(ROLE_ADMIN))
            txtChampionNameRight.Text = gUserInfo.Emp_Name;
    }

    protected void ibtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        object[] objList = GetSelectKpiList();

        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail();
        DataSet dsYear = objTerm.GetTermDetail(PageUtility.GetIntByValueDropDownList(ddlEstTerm));
        if (dsYear.Tables[0].Rows.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가년도를 확인하세요.");
            return;
        }
        Biz_Bsc_Kpi_Info objMBO = new Biz_Bsc_Kpi_Info();


        //if (objMBO.CopyKpiToMbo(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
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


        string returnStr = objMBO.CopyKpiToMbo_NW(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                                , objList
                                                , gUserInfo.Emp_Ref_ID
                                                , dsYear.Tables[0].Rows[0]["YMD"].ToString().Substring(0, 4)
                                                , "STG");

        if (returnStr.Equals(string.Empty))
        {
            DoBindingDept();
            DoBinding();
            ltrScript.Text = JSHelper.GetAlertScript("복사를 완료하였습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(returnStr);
        }
    }

    protected void ibtnInsert2_Click(object sender, ImageClickEventArgs e)
    {
        object[] objList = GetSelectTeamMboList();

        Biz_Bsc_Term_Detail objTerm = new Biz_Bsc_Term_Detail();
        DataSet dsYear = objTerm.GetTermDetail(PageUtility.GetIntByValueDropDownList(ddlEstTerm));
        if (dsYear.Tables[0].Rows.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가년도를 확인하세요.");
            return;
        }
        Biz_Bsc_Kpi_Info objMBO = new Biz_Bsc_Kpi_Info();
        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info bizBscKpiInfo = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info();
        
        
        bool Result = bizBscKpiInfo.CopyKpiToMbo(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                                , objList
                                                , gUserInfo.Emp_Ref_ID
                                                , dsYear.Tables[0].Rows[0]["YMD"].ToString().Substring(0, 4)
                                                , "PRS");
        /*
        bool Result = objMBO.CopyKpiToMbo(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                , objList
                                , gUserInfo.Emp_Ref_ID
                                , dsYear.Tables[0].Rows[0]["YMD"].ToString().Substring(0, 4)
                                , "PRS");
        */

        if (Result)
        {
            DoBindingDeptMBO();
            DoBinding();
            ltrScript.Text = JSHelper.GetAlertScript("복사를 완료하였습니다.");
        }
        else
        {
            Response.Write(objMBO.Transaction_Message);
            ltrScript.Text = JSHelper.GetAlertScript("복사가 실패하였습니다.");
        }
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

    private object[] GetSelectTeamMboList()
    {
        object[] objTemp = new object[ugrdTeamMbo.Rows.Count];
        int objCnt = 0;
        for (int i = 0; i < ugrdTeamMbo.Rows.Count; i++)
        {
            UltraGridRow gr = ugrdTeamMbo.Rows[i];
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

    private object[] GetSelectMboList()
    {
        object[] objTemp = new object[ugrdMBO.Rows.Count];
        int objCnt = 0;
        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            UltraGridRow gr = ugrdMBO.Rows[i];
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

    protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        object[] objList = GetSelectMboList();

        Biz_Bsc_Kpi_Info objMBO = new Biz_Bsc_Kpi_Info();

        //bool boolOK = objMBO.DeleteMboToKpi(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
        //                        , objList
        //                        , gUserInfo.Emp_Ref_ID);

        string returnMsg = objMBO.RemoveMboToKpi_NW(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                            , objList
                                            , gUserInfo.Emp_Ref_ID);
        if (returnMsg.Equals(string.Empty))
        {
            DoBindingDept();
            DoBindingDeptMBO();
            DoBinding();
            ltrScript.Text = JSHelper.GetAlertScript("삭제를 완료하였습니다.");
        }
        else
        {
            //ltrScript.Text = JSHelper.GetAlertScript("삭제가 실패하였습니다.");
            ltrScript.Text = JSHelper.GetAlertScript(returnMsg);
        }
    }

    protected void ibtnDelete2_Click(object sender, ImageClickEventArgs e)
    {
        //object[] objList = GetSelectMboList();

        //Biz_Bsc_Kpi_Info objMBO = new Biz_Bsc_Kpi_Info();
        //if (objMBO.DeleteMboToKpi(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
        //                        , objList
        //                        , gUserInfo.Emp_Ref_ID))
        //{
        //    DoBindingDept();
        //    DoBindingDeptMBO();
        //    DoBinding();
        //    ltrScript.Text = JSHelper.GetAlertScript("삭제를 완료하였습니다.");
        //}
        //else
        //    ltrScript.Text = JSHelper.GetAlertScript("삭제가 실패하였습니다.");


        string kpi_ref_id_list = string.Empty;

        for (int i = 0; i < ugrdMBO.Rows.Count; i++)
        {
            UltraGridRow row = ugrdMBO.Rows[i];

            //CheckBox chkCheck;
            TemplatedColumn Col_Check = (TemplatedColumn)row.Band.Columns.FromKey("selchk");

            CheckBox chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[row.BandIndex]).FindControl("cBox");

            string app_status = DataTypeUtility.GetValue(row.Cells.FromKey("APPROVAL_STATUS").Value);

            if (chkCheck.Checked)
            {
                if (!app_status.Equals("Y"))
                {
                    kpi_ref_id_list += ";" + DataTypeUtility.GetToInt32(row.Cells.FromKey("KPI_REF_ID").Value);
                }
            }
        }

        if (kpi_ref_id_list.Length > 0)
        {
            kpi_ref_id_list = kpi_ref_id_list.Remove(0, 1);
        }

        string[] kpiRefIdList = kpi_ref_id_list.Split(';');

        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info bizBscKpiInfo = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info();
        
        string okMsg = bizBscKpiInfo.RemoveMboToKpi_DB(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                                     , kpiRefIdList);

        if (okMsg.Equals(""))
        {
            DoBindingDept();
            DoBindingDeptMBO();
            DoBinding();
            ltrScript.Text = JSHelper.GetAlertScript("삭제를 완료하였습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제가 실패하였습니다.");
        }
    }

    protected void ibtnSearchLeft_Click(object sender, ImageClickEventArgs e)
    {
        DoBindingDept();
    }

    protected void ibtnSearchLeft2_Click(object sender, ImageClickEventArgs e)
    {
        DoBindingDeptMBO();
    }

    protected void ibtnSearchRight_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    private void DoBindingDept()
    {
        if (ddlEstTerm.Items.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("등록된 평가기간이 없습니다.");
            return;
        }

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetDeptKpiForMBO(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
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

    private void DoBindingDeptMBO()
    {
        if (ddlEstTerm.Items.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("등록된 평가기간이 없습니다.");
            return;
        }

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetDeptMboForMBO(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                                , (ddlComDeptLeft2.SelectedItem.Value == "" ? 0 : PageUtility.GetIntByValueDropDownList(ddlComDeptLeft2))
                                                , txtKpiCodeLeft2.Text.Trim()
                                                , txtKpiNameLeft2.Text.Trim()
                                                , txtChampionNameLeft2.Text.Trim()
                                                , gUserInfo.Emp_Ref_ID
                                                , (User.IsInRole(ROLE_ADMIN) == true ? 1 : 0));

        ugrdTeamMbo.Clear();
        ugrdTeamMbo.DataSource = ds;
        ugrdTeamMbo.DataBind();
    }

    private void DoBinding()
    {
        lblRowCount.Text = "0/0";
        if (ddlEstTerm.Items.Count < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("등록된 평가기간이 없습니다.");
            return;
        }

        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info();
        DataSet ds = objBSC.GetMBOForDeptKpi(PageUtility.GetIntByValueDropDownList(ddlEstTerm)
                                            , txtKpiCodeRight.Text.Trim()
                                            , txtKpiNameRight.Text.Trim()
                                            , txtChampionNameRight.Text.Trim()
                                            , PageUtility.GetByValueDropDownList(ddlKpiGroup)
                                            , (ddlComDeptRight.SelectedItem.Value == "" ? 0 : PageUtility.GetIntByValueDropDownList(ddlComDeptRight))
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop)
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid)
                                            , PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow)
                                            , gUserInfo.Emp_Ref_ID
                                            , (User.IsInRole(ROLE_ADMIN) == true ? 1 : 0)
                                            , this.IDEPT_ID);
        this.IDT_PAGING = ds.Tables[0];
        ugrdMBO.Clear();
        ugrdMBO.DataSource = ds;
        ugrdMBO.DataBind();
        DoSetPaging(1);
        lblRowCount.Text = "&nbsp;" + ds.Tables[0].Compute("COUNT(APPROVAL_STATUS)", "APPROVAL_STATUS = 'Y'").ToString() + "&nbsp;/&nbsp;" + ds.Tables[0].Rows.Count.ToString() + "&nbsp;";
    }

    private void DoSetPaging(int pagenum)
    {
        DataTable dtPaging = this.IDT_PAGING.Copy();
        int dtCount = dtPaging.Rows.Count;
        string strPaging = string.Empty;
        int rowPage = Int32.Parse((pagenum / 10).ToString()) * 10;
        if (rowPage >= 10 && (pagenum % 10) == 0)
            rowPage = rowPage - 10;
        ibtn1.Visible = ibtn2.Visible = ibtn3.Visible = ibtn4.Visible = ibtn5.Visible = ibtn6.Visible = ibtn7.Visible = ibtn8.Visible = ibtn9.Visible = ibtn10.Visible = false;
        ibtn1.Style["cursor"] = ibtn2.Style["cursor"] = ibtn3.Style["cursor"] = ibtn4.Style["cursor"] = ibtn5.Style["cursor"] = ibtn6.Style["cursor"] = ibtn7.Style["cursor"] = ibtn8.Style["cursor"] = ibtn9.Style["cursor"] = ibtn10.Style["cursor"] = "pointer";
        ibtn1.ForeColor = ibtn2.ForeColor = ibtn3.ForeColor = ibtn4.ForeColor = ibtn5.ForeColor = ibtn6.ForeColor = ibtn7.ForeColor = ibtn8.ForeColor = ibtn9.ForeColor = ibtn10.ForeColor = System.Drawing.Color.Black;
        ibtnFirst.Enabled = ibtnPre.Enabled = ibtnNext.Enabled = ibtnLast.Enabled = true;
        if (rowPage + (dtCount / 200) < 1 && dtCount == 0)
            ibtnFirst.Enabled = ibtnPre.Enabled = ibtnNext.Enabled = ibtnLast.Enabled = false;
        else
        {
            for (int i = 1; i < 11; i++)
            {
                if (dtCount > (rowPage + i) * 200 - 200)
                {
                    switch (i)
                    {
                        case 1:
                            ibtn1.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn1.OnClientClick = "return false;";
                                ibtn1.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn1.Text = (rowPage + i).ToString();
                            break;
                        case 2:
                            ibtn2.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn2.OnClientClick = "return false;";
                                ibtn2.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn2.Text = (rowPage + i).ToString();
                            break;
                        case 3:
                            ibtn3.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn3.OnClientClick = "return false;";
                                ibtn3.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn3.Text = (rowPage + i).ToString();
                            break;
                        case 4:
                            ibtn4.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn4.OnClientClick = "return false;";
                                ibtn4.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn4.Text = (rowPage + i).ToString();
                            break;
                        case 5:
                            ibtn5.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn5.OnClientClick = "return false;";
                                ibtn5.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn5.Text = (rowPage + i).ToString();
                            break;
                        case 6:
                            ibtn6.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn6.OnClientClick = "return false;";
                                ibtn6.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn6.Text = (rowPage + i).ToString();
                            break;
                        case 7:
                            ibtn7.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn7.OnClientClick = "return false;";
                                ibtn7.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn7.Text = (rowPage + i).ToString();
                            break;
                        case 8:
                            ibtn8.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn8.OnClientClick = "return false;";
                                ibtn8.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn8.Text = (rowPage + i).ToString();
                            break;
                        case 9:
                            ibtn9.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn9.OnClientClick = "return false;";
                                ibtn9.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn9.Text = (rowPage + i).ToString();
                            break;
                        case 10:
                            ibtn10.Visible = true;
                            if (i == DataTypeUtility.GetToInt32(pagenum.ToString().Remove(0, pagenum.ToString().Length - 1)))
                            {
                                ibtn10.OnClientClick = "return false;";
                                ibtn10.ForeColor = System.Drawing.Color.Red;
                            }
                            ibtn10.Text = (rowPage + i).ToString();
                            break;
                    }
                }
            }
        }
        DataTable dtBind = new DataTable();

        if (dtCount > 0)
        {
            foreach (DataColumn dc in dtPaging.Columns)
            {
                dtBind.Columns.Add(dc.ColumnName, dc.DataType);
            }
            int dcCount = dtBind.Columns.Count;
            for (int i = pagenum * 200 - 199; i < pagenum * 200 + 1; i++)
            {
                if (i == dtCount)
                    break;
                
                DataRow dr = dtBind.NewRow();
                for (int j = 0; j < dcCount; j++)
                {
                    dr[j] = dtPaging.Rows[i - 1][j];
                }
                dtBind.Rows.Add(dr);
            }
        }
        //ugrdMBO.Clear();
        //ugrdMBO.DataSource = dtBind;
        //ugrdMBO.DataBind();

        this.IDTPAGINGID = pagenum;

        int ipage = this.IDT_PAGING.Rows.Count / 200;
        int imod = this.IDT_PAGING.Rows.Count % 200;
        if (ipage == 0)
            ipage = 1;
        else
            if (imod > 0)
                ipage++;
        if (this.IDTPAGINGID == ipage)
            ibtnNext.Enabled = ibtnLast.Enabled = false;
        if (this.IDTPAGINGID == 1)
            ibtnPre.Enabled = ibtnFirst.Enabled = false;
    }

    protected void ugrdDeptKpi_InitializeLayout(object sender, LayoutEventArgs e)
    {
        
    }
    protected void ugrdTeamMbo_InitializeLayout(object sender, LayoutEventArgs e)
    {
        
    }
    
    protected void ugrdDeptKpi_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        CheckBox chkCheck;
        TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");

        chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("cBox");

        if (e.Row.Cells.FromKey("APP_STATUS").Value != null)
            if(e.Row.Cells.FromKey("APP_STATUS").Value.ToString() != Biz_Type.app_status_complete)
                chkCheck.Enabled = false;

        DataRowView drv = (DataRowView)e.Data;
        if (drv["COM_DEPT_REF_ID"].ToString() != this.IDEPT_ID.ToString())
            chkCheck.Enabled = false;


        //string estterm_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        //string kpi_code = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_CODE").Value);
        //string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        //string onclick = "<a href='#null' onclick=\"doLinking_Dept('{0}','{1}','{2}')\">{3}</a>";
        //string link = string.Format(onclick, estterm_ref_id, kpi_code, ICCB1, kpi_name);
        //e.Row.Cells.FromKey("KPI_NAME").Value = link;
    }

    protected void ugrdTeamMbo_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        CheckBox chkCheck;
        TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");

        chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("cBox");

        //if (e.Row.Cells.FromKey("APP_STATUS").Value.ToString() != Biz_Type.app_status_complete)
        //    chkCheck.Enabled = false;
        DataRowView drv = (DataRowView)e.Data;
        if (drv["COM_DEPT_REF_ID"].ToString() != this.IDEPT_ID.ToString())
            chkCheck.Enabled = false;


        //string estterm_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        //string kpi_code = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_CODE").Value);
        //string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        //string onclick = "<a href='#null' onclick=\"doLinking_Team('{0}','{1}','{2}')\">{3}</a>";
        //string link = string.Format(onclick, estterm_ref_id, kpi_code, ICCB3, kpi_name);
        //e.Row.Cells.FromKey("KPI_NAME").Value = link;

    }

    protected void ugrdMBO_InitializeLayout(object sender, LayoutEventArgs e)
    {

    }
    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //CheckBox chkCheck;
        TemplatedColumn Col_Check = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");

        CheckBox chkCheck = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("cBox");
        //chkCheck.Enabled = (e.Row.Cells.FromKey("KPI_CLASS_REF_ID").Value.ToString() != "STG") ? false : true;

        //if (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y")
        //    chkCheck.Enabled = false;

        //if (e.Row.Cells.FromKey("CHAMPION_EMP_ID").Value.ToString() != gUserInfo.Emp_Ref_ID.ToString())
        //    chkCheck.Enabled = false;

        if (((DataRowView)e.Data)["CHECK_YN"].ToString() == "N")
            chkCheck.Enabled = false;
        //if (drv["COM_DEPT_REF_ID"].ToString() != this.IDEPT_ID.ToString())
        //    chkCheck.Enabled = false;

        if (((DataRowView)e.Data)["APPROVAL_STATUS"].ToString() == "N")
            chkCheck.Enabled = true;

        //string estterm_ref_id = DataTypeUtility.GetValue(e.Row.Cells.FromKey("ESTTERM_REF_ID").Value);
        //string kpi_code = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_CODE").Value);
        //string kpi_name = DataTypeUtility.GetValue(e.Row.Cells.FromKey("KPI_NAME").Value);

        //string onclick = "<a href='#null' onclick=\"doLinking_MBO('{0}','{1}','{2}')\">{3}</a>";
        //string link = string.Format(onclick, estterm_ref_id, kpi_code, ICCB2, kpi_name);
        //e.Row.Cells.FromKey("KPI_NAME").Value = link;
    }

    protected void ibtnFirst_Click(object sender, ImageClickEventArgs e)
    {
        DoSetPaging(1);
    }
    protected void ibtnPre_Click(object sender, ImageClickEventArgs e)
    {
        DoSetPaging(this.IDTPAGINGID - 1);
    }
    protected void ibtnNext_Click(object sender, ImageClickEventArgs e)
    {
        DoSetPaging(this.IDTPAGINGID + 1);
    }
    protected void ibtnLast_Click(object sender, ImageClickEventArgs e)
    {
        int ipage = this.IDT_PAGING.Rows.Count / 200;
        int imod = this.IDT_PAGING.Rows.Count % 200;
        if (ipage == 0)
            ipage = 1;
        else
            if (imod > 0)
                ipage++;
        DoSetPaging(ipage);
    }
    protected void ibtnPaging_Click(object sender, EventArgs e)
    {
        string ibtnid = ((Button)sender).ID;
        if (this.IDTPAGINGID == DataTypeUtility.GetToInt32(ibtnid.Remove(0, ibtnid.Length - 1)))
            return;
        DoSetPaging(DataTypeUtility.GetToInt32(ibtnid.Remove(0, ibtnid.Length - 1)));
    }
}
