using BlazorCharts.PlotDataModels;
using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;

namespace BlazorCharts
{
    public class ScatterChartBase : XYBaseChart
    {
        [Parameter] [EditorRequired] public ScatterSeries Data { get; set; } = default!;

        protected override void OnParametersSet()
        {
            SetLimits(Data.Series.SelectMany(x => x.Points).Select(x => x.X), Data.Series.SelectMany(x => x.Points).Select(x => x.Y));
        }

        protected void MouseOver(ScatterPoint p)
        {
            if (p.TooltipProperties is not null)
            {
                double x = GetXCoordinate(p.X);
                double y = GetYCoordinate(p.Y);
                tooltipInfo = new TooltipInfo($"{x}px", $"{y}px", x < Width / 2 ? "0" : "-100%", y < Height / 2 ? "0" : "-100%",
                    p.TooltipProperties.Select(x => $"{x.Key}: {x.Value}"));
                showTooltip = true;
            }
        }

        protected void MouseLeave()
        {
            showTooltip = false;
        }

        protected IEnumerable<(string title, string color)> GetTitles()
        {
            return Data.Series.Select(x => (x.Title, x.Color));
        }
    }
}