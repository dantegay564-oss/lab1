using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

public class StopWords
{
    public static HashSet<string> Load(string fileName)
    {
        if (!File.Exists(fileName))
            return new HashSet<string>();

        return File.ReadAllLines(fileName)
            .SelectMany(line => Regex.Split(line, RegexPatterns.Whitespace))
            .Where(word => word.Length > 0)
            .Select(word => word.ToLower())
            .ToHashSet();
    }

    public static string Remove(string sentence, HashSet<string> stopWords)
    {
        return Regex.Replace(sentence, RegexPatterns.Word, match =>
            stopWords.Contains(match.Value.ToLower()) ? "" : match.Value);
    }
}