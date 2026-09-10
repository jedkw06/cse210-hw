using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);
        while (number != 0)
        {
            numbers.Add(number);
            Console.Write("Enter a number: ");
            userInput = Console.ReadLine();
            number = int.Parse(userInput);
        }
        Console.WriteLine("The average is: " + numbers.Average());
        Console.WriteLine("The sum is: " + numbers.Sum());
        Console.WriteLine("The largest number is: " + numbers.Max());
    }
}