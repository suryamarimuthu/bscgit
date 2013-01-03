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

public partial class EST_EST030501 : EstPageBase
{
    protected string EST_ID;
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
        
        if (!Page.IsPostBack)
        {
            bool isOK = CheckValidation(ltrScript);

            if(!isOK)
            {
                return;
            }

            EST_EMP_ID = 0;

            BindingPosBizByTgt();
            BindingEmp();

            ibnSave.Attributes.Add("onclick", "return confirm('사원 직무를 저장하시겠습니까?');");
        }

        TGT_EMP_ID      = DataTypeUtility.GetToInt32(hdfTgtEmpID.Value);
        TGT_POS_KND_ID  = hdfTgtPosKndID.Value;

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e) 
    {
        if(hdfTgtEmpID.Value.Equals(""))
            ibnViewQ.Visible = false;
        else
            ibnViewQ.Visible = true;
    }

    private void BindingEmp() 
    {
        Biz_EmpInfos empInfo    = new Biz_EmpInfos();
        DataTable dataTable     = empInfo.GetAllEmp().Tables[0];

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
            hdfTgtEmpID.Value    = e.SelectedRows[0].Cells.FromKey("EMP_REF_ID").Value.ToString();

            if(e.SelectedRows[0].Cells.FromKey("POS_KND_ID").Value == null)
            {
                ltrScript.Text          = JSHelper.GetAlertScript("선택된 사원의 직종이 없습니다.");
                BindingPosBizByTgt();
                BindingEmp();
                hdfTgtEmpID.Value       = "";
                hdfTgtPosKndID.Value    = "";
                UltraWebGrid2.Clear();
                return;
            }

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
                                                                            , drw["EMP_REF_ID"]));

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
        if(TGT_EMP_ID.Equals(""))
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
            dataRow["EMP_REF_ID"]       = TGT_EMP_ID;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK = empPosBizMap.SavePosBizMap(dataTable, TGT_EMP_ID);

        if(isOK) 
        {
            BindingPosBizByTgt();
            BindingEmp();

            hdfTgtEmpID.Value       = "";
            hdfTgtPosKndID.Value    = "";
            UltraWebGrid2.Clear();

            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 직무설정 되었습니다.");
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }
}
