using BlazorCharts.PlotDataModels;
using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorCharts;

public class LineChartBase : XYBaseChart, IAsyncDisposable
{
    [Parameter][EditorRequired] public required LineSeries Data { get; init; }
    [Inject] public required IJSRuntime JS { get; init; }

    private IJSObjectReference? jsmodule;
    protected ElementReference ChartRectRef;
    protected int ChartTooltipIndex;

    protected override void OnParametersSet()
    {
        SetLimits(Data.Series.SelectMany(x => x.Points).Select(x => x.X), Data.Series.SelectMany(x => x.Points).Select(x => x.Y));
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            jsmodule = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorSVGCharts/scripts.js");
        }
    }

    protected async Task MouseMove(MouseEventArgs e)
    {
        if(jsmodule is not null)
        {
            BoundingRectangle rect = await jsmodule.InvokeAsync<BoundingRectangle>("getBoundingRectangle", ChartRectRef);
            Console.WriteLine(rect);
            double xShare = (e.ClientX - rect.Left) / rect.Width;
            double yShare = (e.ClientY - rect.Top) / rect.Height;
            double x = MarginLeft + xShare * (Width - MarginLeft - MarginRight);
            double y = MarginTop + yShare * (Height - MarginTop - MarginBottom);
            string X = x < Width / 2 ? $"{x.ToString(c)}px" : $"calc({x.ToString(c)}px - 100%)";
            string Y = y < Height / 2 ? $"{y.ToString(c)}px" : $"calc({y.ToString(c)}px - 100%)";
            ChartTooltipIndex = (int)(Data.Series[0].Points.Count * xShare);
            tooltipInfo = new TooltipInfo(X, Y, Data.Series.Select(x => $"{x.Title}:{x.Points[ChartTooltipIndex].Y:G6}"));
            showTooltip = true;
            await Task.Delay(50);
        }
    }

    protected void MouseLeave()
    {
        showTooltip = false;
    }

    protected string GetPolylinePoints(LineSerie serie)
    {
        return string.Join(" ", serie.Points.Select(x => $"{GetXCoordinate(x.X).ToString(c)},{GetYCoordinate(x.Y).ToString(c)}"));
    }

    protected IEnumerable<(string title, string color)> GetTitles()
    {
        return Data.Series.Select(x => (x.Title, x.Color));
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (jsmodule is not null)
        {
            await jsmodule.DisposeAsync();
        }
        GC.SuppressFinalize(this);
    }
}