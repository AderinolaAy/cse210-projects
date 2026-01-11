using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts;
    private readonly Random _rng;

    public PromptGenerator()
    {
        _rng = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today?",
            "What made me smile today?"
        };
    }

    public string GetRandomPrompt()
    {
        int idx = _rng.Next(_prompts.Count);
        return _prompts[idx];
    }

    
    public void AddPrompt(string prompt)
    {
        if (!string.IsNullOrWhiteSpace(prompt)) _prompts.Add(prompt);
    }
}