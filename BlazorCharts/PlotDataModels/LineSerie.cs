using BlazorCharts.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class LineSerie
{
    public required string Title { get; set; }
    public required string Color { get; set; }
    public required double Thickness { get; set; }
    public required IList<LinePoint> Points { get; set; }

    public LineSerie()
    {
    }

    [SetsRequiredMembers]
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