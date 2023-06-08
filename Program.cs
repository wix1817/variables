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
        else return true;
    }

    static string weatherChecker(int degree)
    {
        if (degree < 0)
            return "Very cold";
        else if (degree < 10)
            return "Cold";
        else if (degree < 20)
            return "Normal";
        else if (degree < 30)
            return "Good";
        else if (degree >= 30)
            return "Warm";
        throw new
            ();
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

        return "говно";
    }
    public static void Main(string[] args)
    {
        var operation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select the required operation:")
                .PageSize(20)
                .AddChoices(new[] {
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
                break;
            }

            case '2':
            {
                Console.WriteLine("Input firs side: ");
                int a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Input second side: ");
                int b = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Square = " + Convert.ToString(triangleCalc(a, b)));
                break;
            }

            case '3':
            {
                Console.WriteLine("Hey, this is calculator =)");
                Console.WriteLine("Input first number: ");
                int a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Input operation(+, -, *, /): ");
                char op = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Input second number: ");
                int b = Int32.Parse(Console.ReadLine());
                Console.WriteLine(a.ToString() + " " + op + " " + b.ToString() + " = " + Convert.ToString(сalculator(a, b, op)));
                break;
            }
        }

    }

    
}