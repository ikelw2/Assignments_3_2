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

SpectrePreloaded.StartupPanel("Assignment 3.2.1", "Print formatting for multidimensional arrays");

SpectrePreloaded.HighlightMethod("Method 1", "primitive counting digits of each array values");

while(true)
{ 
    int rows, columns, maxDigits;
    rows = SpectrePreloaded.AskUserForInteger("Enter the number of rows");
    columns = SpectrePreloaded.AskUserForInteger("Enter the number of columns");
    maxDigits = SpectrePreloaded.AskUserForInteger("Enter the maximum number of digits per randomized value for Array values");

    MultiDimArrayClass myMultiDimArray = new(rows, columns, maxDigits);

    myMultiDimArray.ResetArray(); // add random values to multidimensional array
    myMultiDimArray.PrintArray();


    if (SpectrePreloaded.AskUserToContinue() == false)
    {
        break;
    }
}




SpectrePreloaded.ShutdownTasks(doReadline: false, doClear: false);
