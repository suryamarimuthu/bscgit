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

public partial class EST_EST060600 : EstPageBase
{
    private int ESTTERM_REF_ID_FROM;
    private int ESTTERM_REF_ID_TO;
    private int ESTTERM_SUB_ID_FROM;
    private int ESTTERM_SUB_ID_TO;

	protected void Page_Init( object sender, EventArgs e )
	{
		SetPageLayout(phdLayout, phdBottom);
	}

	protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID_From);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID_To);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID_From, WebUtility.GetIntByValueDropDownList(ddlCompID), "N");
            DropDownListCommom.BindEstTermSub(ddlEstTermSubID_To, WebUtility.GetIntByValueDropDownList(ddlCompID));

            ibnSave.Attributes.Add("onclick", "return confirm('체크하신 항목에 대한 기준대상의 정보를 피참조대상으로 복사하시겠습니까?')");
        }

        COMP_ID             = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID_FROM = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID_From);
        ESTTERM_REF_ID_TO   = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID_To);
        ESTTERM_SUB_ID_FROM = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID_From);
        ESTTERM_SUB_ID_TO   = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID_To);

        ltrScript.Text  = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        if(    !ckbType_1.Checked 
            && !ckbType_2.Checked 
            && !ckbType_3.Checked 
            && !ckbType_4.Checked) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("참조하려는 체크항목을 선택하세요.");
            return;
        }

        if(    ESTTERM_REF_ID_FROM == ESTTERM_REF_ID_TO 
            && ESTTERM_SUB_ID_FROM == ESTTERM_SUB_ID_TO) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("기준대상과 피참조대상의 기간이 같습니다. 다시 설정하세요.");
            return;
        }

        Biz_Managers manager    = new Biz_Managers();
        bool isOK               = manager.CopyEstTermDataFromTo(  ckbType_1.Checked
                                                                , ckbType_2.Checked
                                                                , ckbType_3.Checked
                                                                , ckbType_4.Checked);

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 데이터가 참조되었습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("참조 중 오류가 발생하였습니다.");
        }
    }
}
