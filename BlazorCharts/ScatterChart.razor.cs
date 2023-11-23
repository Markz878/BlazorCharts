using BlazorCharts.PlotDataModels;
using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;

namespace BlazorCharts
{
    public class ScatterChartBase : XYBaseChart
    {
        [Parameter][EditorRequired] public ScatterSeries Data { get; set; } = default!;
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
                string X = x < Width / 2 ? $"{x.ToString(c)}px" : $"calc({x.ToString(c)}px - 100%)";
                string Y = y < Height / 2 ? $"{y.ToString(c)}px" : $"calc({y.ToString(c)}px - 100%)";
                tooltipInfo = new TooltipInfo(X, Y, p.TooltipProperties);
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