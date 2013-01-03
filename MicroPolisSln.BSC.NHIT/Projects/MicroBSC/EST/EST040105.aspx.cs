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

public partial class EST_EST040105 : EstPageBase
{
    private string EST_ID;
    private string REL_GRP_ID;
    private string SENTENCE;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID         = GetRequestByInt("COMP_ID");
        REL_GRP_ID      = GetRequest("REL_GRP_ID");
        EST_ID          = GetRequest("EST_ID");
        ESTTERM_REF_ID  = GetRequestByInt("ESTTERM_REF_ID");

        ESTTERM_STEP_ID = BizUtility.GetEstTermStepIDByMergeYN(COMP_ID);

        SENTENCE        =  BizUtility.GetRelGroupWhereString( COMP_ID
                                                            , EST_ID
                                                            , ESTTERM_REF_ID
                                                            , REL_GRP_ID
                                                            , "TM");

        if (!Page.IsPostBack)
        {
            Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, EST_ID);
            OwnerTypeMode           = BizUtility.GetOwnerType(estInfo.Owner_Type);

            DropDownListCommom.BindEstTermSubByYearYN(ddlEstTermSubID, COMP_ID, "");

            GridBinding(WebUtility.GetIntByValueDropDownList(ddlEstTermSubID), OwnerTypeMode);
        }

        ESTTERM_SUB_ID  = WebUtility.GetIntByValueDropDownList(ddlEstTermSubID);

        ltrScript.Text = "";
    }

    private void GridBinding(int estterm_sub_id, OwnerType ownerType)
    {
        DataSet ds = null;

        if(ownerType == OwnerType.Dept) 
        {
            rbnComDeptEmp.Text = "전체 부서 데이터";

            UltraWebGrid1.Columns.FromKey("TGT_EMP_NAME").Hidden       = true;
            UltraWebGrid1.Columns.FromKey("TGT_POS_CLS_NAME").Hidden   = true;
            UltraWebGrid1.Columns.FromKey("TGT_POS_DUT_NAME").Hidden   = true;
            UltraWebGrid1.Columns.FromKey("TGT_POS_GRP_NAME").Hidden   = true;
            UltraWebGrid1.Columns.FromKey("TGT_POS_RNK_NAME").Hidden   = true;
            UltraWebGrid1.Columns.FromKey("TGT_POS_KND_NAME").Hidden   = true;
        }
        else if(ownerType == OwnerType.Dept) 
        {
            rbnComDeptEmp.Text = "전체 사원 데이터";

            UltraWebGrid1.Columns.FromKey("TGT_EMP_NAME").Hidden       = false;
            UltraWebGrid1.Columns.FromKey("TGT_POS_CLS_NAME").Hidden   = false;
            UltraWebGrid1.Columns.FromKey("TGT_POS_DUT_NAME").Hidden   = false;
            UltraWebGrid1.Columns.FromKey("TGT_POS_GRP_NAME").Hidden   = false;
            UltraWebGrid1.Columns.FromKey("TGT_POS_RNK_NAME").Hidden   = false;
            UltraWebGrid1.Columns.FromKey("TGT_POS_KND_NAME").Hidden   = false;
        }

        if (rbnComDeptEmp.Checked)
        {
            UltraWebGrid1.Columns.FromKey("TGT_DEPT_NAME").Header.Caption = "부서명";
            UltraWebGrid1.Columns.FromKey("TGT_EMP_NAME").Header.Caption  = "사원명";

            UltraWebGrid1.Columns.FromKey("ESTTERM_SUB_NAME").Hidden      = true;
            UltraWebGrid1.Columns.FromKey("EST_DEPT_NAME").Hidden         = true;
            UltraWebGrid1.Columns.FromKey("EST_EMP_NAME").Hidden          = true;

            Biz_EmpInfos biz = new Biz_EmpInfos();

            if(OwnerTypeMode == OwnerType.Dept) 
            {
                ds = biz.GetRelDeptList("WHERE", SENTENCE, "TM");
            }
            else if(OwnerTypeMode == OwnerType.Emp_User)
            {
                ds = biz.GetRelEmpList("WHERE", SENTENCE, "TM");
            }
        }
        else
        {
            UltraWebGrid1.Columns.FromKey("ESTTERM_SUB_NAME").Hidden      = false;
            UltraWebGrid1.Columns.FromKey("EST_DEPT_NAME").Hidden         = false;
            UltraWebGrid1.Columns.FromKey("EST_EMP_NAME").Hidden          = false;

            UltraWebGrid1.Columns.FromKey("TGT_DEPT_NAME").Header.Caption = "피평가자부서";
            UltraWebGrid1.Columns.FromKey("TGT_EMP_NAME").Header.Caption  = "피평가자명";            

            Biz_Datas biz = new Biz_Datas();

            if(OwnerTypeMode == OwnerType.Dept) 
            {
                
            }
            else if(OwnerTypeMode == OwnerType.Emp_User)
            {
                 
            }

            ds            = biz.GetEstDataByRelGroup(  COMP_ID
                                                     , EST_ID
                                                     , ESTTERM_REF_ID
                                                     , estterm_sub_id
                                                     , ESTTERM_STEP_ID
                                                     , "AND "
                                                     , SENTENCE);
        }

        UltraWebGrid1.DataSource = ds.Tables[0];
        UltraWebGrid1.DataBind();

        lblRowCount.Text = ds.Tables[0].Rows.Count.ToString("#,##0");
    }

    protected void UltraWebGrid1_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView dr  = (DataRowView)e.Data;
    }

    protected void UltraWebGrid1_InitializeLayout(object sender, LayoutEventArgs e)
    {
        UltraGridUtility.VisiblePosColumn(e.Layout.Bands[0].Columns);
    }

    protected void ibnSearch_Click(object sender, ImageClickEventArgs e)
    {
        GridBinding(ESTTERM_SUB_ID, OwnerTypeMode);
    }
    protected void ibnDownExcel_Click(object sender, ImageClickEventArgs e)
    {
        uGridExcelExporter.DownloadName     = "EST_REL_" + "_" + DateTime.Now.ToString("yyMMddHHmmss");
        uGridExcelExporter.WorksheetName    = "EST_REL_DATA";
        
        uGridExcelExporter.Export(UltraWebGrid1);
    }
}
