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
using MicroBSC.Integration.PRJ.Biz;
using MicroBSC.Integration.COM.Biz;

public partial class PMS_PMS0300S1 : EstPageBase
{
    Biz_Com_Emp_Role_Rel bizComEmpRoleRel;
    Biz_Prj_Info bizPrjInfo;


    string EST_ID;
    string EST_TGT_TYPE;
    int EST_EMP_ID;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }




    protected void Page_Load(object sender, EventArgs e)
    {
        bizPrjInfo = new Biz_Prj_Info();
        bizComEmpRoleRel = new Biz_Com_Emp_Role_Rel();



        EST_ID = "3Q";
        EST_TGT_TYPE = WebUtility.GetRequest("EST_TGT_TYPE");
        EST_EMP_ID = 0;

        if (EST_TGT_TYPE.Equals("EST"))
            EST_EMP_ID = gUserInfo.Emp_Ref_ID;

        int role_ref_id = 9;//성과평가관리자
        if (bizComEmpRoleRel.IsMatch_EmpRole(gUserInfo.Emp_Ref_ID, role_ref_id))
            EST_EMP_ID = 0;
        


        if (!IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);

            DropDownListCommom.BindEstTerm(ddlEstTermRefID);
            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID,  WebUtility.GetIntByValueDropDownList(ddlCompID), "N");

            this.prj_sDate.Value = System.DateTime.Now.AddMonths(-1);

            this.rdo_prj_select.Checked = false;
            this.rdo_prj_est.Checked = true;
        }

        COMP_ID = WebUtility.GetIntByValueDropDownList(ddlCompID);
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        ltrScript.Text = "";


        if (this.rdo_prj_select.Checked)
        {
            this.ibnSetTarget.Enabled = true;
            this.ibnSetTarget.Visible = true;
        }
        else
        {
            this.ibnSetTarget.Enabled = false;
            this.ibnSetTarget.Visible = false;
        }

        if (!IsPostBack)
            doBind();
    }


    protected void ddlEstTermRefID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_REF_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermRefID);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ESTTERM_SUB_ID = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        doBind();
    }

    protected void doBind()
    {
        if (this.rdo_prj_select.Checked)
        {
            doBind_select();
        }
        else
        {
            doBind_est();
        }
    }

    protected void doBind_select()
    {
        UltraWebGrid1.Clear();

        object sDate = this.prj_sDate.Value;
        object eDate = this.prj_eDate.Value;

        string PRJ_NAME = this.txtPRJ_NAME.Text;

        string StartDate = ((DateTime)sDate).ToString("yyyy-MM-dd");
        string EndDate = ((DateTime)eDate).ToString("yyyy-MM-dd");

        string gubun = this.GUBUN.SelectedValue;

        DataTable DT = bizPrjInfo.Get_Pms_Info_Join_PRj_Info_List(StartDate, EndDate, PRJ_NAME, EST_EMP_ID, gubun);

        this.lblRowCount.Text = DT.Rows.Count.ToString();

        UltraWebGrid1.DataSource = DT;
        UltraWebGrid1.DataBind();
    }
    protected void doBind_est()
    {
        UltraWebGrid1.Clear();

        int estterm_step_id = 2;

        string PRJ_NAME = this.txtPRJ_NAME.Text;

        string gubun = this.GUBUN.SelectedValue;

        DataTable DT = bizPrjInfo.Get_Pms_Info_Join_PRj_Info_List(EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, estterm_step_id, PRJ_NAME, EST_EMP_ID, gubun);

        this.lblRowCount.Text = DT.Rows.Count.ToString();

        UltraWebGrid1.DataSource = DT;
        UltraWebGrid1.DataBind();
    }


    protected void ibnSetTarget_Click(object sender, EventArgs e)
    {
        SetTarget();
        doBind();
    }
    protected void SetTarget()
    {
        //DataTable DT = UltraGridUtility.GetDataSetByCheckedBox(UltraWebGrid1
        //                                                        , new string[] { "PRJ_ID" }
        //                                                        , "selchk"
        //                                                        , "cBox").Tables[0];


        DataTable DT = new DataTable();
        DT.Columns.Add("PRJ_ID");

        foreach (UltraGridRow row in UltraWebGrid1.Rows)
        {
            string status = DataTypeUtility.GetString(row.Cells.FromKey("PRJ_EST_STATUS").Value);
            if (status.Equals("-"))
            {
                TemplatedColumn col_cBox = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                CheckBox cBox = (CheckBox)((CellItem)col_cBox.CellItems[row.BandIndex]).FindControl("cBox");

                if (cBox.Checked == true)
                {
                    DT.Rows.Add(row.Cells.FromKey("PRJ_ID").Value);
                }
            }
        }
        
        int estterm_step_id = 2;
        bool Result;

        Result = bizPrjInfo.Set_Est_Target(DT, COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, estterm_step_id, gUserInfo.Emp_Ref_ID);

        if (DT.Rows.Count > 0)
        {
            if (Result)
            {
                ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.");
            }
            else
            {
                ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다..");
            }
        }
        else
            ltrScript.Text = JSHelper.GetAlertScript("이미 적용된 프로젝트입니다.");
    }



    protected void ibnUnSetTarger_Click(object sender, EventArgs e)
    {
        int Result = UnSetTarget();

        if (Result > 0)
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 처리되었습니다.");
        else if (Result < 0)
            ltrScript.Text = JSHelper.GetAlertScript("평가 확정된 프로젝트입니다.");
        else
            ltrScript.Text = JSHelper.GetAlertScript("오류가 발생했습니다..");


        doBind();
    }


    protected int UnSetTarget()
    {
        int Result;
        //DataTable DT = UltraGridUtility.GetDataSetByCheckedBox(UltraWebGrid1
        //                                                        , new string[] { "PRJ_ID" }
        //                                                        , "selchk"
        //                                                        , "cBox").Tables[0];

        DataTable DT = new DataTable();
        DT.Columns.Add("PRJ_ID");


        foreach(UltraGridRow row in UltraWebGrid1.Rows)
        {
            string status = DataTypeUtility.GetString(row.Cells.FromKey("PRJ_EST_STATUS").Value);
            if (!status.Equals("E"))
            {
                TemplatedColumn col_cBox = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                CheckBox cBox = (CheckBox)((CellItem)col_cBox.CellItems[row.BandIndex]).FindControl("cBox");

                if (cBox.Checked == true)
                {
                    DT.Rows.Add(row.Cells.FromKey("PRJ_ID").Value);
                }
            }
        }


        Result = bizPrjInfo.UnSet_Est_Target(DT);
        if (DT.Rows.Count == 0)
            Result = -1;

        return Result;
    }
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        //PRJ_REF_ID가 있으면 Y로 마킹, 없으면 N으로 마킹
        UltraGridCell PRJ_REF_ID_Cell = e.Row.Cells.FromKey("PRJ_REF_ID");
        UltraGridCell PRJ_REF_ID_YN_Cell = e.Row.Cells.FromKey("PRJ_REF_ID_YN");
        string PRJ_REF_ID = PRJ_REF_ID_Cell.Value.ToString();

        if (PRJ_REF_ID.Equals("-"))
            PRJ_REF_ID_YN_Cell.Value = "N";
        else
            PRJ_REF_ID_YN_Cell.Value = "Y";




        //아이콘 및 링크 추가
        UltraGridCell Status_Cell = e.Row.Cells.FromKey("PRJ_EST_STATUS");
        UltraGridCell Status_Icon_Cell = e.Row.Cells.FromKey("STATUS_ICON");

        UltraGridCell Prj_Name_Cell = e.Row.Cells.FromKey("PRJ_NAME");
        
        string EST_DEPT_ID = e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString();
        string EST_EMP_ID = e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString();

        string PRJ_NAME = e.Row.Cells.FromKey("PRJ_NAME").Value.ToString();

        string PRJ_EST_STATUS = Status_Cell.Value.ToString();
        
        string greenIcon = "../images/icon/color/green.gif";
        string blueIcon = "../images/icon/color/blue.gif";

        string imgURL;

        string popupURL = "PMS0300M1.aspx";
        string PRJ_ID = DataTypeUtility.GetString(e.Row.Cells.FromKey("PRJ_ID").Value);

        if (PRJ_EST_STATUS.Equals("E"))
        {
            imgURL = string.Format("<img src=\"{0}\" />", blueIcon);
        }
        else if (PRJ_EST_STATUS.Equals("N") || PRJ_EST_STATUS.Equals("P"))
        {
            imgURL = string.Format("<img src=\"{0}\" />", greenIcon);
        }
        else
        {
            imgURL = "-";
        }
        


        string jsLink = string.Format("javascript:openEstPopup('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');"
                                    , popupURL
                                    , PRJ_REF_ID
                                    , PRJ_ID
                                    , COMP_ID
                                    , "3Q"
                                    , ESTTERM_REF_ID
                                    , ESTTERM_SUB_ID
                                    , "2"//ESTTERM_STEP_ID
                                    , EST_DEPT_ID
                                    , EST_EMP_ID);


        if (imgURL.Length > 1)
            Status_Icon_Cell.Value = string.Format("<a href=\"{0}\">{1}</a>", jsLink, imgURL);
        else
            Status_Icon_Cell.Value = imgURL;

        if (imgURL.Length > 1)
        {
            Prj_Name_Cell.Value = string.Format("<a href=\"{0}\" style=\"color:Navy;\">{1}</a>", jsLink, PRJ_NAME);

            Prj_Name_Cell.Style.Font.Bold = true;

            
        }
        else
            Prj_Name_Cell.Value = PRJ_NAME;
    }
}

