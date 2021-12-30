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
                new ScatterSerie("Red series", "rgba(255,0,0,0.75)",
                    Enumerable.Range(0, 20).Select(_ => 
                        new ScatterPoint(x = Random.Shared.NextDouble() * 100, y = Random.Shared.NextDouble() * 1000-500, GetTooltip(x,y))).ToList()),
                new ScatterSerie("Blue series", "rgba(0,0,255,0.75)",
                    Enumerable.Range(0, 20).Select(_ => 
                        new ScatterPoint(x = Random.Shared.NextDouble() * 100, y = Random.Shared.NextDouble() * 1000-500, GetTooltip(x, y))).ToList())
            );
        }

        private static IList<string> GetTooltip(double x, double y)
        {
            return new List<string>
            {
                $"KPI variable 1: {x:G3} t�",
                $"KPI variable 2: {y:G3} t�",
                $"    Variable 1: {Random.Shared.Next(100,1000)}",
                $"    Variable 2: {Random.Shared.Next(100,1000)}",
                $"    Variable 3: {Random.Shared.Next(100,1000)}",
            };
        }
    }
}