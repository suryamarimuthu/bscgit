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
using System.Xml;

public partial class Resources_BiasManager : EstPageBase
{
    #region =========================[Fields]=========================
    private string sXml = string.Empty;

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

    private string INAME
    {
        get
        {
            if (ViewState["NAME"] == null)
                ViewState["NAME"] = "";
            return (string)ViewState["NAME"];
        }
        set
        {
            ViewState["NAME"] = value;
        }
    }
    #endregion

    #region =========================[Page_Load]=========================
    protected void Page_Load(object sender, EventArgs e)
    {

        sXml = Server.MapPath(".") + "\\Bias.xml";
        if (!IsPostBack)
        {
            this.INAME = GetRequest("NAME", "");
            ddlBiasID.Items.Insert(0, new ListItem("평균조정산식", "BIAS_AVG_METHOD"));
            ddlBiasID.Items.Insert(1, new ListItem("평균표준편차조정산식", "BIAS_STD_METHOD"));
            WebUtility.FindByValueDropDownList(ddlBiasID, this.INAME);
            BindingScaleInfo(COMP_ID, "");
            ButtonStatusByInit();
        }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    #endregion

    #region =========================[내부함수]=========================
    #region ===============[데이터처리]===============
    private void BindingScaleInfo(int comp_id, string scale_id)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(sXml);
        ugrdResources.DataSource = ds;
        ugrdResources.DataBind();

        foreach (UltraGridRow dr in ugrdResources.Rows)
        {
            if (dr.Cells[0].Value.ToString() != this.INAME)
                dr.Hidden = true;
        }
    }
    #endregion

    #region ===============[컨트롤설정]===============
    private void ButtonStatusByInit()
    {
        ibnNew.Enabled = false;
        ibnSave.Enabled = false;
        ibnDelete.Enabled = false;

        ibnNew.Visible = false;
        ibnDelete.Visible = false;
        txtKey.Enabled = false;

        ClearValueControls();

        //ibnSave.ImageUrl = "../images/btn/b_tp07.gif";//"저장";
        ibnSave.ImageUrl = "../images/btn/b_002.gif";//"수정";

        PageWriteMode = WriteMode.None;
    }

    private void ButtonStatusByNew()
    {
        ibnNew.Enabled = false;
        ibnSave.Enabled = false;
        ibnDelete.Enabled = false;

        ibnNew.Visible = false;
        ibnDelete.Visible = false;
        txtKey.Enabled = false;

        ClearValueControls();

        //ibnSave.ImageUrl = "../images/btn/b_tp07.gif";//"저장";
        ibnSave.ImageUrl = "../images/btn/b_002.gif";//"수정";


        PageWriteMode = WriteMode.New;
    }

    private void ButtonStatusByModify()
    {
        ibnNew.Enabled = false;
        ibnSave.Enabled = true;
        ibnDelete.Enabled = false;

        ibnNew.Visible = false;
        ibnDelete.Visible = false;
        txtKey.Enabled = false;

        ibnSave.ImageUrl = "../images/btn/b_002.gif";//"수정";

        PageWriteMode = WriteMode.Modify;
    }
    private void ClearValueControls()
    {
        this.txtResources.Text = "";
        this.txtKey.Text = "";
    }
    #endregion

    protected string GetResources(string sKey)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(sXml);
        XmlNode xNode = null;
        xNode = doc.SelectSingleNode(@"/root/data[@name='" + this.INAME + "']");
        return xNode.SelectSingleNode("value").InnerXml;
    }
    #endregion

    #region =========================[서버이벤트]=========================
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //BindingScaleInfo(COMP_ID, "");
        //ButtonStatusByInit();
    }

    protected void ibnNew_Click(object sender, ImageClickEventArgs e)
    {
        //ButtonStatusByNew();
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(sXml);

        //XmlNodeList nodeList = xmldoc.SelectNodes("root/data");

        XmlNode xNode = xmldoc.SelectSingleNode(@"/root/data[@name='" + this.txtKey.Text + "']");
        string oldTerm = xNode.SelectSingleNode("value").InnerText;
        xNode.SelectSingleNode("value").InnerText = this.txtResources.Text;
        
        XmlNode hNode = xNode.SelectSingleNode("history");
        if (hNode != null)
        {
            XmlNode vNode = xmldoc.CreateElement("value");
            vNode.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " : " + oldTerm;
            hNode.AppendChild(vNode);
        }
        else
        {
            hNode = xmldoc.CreateElement("history");
            XmlNode vNode = xmldoc.CreateElement("value");
            vNode.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " : " + oldTerm;
            hNode.AppendChild(vNode);
            xNode.AppendChild(hNode);
        }
        
        xmldoc.Save(sXml);
        BindingScaleInfo(COMP_ID, "");

        hdfChangeYN.Value = "1";
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count > 0)
        {
            this.txtKey.Text = e.SelectedRows[0].Cells.FromKey("KEY").Value.ToString();
            this.txtResources.Text = e.SelectedRows[0].Cells.FromKey("VALUE").Value.ToString();
            ButtonStatusByModify();
        }
    }

    protected void ibnDelete_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ddlBiasID_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.INAME = WebUtility.GetByValueDropDownList(ddlBiasID);
        BindingScaleInfo(COMP_ID, "");
        ClearValueControls();
    }
    #endregion


}
