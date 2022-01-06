namespace BlazorCharts.PlotDataModels
{
    public class PieSeries
    {
        public PieSeries(bool showLabels, params PieItem[] pieItems)
        {
            if (pieItems.Length < 2)
            {
                throw new ArgumentException("Pie series needs at least 2 items.", nameof(pieItems));
            }
            ShowLabels = showLabels;
            PieItems = pieItems;
        }

        public bool ShowLabels { get; }
        public PieItem[] PieItems { get; }
    }
}
