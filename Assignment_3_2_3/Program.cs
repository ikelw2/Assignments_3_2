using System;
using Spectre.Console;
using SpectrePreloadedNamespace;
using CircleClassNamespace;

// 3. Create a console application to overload “+” and “-“ operator
// for adding the areas of 2 circles and getting their area difference respectively.


while (true)
{
    SpectrePreloaded.StartupPanel("Assignment 3.2.3", "Overloaded operator to add areas of circle (objects)");
    //SpectrePreloaded.HighlightMethod("Method 2 to format values", "use foreach number.ToString().Length to count digits // thanks to a peer");



    int size;
    size = SpectrePreloaded.AskUserForInteger("Enter the array size (same for two arrays)");

    Circle myCircle1 = new (3.4);
    Circle myCircle2 = new (5.7);

    if (SpectrePreloaded.AskUserToContinue() == false)
    {
        break;
    }
    Console.Clear();
}







SpectrePreloaded.ShutdownTasks(doReadline: false, doClear: false);
