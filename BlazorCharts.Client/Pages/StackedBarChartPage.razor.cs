using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages
{
    public partial class StackedBarChartPage
    {
        private StackedBarSeries? data;
        protected override void OnInitialized()
        {
            data = new StackedBarSeries(
                Enumerable.Range(0, 7).Select(x => $"Item number {(x % 3 == 0 ? $"lorem ipsum doleros {x}" : $"{x}")}").ToList(),
                true,
                new StackedBarSerie("Red series", "rgba(255,50,15,0.75)", "black", Enumerable.Range(0, 7).Select(x => new StackedBarItem((x + 1) * 100d, Enumerable.Range(0, 6).ToDictionary(x => $"Red item key {x}", x => $"Red item value {x}"))).ToList()),
                new StackedBarSerie("Blue series", "rgba(0,50,255,0.75)", "white", Enumerable.Range(0, 7).Select(x => new StackedBarItem((x + 1) * 200d, Enumerable.Range(0, 6).ToDictionary(x => $"Blue item key {x}", x => $"Blue item value {x}"))).ToList()));
        }
    }
}