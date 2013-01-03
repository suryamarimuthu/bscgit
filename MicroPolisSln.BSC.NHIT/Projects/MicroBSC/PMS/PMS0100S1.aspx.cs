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
using MicroBSC.Integration.PMS.Biz;

public partial class PMS_PMS0100S1 : EstPageBase
{
    Biz_Pms_Com_Info bizPmsComInfo;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }




    protected void Page_Load(object sender, EventArgs e)
    {
        bizPmsComInfo = new Biz_Pms_Com_Info();

        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            bindData();
        }


        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);

        ltrScript.Text = "";
        setSaveBtn(true);
    }


    protected void setSaveBtn(bool state)
    {
        this.ibnSave.Enabled = state;
        this.ibnSave.Visible = state;
    }



    public void bindData()
    {
        int Idx = 1;

        DataTable DT = bizPmsComInfo.Get_Pms_Com_Info(Idx);

        this.txtIF_COL_ID.Text = DT.Rows[0]["IF_COL_ID"].ToString();
        this.txtIF_COL_NAME.Text = DT.Rows[0]["IF_COL_NAME"].ToString();
        this.txtCUSTOM_COL_ID.Text = DT.Rows[0]["CUSTOM_COL_ID"].ToString();
        this.txtCUSTOM_COL_NAME.Text = DT.Rows[0]["CUSTOM_COL_NAME"].ToString();
        this.txtSOOSIK.Text = DT.Rows[0]["SOOSIK"].ToString();
        this.txtSOOSIK_DESC.Text = DT.Rows[0]["SOOSIK_DESC"].ToString();
    }



    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        saveInfo();


        //SMS테스트
        //
        //MicroBSC.Integration.ETC.Biz.Biz_Nhis_Hist_Sd objSMS = new MicroBSC.Integration.ETC.Biz.Biz_Nhis_Hist_Sd();
        //bool result = objSMS.Add_Nhis_Hist_Sd("01029124856", "1234", "이거슨test123!@#$");
        //if (result)
        //{
        //    this.ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
        //}
        //else
        //{
        //    this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패하였습니다.");
        //}
    }


    protected void saveInfo()
    {
        bool Result;

        string IF_COL_ID = this.txtIF_COL_ID.Text;
        string IF_COL_NAME = this.txtIF_COL_NAME.Text;
        string CUSTOM_COL_ID = this.txtCUSTOM_COL_ID.Text;
        string CUSTOM_COL_NAME = this.txtCUSTOM_COL_NAME.Text;
        string SOOSIK = this.txtSOOSIK.Text;
        string soosik_desc = this.txtSOOSIK_DESC.Text;

        SiteIdentity gUserInfo = (SiteIdentity)Context.User.Identity;

        Result = bizPmsComInfo.Add_Pms_Com_Info(IF_COL_ID
                                                , IF_COL_NAME
                                                , CUSTOM_COL_ID
                                                , CUSTOM_COL_NAME
                                                , SOOSIK
                                                , soosik_desc
                                                , gUserInfo.Emp_Ref_ID.ToString());

        if (Result)
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장되었습니다.");
        }
        else
        {
            this.ltrScript.Text = JSHelper.GetAlertScript("저장에 실패하였습니다.");
        }
    }
}

