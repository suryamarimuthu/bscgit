using System;
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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;

public partial class EST_EST060602 : EstPageBase
{
    private string EMP_REF_IDS;
    private string TYPE;

    protected void Page_Load(object sender, EventArgs e)
    {
        EMP_REF_IDS = WebUtility.GetRequest("EMP_REF_IDS");
        TYPE        = WebUtility.GetRequest("TYPE");

        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID, WebUtility.GetIntByValueDropDownList(ddlCompID), "N");

            ibnSave.Attributes.Add("onclick", "return confirm('반영하시겠습니까?')");

            if(TYPE.Equals("POS")) 
            {
                ibnSave.ImageUrl = "~/images/btn/b_202.gif";
            }
            else if(TYPE.Equals("DPT")) 
            {
                ibnSave.ImageUrl = "~/images/btn/b_204.gif";
            }
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        ltrScript.Text  = "";
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Datas data  = new Biz_Datas();
        bool isOK       = data.ChangePosData( COMP_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , EMP_REF_IDS
                                            , TYPE);

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 반영되었습니다.", true);
    }
}
