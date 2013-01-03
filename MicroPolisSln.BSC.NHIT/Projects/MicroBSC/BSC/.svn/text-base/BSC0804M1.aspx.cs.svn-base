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
using MicroBSC.BSC.Biz;
using Infragistics.WebUI.UltraWebGrid;

public partial class BSC_BSC0804M1 : AppPageBase
{
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

    public int IDeptTypeRefID
    {
        get
        {
            if (ViewState["TYPE_REF_ID"] == null)
            {
                ViewState["TYPE_REF_ID"] = GetRequestByInt("TYPE_REF_ID", 0);
            }

            return (int)ViewState["TYPE_REF_ID"];
        }
        set
        {
            ViewState["TYPE_REF_ID"] = value;
        }
    }

    public string IYMD
    {
        get
        {
            if (ViewState["YMD"] == null)
            {
                ViewState["YMD"] = GetRequest("YMD", "");
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
        ltrScript.Text = "";
        if (!IsPostBack)
        {
            this.SetInitForm();
            this.SetParameter();
            this.SetExtEstScoreGrid();
        }
        else
        { 
        
        }
    }

    private void SetInitForm()
    { 
        WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        WebCommon.SetDeptTypeDropDownList(ddlComTypeInfo, true);

        this.iBtnSelect.Style.Add("vertical-align", "middle");
        this.iBtnSave.Style.Add("vertical-align"  , "middle");
        this.chkApplyFirstRow.Style.Add("vertical-align"  , "middle");
    }

    private void SetParameter()
    {
        this.IEstTermRefID  = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);
        this.IDeptTypeRefID = PageUtility.GetIntByValueDropDownList(ddlComTypeInfo);
        this.IYMD           = PageUtility.GetByValueDropDownList(ddlMonthInfo);
    }

    private void SetExtEstScoreGrid()
    {
        Biz_Bsc_Est_Dept_Ext_Score objBSC = new Biz_Bsc_Est_Dept_Ext_Score();
        DataSet rDs = objBSC.GetAllList(this.IEstTermRefID, this.IYMD, this.IDeptTypeRefID);

        ugrdExtScore.Clear();
        ugrdExtScore.DataSource = rDs;
        ugrdExtScore.DataBind();

        chkApplyFirstRow.Checked = false;
    }

    private void TxrExtScore()
    {
        DataTable dtScore = new DataTable("BSC_EST_DEPT_EXT_SCORE");

        dtScore.Columns.Add("ESTTERM_REF_ID" , typeof(int));
        dtScore.Columns.Add("YMD"            , typeof(string));
        dtScore.Columns.Add("EST_DEPT_REF_ID", typeof(int));
        dtScore.Columns.Add("WEIGHT_INR"     , typeof(double));
        dtScore.Columns.Add("WEIGHT_EXT"     , typeof(double));
        dtScore.Columns.Add("POINTS_EXT"     , typeof(double));
        dtScore.Columns.Add("TXR_USER"       , typeof(int));

        DataRow dr = null;
        int intRow = ugrdExtScore.Rows.Count;
        for (int i = 0; i < intRow; i++)
        {
            dr = dtScore.NewRow();
            dr["ESTTERM_REF_ID"]  = Convert.ToInt32(ugrdExtScore.Rows[i].Cells.FromKey("ESTTERM_REF_ID").Value.ToString());
            dr["YMD"]             = ugrdExtScore.Rows[i].Cells.FromKey("YMD").Value.ToString();
            dr["EST_DEPT_REF_ID"] = Convert.ToInt32(ugrdExtScore.Rows[i].Cells.FromKey("EST_DEPT_REF_ID").Value.ToString());
            dr["WEIGHT_INR"]      = Convert.ToDouble(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Value.ToString());
            dr["WEIGHT_EXT"]      = Convert.ToDouble(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Value.ToString());
            dr["POINTS_EXT"]      = Convert.ToDouble(ugrdExtScore.Rows[i].Cells.FromKey("POINTS_EXT").Value.ToString());

            dtScore.Rows.Add(dr);
        }

        Biz_Bsc_Est_Dept_Ext_Score objBSC = new Biz_Bsc_Est_Dept_Ext_Score();
        int intRtn = objBSC.InsertAll(dtScore, gUserInfo.Emp_Ref_ID);
        ltrScript.Text = JSHelper.GetAlertScript("총 ["+intRow.ToString()+"]건중 ["+intRtn.ToString()+"]건이 처리되었습니다.", false);
    }

    #region =============================== [ Event ] ===============================
    protected void ugrdExtScore_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        //TemplatedColumn cCol = (TemplatedColumn)e.Row.Band.Columns.FromKey("USE_YN");
        //Image objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        //objImg.ImageUrl = (e.Row.Cells.FromKey("USE_YN").Value.ToString() == "Y") ?
        //                  "../images/icon_o.gif" : "../images/icon_x.gif";

        //cCol   = (TemplatedColumn)e.Row.Band.Columns.FromKey("APPROVAL_STATUS");
        //objImg = (Image)((CellItem)cCol.CellItems[e.Row.BandIndex]).FindControl("imgUseYn");
        //objImg.ImageUrl = (e.Row.Cells.FromKey("APPROVAL_STATUS").Value.ToString() == "Y") ?
        //                  "../images/icon_o.gif" : "../images/icon_x.gif";

        int intLevel   = Convert.ToInt32(e.Row.Cells.FromKey("DEPT_LEVEL").Value.ToString()) - 1;
            intLevel   = (intLevel < 1) ? 0 : intLevel;
        string strDept = Convert.ToString(e.Row.Cells.FromKey("DEPT_NAME").Value);

        strDept = strDept.PadLeft(strDept.Length + intLevel, '‥');

        e.Row.Cells.FromKey("DEPT_NAME").Value = strDept;

        if (intLevel < 3)
        {
            e.Row.Cells.FromKey("DEPT_NAME").Style.Font.Bold = true;
        }

        e.Row.Cells.FromKey("DEPT_NAME").AllowEditing = AllowEditing.No;
        e.Row.Cells.FromKey("TYPE_NAME").AllowEditing = AllowEditing.No;
        e.Row.Cells.FromKey("selchk").AllowEditing    = AllowEditing.No;

        e.Row.Cells.FromKey("DEPT_NAME").Style.BackColor = Color.WhiteSmoke;
        e.Row.Cells.FromKey("TYPE_NAME").Style.BackColor = Color.WhiteSmoke;
        e.Row.Cells.FromKey("selchk").Style.BackColor    = Color.WhiteSmoke;
    }

    protected void iBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.SetParameter();
        this.SetExtEstScoreGrid();
    }


    protected void chkApplyFirstRow_CheckedChanged(object sender, EventArgs e)
    {
        int    intRow        = ugrdExtScore.Rows.Count;
        double dblWeight_Inr = 0;
        double dblWeight_Ext = 0;

        for (int i = 0; i < intRow; i++)
        { 
            if (chkApplyFirstRow.Checked)
            {
                if (i == 0)
                {
                    dblWeight_Inr = Convert.ToDouble(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Value.ToString());
                    dblWeight_Ext = Convert.ToDouble(ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Value.ToString());
                }
                else
                {
                    ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Value = dblWeight_Inr;
                    ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Value = dblWeight_Ext;
                }

                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").AllowEditing = AllowEditing.No;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").AllowEditing = AllowEditing.No;

                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Style.BackColor = Color.WhiteSmoke;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Style.BackColor = Color.WhiteSmoke;
            }
            else
            { 
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").AllowEditing = AllowEditing.Yes;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").AllowEditing = AllowEditing.Yes;

                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_INR").Style.BackColor = Color.White;
                ugrdExtScore.Rows[i].Cells.FromKey("WEIGHT_EXT").Style.BackColor = Color.White;
            }        
        }
    }

    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        this.TxrExtScore();
    }

    protected void ddlEstTermInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        WebCommon.SetTermMonthDropDownList(ddlMonthInfo, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));
        this.SetParameter();
        this.SetExtEstScoreGrid();
    }
    #endregion
}
    