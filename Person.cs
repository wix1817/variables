using Spectre.Console;

namespace variables;

public readonly struct Person
{
    private readonly int _age;

    public Person(int age)
    {
        _age = age;
    }

    public bool IsAdult()
    {
        return _age switch
        {
            < 18 => false,
            _ => true
        };
    }
    public static void Start()
    {
        var rule = new Rule("[red]ADULT CHECKER[/]");
        rule.Centered();
        AnsiConsole.Write(rule);

        var person = new Person(AnsiConsole.Ask<int>("Insert you [green]age[/]:"));

        AnsiConsole.MarkupLine(person.IsAdult() ? "You are [green]adult![/]" : "You are [red]not adult[/]!");
    }
}