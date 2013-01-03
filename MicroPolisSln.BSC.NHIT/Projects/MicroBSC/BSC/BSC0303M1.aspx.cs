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
using MicroBSC.Common;

public partial class BSC_BSC0303M1 : AppPageBase
{
    int intEstTermID = 0;
    int intKpiRefID  = 0;

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

    public int intTergetVersion
    {
        get
        {
            if (ViewState["TERGET_VERSION"] == null)
            {
                ViewState["TERGET_VERSION"] = GetRequestByInt("TERGET_VERSION", 1);
            }

            return (int)ViewState["TERGET_VERSION"];
        }
        set
        {
            ViewState["TERGET_VERSION"] = value;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        intEstTermID   = GetRequestByInt("ESTTERM_REF_ID", 0);
        intKpiRefID    = GetRequestByInt("KPI_REF_ID", 0);
        ltrScript.Text = "";

        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetVersionGrid();
            this.SetButton();
        }
        else
        {

        }
    }

    private void SetInitForm()
    {
        Biz_Bsc_Kpi_Info objKPI = new Biz_Bsc_Kpi_Info(this.intEstTermID, this.intKpiRefID);
        txtKpiCode.Text = objKPI.Ikpi_code;
        lblKpiName.Text = objKPI.Ikpi_name;
    }

    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnInsert.Visible = true;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnClear.Visible  = false;
        }
        else if (this.IType == "U" || this.IType == "D")
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = true;
            iBtnDelete.Visible = true;
            iBtnClear.Visible  = true;
        }
        else
        {
            iBtnInsert.Visible = false;
            iBtnUpdate.Visible = false;
            iBtnDelete.Visible = false;
            iBtnClear.Visible  = false;
        }
    }

    private void SetEmptyForm()
    { 
        txtTermName.Text      = "";
        hdfVersionRefID.Value = "";
        txtVersionName.Text   = "";
        txtVersionDesc.Text   = "";
        txtVersionNumber.Text = "";
        txtRegDate.Text       = "";
        txtEnabelReg.Text     = "";
        this.IType = "A";
        this.SetButton();
    }

    private bool ValidateForm()
    {
        if (this.intEstTermID < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가기간정보가 올바르지 않습니다.", false);
            return false;
        }
        
        if (this.intKpiRefID < 1)
        {
            ltrScript.Text = JSHelper.GetAlertScript("KPI 정보가 올바르지 않습니다.", false);
            return false;
        }

        if ((this.IType == "A" || this.IType == "U") && txtVersionName.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("버젼명을 입력해 주십시오.", false);
            return false;
        }

        if ((this.IType == "A" || this.IType == "U") && txtVersionDesc.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("수정사유를 입력해 주십시오.", false);
            return false;
        }

        if ((this.IType == "U" || this.IType == "D") && hdfVersionRefID.Value.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("버젼ID를 알 수 없습니다.", false);
            return false;
        }

        return true;
    }

    private int TxrFormData()
    {
        if (!this.ValidateForm())
        {
            return 0;
        }

        Biz_Bsc_Kpi_Target_Version objBSC = new Biz_Bsc_Kpi_Target_Version();
        objBSC.Iestterm_ref_id        = this.intEstTermID;
        objBSC.Ikpi_ref_id            = this.intKpiRefID;
        objBSC.Ikpi_target_version_id = (this.IType == "A") ? -1 : int.Parse(this.hdfVersionRefID.Value.ToString());
        objBSC.Iversion_name          = txtVersionName.Text.Trim();
        objBSC.Iversion_desc          = txtVersionDesc.Text.Trim();

        int afftedRow = 0;
        if (this.IType == "A")
        {
            afftedRow = objBSC.InsertData(objBSC.Iestterm_ref_id, objBSC.Ikpi_ref_id, objBSC.Ikpi_target_version_id, objBSC.Iversion_name,
                                          objBSC.Iversion_desc, objBSC.Iversion_number, 12, "Y", gUserInfo.Emp_Ref_ID);

            if (objBSC.Transaction_Result == "Y")
            {
                this.hdfVersionRefID.Value = objBSC.Ikpi_target_version_id.ToString();
                this.intTergetVersion      = objBSC.Ikpi_target_version_id;

                this.SetVersionGrid();
                this.SetFormData();
            }

            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
        }
        else if (this.IType == "U")
        {
            afftedRow = objBSC.UpdateData(objBSC.Iestterm_ref_id, objBSC.Ikpi_ref_id, objBSC.Ikpi_target_version_id, objBSC.Iversion_name,
                                          objBSC.Iversion_desc, objBSC.Iversion_number, 12, "Y", gUserInfo.Emp_Ref_ID);
            if (objBSC.Transaction_Result == "Y")
            {
                this.SetVersionGrid();
                this.intTergetVersion = objBSC.Ikpi_target_version_id;
                this.SetFormData();
            }
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
        }
        else if (this.IType == "D")
        {
            afftedRow = objBSC.DeleteData(objBSC.Iestterm_ref_id, objBSC.Ikpi_ref_id, objBSC.Ikpi_target_version_id, gUserInfo.Emp_Ref_ID);
            this.SetVersionGrid();
            ltrScript.Text = JSHelper.GetAlertScript(objBSC.Transaction_Message, false);
        }
        else
        {
            afftedRow = 0;
        }

        return afftedRow;
    }

    private void SetVersionGrid()
    {
        Biz_Bsc_Kpi_Target_Version objKT = new Biz_Bsc_Kpi_Target_Version();
        DataSet ds = objKT.GetEnableRegTargetList(intEstTermID,intKpiRefID);

        if (ds.Tables.Count > 0)
        {
            ugrdTarget.DataSource = ds;
            ugrdTarget.DataBind();
        }
    }
    protected void SetFormData()
    {
        Biz_Bsc_Kpi_Target_Version objBSC = new Biz_Bsc_Kpi_Target_Version(intEstTermID, intKpiRefID, intTergetVersion);
        txtTermName.Text      = "";
        hdfVersionRefID.Value = objBSC.Ikpi_target_version_id.ToString();
        txtVersionName.Text   = objBSC.Iversion_name;
        txtVersionDesc.Text   = objBSC.Iversion_desc;
        txtVersionNumber.Text = objBSC.Iversion_number.ToString();
        txtRegDate.Text       = objBSC.Create_date.ToShortDateString();
        txtEnabelReg.Text     = (objBSC.IEnable_Reg == "Y") ? "등록가능" : "등록불가";

        this.IType = (objBSC.Ikpi_target_version_id > 0) ? "U" : "A";
        this.SetButton();
    }

    protected void SetFormData_Detail()
    {
        //Biz_Bsc_Kpi_Target objBSC = new Biz_Bsc_Kpi_Target();
        //DataTable dtBsc = objBSC.GetAllList_Detail(intEstTermID, intKpiRefID, intTergetVersion).Tables[0];


        MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target objBSC = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Target();
        DataTable dtBsc = objBSC.GetAllList_Detail(intEstTermID, intKpiRefID, intTergetVersion).Tables[0];

        UltraDetailList.DataSource = dtBsc;
        UltraDetailList.DataBind();
    }

    protected void ugrdTarget_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        intTergetVersion = int.Parse(e.SelectedRows[0].Cells.FromKey("KPI_TARGET_VERSION_ID").Value.ToString());
        this.SetFormData();
    }

    protected void iBtnReg_Click(object sender, ImageClickEventArgs e)
    {
        if (txtEnabelReg.Text.Trim() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("버젼을 선택해주십시오.", false);
        }
        else if (txtEnabelReg.Text.Trim() == "등록불가")
        {
            ltrScript.Text = JSHelper.GetAlertScript("해당버젼은 이미 등록 되었거나 사용할 수 없습니다.", false);
        }
        else
        {
            string strJavaScript = @"
                   <script language=javascript>
                     opener.document.forms[0].hdfinitial_version_yn.value    = 'N';
                     opener.document.forms[0].hdfkpi_target_version_id.value = document.forms[0].hdfVersionRefID.value;

                     if (opener) opener.__doPostBack('linkBtnRegTarget',''); 
                     self.close();
                   </script>
            ";
            ltrScript.Text = strJavaScript;
        }
    }
    protected void ugrdTarget_ActiveRowChange(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        intTergetVersion  = Convert.ToInt16(e.Row.Cells.FromKey("KPI_TARGET_VERSION_ID").Value.ToString());
        txtEnabelReg.Text = (e.Row.Cells.FromKey("ENABLE_REG").Value.ToString() == "Y") ? "등록가능" : "등록불가";
        this.SetFormData();

        /* 추가일자 : 이천씹년 구월 이씹구일
         * 추가작자 : 장동건
         * 추가요청 : 성덕여왕
         * 추가내용 : 여왕께 여쭤 보시미...
         * */
        this.SetFormData_Detail();
    }
    protected void iBtnClear_Click(object sender, ImageClickEventArgs e)
    {
        this.SetEmptyForm();
    }
    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        int intRtn = this.TxrFormData();
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        int intRtn = this.TxrFormData();
    }
    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "D";
        int intRtn = this.TxrFormData();
        if (intRtn > 0)
        {
            this.IType = "A";
            this.SetEmptyForm();
            this.SetButton();
        }
        else
        { 
            this.IType = "U";
        }
    }
}
