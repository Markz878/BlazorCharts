using BlazorCharts.PlotDataModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using static System.Math;

namespace BlazorCharts;

public partial class BarChart
{
    [EditorRequired] [Parameter] public IList<BarItem> Data { get; set; } = default!;
    [Parameter] public double Width { get; set; } = 700;
    [Parameter] public double Height { get; set; } = 350;
    [Parameter] public string BarColor { get; set; } = "red";
    [Parameter] public string Title { get; set; } = "Bar Chart";

    private double YMax;

    private bool showTooltip;
    private double tooltipX;
    private double tooltipY;
    private double tooltipHeight;
    private double tooltipWidth;
    private double MarginLeft = 30;
    private const double MarginRight = 10;
    private const double MarginTop = 30;
    private const double MarginBottom = 20;
    private IEnumerable<(string text, int index)>? tooltipProperties;

    protected override void OnParametersSet()
    {
        SetLimits();
    }

    private void SetLimits()
    {
        YMax = GetLimit(Data.Select(x => x.Value));
        SetMarginLeft(YMax);
    }

    private void SetMarginLeft(double ymax)
    {
        double order = Round(Log10(ymax));
        MarginLeft = order * 10 + 10;
    }

    private static double GetLimit(IEnumerable<double> values)
    {
        double maxVal = values.Max();
        double order = Pow(10, Round(Log10(maxVal)));
        double maxLimit = MathUtilities.RoundTo10(maxVal, order, true);
        return maxLimit;
    }

    private IEnumerable<double> YAxis => Enumerable.Range(0, 11).Select(x => YMax * x / 10);

    private double GetXCoordinate(int index)
    {
        double barWidth = GetBarWidth();
        double result = MarginLeft + barWidth + (double)index / (Data.Count - 1) * (Width - MarginLeft - MarginRight - 2 * barWidth);
        return result;
    }

    private double GetBarWidth()
    {
        return Max(Width / Data.Count * 0.3, 35);
    }

    private double GetBarHeight(double value)
    {
        double result = value / YMax * (Height - MarginTop - MarginBottom);
        return result;
    }

    private double GetYCoordinate(double value)
    {
        double result = Height - MarginBottom - value / YMax * (Height - MarginTop - MarginBottom);
        return result;
    }

    private void MouseOver(BarItem p, int index)
    {
        if (p.TooltipProperties.Any())
        {
            tooltipWidth = GetTooltipWidth(p);
            tooltipHeight = GetTooltipHeight(p);
            double x = GetXCoordinate(index) + (index < Data.Count / 2 ? GetBarWidth() / 2 + 3 : -GetBarWidth() / 2 - 3);
            double y = GetYCoordinate(p.Value);
            tooltipX = index < Data.Count / 2 ? x : x - tooltipWidth;
            tooltipY = Height * 0.6; /*p.Y > (YMin + YMax) / 2 ? y : y - tooltipHeight;*/
            tooltipProperties = p.TooltipProperties.Select((x, i) => ($"{x.Key}: {x.Value}", i));
            showTooltip = true;
        }
    }

    private static double GetTooltipHeight(BarItem p)
    {
        return p.TooltipProperties.Count * 18 + 5;
    }

    private static double GetTooltipWidth(BarItem p)
    {
        return p.TooltipProperties.Max(x => x.Key.Length + x.Value.Length) * 5.5;
    }

    private void MouseLeave()
    {
        showTooltip = false;
    }
}
