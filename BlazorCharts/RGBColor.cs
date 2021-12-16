namespace BlazorCharts;

internal class RGBColor
{
    internal RGBColor(byte red, byte green, byte blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }

    public override string ToString()
    {
        return $"rgb({Red},{Green},{Blue})";
    }
}
