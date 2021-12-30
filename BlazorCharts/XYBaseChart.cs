using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using static System.Math;

namespace BlazorCharts;

public abstract class XYBaseChart : BaseChart
{
    [Parameter] [EditorRequired] public string YAxisTitle { get; set; } = "";
    [Parameter] [EditorRequired] public string XAxisTitle { get; set; } = "";

    protected double XMin;
    protected double XMax;
    protected double YMin;
    protected double YMax;

    protected IEnumerable<double> XAxis => Enumerable.Range(0, 11).Select(x => Round((XMax - XMin) * x / 10 + XMin, 8));
    protected IEnumerable<double> YAxis => Enumerable.Range(0, 11).Select(x => Round((YMax - YMin) * x / 10 + YMin, 8));

    protected virtual void SetLimits(IEnumerable<double> xValues, IEnumerable<double> yValues)
    {
        (XMin, XMax) = GetLimits(xValues);
        (YMin, YMax) = GetLimits(yValues);
        SetMarginLeft();
        SetMarginBottom();
        SetMarginRight();
    }

    private void SetMarginRight()
    {
        int xAxisLastTextLength = XAxis.Last().ToString(StringFormat).Length;
        MarginRight = xAxisLastTextLength * 5 + 5;
    }

    private void SetMarginBottom()
    {
        MarginBottom = ShowLegend ? 70 : 35;
    }

    private void SetMarginLeft()
    {
        int yAxisTextMaxLength = YAxis.Select(x=> x.ToString(StringFormat).Length).Max();
        MarginLeft = yAxisTextMaxLength * 5 + 30;
    }

    private static (double min, double max) GetLimits(IEnumerable<double> values)
    {
        double minVal = values.Min();
        double maxVal = values.Max();
        double diff = maxVal - minVal;
        double order = Pow(10, Round(Log10(diff)) - 1);
        double minLimit = MathUtilities.RoundTo10(minVal, order, false);
        double maxLimit = MathUtilities.RoundTo10(maxVal, order, true);
        return (minLimit, maxLimit);
    }

    protected double GetXAxisTitleY()
    {
        return Height - (ShowLegend ? 35 : 5);
    }

    protected double GetXAxisTickYCoordinate()
    {
        return Height - (ShowLegend ? 50 : 20);
    }

    protected double GetXCoordinate(double value)
    {
        double result = MarginLeft + (value - XMin) / (XMax - XMin) * (Width - MarginLeft - MarginRight);
        return result;
    }

    protected double GetYCoordinate(double value)
    {
        double result = Height - MarginBottom - (value - YMin) / (YMax - YMin) * (Height - MarginBottom - MarginTop);
        return result;
    }
}
