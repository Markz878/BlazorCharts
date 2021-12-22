using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using static System.Math;

namespace BlazorCharts;

public abstract class XYBaseChart : BaseChart
{
    [Parameter] [EditorRequired] public string YAxisTitle { get; set; } = "";
    [Parameter] [EditorRequired] public string XAxisTitle { get; set; } = "";
    [Parameter] public bool ShowLegend { get; set; } = true;


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
        SetMarginLeft(yValues);
        SetMarginBottom();
        SetMarginRight(xValues);
    }

    private void SetMarginRight(IEnumerable<double> xValues)
    {
        double minVal = xValues.Min();
        double maxVal = xValues.Max();
        double diff = maxVal - minVal;
        double order = Round(Log10(diff));
        MarginRight = Max(order, 1) * 5 + 5;
    }

    private void SetMarginBottom()
    {
        MarginBottom = ShowLegend ? 70 : 35;
    }

    protected void SetMarginLeft(IEnumerable<double> xValues)
    {
        double minVal = xValues.Min();
        double maxVal = xValues.Max();
        double diff = maxVal - minVal;
        double order = Round(Log10(diff));
        MarginLeft = Max(order, 2) * 10 + 30;
    }

    protected static (double min, double max) GetLimits(IEnumerable<double> values)
    {
        double minVal = values.Min();
        double maxVal = values.Max();
        double diff = maxVal - minVal;
        double order = Pow(10, Round(Log10(diff)));
        double maxLimit = MathUtilities.RoundTo10(maxVal, order, true);
        double minLimit = MathUtilities.RoundTo10(minVal, order, false);
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
