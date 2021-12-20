namespace BlazorCharts.PlotDataModels;

public class LinePoint
{
    public LinePoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }
}