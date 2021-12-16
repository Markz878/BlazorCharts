namespace BlazorCharts.PlotDataModels;

public class StackedBarSerie
{
    public StackedBarSerie(string color, IList<double> values)
    {
        Color = color;
        Values = values;
    }

    public string Color { get;}
    public IList<double> Values { get; }
}