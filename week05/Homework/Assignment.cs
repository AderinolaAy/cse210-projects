public class Assignment
{
    // Private member variables
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Optional helper method to access student name (for WritingAssignment)
    public string GetStudentName()
    {
        return _studentName;
    }
}