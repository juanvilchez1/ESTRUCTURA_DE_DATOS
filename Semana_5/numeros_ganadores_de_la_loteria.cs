using System;
using System.Collections.Generic;
using System.Linq;

public class Lottery
{
    private List<int> winningNumbers;

    public Lottery()
    {
        winningNumbers = new List<int>();
    }

    public void GetWinningNumbers()
    {
        Console.WriteLine("Introduce los números ganadores separados por comas:");
        string input = Console.ReadLine();
        winningNumbers = input.Split(',').Select(int.Parse).ToList();
    }

    public void DisplaySortedNumbers()
    {
        winningNumbers.Sort();
        Console.WriteLine("Números ganadores ordenados: " + string.Join(", ", winningNumbers));
    }
}

class Program4
{
    static void Main()
    {
        Lottery lottery = new Lottery();
        lottery.GetWinningNumbers();
        lottery.DisplaySortedNumbers();
    }
}
