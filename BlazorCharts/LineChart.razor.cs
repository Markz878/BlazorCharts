using BlazorCharts.PlotDataModels;
using Microsoft.AspNetCore.Components;
using static System.Math;


namespace BlazorCharts
{
    public partial class LineChart
    {
        [EditorRequired] [Parameter] public LineSeries Data { get; set; } = default!;
        [Parameter] public double Width { get; set; } = 700;
        [Parameter] public double Height { get; set; } = 350;
        [Parameter] public string Title { get; set; } = "Line Chart";

        private double XMin;
        private double XMax;
        private double YMin;
        private double YMax;

        private double MarginLeft = 30;
        private const double MarginRight = 10;
        private const double MarginTop = 30;
        private const double MarginBottom = 50;

        //private bool showTooltip;
        //private double tooltipX;
        //private double tooltipY;
        //private double tooltipHeight;
        //private double tooltipWidth;
        //private IEnumerable<(string text, int index)>? tooltipProperties;

        protected override void OnParametersSet()
        {
            SetLimits();
        }

        private void SetLimits()
        {
            (XMin, XMax) = GetLimits(Data.Series.SelectMany(x => x.Points).Select(x=>x.X));
            (YMin, YMax) = GetLimits(Data.Series.SelectMany(x => x.Points).Select(x => x.Y));
            SetMarginLeft(Data.Series.SelectMany(x => x.Points).Select(x => x.Y));
        }

        private void SetMarginLeft(IEnumerable<double> values)
        {
            double minVal = values.Min();
            double maxVal = values.Max();
            double diff = maxVal - minVal;
            double order = Round(Log10(diff));
            MarginLeft = order * 10 + 10;
        }

        private static (double min, double max) GetLimits(IEnumerable<double> values)
        {
            double minVal = values.Min();
            double maxVal = values.Max();
            double diff = maxVal - minVal;
            double order = Pow(10, Round(Log10(diff)));
            double maxLimit = MathUtilities.RoundTo10(maxVal, order, true);
            double minLimit = MathUtilities.RoundTo10(minVal, order, false);
            return (minLimit, maxLimit);
        }

        private IEnumerable<double> XAxis => Enumerable.Range(0, 11).Select(x => (XMax - XMin) * x / 10 + XMin);
        private IEnumerable<double> YAxis => Enumerable.Range(0, 11).Select(x => (YMax - YMin) * x / 10 + YMin);

        private double GetXCoordinate(double value)
        {
            double result = MarginLeft + (value - XMin) / (XMax - XMin) * (Width - MarginLeft - MarginRight);
            return result;
        }

        private double GetYCoordinate(double value)
        {
            double result = Height - MarginBottom - (value - YMin) / (YMax - YMin) * (Height - MarginBottom - MarginTop);
            return result;
        }

        private string GetPolylinePoints(LineSerie serie)
        {
            return string.Join(" ", serie.Points.Select(x=>$"{GetXCoordinate(x.X)},{GetYCoordinate(x.Y)}"));
        }

        //private void MouseOver(ScatterPoint p)
        //{
        //    tooltipWidth = GetTooltipWidth(p);
        //    tooltipHeight = GetTooltipHeight(p);
        //    double x = GetXCoordinate(p.X);
        //    double y = GetYCoordinate(p.Y);
        //    tooltipX = p.X < (XMin + XMax) / 2 ? x : x - tooltipWidth;
        //    tooltipY = p.Y > (YMin + YMax) / 2 ? y : y - tooltipHeight;
        //    tooltipProperties = p.TooltipProperties.Select((x, i) => ($"{x.Key}: {x.Value}", i));
        //    showTooltip = true;
        //}

        //private void MouseLeave()
        //{
        //    showTooltip = false;
        //}
    }
}