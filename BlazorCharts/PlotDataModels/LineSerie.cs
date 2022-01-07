using BlazorCharts.Utilities;

namespace BlazorCharts.PlotDataModels;

public class LineSerie
{
    public string Title { get; set; }
    public string Color { get; set; }
    public double Thickness { get; set; }
    public IList<LinePoint> Points { get; }

    public LineSerie(string title, string color, double thickness, IList<LinePoint> points)
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
        Thickness = thickness;
        Points = points;
    }
}