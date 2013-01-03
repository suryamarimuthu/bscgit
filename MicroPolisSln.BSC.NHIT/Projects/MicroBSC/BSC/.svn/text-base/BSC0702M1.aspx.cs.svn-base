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

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Dac;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0702M1 : AppPageBase
{
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "U");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    protected DataTable UserDataTable 
    {
        get 
        {
            if (ViewState["USER_DATATABLE"] == null) 
                return CreateUserTable();

            return (DataTable)ViewState["USER_DATATABLE"];
        }
        set 
        {
            ViewState["USER_DATATABLE"] = value;
        }
    }

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

    private void SetInitForm()
    {
        WebCommon.FillComDeptTree(trvComDept);
        if (this.IType == "A")
        {
            //return CreateUserTable();
        }
        else if (this.IType == "U")
        {

            ugrdTargetUser.DataSource = ModifyUserTable(GetRequest("RECEIVER_ARR"));
            ugrdTargetUser.DataBind();
        }
        else 
        {
            //return CreateUserTable();
        }
    }

    protected void trvComDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        string deptId               = trvComDept.SelectedNode.Value;

        EmpInfos emp                = new EmpInfos();
        DataSet ds                  = emp.GetEmpInfoByDeptID(deptId);

        ugrdSelectedUser.DataSource    = ds;
        ugrdSelectedUser.DataBind();

        lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
    }

    protected void ugrdSelectedUser_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;
    }

    protected void iBtnConfirm_Click(object sender, ImageClickEventArgs e)
    { 
        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;
        bool isOK           = false;
        string isSuccessed  = "0";

        bool isFirst = true;

        string emp_ref_id_arr   = "";

        for (int i = 0; i < ugrdTargetUser.Rows.Count; i++)
        {
            row = ugrdTargetUser.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (isFirst)
            {
                isFirst = false;
            }
            else
            {
                emp_ref_id_arr += ";";
            }

            emp_ref_id_arr += string.Format("{0}({1})"
                                    , row.Cells.FromKey("EMP_REF_ID").Value.ToString()
                                    , row.Cells.FromKey("EMP_NAME").Value.ToString());
        }

        ltrScript.Text = JSHelper.GetBlankScript(string.Format("opener.document.getElementById('txtReceiver').value = '{0}';opener.document.getElementById('hdfReceiver').value = '{0}';window.close();", emp_ref_id_arr));
    }

    protected DataTable CreateUserTable() 
    {
        DataTable dataTable = new DataTable();

        dataTable.Columns.Add("EMP_REF_ID", typeof(int));
        dataTable.Columns.Add("LOGINID", typeof(string));
        dataTable.Columns.Add("EMP_NAME", typeof(string));
        dataTable.Columns.Add("EMP_EMAIL", typeof(string));
        dataTable.Columns.Add("POSITION_CLASS_NAME", typeof(string));
        dataTable.Columns.Add("POSITION_GRP_NAME", typeof(string));
        dataTable.Columns.Add("POSITION_RANK_NAME", typeof(string));
        dataTable.Columns.Add("POSITION_DUTY_NAME", typeof(string));

        return dataTable;
    }

    protected DataTable ModifyUserTable(string receiver_arr)
    {
        EmpInfos emp        = new EmpInfos();
        DataTable dataTable = emp.GetEmpInfoByEmpIDArr(receiver_arr).Tables[0];
        UserDataTable       = dataTable;

        return dataTable;
    }

    protected DataTable AddUserTable()
    {
        DataTable dataTable = UserDataTable;

        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;
        bool isOK           = false;
        string isSuccessed  = "0";

        DataRow dr = null;

        for (int i = 0; i < ugrdSelectedUser.Rows.Count; i++)
        {
            row = ugrdSelectedUser.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                chk.Checked = false;

                if (UserDataTable.Select("EMP_REF_ID=" + row.Cells.FromKey("EMP_REF_ID").Value.ToString()).Length > 0)
                    continue;

                dr = dataTable.NewRow();

                dr["EMP_REF_ID"]            = int.Parse(row.Cells.FromKey("EMP_REF_ID").Value.ToString());
                dr["LOGINID"]               = row.Cells.FromKey("LOGINID").Value.ToString();
                dr["EMP_NAME"]              = (row.Cells.FromKey("EMP_NAME").Value == null) ? "" : row.Cells.FromKey("EMP_NAME").Value.ToString();
                dr["EMP_EMAIL"]             = (row.Cells.FromKey("EMP_EMAIL").Value == null) ? "" : row.Cells.FromKey("EMP_EMAIL").Value.ToString();
                dr["POSITION_CLASS_NAME"]   = (row.Cells.FromKey("POSITION_CLASS_NAME").Value == null) ? "" : row.Cells.FromKey("POSITION_CLASS_NAME").Value.ToString();
                dr["POSITION_GRP_NAME"]     = (row.Cells.FromKey("POSITION_GRP_NAME").Value == null) ? "" : row.Cells.FromKey("POSITION_GRP_NAME").Value.ToString();
                dr["POSITION_RANK_NAME"]    = (row.Cells.FromKey("POSITION_RANK_NAME").Value == null) ? "" : row.Cells.FromKey("POSITION_RANK_NAME").Value.ToString();
                dr["POSITION_DUTY_NAME"]    = (row.Cells.FromKey("POSITION_DUTY_NAME").Value == null) ? "" : row.Cells.FromKey("POSITION_DUTY_NAME").Value.ToString();

                dataTable.Rows.Add(dr);
            }
        }

        UserDataTable = dataTable;

        return dataTable;
    }

    protected DataTable RemoveUserTable()
    {
        DataTable dataTable = UserDataTable;

        CheckBox            chk;
        UltraGridRow        row;
        TemplatedColumn     col;
        bool isOK           = false;
        string isSuccessed  = "0";

        DataRow[] drArr     = null;

        for (int i = 0; i < ugrdTargetUser.Rows.Count; i++)
        {
            row = ugrdTargetUser.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                drArr = UserDataTable.Select("EMP_REF_ID=" + row.Cells.FromKey("EMP_REF_ID").Value.ToString());

                for (int j = 0; j < drArr.Length; j++) 
                {
                    drArr[j].Delete();
                }
            }
        }

        return UserDataTable;
    }
    protected void iBtnRemoveEmp_Click(object sender, ImageClickEventArgs e)
    {
        ugrdSelectedUser.DataSource = RemoveUserTable();
        ugrdSelectedUser.DataBind();
    }
    protected void iBtnAddEmp_Click(object sender, ImageClickEventArgs e)
    {
        ugrdTargetUser.DataSource = AddUserTable();
        ugrdTargetUser.DataBind();
    }
}
