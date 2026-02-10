using System;
using System.Collections.Generic;
using System.IO;

// Base class
abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract int RecordEvent();
    public virtual string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }
}

// SimpleGoal class
class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"{(_isComplete ? "[X]" : "[ ]")} {Name} ({Description})";
    }
}

// EternalGoal class
class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        return Points; // Always gives points, never completes
    }
}

// ChecklistGoal class
class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted == _targetCount)
        {
            return Points + _bonus;
        }
        return Points;
    }

    public override string GetDetailsString()
    {
        return $"[{(_timesCompleted >= _targetCount ? "X" : " ")}] {Name} ({Description}) -- Completed {_timesCompleted}/{_targetCount}";
    }
}

// GoalManager class
class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int points = _goals[goalIndex].RecordEvent();
            _score += points;
            CheckLevelUp();
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Score: {_score} | Level: {_level}");
    }

    private void CheckLevelUp()
    {
        if (_score >= _level * 1000)
        {
            _level++;
            Console.WriteLine($"🎉 Level Up! You are now Level {_level}!");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (Goal g in _goals)
            {
                writer.WriteLine($"{g.GetType().Name}|{g.Name}|{g.Description}|{g.Points}");
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            // Simplified: would need parsing logic for each goal type
        }
    }
}

// Program class
class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        manager.AddGoal(new SimpleGoal("Run Marathon", "Complete a marathon", 1000));
        manager.AddGoal(new EternalGoal("Read Scriptures", "Daily scripture study", 100));
        manager.AddGoal(new ChecklistGoal("Attend Temple", "Go 10 times", 50, 10, 500));

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Score");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.ShowGoals();
                    break;
                case "2":
                    manager.ShowGoals();
                    Console.Write("Enter goal number: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;
                case "3":
                    manager.ShowScore();
                    break;
                case "4":
                    running = false;
                    break;
            }
        }
    }
}