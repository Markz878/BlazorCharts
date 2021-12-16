using BlazorCharts.PlotDataModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using static System.Math;

namespace BlazorCharts;

public partial class StackedBarChart
{
    [EditorRequired] [Parameter] public IList<StackedBarColumn> Data { get; set; } = default!;
    [Parameter] public double Width { get; set; } = 700;
    [Parameter] public double Height { get; set; } = 350;
    [Parameter] public string Title { get; set; } = "Stacked Bar Chart";

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
        YMax = GetLimit(Data.Select(x => x.Values.Select(y=>y.Value).Sum()));
        SetMarginLeft(YMax);
    }

    private void SetMarginLeft(double ymax)
    {
        double order = Round(Log10(ymax));
        MarginLeft = order * 10 + 10;
    }

    private double GetLimit(IEnumerable<double> values)
    {
        double maxVal = values.Max();
        double order = Pow(10, Round(Log10(maxVal)));
        double maxLimit = MathUtilities.RoundTo10(maxVal, order, true);
        return maxLimit;
    }

    private IEnumerable<double> YAxis => Enumerable.Range(0, 11).Select(x => YMax * x / 10);

    private double GetXCoordinate(int order)
    {
        double result = MarginLeft + 50 + order * Width / Data.Count;
        return result;
    }

    private double GetBarWidth()
    {
        return Max(Width / Data.Count * 0.3, 25);
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

    //private string GetBarColor(int index)
    //{
    //    return MathUtilities.GetColorFromFraction(index / (double)Data[0].Values.Count).ToString();
    //}

    private void MouseOver(MouseEventArgs e, StackedBarColumn p, int itemIndex)
    {
        //tooltipWidth = GetTooltipWidth(p);
        //tooltipHeight = GetTooltipHeight(p);
        //double x = GetXCoordinate(p.X);
        //double y = GetYCoordinate(p.Y);
        //tooltipX = p.X < (XMin + XMax) / 2 ? x : x - tooltipWidth;
        //tooltipY = p.Y > (YMin + YMax) / 2 ? y : y - tooltipHeight;
        //tooltipProperties = p.TooltipProperties.Select((x, i) => ($"{x.Key}: {x.Value}", i));
        //showTooltip = true;
        //Console.WriteLine($"Screen {e.ScreenX},{e.ScreenY} Client {e.ClientX},{e.ClientY} Page {e.PageX},{e.PageY} Offset {e.OffsetX},{e.OffsetY}");
    }

    //private double GetTooltipHeight(ScatterPoint p)
    //{
    //    return p.TooltipProperties.Count * 18 + 5;
    //}

    //private double GetTooltipWidth(ScatterPoint p)
    //{
    //    return p.TooltipProperties.Max(x => x.Key.Length + x.Value.Length) * 5.5;
    //}

    private void MouseLeave(MouseEventArgs e, StackedBarColumn p)
    {
        //showTooltip = false;
    }
}
