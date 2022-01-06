using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class PieChartPage
{
    private PieSeries? data;
    protected override void OnInitialized()
    {
        data = new PieSeries(true,
                new PieItem("Red item", 1, "rgba(255,0,0,0.75)", "black", new List<string>() { "Red Tooltip Line 1", "Red Tooltip Line 2" }),
                new PieItem("Green item", 99, "rgba(0,255,0,0.75)", "black", new List<string>() { "Green Tooltip Line 1", "Green Tooltip Line 2" })
            );
    }
}
