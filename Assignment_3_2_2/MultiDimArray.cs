using Spectre.Console;
using System;
using System.Globalization;

namespace MultiDimArrayClassNamespace;

internal class MultiDimArrayClass
{
    //------------------------------------------------------------------
    const int MAXSIZE = 10; // 10 x 10 width is max
    //------------------------------------------------------------------
    int NumRows { get; set; }
    int NumCols { get; set; }
    int[,]? TheArray1 { get; set; }
    int[,]? TheArray2 { get; set; }
    bool IsArrayInitialized { get; set; }
    int maxDigitsInside { get; set; }

    //------------------------------------------------------------------
    public MultiDimArrayClass()
    {
        NumRows = MAXSIZE;
        NumCols = MAXSIZE;
        TheArray1 = new int[MAXSIZE, MAXSIZE];
        TheArray2 = new int[MAXSIZE, MAXSIZE];
        IsArrayInitialized = true;
        maxDigitsInside = 3;
    }
    public MultiDimArrayClass(int rows, int columns, int maxDigits = 3)
    {
        NumRows = rows;
        NumCols = columns;
        TheArray1 = new int[NumRows, NumCols];
        TheArray2 = new int[NumRows, NumCols];
        IsArrayInitialized = true;
        maxDigitsInside = maxDigits;
    }
    //------------------------------------------------------------------
    public void ResetArrays()
    {
        if (!IsArrayInitialized)
        {
            Console.WriteLine("Must initialize arrays before resetting them.");
            Console.Beep();
            return;
        }
        // reload array with random values
        Random random = new Random();
        for (int r = 0; r < NumRows; r++)
        {
            for (int c = 0; c < NumCols; c++)
            {
                TheArray1[r, c] = random.Next(-1 * ((int)Math.Pow(10, maxDigitsInside)), (int)Math.Pow(10, maxDigitsInside));
                TheArray2[r, c] = random.Next(-1 * ((int)Math.Pow(10, maxDigitsInside)), (int)Math.Pow(10, maxDigitsInside));
            }
        }
        Console.WriteLine("The Arrays have been loaded with random numbers.");
    }
    //------------------------------------------------------------------
    public void PrintArrays()
    {
        if (!IsArrayInitialized)
        {
            Console.WriteLine("Must initialize arrays before printing them.");
            Console.Beep();
            return;
        }

        // quickly, easily determine max number of printable characters in each value of matrix // credit to another MSSA cohort member Bri
        int maxWidth = 0;
        foreach (int number in TheArray1)
        {
            int len = number.ToString().Length;
            if (len > maxWidth)
            { 
                maxWidth = len;
            }
        }
        foreach (int number in TheArray2)
        {
            int len = number.ToString().Length;
            if (len > maxWidth)
            {
                maxWidth = len;
            }
        }

        // The below is previous non-optimized solution for figuring out max number of printable characters in each value of matrix
                            // scan array for highest value width, taking into account negative numbers
                            //int highestValue = 0;
                            //int lowestValue = 0;
                            //for (int r = 0; r < NumRows; r++)
                            //{
                            //    for (int c = 0; c < NumCols; c++)
                            //    {
                            //        if (highestValue > TheArray[r, c]) // assign highest Val to highestVal
                            //            highestValue = TheArray[r, c];
                            //        if (lowestValue > TheArray[r, c]) // assign lowest Val to lowestVal
                            //            lowestValue = TheArray[r, c];
                            //    }
                            //}
                            //// determine the number of digits in highestValue
                            //int highestDigitCount = 0;
                            //if (highestValue < 0) // if negative number add place for - sign
                            //{
                            //    highestDigitCount++;
                            //}
                            //Console.Write($"highestVal ({highestValue}) has ");
                            //while (highestValue != 0)
                            //{
                            //    highestValue /= 10;
                            //    highestDigitCount++;
                            //}
                            //Console.WriteLine($"{highestDigitCount} digits.");

                            //// determine the number of digits in lowestValue
                            //int lowestDigitCount = 0;
                            //if (lowestValue < 0) // if negative number add place for - sign
                            //{
                            //    lowestDigitCount++;
                            //}
        
                            //Console.Write($"lowestValue ({lowestValue}) has ");
                            //while (lowestValue != 0)
                            //{
                            //    lowestValue /= 10;
                            //    lowestDigitCount++;
                            //}
                            //Console.WriteLine($"{lowestDigitCount} digits.");

                            //int digitLength = 1;
                            //if (lowestDigitCount > highestDigitCount)
                            //{
                            //    digitLength = lowestDigitCount;
                            //}
                            //else
                            //{
                            //    digitLength = highestDigitCount;
                            //}

        // print array ensuring enough 
        Console.WriteLine();
        Console.WriteLine("First Matrix:");
        for (int r = 0; r < NumRows; r++)
        {
            AnsiConsole.Markup("[red]|[/]");
            for (int c = 0; c < NumCols; c++)
            {
                string value = TheArray1[r, c].ToString().PadLeft(maxWidth);
                AnsiConsole.Markup($" {value} [red]|[/]");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Second Matrix:");
        for (int r = 0; r < NumRows; r++)
        {
            AnsiConsole.Markup("[red]|[/]");
            for (int c = 0; c < NumCols; c++)
            {
                string value = TheArray2[r, c].ToString().PadLeft(maxWidth);
                AnsiConsole.Markup($" {value} [red]|[/]");
            }
            Console.WriteLine();
        }
    }
    //------------------------------------------------------------------
    public void SumArrays()
    {
        // add two matrix together using nested loops
        int[,] SumOfMatrix = new int[NumRows, NumCols];
        for (int r = 0; r < NumRows; r++)
        {
            for (int c = 0; c < NumCols; c++)
            {
                SumOfMatrix[r,c] = TheArray1[r,c] + TheArray2[r,c];   
            }
        }

        // determine how many characters to print in the result
        int maxWidth = 0;
        foreach (int number in SumOfMatrix)
        {
            int len = number.ToString().Length;
            if (len > maxWidth)
            {
                maxWidth = len;
            }
        }

        // print value out afterwards
        Console.WriteLine();
        Console.WriteLine("Addition of two Matrix is:");
        for (int r = 0; r < NumRows; r++)
        {
            AnsiConsole.Markup("[red]|[/]");
            for (int c = 0; c < NumCols; c++)
            {
                string value = SumOfMatrix[r, c].ToString().PadLeft(maxWidth);
                AnsiConsole.Markup($" {value} [red]|[/]");
            }
            Console.WriteLine();
        }
    }
    //------------------------------------------------------------------
}