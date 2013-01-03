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
using System.Transactions;

using MicroBSC.Common;
using MicroBSC.Biz.Common;
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;

public partial class EST_EST020400 : EstPageBase
{
    private DataTable _dtButtonCommandRole = null;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindingRole();

            ibnSave.Attributes.Add("onclick", "return confirm('권한별 버튼 설정을 저장하시겠습니까?');");
        }

        ltrScript.Text  = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {

    }

    private void BindingRole() 
    {
        Biz_RoleInfos roleInfo   = new Biz_RoleInfos();
        UltraWebGrid1.DataSource = roleInfo.GetRoleInfos();
        UltraWebGrid1.DataBind();
    }

    private void BindingCommandNameRoleMap(int role_ref_id) 
    {
        Biz_ButtonCommandRoleMaps btnCmdRoleMap = new Biz_ButtonCommandRoleMaps();
        _dtButtonCommandRole                    = btnCmdRoleMap.GetButtonCommandRoleMap(role_ref_id, "").Tables[0];

        Biz_ButtonCommandInfos btnCmdInfo       = new Biz_ButtonCommandInfos();
        UltraWebGrid2.DataSource                = btnCmdInfo.GetButtonCommandInfos();
        UltraWebGrid2.DataBind();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

    }

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        string command_name = dr["COMMAND_NAME"].ToString();

        if(_dtButtonCommandRole.Select(string.Format("COMMAND_NAME = '{0}'", command_name)).Length > 0)
        {
            TemplatedColumn ckbBtnCmdMap	= (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
		    CheckBox cBox		            = (CheckBox)((CellItem)ckbBtnCmdMap.CellItems[e.Row.BandIndex]).FindControl("cBox");
            cBox.Checked                    = true;
        }
    }
   
    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if (e.SelectedRows[0] != null)
        {
            int role_ref_id     = DataTypeUtility.GetToInt32(e.SelectedRows[0].Cells.FromKey("ROLE_REF_ID").Value);
            hdfRoleRefID.Value  = role_ref_id.ToString();
            BindingCommandNameRoleMap(role_ref_id);
        }
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_ButtonCommandRoleMaps btnCmdRoleMap = new Biz_ButtonCommandRoleMaps();
        DataTable dataTable                     = btnCmdRoleMap.GetDataTableSchema();

        dataTable                               = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid2
                                                                                        , "cBox"
                                                                                        , "selchk"
                                                                                        , new string[] { "COMMAND_NAME" }
                                                                                        , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["ROLE_REF_ID"]  = hdfRoleRefID.Value;
            dataRow["DATE"]         = DateTime.Now;
            dataRow["USER"]         = EMP_REF_ID;
        }

        bool isOK = btnCmdRoleMap.SaveButtonCommandRoleMap(dataTable, DataTypeUtility.GetToInt32(hdfRoleRefID.Value));

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 저장되었습니다.", false);

        //if (isOK)
        //{
        //    ltrScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        //    return;
        //}
        //else
        //{
        //    //ltrScript.Text = JSHelper.GetAlertScript("삭제할 항목을 선택주세요.", false);
        //}
    }
}