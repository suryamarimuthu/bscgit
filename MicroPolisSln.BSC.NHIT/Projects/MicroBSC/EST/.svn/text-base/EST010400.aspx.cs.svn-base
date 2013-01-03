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

using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using MicroBSC.Biz.BSC;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;

using MicroBSC.Estimation.Biz;

public partial class EST_EST010400 : EstPageBase
{
	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            BindingScaleInfo(WebUtility.GetIntByValueDropDownList(ddlCompID), "");
            ButtonStatusByInit();

            ibnDelete.Attributes.Add("onclick", string.Format( "return confirm( '{0}' );", "정말 삭제하시겠습니까?") );
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);

        ltrScript.Text  = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindingScaleInfo(COMP_ID, "");
        ButtonStatusByInit();
    }

    protected void ibnCheckID_Click(object sender, ImageClickEventArgs e)
    {
        if (txtScaleID.Text.Equals("")) 
        {
            ltrScript.Text = JSHelper.GetAlertScript( "평가방법 ID를 입력하세요." );
            return;
        }

        Biz_ScaleInfos scaleInfo = new Biz_ScaleInfos();

        if (scaleInfo.IsExist(COMP_ID, txtScaleID.Text))
        {
            ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가방법 ID 입니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("사용가능한 평가방법 ID 입니다.");
        }
    }

    protected void ibnNew_Click(object sender, ImageClickEventArgs e)
    {
        ButtonStatusByNew();
    }
    
    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_ScaleInfos scaleInfo = new Biz_ScaleInfos();

        if (PageWriteMode == WriteMode.New)
        {
            if (txtScaleID.Text.Equals("")) 
            {
                ltrScript.Text = JSHelper.GetAlertScript("평가방법 ID를 입력하세요.");
                return;
            }

            if (scaleInfo.IsExist(COMP_ID, txtScaleID.Text))
            {
                ltrScript.Text = JSHelper.GetAlertScript("존재하는 평가방법 ID 입니다.");
                return;
            }

            bool isOK = scaleInfo.AddScaleInfo(   COMP_ID
                                                , txtScaleID.Text
                                                , txtScaleName.Text
                                                , DataTypeUtility.GetBooleanToYN(cbUseYN.Checked)
                                                , DateTime.Now
                                                , EMP_REF_ID);

            if (isOK)
            {
                BindingScaleInfo(COMP_ID, "");
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 등록되지 않았습니다.");
                return;
            }    
        }
        else if (PageWriteMode == WriteMode.Modify)
        {
            if (hdfScaleInfo.Value.Equals(""))
            {
                ltrScript.Text = JSHelper.GetAlertScript("선택된 연결방법이 없습니다.");
                return;
            }

            bool isOK = scaleInfo.ModifyScaleInfo(COMP_ID
                                                , hdfScaleInfo.Value
                                                , txtScaleName.Text
                                                , DataTypeUtility.GetBooleanToYN(cbUseYN.Checked)
                                                , DateTime.Now
                                                , EMP_REF_ID);

            if (isOK)
            {
                BindingScaleInfo(COMP_ID, "");
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 수정되지 않았습니다.");
                return;
            }
        }

        ButtonStatusByInit();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Data;
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0) 
        {
            string scale_id = e.SelectedRows[0].Cells.FromKey("SCALE_ID").Value.ToString();

            SelectScaleInfo(COMP_ID, scale_id);
            ButtonStatusByModify();
        }
    }

    private void BindingScaleInfo(int comp_id, string scale_id) 
    {
        Biz_ScaleInfos scaleInfo      = new Biz_ScaleInfos();
        DataSet ds                    = scaleInfo.GetScaleInfo(comp_id, scale_id, "");
        UltraWebGrid1.DataSource      = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text              = ds.Tables[0].Rows.Count.ToString();
    }
    
    protected void ibnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Biz_ScaleInfos scaleInfo = new Biz_ScaleInfos();

        if (hdfScaleInfo.Value.Equals(""))
        {
            ltrScript.Text  = JSHelper.GetAlertScript("선택된 평가방법이 없습니다.");
            return;
        }

        bool isOK           = scaleInfo.RemoveScaleInfo(COMP_ID, hdfScaleInfo.Value);

        if (isOK)
        {
            BindingScaleInfo(COMP_ID, "");
            ButtonStatusByInit();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 삭제가 처리되지 않았습니다.");
            return;
        }
    }

    private void SelectScaleInfo(int comp_id, string scale_id) 
    {
        Biz_ScaleInfos scaleInfo  = new Biz_ScaleInfos(comp_id, scale_id);

        hdfScaleInfo.Value      = scale_id;
        txtScaleID.Text         = scaleInfo.Scale_ID;
        txtScaleName.Text       = scaleInfo.Scale_Name;
        cbUseYN.Checked         = DataTypeUtility.GetYNToBoolean(scaleInfo.Use_YN);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingScaleInfo(COMP_ID, "");
        ClearValueControls();
    }

    private void ClearValueControls() 
    {
        hdfScaleInfo.Value      = "";
        txtScaleID.Text         = "";
        txtScaleName.Text       = "";
        cbUseYN.Checked         = true;
    }

    private void ButtonStatusByInit() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = false;
        ibnDelete.Enabled       = false;

        ibnCheckID.Visible      = false;
        txtScaleID.Width        = Unit.Percentage(100);
        txtScaleID.Enabled      = false;

        ClearValueControls();

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.None;
    }

    private void ButtonStatusByNew() 
    {
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;
        ibnDelete.Enabled       = false;

        ibnCheckID.Visible      = true;
        txtScaleID.Width        = Unit.Percentage(60);
        txtScaleID.Enabled      = true;

        ClearValueControls();

        ibnSave.ImageUrl        = "../images/btn/b_tp07.gif";//"저장";

        PageWriteMode           = WriteMode.New;
    }

    private void ButtonStatusByModify() 
    {
      
        ibnNew.Enabled          = true;
        ibnSave.Enabled         = true;
        ibnDelete.Enabled       = true;

        ibnCheckID.Visible      = false;
        txtScaleID.Width        = Unit.Percentage(100);
        txtScaleID.Enabled      = false;

        ibnSave.ImageUrl        = "../images/btn/b_002.gif";//"수정";

        PageWriteMode           = WriteMode.Modify;
    }
}
