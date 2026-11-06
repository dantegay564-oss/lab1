using System.Collections.Generic;

namespace lab4
{
    public class ConcordanceEntry
    {
        public int Count { get; set; } = 0;
        public SortedSet<int> Lines { get; set; } = new SortedSet<int>();
    }
}