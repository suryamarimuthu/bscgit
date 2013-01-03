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

public partial class EST_EST060104 : EstPageBase
{
    private string EST_ID;
    private int ESTTERM_REF_ID;
    private string REL_GRP_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        EST_ID          = GetRequest("EST_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");
        REL_GRP_ID      = GetRequest("REL_GRP_ID");

        if (!Page.IsPostBack)
        {
            BindingGrid( EST_ID, ESTTERM_REF_ID, REL_GRP_ID);
        }

        ltrScript.Text = "";
    }
    private void BindingGrid(string est_id, int estterm_ref_id, string rel_grp_id) 
    {
        //Biz_EmpEstTargetMaps empEstTgtMap   = new Biz_EmpEstTargetMaps();
        //DataSet ds                          = empEstTgtMap.GetEmpEstTargetMap(EST_ID
        //                                                                    , ESTTERM_REF_ID
        //                                                                    , ESTTERM_SUB_ID
        //                                                                    , 0
        //                                                                    , 0
        //                                                                    , 0
        //                                                                    , 0
        //                                                                    , 0);

        //UltraWebGrid1.DataSource = ds;
        //UltraWebGrid1.DataBind();
    }
    
    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;

    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }

    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        PageUtility.ExcelDownLoad(UltraWebGrid1, "평가_피평가설정확인");
    }
    
}
