﻿using BlazorCharts.PlotDataModels;

namespace BlazorCharts.Client.Pages;

public partial class LineChartPage
{
    private LineSeries? data;
    protected override void OnInitialized()
    {
        data = new LineSeries(
                new LineSerie("Red series", "rgba(255,0,0,0.75)",
                    Enumerable.Range(0, 10000).Select(x => new LinePoint(x, Math.Sin(x / 1000d))).ToList()),
                new LineSerie("Blue series", "rgba(0,0,255,0.75)",
                    Enumerable.Range(0, 10000).Select(x => new LinePoint(x, Math.Cos(x / 1000d))).ToList())
            );
    }
}
