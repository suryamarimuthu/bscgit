using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Infragistics.WebUI.UltraWebGrid;
using MicroBSC.Integration.BSC.Biz;

public partial class BSC_BSC0302M4 : AppPageBase
{
    protected string type
    {
        get
        {
            if (ViewState["type"] == null)
            {
                ViewState["type"] = GetRequest("type");
            }

            return ViewState["type"].ToString();
        }
        set
        {
            ViewState["type"] = value;
        }
    }

    protected int ESTTERM_REF_ID           
    {
        get
        {
            if (ViewState["est"] == null)
            {
                ViewState["est"] = int.Parse(GetRequest("est").ToString());
            }

            return int.Parse(ViewState["est"].ToString());
        }
        set
        {
            ViewState["est"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (!Page.IsPostBack)
        {
            if (type == "T")
            {
                dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().CoporationKpiTempleteList();
                this.lblPopUpTitle.Text = "전략템플릿 조직 KPI";
            }
            else
            {
                dt = new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Pool().CoporationKpiList();
                dt = DataTypeUtility.FilterSortDataTable(dt, "KPI_EXTERNAL_TYPE='INR'");
                this.lblPopUpTitle.Text = "조직KPI 풀";
            }
            
            ugrdStgList.DataSource = dt;
            ugrdStgList.DataBind();
        }
    }





    protected void iBtnInsert_Click(object sender, EventArgs e)
    {
        int effectrows = 0;
        int cnt = ugrdStgList.Rows.Count;
        if (cnt > 0)
        {
            for (int i = 0; i < cnt; i++)
            {
                UltraGridRow row = ugrdStgList.Rows[i];

                TemplatedColumn selchk = (TemplatedColumn)row.Band.Columns.FromKey("selchk");
                CheckBox cBox = (CheckBox)((CellItem)selchk.CellItems[row.BandIndex]).FindControl("cBox");

                if (cBox.Checked)
                {
                    int KPI_POOL_REF_ID = DataTypeUtility.GetToInt32(row.Cells.FromKey("KPI_POOL_REF_ID").Value);
                    int STG_REF_ID = DataTypeUtility.GetToInt32(row.Cells.FromKey("STG_REF_ID").Value);
                    int VIEW_REF_ID = DataTypeUtility.GetToInt32(row.Cells.FromKey("VIEW_REF_ID").Value);

                    if (new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info().KpiInfoExsistCheck(KPI_POOL_REF_ID, gUserInfo.Emp_Ref_ID, ESTTERM_REF_ID) > 0)
                    {
                        Response.Write("<script>alert('중복되는 KPI 입니다.');</script>");
                    }
                    else
                    {
                        effectrows += new MicroBSC.Integration.BSC.Biz.Biz_Bsc_Kpi_Info().KpiAutoInsert(ESTTERM_REF_ID
                            , VIEW_REF_ID, STG_REF_ID, KPI_POOL_REF_ID, gUserInfo.Dept_Ref_ID, gUserInfo.Emp_Ref_ID);
                    }
                }
            }

            if (effectrows > 0)
            {
                Response.Write("<script>alert('저장 되었습니다.');window.opener.location.reload();window.close();</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('한개이상은 체크하셔야 합니다.');</script>");
        }
    }

    protected void iBtnClose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }
}
