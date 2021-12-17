using BlazorCharts.PlotDataModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using static System.Math;

namespace BlazorCharts;

public partial class StackedBarChart
{
    [EditorRequired] [Parameter] public StackedBarSeries Data { get; set; } = default!;
    [Parameter] public double Width { get; set; } = 700;
    [Parameter] public double Height { get; set; } = 350;
    [Parameter] public string MaxWidth { get; set; } = "900px";
    [Parameter] public string Title { get; set; } = "Stacked Bar Chart";

    private double YMax;

    private bool showTooltip;
    private double tooltipX;
    private double tooltipY;
    private double tooltipHeight;
    private double tooltipWidth;
    private double MarginLeft = 30;
    private double MarginRight = 30;
    private const double MarginTop = 30;
    private const double MarginBottom = 50;
    private IEnumerable<(string text, int index)>? tooltipProperties;

    protected override void OnParametersSet()
    {
        SetLimits();
    }

    private void SetLimits()
    {
        YMax = GetLimit(getElementWiseSum(Data));
        SetMarginLeft(YMax);
        SetMarginRight();

        static IEnumerable<double> getElementWiseSum(StackedBarSeries Data)
        {
            for (int i = 0; i < Data.Titles.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < Data.Series.Count; j++)
                {
                    sum += Data.Series[j].Values[i];
                }
                yield return sum;
            }
        }
    }

    private void SetMarginRight()
    {
        int lastTitleWidth = GetTextPixelWidth(Data.Titles[^1], GetTitleFontsize());
        MarginRight = Max(lastTitleWidth - 90, 10);
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

    private double GetXCoordinate(int order)
    {
        double barWidth = GetBarWidth();
        double result = MarginLeft + barWidth + (double)order / (Data.Titles.Count - 1) * (Width - MarginLeft - MarginRight - 2 * barWidth);
        return result;
    }

    private double GetBarWidth()
    {
        return Max(Width / Data.Titles.Count * 0.3, 35);
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

    private double GetXOffsetBetweenColumns()
    {
        double barWidth = GetBarWidth();
        double result = 1d / (Data.Titles.Count - 1) * (Width - MarginLeft - MarginRight - 2 * barWidth);
        return result;
    }

    private static int GetTextPixelWidth(string text, int fontsize)
    {
        return text.Length * fontsize / 2;
    }

    private int GetTitleFontsize()
    {
        double xOffset = GetXOffsetBetweenColumns();
        int fontSize = 12;
        bool passed = false;
        while (!passed)
        {
            passed = true;
            for (int i = 0; i < Data.Titles.Count - 1; i++)
            {
                if (GetTextPixelWidth(Data.Titles[i], fontSize) / 2 + GetTextPixelWidth(Data.Titles[i + 1], fontSize) / 2 > xOffset * 0.9)
                {
                    fontSize--;
                    if (fontSize < 9)
                    {
                        return fontSize;
                    }
                    passed = false;
                    break;
                }
            }
        }
        return fontSize;
    }

    private string GetTitleTransform(int index)
    {
        int maxTitleLength = Data.Titles.Max(x => x.Length);
        double x = GetXCoordinate(index);
        double y = Height - MarginBottom + 20;
        int size = GetTitleFontsize();
        int rotation = size >= 9 ? 0 : -8;
        return $"rotate({rotation},{x},{y})";
    }
    private void MouseOver(MouseEventArgs e, StackedBarSerie p, int columnIndex)
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

    private void MouseLeave()
    {
        //showTooltip = false;
    }
}
