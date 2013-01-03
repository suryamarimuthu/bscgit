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

public partial class EST_EST060201 : EstPageBase
{
    private string EST_ID;
    private string Q_OBJ_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        EST_ID          = GetRequest("EST_ID");
        Q_OBJ_ID        = GetRequest("Q_OBJ_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = GetRequestByInt("ESTTERM_SUB_ID");

        if (!Page.IsPostBack)
        {
            BindingGrid(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID, Q_OBJ_ID);
        }

        ltrScript.Text = "";
    }
    private void BindingGrid( int comp_id
                            , string est_id
                            , int estterm_ref_id
                            , int estterm_sub_id
                            , string q_obj_id) 
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
        }

        Biz_QuestionDeptEmpMaps questionDeptEmpMap  = new Biz_QuestionDeptEmpMaps();
        DataSet ds                                  = questionDeptEmpMap.GetQuestionEmpMapping(   comp_id
                                                                                                , estterm_ref_id
                                                                                                , estterm_sub_id
                                                                                                , 0
                                                                                                , est_id
                                                                                                , q_obj_id
                                                                                                , 0
                                                                                                , 0
                                                                                                , OwnerTypeMode);

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString();
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;

    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }

    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName     = "Q_TGT_" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName    = "Q_TGT_DATA";
        
        uGridExcelExporter.Export(UltraWebGrid1);
    }
}
