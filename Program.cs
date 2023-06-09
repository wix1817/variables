using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Spectre.Console;

public static class Program
{
    static int rectangleCalc(int x, int y)
    {
        return x * y;
    }

    static double triangleCalc(int x, int y)
    {
        return x * y / 2;
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
                return x / y;
        }

        return 0;
    }

    static bool adultChecker(int age)
    {
        if (age < 18)
        {
            return false;
        }
        return true;
    }

    static string weatherChecker(int degree)
    {
        if (degree < 0)
            return "Very cold";
        if (degree < 10)
            return "Cold";
        if (degree < 20)
            return "Normal";
        if (degree < 30)
            return "Warm";
        if (degree >= 30)
            return "Heat";
        return "Error";
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

        return "Error";
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
                    .PageSize(20)
                    .AddChoices(new[]
                    {
                        "1: Calculating the area of ​​a rectangle",
                        "2: Calculating the area of ​​a triangle",
                        "3: Calculator",
                        "4: Adult checker",
                        "5: Temperature checker",
                        "6: Season checker"
                    }));

            switch (operation.First())
            {
                case '1':
                {
                    Console.WriteLine("Input firs side: ");
                    int a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Input second side: ");
                    int b = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Square = " + Convert.ToString(rectangleCalc(a, b)));
                    toContinue = askToContinue();
                    break;
                }

                case '2':
                {
                    Console.WriteLine("Input firs side: ");
                    int a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Input second side: ");
                    int b = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Square = " + Convert.ToString(triangleCalc(a, b)));
                    toContinue = askToContinue();
                    break;
                }

                case '3':
                {
                    Console.WriteLine("Hey, this is calculator =)");
                    Console.Write("Input first number: ");
                    int a = Int32.Parse(Console.ReadLine());
                    Console.Write("Input operation(+, -, *, /): ");
                    char op = Convert.ToChar(Console.ReadLine());
                    Console.Write("Input second number: ");
                    int b = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(a.ToString() + " " + op + " " + b.ToString() + " = " +
                                      Convert.ToString(сalculator(a, b, op)));
                    askToContinue();
                    break;
                }

                case '4':
                {
                    Console.WriteLine("How old are u? ");
                    int a = Int32.Parse(Console.ReadLine());
                    if (adultChecker(a))
                    {
                        Console.WriteLine("You are adult!");
                    }
                    else Console.WriteLine("You are not adult!");
                    askToContinue();
                    break;
                }

                case '5':
                {
                    Console.WriteLine("How many degrees is it outside?");
                    int a = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(weatherChecker(a));
                    askToContinue();
                    break;
                }

                case '6':
                {
                    Console.Write("Input month: ");
                    string a = Console.ReadLine();
                    Console.WriteLine(seasonChecker(a));
                    askToContinue();
                    break;
                }
            }
        }

    }

    
}