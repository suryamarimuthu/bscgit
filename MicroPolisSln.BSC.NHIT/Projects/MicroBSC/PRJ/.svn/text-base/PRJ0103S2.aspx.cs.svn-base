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
using MicroBSC.PRJ.Biz;

using Infragistics.WebUI.UltraWebGrid;

public partial class PRJ_PRJ0103S2 : PrjPageBase
{
    int intEstTermID = 0;

    public int IPrjRefID
    {
        get
        {
            if (ViewState["PRJ_REF_ID"] == null)
            {
                ViewState["PRJ_REF_ID"] = GetRequestByInt("PRJ_REF_ID", 0);
            }

            return (int)ViewState["PRJ_REF_ID"];
        }
        set
        {
            ViewState["PRJ_REF_ID"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", "");
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        SetAllTimeTop();
        intEstTermID = GetRequestByInt("ESTTERM_REF_ID", 0);
        hdfType.Value = GetRequest("TYPE");

        if (!IsPostBack)
        {
            InitControlValue();
            InitControlEvent();
            SetPageData();
        }
        else
        {
            SetPostBack();
        }

        SetAllTimeBottom();
    }

    #region 페이지 초기화 함수

    private void SetAllTimeTop()
    {

    }

    private void InitControlValue()
    {
        this.IPrjRefID = GetRequestByInt("PRJ_REF_ID");

        hdfObjKey.Value = GetRequest("OBJ_KEY", "");
        hdfObjVal.Value = GetRequest("OBJ_VAL", "");

        hdfValue1.Value = GetRequest("STR_VAR1", "");
        hdfValue2.Value = GetRequest("STR_VAR2", "");
        hdfValue3.Value = GetRequest("STR_VAR3", "");
        hdfValue4.Value = GetRequest("STR_VAR4", "");
        hdfValue5.Value = GetRequest("STR_VAR5", "");

    }

    private void InitControlEvent()
    {

    }

    private void SetPageData()
    {
        Biz_Prj_Resource objResource = new Biz_Prj_Resource();
        UltraWebGrid1.DataSource = objResource.GetAllList(this.IPrjRefID, 0);
        UltraWebGrid1.DataBind();
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }
    #endregion

    #region 내부함수

   
    #endregion

    #region 서버 이벤트 처리 함수

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        e.Row.Cells.FromKey("SELECT").Value = "<img src='../images/drafts.gif' border='0'>";
    }

    #endregion
    protected void UltraWebGrid1_DblClick(object sender, ClickEventArgs e)
    {
        if (hdfType.Value.Equals("P"))
        {
            Response.Write("<script type='text/javascript'>\r\n");


            if (! hdfObjKey.Value.Equals(""))
                Response.Write("opener.document.getElementById('" + hdfObjKey.Value + "').value='" + e.Row.Cells.FromKey("EMP_REF_ID").Value + "';\r\n");

            if (! hdfObjVal.Value.Equals(""))
            {
                Response.Write("opener.document.getElementById('" + hdfObjVal.Value + "').value='" + e.Row.Cells.FromKey("EMP_NAME").Value + "';\r\n");
                //Response.Write("opener.document.getElementById('" + hdfObjVal.Value + "').focus();\r\n");
            }

            Response.Write("self.close();\r\n");

            Response.Write("</script>\r\n");
        }
        else if (hdfType.Value.Equals("G"))
        {
            Response.Write("<script type='text/javascript'>\r\n");


            Response.Write("opener.document.getElementById('" + hdfValue1.Value + "').value='" + e.Row.Cells.FromKey("EMP_REF_ID").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue2.Value + "').value='" + e.Row.Cells.FromKey("EMP_NAME").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue3.Value + "').value='" + e.Row.Cells.FromKey("DAILY_PHONE").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue4.Value + "').value='" + e.Row.Cells.FromKey("CELL_PHONE").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue5.Value + "').value='" + e.Row.Cells.FromKey("EMP_EMail").Value + "';\r\n");
            //Response.Write("self.close();\r\n");
            Response.Write("</script>\r\n");

            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB2, true);
        }
        else if (hdfType.Value.Equals("O"))
        {
            Response.Write("<script type='text/javascript'>\r\n");


            Response.Write("opener.document.getElementById('" + hdfValue1.Value + "').value='" + e.Row.Cells.FromKey("EMP_REF_ID").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue2.Value + "').value='" + e.Row.Cells.FromKey("EMP_NAME").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue3.Value + "').value='" + e.Row.Cells.FromKey("DEPT_CODE").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue4.Value + "').value='" + e.Row.Cells.FromKey("DEPT_NAME").Value + "';\r\n");
            //Response.Write("opener.document.getElementById('" + hdfValue5.Value + "').value='" + e.Row.Cells.FromKey("EMP_EMail").Value + "';\r\n");
            //Response.Write("self.close();\r\n");
            Response.Write("</script>\r\n");

            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB2, true);
        }
        else if (hdfType.Value.Equals("S"))
        {
            Response.Write("<script type='text/javascript'>\r\n");


            Response.Write("opener.document.getElementById('" + hdfValue1.Value + "').value='" + e.Row.Cells.FromKey("EMP_REF_ID").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue2.Value + "').value='" + e.Row.Cells.FromKey("EMP_NAME").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue3.Value + "').value='" + e.Row.Cells.FromKey("DEPT_CODE").Value + "';\r\n");
            Response.Write("opener.document.getElementById('" + hdfValue4.Value + "').value='" + e.Row.Cells.FromKey("DEPT_NAME").Value + "';\r\n");
            //Response.Write("opener.document.getElementById('" + hdfValue5.Value + "').value='" + e.Row.Cells.FromKey("EMP_EMail").Value + "';\r\n");
            //Response.Write("self.close();\r\n");
            Response.Write("</script>\r\n");

            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB2, true);
        }
        

        
    }
}
