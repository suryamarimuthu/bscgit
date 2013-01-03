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
using MicroBSC.Estimation.Dac;
using MicroBSC.Biz.Common;
using MicroBSC.RolesBasedAthentication;
using MicroBSC.Data;
using MicroBSC.Common;
using Infragistics.WebUI.UltraWebGrid;

public partial class ctl_ctl4400 : AppPageBase
{

    // Control for Call Back
    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_','$'));
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
        if (!Page.IsPostBack) 
        {
            DataBindingUnitType();
        }

        ltrScript.Text = "";

        //// 체크인-체크아웃 활성화
        //MenuControl2.IsCheckInOutVisible = true;
        //MenuControl2.SetCheckInOutBuuton(pnlUnit, pnlUnitType);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            iBtnUnitTypeRemove.Attributes.Add("onclick", "return confirm('정말 삭제하시겠습니까? 기존에 존재하는 모든 데이터는 삭제됩니다.')");
            iBtnUnitRemove.Attributes.Add("onclick", "return confirm('정말 삭제하시겠습니까? 기존에 존재하는 모든 데이터는 삭제됩니다.')");
        }
    }

    private void DataBindingUnitType() 
    {
        UnitTypeInfos unitInfo      = new UnitTypeInfos();
        DataSet ds                  = unitInfo.GetUnitTypeGroup();

        UltraWebGrid1.DataSource    = ds;
        UltraWebGrid1.DataBind();
    }
    
    private void DataBindingUnit(string unit_type)
    {
        UnitTypeInfos unitInfo      = new UnitTypeInfos(unit_type);
        DataSet ds                  = unitInfo.GetAllUnitTypeInfo(unit_type);
        
        UltraWebGrid2.DataSource    = ds;
        UltraWebGrid2.DataBind();
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;
    }
    
    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
    
        if (e.SelectedRows[0] != null)
        {
            string unit_type    = e.SelectedRows[0].Cells.FromKey("UNIT_TYPE").Value.ToString();
            
            DataBindingUnit(unit_type);
            
            hdfUnitGroup.Value  = unit_type;
            pnlUnit.Visible     = true;
            pnlUnitType.Visible = true;
            txtUnitGroup.Text   = unit_type;
            hdfUnitGroup.Value  = unit_type;
            ltrEmpAdd.Text      = string.Format("<a href='#null' onclick=\"gfOpenWindow('ctl4401.aspx?MODE=NEW&CCB1="+this.ICCB1+"', 500, 250);\"><IMG src='../images/btn/b_156.gif' /></a>");
        }
    }
    
    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Data;

        //if (pnlUnit.Visible)
            e.Row.Cells.FromKey("MODIFY").Value = string.Format(
                            "<a href=\"#null\" onclick=\"gfOpenWindow('ctl4401.aspx?MODE=MODIFY&UNIT_ID=" + dr["UNIT_TYPE_REF_ID"].ToString() + "&CCB1="+this.ICCB1+"', 500, 250);\"><img src='../images/drafts.gif' border='0'></a>");
        //else
        //    e.Row.Band.Columns.FromKey("MODIFY").Hidden = true;

        UltraGridRow row    = e.Row;
        TemplatedColumn col = (TemplatedColumn)row.Band.Columns.FromKey("USE_YN");
        CheckBox chk        = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("useBox");
        chk.Enabled         = false;

        if (dr["USE_YN"].ToString().Equals("Y"))
        {
            chk.Checked = true;
        }
    }
   
    protected void iBtnUnitTypeRemove_Click(object sender, ImageClickEventArgs e)
    {
        UnitTypeInfos unitInfo = new UnitTypeInfos();

        CheckBox chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        string unit_type;

        for (int i = 0; i < this.UltraWebGrid1.Rows.Count; i++)
        {
            row = UltraWebGrid1.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    unit_type   = row.Cells.FromKey("UNIT_TYPE").Value.ToString();
                    isOK        = unitInfo.RemoveUnitTypeGroup(unit_type);
                }
                catch (Exception ex)
                {
                    ltrScript.Text = JSHelper.GetAlertScript("삭제 중 오류가 발생하였습니다.", false);
                    return;
                }
            }
        }

        if (!isOK)
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 Unit그룹 항목을 선택주세요.", false);
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제되었습니다", false);
            Reload();
        }
    }
    
    protected void iBtnUnitTypeModify_Click(object sender, ImageClickEventArgs e)
    {
        UnitTypeInfos unitInfo = new UnitTypeInfos();
        bool isOk = false;

        try
        {
            isOk = unitInfo.ModifyUnitTypeGroup(txtUnitGroup.Text, hdfUnitGroup.Value);
        }
        catch(Exception ex)
        {
            ltrScript.Text = JSHelper.GetAlertScript("수정 중 오류가 발생하였습니다.", false);
            return;
        }

        if (isOk)
        {
            ltrScript.Text = JSHelper.GetAlertScript("수정이 완료되었습니다", false);
            Reload();
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("수정할 Unit그룹을 선택해주세요", false);
        }
    }
    
    protected void iBtnUnitRemove_Click(object sender, ImageClickEventArgs e)
    {
        UnitTypeInfos unitInfo = new UnitTypeInfos();

        CheckBox  chk;
        UltraGridRow row;
        TemplatedColumn col;
        bool isOK = false;
        string unit;
        string unit_id;

        for (int i = 0; i < this.UltraWebGrid2.Rows.Count; i++)
        {
            row = UltraWebGrid2.Rows[i];
            col = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            chk = (CheckBox)((CellItem)col.CellItems[row.BandIndex]).FindControl("cBox");

            if (chk.Checked)
            {
                try
                {
                    unit    = row.Cells.FromKey("UNIT").Value.ToString();
                    unit_id = row.Cells.FromKey("UNIT_TYPE_REF_ID").Value.ToString();
                    isOK    = unitInfo.RemoveUnitTypeInfo(Convert.ToInt32(unit_id), unit);
                }
                catch (Exception ex)
                {
                    ltrScript.Text = JSHelper.GetAlertScript("삭제 중 오류가 발생하였습니다.", false);
                    return;
                }
            }
        }

        if (!isOK)
            ltrScript.Text = JSHelper.GetAlertScript("삭제할 Unit 항목을 선택주세요.", false);
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("삭제되었습니다", false);
            Reload();
        }
    }
    
    private void Reload()
    {
        UltraWebGrid1.Clear();
        UltraWebGrid2.Clear();
        DataBindingUnitType();
        DataBindingUnit(hdfUnitGroup.Value);
        txtUnitGroup.Text = "";
    }
    
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        DataBindingUnitType();
        DataBindingUnit(hdfUnitGroup.Value);
    }
}
