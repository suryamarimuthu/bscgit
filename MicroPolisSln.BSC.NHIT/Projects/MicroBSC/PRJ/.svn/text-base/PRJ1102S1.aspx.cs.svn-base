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

using System.Collections.Generic;
using System.Text;

using MicroBSC.Common;
using MicroBSC.BSC.Biz;
using MicroBSC.RolesBasedAthentication;
using Infragistics.WebUI.UltraWebGrid;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;

public partial class PRJ_PRJ1102S1 : AppPageBase
{

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
                ViewState["CCB2"] = GetRequest("CCB2", this.iBtnWorkInfoRefresh.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB2"];
        }
        set
        {
            ViewState["CCB2"] = value;
        }
    }

    public string ICCB3
    {
        get
        {
            if (ViewState["CCB3"] == null)
            {
                ViewState["CCB3"] = GetRequest("CCB3", this.iBtnWorkExecRefresh.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB3"];
        }
        set
        {
            ViewState["CCB3"] = value;
        }
    }

    //public string ICCB4
    //{
    //    get
    //    {
    //        if (ViewState["CCB4"] == null)
    //        {
    //            ViewState["CCB4"] = GetRequest("CCB4", this.iBtnWorkTaskRefresh.ClientID.Replace('_', '$'));
    //        }

    //        return (string)ViewState["CCB4"];
    //    }
    //    set
    //    {
    //        ViewState["CCB4"] = value;
    //    }
    //}

    //public string ICCB5
    //{
    //    get
    //    {
    //        if (ViewState["CCB5"] == null)
    //        {
    //            ViewState["CCB5"] = GetRequest("CCB5", this.iBtnWorkItemRefresh.ClientID.Replace('_', '$'));
    //        }

    //        return (string)ViewState["CCB5"];
    //    }
    //    set
    //    {
    //        ViewState["CCB5"] = value;
    //    }
    //}

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public string IEstTermRefIDName
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID_NAME"] == null)
            {
                ViewState["ESTTERM_REF_ID_NAME"] = GetRequest("ESTTERM_REF_ID_NAME", "");
            }

            return (string)ViewState["ESTTERM_REF_ID_NAME"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID_NAME"] = value;
        }
    }

    //평가부서
    public int IEstDeptRefID
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID"] == null)
            {
                ViewState["EST_DEPT_REF_ID"] = GetRequestByInt("EST_DEPT_REF_ID", 0);
            }

            return (int)ViewState["EST_DEPT_REF_ID"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID"] = value;
        }
    }

    public string IEstDeptRefIDName
    {
        get
        {
            if (ViewState["EST_DEPT_REF_ID_NAME"] == null)
            {
                ViewState["EST_DEPT_REF_ID_NAME"] = GetRequest("EST_DEPT_REF_ID_NAME", "");
            }

            return (string)ViewState["EST_DEPT_REF_ID_NAME"];
        }
        set
        {
            ViewState["EST_DEPT_REF_ID_NAME"] = value;
        }
    }

    public int IWorkRefID
    {
        get
        {
            if (ViewState["WORK_REF_ID"] == null)
            {
                ViewState["WORK_REF_ID"] = GetRequestByInt("WORK_REF_ID", 0);
            }

            return (int)ViewState["WORK_REF_ID"];
        }
        set
        {
            ViewState["WORK_REF_ID"] = value;
        }
    }

    public string IWorkRefIDName
    {
        get
        {
            if (ViewState["WORK_REF_ID_NAME"] == null)
            {
                ViewState["WORK_REF_ID_NAME"] = GetRequest("WORK_REF_ID_NAME", "");
            }

            return (string)ViewState["WORK_REF_ID_NAME"];
        }
        set
        {
            ViewState["WORK_REF_ID_NAME"] = value;
        }
    }


    public int IExecRefID
    {
        get
        {
            if (ViewState["EXEC_REF_ID"] == null)
            {
                ViewState["EXEC_REF_ID"] = GetRequestByInt("EXEC_REF_ID", 0);
            }

            return (int)ViewState["EXEC_REF_ID"];
        }
        set
        {
            ViewState["EXEC_REF_ID"] = value;
        }
    }

    public string IExecRefIDName
    {
        get
        {
            if (ViewState["EXEC_REF_ID_NAME"] == null)
            {
                ViewState["EXEC_REF_ID_NAME"] = GetRequest("EXEC_REF_ID_NAME", "");
            }

            return (string)ViewState["EXEC_REF_ID_NAME"];
        }
        set
        {
            ViewState["EXEC_REF_ID_NAME"] = value;
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

    public string ITaskRefIDName
    {
        get
        {
            if (ViewState["TASK_REF_ID_NAME"] == null)
            {
                ViewState["TASK_REF_ID_NAME"] = GetRequest("TASK_REF_ID_NAME", "");
            }

            return (string)ViewState["TASK_REF_ID_NAME"];
        }
        set
        {
            ViewState["TASK_REF_ID_NAME"] = value;
        }
    }

    public int IItemRefID
    {
        get
        {
            if (ViewState["ITEM_REF_ID"] == null)
            {
                ViewState["ITEM_REF_ID"] = GetRequestByInt("ITEM_REF_ID", 0);
            }

            return (int)ViewState["ITEM_REF_ID"];
        }
        set
        {
            ViewState["ITEM_REF_ID"] = value;
        }
    }

    public string IItemRefIDName
    {
        get
        {
            if (ViewState["ITEM_REF_ID_NAME"] == null)
            {
                ViewState["ITEM_REF_ID_NAME"] = GetRequest("ITEM_REF_ID_NAME", "");
            }

            return (string)ViewState["ITEM_REF_ID_NAME"];
        }
        set
        {
            ViewState["ITEM_REF_ID_NAME"] = value;
        }
    }

    public string IUseYN
    {
        get
        {
            if (ViewState["USE_YN"] == null)
            {
                ViewState["USE_YN"] = GetRequest("USE_YN", "");
            }

            return (string)ViewState["USE_YN"];
        }
        set
        {
            ViewState["USE_YN"] = value;
        }
    }

    public string hdfWhat
    {
        get
        {
            if (ViewState["HDFWHAT"] == null)
            {
                ViewState["HDFWHAT"] = GetRequest("HDFWHAT", "");
            }

            return (string)ViewState["HDFWHAT"];
        }
        set
        {
            ViewState["HDFWHAT"] = value;
        }
    }



    //평가기간
    public string strYMD;

    protected void Page_Load(object sender, EventArgs e)
    {

        SetAllTimeTop();

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
        ltrScript.Text = "";
    }


    private void InitControlValue()
    {

    }

    private void InitControlEvent()
    {
    }

    private void SetPageData()
    {
        if (!IsPostBack)
        {
            //평기기간(년)리스트
			WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
		}

        this.IEstTermRefID = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        MicroBSC.Estimation.Dac.TermInfos objTERM = new MicroBSC.Estimation.Dac.TermInfos(this.IEstTermRefID);
        this.IEstTermRefIDName  = Convert.ToString(objTERM.Estterm_name);

		int intEstTermId = (ddlEstTermInfo.Items.Count > 0) ? int.Parse(ddlEstTermInfo.SelectedValue) : 0;
        if (User.IsInRole(ROLE_ADMIN))
            WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, true);
        else
		    WebCommon.SetEstDeptDropDownList(ddlEstDept, intEstTermId, false, gUserInfo.Emp_Ref_ID);

		this.IEstDeptRefID = PageUtility.GetIntByValueDropDownList(ddlEstDept);

		if (ddlEstDept.Items.Count > 0)
		{
			MicroBSC.Estimation.Dac.DeptInfos objDEPT = new MicroBSC.Estimation.Dac.DeptInfos(this.IEstDeptRefID);
			this.IEstDeptRefIDName = Convert.ToString(objDEPT.Dept_Name);
			SetFormData();
        }
        else
        {
            this.txtWorkEmpIDName.Text = "";
            this.txtWorkCode.Text = "";
            this.txtWorkName.Text = "";
            this.IEstDeptRefID = 0;
            this.IWorkRefID = 0;
            this.IExecRefID = 0;
            this.ITaskRefID = 0;
            this.IItemRefID = 0;
            this.pnlInfoBtn.Visible = false;
            this.pnlExecBtn.Visible = false;
            
        }

        
    }

    private void SetPostBack()
    {

    }

    private void SetAllTimeBottom()
    {

    }

    private void pnlWorkInfoClear()
    {
		lblEstTerm1.Text = "";
        lblEstDept1.Text = "";
        pnlInfoBtn.Visible = false;
        
        ugrdWorkInfoList.Clear();
    }

    private void pnlWorkExecClear()
    {
        lblWorkInfo2.Text = "";
        pnlExecBtn.Visible = false;
        ugrdWorkExecList.Clear();
    }

    #endregion

    //&&여기까지
    #region 내부함수
    private void SetFormData()
    {
        pnlWorkInfoClear();
        pnlWorkExecClear();
        this.IWorkRefID = 0;
        this.IWorkRefIDName = "";
        this.IExecRefID = 0;
        this.IExecRefIDName = "";
        this.ITaskRefID = 0;
        this.ITaskRefIDName = "";
        this.IItemRefID = 0;
        this.IItemRefIDName  = "";

        SetWorkInfoList();
    }

    //중점과제(WorkInfo)조회
    private void SetWorkInfoList()
    {
        pnlWorkInfoClear();
        pnlWorkExecClear();

        lblEstTerm1.Text = this.IEstTermRefIDName + ">>";
        lblEstDept1.Text = this.IEstDeptRefIDName + ">>" ;


        Biz_Bsc_Work_Info objWorkInfo = new Biz_Bsc_Work_Info();
        //DataSet rDs = objWorkInfo.GetAllList(this.IEstTermRefID, this.IEstDeptRefID);
        //2012.01.02 박효동 : 허성덕과장 요청으로 조회조건에서 누락된 아이들을 추가해줌
        DataSet rDs = objWorkInfo.GetAllList(this.IEstTermRefID, this.IEstDeptRefID, txtWorkEmpIDName.Text.Trim(), txtWorkCode.Text.Trim(), txtWorkName.Text.Trim(), "", "", "Y");

        ugrdWorkInfoList.Clear();
        ugrdWorkInfoList.DataSource = rDs;
        ugrdWorkInfoList.DataBind();
        pnlInfoBtn.Visible = true;


        IExecRefID = 0;
        ITaskRefID = 0;
        IItemRefID = 0;

    }

    //중점과제의 하위 실행과제(WorkExec) 조회
    private void SetWorkExecList()
    {
        pnlWorkExecClear();

        lblWorkInfo2.Text = this.IWorkRefIDName + ">>";

        Biz_Bsc_Work_Exec objWorkExec = new Biz_Bsc_Work_Exec();
        DataSet rDs = objWorkExec.GetAllList(this.IEstTermRefID, this.IEstDeptRefID, this.IWorkRefID);

        ugrdWorkExecList.Clear();
        ugrdWorkExecList.DataSource = rDs;
        ugrdWorkExecList.DataBind();
        pnlExecBtn.Visible = true;

        ITaskRefID = 0;
        IItemRefID = 0;

    }



    private void GetParentStg()
    {

    }

    #endregion

    #region 서버 이벤트 처리 함수

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetPageData();
    }
    #endregion

    protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.SetFormData();
    }
    protected void iBtnSelectAll_Click(object sender, ImageClickEventArgs e)
    {
        this.SetFormData();
    }

    protected void lBtnReload_Click(object sender, EventArgs e)
    {
       
    }

    protected void iBtnWorkInfoRefresh_Click(object sender, ImageClickEventArgs e)
    {
        SetWorkInfoList();
    }
    protected void iBtnWorkExecRefresh_Click(object sender, ImageClickEventArgs e)
    {
        SetWorkExecList();
    }
    protected void ugrdWorkInfoList_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        TemplatedColumn cCol1 = (TemplatedColumn)e.Row.Band.Columns.FromKey("COMPLETE_YN");
        Image objImg1 = (Image)((CellItem)cCol1.CellItems[e.Row.BandIndex]).FindControl("imgCompleteYn");
        objImg1.ImageUrl = (e.Row.Cells.FromKey("COMPLETE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        string strUrl = "";
        if (e.Row.Cells.FromKey("STG_COUNT").Value != null)
        {
            strUrl = String.Format("<a href={0}javascript:OpenWorkStgWindow('{1}','{2}','{3}');{0}><u><font color=red>{4}</font></u></a>"
                                   , "\""
                                   , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("STG_COUNT").Value.ToString());

            e.Row.Cells.FromKey("STG_COUNT").Text = strUrl;
           
          
        }
      


    }
    protected void ugrdWorkExecList_InitializeRow(object sender, RowEventArgs e)
    {
        TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        TemplatedColumn cCol1 = (TemplatedColumn)e.Row.Band.Columns.FromKey("COMPLETE_YN");
        Image objImg1 = (Image)((CellItem)cCol1.CellItems[e.Row.BandIndex]).FindControl("imgCompleteYn");
        objImg1.ImageUrl = (e.Row.Cells.FromKey("COMPLETE_YN").Value.ToString() == "Y") ?
                          "../images/icon_o.gif" : "../images/icon_x.gif";

        string strUrl = "";
        if (e.Row.Cells.FromKey("STG_COUNT").Value != null)
        {
            strUrl = String.Format("<a href={0}javascript:OpenExecStgWindow('{1}','{2}','{3}','{4}');{0}><u><font color=red>{5}</font></u></a>"
                                   , "\""
                                   , e.Row.Cells.FromKey("ESTTERM_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("EST_DEPT_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("WORK_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("EXEC_REF_ID").Value.ToString()
                                   , e.Row.Cells.FromKey("STG_COUNT").Value.ToString());

            e.Row.Cells.FromKey("STG_COUNT").Text = strUrl;


        }
      
      
    }



    protected void ugrdWorkExecList_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows.Count < 1)
        {
        }
        else
        {
            this.IExecRefID = int.Parse(e.SelectedRows[0].Cells.FromKey("EXEC_REF_ID").Value.ToString());
            this.IExecRefIDName = e.SelectedRows[0].Cells.FromKey("EXEC_NAME").Value.ToString();
            this.IUseYN = e.SelectedRows[0].Cells.FromKey("USE_YN").Value.ToString();
        }

    }

	protected void ddlEstDept_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.IEstDeptRefID = PageUtility.GetIntByValueDropDownList(ddlEstDept);
		MicroBSC.Estimation.Dac.DeptInfos objDEPT = new MicroBSC.Estimation.Dac.DeptInfos(this.IEstDeptRefID);
		this.IEstDeptRefIDName = Convert.ToString(objDEPT.Dept_Name);
		SetFormData();

	}

    protected void btnExecView_Click(object sender, ImageClickEventArgs e)
    {
        if (ugrdWorkInfoList.DisplayLayout.SelectedRows.Count < 1)
        {

        }
        else
        {
            this.IWorkRefID = int.Parse(ugrdWorkInfoList.Rows[ugrdWorkInfoList.DisplayLayout.SelectedRows[0].Index].Cells.FromKey("WORK_REF_ID").Value.ToString());
            this.IWorkRefIDName = ugrdWorkInfoList.Rows[ugrdWorkInfoList.DisplayLayout.SelectedRows[0].Index].Cells.FromKey("WORK_NAME").Value.ToString();
            this.IUseYN = ugrdWorkInfoList.Rows[ugrdWorkInfoList.DisplayLayout.SelectedRows[0].Index].Cells.FromKey("USE_YN").Value.ToString();
            SetWorkExecList();
        }
    }

}
