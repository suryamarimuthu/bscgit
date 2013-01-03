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
using MicroBSC.PRJ.Biz;

using Infragistics.WebUI.UltraWebGrid;

using Infragistics.WebUI.UltraWebGrid;

public partial class PRJ_PRJ0201S1 : PrjPageBase
{
    private string EST_ID;
    private int ESTTERM_REF_ID;
    private int ESTTERM_SUB_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        EST_ID          = GetRequest("EST_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID  = GetRequestByInt("ESTTERM_SUB_ID");

        if (!Page.IsPostBack)
        {
            BindingGrid(COMP_ID, EST_ID, ESTTERM_REF_ID, ESTTERM_SUB_ID);
        }

        ltrScript.Text = "";
    }
    private void BindingGrid(int comp_id, string est_id, int estterm_ref_id, int estterm_sub_id) 
    {
        Biz_Prj_EmpEstPrjMap objPrjEmpEstPrjMap = new Biz_Prj_EmpEstPrjMap();

        DataSet ds = objPrjEmpEstPrjMap.GetPrjEmpEstPrjMap(comp_id, est_id, estterm_ref_id, estterm_sub_id, 0, 0, 0, 0);

        UltraWebGrid1.DataSource = ds;
        UltraWebGrid1.DataBind();
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;

    }

    //protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    //{
    //    PageUtility.ExcelDownLoad(UltraWebGrid1, "평가_피평가설정확인");
    //}
    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName = "PRJ" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName = "PRJ_EST_MAP";

        uGridExcelExporter.Export(UltraWebGrid1);
    }
}
