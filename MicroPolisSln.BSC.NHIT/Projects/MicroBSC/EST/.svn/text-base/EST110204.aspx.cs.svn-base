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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;

public partial class EST_EST110204 : EstPageBase
{
    protected int IESTTERM_REF_ID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
                ViewState["ESTTERM_REF_ID"] = 0;
            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    protected int ICOMP_ID
    {
        get
        {
            if (ViewState["COMP_ID"] == null)
                ViewState["COMP_ID"] = 0;
            return (int)ViewState["COMP_ID"];
        }
        set
        {
            ViewState["COMP_ID"] = value;
        }
    }

    protected string IEST_ID
    {
        get
        {
            if (ViewState["EST_ID"] == null)
                ViewState["EST_ID"] = "3A";
            return (string)ViewState["EST_ID"];
        }
        set
        {
            ViewState["EST_ID"] = value;
        }
    }

    protected int IESTTERM_SUB_ID
    {
        get
        {
            if (ViewState["ESTTERM_SUB_ID"] == null)
                ViewState["ESTTERM_SUB_ID"] = 0;
            return (int)ViewState["ESTTERM_SUB_ID"];
        }
        set
        {
            ViewState["ESTTERM_SUB_ID"] = value;
        }
    }

    //1: 평가자, 2: 피평가자
    protected int IUSERTYPE
    {
        get
        {
            if (ViewState["USERTYPE"] == null)
                ViewState["USERTYPE"] = 1;
            return (int)ViewState["USERTYPE"];
        }
        set
        {
            ViewState["USERTYPE"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoInitControl();
            DoBinding();
        }

        ltrScript.Text = "";
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ICOMP_ID = PageUtility.GetIntByValueDropDownList(ddlCompID);
    }

    protected void ddlEstTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdMBO.Clear();
        lblRowCount.Text = "0/0";
        IESTTERM_REF_ID = PageUtility.GetIntByValueDropDownList(ddlEstTerm);
    }

    protected void ddlEstTermSubID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ugrdMBO.Clear();
        lblRowCount.Text = "0/0";
        IESTTERM_SUB_ID = PageUtility.GetIntByValueDropDownList(ddlEstTermSubID);
    }

    private void DoInitControl()
    {
        
        DropDownListCommom.BindComp(ddlCompID, lblCompTitle);
        ICOMP_ID = GetRequestByInt("COMP_ID", PageUtility.GetIntByValueDropDownList(ddlCompID));
        PageUtility.FindByValueDropDownList(ddlCompID, ICOMP_ID);

        DropDownListCommom.BindEstTerm(ddlEstTerm);
        IESTTERM_REF_ID = GetRequestByInt("ESTTERM_REF_ID", PageUtility.GetIntByValueDropDownList(ddlEstTerm));
        PageUtility.FindByValueDropDownList(ddlEstTerm, IESTTERM_REF_ID);

        DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID
                                                    , ICOMP_ID
                                                    , "N");
        IESTTERM_SUB_ID = GetRequestByInt("ESTTERM_SUB_ID", PageUtility.GetIntByValueDropDownList(ddlEstTermSubID));
        PageUtility.FindByValueDropDownList(ddlEstTermSubID, IESTTERM_SUB_ID);

        IUSERTYPE = GetRequestByInt("USERTYPE", 1);
        IEST_ID = GetRequest("EST_ID", "3A");
        if (User.IsInRole(ROLE_ADMIN) || User.IsInRole(ROLE_ESTADMIN))
        {
        }
        else
        {
            if (IUSERTYPE == 1)
            {
                ugrdMBO.Bands[0].Columns.FromKey("EST_EMP_NAME").Hidden = true;
                ugrdMBO.Bands[0].Columns.FromKey("EST_DEPT_NAME").Hidden = true;
            }
            else
            {
                ugrdMBO.Bands[0].Columns.FromKey("TGT_EMP_NAME").Hidden = true;
                ugrdMBO.Bands[0].Columns.FromKey("TGT_DEPT_NAME").Hidden = true;
            }
        }
        WebCommon.SetComDeptDropDownList(ddlComDept, true);

        if (!User.IsInRole(ROLE_ADMIN) && !User.IsInRole(ROLE_ESTADMIN))
        {
            lblDept.Visible = ddlComDept.Visible = false;
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        DoBinding();
    }

    private void DoBinding()
    {
        Biz_Datas biz   = new Biz_Datas();
        //DataSet ds = biz.Get3GADataList(ICOMP_ID
        //                                , IEST_ID
        //                                , IESTTERM_REF_ID
        //                                , IESTTERM_SUB_ID
        //                                , (User.IsInRole(ROLE_ADMIN) || User.IsInRole(ROLE_ESTADMIN) ? 0 : IUSERTYPE)
        //                                , (User.IsInRole(ROLE_ADMIN) || User.IsInRole(ROLE_ESTADMIN) ? PageUtility.GetIntByValueDropDownList(ddlComDept) : EMP_REF_ID));

        //DataSet ds = biz.Get3GADataList(ICOMP_ID
        //                                , IEST_ID
        //                                , IESTTERM_REF_ID
        //                                , IESTTERM_SUB_ID
        //                                , 2
        //                                , -1);

        MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map bizEstEmpEstTargetMap = new MicroBSC.Integration.EST.Biz.Biz_Est_Emp_Est_Target_Map();
        DataSet ds = bizEstEmpEstTargetMap.Get3A_DB(ICOMP_ID
                                        , IEST_ID
                                        , IESTTERM_REF_ID
                                        , IESTTERM_SUB_ID
                                        , (User.IsInRole(ROLE_ADMIN) || User.IsInRole(ROLE_ESTADMIN) ? 0 : IUSERTYPE)
                                        , (User.IsInRole(ROLE_ADMIN) || User.IsInRole(ROLE_ESTADMIN) ? PageUtility.GetIntByValueDropDownList(ddlComDept) : EMP_REF_ID));


        if (ds.Tables[0].Rows.Count == 0)
        {
            IUSERTYPE = 2;
            if (User.IsInRole(ROLE_ADMIN) || User.IsInRole(ROLE_ESTADMIN))
            {
            }
            else
            {
                ugrdMBO.Bands[0].Columns.FromKey("EST_EMP_NAME").Hidden = false;
                ugrdMBO.Bands[0].Columns.FromKey("EST_DEPT_NAME").Hidden = false;
                ugrdMBO.Bands[0].Columns.FromKey("TGT_EMP_NAME").Hidden = true;
                ugrdMBO.Bands[0].Columns.FromKey("TGT_DEPT_NAME").Hidden = true;
            }
            ds = bizEstEmpEstTargetMap.Get3A_DB(ICOMP_ID
                                    , IEST_ID
                                    , IESTTERM_REF_ID
                                    , IESTTERM_SUB_ID
                                    , IUSERTYPE
                                    , EMP_REF_ID);
        }

        ugrdMBO.Clear();
        ugrdMBO.DataSource = ds;
        ugrdMBO.DataBind();

        lblRowCount.Text = ds.Tables[0].Compute("COUNT(COMPLETE_YN)", "COMPLETE_YN = 'Y'").ToString() + " / " + ds.Tables[0].Rows.Count.ToString();
    }

    protected void ugrdMBO_InitializeLayout(object sender, LayoutEventArgs e)
    {
    }
    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;
        if (drw["COMPLETE_YN"].ToString() == "N")
        {
            e.Row.Cells.FromKey("COMPLETE_YN").Text = string.Format("<div class='stext'><img src='../images/icon_x.gif'></div>");
        }
        else
        {
            e.Row.Cells.FromKey("COMPLETE_YN").Text = string.Format("<div class='stext'><img src='../images/icon_o.gif'></div>");
        }

        if (User.IsInRole(ROLE_ESTADMIN) || User.IsInRole(ROLE_ADMIN))
        {
            if (DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("EST_EMP_ID").Value) == gUserInfo.Emp_Ref_ID)
            {
                e.Row.Cells.FromKey("SELECT").Text = string.Format(@"<a href='EST110204_01.aspx?USERTYPE={0}&COMP_ID={1}&ESTTERM_REF_ID={2}&ESTTERM_SUB_ID={3}&ESTTERM_STEP_ID={4}&EST_EMP_ID={5}&EST_DEPT_ID={6}&TGT_EMP_ID={7}&TGT_DEPT_ID={8}'><div class='stext' style='cursor: pointer;'><img src='../images/btn/b_143.gif'></div></a>"
                                                                    , 1
                                                                    , ICOMP_ID
                                                                    , IESTTERM_REF_ID
                                                                    , IESTTERM_SUB_ID
                                                                    , e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString());
            }
            else if (DataTypeUtility.GetToInt32(e.Row.Cells.FromKey("TGT_EMP_ID").Value) == gUserInfo.Emp_Ref_ID)
            {
                e.Row.Cells.FromKey("SELECT").Text = string.Format(@"<a href='EST110204_01.aspx?USERTYPE={0}&COMP_ID={1}&ESTTERM_REF_ID={2}&ESTTERM_SUB_ID={3}&ESTTERM_STEP_ID={4}&EST_EMP_ID={5}&EST_DEPT_ID={6}&TGT_EMP_ID={7}&TGT_DEPT_ID={8}'><div class='stext' style='cursor: pointer;'><img src='../images/btn/b_143.gif'></div></a>"
                                                                    , 2
                                                                    , ICOMP_ID
                                                                    , IESTTERM_REF_ID
                                                                    , IESTTERM_SUB_ID
                                                                    , e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString());
            }
            else
            {
                e.Row.Cells.FromKey("SELECT").Text = string.Format(@"<a href='EST110204_01.aspx?USERTYPE={0}&COMP_ID={1}&ESTTERM_REF_ID={2}&ESTTERM_SUB_ID={3}&ESTTERM_STEP_ID={4}&EST_EMP_ID={5}&EST_DEPT_ID={6}&TGT_EMP_ID={7}&TGT_DEPT_ID={8}'><div class='stext' style='cursor: pointer;'><img src='../images/btn/b_143.gif'></div></a>"
                                                                    , 0
                                                                    , ICOMP_ID
                                                                    , IESTTERM_REF_ID
                                                                    , IESTTERM_SUB_ID
                                                                    , e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString());
            }
        }
        else
        {
            if (IUSERTYPE == 1)
            {
                e.Row.Cells.FromKey("SELECT").Text = string.Format(@"<a href='EST110204_01.aspx?USERTYPE={0}&COMP_ID={1}&ESTTERM_REF_ID={2}&ESTTERM_SUB_ID={3}&ESTTERM_STEP_ID={4}&EST_EMP_ID={5}&EST_DEPT_ID={6}&TGT_EMP_ID={7}&TGT_DEPT_ID={8}'><div class='stext' style='cursor: pointer;'><img src='../images/btn/b_143.gif'></div></a>"
                                                                    , IUSERTYPE
                                                                    , ICOMP_ID
                                                                    , IESTTERM_REF_ID
                                                                    , IESTTERM_SUB_ID
                                                                    , e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString());
            }
            else
            {
                e.Row.Cells.FromKey("SELECT").Text = string.Format(@"<a href='EST110204_01.aspx?USERTYPE={0}&COMP_ID={1}&ESTTERM_REF_ID={2}&ESTTERM_SUB_ID={3}&ESTTERM_STEP_ID={4}&EST_EMP_ID={5}&EST_DEPT_ID={6}&TGT_EMP_ID={7}&TGT_DEPT_ID={8}'><div class='stext' style='cursor: pointer;'><img src='../images/btn/b_143.gif'></div></a>"
                                                                    , IUSERTYPE
                                                                    , ICOMP_ID
                                                                    , IESTTERM_REF_ID
                                                                    , IESTTERM_SUB_ID
                                                                    , e.Row.Cells.FromKey("ESTTERM_STEP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("EST_DEPT_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_EMP_ID").Value.ToString()
                                                                    , e.Row.Cells.FromKey("TGT_DEPT_ID").Value.ToString());
            }
        }
    }
}
