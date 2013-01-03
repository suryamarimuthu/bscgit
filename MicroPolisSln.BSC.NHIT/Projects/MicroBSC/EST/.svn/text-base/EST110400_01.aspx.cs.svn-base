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
using System.Drawing;

using MicroBSC.Estimation.Biz;

public partial class EST110400_01 : EstPageBase
{
    protected string ICCB1
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
    private int ICOMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
                ViewState["COMP_ID"] = 0;
            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }
    private string IEST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
                ViewState["EST_ID"] = "";
            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ICOMP_ID = WebUtility.GetRequestByInt("COMP_ID", 0);
            this.IEST_ID = WebUtility.GetRequest("EST_ID", "");

            DoBinding();
        }

        ltrScript.Text = "";
    }

    protected void ugrdGroup_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        e.Row.Cells.FromKey("USE_YN_I").Value = string.Format("<img alt='' src='../images/icon_{0}.gif' />", (((DataRowView)e.Data)["USE_YN"].ToString() == "Y" ? "o" : "x"));
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        //Biz_BiasDatas bizBias = new Biz_BiasDatas();
        //int biasID = bizBias.SaveBiasGroup(this.ICOMP_ID
        //                                    , this.IEST_ID
        //                                    , DataTypeUtility.GetToInt32(hdfBIAS_GRP_ID.Value)
        //                                    , txtBIAS_GRP_CD.Text.Trim()
        //                                    , txtBIAS_GRP_NM.Text.Trim()
        //                                    , txtBIAS_GRP_DESC.Text.Trim()
        //                                    , DataTypeUtility.GetBooleanToYN(chkUSE_YN.Checked)
        //                                    , gUserInfo.Emp_Ref_ID);

        MicroBSC.Integration.EST.Biz.Biz_Est_Bias_Group bizEstBiasGroup = new MicroBSC.Integration.EST.Biz.Biz_Est_Bias_Group();
        DataTable dtEstBiasGroup = bizEstBiasGroup.GetBiasGroup_DB(this.ICOMP_ID
                                                                    , this.IEST_ID
                                                                    , txtBIAS_GRP_CD.Text.Trim());
        int biasID = 0;
        if (dtEstBiasGroup.Rows.Count > 0)
        {
            //biasID = DataTypeUtility.GetToInt32(dtEstBiasGroup.Rows[0]["BIAS_GRP_ID"]);
            biasID = bizEstBiasGroup.ModifyEstBiasGroup_DB(this.ICOMP_ID
                                                        , this.IEST_ID
                                                        , DataTypeUtility.GetToInt32(hdfBIAS_GRP_ID.Value)
                                                        , txtBIAS_GRP_CD.Text.Trim()
                                                        , txtBIAS_GRP_NM.Text.Trim()
                                                        , txtBIAS_GRP_DESC.Text.Trim()
                                                        , DataTypeUtility.GetBooleanToYN(chkUSE_YN.Checked)
                                                        , gUserInfo.Emp_Ref_ID);
        }
        else
        {
            biasID = bizEstBiasGroup.AddEstBiasGroup_DB(this.ICOMP_ID
                                                    , this.IEST_ID
                                                    , DataTypeUtility.GetToInt32(hdfBIAS_GRP_ID.Value)
                                                    , txtBIAS_GRP_CD.Text.Trim()
                                                    , txtBIAS_GRP_NM.Text.Trim()
                                                    , txtBIAS_GRP_DESC.Text.Trim()
                                                    , DataTypeUtility.GetBooleanToYN(chkUSE_YN.Checked)
                                                    , gUserInfo.Emp_Ref_ID);
        }

        if (biasID > 0)
        {
            hdfChangeYN.Value = "1";
            hdfBIAS_GRP_ID.Value = biasID.ToString();
            DoBinding();
            txtBIAS_GRP_CD.Style.Add("readOnly", "readonly");
            ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
        }
        else
        {
            if (biasID == -1)
                ltrScript.Text = JSHelper.GetAlertScript("이미 등록된 그룹코드입니다.\\n저장실패!");
            else
                ltrScript.Text = JSHelper.GetAlertScript("저장 실패!");
        }
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        //Biz_BiasDatas bizBias = new Biz_BiasDatas();
        //if (bizBias.DeleteBiasGroup(this.ICOMP_ID
        //                            , this.IEST_ID
        //                            , DataTypeUtility.GetToInt32(hdfBIAS_GRP_ID.Value)))
        //{
        //    hdfChangeYN.Value = "1";
        //    hdfBIAS_GRP_ID.Value = "0";
        //    txtBIAS_GRP_CD.Text = txtBIAS_GRP_NM.Text = txtBIAS_GRP_DESC.Text = string.Empty;
        //    chkUSE_YN.Checked = true;
        //    DoBinding();
        //    ltrScript.Text = JSHelper.GetAlertScript("삭제되었습니다.");
        //}
        //else
        //    ltrScript.Text = JSHelper.GetAlertScript(string.Format("삭제 실패!\\n{0}", bizBias.errMSG.Replace("\\", "").Replace("'", "")));

        MicroBSC.Integration.EST.Biz.Biz_Est_Bias_Group bizEstBiasGroup = new MicroBSC.Integration.EST.Biz.Biz_Est_Bias_Group();
        bool isOK = bizEstBiasGroup.RemoveEstBiasGroup_DB(DataTypeUtility.GetToInt32(hdfBIAS_GRP_ID.Value));

        if (isOK)
        {
            hdfChangeYN.Value = "1";
            hdfBIAS_GRP_ID.Value = "0";
            txtBIAS_GRP_CD.Text = txtBIAS_GRP_NM.Text = txtBIAS_GRP_DESC.Text = string.Empty;
            chkUSE_YN.Checked = true;
            DoBinding();
            ltrScript.Text = JSHelper.GetAlertScript("삭제되었습니다.");
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("삭제 실패!");
    }

    private void DoBinding()
    {
        Biz_BiasDatas bizBias = new Biz_BiasDatas();
        DataTable dt = bizBias.GetBiasGroup(this.ICOMP_ID, this.IEST_ID, "");

        ugrdGroup.DataSource = dt;
        ugrdGroup.DataBind();
    }
}
