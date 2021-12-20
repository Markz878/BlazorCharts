namespace BlazorCharts.PlotDataModels;

public class ScatterSeries
{
    public IList<ScatterSerie> Series { get; }

    public ScatterSeries(params ScatterSerie[] series)
    {
        ArgumentNullException.ThrowIfNull(series);
        Series = series;
    }
}
