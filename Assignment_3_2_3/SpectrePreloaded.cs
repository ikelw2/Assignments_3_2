using Spectre.Console;

namespace SpectrePreloadedNamespace;
// updated 20260721 mw

internal static class SpectrePreloaded
{
    public static void StartupPanel(string shortTitle, string description)
    {
        AnsiConsole.Write(new Panel($"[gray]{shortTitle}: [/]{description}").BorderColor(Color.MediumVioletRed));
    }
    //===========================================================================
    public static void HighlightMethod(string shortTitle, string description, int linesFollowing = 1)
    {
        AnsiConsole.MarkupLine($"\n\n[red on white]{shortTitle}: {description}[/]");
        for (int i = 0; i < linesFollowing; i++)
        {
            Console.WriteLine();
        }
    }
    //===========================================================================
    public static bool PrimitiveDoesUserWantToQuit()
    {
        Console.Write($"\nEnter Q to quit or press ENTER to continue.");
        string userInput = Console.ReadLine();
        bool result = (userInput.Trim().Equals("q", StringComparison.OrdinalIgnoreCase) == true);
        Console.WriteLine("-------------------------------");
        return result;
    }
    //===========================================================================
    public static bool AskUserToContinue()
    {
        // 1. Create a selection prompt (drop-down style)
        var prompt = new SelectionPrompt<string>()
            .Title("\nDo you wish to continue?")
            .AddChoices(new[] { "yes", "no" })
            .DefaultValue("yes");

        // 2. Use Live Display context or Status to auto-hide the console menu
        string selection = AnsiConsole.Live(new Text("")).Start(ctx =>
        {
            // Present the prompt to the user
            return AnsiConsole.Prompt(prompt);
        });

        bool result = selection.Equals("yes", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine("-------------------------------");
        return result;
    }
    //===========================================================================
    public static void ShutdownTasks(bool doReadline = false, bool doClear = false)
    {
        if (doReadline)
            Console.ReadLine();
        if (doClear)
            Console.Clear();
    }
    //===========================================================================
    public static double AskUserForPositiveDouble(string prompt = "Enter a Double") 
    {
        double input = AnsiConsole.Prompt(
        new TextPrompt<double>($"{prompt}: ")
            .ValidationErrorMessage("[red]Invalid input.[/] Please enter a valid positive decimal number.")
            .Validate(x =>
            {
                return x switch
                {
                    < 0.01 => ValidationResult.Error($"[red]Must be greater than 0.01[/]"),
                    _ => ValidationResult.Success(),
                };
            }));
        return input;
    }
    //===========================================================================
    public static int AskUserForInteger(string prompt = "Enter an Integer") 
    {
        const int minVal = -1000000; // int.MinValue;
        const int maxVal = 1000000; // int.MaxValue; // likely need to update this for your specific program to prevent ERRORS
        int input = AnsiConsole.Prompt(
        new TextPrompt<int>($"{prompt}: ") 
            .Validate(x =>
            {
                return x switch
                {
                    < minVal => ValidationResult.Error($"[red]Must be greater than {minVal}[/]"),
                    > maxVal => ValidationResult.Error($"[red]Must be less than {maxVal}[/]"),
                    _ => ValidationResult.Success(),
                };
            }));
        return input;
    }
    //===========================================================================
    public static string AskUserForString()
    {
        string inputString = AnsiConsole.Prompt(
            new TextPrompt<string>("Please input a string: ")
            );
        return inputString;
    }
    //===========================================================================
    public static bool AskUserYesOrNoQuestion(string question, bool defaultAnswer = true)
    {
        // 1. Create a selection prompt (drop-down style)
        var prompt = new SelectionPrompt<string>()
            .Title(question)
            .AddChoices(new[] { "yes", "no" })
            .DefaultValue(defaultAnswer ? "yes" : "no");

        // 2. Use Live Display context or Status to auto-hide the console menu
        string selection = AnsiConsole.Live(new Text("")).Start(ctx =>
        {
            // Present the prompt to the user
            return AnsiConsole.Prompt(prompt);
        });
        return selection.Equals("yes", StringComparison.OrdinalIgnoreCase);
    }
    //===========================================================================
    public static bool GetStringAskUserYesNoQuestion(string prompt)
    {
        string? answer = AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            //.AddChoice("y")
            //.AddChoice("n")
            .DefaultValue("y")
            .InvalidChoiceMessage("[red]Invalid option.[/] Please reply with n or press enter for y.")
            .Validate(input =>
            {
                string cleanInput = input.Trim().ToLower();
                return cleanInput is "y" or "n"
                    ? ValidationResult.Success()
                    : ValidationResult.Error("[red]Invalid option![/] Please reply with n or press enter for y.");
            }));
        if (answer != null)
        {
            if (answer.Equals("yes") || answer.Equals("y"))
                return true;
            else
                return false;
        }
        Console.WriteLine("error at end of line");
        Console.Beep();
        return false;
    }
    //===========================================================================
}
