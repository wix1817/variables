using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Spectre.Console;

public static class Program
{
    static int rectangleCalc(int x, int y)
    {
        return x * y;
    }

    static bool rectangleMenu()
    {
        var rule = new Rule("[red]Calculating the area of rectangle[/]");
        AnsiConsole.Write(rule);
        var firstSide = AnsiConsole.Ask<int>("Input [green]first[/] side:");
        var secondSide = AnsiConsole.Ask<int>("Input [green]second[/] side:");
        var area = rectangleCalc(Convert.ToInt32(firstSide), Convert.ToInt32(secondSide)).ToString();
        AnsiConsole.MarkupLine($"Square =  [red]{area}[/]");
        return true;
    }

    static double triangleCalc(int x, int y)
    {
        return x * y / 2;
    }

    static bool triangleMenu() 
    {
        var rule = new Rule("[red]Calculating the area of triangle[/]");
        AnsiConsole.Write(rule);
        var firstSide = AnsiConsole.Ask<int>("Input [green]first[/] side:");
        var secondSide = AnsiConsole.Ask<int>("Input [green]second[/] side:");
        var area = triangleCalc(Convert.ToInt32(firstSide), Convert.ToInt32(secondSide)).ToString();
        AnsiConsole.MarkupLine($"Square =  [red]{area}[/]");

        return true;
    }

    static double сalculator(int x, int y, char operation)
    {
        switch (operation)
        {
            case '+':
                return x + y;

            case '-':
                return x - y;

            case '*':
                return x * y;

            case '/':
                if (y != 0)
                {
                    return x / y;
                }
                else return 0;
        }

        return 0;
    }

    static bool calculatorMenu()
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
        var result = Convert.ToString(сalculator(firstNumber, secondNumber, Convert.ToChar(choose)));
        AnsiConsole.MarkupLine(
            firstNumber.ToString() + " " + choose + " " + secondNumber.ToString() + " = [red]{0}[/]", result);
        return true;
    }

    static bool adultChecker(int age)
    {
        if (age < 18)
        {
            return false;
        }
        return true;
    }

    static bool adultCheckerMenu()
    {
        var rule = new Rule("[red]ADULT CHECKER[/]");
        rule.Centered();
        AnsiConsole.Write(rule);

        var age = AnsiConsole.Ask<int>("Insert you [green]age[/]:");
        if (adultChecker(age))
        {
            AnsiConsole.MarkupLine("You are [green]adult![/]");
        }
        else AnsiConsole.MarkupLine("You are [red]not adult[/]!");
        return true;
    }

    static string weatherChecker(int degree)
    {
        if (degree < 0)
            return "[navy]Very cold[/]";
        if (degree < 10)
            return "[teal]Cold[/]";
        if (degree < 20)
            return "[wheat4]Normal[/]";
        if (degree < 30)
            return "[gold3_1]Warm[/]";
        if (degree >= 30)
            return "[darkred_1]Heat[/]";
        return "Error";
    }

    static bool weatherCheckerMenu()
    {
        var rule = new Rule("[red]WEATHER CHECKER[/]");
        rule.Centered();
        AnsiConsole.Write(rule);

        var degree = AnsiConsole.Ask<int>("How many [green]degrees[/] is it outside?:");
        AnsiConsole.MarkupLine(weatherChecker(degree));

        return true;
    }

    static string seasonChecker(string month)
    {
        switch (month)
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

    static bool seasonCheckerMenu()
    {
        var rule = new Rule("[red]SEASON CHECKER[/]");
        rule.Centered();
        AnsiConsole.Write(rule);

        var month = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose [green]month[/]?")
                .PageSize(10)
                .AddChoices(new[] {
                    "January", "February", "March",
                    "April", "May", "June",
                    "July", "August", "September",
                    "October", "November", "December"
                }));
        AnsiConsole.MarkupLine(month + " in " + seasonChecker(month));

        return true;
    }

    static bool askToContinue()
    {
        if (!AnsiConsole.Confirm("Want to continue?"))
        {
            AnsiConsole.MarkupLine("Ok... :(");
            return false;
        }

        else
        {
            Console.Clear();
            return true;
        }
    }


    public static void Main(string[] args)
    {
        bool toContinue = true;
        while (toContinue)
        {
            var operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select the required operation:")
                    .PageSize(50)
                    .AddChoices(new[]
                    {
                        "1: Calculating the area of a rectangle",
                        "2: Calculating the area of a triangle",
                        "3: Calculator",
                        "4: Adult checker",
                        "5: Temperature checker",
                        "6: Season checker",
                        "0: Exit"
                    }));

            switch (operation.First())
            {
                case '1':
                {
                    rectangleMenu();
                    toContinue = askToContinue();
                    break;
                }

                case '2':
                {
                    triangleMenu();
                    toContinue = askToContinue();
                    break;
                }

                case '3':
                {
                    calculatorMenu();
                    toContinue = askToContinue();
                    break;
                }

                case '4':
                {
                    adultCheckerMenu();
                    toContinue = askToContinue();
                    break;
                }

                case '5':
                {
                    weatherCheckerMenu();
                    toContinue = askToContinue();
                    break;
                }

                case '6':
                {
                    seasonCheckerMenu();
                    toContinue = askToContinue();
                    break;
                }
                case '0':
                {
                    Environment.Exit(0);
                    break;
                }
            }
        }

    }

    
}