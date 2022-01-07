namespace BlazorCharts.PlotDataModels;

public class LinePoint
{
    public double X { get; set; }
    public double Y { get; set; }
    
    public LinePoint(double x, double y)
    {
        X = x;
        Y = y;
    }
}