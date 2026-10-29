using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

public class Sentence
{
    public string Content { get; set; }

    public Sentence() { Content = ""; }
    public Sentence(string content) { Content = content.Trim(); }

    [XmlIgnore]
    public List<Word> Words
    {
        get
        {
            List<Word> result = new List<Word>();
            foreach (Match match in Regex.Matches(Content ?? "", RegexPatterns.Word))
                result.Add(new Word(match.Value));
            return result;
        }
    }

    [XmlIgnore]
    public List<Punctuation> PunctuationMarks
    {
        get
        {
            List<Punctuation> result = new List<Punctuation>();
            foreach (Match match in Regex.Matches(Content ?? "", RegexPatterns.Punctuation))
                result.Add(new Punctuation(match.Value));
            return result;
        }
    }

    public int WordCount()
    {
        return Words.Count;
    }
}