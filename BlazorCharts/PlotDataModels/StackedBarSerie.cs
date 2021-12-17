﻿namespace BlazorCharts.PlotDataModels;

public class StackedBarSerie
{
    public StackedBarSerie(string title, string color, IList<double> values, string textColor = "black")
    {
        Title = title;
        Color = color;
        TextColor = textColor;
        Values = values;
    }

    public string Title { get;}
    public string Color { get; }
    public string TextColor { get; }
    public IList<double> Values { get; }
}