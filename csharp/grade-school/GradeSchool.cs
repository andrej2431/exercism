public class GradeSchool
{
    private SortedSet<(int, string)> _students = new();
    
    public bool Add(string student, int grade)
    {
        if (_students.Select(row => row.Item2).Contains(student))
        {
            return false;
        }
        
        return _students.Add((grade, student));
    }

    public IEnumerable<string> Roster() => _students.Select((student) => student.Item2);

    public IEnumerable<string> Grade(int grade) => _students.Where((row) => row.Item1 == grade).Select((row) => row.Item2);
}