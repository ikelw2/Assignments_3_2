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
    int[,]? TheArray { get; set; }
    bool IsArrayInitialized { get; set; }
    int maxDigitsInside { get; set; }

    //------------------------------------------------------------------
    public MultiDimArrayClass()
    {
        NumRows = MAXSIZE;
        NumCols = MAXSIZE;
        TheArray = new int[MAXSIZE, MAXSIZE];
        IsArrayInitialized = true;
        maxDigitsInside = 5;
    }
    public MultiDimArrayClass(int rows, int columns, int maxDigits = 5)
    {
        NumRows = rows;
        NumCols = columns;
        TheArray = new int[NumRows, NumCols];
        IsArrayInitialized = true;
        maxDigitsInside = maxDigits;
    }
    //------------------------------------------------------------------
    public void ResetArray()
    {
        if (!IsArrayInitialized)
        {
            Console.WriteLine("Must initialize array before resetting it.");
            Console.Beep();
            return;
        }
        // reload array with random values
        Random random = new Random();
        for (int r = 0; r < NumRows; r++)
        {
            for (int c = 0; c < NumCols; c++)
            {
                TheArray[r, c] = random.Next(-1 * ((int)Math.Pow(10, maxDigitsInside)), (int)Math.Pow(10, maxDigitsInside));
            }
        }
        Console.WriteLine("The Array has been loaded with random numbers.");
    }
    //------------------------------------------------------------------
    public void PrintArray()
    {
        if (!IsArrayInitialized)
        {
            Console.WriteLine("Must initialize array before printing it.");
            Console.Beep();
            return;
        }
        // scan array for highest value width, taking into account negative numbers
        int highestValue = 0;
        int lowestValue = 0;
        for (int r = 0; r < NumRows; r++)
        {
            for (int c = 0; c < NumCols; c++)
            {
                if (highestValue > TheArray[r, c]) // assign highest Val to highestVal
                    highestValue = TheArray[r, c];
                if (lowestValue > TheArray[r, c]) // assign lowest Val to lowestVal
                    lowestValue = TheArray[r, c];
            }
        }
        // determine the number of digits in highestValue
        int highestDigitCount = 0;
        if (highestValue < 0) // if negative number add place for - sign
        {
            highestDigitCount++;
        }
        Console.Write($"highestVal ({highestValue}) has ");
        while (highestValue != 0)
        {
            highestValue /= 10;
            highestDigitCount++;
        }
        Console.WriteLine($"{highestDigitCount} digits.");

        // determine the number of digits in lowestValue
        int lowestDigitCount = 0;
        if (lowestValue < 0) // if negative number add place for - sign
        {
            lowestDigitCount++;
        }
        
        Console.Write($"lowestValue ({lowestValue}) has ");
        while (lowestValue != 0)
        {
            lowestValue /= 10;
            lowestDigitCount++;
        }
        Console.WriteLine($"{lowestDigitCount} digits.");

        int digitLength = 1;
        if (lowestDigitCount > highestDigitCount)
        {
            digitLength = lowestDigitCount;
        }
        else
        {
            digitLength = highestDigitCount;
        }

        // print array ensuring enough 
        Console.WriteLine();
        for (int r = 0; r < NumRows; r++)
        {
            AnsiConsole.Markup("[red]|[/]");
            //Console.Write("|");
            for (int c = 0; c < NumCols; c++)
            {
                string value = TheArray[r, c].ToString().PadLeft(digitLength);
                AnsiConsole.Markup($" {value} [red]|[/]");
                //Console.Write($" {value} |");
            }
            Console.WriteLine();
        }
    }
    //------------------------------------------------------------------
}