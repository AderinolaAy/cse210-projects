// Saved other information in the journal entry
// Improved the process of saving and loading to save as a .csv file that could be opened in Excel 
// Save or load document to a database or use a different library or format such as JSON for storage.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        var journal = new Journal();
        var prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal to CSV");
            Console.WriteLine("4. Load journal from CSV");
            Console.WriteLine("5. Save journal to JSON");
            Console.WriteLine("6. Load journal from JSON");
            Console.WriteLine("7. Clear current journal");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        WriteNewEntry(journal, prompts);
                        break;
                    case "2":
                        journal.DisplayAll();
                        break;
                    case "3":
                        Console.Write("Enter filename to save CSV (e.g., myjournal.csv): ");
                        var csvOut = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(csvOut))
                        {
                            journal.SaveToCsv(csvOut);
                            Console.WriteLine($"Saved to {csvOut}");
                        }
                        break;
                    case "4":
                        Console.Write("Enter filename to load CSV (e.g., myjournal.csv): ");
                        var csvIn = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(csvIn))
                        {
                            journal.LoadFromCsv(csvIn);
                            Console.WriteLine($"Loaded from {csvIn}");
                        }
                        break;
                    case "5":
                        Console.Write("Enter filename to save JSON (e.g., myjournal.json): ");
                        var jsonOut = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(jsonOut))
                        {
                            journal.SaveToJson(jsonOut);
                            Console.WriteLine($"Saved to {jsonOut}");
                        }
                        break;
                    case "6":
                        Console.Write("Enter filename to load JSON (e.g., myjournal.json): ");
                        var jsonIn = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(jsonIn))
                        {
                            journal.LoadFromJson(jsonIn);
                            Console.WriteLine($"Loaded from {jsonIn}");
                        }
                        break;
                    case "7":
                        Console.Write("Are you sure you want to clear the current journal? (y/n): ");
                        var confirm = Console.ReadLine();
                        if (confirm?.Trim().ToLower() == "y")
                        {
                            journal.Clear();
                            Console.WriteLine("Journal cleared.");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void WriteNewEntry(Journal journal, PromptGenerator prompts)
    {
        string prompt = prompts.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine() ?? string.Empty;

        Console.Write("Optional - mood (press Enter to skip): ");
        string mood = Console.ReadLine() ?? string.Empty;

        Console.Write("Optional - tags (comma-separated, press Enter to skip): ");
        string tags = Console.ReadLine() ?? string.Empty;

        var entry = new Entry(prompt, response, mood, tags);
        journal.AddEntry(entry);

        Console.WriteLine("Entry saved.");
    }
}