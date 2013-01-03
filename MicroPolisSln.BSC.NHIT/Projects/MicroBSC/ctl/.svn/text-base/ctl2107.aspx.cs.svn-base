using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Biz;
using MicroBSC.Common;

public partial class ctl_ctl2107 : AppPageBase
{
    #region ========================== [ Variables Declare ] ======================================


    #endregion

    #region ========================== [ Page Initialize ] ======================================

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        if (!IsPostBack)
        {
            this.GetBscDeptInfo();
        }
    }

    #endregion

    #region ========================== [ Page Function ] ======================================
    private void GetBscDeptInfo()
    {
        string sErr = "";
        Biz_Com_Low_HR_Info objCom = new Biz_Com_Low_HR_Info();
        DataTable dtDept = objCom.GetCompareDeptInfo(out sErr);
        DataTable dtEmp  = objCom.GetCompareEmpInfo(out sErr);

        ugrdDept.Clear();
        if (dtDept == null)
        {
            ltrScript.Text = JSHelper.GetAlertScript(sErr, false);
        }
        else
        {
            ugrdDept.DataSource = dtDept.DefaultView;
            ugrdDept.DataBind();        
        }

        ugrdDeptEmp.Clear();
        if (dtEmp == null)
        {
            ltrScript.Text = JSHelper.GetAlertScript(sErr, false);
        }
        else
        {
            ugrdDeptEmp.DataSource = dtEmp.DefaultView;
            ugrdDeptEmp.DataBind();
        }

    }

    #endregion

    #region ========================== [ Event ] ======================================
    protected void ugrdDept_InitializeRow(object sender, RowEventArgs e)
    {
        string sBscDeptCd = (e.Row.Cells.FromKey("BSC_DEPT_REF_ID").Value == null) ? "" : e.Row.Cells.FromKey("BSC_DEPT_REF_ID").Value.ToString();
        string sLowDeptCd = (e.Row.Cells.FromKey("LOW_DEPT_REF_ID").Value == null) ? "" : e.Row.Cells.FromKey("LOW_DEPT_REF_ID").Value.ToString();

        if ((sBscDeptCd == sLowDeptCd))
        {
            e.Row.Cells.FromKey("STATUS").Value = "일치";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Blue;
        }
        else if ((sBscDeptCd == "" && sLowDeptCd != ""))
        {
            e.Row.Cells.FromKey("STATUS").Value = "신규생성";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Red;
        }
        else if ((sBscDeptCd != "" && sLowDeptCd == ""))
        {
            e.Row.Cells.FromKey("STATUS").Value = "삭제/불일치";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            e.Row.Cells.FromKey("STATUS").Value = "불일치";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Red;
        }

    }

    protected void ugrdDeptEmp_InitializeRow(object sender, RowEventArgs e)
    {
        string sBscDeptCd = (e.Row.Cells.FromKey("BSC_DEPT_REF_ID").Value == null) ? "" : e.Row.Cells.FromKey("BSC_DEPT_REF_ID").Value.ToString();
        string sLowDeptCd = (e.Row.Cells.FromKey("LOW_DEPT_REF_ID").Value == null) ? "" : e.Row.Cells.FromKey("LOW_DEPT_REF_ID").Value.ToString();
        string sBscEmpCd  = (e.Row.Cells.FromKey("BSC_EMP_REF_ID").Value == null) ? "" : e.Row.Cells.FromKey("BSC_EMP_REF_ID").Value.ToString();
        string sLowEmpCd  = (e.Row.Cells.FromKey("LOW_EMP_REF_ID").Value == null) ? "" : e.Row.Cells.FromKey("LOW_EMP_REF_ID").Value.ToString();

        if ((sBscDeptCd == sLowDeptCd) && (sBscEmpCd == sLowEmpCd))
        {
            e.Row.Cells.FromKey("STATUS").Value = "일치";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Blue;
        }
        else if ((sBscDeptCd != sLowDeptCd) && (sBscEmpCd == sLowEmpCd) && (sBscDeptCd != "" && sLowEmpCd != ""))
        {
            e.Row.Cells.FromKey("STATUS").Value = "부서이동";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Red;
        }
        else if ((sBscDeptCd != "" && sLowDeptCd == "") && (sBscEmpCd != "" && sLowEmpCd == ""))
        {
            e.Row.Cells.FromKey("STATUS").Value = "퇴사";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Red;
        }
        else if ((sBscDeptCd == "" && sBscEmpCd == "") && (sLowDeptCd != "" && sLowEmpCd != ""))
        {
            e.Row.Cells.FromKey("STATUS").Value = "신규입사";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            e.Row.Cells.FromKey("STATUS").Value = "불일치";
            e.Row.Cells.FromKey("STATUS").Style.ForeColor = System.Drawing.Color.Red;
        }
     }

    protected void ugrdDeptEmp_InitializeLayout(object sender, LayoutEventArgs e)
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
        ch.Caption = "성과관리시스템";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 0;
        ch.RowLayoutColumnInfo.SpanX = 2;
        ch.Style.Height = Unit.Pixel(17);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "기간계시스템";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 2;
        ch.RowLayoutColumnInfo.SpanX = 3;
        ch.Style.Height = Unit.Pixel(17);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = new Infragistics.WebUI.UltraWebGrid.ColumnHeader(true);
        ch.Caption = "상태";
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanX = 1;
        ch.Style.Height = Unit.Pixel(17);
        e.Layout.Bands[0].HeaderLayout.Add(ch);
        e.Layout.Bands[0].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

        ch = e.Layout.Bands[0].Columns[5].Header;
        ch.RowLayoutColumnInfo.OriginY = 0;
        ch.RowLayoutColumnInfo.OriginX = 5;
        ch.RowLayoutColumnInfo.SpanY   = 2;
    }
    #endregion
}
