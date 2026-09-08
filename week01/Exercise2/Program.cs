using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What grade percentage did you score on the test? ");
        string  userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);
        if (gradePercentage >= 90)
        {
            Console.WriteLine("You recieved an A");
        }
        else if (gradePercentage >= 80)
        {
            Console.WriteLine("You recieved a B");
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine("You received a C");
        }
        else if (gradePercentage >= 60)
        {
            Console.WriteLine("You recieved a D");
        }
        else
        {
            Console.WriteLine("You recieved an F");
        }
            if (gradePercentage >= 70)
    {
        Console.WriteLine("Congratulations! You passed the test.");
    }
    else
    {
        Console.WriteLine("Sorry, you did not pass the test.");
    }
        
    }
}