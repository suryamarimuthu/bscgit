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

using MicroBSC.BSC.Biz;

using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.WebDataInput;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;

public partial class BSC_BSC0601M2 : AppPageBase
{
    #region ==========================[변수선언]================
    public string ICCB1
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

    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "A");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int ISourceId
    {
        get
        {
            if (ViewState["SOURCE_ID"] == null)
            {
                ViewState["SOURCE_ID"] = GetRequestByInt("SOURCE_ID", 0);
            }

            return (int)ViewState["SOURCE_ID"];
        }
        set
        {
            ViewState["SOURCE_ID"] = value;
        }
    }

    #endregion

    #region 폼초기화
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        if (!IsPostBack)
        {
            this.SetInitForm();
        }
        else
        { 
        
        }
    }
    #endregion

    #region ================================= [ 내부함수 ]================================

    public void SetInitForm()
    {
        this.SetSourceType();
        this.SetProvider();
        this.SetSourceGrid();
        this.SetButton();

        if (PageUtility.GetByTextDropDownList(ddlSOURCE_TYPE) != "OLEDB")
        { 
            ddlPROVIDER.Visible    = false;
            ddlSOURCE_TYPE.Visible = true;
        }
    }

    private void SetButton()
    {
        if (this.IType == "A")
        {
            iBtnNew.Visible     = false;
            iBtnInsert.Visible  = true;
            iBtnUpdate.Visible  = false;
            iBtnDelete.Visible  = false;
            iBtnReUse.Visible   = false;
        }
        else if (this.IType == "U")
        { 
            iBtnNew.Visible     = true;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = true;
            iBtnDelete.Visible  = true;
            iBtnReUse.Visible   = false;
        }
        else if (this.IType == "D")
        { 
            iBtnNew.Visible     = false;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = true;
            iBtnDelete.Visible  = true;
            iBtnReUse.Visible   = false;
        }
        else if (this.IType == "R")
        { 
            iBtnNew.Visible     = false;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = false;
            iBtnDelete.Visible  = false;
            iBtnReUse.Visible   = true;
        }
        else if (this.IType == "P")
        {
            iBtnNew.Visible     = false;
            iBtnInsert.Visible  = false;
            iBtnUpdate.Visible  = false;
            iBtnDelete.Visible  = false;
            iBtnReUse.Visible   = false;
        }
    }

    public bool SetTrxFormData()
    {
        Biz_Bsc_Interface_Datasource objBSC = new Biz_Bsc_Interface_Datasource();
        objBSC.ISource_Id              = this.ISourceId;
        objBSC.ISource_Name            = txtSOURCE_NAME.Text;
        objBSC.ISource_Type            = PageUtility.GetByValueDropDownList(ddlSOURCE_TYPE,"");
        objBSC.ICs_Provider            = PageUtility.GetByValueDropDownList(ddlPROVIDER, "");
        objBSC.ICs_Initial_Catalog     = txtINITIAL_CATALOG.Text;
        objBSC.ICs_Data_Source         = txtDATA_SOURCE.Text;
        objBSC.ICs_User_Id             = txtUSER_ID.Text;
        objBSC.ICs_Password            = txtPASSWORD.Text;
        objBSC.ICs_Connect_Timeout     = "";
        objBSC.ICs_Extended_Properties = txtEXTENDED_PROPERTIES.Text;
        objBSC.IDescriptions           = txtDESCRIPTIONS.Text;

        int iRtn = 0;
        if (this.IType == "A")
        {
            iRtn = objBSC.InsertData
                   (null, null
                   , objBSC.ISource_Name
                   , objBSC.ISource_Type
                   , objBSC.ICs_Initial_Catalog
                   , objBSC.ICs_Data_Source
                   , objBSC.ICs_Provider
                   , objBSC.ICs_User_Id
                   , objBSC.ICs_Password
                   , objBSC.ICs_Connect_Timeout
                   , objBSC.ICs_Extended_Properties
                   , objBSC.IDescriptions
                   , "Y"
                   , gUserInfo.Emp_Ref_ID);
            this.ISourceId = objBSC.ISource_Id;
            ltrScript.Text = objBSC.Transaction_Message;
            return (objBSC.Transaction_Result == "Y") ? true : false;
        }
        else if (this.IType == "U")
        {
            iRtn = objBSC.UpdateData
                   (null, null
                   , objBSC.ISource_Id
                   , objBSC.ISource_Name
                   , objBSC.ISource_Type
                   , objBSC.ICs_Initial_Catalog
                   , objBSC.ICs_Data_Source
                   , objBSC.ICs_Provider
                   , objBSC.ICs_User_Id
                   , objBSC.ICs_Password
                   , objBSC.ICs_Connect_Timeout
                   , objBSC.ICs_Extended_Properties
                   , objBSC.IDescriptions
                   , "Y"
                   , gUserInfo.Emp_Ref_ID);
            ltrScript.Text = objBSC.Transaction_Message;
            return (objBSC.Transaction_Result == "Y") ? true : false;
        }
        else if (this.IType == "D")
        { 
            iRtn = objBSC.DeleteData
                   (null, null
                   ,objBSC.ISource_Id
                   ,gUserInfo.Emp_Ref_ID);
            ltrScript.Text = objBSC.Transaction_Message;
            return (objBSC.Transaction_Result == "Y") ? true : false;
        }

        this.SetButton();

        return false;
    }

    public void SetFormData()
    {
        Biz_Bsc_Interface_Datasource objBSC = new Biz_Bsc_Interface_Datasource(this.ISourceId);

        this.ISourceId              = objBSC.ISource_Id;
        txtSOURCE_NAME.Text         = objBSC.ISource_Name;
        PageUtility.FindByValueDropDownList(ddlSOURCE_TYPE, objBSC.ISource_Type);
        PageUtility.FindByValueDropDownList(ddlPROVIDER, objBSC.ICs_Provider);
        txtINITIAL_CATALOG.Text     = objBSC.ICs_Initial_Catalog;
        txtDATA_SOURCE.Text         = objBSC.ICs_Data_Source;
        txtUSER_ID.Text             = objBSC.ICs_User_Id;
        txtPASSWORD.Text            = objBSC.ICs_Password;
        txtEXTENDED_PROPERTIES.Text = objBSC.ICs_Extended_Properties;
        txtDESCRIPTIONS.Text        = objBSC.IDescriptions;
        txtConnectionResult.Text    = "";

        if (PageUtility.GetByTextDropDownList(ddlSOURCE_TYPE) == "OLEDB")
        {
            ddlPROVIDER.Visible    = true;
            ddlSOURCE_TYPE.Visible = true;
        }
        else
        {
            ddlPROVIDER.Visible    = false;
            ddlSOURCE_TYPE.Visible = true;
        }
    }

    public void SetClearFormData()
    { 
        this.IType                  = "A";
        this.ISourceId              = 0;
        txtSOURCE_NAME.Text         = "";
        txtINITIAL_CATALOG.Text     = "";
        txtDATA_SOURCE.Text         = "";
        txtUSER_ID.Text             = "";
        txtPASSWORD.Text            = "";
        txtEXTENDED_PROPERTIES.Text = "";
        txtDESCRIPTIONS.Text        = "";
        txtConnectionResult.Text    = "";
    }

    public void SetSourceGrid()
    {
        Biz_Bsc_Interface_Datasource objBSC = new Biz_Bsc_Interface_Datasource();
        DataSet rDs = objBSC.GetAllList();

        ugrdSourceData.Clear();
        ugrdSourceData.DataSource = rDs;
        ugrdSourceData.DataBind();
    }

    public void SetSourceType()
    {
        ddlSOURCE_TYPE.Items.Clear();
        ddlSOURCE_TYPE.Items.Add(new ListItem("MSSQL Client", "System.Data.SqlClient"));
        ddlSOURCE_TYPE.Items.Add(new ListItem("ORACLE Client", "System.Data.OracleClient"));
        ddlSOURCE_TYPE.Items.Add(new ListItem("OLEDB", "System.Data.OleDb"));
    }

    public void SetProvider()
    {
        ddlPROVIDER.Items.Clear();
        ddlPROVIDER.Items.Add(new ListItem("Oracle Provider", "MSDAORA.1"));
        ddlPROVIDER.Items.Add(new ListItem("MSSQL Provider", "SQLOLEDB.1"));
        ddlPROVIDER.Items.Add(new ListItem("ODBC Provider", "MSDASQL.1"));
    }
    #endregion
    
    #region ================================= [ 서버이벤트 ]================================
    protected void iBtnNew_Click(object sender, ImageClickEventArgs e)
    {
        this.SetClearFormData();
        this.SetButton();
    }

    protected void iBtnInsert_Click(object sender, ImageClickEventArgs e)
    {
        bool bRtn = this.SetTrxFormData();
        this.IType = (bRtn) ? "U" : "D";
        this.SetSourceGrid();
        this.SetFormData();
        this.SetButton();
    }

    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        bool bRtn = this.SetTrxFormData();
    }

    protected void iBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        this.IType = "D";
        bool bRtn = this.SetTrxFormData();
        if (bRtn)
        {
            this.SetSourceGrid();
            this.SetFormData();
            this.SetButton();
            this.IType = "X";
        }
        else
        {
            this.IType = "U";
        }
    }

    protected void iBtnReUse_Click(object sender, ImageClickEventArgs e)
    {
        bool bRtn = this.SetTrxFormData();
    }

    protected void iBtnConnect_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Bsc_Interface_Datasource objBSC = new Biz_Bsc_Interface_Datasource();
        bool isSucc = false;
        string sMsg = "";
        Object objCon = objBSC.GetConnection(this.ISourceId, out isSucc, out sMsg);
        string conStr = "";

        if (objCon.GetType() == typeof(SqlConnection))
        {
            SqlConnection conn = null;
            conn = (SqlConnection)objCon;
            conStr = conn.ConnectionString;
        }
        else if (objCon.GetType() == typeof(OracleConnection))
        {
            OracleConnection conn = null;
            conn = (OracleConnection)objCon;
            conStr = conn.ConnectionString;
        }
        else if (objCon.GetType() == typeof(OleDbConnection))
        {
            OleDbConnection conn = null;
            conn = (OleDbConnection)objCon;
            conStr = conn.ConnectionString;
        }

        System.Text.StringBuilder result = new System.Text.StringBuilder();
        result.AppendLine("MSG : ");
        result.AppendLine(sMsg);
        result.AppendLine("");
        result.AppendLine("CONNECTION STRING : ");
        result.AppendLine(conStr);
        

        txtConnectionResult.ForeColor = (isSucc) ? Color.Blue : Color.Red;
        txtConnectionResult.Text = result.ToString();
    }

    protected void ugrdSourceData_Click(object sender, ClickEventArgs e)
    {
        if (e.Row != null)
        {
            this.ISourceId = (e.Row.Cells.FromKey("SOURCE_ID").Value != null) ? int.Parse(e.Row.Cells.FromKey("SOURCE_ID").Value.ToString()) : 0;
            if (this.ISourceId > 0)
            {
                this.IType = "U";
            }
            this.SetFormData();
            this.SetButton();
        }
    }

    protected void ddlSOURCE_TYPE_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PageUtility.GetByTextDropDownList(ddlSOURCE_TYPE) == "OLEDB")
        {
            ddlPROVIDER.Visible    = true;
            ddlSOURCE_TYPE.Visible = true;
        }
        else
        {
            ddlPROVIDER.Visible    = false;
            ddlSOURCE_TYPE.Visible = true;
        }
    }

    protected void ugrdSourceData_InitializeRow(object sender, RowEventArgs e)
    {
        int iRSourceId = (e.Row.Cells.FromKey("SOURCE_ID").Value != null) ? int.Parse(e.Row.Cells.FromKey("SOURCE_ID").Value.ToString()) : 0;
        if (this.ISourceId == iRSourceId)
        {
            e.Row.Selected = true;
        }
        else
        {
            e.Row.Selected = false;
        }
    }
    #endregion
}
