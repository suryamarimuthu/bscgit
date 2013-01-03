using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Infragistics.WebUI.UltraWebGrid;

using MicroBSC.Biz.Common.Biz;
using MicroBSC.Estimation.Biz;

public partial class EST_EST0901S1 : EstPageBase
{
    #region 변수선언
    private int _iestterm_ref_id = 0;
    private string _iymd = "";
    private string _pos_grp_code = "";
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.InitControlValue();
        }
    }

    private void InitControlValue()
    {
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);

        int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        DropDownListCommom.BindPositionGroup(ddlPositionGrp, true);
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intEstTermId = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlEstTermMonth, intEstTermId);
        this.SetResultListGrid();
    }

    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.SetResultListGrid();
    }

    #region 내부함수
    public void SetResultListGrid()
    {
        if (PageUtility.GetByValueDropDownList(ddlPositionGrp) == "0" || ddlPositionGrp.SelectedIndex == 0)
        {
            string sErr = "<script language='javascript' type='text/javascript'>\n"
                + "alert('[직군]을 선택하십시요.');\n"
                + "try {\n"
                + "     document.getElementById('ddlPositionGrp').select();\n"
                + "} catch(e){}\n"
                + "</script>";
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "selectPos", sErr);
            return;
        }

        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");
        _pos_grp_code = PageUtility.GetByValueDropDownList(ddlPositionGrp, "");

        DataTable _estData1 = new DataTable();
        DataTable _estData2 = new DataTable();
        Biz_Datas est_data = new Biz_Datas();

        _estData1 = est_data.GetGroupEavluation(COMP_ID, _iestterm_ref_id, _iymd, _pos_grp_code).Tables[0];
        _estData2 = est_data.GetGroupEavluationData(COMP_ID, _iestterm_ref_id, _iymd, _pos_grp_code).Tables[0];

        ugrdResultTotal.DataSource = _estData1;
        ugrdResultTotal.DataBind();

        if (_estData2.Rows.Count > 0)
        {
            ltGROUP_MEAN.Text = _estData2.Rows[0]["GROUP_MEAN"].ToString();
            ltSTANDARD_DEVIATION.Text = _estData2.Rows[0]["STANDARD_DEVIATION"].ToString();

            /* 2011-05-06 수정 : 원점수의 최대값과 최소값을 설정하고 표시하도록 수정 */
            //_estDataSet.Tables[0].DefaultView.DataViewManager.
            DataTable dtPersonEval = _estData1;

            numMaxValue.Value = dtPersonEval.Compute("MAX(POINT_SUM)", null);
            numMinValue.Value = dtPersonEval.Compute("MIN(POINT_SUM)", null);
            /* 2011-05-06 수정 완료 ****************************************************/
        }
    }

    public void SetResultListGridDN()
    {
        _iestterm_ref_id = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        _iymd = PageUtility.GetByValueDropDownList(ddlEstTermMonth, "");

        DataTable _estData1 = new DataTable();
        Biz_Datas est_data = new Biz_Datas();

        _estData1 = est_data.GetGroupEavluation(COMP_ID, _iestterm_ref_id, _iymd, "").Tables[0];

        ugrdResultTotalDN.DataSource = _estData1;
        ugrdResultTotalDN.DataBind();
    }

    /// <summary>
    /// 다운로드
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void iBtnExcelExport_Click(object sender, ImageClickEventArgs e)
    {
        SetResultListGridDN();
        string _filename = "BSC_GROUP_Evaluation_" + ddlEstTermMonth.SelectedItem.Value.Replace("/", "_") + ".xls";
        _filename = HttpUtility.UrlEncode(_filename, System.Text.Encoding.UTF8);
        uGridExcelExporter.DownloadName = _filename;
        uGridExcelExporter.WorksheetName = "BSC_GROUP_Evaluation_DATA";

        uGridExcelExporter.Export(ugrdResultTotalDN);
    }

    #endregion
}