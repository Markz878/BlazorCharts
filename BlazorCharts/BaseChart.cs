using BlazorCharts.Utilities;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BlazorCharts;

public abstract class BaseChart : ComponentBase
{
    [Parameter][EditorRequired] public required string Title { get; set; } = "";
    [Parameter] public double Width { get; set; } = 600;
    [Parameter] public double Height { get; set; } = 350;
    [Parameter] public bool ShowLegend { get; set; } = true;
    [Parameter] public string FontSize { get; set; } = "12px";
    [Parameter] public string FontColor { get; set; } = "black";
    [Parameter] public string TitleFontSize { get; set; } = "16px";
    [Parameter] public bool Animate { get; set; } = true;

    protected double MarginLeft;
    protected double MarginRight = 10;
    protected double MarginTop = 30;
    protected double MarginBottom;
    protected CultureInfo c = CultureInfo.InvariantCulture;
    protected string StringFormat = "G6";

    protected bool showTooltip;
    protected TooltipInfo? tooltipInfo;

    protected double GetFontSizePixels()
    {
        return GetFontSizeAsNumber() / 2;
    }

    protected double GetFontSizeAsNumber()
    {
        int j;
        for (j = 0; j < FontSize.Length; j++)
        {
            char c = FontSize[j];
            if (!char.IsNumber(c) && c is not '.')
            {
                break;
            }
        }
        if (double.TryParse(FontSize[0..j], out double result))
        {
            return result;
        }
        throw new ArgumentException($"Fontsize {FontSize} is in incorrect format.", nameof(FontSize));
    }
}
