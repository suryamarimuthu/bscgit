using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebToolbar;
using System.Xml;
using MicroBSC.Common;

using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;
using System.Drawing;
using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid;





public partial class PRJ_PRJ0105M1 : PrjPageBase
{
    private int _iPrjRefID = 0;

    

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public string ICCB2
    {
        get
        {
            if (ViewState["CCB2"] == null)
            {
                ViewState["CCB2"] = GetRequest("CCB2", this.lBtnBindRow.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    public int IPrjRefID
    {
        get { return _iPrjRefID; }
        set { _iPrjRefID = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        txtYear.ValueChange += new Infragistics.WebUI.WebDataInput.ValueChangeHandler(txtYear_ValueChange);
        if (!IsPostBack)
        {
            this.SetFormInit();
        }
       
        this.IPrjRefID = WebUtility.GetIntByValueDropDownList(ddlPrjName);

        ltrScript.Text = "";

        SetButton();
    }

    #region 내부 함수

    private void SetButton()
    {

        // 프로젝트 책임자 또는 사업구성원이 아닐경우
        Biz_Prj_Info objPrj = new Biz_Prj_Info();
        Biz_Prj_Resource objRes = new Biz_Prj_Resource(this._iPrjRefID, gUserInfo.Emp_Ref_ID);

        if (!objPrj.IsOwnerEmpIDYN(gUserInfo.Emp_Ref_ID, this.IPrjRefID)
            || (objRes == null))
        {
            this.iBtnAddRow.Visible = false;
            this.iBtnDelRow.Visible = false;
            this.iBtnUpdate.Visible = false;
        }
        else
        {
            this.iBtnAddRow.Visible = true;
            this.iBtnDelRow.Visible = true;
            this.iBtnUpdate.Visible = true;
        }
    }

    public void SetFormInit()
    {
        Biz_Com_Code_Info codeinfo = new Biz_Com_Code_Info();
        codeinfo.GetProjectType(ddlPrjType, -1, true, 120);

        ListItem itemA = new ListItem("----------", "0");
        ddlPrjName.Items.Insert(0, itemA);

        this.ibnDownExcel.Visible = false;
        txtYear.Value = DateTime.Now.Year;
    }

    private void BeforeSearch()
    {
        this.IPrjRefID = WebUtility.GetIntByValueDropDownList(ddlPrjName);

        Biz_Prj_Execution objexec = new Biz_Prj_Execution();

        DataSet ds = objexec.GetAllList(this.IPrjRefID);

        ugrdPrjList.Clear();
        this.ugrdPrjList.DataSource = ds;
        this.ugrdPrjList.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();


        if (ds.Tables[0].Rows.Count > 0)
            this.ibnDownExcel.Visible = true;
    }
  

    #endregion

    
    
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BeforeSearch();
    }
    protected void ddlPrjType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iYear = 0;
        bool isInt = int.TryParse(txtYear.Value.ToString(), out iYear);

        WebCommon.SetProjectListDropDownList(ddlPrjName, true, EMP_REF_ID, PageUtility.GetByValueDropDownList(ddlPrjType), iYear);
    }
    void txtYear_ValueChange(object sender, Infragistics.WebUI.WebDataInput.ValueChangeEventArgs e)
    {
        int iYear = 0;
        bool isInt = int.TryParse(txtYear.Value.ToString(), out iYear);

        WebCommon.SetProjectListDropDownList(ddlPrjName, true, EMP_REF_ID, PageUtility.GetByValueDropDownList(ddlPrjType), iYear);
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        BeforeSearch();
    }

   
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Prj_Execution objExecution = new Biz_Prj_Execution();

        //사업비용집행내역

        int intRtn = 0;

        foreach (UltraGridRow row in ugrdPrjList.Rows)
        {
            objExecution.IExec_Ref_Id   = DataTypeUtility.GetToInt32(row.Cells.FromKey("EXEC_REF_ID").Value);
            objExecution.IPrj_Ref_Id    = DataTypeUtility.GetToInt32(row.Cells.FromKey("PRJ_REF_ID").Value);
            objExecution.ITask_Ref_Id   = DataTypeUtility.GetToInt32(row.Cells.FromKey("TASK_REF_ID").Value);
            objExecution.IExec_Date     = row.Cells.FromKey("EXEC_DATE").Value;
            objExecution.IAmount        = DataTypeUtility.GetToDecimal(row.Cells.FromKey("AMOUNT").Value);
            objExecution.IExec_Content  = DataTypeUtility.GetValue(row.Cells.FromKey("EXEC_CONTENT").Value);
         

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objExecution.InsertData(objExecution.IPrj_Ref_Id
                      , objExecution.ITask_Ref_Id
                      , objExecution.IExec_Date
                      , objExecution.IAmount
                      , objExecution.IExec_Content
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
            {
                intRtn += objExecution.UpdateData(objExecution.IExec_Ref_Id
                                   , objExecution.IPrj_Ref_Id
                                   , objExecution.ITask_Ref_Id
                                   , objExecution.IExec_Date
                                   , objExecution.IAmount
                                   , objExecution.IExec_Content
                                   , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objExecution.DeleteData(objExecution.IExec_Ref_Id, gUserInfo.Emp_Ref_ID);
            }

        }


        if (intRtn > 0)
        {
            this.BeforeSearch();
        }
    }
    protected void iBtnAddRow_Click(object sender, ImageClickEventArgs e)
    {
        this.IPrjRefID = WebUtility.GetIntByValueDropDownList(ddlPrjName);

        if (this._iPrjRefID == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("사업명을 먼저 선택하여 주세요.");
            return;
        }


        Biz_Prj_Info objInfo = new Biz_Prj_Info(IPrjRefID);

        UltraGridRow row = new UltraGridRow(new object[] { "", "A", 0, objInfo.IPrj_Ref_Id, objInfo.IPrj_Code, objInfo.IPrj_Name, objInfo.IOwner_Emp_Id, objInfo.IOwner_Emp_Name, "", "", DateTime.Now.ToShortDateString(), "0" });
        int cntRow = 0;
        ugrdPrjList.Rows.Add(row);
        cntRow = ugrdPrjList.Rows.Count - 1;


        //ugrdPrjList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
    }
    protected void iBtnDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdPrjList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdPrjList.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < ugrdPrjList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdPrjList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdPrjList.Rows[i];
            if (chkCheck.Checked)
            {
                striType = ugrdPrjList.Rows[i].Cells.FromKey("ITYPE").ToString();
                if (striType == "U")
                {
                    ugrdPrjList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                    ugrdPrjList.Rows[i].Hidden = true;
                    chkCheck.Checked = false;
                }
                else if (striType == "A")
                {
                    ugrdPrjList.Rows[i].Cells.FromKey("ITYPE").Value = "X";
                    ugrdPrjList.Rows[i].Hidden = true;
                }
            }
        }
    }

    protected void lBtnBindRow_Click(object sender, EventArgs e)
    {
        ugrdPrjList.DisplayLayout.ActiveRow.Cells.FromKey("TASK_REF_ID").Value = this.hdfTaskRefID.Value;
        ugrdPrjList.DisplayLayout.ActiveRow.Cells.FromKey("TASK_NAME").Value = this.hdfTaskName.Value;
    }
    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName = "PRJ" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName = "PRJ_BUDGET";

        uGridExcelExporter.Export(ugrdPrjList);
    }
}
