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
using System.Data.SqlClient;
using System.Drawing;

using MicroBSC.Biz.BSC;
using MicroBSC.Estimation.Dac;
using MicroBSC.Common;
using MicroBSC.Data;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;

public partial class ctl_ctl4203 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            this.initForm();
            this.setGridClose();
            return;
        }
    }

    private void initForm()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        //StrategyMapInfos stgMapInfo = new StrategyMapInfos();
        hdnTermID.Value = ddlEstTermInfo.SelectedValue.ToString();
    }

    private void setGridClose()
    {
        string strSQL = @"
                SELECT KPI_REF_ID,
                       KPI_CODE,
	                   KPI_NAME
                  FROM KPI_INFO
                 WHERE KPI_CODE LIKE ('"+ txtSKpiCode.Text +@"'+'%')
                   AND KPI_NAME LIKE ('"+ txtSKpiName.Text + @"'+'%')
                   AND RESULT_INPUT_METHOD = 'SYS'
                 ORDER BY KPI_NAME
        ";
        MicroBSC.Data.DBAgent gDbAgent = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        DataSet dsClose = gDbAgent.FillDataSet(strSQL, "tblClose");
        ugrdClose.DataSource = dsClose;
        ugrdClose.DataBind();        
    }

    private void setFormData()
    {
        int intKpi_Ref_ID = int.Parse(hdnKpiRefID.Value.ToString());
        string strSQL = @"
                SELECT KI.KPI_NAME,
                       KL.QRY_DATA,
	                   KL.QRY_MS,
	                   KL.QRY_TS,
                       KI.KPI_REF_ID
                  FROM KPI_INFO KI, KPI_LOW KL
                 WHERE KI.KPI_REF_ID = KL.KPI_REF_ID
                   AND KI.KPI_REF_ID = " + intKpi_Ref_ID + @"
        ";

        MicroBSC.Data.DBAgent gDbAgent = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        DataSet dsClose = gDbAgent.FillDataSet(strSQL, "tblClose");
        if (dsClose.Tables[0].Rows.Count > 0)
        {
            txtKPIName.Text = dsClose.Tables[0].Rows[0]["KPI_NAME"].ToString();
            txtQRY_DATA.Text = dsClose.Tables[0].Rows[0]["QRY_DATA"].ToString();
            txtQRY_MS.Text = dsClose.Tables[0].Rows[0]["QRY_MS"].ToString();
            txtQRY_TS.Text = dsClose.Tables[0].Rows[0]["QRY_TS"].ToString();
        }
        else
        {
            txtKPIName.Text = "";
            txtQRY_DATA.Text = "";
            txtQRY_MS.Text = "";
            txtQRY_TS.Text = "";
        }
    }

    private void updateQuery()
    {
        string strSQL = @"
                UPDATE KPI_LOW
                   SET QRY_DATA = @I_QRY_DATA,
                       QRY_MS   = @I_QRY_MS,
                       QRY_TS   = @I_QRY_TS
                 WHERE KPI_REF_ID = @I_KPI_REF_ID
        ";

        IDbDataParameter[] arrOpm = DbAgentBase.CreateDataParameters(4);

        arrOpm[0]       = DbAgentBase.CreateDataParameter("@I_QRY_DATA", SqlDbType.VarChar, 1000);
        arrOpm[0].Value = txtQRY_DATA.Text;
        arrOpm[1]       = DbAgentBase.CreateDataParameter("@I_QRY_MS", SqlDbType.VarChar, 1000);
        arrOpm[1].Value = txtQRY_MS.Text;
        arrOpm[2]       = DbAgentBase.CreateDataParameter("@I_QRY_TS", SqlDbType.VarChar, 1000);
        arrOpm[2].Value = txtQRY_TS.Text;
        arrOpm[3]       = DbAgentBase.CreateDataParameter("@I_KPI_REF_ID", SqlDbType.Int, 8);
        arrOpm[3].Value = int.Parse(hdnKpiRefID.Value.ToString());

        int intRtn = DbAgentHelper.CreateDbAgent().ExecuteNonQuery(strSQL, arrOpm, CommandType.Text);
    }


    protected void ugrdClose_InitializeLayout(object sender, LayoutEventArgs e)
    {


    }
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.setGridClose();
    }
    protected void ugrdClose_DblClick(object sender, ClickEventArgs e)
    {
        //hdnKpiRefID.Value = e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString();
        //this.setFormData();
        return;
    }

    protected void imgBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (hdnKpiRefID.Value == "")
        {
            ltlMsg.Text = JSHelper.GetAlertScript("KPI 정보가 정확하지 않습니다.", false);
            return;
        }

        this.updateQuery();
    }
    protected void ugrdClose_Click(object sender, ClickEventArgs e)
    {
        hdnKpiRefID.Value = e.Row.Cells.FromKey("KPI_REF_ID").Value.ToString();
        this.setFormData();
    }
}
