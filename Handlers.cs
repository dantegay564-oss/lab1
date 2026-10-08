using System;
using System.Collections.Generic;
using System.IO;

namespace GeneticSearch
{
    static class Handlers
    {
        public static void HandleSearch(List<Protein> proteins, string searchSequence, StreamWriter writer)
        {
            string decodedSearch = Decoder.Decoding(searchSequence);
            bool found = false;

            writer.WriteLine("organism\t\t\t\tprotein");

            for (int i = 0; i < proteins.Count; i++)
            {
                if (proteins[i].amino_acids.Contains(decodedSearch))
                {
                    writer.WriteLine(proteins[i].organism + "\t\t" + proteins[i].name);
                    found = true;
                }
            }

            if (!found)
            {
                writer.WriteLine("NOT FOUND");
            }
        }

        public static void HandleDiff(List<Protein> proteins, string protein1Name, string protein2Name, StreamWriter writer)
        {
            Protein? p1 = null;
            Protein? p2 = null;

            for (int i = 0; i < proteins.Count; i++)
            {
                if (proteins[i].name == protein1Name)
                    p1 = proteins[i];
                if (proteins[i].name == protein2Name)
                    p2 = proteins[i];
            }

            writer.WriteLine("amino-acids difference:");

            if (p1 == null || p2 == null)
            {
                string missing = "";
                if (p1 == null) missing += protein1Name;
                if (p2 == null)
                {
                    if (missing != "") missing += ", ";
                    missing += protein2Name;
                }
                writer.WriteLine("MISSING: " + missing);
                return;
            }

            string seq1 = p1.Value.amino_acids;
            string seq2 = p2.Value.amino_acids;

            int maxLength = Math.Max(seq1.Length, seq2.Length);
            int differences = 0;

            for (int i = 0; i < maxLength; i++)
            {
                char c1 = i < seq1.Length ? seq1[i] : '\0';
                char c2 = i < seq2.Length ? seq2[i] : '\0';
                if (c1 != c2)
                    differences++;
            }

            writer.WriteLine(differences.ToString());
        }

        public static void HandleMode(List<Protein> proteins, string proteinName, StreamWriter writer)
        {
            Protein? foundProtein = null;

            for (int i = 0; i < proteins.Count; i++)
            {
                if (proteins[i].name == proteinName)
                {
                    foundProtein = proteins[i];
                    break;
                }
            }

            writer.WriteLine("amino-acid occurs:");

            if (foundProtein == null)
            {
                writer.WriteLine("MISSING: " + proteinName);
                return;
            }

            string sequence = foundProtein.Value.amino_acids;
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                char c = sequence[i];
                if (frequency.ContainsKey(c))
                    frequency[c]++;
                else
                    frequency[c] = 1;
            }

            char mostFrequent = '\0';
            int maxCount = 0;

            List<char> sortedChars = new List<char>(frequency.Keys);
            sortedChars.Sort();

            for (int i = 0; i < sortedChars.Count; i++)
            {
                if (frequency[sortedChars[i]] > maxCount)
                {
                    maxCount = frequency[sortedChars[i]];
                    mostFrequent = sortedChars[i];
                }
            }

            writer.WriteLine(mostFrequent + "          " + maxCount);
        }
    }
}