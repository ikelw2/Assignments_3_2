Console.WriteLine("Assignment 3_2_5: return index for given element in array\n");

// 
// 5. Create a function that finds the index of a given item in the array
// 
// Examples
// Search([1, 5, 3], 5) ➞ 1
// Search([9, 8, 3], 3) ➞ 2
// Search([1, 2, 3], 4) ➞ -1
// 
// Notes
// If the item is not present, return -1.5. Create a function that finds the index of a given item in the array
// 



while (true)
{

    Console.Write("Step 1. Enter the number of elements in the array: ");
    int arraySize = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[arraySize];


            //Method 1: Solicit user input to fill array
            //for (int i = 0; i < arraySize; i++)
            //{
            //    Console.Write($"Enter the value for array at index [{i}]: ");
            //    array[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //Console.WriteLine();


    //Method 2: randomize integers in array
    for (int i = 0; i < array.Length; i++)
    {
        // Generates numbers between 1 (inclusive) and 101 (exclusive)
        array[i] = Random.Shared.Next(1, 9);
    }
    
    
    
    
    
    Console.Write($"Step 2. Array is: [{string.Join(", ",array)}]. Enter number to search for: ");
    int searchNumber = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"     *** Search([{string.Join(", ", array)}], {searchNumber}) --> {SearchWhileLoop(array, searchNumber)} ***\n");

    
    
    Console.Write("Enter Q to quit or press ENTER to continue.");
    bool userWantsToQuit = (Console.ReadLine().Trim().Equals("q", StringComparison.OrdinalIgnoreCase) == true); // if user enters 'q' or 'Q'
    if (userWantsToQuit == true)
    {
        break; // exit from main program loop
    }
    Console.WriteLine("-----------------------------------------------------");
}
Console.WriteLine();





// option 1 using while loop to search array
int SearchWhileLoop(int[] array, int searchNumber)
{
    bool found = false;
    int index = 0;
    while (!found)
    {
        if (array[index] == searchNumber)
            return index;

        index++;

        if (index >= array.Length)
            return -1;
    }
    return -1;
}

// option 2 using for loop to search array
int SearchForLoop(int[] array, int searchNumber)
{
    for(int i = 0; i < array.Length; ++i)
    {
        if (array[i] == searchNumber)
            return i;
    }
    return -1;
}




