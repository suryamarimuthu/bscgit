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
using System.IO;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;
using System.Drawing;

using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.BSC.Biz;

using MicroBSC.Common;

public partial class BSC_BSC0501M2 : AppPageBase
{
    #region 변수선언

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
                hdnEstTermID.Value = GetRequest("ESTTERM_REF_ID", "");
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
                hdnKpiId.Value = GetRequest("KPI_REF_ID", "");
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public int IEstEmpID
    {
        get
        {
            if (ViewState["EST_EMP_ID"] == null)
            {
                ViewState["EST_EMP_ID"] = GetRequestByInt("EST_EMP_ID", 0);
            }

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
                hdnYMD.Value = GetRequest("YMD", "");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    public string IisAdmin
    {
        get
        {
            if (ViewState["IS_ADMIN"] == null)
            {
                ViewState["IS_ADMIN"] = GetRequest("IS_ADMIN", "N");
            }

            return (string)ViewState["IS_ADMIN"];
        }
        set
        {
            ViewState["IS_ADMIN"] = value;
        }
    }

    public string IResultInputType
    {
        get
        {
            if (ViewState["RESULT_INPUT_TYPE"] == null)
            {
                ViewState["RESULT_INPUT_TYPE"] = GetRequest("RESULT_INPUT_TYPE", "MAN");
            }

            return (string)ViewState["RESULT_INPUT_TYPE"];
        }
        set
        {
            ViewState["RESULT_INPUT_TYPE"] = value;
        }
    }

    public string IResultTsCalcType
    {
        get
        {
            if (ViewState["RESULT_TS_CALC_TYPE"] == null)
            {
                ViewState["RESULT_TS_CALC_TYPE"] = GetRequest("RESULT_TS_CALC_TYPE", "");
            }

            return (string)ViewState["RESULT_TS_CALC_TYPE"];
        }
        set
        {
            ViewState["RESULT_TS_CALC_TYPE"] = value;
        }
    }

    public string IEstStatus
    {
        get
        {
            if (ViewState["ESTSTATUS"] == null)
            {
                ViewState["ESTSTATUS"] = GetRequest("ESTSTATUS", "N");
            }

            return (string)ViewState["ESTSTATUS"];
        }
        set
        {
            ViewState["ESTSTATUS"] = value;
        }
    }

    public string IKpiExternalType
    {
        get
        {
            if (ViewState["KPI_EXTERNAL_TYPE"] == null)
            {
                ViewState["KPI_EXTERNAL_TYPE"] = GetRequest("KPI_EXTERNAL_TYPE", "");
            }

            return (string)ViewState["KPI_EXTERNAL_TYPE"];
        }
        set
        {
            ViewState["KPI_EXTERNAL_TYPE"] = value;
        }
    }

    private bool saveEnable;
    #endregion

    #region 이벤트함수
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            saveEnable = false;
            iBtnClose.OnClientClick = "window.close();";
            SetButton();
            DoBinding();
            if (ugrdResult.Rows.Count > 0)
                lblYMD.Text = ugrdResult.Rows[0].Cells.FromKey("YMD").Text;
            iBtnInsert.Visible = saveEnable;
        }

        ltrScript.Text = "";

        
    }

    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {

        Biz_Bsc_Kpi_Result bizResult = new Biz_Bsc_Kpi_Result();
        DataSet dsResult = bizResult.GetKpiResultDataScheme();

        for (int i = 0; i < ugrdResult.Rows.Count; i++)
        {
            if (ugrdResult.Rows[i].Cells.FromKey("CHECK_YN").Text == "Y")
            {
                DataRow updateRow = dsResult.Tables[0].NewRow();
                updateRow["ESTTERM_REF_ID"] = ugrdResult.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value;
                updateRow["KPI_REF_ID"] = ugrdResult.Rows[i].Cells.FromKey("KPI_REF_ID").Value;
                updateRow["YMD"] = ugrdResult.Rows[i].Cells.FromKey("YMD").Value.ToString().Replace("/", "");

                updateRow["RESULT_MS"] = ugrdResult.Rows[i].Cells.FromKey("RESULT_MS").Value;
                updateRow["RESULT_TS"] = ugrdResult.Rows[i].Cells.FromKey("RESULT_TS").Value;

                string tName = "0" + (i + 1).ToString();
                if (tName.Length == 3)
                    tName = tName.Substring(1, 2);

                updateRow["CAUSE_TEXT_MS"] = ((TextBox)this.FindControl("txtCAUSE_TEXT_MS_" + tName)).Text;
                updateRow["CAUSE_TEXT_TS"] = ((TextBox)this.FindControl("txtCAUSE_TEXT_TS_" + tName)).Text;
                updateRow["MEASURE_TEXT_MS"] = ((TextBox)this.FindControl("txtMEASURE_TEXT_MS_" + tName)).Text;
                updateRow["MEASURE_TEXT_TS"] = ((TextBox)this.FindControl("txtMEASURE_TEXT_TS_" + tName)).Text;

                updateRow["CHECKSTATUS"] = ugrdResult.Rows[i].Cells.FromKey("CHECKSTATUS").Value;

                updateRow["UPDATE_DATE"] = DateTime.Now;
                updateRow["UPDATE_USER"] = EMP_REF_ID;

                dsResult.Tables[0].Rows.Add(updateRow);
            }
        }

        if (dsResult.Tables[0].Rows.Count > 0)
        {
            bool isOK = bizResult.UpdateKpiResultDataByAdmin(dsResult.Tables[0]);

            if (isOK)
            {
                DoBinding();
                string msg = "정상적으로 저장하였습니다.";
                ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript(msg, "lnkRefresh", true);
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
            }
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("수정된 데이터가 없습니다.");
        }
    }

    protected void ugrdResult_InitializeRow(object sender, RowEventArgs e)
    {
        string replaceYMD = e.Row.Cells.FromKey("YMD").Text.Substring(0, 4) + "/" + e.Row.Cells.FromKey("YMD").Text.Substring(4, 2);
        e.Row.Cells.FromKey("YMD").Text = replaceYMD;

        TextBox replaceText1 = (TextBox)this.FindControl("txtCAUSE_TEXT_MS_" + replaceYMD.Substring(5, 2));
        TextBox replaceText2 = (TextBox)this.FindControl("txtCAUSE_TEXT_TS_" + replaceYMD.Substring(5, 2));
        TextBox replaceText3 = (TextBox)this.FindControl("txtMEASURE_TEXT_MS_" + replaceYMD.Substring(5, 2));
        TextBox replaceText4 = (TextBox)this.FindControl("txtMEASURE_TEXT_TS_" + replaceYMD.Substring(5, 2));
        replaceText1.Text = e.Row.Cells.FromKey("CAUSE_TEXT_MS").Text;
        replaceText2.Text = e.Row.Cells.FromKey("CAUSE_TEXT_TS").Text;
        replaceText3.Text = e.Row.Cells.FromKey("MEASURE_TEXT_MS").Text;
        replaceText4.Text = e.Row.Cells.FromKey("MEASURE_TEXT_TS").Text;

        if (e.Row.Cells.FromKey("OPEN_YN").Value == null || !e.Row.Cells.FromKey("OPEN_YN").Text.Equals("Y"))
        {
            e.Row.Cells.FromKey("RESULT_MS").AllowEditing = AllowEditing.No;
            e.Row.Cells.FromKey("RESULT_TS").AllowEditing = AllowEditing.No;
            e.Row.Cells.FromKey("RESULT_MS").Style.BackColor = Color.LightGray;
            e.Row.Cells.FromKey("RESULT_TS").Style.BackColor = Color.LightGray;
            replaceText1.ReadOnly = replaceText2.ReadOnly = replaceText3.ReadOnly = replaceText4.ReadOnly = true;
        }
        else if (e.Row.Cells.FromKey("CHECK_YN").Value == null || e.Row.Cells.FromKey("CHECK_YN").Text == "N")
        {
            e.Row.Cells.FromKey("RESULT_MS").AllowEditing = AllowEditing.No;
            e.Row.Cells.FromKey("RESULT_TS").AllowEditing = AllowEditing.No;
            e.Row.Cells.FromKey("RESULT_MS").Style.BackColor = Color.LightGray;
            e.Row.Cells.FromKey("RESULT_TS").Style.BackColor = Color.LightGray;
            replaceText1.ReadOnly = replaceText2.ReadOnly = replaceText3.ReadOnly = replaceText4.ReadOnly = true;
        }

        if (e.Row.Cells.FromKey("OPEN_YN").Text.Equals("Y") && e.Row.Cells.FromKey("CHECK_YN").Text == "Y")
            saveEnable = true;
    }
    #endregion

    #region 바인딩
    private void DoBinding()
    {
        // KPI정보 바인딩
        Biz_Bsc_Kpi_Info objBSC = new Biz_Bsc_Kpi_Info(this.IEstTermRefID, this.IKpiRefID);
        lblKPICode.Text = objBSC.Ikpi_code;
        lblKPIName.Text = objBSC.Ikpi_name;
        lblUnitName.Text = objBSC.Iunit_name;
        lblRESULT_INPUT_TYPE.Text = objBSC.Iresult_input_type_name;
        lblRESULT_TS_CALC_TYPE.Text = objBSC.Iresult_ts_calc_type_name;
        lblRESULT_ACHIEVEMENT_TYPE.Text = objBSC.Iresult_achievement_type_name;
        IResultTsCalcType = objBSC.Iresult_ts_calc_type;

        string inputType = objBSC.Iresult_input_type.Trim();

        // 누적실적유형이 단순합계, 단순평균은 자동으로 계산되도록 그리드컬럼 LOCK
        if (objBSC.Iresult_ts_calc_type == "SUM" || objBSC.Iresult_ts_calc_type == "AVG")
        {
            ugrdResult.Columns.FromKey("RESULT_TS").AllowUpdate = AllowUpdate.No;
            ugrdResult.Columns.FromKey("RESULT_TS").CellStyle.BackColor = Color.LightGray;
        }
        else if (objBSC.Iresult_ts_calc_type == "OTS") //누적실적만 입력
        {
            ugrdResult.Columns.FromKey("RESULT_MS").AllowUpdate = AllowUpdate.No;
            ugrdResult.Columns.FromKey("RESULT_MS").CellStyle.BackColor = Color.LightGray;
        }

        Biz_Bsc_Kpi_Result bizResult = new Biz_Bsc_Kpi_Result();
        DataSet dsResult = bizResult.GetResultTotalData(this.IEstTermRefID
                                                        , this.IKpiRefID);

        ugrdResult.Clear();
        ugrdResult.DataSource = dsResult;
        ugrdResult.DataBind();

        if (inputType == "SYS")
        {
            iBtnInsert.Enabled = false;
            for (int i = 0; i < ugrdResult.Rows.Count; i++)
            {
                ugrdResult.Rows[i].Cells.FromKey("RESULT_MS").AllowEditing = AllowEditing.No;
                ugrdResult.Rows[i].Cells.FromKey("RESULT_MS").Style.BackColor = Color.LightGray;
                ugrdResult.Rows[i].Cells.FromKey("RESULT_TS").AllowEditing = AllowEditing.No;
                ugrdResult.Rows[i].Cells.FromKey("RESULT_TS").Style.BackColor = Color.LightGray;

                string tName = "0" + (i + 1).ToString();
                if (tName.Length == 3)
                    tName = tName.Substring(1, 2);
                ((TextBox)this.FindControl("txtCAUSE_TEXT_MS_" + tName)).ReadOnly
                    = ((TextBox)this.FindControl("txtCAUSE_TEXT_TS_" + tName)).ReadOnly
                    = ((TextBox)this.FindControl("txtMEASURE_TEXT_MS_" + tName)).ReadOnly
                    = ((TextBox)this.FindControl("txtMEASURE_TEXT_TS_" + tName)).ReadOnly = true;
            }
        }
    }
    #endregion

    #region 버튼권한
    private void SetButton()
    {
        // 어드민에게만 실적일괄변경 권한부여
        iBtnInsert.Visible = false;
        if (User.IsInRole(ROLE_ADMIN))
        {
            iBtnInsert.Visible = true;
        }
    }
    #endregion
}
