using BlazorCharts.PlotDataModels;
using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using static System.Math;

namespace BlazorCharts
{
    public partial class ScatterChart
    {
        [Parameter] [EditorRequired] public ScatterSeries Data { get; set; } = default!;
        [Parameter] public double Width { get; set; } = 700;
        [Parameter] public double Height { get; set; } = 350;
        [Parameter] [EditorRequired] public string Title { get; set; } = "";
        [Parameter] [EditorRequired] public string YAxisTitle { get; set; } = "";
        [Parameter] [EditorRequired] public string XAxisTitle { get; set; } = "";

        private double XMin;
        private double XMax;
        private double YMin;
        private double YMax;

        private double MarginLeft;
        private const double MarginRight = 10;
        private const double MarginTop = 30;
        private const double MarginBottom = 70;

        private bool showTooltip;
        private string? tooltipX;
        private string? tooltipY;
        private string? tooltipXTranslate;
        private string? tooltipYTranslate;
        private IEnumerable<string>? tooltipProperties;

        protected override void OnParametersSet()
        {
            SetLimits();
        }

        private void SetLimits()
        {
            (XMin, XMax) = GetLimits(Data.Series.SelectMany(x=>x.Points).Select(x => x.X));
            (YMin, YMax) = GetLimits(Data.Series.SelectMany(x => x.Points).Select(x => x.Y));
            SetMarginLeft(Data.Series.SelectMany(x => x.Points).Select(x => x.Y));
        }

        private void SetMarginLeft(IEnumerable<double> values)
        {
            double minVal = values.Min();
            double maxVal = values.Max();
            double diff = maxVal - minVal;
            double order = Round(Log10(diff));
            MarginLeft = order * 10 + 30;
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

        private void MouseOver(ScatterPoint p)
        {
            if (p.TooltipProperties.Any())
            {
                double x = GetXCoordinate(p.X);
                double y = GetYCoordinate(p.Y);
                tooltipX = $"{x}px";
                tooltipY = $"{y}px";
                tooltipXTranslate = x < Width / 2 ? "0" : "-100%";
                tooltipYTranslate = y < Height / 2 ? "0" : "-100%";
                tooltipProperties = p.TooltipProperties.Select(x => $"{x.Key}: {x.Value}");
                showTooltip = true;
            }
        }

        private void MouseLeave()
        {
            showTooltip = false;
        }
    }
}