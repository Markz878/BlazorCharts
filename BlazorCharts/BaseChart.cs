﻿using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;

namespace BlazorCharts;

public abstract class BaseChart : ComponentBase
{
    [Parameter] [EditorRequired] public string Title { get; set; } = "";
    [Parameter] public double Width { get; set; } = 700;
    [Parameter] public double Height { get; set; } = 350;
    [Parameter] public bool ShowLegend { get; set; } = true;

    protected double MarginLeft;
    protected double MarginRight = 10;
    protected double MarginTop = 30;
    protected double MarginBottom;

    protected bool showTooltip;
    protected TooltipInfo? tooltipInfo;
}
