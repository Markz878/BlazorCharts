namespace BlazorCharts.PlotDataModels;

public class ScatterSerie
{
    public ScatterSerie(string title, string color, IList<ScatterPoint> points)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(color);
        ArgumentNullException.ThrowIfNull(points);
        if (points.Count < 2)
        {
            throw new ArgumentException("Scatter series must have at least 2 points.", nameof(points));
        }
        Title = title;
        Color = color;
        Points = points;
    }

    public string Title { get; }
    public string Color { get; }
    public IList<ScatterPoint> Points { get; }
}
