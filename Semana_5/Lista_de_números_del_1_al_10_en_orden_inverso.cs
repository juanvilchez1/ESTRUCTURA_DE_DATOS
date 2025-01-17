using System;
using System.Collections.Generic;

public class ReverseNumbers
{
    private List<int> numbers;

    public ReverseNumbers()
    {
        numbers = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i);
        }
    }

    public void DisplayReversed()
    {
        numbers.Reverse();
        Console.WriteLine("Números en orden inverso: " + string.Join(", ", numbers));
    }
}

class Program5
{
    static void Main()
    {
        ReverseNumbers reverseNumbers = new ReverseNumbers();
        reverseNumbers.DisplayReversed();
    }
}
