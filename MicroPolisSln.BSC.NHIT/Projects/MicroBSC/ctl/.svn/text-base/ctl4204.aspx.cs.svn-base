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
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;

public partial class ctl_ctl4204 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            this.initForm();
            this.setGridClose();
            return;
        }

        this.ugrdClose.Columns.FromKey("EMP_NAME").Header.Caption = this.GetText("LBL_00001", "챔피언");
    }

    private void initForm()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

        hdnTermID.Value = PageUtility.GetByValueDropDownList(ddlEstTermInfo);
        hdnTermMM.Value = PageUtility.GetByValueDropDownList(ddlMonthInfo);
    }

    private void setGridClose()
    {
        string strSQL = @"
                SELECT KI.KPI_CODE as KPI_CODE, 
                       KI.KPI_NAME as KPI_NAME,
	                   CD.DEPT_NAME as DEPT_NAME, 
	                   CE.EMP_NAME as EMP_NAME,
	                   KR.RESULT   as MS_RESULT,
	                   KR.COLRESULT as TS_RESULT,
	                   KR.CAL_MS_RESULT as CAL_MS_RESUTL, 
	                   KR.CAL_TS_RESULT as CAL_TS_RESULT,
	                   KR.CAL_MODIFY_REASON as MREASON
                  FROM KPI_INFO KI,
                       KPI_RESULT KR,
	                   COM_EMP_INFO CE,
	                   COM_DEPT_INFO CD,
	                   REL_DEPT_EMP RD
                 WHERE KI.KPI_REF_ID = KR.KPI_REF_ID
                   AND KI.CHAMPION_EMP_ID = CE.EMP_REF_ID
                   AND RD.DEPT_REF_ID = CD.DEPT_REF_ID
                   AND RD.EMP_REF_ID = CE.EMP_REF_ID
                   AND KR.TMCODE = " + ddlMonthInfo.SelectedValue.ToString() + @"
                   AND KR.CAL_APPLY_YN = 0            --RESULT NOT APPLY
                   AND KI.RESULT_INPUT_METHOD = 'SYS' --SYSTEM
                   AND KR.CONFIRMSTATUS = 1           --CONFIRM
                   AND KI.ESTTERM_REF_ID = " + ddlEstTermInfo.SelectedValue.ToString() +@"
        ";
        MicroBSC.Data.DBAgent gDbAgent = new MicroBSC.Data.DBAgent(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
        DataSet dsClose = gDbAgent.FillDataSet(strSQL, "tblClose");
        ugrdClose.DataSource = dsClose;
        ugrdClose.DataBind();
    }


    protected void ugrdClose_InitializeLayout(object sender, LayoutEventArgs e)
    {
        int iIndex = 0;
        Infragistics.WebUI.UltraWebGrid.ColumnHeader ch;

        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridColumn c in e.Layout.Bands[0].Columns)
        {
            c.Header.RowLayoutColumnInfo.OriginY = 1;
            iIndex++;
        }

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "KPI_CODE";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "KPI명";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "부서명";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "챔피언명";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "확정실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 4;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "산식실적";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 6;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(20);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[0].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[1].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 1;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[2].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanY = 2;

        ch = e.Layout.Bands[0].Columns[3].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 3;
        ch.RowLayoutColumnInfo.SpanY = 2;

    }
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.txtReason.Text = "";
        this.setGridClose();
    }
    protected void ddlMonthInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
