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

public partial class EST_EST050200 : EstPageBase
{
    #region ================================ 이벤트 =============================

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DoConfig();
        }

        COMP_ID        = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        ltrScript.Text = string.Empty;

        if (PageUtility.GetAppConfig("Mail.UseMBOMailYN") != "true")
            ibtnMail.Visible = false;
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string est_id  = TreeView1.SelectedValue;
        hdfEstID.Value = est_id;

        BindEstJob(est_id);
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        int okCnt = DoSaving();
        if (okCnt > 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript(string.Format("{0}개의 데이터가 저장되었습니다", okCnt.ToString()));
        }
    }

    protected void ibtnMail_Click(object sender, ImageClickEventArgs e)
    {
        bool rtnMail = false;
        string sC_EMP_MAIL = "";
        string sN_EMP_MAIL = "";
        string sFile = "";
        string sMailTitle = "";
        EmpInfos objEmp;

        if (this.hdfEstID.Value == null)
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가유형을 선택하세요!");
            return;
        }
        if (this.hdfEstID.Value.ToString() == "")
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가유형을 선택하세요!");
            return;
        }

        string strVPath = Request.ApplicationPath;
        string strSHost = Request.Url.Host;
        string strSPort = Request.Url.Port.ToString();
        string strProto = Request.Url.Scheme;
        strVPath = (strVPath == "/") ? "" : strVPath;

        string strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath;

        DataTable dtMailParam = new DataTable("PARAM");
        dtMailParam.Columns.Add("KEY", typeof(string));
        dtMailParam.Columns.Add("VAL", typeof(string));

        DataRow dr = null;
        dr = dtMailParam.NewRow();
        dr["KEY"] = "[::MAIL_DOMAIN::]";
        dr["VAL"] = strFullPath;
        dtMailParam.Rows.Add(dr);

        switch (hdfEstID.Value.ToString())
        {
            case "3GA":
                sFile = "mailtemp_보고서작성.htm";
                sMailTitle = "[성과관리 - " + "MBO평가 종합보고서 작성요청 건 알림메일]";
                dr = dtMailParam.NewRow();
                dr["KEY"] = "[::APP_GUBUN::]";
                dr["VAL"] = "MBO";
                dtMailParam.Rows.Add(dr);

                dr = dtMailParam.NewRow();
                dr["KEY"] = "[::TO_DAY::]";
                dr["VAL"] = DateTime.Now.ToString();
                dtMailParam.Rows.Add(dr);

                break;
            default:
                ltrScript.Text = JSHelper.GetAlertScript("평가유형을 선택하세요!");
                return;
                break;
        }

        Biz_Datas bizData = new Biz_Datas();
        DataSet dsData = bizData.GetEstData(COMP_ID, hdfEstID.Value.ToString(), ESTTERM_REF_ID, ESTTERM_SUB_ID, 0, 0, 0, 0, 0);
        if (dsData.Tables[0].Rows.Count == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("메일을 발송할 평가대상자가 없습니다!");
            return;
        }
        DataTable dtDistinct = dsData.Tables[0].DefaultView.ToTable(true, "TGT_EMP_ID");

        sC_EMP_MAIL = PageUtility.GetAppConfig("Mail.From");

        int totalReceiver = dtDistinct.Rows.Count;
        int sendReceiver = 0;

        foreach (DataRow drReceiver in dtDistinct.Rows)
        {
            objEmp = new EmpInfos(DataTypeUtility.GetToInt32(drReceiver["TGT_EMP_ID"]));
            sN_EMP_MAIL = objEmp.Emp_Email;

            if (!PageUtility.CheckMailAddress(sC_EMP_MAIL) || !PageUtility.CheckMailAddress(sN_EMP_MAIL))
            {
                return;
            }

            rtnMail = PageUtility.SendMail(dtMailParam, sC_EMP_MAIL, sN_EMP_MAIL, sMailTitle, sFile);
            if (rtnMail)
                sendReceiver++;
        }

        ltrScript.Text = JSHelper.GetAlertScript("대상자 " + totalReceiver.ToString() + "명 중 " + sendReceiver.ToString() + "명에게 안내메일을 발송하였습니다.");
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeViewCommom.BindEst(TreeView1, WebUtility.GetIntByValueDropDownList(ddlCompID)); 
    }

    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeViewCommom.BindEst(TreeView1, WebUtility.GetIntByValueDropDownList(ddlCompID));
        UltraWebGrid1.Clear();
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        TreeViewCommom.BindEst(TreeView1, WebUtility.GetIntByValueDropDownList(ddlCompID));
        UltraWebGrid1.Clear();
    }


    #endregion
    

    #region ================================ 메서드 =============================

    private int DoSaving()
    {
        int okCnt     = 0;
        object[] temp = new object[10];
        temp[0]       = COMP_ID;
        temp[1]       = hdfEstID.Value;
        temp[2]       = ESTTERM_REF_ID;
        temp[3]       = ESTTERM_SUB_ID;
        

        for (int i = 0; i < UltraWebGrid1.Rows.Count; i++)
        {
            if (UltraWebGrid1.Rows[i].Cells.FromKey("UPDATE_YN").Value != null)
            {
                //temp[4] = (UltraWebGrid1.Rows[i].Cells.FromKey("STEP_ID").Value == null) ? "0" : UltraWebGrid1.Rows[i].Cells.FromKey("STEP_ID").Value.ToString();
                temp[4] = DataTypeUtility.GetToInt32(UltraWebGrid1.Rows[i].Cells.FromKey("STEP_ID").Value);
                temp[5] = (UltraWebGrid1.Rows[i].Cells.FromKey("EST_JOB_ID").Value == null) ? (object)DBNull.Value : UltraWebGrid1.Rows[i].Cells.FromKey("EST_JOB_ID").Value.ToString();
                temp[6] = (UltraWebGrid1.Rows[i].Cells.FromKey("START_DATE").Value == null) ? (object)DBNull.Value : UltraWebGrid1.Rows[i].Cells.FromKey("START_DATE").Value.ToString();
                temp[7] = (UltraWebGrid1.Rows[i].Cells.FromKey("END_DATE").Value == null) ? (object)DBNull.Value : UltraWebGrid1.Rows[i].Cells.FromKey("END_DATE").Value.ToString();
                temp[8] = (UltraWebGrid1.Rows[i].Cells.FromKey("STATUS_YN").Value == null) ? "N" : UltraWebGrid1.Rows[i].Cells.FromKey("STATUS_YN").Value.ToString();
                temp[9] = EMP_REF_ID;




                temp[6] = Convert.ToDateTime(temp[6]).ToString("yyyy-MM-dd");
                temp[7] = Convert.ToDateTime(temp[7]).ToString("yyyy-MM-dd");




                Biz_JobDetails biz = new Biz_JobDetails();
                if(biz.IsExist(COMP_ID
                             , hdfEstID.Value
                             , ESTTERM_REF_ID
                             , ESTTERM_SUB_ID
                             , DataTypeUtility.GetToInt32(temp[4])
                             , UltraWebGrid1.Rows[i].Cells.FromKey("EST_JOB_ID").Value.ToString()))
                    okCnt += (biz.ModifyJobDetailByDate(temp)) ? 1 : 0;
                else
                    okCnt += (biz.AddJobDetail(temp)) ? 1 : 0;
            }
        }

        return okCnt;
    }

    private void DoConfig()
    {
        string strStatusStyleID = "0004";

        DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
        DropDownListCommom.BindEstTerm(ddlEstTermRefID);
        DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                , WebUtility.GetIntByValueDropDownList(ddlCompID)
                                                , "N");

        TreeViewCommom.BindEst(TreeView1, WebUtility.GetIntByValueDropDownList(ddlCompID)); 

        Biz_Status status	= new Biz_Status();
        DataSet ds          = status.GetStatuses( strStatusStyleID );

        UltraWebGrid1.Columns.FromKey("STATUS_YN").ValueList.DataSource    = ds.Tables[0];
        UltraWebGrid1.Columns.FromKey("STATUS_YN").ValueList.DisplayMember = "STATUS_NAME";
        UltraWebGrid1.Columns.FromKey("STATUS_YN").ValueList.ValueMember   = "STATUS_ID";
        UltraWebGrid1.Columns.FromKey("STATUS_YN").ValueList.DataBind();

        Biz_TermSteps termStep  = new Biz_TermSteps();
        DataSet dsStep          = termStep.GetTermSteps(WebUtility.GetIntByValueDropDownList(ddlCompID), "Y");
        
        UltraWebGrid1.Columns.FromKey("STEP_ID").ValueList.DataSource    = dsStep.Tables[0];
        UltraWebGrid1.Columns.FromKey("STEP_ID").ValueList.DisplayMember = "ESTTERM_STEP_NAME";
        UltraWebGrid1.Columns.FromKey("STEP_ID").ValueList.ValueMember   = "ESTTERM_STEP_ID";
        UltraWebGrid1.Columns.FromKey("STEP_ID").ValueList.DataBind();
        UltraWebGrid1.Columns.FromKey("STEP_ID").ValueList.ValueListItems.RemoveAt(0);
        UltraWebGrid1.Columns.FromKey("STEP_ID").ValueList.ValueListItems.Insert(0,new ValueListItem("-",0));
    }

    private void ClearControlValues()
    {
       
    }

    private void ButtonStatusInit()
    {
        
    }

    private void ButtonStatusBySelected()
    {
       
    }

    private void BindEstJob(string est_id)
    {
        UltraWebGrid1.Clear();
        Biz_JobEstMaps biz       = new Biz_JobEstMaps();
        DataSet ds               = biz.GetJobEstMap(COMP_ID
                                                  , est_id
                                                  , ESTTERM_REF_ID
                                                  , ESTTERM_SUB_ID
                                                  , "");

        UltraWebGrid1.DataSource = ds.Tables[0];
        UltraWebGrid1.DataBind();

        //lblRowCount.Text         = ds.Tables[0].Rows.Count.ToString();
    }

    #endregion
}
