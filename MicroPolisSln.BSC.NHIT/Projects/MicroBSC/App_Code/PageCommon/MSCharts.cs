using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
//using Dundas.Charting.WebControl;


using System.Web.UI.DataVisualization.Charting;

/// <summary>
/// Summary description for DundasCharts
/// </summary>
namespace MicroCharts
{
    public enum MsGradientType
    {
        None = 0,
        LeftRight = 1,
        TopBottom = 2,
        Center = 3,
        DiagonalLeft = 4,
        DiagonalRight = 5,
        HorizontalCenter = 6,
        VerticalCenter = 7,
    }

    public enum MsAntiAliasing
    {
        None = 0,
        Text = 1,
        Graphics = 2,
        All = 3,
    }

    public enum MsChartImageAlign
    {
        TopLeft = 0,
        Top = 1,
        TopRight = 2,
        Right = 3,
        BottomRight = 4,
        Bottom = 5,
        BottomLeft = 6,
        Left = 7,
        Center = 8,
    }

    public class MSCharts
    {
        #region ===================================== [ Chart Scope ] =====================================
        
        /// <summary>
        /// 차트 기본 설정 오버로드 1
        /// </summary>
        /// <param name="chart">설정할 차트ID</param>
        /// <param name="chartImageType">차트 타입</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public static void DundasChartBase(Chart chart
                                            , ChartImageType chartImageType
                                            , int width
                                            , int height)
        {
            DundasChartBase(chart
                            , chartImageType
                            , width
                            , height
                            , BorderSkinStyle.None
                            , Color.Empty, -1
                            , Color.Empty
                            , Color.Empty
                            , Color.Empty
                            , ChartDashStyle.NotSet
                            , -1
                            , ChartHatchStyle.None
                            , MsGradientType.None
                            , MsAntiAliasing.None
                            , null
                            , ChartImageWrapMode.Unscaled
                            , MsChartImageAlign.TopRight
                            , Color.Empty);
        }

        public static void DundasChartBase(Chart chart
                                        , ChartImageType chartImageType
                                        , int width
                                        , int height
                                        , BorderSkinStyle borderSkinStyle
                                        , Color borderLineColor
                                        , int borderLineWidth
            )
        {
            DundasChartBase(chart
                            , chartImageType
                            , width
                            , height
                            , borderSkinStyle
                            , borderLineColor
                            , borderLineWidth
                            , Color.Empty
                            , Color.Empty
                            , Color.Empty
                            , ChartDashStyle.NotSet
                            , -1
                            , ChartHatchStyle.None
                            , MsGradientType.None
                            , MsAntiAliasing.None
                            , null
                            , ChartImageWrapMode.Unscaled
                            , MsChartImageAlign.TopRight
                            , Color.Empty);
        }

        public static void DundasChartBase(Chart chart
                                            , ChartImageType chartImageType
                                            , int width
                                            , int height
                                            , BorderSkinStyle borderSkinStyle
                                            , Color borderLineColor
                                            , int borderLineWidth
                                            , Color backColor
                                            , Color backGradientEndColor
            )
        {
            DundasChartBase(chart
                            , chartImageType
                            , width
                            , height
                            , borderSkinStyle
                            , borderLineColor
                            , borderLineWidth
                            , backColor
                            , backGradientEndColor
                            , Color.Empty
                            , ChartDashStyle.NotSet
                            , -1
                            , ChartHatchStyle.None
                            , MsGradientType.None
                            , MsAntiAliasing.None
                            , null
                            , ChartImageWrapMode.Unscaled
                            , MsChartImageAlign.TopRight
                            , Color.Empty);
        }

        public static void DundasChartBase(Chart chart
                                            , ChartImageType chartImageType
                                            , int width
                                            , int height
                                            , BorderSkinStyle borderSkinStyle
                                            , Color borderLineColor
                                            , int borderLineWidth
                                            , Color backColor
                                            , Color backGradientEndColor
                                            , MsAntiAliasing antiAliasing
            )
        {
            DundasChartBase(chart
                            , chartImageType
                            , width
                            , height
                            , borderSkinStyle
                            , borderLineColor
                            , borderLineWidth
                            , backColor
                            , backGradientEndColor
                            , Color.Empty
                            , ChartDashStyle.NotSet
                            , -1
                            , ChartHatchStyle.None
                            , MsGradientType.None
                            , antiAliasing
                            , null
                            , ChartImageWrapMode.Unscaled
                            , MsChartImageAlign.TopRight
                            , Color.Empty);
        }

        public static void DundasChartBase(Chart chart
                                            , ChartImageType chartImageType
                                            , int width
                                            , int height
                                            , BorderSkinStyle borderSkinStyle
                                            , Color borderLineColor
                                            , int borderLineWidth
                                            , Color backColor
                                            , Color backGradientEndColor
                                            , Color borderColor
                                            , ChartDashStyle borderStyle
                                            , int borderWidth
                                            , MsAntiAliasing antiAliasing
            )
        {
            DundasChartBase(chart
                            , chartImageType
                            , width
                            , height
                            , borderSkinStyle, borderLineColor, borderLineWidth
                            , backColor, backGradientEndColor
                            , borderColor, borderStyle, borderWidth
                            , ChartHatchStyle.None
                            , MsGradientType.None
                            , antiAliasing
                            , null
                            , ChartImageWrapMode.Unscaled
                            , MsChartImageAlign.TopRight
                            , Color.Empty);
        }

        public static void DundasChartBase(Chart chart
                                            , ChartImageType chartImageType
                                            , int width
                                            , int height
                                            , BorderSkinStyle borderSkinStyle
                                            , Color borderLineColor
                                            , int borderLineWidth
                                            , Color backColor
                                            , Color backGradientEndColor
                                            , Color borderColor
                                            , ChartDashStyle chartDashStyle
                                            , int borderWidth
                                            , ChartHatchStyle chartHatchStyle
                                            , MsGradientType gradientType
                                            , MsAntiAliasing antiAliasing
            )
        {
            DundasChartBase(chart
                            , chartImageType
                            , width, height
                            , borderSkinStyle
                            , borderLineColor
                            , borderLineWidth
                            , backColor
                            , backGradientEndColor
                            , borderColor
                            , chartDashStyle
                            , borderWidth
                            , chartHatchStyle
                            , gradientType
                            , antiAliasing
                            , null
                            , ChartImageWrapMode.Unscaled
                            , MsChartImageAlign.TopRight
                            , Color.Empty);
        }

        public static void DundasChartBase(Chart chart
                                            , ChartImageType chartImageType
                                            , int width
                                            , int height
                                            , BorderSkinStyle borderSkinStyle
                                            , Color borderLineColor
                                            , int borderLineWidth
                                            , Color backColor
                                            , Color backGradientEndColor
                                            , Color borderColor
                                            , ChartDashStyle borderStyle
                                            , int borderWidth
                                            , ChartHatchStyle chartHatchStyle
                                            , MsGradientType gradientType
                                            , MsAntiAliasing antiAliasing
                                            , string backImage
                                            , ChartImageWrapMode backImageMode
                                            , MsChartImageAlign backImageAlign
                                            , Color backImageTranspColor)
        {
            chart.ImageType = chartImageType;

            if(width != -1)
                chart.Width = width;

            if (height != -1)
                chart.Height = height;

            if (borderSkinStyle != BorderSkinStyle.None)
                chart.BorderSkin.SkinStyle = borderSkinStyle;

            if (!borderLineColor.Equals(Color.Empty))
            {
                chart.BorderlineColor = borderLineColor;
            }

            if (borderLineWidth != -1)
                chart.BorderlineWidth = borderLineWidth;

            if (!backColor.Equals(Color.Empty))
                chart.BackColor = backColor;
            // Set Back Gradient End Color
            if (!backGradientEndColor.Equals(Color.Empty))
            {
                //chart.BackGradientEndColor = backGradientEndColor;
                chart.BackColor = backGradientEndColor;
            }

            // Set Hatch Style
            // Set Border Color
            if (!borderColor.Equals(Color.Empty))
                chart.BorderColor = borderColor;
            // Set Border Style
            if (borderStyle != ChartDashStyle.NotSet)
                chart.BorderlineDashStyle = borderStyle;
            // Set Border Width
            if(borderWidth != -1)
                chart.BorderWidth = borderWidth;

            if (chartHatchStyle != ChartHatchStyle.None)
                chart.BackHatchStyle = chartHatchStyle;
            if (gradientType != MsGradientType.None)
            {
                chart.BackGradientStyle = (GradientStyle)gradientType;
            }

            if (antiAliasing != MsAntiAliasing.None)
            {
                chart.AntiAliasing = (AntiAliasingStyles)antiAliasing;
            }

            if (backImage != null)
            {
                chart.BackImage         = backImage;
                chart.BackImageWrapMode     = backImageMode;
                chart.BackImageAlignment    = (ChartImageAlignmentStyle)backImageAlign;
                //chart.ImageStorageMode = ImageStorageMode.UseHttpHandler;

                if (!backImageTranspColor.Equals(Color.Empty))
                {
                    //chart.BackImageTransparentColor = backImageTranspColor;
                    chart.BackImageTransparentColor = backImageTranspColor;
                }
            }
        }

        public static void GetDefaultChart(Chart iChart, ChartImageType chtImgType, int iWidth, int iHeight, bool bEnable3D, bool bEnableLegend, bool bChartAreaAutoPosition)
        {
            // Chart Setting
            iChart.ImageType = chtImgType;
            iChart.Width     = iWidth;
            iChart.Height    = iHeight;

            iChart.BorderWidth          = 1;
            iChart.BorderSkin.SkinStyle = BorderSkinStyle.Raised;
            iChart.BorderlineColor      = ColorTranslator.FromHtml("#B0B4BF");
            iChart.BackColor            = ColorTranslator.FromHtml("#D3DEEF");
            //iChart.BackGradientEndColor = ColorTranslator.FromHtml("#F9FAFC");
            iChart.BackColor = ColorTranslator.FromHtml("#F9FAFC");
            iChart.BorderColor          = Color.FromArgb(0x20, 0x80, 0xD0);
            //iChart.BorderlineDashStyle      = ChartDashStyle.Solid;
            iChart.BorderlineDashStyle = ChartDashStyle.Solid;
            iChart.BorderWidth          = 0;
            iChart.BackHatchStyle       = ChartHatchStyle.None;
            iChart.BackGradientStyle = GradientStyle.TopBottom;
            //iChart.MsAntiAliasing         = MsAntiAliasing.Graphics;
            iChart.AntiAliasing = AntiAliasingStyles.Graphics;
            //iChart.Palette              = ChartColorPalette.Dundas;
            iChart.Palette = ChartColorPalette.None;

            // Chart Legend Setting
            //iChart.Legends.Clear();
            if (bEnableLegend)
            {
                iChart.Legends.Add("Legend");
                Legend FstLegend = iChart.Legends[0];

                FstLegend.Enabled     = true;
                FstLegend.BackColor   = Color.Transparent;
                //FstLegend.Docking     = LegendDocking.Top;
                FstLegend.Docking = Docking.Top;
                FstLegend.Alignment   = StringAlignment.Far;
                FstLegend.LegendStyle = LegendStyle.Column;
            }
            else
            {
                iChart.Legends.Clear();
            }
            
            // ChartArea Setting
            iChart.ChartAreas.Clear();
            iChart.ChartAreas.Add("Default");
            ChartArea FstChtArea = iChart.ChartAreas["Default"];

            FstChtArea.BackColor            = ColorTranslator.FromHtml("#CFDCEF");
            //FstChtArea.BackGradientEndColor = ColorTranslator.FromHtml("#EFF3F9");
            FstChtArea.BackImageTransparentColor = ColorTranslator.FromHtml("#EFF3F9");
            FstChtArea.BorderColor          = Color.Transparent;
            FstChtArea.BorderDashStyle          = ChartDashStyle.NotSet;
            FstChtArea.BorderWidth          = 0;
            FstChtArea.BackHatchStyle       = ChartHatchStyle.None;
            
            FstChtArea.ShadowOffset         = 0;
            FstChtArea.ShadowColor          = Color.Transparent;
            FstChtArea.Area3DStyle.Enable3D = true;
            FstChtArea.BackImage            = "";
            //FstChtArea.BackImageAlignment       = MsChartImageAlign.Left;
            //FstChtArea.BackImageWrapMode        = ChartImageWrapMode.Scaled;
            //FstChtArea.BackImageTransparentColor = Color.Transparent;
            //FstChtArea.BackGradientType = MsGradientType.TopBottom;

            FstChtArea.BackImageAlignment = (ChartImageAlignmentStyle)MsChartImageAlign.Left;
            FstChtArea.BackImageWrapMode = ChartImageWrapMode.Scaled;
            FstChtArea.BackImageTransparentColor = Color.Transparent;
            FstChtArea.BackGradientStyle = GradientStyle.TopBottom;

            FstChtArea.Position.Auto        = bChartAreaAutoPosition;
            if (!bChartAreaAutoPosition)
            {
                FstChtArea.Position.X       = 0;
                FstChtArea.Position.Y       = 30;
                FstChtArea.Position.Height  = float.Parse("98");
                FstChtArea.Position.Width   = float.Parse("98");
            }

            FstChtArea.Area3DStyle.Enable3D  = bEnable3D;
            FstChtArea.Area3DStyle.WallWidth = 3;
            //FstChtArea.Area3DStyle.XAngle    = 15;
            //FstChtArea.Area3DStyle.YAngle    = 10;
            //FstChtArea.Area3DStyle.Light     = LightStyle.Realistic;
            FstChtArea.Area3DStyle.LightStyle = LightStyle.Realistic;

            // Setting AXis
            iChart.Titles.Clear();
            Font fnt = new Font("Tahoma", 10F, GraphicsUnit.Pixel);
            foreach (Axis ax in FstChtArea.Axes)
            { 
                ax.Enabled             = AxisEnabled.Auto;
                //ax.LabelsAutoFit       = false;
                ax.IsLabelAutoFit = false;
                ax.LabelStyle.Font     = fnt;
                ax.LineColor           = ColorTranslator.FromHtml("#C4C4C4");
                ax.LineWidth           = 1;
                ax.MajorGrid.Enabled   = true;
                ax.MajorGrid.LineColor = ColorTranslator.FromHtml("#C4C4C4");
                //ax.LineStyle           = ChartDashStyle.Solid;
                ax.LineDashStyle = ChartDashStyle.Solid;
            }
        }

        #endregion

        #region ===================================== [ ChartArea Scope ] =====================================

        public static void SetChartArea(ChartArea chartArea, bool enable3D)
        {
            SetChartArea(chartArea
                        , Color.Empty
                        , Color.Empty
                        , Color.Empty
                        , ChartDashStyle.Solid
                        , -1
                        , ChartHatchStyle.None
                        , MsGradientType.None
                        , -1
                        , Color.Empty
                        , enable3D
                        , null
                        , MsChartImageAlign.TopRight
                        , ChartImageWrapMode.Unscaled
                        , Color.Empty);
        }

        public static void SetChartArea(ChartArea chartArea
                                        , Color backColor
                                        , Color backGradientEndColor
                                        , Color borderColor
                                        , ChartDashStyle borderStyle
                                        , int borderWidth
                                        , bool enable3D)
        {
            SetChartArea(chartArea
                        , backColor
                        , backGradientEndColor
                        , borderColor
                        , borderStyle
                        , borderWidth
                        , ChartHatchStyle.None
                        , MsGradientType.None
                        , -1
                        , Color.Empty
                        , enable3D
                        , null
                        , MsChartImageAlign.TopRight
                        , ChartImageWrapMode.Unscaled
                        , Color.Empty);
        }

        public static void SetChartArea(ChartArea chartArea
                                        , Color backColor
                                        , Color backGradientEndColor
                                        , Color borderColor
                                        , ChartDashStyle borderStyle
                                        , int borderWidth
                                        , ChartHatchStyle chartHatchStyle
                                        , MsGradientType gradientType
                                        , bool enable3D)
        {
            SetChartArea(chartArea
                        , backColor
                        , backGradientEndColor
                        , borderColor
                        , borderStyle
                        , borderWidth
                        , chartHatchStyle
                        , gradientType
                        , -1
                        , Color.Empty
                        , enable3D
                        , null
                        , MsChartImageAlign.TopRight
                        , ChartImageWrapMode.Unscaled
                        , Color.Empty);
        }

        public static void SetChartArea(ChartArea chartArea
                                        , Color backColor
                                        , Color backGradientEndColor
                                        , Color borderColor
                                        , ChartDashStyle borderStyle
                                        , int borderWidth
                                        , ChartHatchStyle chartHatchStyle
                                        , MsGradientType gradientType
                                        , int shadowOffset
                                        , Color shadowColor
            )
        {
            SetChartArea(chartArea
                        , backColor
                        , backGradientEndColor
                        , borderColor
                        , borderStyle
                        , borderWidth
                        , chartHatchStyle
                        , gradientType
                        , shadowOffset
                        , shadowColor
                        , false
                        , null
                        , MsChartImageAlign.TopRight
                        , ChartImageWrapMode.Unscaled
                        , Color.Empty);
        }

        public static void SetChartArea(ChartArea chartArea
                                        , Color backColor
                                        , Color backGradientEndColor
                                        , Color borderColor
                                        , ChartDashStyle borderStyle
                                        , int borderWidth
                                        , ChartHatchStyle chartHatchStyle
                                        , MsGradientType gradientType
                                        , int shadowOffset
                                        , Color shadowColor
                                        , bool enable3D)
        {
            SetChartArea(chartArea
                        , backColor
                        , backGradientEndColor
                        , borderColor
                        , borderStyle
                        , borderWidth
                        , chartHatchStyle
                        , gradientType
                        , shadowOffset
                        , shadowColor
                        , enable3D
                        , null
                        , MsChartImageAlign.TopRight
                        , ChartImageWrapMode.Unscaled
                        , Color.Empty);
        }

        public static void SetChartArea(ChartArea chartArea
                                        , Color backColor
                                        , Color backGradientEndColor
                                        , Color borderColor
                                        , ChartDashStyle borderStyle
                                        , int borderWidth
                                        , ChartHatchStyle chartHatchStyle
                                        , MsGradientType gradientType
                                        , int shadowOffset
                                        , Color shadowColor
                                        , bool enable3D
                                        , string backImage
                                        , MsChartImageAlign chartImageAlign
                                        , ChartImageWrapMode chartImageWrapMode
                                        , Color backImageTranspColor) 
        {
            if (!backColor.Equals(Color.Empty))
                chartArea.BackColor = backColor;
            if (!backGradientEndColor.Equals(Color.Empty))
            {
                //chartArea.BackGradientEndColor = backGradientEndColor;
                chartArea.BackColor = backGradientEndColor;
            }
            if (!borderColor.Equals(Color.Empty))
                chartArea.BorderColor = borderColor;

            chartArea.BorderDashStyle = borderStyle;

            if (borderWidth != -1)
                chartArea.BorderWidth = borderWidth;
            if (chartHatchStyle != ChartHatchStyle.None)
                chartArea.BackHatchStyle = chartHatchStyle;
            if (gradientType != MsGradientType.None)
            {
                //chartArea.BackGradientType = gradientType;

                GradientStyle gStyle = new GradientStyle();
                gStyle = (GradientStyle)gradientType;
                chartArea.BackGradientStyle = gStyle;
            }
            if (shadowOffset != -1)
                chartArea.ShadowOffset = shadowOffset;
            if (!shadowColor.Equals(Color.Empty))
                chartArea.ShadowColor = shadowColor;

            chartArea.Area3DStyle.Enable3D = enable3D;

            if (backImage != null) 
            {
                chartArea.BackImage = backImage;
                //chartArea.BackImageAlignment = chartImageAlign;
                chartArea.BackImageAlignment = (ChartImageAlignmentStyle)chartImageAlign;
                //chartArea.BackImageWrapMode = chartImageWrapMode;
                chartArea.BackImageWrapMode = chartImageWrapMode;
                if (!backImageTranspColor.Equals(Color.Empty))
                {
                    //chartArea.BackImageTransparentColor = backImageTranspColor;
                    chartArea.BackImageTransparentColor = backImageTranspColor;
                }
            }
        }

        #endregion

        #region ===================================== [ Series Scope ] =====================================

        public static Series CreateSeries(Chart chart, string seriesName, string chartArea, SeriesChartType seriesChartType)
        {
            return CreateSeries(chart, seriesName, chartArea, null, null, seriesChartType, -1, Color.Empty, Color.Empty, Color.Empty, -1, -1, Color.Empty);
        }

        public static Series CreateSeries(Chart chart, string seriesName, string chartArea, string legendText, string legendToolTip, SeriesChartType seriesChartType)
        {
            return CreateSeries(chart, seriesName, chartArea, legendText, legendToolTip, seriesChartType, -1, Color.Empty, Color.Empty, Color.Empty, -1, -1, Color.Empty);
        }

        public static Series CreateSeries(Chart chart, string seriesName, string chartArea, string legendText, string legendToolTip, SeriesChartType seriesChartType, int borderWidth, Color color, Color borderColor)
        {
            return CreateSeries(chart, seriesName, chartArea, legendText, legendToolTip, seriesChartType, borderWidth, color, borderColor, Color.Empty, -1, -1, Color.Empty);
        }

        public static Series CreateSeries(Chart chart, string seriesName, string chartArea, string legendText, string legendToolTip, SeriesChartType seriesChartType, int borderWidth, Color color, Color borderColor, Color shadowColor, int shadowOffSet) 
        {
            return CreateSeries(chart, seriesName, chartArea, legendText, legendToolTip, seriesChartType, borderWidth, color, borderColor, shadowColor, shadowOffSet, -1, Color.Empty); 
        }

        public static Series CreateSeries(Chart chart, string seriesName, string chartArea, string legendText, string legendToolTip, SeriesChartType seriesChartType, int borderWidth, Color color, Color borderColor, Color shadowColor, int shadowOffSet, int makerSize, Color makerBorderColor)
        {
            Series series = chart.Series.Add(seriesName);
            series.ChartArea = chartArea;
            if (legendText != null)
                series.LegendText = legendText;
            if (legendToolTip != null)
                series.LegendToolTip = legendToolTip;


            //series.Type = seriesChartType;
            series.ChartType = seriesChartType;
            if (borderWidth != -1)
                series.BorderWidth = borderWidth;
            if(!color.Equals(Color.Empty))
                series.Color = color;
            if (!borderColor.Equals(Color.Empty))
                series.BorderColor = borderColor;
            if (!shadowColor.Equals(Color.Empty))
                series.ShadowColor = shadowColor;
            if (shadowOffSet != -1)
                series.ShadowOffset = shadowOffSet;
            if (makerSize != -1)
                series.MarkerSize = makerSize;
            if (!makerBorderColor.Equals(Color.Empty))
                series.MarkerBorderColor = makerBorderColor;

            
            return series;
        }

        public static Series CreateSeries(Chart chart, string seriesName, string chartArea, string legendText, string legendToolTip, SeriesChartType seriesChartType, int borderWidth, Color color, Color borderColor, Color shadowColor, int shadowOffSet, int makerSize, Color makerBorderColor, Font font)
        {
            Series series = chart.Series.Add(seriesName);
            series.ChartArea = chartArea;
            if (legendText != null)
                series.LegendText = legendText;
            if (legendToolTip != null)
                series.LegendToolTip = legendToolTip;


            //series.Type = seriesChartType;
            series.ChartType = seriesChartType;
            if (borderWidth != -1)
                series.BorderWidth = borderWidth;
            if (!color.Equals(Color.Empty))
                series.Color = color;
            if (!borderColor.Equals(Color.Empty))
                series.BorderColor = borderColor;
            if (!shadowColor.Equals(Color.Empty))
                series.ShadowColor = shadowColor;
            if (shadowOffSet != -1)
                series.ShadowOffset = shadowOffSet;
            if (makerSize != -1)
                series.MarkerSize = makerSize;
            if (!makerBorderColor.Equals(Color.Empty))
                series.MarkerBorderColor = makerBorderColor;

            if (font != null)
                series.Font = font;
            

            return series;
        }

        #endregion

        #region ===================================== [ DataField Scope ] =====================================

        public static void SetDataFieldsX1(string query, string xField1, out ArrayList xValue1, string yField1, out ArrayList yValue1)
        {
            ArrayList array1x = null;
            ArrayList array1 = null;
            ArrayList array2 = null;
            ArrayList array3 = null;
            ArrayList array4 = null;
            SetDataFieldsX2(query, xField1, out xValue1, null, out array1x, yField1, out yValue1, null, out array4, null, out array3, null, out array2, null, out array1);
            array1x = null;
            array1 = null;
            array2 = null;
            array3 = null;
            array4 = null;
        }

        public static void SetDataFieldsX1(string query, string xField1, out ArrayList xValue1, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2)
        {
            ArrayList array1x = null;
            ArrayList array1 = null;
            ArrayList array2 = null;
            ArrayList array3 = null;
            SetDataFieldsX2(query, xField1, out xValue1, null, out array1x, yField1, out yValue1, yField2, out yValue2, null, out array3, null, out array2, null, out array1);
            array1x = null;
            array1 = null;
            array2 = null;
            array3 = null;
        }

        public static void SetDataFieldsX1(string query, string xField1, out ArrayList xValue1, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2, string yField3, out ArrayList yValue3)
        {
            ArrayList array1x = null;
            ArrayList array1 = null;
            ArrayList array2 = null;
            SetDataFieldsX2(query, xField1, out xValue1, null, out array1x, yField1, out yValue1, yField2, out yValue2, yField3, out yValue3, null, out array2, null, out array1);
            array1x = null;
            array1 = null;
            array2 = null;
        }

        public static void SetDataFieldsX1(string query, string xField1, out ArrayList xValue1, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2, string yField3, out ArrayList yValue3, string yField4, out ArrayList yValue4)
        {
            ArrayList array1x = null;
            ArrayList array1 = null;
            //ArrayList array2 = null;
            SetDataFieldsX2(query, xField1, out xValue1, null, out array1x, yField1, out yValue1, yField2, out yValue2, yField3, out yValue3, yField4, out yValue4, null, out array1);
            array1x = null;
            array1 = null;
            //array2 = null;
        }

        public static void SetDataFieldsX1(string query, string xField1, out ArrayList xValue1, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2, string yField3, out ArrayList yValue3, string yField4, out ArrayList yValue4, string yField5, out ArrayList yValue5)
        {
            ArrayList array1x = null;
            //ArrayList array1 = null;
            SetDataFieldsX2(query, xField1, out xValue1, null, out array1x, yField1, out yValue1, yField2, out yValue2, yField3, out yValue3, yField4, out yValue4, yField5, out yValue5);
            array1x = null;
            //array1 = null;
        }

        public static void SetDataFieldsX2(string query, string xField1, out ArrayList xValue1, string xField2, out ArrayList xValue2, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2)
        {
            ArrayList array1 = null;
            ArrayList array2 = null;
            ArrayList array3 = null;
            SetDataFieldsX2(query, xField1, out xValue1, xField2, out xValue2, yField1, out yValue1, yField2, out yValue2, null, out array3, null, out array2, null, out array1);
            array1 = null;
            array2 = null;
            array3 = null;
        }

        public static void SetDataFieldsX2(string query, string xField1, out ArrayList xValue1, string xField2, out ArrayList xValue2, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2, string yField3, out ArrayList yValue3)
        {
            ArrayList array1 = null;
            ArrayList array2 = null;
            SetDataFieldsX2(query, xField1, out xValue1, xField2, out xValue2, yField1, out yValue1, yField2, out yValue2, yField3, out yValue3, null, out array2, null, out array1);
            array1 = null;
            array2 = null;
        }

        public static void SetDataFieldsX2(string query, string xField1, out ArrayList xValue1, string xField2, out ArrayList xValue2, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2, string yField3, out ArrayList yValue3, string yField4, out ArrayList yValue4) 
        {
            ArrayList array1 = null;
            SetDataFieldsX2(query, xField1, out xValue1, xField2, out xValue2, yField1, out yValue1, yField2, out yValue2, yField3, out yValue3, yField4, out yValue4, null, out array1);
            array1 = null;
        }

        public static void SetDataFieldsX2(string query, string xField1, out ArrayList xValue1, string xField2, out ArrayList xValue2, string yField1, out ArrayList yValue1, string yField2, out ArrayList yValue2, string yField3, out ArrayList yValue3, string yField4, out ArrayList yValue4, string yField5, out ArrayList yValue5)
        {
            SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString);
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Connection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();

            xValue1 = new ArrayList();

            //if(xValue2 != null)
                xValue2 = new ArrayList();

            yValue1 = new ArrayList();

            //if(yValue2 != null)
                yValue2 = new ArrayList();
            //if(yValue3 != null)
                yValue3 = new ArrayList();
            //if (yValue4 != null)
                yValue4 = new ArrayList();
            //if (yValue5 != null)
                yValue5 = new ArrayList();

            while (myReader.Read())
            {
                xValue1.Add(myReader[xField1].ToString());
                if (xField2 != null)
                    xValue2.Add(myReader[xField2].ToString());

                yValue1.Add(double.Parse(myReader[yField1].ToString()));

                if(yField2 != null)
                    yValue2.Add(double.Parse(myReader[yField2].ToString()));
                if (yField3 != null)
                    yValue3.Add(double.Parse(myReader[yField3].ToString()));
                if (yField4 != null)
                    yValue4.Add(double.Parse(myReader[yField4].ToString()));
                if (yField5 != null)
                    yValue5.Add(double.Parse(myReader[yField5].ToString()));
            }

            myReader.Close();
            myConnection.Close();
        }

        #endregion

        #region ===================================== [ Title Scope ] =====================================

        public static Title CreateTitle(Chart chart, string titleName
            )
        {
            return CreateTitle(chart, titleName, null
            , null, Color.Empty, Color.Empty, Color.Empty
            , ContentAlignment.TopCenter
            , null
            , Color.Empty, -1
            , true, -1, -1, -1, -1);
        }

        public static Title CreateTitle(Chart chart, string titleName, string titleText
            )
        {
            return CreateTitle(chart, titleName, titleText
            , null, Color.Empty, Color.Empty, Color.Empty
            , ContentAlignment.TopCenter
            , null
            , Color.Empty, -1
            , true, -1, -1, -1, -1);
        }

        public static Title CreateTitle(Chart chart, string titleName, string titleText
            , Font font, Color color, Color backColor, Color boraderColor
            ) 
        {
            return CreateTitle(chart, titleName, titleText
            , font, color, backColor, boraderColor
            , ContentAlignment.TopCenter
            , null
            , Color.Empty, -1
            , true, -1, -1, -1, -1);
        }

        public static Title CreateTitle(Chart chart, string titleName, string titleText
            , Font font, Color color, Color backColor, Color boraderColor
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight) 
        {
            return CreateTitle(chart, titleName, titleText
            , font, color, backColor, boraderColor
            , ContentAlignment.TopCenter
            , null
            , Color.Empty, -1
            , positionAuto, positionX, positionY, positionWidth, positionHeight);
        }

        public static Title CreateTitle(Chart chart, string titleName, string titleText
            , Font font, Color color, Color backColor, Color boraderColor
            , ContentAlignment contentAlignment
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight) 
        {
            return CreateTitle(chart, titleName, titleText
            , font, color, backColor, boraderColor
            , contentAlignment
            , null
            , Color.Empty, -1
            , positionAuto, positionX, positionY, positionWidth, positionHeight);
        }

        public static Title CreateTitle(Chart chart, string titleName, string titleText
            , Font font, Color color, Color backColor, Color boraderColor
            , ContentAlignment contentAlignment
            , string toolTip
            , Color shadowColor, int shadowOffset
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight) 
        {
            Title title = chart.Titles.Add(titleName);
            if (titleText != null)
                title.Text = titleText;
            if(font != null)
                title.Font = font;

            if (!color.Equals(Color.Empty))
            {   
                //title.Color = color;
                title.ForeColor = color;
            }
            if (!backColor.Equals(Color.Empty))
                title.BackColor = backColor;
            if (!boraderColor.Equals(Color.Empty))
                title.BorderColor = boraderColor;
            
            if(contentAlignment != ContentAlignment.TopCenter)
                title.Alignment = contentAlignment;

            if (toolTip != null)
                title.ToolTip = toolTip;
            
            title.Position.Auto = positionAuto;

            if (!shadowColor.Equals(string.Empty))
                title.ShadowColor = shadowColor;
            if (shadowOffset != -1)
                title.ShadowOffset = shadowOffset;

            if(!positionAuto) 
            {
                if (positionX != -1)
                    title.Position.X = positionX;
                if (positionY != -1)
                    title.Position.Y = positionY;
                if (positionWidth != -1)
                    title.Position.Width = positionWidth;
                if (positionHeight != -1)
                    title.Position.Height = positionHeight;
            }

            return title;
        }

        #endregion

        #region ===================================== [ Legend Scope ] =====================================

        public static Legend CreateLegend(Chart chart, string legendName
            , Color backColor, Color borderColor
            )
        {
            return CreateLegend(chart, legendName
            , backColor, Color.Empty, borderColor
            , null
            , MsGradientType.None, ChartHatchStyle.None
            , -1, ChartDashStyle.NotSet
            , -1, Color.Empty
            , true, -1, -1, -1, -1);
        }

        public static Legend CreateLegend(Chart chart, string legendName
            , Color backColor, Color backGradientEndColor, Color borderColor
            )
        {
            return CreateLegend(chart, legendName
            , backColor, backGradientEndColor, borderColor
            , null
            , MsGradientType.None, ChartHatchStyle.None
            , -1, ChartDashStyle.NotSet
            , -1, Color.Empty
            , true, -1, -1, -1, -1);
        }

        public static Legend CreateLegend(Chart chart, string legendName
            , Color backColor, Color backGradientEndColor, Color borderColor
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight)
        {
            return CreateLegend(chart, legendName
            , backColor, backGradientEndColor, borderColor
            , null
            , MsGradientType.None, ChartHatchStyle.None
            , -1, ChartDashStyle.NotSet
            , -1, Color.Empty
            , positionAuto, positionX, positionX, positionWidth, positionHeight);
        }

        public static Legend CreateLegend(Chart chart, string legendName
            , Color backColor, Color backGradientEndColor, Color borderColor
            , Font font
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight)
        {
            return CreateLegend(chart, legendName
            , backColor, backGradientEndColor, borderColor
            , font
            , MsGradientType.None, ChartHatchStyle.None
            , -1, ChartDashStyle.NotSet
            , -1, Color.Empty
            , positionAuto, positionX, positionX, positionWidth, positionHeight);
        }

        public static Legend CreateLegend(Chart chart, string legendName
            , Color backColor, Color backGradientEndColor, Color borderColor
            , Font font
            , MsGradientType gradientType, ChartHatchStyle chartHatchStyle
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight)
        {
            return CreateLegend(chart, legendName
            , backColor, backGradientEndColor, borderColor
            , font
            , gradientType, chartHatchStyle
            , -1, ChartDashStyle.NotSet
            , -1, Color.Empty
            , positionAuto, positionX, positionX, positionWidth, positionHeight);
        }

        public static Legend CreateLegend(Chart chart, string legendName
            , Color backColor, Color backGradientEndColor, Color borderColor
            , Font font
            , MsGradientType gradientType, ChartHatchStyle chartHatchStyle
            , int borderWidth, ChartDashStyle boaderStyle
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight)
        {
            return CreateLegend(chart, legendName
            , backColor, backGradientEndColor, borderColor
            , font
            , gradientType, chartHatchStyle
            , borderWidth, boaderStyle
            , -1, Color.Empty
            , positionAuto, positionX, positionX, positionWidth, positionHeight);
        }

        public static Legend CreateLegend(Chart chart, string legendName
            , Color backColor, Color backGradientEndColor, Color borderColor
            , Font font
            , MsGradientType gradientType, ChartHatchStyle chartHatchStyle
            , int borderWidth, ChartDashStyle boaderStyle
            , int shadowOffset, Color shadowColor
            , bool positionAuto, float positionX, float positionY, float positionWidth, float positionHeight)
        {
            chart.Legends.Add(legendName);

            Legend legend = chart.Legends[legendName];

            // Set Legend visual attributes
            if (!backColor.Equals(Color.Empty))
                legend.BackColor = backColor;
            if (!backGradientEndColor.Equals(Color.Empty))
            {
                //legend.BackGradientEndColor = backGradientEndColor;

            }
            if (!borderColor.Equals(Color.Empty))
                legend.BorderColor = borderColor;

            if (font != null)
                legend.Font = font;

            if (gradientType != MsGradientType.None)
            {
                //legend.BackGradientType = gradientType;

                GradientStyle gStyle = new GradientStyle();
                gStyle = (GradientStyle)gradientType;
                legend.BackGradientStyle = gStyle;

            }
            if (chartHatchStyle != ChartHatchStyle.None)
                legend.BackHatchStyle = chartHatchStyle;

            if (borderWidth != -1)
                legend.BorderWidth = borderWidth;
            if (boaderStyle != ChartDashStyle.NotSet)
            {
                legend.BorderDashStyle = boaderStyle;
            }

            if (shadowOffset != -1)
                legend.ShadowOffset = shadowOffset;
            if (!shadowColor.Equals(Color.Empty))
                legend.ShadowColor = shadowColor;

            legend.Position.Auto = positionAuto;

            if (!positionAuto)
            {
                if (positionX != -1)
                    legend.Position.X = positionX;
                if (positionY != -1)
                    legend.Position.Y = positionY;
                if (positionWidth != -1)
                    legend.Position.Width = positionWidth;
                if (positionHeight != -1)
                    legend.Position.Height = positionHeight;
            }

            return legend;
        }

        #endregion
    }
}
