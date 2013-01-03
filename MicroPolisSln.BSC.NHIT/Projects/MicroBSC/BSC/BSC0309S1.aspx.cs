using System;
using System.Data;
using System.Web.UI;

using MicroBSC.Integration.BSC.Biz;

public partial class BSC_BSC0309S1 : AppPageBase
{
    Biz_Bsc_Kpi_Eqt_Eql bizBscKpiEqtEql;

    int COMP_ID;
    int ESTTERM_REF_ID;
    string EST_TYPE;
    int DEPT_REF_ID;
    int CHAMPION_EMP_REF_ID;
    string IS_TEAM_KPI_YN;
    string KPI_CODE;
    string KPI_NAME;

    protected void Page_Load(object sender, EventArgs e)
    {
        bizBscKpiEqtEql = new Biz_Bsc_Kpi_Eqt_Eql();

        if (this.txtChampion_Emp_Name.Text.Trim().Length == 0)
            this.hdfChampion_Emp_Ref_Id.Value = "";
        if (this.txtDept_Name.Text.Trim().Length == 0)
        {
            this.txtChampion_Emp_Name.Text = "";
            this.hdfChampion_Emp_Ref_Id.Value = "";
            this.hdfDept_Ref_Id.Value = "";
        }


        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);


            COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
            ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
            EST_TYPE = WebUtility.GetByValueDropDownList(ddlEstType);
            DEPT_REF_ID = DataTypeUtility.GetToInt32(this.hdfDept_Ref_Id.Value);
            CHAMPION_EMP_REF_ID = DataTypeUtility.GetToInt32(this.hdfChampion_Emp_Ref_Id.Value);
            IS_TEAM_KPI_YN = WebUtility.GetByValueDropDownList(ddlIsTeamKpi);
            KPI_CODE = this.txtKpiCode.Text;
            KPI_NAME = this.txtKpiName.Text;

            ibnSearch_Click(null, null);
        }

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        EST_TYPE = WebUtility.GetByValueDropDownList(ddlEstType);
        DEPT_REF_ID = DataTypeUtility.GetToInt32(this.hdfDept_Ref_Id.Value);
        CHAMPION_EMP_REF_ID = DataTypeUtility.GetToInt32(this.hdfChampion_Emp_Ref_Id.Value);
        IS_TEAM_KPI_YN = WebUtility.GetByValueDropDownList(ddlIsTeamKpi);
        KPI_CODE = this.txtKpiCode.Text;
        KPI_NAME = this.txtKpiName.Text;

        ltrScript.Text = "";
    }





    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        doBind_Kpi_Eqt_Eql_List();
    }
    protected void doBind_Kpi_Eqt_Eql_List()
    {
        ugrdKpiList.Clear();

        Biz_Bsc_Kpi_Eqt_Eql.EST_TYPE est_type = new Biz_Bsc_Kpi_Eqt_Eql.EST_TYPE();

        if (EST_TYPE.Equals("EQT"))
            est_type = Biz_Bsc_Kpi_Eqt_Eql.EST_TYPE.EQT;
        else
            est_type = Biz_Bsc_Kpi_Eqt_Eql.EST_TYPE.EQL;

        DataTable dt = bizBscKpiEqtEql.Get_Kpi_Eqt_Eql_Ratio(ESTTERM_REF_ID
                                                            , est_type
                                                            , DEPT_REF_ID
                                                            , CHAMPION_EMP_REF_ID
                                                            , IS_TEAM_KPI_YN
                                                            , KPI_CODE
                                                            , KPI_NAME);

        ugrdKpiList.DataSource = dt;
        ugrdKpiList.DataBind();
    }





    protected void ibnAllSave_Click(object sender, ImageClickEventArgs e)
    {
        AllSave_Eqt_Eql_Ratio();
    }
    protected void AllSave_Eqt_Eql_Ratio()
    {
        int eqtValue = DataTypeUtility.GetToInt32(this.txtEqtValue.Text);
        int eqlValue = DataTypeUtility.GetToInt32(this.txtEqlValue.Text);

        DataTable dt = new DataTable();
        dt.Columns.Add("KPI_REF_ID");
        dt = UltraGridUtility.GetDataTableByCheckValue(this.ugrdKpiList, "cBox", "selchk", new string[] { "KPI_REF_ID" }, dt);


        bool result = bizBscKpiEqtEql.Set_Kpi_Eqt_Eql_Ratio(ESTTERM_REF_ID
                                                            , dt
                                                            , eqtValue
                                                            , eqlValue
                                                            , gUserInfo.Emp_Ref_ID);

        if (result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저리되었습니다.");
            doBind_Kpi_Eqt_Eql_List();
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다.");
        }
    }
}
