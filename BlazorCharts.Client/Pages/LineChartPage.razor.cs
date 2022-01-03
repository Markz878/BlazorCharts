using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class LineChartPage
{
    private LineSeries? data;
    protected override void OnInitialized()
    {
        data = new LineSeries(
                new LineSerie("Red series", "rgba(255,0,0,0.75)", 2,
                    Enumerable.Range(0, 100).Select(x => new LinePoint(x, Math.Sin(x / 10d) * 1.19e3)).ToList()),
                new LineSerie("Blue series", "rgba(0,0,255,0.75)", 2,
                    Enumerable.Range(0, 100).Select(x => new LinePoint(x, Math.Cos(x / 10d) * -1.6e3)).ToList())
            );
    }
}
