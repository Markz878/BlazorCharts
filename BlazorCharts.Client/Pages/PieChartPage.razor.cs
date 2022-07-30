using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class PieChartPage
{
    private PieSeries data = default!;
    private bool movePoints;

    protected override void OnInitialized()
    {
        data = new PieSeries(true,
                new PieItem("Red item", 30, "rgba(255,0,0,0.75)", "black", new List<string>() { "Red Tooltip Line 1", "Red Tooltip Line 2" }),
                new PieItem("Green item", 55, "rgba(0,255,0,0.75)", "black", new List<string>() { "Green Tooltip Line 1", "Green Tooltip Line 2" }),
                new PieItem("Blue item", 42, "rgba(0,0,255,0.75)", "black", new List<string>() { "Blue Tooltip Line 1", "Blue Tooltip Line 2" })
            );
    }

    private async Task MovePoints()
    {
        movePoints = true;
        while (movePoints)
        {
            foreach (PieItem item in data.PieItems)
            {
                item.Value = Math.Round(Random.Shared.NextDouble() * 95 + 5);
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
