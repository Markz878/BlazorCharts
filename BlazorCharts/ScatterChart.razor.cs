using BlazorCharts.PlotDataModels;
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
                tooltipX = $"{x}px";
                tooltipY = $"{y}px";
                tooltipXTranslate = x < Width / 2 ? "0" : "-100%";
                tooltipYTranslate = y < Height / 2 ? "0" : "-100%";
                tooltipProperties = p.TooltipProperties.Select(x => $"{x.Key}: {x.Value}");
                showTooltip = true;
            }
        }

        protected void MouseLeave()
        {
            showTooltip = false;
        }
    }
}