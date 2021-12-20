using BlazorCharts.Utilities;

namespace BlazorCharts.PlotDataModels;

public class LineSerie
{
    public LineSerie(string title, string color, IList<LinePoint> points)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(color);
        ArgumentNullException.ThrowIfNull(points);
        if (points.Count < 2)
        {
            throw new ArgumentException("Line series must have at least 2 points.", nameof(points));
        }
        if (!GuardUtilities.IsStrictlyAscending(points.Select(x => x.X)))
        {
            throw new ArgumentException("Given line series points' X-values were not strictly ascending.");
        }
        Title = title;
        Color = color;
        Points = points;
    }

    public string Title { get; }
    public string Color { get; }
    public IList<LinePoint> Points { get; }
}