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
using Infragistics.WebUI.UltraWebTab;

using MicroBSC.Data;
using MicroBSC.Common;
using MicroBSC.Biz.BSC;
using MicroBSC.Data;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Biz.BSC.Biz;

using System.Transactions;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;

public partial class BSC_BSC0301M1 : AppPageBase
{
    #region ======================= [ Variable, Property ] ===============
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", "");
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }
    
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int IKpiPoolRefID
    {
        get
        {
            if (ViewState["KPI_POOL_REF_ID"] == null)
            {
                ViewState["KPI_POOL_REF_ID"] = GetRequestByInt("KPI_POOL_REF_ID", 0);
            }

            return (int)ViewState["KPI_POOL_REF_ID"];
        }
        set
        {
            ViewState["KPI_POOL_REF_ID"] = value;
        }
    }

    UltraWebGrid TugrdQuestionItem;
    #endregion

    #region ======================= [ Page Load ] ========================
    protected void Page_Load(object sender, EventArgs e)
    {
        TugrdQuestionItem = this.ugrdKpiStatusTab.FindControl("ugrdQuestionItem") as UltraWebGrid;

        ltrScript.Text = "";
        if (!Page.IsPostBack)
        {
            this.SetFormData();
            this.SetButton();
        }
    }
    #endregion

    #region ======================== [ Method ] =========================
    #region SetButton
    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnReUsed.Visible = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnDelete.Visible = (this.IType == "D") ? false : true;
            iBtnReUsed.Visible = (this.IType == "D") ? true : false;
        }
        else
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnReUsed.Visible = false;
        }
    } 
    #endregion

    #region SetFormData
    private void SetFormData()
    {
        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info objCode = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        objCode.GetKpiType(ddlKpiType, 0, false, 100);
        objCode.GetKpiExternalType(ddlExternalType, 0, false, 100);
        objCode.GetKpiEstimateType(ddlBASIS_USE_YN, 0, false, 100);

        KpiPoolUpSkillBind();
        LitemCommonCode(tab_ddl_kpiType,"BS003",0);
        LitemCommonCode(tab_ddl_scoreType,"BS002", 0);
        LitemCommonCode(tab_ddl_caMethod,"BS006", 0);
        LitemCommonCode(tab_ddl_grade,"BS004", 0);
        LitemCommonCode(tab_ddl_reiod,"BS005", 0);
        LitemCommonCode(tab_ddl_type,"", 1);

        WebCommon.SetKpiCategoryTopActiveDropDownList(ddlKpiCategoryTop, true, "Y");
        if (this.IType != "A")
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool(this.IKpiPoolRefID);
            this.IKpiPoolRefID = objBSC.Ikpi_pool_ref_id;
            txtKpiName.Text = objBSC.Ikpi_name;
            txtKPIDesc.Text = objBSC.Ikpi_desc;
            txtValuationBasis.Value = objBSC.Ivaluation_basis;
            chkUseYn.Checked = (objBSC.Iuse_yn == "Y") ? true : false;
            PageUtility.FindByValueDropDownList(ddlKpiType, objBSC.Ikpi_type);
            PageUtility.FindByValueDropDownList(ddlExternalType, objBSC.Ikpi_external_type);
            PageUtility.FindByValueDropDownList(ddlBASIS_USE_YN, objBSC.Ibasis_use_yn);
            PageUtility.FindByValueDropDownList(ddlKpiCategoryTop, objBSC.Icategory_top_ref_id);
            WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, false, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
            PageUtility.FindByValueDropDownList(ddlKpiCategoryMid, objBSC.Icategory_mid_ref_id);
            WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, false, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
            PageUtility.FindByValueDropDownList(ddlKpiCategoryLow, objBSC.Icategory_low_ref_id);
            PageUtility.FindByValueDropDownList(ddlTargetName, objBSC.STG_REF_ID);

            GetBscKpiPoolInfo(this.IKpiPoolRefID);
            GetKpiPoolTerm(this.IKpiPoolRefID);
        }
        else
        {
            this.IKpiPoolRefID = 0;
            txtKpiName.Text = "";
            txtKPIDesc.Text = "";
            chkUseYn.Checked = true;
            PageUtility.FindByValueDropDownList(ddlBASIS_USE_YN, "EQT");
            //ddlKpiCategoryTop_SelectedIndexChanged(null, null);
        }
        SetKpiSignalGrid(this.IKpiPoolRefID);
        ugrdKpiStatusTab.SelectedTab = 0;
    } 
    #endregion

    #region Insert befor check
    private bool CheckFormData()
    {
        int row = 0;
        int cnt = ugrdQuestionItem.Rows.Count;
        int sum = 0;
        if (cnt > 0)
        {
            for (int i = 0; i < cnt; i++)
            {
                sum += int.Parse(ugrdQuestionItem.Rows[i].Cells.FromKey("WEIGHT").Value.ToString());
            }
            if (sum > 100)
            {
                ltrScript.Text = JSHelper.GetAlertScript("합계는 100이하여야 합니다", false);
                return false;
            }
        }

        if (this.IType == "A")
        {
            if (txtKpiName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("KPI명을 입력해 주십시오", false);
                return false;
            }
            else if (PageUtility.GetIntByValueDropDownList(ddlTargetName) == 0)
            {
                ltrScript.Text = JSHelper.GetAlertScript("전략명 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "U")
        {
            if (this.IKpiPoolRefID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("KPI를 선택해 주십시오", false);
                return false;
            }
            else if (txtKpiName.Text.Trim() == "")
            {
                ltrScript.Text = JSHelper.GetAlertScript("KPI명을 입력해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (this.IType == "D")
        {
            if (this.IKpiPoolRefID < 1)
            {
                ltrScript.Text = JSHelper.GetAlertScript("KPI를 선택해 주십시오", false);
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    } 
    #endregion

    #region Insert
    private void InsertKpiPool()
    {
        if (!this.CheckFormData()) { return; }
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        objBSC.Ikpi_name = txtKpiName.Text.Trim();
        objBSC.Ikpi_desc = txtKPIDesc.Text;
        objBSC.Ikpi_type = PageUtility.GetByValueDropDownList(ddlKpiType, "");
        objBSC.Ikpi_external_type = PageUtility.GetByValueDropDownList(ddlExternalType, "");
        objBSC.Iuse_yn = (chkUseYn.Checked) ? "Y" : "N";
        objBSC.Ibasis_use_yn = PageUtility.GetByValueDropDownList(ddlBASIS_USE_YN, "N");
        objBSC.Ivaluation_basis = txtValuationBasis.Value;
        objBSC.Icategory_top_ref_id = PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop);
        objBSC.Icategory_mid_ref_id = PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid);
        objBSC.Icategory_low_ref_id = PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow);
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;
        objBSC.STG_REF_ID = PageUtility.GetIntByValueDropDownList(ddlTargetName);

        int intRtn = objBSC.InsertData(objBSC.Ikpi_name,
                                       objBSC.Ikpi_desc,
                                       objBSC.Ikpi_type,
                                       objBSC.Ikpi_external_type,
                                       objBSC.Ibasis_use_yn,
                                       objBSC.Ivaluation_basis,
                                       objBSC.Icategory_top_ref_id,
                                       objBSC.Icategory_mid_ref_id,
                                       objBSC.Icategory_low_ref_id,
                                       objBSC.Iuse_yn,
                                       objBSC.Itxr_user,
                                       objBSC.STG_REF_ID);

        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);

        if (objBSC.Transaction_Result == "Y")
        {
            SetBscKpiPoolInfo(objBSC.Ikpi_pool_ref_id);
            SetKpiPoolTerm(objBSC.Ikpi_pool_ref_id);
            InsertKpiSignalGrid(objBSC.Ikpi_pool_ref_id);
            this.IKpiPoolRefID = objBSC.Ikpi_pool_ref_id;
            this.IType = "U";
            this.SetFormData();
            this.SetButton();
        }
    }
    #endregion

    #region Update
    private void UpdateKpiPool()
    {
        if (!this.CheckFormData()) { return; }

        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        objBSC.Ikpi_name = txtKpiName.Text.Trim();
        objBSC.Ikpi_desc = txtKPIDesc.Text;
        objBSC.Ikpi_type = PageUtility.GetByValueDropDownList(ddlKpiType, "");
        objBSC.Ikpi_external_type = PageUtility.GetByValueDropDownList(ddlExternalType, "");
        objBSC.Iuse_yn = (chkUseYn.Checked) ? "Y" : "N";
        objBSC.Ibasis_use_yn = PageUtility.GetByValueDropDownList(ddlBASIS_USE_YN, "N");
        objBSC.Ivaluation_basis = txtValuationBasis.Value;
        objBSC.Icategory_top_ref_id = PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop);
        objBSC.Icategory_mid_ref_id = PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid);
        objBSC.Icategory_low_ref_id = PageUtility.GetIntByValueDropDownList(ddlKpiCategoryLow);
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;
        objBSC.STG_REF_ID = PageUtility.GetIntByValueDropDownList(ddlTargetName);
        int intRtn = objBSC.UpdateData(this.IKpiPoolRefID,
                                       objBSC.Ikpi_name,
                                       objBSC.Ikpi_desc,
                                       objBSC.Ikpi_type,
                                       objBSC.Ikpi_external_type,
                                       objBSC.Ibasis_use_yn,
                                       objBSC.Ivaluation_basis,
                                       objBSC.Icategory_top_ref_id,
                                       objBSC.Icategory_mid_ref_id,
                                       objBSC.Icategory_low_ref_id,
                                       objBSC.Iuse_yn,
                                       objBSC.Itxr_user,
                                       objBSC.STG_REF_ID);
        SetBscKpiPoolInfo_Update(this.IKpiPoolRefID);
        SetKpiPoolTerm_Update(this.IKpiPoolRefID);
        DeleteKpiSignalGrid(this.IKpiPoolRefID);
        InsertKpiSignalGrid(this.IKpiPoolRefID);
        ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
    } 
    #endregion

    #region ReUsedKpiPool
    private void ReUsedKpiPool()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "RU";
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.ReUsedData(this.IKpiPoolRefID,
                                       objBSC.Itxr_user);

        if (objBSC.Transaction_Result == "Y")
        {
            this.TxrKpiPoolQuestion();
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            this.IType = "U";
        }
    } 
    #endregion

    #region private void DeleteKpiPool()
    private void DeleteKpiPool()
    {
        if (!this.CheckFormData()) { return; }

        this.IType = "D";
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool();
        objBSC.Itxr_user = gUserInfo.Emp_Ref_ID;

        int intRtn = objBSC.DeleteData(this.IKpiPoolRefID,
                                       objBSC.Itxr_user);

        if (objBSC.Transaction_Result == "Y")
        {
            this.TxrKpiPoolQuestion();
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(objBSC.Transaction_Message, this.ICCB1, true);
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
            this.IType = "U";
        }
    } 
    #endregion

    #region GetKpiPoolQuestionList()
    private void GetKpiPoolQuestionList()
    {
        MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool_Question objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool_Question();
        DataSet rDs = objBSC.GetAllList(this.IKpiPoolRefID);

        TugrdQuestionItem.Clear();
        TugrdQuestionItem.DataSource = rDs;
        TugrdQuestionItem.DataBind();
    } 
    #endregion

    #region  private void TxrKpiPoolQuestion()
    private void TxrKpiPoolQuestion()
    {
        DataTable rDt = this.GetQuestionDataTable();

        string strIType = "";
        int intRow = rDt.Rows.Count;
        int intRtn = 0;

        if (intRow > 0)
        {
            MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool_Question objBSC = new MicroBSC.BSC.Biz.Biz_Bsc_Kpi_Pool_Question();

            for (int i = 0; i < intRow; i++)
            {
                strIType = rDt.Rows[i]["ITYPE"].ToString();

                // 지표풀 자체가 삭제될 경우 하위 항목들은 모두 삭제
                if (this.IType == "D")
                {
                    if (strIType == "U" || strIType == "D")
                    {
                        strIType = "D";
                    }
                    else
                    {
                        strIType = "X";
                    }
                }

                if (strIType == "A")
                {
                    intRtn += objBSC.InsertData(int.Parse(rDt.Rows[i]["KPI_POOL_REF_ID"].ToString())
                                                , rDt.Rows[i]["ITEM_NAME"].ToString()
                                                , int.Parse(rDt.Rows[i]["WEIGHT"].ToString())
                                                , int.Parse(rDt.Rows[i]["QUESTION_ORDER"].ToString())
                                                , rDt.Rows[i]["USE_YN"].ToString()
                                                , gUserInfo.Emp_Ref_ID);
                }
                else if (strIType == "U")
                {
                    intRtn += objBSC.UpdateData(int.Parse(rDt.Rows[i]["KPI_POOL_REF_ID"].ToString())
                                                , int.Parse(rDt.Rows[i]["QUESTION_REF_ID"].ToString())
                                                , rDt.Rows[i]["ITEM_NAME"].ToString()
                                                , double.Parse(rDt.Rows[i]["WEIGHT"].ToString())
                                                , int.Parse(rDt.Rows[i]["QUESTION_ORDER"].ToString())
                                                , rDt.Rows[i]["USE_YN"].ToString()
                                                , gUserInfo.Emp_Ref_ID);
                }
                else if (strIType == "D")
                {
                    intRtn += objBSC.DeleteData(int.Parse(rDt.Rows[i]["KPI_POOL_REF_ID"].ToString())
                                                , int.Parse(rDt.Rows[i]["QUESTION_REF_ID"].ToString())
                                                , gUserInfo.Emp_Ref_ID);
                }
            }
        }

        //string strMsg  = "총 ["+ intRow.ToString() +"] 건중 [" + intRtn.ToString() +"]건이 처리되었습니다.";
        //ltrScript.Text = JSHelper.GetAlertScript(strMsg , false);
    } 
    #endregion

    #region private DataTable GetQuestionDataTable()
    private DataTable GetQuestionDataTable()
    {
        ////////////////////////////////////////////////////
        // KPI Pool Question 
        ////////////////////////////////////////////////////
        int intRow = TugrdQuestionItem.Rows.Count;
        int intCol = TugrdQuestionItem.Columns.Count;
        DataTable rDT1 = new DataTable("BSC_KPI_POOL_QUESTION");

        rDT1.Columns.Add("ITYPE", typeof(string));
        rDT1.Columns.Add("KPI_POOL_REF_ID", typeof(int));
        rDT1.Columns.Add("QUESTION_REF_ID", typeof(int));
        rDT1.Columns.Add("ITEM_NAME", typeof(string));
        rDT1.Columns.Add("WEIGHT", typeof(double));
        rDT1.Columns.Add("QUESTION_ORDER", typeof(int));
        rDT1.Columns.Add("USE_YN", typeof(string));

        DataRow rDR1;
        CheckBox chkUseYn;

        TemplatedColumn colUseYn = (TemplatedColumn)TugrdQuestionItem.Columns.FromKey("USE_YN");
        for (int i = 0; i < intRow; i++)
        {
            rDR1 = rDT1.NewRow();

            chkUseYn = (CheckBox)((CellItem)colUseYn.CellItems[TugrdQuestionItem.Rows[i].BandIndex]).FindControl("chkUseYn");

            rDR1["ITYPE"] = (TugrdQuestionItem.Rows[i].Cells.FromKey("ITYPE").Value == null) ? "X" : TugrdQuestionItem.Rows[i].Cells.FromKey("ITYPE").Value.ToString();
            rDR1["KPI_POOL_REF_ID"] = (TugrdQuestionItem.Rows[i].Cells.FromKey("KPI_POOL_REF_ID").Value == null) ? this.IKpiPoolRefID : int.Parse(TugrdQuestionItem.Rows[i].Cells.FromKey("KPI_POOL_REF_ID").Value.ToString());
            rDR1["QUESTION_REF_ID"] = (TugrdQuestionItem.Rows[i].Cells.FromKey("QUESTION_REF_ID").Value == null) ? 0 : int.Parse(TugrdQuestionItem.Rows[i].Cells.FromKey("QUESTION_REF_ID").Value.ToString());
            rDR1["ITEM_NAME"] = (TugrdQuestionItem.Rows[i].Cells.FromKey("ITEM_NAME").Value == null) ? "" : TugrdQuestionItem.Rows[i].Cells.FromKey("ITEM_NAME").Value.ToString();
            rDR1["WEIGHT"] = (TugrdQuestionItem.Rows[i].Cells.FromKey("WEIGHT").Value == null) ? 0 : double.Parse(TugrdQuestionItem.Rows[i].Cells.FromKey("WEIGHT").Value.ToString());
            rDR1["QUESTION_ORDER"] = (TugrdQuestionItem.Rows[i].Cells.FromKey("QUESTION_ORDER").Value == null) ? 0 : int.Parse(TugrdQuestionItem.Rows[i].Cells.FromKey("QUESTION_ORDER").Value.ToString());
            rDR1["USE_YN"] = chkUseYn.Checked ? "Y" : "N";

            if (rDR1["ITYPE"].ToString() != "X")
            {
                rDT1.Rows.Add(rDR1);
            }
        }

        return rDT1;
    } 
    #endregion

    #region 전략 바인드
    private void KpiPoolUpSkillBind()
    {
        ddlTargetName.Items.Add(new ListItem(":: 선택하세요 ::", "0"));
        DataTable dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool_Ver().Select_UpSkill_DB();
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlTargetName.Items.Add(new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
            }
        }
    }
    #endregion

    #region BSC_KPI_POOL_INFO

    private void GetBscKpiPoolInfo(int kpi_ref_id)
    {
        DataTable dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().GETBscKpiPoolInfo(kpi_ref_id);
        if (dt.Rows.Count == 1)
        {
            PageUtility.FindByValueDropDownList(tab_ddl_kpiType, dt.Rows[0]["RESULT_ACHIEVEMENT_TYPE"]);
            PageUtility.FindByValueDropDownList(tab_ddl_scoreType, dt.Rows[0]["RESULT_TS_CALC_TYPE"]);
            PageUtility.FindByValueDropDownList(tab_ddl_caMethod, dt.Rows[0]["MEASUREMENT_GRADE_TYPE"]);
            PageUtility.FindByValueDropDownList(tab_ddl_type, dt.Rows[0]["UNIT_TYPE_REF_ID"]);
            PageUtility.FindByValueDropDownList(tab_ddl_grade, dt.Rows[0]["RESULT_MEASUREMENT_STEP"]);
            PageUtility.FindByValueDropDownList(tab_ddl_reiod, dt.Rows[0]["RESULT_TERM_TYPE"]);
            tab_txt_word.Text = dt.Rows[0]["WORD_DEFINITION"].ToString();
            tab_txt_MonthCa.Text = dt.Rows[0]["CALC_FORM_MS"].ToString();
            tab_txt_fillCa.Text = dt.Rows[0]["CALC_FORM_TS"].ToString();
        }
    }

    private void SetBscKpiPoolInfo(int kpi_ref_id)
    {
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetBscKpiPoolInfo(
            kpi_ref_id,
            tab_txt_word.Text,
            tab_txt_MonthCa.Text,
            tab_txt_fillCa.Text,
            PageUtility.GetByValueDropDownList(tab_ddl_reiod),
            PageUtility.GetByValueDropDownList(tab_ddl_kpiType),
            PageUtility.GetByValueDropDownList(tab_ddl_scoreType),
            PageUtility.GetByValueDropDownList(tab_ddl_grade),
            PageUtility.GetByValueDropDownList(tab_ddl_caMethod),
            PageUtility.GetByValueDropDownList(tab_ddl_type),
            (chkUseYn.Checked) ? "Y" : "N",
            gUserInfo.Emp_Ref_ID);
    }

    private void SetBscKpiPoolInfo_Update(int kpi_ref_id)
    {
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetBscKpiPoolInfo_UPDATE(
            kpi_ref_id,
            tab_txt_word.Text,
            tab_txt_MonthCa.Text,
            tab_txt_fillCa.Text,
            PageUtility.GetByValueDropDownList(tab_ddl_reiod),
            PageUtility.GetByValueDropDownList(tab_ddl_kpiType),
            PageUtility.GetByValueDropDownList(tab_ddl_scoreType),
            PageUtility.GetByValueDropDownList(tab_ddl_grade),
            PageUtility.GetByValueDropDownList(tab_ddl_caMethod),
            PageUtility.GetByValueDropDownList(tab_ddl_type),
            (chkUseYn.Checked) ? "Y" : "N",
            gUserInfo.Emp_Ref_ID);
    }

    #endregion

    #region BSC_KPI_POOL_TERM
    public void SetKpiPoolTerm(int KPI_POOL_REF_ID)
    {
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "01", (tab_ck_1.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "02", (tab_ck_2.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "03", (tab_ck_3.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "04", (tab_ck_4.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "05", (tab_ck_5.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "06", (tab_ck_6.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "07", (tab_ck_7.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "08", (tab_ck_8.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "09", (tab_ck_9.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "10", (tab_ck_10.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "11", (tab_ck_11.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm(KPI_POOL_REF_ID, "12", (tab_ck_12.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
    }

    public void SetKpiPoolTerm_Update(int KPI_POOL_REF_ID)
    {

        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "01", (tab_ck_1.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "02", (tab_ck_2.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "03", (tab_ck_3.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "04", (tab_ck_4.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "05", (tab_ck_5.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "06", (tab_ck_6.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "07", (tab_ck_7.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "08", (tab_ck_8.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "09", (tab_ck_9.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "10", (tab_ck_10.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "11", (tab_ck_11.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().SetKpiPoolTerm_Update(KPI_POOL_REF_ID, "12", (tab_ck_12.Checked) ? "Y" : "N", gUserInfo.Emp_Ref_ID);
    }

    public void GetKpiPoolTerm(int KPI_POOL_REF_ID)
    {
        DataTable dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().GetKpiPoolTerm(KPI_POOL_REF_ID);
        if (dt.Rows.Count == 12)
        {
            tab_ck_1.Checked = (dt.Rows[0]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_2.Checked = (dt.Rows[1]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_3.Checked = (dt.Rows[2]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_4.Checked = (dt.Rows[3]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_5.Checked = (dt.Rows[4]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_6.Checked = (dt.Rows[5]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_7.Checked = (dt.Rows[6]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_8.Checked = (dt.Rows[7]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_9.Checked = (dt.Rows[8]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_10.Checked = (dt.Rows[9]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_11.Checked = (dt.Rows[10]["CHECK_YN"].ToString() == "Y") ? true : false;
            tab_ck_12.Checked = (dt.Rows[11]["CHECK_YN"].ToString() == "Y") ? true : false;
        }
    }  
    #endregion

    private void SetKpiSignalGrid(int KPI_POOL_REF_ID)
    {

        DataSet dsSignal = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().GetSignalListPerKpiWithBiz(KPI_POOL_REF_ID, PageUtility.GetByValueDropDownList(tab_ddl_grade));

        ugrdSignal.Clear();
        ugrdSignal.Rows.Clear();
        ugrdSignal.DataSource = dsSignal;
        ugrdSignal.DataBind();
    }

    private void InsertKpiSignalGrid(int KPI_POOL_REF_ID)
    {
        int intRow = ugrdSignal.Rows.Count;
        int intCol = ugrdSignal.Columns.Count;

        for (int i = 0; i < intRow; i++)
        {
            string level = PageUtility.GetByValueDropDownList(tab_ddl_grade);
            double minValue = (ugrdSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value == null) ? 0 : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("SET_MIN_VALUE").Value.ToString());
            double archiveRate = (ugrdSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value == null)     ? 0  : double.Parse(ugrdSignal.Rows[i].Cells.FromKey("ACHIEVE_RATE").Value.ToString());

            new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().GetThreadHoldInsert(KPI_POOL_REF_ID, i + 1, level, minValue, archiveRate, gUserInfo.Emp_Ref_ID);
        }
    }

    private void DeleteKpiSignalGrid(int KPI_POOL_REF_ID)
    {
        new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().GetThreadHoldDelete(KPI_POOL_REF_ID);
    }

    #region Common Code Bind
    private void LitemCommonCode(DropDownList dl, string code, int type)
    {
        if (type == 0)
        {
            DataTable dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().GetCommonCode(code);
            ListItem[] li = new ListItem[dt.Rows.Count + 1];
    
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dl.Items.Add(new ListItem(dt.Rows[i]["CODE_NAME"].ToString(), dt.Rows[i]["ETC_CODE"].ToString()));
                }
            }
        }
        else
        {
            DataTable dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().GetCommonCode();
            ListItem[] li = new ListItem[dt.Rows.Count + 1];
            li[0] = new ListItem(":: 선택 ::", "");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dl.Items.Add(new ListItem(dt.Rows[i]["UNIT_TYPE"].ToString(), dt.Rows[i]["UNIT_TYPE_REF_ID"].ToString()));
                }
            }
        }
    } 
    #endregion

    #endregion

    #region ======================== [ Server Event ] =========================
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        this.InsertKpiPool();
        this.TxrKpiPoolQuestion();
        this.GetKpiPoolQuestionList();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.DeleteKpiPool();
        //this.GetKpiPoolQuestionList();
    }

    protected void iBtnReUsed_Click(object sender, ImageClickEventArgs e)
    {
        this.ReUsedKpiPool();
    }


    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        this.UpdateKpiPool();
        this.TxrKpiPoolQuestion();
        this.GetKpiPoolQuestionList();
    }

    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }

    protected void ImgBtnAddRow_Click(object sender, ImageClickEventArgs e)
    {
        int cntRow = 0;
        TugrdQuestionItem.Rows.Add();
        cntRow = TugrdQuestionItem.Rows.Count - 1;

        CheckBox chkBox;
        TemplatedColumn chkBox_col = (TemplatedColumn)TugrdQuestionItem.Columns.FromKey("selchk");
        chkBox = (CheckBox)((CellItem)chkBox_col.CellItems[TugrdQuestionItem.Rows[cntRow].BandIndex]).FindControl("cBox");

        chkBox.Checked = true;

        TugrdQuestionItem.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
    }

    protected void ImgBtnDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = TugrdQuestionItem.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)TugrdQuestionItem.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < cntRow; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[TugrdQuestionItem.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow  = TugrdQuestionItem.Rows[i];
            if (chkCheck.Checked)
            {
                striType = TugrdQuestionItem.Rows[i].Cells.FromKey("ITYPE").ToString();
                if (striType == "U")
                {
                    //chkCheck.BackColor = Color.Red;
                    TugrdQuestionItem.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                    TugrdQuestionItem.Rows[i].Hidden = true;
                }
                else if (striType == "A")
                {
                    TugrdQuestionItem.Rows[i].Cells.FromKey("ITYPE").Value = "X";
                    TugrdQuestionItem.Rows[i].Hidden = true;
                    //TugrdQuestionItem.Rows.Remove(ugrdRow);
                }
            }
        }
    }

    protected void ugrdKpiStatusTab_TabClick(object sender, WebTabEvent e)
    {
        if (e.Tab.Key == "2")
        { 
          this.GetKpiPoolQuestionList();
        }
    }

    protected void ugrdQuestionItem_InitializeRow(object sender, RowEventArgs e)
    {

        e.Row.Cells.FromKey("ITYPE").Value = "U";

        CheckBox chkUseYn;
        TemplatedColumn Col_Check  = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");

        chkUseYn  = (CheckBox)((CellItem)Col_Check.CellItems[e.Row.BandIndex]).FindControl("chkUseYn");
        chkUseYn.Checked  = (e.Row.Cells.FromKey("USE_YN").Value.ToString()  == "Y") ? true : false;
    }

    protected void ddlKpiCategoryTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryMidActiveDropDownList(ddlKpiCategoryMid, false, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), "Y");
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, false, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }
    protected void ddlKpiCategoryMid_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetKpiCategoryLowActiveDropDownList(ddlKpiCategoryLow, false, PageUtility.GetIntByValueDropDownList(ddlKpiCategoryTop), PageUtility.GetIntByValueDropDownList(ddlKpiCategoryMid), "Y");
    }

    protected void ugrdSignal_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            c.Header.RowLayoutColumnInfo.OriginX = iIndex;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "표시상태";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "등급구간";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "평가 Table";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 4;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        for (int i = 0; i < e.Layout.Bands[0].Columns.Count; i++)
        {
            switch (i)
            {
                case 0:
                    e.Layout.Bands[0].Columns[i].Width = 80;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    break;
                case 1:
                    e.Layout.Bands[0].Columns[i].Width = 35;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Left;
                    break;
                case 2:
                    e.Layout.Bands[0].Columns[i].Width = 78;
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
                    break;
                case 3:
                    e.Layout.Bands[0].Columns[i].Width = 125;
                    e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.#####";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                case 4:
                    e.Layout.Bands[0].Columns[i].Header.Caption = "달성율";
                    e.Layout.Bands[0].Columns[i].Width = 63;
                    e.Layout.Bands[0].Columns[i].DataType = "System.Double";
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.##";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                case 5:
                    e.Layout.Bands[0].Columns[i].Width = 62;
                    e.Layout.Bands[0].Columns[i].Format = "###,###,###,###,###,###,###,###,###,##0.##";
                    e.Layout.Bands[0].Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                    break;
                default:
                    //e.Layout.Bands[0].Columns[i].Hidden = true;
                    break;
            }
        }
    }

    protected void ugrdSignal_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells[0].AllowEditing = AllowEditing.No;
        e.Row.Cells[1].AllowEditing = AllowEditing.No;
        e.Row.Cells[2].AllowEditing = AllowEditing.No;
        e.Row.Cells[4].AllowEditing = AllowEditing.No;
        e.Row.Cells[5].AllowEditing = AllowEditing.No;

        e.Row.Cells[0].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[1].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[2].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[4].Style.BackColor = System.Drawing.Color.WhiteSmoke;
        e.Row.Cells[5].Style.BackColor = System.Drawing.Color.WhiteSmoke;

        e.Row.Cells[1].Value = "<img src='../images/" + e.Row.Cells[1].Value.ToString() + "'>";
        e.Row.Cells[1].Style.HorizontalAlign = HorizontalAlign.Center;
    }

    protected void tab_ddl_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetKpiSignalGrid(this.IKpiPoolRefID);
    }
    #endregion



    
}
