using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class ScatterSerie
{
    public required string Title { get; set; }
    public required string Color { get; set; }
    public required IList<ScatterPoint> Points { get; set;}

    public ScatterSerie()
    {
    }

    [SetsRequiredMembers]
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
}
