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

public partial class EST_EST060700 : EstPageBase
{
    private string EST_ID;
    private DataTable DT_TGT_OPINION;
    private int ROLE_REF_ID = 10;

    protected void Page_Init(object sender, EventArgs e)
    {
        SetPageLayout(phdLayout, phdBottom);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownListCommom.BindComp(ddlCompID, lblCompTitle);

            ibnSave.Attributes.Add("onclick", "return confirm('의견상신 담당자를 저장하시겠습니까?');");
            ibnUpdateEmpRole.Attributes.Add("onclick", "return confirm('현재 세팅된 의견상신 담당자에게 의견상신 권한을 모두 부여하시겠습니까?');");
        }

        COMP_ID         = WebUtility.GetIntByValueDropDownList(ddlCompID);
        EST_ID          = hdfSearchEstID.Value;

        ltrScript.Text  = "";
    }

    private bool CheckValidation(Literal ltrMsg) 
    {
        Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, EST_ID);
        OwnerType ownerType     = BizUtility.GetEnumByOwnerType(estInfo.Owner_Type);

        if(ownerType != OwnerType.Dept)
        {
            ltrMsg.Text = JSHelper.GetAlertScript("현재 평가는 부서평가가 아니기 때문에 의견상신 담당자를 선택할 수 없습니다.");
            return false;
        }

        if(estInfo.Tgt_Opinion_YN.Equals("N"))
        {
            ltrMsg.Text = JSHelper.GetAlertScript("현재 평가는 의견상신을 하지 않는 평가입니다.");
            return false;
        }

        if(!estInfo.Status_Style_ID.Equals("0002"))
        {
            ltrMsg.Text = JSHelper.GetAlertScript("현재 평가는 5단계(의견상신)이 아닙니다.");
            return false;
        }

        return true;
    }

    protected void ddlCompID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        bool isOK = CheckValidation(ltrScript);

        if(!isOK)
            return;

        BindingGrid(COMP_ID, EST_ID);

        ibnSave.Visible             = true;
        ibnUpdateEmpRole.Visible    = true;
    }

    private void BindingGrid(int comp_id, string est_id) 
    {
        Biz_DeptOpinionTgtEmps deptOpinionTgtEmp    = new Biz_DeptOpinionTgtEmps();
        DT_TGT_OPINION                              = deptOpinionTgtEmp.GetDeptOpinionTgtEmp(COMP_ID, est_id).Tables[0];

        DataTable dataTable                 = BizUtility.GetDeptTree("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        UltraWebGrid1.DataSource            = dataTable;
        UltraWebGrid1.DataBind();

        lblRowCount.Text                    = dataTable.Rows.Count.ToString();
    }

    protected void UltraWebGrid1_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw             = (DataRowView) e.Data;

        TemplatedColumn hdf_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("CTRL_EMP");
        HiddenField hdfTgtEmpID     = (HiddenField)((CellItem)hdf_col.CellItems[e.Row.BandIndex]).FindControl("hdfTgtEmpID");

        TemplatedColumn txt_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("CTRL_EMP");
        TextBox txtTgtEmpName       = (TextBox)((CellItem)txt_col.CellItems[e.Row.BandIndex]).FindControl("txtTgtEmpName");

        TemplatedColumn ltr_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("CTRL_EMP");
        Literal ltrImage            = (Literal)((CellItem)ltr_col.CellItems[e.Row.BandIndex]).FindControl("ltrImage");

        DataRow[] drArr             = DT_TGT_OPINION.Select(string.Format(@"TGT_DEPT_ID = {0}", drw["DEPT_REF_ID"]));

        ltrImage.Text               = string.Format(string.Format("<a href='#null' onclick=\"SelectEmp('{0}', '{1}', '{2}');\"><img align='absMiddle' border='0' src='../images/btn/b_008.gif' /></a>"
                                                    , hdfTgtEmpID.ClientID
                                                    , txtTgtEmpName.ClientID
                                                    , drw["DEPT_REF_ID"]));

        e.Row.Cells.FromKey("TGT_DEPT_ID").Value    = drw["DEPT_REF_ID"];

        if (drArr.Length > 0)
        {
            hdfTgtEmpID.Value   = DataTypeUtility.GetValue(drArr[0]["TGT_EMP_ID"]);
            txtTgtEmpName.Text  = DataTypeUtility.GetValue(drArr[0]["TGT_EMP_NAME"]);
        }
        else 
        {
            
        }
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        UltraGridRow row;

        Biz_DeptOpinionTgtEmps deptOpinionTgtEmp    = new Biz_DeptOpinionTgtEmps();
        DataTable dataTable                         = deptOpinionTgtEmp.GetDataTableSchema();

        for ( int i = 0; i < UltraWebGrid1.Rows.Count; i++ )
        {
            row                         = UltraWebGrid1.Rows[i];
            TemplatedColumn hdf_col     = (TemplatedColumn)row.Band.Columns.FromKey("CTRL_EMP");
            HiddenField hdfTgtEmpID     = (HiddenField)((CellItem)hdf_col.CellItems[row.BandIndex]).FindControl("hdfTgtEmpID");

            TemplatedColumn txt_col     = (TemplatedColumn)row.Band.Columns.FromKey("CTRL_EMP");
            TextBox txtTgtEmpName       = (TextBox)((CellItem)txt_col.CellItems[row.BandIndex]).FindControl("txtTgtEmpName");

            if(hdfTgtEmpID.Value.Equals(""))
                row.Cells.FromKey("TGT_EMP_ID").Value = DBNull.Value;
            else
                row.Cells.FromKey("TGT_EMP_ID").Value = DataTypeUtility.GetToDouble(hdfTgtEmpID.Value);
        }

        dataTable = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid1
                                                            , new string[] {"TGT_DEPT_ID", "TGT_EMP_ID"}
                                                            , dataTable);

        dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "TGT_EMP_ID IS NOT NULL");

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["TGT_OPINION_YN"]   = "Y";
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = deptOpinionTgtEmp.SaveDeptOpinionTgtEmp(dataTable, COMP_ID, EST_ID);

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 의견상신 담당자를 설정하였습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }

    protected void ibnUpdateEmpRole_Click(object sender, ImageClickEventArgs e)
    {
        UltraGridRow row;

        Biz_EmpRoleRels empRoleRel                  = new Biz_EmpRoleRels();
        Biz_DeptOpinionTgtEmps deptOpinionTgtEmp    = new Biz_DeptOpinionTgtEmps();
        DataTable dataTable                         = deptOpinionTgtEmp.GetDataTableSchema();

        dataTable.Columns.Add("EMP_REF_ID", typeof(int));
        dataTable.Columns.Add("ROLE_REF_ID", typeof(int));

        for ( int i = 0; i < UltraWebGrid1.Rows.Count; i++ )
        {
            row                         = UltraWebGrid1.Rows[i];
            TemplatedColumn hdf_col     = (TemplatedColumn)row.Band.Columns.FromKey("CTRL_EMP");
            HiddenField hdfTgtEmpID     = (HiddenField)((CellItem)hdf_col.CellItems[row.BandIndex]).FindControl("hdfTgtEmpID");

            if(hdfTgtEmpID.Value.Equals(""))
                row.Cells.FromKey("TGT_EMP_ID").Value = DBNull.Value;
            else
                row.Cells.FromKey("TGT_EMP_ID").Value = DataTypeUtility.GetToDouble(hdfTgtEmpID.Value);
        }

        dataTable = UltraGridUtility.GetDataTableByAllValue(UltraWebGrid1
                                                            , new string[] {"TGT_EMP_ID"}
                                                            , dataTable);

        dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "TGT_EMP_ID IS NOT NULL");

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["EMP_REF_ID"]   = dataRow["TGT_EMP_ID"];
            dataRow["ROLE_REF_ID"]  = ROLE_REF_ID;
        }

        bool isOK = empRoleRel.SaveEmpRoleRel(dataTable, ROLE_REF_ID);

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 의견상신 담당자 권한을 부여하였습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("부여된 권한이 없습니다.");
        }
    }
}