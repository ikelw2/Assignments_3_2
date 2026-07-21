using System;
using Spectre.Console;
using SpectrePreloadedNamespace;

//
// 4.Write a function that takes 4 numbers as input to calculate the total and average.
//
// (Make use of params array to pass arguments and out parameters to return both total and average to main method).
// 
// Test Data:
// Enter the First number: 10
// Enter the Second number: 15
// Enter the third number: 20
// Enter the fourth number: 30
// 
// Expected Output:
// The average of 10 , 15 , 20 , 30 is: 18.75
// The total is 75


while (true)
{
    SpectrePreloaded.StartupPanel("Assignment 3.2.4", "Calc tot and avg using params array and out params");
    //SpectrePreloaded.HighlightMethod("Method 1", "TBD");




    double a = SpectrePreloaded.AskUserForDouble("Enter value for  first number");
    double b = SpectrePreloaded.AskUserForDouble("Enter value for second number");
    double c = SpectrePreloaded.AskUserForDouble("Enter value for  third number");
    double d = SpectrePreloaded.AskUserForDouble("Enter value for fourth number");

    double total, average;
    bool noError = CalcTotalAndAvg(out total, out average, [a, b, c, d]);

    if (noError = false)
    {
        AnsiConsole.MarkupLine("[red]ERROR: There was an error - no results for you.[/]");
    }
    else
    {
        string paramString = String.Concat(a, ", ", b, ", ", c, " and ", d);
        AnsiConsole.MarkupLine($"The average of {paramString} is: [green]{average}[/]");
        AnsiConsole.MarkupLine($"The total is [green]{total}[/]");
    }







    if (SpectrePreloaded.AskUserToContinue() == false)
    {
        break;
    }
    Console.Clear();
}








bool CalcTotalAndAvg(out double total, out double average, params double[] inputParams) {
    try
    {
        double localTotal = 0.0;
        int count = 0;
        foreach (double number in inputParams) // for each param in param array numbers
        {
            localTotal += number;
            // sum to get localTotal
            count++;
        }
        // calculate localAverage
        double localAverage = localTotal / count;
        
        // assign calulation results to out variables 
        total = localTotal;
        average = localAverage;
    }
    catch (System.Exception e)
    {
        // inform user there was an error
        Console.Beep();
        AnsiConsole.MarkupLine($"There was an error: [red]{e.Message}[/]");
        
        // assign dummy values and exit
        total = 0.0;
        average = 0.0;
        return false;
    }
    return true;
}








SpectrePreloaded.ShutdownTasks(doReadline: false, doClear: false);
