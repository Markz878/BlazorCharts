namespace BlazorCharts.PlotDataModels;

public class LineSeries
{
    public IList<LineSerie> Series { get; }

    public LineSeries(params LineSerie[] series)
    {
        ArgumentNullException.ThrowIfNull(series);
        if (series.Length == 0)
        {
            throw new ArgumentException("No line series given.", nameof(series));
        }
        Series = series;
    }
}
