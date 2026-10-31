using System.Diagnostics;

public class Robot
{
    private static Random rnd = new Random();
    private static HashSet<string> _nameRegistry = new();
    private readonly char[] _capitalNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    private string _name = string.Empty;
    public string Name
    {
        get
        {
            if (_name == string.Empty)
            {
                while (_name == string.Empty || _nameRegistry.Contains(_name))
                {
                    _name = $"{rnd.GetString(_capitalNumbers, 2)}{rnd.Next(0,10)}{rnd.Next(0,10)}{rnd.Next(0,10)}";
                }
                
                _nameRegistry.Add(_name);
            }
            
            return _name;
        }
    }

    public void Reset() => _name = string.Empty;
}