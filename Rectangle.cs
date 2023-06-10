using Spectre.Console;

namespace variables;

public readonly struct Rectangle
{
    private readonly int _firstSide;
    private readonly int _secondSide;

    public Rectangle(int firstSide, int secondSide)
    {
        _firstSide = firstSide; _secondSide = secondSide;
    }

    private int RectangleArea()
    {
        return _firstSide * _secondSide;
    }

    public static void Start()
    {
        var rule = new Rule("[red]Calculating the area of rectangle[/]");
        AnsiConsole.Write(rule);

        var rectangle = new Rectangle(
            AnsiConsole.Ask<int>("Input [green]first[/] side:"),
            AnsiConsole.Ask<int>("Input [green]second[/] side:"));

        AnsiConsole.MarkupLine($"Square =  [red]{rectangle.RectangleArea()}[/]");
    }
}