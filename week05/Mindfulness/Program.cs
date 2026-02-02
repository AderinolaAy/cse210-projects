using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();

            if (choice == "1")
                new BreathingActivity().Run();
            else if (choice == "2")
                new ReflectionActivity().Run();
            else if (choice == "3")
                new ListingActivity().Run();
            else if (choice == "4")
                break;
        }
    }
}
