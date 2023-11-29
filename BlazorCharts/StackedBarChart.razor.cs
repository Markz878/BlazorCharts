using BlazorCharts.PlotDataModels;
using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using static System.Math;

namespace BlazorCharts;

public class StackedBarChartBase : BaseChart
{
    [Parameter][EditorRequired] public StackedBarSeries Data { get; set; } = default!;
    [Parameter][EditorRequired] public string YAxisTitle { get; set; } = "";
    [Parameter] public string LabelFontSize { get; set; } = "10px";

    protected double YMax;

    protected override void OnParametersSet()
    {
        SetLimits();
    }

    protected void SetLimits()
    {
        YMax = GetLimit(getElementWiseSum(Data));
        SetMarginLeft(YMax);
        SetMarginRight();
        SetMarginBottom();

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

    private void SetMarginBottom()
    {
        MarginBottom = ShowLegend ? 50 : 30;
    }

    protected void SetMarginRight()
    {
        int lastTitleWidth = GetTextPixelWidth(Data.Titles[^1], GetColumnTitleFontsize());
        MarginRight = Max(lastTitleWidth - 80, 10);
    }

    protected void SetMarginLeft(double ymax)
    {
        double order = Round(Log10(ymax));
        MarginLeft = order < 0 ? (-order + 2) * 10 + 30 : order * 10 + 30;
    }

    protected static double GetLimit(IEnumerable<double> values)
    {
        double maxVal = values.Max();
        double order = Pow(10, Round(Log10(maxVal) - 0.4));
        double maxLimit = MathUtilities.RoundTo10(maxVal, order, true);
        return maxLimit;
    }

    protected IEnumerable<double> YAxis => Enumerable.Range(0, 11).Select(x => YMax * x / 10);

    protected double GetXCoordinate(int order)
    {
        if (Data.Titles.Count == 1)
        {
            return Width / 2;
        }
        double barWidth = GetBarWidth();
        double result = MarginLeft + barWidth + (double)order / (Data.Titles.Count - 1) * (Width - MarginLeft - MarginRight - 2 * barWidth);
        return result;
    }

    protected double GetBarWidth()
    {
        return Max(Width / Data.Titles.Count * 0.3, 35);
    }

    protected double GetBarHeight(double value)
    {
        double result = value / YMax * (Height - MarginTop - MarginBottom);
        return result;
    }

    protected double GetYCoordinate(double value)
    {
        double result = Height - MarginBottom - value / YMax * (Height - MarginTop - MarginBottom);
        return result;
    }

    protected double GetXOffsetBetweenColumns()
    {
        if (Data.Titles.Count == 1)
        {
            return Width / 2;
        }
        double barWidth = GetBarWidth();
        double result = 1d / (Data.Titles.Count - 1) * (Width - MarginLeft - MarginRight - 2 * barWidth);
        return result;
    }

    protected static int GetTextPixelWidth(string text, int fontsize)
    {
        return text.Length * fontsize / 2;
    }

    protected int GetColumnTitleFontsize()
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

    protected string GetTitleTransform(int columnIndex)
    {
        int maxTitleLength = Data.Titles.Max(x => x.Length);
        double x = GetXCoordinate(columnIndex);
        double y = Height - MarginBottom + 20;
        int size = GetColumnTitleFontsize();
        int rotation = size >= 9 ? 0 : -8;
        return $"rotate({rotation.ToString(c)},{x.ToString(c)},{y.ToString(c)})";
    }

    protected void MouseOver(int serieIndex, int columnIndex)
    {
        if (Data.Series[serieIndex].Values[columnIndex].TooltipProperties is not null)
        {
            double x = GetXCoordinate(columnIndex);
            double sum = 0;
            for (int i = 0; i < serieIndex; i++)
            {
                sum += Data.Series[i].Values[columnIndex].Value;
            }
            sum += Data.Series[serieIndex].Values[columnIndex].Value / 2;
            double y = GetYCoordinate(sum);
            string X = x < Width / 2 ? $"{(x + GetBarWidth() / 2 + 3).ToString(c)}px" : $"calc({(x - GetBarWidth() / 2 - 3).ToString(c)}px - 100%)";
            string Y = y <= Height / 2 ? $"{y.ToString(c)}px" : $"calc({y.ToString(c)}px - 100%)";
            tooltipInfo = new(X, Y, Data.Series[serieIndex].Values[columnIndex].TooltipProperties!);
            showTooltip = true;
        }
    }

    protected void MouseLeave()
    {
        showTooltip = false;
    }

    protected IEnumerable<(string title, string color)> GetTitles()
    {
        return Data.Series.Select(x => (x.Title, x.Color));
    }
}
