//Scripture library loaded from a file.
using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        List<Scripture> scriptures = LoadScriptures("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found.");
            return;
        }

        var rand = new Random();
        var scripture = scriptures[rand.Next(scriptures.Count)];

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                scripture.Display();
                Console.WriteLine("\nAll words hidden. Well done!");
                break;
            }
        }
    }

    static List<Scripture> LoadScriptures(string filePath)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
            return scriptures;

        foreach (var line in File.ReadAllLines(filePath))
        {
            // Format: Book|Chapter|VerseStart|[VerseEnd]|Text
            var parts = line.Split('|');
            if (parts.Length < 5) continue;

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int verseStart = int.Parse(parts[2]);
            string text = parts[4];

            Reference reference = parts[3] == "" 
                ? new Reference(book, chapter, verseStart)
                : new Reference(book, chapter, verseStart, int.Parse(parts[3]));

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}