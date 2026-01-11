using System;

public class Entry
{
    private DateTime _date;
    private string _prompt;
    private string _response;
    private string _mood;      
    private string _tags;      

    
    public DateTime Date => _date;
    public string Prompt
    {
        get => _prompt;
        set => _prompt = value ?? string.Empty;
    }
    public string Response
    {
        get => _response;
        set => _response = value ?? string.Empty;
    }
    public string Mood
    {
        get => _mood;
        set => _mood = value ?? string.Empty;
    }
    public string Tags
    {
        get => _tags;
        set => _tags = value ?? string.Empty;
    }

    
    public Entry(string prompt, string response, string mood = "", string tags = "")
    {
        _date = DateTime.Now;
        _prompt = prompt ?? string.Empty;
        _response = response ?? string.Empty;
        _mood = mood ?? string.Empty;
        _tags = tags ?? string.Empty;
    }

    
    public Entry() { }

    
    public void Display()
    {
        Console.WriteLine("----- Entry -----");
        Console.WriteLine($"Date: {_date:G}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        if (!string.IsNullOrWhiteSpace(_mood)) Console.WriteLine($"Mood: {_mood}");
        if (!string.IsNullOrWhiteSpace(_tags)) Console.WriteLine($"Tags: {_tags}");
        Console.WriteLine();
    }

    
    public string ToCsvLine()
    {
        return $"{QuoteCsv(_date.ToString("o"))},{QuoteCsv(_prompt)},{QuoteCsv(_response)},{QuoteCsv(_mood)},{QuoteCsv(_tags)}";
    }

    
    private static string QuoteCsv(string field)
    {
        if (field == null) field = string.Empty;
        string escaped = field.Replace("\"", "\"\"");
        return $"\"{escaped}\"";
    }

    
    public static Entry FromCsvFields(string[] fields)
    {
        if (fields.Length < 5) throw new FormatException("CSV line does not have enough fields for Entry.");
        var entry = new Entry
        {
            _date = DateTime.Parse(fields[0]),
            _prompt = fields[1],
            _response = fields[2],
            _mood = fields[3],
            _tags = fields[4]
        };
        return entry;
    }
}