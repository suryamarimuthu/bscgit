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
using Dundas.Charting.WebControl;

/// <summary>
/// Summary description for DundasCharts
/// </summary>
namespace MicroCharts
{
    public class DundasAnimations
    {
        #region ===================================== [ Animation Base Scope ] =====================================

        public static void DundasChartBase(Chart chart
                                            , AnimationTheme animationTheme
                                            , int animationDuration
                                            , int animationFramesPerSecond
                                            , bool repeatAnimation
                                            , int repeatDelay)
        {
            if (chart.ImageType == ChartImageType.Flash)
            {
                if (animationTheme != AnimationTheme.None)
                    chart.AnimationTheme = animationTheme;

                if (animationDuration != -1)
                    chart.AnimationDuration = animationDuration;

                if (animationFramesPerSecond != -1)
                    chart.AnimationFramesPerSecond = animationFramesPerSecond;

                chart.RepeatAnimation = repeatAnimation;

                if (repeatDelay != -1)
                    chart.RepeatDelay = repeatDelay;
            }
        }

        #endregion

        #region ===================================== [ GrowingAnimation Scope ] =====================================

        public static void GrowingAnimation(Chart chart
                                            , Series series
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne)
        {
            GrowingAnimation seriesColumnAnimation  = new GrowingAnimation();
            seriesColumnAnimation.AnimatedElements.Add(series);
            seriesColumnAnimation.StartTime         = startTime;
            seriesColumnAnimation.Duration          = duration;
            seriesColumnAnimation.OneByOne          = isOneByOne;
            chart.CustomAnimation.Add(seriesColumnAnimation);
        }

        public static void GrowingAnimation(Chart chart
                                            , Title title
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne)
        {
            GrowingAnimation seriesColumnAnimation  = new GrowingAnimation();
            seriesColumnAnimation.AnimatedElements.Add(title);
            seriesColumnAnimation.StartTime         = startTime;
            seriesColumnAnimation.Duration          = duration;
            seriesColumnAnimation.OneByOne          = isOneByOne;
            chart.CustomAnimation.Add(seriesColumnAnimation);
        }

        public static void GrowingAnimation(Chart chart
                                            , Legend legend
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne)
        {
            GrowingAnimation seriesColumnAnimation  = new GrowingAnimation();
            seriesColumnAnimation.AnimatedElements.Add(legend);
            seriesColumnAnimation.StartTime         = startTime;
            seriesColumnAnimation.Duration          = duration;
            seriesColumnAnimation.OneByOne          = isOneByOne;
            chart.CustomAnimation.Add(seriesColumnAnimation);
        }

        public static void GrowingAnimation(Chart chart
                                            , DataPoint dataPoint
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne)
        {
            GrowingAnimation seriesColumnAnimation = new GrowingAnimation();
            seriesColumnAnimation.AnimatedElements.Add(dataPoint);
            seriesColumnAnimation.StartTime         = startTime;
            seriesColumnAnimation.Duration          = duration;
            seriesColumnAnimation.OneByOne          = isOneByOne;
            chart.CustomAnimation.Add(seriesColumnAnimation);
        }

        #endregion

        #region ===================================== [ FadingAnimation Scope ] =====================================

        //FadingAnimation
        public static void FadingAnimation(Chart chart
                                            , Series series
                                            , Color startFillColor
                                            , Color startBorderColor
                                            , Color startTextColor
                                            , Color startShadowColor
                                            , Color startGradientColor
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne
                                            , bool isRepeated
                                            , double repeatDelay)
        {
            FadingAnimation pointAnimation = new FadingAnimation();
            pointAnimation.AnimatedElements.Add(series);

            if (!startFillColor.Equals(Color.Empty))
                pointAnimation.StartFillColor   = startFillColor;

            if (!startBorderColor.Equals(Color.Empty))
                pointAnimation.StartBorderColor = startBorderColor;

            if (!startTextColor.Equals(Color.Empty))
                pointAnimation.StartTextColor   = startTextColor;

            if (!startShadowColor.Equals(Color.Empty))
                pointAnimation.StartShadowColor = startShadowColor;

            if (!startGradientColor.Equals(Color.Empty))
                pointAnimation.StartGradientColor = startGradientColor;
            
            pointAnimation.StartTime    = startTime;
            pointAnimation.Duration     = duration;
            pointAnimation.Repeat       = isRepeated;
            pointAnimation.OneByOne     = isOneByOne;

            if (repeatDelay != -1)
                pointAnimation.RepeatDelay = repeatDelay;

            chart.CustomAnimation.Add(pointAnimation);
        }

        public static void FadingAnimation(Chart chart
                                            , Series series
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne
                                            , bool isRepeated) 
        {
            FadingAnimation(chart, series, Color.Empty, Color.Empty, Color.Empty, Color.Empty, Color.Empty, startTime, duration, isOneByOne, isRepeated, -1);
        }

        public static void FadingAnimation(Chart chart, DataPoint dataPoint, Color startFillColor, Color startBorderColor, Color startTextColor, Color startShadowColor, Color startGradientColor, double startTime, double duration, bool isOneByOne, bool isRepeated, double repeatDelay)
        {
            FadingAnimation pointAnimation = new FadingAnimation();
            pointAnimation.AnimatedElements.Add(dataPoint);

            if (!startFillColor.Equals(Color.Empty))
                pointAnimation.StartFillColor       = startFillColor;

            if (!startBorderColor.Equals(Color.Empty))
                pointAnimation.StartBorderColor     = startBorderColor;

            if (!startTextColor.Equals(Color.Empty))
                pointAnimation.StartTextColor       = startTextColor;

            if (!startShadowColor.Equals(Color.Empty))
                pointAnimation.StartShadowColor     = startShadowColor;

            if (!startGradientColor.Equals(Color.Empty))
                pointAnimation.StartGradientColor   = startGradientColor;

            pointAnimation.StartTime    = startTime;
            pointAnimation.Duration     = duration;
            pointAnimation.Repeat       = isRepeated;
            pointAnimation.OneByOne     = isOneByOne;

            if (repeatDelay != -1)
                pointAnimation.RepeatDelay = repeatDelay;
            chart.CustomAnimation.Add(pointAnimation);
        }

        public static void FadingAnimation(Chart chart, DataPoint dataPoint, double startTime, double duration, bool isOneByOne, bool isRepeated)
        {
            FadingAnimation(chart, dataPoint, Color.Empty, Color.Empty, Color.Empty, Color.Empty, Color.Empty, startTime, duration, isOneByOne, isRepeated, -1);
        }

        public static void FadingAnimation(Chart chart, Legend legend, Color startFillColor, Color startBorderColor, Color startTextColor, Color startShadowColor, Color startGradientColor, double startTime, double duration, bool isOneByOne, bool isRepeated, double repeatDelay)
        {
            FadingAnimation pointAnimation = new FadingAnimation();
            pointAnimation.AnimatedElements.Add(legend);

            if (!startFillColor.Equals(Color.Empty))
                pointAnimation.StartFillColor       = startFillColor;

            if (!startBorderColor.Equals(Color.Empty))
                pointAnimation.StartBorderColor     = startBorderColor;

            if (!startTextColor.Equals(Color.Empty))
                pointAnimation.StartTextColor       = startTextColor;

            if (!startShadowColor.Equals(Color.Empty))
                pointAnimation.StartShadowColor     = startShadowColor;

            if (!startGradientColor.Equals(Color.Empty))
                pointAnimation.StartGradientColor   = startGradientColor;

            pointAnimation.StartTime    = startTime;
            pointAnimation.Duration     = duration;
            pointAnimation.Repeat       = isRepeated;
            pointAnimation.OneByOne     = isOneByOne;

            if (repeatDelay != -1)
                pointAnimation.RepeatDelay = repeatDelay;
            chart.CustomAnimation.Add(pointAnimation);
        }

        public static void FadingAnimation(Chart chart, Legend legend, double startTime, double duration, bool isOneByOne, bool isRepeated)
        {
            FadingAnimation(chart, legend, Color.Empty, Color.Empty, Color.Empty, Color.Empty, Color.Empty, startTime, duration, isOneByOne, isRepeated, -1);
        }

        public static void FadingAnimation(Chart chart, Title title, Color startFillColor, Color startBorderColor, Color startTextColor, Color startShadowColor, Color startGradientColor, double startTime, double duration, bool isOneByOne, bool isRepeated, double repeatDelay)
        {
            FadingAnimation pointAnimation          = new FadingAnimation();
            pointAnimation.AnimatedElements.Add(title);

            if (!startFillColor.Equals(Color.Empty))
                pointAnimation.StartFillColor       = startFillColor;

            if (!startBorderColor.Equals(Color.Empty))
                pointAnimation.StartBorderColor     = startBorderColor;

            if (!startTextColor.Equals(Color.Empty))
                pointAnimation.StartTextColor       = startTextColor;

            if (!startShadowColor.Equals(Color.Empty))
                pointAnimation.StartShadowColor     = startShadowColor;

            if (!startGradientColor.Equals(Color.Empty))
                pointAnimation.StartGradientColor   = startGradientColor;

            pointAnimation.StartTime    = startTime;
            pointAnimation.Duration     = duration;
            pointAnimation.Repeat       = isRepeated;
            pointAnimation.OneByOne     = isOneByOne;

            if (repeatDelay != -1)
                pointAnimation.RepeatDelay = repeatDelay;
            chart.CustomAnimation.Add(pointAnimation);
        }

        public static void FadingAnimation(Chart chart, Title title, double startTime, double duration, bool isOneByOnebool, bool isRepeated)
        {
            FadingAnimation(chart, title, Color.Empty, Color.Empty, Color.Empty, Color.Empty, Color.Empty, startTime, duration, isOneByOnebool, isRepeated, -1);
        }

        #endregion

        #region ===================================== [ MovingAnimation Scope ] =====================================

        public static void MovingAnimation(Chart chart, Title title, float startPositionX, float startPositionY, double startTime, double duration, bool isOneByOne, bool isRepeated, double repeatDelay)
        {
            MovingAnimation legendAnimation = new MovingAnimation();
            legendAnimation.AnimatedElements.Add(title);

            if (startPositionX != -1)
                legendAnimation.StartPositionX = startPositionX;

            if (startPositionY != -1)
                legendAnimation.StartPositionY = startPositionY;

            legendAnimation.StartTime   = startTime;
            legendAnimation.Duration    = duration;
            legendAnimation.Repeat      = isRepeated;
            if (repeatDelay != -1)
                legendAnimation.RepeatDelay = repeatDelay;

            legendAnimation.OneByOne    = isOneByOne;
            chart.CustomAnimation.Add(legendAnimation);
        }

        public static void MovingAnimation(Chart chart, Title title, double startTime, double duration, bool isOneByOne, bool isRepeated) 
        {
            MovingAnimation(chart, title, -1, -1, startTime, duration, isOneByOne, isRepeated, -1);
        }

        public static void MovingAnimation(Chart chart, Series series, float startPositionX, float startPositionY, double startTime, double duration, bool isOneByOne, bool isRepeated, double repeatDelay)
        {
            MovingAnimation legendAnimation = new MovingAnimation();
            legendAnimation.AnimatedElements.Add(series);

            if (startPositionX != -1)
                legendAnimation.StartPositionX = startPositionX;
            if (startPositionY != -1)
                legendAnimation.StartPositionY = startPositionY;
            legendAnimation.StartTime   = startTime;
            legendAnimation.Duration    = duration;
            legendAnimation.Repeat      = isRepeated;

            if (repeatDelay != -1)
                legendAnimation.RepeatDelay = repeatDelay;

            legendAnimation.OneByOne    = isOneByOne;
            chart.CustomAnimation.Add(legendAnimation);
        }

        public static void MovingAnimation(Chart chart, Series series, double startTime, double duration, bool isOneByOne, bool isRepeated)
        {
            MovingAnimation(chart, series, -1, -1, startTime, duration, isOneByOne, isRepeated, -1);
        }

        public static void MovingAnimation(Chart chart, Legend legend, float startPositionX, float startPositionY, double startTime, double duration, bool isOneByOne, bool isRepeated, double repeatDelay)
        {
            MovingAnimation legendAnimation = new MovingAnimation();
            legendAnimation.AnimatedElements.Add(legend);
            if (startPositionX != -1)
                legendAnimation.StartPositionX = startPositionX;
            if (startPositionY != -1)
                legendAnimation.StartPositionY = startPositionY;
            legendAnimation.StartTime   = startTime;
            legendAnimation.Duration    = duration;
            legendAnimation.Repeat      = isRepeated;

            if (repeatDelay != -1)
                legendAnimation.RepeatDelay = repeatDelay;

            legendAnimation.OneByOne    = isOneByOne;
            chart.CustomAnimation.Add(legendAnimation);
        }

        public static void MovingAnimation(Chart chart
                                            , Legend legend
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne
                                            , bool isRepeated)
        {
            MovingAnimation(chart, legend, -1, -1, startTime, duration, isOneByOne, isRepeated, -1);
        }

        public static void MovingAnimation(Chart chart, DataPoint dataPoint, float startPositionX, float startPositionY, double startTime, double duration, bool isOneByOne, bool isRepeated, double repeatDelay)
        {
            MovingAnimation legendAnimation     = new MovingAnimation();
            legendAnimation.AnimatedElements.Add(dataPoint);

            if (startPositionX != -1)
                legendAnimation.StartPositionX  = startPositionX;

            if (startPositionY != -1)
                legendAnimation.StartPositionY  = startPositionY;

            legendAnimation.StartTime           = startTime;
            legendAnimation.Duration            = duration;
            legendAnimation.Repeat              = isRepeated;

            if (repeatDelay != -1)
                legendAnimation.RepeatDelay     = repeatDelay;

            legendAnimation.OneByOne            = isOneByOne;
            chart.CustomAnimation.Add(legendAnimation);
        }

        public static void MovingAnimation(Chart chart
                                            , DataPoint dataPoint
                                            , double startTime
                                            , double duration
                                            , bool isOneByOne
                                            , bool isRepeated)
        {
            MovingAnimation(chart, dataPoint, -1, -1, startTime, duration, isOneByOne, isRepeated, -1);
        }

        #endregion
    }
}
