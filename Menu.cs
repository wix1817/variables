using Spectre.Console;

namespace variables;

public struct Menu
{
    private static bool AskToContinue()
    {
        if (!AnsiConsole.Confirm("Want to continue?"))
        {
            AnsiConsole.MarkupLine("Ok... :(");
            return false;
        }

        else
        {
            AnsiConsole.Clear();
            return true;
        }
    }

    public static void Start()
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
                    Rectangle.Start();
                    toContinue = AskToContinue();
                    break;
                }

                case '2':
                {
                    Triangle.Start();
                    toContinue = AskToContinue();
                    break;
                }

                case '3':
                {
                    Calculator.Start();
                    toContinue = AskToContinue();
                    break;
                }

                case '4':
                {
                    Person.Start();
                    toContinue = AskToContinue();
                    break;
                }

                case '5':
                {
                    Weather.Start();
                    toContinue = AskToContinue();
                    break;
                }

                case '6':
                {
                    Season.Start();
                    toContinue = AskToContinue();
                    break;
                }
                case '0':
                {
                    AnsiConsole.MarkupLine("Bye... :(");
                    Environment.Exit(0);
                    break;
                }
            }
        }
    }
}