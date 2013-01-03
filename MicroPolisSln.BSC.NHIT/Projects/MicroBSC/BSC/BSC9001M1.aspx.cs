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
using System.Collections.Specialized;

using MicroBSC.Biz.Common;
using MicroBSC.Biz.Common.Biz;
using MicroBSC.PRJ.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC9001M1 : AppPageBase
{
    #region ==========================[변수선언]================

    public int IKey
    {
        get
        {
            if (ViewState["KEY"] == null)
            {
                ViewState["KEY"] = GetRequestByInt("KEY", 0);
            }

            return (int)ViewState["KEY"];
        }
        set
        {
            ViewState["KEY"] = value;
        }
    }

    #endregion

    #region ==========================[페이지 초기화]================

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ExecAllTime();
        if (!IsPostBack)
        {
            this.InitForm();
        }
        else
        {

        }

        this.ShowAnyTime();
    }

    public void ShowAnyTime()
    {
        if (divAreaAppLine.Style["display"] == "block")
        {
            divAreaAppLine.Style.Add("display", "block");
        }
        else
        {
            divAreaAppLine.Style.Add("display", "none");
        }
    }

    #endregion

    #region
    public void InitForm()
    {
        WebCommon.FillComDeptTree(trvDept);
        Biz_Prj_Info objPrj = new Biz_Prj_Info(this.IKey);

        this.txtTitle.Text = "[" + Biz_Type.biz_type_prm_doc_name + "]" + objPrj.IPrj_Name;
    }
    public void ExecAllTime()
    {
        trvDept.SelectedNodeChanged += new EventHandler(trvDept_SelectedNodeChanged);
        btnLineConfirm.Click += new ImageClickEventHandler(btnLineConfirm_Click);
        btnSendMail.Click += new EventHandler(btnSendMail_Click);
    }

    void trvDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        divAreaAppLine.Style["display"] = "block";

        TreeNode trnDept = trvDept.SelectedNode;

        if (trnDept != null)
        {
            string strDeptNm = trnDept.Text;
            string strDeptID = trnDept.Value;

            EmpInfos objEmp = new EmpInfos();
            DataSet rDs = objEmp.GetEmpInfoByDeptID(strDeptID);

            rDs.Tables[0].DefaultView.Sort = "POS_RNK_ID asc";
            ugrdEmpList.Clear();
            ugrdEmpList.DataSource = rDs.Tables[0].DefaultView;
            ugrdEmpList.DataBind();
        }
    }

    void btnLineConfirm_Click(object sender, ImageClickEventArgs e)
    {
        divAreaAppLine.Style["display"] = "none";
        string sDept = "";
        string sEmpe = "";
        string sMail = "";

        int iRow = ugrdAppLine.Rows.Count;
        for (int i = 0; i < iRow; i++)
        {
            sDept = ugrdAppLine.Rows[i].Cells.FromKey("DEPT_NAME").Value.ToString();
            sEmpe = ugrdAppLine.Rows[i].Cells.FromKey("EMP_NAME").Value.ToString();
            sMail += sEmpe.Trim() + "(" + sDept.Trim() + ");";
        }

        txtMailTo.Text = sMail;
    }

    public void SendMail()
    {
        if (this.ugrdAppLine.Rows.Count < 1)
        {
            this.ClientScript.RegisterClientScriptBlock(typeof(string), "1", JSHelper.GetAlertScript("수신인을 선택해 주십시오.", false));
        }

        //string sFile = "Mail_Draft.htm";
        EmpInfos objEmp       = new EmpInfos(EMP_REF_ID);
        //DataTable dtMailParam = new DataTable("PARAM");
        //dtMailParam.Columns.Add("KEY", typeof(string));
        //dtMailParam.Columns.Add("VAL", typeof(string));

        //string strVPath = Request.ApplicationPath;
        //string strSHost = Request.Url.Host;
        //string strSPort = Request.Url.Port.ToString();
        //string strProto = Request.Url.Scheme;
        //strVPath = (strVPath == "/") ? "" : strVPath;

        //string strFullPath = strProto + "://" + strSHost + ":" + strSPort + strVPath;

        //DataRow dr = null;
        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[SITE_URL]";
        //dr["VAL"] = strFullPath;
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[BIZ_TYPE]";
        //dr["VAL"] = Biz_Type.biz_type_prm_doc_name;
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[APP_CODE]";
        //dr["VAL"] = "-";
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[TITLE]";
        //dr["VAL"] = this.ITitle;
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[EMP_NAME]";
        //dr["VAL"] = objEmp.Emp_Name;
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[DEPT_NAME]";
        //dr["VAL"] = objEmp.Dept_Name;
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[TRX_DATE]";
        //dr["VAL"] = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0');
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[TODAY]";
        //dr["VAL"] = DateTime.Now.ToString();
        //dtMailParam.Rows.Add(dr);

        //dr = dtMailParam.NewRow();
        //dr["KEY"] = "[DRAFT_TYPE]";
        //dr["VAL"] = "사업관리진행 확인";
        //dtMailParam.Rows.Add(dr);

        //string sMailTitle = "[성과관리 - 사업관리진행건 알림메일]";

        //string sContent = PageUtility.GetMailContent(sFile, dtMailParam);

        //txtTitle.Text = sMailTitle;
        //wheMail.Text = sContent;

        string sEmail = "";
        int iRow = ugrdAppLine.Rows.Count;
        for (int i = 0; i < iRow; i++)
        {
            sEmail = ugrdAppLine.Rows[i].Cells.FromKey("EMP_EMail").Value.ToString();
            PageUtility.SendMail(txtTitle.Text, wheMail.Text, objEmp.Emp_Email, sEmail);
        }

        this.ClientScript.RegisterClientScriptBlock(typeof(string), "1", JSHelper.GetAlertScript("발송되었습니다.", true));
    }

    void btnSendMail_Click(object sender, EventArgs e)
    {
        this.SendMail();
    }

    #endregion
}
