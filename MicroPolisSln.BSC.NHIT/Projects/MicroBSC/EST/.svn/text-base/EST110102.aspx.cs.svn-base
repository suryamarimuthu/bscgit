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

public partial class EST_EST110102 : EstPageBase
{
    private string EST_ID;
    private DataTable DT_EST_DATA;
    private string YEAR_YN;
    private string MERGE_YN;

    public bool AllowUpdate 
    {
        get
        {
            if(ViewState["ALLOW_UPDATE"] == null)
                return false;

            return (bool)ViewState["ALLOW_UPDATE"];
        }
        set
        {
            ViewState["ALLOW_UPDATE"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        EST_ID          = GetRequest("EST_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = GetRequestByInt("ESTTERM_STEP_ID");
        EST_JOB_ID      = "JOB_31";
        YEAR_YN         = GetRequest("YEAR_YN");
        MERGE_YN        = GetRequest("MERGE_YN");
        
        if (!Page.IsPostBack)
        {
            bool isOK = CheckValidation(ltrScript);

            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnAllowUpdate);
            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnConfirmAssingEmpPoint);

            if(!isOK)
            {
                return;
            }

            TreeViewCommom.BindDept(TreeView1);

            ibnAllowUpdate.Attributes.Add("onclick", "return confirm('기존 사원평가점수를 수정할 수 있도록 페이지를 조정하시겠습니까?');");
            ibnSave.Attributes.Add("onclick", "return confirm('사원평가점수를 수기로 등록하시겠습니까?');");
            ibnConfirmAssingEmpPoint.Attributes.Add("onclick", "return confirm('사원평가점수를 수기 등록 작업을 확정하시겠습니까?');");
        }

        ltrScript.Text = "";
    }

    private void BindingGrid(int comp_id
                        , string est_id
                        , int estterm_ref_id
                        , int estterm_sub_id
                        , int dept_ref_id) 
    {
        if(dept_ref_id == 0)
            return;

        Biz_Datas data                      = new Biz_Datas();
        DT_EST_DATA                         = data.GetData(COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , ESTTERM_SUB_ID
                                                            , ESTTERM_STEP_ID
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , 0
                                                            , YEAR_YN
                                                            , MERGE_YN
                                                            , OwnerType.Emp_User).Tables[0];
                                                            
        Biz_EmpInfos empInfo = new Biz_EmpInfos();

        DataSet ds                  = empInfo.GetEmpByEstDeptID(dept_ref_id);
        UltraWebGrid1.DataSource    = ds;
        UltraWebGrid1.DataBind();

        lblTotal.Text               = ds.Tables[0].Rows.Count.ToString();
    }

    private bool CheckValidation(Literal ltrMsg) 
    {
        Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, EST_ID);
        OwnerType ownerType     = BizUtility.GetEnumByOwnerType(estInfo.Owner_Type);

        if(ownerType != OwnerType.Emp_User)
        {
            ltrMsg.Text = JSHelper.GetAlertScript("현재 평가는 사원평가가 아니기 때문에 사원평가점수 수기 할당이 불가능 합니다.", true);
            return false;
        }

        return true;
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        BindingGrid(  COMP_ID
                    , EST_ID
                    , ESTTERM_REF_ID
                    , ESTTERM_SUB_ID
                    , DataTypeUtility.GetToInt32(TreeView1.SelectedValue));
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw  = (DataRowView)e.Data;

        TemplatedColumn ckb_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        CheckBox ckbSelect          = (CheckBox)((CellItem)ckb_col.CellItems[e.Row.BandIndex]).FindControl("cBox");

        TemplatedColumn lbl_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("CTRL_POINT");
        Label lblPoint              = (Label)((CellItem)lbl_col.CellItems[e.Row.BandIndex]).FindControl("lblPoint");

        TemplatedColumn txt_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("CTRL_POINT");
        TextBox txtPoint            = (TextBox)((CellItem)txt_col.CellItems[e.Row.BandIndex]).FindControl("txtPoint");

        TextBoxCommon.SetOnlyPercent(txtPoint);

        DataRow[] drArr             = DT_EST_DATA.Select(string.Format(@"TGT_DEPT_ID     = {0}", TreeView1.SelectedValue));

        if (drArr.Length > 0)
        {
            if(AllowUpdate) 
            {
                ckbSelect.Visible       = true;
                lblPoint.Visible        = false;
                txtPoint.Visible        = true;

                ckbSelect.Attributes.Add("onclick", string.Format("enableCheckBox('{0}', '{1}');", ckbSelect.ClientID, txtPoint.ClientID));
                ckbSelect.Checked       = false;
                txtPoint.Enabled        = false;
                txtPoint.Text           = DataTypeUtility.GetToDouble(drArr[0]["POINT"]).ToString();

                e.Row.Cells.FromKey("TGT_EMP_ID").Value = drw["EMP_REF_ID"];
            }
            else 
            {
                ckbSelect.Visible       = false;
                lblPoint.Visible        = true;
                txtPoint.Visible        = false;

                lblPoint.Text           = DataTypeUtility.GetToDouble(drArr[0]["POINT"]).ToString();
            }

            e.Row.Style.BackColor       = Color.FromName("#DBDBDB");
        }
        else 
        {
            ckbSelect.Visible           = true;
            lblPoint.Visible            = false;
            txtPoint.Visible            = true;

            ckbSelect.Attributes.Add("onclick", string.Format("enableCheckBox('{0}', '{1}');", ckbSelect.ClientID, txtPoint.ClientID));
            ckbSelect.Checked           = false;
            txtPoint.Enabled            = false;

            e.Row.Cells.FromKey("TGT_EMP_ID").Value = drw["EMP_REF_ID"];
        }
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }

    protected void ibnConfirmAssingEmpPoint_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibn     = ((ImageButton) sender);

        bool isJobOK        = EstJobUtility.SetConfirmButtonVisible(  COMP_ID
                                                                    , EST_ID
                                                                    , ESTTERM_REF_ID
                                                                    , ESTTERM_SUB_ID
                                                                    , ESTTERM_STEP_ID
                                                                    , EST_JOB_ID
                                                                    , ibn
                                                                    , null
                                                                    , "Y"
                                                                    , DateTime.Now
                                                                    , EMP_REF_ID
                                                                    , ltrScript);

        if(isJobOK)
            ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 사원평가점수를 수기 작업을 확정하였습니다.", "lbnReload", true);
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        UltraGridRow row;

        Biz_Datas data              = new Biz_Datas();
        DataTable dataTable         = data.GetDataTableSchema();

        for ( int i = 0; i < UltraWebGrid1.Rows.Count; i++ )
        {
            row                         = UltraWebGrid1.Rows[i];
            TemplatedColumn ckb_col     = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
            CheckBox ckbSelect          = (CheckBox)((CellItem)ckb_col.CellItems[row.BandIndex]).FindControl("cBox");

            TemplatedColumn txt_col     = (TemplatedColumn)row.Band.Columns.FromKey("CTRL_POINT");
            TextBox txtPoint            = (TextBox)((CellItem)txt_col.CellItems[row.BandIndex]).FindControl("txtPoint");

            if(ckbSelect.Checked) 
            {
                if(txtPoint.Text.Trim().Equals(""))
                    row.Cells.FromKey("POINT").Value = DBNull.Value;
                else
                    row.Cells.FromKey("POINT").Value = DataTypeUtility.GetToDouble(txtPoint.Text);
            }
        }

        dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] {  "TGT_EMP_ID", "TGT_POS_CLS_ID", "TGT_POS_CLS_NAME", "TGT_POS_DUT_ID", "TGT_POS_DUT_NAME", "TGT_POS_GRP_ID", "TGT_POS_GRP_NAME", "TGT_POS_RNK_ID", "TGT_POS_RNK_NAME", "TGT_POS_KND_ID", "TGT_POS_KND_NAME"
                                                                            , "POINT"}
                                                            , dataTable);

        dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "POINT IS NOT NULL");

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
            dataRow["ESTTERM_STEP_ID"]  = ESTTERM_STEP_ID;
            dataRow["EST_DEPT_ID"]      = BizUtility.GetDeptID(EMP_REF_ID);
            dataRow["EST_EMP_ID"]       = EMP_REF_ID;
            dataRow["TGT_DEPT_ID"]      = DataTypeUtility.GetToInt32(TreeView1.SelectedValue);
            dataRow["POINT_ORG"]        = dataRow["POINT"];
            dataRow["POINT_ORG_DATE"]   = DateTime.Now;
            dataRow["POINT_DATE"]        = DateTime.Now;
            dataRow["STATUS_ID"]        = "E";
            dataRow["STATUS_DATE"]      = DateTime.Now;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = data.SaveData(dataTable, AllowUpdate);

        if(isOK) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 사원평가점수를 수기 등록하였습니다.");
            //ltrScript.Text = JSHelper.GetAlertOpenerControlCallBackScript("정상적으로 사원평가점수를 수기 등록하였습니다.", "lbnReload", true);
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }

    protected void ibnAllowUpdate_Click(object sender, ImageClickEventArgs e)
    {
        AllowUpdate = true;

        BindingGrid(  COMP_ID
                    , EST_ID
                    , ESTTERM_REF_ID
                    , ESTTERM_SUB_ID
                    , DataTypeUtility.GetToInt32(TreeView1.SelectedValue));
    }
}
