using System;

using System;
using System.Collections.Generic;
using System.Linq;using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a series of numbers (enter 0 to stop):");

        // Collect numbers from the user
        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();

            while (!int.TryParse(userInput, out input))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
                userInput = Console.ReadLine();
            }

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Compute the sum
        int sum = numbers.Sum();

        // Compute the average
        double average = numbers.Average();

        // Find the maximum number
        int max = numbers.Max();

        // Find the smallest positive number
        int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        if (smallestPositive == 0)
        {
            smallestPositive = null;
        }

        // Sort the list
        numbers.Sort();

        // Display results
        Console.WriteLine($"\nSum: {sum}");
        Console.WriteLine($"Average: {average:F2}");
        Console.WriteLine($"Maximum: {max}");
        Console.WriteLine(smallestPositive.HasValue
            ? $"Smallest positive number: {smallestPositive}"
            : "No positive numbers were entered.");
        Console.WriteLine("Sorted list: " + string.Join(", ", numbers));
        
    }
}