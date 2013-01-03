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

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Biz.BSC.Biz;
using MicroBSC.PRJ.Biz;
using Infragistics.WebUI.UltraWebGrid;


public partial class PRJ_PRJ0202S1 : PrjPageBase
{

    private string EST_ID = "";
    private int ESTTERM_STEP_ID;
    private string Q_OBJ_ID = "";
    private string CTRL_VALUE_NAME = "";

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

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = GetRequestByInt("ESTTERM_STEP_ID", 2);
        EST_ID          = GetRequest("EST_ID");
        Q_OBJ_ID        = GetRequest("Q_OBJ_ID");
        CTRL_VALUE_NAME = GetRequest("CTRL_VALUE_NAME");

        if (!Page.IsPostBack)
        {
            this.SetPrjList();
        }

        ltrScript.Text = "";
    }

    public void SetPrjList()
    {
        MicroBSC.Integration.PRJ.Biz.Biz_Prj_Info bizPrjInfo = new MicroBSC.Integration.PRJ.Biz.Biz_Prj_Info();
        Biz_Prj_Info objPrj = new Biz_Prj_Info();

        string iprj_code = "";//txtPrjCode.Text.Trim();
        string iprj_name = "";// txtPrjName.Text.Trim();
        int iowner_dept_id = 0;// WebUtility.GetIntByValueDropDownList(ddlOwnerDeptID);
        string iowner_emp_name = "";// txtOwnerEmpName.Text.Trim();
        string iprj_type = ""; // WebUtility.GetByValueDropDownList(ddlPrjType);
        object iplan_start_date = base.GetStartDayofCurrent();
        object iplan_end_date = base.GetEndDayofCurrent();

        //DataSet rDs = objPrj.GetAllList(iprj_code
        //                            , iprj_name
        //                            , iowner_dept_id
        //                            , iowner_emp_name
        //                            , iprj_type
        //                            , iplan_start_date
        //                            , iplan_end_date);

        DataTable dt = bizPrjInfo.Get_Prj_Info_Not_In_Question_Map(COMP_ID
                                                                , EST_ID
                                                                , ESTTERM_REF_ID
                                                                , ESTTERM_SUB_ID
                                                                , ESTTERM_STEP_ID);

        ugrdPrjList.Clear();
        ugrdPrjList.DataSource = dt;
        ugrdPrjList.DataBind();

    }
     
    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        int cntRow = ugrdPrjList.Rows.Count;

        CheckBox chkCheck;
        UltraGridRow ugrdRow;
        TemplatedColumn col_Check = (TemplatedColumn)ugrdPrjList.Bands[0].Columns.FromKey("selchk");
        string values = "";
        bool isFirst = true;
        int chkCnt = 0;

        for (int i = 0; i < ugrdPrjList.Rows.Count; i++)
        {
            chkCheck = (CheckBox)((CellItem)col_Check.CellItems[ugrdPrjList.Rows[i].BandIndex]).FindControl("cBox");
            ugrdRow = ugrdPrjList.Rows[i];
            if (chkCheck.Checked)
            {
                if (isFirst)
                {
                    values += ugrdRow.Cells.FromKey("PRJ_REF_ID").ToString();
                    isFirst = false;
                }
                else
                {
                    values += string.Format(",{0}", ugrdRow.Cells.FromKey("PRJ_REF_ID").ToString());
                }

                chkCnt++;
            }
        }

        if (chkCnt == 0)
        {
            ltrScript.Text = JSHelper.GetAlertScript("추가할 프로젝트를 선택하세요.");
            return;
        }
        else
        {
            Response.Write("<script type='text/javascript'>\r\n");
            Response.Write("opener.document.getElementById('" + CTRL_VALUE_NAME + "').value='" + values + "';\r\n");
            Response.Write("</script>\r\n");

            ltrScript.Text = JSHelper.GetOpenerControlCallBackScript(ICCB1, true);
            
        }
        
    }
}
