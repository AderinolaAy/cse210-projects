using System;
using System.Collections.Generic;

class Job
{
    
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    
    public Job() { }

    
    public Job(string jobTitle, string company, int startYear, int endYear)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startYear = startYear;
        _endYear = endYear;
    }

   
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

class Resume
{
    
    public string _name;
    public List<Job> _jobs;

    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();
    }

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        foreach (var job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}

