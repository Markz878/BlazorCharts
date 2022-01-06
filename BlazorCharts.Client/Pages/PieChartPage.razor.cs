using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class PieChartPage
{
    private PieSeries? data;
    protected override void OnInitialized()
    {
        data = new PieSeries(true,
                new PieItem("Red item", 30, "rgba(255,0,0,0.75)", "black", new List<string>() { "Red Tooltip Line 1", "Red Tooltip Line 2" }),
                new PieItem("Blue item", 45, "rgba(0,0,255,0.75)", "black", new List<string>() { "Blue Tooltip Line 1", "Blue Tooltip Line 2" }),
                new PieItem("Green item", 95, "rgba(0,255,0,0.75)", "black", new List<string>() { "Green Tooltip Line 1", "Green Tooltip Line 2" }),
                new PieItem("Pink item", 25, "rgba(255,100,100,0.5)", "green", new List<string>() { "Pink Tooltip Line 1", "Pink Tooltip Line 2" }),
                new PieItem("Yellow item", 55, "rgba(255,255,0,0.75)", "blue", new List<string>() { "Yellow Tooltip Line 1", "Yellow Tooltip Line 2" })
            );
    }
}
