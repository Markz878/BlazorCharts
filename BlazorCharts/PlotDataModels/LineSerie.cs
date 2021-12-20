namespace BlazorCharts.PlotDataModels;

public class LineSerie
{
    public LineSerie(string title, string color, IList<LinePoint> points)
    {
        Title = title;
        Color = color;
        Points = points;
    }

    public string Title { get; }
    public string Color { get; }
    public IList<LinePoint> Points { get; }
}