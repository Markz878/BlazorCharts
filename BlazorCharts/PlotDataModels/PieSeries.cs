namespace BlazorCharts.PlotDataModels
{
    public class PieSeries
    {
        public PieSeries(bool showLabels, params PieItem[] pieItems)
        {
            ShowLabels = showLabels;
            PieItems = pieItems;
        }

        public bool ShowLabels { get; }
        public PieItem[] PieItems { get; }
    }
}
