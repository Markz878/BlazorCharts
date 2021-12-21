using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages
{
    public partial class ScatterChartPage
    {
        private ScatterSeries? data;

        protected override void OnInitialized()
        {
            double x = 0;
            double y = 0;
            data = new ScatterSeries(
                new ScatterSerie("Red series",
                    "rgba(255,0,0,0.75)",
                    Enumerable.Range(0, 20).Select(_ => new ScatterPoint(x = Random.Shared.NextDouble() * 100, y = Random.Shared.NextDouble() * 1000,
                        new Dictionary<string, string>()
                        {
                            {"Energian kulutus", $"{x:G3} kWh/m2"},
                            {"Elinkaarikustannukset", $"{y:G3} t€"},
                            {"Muuttuja 1", $"{Random.Shared.Next(100,1000)}"},
                            {"Muuttuja 2", $"{Random.Shared.Next(100,1000)}"},
                            {"Muuttuja 3", $"{Random.Shared.Next(100,1000)}"},
                        }
                    )).ToList()),
                new ScatterSerie("Blue series", "rgba(0,0,255,0.75)",
                    Enumerable.Range(0, 20).Select(_ => new ScatterPoint(x = Random.Shared.NextDouble() * 100, y = Random.Shared.NextDouble() * 1000,
                        new Dictionary<string, string>
                        {
                            {"Energian kulutus", $"{x:G3} kWh/m2"},
                            {"Elinkaarikustannukset", $"{y:G3} t€"},
                            {"Muuttuja 1", $"{Random.Shared.Next(100,1000)}"},
                            {"Muuttuja 2", $"{Random.Shared.Next(100,1000)}"},
                            {"Muuttuja 3", $"{Random.Shared.Next(100,1000)}"},
                        }
                    )).ToList())
            );
        }
    }
}