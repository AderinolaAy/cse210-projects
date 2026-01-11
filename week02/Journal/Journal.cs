using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

public class Journal
{
    private readonly List<Entry> _entries;

    public IReadOnlyList<Entry> Entries => _entries.AsReadOnly();

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        if (entry == null) throw new ArgumentNullException(nameof(entry));
        _entries.Add(entry);
    }

    public void Clear()
    {
        _entries.Clear();
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (var e in _entries)
        {
            e.Display();
        }
    }

    
    public void SaveToCsv(string filename)
    {
        using var writer = new StreamWriter(filename, false, Encoding.UTF8);
        
        writer.WriteLine("\"Date\",\"Prompt\",\"Response\",\"Mood\",\"Tags\"");
        foreach (var e in _entries)
        {
            writer.WriteLine(e.ToCsvLine());
        }
    }

    
    public void LoadFromCsv(string filename)
    {
        if (!File.Exists(filename)) throw new FileNotFoundException("CSV file not found.", filename);
        var lines = File.ReadAllLines(filename, Encoding.UTF8);
        var newEntries = new List<Entry>();

        int start = 0;
        if (lines.Length > 0 && lines[0].TrimStart().StartsWith("\"Date\"", StringComparison.OrdinalIgnoreCase))
            start = 1;

        for (int i = start; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            var fields = ParseCsvLine(lines[i]);
            var entry = Entry.FromCsvFields(fields);
            newEntries.Add(entry);
        }

        _entries.Clear();
        _entries.AddRange(newEntries);
    }

   
    public void SaveToJson(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json, Encoding.UTF8);
    }

    
    public void LoadFromJson(string filename)
    {
        if (!File.Exists(filename)) throw new FileNotFoundException("JSON file not found.", filename);
        string json = File.ReadAllText(filename, Encoding.UTF8);
        var loaded = JsonSerializer.Deserialize<List<Entry>>(json);
        _entries.Clear();
        if (loaded != null) _entries.AddRange(loaded);
    }

    
    private static string[] ParseCsvLine(string line)
    {
        var fields = new List<string>();
        var sb = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"')
                {
                    
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        sb.Append('"');
                        i++; 
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
        }

        fields.Add(sb.ToString());
        return fields.ToArray();
    }
}