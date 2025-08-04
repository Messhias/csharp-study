public class Shoe
{
    public Style Style
    {
        get; private set;
    }

    public string Color
    {
        get;
        private set;
    }

    public Shoe(Style style, string color)
    {
        Style = style;
        Color = color;
    }

    public string Description => $"A {Color} {Style}";
}