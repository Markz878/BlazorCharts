using BlazorCharts.PlotDataModels;
using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using static System.Math;

namespace BlazorCharts;

public class PieChartBase : BaseChart
{
    [Parameter][EditorRequired] public required PieSeries Data { get; init; }
    [Parameter] public string LabelFontSize { get; init; } = "9px";
    [Parameter] public double EdgeThickness { get; init; }
    protected double R => Min(Width, Height) * 0.8 / 2;
    private double Total => Data.PieItems.Sum(x => x.Value);

    protected double GetX(double value, double r)
    {
        return Width / 2 + r * Cos(2 * PI * value / Total);
    }

    protected double GetY(double value, double r)
    {
        return Height / 2 - r * Sin(2 * PI * value / Total);
    }

    protected int GetArcPathArg(double value)
    {
        return value / Total > 0.5 ? 1 : 0;
    }

    protected void MouseOver(PieItem p)
    {
        if (p.TooltipProperties is not null)
        {
            string X = $"calc({(Width / 2).ToString(c)}px - 50%)";
            string Y = $"calc({(Height / 2).ToString(c)}px - 50%)";
            tooltipInfo = new TooltipInfo(X, Y, p.TooltipProperties);
            showTooltip = true;
        }
    }

    protected void MouseLeave()
    {
        showTooltip = false;
    }

    protected IEnumerable<(string title, string color)> GetTitles()
    {
        return Data.PieItems.Select(x => (x.Title, x.Color));
    }
}