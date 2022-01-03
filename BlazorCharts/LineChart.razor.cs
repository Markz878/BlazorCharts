using BlazorCharts.PlotDataModels;
using Microsoft.AspNetCore.Components;

namespace BlazorCharts
{
    public class LineChartBase : XYBaseChart
    {
        [Parameter] [EditorRequired] public LineSeries Data { get; set; } = default!;

        protected override void OnParametersSet()
        {
            SetLimits(Data.Series.SelectMany(x => x.Points).Select(x => x.X), Data.Series.SelectMany(x => x.Points).Select(x => x.Y));
        }

        protected string GetPolylinePoints(LineSerie serie)
        {
            return string.Join(" ", serie.Points.Select(x => $"{GetXCoordinate(x.X)},{GetYCoordinate(x.Y)}"));
        }

        protected IEnumerable<(string title, string color)> GetTitles()
        {
            return Data.Series.Select(x=>(x.Title, x.Color));
        }
    }
}