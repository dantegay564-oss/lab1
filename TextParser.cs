using System.Text.RegularExpressions;

public class TextParser
{
    public Text Parse(string source)
    {
        Text text = new Text();
        foreach (Match match in Regex.Matches(source, RegexPatterns.Sentence))
        {
            string part = match.Value.Trim();
            if (part.Length > 0)
                text.Sentences.Add(new Sentence(part));
        }

        return text;
    }
}