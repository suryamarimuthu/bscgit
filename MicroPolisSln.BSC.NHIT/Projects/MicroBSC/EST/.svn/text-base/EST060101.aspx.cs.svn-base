using System;
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
using MicroBSC.Estimation.Biz;
using MicroBSC.Estimation.Dac;

using Infragistics.WebUI.UltraWebGrid;

public partial class EST_EST060101 : EstPageBase
{
    private string EST_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        EST_ID          = GetRequest("EST_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = GetRequestByInt("ESTTERM_SUB_ID");

        if (!Page.IsPostBack)
        {
            BindingGrid(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

            ibnDeleteMap.Attributes.Add("onclick", "return confirm('선택한 항목의 매핑정보를 삭제하시겠습니까?');");
            ibnAssingEstData.Attributes.Add("onclick", "return confirm('선택한 항목의 매핑정보를 평가데이터로 확정하시겠습니까?');");
        }

        ltrScript.Text = "";
    }

    private void BindingGrid(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id) 
    {
        int tgt_emp_id = 0;

        Biz_EstInfos estInfo    = new Biz_EstInfos(comp_id, est_id);
        OwnerTypeMode           = BizUtility.GetOwnerType(estInfo.Owner_Type);

        if(OwnerTypeMode == OwnerType.Dept) 
        {
            UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("TGT_EMP_NAME").Hidden         = true;
            UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("TGT_POS_CLS_NAME").Hidden     = true;
            UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("TGT_POS_DUT_NAME").Hidden     = true;
            UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("TGT_POS_GRP_NAME").Hidden     = true;
            UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("TGT_POS_RNK_NAME").Hidden     = true;
            UltraWebGrid1.DisplayLayout.Bands[0].Columns.FromKey("TGT_POS_KND_NAME").Hidden     = true;
        }

        Biz_EmpEstTargetMaps empEstTgtMap   = new Biz_EmpEstTargetMaps();
        DataSet ds                          = empEstTgtMap.GetEmpEstTargetMap(comp_id
                                                                            , est_id
                                                                            , estterm_ref_id
                                                                            , estterm_sub_id
                                                                            , 0
                                                                            , 0
                                                                            , 0
                                                                            , 0
                                                                            , tgt_emp_id
                                                                            , OwnerTypeMode);

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;

        if(dr["DIRECTION_TYPE"].ToString().Equals("DN"))
            e.Row.Cells.FromKey("DIRECTION_TYPE_NAME").Value = "하향";
        else
            e.Row.Cells.FromKey("DIRECTION_TYPE_NAME").Value = "상향";
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }

    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName     = "EST_TGT_" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName    = "EST_TGT_DATA";
        
        uGridExcelExporter.Export(UltraWebGrid1);
    }

    protected void ibnDeleteMap_Click(object sender, ImageClickEventArgs e)
    {
        Biz_EmpEstTargetMaps empEstTgtMap   = new Biz_EmpEstTargetMaps();

        DataTable dataTable                 = empEstTgtMap.GetDataTableSchema();

        dataTable   = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID" }
                                                            , dataTable);

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("매핑를 삭제하려는 항목이 선택되지 않았습니다.");
            return;
        }

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
        }

        bool isOK = empEstTgtMap.RemoveEmpEstTargetMap(dataTable);

        if (isOK)
        {
            BindingGrid(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);

            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 매핑이 삭제되었습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }

    protected void ibnAssingEstData_Click(object sender, ImageClickEventArgs e)
    {
        MicroBSC.Integration.EST.Biz.Biz_Est_Data bizEstData = new MicroBSC.Integration.EST.Biz.Biz_Est_Data();


        Biz_Datas biz_data                  = new Biz_Datas();
        DataTable dataTable                 = biz_data.GetDataTableSchema();

        dataTable   = UltraGridUtility.GetDataTableByCheckValue(UltraWebGrid1
                                                            , "cBox"
                                                            , "selchk"
                                                            , new string[] { "ESTTERM_STEP_ID", "EST_DEPT_ID", "EST_EMP_ID", "TGT_DEPT_ID", "TGT_EMP_ID", "TGT_POS_CLS_ID", "TGT_POS_CLS_NAME", "TGT_POS_DUT_ID", "TGT_POS_DUT_NAME", "TGT_POS_GRP_ID", "TGT_POS_GRP_NAME", "TGT_POS_RNK_ID", "TGT_POS_RNK_NAME", "TGT_POS_KND_ID", "TGT_POS_KND_NAME", "DIRECTION_TYPE" }
                                                            , dataTable);

        if(dataTable.Rows.Count == 0) 
        {
            ltrScript.Text = JSHelper.GetAlertScript("평가를 반영하려는 항목이 선택되지 않았습니다.");
            return;
        }

        foreach(DataRow dataRow in dataTable.Rows) 
        {
            dataRow["COMP_ID"]          = COMP_ID;
            dataRow["EST_ID"]           = EST_ID;
            dataRow["ESTTERM_REF_ID"]   = ESTTERM_REF_ID;
            dataRow["ESTTERM_SUB_ID"]   = ESTTERM_SUB_ID;
            dataRow["DATE"]             = DateTime.Now;
            dataRow["USER"]             = EMP_REF_ID;
        }

        bool isOK           = bizEstData.CopyTgtMapDataToEstDataBySelectedItem(dataTable, OwnerTypeMode);
        //bool isOK           = biz_data.CopyTgtMapDataToEstDataBySelectedItem(dataTable, OwnerTypeMode);

        if (isOK)
        {
            ltrScript.Text = JSHelper.GetAlertScript("정상적으로 평가데이터로 확정하였습니다.");
        }
        else
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리 중 오류가 발생하였습니다.");
        }
    }
}
