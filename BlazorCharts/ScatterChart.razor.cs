using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using static System.Math;

namespace BlazorCharts
{
    public partial class ScatterChart
    {
        [EditorRequired] [Parameter] public IList<ScatterPoint> Data { get; set; } = default!;
        [Parameter] public double Width { get; set; } = 700;
        [Parameter] public double Height { get; set; } = 350;

        private double XMin;
        private double XMax;
        private double YMin;
        private double YMax;

        private bool showTooltip;
        private double tooltipX;
        private double tooltipY;
        private double tooltipHeight;
        private double tooltipWidth;
        private double MarginX = 30;
        private const double MarginY = 20;
        private IEnumerable<(string text, int index)>? tooltipProperties;

        protected override void OnParametersSet()
        {
            SetLimits();
        }

        private void SetLimits()
        {
            (XMin, XMax) = GetLimits(Data.Select(x => x.X));
            (YMin, YMax) = GetLimits(Data.Select(x => x.Y));
            SetMarginX(Data.Select(x => x.Y));
        }

        private void SetMarginX(IEnumerable<double> values)
        {
            double minVal = values.Min();
            double maxVal = values.Max();
            double diff = maxVal - minVal;
            double order = Round(Log10(diff));
            MarginX = order * 10 + 10;
        }

        private (double min, double max) GetLimits(IEnumerable<double> values)
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
            double result = MarginX + (value - XMin) / (XMax - XMin) * (Width - 2 * MarginX);
            return result;
        }

        private double GetYCoordinate(double value)
        {
            double result = Height - MarginY - (value - YMin) / (YMax - YMin) * (Height - 2 * MarginY);
            return result;
        }

        private void MouseOver(MouseEventArgs e, ScatterPoint p)
        {
            tooltipWidth = GetTooltipWidth(p);
            tooltipHeight = GetTooltipHeight(p);
            double x = GetXCoordinate(p.X);
            double y = GetYCoordinate(p.Y);
            tooltipX = p.X < (XMin + XMax) / 2 ? x : x - tooltipWidth;
            tooltipY = p.Y > (YMin + YMax) / 2 ? y : y - tooltipHeight;
            tooltipProperties = p.TooltipProperties.Select((x, i) => ($"{x.Key}: {x.Value}", i));
            showTooltip = true;
            //Console.WriteLine($"Screen {e.ScreenX},{e.ScreenY} Client {e.ClientX},{e.ClientY} Page {e.PageX},{e.PageY} Offset {e.OffsetX},{e.OffsetY}");
        }

        private double GetTooltipHeight(ScatterPoint p)
        {
            return p.TooltipProperties.Count * 18 + 5;
        }

        private double GetTooltipWidth(ScatterPoint p)
        {
            KeyValuePair<string, string> maxLenProperty = p.TooltipProperties.MaxBy(x => x.Key.Length + x.Value.Length);
            Console.WriteLine($"Value {maxLenProperty.Key}:{maxLenProperty.Value} has length {maxLenProperty.Key.Length + maxLenProperty.Value.Length}");
            return p.TooltipProperties.Max(x => x.Key.Length + x.Value.Length) * 5.65;
        }

        private void MouseLeave(MouseEventArgs e, ScatterPoint p)
        {
            showTooltip = false;
        }
    }
}