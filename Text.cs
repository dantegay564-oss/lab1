using System.Collections.Generic;
using System.Linq;
public class Text
{
    public List<Sentence> Sentences { get; set; } = new List<Sentence>();

    public override string ToString()
    {
        return string.Join(" ", Sentences.Select(s => s.Content));
    }
}
