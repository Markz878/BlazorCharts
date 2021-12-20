namespace BlazorCharts.PlotDataModels;

public class ScatterSerie
{
    public ScatterSerie(string title, string color, IList<ScatterPoint> points)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(color);
        ArgumentNullException.ThrowIfNull(points);
        if (points.Count == 0)
        {
            throw new ArgumentException("No point given for scatter serie.", nameof(points));
        }
        Title = title;
        Color = color;
        Points = points;
    }

    public string Title { get; }
    public string Color { get; }
    public IList<ScatterPoint> Points { get; }
}
