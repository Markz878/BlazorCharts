namespace BlazorCharts.PlotDataModels;

public class ScatterSeries
{
    public ScatterSeries(string title, string color, IList<ScatterPoint> points)
    {
        Title = title;
        Color = color;
        Points = points;
    }

    public string Title { get; }
    public string Color { get; }
    public IList<ScatterPoint> Points { get; }
}
