using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class StackedBarChartPage
{
    private StackedBarSeries? data;
    private bool movePoints;

    protected override void OnInitialized()
    {
        data = GenerateRandomSeries();
    }

    private async Task MovePoints()
    {
        movePoints = true;
        while (movePoints)
        {
            data = GenerateRandomSeries();
            StateHasChanged();
            await Task.Delay(2000);
        }
    }

    private static StackedBarSeries GenerateRandomSeries()
    {
        int bars = Random.Shared.Next(2, 10);
        return new StackedBarSeries(
            Enumerable.Range(0, bars).Select(x => $"Item number {(x % 3 == 0 ? $"lorem ipsum {x}" : $"{x}")}").ToList(),
            true,
            new StackedBarSerie("Red series", "rgba(255,50,15,1)", "black", Enumerable.Range(0, bars).Select(x => new StackedBarItem((x + 1) * 100d * (Random.Shared.NextDouble() + 0.1), Enumerable.Range(0, 5).Select(x => $"Red item key {x}: Red item value {x}"))).ToList()),
            new StackedBarSerie("Blue series", "rgba(0,50,255,0.75)", "white", Enumerable.Range(0, bars).Select(x => new StackedBarItem((x + 1) * 200d * (Random.Shared.NextDouble() + 0.1), Enumerable.Range(0, 5).Select(x => $"Blue item key {x}: Blue item value {x}"))).ToList()));
    }

    private void CancelMove()
    {
        movePoints = false;
    }
}