using Spectre.Console;

namespace variables;

public readonly struct Triangle
{
    private readonly int _firstSide;
    private readonly int _secondSide;

    public Triangle(int firstSide, int secondSide)
    {
        _firstSide = firstSide; _secondSide = secondSide;
    }

    private double TriangleArea()
    {       
        // ReSharper disable once PossibleLossOfFraction
        return _firstSide * _secondSide / 2;
    }

    public static void Start()
    {
        var rule = new Rule("[red]Calculating the area of triangle[/]");
        AnsiConsole.Write(rule);

        var triangle = new Triangle(
            AnsiConsole.Ask<int>("Input [green]first[/] side:"), 
            AnsiConsole.Ask<int>("Input [green]second[/] side:"));

        AnsiConsole.MarkupLine($"Square =  [red]{triangle.TriangleArea()}[/]");
    }
}