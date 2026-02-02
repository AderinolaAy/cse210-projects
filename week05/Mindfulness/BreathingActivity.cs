using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly.") { }

    public void Run()
    {
        StartActivity();
        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            elapsed += 4;

            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            elapsed += 4;
        }

        EndActivity();
    }
}