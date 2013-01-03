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
using System.Collections.Generic;

using MicroBSC.Biz.Common;
using MicroBSC.Common;
using MicroBSC.RolesBasedAthentication;

using MicroBSC.Estimation.Biz;

public partial class EST_EST_RPT_EMP : EstPageBase
{ 

    private string IEST_STRINGCODE
    {
        get
        {
            if (ViewState["EST_STRINGCODE"] == null)
                ViewState["EST_STRINGCODE"] = ";;;;;;";
            return (string)ViewState["EST_STRINGCODE"];
        }
        set
        {
            ViewState["EST_STRINGCODE"] = value;
        }
    }
    private string IEST_STRINGNAME
    {
        get
        {
            if (ViewState["EST_STRINGNAME"] == null)
                ViewState["EST_STRINGNAME"] = ";;;;;;";
            return (string)ViewState["EST_STRINGNAME"];
        }
        set
        {
            ViewState["EST_STRINGNAME"] = value;
        }
    }

    private string FROM_EST_ID;
    private int EST_DEPT_ID;
    private int EST_EMP_ID;
    private int TGT_DEPT_ID;
    private int TGT_EMP_ID; 

    protected string ESTTERM_REF_NAME;
    protected string ESTTERM_SUB_NAME;
    protected string TGT_DEPT_NAME;
    protected string TGT_EMP_NAME;

    private string ILEGEND;

    protected void Page_Load(object sender, EventArgs e)
    {
        COMP_ID          = WebUtility.GetRequestByInt("COMP_ID");
        FROM_EST_ID      = WebUtility.GetRequest("EST_ID");
        ESTTERM_REF_ID   = WebUtility.GetRequestByInt("ESTTERM_REF_ID");
        ESTTERM_SUB_ID   = WebUtility.GetRequestByInt("ESTTERM_SUB_ID");
        ESTTERM_STEP_ID  = WebUtility.GetRequestByInt("ESTTERM_STEP_ID");
        EST_DEPT_ID      = WebUtility.GetRequestByInt("EST_DEPT_ID");
        EST_EMP_ID       = WebUtility.GetRequestByInt("EST_EMP_ID");
        TGT_DEPT_ID      = WebUtility.GetRequestByInt("TGT_DEPT_ID");
        TGT_EMP_ID       = WebUtility.GetRequestByInt("TGT_EMP_ID");

        MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info bizCom = new MicroBSC.Biz.Common.Biz.Biz_Com_Code_Info();
        DataSet dsCom = bizCom.GetCodeListPerCategory("BS015", "Y");

        ddlGradePoint_hdf.DataSource = dsCom;
        ddlGradePoint_hdf.DataValueField = "ETC_CODE";
        ddlGradePoint_hdf.DataTextField = "SEGMENT1";
        ddlGradePoint_hdf.DataBind();

        string ilegend = string.Empty;
        for (int i = 0; i < ddlGradePoint_hdf.Items.Count; i++)
        {
            ilegend += ddlGradePoint_hdf.Items[i].Value + " : " + ddlGradePoint_hdf.Items[i].Text + "\n";
        }
        this.ILEGEND = ilegend;

        if (!Page.IsPostBack)
        {
            DataBindReport();

            Biz_EstInfos bizEstInfos = new Biz_EstInfos();
            DataSet dsDashBoard = bizEstInfos.GetDashBoardEst(COMP_ID);
            
            if (dsDashBoard.Tables[0].Rows.Count > 0)
            {
                string[] est_code = { "", "", "", "", "", "", "" };
                string[] est_name = { "", "", "", "", "", "", "" };
                string[] est_type = { "01", "02", "03", "04", "11", "12", "13" };//업적평가, 역량평가, 공헌도평가, MBO평가, 공통역량,직무역량,리더역량
                foreach (DataRow drDashBoard in dsDashBoard.Tables[0].Rows)
                {
                    int dashboard_type = DataTypeUtility.GetToInt32(drDashBoard["DASHBOARD_TYPE"].ToString());
                    if (DataTypeUtility.GetToInt32(drDashBoard["DASHBOARD_TYPE"].ToString()) > 10 && DataTypeUtility.GetToInt32(drDashBoard["DASHBOARD_TYPE"].ToString()) < 14)
                    {
                        est_code[dashboard_type - 7] = drDashBoard["EST_ID"].ToString();
                        est_name[dashboard_type - 7] = drDashBoard["EST_NAME"].ToString();
                    }
                    else
                    {
                        est_code[dashboard_type - 1] = drDashBoard["EST_ID"].ToString();
                        est_name[dashboard_type - 1] = drDashBoard["EST_NAME"].ToString();
                    }
                }
                string est_fullcode = string.Empty;
                string est_fullname = string.Empty;
                for (int i = 0; i < est_code.Length; i++)
                {
                    est_fullcode += est_code[i].ToString();
                    est_fullname += est_name[i].ToString();

                    if (i < 6)
                    {
                        est_fullcode += ";";
                        est_fullname += ";";
                    }
                }
                this.IEST_STRINGCODE = est_fullcode;
                this.IEST_STRINGNAME = est_fullname;

                if (est_code[3].ToString() != "")
                    rblFindType.Items.Insert(0, new ListItem(est_name[3].ToString(), est_type[3].ToString()));
                if (est_code[2].ToString() != "")
                    rblFindType.Items.Insert(0, new ListItem(est_name[2].ToString(), est_type[2].ToString()));
            }

            if (rblFindType.Items.Count > 0)
            {
                rblFindType.SelectedIndex = 0;
                if (rblFindType.Items[0].Value == "03")
                {
                    ddlListType.Visible = false;
                    div04.Visible = false;
                }
                else if (rblFindType.Items[0].Value == "04")
                {
                    div03.Visible = false;
                }
            }            

            ddlListType.Items.Add(new ListItem("전체", ""));
            ddlListType.Items.Add(new ListItem("나의지표", "N"));
            ddlListType.Items.Add(new ListItem("팀지표", "Y"));

            //DataBindGraph();
            doBindingGraph();
            //탭2 관련숨김 2012.10.12
            //igTab.SelectedTabIndex = 2;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
		
    }

    protected void ugrdMBO_InitializeRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Data;

        
        double initPoint = DataTypeUtility.GetToDouble(drw["POINT"]);
        int sValue = ddlGradePoint_hdf.Items.Count - 1;
        for (int i = 1; i < ddlGradePoint_hdf.Items.Count - 1; i++)
        {
            if (initPoint >= DataTypeUtility.GetToDouble(ddlGradePoint_hdf.Items[i].Text.Trim()))
            {
                sValue = i;
                break;
            }
        }
        ddlGradePoint_hdf.SelectedIndex = sValue;
        //e.Row.Cells.FromKey("SIGNAL").Value = ddlGradePoint_hdf.SelectedItem.Value;
        e.Row.Cells.FromKey("SIGNAL").Value = string.Format("<img alt='{1}' src='../images/org/signal_set1/icon_{0}.gif' style='cursor: pointer;' />", ddlGradePoint_hdf.SelectedItem.Value, this.ILEGEND);
    }

    private void doBindingGraph()
    {

        Biz_ReportDetails bizReport = new Biz_ReportDetails();
        string[] splitCode = this.IEST_STRINGCODE.Split(';');
        string estid_1 = splitCode[0].ToString();
        string estid_2 = splitCode[1].ToString();
        string gongid = splitCode[2].ToString();
        string mboid = splitCode[3].ToString();
        string yid1 = splitCode[4].ToString();
        string yid2 = splitCode[5].ToString();
        string yid3 = splitCode[6].ToString();

        DataTable[] dtReportMass = bizReport.GetEstDataForReportMBO(COMP_ID
                                                                  , ESTTERM_REF_ID
                                                                  , FROM_EST_ID
                                                                  , ESTTERM_SUB_ID
                                                                  , ESTTERM_STEP_ID
                                                                  , estid_1
                                                                  , estid_2
                                                                  , gongid
                                                                  , mboid
                                                                  , TGT_EMP_ID
                                                                  , ddlListType.SelectedValue
                                                                  , yid1
                                                                  , yid2
                                                                  , yid3);

        //최종평가결과
        if (dtReportMass[0].Rows.Count > 0)
        {
            lblPoint_1.Text = DataTypeUtility.GetToDouble(dtReportMass[0].Rows[0]["POINT_1"]).ToString("###,##0.##");
            lblPoint_2.Text = dtReportMass[0].Rows[0]["POINT_2"].ToString();
            lblPoint_3.Text = DataTypeUtility.GetToDouble(dtReportMass[0].Rows[0]["POINT_3"]).ToString("###,##0.##");
            lblPoint_4.Text = DataTypeUtility.GetToDouble(dtReportMass[0].Rows[0]["POINT_4"]).ToString("###,##0.##");
        }

        #region -- 업적평가(공헌도평가)
        if (dtReportMass[5].Rows.Count > 0)
        {
            double[] yValues = new double[dtReportMass[5].Rows.Count];
            string[] xValues = new string[dtReportMass[5].Rows.Count];
            double[] y = new double[dtReportMass[5].Rows.Count];
            for (int i = 0; i < dtReportMass[5].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dtReportMass[5].Rows[i]["MY_POINT"]);
                xValues[i] = dtReportMass[5].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dtReportMass[5].Rows[i]["AVG_POINT"]);
            }
            this.Chart0.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart0.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.Chart0.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart0.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart0.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart0.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart0.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart0.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart0.Series["Series1"].ShowLabelAsValue = true;
            this.Chart0.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart0.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart0.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart0.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart0.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart0.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart0.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart0.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart0.Series["Series1"].Points.Count; i++)
            {
                Chart0.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart0.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart0.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart0.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart0.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart0.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart0.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart0.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            Chart0.Series["Series1"].BorderWidth = 2;
            Chart0.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart0.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart0.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart0.Series["Series1"].LegendText = "획득점수";
            Chart0.Series["Series2"].LegendText = "평균점수";

            // popup
            this.ChartD.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartD.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartD.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartD.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartD.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartD.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartD.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartD.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartD.Series["Series1"].ShowLabelAsValue = true;
            this.ChartD.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartD.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartD.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartD.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartD.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartD.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartD.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartD.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartD.Series["Series1"].Points.Count; i++)
            {
                ChartD.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartD.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartD.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartD.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartD.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartD.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartD.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartD.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            ChartD.Series["Series1"].BorderWidth = 2;
            ChartD.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartD.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartD.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartD.Series["Series1"].LegendText = "획득점수";
            ChartD.Series["Series2"].LegendText = "평균점수";
        }
        Chart0.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(2).ToString();
        ChartD.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(2).ToString();
        #endregion

        //업적평가(MBO)       
        ugrdMBO.DataSource = dtReportMass[1];
        ugrdMBO.DataBind();

        //역량평가
        //평가별점수
        double[] yValues1 = new double[] { 0, 0, 0 };
        string[] xValues1 = new string[] { "," + this.IEST_STRINGNAME.Split(';').GetValue(6).ToString().Replace("평가", ""), "," + this.IEST_STRINGNAME.Split(';').GetValue(5).ToString().Replace("평가", ""), "," + this.IEST_STRINGNAME.Split(';').GetValue(4).ToString().Replace("평가", "") };
        if (dtReportMass[0].Rows.Count > 0)
        {
            yValues1 = new double[] { DataTypeUtility.GetToDouble(dtReportMass[0].Rows[0]["YVALUE3"]), DataTypeUtility.GetToDouble(dtReportMass[0].Rows[0]["YVALUE2"]), DataTypeUtility.GetToDouble(dtReportMass[0].Rows[0]["YVALUE1"]) };
        }
        Chart1.Series["Default"].Points.Clear();

        string markcolor = string.Empty;
        for (int i = 0; i < yValues1.Length; i++)
        {
            Chart1.Series["Default"].Points.AddXY(xValues1[i], yValues1[i]);
            Chart1.Series["Default"].Points[i].Label = yValues1[i].ToString();

            if (i == 0)
                markcolor = "#4773E2";
            else if (i == 1)
                markcolor = "#E97F29";
            else if (i == 2)
                markcolor = "#63D81D";

            Chart1.Series["Default"].Points[i].MarkerColor = System.Drawing.ColorTranslator.FromHtml(markcolor);
            Chart1.Series["Default"].Points[i].Color = System.Drawing.ColorTranslator.FromHtml(markcolor);
            Chart1.Series["Default"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#F4F4F4");
            Chart1.Series[0]["DrawingStyle"] = "Cylinder";
        }

        Chart1.Series["Default"]["FunnelLabelStyle"] = "Outside";
        Chart1.ChartAreas["Default"].Area3DStyle.Enable3D = true;
        Chart1.Series["Default"]["FunnelStyle"] = "YIsHeight";
        Chart1.Series["Default"]["FunnelOutsideLabelPlacement"] = "Left";
        Chart1.Series["Default"]["FunnelPointGap"] = "2";
        Chart1.Series["Default"]["Funnel3DDrawingStyle"] = "CircularBase";
        Chart1.Series["Default"]["Funnel3DRotationAngle"] = "10";
        Chart1.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
        Chart1.ChartAreas["Default"].AxisX.LineColor = System.Drawing.Color.LightGray;
        Chart1.Titles[0].Text = "평가점수";
        Chart1.Series["Default"].YValuesPerPoint = 32;


        #region -- 평가항목별 점수현황(공통역량평가)
        if (dtReportMass[2].Rows.Count > 0)
        {
            double[] yValues = new double[dtReportMass[2].Rows.Count];
            string[] xValues = new string[dtReportMass[2].Rows.Count];
            double[] y = new double[dtReportMass[2].Rows.Count];
            for (int i = 0; i < dtReportMass[2].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dtReportMass[2].Rows[i]["MY_POINT"]);
                xValues[i] = dtReportMass[2].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dtReportMass[2].Rows[i]["AVG_POINT"]);
            }
            this.Chart2.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart2.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.Chart2.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart2.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart2.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart2.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart2.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart2.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart2.Series["Series1"].ShowLabelAsValue = true;
            this.Chart2.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart2.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart2.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart2.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart2.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart2.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart2.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart2.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart2.Series["Series1"].Points.Count; i++)
            {
                Chart2.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart2.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart2.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart2.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart2.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart2.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart2.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart2.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            Chart2.Series["Series1"].BorderWidth = 2;
            Chart2.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart2.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart2.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart2.Series["Series1"].LegendText = "획득점수";
            Chart2.Series["Series2"].LegendText = "평균점수";

            // popup
            this.ChartA.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartA.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartA.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartA.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartA.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartA.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartA.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartA.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartA.Series["Series1"].ShowLabelAsValue = true;
            this.ChartA.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartA.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartA.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartA.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartA.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartA.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartA.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartA.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartA.Series["Series1"].Points.Count; i++)
            {
                ChartA.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartA.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartA.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartA.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartA.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartA.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartA.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartA.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            ChartA.Series["Series1"].BorderWidth = 2;
            ChartA.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartA.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartA.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartA.Series["Series1"].LegendText = "획득점수";
            ChartA.Series["Series2"].LegendText = "평균점수";
        }
        Chart2.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(4).ToString();
        ChartA.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(4).ToString();
        #endregion


        #region --평가항목별 점수현황(직무역량평가)
        if (dtReportMass[3].Rows.Count > 0)
        {
            double[] yValues = new double[dtReportMass[3].Rows.Count];
            string[] xValues = new string[dtReportMass[3].Rows.Count];
            double[] y = new double[dtReportMass[3].Rows.Count];
            for (int i = 0; i < dtReportMass[3].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dtReportMass[3].Rows[i]["MY_POINT"]);
                xValues[i] = dtReportMass[3].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dtReportMass[3].Rows[i]["AVG_POINT"]);
            }
            this.Chart3.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart3.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.Chart3.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart3.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart3.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart3.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart3.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart3.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart3.Series["Series1"].ShowLabelAsValue = true;
            this.Chart3.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart3.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart3.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart3.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart3.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart3.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart3.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart3.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart3.Series["Series1"].Points.Count; i++)
            {
                Chart3.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart3.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart3.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart3.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart3.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart3.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart3.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart3.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#E97F29");
            Chart3.Series["Series1"].BorderWidth = 2;
            Chart3.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart3.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart3.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart3.Series["Series1"].LegendText = "획득점수";
            Chart3.Series["Series2"].LegendText = "평균점수";

            //popup
            this.ChartB.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartB.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartB.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartB.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartB.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartB.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartB.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartB.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartB.Series["Series1"].ShowLabelAsValue = true;
            this.ChartB.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartB.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartB.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartB.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartB.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartB.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartB.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartB.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartB.Series["Series1"].Points.Count; i++)
            {
                ChartB.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartB.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartB.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartB.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartB.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartB.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartB.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartB.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#E97F29");
            ChartB.Series["Series1"].BorderWidth = 2;
            ChartB.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartB.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartB.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartB.Series["Series1"].LegendText = "획득점수";
            ChartB.Series["Series2"].LegendText = "평균점수";
        }
        Chart3.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(5).ToString();
        ChartB.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(5).ToString();
        #endregion

        #region --평가항목별 점수현황(리더역량평가)
        if (dtReportMass[4].Rows.Count > 0)
        {
            double[] yValues = new double[dtReportMass[4].Rows.Count];
            string[] xValues = new string[dtReportMass[4].Rows.Count];
            double[] y = new double[dtReportMass[4].Rows.Count];
            for (int i = 0; i < dtReportMass[4].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dtReportMass[4].Rows[i]["MY_POINT"]);
                xValues[i] = dtReportMass[4].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dtReportMass[4].Rows[i]["AVG_POINT"]);
            }
            this.Chart4.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart4.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.Chart4.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart4.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart4.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart4.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart4.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart4.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart4.Series["Series1"].ShowLabelAsValue = true;
            this.Chart4.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart4.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart4.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart4.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart4.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart4.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart4.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart4.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart4.Series["Series1"].Points.Count; i++)
            {
                Chart4.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart4.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart4.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart4.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart4.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart4.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart4.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart4.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#4773E2");
            Chart4.Series["Series1"].BorderWidth = 2;
            Chart4.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart4.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart4.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart4.Series["Series1"].LegendText = "획득점수";
            Chart4.Series["Series2"].LegendText = "평균점수";

            //popup
            this.ChartC.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartC.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartC.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartC.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartC.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartC.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartC.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartC.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartC.Series["Series1"].ShowLabelAsValue = true;
            this.ChartC.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartC.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartC.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartC.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartC.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartC.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartC.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartC.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartC.Series["Series1"].Points.Count; i++)
            {
                ChartC.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartC.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartC.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartC.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartC.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartC.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartC.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartC.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#4773E2");
            ChartC.Series["Series1"].BorderWidth = 2;
            ChartC.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartC.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartC.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartC.Series["Series1"].LegendText = "획득점수";
            ChartC.Series["Series2"].LegendText = "평균점수";
        }
        Chart4.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(6).ToString();
        ChartC.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(6).ToString();
        #endregion

    }

    private void DataBindGraph()
    {
        Biz_ReportDetails bizReport = new Biz_ReportDetails();
        string[] splitCode = this.IEST_STRINGCODE.Split(';');
        string estid_1 = splitCode[0].ToString();
        string estid_2 = splitCode[1].ToString();
        string gongid = splitCode[2].ToString();
        string mboid = splitCode[3].ToString();
        string yid1 = splitCode[4].ToString();
        string yid2 = splitCode[5].ToString();
        string yid3 = splitCode[6].ToString();

        DataSet dsReport = bizReport.GetReportIndividal(COMP_ID
                                                      , ESTTERM_REF_ID
                                                      , FROM_EST_ID
                                                      , ESTTERM_SUB_ID
                                                      , ESTTERM_STEP_ID
                                                      , estid_1
                                                      , estid_2
                                                      , gongid
                                                      , mboid
                                                      , TGT_EMP_ID
                                                      , ddlListType.SelectedValue
                                                      , yid1
                                                      , yid2
                                                      , yid3);

        //최종평가결과
        if (dsReport.Tables[0].Rows.Count > 0)
        {
            lblPoint_1.Text = DataTypeUtility.GetToDouble(dsReport.Tables[0].Rows[0]["POINT_1"]).ToString("###,##0.##");
            lblPoint_2.Text = dsReport.Tables[0].Rows[0]["POINT_2"].ToString();
            lblPoint_3.Text = DataTypeUtility.GetToDouble(dsReport.Tables[0].Rows[0]["POINT_3"]).ToString("###,##0.##");
            lblPoint_4.Text = DataTypeUtility.GetToDouble(dsReport.Tables[0].Rows[0]["POINT_4"]).ToString("###,##0.##");
        }

        #region -- 업적평가(공헌도평가)
        if (dsReport.Tables[5].Rows.Count > 0)
        {
            double[] yValues = new double[dsReport.Tables[5].Rows.Count];
            string[] xValues = new string[dsReport.Tables[5].Rows.Count];
            double[] y = new double[dsReport.Tables[5].Rows.Count];
            for (int i = 0; i < dsReport.Tables[5].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dsReport.Tables[5].Rows[i]["MY_POINT"]);
                xValues[i] = dsReport.Tables[5].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dsReport.Tables[5].Rows[i]["AVG_POINT"]);
            }
            this.Chart0.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart0.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.Chart0.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart0.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart0.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart0.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart0.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart0.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart0.Series["Series1"].ShowLabelAsValue = true;
            this.Chart0.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart0.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart0.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart0.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart0.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart0.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart0.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart0.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart0.Series["Series1"].Points.Count; i++)
            {
                Chart0.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart0.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart0.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart0.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart0.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart0.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart0.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart0.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            Chart0.Series["Series1"].BorderWidth = 2;
            Chart0.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart0.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart0.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart0.Series["Series1"].LegendText = "획득점수";
            Chart0.Series["Series2"].LegendText = "평균점수";

            // popup
            this.ChartD.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartD.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartD.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartD.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartD.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartD.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartD.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartD.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartD.Series["Series1"].ShowLabelAsValue = true;
            this.ChartD.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartD.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartD.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartD.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartD.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartD.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartD.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartD.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartD.Series["Series1"].Points.Count; i++)
            {
                ChartD.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartD.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartD.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartD.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartD.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartD.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartD.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartD.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            ChartD.Series["Series1"].BorderWidth = 2;
            ChartD.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartD.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartD.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartD.Series["Series1"].LegendText = "획득점수";
            ChartD.Series["Series2"].LegendText = "평균점수";
        }
        Chart0.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(2).ToString();
        ChartD.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(2).ToString();
        #endregion
        
        //업적평가(MBO)       
        ugrdMBO.DataSource = dsReport.Tables[1];
        ugrdMBO.DataBind();
        
        //역량평가
        //평가별점수
        double[] yValues1 = new double[] { 0, 0, 0 };
        string[] xValues1 = new string[] { "," + this.IEST_STRINGNAME.Split(';').GetValue(6).ToString().Replace("평가", ""), "," + this.IEST_STRINGNAME.Split(';').GetValue(5).ToString().Replace("평가", ""), "," + this.IEST_STRINGNAME.Split(';').GetValue(4).ToString().Replace("평가", "") };
        if (dsReport.Tables[0].Rows.Count > 0)
        {
            yValues1 = new double[] { DataTypeUtility.GetToDouble(dsReport.Tables[0].Rows[0]["YVALUE3"]), DataTypeUtility.GetToDouble(dsReport.Tables[0].Rows[0]["YVALUE2"]), DataTypeUtility.GetToDouble(dsReport.Tables[0].Rows[0]["YVALUE1"]) };
        }
        Chart1.Series["Default"].Points.Clear();

        string markcolor = string.Empty;
        for (int i = 0; i < yValues1.Length; i++)
        {
            Chart1.Series["Default"].Points.AddXY(xValues1[i], yValues1[i]);
            Chart1.Series["Default"].Points[i].Label = yValues1[i].ToString();

            if (i == 0)
                markcolor = "#4773E2";
            else if (i == 1)
                markcolor = "#E97F29";
            else if (i == 2)
                markcolor = "#63D81D";

            Chart1.Series["Default"].Points[i].MarkerColor = System.Drawing.ColorTranslator.FromHtml(markcolor);
            Chart1.Series["Default"].Points[i].Color = System.Drawing.ColorTranslator.FromHtml(markcolor);
            Chart1.Series["Default"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#F4F4F4");
            Chart1.Series[0]["DrawingStyle"] = "Cylinder";
        }

        Chart1.Series["Default"]["FunnelLabelStyle"] = "Outside";
        Chart1.ChartAreas["Default"].Area3DStyle.Enable3D = true;
        Chart1.Series["Default"]["FunnelStyle"] = "YIsHeight";
        Chart1.Series["Default"]["FunnelOutsideLabelPlacement"] = "Left";
        Chart1.Series["Default"]["FunnelPointGap"] = "2";
        Chart1.Series["Default"]["Funnel3DDrawingStyle"] = "CircularBase";
        Chart1.Series["Default"]["Funnel3DRotationAngle"] = "10";
        Chart1.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
        Chart1.ChartAreas["Default"].AxisX.LineColor = System.Drawing.Color.LightGray;
        Chart1.Titles[0].Text = "평가점수";
        Chart1.Series["Default"].YValuesPerPoint = 32;


        #region -- 평가항목별 점수현황(공통역량평가)
        if (dsReport.Tables[2].Rows.Count > 0)
        {
            double[] yValues = new double[dsReport.Tables[2].Rows.Count];
            string[] xValues = new string[dsReport.Tables[2].Rows.Count];
            double[] y = new double[dsReport.Tables[2].Rows.Count];
            for (int i = 0; i < dsReport.Tables[2].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dsReport.Tables[2].Rows[i]["MY_POINT"]);
                xValues[i] = dsReport.Tables[2].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dsReport.Tables[2].Rows[i]["AVG_POINT"]);
            }
            this.Chart2.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart2.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;  
            // Set radar chart style (Area, Line or Marker)  
            this.Chart2.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart2.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart2.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart2.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart2.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart2.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart2.Series["Series1"].ShowLabelAsValue = true;
            this.Chart2.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart2.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart2.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart2.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart2.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart2.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart2.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart2.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart2.Series["Series1"].Points.Count; i++)
            {
                Chart2.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart2.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart2.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart2.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart2.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart2.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart2.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart2.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            Chart2.Series["Series1"].BorderWidth = 2;
            Chart2.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart2.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart2.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart2.Series["Series1"].LegendText = "획득점수";
            Chart2.Series["Series2"].LegendText = "평균점수";

            // popup
            this.ChartA.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartA.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartA.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartA.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartA.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartA.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartA.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartA.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartA.Series["Series1"].ShowLabelAsValue = true;
            this.ChartA.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartA.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartA.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartA.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartA.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartA.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartA.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartA.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartA.Series["Series1"].Points.Count; i++)
            {
                ChartA.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartA.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartA.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartA.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartA.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartA.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartA.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartA.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#63D81D");
            ChartA.Series["Series1"].BorderWidth = 2;
            ChartA.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartA.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartA.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartA.Series["Series1"].LegendText = "획득점수";
            ChartA.Series["Series2"].LegendText = "평균점수";
        }
        Chart2.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(4).ToString();
        ChartA.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(4).ToString();
        #endregion


        #region --평가항목별 점수현황(직무역량평가)
        if (dsReport.Tables[3].Rows.Count > 0)
        {
            double[] yValues = new double[dsReport.Tables[3].Rows.Count];
            string[] xValues = new string[dsReport.Tables[3].Rows.Count];
            double[] y = new double[dsReport.Tables[3].Rows.Count];
            for (int i = 0; i < dsReport.Tables[3].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dsReport.Tables[3].Rows[i]["MY_POINT"]);
                xValues[i] = dsReport.Tables[3].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dsReport.Tables[3].Rows[i]["AVG_POINT"]);
            }
            this.Chart3.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart3.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.Chart3.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart3.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart3.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart3.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart3.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart3.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart3.Series["Series1"].ShowLabelAsValue = true;
            this.Chart3.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart3.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart3.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart3.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart3.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart3.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart3.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart3.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart3.Series["Series1"].Points.Count; i++)
            {
                Chart3.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart3.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart3.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart3.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart3.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart3.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart3.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart3.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#E97F29");
            Chart3.Series["Series1"].BorderWidth = 2;
            Chart3.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart3.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart3.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart3.Series["Series1"].LegendText = "획득점수";
            Chart3.Series["Series2"].LegendText = "평균점수";

            //popup
            this.ChartB.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartB.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartB.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartB.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartB.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartB.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartB.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartB.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartB.Series["Series1"].ShowLabelAsValue = true;
            this.ChartB.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartB.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartB.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartB.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartB.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartB.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartB.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartB.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartB.Series["Series1"].Points.Count; i++)
            {
                ChartB.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartB.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartB.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartB.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartB.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartB.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartB.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartB.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#E97F29");
            ChartB.Series["Series1"].BorderWidth = 2;
            ChartB.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartB.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartB.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartB.Series["Series1"].LegendText = "획득점수";
            ChartB.Series["Series2"].LegendText = "평균점수";
        }
        Chart3.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(5).ToString();
        ChartB.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(5).ToString();
        #endregion

        #region --평가항목별 점수현황(리더역량평가)
        if (dsReport.Tables[4].Rows.Count > 0)
        {
            double[] yValues = new double[dsReport.Tables[4].Rows.Count];
            string[] xValues = new string[dsReport.Tables[4].Rows.Count];
            double[] y = new double[dsReport.Tables[4].Rows.Count];
            for (int i = 0; i < dsReport.Tables[4].Rows.Count; i++)
            {
                yValues[i] = DataTypeUtility.GetToDouble(dsReport.Tables[4].Rows[i]["MY_POINT"]);
                xValues[i] = dsReport.Tables[4].Rows[i]["Q_DFN_NAME"].ToString();
                y[i] = DataTypeUtility.GetToDouble(dsReport.Tables[4].Rows[i]["AVG_POINT"]);
            }
            this.Chart4.Series["Series1"].Points.DataBindY(yValues);
            // Set radar chart type  
            this.Chart4.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.Chart4.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.Chart4.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.Chart4.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.Chart4.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.Chart4.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.Chart4.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.Chart4.Series["Series1"].ShowLabelAsValue = true;
            this.Chart4.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.Chart4.ChartAreas["Default"].AxisX.Margin = true;
            this.Chart4.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.Chart4.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            Chart4.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            Chart4.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            Chart4.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            Chart4.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < Chart4.Series["Series1"].Points.Count; i++)
            {
                Chart4.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                Chart4.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //Chart4.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //Chart4.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //Chart4.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //Chart4.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            Chart4.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            Chart4.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#4773E2");
            Chart4.Series["Series1"].BorderWidth = 2;
            Chart4.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            Chart4.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            Chart4.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            Chart4.Series["Series1"].LegendText = "획득점수";
            Chart4.Series["Series2"].LegendText = "평균점수";

            //popup
            this.ChartC.Series["Series1"].Points.DataBindXY(xValues, yValues);
            // Set radar chart type  
            this.ChartC.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Radar;
            // Set radar chart style (Area, Line or Marker)  
            this.ChartC.Series["Series1"]["RadarDrawingStyle"] = "Line";
            this.ChartC.Series["Series2"]["RadarDrawingStyle"] = "Line";

            // Set circular area drawing style (Circle or Polygon)  
            this.ChartC.Series["Series1"]["AreaDrawingStyle"] = "Circle";
            // Set labels style (Auto, Horizontal, Circular or Radial)  
            this.ChartC.Series["Series1"]["CircularLabelsStyle"] = "Auto";
            // Show as 3D  
            this.ChartC.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            //Seris2  
            this.ChartC.Series["Series2"].Points.DataBindY(y);
            //设置显示数值  
            this.ChartC.Series["Series1"].ShowLabelAsValue = true;
            this.ChartC.Series["Series2"].ShowLabelAsValue = true;
            //设置X,Y之间是否有间隙  
            this.ChartC.ChartAreas["Default"].AxisX.Margin = true;
            this.ChartC.ChartAreas["Default"].AxisY.Margin = true;
            //设置X轴显示间隔为1,X轴数据比较多的时候比较有用  
            this.ChartC.ChartAreas["Default"].AxisX.LabelStyle.Interval = 1;
            //设置XY轴标题的名称所在位置位远  
            ChartC.ChartAreas["Default"].AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            //设置Y轴前面加箭头   
            ChartC.ChartAreas["Default"].AxisY.Arrows = Dundas.Charting.WebControl.ArrowsType.None;
            ChartC.ChartAreas["Default"].AxisY.LineColor = System.Drawing.Color.LightGray;
            ChartC.ChartAreas["Default"].AxisY.LabelStyle.Enabled = false;

            for (int i = 0; i < ChartC.Series["Series1"].Points.Count; i++)
            {
                ChartC.Series["Series1"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     
                ChartC.Series["Series2"].Points[i].MarkerStyle = Dundas.Charting.WebControl.MarkerStyle.None;//设置折点的风格     

                //ChartC.Series["Series1"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     
                //ChartC.Series["Series2"].Points[i].MarkerColor = System.Drawing.Color.Red;//设置seires中折点的颜色     

                //ChartC.Series["Series1"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#63D81D");
                //ChartC.Series["Series2"].Points[i].BorderColor = System.Drawing.ColorTranslator.FromHtml("#585858");
            }
            ChartC.ImageType = Dundas.Charting.WebControl.ChartImageType.Jpeg;
            ChartC.Series["Series1"].Color = System.Drawing.ColorTranslator.FromHtml("#4773E2");
            ChartC.Series["Series1"].BorderWidth = 2;
            ChartC.Series["Series2"].Color = System.Drawing.ColorTranslator.FromHtml("#585858");
            //反锯齿  
            ChartC.AntiAliasing = Dundas.Charting.WebControl.AntiAliasing.All;
            //调色板 磨沙:SemiTransparent  
            ChartC.Palette = Dundas.Charting.WebControl.ChartColorPalette.SemiTransparent;

            ChartC.Series["Series1"].LegendText = "획득점수";
            ChartC.Series["Series2"].LegendText = "평균점수";
        }
        Chart4.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(6).ToString();
        ChartC.Titles[0].Text = this.IEST_STRINGNAME.Split(';').GetValue(6).ToString();
        #endregion









    }

    private void DataBindReport() 
    {
        Biz_TermInfos termInfo  = new Biz_TermInfos(ESTTERM_REF_ID);
        ESTTERM_REF_NAME        = termInfo.EstTerm_Name;

        Biz_TermSubs termSub    = new Biz_TermSubs(COMP_ID, ESTTERM_SUB_ID);
        ESTTERM_SUB_NAME        = termSub.EstTerm_Sub_Name;

        Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, FROM_EST_ID);
        OwnerType ownerType     = BizUtility.GetOwnerType(estInfo.Owner_Type);

        //Biz_DeptInfos deptInfo  = new Biz_DeptInfos(TGT_DEPT_ID);
        //TGT_DEPT_NAME           = deptInfo.Dept_Name;
        MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info bizComDeptInfo = new MicroBSC.Integration.COM.Biz.Biz_Com_Dept_Info(TGT_DEPT_ID);
        TGT_DEPT_NAME           = bizComDeptInfo.DEPT_NAME;

        if(ownerType == OwnerType.Emp_User) 
        {
            Biz_EmpInfos empInfo    = new Biz_EmpInfos(TGT_EMP_ID);
            TGT_EMP_NAME            = empInfo.Emp_Name;
        }

        Biz_ReportDetails reportDetail  = new Biz_ReportDetails();
        DataSet ds                      = reportDetail.GetReportDetail(COMP_ID, FROM_EST_ID);
        GridView1.DataSource            = ds;
        GridView1.DataBind();
    }

    protected void rblFindType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblFindType.SelectedItem.Value == "03")
        {
            ddlListType.Visible = false;
            div03.Visible = true;
            div04.Visible = false;
        }
        else
        {
            ddlListType.Visible = false;// true;
            div03.Visible = false;
            div04.Visible = true;
        }

        //DataBindGraph();
        doBindingGraph();
    }


    protected void ddlListType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataBindGraph();
        doBindingGraph();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drw = (DataRowView)e.Row.DataItem;

        if(e.Row.RowType == DataControlRowType.DataRow) 
        {
            if(drw["RPT_ITM_ID"].ToString().Equals("ARRW")) 
            {
                Image img       = new Image();
                img.ImageUrl    = drw["BG_IMG_URL"].ToString();
                
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Controls.Add(img);
            }
            else if(drw["RPT_ITM_ID"].ToString().Equals("GRID")) 
            {
                Control userCtrl                    = LoadControl("USER_CTRL/EST_GRID.ascx");
                EST_USER_CTRL_EST_GRID grid         = (EST_USER_CTRL_EST_GRID)userCtrl;

                grid.Comp_ID                        = COMP_ID;
                grid.Est_ID                         = drw["EST_ID"].ToString();
                grid.EstTerm_Ref_ID                 = ESTTERM_REF_ID;
                grid.EstTerm_Sub_ID                 = (drw["ESTTERM_SUB_YN"].ToString().Equals("Y"))  ? DataTypeUtility.GetToInt32(drw["ESTTERM_SUB_ID"])  : ESTTERM_SUB_ID;
                grid.EstTerm_Step_ID                = (drw["ESTTERM_STEP_YN"].ToString().Equals("Y")) ? DataTypeUtility.GetToInt32(drw["ESTTERM_STEP_ID"]) : ESTTERM_STEP_ID;
                grid.Tgt_Dept_ID                    = TGT_DEPT_ID;
                grid.Tgt_Emp_ID                     = TGT_EMP_ID;
                grid.Est_Job_IDs                    = drw["EST_JOB_IDS"].ToString();
                grid.Est_Tgt_Type                   = drw["EST_TGT_TYPE"].ToString();
                grid.Year_YN                        = drw["YEAR_YN"].ToString();
                grid.Merge_YN                       = drw["MERGE_YN"].ToString();
                grid.Dept_Column_No_Use_Yn          = drw["DEPT_COLUMN_NO_USE_YN"].ToString();
                grid.EstTerm_Sub_All_Use_YN         = drw["ESTTERM_SUB_ALL_USE_YN"].ToString();
                grid.EstTerm_Step_All_Use_YN        = drw["ESTTERM_STEP_ALL_USE_YN"].ToString();
                grid.Title_Name                     = (drw["TITLE_NAME"] == DBNull.Value) ? drw["RPT_DTL_NAME"].ToString() : drw["TITLE_NAME"].ToString();
                grid.Title_Img_Url                  = drw["TITLE_IMG_URL"].ToString();
                grid.Rpt_Dtl_ID                     = drw["RPT_DTL_ID"].ToString();
                grid.Grid_Height                    = DataTypeUtility.GetToInt32(drw["GRID_HEIGHT"]);
                grid.Emp_Ref_ID                     = EMP_REF_ID;

                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Controls.Add(grid);
            }
            else if(drw["RPT_ITM_ID"].ToString().Equals("DESC")) 
            {
                Label lbl   = new Label();

                string htmlStr = @"<table border='1' cellpadding='2' cellspacing='0' bordercolor='cccccc'>
                                    <tr align='center'>
                                        <td bgcolor='dddddd'>
                                            <font color='#000000'>{0} {1}별 조정</font></td>
                                        <td>
                                            <span id='lblConStepText'>{2}(%) 비율로 조정(만약 평가 {3}일 경우는 {4}%로 조정)</span></td>
                                    </tr>
                                </table>";
                
                Biz_EstInfos estInfo        = new Biz_EstInfos(COMP_ID, drw["EST_ID"].ToString());
                Biz_ReportDetails rptDetail = new Biz_ReportDetails(drw["RPT_DTL_ID"].ToString(), COMP_ID, FROM_EST_ID);
                
                try 
                {
                    if(rptDetail.EstTerm_Sub_YN.Equals("Y")) 
                    {
                        string est_name             = estInfo.Est_Name;
                        string estterm_each_name    = "주기";
                        string estterm_each_weight  = BizUtility.GetWeightStringByEstTermSub(COMP_ID, drw["EST_ID"].ToString());
                        string estterm_each_only    = "주기가 1회";
                        double estterm_weight_total = BizUtility.GetTotalWeightEstTermSub(COMP_ID, drw["EST_ID"].ToString());

                        lbl.Text    = string.Format(htmlStr
                                                    , est_name
                                                    , estterm_each_name
                                                    , estterm_each_weight
                                                    , estterm_each_only
                                                    , estterm_weight_total);

                        e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[0].Controls.Add(lbl);
                    }
                    else if(rptDetail.EstTerm_Step_YN.Equals("Y")) 
                    {
                        string est_name             = estInfo.Est_Name;
                        string estterm_each_name    = "차수";
                        string estterm_each_weight  = BizUtility.GetWeightStringByEstTermStep(COMP_ID, drw["EST_ID"].ToString());
                        string estterm_each_only    = "차수가 1차";
                        double estterm_weight_total = BizUtility.GetTotalWeightEstTermStep(COMP_ID, drw["EST_ID"].ToString());

                        lbl.Text    = string.Format(htmlStr
                                                    , est_name
                                                    , estterm_each_name
                                                    , estterm_each_weight
                                                    , estterm_each_only
                                                    , estterm_weight_total);

                        e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[0].Controls.Add(lbl);
                    }
                }
                catch
                {
                
                }
            }
            else if(drw["RPT_ITM_ID"].ToString().Equals("GRAD")) 
            {
                string grade_html   = @"<table width='400px' border='1' cellpadding='0' cellspacing='0'>
                                            <tr align='center'>
                                                <td class='cssTblTitleSingle' width='90%'>
                                                    <strong>{0} 등급</strong></td>
                                                <td class='cssTblContent' width='10%'>
                                            <span id='lblConGrade' style='color:Maroon;font-size:Small;font-weight:bold;'>{1}</span>&nbsp; 등급</td>
                                            </tr>
                                        </table>";

                Biz_Datas data      = new Biz_Datas(  COMP_ID
                                                    , drw["EST_ID"].ToString()
                                                    , ESTTERM_REF_ID
                                                    , (drw["ESTTERM_SUB_YN"].ToString().Equals("Y"))  ? DataTypeUtility.GetToInt32(drw["ESTTERM_SUB_ID"])  : ESTTERM_SUB_ID
                                                    , (drw["ESTTERM_STEP_YN"].ToString().Equals("Y")) ? DataTypeUtility.GetToInt32(drw["ESTTERM_STEP_ID"]) : ESTTERM_STEP_ID
                                                    , 0
                                                    , 0
                                                    , TGT_DEPT_ID
                                                    , TGT_EMP_ID);

                if(!data.Grade_ID.Equals(""))
                {
                    Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, drw["EST_ID"].ToString());
                    Biz_Grades grade        = new Biz_Grades(COMP_ID, data.Grade_ID);

                    Label lbl   = new Label();
                    lbl.Text    = string.Format(grade_html, estInfo.Est_Name, grade.Grade_ID);

                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[0].Controls.Add(lbl);
                }
                //else 
                //{
                //    Biz_EstInfos estInfo    = new Biz_EstInfos(COMP_ID, drw["EST_ID"].ToString());

                //    Label lbl   = new Label();
                //    lbl.Text    = string.Format(grade_html, estInfo.Est_Name, "A");

                //    e.Row.Cells[0].Controls.Add(lbl);
                //}
            }
            else if(drw["RPT_ITM_ID"].ToString().Equals("HTML")) 
            {
                Control parserCtrl = this.ParseControl(DataTypeUtility.GetValue(drw["CUS_HTML"]));
                e.Row.Cells[0].Controls.Add(parserCtrl);
            }
        }
    }
}
