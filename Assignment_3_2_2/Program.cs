using System;
using Spectre.Console;
using SpectrePreloadedNamespace;
using MultiDimArrayClassNamespace;

using System;
using Spectre.Console;
using SpectrePreloadedNamespace;
using MultiDimArrayClassNamespace;

//
// 1.Create a 2D array to store integers and print them in matrix format with proper formatting.
// e. g:
// | 2 | 3 | 4 |
// | 1 | 4 | 6 |
//

//
// poss improvements: 
// add horizontal lines for better formatting
//


while (true)
{
    SpectrePreloaded.StartupPanel("Assignment 3.2.2", "Multidimensional Array Addition");
    //SpectrePreloaded.HighlightMethod("Method 2 to format values", "use foreach number.ToString().Length to count digits // thanks to a peer");


    int size;
    size = SpectrePreloaded.AskUserForInteger("Enter the array size (same for two arrays)");

    MultiDimArrayClass myMultiDimArray = new(size, size, 2);


    myMultiDimArray.ResetArrays(); // add random values to multidimensional array
    myMultiDimArray.PrintArrays();
    myMultiDimArray.SumArrays();


    if (SpectrePreloaded.AskUserToContinue() == false)
    {
        break;
    }
    Console.Clear();
}




SpectrePreloaded.ShutdownTasks(doReadline: false, doClear: false);
