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

using SJ.Web.UI;

using MicroBSC.Common;
using MicroBSC.Biz.BSC.Biz;
using MicroBSC.BSC.Biz;
using AjaxControlToolkit;

using Dundas.Charting.WebControl;
using MicroCharts;

using DeptInfos = MicroBSC.Estimation.Dac.DeptInfos;
using Lable = System.Web.UI.WebControls.Label;

public partial class usr_usr_ahp : AppPageBase
{
    private int VER_ID;
    private int ESTTERM_REF_ID;

    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    SetPageLayout(phdLayout);
    //}
    
    protected void Page_Load(object sender, EventArgs e)
    {
        VER_ID          = PageUtility.GetIntByValueDropDownList(ddlStgVersion);
        ESTTERM_REF_ID  = PageUtility.GetIntByValueDropDownList(ddlEstTermInfo);

        if (!Page.IsPostBack)
        {
            WebCommon.SetEstTermDropDownList(ddlEstTermInfo);
            WebCommon.FillEstTree(trvEstDept, PageUtility.GetIntByValueDropDownList(ddlEstTermInfo), EMP_REF_ID);
            StgVersionDropDownBinding(PageUtility.GetIntByValueDropDownList(ddlEstTermInfo));

            iBtnSearch.Attributes.Add("onclick", "return ValidCheck();");
        }

        ltrScript.Text = "";
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        DataGrid3.Visible = false;
    }

    private void StgVersionDropDownBinding(int estterm_ref_id) 
    {
        ddlStgVersion.ClearSelection();
        Biz_PDTAndAHPVersions pdtAhpVersion = new Biz_PDTAndAHPVersions();
        DataSet ds                          = pdtAhpVersion.GetPdtAhpVersions(estterm_ref_id); 
        ddlStgVersion.DataSource            = ds;
        ddlStgVersion.DataValueField        = "VER_ID";
        ddlStgVersion.DataTextField         = "VER_NAME";
        ddlStgVersion.DataBind();
    }
    private void EstDeptStgDataBinding(int ver_id, int estterm_ref_id, int est_dept_ref_id) 
    {
        Biz_PDTAndAHPStgEstDeptDatas pdtAhpEstDept  = new Biz_PDTAndAHPStgEstDeptDatas();
        DataSet ds                                  = pdtAhpEstDept.GetPDTAndAHPEstDeptStgList(ver_id
                                                                                            , estterm_ref_id
                                                                                            , est_dept_ref_id
                                                                                            , "Y");
        DataGrid2.DataSource                        = ds;
        DataGrid2.DataBind();

        lblStgCount.Text = ds.Tables[0].Rows.Count.ToString();

        if (ds.Tables[0].Rows.Count <= 1)
        {
            DataGrid1.Visible   = false;
            DataGrid3.Visible   = false;
            iBtnSave.Visible    = false;
        }
        else 
        {
            DataGrid1.Visible   = true;
            DataGrid3.Visible   = true;
            iBtnSave.Visible    = true;
        }
    }
    private void AHPDataBinding(int ver_id, int estterm_ref_id, int est_dept_ref_id) 
    {
        Biz_PDTAndAHPStgEstDeptDatas pdtAhpStgEstDept   = new Biz_PDTAndAHPStgEstDeptDatas();
        DataGrid1.DataSource                            = pdtAhpStgEstDept.GetAHPEstDeptStgList(ver_id
                                                                                                , estterm_ref_id
                                                                                                , est_dept_ref_id);
        DataGrid1.DataBind();

        DataTable dt            = GetAHPPointDataTable();

        if (dt != null)
        {
            DataGrid3.DataSource = dt;
            DataGrid3.DataBind();

            DataGrid3.Visible = true;

            GraphAvailablePointBinding(dt);

            pdtAhpStgEstDept.ModifyPDTAndAHPWeight(VER_ID
                                                    , ESTTERM_REF_ID
                                                    , int.Parse(txtDeptID.Text)
                                                    , EMP_REF_ID
                                                    , dt);
        }
        else 
        {
            lblCI.Text          = "0";
            lblCR.Text          = "0";

            lblMsg.Text         = "";

            //DataGrid3.Visible   = false;

            //GraphNullPointBinding();
        }
    }

    protected void trvEstDept_SelectedNodeChanged(object sender, EventArgs e)
    {
        PopupControlExtender1.Commit(trvEstDept.SelectedNode.Text);
        PopupControlExtender2.Commit(trvEstDept.SelectedNode.Value);

        if (int.Parse(txtDeptID.Text) != 0)
            AHPDataBinding(VER_ID, ESTTERM_REF_ID, int.Parse(txtDeptID.Text)); 
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (!trGraph.Visible)
            trGraph.Visible = true;

        if (!iBtnSave.Visible)
            iBtnSave.Visible = true;

        EstDeptStgDataBinding(VER_ID, ESTTERM_REF_ID, int.Parse(txtDeptID.Text)); 
        AHPDataBinding(VER_ID, ESTTERM_REF_ID, int.Parse(txtDeptID.Text)); 
    }
    protected void iBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Biz_AHPEstDeptStgDatas ahpEstDeptStgDatas   = new Biz_AHPEstDeptStgDatas();

        DataTable dataTable                         = new DataTable();
        DataRow dr                                  = null;

        dataTable.Columns.Add("L_STG_REF_ID"    , typeof(int));
        dataTable.Columns.Add("R_STG_REF_ID"    , typeof(int));
        dataTable.Columns.Add("L_POINT"         , typeof(float));
        dataTable.Columns.Add("S_POINT"         , typeof(int));
        dataTable.Columns.Add("R_POINT"         , typeof(float));

        foreach (DataGridItem item in DataGrid1.Items)
        {
            dr = dataTable.NewRow();

            System.Web.UI.WebControls.Label lblLStgRefID = item.Cells[1].FindControl("lblLStgRefID") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lblRStgRefID = item.Cells[3].FindControl("lblRStgRefID") as System.Web.UI.WebControls.Label;

            TextBox txtLPoint   = item.Cells[2].FindControl("txtLPoint") as TextBox;
            TextBox txtSlider   = GetTextBox(item.Cells[2], int.Parse(item.Cells[0].Text.ToString()), 50);
            TextBox txtRPoint   = item.Cells[2].FindControl("txtRPoint") as TextBox;

            dr["L_STG_REF_ID"]  = int.Parse(lblLStgRefID.Text);
            dr["R_STG_REF_ID"]  = int.Parse(lblRStgRefID.Text);
            dr["L_POINT"]       = GetDividedPoint(txtLPoint.Text, txtRPoint.Text);
            dr["S_POINT"]       = int.Parse(txtSlider.Text);
            dr["R_POINT"]       = GetDividedPoint(txtRPoint.Text, txtLPoint.Text);

            dataTable.Rows.Add(dr);
        }

        bool isOK = ahpEstDeptStgDatas.AddAHPEstDeptStgDatas(VER_ID
                                                            , ESTTERM_REF_ID
                                                            , int.Parse(txtDeptID.Text)
                                                            , EMP_REF_ID
                                                            , dataTable);

        if (isOK)
        {
            AHPDataBinding(VER_ID, ESTTERM_REF_ID, int.Parse(txtDeptID.Text));
        }
        else 
        {
            ltrScript.Text = JSHelper.GetAlertScript("처리가 실패되었습니다.", false);
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            DataRowView drw = (DataRowView)e.Item.DataItem;

            TextBox txtLPoint = e.Item.Cells[2].FindControl("txtLPoint") as TextBox;
            TextBox txtSlider = GetTextBox(e.Item.Cells[2], int.Parse(drw["IDX"].ToString()), 50);
            TextBox txtRPoint = e.Item.Cells[2].FindControl("txtRPoint") as TextBox;

            txtSlider.Text = drw["S_POINT"].ToString();
            GetSliderValue(txtLPoint, txtSlider, txtRPoint);

            txtLPoint.Attributes.Add("onchange", string.Format("GetSliderValue('{0}', '{1}', '{2}');", txtLPoint.ClientID, txtSlider.ClientID, txtRPoint.ClientID));
            txtSlider.Attributes.Add("onchange", string.Format("GetSliderValue('{0}', '{1}', '{2}');", txtLPoint.ClientID, txtSlider.ClientID, txtRPoint.ClientID));
            txtRPoint.Attributes.Add("onchange", string.Format("GetSliderValue('{0}', '{1}', '{2}');", txtLPoint.ClientID, txtSlider.ClientID, txtRPoint.ClientID));

            //SliderExtender sxdSlider    = e.Item.Cells[2].FindControl("sxdSlider") as SliderExtender;
            //sxdSlider.BehaviorID        = txtSlider.ID;
            //sxdSlider.TargetControlID   = txtSlider.ID;
        }
    }
    private void GetSliderValue(TextBox txtlpoint, TextBox txtslider, TextBox txtrpoint)
    {
        if (int.Parse(txtslider.Text) > 0)
        {
            txtlpoint.Text = "";
            txtrpoint.Text = Convert.ToString(int.Parse(txtslider.Text) + 1);
        }
        else if (int.Parse(txtslider.Text) == 0)
        {
            txtlpoint.Text = "";
            txtrpoint.Text = "1";
        }
        else
        {
            txtlpoint.Text = Convert.ToString((int.Parse(txtslider.Text) - 1) * -1);
            txtrpoint.Text = "";
        }
    }
    private TextBox GetTextBox(TableCell cell, int rowId, int maxValue) 
    {
        for (int i = 1; i <= maxValue; i++) 
        {
            if (rowId == i)
                (cell.FindControl("txtSlider" + i.ToString()) as TextBox).Visible = true;
            else
                (cell.FindControl("txtSlider" + i.ToString()) as TextBox).Visible = false;
        }

        return cell.FindControl("txtSlider" + rowId.ToString()) as TextBox;
    }

    private float GetDividedPoint(string point_str_1, string point_str_2)
    {
        if (point_str_1 == "")
        {
            return 1 / float.Parse(point_str_2);
        }
        else 
        {
            return int.Parse(point_str_1);
        }

        return 0;
    }

    private DataTable GetAHPPointDataTable() 
    {
        int est_dept_ref_id = int.Parse(txtDeptID.Text);

        Biz_AHPEstDeptStgDatas ahpEstDept           = new Biz_AHPEstDeptStgDatas();
        Biz_PDTAndAHPStgEstDeptDatas pdtAhpEstDept  = new Biz_PDTAndAHPStgEstDeptDatas();
        DataSet ds                                  = pdtAhpEstDept.GetPDTAndAHPEstDeptStgList(VER_ID
                                                                                                , ESTTERM_REF_ID
                                                                                                , est_dept_ref_id
                                                                                                , "Y");

        int stg_count = ds.Tables[0].Rows.Count;

        if (stg_count == 0 || stg_count == 1)
            return null;

        DataTable dataTable = new DataTable();
        DataRow dr          = null;

        dataTable.Columns.Add("VER_ID"          , typeof(int));
        dataTable.Columns.Add("ESTTERM_REF_ID"  , typeof(int));
        dataTable.Columns.Add("EST_DEPT_REF_ID" , typeof(int));
        dataTable.Columns.Add("STG_REF_ID"      , typeof(int));
        dataTable.Columns.Add("STG_NAME"        , typeof(string));
        dataTable.Columns.Add("MULTIPLY"        , typeof(float));
        dataTable.Columns.Add("GEOMEAN"         , typeof(double));
        dataTable.Columns.Add("WEIGHT"          , typeof(float));
        dataTable.Columns.Add("SUM"             , typeof(float));
        dataTable.Columns.Add("WS"              , typeof(double));
        dataTable.Columns.Add("CI"              , typeof(float));
        dataTable.Columns.Add("CR"              , typeof(float));

        double total_geomean = 0;

        foreach (DataRow dataRow in ds.Tables[0].Rows) 
        {
            double multi_point = ahpEstDept.GetAHPEstDeptStgMultiPlyPoint(VER_ID
                                                                        , ESTTERM_REF_ID
                                                                        , est_dept_ref_id
                                                                        , int.Parse(dataRow["STG_REF_ID"].ToString()));

            double sum_point = ahpEstDept.GetAHPEstDeptStgSumPoint(VER_ID
                                                                    , ESTTERM_REF_ID
                                                                    , est_dept_ref_id
                                                                    , int.Parse(dataRow["STG_REF_ID"].ToString()));

            if (multi_point == 0)
                return null;

            dr                      = dataTable.NewRow();

            dr["VER_ID"]            = VER_ID;
            dr["ESTTERM_REF_ID"]    = ESTTERM_REF_ID;
            dr["EST_DEPT_REF_ID"]   = est_dept_ref_id;
            dr["STG_REF_ID"]        = dataRow["STG_REF_ID"];
            dr["STG_NAME"]          = dataRow["STG_NAME"];
            dr["MULTIPLY"]          = multi_point;
            dr["GEOMEAN"]           = Math.Pow((double)multi_point,(double)1/(double)stg_count);

            total_geomean           += Convert.ToDouble(dr["GEOMEAN"]);

            dr["WEIGHT"]            = 0;
            dr["SUM"]               = sum_point;
            dr["WS"]                = 0;
            dr["CI"]                = 0;
            dr["CR"]                = 0;
            dataTable.Rows.Add(dr);
        }

        double lambda_max           = 0;
        double c_i                  = 0;
        double rci                  = 0;
        double ratio                = 0;
        float[] rciArr              = new float[10];

        for (int i = 0; i < dataTable.Rows.Count; i++) 
        {
            DataRow drRow           = dataTable.Rows[i];

            drRow["WEIGHT"]         = (double)drRow["GEOMEAN"] / total_geomean;
            drRow["WS"]             = double.Parse(drRow["WEIGHT"].ToString()) * double.Parse(drRow["SUM"].ToString());
            drRow["WEIGHT"]         = Math.Round(double.Parse(drRow["WEIGHT"].ToString()) * 100.00, 2);

            lambda_max              += double.Parse(drRow["WS"].ToString());
        }
        
        rciArr[0]   = 0;
        rciArr[1]   = 0;
        rciArr[2]   = 0.58f;
        rciArr[3]   = 0.9f;
        rciArr[4]   = 1.12f;
        rciArr[5]   = 1.24f;
        rciArr[6]   = 1.32f;
        rciArr[7]   = 1.41f;
        rciArr[8]   = 1.45f;
        rciArr[9]   = 1.49f;

        c_i         = (lambda_max - stg_count) / (stg_count - 1);
        rci         = rciArr[stg_count - 1];
        ratio       = c_i / rci;

        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            DataRow drRow       = dataTable.Rows[i];

            drRow["CI"]         = c_i;
            drRow["CR"]         = ratio;
        }

        if (Math.Round(c_i * 100.00, 2) > 10)
        {
            lblMsg.ForeColor    = Color.Red;
            lblCI.ForeColor     = Color.Red;
            lblCR.ForeColor     = Color.Red;
            lblMsg.Text         = "귀하의 선택은 논리적 문제가 있으니<br>재 점검 바랍니다.";
        }
        else 
        {
            lblMsg.ForeColor    = Color.Blue;
            lblCI.ForeColor     = Color.Blue;
            lblCR.ForeColor     = Color.Blue;
            lblMsg.Text         = "귀하의 선택은 논리적 일관성이 있습니다.";
        }

        lblCI.Text              = Convert.ToString(Math.Round(c_i * 100.00, 2)) + "%";
        lblCR.Text              = Convert.ToString(Math.Round(ratio * 100.00, 2)) + "%";

        return dataTable;
    }

    private void GraphAvailablePointBinding(DataTable dataTable) 
    {
        DundasCharts.DundasChartBase(chartMM
                                    , ChartImageType.Flash
                                    , 500
                                    , 250
                                    , BorderSkinStyle.Emboss, Color.FromArgb(181, 64, 1), 2
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0xFF, 0xFF, 0xFE)
                                    , Color.FromArgb(0x20, 0x80, 0xD0)
                                    , ChartDashStyle.Solid
                                    , -1
                                    , ChartHatchStyle.None
                                    , GradientType.TopBottom
                                    , AntiAliasing.None);

        chartMM.DataSource = dataTable;

        Series series1  = DundasCharts.CreateSeries(chartMM
                                                , "serPlan"
                                                , "Default"
                                                , "가중치"
                                                , null
                                                , SeriesChartType.Column
                                                , 1
                                                , GetChartColor2(0)
                                                , Color.FromArgb(180, 26, 59, 105)
                                                , Color.FromArgb(64, 0, 0, 0)
                                                , 1
                                                , 9
                                                , Color.FromArgb(64, 64, 64));

        series1.Label   = "#VALY{P0}";
        
        series1.ValueMembersY                                   = "WEIGHT";
        series1.ValueMemberX                                    = "STG_NAME";

        series1.ToolTip                                         = "#VALY{P0}";

        chartMM.ChartAreas["Default"].AxisY.LabelStyle.Format = "P0";

        DundasAnimations.DundasChartBase(chartMM, AnimationTheme.None, -1, -1, false, 1);
        DundasAnimations.GrowingAnimation(chartMM, series1, 0.5, 1.5, true);

        chartMM.DataBind();
    }

    private void GraphNullPointBinding()
    {

    }

    protected Color GetChartColor2(int i)
    {
        int iCheck = i % 16;

        return Color.FromArgb(CHART_COLOR[iCheck, 0], CHART_COLOR[iCheck, 1], CHART_COLOR[iCheck, 2]);
    }
}
