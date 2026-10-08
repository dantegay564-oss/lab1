using System;

namespace GeneticSearch
{
    static class Decoder
    {
        public static string Decoding(string amino_acids)
        {
            string decoded = String.Empty;
            for (int i = 0; i < amino_acids.Length; i++)
            {
                char ch = amino_acids[i];
                if (char.IsDigit(ch))
                {
                    char letter = amino_acids[i + 1];
                    int count = ch - '0';
                    for (int j = 1; j < count; j++)
                        decoded = decoded + letter;
                }
                else decoded = decoded + ch;
            }
            return decoded;
        }
    }
}