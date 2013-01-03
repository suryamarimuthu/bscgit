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

using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.PRJ.Biz;

public partial class PRJ_PRJ0102M1 : PrjPageBase
{
    #region ==========================[변수선언]================

    public string READ_ONLY_YN
    {
        get
        {
            if (ViewState["READ_ONLY_YN"] == null)
            {
                ViewState["READ_ONLY_YN"] = GetRequest("READ_ONLY_YN", "N");
            }

            return (string)ViewState["READ_ONLY_YN"];
        }
        set
        {
            ViewState["READ_ONLY_YN"] = value;
        }
    }

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

    public string ICCB4
    {
        get
        {
            if (ViewState["CCB4"] == null)
            {
                ViewState["CCB4"] = GetRequest("CCB4", this.lBtnTaskShareAddRow.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB4"];
        }
        set
        {
            ViewState["CCB4"] = value;
        }
    }

    public string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", this.lBtnTaskOwnerAddRow.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB3"];
        }
        set
        {
            ViewState["CCB3"] = value;
        }
    }

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

  
    public int ITaskRefID
    {
        get
        {
            if (ViewState["TASK_REF_ID"] == null)
            {
                ViewState["TASK_REF_ID"] = GetRequestByInt("TASK_REF_ID", 0);
            }

            return (int)ViewState["TASK_REF_ID"];
        }
        set
        {
            ViewState["TASK_REF_ID"] = value;
        }
    }

    public decimal ITaskWeight
    {
        get
        {
            if (ViewState["TASK_WEIGHT"] == null)
            {
                ViewState["TASK_WEIGHT"] = decimal.Parse(GetRequest("TASK_WEIGHT", "0"));
            }

            return (decimal)ViewState["TASK_WEIGHT"];
        }
        set
        {
            ViewState["TASK_WEIGHT"] = value;
        }
    }
   

    #endregion

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetFormInit();
            FormDataBind();
            SetReadOnlyYN();
        }
        else
        {

        }

        ltrScript.Text = "";
    }

    private void SetReadOnlyYN()
    {
        if (READ_ONLY_YN.Equals("N"))
        {
            this.iBtnUpdate.Visible = true;
        }
        else
        {
            this.iBtnUpdate.Visible = false;
        }
    }

    public void SetFormInit()
    {
        TextBoxCommon.SetOnlyInteger(txtProceedRate);
        Biz_Com_Code_Info objCode = new Biz_Com_Code_Info();
        objCode.GetTaskType(ddlTaskType, 0, false, 100);

        wdcSchPlanStartDate.Attributes.Add("onkeypress", "return processKeyPress();");
        wdcSchPlanEndDate.Attributes.Add("onkeypress", "return processKeyPress();");
        wdcSchActualStartDate.Attributes.Add("onkeypress", "return processKeyPress();");
        wdcSchActualEndDate.Attributes.Add("onkeypress", "return processKeyPress();");

        txtProceedRate.Attributes.Add("onkeypress", "return processKeyPress();");
        txtProceedRate.Attributes.Add("onBlur", "return CheckValue();");

    }
    private void FormDataBind()
    {
        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule(this.IPrjRefID, this.ITaskRefID);
        Biz_Prj_Info objInfo = new Biz_Prj_Info(this.IPrjRefID);
        Biz_Prj_Schedule objUpSchedule = new Biz_Prj_Schedule(this.IPrjRefID,objSchedule.IUp_Task_Ref_Id);
        Biz_Prj_Task_Owner objTaskOwner = new Biz_Prj_Task_Owner();
        Biz_Prj_Task_Share objTaskShare = new Biz_Prj_Task_Share();

        txtPrjName.Text = objInfo.IPrj_Name;
        txtPrjPeriod.Text = DataTypeUtility.GetToDateTimeText(objInfo.IPlan_Start_Date) + " ~ " + DataTypeUtility.GetToDateTimeText(objInfo.IPlan_End_Date);

        txtTaskCode.Text            = objSchedule.ITask_Code;
        txtTaskName.Text            = objSchedule.ITask_Name;
        txtUpTaskName.Text          = objUpSchedule.ITask_Name;
        hdfUpTaskRefID.Value        = objSchedule.IUp_Task_Ref_Id.ToString();
        this.ITaskWeight            = objSchedule.ITask_Weight;
        wdcSchPlanStartDate.Value   = objSchedule.IPlan_Start_Date;
        wdcSchPlanEndDate.Value     = objSchedule.IPlan_End_Date;
        wdcSchActualStartDate.Value = objSchedule.IActual_Start_Date;
        wdcSchActualEndDate.Value   = objSchedule.IActual_End_Date;


        txtProceedRate.Text         = objSchedule.IProceed_Rate.ToString("##0.#0");
        hdfAttachNo.Value           = objSchedule.IAtt_File;
        hdfNodeDepth.Value          = objSchedule.INode_Depth.ToString();
        txtDesction.Text            = objSchedule.IDesction;

        SetUploadFileInfo(hdfAttachNo.Value, ddlFileUpload);

        ugrdTaskOwnerList.Clear();
        //ugrdTaskShareList.Clear();

        ugrdTaskOwnerList.DataSource = objTaskOwner.GetAllList(this.IPrjRefID, 0, this.ITaskRefID);
        ugrdTaskOwnerList.DataBind();

        //ugrdTaskShareList.DataSource = objTaskShare.GetAllList(this.IPrjRefID, this.ITaskRefID, 0);
        //ugrdTaskShareList.DataBind();

    }

    private void SetUploadFileInfo(string asAttachNo, DropDownList ddlFileUpload)
    {
        DataSet lDS = new DataSet();

        ddlFileUpload.Items.Clear();

        Biz_Base_FileUpload bizUpload = new Biz_Base_FileUpload();
        lDS = bizUpload.GetFileUploaded(asAttachNo);

        for (int i = 0; i < lDS.Tables[0].Rows.Count; i++)
        {
            ddlFileUpload.Items.Add(new ListItem(lDS.Tables[0].Rows[i]["v_FileText"].ToString(), lDS.Tables[0].Rows[i]["v_FileValue"].ToString()));
        }

        ddlFileUpload.Items.Insert(0, new ListItem("파일선택", ""));

        if (ddlFileUpload.Items.Count > 1)
        {
            ddlFileUpload.Items[1].Selected = true;
        }
    }


    protected void ibtnTaskShareDelRow_Click(object sender, ImageClickEventArgs e)
    {
        //string striType = "";
        //int cntRow = ugrdTaskShareList.Rows.Count;

        //CheckBox chkCheck;
        //UltraGridRow ugrdRow;
        //TemplatedColumn col_Check = (TemplatedColumn)ugrdTaskShareList.Bands[0].Columns.FromKey("selchk");

        //for (int i = 0; i < ugrdTaskShareList.Rows.Count; i++)
        //{
        //    chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdTaskShareList.Rows[i].BandIndex]).FindControl("cBox");
        //    ugrdRow = ugrdTaskShareList.Rows[i];
        //    if (chkCheck.Checked)
        //    {
        //        striType = ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").ToString();

        //        if (striType == "U")
        //        {
        //            ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
        //            ugrdTaskShareList.Rows[i].Hidden = true;
        //            chkCheck.Checked = false;
        //        }
        //        else if (striType == "A")
        //        {
        //            ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").Value = "X";
        //            ugrdTaskShareList.Rows[i].Hidden = true;
        //        }
               
        //    }
        //}
    }
    protected void ibtnTaskOwnerDelRow_Click(object sender, ImageClickEventArgs e)
    {
        string striType = "";
        int cntRow = ugrdTaskOwnerList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdTaskOwnerList.Bands[0].Columns.FromKey("selchk");

        for (int i = 0; i < ugrdTaskOwnerList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdTaskOwnerList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdTaskOwnerList.Rows[i];
            if (chkCheck.Checked)
            {
                striType = ugrdTaskOwnerList.Rows[i].Cells.FromKey("ITYPE").ToString();

                if (striType == "U")
                {
                    ugrdTaskOwnerList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
                    ugrdTaskOwnerList.Rows[i].Hidden = true;
                    chkCheck.Checked = false;
                }
                else if (striType == "A")
                {
                    ugrdTaskOwnerList.Rows[i].Cells.FromKey("ITYPE").Value = "X";
                    ugrdTaskOwnerList.Rows[i].Hidden = true;
                }
            }
        }
    }

    protected void lBtnTaskOwnerAddRow_Click(object sender, EventArgs e)
    {
        bool isCheck = false;

        //중복체크
        foreach (UltraGridRow row in ugrdTaskOwnerList.Rows)
        {
            if (row.Cells.FromKey("EMP_REF_ID").Value.ToString() == hdfValue1.Value.ToString())
            {
                isCheck = true;
                break;
            }
        }

        if (isCheck)
            return;

        int cntRow = 0;
        ugrdTaskOwnerList.Rows.Add();
        cntRow = ugrdTaskOwnerList.Rows.Count == 0 ? 0 : (ugrdTaskOwnerList.Rows.Count - 1);

        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("EMP_REF_ID").Value = hdfValue1.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("EMP_NAME").Value = hdfValue2.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("DEPT_CODE").Value = hdfValue3.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("DEPT_NAME").Value = hdfValue4.Value;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("PRJ_REF_ID").Value = this.IPrjRefID;
        ugrdTaskOwnerList.Rows[cntRow].Cells.FromKey("TASK_REF_ID").Value = this.ITaskRefID;
    }
    protected void lBtnTaskShareAddRow_Click(object sender, EventArgs e)
    {
        //bool isCheck = false;

        ////중복체크
        //foreach (UltraGridRow row in ugrdTaskShareList.Rows)
        //{
        //    if (row.Cells.FromKey("EMP_REF_ID").Value.ToString() == hdfValue1.Value.ToString())
        //    {
        //        isCheck = true;
        //        break;
        //    }
        //}

        //if (isCheck)
        //    return;

        //int cntRow = 0;
        //ugrdTaskShareList.Rows.Add();
        //cntRow = ugrdTaskShareList.Rows.Count == 0 ? 0 : (ugrdTaskShareList.Rows.Count - 1);

        //ugrdTaskShareList.Rows[cntRow].Cells.FromKey("ITYPE").Value = "A";
        //ugrdTaskShareList.Rows[cntRow].Cells.FromKey("EMP_REF_ID").Value = hdfValue1.Value;
        //ugrdTaskShareList.Rows[cntRow].Cells.FromKey("EMP_NAME").Value = hdfValue2.Value;
        //ugrdTaskShareList.Rows[cntRow].Cells.FromKey("DEPT_CODE").Value = hdfValue3.Value;
        //ugrdTaskShareList.Rows[cntRow].Cells.FromKey("DEPT_NAME").Value = hdfValue4.Value;
        //ugrdTaskShareList.Rows[cntRow].Cells.FromKey("PRJ_REF_ID").Value = this.IPrjRefID;
        //ugrdTaskShareList.Rows[cntRow].Cells.FromKey("TASK_REF_ID").Value = this.ITaskRefID;
    }


    protected void ugrdTaskShareList_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        //string striType = "";
        //int cntRow = ugrdTaskShareList.Rows.Count;

        //CheckBox chkCheck;
        //UltraGridRow ugrdRow;
        //TemplatedColumn col_Check = (TemplatedColumn)ugrdTaskShareList.Bands[0].Columns.FromKey("selchk");

        //for (int i = 0; i < ugrdTaskShareList.Rows.Count; i++)
        //{
        //    chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdTaskShareList.Rows[i].BandIndex]).FindControl("cBox");
        //    ugrdRow = ugrdTaskShareList.Rows[i];
        //    if (chkCheck.Checked)
        //    {
        //        striType = ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").ToString();
        //        if (striType == "U")
        //        {
        //            chkCheck.BackColor = Color.Red;
        //            ugrdTaskShareList.Rows[i].Cells.FromKey("ITYPE").Value = "D";
        //        }
        //        else if (striType == "A")
        //        {
        //            ugrdTaskShareList.Rows.Remove(ugrdRow);
        //        }
        //    }
        //}
    }
    protected void iBtnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        Biz_Prj_Task_Owner objTaskOwner = new Biz_Prj_Task_Owner();
        Biz_Prj_Task_Share objTaskShare = new Biz_Prj_Task_Share();

        string[,] saAttachInfo = TypeUtility.GetSplit(hdfAttachNo.Value);

        string strAttach = hdfAttachNo.Value;
        if (saAttachInfo.Length / 2 >= 1)
        {
            if (Convert.ToInt32(saAttachInfo[1, 0]) > 0)
            {
                strAttach = saAttachInfo[0, 0];
            }
        }

        objSchedule.IPrj_Ref_Id = this.IPrjRefID;
        objSchedule.ITask_Ref_Id = this.ITaskRefID;
        objSchedule.ITask_Code = txtTaskCode.Text.Trim();
        objSchedule.ITask_Name = txtTaskName.Text.Trim();
        objSchedule.IUp_Task_Ref_Id = DataTypeUtility.GetToInt32(hdfUpTaskRefID.Value);
        objSchedule.ITask_Type = WebUtility.GetByValueDropDownList(ddlTaskType);
        objSchedule.IPlan_Start_Date = wdcSchPlanStartDate.Value;
        objSchedule.IPlan_End_Date = wdcSchPlanEndDate.Value;
        objSchedule.IActual_Start_Date = wdcSchActualStartDate.Value;
        objSchedule.IActual_End_Date = wdcSchActualEndDate.Value;
        objSchedule.IProceed_Rate = DataTypeUtility.GetToDecimal(txtProceedRate.Text.Trim());
        objSchedule.IAtt_File = strAttach;
        objSchedule.INode_Depth = DataTypeUtility.GetToInt32(hdfNodeDepth.Value);
        objSchedule.IComplete_Yn = "N";
        objSchedule.IIsdelete = "N";
        objSchedule.IAfter_Task_Ref_Id = -1;
        objSchedule.IDesction = this.txtDesction.Text.Trim();



       int intRtn = objSchedule.UpdateData(objSchedule.IPrj_Ref_Id
                                , objSchedule.ITask_Ref_Id
                                , objSchedule.ITask_Name
                                , objSchedule.ITask_Type
                                , this.ITaskWeight
                                , objSchedule.IUp_Task_Ref_Id
                                , objSchedule.ITask_Code
                                , objSchedule.IPlan_Start_Date
                                , objSchedule.IPlan_End_Date
                                , objSchedule.IActual_Start_Date
                                , objSchedule.IActual_End_Date
                                , objSchedule.IProceed_Rate
                                , objSchedule.IAtt_File
                                , objSchedule.IComplete_Yn
                                , objSchedule.IIsdelete
                                , objSchedule.INode_Depth
                                , objSchedule.IAfter_Task_Ref_Id
                                , objSchedule.IDesction
                                , gUserInfo.Emp_Ref_ID);
     

        //작업수행담당자 저장

        foreach (UltraGridRow row in ugrdTaskOwnerList.Rows)
        {
            objTaskOwner.IPrj_Ref_Id = this.IPrjRefID;
            objTaskOwner.ITask_Ref_Id = this.ITaskRefID;
            objTaskOwner.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);

            if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
            {
                intRtn += objTaskOwner.InsertData(objTaskOwner.IPrj_Ref_Id
                      , objTaskOwner.IEmp_Ref_Id
                      , objTaskOwner.ITask_Ref_Id
                      , "N"
                      , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
            {
                intRtn += objTaskOwner.UpdateData(objTaskOwner.IPrj_Ref_Id
                                   , objTaskOwner.IEmp_Ref_Id
                                   , objTaskOwner.ITask_Ref_Id
                                   , "N"
                                   , gUserInfo.Emp_Ref_ID);
            }
            else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
            {
                intRtn += objTaskOwner.DeleteData(objTaskOwner.IPrj_Ref_Id
                    , objTaskOwner.IEmp_Ref_Id
                    , objTaskOwner.ITask_Ref_Id
                    , gUserInfo.Emp_Ref_ID);
            }
        }

        ////일정공유자 저장

        //foreach (UltraGridRow row in ugrdTaskShareList.Rows)
        //{
        //    objTaskShare.IPrj_Ref_Id = this.IPrjRefID;
        //    objTaskShare.ITask_Ref_Id = this.ITaskRefID;
        //    objTaskShare.IEmp_Ref_Id = DataTypeUtility.GetToInt32(row.Cells.FromKey("EMP_REF_ID").Value);

        //    if (row.Cells.FromKey("ITYPE").Value.ToString() == "A")
        //    {
        //        intRtn += objTaskShare.InsertData(objTaskShare.IPrj_Ref_Id
        //              , objTaskShare.ITask_Ref_Id
        //              , objTaskShare.IEmp_Ref_Id
        //              , gUserInfo.Emp_Ref_ID);
        //    }
        //    else if (row.Cells.FromKey("ITYPE").Value.ToString() == "U")
        //    {
        //        intRtn += objTaskShare.UpdateData(objTaskShare.IPrj_Ref_Id
        //                           , objTaskShare.ITask_Ref_Id
        //                           , objTaskShare.IEmp_Ref_Id
        //                           , gUserInfo.Emp_Ref_ID);
        //    }
        //    else if (row.Cells.FromKey("ITYPE").Value.ToString() == "D")
        //    {
        //        intRtn += objTaskShare.DeleteData(objTaskShare.IPrj_Ref_Id
        //            , objTaskShare.ITask_Ref_Id
        //            , objTaskShare.IEmp_Ref_Id
        //            , gUserInfo.Emp_Ref_ID);
        //    }
        //}

        ugrdTaskOwnerList.Clear();
        //ugrdTaskShareList.Clear();

        ugrdTaskOwnerList.DataSource = objTaskOwner.GetAllList(this.IPrjRefID, 0, this.ITaskRefID);
        ugrdTaskOwnerList.DataBind();

        //ugrdTaskShareList.DataSource = objTaskShare.GetAllList(this.IPrjRefID, this.ITaskRefID, 0);
        //ugrdTaskShareList.DataBind();

        if (intRtn > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("작업정보가 저장되었습니다.",true);
         
        }
    }


    protected void iBtnDownload_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlFileUpload.SelectedValue.Trim() == "")
        {
            PageUtility.AlertMessage("첨부된 파일을 선택하세요.");
            return;
        }

        string sText = ddlFileUpload.SelectedItem.Text;
        string sValue = ddlFileUpload.SelectedItem.Value;

        PageUtility.FileDownLoad(sText.Substring(0, sText.LastIndexOf(" (")), sValue);
    }
    protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(this.ICCB1, true);
    }
}
