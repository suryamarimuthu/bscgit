using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

using Infragistics.WebUI.UltraWebGrid;
using Dundas.Charting.WebControl;
using Infragistics.WebUI.UltraWebGrid.ExcelExport;
using Infragistics.Documents.Excel;


using MicroCharts;
using MicroBSC.Biz.BSC;
using MicroBSC.BSC.Biz;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.Data;

public partial class BSC_BSC0803S3 : AppPageBase
{
    public string IType
    {
        get
        {
            if (ViewState["ITYPE"] == null)
            {
                ViewState["ITYPE"] = GetRequest("iType", "");
            }

            return (string)ViewState["ITYPE"];
        }
        set
        {
            ViewState["ITYPE"] = value;
        }
    }

    public int IEstTermRefID
    {
        get
        {
            if (ViewState["ESTTERM_REF_ID"] == null)
            {
                ViewState["ESTTERM_REF_ID"] = GetRequestByInt("ESTTERM_REF_ID", 0);
            }

            return (int)ViewState["ESTTERM_REF_ID"];
        }
        set
        {
            ViewState["ESTTERM_REF_ID"] = value;
        }
    }

    public int IKpiRefID
    {
        get
        {
            if (ViewState["KPI_REF_ID"] == null)
            {
                ViewState["KPI_REF_ID"] = GetRequestByInt("KPI_REF_ID", 0);
            }

            return (int)ViewState["KPI_REF_ID"];
        }
        set
        {
            ViewState["KPI_REF_ID"] = value;
        }
    }

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "000000");
            }

            return (string)ViewState["YMD"];
        }
        set
        {
            ViewState["YMD"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetOpinionGrid();
        }
        else
        {

        }
    }

    public void SetOpinionGrid()
    {
        Biz_Bsc_Kpi_Qlt_Score_Had objOpn = new Biz_Bsc_Kpi_Qlt_Score_Had();
        DataSet oDs = objOpn.GetAllList(this.IEstTermRefID
                                       , this.IYMD
                                       , 0
                                       , this.IKpiRefID  //PageUtility.GetIntByValueDropDownList(ddlEstLevel)
                                       , 0);
        ugrdEstOpinion.Clear();
        ugrdEstOpinion.DataSource = oDs.Tables[0].DefaultView;
        ugrdEstOpinion.DataBind();
    }

    protected void ugrdEstOpinion_InitializeRow(object sender, RowEventArgs e)
    {
        string sFileId = (e.Row.Cells.FromKey("REVIEW_FILE_ID").Value == null) ? "" : e.Row.Cells.FromKey("REVIEW_FILE_ID").Value.ToString();
        TemplatedColumn colEst = (TemplatedColumn)e.Row.Cells.FromKey("EST_LEVEL_NAME").Column;

        System.Web.UI.WebControls.Label lblLevel      = (System.Web.UI.WebControls.Label)((CellItem)colEst.CellItems[e.Row.BandIndex]).FindControl("lblEST_LEVEL_NAME");
        System.Web.UI.WebControls.ImageButton btnFile = (System.Web.UI.WebControls.ImageButton)((CellItem)colEst.CellItems[e.Row.BandIndex]).FindControl("iBtnReviewFile");
        System.Web.UI.WebControls.HiddenField hdfFile = (System.Web.UI.WebControls.HiddenField)((CellItem)colEst.CellItems[e.Row.BandIndex]).FindControl("iHdfReviewFile");

        lblLevel.Text   = (e.Row.Cells.FromKey("EST_LEVEL_NAME").Value == null) ? "" : e.Row.Cells.FromKey("EST_LEVEL_NAME").Value.ToString();
        string sOpinion = (e.Row.Cells.FromKey("OPINION").Value == null) ? "" : e.Row.Cells.FromKey("OPINION").Value.ToString();

        if (sOpinion == "")
        {
            e.Row.Hidden = true;
        }

        if (sFileId.Length > 0)
        {
            hdfFile.Value = sFileId;
            btnFile.Visible = true;
            btnFile.OnClientClick = "return mfUpload('" + hdfFile.ClientID.Replace("$", "_") + "')";
        }
        else
        {
            hdfFile.Value = "";
            btnFile.Visible = false;
        }
    }
}
