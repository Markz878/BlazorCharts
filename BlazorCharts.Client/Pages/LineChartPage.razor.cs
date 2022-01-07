using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class LineChartPage
{
    private LineSeries? data;
    private bool movePoints;

    protected override void OnInitialized()
    {
        data = new LineSeries(
                new LineSerie("Red series", "rgba(255,0,0,0.75)", 2,
                    Enumerable.Range(0, 100).Select(x => new LinePoint(x, Math.Sin(x / 10d) * 1e3)).ToList()),
                new LineSerie("Blue series", "rgba(0,0,255,0.75)", 2,
                    Enumerable.Range(0, 100).Select(x => new LinePoint(x, Math.Sin(x / 10d + Math.PI / 2) * -1e3)).ToList())
            );
    }

    private async Task MovePoints()
    {
        movePoints = true;
        while (movePoints)
        {
            foreach (LineSerie? item in data.Series)
            {
                double phase = Random.Shared.NextDouble() * Math.PI;
                for (int i = 0; i < item.Points.Count; i++)
                {
                    LinePoint? p = item.Points[i];
                    p.Y = Math.Sin(i / 10d + phase) * 1e3;
                }
            }
            StateHasChanged();
            await Task.Delay(2000);
        }
    }

    private void CancelMove()
    {
        movePoints = false;
    }
}
