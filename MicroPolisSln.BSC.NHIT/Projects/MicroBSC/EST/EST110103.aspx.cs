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

public partial class EST_EST110103 : EstPageBase
{
    protected string EST_ID;
    private string YEAR_YN;
    private string MERGE_YN;
    private int TGT_EMP_ID;
    private string TGT_POS_KND_ID;
    private DataTable DT_TGT_EMP_POS_BIZ;
    protected string QUESTION_PAGE_NAME;

    public int EST_EMP_ID 
    {
        get
        {
            if(ViewState["EST_EMP_ID"] == null)
                return EMP_REF_ID;

            return (int)ViewState["EST_EMP_ID"];
        }
        set
        {
            ViewState["EST_EMP_ID"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        EST_ID          = GetRequest("EST_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID = GetRequestByInt("ESTTERM_STEP_ID");
        EST_JOB_ID      = "JOB_32";
        YEAR_YN         = GetRequest("YEAR_YN");
        MERGE_YN        = GetRequest("MERGE_YN");
        
        if (!Page.IsPostBack)
        {
            bool isOK = CheckValidation(ltrScript);

            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnSearchAll);
            BizUtility.SetButtonVisibleCommandNameByRolID(EMP_REF_ID, ibnConfirmAssingPosBiz);

            if(!isOK)
            {
                return;
            }

            EST_EMP_ID = EMP_REF_ID;

            BindingPosBizByTgt();
            BindingTgtEmp(EST_EMP_ID);

            ibnSave.Attributes.Add("onclick", "return confirm('피평가자의 직무를 저장하시겠습니까?');");
            ibnConfirmAssingPosBiz.Attributes.Add("onclick", "return confirm('피평가자의 직무를 확정하시겠습니까?');");
        }

        TGT_EMP_ID = DataTypeUtility.GetToInt32(hdfTgtEmpID.Value);
        TGT_POS_KND_ID = hdfTgtPosKndID.Value;

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e) 
    {
        if(hdfTgtEmpID.Value.Equals(""))
            ibnViewQ.Visible = false;
        else
            ibnViewQ.Visible = true;
    }

    private void BindingTgtEmp(int est_emp_id) 
    {
        Biz_Datas data      = new Biz_Datas();
        DataTable dataTable = data.GetEstData(COMP_ID
                                            , EST_ID
                                            , ESTTERM_REF_ID
                                            , ESTTERM_SUB_ID
                                            , ESTTERM_STEP_ID
                                            , 0
                                            , est_emp_id
                                            , 0
                                            , 0
                                            , YEAR_YN
                                            , MERGE_YN
                                            , OwnerType.Emp_User).Tables[0];


        dataTable = DataTypeUtility.GetGroupByDataTable(  dataTable
                                                        , new string[] {"TGT_EMP_ID", "TGT_EMP_NAME", "TGT_POS_CLS_ID", "TGT_POS_CLS_NAME", "TGT_POS_DUT_ID", "TGT_POS_DUT_NAME", "TGT_POS_GRP_ID", "TGT_POS_GRP_NAME", "TGT_POS_RNK_ID", "TGT_POS_RNK_NAME", "TGT_POS_KND_ID", "TGT_POS_KND_NAME"});

        dataTable = DataTypeUtility.FilterSortDataTable(dataTable, "", "TGT_EMP_NAME");


        UltraWebGrid1.DataSource = dataTable;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = dataTable.Rows.Count.ToString("#,##0");
    }

    private void BindingPosBiz(string pos_knd_id) 
    {
        Biz_PositionKindBizMaps posKndBiz   = new Biz_PositionKindBizMaps();
        DataSet ds                          = posKndBiz.GetPosKndBizMap(pos_knd_id, "");
        
        UltraWebGrid2.DataSource = ds;
        UltraWebGrid2.DataBind();
    }

    private void BindingPosBizByTgt() 
    {
        Biz_EstInfos estInfo                = new Biz_EstInfos(COMP_ID, EST_ID);
        Biz_QuestionPageStyles pageStyle    = new Biz_QuestionPageStyles(estInfo.Q_Style_ID);
        QUESTION_PAGE_NAME                  = pageStyle.Question_Style_Page_Name;

        Biz_EmpPositionBizMaps empPosBizMap = new Biz_EmpPositionBizMaps();
        DT_TGT_EMP_POS_BIZ                  =  empPosBizMap.GetPosBizMap(0).Tables[0];
    }

    private bool CheckValidation(Literal ltrMsg) 
    {
        if(EST_ID.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가정보가 없습니다.");
            return false;
        }

        return true;
    }

    protected void UltraWebGrid1_SelectedRowsChange(object sender, SelectedRowsEventArgs e)
    {
        if(e.SelectedRows.Count > 0) 
        {
            hdfTgtEmpID.Value    = e.SelectedRows[0].Cells.FromKey("TGT_EMP_ID").Value.ToString();
            hdfTgtPosKndID.Value = e.SelectedRows[0].Cells.FromKey("POS_KND_ID").Value.ToString();

            BindingPosBizByTgt();
            BindingPosBiz(hdfTgtPosKndID.Value);
        }
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw  = (DataRowView)e.Data;

        if(DT_TGT_EMP_POS_BIZ != null && DT_TGT_EMP_POS_BIZ.Rows.Count > 0) 
        {
            DataRow[] drArr             = DT_TGT_EMP_POS_BIZ.Select(string.Format(@"EMP_REF_ID = {0}"
                                                                            , drw["TGT_EMP_ID"]));

            if ( drArr.Length > 0 )
            {
                e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i02.gif'>";
            }
            else
            {
                e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i03.gif'>";
            }    
        }
        else
        {
            e.Row.Cells.FromKey("STATUS").Value = "<img src='../images/icon/est_i03.gif'>";
        }
    }

    protected void UltraWebGrid2_InitializeRow(object sender, RowEventArgs e)
    {
        DataRowView drw             = (DataRowView)e.Data;

        TemplatedColumn ckb_col     = (TemplatedColumn)e.Row.Band.Columns.FromKey("selchk");
        CheckBox ckbSelect          = (CheckBox)((CellItem)ckb_col.CellItems[e.Row.BandIndex]).FindControl("cBox");

        if(DT_TGT_EMP_POS_BIZ != null && DT_TGT_EMP_POS_BIZ.Rows.Count > 0) 
        {
            DataRow[] drArr             = DT_TGT_EMP_POS_BIZ.Select(string.Format(@"EMP_REF_ID = {0} AND POS_BIZ_ID = '{1}'"
                                                                            , hdfTgtEmpID.Value
                                                                            , drw["POS_BIZ_ID"]));

            if (drArr.Length > 0)
            {
                ckbSelect.Checked = true;
            }
            else
            {
                ckbSelect.Checked = false;
            }
        }
        else
        {
            ckbSelect.Checked = false;
        }
    }

    protected void ibnSave_Click(object sender, ImageClickEventArgs e)
    {
        if(hdfTgtEmpID.Value.Equals(""))
        {
            ltrScript.Text = JSHelper.GetAlertScript("선택된 피평가자가 없습니다.");
            return;
        }

        Biz_EmpPositionBizMaps empPosBizMap = new Biz_EmpPositionBizMaps();
        DataTable dataTable                 = empPosBizMap.GetDataTableSchema();

        dataTable = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid2
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] {"POS_BIZ_ID"}
                                                            , dataTable);

        foreach (DataRow dataRow in dataTable.Rows)
        {
            dataRow["EMP_REF_ID"]       = hdfTgtEmpID.Value;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = empPosBizMap.SavePosBizMap(dataTable, TGT_EMP_ID);

        if(isOK) 
        {
            BindingPosBizByTgt();
            BindingTgtEmp(EST_EMP_ID);

            hdfTgtEmpID.Value       = "";
            hdfTgtPosKndID.Value    = "";

            UltraWebGrid2.Clear();
        }

        ltrScript.Text = JSHelper.GetAlertScript("정상적으로 직무설정 되었습니다.");
    }

    protected void ibnSearchAll_Click(object sender, ImageClickEventArgs e)
    {
        EST_EMP_ID = 0;

        BindingPosBizByTgt();
        BindingTgtEmp(EST_EMP_ID);

        hdfTgtEmpID.Value       = "";
        hdfTgtPosKndID.Value    = "";

        UltraWebGrid2.Clear();
    }

    protected void ibnConfirmAssingPosBiz_Click(object sender, ImageClickEventArgs e)
    {

    }
}
