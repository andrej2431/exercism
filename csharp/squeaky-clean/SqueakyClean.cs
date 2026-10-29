using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder builder = new StringBuilder();

        bool camelReady = false;
        foreach (var c in identifier)
        {
            if (c == ' ')
            {
                builder.Append('_');
            }
            else if (char.IsControl(c))
            {
                builder.Append("CTRL");
            }
            
            else if (char.IsLetter(c) && c is < 'α' or > 'ω')
            {
                builder.Append(camelReady ? char.ToUpper(c) : c);
            }


            camelReady = c == '-';
        } 
        
        return builder.ToString();
    }
}
