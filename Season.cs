using Spectre.Console;
using System;

namespace variables;

public struct Season
{
    private readonly string _month;

    public Season(string month)
    {
        _month = month;
    }

    public string Now()
    {
        switch (_month)
        {
            case "December":
            case "January":
            case "February":
                return "Winter";
            case "March":
            case "April":
            case "May":
                return "Spring";
            case "June":
            case "July":
            case "August":
                return "Summer";
            case "October":
            case "September":
            case "November":
                return "Autumn";
        }

        return "Incorrect input";
    }

    public static void Start()
    {
        var rule = new Rule("[red]SEASON CHECKER[/]");
        rule.Centered();
        AnsiConsole.Write(rule);

        var Season = new Season(AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose [green]month[/]?")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "January", "February", "March",
                    "April", "May", "June",
                    "July", "August", "September",
                    "October", "November", "December"
                })));

        AnsiConsole.MarkupLine($"{Season._month} in {Season.Now()}");
    }
}