using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4
{
    public class Text
    {
        public List<Sentence> Sentences { get; set; } = new List<Sentence>();

        public Dictionary<string, ConcordanceEntry> GetConcordance()
        {
            Dictionary<string, ConcordanceEntry> result = new Dictionary<string, ConcordanceEntry>();

            foreach (Sentence sentence in Sentences)
            {
                foreach (Word word in sentence.Words)
                {
                    string key = word.ToString().ToLowerInvariant();

                    if (!result.ContainsKey(key))
                    {
                        result[key] = new ConcordanceEntry();
                    }

                    result[key].Count++;
                    result[key].Lines.Add(sentence.LineNumber);
                }
            }
            return result;
        }

        public string GetConcordanceText()
        {
            Dictionary<string, ConcordanceEntry> concordance = GetConcordance();
            StringBuilder result = new StringBuilder();

            if (concordance.Count == 0)
                return "Текст пуст или не содержит слов.";

            foreach (var item in concordance.OrderBy(x => x.Key))
            {
                result.AppendLine(
                    item.Key + " — количество: " +
                    item.Value.Count + ", строки: " +
                    string.Join(", ", item.Value.Lines)
                );
            }
            return result.ToString();
        }

        public override string ToString()
        {
            return string.Join(" ", Sentences.Select(s => s.Content));
        }
    }
}