using Spectre.Console;

namespace variables;

public readonly struct Weather
{
    private readonly int _degree;

    public Weather(int degree)
    {
        _degree = degree;
    }

    private string WeatherQuality()
    {
        return _degree switch
        {
            < 0 => "[navy]Very cold[/]",
            < 10 => "[teal]Cold[/]",
            < 20 => "[wheat4]Normal[/]",
            < 30 => "[gold3_1]Warm[/]",
            >= 30 => "[darkred_1]Heat[/]",
        };
    }

    public static void Start()
    {
        var rule = new Rule("[red]WEATHER CHECKER[/]");
        rule.Centered();
        AnsiConsole.Write(rule);

        var weather = new Weather(AnsiConsole.Ask<int>("How many [green]degrees[/] is it outside?:"));

        AnsiConsole.MarkupLine(weather.WeatherQuality());
    }
}