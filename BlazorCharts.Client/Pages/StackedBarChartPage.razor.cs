using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class StackedBarChartPage
{
    private StackedBarSeries data = default!;
    private bool movePoints;

    protected override void OnInitialized()
    {
        data = new StackedBarSeries(
            Enumerable.Range(0, 10).Select(x => $"Item number {(x % 3 == 0 ? $"lorem ipsum {x}" : $"{x}")}").ToList(),
            true,
            new StackedBarSerie("Red series", "rgba(255,50,15,1)", "black", Enumerable.Range(0, 10).Select(x => new StackedBarItem((x + 1) * 100d, Enumerable.Range(0, 5).Select(x => $"Red item key {x}: Red item value {x}"))).ToList()),
            new StackedBarSerie("Blue series", "rgba(0,50,255,0.75)", "white", Enumerable.Range(0, 10).Select(x => new StackedBarItem((x + 1) * 200d, Enumerable.Range(0, 5).Select(x => $"Blue item key {x}: Blue item value {x}"))).ToList()));
    }

    private async Task MovePoints()
    {
        movePoints = true;
        while (movePoints)
        {
            foreach (StackedBarSerie item in data.Series)
            {
                foreach (StackedBarItem p in item.Values)
                {
                    p.Value = Random.Shared.NextDouble() * 90 + 10;
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