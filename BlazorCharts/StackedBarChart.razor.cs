using BlazorCharts.PlotDataModels;
using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using static System.Math;

namespace BlazorCharts;

public partial class StackedBarChart
{
    [EditorRequired] [Parameter] public StackedBarSeries Data { get; set; } = default!;
    [Parameter] public double Width { get; set; } = 700;
    [Parameter] public double Height { get; set; } = 350;
    [Parameter] public string Title { get; set; } = "Stacked Bar Chart";

    private double YMax;

    private double MarginLeft = 30;
    private double MarginRight = 30;
    private const double MarginTop = 30;
    private const double MarginBottom = 50;

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
                    sum += Data.Series[j].Values[i].Value;
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

    private string GetTitleTransform(int columnIndex)
    {
        int maxTitleLength = Data.Titles.Max(x => x.Length);
        double x = GetXCoordinate(columnIndex);
        double y = Height - MarginBottom + 20;
        int size = GetTitleFontsize();
        int rotation = size >= 9 ? 0 : -8;
        return $"rotate({rotation},{x},{y})";
    }

    private void MouseOver(int serieIndex, int columnIndex)
    {
        if (Data.Series[serieIndex].Values[columnIndex].TooltipProperties.Any())
        {
            double x = GetXCoordinate(columnIndex) + (columnIndex < Data.Titles.Count / 2+1 ? GetBarWidth() / 2 + 3 : -GetBarWidth() / 2 - 3);
            double sum = 0;
            for (int i = 0; i < serieIndex; i++)
            {
                sum += Data.Series[i].Values[columnIndex].Value;
            }
            sum += Data.Series[serieIndex].Values[columnIndex].Value / 2;
            double y = GetYCoordinate(sum);
            Console.WriteLine($"{sum} {y}");
            tooltipX = $"{x}px";
            tooltipY = $"{y}px";
            tooltipXTranslate = x < Width / 2 ? "0" : "-100%";
            tooltipYTranslate = y < Height / 2 ? "0" : "-100%";
            tooltipProperties = Data.Series[serieIndex].Values[columnIndex].TooltipProperties.Select(x => $"{x.Key}: {x.Value}");
            showTooltip = true;
        }
    }

    private void MouseLeave()
    {
        showTooltip = false;
    }
}
