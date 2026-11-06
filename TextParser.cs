using System.IO;
using System.Text.RegularExpressions;

namespace lab4
{
    public class TextParser
    {
        public Text Parse(string source)
        {
            Text text = new Text();

            using (StringReader reader = new StringReader(source))
            {
                string line;
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    foreach (Match match in Regex.Matches(line, RegexPatterns.Sentence))
                    {
                        string part = match.Value.Trim();
                        if (part.Length > 0)
                        {
                            text.Sentences.Add(new Sentence(part, lineNumber));
                        }
                    }
                    lineNumber++;
                }
            }
            return text;
        }
    }
}