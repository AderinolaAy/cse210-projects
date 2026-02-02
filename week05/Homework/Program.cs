class Program
{
    static void Main(string[] args)
    {
        // Test base Assignment
        Assignment assignment = new Assignment("Mary Waters", "European History");
        Console.WriteLine(assignment.GetSummary());

        // Test MathAssignment
        MathAssignment mathAssignment = new MathAssignment("John Smith", "Fractions", "7.3", "3-10, 20-21");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Test WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}