using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class ctl_ctl1800 : AppPageBase
{
    private EmpSysInfos_Biz empSysInfo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataBindingGrid();
        }

        ltrScript.Text = "";
    }

    private void DataBindingGrid() 
    {
        empSysInfo              = new EmpSysInfos_Biz(gUserInfo.Emp_Ref_ID);
        GridView1.DataSource    = empSysInfo.GetEmpSysCategory();
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drw         = (DataRowView)e.Row.DataItem;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gView_Sub      = e.Row.Cells[1].FindControl("gView_Sub") as GridView;
            DataSet ds              = empSysInfo.GetEmpSysInfoByCategory(Convert.ToInt32(drw["SYS_CATEGORY"]));
            gView_Sub.DataSource    = ds;
            gView_Sub.DataBind();
        }

        //(int)drw["SYS_CATEGORY"]
    }
    protected void gView_Sub_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drw     = (DataRowView)e.Row.DataItem;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ctrl_type                = drw["SYS_CTRL_TYPE"].ToString();

            RadioButtonList rBtnColSys_Sub  = e.Row.Cells[2].FindControl("rBtnColSys_Sub") as RadioButtonList;
            DropDownList ddlColSys_Sub      = e.Row.Cells[2].FindControl("ddlColSys_Sub") as DropDownList;
            Literal ltrSysKey_Sub           = e.Row.Cells[2].FindControl("ltrSysKey_Sub") as Literal;
            Literal ltrSysCtrlType_Sub      = e.Row.Cells[2].FindControl("ltrSysCtrlType_Sub") as Literal;

            //DataTable dt                = empSysInfo.GetSysDataSource(drw["SYS_CTRL_KEY_COL"].ToString()
            //                                                        , drw["SYS_CTRL_VALUE_COL"].ToString());

            DataTable dt = empSysInfo.GetSysDataSource(drw["SYS_CTRL_KEY_COL"].ToString()
                                                                 , drw[7].ToString());


            if (ctrl_type.Equals("RADIO_BUTTON")) 
            {
                rBtnColSys_Sub.DataSource       = dt;
                rBtnColSys_Sub.DataBind();

                ltrSysKey_Sub.Text          = drw["SYS_KEY"].ToString();
                ltrSysCtrlType_Sub.Text     = drw["SYS_CTRL_TYPE"].ToString();
                
                string sys_value            = empSysInfo.GetSysValueByEmpID(Convert.ToInt32(drw["SYS_KEY"]));
                rBtnColSys_Sub.Items.FindByValue(sys_value).Selected = true;

                ltrSysKey_Sub.Visible       = false;
                ltrSysCtrlType_Sub.Visible  = false;
                ddlColSys_Sub.Visible       = false;
            }
            else if (ctrl_type.Equals("DROPDOWNLIST"))
            {
                ddlColSys_Sub.DataSource    = dt;
                ddlColSys_Sub.DataBind();

                ltrSysKey_Sub.Text          = drw["SYS_KEY"].ToString();
                ltrSysCtrlType_Sub.Text     = drw["SYS_CTRL_TYPE"].ToString();

                string sys_value = empSysInfo.GetSysValueByEmpID((int)drw["SYS_KEY"]);
                ddlColSys_Sub.Items.FindByValue(sys_value).Selected = true;

                ltrSysKey_Sub.Visible       = false;
                ltrSysCtrlType_Sub.Visible  = false;
                rBtnColSys_Sub.Visible      = false;
            }
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        GridViewRow gridRow             = null;
        GridView grid_sub               = null;
        GridViewRow grid_sub_Row        = null;

        RadioButtonList rBtnColSys_Sub  = null;
        DropDownList ddlColSys_Sub      = null;
        Literal ltrSysKey_Sub           = null;
        Literal ltrSysCtrlType_Sub      = null;

        empSysInfo = new EmpSysInfos_Biz(gUserInfo.Emp_Ref_ID);

        IDbConnection conn = DbAgentHelper.CreateDbConnection();
        conn.Open();
        IDbTransaction trx = conn.BeginTransaction();

        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                gridRow     = GridView1.Rows[i];
                grid_sub    = gridRow.Cells[1].FindControl("gView_Sub") as GridView;

                for (int k = 0; k < grid_sub.Rows.Count; k++)
                {
                    grid_sub_Row            = grid_sub.Rows[k];
                    rBtnColSys_Sub          = grid_sub_Row.Cells[2].FindControl("rBtnColSys_Sub") as RadioButtonList;
                    ddlColSys_Sub           = grid_sub_Row.Cells[2].FindControl("ddlColSys_Sub") as DropDownList;
                    ltrSysKey_Sub           = grid_sub_Row.Cells[2].FindControl("ltrSysKey_Sub") as Literal;
                    ltrSysCtrlType_Sub      = grid_sub_Row.Cells[2].FindControl("ltrSysCtrlType_Sub") as Literal;

                    if (ltrSysCtrlType_Sub.Text.Equals("RADIO_BUTTON")) 
                    {
                        empSysInfo.SetEmpSysDetailUpdate(Convert.ToInt32(ltrSysKey_Sub.Text), rBtnColSys_Sub.SelectedValue);
                        empSysInfo.SetEmpSysDetail(conn, trx, int.Parse(ltrSysKey_Sub.Text), rBtnColSys_Sub.SelectedValue);
                    }
                    else if (ltrSysCtrlType_Sub.Text.Equals("DROPDOWNLIST"))
                    {
                        empSysInfo.SetEmpSysDetailUpdate(Convert.ToInt32(ltrSysKey_Sub.Text), rBtnColSys_Sub.SelectedValue);
                        empSysInfo.SetEmpSysDetail(conn, trx, int.Parse(ltrSysKey_Sub.Text), ddlColSys_Sub.SelectedValue);
                    }
                }
            }

            trx.Commit();
        }
        catch (SqlException ex)
        {
            trx.Rollback();
            conn.Close();
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.", false);
            return;
        }
        finally
        {
            conn.Close();
        }

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 설정되었습니다.", false);

        DataBindingGrid();
    }
}
