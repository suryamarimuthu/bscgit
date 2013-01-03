using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Infragistics.WebUI.UltraWebToolbar;
using System.Xml;
using MicroBSC.Common;

using MicroBSC.PRJ.Biz;
using MicroBSC.Biz.Common.Biz;
using System.Drawing;
using Dundas.Charting.WebControl;

public partial class PRJ_PRJ0102S3 : PrjPageBase
{
    private int _iPrjRefID = 0;
    private DataTable _dataTable = null;
    private Hashtable _htPoints = new Hashtable();

    public string PAGE_TYPE; // Nomal: N , Popup : P
    private string PRJ_TYPE;
    private string _readOnlyYN = "N";

    
    

    public string ICCB1
    {
        get
        {
            if (ViewState["CCB1"] == null)
            {
                ViewState["CCB1"] = GetRequest("CCB1", this.lBtnReload.ClientID.Replace('_', '$'));
            }

            return (string)ViewState["CCB1"];
        }
        set
        {
            ViewState["CCB1"] = value;
        }
    }

    public int IPrjRefID
    {
        get { return _iPrjRefID; }
        set { _iPrjRefID = value; }
    }

    public string READ_ONLY_YN
    {
        get { return _readOnlyYN; }
        set { _readOnlyYN = value; }
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        ltrScript.Text = "";
        PAGE_TYPE = WebUtility.GetRequest("PAGE_TYPE", "N");

        txtYear.ValueChange += new Infragistics.WebUI.WebDataInput.ValueChangeHandler(txtYear_ValueChange);
        if (!IsPostBack)
        {
            this.SetFormInit();
            this.SetPageType();
        }
        else
        {

        }        
    }

    #region 내부 함수

    private void SetPageType()
    {
        if (PAGE_TYPE.Equals("P"))
        {
            SetMenuControl(false, false, false);

            IPrjRefID = GetRequestByInt("PRJ_REF_ID", 0);
            PRJ_TYPE  = GetRequest("PRJ_TYPE", "");

            if (IPrjRefID > 0)
            {
                PageUtility.FindByValueDropDownList(ddlPrjType, this.IPrjRefID.ToString());
            }

            Biz_Prj_Info objPrjInfo      = new Biz_Prj_Info(IPrjRefID);
            Biz_Com_Code_Info objComCode = new Biz_Com_Code_Info();

            DataSet ds   = objComCode.GetProjectType(0);
            DataRow[] dr = ds.Tables[0].Select("ETC_CODE='" + PRJ_TYPE + "'");

            //ddlPrjType.Visible = false;
            //ddlPrjName.Visible = false;
            iBtnSearch.Visible = false;

            lblPrjTypeName.Visible = true;
            lblPrjName.Visible     = true;
            ImgClose.Visible       = true;

            lblPrjName.Text     = objPrjInfo.IPrj_Name;
            lblPrjTypeName.Text = dr[0].ItemArray[3].ToString(); //CODE_NAME
            BindGanttChart(IPrjRefID);

            pnlPrjInfo.Visible   = true;
            pnlPrjSearch.Visible = false;
        }
        else
        {
            pnlPrjInfo.Visible   = false;
            pnlPrjSearch.Visible = true;
            BindGanttChart(IPrjRefID);
        }

        // 프로젝트 책임자 또는 사업구성원이 아닐경우
        Biz_Prj_Info objPrj     = new Biz_Prj_Info(this.IPrjRefID);
        Biz_Prj_Resource objRes = new Biz_Prj_Resource(this._iPrjRefID, gUserInfo.Emp_Ref_ID);

        if (!objPrj.IsOwnerEmpIDYN(gUserInfo.Emp_Ref_ID, this.IPrjRefID)
            || (objRes == null) )
        {
            _readOnlyYN = "Y";
        }
        else if (objPrj.IsOwnerEmpIDYN(gUserInfo.Emp_Ref_ID, this.IPrjRefID) && objPrj.IComplete_YN == "Y")
        {
            _readOnlyYN = "Y";
        }
        else if( this.PAGE_TYPE == "N")
        {
             _readOnlyYN = "N";
        }
        else 
        {
             _readOnlyYN = "N";
        }

        Biz_Prj_Schedule objSch = new Biz_Prj_Schedule();        

        lblPROCEED_RATE.Text    = objSch.GetTotalRate(this.IPrjRefID, 0).ToString();
        lblActualEDate.Text     = (objPrj.IActual_End_Date == DBNull.Value)   ? "" : Convert.ToDateTime(objPrj.IActual_End_Date).ToShortDateString();
        lblActualSDate.Text     = (objPrj.IActual_Start_Date == DBNull.Value) ? "" : Convert.ToDateTime(objPrj.IActual_Start_Date).ToShortDateString();
        lblplanEDate.Text       = (objPrj.IPlan_End_Date == DBNull.Value)     ? "" : Convert.ToDateTime(objPrj.IPlan_End_Date).ToShortDateString();
        lblplanSDate.Text       = (objPrj.IPlan_Start_Date == DBNull.Value)   ? "" : Convert.ToDateTime(objPrj.IPlan_Start_Date).ToShortDateString();
        lblOWNER_DEPT_NAME.Text = objPrj.IOwner_Dept_Name;
        lblOWNER_EMP_NAME.Text  = objPrj.IOwner_Emp_Name;

        PageUtility.FindByValueDropDownList(ddlPRIORITY, objPrj.IPriority);
        lblPRIORITY.Text        = PageUtility.GetByTextDropDownList(ddlPRIORITY);

        lblTOTAL_BUDGET.Text    = objPrj.ITotal_Budget.ToString();
        lblREF_STG.Text         = objPrj.IRef_Stg;
        lblEFFECTIVENESS.Text   = objPrj.IEffectiveness;
        lblRANGE.Text           = objPrj.IRange;
        lblPRJ_TYPE.Text        = PageUtility.GetByTextDropDownList(ddlPrjType);        
    }


    public void SetFormInit()
    {
        Biz_Com_Code_Info codeinfo = new Biz_Com_Code_Info();
        codeinfo.GetProjectType(ddlPrjType, -1, true, 120);
        codeinfo.GetProjectPriority(ddlPRIORITY, 0, false, 250);

        ListItem itemA = new ListItem("----------", "0");
        ddlPrjName.Items.Insert(0, itemA);
        txtYear.Value = DateTime.Now.Year;
    }

    private void BindGanttChart(int iPrjRefID)
    {
        IPrjRefID = iPrjRefID;

        if(PAGE_TYPE.Equals("N"))
            _iPrjRefID = WebUtility.GetIntByValueDropDownList(ddlPrjName);

        if (PAGE_TYPE.Equals("N") && _iPrjRefID < 1)
        {
            return;
        }            

        Biz_Prj_Schedule objSchedule = new Biz_Prj_Schedule();
        objSchedule.IPrj_Ref_Id = IPrjRefID;
        DataSet ds = objSchedule.GetAllList(objSchedule.IPrj_Ref_Id, 0);

        if (ds.Tables.Count == 0 && ds.Tables[0].Rows.Count == 0)
            return;

        DataSet tmpDs = ds.Clone();

        ds.Relations.Add("NodeRelation"
                        , ds.Tables[0].Columns["TASK_REF_ID"]
                        , ds.Tables[0].Columns["UP_TASK_REF_ID"]
                        , false);

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (DataTypeUtility.GetToInt32(dbRow["UP_TASK_REF_ID"]) == 0)
            {
                tmpDs.Tables[0].ImportRow(dbRow);
                PopulateScheduleTree(dbRow,tmpDs);
            }
        }

        _dataTable = tmpDs.Tables[0];

        // Set Gantt chart type
        Chart1.Series["Tasks"].Type    = SeriesChartType.Gantt;
        Chart1.Series["Progress"].Type = SeriesChartType.Gantt;

        Chart1.Legends["Default"].Enabled = true;

        Chart1.ChartAreas["Default"].AxisX.MajorGrid.Interval = 2;
        Chart1.ChartAreas["Default"].AxisX.LabelsAutoFit = false;

        Chart1.ChartAreas["Default"].AxisX.Interval = 1;
        Chart1.ChartAreas["Default"].AxisX.Reverse = true;

        Chart1.ChartAreas["Default"].AxisY.LabelStyle.Format = "yy.MM.dd";
        //Chart1.ChartAreas["Default"].AxisY.MajorGrid.Interval = 28;
        //Chart1.ChartAreas["Default"].AxisY.Interval = 10;
        Chart1.ChartAreas["Default"].AxisY.LabelsAutoFitStyle ^= LabelsAutoFitStyle.IncreaseFont;
        Chart1.ChartAreas["Default"].AxisY.LabelsAutoFit = true;
        
        Chart1.ChartAreas["Default"].Area3DStyle.Enable3D = false;
        Chart1.Series["Progress"]["DrawSideBySide"] = "false";
        Chart1.Series["Tasks"]["DrawSideBySide"]    = "false";

        Chart1.Series["Tasks"]["PointWidth"] = "0.7";
        Chart1.Series["Progress"]["PointWidth"] = "0.4";

        //Chart1.BackColor = Color.White;
        //Chart1.BackGradientType = GradientType.None;
        //Chart1.BorderColor = Color.Gray;
        //Chart1.BorderLineStyle = ChartDashStyle.Solid;
        //Chart1.BorderStyle = ChartDashStyle.NotSet;

        _htPoints.Clear();

        for (int i = 0; i < _dataTable.Rows.Count; i++)
        {
            DataRow row = _dataTable.Rows[i];

            object oPlanStartDate   = row["PLAN_START_DATE"];
            object oPlanEndDate     = row["PLAN_END_DATE"];
            object oActualStartDate = row["ACTUAL_START_DATE"];
            object oActualEndDate   = row["ACTUAL_END_DATE"];

            if (oPlanStartDate.ToString() == oPlanEndDate.ToString() && oPlanEndDate != DBNull.Value)
                oPlanEndDate = (object)DataTypeUtility.GetToDateTime(oPlanEndDate).AddDays(1);

            if (oActualStartDate.ToString() == oActualEndDate.ToString() && oActualEndDate != DBNull.Value)
                oActualEndDate = (object)DataTypeUtility.GetToDateTime(oActualEndDate).AddDays(1);

            if (oPlanStartDate != DBNull.Value && oPlanEndDate != DBNull.Value)
            {
                Chart1.Series["Tasks"].Points.AddXY(i, oPlanStartDate, oPlanEndDate);
            }
            else
            {
                Chart1.Series["Tasks"].Points.AddXY(i, null, null);
            }

            if (oActualStartDate == DBNull.Value || oActualStartDate == null)
            {
                oActualStartDate = null;
            }

            if (oActualEndDate == DBNull.Value || oActualEndDate == null)
            {
                oActualEndDate = null;
            }

            if (oActualStartDate == null || oActualEndDate == null)
            {
                oActualStartDate = null;
                oActualEndDate   = null;
            }

            //if (oActualStartDate == DBNull.Value && oActualEndDate != null)
            //    oActualStartDate =  oPlanStartDate;

            //if (oActualStartDate != DBNull.Value && (oActualEndDate == null || oActualEndDate == DBNull.Value))
            //    oActualEndDate    = oPlanEndDate;

            Chart1.Series["Progress"].Points.AddXY(i, oActualStartDate, oActualEndDate);

            //Chart1.Series["Tasks"].Points.AddXY(i, row["PLAN_START_DATE"], row["PLAN_END_DATE"]);

            //Chart1.Series["Progress"].Points.AddXY(i, row["ACTUAL_START_DATE"], row["ACTUAL_END_DATE"]);

            Chart1.Series["Tasks"].Points[i].AxisLabel = row["TASK_NAME"].ToString();
            Chart1.Series["Progress"].Points[i].AxisLabel = row["TASK_NAME"].ToString();

            //Chart1.Series["Tasks"].Points[i].ToolTip = "계획기간 : " + DataTypeUtility.GetToDateTimeText(row["PLAN_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["PLAN_END_DATE"]);
            //Chart1.Series["Progress"].Points[i].ToolTip = "계획기간 : " + DataTypeUtility.GetToDateTimeText(row["PLAN_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["PLAN_END_DATE"]);
            //Chart1.Series["Progress"].Points[i].ToolTip = "실행기간 : " + DataTypeUtility.GetToDateTimeText(row["ACTUAL_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["ACTUAL_END_DATE"]);

            if (DataTypeUtility.GetToInt32(row["UP_TASK_REF_ID"]) > 0)
            {
                Chart1.Series["Tasks"].Points[i].ToolTip = "계획기간 : " + DataTypeUtility.GetToDateTimeText(row["PLAN_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["PLAN_END_DATE"]) + "\r\n" +
                                                           "실행기간 : " + DataTypeUtility.GetToDateTimeText(row["ACTUAL_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["ACTUAL_END_DATE"]);

                Chart1.Series["Progress"].Points[i].ToolTip = "계획기간 : " + DataTypeUtility.GetToDateTimeText(row["PLAN_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["PLAN_END_DATE"]) + "\r\n" +
                                                              "실행기간 : " + DataTypeUtility.GetToDateTimeText(row["ACTUAL_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["ACTUAL_END_DATE"]);
            }
            else
            {
                DataSet actualDs = objSchedule.GetActualDate(this.IPrjRefID);

                Chart1.Series["Tasks"].Points[i].ToolTip = "계획기간 : " + DataTypeUtility.GetToDateTimeText(row["PLAN_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["PLAN_END_DATE"]) + "\r\n" +
                                                                          "실행기간 : " + DataTypeUtility.GetToDateTimeText(actualDs.Tables[0].Rows[0]["ACTUAL_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(actualDs.Tables[0].Rows[0]["ACTUAL_END_DATE"]);

                Chart1.Series["Progress"].Points[i].ToolTip = "계획기간 : " + DataTypeUtility.GetToDateTimeText(row["PLAN_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(row["PLAN_END_DATE"]) + "\r\n" +
                                                              "실행기간 : " + DataTypeUtility.GetToDateTimeText(actualDs.Tables[0].Rows[0]["ACTUAL_START_DATE"]) + " ~ " + DataTypeUtility.GetToDateTimeText(actualDs.Tables[0].Rows[0]["ACTUAL_END_DATE"]);
            }

            if (DataTypeUtility.GetToInt32(row["UP_TASK_REF_ID"]) > 0)
            {
                Chart1.Series["Tasks"].Points[i].Href = "javascript:OpenSchedule('" + row["TASK_REF_ID"].ToString() + "');";
                Chart1.Series["Progress"].Points[i].Href = "javascript:OpenSchedule('" + row["TASK_REF_ID"].ToString() + "');";
            }

            //Chart1.Series["Tasks"].Points[i].Label = Chart1.Series["Tasks"].Points[i].XValue.ToString(); 

            _htPoints.Add(row["TASK_REF_ID"], Chart1.Series["Tasks"].Points[i]);
        }
    }

    private void PopulateScheduleTree(DataRow dbRow, DataSet ds)
    {
        foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation"))
        {
            ds.Tables[0].ImportRow(childRow);

            PopulateScheduleTree(childRow, ds);
        }
    }

    private DataPoint GetSeriesPoint(object key)
    {
        DataPoint obj = null;

        for (int i = 0; i < _htPoints.Count; i++)
        {
            if (_htPoints.ContainsKey(key))
                obj = (DataPoint)_htPoints[key];
        }

        return obj;
    }

    private void DrawArrow(Graphics graph, Color brushcolor, PointF p1, PointF p2, double angle_deg)
    {

        double rad = angle_deg * Math.PI / 180;

        // to simplify calcuations find dx and dy for points p1 and p2
        double dx = p1.X - p2.X;
        double dy = p1.Y - p2.Y;

        double c = Math.Sqrt((Math.Pow(dx, 2) + Math.Pow(dy, 2)));

        double pixels = 8;
        double line_length = (1 / (c / pixels));

        PointF arrow_segment1 = Point.Empty;
        PointF arrow_segment2 = Point.Empty;

        arrow_segment1.X = p1.X - (float)((dx * Math.Cos(rad) - dy * Math.Sin(rad)) * line_length);
        arrow_segment1.Y = p1.Y - (float)((dy * Math.Cos(rad) + dx * Math.Sin(rad)) * line_length);

        arrow_segment2.X = p1.X - (float)((dx * Math.Cos(-rad) - dy * Math.Sin(-rad)) * line_length);
        arrow_segment2.Y = p1.Y - (float)((dy * Math.Cos(-rad) + dx * Math.Sin(-rad)) * line_length);

        PointF[] arrowhead =	{
										p1,
										arrow_segment1,
										arrow_segment2
									};

        SolidBrush brush = new SolidBrush(brushcolor);
        graph.FillPolygon(brush, arrowhead);

    }
    #endregion

    
    protected void Chart1_PostPaint(object sender, Dundas.Charting.WebControl.ChartPaintEventArgs e)
    {
        if (sender is ChartArea)
        {
            Series series = Chart1.Series["Tasks"];
            // Take Graphics object from chart
            Graphics graph = e.ChartGraphics.Graphics;

            if (_dataTable == null)
                return;

            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                DataRow row = _dataTable.Rows[i];

                DataPoint chdObj = GetSeriesPoint(row["TASK_REF_ID"]);
                DataPoint obj = GetSeriesPoint(row["AFTER_TASK_REF_ID"]);

                if (obj != null && chdObj != null)
                {
                    double p1X, p2X, p1Y, p2Y;

                    p1X = obj.XValue;
                    p2X = chdObj.XValue;
                    p1Y = obj.YValues[1];
                    p2Y = chdObj.YValues[0];
                
                    if ((i + 1) <= series.Points.Count && i != 0)
                    {
                        float pixelX1 = (float)e.ChartGraphics.GetPositionFromAxis("Default", AxisName.Y, p1Y);
                        float pixelY1 = (float)e.ChartGraphics.GetPositionFromAxis("Default", AxisName.X, p1X);
                        float pixelX2 = (float)e.ChartGraphics.GetPositionFromAxis("Default", AxisName.Y, p2Y);
                        float pixelY2 = (float)e.ChartGraphics.GetPositionFromAxis("Default", AxisName.X, p2X);

                        PointF point1 = PointF.Empty;
                        PointF point2 = PointF.Empty;
                        PointF point3 = PointF.Empty;

                        point1.X = pixelX1;
                        point1.Y = pixelY1;
                        point2.X = pixelX2;
                        point2.Y = pixelY2;

                        // make the middle right-angle point
                        point3.X = pixelX2;
                        point3.Y = pixelY1;

                        // Convert relative coordinates to absolute coordinates.
                        point1 = e.ChartGraphics.GetAbsolutePoint(point1);
                        point2 = e.ChartGraphics.GetAbsolutePoint(point2);
                        point3 = e.ChartGraphics.GetAbsolutePoint(point3);

                        // Draw connection line
                        graph.DrawLine(new Pen(Color.Black, 1), point1, point3);
                        graph.DrawLine(new Pen(Color.Black, 1), point3, point2);

                        DrawArrow(graph, Color.Black, point2, point3, 20.5);
                    }
                }
            }
        }
    }
    protected void iBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindGanttChart(IPrjRefID);
    }
    protected void ddlPrjType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iYear = 0;
        bool isInt = int.TryParse(txtYear.Value.ToString(), out iYear);

        WebCommon.SetProjectListDropDownList(ddlPrjName, true, EMP_REF_ID, PageUtility.GetByValueDropDownList(ddlPrjType), iYear);
    }
    void txtYear_ValueChange(object sender, Infragistics.WebUI.WebDataInput.ValueChangeEventArgs e)
    {
        int iYear = 0;
        bool isInt = int.TryParse(txtYear.Value.ToString(), out iYear);

        WebCommon.SetProjectListDropDownList(ddlPrjName, true, EMP_REF_ID, PageUtility.GetByValueDropDownList(ddlPrjType), iYear);
    }
    protected void lBtnReload_Click(object sender, EventArgs e)
    {
        BindGanttChart(IPrjRefID);
    }

    protected void ddlPrjName_SelectedIndexChanged(object sender, EventArgs e)
    {

        //IPrjRefID = Convert.ToInt32(((DropDownList)sender).SelectedValue);

        //BindGanttChart(IPrjRefID);
    }
}
