using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class ScatterSeries
{
    public required IList<ScatterSerie> Series { get; set; }
    public ScatterSeries()
    {
    }

    [SetsRequiredMembers]
    public ScatterSeries(params ScatterSerie[] series)
    {
        ArgumentNullException.ThrowIfNull(series);
        if (series.Length == 0)
        {
            throw new ArgumentException("No scatter series given.", nameof(series));
        }
        Series = series;
    }
}
