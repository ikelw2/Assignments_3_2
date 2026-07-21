using System;
using Spectre.Console;
using SpectrePreloadedNamespace;
using CircleClassNamespace;

// 3. Create a console application to overload “+” and “-“ operator
// for adding the areas of 2 circles and getting their area difference respectively.


while (true)
{
    SpectrePreloaded.StartupPanel("Assignment 3.2.3", "Overloaded operator to add/subtract objects of \ntype circle, resulting in a new circle with sum/diff of area");
    //SpectrePreloaded.HighlightMethod("Method 1", "brute force");



    double area1 = SpectrePreloaded.AskUserForPositiveDouble("Enter the area of circle 1");
    double radius1 = Math.Sqrt((area1 / Math.PI));

    double area2 = SpectrePreloaded.AskUserForPositiveDouble("Enter the area of circle 2");
    double radius2 = Math.Sqrt((area2 / Math.PI));

    Circle circle1 = new(radius1);
    Circle circle2 = new(radius2);

    Circle combined = circle1 + circle2;
    Circle difference = circle1 - circle2;

    AnsiConsole.MarkupLine($"The area of the new combined circle is [yellow]{combined.ToString():D3}[/]");
    AnsiConsole.MarkupLine($"The area of the new difference circle is [yellow]{difference.ToString():D3}[/]");


    if (SpectrePreloaded.AskUserToContinue() == false)
    {
        break;
    }
    Console.Clear();
}







SpectrePreloaded.ShutdownTasks(doReadline: false, doClear: false);
