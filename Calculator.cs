using Spectre.Console;

namespace variables;

public readonly struct Calculator
{
    private readonly double _firstNumber;
    private readonly double _secondNumber;
    private readonly char _operation;

    public Calculator(double firstNumber, double secondNumber, char operation)
    {
        _firstNumber = firstNumber;
        _secondNumber = secondNumber;
        _operation = operation;
    }

    private double Calculate()
    {
        switch (_operation)
        {
            case '+':
                return _firstNumber + _secondNumber;

            case '-':
                return _firstNumber - _secondNumber;

            case '*':
                return _firstNumber * _secondNumber;

            case '/':
                if (_secondNumber != 0)
                {
                    return _firstNumber / _secondNumber;
                }
                else return 0;
        }

        return 0;
    }

    public static void Start()
    {
        var rule = new Rule("[red]CALCULATOR[/]");
        rule.Centered();
        AnsiConsole.Write(rule);

        var firstNumber = AnsiConsole.Ask<int>("Input [green]first[/] number:");
        var choose = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose operation")
            .MoreChoicesText("[grey](Move up and down to reveal more choose)[/]")
            .AddChoices(new[]
            {
                "+", "-", "*", "/"
            }));
        AnsiConsole.MarkupLine("You selected: [yellow]{0}[/]", choose);
        var secondNumber = AnsiConsole.Ask<int>("Input [green]second[/] number:");
        var calculator = new Calculator(firstNumber, secondNumber, Convert.ToChar(choose));
        var result = calculator.Calculate();

        AnsiConsole.MarkupLine("{0} {1} {2} = [red]{3}[/]", firstNumber, choose, secondNumber, result);
    }
}